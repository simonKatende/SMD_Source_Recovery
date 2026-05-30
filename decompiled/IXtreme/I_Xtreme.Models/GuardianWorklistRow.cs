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

    public DateTime?       LastContactDate             { get; set; }
    public ContactOutcome? LastOutcome                 { get; set; }
    public DateTime?       LatestPromiseDate           { get; set; }
    public decimal?        LatestPromiseAmount         { get; set; }
    public decimal         PaymentsSinceLatestPromise  { get; set; }

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
    public string GuardianKey      { get; set; }   // PriorityContact — used to look up guardian
    public string GuardianContact  { get; set; }
    public string GuardianName     { get; set; }
    public string GuardianRelation { get; set; }
    public string GuardianLabel =>
        !string.IsNullOrWhiteSpace(GuardianName)
            ? $"{GuardianName} ({GuardianRelation})"
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
    public decimal TotalBilled                { get; set; }
    public decimal TotalCollected             { get; set; }
    public decimal CollectionRate             => TotalBilled == 0 ? 0 : TotalCollected / TotalBilled * 100m;
    public int     TotalGuardiansWithBalance  { get; set; }
    public int     DailyListTotal             { get; set; }   // guardians on today's list (before any contacts)
    public int     DailyListContacted         { get; set; }   // successfully reached today
    public int     DailyListRemaining         => DailyListTotal - DailyListContacted;
    public int     BrokenPromiseCount         { get; set; }
    public int     ActivePromiseCount         { get; set; }
    public List<PriorityGroupStats> ByPriority  { get; set; } = new();
    public List<GuardianWorklistRow> TopCritical { get; set; } = new();   // top 5 by balance
    public DateTime AsOf                        { get; set; } = DateTime.Now;
}
