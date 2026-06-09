# SMS Follow-up Fixes Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Fix the egosms success-detection bug (and the dedup/double-send it broke), stop balance+promise cross-channel double-nudges, add reminder-count columns + a read-only SMS history view, make the interaction-opened payment dialog view-only, and soften the worklist colours.

**Architecture:** One pure helper (`SmsReminderLogic.IsGatewaySuccessResponse`) is unit-tested; the gateway, service, worklist controls, a new history dialog, the payment dialog, and three row-style handlers are wired to use the fixes and verified by `dotnet build` + the `smoke_test/` deployment. No DB schema change.

**Tech Stack:** C# 11, net472 WinForms, DevExpress v23.2, SQL Server. Tests: net8.0 + xUnit (source-linked).

**Spec:** `docs/superpowers/specs/2026-06-08-sms-followup-fixes-design.md`

**Branch:** `feat/sms-followup-fixes` (create off `main`).

**Key source anchors (verified):**
- `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeeSmsHelper.cs` — success check (84-92), `SaveLog` (95-110).
- `decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs` — pure helpers.
- `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` — `GetGuardianWorklist` (283, builds row at ~454), `GetStudentWorklist` (597, builds row at ~606), `GetStudentsWithActivePromises` (743), `ExecuteSendReminders` (889-927), `GetBalanceRemindersPreview` (~1024), `GetGuardiansInGeneralCooldown`, `AlreadySentReminder` (958), settings `TermStartDate/TermEndDate` (load 90-93).
- `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` — `FeesFollowUpSettings` (7-41), `GuardianWorklistRow` (75-122), `StudentWorklistRow` (124-153).
- `decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs` — `View_RowStyle` (246-266), column setup, `_view`/`_grid`.
- `decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentWorklist.cs` — `View_RowStyle` (231-242).
- `decompiled/IXtreme/I_Xtreme.NavigationForms/usrDailyWorklist.cs` — `View_RowStyle` (201-221).
- `decompiled/IXtreme/I_Xtreme.DialogForms/StudentFeesPayment.cs` — ctor `StudentFeesPayment(string FormMode)` (758-797), permission gating of `btnProcessPayment`/`barButtonItem9`/`barButtonItem8/10/13/11`.
- `decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs` — `GridStudents_MouseDoubleClick` (501-514) → `new StudentFeesPayment("SingleStudentPayment")`.
- `decompiled/IXtreme/I_Xtreme/MainForm.cs` — Interactions group (`ribbonPageGroupFeesInteractions` 24907-24911), `bbiViewInteractions` (24887-24906), ribbon `Items.AddRange` (24914).
- `tbl_SMSLog` columns: `date, recipients, response, message` (see `FeeSmsHelper.SaveLog`).

**Conventions:** locate edits by matching quoted code (line numbers drift). Build logs → `notes/IXtreme_smsfix_buildN.log`. Conventional commits ending with `Co-Authored-By: Claude Opus 4.8 <noreply@anthropic.com>`. Don't touch `backup/` or `smoke_test/` sources. ~86 pre-existing build warnings are expected; only errors matter.

---

