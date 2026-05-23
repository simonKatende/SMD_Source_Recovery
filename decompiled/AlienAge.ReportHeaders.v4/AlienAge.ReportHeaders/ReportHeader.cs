using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.XtraEditors;

namespace AlienAge.ReportHeaders;

[Serializable]
public class ReportHeader
{
	private static string schName = string.Empty;

	private static string shortName = string.Empty;

	private static string schTel = string.Empty;

	private static string schMotto = string.Empty;

	private static string schNetAddress = string.Empty;

	private static string schFullAddress = string.Empty;

	private static string schLocation = string.Empty;

	private static string schoolBoxNo = string.Empty;

	private static Image schLogo = null;

	private string _headerString { get; set; }

	private string _selectedSets { get; set; }

	private string _scoreCaption { get; set; }

	private double _hop { get; set; }

	private double _bot { get; set; }

	private double _mot { get; set; }

	private double _eot { get; set; }

	private DateTime _termBegins { get; set; }

	private DateTime _termEnds { get; set; }

	private static int selectedCode { get; set; }

	public static double HoP
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._hop;
			}
			return 25.0;
		}
	}

	public static double BOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._bot;
			}
			return 25.0;
		}
	}

	public static double MOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._mot;
			}
			return 25.0;
		}
	}

	public static double EOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._eot;
			}
			return 25.0;
		}
	}

	public static string SelectedSets
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._selectedSets;
			}
			return "HBME";
		}
	}

	public static string ScoreCaption
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._scoreCaption;
			}
			return "TOTAL";
		}
	}

	public static string HeaderString
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._headerString;
			}
			return "TERMLY REPORT CARD";
		}
	}

	public static DateTime NextTermBeginsOn
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._termBegins;
			}
			return DateTime.Now;
		}
	}

	public static DateTime NextTermEndsOn
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				ReportHeader reportHeader = new ReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeader = (ReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeader._termEnds;
			}
			return DateTime.Now;
		}
	}

	public static string SchoolName => schName;

	public static int SelectedCode => selectedCode;

	public static string ShortName => shortName;

	public static string SchoolTel => schTel;

	public static string SchoolMotto => schMotto;

	public static string SchoolNetAddress => schNetAddress;

	public static string SchoolFullAddress => schFullAddress;

	public static string SchoolLocation => schLocation;

	public static string SchoolBoxNo => schoolBoxNo;

	public static Image SchoolLogo => schLogo;

	public static void InitializeReportHeaderTitle(string Class, string Term)
	{
		string headerString = string.Empty;
		string selectedSets = string.Empty;
		string scoreCaption = string.Empty;
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		double result4 = 0.0;
		DateTime result5 = DateTime.Now;
		DateTime result6 = DateTime.Now;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_ReportTitleHeaders.tmp");
		string selectCommandText = "SELECT * FROM tbl_TermSettings WHERE SemesterId='" + Term + "' AND ClassId='" + Class + "'";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		using (DataSet dataSet = new DataSet())
		{
			sqlDataAdapter.Fill(dataSet, "TermSettings");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				headerString = "TERMLY REPORT CARD";
				selectedSets = "HBME";
				result = 25.0;
				result2 = 25.0;
				result3 = 25.0;
				result4 = 25.0;
				result5 = DateTime.Now;
				result6 = DateTime.Now;
				scoreCaption = "TOTAL";
			}
			else
			{
				headerString = dataSet.Tables[0].Rows[0]["ReportHeader"].ToString();
				selectedSets = dataSet.Tables[0].Rows[0]["Sets"].ToString();
				result = (double.TryParse(dataSet.Tables[0].Rows[0]["HoP"].ToString(), out result) ? result : 0.0);
				result2 = (double.TryParse(dataSet.Tables[0].Rows[0]["BOT"].ToString(), out result2) ? result2 : 0.0);
				result3 = (double.TryParse(dataSet.Tables[0].Rows[0]["MOT"].ToString(), out result3) ? result3 : 0.0);
				result4 = (double.TryParse(dataSet.Tables[0].Rows[0]["EOT"].ToString(), out result4) ? result4 : 0.0);
				result5 = (DateTime.TryParse(dataSet.Tables[0].Rows[0]["TermBeginsOn"].ToString(), out result5) ? result5 : DateTime.Now);
				result6 = (DateTime.TryParse(dataSet.Tables[0].Rows[0]["TermEndsOn"].ToString(), out result6) ? result6 : DateTime.Now);
				scoreCaption = ((!Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsPercentage"].ToString())) ? "TOTAL" : "AVG");
			}
		}
		ReportHeader reportHeader = new ReportHeader();
		reportHeader._headerString = headerString;
		reportHeader._selectedSets = selectedSets;
		reportHeader._hop = result;
		reportHeader._bot = result2;
		reportHeader._mot = result3;
		reportHeader._eot = result4;
		reportHeader._termBegins = result5;
		reportHeader._termEnds = result6;
		reportHeader._scoreCaption = scoreCaption;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, reportHeader);
		fileStream.Close();
	}

	public static void InitializeReportHeader()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ReportHeader");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				schName = "-";
				schTel = "-";
				schMotto = "-";
				schNetAddress = "-";
				schFullAddress = "-";
				schLocation = "-";
				schoolBoxNo = "-";
				shortName = string.Empty;
				schLogo = null;
				selectedCode = 0;
				return;
			}
			IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					schName = CryptorEngine.Decrypt(dataRow["SchoolName"].ToString());
					schTel = "Tel: " + CryptorEngine.Decrypt(dataRow["mobileContact"].ToString()) + ", " + dataRow["officeContact"].ToString();
					schMotto = dataRow["schoolMotto"].ToString();
					schNetAddress = dataRow["netAddress"].ToString();
					schFullAddress = dataRow["fullContact"].ToString();
					schLocation = CryptorEngine.Decrypt(dataRow["location"].ToString());
					schoolBoxNo = "P.O.Box " + dataRow["boxNumber"].ToString() + " " + dataRow["district"].ToString();
					shortName = dataRow["ShortName"].ToString();
					int result = (int.TryParse(dataRow["NumberDisplay"].ToString(), out result) ? result : 0);
					selectedCode = result;
					byte[] array = new byte[0];
					array = (byte[])dataRow["logo"];
					using MemoryStream stream = new MemoryStream(array);
					schLogo = Image.FromStream(stream);
					return;
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
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
