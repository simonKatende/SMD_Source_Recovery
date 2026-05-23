using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme;

[Serializable]
internal class CurrentUser
{
	private int userID { get; set; }

	private string userName { get; set; }

	private string userFullName { get; set; }

	private string userGroupName { get; set; }

	private bool readOnly { get; set; }

	private bool canBill { get; set; }

	private bool canPayIn { get; set; }

	private bool canEditFees { get; set; }

	private bool canAddStud { get; set; }

	private bool canEditStud { get; set; }

	private bool canDelStud { get; set; }

	private bool canEditContact { get; set; }

	public static int UserID
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.userID;
		}
	}

	public static string UserName
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.userName;
		}
	}

	public static string UserFullName
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.userFullName;
		}
	}

	public static string UserGroup
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.userGroupName;
		}
	}

	public static bool CanBillStudent
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canBill;
		}
	}

	public static bool CanPayInFees
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canPayIn;
		}
	}

	public static bool CanEditFees
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canEditFees;
		}
	}

	public static bool CanAddStudent
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canAddStud;
		}
	}

	public static bool CanEditStudent
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canEditStud;
		}
	}

	public static bool CanDeleteStudent
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canDelStud;
		}
	}

	public static bool IsReadOnly
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.readOnly;
		}
	}

	public static bool CanEditContact
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
			CurrentUser currentUser = new CurrentUser();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return currentUser.canEditContact;
		}
	}

	public static string GetSystemUser()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
		CurrentUser currentUser = new CurrentUser();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		currentUser = (CurrentUser)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return $"{currentUser.userGroupName}/{currentUser.userFullName}";
	}

	public static void SetSystemUser(int UserID, string UserName, string FullName, string GroupName, bool ReadOnly, bool CanBill, bool CanPayIn, bool CanEditFees, bool CanAddStud, bool CanEditStud, bool CanDelStud, bool CanEditContacts)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_System_C_U.tmp");
		CurrentUser currentUser = new CurrentUser();
		currentUser.userID = UserID;
		currentUser.userName = UserName;
		currentUser.userFullName = FullName;
		currentUser.userGroupName = GroupName;
		currentUser.readOnly = ReadOnly;
		currentUser.canBill = CanBill;
		currentUser.canPayIn = CanPayIn;
		currentUser.canEditFees = CanEditFees;
		currentUser.canAddStud = CanAddStud;
		currentUser.canEditStud = CanEditStud;
		currentUser.canDelStud = CanDelStud;
		currentUser.canEditContact = CanEditContacts;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, currentUser);
		fileStream.Close();
	}
}
