namespace I_Xtreme.ExtremeClasses;

public class InMemoryGradingScale
{
	public static string OverallGrade(double AvgPerformance)
	{
		string result = string.Empty;
		if (AvgPerformance >= 80.0 && AvgPerformance <= 100.0)
		{
			result = "A";
		}
		else if (AvgPerformance >= 70.0 && AvgPerformance <= 79.0)
		{
			result = "B";
		}
		else if (AvgPerformance >= 50.0 && AvgPerformance <= 69.0)
		{
			result = "C";
		}
		else if (AvgPerformance >= 35.0 && AvgPerformance <= 49.0)
		{
			result = "D";
		}
		else if (AvgPerformance >= 0.0 && AvgPerformance <= 34.0)
		{
			result = "E";
		}
		return result;
	}
}
