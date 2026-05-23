using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;

namespace I_Xtreme;

public class WaitFinancialReports : XtraForm
{
	private DateTime __StartDate = DateTime.Now;

	private DateTime __EndDate = DateTime.Now;

	private string __navPage = string.Empty;

	private string __AccountName = string.Empty;

	private string __AccountNo = string.Empty;

	private int __LedgerNo = 0;

	private DataTable dt;

	private int i = 0;

	public AccountReportParameters ReportParameters;

	private IContainer components = null;

	private Timer timer1;

	private ProgressPanel progressPanel1;

	private BackgroundWorker backgroundWorker1;

	private double[] OpeningBalances
	{
		get
		{
			int[] array = new int[2] { 3001, 3002 };
			List<double> list = new List<double>();
			double result = 0.0;
			for (int i = 0; i < array.Length; i++)
			{
				string selectCommandText = $"SELECT accNo, subAccountNo FROM tbl_generalAccounts_Sub WHERE accNo={array[i]}";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
				IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
				try
				{
					if (!enumerator.MoveNext())
					{
						continue;
					}
					DataRow dataRow = (DataRow)enumerator.Current;
					string selectCommandText2 = string.Format("SELECT (SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0))) AS Total FROM tbl_StatementOfAffairs WHERE _date <= '{0}' AND accNo='{1}'", __StartDate.ToShortDateString(), dataRow["subAccountNo"]);
					using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, DataConnection.ConnectToDatabase());
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "AccountStandingBalance");
					IEnumerator enumerator2 = dataSet2.Tables[0].Rows.GetEnumerator();
					try
					{
						if (enumerator2.MoveNext())
						{
							DataRow dataRow2 = (DataRow)enumerator2.Current;
							result = (double.TryParse(dataRow2["Total"].ToString(), out result) ? result : 0.0);
							list.Add(result);
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator2 as IDisposable;
						if (disposable2 != null)
						{
							disposable2.Dispose();
						}
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
			}
			return list.ToArray();
		}
	}

	public WaitFinancialReports(DateTime StartDate, DateTime EndDate, string navPage, string AccountName, string AccountNo, int LedgerNo)
	{
		InitializeComponent();
		progressPanel1.AutoHeight = true;
		__StartDate = StartDate;
		__EndDate = EndDate;
		__navPage = navPage;
		__AccountName = AccountName;
		__AccountNo = AccountNo;
		__LedgerNo = LedgerNo;
	}

	private void ProcessCommand()
	{
		if (__navPage == "pageIncome")
		{
			TotalIncome();
		}
		else if (__navPage == "pageExpenses")
		{
			ExpenseAnalysis();
		}
		else if (__navPage == "pageExpensesGrouped")
		{
			ExpenseAnalysis();
		}
		else if (__navPage == "pageIncomeStatement")
		{
			IncomeStatement();
		}
		else if (__navPage == "pageBalanceSheet")
		{
			MultipleColumnsBalanceSheet();
		}
		else if (__navPage == "pageCashbook")
		{
			Cashbook();
		}
		else if (__navPage == "pageAccountLedgers")
		{
			LoadLedgerDetails();
		}
		else if (__navPage == "pageTrialBalance")
		{
			TrialBalance();
		}
	}

	private void TotalIncome()
	{
		try
		{
			dt = new DataTable();
			string selectCommandText = string.Format("SELECT sa._date AS Date,sa.TrRef, ga.accName AS Category, gas.subAccountNo AS Ref#, sa.particulars AS Particulars,gas.SubAccoutName, sa.Narration,sa.Credit AS Amount FROM tbl_generalAccounts ga INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo INNER JOIN tbl_StatementOfAffairs sa ON gas.subAccountNo = sa.accNo WHERE (ga.categoryId = 1000) AND (sa._date >= '{0}' AND sa._date <= '{1}')", __StartDate.ToString("yyyy-MM-dd"), __EndDate.ToString("yyyy-MM-dd"));
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "TotalIncome");
			dt = dataSet.Tables[0];
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ExpenseAnalysis()
	{
		try
		{
			dt = new DataTable();
			string selectCommandText = string.Format("SELECT expenseSource,ExpenseName,DateOfExpense,ChequeNo,VoucherNo,Narration,PaymentMode, ExpenseValue FROM Expenses WHERE (DateOfExpense >='{0}' AND DateOfExpense <='{1}')", __StartDate.ToString("yyyy-MM-dd"), __EndDate.ToString("yyyy-MM-dd"));
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Expenses");
			dt = dataSet.Tables[0];
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void IncomeStatement()
	{
		try
		{
			dt = new DataTable();
			dt.Columns.Add("MajorGroup", typeof(string));
			dt.Columns.Add("SubAccountName", typeof(string));
			dt.Columns.Add("SubAccountNo", typeof(string));
			dt.Columns.Add("Debit", typeof(double));
			dt.Columns.Add("Credit", typeof(double));
			DataSet dataSet = new DataSet();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT TOP (100) PERCENT at.Category AS MajorGroup, at.accountName AS Category, ga.accNo AS MajorAccountNo, ga.accName AS MajorAccountName, gas.subAccountNo AS SubAccountNo, gas.SubAccoutName AS SubAccountName,at.SuperGroup FROM tbl_account_types at INNER JOIN  tbl_generalAccounts ga ON at.categoryId = ga.categoryId INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo WHERE (at.categoryId < 3000) ORDER BY Category", DataConnection.ConnectToDatabase()))
			{
				sqlDataAdapter.Fill(dataSet, "AccountTypes");
			}
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				string selectCommandText = string.Format("SELECT accNo, SUM(ISNULL(Debit, 0)) AS Debit, SUM(ISNULL(Credit, 0)) AS Credit FROM tbl_StatementOfAffairs WHERE (accNo = '{0}') AND (_date >= '{1}') AND (_date <= '{2}') GROUP BY accNo", row["SubAccountNo"], __StartDate.ToString("yyyy-MM-dd"), __EndDate.ToString("yyyy-MM-dd"));
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "AccountBalances");
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				foreach (DataRow row2 in dataSet2.Tables[0].Rows)
				{
					dt.Rows.Add(row["Category"].ToString(), row["SubAccountName"].ToString(), row["SubAccountNo"].ToString(), Convert.ToDouble(row2["Debit"].ToString()), Convert.ToDouble(row2["Credit"].ToString()));
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private double LoadTransactingAccountBalance(string accNo)
	{
		double result = 0.0;
		try
		{
			string selectCommandText = string.Format("SELECT (SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0))) AS Total FROM tbl_StatementOfAffairs WHERE _date < '{0}' AND accNo='{1}'", __StartDate.ToString("yyyy-M-d"), accNo);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = (double.TryParse(dataRow["Total"].ToString(), out result) ? result : 0.0);
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
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	private void MultipleColumnsBalanceSheet()
	{
		try
		{
			dt = new DataTable();
			dt.Columns.Add("MajorGroup", typeof(string));
			dt.Columns.Add("Category", typeof(string));
			dt.Columns.Add("MajorAccount", typeof(string));
			dt.Columns.Add("SubAccountName", typeof(string));
			dt.Columns.Add("SubAccountNo", typeof(string));
			dt.Columns.Add("OpenningBalance", typeof(double));
			dt.Columns.Add("AccountBalance", typeof(double));
			dt.Columns.Add("Total", typeof(double));
			DataSet dataSet = new DataSet();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT TOP (100) PERCENT at.Category AS MajorGroup, at.accountName AS Category, ga.accNo AS MajorAccountNo, ga.accName AS MajorAccountName, gas.subAccountNo AS SubAccountNo, gas.SubAccoutName AS SubAccountName,at.SuperGroup FROM tbl_account_types at INNER JOIN  tbl_generalAccounts ga ON at.categoryId = ga.categoryId INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo WHERE (at.categoryId > 2000) ORDER BY Category", DataConnection.ConnectToDatabase()))
			{
				sqlDataAdapter.Fill(dataSet, "AccountTypes");
			}
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				string selectCommandText = string.Format("SELECT accNo, (SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0))) AS AccountBalance, _date FROM tbl_StatementOfAffairs WHERE (accNo = '{0}') AND ((_date >= '{1}') AND (_date <= '{2}')) GROUP BY accNo, _date", row["SubAccountNo"], __StartDate.ToString("yyyy-M-d"), __EndDate.ToString("yyyy-M-d"));
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "AccountBalances");
				double num = 0.0;
				double num2 = 0.0;
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					num2 = LoadTransactingAccountBalance(row["SubAccountNo"].ToString());
					dt.Rows.Add(row["MajorGroup"].ToString(), row["Category"].ToString(), row["MajorAccountName"].ToString(), row["SubAccountName"].ToString(), row["SubAccountNo"].ToString(), num2, 0, num2);
					continue;
				}
				foreach (DataRow row2 in dataSet2.Tables[0].Rows)
				{
					num = Convert.ToDouble(row2["AccountBalance"].ToString());
					num2 = LoadTransactingAccountBalance(row2["accNo"].ToString());
					dt.Rows.Add(row["MajorGroup"].ToString(), row["Category"].ToString(), row["MajorAccountName"].ToString(), row["SubAccountName"].ToString(), row["SubAccountNo"].ToString(), num2, num, num2 + num);
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void TrialBalance()
	{
		try
		{
			dt = new DataTable();
			dt.Columns.Add("AccNo", typeof(string));
			dt.Columns.Add("AccountTitle", typeof(string));
			dt.Columns.Add("DEBIT", typeof(double));
			dt.Columns.Add("CREDIT", typeof(double));
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT at.accountName AS accGroup, ga.accName, gas.subAccountNo AS accNo,gas.SubAccoutName AS AccountName FROM tbl_generalAccounts ga INNER JOIN tbl_account_types at ON ga.categoryId = at.categoryId INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo ORDER BY at.SuperGroup", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "TrailBalanceAccounts");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				if (row["accGroup"].ToString() == "2.EXPENSES" || row["accGroup"].ToString() == "4.CURRENT ASSETS" || row["accGroup"].ToString() == "3.FIXED ASSETS")
				{
					empty = string.Format("SELECT accNo, SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0)) AS DEBIT FROM tbl_StatementOfAffairs WHERE accNo='{0}' AND (_date >='{1}' AND _date <= '{2}') GROUP BY accNo", row["accNo"], __StartDate.ToString("yyyy-M-d"), __EndDate.ToString("yyyy-M-d"));
					empty2 = "Debit";
				}
				else
				{
					empty = string.Format("SELECT accNo, SUM(ISNULL(Credit,0))-SUM(ISNULL(Debit,0)) AS CREDIT FROM tbl_StatementOfAffairs WHERE accNo='{0}' AND (_date >='{1}' AND _date <= '{2}') GROUP BY accNo", row["accNo"], __StartDate.ToString("yyyy-M-d"), __EndDate.ToString("yyyy-M-d"));
					empty2 = "Credit";
				}
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "TrailBalanceBalance");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				foreach (DataRow row2 in dataTable2.Rows)
				{
					double num = 0.0;
					double num2 = 0.0;
					if (empty2 == "Debit")
					{
						num = Convert.ToDouble(row2["DEBIT"].ToString());
						num2 = 0.0;
					}
					else
					{
						num = 0.0;
						num2 = Convert.ToDouble(row2["CREDIT"].ToString());
					}
					dt.Rows.Add(row2["accNo"].ToString(), row["AccountName"].ToString(), num, num2);
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void Cashbook()
	{
		dt = new DataTable();
		dt.Columns.Add("Date", typeof(DateTime));
		dt.Columns.Add("Particulars", typeof(string));
		dt.Columns.Add("TrxRef", typeof(string));
		dt.Columns.Add("AccountRef", typeof(string));
		dt.Columns.Add("dCash", typeof(double));
		dt.Columns.Add("dBank", typeof(double));
		dt.Columns.Add("cCash", typeof(double));
		dt.Columns.Add("cBank", typeof(double));
		dt.Rows.Add(__StartDate, "Opening Balance", string.Empty, string.Empty, OpeningBalances[1], OpeningBalances[0], DBNull.Value, DBNull.Value);
		string selectCommandText = string.Format("SELECT  ga.accNo, ga.accName, gas.subAccountNo, gas.SubAccoutName, sa.particulars, sa._date, sa.Debit, sa.Credit,sa.TrRef, sa.Narration FROM tbl_generalAccounts ga INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo INNER JOIN tbl_StatementOfAffairs sa ON gas.subAccountNo = sa.accNo WHERE sa.Debit > 0 AND ((ga.accNo = 3001) OR (ga.accNo = 3002)) AND (sa._date>='{0}' AND sa._date<='{1}') ", __StartDate.AddDays(1.0).ToString("yyyy-M-d"), __EndDate.ToString("yyyy-M-d"));
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "d");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				if (row["accName"].ToString() == "Bank Accounts")
				{
					dt.Rows.Add(Convert.ToDateTime(row["_date"]), row["particulars"], row["TrRef"], row["SubAccoutName"], DBNull.Value, Convert.ToDouble(row["Debit"]), DBNull.Value, DBNull.Value);
				}
				else if (row["accName"].ToString() == "Cash")
				{
					dt.Rows.Add(Convert.ToDateTime(row["_date"]), row["particulars"], row["TrRef"], row["SubAccoutName"], Convert.ToDouble(row["Debit"]), DBNull.Value, DBNull.Value, DBNull.Value);
				}
			}
		}
		string selectCommandText2 = $"SELECT  ga.accNo, ga.accName, gas.subAccountNo, gas.SubAccoutName, sa.particulars, sa._date, sa.Debit, sa.Credit, sa.TrRef, sa.Narration FROM tbl_generalAccounts ga INNER JOIN tbl_generalAccounts_Sub gas ON ga.accNo = gas.accNo INNER JOIN tbl_StatementOfAffairs sa ON gas.subAccountNo = sa.accNo WHERE sa.Credit > 0 AND ((ga.accNo = 3001) OR (ga.accNo = 3002)) AND (sa._date>='{__StartDate.AddDays(1.0).ToShortDateString()}' AND sa._date<='{__EndDate.ToShortDateString()}') ";
		using (SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "c");
			foreach (DataRow row2 in dataSet2.Tables[0].Rows)
			{
				if (row2["accName"].ToString() == "Bank Accounts")
				{
					dt.Rows.Add(Convert.ToDateTime(row2["_date"]), row2["particulars"], row2["TrRef"], row2["SubAccoutName"], DBNull.Value, DBNull.Value, DBNull.Value, Convert.ToDouble(row2["Credit"]));
				}
				else if (row2["accName"].ToString() == "Cash")
				{
					dt.Rows.Add(Convert.ToDateTime(row2["_date"]), row2["particulars"], row2["TrRef"], row2["SubAccoutName"], DBNull.Value, DBNull.Value, Convert.ToDouble(row2["Credit"]), DBNull.Value);
				}
			}
		}
		dt.Rows.Add(__EndDate, "Balance C/D", string.Empty, string.Empty, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value);
	}

	private double LoadTransactingAccountBalanceAssets(string accNo)
	{
		double result = 0.0;
		try
		{
			string selectCommandText = $"SELECT (SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0))) AS Total FROM tbl_StatementOfAffairs WHERE _date <= '{__StartDate.ToShortDateString()}' AND accNo='{accNo}'";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = (double.TryParse(dataRow["Total"].ToString(), out result) ? result : 0.0);
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
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	private double LoadTransactingAccountBalanceLiabilities(string accNo)
	{
		double result = 0.0;
		try
		{
			string selectCommandText = $"SELECT (SUM(ISNULL(Credit,0))-SUM(ISNULL(Debit,0))) AS Total FROM tbl_StatementOfAffairs WHERE _date <= '{__StartDate.ToShortDateString()}' AND accNo='{accNo}'";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = (double.TryParse(dataRow["Total"].ToString(), out result) ? result : 0.0);
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
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	private void LoadLedgerDetails()
	{
		try
		{
			string empty = string.Empty;
			double num = 0.0;
			dt = new DataTable();
			dt.Columns.Add("Date", typeof(DateTime));
			dt.Columns.Add("Particulars", typeof(string));
			dt.Columns.Add("Dr", typeof(double));
			dt.Columns.Add("Cr", typeof(double));
			dt.Columns.Add("Amount", typeof(double));
			dt.Columns.Add("TrRef", typeof(string));
			if (Convert.ToInt32(__LedgerNo) >= 5000)
			{
				num = LoadTransactingAccountBalanceLiabilities(__AccountNo);
				dt.Rows.Add(DBNull.Value, "Opening Balance " + __StartDate.ToString("dd MMM yyyy"), 0, num, num);
				empty = string.Format("SELECT ref,_date AS Date, particulars AS Particulars,TrRef,ISNULL(Debit,0) AS Dr,ISNULL(Credit,0) AS Cr, (ISNULL(Credit,0)-ISNULL(Debit,0)) AS Amount FROM tbl_StatementOfAffairs WHERE (_date >= '{0}' AND _date <= '{1}') AND accNo='{2}' ORDER BY _date", __StartDate.AddDays(1.0).ToString("yyyy-M-d"), __EndDate.ToString("yyyy-M-d"), __AccountNo);
			}
			else
			{
				num = LoadTransactingAccountBalanceAssets(__AccountNo);
				dt.Rows.Add(DBNull.Value, "Opening Balance " + __StartDate.ToString("dd MMM yyyy"), num, 0, num);
				empty = string.Format("SELECT ref,_date AS Date, particulars AS Particulars,TrRef,ISNULL(Debit,0) AS Dr,ISNULL(Credit,0) AS Cr, (ISNULL(Debit,0)-ISNULL(Credit,0)) AS Amount FROM tbl_StatementOfAffairs WHERE (_date >= '{0}' AND _date <= '{1}') AND accNo='{2}' ORDER BY _date", __StartDate.AddDays(1.0).ToString("yyyy-M-d"), __EndDate.ToString("yyyy-M-d"), __AccountNo);
			}
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "accountsGrouped");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				dt.Rows.Add(Convert.ToDateTime(row["Date"]), row["Particulars"].ToString(), Convert.ToDouble(row["Dr"].ToString()), Convert.ToDouble(row["Cr"].ToString()), Convert.ToDouble(row["Amount"].ToString()), row["TrRef"].ToString());
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		Close();
	}

	private void WaitFinancialReports_FormClosing(object sender, FormClosingEventArgs e)
	{
		ReportParameters(__StartDate, __EndDate, __navPage, __AccountName, dt, __LedgerNo);
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
		base.Name = "WaitFinancialReports";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Form1";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(WaitFinancialReports_FormClosing);
		base.Load += new System.EventHandler(WaitFinancialReports_Load);
		base.ResumeLayout(false);
	}
}
