# Fees CRM Guardian Redesign Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Redesign the Fees Follow-up CRM so the worklist is guardian-centric (one row per guardian family, not per student), logs one contact event per guardian call rather than per student, fixes the balance bug (showing billed instead of outstanding), adds a pacing-based "Critical" priority tier, and opens an interaction dialog with student breakdown and back/next navigation.

**Architecture:** The worklist data model shifts from `WorklistRow` (per-student) to `GuardianWorklistRow` (per-guardian, containing a `List<StudentSummary>`). `FeesFollowUpService` gains a `GetGuardianWorklist()` method that queries outstanding balance (billed − paid) and groups students by guardian contact. A new `dlgFeesContactInteraction` dialog hosts the per-guardian interaction: student breakdown grid, contact history, log form, and back/next navigation. A DB migration adds `GuardianKey` to `tbl_FeesContactLog` so guardian-level contacts are stored as a single row rather than N per-student copies.

**Tech Stack:** C# 11, .NET Framework 4.7.2, WinForms, DevExpress v23.2 (XtraGrid, XtraEditors, XtraBars/Ribbon), ADO.NET (SqlConnection), `AlienAge.Connectivity.DataConnection`

---

## File Map

| Action | File |
|---|---|
| Create | `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs` |
| Create | `decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs` |
| Create | `notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql` |
| Modify | `decompiled/IXtreme/I_Xtreme.Models/WorklistRow.cs` — add `Critical = 0` to `PriorityTier` |
| Modify | `decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs` — add `GuardianKey` property |
| Modify | `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs` — new service methods |
| Modify | `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs` — full rewrite to guardian grid |
| Modify | `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs` — term dates + critical threshold |
| Modify | `decompiled/IXtreme/I_Xtreme/MainForm.cs` — add "Open Contact View" ribbon button |

---

## Task 1: DB Migration — Add GuardianKey + Document Balance Bug

**Files:**
- Create: `notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql`

**Context:** `tbl_FeesContactLog` currently only has `StudentNumber`. Guardian-level contacts need a `GuardianKey` column so one contact row covers a whole family. Existing rows get `NULL`, which the service handles as "old student-level entry". The balance bug (showing `cashOnAccount` = total billed instead of outstanding = billed − paid) is fixed in Task 3's new `GetGuardianWorklist()` — no action needed on the old `GetWorklist()`.

- [ ] **Step 1: Write migration SQL**

```sql
-- notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql
--
-- Context: Guardian-level contacts are stored as one row per guardian instead
-- of one row per student. GuardianKey holds the guardian's primary phone number
-- (same value used as the grouping key in GetGuardianWorklist).
-- Existing rows keep GuardianKey = NULL; the service queries by
-- (GuardianKey = @key) OR (GuardianKey IS NULL AND StudentNumber IN (...)).
--
-- Safe to run multiple times (idempotent via column-existence check).
-- Run manually against the school's SMD SQL Server database BEFORE
-- launching the updated IXtreme.exe.

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'tbl_FeesContactLog' AND COLUMN_NAME = 'GuardianKey'
)
BEGIN
    ALTER TABLE dbo.tbl_FeesContactLog
    ADD GuardianKey VARCHAR(20) NULL;
END
```

- [ ] **Step 2: Commit**

```bash
git add notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql
git commit -m "feat(fees-crm): add migration for GuardianKey column on tbl_FeesContactLog"
```

---

## Task 2: Models — PriorityTier, GuardianWorklistRow, FeesContactLog.GuardianKey

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.Models/WorklistRow.cs`
- Modify: `decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs`
- Create: `decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs`

**Context:** `PriorityTier` lives in `WorklistRow.cs`. Adding `Critical = 0` makes it sort before `BrokenPromise = 1` (existing sort uses `a.Tier.CompareTo(b.Tier)` ascending). `GuardianWorklistRow` and `StudentSummary` are new POCOs used by the service and UI. `FeesFollowUpSettings` replaces the one-field-at-a-time settings API.

- [ ] **Step 1: Update `WorklistRow.cs` — add Critical tier**

Replace line 5 in `WorklistRow.cs`:

```csharp
public enum PriorityTier { Critical = 0, BrokenPromise = 1, Stale = 2, Current = 3 }
```

- [ ] **Step 2: Update `FeesContactLog.cs` — add GuardianKey to FeesContactLog**

Add `GuardianKey` property after `StudentNumber`:

```csharp
public class FeesContactLog
{
    public int ContactId { get; set; }
    public string StudentNumber { get; set; }
    public string GuardianKey { get; set; }   // non-null for guardian-level contacts
    public DateTime ContactDate { get; set; }
    public string LoggedBy { get; set; }
    public ContactChannel Channel { get; set; }
    public ContactOutcome Outcome { get; set; }
    public string Note { get; set; }
    public DateTime? PromiseDate { get; set; }
    public decimal? PromiseAmount { get; set; }
}
```

- [ ] **Step 3: Create `GuardianWorklistRow.cs`**

```csharp
using System;
using System.Collections.Generic;

namespace I_Xtreme.Models;

public class FeesFollowUpSettings
{
    public int    StaleThresholdDays         { get; set; } = 7;
    public DateTime? TermStartDate           { get; set; }
    public DateTime? TermEndDate             { get; set; }
    public double CriticalPacingGapThreshold { get; set; } = 0.50;
}

public class StudentSummary
{
    public string  StudentNumber  { get; set; }
    public string  FullName       { get; set; }
    public string  ClassId        { get; set; }
    public decimal TotalBilled    { get; set; }
    public decimal TotalPaid      { get; set; }
    public decimal Balance        { get; set; }
    public decimal PaymentPercent { get; set; }  // TotalPaid/TotalBilled*100, rounded to 1dp
}

public class GuardianWorklistRow
{
    // Key used to group students and to store in tbl_FeesContactLog.GuardianKey.
    // Format: phone number (10-13 chars), or "NOCONTACT-{StudentNumber}" when
    // both PriorityContact and OtherContact are blank.
    public string GuardianContact { get; set; }

    // Display label shown in the worklist, e.g. "0771234567 (Mother)"
    public string GuardianLabel { get; set; }

    public List<StudentSummary> Students { get; set; } = new();
    public int StudentCount => Students.Count;

    // Aggregates across all students in this group
    public decimal TotalBalance    { get; set; }
    public decimal TotalBilled     { get; set; }
    public decimal TotalPaid       { get; set; }
    public decimal PaymentPercent  { get; set; }  // TotalPaid/TotalBilled*100

    // Pacing: (TermElapsedDays/TermTotalDays) − (TotalPaid/TotalBilled).
    // Positive = behind payment pace. 0.0 when term dates not configured.
    public double PacingGap { get; set; }

    public PriorityTier    Tier              { get; set; }
    public DateTime?       LastContactDate   { get; set; }
    public ContactOutcome? LastOutcome       { get; set; }
    public DateTime?       LatestPromiseDate { get; set; }
    public decimal?        LatestPromiseAmount { get; set; }
    public decimal         PaymentsSinceLatestPromise { get; set; }
}
```

- [ ] **Step 4: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors.

- [ ] **Step 5: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.Models/WorklistRow.cs \
        decompiled/IXtreme/I_Xtreme.Models/FeesContactLog.cs \
        decompiled/IXtreme/I_Xtreme.Models/GuardianWorklistRow.cs
git commit -m "feat(fees-crm): add GuardianWorklistRow, StudentSummary, FeesFollowUpSettings; Critical tier"
```

---

## Task 3: Service — GetGuardianWorklist (balance fix + guardian grouping + pacing)

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

**Context:** `GetGuardianWorklist()` replaces `GetWorklist()` as the data source for the redesigned form. It fixes the balance bug by computing `cashOnAccount − SUM(FeesPayment.Credit)` (filtered to the configured term dates when set). It groups students by `GuardianKey` (Contact1 → Contact2 → synthetic key) in C# after a single SQL pass. `ComputeGuardianTier()` adds the Critical tier check. Add `GetSettings()` and `SaveSettings()` here too since they're needed by this method.

- [ ] **Step 1: Add `GetSettings()` and `SaveSettings()` to the service**

Add after `SetStalenessThresholdDays()` (around line 42 of the current file):

