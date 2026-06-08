using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Xtreme.Models;

public class FeesFollowUpSettings
{
    public int    StaleThresholdDays         { get; set; } = 7;
    public DateTime? TermStartDate           { get; set; }
    public DateTime? TermEndDate             { get; set; }
    public double CriticalPacingGapThreshold { get; set; } = 0.50;
    public string SmsTemplate2Day  { get; set; } = "";
    public string SmsTemplateDayOf { get; set; } = "";
    public string SmsTemplateOverdue { get; set; } = "";

    // Improvement 1: partial-promise exclusion threshold
    // Only exclude a guardian with an active promise if that promise covers >= this fraction of TotalBalance.
    // Default 0.50 = 50%. A promise covering less keeps the guardian on the daily list.
    public double  PartialPromiseCoverageThreshold { get; set; } = 0.50;

    // Improvement 2: balance-weighted staleness
    // Guardians whose TotalBalance >= StaleHighBalanceAmount go stale in StaleHighBalanceDays days;
    // those >= StaleMedBalanceAmount (but below High) go stale in StaleMedBalanceDays days;
    // everyone else uses the original StaleThresholdDays.
    public decimal StaleHighBalanceAmount          { get; set; } = 1_000_000m;
    public int     StaleHighBalanceDays            { get; set; } = 3;
    public decimal StaleMedBalanceAmount           { get; set; } = 500_000m;
    public int     StaleMedBalanceDays             { get; set; } = 5;

    // Improvement 3: no-progress escalation
    // If a guardian has been followed up for > NoProgressEscalationWeeks and has paid
    // less than NoProgressPaymentThreshold % of what they were billed, force-promote to Critical.
    public int    NoProgressEscalationWeeks    { get; set; } = 4;
    public double NoProgressPaymentThreshold   { get; set; } = 30.0;

    // Deadline-aware overhaul (2026-06-08).
    public double CollectionGoal          { get; set; } = 0.98;  // fraction 0..1, term-end target
    public double CriticalShortfallPoints { get; set; } = 25.0;  // pts behind required line => Critical
    public int    CallRequiredWindowDays  { get; set; } = 14;    // Overdue SMS recency window
    public int    PromiseResurfaceDays    { get; set; } = 14;    // days before term end to stop hiding promises

    // Send Reminder improvements (2026-06-08).
    public int    GeneralReminderCooldownDays { get; set; } = 7;     // min days between balance reminders to a guardian
    public string SmsTemplateGeneral          { get; set; } = "";    // balance-reminder template (falls back to DefaultGeneral)
}

public class SmsReminderResult
{
    public bool AlreadyRanToday { get; set; }
    public int  TwoDayCount     { get; set; }
    public int  DayOfCount      { get; set; }
    public int  OverdueCount    { get; set; }
    public int  GeneralCount    { get; set; }
    public List<string> Failures { get; set; } = new List<string>();
    public bool HasFailures => Failures.Count > 0;
    public int  TotalSent   => TwoDayCount + DayOfCount + OverdueCount + GeneralCount;
}

public class StudentSummary
{
    public string  StudentNumber  { get; set; }
    public string  StudentId      { get; set; }   // tbl_Stud.StudentID
    public string  FullName       { get; set; }
    public string  ClassId        { get; set; }
    public string  DayBoarder     { get; set; }   // "D" or "B" (direct from tbl_Stud.StudyStatus)
    public decimal TotalBilled    { get; set; }
    public decimal TotalPaid      { get; set; }
    public decimal Balance        { get; set; }
    public decimal PaymentPercent { get; set; }

    public override string ToString() => $"{FullName} ({ClassId})";
}

public class GuardianWorklistRow
{
    public string GuardianContact  { get; set; }   // PriorityContact (guardian key)
    public string Contact2         { get; set; }   // OtherContact
    public string GuardianName     { get; set; }   // tbl_Stud.Guardian
    public string GuardianRelation { get; set; }   // tbl_Stud.GuardianRelation

    // "Name (Relation)" when name is known; phone + relation as fallback
    public string GuardianLabel =>
        !string.IsNullOrWhiteSpace(GuardianName)
            ? $"{GuardianName} ({GuardianRelation})"
            : !string.IsNullOrWhiteSpace(GuardianRelation)
                ? $"{GuardianContact} ({GuardianRelation})"
                : GuardianContact;

    public List<StudentSummary> Students          { get; set; } = new();
    public int   StudentCount   => Students.Count;
    public string StudentNames  => string.Join(", ", Students.Select(s => s.FullName));

    public decimal TotalBalance  { get; set; }
    public decimal TotalBilled   { get; set; }
    public decimal TotalPaid     { get; set; }
    public decimal PaymentPercent { get; set; }
    public double  PacingGap     { get; set; }
    public PriorityTier Tier     { get; set; }
    public double UrgencyScore   { get; set; }   // master ranking signal (FeesUrgency.UrgencyScore)

    // F9: true when the guardian has no callable phone (NOCONTACT key or blank contact).
    public bool IsUnreachable =>
        string.IsNullOrWhiteSpace(GuardianContact)
        || GuardianContact.StartsWith("NOCONTACT-", System.StringComparison.Ordinal);

    public DateTime?       LastContactDate             { get; set; }
    public ContactOutcome? LastOutcome                 { get; set; }
    public DateTime?       LatestPromiseDate           { get; set; }
    public decimal?        LatestPromiseAmount         { get; set; }
    public decimal         PaymentsSinceLatestPromise  { get; set; }
    public DateTime?       FirstContactDate            { get; set; }

