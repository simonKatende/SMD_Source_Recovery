using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace AlienAge.TermlySettings.Thematic;

public class ExamsOutputString
{
	public static string hHoP { get; set; }

	public static string hBOT { get; set; }

	public static string hMOT { get; set; }

	public static string hEOT { get; set; }

	public static void InitializeExamsOutputStrings(string _class, string _semester)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_TermSettings WHERE ClassId='" + _class + "' AND SemesterId='" + _semester + "'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count == 0)
		{
			hHoP = "HoP";
			hBOT = "BOT";
			hMOT = "MOT";
			hEOT = "EOT";
		}
		else
		{
			hHoP = dataTable.Rows[0]["hHoP"].ToString();
			hBOT = dataTable.Rows[0]["hBOT"].ToString();
			hMOT = dataTable.Rows[0]["hMOT"].ToString();
			hEOT = dataTable.Rows[0]["hEOT"].ToString();
		}
	}
}
