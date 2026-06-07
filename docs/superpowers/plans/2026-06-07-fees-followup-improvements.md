# Fees Follow-up Improvements Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Add a weekly-collection KPI, a date-range interaction viewer, a phase-based Critical escalation rule, and remove the per-guardian N+1 query pattern in the Fees Follow-up module.

**Architecture:** All changes are in the IXtreme WinForms project (`decompiled/IXtreme/`). Three of the four features touch `FeesFollowUpService.GetGuardianWorklist` / `GetDashboardData` and their DTOs; one adds a new modal dialog plus ribbon wiring. No DB schema changes — new settings keys are created lazily by the existing `Upsert` pattern.

**Tech Stack:** C# (net472, x86, LangVersion 11), WinForms, DevExpress v23.2 (XtraGrid/XtraEditors/XtraBars), `System.Data.SqlClient`, SQL Server.

**Verification model:** This is a source-recovery project with **no test suite** (per CLAUDE.md). Each task is verified by a clean build of `decompiled\IXtreme\IXtreme.csproj` and, at the end, a smoke test (launch the EXE, open Fees Follow-up). Build logs go to `notes\IXtreme_build<N>.log` (next free number — the repo is at build68, so start at build69).

**Build command used throughout (PowerShell):**
```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build<N>.log
```
Expected on success: `Build succeeded.` with `0 Error(s)`.

---

## File Structure

| File | Change | Responsibility |
|---|---|---|
| `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` | Modify | Add `ContactedToday`/`CallRequired` bools to `GuardianWorklistRow`; add `CollectedThisWeek` to `DashboardData`; add `FirstHalfMinPercent`/`SecondHalfMinPercent` to `FeesFollowUpSettings`. |
| `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` | Modify | Fold per-guardian lookups into main query; phase-rule tier logic; weekly-collection total; new `GetInteractionsByDateRange`; settings load/save. |
| `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` | Modify | 12th KPI card. |
| `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs` | Modify | Two new percent inputs. |
| `decompiled/IXtreme/I_Xtreme.DialogForms/dlgInteractionLog.cs` | Create | New modal interaction-review dialog. |
| `decompiled/IXtreme/I_Xtreme/MainForm.cs` | Modify | Ribbon button `bbiViewInteractions`. |

Tasks are ordered to minimise churn inside `GetGuardianWorklist`: performance restructure first, then the tier rule, then the dashboard KPI, then the standalone dialog.

---

## Task 1: Performance — eliminate per-guardian round-trips

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` (class `GuardianWorklistRow`)
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`GetGuardianWorklist`, `GetDailyWorklist`, `GetDashboardData`)

- [ ] **Step 1: Add two bool properties to `GuardianWorklistRow`**

In `GuardianWorklistRow.cs`, inside `class GuardianWorklistRow`, after the existing `FirstContactDate` property (around line 94), add:

```csharp
    // Folded into the main query (Task 1) to avoid per-guardian round-trips.
    public bool ContactedToday { get; set; }   // any 'Contacted'/'Promised'/'Refused' log today
    public bool CallRequired   { get; set; }   // any Overdue SMS sent (tbl_SmsReminderLog)
```

- [ ] **Step 2: Add the two CTEs to the `GetGuardianWorklist` SQL**

In `FeesFollowUpService.cs`, in `GetGuardianWorklist`, find the `EarliestContact` CTE (ends `GROUP BY ContactKey`) immediately before the final `SELECT` (around lines 349-353). Insert these two CTEs between `EarliestContact` and the final `SELECT`. The line `)` closing `EarliestContact` is followed by `SELECT`; change it so `EarliestContact` is followed by a comma and the new CTEs:

```sql
    ),
    EarliestContact AS (
        SELECT ContactKey, MIN(ContactDate) AS FirstContactDate
        FROM AllRelevantContacts
        GROUP BY ContactKey
    ),
    ContactedTodayCte AS (
        -- Mirrors WasContactedToday: a same-day log with a 'reached' outcome
        SELECT cl.GuardianKey AS ContactKey
        FROM tbl_FeesContactLog cl
        WHERE cl.GuardianKey IS NOT NULL
          AND CAST(cl.ContactDate AS DATE) = CAST(GETDATE() AS DATE)
          AND cl.Outcome IN ('Contacted', 'Promised', 'Refused')
        GROUP BY cl.GuardianKey
    ),
    CallRequiredCte AS (
        -- Mirrors HasCallRequiredStudent: any Overdue SMS sent to this guardian
        SELECT GuardianKey AS ContactKey
        FROM tbl_SmsReminderLog
        WHERE ReminderType = 'Overdue' AND GuardianKey IS NOT NULL
        GROUP BY GuardianKey
    )
