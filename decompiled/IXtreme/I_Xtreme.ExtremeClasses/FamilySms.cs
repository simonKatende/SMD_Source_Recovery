using System;
using System.Collections.Generic;
using System.Linq;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>
/// Pure SMS composition for a guardian family: the single place that turns a template plus a
/// family's children into the exact message(s) to send, honouring the family's SMS style.
/// Depends only on System + I_Xtreme.Models so it is unit-testable.
/// </summary>
public static class FamilySms
{
    public const string DefaultPreDue =
        "Dear Parent, you promised a payment[[ of UGX {promised_amount}]] for {names} ({class}) by {date}. " +
        "Your balance is UGX {balance}. Please pay as promised. - {school}";

    public const string DefaultDayOf =
        "Dear Parent, today is your promised payment date[[ of UGX {promised_amount}]] for {names} ({class}). " +
        "Balance: UGX {balance}. Please pay today. - {school}";

    public const string DefaultOverdue =
        "Dear Parent, your payment[[ of UGX {promised_amount}]] for {names} ({class}) was due on {date} " +
        "but has not been received. Balance: UGX {balance}. Please pay immediately. - {school}";

    public const string DefaultGeneral =
        "Dear Parent, {names} ({class}) has an outstanding balance of UGX {balance}. " +
        "Please pay or contact the bursar to arrange a payment plan. - {school}";

    // Defaults an older settings window used to save. They print "UGX 0" for a promise logged
    // without an amount, so a stored copy of one is treated as "use the current default".
    private static readonly string[] LegacyDefaults =
    {
        "Dear Parent, you promised to pay UGX {promised_amount} for {names} by {date}. Your overall balance is UGX {balance}. Please pay as promised. - {school}",
        "Dear Parent, today is your promised payment date of UGX {promised_amount} for {names}. Your overall balance is UGX {balance}. Please make your payment today. - {school}",
        "Dear Parent, your payment of UGX {promised_amount} for {names} ({class}) was due on {date} but has not been received. Balance: UGX {balance}. Please pay immediately. - {school}",
    };

    /// <summary>The default template for a reminder type ("3DayBefore" | "DayOf" | "Overdue" | "General").</summary>
    public static string DefaultTemplate(string reminderType) => reminderType switch
    {
        "3DayBefore" => DefaultPreDue,
        "DayOf"      => DefaultDayOf,
        "Overdue"    => DefaultOverdue,
        "General"    => DefaultGeneral,
        _            => "",
    };

    /// <summary>The template to use: the stored one, unless it is blank or an outdated default.</summary>
    public static string ResolveTemplate(string stored, string reminderType)
    {
        if (string.IsNullOrWhiteSpace(stored)) return DefaultTemplate(reminderType);
        string s = stored.Trim();
        foreach (string legacy in LegacyDefaults)
            if (string.Equals(s, legacy, StringComparison.Ordinal)) return DefaultTemplate(reminderType);
        return s;
    }

    public static SmsStyle ParseStyle(string raw, SmsStyle fallback = SmsStyle.FamilyTotal)
        => Enum.TryParse(raw, ignoreCase: true, out SmsStyle s) ? s : fallback;

    /// <summary>"Ali", "Ali and Sara", "Ali, Sara and Tom".</summary>
    public static string JoinNames(IEnumerable<string> names)
    {
        var list = (names ?? Enumerable.Empty<string>())
            .Where(n => !string.IsNullOrWhiteSpace(n)).Select(n => n.Trim()).ToList();
        if (list.Count == 0) return "";
        if (list.Count == 1) return list[0];
        return string.Join(", ", list.Take(list.Count - 1)) + " and " + list[list.Count - 1];
    }

    /// <summary>Number of SMS parts a message is billed as (160 characters, or 153 each when split).</summary>
    public static int SegmentCount(string message)
    {
        int len = (message ?? "").Length;
        if (len == 0) return 0;
        return len <= 160 ? 1 : (int)Math.Ceiling(len / 153.0);
    }

    /// <summary>Fill one template for one child or one whole family.</summary>
    public static string Render(string template, string names, string classes, decimal balance,
        DateTime date, string school, decimal promisedAmount)
    {
        string t = SmsReminderLogic.ResolveOptionalAmountSegments(template ?? "", promisedAmount);
        // "{names} ({class})" with no class would leave an empty "()" behind.
        if (string.IsNullOrWhiteSpace(classes))
            t = t.Replace("{names} ({class})", "{names}").Replace(" ({class})", "");
        return t
            .Replace("{promised_amount}", SmsReminderLogic.FormatAmount(promisedAmount))
            .Replace("{balance}",         SmsReminderLogic.FormatAmount(balance))
            .Replace("{names}",           names ?? "")
            .Replace("{class}",           classes ?? "")
            .Replace("{date}",            date.ToString("dd-MMM-yyyy"))
            .Replace("{school}",          school ?? "");
    }

    /// <summary>
    /// The exact message(s) to send to one guardian.
    /// FamilyTotal: one message naming every child, with the family total.
    /// PerChild: one message per child with that child's own balance; the promised amount is
    /// quoted only when the promise was made for that child (or the family has one child), so a
    /// family promise never shows a wrong figure against a single child.
    /// </summary>
    /// <param name="students">The children the message is about.</param>
    /// <param name="promiseStudentNumber">The child the promise was logged for; blank for a family promise.</param>
    public static List<string> Compose(SmsStyle style, string template, IList<StudentSummary> students,
        DateTime date, string school, decimal promisedAmount, string promiseStudentNumber = null)
    {
        var result = new List<string>();
        var kids = (students ?? new List<StudentSummary>()).Where(s => s != null).ToList();
        if (kids.Count == 0 || string.IsNullOrWhiteSpace(template)) return result;

        if (style == SmsStyle.FamilyTotal || kids.Count == 1)
        {
            decimal total = kids.Sum(s => s.Balance);
            string names, classes;
            if (kids.Count == 1)
            {
                names   = kids[0].FullName;
                classes = kids[0].ClassId;
            }
            else if ((template ?? "").Contains("{names} ({class})"))
            {
                // Keep each class beside its own child: "Ali (P.3) and Sara (P.5)".
                names = JoinNames(kids.Select(s => string.IsNullOrWhiteSpace(s.ClassId)
                    ? s.FullName : $"{s.FullName} ({s.ClassId})"));
                classes = "";
            }
            else
            {
                names   = JoinNames(kids.Select(s => s.FullName));
                classes = string.Join(", ", kids.Select(s => s.ClassId)
                    .Where(c => !string.IsNullOrWhiteSpace(c)).Distinct());
            }
            result.Add(Render(template, names, classes, total, date, school, promisedAmount));
            return result;
        }

        // PerChild: only children who still owe (all of them if nobody owes).
        var owing = kids.Where(s => s.Balance > 0m).ToList();
        if (owing.Count == 0) owing = kids;
        foreach (var s in owing)
        {
            bool promiseIsForThisChild = !string.IsNullOrWhiteSpace(promiseStudentNumber)
                && string.Equals(promiseStudentNumber.Trim(), (s.StudentNumber ?? "").Trim(),
                                 StringComparison.OrdinalIgnoreCase);
            result.Add(Render(template, s.FullName, s.ClassId, s.Balance, date, school,
                promiseIsForThisChild ? promisedAmount : 0m));
        }
        return result;
    }
}
