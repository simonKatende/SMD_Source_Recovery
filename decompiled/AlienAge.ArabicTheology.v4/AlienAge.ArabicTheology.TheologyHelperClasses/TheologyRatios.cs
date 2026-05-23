using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.Connectivity;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

[Serializable]
public class TheologyRatios
{
	private static double bot { get; set; }

	private static double mot { get; set; }

	private static double eot { get; set; }

	private static bool processType { get; set; }

	public static double BOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TheologyRatios.tmp");
			if (File.Exists(path))
			{
				TheologyRatios theologyRatios = new TheologyRatios();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyRatios = (TheologyRatios)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return bot;
			}
			return 0.0;
		}
	}

	public static double MOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TheologyRatios.tmp");
			if (File.Exists(path))
			{
				TheologyRatios theologyRatios = new TheologyRatios();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyRatios = (TheologyRatios)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return mot;
			}
			return 100.0;
		}
	}

	public static double EOT
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TheologyRatios.tmp");
			if (File.Exists(path))
			{
				TheologyRatios theologyRatios = new TheologyRatios();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyRatios = (TheologyRatios)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return eot;
			}
			return 100.0;
		}
	}

	public static bool ProcessAsPercentages
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_TheologyRatios.tmp");
			if (File.Exists(path))
			{
				TheologyRatios theologyRatios = new TheologyRatios();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				theologyRatios = (TheologyRatios)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return processType;
			}
			return true;
		}
	}

	public static void InitializeTheologyRatios(string _class, string _semester)
	{
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		bool flag = false;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{_class}' AND SemesterId='{_semester}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TermSettings");
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			result = (double.TryParse(row["BOTEn"].ToString(), out result) ? result : 0.0);
			result2 = (double.TryParse(row["EOTEn"].ToString(), out result2) ? result2 : 0.0);
			result3 = (double.TryParse(row["MOTEn"].ToString(), out result3) ? result3 : 0.0);
			flag = Convert.ToBoolean(row["IsPercentage"]);
		}
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TheologyRatios.tmp");
		TheologyRatios graph = new TheologyRatios();
		bot = result;
		eot = result2;
		mot = result3;
		processType = flag;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
