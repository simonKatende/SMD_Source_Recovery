using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.ReportHeaders;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Taxes;

namespace I_Xtreme.DialogForms;

public class SupplierPayment : RibbonForm
{
	private SqlTransaction transaction;

	private SqlTransaction trans;

	private SqlTransaction _trans_s;

	public string paymentMode = "DirectPay";

	private DataTable _dt_TA;

	private DataTable _dt;

	private IContainer components = null;

	private GroupControl groupControl6;

	private LabelControl labelControl1;

	private LabelControl labelControl91;

	private LabelControl labelControl136;

	private LabelControl labelControl46;

	private SimpleButton btnPayBills;

	private MemoEdit txtPaySupplierAddress;

	private LabelControl labelControl45;

	private TextEdit txtPaySupplierOffice;

	private TextEdit txtPaySupplierMob;

	private TextEdit txtPaySupplierOtherName;

	private TextEdit txtPaySupplierSurname;

	private TextEdit txtPaySupplierName;

	private LabelControl labelControl40;

	private LookUpEdit lookUpSupplierPayment;

	private RibbonControl ribbonControl1;

	private RibbonPage ribbonPage1;

	private RibbonPageGroup ribbonPageGroup1;

	private GridControl gridSupplierLedger;

	private GridView gridViewSL;

	private LookUpEdit lookUpInvoices;

	private CheckEdit chkPrintInvoice;

	private LabelControl lblPayAs;

	private RibbonPageGroup ribbonPageGroup2;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private PrintingSystem printingSystem1;

	private PrintableComponentLink printableComponentLink1;

	private System.Windows.Forms.Timer timer1;

	private BarEditItem barEditItem1;

	private RepositoryItemLookUpEdit VoucherItemLookUp;

	public TextEdit txtVoucherNo;

	public LabelControl lblBankAccNo;

	public TextEdit txtPaySupplierAmount;

	public DateEdit dtPaySupplier;

	private TextEdit txtAccountNo;

	private TextEdit txtStandingBalance;

	public ComboBoxEdit cboAccount;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	public SupplierPayment()
	{
		InitializeComponent();
		txtVoucherNo.Text = "---";
		lblPayAs.Text = "Cash Pay";
		txtVoucherNo.Properties.ReadOnly = true;
		LoadSupplierLookUp();
		LoadTransactingAccount();
	}

