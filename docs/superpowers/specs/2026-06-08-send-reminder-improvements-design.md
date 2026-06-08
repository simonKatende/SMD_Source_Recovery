# Send Reminder Improvements (Design)

Date: 2026-06-08
Status: Approved (pending spec review)
Scope: Audit findings R1–R9 of the Fees Follow-up "Send Reminder" feature, **excluding**
scheduling/automation (deferred). Covers: general (non-promiser) balance reminders,
guardian-centric consolidation, and gateway/correctness/UX hardening.

## Goal

The reminder feature should drive guardians to pay before term end (toward 98% collection)
without spamming them. Today it only texts guardians who made a promise, texts multi-child
families once per child, and ships several correctness/robustness bugs. This change adds a
focused balance-reminder path for at-risk non-promisers, consolidates messaging to one SMS
per guardian per occurrence, and hardens the gateway and message rendering.

## Decisions locked in brainstorming

- General balance reminders target **at-risk** guardians via the existing worklist urgency
  engine — tiers **Critical and Broken Promise only**, balance > 0, **no active promise**.
- Spam prevention via a **fixed, configurable cooldown** (`GeneralReminderCooldownDays`,
  default 7) so running "send" daily texts each guardian at most once per window.
- General reminders are a **separate ribbon action + separate preview dialog**, not merged
  into the promise-reminder dialog.
- Promise consolidation is **per guardian per reminder-type occurrence**.
- Phone market is **Uganda only**; normalize to `256XXXXXXXXX` (no `+`).

## Components

### 1. Settings & data model

New settings in `FeesFollowUpSettings` (loaded/saved in `GetSettings`/`SaveSettings`, row in
`FollowUpSettings.cs`):

| Key | Default | Unit |
|---|---|---|
| `GeneralReminderCooldownDays` | 7 | days |
| `SmsTemplateGeneral` | `DefaultGeneral` text | template string |

New reminder type string: **`"General"`**. Logged to `tbl_SmsReminderLog` like the others,
relying on the existing `SentAt` column. No new tables. No migration beyond seeding the two
new settings keys (the app also upserts them via `SaveSettings`).

Cooldown is enforced by a query: a guardian is in cooldown if a `tbl_SmsReminderLog` row
exists with `GuardianKey = @gk AND ReminderType = 'General' AND SentAt >= @cutoff`
(`@cutoff = today − GeneralReminderCooldownDays`).

### 2. Pure, testable logic (`SmsReminderLogic` — new static class)

New `I_Xtreme.ExtremeClasses/SmsReminderLogic.cs`, dependency-light (System + I_Xtreme.Models),
unit-tested by the existing `FeesFollowUp.Tests` project (mirrors the `FeesUrgency` pattern):

- `NormalizePhone(string raw) -> string?` — Uganda MSISDN normalization (see §4).
- `FormatAmount(decimal value) -> string` — thousands-separated, `0` renders as `"0"` (not blank).
- `IsBalanceReminderEligible(PriorityTier tier, decimal balance, bool hasActivePromise) -> bool`
  — true when `balance > 0 && !hasActivePromise && tier is Critical or BrokenPromise`.
- `WithinCooldown(DateTime? lastGeneralSent, DateTime today, int cooldownDays) -> bool`.
- `ConsolidatePromiseReminders(IEnumerable<ReminderItem> perStudent) -> List<ReminderItem>`
  — groups by `(GuardianKey, ReminderType)` and merges (see §3).

### 3. Promise-reminder flow — consolidation (R2) + de-dup integrity

`GetStudentsWithActivePromises` still produces **per-student** candidate `ReminderItem`s, and
`GetRemindersPreview` still filters already-sent **per student** (`AlreadySentReminder` unchanged).
A new final step consolidates the surviving items via
`SmsReminderLogic.ConsolidatePromiseReminders`:

For each `(GuardianKey, ReminderType)` group, emit one `ReminderItem`:
- `StudentName` = distinct student names joined (", ").
- `ClassId` = distinct class ids joined (", ").
- `Balance` = **sum of the group's student balances** (the family total for the named
  children; see Known Limitations re: non-promised siblings).
- `PromisedAmount` = sum of the group's promise amounts.
- `PromiseDate` = the **earliest** promise date in the group (most urgent; used for display).
- `Message` = rendered once from the merged values.
- `Components` = **new field**: the list of `(StudentNumber, PromiseDate)` underlying the group.

`ReminderItem` gains `public List<ReminderComponent> Components` (a small record/struct of
`StudentNumber` + `PromiseDate`), empty for General items.

**De-dup stays per-student.** On successful send, the send loop logs **each** component via the
existing `LogReminderSent(guardianKey, studentNumber, promiseDate, type)`. Because filtering and
logging remain per-student, consolidation changes only *how many SMS go out* (one per group),
never the idempotency guarantees — running daily still won't re-send.

### 4. Gateway hardening (`FeeSmsHelper`)

- **URL-encode** every interpolated value in the request URI (`number`, `message`, `username`,
  `password`, `sender`) with `Uri.EscapeDataString(...)`. Fixes garbled messages and the
  param-injection risk when names/school contain `& # = +` (R4).
- **Phone normalization** (R8), applied before send (and reused as a filter in the preview
  builders so un-normalizable numbers are dropped + reported):
  - Strip everything except digits (drop a leading `+`).
  - `0XXXXXXXXX` (10 digits, local) → `256` + last 9.
  - `7XXXXXXXX` (9 digits) → `256` + the 9.
  - `256XXXXXXXXX` (12 digits) → unchanged.
  - Otherwise → `null` (invalid). Valid result: 12 digits beginning `2567`.
  - `TrySend`/preview treat `null` as "invalid number — skipped" and surface it in the
    failure/skipped list rather than calling the gateway.

