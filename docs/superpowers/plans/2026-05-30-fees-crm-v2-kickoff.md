# Session Kickoff: Fees CRM v2 Execution

Read `docs/superpowers/plans/2026-05-30-fees-crm-v2-redesign.md` then use the
`superpowers:subagent-driven-development` skill to execute it task by task, starting from Task 1.

---

## Context you need before starting

**Codebase:** Source-recovery project. Code lives in `decompiled/IXtreme/`. All edits go there.

**Build:**
```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build<NN>.log 2>&1
Select-String "error" notes\IXtreme_build<NN>.log
```
Increment the log number each build (last used was build44 in the previous session — start from build45).
85 pre-existing warnings are normal. Target = 0 errors.

**Deploy after each build that passes:**
```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe
```

**No test suite.** Verification = clean build (0 errors).

**Migrations run manually — do NOT run them automatically.** When a task produces a migration SQL file, note it and move on. The user runs migrations manually.

**Commit format:** Conventional Commits, imperative mood, under 72 chars. No emojis.

---

## Key codebase facts (confirmed — do not re-derive)

| Fact | Value |
|---|---|
| Guardian name column | `tbl_Stud.Guardian` |
| Guardian relationship | `tbl_Stud.GuardianRelation` |
| Primary contact | `tbl_Stud.PriorityContact` |
| Secondary contact | `tbl_Stud.OtherContact` |
| Study status column | `tbl_Stud.StudyStatus` — values `"B"` (Border) and `"D"` (Day) |
| Student ID column | `tbl_Stud.StudentID` |
| School name query | `SELECT TOP 1 SchoolName, fullContact FROM SchoolDetails` — decrypt with `AlienAge.Security.CryptorEngine.Decrypt(raw, true)` |
| SMS gateway | `AlienAge.ExtremeMessenger.SMSGateWay.TrySendSMSViaPOST(phone, message, out error)` |
| SMS dialog | `new SMSGuardian()` — set `smsForm.txtReceipient.Text` before `ShowDialog()` — returns `DialogResult.OK` on success |
| Fees Payment dialog | `new StudentFeesPayment("SingleStudentPayment")` |
| Service class | `I_Xtreme.ExtremeClasses.FeesFollowUpService` |
| DB connection | `AlienAge.Connectivity.DataConnection.GetConnectionString()` |
| Daily list removal outcomes | Contacted, Promised, Refused, InPerson → remove; NoAnswer, ContactUnavailable, ContactOff → keep |

---

## What was already built (do not redo)

The previous session completed the guardian-centric worklist redesign (8 tasks, all committed to `main`). The smoke test revealed bugs and triggered this redesign. The current `main` has:

- `GuardianWorklistRow`, `StudentSummary`, `FeesFollowUpSettings` in `I_Xtreme.Models/`
- `FeesFollowUpService` with `GetGuardianWorklist`, `LogGuardianContact`, `GetGuardianContactHistory`, `GetSettings`, `SaveSettings`
- `usrFeesFollowUp` (current broken version — will be fully replaced in Task 7)
- `dlgFeesContactInteraction` (current version — will be redesigned in Task 6)
- `FollowUpSettings` dialog (keep as-is)
- Migration `notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql` already run

---

## Plan location

`docs/superpowers/plans/2026-05-30-fees-crm-v2-redesign.md`

Start from Task 1.