	private void LoadPayableInvoices()
	{
		try
		{
			string selectCommandText = $"SELECT OrderNumber AS Invoice#,SupplyDate AS Date,Supplier,Credit AS InvoiceTotal FROM tbl_Orders WHERE Balance>0 AND Status='Closed' AND Supplier='{txtPaySupplierName.Text}' AND Debit=0";
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SupplierInvoices");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpInvoices.Properties.Columns.Clear();
			lookUpInvoices.Properties.DataSource = dataTable;
			lookUpInvoices.Properties.DisplayMember = "Supplier";
			lookUpInvoices.Properties.ValueMember = "Supplier";
			LookUpColumnInfoCollection columns = lookUpSupplierPayment.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Date", 0));
			columns.Add(new LookUpColumnInfo("Invoice#", 0));
			columns.Add(new LookUpColumnInfo("InvoiceTotal", 0));
			lookUpInvoices.Properties.BestFitMode = BestFitMode.BestFit;
			lookUpInvoices.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpInvoices.Properties.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void LoadSupplierLedger(string supplierCompany)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT OrderNumber AS Ref,Particulars,SupplyDate AS Date,Credit,Debit,Balance FROM tbl_Orders WHERE Supplier='{supplierCompany}'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SupplierLedger");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			gridSupplierLedger.DataSource = dataTable.DefaultView;
			gridViewSL.Columns["Ref"].Width = 50;
			gridViewSL.Columns["Date"].Width = 70;
			gridViewSL.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
			gridViewSL.Columns["Date"].DisplayFormat.FormatString = "{0:dd-MMM-yy}";
			gridViewSL.Columns["Credit"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Credit"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridViewSL.Columns["Debit"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Debit"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridViewSL.Columns["Balance"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Balance"].DisplayFormat.FormatString = "{0:#,#.0}";
			GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
			gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem.FieldName = "Credit";
			gridViewSL.Columns["Credit"].SummaryItem.Assign(gridColumnSummaryItem);
			GridColumnSummaryItem gridColumnSummaryItem2 = new GridColumnSummaryItem();
			gridColumnSummaryItem2.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem2.FieldName = "Debit";
			gridViewSL.Columns["Debit"].SummaryItem.Assign(gridColumnSummaryItem2);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSupplierLookUp()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Company, Surname AS Name,OtherNames,Mobile As Tel,SupplierCode FROM tbl_Suppliers", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SupplierList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpSupplierPayment.Properties.Columns.Clear();
			lookUpSupplierPayment.Properties.DataSource = dataTable;
			lookUpSupplierPayment.Properties.DisplayMember = "Company";
			lookUpSupplierPayment.Properties.ValueMember = "Company";
			LookUpColumnInfoCollection columns = lookUpSupplierPayment.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Company", 0));
			columns.Add(new LookUpColumnInfo("Name", 0));
			columns.Add(new LookUpColumnInfo("OtherNames", 0));
			columns.Add(new LookUpColumnInfo("Tel", 0));
			lookUpSupplierPayment.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
			lookUpSupplierPayment.Properties.SearchMode = SearchMode.AutoComplete;
			lookUpSupplierPayment.Properties.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnPayBills_Click(object sender, EventArgs e)
	{
		try
		{
			double result = (double.TryParse(txtPaySupplierAmount.Text, out result) ? result : 0.0);
			string empty = string.Empty;
			int num = 0;
			string text = string.Empty;
			string captureDate = CaptureDate.GetCaptureDate();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT * FROM tbl_OrderdDetails WHERE OrderNumber='{0}'", lookUpInvoices.Properties.GetDataSourceValue("Invoice#", lookUpInvoices.ItemIndex)), DataConnection.ConnectToDatabase()))
			{
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "OrderItems");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					double result2 = (double.TryParse(row["Total"].ToString(), out result2) ? result2 : 0.0);
					double num2 = Math.Round(result2 / result * 100.0, 2);
					empty = row["ItemName"].ToString();
					num = Convert.ToInt32(row["AccNo"]);
					text = $"{text},{empty}";
					using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					string selectCommandText = $"SELECT TOP (100) PERCENT id, Supplier, Particulars, Debit, Credit, Balance FROM tbl_Orders AS tbl_Orders_1 WHERE (id IN (SELECT MAX(id) AS id FROM tbl_Orders AS tbl_Suppliers WHERE (Supplier = '{txtPaySupplierName.Text}')))";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, selectConnection);
					using DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "SupplierPayment");
					DataTable dataTable2 = new DataTable();
					dataTable2 = dataSet2.Tables[0];
					foreach (DataRow row2 in dataTable2.Rows)
					{
						double result3 = (double.TryParse(Convert.ToDouble(row2["Balance"]).ToString(), out result3) ? result3 : 0.0);
						double num3 = num2;
						double num4 = result3 - num3;
						DateTime dateTime = dtPaySupplier.DateTime;
						using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection.Open();
						_trans_s = sqlConnection.BeginTransaction();
						using (SqlCommand sqlCommand = new SqlCommand
						{
							Transaction = _trans_s,
							Connection = sqlConnection,
							CommandText = "INSERT INTO tbl_Orders (OrderNumber,Supplier,Particulars,SupplyDate,Credit,Debit,Balance,Status) VALUES (@OrderNumber,@Supplier,@Particulars,@SupplyDate,@Credit,@Debit,@Balance,@Status)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand.Parameters.Add("@OrderNumber", SqlDbType.BigInt);
							sqlParameter.Value = Convert.ToInt64(lookUpInvoices.Properties.GetDataSourceValue("Invoice#", lookUpInvoices.ItemIndex));
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Supplier", SqlDbType.VarChar, 100);
							sqlParameter.Value = txtPaySupplierName.Text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
							sqlParameter.Value = empty;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@SupplyDate", SqlDbType.DateTime);
							sqlParameter.Value = dateTime.ToShortDateString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter.Value = num2;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter.Value = 0;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Balance", SqlDbType.Money);
							sqlParameter.Value = num4;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 10);
							sqlParameter.Value = "Closed";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Transaction = _trans_s,
							Connection = sqlConnection,
							CommandText = "UPDATE tbl_OrderdDetails SET Status=@Status WHERE OrderNumber=@OrderNumber AND ItemName=@ItemName",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2;
							if (num2 >= result2)
							{
								sqlParameter2 = sqlCommand2.Parameters.Add("@Status", SqlDbType.VarChar, 10);
								sqlParameter2.Value = "Paid";
								sqlParameter2.Direction = ParameterDirection.Input;
							}
							else if (num2 < result2)
							{
								sqlParameter2 = sqlCommand2.Parameters.Add("@Status", SqlDbType.VarChar, 10);
								sqlParameter2.Value = "Not Paid";
								sqlParameter2.Direction = ParameterDirection.Input;
							}
							sqlParameter2 = sqlCommand2.Parameters.Add("@OrderNumber", SqlDbType.BigInt);
							sqlParameter2.Value = Convert.ToInt64(lookUpInvoices.Properties.GetDataSourceValue("Voucher#", lookUpInvoices.ItemIndex));
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand2.Parameters.Add("@ItemName", SqlDbType.VarChar, 50);
							sqlParameter2.Value = empty;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand2.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Transaction = _trans_s,
							Connection = sqlConnection,
							CommandText = "INSERT INTO Expenses (ExpenseName,expenseSource,qty,units,ExpenseValue,DateOfExpense,SemesterId,Narration,Debitor,CaptureDate)VALUES(@ExpenseName,@expenseSource,@qty,@units,@ExpenseValue,@DateOfExpense,@SemesterId,@Narration,@Debitor,@CaptureDate)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@ExpenseName", SqlDbType.VarChar, 50);
							sqlParameter3.Value = empty;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@expenseSource", SqlDbType.VarChar, 50);
							sqlParameter3.Value = "Supplier payment";
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@qty", SqlDbType.Int);
							sqlParameter3.Value = 1;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@units", SqlDbType.VarChar, 35);
							sqlParameter3.Value = string.Empty;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@ExpenseValue", SqlDbType.Money);
							sqlParameter3.Value = num2;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@DateOfExpense", SqlDbType.DateTime);
							sqlParameter3.Value = dateTime.ToShortDateString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
							sqlParameter3.Value = WorkingSemesters.GetWorkingSemester();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
							sqlParameter3.Value = $"Payment for: {empty} ({txtPaySupplierName.Text})";
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@Debitor", SqlDbType.VarChar, 50);
							sqlParameter3.Value = txtPaySupplierName.Text;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand3.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
							sqlParameter3.Value = captureDate;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand4 = new SqlCommand
						{
							Transaction = _trans_s,
							Connection = sqlConnection,
							CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.Int);
							sqlParameter4.Value = 5001;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
							sqlParameter4.Value = $"{empty}";
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
							sqlParameter4.Value = WorkingSemesters.GetWorkingSemester();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@_date", SqlDbType.DateTime);
							sqlParameter4.Value = dateTime.ToShortDateString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@month", SqlDbType.VarChar, 9);
							sqlParameter4.Value = dateTime.ToString("MMMM");
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@year", SqlDbType.Int);
							sqlParameter4.Value = dateTime.Year;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter4.Value = num2;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter4.Value = 0;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
							sqlParameter4.Value = captureDate;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand4.Parameters.Add("@Narration", SqlDbType.VarChar);
							sqlParameter4.Value = $"Payment for: {empty} ({txtPaySupplierName.Text})";
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Transaction = _trans_s,
							Connection = sqlConnection,
							CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter5 = sqlCommand5.Parameters.Add("@accNo", SqlDbType.Int);
							sqlParameter5.Value = num;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
							sqlParameter5.Value = $"{empty}";
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
							sqlParameter5.Value = WorkingSemesters.GetWorkingSemester();
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@_date", SqlDbType.DateTime);
							sqlParameter5.Value = dateTime.ToShortDateString();
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@month", SqlDbType.VarChar, 9);
							sqlParameter5.Value = dateTime.ToString("MMMM");
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@year", SqlDbType.Int);
							sqlParameter5.Value = dateTime.Year;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter5.Value = num2;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter5.Value = 0;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
							sqlParameter5.Value = captureDate;
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlParameter5 = sqlCommand5.Parameters.Add("@Narration", SqlDbType.VarChar);
							sqlParameter5.Value = $"Payment for: {empty} ({txtPaySupplierName.Text})";
							sqlParameter5.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand6 = new SqlCommand
						{
							Transaction = _trans_s,
							Connection = sqlConnection,
							CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter6 = sqlCommand6.Parameters.Add("@accNo", SqlDbType.Int);
							sqlParameter6.Value = txtAccountNo.Text;
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
							sqlParameter6.Value = $"Payment for: {empty} ({txtPaySupplierName.Text})";
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
							sqlParameter6.Value = WorkingSemesters.GetWorkingSemester();
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@_date", SqlDbType.DateTime);
							sqlParameter6.Value = dateTime.ToShortDateString();
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@month", SqlDbType.VarChar, 9);
							sqlParameter6.Value = dateTime.ToString("MMMM");
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@year", SqlDbType.Int);
							sqlParameter6.Value = dateTime.Year;
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter6.Value = 0;
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter6.Value = num2;
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
							sqlParameter6.Value = captureDate;
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlParameter6 = sqlCommand6.Parameters.Add("@Narration", SqlDbType.VarChar);
							sqlParameter6.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtPaySupplierName.Text);
							sqlParameter6.Direction = ParameterDirection.Input;
							sqlCommand6.ExecuteNonQuery();
						}
						_trans_s.Commit();
						sqlConnection.Close();
					}
				}
			}
			if (!cboAccount.Enabled && paymentMode == "IndirectPay" && (txtAccountNo.Text == "3002" || txtAccountNo.Text == "3003"))
			{
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				trans = sqlConnection2.BeginTransaction();
				string commandText = "INSERT INTO tbl_ChequeTransactions (ChequeNo,BankAccNo,_Date,PayTo,Amount,AmountInWords,Status,C_Type,ref) VALUES (@ChequeNo,@BankAccNo,@_Date,@PayTo,@Amount,@AmountInWords,@Status,@C_Type,@ref)";
				using (SqlCommand sqlCommand7 = new SqlCommand
				{
					Transaction = trans,
					Connection = sqlConnection2,
					CommandText = commandText,
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter7 = sqlCommand7.Parameters.Add("@ChequeNo", SqlDbType.VarChar, 20);
					sqlParameter7.Value = txtVoucherNo.Text;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@BankAccNo", SqlDbType.VarChar, 30);
					sqlParameter7.Value = lblBankAccNo.Text;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@_Date", SqlDbType.DateTime);
					sqlParameter7.Value = dtPaySupplier.DateTime.ToShortDateString();
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@PayTo", SqlDbType.VarChar, 100);
					sqlParameter7.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtPaySupplierName.Text);
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@Amount", SqlDbType.Money);
					sqlParameter7.Value = Convert.ToDouble(txtPaySupplierAmount.Text);
					sqlParameter7.Direction = ParameterDirection.Input;
					NumberToWordsConverter numberToWordsConverter = new NumberToWordsConverter();
					sqlParameter7 = sqlCommand7.Parameters.Add("@AmountInWords", SqlDbType.VarChar, 100);
					sqlParameter7.Value = numberToWordsConverter.NumberToWords((long)result) + " shillings only";
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@Status", SqlDbType.VarChar, 12);
					sqlParameter7.Value = "NonCancelled";
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@C_Type", SqlDbType.VarChar, 10);
					sqlParameter7.Value = "Withdraw";
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand7.Parameters.Add("@ref", SqlDbType.VarChar, 80);
					sqlParameter7.Value = captureDate;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlCommand7.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand8 = new SqlCommand
				{
					Transaction = trans,
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_Banking (AccountNo,PayRef,Particulars,_date,Credit,Debit) VALUES (@AccountNo,@PayRef,@Particulars,@_date,@Credit,@Debit)",
					CommandType = CommandType.Text
				})
				{
					string text2 = string.Empty;
					if (txtAccountNo.Text == "3002")
					{
						text2 = "Cheque";
					}
					else if (txtAccountNo.Text == "3003")
					{
						text2 = "M-Money";
					}
					SqlParameter sqlParameter8 = sqlCommand8.Parameters.Add("@AccountNo", SqlDbType.VarChar, 50);
					sqlParameter8.Value = lblBankAccNo.Text;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand8.Parameters.Add("@PayRef", SqlDbType.VarChar, 50);
					sqlParameter8.Value = captureDate;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand8.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
					sqlParameter8.Value = text2 + Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtPaySupplierName.Text);
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand8.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter8.Value = dtPaySupplier.DateTime.ToShortDateString();
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand8.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter8.Value = 0;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand8.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter8.Value = Convert.ToDouble(txtPaySupplierAmount.Text);
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlCommand8.ExecuteNonQuery();
				}
				double result4 = (double.TryParse(txtStandingBalance.Text, out result4) ? result4 : 0.0);
				double num5 = result4 - Convert.ToDouble(txtPaySupplierAmount.Text);
				using (SqlCommand sqlCommand9 = new SqlCommand
				{
					Transaction = trans,
					Connection = sqlConnection2,
					CommandText = "UPDATE tbl_generalAccounts SET ClosingBalance=@ClosingBalance WHERE accNo=@accNo",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter9 = sqlCommand9.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter9.Value = txtAccountNo.Text;
					sqlParameter9.Direction = ParameterDirection.Input;
					sqlParameter9 = sqlCommand9.Parameters.Add("@ClosingBalance", SqlDbType.Money);
					sqlParameter9.Value = num5;
					sqlParameter9.Direction = ParameterDirection.Input;
					sqlCommand9.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				transaction = sqlConnection3.BeginTransaction();
				using (SqlCommand sqlCommand10 = new SqlCommand
				{
					Transaction = transaction,
					Connection = sqlConnection3,
					CommandText = "INSERT INTO tbl_PaymentVoucher (voucherNo,VType,RefNo,ReceivedBy,ReceiverNo,Total,PaymentOf,AmountInWords,Balance,PreparedBy,PayMode,_Date,TaxValue,TaxName,capDate) VALUES (@voucherNo,@VType,@RefNo,@ReceivedBy,@ReceiverNo,@Total,@PaymentOf,@AmountInWords,@Balance,@PreparedBy,@PayMode,@_Date,@TaxValue,@TaxName,@capDate)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter10 = sqlCommand10.Parameters.Add("@voucherNo", SqlDbType.VarChar, 10);
					sqlParameter10.Value = PayInVoucher.GetNextVoucherNumber();
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@VType", SqlDbType.VarChar, 3);
					sqlParameter10.Value = "O";
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@RefNo", SqlDbType.VarChar, 50);
					sqlParameter10.Value = txtVoucherNo.Text.ToUpper();
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@ReceivedBy", SqlDbType.VarChar, 50);
					sqlParameter10.Value = txtPaySupplierName.Text;
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@ReceiverNo", SqlDbType.VarChar, 50);
					sqlParameter10.Value = lookUpSupplierPayment.Properties.GetDataSourceValue("SupplierCode", lookUpSupplierPayment.ItemIndex).ToString();
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@Total", SqlDbType.Money);
					sqlParameter10.Value = Convert.ToDouble(txtPaySupplierAmount.Text);
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@PaymentOf", SqlDbType.VarChar, 100);
					sqlParameter10.Value = text.Substring(1, text.Length - 1);
					sqlParameter10.Direction = ParameterDirection.Input;
					NumberToWordsConverter numberToWordsConverter2 = new NumberToWordsConverter();
					sqlParameter10 = sqlCommand10.Parameters.Add("@AmountInWords", SqlDbType.VarChar, 100);
					sqlParameter10.Value = numberToWordsConverter2.NumberToWords((long)result) + " shillings only";
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@Balance", SqlDbType.Money);
					sqlParameter10.Value = 0;
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@PreparedBy", SqlDbType.VarChar, 50);
					sqlParameter10.Value = CurrentUser.GetSystemUser();
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@PayMode", SqlDbType.VarChar, 50);
					sqlParameter10.Value = cboAccount.SelectedItem;
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@_Date", SqlDbType.DateTime);
					sqlParameter10.Value = dtPaySupplier.DateTime.ToShortDateString();
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@TaxValue", SqlDbType.Money);
					sqlParameter10.Value = TaxCalculations.WithHoldingTax(result);
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@TaxName", SqlDbType.VarChar, 50);
					sqlParameter10.Value = TaxCalculations.TaxName();
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlParameter10 = sqlCommand10.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
					sqlParameter10.Value = captureDate;
					sqlParameter10.Direction = ParameterDirection.Input;
					sqlCommand10.ExecuteNonQuery();
				}
				if (TaxCalculations.DeductWithHoldingTax)
				{
					using SqlCommand sqlCommand11 = new SqlCommand
					{
						Transaction = transaction,
						Connection = sqlConnection3,
						CommandText = "INSERT INTO tbl_TaxCollection (TaxName,_Date,Source,Amount,capDate) VALUES (@TaxName,@_Date,@Source,@Amount,@capDate)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter11 = sqlCommand11.Parameters.Add("@TaxName", SqlDbType.VarChar, 10);
					sqlParameter11.Value = TaxCalculations.TaxName();
					sqlParameter11.Direction = ParameterDirection.Input;
					sqlParameter11 = sqlCommand11.Parameters.Add("@_Date", SqlDbType.VarChar, 3);
					sqlParameter11.Value = dtPaySupplier.DateTime.ToShortDateString();
					sqlParameter11.Direction = ParameterDirection.Input;
					sqlParameter11 = sqlCommand11.Parameters.Add("@Source", SqlDbType.VarChar, 50);
					sqlParameter11.Value = txtPaySupplierName.Text;
					sqlParameter11.Direction = ParameterDirection.Input;
					sqlParameter11 = sqlCommand11.Parameters.Add("@Amount", SqlDbType.VarChar, 50);
					sqlParameter11.Value = TaxCalculations.WithHoldingTax(result);
					sqlParameter11.Direction = ParameterDirection.Input;
					sqlParameter11 = sqlCommand11.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
					sqlParameter11.Value = captureDate;
					sqlParameter11.Direction = ParameterDirection.Input;
					sqlCommand11.ExecuteNonQuery();
				}
				transaction.Commit();
			}
			CustomDialog.ShowCustomDialog("Payment made successfully");
			txtPaySupplierAmount.Text = string.Empty;
			if (chkPrintInvoice.Checked)
			{
				WaitDialogForm waitDialogForm = new WaitDialogForm
				{
					Caption = "Generating payment voucher..."
				};
				waitDialogForm.Show();
				waitDialogForm.Close();
			}
			if (paymentMode == "IndirectPay")
			{
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void txtPaySupplierName_TextChanged(object sender, EventArgs e)
	{
		LoadPayableInvoices();
		LoadSupplierLedger(txtPaySupplierName.Text);
		LoadPreviousVouchers();
		if (txtPaySupplierName.Text == string.Empty)
		{
			ribbonPageGroup1.Visible = false;
		}
		else
		{
			ribbonPageGroup1.Visible = true;
		}
	}

	private void LoadPreviousVouchers()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT _Date AS Date,voucherNo AS Voucher#, PaymentOf AS ReasonOfPayment,Total AS Amount FROM tbl_PaymentVoucher WHERE ReceiverNo='{0}'", lookUpSupplierPayment.Properties.GetDataSourceValue("SupplierCode", lookUpSupplierPayment.ItemIndex).ToString()), selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "EmployeeList");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			VoucherItemLookUp.Columns.Clear();
			VoucherItemLookUp.DataSource = _dt;
			VoucherItemLookUp.DisplayMember = "ReasonOfPayment";
			VoucherItemLookUp.ValueMember = "Voucher#";
			LookUpColumnInfoCollection columns = lookUpSupplierPayment.Properties.Columns;
			columns.Add(new LookUpColumnInfo("Date", 0));
			columns.Add(new LookUpColumnInfo("Voucher#", 0));
			columns.Add(new LookUpColumnInfo("ReasonOfPayment", 0));
			columns.Add(new LookUpColumnInfo("Amount", 0));
			VoucherItemLookUp.BestFitMode = BestFitMode.BestFitResizePopup;
			VoucherItemLookUp.SearchMode = SearchMode.AutoComplete;
			VoucherItemLookUp.AutoSearchColumnIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadTransactingAccount()
	{
		try
		{
			string selectCommandText = string.Format("SELECT at.Category, at.accountName AS AccGroup, ga.accNo, ga.accName,SUM(ISNULL(sa.Debit, 0) - ISNULL(sa.Credit, 0)) AS AccountBalance FROM tbl_generalAccounts ga LEFT OUTER JOIN  tbl_StatementOfAffairs sa ON ga.accNo = sa.accNo RIGHT OUTER JOIN  tbl_account_types at ON ga.categoryId = at.categoryId GROUP BY at.Category, at.accountName, ga.accNo, ga.accName HAVING (ga.accNo = 3001) OR (ga.accNo = 3002) OR (ga.accNo = 3003) AND (MIN(DISTINCT sa._date) >= '{0}')", FinalAccounts.BooksBeginningDate.ToString("yyyy-M-d"));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			_dt_TA = new DataTable();
			_dt_TA = dataSet.Tables[0];
			cboAccount.Properties.Items.Clear();
			foreach (DataRow row in _dt_TA.Rows)
			{
				cboAccount.Properties.Items.Add(row["accName"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void radioGroup10_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		printableComponentLink1.Component = gridSupplierLedger;
		printableComponentLink1.PrintingSystem.ClearContent();
		GridReportHeaders.Header(printableComponentLink1, "SUPPLIER LEDGER", txtPaySupplierName.Text, txtPaySupplierMob.Text);
		printableComponentLink1.ShowPreview();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		printableComponentLink1.Component = gridSupplierLedger;
		printableComponentLink1.PrintingSystem.ClearContent();
		GridReportHeaders.Header(printableComponentLink1, "SUPPLIER LEDGER", txtPaySupplierName.Text, txtPaySupplierMob.Text);
		printableComponentLink1.PrintDlg();
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		string arg = $"{txtPaySupplierName.Text}";
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = "Save to",
			FileName = string.Format("{0}_{1}", arg, DateTime.Now.ToString("HHMMss")),
			RestoreDirectory = true,
			Filter = "Excel Workbook (*.Xlsx)|*.Xlsx"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			printableComponentLink1.Component = gridSupplierLedger;
			printableComponentLink1.Landscape = false;
			printableComponentLink1.PrintingSystem.ClearContent();
			GridReportHeaders.Header(printableComponentLink1, "SUPPLIER LEDGER", txtPaySupplierName.Text, string.Empty);
			printableComponentLink1.ExportToXlsx(saveFileDialog.FileName + ".Xlsx");
			if (XtraMessageBox.Show("Do you want to open the file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Process.Start(saveFileDialog.FileName + ".Xlsx");
			}
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtPaySupplierName.Text != string.Empty && lookUpInvoices.EditValue != null && txtVoucherNo.Text != string.Empty && dtPaySupplier.EditValue != null && txtPaySupplierAmount.Text != string.Empty && txtPaySupplierAmount.Text != "0")
		{
			btnPayBills.Enabled = true;
		}
		else
		{
			btnPayBills.Enabled = false;
		}
	}

	private void barEditItem1_HiddenEditor_1(object sender, ItemClickEventArgs e)
	{
		if (barEditItem1.EditValue == null)
		{
		}
	}

	private void lookUpSupplierPayment_Closed(object sender, ClosedEventArgs e)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Suppliers WHERE Company='{lookUpSupplierPayment.Text}'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SupplierDetails");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				txtPaySupplierName.Text = row["Company"].ToString();
				txtPaySupplierAddress.Text = row["Street"].ToString();
				txtPaySupplierMob.Text = row["Mobile"].ToString();
				txtPaySupplierSurname.Text = row["Surname"].ToString();
				txtPaySupplierOffice.Text = row["Phone"].ToString();
				txtPaySupplierOtherName.Text = row["OtherNames"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboAccount_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboAccount.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_TA.Rows[cboAccount.SelectedIndex];
			txtAccountNo.Text = dataRow["accNo"].ToString();
			txtStandingBalance.Text = Convert.ToDouble(dataRow["AccountBalance"]).ToString("#,#.0");
			if (cboAccount.SelectedIndex == 0)
			{
				txtVoucherNo.Text = "---";
				txtVoucherNo.Properties.ReadOnly = true;
				lblPayAs.Text = "Cash Pay";
			}
			else if (cboAccount.SelectedIndex == 1)
			{
				txtVoucherNo.Properties.ReadOnly = false;
				lblPayAs.Text = "Cheque No.";
				txtVoucherNo.Text = string.Empty;
			}
			else if (cboAccount.SelectedIndex == 2)
			{
				txtVoucherNo.Properties.ReadOnly = false;
				lblPayAs.Text = "Mobile #";
				txtVoucherNo.Text = string.Empty;
			}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.DialogForms.SupplierPayment));
		this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.txtAccountNo = new DevExpress.XtraEditors.TextEdit();
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
		this.VoucherItemLookUp = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.txtStandingBalance = new DevExpress.XtraEditors.TextEdit();
		this.cboAccount = new DevExpress.XtraEditors.ComboBoxEdit();
		this.lblBankAccNo = new DevExpress.XtraEditors.LabelControl();
		this.lblPayAs = new DevExpress.XtraEditors.LabelControl();
		this.txtVoucherNo = new DevExpress.XtraEditors.TextEdit();
		this.chkPrintInvoice = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl91 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl136 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl46 = new DevExpress.XtraEditors.LabelControl();
		this.btnPayBills = new DevExpress.XtraEditors.SimpleButton();
		this.txtPaySupplierAmount = new DevExpress.XtraEditors.TextEdit();
		this.dtPaySupplier = new DevExpress.XtraEditors.DateEdit();
		this.txtPaySupplierAddress = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl45 = new DevExpress.XtraEditors.LabelControl();
		this.txtPaySupplierOffice = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierMob = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierOtherName = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierSurname = new DevExpress.XtraEditors.TextEdit();
		this.txtPaySupplierName = new DevExpress.XtraEditors.TextEdit();
		this.labelControl40 = new DevExpress.XtraEditors.LabelControl();
		this.lookUpSupplierPayment = new DevExpress.XtraEditors.LookUpEdit();
		this.lookUpInvoices = new DevExpress.XtraEditors.LookUpEdit();
		this.gridSupplierLedger = new DevExpress.XtraGrid.GridControl();
		this.gridViewSL = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
		this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.groupControl6).BeginInit();
		this.groupControl6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAccountNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.VoucherItemLookUp).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStandingBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboAccount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVoucherNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintInvoice.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOffice.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierMob.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOtherName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierSurname.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpSupplierPayment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpInvoices.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLedger).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSL).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printableComponentLink1.ImageCollection).BeginInit();
		base.SuspendLayout();
		this.groupControl6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.groupControl6.Controls.Add(this.labelControl3);
		this.groupControl6.Controls.Add(this.labelControl2);
		this.groupControl6.Controls.Add(this.txtAccountNo);
		this.groupControl6.Controls.Add(this.txtStandingBalance);
		this.groupControl6.Controls.Add(this.cboAccount);
		this.groupControl6.Controls.Add(this.lblBankAccNo);
		this.groupControl6.Controls.Add(this.lblPayAs);
		this.groupControl6.Controls.Add(this.txtVoucherNo);
		this.groupControl6.Controls.Add(this.chkPrintInvoice);
		this.groupControl6.Controls.Add(this.labelControl1);
		this.groupControl6.Controls.Add(this.labelControl91);
		this.groupControl6.Controls.Add(this.labelControl136);
		this.groupControl6.Controls.Add(this.labelControl46);
		this.groupControl6.Controls.Add(this.btnPayBills);
		this.groupControl6.Controls.Add(this.txtPaySupplierAmount);
		this.groupControl6.Controls.Add(this.dtPaySupplier);
		this.groupControl6.Controls.Add(this.txtPaySupplierAddress);
		this.groupControl6.Controls.Add(this.labelControl45);
		this.groupControl6.Controls.Add(this.txtPaySupplierOffice);
		this.groupControl6.Controls.Add(this.txtPaySupplierMob);
		this.groupControl6.Controls.Add(this.txtPaySupplierOtherName);
		this.groupControl6.Controls.Add(this.txtPaySupplierSurname);
		this.groupControl6.Controls.Add(this.txtPaySupplierName);
		this.groupControl6.Controls.Add(this.labelControl40);
		this.groupControl6.Controls.Add(this.lookUpSupplierPayment);
		this.groupControl6.Controls.Add(this.lookUpInvoices);
		this.groupControl6.Location = new System.Drawing.Point(3, 127);
		this.groupControl6.Name = "groupControl6";
		this.groupControl6.ShowCaption = false;
		this.groupControl6.Size = new System.Drawing.Size(279, 505);
		this.groupControl6.TabIndex = 6;
		this.groupControl6.Text = "Supplier details";
		this.labelControl3.Location = new System.Drawing.Point(7, 268);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(38, 13);
		this.labelControl3.TabIndex = 45;
		this.labelControl3.Text = "Acc Bal:";
		this.labelControl2.Location = new System.Drawing.Point(7, 242);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(43, 13);
		this.labelControl2.TabIndex = 44;
		this.labelControl2.Text = "Account:";
		this.txtAccountNo.Location = new System.Drawing.Point(149, 450);
		this.txtAccountNo.MenuManager = this.ribbonControl1;
		this.txtAccountNo.Name = "txtAccountNo";
		this.txtAccountNo.Properties.ReadOnly = true;
		this.txtAccountNo.Size = new System.Drawing.Size(100, 20);
		this.txtAccountNo.TabIndex = 43;
		this.txtAccountNo.Visible = false;
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[5]
		{
			this.ribbonControl1.ExpandCollapseItem,
			this.barButtonItem1,
			this.barButtonItem2,
			this.barButtonItem3,
			this.barEditItem1
		});
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 10;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.VoucherItemLookUp });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowCategoryInCaption = false;
		this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.Size = new System.Drawing.Size(923, 123);
		this.barButtonItem1.Caption = "Print";
		this.barButtonItem1.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem1.Glyph");
		this.barButtonItem1.Id = 6;
		this.barButtonItem1.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem1.LargeGlyph");
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Preview";
		this.barButtonItem2.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem2.Glyph");
		this.barButtonItem2.Id = 7;
		this.barButtonItem2.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem2.LargeGlyph");
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Export";
		this.barButtonItem3.Glyph = (System.Drawing.Image)resources.GetObject("barButtonItem3.Glyph");
		this.barButtonItem3.Id = 8;
		this.barButtonItem3.LargeGlyph = (System.Drawing.Image)resources.GetObject("barButtonItem3.LargeGlyph");
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barEditItem1.Edit = this.VoucherItemLookUp;
		this.barEditItem1.Id = 9;
		this.barEditItem1.Name = "barEditItem1";
		this.barEditItem1.Width = 120;
		this.barEditItem1.HiddenEditor += new DevExpress.XtraBars.ItemClickEventHandler(barEditItem1_HiddenEditor_1);
		this.VoucherItemLookUp.AutoHeight = false;
		this.VoucherItemLookUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.VoucherItemLookUp.Name = "VoucherItemLookUp";
		this.VoucherItemLookUp.NullText = "[Select Vouchers]";
		this.VoucherItemLookUp.PopupFormMinSize = new System.Drawing.Size(880, 550);
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[2] { this.ribbonPageGroup1, this.ribbonPageGroup2 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "ribbonPage1";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.ItemLinks.Add(this.barEditItem1);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.ShowCaptionButton = false;
		this.ribbonPageGroup1.Text = "Paid Vouchers";
		this.ribbonPageGroup1.Visible = false;
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.ShowCaptionButton = false;
		this.ribbonPageGroup2.Text = "Supplier Ledger";
		this.txtStandingBalance.Location = new System.Drawing.Point(66, 261);
		this.txtStandingBalance.MenuManager = this.ribbonControl1;
		this.txtStandingBalance.Name = "txtStandingBalance";
		this.txtStandingBalance.Properties.DisplayFormat.FormatString = "{0:#,#.0}";
		this.txtStandingBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtStandingBalance.Properties.EditFormat.FormatString = "{0:#,#.0}";
		this.txtStandingBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.txtStandingBalance.Properties.ReadOnly = true;
		this.txtStandingBalance.Size = new System.Drawing.Size(206, 20);
		this.txtStandingBalance.TabIndex = 42;
		this.cboAccount.Location = new System.Drawing.Point(66, 235);
		this.cboAccount.MenuManager = this.ribbonControl1;
		this.cboAccount.Name = "cboAccount";
		this.cboAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboAccount.Size = new System.Drawing.Size(206, 20);
		this.cboAccount.TabIndex = 41;
		this.cboAccount.SelectedIndexChanged += new System.EventHandler(cboAccount_SelectedIndexChanged);
		this.lblBankAccNo.Location = new System.Drawing.Point(66, 453);
		this.lblBankAccNo.Name = "lblBankAccNo";
		this.lblBankAccNo.Size = new System.Drawing.Size(63, 13);
		this.lblBankAccNo.TabIndex = 40;
		this.lblBankAccNo.Text = "labelControl2";
		this.lblBankAccNo.Visible = false;
		this.lblPayAs.Location = new System.Drawing.Point(7, 327);
		this.lblPayAs.Name = "lblPayAs";
		this.lblPayAs.Size = new System.Drawing.Size(51, 13);
		this.lblPayAs.TabIndex = 39;
		this.lblPayAs.Text = "Pay Mode:";
		this.txtVoucherNo.Location = new System.Drawing.Point(64, 320);
		this.txtVoucherNo.MenuManager = this.ribbonControl1;
		this.txtVoucherNo.Name = "txtVoucherNo";
		this.txtVoucherNo.Size = new System.Drawing.Size(208, 20);
		this.txtVoucherNo.TabIndex = 38;
		this.chkPrintInvoice.Location = new System.Drawing.Point(64, 427);
		this.chkPrintInvoice.MenuManager = this.ribbonControl1;
		this.chkPrintInvoice.Name = "chkPrintInvoice";
		this.chkPrintInvoice.Properties.Caption = "Print Voucher";
		this.chkPrintInvoice.Size = new System.Drawing.Size(170, 19);
		this.chkPrintInvoice.TabIndex = 36;
		this.labelControl1.Location = new System.Drawing.Point(66, 216);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(71, 13);
		this.labelControl1.TabIndex = 34;
		this.labelControl1.Text = "Payment Mode";
		this.labelControl91.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl91.Location = new System.Drawing.Point(7, 353);
		this.labelControl91.Name = "labelControl91";
		this.labelControl91.Size = new System.Drawing.Size(44, 13);
		this.labelControl91.TabIndex = 27;
		this.labelControl91.Text = "Invoices:";
		this.labelControl136.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl136.Location = new System.Drawing.Point(7, 379);
		this.labelControl136.Name = "labelControl136";
		this.labelControl136.Size = new System.Drawing.Size(27, 13);
		this.labelControl136.TabIndex = 17;
		this.labelControl136.Text = "Date:";
		this.labelControl46.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl46.Location = new System.Drawing.Point(7, 405);
		this.labelControl46.Name = "labelControl46";
		this.labelControl46.Size = new System.Drawing.Size(41, 13);
		this.labelControl46.TabIndex = 16;
		this.labelControl46.Text = "Amount:";
		this.btnPayBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnPayBills.Location = new System.Drawing.Point(64, 476);
		this.btnPayBills.Name = "btnPayBills";
		this.btnPayBills.Size = new System.Drawing.Size(208, 23);
		this.btnPayBills.TabIndex = 15;
		this.btnPayBills.Text = "Continue";
		this.btnPayBills.Click += new System.EventHandler(btnPayBills_Click);
		this.txtPaySupplierAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.txtPaySupplierAmount.Location = new System.Drawing.Point(64, 398);
		this.txtPaySupplierAmount.Name = "txtPaySupplierAmount";
		this.txtPaySupplierAmount.Properties.Mask.EditMask = "n0";
		this.txtPaySupplierAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtPaySupplierAmount.Size = new System.Drawing.Size(208, 20);
		this.txtPaySupplierAmount.TabIndex = 14;
		this.dtPaySupplier.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dtPaySupplier.EditValue = null;
		this.dtPaySupplier.Location = new System.Drawing.Point(64, 372);
		this.dtPaySupplier.Name = "dtPaySupplier";
		this.dtPaySupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtPaySupplier.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtPaySupplier.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtPaySupplier.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtPaySupplier.Size = new System.Drawing.Size(208, 20);
		this.dtPaySupplier.TabIndex = 13;
		this.txtPaySupplierAddress.Location = new System.Drawing.Point(66, 166);
		this.txtPaySupplierAddress.Name = "txtPaySupplierAddress";
		this.txtPaySupplierAddress.Properties.ReadOnly = true;
		this.txtPaySupplierAddress.Size = new System.Drawing.Size(208, 44);
		this.txtPaySupplierAddress.TabIndex = 11;
		this.labelControl45.Location = new System.Drawing.Point(11, 77);
		this.labelControl45.Name = "labelControl45";
		this.labelControl45.Size = new System.Drawing.Size(31, 13);
		this.labelControl45.TabIndex = 7;
		this.labelControl45.Text = "Name:";
		this.txtPaySupplierOffice.Location = new System.Drawing.Point(66, 142);
		this.txtPaySupplierOffice.Name = "txtPaySupplierOffice";
		this.txtPaySupplierOffice.Properties.ReadOnly = true;
		this.txtPaySupplierOffice.Size = new System.Drawing.Size(208, 20);
		this.txtPaySupplierOffice.TabIndex = 6;
		this.txtPaySupplierMob.Location = new System.Drawing.Point(66, 118);
		this.txtPaySupplierMob.Name = "txtPaySupplierMob";
		this.txtPaySupplierMob.Properties.ReadOnly = true;
		this.txtPaySupplierMob.Size = new System.Drawing.Size(208, 20);
		this.txtPaySupplierMob.TabIndex = 5;
		this.txtPaySupplierOtherName.Location = new System.Drawing.Point(66, 94);
		this.txtPaySupplierOtherName.Name = "txtPaySupplierOtherName";
		this.txtPaySupplierOtherName.Properties.ReadOnly = true;
		this.txtPaySupplierOtherName.Size = new System.Drawing.Size(208, 20);
		this.txtPaySupplierOtherName.TabIndex = 4;
		this.txtPaySupplierSurname.Location = new System.Drawing.Point(66, 70);
		this.txtPaySupplierSurname.Name = "txtPaySupplierSurname";
		this.txtPaySupplierSurname.Properties.ReadOnly = true;
		this.txtPaySupplierSurname.Size = new System.Drawing.Size(208, 20);
		this.txtPaySupplierSurname.TabIndex = 3;
		this.txtPaySupplierName.Location = new System.Drawing.Point(6, 46);
		this.txtPaySupplierName.Name = "txtPaySupplierName";
		this.txtPaySupplierName.Properties.ReadOnly = true;
		this.txtPaySupplierName.Size = new System.Drawing.Size(268, 20);
		this.txtPaySupplierName.TabIndex = 2;
		this.txtPaySupplierName.TextChanged += new System.EventHandler(txtPaySupplierName_TextChanged);
		this.labelControl40.Location = new System.Drawing.Point(4, 3);
		this.labelControl40.Name = "labelControl40";
		this.labelControl40.Size = new System.Drawing.Size(64, 13);
		this.labelControl40.TabIndex = 1;
		this.labelControl40.Text = "Find supplier:";
		this.lookUpSupplierPayment.Location = new System.Drawing.Point(6, 22);
		this.lookUpSupplierPayment.Name = "lookUpSupplierPayment";
		this.lookUpSupplierPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpSupplierPayment.Properties.NullText = "Select supplier";
		this.lookUpSupplierPayment.Properties.NullValuePrompt = "Select supplier";
		this.lookUpSupplierPayment.Properties.PopupFormMinSize = new System.Drawing.Size(850, 600);
		this.lookUpSupplierPayment.Size = new System.Drawing.Size(268, 20);
		this.lookUpSupplierPayment.TabIndex = 0;
		this.lookUpSupplierPayment.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(lookUpSupplierPayment_Closed);
		this.lookUpInvoices.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lookUpInvoices.Location = new System.Drawing.Point(64, 346);
		this.lookUpInvoices.Name = "lookUpInvoices";
		this.lookUpInvoices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpInvoices.Properties.NullText = "";
		this.lookUpInvoices.Properties.PopupFormMinSize = new System.Drawing.Size(500, 400);
		this.lookUpInvoices.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
		this.lookUpInvoices.Size = new System.Drawing.Size(208, 20);
		this.lookUpInvoices.TabIndex = 24;
		this.gridSupplierLedger.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridSupplierLedger.Location = new System.Drawing.Point(288, 129);
		this.gridSupplierLedger.MainView = this.gridViewSL;
		this.gridSupplierLedger.Name = "gridSupplierLedger";
		this.gridSupplierLedger.Size = new System.Drawing.Size(634, 503);
		this.gridSupplierLedger.TabIndex = 8;
		this.gridSupplierLedger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSL });
		this.gridViewSL.GridControl = this.gridSupplierLedger;
		this.gridViewSL.Name = "gridViewSL";
		this.gridViewSL.OptionsBehavior.Editable = false;
		this.gridViewSL.OptionsDetail.AutoZoomDetail = true;
		this.gridViewSL.OptionsView.ShowGroupPanel = false;
		this.printingSystem1.Links.AddRange(new object[1] { this.printableComponentLink1 });
		this.printingSystem1.ShowMarginsWarning = false;
		this.printableComponentLink1.ImageCollection.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("printableComponentLink1.ImageCollection.ImageStream");
		this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
		this.printableComponentLink1.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
		this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(923, 635);
		base.Controls.Add(this.gridSupplierLedger);
		base.Controls.Add(this.groupControl6);
		base.Controls.Add(this.ribbonControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "SupplierPayment";
		this.Ribbon = this.ribbonControl1;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Supplier Payment";
		((System.ComponentModel.ISupportInitialize)this.groupControl6).EndInit();
		this.groupControl6.ResumeLayout(false);
		this.groupControl6.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAccountNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.VoucherItemLookUp).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStandingBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboAccount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVoucherNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkPrintInvoice.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPaySupplier.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOffice.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierMob.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierOtherName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierSurname.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpSupplierPayment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpInvoices.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLedger).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSL).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printableComponentLink1.ImageCollection).EndInit();
		base.ResumeLayout(false);
	}
}
