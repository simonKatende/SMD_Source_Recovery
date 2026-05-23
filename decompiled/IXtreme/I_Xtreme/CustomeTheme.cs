using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
public class CustomeTheme
{
	public string ThemeName { get; set; }

	public static void SaveThemes(string myTheme)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_Themes.tmp");
		CustomeTheme graph = new CustomeTheme
		{
			ThemeName = myTheme
		};
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
