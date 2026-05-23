using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class DebitorHandler
{
	private int generalPurposeAccountNo { get; set; }

	private string narration { get; set; }

	private int debitorAccountNo { get; set; }

	private string debitorRef { get; set; }

	private string debitorName { get; set; }

	private string generalPurposeReason { get; set; }

	public static int GeneralPurposeAccountNo
	{
		get
		{
			DebitorHandler debitorHandler = new DebitorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				debitorHandler = (DebitorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return debitorHandler.generalPurposeAccountNo;
		}
	}

	public static int DebitorAccountNo
	{
		get
		{
			DebitorHandler debitorHandler = new DebitorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				debitorHandler = (DebitorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return debitorHandler.debitorAccountNo;
		}
	}

	public static string Narration
	{
		get
		{
			DebitorHandler debitorHandler = new DebitorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				debitorHandler = (DebitorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return debitorHandler.narration;
		}
	}

	public static string DebitorRef
	{
		get
		{
			DebitorHandler debitorHandler = new DebitorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				debitorHandler = (DebitorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return debitorHandler.debitorRef;
		}
	}

	public static string DebitorName
	{
		get
		{
			DebitorHandler debitorHandler = new DebitorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				debitorHandler = (DebitorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return debitorHandler.debitorName;
		}
	}

	public static string GeneralPurposeReason
	{
		get
		{
			DebitorHandler debitorHandler = new DebitorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				debitorHandler = (DebitorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return debitorHandler.generalPurposeReason;
		}
	}

	public static void SetCreditPaymentParameters(int generalPurposeAccountNo, string narration, int debitorAccountNo, string debitorRef, string debitorName, string generalPurposeReason)
	{
		DebitorHandler debitorHandler = new DebitorHandler();
		debitorHandler.generalPurposeAccountNo = generalPurposeAccountNo;
		debitorHandler.narration = narration;
		debitorHandler.debitorAccountNo = debitorAccountNo;
		debitorHandler.debitorRef = debitorRef;
		debitorHandler.debitorName = debitorName;
		debitorHandler.generalPurposeReason = generalPurposeReason;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_DebitorHandler.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, debitorHandler);
		fileStream.Close();
	}
}
