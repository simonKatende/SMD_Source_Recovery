# Fees Follow-up Deadline-Aware Urgency Overhaul — Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Make the Fees Follow-up worklist deadline-aware — escalate partial-payers toward a 98% collection target, rank every list by a continuous money-at-risk UrgencyScore, and stop the Critical tier from flooding.

**Architecture:** Extract the tier/shortfall/score math into one dependency-free static class (`FeesUrgency`) in `I_Xtreme.ExtremeClasses`, depending only on `System` and the `I_Xtreme.Models` POCOs. `FeesFollowUpService` calls it; a new net8.0 xUnit project unit-tests it by compiling the same source files. DB plumbing, settings dialog, and WinForms changes are verified by `dotnet build`.

**Tech Stack:** C# 11, net472 WinForms (IXtreme), DevExpress v23.2, SQL Server. Tests: net8.0 + xUnit (source-linked, no DevExpress/SqlClient dependency).

**Spec:** `docs/superpowers/specs/2026-06-08-fees-followup-urgency-overhaul-design.md`

**Source anchors (verified before writing this plan):**
- `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`
  - `GetSettings` 75-139, `SaveSettings` 141-168
  - `GetGuardianWorklist` 263-524 (tier loop 491-509, CallRequired override 511-514, sort 516-522)
  - `GetDailyWorklist` 540-568
  - `GetStudentWorklist` 570-606
  - `GetDashboardData` 608-680, `GetDashboardTotals` 194-261
  - `ComputeGuardianTier` 917-950, `FailedOutcomes` 1037-1044, legacy `ComputeTier` 1046-1063
  - CallRequired CTE 384-390
- `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` (`FeesFollowUpSettings` 7-42, `GuardianWorklistRow` 69-110, `DashboardData` 149-175)
- `decompiled/IXtreme/I_Xtreme.Models/WorklistRow.cs` (`PriorityTier` 5)
- `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs`
- `decompiled/IXtreme/I_Xtreme.NavigationForms/usrDailyWorklist.cs`, `usrGuardianWorklist.cs`

**Conventions:** branch `feat/fees-followup-urgency-overhaul` (already created). Build logs go to `notes/` (`notes\IXtreme_buildN.log`). Conventional Commits. Do not touch `backup/` or `smoke_test/`.

---

## Task 1: Scaffold the unit-test project

**Files:**
- Create: `tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
- Create: `tests/FeesFollowUp.Tests/SmokeTests.cs`

- [ ] **Step 1: Create the test project file**

Create `tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <LangVersion>11.0</LangVersion>
    <Nullable>disable</Nullable>
    <ImplicitUsings>disable</ImplicitUsings>
    <IsPackable>false</IsPackable>
    <AssemblyName>FeesFollowUp.Tests</AssemblyName>
    <RootNamespace>FeesFollowUp.Tests</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="xunit" Version="2.6.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.4">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

  <!-- Source-link the dependency-free POCOs + the pure logic under test.
       These files use only System + I_Xtreme.Models types, so they compile
       here without DevExpress or System.Data.SqlClient. -->
  <ItemGroup>
    <Compile Include="..\..\decompiled\IXtreme\I_Xtreme.Models\WorklistRow.cs"          Link="Models\WorklistRow.cs" />
    <Compile Include="..\..\decompiled\IXtreme\I_Xtreme.Models\GuardianWorklistRow.cs"  Link="Models\GuardianWorklistRow.cs" />
    <Compile Include="..\..\decompiled\IXtreme\I_Xtreme.Models\FeesContactLog.cs"       Link="Models\FeesContactLog.cs" />
    <Compile Include="..\..\decompiled\IXtreme\I_Xtreme.ExtremeClasses\FeesUrgency.cs"  Link="Logic\FeesUrgency.cs" />
  </ItemGroup>

</Project>
```

- [ ] **Step 2: Create a stub for the file under test so the project compiles**

Create `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs`:

```csharp
using System;
using System.Collections.Generic;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>
/// Pure, dependency-free fees-follow-up urgency math. Depends only on System
/// and I_Xtreme.Models POCOs so it can be unit-tested without DevExpress/SQL.
/// </summary>
public static class FeesUrgency
{
}
```

- [ ] **Step 3: Write a smoke test**

Create `tests/FeesFollowUp.Tests/SmokeTests.cs`:

```csharp
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
        Assert.Equal(PriorityTier.Current, default(PriorityTier) == PriorityTier.Critical
            ? PriorityTier.Current : PriorityTier.Current);
    }
}
```

- [ ] **Step 4: Run the test to verify the harness compiles and runs**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: build succeeds, 1 test passes.

- [ ] **Step 5: Commit**

```bash
git add tests/FeesFollowUp.Tests/ decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs
git commit -m "test: scaffold source-linked FeesUrgency unit-test project"
```

---

## Task 2: Required-payment line + shortfall (F1)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs`
- Create: `tests/FeesFollowUp.Tests/RequiredLineTests.cs`

- [ ] **Step 1: Write failing tests**

Create `tests/FeesFollowUp.Tests/RequiredLineTests.cs`:

```csharp
using System;
using I_Xtreme.ExtremeClasses;
using Xunit;

namespace FeesFollowUp.Tests;

public class RequiredLineTests
{
    private static readonly DateTime Start = new DateTime(2026, 2, 1);
    private static readonly DateTime End   = new DateTime(2026, 4, 30); // 88 days

    [Fact]
    public void TermProgress_is_zero_when_dates_missing()
    {
        Assert.Equal(0.0, FeesUrgency.TermProgress(new DateTime(2026, 3, 1), null, End));
        Assert.Equal(0.0, FeesUrgency.TermProgress(new DateTime(2026, 3, 1), Start, null));
    }

    [Fact]
    public void TermProgress_clamps_to_unit_interval()
    {
        Assert.Equal(0.0, FeesUrgency.TermProgress(Start.AddDays(-5), Start, End));
        Assert.Equal(1.0, FeesUrgency.TermProgress(End.AddDays(5), Start, End));
    }

    [Fact]
    public void TermProgress_is_about_half_at_midterm()
    {
        double p = FeesUrgency.TermProgress(Start.AddDays(44), Start, End);
        Assert.InRange(p, 0.49, 0.51);
    }

    [Fact]
    public void RequiredPct_scales_goal_by_progress()
    {
        Assert.Equal(0.0,  FeesUrgency.RequiredPct(0.98, 0.0));
        Assert.Equal(98.0, FeesUrgency.RequiredPct(0.98, 1.0), 3);
        Assert.Equal(49.0, FeesUrgency.RequiredPct(0.98, 0.5), 3);
    }

    [Fact]
    public void Shortfall_is_required_minus_paid_in_points()
    {
        Assert.Equal(30.0,  FeesUrgency.Shortfall(80.0, 50m), 3);
        Assert.Equal(-5.0,  FeesUrgency.Shortfall(80.0, 85m), 3); // ahead of pace
    }
}
```

