using System;

namespace I_Xtreme;

internal class CaptureDate
{
	public static string GetCaptureDate()
	{
		double num = DateTime.Now.ToOADate();
		Random random = new Random();
		double num2 = (int)(random.NextDouble() * 9.0 + 1.0);
		return num.ToString().Replace('.', Convert.ToChar(num2.ToString()));
	}
}
