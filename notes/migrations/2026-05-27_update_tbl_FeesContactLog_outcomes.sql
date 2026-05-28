-- notes/migrations/2026-05-27_update_tbl_FeesContactLog_outcomes.sql
--
-- Context: WrongContact is removed from the ContactOutcome enum.
-- Existing rows with Outcome = 'WrongContact' would silently parse
-- to null (Enum.TryParse miss). This UPDATE remaps them to 'NoAnswer'
-- so they display correctly in the history grid.
--
-- Safe to run multiple times (idempotent via WHERE clause).
-- Run manually against the school's SMD SQL Server database BEFORE
-- launching the updated IXtreme.exe.

UPDATE dbo.tbl_FeesContactLog
SET    Outcome = 'NoAnswer'
WHERE  Outcome = 'WrongContact';
