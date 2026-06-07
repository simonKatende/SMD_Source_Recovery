# Fees Follow-up Improvements — Design

**Date:** 2026-06-07
**Module:** IXtreme Fees Follow-up CRM
**Status:** Approved, pending implementation plan

## Overview

Four improvements to the Fees Follow-up module, requested by the bursar:

1. Show total fee collection for the current week.
2. Let the bursar review all logged interactions for any given date (defaulting to the current week).
3. Escalate a guardian to Critical when their payment percentage is below the expected level for the current term phase and they have no active promise.
4. Optimise page loads (dashboard and worklists) by eliminating per-guardian database round-trips.

All work lives in the IXtreme project under `decompiled/IXtreme/`. Primary files:

- `I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` — data access + tier logic
- `I_Xtreme.Models/GuardianWorklistRow.cs` — DTOs (`GuardianWorklistRow`, `DashboardData`, `FeesFollowUpSettings`)
- `I_Xtreme.NavigationForms/usrFeesFollowUp.cs` — dashboard UI (KPI strip)
- `I_Xtreme.DialogForms/FollowUpSettings.cs` — settings dialog
- `I_Xtreme.DialogForms/dlgInteractionLog.cs` — **new** interaction-review dialog
- `I_Xtreme/MainForm.cs` — ribbon wiring

No database schema changes are required. New settings keys are created lazily by the existing `Upsert` pattern in `tbl_FollowUpSettings`.

## Guiding constraint

This is a source-recovery codebase. Preserve existing behaviour byte-for-byte except where a change is explicitly specified below. Do not refactor, rename, or reorganise unrelated code. Follow the patterns already present in `FeesFollowUpService` and the navigation forms.

---

## Feature 1 — "Collected This Week" KPI

### Behaviour
Display total payments received during the current school week on the dashboard KPI strip.

- **Week definition:** the same Sun–Sat school week the dashboard already uses. Week start = the Sunday on or before today: `weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek)`.
- **Amount:** sum of `Credit` in `FeesPayment` for the current semester, on or after `weekStart`.

### Data
Extend the existing `GetDashboardTotals` query (or its result struct) so the weekly figure is fetched in the same round-trip — no new connection. Add to the `DashboardTotals` struct a `CollectedThisWeek` decimal and compute it via:

```sql
SELECT ISNULL(SUM(Credit), 0)
FROM FeesPayment
WHERE SemesterId = @currentSemester
  AND Credit > 0
  AND DateOfPayment >= @weekStart
```

`@weekStart` is passed as a `SqlDbType.Date` parameter computed in C#.

### Model
Add `public decimal CollectedThisWeek { get; set; }` to `DashboardData`. Set it from the totals in `GetDashboardData`.

### UI
In `usrFeesFollowUp`:
- Grow `_kpiValues` from `new Label[11]` to `new Label[12]`.
- Add a 12th KPI card "Collected This Week (UGX)" built as `BuildKpiCard(11, ...)`, colour `Color.SeaGreen`. The label slot is keyed by the index argument, independent of insertion order; insert this card into `_kpiPanel.Controls` immediately after the "Total Enrolled" card (index 4) so it renders at the end of Row 1 (financial totals).
- In `UpdateKpiStrip`, set `_kpiValues[11].Text = $"{data.CollectedThisWeek:N0}"`.

Card is non-clickable (no navigation).

---

## Feature 2 — "View Interactions" dialog

### Behaviour
A modal dialog, opened from a new ribbon button, that lists every interaction logged within a date range. Date range defaults to the current Sun–Sat week; the bursar can narrow to a single day or widen it.

### UI: `dlgInteractionLog` (new, in `I_Xtreme.DialogForms`)
- Two `DateEdit` pickers, **From** and **To**.
  - From default = current week's Sunday (`Today.AddDays(-(int)Today.DayOfWeek)`).
  - To default = that Sunday + 6 (Saturday).
- A "Refresh"/"Load" button (or reload on date change) that re-runs the query.
- A read-only `GridControl`/`GridView` (follow the pattern in the existing worklist forms) with columns:
  - **Date/Time** (`ContactDate`, formatted `dd-MMM-yyyy HH:mm`)
  - **Student** (`StudentName`)
  - **Guardian** (Guardian name + relation; fall back to phone)
  - **Channel**
  - **Outcome** (rendered with the same display names used elsewhere — e.g. "Missed Promise" — via a value→display map; the raw enum value still backs sorting/filtering)
  - **Note**
  - **Promise Date** (`PromiseDate`)
  - **Promise Amount** (`PromiseAmount`, `N0`)
  - **Logged By** (`LoggedBy`)
- Grid is non-editable. Sorted by `ContactDate DESC`.

### Data: new service method
```csharp
public DataTable GetInteractionsByDateRange(DateTime fromInclusive, DateTime toInclusive)
```
- Query `tbl_FeesContactLog cl LEFT JOIN tbl_Stud s ON s.StudentNumber = cl.StudentNumber`.
- Filter `cl.ContactDate >= @from AND cl.ContactDate < @toExclusive`, where `@toExclusive = toInclusive.Date.AddDays(1)` so the entire To-day is included regardless of time component.
- Select: `ContactId, ContactDate, s.fullName AS StudentName, s.Guardian, s.GuardianRelation, cl.Channel, cl.Outcome, cl.Note, cl.PromiseDate, cl.PromiseAmount, cl.LoggedBy`.
- Order by `cl.ContactDate DESC`.
- Parameters use `SqlDbType.DateTime`.

