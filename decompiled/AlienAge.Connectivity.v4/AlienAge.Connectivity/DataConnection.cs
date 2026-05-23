using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace AlienAge.Connectivity;

[Serializable]
public class DataConnection
{
	private static string fileName = Path.Combine(Path.GetTempPath(), Application.ProductName.ToString() + "_AlienAge_DBConnect.tmp");

	private static string fileNameLocal = Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory) + "DbConnect\\" + Application.ProductName.ToString() + "_AlienAge_DBConnect.tmp";

	private string serverPassword { get; set; }

	private string serverUID { get; set; }

	private string serverPort { get; set; }

	private string databaseName { get; set; }

	private string serverName { get; set; }

	private string connectToDatabase { get; set; }

	private bool databaseConnected { get; set; }

	private string serverPasswordL { get; set; }

	private string serverUIDL { get; set; }

	private string serverPortL { get; set; }

	private string databaseNameL { get; set; }

	private string serverNameL { get; set; }

	private string connectToDatabaseL { get; set; }

	private bool databaseConnectedL { get; set; }

	public static string ServerPassword()
	{
		if (File.Exists(fileName))
		{
			DataConnection dataConnection = new DataConnection();
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			dataConnection = (DataConnection)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataConnection.serverPassword;
		}
		return string.Empty;
	}

	public static string ServerUID()
	{
		if (File.Exists(fileName))
		{
			DataConnection dataConnection = new DataConnection();
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			dataConnection = (DataConnection)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataConnection.serverUID;
		}
		return "sa";
	}

	public static string ServerPort()
	{
		if (File.Exists(fileName))
		{
			DataConnection dataConnection = new DataConnection();
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			dataConnection = (DataConnection)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataConnection.serverPort;
		}
		return "1433";
	}

	public static string DatabaseName()
	{
		if (File.Exists(fileName))
		{
			DataConnection dataConnection = new DataConnection();
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			dataConnection = (DataConnection)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataConnection.databaseName;
		}
		return string.Empty;
	}

	public static string ServerName()
	{
		if (File.Exists(fileName))
		{
			DataConnection dataConnection = new DataConnection();
			FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			dataConnection = (DataConnection)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataConnection.serverName;
		}
		return Environment.MachineName;
	}

	public static void SaveConnectionString(string database, string _password, string server, string uid, string _port)
	{
		DataConnection dataConnection = new DataConnection();
		dataConnection.databaseName = database;
		dataConnection.serverPassword = _password;
		dataConnection.serverName = server;
		dataConnection.serverUID = uid;
		dataConnection.serverPort = _port;
		FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, dataConnection);
		fileStream.Close();
	}

	public static string ConnectToDatabase()
	{
		try
		{
			return $"Data Source={ServerName()},{ServerPort()};Database={DatabaseName()};UID={ServerUID()};PWD={ServerPassword()}";
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	public static bool DatabaseConnected()
	{
		bool flag = false;
		try
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectToDatabase());
			sqlConnection.Open();
			if (sqlConnection.State == ConnectionState.Open)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void SaveConnectionStringL(string database, string _password, string server, string uid, string _port)
	{
		string contents = "Data Source=" + server + "," + _port + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + _password + ";";
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "School Dynamics");
		Directory.CreateDirectory(text);
		string path = Path.Combine(text, "SMDServices_ConnectionString.txt");
		File.WriteAllText(path, contents);
		FileSecurity fileSecurity = new FileSecurity();
		fileSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, AccessControlType.Allow));
		File.SetAccessControl(path, fileSecurity);
	}

	public static string ConnectToDatabaseLocal()
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string path = Path.Combine(folderPath, "School Dynamics");
			string text = Path.Combine(path, "SMDServices_ConnectionString.txt");
			if (!File.Exists(text))
			{
				throw new FileNotFoundException("Database connection file not found at: " + text);
			}
			FileInfo fileInfo = new FileInfo(text);
			FileSecurity accessControl = fileInfo.GetAccessControl();
			accessControl.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null), FileSystemRights.Read, AccessControlType.Allow));
			accessControl.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.Read, AccessControlType.Allow));
			fileInfo.SetAccessControl(accessControl);
			string text2 = File.ReadAllText(text).Trim();
			if (string.IsNullOrWhiteSpace(text2))
			{
				throw new InvalidDataException("Connection string is empty");
			}
			return text2;
		}
		catch (UnauthorizedAccessException ex)
		{
			EventLog.WriteEntry("School Dynamics Services", "Service database access denied. " + ex.Message, EventLogEntryType.Error, 1001);
			throw;
		}
		catch (FileNotFoundException ex2)
		{
			EventLog.WriteEntry("School Dynamics Services", "Database connection file missing. " + ex2.Message, EventLogEntryType.Error, 1002);
			throw;
		}
		catch (Exception ex3)
		{
			EventLog.WriteEntry("School Dynamics Services", "Database connection error: " + ex3.Message, EventLogEntryType.Error, 1003);
			throw;
		}
	}

	public static bool DatabaseConnectedL()
	{
		bool flag = false;
		try
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectToDatabaseLocal());
			sqlConnection.Open();
			if (sqlConnection.State == ConnectionState.Open)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
