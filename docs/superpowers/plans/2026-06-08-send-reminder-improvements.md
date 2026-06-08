# Send Reminder Improvements Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Add general balance reminders for at-risk non-promisers (with a cooldown), consolidate promise reminders to one SMS per guardian per occurrence, and harden the SMS gateway and message rendering.

**Architecture:** Pure, table-driven logic (phone normalization, amount formatting, eligibility, cooldown, consolidation) lives in a new dependency-light `SmsReminderLogic` static class, unit-tested by the existing `FeesFollowUp.Tests` xUnit project. The DB-bound service (`FeesFollowUpService`), gateway (`FeeSmsHelper`), settings dialog, preview dialog, dashboard control, and ribbon are wired to use it; those are verified by `dotnet build` + the `smoke_test/` deployment.

**Tech Stack:** C# 11, net472 WinForms, DevExpress v23.2, SQL Server (egosms HTTP gateway). Tests: net8.0 + xUnit (source-linked).

**Spec:** `docs/superpowers/specs/2026-06-08-send-reminder-improvements-design.md`

**Branch:** `feat/send-reminder-improvements` (already created).

**Key source anchors (verified):**
- `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` — `FeesFollowUpSettings` (~7-41), `SmsReminderResult` (44-52), `ReminderItem` (~177-189).
- `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` — `DefaultPreDue/DayOf/Overdue/General` consts (15-29), `GetSettings` (75-139), `SaveSettings` (141-168), `GetStudentsWithActivePromises` (729-849), `GetRemindersPreview` (851-863), `ExecuteSendReminders` (865-888), `ApplySmsTemplate` (890-898), `LogReminderSent` (936-947).
- `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeeSmsHelper.cs` — `TrySend` (11-84).
- `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs` — template memos + buttons (~174-271 after the prior overhaul).
- `decompiled/IXtreme/I_Xtreme.DialogForms/dlgSendRemindersPreview.cs` — constructor (23-27), `LoadPreview` (87-101), `ConfigureColumns` (104-145), `BtnSend_Click` (187-214).
- `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` — `SendReminders` (371-381 area).
- `decompiled/IXtreme/I_Xtreme/MainForm.cs` — `bbiSendReminders` field decl (553), setup (24822-24827), settings-group link (24845), ribbon `Items.AddRange` (24904-24905).

**Conventions:** locate edits by matching quoted code (line numbers drift). Build logs → `notes/IXtreme_buildN.log`. Conventional commits. Don't touch `backup/` or `smoke_test/` source.

---

## Task 1: Model changes — settings, result counters, reminder components

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs`

- [ ] **Step 1: Add the two new settings to `FeesFollowUpSettings`**

After the deadline-aware block (the lines `public int CallRequiredWindowDays …` / `public int PromiseResurfaceDays …`), add:

```csharp
    // Send Reminder improvements (2026-06-08).
    public int    GeneralReminderCooldownDays { get; set; } = 7;     // min days between balance reminders to a guardian
    public string SmsTemplateGeneral          { get; set; } = "";    // balance-reminder template (falls back to DefaultGeneral)
```

- [ ] **Step 2: Add counters to `SmsReminderResult`**

Replace the whole `SmsReminderResult` class body:

```csharp
public class SmsReminderResult
{
    public bool AlreadyRanToday { get; set; }
    public int  TwoDayCount     { get; set; }
    public int  DayOfCount      { get; set; }
    public int  OverdueCount    { get; set; }
    public int  GeneralCount    { get; set; }
    public List<string> Failures { get; set; } = new List<string>();
    public bool HasFailures => Failures.Count > 0;
    public int  TotalSent   => TwoDayCount + DayOfCount + OverdueCount + GeneralCount;
}
```

- [ ] **Step 3: Add `ReminderComponent` and `Components` to `ReminderItem`**

In the `ReminderItem` class, after the `Message` property, add:

```csharp
    // Per-student rows underlying a consolidated promise reminder (empty for General).
    public List<ReminderComponent> Components { get; set; } = new List<ReminderComponent>();
