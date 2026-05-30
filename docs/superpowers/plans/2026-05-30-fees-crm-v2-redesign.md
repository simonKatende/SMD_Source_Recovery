# Fees CRM v2 Redesign Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Redesign the Fees Follow-up tab into a complete daily operations tool: fix three critical bugs, add a KPI dashboard home, three worklist dialogs (daily/guardian/student), a redesigned interaction dialog with SMS integration, XtraReport printing, and auto-SMS reminders for promises.

**Architecture:** `usrFeesFollowUp` becomes a dashboard-only user control (KPI cards, priority breakdown, top-5). Three worklist dialogs (`dlgDailyWorklist`, `dlgGuardianWorklist`, `dlgStudentWorklist`) open from a new "Worklists" ribbon group and all delegate to the redesigned `dlgFeesContactInteraction`. XtraReports produce properly-formatted printouts matching the rest of the app. Auto-SMS reminders run on dashboard load.

**Tech Stack:** C# 11, .NET 4.7.2, WinForms, DevExpress v23.2 (XtraBars/XtraGrid/XtraReports/XtraEditors), ADO.NET, `AlienAge.ExtremeMessenger.SMSGateWay`, `AlienAge.Security.CryptorEngine`.

---

## Key Facts (confirmed by codebase research)

- `tbl_Stud` guardian columns: `Guardian` (name), `GuardianRelation`, `PriorityContact`, `OtherContact`, `StudyStatus` (values: `"B"` = Border, `"D"` = Day), `StudentID` (the ID number)
- School name: `SELECT TOP 1 SchoolName, fullContact FROM SchoolDetails` — `SchoolName` is encrypted; decrypt with `AlienAge.Security.CryptorEngine.Decrypt(raw, true)`
- SMS: `new SMSGuardian()` (no params) — set `smsForm.txtReceipient.Text` before `ShowDialog()` to pre-fill phone; returns `DialogResult.OK` on successful send
- Fees Payment dialog: `new StudentFeesPayment("SingleStudentPayment")` — before implementing double-click handler, read the form to find how to pre-select a student by number
- Daily list removal: outcomes `Contacted`, `Promised`, `Refused`, `InPerson` remove from today's list; `NoAnswer`, `ContactUnavailable`, `ContactOff` keep on list
- Daily list inclusion: outstanding balance > 0 AND (no promise date OR broken promise) AND not successfully reached today
- Broken promise = latest promise date is in the past AND payments since promise < promise amount

---

## File Map

### Files to Modify
| File | What Changes |
|---|---|
| `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` | Add `GuardianName`, `GuardianRelation`, `Contact2`, `StudentNames`, `PaymentStatus` to `GuardianWorklistRow`; update `GuardianLabel` property; add `StudentId`, `DayBoarder` to `StudentSummary`; add `StudentWorklistRow`, `DashboardData`, `PriorityGroupStats` |
| `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` | Update `GetGuardianWorklist` SQL for guardian name/contact2/student fields; add `GetDailyWorklist`, `GetStudentWorklist`, `GetDashboardData`, `CheckAndSendSmsReminders` |
| `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` | Replace worklist grid with KPI dashboard; update public ribbon API |
| `decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs` | Complete redesign: guardian header with both contacts, student grid columns, outcome label, Save/Save & Next/Clear, SMS flow, double-click student → payment dialog |
| `decompiled/IXtreme/I_Xtreme/MainForm.cs` | Add "Worklists" ribbon group with 3 buttons; remove old "Open Contact View" button |

### Files to Create
| File | Purpose |
|---|---|
| `notes/migrations/2026-05-30_add_SmsReminderLog.sql` | New table for SMS reminder deduplication |
| `decompiled/IXtreme/I_Xtreme.DialogForms/dlgDailyWorklist.cs` | Daily worklist dialog |
| `decompiled/IXtreme/I_Xtreme.DialogForms/dlgGuardianWorklist.cs` | Guardian worklist dialog |
| `decompiled/IXtreme/I_Xtreme.DialogForms/dlgStudentWorklist.cs` | Student worklist dialog |
| `decompiled/IXtreme/I_Xtreme.Reports/rptDailyWorklist.cs` | Daily worklist XtraReport |
| `decompiled/IXtreme/I_Xtreme.Reports/rptGuardianWorklist.cs` | Guardian worklist XtraReport |
| `decompiled/IXtreme/I_Xtreme.Reports/rptStudentWorklist.cs` | Student worklist XtraReport |

---

## Task 1: Fix three existing bugs

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

### Bug 1: Duplicate `#` columns on every refresh

**Root cause:** `_columnsConfigured = false` is set on every `LoadWorklist()` call (line 131), but `ConfigureWorklistColumns()` never clears existing columns before adding new ones. Each refresh appends another `#` and `StudentCountDisplay` column.

- [ ] **Step 1: Read usrFeesFollowUp.cs to confirm line numbers**

- [ ] **Step 2: Remove the flag reset and clear columns before configuring**

In `LoadWorklist()`, remove this line:
```csharp
_columnsConfigured = false;   // reconfigure on each load (class list may change)
```

At the top of `ConfigureWorklistColumns()`, replace the guard check with:
```csharp
private void ConfigureWorklistColumns()
{
    if (_columnsConfigured) return;
    _columnsConfigured = true;
    gridViewWorklist.Columns.Clear();   // clear before re-adding to prevent accumulation
    // ... rest of method unchanged
```

### Bug 2: Class dropdown loses all classes when filtered

**Root cause:** `LoadWorklist()` rebuilds the class combo from `rows` (the already-filtered results). If the class filter = "P.6", only P.6 data returns, so the combo ends up with only "P.6".

- [ ] **Step 3: Track the full class list independently of the filter**

Add a private field:
```csharp
private List<string> _allClasses = new List<string>();
```

Change `LoadWorklist()` to only refresh `_allClasses` when the filter is "All classes":
```csharp
private void LoadWorklist()
{
    string classFilter = cboClass.SelectedIndex <= 0 ? "" : cboClass.SelectedItem?.ToString() ?? "";
    decimal minBal = (decimal)spnMinBalance.Value;

    var rows = _service.GetGuardianWorklist(classFilter, minBal);
    gridWorklist.DataSource = rows;
    ConfigureWorklistColumns();

    if (string.IsNullOrEmpty(classFilter))
    {
        _allClasses = rows.SelectMany(r => r.Students)
                         .Select(s => s.ClassId)
                         .Where(c => !string.IsNullOrEmpty(c))
                         .Distinct().OrderBy(c => c).ToList();
        string selected = cboClass.SelectedIndex > 0 ? cboClass.SelectedItem?.ToString() : null;
        cboClass.Properties.Items.Clear();
        cboClass.Properties.Items.Add("All classes");
        cboClass.Properties.Items.AddRange(_allClasses.Cast<object>().ToArray());
        int idx = selected != null ? cboClass.Properties.Items.IndexOf(selected) : 0;
        cboClass.SelectedIndex = idx >= 0 ? idx : 0;
    }
}
```

### Bug 3: Investigate missing guardians

**Root cause hypothesis:** The `GetGuardianWorklist` SQL most likely filters by a semester ID. If the semester ID used doesn't match the active semester in the database, large numbers of students are silently excluded.

- [ ] **Step 4: Read FeesFollowUpService.cs and locate the semester filter in the SQL**

Look for a `SemesterId` or `SemesterID` parameter in the `GetGuardianWorklist` CTE chain. Identify where the semester value comes from (hardcoded? from `GetSettings()`? from `tbl_Settings`?).

- [ ] **Step 5: Fix the semester filter**

If the semester is hardcoded or read from a stale source, replace it with a query that reads the active semester from the same source used by the main Fees module. The pattern used elsewhere in IXtreme is:
```sql
SELECT TOP 1 SemesterId FROM tbl_Settings ORDER BY Id DESC
-- or
SELECT TOP 1 SemesterID FROM tbl_Semester WHERE IsActive = 1
```

Grep for `tbl_Semester` and `tbl_Settings` in the codebase to find the exact table and column names used by other fee queries, then match that pattern.

