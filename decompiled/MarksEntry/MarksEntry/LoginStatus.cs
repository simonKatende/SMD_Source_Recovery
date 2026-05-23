using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MarksEntry;

[Serializable]
internal class LoginStatus
{
	private static bool isLogedIn { get; set; }

	public static bool IsLoggedIn
	{
		get
		{
			LoginStatus loginStatus = new LoginStatus();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_LoginStatus.tmp");
			if (File.Exists(path))
			{
				FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				loginStatus = (LoginStatus)binaryFormatter.Deserialize(serializationStream);
				isLogedIn = IsLoggedIn;
				bool flag = false;
				return IsLoggedIn ? true : false;
			}
			return false;
		}
	}

	public static void SaveLoginStatus(bool loggedIn)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_LoginStatus.tmp");
		LoginStatus graph = new LoginStatus();
		isLogedIn = loggedIn;
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
