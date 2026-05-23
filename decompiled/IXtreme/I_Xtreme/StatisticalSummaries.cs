using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;

namespace I_Xtreme;

[Serializable]
internal class StatisticalSummaries
{
	public enum SummaryType
	{
		DivisionFrequency,
		OLSubjectPerformance,
		SetsComparison,
		PointsFrequencies,
		ALSubjectPerformance
	}

	private static string statisticalSummaryType { get; set; }

	private static bool summarizeStream { get; set; }

	private static string summarizableStream { get; set; }

	public static bool IsStreamSummarizable
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StaticalSummary.tmp");
			StatisticalSummaries statisticalSummaries = new StatisticalSummaries();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			statisticalSummaries = (StatisticalSummaries)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return summarizeStream;
		}
	}

	public static string StatisticalSummaryType
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StaticalSummary.tmp");
			StatisticalSummaries statisticalSummaries = new StatisticalSummaries();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			statisticalSummaries = (StatisticalSummaries)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return statisticalSummaryType;
		}
	}

	public static string SummarizableStream()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaticalSummary.tmp");
		StatisticalSummaries statisticalSummaries = new StatisticalSummaries();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		statisticalSummaries = (StatisticalSummaries)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return summarizableStream;
	}

	private static string GradingTableSourceActive(string Class)
	{
		return SchoolSettings.GeneralReportGradingTableSource(Class);
	}

	private static string ReportTableSourceActive(string Class)
	{
		return SchoolSettings.GeneralReportTableSource(Class);
	}

	public static void SetStreamSummerization(bool _summarizeStream, string _summarizableStream)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaticalSummary.tmp");
		StatisticalSummaries graph = new StatisticalSummaries();
		summarizeStream = _summarizeStream;
		summarizableStream = _summarizableStream;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetSummaryType(string _statisticalSummaryType)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaticalSummary.tmp");
		StatisticalSummaries graph = new StatisticalSummaries();
		statisticalSummaryType = _statisticalSummaryType;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static DataTable DivisionFrenquencies(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("BestInEight", typeof(float));
		dataTable.Columns.Add("Div", typeof(string));
		dataTable.Columns.Add("AvMark", typeof(float));
		dataTable.Columns.Add("StreamId", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("StudentNumber", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT g.BestinEight,g.Div,g.AvMark,g.SemesterId,g.TotalMark,g.AvMark,g.StudentNumber,s.StreamId,s.ClassId FROM {GradingTableSourceActive(Class)} g INNER JOIN tbl_Stud s ON s.StudentNumber=g.StudentNumber WHERE g.SemesterId='{Semester}' AND s.ClassId='{Class}'", DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "DivisionFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				dataTable.Rows.Add(row["BestinEight"], row["Div"], row["AvMark"], row["StreamId"], row["SemesterId"], row["StudentNumber"]);
			}
		}
		return dataTable;
	}

	public static DataTable DivisionFrenquenciesStream(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("BestInEight", typeof(float));
		dataTable.Columns.Add("Div", typeof(string));
		dataTable.Columns.Add("AvMark", typeof(float));
		dataTable.Columns.Add("StreamId", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("StudentNumber", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT g.BestinEight,g.Div,g.AvMark,g.SemesterId,g.TotalMark,g.AvMark,g.StudentNumber,s.StreamId,s.ClassId FROM {GradingTableSourceActive(Class)} g INNER JOIN tbl_Stud s ON s.StudentNumber=g.StudentNumber WHERE g.SemesterId='{Semester}' AND s.StreamId='{SummarizableStream()}' AND s.ClassId='{Class}'", DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "DivisionFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				dataTable.Rows.Add(row["BestinEight"], row["Div"], row["AvMark"], row["StreamId"], row["SemesterId"], row["StudentNumber"]);
			}
		}
		return dataTable;
	}

	public static DataTable SubjectFrenquenciesOLevel(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("AvMark", typeof(double));
		dataTable.Columns.Add("Grade", typeof(float));
		dataTable.Columns.Add("Category", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,AvMark,Grade,Category,SemesterId,SubjectId,ClassId FROM {ReportTableSourceActive(Class)} WHERE SemesterId='{Semester}' AND ClassId='{Class}'", DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "DivisionFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				string empty = string.Empty;
				empty = ((!(row["Category"].ToString() == "D1")) ? ((!(row["Category"].ToString() == "D2")) ? ((!(row["Category"].ToString() == "C3")) ? ((!(row["Category"].ToString() == "C4")) ? ((!(row["Category"].ToString() == "C5")) ? ((!(row["Category"].ToString() == "C6")) ? ((!(row["Category"].ToString() == "P7")) ? ((!(row["Category"].ToString() == "P8")) ? ((!(row["Category"].ToString() == "F9")) ? "Missing" : string.Format("9 ({0})", row["Category"])) : string.Format("8 ({0})", row["Category"])) : string.Format("7 ({0})", row["Category"])) : string.Format("6 ({0})", row["Category"])) : string.Format("5 ({0})", row["Category"])) : string.Format("4 ({0})", row["Category"])) : string.Format("3 ({0})", row["Category"])) : string.Format("2 ({0})", row["Category"])) : string.Format("1 ({0})", row["Category"]));
				double result = (double.TryParse(row["AvMark"].ToString(), out result) ? result : 0.0);
				double result2 = (double.TryParse(row["Grade"].ToString(), out result2) ? result2 : 0.0);
				dataTable.Rows.Add(row["StudentNumber"], result, result2, empty, row["SemesterId"], row["SubjectId"]);
			}
		}
		return dataTable;
	}

	public static DataTable SubjectFrenquenciesOLevelStream(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("AvMark", typeof(double));
		dataTable.Columns.Add("Grade", typeof(float));
		dataTable.Columns.Add("Category", typeof(string));
		dataTable.Columns.Add("StreamId", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT gr.StudentNumber,gr.AvMark,gr.Grade,gr.Category,gr.SemesterId,gr.SubjectId,s.StreamId,s.ClassId FROM {ReportTableSourceActive(Class)} gr INNER JOIN tbl_Stud s ON gr.StudentNumber=s.StudentNumber WHERE gr.SemesterId='{Semester}' AND s.StreamId='{SummarizableStream()}' AND s.ClassId='{Class}'", DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "DivisionFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				string empty = string.Empty;
				empty = ((!(row["Category"].ToString() == "D1")) ? ((!(row["Category"].ToString() == "D2")) ? ((!(row["Category"].ToString() == "C3")) ? ((!(row["Category"].ToString() == "C4")) ? ((!(row["Category"].ToString() == "C5")) ? ((!(row["Category"].ToString() == "C6")) ? ((!(row["Category"].ToString() == "P7")) ? ((!(row["Category"].ToString() == "P8")) ? ((!(row["Category"].ToString() == "F9")) ? "Missing" : string.Format("9 ({0})", row["Category"])) : string.Format("8 ({0})", row["Category"])) : string.Format("7 ({0})", row["Category"])) : string.Format("6 ({0})", row["Category"])) : string.Format("5 ({0})", row["Category"])) : string.Format("4 ({0})", row["Category"])) : string.Format("3 ({0})", row["Category"])) : string.Format("2 ({0})", row["Category"])) : string.Format("1 ({0})", row["Category"]));
				double result = (double.TryParse(row["AvMark"].ToString(), out result) ? result : 0.0);
				double result2 = (double.TryParse(row["Grade"].ToString(), out result2) ? result2 : 0.0);
				dataTable.Rows.Add(row["StudentNumber"], result, result2, empty, row["StreamId"], row["SemesterId"], row["SubjectId"]);
			}
		}
		return dataTable;
	}

	public static DataTable SetsPerformanceComparisionOLevel(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("HoP", typeof(float));
		dataTable.Columns.Add("BOT", typeof(float));
		dataTable.Columns.Add("MOT", typeof(float));
		dataTable.Columns.Add("EOT", typeof(float));
		dataTable.Columns.Add("AvMark", typeof(string));
		dataTable.Columns.Add("Grade", typeof(float));
		dataTable.Columns.Add("Category", typeof(string));
		dataTable.Columns.Add("ClassId", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,HoP,BOT,MOT,EOT,AvMark,Grade,Category,ClassId,SemesterId,SubjectId FROM {ReportTableSourceActive(Class)} WHERE ClassId='{Class}' AND SemesterId='{Semester}'", DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "DivisionFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				double result = (double.TryParse(row["AvMark"].ToString(), out result) ? result : 0.0);
				double result2 = (double.TryParse(row["Grade"].ToString(), out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(row["HoP"].ToString(), out result3) ? result3 : 0.0);
				double result4 = (double.TryParse(row["BOT"].ToString(), out result4) ? result4 : 0.0);
				double result5 = (double.TryParse(row["MOT"].ToString(), out result5) ? result5 : 0.0);
				double result6 = (double.TryParse(row["EOT"].ToString(), out result6) ? result6 : 0.0);
				dataTable.Rows.Add(row["StudentNumber"], result3, result4, result5, result6, result, result2, row["Category"], row["ClassId"], row["SemesterId"], row["SubjectId"]);
			}
		}
		return dataTable;
	}

	public static DataTable SetsPerformanceComparisionOLevelStream(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("HoP", typeof(float));
		dataTable.Columns.Add("BOT", typeof(float));
		dataTable.Columns.Add("MOT", typeof(float));
		dataTable.Columns.Add("EOT", typeof(float));
		dataTable.Columns.Add("AvMark", typeof(string));
		dataTable.Columns.Add("Grade", typeof(float));
		dataTable.Columns.Add("Category", typeof(string));
		dataTable.Columns.Add("ClassId", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT gr.StudentNumber,gr.HoP,gr.BOT,gr.MOT,gr.EOT,gr.AvMark,gr.Grade,gr.Category,gr.ClassId,gr.SemesterId,gr.SubjectId,st.StreamId FROM {0} gr INNER JOINS Streams st ON gr.ClassId=st.ClassId WHERE gr.ClassId='{0}' AND gr.SemesterId='{1}' AND st.StreamId='{2}'", ReportTableSourceActive(Class), Class, Semester, SummarizableStream()), DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "DivisionFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				double result = (double.TryParse(row["AvMark"].ToString(), out result) ? result : 0.0);
				double result2 = (double.TryParse(row["Grade"].ToString(), out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(row["HoP"].ToString(), out result3) ? result3 : 0.0);
				double result4 = (double.TryParse(row["BOT"].ToString(), out result4) ? result4 : 0.0);
				double result5 = (double.TryParse(row["MOT"].ToString(), out result5) ? result5 : 0.0);
				double result6 = (double.TryParse(row["EOT"].ToString(), out result6) ? result6 : 0.0);
				dataTable.Rows.Add(row["StudentNumber"], result3, result4, result5, result6, result, result2, row["Category"], row["ClassId"], row["StreamId"], row["SemesterId"], row["SubjectId"]);
			}
		}
		return dataTable;
	}

	public static DataTable PerformanceGradesPointsALevel(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("TotalPoints", typeof(int));
		dataTable.Columns.Add("SemesterId", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber FROM tbl_Stud WHERE ClassId='{Class}'", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PointsFreq");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				string selectCommandText = string.Format("SELECT SemesterId,StudentNumber,SUM(TotalPoints) AS TotalPoints FROM tbl_ALevelReport  WHERE SemesterId='{0}' AND StudentNumber='{1}' GROUP BY SemesterId,StudentNumber", Semester, row["StudentNumber"].ToString());
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				using DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "PointsFrequencies");
				DataTable dataTable3 = new DataTable();
				dataTable3 = dataSet2.Tables[0];
				foreach (DataRow row2 in dataTable3.Rows)
				{
					dataTable.Rows.Add(row2["TotalPoints"], row2["SemesterId"]);
				}
			}
		}
		return dataTable;
	}

	public static DataTable PerformanceGradesPointsALevelStream(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("TotalPoints", typeof(int));
		dataTable.Columns.Add("Stream", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,StreamId,ClassId FROM tbl_Stud WHERE StreamId='{SummarizableStream()}' AND ClassId='{Class}'", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PointsFreqStream");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				string selectCommandText = string.Format("SELECT SemesterId,StudentNumber,SUM(Points) AS TotalPoints FROM {0}  WHERE SemesterId='{1}' AND StudentNumber='{2}' GROUP BY SemesterId,StudentNumber", GradingTableSourceActive(Class), Semester, row["StudentNumber"].ToString());
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				using DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "PointsFrequenciesStream");
				DataTable dataTable3 = new DataTable();
				dataTable3 = dataSet2.Tables[0];
				foreach (DataRow row2 in dataTable3.Rows)
				{
					dataTable.Rows.Add(row2["TotalPoints"], row["StreamId"], row2["SemesterId"]);
				}
			}
		}
		return dataTable;
	}

	public static DataTable PerformanceGradesALevel(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("TotalPoints", typeof(int));
		dataTable.Columns.Add("Grade", typeof(string));
		dataTable.Columns.Add("AverageMark", typeof(float));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		string selectCommandText = $"SELECT StudentNumber,Points,Grade,AverageMark,SemesterId,SubjectId FROM {GradingTableSourceActive(Class)} WHERE SemesterId='{Semester}' AND ClassId='{Class}'";
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PointsGradesFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				dataTable.Rows.Add(row["StudentNumber"], row["Points"], row["Grade"], row["AverageMark"], row["SemesterId"], row["SubjectId"]);
			}
		}
		return dataTable;
	}

	public static DataTable PerformanceGradesALevelStream(string Class, string Semester)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("TotalPoints", typeof(int));
		dataTable.Columns.Add("Grade", typeof(string));
		dataTable.Columns.Add("AverageMark", typeof(float));
		dataTable.Columns.Add("StreamId", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		string selectCommandText = $"SELECT p.StudentNumber,p.Points,p.Grade,p.AverageMark,p.SemesterId,p.SubjectId,s.StreamId,s.ClassId FROM {GradingTableSourceActive(Class)} p INNER JOIN tbl_Stud s ON p.StudentNumber=s.StudentNumber WHERE p.SemesterId='{Semester}' AND s.StreamId='{SummarizableStream()}' AND s.ClassId='{Class}'";
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase()))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PointsGradesFrequencies");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				dataTable.Rows.Add(row["StudentNumber"], row["Points"], row["Grade"], row["AverageMark"], row["StreamId"], row["SemesterId"], row["SubjectId"]);
			}
		}
		return dataTable;
	}
}