```csharp
public FeesFollowUpSettings GetSettings()
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    using var cmd = new SqlCommand(
        "SELECT SettingKey, SettingValue FROM tbl_FollowUpSettings", conn);
    var dict = new Dictionary<string, string>();
    using var rdr = cmd.ExecuteReader();
    while (rdr.Read())
        dict[rdr.GetString(0)] = rdr.GetString(1) ?? "";

    return new FeesFollowUpSettings
    {
        StaleThresholdDays =
            dict.TryGetValue("StalenessThresholdDays", out var sd) && int.TryParse(sd, out int d) ? d : 7,
        TermStartDate =
            dict.TryGetValue("TermStartDate", out var ts) && DateTime.TryParse(ts, out DateTime tsd) ? tsd : (DateTime?)null,
        TermEndDate =
            dict.TryGetValue("TermEndDate", out var te) && DateTime.TryParse(te, out DateTime ted) ? ted : (DateTime?)null,
        CriticalPacingGapThreshold =
            dict.TryGetValue("CriticalPacingGapThreshold", out var ct) && double.TryParse(ct, out double ctd) ? ctd : 0.50,
    };
}

public void SaveSettings(FeesFollowUpSettings s)
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    Upsert(conn, "StalenessThresholdDays",        s.StaleThresholdDays.ToString());
    Upsert(conn, "TermStartDate",                 s.TermStartDate?.ToString("yyyy-MM-dd") ?? "");
    Upsert(conn, "TermEndDate",                   s.TermEndDate?.ToString("yyyy-MM-dd") ?? "");
    Upsert(conn, "CriticalPacingGapThreshold",    s.CriticalPacingGapThreshold.ToString("R"));
}

private static void Upsert(SqlConnection conn, string key, string value)
{
    using var cmd = new SqlCommand(@"
        IF EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = @k)
            UPDATE tbl_FollowUpSettings SET SettingValue = @v WHERE SettingKey = @k
        ELSE
            INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES (@k, @v)", conn);
    cmd.Parameters.Add("@k", SqlDbType.NVarChar, 200).Value = key;
    cmd.Parameters.Add("@v", SqlDbType.NVarChar, 200).Value = value;
    cmd.ExecuteNonQuery();
}
```

- [ ] **Step 2: Add `GetGuardianWorklist()` and its private helpers**

Add after `GetSettings()`/`SaveSettings()`:

```csharp
public List<GuardianWorklistRow> GetGuardianWorklist(string classFilter, decimal minBalance)
{
    var settings    = GetSettings();
    DateTime? tStart = settings.TermStartDate;
    DateTime? tEnd   = settings.TermEndDate;
    bool hasTermDates = tStart.HasValue && tEnd.HasValue;

    const string sql = @"
    ;WITH TermPayments AS (
        SELECT StudentNumber, ISNULL(SUM(Credit), 0) AS TotalPaid
        FROM FeesPayment
        WHERE (@termStart IS NULL OR DateOfPayment >= @termStart)
          AND (@termEnd   IS NULL OR DateOfPayment <= @termEnd)
        GROUP BY StudentNumber
    ),
    StudentsWithBalance AS (
        SELECT
            s.StudentNumber,
            s.fullName      AS FullName,
            s.ClassId,
            ISNULL(s.Guardian, '') AS GuardianRel,
            s.cashOnAccount AS TotalBilled,
            ISNULL(tp.TotalPaid, 0) AS TotalPaid,
            s.cashOnAccount - ISNULL(tp.TotalPaid, 0) AS Balance,
            CASE
                WHEN NULLIF(RTRIM(LTRIM(ISNULL(s.PriorityContact,''))), '') IS NOT NULL
                    THEN RTRIM(LTRIM(s.PriorityContact))
                WHEN NULLIF(RTRIM(LTRIM(ISNULL(s.OtherContact,''))),   '') IS NOT NULL
                    THEN RTRIM(LTRIM(s.OtherContact))
                ELSE 'NOCONTACT-' + s.StudentNumber
            END AS GuardianKey
        FROM tbl_Stud s
        LEFT JOIN TermPayments tp ON tp.StudentNumber = s.StudentNumber
        WHERE s.cashOnAccount - ISNULL(tp.TotalPaid, 0) > @minBalance
          AND (@classFilter = '' OR s.ClassId = @classFilter)
    ),
    AllRelevantContacts AS (
        SELECT cl.GuardianKey AS ContactKey,
               cl.ContactDate, cl.Outcome, cl.PromiseDate, cl.PromiseAmount, cl.ContactId
        FROM tbl_FeesContactLog cl
        WHERE cl.GuardianKey IS NOT NULL
          AND EXISTS (SELECT 1 FROM StudentsWithBalance sw WHERE sw.GuardianKey = cl.GuardianKey)
        UNION ALL
        SELECT sw.GuardianKey AS ContactKey,
               cl.ContactDate, cl.Outcome, cl.PromiseDate, cl.PromiseAmount, cl.ContactId
        FROM tbl_FeesContactLog cl
        JOIN StudentsWithBalance sw ON sw.StudentNumber = cl.StudentNumber
        WHERE cl.GuardianKey IS NULL
    ),
    LatestContact AS (
        SELECT ContactKey, MAX(ContactDate) AS LastContactDate, MAX(ContactId) AS LastContactId
        FROM AllRelevantContacts
        GROUP BY ContactKey
    ),
    LatestContactDetail AS (
        SELECT lc.ContactKey, lc.LastContactDate, arc.Outcome AS LastOutcome
        FROM LatestContact lc
        JOIN AllRelevantContacts arc ON arc.ContactId = lc.LastContactId
    ),
    LatestPromise AS (
        SELECT ContactKey, MAX(ContactDate) AS PromiseLoggedAt, MAX(ContactId) AS PromiseContactId
        FROM AllRelevantContacts
        WHERE Outcome = 'Promised'
        GROUP BY ContactKey
    ),
    LatestPromiseDetail AS (
        SELECT lp.ContactKey, lp.PromiseLoggedAt, arc.PromiseDate, arc.PromiseAmount
        FROM LatestPromise lp
        JOIN AllRelevantContacts arc ON arc.ContactId = lp.PromiseContactId
    ),
    PaymentsSincePromise AS (
        SELECT lpd.ContactKey,
               ISNULL((
                   SELECT SUM(fp.Credit)
                   FROM FeesPayment fp
                   JOIN StudentsWithBalance sw2 ON sw2.StudentNumber = fp.StudentNumber
                   WHERE sw2.GuardianKey = lpd.ContactKey
                     AND fp.DateOfPayment >= lpd.PromiseLoggedAt
               ), 0) AS PaymentsSinceLatestPromise
        FROM LatestPromiseDetail lpd
    )
    SELECT
        sw.StudentNumber, sw.FullName, sw.ClassId,
        sw.GuardianKey,   sw.GuardianRel,
        sw.TotalBilled,   sw.TotalPaid, sw.Balance,
        lcd.LastContactDate, lcd.LastOutcome,
        lpd.PromiseDate      AS LatestPromiseDate,
        lpd.PromiseAmount    AS LatestPromiseAmount,
        ISNULL(psp.PaymentsSinceLatestPromise, 0) AS PaymentsSinceLatestPromise
    FROM StudentsWithBalance sw
    LEFT JOIN LatestContactDetail lcd ON lcd.ContactKey = sw.GuardianKey
    LEFT JOIN LatestPromiseDetail  lpd ON lpd.ContactKey = sw.GuardianKey
    LEFT JOIN PaymentsSincePromise psp ON psp.ContactKey = sw.GuardianKey
    ORDER BY sw.GuardianKey, sw.FullName";

    var grouped = new Dictionary<string, GuardianWorklistRow>();

    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@minBalance",  SqlDbType.Money).Value  = minBalance;
        cmd.Parameters.Add("@classFilter", SqlDbType.VarChar, 50).Value = classFilter ?? "";
        cmd.Parameters.Add("@termStart",   SqlDbType.Date).Value   = (object)tStart ?? DBNull.Value;
        cmd.Parameters.Add("@termEnd",     SqlDbType.Date).Value   = (object)tEnd   ?? DBNull.Value;

        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            string gKey = rdr["GuardianKey"].ToString();
            string gRel = rdr["GuardianRel"]?.ToString() ?? "";

            if (!grouped.TryGetValue(gKey, out var g))
            {
                bool noContact = gKey.StartsWith("NOCONTACT-", StringComparison.Ordinal);
                string label = noContact
                    ? $"(no contact) {rdr["FullName"]}"
                    : string.IsNullOrEmpty(gRel) ? gKey : $"{gKey} ({gRel})";

                g = new GuardianWorklistRow
                {
                    GuardianContact            = gKey,
                    GuardianLabel              = label,
                    LastContactDate            = rdr["LastContactDate"] as DateTime?,
                    LastOutcome                = ParseOutcome(rdr["LastOutcome"]?.ToString()),
                    LatestPromiseDate          = rdr["LatestPromiseDate"] as DateTime?,
                    LatestPromiseAmount        = rdr["LatestPromiseAmount"] as decimal?,
                    PaymentsSinceLatestPromise = (decimal)rdr["PaymentsSinceLatestPromise"],
                };
                grouped[gKey] = g;
            }

            decimal billed = (decimal)rdr["TotalBilled"];
            decimal paid   = (decimal)rdr["TotalPaid"];
            decimal bal    = (decimal)rdr["Balance"];

            g.Students.Add(new StudentSummary
            {
                StudentNumber  = rdr["StudentNumber"].ToString(),
                FullName       = rdr["FullName"]?.ToString() ?? "",
                ClassId        = rdr["ClassId"]?.ToString()  ?? "",
                TotalBilled    = billed,
                TotalPaid      = paid,
                Balance        = bal,
                PaymentPercent = billed > 0 ? Math.Round(paid / billed * 100m, 1) : 0m,
            });
            g.TotalBilled  += billed;
            g.TotalPaid    += paid;
            g.TotalBalance += bal;
        }
    }

    // Compute pacing gap and tier
    double termProgress = 0.0;
    if (hasTermDates)
    {
        double totalDays   = (tEnd.Value - tStart.Value).TotalDays;
        double elapsedDays = (DateTime.Today - tStart.Value).TotalDays;
        termProgress = totalDays > 0 ? Math.Max(0.0, Math.Min(1.0, elapsedDays / totalDays)) : 0.0;
    }

    var rows = new List<GuardianWorklistRow>(grouped.Values);
    foreach (var g in rows)
    {
        g.PaymentPercent = g.TotalBilled > 0
            ? Math.Round(g.TotalPaid / g.TotalBilled * 100m, 1) : 0m;
        double payProgress = g.TotalBilled > 0 ? (double)(g.TotalPaid / g.TotalBilled) : 0.0;
        g.PacingGap = hasTermDates ? termProgress - payProgress : 0.0;
        g.Tier = ComputeGuardianTier(g, settings.StaleThresholdDays,
                                     settings.CriticalPacingGapThreshold, hasTermDates);
    }

    rows.Sort((a, b) =>
    {
        int t = a.Tier.CompareTo(b.Tier);
        if (t != 0) return t;
        int p = b.PacingGap.CompareTo(a.PacingGap);   // higher gap = more urgent
        return p != 0 ? p : b.TotalBalance.CompareTo(a.TotalBalance);
    });
    return rows;
}

private static PriorityTier ComputeGuardianTier(
    GuardianWorklistRow g, int stalenessDays, double criticalThreshold, bool hasTermDates)
{
    if (hasTermDates && g.PacingGap >= criticalThreshold)
        return PriorityTier.Critical;

    if (g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date < DateTime.Today)
    {
        decimal promised = g.LatestPromiseAmount ?? (g.TotalBalance + g.PaymentsSinceLatestPromise);
        if (g.PaymentsSinceLatestPromise < promised)
            return PriorityTier.BrokenPromise;
    }

    if (!g.LastContactDate.HasValue
        || (DateTime.Today - g.LastContactDate.Value.Date).TotalDays > stalenessDays
        || (g.LastOutcome.HasValue && FailedOutcomes.Contains(g.LastOutcome.Value)))
        return PriorityTier.Stale;

    return PriorityTier.Current;
}
```

