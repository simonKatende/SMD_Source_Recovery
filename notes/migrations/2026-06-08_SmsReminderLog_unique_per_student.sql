-- 2026-06-08: Align tbl_SmsReminderLog uniqueness with the per-student dedup grain.
-- The 2026-05-31 SMS overhaul added the StudentNumber column for per-student dedup but left
-- UQ_SmsReminderLog at (GuardianKey, PromiseDate, ReminderType). When one guardian has two
-- students sharing a promise date + reminder type, the second per-student INSERT collides.
-- Recreate the constraint to include StudentNumber. The new key is strictly finer than the
-- old one, so any rows that satisfied the old constraint already satisfy the new one — no
-- data cleanup is required. Idempotent: safe to re-run.

-- 1. Ensure the StudentNumber column exists (added by the 2026-05-31 SMS overhaul; guard for older DBs).
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID('tbl_SmsReminderLog') AND name = 'StudentNumber')
    ALTER TABLE tbl_SmsReminderLog ADD StudentNumber NVARCHAR(20) NULL;
GO

-- 2. Drop the old guardian-grained unique constraint if present.
IF EXISTS (SELECT 1 FROM sys.key_constraints
           WHERE name = 'UQ_SmsReminderLog' AND parent_object_id = OBJECT_ID('tbl_SmsReminderLog'))
    ALTER TABLE tbl_SmsReminderLog DROP CONSTRAINT UQ_SmsReminderLog;
GO

-- 3. Add the per-student unique constraint. Note: a standard UNIQUE constraint treats NULLs as
--    equal, so at most one NULL-StudentNumber row is allowed per (GuardianKey, PromiseDate,
--    ReminderType). That is correct for 'General' balance reminders (StudentNumber NULL), which
--    the GeneralReminderCooldownDays window already prevents from repeating same-day.
IF NOT EXISTS (SELECT 1 FROM sys.key_constraints
               WHERE name = 'UQ_SmsReminderLog' AND parent_object_id = OBJECT_ID('tbl_SmsReminderLog'))
    ALTER TABLE tbl_SmsReminderLog
        ADD CONSTRAINT UQ_SmsReminderLog UNIQUE (GuardianKey, StudentNumber, PromiseDate, ReminderType);
GO
