using System;
using I_Xtreme.ExtremeClasses;
using Xunit;

namespace FeesFollowUp.Tests;

public class RequiredLineTests
{
    private static readonly DateTime Start = new DateTime(2026, 2, 1);
    private static readonly DateTime End   = new DateTime(2026, 4, 30); // 88 days

    [Fact]
    public void TermProgress_is_zero_when_dates_missing()
    {
        Assert.Equal(0.0, FeesUrgency.TermProgress(new DateTime(2026, 3, 1), null, End));
        Assert.Equal(0.0, FeesUrgency.TermProgress(new DateTime(2026, 3, 1), Start, null));
    }

    [Fact]
    public void TermProgress_clamps_to_unit_interval()
    {
        Assert.Equal(0.0, FeesUrgency.TermProgress(Start.AddDays(-5), Start, End));
        Assert.Equal(1.0, FeesUrgency.TermProgress(End.AddDays(5), Start, End));
    }

    [Fact]
    public void TermProgress_is_about_half_at_midterm()
    {
        double p = FeesUrgency.TermProgress(Start.AddDays(44), Start, End);
        Assert.InRange(p, 0.49, 0.51);
    }

    [Fact]
    public void RequiredPct_scales_goal_by_progress()
    {
        Assert.Equal(0.0,  FeesUrgency.RequiredPct(0.98, 0.0));
        Assert.Equal(98.0, FeesUrgency.RequiredPct(0.98, 1.0), 3);
        Assert.Equal(49.0, FeesUrgency.RequiredPct(0.98, 0.5), 3);
    }

    [Fact]
    public void Shortfall_is_required_minus_paid_in_points()
    {
        Assert.Equal(30.0,  FeesUrgency.Shortfall(80.0, 50m), 3);
        Assert.Equal(-5.0,  FeesUrgency.Shortfall(80.0, 85m), 3); // ahead of pace
    }
}
