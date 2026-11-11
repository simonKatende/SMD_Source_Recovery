// tests/FeesFollowUp.IntegrationTests/FeesFollowUpServiceTests.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.IntegrationTests;

/// A throwaway school: two families, one with two children. Fees were billed three weeks ago.
public sealed class School : IDisposable
{
    public const string KatoFamily  = "0771000001";   // Ali (P.3, owes 500k) and Sara (P.5, owes 300k)
    public const string OkelloFamily = "0772000002";  // Tom (P.4, owes 400k)

    public TestDatabase Db { get; }
    public FeesFollowUpService Service { get; }
    public List<(string phone, string message)> Sent { get; } = new List<(string, string)>();
    public string FailSendsTo { get; set; }

    public School(bool applyMigration = true)
    {
        Db = TestDatabase.Create(applyMigration);
        Db.AddStudent("A1", "Ali Kato",   "P.3", KatoFamily);
        Db.AddStudent("A2", "Sara Kato",  "P.5", KatoFamily);
        Db.AddStudent("B1", "Tom Okello", "P.4", OkelloFamily);
        Db.Bill("A1", 500_000m);
        Db.Bill("A2", 300_000m);
        Db.Bill("B1", 400_000m);
        Service = NewService();
    }

    /// A fresh service (as a second PC, or the application reopened, would have).
    public FeesFollowUpService NewService()
    {
        var service = new FeesFollowUpService(Db.ConnectionString);
        service.SendSms = (string phone, string message, out string error) =>
        {
            if (FailSendsTo != null && phone.EndsWith(FailSendsTo.Substring(1)))
            {
                error = "gateway down";
                return false;
            }
            Sent.Add((phone, message));
            error = null;
            return true;
        };
        return service;
    }

    public GuardianWorklistRow Family(string key)
        => Service.GetGuardianWorklist("", 0).Single(g => g.GuardianContact == key);

    public FeesContactLog Entry(ContactOutcome outcome, string student = null, DateTime? on = null,
        string note = null, ContactChannel channel = ContactChannel.Phone) => new FeesContactLog
    {
        ContactDate   = on ?? DateTime.Now,
        LoggedBy      = "bursar",
        Channel       = channel,
        Outcome       = outcome,
        StudentNumber = student,
        Note          = note,
    };

    public static List<PromiseInstalment> Plan(params (int inDays, decimal? amount)[] parts)
        => parts.Select(p => new PromiseInstalment { DueDate = DateTime.Today.AddDays(p.inDays), Amount = p.amount }).ToList();

    public void Dispose() => Db.Dispose();
}

public class MigrationTests
{
    [Fact]
    public void Service_explains_when_the_database_update_is_missing()
    {
        using var school = new School(applyMigration: false);
        var ex = Assert.Throws<InvalidOperationException>(() => school.Service.GetSettings());
        Assert.Contains("2026-11-11_fees_followup_crm.sql", ex.Message);
    }

    [Fact]
    public void Migration_can_be_run_twice()
    {
        using var school = new School();
        school.Db.ApplyMigration();
        Assert.Equal(3, school.Service.GetGuardianWorklist("", 0).Sum(g => g.StudentCount));
    }

