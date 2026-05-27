# Fees CRM Improvements Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Implement the 10 user-requested improvements to the Fees Follow-up CRM tab in IXtreme (post-smoke session on 2026-05-27).

**Architecture:** All changes are incremental to the existing `usrFeesFollowUp` / `FeesFollowUpService` / `FeesContactLog` / `MainForm` files from the previous session. No new projects or assemblies are introduced. Tasks are ordered so each builds cleanly before the next begins; Task 5 (Edit/Delete) depends on Task 2 (contact date field) being complete first, and Task 8 (enum reorder) must update the `ResetContactForm()` default introduced in Task 5.

**Tech Stack:** C# 11 / .NET Framework 4.7.2, `Microsoft.NET.Sdk.WindowsDesktop`, DevExpress v23.2 (XtraBars, XtraGrid, XtraEditors), SQL Server (ADO.NET via `AlienAge.Connectivity.DataConnection`). No automated tests — verification is `dotnet build` + manual smoke-test.

**Branch:** `feat/fees-crm` (already exists; merge to `main` after Task 9).

**Verification convention used throughout:**
1. Build: `dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_buildNN.log"` (increment NN per task, starting at 28 — highest existing log is `IXtreme_build27.log`).
2. Expect: `0 Error(s)`. Investigate any warning count jump > 2 over the previous build.
3. For UI-touching tasks: copy the output EXE to `smoke_test\IXtreme.exe` and exercise the scenario described in the task.
4. Commit message: Conventional Commits format, subject ≤ 72 chars, body lists key changes, trailer on its own line: `Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>`.

---

## File change map

| File | Tasks |
|---|---|
| `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` | 1, 2, 3, 4, 5, 6, 7, 8 |
| `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` | 3, 5, 6, 8 |
| `decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs` | 6, 8 |
| `decompiled/IXtreme/I_Xtreme/MainForm.cs` | 7 |
| `decompiled/IXtreme/I_Xtreme.DialogForms/SMSGuardian.cs` | 9 |
| `decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentList.cs` | 9 |
| `notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql` | 8 (create) |

---

## Task 1: Auto-fit columns + row-count `#` column on both grids (Items 7 + 9)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

- [ ] **Step 1: Wire `CustomUnboundColumnData` for both grids in `InitializeComponent`**

After the existing line `this.gridViewWorklist.RowStyle += GridViewWorklist_RowStyle;`, add:

```csharp
this.gridViewWorklist.CustomUnboundColumnData += GridViewWorklist_UnboundData;
this.gridViewHistory.CustomUnboundColumnData  += GridViewHistory_UnboundData;
```

Add the two handlers alongside the existing `GridViewWorklist_CustomColumnDisplayText` method:

```csharp
private void GridViewWorklist_UnboundData(object sender,
    DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
{
    if (e.Column.FieldName == "#")
        e.Value = e.RowHandle + 1;
}

private void GridViewHistory_UnboundData(object sender,
    DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
{
    if (e.Column.FieldName == "#")
        e.Value = e.RowHandle + 1;
}
```

- [ ] **Step 2: Add `#` column + `BestFitColumns` to `ConfigureWorklistColumns`**

At the top of `ConfigureWorklistColumns()`, immediately after `_columnsConfigured = true;`, insert:

```csharp
var colNum = new DevExpress.XtraGrid.Columns.GridColumn();
colNum.FieldName = "#";
colNum.Caption   = "#";
colNum.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
colNum.OptionsColumn.AllowEdit = false;
colNum.OptionsColumn.ReadOnly  = true;
colNum.Width = 36;
gridViewWorklist.Columns.Add(colNum);
colNum.VisibleIndex = 0;
```

At the **end** of `ConfigureWorklistColumns()` (after the `gridViewWorklist.CustomColumnDisplayText +=` line), add:

```csharp
gridViewWorklist.BestFitColumns();
var colNumFixed = gridViewWorklist.Columns["#"];
if (colNumFixed != null) colNumFixed.Width = 36; // BestFit must not expand the # column
```

- [ ] **Step 3: Add `#` column + `BestFitColumns` to `ConfigureHistoryColumns`**

At the top of `ConfigureHistoryColumns()`, immediately after `_historyColumnsConfigured = true;`, insert:

```csharp
var colNumH = new DevExpress.XtraGrid.Columns.GridColumn();
colNumH.FieldName = "#";
colNumH.Caption   = "#";
colNumH.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
colNumH.OptionsColumn.AllowEdit = false;
colNumH.OptionsColumn.ReadOnly  = true;
colNumH.Width = 36;
gridViewHistory.Columns.Add(colNumH);
colNumH.VisibleIndex = 0;
```

At the **end** of `ConfigureHistoryColumns()` (after the `OptionsBehavior.Editable = false` line), add:

```csharp
gridViewHistory.BestFitColumns();
var noteCol = gridViewHistory.Columns["Note"];
if (noteCol != null) noteCol.Width = Math.Min(noteCol.Width, 200);
var colNumHFixed = gridViewHistory.Columns["#"];
if (colNumHFixed != null) colNumHFixed.Width = 36;
```

- [ ] **Step 4: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build28.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 5: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Navigate to the Fees Follow-up tab. Expected:
- Worklist grid has a `#` column at position 0, numbered 1, 2, 3… (not 0-based).
- History grid for any selected student also has a `#` column at position 0.
- All other columns auto-fit their content on first load.
- The Note column in the history grid is ≤ 200 px wide.

- [ ] **Step 6: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs notes/IXtreme_build28.log
git commit -m "feat(fees-crm): auto-fit columns and row-count # on both grids

Adds a 1-based unbound # column (VisibleIndex=0, Width=36) to both the
worklist and history grids via CustomUnboundColumnData. BestFitColumns()
called once on first configure; Note capped at 200 px, # re-pinned to
36 px after fit so it doesn't balloon.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 2: Back-dated contact date field (Item 2)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

- [ ] **Step 1: Declare new fields**

In the field declarations block (near `private SimpleButton btnSave;`), add:

```csharp
private DevExpress.XtraEditors.LabelControl lblContactDate;
private DevExpress.XtraEditors.DateEdit dteContactDate;
```

- [ ] **Step 2: Shrink channel radio and add date field in `InitializeComponent`**

Find the `rgChannel.Size` line and change width from 400 to 300:

```csharp
// Old:
this.rgChannel.Size = new System.Drawing.Size(400, 36);
// New:
this.rgChannel.Size = new System.Drawing.Size(300, 36);
```

Immediately after the `rgChannel` setup block (before `this.cboOutcome = new ...`), insert:

