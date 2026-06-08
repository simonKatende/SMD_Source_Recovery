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

    private static ReminderItem PItem(string guardian, string type, string student,
        string classId, decimal balance, decimal promised, DateTime promiseDate)
        => new ReminderItem
        {
            GuardianKey = guardian, ReminderType = type, StudentName = student,
            ClassId = classId, Balance = balance, PromisedAmount = promised,
            PromiseDate = promiseDate, StudentNumber = student, Phone = "256772000000",
        };

    [Fact]
    public void Consolidate_merges_same_guardian_same_type_into_one_item()
    {
        var d = new DateTime(2026, 6, 10);
        var input = new[]
        {
            PItem("256772000000", "DayOf", "Amina", "P3", 400000, 100000, d),
            PItem("256772000000", "DayOf", "Yusuf", "P5", 350000, 50000,  d.AddDays(1)),
            PItem("256772000000", "DayOf", "Sara",  "P1", 300000, 0,      d),
        };
        var outp = SmsReminderLogic.ConsolidatePromiseReminders(input);
        var item = Assert.Single(outp);
        Assert.Equal("Amina, Yusuf, Sara", item.StudentName);
        Assert.Equal("P3, P5, P1", item.ClassId);
        Assert.Equal(1_050_000m, item.Balance);
        Assert.Equal(150_000m, item.PromisedAmount);
        Assert.Equal(d, item.PromiseDate);            // earliest date in the group
        Assert.Equal(3, item.Components.Count);       // all students retained for logging
    }

    [Fact]
    public void Consolidate_keeps_distinct_types_separate()
    {
        var d = new DateTime(2026, 6, 10);
        var input = new[]
        {
            PItem("256772000000", "DayOf",   "Amina", "P3", 400000, 100000, d),
            PItem("256772000000", "Overdue", "Yusuf", "P5", 350000, 50000,  d.AddDays(-2)),
        };
        var outp = SmsReminderLogic.ConsolidatePromiseReminders(input);
        Assert.Equal(2, outp.Count);
        Assert.Contains(outp, i => i.ReminderType == "DayOf"   && i.Components.Count == 1);
        Assert.Contains(outp, i => i.ReminderType == "Overdue" && i.Components.Count == 1);
    }

    [Fact]
    public void Consolidate_groups_by_guardian()
    {
        var d = new DateTime(2026, 6, 10);
        var input = new[]
        {
            PItem("256772000001", "DayOf", "A", "P3", 100, 0, d),
            PItem("256772000002", "DayOf", "B", "P4", 200, 0, d),
        };
        var outp = SmsReminderLogic.ConsolidatePromiseReminders(input);
        Assert.Equal(2, outp.Count);
    }

    [Theory]
    [InlineData("OK", true)]
    [InlineData("ok", true)]
    [InlineData(" OK ", true)]
    [InlineData("1", true)]
    [InlineData("250", true)]
    [InlineData("0", false)]
    [InlineData("Failed", false)]
    [InlineData("Insufficient balance", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsGatewaySuccessResponse_matches_OK_or_positive_int(string response, bool expected)
        => Assert.Equal(expected, SmsReminderLogic.IsGatewaySuccessResponse(response));
}
