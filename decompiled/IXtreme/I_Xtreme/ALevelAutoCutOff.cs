using System;
using Microsoft.Win32;

namespace I_Xtreme;

internal class ALevelAutoCutOff
{
	public static double Repeat
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\A Level Cutoff");
			return Convert.ToInt32(registryKey.GetValue("Repeat").ToString());
		}
	}

	public static double ProbationEnd
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\A Level Cutoff");
			return Convert.ToInt32(registryKey.GetValue("ProbationEnd").ToString());
		}
	}
}
