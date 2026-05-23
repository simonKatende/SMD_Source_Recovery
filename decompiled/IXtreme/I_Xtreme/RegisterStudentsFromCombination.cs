using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class RegisterStudentsFromCombination : XtraForm
{
	private int i;

	private int k = 1;

	private int maximum = 0;

	private string currentTask = string.Empty;

	private string Term = string.Empty;

	private string ClassId = string.Empty;

	private string StreamId = string.Empty;

	private SqlTransaction _trans;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker bgRegisterStudents;

	private ProgressBarControl progressBarControl1;

	public RegisterStudentsFromCombination(string Term, string ClassId, string StreamId)
	{
		InitializeComponent();
		this.ClassId = ClassId;
		this.StreamId = StreamId;
		this.Term = Term;
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
			i = 0;
			timer1.Enabled = false;
			bgRegisterStudents.RunWorkerAsync();
		}
	}

	private void InitializeCombinations()
	{
		k = 1;
		currentTask = "Initializing Combinations...";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_SubjectCombinations", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		maximum = dataTable.Rows.Count;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		foreach (DataRow row in dataTable.Rows)
		{
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_Stud SET SubjectString=@SubjectString WHERE Comb=@Comb",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectString", row["combFull"]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Comb", row["combShort"]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			k++;
			Thread.Sleep(10);
			bgRegisterStudents.ReportProgress(k);
		}
	}

	private void bgRegisterStudents_DoWork(object sender, DoWorkEventArgs e)
	{
		InitializeCombinations();
		RegisterAllALevel();
		InitializeGradingTables();
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

	private void RegisterAllALevel()
	{
		try
		{
			k = 1;
			currentTask = "Initializing Teachers' Gateway...";
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string text = DataConnection.ConnectToDatabase();
			string selectCommandText = $"SELECT * FROM tbl_Stud WHERE ClassId='{ClassId}' AND StreamId='{StreamId}' AND Status='Active'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, text);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			maximum = dataTable.Rows.Count;
			SqlConnection sqlConnection = new SqlConnection(text);
			foreach (DataRow row in dataTable.Rows)
			{
				empty4 = row["SubjectString"].ToString();
				if (empty4.Length == 12)
				{
					string[] subjectsFromCombinations = Subjects.GetSubjectsFromCombinations(empty4);
					for (int i = 0; i < subjectsFromCombinations.Length; i++)
					{
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT s.SubjectId, s.ShortCode, p.PaperId,p.Paper FROM ALevelSubjects s INNER JOIN ALevelSubjects_Categorised p ON s.SubjectId = p.SubjectId WHERE (s.ShortCode = '{subjectsFromCombinations[i]}')", DataConnection.ConnectToDatabase());
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						if (dataTable2.Rows.Count <= 0)
						{
							continue;
						}
						foreach (DataRow row2 in dataTable2.Rows)
						{
							empty2 = row2["SubjectId"].ToString();
							empty = row2["PaperId"].ToString();
							empty3 = row2["Paper"].ToString();
							sqlConnection.Open();
							SqlCommand sqlCommand = new SqlCommand
							{
								CommandText = "SELECT * FROM tbl_GeneralReport_AL WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId AND ClassId=@ClassId ",
								Connection = sqlConnection,
								CommandType = CommandType.Text
							};
							sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
							sqlCommand.Parameters.AddWithValue("@SemesterId", Term);
							sqlCommand.Parameters.AddWithValue("@PaperId", empty);
							sqlCommand.Parameters.AddWithValue("@ClassId", ClassId);
							SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
							if (!sqlDataReader.HasRows)
							{
								sqlDataReader.Close();
								_trans = sqlConnection.BeginTransaction();
								using (SqlCommand sqlCommand2 = new SqlCommand
								{
									Connection = sqlConnection,
									Transaction = _trans,
									CommandText = "INSERT INTO tbl_Scores_AL (StudentNumber,SemesterId,SubjectId,PaperId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@ClassId)",
									CommandType = CommandType.Text
								})
								{
									SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
									sqlParameter.Value = row["StudentNumber"].ToString();
									sqlParameter.Direction = ParameterDirection.Input;
									sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
									sqlParameter.Value = Term;
									sqlParameter.Direction = ParameterDirection.Input;
									sqlParameter = sqlCommand2.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
									sqlParameter.Value = empty;
									sqlParameter.Direction = ParameterDirection.Input;
									sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
									sqlParameter.Value = empty2;
									sqlParameter.Direction = ParameterDirection.Input;
									sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
									sqlParameter.Value = ClassId;
									sqlParameter.Direction = ParameterDirection.Input;
									sqlCommand2.ExecuteNonQuery();
								}
								using (SqlCommand sqlCommand3 = new SqlCommand
								{
									Connection = sqlConnection,
									Transaction = _trans,
									CommandText = "INSERT INTO tbl_GeneralReport_AL (StudentNumber,SubjectId,PaperId,SemesterId,ClassId) VALUES (@StudentNumber,@SubjectId,@PaperId,@SemesterId,@ClassId)",
									CommandType = CommandType.Text
								})
								{
									SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
									sqlParameter2.Value = row["StudentNumber"].ToString();
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
									sqlParameter2.Value = Term;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
									sqlParameter2.Value = empty2;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
									sqlParameter2.Value = empty;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
									sqlParameter2.Value = ClassId;
									sqlParameter2.Direction = ParameterDirection.Input;
									sqlCommand3.ExecuteNonQuery();
								}
								_trans.Commit();
							}
							sqlDataReader.Close();
							sqlConnection.Close();
						}
					}
				}
				k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void InitializeGradingTables()
	{
		try
		{
			k = 1;
			currentTask = "Generating Grading Scheme...";
			string empty = string.Empty;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,SemesterId,SubjectId,ClassId FROM tbl_GeneralReport_AL WHERE SemesterId='{Term}' AND ClassId='{ClassId}' GROUP BY StudentNumber,SemesterId,SubjectId,ClassId ORDER BY StudentNumber, SubjectId", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			maximum = dataTable.Rows.Count;
			sqlDataAdapter.Fill(dataTable);
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			foreach (DataRow row in dataTable.Rows)
			{
				empty = row["SubjectId"].ToString();
				sqlConnection.Open();
				SqlCommand sqlCommand = new SqlCommand
				{
					CommandText = "SELECT * FROM tbl_GeneralReport_Grading_AL WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId",
					Connection = sqlConnection,
					CommandType = CommandType.Text
				};
				sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
				sqlCommand.Parameters.AddWithValue("@SemesterId", Term);
				sqlCommand.Parameters.AddWithValue("@SubjectId", empty);
				sqlCommand.Parameters.AddWithValue("@ClassId", ClassId);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					sqlConnection.Close();
					sqlConnection.Open();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_GeneralReport_Grading_AL (StudentNumber,SemesterId,SubjectId,ClassId) VALUES (@StudentNumber,@SemesterId,@SubjectId,@ClassId)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
					sqlParameter.Value = row["StudentNumber"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
					sqlParameter.Value = Term;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
					sqlParameter.Value = empty;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
					sqlParameter.Value = ClassId;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlDataReader.Close();
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				bgRegisterStudents.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void bgRegisterStudents_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
		Text = currentTask;
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
		this.progressBarControl1.Size = new System.Drawing.Size(404, 57);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(404, 57);
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "RegisterStudentsFromCombination";
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
