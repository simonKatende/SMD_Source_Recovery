using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>Pure rules for the academic term that Fees Follow-up works in.</summary>
public static class FeesTerm
{
    /// <summary>
    /// True when the stored term dates belong to the term the application is working in.
    /// Dates are stamped with the term they were entered for; when the school moves to a new
    /// term the old dates stop applying until someone enters the new ones. Dates saved before
    /// stamping existed are accepted only while the term they describe has not yet ended.
    /// </summary>
    public static bool DatesApply(string stampedSemester, string workingSemester,
        DateTime? termEnd, DateTime today)
    {
        if (!string.IsNullOrWhiteSpace(stampedSemester))
            return string.Equals(stampedSemester.Trim(), (workingSemester ?? "").Trim(),
                                 StringComparison.OrdinalIgnoreCase);
        return termEnd.HasValue && termEnd.Value.Date >= today.Date;
    }

    /// <summary>"TermIII-2026" → "Term III 2026"; anything unrecognised is returned unchanged.</summary>
    public static string DisplayName(string semesterId)
    {
        if (string.IsNullOrWhiteSpace(semesterId)) return "(no term set)";
        string s = semesterId.Trim();
        int dash = s.IndexOf('-');
        if (dash <= 0) return s;
        string head = s.Substring(0, dash), year = s.Substring(dash + 1);
        if (head.StartsWith("Term", StringComparison.OrdinalIgnoreCase))
            return $"Term {head.Substring(4)} {year}";
        if (head.StartsWith("SEM", StringComparison.OrdinalIgnoreCase))
            return $"Semester {head.Substring(3)} {year}";
        return s;
    }

    /// <summary>1-based week of term and total weeks; (0,0) when dates are missing or today is outside them.</summary>
    public static (int week, int totalWeeks) WeekOfTerm(DateTime today, DateTime? termStart, DateTime? termEnd)
    {
        if (!termStart.HasValue || !termEnd.HasValue || termEnd.Value <= termStart.Value) return (0, 0);
        int total = Math.Max(1, (int)Math.Ceiling(((termEnd.Value.Date - termStart.Value.Date).TotalDays + 1) / 7.0));
        if (today.Date < termStart.Value.Date) return (0, total);
        int week = (int)((today.Date - termStart.Value.Date).TotalDays / 7) + 1;
        return (Math.Min(week, total), total);
    }
}

/// <summary>Pure rules for the daily follow-up list: who is on it, and what has been done today.</summary>
public static class DailyListLogic
{
    public static TodayStatus StatusFor(bool reachedToday, int attemptsToday)
        => reachedToday ? TodayStatus.Done
         : attemptsToday > 0 ? TodayStatus.Tried
         : TodayStatus.NotCalled;

    public static string StatusText(TodayStatus status, int attemptsToday) => status switch
    {
        TodayStatus.Done  => "Done",
        TodayStatus.Tried => attemptsToday > 1 ? $"Tried x{attemptsToday}" : "Tried",
        _                 => "Not called",
    };

    /// <summary>
    /// Whether a family needs chasing today, before looking at what has already been done today.
    /// On the list: anyone not "Up to Date", plus anyone with a promise falling due today.
    /// Off the list: families with a promise that is not yet due and covers enough of the balance
    /// (unless the term is about to end).
    /// </summary>
    public static bool NeedsChasingToday(GuardianWorklistRow g, DateTime today,
        bool nearDeadline, double coverageThreshold)
    {
        if (g.TotalBalance <= 0m) return false;

        var promise = g.Promise ?? PromiseState.None;
        if (promise.IsDueOn(today)) return true;           // confirm today's payment
        if (g.Tier == PriorityTier.Current) return false;  // on track

        if (!nearDeadline && promise.HasActive && !promise.IsBroken)
        {
            double coverage = (double)(promise.RemainingPromised / g.TotalBalance);
            if (coverage >= coverageThreshold) return false;
        }
        return true;
    }

    /// <summary>
    /// The daily list: everyone who needs chasing today plus everyone already worked today, so
    /// finished families stay visible as "Done" instead of vanishing.
    /// </summary>
    public static bool IsOnDailyList(GuardianWorklistRow g, DateTime today,
        bool nearDeadline, double coverageThreshold)
        => g.AttemptsToday > 0 || g.ContactedToday
           || NeedsChasingToday(g, today, nearDeadline, coverageThreshold);

    public static DailyProgress Progress(IEnumerable<GuardianWorklistRow> rows)
    {
        var p = new DailyProgress();
        foreach (var g in rows ?? Enumerable.Empty<GuardianWorklistRow>())
        {
            p.Total++;
            switch (g.TodayStatus)
            {
                case TodayStatus.Done:  p.Done++;  break;
                case TodayStatus.Tried: p.Tried++; break;
                default:                p.NotCalled++; break;
            }
        }
        return p;
    }

