using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
internal class StudentAccounts
{
	public static string FeesAndOtherRequirements = "Fees + Other requirements";

	public static string FeesList = "Fees lists";

	public static string OtherRequirements = "Other requirements";

	private static string reportType { get; set; }

	private static double feesBalanceGreaterThan { get; set; }

	private static double feesBalanceLessThan { get; set; }

	public static double FBGreaterThanEqualTo
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StudentAccounts.tmp");
			StudentAccounts studentAccounts = new StudentAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentAccounts = (StudentAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return feesBalanceGreaterThan;
		}
	}

	public static double FBLessThanEqualTo
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StudentAccounts.tmp");
			StudentAccounts studentAccounts = new StudentAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentAccounts = (StudentAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return feesBalanceLessThan;
		}
	}

	public static string ReportType
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StudentAccounts.tmp");
			StudentAccounts studentAccounts = new StudentAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentAccounts = (StudentAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return reportType;
		}
	}

	public static void SetReportBalances(double feesGreaterThan, double feesLessThan)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentAccounts.tmp");
		StudentAccounts graph = new StudentAccounts();
		feesBalanceGreaterThan = feesGreaterThan;
		feesBalanceLessThan = feesLessThan;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetReportType(string _reportType)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentAccounts.tmp");
		StudentAccounts graph = new StudentAccounts();
		reportType = _reportType;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
