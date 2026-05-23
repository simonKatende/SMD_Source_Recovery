using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
internal class SupplierOptions
{
	private static float activeSupplierID { get; set; }

	private static string activeSupplierCompany { get; set; }

	private static string activeEmail { get; set; }

	public static float ActiveSupplierID
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_SupplierOptions.tmp");
			SupplierOptions supplierOptions = new SupplierOptions();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			supplierOptions = (SupplierOptions)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return activeSupplierID;
		}
	}

	public static string ActiveCompanyName()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_SupplierOptions.tmp");
		SupplierOptions supplierOptions = new SupplierOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		supplierOptions = (SupplierOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeSupplierCompany;
	}

	public static string ActiveSupplierEmail()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_SupplierOptions.tmp");
		SupplierOptions supplierOptions = new SupplierOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		supplierOptions = (SupplierOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeEmail;
	}

	public static void SetActiveSupplier(float supplierId, string companyName, string supplierEmail)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_SupplierOptions.tmp");
		SupplierOptions graph = new SupplierOptions();
		activeSupplierCompany = companyName;
		activeSupplierID = supplierId;
		activeEmail = supplierEmail;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