- [ ] **Step 6: Build and deploy**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build44.log 2>&1
Select-String "error" notes\IXtreme_build44.log
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe
```

- [ ] **Step 7: Commit**

```
git commit -m "fix(fees-crm): fix duplicate columns on refresh, class dropdown reset, guardian query semester"
```

---

## Task 2: SMS reminder table migration

**Files:**
- Create: `notes/migrations/2026-05-30_add_SmsReminderLog.sql`

- [ ] **Step 1: Write the migration file**

```sql
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'tbl_SmsReminderLog'
)
BEGIN
    CREATE TABLE dbo.tbl_SmsReminderLog (
        Id           INT IDENTITY(1,1) NOT NULL,
        GuardianKey  VARCHAR(20)       NOT NULL,
        PromiseDate  DATE              NOT NULL,
        ReminderType VARCHAR(20)       NOT NULL,   -- '2DayBefore', 'DayOf', 'ThankYou'
        SentAt       DATETIME          NOT NULL CONSTRAINT DF_SmsReminderLog_SentAt DEFAULT GETDATE(),
        CONSTRAINT PK_SmsReminderLog  PRIMARY KEY CLUSTERED (Id ASC),
        CONSTRAINT UQ_SmsReminderLog  UNIQUE (GuardianKey, PromiseDate, ReminderType)
    );
END
```

- [ ] **Step 2: Commit — this must be run manually before deploying the EXE**

```
git commit -m "feat(fees-crm): add migration for tbl_SmsReminderLog (run before deploy)"
```

---

## Task 3: Update data models

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs`

- [ ] **Step 1: Read GuardianWorklistRow.cs in full**

- [ ] **Step 2: Update `StudentSummary` — add StudentId and DayBoarder**

```csharp
public class StudentSummary
{
    public string StudentNumber  { get; set; }
    public string StudentId      { get; set; }   // tbl_Stud.StudentID
    public string FullName       { get; set; }
    public string ClassId        { get; set; }
    public string DayBoarder     { get; set; }   // "D" or "B" (direct from tbl_Stud.StudyStatus)
    public decimal TotalBilled   { get; set; }
    public decimal TotalPaid     { get; set; }
    public decimal Balance       { get; set; }
    public decimal PaymentPercent { get; set; }
}
```

- [ ] **Step 3: Update `GuardianWorklistRow` — add guardian name, Contact2, computed properties**

Replace the class body with:
```csharp
public class GuardianWorklistRow
{
    public string GuardianContact  { get; set; }   // PriorityContact (guardian key)
    public string Contact2         { get; set; }   // OtherContact
    public string GuardianName     { get; set; }   // tbl_Stud.Guardian
    public string GuardianRelation { get; set; }   // tbl_Stud.GuardianRelation

    // "Name (Relation)" when name is known; phone + relation as fallback
    public string GuardianLabel =>
        !string.IsNullOrWhiteSpace(GuardianName)
            ? $"{GuardianName} ({GuardianRelation})"
            : !string.IsNullOrWhiteSpace(GuardianRelation)
                ? $"{GuardianContact} ({GuardianRelation})"
                : GuardianContact;

    public List<StudentSummary> Students          { get; set; } = new();
    public int   StudentCount   => Students.Count;
    public string StudentNames  => string.Join(", ", Students.Select(s => s.FullName));

    public decimal TotalBalance  { get; set; }
    public decimal TotalBilled   { get; set; }
    public decimal TotalPaid     { get; set; }
    public decimal PaymentPercent { get; set; }
    public double  PacingGap     { get; set; }
    public PriorityTier Tier     { get; set; }

    public DateTime?       LastContactDate             { get; set; }
    public ContactOutcome? LastOutcome                 { get; set; }
    public DateTime?       LatestPromiseDate           { get; set; }
    public decimal?        LatestPromiseAmount         { get; set; }
    public decimal         PaymentsSinceLatestPromise  { get; set; }

    public string PaymentStatus =>
        TotalBilled == 0 ? "N/A" :
        TotalPaid >= TotalBilled ? "Fully Paid" :
        TotalPaid == 0 ? "Unpaid" : "Partial";
}
```

- [ ] **Step 4: Add `StudentWorklistRow` at the bottom of the file**

```csharp
public class StudentWorklistRow
{
    public string StudentNumber   { get; set; }
    public string StudentId       { get; set; }
    public string FullName        { get; set; }
    public string ClassId         { get; set; }
    public string DayBoarder      { get; set; }   // "D" or "B"
    public decimal TotalBilled    { get; set; }
    public decimal TotalPaid      { get; set; }
    public decimal Balance        { get; set; }
    public decimal PaymentPercent { get; set; }
    public PriorityTier Tier      { get; set; }
    public string GuardianKey     { get; set; }   // PriorityContact — used to look up guardian
    public string GuardianContact { get; set; }
    public string GuardianName    { get; set; }
    public string GuardianRelation { get; set; }
    public string GuardianLabel =>
        !string.IsNullOrWhiteSpace(GuardianName)
            ? $"{GuardianName} ({GuardianRelation})"
            : GuardianContact;
    public DateTime?       LastContactDate { get; set; }
    public ContactOutcome? LastOutcome     { get; set; }
    public string PaymentStatus =>
        TotalBilled == 0 ? "N/A" :
        TotalPaid >= TotalBilled ? "Fully Paid" :
        TotalPaid == 0 ? "Unpaid" : "Partial";
}
```

- [ ] **Step 5: Add `PriorityGroupStats` and `DashboardData` at the bottom of the file**

```csharp
public class PriorityGroupStats
{
    public PriorityTier Tier          { get; set; }
    public int          GuardianCount { get; set; }
    public decimal      TotalBalance  { get; set; }
}

public class DashboardData
{
    public decimal TotalOutstanding           { get; set; }
    public decimal TotalBilled                { get; set; }
    public decimal TotalCollected             { get; set; }
    public decimal CollectionRate             => TotalBilled == 0 ? 0 : TotalCollected / TotalBilled * 100m;
    public int     TotalGuardiansWithBalance  { get; set; }
    public int     DailyListTotal             { get; set; }   // guardians on today's list (before any contacts)
    public int     DailyListContacted         { get; set; }   // successfully reached today
    public int     DailyListRemaining         => DailyListTotal - DailyListContacted;
    public int     BrokenPromiseCount         { get; set; }
    public int     ActivePromiseCount         { get; set; }
    public List<PriorityGroupStats> ByPriority { get; set; } = new();
    public List<GuardianWorklistRow> TopCritical { get; set; } = new();   // top 5 by balance
    public DateTime AsOf                      { get; set; } = DateTime.Now;
}
```

