using System;

namespace I_Xtreme;

public class CurrentTime
{
	public static DateTime TimeZoneTime
	{
		get
		{
			string id = "E. Africa Standard Time";
			TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(id);
			return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, destinationTimeZone);
		}
	}
}