```csharp
this.lblContactDate = new DevExpress.XtraEditors.LabelControl
{
    Text     = "Date:",
    Location = new System.Drawing.Point(312, 14),
};

this.dteContactDate = new DevExpress.XtraEditors.DateEdit();
((System.ComponentModel.ISupportInitialize)this.dteContactDate.Properties).BeginInit();
this.dteContactDate.Location  = new System.Drawing.Point(342, 8);
this.dteContactDate.Width     = 120;
this.dteContactDate.EditValue = System.DateTime.Today;
((System.ComponentModel.ISupportInitialize)this.dteContactDate.Properties).EndInit();
```

In the `newContactPanel.Controls.Add` block, add both controls:

```csharp
this.newContactPanel.Controls.Add(this.lblContactDate);
this.newContactPanel.Controls.Add(this.dteContactDate);
```

- [ ] **Step 3: Use `dteContactDate.DateTime` in `BtnSave_Click`**

There are two places where `ContactDate = System.DateTime.Now` appears in `BtnSave_Click`: one inside the SMS path (the `smsEntry` object initialiser) and one in the non-SMS path (the `entry` object initialiser). Replace **both** with:

```csharp
ContactDate = dteContactDate.DateTime,
```

- [ ] **Step 4: Reset the date field on successful save**

There are two successful-save cleanup blocks in `BtnSave_Click`. Each currently ends with:

```csharp
memoNote.Text = "";
dtePromiseDate.EditValue = null;
txtPromiseAmount.Value = 0;
gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
```

Add a reset line to **both** blocks so each reads:

```csharp
memoNote.Text = "";
dteContactDate.EditValue = System.DateTime.Today;
dtePromiseDate.EditValue = null;
txtPromiseAmount.Value = 0;
gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
```

- [ ] **Step 5: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build29.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 6: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Select a parent on the worklist. Expected:
- A "Date:" label and date picker appear to the right of the channel radios, defaulting to today.
- Change the date to yesterday, set Channel=Phone, Outcome=Contacted, save.
- History grid shows the new entry with yesterday's date (not today).
- After save, the date picker resets to today.

- [ ] **Step 7: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs notes/IXtreme_build29.log
git commit -m "feat(fees-crm): back-dated contact date field on new-contact form

Adds a DateEdit next to the channel radio (default = today). BtnSave_Click
now uses dteContactDate.DateTime instead of DateTime.Now so staff can
log contacts that happened earlier in the day or on a previous day.
Resets to today after each successful save.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 3: Last 2 payments, active term only (Item 5)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

- [ ] **Step 1: Add `GetCurrentSemester` to `FeesFollowUpService`**

Append inside the class body of `FeesFollowUpService`:

```csharp
/// <summary>
/// Returns the SemesterId of the most recent payment in FeesPayment —
/// a reliable proxy for the current active term. Returns null if the
/// table is empty or all SemesterId values are NULL.
/// </summary>
public string GetCurrentSemester()
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    using var cmd = new SqlCommand(
        "SELECT TOP 1 SemesterId FROM FeesPayment WHERE SemesterId IS NOT NULL ORDER BY DateOfPayment DESC",
        conn);
    return cmd.ExecuteScalar() as string;
}
```

- [ ] **Step 2: Update `GetRecentPayments` signature and query**

Replace the existing `GetRecentPayments` method with:

```csharp
public DataTable GetRecentPayments(string studentNumber, int topN = 2, string semester = null)
{
    var dt = new DataTable();
    using var conn = new SqlConnection(connectionString);
    string semesterClause = string.IsNullOrEmpty(semester)
        ? ""
        : "AND SemesterId = @semester";
    using var da = new SqlDataAdapter($@"
    SELECT TOP ({topN}) DateOfPayment AS PaymentDate, Credit, Particulars
    FROM FeesPayment
    WHERE StudentNumber = @sn AND Credit > 0
    {semesterClause}
    ORDER BY DateOfPayment DESC", conn);
    da.SelectCommand.Parameters.Add("@sn", SqlDbType.VarChar, 50).Value = studentNumber;
    if (!string.IsNullOrEmpty(semester))
        da.SelectCommand.Parameters.Add("@semester", SqlDbType.VarChar, 20).Value = semester;
    da.Fill(dt);
    return dt;
}
```

- [ ] **Step 3: Update the call site in `usrFeesFollowUp`**

In `GridViewWorklist_FocusedRowChanged`, find:

```csharp
var payments = service.GetRecentPayments(row.StudentNumber, 3);
if (payments.Rows.Count == 0)
{
    lblRecentPayments.Text = "Last 3 payments: (none)";
}
else
{
    var parts = new System.Collections.Generic.List<string>();
    foreach (System.Data.DataRow p in payments.Rows)
    {
        decimal amt = p["Credit"] is decimal d ? d : 0m;
        var dt = p["PaymentDate"] is System.DateTime pd ? pd : System.DateTime.MinValue;
        parts.Add($"{amt:N0} ({dt:yyyy-MM-dd})");
    }
    lblRecentPayments.Text = "Last 3 payments: " + string.Join(", ", parts);
}
```

Replace with:

```csharp
string currentSemester = service.GetCurrentSemester();
var payments = service.GetRecentPayments(row.StudentNumber, topN: 2, semester: currentSemester);
string payLabel = currentSemester != null
    ? $"Last 2 payments ({currentSemester}):"
    : "Last 2 payments:";
if (payments.Rows.Count == 0)
{
    lblRecentPayments.Text = $"{payLabel} (none)";
}
else
{
    var parts = new System.Collections.Generic.List<string>();
    foreach (System.Data.DataRow p in payments.Rows)
    {
        decimal amt = p["Credit"] is decimal d ? d : 0m;
        var dt = p["PaymentDate"] is System.DateTime pd ? pd : System.DateTime.MinValue;
        parts.Add($"{amt:N0} ({dt:yyyy-MM-dd})");
    }
    lblRecentPayments.Text = payLabel + " " + string.Join(", ", parts);
}
```

- [ ] **Step 4: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build30.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 5: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Select a parent who has payments this term. Expected:
- Payment strip shows at most 2 entries and includes the semester, e.g. "Last 2 payments (TermII-2026): 500,000 (2026-04-15), 200,000 (2026-03-01)".
- A parent with no payments this term shows "(none)".
- A parent who paid only in a previous term also shows "(none)" — correct, since only current-term payments count.

- [ ] **Step 6: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs `
        decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs `
        notes/IXtreme_build30.log
git commit -m "feat(fees-crm): last 2 payments filtered to active term

GetRecentPayments gains an optional semester param; topN defaults to 2.
GetCurrentSemester() derives the active term from the most recent
FeesPayment.SemesterId. Label updated to 'Last 2 payments (TermX):'.
Falls back to all-time top 2 if the FeesPayment table has no semester data.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 4: Double-click worklist row → open student ledger (Item 4)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