- [ ] **Step 2: Run tests to verify they fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `FeesUrgency` has no `TermProgress`/`RequiredPct`/`Shortfall`.

- [ ] **Step 3: Implement the functions**

In `FeesUrgency.cs`, replace the empty class body with:

```csharp
    /// <summary>Fraction of the term elapsed today, clamped to [0,1]; 0 if dates unset.</summary>
    public static double TermProgress(DateTime today, DateTime? termStart, DateTime? termEnd)
    {
        if (!termStart.HasValue || !termEnd.HasValue) return 0.0;
        double totalDays = (termEnd.Value - termStart.Value).TotalDays;
        if (totalDays <= 0) return 0.0;
        double elapsed = (today - termStart.Value).TotalDays;
        return Math.Max(0.0, Math.Min(1.0, elapsed / totalDays));
    }

    /// <summary>The required-paid percentage line for today: goal * progress, as 0..goal*100.</summary>
    public static double RequiredPct(double collectionGoal, double termProgress)
        => collectionGoal * termProgress * 100.0;

    /// <summary>Percentage points a guardian is behind the required line (&lt;= 0 means on/ahead of pace).</summary>
    public static double Shortfall(double requiredPct, decimal paymentPercent)
        => requiredPct - (double)paymentPercent;
```

- [ ] **Step 4: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS (all RequiredLineTests + smoke).

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs tests/FeesFollowUp.Tests/RequiredLineTests.cs
git commit -m "feat(fees-crm): add deadline-aware required-payment line and shortfall (F1)"
```

---

## Task 3: Shortfall-based tier rule (F2)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs`
- Create: `tests/FeesFollowUp.Tests/TierTests.cs`

- [ ] **Step 1: Write failing tests**

Create `tests/FeesFollowUp.Tests/TierTests.cs`:

```csharp
using System;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using Xunit;

namespace FeesFollowUp.Tests;

public class TierTests
{
    private static readonly DateTime Today = new DateTime(2026, 4, 1);

    private static GuardianWorklistRow Row(
        decimal paymentPercent, decimal balance = 1_000_000m,
        DateTime? lastContact = null, ContactOutcome? lastOutcome = null,
        DateTime? promiseDate = null, decimal? promiseAmount = null,
        decimal paymentsSincePromise = 0m, DateTime? firstContact = null)
        => new GuardianWorklistRow
        {
            PaymentPercent = paymentPercent,
            TotalBalance = balance,
            LastContactDate = lastContact,
            LastOutcome = lastOutcome,
            LatestPromiseDate = promiseDate,
            LatestPromiseAmount = promiseAmount,
            PaymentsSinceLatestPromise = paymentsSincePromise,
            FirstContactDate = firstContact,
        };

    [Fact]
    public void Critical_when_shortfall_at_or_above_threshold_and_no_active_promise()
    {
        var g = Row(paymentPercent: 40m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 30.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Critical, tier);
    }

    [Fact]
    public void Not_critical_when_active_promise_even_if_behind()
    {
        var g = Row(paymentPercent: 40m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Promised);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 30.0, criticalShortfallPoints: 25.0, hasActivePromise: true,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.NotEqual(PriorityTier.Critical, tier);
    }

    [Fact]
    public void Midterm_midpayer_is_not_critical_below_threshold()
    {
        // F2: 60% paid, required ~49% -> shortfall negative -> not flooded into Critical
        var g = Row(paymentPercent: 60m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: -11.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Current, tier);
    }

    [Fact]
    public void No_critical_when_term_dates_unset()
    {
        var g = Row(paymentPercent: 0m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: false,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.NotEqual(PriorityTier.Critical, tier);
    }

    [Fact]
    public void BrokenPromise_when_promise_passed_and_underpaid()
    {
        var g = Row(paymentPercent: 50m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted,
            promiseDate: Today.AddDays(-3), promiseAmount: 500_000m, paymentsSincePromise: 100_000m);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.BrokenPromise, tier);
    }

    [Fact]
    public void Stale_when_no_contact_logged()
    {
        var g = Row(paymentPercent: 50m);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Stale, tier);
    }

    [Fact]
    public void Stale_when_last_outcome_failed()
    {
        var g = Row(paymentPercent: 50m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.NoAnswer);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Stale, tier);
    }

    [Fact]
    public void NoProgress_escalates_to_critical_after_weeks_with_low_payment()
    {
        var g = Row(paymentPercent: 10m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted,
            firstContact: Today.AddDays(-40));
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: 0.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Critical, tier);
    }

    [Fact]
    public void Current_when_on_pace_and_recently_contacted()
    {
        var g = Row(paymentPercent: 90m, lastContact: Today.AddDays(-1), lastOutcome: ContactOutcome.Contacted);
        var tier = FeesUrgency.ComputeTier(g, Today, hasTermDates: true,
            shortfall: -5.0, criticalShortfallPoints: 25.0, hasActivePromise: false,
            stalenessDays: 7, noProgressWeeks: 4, noProgressThreshold: 30.0);
        Assert.Equal(PriorityTier.Current, tier);
    }
}
```

- [ ] **Step 2: Run tests to verify they fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `ComputeTier` not defined.

- [ ] **Step 3: Implement `ComputeTier` + `FailedOutcomes`**

Append to the `FeesUrgency` class body in `FeesUrgency.cs`:

