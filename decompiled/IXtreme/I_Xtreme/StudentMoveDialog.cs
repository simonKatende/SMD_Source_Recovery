using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class StudentMoveDialog
{
	private static bool showDialog { get; set; }

	public static bool CannotShowDialog
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_STO_Dialog.tmp");
			if (File.Exists(path))
			{
				StudentMoveDialog studentMoveDialog = new StudentMoveDialog();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				studentMoveDialog = (StudentMoveDialog)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return showDialog;
			}
			return true;
		}
	}

	public static void SetDialogShowProperty(bool _showDialog)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_STO_Dialog.tmp");
		StudentMoveDialog graph = new StudentMoveDialog();
		showDialog = _showDialog;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