- [ ] **Step 1: Wire the double-click event in `InitializeComponent`**

After the line `this.gridViewWorklist.FocusedRowChanged += GridViewWorklist_FocusedRowChanged;`, add:

```csharp
this.gridWorklist.DoubleClick += GridWorklist_DoubleClick;
```

- [ ] **Step 2: Add the handler**

Add this method alongside `BtnRefresh_Click`:

```csharp
private void GridWorklist_DoubleClick(object sender, System.EventArgs e)
{
    int rh = gridViewWorklist.FocusedRowHandle;
    if (rh < 0) return;
    var row = gridViewWorklist.GetRow(rh) as WorklistRow;
    if (row == null) return;

    // Same pattern as usrStudentList.barButtonItem3_ItemClick
    StudentOptions.SetActiveStudent(row.StudentNumber);
    StudentOptions.SetPaymentMode("SingleStudent");
    using var dlg = new DialogForms.StudentFeesPayment("SingleStudentPayment");
    dlg.ShowDialog(this);
    LoadWorklist(); // balance may have changed after a payment was made
}
```

`StudentOptions` is in the `I_Xtreme` namespace (already imported). `StudentFeesPayment` is in `I_Xtreme.DialogForms` (already imported).

- [ ] **Step 3: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build31.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 4: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

On the Fees Follow-up tab, double-click any worklist row. Expected:
- The `StudentFeesPayment` dialog opens pre-loaded with that student's data.
- Closing the dialog causes the worklist to refresh (new balance reflected immediately).
- Single-click still works normally (right pane populates, no dialog).

- [ ] **Step 5: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs notes/IXtreme_build31.log
git commit -m "feat(fees-crm): double-click worklist row opens student ledger

Double-clicking a row calls StudentOptions.SetActiveStudent/SetPaymentMode
then opens StudentFeesPayment("SingleStudentPayment") — same as the
Students tab. Worklist refreshes on close so balance changes are
visible immediately.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 5: Edit / Delete contact log rows (Item 1)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

**Prerequisite:** Task 2 must be complete (`dteContactDate` must exist on the form).

- [ ] **Step 1: Include `ContactId` in `GetContactHistory`**

In `FeesFollowUpService.GetContactHistory`, change:

```csharp
SELECT ContactDate, Channel, Outcome, Note, LoggedBy, PromiseDate, PromiseAmount
```

to:

```csharp
SELECT ContactId, ContactDate, Channel, Outcome, Note, LoggedBy, PromiseDate, PromiseAmount
```

- [ ] **Step 2: Add `DeleteContact` to `FeesFollowUpService`**

Append inside the class body:

```csharp
public void DeleteContact(int contactId)
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    using var cmd = new SqlCommand(
        "DELETE FROM tbl_FeesContactLog WHERE ContactId = @id", conn);
    cmd.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
    cmd.ExecuteNonQuery();
}
```

- [ ] **Step 3: Add `UpdateContact` to `FeesFollowUpService`**

Append inside the class body:

```csharp
public void UpdateContact(FeesContactLog entry)
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    using var cmd = new SqlCommand(@"
    UPDATE tbl_FeesContactLog
    SET ContactDate   = @ContactDate,
        Channel       = @Channel,
        Outcome       = @Outcome,
        Note          = @Note,
        PromiseDate   = @PromiseDate,
        PromiseAmount = @PromiseAmount
    WHERE ContactId = @ContactId", conn);
    cmd.Parameters.Add("@ContactDate",   SqlDbType.DateTime).Value = entry.ContactDate;
    cmd.Parameters.Add("@Channel",       SqlDbType.VarChar,  20).Value = entry.Channel.ToString();
    cmd.Parameters.Add("@Outcome",       SqlDbType.VarChar,  20).Value = entry.Outcome.ToString();
    cmd.Parameters.Add("@Note",          SqlDbType.NVarChar, 500).Value = (object)entry.Note ?? DBNull.Value;
    cmd.Parameters.Add("@PromiseDate",   SqlDbType.Date).Value = (object)entry.PromiseDate ?? DBNull.Value;
    cmd.Parameters.Add("@PromiseAmount", SqlDbType.Money).Value = (object)entry.PromiseAmount ?? DBNull.Value;
    cmd.Parameters.Add("@ContactId",     SqlDbType.Int).Value = entry.ContactId;
    cmd.ExecuteNonQuery();
}
```

- [ ] **Step 4: Add `_editContactId` field and `PopupMenuShowing` wire in `usrFeesFollowUp`**

In the field declarations block, add:

```csharp
private int _editContactId = -1; // -1 = new-entry mode; >= 0 = editing existing row
```

In `InitializeComponent()`, after `this.gridViewHistory.OptionsBehavior.Editable = false;`, add:

```csharp
this.gridViewHistory.PopupMenuShowing += GridViewHistory_PopupMenuShowing;
```

- [ ] **Step 5: Hide `ContactId` column in `ConfigureHistoryColumns`**

At the top of `ConfigureHistoryColumns()`, immediately after `_historyColumnsConfigured = true;`, add:

```csharp
var colId = gridViewHistory.Columns["ContactId"];
if (colId != null) colId.Visible = false;
```

- [ ] **Step 6: Add `ResetContactForm` helper**

Add this method to `usrFeesFollowUp`:

```csharp
private void ResetContactForm()
{
    _editContactId = -1;
    dteContactDate.EditValue = System.DateTime.Today;
    rgChannel.SelectedIndex = 1;    // Phone (index 1 in current channel radio)
    cboOutcome.SelectedIndex = 1;   // Contacted at index 1 in current enum
                                    // NOTE: Task 8 changes this to index 0
    memoNote.Text = "";
    dtePromiseDate.EditValue = null;
    txtPromiseAmount.Value = 0;
    btnSave.Text = "Save";
    btnSaveAndNext.Enabled = true;
}
```

- [ ] **Step 7: Replace manual cleanup blocks in `BtnSave_Click` with `ResetContactForm()`**

`BtnSave_Click` has two successful-save cleanup blocks (SMS path and non-SMS path). Each currently reads:

```csharp
memoNote.Text = "";
dteContactDate.EditValue = System.DateTime.Today;
dtePromiseDate.EditValue = null;
txtPromiseAmount.Value = 0;
gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
```

Replace **both** with:

```csharp
ResetContactForm();
gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
```

- [ ] **Step 8: Add the edit-mode UPDATE branch in `BtnSave_Click`**

Find the two lines after the null-row guard:

```csharp
var channel = (Models.ContactChannel)rgChannel.EditValue;
var outcome = (Models.ContactOutcome)cboOutcome.SelectedItem;
```

Insert the edit-mode block immediately **after** those two lines and **before** the `if (channel == Models.ContactChannel.SMS)` check:

