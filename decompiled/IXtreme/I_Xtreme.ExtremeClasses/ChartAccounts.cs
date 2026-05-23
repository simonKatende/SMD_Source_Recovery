namespace I_Xtreme.ExtremeClasses;

public class ChartAccounts
{
	private static string accountNo { get; set; }

	private static string accountName { get; set; }

	public static string SelectedAccount => accountNo;

	public static string AccoutName => accountName;

	public static void SetSelectedAccount(string AccountNo, string AccountName)
	{
		accountNo = AccountNo;
		accountName = AccountName;
	}
}
