# Fees CRM — Handoff to Implementation Session

**Date written:** 2026-05-27
**Branch to check out:** `feat/fees-crm`
**Head at handoff time:** `7541fc1`

---

## Read this first, in order

1. **`CLAUDE.md`** (repo root) — recovery-project context: what the repo is, build commands, recurring decompiler-artifact patterns, the `backup/` / `smoke_test/` gitignored-folder convention. **Required orientation.**
2. **`docs/superpowers/specs/2026-05-27-fees-crm-design.md`** — the approved design. This is the source of truth for *what* to build. Do not redesign mid-implementation.
3. **`docs/superpowers/plans/2026-05-27-fees-crm.md`** — the 13-task implementation plan with code blocks and exact commands per task. This is the source of truth for *how* to build it.
4. **`~/.claude/CLAUDE.md`** (global) — user's cross-project preferences: be direct, no emojis, async/await, Conventional Commits, never run schema migrations without showing the user first.

If you read those four, you have everything. Skim the rest of this handoff.

## What's been done already

| Task | Status | Commit | Notes |
|------|--------|--------|-------|
| Task #1 SMS Guardian repair + SMSGateWay refactor | merged to `main` | `9b5d6a0`, `46fbab4` | First library (`AlienAge.ExtremeMessenger.v4`) graduated from `backup/` HintPath to ProjectReference. Sets the pattern. |
| Fees CRM design doc | committed | `000ada6` | On `feat/fees-crm`. Approved by user. |
| Fees CRM implementation plan | committed | `7541fc1` | On `feat/fees-crm`. **You execute this.** |

## What you do next

Use the `superpowers:subagent-driven-development` skill. The user has chosen subagent-driven execution: dispatch a fresh subagent per plan task, review the diff between tasks, iterate. Each task in the plan is sized to fit one subagent.

Recommended dispatch flow per task:

1. Read the next unchecked task from `docs/superpowers/plans/2026-05-27-fees-crm.md`.
2. Dispatch a subagent with: the relevant task section (verbatim), pointers to the design doc and `CLAUDE.md`, and the branch to commit on (`feat/fees-crm`).
3. When the subagent returns: verify it built clean (`0 Error(s)` in the build log it produced), verify the commit exists with a Conventional-Commits message, smoke-test if the task includes a UI-affecting change.
4. Mark the task's checkboxes complete (`- [x]`) in the plan file. Commit the plan-checkbox-update separately with `chore(fees-crm): mark task N complete`.
5. Move to the next task.

When Task 13 finishes successfully, merge `feat/fees-crm` to `main` with `git merge --ff-only` (matches the pattern used for `fix/sms-guardian`).

## Hard rules that must NOT drift

- **No automated tests.** This project has no test framework (per `CLAUDE.md`). Replacing TDD steps with smoke-test + build is the agreed adaptation. Do NOT add a test framework on a whim.
- **Migrations are manual.** `notes/migrations/2026-05-27_create_tbl_FeesContactLog.sql` is committed but never auto-applied. Tell the user when it's time for them to run it (likely after Task 1 commit or before Task 12 smoke test).
- **`backup/` and `smoke_test/` are gitignored.** Both must exist locally (recreate via `robocopy` from `Program Files (x86)\Alien Age\School Management Dynamics` if a fresh machine — see `CLAUDE.md`). Never commit either.
- **Per-task commits.** Every plan task ends with one commit. Don't batch.
- **Co-author trailer required.** Every commit message ends with `Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>` (matching the convention used in commits `9b5d6a0`, `46fbab4`, `000ada6`, `7541fc1`).
- **Single-contact SMS policy is settled.** Don't reintroduce dual-guardian sends in any new SMS code path. The policy: contact1 if filled, else contact2. See commit `46fbab4` rationale.

## Project-specific gotchas not in CLAUDE.md

- **`MainForm.cs` is huge (>9000 lines).** Use `Grep` with line numbers; never load the whole file. Key landmarks: line 92-98 = role flags; line 526-528 = ribbon-page declarations; lines 4198/4371/4730/4872/4944/5099 = `ribbonPageStudentAccounts.Visible = …` sites that Task 12 mirrors for the new tab.
- **`CurrentControl.LoadControl(<control>, panelMain)`** is the canonical pattern for mounting a `UserControl` into the main area (confirmed at lines 4790-4792, 7640-7641, 9017-9018). Use it in Task 12 step 3.
- **DevExpress references**: when build fails on a missing type (e.g. `GridFormatRule`, `DateEdit`, `RadioGroup`), add the matching `<Reference Include="DevExpress.XtraXxx.v23.2">` block in `IXtreme.csproj` with `HintPath="..\..\backup\DevExpress.XtraXxx.v23.2.dll"`. The Task 1 commit message lists the references already present.
- **Build log numbering**: the plan assumes `notes\IXtreme_build13.log` through `notes\IXtreme_build23.log`. If a real fresh build has already taken a number (check `notes/` for the highest existing `IXtreme_buildN.log`), bump from there.
- **`SaveSMSLog` is silent on failure** (post-Task #1 refactor — `Debug.WriteLine` instead of `MessageBox.Show`). If logging-related issues appear, look at the Output window during a `Debugger.IsAttached` run, not at user-visible toasts.
- **Decompiled-code artifacts you'll likely hit**: see `CLAUDE.md` § "Working with decompiled code — recurring fixes". The list there covers all classes of bug seen across the 4 rebuilt EXEs. New code being written for the CRM shouldn't hit any of them, but if you find yourself editing a sibling decompiled file mid-task, those patterns apply.

## Open decisions deferred to implementation

These were left for the implementer (you) to confirm by reading the code, not punted indefinitely:

- **Role gating flag** — plan defaults to "mirror `ribbonPageStudentAccounts.Visible` at every site." If that turns out to be wrong (e.g. one role can see Accounts but shouldn't see Follow-up), add `canFeesFollowUp` to `MainForm.cs` and `CurrentUser.cs` per the design-doc fallback.
- **Class-filter data source** — plan uses `SELECT DISTINCT ClassId FROM tbl_Stud`. If a proper `tbl_Classes` (or similar) exists, switch to it during Task 5; if not, the DISTINCT approach is fine.
- **`RibbonPageGroup` inside the new `RibbonPage`** — the plan doesn't add bar items inside the new page; the page just hosts the UserControl. If DevExpress requires at least one `RibbonPageGroup` (it doesn't, for hosting pure content), add an empty one.

## Definition of done

- All 13 plan tasks checked off.
- `dotnet build decompiled\IXtreme\IXtreme.csproj` returns `0 Error(s)`.
- All 9 smoke-test scenarios from `docs/superpowers/specs/2026-05-27-fees-crm-design.md` § 6 pass on the user's deployment.
- `feat/fees-crm` merged to `main` (fast-forward).
- Migration script run on the user's SQL Server.

## If you get stuck

- Spec ambiguity → re-read the design doc; don't invent.
- Plan ambiguity → ask the user; don't guess silently.
- Build failure → check the relevant `notes/*_buildN.log` for the exact error before iterating.
- Smoke-test failure → diff against `recovery-baseline` (tag) to confirm you didn't regress unrelated functionality.
