using System;

namespace I_Xtreme.ExtremeClasses;

internal class RollCallHelper
{
	public static string ClassId { get; set; }

	public static string StreamId { get; set; }

	public static DateTime EffectiveDate { get; set; }

	public static bool IsWeeklyReport { get; set; } = true;


	public static void SetRollCall(string _ClassId, string _StreamId, DateTime _EffectiveDate, bool _IsWeeklReport)
	{
		ClassId = _ClassId;
		StreamId = _StreamId;
		EffectiveDate = _EffectiveDate;
		IsWeeklyReport = _IsWeeklReport;
	}
}
