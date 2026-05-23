using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.DialogForms;

public class GenerateRollcall : XtraForm
{
	private int k = 0;

	private int max = 0;

	private int i = 0;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	public GenerateRollcall()
	{
		InitializeComponent();
	}

	private void DeleteExistingRollCall()
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "DELETE FROM AttendanceSheetRollCall WHERE ClassId=@ClassId AND StreamId=@StreamId AND UserId=@UserId",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", RollCallHelper.ClassId);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StreamId", RollCallHelper.StreamId);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@UserId", CurrentUser.UserID);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void CreateRollCallWeekly()
	{
		DeleteExistingRollCall();
		List<DateTime> list = new List<DateTime>();
		for (int i = 0; i < 7; i++)
		{
			list.Add(RollCallHelper.EffectiveDate.AddDays(i));
		}
		this.i = 0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.fullName, s.StudentNumber, s.StudentID, s.ClassId, s.StreamId, s.Sex,s.Status, a.SemesterId, a.AttendanceCategory  FROM   AttendanceSheet a INNER JOIN tbl_Stud s ON a.StudentNo = s.StudentNumber  WHERE (s.ClassId = '{RollCallHelper.ClassId}') AND (s.StreamId = '{RollCallHelper.StreamId}') AND (a.SemesterId = '{WorkingSemesters.GetWorkingSemester()}') AND (a.AttendanceCategory = 'Reporting') AND (s.Status = 'Active')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		max = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandType = CommandType.Text,
				CommandText = "INSERT INTO AttendanceSheetRollCall (Name,StudentNumber,StudentId,ClassId,StreamId,Sex,Date1,Date2,Date3,Date4,Date5,Date6,Date7,UserId) VALUES (@Name,@StudentNumber,@StudentId,@ClassId,@StreamId,@Sex,@Date1,@Date2,@Date3,@Date4,@Date5,@Date6,@Date7,@UserId)"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@Name", row["fullName"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentId", row["StudentID"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", row["ClassId"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StreamId", row["StreamId"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Sex", row["Sex"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date1", list[0].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date2", list[1].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date3", list[2].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date4", list[3].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date5", list[4].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date6", list[5].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date7", list[6].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@UserId", CurrentUser.UserID);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			this.i++;
			Thread.Sleep(25);
			backgroundWorker1.ReportProgress(this.i);
		}
	}

	private void CreateRollCallMonthly()
	{
		DeleteExistingRollCall();
		List<DateTime> list = new List<DateTime>();
		for (int i = 0; i < 30; i++)
		{
			list.Add(RollCallHelper.EffectiveDate.AddDays(i));
		}
		this.i = 0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.fullName, s.StudentNumber, s.StudentID, s.ClassId, s.StreamId, s.Sex,s.Status, a.SemesterId, a.AttendanceCategory  FROM   AttendanceSheet a INNER JOIN tbl_Stud s ON a.StudentNo = s.StudentNumber  WHERE (s.ClassId = '{RollCallHelper.ClassId}') AND (s.StreamId = '{RollCallHelper.StreamId}') AND (a.SemesterId = '{WorkingSemesters.GetWorkingSemester()}') AND (a.AttendanceCategory = 'Reporting') AND (s.Status = 'Active')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		max = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandType = CommandType.Text,
				CommandText = "INSERT INTO AttendanceSheetRollCall (Name,StudentNumber,StudentId,ClassId,StreamId,Sex,Date1,Date2,Date3,Date4,Date5,Date6,Date7,Date8,Date9,Date10,Date11,Date12,Date13,Date14,Date15,Date16,Date17,Date18,Date19,Date20,Date21,Date22,Date23,Date24,Date25,Date26,Date27,Date28,Date29,Date30,UserId) VALUES (@Name,@StudentNumber,@StudentId,@ClassId,@StreamId,@Sex,@Date1,@Date2,@Date3,@Date4,@Date5,@Date6,@Date7,@Date8,@Date9,@Date10,@Date11,@Date12,@Date13,@Date14,@Date15,@Date16,@Date17,@Date18,@Date19,@Date20,@Date21,@Date22,@Date23,@Date24,@Date25,@Date26,@Date27,@Date28,@Date29,@Date30,@UserId)"
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@Name", row["fullName"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentId", row["StudentID"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", row["ClassId"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StreamId", row["StreamId"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Sex", row["Sex"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date1", list[0].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date2", list[1].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date3", list[2].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date4", list[3].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date5", list[4].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date6", list[5].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date7", list[6].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date8", list[7].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date9", list[8].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date10", list[9].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date11", list[10].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date12", list[11].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date13", list[12].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date14", list[13].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date15", list[14].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date16", list[15].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date17", list[16].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date18", list[17].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date19", list[18].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date20", list[19].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date21", list[20].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date22", list[21].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date23", list[22].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date24", list[23].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date25", list[24].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date26", list[25].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date27", list[26].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date28", list[27].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date29", list[28].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Date30", list[29].ToShortDateString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@UserId", CurrentUser.UserID);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			this.i++;
			Thread.Sleep(25);
			backgroundWorker1.ReportProgress(this.i);
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		if (RollCallHelper.IsWeeklyReport)
		{
			CreateRollCallWeekly();
		}
		else
		{
			CreateRollCallMonthly();
		}
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = max + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 2)
		{
			timer1.Stop();
			k = 0;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void GenerateRollcall_Load(object sender, EventArgs e)
	{
		timer1.Start();
	}

	private void GenerateRollcall_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (backgroundWorker1.IsBusy)
		{
			backgroundWorker1.CancelAsync();
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
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(284, 30);
		this.progressBarControl1.TabIndex = 0;
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 30);
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "GenerateRollcall";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Generating. Please wait...";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(GenerateRollcall_FormClosing);
		base.Load += new System.EventHandler(GenerateRollcall_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
