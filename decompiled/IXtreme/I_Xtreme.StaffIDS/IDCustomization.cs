using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.Connectivity;

namespace I_Xtreme.StaffIDS;

[Serializable]
internal class IDCustomization
{
	private DateTime validity { get; set; }

	private static Image signatory { get; set; }

	public static DateTime Validity
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_SID.tmp");
			IDCustomization iDCustomization = new IDCustomization();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			iDCustomization = (IDCustomization)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return iDCustomization.validity;
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

	public static void SetValidyTime(DateTime _validity)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_SID.tmp");
		IDCustomization iDCustomization = new IDCustomization();
		iDCustomization.validity = _validity;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, iDCustomization);
		fileStream.Close();
	}
}
