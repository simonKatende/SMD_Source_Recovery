using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class ProcessProgressALevel : XtraForm
{
	private static SqlTransaction transaction;

	private static SqlTransaction trans;

	private int i;

	private int k = 0;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private static string connectionString = DataConnection.ConnectToDatabase();

	private static DataTable pbDTable = ALevelGradingScale.PaperBalancingScale;

	private static DataTable AComments = ALevelGradingScale.ALevelComments;

	private double gpValue = GeneralPaper.Value;

	private double compValue = Computing.Value;

	private double subMValue = SubMaths.Value;

	private string _Class = string.Empty;

	private string _Semester = string.Empty;

	private string StreamEn = string.Empty;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker bgProcessALevel;

	private ProgressBarControl progressBarControl1;

	public ProcessProgressALevel(string __Class, string __Semester, string StreamEn)
	{
		InitializeComponent();
		_Class = __Class;
		_Semester = __Semester;
		this.StreamEn = StreamEn;
	}

	private void bgProcessALevel_DoWork(object sender, DoWorkEventArgs e)
	{
		ProcessALevelReportCards();
	}

	private void ProcessALevel_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			timer1.Enabled = false;
			bgProcessALevel.RunWorkerAsync();
		}
	}

	private void bgProcessALevel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Reports Process Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Dispose();
	}

	private void ProcessProgressALevel_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void ProcessProgressALevel_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bgProcessALevel.IsBusy)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to cancel the current process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				bgProcessALevel.CancelAsync();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
		}
	}

	private void ProcessALevelReportCards()
	{
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_ALevelReport WHERE SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
			sqlParameter.Value = _Semester;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
			sqlParameter.Value = _Class;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		double result = 0.0;
		double result2 = 0.0;
		double result3 = 0.0;
		double result4 = 0.0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings WHERE SemesterId='{_Semester}' AND ClassId='{_Class}'", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "GradingRatios");
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			result = (double.TryParse(row["HoP"].ToString(), out result) ? result : 0.0);
			result2 = (double.TryParse(row["BOT"].ToString(), out result2) ? result2 : 0.0);
			result3 = (double.TryParse(row["MOT"].ToString(), out result3) ? result3 : 0.0);
			result4 = (double.TryParse(row["EOT"].ToString(), out result4) ? result4 : 0.0);
		}
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId = '{_Class}' AND StreamId = '{StreamEn}'", connectionString);
		using (DataSet dataSet2 = new DataSet())
		{
			sqlDataAdapter2.Fill(dataSet2, "myStudents");
			DataTable dataTable = new DataTable();
			dataTable = dataSet2.Tables[0];
			k = 0;
			maximum = dataTable.Rows.Count;
			currentTask = "Task 2/7: Ascertaining paper balancing...";
			foreach (DataRow row2 in dataTable.Rows)
			{
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("SELECT * FROM ALevelSubjects", connectionString);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "mySubjects");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet3.Tables[0];
				foreach (DataRow row3 in dataTable2.Rows)
				{
					string selectCommandText = string.Format("SELECT StudentNumber,SubjectId,PaperId,ISNULL(Grade,10) AS Grade,ISNULL(AvMark,0) AS AvMark,Category FROM tbl_GeneralReport_AL WHERE SubjectId='{0}' AND SemesterId='{1}' AND StudentNumber='{2}' AND ClassId='{3}' GROUP BY StudentNumber,SubjectId,PaperId,Grade,AvMark,Category,ClassId", row3["SubjectId"], _Semester, row2["StudentNumber"], _Class);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText, connectionString);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "mySubjects");
					if (dataSet4.Tables[0].Rows.Count <= 0)
					{
						continue;
					}
					List<int> list = new List<int>();
					List<double> list2 = new List<double>();
					double num = 0.0;
					foreach (DataRow row4 in dataSet4.Tables[0].Rows)
					{
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							list.Add(Convert.ToInt32(row4["Grade"].ToString()));
							list2.Add(Convert.ToDouble(row4["AvMark"].ToString()));
							num = dataSet4.Tables[0].Rows.Count;
						}
					}
					int[] array = new int[0];
					array = list.ToArray();
					Array.Sort(array);
					Array.Reverse(array);
					double num2 = array.Sum();
					double num3 = Math.Round(list2.ToArray().Sum() / num, 1);
					string value = string.Empty;
					int num4 = 0;
					string value2 = string.Empty;
					if (num == 4.0)
					{
						if (array.Max() <= 3 && array[1] <= 2)
						{
							value = "A";
							num4 = 6;
							value2 = ALevelGradingScale.GradeComment("A");
						}
						else if (array.Max() == 3 && array[1] == 3)
						{
							value = "B";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("B");
						}
						else if (array.Max() == 4 && array[1] <= 3)
						{
							value = "B";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("B");
						}
						else if (array.Max() == 4 && array[1] == 4)
						{
							value = "C";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("C");
						}
						else if (array.Max() == 5 && array[1] <= 4)
						{
							value = "C";
							num4 = 4;
							value2 = ALevelGradingScale.GradeComment("C");
						}
						else if (array.Max() == 5 && array[1] == 5)
						{
							value = "D";
							num4 = 3;
							value2 = ALevelGradingScale.GradeComment("D");
						}
						else if (array.Max() == 6 && array[1] <= 5)
						{
							value = "D";
							num4 = 3;
							value2 = ALevelGradingScale.GradeComment("D");
						}
						else if (array.Max() == 6 && array[1] == 6)
						{
							value = "E";
							num4 = 2;
							value2 = ALevelGradingScale.GradeComment("E");
						}
						else if (array.Max() == 7 && array[1] <= 6)
						{
							value = "E";
							num4 = 2;
							value2 = ALevelGradingScale.GradeComment("E");
						}
						else if (array.Max() == 7 && array[1] == 7 && array[2] <= 6)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 8 && array[1] <= 8 && array[2] <= 8 && array[3] <= 8)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] <= 7 && array[2] <= 7 && array[3] <= 7)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] >= 8)
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
						else if (array.Max() == 10)
						{
							value = "-";
							num4 = 0;
							value2 = "-";
						}
						else
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
					}
					else if (num == 3.0)
					{
						if (array.Max() < 3)
						{
							value = "A";
							num4 = 6;
							value2 = ALevelGradingScale.GradeComment("A");
						}
						else if (array.Max() == 3 && array[1] <= 2)
						{
							value = "A";
							num4 = 6;
							value2 = ALevelGradingScale.GradeComment("A");
						}
						else if (array.Max() == 3 && array[1] == 3)
						{
							value = "B";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("B");
						}
						else if (array.Max() == 4 && array[1] <= 3)
						{
							value = "B";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("B");
						}
						else if (array.Max() == 4 && array[1] == 4)
						{
							value = "C";
							num4 = 4;
							value2 = ALevelGradingScale.GradeComment("C");
						}
						else if (array.Max() == 5 && array[1] <= 4)
						{
							value = "C";
							num4 = 4;
							value2 = ALevelGradingScale.GradeComment("C");
						}
						else if (array.Max() == 5 && array[1] == 5)
						{
							value = "D";
							num4 = 3;
							value2 = ALevelGradingScale.GradeComment("D");
						}
						else if (array.Max() == 6 && array[1] <= 5)
						{
							value = "D";
							num4 = 3;
							value2 = ALevelGradingScale.GradeComment("D");
						}
						else if (array.Max() == 6 && array[1] == 6)
						{
							value = "E";
							num4 = 2;
							value2 = ALevelGradingScale.GradeComment("E");
						}
						else if (array.Max() == 7 && array[1] <= 6)
						{
							value = "E";
							num4 = 2;
							value2 = ALevelGradingScale.GradeComment("E");
						}
						else if (array.Max() == 7 && array[1] == 7)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 8)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] <= 6)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] == 7 && array[2] <= 7)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] == 8 && array[2] < 8)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] == 8 && array[2] == 8)
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
						else if (array.Max() == 10)
						{
							value = "-";
							num4 = 0;
							value2 = "-";
						}
						else
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
					}
					else if (num == 2.0)
					{
						if (array.Max() == 1)
						{
							value = "A";
							num4 = 6;
							value2 = ALevelGradingScale.GradeComment("A");
						}
						else if (array.Max() == 2 && array[1] <= 2)
						{
							value = "A";
							num4 = 6;
							value2 = ALevelGradingScale.GradeComment("A");
						}
						else if (array.Max() == 3 && array[1] <= 3)
						{
							value = "B";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("B");
						}
						else if (array.Max() == 4 && array[1] <= 4)
						{
							value = "C";
							num4 = 4;
							value2 = ALevelGradingScale.GradeComment("C");
						}
						else if (array.Max() == 5 && array[1] <= 5)
						{
							value = "D";
							num4 = 3;
							value2 = ALevelGradingScale.GradeComment("D");
						}
						else if (array.Max() == 6 && array[1] <= 6)
						{
							value = "E";
							num4 = 2;
							value2 = ALevelGradingScale.GradeComment("E");
						}
						else if (array.Max() == 7 && array[1] <= 7)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 8 && array[1] <= 7)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] <= 6)
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (array.Max() == 9 && array[1] >= 7)
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
						else if (array.Max() == 10)
						{
							value = "-";
							num4 = 0;
							value2 = "-";
						}
						else
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
					}
					else if (num == 1.0)
					{
						if (list.Contains(1))
						{
							value = "A";
							num4 = 6;
							value2 = ALevelGradingScale.GradeComment("A");
						}
						else if (list.Contains(2))
						{
							value = "B";
							num4 = 5;
							value2 = ALevelGradingScale.GradeComment("B");
						}
						else if (list.Contains(3))
						{
							value = "C";
							num4 = 4;
							value2 = ALevelGradingScale.GradeComment("C");
						}
						else if (list.Contains(4))
						{
							value = "D";
							num4 = 3;
							value2 = ALevelGradingScale.GradeComment("D");
						}
						else if (list.Contains(5))
						{
							value = "E";
							num4 = 2;
							value2 = ALevelGradingScale.GradeComment("E");
						}
						else if (list.Contains(6))
						{
							value = "O";
							num4 = 1;
							value2 = ALevelGradingScale.GradeComment("O");
						}
						else if (list.Contains(7) || list.Contains(8))
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
						else if (list.Contains(9))
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
						else if (list.Contains(10))
						{
							value = "-";
							num4 = 0;
							value2 = "-";
						}
						else
						{
							value = "F";
							num4 = 0;
							value2 = ALevelGradingScale.GradeComment("F");
						}
					}
					using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
					sqlConnection2.Open();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "UPDATE tbl_GeneralReport_Grading_AL SET Points=@Points,Grade=@Grade,AverageMark=@AverageMark,Comment=@Comment WHERE SemesterId=@SemesterId AND SubjectId=@SubjectId AND StudentNumber=@StudentNumber AND ClassId=@ClassId",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = row2["StudentNumber"];
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = row3["SubjectId"];
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter2.Value = _Semester;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter2.Value = _Class;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@Points", SqlDbType.Int);
						sqlParameter2.Value = num4;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@Grade", SqlDbType.VarChar, 3);
						sqlParameter2.Value = value;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@AverageMark", SqlDbType.Float);
						sqlParameter2.Value = num3;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@Comment", SqlDbType.VarChar, 80);
						sqlParameter2.Value = value2;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					sqlConnection2.Close();
				}
				k++;
				Thread.Sleep(10);
				bgProcessALevel.ReportProgress(k);
			}
			dataSet2.Clear();
			dataSet2.Dispose();
			sqlDataAdapter2.Dispose();
		}
		k = 0;
		currentTask = "Task 3/7: Grading students on subsidiary subjects scores...";
		using (SqlConnection sqlConnection3 = new SqlConnection(connectionString))
		{
			sqlConnection3.Open();
			trans = sqlConnection3.BeginTransaction();
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = $"UPDATE tbl_GeneralReport_Grading_AL SET Grade='O',Points='1' WHERE SemesterId='{_Semester}' AND SubjectId='General Paper' AND AverageMark >= {gpValue} AND ClassId='{_Class}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand3.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = $"UPDATE tbl_GeneralReport_Grading_AL SET Grade='F',Points='0' WHERE SemesterId='{_Semester}' AND SubjectId='General Paper' AND AverageMark < {gpValue} AND ClassId='{_Class}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand5 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = $"UPDATE tbl_GeneralReport_Grading_AL SET Grade='O',Points='1' WHERE SemesterId='{_Semester}' AND SubjectId='Sub Math' AND AverageMark >= {subMValue} AND ClassId='{_Class}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand5.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand6 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = $"UPDATE tbl_GeneralReport_Grading_AL SET Grade='F',Points='0' WHERE SemesterId='{_Semester}' AND SubjectId='Sub Math' AND AverageMark < {subMValue} AND ClassId='{_Class}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand6.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand7 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = $"UPDATE tbl_GeneralReport_Grading_AL SET Grade='O',Points='1' WHERE SemesterId='{_Semester}' AND SubjectId='ICT' AND AverageMark >= {compValue} AND ClassId='{_Class}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand7.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand8 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = $"UPDATE tbl_GeneralReport_Grading_AL SET Grade='F',Points='0' WHERE SemesterId='{_Semester}' AND SubjectId='ICT' AND AverageMark < {compValue} AND ClassId='{_Class}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand8.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection3.Close();
			k++;
			Thread.Sleep(10);
			bgProcessALevel.ReportProgress(k);
		}
		string selectCommandText2 = $"SELECT * FROM tbl_Stud WHERE ClassId='{_Class}' AND StreamId = '{StreamEn}'";
		using (SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText2, connectionString))
		{
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5, "allStudents");
			DataTable dataTable3 = new DataTable();
			dataTable3 = dataSet5.Tables[0];
			k = 0;
			maximum = dataSet5.Tables[0].Rows.Count;
			currentTask = "Task 4/7: Assigning Grade X for missing an exam...";
			foreach (DataRow row5 in dataTable3.Rows)
			{
				string selectCommandText3 = string.Format("SELECT StudentNumber,SemesterId, SubjectId,PaperId,HoP,BOT,MOT,EOT FROM tbl_GeneralReport_AL WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND ClassId='{2}'", row5["StudentNumber"], _Semester, _Class);
				using (SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText3, connectionString))
				{
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6, "Papers");
					DataTable dataTable4 = new DataTable();
					dataTable4 = dataSet6.Tables[0];
					foreach (DataRow row6 in dataTable4.Rows)
					{
						if ((row6["HoP"].ToString() == "-" || row6["HoP"].ToString() == string.Empty) && result > 0.0)
						{
							using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
							sqlConnection4.Open();
							transaction = sqlConnection4.BeginTransaction();
							SqlCommand sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection4;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_AL SET Category='-' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND PaperId='{3}' AND ClassId='{4}'", row5["StudentNumber"], _Semester, row6["SubjectId"], row6["PaperId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand10 = sqlCommand9)
							{
								sqlCommand10.ExecuteNonQuery();
							}
							sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection4;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_Grading_AL SET Points=0,Grade='X',Comment='Missed Examinations' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND ClassId='{3}'", row5["StudentNumber"], _Semester, row6["SubjectId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand11 = sqlCommand9)
							{
								sqlCommand11.ExecuteNonQuery();
							}
							transaction.Commit();
							sqlConnection4.Close();
						}
						else if ((row6["BOT"].ToString() == "-" || row6["BOT"].ToString() == string.Empty) && result2 > 0.0)
						{
							using SqlConnection sqlConnection5 = new SqlConnection(connectionString);
							sqlConnection5.Open();
							transaction = sqlConnection5.BeginTransaction();
							SqlCommand sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection5;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_AL SET Category='-' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND PaperId='{3}' AND ClassId='{4}'", row5["StudentNumber"], _Semester, row6["SubjectId"], row6["PaperId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand12 = sqlCommand9)
							{
								sqlCommand12.ExecuteNonQuery();
							}
							sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection5;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_Grading_AL SET Points=0,Grade='X',Comment='Missed Examinations' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND ClassId='{3}'", row5["StudentNumber"], _Semester, row6["SubjectId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand13 = sqlCommand9)
							{
								sqlCommand13.ExecuteNonQuery();
							}
							transaction.Commit();
							sqlConnection5.Close();
						}
						else if ((row6["MOT"].ToString() == "-" || row6["MOT"].ToString() == string.Empty) && result3 > 0.0)
						{
							using SqlConnection sqlConnection6 = new SqlConnection(connectionString);
							sqlConnection6.Open();
							transaction = sqlConnection6.BeginTransaction();
							SqlCommand sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection6;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_AL SET Category='-' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND PaperId='{3}' AND ClassId='{4}'", row5["StudentNumber"], _Semester, row6["SubjectId"], row6["PaperId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand14 = sqlCommand9)
							{
								sqlCommand14.ExecuteNonQuery();
							}
							sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection6;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_Grading_AL SET Points=0,Grade='X',Comment='Missed Examinations' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND ClassId='{3}'", row5["StudentNumber"], _Semester, row6["SubjectId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand15 = sqlCommand9)
							{
								sqlCommand15.ExecuteNonQuery();
							}
							transaction.Commit();
							sqlConnection6.Close();
						}
						else
						{
							if ((!(row6["EOT"].ToString() == "-") && !(row6["EOT"].ToString() == string.Empty)) || !(result4 > 0.0))
							{
								continue;
							}
							using SqlConnection sqlConnection7 = new SqlConnection(connectionString);
							sqlConnection7.Open();
							transaction = sqlConnection7.BeginTransaction();
							SqlCommand sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection7;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_AL SET Category='-' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND PaperId='{3}' AND ClassId='{4}'", row5["StudentNumber"], _Semester, row6["SubjectId"], row6["PaperId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand16 = sqlCommand9)
							{
								sqlCommand16.ExecuteNonQuery();
							}
							sqlCommand9 = new SqlCommand();
							sqlCommand9.Transaction = transaction;
							sqlCommand9.Connection = sqlConnection7;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_Grading_AL SET Points=0,Grade='X',Comment='Missed Examinations' WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND SubjectId='{2}' AND ClassId='{3}'", row5["StudentNumber"], _Semester, row6["SubjectId"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand17 = sqlCommand9)
							{
								sqlCommand17.ExecuteNonQuery();
							}
							transaction.Commit();
							sqlConnection7.Close();
						}
					}
				}
				k++;
				Thread.Sleep(10);
				bgProcessALevel.ReportProgress(k);
			}
			dataSet5.Clear();
			dataSet5.Dispose();
			sqlDataAdapter5.Dispose();
		}
		SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{_Class}' AND StreamId='{StreamEn}'", connectionString);
		using (DataSet dataSet7 = new DataSet())
		{
			sqlDataAdapter7.Fill(dataSet7, "__total_points");
			DataTable dataTable5 = new DataTable();
			dataTable5 = dataSet7.Tables[0];
			k = 0;
			maximum = dataSet7.Tables[0].Rows.Count;
			currentTask = "Task 5/7: Adding up points for each student...";
			foreach (DataRow row7 in dataTable5.Rows)
			{
				using (SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(string.Format("SELECT StudentNumber, SemesterId, SUM(ISNULL(Points,0)) AS _TotalPoints FROM tbl_GeneralReport_Grading_AL WHERE StudentNumber = '{0}' AND SemesterId = '{1}' AND ClassId='{2}' GROUP BY StudentNumber, SemesterId,ClassId", row7["StudentNumber"], _Semester, _Class), connectionString))
				{
					using DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8, "Point_Totals");
					DataTable dataTable6 = new DataTable();
					dataTable6 = new DataTable();
					dataTable6 = dataSet8.Tables[0];
					IEnumerator enumerator8 = dataTable6.Rows.GetEnumerator();
					try
					{
						if (enumerator8.MoveNext())
						{
							DataRow dataRow8 = (DataRow)enumerator8.Current;
							using SqlConnection sqlConnection8 = new SqlConnection(connectionString);
							sqlConnection8.Open();
							SqlCommand sqlCommand9 = new SqlCommand();
							sqlCommand9.Connection = sqlConnection8;
							sqlCommand9.CommandText = string.Format("UPDATE tbl_GeneralReport_Grading_AL SET TotalPoints={0} WHERE SemesterId='{1}' AND StudentNumber = '{2}' AND ClassId='{3}'", Convert.ToDouble(dataRow8["_TotalPoints"]), _Semester, row7["StudentNumber"], _Class);
							sqlCommand9.CommandType = CommandType.Text;
							using (SqlCommand sqlCommand18 = sqlCommand9)
							{
								sqlCommand18.ExecuteNonQuery();
							}
							sqlConnection8.Close();
						}
					}
					finally
					{
						IDisposable disposable = enumerator8 as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				k++;
				Thread.Sleep(10);
				bgProcessALevel.ReportProgress(k);
			}
			dataSet7.Clear();
			dataSet7.Dispose();
			sqlDataAdapter7.Dispose();
		}
		string selectCommandText4 = $"SELECT g.StudentNumber, g.SubjectId, g.Points, g.Grade, g.Comment, g.AverageMark,ISNULL(r.AvMark,0) AS AvMark, s.Paper,s.Category AS SubCategory, r.HoP, r.BOT,r.MOT, r.EOT, r.Initial,r.Category, g.TotalPoints, r.Grade AS GradeScore, g.SemesterId  FROM  tbl_GeneralReport_Grading_AL g INNER JOIN tbl_GeneralReport_AL r ON g.StudentNumber = r.StudentNumber AND g.SubjectId = r.SubjectId AND g.SemesterId = r.SemesterId LEFT OUTER JOIN ALevelSubjects_Categorised s ON r.PaperId = s.PaperId  GROUP BY g.StudentNumber, g.SubjectId, g.Points, g.Grade, g.Comment, g.AverageMark, s.Paper,s.Category, r.HoP, r.BOT, r.MOT, r.EOT, r.Initial, r.Category, g.TotalPoints, r.AvMark, r.Grade, g.SemesterId,g.ClassId  HAVING (g.SemesterId ='{ProcessALevelReports.CurrentSemester()}' AND g.ClassId='{_Class}') ORDER BY g.StudentNumber,g.SubjectId";
		string commandText = "INSERT INTO tbl_ALevelReport (StudentNumber,SemesterId,SubjectId,Paper,HoP,BOT,MOT,EOT,AvMark,Category,Grade,Comment,Initial,Points,AverageMark,TotalPoints,CategoryPoints,SubGroup,ClassId)VALUES(@StudentNumber,@SemesterId,@SubjectId,@Paper,@HoP,@BOT,@MOT,@EOT,@AvMark,@Category,@Grade,@Comment,@Initial,@Points,@AverageMark,@TotalPoints,@CategoryPoints,@SubGroup,@ClassId)";
		using (SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommandText4, DataConnection.ConnectToDatabase()))
		{
			using (DataSet dataSet9 = new DataSet())
			{
				sqlDataAdapter9.Fill(dataSet9, "_ALevel_Report");
				DataTable dataTable7 = new DataTable();
				dataTable7 = dataSet9.Tables[0];
				k = 0;
				maximum = dataSet9.Tables[0].Rows.Count;
				currentTask = "Task 6/7: Generating final report card...";
				foreach (DataRow row8 in dataTable7.Rows)
				{
					using (SqlConnection sqlConnection9 = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						sqlConnection9.Open();
						string commandText2 = string.Format("SELECT * FROM tbl_ALevelReport WHERE StudentNumber='{0}' AND SemesterId='{1}' AND SubjectId='{2}' AND Grade='{3}' AND ClassId='{4}'", row8["StudentNumber"].ToString(), row8["SemesterId"].ToString(), row8["SubjectId"].ToString(), row8["Grade"], _Class);
						using SqlCommand sqlCommand19 = new SqlCommand
						{
							Connection = sqlConnection9,
							CommandText = commandText2,
							CommandType = CommandType.Text
						};
						using SqlDataReader sqlDataReader = sqlCommand19.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							sqlConnection9.Close();
							using SqlConnection sqlConnection10 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection10.Open();
							using SqlCommand sqlCommand20 = new SqlCommand
							{
								Connection = sqlConnection10,
								CommandText = commandText,
								CommandType = CommandType.Text
							};
							SqlParameter sqlParameter3 = sqlCommand20.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = row8["StudentNumber"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter3.Value = row8["SemesterId"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter3.Value = row8["SubjectId"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter3.Value = _Class;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@Paper", SqlDbType.VarChar, 15);
							sqlParameter3.Value = row8["Paper"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@HoP", SqlDbType.VarChar, 5);
							sqlParameter3.Value = row8["HoP"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@BOT", SqlDbType.VarChar, 5);
							sqlParameter3.Value = row8["BOT"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@MOT", SqlDbType.VarChar, 5);
							sqlParameter3.Value = row8["MOT"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@EOT", SqlDbType.VarChar, 5);
							sqlParameter3.Value = row8["EOT"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							float result5 = (float.TryParse(row8["AvMark"].ToString(), out result5) ? result5 : 0f);
							if (string.IsNullOrEmpty(row8["AvMark"].ToString()))
							{
								sqlParameter3 = sqlCommand20.Parameters.Add("@AvMark", SqlDbType.Float);
								sqlParameter3.Value = DBNull.Value;
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand20.Parameters.Add("@CategoryPoints", SqlDbType.VarChar, 1);
								sqlParameter3.Value = DBNull.Value;
								sqlParameter3.Direction = ParameterDirection.Input;
							}
							else
							{
								sqlParameter3 = sqlCommand20.Parameters.Add("@AvMark", SqlDbType.Float);
								sqlParameter3.Value = result5;
								sqlParameter3.Direction = ParameterDirection.Input;
								sqlParameter3 = sqlCommand20.Parameters.Add("@CategoryPoints", SqlDbType.VarChar, 1);
								sqlParameter3.Value = row8["GradeScore"].ToString();
								sqlParameter3.Direction = ParameterDirection.Input;
							}
							sqlParameter3 = sqlCommand20.Parameters.Add("@Category", SqlDbType.VarChar, 3);
							sqlParameter3.Value = row8["Category"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@Grade", SqlDbType.VarChar, 3);
							sqlParameter3.Value = string.Empty;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@Comment", SqlDbType.VarChar, 80);
							sqlParameter3.Value = string.Empty;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@Initial", SqlDbType.VarChar, 5);
							sqlParameter3.Value = row8["Initial"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							int result6 = (int.TryParse(row8["Points"].ToString(), out result6) ? result6 : 0);
							sqlParameter3 = sqlCommand20.Parameters.Add("@Points", SqlDbType.Float);
							sqlParameter3.Value = result6;
							sqlParameter3.Direction = ParameterDirection.Input;
							float result7 = (float.TryParse(row8["AverageMark"].ToString(), out result7) ? result7 : 0f);
							sqlParameter3 = sqlCommand20.Parameters.Add("@AverageMark", SqlDbType.Float);
							sqlParameter3.Value = result7;
							sqlParameter3.Direction = ParameterDirection.Input;
							int result8 = (int.TryParse(row8["TotalPoints"].ToString(), out result8) ? result8 : 0);
							sqlParameter3 = sqlCommand20.Parameters.Add("@TotalPoints", SqlDbType.Float);
							sqlParameter3.Value = result8;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand20.Parameters.Add("@SubGroup", SqlDbType.VarChar, 7);
							sqlParameter3.Value = row8["SubCategory"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand20.ExecuteNonQuery();
							sqlConnection10.Close();
						}
						else if (!sqlDataReader.HasRows)
						{
							sqlConnection9.Close();
							using SqlConnection sqlConnection11 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection11.Open();
							using SqlCommand sqlCommand21 = new SqlCommand
							{
								Connection = sqlConnection11,
								CommandText = commandText,
								CommandType = CommandType.Text
							};
							SqlParameter sqlParameter4 = sqlCommand21.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter4.Value = row8["StudentNumber"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter4.Value = row8["SemesterId"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter4.Value = row8["SubjectId"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter4.Value = _Class;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@Paper", SqlDbType.VarChar, 15);
							sqlParameter4.Value = row8["Paper"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@HoP", SqlDbType.VarChar, 5);
							sqlParameter4.Value = row8["HoP"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@BOT", SqlDbType.VarChar, 5);
							sqlParameter4.Value = row8["BOT"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@MOT", SqlDbType.VarChar, 5);
							sqlParameter4.Value = row8["MOT"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@EOT", SqlDbType.VarChar, 5);
							sqlParameter4.Value = row8["EOT"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							float result9 = (float.TryParse(row8["AvMark"].ToString(), out result9) ? result9 : 0f);
							if (string.IsNullOrEmpty(row8["AvMark"].ToString()))
							{
								sqlParameter4 = sqlCommand21.Parameters.Add("@AvMark", SqlDbType.Float);
								sqlParameter4.Value = DBNull.Value;
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand21.Parameters.Add("@CategoryPoints", SqlDbType.VarChar, 1);
								sqlParameter4.Value = DBNull.Value;
								sqlParameter4.Direction = ParameterDirection.Input;
							}
							else
							{
								sqlParameter4 = sqlCommand21.Parameters.Add("@AvMark", SqlDbType.Float);
								sqlParameter4.Value = result9;
								sqlParameter4.Direction = ParameterDirection.Input;
								sqlParameter4 = sqlCommand21.Parameters.Add("@CategoryPoints", SqlDbType.VarChar, 1);
								sqlParameter4.Value = row8["GradeScore"].ToString();
								sqlParameter4.Direction = ParameterDirection.Input;
							}
							sqlParameter4 = sqlCommand21.Parameters.Add("@Category", SqlDbType.VarChar, 3);
							sqlParameter4.Value = row8["Category"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@Grade", SqlDbType.VarChar, 3);
							sqlParameter4.Value = row8["Grade"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@Comment", SqlDbType.VarChar, 80);
							sqlParameter4.Value = row8["Comment"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@Initial", SqlDbType.VarChar, 5);
							sqlParameter4.Value = row8["Initial"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							float result10 = (float.TryParse(row8["Points"].ToString(), out result10) ? result10 : 0f);
							sqlParameter4 = sqlCommand21.Parameters.Add("@Points", SqlDbType.Float);
							sqlParameter4.Value = result10;
							sqlParameter4.Direction = ParameterDirection.Input;
							float result11 = (float.TryParse(row8["AverageMark"].ToString(), out result11) ? result11 : 0f);
							sqlParameter4 = sqlCommand21.Parameters.Add("@AverageMark", SqlDbType.Float);
							sqlParameter4.Value = result11;
							sqlParameter4.Direction = ParameterDirection.Input;
							float result12 = (float.TryParse(row8["TotalPoints"].ToString(), out result12) ? result12 : 0f);
							sqlParameter4 = sqlCommand21.Parameters.Add("@TotalPoints", SqlDbType.Float);
							sqlParameter4.Value = result12;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand21.Parameters.Add("@SubGroup", SqlDbType.VarChar, 7);
							sqlParameter4.Value = row8["SubCategory"].ToString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlCommand21.ExecuteNonQuery();
							sqlConnection11.Close();
						}
					}
					k++;
					Thread.Sleep(25);
					bgProcessALevel.ReportProgress(k);
				}
				dataSet9.Clear();
				dataSet9.Dispose();
			}
			sqlDataAdapter9.Dispose();
		}
		k = 0;
		maximum = AComments.Rows.Count;
		currentTask = "Task 7/7: Adding automated comments on report card...";
		foreach (DataRow row9 in AComments.Rows)
		{
			Random random = new Random();
			int num5 = (int)(random.NextDouble() * 5.0 + 1.0);
			using (SqlConnection sqlConnection12 = new SqlConnection(connectionString))
			{
				sqlConnection12.Open();
				string commandText3 = string.Format("UPDATE tbl_ALevelReport SET HeadTeacherComments=@HeadTeacherComments,ClassTeacherComments=@ClassTeacherComments WHERE SemesterId=@SemesterId AND (TotalPoints>={0} AND TotalPoints <= {1}) AND ClassId=@ClassId", Convert.ToDouble(row9["Debut"]), Convert.ToDouble(row9["EndMark"]));
				using SqlCommand sqlCommand22 = new SqlCommand
				{
					Connection = sqlConnection12,
					CommandText = commandText3,
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter5;
				switch (num5)
				{
				case 1:
					sqlParameter5 = sqlCommand22.Parameters.Add("@HeadTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["HeadTeacherComment1"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand22.Parameters.Add("@ClassTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["ClassTeacherComments1"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					break;
				case 2:
					sqlParameter5 = sqlCommand22.Parameters.Add("@HeadTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["HeadTeacherComment2"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand22.Parameters.Add("@ClassTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["ClassTeacherComments2"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					break;
				case 3:
					sqlParameter5 = sqlCommand22.Parameters.Add("@HeadTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["HeadTeacherComment3"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand22.Parameters.Add("@ClassTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["ClassTeacherComments3"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					break;
				case 4:
					sqlParameter5 = sqlCommand22.Parameters.Add("@HeadTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["HeadTeacherComment4"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand22.Parameters.Add("@ClassTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["ClassTeacherComments4"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					break;
				case 5:
					sqlParameter5 = sqlCommand22.Parameters.Add("@HeadTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["HeadTeacherComment5"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand22.Parameters.Add("@ClassTeacherComments", SqlDbType.VarChar, 80);
					sqlParameter5.Value = row9["ClassTeacherComments5"].ToString();
					sqlParameter5.Direction = ParameterDirection.Input;
					break;
				}
				sqlParameter5 = sqlCommand22.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
				sqlParameter5.Value = _Semester;
				sqlParameter5.Direction = ParameterDirection.Input;
				sqlParameter5 = sqlCommand22.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter5.Value = _Class;
				sqlParameter5.Direction = ParameterDirection.Input;
				sqlCommand22.ExecuteNonQuery();
			}
			k++;
			Thread.Sleep(10);
			bgProcessALevel.ReportProgress(k);
		}
		using (SqlConnection sqlConnection13 = new SqlConnection(connectionString))
		{
			sqlConnection13.Open();
			using SqlCommand sqlCommand23 = new SqlCommand
			{
				Connection = sqlConnection13,
				CommandText = "UPDATE tbl_ALevelReport SET CategoryPoints='-' WHERE ((HoP='-' AND BOT='-' AND MOT='-' AND EOT='-') OR (HoP='' AND BOT='' AND MOT='' AND EOT='')) AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter6 = sqlCommand23.Parameters.Add("SemesterId", SqlDbType.VarChar, 12);
			sqlParameter6.Value = _Semester;
			sqlParameter6.Direction = ParameterDirection.Input;
			sqlParameter6 = sqlCommand23.Parameters.Add("ClassId", SqlDbType.VarChar, 8);
			sqlParameter6.Value = _Class;
			sqlParameter6.Direction = ParameterDirection.Input;
			sqlCommand23.ExecuteNonQuery();
		}
		if (_Semester.Contains("TermIII") && _Class == "S.5")
		{
			string nextClassAfterThis = Classes.GetNextClassAfterThis(_Class);
			PromoteA($"UPDATE tbl_ALevelReport Set promoStatus='PROMOTED TO {nextClassAfterThis}' WHERE SemesterId='{_Semester}' AND TotalPoints > {ALevelAutoCutOff.ProbationEnd}");
			PromoteA($"UPDATE tbl_ALevelReport Set promoStatus='PROMOTED TO {nextClassAfterThis} ON PROBATION' WHERE SemesterId='{_Semester}' AND (TotalPoints > {ALevelAutoCutOff.Repeat} AND TotalPoints <={ALevelAutoCutOff.ProbationEnd})");
			PromoteA($"UPDATE tbl_ALevelReport Set promoStatus='DOES NOT QUALIFY FOR {nextClassAfterThis}' WHERE SemesterId='{_Semester}' AND TotalPoints <= {ALevelAutoCutOff.Repeat}");
		}
	}

	private static void PromoteA(string cmdText)
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

	private void bgProcessALevel_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
		this.components = new System.ComponentModel.Container();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.bgProcessALevel = new System.ComponentModel.BackgroundWorker();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.bgProcessALevel.WorkerReportsProgress = true;
		this.bgProcessALevel.WorkerSupportsCancellation = true;
		this.bgProcessALevel.DoWork += new System.ComponentModel.DoWorkEventHandler(bgProcessALevel_DoWork);
		this.bgProcessALevel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgProcessALevel_ProgressChanged);
		this.bgProcessALevel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgProcessALevel_RunWorkerCompleted);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(404, 37);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(404, 37);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "ProcessProgressALevel";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Processing reports, please wait...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ProcessProgressALevel_FormClosing);
		base.Load += new System.EventHandler(ProcessALevel_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(ProcessProgressALevel_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
