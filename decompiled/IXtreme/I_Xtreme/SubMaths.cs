using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class SubMaths
{
	private double cutOffValue { get; set; }

	public static double Value
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_SubMath.tmp");
			if (File.Exists(path))
			{
				SubMaths subMaths = new SubMaths();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				subMaths = (SubMaths)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return subMaths.cutOffValue;
			}
			return 50.0;
		}
	}

	public static void SetMathCutoff(double cutOff)
	{
		string path = Path.Combine(Path.GetTempPath(), "SMD_SubMath.tmp");
		SubMaths subMaths = new SubMaths();
		subMaths.cutOffValue = cutOff;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, subMaths);
		fileStream.Close();
	}
}
