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

    internal const string DefaultPreDue  =
        "Dear Parent, you promised to pay UGX {promised_amount} for {names} ({class}) by {date}. " +
        "Your balance is UGX {balance}. Please pay as promised. - {school}";

    internal const string DefaultDayOf   =
        "Dear Parent, today is your promised payment date of UGX {promised_amount} for {names} ({class}). " +
        "Balance: UGX {balance}. Please pay today. - {school}";

    internal const string DefaultOverdue =
        "Dear Parent, your payment of UGX {promised_amount} for {names} ({class}) was due on {date} " +
        "but has not been received. Balance: UGX {balance}. Please pay immediately. - {school}";

    internal const string DefaultGeneral =
        "Dear Parent, {names} ({class}) has an outstanding balance of UGX {balance}. " +
        "Please pay or contact the bursar to arrange a payment plan. - {school}";

    public FeesFollowUpService()
    {
        connectionString = DataConnection.ConnectToDatabase();
    }

    public string ConnectionString => connectionString;

    public static string RenderTemplate(string template, decimal balance,
        string studentName, string classId, DateTime date, string school, decimal promisedAmount)
        => ApplySmsTemplate(template, balance, studentName, classId, date, school, promisedAmount);

    public void LogManualReminderSent(string phone, string studentNumber, DateTime promiseDate, string type)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        if (!AlreadySentReminder(conn, phone, studentNumber, promiseDate, type))
            LogReminderSent(conn, phone, studentNumber, promiseDate, type);
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
            SmsTemplate2Day  = dict.TryGetValue("SmsTemplate2Day",  out var t2)  ? t2  : "",
            SmsTemplateDayOf = dict.TryGetValue("SmsTemplateDayOf", out var tdo) ? tdo : "",
            SmsTemplateOverdue = dict.TryGetValue("SmsTemplateOverdue", out var tov) ? tov : "",
            PartialPromiseCoverageThreshold =
                dict.TryGetValue("PartialPromiseCoverageThreshold", out var pp)
                && double.TryParse(pp, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double ppd)
                    ? ppd : 0.50,
            StaleHighBalanceAmount =
                dict.TryGetValue("StaleHighBalanceAmount", out var sha)
                && decimal.TryParse(sha, System.Globalization.NumberStyles.Number,
                                    System.Globalization.CultureInfo.InvariantCulture, out decimal shav)
                    ? shav : 1_000_000m,
            StaleHighBalanceDays =
                dict.TryGetValue("StaleHighBalanceDays", out var shd) && int.TryParse(shd, out int shdi)
                    ? shdi : 3,
            StaleMedBalanceAmount =
                dict.TryGetValue("StaleMedBalanceAmount", out var sma)
                && decimal.TryParse(sma, System.Globalization.NumberStyles.Number,
                                    System.Globalization.CultureInfo.InvariantCulture, out decimal smav)
                    ? smav : 500_000m,
            StaleMedBalanceDays =
                dict.TryGetValue("StaleMedBalanceDays", out var smd) && int.TryParse(smd, out int smdi)
                    ? smdi : 5,
            NoProgressEscalationWeeks =
                dict.TryGetValue("NoProgressEscalationWeeks", out var npw) && int.TryParse(npw, out int npwi)
                    ? npwi : 4,
            NoProgressPaymentThreshold =
                dict.TryGetValue("NoProgressPaymentThreshold", out var npt)
                && double.TryParse(npt, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double nptd)
                    ? nptd : 30.0,
            CollectionGoal =
                dict.TryGetValue("CollectionGoal", out var cg)
                && double.TryParse(cg, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double cgv)
                    ? cgv : 0.98,
            CriticalShortfallPoints =
                dict.TryGetValue("CriticalShortfallPoints", out var csp)
                && double.TryParse(csp, System.Globalization.NumberStyles.Float,
                                   System.Globalization.CultureInfo.InvariantCulture, out double cspv)
                    ? cspv : 25.0,
            CallRequiredWindowDays =
                dict.TryGetValue("CallRequiredWindowDays", out var crw) && int.TryParse(crw, out int crwi)
                    ? crwi : 14,
            PromiseResurfaceDays =
                dict.TryGetValue("PromiseResurfaceDays", out var prd) && int.TryParse(prd, out int prdi)
                    ? prdi : 14,
            GeneralReminderCooldownDays =
                dict.TryGetValue("GeneralReminderCooldownDays", out var grc) && int.TryParse(grc, out int grci)
                    ? grci : 7,
            SmsTemplateGeneral = dict.TryGetValue("SmsTemplateGeneral", out var stg) ? stg : "",
        };
    }

    /// <summary>Cheap check for the worklist banner: are both term dates configured?</summary>
    public bool AreTermDatesConfigured()
    {
        var s = GetSettings();
        return s.TermStartDate.HasValue && s.TermEndDate.HasValue;
    }

    public void SaveSettings(FeesFollowUpSettings s)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        Upsert(conn, "StalenessThresholdDays",     s.StaleThresholdDays.ToString());
        Upsert(conn, "TermStartDate",              s.TermStartDate?.ToString("yyyy-MM-dd") ?? "");
        Upsert(conn, "TermEndDate",                s.TermEndDate?.ToString("yyyy-MM-dd") ?? "");
        Upsert(conn, "SmsTemplate2Day",            s.SmsTemplate2Day ?? "");
        Upsert(conn, "SmsTemplateDayOf",           s.SmsTemplateDayOf ?? "");
        Upsert(conn, "SmsTemplateOverdue", s.SmsTemplateOverdue ?? "");
        Upsert(conn, "PartialPromiseCoverageThreshold",
            s.PartialPromiseCoverageThreshold.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "StaleHighBalanceAmount",
            s.StaleHighBalanceAmount.ToString("F2", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "StaleHighBalanceDays",  s.StaleHighBalanceDays.ToString());
        Upsert(conn, "StaleMedBalanceAmount",
            s.StaleMedBalanceAmount.ToString("F2", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "StaleMedBalanceDays",   s.StaleMedBalanceDays.ToString());
        Upsert(conn, "NoProgressEscalationWeeks",
            s.NoProgressEscalationWeeks.ToString());
        Upsert(conn, "NoProgressPaymentThreshold",
            s.NoProgressPaymentThreshold.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "CollectionGoal",
            s.CollectionGoal.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "CriticalShortfallPoints",
            s.CriticalShortfallPoints.ToString("R", System.Globalization.CultureInfo.InvariantCulture));
        Upsert(conn, "CallRequiredWindowDays", s.CallRequiredWindowDays.ToString());
        Upsert(conn, "PromiseResurfaceDays",   s.PromiseResurfaceDays.ToString());
        Upsert(conn, "GeneralReminderCooldownDays", s.GeneralReminderCooldownDays.ToString());
        Upsert(conn, "SmsTemplateGeneral",          s.SmsTemplateGeneral ?? "");
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

    // Returns the most-recently-used SemesterId in FeesPayment that is not the current semester.
    private string GetPreviousSemesterId(string currentSemester)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT TOP 1 SemesterId FROM FeesPayment WHERE SemesterId != @curr AND SemesterId IS NOT NULL GROUP BY SemesterId ORDER BY MAX(PaymentId) DESC",
            conn);
        cmd.Parameters.Add("@curr", SqlDbType.VarChar, 50).Value = currentSemester;
        return cmd.ExecuteScalar() as string;
    }

    private struct DashboardTotals
    {
        public int     TotalEnrolled;
        public decimal TotalPayable;
        public decimal TotalPaid;
        public int     NilBalance;
        public int     ZeroPaid;
        public decimal CollectedThisWeek;
    }

    // Mirrors the tracking sheet formula for all students in the current semester —
    // no balance filter, so fully-paid and credit-balance students are included.
    private DashboardTotals GetDashboardTotals(string currentSemester, string prevSemester)
    {
        const string sql = @"
    ;WITH CurrentTermPayments AS (
        SELECT StudentNumber,
               ISNULL(SUM(ISNULL(Debit,  0)), 0) AS TotalBilled,
               ISNULL(SUM(ISNULL(Credit, 0)), 0) AS TotalPaid
        FROM FeesPayment
        WHERE SemesterId = @currentSemester
        GROUP BY StudentNumber
    ),
    PrevTermLastBalance AS (
        SELECT StudentNumber, Balance AS BFAmount
        FROM (
            SELECT StudentNumber, Balance,
                   ROW_NUMBER() OVER (PARTITION BY StudentNumber ORDER BY PaymentId DESC) AS rn
            FROM FeesPayment
            WHERE SemesterId = @prevSemester
        ) t
        WHERE rn = 1
    )
    SELECT
        COUNT(*)                                                              AS TotalEnrolled,
        ISNULL(SUM(ctp.TotalBilled + ISNULL(ptb.BFAmount, 0)), 0)           AS TotalPayable,
        ISNULL(SUM(ctp.TotalPaid), 0)                                        AS TotalPaid,
        ISNULL(SUM(CASE WHEN ctp.TotalBilled + ISNULL(ptb.BFAmount, 0)
                             - ctp.TotalPaid <= 0 THEN 1 ELSE 0 END), 0)    AS NilBalance,
        ISNULL(SUM(CASE WHEN ctp.TotalPaid = 0
                         AND ctp.TotalBilled + ISNULL(ptb.BFAmount, 0) > 0
                        THEN 1 ELSE 0 END), 0)                               AS ZeroPaid
        ,(SELECT ISNULL(SUM(Credit), 0) FROM FeesPayment
          WHERE SemesterId = @currentSemester AND Credit > 0
            AND DateOfPayment >= @weekStart)                                AS CollectedThisWeek
    FROM tbl_Stud s
    INNER JOIN CurrentTermPayments ctp ON ctp.StudentNumber = s.StudentNumber
    LEFT  JOIN PrevTermLastBalance  ptb ON ptb.StudentNumber = s.StudentNumber";

        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@currentSemester", SqlDbType.VarChar, 50).Value = currentSemester;
        cmd.Parameters.Add("@prevSemester",    SqlDbType.VarChar, 50).Value = (object)prevSemester ?? DBNull.Value;
        DateTime weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek); // Sunday on/before today
        cmd.Parameters.Add("@weekStart", SqlDbType.Date).Value = weekStart;
        using var rdr = cmd.ExecuteReader();
        if (!rdr.Read()) return new DashboardTotals();
        return new DashboardTotals
        {
            TotalEnrolled     = Convert.ToInt32(rdr["TotalEnrolled"]),
            TotalPayable      = Convert.ToDecimal(rdr["TotalPayable"]),
            TotalPaid         = Convert.ToDecimal(rdr["TotalPaid"]),
            NilBalance        = Convert.ToInt32(rdr["NilBalance"]),
            ZeroPaid          = Convert.ToInt32(rdr["ZeroPaid"]),
            CollectedThisWeek = Convert.ToDecimal(rdr["CollectedThisWeek"]),
        };
    }

    public List<GuardianWorklistRow> GetGuardianWorklist(string classFilter, decimal minBalance,
        FeesFollowUpSettings settings = null)
    {
        settings ??= GetSettings();
        DateTime? tStart = settings.TermStartDate;
        DateTime? tEnd   = settings.TermEndDate;
        bool hasTermDates = tStart.HasValue && tEnd.HasValue;

        string currentSemester = AlienAge.Semesters.WorkingSemesters.GetWorkingSemester();
        string prevSemester    = GetPreviousSemesterId(currentSemester);  // may be null

        // Uses the same formula as the Fees Tracking Sheet (usrStudentAccounts):
        //   TotalBilled = SUM(Debit, current semester) + stored Balance from last previous-semester entry
        //   TotalPaid   = SUM(Credit, current semester)
        //   Balance     = TotalBilled - TotalPaid
        // Only students with at least one current-semester FeesPayment entry are included,
        // which keeps this total consistent with what the tracking sheet reports.
        const string sql = @"
    ;WITH CurrentTermPayments AS (
        SELECT StudentNumber,
               ISNULL(SUM(ISNULL(Debit,  0)), 0) AS TotalBilled,
               ISNULL(SUM(ISNULL(Credit, 0)), 0) AS TotalPaid
        FROM FeesPayment
        WHERE SemesterId = @currentSemester
        GROUP BY StudentNumber
    ),
    PrevTermLastBalance AS (
        -- Stored running balance at end of the previous semester (matches tracking sheet B/F column)
        SELECT StudentNumber, Balance AS BFAmount
        FROM (
            SELECT StudentNumber, Balance,
                   ROW_NUMBER() OVER (PARTITION BY StudentNumber ORDER BY PaymentId DESC) AS rn
            FROM FeesPayment
            WHERE SemesterId = @prevSemester
        ) t
        WHERE rn = 1
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
            ctp.TotalBilled + ISNULL(ptb.BFAmount, 0) AS TotalBilled,
            ctp.TotalPaid AS TotalPaid,
            ctp.TotalBilled + ISNULL(ptb.BFAmount, 0) - ctp.TotalPaid AS Balance,
            CASE
                WHEN NULLIF(RTRIM(LTRIM(ISNULL(s.PriorityContact,''))), '') IS NOT NULL
                    THEN RTRIM(LTRIM(s.PriorityContact))
                WHEN NULLIF(RTRIM(LTRIM(ISNULL(s.OtherContact,''))),   '') IS NOT NULL
                    THEN RTRIM(LTRIM(s.OtherContact))
                ELSE 'NOCONTACT-' + s.StudentNumber
            END AS GuardianKey
        FROM tbl_Stud s
        INNER JOIN CurrentTermPayments ctp ON ctp.StudentNumber = s.StudentNumber
        LEFT JOIN  PrevTermLastBalance  ptb ON ptb.StudentNumber = s.StudentNumber
        WHERE ctp.TotalBilled + ISNULL(ptb.BFAmount, 0) - ctp.TotalPaid > @minBalance
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
               ISNULL(SUM(fp.Credit), 0) AS PaymentsSinceLatestPromise
        FROM LatestPromiseDetail lpd
        JOIN StudentsWithBalance sw2 ON sw2.GuardianKey = lpd.ContactKey
        JOIN FeesPayment fp
             ON fp.StudentNumber = sw2.StudentNumber
            AND fp.DateOfPayment >= lpd.PromiseLoggedAt
        GROUP BY lpd.ContactKey
    ),
    EarliestContact AS (
        SELECT ContactKey, MIN(ContactDate) AS FirstContactDate
        FROM AllRelevantContacts
        GROUP BY ContactKey
    ),
    ContactedTodayCte AS (
        -- Mirrors WasContactedToday: a same-day log with a 'reached' outcome
        SELECT cl.GuardianKey AS ContactKey
        FROM tbl_FeesContactLog cl
        WHERE cl.GuardianKey IS NOT NULL
          AND CAST(cl.ContactDate AS DATE) = CAST(GETDATE() AS DATE)
          AND cl.Outcome IN ('Contacted', 'Promised', 'Refused')
        GROUP BY cl.GuardianKey
    ),
    CallRequiredCte AS (
        -- F3: only a *recent* Overdue SMS counts, so the flag decays instead of sticking forever.
        SELECT GuardianKey AS ContactKey
        FROM tbl_SmsReminderLog
        WHERE ReminderType = 'Overdue' AND GuardianKey IS NOT NULL
          AND SentAt >= @callRequiredCutoff
        GROUP BY GuardianKey
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
        ,ec.FirstContactDate
        ,CASE WHEN ct.ContactKey IS NOT NULL THEN 1 ELSE 0 END AS ContactedToday
        ,CASE WHEN cr.ContactKey IS NOT NULL THEN 1 ELSE 0 END AS CallRequired
    FROM StudentsWithBalance sw
    LEFT JOIN LatestContactDetail lcd ON lcd.ContactKey = sw.GuardianKey
    LEFT JOIN LatestPromiseDetail  lpd ON lpd.ContactKey = sw.GuardianKey
    LEFT JOIN PaymentsSincePromise psp ON psp.ContactKey = sw.GuardianKey
    LEFT JOIN EarliestContact     ec  ON ec.ContactKey  = sw.GuardianKey
    LEFT JOIN ContactedTodayCte   ct  ON ct.ContactKey  = sw.GuardianKey
    LEFT JOIN CallRequiredCte     cr  ON cr.ContactKey  = sw.GuardianKey
    ORDER BY sw.GuardianKey, sw.FullName";

        var grouped = new Dictionary<string, GuardianWorklistRow>();

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@minBalance",       SqlDbType.Money).Value      = minBalance;
            cmd.Parameters.Add("@classFilter",     SqlDbType.VarChar, 50).Value = classFilter ?? "";
            cmd.Parameters.Add("@currentSemester", SqlDbType.VarChar, 50).Value = currentSemester;
            cmd.Parameters.Add("@prevSemester",    SqlDbType.VarChar, 50).Value = (object)prevSemester ?? DBNull.Value;
            cmd.Parameters.Add("@callRequiredCutoff", SqlDbType.DateTime).Value =
                DateTime.Today.AddDays(-settings.CallRequiredWindowDays);

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
                        FirstContactDate = rdr["FirstContactDate"] as DateTime?,
                        ContactedToday = Convert.ToInt32(rdr["ContactedToday"]) == 1,
                        CallRequired   = Convert.ToInt32(rdr["CallRequired"])   == 1,
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

        // Deadline-aware required-payment line (F1).
        DateTime today = DateTime.Today;
        double termProgress = FeesUrgency.TermProgress(today, tStart, tEnd);
        double requiredPct  = hasTermDates ? FeesUrgency.RequiredPct(settings.CollectionGoal, termProgress) : 0.0;

        var rows = new List<GuardianWorklistRow>(grouped.Values);
        foreach (var g in rows)
        {
            g.PaymentPercent = g.TotalBilled > 0
                ? Math.Round(g.TotalPaid / g.TotalBilled * 100m, 1) : 0m;
            double payProgress = g.TotalBilled > 0 ? (double)(g.TotalPaid / g.TotalBilled) : 0.0;
            g.PacingGap = hasTermDates ? termProgress - payProgress : 0.0;  // retained for display
            double shortfall = hasTermDates ? FeesUrgency.Shortfall(requiredPct, g.PaymentPercent) : 0.0;

            int effectiveStaleDays = g.TotalBalance >= settings.StaleHighBalanceAmount
                ? settings.StaleHighBalanceDays
                : g.TotalBalance >= settings.StaleMedBalanceAmount
                    ? settings.StaleMedBalanceDays
                    : settings.StaleThresholdDays;

            bool hasActivePromise = g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today;
            bool hasCoveringActivePromise = hasActivePromise
                && g.TotalBalance > 0
                && (double)((g.LatestPromiseAmount ?? 0m) / g.TotalBalance) >= settings.PartialPromiseCoverageThreshold;

            g.Tier = FeesUrgency.ComputeTier(g, today, hasTermDates,
                shortfall, settings.CriticalShortfallPoints, hasActivePromise,
                effectiveStaleDays, settings.NoProgressEscalationWeeks, settings.NoProgressPaymentThreshold);

            bool failedLastOutcome = g.LastOutcome.HasValue
                && FeesUrgency.FailedOutcomes.Contains(g.LastOutcome.Value);
            g.UrgencyScore = FeesUrgency.UrgencyScore(
                g.TotalBalance, shortfall,
                brokenPromise: g.Tier == PriorityTier.BrokenPromise,
                failedLastOutcome: failedLastOutcome,
                callRequired: g.CallRequired,
                hasCoveringActivePromise: hasCoveringActivePromise);
        }

        // CallRequired stays a flag on the row (g.CallRequired) and is NOT folded into
        // Tier — Tier always reflects the true risk tier so dashboard counts stay accurate.
        // The UI colours CallRequired rows from the flag, and the 1.4x score multiplier
        // already lifted their rank.

        // F4: single money-at-risk ranking for every list.
        rows.Sort((a, b) =>
        {
            int u = b.UrgencyScore.CompareTo(a.UrgencyScore);   // higher score = chase sooner
            return u != 0 ? u : b.TotalBalance.CompareTo(a.TotalBalance);
        });

        var remSummary = GetReminderSummaryByGuardian(settings.TermStartDate, settings.TermEndDate);
        foreach (var row in rows)
            if (remSummary.TryGetValue(row.GuardianContact, out var rs))
            {
                row.RemindersSentCount = rs.count;
                row.LastReminderDate   = rs.last;
                row.LastReminderType   = rs.type;
            }

        return rows;
    }

    private bool WasContactedToday(string guardianKey)
    {
        const string sql = @"
        SELECT COUNT(1) FROM tbl_FeesContactLog
        WHERE GuardianKey = @key
          AND CAST(ContactDate AS DATE) = CAST(GETDATE() AS DATE)
          AND Outcome IN ('Contacted', 'Promised', 'Refused')";
        using var conn = new SqlConnection(connectionString);
        using var cmd  = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@key", SqlDbType.VarChar, 20).Value = guardianKey;
        conn.Open();
        return (int)cmd.ExecuteScalar() > 0;
    }

    public List<GuardianWorklistRow> GetDailyWorklist(decimal minBalance = 0)
    {
        var settings = GetSettings();
        var all      = GetGuardianWorklist("", minBalance, settings);
        var today = DateTime.Today;

        // F6: within PromiseResurfaceDays of term end, stop hiding partially-covered
        // promises so the uncovered remainder gets worked before the deadline.
        bool nearDeadline = settings.TermEndDate.HasValue
            && (settings.TermEndDate.Value.Date - today).TotalDays <= settings.PromiseResurfaceDays;

        return all.Where(g =>
        {
            if (!nearDeadline
                && g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today
                && g.PaymentsSinceLatestPromise < (g.LatestPromiseAmount ?? 0))
            {
                decimal promiseAmt    = g.LatestPromiseAmount ?? 0m;
                double  coverageRatio = g.TotalBalance > 0
                    ? (double)(promiseAmt / g.TotalBalance)
                    : 1.0;
                if (coverageRatio >= settings.PartialPromiseCoverageThreshold)
                    return false;
            }

            // Exclude if successfully reached today
            return !g.ContactedToday;
        })
        .OrderByDescending(g => g.UrgencyScore)   // F4: same ranking as the guardian list
        .ThenByDescending(g => g.TotalBalance)
        .ToList();
    }

    public List<StudentWorklistRow> GetStudentWorklist(string classFilter = "", decimal minBalance = 0)
    {
        var studentSettings = GetSettings();
        var guardianRows = GetGuardianWorklist(classFilter, minBalance, studentSettings);
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
                    UrgencyScore     = g.UrgencyScore,
                    GuardianKey      = g.GuardianContact,
                    GuardianContact  = g.GuardianContact,
                    GuardianName     = g.GuardianName,
                    GuardianRelation = g.GuardianRelation,
                    LastContactDate  = g.LastContactDate,
                    LastOutcome      = g.LastOutcome,
                });
            }
        }

        var studentList = result
            .OrderByDescending(s => s.UrgencyScore)
            .ThenBy(s => s.ClassId)
            .ThenBy(s => s.FullName)
            .ToList();

        var remByStudent = GetReminderSummaryByStudent(studentSettings.TermStartDate, studentSettings.TermEndDate);
        foreach (var row in studentList)
            if (remByStudent.TryGetValue(row.StudentNumber, out var rs))
            {
                row.RemindersSentCount = rs.count;
                row.LastReminderDate   = rs.last;
                row.LastReminderType   = rs.type;
            }

        return studentList;
    }

    public DashboardData GetDashboardData()
    {
        var settings = GetSettings();
        string currentSemester = AlienAge.Semesters.WorkingSemesters.GetWorkingSemester();
        string prevSemester    = GetPreviousSemesterId(currentSemester);

        var all = GetGuardianWorklist("", 0, settings);
        var totals = GetDashboardTotals(currentSemester, prevSemester);
        var today  = DateTime.Today;
        bool termDatesConfigured = settings.TermStartDate.HasValue && settings.TermEndDate.HasValue;
        double termProgress = FeesUrgency.TermProgress(today, settings.TermStartDate, settings.TermEndDate);

        int contactedToday = all.Count(g => g.ContactedToday);

        bool nearDeadline = settings.TermEndDate.HasValue
            && (settings.TermEndDate.Value.Date - today).TotalDays <= settings.PromiseResurfaceDays;

        int dailyTotal = all.Count(g =>
        {
            if (!nearDeadline
                && g.LatestPromiseDate.HasValue
                && g.LatestPromiseDate.Value.Date >= today
                && g.PaymentsSinceLatestPromise < (g.LatestPromiseAmount ?? 0))
            {
                decimal promiseAmt    = g.LatestPromiseAmount ?? 0m;
                double  coverageRatio = g.TotalBalance > 0
                    ? (double)(promiseAmt / g.TotalBalance)
                    : 1.0;
                if (coverageRatio >= settings.PartialPromiseCoverageThreshold)
                    return false;
            }
            return !g.ContactedToday;
        }) + contactedToday;

        int belowPacingCount = all.Count(g => g.PacingGap > 0);

        int termWeek = 0, totalTermWeeks = 0;
        if (settings.TermStartDate.HasValue && settings.TermEndDate.HasValue)
        {
            // School week runs Sun–Sat; anchor both dates to their containing Sunday
            DateTime tStart = settings.TermStartDate.Value;
            DateTime tEnd   = settings.TermEndDate.Value;
            DateTime termSunday  = tStart.AddDays(-(int)tStart.DayOfWeek);  // Sunday on/before term start
            DateTime todaySunday = today.AddDays(-(int)today.DayOfWeek);     // Sunday on/before today
            int totalDays  = (int)(tEnd - termSunday).TotalDays;
            totalTermWeeks = Math.Max(1, (totalDays + 6) / 7);
            int elapsedWeeks = Math.Max(0, (int)(todaySunday - termSunday).TotalDays / 7);
            termWeek = Math.Min(totalTermWeeks - 1, elapsedWeeks);  // 0-based: week 0 = first week
        }

        return new DashboardData
        {
            TotalOutstanding          = all.Sum(g => g.TotalBalance),  // positive balances only
            TotalPayable              = totals.TotalPayable,            // all students, matches tracking sheet
            TotalCollected            = totals.TotalPaid,               // all students
            CollectedThisWeek         = totals.CollectedThisWeek,
            TotalGuardiansWithBalance = all.Count,
            DailyListTotal            = dailyTotal,
            DailyListContacted        = contactedToday,
            BrokenPromiseCount        = all.Count(g => g.Tier == PriorityTier.BrokenPromise),
            ActivePromiseCount        = all.Count(g =>
                g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date >= today),
            TotalEnrolled      = totals.TotalEnrolled,
            NilBalanceStudents = totals.NilBalance,
            ZeroPaidStudents   = totals.ZeroPaid,
            BelowPacingCount   = belowPacingCount,
            CurrentTermWeek    = termWeek,
            TotalTermWeeks     = totalTermWeeks,
            TermDatesConfigured   = termDatesConfigured,
            TermProgress          = termProgress,
            CollectionGoalPercent = (decimal)(settings.CollectionGoal * 100.0),
            ByPriority = Enum.GetValues(typeof(PriorityTier))
                .Cast<PriorityTier>()
                .Where(t => t != PriorityTier.CallRequired)   // CallRequired is a flag, not a risk tier
                .Select(t => new PriorityGroupStats
                {
                    Tier          = t,
                    GuardianCount = all.Count(g => g.Tier == t),
                    TotalBalance  = all.Where(g => g.Tier == t).Sum(g => g.TotalBalance),
                }).ToList(),
            TopByBalance = all.OrderByDescending(g => g.TotalBalance).Take(5).ToList(),
        };
    }

    public string GetSchoolName()
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

    private static string PickPromiseTemplate(string type, FeesFollowUpSettings s) => type switch
    {
        "3DayBefore" => !string.IsNullOrWhiteSpace(s.SmsTemplate2Day)    ? s.SmsTemplate2Day    : DefaultPreDue,
        "DayOf"      => !string.IsNullOrWhiteSpace(s.SmsTemplateDayOf)   ? s.SmsTemplateDayOf   : DefaultDayOf,
        "Overdue"    => !string.IsNullOrWhiteSpace(s.SmsTemplateOverdue) ? s.SmsTemplateOverdue : DefaultOverdue,
        _            => "",
    };

    private List<ReminderItem> GetStudentsWithActivePromises(
        SqlConnection conn, string school,
        string preDueTemplate, string dayOfTemplate, string overdueTemplate)
    {
        var today        = DateTime.Today;
        DateTime windowStart = today.AddDays(-8);  // T+1 of 7 days ago
        DateTime windowEnd   = today.AddDays(3);   // T-3 of 3 days ahead
        string currentSemester = AlienAge.Semesters.WorkingSemesters.GetWorkingSemester();
        string prevSemester    = GetPreviousSemesterId(currentSemester);

        // Latest promise per student within the window
        string sql = @"
;WITH LatestPromise AS (
    SELECT cl.StudentNumber,
           cl.GuardianKey,
           cl.PromiseDate,
           cl.PromiseAmount,
           ROW_NUMBER() OVER (PARTITION BY cl.StudentNumber ORDER BY cl.ContactDate DESC) AS rn
    FROM tbl_FeesContactLog cl
    WHERE cl.Outcome = 'Promised'
      AND cl.PromiseDate IS NOT NULL
      AND cl.PromiseDate >= @windowStart
      AND cl.PromiseDate <= @windowEnd
),
CurrentTermPayments AS (
    SELECT StudentNumber,
           ISNULL(SUM(Debit), 0)  AS TotalBilled,
           ISNULL(SUM(Credit), 0) AS TotalPaid
    FROM FeesPayment WHERE SemesterId = @sem
    GROUP BY StudentNumber
),
PrevTermLastBalance AS (
    SELECT StudentNumber, Balance AS BFAmount
    FROM (
        SELECT StudentNumber, Balance,
               ROW_NUMBER() OVER (PARTITION BY StudentNumber ORDER BY PaymentId DESC) AS rn
        FROM FeesPayment
        WHERE SemesterId = @prevSem
    ) t
    WHERE rn = 1
)
SELECT
    lp.StudentNumber,
    lp.GuardianKey,
    lp.PromiseDate,
    ISNULL(lp.PromiseAmount, 0)                                            AS PromisedAmount,
    s.fullName                                                             AS StudentName,
    s.ClassId,
    ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0)
        - ISNULL(ctp.TotalPaid, 0)                                        AS Balance,
    s.PriorityContact,
    s.OtherContact
