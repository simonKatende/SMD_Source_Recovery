using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class SmokeTests
{
    [Fact]
    public void Poco_types_are_reachable()
    {
        var row = new GuardianWorklistRow { TotalBalance = 1000m };
        Assert.Equal(1000m, row.TotalBalance);
        Assert.Equal(PriorityTier.Critical, (PriorityTier)0);
    }
}
