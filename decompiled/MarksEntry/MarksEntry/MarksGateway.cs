namespace MarksEntry;

internal class MarksGateway
{
	private static string tr { get; set; }

	private static string subject { get; set; }

	private static string _class { get; set; }

	private static string term { get; set; }

	private static string newCur { get; set; }

	public static string TR => tr;

	public static string Subject => subject;

	public static string _Class => _class;

	public static string Term => term;

	public static string NewCurriculum => newCur;

	public static void SetLoginParameters(string Tr, string Subject, string _Class, string Term, string NewCurriculum)
	{
		tr = Tr;
		subject = Subject;
		_class = _Class;
		term = Term;
		newCur = NewCurriculum;
	}
}