    [Fact]
    public void Migration_stamps_only_this_terms_rows_and_keeps_the_rest_as_history()
    {
        using var school = new School(applyMigration: false);
        DateTime lastTerm = TestDatabase.TermOpened.AddDays(-30);
        DateTime thisTerm = TestDatabase.TermOpened.AddDays(2);
        school.Db.Run(@"INSERT INTO tbl_FeesContactLog (StudentNumber, ContactDate, LoggedBy, Channel, Outcome, PromiseDate, PromiseAmount, GuardianKey)
                        VALUES ('A1', @old, 'bursar', 'Phone', 'Promised', @oldDue, 100000, @gk),
                               ('',   @new, 'bursar', 'Phone', 'Contacted', NULL, NULL, @gk)",
            ("@old", lastTerm), ("@oldDue", lastTerm.AddDays(5)), ("@new", thisTerm), ("@gk", School.KatoFamily));
        school.Db.Run(@"INSERT INTO tbl_SmsReminderLog (GuardianKey, PromiseDate, ReminderType, SentAt)
                        VALUES (@gk, @d, 'Overdue', @old)", ("@gk", School.KatoFamily), ("@d", lastTerm), ("@old", lastTerm));

        school.Db.ApplyMigration();

        Assert.Equal(1, school.Db.Scalar<int>("SELECT COUNT(*) FROM tbl_FeesContactLog WHERE SemesterId = 'TermIII-2026'"));
        Assert.Equal(1, school.Db.Scalar<int>("SELECT COUNT(*) FROM tbl_FeesContactLog WHERE SemesterId IS NULL"));
        Assert.Equal(1, school.Db.Scalar<int>("SELECT COUNT(*) FROM tbl_SmsReminderLog WHERE SemesterId IS NULL"));

        // Last term's unpaid promise no longer makes the family a "missed promise" this term…
        var kato = school.Family(School.KatoFamily);
        Assert.False(kato.Promise.HasPromise);
        Assert.NotEqual(PriorityTier.BrokenPromise, kato.Tier);
        Assert.False(kato.CallRequired);
        // …this term's call still counts…
        Assert.Equal(thisTerm, kato.LastContactDate);
        // …and both stay visible in the family's history, labelled by term.
        var history = school.Service.GetGuardianContactHistory(School.KatoFamily, new[] { "A1", "A2" });
        Assert.Equal(new[] { "Term III 2026", "Earlier terms" },
            history.AsEnumerable().Select(r => r["Term"].ToString()).ToArray());
    }
}

public class TermTests
{
    [Fact]
    public void Dates_are_tied_to_the_term_they_were_entered_for()
    {
        using var school = new School();
        var settings = school.Service.GetSettings();
        Assert.True(settings.TermDatesNeedSetting);
        Assert.Equal("TermIII-2026", settings.WorkingSemester);

        settings.TermStartDate = DateTime.Today.AddDays(-21);
        settings.TermEndDate   = DateTime.Today.AddDays(63);
        school.Service.SaveSettings(settings);

        settings = school.NewService().GetSettings();
        Assert.False(settings.TermDatesNeedSetting);
        Assert.Equal(DateTime.Today.AddDays(63), settings.TermEndDate);
        Assert.True(school.NewService().AreTermDatesConfigured());

        // The school moves to a new term in the application: the old dates stop applying.
        school.Db.SetActiveTerm("TermI-2027");
        settings = school.NewService().GetSettings();
        Assert.True(settings.TermDatesNeedSetting);
        Assert.Null(settings.TermStartDate);
        Assert.Null(settings.TermEndDate);
        Assert.False(school.NewService().AreTermDatesConfigured());
    }

    [Fact]
    public void Old_unstamped_dates_for_a_finished_term_are_treated_as_not_set()
    {
        using var school = new School();
        school.Db.Run(@"INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue)
                        VALUES ('TermStartDate', '2026-05-10'), ('TermEndDate', '2026-08-19')");
        Assert.True(school.Service.GetSettings().TermDatesNeedSetting);
    }

    [Fact]
    public void A_new_term_starts_with_a_clean_slate()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.Promised), School.Plan((3, 300_000m)));
        Assert.True(school.Family(School.KatoFamily).Promise.HasActive);

        // New term, fees billed afresh.
        school.Db.SetActiveTerm("TermI-2027");
        school.Db.Bill("A1", 500_000m, "TermI-2027", DateTime.Today);
        var kato = school.NewService().GetGuardianWorklist("", 0).Single(g => g.GuardianContact == School.KatoFamily);

