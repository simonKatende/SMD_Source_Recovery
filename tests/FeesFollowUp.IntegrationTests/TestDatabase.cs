// tests/FeesFollowUp.IntegrationTests/TestDatabase.cs
using System;
using System.Data.SqlClient;
using System.IO;

namespace FeesFollowUp.IntegrationTests;

/// Creates a throwaway database per test with the tables Fees Follow-up reads, in the shape
/// they had BEFORE the 2026-11-11 CRM migration, optionally applies that migration, and drops
/// the database on Dispose. Never touches a school database.
public sealed class TestDatabase : IDisposable
{
    private const string MasterConnection =
        "Server=localhost;Database=master;Integrated Security=true;TrustServerCertificate=true";

    public const string CurrentTerm  = "TermIII-2026";
    public const string PreviousTerm = "TermII-2026";

    public string Name { get; }
    public string ConnectionString { get; }

    /// First fees entry of the current term (billing day): three weeks ago.
    public static DateTime TermOpened => DateTime.Today.AddDays(-21);

    private TestDatabase(string name)
    {
        Name = name;
        ConnectionString =
            "Server=localhost;Database=" + name + ";Integrated Security=true;TrustServerCertificate=true";
    }

    public static TestDatabase Create(bool applyMigration = true)
    {
        var db = new TestDatabase("SMD_Test_" + Guid.NewGuid().ToString("N").Substring(0, 12));
        RunOnMaster("CREATE DATABASE [" + db.Name + "]");
        try
        {
            db.ApplyBaseSchema();
            if (applyMigration) db.ApplyMigration();
        }
        catch
        {
            db.Dispose();
            throw;
        }
        return db;
    }