```csharp
    /// <summary>Outcomes that, as the most-recent contact result, mark a guardian Stale (needs retry).</summary>
    public static readonly HashSet<ContactOutcome> FailedOutcomes = new HashSet<ContactOutcome>
    {
        ContactOutcome.NoAnswer,
        ContactOutcome.ContactUnavailable,
        ContactOutcome.ContactOff,
        ContactOutcome.Refused,
    };

    /// <summary>
    /// Assigns a guardian's priority tier. Critical is driven by a single deadline-aware
    /// shortfall rule (F2); the no-progress, broken-promise, and stale rules are retained.
    /// Returns Stale/Current rather than Critical when term dates are unset.
    /// </summary>
    public static PriorityTier ComputeTier(
        GuardianWorklistRow g, DateTime today, bool hasTermDates,
        double shortfall, double criticalShortfallPoints, bool hasActivePromise,
        int stalenessDays, int noProgressWeeks, double noProgressThreshold)
    {
        // F2: single shortfall-based Critical rule (replaces pacing-gap + flat-phase rules).
        if (hasTermDates && shortfall >= criticalShortfallPoints && !hasActivePromise)
            return PriorityTier.Critical;

        // No-progress escalation (retained): long-followed-up and still barely paying.
        if (noProgressWeeks > 0 && g.FirstContactDate.HasValue)
        {
            double weeksFollowedUp = (today - g.FirstContactDate.Value.Date).TotalDays / 7.0;
            if (weeksFollowedUp > noProgressWeeks && (double)g.PaymentPercent < noProgressThreshold)
                return PriorityTier.Critical;
        }

        // Broken promise (retained, 5% tolerance for rounding).
        if (g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date < today)
        {
            decimal promised = g.LatestPromiseAmount ?? (g.TotalBalance + g.PaymentsSinceLatestPromise);
            if (g.PaymentsSinceLatestPromise < promised * 0.95m)
                return PriorityTier.BrokenPromise;
        }

        // Stale (retained): no recent contact, or last contact was a failed outcome.
        if (!g.LastContactDate.HasValue
            || (today - g.LastContactDate.Value.Date).TotalDays > stalenessDays
            || (g.LastOutcome.HasValue && FailedOutcomes.Contains(g.LastOutcome.Value)))
            return PriorityTier.Stale;

        return PriorityTier.Current;
    }
```

- [ ] **Step 4: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS (all TierTests + prior).

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs tests/FeesFollowUp.Tests/TierTests.cs
git commit -m "feat(fees-crm): shortfall-based single Critical tier rule (F2)"
```

---

## Task 4: UrgencyScore (F3/F4/F5)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs`
- Create: `tests/FeesFollowUp.Tests/UrgencyScoreTests.cs`

- [ ] **Step 1: Write failing tests**

Create `tests/FeesFollowUp.Tests/UrgencyScoreTests.cs`:

```csharp
using I_Xtreme.ExtremeClasses;
using Xunit;

namespace FeesFollowUp.Tests;

public class UrgencyScoreTests
{
    [Fact]
    public void Base_score_is_balance_when_no_modifiers()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(1_000_000.0, s, 0);
    }

    [Fact]
    public void Shortfall_increases_score_up_to_about_double_at_50_points()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 50.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(2_000_000.0, s, 0);
    }

    [Fact]
    public void Negative_shortfall_does_not_reduce_below_base()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: -40.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(1_000_000.0, s, 0);
    }

    [Fact]
    public void BrokenPromise_multiplies_by_one_point_five()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: true, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.Equal(1_500_000.0, s, 0);
    }

    [Fact]
    public void CoveringActivePromise_de_emphasises_without_zeroing()
    {
        double s = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: true);
        Assert.Equal(400_000.0, s, 0);
    }

    [Fact]
    public void Worked_example_genuine_risk_outranks_sticky_callrequired()
    {
        // F3/F4: 95%-paid, 100k balance, CallRequired vs 2M balance, 50% paid, behind.
        double sticky = FeesUrgency.UrgencyScore(100_000m, shortfall: -10.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: true,
            hasCoveringActivePromise: false);                 // 100k * 1.0 * 1.4 = 140k
        double genuine = FeesUrgency.UrgencyScore(2_000_000m, shortfall: 30.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);                 // 2M * 1.6 = 3.2M
        Assert.True(genuine > sticky);
    }

    [Fact]
    public void Worked_example_broken_promise_outranks_equal_balance_on_pace()
    {
        // F5
        double broken = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: true, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        double onPace = FeesUrgency.UrgencyScore(1_000_000m, shortfall: 0.0,
            brokenPromise: false, failedLastOutcome: false, callRequired: false,
            hasCoveringActivePromise: false);
        Assert.True(broken > onPace);
    }
}
```

- [ ] **Step 2: Run tests to verify they fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `UrgencyScore` not defined.

- [ ] **Step 3: Implement `UrgencyScore`**

Append to the `FeesUrgency` class body in `FeesUrgency.cs`:

```csharp
    /// <summary>
    /// Master ranking signal: money still owed, amplified by how far behind the required
    /// line the guardian is and by behavioral flags. A covering active promise de-emphasises
    /// (x0.4) without zeroing so the remainder is never lost. Higher = chase sooner.
    /// </summary>
    public static double UrgencyScore(
        decimal totalBalance, double shortfall, bool brokenPromise,
        bool failedLastOutcome, bool callRequired, bool hasCoveringActivePromise)
    {
        double baseAtRisk = (double)totalBalance;
        double shortfallX = 1.0 + Math.Max(0.0, shortfall) / 50.0;
        double behaviorX = 1.0;
        if (brokenPromise)            behaviorX *= 1.5;
        if (failedLastOutcome)        behaviorX *= 1.3;
        if (callRequired)             behaviorX *= 1.4;
        if (hasCoveringActivePromise) behaviorX *= 0.4;
        return baseAtRisk * shortfallX * behaviorX;
    }
```

- [ ] **Step 4: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesUrgency.cs tests/FeesFollowUp.Tests/UrgencyScoreTests.cs
git commit -m "feat(fees-crm): money-at-risk UrgencyScore with behavior modifiers (F3/F4/F5)"
```

---

## Task 5: Model fields — UrgencyScore + IsUnreachable + ProjectedCollectionRate (F8/F9)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs`
- Create: `tests/FeesFollowUp.Tests/ModelTests.cs`

- [ ] **Step 1: Write failing tests**

Create `tests/FeesFollowUp.Tests/ModelTests.cs`:

```csharp
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
}
```

- [ ] **Step 2: Run tests to verify they fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `IsUnreachable`, `UrgencyScore`, `DashboardData.TermProgress`/`ProjectedCollectionRate` not defined.

- [ ] **Step 3: Add the fields to `GuardianWorklistRow`**

In `GuardianWorklistRow.cs`, after the `PacingGap`/`Tier` lines (currently 92-93), add:

```csharp
    public double UrgencyScore { get; set; }   // master ranking signal (FeesUrgency.UrgencyScore)

    // F9: true when the guardian has no callable phone (NOCONTACT key or blank contact).
    public bool IsUnreachable =>
        string.IsNullOrWhiteSpace(GuardianContact)
        || GuardianContact.StartsWith("NOCONTACT-", System.StringComparison.Ordinal);
```

- [ ] **Step 4: Add the on-track fields to `DashboardData`**

In `GuardianWorklistRow.cs`, inside `DashboardData`, after the existing `CollectionRate` line (currently 155), add:

