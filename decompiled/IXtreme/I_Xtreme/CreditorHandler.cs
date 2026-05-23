using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class CreditorHandler
{
	private string generalPurposeAccountNo { get; set; }

	private string narration { get; set; }

	private string creditorAccountNo { get; set; }

	private string creditorRef { get; set; }

	private string creditorName { get; set; }

	private string generalPurposeReason { get; set; }

	public static string GeneralPurposeAccountNo
	{
		get
		{
			CreditorHandler creditorHandler = new CreditorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				creditorHandler = (CreditorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return creditorHandler.generalPurposeAccountNo;
		}
	}

	public static string CreditorAccountNo
	{
		get
		{
			CreditorHandler creditorHandler = new CreditorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				creditorHandler = (CreditorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return creditorHandler.creditorAccountNo;
		}
	}

	public static string Narration
	{
		get
		{
			CreditorHandler creditorHandler = new CreditorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				creditorHandler = (CreditorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return creditorHandler.narration;
		}
	}

	public static string CreditorRef
	{
		get
		{
			CreditorHandler creditorHandler = new CreditorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				creditorHandler = (CreditorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return creditorHandler.creditorRef;
		}
	}

	public static string CreditorName
	{
		get
		{
			CreditorHandler creditorHandler = new CreditorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				creditorHandler = (CreditorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return creditorHandler.creditorName;
		}
	}

	public static string GeneralPurposeReason
	{
		get
		{
			CreditorHandler creditorHandler = new CreditorHandler();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
			using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				creditorHandler = (CreditorHandler)binaryFormatter.Deserialize(serializationStream);
			}
			return creditorHandler.generalPurposeReason;
		}
	}

	public static void SetCreditPaymentParameters(string generalPurposeAccountNo, string narration, string CreditorAccountNo, string creditorName, string generalPurposeReason)
	{
		CreditorHandler creditorHandler = new CreditorHandler();
		creditorHandler.generalPurposeAccountNo = generalPurposeAccountNo;
		creditorHandler.narration = narration;
		creditorHandler.creditorAccountNo = CreditorAccountNo;
		creditorHandler.creditorName = creditorName;
		creditorHandler.generalPurposeReason = generalPurposeReason;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_CreditorHandler.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, creditorHandler);
		fileStream.Close();
	}
}