    // Folded into the main query (Task 1) to avoid per-guardian round-trips.
    public bool ContactedToday { get; set; }   // any 'Contacted'/'Promised'/'Refused' log today
    public bool CallRequired   { get; set; }   // any Overdue SMS sent (tbl_SmsReminderLog)

    public string PaymentStatus =>
        TotalBilled == 0 ? "N/A" :
        TotalPaid >= TotalBilled ? "Fully Paid" :
        TotalPaid == 0 ? "Unpaid" : "Partial";
}

public class StudentWorklistRow
{
    public string StudentNumber    { get; set; }
    public string StudentId        { get; set; }
    public string FullName         { get; set; }
    public string ClassId          { get; set; }
    public string DayBoarder       { get; set; }   // "D" or "B"
    public decimal TotalBilled     { get; set; }
    public decimal TotalPaid       { get; set; }
    public decimal Balance         { get; set; }
    public decimal PaymentPercent  { get; set; }
    public PriorityTier Tier       { get; set; }
    public double UrgencyScore     { get; set; }   // inherited from guardian for ranking
    public string GuardianKey      { get; set; }   // PriorityContact — used to look up guardian
    public string GuardianContact  { get; set; }
    public string GuardianName     { get; set; }
    public string GuardianRelation { get; set; }
    public string GuardianLabel =>
        !string.IsNullOrWhiteSpace(GuardianName)
            ? $"{GuardianName} ({GuardianRelation})"
            : !string.IsNullOrWhiteSpace(GuardianRelation)
                ? $"{GuardianContact} ({GuardianRelation})"
                : GuardianContact;
    public DateTime?       LastContactDate { get; set; }
    public ContactOutcome? LastOutcome     { get; set; }
    public string PaymentStatus =>
        TotalBilled == 0 ? "N/A" :
        TotalPaid >= TotalBilled ? "Fully Paid" :
        TotalPaid == 0 ? "Unpaid" : "Partial";
}

public class PriorityGroupStats
{
    public PriorityTier Tier          { get; set; }
    public int          GuardianCount { get; set; }
    public decimal      TotalBalance  { get; set; }
}

public class DashboardData
{
    public decimal TotalOutstanding           { get; set; }
    public decimal TotalPayable               { get; set; }
    public decimal TotalCollected             { get; set; }
    public decimal CollectedThisWeek         { get; set; }
    public decimal CollectionRate             => TotalPayable == 0 ? 0 : TotalCollected / TotalPayable * 100m;
    public bool    TermDatesConfigured        { get; set; }
    public double  TermProgress               { get; set; }   // 0..1, clamped
    public decimal CollectionGoalPercent      { get; set; }   // e.g. 98
    public double  RequiredRateToday          => CollectionGoalPercent == 0 || TermProgress == 0
                                                    ? 0.0
                                                    : (double)CollectionGoalPercent * TermProgress;
    public double  ProjectedCollectionRate    => TermProgress <= 0
                                                    ? 0.0
                                                    : System.Math.Min(100.0, (double)CollectionRate / TermProgress);
    public decimal AmountBehindPace           => TermProgress <= 0
                                                    ? 0m
                                                    : System.Math.Max(0m,
                                                        (decimal)(RequiredRateToday / 100.0) * TotalPayable - TotalCollected);
    public int     TotalGuardiansWithBalance  { get; set; }
    public int     DailyListTotal             { get; set; }
    public int     DailyListContacted         { get; set; }
    public int     DailyListRemaining         => DailyListTotal - DailyListContacted;
    public int     BrokenPromiseCount         { get; set; }
    public int     ActivePromiseCount         { get; set; }
    public int     TotalEnrolled              { get; set; }
    public int     NilBalanceStudents         { get; set; }
    public int     ZeroPaidStudents           { get; set; }
    public int     BelowPacingCount           { get; set; }
    public int     CurrentTermWeek            { get; set; }
    public int     TotalTermWeeks             { get; set; }
    public string  TermWeekDisplay            =>
        CurrentTermWeek > 0 && TotalTermWeeks > 0
            ? $"WK {CurrentTermWeek} / {TotalTermWeeks}"
            : "—";
    public List<PriorityGroupStats>  ByPriority   { get; set; } = new List<PriorityGroupStats>();
    public List<GuardianWorklistRow> TopByBalance { get; set; } = new List<GuardianWorklistRow>();
    public DateTime AsOf { get; set; } = DateTime.Now;
}

public class ReminderItem
{
    public string   GuardianKey     { get; set; }
    public string   Phone           { get; set; }   // resolved phone (priority → alt fallback)
    public string   StudentNumber   { get; set; }
    public string   StudentName     { get; set; }
    public string   ClassId         { get; set; }
    public DateTime PromiseDate     { get; set; }
    public decimal  PromisedAmount  { get; set; }
    public decimal  Balance         { get; set; }
    public string   ReminderType    { get; set; }   // "3DayBefore" | "DayOf" | "Overdue"
    public string   Message         { get; set; }   // pre-rendered SMS text

    // Per-student rows underlying a consolidated promise reminder (empty for General).
    public List<ReminderComponent> Components { get; set; } = new List<ReminderComponent>();
}

public class ReminderComponent
{
    public string   StudentNumber { get; set; }
    public DateTime PromiseDate   { get; set; }
}
