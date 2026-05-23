using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;

namespace I_Xtreme;

public class WaitPayroll : XtraForm
{
	private string __navPage = string.Empty;

	private string __PayrollPeriod = string.Empty;

	private int i = 0;

	private DataTable dt;

	public PayrollParameters _PayrollParameters;

	private IContainer components = null;

	private Timer timer1;

	private ProgressPanel progressPanel1;

	private BackgroundWorker backgroundWorker1;

	public WaitPayroll(string navPage, string PayrollPeriod)
	{
		InitializeComponent();
		progressPanel1.AutoHeight = true;
		__navPage = navPage;
		__PayrollPeriod = PayrollPeriod;
	}

	private void ProcessCommand()
	{
		if (__navPage == "pageReviewPayroll")
		{
			LoadPayroll();
		}
	}

	private void LoadPayroll()
	{
		try
		{
			dt = new DataTable();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT s.StaffId, s.StaffName, s.LedgerNo, s.Responsibility, s.Qualification, s.ContactNumber, p.Month, p.Year, p.Category, p.Particulars, p.Requirements, p.PayrollPeriod FROM   Staff s INNER JOIN tbl_EmployeePaySlip p ON s.StaffId = p.EmployeeNo WHERE(p.PayrollPeriod = '{__PayrollPeriod}')", DataConnection.ConnectToDatabase());
			sqlDataAdapter.Fill(dt);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void WaitFinancialReports_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 5)
		{
			timer1.Enabled = false;
			i = 0;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		ProcessCommand();
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void WaitFinancialReports_FormClosing(object sender, FormClosingEventArgs e)
	{
		_PayrollParameters(__navPage, __PayrollPeriod, dt);
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
		this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.progressPanel1.Appearance.Options.UseBackColor = true;
		this.progressPanel1.BarAnimationElementThickness = 2;
		this.progressPanel1.Location = new System.Drawing.Point(7, 11);
		this.progressPanel1.Name = "progressPanel1";
		this.progressPanel1.Size = new System.Drawing.Size(233, 49);
		this.progressPanel1.TabIndex = 0;
		this.progressPanel1.Text = "progressPanel1";
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		base.ClientSize = new System.Drawing.Size(246, 73);
		base.ControlBox = false;
		base.Controls.Add(this.progressPanel1);
		this.DoubleBuffered = true;
		base.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "WaitBudget";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Form1";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(WaitFinancialReports_FormClosing);
		base.Load += new System.EventHandler(WaitFinancialReports_Load);
		base.ResumeLayout(false);
	}
}
