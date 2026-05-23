using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using DevExpress.XtraEditors;

namespace AlienAge.TermlySettings.Thematic.Primary;

public class PrimaryProcessProgress : XtraForm
{
	private string StudentClass = "";

	private string Semester = "";

	private double hop = 0.0;

	private double bot = 0.0;

	private double mot = 0.0;

	private double eot = 0.0;

	private string h_hop = string.Empty;

	private string h_bot = string.Empty;

	private string h_mot = string.Empty;

	private string h_eot = string.Empty;

	private bool ProcessAspercentage = false;

	private DateTime dtTermBegins = DateTime.Now;

	private string _selectedSets = "";

	private string reportHeader = "";

	private bool input100 = false;

	private bool aeot = false;

	private int maximum = 0;

	private int k = 0;

	private int w = 0;

	private readonly string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	public PrimaryProcessProgress(double HOP, double BOT, double MOT, double EOT, bool PROCESSASPER, DateTime DTBEGINS, string REPORTHEADER, string SELECTEDSETS, string STUDENTCLASS, string SEMESTER, bool INPUT100, string H_HoP, string H_BOT, string H_MOT, string H_EOT, bool aeot)
	{
		InitializeComponent();
		hop = HOP;
		bot = BOT;
		mot = MOT;
		eot = EOT;
		h_hop = H_HoP;
		h_bot = H_BOT;
		h_mot = H_MOT;
		h_eot = H_EOT;
		ProcessAspercentage = PROCESSASPER;
		dtTermBegins = DTBEGINS;
		reportHeader = REPORTHEADER;
		_selectedSets = SELECTEDSETS;
		StudentClass = STUDENTCLASS;
		Semester = SEMESTER;
		input100 = INPUT100;
		this.aeot = aeot;
	}

