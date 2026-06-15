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
    // Misconfigured / blank / portal URLs fall back to the working plain endpoint.
    [InlineData(null,                              "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("",                                "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("   ",                             "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("https://www.egosms.co",           "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("https://www.egosms.co/",          "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("www.egosms.co/api/v1/plain/",     "https://www.egosms.co/api/v1/plain/?")] // non-http
    // Properly-configured plain endpoints are honoured, with "?" ensured.
    [InlineData("https://www.egosms.co/api/v1/plain/",  "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("https://www.egosms.co/api/v1/plain/?", "https://www.egosms.co/api/v1/plain/?")]
    [InlineData("https://sms.example.com/api/send",     "https://sms.example.com/api/send?")]
    public void ResolveSmsBaseUrl_falls_back_unless_real_plain_endpoint(string configured, string expected)
        => Assert.Equal(expected, SmsReminderLogic.ResolveSmsBaseUrl(configured));

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

    // delta = today - promiseDate, in days. Windows must partition [-3..7] with no overlap:
    // -3..-1 = 3DayBefore, 0..1 = DayOf (day-of + 1-day catch-up), 2..7 = Overdue.
    [Theory]
    [InlineData(-4, null)]
    [InlineData(-3, "3DayBefore")]
    [InlineData(-2, "3DayBefore")]
    [InlineData(-1, "3DayBefore")]
    [InlineData(0,  "DayOf")]
    [InlineData(1,  "DayOf")]      // catch-up day, must NOT also be Overdue
    [InlineData(2,  "Overdue")]    // first overdue day, must NOT be DayOf
    [InlineData(7,  "Overdue")]
    [InlineData(8,  null)]
    public void ClassifyPromiseReminder_returns_single_non_overlapping_type(int delta, string expected)
    {
        var promiseDate = new DateTime(2026, 6, 14);
        var today = promiseDate.AddDays(delta);
        Assert.Equal(expected, SmsReminderLogic.ClassifyPromiseReminder(today, promiseDate));
    }

    [Fact]
    public void ResolveOptionalAmountSegments_keeps_inner_text_when_amount_present()
        => Assert.Equal(
            "today is your promised payment date of UGX {promised_amount} for X.",
            SmsReminderLogic.ResolveOptionalAmountSegments(
                "today is your promised payment date[[ of UGX {promised_amount}]] for X.", 100000m));

    [Fact]
    public void ResolveOptionalAmountSegments_drops_segment_when_amount_zero()
        => Assert.Equal(
            "today is your promised payment date for X.",
            SmsReminderLogic.ResolveOptionalAmountSegments(
                "today is your promised payment date[[ of UGX {promised_amount}]] for X.", 0m));

    [Fact]
    public void ResolveOptionalAmountSegments_leaves_template_without_markers_untouched()
        => Assert.Equal(
            "Balance: UGX {balance}.",
            SmsReminderLogic.ResolveOptionalAmountSegments("Balance: UGX {balance}.", 0m));
}