- [ ] **Step 3: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors.

- [ ] **Step 4: Commit**

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs
git commit -m "feat(fees-crm): add GetGuardianWorklist with outstanding balance, guardian grouping, pacing gap"
```

---

## Task 4: Service — Guardian Contact Logging + History

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs`

**Context:** `LogGuardianContact()` inserts a single row with the `GuardianKey` set and the first student's `StudentNumber` as FK anchor (StudentNumber is NOT NULL in the table). `GetGuardianContactHistory()` retrieves all contacts for a guardian: rows where `GuardianKey = @key` (new style) OR `GuardianKey IS NULL AND StudentNumber IN (...)` (old student-level rows, backward compat). `UpdateContact()` and `DeleteContact()` already exist and work on `ContactId`; no changes needed there.

- [ ] **Step 1: Add `LogGuardianContact()` after `LogContact()`**

```csharp
public void LogGuardianContact(string guardianKey, FeesContactLog entry)
{
    using var conn = new SqlConnection(connectionString);
    conn.Open();
    using var cmd = new SqlCommand(@"
    INSERT INTO tbl_FeesContactLog
      (StudentNumber, GuardianKey, ContactDate, LoggedBy, Channel, Outcome, Note, PromiseDate, PromiseAmount)
    VALUES
      (@StudentNumber, @GuardianKey, @ContactDate, @LoggedBy, @Channel, @Outcome, @Note, @PromiseDate, @PromiseAmount)",
        conn);
    cmd.Parameters.Add("@StudentNumber", SqlDbType.VarChar,   50).Value = entry.StudentNumber ?? "";
    cmd.Parameters.Add("@GuardianKey",   SqlDbType.VarChar,   20).Value = (object)guardianKey ?? DBNull.Value;
    cmd.Parameters.Add("@ContactDate",   SqlDbType.DateTime      ).Value = entry.ContactDate;
    cmd.Parameters.Add("@LoggedBy",      SqlDbType.VarChar,   50).Value = entry.LoggedBy ?? "";
    cmd.Parameters.Add("@Channel",       SqlDbType.VarChar,   20).Value = entry.Channel.ToString();
    cmd.Parameters.Add("@Outcome",       SqlDbType.VarChar,   20).Value = entry.Outcome.ToString();
    cmd.Parameters.Add("@Note",          SqlDbType.NVarChar, 500).Value = (object)entry.Note ?? DBNull.Value;
    cmd.Parameters.Add("@PromiseDate",   SqlDbType.Date          ).Value = (object)entry.PromiseDate ?? DBNull.Value;
    cmd.Parameters.Add("@PromiseAmount", SqlDbType.Money          ).Value = (object)entry.PromiseAmount ?? DBNull.Value;
    cmd.ExecuteNonQuery();
}
```

- [ ] **Step 2: Add `GetGuardianContactHistory()` after `GetContactHistory()`**

```csharp
public DataTable GetGuardianContactHistory(string guardianKey, IEnumerable<string> studentNumbers)
{
    var nums = studentNumbers.ToList();
    // Build parameterized IN list (@sn0, @sn1, ...)
    string inList = nums.Count > 0
        ? string.Join(",", Enumerable.Range(0, nums.Count).Select(i => $"@sn{i}"))
        : "'__EMPTY__'";   // fallback that matches nothing

    var dt = new DataTable();
    using var conn = new SqlConnection(connectionString);
    using var da = new SqlDataAdapter($@"
    SELECT ContactId, ContactDate, Channel, Outcome, Note, LoggedBy, PromiseDate, PromiseAmount, GuardianKey
    FROM tbl_FeesContactLog
    WHERE GuardianKey = @guardianKey
       OR (GuardianKey IS NULL AND StudentNumber IN ({inList}))
    ORDER BY ContactDate DESC", conn);

    da.SelectCommand.Parameters.Add("@guardianKey", SqlDbType.VarChar, 20).Value = guardianKey;
    for (int i = 0; i < nums.Count; i++)
        da.SelectCommand.Parameters.Add($"@sn{i}", SqlDbType.VarChar, 50).Value = nums[i];

    da.Fill(dt);
    return dt;
}
```

- [ ] **Step 3: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors.

- [ ] **Step 4: Save build log and commit**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 > notes\IXtreme_build39.log
```

```bash
git add decompiled/IXtreme/I_Xtreme.ExtremeClasses/FeesFollowUpService.cs notes/IXtreme_build39.log
git commit -m "feat(fees-crm): add LogGuardianContact, GetGuardianContactHistory to service"
```

---

## Task 5: Rewrite usrFeesFollowUp — Full-Page Guardian Worklist

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs`

