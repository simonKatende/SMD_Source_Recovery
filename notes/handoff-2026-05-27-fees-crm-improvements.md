# Fees Follow-up CRM — Improvements Handoff
**Date:** 2026-05-27  
**Branch:** `feat/fees-crm`  
**HEAD:** `5a15104`

---

## What was built

A "Fees Follow-up" ribbon tab in the `IXtreme` WinForms desktop application
(Alien Age School Management Dynamics). It is a two-pane workspace:

- **Left pane** — Arrears worklist (`gridWorklist`), sorted by priority tier
  (Missed Promise → Contact Overdue → Up to Date), then balance descending.
  Filter by class and minimum balance. Refresh and Settings buttons in the
  filter strip.
- **Right pane** — Per-student contact detail: header (name / class / balance),
  last 2 payments strip, contact-history grid, and a new-contact form
  (channel, outcome, promise date/amount, note, Save / Save & next).

All 13 plan tasks complete and smoke-tested. Four post-smoke bugs were also
fixed (split orientation, row click, balance format, Promise Amount format).

### Key files

| File | Role |
|---|---|
| `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` | Main user control (~490 lines) |
| `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` | All SQL: worklist, log, history, payments |
| `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs` | Settings dialog (overdue threshold) |
| `decompiled/IXtreme/I_Xtreme.DialogForms/SMSGuardian.cs` | SMS send dialog (modified: DialogResult wiring) |
| `decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs` | Model + `ContactChannel` / `ContactOutcome` enums |
| `decompiled/IXtreme/I_Xtreme.Models/WorklistRow.cs` | Worklist row model + `PriorityTier` enum |
| `decompiled/IXtreme/I_Xtreme/MainForm.cs` | Ribbon wiring, visibility gating |
| `notes/migrations/2026-05-27_create_tbl_FeesContactLog.sql` | Migration (already run on school DB) |

### DB tables (already exist on school SQL Server)

- `tbl_FeesContactLog` — contact log entries
- `tbl_FollowUpSettings` — key/value settings (StalenessThresholdDays = 7)

---

## Current enum values

```csharp
// ContactChannel
SMS, Phone, InPerson

// ContactOutcome
NoAnswer, Contacted, Promised, Refused, WrongContact

// PriorityTier  (1 = highest)
BrokenPromise = 1, Stale = 2, Current = 3
```

---

## Improvements to brainstorm and plan

These came directly from the user after smoke-testing. The session should
**brainstorm** then produce a numbered implementation plan (one plan task =
one commit, same pattern as `docs/superpowers/plans/2026-05-27-fees-crm.md`).

### Bug / polish (implement before new features)
1. **Promise Amount format** — fixed in `5a15104`. No action needed.

### Improvements (user-requested, in priority order as stated)

1. **Edit / Delete contact log rows** — Right-click on a history row shows a
   context menu with "Edit" and "Delete". Edit either repopulates the new-contact
   form below OR enables inline edit on that row. Delete removes the row from
   `tbl_FeesContactLog` (confirm first).

2. **Back-dated contact date** — Add a "Contact date" field to the new-contact
   form. Default = today. Allow the user to enter any past date. Maps to the
   `ContactDate` column already in `tbl_FeesContactLog`.

