using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Accounts;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class PayrollProgress : XtraForm
{
	private string currentTask = string.Empty;

	private int maximum = 0;

	private string month = string.Empty;

	private int year = 0;

	private int i = 0;

	private int k = 0;

	private string _Period = string.Empty;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	public PayrollProgress(string _month, int _year)
	{
		InitializeComponent();
		year = _year;
		month = _month;
		_Period = $"{_month}-{_year}";
	}

	private void CreatePayroll()
	{
		CreatePayrollPayments();
		CreatePayrollDeductions();
	}

	private void CreatePayrollPayments()
	{
		k = 0;
		maximum = 0;
		string text = DataConnection.ConnectToDatabase();
		SqlConnection sqlConnection = new SqlConnection(text);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Staff", text);
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT * FROM tbl_PayrollMonthlyAllowances WHERE StaffID='{0}' AND IsActive=1", row["StaffId"].ToString()), text);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			foreach (DataRow row2 in dataTable2.Rows)
			{
				if (!Payroll.PayrollItemExists(row["StaffId"].ToString(), row2["Particulars"].ToString(), _Period))
				{
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_EmployeePaySlip (EmployeeNo,Month,Year,Category,Particulars,Requirements,PayrollPeriod) VALUES (@EmployeeNo,@Month,@Year,@Category,@Particulars,@Requirements,@PayrollPeriod)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@EmployeeNo", SqlDbType.VarChar, 50);
					sqlParameter.Value = row["StaffId"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Month", SqlDbType.VarChar, 11);
					sqlParameter.Value = month;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Year", SqlDbType.Int);
					sqlParameter.Value = year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 15);
					sqlParameter.Value = " PAYMENTS";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = row2["Particulars"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					double result = (double.TryParse(row2["Rate"].ToString(), out result) ? result : 0.0);
					sqlParameter = sqlCommand.Parameters.Add("@Requirements", SqlDbType.Money);
					sqlParameter.Value = result;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@PayrollPeriod", SqlDbType.VarChar, 50);
					sqlParameter.Value = _Period;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
			}
			k++;
			Thread.Sleep(10);
			backgroundWorker1.ReportProgress(k);
		}
	}

	private void CreatePayrollDeductions()
	{
		k = 0;
		maximum = 0;
		string text = DataConnection.ConnectToDatabase();
		SqlConnection sqlConnection = new SqlConnection(text);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Staff", text);
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		k = 0;
		maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT * FROM tbl_PayrollDeductions WHERE StaffID='{0}'", row["StaffId"].ToString()), text);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			foreach (DataRow row2 in dataTable2.Rows)
			{
				if (!Payroll.PayrollItemExists(row["StaffId"].ToString(), row2["Item"].ToString(), _Period))
				{
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_EmployeePaySlip (EmployeeNo,Month,Year,Category,Particulars,Requirements,PayrollPeriod) VALUES (@EmployeeNo,@Month,@Year,@Category,@Particulars,@Requirements,@PayrollPeriod)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@EmployeeNo", SqlDbType.VarChar, 50);
					sqlParameter.Value = row["StaffId"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Month", SqlDbType.VarChar, 11);
					sqlParameter.Value = month;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Year", SqlDbType.Int);
					sqlParameter.Value = year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 15);
					sqlParameter.Value = "DEDUCTIONS";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = row2["Item"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					double result = (double.TryParse(row2["Rate"].ToString(), out result) ? result : 0.0);
					sqlParameter = sqlCommand.Parameters.Add("@Requirements", SqlDbType.Money);
					sqlParameter.Value = result * -1.0;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@PayrollPeriod", SqlDbType.VarChar, 50);
					sqlParameter.Value = _Period;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
			}
			k++;
			Thread.Sleep(10);
			backgroundWorker1.ReportProgress(k);
		}
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
		Text = currentTask;
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		CreatePayroll();
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Payroll created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			timer1.Enabled = false;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void PayrollProgress_Load(object sender, EventArgs e)
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
		this.progressBarControl1.Size = new System.Drawing.Size(546, 73);
		this.progressBarControl1.TabIndex = 0;
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(546, 73);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "PayrollProgress";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Working. Please wait...";
		base.Load += new System.EventHandler(PayrollProgress_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