```csharp
    public bool    TermDatesConfigured        { get; set; }
    public double  TermProgress               { get; set; }   // 0..1, clamped
    public decimal CollectionGoalPercent      { get; set; }   // e.g. 98
    public double  RequiredRateToday          => CollectionGoalPercent == 0 || TermProgress == 0
                                                    ? 0.0
                                                    : (double)CollectionGoalPercent * TermProgress;
    public double  ProjectedCollectionRate    => TermProgress <= 0
                                                    ? 0.0
                                                    : System.Math.Min(100.0, (double)CollectionRate / TermProgress);
    public decimal AmountBehindPace           => TermProgress <= 0
                                                    ? 0m
                                                    : System.Math.Max(0m,
                                                        (decimal)(RequiredRateToday / 100.0) * TotalPayable - TotalCollected);
```

- [ ] **Step 5: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS.

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs tests/FeesFollowUp.Tests/ModelTests.cs
git commit -m "feat(fees-crm): add UrgencyScore, IsUnreachable, and on-track dashboard fields (F8/F9)"
```

---

## Task 6: Settings — new keys, remove phase percents (F1/F2/F3/F6)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` (`FeesFollowUpSettings`)
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`GetSettings` 75-139, `SaveSettings` 141-168)

No new unit test (DB-backed); verified by build in Task 13. Keep changes mechanical.

- [ ] **Step 1: Update the settings record**

In `GuardianWorklistRow.cs`, in `FeesFollowUpSettings`, remove these two lines (currently 40-41):

```csharp
    public double FirstHalfMinPercent  { get; set; } = 50.0;
    public double SecondHalfMinPercent { get; set; } = 80.0;
```

And add, in their place:

```csharp
    // Deadline-aware overhaul (2026-06-08).
    public double CollectionGoal          { get; set; } = 0.98;  // fraction 0..1, term-end target
    public double CriticalShortfallPoints { get; set; } = 25.0;  // pts behind required line => Critical
    public int    CallRequiredWindowDays  { get; set; } = 14;    // Overdue SMS recency window
    public int    PromiseResurfaceDays    { get; set; } = 14;    // days before term end to stop hiding promises
```

- [ ] **Step 2: Update `GetSettings`**

In `FeesFollowUpService.cs`, in `GetSettings`, remove the two trailing block initializers for `FirstHalfMinPercent` (128-132) and `SecondHalfMinPercent` (133-137). Replace them with:

```csharp
            CollectionGoal =
                dict.TryGetValue("CollectionGoal", out var cg)
                && double.TryParse(cg, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double cgv)
                    ? cgv : 0.98,
            CriticalShortfallPoints =
                dict.TryGetValue("CriticalShortfallPoints", out var csp)
                && double.TryParse(csp, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double cspv)
                    ? cspv : 25.0,
            CallRequiredWindowDays =
                dict.TryGetValue("CallRequiredWindowDays", out var crw) && int.TryParse(crw, out int crwi)
                    ? crwi : 14,
            PromiseResurfaceDays =
                dict.TryGetValue("PromiseResurfaceDays", out var prd) && int.TryParse(prd, out int prdi)
                    ? prdi : 14,
```

- [ ] **Step 3: Update `SaveSettings`**

In `FeesFollowUpService.cs`, in `SaveSettings`, remove the two `Upsert` calls for `FirstHalfMinPercent` (164-165) and `SecondHalfMinPercent` (166-167). Replace them with:

```csharp
        Upsert(conn, "CollectionGoal",
            s.CollectionGoal.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "CriticalShortfallPoints",
            s.CriticalShortfallPoints.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "CallRequiredWindowDays", s.CallRequiredWindowDays.ToString());
        Upsert(conn, "PromiseResurfaceDays",   s.PromiseResurfaceDays.ToString());
```

- [ ] **Step 4: Verify the project still builds**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_settings.binlog 2>&1 | tee notes\IXtreme_build_settings.log`
Expected: Build succeeded (no CS errors about `FirstHalfMinPercent`/`SecondHalfMinPercent` remaining — Task 7 removes their last reader; if any reference remains the build will flag it, fix in Task 7).

Note: a reference to `FirstHalfMinPercent`/`SecondHalfMinPercent` still exists in `GetGuardianWorklist` (phase-target block 482-489) and `FollowUpSettings.cs`; those are removed in Tasks 7 and 11. If this build fails only on those references, that is expected — proceed; the final build gate is Task 13.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "feat(fees-crm): add CollectionGoal/shortfall/window settings, retire phase percents"
```

---

## Task 7: Wire FeesUrgency into GetGuardianWorklist (F1/F2/F4/F5)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`GetGuardianWorklist` 472-523, `ComputeGuardianTier` 917-950, `FailedOutcomes` 1037-1044)

- [ ] **Step 1: Replace the pacing/phase/tier block (current lines 472-509)**

In `GetGuardianWorklist`, replace this block:

```csharp
        // Compute pacing gap and tier
        double termProgress = 0.0;
        if (hasTermDates)
        {
            double totalDays   = (tEnd.Value - tStart.Value).TotalDays;
            double elapsedDays = (DateTime.Today - tStart.Value).TotalDays;
            termProgress = totalDays > 0 ? Math.Max(0.0, Math.Min(1.0, elapsedDays / totalDays)) : 0.0;
        }

        // Phase target for the payment-shortfall Critical rule (Task 2)
        double phaseTarget = 0.0;
        if (hasTermDates)
        {
            DateTime midterm = tStart.Value.AddDays((tEnd.Value - tStart.Value).TotalDays / 2.0);
            phaseTarget = DateTime.Today < midterm
                ? settings.FirstHalfMinPercent
                : settings.SecondHalfMinPercent;
        }

        var rows = new List<GuardianWorklistRow>(grouped.Values);
        foreach (var g in rows)
        {
            g.PaymentPercent = g.TotalBilled > 0
                ? Math.Round(g.TotalPaid / g.TotalBilled * 100m, 1) : 0m;
            double payProgress = g.TotalBilled > 0 ? (double)(g.TotalPaid / g.TotalBilled) : 0.0;
            g.PacingGap = hasTermDates ? termProgress - payProgress : 0.0;
            int effectiveStaleDays = g.TotalBalance >= settings.StaleHighBalanceAmount
                ? settings.StaleHighBalanceDays
                : g.TotalBalance >= settings.StaleMedBalanceAmount
                    ? settings.StaleMedBalanceDays
                    : settings.StaleThresholdDays;
            bool hasActivePromise = g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= DateTime.Today;
            g.Tier = ComputeGuardianTier(g, effectiveStaleDays,
                settings.CriticalPacingGapThreshold, hasTermDates,
                settings.NoProgressEscalationWeeks, settings.NoProgressPaymentThreshold,
                phaseTarget, hasActivePromise);
        }
```