FROM LatestPromise lp
INNER JOIN tbl_Stud s  ON s.StudentNumber = lp.StudentNumber
LEFT  JOIN CurrentTermPayments ctp ON ctp.StudentNumber = lp.StudentNumber
LEFT  JOIN PrevTermLastBalance  ptb ON ptb.StudentNumber = lp.StudentNumber
WHERE lp.rn = 1
  AND (ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0) - ISNULL(ctp.TotalPaid, 0)) > 0";

        var items = new List<ReminderItem>();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@windowStart", SqlDbType.Date).Value = windowStart;
        cmd.Parameters.Add("@windowEnd",   SqlDbType.Date).Value = windowEnd;
        cmd.Parameters.Add("@sem",         SqlDbType.NVarChar, 50).Value = currentSemester;
        cmd.Parameters.Add("@prevSem",     SqlDbType.NVarChar, 50).Value =
            (object)prevSemester ?? DBNull.Value;

        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            string studentNo   = rdr["StudentNumber"].ToString();
            string guardianKey = rdr["GuardianKey"].ToString();
            DateTime pd        = Convert.ToDateTime(rdr["PromiseDate"]);
            decimal promised   = Convert.ToDecimal(rdr["PromisedAmount"]);
            decimal balance    = Convert.ToDecimal(rdr["Balance"]);
            string name        = rdr["StudentName"].ToString();
            string classId     = rdr["ClassId"].ToString();

            // Resolve phone: priority contact -> alt contact -> skip
            string phone = rdr["PriorityContact"].ToString();
            if (string.IsNullOrWhiteSpace(phone) || phone.StartsWith("NOCONTACT-", StringComparison.Ordinal))
                phone = rdr["OtherContact"].ToString();
            if (string.IsNullOrWhiteSpace(phone) || phone.StartsWith("NOCONTACT-", StringComparison.Ordinal))
                continue;

            // Determine which reminder types are due today (with catch-up)
            var candidates = new (string type, bool isDue)[]
            {
                ("3DayBefore", today >= pd.AddDays(-3) && today <= pd.AddDays(-1)),
                ("DayOf",      today >= pd             && today <= pd.AddDays(1)),
                ("Overdue",    today >= pd.AddDays(1)  && today <= pd.AddDays(7)),
            };

            foreach (var (type, isDue) in candidates)
            {
                if (!isDue) continue;
                string template = type switch
                {
                    "3DayBefore" => !string.IsNullOrWhiteSpace(preDueTemplate)  ? preDueTemplate  : DefaultPreDue,
                    "DayOf"      => !string.IsNullOrWhiteSpace(dayOfTemplate)   ? dayOfTemplate   : DefaultDayOf,
                    "Overdue"    => !string.IsNullOrWhiteSpace(overdueTemplate) ? overdueTemplate : DefaultOverdue,
                    _            => ""
                };
                string msg = ApplySmsTemplate(template, balance, name, classId, pd, school, promised);
                items.Add(new ReminderItem
                {
                    GuardianKey    = guardianKey,
                    Phone          = phone,
                    StudentNumber  = studentNo,
                    StudentName    = name,
                    ClassId        = classId,
                    PromiseDate    = pd,
                    PromisedAmount = promised,
                    Balance        = balance,
                    ReminderType   = type,
                    Message        = msg,
                });
            }
        }
        return items;
    }

    public List<ReminderItem> GetRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        var all = GetStudentsWithActivePromises(conn, school,
            settings.SmsTemplate2Day, settings.SmsTemplateDayOf, settings.SmsTemplateOverdue);

        // Drop already-sent, per student (idempotency preserved at student grain).
        var notSent = all.Where(item =>
            !AlreadySentReminder(conn, item.GuardianKey, item.StudentNumber, item.PromiseDate, item.ReminderType))
            .ToList();

        // One SMS per guardian per reminder-type occurrence; re-render from merged values.
        var consolidated = SmsReminderLogic.ConsolidatePromiseReminders(notSent);
        foreach (var item in consolidated)
            item.Message = ApplySmsTemplate(
                PickPromiseTemplate(item.ReminderType, settings),
                item.Balance, item.StudentName, item.ClassId, item.PromiseDate, school, item.PromisedAmount);

        return consolidated;
    }

    public SmsReminderResult ExecuteSendReminders(List<ReminderItem> approved)
    {
        var result = new SmsReminderResult();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        foreach (var item in approved)
        {
            try
            {
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

                if (FeeSmsHelper.TrySend(connectionString, item.Phone, item.Message, out string err))
                {
                    if (item.ReminderType == "General")
                    {
                        LogGeneralReminderSent(conn, item.GuardianKey);
                        result.GeneralCount++;
                    }
                    else
                    {
                        // Per-student de-dup logging: log every underlying component (or the item
                        // itself if it was not consolidated).
                        if (item.Components != null && item.Components.Count > 0)
                            foreach (var c in item.Components)
                                LogReminderSent(conn, item.GuardianKey, c.StudentNumber, c.PromiseDate, item.ReminderType);
                        else
                            LogReminderSent(conn, item.GuardianKey, item.StudentNumber, item.PromiseDate, item.ReminderType);

                        switch (item.ReminderType)
                        {
                            case "3DayBefore": result.TwoDayCount++;  break;
                            case "DayOf":      result.DayOfCount++;   break;
                            case "Overdue":    result.OverdueCount++; break;
                        }
                    }
                }
                else
                {
                    result.Failures.Add($"{item.ReminderType} to {item.Phone} ({item.StudentName}): {err}");
                }
            }
            catch (Exception ex)
            {
                // The SMS may already have been delivered; record the logging/DB error but keep
                // processing the rest of the batch instead of aborting mid-send.
                result.Failures.Add($"{item.ReminderType} to {item.Phone} ({item.StudentName}): post-send logging error: {ex.Message}");
            }
        }
        return result;
    }

    private static string ApplySmsTemplate(string template, decimal balance,
        string studentName, string classId, DateTime date, string school, decimal promisedAmount)
        => template
            .Replace("{promised_amount}", SmsReminderLogic.FormatAmount(promisedAmount))
            .Replace("{balance}",         SmsReminderLogic.FormatAmount(balance))
            .Replace("{names}",           studentName)
            .Replace("{class}",           classId ?? "")
            .Replace("{date}",            date.ToString("dd-MMM-yyyy"))
            .Replace("{school}",          school);

    public string GetSmsTemplate(string key)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT SettingValue FROM tbl_FollowUpSettings WHERE SettingKey = @k", conn);
        cmd.Parameters.Add("@k", SqlDbType.NVarChar, 200).Value = key;
        return cmd.ExecuteScalar() as string ?? "";
    }

    private bool HasCallRequiredStudent(SqlConnection conn, string guardianKey)
    {
        using var cmd = new SqlCommand(
            "SELECT COUNT(1) FROM tbl_SmsReminderLog WHERE GuardianKey = @gk AND ReminderType = 'Overdue'",
            conn);
        cmd.Parameters.Add("@gk", SqlDbType.VarChar, 20).Value = guardianKey;
        return (int)cmd.ExecuteScalar() > 0;
    }

    private bool AlreadySentReminder(SqlConnection conn, string guardianKey,
        string studentNumber, DateTime promiseDate, string type)
    {
        using var cmd = new SqlCommand(
            @"SELECT COUNT(1) FROM tbl_SmsReminderLog
              WHERE GuardianKey = @gk
                AND (StudentNumber = @sn OR (StudentNumber IS NULL AND @sn IS NULL))
                AND PromiseDate   = @pd
                AND ReminderType  = @type",
            conn);
        cmd.Parameters.Add("@gk",   SqlDbType.VarChar,  20).Value = guardianKey;
        cmd.Parameters.Add("@sn",   SqlDbType.NVarChar,  20).Value = (object)studentNumber ?? DBNull.Value;
        cmd.Parameters.Add("@pd",   SqlDbType.Date).Value           = promiseDate.Date;
        cmd.Parameters.Add("@type", SqlDbType.VarChar,  20).Value  = type;
        return (int)cmd.ExecuteScalar() > 0;
    }

    private void LogReminderSent(SqlConnection conn, string guardianKey,
        string studentNumber, DateTime promiseDate, string type)
    {
        using var cmd = new SqlCommand(
            "INSERT INTO tbl_SmsReminderLog (GuardianKey, StudentNumber, PromiseDate, ReminderType) VALUES (@gk, @sn, @pd, @type)",
            conn);
        cmd.Parameters.Add("@gk",   SqlDbType.VarChar,  20).Value = guardianKey;
        cmd.Parameters.Add("@sn",   SqlDbType.NVarChar,  20).Value = (object)studentNumber ?? DBNull.Value;
        cmd.Parameters.Add("@pd",   SqlDbType.Date).Value           = promiseDate.Date;
        cmd.Parameters.Add("@type", SqlDbType.VarChar,  20).Value  = type;
        cmd.ExecuteNonQuery();
    }

    private void LogGeneralReminderSent(SqlConnection conn, string guardianKey)
    {
        // PromiseDate is NOT NULL, so a General reminder (which has no promise) stores today as
        // a placeholder to satisfy the column and the UNIQUE(GuardianKey,PromiseDate,ReminderType)
        // key. The cooldown in GetGuardiansInGeneralCooldown is measured against SentAt (which
        // defaults to GETDATE()), never against this placeholder PromiseDate.
        using var cmd = new SqlCommand(
            "INSERT INTO tbl_SmsReminderLog (GuardianKey, StudentNumber, PromiseDate, ReminderType) " +
            "VALUES (@gk, NULL, @pd, 'General')", conn);
        cmd.Parameters.Add("@gk", SqlDbType.VarChar, 20).Value = guardianKey;
        cmd.Parameters.Add("@pd", SqlDbType.Date).Value        = DateTime.Today;
        cmd.ExecuteNonQuery();
    }

    private HashSet<string> GetGuardiansInGeneralCooldown(int cooldownDays)
    {
        var set = new HashSet<string>(StringComparer.Ordinal);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            @"SELECT DISTINCT GuardianKey FROM tbl_SmsReminderLog
              WHERE ReminderType = 'General' AND GuardianKey IS NOT NULL
                AND SentAt >= @cutoff", conn);
        cmd.Parameters.Add("@cutoff", SqlDbType.DateTime).Value = DateTime.Today.AddDays(-cooldownDays);
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            if (!rdr.IsDBNull(0)) set.Add(rdr.GetString(0));
        return set;
    }

    // (count, lastSentAt, lastType) of reminders within the current term, keyed by GuardianKey.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummaryByGuardian(DateTime? termStart, DateTime? termEnd)
        => GetReminderSummary("GuardianKey", termStart, termEnd);

    // (count, lastSentAt, lastType) within the current term, keyed by StudentNumber.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummaryByStudent(DateTime? termStart, DateTime? termEnd)
        => GetReminderSummary("StudentNumber", termStart, termEnd);

    // Per-key reminder summary (count, most-recent SentAt, type of that most-recent row) over the
    // term window, computed in a single pass so the "last type" is the term-scoped latest, not the
    // all-time latest. keyColumn is a fixed identifier ("GuardianKey" | "StudentNumber"), never user input.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummary(string keyColumn, DateTime? termStart, DateTime? termEnd)
    {
        var map = new Dictionary<string, (int, DateTime, string)>(StringComparer.Ordinal);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            $@";WITH Scoped AS (
                 SELECT {keyColumn} AS K, ReminderType, SentAt,
                        ROW_NUMBER() OVER (PARTITION BY {keyColumn} ORDER BY SentAt DESC) AS rn,
                        COUNT(*)     OVER (PARTITION BY {keyColumn})                       AS Cnt
                 FROM tbl_SmsReminderLog
                 WHERE {keyColumn} IS NOT NULL
                   AND (@start IS NULL OR SentAt >= @start)
                   AND (@end   IS NULL OR SentAt <  DATEADD(DAY, 1, @end))
               )
               SELECT K, Cnt, SentAt, ReminderType FROM Scoped WHERE rn = 1", conn);
        cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = (object)termStart ?? DBNull.Value;
        cmd.Parameters.Add("@end",   SqlDbType.DateTime).Value = (object)termEnd   ?? DBNull.Value;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            map[rdr.GetString(0)] = (rdr.GetInt32(1), rdr.GetDateTime(2), rdr.IsDBNull(3) ? "" : rdr.GetString(3));
        return map;
    }

    public List<ReminderItem> GetBalanceRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        string template = !string.IsNullOrWhiteSpace(settings.SmsTemplateGeneral)
            ? settings.SmsTemplateGeneral : DefaultGeneral;
        var today = DateTime.Today;

        var rows   = GetGuardianWorklist("", 0, settings);
        var cooled = GetGuardiansInGeneralCooldown(settings.GeneralReminderCooldownDays);

        // Cross-channel guard: never send a balance reminder to a guardian who is already getting a
        // promise reminder today (e.g. a just-broken promise still in the Overdue window).
        HashSet<string> promiseGuardians;
        using (var pconn = new SqlConnection(connectionString))
        {
            pconn.Open();
            promiseGuardians = new HashSet<string>(
                GetStudentsWithActivePromises(pconn, school,
                    settings.SmsTemplate2Day, settings.SmsTemplateDayOf, settings.SmsTemplateOverdue)
                    .Select(i => i.GuardianKey)
                    .Where(k => !string.IsNullOrEmpty(k)),   // guard against legacy NULL GuardianKey rows
                StringComparer.Ordinal);
        }

        var items = new List<ReminderItem>();
        foreach (var g in rows)
        {
            bool hasActivePromise = g.LatestPromiseDate.HasValue && g.LatestPromiseDate.Value.Date >= today;
            if (!SmsReminderLogic.IsBalanceReminderEligible(g.Tier, g.TotalBalance, hasActivePromise)) continue;
            if (cooled.Contains(g.GuardianContact)) continue;
            if (promiseGuardians.Contains(g.GuardianContact)) continue;   // in today's promise-reminder queue — skip balance SMS

            string phone = SmsReminderLogic.NormalizePhone(g.GuardianContact)
                        ?? SmsReminderLogic.NormalizePhone(g.Contact2);
            if (phone == null) continue;   // no callable number

            string names   = string.Join(", ", g.Students.Select(s => s.FullName));
            string classes = string.Join(", ", g.Students.Select(s => s.ClassId)
                                 .Where(c => !string.IsNullOrWhiteSpace(c)).Distinct());
            string msg = ApplySmsTemplate(template, g.TotalBalance, names, classes, today, school, 0m);

            items.Add(new ReminderItem
            {
                GuardianKey    = g.GuardianContact,
                Phone          = phone,
                StudentName    = names,
                ClassId        = classes,
                Balance        = g.TotalBalance,
                PromisedAmount = 0m,
                PromiseDate    = today,   // placeholder; a General reminder carries no promise date (StudentNumber stays null too)
                ReminderType   = "General",
                Message        = msg,
                Components     = new List<ReminderComponent>(),
            });
        }
        return items;
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
            || (r.LastOutcome.HasValue && FeesUrgency.FailedOutcomes.Contains(r.LastOutcome.Value)))
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
        SELECT cl.ContactId, cl.ContactDate, cl.Channel, cl.Outcome, cl.Note, cl.LoggedBy,
               cl.PromiseDate, cl.PromiseAmount, cl.GuardianKey,
               cl.StudentNumber,
               s.fullName AS StudentName
        FROM tbl_FeesContactLog cl
        LEFT JOIN tbl_Stud s ON s.StudentNumber = cl.StudentNumber
        WHERE cl.GuardianKey = @guardianKey
           OR (cl.GuardianKey IS NULL AND cl.StudentNumber IN ({inList}))
        ORDER BY cl.ContactDate DESC", conn);

        da.SelectCommand.Parameters.Add("@guardianKey", SqlDbType.VarChar, 20).Value = guardianKey;
        for (int i = 0; i < nums.Count; i++)
            da.SelectCommand.Parameters.Add($"@sn{i}", SqlDbType.VarChar, 50).Value = nums[i];

        da.Fill(dt);
        return dt;
    }

    /// <summary>
    /// All interactions logged within [fromInclusive, toInclusive] (whole days),
    /// joined to the student name. Ordered newest first. Read-only review feed.
    /// </summary>
    public DataTable GetInteractionsByDateRange(DateTime fromInclusive, DateTime toInclusive)
    {
        var dt = new DataTable();
        using var conn = new SqlConnection(connectionString);
        using var da = new SqlDataAdapter(@"
        SELECT cl.ContactId,
               cl.ContactDate,
               s.fullName AS StudentName,
               CASE WHEN LTRIM(RTRIM(ISNULL(s.GuardianRelation,''))) = ''
                    THEN ISNULL(s.Guardian,'')
                    ELSE ISNULL(s.Guardian,'') + ' (' + s.GuardianRelation + ')'
               END AS GuardianDisplay,
               cl.Channel,
               cl.Outcome,
               cl.Note,
               cl.PromiseDate,
               cl.PromiseAmount,
               cl.LoggedBy
        FROM tbl_FeesContactLog cl
        LEFT JOIN tbl_Stud s ON s.StudentNumber = cl.StudentNumber
        WHERE cl.ContactDate >= @from AND cl.ContactDate < @toExclusive
        ORDER BY cl.ContactDate DESC", conn);
        da.SelectCommand.Parameters.Add("@from", SqlDbType.DateTime).Value = fromInclusive.Date;
        da.SelectCommand.Parameters.Add("@toExclusive", SqlDbType.DateTime).Value =
            toInclusive.Date.AddDays(1);
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