        Assert.False(kato.Promise.HasPromise);
        Assert.Null(kato.LastContactDate);
        Assert.Equal(TodayStatus.NotCalled, kato.TodayStatus);
    }

    [Fact]
    public void Settings_round_trip_including_long_messages()
    {
        using var school = new School();
        var s = school.Service.GetSettings();
        string longMessage = "Dear Parent, {names} " + new string('x', 400) + " {balance} - {school}";
        s.SmsTemplateOverdue   = longMessage;
        s.DefaultSmsStyle      = SmsStyle.PerChild;
        s.AutoRemindersEnabled = true;
        s.AutoReminderTime     = "7:30";
        s.StaleThresholdDays   = 9;
        school.Service.SaveSettings(s);

        s = school.NewService().GetSettings();
        Assert.Equal(longMessage, s.SmsTemplateOverdue);   // used to be cut off at 200 characters
        Assert.Equal(SmsStyle.PerChild, s.DefaultSmsStyle);
        Assert.True(s.AutoRemindersEnabled);
        Assert.Equal("07:30", s.AutoReminderTime);
        Assert.Equal(9, s.StaleThresholdDays);
    }
}

public class PromiseTests
{
    [Fact]
    public void A_family_promise_is_kept_when_a_cleared_sibling_received_the_money()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-6)), School.Plan((-2, 300_000m)));
        // The parent paid the 300k into Sara's account, clearing her; Ali still owes.
        school.Db.Pay("A2", 300_000m, DateTime.Today.AddDays(-3));

        var kato = school.Family(School.KatoFamily);

        Assert.Equal(new[] { "Ali Kato" }, kato.Students.Select(s => s.FullName).ToArray());   // only the child owing is listed
        Assert.False(kato.Promise.IsBroken);
        Assert.Equal("Promise kept", kato.PromiseStatusText);
        Assert.NotEqual(PriorityTier.BrokenPromise, kato.Tier);
    }

    [Fact]
    public void A_promise_for_one_child_ignores_money_paid_for_another()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, student: "A1", on: DateTime.Today.AddDays(-6)), School.Plan((-2, 200_000m)));
        school.Db.Pay("A2", 200_000m, DateTime.Today.AddDays(-3));

        var kato = school.Family(School.KatoFamily);
        Assert.True(kato.Promise.IsBroken);
        Assert.Equal(PriorityTier.BrokenPromise, kato.Tier);
        Assert.Equal("Student", school.Db.Scalar<string>("SELECT PromiseScope FROM tbl_FeesContactLog"));
    }

    [Fact]
    public void A_payment_plan_is_stored_and_followed_instalment_by_instalment()
    {
        using var school = new School();
        int id = school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-10)),
            School.Plan((-5, 300_000m), (4, 300_000m), (18, 200_000m)));
        school.Db.Pay("A1", 300_000m, DateTime.Today.AddDays(-6));

        Assert.Equal(3, school.Service.GetInstalments(id).Count);
        Assert.Equal(800_000m, school.Db.Scalar<decimal>("SELECT PromiseAmount FROM tbl_FeesContactLog"));
        Assert.Equal("Family", school.Db.Scalar<string>("SELECT PromiseScope FROM tbl_FeesContactLog"));

        var kato = school.Family(School.KatoFamily);
        var parts = kato.Promise.ActivePlans.Single().Instalments.OrderBy(i => i.DueDate).ToList();
        Assert.Equal(new[] { InstalmentStatus.Kept, InstalmentStatus.Pending, InstalmentStatus.Pending },
            parts.Select(p => p.Status).ToArray());
        Assert.Equal(DateTime.Today.AddDays(4), kato.LatestPromiseDate);
        Assert.Equal(500_000m, kato.Promise.RemainingPromised);

        // The second instalment's date passes unpaid.
        school.Db.Run("UPDATE tbl_FeesPromiseInstalment SET DueDate = @d WHERE DueDate = @was",
            ("@d", DateTime.Today.AddDays(-1)), ("@was", DateTime.Today.AddDays(4)));
        kato = school.Family(School.KatoFamily);
        Assert.True(kato.Promise.IsBroken);
        Assert.Equal(PriorityTier.BrokenPromise, kato.Tier);
        Assert.Contains("Missed UGX 300,000", kato.PromiseStatusText);
    }

    [Fact]
    public void Editing_and_deleting_a_promise_keeps_its_instalments_in_step()
    {
        using var school = new School();
        var entry = school.Entry(ContactOutcome.Promised);
        entry.ContactId = school.Service.LogGuardianContact(School.KatoFamily, entry, School.Plan((3, 100_000m), (10, 100_000m)));

        school.Service.UpdateContact(entry, School.Plan((5, 250_000m)));
        var only = Assert.Single(school.Service.GetInstalments(entry.ContactId));
        Assert.Equal((DateTime.Today.AddDays(5), 250_000m), (only.DueDate, only.Amount.Value));

        // Changed to "no answer": the plan goes.
        entry.Outcome = ContactOutcome.NoAnswer;
        school.Service.UpdateContact(entry);
        Assert.Empty(school.Service.GetInstalments(entry.ContactId));
        Assert.False(school.Family(School.KatoFamily).Promise.HasPromise);

        entry.Outcome = ContactOutcome.Promised;
        school.Service.UpdateContact(entry, School.Plan((5, 250_000m)));
        school.Service.DeleteContact(entry.ContactId);
        Assert.Equal(0, school.Db.Scalar<int>("SELECT COUNT(*) FROM tbl_FeesPromiseInstalment"));
    }

    [Fact]
    public void A_newer_promise_replaces_the_older_one()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-8)), School.Plan((-3, 300_000m)));
        Assert.True(school.Family(School.KatoFamily).Promise.IsBroken);

        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.Promised), School.Plan((6, 300_000m)));
        var kato = school.Family(School.KatoFamily);
        Assert.False(kato.Promise.IsBroken);
        Assert.Equal(DateTime.Today.AddDays(6), kato.LatestPromiseDate);
    }

    [Fact]
    public void A_promise_logged_before_payment_plans_existed_still_counts()
    {
        using var school = new School();
        // The old way: one date and amount on the contact row, a child selected, no instalment rows.
        school.Db.Run(@"INSERT INTO tbl_FeesContactLog (StudentNumber, ContactDate, LoggedBy, Channel, Outcome, PromiseDate, PromiseAmount, GuardianKey, SemesterId)
                        VALUES ('A1', @on, 'bursar', 'Phone', 'Promised', @due, 300000, @gk, 'TermIII-2026')",
            ("@on", DateTime.Today.AddDays(-5)), ("@due", DateTime.Today.AddDays(2)), ("@gk", School.KatoFamily));
        school.Db.Pay("A2", 300_000m, DateTime.Today.AddDays(-1));

        var kato = school.Family(School.KatoFamily);
        Assert.True(kato.Promise.HasPromise);
        Assert.True(kato.Promise.ActivePlans.Single().IsFamily);   // old promises were family promises
        Assert.Equal("Promise kept", kato.PromiseStatusText);
    }
}

