using System;
using System.Collections.Generic;

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
    public string  FullName       { get; set; }
    public string  ClassId        { get; set; }
    public decimal TotalBilled    { get; set; }
    public decimal TotalPaid      { get; set; }
    public decimal Balance        { get; set; }
    public decimal PaymentPercent { get; set; }  // TotalPaid/TotalBilled*100, rounded to 1dp
}

public class GuardianWorklistRow
{
    // Key used to group students and to store in tbl_FeesContactLog.GuardianKey.
    // Format: phone number (10-13 chars), or "NOCONTACT-{StudentNumber}" when
    // both PriorityContact and OtherContact are blank.
    public string GuardianContact { get; set; }

    // Display label shown in the worklist, e.g. "0771234567 (Mother)"
    public string GuardianLabel { get; set; }

    public List<StudentSummary> Students { get; set; } = new();
    public int StudentCount => Students.Count;

    // Aggregates across all students in this group
    public decimal TotalBalance    { get; set; }
    public decimal TotalBilled     { get; set; }
    public decimal TotalPaid       { get; set; }
    public decimal PaymentPercent  { get; set; }  // TotalPaid/TotalBilled*100

    // Pacing: (TermElapsedDays/TermTotalDays) − (TotalPaid/TotalBilled).
    // Positive = behind payment pace. 0.0 when term dates not configured.
    public double PacingGap { get; set; }

    public PriorityTier    Tier              { get; set; }
    public DateTime?       LastContactDate   { get; set; }
    public ContactOutcome? LastOutcome       { get; set; }
    public DateTime?       LatestPromiseDate { get; set; }
    public decimal?        LatestPromiseAmount { get; set; }
    public decimal         PaymentsSinceLatestPromise { get; set; }
}
