using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class GeneralPaper
{
	private double cutOffValue { get; set; }

	public static double Value
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_GeneralPaper.tmp");
			if (File.Exists(path))
			{
				GeneralPaper generalPaper = new GeneralPaper();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				generalPaper = (GeneralPaper)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return generalPaper.cutOffValue;
			}
			return 50.0;
		}
	}

	public static void SetGPCutoff(double cutOff)
	{
		string path = Path.Combine(Path.GetTempPath(), "SMD_GeneralPaper.tmp");
		GeneralPaper generalPaper = new GeneralPaper();
		generalPaper.cutOffValue = cutOff;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, generalPaper);
		fileStream.Close();
	}
}
