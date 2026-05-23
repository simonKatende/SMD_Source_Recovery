using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MarksEntry;

[Serializable]
internal class TeacherInitials
{
	private static string initials { get; set; }

	public static void SetInitials(string fullName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		TeacherInitials graph = new TeacherInitials();
		if (fullName.Length > 3)
		{
			string[] array = fullName.Split();
			foreach (string text in array)
			{
				stringBuilder.Append(text.Trim().Substring(0, 1));
			}
			initials = stringBuilder.ToString();
		}
		else
		{
			initials = fullName;
		}
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "Alien_Age_SMD_Initials");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string GetTeacherInitials()
	{
		TeacherInitials teacherInitials = new TeacherInitials();
		string empty = string.Empty;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "Alien_Age_SMD_Initials");
		if (File.Exists(path))
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				teacherInitials = (TeacherInitials)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return initials;
		}
		return "-";
	}
}
