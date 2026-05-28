-- notes/migrations/2026-05-28_add_GuardianKey_to_FeesContactLog.sql
--
-- Context: Guardian-level contacts are stored as one row per guardian instead
-- of one row per student. GuardianKey holds the guardian's primary phone number
-- (same value used as the grouping key in GetGuardianWorklist).
-- Existing rows keep GuardianKey = NULL; the service queries by
-- (GuardianKey = @key) OR (GuardianKey IS NULL AND StudentNumber IN (...)).
--
-- Safe to run multiple times (idempotent via column-existence check).
-- Run manually against the school's SMD SQL Server database BEFORE
-- launching the updated IXtreme.exe.

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'tbl_FeesContactLog' AND COLUMN_NAME = 'GuardianKey'
)
BEGIN
    ALTER TABLE dbo.tbl_FeesContactLog
    ADD GuardianKey VARCHAR(20) NULL;
END
