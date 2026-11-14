using System;
using System.Collections.Generic;
using System.Linq;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class WorkflowTests
{
    private static readonly DateTime Today = new DateTime(2026, 10, 20);

    // ── Term ──────────────────────────────────────────────────────────────────

    [Theory]
    [InlineData("TermIII-2026", "TermIII-2026", true)]
    [InlineData("termiii-2026", "TermIII-2026", true)]
    [InlineData("TermII-2026",  "TermIII-2026", false)]
    public void Stamped_dates_apply_only_to_their_own_term(string stamped, string working, bool expected)
        => Assert.Equal(expected, FeesTerm.DatesApply(stamped, working, Today.AddDays(30), Today));

    [Fact]
    public void Unstamped_dates_apply_only_while_that_term_is_still_running()
    {
        Assert.True(FeesTerm.DatesApply(null, "TermIII-2026", Today.AddDays(1), Today));
        Assert.True(FeesTerm.DatesApply("", "TermIII-2026", Today, Today));
        Assert.False(FeesTerm.DatesApply(null, "TermIII-2026", Today.AddDays(-1), Today));
        Assert.False(FeesTerm.DatesApply(null, "TermIII-2026", null, Today));
    }

    [Theory]
    [InlineData("TermIII-2026", "Term III 2026")]
    [InlineData("TermI-2027", "Term I 2027")]
    [InlineData("SEMII-2026", "Semester II 2026")]
    [InlineData("Semester No Set!", "Semester No Set!")]
    [InlineData("", "(no term set)")]
    public void Term_names_read_naturally(string id, string expected)
        => Assert.Equal(expected, FeesTerm.DisplayName(id));

    [Fact]
    public void Week_of_term_counts_from_the_start_date()
    {
        var start = new DateTime(2026, 9, 7);
        var end   = new DateTime(2026, 12, 4);   // 89 days → 13 weeks
        Assert.Equal((1, 13),  FeesTerm.WeekOfTerm(start, start, end));
        Assert.Equal((1, 13),  FeesTerm.WeekOfTerm(start.AddDays(6), start, end));
        Assert.Equal((2, 13),  FeesTerm.WeekOfTerm(start.AddDays(7), start, end));
        Assert.Equal((13, 13), FeesTerm.WeekOfTerm(end.AddDays(30), start, end));
        Assert.Equal((0, 13),  FeesTerm.WeekOfTerm(start.AddDays(-1), start, end));
        Assert.Equal((0, 0),   FeesTerm.WeekOfTerm(Today, null, end));
    }

    // ── Daily list ────────────────────────────────────────────────────────────

    private static GuardianWorklistRow Row(PriorityTier tier, decimal balance = 500_000m,
        int attempts = 0, bool reached = false, PromiseState promise = null)
        => new GuardianWorklistRow
        {
            Tier = tier, TotalBalance = balance, AttemptsToday = attempts,
            ContactedToday = reached, Promise = promise ?? PromiseState.None,
        };

    private static PromiseState Promise(DateTime due, decimal amount, decimal balance, decimal paid = 0m)
        => PromiseEvaluator.Evaluate(
            new[] { new PromisePlan { ContactId = 1, LoggedAt = Today.AddDays(-5),
                Instalments = { new PromiseInstalment { DueDate = due, Amount = amount } } } },
            paid > 0 ? new[] { new PaymentFact { StudentNumber = "A", Date = Today.AddDays(-1), Amount = paid } } : null,
            new Dictionary<string, decimal> { ["A"] = balance }, Today);

    [Fact]
    public void Status_today_reflects_reached_tried_and_untouched()
    {
        Assert.Equal(TodayStatus.NotCalled, Row(PriorityTier.Stale).TodayStatus);
        Assert.Equal(TodayStatus.Tried,     Row(PriorityTier.Stale, attempts: 2).TodayStatus);
        Assert.Equal(TodayStatus.Done,      Row(PriorityTier.Stale, attempts: 3, reached: true).TodayStatus);
        Assert.Equal("Tried x2", Row(PriorityTier.Stale, attempts: 2).TodayStatusText);
        Assert.Equal("Tried",    Row(PriorityTier.Stale, attempts: 1).TodayStatusText);
        Assert.Equal("Tried x3", DailyListLogic.StatusText(TodayStatus.Tried, 3));
    }

    [Fact]
    public void Families_on_track_are_not_chased()
        => Assert.False(DailyListLogic.NeedsChasingToday(Row(PriorityTier.Current), Today, false, 0.5));

    [Fact]
    public void Families_behind_are_chased()
        => Assert.True(DailyListLogic.NeedsChasingToday(Row(PriorityTier.Critical), Today, false, 0.5));

    [Fact]
    public void Cleared_families_are_never_chased()
        => Assert.False(DailyListLogic.NeedsChasingToday(Row(PriorityTier.Critical, balance: 0m), Today, false, 0.5));

    [Fact]
    public void A_promise_due_today_puts_an_on_track_family_on_the_list()
    {
        var g = Row(PriorityTier.Current, promise: Promise(Today, 400_000m, 500_000m));
        Assert.True(DailyListLogic.NeedsChasingToday(g, Today, false, 0.5));
    }

    [Fact]
    public void A_covering_promise_not_yet_due_hides_the_family()
    {
        var g = Row(PriorityTier.Stale, promise: Promise(Today.AddDays(4), 400_000m, 500_000m));
        Assert.False(DailyListLogic.NeedsChasingToday(g, Today, false, 0.5));
    }

    [Fact]
    public void A_small_promise_does_not_hide_the_family()
    {
        var g = Row(PriorityTier.Stale, promise: Promise(Today.AddDays(4), 100_000m, 500_000m));
        Assert.True(DailyListLogic.NeedsChasingToday(g, Today, false, 0.5));
    }

    [Fact]
    public void Near_the_end_of_term_promises_stop_hiding_families()
    {
        var g = Row(PriorityTier.Stale, promise: Promise(Today.AddDays(4), 400_000m, 500_000m));
        Assert.True(DailyListLogic.NeedsChasingToday(g, Today, nearDeadline: true, 0.5));
    }

    [Fact]
    public void A_family_worked_today_stays_on_the_list_even_if_now_on_track()
    {
        Assert.True(DailyListLogic.IsOnDailyList(Row(PriorityTier.Current, attempts: 1, reached: true), Today, false, 0.5));
        Assert.True(DailyListLogic.IsOnDailyList(Row(PriorityTier.Current, attempts: 1), Today, false, 0.5));
        Assert.False(DailyListLogic.IsOnDailyList(Row(PriorityTier.Current), Today, false, 0.5));
    }

    [Fact]
    public void Progress_counts_every_status()
    {
        var rows = new[]
        {
            Row(PriorityTier.Stale), Row(PriorityTier.Stale), Row(PriorityTier.Stale, attempts: 1),
            Row(PriorityTier.Stale, attempts: 1, reached: true),
        };
        var p = DailyListLogic.Progress(rows);
        Assert.Equal((4, 1, 1, 2, 2, 50), (p.Total, p.Done, p.Tried, p.NotCalled, p.Worked, p.Percent));
        Assert.Contains("2 of 4 worked today", p.Summary);
        Assert.Equal("Nobody needs calling today.", DailyListLogic.Progress(null).Summary);
    }

    [Fact]
    public void Next_to_work_skips_finished_families_and_wraps_round()
    {
        var rows = new List<GuardianWorklistRow>
        {
            Row(PriorityTier.Stale),                              // 0 not called
            Row(PriorityTier.Stale, attempts: 1, reached: true),  // 1 done
            Row(PriorityTier.Stale, attempts: 1),                 // 2 tried
            Row(PriorityTier.Stale, attempts: 1, reached: true),  // 3 done
        };
        Assert.Equal(0, DailyListLogic.NextToWork(rows, -1));
        Assert.Equal(0, DailyListLogic.NextToWork(rows, 1));   // wraps to the untouched one before retries
        rows[0].AttemptsToday = 1; rows[0].ContactedToday = true;
        Assert.Equal(2, DailyListLogic.NextToWork(rows, 0));   // only a retry is left
        rows[2].ContactedToday = true;
        Assert.Equal(-1, DailyListLogic.NextToWork(rows, 2));  // everything done
        Assert.Equal(-1, DailyListLogic.NextToWork(new List<GuardianWorklistRow>(), 0));
    }

    // ── Automatic reminders ───────────────────────────────────────────────────

    [Theory]
    [InlineData("09:00", 9, 0)]
    [InlineData("7:30", 7, 30)]
    [InlineData("", 9, 0)]
    [InlineData("25:00", 9, 0)]
    [InlineData("soon", 9, 0)]
    public void Send_time_is_parsed_with_a_safe_fallback(string raw, int h, int m)
        => Assert.Equal(new TimeSpan(h, m, 0), AutoReminderSchedule.ParseTime(raw));

    [Fact]
    public void Automatic_run_is_due_once_a_day_after_the_set_time()
    {
        var nine = new TimeSpan(9, 0, 0);
        DateTime At(int h, int m) => Today.AddHours(h).AddMinutes(m);
        Assert.False(AutoReminderSchedule.IsDue(true, nine, At(8, 59), false));
        Assert.True(AutoReminderSchedule.IsDue(true, nine, At(9, 0), false));
        Assert.True(AutoReminderSchedule.IsDue(true, nine, At(15, 0), false));    // catch-up when opened late
        Assert.False(AutoReminderSchedule.IsDue(true, nine, At(20, 1), false));   // too late to text parents
        Assert.False(AutoReminderSchedule.IsDue(true, nine, At(10, 0), true));    // already ran
        Assert.False(AutoReminderSchedule.IsDue(false, nine, At(10, 0), false));  // switched off
    }

    // ── Reminder planning ─────────────────────────────────────────────────────

    private static List<StudentSummary> Kids() => new List<StudentSummary>
    {
        new StudentSummary { StudentNumber = "A", FullName = "Ali",  ClassId = "P.3", Balance = 200_000m },
        new StudentSummary { StudentNumber = "B", FullName = "Sara", ClassId = "P.5", Balance = 150_000m },
    };

    private static PromiseState Eval(IEnumerable<PromisePlan> plans, params PaymentFact[] pays)
        => PromiseEvaluator.Evaluate(plans, pays, Kids().ToDictionary(k => k.StudentNumber, k => k.Balance), Today);

    private static PromisePlan Plan(int id, int loggedDaysAgo, string student, params (int dueInDays, decimal? amount)[] parts)
        => new PromisePlan
        {
            ContactId = id, LoggedAt = Today.AddDays(-loggedDaysAgo), StudentNumber = student,
            Instalments = parts.Select(p => new PromiseInstalment { DueDate = Today.AddDays(p.dueInDays), Amount = p.amount }).ToList(),
        };

    [Fact]
    public void Family_promise_due_today_gives_one_reminder_for_the_whole_family()
    {
        var items = ReminderPlanner.Plan("0771", "0771", Kids(), Eval(new[] { Plan(1, 5, "", (0, 300_000m)) }), Today);

        var item = Assert.Single(items);
        Assert.Equal("DayOf", item.ReminderType);
        Assert.Equal("Ali and Sara", item.StudentName);
        Assert.Equal(350_000m, item.Balance);
        Assert.Equal(300_000m, item.PromisedAmount);
        Assert.Null(item.StudentNumber);
        Assert.Equal(2, item.ScopeStudents.Count);
        Assert.Null(Assert.Single(item.Components).StudentNumber);
    }

    [Fact]
    public void A_kept_promise_gets_no_reminder()
    {
        var st = Eval(new[] { Plan(1, 5, "", (-3, 100_000m)) },
            new PaymentFact { StudentNumber = "A", Date = Today.AddDays(-4), Amount = 100_000m });
        Assert.Empty(ReminderPlanner.Plan("0771", "0771", Kids(), st, Today));
    }

    [Fact]
    public void A_replaced_promise_gets_no_reminder()
    {
        // Old date is in the overdue window, but the parent has since moved it out of every window.
        var st = Eval(new[] { Plan(1, 10, "", (-3, 100_000m)), Plan(2, 1, "", (10, 100_000m)) });
        Assert.Empty(ReminderPlanner.Plan("0771", "0771", Kids(), st, Today));
    }

    [Fact]
    public void Two_overdue_instalments_make_one_reminder_without_double_counting_the_balance()
    {
        var st = Eval(new[] { Plan(1, 20, "", (-6, 100_000m), (-3, 50_000m)) });
        var item = Assert.Single(ReminderPlanner.Plan("0771", "0771", Kids(), st, Today));

        Assert.Equal("Overdue", item.ReminderType);
        Assert.Equal(350_000m, item.Balance);
        Assert.Equal(150_000m, item.PromisedAmount);
        Assert.Equal(Today.AddDays(-6), item.PromiseDate);
        Assert.Equal(2, item.Components.Count);
    }

    [Fact]
    public void A_child_promise_reminds_about_that_child_only()
    {
        var st = Eval(new[] { Plan(1, 5, "B", (2, 100_000m)) });
        var item = Assert.Single(ReminderPlanner.Plan("0771", "0771", Kids(), st, Today));

        Assert.Equal("3DayBefore", item.ReminderType);
        Assert.Equal("Sara", item.StudentName);
        Assert.Equal(150_000m, item.Balance);
        Assert.Equal("B", item.StudentNumber);
        Assert.Equal("B", item.Components[0].StudentNumber);
    }

    [Fact]
    public void A_promise_without_amount_quotes_no_amount()
    {
        var st = Eval(new[] { Plan(1, 5, "", (0, null)) });
        Assert.Equal(0m, Assert.Single(ReminderPlanner.Plan("0771", "0771", Kids(), st, Today)).PromisedAmount);
    }

    [Fact]
    public void Instalments_outside_every_window_are_left_alone()
    {
        var st = Eval(new[] { Plan(1, 30, "", (-20, 100_000m), (15, 100_000m)) });
        Assert.Empty(ReminderPlanner.Plan("0771", "0771", Kids(), st, Today));
    }

    // ── Dashboard ─────────────────────────────────────────────────────────────

    [Fact]
    public void Class_breakdown_totals_each_class_worst_first()
    {
        var students = new[]
        {
            new StudentSummary { ClassId = "P.1", TotalBilled = 100m, TotalPaid = 100m, Balance = 0m },
            new StudentSummary { ClassId = "P.1", TotalBilled = 100m, TotalPaid = 60m,  Balance = 40m },
            new StudentSummary { ClassId = "P.2", TotalBilled = 200m, TotalPaid = 0m,   Balance = 200m },
            new StudentSummary { ClassId = " ",   TotalBilled = 50m,  TotalPaid = 60m,  Balance = -10m },
        };
        var rows = FeesDashboardMath.ByClass(students);

        Assert.Equal(new[] { "P.2", "P.1", "(no class)" }, rows.Select(r => r.ClassId).ToArray());
        var p1 = rows.Single(r => r.ClassId == "P.1");
        Assert.Equal((2, 200m, 160m, 40m, 1, 0), (p1.Students, p1.Billed, p1.Paid, p1.Outstanding, p1.Cleared, p1.ZeroPaid));
        Assert.Equal(80.0, p1.PercentPaid, 3);
        Assert.Equal(1, rows[0].ZeroPaid);
        Assert.Equal(0m, rows.Single(r => r.ClassId == "(no class)").Outstanding);   // credit is not outstanding
    }

    [Fact]
    public void Weekly_trend_runs_a_cumulative_total_against_the_required_line()
    {
        var start = new DateTime(2026, 9, 7);
        var end   = start.AddDays(69);    // 10 weeks
        var today = start.AddDays(16);    // in week 3
        var pays = new[]
        {
            new PaymentFact { Date = start.AddDays(-3), Amount = 100m },   // before term → week 1
            new PaymentFact { Date = start.AddDays(2),  Amount = 100m },
            new PaymentFact { Date = start.AddDays(8),  Amount = 300m },
            new PaymentFact { Date = start.AddDays(40), Amount = 999m },   // future-dated: not shown yet
        };
        var rows = FeesDashboardMath.WeeklyTrend(pays, start, end, today, totalPayable: 1000m, collectionGoal: 1.0);

        Assert.Equal(3, rows.Count);
        Assert.Equal(new[] { 200m, 300m, 0m }, rows.Select(r => r.Collected).ToArray());
        Assert.Equal(new[] { 20.0, 50.0, 50.0 }, rows.Select(r => Math.Round(r.CumulativePct, 3)).ToArray());
        Assert.True(rows[0].RequiredPct < rows[1].RequiredPct && rows[1].RequiredPct < rows[2].RequiredPct);
        Assert.Equal(6.0 / 69.0 * 100.0, rows[0].RequiredPct, 3);
        Assert.Empty(FeesDashboardMath.WeeklyTrend(pays, end, start, today, 1000m, 1.0));
    }

    [Fact]
    public void Promise_pipeline_sorts_instalments_into_kept_pending_and_missed()
    {
        var kept    = Row(PriorityTier.Current, promise: Promise(Today.AddDays(-2), 100_000m, 400_000m, paid: 100_000m));
        var missed  = Row(PriorityTier.BrokenPromise, promise: Promise(Today.AddDays(-2), 100_000m, 400_000m));
        var dueNow  = Row(PriorityTier.Stale, promise: Promise(Today, 150_000m, 400_000m));
        var later   = Row(PriorityTier.Stale, promise: Promise(Today.AddDays(20), 200_000m, 400_000m));
        var none    = Row(PriorityTier.Stale);

        var p = FeesDashboardMath.Pipeline(new[] { kept, missed, dueNow, later, none }, Today);

        Assert.Equal(4, p.FamiliesWithPromise);
        Assert.Equal((1, 100_000m), (p.KeptCount, p.KeptAmount));
        Assert.Equal((1, 100_000m), (p.MissedCount, p.MissedAmount));
        Assert.Equal((2, 350_000m), (p.PendingCount, p.PendingAmount));
        Assert.Equal((1, 150_000m), (p.DueTodayCount, p.DueTodayAmount));
        Assert.Equal((1, 150_000m), (p.DueThisWeekCount, p.DueThisWeekAmount));
        Assert.Equal(50.0, p.KeptRatePercent, 3);
    }
}
