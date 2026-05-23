using System;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

internal class WorkingDate
{
	public static DateTime WorkingSetDate
	{
		get
		{
			DateTime result = DateTime.Now;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT CurrentDate FROM tbl_CurrentDate", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "WorkingSetDate");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					result = DateTime.Now;
				}
				else
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						result = Convert.ToDateTime(row["CurrentDate"]);
					}
				}
			}
			return result;
		}
	}
}
