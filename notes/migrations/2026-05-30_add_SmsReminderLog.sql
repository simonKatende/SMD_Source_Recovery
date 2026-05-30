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
