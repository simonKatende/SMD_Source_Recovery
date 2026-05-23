using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

internal class ReportComments
{
	public string ValuesExhibited { get; set; } = string.Empty;


	public string ClassTeacherComment { get; set; } = string.Empty;


	public string ClassTeacherName { get; set; } = string.Empty;


	public string HeadTeacherComment { get; set; } = string.Empty;


	public string HeadTeacherName { get; set; } = string.Empty;


	public string GamesAndSports { get; set; } = string.Empty;


	public string GamesName { get; set; } = string.Empty;


	public string Clubs { get; set; } = string.Empty;


	public string ClubsName { get; set; } = string.Empty;


	public string ProjectTitle { get; set; } = string.Empty;


	public string Project { get; set; } = string.Empty;


	public ReportComments(string StudentNo, string Class, string Term)
	{
		GetReportComments(StudentNo, Class, Term);
	}

	public void GetReportComments(string StudentNo, string Class, string Term)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM ReportCommentsNC WHERE StudentNumber='{StudentNo}' AND ClassId='{Class}' AND SemesterId='{Term}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			ValuesExhibited = dataTable.Rows[0]["ValuesExhibited"].ToString();
			ClassTeacherComment = dataTable.Rows[0]["ClassTeacherComment"].ToString();
			ClassTeacherName = dataTable.Rows[0]["ClassTeacherName"].ToString();
			HeadTeacherComment = dataTable.Rows[0]["HeadTeacherComment"].ToString();
			HeadTeacherName = dataTable.Rows[0]["HeadTeacherName"].ToString();
			GamesAndSports = dataTable.Rows[0]["GamesAndSports"].ToString();
			GamesName = dataTable.Rows[0]["GamesName"].ToString();
			Clubs = dataTable.Rows[0]["Clubs"].ToString();
			ClubsName = dataTable.Rows[0]["ClubsName"].ToString();
			ProjectTitle = dataTable.Rows[0]["ProjectTitle"].ToString();
			Project = dataTable.Rows[0]["Project"].ToString();
		}
	}
}
