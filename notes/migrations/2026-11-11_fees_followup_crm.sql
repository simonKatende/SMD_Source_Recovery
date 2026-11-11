-- notes/migrations/2026-11-11_fees_followup_crm.sql
-- Fees Follow-up CRM overhaul. Run once against the school's SMD database BEFORE the first
-- launch of a build that contains the overhaul. Idempotent: safe to run again.
--
-- What it changes
--   1. tbl_FeesContactLog   + SemesterId   (which term an interaction belongs to)
--                           + PromiseScope ('Family' | 'Student'; NULL on old rows = Family)
--   2. tbl_SmsReminderLog   + SemesterId
--   3. tbl_FollowUpSettings   SettingValue widened 200 -> 1000 (SMS templates were being cut off)
--   4. tbl_FeesGuardianPrefs      (new) each family's SMS style
--   5. tbl_FeesPromiseInstalment  (new) dated instalments of a payment plan
--   6. tbl_FeesReminderRun        (new) one row per day the automatic reminders ran
--
-- It deletes nothing. The only existing rows it updates are interactions and reminder-log rows
-- dated on or after the first fees entry of the active term: those are stamped with that term.
-- Older rows keep SemesterId NULL and show as "Earlier terms" in history.
--
-- Reverse:
--   DROP TABLE tbl_FeesReminderRun; DROP TABLE tbl_FeesPromiseInstalment; DROP TABLE tbl_FeesGuardianPrefs;
--   ALTER TABLE tbl_SmsReminderLog DROP COLUMN SemesterId;
--   DROP INDEX IX_FeesContactLog_Term ON tbl_FeesContactLog;
--   ALTER TABLE tbl_FeesContactLog DROP COLUMN SemesterId, PromiseScope;

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

-- 1. Interactions: term + promise scope ------------------------------------------------------
IF COL_LENGTH('dbo.tbl_FeesContactLog', 'SemesterId') IS NULL
    ALTER TABLE dbo.tbl_FeesContactLog ADD SemesterId VARCHAR(50) NULL;
GO
IF COL_LENGTH('dbo.tbl_FeesContactLog', 'PromiseScope') IS NULL
    ALTER TABLE dbo.tbl_FeesContactLog ADD PromiseScope VARCHAR(10) NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = 'IX_FeesContactLog_Term' AND object_id = OBJECT_ID('dbo.tbl_FeesContactLog'))
    CREATE INDEX IX_FeesContactLog_Term
        ON dbo.tbl_FeesContactLog (SemesterId, GuardianKey, ContactDate DESC);
GO

-- 2. Reminder log: term ----------------------------------------------------------------------
IF COL_LENGTH('dbo.tbl_SmsReminderLog', 'SemesterId') IS NULL
    ALTER TABLE dbo.tbl_SmsReminderLog ADD SemesterId VARCHAR(50) NULL;
GO

-- Stamp rows that belong to the active term. The term is taken to have started on the date of
-- its first fees entry (billing or payment). Nothing is stamped if the active term has no
-- fees entries yet.
DECLARE @semester VARCHAR(50) = (SELECT TOP 1 semester FROM dbo.tbl_ActiveSemester);
DECLARE @termFirstEntry DATETIME =
    (SELECT MIN(DateOfPayment) FROM dbo.FeesPayment WHERE SemesterId = @semester);

IF @semester IS NOT NULL AND @termFirstEntry IS NOT NULL
BEGIN
    UPDATE dbo.tbl_FeesContactLog
       SET SemesterId = @semester
     WHERE SemesterId IS NULL AND ContactDate >= @termFirstEntry;

    UPDATE dbo.tbl_SmsReminderLog
       SET SemesterId = @semester
     WHERE SemesterId IS NULL AND SentAt >= @termFirstEntry;
END
GO

-- 3. Settings: room for full SMS templates -----------------------------------------------------
IF COL_LENGTH('dbo.tbl_FollowUpSettings', 'SettingValue') < 2000   -- nvarchar(200) reports 400 bytes
    ALTER TABLE dbo.tbl_FollowUpSettings ALTER COLUMN SettingValue NVARCHAR(1000) NULL;
GO

-- 4. Each family's SMS style -------------------------------------------------------------------
IF OBJECT_ID('dbo.tbl_FeesGuardianPrefs', 'U') IS NULL
    CREATE TABLE dbo.tbl_FeesGuardianPrefs (
        GuardianKey VARCHAR(50)  NOT NULL CONSTRAINT PK_FeesGuardianPrefs PRIMARY KEY,
        SmsStyle    VARCHAR(20)  NOT NULL,                 -- 'FamilyTotal' | 'PerChild'
        UpdatedBy   VARCHAR(50)  NOT NULL,
        UpdatedAt   DATETIME     NOT NULL CONSTRAINT DF_FeesGuardianPrefs_UpdatedAt DEFAULT GETDATE(),
        CONSTRAINT CK_FeesGuardianPrefs_SmsStyle CHECK (SmsStyle IN ('FamilyTotal', 'PerChild'))
    );
GO

-- 5. Payment-plan instalments ------------------------------------------------------------------
IF OBJECT_ID('dbo.tbl_FeesPromiseInstalment', 'U') IS NULL
    CREATE TABLE dbo.tbl_FeesPromiseInstalment (
        InstalmentId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_FeesPromiseInstalment PRIMARY KEY,
        ContactId    INT   NOT NULL
            CONSTRAINT FK_FeesPromiseInstalment_Contact
            REFERENCES dbo.tbl_FeesContactLog (ContactId) ON DELETE CASCADE,
        DueDate      DATE  NOT NULL,
        Amount       MONEY NULL,                           -- NULL = "clear the balance"
        CONSTRAINT UQ_FeesPromiseInstalment UNIQUE (ContactId, DueDate),
        CONSTRAINT CK_FeesPromiseInstalment_Amount CHECK (Amount IS NULL OR Amount > 0)
    );
GO

-- 6. Automatic reminder runs (one per day; the primary key stops two PCs sending twice) --------
IF OBJECT_ID('dbo.tbl_FeesReminderRun', 'U') IS NULL
    CREATE TABLE dbo.tbl_FeesReminderRun (
        RunDate     DATE          NOT NULL CONSTRAINT PK_FeesReminderRun PRIMARY KEY,
        StartedAt   DATETIME      NOT NULL CONSTRAINT DF_FeesReminderRun_StartedAt DEFAULT GETDATE(),
        FinishedAt  DATETIME      NULL,
        StartedBy   VARCHAR(50)   NOT NULL,
        Machine     VARCHAR(100)  NULL,
        SentCount   INT           NOT NULL CONSTRAINT DF_FeesReminderRun_Sent   DEFAULT 0,
        FailedCount INT           NOT NULL CONSTRAINT DF_FeesReminderRun_Failed DEFAULT 0,
        Note        NVARCHAR(1000) NULL
    );
GO