with:

```csharp
        // Deadline-aware required-payment line (F1).
        DateTime today = DateTime.Today;
        double termProgress = FeesUrgency.TermProgress(today, tStart, tEnd);
        double requiredPct  = hasTermDates ? FeesUrgency.RequiredPct(settings.CollectionGoal, termProgress) : 0.0;

        var rows = new List<GuardianWorklistRow>(grouped.Values);
        foreach (var g in rows)
        {
            g.PaymentPercent = g.TotalBilled > 0
                ? Math.Round(g.TotalPaid / g.TotalBilled * 100m, 1) : 0m;
            double payProgress = g.TotalBilled > 0 ? (double)(g.TotalPaid / g.TotalBilled) : 0.0;
            g.PacingGap = hasTermDates ? termProgress - payProgress : 0.0;  // retained for display
            double shortfall = hasTermDates ? FeesUrgency.Shortfall(requiredPct, g.PaymentPercent) : 0.0;

            int effectiveStaleDays = g.TotalBalance >= settings.StaleHighBalanceAmount
                ? settings.StaleHighBalanceDays
                : g.TotalBalance >= settings.StaleMedBalanceAmount
                    ? settings.StaleMedBalanceDays
                    : settings.StaleThresholdDays;

            bool hasActivePromise = g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today;
            bool hasCoveringActivePromise = hasActivePromise
                && g.TotalBalance > 0
                && (double)((g.LatestPromiseAmount ?? 0m) / g.TotalBalance) >= settings.PartialPromiseCoverageThreshold;

            g.Tier = FeesUrgency.ComputeTier(g, today, hasTermDates,
                shortfall, settings.CriticalShortfallPoints, hasActivePromise,
                effectiveStaleDays, settings.NoProgressEscalationWeeks, settings.NoProgressPaymentThreshold);

            bool failedLastOutcome = g.LastOutcome.HasValue
                && FeesUrgency.FailedOutcomes.Contains(g.LastOutcome.Value);
            g.UrgencyScore = FeesUrgency.UrgencyScore(
                g.TotalBalance, shortfall,
                brokenPromise: g.Tier == PriorityTier.BrokenPromise,
                failedLastOutcome: failedLastOutcome,
                callRequired: g.CallRequired,
                hasCoveringActivePromise: hasCoveringActivePromise);
        }
```

- [ ] **Step 2: Keep the CallRequired enum tag but stop it overriding rank (current lines 511-514)**

Replace:

```csharp
        // Mark Call Required for guardians with any Overdue SMS sent (flag loaded with the main query)
        foreach (var row in rows)
            if (row.CallRequired)
                row.Tier = PriorityTier.CallRequired;
```

with:

```csharp
        // Tag Call Required for row colour only; ranking is by UrgencyScore (the
        // 1.4x callRequired multiplier already lifted these rows appropriately).
        foreach (var row in rows)
            if (row.CallRequired)
                row.Tier = PriorityTier.CallRequired;
```

(Behavior note: the tier tag is retained so the row keeps its CallRequired colour; the sort below no longer keys on tier.)

- [ ] **Step 3: Replace the sort (current lines 516-522)**

Replace:

```csharp
        rows.Sort((a, b) =>
        {
            int t = a.Tier.CompareTo(b.Tier);
            if (t != 0) return t;
            int p = b.PacingGap.CompareTo(a.PacingGap);   // higher gap = more urgent
            return p != 0 ? p : b.TotalBalance.CompareTo(a.TotalBalance);
        });
        return rows;
```

with:

```csharp
        // F4: single money-at-risk ranking for every list.
        rows.Sort((a, b) =>
        {
            int u = b.UrgencyScore.CompareTo(a.UrgencyScore);   // higher score = chase sooner
            return u != 0 ? u : b.TotalBalance.CompareTo(a.TotalBalance);
        });
        return rows;
```

- [ ] **Step 4: Delete the now-unused `ComputeGuardianTier` and `FailedOutcomes` from the service**

In `FeesFollowUpService.cs`, delete the entire private method `ComputeGuardianTier` (currently 917-950) and the private `FailedOutcomes` field (currently 1037-1044). The legacy `ComputeTier` (1046-1063) still references `FailedOutcomes`; update its three uses from `FailedOutcomes` to `FeesUrgency.FailedOutcomes`.

Specifically, in legacy `ComputeTier`, change:

```csharp
            || (r.LastOutcome.HasValue && FailedOutcomes.Contains(r.LastOutcome.Value)))
```

to:

```csharp
            || (r.LastOutcome.HasValue && FeesUrgency.FailedOutcomes.Contains(r.LastOutcome.Value)))
```

- [ ] **Step 5: Verify build**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_worklist.binlog 2>&1 | tee notes\IXtreme_build_worklist.log`
Expected: Build succeeded. (If CS errors mention `phaseTarget` or `CriticalPacingGapThreshold`, ensure all references in this method were replaced.)

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "feat(fees-crm): rank GetGuardianWorklist by UrgencyScore, drop tier-order sort (F1/F2/F4/F5)"
```

---

## Task 8: Window the CallRequired CTE (F3)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`CallRequiredCte` 384-390, parameter binding 419-422)

- [ ] **Step 1: Restrict the CTE to a recency window**

In the `GetGuardianWorklist` SQL, replace the `CallRequiredCte` definition (current 384-390):

```sql
    CallRequiredCte AS (
        -- Mirrors HasCallRequiredStudent: any Overdue SMS sent to this guardian
        SELECT GuardianKey AS ContactKey
        FROM tbl_SmsReminderLog
        WHERE ReminderType = 'Overdue' AND GuardianKey IS NOT NULL
        GROUP BY GuardianKey
    )
```

with:

```sql
    CallRequiredCte AS (
        -- F3: only a *recent* Overdue SMS counts, so the flag decays instead of sticking forever.
        SELECT GuardianKey AS ContactKey
        FROM tbl_SmsReminderLog
        WHERE ReminderType = 'Overdue' AND GuardianKey IS NOT NULL
          AND SentAt >= @callRequiredCutoff
        GROUP BY GuardianKey
    )
```

- [ ] **Step 2: Bind the new parameter**

In `GetGuardianWorklist`, after the existing `cmd.Parameters.Add("@prevSemester", ...)` line (current 422), add:

```csharp
            cmd.Parameters.Add("@callRequiredCutoff", SqlDbType.DateTime).Value =
                DateTime.Today.AddDays(-settings.CallRequiredWindowDays);
```

- [ ] **Step 3: Confirm the timestamp column name**

