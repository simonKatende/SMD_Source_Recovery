using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace AlienAge.TermlySettings.Thematic;

public class ThematicRatios
{
	private static double hop { get; set; }

	private static double bot { get; set; }

	private static double mot { get; set; }

	private static double eot { get; set; }

	private static bool processType { get; set; }

	private static bool marksNot100 { get; set; }

	private static bool aEOT { get; set; }

	public static double HoP => hop;

	public static double BOT => bot;

	public static double MOT => mot;

	public static double EOT => eot;

	public static bool ProcessAsPercentages => processType;

	public static bool MarksNot100 => marksNot100;

	public static bool AEOT => aEOT;

	public static void InitializeRatios(string _class, string _semester)
	{
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		double result4 = 0.0;
		bool result5 = false;
		bool result6 = false;
		bool result7 = false;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_TermSettings WHERE ClassId='" + _class + "' AND SemesterId='" + _semester + "'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TermSettings");
		IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				result = (double.TryParse(dataRow["BOT"].ToString(), out result) ? result : 0.0);
				result2 = (double.TryParse(dataRow["EOT"].ToString(), out result2) ? result2 : 0.0);
				result3 = (double.TryParse(dataRow["MOT"].ToString(), out result3) ? result3 : 0.0);
				result4 = (double.TryParse(dataRow["HoP"].ToString(), out result4) ? result4 : 0.0);
				result5 = bool.TryParse(dataRow["AEOT"].ToString(), out result5) && result5;
				result6 = bool.TryParse(dataRow["IsPercentage"].ToString(), out result6) && result6;
				result7 = bool.TryParse(dataRow["EnterAs100"].ToString(), out result7) && result7;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		aEOT = result5;
		bot = result;
		eot = result2;
		mot = result3;
		hop = result4;
		processType = result6;
		marksNot100 = result7;
	}
}