    private void ApplyBaseSchema()
    {
        // Column shapes mirror the test school database as profiled on 2026-11-11.
        Execute(@"
CREATE TABLE dbo.tbl_Stud (
    StudentNumber    varchar(12)   NOT NULL PRIMARY KEY,
    fullName         varchar(50)   NULL,
    ClassId          varchar(8)    NULL,
    StudyStatus      varchar(1)    NULL,
    Guardian         varchar(50)   NULL,
    GuardianRelation nvarchar(100) NULL,
    Status           varchar(15)   NULL,
    StudentID        varchar(12)   NULL,
    PriorityContact  varchar(11)   NULL,
    OtherContact     varchar(11)   NULL
);
CREATE TABLE dbo.FeesPayment (
    PaymentId     bigint IDENTITY(1,1) NOT NULL PRIMARY KEY,
    StudentNumber varchar(12)  NULL,
    DateOfPayment datetime     NULL,
    SemesterId    varchar(18)  NULL,
    Particulars   varchar(25)  NULL,
    Debit         money        NULL,
    Credit        money        NULL,
    Balance       money        NULL
);
CREATE TABLE dbo.tbl_ActiveSemester (
    id       int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    semester varchar(12) NULL
);
CREATE TABLE dbo.SchoolDetails (
    DetailId   int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SchoolName varchar(500) NOT NULL
);
CREATE TABLE dbo.tbl_FeesContactLog (
    ContactId      INT IDENTITY(1,1) PRIMARY KEY,
    StudentNumber  VARCHAR(50)   NOT NULL,
    ContactDate    DATETIME      NOT NULL DEFAULT GETDATE(),
    LoggedBy       VARCHAR(50)   NOT NULL,
    Channel        VARCHAR(20)   NOT NULL,
    Outcome        VARCHAR(20)   NOT NULL,
    Note           NVARCHAR(500)     NULL,
    PromiseDate    DATE              NULL,
    PromiseAmount  MONEY             NULL,
    GuardianKey    VARCHAR(20)       NULL
);
CREATE INDEX IX_FeesContactLog_Student ON dbo.tbl_FeesContactLog (StudentNumber, ContactDate DESC);
CREATE TABLE dbo.tbl_FollowUpSettings (
    SettingKey   VARCHAR(50)  NOT NULL PRIMARY KEY,
    SettingValue NVARCHAR(200)    NULL
);
CREATE TABLE dbo.tbl_SmsReminderLog (
    Id            INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_SmsReminderLog PRIMARY KEY,
    GuardianKey   VARCHAR(50)  NOT NULL,
    PromiseDate   DATE         NOT NULL,
    ReminderType  VARCHAR(20)  NOT NULL,
    SentAt        DATETIME     NOT NULL CONSTRAINT DF_SmsReminderLog_SentAt DEFAULT GETDATE(),
    StudentNumber NVARCHAR(20) NULL,
    CONSTRAINT UQ_SmsReminderLog UNIQUE (GuardianKey, StudentNumber, PromiseDate, ReminderType)
);
INSERT INTO dbo.tbl_ActiveSemester (semester) VALUES ('" + CurrentTerm + @"');
INSERT INTO dbo.SchoolDetails (SchoolName) VALUES ('Test School');");
    }

    public void ApplyMigration()
    {
        string file = Path.Combine(FindMigrationsDirectory(), "2026-11-11_fees_followup_crm.sql");
        foreach (string batch in File.ReadAllText(file)
                     .Split(new[] { "\nGO", "\r\nGO" }, StringSplitOptions.None))
        {
            if (!string.IsNullOrWhiteSpace(batch)) Execute(batch);
        }
    }

    public static string FindMigrationsDirectory()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null)
        {
            string candidate = Path.Combine(dir.FullName, "notes", "migrations");
            if (Directory.Exists(candidate)) return candidate;
            dir = dir.Parent;
        }
        throw new DirectoryNotFoundException(
            "Could not locate notes/migrations above " + AppContext.BaseDirectory);
    }

    // ── Seeding helpers ───────────────────────────────────────────────────────

    public void AddStudent(string number, string name, string classId, string phone,
        string guardian = "Parent", string status = "Active")
    {
        Run(@"INSERT INTO dbo.tbl_Stud (StudentNumber, fullName, ClassId, StudyStatus, Guardian, GuardianRelation, Status, StudentID, PriorityContact)
              VALUES (@n, @name, @class, 'D', @g, 'Mother', @status, @n, @phone)",
            ("@n", number), ("@name", name), ("@class", classId), ("@g", guardian),
            ("@status", status), ("@phone", (object)phone ?? DBNull.Value));
    }

    /// A fees charge in the given term (defaults: current term, on the day the term opened).
    public void Bill(string student, decimal amount, string term = CurrentTerm, DateTime? on = null)
        => Run(@"INSERT INTO dbo.FeesPayment (StudentNumber, DateOfPayment, SemesterId, Particulars, Debit, Credit, Balance)
                 VALUES (@s, @d, @t, 'Fees', @a, 0, @a)",
            ("@s", student), ("@d", on ?? TermOpened), ("@t", term), ("@a", amount));

    public void Pay(string student, decimal amount, DateTime on, string term = CurrentTerm)
        => Run(@"INSERT INTO dbo.FeesPayment (StudentNumber, DateOfPayment, SemesterId, Particulars, Debit, Credit, Balance)
                 VALUES (@s, @d, @t, 'Fees', 0, @a, 0)",
            ("@s", student), ("@d", on.Date), ("@t", term), ("@a", amount));

    /// The closing balance row of the previous term (what is brought forward).
    public void BroughtForward(string student, decimal balance)
        => Run(@"INSERT INTO dbo.FeesPayment (StudentNumber, DateOfPayment, SemesterId, Particulars, Debit, Credit, Balance)
                 VALUES (@s, @d, @t, 'Fees', @a, 0, @a)",
            ("@s", student), ("@d", TermOpened.AddDays(-90)), ("@t", PreviousTerm), ("@a", balance));

    public void SetActiveTerm(string term) => Run("UPDATE dbo.tbl_ActiveSemester SET semester = @t", ("@t", term));

    // ── Plumbing ──────────────────────────────────────────────────────────────

    public void Run(string sql, params (string name, object value)[] parameters)
    {
        using var conn = new SqlConnection(ConnectionString);
        conn.Open();
        using var cmd = new SqlCommand(sql, conn) { CommandTimeout = 60 };
        foreach (var (name, value) in parameters) cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        cmd.ExecuteNonQuery();
    }

    public void Execute(string sql) => Run(sql);

    public T Scalar<T>(string sql)
    {
        using var conn = new SqlConnection(ConnectionString);
        conn.Open();
        using var cmd = new SqlCommand(sql, conn) { CommandTimeout = 60 };
        object value = cmd.ExecuteScalar();
        return value == null || value == DBNull.Value ? default : (T)Convert.ChangeType(value, typeof(T));
    }

    private static void RunOnMaster(string sql)
    {
        using var conn = new SqlConnection(MasterConnection);
        conn.Open();
        using var cmd = new SqlCommand(sql, conn) { CommandTimeout = 60 };
        cmd.ExecuteNonQuery();
    }

    public void Dispose()
    {
        SqlConnection.ClearAllPools();
        RunOnMaster("ALTER DATABASE [" + Name + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE [" + Name + "]");
    }
}
