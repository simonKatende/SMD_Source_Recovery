using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
internal class SubjectDropingMode
{
	private static bool dropingMode { get; set; }

	public static bool MainFormDrop
	{
		get
		{
			SubjectDropingMode subjectDropingMode = new SubjectDropingMode();
			FileStream fileStream = new FileStream(Path.Combine(Path.GetTempPath(), "SMD_DropMode.tmp"), FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			subjectDropingMode = (SubjectDropingMode)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dropingMode;
		}
	}

	public static void DropFromMainForm(bool DropMode)
	{
		SubjectDropingMode graph = new SubjectDropingMode();
		dropingMode = DropMode;
		FileStream fileStream = new FileStream(Path.Combine(Path.GetTempPath(), "SMD_DropMode.tmp"), FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