```

(Note: `EarliestContact`'s closing `)` now ends with `,` instead of being followed directly by `SELECT`.)

- [ ] **Step 3: Add the two flags to the final SELECT and its joins**

Still in `GetGuardianWorklist`, in the final `SELECT` list, after the line `,ec.FirstContactDate` add two columns; and after `LEFT JOIN EarliestContact ec ...` add two joins. The block becomes:

```sql
        ISNULL(psp.PaymentsSinceLatestPromise, 0) AS PaymentsSinceLatestPromise
        ,ec.FirstContactDate
        ,CASE WHEN ct.ContactKey IS NOT NULL THEN 1 ELSE 0 END AS ContactedToday
        ,CASE WHEN cr.ContactKey IS NOT NULL THEN 1 ELSE 0 END AS CallRequired
    FROM StudentsWithBalance sw
    LEFT JOIN LatestContactDetail lcd ON lcd.ContactKey = sw.GuardianKey
    LEFT JOIN LatestPromiseDetail  lpd ON lpd.ContactKey = sw.GuardianKey
    LEFT JOIN PaymentsSincePromise psp ON psp.ContactKey = sw.GuardianKey
    LEFT JOIN EarliestContact     ec  ON ec.ContactKey  = sw.GuardianKey
    LEFT JOIN ContactedTodayCte   ct  ON ct.ContactKey  = sw.GuardianKey
    LEFT JOIN CallRequiredCte     cr  ON cr.ContactKey  = sw.GuardianKey
    ORDER BY sw.GuardianKey, sw.FullName";
```

- [ ] **Step 4: Set the flags when the guardian group is first created**

In the `while (rdr.Read())` loop, in the `g = new GuardianWorklistRow { ... }` initializer (around lines 390-402), after the `FirstContactDate = rdr["FirstContactDate"] as DateTime?,` line add:

```csharp
                        ContactedToday = Convert.ToInt32(rdr["ContactedToday"]) == 1,
                        CallRequired   = Convert.ToInt32(rdr["CallRequired"])   == 1,
```

- [ ] **Step 5: Replace the per-row CallRequired connection loop**

In `GetGuardianWorklist`, find this block (around lines 455-462):

```csharp
        // Mark Call Required for guardians with any Overdue SMS sent
        using (var crConn = new SqlConnection(connectionString))
        {
            crConn.Open();
            foreach (var row in rows)
                if (HasCallRequiredStudent(crConn, row.GuardianContact))
                    row.Tier = PriorityTier.CallRequired;
        }
```

Replace it with (no DB connection — use the flag already loaded):

```csharp
        // Mark Call Required for guardians with any Overdue SMS sent (flag loaded with the main query)
        foreach (var row in rows)
            if (row.CallRequired)
                row.Tier = PriorityTier.CallRequired;
```

- [ ] **Step 6: Use the flag in `GetDailyWorklist`**

In `GetDailyWorklist`, find `return !WasContactedToday(g.GuardianContact);` (around line 511) and replace with:

```csharp
            return !g.ContactedToday;
```

- [ ] **Step 7: Use the flag in `GetDashboardData`**

In `GetDashboardData`, replace the two `WasContactedToday` usages:

Line ~566: `int contactedToday = all.Count(g => WasContactedToday(g.GuardianContact));`
becomes:
```csharp
        int contactedToday = all.Count(g => g.ContactedToday);
```

Inside the `dailyTotal` lambda (around line 581): `return !WasContactedToday(g.GuardianContact);`
becomes:
```csharp
            return !g.ContactedToday;
```

- [ ] **Step 8: Build**

Run:
```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build69.log
```
Expected: `Build succeeded.` `0 Error(s)`. (The `WasContactedToday` and `HasCallRequiredStudent` helpers remain defined but are now unused — that is fine, do not delete them; they are private and harmless. A CS0169/unused-private-member warning will NOT appear because they are methods, not fields.)

- [ ] **Step 9: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "perf(fees-crm): fold contacted-today and call-required lookups into main worklist query"
```

---

