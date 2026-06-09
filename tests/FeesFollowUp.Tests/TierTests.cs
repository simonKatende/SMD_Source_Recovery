using System;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class TierTests
{
    private static readonly DateTime Today = new DateTime(2026, 4, 1);

    private static GuardianWorklistRow Row(
        decimal paymentPercent, decimal balance = 1_000_000m,
        DateTime? lastContact = null, ContactOutcome? lastOutcome = null,
        DateTime? promiseDate = null, decimal? promiseAmount = null,
        decimal paymentsSincePromise = 0m, DateTime? firstContact = null)
        => new GuardianWorklistRow
        {
            PaymentPercent = paymentPercent,
            TotalBalance = balance,
            LastContactDate = lastContact,
            LastOutcome = lastOutcome,
            LatestPromiseDate = promiseDate,
            LatestPromiseAmount = promiseAmount,
            PaymentsSinceLatestPromise = paymentsSincePromise,
            FirstContactDate = firstContact,
        };

    [Fact]
    public void Critical_when_shortfall_at_or_above_threshold_and_no_active_promise()
    {
        var g = Row(paymentPercent: 40m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 30.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Critical, tier);
    }

    [Fact]
    public void Not_critical_when_active_promise_even_if_behind()
    {
        var g = Row(paymentPercent: 40m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Promised);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 30.0, criticalShortfallPoints: 25.0, hasActivePromise: true,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.NotEqual(PriorityTier.Critical, tier);
    }

    [Fact]
    public void Midterm_midpayer_is_not_critical_below_threshold()
    {
        // F2: 60% paid, required ~49% -> shortfall negative -> not flooded into Critical
        var g = Row(paymentPercent: 60m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: -11.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Current, tier);
    }

    [Fact]
    public void No_critical_when_term_dates_unset()
    {
        var g = Row(paymentPercent: 0m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: false,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.NotEqual(PriorityTier.Critical, tier);
    }

    [Fact]
    public void BrokenPromise_when_promise_passed_and_underpaid()
    {
        var g = Row(paymentPercent: 50m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted,
            promiseDate: Today.AddDays(-3), promiseAmount: 500_000m, paymentsSincePromise: 100_000m);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.BrokenPromise, tier);
    }

    [Fact]
    public void Stale_when_no_contact_logged()
    {
        var g = Row(paymentPercent: 50m);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Stale, tier);
    }

    [Fact]
    public void Stale_when_last_outcome_failed()
    {
        var g = Row(paymentPercent: 50m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.NoAnswer);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Stale, tier);
    }

    [Fact]
    public void NoProgress_escalates_to_critical_after_weeks_with_low_payment()
    {
        var g = Row(paymentPercent: 10m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted,
            firstContact: Today.AddDays(-40));
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Critical, tier);
    }

    [Fact]
    public void Current_when_on_pace_and_recently_contacted()
    {
        var g = Row(paymentPercent: 90m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: -5.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Current, tier);
    }

    [Fact]
    public void Fully_paid_is_Current_even_with_no_contact()
    {
        // Nil-balance enrolled family now appears on the worklists; it must not be flagged Stale.
        var g = Row(paymentPercent: 100m, balance: 0m);  // no contact ever logged
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Current, tier);
    }

    [Fact]
    public void Overpaid_credit_is_Current_even_when_shortfall_would_be_critical()
    {
        // Credit balance (overpaid). The balance guard takes precedence over the Critical rule.
        var g = Row(paymentPercent: 120m, balance: -50_000m, lastContact: Today.AddDays(-1),
            lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 99.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Current, tier);
    }
}
