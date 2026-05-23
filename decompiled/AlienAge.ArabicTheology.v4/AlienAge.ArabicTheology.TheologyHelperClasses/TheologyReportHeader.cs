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

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

[Serializable]
public class TheologyReportHeader
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

	private static string schNameAr = string.Empty;

	private static string schTelAr = string.Empty;

	private static string schMottoAr = string.Empty;

	private static string schFullAddressAr = string.Empty;

	private static string schLocationAr = string.Empty;

	private static string schoolBoxNoAr = string.Empty;

	private string _headerString { get; set; }

	private string _headerStringAr { get; set; }

	private string _selectedSets { get; set; }

	private string _scoreCaption { get; set; }

	private double _bot { get; set; }

	private double _mot { get; set; }

	private double _eot { get; set; }

	private DateTime _termBegins { get; set; }

	private string _termBeginsAr { get; set; }

	public static double BOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._bot;
			}
			return 25.0;
		}
	}

	public static double MOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._mot;
			}
			return 25.0;
		}
	}

	public static double EOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._eot;
			}
			return 25.0;
		}
	}

	public static string SelectedSets
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._selectedSets;
			}
			return "HBME";
		}
	}

	public static string ScoreCaption
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._scoreCaption;
			}
			return "TOTAL";
		}
	}

	public static string HeaderString
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._headerString;
			}
			return "TERMLY REPORT CARD";
		}
	}

	public static string HeaderStringAr
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._headerStringAr;
			}
			return "";
		}
	}

	public static DateTime NextTermBeginsOn
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._termBegins;
			}
			return DateTime.Now;
		}
	}

	public static string NextTermBeginsOnAr
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
			if (File.Exists(path))
			{
				TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyReportHeader = (TheologyReportHeader)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return theologyReportHeader._termBeginsAr;
			}
			return DateTime.Now.ToString();
		}
	}

	public static string SchoolName => schName;

	public static string ShortName => shortName;

	public static string SchoolTel => schTel;

	public static string SchoolMotto => schMotto;

	public static string SchoolNetAddress => schNetAddress;

	public static string SchoolFullAddress => schFullAddress;

	public static string SchoolLocation => schLocation;

	public static string SchoolBoxNo => schoolBoxNo;

	public static Image SchoolLogo => schLogo;

	public static string SchoolNameAr => schNameAr;

	public static string SchoolTelAr => schTelAr;

	public static string SchoolMottoAr => schMottoAr;

	public static string SchoolFullAddressAr => schFullAddressAr;

	public static string SchoolLocationAr => schLocationAr;

	public static string SchoolBoxNoAr => schoolBoxNoAr;

	public static void InitializeReportHeaderTitle(string Class, string Term)
	{
		string headerString = string.Empty;
		string headerStringAr = string.Empty;
		string selectedSets = string.Empty;
		string scoreCaption = string.Empty;
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		DateTime result4 = DateTime.Now;
		string termBeginsAr = DateTime.Now.ToString();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMDTH_ReportTitleHeaders.tmp");
		string selectCommandText = "SELECT * FROM tbl_TermSettings_TH WHERE SemesterId='" + Term + "' AND ClassIdEn='" + Class + "'";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		using (DataSet dataSet = new DataSet())
		{
			sqlDataAdapter.Fill(dataSet, "TermSettings");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				headerString = "TERMLY REPORT CARD";
				headerStringAr = "";
				selectedSets = "BME";
				result = 25.0;
				result2 = 25.0;
				result3 = 25.0;
				result4 = DateTime.Now;
				termBeginsAr = DateTime.Now.ToString();
				scoreCaption = "TOTAL";
			}
			else
			{
				headerString = dataSet.Tables[0].Rows[0]["ReportHeaderEn"].ToString();
				headerStringAr = dataSet.Tables[0].Rows[0]["ReportHeaderAr"].ToString();
				selectedSets = dataSet.Tables[0].Rows[0]["Sets"].ToString();
				result = (double.TryParse(dataSet.Tables[0].Rows[0]["BOTEn"].ToString(), out result) ? result : 0.0);
				result2 = (double.TryParse(dataSet.Tables[0].Rows[0]["MOTEn"].ToString(), out result2) ? result2 : 0.0);
				result3 = (double.TryParse(dataSet.Tables[0].Rows[0]["EOTEn"].ToString(), out result3) ? result3 : 0.0);
				result4 = (DateTime.TryParse(dataSet.Tables[0].Rows[0]["TermBeginsOnEn"].ToString(), out result4) ? result4 : DateTime.Now);
				result4 = (DateTime.TryParse(dataSet.Tables[0].Rows[0]["TermBeginsOnAr"].ToString(), out result4) ? result4 : DateTime.Now);
				scoreCaption = ((!Convert.ToBoolean(dataSet.Tables[0].Rows[0]["IsPercentage"].ToString())) ? "TOTAL" : "AVG");
			}
		}
		TheologyReportHeader theologyReportHeader = new TheologyReportHeader();
		theologyReportHeader._headerString = headerString;
		theologyReportHeader._headerStringAr = headerStringAr;
		theologyReportHeader._selectedSets = selectedSets;
		theologyReportHeader._bot = result;
		theologyReportHeader._mot = result2;
		theologyReportHeader._eot = result3;
		theologyReportHeader._termBegins = result4;
		theologyReportHeader._termBeginsAr = termBeginsAr;
		theologyReportHeader._scoreCaption = scoreCaption;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, theologyReportHeader);
		fileStream.Close();
	}

	public static void InitializeReportHeaderEn()
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

	public static void InitializeReportHeaderAr()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails_TH", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ReportHeader");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				schNameAr = "-";
				schTelAr = "-";
				schMottoAr = "-";
				schFullAddressAr = "-";
				schLocationAr = "-";
				schoolBoxNoAr = "-";
				return;
			}
			IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					schNameAr = dataRow["SchoolName"].ToString();
					schTelAr = "Tel: " + dataRow["mobileContact"].ToString() + ", " + dataRow["officeContact"].ToString();
					schMottoAr = dataRow["schoolMotto"].ToString();
					schFullAddressAr = dataRow["fullContact"].ToString();
					schLocationAr = dataRow["location"].ToString();
					schoolBoxNoAr = "P.O.Box " + dataRow["boxNumber"].ToString() + " " + dataRow["district"].ToString();
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
