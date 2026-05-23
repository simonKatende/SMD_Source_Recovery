using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class StaffOptions
{
	private static string activeStaff { get; set; }

	private static string activeStaffEmail { get; set; }

	private static string activeStaffName { get; set; }

	private static string employeeType { get; set; }

	private static DateTime payrollDate { get; set; }

	public static DateTime PayRollDate
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
			StaffOptions staffOptions = new StaffOptions();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			staffOptions = (StaffOptions)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return payrollDate;
		}
	}

	public static string ActiveStaffID()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions staffOptions = new StaffOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		staffOptions = (StaffOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeStaff;
	}

	public static string ActiveStaffEmail()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions staffOptions = new StaffOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		staffOptions = (StaffOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeStaffEmail;
	}

	public static string ActiveStaffName()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions staffOptions = new StaffOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		staffOptions = (StaffOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeStaffName;
	}

	public static string EmployeeType()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions staffOptions = new StaffOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		staffOptions = (StaffOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return employeeType;
	}

	public static void SetActiveStaff(string _activeStaff, string _staffEmail, string _staffName)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions graph = new StaffOptions();
		activeStaff = _activeStaff;
		activeStaffEmail = _staffEmail;
		activeStaffName = _staffName;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetEmployeeType(string _employeeType)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions graph = new StaffOptions();
		employeeType = _employeeType;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetPayrollDate(DateTime _payrollDate)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions graph = new StaffOptions();
		payrollDate = _payrollDate;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
