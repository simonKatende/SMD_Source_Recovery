using System;
using System.Collections.Generic;
using System.Linq;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>
/// Pure promise / payment-plan maths. Decides which promises are still in force for a guardian
/// family and whether each instalment has been kept, is still pending, or was missed.
/// Depends only on System + I_Xtreme.Models so it is unit-testable.
/// </summary>
public static class PromiseEvaluator
{
    /// <summary>An instalment counts as kept when at least this share of it has been paid.</summary>
    public const decimal KeptTolerance = 0.95m;

    /// <summary>
    /// The promises still in force. The most recent promise replaces older ones that cover the
    /// same children: a whole-family promise replaces everything before it; a promise for one
    /// child replaces that child's earlier promise and any earlier whole-family promise.
    /// </summary>
    public static List<PromisePlan> SelectActivePlans(IEnumerable<PromisePlan> plans)
    {
        var ordered = (plans ?? Enumerable.Empty<PromisePlan>())
            .Where(p => p != null && p.Instalments != null && p.Instalments.Count > 0)
            .OrderByDescending(p => p.LoggedAt)
            .ThenByDescending(p => p.ContactId)
            .ToList();

        var active = new List<PromisePlan>();
        if (ordered.Count == 0) return active;
        if (ordered[0].IsFamily)
        {
            active.Add(ordered[0]);
            return active;
        }

        var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var p in ordered)
        {
            if (p.IsFamily) break;   // older than a child-specific promise: replaced
            if (seen.Add(p.StudentNumber.Trim())) active.Add(p);
        }
        return active;
    }

    /// <summary>
    /// Evaluate a family's promises against payments received since each promise was logged.
    /// </summary>
    /// <param name="plans">Every promise logged for the family this term.</param>
    /// <param name="payments">Payments received this term for the family's children.</param>
    /// <param name="balanceByStudent">Current balance per child (StudentNumber → balance).</param>
    public static PromiseState Evaluate(
        IEnumerable<PromisePlan> plans,
        IEnumerable<PaymentFact> payments,
        IDictionary<string, decimal> balanceByStudent,
        DateTime today)
    {
        var state = new PromiseState { ActivePlans = SelectActivePlans(plans) };
        var pays = (payments ?? Enumerable.Empty<PaymentFact>()).ToList();
        balanceByStudent ??= new Dictionary<string, decimal>();

        foreach (var plan in state.ActivePlans)
        {
            bool InScope(string studentNumber) =>
                plan.IsFamily || string.Equals((studentNumber ?? "").Trim(), plan.StudentNumber.Trim(),
                                               StringComparison.OrdinalIgnoreCase);

            // Payment dates carry no time of day, so compare whole days: a payment made on the
            // day the promise was logged counts towards it.
            plan.PaidSince = pays.Where(p => InScope(p.StudentNumber) && p.Date.Date >= plan.LoggedAt.Date)
                                 .Sum(p => p.Amount);
            plan.ScopeBalance = balanceByStudent.Where(kv => InScope(kv.Key)).Sum(kv => kv.Value);

            decimal owedWhenLogged = Math.Max(0m, plan.ScopeBalance + plan.PaidSince);
            decimal remainingPaid  = plan.PaidSince;
            decimal allocated      = 0m;

            foreach (var inst in plan.Instalments.OrderBy(i => i.DueDate))
            {
                // No amount given = "I will clear what I owe" (less any earlier instalments).
                decimal due = inst.Amount.HasValue && inst.Amount.Value > 0m
                    ? inst.Amount.Value
                    : Math.Max(0m, owedWhenLogged - allocated);
                allocated += due;

                decimal covered = Math.Min(due, Math.Max(0m, remainingPaid));
                remainingPaid -= covered;

                inst.AmountDue = due;
                bool kept = plan.ScopeBalance <= 0m || covered >= due * KeptTolerance;
                if (kept)
                {
                    inst.Status = InstalmentStatus.Kept;
                    inst.AmountOutstanding = 0m;
                }
                else
                {
                    inst.Status = inst.DueDate.Date >= today.Date
                        ? InstalmentStatus.Pending : InstalmentStatus.Missed;
                    // Never claim more is outstanding than the family still owes.
                    inst.AmountOutstanding = Math.Min(due - covered, Math.Max(0m, plan.ScopeBalance));
                }
            }
        }
        return state;
    }

    /// <summary>
    /// True when instalments are usable: at least one, every date present, dates not repeated,
    /// and amounts (when given) positive. Returns a plain-language problem otherwise.
    /// </summary>
    public static bool ValidateInstalments(IList<PromiseInstalment> instalments, DateTime today, out string problem)
    {
        problem = null;
        if (instalments == null || instalments.Count == 0)
        {
            problem = "Enter the date the parent promised to pay.";
            return false;
        }
        if (instalments.Any(i => i.DueDate == default))
        {
            problem = "Every instalment needs a date.";
            return false;
        }
        if (instalments.Any(i => i.DueDate.Date < today.Date))
        {
            problem = "A promise date cannot be in the past.";
            return false;
        }
        if (instalments.GroupBy(i => i.DueDate.Date).Any(g => g.Count() > 1))
        {
            problem = "Two instalments have the same date. Combine them into one.";
            return false;
        }
        if (instalments.Any(i => i.Amount.HasValue && i.Amount.Value < 0m))
        {
            problem = "An instalment amount cannot be negative.";
            return false;
        }
        if (instalments.Count > 1 && instalments.Any(i => !i.Amount.HasValue || i.Amount.Value <= 0m))
        {
            problem = "When there is more than one instalment, each one needs an amount.";
            return false;
        }
        return true;
    }
}
