using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace I_Xtreme;

public class progressGatePass : XtraForm
{
	private int i;

	private int j;

	private readonly string date = DateTime.Now.ToOADate().ToString();

	private string _class = string.Empty;

	private string _stream = string.Empty;

	public string _currentUser = string.Empty;

	public string _semester = string.Empty;

	private double feesBalance = 0.0;

	private string capDate = DateTime.Now.ToOADate().ToString();

	private IContainer components = null;

	private Timer timer1;

	private ProgressBarControl progressBarControl1;

	public progressGatePass(double StudentBalance, string ClassId, string StreamId)
	{
		InitializeComponent();
		feesBalance = StudentBalance;
		_class = ClassId;
		_stream = StreamId;
	}

	private double FeesBalance(string StudentNo)
	{
		double result = 0.0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SUM(Debit) AS Debit, SUM(Credit) AS Credit, SUM(Debit) - SUM(Credit) AS FeesBalance FROM   FeesPayment GROUP BY StudentNumber HAVING(StudentNumber = '{StudentNo}')", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "FeesBalance");
		IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				result = (double.TryParse(dataRow["FeesBalance"].ToString(), out result) ? result : 0.0);
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	private void CreateGatePass()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT StudentNumber,fullName,StudyStatus,Sex, StreamId,Guardian, cashOnAccount,Picture FROM tbl_Stud WHERE ClassId='{_class}' AND StreamId = '{_stream}' AND cashOnAccount >= {feesBalance}", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "FeesGatePass");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		progressBarControl1.Properties.Minimum = 0;
		progressBarControl1.Properties.Maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			j++;
			progressBarControl1.Position = j;
			Application.DoEvents();
			NumberToWordsConverter numberToWordsConverter = new NumberToWordsConverter();
			double num = FeesBalance(row["StudentNumber"].ToString());
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_GatePass (StudentNumber,Name,Class,Stream,DB,Guardian,CreatedBy,SemesterId,CreateDate,PassType,pic,Sex,amount,amountInWords,CaptureDate)VALUES(@StudentNumber,@Name,@Class,@Stream,@DB,@Guardian,@CreatedBy,@SemesterId,@CreateDate,@PassType,@pic,@Sex,@amount,@amountInWords,@CaptureDate)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = row["StudentNumber"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50);
				sqlParameter.Value = row["fullName"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Class", SqlDbType.VarChar, 3);
				sqlParameter.Value = _class;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Stream", SqlDbType.VarChar, 50);
				sqlParameter.Value = _stream;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@DB", SqlDbType.VarChar, 1);
				sqlParameter.Value = row["StudyStatus"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
				sqlParameter.Value = row["Guardian"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 30);
				sqlParameter.Value = CurrentUser.GetSystemUser();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 30);
				sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CreateDate", SqlDbType.DateTime);
				sqlParameter.Value = DateTime.Now.ToLongDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PassType", SqlDbType.VarChar, 50);
				sqlParameter.Value = "Student Fees GatePass";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Pic", SqlDbType.Image);
				sqlParameter.Value = row["Picture"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = row["Sex"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@amount", SqlDbType.Money);
				sqlParameter.Value = num;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@amountInWords", SqlDbType.VarChar);
				sqlParameter.Value = numberToWordsConverter.NumberToWords((long)num).ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 50);
				sqlParameter.Value = capDate;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			sqlConnection.Close();
		}
	}

	private void CleanGatePassStorage()
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_GatePass",
				CommandType = CommandType.Text
			};
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void progressGatePass_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 5)
		{
			timer1.Enabled = false;
			CleanGatePassStorage();
			CreateGatePass();
			Close();
			using gatePass_Multiple gatePass_Multiple2 = new gatePass_Multiple();
			gatePass_Multiple2.CapDate.Value = date;
			gatePass_Multiple2.CapDate.Visible = false;
			ReportPrintTool reportPrintTool = new ReportPrintTool(gatePass_Multiple2);
			reportPrintTool.ShowRibbonPreviewDialog();
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
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Properties.Step = 1;
		this.progressBarControl1.Size = new System.Drawing.Size(364, 33);
		this.progressBarControl1.TabIndex = 6;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(364, 33);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "progressGatePass";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Please wait...";
		base.Load += new System.EventHandler(progressGatePass_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
