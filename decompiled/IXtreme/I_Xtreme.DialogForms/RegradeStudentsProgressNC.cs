using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class RegradeStudentsProgressNC : XtraForm
{
	private int i;

	private int k = 0;

	private int maximum = 0;

	private int UnitsUsed = 0;

	private string _Class = string.Empty;

	private string _Term = string.Empty;

	private string _Connection = string.Empty;

	private string _Stream = string.Empty;

	private bool ProjectInclusive = false;

	private int RankingOption = 0;

	private bool _ProcessClassRank = false;

	private bool _ProcessSubjectRank = false;

	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private int u1f = 0;

	private int u2f = 0;

	private int u3f = 0;

	private int u4f = 0;

	private SqlConnection con;

	private IContainer components = null;

	private BackgroundWorker bgProcessOLevel;

	private System.Windows.Forms.Timer timer1;

	private ProgressBarControl progressBarControl1;

	private DataTable dtEOY { get; set; }

	public RegradeStudentsProgressNC(string _Class, string _Term, string _Stream, bool ProcessClassRank, bool ProcessSubjectRank)
	{
		InitializeComponent();
		this._Class = _Class;
		this._Term = _Term;
		this._Stream = _Stream;
		_Connection = DataConnection.ConnectToDatabase();
		_ProcessClassRank = ProcessClassRank;
		_ProcessSubjectRank = ProcessSubjectRank;
		dtEOY = gradingScale.EndOfYearScale;
		con = new SqlConnection(_Connection);
	}

	private static KeyValuePair<string, string> OLevelAutoCommentsNCScale3(double score)
	{
		KeyValuePair<string, string> result = new KeyValuePair<string, string>("", "");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNC WHERE " + score + " BETWEEN D3 AND E3", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "OLevelAutoCommentsNC");
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		foreach (DataRow row in dataTable.Rows)
		{
			Random random = new Random();
			int num = random.Next(1, 5);
			string columnName = "Classteacher" + num;
			string columnName2 = "Headteacher" + num;
			string key = row[columnName].ToString();
			string value = row[columnName2].ToString();
			result = new KeyValuePair<string, string>(key, value);
		}
		return result;
	}

	private static KeyValuePair<string, string> OLevelAutoCommentsNCScale100(double score)
	{
		KeyValuePair<string, string> result = new KeyValuePair<string, string>("", "");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNC WHERE " + score + " BETWEEN D100 AND E100", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "OLevelAutoCommentsNC");
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		foreach (DataRow row in dataTable.Rows)
		{
			Random random = new Random();
			int num = random.Next(1, 5);
			string columnName = "Classteacher" + num;
			string columnName2 = "Headteacher" + num;
			string key = row[columnName].ToString();
			string value = row[columnName2].ToString();
			result = new KeyValuePair<string, string>(key, value);
		}
		return result;
	}

	private void bgProcessOLevel_DoWork(object sender, DoWorkEventArgs e)
	{
		RegradeStudents();
		FinalizeCreateReport();
		if (_ProcessClassRank)
		{
			ProcessStudentsRankingLO();
			ProcessStudentsRankingLOEOT();
			ProcessStudentsRankingEOT();
		}
		else
		{
			UnProcessClassRanking();
		}
		if (_ProcessSubjectRank)
		{
			ProcessStudentsRankingPerSubject();
		}
		else
		{
			UnProcessStudentsRankingPerSubject();
		}
	}

	private void ProcessOLevel_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 2)
		{
			timer1.Enabled = false;
			bgProcessOLevel.RunWorkerAsync();
		}
	}

	private void bgProcessOLevel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Processing students completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Dispose();
	}

	private KeyValuePair<string, string> EOYYearGrade(double AvgScore)
	{
		double num = Math.Round(AvgScore, 0);
		KeyValuePair<string, string> result = new KeyValuePair<string, string>("", "");
		DataRow[] array = dtEOY.Select(string.Format("E100>={0} AND D100<={0}", num));
		try
		{
			result = new KeyValuePair<string, string>(array[0]["Grade"].ToString(), array[0]["Descriptor"].ToString());
			return result;
		}
		catch (Exception)
		{
		}
		return result;
	}

	private void GetUnitsUsed(string Subject, string ClassId, string SemesterId)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNC WHERE ClassId='{ClassId}' AND SemesterId='{SemesterId}' AND SubjectId='{Subject}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		ProjectInclusive = bool.TryParse(dataTable.Rows[0]["ProjectAvailable"].ToString(), out ProjectInclusive) && ProjectInclusive;
		if (dataTable.Rows.Count > 0)
		{
			UnitsUsed = (int.TryParse(dataTable.Rows[0]["TUnits"].ToString(), out UnitsUsed) ? UnitsUsed : 0);
		}
		else
		{
			UnitsUsed = 1;
		}
		if (UnitsUsed == 0)
		{
			u1f = 0;
			u2f = 0;
			u3f = 0;
			u4f = 0;
		}
		else if (UnitsUsed == 1)
		{
			u1f = 1;
			u2f = 0;
			u3f = 0;
			u4f = 0;
		}
		else if (UnitsUsed == 2)
		{
			u1f = 1;
			u2f = 1;
			u3f = 0;
			u4f = 0;
		}
		else if (UnitsUsed == 3)
		{
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 0;
		}
		else if (UnitsUsed == 4)
		{
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
		}
	}

	private string[] PlaceholderValue(double LO, string PlaceHolder)
	{
		string[] array = new string[2] { "", "" };
		switch (PlaceHolder)
		{
		case "x":
			array[0] = "x";
			array[1] = "x";
			break;
		case "0":
			array[0] = "0";
			array[1] = "0";
			break;
		case "-":
			array[0] = "-";
			array[1] = "-";
			break;
		case " ":
			array[0] = " ";
			array[1] = " ";
			break;
		case "":
			array[0] = "";
			array[1] = "";
			break;
		default:
			array[0] = LO.ToString();
			array[1] = Math.Round(LO / 3.0 * 10.0, 0, MidpointRounding.AwayFromZero).ToString();
			break;
		}
		return array;
	}

	public static string LastName(string text)
	{
		string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length >= 2)
		{
			return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(array[1].ToLower());
		}
		return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
	}

	private void FinalizeCreateReport()
	{
		try
		{
			string empty = string.Empty;
			empty = ((!(_Stream == " All Streams ") && !(_Stream == "-")) ? $"SELECT sc.StudentNumber, AVG(sc.AvLO) AS AvLO, AVG(sc.ETAv) AS ETAv,AVG(sc.ProjLO)  AS ProjAv,AVG(CAST(ISNULL(ETA,'0') AS FLOAT)) AS ETA FROM   tbl_Scores_OL_Report sc INNER JOIN  tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId GROUP BY sc.StudentNumber, sc.SemesterId, s.ClassId,s.ClassId,s.Status,s.StreamId HAVING (sc.SemesterId = '{_Term}') AND (s.ClassId = '{_Class}') AND (s.Status = 'Active') AND s.StreamId='{_Stream}'" : $"SELECT sc.StudentNumber, AVG(sc.AvLO) AS AvLO, AVG(sc.ETAv) AS ETAv, AVG(sc.ProjLO) AS ProjAv, AVG(CAST(ISNULL(ETA,'0') AS FLOAT)) AS ETA FROM tbl_Scores_OL_Report sc INNER JOIN tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId GROUP BY sc.StudentNumber, sc.SemesterId, s.ClassId, s.ClassId, s.Status, s.StreamId HAVING (sc.SemesterId = '{_Term}') AND (s.ClassId = '{_Class}') AND (s.Status = 'Active')");
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, _Connection);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			k = 0;
			maximum = dataTable.Rows.Count;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			double result = 0.0;
			double result2 = 0.0;
			double result3 = 0.0;
			double result4 = 0.0;
			string empty5 = string.Empty;
			foreach (DataRow row in dataTable.Rows)
			{
				empty5 = row["StudentNumber"].ToString();
				result4 = (double.TryParse(row["ETA"].ToString(), out result4) ? result4 : 0.0);
				double scoreOutOf = Math.Round(result4 / 100.0 * 3.0, 2);
				result = (double.TryParse(row["AvLO"].ToString(), out result) ? result : 0.0);
				result2 = (double.TryParse(row["ETAv"].ToString(), out result2) ? result2 : 0.0);
				double scoreOutOf2 = Math.Round(result2 / 100.0 * 3.0, 2);
				result3 = (double.TryParse(row["ProjAv"].ToString(), out result3) ? result3 : 0.0);
				empty2 = gradingScale.GetGradingScale(scoreOutOf2).Value;
				empty3 = gradingScale.GetGradingScale(result).Value;
				empty4 = gradingScale.GetGradingScale(scoreOutOf).Value;
				KeyValuePair<string, string> keyValuePair = OLevelAutoCommentsNCScale3(result);
				KeyValuePair<string, string> keyValuePair2 = OLevelAutoCommentsNCScale100(result2);
				con.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					CommandText = "UPDATE tbl_Scores_OL_Report SET ClassteacherRemark=@ClassteacherRemark,HeadteacherRemark=@HeadteacherRemark,ClassteacherRemarkFA=@ClassteacherRemarkFA,HeadteacherRemarkFA=@HeadteacherRemarkFA,ClassTeacherProject=@ClassTeacherProject,HeadTeacherProject=@HeadTeacherProject,OverallPerformance=@OverallPerformance,OverallPerformanceLO=@OverallPerformanceLO,OverallPerformance100=@OverallPerformance100 WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId",
					Connection = con,
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassteacherRemark", keyValuePair.Key);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@HeadteacherRemark", keyValuePair.Value);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassteacherRemarkFA", keyValuePair2.Key);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@HeadteacherRemarkFA", keyValuePair2.Value);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", empty5);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassTeacherProject", keyValuePair2.Key);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@HeadTeacherProject", keyValuePair2.Value);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@OverallPerformanceLO", empty3);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@OverallPerformance", empty2);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("@OverallPerformance100", empty4);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					con.Close();
				}
				k++;
				Thread.Sleep(10);
				bgProcessOLevel.ReportProgress(k + 1);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void RegradeStudents()
	{
		try
		{
			string text = "SELECT s.StudentNumber, s.fullName, s.StudentID, s.ClassId, s.StreamId, \r\n                   sc.SubjectId, sc.ETA80, sc.ETA, sc.Score1, sc.Score2, sc.Score3, sc.Score4, \r\n                   sc.WriteComment, sc.TeacherRemarks, sc.Hund1, sc.Hund2, sc.Hund3, sc.Hund4, \r\n                   sc.P1, sc.T1, sc.T2, sc.T3, sc.T4 FROM tbl_Stud s\r\n                   INNER JOIN tbl_Scores_OL_Report sc ON s.StudentNumber = sc.StudentNumber\r\n                   WHERE s.ClassId = @ClassId AND sc.SemesterId = @SemesterId AND sc.IsAssessed = 1";
			if (_Stream != " All Streams " && _Stream != "-")
			{
				text += " AND s.StreamId = @StreamId";
			}
			DataTable dataTable = new DataTable();
			using (SqlCommand sqlCommand = new SqlCommand(text, con))
			{
				sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
				sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
				if (_Stream != " All Streams " && _Stream != "-")
				{
					sqlCommand.Parameters.AddWithValue("@StreamId", _Stream);
				}
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
			}
			k = 0;
			maximum = dataTable.Rows.Count;
			string empty = string.Empty;
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			foreach (DataRow row in dataTable.Rows)
			{
				empty = row["StudentNumber"].ToString();
				GetUnitsUsed(row["SubjectId"].ToString(), _Class, _Term);
				double result = (double.TryParse(row["ETA80"].ToString(), out result) ? result : 0.0);
				double result2 = (double.TryParse(row["ETA"].ToString(), out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(row["Score1"].ToString(), out result3) ? result3 : 0.0) * (double)u1f;
				double result4 = (double.TryParse(row["Score2"].ToString(), out result4) ? result4 : 0.0) * (double)u2f;
				double result5 = (double.TryParse(row["Score3"].ToString(), out result5) ? result5 : 0.0) * (double)u3f;
				double result6 = (double.TryParse(row["Score4"].ToString(), out result6) ? result6 : 0.0) * (double)u4f;
				double result7 = (double.TryParse(row["P1"].ToString(), out result7) ? result7 : 0.0);
				bool result8 = bool.TryParse(row["WriteComment"].ToString(), out result8) && result8;
				string text2 = row["TeacherRemarks"].ToString();
				string placeHolder = row["Score1"].ToString();
				string placeHolder2 = row["Score2"].ToString();
				string placeHolder3 = row["Score3"].ToString();
				string placeHolder4 = row["Score4"].ToString();
				double num = result3 + result4 + result5 + result6;
				double result9 = (double.TryParse(row["Hund1"].ToString(), out result9) ? result9 : 0.0) * (double)u1f;
				double result10 = (double.TryParse(row["Hund2"].ToString(), out result10) ? result10 : 0.0) * (double)u2f;
				double result11 = (double.TryParse(row["Hund3"].ToString(), out result11) ? result11 : 0.0) * (double)u3f;
				double result12 = (double.TryParse(row["Hund4"].ToString(), out result12) ? result12 : 0.0) * (double)u4f;
				double num2 = result9 + result10 + result11 + result12;
				double result13 = (double.TryParse(row["T1"].ToString(), out result13) ? result13 : 0.0) * (double)u1f;
				double result14 = (double.TryParse(row["T2"].ToString(), out result14) ? result14 : 0.0) * (double)u2f;
				double result15 = (double.TryParse(row["T3"].ToString(), out result15) ? result15 : 0.0) * (double)u3f;
				double result16 = (double.TryParse(row["T4"].ToString(), out result16) ? result16 : 0.0) * (double)u4f;
				double num3 = result13 + result14 + result15 + result16;
				double num4 = num3 + result7;
				double num5 = num4 / (double)(UnitsUsed + Convert.ToInt32(ProjectInclusive));
				double num6 = Math.Round(num5 / 10.0 * 3.0, 1);
				double num7 = Math.Round(result3 / 20.0 * 3.0, 1);
				double num8 = Math.Round(result4 / 20.0 * 3.0, 1);
				double num9 = Math.Round(result5 / 20.0 * 3.0, 1);
				double num10 = Math.Round(result6 / 20.0 * 3.0, 1);
				double num11 = num7 + num8 + num9 + num10;
				double num12 = Math.Round(num11 / (double)UnitsUsed, 1);
				double num13 = Math.Round(num11 / (double)(UnitsUsed * 3) * 20.0, 1, MidpointRounding.AwayFromZero);
				double value = num / (double)UnitsUsed;
				double num14 = Math.Round(value, 1, MidpointRounding.AwayFromZero);
				double value2 = num2 / (double)UnitsUsed;
				double num15 = Math.Round(value2, 1, MidpointRounding.AwayFromZero);
				double num16 = num14 + result;
				string key = EOYYearGrade(num16).Key;
				string value3 = EOYYearGrade(num16).Value;
				string key2 = EOYYearGrade(result2).Key;
				string value4 = EOYYearGrade(result2).Value;
				string key3 = gradingScale.GetGradingScale(num12).Key;
				string value5 = gradingScale.GetGradingScale(num12).Value;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				string empty4 = string.Empty;
				string empty5 = string.Empty;
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_Scores_OL_Report SET Descriptor_1=@Descriptor_1,Descriptor_2=@Descriptor_2,Descriptor_3=@Descriptor_3,Descriptor_4=@Descriptor_4, U1=@U1,U2=@U2,U3=@U3,U4=@U4,T1=@T1,T2=@T2,T3=@T3,T4=@T4,TTLPoints=@TTLPoints,AvMark=@AvMark,ETAv=@ETAv, OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen, OutOfHund=@OutOfHund,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,TeacherRemarksDesc=@TeacherRemarksDesc,Score100=@Score100,P5=@P5,P6=@P6,Category=@Category,TeacherRemarks=@TeacherRemarks,ProjAv=@ProjAv,ProjLO=@ProjLO,ProjRemark=@ProjRemark,CategoryAIOnly=@CategoryAIOnly WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId",
					CommandType = CommandType.Text
				};
				empty2 = gradingScale.GetGradingScale(num7).Value;
				empty3 = gradingScale.GetGradingScale(num8).Value;
				empty4 = gradingScale.GetGradingScale(num9).Value;
				empty5 = gradingScale.GetGradingScale(num10).Value;
				SqlParameter sqlParameter = sqlCommand2.Parameters.AddWithValue("@Descriptor_1", empty2);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Descriptor_2", empty3);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Descriptor_3", empty4);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Descriptor_4", empty5);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@U1", PlaceholderValue(num7, placeHolder)[0]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@U2", PlaceholderValue(num8, placeHolder2)[0]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@U3", PlaceholderValue(num9, placeHolder3)[0]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@U4", PlaceholderValue(num10, placeHolder4)[0]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@T1", PlaceholderValue(num7, placeHolder)[1]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@T2", PlaceholderValue(num8, placeHolder2)[1]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@T3", PlaceholderValue(num9, placeHolder3)[1]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@T4", PlaceholderValue(num10, placeHolder4)[1]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@ETAv", num16);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@AvMark", num14);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@StudentNumber", empty);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@SubjectId", row["SubjectId"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@ClassId", _Class);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@SemesterId", _Term);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@TTLPoints", num11);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@OutOfTwenty", num14);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@OutOfTen", Math.Round(num14 / 2.0, 1, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@OutOfHund", num15);
				sqlParameter.Direction = ParameterDirection.Input;
				double num17 = Math.Round((num14 + result) / 100.0 * 3.0, 1);
				string value6 = gradingScale.GetGradingScale(num17).Value;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@AvLo", num12);
				sqlParameter.Direction = ParameterDirection.Input;
				string automaticSubjectComment = gradingScale.GetAutomaticSubjectComment((float)num16, useSmallScale: false);
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@TeacherRemarks", automaticSubjectComment.PadRight(200).Substring(0, 200).Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				string automaticSubjectComment2 = gradingScale.GetAutomaticSubjectComment((float)num12);
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@TeacherRemarksDesc", automaticSubjectComment2.PadRight(200).Substring(0, 200).Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Comment", value5);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Descriptor100", value6);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Score100", num17);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@P5", key2);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@P6", value4);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@Category", key);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@CategoryAIOnly", key3);
				sqlParameter.Direction = ParameterDirection.Input;
				string key4 = gradingScale.GetGradingScale(num6).Key;
				string automaticSubjectComment3 = gradingScale.GetAutomaticSubjectComment((float)num6);
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@ProjAv", num5);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@ProjLO", num6);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.AddWithValue("@ProjRemark", automaticSubjectComment3.PadRight(200).Substring(0, 200).Trim());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k + 1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void bgProcessOLevel_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void RegradeStudentsProgressNC_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bgProcessOLevel.IsBusy)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to cancel the current process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				bgProcessOLevel.CancelAsync();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
		}
	}

	private void ProcessStudentsRankingLO()
	{
		string selectCommandText = $"SELECT s.fullName, s.StudentNumber,  s.ClassId, s.StreamId,  sc.SemesterId,  AVG(sc.OutOfHund) AS OutOfHund, RANK() OVER (PARTITION BY s.ClassId ORDER BY AVG(sc.OutOfHund) DESC) AS RankByClassId,  RANK() OVER (PARTITION BY s.StreamId ORDER BY AVG(sc.OutOfHund) DESC) AS RankByStreamId, COUNT(*) OVER (PARTITION BY s.ClassId) AS TotalStudents,COUNT(*) OVER (PARTITION BY s.StreamId) AS StudentsInStream  FROM tbl_Scores_OL_Report sc INNER JOIN dbo.tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId  GROUP BY s.fullName, s.StudentNumber,  s.ClassId,  s.StreamId, sc.SemesterId HAVING(s.ClassId = '{_Class}') AND(sc.SemesterId = '{_Term}')";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			con.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				CommandText = "UPDATE tbl_Scores_OL_Report SET PICLO=@PICLO,PISLO=@PISLO,SIC=@SIC,SIS=@SIS,GrandAvgLO=@GrandAvgLO WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = con
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("PICLO", Convert.ToInt32(row["RankByClassId"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("PISLO", Convert.ToInt32(row["RankByStreamId"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("GrandAvgLO", Convert.ToDouble(row["OutOfHund"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("StudentNumber", row["StudentNumber"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", _Term);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", _Class);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("SIC", Convert.ToInt32(row["TotalStudents"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("SIS", Convert.ToInt32(row["StudentsInStream"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k + 1);
		}
	}

	private void ProcessStudentsRankingLOEOT()
	{
		string selectCommandText = $"SELECT s.fullName, s.StudentNumber,  s.ClassId, s.StreamId,  sc.SemesterId,  AVG(sc.ETAv) AS OutOfHund,   RANK() OVER (PARTITION BY s.ClassId ORDER BY AVG(sc.ETAv) DESC) AS RankByClassId,  RANK() OVER (PARTITION BY s.StreamId ORDER BY AVG(sc.ETAv) DESC) AS RankByStreamId, COUNT(*) OVER (PARTITION BY s.ClassId) AS TotalStudents,COUNT(*) OVER (PARTITION BY s.StreamId) AS StudentsInStream  FROM tbl_Scores_OL_Report sc INNER JOIN dbo.tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId  GROUP BY s.fullName, s.StudentNumber,  s.ClassId,  s.StreamId, sc.SemesterId HAVING(s.ClassId = '{_Class}') AND(sc.SemesterId = '{_Term}')";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			con.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				CommandText = "UPDATE tbl_Scores_OL_Report SET PICLOEOT=@PICLOEOT,PISLOEOT=@PISLOEOT,GrandAvg=@GrandAvg WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = con
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("PICLOEOT", Convert.ToInt32(row["RankByClassId"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("PISLOEOT", Convert.ToInt32(row["RankByStreamId"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("GrandAvg", Convert.ToDouble(row["OutOfHund"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("StudentNumber", row["StudentNumber"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", _Term);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", _Class);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k + 1);
		}
	}

	private void ProcessStudentsRankingEOT()
	{
		string selectCommandText = $"SELECT s.fullName, s.StudentNumber, s.ClassId, s.StreamId,  sc.SemesterId, AVG(ISNULL(TRY_CAST(sc.ETA AS FLOAT), 0)) AS OutOfHund,  RANK() OVER (PARTITION BY s.ClassId ORDER BY AVG(ISNULL(TRY_CAST(sc.ETA AS FLOAT), 0)) DESC) AS RankByClassId, RANK() OVER (PARTITION BY s.StreamId ORDER BY AVG(ISNULL(TRY_CAST(sc.ETA AS FLOAT), 0)) DESC) AS RankByStreamId, COUNT(*) OVER (PARTITION BY s.ClassId) AS TotalStudents,COUNT(*) OVER (PARTITION BY s.StreamId) AS StudentsInStream  FROM tbl_Scores_OL_Report sc INNER JOIN  tbl_Stud s ON sc.StudentNumber = s.StudentNumber AND sc.ClassId = s.ClassId  GROUP BY s.fullName, s.StudentNumber,  s.ClassId, s.StreamId, sc.SemesterId HAVING  (s.ClassId = '{_Class}') AND (sc.SemesterId = '{_Term}')";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			con.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				CommandText = "UPDATE tbl_Scores_OL_Report SET PICEOT=@PICEOT,PISEOT=@PISEOT,GrandAvgEOT=@GrandAvgEOT WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = con
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("PICEOT", Convert.ToInt32(row["RankByClassId"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("PISEOT", Convert.ToInt32(row["RankByStreamId"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("GrandAvgEOT", Convert.ToDouble(row["OutOfHund"]));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("StudentNumber", row["StudentNumber"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", _Term);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", _Class);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
				con.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k + 1);
		}
	}

	private void ProcessStudentsRankingPerSubject()
	{
		try
		{
			string selectCommandText = $"SELECT StudentNumber, SubjectId, RANK() OVER (PARTITION BY SubjectId ORDER BY OutOfTwenty DESC) AS Rank20, COUNT(*) OVER (PARTITION BY SubjectId) AS TotalStudents, RANK() OVER (PARTITION BY SubjectId ORDER BY ETA DESC) AS RankETA, RANK() OVER (PARTITION BY SubjectId ORDER BY ETAv DESC) AS RankETAv FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND ClassId='{_Class}' ORDER BY StudentNumber, SubjectId, Rank20, RankETA, RankETAv";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			k = 0;
			maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				con.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					CommandText = "UPDATE tbl_Scores_OL_Report SET SubPosLO=@SubPosLO,SubPosEOT=@SubPosEOT,SubPosLOEOT=@SubPosLOEOT,TotalStudents=@TotalStudents WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId AND SubjectId=@SubjectId",
					CommandType = CommandType.Text,
					Connection = con
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("SubPosLO", Convert.ToInt32(row["Rank20"]));
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("SubPosEOT", Convert.ToInt32(row["RankETA"]));
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("SubPosLOEOT", Convert.ToDouble(row["RankETAv"]));
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("StudentNumber", row["StudentNumber"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", _Term);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", _Class);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("SubjectId", row["SubjectId"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.AddWithValue("TotalStudents", Convert.ToInt32(row["TotalStudents"]));
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					con.Close();
				}
				k++;
				Thread.Sleep(10);
				bgProcessOLevel.ReportProgress(k + 1);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
		}
	}

	private void UnProcessStudentsRankingPerSubject()
	{
		try
		{
			con.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				CommandText = "UPDATE tbl_Scores_OL_Report SET SubPosLO=@SubPosLO,SubPosEOT=@SubPosEOT,SubPosLOEOT=@SubPosLOEOT WHERE SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = con
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("SubPosLO", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SubPosEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SubPosLOEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", _Term);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", _Class);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			con.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
		}
	}

	private void UnProcessClassRanking()
	{
		try
		{
			con.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				CommandText = "UPDATE tbl_Scores_OL_Report SET PICLOEOT=@PICLOEOT,PICLO=@PICLO,PICEOT=@PICEOT,PISLOEOT=@PISLOEOT,PISLO=@PISLO,PISEOT=@PISEOT,SIC=@SIC,SIS=@SIS,GrandAvg=@GrandAvg,GrandAvgLO=@GrandAvgLO,GrandAvgEOT=@GrandAvgEOT WHERE SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = con
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("PICLO", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("PISLO", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("PICLOEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("PISLOEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("PICEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("PISEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SIC", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SIS", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("GrandAvg", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("GrandAvgLO", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("GrandAvgEOT", DBNull.Value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("SemesterId", _Term);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("ClassId", _Class);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			con.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.bgProcessOLevel = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.bgProcessOLevel.WorkerReportsProgress = true;
		this.bgProcessOLevel.WorkerSupportsCancellation = true;
		this.bgProcessOLevel.DoWork += new System.ComponentModel.DoWorkEventHandler(bgProcessOLevel_DoWork);
		this.bgProcessOLevel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgProcessOLevel_ProgressChanged);
		this.bgProcessOLevel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgProcessOLevel_RunWorkerCompleted);
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(295, 37);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(295, 37);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "RegradeStudentsProgressNC";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Regrading students, please wait...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RegradeStudentsProgressNC_FormClosing);
		base.Load += new System.EventHandler(ProcessOLevel_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
