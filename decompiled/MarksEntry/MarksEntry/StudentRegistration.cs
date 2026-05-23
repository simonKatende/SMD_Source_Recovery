using DevExpress.XtraGrid.Views.Grid;

namespace MarksEntry;

internal class StudentRegistration
{
	private static int levelToRegister { get; set; }

	private static GridView gridView { get; set; }

	private static int academicYear { get; set; }

	private static string selectedClass { get; set; }

	private static string studentNumber { get; set; }

	private static int registrationMode { get; set; }

	public static int CurrentAcademicYear => academicYear;

	public static int LevelForRegistration => levelToRegister;

	public static int ModeOfRegistration => registrationMode;

	public static GridView StudentsGridView => gridView;

	public static string CurrentClass()
	{
		return selectedClass;
	}

	public static void SetRegistrationParameters(GridView gridView1, string studentClass, int _academicYear, int _regMode, int _levelToRegister)
	{
		academicYear = _academicYear;
		registrationMode = _regMode;
		selectedClass = studentClass;
		levelToRegister = _levelToRegister;
		gridView = gridView1;
	}
}
