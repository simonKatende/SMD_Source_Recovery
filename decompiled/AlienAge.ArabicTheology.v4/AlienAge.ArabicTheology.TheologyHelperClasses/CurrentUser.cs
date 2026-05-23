namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public class CurrentUser
{
	private static int userID { get; set; }

	private static string userName { get; set; }

	private static string userFullName { get; set; }

	private static string userGroupName { get; set; }

	public static int UserID => userID;

	public static string UserName => userName;

	public static string UserFullName => userFullName;

	public static string UserGroup => userGroupName;

	public static string GetSystemUser()
	{
		return $"{userGroupName}/{userFullName}";
	}

	public static void SetSystemUser(int UserID, string UserName, string FullName, string GroupName)
	{
		userID = UserID;
		userName = UserName;
		userFullName = FullName;
		userGroupName = GroupName;
	}
}