Run: `git grep -n "tbl_SmsReminderLog" -- '*.cs'` and inspect the `LogReminderSent` INSERT (FeesFollowUpService.cs:904-915) and any migration SQL under `docs/superpowers/plans/`.
Expected: confirm the column that records send time. The INSERT lists `(GuardianKey, StudentNumber, PromiseDate, ReminderType)` — if there is **no** send-timestamp column, use the migration in Task 12 to add `SentAt DATETIME NOT NULL DEFAULT GETDATE()` and set `LogReminderSent` to rely on the default (no code change needed for the INSERT). If a timestamp column already exists under a different name (e.g. `DateSent`), use that name in Step 1 instead of `SentAt` and skip the column addition in Task 12.

- [ ] **Step 4: Verify build**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_callrequired.binlog 2>&1 | tee notes\IXtreme_build_callrequired.log`
Expected: Build succeeded.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "feat(fees-crm): window CallRequired to recent Overdue SMS (F3)"
```

---

## Task 9: Daily list — resurface near deadline, sort by score (F4/F6)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`GetDailyWorklist` 540-568, `GetStudentWorklist` sort 601-605, `GetDashboardData` dailyTotal 620-634)

- [ ] **Step 1: Rewrite `GetDailyWorklist` (current 540-568)**

Replace the whole method body:

```csharp
    public List<GuardianWorklistRow> GetDailyWorklist(decimal minBalance = 0)
    {
        var settings = GetSettings();
        var all      = GetGuardianWorklist("", minBalance, settings);
        var today = DateTime.Today;

        // F6: within PromiseResurfaceDays of term end, stop hiding partially-covered
        // promises so the uncovered remainder gets worked before the deadline.
        bool nearDeadline = settings.TermEndDate.HasValue
            && (settings.TermEndDate.Value.Date - today).TotalDays <= settings.PromiseResurfaceDays;

        return all.Where(g =>
        {
            if (!nearDeadline
                && g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today
                && g.PaymentsSinceLatestPromise < (g.LatestPromiseAmount ?? 0))
            {
                decimal promiseAmt    = g.LatestPromiseAmount ?? 0m;
                double  coverageRatio = g.TotalBalance > 0
                    ? (double)(promiseAmt / g.TotalBalance)
                    : 1.0;
                if (coverageRatio >= settings.PartialPromiseCoverageThreshold)
                    return false;
            }

            // Exclude if successfully reached today
            return !g.ContactedToday;
        })
        .OrderByDescending(g => g.UrgencyScore)   // F4: same ranking as the guardian list
        .ThenByDescending(g => g.TotalBalance)
        .ToList();
    }
```

- [ ] **Step 2: Align `GetStudentWorklist` sort (current 601-605)**

Replace:

```csharp
        return result
            .OrderBy(s => (int)s.Tier)
            .ThenBy(s => s.ClassId)
            .ThenBy(s => s.FullName)
            .ToList();
```

with:

```csharp
        return result
            .OrderByDescending(s => s.UrgencyScore)
            .ThenBy(s => s.ClassId)
            .ThenBy(s => s.FullName)
            .ToList();
```

- [ ] **Step 3: Add `UrgencyScore` to `StudentWorklistRow` and populate it**

In `GuardianWorklistRow.cs`, in `StudentWorklistRow`, after `public PriorityTier Tier { get; set; }` (currently 123) add:

```csharp
    public double UrgencyScore     { get; set; }   // inherited from guardian for ranking
```

In `FeesFollowUpService.GetStudentWorklist`, inside the `new StudentWorklistRow { ... }` initializer (currently 579-597), add after `Tier = g.Tier,`:

```csharp
                    UrgencyScore     = g.UrgencyScore,
```

- [ ] **Step 4: Mirror the resurface condition in `GetDashboardData` dailyTotal (current 620-634)**

Replace:

```csharp
        int dailyTotal = all.Count(g =>
        {
            if (g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today
                && g.PaymentsSinceLatestPromise < (g.LatestPromiseAmount ?? 0))
            {
                decimal promiseAmt    = g.LatestPromiseAmount ?? 0m;
                double  coverageRatio = g.TotalBalance > 0
                    ? (double)(promiseAmt / g.TotalBalance)
                    : 1.0;
                if (coverageRatio >= settings.PartialPromiseCoverageThreshold)
                    return false;
            }
            return !g.ContactedToday;
        }) + contactedToday;
```

with:

```csharp
        bool nearDeadline = settings.TermEndDate.HasValue
            && (settings.TermEndDate.Value.Date - today).TotalDays <= settings.PromiseResurfaceDays;

        int dailyTotal = all.Count(g =>
        {
            if (!nearDeadline
                && g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today
                && g.PaymentsSinceLatestPromise < (g.LatestPromiseAmount ?? 0))
            {
                decimal promiseAmt    = g.LatestPromiseAmount ?? 0m;
                double  coverageRatio = g.TotalBalance > 0
                    ? (double)(promiseAmt / g.TotalBalance)
                    : 1.0;
                if (coverageRatio >= settings.PartialPromiseCoverageThreshold)
                    return false;
            }
            return !g.ContactedToday;
        }) + contactedToday;
```

- [ ] **Step 5: Verify build**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_daily.binlog 2>&1 | tee notes\IXtreme_build_daily.log`
Expected: Build succeeded.

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs
git commit -m "feat(fees-crm): resurface partial promises near deadline, rank daily list by UrgencyScore (F4/F6)"
```

---

## Task 10: Populate on-track dashboard fields (F7/F8)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`GetDashboardData` 608-680)

- [ ] **Step 1: Compute term progress + configured flag in `GetDashboardData`**

In `GetDashboardData`, after the line `var today  = DateTime.Today;` (current 616), add:

```csharp
        bool termDatesConfigured = settings.TermStartDate.HasValue && settings.TermEndDate.HasValue;
        double termProgress = FeesUrgency.TermProgress(today, settings.TermStartDate, settings.TermEndDate);
```

- [ ] **Step 2: Set the new fields on the returned `DashboardData`**

In the `return new DashboardData { ... }` initializer, after `TotalTermWeeks = totalTermWeeks,` (current 669) add:

```csharp
            TermDatesConfigured   = termDatesConfigured,
            TermProgress          = termProgress,
            CollectionGoalPercent = (decimal)(settings.CollectionGoal * 100.0),
```

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_dash.binlog 2>&1 | tee notes\IXtreme_build_dash.log`
Expected: Build succeeded.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "feat(fees-crm): populate on-track dashboard fields (F7/F8)"
```

---

## Task 11: Settings dialog — swap phase rows for new settings (F1/F2/F3/F6)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs`

- [ ] **Step 1: Replace the phase-percent SpinEdit fields**