## Task 2: Phase-based payment-shortfall → Critical

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` (class `FeesFollowUpSettings`)
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`GetSettings`, `SaveSettings`, `GetGuardianWorklist`, `ComputeGuardianTier`)
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs`

- [ ] **Step 1: Add the two settings properties**

In `GuardianWorklistRow.cs`, in `class FeesFollowUpSettings`, after the `NoProgressPaymentThreshold` property (around line 35) add:

```csharp
    // Phase-based shortfall escalation (in addition to pacing-gap rule).
    // First half of term: expect >= FirstHalfMinPercent paid; second half: >= SecondHalfMinPercent.
    // Below the phase target AND no active promise => Critical (only when term dates are set).
    public double FirstHalfMinPercent  { get; set; } = 50.0;
    public double SecondHalfMinPercent { get; set; } = 80.0;
```

- [ ] **Step 2: Load the settings in `GetSettings`**

In `FeesFollowUpService.GetSettings`, inside the `return new FeesFollowUpSettings { ... }` initializer, after the `NoProgressPaymentThreshold = ...` block (ends around line 127) add:

```csharp
            FirstHalfMinPercent =
                dict.TryGetValue("FirstHalfMinPercent", out var fh)
                && double.TryParse(fh, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double fhd)
                    ? fhd : 50.0,
            SecondHalfMinPercent =
                dict.TryGetValue("SecondHalfMinPercent", out var sh)
                && double.TryParse(sh, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double shd)
                    ? shd : 80.0,
```

- [ ] **Step 3: Persist the settings in `SaveSettings`**

In `SaveSettings`, after the `Upsert(conn, "NoProgressPaymentThreshold", ...)` call (around line 152-153) add:

```csharp
        Upsert(conn, "FirstHalfMinPercent",
            s.FirstHalfMinPercent.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "SecondHalfMinPercent",
            s.SecondHalfMinPercent.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
```

- [ ] **Step 4: Compute the phase target in `GetGuardianWorklist`**

In `GetGuardianWorklist`, after the `termProgress` computation block (the `if (hasTermDates) { ... }` ending around line 436), add:

```csharp
        // Phase target for the payment-shortfall Critical rule (Task 2)
        double phaseTarget = 0.0;
        if (hasTermDates)
        {
            DateTime midterm = tStart.Value.AddDays((tEnd.Value - tStart.Value).TotalDays / 2.0);
            phaseTarget = DateTime.Today < midterm
                ? settings.FirstHalfMinPercent
                : settings.SecondHalfMinPercent;
        }
```

- [ ] **Step 5: Pass phase target + active-promise flag to `ComputeGuardianTier`**

Still in `GetGuardianWorklist`, in the `foreach (var g in rows)` loop, replace the existing tier assignment (around lines 450-452):

```csharp
            g.Tier = ComputeGuardianTier(g, effectiveStaleDays,
                settings.CriticalPacingGapThreshold, hasTermDates,
                settings.NoProgressEscalationWeeks, settings.NoProgressPaymentThreshold);
```

with:

```csharp
            bool hasActivePromise = g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= DateTime.Today;
            g.Tier = ComputeGuardianTier(g, effectiveStaleDays,
                settings.CriticalPacingGapThreshold, hasTermDates,
                settings.NoProgressEscalationWeeks, settings.NoProgressPaymentThreshold,
                phaseTarget, hasActivePromise);
```

- [ ] **Step 6: Add the phase rule to `ComputeGuardianTier`**

Replace the `ComputeGuardianTier` signature and its opening pacing check (around lines 864-869):

```csharp
    private static PriorityTier ComputeGuardianTier(
        GuardianWorklistRow g, int stalenessDays, double criticalThreshold, bool hasTermDates,
        int noProgressWeeks, double noProgressThreshold)
    {
        if (hasTermDates && g.PacingGap >= criticalThreshold)
            return PriorityTier.Critical;
```

with:

```csharp
    private static PriorityTier ComputeGuardianTier(
        GuardianWorklistRow g, int stalenessDays, double criticalThreshold, bool hasTermDates,
        int noProgressWeeks, double noProgressThreshold,
        double phaseTarget, bool hasActivePromise)
    {
        if (hasTermDates && g.PacingGap >= criticalThreshold)
            return PriorityTier.Critical;

        // Phase-based shortfall: below the term-phase target with no active promise.
        if (hasTermDates && (double)g.PaymentPercent < phaseTarget && !hasActivePromise)
            return PriorityTier.Critical;
```

