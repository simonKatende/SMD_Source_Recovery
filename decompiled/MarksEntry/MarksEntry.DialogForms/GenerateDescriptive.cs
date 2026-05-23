using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using DevExpress.XtraEditors;

namespace MarksEntry.DialogForms;

public class GenerateDescriptive : XtraForm
{
	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private string _Subject;

	private string _Class;

	private string _Term;

	private string _Initial;

	private int maximum = 0;

	private int w = 1;

	private IContainer components = null;

	private BackgroundWorker backgroundWorker1;

	private ProgressBarControl progressBarControl1;

	public GenerateDescriptive(string _Subject, string _Class, string _Term, string _Initial)
	{
		InitializeComponent();
		this._Subject = _Subject;
		this._Class = _Class;
		this._Term = _Term;
		this._Initial = _Initial;
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		GenerateDescriptiveGrid();
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("All Processes completed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void GenerateDescriptive_Load(object sender, EventArgs e)
	{
		backgroundWorker1.RunWorkerAsync();
	}

	private string ScoreHeader(int ColIndex)
	{
		string result = string.Empty;
		if (ReportCustomization.ShowRawScores)
		{
			switch (ColIndex)
			{
			case 1:
				result = "T1";
				break;
			case 2:
				result = "T2";
				break;
			case 3:
				result = "T3";
				break;
			case 4:
				result = "T4";
				break;
			case 5:
				result = "T5";
				break;
			case 6:
				result = "T6";
				break;
			case 7:
				result = "T7";
				break;
			case 8:
				result = "T8";
				break;
			case 9:
				result = "T9";
				break;
			case 10:
				result = "T10";
				break;
			}
		}
		else
		{
			switch (ColIndex)
			{
			case 1:
				result = "U1";
				break;
			case 2:
				result = "U2";
				break;
			case 3:
				result = "U3";
				break;
			case 4:
				result = "U4";
				break;
			}
		}
		return result;
	}

	private int TotalUnits()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ClassId, SemesterId, SubjectId, TUnits FROM tbl_TermSettingsNC  WHERE (SubjectId = '{_Subject}') AND (SemesterId = '{_Term}') AND (ClassId = '{_Class}')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count == 0)
		{
			return 1;
		}
		int result;
		return (!int.TryParse(dataTable.Rows[0]["TUnits"].ToString(), out result)) ? 1 : result;
	}

	private string Descriptor(double value)
	{
		string empty = string.Empty;
		if (value >= 3.0 && value <= 4.0)
		{
			return "Basic";
		}
		if (value >= 5.0 && value <= 8.0)
		{
			return "Moderate";
		}
		if (value >= 9.0 && value <= 10.0)
		{
			return "Outstanding";
		}
		return "Learner Absent";
	}

	private void GenerateDescriptiveGrid()
	{
		try
		{
			w = 1;
			string text = DataConnection.ConnectToDatabase();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,ClassId FROM tbl_Stud WHERE ClassId='{_Class}'", text);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				string text2 = row["StudentNumber"].ToString();
				string selectCommandText = $"SELECT * FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND SubjectId='{_Subject}' AND ClassId='{_Class}' AND StudentNumber='{text2}'";
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, text);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				if (dataTable2.Rows.Count > 0)
				{
					string empty = string.Empty;
					string empty2 = string.Empty;
					using (SqlConnection sqlConnection = new SqlConnection(text))
					{
						sqlConnection.Open();
						using SqlCommand sqlCommand = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = "DELETE FROM OLevelReportNC WHERE StudentNo=@StudentNo AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId AND CompetencyNo>@CompetencyNo",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNo", text2);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@CompetencyNo", TotalUnits());
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand.ExecuteNonQuery();
						sqlConnection.Close();
					}
					int num = TotalUnits();
					int num2;
					for (num2 = 1; num2 < num + 1; num2++)
					{
						num2++;
						empty = dataTable2.Rows[0][ScoreHeader(num2)].ToString();
						double result = (double.TryParse(empty, out result) ? result : 0.0);
						empty2 = ((!ReportCustomization.ShowRawScores) ? gradingScale.GetGradingScale(Convert.ToDouble(result)).Value : Descriptor(result));
						SqlConnection sqlConnection2 = new SqlConnection(text);
						sqlConnection2.Open();
						string commandText = $"SELECT * FROM OLevelReportNC WHERE SemesterId='{_Term}' AND SubjectId='{_Subject}' AND ClassId='{_Class}' AND StudentNo='{text2}' AND CompetencyNo={num2}";
						SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = commandText,
							CommandType = CommandType.Text
						};
						SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
						if (!sqlDataReader.HasRows)
						{
							sqlDataReader.Close();
							sqlConnection2.Close();
							sqlConnection2.Open();
							using SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = "INSERT INTO OLevelReportNC (StudentNo,SubjectId,ClassId,CompetencyNo,Score,Descriptor,TeacherInitial,SemesterId) VALUES (@StudentNo,@SubjectId,@ClassId,@CompetencyNo,@Score,@Descriptor,@TeacherInitial,@SemesterId)",
								CommandType = CommandType.Text
							};
							SqlParameter sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@StudentNo", text2);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@SubjectId", _Subject);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@ClassId", _Class);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@CompetencyNo", num2);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@Score", empty);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@Descriptor", empty2);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@TeacherInitial", _Initial);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.AddWithValue("@SemesterId", _Term);
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
							sqlConnection2.Close();
						}
						else
						{
							sqlDataReader.Close();
							sqlConnection2.Close();
							sqlConnection2.Open();
							using SqlCommand sqlCommand4 = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = "UPDATE OLevelReportNC SET Score=@Score,Descriptor=@Descriptor,TeacherInitial=@TeacherInitial WHERE StudentNo=@StudentNo AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId AND CompetencyNo=@CompetencyNo",
								CommandType = CommandType.Text
							};
							SqlParameter sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@StudentNo", text2);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@SubjectId", _Subject);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@ClassId", _Class);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@CompetencyNo", num2);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@Score", empty);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@Descriptor", empty2);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@TeacherInitial", _Initial);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.AddWithValue("@SemesterId", _Term);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
							sqlConnection2.Close();
						}
					}
				}
				w++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(w);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.DialogResult = DialogResult.OK;
			Close();
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
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(365, 55);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(365, 55);
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "GenerateDescriptive";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Working. Please wait...";
		base.Load += new System.EventHandler(GenerateDescriptive_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
