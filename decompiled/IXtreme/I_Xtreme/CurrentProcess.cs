using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class CurrentProcess
{
	private static bool processFinished { get; set; }

	public static bool ProcessFinished
	{
		get
		{
			return processFinished;
		}
		set
		{
			CurrentProcess currentProcess = new CurrentProcess();
			string path = Path.Combine(Path.GetTempPath(), "SMD_CP.tmp");
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentProcess = (CurrentProcess)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
	}

	public static void ProcessCompleted(bool status)
	{
		CurrentProcess graph = new CurrentProcess();
		processFinished = status;
		string path = Path.Combine(Path.GetTempPath(), "SMD_CP.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
