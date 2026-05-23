using System;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

internal class StudentIdentityCards
{
	private static int j;

	private static int m;

	public static void GenerateClassIds(string _class, string stream, DateTime issueDate, DateTime validityDate, ProgressBarControl progessBar)
	{
		DeleteIds(issueDate.Year, _class, stream, progessBar);
		string arg = string.Empty;
		string arg2 = string.Empty;
		switch (_class)
		{
		case "S.1":
			arg = "tbl_Stud_1";
			arg2 = "tbl_StudIDS_1";
			break;
		case "S.2":
			arg = "tbl_Stud_2";
			arg2 = "tbl_StudIDS_2";
			break;
		case "S.3":
			arg = "tbl_Stud_3";
			arg2 = "tbl_StudIDS_3";
			break;
		case "S.4":
			arg = "tbl_Stud_4";
			arg2 = "tbl_StudIDS_4";
			break;
		case "S.5":
			arg = "tbl_Stud_5";
			arg2 = "tbl_StudIDS_5";
			break;
		case "S.6":
			arg = "tbl_Stud_6";
			arg2 = "tbl_StudIDS_6";
			break;
		}
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,ClassId,StreamId FROM {arg} WHERE ClassId='{_class}' AND StreamId='{stream}'", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "StudentIdList");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		progessBar.Properties.Maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"INSERT INTO {arg2} (StudentNumber,IssueYear,IssueDate,Validity) VALUES (@StudentNumber,@IssueYear,@IssueDate,@Validity)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = row["StudentNumber"].ToString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IssueYear", SqlDbType.Int);
			sqlParameter.Value = issueDate.Year;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IssueDate", SqlDbType.DateTime);
			sqlParameter.Value = issueDate.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Validity", SqlDbType.DateTime);
			sqlParameter.Value = validityDate.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			j++;
			progessBar.Position = j;
		}
		XtraMessageBox.Show("Student IDs Created successfully", "School Management Dynamics");
		progessBar.Position = 0;
	}

	public static void DeleteIds(int issueYear, string _class, string stream, ProgressBarControl progessBar)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		switch (_class)
		{
		case "S.1":
			text = "tbl_Stud_1";
			text2 = "tbl_StudIDS_1";
			break;
		case "S.2":
			text = "tbl_Stud_2";
			text2 = "tbl_StudIDS_2";
			break;
		case "S.3":
			text = "tbl_Stud_3";
			text2 = "tbl_StudIDS_3";
			break;
		case "S.4":
			text = "tbl_Stud_4";
			text2 = "tbl_StudIDS_4";
			break;
		case "S.5":
			text = "tbl_Stud_5";
			text2 = "tbl_StudIDS_5";
			break;
		case "S.6":
			text = "tbl_Stud_6";
			text2 = "tbl_StudIDS_6";
			break;
		}
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.StudentNumber,s.ClassId,s.StreamId,id.IssueYear FROM {text} s INNER JOIN {text2} id ON s.StudentNumber=id.StudentNumber WHERE s.ClassId='{_class}' AND s.StreamId='{stream}' AND id.IssueYear={issueYear}", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "StudentIdList");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		m = dataTable.Rows.Count;
		progessBar.Properties.Maximum = dataTable.Rows.Count;
		progessBar.Position = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM {0} WHERE StudentNumber='{1}'", text, row["StudentNumber"]),
				CommandType = CommandType.Text
			};
			sqlCommand.ExecuteNonQuery();
			m--;
			progessBar.Position = m;
		}
		progessBar.Position = 0;
	}
}