3. **Settings moved to Fees Follow-up ribbon** — Currently a "Settings" button
   lives in the filter strip of the worklist. User wants it in the ribbon bar
   (like the Print/Preview/Export group in the Students ribbon — see Image #7).
   The Fees Follow-up ribbon page currently has no ribbon groups at all.

4. **Double-click worklist row → open student ledger** — Double-clicking a row
   on the worklist should open the same `Fees Payment` dialog that the Students
   tab opens (`frmFeesPay` or the equivalent). The student number is available
   on the `WorklistRow`. Need to identify the exact class/method to call.

5. **Last 2 payments, active term only** — Currently "Last 3 payments" pulls
   from all time. Change to top 2 payments for the current semester
   (`tbl_SystemSettings` or `SystemTerm.CurrentTerm()` / `Semester` column on
   `FeesPayment`). `FeesPayment` has a `Semester` column (e.g. `TermII-2026`).
   `GetRecentPayments()` in `FeesFollowUpService` needs the active term filter.

6. **Rich student header** — Replace the plain text header label with a panel
   showing: student photo (left-aligned, same source as `tbl_Stud.Picture`),
   student name + student ID + class (right of photo), guardian 1 contact,
   guardian 2 contact, guardian relationship. Data already exists in `tbl_Stud`
   columns: `Picture`, `fullName`, `StudentNumber`, `ClassId`, `PriorityContact`,
   `OtherContact`, `Guardian` (relationship/name).

7. **Auto-fit columns on load** — Call `gridViewWorklist.BestFitColumns()` and
   `gridViewHistory.BestFitColumns()` after data bind so all content is visible
   without manual resizing. Column widths should reflect content, except Note
   which can be capped at a fixed max width (e.g. 200 px).

8. **Print / Preview / Export ribbon group** — Add a `RibbonPageGroup`
   ("Printing & Exporting") to the Fees Follow-up ribbon page with Print,
   Preview, Export buttons — same visual pattern as the Students ribbon
   (see Image #7). Target: export/print the current worklist grid
   (`gridWorklist`). DevExpress `PrintingSystem` / `XtraGrid` built-in export.

9. **Row count column** — Add a `#` auto-increment column to both the worklist
   and the history grid, like the `#` column on the Students list (see Image
   #8). DevExpress `GridView` exposes this via
   `gridView.IndicatorWidth` + a `CustomDrawRowIndicator` event, OR a
   calculated unbound column.

10. **Revised outcome list + priority impact** — Replace the `ContactOutcome`
    enum with:
    `Contacted, NoAnswer, ContactUnavailable, ContactOff, Promised, Refused`
    (note new values: `ContactUnavailable`, `ContactOff`; remove `WrongContact`).
    Triage impact: outcomes `NoAnswer`, `ContactUnavailable`, `ContactOff`,
    `Refused` should raise priority (treated similarly to or above `Stale`).
    This requires: enum change, DB migration (new `Outcome` values fit in the
    existing `VARCHAR(20)` column), `ComputeTier()` logic update, display-text
    mappings, and `ConfigureWorklistColumns` friendly-name update.
    **This is a schema-touching change — draft migration SQL.**

11. **Auto-log SMS contacts** — Sending a guardian an SMS from the Students tab
    (`usrStudentList.navBarItem18_LinkClicked`) or from ExtremeMessenger bulk
    fees reminders should automatically write a row to `tbl_FeesContactLog`
    (Channel=SMS, Outcome=Contacted, LoggedBy=current user, Note=message text).
    Requires identifying the student number at the call site and calling
    `FeesFollowUpService.LogContact()`.

---

## Technical context for the brainstorm

- **Build:** `dotnet build decompiled/IXtreme/IXtreme.csproj` → output in
  `bin/Debug/net472/`. Stage to `smoke_test/IXtreme.exe` for manual testing.
- **No automated tests.** Verification = build + smoke test.
- **Per-task commits.** Every plan task ends with exactly one commit.
- **Commit trailer:** every message ends with
  `Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>`
- **UI framework:** DevExpress v23.2 (XtraBars, XtraGrid, XtraEditors).
- **Data access:** ADO.NET (`SqlConnection`/`SqlDataAdapter`), connection string
  from `AlienAge.Connectivity.DataConnection.ConnectToDatabase()`.
- **Current user:** `I_Xtreme.CurrentUser.GetSystemUser()` → `"group/fullName"`.
- **Active term:** look up `AlienAge.SystemSettings` or query
  `tbl_SystemSettings` for the current semester string.
- **Student ledger dialog:** need to identify class name from existing Students
  tab code before planning item #4.
- **Migrations are manual** — write SQL to `notes/migrations/` and note in plan
  that user must run it before launching.
- **`backup/` and `smoke_test/` are gitignored** — never commit either.
