using System;
using System.Collections.Generic;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>
/// Pure, dependency-free fees-follow-up urgency math. Depends only on System
/// and I_Xtreme.Models POCOs so it can be unit-tested without DevExpress/SQL.
/// </summary>
public static class FeesUrgency
{
    /// <summary>Fraction of the term elapsed today, clamped to [0,1]; 0 if dates unset.</summary>
    public static double TermProgress(DateTime today, DateTime? termStart, DateTime? termEnd)
    {
        if (!termStart.HasValue || !termEnd.HasValue) return 0.0;
        double totalDays = (termEnd.Value - termStart.Value).TotalDays;
        if (totalDays <= 0) return 0.0;
        double elapsed = (today - termStart.Value).TotalDays;
        return Math.Max(0.0, Math.Min(1.0, elapsed / totalDays));
    }

    /// <summary>The required-paid percentage line for today: goal * progress, as 0..goal*100.</summary>
    public static double RequiredPct(double collectionGoal, double termProgress)
        => collectionGoal * termProgress * 100.0;

    /// <summary>Percentage points a guardian is behind the required line (&lt;= 0 means on/ahead of pace).</summary>
    public static double Shortfall(double requiredPct, decimal paymentPercent)
        => requiredPct - (double)paymentPercent;

    /// <summary>Outcomes that, as the most-recent contact result, mark a guardian Stale (needs retry).</summary>
    public static readonly HashSet<ContactOutcome> FailedOutcomes = new HashSet<ContactOutcome>
    {
        ContactOutcome.NoAnswer,
        ContactOutcome.ContactUnavailable,
        ContactOutcome.ContactOff,
        ContactOutcome.Refused,
    };

    /// <summary>
    /// Assigns a guardian's priority tier. Critical is driven by a single deadline-aware
    /// shortfall rule (F2); the no-progress, broken-promise, and stale rules are retained.
    /// Returns Stale/Current rather than Critical when term dates are unset.
    /// </summary>
    public static PriorityTier ComputeTier(
        GuardianWorklistRow g, DateTime today, bool hasTermDates,
        double shortfall, double criticalShortfallPoints, bool hasActivePromise,
        int stalenessDays, int noProgressWeeks, double noProgressThreshold)
    {
        // F2: single shortfall-based Critical rule (replaces pacing-gap + flat-phase rules).
        if (hasTermDates && shortfall >= criticalShortfallPoints && !hasActivePromise)
            return PriorityTier.Critical;

        // No-progress escalation (retained): long-followed-up and still barely paying.
        if (noProgressWeeks > 0 && g.FirstContactDate.HasValue)
        {
            double weeksFollowedUp = (today - g.FirstContactDate.Value.Date).TotalDays / 7.0;
            if (weeksFollowedUp > noProgressWeeks && (double)g.PaymentPercent < noProgressThreshold)
                return PriorityTier.Critical;
        }

        // Broken promise (retained, 5% tolerance for rounding).
        if (g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date < today)
        {
            decimal promised = g.LatestPromiseAmount ?? (g.TotalBalance + g.PaymentsSinceLatestPromise);
            if (g.PaymentsSinceLatestPromise < promised * 0.95m)
                return PriorityTier.BrokenPromise;
        }

        // Stale (retained): no recent contact, or last contact was a failed outcome.
        if (!g.LastContactDate.HasValue
            || (today - g.LastContactDate.Value.Date).TotalDays > stalenessDays
            || (g.LastOutcome.HasValue && FailedOutcomes.Contains(g.LastOutcome.Value)))
            return PriorityTier.Stale;

        return PriorityTier.Current;
    }

    /// <summary>
    /// Master ranking signal: money still owed, amplified by how far behind the required
    /// line the guardian is and by behavioral flags. A covering active promise de-emphasises
    /// (x0.4) without zeroing so the remainder is never lost. Higher = chase sooner.
    /// </summary>
    public static double UrgencyScore(
        decimal totalBalance, double shortfall, bool brokenPromise,
        bool failedLastOutcome, bool callRequired, bool hasCoveringActivePromise)
    {
        double baseAtRisk = (double)totalBalance;
        double shortfallX = 1.0 + Math.Max(0.0, shortfall) / 50.0;
        double behaviorX = 1.0;
        if (brokenPromise)            behaviorX *= 1.5;
        if (failedLastOutcome)        behaviorX *= 1.3;
        if (callRequired)             behaviorX *= 1.4;
        if (hasCoveringActivePromise) behaviorX *= 0.4;
        return baseAtRisk * shortfallX * behaviorX;
    }
}
