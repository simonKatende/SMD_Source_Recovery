using System;
using System.Collections.Generic;
using System.Linq;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class FamilySmsTests
{
    private static readonly DateTime Date = new DateTime(2026, 10, 25);

    private static List<StudentSummary> Family() => new List<StudentSummary>
    {
        new StudentSummary { StudentNumber = "A", FullName = "Ali Kato",  ClassId = "P.3", Balance = 200_000m },
        new StudentSummary { StudentNumber = "B", FullName = "Sara Kato", ClassId = "P.5", Balance = 150_000m },
        new StudentSummary { StudentNumber = "C", FullName = "Tom Kato",  ClassId = "P.7", Balance = 0m },
    };

    [Fact]
    public void Family_total_sends_one_message_with_every_child_and_the_total()
    {
        var msgs = FamilySms.Compose(SmsStyle.FamilyTotal, FamilySms.DefaultGeneral, Family(), Date, "HPS", 0m);

        Assert.Single(msgs);
        Assert.Contains("Ali Kato (P.3), Sara Kato (P.5) and Tom Kato (P.7)", msgs[0]);
        Assert.Contains("UGX 350,000", msgs[0]);
        Assert.DoesNotContain("()", msgs[0]);
        Assert.DoesNotContain("{", msgs[0]);
    }

    [Fact]
    public void Per_child_sends_each_owing_child_their_own_details()
    {
        var msgs = FamilySms.Compose(SmsStyle.PerChild, FamilySms.DefaultGeneral, Family(), Date, "HPS", 0m);

        Assert.Equal(2, msgs.Count);   // Tom owes nothing
        Assert.Contains("Ali Kato (P.3)", msgs[0]);
        Assert.Contains("UGX 200,000", msgs[0]);
        Assert.Contains("Sara Kato (P.5)", msgs[1]);
        Assert.Contains("UGX 150,000", msgs[1]);
        Assert.Equal(msgs.Count, msgs.Distinct().Count());   // never the same text twice
    }

    [Fact]
    public void Per_child_leaves_the_family_promise_amount_out()
    {
        var msgs = FamilySms.Compose(SmsStyle.PerChild, FamilySms.DefaultPreDue, Family(), Date, "HPS",
            promisedAmount: 300_000m, promiseStudentNumber: null);

        Assert.All(msgs, m => Assert.DoesNotContain("300,000", m));
        Assert.All(msgs, m => Assert.Contains("you promised a payment for", m));
    }

    [Fact]
    public void Per_child_quotes_the_amount_only_for_the_child_it_was_promised_for()
    {
        var msgs = FamilySms.Compose(SmsStyle.PerChild, FamilySms.DefaultPreDue, Family(), Date, "HPS",
            promisedAmount: 100_000m, promiseStudentNumber: "B");

        Assert.DoesNotContain("of UGX 100,000", msgs[0]);
        Assert.Contains("of UGX 100,000", msgs[1]);
    }

    [Fact]
    public void Family_total_quotes_the_family_promise_amount()
    {
        var msgs = FamilySms.Compose(SmsStyle.FamilyTotal, FamilySms.DefaultDayOf, Family(), Date, "HPS", 300_000m);
        Assert.Contains("of UGX 300,000", msgs[0]);
        Assert.Contains("Balance: UGX 350,000", msgs[0]);
    }

    [Fact]
    public void Single_child_family_is_the_same_in_both_styles()
    {
        var one = Family().Take(1).ToList();
        var a = FamilySms.Compose(SmsStyle.FamilyTotal, FamilySms.DefaultOverdue, one, Date, "HPS", 50_000m);
        var b = FamilySms.Compose(SmsStyle.PerChild,    FamilySms.DefaultOverdue, one, Date, "HPS", 50_000m);
        Assert.Equal(a, b);
        Assert.Contains("Ali Kato (P.3)", a[0]);
        Assert.Contains("25-Oct-2026", a[0]);
    }

    [Fact]
    public void Custom_template_without_class_brackets_joins_names_and_classes_separately()
    {
        var msgs = FamilySms.Compose(SmsStyle.FamilyTotal, "Pay {balance} for {names} in {class}.", Family(), Date, "HPS", 0m);
        Assert.Equal("Pay 350,000 for Ali Kato, Sara Kato and Tom Kato in P.3, P.5, P.7.", msgs[0]);
    }

    [Fact]
    public void Nothing_to_send_without_children_or_template()
    {
        Assert.Empty(FamilySms.Compose(SmsStyle.FamilyTotal, FamilySms.DefaultGeneral, new List<StudentSummary>(), Date, "HPS", 0m));
        Assert.Empty(FamilySms.Compose(SmsStyle.FamilyTotal, " ", Family(), Date, "HPS", 0m));
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("Ali", "Ali")]
    [InlineData("Ali|Sara", "Ali and Sara")]
    [InlineData("Ali|Sara|Tom", "Ali, Sara and Tom")]
    public void Names_are_joined_naturally(string input, string expected)
        => Assert.Equal(expected, FamilySms.JoinNames(input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(160, 1)]
    [InlineData(161, 2)]
    [InlineData(306, 2)]
    [InlineData(307, 3)]
    public void Sms_parts_are_counted(int length, int expected)
        => Assert.Equal(expected, FamilySms.SegmentCount(new string('x', length)));

    [Fact]
    public void Outdated_stored_default_is_swapped_for_the_current_one()
    {
        string legacy = "Dear Parent, you promised to pay UGX {promised_amount} for {names} by {date}. Your overall balance is UGX {balance}. Please pay as promised. - {school}";
        Assert.Equal(FamilySms.DefaultPreDue, FamilySms.ResolveTemplate(legacy, "3DayBefore"));
        Assert.Equal(FamilySms.DefaultGeneral, FamilySms.ResolveTemplate("  ", "General"));
        Assert.Equal("My own words {balance}", FamilySms.ResolveTemplate(" My own words {balance} ", "Overdue"));
    }

    [Fact]
    public void Promise_without_amount_never_prints_zero()
    {
        var msgs = FamilySms.Compose(SmsStyle.FamilyTotal, FamilySms.DefaultOverdue, Family(), Date, "HPS", 0m);
        Assert.DoesNotContain("UGX 0", msgs[0]);
    }

    [Theory]
    [InlineData("PerChild", SmsStyle.PerChild)]
    [InlineData("familytotal", SmsStyle.FamilyTotal)]
    [InlineData("", SmsStyle.FamilyTotal)]
    [InlineData("nonsense", SmsStyle.FamilyTotal)]
    public void Style_is_parsed_with_a_safe_fallback(string raw, SmsStyle expected)
        => Assert.Equal(expected, FamilySms.ParseStyle(raw));
}
