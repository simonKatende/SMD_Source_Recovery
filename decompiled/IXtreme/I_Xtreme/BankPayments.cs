using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace I_Xtreme;

[Serializable]
internal class BankPayments
{
	public enum BankingTransaction
	{
		Deposit,
		Withdraw,
		CashTransfer
	}

	public enum ChequeReportType
	{
		AllCheques,
		Cancelled,
		NonCancelled,
		Deposits,
		Withdraws
	}

	private static string bankTrans { get; set; }

	private static string chequeReportDisplayType { get; set; }

	public static int SelectedBankIndex
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
			if (registryKey.GetValue("BankIndex").ToString() == string.Empty)
			{
				return -1;
			}
			return Convert.ToInt32(registryKey.GetValue("BankIndex"));
		}
	}

	public static double BankCharges
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
			return Convert.ToDouble(registryKey.GetValue("BankCharges"));
		}
	}

	public static bool RememberBank
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
			if (Convert.ToInt32(registryKey.GetValue("RememberBank").ToString()) == 0)
			{
				return false;
			}
			if (Convert.ToInt32(registryKey.GetValue("RememberBank").ToString()) == 1)
			{
				return true;
			}
			return false;
		}
	}

	public static string SelectedBank
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
			return registryKey.GetValue("selectedBank").ToString();
		}
	}

	public static string BankName
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
			if (registryKey.GetValue("SelectedBank").ToString() != string.Empty)
			{
				return registryKey.GetValue("SelectedBank").ToString();
			}
			return "No Bank Selected.";
		}
	}

	public static string BankingTransactionType
	{
		get
		{
			string empty = string.Empty;
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "IXtreme_Banking.tmp");
			if (File.Exists(path))
			{
				BankPayments bankPayments = new BankPayments();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				bankPayments = (BankPayments)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return bankTrans;
			}
			return "No Transaction";
		}
	}

	public static string ChequeReportDisplayType
	{
		get
		{
			string empty = string.Empty;
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "IXtreme_Banking.tmp");
			if (File.Exists(path))
			{
				BankPayments bankPayments = new BankPayments();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				bankPayments = (BankPayments)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return chequeReportDisplayType;
			}
			return "No Transaction";
		}
	}

	public static void StoreBank(string BankId, string BankName)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
		registryKey.SetValue("SelectedBank", BankId);
		registryKey.SetValue("SelectedBank", BankName);
	}

	public static void BankIndex(string bankIndex)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
		registryKey.SetValue("BankIndex", bankIndex);
	}

	public static void RememberThisBank(int rememberBank)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
		registryKey.SetValue("RememberBank", rememberBank);
	}

	public static void SetBankCharges(double bankCharges)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Banking");
		registryKey.SetValue("BankCharges", bankCharges);
	}

	public static void SetBankingTransaction(string _bankTra)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "IXtreme_Banking.tmp");
		BankPayments graph = new BankPayments();
		bankTrans = _bankTra;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetChequeReport(string _chequeReport)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "IXtreme_Banking.tmp");
		BankPayments graph = new BankPayments();
		chequeReportDisplayType = _chequeReport;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