```csharp
// --- Edit mode: update existing row, skip SMS dialog ---
if (_editContactId >= 0)
{
    var editEntry = new Models.FeesContactLog
    {
        ContactId     = _editContactId,
        StudentNumber = row.StudentNumber,
        ContactDate   = dteContactDate.DateTime,
        LoggedBy      = CurrentUser.GetSystemUser(),
        Channel       = channel,
        Outcome       = outcome,
        Note          = string.IsNullOrWhiteSpace(memoNote.Text) ? null : memoNote.Text,
        PromiseDate   = outcome == Models.ContactOutcome.Promised
                        ? dtePromiseDate.DateTime.Date
                        : (System.DateTime?)null,
        PromiseAmount = (outcome == Models.ContactOutcome.Promised && txtPromiseAmount.Value > 0)
                        ? (decimal?)txtPromiseAmount.Value
                        : null,
    };
    try
    {
        service.UpdateContact(editEntry);
        ResetContactForm();
        gridHistory.DataSource = service.GetContactHistory(row.StudentNumber);
    }
    catch (System.Exception ex)
    {
        XtraMessageBox.Show(ex.Message, "Error",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Hand);
    }
    return;
}
// --- New contact mode continues below ---
```

- [ ] **Step 9: Add `StartEditContact` method**

```csharp
private void StartEditContact(int rowHandle)
{
    var drv = gridViewHistory.GetRow(rowHandle) as System.Data.DataRowView;
    if (drv == null) return;

    _editContactId           = System.Convert.ToInt32(drv["ContactId"]);
    dteContactDate.EditValue = drv["ContactDate"];
    memoNote.Text            = drv["Note"]?.ToString() ?? "";

    if (System.Enum.TryParse(drv["Channel"]?.ToString(), out Models.ContactChannel ch))
        rgChannel.EditValue = ch;
    if (System.Enum.TryParse(drv["Outcome"]?.ToString(), out Models.ContactOutcome oc))
        cboOutcome.SelectedItem = oc;

    dtePromiseDate.EditValue = drv["PromiseDate"] == DBNull.Value ? null : drv["PromiseDate"];
    txtPromiseAmount.Value   = drv["PromiseAmount"] == DBNull.Value
                               ? 0 : System.Convert.ToDecimal(drv["PromiseAmount"]);

    btnSave.Text           = "Update";
    btnSaveAndNext.Enabled = false;
}
```

- [ ] **Step 10: Add `DeleteHistoryRow` method**

```csharp
private void DeleteHistoryRow(int rowHandle)
{
    var drv = gridViewHistory.GetRow(rowHandle) as System.Data.DataRowView;
    if (drv == null) return;
    int contactId = System.Convert.ToInt32(drv["ContactId"]);

    var confirm = XtraMessageBox.Show(
        "Delete this contact log entry? This cannot be undone.",
        "Confirm Delete",
        System.Windows.Forms.MessageBoxButtons.YesNo,
        System.Windows.Forms.MessageBoxIcon.Question);
    if (confirm != System.Windows.Forms.DialogResult.Yes) return;

    var wlistRow = gridViewWorklist.GetFocusedRow() as WorklistRow;
    try
    {
        service.DeleteContact(contactId);
        if (wlistRow != null)
            gridHistory.DataSource = service.GetContactHistory(wlistRow.StudentNumber);
    }
    catch (System.Exception ex)
    {
        XtraMessageBox.Show(ex.Message, "Error",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Hand);
    }
}
```

- [ ] **Step 11: Add `GridViewHistory_PopupMenuShowing` handler**

```csharp
private void GridViewHistory_PopupMenuShowing(object sender,
    DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
{
    if (e.MenuType != DevExpress.XtraGrid.Views.Grid.GridMenuType.Row) return;
    int rh = e.HitInfo.RowHandle;
    if (rh < 0) return;
    gridViewHistory.FocusedRowHandle = rh; // select the right-clicked row
    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Edit",
        (s2, e2) => StartEditContact(rh)));
    e.Menu.Items.Add(new DevExpress.Utils.Menu.DXMenuItem("Delete",
        (s2, e2) => DeleteHistoryRow(rh)));
}
```

If `DevExpress.Utils.Menu` causes an unresolved-namespace error, add `using DevExpress.Utils.Menu;` at the top of `usrFeesFollowUp.cs`, or qualify as shown above.

- [ ] **Step 12: Call `ResetContactForm` when the worklist selection changes**

At the very start of `GridViewWorklist_FocusedRowChanged` (before the `if (e.FocusedRowHandle < 0)` guard), add:

```csharp
ResetContactForm();
```

This ensures that if the user is mid-edit and clicks a different worklist row, the form returns to new-contact mode.

- [ ] **Step 13: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build32.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 14: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Select a parent with at least one existing history row. Expected:
- Right-click a history row → context menu shows "Edit" and "Delete".
- **Edit:** fields populate in the form below; Save button shows "Update"; Save & next is disabled. Saving updates the DB row and refreshes the history grid.
- **Delete:** confirmation dialog → "Yes" removes the row from DB and grid; "No" cancels with no change.
- Clicking a different worklist row resets the form to new-contact mode (button reverts to "Save", Save & next re-enabled).

- [ ] **Step 15: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs `
        decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs `
        notes/IXtreme_build32.log
git commit -m "feat(fees-crm): right-click edit and delete on contact history rows

Right-click a history row to Edit (repopulates form in Update mode) or
Delete (confirms then removes the DB row). Edit mode: btnSave shows
'Update', Save&Next disabled, _editContactId tracks the row being edited.
ResetContactForm() centralises teardown and is called on every worklist
row change so edit state cannot bleed across students.

