using I_Xtreme.ExtremeClasses;
using Xunit;

namespace FeesFollowUp.Tests;

public class UrgencyScoreTests
{
    [Fact]
    public void Base_score_is_balance_when_no_modifiers()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(1_000_000.0, s, 0);
    }

    [Fact]
    public void Shortfall_increases_score_up_to_about_double_at_50_points()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 50.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(2_000_000.0, s, 0);
    }

    [Fact]
    public void Negative_shortfall_does_not_reduce_below_base()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: -40.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(1_000_000.0, s, 0);
    }

    [Fact]
    public void BrokenPromise_multiplies_by_one_point_five()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: true, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(1_500_000.0, s, 0);
    }

    [Fact]
    public void CoveringActivePromise_de_emphasises_without_zeroing()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: true);
        Assert.Equal(400_000.0, s, 0);
    }

    [Fact]
    public void Worked_example_genuine_risk_outranks_sticky_callrequired()
    {
        // F3/F4: 95%-paid, 100k balance, CallRequired vs 2M balance, 50% paid, behind.
        double sticky = FeesUrgency.UrgencyScore(100_000m, shortfall: -10.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: true,
            hasCoveringActivePromise: false);                 // 100k * 1.0 * 1.4 = 140k
        double genuine = FeesUrgency.UrgencyScore(2_000_000m, shortfall: 30.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);                 // 2M * 1.6 = 3.2M
        Assert.True(genuine > sticky);
    }

    [Fact]
    public void Worked_example_broken_promise_outranks_equal_balance_on_pace()
    {
        // F5
        double broken = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: true, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        double onPace = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.True(broken > onPace);
    }
}
