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

namespace I_Xtreme.WaitForms;

public class UpdateUnits : XtraForm
{
	public enum WaitFormCommand
	{

	}

	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private int maximum = 0;

	private int k = 0;

	private int x = 0;

	private string Semester = string.Empty;

	private string _Class = string.Empty;

	private string Subject = string.Empty;

	private int u1f = 0;

	private int u2f = 0;

	private int u3f = 0;

	private int u4f = 0;

	private int u5f = 0;

	private int u6f = 0;

	private int u7f = 0;

	private int u8f = 0;

	private int u9f = 0;

	private int u10f = 0;

	private int units = 0;

	private IContainer components = null;

	private System.Windows.Forms.Timer timer1;

	private BackgroundWorker backgroundWorker1;

	private ProgressBarControl progressBarControl1;

	public UpdateUnits(string Semester, string _Class, int units, string Subject)
	{
		InitializeComponent();
		this.Semester = Semester;
		this._Class = _Class;
		this.units = units;
		this.Subject = Subject;
	}

	private void UpdateUnitsProgress()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_OL_Report WHERE SemesterId='{Semester}' AND SubjectId='{Subject}' AND ClassId='{_Class}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			double result = (double.TryParse(row["ETA80"].ToString(), out result) ? result : 0.0);
			switch (units)
			{
			case 1:
				u1f = 1;
				u2f = 0;
				u3f = 0;
				u4f = 0;
				u5f = 0;
				u6f = 0;
				u7f = 0;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 2:
				u1f = 1;
				u2f = 1;
				u3f = 0;
				u4f = 0;
				u5f = 0;
				u6f = 0;
				u7f = 0;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 3:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 0;
				u5f = 0;
				u6f = 0;
				u7f = 0;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 4:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 0;
				u6f = 0;
				u7f = 0;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 5:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 1;
				u6f = 0;
				u7f = 0;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 6:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 1;
				u6f = 1;
				u7f = 0;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 7:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 1;
				u6f = 1;
				u7f = 1;
				u8f = 0;
				u9f = 0;
				u10f = 0;
				break;
			case 8:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 1;
				u6f = 1;
				u7f = 1;
				u8f = 1;
				u9f = 0;
				u10f = 0;
				break;
			case 9:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 1;
				u6f = 1;
				u7f = 1;
				u8f = 1;
				u9f = 1;
				u10f = 0;
				break;
			case 10:
				u1f = 1;
				u2f = 1;
				u3f = 1;
				u4f = 1;
				u5f = 1;
				u6f = 1;
				u7f = 1;
				u8f = 1;
				u9f = 1;
				u10f = 1;
				break;
			}
			double result2 = (double.TryParse(row["Score1"].ToString(), out result2) ? result2 : 0.0) * (double)u1f;
			double result3 = (double.TryParse(row["Score2"].ToString(), out result3) ? result3 : 0.0) * (double)u2f;
			double result4 = (double.TryParse(row["Score3"].ToString(), out result4) ? result4 : 0.0) * (double)u3f;
			double result5 = (double.TryParse(row["Score4"].ToString(), out result5) ? result5 : 0.0) * (double)u4f;
			double result6 = (double.TryParse(row["Score5"].ToString(), out result6) ? result6 : 0.0) * (double)u5f;
			double result7 = (double.TryParse(row["Score6"].ToString(), out result7) ? result7 : 0.0) * (double)u6f;
			double result8 = (double.TryParse(row["Score7"].ToString(), out result8) ? result8 : 0.0) * (double)u7f;
			double result9 = (double.TryParse(row["Score8"].ToString(), out result9) ? result9 : 0.0) * (double)u8f;
			double result10 = (double.TryParse(row["Score9"].ToString(), out result10) ? result10 : 0.0) * (double)u9f;
			double result11 = (double.TryParse(row["Score10"].ToString(), out result11) ? result11 : 0.0) * (double)u10f;
			double num = result2 + result3 + result4 + result5 + result6 + result7 + result8 + result9 + result10 + result11;
			double num2 = result2 / 20.0 * 100.0;
			double num3 = result3 / 20.0 * 100.0;
			double num4 = result4 / 20.0 * 100.0;
			double num5 = result5 / 20.0 * 100.0;
			double num6 = result6 / 20.0 * 100.0;
			double num7 = result7 / 20.0 * 100.0;
			double num8 = result8 / 20.0 * 100.0;
			double num9 = result9 / 20.0 * 100.0;
			double num10 = result10 / 20.0 * 100.0;
			double num11 = result11 / 20.0 * 100.0;
			double num12 = num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9 + num10 + num11;
			double value = result2 / 20.0 * 3.0;
			double num13 = Math.Round(value, 1);
			double value2 = result3 / 20.0 * 3.0;
			double num14 = Math.Round(value2, 1);
			double value3 = result4 / 20.0 * 3.0;
			double num15 = Math.Round(value3, 1);
			double value4 = result5 / 20.0 * 3.0;
			double num16 = Math.Round(value4, 1);
			double value5 = result6 / 20.0 * 3.0;
			double num17 = Math.Round(value5, 1);
			double value6 = result7 / 20.0 * 3.0;
			double num18 = Math.Round(value6, 1);
			double value7 = result8 / 20.0 * 3.0;
			double num19 = Math.Round(value7, 1);
			double value8 = result9 / 20.0 * 3.0;
			double num20 = Math.Round(value8, 1);
			double value9 = result10 / 20.0 * 3.0;
			double num21 = Math.Round(value9, 1);
			double value10 = result11 / 20.0 * 3.0;
			double num22 = Math.Round(value10, 1);
			double num23 = num13 + num14 + num15 + num16 + num17 + num18 + num19 + num20 + num21 + num22;
			double num24 = Math.Round(num23 / (double)units, 1);
			double num25 = Math.Round(num23 / (double)(units * 3) * 20.0, 1, MidpointRounding.AwayFromZero);
			double num26 = num / (double)units;
			double num27 = Math.Round(num26, 1, MidpointRounding.AwayFromZero);
			double value11 = num26 / 20.0 * 100.0;
			double num28 = Math.Round(value11, 1, MidpointRounding.AwayFromZero);
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_Scores_OL_Report SET U1=@U1,U2=@U2,U3=@U3,U4=@U4,U5=@U5,U6=@U6,U7=@U7,U8=@U8,U9=@U9,U10=@U10,Hund1=@Hund1,Hund2=@Hund2,Hund3=@Hund3,Hund4=@Hund4,Hund5=@Hund5,Hund6=@Hund6,Hund7=@Hund7,Hund8=@Hund8,Hund9=@Hund9,Hund10=@Hund10,Score1=@Score1,Score2=@Score2,Score3=@Score3,Score4=@Score4,Score5=@Score5,Score6=@Score6,Score7=@Score7,Score8=@Score8,Score9=@Score9,Score10=@Score10,OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,AvMark=@AvMark,TTLPoints=@TTLPoints,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@Score1", result2);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score2", result3);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score3", result4);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score4", result5);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score5", result6);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score6", result7);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score7", result8);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score8", result9);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score9", result10);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Score10", result11);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U1", num13);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U2", num14);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U3", num15);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U4", num16);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U5", num17);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U6", num18);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U7", num19);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U8", num20);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U9", num21);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@U10", num22);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund1", Math.Round(num2, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund2", Math.Round(num3, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund3", Math.Round(num4, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund4", Math.Round(num5, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund5", Math.Round(num6, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund6", Math.Round(num7, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund7", Math.Round(num8, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund8", Math.Round(num9, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund9", Math.Round(num10, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Hund10", Math.Round(num11, 0, MidpointRounding.AwayFromZero));
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num28);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num25);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num27);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", Subject);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", Semester);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num23);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num25 + result);
				sqlParameter.Direction = ParameterDirection.Input;
				string value12 = gradingScale.GetGradingScale(num24).Value;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num24);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value12);
				sqlParameter.Direction = ParameterDirection.Input;
				if (sqlCommand.ExecuteNonQuery() > 0)
				{
					sqlConnection.Close();
				}
			}
			k++;
			Thread.Sleep(10);
			backgroundWorker1.ReportProgress(k);
		}
	}

	private void UpdateUnits_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		x++;
		if (x == 3)
		{
			timer1.Enabled = false;
			x = 0;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		UpdateUnitsProgress();
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("All processes completed successfully.", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Close();
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
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
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(374, 44);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(374, 44);
		base.Controls.Add(this.progressBarControl1);
		this.DoubleBuffered = true;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "UpdateUnits";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Form1";
		base.Load += new System.EventHandler(UpdateUnits_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
