using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.ReportDesigner.Properties;

namespace AlienAge.ReportDesigner;

[Serializable]
public class ReportBoundaryHangler
{
	private Image boundaryImage { get; set; }

	public static Image BoundaryDesign
	{
		get
		{
			Image image = null;
			ReportBoundaryHangler reportBoundaryHangler = new ReportBoundaryHangler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_WMI.tmp");
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				reportBoundaryHangler = (ReportBoundaryHangler)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return reportBoundaryHangler.boundaryImage;
			}
			return Resources.NoTheme;
		}
	}

	public static void SaveBoundaryToMemory(string boundaryText)
	{
		Image image = null;
		switch (boundaryText)
		{
		case "Default":
			image = Resources.NoTheme;
			break;
		case "Art Obsession":
			image = Resources.Art_Obsession;
			break;
		case "Classic":
			image = Resources.Classic;
			break;
		case "Grandmother":
			image = Resources.Grandmother;
			break;
		case "Summertime":
			image = Resources.Summertime;
			break;
		case "Candy Party":
			image = Resources.Candy_Party;
			break;
		case "Curious Bird":
			image = Resources.Curious_Bird;
			break;
		case "Festive Season":
			image = Resources.Festive_Season;
			break;
		case "Forbidden Tree":
			image = Resources.Forbidden_Tree;
			break;
		case "Green House":
			image = Resources.Green_House;
			break;
		case "Elegant":
			image = Resources.Elegant;
			break;
		case "Sketch Mania":
			image = Resources.Sketch_Mania;
			break;
		case "Alien Age":
			image = Resources.alien_age;
			break;
		case "Birthday Cake":
			image = Resources.Birthday_Cake;
			break;
		}
		ReportBoundaryHangler reportBoundaryHangler = new ReportBoundaryHangler();
		reportBoundaryHangler.boundaryImage = image;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_WMI.tmp");
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, reportBoundaryHangler);
		fileStream.Close();
	}
}
