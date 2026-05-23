using Microsoft.Win32;

namespace I_Xtreme;

internal class NoneCashPayment
{
	public static string Narration
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\None Cash Fees Payment");
			return registryKey.GetValue("narration").ToString();
		}
	}

	public static void StoreNarration(string _narration)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\None Cash Fees Payment");
		registryKey.SetValue("narration", _narration);
	}
}