public class DailyListTests
{
    [Fact]
    public void Worked_families_stay_on_the_list_with_their_status()
    {
        using var school = new School();
        var list = school.Service.GetDailyWorklist();
        Assert.Equal(2, list.Count);
        Assert.All(list, g => Assert.Equal(TodayStatus.NotCalled, g.TodayStatus));

        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.NoAnswer));
        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.ContactOff));
        list = school.Service.GetDailyWorklist();
        var kato = list.Single(g => g.GuardianContact == School.KatoFamily);
        Assert.Equal((TodayStatus.Tried, "Tried x2"), (kato.TodayStatus, kato.TodayStatusText));

        school.Service.LogGuardianContact(School.OkelloFamily, school.Entry(ContactOutcome.Contacted));
        list = school.Service.GetDailyWorklist();
        Assert.Equal(2, list.Count);   // the family reached is still shown, as Done
        Assert.Equal(TodayStatus.Done, list.Single(g => g.GuardianContact == School.OkelloFamily).TodayStatus);

        // Next to call is always at the top: tried before done here, nobody left untouched.
        Assert.Equal(new[] { TodayStatus.Tried, TodayStatus.Done }, list.Select(g => g.TodayStatus).ToArray());
        Assert.Equal(0, DailyListLogic.NextToWork(list, 1));
    }

    [Fact]
    public void Yesterdays_calls_do_not_count_as_today()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.Contacted, on: DateTime.Today.AddDays(-1)));
        var kato = school.Family(School.KatoFamily);
        Assert.Equal(TodayStatus.NotCalled, kato.TodayStatus);
        Assert.Equal(PriorityTier.Current, kato.Tier);   // spoken to yesterday: up to date
        Assert.DoesNotContain(school.Service.GetDailyWorklist(), g => g.GuardianContact == School.KatoFamily);
    }

    [Fact]
    public void A_promise_hides_a_family_until_the_day_it_falls_due()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-2)), School.Plan((3, 800_000m)));
        Assert.DoesNotContain(school.Service.GetDailyWorklist(), g => g.GuardianContact == School.KatoFamily);

        school.Db.Run("UPDATE tbl_FeesPromiseInstalment SET DueDate = @d", ("@d", DateTime.Today));
        var kato = school.Service.GetDailyWorklist().Single(g => g.GuardianContact == School.KatoFamily);
        Assert.True(kato.PromiseDueToday);
    }

    [Fact]
    public void A_student_with_only_a_balance_brought_forward_is_not_left_out()
    {
        using var school = new School();
        school.Db.AddStudent("C1", "Zed Musa", "P.6", "0773000003");
        school.Db.BroughtForward("C1", 150_000m);                       // owes from last term, not yet billed this term
        school.Db.AddStudent("C2", "Left School", "P.6", "0774000004", status: "Left");
        school.Db.BroughtForward("C2", 90_000m);

        var all = school.Service.GetGuardianWorklist("", 0);
        var musa = all.Single(g => g.GuardianContact == "0773000003");
        Assert.Equal(150_000m, musa.TotalBalance);
        Assert.DoesNotContain(all, g => g.GuardianContact == "0774000004");   // no longer an active student
        Assert.Contains(school.Service.GetDailyWorklist(), g => g.GuardianContact == "0773000003");
    }

    [Fact]
    public void A_family_with_no_phone_number_keeps_its_own_history()
    {
        using var school = new School();
        school.Db.AddStudent("LONGNUMBER12", "No Phone", "P.2", null);
        school.Db.Bill("LONGNUMBER12", 100_000m);
        string key = "NOCONTACT-LONGNUMBER12";   // 22 characters: used to be cut to 20

        school.Service.LogGuardianContact(key, school.Entry(ContactOutcome.Contacted, channel: ContactChannel.InPerson));
        var row = school.Family(key);
        Assert.True(row.IsUnreachable);
        Assert.Equal(TodayStatus.Done, row.TodayStatus);
        Assert.Single(school.Service.GetGuardianContactHistory(key, new[] { "LONGNUMBER12" }).Rows);
    }

    [Fact]
    public void The_dashboard_agrees_with_the_daily_list()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.NoAnswer));
        school.Service.LogGuardianContact(School.OkelloFamily, school.Entry(ContactOutcome.Promised), School.Plan((0, 400_000m)));

        var list = school.Service.GetDailyWorklist();
        var data = school.Service.GetDashboardData();

        Assert.Equal(list.Count, data.DailyListTotal);
        Assert.Equal(list.Count(g => g.TodayStatus == TodayStatus.Done),  data.DailyListContacted);
        Assert.Equal(list.Count(g => g.TodayStatus == TodayStatus.Tried), data.DailyListTried);
        Assert.Equal(1_200_000m, data.TotalOutstanding);
        Assert.Equal("Term III 2026", data.TermName);
        Assert.True(data.TermDatesNeedSetting);

        Assert.Equal(new[] { "P.3", "P.4", "P.5" }, data.ByClass.Select(c => c.ClassId).OrderBy(c => c).ToArray());
        Assert.Equal(1_200_000m, data.ByClass.Sum(c => c.Outstanding));
        Assert.Equal((1, 400_000m), (data.Promises.DueTodayCount, data.Promises.DueTodayAmount));
        var bursar = Assert.Single(data.TeamActivity);
        Assert.Equal(("bursar", 2, 2, 1, 1, 400_000m),
            (bursar.Officer, bursar.ContactsToday, bursar.ContactsThisWeek, bursar.ReachedThisWeek, bursar.PromisesThisWeek, bursar.PromisedThisWeek));
        Assert.Empty(data.WeeklyTrend);   // no term dates yet
    }

    [Fact]
    public void The_weekly_trend_appears_once_term_dates_are_set()
    {
        using var school = new School();
        var s = school.Service.GetSettings();
        s.TermStartDate = TestDatabase.TermOpened;
        s.TermEndDate   = TestDatabase.TermOpened.AddDays(83);
        school.Service.SaveSettings(s);
        school.Db.Pay("A1", 300_000m, TestDatabase.TermOpened.AddDays(8));

        var data = school.NewService().GetDashboardData();
        Assert.Equal(4, data.WeeklyTrend.Count);   // day 21 of term = week 4
        Assert.Equal(300_000m, data.WeeklyTrend[1].Collected);
        Assert.Equal(25.0, data.WeeklyTrend.Last().CumulativePct, 1);
        Assert.Equal(4, data.CurrentTermWeek);
        Assert.Equal(12, data.TotalTermWeeks);
    }
}

