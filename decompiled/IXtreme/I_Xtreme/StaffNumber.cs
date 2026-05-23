using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.XtraEditors;

namespace I_Xtreme;

internal class StaffNumber
{
	private static string CurrentYear => DateTime.Now.ToString("yy-");

	private static string IDNumberPrefix()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		return dataSet.Tables[0].Rows[0]["T_T"].ToString();
	}

	public static void SaveStaffNumber(string studentNo)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_LastId (lastId) VALUES (@lastId)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@lastId", SqlDbType.VarChar, 50);
		sqlParameter.Value = studentNo;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	public static string[] GetNextStaffNumber()
	{
		string[] array = new string[2] { "", "" };
		string schoolCode = SerialNumber.GetSchoolCode(DataConnection.ConnectToDatabase());
		string empty = string.Empty;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT COUNT(StaffId) AS CountOfNumbers FROM Staff", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		int num = Convert.ToInt32(dataTable.Rows[0]["CountOfNumbers"].ToString());
		int length = (num + 1).ToString().Length;
		do
		{
			num++;
			empty = length switch
			{
				1 => "00" + num, 
				2 => "0" + num, 
				3 => num.ToString(), 
				_ => "100", 
			};
		}
		while (StaffNumberExists(schoolCode + empty));
		array[0] = schoolCode + "8675" + empty;
		array[1] = IDNumberPrefix() + DateTime.Now.ToString("yy") + "-" + empty;
		return array;
	}

	public static bool StaffNumberExists(string StudentNo)
	{
		bool result = false;
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StaffId FROM Staff WHERE StaffId ='{StudentNo}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentNos");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				result = false;
			}
			else if (dataTable.Rows.Count > 0)
			{
				result = true;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}
}
