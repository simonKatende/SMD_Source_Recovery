# Fees CRM (Bursar Follow-up) — Design

- **Date:** 2026-05-27
- **Status:** approved for implementation planning
- **Author:** Simon Katende (brainstormed with Claude)
- **Task tracker:** Task #3 in this session
- **Depends on:** Task #1 (SMS Guardian repair) — already merged to `main` at `46fbab4`

## 1. Architecture & scope

A new top-level ribbon tab in IXtreme called **Fees Follow-up** that gives the bursar a daily workspace for chasing outstanding fees. Same permission gate as the Accounts ribbon tab (any user who can see Accounts can use Follow-up). The tab opens a two-pane workspace: left = arrears worklist sorted by composite priority, right = currently-selected parent's detail panel (balance snapshot, contact history, new-contact form).

**In scope for v1:**

- Worklist with composite-priority sort and three-tier row colouring (red / yellow / white).
- Per-parent contact log over three channels (SMS / Phone / InPerson), with outcome status, free-text note, optional promise-to-pay date and amount.
- When `Channel=SMS`, the form opens the existing `SMSGuardian` dialog (repaired in Task #1) pre-filled with the parent's preferred contact (`contact1` with `contact2` fallback — the policy from commit `46fbab4`). Contact log entry is only written on a successful send.
- Single new SQL table: `tbl_FeesContactLog`.
- Audit trail: every contact entry stamped with `CurrentUser.GetSystemUser()` and `GETDATE()`.
- Small settings dialog for the bursar-tunable staleness threshold (default 7 days).

**Deliberately out of scope for v1:**

- Bulk SMS reminders. ExtremeMessenger's `userFeesReminder` stays as-is; no absorption.
- Case assignment between roles, escalations, parent-facing portal hooks.
- Configurable channel list — the channel set is a fixed enum (SMS / Phone / InPerson).
- User-tunable priority weights — formula is hardcoded; only the staleness-days threshold is configurable.
- "Show cleared students" toggle on the worklist (balance = 0 students are filtered out).

## 2. Data model

One new table; no schema changes to existing tables.

```sql
CREATE TABLE tbl_FeesContactLog (
  ContactId      INT IDENTITY(1,1) PRIMARY KEY,
  StudentNumber  VARCHAR(50)   NOT NULL,
  ContactDate    DATETIME      NOT NULL DEFAULT GETDATE(),
  LoggedBy       VARCHAR(50)   NOT NULL,        -- CurrentUser.GetSystemUser()
  Channel        VARCHAR(20)   NOT NULL,        -- 'SMS' | 'Phone' | 'InPerson'
  Outcome        VARCHAR(20)   NOT NULL,        -- 'NoAnswer' | 'Contacted' | 'Promised' | 'Refused' | 'WrongContact'
  Note           NVARCHAR(500)     NULL,
  PromiseDate    DATE              NULL,        -- non-null iff Outcome='Promised'
  PromiseAmount  MONEY             NULL         -- null = "promised the full current balance at promise time"
);

CREATE INDEX IX_FeesContactLog_Student
  ON tbl_FeesContactLog (StudentNumber, ContactDate DESC);
```

Notes on the model:

- `StudentNumber` is the link column. This matches how `FeesPayment` and the rest of the app reference students. No strict foreign-key constraint added because existing tables don't enforce one either — staying consistent with the codebase.
- Composite priority is **computed at query time** from `tbl_Stud.cashOnAccount` plus the latest row per student in `tbl_FeesContactLog`. No denormalised priority columns to keep in sync.
- The `Channel` and `Outcome` columns are stored as strings rather than `int` enums for SQL readability and easier ad-hoc reporting. The set of valid values is enforced in C# code, not by a CHECK constraint, to match existing conventions.

## 3. Priority scoring formula

Three tiers, ranked. Within each tier, rows sort by `cashOnAccount` descending. Computed at worklist load.

| Tier | Colour | Definition |
|------|--------|-----------|
| 1. Broken promise | Red | The latest contact for this student has `Outcome='Promised'`, `PromiseDate < today`, **and** total `Credit` in `FeesPayment` for this student since the promise's `ContactDate` is less than `PromiseAmount`. If `PromiseAmount` is null, it's compared against the balance at promise time, which is approximated as `(current cashOnAccount) + (payments since promise)`. |
| 2. Stale | Yellow | `cashOnAccount > 0`, and either there is no contact log entry at all, or the latest entry's `ContactDate` is older than the staleness threshold (default 7 days; bursar-configurable). |
| 3. Current | Default | `cashOnAccount > 0`, not in tier 1 or 2. |

Implementation note: the worklist runs a single SQL query joining `tbl_Stud` to the latest `tbl_FeesContactLog` row per student (via `ROW_NUMBER() OVER (PARTITION BY StudentNumber ORDER BY ContactDate DESC) = 1`). The broken-promise tier needs one extra `SUM(Credit)` subquery per row in tier 1 — at primary-school scale (~500 pupils, of whom <100 will be on the worklist) this remains a sub-second query. No denormalisation needed for v1.

## 4. UI layout

New `UserControl` `usrFeesFollowUp.cs` in `I_Xtreme.NavigationForms`, mounted on a new ribbon tab page **Fees Follow-up** in `MainForm`.

**Top-level layout:** `DevExpress.XtraEditors.SplitContainerControl` (vertical split, left ~55%, right ~45%, user-resizable).

**Left pane — worklist:**

```
┌─ Filter bar ─────────────────────────────────────────┐
│ Class: [All ▾]  Min balance: [____]  [Refresh]       │
├──────────────────────────────────────────────────────┤
│ ●  Class  Student          Balance  LastContact  Outc.│
│ R   P.4   Mukasa John      250,000  2026-05-20  Prom.│
│ R   P.2   Nakato Sarah     180,000  (none)      —    │
│ Y   P.6   Ssali Ivan        95,000  2026-05-15  NoAns│
│ ·   Baby  Achieng Hope      40,000  2026-05-26  Cont.│
└──────────────────────────────────────────────────────┘
```

`GridControl` + `GridView`. Row colour is driven by a `FormatConditionRuleExpression` keyed on the tier (computed column in the data source). Default sort: tier ascending, balance descending. The `●` column is a visual badge derived from tier.

**Right pane — selected parent's detail:**

```
┌─ Mukasa John  •  P.4  •  Balance UGX 250,000 ───────┐
│ Last 3 payments: 50k (2026-04-10), 100k (2026-03-15)│
├─ Contact history ────────────────────────────────────┤
│ Date         Channel  Outcome   Note          By     │
│ 2026-05-20   Phone    Promised  "by Friday"   simon  │
│ 2026-05-12   SMS      —         "reminder"    simon  │
├─ Log new contact ────────────────────────────────────┤
│ Channel:  (•) SMS   ( ) Phone   ( ) InPerson         │
│ Outcome:  [Contacted        ▾]                       │
│ Note:     [____________________________________]     │
│ [Promise date: ____] [Promise amount: ____]          │   ← shown only when Outcome=Promised
│ [Save] [Save & next →]                               │
└──────────────────────────────────────────────────────┘
```

`Save & next →` saves the current entry and advances the worklist selection to the next row, so the bursar can power through without mouse-hunting.

**Channel=SMS save flow** (selected during brainstorming): clicking **Save** opens `SMSGuardian` pre-populated with the parent's preferred phone number. The contact-log entry is written **only after** a successful send (i.e. `SMSGuardian.ShowDialog() == DialogResult.OK`). Cancel / failure → no entry written. The `Outcome` and `Note` fields from the panel are carried into the log entry; the SMS message body is appended to the note.

**Settings dialog (small, separate):** one numeric field — *Staleness threshold (days)*, default 7. Opened via a small **Settings** button on the ribbon tab.

## 5. Integration touchpoints & migration

**`SMSGuardian` enhancement (small, backward-compatible):**

Currently `SMSGuardian.simpleButton1_Click` ends with `XtraMessageBox.Show(...); Dispose();` on success. Add `base.DialogResult = DialogResult.OK;` before the `Dispose()` call so a caller using `ShowDialog()` can detect success. Existing callers (`usrStudentList`, `usrStudentActivator`) ignore the return value, so this doesn't affect them. Also set `DialogResult.Cancel` in `simpleButton2_Click` (the Cancel button) for symmetry.

**Role gating:**

The new ribbon tab respects whichever flag currently gates the Accounts tab in `MainForm`. Likely candidates from a previous grep: `MainForm.canBill`, `canPayIn`, `canEditFees`. The implementation plan will identify the right flag. If no clean mapping exists, add a new `canFeesFollowUp` flag to the role system, defaulting to `true` for any role that currently has any fees access — nobody should lose access by upgrading.

**Settings storage:**

The staleness threshold is one integer. Rather than creating a new single-row table, store it in whatever existing app-settings table the code uses (likely a key-value table — the implementation plan will identify it). If no suitable table exists, create `tbl_FollowUpSettings` with one row.

**Migration:**

`notes/migrations/2026-05-27_create_tbl_FeesContactLog.sql` (new `notes/migrations/` subfolder; matches the existing `notes/` convention). Contains the `CREATE TABLE` and `CREATE INDEX` statements. **Not auto-applied** — per `CLAUDE.md`, never run SQL that modifies the schema without the user's explicit approval. The script is committed alongside the code change; Simon runs it manually against the school's SQL Server before the first launch of the new tab.

## 6. Edge cases, error handling, testing

**Edge cases handled in v1:**

- Student with no contact log entries yet → "Stale" tier (since never contacted); `LastContact` displays as `(none)` in the worklist.
- `PromiseAmount IS NULL` → treated as "promised the whole balance at promise time" (approximated as current balance + payments since promise).
- Multiple promises stacked → only the latest `Outcome='Promised'` contact is checked for broken-promise tier classification. Older promises sit in the history.
- Student with `cashOnAccount = 0` → not on worklist, even if there's contact history. ("Show cleared" toggle is a deferred enhancement.)
- Student missing both `contact1` and `contact2` → SMS channel radio button is disabled; only Phone / InPerson are selectable.
- Transferred / graduated students → if `cashOnAccount > 0`, they appear on the worklist; if zero, they don't. No special-casing for `StudyStatus`.

**Error handling:**

- DB connection / SQL errors during worklist load → DevExpress error dialog; the grid keeps its previously-loaded data rather than clearing.
- SMS send failure (after Task #1's refactor, errors propagate cleanly) → error toast in `SMSGuardian`, **no contact log entry written**, bursar can retry from the same form.
- Save contact entry fails → error toast in the right pane, form keeps its field values so the bursar can retry without re-typing.
- Two bursars logging contacts for the same parent simultaneously → no conflict (each is a separate `INSERT`); the worklist won't reflect the other bursar's entry until refresh.

**Testing approach:**

No automated test suite exists in the project (per `CLAUDE.md`). Manual smoke test against `smoke_test\IXtreme.exe`:

1. Open the new Fees Follow-up tab → worklist loads with arrears, sorted by tier.
2. Select a parent → right pane shows their balance, recent payments, empty contact history, and the new-contact form.
3. Log a Phone contact with `Outcome=Promised`, `PromiseDate=tomorrow` → entry appears in the history table; row moves to "Current" tier on next refresh (just contacted).
4. Set the staleness threshold to 0 days → on refresh, all "Current" rows go yellow.
5. Log a Promised contact with `PromiseDate=yesterday` and no payment since → row flips to red on refresh (broken promise).
6. Pick an SMS contact → `SMSGuardian` opens pre-filled with the parent's preferred contact → send → verify both that the SMS arrives and that a `Channel='SMS'` entry is written to the log.
7. Cancel `SMSGuardian` instead of sending → confirm no log entry is written.
8. Regression: confirm the existing payment-acknowledgement SMS and the other Task #1 flows still work end-to-end on the rebuilt EXE (the only Task-#1 file we change is `SMSGuardian.cs`, and only to add `DialogResult` setting).

## Open questions deferred to implementation

These were intentionally not pinned down during design because they're cheap to resolve from the code:

- Exact ribbon-tab gating flag (one of `canBill` / `canPayIn` / `canEditFees`, or new `canFeesFollowUp`).
- Exact settings table name (re-use existing key-value table, or new `tbl_FollowUpSettings`).
- Exact class-list source for the "Class" filter (presumably an existing classes table or DataSet used by `userFeesReminder`).
