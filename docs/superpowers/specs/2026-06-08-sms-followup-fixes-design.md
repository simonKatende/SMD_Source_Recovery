# SMS Follow-up Fixes — Design Spec

**Date:** 2026-06-08
**Status:** approved (smoke-test feedback on the Send Reminder improvements)
**Branch:** `feat/sms-followup-fixes` (off `main`)

This addresses six issues found while smoke-testing the merged Send Reminder feature. One bug (the
gateway success check) is the root cause of three reported symptoms; the rest are targeted fixes and
two UX/visibility improvements the user chose during brainstorming.

---

## 1. Gateway success misdetection (the keystone) — #1, root cause of #3/#4 "reappears / send twice"

**Symptom:** "Send Reminders — Complete" reports `Sent: 0`, `Failed (N): … SMS gateway error: OK`,
even though the SMS were delivered.

**Cause:** `FeeSmsHelper.TrySend` (`FeeSmsHelper.cs:84-92`) decides success with
`int.TryParse(response, out int code) && code > 0`. The egosms `/api/v1/plain/` endpoint returns the
literal text **`OK`** on success, not a number. So every successful send is classified as a failure.

**Cascade:** `ExecuteSendReminders` only writes to `tbl_SmsReminderLog` (`LogReminderSent` /
`LogGeneralReminderSent`) inside the `if (TrySend…)` success branch. Because TrySend returns false,
**nothing is ever logged**, so the dedup filter (`AlreadySentReminder`) and the cooldown query
(`GetGuardiansInGeneralCooldown`) find nothing → guardians reappear in the queue after sending (#3)
and can be re-sent indefinitely by any user (#4).

**Decision:** Extract a pure, unit-tested `SmsReminderLogic.IsGatewaySuccessResponse(string)` that
returns true when the trimmed response equals `OK` (case-insensitive) **or** parses to a positive
integer (defensive, for gateway variants). `FeeSmsHelper.TrySend` uses it. The actual gateway
responses remain audited in `tbl_SMSLog` via `SaveLog`.

## 2. Cross-channel double-nudge — #3 (design)

**Symptom:** A guardian queued for a Balance reminder is also queued for a (promise) reminder, so the
parent gets two SMS the same day.

**Cause:** `GetStudentsWithActivePromises` emits an `Overdue` promise reminder for a promise dated
1–7 days ago (`FeesFollowUpService.cs:833`). For such a guardian `LatestPromiseDate < today`, so
`hasActivePromise` is false and `IsBalanceReminderEligible` admits them too. The two channels overlap.

**Decision:** `GetBalanceRemindersPreview` excludes any guardian who appears in today's promise queue.
We reuse `GetStudentsWithActivePromises` (the authoritative "who is due" computation) and skip guardians
whose `GuardianKey` is in that set — no duplication of the window logic.

## 3. Multi-user race — #4 (mitigation)

**Symptom:** Two bursars each send the same batch; the parent gets duplicates and SMS cost doubles.

**Resolution:** Once #1 is fixed, logging works and sequential users are deduped by the log/cooldown.
For the residual simultaneous race, `ExecuteSendReminders` re-checks `AlreadySentReminder` immediately
before sending each item and skips an item that is now fully already-sent (General: a `General` row for
the guardian today; promise: all of the item's components already logged). The per-student UNIQUE key +
the existing try/catch backstop any row that still slips through. This narrows — does not theoretically
eliminate — the window; that is acceptable for this workflow.

## 4. Reminder visibility without flooding Interactions — #2

The user chose **counter columns + a read-only SMS history view** (not one interaction row per SMS).

- **Counter columns** on the Guardian and Student worklists:
  - `RemindersSentCount` — number of `tbl_SmsReminderLog` rows for the guardian/student with
    `SentAt` inside the **current term** (`TermStartDate`..`TermEndDate`); when term dates are not
    configured, count all.
  - `LastReminderDate` + `LastReminderType` — the most recent reminder.
- **SMS History view** (`dlgSmsHistory`) — a read-only, searchable grid over **`tbl_SMSLog`**
  (`date`, `recipients`, `response`, `message`), newest first, filterable by recipient/message text.
  `tbl_SMSLog` is the actual gateway send log (what text went to which number and the response), which
  is exactly what a bursar needs when a parent disputes. Opened from a new **"SMS History"** ribbon
  button in the Fees Follow-up **Interactions** group.

## 5. Read-only ledger from the interaction double-click — #5

**Symptom:** Double-clicking a student in the Log Interaction dialog opens the payment form; processing
a payment there throws `NullReferenceException` in `StudentFeesPayment.UpdateCashOnAccount` (the
`gridView1.Columns["Amount"]` summary isn't initialised in that entry path). The payment row is inserted
before the crash, but the receipt + post-payment SMS (in `ConfirmReceiptPrinting`, after the throw)
never run.

**Decision:** Do not try to make payment work from that surface. When opened from the interaction
double-click, the dialog is **view-only**: the ledger is visible and navigable, but the commit/edit
actions are disabled (`btnProcessPayment` + the bill/edit bar buttons gated by permissions in the
constructor). Payment recording stays in Accounts → Pay In, untouched. This both honours the intent and
sidesteps the NRE (the crashing path is never reached).

## 6. Worklist colour coding — #6

**Symptom:** Critical rows flood the entire row with saturated `OrangeRed` + white/dark text → harsh and
low-contrast across hundreds of rows.

**Decision:** Keep **full-row tinting** but use **pale per-tier tints with normal dark text** (no white
fore-colour, no italic on data rows). No badge or edge bar (tint only). A shared helper applies the same
palette in all three worklist `RowStyle` handlers (Guardian, Student, Daily):

| Tier / flag | Background | Fore |
|---|---|---|
| Critical | `#FCE4E4` (pale red) | default (dark) |
| BrokenPromise (Missed Promise) | `#FBE0D8` (pale coral) | default |
| Stale (Contact Overdue) | `#FCF6DD` (pale amber) | default |
| CallRequired (flag, precedence) | `#E2E8F5` (pale blue) | default |
| Current / Up-to-date | default (white) | default |
| IsUnreachable (overlay) | (unchanged bg) | `Gray` (keep, drop italic) |

---

## Out of scope / no schema change

- The counter columns and SMS history read existing tables (`tbl_SmsReminderLog`, `tbl_SMSLog`); **no
  migration** is required.
- The `StudentFeesPayment.UpdateCashOnAccount` NRE itself is not "fixed" — it is avoided by the view-only
  mode. A proper fix to that older payment dialog is a separate concern.

## Verification

- Pure logic (`IsGatewaySuccessResponse`) is unit-tested in `FeesFollowUp.Tests`.
- Everything else is verified by `dotnet build decompiled/IXtreme/IXtreme.csproj` + the `smoke_test/`
  deployment (app launches; worklists render with new columns and softened colours; the SMS History and
  view-only ledger dialogs open).
