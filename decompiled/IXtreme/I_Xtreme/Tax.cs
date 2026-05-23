using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class Tax
{
	private double level1 { get; set; }

	private double level2 { get; set; }

	private double level3 { get; set; }

	private bool calcPAYE { get; set; }

	private bool calcNSSF { get; set; }

	private double perc1 { get; set; }

	private double perc2 { get; set; }

	private double perc3 { get; set; }

	private double employee_nssfRate { get; set; }

	private double employer_nssfRate { get; set; }

	public static double TaxLevel1
	{
		get
		{
			Tax tax = new Tax();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.level1;
			}
			return 235000.0;
		}
	}

	public static double TaxLevel2
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.level2;
			}
			return 335000.0;
		}
	}

	public static double TaxLevel3
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.level3;
			}
			return 410000.0;
		}
	}

	public static bool CalculateNSSF
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.calcNSSF;
			}
			return true;
		}
	}

	public static bool CalculatePAYE
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.calcPAYE;
			}
			return true;
		}
	}

	public static double PAYEPercentageLevel1
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.perc1;
			}
			return 0.1;
		}
	}

	public static double PAYEPercentageLevel2
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.perc2;
			}
			return 0.2;
		}
	}

	public static double PAYEPercentageLevel3
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.perc3;
			}
			return 0.3;
		}
	}

	public static double NSSFEmployeeContribution
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.employee_nssfRate;
			}
			return 5.0;
		}
	}

	public static double NSSFEmployerContribution
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TaxCalculations.tmp");
			if (File.Exists(path))
			{
				Tax tax = new Tax();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				tax = (Tax)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return tax.employer_nssfRate;
			}
			return 10.0;
		}
	}

	public static void SetTaxLevels(double level_1, double level_2, double level_3, double p1, double p2, double p3, double employeeCon, double employerCon, bool _calcPAYE, bool _calcNSSF)
	{
		Tax tax = new Tax();
		tax.level1 = level_1;
		tax.level2 = level_2;
		tax.level3 = level_3;
		tax.perc1 = p1;
		tax.perc2 = p2;
		tax.perc3 = p3;
		tax.employee_nssfRate = employeeCon;
		tax.employer_nssfRate = employerCon;
		tax.calcNSSF = _calcNSSF;
		tax.calcPAYE = _calcPAYE;
		string path = Path.Combine(Path.GetTempPath(), "SMD_TaxCalculations.tmp");
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, tax);
		fileStream.Close();
	}

	public static double TaxValue(double grossSalary)
	{
		double result = 0.0;
		if (grossSalary <= TaxLevel1)
		{
			result = 0.0;
		}
		else if (grossSalary > TaxLevel1 && grossSalary <= TaxLevel2)
		{
			double num = (grossSalary - TaxLevel1) * 0.1;
			result = num;
		}
		else if (grossSalary > TaxLevel2 && grossSalary <= TaxLevel3)
		{
			double num2 = (grossSalary - TaxLevel2) * 0.2 + 10000.0;
			result = num2;
		}
		else if (grossSalary > TaxLevel3 && grossSalary <= 10000000.0)
		{
			double num3 = (grossSalary - TaxLevel3) * 0.3 + 25000.0;
			result = num3;
		}
		else if (grossSalary > TaxLevel3 && grossSalary > 10000000.0)
		{
			double num4 = (grossSalary - TaxLevel3) * 0.3 + 25000.0 + (grossSalary - 10000000.0) * 0.1;
			result = num4;
		}
		return result;
	}

	public static double NetSalary(double grossSalary)
	{
		double result = 0.0;
		if (grossSalary <= TaxLevel1)
		{
			result = grossSalary;
		}
		else if (grossSalary > TaxLevel1 && grossSalary <= TaxLevel2)
		{
			double num = (grossSalary - TaxLevel1) * PAYEPercentageLevel1;
			result = grossSalary - num;
		}
		else if (grossSalary > TaxLevel2 && grossSalary <= TaxLevel3)
		{
			double num2 = (grossSalary - TaxLevel2) * PAYEPercentageLevel2 + 10000.0;
			result = grossSalary - num2;
		}
		else if (grossSalary > TaxLevel3 && grossSalary <= 10000000.0)
		{
			double num3 = (grossSalary - TaxLevel3) * PAYEPercentageLevel3 + 25000.0;
			result = grossSalary - num3;
		}
		else if (grossSalary > TaxLevel3 && grossSalary > 10000000.0)
		{
			double num4 = (grossSalary - TaxLevel3) * PAYEPercentageLevel3 + 25000.0 + (grossSalary - 10000000.0) * PAYEPercentageLevel1;
			result = grossSalary - num4;
		}
		return result;
	}

	public static double TaxBrackets(double grossSalary)
	{
		double result = 0.0;
		if (grossSalary <= TaxLevel1)
		{
			result = 0.0;
		}
		else if (grossSalary > TaxLevel1 && grossSalary <= TaxLevel2)
		{
			result = PAYEPercentageLevel1 * 100.0;
		}
		else if (grossSalary > TaxLevel2 && grossSalary <= TaxLevel3)
		{
			result = PAYEPercentageLevel2 * 100.0;
		}
		else if (grossSalary > TaxLevel3 && grossSalary <= 10000000.0)
		{
			result = PAYEPercentageLevel3 * 100.0;
		}
		else if (grossSalary > TaxLevel3 && grossSalary > 10000000.0)
		{
			result = PAYEPercentageLevel3 * 100.0;
		}
		return result;
	}
}