public class ReminderTests
{
    private static void PromiseDueToday(School school, string family, decimal amount, string student = null)
        => school.Service.LogGuardianContact(family,
            school.Entry(ContactOutcome.Promised, student, DateTime.Today.AddDays(-4)), School.Plan((0, amount)));

    [Fact]
    public void A_family_gets_one_message_with_the_family_total()
    {
        using var school = new School();
        PromiseDueToday(school, School.KatoFamily, 600_000m);

        var item = Assert.Single(school.Service.GetRemindersPreview());
        Assert.Equal("DayOf", item.ReminderType);
        Assert.Equal(1, item.SmsCount);
        Assert.Contains("Ali Kato (P.3) and Sara Kato (P.5)", item.Message);
        Assert.Contains("of UGX 600,000", item.Message);
        Assert.Contains("Balance: UGX 800,000", item.Message);
        Assert.Contains("Test School", item.Message);
    }

    [Fact]
    public void A_per_child_family_gets_each_child_once_never_the_same_text_twice()
    {
        using var school = new School();
        school.Service.SetGuardianSmsStyle(School.KatoFamily, SmsStyle.PerChild, "bursar");
        PromiseDueToday(school, School.KatoFamily, 600_000m);

        var item = Assert.Single(school.Service.GetRemindersPreview());
        Assert.Equal(2, item.SmsCount);
        Assert.Contains("Ali Kato (P.3)", item.Messages[0]);
        Assert.Contains("UGX 500,000", item.Messages[0]);
        Assert.Contains("Sara Kato (P.5)", item.Messages[1]);
        Assert.Contains("UGX 300,000", item.Messages[1]);
        Assert.All(item.Messages, m => Assert.DoesNotContain("600,000", m));   // family amount is not pinned on one child

        var result = school.Service.ExecuteSendReminders(new List<ReminderItem> { item });
        Assert.Equal(1, result.DayOfCount);
        Assert.Equal(2, school.Sent.Count);
        Assert.Equal(2, school.Sent.Select(s => s.message).Distinct().Count());
        Assert.True(school.Family(School.KatoFamily).SmsStyleIsOwn);
    }

