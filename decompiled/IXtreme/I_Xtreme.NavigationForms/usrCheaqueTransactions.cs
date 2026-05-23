using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrCheaqueTransactions : XtraUserControl
{
	private DataTable _dt_Inc;

	private DataTable _dt_TA;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton btnContinue;

	private DateEdit dtDate;

	private LayoutControlItem layoutDate;

	private LayoutControlItem layoutButton;

	private TextEdit txtdChequeNo;

	private TextEdit txtdAmount;

	private LayoutControlGroup grBankingDetails;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutChequeNo;

	private MyGridControl gridBankLedgers;

	private MyGridView gridView3;

	private LayoutControlItem layoutBankLedger;

	private TextEdit txtStandingBalance;

	private ComboBoxEdit cboAccount;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem8;

	private TextEdit txtAccNo;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlGroup layoutAccount;

	private TextEdit txtAccGroup;

	private LayoutControlItem layoutControlItem9;

	private EmptySpaceItem emptySpaceItem1;

	private LabelControl lblActions;

	private LayoutControlItem lblActionssss;

	private GridColumn gridColDate;

	private GridColumn gridColParticulars;

	private GridColumn gridColDr;

	private GridColumn gridColCr;

	private GridColumn gridColBal;

	private GridColumn gridColumn1;

	public usrCheaqueTransactions()
	{
		InitializeComponent();
		LoadTransactingAccount();
		PrintableControl.SavePrintableControl(gridBankLedgers);
		PrintableControl.SavePrintableControl(gridView3);
		ActiveFormSelected.SetActiveForm(string.Empty);
	}

	private void InitializeTransaction()
	{
		if (BankPayments.BankingTransactionType == BankPayments.BankingTransaction.Deposit.ToString())
		{
			layoutAccount.Visibility = LayoutVisibility.Always;
			layoutDate.Visibility = LayoutVisibility.Always;
			layoutButton.Visibility = LayoutVisibility.Always;
			LoadIncomeAccounts();
		}
		else if (BankPayments.BankingTransactionType == BankPayments.BankingTransaction.Withdraw.ToString())
		{
			layoutAccount.Visibility = LayoutVisibility.Always;
			layoutDate.Visibility = LayoutVisibility.Always;
			layoutButton.Visibility = LayoutVisibility.Always;
		}
		else if (BankPayments.BankingTransactionType == BankPayments.BankingTransaction.CashTransfer.ToString())
		{
			grBankingDetails.Visibility = LayoutVisibility.Never;
			layoutAccount.Visibility = LayoutVisibility.Never;
			layoutDate.Visibility = LayoutVisibility.Always;
			layoutButton.Visibility = LayoutVisibility.Always;
			grBankingDetails.Text = "Source Bank";
		}
		else
		{
			grBankingDetails.Visibility = LayoutVisibility.Never;
			layoutAccount.Visibility = LayoutVisibility.Never;
			layoutDate.Visibility = LayoutVisibility.Never;
			layoutButton.Visibility = LayoutVisibility.Never;
		}
	}

	private void rdTType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (txtAccNo.Text == "3001")
		{
			layoutChequeNo.Visibility = LayoutVisibility.Never;
			grBankingDetails.Text = "Cash Transactions";
		}
		else if (txtAccNo.Text == "3002")
		{
			txtdChequeNo.Properties.NullText = "Cheaque";
			txtdChequeNo.Properties.NullValuePrompt = "Cheaque";
			grBankingDetails.Text = "Cheque Transactions";
		}
		else if (txtAccNo.Text == "3003")
		{
			txtdChequeNo.Properties.NullText = "Mobile No";
			txtdChequeNo.Properties.NullValuePrompt = "Mobile No";
			grBankingDetails.Text = "Mobile-Money Transactions";
		}
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "No")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void usrCheaqueTransactions_Load(object sender, EventArgs e)
	{
		InitializeTransaction();
		if (BankPayments.BankingTransactionType == "Deposit")
		{
			lblActions.Text = "Cash Deposit";
			layoutChequeNo.Visibility = LayoutVisibility.Never;
		}
		else if (BankPayments.BankingTransactionType == "Withdraw")
		{
			lblActions.Text = "Cash Withdraw";
			layoutChequeNo.Visibility = LayoutVisibility.Always;
		}
		else if (BankPayments.BankingTransactionType == "CashTransfer")
		{
			lblActions.Text = "Cash Transfer";
			layoutChequeNo.Visibility = LayoutVisibility.Never;
		}
	}

	private void btnContinue_Click(object sender, EventArgs e)
	{
		if (BankPayments.BankingTransactionType == BankPayments.BankingTransaction.Deposit.ToString())
		{
			if (!string.IsNullOrEmpty(txtdAmount.Text))
			{
				if (dtDate.EditValue != null)
				{
					using (DepositSourceDetails depositSourceDetails = new DepositSourceDetails())
					{
						depositSourceDetails.txtAmount.Text = Convert.ToDouble(txtdAmount.Text).ToString("#,#.0");
						depositSourceDetails.dtDate = dtDate.DateTime;
						depositSourceDetails._AccountNo = txtAccNo.Text;
						if (depositSourceDetails.ShowDialog() == DialogResult.OK)
						{
							LoadAccountBalanceDetails(txtAccNo.Text);
							txtStandingBalance.Text = LoadTransactingAccountBalance(txtAccNo.Text).ToString("#,#.0");
							dtDate.Text = string.Empty;
							txtdAmount.Text = string.Empty;
							txtdChequeNo.Text = string.Empty;
						}
						return;
					}
				}
				XtraMessageBox.Show("Please select date.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				XtraMessageBox.Show("Amount cannot be blank. Please enter the amount you wish to withdraw.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			if (!(BankPayments.BankingTransactionType == BankPayments.BankingTransaction.Withdraw.ToString()))
			{
				return;
			}
			if (txtAccGroup.Text == "Cash")
			{
				XtraMessageBox.Show("Withdrawing from Cash Account is not a valid action.\nYou can only withdraw funds from Bank or Mobile-Money Account", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (!string.IsNullOrEmpty(txtdAmount.Text))
			{
				if (!string.IsNullOrEmpty(txtdChequeNo.Text))
				{
					if (dtDate.EditValue != null)
					{
						double result = (double.TryParse(txtdAmount.Text, out result) ? result : 0.0);
						double num = Convert.ToDouble(txtStandingBalance.Text);
						if (result <= num)
						{
							TransferTarget transferTarget = new TransferTarget();
							transferTarget.amount = Convert.ToDouble(txtdAmount.Text);
							transferTarget.cheaqueNo = txtdChequeNo.Text;
							transferTarget._dtDate = dtDate.DateTime;
							transferTarget.bankName = cboAccount.SelectedItem.ToString();
							transferTarget.bankAccountNo = txtAccNo.Text;
							DialogResult dialogResult = transferTarget.ShowDialog();
							if (dialogResult == DialogResult.OK)
							{
								LoadAccountBalanceDetails(txtAccNo.Text);
								txtStandingBalance.Text = LoadTransactingAccountBalance(txtAccNo.Text).ToString("#,#.0");
								dtDate.Text = string.Empty;
								txtdAmount.Text = string.Empty;
								txtdChequeNo.Text = string.Empty;
							}
						}
						else
						{
							XtraMessageBox.Show("You cannot withdraw amount greater than the account standing balance", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						XtraMessageBox.Show("Please select date.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else
				{
					XtraMessageBox.Show("Please enter Cheaque or Mobile No.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				XtraMessageBox.Show("Amount cannot be blank. Please enter the amount you wish to withdraw.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private double LoadTransactingAccountBalance(string accNo)
	{
		double result = 0.0;
		try
		{
			string selectCommandText = "SELECT SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0)) AS Total FROM tbl_StatementOfAffairs WHERE _date <= '" + FinalAccounts.BooksClosinggDate.ToString("MM-dd-yyyy") + "' AND accNo='" + accNo + "'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
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

	private void LoadTransactingAccount()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo,gas.SubAccoutName,ga.accName FROM tbl_generalAccounts ga RIGHT OUTER JOIN tbl_generalAccounts_Sub gas ON gas.accNo = ga.accNo GROUP BY gas.subAccountNo,gas.SubAccoutName,ga.accName HAVING  (ga.accName = 'Cash' OR ga.accName = 'Bank Accounts' OR ga.accName = 'Mobile Money')", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			_dt_TA = new DataTable();
			_dt_TA = dataSet.Tables[0];
			cboAccount.Properties.Items.Clear();
			foreach (DataRow row in _dt_TA.Rows)
			{
				cboAccount.Properties.Items.Add(row["SubAccoutName"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboAccount_Closed(object sender, ClosedEventArgs e)
	{
		if (cboAccount.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_TA.Rows[cboAccount.SelectedIndex];
			txtAccNo.Text = dataRow["subAccountNo"].ToString();
			txtStandingBalance.Text = LoadTransactingAccountBalance(dataRow["subAccountNo"].ToString()).ToString("#,#.0");
		}
	}

	private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataRow dataRow = _dt_TA.Rows[cboAccount.SelectedIndex];
		txtAccNo.Text = dataRow["subAccountNo"].ToString().ToString();
		txtAccGroup.Text = dataRow["accName"].ToString();
		txtStandingBalance.Text = LoadTransactingAccountBalance(txtAccNo.Text).ToString("#,#.0");
		LoadAccountBalanceDetails(txtAccNo.Text);
		if (txtAccNo.Text == "3001")
		{
			layoutChequeNo.Visibility = LayoutVisibility.Never;
			grBankingDetails.Text = "Cash Transactions";
		}
		else if (txtAccNo.Text == "3002")
		{
			txtdChequeNo.Properties.NullText = "Cheaque";
			txtdChequeNo.Properties.NullValuePrompt = "Cheaque";
			grBankingDetails.Text = "Cheque Transactions";
		}
		else if (txtAccNo.Text == "3003")
		{
			txtdChequeNo.Properties.NullText = "Mobile No";
			txtdChequeNo.Properties.NullValuePrompt = "Mobile No";
			grBankingDetails.Text = "Mobile-Money Transactions";
		}
	}

	private void LoadIncomeAccounts()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT accNo,accName AS AccName FROM tbl_generalAccounts WHERE categoryId=1000", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "IncomeAccounts");
		_dt_Inc = new DataTable();
		_dt_Inc = dataSet.Tables[0];
		foreach (DataRow row in _dt_Inc.Rows)
		{
		}
	}

	private void LoadAccountBalanceDetails(string accNo)
	{
		try
		{
			string selectCommandText = string.Format("SELECT ref,_date AS Date,(particulars + '_' + Narration) AS Particulars, ISNULL(Debit,0) AS Dr,ISNULL(Credit,0) AS Cr, (ISNULL(Debit,0)-ISNULL(Credit,0)) AS Amount FROM tbl_StatementOfAffairs WHERE _date >= '{0}' AND accNo='{1}' ORDER BY ref", Convert.ToDateTime(FinalAccounts.BooksBeginningDate.ToString("dd/M/yyyy")).ToShortDateString(), accNo);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "accountsGrouped");
			gridBankLedgers.DataSource = dataSet.Tables[0];
			PrintableControl.SavePrintableControl(gridBankLedgers);
			PrintableControl.SavePrintableControl(gridView3);
			ActiveFormSelected.SetActiveForm(cboAccount.SelectedItem?.ToString() + " Transactions Statement");
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static bool ChequeNoExists(string chequeNo)
	{
		bool result = false;
		using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT ChequeNo FROM tbl_ChequeTransactions WHERE ChequeNo='{chequeNo}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				result = true;
			}
			else
			{
				sqlConnection.Close();
				result = false;
			}
		}
		return result;
	}

	private void gridView3_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
	{
		if (((GridSummaryItem)e.Item).FieldName == "Bal")
		{
			double num = Convert.ToDouble(gridView3.Columns["Dr"].SummaryItem.SummaryValue) - Convert.ToDouble(gridView3.Columns["Cr"].SummaryItem.SummaryValue);
			e.TotalValue = num;
		}
	}

	private void gridView3_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
	{
		GridView gridView = (GridView)sender;
		if (e.Column.FieldName == "Bal" && e.IsGetData)
		{
			double num = 0.0;
			int rowHandle = gridView.GetRowHandle(e.ListSourceRowIndex);
			for (int i = -1; i <= rowHandle - 1; i++)
			{
				num += Convert.ToDouble(gridView.GetRowCellValue(i + 1, "Amount"));
			}
			e.Value = num;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lblActions = new DevExpress.XtraEditors.LabelControl();
		this.txtAccGroup = new DevExpress.XtraEditors.TextEdit();
		this.txtAccNo = new DevExpress.XtraEditors.TextEdit();
		this.txtStandingBalance = new DevExpress.XtraEditors.TextEdit();
		this.cboAccount = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridBankLedgers = new AlienAge.CustomGrid.MyGridControl();
		this.gridView3 = new AlienAge.CustomGrid.MyGridView();
		this.gridColDate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColParticulars = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColDr = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCr = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBal = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.txtdChequeNo = new DevExpress.XtraEditors.TextEdit();
		this.txtdAmount = new DevExpress.XtraEditors.TextEdit();
		this.btnContinue = new DevExpress.XtraEditors.SimpleButton();
		this.dtDate = new DevExpress.XtraEditors.DateEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.grBankingDetails = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutChequeNo = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutDate = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutButton = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutAccount = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutBankLedger = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.lblActionssss = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAccGroup.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStandingBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboAccount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridBankLedgers).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtdChequeNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtdAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.grBankingDetails).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutChequeNo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutDate).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutButton).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutAccount).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutBankLedger).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lblActionssss).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.lblActions);
		this.layoutControl1.Controls.Add(this.txtAccGroup);
		this.layoutControl1.Controls.Add(this.txtAccNo);
		this.layoutControl1.Controls.Add(this.txtStandingBalance);
		this.layoutControl1.Controls.Add(this.cboAccount);
		this.layoutControl1.Controls.Add(this.gridBankLedgers);
		this.layoutControl1.Controls.Add(this.txtdChequeNo);
		this.layoutControl1.Controls.Add(this.txtdAmount);
		this.layoutControl1.Controls.Add(this.btnContinue);
		this.layoutControl1.Controls.Add(this.dtDate);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(445, 110, 491, 518);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(843, 547);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.lblActions.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblActions.Appearance.Options.UseFont = true;
		this.lblActions.Appearance.Options.UseTextOptions = true;
		this.lblActions.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.lblActions.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
		this.lblActions.Location = new System.Drawing.Point(2, 2);
		this.lblActions.Name = "lblActions";
		this.lblActions.Size = new System.Drawing.Size(94, 19);
		this.lblActions.StyleController = this.layoutControl1;
		this.lblActions.TabIndex = 35;
		this.lblActions.Text = "labelControl1";
		this.txtAccGroup.Location = new System.Drawing.Point(2, 106);
		this.txtAccGroup.Name = "txtAccGroup";
		this.txtAccGroup.Properties.ReadOnly = true;
		this.txtAccGroup.Size = new System.Drawing.Size(146, 20);
		this.txtAccGroup.StyleController = this.layoutControl1;
		this.txtAccGroup.TabIndex = 33;
		this.txtAccNo.Location = new System.Drawing.Point(2, 130);
		this.txtAccNo.Name = "txtAccNo";
		this.txtAccNo.Properties.ReadOnly = true;
		this.txtAccNo.Size = new System.Drawing.Size(146, 20);
		this.txtAccNo.StyleController = this.layoutControl1;
		this.txtAccNo.TabIndex = 31;
		this.txtStandingBalance.Location = new System.Drawing.Point(5, 73);
		this.txtStandingBalance.Name = "txtStandingBalance";
		this.txtStandingBalance.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStandingBalance.Properties.Appearance.Options.UseFont = true;
		this.txtStandingBalance.Properties.Appearance.Options.UseTextOptions = true;
		this.txtStandingBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.txtStandingBalance.Properties.ReadOnly = true;
		this.txtStandingBalance.Size = new System.Drawing.Size(140, 26);
		this.txtStandingBalance.StyleController = this.layoutControl1;
		this.txtStandingBalance.TabIndex = 29;
		this.txtStandingBalance.ToolTip = "Account Standing Balance";
		this.txtStandingBalance.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		this.txtStandingBalance.ToolTipTitle = "Standing Balance";
		this.cboAccount.Location = new System.Drawing.Point(5, 47);
		this.cboAccount.Name = "cboAccount";
		this.cboAccount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboAccount.Properties.Appearance.Options.UseFont = true;
		this.cboAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboAccount.Size = new System.Drawing.Size(140, 22);
		this.cboAccount.StyleController = this.layoutControl1;
		this.cboAccount.TabIndex = 28;
		this.cboAccount.SelectedIndexChanged += new System.EventHandler(cboAccount_SelectedIndexChanged);
		this.cboAccount.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboAccount_Closed);
		this.gridBankLedgers.Location = new System.Drawing.Point(152, 25);
		this.gridBankLedgers.MainView = this.gridView3;
		this.gridBankLedgers.Name = "gridBankLedgers";
		this.gridBankLedgers.Size = new System.Drawing.Size(689, 520);
		this.gridBankLedgers.TabIndex = 26;
		this.gridBankLedgers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView3 });
		this.gridView3.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView3.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView3.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView3.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.DetailTip.Options.UseFont = true;
		this.gridView3.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.Empty.Options.UseFont = true;
		this.gridView3.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.EvenRow.Options.UseFont = true;
		this.gridView3.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView3.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView3.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.FixedLine.Options.UseFont = true;
		this.gridView3.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView3.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView3.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView3.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView3.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView3.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView3.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView3.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.GroupButton.Options.UseFont = true;
		this.gridView3.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView3.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView3.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.GroupRow.Options.UseFont = true;
		this.gridView3.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView3.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView3.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView3.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView3.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.HorzLine.Options.UseFont = true;
		this.gridView3.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.OddRow.Options.UseFont = true;
		this.gridView3.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.Preview.Options.UseFont = true;
		this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.Row.Options.UseFont = true;
		this.gridView3.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView3.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView3.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView3.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView3.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView3.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.VertLine.Options.UseFont = true;
		this.gridView3.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.gridView3.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColDate, this.gridColParticulars, this.gridColDr, this.gridColCr, this.gridColBal, this.gridColumn1 });
		this.gridView3.GridControl = this.gridBankLedgers;
		this.gridView3.Name = "gridView3";
		this.gridView3.OptionsBehavior.Editable = false;
		this.gridView3.OptionsCustomization.AllowSort = false;
		this.gridView3.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
		this.gridView3.OptionsDetail.EnableDetailToolTip = true;
		this.gridView3.OptionsDetail.ShowDetailTabs = false;
		this.gridView3.OptionsMenu.EnableFooterMenu = false;
		this.gridView3.OptionsPrint.PrintHorzLines = false;
		this.gridView3.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
		this.gridView3.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
		this.gridView3.OptionsView.ShowFooter = true;
		this.gridView3.OptionsView.ShowGroupPanel = false;
		this.gridView3.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView3.OptionsView.ShowIndicator = false;
		this.gridView3.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridView3_CustomSummaryCalculate);
		this.gridView3.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridView3_CustomUnboundColumnData);
		this.gridColDate.Caption = "Date";
		this.gridColDate.DisplayFormat.FormatString = "dd-MMM-yy";
		this.gridColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColDate.FieldName = "Date";
		this.gridColDate.Name = "gridColDate";
		this.gridColDate.Visible = true;
		this.gridColDate.VisibleIndex = 0;
		this.gridColDate.Width = 100;
		this.gridColParticulars.Caption = "Particulars";
		this.gridColParticulars.FieldName = "Particulars";
		this.gridColParticulars.Name = "gridColParticulars";
		this.gridColParticulars.Visible = true;
		this.gridColParticulars.VisibleIndex = 1;
		this.gridColParticulars.Width = 234;
		this.gridColDr.Caption = "Dr";
		this.gridColDr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColDr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColDr.FieldName = "Dr";
		this.gridColDr.Name = "gridColDr";
		this.gridColDr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Dr", "{0:#,#.0}")
		});
		this.gridColDr.Visible = true;
		this.gridColDr.VisibleIndex = 2;
		this.gridColDr.Width = 167;
		this.gridColCr.Caption = "Cr";
		this.gridColCr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColCr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColCr.FieldName = "Cr";
		this.gridColCr.Name = "gridColCr";
		this.gridColCr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cr", "{0:#,#.0}")
		});
		this.gridColCr.Visible = true;
		this.gridColCr.VisibleIndex = 3;
		this.gridColCr.Width = 168;
		this.gridColBal.Caption = "Bal";
		this.gridColBal.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBal.FieldName = "Bal";
		this.gridColBal.Name = "gridColBal";
		this.gridColBal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColBal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
		this.gridColBal.Visible = true;
		this.gridColBal.VisibleIndex = 4;
		this.gridColBal.Width = 149;
		this.gridColumn1.Caption = "Amount";
		this.gridColumn1.FieldName = "Amount";
		this.gridColumn1.Name = "gridColumn1";
		this.txtdChequeNo.Location = new System.Drawing.Point(7, 206);
		this.txtdChequeNo.Name = "txtdChequeNo";
		this.txtdChequeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.txtdChequeNo.Properties.Appearance.Options.UseFont = true;
		this.txtdChequeNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtdChequeNo.Properties.NullText = "Cheque No";
		this.txtdChequeNo.Properties.NullValuePrompt = "Cheque No";
		this.txtdChequeNo.Size = new System.Drawing.Size(136, 24);
		this.txtdChequeNo.StyleController = this.layoutControl1;
		this.txtdChequeNo.TabIndex = 15;
		this.txtdAmount.Location = new System.Drawing.Point(7, 178);
		this.txtdAmount.Name = "txtdAmount";
		this.txtdAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtdAmount.Properties.Appearance.Options.UseFont = true;
		this.txtdAmount.Properties.DisplayFormat.FormatString = "{0:#,#.0}";
		this.txtdAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtdAmount.Properties.Mask.EditMask = "n0";
		this.txtdAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtdAmount.Properties.NullText = "Amount";
		this.txtdAmount.Properties.NullValuePrompt = "Amount";
		this.txtdAmount.Size = new System.Drawing.Size(136, 24);
		this.txtdAmount.StyleController = this.layoutControl1;
		this.txtdAmount.TabIndex = 12;
		this.btnContinue.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnContinue.Appearance.Options.UseFont = true;
		this.btnContinue.Location = new System.Drawing.Point(2, 522);
		this.btnContinue.Name = "btnContinue";
		this.btnContinue.Size = new System.Drawing.Size(146, 23);
		this.btnContinue.StyleController = this.layoutControl1;
		this.btnContinue.TabIndex = 11;
		this.btnContinue.Text = "Continue";
		this.btnContinue.Click += new System.EventHandler(btnContinue_Click);
		this.dtDate.EditValue = null;
		this.dtDate.Location = new System.Drawing.Point(7, 234);
		this.dtDate.Name = "dtDate";
		this.dtDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dtDate.Properties.Appearance.Options.UseFont = true;
		this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDate.Properties.NullText = "Date";
		this.dtDate.Properties.NullValuePrompt = "Date";
		this.dtDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtDate.Size = new System.Drawing.Size(136, 24);
		this.dtDate.StyleController = this.layoutControl1;
		this.dtDate.TabIndex = 6;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.grBankingDetails, this.layoutButton, this.layoutControlItem11, this.layoutAccount, this.layoutBankLedger, this.layoutControlItem9, this.emptySpaceItem1, this.lblActionssss });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(843, 547);
		this.layoutControlGroup1.TextVisible = false;
		this.grBankingDetails.CustomizationFormText = "Cheque Deposit";
		this.grBankingDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem4, this.layoutChequeNo, this.layoutDate });
		this.grBankingDetails.Location = new System.Drawing.Point(0, 152);
		this.grBankingDetails.Name = "grBankingDetails";
		this.grBankingDetails.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.grBankingDetails.Size = new System.Drawing.Size(150, 113);
		this.grBankingDetails.Text = "Cash Transactions";
		this.layoutControlItem4.Control = this.txtdAmount;
		this.layoutControlItem4.CustomizationFormText = "Amount";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(140, 28);
		this.layoutControlItem4.Text = "Amount";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutChequeNo.Control = this.txtdChequeNo;
		this.layoutChequeNo.CustomizationFormText = "Cheque No:";
		this.layoutChequeNo.Location = new System.Drawing.Point(0, 28);
		this.layoutChequeNo.Name = "layoutChequeNo";
		this.layoutChequeNo.Size = new System.Drawing.Size(140, 28);
		this.layoutChequeNo.Text = "Cheque No:";
		this.layoutChequeNo.TextSize = new System.Drawing.Size(0, 0);
		this.layoutChequeNo.TextVisible = false;
		this.layoutDate.Control = this.dtDate;
		this.layoutDate.CustomizationFormText = "Date";
		this.layoutDate.Location = new System.Drawing.Point(0, 56);
		this.layoutDate.Name = "layoutDate";
		this.layoutDate.Size = new System.Drawing.Size(140, 28);
		this.layoutDate.Text = "Date";
		this.layoutDate.TextSize = new System.Drawing.Size(0, 0);
		this.layoutDate.TextVisible = false;
		this.layoutButton.Control = this.btnContinue;
		this.layoutButton.CustomizationFormText = "layoutControlItem8";
		this.layoutButton.Location = new System.Drawing.Point(0, 520);
		this.layoutButton.Name = "layoutButton";
		this.layoutButton.Size = new System.Drawing.Size(150, 27);
		this.layoutButton.TextSize = new System.Drawing.Size(0, 0);
		this.layoutButton.TextVisible = false;
		this.layoutControlItem11.Control = this.txtAccNo;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 128);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(150, 24);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutAccount.CustomizationFormText = "Account";
		this.layoutAccount.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem3, this.layoutControlItem8 });
		this.layoutAccount.Location = new System.Drawing.Point(0, 23);
		this.layoutAccount.Name = "layoutAccount";
		this.layoutAccount.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutAccount.Size = new System.Drawing.Size(150, 81);
		this.layoutAccount.Text = "Account";
		this.layoutControlItem3.Control = this.cboAccount;
		this.layoutControlItem3.CustomizationFormText = "Account";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(144, 26);
		this.layoutControlItem3.Text = "Account";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.txtStandingBalance;
		this.layoutControlItem8.CustomizationFormText = "Standing Balance";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 26);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(144, 30);
		this.layoutControlItem8.Text = "Standing Balance";
		this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutBankLedger.Control = this.gridBankLedgers;
		this.layoutBankLedger.CustomizationFormText = "layoutControlItem3";
		this.layoutBankLedger.Location = new System.Drawing.Point(150, 23);
		this.layoutBankLedger.Name = "layoutBankLedger";
		this.layoutBankLedger.Size = new System.Drawing.Size(693, 524);
		this.layoutBankLedger.TextSize = new System.Drawing.Size(0, 0);
		this.layoutBankLedger.TextVisible = false;
		this.layoutControlItem9.Control = this.txtAccGroup;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 104);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(150, 24);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 265);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(150, 255);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.lblActionssss.AppearanceItemCaption.Options.UseTextOptions = true;
		this.lblActionssss.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.lblActionssss.Control = this.lblActions;
		this.lblActionssss.CustomizationFormText = "lblActionssss";
		this.lblActionssss.Location = new System.Drawing.Point(0, 0);
		this.lblActionssss.Name = "lblActionssss";
		this.lblActionssss.Size = new System.Drawing.Size(843, 23);
		this.lblActionssss.TextSize = new System.Drawing.Size(0, 0);
		this.lblActionssss.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrCheaqueTransactions";
		base.Size = new System.Drawing.Size(843, 547);
		base.Load += new System.EventHandler(usrCheaqueTransactions_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtAccGroup.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStandingBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboAccount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridBankLedgers).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtdChequeNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtdAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.grBankingDetails).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutChequeNo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutDate).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutButton).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutAccount).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutBankLedger).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lblActionssss).EndInit();
		base.ResumeLayout(false);
	}
}
