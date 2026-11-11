using System;
using System.Collections.Generic;
using System.Linq;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class PromiseEvaluatorTests
{
    private static readonly DateTime Today = new DateTime(2026, 10, 20);

    private static PromisePlan Plan(int id, DateTime loggedAt, string student, params (DateTime due, decimal? amount)[] parts)
        => new PromisePlan
        {
            ContactId = id, LoggedAt = loggedAt, StudentNumber = student,
            Instalments = parts.Select(p => new PromiseInstalment { DueDate = p.due, Amount = p.amount }).ToList(),
        };

    private static PaymentFact Pay(string student, DateTime date, decimal amount)
        => new PaymentFact { StudentNumber = student, Date = date, Amount = amount };

    private static Dictionary<string, decimal> Balances(params (string student, decimal balance)[] b)
        => b.ToDictionary(x => x.student, x => x.balance);

    [Fact]
    public void No_promises_gives_an_empty_state()
    {
        var st = PromiseEvaluator.Evaluate(null, null, Balances(("A", 500_000m)), Today);
        Assert.False(st.HasPromise);
        Assert.False(st.IsBroken);
        Assert.False(st.HasActive);
        Assert.Equal("", st.StatusText);
    }

    [Fact]
    public void Family_promise_counts_payments_for_any_child()
    {
        var plan = Plan(1, Today.AddDays(-5), "", (Today.AddDays(-1), 300_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-3), 100_000m), Pay("B", Today.AddDays(-2), 200_000m) },
            Balances(("A", 200_000m), ("B", 100_000m)), Today);

        Assert.False(st.IsBroken);
        Assert.Equal(InstalmentStatus.Kept, st.ActivePlans[0].Instalments[0].Status);
        Assert.Equal("Promise kept", st.StatusText);
    }

    [Fact]
    public void Child_promise_ignores_payments_for_a_sibling()
    {
        var plan = Plan(1, Today.AddDays(-5), "A", (Today.AddDays(-1), 300_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("B", Today.AddDays(-2), 300_000m) },
            Balances(("A", 400_000m), ("B", 0m)), Today);

        Assert.True(st.IsBroken);
        Assert.Equal(300_000m, st.MissedAmount);
    }

    [Fact]
    public void Payment_on_the_day_the_promise_was_logged_counts()
    {
        // Payment dates carry no time, the promise was logged mid-morning.
        var plan = Plan(1, Today.AddDays(-2).AddHours(10), "", (Today.AddDays(-1), 100_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-2), 100_000m) }, Balances(("A", 50_000m)), Today);
        Assert.False(st.IsBroken);
    }

    [Fact]
    public void Payments_before_the_promise_do_not_count()
    {
        var plan = Plan(1, Today.AddDays(-2), "", (Today.AddDays(-1), 100_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-10), 900_000m) }, Balances(("A", 100_000m)), Today);
        Assert.True(st.IsBroken);
    }

    [Fact]
    public void Promise_due_today_is_pending_not_broken()
    {
        var plan = Plan(1, Today.AddDays(-4), "", (Today, 200_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan }, null, Balances(("A", 600_000m)), Today);
        Assert.False(st.IsBroken);
        Assert.True(st.HasActive);
        Assert.True(st.IsDueOn(Today));
        Assert.Equal(200_000m, st.RemainingPromised);
    }

    [Fact]
    public void Within_five_percent_counts_as_kept()
    {
        var plan = Plan(1, Today.AddDays(-4), "", (Today.AddDays(-1), 200_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-2), 191_000m) }, Balances(("A", 400_000m)), Today);
        Assert.False(st.IsBroken);
    }

    [Fact]
    public void Promise_without_amount_means_clearing_the_balance()
    {
        var plan = Plan(1, Today.AddDays(-4), "", (Today.AddDays(-1), null));
        // Owed 500k when logged (300k still owed + 200k paid since): paying 200k is not enough.
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-2), 200_000m) }, Balances(("A", 300_000m)), Today);
        Assert.True(st.IsBroken);
        Assert.Equal(300_000m, st.MissedAmount);
    }

    [Fact]
    public void Cleared_balance_keeps_every_instalment()
    {
        var plan = Plan(1, Today.AddDays(-4), "", (Today.AddDays(-1), 900_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-2), 100_000m) }, Balances(("A", 0m)), Today);
        Assert.False(st.IsBroken);
        Assert.Equal("Promise kept", st.StatusText);
    }

    [Fact]
    public void Instalments_are_paid_off_in_date_order()
    {
        var plan = Plan(1, Today.AddDays(-20), "",
            (Today.AddDays(-10), 200_000m), (Today.AddDays(-2), 200_000m), (Today.AddDays(8), 200_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan },
            new[] { Pay("A", Today.AddDays(-12), 250_000m) }, Balances(("A", 350_000m)), Today);

        var inst = st.ActivePlans[0].Instalments.OrderBy(i => i.DueDate).ToList();
        Assert.Equal(InstalmentStatus.Kept,    inst[0].Status);
        Assert.Equal(InstalmentStatus.Missed,  inst[1].Status);
        Assert.Equal(150_000m,                 inst[1].AmountOutstanding);
        Assert.Equal(InstalmentStatus.Pending, inst[2].Status);
        Assert.True(st.IsBroken);
        Assert.True(st.HasActive);
        Assert.Equal(Today.AddDays(8), st.NextDue.DueDate);
        Assert.Contains("Missed UGX 150,000", st.StatusText);
    }

    [Fact]
    public void Outstanding_never_exceeds_what_is_still_owed()
    {
        var plan = Plan(1, Today.AddDays(-4), "", (Today.AddDays(2), 500_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan }, null, Balances(("A", 120_000m)), Today);
        Assert.Equal(120_000m, st.RemainingPromised);
    }

    [Fact]
    public void Newer_family_promise_replaces_an_older_one()
    {
        var old = Plan(1, Today.AddDays(-10), "", (Today.AddDays(-3), 300_000m));
        var newer = Plan(2, Today.AddDays(-2), "", (Today.AddDays(5), 300_000m));
        var st = PromiseEvaluator.Evaluate(new[] { old, newer }, null, Balances(("A", 300_000m)), Today);

        Assert.Single(st.ActivePlans);
        Assert.Equal(2, st.ActivePlans[0].ContactId);
        Assert.False(st.IsBroken);   // the missed old date was replaced
    }

    [Fact]
    public void Family_promise_replaces_earlier_child_promises()
    {
        var childA = Plan(1, Today.AddDays(-10), "A", (Today.AddDays(-3), 100_000m));
        var family = Plan(2, Today.AddDays(-2), "", (Today.AddDays(5), 300_000m));
        var active = PromiseEvaluator.SelectActivePlans(new[] { childA, family });
        Assert.Single(active);
        Assert.True(active[0].IsFamily);
    }

    [Fact]
    public void Child_promises_for_different_children_stand_together()
    {
        var family = Plan(1, Today.AddDays(-20), "", (Today.AddDays(-15), 100_000m));
        var childA = Plan(2, Today.AddDays(-10), "A", (Today.AddDays(3), 100_000m));
        var childAold = Plan(3, Today.AddDays(-12), "A", (Today.AddDays(-5), 100_000m));
        var childB = Plan(4, Today.AddDays(-4), "B", (Today.AddDays(6), 100_000m));
        var active = PromiseEvaluator.SelectActivePlans(new[] { family, childA, childAold, childB });

        Assert.Equal(new[] { 4, 2 }, active.Select(p => p.ContactId).ToArray());
    }

    [Fact]
    public void Same_moment_ties_break_on_the_later_entry()
    {
        var first = Plan(7, Today, "", (Today.AddDays(3), 100_000m));
        var second = Plan(8, Today, "", (Today.AddDays(9), 100_000m));
        Assert.Equal(8, PromiseEvaluator.SelectActivePlans(new[] { first, second })[0].ContactId);
    }

    [Theory]
    [InlineData(0, "Enter the date")]
    [InlineData(1, "cannot be in the past")]
    [InlineData(2, "same date")]
    [InlineData(3, "each one needs an amount")]
    public void Validation_explains_the_problem(int scenario, string expected)
    {
        var list = scenario switch
        {
            0 => new List<PromiseInstalment>(),
            1 => new List<PromiseInstalment> { new PromiseInstalment { DueDate = Today.AddDays(-1), Amount = 1m } },
            2 => new List<PromiseInstalment>
                 {
                     new PromiseInstalment { DueDate = Today.AddDays(2), Amount = 1m },
                     new PromiseInstalment { DueDate = Today.AddDays(2), Amount = 2m },
                 },
            _ => new List<PromiseInstalment>
                 {
                     new PromiseInstalment { DueDate = Today.AddDays(2), Amount = 1m },
                     new PromiseInstalment { DueDate = Today.AddDays(9), Amount = null },
                 },
        };
        Assert.False(PromiseEvaluator.ValidateInstalments(list, Today, out string problem));
        Assert.Contains(expected, problem);
    }

    [Fact]
    public void Single_promise_without_amount_is_valid()
    {
        var list = new List<PromiseInstalment> { new PromiseInstalment { DueDate = Today, Amount = null } };
        Assert.True(PromiseEvaluator.ValidateInstalments(list, Today, out _));
    }

    [Fact]
    public void Tier_follows_the_evaluated_promise_when_present()
    {
        var plan = Plan(1, Today.AddDays(-10), "", (Today.AddDays(-3), 300_000m));
        var st = PromiseEvaluator.Evaluate(new[] { plan }, null, Balances(("A", 300_000m)), Today);
        var g = new GuardianWorklistRow
        {
            TotalBalance = 300_000m, PaymentPercent = 80m, Promise = st,
            LastContactDate = Today.AddDays(-1), LastOutcome = ContactOutcome.Contacted,
        };
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true, shortfall: 0, criticalShortfallPoints: 25,
            hasActivePromise: false, stalenessDays: 7, noProgressWeeks: 0, noProgressThreshold: 30);
        Assert.Equal(PriorityTier.BrokenPromise, tier);

        g.Promise = PromiseState.None;
        g.LatestPromiseDate = Today.AddDays(-3);   // legacy fields are ignored once Promise is set
        g.LatestPromiseAmount = 300_000m;
        tier = FeesUrgency.ComputeTier(g, Today, true, 0, 25, false, 7, 0, 30);
        Assert.Equal(PriorityTier.Current, tier);
    }
}
