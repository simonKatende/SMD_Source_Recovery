using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace AlienAge.CommonSettings;

public class ReportCustomization
{
	public static bool IsPotrait { get; set; }

	public static bool ShowHeader { get; set; }

	public static bool ShowALevelPromo { get; set; }

	public static bool ShowOLevelPromo { get; set; }

	public static bool Comment1 { get; set; }

	public static bool Comment2 { get; set; }

	public static string Comment1Label { get; set; }

	public static string Comment2Label { get; set; }

	public static bool ShowFeesBalance { get; set; }

	public static bool ShowFeesNextTerm { get; set; }

	public static bool ShowPositionInClass { get; set; }

	public static bool ShowPositionInStream { get; set; }

	public static bool ShowRawScores { get; set; }

	public static void SetFieldsVisibility(string field, object value)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("UPDATE tbl_ReportSettings SET {0}=@{0}", field, value),
				CommandType = CommandType.Text
			};
			if (value.GetType() == typeof(bool))
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{field}", SqlDbType.Bit);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
			}
			else
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{field}", SqlDbType.VarChar, 50);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
			}
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void InitializeReportSetting()
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_ReportSettings",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"INSERT INTO tbl_ReportSettings (showHeader,ShowColorMap,ScaleLabelInUse,Label1,Label2,Score1,Score2,Score3,Score4,ReportHeader) VALUES (1,1,0,'Classteacher','Headteacher',-16732080,-11235884,-256,-1048576,'END OF TERM REPORT CARD')",
					CommandType = CommandType.Text
				};
				if (sqlCommand2.ExecuteNonQuery() > 0)
				{
					sqlConnection.Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void LoadCustomizedFields()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_ReportSettings", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ReportSettings");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		IsPotrait = Convert.ToBoolean(dataTable.Rows[0]["showPotrait"].ToString());
		ShowHeader = Convert.ToBoolean(dataTable.Rows[0]["showHeader"].ToString());
		ShowALevelPromo = Convert.ToBoolean(dataTable.Rows[0]["showALevelPromo"].ToString());
		ShowOLevelPromo = Convert.ToBoolean(dataTable.Rows[0]["showOLevelPromo"].ToString());
		Comment1 = Convert.ToBoolean(dataTable.Rows[0]["comment1"].ToString());
		Comment2 = Convert.ToBoolean(dataTable.Rows[0]["comment2"].ToString());
		if (string.IsNullOrEmpty(dataTable.Rows[0]["tag1"].ToString()))
		{
			Comment1Label = "Class teacher comment";
		}
		else
		{
			Comment1Label = dataTable.Rows[0]["tag1"].ToString();
		}
		if (string.IsNullOrEmpty(dataTable.Rows[0]["tag2"].ToString()))
		{
			Comment2Label = "Headteacher comment";
		}
		else
		{
			Comment2Label = dataTable.Rows[0]["tag2"].ToString();
		}
		ShowFeesBalance = Convert.ToBoolean(dataTable.Rows[0]["feesBalance"].ToString());
		ShowFeesNextTerm = Convert.ToBoolean(dataTable.Rows[0]["nextTermFees"].ToString());
		ShowPositionInClass = Convert.ToBoolean(dataTable.Rows[0]["classPosition"].ToString());
		ShowPositionInStream = Convert.ToBoolean(dataTable.Rows[0]["streamPosition"].ToString());
		bool result = false;
		try
		{
			result = bool.TryParse(dataTable.Rows[0]["ShowRawScores"].ToString(), out result) && result;
		}
		catch (Exception)
		{
		}
		ShowRawScores = result;
	}
}
