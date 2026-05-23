using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace LibraryManagement;

internal class LocalCode
{
	public static string GetNextBookNumber()
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX(BookId) AS BookId,LocalCode FROM tbl_Books GROUP BY LocalCode", DataConnection.ConnectToDatabase());
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "LastNo");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		string text = "";
		foreach (DataRow row in dataTable.Rows)
		{
			text = row["LocalCode"].ToString();
		}
		int num = 0;
		int num2 = text.IndexOf('-') + 1;
		string s = text.Substring(num2, text.Length - num2);
		int result = (int.TryParse(s, out result) ? result : 99999);
		string text2 = ((result == 99999) ? 1 : (result + 1)).ToString();
		string result2 = "";
		if (text2.Length == 1)
		{
			result2 = "0000" + text2;
		}
		else if (text2.Length == 2)
		{
			result2 = "000" + text2;
		}
		else if (text2.Length == 3)
		{
			result2 = "00" + text2;
		}
		else if (text2.Length == 4)
		{
			result2 = "0" + text2;
		}
		else if (text2.Length == 5)
		{
			result2 = text2;
		}
		return result2;
	}

	public static bool LocalNumberExists(string LocalCode)
	{
		bool result = false;
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT LocalCode FROM tbl_Books WHERE LocalCode='{LocalCode}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "LocalCode");
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
