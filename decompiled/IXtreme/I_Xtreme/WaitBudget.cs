using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;

namespace I_Xtreme;

public class WaitBudget : XtraForm
{
	private string __navPage = string.Empty;

	private string __BudgetType = string.Empty;

	private string __BudgetPeriod = string.Empty;

	private int i = 0;

	private DataTable dt;

	public BudgetParameters BudgetParameters;

	private IContainer components = null;

	private Timer timer1;

	private ProgressPanel progressPanel1;

	private BackgroundWorker backgroundWorker1;

	public WaitBudget(string navPage, string BudgetType, string BudgetPeriod)
	{
		InitializeComponent();
		progressPanel1.AutoHeight = true;
		__navPage = navPage;
		__BudgetType = BudgetType;
		__BudgetPeriod = BudgetPeriod;
	}

	private void ProcessCommand()
	{
		if (__navPage == "pageBudgetCreate")
		{
			LoadSemesterBudget();
		}
		else if (__navPage == "pageBudgetCompare")
		{
			CompareBudget();
		}
	}

	private void LoadSemesterBudget()
	{
		try
		{
			dt = new DataTable();
			string selectCommandText = string.Empty;
			if (__BudgetType == "Termly")
			{
				selectCommandText = $"SELECT gas.subAccountNo, gas.SubAccoutName AS SubVote, b.semester, b.year, b.qty, b.units, b.rate, (b.rate * b.qty) AS Amount, ga.accName AS Vote FROM tbl_generalAccounts_Sub gas INNER JOIN tbl_budget b ON gas.subAccountNo = b.accNo INNER JOIN tbl_generalAccounts ga ON gas.accNo = ga.accNo WHERE b.semester='{__BudgetPeriod}'";
			}
			else if (__BudgetType == "Annual")
			{
				selectCommandText = $"SELECT gas.subAccountNo, gas.SubAccoutName AS SubVote, b.year, b.qty, b.units, b.rate, (b.rate * b.qty) AS Amount, ga.accName AS Vote FROM tbl_generalAccounts_Sub gas INNER JOIN tbl_budget b ON gas.subAccountNo = b.accNo INNER JOIN tbl_generalAccounts ga ON gas.accNo = ga.accNo WHERE b.year='{__BudgetPeriod}'";
			}
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Budget");
			dt = dataSet.Tables[0];
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CompareBudget()
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("accName", typeof(string));
			dataTable.Columns.Add("subAccountNo", typeof(string));
			dataTable.Columns.Add("SubAccoutName", typeof(string));
			dataTable.Columns.Add("Budget", typeof(double));
			dataTable.Columns.Add("Actual", typeof(double));
			dataTable.Columns.Add("Variance", typeof(double));
			if (__BudgetType == "Termly")
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ga.accName, gas.subAccountNo, gas.SubAccoutName, ga.categoryId, tbl_budget.rate, tbl_budget.semester FROM   dbo.tbl_generalAccounts ga INNER JOIN  tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo INNER JOIN tbl_budget ON gas.subAccountNo = tbl_budget.accNo WHERE (ga.categoryId = 2000) AND (tbl_budget.semester = '{__BudgetPeriod}')", DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "budget");
				double num = 0.0;
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(string.Format("SELECT accNo, SemesterId, SUM(Debit) AS Actual FROM   tbl_StatementOfAffairs GROUP BY accNo, SemesterId HAVING (SemesterId = '{0}') AND (accNo = '{1}')", row["semester"].ToString(), row["subAccountNo"].ToString()), DataConnection.ConnectToDatabase());
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "Expenses");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						{
							IEnumerator enumerator2 = dataSet2.Tables[0].Rows.GetEnumerator();
							try
							{
								if (enumerator2.MoveNext())
								{
									DataRow dataRow2 = (DataRow)enumerator2.Current;
									num = Convert.ToDouble(row["rate"].ToString()) - Convert.ToDouble(dataRow2["Actual"].ToString());
									dataTable.Rows.Add(row["accName"].ToString(), row["subAccountNo"].ToString(), row["SubAccoutName"].ToString(), Convert.ToDouble(row["rate"].ToString()), Convert.ToDouble(dataRow2["Actual"].ToString()), num);
								}
							}
							finally
							{
								IDisposable disposable = enumerator2 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
					}
					else if (dataSet2.Tables[0].Rows.Count == 0)
					{
						num = Convert.ToDouble(row["rate"].ToString());
						dataTable.Rows.Add(row["accName"].ToString(), row["subAccountNo"].ToString(), row["SubAccoutName"].ToString(), Convert.ToDouble(row["rate"].ToString()), 0, num);
					}
				}
				dt = dataTable;
			}
			else
			{
				if (!(__BudgetType == "Annual"))
				{
					return;
				}
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter($"SELECT ga.accName, gas.subAccountNo, gas.SubAccoutName, ga.categoryId, tbl_budget.rate, tbl_budget.semester,dbo.tbl_budget.year FROM   tbl_generalAccounts ga INNER JOIN  tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo INNER JOIN tbl_budget ON gas.subAccountNo = tbl_budget.accNo WHERE (ga.categoryId = 2000) AND (tbl_budget.year = '{__BudgetPeriod}')", DataConnection.ConnectToDatabase());
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "budget");
				double num2 = 0.0;
				foreach (DataRow row2 in dataSet3.Tables[0].Rows)
				{
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(string.Format("SELECT accNo, year, SUM(Debit) AS Actual FROM   tbl_StatementOfAffairs WHERE (year = '{0}') AND (accNo = '{1}') GROUP BY accNo,year", row2["year"].ToString(), row2["subAccountNo"].ToString()), DataConnection.ConnectToDatabase());
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "Expenses");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						{
							IEnumerator enumerator4 = dataSet4.Tables[0].Rows.GetEnumerator();
							try
							{
								if (enumerator4.MoveNext())
								{
									DataRow dataRow4 = (DataRow)enumerator4.Current;
									num2 = Convert.ToDouble(row2["rate"].ToString()) - Convert.ToDouble(dataRow4["Actual"].ToString());
									dataTable.Rows.Add(row2["accName"].ToString(), row2["subAccountNo"].ToString(), row2["SubAccoutName"].ToString(), Convert.ToDouble(row2["rate"].ToString()), Convert.ToDouble(dataRow4["Actual"].ToString()), num2);
								}
							}
							finally
							{
								IDisposable disposable2 = enumerator4 as IDisposable;
								if (disposable2 != null)
								{
									disposable2.Dispose();
								}
							}
						}
					}
					else if (dataSet4.Tables[0].Rows.Count == 0)
					{
						num2 = Convert.ToDouble(row2["rate"].ToString());
						dataTable.Rows.Add(row2["accName"].ToString(), row2["subAccountNo"].ToString(), row2["SubAccoutName"].ToString(), Convert.ToDouble(row2["rate"].ToString()), 0, num2);
					}
				}
				dt = dataTable;
			}
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
		BudgetParameters(__navPage, __BudgetType, __BudgetPeriod, dt);
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
