using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

internal class Depreciation
{
	private static string StraightLineMethod
	{
		get
		{
			string result = string.Empty;
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_FixedAssets_Value", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Assets");
				DataTable dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					result = row["DepreMethod"].ToString();
				}
			}
			return result;
		}
	}

	public static double UseStraightLineMethod(double initialCost, double depreciationRate)
	{
		return depreciationRate / 100.0 * initialCost;
	}

	public static double UseReducingBalanceMethod(double CurrentValue, double DepreciationRate, double PreviousDepreciation)
	{
		return DepreciationRate / 100.0 * (CurrentValue - PreviousDepreciation);
	}

	public static void DepreciateAssets()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_FixedAssets_Value", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Assets");
			DataTable dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				if ((!(row["DepreMethod"].ToString() == "Straight Line Method") || !Convert.ToBoolean(row["IsDepreciable"])) && row["DepreMethod"].ToString() == "Declining Balance Method" && !Convert.ToBoolean(row["IsDepreciable"]))
				{
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
