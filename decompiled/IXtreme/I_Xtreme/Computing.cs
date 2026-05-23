using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class Computing
{
	private double cutOffValue { get; set; }

	public static double Value
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_Computing.tmp");
			if (File.Exists(path))
			{
				Computing computing = new Computing();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				computing = (Computing)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return computing.cutOffValue;
			}
			return 50.0;
		}
	}

	public static void SetCompCutoff(double cutOff)
	{
		string path = Path.Combine(Path.GetTempPath(), "SMD_Computing.tmp");
		Computing computing = new Computing();
		computing.cutOffValue = cutOff;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, computing);
		fileStream.Close();
	}
}
