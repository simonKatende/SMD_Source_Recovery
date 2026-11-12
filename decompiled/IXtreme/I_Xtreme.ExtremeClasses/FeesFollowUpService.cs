using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

public partial class FeesFollowUpService
{
    private readonly string connectionString;

    // One set of default messages for the whole feature (see FamilySms).
    internal const string DefaultPreDue  = FamilySms.DefaultPreDue;
    internal const string DefaultDayOf   = FamilySms.DefaultDayOf;
    internal const string DefaultOverdue = FamilySms.DefaultOverdue;
    internal const string DefaultGeneral = FamilySms.DefaultGeneral;

    /// <summary>Database update this build needs (notes/migrations).</summary>
    internal const string MigrationScript = "2026-11-11_fees_followup_crm.sql";

    private static readonly HashSet<string> _schemaChecked = new HashSet<string>();
    private string _semesterCache;

    // The guardian key: priority contact, else other contact, else a per-student placeholder.
    private const string GuardianKeySql = @"CASE
                WHEN NULLIF(RTRIM(LTRIM(ISNULL(s.PriorityContact,''))), '') IS NOT NULL
                    THEN RTRIM(LTRIM(s.PriorityContact))
                WHEN NULLIF(RTRIM(LTRIM(ISNULL(s.OtherContact,''))),   '') IS NOT NULL
                    THEN RTRIM(LTRIM(s.OtherContact))
                ELSE 'NOCONTACT-' + s.StudentNumber
            END";

    /// <summary>Sends one SMS; returns false with a reason when it could not be sent.</summary>
    internal delegate bool SmsSend(string phone, string message, out string error);

    /// <summary>How reminders are actually sent (the egosms gateway in the application).</summary>
    internal SmsSend SendSms { get; set; }

    /// <summary>Decrypts the stored school name (the application stores it encrypted).</summary>
    internal Func<string, string> DecryptSchoolName { get; set; }

    /// <summary>
    /// A service bound to one database. The application uses the parameterless constructor
    /// (FeesFollowUpService.App.cs), which connects to the school's database and wires the
    /// SMS gateway; this one exists so the feature can be tested against a throwaway database.
    /// </summary>
    public FeesFollowUpService(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("A database connection string is required.", nameof(connectionString));
        this.connectionString = connectionString;
    }

    public string ConnectionString => connectionString;

    /// <summary>The term the application is working in (e.g. "TermIII-2026").</summary>
    public string GetWorkingSemester()
    {
        if (_semesterCache != null) return _semesterCache;
        // Same source as the application's term setup (tbl_ActiveSemester).
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand("SELECT semester FROM tbl_ActiveSemester", conn);
        string semester = null;
        using (var rdr = cmd.ExecuteReader())
            while (rdr.Read()) semester = rdr["semester"]?.ToString();
        if (string.IsNullOrWhiteSpace(semester))
            throw new InvalidOperationException(
                "No working term is set in the application. Set the term before using Fees Follow-up.");
        return _semesterCache = semester.Trim();
    }

    /// <summary>
    /// Throws a plain-language error when the database has not had the Fees Follow-up update
    /// applied, instead of letting a later query fail on a missing column.
    /// </summary>
    public void EnsureSchemaReady()
    {
        lock (_schemaChecked)
            if (_schemaChecked.Contains(connectionString)) return;

        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            SELECT CASE WHEN COL_LENGTH('dbo.tbl_FeesContactLog', 'SemesterId')   IS NOT NULL
                         AND COL_LENGTH('dbo.tbl_FeesContactLog', 'PromiseScope') IS NOT NULL
                         AND COL_LENGTH('dbo.tbl_SmsReminderLog', 'SemesterId')   IS NOT NULL
                         AND OBJECT_ID('dbo.tbl_FeesGuardianPrefs', 'U')          IS NOT NULL
                         AND OBJECT_ID('dbo.tbl_FeesPromiseInstalment', 'U')      IS NOT NULL
                         AND OBJECT_ID('dbo.tbl_FeesReminderRun', 'U')            IS NOT NULL
                        THEN 1 ELSE 0 END", conn);
        if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
            throw new InvalidOperationException(
                "Fees Follow-up needs a database update before it can be used. " +
                $"Ask your administrator to run the script \"{MigrationScript}\" on this school's database.");

        lock (_schemaChecked) _schemaChecked.Add(connectionString);
    }

    public static string RenderTemplate(string template, decimal balance,
        string studentName, string classId, DateTime date, string school, decimal promisedAmount)
        => ApplySmsTemplate(template, balance, studentName, classId, date, school, promisedAmount);

    /// <summary>Record that a reminder was sent by hand from the interaction window (once per family per day and type).</summary>
    public void LogManualReminderSent(string guardianKey, DateTime promiseDate, string type)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        if (!AlreadySentReminder(conn, guardianKey, null, promiseDate, type))
            LogReminderSent(conn, guardianKey, null, promiseDate, type);
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
        EnsureSchemaReady();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT SettingKey, SettingValue FROM tbl_FollowUpSettings", conn);
        var dict = new Dictionary<string, string>();
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            dict[rdr.GetString(0)] = rdr.IsDBNull(1) ? "" : rdr.GetString(1);