(`g.PaymentPercent` is already set earlier in the loop, before this call.)

- [ ] **Step 7: Add the two inputs to the settings dialog**

In `FollowUpSettings.cs`:

(a) Add fields next to the existing escalation spin edits (after line 23 `private SpinEdit spnEscWeeks, spnEscThreshold;`):

```csharp
    private SpinEdit spnFirstHalfPct, spnSecondHalfPct;
```

(b) In the constructor, after `spnEscThreshold.Value = (decimal)s.NoProgressPaymentThreshold;` (around line 46) add:

```csharp
        spnFirstHalfPct.Value  = (decimal)s.FirstHalfMinPercent;
        spnSecondHalfPct.Value = (decimal)s.SecondHalfMinPercent;
```

(c) In `InitializeComponent`, after the Row 10 (`spnEscThreshold`) block (around line 149), add two new rows. Shift the template rows down by 72px to make room: change `lbl2Day` Location Y from 360 to 432, `memo2Day` Y from 378 to 450, `lblDayOf` Y from 446 to 518, `memoDayOf` Y from 462 to 534, `lblOverdue` Y from 530 to 602, `memoOverdue` Y from 546 to 618, `btnResetTemplates`/`btnOK`/`btnCancel` Y from 620 to 692, and `this.ClientSize` height from 652 to 724. Then add:

```csharp
        // Row 11: First-half min payment %
        var lblFirstHalf = new LabelControl
            { Text = "First half of term: expect paid >= (%):",
              Location = new System.Drawing.Point(12, 366) };
        this.spnFirstHalfPct = new SpinEdit
            { Location = new System.Drawing.Point(340, 362), Width = 80 };
        this.spnFirstHalfPct.Properties.IsFloatValue = false;
        this.spnFirstHalfPct.Properties.MinValue     = 0;
        this.spnFirstHalfPct.Properties.MaxValue     = 100;

        // Row 12: Second-half min payment %
        var lblSecondHalf = new LabelControl
            { Text = "Second half of term: expect paid >= (%):",
              Location = new System.Drawing.Point(12, 398) };
        this.spnSecondHalfPct = new SpinEdit
            { Location = new System.Drawing.Point(340, 394), Width = 80 };
        this.spnSecondHalfPct.Properties.IsFloatValue = false;
        this.spnSecondHalfPct.Properties.MinValue     = 0;
        this.spnSecondHalfPct.Properties.MaxValue     = 100;
```

(d) In `this.Controls.AddRange(...)` add the four new controls after `lblEscThreshold, spnEscThreshold,`:

```csharp
            lblFirstHalf,  spnFirstHalfPct,
            lblSecondHalf, spnSecondHalfPct,
```

(e) In the `btnOK.Click` handler's `new FeesFollowUpSettings { ... }` initializer, after `NoProgressPaymentThreshold = (double)spnEscThreshold.Value,` add:

```csharp
                FirstHalfMinPercent  = (double)spnFirstHalfPct.Value,
                SecondHalfMinPercent = (double)spnSecondHalfPct.Value,
```

- [ ] **Step 8: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build70.log
```
Expected: `Build succeeded.` `0 Error(s)`.

- [ ] **Step 9: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs
git commit -m "feat(fees-crm): escalate below-phase-target guardians with no active promise to Critical"
```

---

## Task 3: "Collected This Week" KPI

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (`DashboardTotals` struct, `GetDashboardTotals`, `GetDashboardData`)
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` (class `DashboardData`)
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

- [ ] **Step 1: Add `CollectedThisWeek` to the `DashboardTotals` struct**

In `FeesFollowUpService.cs`, in the private `struct DashboardTotals` (around lines 180-187), add a field:

```csharp
        public decimal CollectedThisWeek;
```

- [ ] **Step 2: Compute the weekly total inside `GetDashboardTotals`**

In `GetDashboardTotals`, add the weekly figure as a scalar subquery in the final `SELECT`. After the `ZeroPaid` line in the SELECT list (around line 220), add:

```sql
        ,(SELECT ISNULL(SUM(Credit), 0) FROM FeesPayment
          WHERE SemesterId = @currentSemester AND Credit > 0
            AND DateOfPayment >= @weekStart)                                AS CollectedThisWeek
```

Then add the parameter after the existing `@prevSemester` parameter (around line 229):

```csharp
        DateTime weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek); // Sunday on/before today
        cmd.Parameters.Add("@weekStart", SqlDbType.Date).Value = weekStart;
