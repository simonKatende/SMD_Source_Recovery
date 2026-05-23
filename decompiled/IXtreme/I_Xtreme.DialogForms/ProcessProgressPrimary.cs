using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class ProcessProgressPrimary : XtraForm
{
	private int i;

	private int k = 0;

	private string currentTask = string.Empty;

	private int maximum = 0;

	private string connectionString = DataConnection.ConnectToDatabase();

	private string semester = ProcessPrimaryReports.CurrentSemester();

	private string classForProcessing = ProcessPrimaryReports.ClassForProcessing();

	private bool sendToDiv3ForF9InEng = ProcessPrimaryReports.SendToDiv3ForF9InEng;

	private bool sendToDiv2ForP8OrP7InEng = ProcessPrimaryReports.SendToDiv2ForP8OrP7InEng;

	private bool sendToDiv2ForF9InMTC = ProcessPrimaryReports.SendToDiv2ForF9InMTC;

	private bool assignGradeX = ProcessPrimaryReports.AssignGradeX;

	private IContainer components = null;

	private BackgroundWorker bgProcessOLevel;

	private System.Windows.Forms.Timer timer1;

	private ProgressBarControl progressBarControl1;

	public ProcessProgressPrimary()
	{
		InitializeComponent();
	}

	private void bgProcessOLevel_DoWork(object sender, DoWorkEventArgs e)
	{
		ProcessPrimaryReportCards();
	}

	private void ProcessOLevel_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			timer1.Enabled = false;
			bgProcessOLevel.RunWorkerAsync();
		}
	}

	private void bgProcessOLevel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Reports Processed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Dispose();
	}

	private void ProcessProgressOLevel_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void ProcessProgressOLevel_FormClosing(object sender, FormClosingEventArgs e)
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

	private void ProcessPrimaryReportCards()
	{
		try
		{
			currentTask = "Task 1/8: Grading students...";
			string commandText = "UPDATE tbl_GeneralReports_Grading_Primary SET OutOf=@OutOf,BestInEight=@BestInEight,Agg=@Agg,Div=@Div,ClassTeacherComment=@ClassTeacherComment,HeadTeacherComment=@HeadTeacherComment,DOSComment=@DOSComment,Comment4=@Comment4,TotalMark=@TotalMark,AvMark=@AvMark WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId";
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				string selectCommandText = $"SELECT * FROM tbl_Stud WHERE ClassId='{classForProcessing}'";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "myStudents");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				k = 0;
				maximum = dataTable.Rows.Count;
				foreach (DataRow row in dataTable.Rows)
				{
					string selectCommandText2 = string.Format("SELECT * FROM tbl_GeneralReportCards_Primary WHERE StudentNumber='{0}' AND SemesterId='{1}' AND ClassId='{2}' AND IsAssessed=1", row["StudentNumber"].ToString().TrimStart().TrimEnd(), semester, classForProcessing);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, connectionString);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "PrimaryReports");
					DataTable dataTable2 = new DataTable();
					dataTable2 = dataSet2.Tables[0];
					double num = 0.0;
					int num2 = 0;
					double value = 0.0;
					string text = string.Empty;
					foreach (DataRow row2 in dataTable2.Rows)
					{
						double result = (double.TryParse(row2["AvMark"].ToString(), out result) ? result : 0.0);
						int result2 = (int.TryParse(row2["Grade"].ToString(), out result2) ? result2 : 9);
						double[] source = new double[1] { result };
						num += source.Sum();
						int[] source2 = new int[1] { result2 };
						num2 += source2.Sum();
						value = (float)(num / (double)row2.Table.Rows.Count);
						text = $"{result2},{text}";
					}
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("SELECT * FROM OLevelDivisionScale", connectionString);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "divisionScale");
					DataTable dataTable3 = new DataTable();
					dataTable3 = dataSet3.Tables[0];
					foreach (DataRow row3 in dataTable3.Rows)
					{
						Random random = new Random();
						int num3 = (int)(random.NextDouble() * 5.0 + 1.0);
						string[] array = Regex.Split(text, "\\D+");
						int parsedValue = 0;
						Array.Sort(array);
						int num4 = Convert.ToInt32(array.SkipWhile((string item) => string.IsNullOrEmpty(item)).Take(4).Sum((string item) => int.TryParse(item, out parsedValue) ? parsedValue : parsedValue));
						if (!(Convert.ToDouble(row3["Debut"]) <= (double)num4) || !((double)num4 <= Convert.ToDouble(row3["EndMark"])))
						{
							continue;
						}
						using SqlConnection sqlConnection = new SqlConnection(connectionString);
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = commandText,
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter.Value = row["StudentNumber"].ToString().TrimStart().TrimEnd();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter.Value = classForProcessing;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@TotalMark", SqlDbType.Float);
							sqlParameter.Value = num;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Div", SqlDbType.VarChar, 3);
							sqlParameter.Value = row3["Grade"].ToString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Agg", SqlDbType.Int);
							sqlParameter.Value = num2;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@BestInEight", SqlDbType.Int);
							sqlParameter.Value = num4;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@OutOf", SqlDbType.Int);
							sqlParameter.Value = dataTable.Rows.Count;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter.Value = semester;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.Float);
							sqlParameter.Value = Math.Round(value, 2);
							sqlParameter.Direction = ParameterDirection.Input;
							switch (num3)
							{
							case 1:
								sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["ClassTeacherComment"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["HeadTeacherComment"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["DOSComment"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["Comment4"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								break;
							case 2:
								sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["ClassTeacherComment1"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["HeadTeacherComment1"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["DOSComment1"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["Comment41"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								break;
							case 3:
								sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["ClassTeacherComment2"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["HeadTeacherComment2"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["DOSComment2"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["Comment42"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								break;
							case 4:
								sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["ClassTeacherComment3"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["HeadTeacherComment3"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["DOSComment3"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["Comment43"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								break;
							case 5:
								sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["ClassTeacherComment4"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["HeadTeacherComment4"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["DOSComment4"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand.Parameters.Add("@Comment4", SqlDbType.VarChar, 80);
								sqlParameter.Value = row3["Comment44"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								break;
							}
							sqlCommand.ExecuteNonQuery();
						}
						sqlConnection.Close();
					}
					k++;
					Thread.Sleep(10);
					bgProcessOLevel.ReportProgress(k);
				}
			}
			SendToDiv3ForF9InEnglish();
			SendToDiv2ForP8OrP7InEnglish();
			SendToDiv2ForF9InMaths();
			AssignGradeXForFewerSubjects();
			AssignXForMissingMTCEng();
			AssignPositionInClass();
			AssignPositionsPerStream();
			PromoteStudents();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void SendToDiv3ForF9InEnglish()
	{
		if (!sendToDiv3ForF9InEng)
		{
			return;
		}
		currentTask = "Task 2/8: Assigning Div III for F9 in English ...";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_GeneralReportCards_Primary  WHERE SubjectId='English' AND Category='F9' AND SemesterId='{semester}' AND ClassId='{classForProcessing}'", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TestStudents");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_GeneralReports_Grading_Primary SET Div='III' WHERE (Div='I' OR Div='II') AND StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = semester;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = classForProcessing;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void SendToDiv2ForP8OrP7InEnglish()
	{
		if (!sendToDiv2ForP8OrP7InEng)
		{
			return;
		}
		currentTask = "Task 3/8: Assigning Div II for P8 or P7 in English...";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_GeneralReportCards_Primary WHERE SubjectId='English' AND (Category='P7' OR Category='P8') AND SemesterId='{semester}' AND ClassId='{classForProcessing}'", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TestStudents");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_GeneralReports_Grading_Primary SET Div='II' WHERE Div='I' AND StudentNumber=@StudentNumber AND ClassId=@ClassId AND SemesterId=@SemesterId",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = classForProcessing;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = semester;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void SendToDiv2ForF9InMaths()
	{
		if (!sendToDiv2ForF9InMTC)
		{
			return;
		}
		currentTask = "Task 4/8: Assigning Div II for F9 in Mathematics...";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_GeneralReportCards_Primary WHERE SubjectId='456-Mathematics' AND Category='F9' AND SemesterId='{semester}' AND ClassId='{classForProcessing}'", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TestStudents");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_GeneralReports_Grading_Primary SET Div='II' WHERE Div='I' AND StudentNumber=@StudentNumber AND ClassId=@ClassId AND SemesterId=@SemesterId",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = classForProcessing;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = semester;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void AssignGradeXForFewerSubjects()
	{
		if (!assignGradeX)
		{
			return;
		}
		currentTask = "Task 5/8: Assigning Grade X for less than 4 Subjects...";
		string selectCommandText = $"SELECT * FROM tbl_Stud WHERE ClassId='{classForProcessing}'";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "students");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT * FROM tbl_GeneralReportCards_Primary WHERE  SemesterId='{0}' AND StudentNumber='{1}' AND ClassId='{2}' AND IsAssessed=1", semester, row["StudentNumber"], classForProcessing), connectionString);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "subjects");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet2.Tables[0];
			if (dataTable2.Rows.Count < 4)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_GeneralReports_Grading_Primary SET Div='X' WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = classForProcessing;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = semester;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void AssignXForMissingMTCEng()
	{
		currentTask = "Task 6/8: Assigning Grade X for missing English or Mathematics...";
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_GeneralReportCards_Primary WHERE semesterId='{semester}' AND ((SubjectId='Mathematics' AND AvMark=NULL) OR (SubjectId='English' AND AvMark=NULL)) AND ClassId='{classForProcessing}'", connectionString);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "gradeX");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_GeneralReports_Grading_Primary SET Div='X' WHERE SemesterId=@SemesterId AND StudentNumber=@StudentNumber AND ClassId=@ClassId",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = classForProcessing;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = semester;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void AssignPositionInClass()
	{
		currentTask = "Task 7/8: Generating Class performance positions...";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,SemesterId,AvMark, RANK() OVER (ORDER BY AvMark DESC) AS Pos FROM tbl_GeneralReports_Grading_Primary WHERE SemesterId ='{semester}' AND ClassId='{classForProcessing}'", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "_positions");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			double result = (double.TryParse(row["AvMark"].ToString(), out result) ? result : 0.0);
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				string commandText = string.Format("UPDATE tbl_GeneralReports_Grading_Primary SET Position={0} WHERE AvMark={1} AND SemesterId=@SemesterId AND ClassId=@ClassId", row["Pos"], result);
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = commandText,
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = classForProcessing;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = semester;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void AssignPositionsPerStream()
	{
		currentTask = "Task 8/8: Generating Stream performance positions...";
		string text = string.Empty;
		int num = 0;
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM Streams WHERE ClassId='{classForProcessing}'", connectionString))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PIS");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				num++;
				text = string.Format("{0} {1}", text, row["StreamId"]);
			}
		}
		k = 0;
		maximum = num;
		string[] array = text.TrimStart().TrimEnd().Split();
		foreach (string text2 in array)
		{
			currentTask = "Task 8/8: Generating Stream (" + text2 + ") performance positions...";
			if (!(text2 != string.Empty))
			{
				break;
			}
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				string selectCommandText = $"SELECT s.StudentNumber, s.StreamId, g.SemesterId, g.AvMark,RANK() OVER (ORDER BY g.AvMark DESC) AS Positions FROM tbl_GeneralReports_Grading_Primary g INNER JOIN tbl_Stud s ON g.StudentNumber = s.StudentNumber WHERE g.SemesterId ='{semester}' AND s.StreamId='{text2}' AND s.ClassId='{classForProcessing}'";
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, selectConnection);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "positions");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				foreach (DataRow row2 in dataTable2.Rows)
				{
					double result = (double.TryParse(row2["AvMark"].ToString(), out result) ? result : 0.0);
					using SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = string.Format("UPDATE tbl_GeneralReports_Grading_Primary SET PositionInStream={0},StudentsInStream={1} WHERE AvMark={2} AND SemesterId=@SemesterId AND StudentNumber=@StudentNumber AND ClassId=@ClassId", row2["Positions"], dataTable2.Rows.Count, result),
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = row2["StudentNumber"].ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter.Value = classForProcessing;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter.Value = semester;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand.ExecuteNonQuery();
					}
					sqlConnection.Close();
				}
			}
			k++;
			Thread.Sleep(10);
			bgProcessOLevel.ReportProgress(k);
		}
	}

	private void Promote(string cmdText)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = cmdText,
			CommandType = CommandType.Text
		};
		sqlCommand.ExecuteNonQuery();
	}

	private void PromoteStudents()
	{
		if (semester.Contains("TermIII") && classForProcessing != "P.7")
		{
			string nextClassAfterThis = Classes.GetNextClassAfterThis(classForProcessing);
			Promote($"UPDATE tbl_GeneralReports_Grading_Primary Set promoStatus='PROMOTED to {nextClassAfterThis}' WHERE SemesterId='{semester}' AND AvMark > {OLevelAutoCutOff.Promoted} AND ClassId='{classForProcessing}'");
			Promote($"UPDATE tbl_GeneralReports_Grading_Primary Set promoStatus='PROMOTED TO {nextClassAfterThis} ON PROBATION' WHERE SemesterId='{semester}' AND (AvMark >= {OLevelAutoCutOff.ProbationDebut} AND AvMark <= {OLevelAutoCutOff.Promoted}) AND ClassId='{classForProcessing}'");
			Promote($"UPDATE tbl_GeneralReports_Grading_Primary Set promoStatus='DOES NOT QUALIFY FOR {nextClassAfterThis}' WHERE SemesterId='{semester}' AND AvMark < {OLevelAutoCutOff.ProbationDebut} AND ClassId='{classForProcessing}'");
		}
	}

	private void bgProcessOLevel_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
		Text = currentTask;
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
		this.bgProcessOLevel = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer();
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
		this.progressBarControl1.Size = new System.Drawing.Size(418, 44);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(418, 44);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "ProcessProgressPrimary";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Processing reports, please wait...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ProcessProgressOLevel_FormClosing);
		base.Load += new System.EventHandler(ProcessOLevel_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(ProcessProgressOLevel_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
