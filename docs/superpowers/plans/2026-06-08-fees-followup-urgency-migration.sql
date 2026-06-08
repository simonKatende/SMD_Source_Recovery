-- Fees Follow-up deadline-aware urgency overhaul (2026-06-08)
-- Run once against the school database before deploying the rebuilt IXtreme.exe.

-- 1. New settings keys (defaults; the app also upserts these via SaveSettings).
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'CollectionGoal')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('CollectionGoal', '0.98');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'CriticalShortfallPoints')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('CriticalShortfallPoints', '25');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'CallRequiredWindowDays')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('CallRequiredWindowDays', '14');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'PromiseResurfaceDays')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('PromiseResurfaceDays', '14');
IF NOT EXISTS (SELECT 1 FROM tbl_FollowUpSettings WHERE SettingKey = 'GeneralReminderCooldownDays')
    INSERT INTO tbl_FollowUpSettings (SettingKey, SettingValue) VALUES ('GeneralReminderCooldownDays', '7');
-- SmsTemplateGeneral is left unset so the app falls back to the built-in DefaultGeneral text.

-- 2. Retired keys (FirstHalfMinPercent / SecondHalfMinPercent) are now dead; safe to remove.
DELETE FROM tbl_FollowUpSettings WHERE SettingKey IN ('FirstHalfMinPercent', 'SecondHalfMinPercent');

-- 3. CallRequired windowing relies on tbl_SmsReminderLog.SentAt. It already exists
--    (notes/migrations/2026-05-30_add_SmsReminderLog.sql defines it with DEFAULT GETDATE()).
--    This guard is a safety net for older databases that predate that migration.
IF NOT EXISTS (SELECT 1 FROM sys.columns
              WHERE object_id = OBJECT_ID('tbl_SmsReminderLog') AND name = 'SentAt')
    ALTER TABLE tbl_SmsReminderLog ADD SentAt DATETIME NOT NULL CONSTRAINT DF_SmsReminderLog_SentAt DEFAULT GETDATE();
