using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.ReportHeaders;

[Serializable]
public class ReportHeaderVisibility
{
	private static string _fileName = "84B41595-604E-418B-A2A2-884BDEB33803.tmp";

	private bool reportHeaderVisible { get; set; }

	public static bool ReportHeaderVisible
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, _fileName);
			if (File.Exists(path))
			{
				ReportHeaderVisibility reportHeaderVisibility = new ReportHeaderVisibility();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeaderVisibility = (ReportHeaderVisibility)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeaderVisibility.reportHeaderVisible;
			}
			return true;
		}
	}

	public static void SetReportHeaderVisibility(bool showHeader)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, _fileName);
		ReportHeaderVisibility reportHeaderVisibility = new ReportHeaderVisibility();
		reportHeaderVisibility.reportHeaderVisible = showHeader;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, reportHeaderVisibility);
		fileStream.Close();
	}
}
