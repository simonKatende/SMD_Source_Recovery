using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

public class GradeSummaryService
{
	public static DataTable GetGradeSummaryAIEOT(string ClassEn, string StreamEn, string Term)
	{
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			DataTable dataTable = new DataTable();
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand("GetGradeSummaryPerClass", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 120;
				sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
				sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
			}
			return dataTable;
		}
		DataTable dataTable2 = new DataTable();
		using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("GetGradeSummaryPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.CommandTimeout = 120;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable2);
		}
		return dataTable2;
	}

	public static DataTable GetGradeSummaryEOT(string ClassEn, string StreamEn, string Term)
	{
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			DataTable dataTable = new DataTable();
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand("GetGradeSummaryPerClassEOT", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 120;
				sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
				sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
			}
			return dataTable;
		}
		DataTable dataTable2 = new DataTable();
		using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("GetGradeSummaryPerStreamEOT", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.CommandTimeout = 120;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable2);
		}
		return dataTable2;
	}

	public static DataTable GetGradeSummaryAI(string ClassEn, string StreamEn, string Term)
	{
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			DataTable dataTable = new DataTable();
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand("GetGradeSummaryPerClassAI", sqlConnection);
				sqlCommand.CommandType = CommandType.StoredProcedure;
				sqlCommand.CommandTimeout = 120;
				sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
				sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
			}
			return dataTable;
		}
		DataTable dataTable2 = new DataTable();
		using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("GetGradeSummaryPerStreamAI", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.CommandTimeout = 120;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable2);
		}
		return dataTable2;
	}

	public static DataTable GetAlevelGradeSummaryPerPaper(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelPrincipalPerPaperPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelPrincipalPerPaperPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}

	public static DataTable GetAlevelGradeSummaryPerSubject(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelPrincipalPerSubjectPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelPrincipalPerSubjectPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}

	public static DataTable GetAlevelGradeSummaryAWP(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelPrincipalAWPPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelPrincipalAWPPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}

	public static DataTable GetAlevelPrincipalCounts(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelPassesCountPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelPassesCountPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}

	public static DataTable GetAlevelGradeSummaryPerPaperSub(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelSubPerPaperPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelSubPerPaperPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}

	public static DataTable GetAlevelGradeSummaryPerSubjectSub(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelSubPerSubjectPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelSubPerSubjectPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}

	public static DataTable GetAlevelGradeSummaryAWPSub(string ClassEn, string StreamEn, string Term)
	{
		DataTable dataTable = new DataTable();
		if (string.IsNullOrEmpty(StreamEn) || StreamEn.Equals("-Entire Class-"))
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand("ALevelSubAWPPerClass", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", Term));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dataTable);
		}
		else
		{
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand("ALevelSubAWPPerStream", sqlConnection2);
			sqlCommand2.CommandType = CommandType.StoredProcedure;
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", ClassEn));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@StreamId", StreamEn));
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			sqlDataAdapter2.Fill(dataTable);
		}
		return dataTable;
	}
}
