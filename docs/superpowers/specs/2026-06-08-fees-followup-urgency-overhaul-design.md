# Fees Follow-up — Deadline-Aware Urgency Overhaul (Design)

Date: 2026-06-08
Status: Approved (pending spec review)
Scope: Audit findings F1–F9 of the daily-worklist / priority-tier logic.

## Goal

The daily worklist must direct the bursar's limited time to the guardians who, if
not chased, will cause the school to miss **98% fee collection by term end**. The
current logic flags current distress well but (a) stops escalating partial-payers
once they cross a flat 80% target, (b) floods the Critical tier in the second half
so the tier loses meaning, and (c) orders the daily list by raw balance with a
sticky `CallRequired` flag pinned above genuine risk. This overhaul makes the
logic deadline-aware and ranks by money genuinely at risk.

## Core model decision

Keep the `PriorityTier` enum for **row color and dashboard grouping only**.
Introduce a continuous **`UrgencyScore`** that is the single sort key for every
worklist. "How urgent (for ranking)" and "what bucket (for color)" become
independent concerns. No new tier is added; "behind but not critical" is expressed
purely through the score.

## Components

### 1. Required-payment line (F1)

New setting `CollectionGoal` (default `0.98`).

```
termProgress = clamp(elapsedDays / totalDays, 0, 1)        // existing calc
requiredPct(today) = CollectionGoal * termProgress * 100   // 0..98
```

On day 1 ≈ 0%, midterm ≈ 49%, final week ≈ 90%+, term end = 98%. This is what
finally flags the 80–98% cohort as the deadline nears.

The flat phase targets `FirstHalfMinPercent` / `SecondHalfMinPercent` are
**removed** from the tier logic and from `FeesFollowUpSettings` (and the settings
dialog). A migration note records that their stored keys become dead.

### 2. Shortfall + single Critical rule (F2)

```
shortfall = requiredPct - PaymentPercent      // percentage points; <=0 = on/ahead of pace
```

New setting `CriticalShortfallPoints` (default `25`).

`ComputeGuardianTier` Critical logic is replaced by **one** rule:

```
if hasTermDates && shortfall >= CriticalShortfallPoints && !hasActivePromise
    => Critical
```

The old pacing-gap Critical rule (`PacingGap >= CriticalPacingGapThreshold`) and
the flat-phase Critical rule are both removed. The no-progress escalation rule,
broken-promise rule, and stale rule are retained as today. With term dates unset,
Critical via shortfall cannot fire (see F7 degrade behavior).

`CriticalPacingGapThreshold` is retired from logic; `PacingGap` is still computed
and displayed (it is informative in the grid) but no longer gates a tier.

### 3. UrgencyScore — master sort key (F3, F4, F5)

Pure static function `ComputeUrgencyScore(GuardianWorklistRow, shortfall, callRequired, hasCoveringActivePromise)`:

```
base       = TotalBalance                              // money still owed
shortfallX = 1 + max(0, shortfall) / 50.0              // ~1x..2x as they fall behind the line
behaviorX  = 1.0
           * (brokenPromise           ? 1.5 : 1.0)     // engaged then defaulted = high leverage
           * (failedLastOutcome       ? 1.3 : 1.0)     // Refused / NoAnswer / Off / Unavailable
           * (callRequired            ? 1.4 : 1.0)     // recent overdue SMS, windowed (see #4)
           * (hasCoveringActivePromise? 0.4 : 1.0)     // committed -> de-emphasise, do not zero
UrgencyScore = base * shortfallX * behaviorX
```

`failedLastOutcome` uses the existing `FailedOutcomes` set. `brokenPromise` is true
when the row's computed tier is `BrokenPromise` (tier is computed before score).
`hasCoveringActivePromise` is an active promise (date >= today) whose amount covers
>= `PartialPromiseCoverageThreshold` of `TotalBalance`.

