namespace I_Xtreme.ExtremeClasses;

internal class StudentFeesCard
{
	public static string ClassId { get; set; }

	public static string StreamId { get; set; }

	public static double FeesBalance { get; set; }

	public static void SetClearanceCardParameters(string _ClassId, string _StreamId, double _FeesBalance)
	{
		ClassId = _ClassId;
		StreamId = _StreamId;
		FeesBalance = _FeesBalance;
	}
}
