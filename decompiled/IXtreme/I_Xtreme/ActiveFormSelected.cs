using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class ActiveFormSelected
{
	private string activeForm { get; set; }

	public static string CurrentActiveForm
	{
		get
		{
			string empty = string.Empty;
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ActiveForm.tmp");
			if (File.Exists(path))
			{
				ActiveFormSelected activeFormSelected = new ActiveFormSelected();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				activeFormSelected = (ActiveFormSelected)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return activeFormSelected.activeForm;
			}
			return "No Form";
		}
	}

	public static void SetActiveForm(string _activeForm)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_ActiveForm.tmp");
		ActiveFormSelected activeFormSelected = new ActiveFormSelected();
		activeFormSelected.activeForm = _activeForm;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, activeFormSelected);
		fileStream.Close();
	}
}
