using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class ModelTests
{
    [Theory]
    [InlineData("NOCONTACT-S123", true)]
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData("0771234567", false)]
    public void IsUnreachable_detects_nocontact_and_blank(string contact, bool expected)
    {
        var row = new GuardianWorklistRow { GuardianContact = contact };
        Assert.Equal(expected, row.IsUnreachable);
    }

    [Fact]
    public void UrgencyScore_field_round_trips()
    {
        var row = new GuardianWorklistRow { UrgencyScore = 1234.5 };
        Assert.Equal(1234.5, row.UrgencyScore);
    }

    [Fact]
    public void ProjectedCollectionRate_extrapolates_current_pace()
    {
        var d = new DashboardData
        {
            TotalPayable = 1000m,
            TotalCollected = 250m, // 25% collected
            TermProgress = 0.5,    // half the term gone
        };
        // 25% / 0.5 = 50% projected, capped at 100
        Assert.Equal(50.0, d.ProjectedCollectionRate, 3);
    }

    [Fact]
    public void ProjectedCollectionRate_is_zero_before_term_starts()
    {
        var d = new DashboardData { TotalPayable = 1000m, TotalCollected = 250m, TermProgress = 0.0 };
        Assert.Equal(0.0, d.ProjectedCollectionRate, 3);
    }

    [Fact]
    public void ProjectedCollectionRate_caps_at_100()
    {
        var d = new DashboardData { TotalPayable = 1000m, TotalCollected = 900m, TermProgress = 0.5 };
        Assert.Equal(100.0, d.ProjectedCollectionRate, 3);
    }

    [Fact]
    public void RequiredRateToday_is_goal_times_progress()
    {
        var d = new DashboardData { CollectionGoalPercent = 98m, TermProgress = 0.5 };
        Assert.Equal(49.0, d.RequiredRateToday, 3);
    }

    [Fact]
    public void AmountBehindPace_is_zero_when_ahead()
    {
        var d = new DashboardData
        {
            CollectionGoalPercent = 98m,
            TermProgress = 0.5,           // required 49%
            TotalPayable = 1000m,
            TotalCollected = 600m,        // 60% collected, ahead of 49%
        };
        Assert.Equal(0m, d.AmountBehindPace);
    }

    [Fact]
    public void AmountBehindPace_reports_shortfall_amount_when_behind()
    {
        var d = new DashboardData
        {
            CollectionGoalPercent = 98m,
            TermProgress = 0.5,           // required 49% -> 490 of 1000
            TotalPayable = 1000m,
            TotalCollected = 200m,        // behind: 490 - 200 = 290
        };
        Assert.Equal(290m, d.AmountBehindPace);
    }
}
