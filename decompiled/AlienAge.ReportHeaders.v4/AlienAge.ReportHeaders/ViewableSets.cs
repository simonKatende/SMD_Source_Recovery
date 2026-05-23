using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.ReportHeaders;

[Serializable]
public class ViewableSets
{
	public static string ME = "ME";

	public static string BE = "BE";

	public static string BM = "BM";

	public static string M = "M";

	public static string E = "E";

	public static string B = "B";

	public static string BME = "BME";

	public static string HBME = "HBME";

	private string viewSet { get; set; }

	public static string ActiveSet
	{
		get
		{
			ViewableSets viewableSets = new ViewableSets();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ViewableSets.tmp");
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				viewableSets = (ViewableSets)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return viewableSets.viewSet;
			}
			return viewableSets.viewSet;
		}
	}

	public static void SetActiveSet(string _viewSet)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_ViewableSets.tmp");
		ViewableSets viewableSets = new ViewableSets();
		viewableSets.viewSet = _viewSet;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, viewableSets);
		fileStream.Close();
	}
}