Service: DeleteContact (DELETE WHERE ContactId), UpdateContact (UPDATE
WHERE ContactId). GetContactHistory SELECT now includes ContactId
(hidden in the grid view).

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 6: Rich student header — photo + guardian contacts (Item 6)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs` (add `StudentDetail` POCO)
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` (add `GetStudentDetail`)
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` (replace header panel)

- [ ] **Step 1: Add `StudentDetail` POCO to `FeesContactLog.cs`**

Append at the bottom of `FeesContactLog.cs`, inside the `I_Xtreme.Models` namespace, after the `FeesContactLog` class:

```csharp
public class StudentDetail
{
    public byte[]  Photo                { get; set; }
    public string  FullName             { get; set; }
    public string  StudentNumber        { get; set; }
    public string  ClassId              { get; set; }
    public string  GuardianContact1     { get; set; }  // tbl_Stud.PriorityContact
    public string  GuardianContact2     { get; set; }  // tbl_Stud.OtherContact
    public string  GuardianRelationship { get; set; }  // tbl_Stud.Guardian (name/relationship)
}
```

- [ ] **Step 2: Add `GetStudentDetail` to `FeesFollowUpService`**

Append inside the class body:

```csharp
/// <summary>
/// Loads the student's photo and guardian contact info for the header panel.
/// Called per row-select (not in GetWorklist) to avoid loading binary photo
/// data for the entire worklist on every refresh.
/// </summary>
public StudentDetail GetStudentDetail(string studentNumber)
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    using var cmd = new SqlCommand(@"
    SELECT Picture, fullName, StudentNumber, ClassId,
           PriorityContact, OtherContact, Guardian
    FROM tbl_Stud
    WHERE StudentNumber = @sn", conn);
    cmd.Parameters.Add("@sn", SqlDbType.VarChar, 50).Value = studentNumber;
    using var rdr = cmd.ExecuteReader();
    if (!rdr.Read()) return null;
    return new StudentDetail
    {
        Photo                = rdr["Picture"] as byte[],
        FullName             = rdr["fullName"]?.ToString(),
        StudentNumber        = rdr["StudentNumber"]?.ToString(),
        ClassId              = rdr["ClassId"]?.ToString(),
        GuardianContact1     = rdr["PriorityContact"]?.ToString(),
        GuardianContact2     = rdr["OtherContact"]?.ToString(),
        GuardianRelationship = rdr["Guardian"]?.ToString(),
    };
}
```

- [ ] **Step 3: Replace header panel field declarations in `usrFeesFollowUp`**

Remove the field declarations for `lblParentHeader` and `lblRecentPayments`. Replace with:

```csharp
private DevExpress.XtraEditors.PictureEdit picStudentPhoto;
private DevExpress.XtraEditors.LabelControl lblStudentName;
private DevExpress.XtraEditors.LabelControl lblStudentIdClass;
private DevExpress.XtraEditors.LabelControl lblGuardian1;
private DevExpress.XtraEditors.LabelControl lblGuardian2;
private DevExpress.XtraEditors.LabelControl lblRecentPayments;  // re-declared; same field name
```

- [ ] **Step 4: Rebuild the `headerPanel` block in `InitializeComponent`**

Find the block that creates `headerPanel`, `lblParentHeader`, and `lblRecentPayments`. Replace the entire block with:

```csharp
this.headerPanel = new System.Windows.Forms.Panel { Dock = DockStyle.Top, Height = 110 };

this.picStudentPhoto = new DevExpress.XtraEditors.PictureEdit();
((System.ComponentModel.ISupportInitialize)this.picStudentPhoto.Properties).BeginInit();
this.picStudentPhoto.Location = new System.Drawing.Point(4, 8);
this.picStudentPhoto.Size     = new System.Drawing.Size(72, 90);
this.picStudentPhoto.Properties.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
this.picStudentPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
((System.ComponentModel.ISupportInitialize)this.picStudentPhoto.Properties).EndInit();

this.lblStudentName = new DevExpress.XtraEditors.LabelControl();
this.lblStudentName.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
this.lblStudentName.AutoSizeMode    = DevExpress.XtraEditors.LabelAutoSizeMode.None;
this.lblStudentName.Size            = new System.Drawing.Size(520, 22);
this.lblStudentName.Location        = new System.Drawing.Point(84, 8);
this.lblStudentName.Text            = "(select a student on the worklist)";

this.lblStudentIdClass = new DevExpress.XtraEditors.LabelControl();
this.lblStudentIdClass.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
this.lblStudentIdClass.Size         = new System.Drawing.Size(520, 16);
this.lblStudentIdClass.Location     = new System.Drawing.Point(84, 32);
this.lblStudentIdClass.Text         = "";

this.lblGuardian1 = new DevExpress.XtraEditors.LabelControl();
this.lblGuardian1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
this.lblGuardian1.Size         = new System.Drawing.Size(520, 16);
this.lblGuardian1.Location     = new System.Drawing.Point(84, 50);
this.lblGuardian1.Text         = "";

this.lblGuardian2 = new DevExpress.XtraEditors.LabelControl();
this.lblGuardian2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
this.lblGuardian2.Size         = new System.Drawing.Size(520, 16);
this.lblGuardian2.Location     = new System.Drawing.Point(84, 68);
this.lblGuardian2.Text         = "";

this.lblRecentPayments = new DevExpress.XtraEditors.LabelControl();
this.lblRecentPayments.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
this.lblRecentPayments.Size         = new System.Drawing.Size(520, 16);
this.lblRecentPayments.Location     = new System.Drawing.Point(84, 88);
this.lblRecentPayments.Text         = "";

this.headerPanel.Controls.Add(this.picStudentPhoto);
this.headerPanel.Controls.Add(this.lblStudentName);
this.headerPanel.Controls.Add(this.lblStudentIdClass);
this.headerPanel.Controls.Add(this.lblGuardian1);
this.headerPanel.Controls.Add(this.lblGuardian2);
this.headerPanel.Controls.Add(this.lblRecentPayments);
```

- [ ] **Step 5: Update the empty-selection state in `GridViewWorklist_FocusedRowChanged`**

Find:

```csharp
if (e.FocusedRowHandle < 0)
{
    lblParentHeader.Text = "(select a parent)";
    lblRecentPayments.Text = "";
    gridHistory.DataSource = null;
    return;
}
```

Replace with:

```csharp
if (e.FocusedRowHandle < 0)
{
    picStudentPhoto.Image   = null;
    lblStudentName.Text     = "(select a student on the worklist)";
    lblStudentIdClass.Text  = "";
    lblGuardian1.Text       = "";
    lblGuardian2.Text       = "";
    lblRecentPayments.Text  = "";
    gridHistory.DataSource  = null;
    return;
}
```

- [ ] **Step 6: Replace the header text line in the row-selection path**

Find (immediately after the row null-check):

```csharp
lblParentHeader.Text = $"{row.FullName}  •  {row.ClassId}  •  Balance UGX {row.Balance:N0}";
```

Replace with the full header-population block. Insert this **before** the `try` block that loads payments and history:

```csharp
// Quick header from the already-loaded WorklistRow
picStudentPhoto.Image   = null;
lblStudentName.Text     = $"{row.FullName}  —  Balance UGX {row.Balance:N0}";
lblStudentIdClass.Text  = "";
lblGuardian1.Text       = "";
lblGuardian2.Text       = "";

