using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AlienAge.Connectivity;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

public class FeesFollowUpService
{
    private readonly string connectionString;

    public FeesFollowUpService()
    {
        connectionString = DataConnection.ConnectToDatabase();
    }

    public int GetStalenessThresholdDays()
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT SettingValue FROM tbl_FollowUpSettings WHERE SettingKey = 'StalenessThresholdDays'",
            conn);
        var raw = cmd.ExecuteScalar() as string;
        return int.TryParse(raw, out int days) ? days : 7;
    }

    public void SetStalenessThresholdDays(int days)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            IF EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'StalenessThresholdDays')
                UPDATE tbl_FollowUpSettings SET SettingValue = @v WHERE SettingKey = 'StalenessThresholdDays'
            ELSE
                INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('StalenessThresholdDays', @v)",
            conn);
        cmd.Parameters.Add("@v", SqlDbType.NVarChar, 200).Value = days.ToString();
        cmd.ExecuteNonQuery();
    }

    public FeesFollowUpSettings GetSettings()
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT SettingKey, SettingValue FROM tbl_FollowUpSettings", conn);
        var dict = new Dictionary<string, string>();
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            dict[rdr.GetString(0)] = rdr.IsDBNull(1) ? "" : rdr.GetString(1);

        return new FeesFollowUpSettings
        {
            StaleThresholdDays =
                dict.TryGetValue("StalenessThresholdDays", out var sd) && int.TryParse(sd, out int d) ? d : 7,
            TermStartDate =
                dict.TryGetValue("TermStartDate", out var ts) && DateTime.TryParse(ts, out DateTime tsd) ? tsd : (DateTime?)null,
            TermEndDate =
                dict.TryGetValue("TermEndDate", out var te) && DateTime.TryParse(te, out DateTime ted) ? ted : (DateTime?)null,
            CriticalPacingGapThreshold =
                dict.TryGetValue("CriticalPacingGapThreshold", out var ct) && double.TryParse(ct, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double ctd) ? ctd : 0.50,
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
            s.fullName          AS FullName,
            s.ClassId,
            s.Guardian          AS GuardianName,
            s.GuardianRelation  AS GuardianRelation,
            s.OtherContact      AS Contact2,
            s.StudentID         AS StudentId,
            s.StudyStatus       AS DayBoarder,
            s.cashOnAccount     AS TotalBilled,
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
    LatestContactRanked AS (
        SELECT ContactKey, ContactDate AS LastContactDate, Outcome AS LastOutcome,
               ROW_NUMBER() OVER (PARTITION BY ContactKey ORDER BY ContactDate DESC, ContactId DESC) AS rn
        FROM AllRelevantContacts
    ),
    LatestContactDetail AS (
        SELECT ContactKey, LastContactDate, LastOutcome
        FROM LatestContactRanked
        WHERE rn = 1
    ),
    LatestPromiseRanked AS (
        SELECT ContactKey, ContactDate AS PromiseLoggedAt, PromiseDate, PromiseAmount,
               ROW_NUMBER() OVER (PARTITION BY ContactKey ORDER BY ContactDate DESC, ContactId DESC) AS rn
        FROM AllRelevantContacts
        WHERE Outcome = 'Promised'
    ),
    LatestPromiseDetail AS (
        SELECT ContactKey, PromiseLoggedAt, PromiseDate, PromiseAmount
        FROM LatestPromiseRanked
        WHERE rn = 1
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
        sw.GuardianKey,
        sw.GuardianName, sw.GuardianRelation, sw.Contact2,
        sw.StudentId,    sw.DayBoarder,
        sw.TotalBilled,  sw.TotalPaid, sw.Balance,
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

                if (!grouped.TryGetValue(gKey, out var g))
                {
                    g = new GuardianWorklistRow
                    {
                        GuardianContact            = gKey,
                        GuardianName               = rdr.IsDBNull(rdr.GetOrdinal("GuardianName"))     ? "" : rdr.GetString(rdr.GetOrdinal("GuardianName")),
                        GuardianRelation           = rdr.IsDBNull(rdr.GetOrdinal("GuardianRelation")) ? "" : rdr.GetString(rdr.GetOrdinal("GuardianRelation")),
                        Contact2                   = rdr.IsDBNull(rdr.GetOrdinal("Contact2"))         ? "" : rdr.GetString(rdr.GetOrdinal("Contact2")),
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

                var student = new StudentSummary
                {
                    StudentNumber  = rdr["StudentNumber"].ToString(),
                    FullName       = rdr["FullName"]?.ToString() ?? "",
                    ClassId        = rdr["ClassId"]?.ToString()  ?? "",
                    TotalBilled    = billed,
                    TotalPaid      = paid,
                    Balance        = bal,
                    PaymentPercent = billed > 0 ? Math.Round(paid / billed * 100m, 1) : 0m,
                };
                student.StudentId  = rdr.IsDBNull(rdr.GetOrdinal("StudentId"))  ? "" : rdr.GetString(rdr.GetOrdinal("StudentId"));
                student.DayBoarder = rdr.IsDBNull(rdr.GetOrdinal("DayBoarder")) ? "" : rdr.GetString(rdr.GetOrdinal("DayBoarder"));
                g.Students.Add(student);
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

    private bool WasContactedToday(string guardianKey)
    {
        const string sql = @"
        SELECT COUNT(1) FROM tbl_FeesContactLog
        WHERE GuardianKey = @key
          AND CAST(ContactDate AS DATE) = CAST(GETDATE() AS DATE)
          AND Outcome IN ('Contacted', 'Promised', 'Refused', 'InPerson')";
        using var conn = new SqlConnection(connectionString);
        using var cmd  = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@key", guardianKey);
        conn.Open();
        return (int)cmd.ExecuteScalar() > 0;
    }

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

    public DashboardData GetDashboardData()
    {
        var all   = GetGuardianWorklist("", 0);
        var today = DateTime.Today;

        int contactedToday = all.Count(g => WasContactedToday(g.GuardianContact));

        // Daily list (would exclude those contacted today) + those already contacted today
        int dailyTotal = GetDailyWorklist(0).Count + contactedToday;

        return new DashboardData
        {
            TotalOutstanding          = all.Sum(g => g.TotalBalance),
            TotalBilled               = all.Sum(g => g.TotalBilled),
            TotalCollected            = all.Sum(g => g.TotalPaid),
            TotalGuardiansWithBalance = all.Count,
            DailyListTotal            = dailyTotal,
            DailyListContacted        = contactedToday,
            BrokenPromiseCount        = all.Count(g => g.Tier == PriorityTier.BrokenPromise),
            ActivePromiseCount        = all.Count(g =>
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

    private string GetSchoolName()
    {
        const string sql = "SELECT TOP 1 SchoolName FROM SchoolDetails";
        try
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd  = new SqlCommand(sql, conn);
            conn.Open();
            var raw = cmd.ExecuteScalar() as string ?? "";
            try { return AlienAge.Security.CryptorEngine.Decrypt(raw); }
            catch { return raw; }   // return raw if decryption fails
        }
        catch { return ""; }
    }

    public void CheckAndSendSmsReminders()
    {
        // Full implementation in Task 12 — requires tbl_SmsReminderLog migration to be run first
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

    public List<WorklistRow> GetWorklist(string classFilter, decimal minBalance)
    {
        int staleness = GetStalenessThresholdDays();

        string sql = @"
        ;WITH LatestContact AS (
            SELECT StudentNumber, ContactDate, Outcome, PromiseDate, PromiseAmount,
                   ROW_NUMBER() OVER (PARTITION BY StudentNumber ORDER BY ContactDate DESC) AS rn
            FROM tbl_FeesContactLog
        ),
        LatestPromise AS (
            SELECT StudentNumber, ContactDate AS PromiseLoggedAt, PromiseDate, PromiseAmount,
                   ROW_NUMBER() OVER (PARTITION BY StudentNumber ORDER BY ContactDate DESC) AS rn
            FROM tbl_FeesContactLog
            WHERE Outcome = 'Promised'
        )
        SELECT
            s.StudentNumber,
            s.fullName,
            s.ClassId,
            s.cashOnAccount       AS Balance,
            s.PriorityContact,
            s.OtherContact,
            lc.ContactDate        AS LastContactDate,
            lc.Outcome            AS LastOutcome,
            lp.PromiseDate        AS LatestPromiseDate,
            lp.PromiseAmount      AS LatestPromiseAmount,
            lp.PromiseLoggedAt    AS LatestPromiseLoggedAt,
            ISNULL((SELECT SUM(Credit) FROM FeesPayment fp
                    WHERE fp.StudentNumber = s.StudentNumber
                      AND fp.DateOfPayment >= lp.PromiseLoggedAt), 0) AS PaymentsSinceLatestPromise
        FROM tbl_Stud s
        LEFT JOIN LatestContact lc ON s.StudentNumber = lc.StudentNumber AND lc.rn = 1
        LEFT JOIN LatestPromise lp ON s.StudentNumber = lp.StudentNumber AND lp.rn = 1
        WHERE s.cashOnAccount > @minBalance
          AND (@classFilter = '' OR s.ClassId = @classFilter)
        ORDER BY s.cashOnAccount DESC";

        var rows = new List<WorklistRow>();
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@minBalance", SqlDbType.Money).Value = minBalance;
            cmd.Parameters.Add("@classFilter", SqlDbType.VarChar, 50).Value = classFilter ?? "";
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string priority = rdr["PriorityContact"]?.ToString() ?? "";
                string other = rdr["OtherContact"]?.ToString() ?? "";
                string preferred = priority.Length >= 10 ? priority : other;

                var row = new WorklistRow
                {
                    StudentNumber = (string)rdr["StudentNumber"],
                    FullName = rdr["fullName"]?.ToString(),
                    ClassId = rdr["ClassId"]?.ToString(),
                    Balance = (decimal)rdr["Balance"],
                    PriorityContact = preferred,
                    LastContactDate = rdr["LastContactDate"] as DateTime?,
                    LastOutcome = ParseOutcome(rdr["LastOutcome"]?.ToString()),
                    LatestPromiseDate = rdr["LatestPromiseDate"] as DateTime?,
                    LatestPromiseAmount = rdr["LatestPromiseAmount"] as decimal?,
                    PaymentsSinceLatestPromise = rdr["PaymentsSinceLatestPromise"] as decimal? ?? 0m,
                };
                row.Tier = ComputeTier(row, staleness);
                rows.Add(row);
            }
        }

        // Re-sort by tier, then balance desc
        rows.Sort((a, b) =>
        {
            int t = a.Tier.CompareTo(b.Tier);
            return t != 0 ? t : b.Balance.CompareTo(a.Balance);
        });
        return rows;
    }

    private static ContactOutcome? ParseOutcome(string raw)
    {
        if (string.IsNullOrEmpty(raw)) return null;
        return Enum.TryParse(raw, out ContactOutcome o) ? o : (ContactOutcome?)null;
    }

    private static readonly System.Collections.Generic.HashSet<ContactOutcome> FailedOutcomes =
        new System.Collections.Generic.HashSet<ContactOutcome>
        {
            ContactOutcome.NoAnswer,
            ContactOutcome.ContactUnavailable,
            ContactOutcome.ContactOff,
            ContactOutcome.Refused,
        };

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

    public void LogContact(FeesContactLog entry)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
        INSERT INTO tbl_FeesContactLog
          (StudentNumber, ContactDate, LoggedBy, Channel, Outcome, Note, PromiseDate, PromiseAmount)
        VALUES
          (@StudentNumber, @ContactDate, @LoggedBy, @Channel, @Outcome, @Note, @PromiseDate, @PromiseAmount)",
            conn);
        cmd.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50).Value = entry.StudentNumber;
        cmd.Parameters.Add("@ContactDate", SqlDbType.DateTime).Value = entry.ContactDate;
        cmd.Parameters.Add("@LoggedBy", SqlDbType.VarChar, 50).Value = entry.LoggedBy ?? "";
        cmd.Parameters.Add("@Channel", SqlDbType.VarChar, 20).Value = entry.Channel.ToString();
        cmd.Parameters.Add("@Outcome", SqlDbType.VarChar, 20).Value = entry.Outcome.ToString();
        cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 500).Value = (object)entry.Note ?? DBNull.Value;
        cmd.Parameters.Add("@PromiseDate", SqlDbType.Date).Value = (object)entry.PromiseDate ?? DBNull.Value;
        cmd.Parameters.Add("@PromiseAmount", SqlDbType.Money).Value = (object)entry.PromiseAmount ?? DBNull.Value;
        cmd.ExecuteNonQuery();
    }

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

    public void DeleteContact(int contactId)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "DELETE FROM tbl_FeesContactLog WHERE ContactId = @id", conn);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
        cmd.ExecuteNonQuery();
    }

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

    public DataTable GetContactHistory(string studentNumber)
    {
        var dt = new DataTable();
        using var conn = new SqlConnection(connectionString);
        using var da = new SqlDataAdapter(@"
        SELECT ContactId, ContactDate, Channel, Outcome, Note, LoggedBy, PromiseDate, PromiseAmount
        FROM tbl_FeesContactLog
        WHERE StudentNumber = @sn
        ORDER BY ContactDate DESC", conn);
        da.SelectCommand.Parameters.Add("@sn", SqlDbType.VarChar, 50).Value = studentNumber;
        da.Fill(dt);
        return dt;
    }

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

    public DataTable GetRecentPayments(string studentNumber, int topN = 2, string semester = null)
    {
        var dt = new DataTable();
        using var conn = new SqlConnection(connectionString);
        string semesterClause = string.IsNullOrEmpty(semester)
            ? ""
            : "AND SemesterId = @semester";
        using var da = new SqlDataAdapter($@"
        SELECT TOP (@topN) DateOfPayment AS PaymentDate, Credit, Particulars
        FROM FeesPayment
        WHERE StudentNumber = @sn AND Credit > 0
        {semesterClause}
        ORDER BY DateOfPayment DESC", conn);
        da.SelectCommand.Parameters.Add("@topN", SqlDbType.Int).Value = topN;
        da.SelectCommand.Parameters.Add("@sn", SqlDbType.VarChar, 50).Value = studentNumber;
        if (!string.IsNullOrEmpty(semester))
            da.SelectCommand.Parameters.Add("@semester", SqlDbType.VarChar, 50).Value = semester;
        da.Fill(dt);
        return dt;
    }

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
}
