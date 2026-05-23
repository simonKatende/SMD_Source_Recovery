using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

public class RegisterStudents : XtraForm
{
	private int i;

	private int k = 0;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private string connectionString = DataConnection.ConnectToDatabase();

	private string currentStudent = StudentRegistration.CurrentStudent();

	private string classForProcessing = StudentRegistration.CurrentClass();

	private string scoresTable = SchoolSettings.ScoresTableSource(StudentRegistration.CurrentClass());

	private string generalReport = SchoolSettings.GeneralReportTableSource(StudentRegistration.CurrentClass());

	private string generalReportGrading = SchoolSettings.GeneralReportGradingTableSource(StudentRegistration.CurrentClass());

	private static SqlTransaction _trans;

	private static SqlTransaction _transaction;

	private static DataSet dataSet;

	private static DataSet dataSet_A;

	private GridView gridView = StudentRegistration.gridView;

	private string ClassGroup = string.Empty;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker bgRegisterStudents;

	private ProgressBarControl progressBarControl1;

	public RegisterStudents(string _ClassGroup)
	{
		InitializeComponent();
		ClassGroup = _ClassGroup;
	}

	private void RegisterStudents_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			timer1.Enabled = false;
			bgRegisterStudents.RunWorkerAsync();
		}
	}

	private void bgRegisterStudents_DoWork(object sender, DoWorkEventArgs e)
	{
		if (StudentRegistration.ModeOfRegistration == 0 && StudentRegistration.LevelForRegistration == 0)
		{
			if (ClassGroup == "Nursery")
			{
				RegisterAllPreprimary();
			}
			else if (ClassGroup == "Primary" || ClassGroup == "OLevel")
			{
				RegisterAllOLevel();
			}
		}
		else if (StudentRegistration.ModeOfRegistration == 0 && StudentRegistration.LevelForRegistration == 1)
		{
			RegisterAllALevel();
		}
		else if (StudentRegistration.ModeOfRegistration == 1 && StudentRegistration.LevelForRegistration == 0)
		{
			if (ClassGroup == "Nursery")
			{
				RegisterSinglePrePrimary();
			}
			else if (ClassGroup == "Primary" || ClassGroup == "OLevel")
			{
				RegisterSingleOLevel();
			}
		}
		else if (StudentRegistration.ModeOfRegistration == 1 && StudentRegistration.LevelForRegistration == 1)
		{
			RegisterSingleALevel();
		}
	}

	private void bgRegisterStudents_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Dispose();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void RegisterStudents_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bgRegisterStudents.IsBusy)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to cancel the current process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				bgRegisterStudents.CancelAsync();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
		}
	}

	private string FirstWords(string input, int numberWords)
	{
		try
		{
			int num = numberWords;
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == ' ')
				{
					num--;
				}
				if (num == 0)
				{
					return input.Substring(0, i);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return string.Empty;
	}

	private void RegisterAllALevel()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			maximum = StudentRegistration.gridView.RowCount;
			string text = StudentRegistration.CurrentAcademicYear.ToString();
			for (int i = 0; i < StudentRegistration.gridView.RowCount; i++)
			{
				string text2 = StudentRegistration.gridView.GetRowCellValue(i, "PaperId").ToString();
				string text3 = StudentRegistration.gridView.GetRowCellValue(i, "Paper").ToString();
				string value = StudentRegistration.gridView.GetRowCellValue(i, "SubjectId").ToString();
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					string selectCommandText = $"SELECT * FROM tbl_Stud WHERE ClassId='{classForProcessing}'";
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
					dataSet_A = new DataSet();
					sqlDataAdapter.Fill(dataSet_A, "students");
					DataTable dataTable = dataSet_A.Tables[0];
					foreach (DataRow row in dataTable.Rows)
					{
						string[] array = "TermI- TermII- TermIII-".Split();
						foreach (string text4 in array)
						{
							using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
							sqlConnection2.Open();
							using SqlCommand sqlCommand = new SqlCommand
							{
								CommandText = $"SELECT * FROM {generalReport} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId AND ClassId=@ClassId ",
								Connection = sqlConnection2,
								CommandType = CommandType.Text
							};
							sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
							sqlCommand.Parameters.AddWithValue("@SemesterId", text4 + text);
							sqlCommand.Parameters.AddWithValue("@PaperId", text2.ToString());
							sqlCommand.Parameters.AddWithValue("@ClassId", classForProcessing);
							SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
							if (sqlDataReader.HasRows)
							{
								continue;
							}
							sqlConnection2.Close();
							using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
							sqlConnection3.Open();
							_trans = sqlConnection3.BeginTransaction();
							using (SqlCommand sqlCommand2 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = _trans,
								CommandText = $"INSERT INTO {scoresTable} (StudentNumber,SemesterId,SubjectId,PaperId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@ClassId)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
								sqlParameter.Value = row["StudentNumber"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
								sqlParameter.Value = text4 + text;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
								sqlParameter.Value = text2;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
								sqlParameter.Value = value;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
								sqlParameter.Value = classForProcessing;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlCommand2.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = _trans,
								CommandText = $"INSERT INTO {generalReport} (StudentNumber,SubjectId,PaperId,SemesterId,ClassId) VALUES (@StudentNumber,@SubjectId,@PaperId,@SemesterId,@ClassId)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
								sqlParameter2.Value = row["StudentNumber"].ToString();
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
								sqlParameter2.Value = text4 + text;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
								sqlParameter2.Value = value;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
								sqlParameter2.Value = text2;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
								sqlParameter2.Value = classForProcessing;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlCommand3.ExecuteNonQuery();
							}
							_trans.Commit();
							sqlConnection3.Close();
						}
					}
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
			this.k = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = StudentRegistration.gridView.RowCount;
			for (int k = 0; k < StudentRegistration.gridView.RowCount; k++)
			{
				string value2 = StudentRegistration.gridView.GetRowCellValue(k, "SubjectId").ToString();
				using (SqlConnection sqlConnection4 = new SqlConnection(connectionString))
				{
					sqlConnection4.Open();
					string selectCommandText2 = $"SELECT * FROM tbl_Stud WHERE ClassId='{classForProcessing}'";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection4);
					dataSet_A = new DataSet();
					sqlDataAdapter2.Fill(dataSet_A, "students");
					DataTable dataTable2 = dataSet_A.Tables[0];
					foreach (DataRow row2 in dataTable2.Rows)
					{
						string[] array2 = "TermI- TermII- TermIII-".Split();
						foreach (string text5 in array2)
						{
							using SqlConnection sqlConnection5 = new SqlConnection(connectionString);
							sqlConnection5.Open();
							using SqlCommand sqlCommand4 = new SqlCommand
							{
								CommandText = $"SELECT * FROM {generalReportGrading} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId ",
								Connection = sqlConnection5,
								CommandType = CommandType.Text
							};
							sqlCommand4.Parameters.AddWithValue("@StudentNumber", row2["StudentNumber"].ToString());
							sqlCommand4.Parameters.AddWithValue("@SemesterId", text5 + text);
							sqlCommand4.Parameters.AddWithValue("@SubjectId", value2);
							sqlCommand4.Parameters.AddWithValue("@ClassId", classForProcessing);
							SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
							if (sqlDataReader2.HasRows)
							{
								continue;
							}
							sqlConnection5.Close();
							using SqlConnection sqlConnection6 = new SqlConnection(connectionString);
							sqlConnection6.Open();
							using SqlCommand sqlCommand5 = new SqlCommand
							{
								Connection = sqlConnection6,
								CommandText = $"INSERT INTO {generalReportGrading} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)",
								CommandType = CommandType.Text
							};
							SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = row2["StudentNumber"].ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter3.Value = text5 + text;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter3.Value = value2;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter3.Value = classForProcessing;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
					}
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void RegisterSingleALevel()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string text = StudentRegistration.CurrentAcademicYear.ToString();
			string text2 = currentStudent;
			maximum = StudentRegistration.gridView.RowCount;
			for (int i = 0; i < StudentRegistration.gridView.RowCount; i++)
			{
				string text3 = StudentRegistration.gridView.GetRowCellValue(i, "PaperId").ToString();
				string text4 = StudentRegistration.gridView.GetRowCellValue(i, "Paper").ToString();
				string value = StudentRegistration.gridView.GetRowCellValue(i, "SubjectId").ToString();
				string[] array = "TermI- TermII- TermIII-".Split();
				foreach (string text5 in array)
				{
					using SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						CommandText = $"SELECT * FROM {generalReport} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId AND ClassId=@ClassId",
						Connection = sqlConnection,
						CommandType = CommandType.Text
					};
					sqlCommand.Parameters.AddWithValue("@StudentNumber", currentStudent);
					sqlCommand.Parameters.AddWithValue("@SemesterId", text5 + text);
					sqlCommand.Parameters.AddWithValue("@PaperId", text3.ToString());
					sqlCommand.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						continue;
					}
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
					sqlConnection2.Open();
					_trans = sqlConnection2.BeginTransaction();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = _trans,
						CommandText = $"INSERT INTO {scoresTable} (StudentNumber,SemesterId,SubjectId,PaperId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = currentStudent;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter.Value = text5 + text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
						sqlParameter.Value = text3.ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = value;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter.Value = classForProcessing;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = _trans,
						CommandText = $"INSERT INTO {generalReport} (StudentNumber,SubjectId,PaperId,SemesterId,ClassId) VALUES (@StudentNumber,@SubjectId,@PaperId,@SemesterId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = currentStudent;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter2.Value = text5 + text;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = value;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = text3;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter2.Value = classForProcessing;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					_trans.Commit();
					sqlConnection2.Close();
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
			this.k = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = StudentRegistration.gridView.RowCount;
			for (int k = 0; k < StudentRegistration.gridView.RowCount; k++)
			{
				string value2 = StudentRegistration.gridView.GetRowCellValue(k, "SubjectId").ToString();
				string[] array2 = "TermI- TermII- TermIII-".Split();
				foreach (string text6 in array2)
				{
					using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
					sqlConnection3.Open();
					using SqlCommand sqlCommand4 = new SqlCommand
					{
						CommandText = $"SELECT * FROM {generalReportGrading} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
						Connection = sqlConnection3,
						CommandType = CommandType.Text
					};
					sqlCommand4.Parameters.AddWithValue("@StudentNumber", currentStudent);
					sqlCommand4.Parameters.AddWithValue("@SemesterId", text6 + text);
					sqlCommand4.Parameters.AddWithValue("@SubjectId", value2);
					sqlCommand4.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
					if (sqlDataReader2.HasRows)
					{
						continue;
					}
					sqlConnection3.Close();
					using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
					sqlConnection4.Open();
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Connection = sqlConnection4,
						CommandText = $"INSERT INTO {generalReportGrading} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter3.Value = currentStudent;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter3.Value = text6 + text;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter3.Value = value2;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter3.Value = classForProcessing;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlCommand5.ExecuteNonQuery();
					}
					sqlConnection4.Close();
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void RegisterAllOLevel()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string text = StudentRegistration.CurrentAcademicYear.ToString();
			maximum = StudentRegistration.gridView.RowCount;
			for (int i = 0; i < StudentRegistration.gridView.RowCount; i++)
			{
				string value = StudentRegistration.gridView.GetRowCellValue(i, "Subject").ToString();
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					string selectCommandText = $"SELECT * FROM tbl_Stud WHERE ClassId='{classForProcessing}'";
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
					dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "students");
					DataTable dataTable = dataSet.Tables[0];
					foreach (DataRow row in dataTable.Rows)
					{
						string[] array = "TermI- TermII- TermIII-".Split();
						foreach (string text2 in array)
						{
							using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
							sqlConnection2.Open();
							using SqlCommand sqlCommand = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = $"SELECT * FROM {generalReport} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
								CommandType = CommandType.Text
							};
							sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
							sqlCommand.Parameters.AddWithValue("@SemesterId", text2 + text);
							sqlCommand.Parameters.AddWithValue("@SubjectId", value);
							sqlCommand.Parameters.AddWithValue("@ClassId", classForProcessing);
							SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
							if (sqlDataReader.HasRows)
							{
								continue;
							}
							sqlConnection2.Close();
							DateTime now = DateTime.Now;
							using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
							sqlConnection3.Open();
							_transaction = sqlConnection3.BeginTransaction();
							using (SqlCommand sqlCommand2 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = _transaction,
								CommandText = $"INSERT INTO {scoresTable} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
								sqlParameter.Value = row["StudentNumber"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
								sqlParameter.Value = text2 + text;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
								sqlParameter.Value = value;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
								sqlParameter.Value = classForProcessing;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlCommand2.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = _transaction,
								CommandText = $"INSERT INTO {generalReport} (StudentNumber,SubjectId,SemesterId,ClassId) VALUES (@StudentNumber,@SubjectId,@SemesterId,@ClassId)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
								sqlParameter2.Value = row["StudentNumber"].ToString();
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
								sqlParameter2.Value = text2 + text;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
								sqlParameter2.Value = value;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
								sqlParameter2.Value = classForProcessing;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlCommand3.ExecuteNonQuery();
							}
							_transaction.Commit();
							sqlConnection3.Close();
						}
					}
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
			using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
			sqlConnection4.Open();
			string selectCommandText2 = $"SELECT * FROM {generalReport} WHERE ClassId='{classForProcessing}'";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection4);
			dataSet = new DataSet();
			sqlDataAdapter2.Fill(dataSet, "students");
			DataTable dataTable2 = dataSet.Tables[0];
			this.k = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = dataTable2.Rows.Count;
			foreach (DataRow row2 in dataTable2.Rows)
			{
				string[] array2 = "TermI- TermII- TermIII-".Split();
				foreach (string text3 in array2)
				{
					using SqlConnection sqlConnection5 = new SqlConnection(connectionString);
					sqlConnection5.Open();
					using SqlCommand sqlCommand4 = new SqlCommand
					{
						Connection = sqlConnection5,
						CommandText = $"SELECT * FROM {generalReportGrading} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
						CommandType = CommandType.Text
					};
					sqlCommand4.Parameters.AddWithValue("@StudentNumber", row2["StudentNumber"].ToString());
					sqlCommand4.Parameters.AddWithValue("@SemesterId", text3 + text);
					sqlCommand4.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
					if (sqlDataReader2.HasRows)
					{
						continue;
					}
					sqlConnection5.Close();
					using SqlConnection sqlConnection6 = new SqlConnection(connectionString);
					sqlConnection6.Open();
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Connection = sqlConnection6,
						CommandText = $"INSERT INTO {generalReportGrading} (StudentNumber,SemesterId,ClassId) VALUES (@StudentNumber,@SemesterId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter3.Value = row2["StudentNumber"];
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter3.Value = text3 + text;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter3.Value = classForProcessing;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlCommand5.ExecuteNonQuery();
					}
					sqlConnection6.Close();
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void RegisterSingleOLevel()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string text = StudentRegistration.CurrentAcademicYear.ToString();
			string value = currentStudent;
			maximum = StudentRegistration.gridView.RowCount;
			for (int i = 0; i < StudentRegistration.gridView.RowCount; i++)
			{
				string value2 = StudentRegistration.gridView.GetRowCellValue(i, "Subject").ToString();
				string[] array = "TermI- TermII- TermIII-".Split();
				foreach (string text2 in array)
				{
					using SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						CommandText = $"SELECT * FROM {generalReport} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
						Connection = sqlConnection,
						CommandType = CommandType.Text
					};
					sqlCommand.Parameters.AddWithValue("@StudentNumber", value);
					sqlCommand.Parameters.AddWithValue("@SemesterId", text2 + text);
					sqlCommand.Parameters.AddWithValue("@SubjectId", value2);
					sqlCommand.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						continue;
					}
					string[] array2 = "TermI- TermII- TermIII-".Split();
					int num = 0;
					if (num >= array2.Length)
					{
						continue;
					}
					string text3 = array2[num];
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
					sqlConnection2.Open();
					_transaction = sqlConnection2.BeginTransaction();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = _transaction,
						CommandText = $"INSERT INTO {scoresTable} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = currentStudent;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter.Value = text2 + text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = value2;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter.Value = classForProcessing;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = _transaction,
						CommandText = $"INSERT INTO {generalReport} (StudentNumber,SubjectId,SemesterId,ClassId) VALUES (@StudentNumber,@SubjectId,@SemesterId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = currentStudent;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter2.Value = text2 + text;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = value2;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter2.Value = classForProcessing;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					_transaction.Commit();
					sqlConnection2.Close();
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
			this.k = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = 3;
			string[] array3 = "TermI- TermII- TermIII-".Split();
			foreach (string text4 in array3)
			{
				using (SqlConnection sqlConnection3 = new SqlConnection(connectionString))
				{
					sqlConnection3.Open();
					using SqlCommand sqlCommand4 = new SqlCommand
					{
						CommandText = $"SELECT * FROM {generalReportGrading} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
						Connection = sqlConnection3,
						CommandType = CommandType.Text
					};
					sqlCommand4.Parameters.AddWithValue("@StudentNumber", currentStudent);
					sqlCommand4.Parameters.AddWithValue("@SemesterId", text4 + text);
					sqlCommand4.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
					if (!sqlDataReader2.HasRows)
					{
						sqlConnection3.Close();
						using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
						sqlConnection4.Open();
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Connection = sqlConnection4,
							CommandText = $"INSERT INTO {generalReportGrading} (StudentNumber,SemesterId,ClassId) VALUES (@StudentNumber,@SemesterId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = currentStudent;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter3.Value = text4 + text;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter3.Value = classForProcessing;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
						sqlConnection4.Close();
					}
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void RegisterAllPreprimary()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string text = StudentRegistration.CurrentAcademicYear.ToString();
			maximum = StudentRegistration.gridView.RowCount;
			for (int i = 0; i < StudentRegistration.gridView.RowCount; i++)
			{
				string value = StudentRegistration.gridView.GetRowCellValue(i, "Subject").ToString();
				string value2 = StudentRegistration.gridView.GetRowCellValue(i, "SubGroup").ToString();
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					string selectCommandText = $"SELECT * FROM tbl_Stud WHERE ClassId='{classForProcessing}'";
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
					dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "students");
					DataTable dataTable = dataSet.Tables[0];
					foreach (DataRow row in dataTable.Rows)
					{
						string[] array = "TermI- TermII- TermIII-".Split();
						foreach (string text2 in array)
						{
							using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
							sqlConnection2.Open();
							using SqlCommand sqlCommand = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = "SELECT * FROM tbl_Scores_PrePrimary WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
								CommandType = CommandType.Text
							};
							sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
							sqlCommand.Parameters.AddWithValue("@SemesterId", text2 + text);
							sqlCommand.Parameters.AddWithValue("@SubjectId", value);
							sqlCommand.Parameters.AddWithValue("@ClassId", classForProcessing);
							SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
							if (sqlDataReader.HasRows)
							{
								continue;
							}
							sqlConnection2.Close();
							DateTime now = DateTime.Now;
							using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
							sqlConnection3.Open();
							using (SqlCommand sqlCommand2 = new SqlCommand
							{
								Connection = sqlConnection3,
								CommandText = string.Format("INSERT INTO tbl_Scores_PrePrimary (StudentNumber,SemesterId,LearningArea,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@LearningArea,@SubjectId,@ClassId)", scoresTable),
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
								sqlParameter.Value = row["StudentNumber"].ToString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
								sqlParameter.Value = text2 + text;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@LearningArea", SqlDbType.VarChar, 50);
								sqlParameter.Value = value2;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
								sqlParameter.Value = value;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
								sqlParameter.Value = classForProcessing;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlCommand2.ExecuteNonQuery();
							}
							sqlConnection3.Close();
						}
					}
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
			using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
			sqlConnection4.Open();
			string selectCommandText2 = $"SELECT * FROM tbl_Scores_PrePrimary WHERE ClassId='{classForProcessing}'";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, sqlConnection4);
			dataSet = new DataSet();
			sqlDataAdapter2.Fill(dataSet, "students");
			DataTable dataTable2 = dataSet.Tables[0];
			this.k = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = dataTable2.Rows.Count;
			foreach (DataRow row2 in dataTable2.Rows)
			{
				string[] array2 = "TermI- TermII- TermIII-".Split();
				foreach (string text3 in array2)
				{
					using SqlConnection sqlConnection5 = new SqlConnection(connectionString);
					sqlConnection5.Open();
					using SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection5,
						CommandText = "SELECT * FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
						CommandType = CommandType.Text
					};
					sqlCommand3.Parameters.AddWithValue("@StudentNumber", row2["StudentNumber"].ToString());
					sqlCommand3.Parameters.AddWithValue("@SemesterId", text3 + text);
					sqlCommand3.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
					if (sqlDataReader2.HasRows)
					{
						continue;
					}
					sqlConnection5.Close();
					using SqlConnection sqlConnection6 = new SqlConnection(connectionString);
					sqlConnection6.Open();
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Connection = sqlConnection6,
						CommandText = "INSERT INTO tbl_GeneralReports_Grading_PrePrimary (StudentNumber,SemesterId,ClassId) VALUES (@StudentNumber,@SemesterId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = row2["StudentNumber"];
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter2.Value = text3 + text;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand4.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter2.Value = classForProcessing;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand4.ExecuteNonQuery();
					}
					sqlConnection6.Close();
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void RegisterSinglePrePrimary()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string text = StudentRegistration.CurrentAcademicYear.ToString();
			string value = currentStudent;
			maximum = StudentRegistration.gridView.RowCount;
			for (int i = 0; i < StudentRegistration.gridView.RowCount; i++)
			{
				string value2 = StudentRegistration.gridView.GetRowCellValue(i, "Subject").ToString();
				string value3 = StudentRegistration.gridView.GetRowCellValue(i, "SubGroup").ToString();
				string[] array = "TermI- TermII- TermIII-".Split();
				foreach (string text2 in array)
				{
					using SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						CommandText = "SELECT * FROM tbl_Scores_PrePrimary WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
						Connection = sqlConnection,
						CommandType = CommandType.Text
					};
					sqlCommand.Parameters.AddWithValue("@StudentNumber", value);
					sqlCommand.Parameters.AddWithValue("@SemesterId", text2 + text);
					sqlCommand.Parameters.AddWithValue("@SubjectId", value2);
					sqlCommand.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						continue;
					}
					string[] array2 = "TermI- TermII- TermIII-".Split();
					int num = 0;
					if (num >= array2.Length)
					{
						continue;
					}
					string text3 = array2[num];
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
					sqlConnection2.Open();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_Scores_PrePrimary (StudentNumber,SemesterId,LearningArea,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@LearningArea,@SubjectId,@ClassId)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = currentStudent;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
						sqlParameter.Value = text2 + text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@LearningArea", SqlDbType.VarChar, 50);
						sqlParameter.Value = value3;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = value2;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
						sqlParameter.Value = classForProcessing;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					sqlConnection2.Close();
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
			this.k = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = 3;
			string[] array3 = "TermI- TermII- TermIII-".Split();
			foreach (string text4 in array3)
			{
				using (SqlConnection sqlConnection3 = new SqlConnection(connectionString))
				{
					sqlConnection3.Open();
					using SqlCommand sqlCommand3 = new SqlCommand
					{
						CommandText = "SELECT * FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
						Connection = sqlConnection3,
						CommandType = CommandType.Text
					};
					sqlCommand3.Parameters.AddWithValue("@StudentNumber", currentStudent);
					sqlCommand3.Parameters.AddWithValue("@SemesterId", text4 + text);
					sqlCommand3.Parameters.AddWithValue("@ClassId", classForProcessing);
					SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
					if (!sqlDataReader2.HasRows)
					{
						sqlConnection3.Close();
						using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
						sqlConnection4.Open();
						using (SqlCommand sqlCommand4 = new SqlCommand
						{
							Connection = sqlConnection4,
							CommandText = "INSERT INTO tbl_GeneralReports_Grading_PrePrimary (StudentNumber,SemesterId,ClassId) VALUES (@StudentNumber,@SemesterId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter2.Value = currentStudent;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter2.Value = text4 + text;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter2.Value = classForProcessing;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						sqlConnection4.Close();
					}
				}
				this.k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(this.k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void bgRegisterStudents_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum;
		Text = currentTask;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void RegisterStudents_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		this.bgRegisterStudents = new System.ComponentModel.BackgroundWorker();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.bgRegisterStudents.WorkerReportsProgress = true;
		this.bgRegisterStudents.WorkerSupportsCancellation = true;
		this.bgRegisterStudents.DoWork += new System.ComponentModel.DoWorkEventHandler(bgRegisterStudents_DoWork);
		this.bgRegisterStudents.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgRegisterStudents_ProgressChanged);
		this.bgRegisterStudents.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgRegisterStudents_RunWorkerCompleted);
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
		base.Name = "RegisterStudents";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Registering students...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RegisterStudents_FormClosing);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(RegisterStudents_FormClosed);
		base.Load += new System.EventHandler(RegisterStudents_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