### 5. New "Send Balance Reminders" action (R1)

- **Ribbon button** "Send Balance Reminders" on the Fees Follow-up ribbon, wired to a new
  `usrFeesFollowUp.SendBalanceReminders()` that opens a balance-reminder preview dialog.
- **Preview dialog:** reuse `dlgSendRemindersPreview` parameterized by a `mode`
  (promise vs balance) that sets the title, the data source (`GetRemindersPreview` vs
  `GetBalanceRemindersPreview`), and which columns show (balance mode hides promise-only
  columns). This avoids duplicating the grid/remove/send logic. (A thin separate class is an
  acceptable fallback if parameterizing proves awkward; behavior must be identical.)
- **Service:** `GetBalanceRemindersPreview()`:
  1. `var rows = GetGuardianWorklist("", 0, settings)`.
  2. Keep rows where `SmsReminderLogic.IsBalanceReminderEligible(row.Tier, row.TotalBalance, hasActivePromise)`.
  3. Drop rows in cooldown (query `tbl_SmsReminderLog` for a recent `General` row per guardian
     — batch into one query keyed by GuardianKey, mirroring the worklist CTEs).
  4. Resolve + normalize the guardian phone (priority → other); drop/report un-normalizable.
  5. Render `SmsTemplateGeneral` with `{names}` = family student names, `{class}` = distinct
     classes, `{balance}` = `row.TotalBalance`, `{school}`. `ReminderType = "General"`,
     `Components` empty (guardian-level).
- **Send + log:** reuse `ExecuteSendReminders`. On a successful `TrySend`, the send loop
  branches on type: a `General` item logs guardian-level via a new
  `LogGeneralReminderSent(conn, guardianKey)` (StudentNumber NULL, PromiseDate = today,
  ReminderType `General`, SentAt default) so the cooldown holds; a promise item logs **each**
  entry in its `Components` list via the existing `LogReminderSent` (preserving per-student
  de-dup). Counters increment by type.

### 6. Smaller correctness/UX fixes

- **Amount-blank (R6):** `ApplySmsTemplate` uses `SmsReminderLogic.FormatAmount` for
  `{promised_amount}` and `{balance}` so `0` renders as `"0"`, never blank.
- **`Overdue` miscount (R5):** `SmsReminderResult` gains `OverdueCount` and `GeneralCount`;
  `TotalSent = TwoDayCount + DayOfCount + OverdueCount + GeneralCount`; `ExecuteSendReminders`
  increments the correct counter per type (Overdue stops folding into `TwoDayCount`).
- **Template naming (R7):** relabel the pre-due template row in `FollowUpSettings.cs` to
  "Pre-due reminder template (sent 3 days before)". Keep the stored key `SmsTemplate2Day` to
  avoid a migration; only the UI label changes.
- **Send confirmation (R9):** both preview dialogs show a Yes/No
  "Send {N} SMS to {M} guardians? This uses SMS credits." before `ExecuteSendReminders`.

## Data flow

**Promise:** ribbon → `dlgSendRemindersPreview` → `GetRemindersPreview` (per-student build →
per-student already-sent filter → `ConsolidatePromiseReminders`) → preview → confirm →
`ExecuteSendReminders` (TrySend per item; on success log each `Component`).

**Balance:** ribbon → `dlgSendBalanceRemindersPreview` → `GetBalanceRemindersPreview`
(worklist → eligibility → cooldown filter → phone normalize → render) → preview → confirm →
`ExecuteSendReminders` (TrySend; on success `LogGeneralReminderSent`).

## Error handling

- Gateway failures already isolated per item (`TrySend` catches, batch continues); unchanged.
- Un-normalizable phones are dropped before send and reported as skipped, not sent.
- Cooldown and eligibility are first-class filters, not errors.
- Missing SMS account / template still surfaced via existing messaging.

## Testing

- `SmsReminderLogic` is pure and table-driven → unit-tested in `FeesFollowUp.Tests`:
  - `NormalizePhone`: local `07…`, `7…`, `256…`, `+256…`, spaces/punctuation, invalid → null.
  - `FormatAmount`: 0 → "0", thousands separators, large values.
  - `IsBalanceReminderEligible`: Critical/BrokenPromise eligible; Stale/Current/CallRequired
    not; zero balance not; active promise not.
  - `WithinCooldown`: boundary at exactly `cooldownDays`.
  - `ConsolidatePromiseReminders`: 3 same-type kids → 1 item with summed balance/amount, joined
    names; mixed types → one item per type; components preserved for logging.
- DB-bound methods (`GetBalanceRemindersPreview`, cooldown query, `LogGeneralReminderSent`) and
  `FeeSmsHelper` changes verified by `dotnet build` + the `smoke_test/` deployment.

## Out of scope

- Scheduling / automated daily sending (deferred — needs a desktop-app scheduling mechanism).
- Balance-tiered or escalating cooldown (fixed cooldown only this pass).
- Markets other than Uganda.
- Stale-tier balance reminders (only Critical + Broken Promise this pass).
- SMS credential encryption / `tbl_SMSLog` PII retention (security hardening beyond URL-encoding).

## Known limitations after this change

- A consolidated promise reminder's `{balance}` sums only the **promised** children's balances;
  a non-promised sibling who also owes is not included in that figure (the guardian still
  appears in the balance-reminder flow only if they have *no* active promise — a guardian with
  any active promise is handled by the promise flow). Acceptable; documented.
- Cooldown is per guardian across all balance reminders; it does not escalate near term end.
- No send scheduling; reminders still require the bursar to open the dialog and Send.
