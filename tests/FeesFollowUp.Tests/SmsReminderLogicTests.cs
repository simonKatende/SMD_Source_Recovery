using System;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class SmsReminderLogicTests
{
    [Theory]
    [InlineData("0772123456", "256772123456")]
    [InlineData("0701234567", "256701234567")]
    [InlineData("772123456",  "256772123456")]
    [InlineData("256772123456", "256772123456")]
    [InlineData("+256 772 123456", "256772123456")]
    [InlineData("0772-123-456", "256772123456")]
    public void NormalizePhone_returns_uganda_msisdn(string raw, string expected)
        => Assert.Equal(expected, SmsReminderLogic.NormalizePhone(raw));

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    [InlineData("12345")]
    [InlineData("NOCONTACT-S001")]
    [InlineData("0812123456")]   // not a 7x mobile
    public void NormalizePhone_returns_null_for_invalid(string raw)
        => Assert.Null(SmsReminderLogic.NormalizePhone(raw));

    [Theory]
    [InlineData(0, "0")]
    [InlineData(1500000, "1,500,000")]
    [InlineData(40, "40")]
    public void FormatAmount_shows_zero_and_thousands(decimal v, string expected)
        => Assert.Equal(expected, SmsReminderLogic.FormatAmount(v));

    [Theory]
    [InlineData(PriorityTier.Critical,      1000, false, true)]
    [InlineData(PriorityTier.BrokenPromise, 1000, false, true)]
    [InlineData(PriorityTier.Stale,         1000, false, false)]   // Stale excluded this pass
    [InlineData(PriorityTier.Current,       1000, false, false)]
    [InlineData(PriorityTier.Critical,         0, false, false)]   // zero balance
    [InlineData(PriorityTier.Critical,      1000, true,  false)]   // active promise
    public void IsBalanceReminderEligible(PriorityTier tier, decimal bal, bool activePromise, bool expected)
        => Assert.Equal(expected, SmsReminderLogic.IsBalanceReminderEligible(tier, bal, activePromise));
}