try
{
    var detail = service.GetStudentDetail(row.StudentNumber);
    if (detail != null)
    {
        lblStudentIdClass.Text = $"ID: {detail.StudentNumber}  •  Class: {detail.ClassId}";

        string g1    = detail.GuardianContact1 ?? "";
        string rel   = detail.GuardianRelationship ?? "";
        lblGuardian1.Text = string.IsNullOrEmpty(rel)
            ? $"Contact 1: {g1}"
            : $"Guardian ({rel}): {g1}";

        if (!string.IsNullOrEmpty(detail.GuardianContact2))
            lblGuardian2.Text = $"Contact 2: {detail.GuardianContact2}";

        if (detail.Photo != null && detail.Photo.Length > 0)
        {
            try
            {
                picStudentPhoto.Image = System.Drawing.Image.FromStream(
                    new System.IO.MemoryStream(detail.Photo));
            }
            catch { /* corrupt or unsupported photo format — leave blank */ }
        }
    }
}
catch (System.Exception ex)
{
    lblStudentIdClass.Text = $"(error loading student details: {ex.Message})";
}
```

The existing `try` block that loads payments and history remains immediately below this new block — do not remove it.

- [ ] **Step 7: Remove any remaining `lblParentHeader` references**

Search `usrFeesFollowUp.cs` for `lblParentHeader`. If any references remain (e.g. in catch blocks), replace them with `lblStudentName`.

- [ ] **Step 8: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build33.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 9: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Select a parent on the worklist. Expected:
- Photo area on the left (photo if available, blank if not on record; no crash for missing photo).
- Line 1: student name — balance (bold).
- Line 2: student ID + class.
- Line 3: guardian contact (phone + relationship).
- Line 4: second contact phone (blank if not on record).
- Line 5: recent payments strip.
- "Select a student" placeholder reappears when no row is focused.

- [ ] **Step 10: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs `
        decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs `
        decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs `
        notes/IXtreme_build33.log
git commit -m "feat(fees-crm): rich student header with photo and guardian contacts

Replaces the single-line header with a 110px panel: PictureEdit (72x90)
on the left; five label rows on the right (name+balance, ID+class,
guardian+relationship, second contact, recent payments). Photo loaded
from tbl_Stud.Picture on each row-select via GetStudentDetail() — a
targeted per-select query, not bundled into the bulk GetWorklist fetch.
Corrupt/missing photos are silently ignored.

Model: StudentDetail POCO added to FeesContactLog.cs.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 7: Ribbon groups — Settings + Printing & Exporting (Items 3 + 8)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`
- Modify: `decompiled/IXtreme/I_Xtreme/MainForm.cs`

- [ ] **Step 1: Remove inline Settings button from filter strip in `usrFeesFollowUp`**

In `InitializeComponent()`, find and delete the entire `btnSettings` block:

```csharp
var btnSettings = new DevExpress.XtraEditors.SimpleButton { Text = "Settings" };
btnSettings.Location = new System.Drawing.Point(396, 7);
btnSettings.Width = 80;
btnSettings.Click += (s, e) =>
{
    using var dlg = new FollowUpSettings();
    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        LoadWorklist();
};
filterStrip.Controls.Add(btnSettings);
```

- [ ] **Step 2: Add public methods to `usrFeesFollowUp` for ribbon button actions**

Add these four methods outside `InitializeComponent`:

```csharp
public void OpenSettings()
{
    using var dlg = new FollowUpSettings();
    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
        LoadWorklist();
}

public void PrintPreviewWorklist() => gridWorklist.ShowPrintPreview();

public void PrintWorklist() => gridWorklist.Print();

public void ExportWorklistToExcel()
{
    using var dlg = new System.Windows.Forms.SaveFileDialog();
    dlg.Filter   = "Excel files (*.xlsx)|*.xlsx";
    dlg.FileName = $"FeesCRM_Worklist_{System.DateTime.Today:yyyy-MM-dd}.xlsx";
    if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
    try
    {
        gridWorklist.ExportToXlsx(dlg.FileName);
        XtraMessageBox.Show($"Exported to {dlg.FileName}", "School Management Dynamics",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Information);
    }
    catch (System.Exception ex)
    {
        XtraMessageBox.Show(ex.Message, "Export Error",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Hand);
    }
}
```

- [ ] **Step 3: Add ribbon group fields to `MainForm`**

In `MainForm.cs`, in the ribbon field declarations (near `private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageFeesFollowUp;`), add:

```csharp
private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFeesSettings;
private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFeesPrint;
private DevExpress.XtraBars.BarButtonItem bbiFeesSettings;
private DevExpress.XtraBars.BarButtonItem bbiFeesPreview;
private DevExpress.XtraBars.BarButtonItem bbiFeesPrint;
private DevExpress.XtraBars.BarButtonItem bbiFeesExport;
```

- [ ] **Step 4: Wire ribbon groups in `MainForm.InitializeComponent`**

Find the block where `ribbonPageFeesFollowUp` was added (from the original plan's Task 12). After `this.ribbon.Pages.Add(this.ribbonPageFeesFollowUp);`, insert:

```csharp
// --- Fees Follow-up: Settings group ---
this.bbiFeesSettings = new DevExpress.XtraBars.BarButtonItem();
this.bbiFeesSettings.Name    = "bbiFeesSettings";
this.bbiFeesSettings.Caption = "Settings";
this.bbiFeesSettings.ItemClick += (s, e) => _usrFeesFollowUp?.OpenSettings();

this.ribbonPageGroupFeesSettings = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
this.ribbonPageGroupFeesSettings.Name = "ribbonPageGroupFeesSettings";
this.ribbonPageGroupFeesSettings.Text = "Settings";
this.ribbonPageGroupFeesSettings.ItemLinks.Add(this.bbiFeesSettings);

// --- Fees Follow-up: Printing & Exporting group ---
this.bbiFeesPreview = new DevExpress.XtraBars.BarButtonItem();
this.bbiFeesPreview.Name    = "bbiFeesPreview";
this.bbiFeesPreview.Caption = "Preview";
this.bbiFeesPreview.ItemClick += (s, e) => _usrFeesFollowUp?.PrintPreviewWorklist();

this.bbiFeesPrint = new DevExpress.XtraBars.BarButtonItem();
this.bbiFeesPrint.Name    = "bbiFeesPrint";
this.bbiFeesPrint.Caption = "Print";
this.bbiFeesPrint.ItemClick += (s, e) => _usrFeesFollowUp?.PrintWorklist();

this.bbiFeesExport = new DevExpress.XtraBars.BarButtonItem();
this.bbiFeesExport.Name    = "bbiFeesExport";
this.bbiFeesExport.Caption = "Export";
this.bbiFeesExport.ItemClick += (s, e) => _usrFeesFollowUp?.ExportWorklistToExcel();