```

And add this new class immediately after `ReminderItem`:

```csharp
public class ReminderComponent
{
    public string   StudentNumber { get; set; }
    public DateTime PromiseDate   { get; set; }
}
```

- [ ] **Step 4: Verify the test project still compiles (it source-links this file)**

Run: `dotnet build tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj -clp:ErrorsOnly`
Expected: Build succeeded.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs
git commit -m "feat(fees-sms): model fields for balance reminders, result counters, reminder components"
```

---

## Task 2: SmsReminderLogic — normalize/format/eligibility/cooldown (TDD)

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs`
- Create: `tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs`
- Modify: `tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj` (source-link the new file)

- [ ] **Step 1: Source-link the new logic file into the test project**

In `FeesFollowUp.Tests.csproj`, inside the `<ItemGroup>` that `<Compile Include=…>`s the linked sources, add:

```xml
    <Compile Include="..\..\decompiled\IXtreme\I_Xtreme.ExtremeClasses\SmsReminderLogic.cs" Link="Logic\SmsReminderLogic.cs" />
```

- [ ] **Step 2: Write failing tests**

Create `tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs`:

```csharp
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
```

- [ ] **Step 3: Run tests to verify they fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `SmsReminderLogic` does not exist.

- [ ] **Step 4: Implement `SmsReminderLogic` (this step; consolidation added in Task 3)**

Create `decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs`:

```csharp
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

    /// <summary>Balance reminder targets: Critical or Broken Promise, owing, with no active promise.</summary>
    public static bool IsBalanceReminderEligible(PriorityTier tier, decimal balance, bool hasActivePromise)
        => balance > 0m && !hasActivePromise
           && (tier == PriorityTier.Critical || tier == PriorityTier.BrokenPromise);
}
```

(Cooldown is enforced by the set-based SQL query `GetGuardiansInGeneralCooldown` in Task 7 — a guardian with a `General` log whose `SentAt >= today − cooldownDays` is excluded. There is no separate pure cooldown helper, to avoid shipping a tested-but-unused function.)

- [ ] **Step 5: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS.

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj
git commit -m "feat(fees-sms): pure phone/format/eligibility/cooldown logic with tests"
```

---

## Task 3: SmsReminderLogic.ConsolidatePromiseReminders (TDD)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs`
- Modify: `tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs`

- [ ] **Step 1: Write failing tests**

Append to `SmsReminderLogicTests.cs` (inside the class):

```csharp
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
```

- [ ] **Step 2: Run tests to verify they fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `ConsolidatePromiseReminders` not defined.

- [ ] **Step 3: Implement `ConsolidatePromiseReminders`**

In `SmsReminderLogic.cs`, add to the class (after `WithinCooldown`):

```csharp
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
```

- [ ] **Step 4: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs
git commit -m "feat(fees-sms): guardian-per-type promise consolidation with tests"
```

---

## Task 4: Service — new settings + amount formatting + template picker

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Load the two new keys in `GetSettings`**

In the `new FeesFollowUpSettings { … }` initializer, after the `PromiseResurfaceDays = …,` block, add:

```csharp
            GeneralReminderCooldownDays =
                dict.TryGetValue("GeneralReminderCooldownDays", out var grc) && int.TryParse(grc, out int grci)
                    ? grci : 7,
            SmsTemplateGeneral = dict.TryGetValue("SmsTemplateGeneral", out var stg) ? stg : "",
```

- [ ] **Step 2: Persist them in `SaveSettings`**

After the `Upsert(conn, "PromiseResurfaceDays", …);` line, add:

```csharp
        Upsert(conn, "GeneralReminderCooldownDays", s.GeneralReminderCooldownDays.ToString());
        Upsert(conn, "SmsTemplateGeneral",          s.SmsTemplateGeneral ?? "");
