using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

    private static PriorityTier ComputeTier(WorklistRow r, int stalenessDays)
    {
        // Broken promise
        if (r.LatestPromiseDate.HasValue && r.LatestPromiseDate.Value.Date < DateTime.Today)
        {
            decimal promised = r.LatestPromiseAmount ?? (r.Balance + r.PaymentsSinceLatestPromise);
            if (r.PaymentsSinceLatestPromise < promised)
                return PriorityTier.BrokenPromise;
        }
        // Stale
        if (!r.LastContactDate.HasValue
            || (DateTime.Today - r.LastContactDate.Value.Date).TotalDays > stalenessDays)
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