In `FollowUpSettings.cs`, change the field declaration (current 24):

```csharp
    private SpinEdit spnFirstHalfPct, spnSecondHalfPct;
```

to:

```csharp
    private SpinEdit spnCollectionGoal, spnCriticalShortfall, spnCallReqWindow, spnPromiseResurface;
```

- [ ] **Step 2: Replace the load lines in the constructor (current 48-49)**

Replace:

```csharp
        spnFirstHalfPct.Value  = (decimal)s.FirstHalfMinPercent;
        spnSecondHalfPct.Value = (decimal)s.SecondHalfMinPercent;
```

with:

```csharp
        spnCollectionGoal.Value    = (decimal)(s.CollectionGoal * 100.0);
        spnCriticalShortfall.Value = (decimal)s.CriticalShortfallPoints;
        spnCallReqWindow.Value     = s.CallRequiredWindowDays;
        spnPromiseResurface.Value  = s.PromiseResurfaceDays;
```

- [ ] **Step 3: Replace the InitializeComponent UI rows (current 154-172)**

Replace the two blocks "Row 11: First-half min payment %" and "Row 12: Second-half min payment %" (current 154-172) with:

```csharp
        // Row 11: Collection goal
        var lblGoal = new LabelControl
            { Text = "Collection goal by term end (%):",
              Location = new System.Drawing.Point(12, 366) };
        this.spnCollectionGoal = new SpinEdit
            { Location = new System.Drawing.Point(340, 362), Width = 80 };
        this.spnCollectionGoal.Properties.IsFloatValue = false;
        this.spnCollectionGoal.Properties.MinValue     = 0;
        this.spnCollectionGoal.Properties.MaxValue     = 100;

        // Row 12: Critical shortfall points
        var lblShortfall = new LabelControl
            { Text = "Critical when behind required line by (pts):",
              Location = new System.Drawing.Point(12, 398) };
        this.spnCriticalShortfall = new SpinEdit
            { Location = new System.Drawing.Point(340, 394), Width = 80 };
        this.spnCriticalShortfall.Properties.IsFloatValue = false;
        this.spnCriticalShortfall.Properties.MinValue     = 0;
        this.spnCriticalShortfall.Properties.MaxValue     = 100;

        // Row 12b: CallRequired window
        var lblCallReq = new LabelControl
            { Text = "\"Call Required\" window — overdue SMS within (days):",
              Location = new System.Drawing.Point(12, 412) };
        this.spnCallReqWindow = new SpinEdit
            { Location = new System.Drawing.Point(340, 408), Width = 80 };
        this.spnCallReqWindow.Properties.IsFloatValue = false;
        this.spnCallReqWindow.Properties.MinValue     = 1;
        this.spnCallReqWindow.Properties.MaxValue     = 365;

        // Row 12c: Promise resurface
        var lblResurface = new LabelControl
            { Text = "Resurface partial promises within (days of term end):",
              Location = new System.Drawing.Point(12, 426) };
        this.spnPromiseResurface = new SpinEdit
            { Location = new System.Drawing.Point(340, 422), Width = 80 };
        this.spnPromiseResurface.Properties.IsFloatValue = false;
        this.spnPromiseResurface.Properties.MinValue     = 0;
        this.spnPromiseResurface.Properties.MaxValue     = 365;
```

Note: the template labels/memos below (current 174-194) and the buttons use fixed Y coordinates; the four new rows fit in the same vertical span the two removed rows occupied plus the existing gap. If rows visually overlap the template section, nudge the template/button `Location` Y values down by ~40px consistently. This is cosmetic and does not affect logic.

- [ ] **Step 4: Replace the save initializer lines (current 234-235)**

Replace:

```csharp
                FirstHalfMinPercent  = (double)spnFirstHalfPct.Value,
                SecondHalfMinPercent = (double)spnSecondHalfPct.Value,
```

with:

```csharp
                CollectionGoal          = (double)(spnCollectionGoal.Value / 100m),
                CriticalShortfallPoints = (double)spnCriticalShortfall.Value,
                CallRequiredWindowDays  = (int)spnCallReqWindow.Value,
                PromiseResurfaceDays    = (int)spnPromiseResurface.Value,
```

- [ ] **Step 5: Add the new controls to the form's Controls collection (current 261-262)**

Replace:

```csharp
            lblFirstHalf,  spnFirstHalfPct,
            lblSecondHalf, spnSecondHalfPct,
```

with:

```csharp
            lblGoal,       spnCollectionGoal,
            lblShortfall,  spnCriticalShortfall,
            lblCallReq,    spnCallReqWindow,
            lblResurface,  spnPromiseResurface,
```

- [ ] **Step 6: Verify build**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_settingsdlg.binlog 2>&1 | tee notes\IXtreme_build_settingsdlg.log`
Expected: Build succeeded — no remaining references to `spnFirstHalfPct`/`spnSecondHalfPct` or `FirstHalfMinPercent`/`SecondHalfMinPercent`.

- [ ] **Step 7: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs
git commit -m "feat(fees-crm): settings dialog rows for goal/shortfall/window/resurface"
```

---

## Task 12: UI — term-dates banner + NOCONTACT styling + migration (F7/F9)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrDailyWorklist.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs`
- Create: `docs/superpowers/plans/2026-06-08-fees-followup-urgency-migration.sql`

- [ ] **Step 1: Add a term-dates banner field + helper to `usrDailyWorklist`**

In `usrDailyWorklist.cs`, add a field after `private bool _columnsConfigured;` (current 24):

```csharp
    private LabelControl _banner;
```

In `BuildLayout`, before `this.Controls.Add(_grid);` (current 68), add:

```csharp
        _banner = new LabelControl
        {
            Dock      = DockStyle.Top,
            Visible   = false,
            AutoSizeMode = LabelAutoSizeMode.None,
            Height    = 24,
            Text      = "Term start/end not set — deadline-based prioritisation is off. Set them in Follow-up Settings.",
        };
        _banner.Appearance.BackColor = Color.LightGoldenrodYellow;
        _banner.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        this.Controls.Add(_banner);
```

In `LoadData`, after `_allRows = _service.GetDailyWorklist(0);` (current 77), add:

```csharp
            _banner.Visible = !_service.GetDashboardData().TermDatesConfigured;
```

Note: `GetDashboardData` is heavier than needed for a flag; acceptable for parity with the dashboard. If the reviewer prefers, expose a cheap `bool AreTermDatesConfigured()` on the service and call that instead — equivalent behavior.

- [ ] **Step 2: Add NOCONTACT styling to `usrDailyWorklist.View_RowStyle` (current 177-188)**