```

- [ ] **Step 3: Route amounts through `SmsReminderLogic.FormatAmount`**

Replace `ApplySmsTemplate` (its body uses `$"{promisedAmount:#,#}"` / `$"{balance:#,#}"`):

```csharp
    private static string ApplySmsTemplate(string template, decimal balance,
        string studentName, string classId, DateTime date, string school, decimal promisedAmount)
        => template
            .Replace("{promised_amount}", SmsReminderLogic.FormatAmount(promisedAmount))
            .Replace("{balance}",         SmsReminderLogic.FormatAmount(balance))
            .Replace("{names}",           studentName)
            .Replace("{class}",           classId ?? "")
            .Replace("{date}",            date.ToString("dd-MMM-yyyy"))
            .Replace("{school}",          school);
```

- [ ] **Step 4: Add a shared promise-template picker (DRY) and use it in `GetStudentsWithActivePromises`**

Add this private method just above `GetStudentsWithActivePromises`:

```csharp
    private static string PickPromiseTemplate(string type, FeesFollowUpSettings s) => type switch
    {
        "3DayBefore" => !string.IsNullOrWhiteSpace(s.SmsTemplate2Day)    ? s.SmsTemplate2Day    : DefaultPreDue,
        "DayOf"      => !string.IsNullOrWhiteSpace(s.SmsTemplateDayOf)   ? s.SmsTemplateDayOf   : DefaultDayOf,
        "Overdue"    => !string.IsNullOrWhiteSpace(s.SmsTemplateOverdue) ? s.SmsTemplateOverdue : DefaultOverdue,
        _            => "",
    };
```

In `GetStudentsWithActivePromises`, the method receives `preDueTemplate/dayOfTemplate/overdueTemplate` params and selects inline. Leave that method as-is for now (it still renders per-student messages that Task 6 will re-render after consolidation). No change in this step beyond adding the helper.

- [ ] **Step 5: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build4.binlog 2>&1 | tee notes/IXtreme_sms_build4.log`
Expected: Build succeeded.

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_sms_build4.log
git commit -m "feat(fees-sms): persist general-reminder settings, format amounts via SmsReminderLogic"
```

---

## Task 5: Service — `ExecuteSendReminders` counters + General/components logging

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Add a guardian-level general log method**

After `LogReminderSent` (936-947), add:

```csharp
    private void LogGeneralReminderSent(SqlConnection conn, string guardianKey)
    {
        using var cmd = new SqlCommand(
            "INSERT INTO tbl_SmsReminderLog (GuardianKey, StudentNumber, PromiseDate, ReminderType) " +
            "VALUES (@gk, NULL, @pd, 'General')", conn);
        cmd.Parameters.Add("@gk", SqlDbType.VarChar, 20).Value = guardianKey;
        cmd.Parameters.Add("@pd", SqlDbType.Date).Value        = DateTime.Today;   // SentAt defaults to GETDATE()
        cmd.ExecuteNonQuery();
    }
```

- [ ] **Step 2: Replace the success branch in `ExecuteSendReminders`**

Replace the `if (FeeSmsHelper.TrySend(...)) { LogReminderSent(...); switch(...) {...} }` block (the success arm) with:

```csharp
            if (FeeSmsHelper.TrySend(connectionString, item.Phone, item.Message, out string err))
            {
                if (item.ReminderType == "General")
                {
                    LogGeneralReminderSent(conn, item.GuardianKey);
                    result.GeneralCount++;
                }
                else
                {
                    // Per-student de-dup logging: log every underlying component (or the item
                    // itself if it was not consolidated).
                    if (item.Components != null && item.Components.Count > 0)
                        foreach (var c in item.Components)
                            LogReminderSent(conn, item.GuardianKey, c.StudentNumber, c.PromiseDate, item.ReminderType);
                    else
                        LogReminderSent(conn, item.GuardianKey, item.StudentNumber, item.PromiseDate, item.ReminderType);

                    switch (item.ReminderType)
                    {
                        case "3DayBefore": result.TwoDayCount++;  break;
                        case "DayOf":      result.DayOfCount++;   break;
                        case "Overdue":    result.OverdueCount++; break;
                    }
                }
            }
            else
            {
                result.Failures.Add($"{item.ReminderType} to {item.Phone} ({item.StudentName}): {err}");
            }
