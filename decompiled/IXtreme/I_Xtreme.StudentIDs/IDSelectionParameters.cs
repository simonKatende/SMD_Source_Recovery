using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.StudentIDs;

[Serializable]
internal class IDSelectionParameters
{
	private string selectedStream { get; set; }

	private string selectedClass { get; set; }

	public static string StreamID
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_IDSelPar.bin");
			IDSelectionParameters iDSelectionParameters = new IDSelectionParameters();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			iDSelectionParameters = (IDSelectionParameters)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return iDSelectionParameters.selectedStream;
		}
	}

	public static string ClassID
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_IDSelPar.bin");
			IDSelectionParameters iDSelectionParameters = new IDSelectionParameters();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			iDSelectionParameters = (IDSelectionParameters)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return iDSelectionParameters.selectedClass;
		}
	}

	public static void SetIDParameters(string _stream, string _class)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_IDSelPar.bin");
		IDSelectionParameters iDSelectionParameters = new IDSelectionParameters();
		iDSelectionParameters.selectedStream = _stream;
		iDSelectionParameters.selectedClass = _class;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, iDSelectionParameters);
		fileStream.Close();
	}
}
