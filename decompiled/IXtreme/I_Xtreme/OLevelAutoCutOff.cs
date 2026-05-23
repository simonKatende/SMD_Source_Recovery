using System;
using Microsoft.Win32;

namespace I_Xtreme;

internal class OLevelAutoCutOff
{
	public static double Promoted
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\O Level Cutoff");
			return Convert.ToInt32(registryKey.GetValue("Promoted").ToString());
		}
	}

	public static double ProbationDebut
	{
		get
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\O Level Cutoff");
			return Convert.ToInt32(registryKey.GetValue("ProbationDebut").ToString());
		}
	}
}