```

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build5.binlog 2>&1 | tee notes/IXtreme_sms_build5.log`
Expected: Build succeeded.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_sms_build5.log
git commit -m "feat(fees-sms): per-type counters + General/per-component reminder logging"
```

---

## Task 6: Service — consolidate promise reminders in `GetRemindersPreview`

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Consolidate + re-render after the already-sent filter**

Replace `GetRemindersPreview` (851-863) with:

```csharp
    public List<ReminderItem> GetRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        var all = GetStudentsWithActivePromises(conn, school,
            settings.SmsTemplate2Day, settings.SmsTemplateDayOf, settings.SmsTemplateOverdue);

        // Drop already-sent, per student (idempotency preserved at student grain).
        var notSent = all.Where(item =>
            !AlreadySentReminder(conn, item.GuardianKey, item.StudentNumber, item.PromiseDate, item.ReminderType))
            .ToList();

        // One SMS per guardian per reminder-type occurrence; re-render from merged values.
        var consolidated = SmsReminderLogic.ConsolidatePromiseReminders(notSent);
        foreach (var item in consolidated)
            item.Message = ApplySmsTemplate(
                PickPromiseTemplate(item.ReminderType, settings),
                item.Balance, item.StudentName, item.ClassId, item.PromiseDate, school, item.PromisedAmount);

        return consolidated;
    }
```

- [ ] **Step 2: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build6.binlog 2>&1 | tee notes/IXtreme_sms_build6.log`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_sms_build6.log
git commit -m "feat(fees-sms): consolidate promise reminders one-per-guardian-per-type"
```

---

## Task 7: Service — balance-reminder preview + cooldown query

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Add the cooldown lookup**

After `LogGeneralReminderSent` (added in Task 5), add:

```csharp
    private HashSet<string> GetGuardiansInGeneralCooldown(int cooldownDays)
    {
        var set = new HashSet<string>(StringComparer.Ordinal);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            @"SELECT DISTINCT GuardianKey FROM tbl_SmsReminderLog
              WHERE ReminderType = 'General' AND GuardianKey IS NOT NULL
                AND SentAt >= @cutoff", conn);
        cmd.Parameters.Add("@cutoff", SqlDbType.DateTime).Value = DateTime.Today.AddDays(-cooldownDays);
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            if (!rdr.IsDBNull(0)) set.Add(rdr.GetString(0));
        return set;
    }
```

- [ ] **Step 2: Add `GetBalanceRemindersPreview`**

Add this public method just after `GetRemindersPreview`:

```csharp
    public List<ReminderItem> GetBalanceRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        string template = !string.IsNullOrWhiteSpace(settings.SmsTemplateGeneral)
            ? settings.SmsTemplateGeneral : DefaultGeneral;
        var today = DateTime.Today;

        var rows   = GetGuardianWorklist("", 0, settings);
        var cooled = GetGuardiansInGeneralCooldown(settings.GeneralReminderCooldownDays);

        var items = new List<ReminderItem>();
        foreach (var g in rows)
        {
            bool hasActivePromise = g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date >= today;
            if (!SmsReminderLogic.IsBalanceReminderEligible(g.Tier, g.TotalBalance, hasActivePromise)) continue;
            if (cooled.Contains(g.GuardianContact)) continue;

            string phone = SmsReminderLogic.NormalizePhone(g.GuardianContact)
                        ?? SmsReminderLogic.NormalizePhone(g.Contact2);
            if (phone == null) continue;   // unreachable — no callable number

            string names   = string.Join(", ", g.Students.Select(s => s.FullName));
            string classes = string.Join(", ", g.Students.Select(s => s.ClassId)
                                 .Where(c => !string.IsNullOrWhiteSpace(c)).Distinct());
            string msg = ApplySmsTemplate(template, g.TotalBalance, names, classes, today, school, 0m);

            items.Add(new ReminderItem
            {
                GuardianKey    = g.GuardianContact,
                Phone          = phone,
                StudentName    = names,
                ClassId        = classes,
                Balance        = g.TotalBalance,
                PromisedAmount = 0m,
                PromiseDate    = today,
                ReminderType   = "General",
                Message        = msg,
                Components     = new List<ReminderComponent>(),
            });
        }
        return items;
    }
