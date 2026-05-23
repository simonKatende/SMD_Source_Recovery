using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
public class ProcessALevelReports
{
	private static bool promoStatus { get; set; }

	public static string ReportHeader { get; set; }

	public static DateTime TermEnds { get; set; }

	public static DateTime TermBegins { get; set; }

	public static string StudentClass { get; set; }

	public static string Semester { get; set; }

	public static void InitializeALevelProcessing(DateTime termBeginsA, string studentClassA, string semesterA)
	{
		ProcessALevelReports graph = new ProcessALevelReports();
		Semester = semesterA;
		StudentClass = studentClassA;
		TermBegins = termBeginsA;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static DateTime NextTermBeginsOn()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessALevelReports processALevelReports = new ProcessALevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processALevelReports = (ProcessALevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return TermBegins;
	}

	public static DateTime NextTermEndsOn()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessALevelReports processALevelReports = new ProcessALevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processALevelReports = (ProcessALevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return TermEnds;
	}

	public static string ReportHeaders()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessALevelReports processALevelReports = new ProcessALevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processALevelReports = (ProcessALevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return ReportHeader;
	}

	public static string ClassForProcessing()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessALevelReports processALevelReports = new ProcessALevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processALevelReports = (ProcessALevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return StudentClass;
	}

	public static string CurrentSemester()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessALevelReports processALevelReports = new ProcessALevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processALevelReports = (ProcessALevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return Semester;
	}
}