    [Fact]
    public void A_reminder_is_sent_once_and_never_repeated()
    {
        using var school = new School();
        PromiseDueToday(school, School.KatoFamily, 600_000m);
        PromiseDueToday(school, School.OkelloFamily, 400_000m);

        var result = school.Service.ExecuteSendReminders(school.Service.GetRemindersPreview());
        Assert.Equal(2, result.TotalSent);
        Assert.Equal(2, school.Sent.Count);
        Assert.Equal(2, school.Db.Scalar<int>("SELECT COUNT(*) FROM tbl_SmsReminderLog WHERE SemesterId = 'TermIII-2026' AND ReminderType = 'DayOf'"));

        Assert.Empty(school.Service.GetRemindersPreview());
        var again = school.Service.ExecuteSendReminders(school.Service.GetRemindersPreview());
        Assert.Equal(0, again.TotalSent);
        Assert.Equal(2, school.Sent.Count);
        Assert.Equal(1, school.Family(School.KatoFamily).RemindersSentCount);
    }

    [Fact]
    public void A_parent_who_paid_what_they_promised_is_not_reminded()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-9)), School.Plan((-3, 300_000m)));
        Assert.Equal("Overdue", Assert.Single(school.Service.GetRemindersPreview()).ReminderType);

        school.Db.Pay("A1", 300_000m, DateTime.Today.AddDays(-1));   // still owes 500k in total, but kept the promise
        Assert.Empty(school.Service.GetRemindersPreview());
    }

    [Fact]
    public void A_replaced_promise_is_not_chased()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-9)), School.Plan((-3, 300_000m)));
        school.Service.LogGuardianContact(School.KatoFamily, school.Entry(ContactOutcome.Promised), School.Plan((12, 300_000m)));
        Assert.Empty(school.Service.GetRemindersPreview());
    }

    [Fact]
    public void A_failed_send_is_reported_and_can_be_retried()
    {
        using var school = new School();
        PromiseDueToday(school, School.KatoFamily, 600_000m);
        school.FailSendsTo = School.KatoFamily;

        var result = school.Service.ExecuteSendReminders(school.Service.GetRemindersPreview());
        Assert.Equal(0, result.TotalSent);
        Assert.Contains("gateway down", Assert.Single(result.Failures));

        school.FailSendsTo = null;
        Assert.Single(school.Service.GetRemindersPreview());   // not logged as sent, so still due
    }

    [Fact]
    public void Balance_reminders_follow_the_family_style_and_the_cooling_off_period()
    {
        using var school = new School();
        // Make the Okello family a missed promise (eligible for a balance reminder once out of the promise window).
        school.Service.LogGuardianContact(School.OkelloFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-20)), School.Plan((-12, 400_000m)));

        var item = Assert.Single(school.Service.GetBalanceRemindersPreview());
        Assert.Equal(School.OkelloFamily, item.GuardianKey);
        Assert.Contains("Tom Okello (P.4) has an outstanding balance of UGX 400,000", item.Message);

        school.Service.ExecuteSendReminders(new List<ReminderItem> { item });
        Assert.Single(school.Sent);
        Assert.Empty(school.Service.GetBalanceRemindersPreview());   // within the cooling-off period
    }

    [Fact]
    public void Automatic_reminders_run_once_a_day_across_all_computers()
    {
        using var school = new School();
        PromiseDueToday(school, School.KatoFamily, 600_000m);

        Assert.False(school.Service.IsAutomaticRunDue(DateTime.Today.AddHours(10)));   // switched off by default
        var s = school.Service.GetSettings();
        s.AutoRemindersEnabled = true;
        s.AutoReminderTime     = "09:00";
        school.Service.SaveSettings(s);
        Assert.False(school.Service.IsAutomaticRunDue(DateTime.Today.AddHours(8)));
        Assert.True(school.Service.IsAutomaticRunDue(DateTime.Today.AddHours(10)));

        var first  = school.Service.RunAutomaticReminders("bursar");
        var second = school.NewService().RunAutomaticReminders("another-pc");   // a second computer, same day

        Assert.False(first.AlreadyRanToday);
        Assert.Equal(1, first.TotalSent);
        Assert.True(second.AlreadyRanToday);
        Assert.Single(school.Sent);
        Assert.False(school.Service.IsAutomaticRunDue(DateTime.Today.AddHours(10)));

        var run = school.Service.GetLastAutoRun();
        Assert.Equal((DateTime.Today, 1, 0, "bursar"), (run.RunDate, run.SentCount, run.FailedCount, run.StartedBy));
        Assert.NotNull(run.FinishedAt);
        Assert.True(school.Service.GetDashboardData().AutoRemindersEnabled);
    }

    [Fact]
    public void An_automatic_run_with_nothing_due_still_records_the_day()
    {
        using var school = new School();
        var result = school.Service.RunAutomaticReminders("bursar");
        Assert.Equal(0, result.TotalSent);
        Assert.Equal("No promise reminders were due.", school.Service.GetLastAutoRun().Note);
    }
}

