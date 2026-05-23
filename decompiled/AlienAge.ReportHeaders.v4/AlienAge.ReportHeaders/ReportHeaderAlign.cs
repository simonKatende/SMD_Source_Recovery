using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.ReportHeaders;

[Serializable]
public class ReportHeaderAlign
{
	private static string _fileName = "AAD6219A-39FF-4FB6-AE2F-7F1A33D6DD8F.tmp";

	private string headerAlignment { get; set; }

	private int alignmentIndex { get; set; }

	public static string HeaderAlignment
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, _fileName);
			if (File.Exists(path))
			{
				ReportHeaderAlign reportHeaderAlign = new ReportHeaderAlign();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeaderAlign = (ReportHeaderAlign)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeaderAlign.headerAlignment;
			}
			return "Left";
		}
	}

	public static int AlignmentIndex
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, _fileName);
			if (File.Exists(path))
			{
				ReportHeaderAlign reportHeaderAlign = new ReportHeaderAlign();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportHeaderAlign = (ReportHeaderAlign)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportHeaderAlign.alignmentIndex;
			}
			return 0;
		}
	}

	public static void SetHeaderAlignment(string alignment, int alignmentIndex)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, _fileName);
		ReportHeaderAlign reportHeaderAlign = new ReportHeaderAlign();
		reportHeaderAlign.headerAlignment = alignment;
		reportHeaderAlign.alignmentIndex = alignmentIndex;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, reportHeaderAlign);
		fileStream.Close();
	}
}
