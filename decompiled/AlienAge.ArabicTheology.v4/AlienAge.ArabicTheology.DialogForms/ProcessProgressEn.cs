using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.ArabicTheology.TheologyHelperClasses;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace AlienAge.ArabicTheology.DialogForms;

public class ProcessProgressEn : XtraForm
{
	private string StudentClass = "";

	private string Semester = "";

	private double bot = 0.0;

	private double mot = 0.0;

	private double eot = 0.0;

	private bool ProcessAspercentage = false;

	private DateTime dtTermBegins = DateTime.Now;

	private string _selectedSets = "";

	private string reportHeader = "";

	private string reportHeaderAr = "";

	private string ClassLevel = string.Empty;

	private int maximum = 0;

	private int k = 0;

	private int w = 0;

	private readonly string connectionString = DataConnection.ConnectToDatabase();

	private ArabicNumeralHelper conv;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	public ProcessProgressEn(double BOT, double MOT, double EOT, bool PROCESSASPER, DateTime DTBEGINS, string REPORTHEADER, string REPORTHEADERAr, string SELECTEDSETS, string STUDENTCLASS, string SEMESTER, string ClassLevel)
	{
		InitializeComponent();
		bot = BOT;
		mot = MOT;
		eot = EOT;
		ProcessAspercentage = PROCESSASPER;
		dtTermBegins = DTBEGINS;
		reportHeader = REPORTHEADER;
		reportHeaderAr = REPORTHEADERAr;
		_selectedSets = SELECTEDSETS;
		StudentClass = STUDENTCLASS;
		Semester = SEMESTER;
		this.ClassLevel = ClassLevel;
	}