```

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build7.binlog 2>&1 | tee notes/IXtreme_sms_build7.log`
Expected: Build succeeded.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_sms_build7.log
git commit -m "feat(fees-sms): balance-reminder preview for at-risk non-promisers with cooldown"
```

---

## Task 8: Gateway hardening — URL-encode + phone normalize

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeeSmsHelper.cs`

- [ ] **Step 1: Normalize the number and encode the request**

In `TrySend`, replace the block that builds `baseUrl` + `requestUri` (currently lines ~43-51):

```csharp
        string baseUrl = string.IsNullOrEmpty(url) || !url.StartsWith("http")
            ? "https://www.egosms.co/api/v1/plain/?"
            : (url.EndsWith("?") ? url : url + "?");

        string requestUri = $"{baseUrl}number={phone}" +
                            $"&message={message}" +
                            $"&username={username}" +
                            $"&password={password}" +
                            $"&sender={sender}";
```

with:

```csharp
        string baseUrl = string.IsNullOrEmpty(url) || !url.StartsWith("http")
            ? "https://www.egosms.co/api/v1/plain/?"
            : (url.EndsWith("?") ? url : url + "?");

        // Normalize the recipient to a Ugandan MSISDN; skip invalid numbers before hitting the gateway.
        string normalized = SmsReminderLogic.NormalizePhone(phone);
        if (normalized == null)
        {
            errorMessage = $"Invalid phone number: {phone}";
            return false;
        }

        // URL-encode every value so '&', '#', '=', '+' in names/school/message can't corrupt the query.
        string requestUri = $"{baseUrl}number={Uri.EscapeDataString(normalized)}" +
                            $"&message={Uri.EscapeDataString(message ?? string.Empty)}" +
                            $"&username={Uri.EscapeDataString(username)}" +
                            $"&password={Uri.EscapeDataString(password)}" +
                            $"&sender={Uri.EscapeDataString(sender ?? string.Empty)}";
```

(`FeeSmsHelper` already `using System;`, so `Uri` resolves; `SmsReminderLogic` is in the same `I_Xtreme.ExtremeClasses` namespace.)

- [ ] **Step 2: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build8.binlog 2>&1 | tee notes/IXtreme_sms_build8.log`
Expected: Build succeeded.

- [ ] **Step 3: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeeSmsHelper.cs notes/IXtreme_sms_build8.log
git commit -m "fix(fees-sms): URL-encode gateway params and normalize Uganda phone numbers"
```

---

## Task 9: Settings dialog — cooldown, general template, relabel pre-due

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs`

- [ ] **Step 1: Add fields and a `DefaultGeneral` constant**

In the field declarations (near `private SpinEdit spnCollectionGoal, …;`), add:

```csharp
    private SpinEdit spnGeneralCooldown;
    private MemoEdit memoGeneral;
```

Near the other `Default*` template constants (`Default2Day`, `DefaultDayOf`, `DefaultOverdue`), add:

```csharp
    private const string DefaultGeneral = "Dear Parent, {names} ({class}) has an outstanding balance of UGX {balance}. Please pay or contact the bursar to arrange a payment plan. - {school}";
```

- [ ] **Step 2: Load the new values in the constructor**

After the line `spnPromiseResurface.Value = s.PromiseResurfaceDays;`, add:

```csharp
        spnGeneralCooldown.Value = s.GeneralReminderCooldownDays;
        memoGeneral.Text = !string.IsNullOrWhiteSpace(s.SmsTemplateGeneral) ? s.SmsTemplateGeneral : DefaultGeneral;
```

- [ ] **Step 3: Relabel the pre-due template row**

Find the pre-due template label (text begins "2-day reminder template…") and change its `Text` to:

```csharp
            Text = "Pre-due reminder template — sent 3 days before ({promised_amount},{balance},{names},{class},{date},{school}):",
