using System;
using System.Globalization;
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

    /// <summary>Balance reminder targets: Critical or Broken Promise, owing, with no active promise.</summary>
    public static bool IsBalanceReminderEligible(PriorityTier tier, decimal balance, bool hasActivePromise)
        => balance > 0m && !hasActivePromise
           && (tier == PriorityTier.Critical || tier == PriorityTier.BrokenPromise);
}
