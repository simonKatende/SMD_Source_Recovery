namespace I_Xtreme;

internal class ReportParameters
{
	public static string Semester { get; set; }

	public static string Class { get; set; }

	public static string Stream { get; set; }

	public static bool ShadeReport { get; set; }

	public static void SetReportParameters(string Term, string StudentClass, string ClassStream, bool ShowShades)
	{
		Class = StudentClass;
		Stream = ClassStream;
		Semester = Term;
		ShadeReport = ShowShades;
	}
}