```

- [ ] **Step 4: Add the cooldown row and re-flow the template block**

The numeric rows currently end with `spnPromiseResurface` at y≈462, and the template block starts at y≈496 (`lbl2Day`). Insert the cooldown row at y=494 and push the template block + buttons + form height down. Replace the template/button Location Y-values as follows (find each control by its existing text/name and set its `Location`/`ClientSize`):

```csharp
        // New: General reminder cooldown (numeric row)
        var lblCooldown = new LabelControl
            { Text = "Balance reminder cooldown (days between sends to a guardian):",
              Location = new System.Drawing.Point(12, 494) };
        this.spnGeneralCooldown = new SpinEdit
            { Location = new System.Drawing.Point(340, 490), Width = 80 };
        this.spnGeneralCooldown.Properties.IsFloatValue = false;
        this.spnGeneralCooldown.Properties.MinValue     = 1;
        this.spnGeneralCooldown.Properties.MaxValue     = 365;
```

Set these Y values on the existing/new template controls (X and Sizes unchanged):
- `lbl2Day` Y=528 ; `memo2Day` Location Y=546
- `lblDayOf` Y=614 ; `memoDayOf` Location Y=632
- `lblOverdue` Y=700 ; `memoOverdue` Location Y=718
- NEW general template:
```csharp
        var lblGeneral = new LabelControl
            { Text = "Balance reminder template ({balance},{names},{class},{school}):",
              Location = new System.Drawing.Point(12, 786), AutoSize = true };
        this.memoGeneral = new MemoEdit { Location = new System.Drawing.Point(12, 804), Size = new System.Drawing.Size(580, 60) };
        this.memoGeneral.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
```
- `btnResetTemplates` Y=878 ; `btnOK` Y=878 ; `btnCancel` Y=878 (keep their X)
- `this.ClientSize = new System.Drawing.Size(608, 910);`

- [ ] **Step 5: Save the new values + add controls + reset-templates**

In the `btnOK.Click` save initializer (`new FeesFollowUpSettings { … }`), after `PromiseResurfaceDays = (int)spnPromiseResurface.Value,` add:

```csharp
                GeneralReminderCooldownDays = (int)spnGeneralCooldown.Value,
                SmsTemplateGeneral          = memoGeneral.Text.Trim(),
```

In the `btnResetTemplates.Click` handler, after the existing `memoOverdue.Text = DefaultOverdue;`, add:

```csharp
            memoGeneral.Text = DefaultGeneral;
```

In the `this.Controls.AddRange(new Control[] { … })`, add (e.g. after the resurface row entry and before the template memos):

```csharp
            lblCooldown, spnGeneralCooldown,
```

and after `lblOverdue, memoOverdue,`:

```csharp
            lblGeneral, memoGeneral,
```

- [ ] **Step 6: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build9.binlog 2>&1 | tee notes/IXtreme_sms_build9.log`
Expected: Build succeeded.

- [ ] **Step 7: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs notes/IXtreme_sms_build9.log
git commit -m "feat(fees-sms): settings rows for cooldown + balance template; relabel pre-due"
```

---

## Task 10: Preview dialog — balance mode + send confirmation

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgSendRemindersPreview.cs`

- [ ] **Step 1: Add a mode and route the data source**

Replace the constructor (23-27) with:

```csharp
    public enum ReminderMode { Promise, Balance }
    private readonly ReminderMode _mode;

    public dlgSendRemindersPreview(ReminderMode mode = ReminderMode.Promise)
    {
        _mode = mode;
        InitializeComponent();
        LoadPreview();
    }
```

In `InitializeComponent`, change the title line `this.Text = "Send Reminders — Preview";` to:

```csharp
        this.Text = _mode == ReminderMode.Balance
            ? "Send Balance Reminders — Preview"
            : "Send Reminders — Preview";
```

In `LoadPreview`, change `_items = _service.GetRemindersPreview();` to:

```csharp
            _items = _mode == ReminderMode.Balance
                ? _service.GetBalanceRemindersPreview()
                : _service.GetRemindersPreview();
```

