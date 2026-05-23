using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

internal class PreprimaryReportDesigner
{
	private static string label1 { get; set; }

	private static string label2 { get; set; }

	private static string reportHeader { get; set; }

	private static Color colorScale1 { get; set; }

	private static Color colorScale2 { get; set; }

	private static Color colorScale3 { get; set; }

	private static Color colorScale4 { get; set; }

	private static bool showColorMap { get; set; }

	private static int scaleValuesInUse { get; set; }

	public static string Label1 => label1;

	public static string Label2 => label2;

	public static string ReportHeader => reportHeader;

	public static Color ColorScale1 => colorScale1;

	public static Color ColorScale2 => colorScale2;

	public static Color ColorScale3 => colorScale3;

	public static Color ColorScale4 => colorScale4;

	public static bool ShowColorMap => showColorMap;

	public static int ScaleValuesInUse => scaleValuesInUse;

	public static void InitializeInfantReportDesigner()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_ReportSettings", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ReportDesigner");
		if (dataSet.Tables[0].Rows.Count == 0)
		{
			label1 = "Class Teacher:";
			label2 = "Headteacher:";
			reportHeader = "Termly Report Card";
			colorScale1 = Color.FromArgb(255, 128, 128);
			colorScale2 = Color.Aqua;
			colorScale3 = Color.Gold;
			colorScale4 = Color.Lime;
			showColorMap = true;
			scaleValuesInUse = 0;
			return;
		}
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			label1 = row["Label1"].ToString();
			label2 = row["Label2"].ToString();
			reportHeader = row["ReportHeader"].ToString();
			colorScale1 = Color.FromArgb(Convert.ToInt32(row["Score1"].ToString()));
			colorScale2 = Color.FromArgb(Convert.ToInt32(row["Score2"].ToString()));
			colorScale3 = Color.FromArgb(Convert.ToInt32(row["Score3"].ToString()));
			colorScale4 = Color.FromArgb(Convert.ToInt32(row["Score4"].ToString()));
			showColorMap = Convert.ToBoolean(row["ShowColorMap"].ToString());
			scaleValuesInUse = Convert.ToInt32(row["ScaleLabelInUse"].ToString());
		}
	}
}
