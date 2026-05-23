using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

internal class FeesMapping
{
	public static double RequriedFees(string Class, string StudyStatus)
	{
		double result = 0.0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM Classes WHERE ClassId='{Class}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		if (dataTable.Rows.Count > 0)
		{
			if (StudyStatus == "B")
			{
				result = (double.TryParse(dataTable.Rows[0]["TuitionResidents"].ToString(), out result) ? result : 0.0);
			}
			else if (StudyStatus == "D")
			{
				result = (double.TryParse(dataTable.Rows[0]["TuitionNonResidents"].ToString(), out result) ? result : 0.0);
			}
		}
		return result;
	}
}