	private void UpdateScores(string StudentNumber, string Subject, string AvMark, string Category, string Grade, string Comment, string HOP, string BOT, string MOT, string EOT)
	{
		try
		{
			string text = StudentClass.Substring(2, 1);
			string commandText = "UPDATE tbl_GeneralReportCards_Primary SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,AvMark = @AvMark,Grade = @Grade,Category = @Category,Comment = @Comment WHERE StudentNumber = @StudentNumber AND SubjectId = @SubjectId AND SemesterId = @SemesterId AND ClassId = @ClassId";
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
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = StudentClass;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HoP", SqlDbType.VarChar, 4);
				sqlParameter.Value = HOP;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BOT", SqlDbType.VarChar, 4);
				sqlParameter.Value = BOT;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@MOT", SqlDbType.VarChar, 4);
				sqlParameter.Value = MOT;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@EOT", SqlDbType.VarChar, 4);
				sqlParameter.Value = EOT;
				sqlParameter.Direction = ParameterDirection.Input;
				if (string.IsNullOrEmpty(AvMark) || AvMark == "-")
				{
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.Float);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.VarChar, 1);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 2);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				else
				{
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 3);
					sqlParameter.Value = AvMark;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.VarChar, 1);
					sqlParameter.Value = Grade;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 2);
					sqlParameter.Value = Category;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
					sqlParameter.Value = Comment;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
				sqlParameter.Value = Semester;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
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

	private void ProcessPrimaryReportCards()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_Primary WHERE ClassId = '{StudentClass}' AND SemesterId='{Semester}'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GeneralReport");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			k = 0;
			maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				k++;
				string text = row["HoP"].ToString();
				string text2 = row["BOT"].ToString();
				string text3 = row["MOT"].ToString();
				string text4 = row["EOT"].ToString();
				double result = (double.TryParse(text, out result) ? result : 0.0);
				double result2 = (double.TryParse(text2, out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(text3, out result3) ? result3 : 0.0);
				double result4 = (double.TryParse(text4, out result4) ? result4 : 0.0);
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				if (input100)
				{
					num = result;
					num2 = result2;
					num3 = result3;
					num4 = result4;
				}
				else
				{
					num = Math.Round(result / 100.0 * hop, 0, MidpointRounding.AwayFromZero);
					num2 = Math.Round(result2 / 100.0 * bot, 0, MidpointRounding.AwayFromZero);
					num3 = Math.Round(result3 / 100.0 * mot, 0, MidpointRounding.AwayFromZero);
					num4 = Math.Round(result4 / 100.0 * eot, 0, MidpointRounding.AwayFromZero);
				}
				if (bot > 0.0 && mot == 0.0 && eot == 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (mot > 0.0 && bot == 0.0 && eot == 0.0 && hop == 0.0 && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (eot > 0.0 && mot == 0.0 && bot == 0.0 && hop == 0.0 && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (bot > 0.0 && mot > 0.0 && eot == 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (mot > 0.0 && eot > 0.0 && bot == 0.0 && hop == 0.0 && (text3 == "-" || text3 == "") && (text4 == "-" || text4 == ""))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (bot > 0.0 && eot > 0.0 && mot == 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (bot > 0.0 && mot > 0.0 && eot > 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else if (hop > 0.0 && bot > 0.0 && mot > 0.0 && eot > 0.0 && (text == "-" || string.IsNullOrEmpty(text)) && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), "-", "-", "-", "-", "-", "-", "-", "-");
				}
				else
				{
					double result5 = (double.TryParse(row["HoP"].ToString(), out result5) ? result5 : 0.0);
					double result6 = (double.TryParse(row["BOT"].ToString(), out result6) ? result6 : 0.0);
					double result7 = (double.TryParse(row["MOT"].ToString(), out result7) ? result7 : 0.0);
					double result8 = (double.TryParse(row["EOT"].ToString(), out result8) ? result8 : 0.0);
					foreach (DataRow row2 in OLevelGradingScale.Instance.SubjectGradingScale.Rows)
					{
						double num5 = 0.0;
						double value = 0.0;
						if (ProcessAspercentage)
						{
							int num6 = 0;
							double[] array = new double[4] { hop, bot, mot, eot };
							for (int i = 0; i < 4; i++)
							{
								if (array[i] > 0.0)
								{
									num6++;
								}
							}
							value = ((!aeot) ? ((num + num2 + num3 + num4) / (double)num6) : num4);
							num5 = Math.Round(value, 0);
						}
						else if (!ProcessAspercentage)
						{
							double value2 = result5 / 100.0 * hop;
							double value3 = result6 / 100.0 * bot;
							double value4 = result7 / 100.0 * mot;
							double value5 = result8 / 100.0 * eot;
							if (aeot)
							{
								Math.Round(value5, 0);
							}
							else
							{
								value = Math.Round(value2, 0) + Math.Round(value3, 0) + Math.Round(value4, 0) + Math.Round(value5, 0);
							}
							num5 = Math.Round(value, 0);
						}
						if (Convert.ToDouble(row2["Debut"]) <= num5 && num5 <= Convert.ToDouble(row2["End"]))
						{
							Random random = new Random();
							int num7 = (int)(random.NextDouble() * 5.0 + 1.0);
							string comment = "";
							switch (num7)
							{
							case 1:
								comment = row2["Comment"].ToString();
								break;
							case 2:
								comment = row2["Comment2"].ToString();
								break;
							case 3:
								comment = row2["Comment3"].ToString();
								break;
							case 4:
								comment = row2["Comment4"].ToString();
								break;
							case 5:
								comment = row2["Comment5"].ToString();
								break;
							}
							UpdateScores(row["StudentNumber"].ToString(), row["SubjectId"].ToString(), num5.ToString(), row2["Category"].ToString(), row2["Points"].ToString(), comment, num.ToString(), num2.ToString(), num3.ToString(), num4.ToString());
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
		XtraMessageBox.Show("All Processes completed successfully.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		ProcessPrimaryReportCards();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		w++;
		if (w == 5)
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
		base.Name = "PrimaryProcessProgress";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Re-assigning sets. Please wait...";
		base.Load += new System.EventHandler(OLevelProcessProgress_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
