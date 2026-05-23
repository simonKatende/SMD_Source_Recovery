using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
public class BiometricDeviceInMemory
{
	private static string file = "biometricdevice.tmp";

	private bool deviceInMemory { get; set; }

	private int machineNumber { get; set; }

	private int port { get; set; }

	private string ipAddress { get; set; }

	public static bool DeviceInMemory
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, file);
			if (File.Exists(path))
			{
				BiometricDeviceInMemory biometricDeviceInMemory = new BiometricDeviceInMemory();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				biometricDeviceInMemory = (BiometricDeviceInMemory)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return biometricDeviceInMemory.deviceInMemory;
			}
			return false;
		}
	}

	public static int MachineNumber
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, file);
			if (File.Exists(path))
			{
				BiometricDeviceInMemory biometricDeviceInMemory = new BiometricDeviceInMemory();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				biometricDeviceInMemory = (BiometricDeviceInMemory)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return biometricDeviceInMemory.machineNumber;
			}
			return 1;
		}
	}

	public static string IpAddress
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, file);
			if (File.Exists(path))
			{
				BiometricDeviceInMemory biometricDeviceInMemory = new BiometricDeviceInMemory();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				biometricDeviceInMemory = (BiometricDeviceInMemory)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return biometricDeviceInMemory.ipAddress;
			}
			return "192.168.1.200";
		}
	}

	public static int Port
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, file);
			if (File.Exists(path))
			{
				BiometricDeviceInMemory biometricDeviceInMemory = new BiometricDeviceInMemory();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				biometricDeviceInMemory = (BiometricDeviceInMemory)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return biometricDeviceInMemory.port;
			}
			return 4370;
		}
	}

	public static void SetInMemoryDevice(string _ipaddress, bool _deviceInMemory, int _machineNumber, int port)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, file);
		BiometricDeviceInMemory biometricDeviceInMemory = new BiometricDeviceInMemory();
		biometricDeviceInMemory.ipAddress = _ipaddress;
		biometricDeviceInMemory.deviceInMemory = _deviceInMemory;
		biometricDeviceInMemory.machineNumber = _machineNumber;
		biometricDeviceInMemory.port = port;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, biometricDeviceInMemory);
		fileStream.Close();
	}
}