    /// <summary>
    /// Index of the next family to work after <paramref name="afterIndex"/>: the next one not yet
    /// called (wrapping round to the top), else the next one only tried, else -1 when all are done.
    /// </summary>
    public static int NextToWork(IList<GuardianWorklistRow> rows, int afterIndex)
    {
        if (rows == null || rows.Count == 0) return -1;
        foreach (var wanted in new[] { TodayStatus.NotCalled, TodayStatus.Tried })
        {
            for (int step = 1; step <= rows.Count; step++)
            {
                int i = ((afterIndex + step) % rows.Count + rows.Count) % rows.Count;
                if (i == afterIndex) continue;
                if (rows[i].TodayStatus == wanted) return i;
            }
        }
        return -1;
    }
}

public class DailyProgress
{
    public int Total     { get; set; }
    public int Done      { get; set; }
    public int Tried     { get; set; }
    public int NotCalled { get; set; }
    public int Worked    => Done + Tried;
    public int Percent   => Total == 0 ? 0 : (int)Math.Round(Worked * 100.0 / Total);

    public string Summary => Total == 0
        ? "Nobody needs calling today."
        : $"{Worked} of {Total} worked today   ·   {Done} done   ·   {Tried} to try again   ·   {NotCalled} not yet called";
}

/// <summary>Pure rules for sending promise reminders automatically once a day.</summary>
public static class AutoReminderSchedule
{
    /// <summary>Parse "HH:mm"; falls back to 09:00.</summary>
    public static TimeSpan ParseTime(string raw)
        => TimeSpan.TryParseExact((raw ?? "").Trim(), new[] { @"hh\:mm", @"h\:mm" },
               CultureInfo.InvariantCulture, out TimeSpan t) && t < TimeSpan.FromDays(1)
            ? t : new TimeSpan(9, 0, 0);

    /// <summary>
    /// Due when switched on, not yet run today, the set time has passed, and it is not too late
    /// in the evening to text parents (after 20:00 the run waits for tomorrow).
    /// </summary>
    public static bool IsDue(bool enabled, TimeSpan sendAt, DateTime now, bool alreadyRanToday)
    {
        if (!enabled || alreadyRanToday) return false;
        var latest = new TimeSpan(20, 0, 0);
        return now.TimeOfDay >= sendAt && now.TimeOfDay <= latest;
    }
}

/// <summary>Pure planning of promise reminders from evaluated promises.</summary>
public static class ReminderPlanner
{
    /// <summary>
    /// The promise reminders due today for one guardian: at most one per reminder type, covering
    /// every unpaid instalment in that type's window. Kept instalments and replaced promises
    /// never produce a reminder.
    /// </summary>
    public static List<ReminderItem> Plan(string guardianKey, string phone,
        IList<StudentSummary> students, PromiseState promise, DateTime today)
    {
        var result = new List<ReminderItem>();
        if (promise == null || !promise.HasPromise || students == null) return result;

        var due = new List<(string type, PromisePlan plan, PromiseInstalment inst)>();
        foreach (var plan in promise.ActivePlans)
            foreach (var inst in plan.Instalments)
            {
                if (inst.Status == InstalmentStatus.Kept) continue;
                string type = SmsReminderLogic.ClassifyPromiseReminder(today, inst.DueDate);
                if (type != null) due.Add((type, plan, inst));
            }

        foreach (var grp in due.GroupBy(d => d.type))
        {
            var parts = grp.ToList();
            bool anyFamily = parts.Any(p => p.plan.IsFamily);
            var scope = anyFamily
                ? students.ToList()
                : students.Where(s => parts.Any(p => string.Equals(p.plan.StudentNumber.Trim(),
                      (s.StudentNumber ?? "").Trim(), StringComparison.OrdinalIgnoreCase))).ToList();
            if (scope.Count == 0) continue;

            // Quote an amount only when every instalment in the group named one.
            bool allHaveAmount = parts.All(p => p.inst.Amount.HasValue && p.inst.Amount.Value > 0m);
            var singleStudentPlans = parts.Select(p => p.plan.StudentNumber?.Trim() ?? "").Distinct().ToList();

            result.Add(new ReminderItem
            {
                GuardianKey    = guardianKey,
                Phone          = phone,
                ReminderType   = grp.Key,
                StudentNumber  = singleStudentPlans.Count == 1 && singleStudentPlans[0] != "" ? singleStudentPlans[0] : null,
                StudentName    = FamilySms.JoinNames(scope.Select(s => s.FullName)),
                ClassId        = string.Join(", ", scope.Select(s => s.ClassId)
                                     .Where(c => !string.IsNullOrWhiteSpace(c)).Distinct()),
                Balance        = scope.Sum(s => s.Balance),
                PromisedAmount = allHaveAmount ? parts.Sum(p => p.inst.AmountOutstanding) : 0m,
                PromiseDate    = parts.Min(p => p.inst.DueDate),
                ScopeStudents  = scope,
                Components     = parts.Select(p => new ReminderComponent
                {
                    StudentNumber = p.plan.IsFamily ? null : p.plan.StudentNumber.Trim(),
                    PromiseDate   = p.inst.DueDate,
                }).ToList(),
            });
        }
        return result;
    }
}