### Ribbon wiring (`MainForm.cs`)
- Add a `bbiViewInteractions` bar button item under the Fees Follow-up ribbon group, alongside `bbiDailyWorklist` / `bbiGuardianWorklist` / `bbiStudentWorklist`.
- `ItemClick` opens the dialog modally: `using var dlg = new I_Xtreme.DialogForms.dlgInteractionLog(); dlg.ShowDialog(this);`

---

## Feature 3 — Phase-based payment-shortfall → Critical

### Behaviour
In addition to the existing pacing-gap rule, a guardian becomes Critical when, **with term dates configured**, their payment percentage is below the minimum expected for the current term phase **and** they have no active promise.

- **Term phase split:** mid-term = the date midpoint, `TermStart + (TermEnd - TermStart) / 2`.
- **Phase target:** `today < midterm ? FirstHalfMinPercent : SecondHalfMinPercent`.
- **Active promise:** `LatestPromiseDate.HasValue && LatestPromiseDate.Value.Date >= DateTime.Today`.
- **Critical condition (new):** `hasTermDates && (double)g.PaymentPercent < phaseTarget && !hasActivePromise`.

The existing `PacingGap >= CriticalPacingGapThreshold` rule is retained. Either rule triggers Critical (logical OR). Both sit at the top of `ComputeGuardianTier`, before BrokenPromise and Stale evaluation.

### Settings
Add to `FeesFollowUpSettings` (in `GuardianWorklistRow.cs`):
- `public double FirstHalfMinPercent { get; set; } = 50.0;`
- `public double SecondHalfMinPercent { get; set; } = 80.0;`

Wire into `FeesFollowUpService.GetSettings()` and `SaveSettings()` using the existing `Upsert` / `TryGetValue` + `InvariantCulture` parse pattern. Keys: `FirstHalfMinPercent`, `SecondHalfMinPercent`. Defaults 50 / 80 when absent.

Surface both in the `FollowUpSettings` dialog as percentage inputs (follow the existing control pattern for `NoProgressPaymentThreshold`).

### Logic
`ComputeGuardianTier` gains parameters for the two phase targets and a precomputed `hasActivePromise` (or computes it from the row). Mid-term and phase target are derived in `GetGuardianWorklist` where term dates are already in scope, and passed in — keeping `ComputeGuardianTier` pure. The phase rule is gated on `hasTermDates` exactly like the pacing rule.

---

## Feature 4 — Performance: eliminate per-guardian round-trips

### Problem
`GetGuardianWorklist` runs `WasContactedToday` and `HasCallRequiredStudent` once **per guardian** (a loop of separate `SqlConnection`s). `GetDashboardData` then loops every guardian calling `WasContactedToday` **twice more** each, and `GetDailyWorklist` calls it again per guardian. A dashboard load is roughly `1 + ~3N` connections for N guardians.

### Fix
Fold the two per-guardian lookups into the single main `GetGuardianWorklist` query as aggregate CTEs keyed by GuardianKey:

- `ContactedTodayCte`: from `tbl_FeesContactLog`, guardians with a row today whose `Outcome IN ('Contacted','Promised','Refused')` (matches current `WasContactedToday`).
- `CallRequiredCte`: from `tbl_SmsReminderLog`, guardians with any `ReminderType = 'Overdue'` (matches current `HasCallRequiredStudent`).

Both are LEFT JOINed to the result by `ContactKey`/`GuardianKey`, surfaced as new bool properties on `GuardianWorklistRow`:
- `public bool ContactedToday { get; set; }`
- `public bool CallRequired { get; set; }`

Then:
- `GetGuardianWorklist`: drop the per-row `HasCallRequiredStudent` connection loop; set `row.Tier = PriorityTier.CallRequired` from `row.CallRequired`. (CallRequired override stays last, exactly as today.)
- `GetDailyWorklist`: replace `WasContactedToday(g.GuardianContact)` with `g.ContactedToday`.
- `GetDashboardData`: replace both `WasContactedToday` calls with `g.ContactedToday`.

The standalone `WasContactedToday` / `HasCallRequiredStudent` helpers may remain if still referenced elsewhere; if not referenced after this change, leave them in place (no unrelated deletions) but they will no longer be on the hot path.

### Invariant
No change to displayed numbers, tiers, daily-list membership, or sort order. This is purely a round-trip reduction. Verify by comparing dashboard KPIs and worklist contents before/after on the smoke-test database.

---

## Out of scope
- No changes to SMS reminder sending.
- No Excel export / print for the interaction dialog (dialog is review-only).
- No database schema migrations.

## Verification
- Build `decompiled/IXtreme/IXtreme.csproj` clean (net472, x86).
- Smoke test: launch the rebuilt EXE, open Fees Follow-up, confirm the new KPI shows a plausible weekly figure, the View Interactions dialog lists the current week's logs, settings persist the two new thresholds, and a guardian below the phase target with no active promise shows Critical.
- Confirm dashboard/worklist load is visibly faster on a populated database.
