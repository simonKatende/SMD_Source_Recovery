using System;
using System.Collections.Generic;
using System.Linq;

namespace I_Xtreme.Models;

/// <summary>How a guardian family wants fee SMS: one message with the family total, or one per child.</summary>
public enum SmsStyle { FamilyTotal, PerChild }

public enum InstalmentStatus { Kept, Pending, Missed }

/// <summary>What has happened on the daily list for a family today.</summary>
public enum TodayStatus { NotCalled, Tried, Done }

/// <summary>One dated part of a payment plan. Amount null = "clear whatever is still owed".</summary>
public class PromiseInstalment
{
    public DateTime DueDate { get; set; }
    public decimal? Amount  { get; set; }

    // Filled in by PromiseEvaluator.
    public InstalmentStatus Status   { get; set; }
    public decimal AmountDue         { get; set; }   // resolved amount (Amount, or the balance when Amount is null)
    public decimal AmountOutstanding { get; set; }   // 0 when kept
}

/// <summary>
/// A promise logged in one interaction: one or more instalments, for the whole family
/// (StudentNumber blank) or for one named child.
/// </summary>
public class PromisePlan
{
    public int      ContactId     { get; set; }
    public DateTime LoggedAt      { get; set; }
    public string   StudentNumber { get; set; }
    public string   LoggedBy      { get; set; }
    public List<PromiseInstalment> Instalments { get; set; } = new List<PromiseInstalment>();

    public bool IsFamily => string.IsNullOrWhiteSpace(StudentNumber);

    // Filled in by PromiseEvaluator.
    public decimal PaidSince    { get; set; }
    public decimal ScopeBalance { get; set; }
}

/// <summary>A payment received (a FeesPayment credit) in the current term.</summary>
public class PaymentFact
{
    public string   StudentNumber { get; set; }
    public DateTime Date          { get; set; }
    public decimal  Amount        { get; set; }
}

/// <summary>Where a guardian family stands against the promises that are still in force.</summary>
public class PromiseState
{
    public List<PromisePlan> ActivePlans { get; set; } = new List<PromisePlan>();

    public bool HasPromise => ActivePlans.Count > 0;

    private IEnumerable<PromiseInstalment> All => ActivePlans.SelectMany(p => p.Instalments);

    /// <summary>At least one instalment's date has passed without being paid.</summary>
    public bool IsBroken => All.Any(i => i.Status == InstalmentStatus.Missed);

    /// <summary>At least one unpaid instalment is still due today or later.</summary>
    public bool HasActive => All.Any(i => i.Status == InstalmentStatus.Pending);

    public PromiseInstalment NextDue =>
        All.Where(i => i.Status == InstalmentStatus.Pending).OrderBy(i => i.DueDate).FirstOrDefault();

    public PromiseInstalment EarliestMissed =>
        All.Where(i => i.Status == InstalmentStatus.Missed).OrderBy(i => i.DueDate).FirstOrDefault();

    /// <summary>Money promised but not yet paid on instalments that are not yet late.</summary>
    public decimal RemainingPromised =>
        All.Where(i => i.Status == InstalmentStatus.Pending).Sum(i => i.AmountOutstanding);

    public decimal MissedAmount =>
        All.Where(i => i.Status == InstalmentStatus.Missed).Sum(i => i.AmountOutstanding);

    public decimal PaidSincePromise => ActivePlans.Sum(p => p.PaidSince);

    public bool IsDueOn(DateTime day) =>
        All.Any(i => i.Status == InstalmentStatus.Pending && i.DueDate.Date == day.Date);

    /// <summary>Short plain-language summary for lists and reports.</summary>
    public string StatusText
    {
        get
        {
            if (!HasPromise) return "";
            var missed = EarliestMissed;
            if (missed != null)
                return $"Missed UGX {missed.AmountOutstanding:N0} due {missed.DueDate:dd-MMM}";
            var next = NextDue;
            if (next != null)
                return $"UGX {next.AmountOutstanding:N0} due {next.DueDate:dd-MMM}";
            return "Promise kept";
        }
    }

    public static PromiseState None => new PromiseState();
}

/// <summary>One row of the promises / payment plans report.</summary>
public class PromiseReportRow
{
    public string   GuardianLabel   { get; set; }
    public string   Phone           { get; set; }
    public string   Students        { get; set; }
    public string   Classes         { get; set; }
    public string   PromiseFor      { get; set; }   // "Whole family" or the child's name
    public DateTime LoggedOn        { get; set; }
    public string   LoggedBy        { get; set; }
    public DateTime DueDate         { get; set; }
    public decimal  AmountPromised  { get; set; }
    public decimal  AmountPaid      { get; set; }
    public decimal  AmountOutstanding { get; set; }
    public string   Status          { get; set; }   // Kept | Pending | Missed | Replaced
    public decimal  FamilyBalance   { get; set; }
}