/// <summary>Pure dashboard aggregations.</summary>
public static class FeesDashboardMath
{
    public static List<ClassCollectionRow> ByClass(IEnumerable<StudentSummary> students)
        => (students ?? Enumerable.Empty<StudentSummary>())
            .GroupBy(s => string.IsNullOrWhiteSpace(s.ClassId) ? "(no class)" : s.ClassId.Trim())
            .Select(g => new ClassCollectionRow
            {
                ClassId     = g.Key,
                Students    = g.Count(),
                Billed      = g.Sum(s => s.TotalBilled),
                Paid        = g.Sum(s => s.TotalPaid),
                Outstanding = g.Sum(s => Math.Max(0m, s.Balance)),
                Cleared     = g.Count(s => s.Balance <= 0m),
                ZeroPaid    = g.Count(s => s.TotalPaid == 0m && s.TotalBilled > 0m),
            })
            .OrderBy(r => r.PercentPaid).ThenBy(r => r.ClassId, StringComparer.OrdinalIgnoreCase)
            .ToList();

    /// <summary>
    /// Collections per week of term (weeks counted from the term start date), with the running
    /// percentage collected and the percentage required by the end of that week.
    /// </summary>
    public static List<WeeklyCollectionRow> WeeklyTrend(IEnumerable<PaymentFact> payments,
        DateTime termStart, DateTime termEnd, DateTime today, decimal totalPayable, double collectionGoal)
    {
        var rows = new List<WeeklyCollectionRow>();
        if (termEnd <= termStart) return rows;
        var pays = (payments ?? Enumerable.Empty<PaymentFact>()).ToList();
        int totalWeeks = FeesTerm.WeekOfTerm(termEnd, termStart, termEnd).totalWeeks;
        DateTime lastDay = today.Date < termEnd.Date ? today.Date : termEnd.Date;
        // Money paid before the term opened is counted in week 1 so the running total is complete.
        decimal beforeTerm = pays.Where(p => p.Date.Date < termStart.Date).Sum(p => p.Amount);
        decimal running = 0m;

        for (int w = 1; w <= totalWeeks; w++)
        {
            DateTime from = termStart.Date.AddDays((w - 1) * 7);
            if (from > lastDay) break;
            DateTime to = from.AddDays(6);
            decimal collected = pays.Where(p => p.Date.Date >= from && p.Date.Date <= to).Sum(p => p.Amount);
            if (w == 1) collected += beforeTerm;
            running += collected;
            DateTime measuredAt = to < lastDay ? to : lastDay;
            double progress = FeesUrgency.TermProgress(measuredAt, termStart, termEnd);
            rows.Add(new WeeklyCollectionRow
            {
                Week            = w,
                WeekStarting    = from,
                Collected       = collected,
                CumulativePct   = totalPayable > 0m ? (double)(running / totalPayable) * 100.0 : 0.0,
                RequiredPct     = FeesUrgency.RequiredPct(collectionGoal, progress),
            });
        }
        return rows;
    }

    public static PromisePipeline Pipeline(IEnumerable<GuardianWorklistRow> rows, DateTime today)
    {
        var p = new PromisePipeline();
        DateTime weekEnd = today.Date.AddDays(7);
        foreach (var g in rows ?? Enumerable.Empty<GuardianWorklistRow>())
        {
            var st = g.Promise;
            if (st == null || !st.HasPromise) continue;
            p.FamiliesWithPromise++;
            foreach (var inst in st.ActivePlans.SelectMany(a => a.Instalments))
            {
                switch (inst.Status)
                {
                    case InstalmentStatus.Kept:
                        p.KeptCount++; p.KeptAmount += inst.AmountDue; break;
                    case InstalmentStatus.Missed:
                        p.MissedCount++; p.MissedAmount += inst.AmountOutstanding; break;
                    default:
                        p.PendingCount++; p.PendingAmount += inst.AmountOutstanding;
                        if (inst.DueDate.Date == today.Date) { p.DueTodayCount++; p.DueTodayAmount += inst.AmountOutstanding; }
                        if (inst.DueDate.Date <= weekEnd)    { p.DueThisWeekCount++; p.DueThisWeekAmount += inst.AmountOutstanding; }
                        break;
                }
            }
        }
        return p;
    }
}