```

And in the `return new DashboardTotals { ... }` initializer (around lines 232-239), add:

```csharp
            CollectedThisWeek = Convert.ToDecimal(rdr["CollectedThisWeek"]),
```

- [ ] **Step 3: Add `CollectedThisWeek` to `DashboardData`**

In `GuardianWorklistRow.cs`, in `class DashboardData`, after `public decimal TotalCollected { get; set; }` (around line 143) add:

```csharp
    public decimal CollectedThisWeek         { get; set; }
```

- [ ] **Step 4: Set it in `GetDashboardData`**

In `GetDashboardData`, in the `return new DashboardData { ... }` initializer, after `TotalCollected = totals.TotalPaid,` (around line 606) add:

```csharp
            CollectedThisWeek         = totals.CollectedThisWeek,
```

- [ ] **Step 5: Grow the KPI array and add the card**

In `usrFeesFollowUp.cs`:

(a) Change the array size (line 17):
```csharp
    private readonly Label[] _kpiValues = new Label[12];
```

(b) In `InitializeComponent`, in the Row 1 card block, insert the new card immediately after the `BuildKpiCard(4, "Total Enrolled", ...)` line (around line 143) so it renders at the end of Row 1:

```csharp
        _kpiPanel.Controls.Add(BuildKpiCard(11, "Collected This Week (UGX)", Color.SeaGreen));
```

- [ ] **Step 6: Populate the card value**

In `UpdateKpiStrip`, after `_kpiValues[4].Text = $"{data.TotalEnrolled}";` (around line 231) add:

```csharp
        _kpiValues[11].Text = $"{data.CollectedThisWeek:N0}";
```

- [ ] **Step 7: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build71.log
```
Expected: `Build succeeded.` `0 Error(s)`.

