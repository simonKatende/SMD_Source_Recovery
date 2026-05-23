using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class MultipleFeesPayment
{
	private static DataTable dTable;

	private static bool useMultipleItems;

	public static bool UseMultipleItems
	{
		get
		{
			return useMultipleItems;
		}
		set
		{
			string path = Path.Combine(Path.GetTempPath(), "SMD_MPI.tmp");
			MultipleFeesPayment multipleFeesPayment = new MultipleFeesPayment();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			multipleFeesPayment = (MultipleFeesPayment)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
	}

	public static DataTable ItemsList
	{
		get
		{
			return dTable;
		}
		set
		{
			string path = Path.Combine(Path.GetTempPath(), "SMD_MPI.tmp");
			MultipleFeesPayment multipleFeesPayment = new MultipleFeesPayment();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			multipleFeesPayment = (MultipleFeesPayment)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
	}

	public static void UseMultiplePayMode(bool payMode)
	{
		string path = Path.Combine(Path.GetTempPath(), "SMD_MPI.tmp");
		MultipleFeesPayment graph = new MultipleFeesPayment();
		useMultipleItems = payMode;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePayableItems(DataTable D_T)
	{
		string path = Path.Combine(Path.GetTempPath(), "SMD_MPI.tmp");
		MultipleFeesPayment graph = new MultipleFeesPayment();
		dTable = D_T;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
