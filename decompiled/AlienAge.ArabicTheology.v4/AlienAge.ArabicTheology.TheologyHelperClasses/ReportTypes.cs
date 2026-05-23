namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public static class ReportTypes
{
	private static string thematicClass { get; set; }

	private static string theologyClass { get; set; }

	private static string term { get; set; }

	public static string ThematicClass => thematicClass;

	public static string TheologyClass => theologyClass;

	public static string Term => term;

	public static void SetTermSetting(string TheologyClass, string ThematicClass, string Term)
	{
		thematicClass = ThematicClass;
		theologyClass = TheologyClass;
		term = Term;
	}
}
