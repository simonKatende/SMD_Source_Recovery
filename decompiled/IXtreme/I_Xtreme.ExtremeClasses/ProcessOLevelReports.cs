using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace I_Xtreme.ExtremeClasses;

[Serializable]
internal class ProcessOLevelReports
{
	private static bool gradeX { get; set; }

	private static bool F9MTC { get; set; }

	private static bool F9Eng { get; set; }

	private static bool P7Or8Eng { get; set; }

	private static bool F9SCI { get; set; }

	private static bool promoStatus { get; set; }

	public static string ReportHeader { get; set; }

	public static DateTime TermEnds { get; set; }

	public static DateTime TermBegins { get; set; }

	public static string StudentClass { get; set; }

	public static string Semester { get; set; }

	public static bool SendToDiv3ForF9InEng
	{
		get
		{
			return F9Eng;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
			ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			SendToDiv3ForF9InEng = F9Eng;
		}
	}

	public static bool SendToDiv2ForP8OrP7InEng
	{
		get
		{
			return P7Or8Eng;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
			ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			SendToDiv2ForP8OrP7InEng = P7Or8Eng;
		}
	}

	public static bool SendToDiv2ForF9InMTC
	{
		get
		{
			return F9MTC;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
			ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			SendToDiv2ForF9InMTC = F9MTC;
		}
	}

	public static bool SendToDiv2ForF9InSCI
	{
		get
		{
			return F9SCI;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
			ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			SendToDiv2ForF9InSCI = F9SCI;
		}
	}

	public static bool AssignGradeX
	{
		get
		{
			return gradeX;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
			ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			AssignGradeX = gradeX;
		}
	}

	public static void InitializeOLevelProcessing(DateTime termBegins, string studentclass, string semester, bool sendToDiv3ForF9InEng, bool sendToDiv2ForP8OrP7InEng, bool sendToDiv2ForF9InMTC, bool sendToDiv2ForF9InSCI, bool assignGradeX)
	{
		ProcessOLevelReports graph = new ProcessOLevelReports();
		gradeX = assignGradeX;
		Semester = semester;
		F9MTC = sendToDiv2ForF9InMTC;
		F9SCI = sendToDiv2ForF9InSCI;
		P7Or8Eng = sendToDiv2ForP8OrP7InEng;
		F9Eng = sendToDiv3ForF9InEng;
		StudentClass = studentclass;
		TermBegins = termBegins;
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
		ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return TermBegins;
	}

	public static DateTime NextTermEndsOn()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return TermEnds;
	}

	public static string ReportHeaders()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return ReportHeader;
	}

	public static string ClassForProcessing()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return StudentClass;
	}

	public static string CurrentSemester()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_P_Reports_Ultimate.tmp");
		ProcessOLevelReports processOLevelReports = new ProcessOLevelReports();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			processOLevelReports = (ProcessOLevelReports)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return Semester;
	}
}
