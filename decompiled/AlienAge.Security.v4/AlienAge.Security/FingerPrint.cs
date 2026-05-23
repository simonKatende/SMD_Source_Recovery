using System;
using System.Data;
using System.Data.SqlClient;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using AlienAge.Connectivity;

namespace AlienAge.Security;

public class FingerPrint
{
	private static SqlTransaction trans;

	public static int SchoolType
	{
		get
		{
			int result = -1;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SchoolInfo");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["S_T"].ToString() == "6ez8aEZy")
				{
					result = 88;
				}
				else if (dataSet.Tables[0].Rows[0]["S_T"].ToString() == "ea/Hl6iT")
				{
					result = 55;
				}
			}
			return result;
		}
	}

	public static string Category
	{
		get
		{
			string result = "No defined";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SchoolInfo");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["S_T"].ToString() == "6ez8aEZy")
				{
					result = "Secondary";
				}
				else if (dataSet.Tables[0].Rows[0]["S_T"].ToString() == "ea/Hl6iT")
				{
					result = "Primary";
				}
			}
			return result;
		}
	}

	public static string SchoolName
	{
		get
		{
			string result = string.Empty;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SchoolInfo");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					result = CryptorEngine.Decrypt(row["SchoolName"].ToString());
				}
			}
			return result;
		}
	}

	public static string Village
	{
		get
		{
			string text = string.Empty;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "location");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					text = CryptorEngine.Decrypt(row["location"].ToString());
				}
			}
			return text.ToUpper();
		}
	}

	public static string ContactNo
	{
		get
		{
			string result = string.Empty;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "contact");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					result = CryptorEngine.Decrypt(row["mobileContact"].ToString());
				}
			}
			return result;
		}
	}

	public static string GenerateRequestCode(string sSchool, string sContact, string sVillage, int TypeId, string sType)
	{
		string word = sSchool + sVillage + sContact;
		string text = HelperClasses.CharacterCodes(word, TypeId);
		string text2 = text;
		return TypeId + text2;
	}

	private static string GetHash(string s)
	{
		using MD5 mD = new MD5CryptoServiceProvider();
		ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
		byte[] bytes = aSCIIEncoding.GetBytes(s);
		return GetHexString(mD.ComputeHash(bytes));
	}

	private static string GetHexString(byte[] bt)
	{
		string text = string.Empty;
		for (int i = 0; i < bt.Length; i++)
		{
			byte b = bt[i];
			int num = b;
			int num2 = num & 0xF;
			int num3 = (num >> 4) & 0xF;
			text = ((num3 <= 9) ? (text + num3) : (text + (char)(num3 - 10 + 65)));
			text = ((num2 <= 9) ? (text + num2) : (text + (char)(num2 - 10 + 65)));
			if (i + 1 != bt.Length && (i + 1) % 2 == 0)
			{
				text += "-";
			}
		}
		return text;
	}

	private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
	{
		string text = "";
		using (ManagementClass managementClass = new ManagementClass(wmiClass))
		{
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementObject item in instances)
			{
				if (item[wmiMustBeTrue].ToString() == "True" && text == "")
				{
					try
					{
						text = item[wmiProperty].ToString();
					}
					catch
					{
						continue;
					}
					break;
				}
			}
		}
		return text;
	}

	private static string identifier(string wmiClass, string wmiProperty)
	{
		string text = "";
		using (ManagementClass managementClass = new ManagementClass(wmiClass))
		{
			ManagementObjectCollection instances = managementClass.GetInstances();
			foreach (ManagementObject item in instances)
			{
				if (text == "")
				{
					try
					{
						text = item[wmiProperty].ToString();
					}
					catch
					{
						continue;
					}
					break;
				}
			}
		}
		return text;
	}

	private static string cpuId()
	{
		string text = identifier("Win32_Processor", "UniqueId");
		if (text == "")
		{
			text = identifier("Win32_Processor", "ProcessorId");
			if (text == "")
			{
				text = identifier("Win32_Processor", "Name");
				if (text == "")
				{
					text = identifier("Win32_Processor", "Manufacturer");
				}
				text += identifier("Win32_Processor", "MaxClockSpeed");
			}
		}
		return text;
	}

	private static string biosId()
	{
		return identifier("Win32_BIOS", "Manufacturer") + identifier("Win32_BIOS", "SMBIOSBIOSVersion") + identifier("Win32_BIOS", "IdentificationCode") + identifier("Win32_BIOS", "SerialNumber") + identifier("Win32_BIOS", "ReleaseDate") + identifier("Win32_BIOS", "Version");
	}

	private static string diskId()
	{
		return identifier("Win32_DiskDrive", "Model") + identifier("Win32_DiskDrive", "Manufacturer") + identifier("Win32_DiskDrive", "Signature") + identifier("Win32_DiskDrive", "TotalHeads");
	}

	private static string baseId()
	{
		return identifier("Win32_BaseBoard", "Model") + identifier("Win32_BaseBoard", "Manufacturer") + identifier("Win32_BaseBoard", "Name") + identifier("Win32_BaseBoard", "SerialNumber");
	}

	private static string videoId()
	{
		return identifier("Win32_VideoController", "DriverVersion") + identifier("Win32_VideoController", "Name");
	}

	private static string macId()
	{
		return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
	}

	public static void SaveSchoolInfo(string sSchool, string sContact, string sVillage, string LicensedBy, string SchoolCode)
	{
		using SqlConnection sqlConnection = new SqlConnection();
		string plainText = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(sVillage.ToLower().Trim());
		sqlConnection.Open();
		trans = sqlConnection.BeginTransaction();
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.Connection = sqlConnection;
		sqlCommand.Transaction = trans;
		sqlCommand.CommandText = $"INSERT INTO SchoolDetails (SchoolName,location,mobileContact,LicensedBy,SchoolCode) VALUES ('{CryptorEngine.Encrypt(sSchool.Trim().ToUpper())}','{CryptorEngine.Encrypt(sContact)}','{CryptorEngine.Encrypt(plainText)}','{LicensedBy}','{SchoolCode}')";
		sqlCommand.CommandType = CommandType.Text;
		using (SqlCommand sqlCommand2 = sqlCommand)
		{
			sqlCommand2.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Connection = sqlConnection,
			Transaction = trans,
			CommandText = $"INSERT INTO tbl_BankCharges (Particulars,BankCharges,CaptureDate) VALUES ('Default Charges',99996666234,'{DateTime.Now.ToOADate()}')",
			CommandType = CommandType.Text
		})
		{
			sqlCommand3.ExecuteNonQuery();
		}
		trans.Commit();
		sqlConnection.Close();
	}
}