- [ ] **Step 8: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs
git commit -m "feat(fees-crm): add Collected This Week KPI to follow-up dashboard"
```

---

## Task 4: "View Interactions" service method

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Add `GetInteractionsByDateRange`**

In `FeesFollowUpService.cs`, after `GetGuardianContactHistory` (ends around line 1124), add:

```csharp
    /// <summary>
    /// All interactions logged within [fromInclusive, toInclusive] (whole days),
    /// joined to the student name. Ordered newest first. Read-only review feed.
    /// </summary>
    public DataTable GetInteractionsByDateRange(DateTime fromInclusive, DateTime toInclusive)
    {
        var dt = new DataTable();
        using var conn = new SqlConnection(connectionString);
        using var da = new SqlDataAdapter(@"
        SELECT cl.ContactId,
               cl.ContactDate,
               s.fullName AS StudentName,
               CASE WHEN LTRIM(RTRIM(ISNULL(s.GuardianRelation,''))) = ''
                    THEN ISNULL(s.Guardian,'')
                    ELSE ISNULL(s.Guardian,'') + ' (' + s.GuardianRelation + ')'
               END AS GuardianDisplay,
               cl.Channel,
               cl.Outcome,
               cl.Note,
               cl.PromiseDate,
               cl.PromiseAmount,
               cl.LoggedBy
        FROM tbl_FeesContactLog cl
        LEFT JOIN tbl_Stud s ON s.StudentNumber = cl.StudentNumber
        WHERE cl.ContactDate >= @from AND cl.ContactDate < @toExclusive
        ORDER BY cl.ContactDate DESC", conn);
        da.SelectCommand.Parameters.Add("@from", SqlDbType.DateTime).Value = fromInclusive.Date;
        da.SelectCommand.Parameters.Add("@toExclusive", SqlDbType.DateTime).Value =
            toInclusive.Date.AddDays(1);
        da.Fill(dt);
        return dt;
    }
```

- [ ] **Step 2: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build72.log
```
Expected: `Build succeeded.` `0 Error(s)`.

- [ ] **Step 3: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "feat(fees-crm): add GetInteractionsByDateRange query for interaction review"
```

---

## Task 5: "View Interactions" dialog

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgInteractionLog.cs`

- [ ] **Step 1: Create the dialog**

Create `decompiled/IXtreme/I_Xtreme.DialogForms/dlgInteractionLog.cs` with this full content:

```csharp
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class dlgInteractionLog : XtraForm
{
    private DateEdit dteFrom;
    private DateEdit dteTo;
    private SimpleButton btnLoad;
    private GridControl grid;
    private GridView view;

    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public dlgInteractionLog()
    {
        InitializeComponent();
        // Default range = current Sun-Sat school week
        DateTime today      = DateTime.Today;
        DateTime weekSunday = today.AddDays(-(int)today.DayOfWeek);
        dteFrom.EditValue = weekSunday;
        dteTo.EditValue   = weekSunday.AddDays(6);
        LoadGrid();
    }

    private void InitializeComponent()
    {
        var lblFrom = new LabelControl { Text = "From:", Location = new System.Drawing.Point(12, 16) };
        this.dteFrom = new DateEdit { Location = new System.Drawing.Point(56, 12), Width = 120 };
        var lblTo = new LabelControl { Text = "To:", Location = new System.Drawing.Point(192, 16) };
        this.dteTo = new DateEdit { Location = new System.Drawing.Point(220, 12), Width = 120 };
        this.btnLoad = new SimpleButton { Text = "Load", Location = new System.Drawing.Point(356, 11), Width = 75 };
        this.btnLoad.Click += (s, e) => LoadGrid();

        this.grid = new GridControl
        {
            Location = new System.Drawing.Point(12, 44),
            Size     = new System.Drawing.Size(860, 460),
            Anchor   = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
        };
        this.view = new GridView();
        this.grid.MainView = this.view;
        this.grid.ViewCollection.Add(this.view);
        this.view.OptionsView.ShowGroupPanel = false;
        this.view.OptionsBehavior.Editable   = false;

        AddCol("ContactDate",  "Date / Time", 130).DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm";
        view.Columns["ContactDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
        AddCol("StudentName",     "Student",  160);
        AddCol("GuardianDisplay", "Guardian", 160);
        AddCol("Channel",         "Channel",   80);
        AddOutcomeCol();
        AddCol("Note",         "Note",      220);
        var colPd = AddCol("PromiseDate", "Promise Date", 100);
        colPd.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.DateTime;
        colPd.DisplayFormat.FormatString = "dd-MMM-yyyy";
        var colPa = AddCol("PromiseAmount", "Promise Amt", 100);
        colPa.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
        colPa.DisplayFormat.FormatString = "N0";
        AddCol("LoggedBy",     "Logged By", 100);
        // Hide the technical key column if present
        var idCol = AddCol("ContactId", "Id", 0);
        idCol.Visible = false;

        this.ClientSize = new System.Drawing.Size(884, 516);
        this.Controls.AddRange(new Control[] { lblFrom, dteFrom, lblTo, dteTo, btnLoad, grid });
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "View Interactions";
        this.MinimizeBox = false;
        this.MaximizeBox = true;
    }

    private GridColumn AddCol(string field, string caption, int width)
    {
        var col = new GridColumn
        {
            FieldName    = field,
            Caption      = caption,
            Width        = width,
            VisibleIndex = view.Columns.Count,
        };
        col.OptionsColumn.AllowEdit = false;
        view.Columns.Add(col);
        return col;
    }

    private void AddOutcomeCol()
    {
        var col = AddCol("Outcome", "Outcome", 100);
        view.CustomColumnDisplayText += (s, e) =>
        {
            if (e.Column != col || e.Value == null) return;
            e.DisplayText = e.Value.ToString() switch
            {
                "Contacted"          => "Contacted",
                "NoAnswer"           => "No Answer",
                "ContactUnavailable" => "Unavailable",
                "ContactOff"         => "Phone Off",
                "Promised"           => "Promised",
                "Refused"            => "Refused",
                _                    => e.DisplayText,
            };
        };
    }

    private void LoadGrid()
    {
        try
        {
            DateTime from = dteFrom.DateTime == DateTime.MinValue ? DateTime.Today : dteFrom.DateTime.Date;
            DateTime to   = dteTo.DateTime   == DateTime.MinValue ? DateTime.Today : dteTo.DateTime.Date;
            if (to < from)
            {
                XtraMessageBox.Show("'To' date must be on or after 'From' date.", "View Interactions",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grid.DataSource = _service.GetInteractionsByDateRange(from, to);
            view.RefreshData();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load interactions.\n\n{ex.Message}", "View Interactions",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
```

- [ ] **Step 2: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build73.log
```
Expected: `Build succeeded.` `0 Error(s)`.

- [ ] **Step 3: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.DialogForms/dlgInteractionLog.cs
git commit -m "feat(fees-crm): add View Interactions dialog (date-range interaction review)"
```

---

## Task 6: Ribbon wiring for "View Interactions"

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme/MainForm.cs`

- [ ] **Step 1: Declare the field**

In `MainForm.cs`, after `private DevExpress.XtraBars.BarButtonItem bbiLogInteraction;` (around line 543) add:

```csharp
	private DevExpress.XtraBars.BarButtonItem bbiViewInteractions;
```

- [ ] **Step 2: Construct and wire the button in the Interactions group**

In `MainForm.cs`, in the `// --- Fees Follow-up: Interactions group ---` block (around lines 869-879), after the `bbiLogInteraction.ItemClick += ...` line and before `this.ribbonPageGroupFeesInteractions = ...`, add:

```csharp
			this.bbiViewInteractions = new DevExpress.XtraBars.BarButtonItem();
			this.bbiViewInteractions.Name    = "bbiViewInteractions";
			this.bbiViewInteractions.Caption = "View Interactions";
			this.bbiViewInteractions.ImageOptions.Image      = I_Xtreme.Properties.Resources.FeesReport;
			this.bbiViewInteractions.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.FeesReport;
			this.bbiViewInteractions.ItemClick += (s, e) =>
			{
				using var dlg = new I_Xtreme.DialogForms.dlgInteractionLog();
				dlg.ShowDialog(this);
			};
```

- [ ] **Step 3: Add it to the Interactions group's item links**

In the same block, after `this.ribbonPageGroupFeesInteractions.ItemLinks.Add(this.bbiLogInteraction);` (around line 24879) add:

```csharp
			this.ribbonPageGroupFeesInteractions.ItemLinks.Add(this.bbiViewInteractions);
```

- [ ] **Step 4: Register the item with the ribbon manager**

In the `this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ... })` call (around lines 24881-24882), add `bbiViewInteractions` to the array, e.g. after `bbiLogInteraction`:

```csharp
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[]
				{ bbiFeesSettings, bbiSendReminders, bbiDailyWorklist, bbiGuardianWorklist, bbiStudentWorklist, bbiFeesPrint, bbiFeesPreview, bbiFeesExport, bbiLogInteraction, bbiViewInteractions });
```

- [ ] **Step 5: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Tee-Object notes\IXtreme_build74.log
```
Expected: `Build succeeded.` `0 Error(s)`.

- [ ] **Step 6: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme/MainForm.cs
git commit -m "feat(fees-crm): wire View Interactions ribbon button into Fees Follow-up page"
```

---

## Task 7: Smoke test (whole feature set)

**Files:** none (manual verification)

- [ ] **Step 1: Deploy and launch**

Build is already verified. Deploy the freshly built `IXtreme.exe` (+ `.exe.config`) over the `smoke_test/` mirror of `backup/` and launch it (this requires the local `backup/` and `smoke_test/` set up per CLAUDE.md; if not present, note that the build passing is the available automated signal and ask the user to run the smoke test).

- [ ] **Step 2: Verify each feature**

Open the Fees Follow-up page and confirm:
1. **KPI** — a "Collected This Week (UGX)" card appears at the end of the financial row with a plausible (non-dash) figure.
2. **View Interactions** — the Interactions ribbon group has a "View Interactions" button; clicking it opens the dialog defaulted to this week's Sun–Sat range and lists logged interactions with student, guardian, channel, outcome (friendly text), note, promise, logged-by. Changing dates + Load re-queries.
3. **Critical rule** — with term dates set, a guardian below the phase target (50% first half / 80% second half) with no active future-dated promise shows in the Critical tier (red). A guardian below target but with an active promise does NOT.
4. **Settings** — the Follow-up Settings dialog shows the two new percent inputs; saving and reopening persists them.
5. **Performance** — the dashboard and worklist pages load noticeably faster than before (no per-guardian stall on populated data).

- [ ] **Step 3: Record the result**

If all pass, the feature set is complete. If anything fails, debug per `superpowers:systematic-debugging` before claiming completion.

---

## Notes for the implementer
- Preserve byte-for-byte behaviour everywhere except the explicit changes above (source-recovery rule from CLAUDE.md). Do not rename identifiers, reorder members, or tidy decompiled oddities.
- The `WasContactedToday` and `HasCallRequiredStudent` private helpers become unused after Task 1 but must be left in place (no unrelated deletions).
- All new SQL is parameterised; do not interpolate user/date values into query text.
