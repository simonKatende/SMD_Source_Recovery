-- notes/migrations/2026-05-27_create_tbl_FeesContactLog.sql
-- Run manually against the school's SMD SQL Server database before the
-- first launch of the Fees Follow-up ribbon tab. Idempotent (uses IF NOT EXISTS).
-- Reverse: DROP TABLE tbl_FeesContactLog; DROP TABLE tbl_FollowUpSettings;

IF OBJECT_ID('dbo.tbl_FeesContactLog', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tbl_FeesContactLog (
        ContactId      INT IDENTITY(1,1) PRIMARY KEY,
        StudentNumber  VARCHAR(50)   NOT NULL,
        ContactDate    DATETIME      NOT NULL DEFAULT GETDATE(),
        LoggedBy       VARCHAR(50)   NOT NULL,
        Channel        VARCHAR(20)   NOT NULL,
        Outcome        VARCHAR(20)   NOT NULL,
        Note           NVARCHAR(500)     NULL,
        PromiseDate    DATE              NULL,
        PromiseAmount  MONEY             NULL
    );

    CREATE INDEX IX_FeesContactLog_Student
        ON dbo.tbl_FeesContactLog (StudentNumber, ContactDate DESC);
END;

IF OBJECT_ID('dbo.tbl_FollowUpSettings', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tbl_FollowUpSettings (
        SettingKey   VARCHAR(50)  NOT NULL PRIMARY KEY,
        SettingValue NVARCHAR(200)    NULL
    );

    INSERT INTO dbo.tbl_FollowUpSettings (SettingKey, SettingValue)
    VALUES ('StalenessThresholdDays', '7');
END;
