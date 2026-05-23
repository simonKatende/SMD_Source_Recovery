using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

public static class OverallPerformance
{
	public static double GetAverageScore20(string StudentNumber, string Term, string ClassId)
	{
		double result = 0.0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT  AVG(AvLO) AS AvLO FROM tbl_Scores_OL_Report WHERE (StudentNumber = '{StudentNumber}') AND (SemesterId = '{Term}') AND (ClassId = '{ClassId}')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		return double.TryParse(dataTable.Rows[0]["AvLO"].ToString().PadRight(5).Substring(0, 4), out result) ? result : 0.0;
	}

	public static double GetAverageScore100(string StudentNumber, string Term, string ClassId)
	{
		double result = 0.0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT  AVG(Score100) AS Score100 FROM tbl_Scores_OL_Report WHERE (StudentNumber = '{StudentNumber}') AND (SemesterId = '{Term}') AND (ClassId = '{ClassId}')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		return double.TryParse(dataTable.Rows[0]["Score100"].ToString().PadRight(5).Substring(0, 4), out result) ? result : 0.0;
	}
}
