# Fees CRM v2 — Session Handoff (2026-05-30)

## What Was Built

A complete Fees Follow-up daily operations tool built on top of the IXtreme
WinForms app. All 12 planned tasks are committed to `main`. The rebuilt EXE is
in `smoke_test/`.

### Features shipped

| Area | What it does |
|---|---|
| KPI dashboard | 5 cards (Total Outstanding, Collection Rate, Guardians with Balance, Today's Remaining, Broken Promises), priority breakdown grid, top-5 by balance grid |
| Daily Worklist dialog | Guardians not yet contacted today, excludes those with active future promises; search, print, export |
| Guardian Worklist dialog | All guardians with balance; class + min-balance filter, search, print, export |
| Student Worklist dialog | Per-student view; double-click opens guardian interaction dialog |
| Interaction dialog | Redesigned — guardian name/contacts header, per-student balance grid, Save / Save & Next / Clear, inline SMS button |
| XtraReports | rptDailyWorklist, rptGuardianWorklist, rptStudentWorklist (A4 landscape) |
| Ribbon | Worklists group (Daily, Guardian, Student) + Settings group (Settings, Send Reminders) on Fees Follow-up page |
| SMS reminders | Manual "Send Reminders" button; sends 2-day-before, day-of, and thank-you messages; deduplicated via tbl_SmsReminderLog |
| Balance fix | B/F (brought-forward arrears) included in balance — matches student ledger; uses active semester from WorkingSemesters.GetWorkingSemester(), no term-date config needed |

---

## Current State

- **Branch:** `main`
- **HEAD:** `35a3c66`
- **EXE deployed to:** `smoke_test/IXtreme.exe`
- **App launches:** Yes (confirmed)
- **Follow-up tab loads:** Crashes with `Invalid object name 'tbl_FollowUpSettings'` — migrations not yet run on the school database

---

## Before Smoke Testing Can Start

Run all four migration scripts against the school's SQL Server database **in
this order**. All are idempotent (safe to re-run).

```
1. notes/migrations/2026-05-27_create_tbl_FeesContactLog.sql
   Creates: tbl_FeesContactLog, tbl_FollowUpSettings (default stale threshold 7 days)

2. notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql
   Alters: Outcome column constraints on tbl_FeesContactLog

3. notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql
   Adds: GuardianKey column to tbl_FeesContactLog

4. notes/migrations/2026-05-30_add_SmsReminderLog.sql
   Creates: tbl_SmsReminderLog (SMS deduplication)
```

Open SSMS → connect to the SMD database → run each script.

---

## Smoke Test Checklist

### Startup
- [ ] App launches without error
- [ ] Fees Follow-up tab visible in ribbon

### Dashboard
- [ ] Dashboard loads — 5 KPI cards show values (or zeros if no data)
- [ ] Priority breakdown grid populates
- [ ] Top-5 by balance grid populates
- [ ] KPI values are plausible vs Fees Payment Reports screen

### Balance accuracy
- [ ] Open a guardian with a B/F balance in the student ledger (e.g. NAYIGA MARGARET NJAGAANIDDE in TOP class)
- [ ] Confirm their balance in the Guardian Worklist matches the student ledger balance (198,000 for NAYIGA)
- [ ] Confirm their balance is NOT the old cashOnAccount-only figure (130,000 for NAYIGA)

### Worklist dialogs
- [ ] Daily Worklist opens; rows load; search filters work; print opens preview
- [ ] Guardian Worklist opens; class dropdown populates; filter by class works; min balance filter works; print/export work
- [ ] Student Worklist opens; same filter checks; double-click opens interaction dialog

### Interaction dialog
- [ ] Double-click guardian row in Daily Worklist → interaction dialog opens with correct guardian name and contacts
- [ ] Student grid shows all students in the guardian's family with correct balances
- [ ] Save contact log — select Phone + Contacted + note, click Save → dialog closes, row disappears from Daily Worklist on refresh
- [ ] Save & Next — saves current guardian and advances to next in the list
- [ ] Promise flow — select Outcome = Promised, set a promise date, save → log is created
- [ ] SMS button — opens SMS dialog pre-addressed to the guardian's phone
- [ ] NOCONTACT guardian — SMS button should NOT appear (or should be blocked with a message)

### Reports
- [ ] Print from Daily Worklist → A4 landscape preview renders without error
- [ ] Print from Guardian Worklist → same
- [ ] Print from Student Worklist → same
- [ ] Export to Excel from any worklist → file saves and opens

### Settings
- [ ] Settings button opens FollowUpSettings dialog
- [ ] Can save stale threshold, term dates, critical threshold
- [ ] After saving term dates, PacingGap affects tier colouring (Critical rows go red)

### Send Reminders
- [ ] "Send Reminders" button shows a success message (even if 0 reminders are due)
- [ ] Does NOT crash when tbl_SmsReminderLog exists

### Row colouring
- [ ] Critical tier → red background
- [ ] Missed Promise → coral/light-coral background
- [ ] Contact Overdue (stale) → yellow background
- [ ] Up to Date → no special colour

---

## Key Technical Facts for Next Session

**Balance formula:**
```
TotalBilled = cashOnAccount + BFAmount
BFAmount    = SUM(Debit) - SUM(Credit) FROM FeesPayment WHERE SemesterId != currentSemester
TotalPaid   = SUM(Credit) FROM FeesPayment WHERE SemesterId = currentSemester
Balance     = TotalBilled - TotalPaid
```
`currentSemester` comes from `WorkingSemesters.GetWorkingSemester()` — the same active-term setting the rest of the app uses. No separate date config needed.

**Guardian Key** (unique family identifier):
```
PriorityContact → OtherContact → "NOCONTACT-{StudentNumber}"
```
Stored in `tbl_FeesContactLog.GuardianKey`. Guardians with a `NOCONTACT-` key cannot receive SMS.

**SMS gateway:**
```csharp
new SMSGateWay(connectionString).TrySendSMSViaPOST(phone, message, out string error)
```
Returns `true` on success. In `AlienAge.ExtremeMessenger` namespace.

**CryptorEngine:** Single-arg only — `CryptorEngine.Decrypt(raw)`, no bool overload.

**DB connection:** `DataConnection.ConnectToDatabase()`, not `GetConnectionString()`.

**Report preview:** `new ReportPrintTool(rpt).ShowRibbonPreview()`, not `rpt.ShowRibbonPreview()`.

**Date format in GridControl:** `"dd-MMM-yyyy"` bare (not `"{0:dd-MMM-yyyy}"`).

**Build:**
```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj
# logs → notes\IXtreme_buildNN.log   (last used: build68)
```

**Deploy:**
```powershell
Copy-Item "decompiled\IXtreme\bin\Debug\net472\IXtreme.exe" "smoke_test\IXtreme.exe" -Force
```

---

## Files Changed This Session (key ones)

| File | What changed |
|---|---|
| `I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` | Full service — guardian/student/daily worklists, dashboard, SMS reminders, B/F balance, semester-based filtering |
| `I_Xtreme.Models/GuardianWorklistRow.cs` | Added StudentWorklistRow, DashboardData, PriorityGroupStats; expanded StudentSummary and GuardianWorklistRow |
| `I_Xtreme.NavigationForms/usrFeesFollowUp.cs` | KPI dashboard UI; public OpenDailyWorklist/OpenGuardianWorklist/OpenStudentWorklist/OpenSettings/SendReminders |
| `I_Xtreme.DialogForms/dlgFeesContactInteraction.cs` | Redesigned interaction dialog |
| `I_Xtreme.DialogForms/dlgDailyWorklist.cs` | New full implementation |
| `I_Xtreme.DialogForms/dlgGuardianWorklist.cs` | New full implementation |
| `I_Xtreme.DialogForms/dlgStudentWorklist.cs` | New full implementation |
| `I_Xtreme.GeneralReports/rptDailyWorklist.cs` | New XtraReport |
| `I_Xtreme.GeneralReports/rptGuardianWorklist.cs` | New XtraReport |
| `I_Xtreme.GeneralReports/rptStudentWorklist.cs` | New XtraReport |
| `I_Xtreme.GeneralReports/ReportHelper.cs` | School name/contact header helper |
| `I_Xtreme/MainForm.cs` | Ribbon restructure — 3 worklist buttons, Send Reminders button, removed Open Contact View |
| `notes/migrations/*.sql` | 4 migration scripts (all must be run before first use) |
