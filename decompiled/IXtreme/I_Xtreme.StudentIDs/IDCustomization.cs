using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using AlienAge.Connectivity;
using Microsoft.Win32;

namespace I_Xtreme.StudentIDs;

[Serializable]
internal class IDCustomization
{
	private static Image signatory { get; set; }

	private static DateTime issueDate { get; set; }

	private static DateTime expiryDate { get; set; }

	public static int HBColor
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("HBColor").ToString() != "0")
			{
				return Convert.ToInt32(registryKey.GetValue("HBColor").ToString());
			}
			return -65536;
		}
	}

	public static int HFColor
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("HFColor").ToString() != "0")
			{
				return Convert.ToInt32(registryKey.GetValue("HFColor").ToString());
			}
			return -1;
		}
	}

	public static int FCol1
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("FCol1").ToString() != "0")
			{
				return Convert.ToInt32(registryKey.GetValue("FCol1").ToString());
			}
			return -16777216;
		}
	}

	public static int FCol2
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("FCol2").ToString() != "0")
			{
				return Convert.ToInt32(registryKey.GetValue("FCol2").ToString());
			}
			return -256;
		}
	}

	public static int FCol3
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("FCol3").ToString() != "0")
			{
				return Convert.ToInt32(registryKey.GetValue("FCol3").ToString());
			}
			return -65536;
		}
	}

	public static string HFont
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("HFont").ToString() != string.Empty)
			{
				return registryKey.GetValue("HFont").ToString();
			}
			return "Algerian";
		}
	}

	public static decimal FontSize
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("FontSize").ToString() != "0")
			{
				return Convert.ToDecimal(registryKey.GetValue("FontSize"));
			}
			return 14m;
		}
	}

	public static Image Signatory
	{
		get
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Signatory", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "_signatory");
			if (dataSet.Tables[0].Rows.Count != 0)
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					byte[] array = new byte[0];
					array = (byte[])row["sign"];
					using MemoryStream stream = new MemoryStream(array);
					signatory = Image.FromStream(stream);
				}
			}
			return signatory;
		}
	}

	public static DateTime IssueDate
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("IssueDate").ToString() != string.Empty)
			{
				return Convert.ToDateTime(registryKey.GetValue("IssueDate").ToString());
			}
			return DateTime.Now;
		}
	}

	public static DateTime ExpiryDate
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
			if (registryKey.GetValue("ExpiryDate").ToString() != string.Empty)
			{
				return Convert.ToDateTime(registryKey.GetValue("ExpiryDate").ToString());
			}
			return DateTime.Now;
		}
	}

	public static void SetIDColors(int _hBCol, int _hFCol, int _fCol1, int _fCol2, int _fCol3)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
		registryKey.SetValue("HBColor", _hBCol);
		registryKey.SetValue("HFColor", _hFCol);
		registryKey.SetValue("FCol1", _fCol1);
		registryKey.SetValue("FCol2", _fCol2);
		registryKey.SetValue("FCol3", _fCol3);
	}

	public static void SetIDFonts(string _hFont, decimal _fontSize)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
		registryKey.SetValue("HFont", _hFont);
		registryKey.SetValue("FontSize", _fontSize);
	}

	public static void SetIDDates(DateTime issueDate, DateTime expiryDate)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\IDCustomization");
		registryKey.SetValue("IssueDate", issueDate);
		registryKey.SetValue("ExpiryDate", expiryDate);
	}
}
