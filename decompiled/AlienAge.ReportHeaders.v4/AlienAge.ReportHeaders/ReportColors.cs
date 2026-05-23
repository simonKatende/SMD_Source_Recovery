using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.ReportHeaders;

[Serializable]
public class ReportColors
{
	private const string _fileName = "9D321B41-CABE-465C-8F2E-5B0ECF292B64.tmp";

	private double reportHeaderTextColor { get; set; }

	private double reportBannerColor { get; set; }

	private double reportForeColor { get; set; }

	public static double ReportHeaderTextColor
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "9D321B41-CABE-465C-8F2E-5B0ECF292B64.tmp");
			if (File.Exists(path))
			{
				ReportColors reportColors = new ReportColors();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportColors = (ReportColors)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportColors.reportHeaderTextColor;
			}
			return -8355585.0;
		}
	}

	public static double ReportBannerColor
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "9D321B41-CABE-465C-8F2E-5B0ECF292B64.tmp");
			if (File.Exists(path))
			{
				ReportColors reportColors = new ReportColors();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportColors = (ReportColors)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportColors.reportBannerColor;
			}
			return -4128832.0;
		}
	}

	public static double ReportForeColor
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "9D321B41-CABE-465C-8F2E-5B0ECF292B64.tmp");
			if (File.Exists(path))
			{
				ReportColors reportColors = new ReportColors();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportColors = (ReportColors)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportColors.reportForeColor;
			}
			return -8355840.0;
		}
	}

	public static void SetReportColors(double _headerColor, double _banner_table_Color, double _foreColor)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "9D321B41-CABE-465C-8F2E-5B0ECF292B64.tmp");
		ReportColors reportColors = new ReportColors();
		reportColors.reportHeaderTextColor = _headerColor;
		reportColors.reportBannerColor = _banner_table_Color;
		reportColors.reportForeColor = _foreColor;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, reportColors);
		fileStream.Close();
	}
}
