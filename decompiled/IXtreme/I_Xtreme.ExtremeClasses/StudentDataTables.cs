namespace I_Xtreme.ExtremeClasses;

internal class StudentDataTables
{
	public static string StudentsTable(string SelectedClass)
	{
		string result = string.Empty;
		switch (SelectedClass)
		{
		case "S.1":
			result = "tbl_Stud_1";
			break;
		case "S.2":
			result = "tbl_Stud_2";
			break;
		case "S.3":
			result = "tbl_Stud_3";
			break;
		case "S.4":
			result = "tbl_Stud_4";
			break;
		case "S.5":
			result = "tbl_Stud_5";
			break;
		case "S.6":
			result = "tbl_Stud_6";
			break;
		}
		return result;
	}
}
