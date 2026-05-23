namespace I_Xtreme.ExtremeClasses;

public class StudentForCapture
{
	public static string StudentNo { get; set; }

	public static string StudentName { get; set; }

	public static void SetStudentForCapture(string _StudentNo, string _StudentName)
	{
		StudentNo = _StudentNo;
		StudentName = _StudentName;
	}
}