	private void UpdateScores(string StudentNumber, string Subject, string AvMark, string CategoryEn, string GradeEn, string CommentEn, string BOT, string MOT, string EOT, string CategoryAr, string GradeAr, string CommentAr)
	{
		try
		{
			conv = new ArabicNumeralHelper();
			string text = StudentClass.Substring(2, 1);
			string commandText = "UPDATE tbl_GeneralReport_TH SET BOTEn=@BOTEn,MOTEn=@MOTEn,EOTEn=@EOTEn,AvMarkEn = @AvMarkEn,GradeEn = @GradeEn,CategoryEn = @CategoryEn,CommentEn = @CommentEn, BOTAr = @BOTAr, MOTAr = @MOTAr, EOTAr = @EOTAr, AvMarkAr = @AvMarkAr, GradeAr = @GradeAr, CategoryAr = @CategoryAr, CommentAr = @CommentAr WHERE StudentNumber = @StudentNumber AND SubjectIdEn = @SubjectIdEn AND SemesterId = @SemesterId AND ClassIdEn = @ClassIdEn";
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
				sqlParameter.Value = StudentNumber;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassIdEn", SqlDbType.VarChar, 15);
				sqlParameter.Value = StudentClass;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BOTEn", SqlDbType.VarChar, 4);
				sqlParameter.Value = BOT;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@MOTEn", SqlDbType.VarChar, 4);
				sqlParameter.Value = MOT;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@EOTEn", SqlDbType.VarChar, 4);
				sqlParameter.Value = EOT;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BOTAr", SqlDbType.NVarChar, 4);
				sqlParameter.Value = conv.EnglishToArabic(BOT);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@MOTAr", SqlDbType.NVarChar, 4);
				sqlParameter.Value = conv.EnglishToArabic(MOT);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@EOTAr", SqlDbType.NVarChar, 4);
				sqlParameter.Value = conv.EnglishToArabic(EOT);
				sqlParameter.Direction = ParameterDirection.Input;
				if (string.IsNullOrEmpty(AvMark) || AvMark == "-")
				{
					sqlParameter = sqlCommand.Parameters.Add("@AvMarkEn", SqlDbType.VarChar, 4);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@GradeEn", SqlDbType.VarChar, 3);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CategoryEn", SqlDbType.VarChar, 50);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CommentEn", SqlDbType.VarChar, 30);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AvMarkAr", SqlDbType.NVarChar, 4);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@GradeAr", SqlDbType.NVarChar, 3);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CategoryAr", SqlDbType.NVarChar, 50);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CommentAr", SqlDbType.NVarChar, 30);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				else
				{
					sqlParameter = sqlCommand.Parameters.Add("@AvMarkEn", SqlDbType.VarChar, 4);
					sqlParameter.Value = AvMark;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@GradeEn", SqlDbType.VarChar, 3);
					sqlParameter.Value = GradeEn;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CategoryEn", SqlDbType.VarChar, 50);
					sqlParameter.Value = CategoryEn;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CommentEn", SqlDbType.VarChar, 30);
					sqlParameter.Value = CommentEn;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AvMarkAr", SqlDbType.NVarChar, 4);
					sqlParameter.Value = conv.EnglishToArabic(AvMark);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@GradeAr", SqlDbType.NVarChar, 3);
					sqlParameter.Value = GradeAr;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CategoryAr", SqlDbType.NVarChar, 50);
					sqlParameter.Value = CategoryAr;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@CommentAr", SqlDbType.NVarChar, 30);
					sqlParameter.Value = CommentAr;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
				sqlParameter.Value = Semester;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SubjectIdEn", SqlDbType.VarChar, 50);
				sqlParameter.Value = Subject;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ProcessTheologyReportCards()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_TH WHERE ClassIdEn = '{StudentClass}' AND SemesterId='{Semester}'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GeneralReport");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			k = 0;
			maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				k++;
				string text = row["BOTEn"].ToString();
				string text2 = row["MOTEn"].ToString();
				string text3 = row["EOTEn"].ToString();
				double result = (double.TryParse(text, out result) ? result : 0.0);
				double result2 = (double.TryParse(text2, out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(text3, out result3) ? result3 : 0.0);
				double num = Math.Round(result / 100.0 * bot, 0, MidpointRounding.AwayFromZero);
				double num2 = Math.Round(result2 / 100.0 * mot, 0, MidpointRounding.AwayFromZero);
				double num3 = Math.Round(result3 / 100.0 * eot, 0, MidpointRounding.AwayFromZero);
				if (bot > 0.0 && mot == 0.0 && eot == 0.0 && (text == "-" || string.IsNullOrEmpty(text)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (mot > 0.0 && bot == 0.0 && eot == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (eot > 0.0 && mot == 0.0 && bot == 0.0 && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (bot > 0.0 && mot > 0.0 && eot == 0.0 && (text == "-" || string.IsNullOrEmpty(text)) && (text2 == "-" || string.IsNullOrEmpty(text2)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (mot > 0.0 && eot > 0.0 && bot == 0.0 && (text2 == "-" || text2 == "") && (text3 == "-" || text3 == ""))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (bot > 0.0 && eot > 0.0 && mot == 0.0 && (text == "-" || string.IsNullOrEmpty(text)) && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (bot > 0.0 && mot > 0.0 && eot > 0.0 && (text == "-" || string.IsNullOrEmpty(text)) && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else
				{
					foreach (DataRow row2 in TheologyGradingScale.TheologyGradingScaleSource(ClassLevel).Rows)
					{
						double num4 = 0.0;
						double num5 = 0.0;
						if (ProcessAspercentage)
						{
							int num6 = 0;
							double[] array = new double[3] { bot, mot, eot };
							for (int i = 0; i < 3; i++)
							{
								if (array[i] > 0.0)
								{
									num6++;
								}
							}
							num5 = (num + num2 + num3) / (double)num6;
							num4 = Math.Round(num5, 0);
						}
						else if (!ProcessAspercentage)
						{
							num5 = num + num2 + num3;
							num4 = Math.Round(num5, 0, MidpointRounding.AwayFromZero);
						}
						if (Convert.ToDouble(row2["Debut_En"]) <= num4 && num4 <= Convert.ToDouble(row2["End_En"]))
						{
							string commentEn = row2["Com_En"].ToString();
							string commentAr = row2["Com_Ar"].ToString();
							UpdateScores(row["StudentNumber"].ToString(), row["SubjectIdEn"].ToString(), num4.ToString(), row2["Category_En"].ToString(), row2["Points_En"].ToString(), commentEn, num.ToString(), num2.ToString(), num3.ToString(), row2["Category_Ar"].ToString(), row2["Points_Ar"].ToString(), commentAr);
						}
					}
				}
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		TermSettings.SetTermSettingsEn(StudentClass, Semester, bot, mot, eot, ProcessAspercentage, dtTermBegins, reportHeader.ToUpper(), reportHeaderAr, _selectedSets);
		XtraMessageBox.Show("All Processes completed successfully.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		ProcessTheologyReportCards();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		w++;
		if (w == 3)
		{
			timer1.Enabled = false;
			timer1.Enabled = false;
			w = 0;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void OLevelProcessProgress_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
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
		this.progressBarControl1.Size = new System.Drawing.Size(382, 40);
		this.progressBarControl1.TabIndex = 0;
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(382, 40);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "OLevelProcessProgress";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Re-assigning sets. Please wait...";
		base.Load += new System.EventHandler(OLevelProcessProgress_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
