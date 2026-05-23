using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class SubjectsFix : XtraForm
{
	private int i;

	private int maximum = 0;

	private int k = 0;

	private SqlTransaction trans;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	public SubjectsFix()
	{
		InitializeComponent();
	}

	private void FixSubjects()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ALevelSubjects", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = string.Format("UPDATE ALevelSubjects_Categorised SET SubjectId=@SubjectId WHERE PaperId LIKE '%{0}%'", row["SubjectId"].ToString()),
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter.Value = row["SubjectId"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = string.Format("UPDATE tbl_GeneralReport_AL SET SubjectId=@SubjectId WHERE PaperId LIKE '%{0}%'", row["SubjectId"].ToString()),
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter2.Value = row["SubjectId"].ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = string.Format("UPDATE tbl_Scores_AL SET SubjectId=@SubjectId WHERE PaperId LIKE '%{0}%'", row["SubjectId"].ToString()),
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter3.Value = row["SubjectId"].ToString();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = string.Format("UPDATE tbl_GeneralReport_Grading_AL SET SubjectId=@SubjectId WHERE SubjectId LIKE '%{0}%'", row["SubjectId"].ToString()),
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter4.Value = row["SubjectId"].ToString();
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection.Close();
			k++;
			Thread.Sleep(10);
			backgroundWorker1.ReportProgress(k);
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		FixSubjects();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 2)
		{
			timer1.Enabled = false;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void SubjectsFix_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Dispose();
	}

	private void SubjectsFix_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (backgroundWorker1.IsBusy)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to cancel the current process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				backgroundWorker1.CancelAsync();
				e.Cancel = false;
			}
			else
			{
				e.Cancel = true;
			}
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
		this.progressBarControl1.Size = new System.Drawing.Size(380, 40);
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
		base.ClientSize = new System.Drawing.Size(380, 40);
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SubjectsFix";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Subjects Fix";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(SubjectsFix_FormClosing);
		base.Load += new System.EventHandler(SubjectsFix_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
