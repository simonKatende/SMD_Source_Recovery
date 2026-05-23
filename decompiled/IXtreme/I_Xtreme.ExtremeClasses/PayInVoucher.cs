using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

internal class PayInVoucher
{
	public static string LastVoucherNo
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX(auto) AS MaxVoucher,voucherNo AS VNo FROM tbl_PaymentVoucher Group By voucherNo", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "lastVNo");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			string result = string.Empty;
			foreach (DataRow row in dataTable.Rows)
			{
				result = row["VNo"].ToString();
			}
			return result;
		}
	}

	public static string GetVoucherNoFromAuto(float auto)
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(DataConnection.ConnectToDatabase(), "SELECT voucherNo FROM tbl_PaymentVoucher WHERE auto=" + auto);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "lastVNo");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		string result = string.Empty;
		foreach (DataRow row in dataTable.Rows)
		{
			result = row["voucherNo"].ToString();
		}
		return result;
	}

	public static string GetNextVoucherNumber()
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX(auto) AS id,voucherNo FROM tbl_PaymentVoucher GROUP BY voucherNo", DataConnection.ConnectToDatabase());
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "LastNo");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		string s = string.Empty;
		foreach (DataRow row in dataTable.Rows)
		{
			s = row["voucherNo"].ToString();
		}
		int num = 0;
		int result = (int.TryParse(s, out result) ? result : 999999);
		string text = ((result == 999999) ? 1 : (result + 1)).ToString();
		string result2 = string.Empty;
		if (text.Length == 1)
		{
			result2 = "00000" + text;
		}
		else if (text.Length == 2)
		{
			result2 = "0000" + text;
		}
		else if (text.Length == 3)
		{
			result2 = "000" + text;
		}
		else if (text.Length == 4)
		{
			result2 = "00" + text;
		}
		else if (text.Length == 5)
		{
			result2 = "0" + text;
		}
		else if (text.Length == 6)
		{
			result2 = text;
		}
		return result2;
	}
}