**Two distinct promise conditions (intentional, not a contradiction):**
- The Critical rule (#2) is suppressed by *any* active promise (`!hasActivePromise`),
  matching today's behavior — a guardian who has committed should not read as Critical.
- The `0.4` score multiplier applies only to a *covering* active promise. A small,
  non-covering promise therefore lifts the guardian out of the Critical label but does
  **not** bury them in rank — correct, since they still owe most of the balance.

**Both** `GetGuardianWorklist` and `GetDailyWorklist` sort by `UrgencyScore`
descending (replacing `Tier`→`PacingGap`→`Balance` and `Tier`→`Balance`
respectively). `GetStudentWorklist` inherits guardian `UrgencyScore` and sorts by
it, then class/name.

`UrgencyScore` is added to `GuardianWorklistRow` (and surfaced as an optional grid
column for transparency).

Worked-example check: 95%-paid / 100k-balance CallRequired guardian scores
`100k × 1.0 × 1.4 = 140,000`; 2M-balance / 50%-paid critical scores in the
millions → genuine risk ranks first without tier-order hacks.

### 4. CallRequired windowed (F3)

`CallRequiredCte` is restricted to Overdue SMS sent within the last
`CallRequiredWindowDays` (new setting, default `14`) for guardians who still owe.
The flag now feeds the `1.4x` score multiplier. The `CallRequired` enum member is
**retained** for row color, but the unconditional `row.Tier = CallRequired`
override that pinned these rows above Critical is **removed** — ranking is by score.

### 5. Term dates: warn + degrade (F7)

`DashboardData` gains `TermDatesConfigured` (bool). When false:
- `usrDailyWorklist`, `usrGuardianWorklist`, and the dashboard show a persistent,
  non-blocking banner: "Term start/end not set — deadline-based prioritisation is
  off. Set them in Follow-up Settings."
- Lists still load; shortfall/Critical/required-line simply do not fire.

No change to settings save behavior (not blocking).

### 6. Partial-promise resurface near deadline (F6)

New setting `PromiseResurfaceDays` (default `14`). In `GetDailyWorklist`, the
promise-suppression branch is **skipped** (guardian stays on the list) when term
dates are set and `(TermEndDate - today).Days <= PromiseResurfaceDays`. Earlier in
term, suppression behaves as today. The `GetDashboardData.DailyListTotal`
calculation mirrors the same condition.

### 7. NOCONTACT flag-in-place (F9)

`GuardianWorklistRow.IsUnreachable` (computed): true when `GuardianContact` starts
with `NOCONTACT-` or is blank. Both grids render unreachable rows with a muted
appearance via the existing `RowStyle` hook and append a "(no phone)" hint to the
guardian display. They remain in the list (they still owe) but are visually
skippable on a call pass. Shared-phone over-merge detection is **not** included
this round (documented as a known limitation; low volume).

### 8. Dashboard on-track indicator (F8)

`DashboardData` adds:
- `RequiredRateToday` = `CollectionGoal * termProgress * 100` (= the required line).
- `ProjectedCollectionRate` = `CollectionRate / termProgress`, capped at 100,
  `0` when `termProgress == 0` (simple linear extrapolation of current pace to
  term end).
- `AmountBehindPace` (UGX) = `max(0, RequiredRateToday/100 * TotalPayable - TotalCollected)`.

Surfaced as a KPI: "On track for {goal}%?" with the projected rate and, when
behind, "behind by {AmountBehindPace}". Shows "—" when term dates unset.

## New / changed settings summary

| Key | Default | Replaces | Unit |
|---|---|---|---|
| `CollectionGoal` | 0.98 | — | fraction 0–1 |
| `CriticalShortfallPoints` | 25 | `CriticalPacingGapThreshold` (logic) | percentage points |
| `CallRequiredWindowDays` | 14 | — | days |
| `PromiseResurfaceDays` | 14 | — | days |
| `FirstHalfMinPercent` | (removed) | — | — |
| `SecondHalfMinPercent` | (removed) | — | — |

Settings dialog (`FollowUpSettings.cs`): remove the two phase-percent rows; add
rows for `CollectionGoal` (shown as %), `CriticalShortfallPoints`,
`CallRequiredWindowDays`, `PromiseResurfaceDays`. `CollectionGoal` stored as
fraction (value/100), the rest as whole numbers, matching the existing
unit conventions in CLAUDE.md.

## Data flow (unchanged shape)

`GetSettings` → `GetGuardianWorklist` (SQL build + per-row tier + shortfall +
`UrgencyScore`, sorted by score) → `GetDailyWorklist` (promise/contacted filter
with deadline-aware resurface, sorted by score) and `GetDashboardData`
(aggregates + on-track KPIs). UIs bind the lists and apply color/banner/flag.

## Error handling

No new external calls. Division guards: `termProgress == 0`, `TotalBalance == 0`,
`TotalBilled == 0` all already guarded or guarded in new code. Unset term dates is
a first-class state, not an error.

## Testing / verification

No test suite exists in the repo; verification today is "does the EXE launch."
The tier/shortfall/score logic is pure and static, so:

1. Extract `requiredPct`, `shortfall`, `ComputeGuardianTier`, and
   `ComputeUrgencyScore` as pure static methods with no DB dependency.
2. Add a minimal throwaway scenario harness (a small console/`xUnit` snippet, not
   committed to the build) asserting the worked-example orderings:
   - 81%-paid guardian in final week is flagged (shortfall ≥ threshold) — F1.
   - second-half mid-payers no longer all become Critical at midterm — F2.
   - 95%-paid CallRequired ranks below a 2M/50% Critical — F3/F4.
   - broken promise outranks an equal-balance on-pace guardian — F5.
3. `dotnet build decompiled\IXtreme\IXtreme.csproj` clean.

Exact harness form (committed test project vs. throwaway) to be confirmed in the
plan.

## Out of scope

- Shared-phone over-merge detection (F9 second half).
- Reworking the legacy student-level `GetWorklist` / `ComputeTier` path (unused by
  the new pages).
- SMS template/reminder cadence changes.

## Known limitations after this change

- `ProjectedCollectionRate` is naive linear extrapolation; early-term projections
  are noisy (mitigated by showing it only as a directional KPI).
- Over-merged shared phones still aggregate as one family.