- [ ] **Step 6: Build to verify no compile errors introduced**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build45.log 2>&1
Select-String "error" notes\IXtreme_build45.log
```

- [ ] **Step 7: Commit**

```
git commit -m "feat(fees-crm): expand data models — guardian name/contact2, student worklist, dashboard data"
```

---

## Task 4: Update service layer

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

### 4a: Update GetGuardianWorklist SQL for new fields

- [ ] **Step 1: Read FeesFollowUpService.cs in full**

- [ ] **Step 2: Update the StudentsWithBalance CTE to include new tbl_Stud columns**

Inside the `StudentsWithBalance` CTE SELECT, add:
```sql
s.Guardian          AS GuardianName,
s.GuardianRelation  AS GuardianRelation,
s.OtherContact      AS Contact2,
s.StudentID         AS StudentId,
s.StudyStatus       AS DayBoarder,
```

In the grouping/aggregation CTE that produces one row per guardian, add:
```sql
MAX(s.Guardian)         AS GuardianName,
MAX(s.GuardianRelation) AS GuardianRelation,
MAX(s.OtherContact)     AS Contact2,
```

- [ ] **Step 3: Update the per-student reader loop to populate new StudentSummary fields**

In the `while (rdr.Read())` section that builds `StudentSummary`, add:
```csharp
student.StudentId  = rdr.IsDBNull(rdr.GetOrdinal("StudentId"))  ? "" : rdr.GetString(rdr.GetOrdinal("StudentId"));
student.DayBoarder = rdr.IsDBNull(rdr.GetOrdinal("DayBoarder")) ? "" : rdr.GetString(rdr.GetOrdinal("DayBoarder"));
```

In the per-guardian reader section that builds `GuardianWorklistRow`, add:
```csharp
row.GuardianName     = rdr.IsDBNull(rdr.GetOrdinal("GuardianName"))     ? "" : rdr.GetString(rdr.GetOrdinal("GuardianName"));
row.GuardianRelation = rdr.IsDBNull(rdr.GetOrdinal("GuardianRelation")) ? "" : rdr.GetString(rdr.GetOrdinal("GuardianRelation"));
row.Contact2         = rdr.IsDBNull(rdr.GetOrdinal("Contact2"))         ? "" : rdr.GetString(rdr.GetOrdinal("Contact2"));
```

### 4b: Add GetDailyWorklist

- [ ] **Step 4: Add private helper WasContactedToday**

```csharp
private bool WasContactedToday(string guardianKey)
{
    const string sql = @"
        SELECT COUNT(1) FROM tbl_FeesContactLog
        WHERE GuardianKey = @key
          AND CAST(ContactDate AS DATE) = CAST(GETDATE() AS DATE)
          AND Outcome IN ('Contacted', 'Promised', 'Refused', 'InPerson')";
    using var conn = new SqlConnection(DataConnection.GetConnectionString());
    using var cmd  = new SqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@key", guardianKey);
    conn.Open();
    return (int)cmd.ExecuteScalar() > 0;
}
```

- [ ] **Step 5: Add GetDailyWorklist**

```csharp
public List<GuardianWorklistRow> GetDailyWorklist(decimal minBalance = 0)
{
    var all   = GetGuardianWorklist("", minBalance);
    var today = DateTime.Today;

    return all.Where(g =>
    {
        // Exclude if there is an active future promise (waiting for guardian to fulfil)
        bool hasActiveFuturePromise =
            g.LatestPromiseDate.HasValue
            && g.LatestPromiseDate.Value.Date >= today
            && g.PaymentsSinceLatestPromise < (g.LatestPromiseAmount ?? 0);
        if (hasActiveFuturePromise) return false;

        // Exclude if successfully reached today
        return !WasContactedToday(g.GuardianContact);
    })
    .OrderBy(g => (int)g.Tier)
    .ThenByDescending(g => g.TotalBalance)
    .ToList();
}
```

### 4c: Add GetStudentWorklist

- [ ] **Step 6: Add GetStudentWorklist**

```csharp
public List<StudentWorklistRow> GetStudentWorklist(string classFilter = "", decimal minBalance = 0)
{
    var guardianRows = GetGuardianWorklist(classFilter, minBalance);
    var result = new List<StudentWorklistRow>();

    foreach (var g in guardianRows)
    {
        foreach (var s in g.Students)
        {
            result.Add(new StudentWorklistRow
            {
                StudentNumber    = s.StudentNumber,
                StudentId        = s.StudentId,
                FullName         = s.FullName,
                ClassId          = s.ClassId,
                DayBoarder       = s.DayBoarder,
                TotalBilled      = s.TotalBilled,
                TotalPaid        = s.TotalPaid,
                Balance          = s.Balance,
                PaymentPercent   = s.PaymentPercent,
                Tier             = g.Tier,
                GuardianKey      = g.GuardianContact,
                GuardianContact  = g.GuardianContact,
                GuardianName     = g.GuardianName,
                GuardianRelation = g.GuardianRelation,
                LastContactDate  = g.LastContactDate,
                LastOutcome      = g.LastOutcome,
            });
        }
    }

    return result
        .OrderBy(s => (int)s.Tier)
        .ThenBy(s => s.ClassId)
        .ThenBy(s => s.FullName)
        .ToList();
}
```

### 4d: Add GetDashboardData

- [ ] **Step 7: Add GetDashboardData**

```csharp
public DashboardData GetDashboardData()
{
    var all   = GetGuardianWorklist("", 0);
    var today = DateTime.Today;

    int contactedToday = all.Count(g => WasContactedToday(g.GuardianContact));

    // Daily list (would exclude those contacted today) + those already contacted today
    int dailyTotal     = GetDailyWorklist(0).Count + contactedToday;

    return new DashboardData
    {
        TotalOutstanding         = all.Sum(g => g.TotalBalance),
        TotalBilled              = all.Sum(g => g.TotalBilled),
        TotalCollected           = all.Sum(g => g.TotalPaid),
        TotalGuardiansWithBalance = all.Count,
        DailyListTotal           = dailyTotal,
        DailyListContacted       = contactedToday,
        BrokenPromiseCount       = all.Count(g => g.Tier == PriorityTier.BrokenPromise),
        ActivePromiseCount       = all.Count(g =>
            g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date >= today),
        ByPriority = Enum.GetValues(typeof(PriorityTier))
            .Cast<PriorityTier>()
            .Select(t => new PriorityGroupStats
            {
                Tier          = t,
                GuardianCount = all.Count(g => g.Tier == t),
                TotalBalance  = all.Where(g => g.Tier == t).Sum(g => g.TotalBalance),
            }).ToList(),
        TopCritical = all.OrderByDescending(g => g.TotalBalance).Take(5).ToList(),
    };
}
```

### 4e: Add school name helper

- [ ] **Step 8: Add private GetSchoolName helper**

```csharp
private string GetSchoolName()
{
    const string sql = "SELECT TOP 1 SchoolName FROM SchoolDetails";
    try
    {
        using var conn = new SqlConnection(DataConnection.GetConnectionString());
        using var cmd  = new SqlCommand(sql, conn);
        conn.Open();
        var raw = cmd.ExecuteScalar() as string ?? "";
        try { return AlienAge.Security.CryptorEngine.Decrypt(raw, true); }
        catch { return raw; }   // return raw if decryption fails
    }
    catch { return ""; }
}
```

- [ ] **Step 9: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build46.log 2>&1
Select-String "error" notes\IXtreme_build46.log
```

- [ ] **Step 10: Commit**

```
git commit -m "feat(fees-crm): update service — guardian name/contact2, daily/student worklist, dashboard data"
```

---

## Task 5: XtraReport layouts for all three worklists

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.Reports/rptDailyWorklist.cs`
- Create: `decompiled/IXtreme/I_Xtreme.Reports/rptGuardianWorklist.cs`
- Create: `decompiled/IXtreme/I_Xtreme.Reports/rptStudentWorklist.cs`

**Prerequisite: Read one existing XtraReport class** to learn how the school header band and data binding are structured. Glob for `*.cs` in `decompiled/IXtreme/I_Xtreme.GeneralReports/` and read the smallest file found.

- [ ] **Step 1: Read an existing XtraReport class from I_Xtreme.GeneralReports/**

Note the pattern for:
- How it inherits from `DevExpress.XtraReports.UI.XtraReport`
- How it binds a `List<T>` as `DataSource`
- How the `PageHeader` band adds school name/address labels
- What method triggers the preview (`ShowRibbonPreview()` or similar)

- [ ] **Step 2: Create shared school-header helper method**

All three reports will use the same header. Create a static helper class in the same namespace:

```csharp
namespace I_Xtreme.Reports;

internal static class ReportHelper
{
    internal static (string name, string contact) GetSchoolInfo()
    {
        const string sql = "SELECT TOP 1 SchoolName, fullContact FROM SchoolDetails";
        try
        {
            using var conn = new SqlConnection(AlienAge.Connectivity.DataConnection.GetConnectionString());
            using var cmd  = new SqlCommand(sql, conn);
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return ("", "");
            string rawName    = rdr.IsDBNull(0) ? "" : rdr.GetString(0);
            string rawContact = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
            string name;
            try { name = AlienAge.Security.CryptorEngine.Decrypt(rawName, true); }
            catch { name = rawName; }
            return (name, rawContact);
        }
        catch { return ("", ""); }
    }

