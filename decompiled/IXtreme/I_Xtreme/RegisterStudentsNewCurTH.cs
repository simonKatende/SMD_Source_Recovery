using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

public class RegisterStudentsNewCurTH : XtraForm
{
	private int i;

	private int k = 0;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private string _Class = string.Empty;

	private string _Term = string.Empty;

	private GridView grvSubjects = null;

	private GridView grvStudents = null;

	private string connectionString = string.Empty;

	private string academicYear = string.Empty;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker bgRegisterStudents;

	private ProgressBarControl progressBarControl1;

	public RegisterStudentsNewCurTH(string _Class, string _Term, GridView grvSubjects, GridView grvStudents)
	{
		InitializeComponent();
		this._Class = _Class;
		this._Term = _Term;
		this.grvStudents = grvStudents;
		this.grvSubjects = grvSubjects;
		connectionString = DataConnection.ConnectToDatabase();
		academicYear = _Term.Substring(_Term.IndexOf('-') + 1, 4);
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
		RegisterAllOLevel();
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

	private int UnitsUsed(string _subject, string _class, string _term)
	{
		int result = 1;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNCTH WHERE ClassId='{_class}' AND SemesterId='{_term}' AND SubjectId='{_subject}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			result = Convert.ToInt32(dataTable.Rows[0]["TUnits"].ToString());
		}
		return result;
	}

	private void RegisterAllOLevel()
	{
		try
		{
			this.k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			int[] selectedRows = grvStudents.GetSelectedRows();
			int[] selectedRows2 = grvSubjects.GetSelectedRows();
			maximum = selectedRows.Length;
			string[] array = "TermI- TermII- TermIII-".Split();
			foreach (string text in array)
			{
				string text2 = text + academicYear;
				for (int j = 0; j < selectedRows2.Length; j++)
				{
					string text3 = grvSubjects.GetRowCellValue(selectedRows2[j], "Subject_En").ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNCTH WHERE SemesterId='{text2}' AND ClassId='{_Class}' AND SubjectId='{text3}'", DataConnection.ConnectToDatabase());
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					if (dataTable.Rows.Count == 0)
					{
						SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection.Open();
						SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = "INSERT INTO tbl_TermSettingsNCTH (ClassId,SemesterId,TUnits,IsAssessed,SubjectId) VALUES (@ClassId,@SemesterId,1,'1',@SubjectId)",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", text2);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", text3);
						sqlParameter.Direction = ParameterDirection.Input;
						if (sqlCommand.ExecuteNonQuery() > 0)
						{
							sqlConnection.Close();
						}
					}
				}
			}
			string[] array2 = "TermI- TermII- TermIII-".Split();
			foreach (string text4 in array2)
			{
				string text5 = text4 + academicYear;
				for (int l = 0; l < selectedRows.Length; l++)
				{
					for (int m = 0; m < selectedRows2.Length; m++)
					{
						string text6 = grvSubjects.GetRowCellValue(selectedRows2[m], "Subject_En").ToString();
						string value = grvSubjects.GetRowCellValue(selectedRows2[m], "Subject_Ar").ToString();
						string value2 = grvStudents.GetRowCellValue(selectedRows[l], "StudentNumber").ToString();
						SqlConnection sqlConnection2 = new SqlConnection(connectionString);
						sqlConnection2.Open();
						using SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = "SELECT * FROM tbl_Scores_OL_ReportTH WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
							CommandType = CommandType.Text
						};
						sqlCommand2.Parameters.AddWithValue("@StudentNumber", value2);
						sqlCommand2.Parameters.AddWithValue("@SemesterId", text4 + academicYear);
						sqlCommand2.Parameters.AddWithValue("@SubjectId", text6);
						sqlCommand2.Parameters.AddWithValue("@ClassId", _Class);
						SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
						if (!sqlDataReader.HasRows)
						{
							sqlDataReader.Close();
							DateTime now = DateTime.Now;
							using (SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = "INSERT INTO tbl_Scores_OL_ReportTH (StudentNumber,SemesterId,SubjectId,SubjectIdAr,ClassId,TUnits, U1,U2,U3,U4,Score1,Score2,Score3,Score4,Hund1,Hund2,Hund3,Hund4) VALUES (@StudentNumber,@SemesterId,@SubjectId,@SubjectIdAr,@ClassId,@TUnits, @U1,@U2,@U3,@U4,@Score1,@Score2,@Score3,@Score4,@Hund1,@Hund2,@Hund3,@Hund4)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
								sqlParameter2.Value = value2;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
								sqlParameter2.Value = text5;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 100);
								sqlParameter2.Value = text6;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectIdAr", SqlDbType.NVarChar, 100);
								sqlParameter2.Value = value;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.NVarChar, 100);
								sqlParameter2.Value = _Class;
								sqlParameter2.Direction = ParameterDirection.Input;
								if (UnitsUsed(text6, _Class, text5) == 1)
								{
									sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
									sqlParameter2.Value = 1;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
								}
								else if (UnitsUsed(text6, _Class, text5) == 2)
								{
									sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
									sqlParameter2.Value = 2;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
								}
								else if (UnitsUsed(text6, _Class, text5) == 3)
								{
									sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
									sqlParameter2.Value = 3;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "x";
									sqlParameter2.Direction = ParameterDirection.Input;
								}
								else if (UnitsUsed(text6, _Class, text5) == 4)
								{
									sqlParameter2 = sqlCommand3.Parameters.Add("@TUnits", SqlDbType.Int);
									sqlParameter2.Value = 4;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@U4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score1", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score2", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score3", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Score4", SqlDbType.VarChar, 4);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund1", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund2", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund3", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@Hund4", SqlDbType.NVarChar, 3);
									sqlParameter2.Value = "";
									sqlParameter2.Direction = ParameterDirection.Input;
								}
								sqlCommand3.ExecuteNonQuery();
							}
							sqlConnection2.Close();
						}
						else
						{
							sqlDataReader.Close();
							sqlConnection2.Close();
						}
					}
					this.k++;
					Thread.Sleep(10);
					bgRegisterStudents.ReportProgress(this.k);
				}
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
		this.timer1 = new System.Windows.Forms.Timer();
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
		this.progressBarControl1.Size = new System.Drawing.Size(418, 44);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(418, 44);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "RegisterStudentsNewCur";
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
