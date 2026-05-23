using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class RegisterStudentsPre : XtraForm
{
	private int i;

	private int k = 0;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private string connectionString = DataConnection.ConnectToDatabase();

	private static DataSet dataSet;

	private string classForProcessing = string.Empty;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker bgRegisterStudents;

	private ProgressBarControl progressBarControl1;

	public RegisterStudentsPre(string classForProcessing)
	{
		InitializeComponent();
		this.classForProcessing = classForProcessing;
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
		RegisterAllPreprimary();
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

	private string AcademicYear(string Term)
	{
		string result = string.Empty;
		if (Term.Length == 10)
		{
			result = Term.Substring(6, 4);
		}
		else if (Term.Length == 11)
		{
			result = Term.Substring(7, 4);
		}
		else if (Term.Length == 12)
		{
			result = Term.Substring(8, 4);
		}
		return result;
	}

	private void RegisterAllPreprimary()
	{
		try
		{
			k = 0;
			currentTask = "Initializing Teachers' Module Gateway...";
			string workingSemester = WorkingSemesters.GetWorkingSemester();
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
					foreach (string text in array)
					{
						using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
						sqlConnection2.Open();
						using SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = "SELECT * FROM tbl_Scores_PrePrimary WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId  AND ClassId=@ClassId",
							CommandType = CommandType.Text
						};
						sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
						sqlCommand.Parameters.AddWithValue("@SemesterId", text + AcademicYear(workingSemester));
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
							CommandText = "INSERT INTO tbl_Scores_PrePrimary (StudentNumber,SemesterId,ClassId) VALUES (@StudentNumber,@SemesterId,@ClassId)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter.Value = row["StudentNumber"].ToString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
							sqlParameter.Value = text + AcademicYear(workingSemester);
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
			k++;
			Thread.Sleep(10);
			bgRegisterStudents.ReportProgress(k);
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
		this.progressBarControl1.Size = new System.Drawing.Size(358, 37);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(358, 37);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "RegisterStudentsPre";
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