    internal static void AddSchoolHeader(XtraReport report, string reportTitle)
    {
        var (schoolName, contact) = GetSchoolInfo();
        var header = new PageHeaderBand { HeightF = 80f };

        var lblSchool = new XRLabel
        {
            Text = schoolName, Font = new Font("Tahoma", 14, FontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            BoundsF = new RectangleF(0, 0, report.PageWidth - report.Margins.Left - report.Margins.Right, 25),
        };
        var lblContact = new XRLabel
        {
            Text = contact, Font = new Font("Tahoma", 9),
            TextAlignment = TextAlignment.MiddleCenter,
            BoundsF = new RectangleF(0, 26, lblSchool.WidthF, 18),
        };
        var lblTitle = new XRLabel
        {
            Text = reportTitle, Font = new Font("Tahoma", 11, FontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            BoundsF = new RectangleF(0, 46, lblSchool.WidthF, 22),
        };
        header.Controls.AddRange(new XRControl[] { lblSchool, lblContact, lblTitle });
        report.Bands.Add(header);
    }
}
```

- [ ] **Step 3: Create rptDailyWorklist.cs**

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraReports.UI;
using I_Xtreme.Models;

namespace I_Xtreme.Reports;

public class rptDailyWorklist : XtraReport
{
    public rptDailyWorklist(List<GuardianWorklistRow> data)
    {
        this.DataSource = data;
        this.PaperKind  = System.Drawing.Printing.PaperKind.A4;
        this.Landscape  = true;

        ReportHelper.AddSchoolHeader(this, $"Daily Follow-up Worklist — {DateTime.Today:dd-MMMM-yyyy}");
        AddColumnHeader();
        AddDetailBand();
        AddPageFooter();
    }

    private void AddColumnHeader()
    {
        var band = new GroupHeaderBand { HeightF = 22f, PrintAcrossGroupFooter = false };
        float x = 0;
        foreach (var (caption, width) in Columns())
        {
            band.Controls.Add(new XRLabel
            {
                Text = caption, Font = new Font("Tahoma", 8, FontStyle.Bold),
                BoundsF = new RectangleF(x, 0, width, 20),
                BackColor = Color.LightSteelBlue,
                Borders = BorderSide.All,
            });
            x += width;
        }
        this.Bands.Add(band);
    }

    private void AddDetailBand()
    {
        var band = new DetailBand { HeightF = 20f };
        float x = 0;
        string[] fields = { "GuardianLabel", "GuardianContact", "Contact2", "StudentNames",
                            "TotalBalance", "PaymentPercent", "Tier", "LastContactDate", "LastOutcome" };
        var cols = Columns();
        for (int i = 0; i < fields.Length; i++)
        {
            var lbl = new XRLabel
            {
                Font    = new Font("Tahoma", 8),
                BoundsF = new RectangleF(x, 0, cols[i].width, 18),
                Borders = BorderSide.All,
            };
            lbl.DataBindings.Add("Text", null, fields[i]);
            band.Controls.Add(lbl);
            x += cols[i].width;
        }
        band.BeforePrint += (s, e) =>
        {
            if (this.GetCurrentColumnValue("Tier") is PriorityTier tier)
            {
                var backColor = tier switch
                {
                    PriorityTier.Critical      => Color.OrangeRed,
                    PriorityTier.BrokenPromise => Color.LightCoral,
                    PriorityTier.Stale         => Color.LightYellow,
                    _                          => Color.White,
                };
                foreach (XRLabel lbl in band.Controls) lbl.BackColor = backColor;
            }
        };
        this.Bands.Add(band);
    }

    private void AddPageFooter()
    {
        var band = new PageFooterBand { HeightF = 20f };
        band.Controls.Add(new XRPageInfo
        {
            PageInfo = PageInfo.NumberOfTotal, Font = new Font("Tahoma", 8),
            BoundsF  = new RectangleF(0, 0, 200, 18),
        });
        band.Controls.Add(new XRLabel
        {
            Text    = $"Generated: {DateTime.Now:dd-MMM-yyyy HH:mm}",
            Font    = new Font("Tahoma", 8),
            BoundsF = new RectangleF(500, 0, 250, 18),
        });
        this.Bands.Add(band);
    }

    private static (string caption, float width)[] Columns() => new[]
    {
        ("Guardian",      200f), ("Contact",   120f), ("Alt Contact", 120f),
        ("Students",      200f), ("Balance",   110f), ("% Paid",       60f),
        ("Priority",      110f), ("Last Contact", 90f), ("Last Outcome", 100f),
    };
}
```

- [ ] **Step 4: Create rptGuardianWorklist.cs**

Same structure as `rptDailyWorklist`. Differences:
- Title: `"Guardian Worklist"`
- Landscape: `true`
- Columns: `("Guardian", 180f), ("Contact", 110f), ("Alt Contact", 110f), ("Students", 180f), ("Balance", 110f), ("% Paid", 60f), ("Payment Status", 90f), ("Priority", 100f), ("Last Contact", 90f), ("Last Outcome", 100f)`
- Fields: `"GuardianLabel", "GuardianContact", "Contact2", "StudentNames", "TotalBalance", "PaymentPercent", "PaymentStatus", "Tier", "LastContactDate", "LastOutcome"`

- [ ] **Step 5: Create rptStudentWorklist.cs**

Same structure. Differences:
- Title: `"Student Fees Worklist"`
- Landscape: `true`
- DataSource is `List<StudentWorklistRow>`
- Columns: `("Name", 160f), ("Stud#", 90f), ("ID", 90f), ("Class", 50f), ("D/B", 35f), ("Payable", 90f), ("Paid", 90f), ("Balance", 90f), ("% Paid", 55f), ("Status", 75f), ("Priority", 90f), ("Guardian", 140f), ("Contact", 100f), ("Last Contact", 80f), ("Last Outcome", 90f)`
- Fields: `"FullName", "StudentNumber", "StudentId", "ClassId", "DayBoarder", "TotalBilled", "TotalPaid", "Balance", "PaymentPercent", "PaymentStatus", "Tier", "GuardianLabel", "GuardianContact", "LastContactDate", "LastOutcome"`
- No row coloring needed (student tier coloring is optional, add if desired)

- [ ] **Step 6: Add `using` statements and add I_Xtreme.Reports to the csproj if not already present**

Check `decompiled/IXtreme/I_Xtreme.Reports/` — if files don't exist yet, check whether the folder and project reference exist. If the folder is new, add a `<Compile Include="I_Xtreme.Reports\*.cs" />` or ensure the project glob picks it up.

Actually: look at how existing Report classes are structured in `I_Xtreme.GeneralReports`. Are they a separate project or inside the main `IXtreme.csproj`? Follow the same pattern.

- [ ] **Step 7: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build47.log 2>&1
Select-String "error" notes\IXtreme_build47.log
```

- [ ] **Step 8: Commit**

```
git commit -m "feat(fees-crm): add XtraReport layouts for daily, guardian, and student worklists"
```

---

## Task 6: Redesign interaction dialog

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs`

**Before writing any code:** Read the current `dlgFeesContactInteraction.cs` in full AND read the first ~100 lines of `StudentFeesPayment.cs` to find any public method or property that accepts a student number for pre-selection.

- [ ] **Step 1: Read dlgFeesContactInteraction.cs in full**

- [ ] **Step 2: Read StudentFeesPayment.cs lines 1–120 — find student pre-selection method**

Look for a public method like `LoadStudent(string studentNumber)`, `SetStudent(...)`, or a public property `CurrentStudentNumber`. If none exists, the double-click handler will open the dialog in `"SingleStudentPayment"` mode and the bursar manually selects the student (acceptable fallback).

- [ ] **Step 3: Redesign the info header section**

Replace the existing info bar label with a structured panel showing:
- **Line 1** (large, bold): GuardianLabel (name + relationship)
- **Line 2**: `Contact: [Contact1]   Alt: [Contact2]` — use a monospaced or large font so numbers are easy to read while dialing
- **Line 3**: `Balance: UGX [TotalBalance:N0]  ·  [StudentCount] student(s)  ·  [PaymentPercent:F1]% paid`

```csharp
private Label _lblGuardianName, _lblContacts, _lblBalance;

private Panel BuildInfoPanel(GuardianWorklistRow g)
{
    var pnl = new Panel { Dock = DockStyle.Top, Height = 72, BackColor = Color.FromArgb(245, 245, 245) };

    _lblGuardianName = new Label
    {
        Text = g.GuardianLabel, Font = new Font("Tahoma", 13, FontStyle.Bold),
        Location = new Point(8, 6), AutoSize = true,
    };
    _lblContacts = new Label
    {
        Text = $"Contact: {g.GuardianContact}     Alt: {(!string.IsNullOrEmpty(g.Contact2) ? g.Contact2 : "—")}",
        Font = new Font("Consolas", 11),   // monospace so numbers read easily
        Location = new Point(8, 30), AutoSize = true, ForeColor = Color.Navy,
    };
    _lblBalance = new Label
    {
        Text = $"Balance: UGX {g.TotalBalance:N0}   ·   {g.StudentCount} student(s)   ·   {g.PaymentPercent:F1}% paid",
        Font = new Font("Tahoma", 9), ForeColor = Color.DarkRed,
        Location = new Point(8, 52), AutoSize = true,
    };
    pnl.Controls.AddRange(new Control[] { _lblGuardianName, _lblContacts, _lblBalance });
    return pnl;
}
```

- [ ] **Step 4: Update student family grid columns**

The student grid (`gridStudents` / `gridViewStudents`) must show:

| Column | Field | Width |
|---|---|---|
| Student# | `StudentNumber` | 110 |
| Student ID | `StudentId` | 100 |
| Name | `FullName` | 200 |
| Class | `ClassId` | 60 |
| D/B | `DayBoarder` | 45 |
| Total Payable | `TotalBilled` | 110 (N0 format) |
| Balance (UGX) | `Balance` | 110 (N0 format) |
| % Paid | `PaymentPercent` | 70 (F1%) |

Add double-click handler:
```csharp
private void GridViewStudents_DoubleClick(object sender, EventArgs e)
{
    var pt  = gridStudents.PointToClient(Cursor.Position);
    var hit = gridViewStudents.CalcHitInfo(pt);
    if (!hit.InRow) return;
    var student = gridViewStudents.GetRow(hit.RowHandle) as StudentSummary;
    if (student == null) return;

    // See Step 2: if StudentFeesPayment has a pre-select method, use it.
    // Fallback: open in single-student mode (bursar manually selects).
    using var dlg = new StudentFeesPayment("SingleStudentPayment");
    // If a pre-selection method was found in Step 2, call it here before ShowDialog.
    dlg.ShowDialog(this);
}
```

- [ ] **Step 5: Add Outcome label**

Find where the outcome `ComboBoxEdit` is positioned. Immediately before it, add a `LabelControl`:
```csharp
var lblOutcome = new LabelControl
{
    Text     = "Outcome:",
    Location = new Point(outcomeX - 76, outcomeY + 3),
    Width    = 72,
};
```

- [ ] **Step 6: Replace buttons — Save / Save & Next / Clear**

Remove old `btnSaveContact`. Add three buttons:
```csharp
var btnSave     = new SimpleButton { Text = "Save",         Width = 100, Location = new Point(8,  btnY) };
var btnSaveNext = new SimpleButton { Text = "Save && Next", Width = 115, Location = new Point(116, btnY) };
var btnClear    = new SimpleButton { Text = "Clear",        Width = 90,  Location = new Point(239, btnY) };

btnSave.Click     += BtnSave_Click;
btnSaveNext.Click += BtnSaveNext_Click;
btnClear.Click    += BtnClear_Click;
```

`BtnSaveNext_Click`: save the current interaction (call same logic as `BtnSave_Click`), then navigate to next guardian:
```csharp
private void BtnSaveNext_Click(object sender, EventArgs e)
{
    if (!TrySaveContact()) return;   // extract save logic to shared method
    if (_currentIndex < _worklist.Count - 1)
        LoadGuardian(_currentIndex + 1);
    else
        this.DialogResult = DialogResult.OK;   // end of list
}
```

`BtnClear_Click`: reset all input fields:
```csharp
private void BtnClear_Click(object sender, EventArgs e)
{
    rdoPhone.Checked     = true;
    dteContact.DateTime  = DateTime.Today;
    cboOutcome.SelectedIndex = -1;
    txtNote.Text         = "";
    dtePromiseDate.EditValue = null;
    spnPromiseAmount.Value   = 0;
}
```

- [ ] **Step 7: SMS channel flow**

In `BtnSave_Click`, when `rdoSMS.Checked`, open the SMSGuardian dialog before saving:
```csharp
private void BtnSave_Click(object sender, EventArgs e)
{
    if (rdoSMS.Checked)
    {
        var smsForm = new SMSGuardian();
        smsForm.txtReceipient.Text = _current.GuardianContact;
        if (smsForm.ShowDialog(this) != DialogResult.OK) return;   // user cancelled
        // Auto-set outcome to Contacted when SMS sent successfully
        var contactedIdx = cboOutcome.Properties.Items.IndexOf("Contacted");
        if (contactedIdx >= 0) cboOutcome.SelectedIndex = contactedIdx;
    }

    TrySaveContact();
}
```

`TrySaveContact()` contains the existing validation and `service.LogGuardianContact()` call, extracted into a shared method so both `BtnSave_Click` and `BtnSaveNext_Click` use it.

- [ ] **Step 8: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build48.log 2>&1
Select-String "error" notes\IXtreme_build48.log
```

- [ ] **Step 9: Commit**

```
git commit -m "feat(fees-crm): redesign interaction dialog — contacts header, student grid, save-next, SMS flow"
```

---

## Task 7: Dashboard in usrFeesFollowUp

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

Strip the existing worklist grid entirely. Replace with a four-section dashboard. All three worklists become separate dialogs.

- [ ] **Step 1: Read usrFeesFollowUp.cs in full**

- [ ] **Step 2: Rewrite InitializeComponent with dashboard layout**

The dashboard has four sections stacked top to bottom:

**Section 1 — KPI strip (height 100):** Five `GroupControl` cards side by side, each showing a caption and a large bold value:
```
[Total Outstanding UGX] [Collection Rate %] [Guardians with Balance] [Today's Remaining] [Broken Promises]
```

**Section 2 — Priority breakdown (height 130):** A `GridControl` with 4 rows (one per tier), 3 columns: Priority, Guardians, Total Balance.

**Section 3 — Top 5 critical (height 200):** A `GridControl` with columns: Guardian, Balance, Students, Priority. Shows the 5 highest-balance guardians.

**Section 4 — Quick actions + refresh (height 60):**
```csharp
var btnRefresh     = new SimpleButton { Text = "Refresh",              Width = 100 };
var btnDaily       = new SimpleButton { Text = "Open Daily Worklist",  Width = 160 };
var btnGuardian    = new SimpleButton { Text = "Guardian Worklist",    Width = 160 };
var btnStudent     = new SimpleButton { Text = "Student Worklist",     Width = 150 };
btnRefresh.Click  += (s, e) => LoadDashboard();
btnDaily.Click    += (s, e) => OpenDailyWorklist();
btnGuardian.Click += (s, e) => OpenGuardianWorklist();
btnStudent.Click  += (s, e) => OpenStudentWorklist();
```

- [ ] **Step 3: Implement KPI card builder**

```csharp
private Label[] _kpiValues = new Label[5];

private GroupControl BuildKpiCard(int idx, string caption, Color valueColor)
{
    var grp = new GroupControl { Width = 190, Height = 90, Text = caption };
    var lbl = new Label
    {
        Text      = "—",
        Font      = new Font("Tahoma", 18, FontStyle.Bold),
        ForeColor = valueColor,
        Dock      = DockStyle.Fill,
        TextAlign = ContentAlignment.MiddleCenter,
    };
    grp.Controls.Add(lbl);
    _kpiValues[idx] = lbl;
    return grp;
}
```

Create cards:
```csharp
var kpiPanel = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 100, FlowDirection = FlowDirection.LeftToRight };
kpiPanel.Controls.Add(BuildKpiCard(0, "Total Outstanding (UGX)", Color.DarkRed));
kpiPanel.Controls.Add(BuildKpiCard(1, "Collection Rate (%)",     Color.DarkGreen));
kpiPanel.Controls.Add(BuildKpiCard(2, "Guardians with Balance",  Color.DarkBlue));
kpiPanel.Controls.Add(BuildKpiCard(3, "Today's Remaining",       Color.DarkOrange));
kpiPanel.Controls.Add(BuildKpiCard(4, "Broken Promises",         Color.Crimson));
```

- [ ] **Step 4: Implement LoadDashboard and UpdateKpiStrip**

```csharp
private void LoadDashboard()
{
    _service.CheckAndSendSmsReminders();
    var data = _service.GetDashboardData();
    UpdateKpiStrip(data);
    UpdatePriorityBreakdown(data);
    UpdateTopCritical(data);
}

private void UpdateKpiStrip(DashboardData data)
{
    _kpiValues[0].Text = $"{data.TotalOutstanding:N0}";
    _kpiValues[1].Text = $"{data.CollectionRate:F1}%";
    _kpiValues[2].Text = $"{data.TotalGuardiansWithBalance}";
    _kpiValues[3].Text = $"{data.DailyListRemaining} / {data.DailyListTotal}";
    _kpiValues[4].Text = $"{data.BrokenPromiseCount}";
}
```

- [ ] **Step 5: Implement public ribbon API**

```csharp
public void OpenDailyWorklist()
{
    using var dlg = new dlgDailyWorklist();
    dlg.ShowDialog(this);
    LoadDashboard();
}

public void OpenGuardianWorklist()
{
    using var dlg = new dlgGuardianWorklist();
    dlg.ShowDialog(this);
    LoadDashboard();
}

public void OpenStudentWorklist()
{
    using var dlg = new dlgStudentWorklist();
    dlg.ShowDialog(this);
    LoadDashboard();
}

public void OpenSettings()
{
    using var dlg = new FollowUpSettings();
    if (dlg.ShowDialog(this) == DialogResult.OK) LoadDashboard();
}
```

`usrFeesFollowUp_Load` calls `LoadDashboard()`.

- [ ] **Step 6: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build49.log 2>&1
Select-String "error" notes\IXtreme_build49.log
```

- [ ] **Step 7: Commit**

```
git commit -m "feat(fees-crm): replace worklist tab with KPI dashboard"
```

---

## Task 8: Daily Worklist dialog

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgDailyWorklist.cs`

- [ ] **Step 1: Create dlgDailyWorklist.cs**

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;
using I_Xtreme.Reports;

namespace I_Xtreme.DialogForms;

public class dlgDailyWorklist : DevExpress.XtraEditors.XtraForm
{
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private List<GuardianWorklistRow> _allRows = new();
    private DevExpress.XtraGrid.GridControl _grid;
    private GridView _view;
    private TextEdit _txtSearch;

    public dlgDailyWorklist()
    {
        this.Text          = $"Daily Follow-up Worklist — {DateTime.Today:dd-MMM-yyyy}";
        this.Size          = new Size(1150, 680);
        this.StartPosition = FormStartPosition.CenterParent;
        InitLayout();
        this.Load += (s, e) => LoadData();
    }
    // ... see steps 2–7
}
```

- [ ] **Step 2: Build the layout**

Top panel (height 48): `_txtSearch` (width 320, hint "Search guardian name, contact, student..."), Refresh button, Print button, Export button, right-aligned.

Main area: `_grid` docked Fill, `_view` configured:
- `ShowGroupPanel = false`
- `Editable = false`
- `OptionsBehavior.DoubleClickRowAction = DevExpress.XtraGrid.Views.Grid.DoubleClickRowAction.Nothing` (we handle DoubleClick manually)

- [ ] **Step 3: Configure grid columns**

```csharp
private void ConfigureColumns()
{
    _view.Columns.Clear();

    AddUnboundInt("#", 36);
    AddCol("GuardianLabel",   "Guardian",       200);
    AddCol("GuardianContact", "Contact",         120);
    AddCol("Contact2",        "Alt Contact",     120);
    AddCol("StudentNames",    "Students",        200);
    AddNumCol("TotalBalance", "Balance (UGX)",   120);
    AddPctCol("PaymentPercent", "% Paid",         70);
    AddTierCol("Tier",        "Priority",        120);
    AddDateCol("LastContactDate", "Last Contact", 100);
    AddOutcomeCol("LastOutcome",  "Last Outcome", 120);
}
```

Implement `AddUnboundInt`, `AddCol`, `AddNumCol`, `AddPctCol`, `AddTierCol`, `AddDateCol`, `AddOutcomeCol` as private helpers that create `GridColumn` objects with appropriate `DisplayFormat`, `Caption`, and `VisibleIndex`. `AddTierCol` uses `CustomColumnDisplayText` to show "Critical" / "Missed Promise" / "Contact Overdue" / "Up to Date". `AddOutcomeCol` similarly maps enum values to display strings. These helpers are copy-paste from the original `ConfigureWorklistColumns()` logic, extracted into a reusable form.

- [ ] **Step 4: Row coloring**

```csharp
_view.RowStyle += (s, e) =>
{
    var row = _view.GetRow(e.RowHandle) as GuardianWorklistRow;
    if (row == null) return;
    switch (row.Tier)
    {
        case PriorityTier.Critical:
            e.Appearance.BackColor = Color.OrangeRed;
            e.Appearance.ForeColor = Color.White;
            e.HighPriority = true; break;
        case PriorityTier.BrokenPromise:
            e.Appearance.BackColor = Color.LightCoral;
            e.HighPriority = true; break;
        case PriorityTier.Stale:
            e.Appearance.BackColor = Color.LightYellow;
            e.HighPriority = true; break;
    }
};
```

- [ ] **Step 5: Search**

```csharp
_txtSearch.EditValueChanged += (s, e) =>
{
    string q = (_txtSearch.Text ?? "").Trim().ToLower();
    _grid.DataSource = string.IsNullOrEmpty(q) ? _allRows : _allRows.Where(r =>
        r.GuardianLabel.ToLower().Contains(q) ||
        r.GuardianContact.Contains(q) ||
        (r.Contact2 ?? "").Contains(q) ||
        r.Students.Any(st =>
            st.FullName.ToLower().Contains(q) ||
            st.StudentNumber.Contains(q) ||
            st.StudentId.Contains(q))
    ).ToList();
};
```

- [ ] **Step 6: Double-click → interaction dialog**

```csharp
_view.DoubleClick += (s, e) =>
{
    var hit = _view.CalcHitInfo(_grid.PointToClient(Cursor.Position));
    if (!hit.InRow) return;
    var row = _view.GetRow(hit.RowHandle) as GuardianWorklistRow;
    if (row == null) return;
    int idx = _allRows.IndexOf(row);
    if (idx < 0) idx = 0;
    using var dlg = new dlgFeesContactInteraction(_allRows, idx);
    dlg.ShowDialog(this);
    LoadData();   // refresh — contacted rows may disappear from daily list
};
```

- [ ] **Step 7: Print and Export**

```csharp
btnPrint.Click += (s, e) =>
{
    var rpt = new rptDailyWorklist(_allRows);
    rpt.ShowRibbonPreview();
};

btnExport.Click += (s, e) =>
{
    using var save = new SaveFileDialog
    {
        Filter   = "Excel (*.xlsx)|*.xlsx",
        FileName = $"DailyWorklist_{DateTime.Today:yyyyMMdd}.xlsx",
    };
    if (save.ShowDialog() == DialogResult.OK)
        _view.ExportToXlsx(save.FileName);
};
```

- [ ] **Step 8: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build50.log 2>&1
Select-String "error" notes\IXtreme_build50.log
```

- [ ] **Step 9: Commit**

```
git commit -m "feat(fees-crm): add daily worklist dialog with search, row coloring, interaction nav, print"
```

---

## Task 9: Guardian Worklist dialog

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgGuardianWorklist.cs`

Same structure as `dlgDailyWorklist`. Differences:

- [ ] **Step 1: Create dlgGuardianWorklist.cs with these differences from dlgDailyWorklist:**

- Title: `"Guardian Worklist — All Guardians with Outstanding Fees"`
- Has class filter `ComboBoxEdit _cboClass` + min balance `SpinEdit _spnMinBalance` in top panel
- `LoadData()` calls `_service.GetGuardianWorklist(classFilter, minBal)` — note: when class filter changes, rebuild class list only when filter is "All classes" (same fix as Bug 2)
- Additional column: `("PaymentStatus", "Status", 90)` — inserted before Priority

**Grid columns:**
```
# | Guardian (GuardianLabel, 200) | Contact (GuardianContact, 120) | Alt Contact (Contact2, 120) |
Students (StudentNames, 200) | Balance (TotalBalance, 120, N0) | % Paid (PaymentPercent, 70) |
Status (PaymentStatus, 90) | Priority (Tier, 120) | Last Contact (LastContactDate, 100) | Last Outcome (LastOutcome, 120)
```

- Print: `new rptGuardianWorklist(_allRows)`
- Export filename: `$"GuardianWorklist_{DateTime.Today:yyyyMMdd}.xlsx"`

- [ ] **Step 2: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build51.log 2>&1
Select-String "error" notes\IXtreme_build51.log
```

- [ ] **Step 3: Commit**

```
git commit -m "feat(fees-crm): add guardian worklist dialog with payment status, class filter, print"
```

---

## Task 10: Student Worklist dialog

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgStudentWorklist.cs`

- [ ] **Step 1: Create dlgStudentWorklist.cs**

- Title: `"Student Worklist — All Students with Outstanding Fees"`
- DataSource type: `List<StudentWorklistRow>`
- Has class filter + min balance filter
- `LoadData()` calls `_service.GetStudentWorklist(classFilter, minBal)`

**Grid columns:**
```
# | Name (FullName, 180) | Stud# (StudentNumber, 100) | ID (StudentId, 90) |
Class (ClassId, 55) | D/B (DayBoarder, 42) | Payable (TotalBilled, 100, N0) |
Paid (TotalPaid, 100, N0) | Balance (Balance, 100, N0) | % Paid (PaymentPercent, 65) |
Status (PaymentStatus, 80) | Priority (Tier, 110) | Guardian (GuardianLabel, 160) |
Contact (GuardianContact, 110) | Last Contact (LastContactDate, 95) | Last Outcome (LastOutcome, 110)
```

- [ ] **Step 2: Search**

```csharp
_grid.DataSource = _allRows.Where(r =>
    r.FullName.ToLower().Contains(q) ||
    r.StudentNumber.Contains(q) ||
    r.StudentId.Contains(q) ||
    r.GuardianContact.Contains(q) ||
    r.GuardianLabel.ToLower().Contains(q)
).ToList();
```

- [ ] **Step 3: Double-click → interaction dialog for that student's guardian**

```csharp
_view.DoubleClick += (s, e) =>
{
    var hit = _view.CalcHitInfo(_grid.PointToClient(Cursor.Position));
    if (!hit.InRow) return;
    var row = _view.GetRow(hit.RowHandle) as StudentWorklistRow;
    if (row == null) return;

    // Load full guardian worklist to get the GuardianWorklistRow with students list
    var guardianRows = _service.GetGuardianWorklist("", 0);
    var guardianRow  = guardianRows.FirstOrDefault(g => g.GuardianContact == row.GuardianKey);
    if (guardianRow == null) return;

    int idx = guardianRows.IndexOf(guardianRow);
    using var dlg = new dlgFeesContactInteraction(guardianRows, idx);
    dlg.ShowDialog(this);
    LoadData();
};
```

- [ ] **Step 4: Print and Export**

```csharp
btnPrint.Click += (s, e) => new rptStudentWorklist(_allRows).ShowRibbonPreview();
btnExport.Click += ...  // export to xlsx, filename DailyWorklist_...
```

- [ ] **Step 5: Build**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build52.log 2>&1
Select-String "error" notes\IXtreme_build52.log
```

- [ ] **Step 6: Commit**

```
git commit -m "feat(fees-crm): add student worklist dialog with search and guardian interaction"
```

---

## Task 11: Ribbon restructure in MainForm

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme/MainForm.cs`

- [ ] **Step 1: Read the Fees Follow-up ribbon section in MainForm.cs**

Search for `bbiFeesOpenContact` and `ribbonPageGroupFeesSettings` to find:
- Field declaration lines
- InitializeComponent initialization block
- The `ribbonPageGroupFeesSettings.ItemLinks.Add(...)` lines
- The `ribbon.Items.AddRange(...)` call
- The `bbiFeesOpenContact` ItemClick handler

- [ ] **Step 2: Remove bbiFeesOpenContact (replaced by double-click in dialogs)**

Remove: field declaration, initialization block, `ItemLinks.Add` call, entry in `ribbon.Items.AddRange`, and the ItemClick handler.

- [ ] **Step 3: Add field declarations for three new buttons and new ribbon group**

After the existing `bbiFeesSettings` field declaration, add:
```csharp
private DevExpress.XtraBars.BarButtonItem bbiDailyWorklist;
private DevExpress.XtraBars.BarButtonItem bbiGuardianWorklist;
private DevExpress.XtraBars.BarButtonItem bbiStudentWorklist;
private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupFeesWorklists;
```

- [ ] **Step 4: Initialize the new buttons and group in InitializeComponent**

Find the right location (after `bbiFeesSettings` initialization). Add:
```csharp
this.ribbonPageGroupFeesWorklists = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
this.ribbonPageGroupFeesWorklists.Text = "Worklists";

this.bbiDailyWorklist = new DevExpress.XtraBars.BarButtonItem();
this.bbiDailyWorklist.Caption = "Daily\nWorklist";
this.bbiDailyWorklist.LargeGlyph = global::IXtreme.Properties.Resources.inv_catEditCat;
this.bbiDailyWorklist.ItemClick += (s, e) => _usrFeesFollowUp?.OpenDailyWorklist();

this.bbiGuardianWorklist = new DevExpress.XtraBars.BarButtonItem();
this.bbiGuardianWorklist.Caption = "Guardian\nWorklist";
this.bbiGuardianWorklist.LargeGlyph = global::IXtreme.Properties.Resources.inv_catEditCat;
this.bbiGuardianWorklist.ItemClick += (s, e) => _usrFeesFollowUp?.OpenGuardianWorklist();

this.bbiStudentWorklist = new DevExpress.XtraBars.BarButtonItem();
this.bbiStudentWorklist.Caption = "Student\nWorklist";
this.bbiStudentWorklist.LargeGlyph = global::IXtreme.Properties.Resources.inv_catEditCat;
this.bbiStudentWorklist.ItemClick += (s, e) => _usrFeesFollowUp?.OpenStudentWorklist();

this.ribbonPageGroupFeesWorklists.ItemLinks.Add(this.bbiDailyWorklist);
this.ribbonPageGroupFeesWorklists.ItemLinks.Add(this.bbiGuardianWorklist);
this.ribbonPageGroupFeesWorklists.ItemLinks.Add(this.bbiStudentWorklist);
```

**Note on icons:** `inv_catEditCat` is a fallback. Search `Properties/Resources.Designer.cs` for resource names containing `list`, `report`, `worklist`, `students`, or `daily`. Use the best match found; use `inv_catEditCat` if nothing fits.

- [ ] **Step 5: Add the Worklists group to the Fees Follow-up ribbon page**

Find where `ribbonPageGroupFeesSettings` is added to the fees ribbon page. Add `ribbonPageGroupFeesWorklists` BEFORE it:
```csharp
this.ribbonPageFeesFollowUp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
    this.ribbonPageGroupFeesWorklists,
    this.ribbonPageGroupFeesSettings,
    this.ribbonPageGroupFeesPrinting,  // existing
    this.ribbonPageGroupFeesExporting, // existing
});
```

- [ ] **Step 6: Add the three buttons to ribbon.Items.AddRange**

Find the existing `ribbon.Items.AddRange` call and add the three new button items to it.

- [ ] **Step 7: Build and deploy**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build53.log 2>&1
Select-String "error" notes\IXtreme_build53.log
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe
```

- [ ] **Step 8: Commit**

```
git commit -m "feat(fees-crm): add Worklists ribbon group with daily/guardian/student buttons, remove open-contact"
```

---

## Task 12: Auto SMS reminders

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

Complete the `CheckAndSendSmsReminders()` method. Also requires the `tbl_SmsReminderLog` migration (Task 2) to have been run on the database.

- [ ] **Step 1: Add necessary using statements**

Ensure `FeesFollowUpService.cs` has:
```csharp
using AlienAge.ExtremeMessenger;
using AlienAge.Security;
```

- [ ] **Step 2: Add private helpers — AlreadySentReminder and LogReminderSent**

```csharp
private bool AlreadySentReminder(SqlConnection conn, string guardianKey, DateTime promiseDate, string type)
{
    using var cmd = new SqlCommand(
        @"SELECT COUNT(1) FROM tbl_SmsReminderLog
          WHERE GuardianKey=@k AND PromiseDate=@d AND ReminderType=@t", conn);
    cmd.Parameters.AddWithValue("@k", guardianKey);
    cmd.Parameters.AddWithValue("@d", promiseDate.Date);
    cmd.Parameters.AddWithValue("@t", type);
    return (int)cmd.ExecuteScalar() > 0;
}

private void LogReminderSent(SqlConnection conn, string guardianKey, DateTime promiseDate, string type)
{
    using var cmd = new SqlCommand(
        @"INSERT INTO tbl_SmsReminderLog (GuardianKey, PromiseDate, ReminderType, SentAt)
          VALUES (@k, @d, @t, GETDATE())", conn);
    cmd.Parameters.AddWithValue("@k", guardianKey);
    cmd.Parameters.AddWithValue("@d", promiseDate.Date);
    cmd.Parameters.AddWithValue("@t", type);
    cmd.ExecuteNonQuery();
}
```

- [ ] **Step 3: Implement CheckAndSendSmsReminders**

```csharp
public void CheckAndSendSmsReminders()
{
    var today          = DateTime.Today;
    var twoDaysFromNow = today.AddDays(2);
    string schoolName  = GetSchoolName();
    string connStr     = DataConnection.GetConnectionString();

    const string sql = @"
        WITH LatestPromise AS (
            SELECT GuardianKey, MAX(ContactId) AS LatestId
            FROM tbl_FeesContactLog
            WHERE PromiseDate IS NOT NULL AND GuardianKey IS NOT NULL
            GROUP BY GuardianKey
        ),
        PromiseDetail AS (
            SELECT f.GuardianKey, f.PromiseDate, ISNULL(f.PromiseAmount, 0) AS PromiseAmount,
                   MAX(s.Guardian) AS GuardianName
            FROM tbl_FeesContactLog f
            JOIN LatestPromise lp ON lp.LatestId = f.ContactId
            JOIN tbl_Stud s ON s.PriorityContact = f.GuardianKey
            GROUP BY f.GuardianKey, f.PromiseDate, f.PromiseAmount
        ),
        PaidSince AS (
            SELECT st.PriorityContact AS GuardianKey, SUM(p.Credit) AS TotalPaid
            FROM tbl_FeesPayment p
            JOIN tbl_Stud st ON st.StudentNumber = p.StudentNumber
            WHERE p.DateOfPayment >= (
                SELECT MIN(f2.PromiseDate) FROM tbl_FeesContactLog f2
                WHERE f2.GuardianKey = st.PriorityContact AND f2.PromiseDate IS NOT NULL
            )
            GROUP BY st.PriorityContact
        )
        SELECT pd.GuardianKey, pd.PromiseDate, pd.PromiseAmount, pd.GuardianName,
               ISNULL(ps.TotalPaid, 0) AS PaidSince
        FROM PromiseDetail pd
        LEFT JOIN PaidSince ps ON ps.GuardianKey = pd.GuardianKey
        WHERE CAST(pd.PromiseDate AS DATE) IN (@twoDays, @today)
           OR (pd.PromiseDate < @today AND ISNULL(ps.TotalPaid, 0) >= pd.PromiseAmount)";

    using var conn = new SqlConnection(connStr);
    conn.Open();
    using var cmd = new SqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@twoDays", twoDaysFromNow.Date);
    cmd.Parameters.AddWithValue("@today",   today);

    var reminders = new List<(string gk, DateTime pd, decimal pa, string name, decimal paid)>();
    using (var rdr = cmd.ExecuteReader())
    {
        while (rdr.Read())
        {
            reminders.Add((
                rdr.GetString(0),
                rdr.GetDateTime(1).Date,
                rdr.GetDecimal(2),
                rdr.IsDBNull(3) ? "" : rdr.GetString(3),
                rdr.GetDecimal(4)
            ));
        }
    }

    var gw = new SMSGateWay();
    foreach (var (gk, pd, pa, name, paid) in reminders)
    {
        string reminderType =
            pd == twoDaysFromNow.Date ? "2DayBefore" :
            pd == today && paid < pa  ? "DayOf"      :
            pd < today && paid >= pa  ? "ThankYou"   : null;

        if (reminderType == null) continue;
        if (AlreadySentReminder(conn, gk, pd, reminderType)) continue;

        string guardianName = string.IsNullOrWhiteSpace(name) ? "Parent" : name;
        string message = reminderType switch
        {
            "2DayBefore" => $"Dear {guardianName}, this is a reminder that you promised to pay school fees by {pd:dd-MMM-yyyy}. Please ensure payment is ready. — {schoolName}",
            "DayOf"      => $"Dear {guardianName}, today ({pd:dd-MMM-yyyy}) is the day you promised to pay school fees. Please make payment as agreed. — {schoolName}",
            "ThankYou"   => $"Dear {guardianName}, thank you for honouring your school fees payment commitment. We truly appreciate your support. — {schoolName}",
            _            => null
        };
        if (message == null) continue;

        gw.TrySendSMSViaPOST(gk, message, out _);
        LogReminderSent(conn, gk, pd, reminderType);
    }
}
```

- [ ] **Step 4: Final build and deploy**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj > notes\IXtreme_build54.log 2>&1
Select-String "error" notes\IXtreme_build54.log
Copy-Item decompiled\IXtreme\bin\Debug\net472\IXtreme.exe smoke_test\IXtreme.exe
```

- [ ] **Step 5: Commit**

```
git commit -m "feat(fees-crm): add auto SMS reminders for promise dates and payment thank-you"
```

---

## Migrations to run before deploying

In order, run these SQL files against the school database:

1. `notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql` ✅ (already done)
2. `notes/migrations/2026-05-30_add_SmsReminderLog.sql` ← run this before deploying the new EXE

---

## Smoke test after completion

1. Open app → Fees Follow-up tab shows dashboard with KPI cards and priority breakdown
2. All 5 KPI values are populated (not "—")
3. Daily Worklist ribbon button → dialog opens with today's guardians, colors correct, search works
4. Guardian Worklist → all guardians, both contacts visible, payment status column present
5. Student Worklist → student-level rows, D/B column populated, double-click → interaction dialog
6. In any worklist, search by guardian name, phone, student name, student number — results filter correctly
7. Double-click a guardian → interaction dialog shows: name+relationship header, both contacts, balance
8. Double-click a student in the interaction dialog → Fees Payment dialog opens
9. SMS channel → SMSGuardian dialog appears with phone pre-filled; send → interaction auto-logged
10. Print in any worklist → XtraReport viewer with school name header and ribbon toolbar (matches other tabs)
11. Export → `.xlsx` file saves
12. Log a contact with outcome "Contacted" → refresh daily list → that guardian no longer appears
13. Log a promise → set promise date 2 days from now → close and reopen app → SMS reminder fires