public class ReportTests
{
    [Fact]
    public void The_interactions_report_lists_who_was_contacted_and_how_they_responded()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, note: "Will pay after salary"),
            School.Plan((3, 300_000m), (17, 500_000m)));
        school.Service.LogGuardianContact(School.OkelloFamily, school.Entry(ContactOutcome.NoAnswer));
        school.Service.LogGuardianContact(School.OkelloFamily, school.Entry(ContactOutcome.Contacted, on: DateTime.Today.AddDays(-40)));

        DataTable report = school.Service.GetInteractionsReport(DateTime.Today.AddDays(-6), DateTime.Today);

        Assert.Equal(2, report.Rows.Count);   // the one from 40 days ago is outside the dates
        DataRow kato = report.AsEnumerable().Single(r => r["GuardianKey"].ToString() == School.KatoFamily);
        Assert.Equal("Parent (Mother)", kato["GuardianDisplay"]);
        Assert.Equal(School.KatoFamily, kato["Phone"]);
        Assert.Equal("Ali Kato, Sara Kato", kato["StudentName"]);
        Assert.Equal("P.3, P.5", kato["Classes"]);
        Assert.Equal("Promised", kato["Outcome"]);
        Assert.Equal("Will pay after salary", kato["Note"]);
        Assert.Equal("Term III 2026", kato["Term"]);
        Assert.Equal(800_000m, kato["FamilyBalance"]);
        string plan = kato["PaymentPlan"].ToString();
        Assert.Contains("300,000", plan);
        Assert.Contains("500,000", plan);
        Assert.Contains(DateTime.Today.AddDays(3).ToString("dd MMM yyyy"), plan);
    }

    [Fact]
    public void The_promise_report_shows_each_instalment_and_where_it_stands()
    {
        using var school = new School();
        school.Service.LogGuardianContact(School.KatoFamily,
            school.Entry(ContactOutcome.Promised, on: DateTime.Today.AddDays(-10)),
            School.Plan((-5, 300_000m), (-1, 200_000m), (9, 300_000m)));
        school.Db.Pay("A2", 300_000m, DateTime.Today.AddDays(-7));

        var rows = school.Service.GetPromiseReport();

        Assert.Equal(new[] { "Kept", "Missed", "Pending" }, rows.Select(r => r.Status).ToArray());
        Assert.All(rows, r => Assert.Equal("Whole family", r.PromiseFor));
        Assert.Equal((200_000m, 0m, 200_000m), (rows[1].AmountPromised, rows[1].AmountPaid, rows[1].AmountOutstanding));
        Assert.Equal(300_000m, rows[0].AmountPaid);
        Assert.Equal(500_000m, rows[0].FamilyBalance);
        Assert.Equal("bursar", rows[0].LoggedBy);
    }
}