**Context:** The split-container form is scrapped. The new form is a full-page DevExpress GridControl (`Dock = Fill`) showing one row per guardian. A thin filter panel sits at the top (class combo + min-balance spin + refresh button). Double-click opens `dlgFeesContactInteraction`. The public methods called from MainForm (`OpenSettings`, `PrintPreviewWorklist`, `PrintWorklist`, `ExportWorklistToExcel`) are preserved; a new `OpenContactView()` is added for the ribbon button.

Row coloring: Critical = `Color.OrangeRed` (deep), BrokenPromise = `Color.LightCoral`, Stale = `Color.LightYellow`, Current = default.

The `#` column is unbound (row index). `PaymentPercent` and `Tier` columns use `CustomColumnDisplayText` to format as `"40.0%"` and `"Critical"` / `"Missed Promise"` / `"Contact Overdue"` / `"Up to Date"` respectively.

- [ ] **Step 1: Replace the entire file with the new guardian-grid implementation**

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
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrFeesFollowUp : UserControl
{
    // ── filter controls ──────────────────────────────────────────────────────
    private ComboBoxEdit cboClass;
    private SpinEdit     spnMinBalance;
    private SimpleButton btnRefresh;

    // ── worklist grid ─────────────────────────────────────────────────────────
    private DevExpress.XtraGrid.GridControl gridWorklist;
    private GridView                        gridViewWorklist;

    // ── state ─────────────────────────────────────────────────────────────────
    private readonly FeesFollowUpService _service = new FeesFollowUpService();
    private bool _columnsConfigured = false;
    private string _currentSemester;

    public usrFeesFollowUp()
    {
        InitializeComponent();
    }

    // ── InitializeComponent ───────────────────────────────────────────────────

    private void InitializeComponent()
    {
        this.SuspendLayout();

        // Filter panel
        var filterPanel = new Panel { Dock = DockStyle.Top, Height = 44 };

        this.cboClass = new ComboBoxEdit();
        this.cboClass.Properties.Items.AddRange(new object[] { "All classes" });
        this.cboClass.SelectedIndex = 0;
        this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        this.cboClass.Location = new Point(8, 10);
        this.cboClass.Width    = 160;
        filterPanel.Controls.Add(this.cboClass);

        var lblMin = new LabelControl { Text = "Min balance (UGX):", Location = new Point(180, 14) };
        filterPanel.Controls.Add(lblMin);

        this.spnMinBalance = new SpinEdit { Location = new Point(310, 8), Width = 120 };
        this.spnMinBalance.Properties.IsFloatValue = false;
        this.spnMinBalance.Properties.MinValue     = 0;
        this.spnMinBalance.Properties.MaxValue     = 10_000_000;
        this.spnMinBalance.Value = 0;
        filterPanel.Controls.Add(this.spnMinBalance);

        this.btnRefresh = new SimpleButton { Text = "Refresh", Location = new Point(440, 8), Width = 90 };
        this.btnRefresh.Click += (s, e) => LoadWorklist();
        filterPanel.Controls.Add(this.btnRefresh);

        // Worklist grid
        this.gridWorklist     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewWorklist = new GridView();
        this.gridWorklist.MainView = this.gridViewWorklist;
        this.gridWorklist.ViewCollection.Add(this.gridViewWorklist);

        this.gridViewWorklist.OptionsView.ShowGroupPanel = false;
        this.gridViewWorklist.OptionsBehavior.Editable   = false;
        this.gridViewWorklist.OptionsSelection.EnableAppearanceFocusedRow = true;

        this.gridViewWorklist.CustomUnboundColumnData  += GridViewWorklist_UnboundData;
        this.gridViewWorklist.CustomColumnDisplayText  += GridViewWorklist_CustomColumnDisplayText;
        this.gridViewWorklist.RowStyle                 += GridViewWorklist_RowStyle;
        this.gridViewWorklist.DoubleClick              += GridViewWorklist_DoubleClick;

        this.Controls.Add(this.gridWorklist);
        this.Controls.Add(filterPanel);

        this.Load += usrFeesFollowUp_Load;
        this.ResumeLayout(false);
    }

    // ── Lifecycle ─────────────────────────────────────────────────────────────

    private void usrFeesFollowUp_Load(object sender, EventArgs e) => LoadWorklist();

    // ── Public ribbon API ─────────────────────────────────────────────────────

    public void OpenSettings()
    {
        using var dlg = new FollowUpSettings();
        if (dlg.ShowDialog(this) == DialogResult.OK)
            LoadWorklist();
    }

    public void OpenContactView()
    {
        int handle = gridViewWorklist.FocusedRowHandle;
        if (handle < 0) return;
        var row = gridViewWorklist.GetRow(handle) as GuardianWorklistRow;
        OpenInteraction(row);
    }

    public void PrintPreviewWorklist() => gridWorklist.ShowPrintPreview();

    public void PrintWorklist()
    {
        gridWorklist.ShowPrintPreview();
    }

    public void ExportWorklistToExcel()
    {
        using var dlg = new SaveFileDialog
        {
            Filter   = "Excel files (*.xlsx)|*.xlsx",
            FileName = "FeesFollowUp_Worklist.xlsx",
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;
        gridViewWorklist.ExportToXlsx(dlg.FileName);
    }

    // ── Data ──────────────────────────────────────────────────────────────────

    private void LoadWorklist()
    {
        _columnsConfigured = false;   // reconfigure on each load (class list may change)
        string classFilter = cboClass.SelectedIndex <= 0 ? "" : cboClass.SelectedItem?.ToString() ?? "";
        decimal minBal     = (decimal)spnMinBalance.Value;

        var rows = _service.GetGuardianWorklist(classFilter, minBal);
        gridWorklist.DataSource = rows;
        ConfigureWorklistColumns();

        // Rebuild class combo from distinct classes in returned data
        var classes = rows.SelectMany(r => r.Students).Select(s => s.ClassId)
                          .Where(c => !string.IsNullOrEmpty(c)).Distinct().OrderBy(c => c).ToList();
        string selected = cboClass.SelectedIndex > 0 ? cboClass.SelectedItem?.ToString() : null;
        cboClass.Properties.Items.Clear();
        cboClass.Properties.Items.Add("All classes");
        cboClass.Properties.Items.AddRange(classes.Cast<object>().ToArray());
        cboClass.SelectedIndex = selected != null ? cboClass.Properties.Items.IndexOf(selected) : 0;
        if (cboClass.SelectedIndex < 0) cboClass.SelectedIndex = 0;
    }

    // ── Grid configuration ────────────────────────────────────────────────────

    private void ConfigureWorklistColumns()
    {
        if (_columnsConfigured) return;
        _columnsConfigured = true;

        // # — unbound row counter
        var colNum = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName    = "#",
            Caption      = "#",
            UnboundType  = DevExpress.Data.UnboundColumnType.Integer,
        };
        colNum.OptionsColumn.AllowEdit = false;
        colNum.OptionsColumn.ReadOnly  = true;
        colNum.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        colNum.Width    = 36;
        colNum.MinWidth = 36;
        colNum.MaxWidth = 36;
        gridViewWorklist.Columns.Add(colNum);
        colNum.VisibleIndex = 0;

        // Hide internal key column
        HideCol("GuardianContact");
        HideCol("Students");
        HideCol("StudentCount");   // shown via unbound caption column below
        HideCol("TotalBilled");
        HideCol("TotalPaid");
        HideCol("PacingGap");
        HideCol("LatestPromiseDate");
        HideCol("LatestPromiseAmount");
        HideCol("PaymentsSinceLatestPromise");

        // Captions
        SetCaption("GuardianLabel",    "Guardian");
        SetCaption("TotalBalance",     "Balance (UGX)");
        SetCaption("PaymentPercent",   "% Paid");
        SetCaption("Tier",             "Priority");
        SetCaption("LastContactDate",  "Last Contact");
        SetCaption("LastOutcome",      "Last Outcome");

        // Format Balance
        var colBal = gridViewWorklist.Columns["TotalBalance"];
        if (colBal != null)
        {
            colBal.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colBal.DisplayFormat.FormatString = "N0";
        }

        // Unbound "Students" count column
        var colStudents = new DevExpress.XtraGrid.Columns.GridColumn
        {
            FieldName   = "StudentCountDisplay",
            Caption     = "Students",
            UnboundType = DevExpress.Data.UnboundColumnType.Integer,
        };
        colStudents.OptionsColumn.AllowEdit = false;
        colStudents.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
        colStudents.Width    = 60;
        colStudents.MinWidth = 60;
        colStudents.MaxWidth = 80;
        gridViewWorklist.Columns.Add(colStudents);

        gridViewWorklist.BestFitColumns();

        // Pin # and Students columns
        colNum.Width    = 36;
        colNum.MinWidth = 36;
        colNum.MaxWidth = 36;
        colStudents.Width = 60;
    }

    private void HideCol(string field)
    {
        var c = gridViewWorklist.Columns[field];
        if (c != null) c.Visible = false;
    }

    private void SetCaption(string field, string caption)
    {
        var c = gridViewWorklist.Columns[field];
        if (c != null) c.Caption = caption;
    }

    // ── Grid event handlers ───────────────────────────────────────────────────

    private void GridViewWorklist_UnboundData(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
    {
        if (!e.IsGetData) return;
        if (e.Column.FieldName == "#")
            e.Value = e.ListSourceRowIndex + 1;
        else if (e.Column.FieldName == "StudentCountDisplay")
        {
            var row = gridViewWorklist.GetRow(e.RowHandle) as GuardianWorklistRow;
            e.Value = row?.StudentCount ?? 0;
        }
    }

    private void GridViewWorklist_CustomColumnDisplayText(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "Tier" && e.Value is PriorityTier tier)
        {
            e.DisplayText = tier switch
            {
                PriorityTier.Critical      => "Critical",
                PriorityTier.BrokenPromise => "Missed Promise",
                PriorityTier.Stale         => "Contact Overdue",
                PriorityTier.Current       => "Up to Date",
                _                          => e.DisplayText,
            };
        }
        else if (e.Column.FieldName == "LastOutcome" && e.Value is ContactOutcome outcome)
        {
            e.DisplayText = outcome switch
            {
                ContactOutcome.Contacted        => "Contacted",
                ContactOutcome.NoAnswer         => "No Answer",
                ContactOutcome.ContactUnavailable => "Unavailable",
                ContactOutcome.ContactOff       => "Phone Off",
                ContactOutcome.Promised         => "Promised",
                ContactOutcome.Refused          => "Refused",
                _                               => e.DisplayText,
            };
        }
        else if (e.Column.FieldName == "PaymentPercent" && e.Value is decimal pct)
        {
            e.DisplayText = $"{pct:F1}%";
        }
    }

    private void GridViewWorklist_RowStyle(object sender,
        DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
    {
        var row = gridViewWorklist.GetRow(e.RowHandle) as GuardianWorklistRow;
        if (row == null) return;
        switch (row.Tier)
        {
            case PriorityTier.Critical:
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.ForeColor = Color.White;
                e.HighPriority = true;
                break;
            case PriorityTier.BrokenPromise:
                e.Appearance.BackColor = Color.LightCoral;
                e.HighPriority = true;
                break;
            case PriorityTier.Stale:
                e.Appearance.BackColor = Color.LightYellow;
                e.HighPriority = true;
                break;
        }
    }

    private void GridViewWorklist_DoubleClick(object sender, EventArgs e)
    {
        var pt  = gridWorklist.PointToClient(Cursor.Position);
        var hit = gridViewWorklist.CalcHitInfo(pt);
        if (!hit.InRow) return;
        var row = gridViewWorklist.GetRow(hit.RowHandle) as GuardianWorklistRow;
        OpenInteraction(row);
    }

    // ── Interaction dialog helper ─────────────────────────────────────────────

    private void OpenInteraction(GuardianWorklistRow row)
    {
        if (row == null) return;
        var worklist = gridWorklist.DataSource as List<GuardianWorklistRow>
                       ?? new List<GuardianWorklistRow> { row };
        int idx = worklist.IndexOf(row);
        if (idx < 0) idx = 0;
        using var dlg = new dlgFeesContactInteraction(worklist, idx);
        dlg.ShowDialog(this);
        LoadWorklist();   // refresh after contact may have been logged
    }
}
```

- [ ] **Step 2: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors. (dlgFeesContactInteraction is created in Task 6; the file will not exist yet — add a temporary stub `public class dlgFeesContactInteraction : DevExpress.XtraEditors.XtraForm { public dlgFeesContactInteraction(System.Collections.Generic.List<I_Xtreme.Models.GuardianWorklistRow> w, int i) { } }` in a temporary file if the build fails due to the missing class, then remove that stub in Task 6 Step 1.)

- [ ] **Step 3: Save build log and commit**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 > notes\IXtreme_build40.log
```

```bash
git add decompiled/IXtreme/I_Xtreme.NavigationForms/usrFeesFollowUp.cs notes/IXtreme_build40.log
git commit -m "feat(fees-crm): rewrite usrFeesFollowUp as full-page guardian worklist"
```

---

## Task 6: New dlgFeesContactInteraction Dialog

**Files:**
- Create: `decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs`

**Context:** `XtraForm` dialog that opens from double-click or ribbon. Receives the full `List<GuardianWorklistRow>` and the current index. Layout (top to bottom):
1. Navigation bar: ← Prev button, guardian name label, Next → button
2. Info bar: contact number, student count, total balance
3. Students grid (top half of content area)
4. Contact history grid (middle; right-click to Edit/Delete)
5. Contact log form (bottom panel, `DockStyle.Bottom`, Height = 220)

The contact log form is the same fields as the old right-panel: channel radio, date edit, outcome combo, note memo, optional promise date + amount. Saving calls `service.LogGuardianContact()` (new) for new entries or `service.UpdateContact()` (existing) for edits.

- [ ] **Step 1: Create the file**

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

namespace I_Xtreme.DialogForms;

public class dlgFeesContactInteraction : XtraForm
{
    // ── Navigation ────────────────────────────────────────────────────────────
    private SimpleButton btnPrev, btnNext;
    private LabelControl lblTitle;

    // ── Info bar ──────────────────────────────────────────────────────────────
    private LabelControl lblContactNum, lblStudentCount, lblTotalBalance, lblPayPct;

    // ── Students grid ─────────────────────────────────────────────────────────
    private DevExpress.XtraGrid.GridControl gridStudents;
    private GridView                        gridViewStudents;

    // ── History grid ──────────────────────────────────────────────────────────
    private DevExpress.XtraGrid.GridControl gridHistory;
    private GridView                        gridViewHistory;

    // ── Contact log form ──────────────────────────────────────────────────────
    private DevExpress.XtraEditors.RadioGroup rgChannel;
    private DateEdit      dteContactDate;
    private LabelControl  lblContactDate;
    private ComboBoxEdit  cboOutcome;
    private MemoEdit      memoNote;
    private LabelControl  lblPromiseDate, lblPromiseAmount;
    private DateEdit      dtePromiseDate;
    private SpinEdit      txtPromiseAmount;
    private SimpleButton  btnSave, btnClear;

    // ── State ─────────────────────────────────────────────────────────────────
    private readonly List<GuardianWorklistRow> _worklist;
    private int _currentIndex;
    private int _editContactId = -1;
    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public dlgFeesContactInteraction(List<GuardianWorklistRow> worklist, int startIndex)
    {
        _worklist     = worklist;
        _currentIndex = Math.Max(0, Math.Min(startIndex, worklist.Count - 1));
        InitializeComponent();
        LoadCurrent();
    }

    private GuardianWorklistRow Current => _worklist[_currentIndex];

    // ── InitializeComponent ───────────────────────────────────────────────────

    private void InitializeComponent()
    {
        this.SuspendLayout();
        this.Text            = "Contact Interaction";
        this.Size            = new Size(900, 720);
        this.StartPosition   = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.Sizable;

        // ── Navigation bar ────────────────────────────────────────────────────
        var navBar = new Panel { Dock = DockStyle.Top, Height = 44 };

        this.btnPrev = new SimpleButton { Text = "← Prev", Location = new Point(8, 8), Width = 80 };
        this.btnPrev.Click += (s, e) => Navigate(-1);

        this.btnNext = new SimpleButton { Text = "Next →", Location = new Point(800, 8), Width = 80 };
        this.btnNext.Click += (s, e) => Navigate(+1);

        this.lblTitle = new LabelControl
        {
            AutoSizeMode = LabelAutoSizeMode.None,
            Size         = new Size(700, 22),
            Location     = new Point(96, 12),
            Appearance   = { Font = new Font("Tahoma", 11F, FontStyle.Bold) },
        };
        navBar.Controls.AddRange(new Control[] { btnPrev, btnNext, lblTitle });

        // ── Info bar ──────────────────────────────────────────────────────────
        var infoBar = new Panel { Dock = DockStyle.Top, Height = 28 };

        this.lblContactNum   = new LabelControl { Location = new Point(8, 6),   AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(200, 18) };
        this.lblStudentCount = new LabelControl { Location = new Point(220, 6),  AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(120, 18) };
        this.lblTotalBalance = new LabelControl { Location = new Point(350, 6),  AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(200, 18) };
        this.lblPayPct       = new LabelControl { Location = new Point(560, 6),  AutoSizeMode = LabelAutoSizeMode.None, Size = new Size(160, 18) };
        infoBar.Controls.AddRange(new Control[] { lblContactNum, lblStudentCount, lblTotalBalance, lblPayPct });

        // ── Contact log panel (Bottom) ─────────────────────────────────────────
        var logPanel = new Panel { Dock = DockStyle.Bottom, Height = 220 };

        var lblChannel = new LabelControl { Text = "Channel:", Location = new Point(8, 10) };
        this.rgChannel = new DevExpress.XtraEditors.RadioGroup();
        this.rgChannel.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[]
        {
            new(ContactChannel.SMS,      "SMS"),
            new(ContactChannel.Phone,    "Phone"),
            new(ContactChannel.InPerson, "InPerson"),
        });
        this.rgChannel.Properties.Columns = 3;
        this.rgChannel.SelectedIndex = 1;    // Phone
        this.rgChannel.Location = new Point(70, 4);
        this.rgChannel.Size     = new Size(280, 36);

        this.lblContactDate = new LabelControl { Text = "Date:", Location = new Point(360, 12) };
        this.dteContactDate = new DateEdit
        {
            Location  = new Point(392, 6),
            Width     = 120,
            EditValue = DateTime.Today,
        };

        this.cboOutcome = new ComboBoxEdit();
        this.cboOutcome.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        foreach (ContactOutcome o in Enum.GetValues(typeof(ContactOutcome)))
            this.cboOutcome.Properties.Items.Add(o);
        this.cboOutcome.SelectedIndex = -1;
        this.cboOutcome.Location      = new Point(8, 48);
        this.cboOutcome.Width         = 200;
        this.cboOutcome.SelectedIndexChanged += (s, e) =>
        {
            bool promised = cboOutcome.SelectedItem is ContactOutcome o2 && o2 == ContactOutcome.Promised;
            lblPromiseDate.Visible  = dtePromiseDate.Visible  = promised;
            lblPromiseAmount.Visible = txtPromiseAmount.Visible = promised;
        };

        this.lblPromiseDate  = new LabelControl { Text = "Promise date:",   Location = new Point(220, 52), Visible = false };
        this.dtePromiseDate  = new DateEdit     { Location = new Point(310, 47), Width = 120, Visible = false };
        this.lblPromiseAmount = new LabelControl { Text = "Promise amount:", Location = new Point(440, 52), Visible = false };
        this.txtPromiseAmount = new SpinEdit    { Location = new Point(545, 47), Width = 110, Visible = false };
        this.txtPromiseAmount.Properties.IsFloatValue = true;
        this.txtPromiseAmount.Properties.MaskSettings.Set("mask", "N0");

        this.memoNote = new MemoEdit { Location = new Point(8, 80), Size = new Size(560, 80) };

        this.btnSave = new SimpleButton { Text = "Save Contact", Location = new Point(8, 168), Width = 120 };
        this.btnSave.Click += BtnSave_Click;

        this.btnClear = new SimpleButton { Text = "Clear", Location = new Point(136, 168), Width = 80 };
        this.btnClear.Click += (s, e) => ResetContactForm();

        logPanel.Controls.AddRange(new Control[]
        {
            lblChannel, rgChannel, lblContactDate, dteContactDate,
            cboOutcome, lblPromiseDate, dtePromiseDate,
            lblPromiseAmount, txtPromiseAmount,
            memoNote, btnSave, btnClear,
        });

        // ── Students grid ─────────────────────────────────────────────────────
        var studentsPanel = new Panel { Dock = DockStyle.Top, Height = 160 };
        this.gridStudents     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewStudents = new GridView();
        this.gridStudents.MainView = this.gridViewStudents;
        this.gridStudents.ViewCollection.Add(this.gridViewStudents);
        this.gridViewStudents.OptionsView.ShowGroupPanel     = false;
        this.gridViewStudents.OptionsBehavior.Editable       = false;
        this.gridViewStudents.CustomColumnDisplayText       += GridViewStudents_CustomColumnDisplayText;
        studentsPanel.Controls.Add(this.gridStudents);

        // ── History grid (Fill) ───────────────────────────────────────────────
        this.gridHistory     = new DevExpress.XtraGrid.GridControl { Dock = DockStyle.Fill };
        this.gridViewHistory = new GridView();
        this.gridHistory.MainView = this.gridViewHistory;
        this.gridHistory.ViewCollection.Add(this.gridViewHistory);
        this.gridViewHistory.OptionsView.ShowGroupPanel = false;
        this.gridViewHistory.OptionsBehavior.Editable   = false;
        this.gridViewHistory.MouseDown += GridViewHistory_MouseDown;

        // ── Assemble ──────────────────────────────────────────────────────────
        this.Controls.Add(this.gridHistory);     // Fill
        this.Controls.Add(studentsPanel);        // Top (after logPanel so z-order correct)
        this.Controls.Add(logPanel);             // Bottom
        this.Controls.Add(infoBar);              // Top
        this.Controls.Add(navBar);               // Top

        this.ResumeLayout(false);
    }

    // ── Navigation ────────────────────────────────────────────────────────────

    private void Navigate(int delta)
    {
        int next = _currentIndex + delta;
        if (next < 0 || next >= _worklist.Count) return;
        _currentIndex = next;
        LoadCurrent();
    }

    private void LoadCurrent()
    {
        var g = Current;

        // Navigation buttons
        btnPrev.Enabled = _currentIndex > 0;
        btnNext.Enabled = _currentIndex < _worklist.Count - 1;
        Text            = $"Contact Interaction — {g.GuardianLabel} ({_currentIndex + 1} of {_worklist.Count})";
        lblTitle.Text   = g.GuardianLabel;

        // Info bar
        bool noPhone = g.GuardianContact.StartsWith("NOCONTACT-", StringComparison.Ordinal);
        lblContactNum.Text   = noPhone ? "(no phone on file)" : g.GuardianContact;
        lblStudentCount.Text = $"{g.StudentCount} student{(g.StudentCount == 1 ? "" : "s")}";
        lblTotalBalance.Text = $"Balance: UGX {g.TotalBalance:N0}";
        lblPayPct.Text       = $"Paid: {g.PaymentPercent:F1}%  (Pacing: {g.PacingGap:P0} behind)";

        // Students grid
        gridStudents.DataSource = g.Students;
        ConfigureStudentsColumns();

        // History grid
        var nums = g.Students.Select(s => s.StudentNumber);
        gridHistory.DataSource = _service.GetGuardianContactHistory(g.GuardianContact, nums);
        ConfigureHistoryColumns();

        ResetContactForm();
    }

    // ── Grid configuration ────────────────────────────────────────────────────

    private bool _studentsColumnsConfigured = false;

    private void ConfigureStudentsColumns()
    {
        if (_studentsColumnsConfigured) return;
        _studentsColumnsConfigured = true;

        HideStudCol("TotalBilled");
        HideStudCol("TotalPaid");

        SetStudCaption("FullName",       "Name");
        SetStudCaption("ClassId",        "Class");
        SetStudCaption("Balance",        "Balance (UGX)");
        SetStudCaption("PaymentPercent", "% Paid");

        var colBal = gridViewStudents.Columns["Balance"];
        if (colBal != null)
        {
            colBal.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colBal.DisplayFormat.FormatString = "N0";
        }

        gridViewStudents.BestFitColumns();
    }

    private void HideStudCol(string field)
    {
        var c = gridViewStudents.Columns[field];
        if (c != null) c.Visible = false;
    }

    private void SetStudCaption(string field, string caption)
    {
        var c = gridViewStudents.Columns[field];
        if (c != null) c.Caption = caption;
    }

    private bool _historyColumnsConfigured = false;

    private void ConfigureHistoryColumns()
    {
        if (_historyColumnsConfigured) return;
        _historyColumnsConfigured = true;

        var colId = gridViewHistory.Columns["ContactId"];
        if (colId != null) colId.Visible = false;
        var colGK = gridViewHistory.Columns["GuardianKey"];
        if (colGK != null) colGK.Visible = false;

        void SetH(string f, string c) { var col = gridViewHistory.Columns[f]; if (col != null) col.Caption = c; }
        SetH("ContactDate",   "Date");
        SetH("Channel",       "Channel");
        SetH("Outcome",       "Outcome");
        SetH("Note",          "Note");
        SetH("LoggedBy",      "Logged By");
        SetH("PromiseDate",   "Promise Date");
        SetH("PromiseAmount", "Promise Amt");

        var colAmt = gridViewHistory.Columns["PromiseAmount"];
        if (colAmt != null)
        {
            colAmt.DisplayFormat.FormatType   = DevExpress.Utils.FormatType.Numeric;
            colAmt.DisplayFormat.FormatString = "N0";
        }

        gridViewHistory.BestFitColumns();
        var noteCol = gridViewHistory.Columns["Note"];
        if (noteCol != null) noteCol.Width = Math.Min(noteCol.Width, 200);
    }

    private void GridViewStudents_CustomColumnDisplayText(object sender,
        DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column.FieldName == "PaymentPercent" && e.Value is decimal pct)
            e.DisplayText = $"{pct:F1}%";
    }

    // ── History right-click (Edit / Delete) ───────────────────────────────────

    private void GridViewHistory_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;
        var hit = gridViewHistory.CalcHitInfo(new Point(e.X, e.Y));
        if (!hit.InRow) return;
        var dataRow = gridViewHistory.GetDataRow(hit.RowHandle);
        if (dataRow == null) return;

        int contactId = Convert.ToInt32(dataRow["ContactId"]);

        var menu = new System.Windows.Forms.ContextMenuStrip();
        menu.Items.Add("Edit",   null, (s2, e2) => BeginEditContact(dataRow, contactId));
        menu.Items.Add("Delete", null, (s2, e2) => DeleteHistoryContact(contactId));
        menu.Show(Control.MousePosition);
    }

    private void BeginEditContact(System.Data.DataRow row, int contactId)
    {
        _editContactId = contactId;

        if (DateTime.TryParse(row["ContactDate"]?.ToString(), out DateTime cd))
            dteContactDate.EditValue = cd;
        if (Enum.TryParse(row["Channel"]?.ToString(), out ContactChannel ch))
            rgChannel.EditValue = ch;
        if (Enum.TryParse(row["Outcome"]?.ToString(), out ContactOutcome oc))
        {
            cboOutcome.SelectedItem = oc;
        }
        memoNote.Text = row["Note"]?.ToString() ?? "";
        if (row["PromiseDate"] != DBNull.Value && DateTime.TryParse(row["PromiseDate"]?.ToString(), out DateTime pd))
            dtePromiseDate.EditValue = pd;
        if (row["PromiseAmount"] != DBNull.Value && decimal.TryParse(row["PromiseAmount"]?.ToString(), out decimal pa))
            txtPromiseAmount.Value = pa;

        btnSave.Text = "Update Contact";
    }

    private void DeleteHistoryContact(int contactId)
    {
        var confirm = XtraMessageBox.Show(
            "Delete this contact record?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes) return;

        try
        {
            _service.DeleteContact(contactId);
            var nums = Current.Students.Select(s => s.StudentNumber);
            gridHistory.DataSource = _service.GetGuardianContactHistory(Current.GuardianContact, nums);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }

    // ── Contact log form ──────────────────────────────────────────────────────

    private void ResetContactForm()
    {
        _editContactId          = -1;
        dteContactDate.EditValue = DateTime.Today;
        rgChannel.SelectedIndex  = 1;   // Phone
        cboOutcome.SelectedIndex = -1;
        memoNote.Text            = "";
        dtePromiseDate.EditValue = null;
        txtPromiseAmount.Value   = 0;
        lblPromiseDate.Visible   = dtePromiseDate.Visible   = false;
        lblPromiseAmount.Visible = txtPromiseAmount.Visible = false;
        btnSave.Text             = "Save Contact";
    }

    private void BtnSave_Click(object sender, EventArgs e)
    {
        if (dteContactDate.DateTime.Date > DateTime.Today)
        {
            XtraMessageBox.Show("Contact date cannot be in the future.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (cboOutcome.SelectedItem == null)
        {
            XtraMessageBox.Show("Please select a contact outcome before saving.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var channel = (ContactChannel)rgChannel.EditValue;
        var outcome = (ContactOutcome)cboOutcome.SelectedItem;

        var entry = new FeesContactLog
        {
            StudentNumber = Current.Students.Count > 0 ? Current.Students[0].StudentNumber : "",
            ContactDate   = dteContactDate.DateTime,
            LoggedBy      = I_Xtreme.CurrentUser.GetSystemUser(),
            Channel       = channel,
            Outcome       = outcome,
            Note          = string.IsNullOrWhiteSpace(memoNote.Text) ? null : memoNote.Text,
            PromiseDate   = outcome == ContactOutcome.Promised
                            ? dtePromiseDate.DateTime.Date : (DateTime?)null,
            PromiseAmount = outcome == ContactOutcome.Promised && txtPromiseAmount.Value > 0
                            ? (decimal?)txtPromiseAmount.Value : null,
        };

        if (outcome == ContactOutcome.Promised && !entry.PromiseDate.HasValue)
        {
            XtraMessageBox.Show("Please set a promise date when outcome is 'Promised'.", "Validation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            if (_editContactId >= 0)
            {
                entry.ContactId = _editContactId;
                _service.UpdateContact(entry);
            }
            else
            {
                _service.LogGuardianContact(Current.GuardianContact, entry);
            }

            var nums = Current.Students.Select(s => s.StudentNumber);
            gridHistory.DataSource = _service.GetGuardianContactHistory(Current.GuardianContact, nums);
            ResetContactForm();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
```

- [ ] **Step 2: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors. Fix any `I_Xtreme.CurrentUser.GetSystemUser()` namespace issue — the existing usages in usrFeesFollowUp.cs show the correct namespace; match it here.

- [ ] **Step 3: Save build log and commit**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 > notes\IXtreme_build41.log
```

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/dlgFeesContactInteraction.cs notes/IXtreme_build41.log
git commit -m "feat(fees-crm): add dlgFeesContactInteraction with student breakdown and back/next nav"
```

---

## Task 7: Update FollowUpSettings Dialog — Term Dates + Critical Threshold

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs`

**Context:** The current dialog has one field (`spnStaleness`). Expand it with `dteTermStart`, `dteTermEnd`, and `spnCriticalThreshold`. Load/save via `service.GetSettings()` / `service.SaveSettings()` (added in Task 3). The dialog height grows from 90px to 190px to fit the new fields.

- [ ] **Step 1: Replace `FollowUpSettings.cs` with expanded version**

```csharp
using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Models;

namespace I_Xtreme.DialogForms;

public class FollowUpSettings : XtraForm
{
    private IContainer components = null;
    private SpinEdit  spnStaleness;
    private DateEdit  dteTermStart;
    private DateEdit  dteTermEnd;
    private SpinEdit  spnCriticalThreshold;
    private SimpleButton btnOK, btnCancel;

    private readonly FeesFollowUpService _service = new FeesFollowUpService();

    public FollowUpSettings()
    {
        InitializeComponent();
        var s = _service.GetSettings();
        spnStaleness.Value          = s.StaleThresholdDays;
        dteTermStart.EditValue      = (object)s.TermStartDate ?? DBNull.Value;
        dteTermEnd.EditValue        = (object)s.TermEndDate   ?? DBNull.Value;
        spnCriticalThreshold.Value  = (decimal)(s.CriticalPacingGapThreshold * 100); // stored as 0..1, shown as 0..100%
    }

    private void InitializeComponent()
    {
        // Row 1: Staleness
        var lblStaleness = new LabelControl
            { Text = "Flag as overdue after (days):", Location = new System.Drawing.Point(12, 18) };
        this.spnStaleness = new SpinEdit { Location = new System.Drawing.Point(210, 14), Width = 80 };
        this.spnStaleness.Properties.IsFloatValue = false;
        this.spnStaleness.Properties.MinValue     = 0;
        this.spnStaleness.Properties.MaxValue     = 365;

        // Row 2: Term start
        var lblTermStart = new LabelControl
            { Text = "Term start date:", Location = new System.Drawing.Point(12, 54) };
        this.dteTermStart = new DateEdit { Location = new System.Drawing.Point(210, 50), Width = 120 };

        // Row 3: Term end
        var lblTermEnd = new LabelControl
            { Text = "Term end date:", Location = new System.Drawing.Point(12, 90) };
        this.dteTermEnd = new DateEdit { Location = new System.Drawing.Point(210, 86), Width = 120 };

        // Row 4: Critical threshold
        var lblCritical = new LabelControl
            { Text = "Critical tier: pacing gap ≥ (%):", Location = new System.Drawing.Point(12, 126) };
        this.spnCriticalThreshold = new SpinEdit { Location = new System.Drawing.Point(210, 122), Width = 80 };
        this.spnCriticalThreshold.Properties.IsFloatValue = false;
        this.spnCriticalThreshold.Properties.MinValue     = 0;
        this.spnCriticalThreshold.Properties.MaxValue     = 100;

        // Buttons
        this.btnOK = new SimpleButton
            { Text = "OK", Location = new System.Drawing.Point(130, 158), Width = 75 };
        this.btnCancel = new SimpleButton
            { Text = "Cancel", Location = new System.Drawing.Point(214, 158), Width = 75 };

        this.btnOK.Click += (s, e) =>
        {
            DateTime? termStart = dteTermStart.DateTime == DateTime.MinValue
                ? (DateTime?)null : dteTermStart.DateTime.Date;
            DateTime? termEnd   = dteTermEnd.DateTime == DateTime.MinValue
                ? (DateTime?)null : dteTermEnd.DateTime.Date;

            if (termStart.HasValue && termEnd.HasValue && termEnd.Value <= termStart.Value)
            {
                XtraMessageBox.Show("Term end date must be after term start date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _service.SaveSettings(new FeesFollowUpSettings
            {
                StaleThresholdDays          = (int)spnStaleness.Value,
                TermStartDate               = termStart,
                TermEndDate                 = termEnd,
                CriticalPacingGapThreshold  = (double)(spnCriticalThreshold.Value / 100m),
            });
            base.DialogResult = DialogResult.OK;
            Dispose();
        };
        this.btnCancel.Click += (s, e) => { base.DialogResult = DialogResult.Cancel; Dispose(); };

        this.ClientSize = new System.Drawing.Size(320, 196);
        this.Controls.AddRange(new Control[]
        {
            lblStaleness, spnStaleness,
            lblTermStart, dteTermStart,
            lblTermEnd,   dteTermEnd,
            lblCritical,  spnCriticalThreshold,
            btnOK, btnCancel,
        });
        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        this.StartPosition   = FormStartPosition.CenterParent;
        this.Text            = "Follow-up Settings";
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }
}
```

- [ ] **Step 2: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors.

- [ ] **Step 3: Save build log and commit**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 > notes\IXtreme_build42.log
```

```bash
git add decompiled/IXtreme/I_Xtreme.DialogForms/FollowUpSettings.cs notes/IXtreme_build42.log
git commit -m "feat(fees-crm): expand FollowUpSettings with term dates and critical threshold"
```

---

## Task 8: MainForm — Add "Open Contact View" Ribbon Button

**Files:**
- Modify: `decompiled/IXtreme/I_Xtreme/MainForm.cs`

**Context:** Add a `bbiFeesOpenContact` `BarButtonItem` to the Fees Follow-up ribbon page. Place it in `ribbonPageGroupFeesSettings` (alongside the existing Settings button). Use the `barButtonItem89` icon (`I_Xtreme.Properties.Resources.inv_catEditCat`) as a reasonable "open/edit" visual — the user can swap it later. The handler calls `_usrFeesFollowUp?.OpenContactView()`.

The private field declarations (around line 530) and the InitializeComponent block that initialises fees buttons (around line 24703) both need changes.

- [ ] **Step 1: Add private field declaration**

In the field declarations block near the other fees button fields (around line 536), add:

```csharp
private DevExpress.XtraBars.BarButtonItem bbiFeesOpenContact;
```

- [ ] **Step 2: Initialise the button in InitializeComponent**

In the section that starts with `// --- Fees Follow-up: Settings group ---` (around line 24703), add the new button after `bbiFeesSettings` is initialised and before `ribbonPageGroupFeesSettings` is created:

```csharp
this.bbiFeesOpenContact = new DevExpress.XtraBars.BarButtonItem();
this.bbiFeesOpenContact.Name    = "bbiFeesOpenContact";
this.bbiFeesOpenContact.Caption = "Open Contact View";
this.bbiFeesOpenContact.ImageOptions.Image      = I_Xtreme.Properties.Resources.inv_catEditCat;
this.bbiFeesOpenContact.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.inv_catEditCat;
this.bbiFeesOpenContact.ItemClick += (s, e) => _usrFeesFollowUp?.OpenContactView();
```

- [ ] **Step 3: Add to ribbon group and ribbon.Items**

In the same section, update `ribbonPageGroupFeesSettings.ItemLinks.Add` to include the new button, and add it to `ribbon.Items.AddRange`:

```csharp
this.ribbonPageGroupFeesSettings.ItemLinks.Add(this.bbiFeesSettings);
this.ribbonPageGroupFeesSettings.ItemLinks.Add(this.bbiFeesOpenContact);
```

And in the `ribbon.Items.AddRange` call:

```csharp
this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[]
    { bbiFeesSettings, bbiFeesOpenContact, bbiFeesPreview, bbiFeesPrint, bbiFeesExport });
```

- [ ] **Step 4: Build to verify no errors**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 | Select-String "error|Error" | Where-Object { $_ -notmatch "warning" }
```

Expected: 0 errors.

- [ ] **Step 5: Save build log and commit**

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj 2>&1 > notes\IXtreme_build43.log
```

```bash
git add decompiled/IXtreme/I_Xtreme/MainForm.cs notes/IXtreme_build43.log
git commit -m "feat(fees-crm): add Open Contact View ribbon button to Fees Follow-up page"
```

---

## Self-Review

**Spec coverage check:**

| Requirement | Task |
|---|---|
| Guardian as unit of contact (one row per guardian) | T3, T5 |
| GuardianContact1 → GuardianContact2 fallback | T3 SQL `CASE WHEN` |
| Students with no contact shown separately | T3 `NOCONTACT-` synthetic key |
| Full-page worklist (no side panel) | T5 |
| Double-click opens interaction dialog | T5 `GridViewWorklist_DoubleClick` |
| Interaction dialog: student breakdown | T6 students grid |
| Interaction dialog: contact history | T6 history grid |
| Interaction dialog: contact log form | T6 `BtnSave_Click` |
| Interaction dialog: back/next navigation | T6 `Navigate()` |
| Ribbon button opens interaction dialog | T8 |
| One contact log row per guardian call | T4 `LogGuardianContact` |
| GuardianKey migration on tbl_FeesContactLog | T1 |
| Balance bug fixed (billed − paid, filter out cleared) | T3 SQL `Balance = cashOnAccount − TotalPaid` |
| New Critical tier (pacing gap ≥ threshold) | T2 enum, T3 `ComputeGuardianTier` |
| % Paid column on worklist | T5 `PaymentPercent` column |
| Pacing gap column hidden but used for sort | T5 `HideCol("PacingGap")` |
| Term dates configurable in settings | T7 |
| Critical threshold configurable in settings | T7 |
| Students cleared of balance excluded | T3 `WHERE Balance > @minBalance` |

**Placeholder scan:** No TBDs found.

**Type consistency check:** `GuardianWorklistRow`, `StudentSummary`, `FeesFollowUpSettings` defined in T2 and used in T3, T5, T6, T7. `LogGuardianContact(string, FeesContactLog)` defined in T4, called in T6. `GetGuardianContactHistory(string, IEnumerable<string>)` defined in T4, called in T6 with `.Select(s => s.StudentNumber)`. `GetSettings()`/`SaveSettings()` defined in T3, called in T7. All consistent.

**Edge cases noted:**
- Term dates not yet configured: `PacingGap = 0.0`, Critical tier never triggers (guard `hasTermDates`). ✓
- Guardian with no phone: groups under `"NOCONTACT-{StudentNumber}"`, shows `(no contact) Name` label. ✓
- No students in worklist (all cleared): `GetGuardianWorklist` returns empty list, grid shows empty. ✓
- `FeesPayment` empty: `TotalPaid = 0`, balance = `cashOnAccount`. ✓
