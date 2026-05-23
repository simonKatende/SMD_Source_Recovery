using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

internal class FeesBalance
{
	public static bool FeesBalanceVisible
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_FeesBalance", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "_FeesBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			bool result = false;
			if (dataTable.Rows.Count >= 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					result = Convert.ToBoolean(row["outPut"]);
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	public static void UpdateFeesBalanceOnReport(string studentClass)
	{
		try
		{
			string text = studentClass.Substring(2, 1);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{studentClass}'", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Fees_Balance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				string selectCommandText = string.Format("SELECT TOP (100) PERCENT PaymentId, StudentNumber, Debit, Credit, Balance FROM FeesPayment AS FeesPayment_1 WHERE (PaymentId IN (SELECT MAX(PaymentId) AS PaymentId FROM FeesPayment AS FeesPayment WHERE (StudentNumber = '{0}')))", row["StudentNumber"]);
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				using DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "CashOnAccount");
				DataTable dataTable2 = dataSet2.Tables[0];
				foreach (DataRow row2 in dataTable2.Rows)
				{
					double result = (double.TryParse(row2["Balance"].ToString(), out result) ? result : 0.0);
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = string.Format("UPDATE tbl_Stud SET cashOnAccount={0} WHERE StudentNumber='{1}' AND ClassId='{2}'", result, row["StudentNumber"], studentClass),
						CommandType = CommandType.Text
					};
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void SetShowFeesBalance(bool showFeesBalance)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "SELECT * FROM tbl_FeesBalance",
			CommandType = CommandType.Text
		};
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "UPDATE tbl_FeesBalance SET outPut=@outPut",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@outPut", SqlDbType.Bit);
				sqlParameter.Value = showFeesBalance;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection2.Close();
			return;
		}
		sqlConnection.Close();
		using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection3.Open();
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Connection = sqlConnection3,
			CommandText = "INSERT INTO tbl_FeesBalance (outPut) VALUES (@outPut)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@outPut", SqlDbType.Bit);
			sqlParameter2.Value = showFeesBalance;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
		}
		sqlConnection3.Close();
	}
}