        var settings = new FeesFollowUpSettings
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
            DefaultSmsStyle = FamilySms.ParseStyle(dict.TryGetValue("DefaultSmsStyle", out var dss) ? dss : ""),
            AutoRemindersEnabled = dict.TryGetValue("AutoRemindersEnabled", out var are) && are == "1",
            AutoReminderTime = dict.TryGetValue("AutoReminderTime", out var art) && !string.IsNullOrWhiteSpace(art)
                ? art : "09:00",
        };

        // Term dates belong to the term they were entered for. When the application has moved to
        // a new term they stop applying until the bursar enters the new ones.
        settings.WorkingSemester = GetWorkingSemester();
        dict.TryGetValue("TermDatesSemester", out var stampedSemester);
        bool haveDates = settings.TermStartDate.HasValue && settings.TermEndDate.HasValue;
        if (!haveDates || !FeesTerm.DatesApply(stampedSemester, settings.WorkingSemester,
                                               settings.TermEndDate, DateTime.Today))
        {
            settings.TermStartDate        = null;
            settings.TermEndDate          = null;
            settings.TermDatesNeedSetting = true;
        }
        return settings;
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
        // Stamp the dates with the term they were entered for (see FeesTerm.DatesApply).
        Upsert(conn, "TermDatesSemester",
            s.TermStartDate.HasValue && s.TermEndDate.HasValue ? GetWorkingSemester() : "");
        Upsert(conn, "DefaultSmsStyle",      s.DefaultSmsStyle.ToString());
        Upsert(conn, "AutoRemindersEnabled", s.AutoRemindersEnabled ? "1" : "0");
        Upsert(conn, "AutoReminderTime",
            AutoReminderSchedule.ParseTime(s.AutoReminderTime).ToString(@"hh\:mm"));
    }

    private static void Upsert(SqlConnection conn, string key, string value)
    {
        using var cmd = new SqlCommand(@"
            IF EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = @k)
                UPDATE tbl_FollowUpSettings SET SettingValue = @v WHERE SettingKey = @k
            ELSE
                INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES (@k, @v)", conn);
        cmd.Parameters.Add("@k", SqlDbType.NVarChar, 200).Value = key;
        cmd.Parameters.Add("@v", SqlDbType.NVarChar, 1000).Value = value;
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
        ISNULL(SUM(ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0)), 0) AS TotalPayable,
        ISNULL(SUM(ISNULL(ctp.TotalPaid, 0)), 0)                             AS TotalPaid,
        ISNULL(SUM(CASE WHEN ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0)
                             - ISNULL(ctp.TotalPaid, 0) <= 0 THEN 1 ELSE 0 END), 0) AS NilBalance,
        ISNULL(SUM(CASE WHEN ISNULL(ctp.TotalPaid, 0) = 0
                         AND ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0) > 0
                        THEN 1 ELSE 0 END), 0)                               AS ZeroPaid
        ,(SELECT ISNULL(SUM(Credit), 0) FROM FeesPayment
          WHERE SemesterId = @currentSemester AND Credit > 0
            AND DateOfPayment >= @weekStart)                                AS CollectedThisWeek
    FROM tbl_Stud s
    LEFT JOIN CurrentTermPayments ctp ON ctp.StudentNumber = s.StudentNumber
    LEFT JOIN PrevTermLastBalance  ptb ON ptb.StudentNumber = s.StudentNumber
    -- Same students as the worklists: billed this term, or active with a balance brought forward.
    WHERE ctp.StudentNumber IS NOT NULL
       OR (ISNULL(ptb.BFAmount, 0) > 0
           AND ISNULL(NULLIF(LTRIM(RTRIM(s.Status)), ''), 'Active') = 'Active')";

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
        FeesFollowUpSettings settings = null, bool includeAllEnrolled = false)
    {
        EnsureSchemaReady();
        settings ??= GetSettings();
        DateTime? tStart = settings.TermStartDate;
        DateTime? tEnd   = settings.TermEndDate;
        bool hasTermDates = tStart.HasValue && tEnd.HasValue;
        DateTime today = DateTime.Today;
        classFilter ??= "";

        string currentSemester = GetWorkingSemester();
        string prevSemester    = GetPreviousSemesterId(currentSemester);  // may be null

        // Uses the same formula as the Fees Tracking Sheet (usrStudentAccounts):
        //   TotalBilled = SUM(Debit, current semester) + stored Balance from last previous-semester entry
        //   TotalPaid   = SUM(Credit, current semester)
        //   Balance     = TotalBilled - TotalPaid
        // Every student with a current-semester FeesPayment entry is read, plus active students
        // who have not been billed yet this term but still owe a balance brought forward (so they
        // are not left off the lists). The class / minimum-balance filters are applied afterwards
        // in code, because a family's promise is judged against ALL its children: a sibling who
        // has cleared must still count towards a whole-family promise.
        // Interactions, promises and reminders are scoped to the current term (SemesterId).
        string sql = $@"
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
    FamilyStudents AS (
        SELECT
            s.StudentNumber,
            s.fullName          AS FullName,
            s.ClassId,
            s.Guardian          AS GuardianName,
            s.GuardianRelation  AS GuardianRelation,
            s.OtherContact      AS Contact2,
            s.StudentID         AS StudentId,
            s.StudyStatus       AS DayBoarder,
            ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0) AS TotalBilled,
            ISNULL(ctp.TotalPaid, 0) AS TotalPaid,
            ISNULL(ctp.TotalBilled, 0) + ISNULL(ptb.BFAmount, 0) - ISNULL(ctp.TotalPaid, 0) AS Balance,
            {GuardianKeySql} AS GuardianKey
        FROM tbl_Stud s
        LEFT JOIN CurrentTermPayments ctp ON ctp.StudentNumber = s.StudentNumber
        LEFT JOIN PrevTermLastBalance  ptb ON ptb.StudentNumber = s.StudentNumber
        WHERE ctp.StudentNumber IS NOT NULL
           OR (ISNULL(ptb.BFAmount, 0) > 0
               AND ISNULL(NULLIF(LTRIM(RTRIM(s.Status)), ''), 'Active') = 'Active')
    ),
    AllRelevantContacts AS (
        SELECT cl.GuardianKey AS ContactKey,
               cl.ContactDate, cl.Outcome, cl.ContactId
        FROM tbl_FeesContactLog cl
        WHERE cl.GuardianKey IS NOT NULL
          AND cl.SemesterId = @currentSemester
          AND EXISTS (SELECT 1 FROM FamilyStudents sw WHERE sw.GuardianKey = cl.GuardianKey)
        UNION ALL
        SELECT sw.GuardianKey AS ContactKey,
               cl.ContactDate, cl.Outcome, cl.ContactId
        FROM tbl_FeesContactLog cl
        JOIN FamilyStudents sw ON sw.StudentNumber = cl.StudentNumber
        WHERE cl.GuardianKey IS NULL
          AND cl.SemesterId = @currentSemester
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
    EarliestContact AS (
        SELECT ContactKey, MIN(ContactDate) AS FirstContactDate
        FROM AllRelevantContacts
        GROUP BY ContactKey
    ),
    TodayCte AS (
        -- Everything logged today: how many attempts, and whether the guardian was reached.
        SELECT ContactKey,
               COUNT(*) AS AttemptsToday,
               MAX(CASE WHEN Outcome IN ('Contacted', 'Promised', 'Refused') THEN 1 ELSE 0 END) AS ReachedToday
        FROM AllRelevantContacts
        WHERE ContactDate >= @today AND ContactDate < @tomorrow
        GROUP BY ContactKey
    ),
    CallRequiredCte AS (
        -- F3: only a *recent* Overdue SMS counts, so the flag decays instead of sticking forever.
        SELECT GuardianKey AS ContactKey
        FROM tbl_SmsReminderLog
        WHERE ReminderType = 'Overdue' AND GuardianKey IS NOT NULL
          AND SentAt >= @callRequiredCutoff
          AND SemesterId = @currentSemester
        GROUP BY GuardianKey
    )
    SELECT
        sw.StudentNumber, sw.FullName, sw.ClassId,
        sw.GuardianKey,
        sw.GuardianName, sw.GuardianRelation, sw.Contact2,
        sw.StudentId,    sw.DayBoarder,
        sw.TotalBilled,  sw.TotalPaid, sw.Balance,
        lcd.LastContactDate, lcd.LastOutcome,
        ec.FirstContactDate,
        ISNULL(td.AttemptsToday, 0) AS AttemptsToday,
        ISNULL(td.ReachedToday, 0)  AS ReachedToday,
        CASE WHEN cr.ContactKey IS NOT NULL THEN 1 ELSE 0 END AS CallRequired
    FROM FamilyStudents sw
    LEFT JOIN LatestContactDetail lcd ON lcd.ContactKey = sw.GuardianKey
    LEFT JOIN EarliestContact     ec  ON ec.ContactKey  = sw.GuardianKey
    LEFT JOIN TodayCte            td  ON td.ContactKey  = sw.GuardianKey
    LEFT JOIN CallRequiredCte     cr  ON cr.ContactKey  = sw.GuardianKey
    ORDER BY sw.GuardianKey, sw.FullName";

        var grouped   = new Dictionary<string, GuardianWorklistRow>(StringComparer.Ordinal);
        var familyAll = new Dictionary<string, List<StudentSummary>>(StringComparer.Ordinal);   // every child, listed or not
        var guardianOfStudent = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@currentSemester", SqlDbType.VarChar, 50).Value = currentSemester;
            cmd.Parameters.Add("@prevSemester",    SqlDbType.VarChar, 50).Value = (object)prevSemester ?? DBNull.Value;
            cmd.Parameters.Add("@today",           SqlDbType.DateTime).Value = today;
            cmd.Parameters.Add("@tomorrow",        SqlDbType.DateTime).Value = today.AddDays(1);
            cmd.Parameters.Add("@callRequiredCutoff", SqlDbType.DateTime).Value =
                today.AddDays(-settings.CallRequiredWindowDays);

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string gKey = rdr["GuardianKey"].ToString();

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

                if (!familyAll.TryGetValue(gKey, out var everyChild))
                    familyAll[gKey] = everyChild = new List<StudentSummary>();
                everyChild.Add(student);
                guardianOfStudent[student.StudentNumber] = gKey;

                bool listed = (includeAllEnrolled || bal > minBalance)
                           && (classFilter == "" || string.Equals(student.ClassId, classFilter, StringComparison.OrdinalIgnoreCase));
                if (!listed) continue;

                if (!grouped.TryGetValue(gKey, out var g))
                {
                    g = new GuardianWorklistRow
                    {
                        GuardianContact  = gKey,
                        GuardianName     = rdr.IsDBNull(rdr.GetOrdinal("GuardianName"))     ? "" : rdr.GetString(rdr.GetOrdinal("GuardianName")),
                        GuardianRelation = rdr.IsDBNull(rdr.GetOrdinal("GuardianRelation")) ? "" : rdr.GetString(rdr.GetOrdinal("GuardianRelation")),
                        Contact2         = rdr.IsDBNull(rdr.GetOrdinal("Contact2"))         ? "" : rdr.GetString(rdr.GetOrdinal("Contact2")),
                        LastContactDate  = rdr["LastContactDate"] as DateTime?,
                        LastOutcome      = ParseOutcome(rdr["LastOutcome"]?.ToString()),
                        FirstContactDate = rdr["FirstContactDate"] as DateTime?,
                        AttemptsToday    = Convert.ToInt32(rdr["AttemptsToday"]),
                        ContactedToday   = Convert.ToInt32(rdr["ReachedToday"]) == 1,
                        CallRequired     = Convert.ToInt32(rdr["CallRequired"]) == 1,
                        SmsStyle         = settings.DefaultSmsStyle,
                    };
                    grouped[gKey] = g;
                }

                g.Students.Add(student);
                g.TotalBilled  += billed;
                g.TotalPaid    += paid;
                g.TotalBalance += bal;
            }
        }

        var plansByGuardian   = LoadPromisePlans(currentSemester, guardianOfStudent);
        var paymentsByStudent = LoadTermPayments(currentSemester);
        var smsStyles         = LoadSmsStyles();

        // Deadline-aware required-payment line (F1).
        double termProgress = FeesUrgency.TermProgress(today, tStart, tEnd);
        double requiredPct  = hasTermDates ? FeesUrgency.RequiredPct(settings.CollectionGoal, termProgress) : 0.0;

        var rows = new List<GuardianWorklistRow>(grouped.Values);
        foreach (var g in rows)
        {
            // Nil-/credit-balance enrolled families (only present when includeAllEnrolled) are not
            // action items: clear any lingering Call-Required flag so they render calm and don't get
            // the urgency multiplier. ComputeTier independently forces them to the Current tier.
            if (g.TotalBalance <= 0m) g.CallRequired = false;

            if (smsStyles.TryGetValue(g.GuardianContact, out var ownStyle))
            {
                g.SmsStyle      = ownStyle;
                g.SmsStyleIsOwn = true;
            }

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

            // Promises / payment plan, judged against every child in the family.
            var everyChild = familyAll[g.GuardianContact];
            var balances   = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
            var familyPays = new List<PaymentFact>();
            foreach (var child in everyChild)
            {
                balances[child.StudentNumber] = child.Balance;
                if (paymentsByStudent.TryGetValue(child.StudentNumber, out var pays)) familyPays.AddRange(pays);
            }
            plansByGuardian.TryGetValue(g.GuardianContact, out var plans);
            g.Promise         = PromiseEvaluator.Evaluate(plans, familyPays, balances, today);
            g.PromiseDueToday = g.Promise.IsDueOn(today);

            // Display fields: the instalment that matters now (a missed one first, else the next due).
            var governing = g.Promise.EarliestMissed ?? g.Promise.NextDue;
            g.LatestPromiseDate          = governing?.DueDate;
            g.LatestPromiseAmount        = governing != null ? governing.AmountDue : (decimal?)null;
            g.PaymentsSinceLatestPromise = g.Promise.PaidSincePromise;

            bool hasActivePromise = g.Promise.HasActive;
            bool hasCoveringActivePromise = hasActivePromise && !g.Promise.IsBroken
                && g.TotalBalance > 0
                && (double)(g.Promise.RemainingPromised / g.TotalBalance) >= settings.PartialPromiseCoverageThreshold;

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

        var remSummary = GetReminderSummaryByGuardian(currentSemester);
        foreach (var row in rows)
            if (remSummary.TryGetValue(row.GuardianContact, out var rs))
            {
                row.RemindersSentCount = rs.count;
                row.LastReminderDate   = rs.last;
                row.LastReminderType   = rs.type;
            }

        return rows;
    }

    /// <summary>
    /// Every promise logged this term, grouped by guardian key. A promise logged before
    /// instalments existed is read as a single instalment (its PromiseDate / PromiseAmount).
    /// Old rows without a scope are whole-family promises.
    /// </summary>
    private Dictionary<string, List<PromisePlan>> LoadPromisePlans(
        string semester, Dictionary<string, string> guardianOfStudent)
    {
        const string sql = @"
        SELECT cl.ContactId, cl.GuardianKey, cl.StudentNumber, cl.ContactDate, cl.LoggedBy,
               cl.PromiseScope, cl.PromiseDate, cl.PromiseAmount,
               pi.DueDate AS InstalmentDate, pi.Amount AS InstalmentAmount
        FROM tbl_FeesContactLog cl
        LEFT JOIN tbl_FeesPromiseInstalment pi ON pi.ContactId = cl.ContactId
        WHERE cl.Outcome = 'Promised'
          AND cl.SemesterId = @semester
          AND (cl.PromiseDate IS NOT NULL OR pi.DueDate IS NOT NULL)
        ORDER BY cl.ContactId, pi.DueDate";

        var byContact = new Dictionary<int, PromisePlan>();
        var keyOf     = new Dictionary<int, string>();

        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@semester", SqlDbType.VarChar, 50).Value = semester;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            int id = Convert.ToInt32(rdr["ContactId"]);
            string studentNumber = rdr["StudentNumber"]?.ToString()?.Trim() ?? "";
            if (!byContact.TryGetValue(id, out var plan))
            {
                string gKey = rdr["GuardianKey"] as string;
                if (string.IsNullOrWhiteSpace(gKey))
                {
                    // Legacy student-level row: find the family through the student.
                    if (!guardianOfStudent.TryGetValue(studentNumber, out gKey)) continue;
                }
                bool forOneChild = string.Equals(rdr["PromiseScope"] as string, "Student", StringComparison.OrdinalIgnoreCase)
                                   && studentNumber != "";
                plan = new PromisePlan
                {
                    ContactId     = id,
                    LoggedAt      = Convert.ToDateTime(rdr["ContactDate"]),
                    LoggedBy      = rdr["LoggedBy"]?.ToString() ?? "",
                    StudentNumber = forOneChild ? studentNumber : "",
                };
                byContact[id] = plan;
                keyOf[id]     = gKey.Trim();
            }

            if (rdr["InstalmentDate"] != DBNull.Value)
                plan.Instalments.Add(new PromiseInstalment
                {
                    DueDate = Convert.ToDateTime(rdr["InstalmentDate"]),
                    Amount  = rdr["InstalmentAmount"] as decimal?,
                });
            else if (plan.Instalments.Count == 0 && rdr["PromiseDate"] != DBNull.Value)
                plan.Instalments.Add(new PromiseInstalment
                {
                    DueDate = Convert.ToDateTime(rdr["PromiseDate"]),
                    Amount  = rdr["PromiseAmount"] as decimal?,
                });
        }

        var result = new Dictionary<string, List<PromisePlan>>(StringComparer.Ordinal);
        foreach (var kv in byContact)
        {
            string gKey = keyOf[kv.Key];
            if (!result.TryGetValue(gKey, out var list)) result[gKey] = list = new List<PromisePlan>();
            list.Add(kv.Value);
        }
        return result;
    }

    /// <summary>Payments (credits, including reversals as negatives) received this term, by student.</summary>
    private Dictionary<string, List<PaymentFact>> LoadTermPayments(string semester)
    {
        var map = new Dictionary<string, List<PaymentFact>>(StringComparer.OrdinalIgnoreCase);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            SELECT StudentNumber, DateOfPayment, Credit
            FROM FeesPayment
            WHERE SemesterId = @semester AND ISNULL(Credit, 0) <> 0 AND DateOfPayment IS NOT NULL", conn);
        cmd.Parameters.Add("@semester", SqlDbType.VarChar, 50).Value = semester;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            string sn = rdr["StudentNumber"]?.ToString() ?? "";
            if (!map.TryGetValue(sn, out var list)) map[sn] = list = new List<PaymentFact>();
            list.Add(new PaymentFact
            {
                StudentNumber = sn,
                Date          = Convert.ToDateTime(rdr["DateOfPayment"]),
                Amount        = Convert.ToDecimal(rdr["Credit"]),
            });
        }
        return map;
    }

    /// <summary>Families that have chosen their own SMS style (everyone else uses the school default).</summary>
    private Dictionary<string, SmsStyle> LoadSmsStyles()
    {
        var map = new Dictionary<string, SmsStyle>(StringComparer.Ordinal);
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand("SELECT GuardianKey, SmsStyle FROM tbl_FeesGuardianPrefs", conn);
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            map[rdr.GetString(0).Trim()] = FamilySms.ParseStyle(rdr.GetString(1));
        return map;
    }

    /// <summary>Remember how a family wants its fee SMS.</summary>
    public void SetGuardianSmsStyle(string guardianKey, SmsStyle style, string user)
    {
        if (string.IsNullOrWhiteSpace(guardianKey))
            throw new ArgumentException("Cannot save an SMS style without a guardian key.", nameof(guardianKey));
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            IF EXISTS (SELECT 1 FROM tbl_FeesGuardianPrefs WHERE GuardianKey = @gk)
                UPDATE tbl_FeesGuardianPrefs
                   SET SmsStyle = @style, UpdatedBy = @user, UpdatedAt = GETDATE()
                 WHERE GuardianKey = @gk
            ELSE
                INSERT INTO tbl_FeesGuardianPrefs (GuardianKey, SmsStyle, UpdatedBy)
                VALUES (@gk, @style, @user)", conn);
        cmd.Parameters.Add("@gk",    SqlDbType.VarChar, 50).Value = guardianKey.Trim();
        cmd.Parameters.Add("@style", SqlDbType.VarChar, 20).Value = style.ToString();
        cmd.Parameters.Add("@user",  SqlDbType.VarChar, 50).Value = user ?? "";
        cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Today's follow-up list: everyone who needs chasing today plus everyone already worked
    /// today. Ordered so the next family to call is always at the top: not yet called first,
    /// then those to try again, then those finished; most urgent first within each.
    /// </summary>
    public List<GuardianWorklistRow> GetDailyWorklist(decimal minBalance = 0)
    {
        var settings = GetSettings();
        var all      = GetGuardianWorklist("", minBalance, settings);
        var today    = DateTime.Today;
        bool nearDeadline = IsNearDeadline(settings, today);

        return all
            .Where(g => DailyListLogic.IsOnDailyList(g, today, nearDeadline, settings.PartialPromiseCoverageThreshold))
            .OrderBy(g => (int)g.TodayStatus)
            .ThenByDescending(g => g.UrgencyScore)   // F4: same ranking as the guardian list
            .ThenByDescending(g => g.TotalBalance)
            .ToList();
    }

    // F6: within PromiseResurfaceDays of term end, stop hiding partially-covered promises so
    // the uncovered remainder gets worked before the deadline.
    private static bool IsNearDeadline(FeesFollowUpSettings settings, DateTime today)
        => settings.TermEndDate.HasValue
           && (settings.TermEndDate.Value.Date - today).TotalDays <= settings.PromiseResurfaceDays;

    public List<StudentWorklistRow> GetStudentWorklist(string classFilter = "", decimal minBalance = 0)
    {
        var studentSettings = GetSettings();
        // With no min-balance filter, list every currently-enrolled student (incl. nil/credit
        // balances); an explicit min-balance still filters to those owing more than it.
        var guardianRows = GetGuardianWorklist(classFilter, minBalance, studentSettings, includeAllEnrolled: minBalance == 0m);
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

        var remByStudent = GetReminderSummaryByStudent(GetWorkingSemester());
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
        string currentSemester = GetWorkingSemester();
        string prevSemester    = GetPreviousSemesterId(currentSemester);

        var all      = GetGuardianWorklist("", 0, settings);                              // families owing
        var enrolled = GetGuardianWorklist("", 0, settings, includeAllEnrolled: true);   // every family, for class totals
        var totals = GetDashboardTotals(currentSemester, prevSemester);
        var today  = DateTime.Today;
        bool termDatesConfigured = settings.TermStartDate.HasValue && settings.TermEndDate.HasValue;
        double termProgress = FeesUrgency.TermProgress(today, settings.TermStartDate, settings.TermEndDate);

        // Same membership rule as the daily list itself, so the tile and the list always agree.
        bool nearDeadline = IsNearDeadline(settings, today);
        var daily = all.Where(g => DailyListLogic.IsOnDailyList(
            g, today, nearDeadline, settings.PartialPromiseCoverageThreshold)).ToList();
        var progress = DailyListLogic.Progress(daily);

        int belowPacingCount = all.Count(g => g.PacingGap > 0);
        var (termWeek, totalTermWeeks) = FeesTerm.WeekOfTerm(today, settings.TermStartDate, settings.TermEndDate);

        var data = new DashboardData
        {
            TotalOutstanding          = all.Sum(g => g.TotalBalance),  // positive balances only
            TotalPayable              = totals.TotalPayable,            // all students, matches tracking sheet
            TotalCollected            = totals.TotalPaid,               // all students
            CollectedThisWeek         = totals.CollectedThisWeek,
            TotalGuardiansWithBalance = all.Count,
            DailyListTotal            = progress.Total,
            DailyListContacted        = progress.Done,
            DailyListTried            = progress.Tried,
            BrokenPromiseCount        = all.Count(g => g.Tier == PriorityTier.BrokenPromise),
            ActivePromiseCount        = all.Count(g => g.Promise != null && g.Promise.HasActive),
            TotalEnrolled      = totals.TotalEnrolled,
            NilBalanceStudents = totals.NilBalance,
            ZeroPaidStudents   = totals.ZeroPaid,
            BelowPacingCount   = belowPacingCount,
            CurrentTermWeek    = termWeek,
            TotalTermWeeks     = totalTermWeeks,
            TermDatesConfigured   = termDatesConfigured,
            TermProgress          = termProgress,
            CollectionGoalPercent = (decimal)(settings.CollectionGoal * 100.0),
            TermName              = FeesTerm.DisplayName(currentSemester),
            TermDatesNeedSetting  = settings.TermDatesNeedSetting,
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
            ByClass      = FeesDashboardMath.ByClass(enrolled.SelectMany(g => g.Students)),
            Promises     = FeesDashboardMath.Pipeline(all, today),
            TeamActivity = GetTeamActivity(currentSemester, today),
        };

        if (termDatesConfigured)
            data.WeeklyTrend = FeesDashboardMath.WeeklyTrend(
                LoadTermPayments(currentSemester).Values.SelectMany(v => v),
                settings.TermStartDate.Value, settings.TermEndDate.Value, today,
                totals.TotalPayable, settings.CollectionGoal);

        var (sentToday, sentThisWeek) = GetReminderCounts(today);
        data.RemindersSentToday    = sentToday;
        data.RemindersSentThisWeek = sentThisWeek;
        data.LastAutoReminderRun   = GetLastAutoRun()?.StartedAt;
        data.AutoRemindersEnabled  = settings.AutoRemindersEnabled;
        data.AutoReminderTime      = settings.AutoReminderTime;
        return data;
    }

    // Sunday on/before the given day (the school week runs Sun–Sat, as on the other tiles).
    private static DateTime WeekStart(DateTime day) => day.Date.AddDays(-(int)day.DayOfWeek);

    /// <summary>What each officer has logged today and this week (current term).</summary>
    private List<OfficerActivityRow> GetTeamActivity(string semester, DateTime today)
    {
        var rows = new List<OfficerActivityRow>();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            SELECT ISNULL(NULLIF(LTRIM(RTRIM(LoggedBy)), ''), '(unknown)') AS Officer,
                   SUM(CASE WHEN ContactDate >= @today THEN 1 ELSE 0 END) AS ContactsToday,
                   COUNT(*) AS ContactsThisWeek,
                   SUM(CASE WHEN Outcome IN ('Contacted', 'Promised', 'Refused') THEN 1 ELSE 0 END) AS ReachedThisWeek,
                   SUM(CASE WHEN Outcome = 'Promised' THEN 1 ELSE 0 END) AS PromisesThisWeek,
                   ISNULL(SUM(CASE WHEN Outcome = 'Promised' THEN PromiseAmount ELSE 0 END), 0) AS PromisedThisWeek
            FROM tbl_FeesContactLog
            WHERE SemesterId = @semester
              AND ContactDate >= @weekStart AND ContactDate < @tomorrow
            GROUP BY ISNULL(NULLIF(LTRIM(RTRIM(LoggedBy)), ''), '(unknown)')
            ORDER BY COUNT(*) DESC", conn);
        cmd.Parameters.Add("@semester",  SqlDbType.VarChar, 50).Value = semester;
        cmd.Parameters.Add("@today",     SqlDbType.DateTime).Value = today;
        cmd.Parameters.Add("@tomorrow",  SqlDbType.DateTime).Value = today.AddDays(1);
        cmd.Parameters.Add("@weekStart", SqlDbType.DateTime).Value = WeekStart(today);
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            rows.Add(new OfficerActivityRow
            {
                Officer          = rdr["Officer"].ToString(),
                ContactsToday    = Convert.ToInt32(rdr["ContactsToday"]),
                ContactsThisWeek = Convert.ToInt32(rdr["ContactsThisWeek"]),
                ReachedThisWeek  = Convert.ToInt32(rdr["ReachedThisWeek"]),
                PromisesThisWeek = Convert.ToInt32(rdr["PromisesThisWeek"]),
                PromisedThisWeek = Convert.ToDecimal(rdr["PromisedThisWeek"]),
            });
        return rows;
    }

    private (int today, int thisWeek) GetReminderCounts(DateTime today)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            SELECT ISNULL(SUM(CASE WHEN SentAt >= @today THEN 1 ELSE 0 END), 0), COUNT(*)
            FROM tbl_SmsReminderLog
            WHERE SentAt >= @weekStart AND SentAt < @tomorrow", conn);
        cmd.Parameters.Add("@today",     SqlDbType.DateTime).Value = today;
        cmd.Parameters.Add("@tomorrow",  SqlDbType.DateTime).Value = today.AddDays(1);
        cmd.Parameters.Add("@weekStart", SqlDbType.DateTime).Value = WeekStart(today);
        using var rdr = cmd.ExecuteReader();
        return rdr.Read() ? (Convert.ToInt32(rdr[0]), Convert.ToInt32(rdr[1])) : (0, 0);
    }

    public string GetSchoolName()
    {
        string raw;
        using (var conn = new SqlConnection(connectionString))
        using (var cmd  = new SqlCommand("SELECT TOP 1 SchoolName FROM SchoolDetails", conn))
        {
            conn.Open();
            raw = cmd.ExecuteScalar() as string ?? "";
        }
        if (DecryptSchoolName == null || raw == "") return raw;
        try
        {
            return DecryptSchoolName(raw);
        }
        catch (Exception ex)
        {
            // Some databases hold the name unencrypted: use it as stored.
            System.Diagnostics.Debug.WriteLine($"FeesFollowUpService: school name is not encrypted, using it as stored: {ex.Message}");
            return raw;
        }
    }

    /// <summary>The message template in force for a reminder type ("3DayBefore" | "DayOf" | "Overdue" | "General").</summary>
    public static string TemplateFor(string type, FeesFollowUpSettings s) => FamilySms.ResolveTemplate(type switch
    {
        "3DayBefore" => s.SmsTemplate2Day,
        "DayOf"      => s.SmsTemplateDayOf,
        "Overdue"    => s.SmsTemplateOverdue,
        "General"    => s.SmsTemplateGeneral,
        _            => "",
    }, type);

    // A callable number for the family: priority contact, else the alternative contact.
    private static string ResolvePhone(GuardianWorklistRow g)
        => SmsReminderLogic.NormalizePhone(g.GuardianContact) ?? SmsReminderLogic.NormalizePhone(g.Contact2);

    /// <summary>
    /// Promise reminders due today for every family, before removing ones already sent. Built
    /// from the evaluated promises, so a kept instalment or a replaced promise never produces a
    /// reminder, and each family's SMS style decides whether it gets one message or one per child.
    /// </summary>
    private List<ReminderItem> PlanPromiseReminders(
        List<GuardianWorklistRow> rows, FeesFollowUpSettings settings, string school)
    {
        var today = DateTime.Today;
        var items = new List<ReminderItem>();
        foreach (var g in rows)
        {
            if (g.TotalBalance <= 0m) continue;
            string phone = ResolvePhone(g);
            if (phone == null) continue;   // no callable number

            foreach (var item in ReminderPlanner.Plan(g.GuardianContact, phone, g.Students, g.Promise, today))
            {
                item.Messages = FamilySms.Compose(g.SmsStyle, TemplateFor(item.ReminderType, settings),
                    item.ScopeStudents, item.PromiseDate, school, item.PromisedAmount, item.StudentNumber);
                if (item.Messages.Count == 0) continue;
                item.Message = string.Join(Environment.NewLine + Environment.NewLine, item.Messages);
                items.Add(item);
            }
        }
        return items;
    }

    public List<ReminderItem> GetRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        var planned = PlanPromiseReminders(GetGuardianWorklist("", 0, settings), settings, school);

        using var conn = new SqlConnection(connectionString);
        conn.Open();
        // Drop reminders whose every instalment has already been reminded for this type.
        return planned.Where(item => !AllComponentsSent(conn, item)).ToList();
    }

    private bool AllComponentsSent(SqlConnection conn, ReminderItem item)
        => item.Components != null && item.Components.Count > 0
            ? item.Components.All(c => AlreadySentReminder(conn, item.GuardianKey, c.StudentNumber, c.PromiseDate, item.ReminderType))
            : AlreadySentReminder(conn, item.GuardianKey, item.StudentNumber, item.PromiseDate, item.ReminderType);

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
                else if (AllComponentsSent(conn, item)) continue;

                // One SMS for a family-total guardian, one per child otherwise.
                var messages = item.Messages != null && item.Messages.Count > 0
                    ? item.Messages
                    : new List<string> { item.Message };
                int delivered = 0;
                foreach (string message in messages)
                {
                    if (SendSms == null)
                        throw new InvalidOperationException("No SMS gateway is configured for this service.");
                    if (SendSms(item.Phone, message, out string err))
                        delivered++;
                    else
                        result.Failures.Add($"{item.ReminderType} to {item.Phone} ({item.StudentName}): {err}");
                }
                if (delivered == 0) continue;

                if (item.ReminderType == "General")
                {
                    LogGeneralReminderSent(conn, item.GuardianKey);
                    result.GeneralCount++;
                }
                else
                {
                    // De-dup logging per instalment (or the item itself if it has no components).
                    if (item.Components != null && item.Components.Count > 0)
                    {
                        foreach (var c in item.Components)
                            if (!AlreadySentReminder(conn, item.GuardianKey, c.StudentNumber, c.PromiseDate, item.ReminderType))
                                LogReminderSent(conn, item.GuardianKey, c.StudentNumber, c.PromiseDate, item.ReminderType);
                    }
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
            catch (Exception ex)
            {
                // The SMS may already have been delivered; record the logging/DB error but keep
                // processing the rest of the batch instead of aborting mid-send.
                result.Failures.Add($"{item.ReminderType} to {item.Phone} ({item.StudentName}): post-send logging error: {ex.Message}");
            }
        }
        return result;
    }

    // ── Automatic promise reminders (once a day) ──────────────────────────────

    public class AutoReminderRun
    {
        public DateTime  RunDate     { get; set; }
        public DateTime  StartedAt   { get; set; }
        public DateTime? FinishedAt  { get; set; }
        public string    StartedBy   { get; set; }
        public int       SentCount   { get; set; }
        public int       FailedCount { get; set; }
        public string    Note        { get; set; }
    }

    public bool HasAutoRunToday()
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand("SELECT COUNT(1) FROM tbl_FeesReminderRun WHERE RunDate = @d", conn);
        cmd.Parameters.Add("@d", SqlDbType.Date).Value = DateTime.Today;
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
    }

    public AutoReminderRun GetLastAutoRun()
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            SELECT TOP 1 RunDate, StartedAt, FinishedAt, StartedBy, SentCount, FailedCount, Note
            FROM tbl_FeesReminderRun ORDER BY RunDate DESC", conn);
        using var rdr = cmd.ExecuteReader();
        if (!rdr.Read()) return null;
        return new AutoReminderRun
        {
            RunDate     = Convert.ToDateTime(rdr["RunDate"]),
            StartedAt   = Convert.ToDateTime(rdr["StartedAt"]),
            FinishedAt  = rdr["FinishedAt"] as DateTime?,
            StartedBy   = rdr["StartedBy"]?.ToString(),
            SentCount   = Convert.ToInt32(rdr["SentCount"]),
            FailedCount = Convert.ToInt32(rdr["FailedCount"]),
            Note        = rdr["Note"] as string,
        };
    }

    /// <summary>True when automatic promise reminders are switched on and due to go out now.</summary>
    public bool IsAutomaticRunDue(DateTime now)
    {
        var settings = GetSettings();
        if (!settings.AutoRemindersEnabled) return false;
        return AutoReminderSchedule.IsDue(true, AutoReminderSchedule.ParseTime(settings.AutoReminderTime),
            now, HasAutoRunToday());
    }

    /// <summary>
    /// Send today's promise reminders without anyone pressing a button. Only promise reminders
    /// go out this way; balance reminders to families with no promise always need a person.
    /// Today's row in tbl_FeesReminderRun is claimed first (its primary key is the date), so
    /// when several PCs are open only one of them sends.
    /// </summary>
    public SmsReminderResult RunAutomaticReminders(string startedBy)
    {
        var result = new SmsReminderResult();
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using var claim = new SqlCommand(
                "INSERT INTO tbl_FeesReminderRun (RunDate, StartedBy, Machine) VALUES (@d, @by, @pc)", conn);
            claim.Parameters.Add("@d",  SqlDbType.Date).Value          = DateTime.Today;
            claim.Parameters.Add("@by", SqlDbType.VarChar, 50).Value   = string.IsNullOrWhiteSpace(startedBy) ? "(automatic)" : startedBy;
            claim.Parameters.Add("@pc", SqlDbType.VarChar, 100).Value  = Environment.MachineName;
            try
            {
                claim.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                result.AlreadyRanToday = true;   // another PC (or an earlier run) has today's run
                return result;
            }
        }

        string note;
        try
        {
            var items = GetRemindersPreview();
            result = ExecuteSendReminders(items);
            note = result.HasFailures
                ? string.Join(" | ", result.Failures)
                : items.Count == 0 ? "No promise reminders were due." : null;
        }
        catch (Exception ex)
        {
            RecordAutoRunFinished(result, $"Stopped early: {ex.Message}");
            throw new InvalidOperationException($"Automatic fee reminders stopped early: {ex.Message}", ex);
        }
        RecordAutoRunFinished(result, note);
        return result;
    }

    private void RecordAutoRunFinished(SmsReminderResult result, string note)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
            UPDATE tbl_FeesReminderRun
               SET FinishedAt = GETDATE(), SentCount = @sent, FailedCount = @failed, Note = @note
             WHERE RunDate = @d", conn);
        cmd.Parameters.Add("@d",      SqlDbType.Date).Value = DateTime.Today;
        cmd.Parameters.Add("@sent",   SqlDbType.Int).Value  = result.TotalSent;
        cmd.Parameters.Add("@failed", SqlDbType.Int).Value  = result.Failures.Count;
        cmd.Parameters.Add("@note",   SqlDbType.NVarChar, 1000).Value =
            string.IsNullOrEmpty(note) ? (object)DBNull.Value : (note.Length > 1000 ? note.Substring(0, 1000) : note);
        cmd.ExecuteNonQuery();
    }

    private static string ApplySmsTemplate(string template, decimal balance,
        string studentName, string classId, DateTime date, string school, decimal promisedAmount)
        => FamilySms.Render(template, studentName, classId, balance, date, school, promisedAmount);

    public string GetSmsTemplate(string key)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT SettingValue FROM tbl_FollowUpSettings WHERE SettingKey = @k", conn);
        cmd.Parameters.Add("@k", SqlDbType.NVarChar, 200).Value = key;
        return cmd.ExecuteScalar() as string ?? "";
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
        cmd.Parameters.Add("@gk",   SqlDbType.VarChar,  50).Value = guardianKey;
        cmd.Parameters.Add("@sn",   SqlDbType.NVarChar,  20).Value = (object)studentNumber ?? DBNull.Value;
        cmd.Parameters.Add("@pd",   SqlDbType.Date).Value           = promiseDate.Date;
        cmd.Parameters.Add("@type", SqlDbType.VarChar,  20).Value  = type;
        return (int)cmd.ExecuteScalar() > 0;
    }

    private void LogReminderSent(SqlConnection conn, string guardianKey,
        string studentNumber, DateTime promiseDate, string type)
    {
        using var cmd = new SqlCommand(
            "INSERT INTO tbl_SmsReminderLog (GuardianKey, StudentNumber, PromiseDate, ReminderType, SemesterId) " +
            "VALUES (@gk, @sn, @pd, @type, @sem)",
            conn);
        cmd.Parameters.Add("@gk",   SqlDbType.VarChar,  50).Value = guardianKey;
        cmd.Parameters.Add("@sn",   SqlDbType.NVarChar,  20).Value = (object)studentNumber ?? DBNull.Value;
        cmd.Parameters.Add("@pd",   SqlDbType.Date).Value           = promiseDate.Date;
        cmd.Parameters.Add("@type", SqlDbType.VarChar,  20).Value  = type;
        cmd.Parameters.Add("@sem",  SqlDbType.VarChar,  50).Value  = GetWorkingSemester();
        cmd.ExecuteNonQuery();
    }

    private void LogGeneralReminderSent(SqlConnection conn, string guardianKey)
    {
        // PromiseDate is NOT NULL, so a General reminder (which has no promise) stores today as
        // a placeholder to satisfy the column and the unique key. The cooldown in
        // GetGuardiansInGeneralCooldown is measured against SentAt (which defaults to GETDATE()),
        // never against this placeholder PromiseDate.
        LogReminderSent(conn, guardianKey, null, DateTime.Today, "General");
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

    // (count, lastSentAt, lastType) of reminders sent this term, keyed by GuardianKey.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummaryByGuardian(string semester)
        => GetReminderSummary("GuardianKey", semester);

    // (count, lastSentAt, lastType) of reminders sent this term, keyed by StudentNumber.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummaryByStudent(string semester)
        => GetReminderSummary("StudentNumber", semester);

    // Per-key reminder summary (count, most-recent SentAt, type of that most-recent row) for the
    // term, computed in a single pass. keyColumn is a fixed identifier ("GuardianKey" |
    // "StudentNumber"), never user input.
    private Dictionary<string, (int count, DateTime last, string type)>
        GetReminderSummary(string keyColumn, string semester)
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
                   AND SemesterId = @semester
               )
               SELECT K, Cnt, SentAt, ReminderType FROM Scoped WHERE rn = 1", conn);
        cmd.Parameters.Add("@semester", SqlDbType.VarChar, 50).Value = semester;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            map[rdr.GetString(0)] = (rdr.GetInt32(1), rdr.GetDateTime(2), rdr.IsDBNull(3) ? "" : rdr.GetString(3));
        return map;
    }

    public List<ReminderItem> GetBalanceRemindersPreview()
    {
        var settings = GetSettings();
        string school = GetSchoolName();
        string template = TemplateFor("General", settings);
        var today = DateTime.Today;

        var rows   = GetGuardianWorklist("", 0, settings);
        var cooled = GetGuardiansInGeneralCooldown(settings.GeneralReminderCooldownDays);

        // Cross-channel guard: never send a balance reminder to a guardian who is already getting a
        // promise reminder today (e.g. a just-broken promise still in the Overdue window).
        var promiseGuardians = new HashSet<string>(
            PlanPromiseReminders(rows, settings, school).Select(i => i.GuardianKey), StringComparer.Ordinal);

        var items = new List<ReminderItem>();
        foreach (var g in rows)
        {
            bool hasActivePromise = g.Promise != null && g.Promise.HasActive;
            if (!SmsReminderLogic.IsBalanceReminderEligible(g.Tier, g.TotalBalance, hasActivePromise)) continue;
            if (cooled.Contains(g.GuardianContact)) continue;
            if (promiseGuardians.Contains(g.GuardianContact)) continue;   // in today's promise-reminder queue — skip balance SMS

            string phone = ResolvePhone(g);
            if (phone == null) continue;   // no callable number

            var messages = FamilySms.Compose(g.SmsStyle, template, g.Students, today, school, 0m);
            if (messages.Count == 0) continue;

            items.Add(new ReminderItem
            {
                GuardianKey    = g.GuardianContact,
                Phone          = phone,
                StudentName    = FamilySms.JoinNames(g.Students.Select(s => s.FullName)),
                ClassId        = string.Join(", ", g.Students.Select(s => s.ClassId)
                                     .Where(c => !string.IsNullOrWhiteSpace(c)).Distinct()),
                Balance        = g.TotalBalance,
                PromisedAmount = 0m,
                PromiseDate    = today,   // placeholder; a General reminder carries no promise date (StudentNumber stays null too)
                ReminderType   = "General",
                Messages       = messages,
                Message        = string.Join(Environment.NewLine + Environment.NewLine, messages),
                ScopeStudents  = g.Students,
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
        EnsureSchemaReady();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(@"
        INSERT INTO tbl_FeesContactLog
          (StudentNumber, ContactDate, LoggedBy, Channel, Outcome, Note, PromiseDate, PromiseAmount, SemesterId)
        VALUES
          (@StudentNumber, @ContactDate, @LoggedBy, @Channel, @Outcome, @Note, @PromiseDate, @PromiseAmount, @SemesterId)",
            conn);
        cmd.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50).Value = entry.StudentNumber;
        cmd.Parameters.Add("@ContactDate", SqlDbType.DateTime).Value = entry.ContactDate;
        cmd.Parameters.Add("@LoggedBy", SqlDbType.VarChar, 50).Value = entry.LoggedBy ?? "";
        cmd.Parameters.Add("@Channel", SqlDbType.VarChar, 20).Value = entry.Channel.ToString();
        cmd.Parameters.Add("@Outcome", SqlDbType.VarChar, 20).Value = entry.Outcome.ToString();
        cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 500).Value = (object)entry.Note ?? DBNull.Value;
        cmd.Parameters.Add("@PromiseDate", SqlDbType.Date).Value = (object)entry.PromiseDate ?? DBNull.Value;
        cmd.Parameters.Add("@PromiseAmount", SqlDbType.Money).Value = (object)entry.PromiseAmount ?? DBNull.Value;
        cmd.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50).Value = GetWorkingSemester();
        cmd.ExecuteNonQuery();
    }

    // A promise is for one child only when a student is named on it; otherwise the whole family.
    private static object PromiseScopeOf(FeesContactLog entry)
        => entry.Outcome != ContactOutcome.Promised ? (object)DBNull.Value
         : string.IsNullOrWhiteSpace(entry.StudentNumber) ? "Family" : "Student";

    // The contact row carries a summary of the plan (first date, total when every part has an
    // amount) so older screens and exports still show something sensible.
    private static void SummarisePlanOnEntry(FeesContactLog entry, IList<PromiseInstalment> instalments)
    {
        if (entry.Outcome != ContactOutcome.Promised)
        {
            entry.PromiseDate   = null;
            entry.PromiseAmount = null;
            return;
        }
        if (instalments == null || instalments.Count == 0) return;   // caller set PromiseDate/Amount directly
        entry.PromiseDate   = instalments.Min(i => i.DueDate).Date;
        entry.PromiseAmount = instalments.All(i => i.Amount.HasValue && i.Amount.Value > 0m)
            ? instalments.Sum(i => i.Amount.Value) : (decimal?)null;
    }

    private static void WriteInstalments(SqlConnection conn, SqlTransaction tx, int contactId,
        FeesContactLog entry, IList<PromiseInstalment> instalments)
    {
        using (var del = new SqlCommand("DELETE FROM tbl_FeesPromiseInstalment WHERE ContactId = @id", conn, tx))
        {
            del.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
            del.ExecuteNonQuery();
        }
        if (entry.Outcome != ContactOutcome.Promised) return;

        var parts = instalments != null && instalments.Count > 0
            ? instalments
            : entry.PromiseDate.HasValue
                ? new List<PromiseInstalment> { new PromiseInstalment { DueDate = entry.PromiseDate.Value, Amount = entry.PromiseAmount } }
                : new List<PromiseInstalment>();

        foreach (var part in parts)
        {
            using var ins = new SqlCommand(
                "INSERT INTO tbl_FeesPromiseInstalment (ContactId, DueDate, Amount) VALUES (@id, @due, @amt)", conn, tx);
            ins.Parameters.Add("@id",  SqlDbType.Int).Value   = contactId;
            ins.Parameters.Add("@due", SqlDbType.Date).Value  = part.DueDate.Date;
            ins.Parameters.Add("@amt", SqlDbType.Money).Value =
                part.Amount.HasValue && part.Amount.Value > 0m ? (object)part.Amount.Value : DBNull.Value;
            ins.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Log an interaction with a guardian family in the current term. For a promise, pass the
    /// dated instalments; leave entry.StudentNumber blank for a whole-family promise or set it
    /// to the one child the promise is for. Returns the new ContactId.
    /// </summary>
    public int LogGuardianContact(string guardianKey, FeesContactLog entry,
        IList<PromiseInstalment> instalments = null)
    {
        EnsureSchemaReady();
        SummarisePlanOnEntry(entry, instalments);

        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            int contactId;
            using (var cmd = new SqlCommand(@"
            INSERT INTO tbl_FeesContactLog
              (StudentNumber, GuardianKey, ContactDate, LoggedBy, Channel, Outcome, Note,
               PromiseDate, PromiseAmount, SemesterId, PromiseScope)
            OUTPUT INSERTED.ContactId
            VALUES
              (@StudentNumber, @GuardianKey, @ContactDate, @LoggedBy, @Channel, @Outcome, @Note,
               @PromiseDate, @PromiseAmount, @SemesterId, @PromiseScope)", conn, tx))
            {
                cmd.Parameters.Add("@StudentNumber", SqlDbType.VarChar,   50).Value = entry.StudentNumber ?? "";
                cmd.Parameters.Add("@GuardianKey",   SqlDbType.VarChar,   50).Value = (object)guardianKey ?? DBNull.Value;
                cmd.Parameters.Add("@ContactDate",   SqlDbType.DateTime      ).Value = entry.ContactDate;
                cmd.Parameters.Add("@LoggedBy",      SqlDbType.VarChar,   50).Value = entry.LoggedBy ?? "";
                cmd.Parameters.Add("@Channel",       SqlDbType.VarChar,   20).Value = entry.Channel.ToString();
                cmd.Parameters.Add("@Outcome",       SqlDbType.VarChar,   20).Value = entry.Outcome.ToString();
                cmd.Parameters.Add("@Note",          SqlDbType.NVarChar, 500).Value = (object)entry.Note ?? DBNull.Value;
                cmd.Parameters.Add("@PromiseDate",   SqlDbType.Date          ).Value = (object)entry.PromiseDate ?? DBNull.Value;
                cmd.Parameters.Add("@PromiseAmount", SqlDbType.Money         ).Value = (object)entry.PromiseAmount ?? DBNull.Value;
                cmd.Parameters.Add("@SemesterId",    SqlDbType.VarChar,   50).Value = GetWorkingSemester();
                cmd.Parameters.Add("@PromiseScope",  SqlDbType.VarChar,   10).Value = PromiseScopeOf(entry);
                contactId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            WriteInstalments(conn, tx, contactId, entry, instalments);
            tx.Commit();
            return contactId;
        }
        catch (Exception ex)
        {
            tx.Rollback();
            throw new InvalidOperationException(
                $"Could not save the interaction for guardian {guardianKey}: {ex.Message}", ex);
        }
    }

    public void DeleteContact(int contactId)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        // Instalments go with it (ON DELETE CASCADE).
        using var cmd = new SqlCommand(
            "DELETE FROM tbl_FeesContactLog WHERE ContactId = @id", conn);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
        cmd.ExecuteNonQuery();
    }

    public void UpdateContact(FeesContactLog entry, IList<PromiseInstalment> instalments = null)
    {
        EnsureSchemaReady();
        SummarisePlanOnEntry(entry, instalments);

        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            using (var cmd = new SqlCommand(@"
            UPDATE tbl_FeesContactLog
            SET ContactDate   = @ContactDate,
                Channel       = @Channel,
                Outcome       = @Outcome,
                Note          = @Note,
                StudentNumber = @StudentNumber,
                PromiseDate   = @PromiseDate,
                PromiseAmount = @PromiseAmount,
                PromiseScope  = @PromiseScope
            WHERE ContactId = @ContactId", conn, tx))
            {
                cmd.Parameters.Add("@ContactDate",   SqlDbType.DateTime).Value = entry.ContactDate;
                cmd.Parameters.Add("@Channel",       SqlDbType.VarChar,  20).Value = entry.Channel.ToString();
                cmd.Parameters.Add("@Outcome",       SqlDbType.VarChar,  20).Value = entry.Outcome.ToString();
                cmd.Parameters.Add("@Note",          SqlDbType.NVarChar, 500).Value = (object)entry.Note ?? DBNull.Value;
                cmd.Parameters.Add("@StudentNumber", SqlDbType.VarChar,  50).Value = entry.StudentNumber ?? "";
                cmd.Parameters.Add("@PromiseDate",   SqlDbType.Date).Value = (object)entry.PromiseDate ?? DBNull.Value;
                cmd.Parameters.Add("@PromiseAmount", SqlDbType.Money).Value = (object)entry.PromiseAmount ?? DBNull.Value;
                cmd.Parameters.Add("@PromiseScope",  SqlDbType.VarChar,  10).Value = PromiseScopeOf(entry);
                cmd.Parameters.Add("@ContactId",     SqlDbType.Int).Value = entry.ContactId;
                cmd.ExecuteNonQuery();
            }
            WriteInstalments(conn, tx, entry.ContactId, entry, instalments);
            tx.Commit();
        }
        catch (Exception ex)
        {
            tx.Rollback();
            throw new InvalidOperationException(
                $"Could not update interaction {entry.ContactId}: {ex.Message}", ex);
        }
    }

    /// <summary>The instalments stored for one logged promise (empty for a promise logged before instalments existed).</summary>
    public List<PromiseInstalment> GetInstalments(int contactId)
    {
        var list = new List<PromiseInstalment>();
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(
            "SELECT DueDate, Amount FROM tbl_FeesPromiseInstalment WHERE ContactId = @id ORDER BY DueDate", conn);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
            list.Add(new PromiseInstalment
            {
                DueDate = Convert.ToDateTime(rdr["DueDate"]),
                Amount  = rdr["Amount"] as decimal?,
            });
        return list;
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

    // "15 Nov 2026 - 200,000; 30 Nov 2026 - 200,000" for a logged promise; falls back to the
    // single PromiseDate / PromiseAmount on rows logged before instalments existed.
    private const string PaymentPlanSql = @"
               ISNULL(STUFF((SELECT '; ' + CONVERT(varchar(11), pi.DueDate, 106)
                                    + ISNULL(' - ' + REPLACE(CONVERT(varchar(30), pi.Amount, 1), '.00', ''), '')
                             FROM tbl_FeesPromiseInstalment pi
                             WHERE pi.ContactId = cl.ContactId
                             ORDER BY pi.DueDate
                             FOR XML PATH('')), 1, 2, ''),
                      CASE WHEN cl.PromiseDate IS NULL THEN NULL
                           ELSE CONVERT(varchar(11), cl.PromiseDate, 106)
                                + ISNULL(' - ' + REPLACE(CONVERT(varchar(30), cl.PromiseAmount, 1), '.00', ''), '')
                      END)";

    /// <summary>
    /// Every interaction with a guardian family, newest first, across all terms. The Term column
    /// says which term each belongs to; only the current term's entries drive the lists.
    /// </summary>
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
               cl.StudentNumber, cl.PromiseScope, cl.SemesterId,
               s.fullName AS StudentName,
               {PaymentPlanSql} AS PaymentPlan
        FROM tbl_FeesContactLog cl
        LEFT JOIN tbl_Stud s ON s.StudentNumber = cl.StudentNumber
        WHERE cl.GuardianKey = @guardianKey
           OR (cl.GuardianKey IS NULL AND cl.StudentNumber IN ({inList}))
        ORDER BY cl.ContactDate DESC, cl.ContactId DESC", conn);

        da.SelectCommand.Parameters.Add("@guardianKey", SqlDbType.VarChar, 50).Value = guardianKey;
        for (int i = 0; i < nums.Count; i++)
            da.SelectCommand.Parameters.Add($"@sn{i}", SqlDbType.VarChar, 50).Value = nums[i];

        da.Fill(dt);
        AddTermColumn(dt);
        return dt;
    }

    // Adds a readable "Term" column from SemesterId; rows from before term stamping read "Earlier terms".
    private static void AddTermColumn(DataTable dt)
    {
        dt.Columns.Add("Term", typeof(string));
        foreach (DataRow row in dt.Rows)
        {
            string sem = row["SemesterId"] as string;
            row["Term"] = string.IsNullOrWhiteSpace(sem) ? "Earlier terms" : FeesTerm.DisplayName(sem);
        }
    }

    /// <summary>
    /// The interactions report: every interaction logged within [fromInclusive, toInclusive]
    /// (whole days), newest first, with who was contacted, their phone, children and classes,
    /// the response, any payment plan, and the family's balance today. Print / export source.
    /// </summary>
    public DataTable GetInteractionsReport(DateTime fromInclusive, DateTime toInclusive)
    {
        EnsureSchemaReady();
        var dt = new DataTable();
        using (var conn = new SqlConnection(connectionString))
        using (var da = new SqlDataAdapter($@"
        ;WITH Stud AS (
            SELECT s.StudentNumber, s.fullName, s.ClassId, s.Guardian, s.GuardianRelation,
                   {GuardianKeySql} AS GuardianKey
            FROM tbl_Stud s
        ),
        Fam AS (
            SELECT f.GuardianKey,
                   MAX(ISNULL(f.Guardian, ''))         AS Guardian,
                   MAX(ISNULL(f.GuardianRelation, '')) AS GuardianRelation,
                   STUFF((SELECT ', ' + x.fullName FROM Stud x WHERE x.GuardianKey = f.GuardianKey
                          ORDER BY x.fullName FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS Students,
                   STUFF((SELECT DISTINCT ', ' + x.ClassId FROM Stud x
                          WHERE x.GuardianKey = f.GuardianKey AND ISNULL(x.ClassId, '') <> ''
                          FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 2, '') AS Classes
            FROM Stud f
            GROUP BY f.GuardianKey
        )
        SELECT cl.ContactId,
               cl.ContactDate,
               cl.SemesterId,
               COALESCE(cl.GuardianKey, one.GuardianKey)                       AS GuardianKey,
               CASE WHEN LTRIM(RTRIM(ISNULL(COALESCE(fam.GuardianRelation, one.GuardianRelation), ''))) = ''
                    THEN ISNULL(COALESCE(fam.Guardian, one.Guardian), '')
                    ELSE ISNULL(COALESCE(fam.Guardian, one.Guardian), '') + ' ('
                         + COALESCE(fam.GuardianRelation, one.GuardianRelation) + ')'
               END                                                             AS GuardianDisplay,
               CASE WHEN COALESCE(cl.GuardianKey, one.GuardianKey) LIKE 'NOCONTACT-%' THEN ''
                    ELSE COALESCE(cl.GuardianKey, one.GuardianKey) END         AS Phone,
               CASE WHEN one.StudentNumber IS NOT NULL AND (cl.GuardianKey IS NULL OR cl.PromiseScope = 'Student')
                    THEN one.fullName ELSE fam.Students END                    AS StudentName,
               CASE WHEN one.StudentNumber IS NOT NULL AND (cl.GuardianKey IS NULL OR cl.PromiseScope = 'Student')
                    THEN one.ClassId ELSE fam.Classes END                      AS Classes,
               cl.Channel,
               cl.Outcome,
               cl.Note,
               cl.PromiseDate,
               cl.PromiseAmount,
               {PaymentPlanSql}                                                AS PaymentPlan,
               cl.LoggedBy
        FROM tbl_FeesContactLog cl
        LEFT JOIN Stud one ON one.StudentNumber = NULLIF(cl.StudentNumber, '')
        LEFT JOIN Fam  fam ON fam.GuardianKey = COALESCE(cl.GuardianKey, one.GuardianKey)
        WHERE cl.ContactDate >= @from AND cl.ContactDate < @toExclusive
        ORDER BY cl.ContactDate DESC, cl.ContactId DESC", conn))
        {
            da.SelectCommand.Parameters.Add("@from", SqlDbType.DateTime).Value = fromInclusive.Date;
            da.SelectCommand.Parameters.Add("@toExclusive", SqlDbType.DateTime).Value =
                toInclusive.Date.AddDays(1);
            da.Fill(dt);
        }
        AddTermColumn(dt);

        // Balance today for each family, so the printout shows where things stand now.
        var balanceByGuardian = GetGuardianWorklist("", 0, null, includeAllEnrolled: true)
            .ToDictionary(g => g.GuardianContact, g => g.TotalBalance, StringComparer.Ordinal);
        dt.Columns.Add("FamilyBalance", typeof(decimal));
        foreach (DataRow row in dt.Rows)
        {
            string key = (row["GuardianKey"] as string ?? "").Trim();
            row["FamilyBalance"] = balanceByGuardian.TryGetValue(key, out decimal bal) ? (object)bal : DBNull.Value;
        }
        return dt;
    }

    /// <summary>
    /// The promises / payment plans report for the current term: one row per instalment of every
    /// promise still in force, with what was promised, what has been paid since, and whether it
    /// was kept, is still pending, or was missed.
    /// </summary>
    public List<PromiseReportRow> GetPromiseReport()
    {
        var rows = new List<PromiseReportRow>();
        foreach (var g in GetGuardianWorklist("", 0, null, includeAllEnrolled: true))
        {
            if (g.Promise == null || !g.Promise.HasPromise) continue;
            foreach (var plan in g.Promise.ActivePlans)
            {
                string promiseFor = plan.IsFamily
                    ? "Whole family"
                    : g.Students.FirstOrDefault(s => string.Equals(s.StudentNumber, plan.StudentNumber,
                          StringComparison.OrdinalIgnoreCase))?.FullName ?? plan.StudentNumber;
                foreach (var inst in plan.Instalments.OrderBy(i => i.DueDate))
                    rows.Add(new PromiseReportRow
                    {
                        GuardianLabel     = g.GuardianLabel,
                        Phone             = g.IsUnreachable ? "" : g.GuardianContact,
                        Students          = g.StudentNames,
                        Classes           = string.Join(", ", g.Students.Select(s => s.ClassId)
                                                .Where(c => !string.IsNullOrWhiteSpace(c)).Distinct()),
                        PromiseFor        = promiseFor,
                        LoggedOn          = plan.LoggedAt,
                        LoggedBy          = plan.LoggedBy,
                        DueDate           = inst.DueDate,
                        AmountPromised    = inst.AmountDue,
                        AmountPaid        = inst.AmountDue - inst.AmountOutstanding,
                        AmountOutstanding = inst.AmountOutstanding,
                        Status            = inst.Status.ToString(),
                        FamilyBalance     = g.TotalBalance,
                    });
            }
        }
        return rows.OrderBy(r => r.DueDate).ThenBy(r => r.GuardianLabel).ToList();
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
