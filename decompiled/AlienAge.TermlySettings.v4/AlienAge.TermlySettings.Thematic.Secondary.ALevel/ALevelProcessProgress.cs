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

namespace AlienAge.TermlySettings.Thematic.Secondary.ALevel;

public class ALevelProcessProgress : XtraForm
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

	private bool input100 = false;

	private DateTime dtTermBegins = DateTime.Now;

	private string _selectedSets = "";

	private string reportHeader = "";

	private int maximum = 0;

	private int k = 0;

	private int w = 0;

	private string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	public ALevelProcessProgress(double HOP, double BOT, double MOT, double EOT, bool PROCESSASPER, DateTime DTBEGINS, string REPORTHEADER, string SELECTEDSETS, string STUDENTCLASS, string SEMESTER, bool INPUT100, string H_HoP, string H_BOT, string H_MOT, string H_EOT)
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
	}

	private void UpdateScores(string StudentNumber, string PaperId, string AvMark, string Category, float Grade, string HOP, string BOT, string MOT, string EOT)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string commandText = "UPDATE tbl_GeneralReport_AL SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,AvMark = @AvMark,Grade = @Grade,Category = @Category WHERE StudentNumber = @StudentNumber AND PaperId = @PaperId AND SemesterId = @SemesterId AND ClassId=@ClassId";
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
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 6);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 3);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.Float);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				else
				{
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 6);
					sqlParameter.Value = AvMark;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 3);
					sqlParameter.Value = Category;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.Float);
					sqlParameter.Value = Grade;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter.Value = Semester;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
				sqlParameter.Value = PaperId;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ProcessALevelReportCards()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			string selectCommandText = $"SELECT * FROM tbl_Scores_AL WHERE ClassId='{StudentClass}' AND SemesterId='{Semester}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Scores");
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
				num = result;
				num2 = result2;
				num3 = result3;
				num4 = result4;
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
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (mot > 0.0 && bot == 0.0 && eot == 0.0 && hop == 0.0 && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (eot > 0.0 && mot == 0.0 && bot == 0.0 && hop == 0.0 && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (bot > 0.0 && mot > 0.0 && eot == 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (mot > 0.0 && eot > 0.0 && bot == 0.0 && hop == 0.0 && (text3 == "-" || string.IsNullOrEmpty(text3)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (bot > 0.0 && eot > 0.0 && mot == 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (bot > 0.0 && mot > 0.0 && eot > 0.0 && hop == 0.0 && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else if (hop > 0.0 && bot > 0.0 && mot > 0.0 && eot > 0.0 && (text == "-" || string.IsNullOrEmpty(text)) && (text2 == "-" || string.IsNullOrEmpty(text2)) && (text3 == "-" || string.IsNullOrEmpty(text3)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), "-", "-", 0f, "-", "-", "-", "-");
				}
				else
				{
					foreach (DataRow row2 in ALevelGradingScale.SubjectGradingScale.Rows)
					{
						double num5 = 0.0;
						double num6 = 0.0;
						if (ProcessAspercentage)
						{
							int num7 = 0;
							double[] array = new double[4] { hop, bot, mot, eot };
							for (int i = 0; i < 4; i++)
							{
								if (array[i] > 0.0)
								{
									num7++;
								}
							}
							num6 = (result + result2 + result3 + result4) / (double)num7;
							num5 = Math.Round(num6, 0, MidpointRounding.AwayFromZero);
						}
						else if (!ProcessAspercentage)
						{
							num6 = num + num2 + num3 + num4;
							num5 = num6;
						}
						if (Convert.ToDouble(row2["Debut"]) <= num5 && num5 <= Convert.ToDouble(row2["End"]))
						{
							UpdateScores(row["StudentNumber"].ToString(), row["PaperId"].ToString(), num5.ToString(), row2["Category"].ToString(), Convert.ToInt64(row2["Points"].ToString()), num.ToString(), num2.ToString(), num3.ToString(), num4.ToString());
						}
					}
				}
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		w++;
		if (w == 5)
		{
			timer1.Enabled = false;
			w = 0;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		ProcessALevelReportCards();
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

	private void ALevelProcessProgress_Load(object sender, EventArgs e)
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
		base.Name = "ALevelProcessProgress";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Re-assigning sets. Please wait...";
		base.Load += new System.EventHandler(ALevelProcessProgress_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
