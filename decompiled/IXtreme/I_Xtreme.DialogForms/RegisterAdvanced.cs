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

namespace I_Xtreme.DialogForms;

public class RegisterAdvanced : XtraForm
{
	private int i;

	private int t = 0;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private SqlTransaction transaction;

	private SqlTransaction _transaction;

	private string scoresTable = string.Empty;

	private string generalReport = string.Empty;

	private string generalReportGrading = string.Empty;

	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private IContainer components = null;

	private BackgroundWorker bgRegisterStudents;

	private System.Windows.Forms.Timer timer1;

	public LabelControl lblClass;

	public LabelControl lblAcademicYear;

	private ProgressBarControl progressBarControl1;

	public RegisterAdvanced()
	{
		InitializeComponent();
	}

	private void RegisterAdvanced_Load(object sender, EventArgs e)
	{
		scoresTable = SchoolSettings.ScoresTableSource(lblClass.Text);
		generalReport = SchoolSettings.GeneralReportTableSource(lblClass.Text);
		generalReportGrading = SchoolSettings.GeneralReportGradingTableSource(lblClass.Text);
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
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString() || (schoolType == SchoolSettings.SchoolType.Secondary.ToString() && SchoolSettings.ClassLevel(lblClass.Text) == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
		{
			RegisterOLevel(Convert.ToInt32(lblAcademicYear.Text), lblClass.Text);
		}
		else if (schoolType == SchoolSettings.SchoolType.Secondary.ToString() && SchoolSettings.ClassLevel(lblClass.Text) == SchoolSettings.SecondaryClassLevels.ALevel.ToString())
		{
			RegisterALevel(Convert.ToInt32(lblAcademicYear.Text), lblClass.Text);
		}
	}

	private void bgRegisterStudents_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Dispose();
		XtraMessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void RegisterAdvanced_FormClosing(object sender, FormClosingEventArgs e)
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

	private void RegisterALevel(int academicYear, string classRegisterFor)
	{
		try
		{
			t = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			maximum = StudentRegistrationAdvanced.Grid_View.RowCount;
			for (int i = 0; i < StudentRegistrationAdvanced.Grid_View.RowCount; i++)
			{
				for (int j = 3; j < StudentRegistrationAdvanced.Grid_View.Columns.Count; j++)
				{
					bool result = bool.TryParse(StudentRegistrationAdvanced.Grid_View.GetRowCellValue(i, StudentRegistrationAdvanced.Grid_View.Columns[j].FieldName).ToString(), out result) && result;
					if (!result)
					{
						continue;
					}
					string text = StudentRegistrationAdvanced.Grid_View.Columns[j].FieldName.ToString();
					string value = FirstWords(text);
					string value2 = StudentRegistrationAdvanced.Grid_View.GetRowCellValue(i, "StudentNo").ToString();
					string[] array = "TermI- TermII- TermIII-".Split();
					foreach (string text2 in array)
					{
						using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection.Open();
						using SqlCommand sqlCommand = new SqlCommand
						{
							CommandText = $"SELECT * FROM {generalReport} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId AND ClassId=@ClassId",
							Connection = sqlConnection,
							CommandType = CommandType.Text
						};
						sqlCommand.Parameters.AddWithValue("@StudentNumber", value2);
						sqlCommand.Parameters.AddWithValue("@SemesterId", text2 + academicYear);
						sqlCommand.Parameters.AddWithValue("@PaperId", text);
						sqlCommand.Parameters.AddWithValue("@ClassId", classRegisterFor);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							continue;
						}
						sqlConnection.Close();
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						transaction = sqlConnection2.BeginTransaction();
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = transaction,
							CommandText = $"INSERT INTO {scoresTable} (StudentNumber,SemesterId,SubjectId,PaperId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter.Value = StudentRegistrationAdvanced.Grid_View.GetRowCellValue(i, "StudentNo").ToString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
							sqlParameter.Value = text2 + academicYear;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
							sqlParameter.Value = text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter.Value = value;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter.Value = classRegisterFor;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand2.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = transaction,
							CommandText = $"INSERT INTO {generalReport} (StudentNumber,SemesterId,SubjectId,PaperId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter2.Value = value2;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter2.Value = text2 + academicYear;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = value;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = text.ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter2.Value = classRegisterFor;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						transaction.Commit();
						sqlConnection2.Close();
					}
				}
				t++;
				Thread.Sleep(25);
				bgRegisterStudents.ReportProgress(t);
			}
			t = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = StudentRegistrationAdvanced.Grid_View.RowCount;
			for (int l = 0; l < StudentRegistrationAdvanced.Grid_View.RowCount; l++)
			{
				for (int m = 3; m < StudentRegistrationAdvanced.Grid_View.Columns.Count; m++)
				{
					bool result2 = bool.TryParse(StudentRegistrationAdvanced.Grid_View.GetRowCellValue(l, StudentRegistrationAdvanced.Grid_View.Columns[m].FieldName).ToString(), out result2) && result2;
					if (!result2)
					{
						continue;
					}
					string[] array2 = "TermI- TermII- TermIII-".Split();
					foreach (string text3 in array2)
					{
						string input = StudentRegistrationAdvanced.Grid_View.Columns[m].FieldName.ToString();
						string value3 = FirstWords(input);
						string value4 = StudentRegistrationAdvanced.Grid_View.GetRowCellValue(l, "StudentNo").ToString();
						using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection3.Open();
						using SqlCommand sqlCommand4 = new SqlCommand
						{
							CommandText = $"SELECT * FROM {generalReportGrading} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
							Connection = sqlConnection3,
							CommandType = CommandType.Text
						};
						sqlCommand4.Parameters.AddWithValue("@StudentNumber", value4);
						sqlCommand4.Parameters.AddWithValue("@SemesterId", text3 + academicYear);
						sqlCommand4.Parameters.AddWithValue("@SubjectId", value3);
						sqlCommand4.Parameters.AddWithValue("@ClassId", classRegisterFor);
						SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
						if (sqlDataReader2.HasRows)
						{
							continue;
						}
						sqlConnection3.Close();
						using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection4.Open();
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Connection = sqlConnection4,
							CommandText = $"INSERT INTO {generalReportGrading} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = value4;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter3.Value = text3 + academicYear;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter3.Value = value3;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter3.Value = classRegisterFor;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
						sqlConnection4.Close();
					}
				}
				t++;
				Thread.Sleep(25);
				bgRegisterStudents.ReportProgress(t);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void RegisterOLevel(int academicYear, string classRegisterFor)
	{
		try
		{
			t = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			maximum = StudentRegistrationAdvanced.Grid_View.RowCount;
			for (int i = 0; i < StudentRegistrationAdvanced.Grid_View.RowCount; i++)
			{
				for (int j = 3; j < StudentRegistrationAdvanced.Grid_View.Columns.Count; j++)
				{
					bool result = bool.TryParse(StudentRegistrationAdvanced.Grid_View.GetRowCellValue(i, StudentRegistrationAdvanced.Grid_View.Columns[j].FieldName).ToString(), out result) && result;
					if (!result)
					{
						continue;
					}
					string[] array = "TermI- TermII- TermIII-".Split();
					foreach (string text in array)
					{
						string value = StudentRegistrationAdvanced.Grid_View.Columns[j].FieldName.ToString();
						string value2 = StudentRegistrationAdvanced.Grid_View.GetRowCellValue(i, "StudentNo").ToString();
						using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection.Open();
						string commandText = $"SELECT * FROM {generalReport} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId";
						using SqlCommand sqlCommand = new SqlCommand
						{
							CommandText = commandText,
							Connection = sqlConnection,
							CommandType = CommandType.Text
						};
						sqlCommand.Parameters.AddWithValue("@StudentNumber", value2);
						sqlCommand.Parameters.AddWithValue("@SemesterId", text + academicYear);
						sqlCommand.Parameters.AddWithValue("@subjectId", value);
						sqlCommand.Parameters.AddWithValue("@ClassId", classRegisterFor);
						SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							continue;
						}
						sqlConnection.Close();
						string[] array2 = "TermI- TermII- TermIII-".Split();
						int num = 0;
						if (num >= array2.Length)
						{
							continue;
						}
						string text2 = array2[num];
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						_transaction = sqlConnection2.BeginTransaction();
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = _transaction,
							CommandText = string.Format("INSERT INTO {0} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)", scoresTable, classRegisterFor),
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter.Value = value2;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
							sqlParameter.Value = text + academicYear;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter.Value = value;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter.Value = classRegisterFor;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand2.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = _transaction,
							CommandText = string.Format("INSERT INTO {0} (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)", generalReport, classRegisterFor),
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter2.Value = value2;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter2.Value = text + academicYear;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = value;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter2.Value = classRegisterFor;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						_transaction.Commit();
						sqlConnection2.Close();
					}
				}
				t++;
				Thread.Sleep(25);
				bgRegisterStudents.ReportProgress(t);
			}
			t = 0;
			currentTask = "Initializing Students' Grades...";
			maximum = StudentRegistrationAdvanced.Grid_View.RowCount;
			for (int l = 0; l < StudentRegistrationAdvanced.Grid_View.RowCount; l++)
			{
				for (int m = 3; m < StudentRegistrationAdvanced.Grid_View.Columns.Count; m++)
				{
					bool result2 = bool.TryParse(StudentRegistrationAdvanced.Grid_View.GetRowCellValue(l, StudentRegistrationAdvanced.Grid_View.Columns[m].FieldName).ToString(), out result2) && result2;
					if (!result2)
					{
						continue;
					}
					string[] array3 = "TermI- TermII- TermIII-".Split();
					foreach (string text3 in array3)
					{
						using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection3.Open();
						using SqlCommand sqlCommand4 = new SqlCommand
						{
							CommandText = $"SELECT * FROM {generalReportGrading} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
							Connection = sqlConnection3,
							CommandType = CommandType.Text
						};
						sqlCommand4.Parameters.AddWithValue("@StudentNumber", StudentRegistrationAdvanced.Grid_View.GetRowCellValue(l, "StudentNo").ToString());
						sqlCommand4.Parameters.AddWithValue("@SemesterId", text3 + academicYear);
						sqlCommand4.Parameters.AddWithValue("@ClassId", classRegisterFor);
						SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
						if (sqlDataReader2.HasRows)
						{
							continue;
						}
						sqlConnection3.Close();
						using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection4.Open();
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Connection = sqlConnection4,
							CommandText = $"INSERT INTO {generalReportGrading} (StudentNumber,SemesterId,ClassId) VALUES (@StudentNumber,@SemesterId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter3.Value = StudentRegistrationAdvanced.Grid_View.GetRowCellValue(l, "StudentNo").ToString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter3.Value = text3 + academicYear;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
							sqlParameter3.Value = classRegisterFor;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
						sqlConnection4.Close();
					}
				}
				t++;
				Thread.Sleep(25);
				bgRegisterStudents.ReportProgress(t);
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

	private string FirstWords(string input)
	{
		try
		{
			int num = 1;
			int num2 = 0;
			string[] array = input.Split();
			foreach (string text in array)
			{
				num2++;
			}
			if (num2 == 3)
			{
				num = 2;
			}
			for (int j = 0; j < input.Length; j++)
			{
				if (input[j] == ' ')
				{
					num--;
				}
				if (num == 0)
				{
					return input.Substring(0, j);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return string.Empty;
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
		this.bgRegisterStudents = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer();
		this.lblClass = new DevExpress.XtraEditors.LabelControl();
		this.lblAcademicYear = new DevExpress.XtraEditors.LabelControl();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.bgRegisterStudents.WorkerReportsProgress = true;
		this.bgRegisterStudents.WorkerSupportsCancellation = true;
		this.bgRegisterStudents.DoWork += new System.ComponentModel.DoWorkEventHandler(bgRegisterStudents_DoWork);
		this.bgRegisterStudents.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgRegisterStudents_ProgressChanged);
		this.bgRegisterStudents.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgRegisterStudents_RunWorkerCompleted);
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.lblClass.Location = new System.Drawing.Point(7, 55);
		this.lblClass.Name = "lblClass";
		this.lblClass.Size = new System.Drawing.Size(0, 13);
		this.lblClass.TabIndex = 6;
		this.lblClass.Visible = false;
		this.lblAcademicYear.Location = new System.Drawing.Point(327, 12);
		this.lblAcademicYear.Name = "lblAcademicYear";
		this.lblAcademicYear.Size = new System.Drawing.Size(0, 13);
		this.lblAcademicYear.TabIndex = 7;
		this.lblAcademicYear.Visible = false;
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(418, 44);
		this.progressBarControl1.TabIndex = 8;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(418, 44);
		base.Controls.Add(this.progressBarControl1);
		base.Controls.Add(this.lblAcademicYear);
		base.Controls.Add(this.lblClass);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "RegisterAdvanced";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Registering students...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RegisterAdvanced_FormClosing);
		base.Load += new System.EventHandler(RegisterAdvanced_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
