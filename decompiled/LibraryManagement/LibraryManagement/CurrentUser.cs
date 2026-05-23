using Microsoft.Win32;

namespace LibraryManagement;

internal class CurrentUser
{
	public static string GetSystemUser()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Alien Age\\Intelligent Records 2014\\Current User");
		if (registryKey != null)
		{
			return registryKey.GetValue("CurrentUser").ToString();
		}
		return "Not Set";
	}

	public static void SetSystemUser(string userGroup)
	{
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\Intelligent Records 2014\\Current User");
		registryKey.SetValue("CurrentUser", userGroup);
	}
}