## Task 1: Gateway success detection — pure helper + TDD

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs`
- Modify: `tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeeSmsHelper.cs`

- [ ] **Step 1: Write the failing test**

Append inside the `SmsReminderLogicTests` class in `tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs`:

```csharp
    [Theory]
    [InlineData("OK", true)]
    [InlineData("ok", true)]
    [InlineData(" OK ", true)]
    [InlineData("1", true)]
    [InlineData("250", true)]
    [InlineData("0", false)]
    [InlineData("Failed", false)]
    [InlineData("Insufficient balance", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public void IsGatewaySuccessResponse_matches_OK_or_positive_int(string response, bool expected)
        => Assert.Equal(expected, SmsReminderLogic.IsGatewaySuccessResponse(response));
```

- [ ] **Step 2: Run tests to verify the new ones fail**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: FAIL — `IsGatewaySuccessResponse` not defined.

- [ ] **Step 3: Implement the helper**

In `SmsReminderLogic.cs`, add to the class (after `FormatAmount`):

```csharp
    /// <summary>
    /// True when an SMS-gateway response indicates success. egosms /plain returns the literal
    /// "OK"; some gateway variants return a positive integer (batch id / count). Anything else
    /// (empty, "0", an error string) is a failure.
    /// </summary>
    public static bool IsGatewaySuccessResponse(string response)
    {
        if (string.IsNullOrWhiteSpace(response)) return false;
        string r = response.Trim();
        if (r.Equals("OK", StringComparison.OrdinalIgnoreCase)) return true;
        return int.TryParse(r, out int code) && code > 0;
    }
```

- [ ] **Step 4: Run tests to verify they pass**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: PASS (all prior tests + the new theory).

- [ ] **Step 5: Use it in the gateway**

In `FeeSmsHelper.cs`, replace the success block (currently):

```csharp
        // egosms returns a positive integer on success (message count / batch ID)
        if (int.TryParse(response, out int code) && code > 0)
        {
            errorMessage = null;
            return true;
        }

        errorMessage = string.IsNullOrEmpty(response) ? "No response from SMS gateway." : $"SMS gateway error: {response}";
        return false;
```

with:

```csharp
        // egosms /plain returns "OK" on success; some variants return a positive integer.
        if (SmsReminderLogic.IsGatewaySuccessResponse(response))
        {
            errorMessage = null;
            return true;
        }

        errorMessage = string.IsNullOrEmpty(response) ? "No response from SMS gateway." : $"SMS gateway error: {response}";
        return false;
```

(`FeeSmsHelper` and `SmsReminderLogic` share the `I_Xtreme.ExtremeClasses` namespace — no using needed.)

- [ ] **Step 6: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build1.log`. Expect 0 errors.

- [ ] **Step 7: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/SmsReminderLogic.cs tests/FeesFollowUp.Tests/SmsReminderLogicTests.cs decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeeSmsHelper.cs notes/IXtreme_smsfix_build1.log
git commit -m "fix(fees-sms): treat egosms 'OK' as success so sends log correctly"
```

---

## Task 2: Cross-channel exclusion — balance reminders skip the promise queue

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Build the promise-queue guardian set inside `GetBalanceRemindersPreview`**

Read `GetBalanceRemindersPreview` (≈1024-1060). It currently does (shape):

```csharp
    public List<ReminderItem> GetBalanceRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        string template = !string.IsNullOrWhiteSpace(settings.SmsTemplateGeneral)
            ? settings.SmsTemplateGeneral : DefaultGeneral;
        var today = DateTime.Today;

        var rows   = GetGuardianWorklist("", 0, settings);
        var cooled = GetGuardiansInGeneralCooldown(settings.GeneralReminderCooldownDays);
        ...
```

Immediately after the `cooled` line, add a set of guardians who already have a promise reminder due
today (reusing the authoritative computation), opening one connection for it:

```csharp
        // Cross-channel guard: never send a balance reminder to a guardian who is already getting a
        // promise reminder today (e.g. a just-broken promise still in the Overdue window).
        HashSet<string> promiseGuardians;
        using (var pconn = new SqlConnection(connectionString))
        {
            pconn.Open();
            promiseGuardians = new HashSet<string>(
                GetStudentsWithActivePromises(pconn, school,
                    settings.SmsTemplate2Day, settings.SmsTemplateDayOf, settings.SmsTemplateOverdue)
                    .Select(i => i.GuardianKey),
                StringComparer.Ordinal);
        }
```

- [ ] **Step 2: Apply the exclusion in the per-guardian loop**

In the `foreach (var g in rows)` loop, next to the existing `if (cooled.Contains(g.GuardianContact)) continue;`, add (immediately after it):

```csharp
            if (promiseGuardians.Contains(g.GuardianContact)) continue;   // already getting a promise SMS today
```

Confirm the loop variable and key are `g` / `g.GuardianContact` (matching `cooled.Contains(g.GuardianContact)`); adapt if the actual code differs.

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build2.log`. Expect 0 errors.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_smsfix_build2.log
git commit -m "fix(fees-sms): balance reminders skip guardians already in the promise queue"
```

---

## Task 3: Race re-check — skip already-sent items at send time

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Add a pre-send "already fully sent?" guard in `ExecuteSendReminders`**

Read `ExecuteSendReminders` (889-927). Inside the `try` block, as the FIRST statements before
`FeeSmsHelper.TrySend(...)`, insert a guard that skips an item another user already logged:

```csharp
                // Concurrency guard: re-check the log immediately before sending so a second user
                // who sent moments ago doesn't cause a duplicate SMS.
                if (item.ReminderType == "General")
                {
                    if (AlreadySentReminder(conn, item.GuardianKey, null, DateTime.Today, "General"))
                        continue;
                }
                else
                {
                    bool allComponentsSent =
                        item.Components != null && item.Components.Count > 0
                            ? item.Components.All(c => AlreadySentReminder(conn, item.GuardianKey, c.StudentNumber, c.PromiseDate, item.ReminderType))
                            : AlreadySentReminder(conn, item.GuardianKey, item.StudentNumber, item.PromiseDate, item.ReminderType);
                    if (allComponentsSent) continue;
                }
```

This sits inside `try { … }` and before the `if (FeeSmsHelper.TrySend(...))` line. `AlreadySentReminder`
already exists with signature `(SqlConnection, string guardianKey, string studentNumber, DateTime promiseDate, string type)`
and treats `studentNumber == null` via `(StudentNumber IS NULL AND @sn IS NULL)`. `System.Linq` is in scope.

- [ ] **Step 2: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build3.log`. Expect 0 errors.

- [ ] **Step 3: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_smsfix_build3.log
git commit -m "fix(fees-sms): re-check dedup at send time to narrow multi-user race"
```

---

## Task 4: Model fields for reminder counters

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs`

- [ ] **Step 1: Add counter fields to `GuardianWorklistRow`**

In `GuardianWorklistRow` (75-122), after the `CallRequired` property (line ~116), add:

```csharp
    // Reminder activity this term (folded in by GetGuardianWorklist; read-only display).
    public int       RemindersSentCount { get; set; }
    public DateTime? LastReminderDate   { get; set; }
    public string    LastReminderType   { get; set; }
```

- [ ] **Step 2: Add the same fields to `StudentWorklistRow`**

In `StudentWorklistRow` (124-153), after `LastOutcome` (line ~148), add:

```csharp
    public int       RemindersSentCount { get; set; }
    public DateTime? LastReminderDate   { get; set; }
    public string    LastReminderType   { get; set; }
```

- [ ] **Step 3: Verify the test project still compiles (it source-links this file)**

Run: `dotnet build tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj -clp:ErrorsOnly`
Expected: Build succeeded.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs
git commit -m "feat(fees-crm): reminder-count fields on guardian/student worklist rows"
```

---

## Task 5: Service — populate reminder counters (current term)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

- [ ] **Step 1: Add a per-guardian and per-student reminder-summary helper**

Add these two private helpers near `GetGuardiansInGeneralCooldown`:

```csharp
    // (count, lastSentAt, lastType) of reminders within the current term, keyed by GuardianKey.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummaryByGuardian(DateTime? termStart, DateTime? termEnd)
    {
        var map = new Dictionary<string, (int, DateTime, string)>(StringComparer.Ordinal);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            @"SELECT GuardianKey, COUNT(1) AS Cnt, MAX(SentAt) AS LastSent
              FROM tbl_SmsReminderLog
              WHERE GuardianKey IS NOT NULL
                AND (@start IS NULL OR SentAt >= @start)
                AND (@end   IS NULL OR SentAt <  DATEADD(DAY, 1, @end))
              GROUP BY GuardianKey", conn);
        cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = (object)termStart ?? DBNull.Value;
        cmd.Parameters.Add("@end",   SqlDbType.DateTime).Value = (object)termEnd   ?? DBNull.Value;
        using (var rdr = cmd.ExecuteReader())
            while (rdr.Read())
                map[rdr.GetString(0)] = (rdr.GetInt32(1), rdr.GetDateTime(2), "");

        // Resolve the type of each guardian's most-recent reminder in a second pass.
        if (map.Count > 0)
        {
            using var cmd2 = new SqlCommand(
                @"SELECT l.GuardianKey, l.ReminderType
                  FROM tbl_SmsReminderLog l
                  INNER JOIN (SELECT GuardianKey, MAX(SentAt) AS M FROM tbl_SmsReminderLog
                              WHERE GuardianKey IS NOT NULL GROUP BY GuardianKey) x
                    ON x.GuardianKey = l.GuardianKey AND x.M = l.SentAt", conn);
            using var rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {
                string gk = rdr2.GetString(0);
                if (map.TryGetValue(gk, out var v)) map[gk] = (v.Item1, v.Item2, rdr2.IsDBNull(1) ? "" : rdr2.GetString(1));
            }
        }
        return map;
    }

    // (count, lastSentAt, lastType) within the current term, keyed by StudentNumber.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummaryByStudent(DateTime? termStart, DateTime? termEnd)
    {
        var map = new Dictionary<string, (int, DateTime, string)>(StringComparer.Ordinal);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            @"SELECT StudentNumber, COUNT(1) AS Cnt, MAX(SentAt) AS LastSent
              FROM tbl_SmsReminderLog
              WHERE StudentNumber IS NOT NULL
                AND (@start IS NULL OR SentAt >= @start)
                AND (@end   IS NULL OR SentAt <  DATEADD(DAY, 1, @end))
              GROUP BY StudentNumber", conn);
        cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = (object)termStart ?? DBNull.Value;
        cmd.Parameters.Add("@end",   SqlDbType.DateTime).Value = (object)termEnd   ?? DBNull.Value;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            map[rdr.GetString(0)] = (rdr.GetInt32(1), rdr.GetDateTime(2), "");
        return map;
    }
```

- [ ] **Step 2: Apply the guardian summary in `GetGuardianWorklist`**

Read `GetGuardianWorklist` (283…). It builds a `List<GuardianWorklistRow>` (rows are created at ~454 and
returned at the end). Just before the method returns the list, add a post-pass that stamps the counters
onto each row (use the actual local list variable name — e.g. `result`/`rows`/`list`):

```csharp
        var remSummary = GetReminderSummaryByGuardian(settings.TermStartDate, settings.TermEndDate);
        foreach (var row in <theList>)
            if (remSummary.TryGetValue(row.GuardianContact, out var rs))
            {
                row.RemindersSentCount = rs.count;
                row.LastReminderDate   = rs.last;
                row.LastReminderType   = rs.type;
            }
```

Replace `<theList>` with the real variable that is returned. `settings` is already in scope in this method
(it is the `settings` parameter). If term dates aren't configured the helper counts all-time (per spec).

- [ ] **Step 3: Apply the student summary in `GetStudentWorklist`**

`GetStudentWorklist(string classFilter = "", decimal minBalance = 0)` (597) builds `StudentWorklistRow`s
(at ~606). It calls `GetSettings()` internally (it reads `settings.TermStartDate` later at ~645). Capture
those term dates (reuse the existing `settings`/`GetSettings()` value already loaded in the method) and add
a post-pass before the return:

```csharp
        var remByStudent = GetReminderSummaryByStudent(settings.TermStartDate, settings.TermEndDate);
        foreach (var row in <theStudentList>)
            if (remByStudent.TryGetValue(row.StudentNumber, out var rs))
            {
                row.RemindersSentCount = rs.count;
                row.LastReminderDate   = rs.last;
                row.LastReminderType   = rs.type;
            }
```

Use the method's existing settings variable (it already references `settings.TermStartDate`); if the method
names it differently, match that. Replace `<theStudentList>` with the returned list variable.

- [ ] **Step 4: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build5.log`. Expect 0 errors.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_smsfix_build5.log
git commit -m "feat(fees-crm): populate term reminder counts on guardian/student worklists"
```

---

## Task 6: Worklist UI — reminder-count columns

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentWorklist.cs`

- [ ] **Step 1: Add the columns to the guardian worklist**

Read how `usrGuardianWorklist` configures grid columns (search for where it adds columns — e.g. a helper
like `AddCol(...)`, or `gridColumn` creation / `_view.Columns.AddField(...)`). Mirroring the EXISTING
column-adding idiom in that file, add two columns bound to the new fields after the "Last Outcome" column:

```csharp
        // Reminder activity (this term)
        AddCol("RemindersSentCount", "Reminders",      80);
        AddCol("LastReminderDate",   "Last Reminder",  110);
```

- If the file uses a different helper name/signature than `AddCol(fieldName, caption, width)`, use that
  idiom instead (e.g. building a `GridColumn` with `FieldName`/`Caption`/`Visible = true`/`VisibleIndex`).
- For `LastReminderDate`, set a date display format if the file does so for other date columns (e.g.
  `DisplayFormat`/`FormatType.DateTime` with `"dd-MMM-yyyy"`); otherwise leave default. Append
  `LastReminderType` only if it adds value — the date column alone is the spec minimum; if you add it, use
  caption "Last Type", width 90.

- [ ] **Step 2: Add the same columns to the student worklist**

In `usrStudentWorklist`, mirror its column idiom to add (after its last existing column):

```csharp
        AddCol("RemindersSentCount", "Reminders",     80);
        AddCol("LastReminderDate",   "Last Reminder", 110);
```

(Use the real helper/idiom that file uses.)

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build6.log`. Expect 0 errors.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentWorklist.cs notes/IXtreme_smsfix_build6.log
git commit -m "feat(fees-crm): reminder-count columns on guardian/student worklists"
```

---

## Task 7: SMS History dialog + ribbon button

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgSmsHistory.cs`
- Modify: `decompiled/IXtreme/I_Xtreme/MainForm.cs`

- [ ] **Step 1: Create the read-only SMS history dialog**

Create `decompiled/IXtreme/I_Xtreme.DialogForms/dlgSmsHistory.cs`. It is a small, self-contained
DevExpress dialog: a search box + a read-only grid over `tbl_SMSLog` (newest first), filterable by
recipient/message. Model it on the existing dialog style in this folder (a `XtraForm` built in code).

```csharp
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.DialogForms;

public class dlgSmsHistory : XtraForm
{
    private readonly string _connectionString;
    private readonly string _initialFilter;
    private TextEdit _txtSearch;
    private GridControl _grid;
    private GridView _view;
    private DataTable _all = new DataTable();

    public dlgSmsHistory(string connectionString, string initialFilter = "")
    {
        _connectionString = connectionString;
        _initialFilter = initialFilter ?? "";
        InitializeComponent();
        LoadData();
    }

    private void InitializeComponent()
    {
        this.Text = "SMS History";
        this.ClientSize = new System.Drawing.Size(820, 520);
        this.StartPosition = FormStartPosition.CenterParent;

        _txtSearch = new TextEdit { Location = new System.Drawing.Point(12, 12), Width = 520 };
        _txtSearch.Properties.NullValuePrompt = "Search recipient or message…";
        _txtSearch.EditValueChanged += (s, e) => ApplyFilter();

        _grid = new GridControl { Location = new System.Drawing.Point(12, 44),
            Size = new System.Drawing.Size(796, 464),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right };
        _view = new GridView(_grid);
        _grid.MainView = _view;
        _view.OptionsBehavior.Editable = false;
        _view.OptionsView.ColumnAutoWidth = false;

        this.Controls.Add(_txtSearch);
        this.Controls.Add(_grid);
        _txtSearch.Text = _initialFilter;
    }

    private void LoadData()
    {
        try
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var da = new SqlDataAdapter(
                "SELECT [date] AS Sent, recipients AS Recipient, message AS Message, response AS Response " +
                "FROM tbl_SMSLog ORDER BY [date] DESC", conn);
            _all = new DataTable();
            da.Fill(_all);
            ApplyFilter();
            ConfigureColumns();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"Could not load SMS history.\n\n{ex.Message}", "SMS History",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ConfigureColumns()
    {
        if (_view.Columns["Sent"] is { } c0) { c0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime; c0.DisplayFormat.FormatString = "dd-MMM-yyyy HH:mm"; c0.Width = 130; }
        if (_view.Columns["Recipient"] is { } c1) c1.Width = 120;
        if (_view.Columns["Message"]   is { } c2) c2.Width = 420;
        if (_view.Columns["Response"]  is { } c3) c3.Width = 90;
    }

    private void ApplyFilter()
    {
        string q = (_txtSearch?.Text ?? "").Trim().Replace("'", "''");
        var dv = _all.DefaultView;
        dv.RowFilter = string.IsNullOrEmpty(q) ? "" :
            $"CONVERT(Recipient, 'System.String') LIKE '%{q}%' OR CONVERT(Message, 'System.String') LIKE '%{q}%'";
        _grid.DataSource = dv;
    }
}
```

Note: if other dialogs in this folder derive from `DevExpress.XtraEditors.XtraForm` they will already pull
in the needed references; the EXE already references `DevExpress.XtraGrid.v23.2`. If `XtraForm` isn't the
local base, use `System.Windows.Forms.Form` instead (the body is identical). Verify the project compiles
this file before wiring the button.

- [ ] **Step 2: Add the "SMS History" ribbon button (Interactions group)**

In `MainForm.cs`, after the `bbiViewInteractions` field declaration (`private DevExpress.XtraBars.BarButtonItem bbiViewInteractions;`, ≈545) add:

```csharp
	private DevExpress.XtraBars.BarButtonItem bbiSmsHistory;
```

After the `bbiViewInteractions` setup block (its `ItemClick += …` ends ≈24906), add:

```csharp
		this.bbiSmsHistory = new DevExpress.XtraBars.BarButtonItem();
		this.bbiSmsHistory.Name    = "bbiSmsHistory";
		this.bbiSmsHistory.Caption = "SMS History";
		this.bbiSmsHistory.ImageOptions.Image      = I_Xtreme.Properties.Resources.FeesReport;
		this.bbiSmsHistory.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.FeesReport;
		this.bbiSmsHistory.ItemClick += (s, e) =>
		{
			try
			{
				using var dlg = new I_Xtreme.DialogForms.dlgSmsHistory(DataConnection.ConnectToDatabase().ConnectionString);
				dlg.ShowDialog(this);
			}
			catch (Exception ex)
			{
				DevExpress.XtraEditors.XtraMessageBox.Show($"Could not open SMS history.\n\n{ex.Message}",
					"SMS History", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
			}
		};
```

Confirm how the rest of `MainForm` obtains a connection string (the same expression used by other fees
buttons — e.g. `DataConnection.ConnectToDatabase().ConnectionString` or a `connectionString` field). Use the
ACTUAL idiom this file already uses.

After `this.ribbonPageGroupFeesInteractions.ItemLinks.Add(this.bbiViewInteractions);` (≈24911) add:

```csharp
		this.ribbonPageGroupFeesInteractions.ItemLinks.Add(this.bbiSmsHistory);
```

In the `this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { … })` array (≈24914) add
`bbiSmsHistory` (e.g. right after `bbiViewInteractions`).

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build7.log`. Expect 0 errors.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/dlgSmsHistory.cs decompiled/IXtreme/I_Xtreme/MainForm.cs notes/IXtreme_smsfix_build7.log
git commit -m "feat(fees-crm): read-only SMS History dialog + ribbon button"
```

---

## Task 8: View-only ledger from the interaction double-click

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/StudentFeesPayment.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs`

- [ ] **Step 1: Add a view-only constructor overload**

In `StudentFeesPayment.cs`, after the existing `public StudentFeesPayment(string FormMode)` ctor
(758-797), add an overload that chains to it then disables the commit/edit controls:

```csharp
	public StudentFeesPayment(string FormMode, bool viewOnly)
		: this(FormMode)
	{
		if (viewOnly)
		{
			// View-only ledger: bursar can browse the student's fees, but recording lives in Accounts.
			this.Text = "Student Ledger (view only)";
			btnProcessPayment.Enabled = false;
			barButtonItem9.Enabled  = false;   // Bill
			barButtonItem8.Enabled  = false;   // Edit
			barButtonItem10.Enabled = false;
			barButtonItem11.Enabled = false;
			barButtonItem13.Enabled = false;
		}
	}
```

These are exactly the controls the base ctor gates on `CanPayInFees`/`CanBillStudent`/`CanEditFees`
(758-796), so disabling them is well-scoped. Confirm those bar-button identifiers exist as written; if any
differ, disable the actual pay/bill/edit buttons (the `btnProcessPayment` name is stable).

- [ ] **Step 2: Use the view-only ctor from the interaction double-click**

In `dlgFeesContactInteraction.cs`, in `GridStudents_MouseDoubleClick` (501-514), change:

```csharp
        using var dlg = new StudentFeesPayment("SingleStudentPayment");
        dlg.ShowDialog(this);
```

to:

```csharp
        using var dlg = new StudentFeesPayment("SingleStudentPayment", viewOnly: true);
        dlg.ShowDialog(this);
```

Leave the Accounts → Pay In call sites (`usrStudentAccounts.cs`, `usrStudentAccounts*`) untouched — they
keep full payment capability.

- [ ] **Step 3: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build8.log`. Expect 0 errors.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/StudentFeesPayment.cs decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs notes/IXtreme_smsfix_build8.log
git commit -m "fix(fees-crm): open student ledger view-only from interaction double-click"
```

---

## Task 9: Soften worklist colours (pale tints, dark text)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentWorklist.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrDailyWorklist.cs`

- [ ] **Step 1: Replace the guardian worklist `View_RowStyle`**

In `usrGuardianWorklist.cs`, replace `View_RowStyle` (246-266) with:

```csharp
    private void View_RowStyle(object sender, RowStyleEventArgs e)
    {
        var row = _view.GetRow(e.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:      e.Appearance.BackColor = Color.FromArgb(252, 228, 228); e.HighPriority = true; break; // pale red
            case PriorityTier.BrokenPromise: e.Appearance.BackColor = Color.FromArgb(251, 224, 216); e.HighPriority = true; break; // pale coral
            case PriorityTier.Stale:         e.Appearance.BackColor = Color.FromArgb(252, 246, 221); e.HighPriority = true; break; // pale amber
        }
        // CallRequired is a flag orthogonal to the risk tier — colour it from the flag (takes precedence).
        if (row.CallRequired)
        {
            e.Appearance.BackColor = Color.FromArgb(226, 232, 245); e.HighPriority = true; // pale blue
        }
        if (row.IsUnreachable)
        {
            e.Appearance.ForeColor = Color.Gray;   // keep the muted cue for no-phone rows; no italic
        }
    }
```

- [ ] **Step 2: Replace the daily worklist `View_RowStyle`**

In `usrDailyWorklist.cs`, replace `View_RowStyle` (201-221) with the SAME body as Step 1 (it also casts to
`GuardianWorklistRow` and has the identical tier + CallRequired + IsUnreachable structure):

```csharp
    private void View_RowStyle(object sender, RowStyleEventArgs e)
    {
        var row = _view.GetRow(e.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:      e.Appearance.BackColor = Color.FromArgb(252, 228, 228); e.HighPriority = true; break;
            case PriorityTier.BrokenPromise: e.Appearance.BackColor = Color.FromArgb(251, 224, 216); e.HighPriority = true; break;
            case PriorityTier.Stale:         e.Appearance.BackColor = Color.FromArgb(252, 246, 221); e.HighPriority = true; break;
        }
        if (row.CallRequired)
        {
            e.Appearance.BackColor = Color.FromArgb(226, 232, 245); e.HighPriority = true;
        }
        if (row.IsUnreachable)
        {
            e.Appearance.ForeColor = Color.Gray;
        }
    }
```

- [ ] **Step 3: Replace the student worklist `View_RowStyle`**

In `usrStudentWorklist.cs`, replace `View_RowStyle` (231-242) with (it casts to `StudentWorklistRow` and has
a `CallRequired` case in the switch, no separate flag/unreachable blocks):

```csharp
    private void View_RowStyle(object sender, RowStyleEventArgs e)
    {
        var row = _view.GetRow(e.RowHandle) as StudentWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:      e.Appearance.BackColor = Color.FromArgb(252, 228, 228); e.HighPriority = true; break;
            case PriorityTier.BrokenPromise: e.Appearance.BackColor = Color.FromArgb(251, 224, 216); e.HighPriority = true; break;
            case PriorityTier.Stale:         e.Appearance.BackColor = Color.FromArgb(252, 246, 221); e.HighPriority = true; break;
            case PriorityTier.CallRequired:  e.Appearance.BackColor = Color.FromArgb(226, 232, 245); e.HighPriority = true; break;
        }
    }
```

Confirm `using System.Drawing;` (for `Color`) is present in each file — the originals already used `Color`
and `Font`, so it is. The `Font`/`FontStyle.Italic` line is intentionally dropped; if `System.Drawing` was
only pulled in for `Font`, it is still needed for `Color`, so leave the using.

- [ ] **Step 4: Verify build**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_build9.log`. Expect 0 errors.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrGuardianWorklist.cs decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentWorklist.cs decompiled/IXtreme/I_Xtreme.NavigationForms/usrDailyWorklist.cs notes/IXtreme_smsfix_build9.log
git commit -m "feat(fees-crm): softer pale-tint worklist colours with dark text"
```

---

## Task 10: Full verification + glossary + deploy

**Files:**
- Modify: `CLAUDE.md` (Fees Follow-up Glossary)

- [ ] **Step 1: Run the full unit suite**

Run: `dotnet test tests/FeesFollowUp.Tests/FeesFollowUp.Tests.csproj`
Expected: all PASS (FeesUrgency + SmsReminderLogic incl. the new gateway-response theory).

- [ ] **Step 2: Clean rebuild**

Run: `dotnet build decompiled/IXtreme/IXtreme.csproj -t:Rebuild -clp:ErrorsOnly` capturing to `notes/IXtreme_smsfix_final.log`.
Expected: Build succeeded, 0 errors.

- [ ] **Step 3: Update the glossary**

In `CLAUDE.md`, in the Fees Follow-up Glossary "Settings"/"Contact & Interaction" area, add:

```markdown
**Gateway success** — egosms `/plain` returns the literal `OK` on success (some variants return a
positive integer). `SmsReminderLogic.IsGatewaySuccessResponse` is the single source of truth; a non-OK,
non-positive response is a failure. Misreading this as a failure previously suppressed all reminder
logging (so dedup/cooldown never engaged).

**Reminders Sent (column)** — count of `tbl_SmsReminderLog` rows for the guardian/student within the
current term (`TermStartDate`..`TermEndDate`; all-time when term dates are unset), shown with the most
recent reminder date on the guardian and student worklists.

**SMS History** — read-only dialog over `tbl_SMSLog` (actual gateway sends: recipient, message, response,
time), opened from the Interactions ribbon group. Distinct from `tbl_SmsReminderLog`, which is the
per-student dedup ledger.

**View-only ledger** — opening a student from the Log Interaction dialog shows `StudentFeesPayment` with
recording disabled; payments are recorded under Accounts → Pay In.
```

- [ ] **Step 4: Commit**

```bash
git add CLAUDE.md notes/IXtreme_smsfix_final.log
git commit -m "docs(fees-crm): glossary for gateway success, reminder columns, SMS history"
```

- [ ] **Step 5: Finish the branch + smoke test**

Use the superpowers:finishing-a-development-branch skill (the user's prior choice has been "merge to main
locally"). Then redeploy: copy `decompiled/IXtreme/bin/Debug/net472/IXtreme.exe` (+ `.exe.config`) into
`smoke_test/`, launch it, and confirm: the app reaches the Login form; the Fees Follow-up worklists render
with softer pale colours and the new "Reminders / Last Reminder" columns; the Interactions group shows
"SMS History" and it opens; double-clicking a student in Log Interaction opens the ledger with payment
controls disabled.

---

## Self-review notes (spec → tasks)

- §1 gateway success (#1) → Task 1
- §2 cross-channel (#3) → Task 2
- §3 race (#4) → Task 3
- §4 counters + history (#2) → Tasks 4, 5, 6 (counters) + 7 (history)
- §5 view-only ledger (#5) → Task 8
- §6 colours (#6) → Task 9
- verification/docs → Task 10
