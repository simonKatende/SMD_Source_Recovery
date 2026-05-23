using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.ReportHeaders;

[Serializable]
public class ReportFonts
{
	private const string _fileName = "B19FE953-4F70-4A8B-859F-B208215D9A69.tmp";

	private string fontName { get; set; }

	private int selectedFont { get; set; }

	private int fontSize { get; set; }

	private int selectedFontSizeIndex { get; set; }

	public static string HeaderFont
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "B19FE953-4F70-4A8B-859F-B208215D9A69.tmp");
			if (File.Exists(path))
			{
				ReportFonts reportFonts = new ReportFonts();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportFonts = (ReportFonts)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportFonts.fontName;
			}
			return "Tahoma";
		}
	}

	public static int SelectedFont
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "B19FE953-4F70-4A8B-859F-B208215D9A69.tmp");
			if (File.Exists(path))
			{
				ReportFonts reportFonts = new ReportFonts();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportFonts = (ReportFonts)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportFonts.selectedFont;
			}
			return 16;
		}
	}

	public static int FontSize
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "B19FE953-4F70-4A8B-859F-B208215D9A69.tmp");
			if (File.Exists(path))
			{
				ReportFonts reportFonts = new ReportFonts();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportFonts = (ReportFonts)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportFonts.fontSize;
			}
			return 24;
		}
	}

	public static int SelectedFontSizeIndex
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "B19FE953-4F70-4A8B-859F-B208215D9A69.tmp");
			if (File.Exists(path))
			{
				ReportFonts reportFonts = new ReportFonts();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportFonts = (ReportFonts)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportFonts.selectedFontSizeIndex;
			}
			return 16;
		}
	}

	public static void SetFonts(string fontName, int font_index, int fontSize, int fontSizeInd)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "B19FE953-4F70-4A8B-859F-B208215D9A69.tmp");
		ReportFonts reportFonts = new ReportFonts();
		reportFonts.fontName = fontName;
		reportFonts.selectedFont = font_index;
		reportFonts.fontSize = fontSize;
		reportFonts.selectedFontSizeIndex = fontSizeInd;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, reportFonts);
		fileStream.Close();
	}
}
