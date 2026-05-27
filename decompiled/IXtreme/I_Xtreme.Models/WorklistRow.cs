using System;

namespace I_Xtreme.Models;

public enum PriorityTier { BrokenPromise = 1, Stale = 2, Current = 3 }

public class WorklistRow
{
    public string StudentNumber { get; set; }
    public string FullName { get; set; }
    public string ClassId { get; set; }
    public decimal Balance { get; set; }
    public string PriorityContact { get; set; }     // contact1 fallback contact2
    public DateTime? LastContactDate { get; set; }
    public ContactOutcome? LastOutcome { get; set; }
    public DateTime? LatestPromiseDate { get; set; }
    public decimal? LatestPromiseAmount { get; set; }
    public decimal PaymentsSinceLatestPromise { get; set; }
    public PriorityTier Tier { get; set; }           // computed in service after query
}