- [ ] **Step 2: Hide promise-only columns in balance mode**

In `ConfigureColumns`, after the existing `AddCol(...)`/`AddNumCol(...)` calls that add the columns, wrap the promise-only columns so they are skipped in balance mode. Replace the column-adding block:

```csharp
        AddCol("StudentName",   "Student",        160);
        AddCol("ClassId",       "Class",            50);
        AddCol("Phone",         "Phone",           120);
        AddCol("ReminderType",  "Reminder",        100);
        AddDateCol("PromiseDate", "Promise Date",  100);
        AddNumCol("PromisedAmount", "Promised (UGX)", 110);
        AddNumCol("Balance",    "Balance (UGX)",   110);
        AddCol("Message",       "Message",         360);
```

with:

```csharp
        AddCol("StudentName",   _mode == ReminderMode.Balance ? "Students" : "Student", 160);
        AddCol("ClassId",       "Class",            50);
        AddCol("Phone",         "Phone",           120);
        if (_mode == ReminderMode.Promise)
        {
            AddCol("ReminderType",  "Reminder",        100);
            AddDateCol("PromiseDate", "Promise Date",  100);
            AddNumCol("PromisedAmount", "Promised (UGX)", 110);
        }
        AddNumCol("Balance",    "Balance (UGX)",   110);
        AddCol("Message",       "Message",         360);
```

- [ ] **Step 3: Add a send confirmation**

In `BtnSend_Click`, after the empty-list guard and before `_btnSend.Enabled = false;`, add:

```csharp
        int guardianCount = _items.Select(i => i.GuardianKey).Distinct().Count();
        if (XtraMessageBox.Show(
                $"Send {_items.Count} SMS to {guardianCount} guardian(s)? This uses SMS credits.",
                "Send Reminders", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;
```

- [ ] **Step 4: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build10.binlog 2>&1 | tee notes/IXtreme_sms_build10.log`
Expected: Build succeeded.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/dlgSendRemindersPreview.cs notes/IXtreme_sms_build10.log
git commit -m "feat(fees-sms): balance mode + send confirmation in reminder preview dialog"
```

---

## Task 11: Dashboard action + ribbon button

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`
- Modify: `decompiled/IXtreme/I_Xtreme/MainForm.cs`

- [ ] **Step 1: Add `SendBalanceReminders()` to the dashboard control**

In `usrFeesFollowUp.cs`, after the existing `SendReminders()` method, add:

```csharp
    public void SendBalanceReminders()
    {
        try
        {
            using var dlg = new I_Xtreme.DialogForms.dlgSendRemindersPreview(
                I_Xtreme.DialogForms.dlgSendRemindersPreview.ReminderMode.Balance);
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                LoadDashboard();
        }
        catch (Exception ex)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(
                $"Could not open balance reminders.\n\n{ex.Message}",
                "Send Balance Reminders", System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }
```

- [ ] **Step 2: Declare the ribbon button field**

In `MainForm.cs`, find `private DevExpress.XtraBars.BarButtonItem bbiSendReminders;` (≈553) and add after it:

```csharp
	private DevExpress.XtraBars.BarButtonItem bbiSendBalanceReminders;
```

- [ ] **Step 3: Construct and wire the button**

In `MainForm.cs`, after the `bbiSendReminders.ItemClick += …` line (≈24827), add:

```csharp
			this.bbiSendBalanceReminders = new DevExpress.XtraBars.BarButtonItem();
			this.bbiSendBalanceReminders.Name    = "bbiSendBalanceReminders";
			this.bbiSendBalanceReminders.Caption = "Send Balance Reminders";
			this.bbiSendBalanceReminders.ImageOptions.Image      = I_Xtreme.Properties.Resources.FeesTracking;
			this.bbiSendBalanceReminders.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.FeesTracking;
			this.bbiSendBalanceReminders.ItemClick += (s, e) => _usrFeesFollowUp?.SendBalanceReminders();
```

- [ ] **Step 4: Add it to the Settings group and register it with the ribbon**

After `this.ribbonPageGroupFeesSettings.ItemLinks.Add(this.bbiSendReminders);` (≈24845), add:

```csharp
			this.ribbonPageGroupFeesSettings.ItemLinks.Add(this.bbiSendBalanceReminders);
```

In the `this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { … })` list (≈24904-24905), add `bbiSendBalanceReminders` to the array (e.g. right after `bbiSendReminders`).

- [ ] **Step 5: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly /bl:notes/IXtreme_sms_build11.binlog 2>&1 | tee notes/IXtreme_sms_build11.log`
Expected: Build succeeded.

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs decompiled/IXtreme/I_Xtreme/MainForm.cs notes/IXtreme_sms_build11.log
git commit -m "feat(fees-sms): Send Balance Reminders ribbon action"
```

---

## Task 12: Full verification + glossary + migration note

**Files:**
- Modify: `CLAUDE.md` (Fees Follow-up Glossary)
- Modify: `docs/superpowers/plans/2026-06-08-fees-followup-urgency-migration.sql` (add the two new settings keys)

- [ ] **Step 1: Run the full unit suite**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: all tests PASS (FeesUrgency + SmsReminderLogic).

- [ ] **Step 2: Clean build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -t:Rebuild -clp:ErrorsOnly /bl:notes/IXtreme_sms_final.binlog 2>&1 | tee notes/IXtreme_sms_final.log`
Expected: Build succeeded, 0 errors.