Inside `View_RowStyle`, before the closing brace of the method (after the `switch`), add:

```csharp
        if (row.IsUnreachable)
        {
            e.Appearance.ForeColor = Color.Gray;
            e.Appearance.Font = new Font(_view.Appearance.Row.Font, FontStyle.Italic);
        }
```

And append a "(no phone)" hint by adding to `ConfigureColumns`, after the `AddCol("GuardianLabel", ...)` line (current 99):

```csharp
        _view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column.FieldName == "GuardianLabel"
                && _view.GetRow(_view.GetRowHandle(e.ListSourceRowIndex)) is GuardianWorklistRow gr
                && gr.IsUnreachable)
                e.DisplayText = (e.Value?.ToString() ?? "") + "  (no phone)";
        };
```

- [ ] **Step 3: Repeat Steps 1–2 for `usrGuardianWorklist.cs`**

Apply the identical banner field/creation, the `LoadData` visibility line (place after `_allRows = _service.GetGuardianWorklist(cf, mb);`, current 97), the `View_RowStyle` NOCONTACT block (current 222-233), and the `GuardianLabel` display-text hint in `ConfigureColumns` (after the `AddCol("GuardianLabel", ...)` line, current 143). Code is identical to Step 1–2.

- [ ] **Step 4: Write the migration SQL**

Create `docs/superpowers/plans/2026-06-08-fees-followup-urgency-migration.sql`:

```sql
-- Fees Follow-up deadline-aware urgency overhaul (2026-06-08)
-- Run once against the school database before deploying the rebuilt IXtreme.exe.

-- 1. New settings keys (defaults; the app upserts these via SaveSettings too).
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'CollectionGoal')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('CollectionGoal', '0.98');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'CriticalShortfallPoints')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('CriticalShortfallPoints', '25');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'CallRequiredWindowDays')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('CallRequiredWindowDays', '14');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'PromiseResurfaceDays')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('PromiseResurfaceDays', '14');

-- 2. Retired keys (FirstHalfMinPercent / SecondHalfMinPercent) are now dead; safe to remove.
DELETE FROM tbl_FollowUpSettings WHERE SettingKey IN ('FirstHalfMinPercent', 'SecondHalfMinPercent');

-- 3. CallRequired windowing needs a send-timestamp on the SMS log.
--    Only run if tbl_SmsReminderLog has no existing send-time column (see Task 8 Step 3).
IF NOT EXISTS (SELECT 1 FROM sys.columns
              WHERE object_id = OBJECT_ID('tbl_SmsReminderLog') AND name = 'SentAt')
    ALTER TABLE tbl_SmsReminderLog ADD SentAt DATETIME NOT NULL CONSTRAINT DF_SmsReminderLog_SentAt DEFAULT GETDATE();
```

- [ ] **Step 5: Verify build**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_ui.binlog 2>&1 | tee notes\IXtreme_build_ui.log`
Expected: Build succeeded.

- [ ] **Step 6: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrDailyWorklist.cs decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs docs/superpowers/plans/2026-06-08-fees-followup-urgency-migration.sql
git commit -m "feat(fees-crm): term-dates banner, NOCONTACT styling, migration SQL (F7/F9)"
```

---

## Task 13: Full verification + docs

**Files:**
- Modify: `CLAUDE.md` (Fees Follow-up Glossary — settings section)

- [ ] **Step 1: Run the full unit-test suite**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: all tests PASS (RequiredLine, Tier, UrgencyScore, Model, Smoke).

- [ ] **Step 2: Clean build of IXtreme**

Run: `dotnet build decompiled\IXtreme\IXtreme.csproj -clp:ErrorsOnly /bl:notes\IXtreme_build_final.binlog 2>&1 | tee notes\IXtreme_build_final.log`
Expected: Build succeeded, 0 errors.

- [ ] **Step 3: Update the glossary settings section in CLAUDE.md**

In `CLAUDE.md`, in the "Settings" part of the Fees Follow-up Glossary, replace the "Phase Min Percent (First/Second Half)" entry and the "Threshold units" paragraph's references to first/second half with the new model. Add:

```markdown
**Collection Goal** — the term-end collection target driving the required-payment line.
Stored as a fraction (0–1), shown as a percentage. Default 0.98 (98%).

**Required-Payment Line** — `CollectionGoal × TermProgress × 100`. The payment percent a
guardian is expected to have reached today. Replaces the old flat First/Second-Half phase targets.

**Shortfall** — `RequiredPct − PaymentPercent`, in percentage points. Positive = behind the line.

**Critical Shortfall Points** — shortfall (pts) at/above which a guardian with no active promise
becomes Critical. Default 25. (Replaces the pacing-gap and flat-phase Critical rules.)

**Urgency Score** — `TotalBalance × (1 + max(0,Shortfall)/50) × behaviorMultipliers`
(broken promise ×1.5, failed last outcome ×1.3, call-required ×1.4, covering active promise ×0.4).
The single sort key for all worklists; tiers now drive only row colour and dashboard grouping.

**Call Required Window Days** — only an Overdue SMS sent within this many days flags Call Required.
Default 14.

**Promise Resurface Days** — within this many days of term end, partially-covered promises are no
longer hidden from the daily list so the uncovered remainder is worked. Default 14.
```

Remove the now-obsolete "Phase Min Percent (First/Second Half)" definition and drop
`FirstHalfMinPercent`/`SecondHalfMinPercent` from the "Threshold units" paragraph (keep the
`CriticalShortfallPoints` and `CollectionGoal` unit notes consistent with existing conventions).

- [ ] **Step 4: Commit**

```bash
git add CLAUDE.md notes/IXtreme_build_final.log
git commit -m "docs(fees-crm): update glossary for deadline-aware urgency model"
```

- [ ] **Step 5: Finish the branch**

Use the superpowers:finishing-a-development-branch skill to choose merge/PR/cleanup.

---

## Self-review notes (coverage map spec → tasks)

- F1 required line → Tasks 2, 6, 7, 10, 11
- F2 single Critical rule / no flooding → Tasks 3, 6, 7, 11
- F3 windowed CallRequired + score, not top tier → Tasks 4, 7, 8, 11
- F4 UrgencyScore master sort, both lists → Tasks 4, 5, 7, 9
- F5 broken promise surfaces via score → Task 4, 7
- F6 partial-promise resurface near deadline → Tasks 6, 9, 11
- F7 term-dates warn+degrade → Tasks 6, 7, 10, 12
- F8 on-track dashboard KPIs (linear projection) → Tasks 5, 10
- F9 NOCONTACT flag-in-place → Tasks 5, 12
- Settings/migration/docs → Tasks 6, 11, 12, 13
```
