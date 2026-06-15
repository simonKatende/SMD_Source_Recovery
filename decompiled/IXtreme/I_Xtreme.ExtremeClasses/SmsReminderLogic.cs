using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>
/// Pure, dependency-free SMS-reminder helpers (phone/format/eligibility/cooldown/
/// consolidation). Depends only on System + I_Xtreme.Models so it is unit-testable.
/// </summary>
public static class SmsReminderLogic
{
    /// <summary>Normalize a Ugandan number to MSISDN form 2567XXXXXXXX, or null if not valid.</summary>
    public static string NormalizePhone(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw)) return null;
        var sb = new StringBuilder();
        foreach (char c in raw) if (c >= '0' && c <= '9') sb.Append(c);
        string d = sb.ToString();
        if (d.Length == 12 && d.StartsWith("2567", StringComparison.Ordinal)) return d;
        if (d.Length == 10 && d[0] == '0' && d[1] == '7') return "256" + d.Substring(1);
        if (d.Length == 9  && d[0] == '7') return "256" + d;
        if (d.Length == 13 && d.StartsWith("2560", StringComparison.Ordinal) && d[4] == '7')
            return "256" + d.Substring(4);   // 256 + local-with-leading-0
        return null;
    }

    /// <summary>Thousands-separated amount; 0 renders as "0" (never blank).</summary>
    public static string FormatAmount(decimal value)
        => value.ToString("#,##0", CultureInfo.InvariantCulture);

    /// <summary>
    /// True when an SMS-gateway response indicates success. egosms /plain returns the literal
    /// "OK"; some gateway variants return a positive integer (batch id / count). Anything else
    /// (empty, "0", an error string) is a failure.
    /// </summary>
    public static bool IsGatewaySuccessResponse(string response)
    {
        if (string.IsNullOrWhiteSpace(response)) return false;
        string r = response.Trim();
        if (r.Equals("OK", StringComparison.OrdinalIgnoreCase)) return true;
        return int.TryParse(r, out int code) && code > 0;
    }

    /// <summary>
    /// The egosms send endpoint to use. A correctly-configured plain-API URL (one that contains
    /// "/api/" or "/plain") is honoured; anything else — blank, non-http, or a portal/host URL
    /// such as "https://www.egosms.co" that returns the HTML login page instead of sending —
    /// falls back to the known plain endpoint. The trailing "?" is ensured for query building.
    /// (The old gateway hardcoded this endpoint and ignored tbl_SMSAccount.url, so a stale
    /// portal URL in that column was harmless until the newer code began honouring it.)
    /// </summary>
    public static string ResolveSmsBaseUrl(string configuredUrl)
    {
        const string Default = "https://www.egosms.co/api/v1/plain/?";
        if (string.IsNullOrWhiteSpace(configuredUrl)) return Default;
        string u = configuredUrl.Trim();
        if (!u.StartsWith("http", StringComparison.OrdinalIgnoreCase)) return Default;
        if (u.IndexOf("/plain", StringComparison.OrdinalIgnoreCase) < 0
            && u.IndexOf("/api/", StringComparison.OrdinalIgnoreCase) < 0) return Default;
        return u.EndsWith("?", StringComparison.Ordinal) ? u : u + "?";
    }

    /// <summary>Balance reminder targets: Critical or Broken Promise, owing, with no active promise.</summary>
    public static bool IsBalanceReminderEligible(PriorityTier tier, decimal balance, bool hasActivePromise)
        => balance > 0m && !hasActivePromise
           && (tier == PriorityTier.Critical || tier == PriorityTier.BrokenPromise);

    /// <summary>
    /// Classify a promise into exactly one reminder type for today, or null if none is due.
    /// Windows partition the days around the promise date with no overlap so a single promise
    /// can never produce two reminders on the same run:
    ///   delta -3..-1 = "3DayBefore", delta 0..1 = "DayOf" (promise day + 1-day catch-up),
    ///   delta 2..7 = "Overdue", where delta = (today - promiseDate) in whole days.
    /// </summary>
    public static string ClassifyPromiseReminder(DateTime today, DateTime promiseDate)
    {
        int delta = (today.Date - promiseDate.Date).Days;
        if (delta >= -3 && delta <= -1) return "3DayBefore";
        if (delta == 0  || delta == 1)  return "DayOf";
        if (delta >= 2  && delta <= 7)  return "Overdue";
        return null;
    }

    /// <summary>
    /// Resolve optional "[[ ... ]]" segments in an SMS template against the promised amount.
    /// Each segment is unwrapped (markers removed, inner text kept) when promisedAmount &gt; 0,
    /// or dropped entirely when promisedAmount is 0 / negative. Lets a template carry an amount
    /// clause that disappears for promises logged without an amount, instead of rendering "UGX 0".
    /// Templates with no markers are returned unchanged.
    /// </summary>
    public static string ResolveOptionalAmountSegments(string template, decimal promisedAmount)
    {
        if (string.IsNullOrEmpty(template)) return template;
        var sb = new StringBuilder(template.Length);
        int i = 0;
        while (i < template.Length)
        {
            int open = template.IndexOf("[[", i, StringComparison.Ordinal);
            if (open < 0) { sb.Append(template, i, template.Length - i); break; }
            int close = template.IndexOf("]]", open + 2, StringComparison.Ordinal);
            if (close < 0) { sb.Append(template, i, template.Length - i); break; }

            sb.Append(template, i, open - i);                       // text before the segment
            if (promisedAmount > 0m)
                sb.Append(template, open + 2, close - (open + 2));  // keep inner text
            i = close + 2;                                          // skip the segment when dropped
        }
        return sb.ToString();
    }

    /// <summary>
    /// Collapse per-student promise reminders into one item per (GuardianKey, ReminderType).
    /// Names/classes are joined in input order, balance/promised summed, PromiseDate = earliest,
    /// and every underlying (StudentNumber, PromiseDate) is retained in Components for per-student
    /// de-dup logging. Message is left null for the caller to render from the merged values.
    /// </summary>
    public static List<ReminderItem> ConsolidatePromiseReminders(IEnumerable<ReminderItem> perStudent)
    {
        var result = new List<ReminderItem>();
        foreach (var grp in perStudent.GroupBy(r => new { r.GuardianKey, r.ReminderType }))
        {
            var items = grp.ToList();
            var first = items.OrderBy(i => i.PromiseDate).First();
            result.Add(new ReminderItem
            {
                GuardianKey    = grp.Key.GuardianKey,
                ReminderType   = grp.Key.ReminderType,
                Phone          = first.Phone,
                StudentNumber  = first.StudentNumber,
                StudentName    = string.Join(", ", items.Select(i => i.StudentName)
                                     .Where(n => !string.IsNullOrWhiteSpace(n))),
                ClassId        = string.Join(", ", items.Select(i => i.ClassId)
                                     .Where(c => !string.IsNullOrWhiteSpace(c))),
                Balance        = items.Sum(i => i.Balance),
                PromisedAmount = items.Sum(i => i.PromisedAmount),
                PromiseDate    = items.Min(i => i.PromiseDate),
                Message        = null,
                Components     = items.Select(i => new ReminderComponent
                                 { StudentNumber = i.StudentNumber, PromiseDate = i.PromiseDate }).ToList(),
            });
        }
        return result;
    }
}