- [ ] **Step 3: Seed the new settings keys in the migration**

In `docs/superpowers/plans/2026-06-08-fees-followup-urgency-migration.sql`, after the `PromiseResurfaceDays` insert guard, add:

```sql
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'GeneralReminderCooldownDays')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('GeneralReminderCooldownDays', '7');
-- SmsTemplateGeneral is left unset so the app falls back to the built-in DefaultGeneral text.
```

- [ ] **Step 4: Update the glossary**

In `CLAUDE.md`, in the Fees Follow-up Glossary "Settings" section, add:

```markdown
**General Reminder Cooldown Days** — minimum days between balance reminders to the same
guardian, so running "Send Balance Reminders" daily texts each at-risk guardian at most once
per window. Default 7. Logged as `ReminderType = 'General'` in `tbl_SmsReminderLog`
(cooldown measured against `SentAt`).

**Balance Reminder** — an SMS to an at-risk guardian (tier Critical or Broken Promise, owing,
no active promise) who has *not* made a promise. Separate "Send Balance Reminders" ribbon
action; renders `SmsTemplateGeneral` (falls back to the built-in general template). Distinct
from promise reminders (3-day / day-of / overdue), which are anchored to a promise date.

**Reminder consolidation** — promise reminders are sent one SMS per guardian per
reminder-type occurrence (e.g. three children all "due today" → one message with the family
total), while per-student de-dup logging is preserved.
```

- [ ] **Step 5: Commit**

```bash
git add CLAUDE.md docs/superpowers/plans/2026-06-08-fees-followup-urgency-migration.sql notes/IXtreme_sms_final.log
git commit -m "docs(fees-sms): glossary + migration seed for balance reminders"
```

- [ ] **Step 6: Finish the branch**

Use the superpowers:finishing-a-development-branch skill to choose merge/PR/cleanup, then redeploy to `smoke_test/` and verify the two reminder dialogs open.

---

## Self-review notes (coverage map spec → tasks)

- §1 settings + ReminderType "General" → Tasks 1, 4, 12
- §2 SmsReminderLogic (normalize/format/eligible/cooldown/consolidate) → Tasks 2, 3
- §3 promise consolidation + per-student de-dup integrity → Tasks 1 (Components), 5 (logging), 6 (wire)
- §4 gateway hardening (URL-encode + phone normalize) → Task 8
- §5 Send Balance Reminders action (target/cooldown/phone/render/log) → Tasks 7, 10, 11
- §6 amount-blank (Task 4), Overdue miscount (Tasks 1, 5), template naming (Task 9), send confirmation (Task 10)
- Testing → Tasks 2, 3, 12
```
