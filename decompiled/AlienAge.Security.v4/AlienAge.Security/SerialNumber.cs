using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace AlienAge.Security;

public class SerialNumber
{
	public static string GetSerialNumberiXtreme(string ReqCode, string SchoolId)
	{
		char[] array = SchoolId.ToCharArray();
		string text = string.Format(array[0] + "{1}" + array[1] + "{6}" + array[2] + "{3}" + array[3] + "{7}" + array[4] + "{4}{0}{5}{2}", ReqCode.Substring(4, 4), ReqCode.Substring(28, 4), ReqCode.Substring(12, 4), ReqCode.Substring(20, 4), ReqCode.Substring(0, 4), ReqCode.Substring(16, 4), ReqCode.Substring(24, 4), ReqCode.Substring(8, 4));
		return text.Substring(0, 30);
	}

	public static string GetSchoolCodeMapping()
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string path = Path.Combine(folderPath, "School Dynamics");
			string text = Path.Combine(path, "SMDServices_SchoolRef.txt");
			if (!File.Exists(text))
			{
				throw new FileNotFoundException("School Ref. config file not found at: " + text);
			}
			FileInfo fileInfo = new FileInfo(text);
			FileSecurity accessControl = fileInfo.GetAccessControl();
			accessControl.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null), FileSystemRights.Read, AccessControlType.Allow));
			accessControl.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.Read, AccessControlType.Allow));
			fileInfo.SetAccessControl(accessControl);
			string text2 = File.ReadAllText(text).Trim();
			if (string.IsNullOrWhiteSpace(text2))
			{
				throw new InvalidDataException("School Ref. config string is empty");
			}
			return text2;
		}
		catch (UnauthorizedAccessException ex)
		{
			EventLog.WriteEntry("School Dynamics Services", "School Ref. config access denied. " + ex.Message, EventLogEntryType.Error, 1001);
			throw;
		}
		catch (FileNotFoundException ex2)
		{
			EventLog.WriteEntry("School Dynamics Services", "School Ref. config file missing. " + ex2.Message, EventLogEntryType.Error, 1002);
			throw;
		}
		catch (Exception ex3)
		{
			EventLog.WriteEntry("School Dynamics Services", "School Ref. config error: " + ex3.Message, EventLogEntryType.Error, 1003);
			throw;
		}
	}

	public static string GetTermMapping()
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			string path = Path.Combine(folderPath, "School Dynamics");
			string text = Path.Combine(path, "SMDServices_Term.txt");
			if (!File.Exists(text))
			{
				throw new FileNotFoundException("Term config file not found at: " + text);
			}
			FileInfo fileInfo = new FileInfo(text);
			FileSecurity accessControl = fileInfo.GetAccessControl();
			accessControl.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null), FileSystemRights.Read, AccessControlType.Allow));
			accessControl.AddAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().Name, FileSystemRights.Read, AccessControlType.Allow));
			fileInfo.SetAccessControl(accessControl);
			string text2 = File.ReadAllText(text).Trim();
			if (string.IsNullOrWhiteSpace(text2))
			{
				throw new InvalidDataException("Term. config string is empty");
			}
			return text2;
		}
		catch (UnauthorizedAccessException ex)
		{
			EventLog.WriteEntry("School Dynamics Services", "Term access denied. " + ex.Message, EventLogEntryType.Error, 1001);
			throw;
		}
		catch (FileNotFoundException ex2)
		{
			EventLog.WriteEntry("School Dynamics Services", "Term config file missing. " + ex2.Message, EventLogEntryType.Error, 1002);
			throw;
		}
		catch (Exception ex3)
		{
			EventLog.WriteEntry("School Dynamics Services", "Term config error: " + ex3.Message, EventLogEntryType.Error, 1003);
			throw;
		}
	}

	public static void SetSchoolCodeMapping(string SchoolRef)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "School Dynamics");
		Directory.CreateDirectory(text);
		string path = Path.Combine(text, "SMDServices_SchoolRef.txt");
		File.WriteAllText(path, SchoolRef);
		FileSecurity fileSecurity = new FileSecurity();
		fileSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, AccessControlType.Allow));
		File.SetAccessControl(path, fileSecurity);
	}

	public static void SetTermMapping(string Term)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "School Dynamics");
		Directory.CreateDirectory(text);
		string path = Path.Combine(text, "SMDServices_Term.txt");
		File.WriteAllText(path, Term);
		FileSecurity fileSecurity = new FileSecurity();
		fileSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, AccessControlType.Allow));
		File.SetAccessControl(path, fileSecurity);
	}

	public static string GetSchoolCode(string connectionString)
	{
		string arg = CryptorEngine.Encrypt("MainKeyValidator");
		string result = "XXXXX";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_StudentIDSNo WHERE _vvvv='{arg}'", connectionString);
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			result = dataTable.Rows[0]["_ccccc"].ToString();
		}
		return result;
	}

	public static string GetSerialNumberiXtremeTrial(string ReqCode, string SchoolId)
	{
		char[] array = SchoolId.ToCharArray();
		int length = ReqCode.Length;
		string text = ReqCode.Substring(length - 3, 3);
		string value = text.Substring(0, 1);
		string value2 = text.Substring(1, 1);
		string value3 = text.Substring(2, 1);
		string text2 = string.Format("{1}{6}{3}{7}{4}{0}{5}{2}", ReqCode.Substring(8, 4), ReqCode.Substring(16, 4), ReqCode.Substring(4, 4), ReqCode.Substring(0, 4), ReqCode.Substring(12, 4), ReqCode.Substring(28, 4), ReqCode.Substring(20, 4), ReqCode.Substring(24, 4));
		string text3 = text2.Substring(0, 21);
		string text4 = text3.Insert(0, array[0].ToString());
		string text5 = text4.Insert(5, array[1].ToString());
		string text6 = text5.Insert(10, array[2].ToString());
		string text7 = text6.Insert(15, array[3].ToString());
		string text8 = text7.Insert(20, array[4].ToString());
		string text9 = text8.Insert(21, "-");
		string text10 = text9.Insert(23, value);
		string text11 = text10.Insert(26, value2);
		return text11.Insert(29, value3);
	}

	public static string TestDays(string TestSerialNumber)
	{
		string text = TestSerialNumber.Substring(23, 1);
		string text2 = TestSerialNumber.Substring(26, 1);
		string text3 = TestSerialNumber.Substring(29, 1);
		return text + text2 + text3;
	}

	public static string SchoolCode(string SerialNumber)
	{
		string text = SerialNumber.Substring(0, 1);
		string text2 = SerialNumber.Substring(5, 1);
		string text3 = SerialNumber.Substring(10, 1);
		string text4 = SerialNumber.Substring(15, 1);
		string text5 = SerialNumber.Substring(20, 1);
		return text + text2 + text3 + text4 + text5;
	}
}
