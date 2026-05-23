using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

[Serializable]
public class InputLanguage
{
	private string lang { get; set; }

	public static string Language
	{
		get
		{
			InputLanguage inputLanguage = new InputLanguage();
			string path = Path.Combine(Path.GetTempPath(), "SMD_ArTheologyLang.tmp");
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				inputLanguage = (InputLanguage)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return inputLanguage.lang;
		}
		set
		{
			InputLanguage graph = new InputLanguage
			{
				lang = value
			};
			string path = Path.Combine(Path.GetTempPath(), "SMD_ArTheologyLang.tmp");
			using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(fileStream, graph);
			fileStream.Close();
		}
	}
}