this.ribbonPageGroupFeesPrint = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
this.ribbonPageGroupFeesPrint.Name = "ribbonPageGroupFeesPrint";
this.ribbonPageGroupFeesPrint.Text = "Printing & Exporting";
this.ribbonPageGroupFeesPrint.ItemLinks.Add(this.bbiFeesPreview);
this.ribbonPageGroupFeesPrint.ItemLinks.Add(this.bbiFeesPrint);
this.ribbonPageGroupFeesPrint.ItemLinks.Add(this.bbiFeesExport);

// Register items with the ribbon manager so they get an ID
this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[]
    { bbiFeesSettings, bbiFeesPreview, bbiFeesPrint, bbiFeesExport });

// Attach both groups to the ribbon page
this.ribbonPageFeesFollowUp.Groups.Add(this.ribbonPageGroupFeesSettings);
this.ribbonPageFeesFollowUp.Groups.Add(this.ribbonPageGroupFeesPrint);
```

- [ ] **Step 5: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build34.log"
```

Expected: `0 Error(s)`. If the build fails with an unresolved `ExportToXlsx`, that method is on `GridControl` from `DevExpress.XtraGrid.v23.2.dll` — already referenced; check for typo.

- [ ] **Step 6: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Navigate to the Fees Follow-up ribbon tab. Expected:
- Two ribbon groups appear: "Settings" (one button) and "Printing & Exporting" (three buttons).
- "Settings" button opens the `FollowUpSettings` dialog; changing the threshold and clicking OK refreshes the worklist.
- Filter strip no longer has a Settings button.
- "Preview" opens the DevExpress print preview for the worklist grid.
- "Export" prompts for a file path, writes an `.xlsx`, shows a confirmation toast.

- [ ] **Step 7: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs `
        decompiled/IXtreme/I_Xtreme/MainForm.cs `
        notes/IXtreme_build34.log
git commit -m "feat(fees-crm): Settings and Printing & Exporting ribbon groups

Moves Settings off the filter strip into a 'Settings' ribbon group on
the Fees Follow-up ribbon page. Adds a 'Printing & Exporting' group
with Preview, Print, Export wired to GridControl.ShowPrintPreview /
Print / ExportToXlsx. Filter strip is now just class filter + min
balance + Refresh.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 8: Revised `ContactOutcome` enum + `ComputeTier` + migration (Item 10)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`
- Create: `notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql`

**Schema note:** No column-type change is needed. `Outcome` is `VARCHAR(20)` and stores enum names as strings. The migration simply remaps the old `WrongContact` string value to `NoAnswer`. Run the migration against the school DB before deploying this build.

- [ ] **Step 1: Update `ContactOutcome` enum in `FeesContactLog.cs`**

Replace:

```csharp
public enum ContactOutcome { NoAnswer, Contacted, Promised, Refused, WrongContact }
```

With:

```csharp
public enum ContactOutcome
{
    Contacted,           // 0 — successfully reached guardian
    NoAnswer,            // 1 — rang but no answer
    ContactUnavailable,  // 2 — number unreachable (out of coverage)
    ContactOff,          // 3 — phone switched off
    Promised,            // 4 — guardian committed to a payment
    Refused,             // 5 — guardian refused to pay
}
```

- [ ] **Step 2: Add `FailedOutcomes` set and update `ComputeTier` in `FeesFollowUpService`**

Add a static field immediately above `ComputeTier`:

```csharp
private static readonly System.Collections.Generic.HashSet<ContactOutcome> FailedOutcomes =
    new System.Collections.Generic.HashSet<ContactOutcome>
    {
        ContactOutcome.NoAnswer,
        ContactOutcome.ContactUnavailable,
        ContactOutcome.ContactOff,
        ContactOutcome.Refused,
    };
```

Replace the body of `ComputeTier` with:

```csharp
private static PriorityTier ComputeTier(WorklistRow r, int stalenessDays)
{
    // Broken promise: promise date has passed and insufficient payments received
    if (r.LatestPromiseDate.HasValue && r.LatestPromiseDate.Value.Date < DateTime.Today)
    {
        decimal promised = r.LatestPromiseAmount ?? (r.Balance + r.PaymentsSinceLatestPromise);
        if (r.PaymentsSinceLatestPromise < promised)
            return PriorityTier.BrokenPromise;
    }
    // Stale: no contact within threshold, OR last contact was a failed outcome
    if (!r.LastContactDate.HasValue
        || (DateTime.Today - r.LastContactDate.Value.Date).TotalDays > stalenessDays
        || (r.LastOutcome.HasValue && FailedOutcomes.Contains(r.LastOutcome.Value)))
    {
        return PriorityTier.Stale;
    }
    return PriorityTier.Current;
}
```

- [ ] **Step 3: Update `GridViewWorklist_CustomColumnDisplayText` in `usrFeesFollowUp`**

Find the `else if (e.Column.FieldName == "LastOutcome" ...)` branch. Replace the switch expression with:

```csharp
e.DisplayText = outcome switch
{
    ContactOutcome.Contacted          => "Contacted",
    ContactOutcome.NoAnswer           => "No Answer",
    ContactOutcome.ContactUnavailable => "Unavailable",
    ContactOutcome.ContactOff         => "Phone Off",
    ContactOutcome.Promised           => "Promised Payment",
    ContactOutcome.Refused            => "Refused",
    _                                 => e.DisplayText,
};
```

- [ ] **Step 4: Fix default `cboOutcome` selection (`Contacted` is now index 0)**

In `InitializeComponent`, change:

```csharp
this.cboOutcome.SelectedIndex = 1; // default Contacted
```

to:

```csharp
this.cboOutcome.SelectedIndex = 0; // Contacted is index 0 in updated enum
```

In `ResetContactForm()`, change:

```csharp
cboOutcome.SelectedIndex = 1;   // Contacted (old enum: NoAnswer=0, Contacted=1)
```

to:

```csharp
cboOutcome.SelectedIndex = 0;   // Contacted is index 0 in updated enum
```

- [ ] **Step 5: Create the migration file**

Create `notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql`:

```sql
-- notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql
--
-- Context: WrongContact is removed from the ContactOutcome enum.
-- Existing rows with Outcome = 'WrongContact' would silently parse
-- to null (Enum.TryParse miss). This UPDATE remaps them to 'NoAnswer'
-- so they display correctly in the history grid.
--
-- Safe to run multiple times (idempotent via WHERE clause).
-- Run manually against the school's SMD SQL Server database BEFORE
-- launching the updated IXtreme.exe.

