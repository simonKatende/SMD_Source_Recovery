using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

internal class PreprimaryAssessmentScale
{
	public static string[] Scale1 => new string[3] { "Working towards expected range", "Working within expected range", "Exceeding expected range" };

	public static string[] Scale1_ShortCodes => new string[3] { "WT", "EP", "Ex" };

	public static string[] Scale2 => new string[4] { "Tried", "Good", "Very Good", "Excellent" };

	public static string[] Scale2_ShortCodes => new string[4] { "Td", "Gd", "VG", "Ex" };

	public static string[] Scale3 => new string[4] { "Beginning", "Approaching", "Meeting", "Exceeding" };

	public static string[] Scale3_ShortCodes => new string[4] { "Bg", "Ap", "Mt", "Ex" };

	public static string[] Scale4 => new string[4] { "Emerging", "Developing", "Expected", "Exceeding" };

	public static string[] Scale4_ShortCodes => new string[4] { "Em", "Dv", "Ep", "Ex" };

	public static string[] AssessmentScaleKeys
	{
		get
		{
			List<string> list = new List<string>();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_AssessmentScale", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AssessmentScaleKeys");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				list.AddRange(new string[4] { "Tried", "Good", "Very Good", "Excellent" });
			}
			else
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					list.Add(row["Key"].ToString());
				}
			}
			return list.ToArray();
		}
	}

	public static string[] AssessmentScaleShortCodes
	{
		get
		{
			List<string> list = new List<string>();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_AssessmentScale", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AssessmentScaleKeys");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				list.AddRange(new string[4] { "Td", "Gd", "VG", "Ex" });
			}
			else
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					list.Add(row["ShortCode"].ToString());
				}
			}
			return list.ToArray();
		}
	}

	public static bool OrdinalScaleInUse
	{
		get
		{
			bool result = true;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_AssessmentScaleType", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AssessmentScaleKeys");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				result = true;
			}
			else
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					result = Convert.ToBoolean(row["UseOrdinalScale"].ToString());
				}
			}
			return result;
		}
	}
}
