using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MarksEntry;

[Serializable]
public class CustomeTheme_2
{
	public int CheckedThemeIndex { get; set; }

	public static void SaveThemes(int themeIndex)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarksEntry_Themes.tmp");
		CustomeTheme_2 graph = new CustomeTheme_2
		{
			CheckedThemeIndex = themeIndex
		};
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