UPDATE dbo.tbl_FeesContactLog
SET    Outcome = 'NoAnswer'
WHERE  Outcome = 'WrongContact';
```

- [ ] **Step 6: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build35.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 7: Run migration (manual — you do this, not the build)**

In SSMS or Azure Data Studio, connect to the school's SMD database, run `notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql`. Expected: command completes successfully; affected-row count = number of historical `WrongContact` rows (may be 0 if none were logged).

- [ ] **Step 8: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Open the Fees Follow-up tab. Expected:
- Outcome combo shows: Contacted, No Answer, Unavailable, Phone Off, Promised Payment, Refused (6 options; "Wrong Contact" gone).
- Default selection is "Contacted".
- Log a "No Answer" contact for a student and click Refresh: that student's row turns yellow (Stale tier) even if the contact was today.
- Log a "Contacted" contact for the same student and refresh: row returns to default colour (Current tier).

- [ ] **Step 9: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs `
        decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs `
        decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs `
        "notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql" `
        notes/IXtreme_build35.log
git commit -m "feat(fees-crm): revised ContactOutcome enum and outcome-based priority

ContactOutcome reordered: Contacted(0) NoAnswer(1) ContactUnavailable(2)
ContactOff(3) Promised(4) Refused(5). WrongContact removed.

ComputeTier: failed outcomes (NoAnswer, ContactUnavailable, ContactOff,
Refused) now escalate to Stale regardless of contact recency, so
repeatedly unreachable guardians stay surfaced at the top of the worklist.

Migration: notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql
remaps existing WrongContact rows to NoAnswer (run before launch).

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Task 9: Auto-log SMS contacts from the Students tab (Item 11)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/SMSGuardian.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentList.cs`

**Scope note:** Only `usrStudentList.navBarItem18_LinkClicked` is covered here. Bulk ExtremeMessenger fees-reminder SMS logging is a separate follow-on (requires building `AlienAge.ExtremeClasses` from decompiled source first).

- [ ] **Step 1: Add `SentMessage` property to `SMSGuardian`**

In `SMSGuardian.cs`, add a public property to the class body:

```csharp
public string SentMessage { get; private set; } = string.Empty;
```

- [ ] **Step 2: Capture message text before setting `DialogResult.OK` in `SMSGuardian`**

In `simpleButton1_Click`, find:

```csharp
base.DialogResult = DialogResult.OK;
Dispose();
```

Change to:

```csharp
SentMessage = txtMessage.Text;
base.DialogResult = DialogResult.OK;
Dispose();
```

- [ ] **Step 3: Update `navBarItem18_LinkClicked` in `usrStudentList`**

Find:

```csharp
private void navBarItem18_LinkClicked(object sender, NavBarLinkEventArgs e)
{
    using SMSGuardian sMSGuardian = new SMSGuardian();
    sMSGuardian.txtReceipient.Text = lblGuardianPhone.Text;
    sMSGuardian.ShowDialog();
}
```

Replace with:

```csharp
private void navBarItem18_LinkClicked(object sender, NavBarLinkEventArgs e)
{
    using SMSGuardian sMSGuardian = new SMSGuardian();
    sMSGuardian.txtReceipient.Text = lblGuardianPhone.Text;
    if (sMSGuardian.ShowDialog() == System.Windows.Forms.DialogResult.OK
        && !string.IsNullOrEmpty(lblStudentNo.Text))
    {
        try
        {
            new I_Xtreme.ExtremeClasses.FeesFollowUpService().LogContact(
                new I_Xtreme.Models.FeesContactLog
                {
                    StudentNumber = lblStudentNo.Text,
                    ContactDate   = System.DateTime.Now,
                    LoggedBy      = CurrentUser.GetSystemUser(),
                    Channel       = I_Xtreme.Models.ContactChannel.SMS,
                    Outcome       = I_Xtreme.Models.ContactOutcome.Contacted,
                    Note          = string.IsNullOrWhiteSpace(sMSGuardian.SentMessage)
                                    ? "SMS sent from Students tab"
                                    : sMSGuardian.SentMessage,
                });
        }
        catch (System.Exception logEx)
        {
            // Non-critical: auto-log failure must never interrupt the user's SMS flow
            System.Diagnostics.Debug.WriteLine(
                $"FeesFollowUp auto-log failed for {lblStudentNo.Text}: {logEx.Message}");
        }
    }
}
```

Full type qualification (`I_Xtreme.ExtremeClasses.*`, `I_Xtreme.Models.*`) avoids adding new `using` directives to a large decompiled file.

- [ ] **Step 4: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj -fl "-flp:LogFile=notes\IXtreme_build36.log"
```

Expected: `0 Error(s)`.

- [ ] **Step 5: Stage and smoke-test**

```powershell
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe -Force
```

Select a student in the Students tab who has an arrears balance. Click "SMS guardian", type a message, send. Expected:
- SMS sends normally (existing UX unchanged).
- Navigate to the Fees Follow-up tab, find that student in the worklist, select them.
- History grid contains a new row: Channel=SMS, Outcome=Contacted, Note= the message you typed.

Click Cancel in SMS guardian for a different student. Expected:
- No log entry written for that student.

- [ ] **Step 6: Commit**

```powershell
git add decompiled/IXtreme/I_Xtreme.DialogForms/SMSGuardian.cs `
        decompiled/IXtreme/I_Xtreme.NavigationForms/usrStudentList.cs `
        notes/IXtreme_build36.log
git commit -m "feat(fees-crm): auto-log SMS contacts sent from Students tab

When navBarItem18_LinkClicked (SMS guardian) closes with DialogResult.OK,
a FeesContactLog row is written (Channel=SMS, Outcome=Contacted,
Note=message text). LogContact failure is swallowed with Debug.WriteLine
so a DB issue never blocks the SMS flow. Cancelled or failed sends
produce no log entry.

SMSGuardian gains SentMessage { get; private set; } (set before
DialogResult.OK) so the caller can read the sent text without coupling
to the dialog's internal TextEdit.

Co-Authored-By: Claude Opus 4.7 (1M context) <noreply@anthropic.com>"
```

---

## Final step: merge to main

After Task 9 passes smoke-test:

```powershell
git checkout main
git merge --ff-only feat/fees-crm
```

---

## Notes for the implementer

- **Migration timing:** Task 8's SQL must be run against the school DB **before** the Task 8 build is deployed. Tasks 1–7 require no schema changes.
- **`ResetContactForm()` default index:** Task 5 sets `cboOutcome.SelectedIndex = 1` (Contacted in the old enum). Task 8 must update it to `SelectedIndex = 0` (Step 4). Do not skip Task 8 Step 4.
- **ExtremeMessenger:** Bulk SMS auto-logging is out of scope here. It would require building `AlienAge.ExtremeClasses` from the decompiled library source — a separate session.
- **`backup/` and `smoke_test/` are gitignored** — never stage either directory.
- **Build log numbering:** This plan uses build28–build36. The previous highest log was `IXtreme_build27.log`.
- **DevExpress `ExportToXlsx`:** Ships in `DevExpress.XtraGrid.v23.2.dll` (already referenced). No additional NuGet or HintPath change needed.
