using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.ExtremeMessenger;
using AlienAge.Security;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Data.Mask;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Properties;

namespace I_Xtreme.DialogForms;

public class StudentFeesPayment : RibbonForm
{
	private readonly string formMode = string.Empty;

	private SqlTransaction __TranS;

	private SqlTransaction _transPrep;

	private DataTable dt_FeesLedger;

	private DataTable dataTable;

	private DataSet dataSet;

	private DataTable dt_s;

	private DataTable dt_PI;

	private DataTable _dt_TA;

	private string accGroup = string.Empty;

	private MemoryStream stream;

	private double feesRequired = 0.0;

	private string _AccountNumber = string.Empty;

	private string accountNo_To_DEL = string.Empty;

	private string bankID_To_DEL = string.Empty;

	private string contactNo1 = string.Empty;

	private string contactNo2 = string.Empty;

	private double NewAmount = 0.0;

	private double OLD_BAL = 0.0;

	private int k = 0;

	private int paymentID = 0;

	private string ____CMD_TEXT = string.Empty;

	private readonly string connectionString = DataConnection.ConnectToDatabase();

	public StartOrStopTimer RefreshList;

	private IContainer components = null;

	private RibbonControl ribbonControl1;

	private RibbonPage ribbonPage1;

	private RibbonStatusBar ribbonStatusBar1;

	private SimpleButton btnProcessPayment;

	private TextEdit txtReceiptNumber;

	private DateEdit dtPayment;

	private MyGridControl gridStudentPayment;

	private MyGridView gridViewStudentPayment;

	private PopupMenu popupMenu1;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarEditItem barEditItem3;

	private RepositoryItemPictureEdit picStudentPicture;

	private RibbonPageGroup ribbonPageGroup2;

	private BarStaticItem barStaticItem1;

	private BarStaticItem barStaticItem2;

	private BarStaticItem barStaticItem3;

	private BarStaticItem lblName;

	private BarStaticItem lblClass;

	private BarStaticItem lblStream;

	private BarStaticItem lblSemester;

	private BarButtonItem barButtonItem6;

	private RibbonPageGroup ribbonPageGroup3;

	private BarStaticItem barStaticItem5;

	private BarButtonItem barButtonItem7;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutBankSlip;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem9;

	private SimpleButton simpleButton1;

	private TextEdit txtConfirmStudentNumber;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem11;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem5;

	private GridLookUpEdit gridLookUpEdit1;

	private LayoutControlItem layoutControlItem12;

	private DXValidationProvider dxValidationProvider1;

	private ToolTipController toolTipController1;

	private LayoutControlItem layoutControlItem14;

	private TextEdit lookUpStudents;

	private BarStaticItem lblStudentNo;

	private MyGridControl gridPayableItems;

	private MyGridView gridView1;

	private BarButtonItem barButtonItem8;

	private RibbonPageGroup ribbonPageGroup1;

	private Timer timer1;

	private BarEditItem txtDateTime;

	private ComboBoxEdit cboStudents;

	private LayoutControlItem layoutControlItem2;

	private RepositoryItemComboBox repositoryItemComboBox2;

	private ComboBoxEdit cboPayToAccount;

	private TextEdit txtAccNo;

	private LayoutControlItem layoutControlItem7;

	private BarStaticItem lblStudyStatus;

	private DXValidationProvider dxValidationProvider2;

	private GridView gridLookUpEdit1View;

	private PopupControlContainer popupControlContainer1;

	private LayoutControl layoutControl2;

	private SimpleButton simpleButton4;

	private SimpleButton simpleButton3;

	private TextEdit txtAmount;

	private ComboBoxEdit cboItem;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem13;

	private LayoutControlItem layoutControlItem16;

	private EmptySpaceItem emptySpaceItem1;

	private BarButtonItem barButtonItem9;

	private DateEdit dtBillingDate;

	private LayoutControlItem layoutControlItem17;

	private BarButtonItem barButtonItem10;

	private BarButtonItem barButtonItem11;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColRef;

	private GridColumn gridColDate;

	private GridColumn gridColParticulars;

	private GridColumn gridColBills;

	private GridColumn gridColPayment;

	private GridColumn gridColBalance;

	private GridColumn gridColAmount;

	private GridColumn gridColSemester;

	private GridColumn gridColumn3;

	private BarStaticItem barStaticItem6;

	private BarStaticItem barStaticItem7;

	private BarStaticItem lblIsOnBursary;

	private BarStaticItem lblBursaryScheme;

	private BarStaticItem lblDiscount;

	private BarStaticItem barStaticItem8;

	private RepositoryItemCheckEdit repositoryItemCheckEdit1;

	private BarButtonItem barButtonItem12;

	private RepositoryItemToggleSwitch repositoryItemToggleSwitch1;

	private BarButtonItem barButtonItem13;

	private RibbonPageGroup ribbonPageGroup5;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private BarButtonItem barButtonItem14;

	private LayoutControlItem layoutControlItem4;

	private NavigationFrame navigationFrame1;

	private NavigationPage navigationPage1;

	private NavigationPage navigationPage2;

	private GridControl gridControl1;

	private GridView gridView2;

	private LayoutControlItem layoutControlItem3;

	private GridColumn gridColumn4;

	private ToggleSwitch toggleSwitch1;

	private LayoutControlItem layoutControlItem15;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private RepositoryItemTextEdit repositoryItemTextEdit2;

	private CheckEdit checkEdit2;

	private LayoutControlItem layoutControlItem18;

	private BarButtonItem barButtonItem15;

	private void AddFeesPayment(string Particulars, string AccNo, double amount, string _receiptNo, string _capDate, double feesBalance, string Narration, string ModeOfPayment)
	{
		gridView1.CloseEditor();
		DateTime dateTime = dtPayment.DateTime;
		double num = amount;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		__TranS = sqlConnection.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = __TranS,
			Connection = sqlConnection,
			CommandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,CaptureDate,IsSent,ReceivedBy,StudentName,Narration,ClassName) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@CaptureDate,@IsSent,@ReceivedBy,@StudentName,@Narration,@ClassName)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = lblStudentNo.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@DateOfPayment", SqlDbType.DateTime);
			sqlParameter.Value = dateTime.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
			sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = AccNo;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
			sqlParameter.Value = Narration;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
			sqlParameter.Value = Particulars;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
			sqlParameter.Value = 0;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
			sqlParameter.Value = num;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Balance", SqlDbType.Money);
			sqlParameter.Value = feesBalance;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar, 50);
			sqlParameter.Value = ModeOfPayment;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BankId", SqlDbType.VarChar, 9);
			sqlParameter.Value = txtAccNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BankSlipNo", SqlDbType.VarChar, 50);
			sqlParameter.Value = _receiptNo;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
			sqlParameter.Value = _capDate;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IsSent", SqlDbType.Bit);
			sqlParameter.Value = 0;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ReceivedBy", SqlDbType.VarChar, 50);
			sqlParameter.Value = CurrentUser.UserFullName;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@StudentName", SqlDbType.VarChar, 100);
			sqlParameter.Value = lblName.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ClassName", SqlDbType.VarChar, 100);
			sqlParameter.Value = lblClass.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		if (Particulars == "Waiver on Fees")
		{
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = __TranS,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration,@TrRef)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter2.Value = AccNo;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter2.Value = "Waiver on Fees";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter2.Value = WorkingSemesters.GetWorkingSemester();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter2.Value = dateTime.ToShortDateString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter2.Value = dateTime.ToString("MMMM");
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter2.Value = dateTime.Year;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
				sqlParameter2.Value = num;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Credit", SqlDbType.Money);
				sqlParameter2.Value = 0;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter2.Value = _capDate;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter2.Value = lblName.Caption + "-" + lblClass.Caption;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
				sqlParameter2.Value = _receiptNo;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using SqlCommand sqlCommand3 = new SqlCommand
			{
				Transaction = __TranS,
				Connection = sqlConnection,
				CommandText = "INSERT INTO Expenses (ExpenseName,expenseSource,qty,units,ChequeNo,VoucherNo,ExpenseValue,DateOfExpense,SemesterId,Narration,CaptureDate,PaymentMode,NarrationBig,Contact,Address,Payee)VALUES(@ExpenseName,@expenseSource,@qty,@units,@ChequeNo,@VoucherNo,@ExpenseValue,@DateOfExpense,@SemesterId,@Narration,@CaptureDate,@PaymentMode,@NarrationBig,@Contact,@Address,@Payee)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@ExpenseName", SqlDbType.VarChar, 50);
			sqlParameter3.Value = lblName.Caption + "-" + lblClass.Caption;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@expenseSource", SqlDbType.VarChar, 50);
			sqlParameter3.Value = "Waiver on Fees";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@qty", SqlDbType.Int);
			sqlParameter3.Value = 1;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@units", SqlDbType.VarChar, 35);
			sqlParameter3.Value = string.Empty;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@ChequeNo", SqlDbType.VarChar, 30);
			sqlParameter3.Value = "";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 30);
			sqlParameter3.Value = "";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@ExpenseValue", SqlDbType.Money);
			sqlParameter3.Value = num;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@DateOfExpense", SqlDbType.DateTime);
			sqlParameter3.Value = dateTime.ToShortDateString();
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
			sqlParameter3.Value = WorkingSemesters.GetWorkingSemester();
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
			sqlParameter3.Value = Narration;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
			sqlParameter3.Value = _capDate;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@PaymentMode", SqlDbType.VarChar, 20);
			sqlParameter3.Value = "Waiver on Fees";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@NarrationBig", SqlDbType.NVarChar, 500);
			sqlParameter3.Value = Narration;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Contact", SqlDbType.NVarChar, 50);
			sqlParameter3.Value = "";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Address", SqlDbType.NVarChar, 100);
			sqlParameter3.Value = "";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Payee", SqlDbType.NVarChar, 100);
			sqlParameter3.Value = "";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
		}
		if (Particulars != "Waiver on Fees")
		{
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Transaction = __TranS,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration,userId,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration,@userId,@TrRef)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter4.Value = AccNo;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter4.Value = $"{lblName.Caption}-{lblStudentNo.Caption}";
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter4.Value = lblSemester.Caption;
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
				sqlParameter4 = sqlCommand4.Parameters.Add("@Credit", SqlDbType.Money);
				sqlParameter4.Value = num;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter4.Value = _capDate;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@Narration", SqlDbType.VarChar);
				sqlParameter4.Value = Particulars;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@userId", SqlDbType.VarChar, 30);
				sqlParameter4.Value = CurrentUser.GetSystemUser();
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlParameter4 = sqlCommand4.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
				sqlParameter4.Value = _receiptNo;
				sqlParameter4.Direction = ParameterDirection.Input;
				sqlCommand4.ExecuteNonQuery();
			}
			using SqlCommand sqlCommand5 = new SqlCommand
			{
				Transaction = __TranS,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration,userId,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration,@userId,@TrRef)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter5 = sqlCommand5.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter5.Value = txtAccNo.Text;
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter5.Value = lblSemester.Caption;
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@_date", SqlDbType.DateTime);
			sqlParameter5.Value = dtPayment.DateTime.ToShortDateString();
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@month", SqlDbType.VarChar, 9);
			sqlParameter5.Value = dtPayment.DateTime.ToString("MMMM");
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter5.Value = dtPayment.DateTime.Year;
			sqlParameter5 = sqlCommand5.Parameters.Add("@Debit", SqlDbType.Money);
			sqlParameter5.Value = num;
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
			sqlParameter5.Value = $"{lblName.Caption}-{lblStudentNo.Caption}, {Particulars}";
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@Narration", SqlDbType.VarChar);
			sqlParameter5.Value = Particulars;
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
			sqlParameter5.Value = _capDate;
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@userId", SqlDbType.VarChar, 30);
			sqlParameter5.Value = CurrentUser.GetSystemUser();
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlParameter5 = sqlCommand5.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
			sqlParameter5.Value = _receiptNo;
			sqlParameter5.Direction = ParameterDirection.Input;
			sqlCommand5.ExecuteNonQuery();
		}
		__TranS.Commit();
		sqlConnection.Close();
		if (SchoolInfoTemp.SendSMS)
		{
			SMSGateWay sMSGateWay = new SMSGateWay(DataConnection.ConnectToDatabase());
			sMSGateWay.InitializeAccount();
			string message = feesBalance <= 0.0
				? string.Format("Dear Parent, thank you for paying UGX {0} for {1} on {2}. Fees fully cleared.\n- {3}", amount.ToString("#,#"), lblName.Caption, DateTime.Now.ToString("dd-MMM-yyyy"), SMSGateWay.SMSSender)
				: string.Format("Dear Parent, thank you for paying UGX {0} for {1} on {2}. Outstanding balance: UGX {3}.\n- {4}", amount.ToString("#,#"), lblName.Caption, DateTime.Now.ToString("dd-MMM-yyyy"), feesBalance.ToString("#,#"), SMSGateWay.SMSSender);
			if (!string.IsNullOrEmpty(contactNo1))
			{
				string recipients = "256" + contactNo1.Substring(1, 9);
				sMSGateWay.TrySendSMSViaPOST(recipients, message, out _);
			}
			if (!string.IsNullOrEmpty(contactNo2))
			{
				string recipients2 = "256" + contactNo2.Substring(1, 9);
				sMSGateWay.TrySendSMSViaPOST(recipients2, message, out _);
			}
		}
	}

	private int[] StockItemDetails(string Item)
	{
		int[] array = new int[2];
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_StockItems WHERE AssetName = '{Item}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			array[0] = Convert.ToInt32(dataTable.Rows[0]["id"].ToString());
			array[1] = Convert.ToInt32(dataTable.Rows[0]["Qty"].ToString());
		}
		return array;
	}

	private void UpdateStockItems(string Item, int Qty)
	{
		int num = StockItemDetails(Item)[0];
		int num2 = StockItemDetails(Item)[1];
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_StockItems SET Qty=@Qty WHERE id=@id",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Qty", SqlDbType.Int);
		sqlParameter.Value = Qty + num2;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
		sqlParameter.Value = num;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlCommand.Clone();
	}

	private void AddPIKPayment(string Particulars, string AccNo, string _receiptNo, string _capDate, int Qty)
	{
		DateTime dateTime = dtPayment.DateTime;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,CaptureDate,IsSent,ReceivedBy,StudentName,PIKPaid,PIKQty) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@CaptureDate,@IsSent,@ReceivedBy,@StudentName,@PIKPaid,@PIKQty)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
		sqlParameter.Value = lblStudentNo.Caption;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@DateOfPayment", SqlDbType.DateTime);
		sqlParameter.Value = dateTime.ToShortDateString();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
		sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
		sqlParameter.Value = AccNo;
		sqlParameter.Direction = ParameterDirection.Input;
		string empty = string.Empty;
		empty = ((Qty <= 1) ? (Qty + " " + Particulars) : (Qty + " " + Particulars + "s"));
		sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
		sqlParameter.Value = empty;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
		sqlParameter.Value = 0;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
		sqlParameter.Value = 0;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Balance", SqlDbType.Money);
		sqlParameter.Value = 0;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar, 50);
		sqlParameter.Value = "PIK";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@BankId", SqlDbType.VarChar, 9);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@BankSlipNo", SqlDbType.VarChar, 50);
		sqlParameter.Value = _receiptNo;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
		sqlParameter.Value = _capDate;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@IsSent", SqlDbType.Bit);
		sqlParameter.Value = 0;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@ReceivedBy", SqlDbType.VarChar, 50);
		sqlParameter.Value = CurrentUser.UserFullName;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@StudentName", SqlDbType.VarChar, 100);
		sqlParameter.Value = lblName.Caption;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@PIKPaid", SqlDbType.Bit);
		sqlParameter.Value = 1;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@PIKQty", SqlDbType.Int);
		sqlParameter.Value = Qty;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			UpdateStockItems(Particulars, Qty);
			sqlConnection.Close();
		}
	}

	private static bool BankSlipNoExists(string receipNo)
	{
		bool flag = false;
		string selectCommandText = $"SELECT * FROM FeesPayment WHERE BankSlipNo='{receipNo}'";
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "FeesPayment");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			return true;
		}
		return false;
	}

	private static string DuplicateReceiptNoWarning(string receipNo)
	{
		string result = string.Empty;
		string selectCommandText = $"SELECT s.fullName, s.ClassId, s.StreamId, f.BankSlipNo FROM  FeesPayment f INNER JOIN tbl_Stud s ON f.StudentNumber = s.StudentNumber WHERE f.BankSlipNo = '{receipNo}'";
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "FeesPayment");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = string.Format("Receipt#: {0} is already assigned to:\n{1}\nClass: {2}\nStream: {3}", receipNo, dataRow["fullName"], dataRow["ClassId"], dataRow["StreamId"]);
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
		return result;
	}

	public StudentFeesPayment(string FormMode)
	{
		InitializeComponent();
		LoadAppendableItems();
		barEditItem3.EditValue = ByteImageConverter.ToByteArray(Resources.Default, ImageFormat.Png);
		LoadTransactingAccount();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboStudents });
		cboStudents.SelectedIndex = -1;
		formMode = FormMode;
		if (CurrentUser.CanBillStudent)
		{
			barButtonItem9.Enabled = true;
		}
		else
		{
			barButtonItem9.Enabled = false;
		}
		if (CurrentUser.CanPayInFees)
		{
			btnProcessPayment.Enabled = true;
		}
		else
		{
			btnProcessPayment.Enabled = false;
		}
		if (CurrentUser.CanEditFees)
		{
			barButtonItem8.Enabled = true;
			barButtonItem10.Enabled = true;
			barButtonItem13.Enabled = true;
			barButtonItem11.Enabled = true;
		}
		else
		{
			barButtonItem8.Enabled = false;
			barButtonItem10.Enabled = false;
			barButtonItem13.Enabled = false;
			barButtonItem11.Enabled = false;
		}
	}

	public StudentFeesPayment()
	{
	}

	private void ConfirmReceiptPrinting(string receiptNo)
	{
		if (Receipt.AlwaysPrintReceipt)
		{
			string s_name = $"{lblName.Caption}";
			if (Receipt.NumberOfCopies == 1)
			{
				Receipt.PrintReceipt(txtConfirmStudentNumber.Text, s_name, lblClass.Caption, lblStream.Caption, lblStudyStatus.Caption, receiptNo);
			}
			else if (Receipt.NumberOfCopies == 2)
			{
				for (int i = 0; i < 2; i++)
				{
					Receipt.PrintReceipt(txtConfirmStudentNumber.Text, s_name, lblClass.Caption, lblStream.Caption, lblStudyStatus.Caption, receiptNo);
				}
			}
			else if (Receipt.NumberOfCopies == 3)
			{
				for (int j = 0; j < 3; j++)
				{
					Receipt.PrintReceipt(txtConfirmStudentNumber.Text, s_name, lblClass.Caption, lblStream.Caption, lblStudyStatus.Caption, receiptNo);
				}
			}
		}
		if (StudentOptions.PaymentMode() == "SingleStudent")
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else if (StudentOptions.PaymentMode() == "MultipleStudents")
		{
			LoadStudentLegder();
		}
	}

	private void LoadStudentPaymentDetails()
	{
		try
		{
			using (new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				string selectCommandText = $"SELECT * from tbl_Stud WHERE StudentNumber='{StudentOptions.ActiveStudent()}'";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Classes");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					lblName.Caption = row["fullName"].ToString().ToUpper();
					txtConfirmStudentNumber.EditValue = row["StudentNumber"].ToString().ToUpper();
					lblClass.Caption = StudentOptions.ActiveClass();
					lblStream.Caption = row["StreamId"].ToString();
					lblStudyStatus.Caption = row["StudyStatus"].ToString();
					byte[] array = new byte[0];
					array = (byte[])row["picture"];
					using (stream = new MemoryStream(array))
					{
						barEditItem3.EditValue = ByteImageConverter.ToByteArray(Image.FromStream(stream), ImageFormat.Png);
					}
				}
				LoadSemesterRequiredItems(StudentOptions.ActiveStudent());
				LoadSemesterPIKItems(StudentOptions.ActiveStudent());
				LoadStudentLegder();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadStudentPaymentDetailsOld()
	{
		try
		{
			using (new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				string selectCommandText = $"SELECT * from tbl_oldStudents WHERE StudentNumber='{StudentOptions.ActiveStudent()}'";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Classes");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					lblName.Caption = row["fullName"].ToString().ToUpper();
					txtConfirmStudentNumber.EditValue = row["StudentNumber"].ToString().ToUpper();
					lblClass.Caption = StudentOptions.ActiveClass();
					lblStream.Caption = row["StreamId"].ToString();
					lblStudyStatus.Caption = row["StudyStatus"].ToString();
					byte[] array = new byte[0];
					array = (byte[])row["picture"];
					using MemoryStream memoryStream = new MemoryStream(array);
					barEditItem3.EditValue = ByteImageConverter.ToByteArray(Image.FromStream(memoryStream), ImageFormat.Png);
				}
				LoadSemesterRequiredItems(StudentOptions.ActiveStudent());
				LoadSemesterPIKItems(StudentOptions.ActiveStudent());
				LoadStudentLegderAll();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ClearFields()
	{
		Text = "Fees Payment";
		lblName.Caption = string.Empty;
		lblBursaryScheme.Caption = string.Empty;
		lblDiscount.Caption = string.Empty;
		lblIsOnBursary.Caption = string.Empty;
		txtConfirmStudentNumber.Text = string.Empty;
		lblStudentNo.Caption = string.Empty;
		lblClass.Caption = string.Empty;
		lblStream.Caption = string.Empty;
		lblStudyStatus.Caption = string.Empty;
		lookUpStudents.Text = string.Empty;
		picStudentPicture.InitialImage = null;
		gridStudentPayment.DataSource = null;
		barEditItem3.EditValue = ByteImageConverter.ToByteArray(Resources.Default, ImageFormat.Png);
	}

	private void LoadAppendableItems()
	{
		try
		{
			string selectCommandText = "SELECT        TOP (100) PERCENT gas.subAccountNo AS accNo, gas.SubAccoutName AS Particulars  FROM tbl_generalAccounts AS ga INNER JOIN  tbl_generalAccounts_Sub AS gas ON ga.accNo = gas.accNo  WHERE(ga.accName = 'Student Payments') GROUP BY gas.subAccountNo, gas.SubAccoutName ORDER BY accNo";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PayableItems");
			dt_PI = new DataTable();
			dt_PI = dataSet.Tables[0];
			foreach (DataRow row in dt_PI.Rows)
			{
				cboItem.Properties.Items.Add(row["Particulars"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSemesterPIKItems(string _studentNo)
	{
		try
		{
			if (StudentOptions.PaymentMode() != "SingleStudentOld")
			{
				string selectCommandText = $"SELECT accNo, Particulars, SUM(ISNULL(Credit, 0)) AS Amount,PIKQty FROM  FeesPayment WHERE (StudentNumber = '{_studentNo}') AND (SemesterId = '{lblSemester.Caption}') AND (Credit = 0) AND (IsPIK = 1) AND (PIKPaid=0)GROUP BY accNo, Particulars,PIKQty";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SemesterItems");
				dataTable = dataSet.Tables[0];
				gridControl1.DataSource = dataTable.DefaultView;
				return;
			}
			if (!(StudentOptions.PaymentMode() == "SingleStudentOld"))
			{
				return;
			}
			using (new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT (accNo-accNo) AS Amount,SubAccoutName AS Particulars,subAccountNo AS accNo FROM tbl_generalAccounts_Sub WHERE SubAccoutName='Fees Arrears'", DataConnection.ConnectToDatabase());
				dataSet = new DataSet();
				sqlDataAdapter2.Fill(dataSet, "SemesterItems");
				dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				gridPayableItems.DataSource = dataTable.DefaultView;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSemesterRequiredItems(string _studentNo)
	{
		try
		{
			dataTable = new DataTable();
			dataTable.Columns.Add("accNo", typeof(string));
			dataTable.Columns.Add("Particulars", typeof(string));
			dataTable.Columns.Add("Amount", typeof(double));
			dataTable.Columns.Add("PIKQty", typeof(int));
			if (StudentOptions.PaymentMode() != "SingleStudentOld")
			{
				string selectCommandText = $"SELECT accNo, Particulars, SUM(ISNULL(Credit, 0)) AS Amount FROM  FeesPayment WHERE(StudentNumber = '{_studentNo}') AND(SemesterId = '{lblSemester.Caption}') AND (Credit = 0) AND (IsPIK = 0 OR IsPIK IS NULL ) GROUP BY accNo, Particulars";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
				dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SemesterItems");
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					dataTable.Rows.Add(row["accNo"], row["Particulars"], row["Amount"], 0);
				}
				dataTable.Rows.Add("1001-0003", "B/F", 0, 0);
				gridPayableItems.DataSource = dataTable.DefaultView;
				gridView1.ClearColumnsFilter();
			}
			else
			{
				if (!(StudentOptions.PaymentMode() == "SingleStudentOld"))
				{
					return;
				}
				dataTable.Rows.Add("1001-0002", "Fees Arrears", 0, 0);
				using (new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT (accNo-accNo) AS Amount,SubAccoutName AS Particulars,subAccountNo AS accNo FROM tbl_generalAccounts_Sub WHERE SubAccoutName='Fees Arrears'", DataConnection.ConnectToDatabase());
					dataSet = new DataSet();
					sqlDataAdapter2.Fill(dataSet, "SemesterItems");
					dataTable = new DataTable();
					dataTable = dataSet.Tables[0];
					gridPayableItems.DataSource = dataTable.DefaultView;
					return;
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private string GetPreviousSemester(string currentSemester)
	{
		int num = Convert.ToInt32(currentSemester.Substring(currentSemester.IndexOf('-') + 1, 4));
		string result = string.Empty;
		if (currentSemester.Length == 10)
		{
			result = "TermIII-" + (num - 1);
		}
		else if (currentSemester.Length == 11)
		{
			result = "TermI-" + num;
		}
		else if (currentSemester.Length == 12)
		{
			result = "TermII-" + num;
		}
		return result;
	}

	private long MaxPaymentIDForSemester()
	{
		long result = 0L;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT Max(PaymentId) AS MaxID FROM FeesPayment WHERE SemesterId='{GetPreviousSemester(lblSemester.Caption)}' AND StudentNumber='{StudentOptions.ActiveStudent()}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "MaximumID");
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			result = (long.TryParse(dataSet.Tables["MaximumID"].Rows[0]["MaxID"].ToString(), out result) ? result : 0);
		}
		return result;
	}

	private double LoadBalanceFromPreviousSemester()
	{
		double result = 0.0;
		try
		{
			string selectCommandText = $"SELECT (SUM(ISNULL(Debit,0)) - SUM(ISNULL(Credit,0))) AS Total FROM  FeesPayment WHERE (PaymentId <= {MaxPaymentIDForSemester()} AND StudentNumber = '{StudentOptions.ActiveStudent()}')";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				{
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
			}
			else
			{
				result = 0.0;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	private void LoadStudentLegder()
	{
		try
		{
			double num = LoadBalanceFromPreviousSemester();
			dt_FeesLedger = new DataTable();
			dt_FeesLedger.Columns.Add("Ref", typeof(long));
			dt_FeesLedger.Columns.Add("StudentNumber", typeof(string));
			dt_FeesLedger.Columns.Add("Date", typeof(DateTime));
			dt_FeesLedger.Columns.Add("BankId", typeof(string));
			dt_FeesLedger.Columns.Add("accNo", typeof(string));
			dt_FeesLedger.Columns.Add("TRef", typeof(string));
			dt_FeesLedger.Columns.Add("Term", typeof(string));
			dt_FeesLedger.Columns.Add("Particulars", typeof(string));
			dt_FeesLedger.Columns.Add("Dr", typeof(double));
			dt_FeesLedger.Columns.Add("Cr", typeof(double));
			dt_FeesLedger.Columns.Add("Amount", typeof(double));
			dt_FeesLedger.Columns.Add("CaptureDate", typeof(string));
			dt_FeesLedger.Rows.Add(-1111, StudentOptions.ActiveStudent(), DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, $"B/F {GetPreviousSemester(WorkingSemesters.GetWorkingSemester())}", num, 0, num);
			string selectCommandText = $"SELECT PaymentId AS Ref,CaptureDate, StudentNumber,DateOfPayment AS Date,BankId,accNo,BankSlipNo AS TRef,SemesterId AS Term,Particulars, ISNULL(Debit,0) AS Dr, ISNULL(Credit,0) AS Cr,(ISNULL(Debit,0)-ISNULL(Credit,0)) AS Amount FROM FeesPayment WHERE StudentNumber='{StudentOptions.ActiveStudent()}' AND SemesterId='{WorkingSemesters.GetWorkingSemester()}' ORDER BY PaymentId";
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentLedger");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				dt_FeesLedger.Rows.Add(Convert.ToInt64(row["Ref"].ToString()), row["StudentNumber"].ToString(), Convert.ToDateTime(row["Date"].ToString()), row["BankId"].ToString(), row["accNo"].ToString(), row["TRef"].ToString(), row["Term"].ToString(), row["Particulars"].ToString(), Convert.ToDouble(row["Dr"].ToString()), Convert.ToDouble(row["Cr"].ToString()), Convert.ToDouble(row["Amount"].ToString()), row["CaptureDate"].ToString());
			}
			gridStudentPayment.DataSource = dt_FeesLedger.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadStudentLegderAll()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT PaymentId AS Ref,CaptureDate, StudentNumber,DateOfPayment AS Date,BankId,accNo,BankSlipNo AS TRef,SemesterId AS Term,Particulars, ISNULL(Debit,0) AS Dr, ISNULL(Credit,0) AS Cr,(ISNULL(Debit,0)-ISNULL(Credit,0)) AS Amount FROM FeesPayment WHERE StudentNumber='{StudentOptions.ActiveStudent()}' ORDER BY PaymentId", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentLedger");
			dt_FeesLedger = new DataTable();
			dt_FeesLedger = dataSet.Tables[0];
			gridStudentPayment.DataSource = dt_FeesLedger.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridViewStudentPayment_KeyDown(object sender, KeyEventArgs e)
	{
		if (gridViewStudentPayment.FocusedRowHandle > -1)
		{
			if (e.KeyCode == Keys.Apps)
			{
				string menuCaption = $"{lblName.Caption}";
				popupMenu1.ShowCaption = true;
				DataRow dataRow = dt_FeesLedger.Rows[gridViewStudentPayment.GetFocusedDataSourceRowIndex()];
				popupMenu1.MenuCaption = menuCaption;
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
	}

	private void gridViewStudentPayment_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
	{
		if (((GridSummaryItem)e.Item).FieldName == "Bal")
		{
			double num = Convert.ToDouble(gridViewStudentPayment.Columns["Dr"].SummaryItem.SummaryValue) - Convert.ToDouble(gridViewStudentPayment.Columns["Cr"].SummaryItem.SummaryValue);
			e.TotalValue = num;
		}
	}

	private void gridViewStudentPayment_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridViewStudentPayment.FocusedRowHandle > -1)
		{
			if (e.Button == MouseButtons.Right)
			{
				string menuCaption = $"{lblName.Caption}";
				popupMenu1.ShowCaption = true;
				DataRow dataRow = dt_FeesLedger.Rows[gridViewStudentPayment.GetFocusedDataSourceRowIndex()];
				popupMenu1.MenuCaption = menuCaption;
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		PrintingSystem printingSystem = new PrintingSystem();
		CompositeLink compositeLink = new CompositeLink();
		compositeLink.Margins = new Margins(80, 80, 30, 100);
		compositeLink.Landscape = false;
		compositeLink.PageHeaderFooter = new PageHeaderFooter(null, new PageFooterArea(new string[3] { "Student's Ledger", "[Date Printed]", "[Page # of Pages #]" }, new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0), BrickAlignment.Far));
		CompositeLink compositeLink2 = compositeLink;
		PrintableComponentLink printableComponentLink = new PrintableComponentLink();
		printingSystem.ClearContent();
		printingSystem.Links.AddRange(new object[2] { printableComponentLink, compositeLink2 });
		printableComponentLink.Component = gridStudentPayment;
		compositeLink2.PrintingSystem.ClearContent();
		compositeLink2.Links.AddRange(new object[1] { printableComponentLink });
		compositeLink2.PrintingSystem = printingSystem;
		ReportHeaderStatistics(compositeLink2, $"{lblName.Caption} [{txtConfirmStudentNumber.Text}]");
		compositeLink2.ShowRibbonPreview(UserLookAndFeel.Default.ActiveLookAndFeel);
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = "Save to",
			FileName = string.Format("{0}_{1}", lblName.Caption, DateTime.Now.ToString("HHMMss")),
			RestoreDirectory = true,
			Filter = "Excel Workbook (*.Xlsx)|*.Xlsx"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			PrintingSystem printingSystem = new PrintingSystem();
			CompositeLink compositeLink = new CompositeLink
			{
				Margins = new Margins(80, 80, 30, 100),
				Landscape = false
			};
			PrintableComponentLink printableComponentLink = new PrintableComponentLink();
			printingSystem.ClearContent();
			printingSystem.Links.AddRange(new object[2] { printableComponentLink, compositeLink });
			printableComponentLink.Component = gridStudentPayment;
			compositeLink.PrintingSystem.ClearContent();
			compositeLink.Links.AddRange(new object[1] { printableComponentLink });
			compositeLink.PrintingSystem = printingSystem;
			ReportHeaderStatistics(compositeLink, $"{lblName.Caption} [{txtConfirmStudentNumber.Text}]");
			compositeLink.ExportToXlsx(saveFileDialog.FileName + ".Xlsx");
			if (XtraMessageBox.Show("Do you want to open the file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Process.Start(saveFileDialog.FileName + ".Xlsx");
			}
		}
	}

	private void FeesPayment_Load(object sender, EventArgs e)
	{
		lblSemester.Caption = WorkingSemesters.GetWorkingSemester();
		dtPayment.DateTime = DateTime.Now;
		if (StudentOptions.PaymentMode() == "SingleStudent")
		{
			LoadStudentPaymentDetails();
			txtConfirmStudentNumber.Text = StudentOptions.ActiveStudent();
			txtConfirmStudentNumber.Properties.ReadOnly = true;
			lookUpStudents.Properties.ReadOnly = true;
			lblStudentNo.Caption = StudentOptions.ActiveStudent();
			cboStudents.Enabled = false;
			gridLookUpEdit1.Enabled = false;
			simpleButton1.Enabled = false;
			____CMD_TEXT = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber";
		}
		else if (StudentOptions.PaymentMode() == "SingleStudentOld")
		{
			LoadStudentPaymentDetailsOld();
			txtConfirmStudentNumber.Properties.ReadOnly = true;
			lookUpStudents.Properties.ReadOnly = true;
			txtConfirmStudentNumber.Text = StudentOptions.ActiveStudent();
			lblStudentNo.Caption = StudentOptions.ActiveStudent();
			cboStudents.Enabled = false;
			gridLookUpEdit1.Enabled = false;
			simpleButton1.Enabled = false;
			barButtonItem12.Down = true;
			____CMD_TEXT = "UPDATE tbl_oldStudents SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber";
		}
		else if (StudentOptions.PaymentMode() == "MultipleStudents")
		{
			barEditItem3.EditValue = ByteImageConverter.ToByteArray(Resources.Default, ImageFormat.Png);
			txtConfirmStudentNumber.Properties.ReadOnly = false;
			txtConfirmStudentNumber.Focus();
			cboStudents.Enabled = true;
			gridLookUpEdit1.Enabled = true;
			simpleButton1.Enabled = true;
			____CMD_TEXT = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber";
		}
	}

	private void StudentFeesPayment_KeyDown(object sender, KeyEventArgs e)
	{
		StudentOptions.SetActiveStudent(txtConfirmStudentNumber.Text);
		if (e.KeyCode == Keys.Return)
		{
			if (txtConfirmStudentNumber.Text != string.Empty)
			{
				SearchSingleStudentByNo();
			}
			else if (lookUpStudents.Text != string.Empty)
			{
				SearchSingleStudentByName();
			}
		}
		else if (e.Control && e.KeyCode == Keys.Return)
		{
			FinalizeFeesPayment();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (txtConfirmStudentNumber.Text != string.Empty)
		{
			SearchSingleStudentByNo();
		}
		else if (lookUpStudents.Text != string.Empty)
		{
			SearchSingleStudentByName();
		}
	}

	private void AdvancedSearch()
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		waitDialogForm.Show();
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT Picture AS Img,UPPER(fullName) AS Name,UPPER(StudentNumber) AS Student#,StreamId AS Stream,Sex,cashOnAccount AS AccountBalance ,RequiredFees AS Fees FROM tbl_Stud WHERE ClassId='{cboStudents.SelectedItem}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentList");
			dt_s = new DataTable();
			dt_s = dataSet.Tables[0];
			gridLookUpEdit1View.Columns.Clear();
			gridLookUpEdit1.Properties.DataSource = dt_s;
			gridLookUpEdit1.Properties.DisplayMember = "Name";
			waitDialogForm.Close();
			gridLookUpEdit1.ShowPopup();
		}
		catch (Exception ex)
		{
			waitDialogForm.Close();
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void gridLookUpEdit1_CloseUp(object sender, CloseUpEventArgs e)
	{
		if (gridLookUpEdit1View.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt_s.Rows[gridLookUpEdit1View.GetFocusedDataSourceRowIndex()];
			txtConfirmStudentNumber.Text = dataRow["Student#"].ToString();
			lblStudentNo.Caption = dataRow["Student#"].ToString();
			feesRequired = (double.TryParse(dataRow["Fees"].ToString(), out feesRequired) ? feesRequired : 0.0);
			gridLookUpEdit1.Text = gridLookUpEdit1.Properties.DisplayMember;
			StudentOptions.SetActiveStudent(dataRow["Student#"].ToString());
			SearchSingleStudentByNo();
		}
	}

	private void UpdateCashOnAccount()
	{
		double num = Convert.ToDouble(gridView1.Columns["Amount"].SummaryItem.SummaryValue);
		double num2 = Convert.ToDouble(gridViewStudentPayment.Columns["Bal"].SummaryItem.SummaryValue) - num;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = ____CMD_TEXT,
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = txtConfirmStudentNumber.Text.Trim();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Float);
			sqlParameter.Value = num2;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
		RefreshList(timerStatus: true);
	}

	private void FinalizePIKPayment()
	{
		string empty = string.Empty;
		empty = (string.IsNullOrEmpty(txtReceiptNumber.Text) ? Guid.NewGuid().ToString().Substring(0, 6)
			.ToUpper() : txtReceiptNumber.Text);
		if (dtPayment.Text != string.Empty)
		{
			int[] selectedRows = gridView2.GetSelectedRows();
			if (selectedRows.Length == 0)
			{
				XtraMessageBox.Show("Please select an item the student is paying for.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			int result = 0;
			for (int i = 0; i < selectedRows.Length; i++)
			{
				result = (int.TryParse(gridView2.GetRowCellValue(selectedRows[i], "PIKQty").ToString(), out result) ? result : 0);
				if (result > 0)
				{
					empty3 = gridView2.GetRowCellValue(selectedRows[i], "Particulars").ToString();
					empty4 = gridView2.GetRowCellValue(selectedRows[i], "accNo").ToString();
					empty2 = CaptureDate.GetCaptureDate();
					AddPIKPayment(empty3, empty4, empty.ToUpper(), empty2, result);
				}
			}
		}
		else
		{
			dxValidationProvider1.Validate();
			dxValidationProvider2.Validate();
		}
	}

	private void FinalizeFeesPaymentWaiver(double WaiverAmt, string Narration)
	{
		string text = Guid.NewGuid().ToString().Substring(0, 6)
			.ToUpper();
		if (dtPayment.Text != string.Empty)
		{
			string empty = string.Empty;
			double num = Convert.ToDouble(gridViewStudentPayment.Columns["Bal"].SummaryItem.SummaryValue);
			empty = CaptureDate.GetCaptureDate();
			NewAmount += WaiverAmt;
			double feesBalance = num - NewAmount;
			AddFeesPayment("Waiver on Fees", "2004-0100", WaiverAmt, text.ToUpper(), empty, feesBalance, Narration, "Fees Waiver");
			UpdateCashOnAccount();
			NewAmount = 0.0;
		}
		else
		{
			dxValidationProvider1.Validate();
			dxValidationProvider2.Validate();
		}
	}

	private void FinalizeFeesPayment()
	{
		string empty = string.Empty;
		empty = (string.IsNullOrEmpty(txtReceiptNumber.Text) ? Guid.NewGuid().ToString().Substring(0, 6)
			.ToUpper() : txtReceiptNumber.Text);
		if (dtPayment.Text != string.Empty)
		{
			if (cboPayToAccount.SelectedIndex > -1)
			{
				if (!BankSlipNoExists(empty))
				{
					string empty2 = string.Empty;
					double num = Convert.ToDouble(gridViewStudentPayment.Columns["Bal"].SummaryItem.SummaryValue);
					for (int i = 0; i < gridView1.RowCount; i++)
					{
						k++;
						empty2 = CaptureDate.GetCaptureDate();
						string particulars = gridView1.GetRowCellValue(i, "Particulars").ToString();
						double result = (double.TryParse(gridView1.GetRowCellValue(i, "Amount").ToString(), out result) ? result : 0.0);
						if (result > 0.0)
						{
							NewAmount += result;
							double feesBalance = num - NewAmount;
							string accNo = gridView1.GetRowCellValue(i, "accNo").ToString();
							AddFeesPayment(particulars, accNo, result, empty.ToUpper(), empty2, feesBalance, "Fees Payment", cboPayToAccount.SelectedItem.ToString());
						}
						if (k == gridView1.RowCount)
						{
							UpdateCashOnAccount();
							NewAmount = 0.0;
						}
					}
					ConfirmReceiptPrinting(empty.ToUpper());
				}
				else
				{
					XtraMessageBox.Show(DuplicateReceiptNoWarning(empty), "Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					txtReceiptNumber.Focus();
				}
			}
			else
			{
				dxValidationProvider1.Validate();
				dxValidationProvider2.Validate();
			}
		}
		else
		{
			dxValidationProvider1.Validate();
			dxValidationProvider2.Validate();
		}
	}

	private void btnProcessPayment_Click(object sender, EventArgs e)
	{
		if (!LicenceStatus.IsTrialExpired)
		{
			if (toggleSwitch1.IsOn)
			{
				FinalizePIKPayment();
			}
			else
			{
				FinalizeFeesPayment();
			}
			LoadStudentLegder();
			LoadSemesterRequiredItems(lblStudentNo.Caption);
			LoadSemesterPIKItems(lblStudentNo.Caption);
		}
		else
		{
			XtraMessageBox.Show("Sorry! Your license expired. Please renew.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void SearchSingleStudentByNo()
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		try
		{
			bool flag = false;
			waitDialogForm.Caption = "Searching...";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE StudentNumber='{StudentOptions.ActiveStudent()}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SingleStudentSearch");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				flag = true;
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					waitDialogForm.Close();
					StudentOptions.SetActiveStudent(row["StudentNumber"].ToString());
					lblName.Caption = row["fullName"].ToString().ToUpper();
					txtConfirmStudentNumber.EditValue = row["StudentNumber"].ToString().ToUpper();
					lblClass.Caption = row["ClassId"].ToString().ToUpper();
					lblStream.Caption = row["StreamId"].ToString();
					Text = "Fees Payment-" + row["StudentId"].ToString();
					lblStudyStatus.Caption = row["StudyStatus"].ToString();
					feesRequired = (double.TryParse(row["StudyStatus"].ToString(), out feesRequired) ? feesRequired : 0.0);
					byte[] array = new byte[0];
					array = (byte[])row["picture"];
					using (MemoryStream memoryStream = new MemoryStream(array))
					{
						barEditItem3.EditValue = ByteImageConverter.ToByteArray(Image.FromStream(memoryStream), ImageFormat.Png);
					}
					contactNo1 = row["PriorityContact"].ToString();
					contactNo2 = row["OtherContact"].ToString();
				}
				LoadStudentLegder();
				LoadSemesterRequiredItems(StudentOptions.ActiveStudent());
				LoadSemesterPIKItems(StudentOptions.ActiveStudent());
				if (CurrentUser.CanBillStudent)
				{
					barButtonItem9.Enabled = true;
				}
				else
				{
					barButtonItem9.Enabled = false;
				}
				if (CurrentUser.CanPayInFees)
				{
					btnProcessPayment.Enabled = true;
				}
				else
				{
					btnProcessPayment.Enabled = false;
				}
				if (CurrentUser.CanEditFees)
				{
					barButtonItem8.Enabled = true;
					barButtonItem10.Enabled = true;
					barButtonItem13.Enabled = true;
					barButtonItem11.Enabled = true;
				}
				else
				{
					barButtonItem8.Enabled = false;
					barButtonItem10.Enabled = false;
					barButtonItem13.Enabled = false;
					barButtonItem11.Enabled = false;
				}
			}
			if (!flag)
			{
				waitDialogForm.Close();
				XtraMessageBox.Show("The student you searched does not exist.", "Search results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ClearFields();
			}
		}
		catch (Exception ex)
		{
			waitDialogForm.Close();
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void SearchSingleStudentByName()
	{
		using WaitDialogForm waitDialogForm = new WaitDialogForm();
		dt_s = new DataTable();
		dt_s.Columns.Add("StudentID", typeof(string));
		dt_s.Columns.Add("Img", typeof(byte[]));
		dt_s.Columns.Add("Name", typeof(string));
		dt_s.Columns.Add("Student#", typeof(string));
		dt_s.Columns.Add("Class", typeof(string));
		dt_s.Columns.Add("Stream", typeof(string));
		dt_s.Columns.Add("Sex", typeof(string));
		dt_s.Columns.Add("AccountBalance", typeof(string));
		dt_s.Columns.Add("Fees", typeof(double));
		try
		{
			waitDialogForm.Caption = "Searching...";
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE fullName LIKE '%{lookUpStudents.Text}%'", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SingleStudentSearch");
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					byte[] array = new byte[0];
					array = (byte[])row["picture"];
					using (new MemoryStream(array))
					{
						dt_s.Rows.Add(row["StudentID"], array, row["fullName"], row["StudentNumber"], row["ClassId"], row["StreamId"], row["Sex"], row["cashOnAccount"], row["RequiredFees"]);
					}
				}
			}
			if (dt_s.Rows.Count == 0)
			{
				waitDialogForm.Close();
				XtraMessageBox.Show("The student you searched does not exist.", "Search results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ClearFields();
				return;
			}
			waitDialogForm.Close();
			gridLookUpEdit1View.Columns.Clear();
			gridLookUpEdit1.Properties.DataSource = dt_s;
			gridLookUpEdit1.Properties.DisplayMember = "Name";
			gridLookUpEdit1.ShowPopup();
			gridLookUpEdit1View.Columns["Name"].Width = 150;
			gridLookUpEdit1View.Columns["StudentID"].Caption = "ID #";
			gridLookUpEdit1View.Columns["AccountBalance"].Visible = false;
			gridLookUpEdit1View.Columns["Img"].Visible = false;
			gridLookUpEdit1View.Columns["Student#"].Visible = false;
			gridLookUpEdit1View.Columns["Fees"].DisplayFormat.FormatType = FormatType.Numeric;
			gridLookUpEdit1View.Columns["Fees"].DisplayFormat.FormatString = "{0:#,#}";
		}
		catch (Exception ex)
		{
			waitDialogForm.Close();
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static string ReportHeaderStatistics(CompositeLink compLink, string _name)
	{
		string arg = string.Empty;
		string arg2 = string.Empty;
		string empty = string.Empty;
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SchoolName,fullContact,location FROM SchoolDetails", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "header");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				arg = FingerPrint.SchoolName;
				arg2 = row["fullContact"].ToString();
				empty = FingerPrint.Village;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return compLink.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs22{arg}\\par\r\n{arg2}\\par\r\n\\par\r\n________________________________STUDENT'S LEDGER________________________________\\par\r\n\\par\r\n{_name}\\par\r\n";
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		PrintingSystem printingSystem = new PrintingSystem();
		CompositeLink compositeLink = new CompositeLink();
		compositeLink.Margins = new Margins(80, 80, 30, 100);
		compositeLink.Landscape = false;
		compositeLink.PageHeaderFooter = new PageHeaderFooter(null, new PageFooterArea(new string[3] { "Student's Ledger", "[Date Printed]", "[Page # of Pages #]" }, new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0), BrickAlignment.Far));
		CompositeLink compositeLink2 = compositeLink;
		PrintableComponentLink printableComponentLink = new PrintableComponentLink();
		printingSystem.ClearContent();
		printingSystem.Links.AddRange(new object[2] { printableComponentLink, compositeLink2 });
		printableComponentLink.Component = gridStudentPayment;
		compositeLink2.PrintingSystem.ClearContent();
		compositeLink2.Links.AddRange(new object[1] { printableComponentLink });
		compositeLink2.PrintingSystem = printingSystem;
		ReportHeaderStatistics(compositeLink2, $"{lblName.Caption} [{lblStudentNo.Caption}]");
		compositeLink2.ShowRibbonPreview(UserLookAndFeel.Default.ActiveLookAndFeel);
	}

	private void txtReceiptNumber_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtReceiptNumber);
	}

	private void dtPayment_EditValueChanged(object sender, EventArgs e)
	{
		dxValidationProvider2.RemoveControlError(dtPayment);
		dxValidationProvider1.RemoveControlError(dtPayment);
	}

	private void lookUpStudents_TextChanged(object sender, EventArgs e)
	{
		txtConfirmStudentNumber.Text = string.Empty;
	}

	private void txtConfirmStudentNumber_TextChanged(object sender, EventArgs e)
	{
		lookUpStudents.Text = string.Empty;
	}

	private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		gridView1.HideEditor();
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = "Save to",
			FileName = string.Format("{0}_{1}", lblName.Caption, DateTime.Now.ToString("HHMMss")),
			RestoreDirectory = true,
			Filter = "Excel Workbook (*.Xlsx)|*.Xlsx"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			PrintingSystem printingSystem = new PrintingSystem();
			CompositeLink compositeLink = new CompositeLink
			{
				Margins = new Margins(80, 80, 30, 100),
				Landscape = false
			};
			PrintableComponentLink printableComponentLink = new PrintableComponentLink();
			printingSystem.ClearContent();
			printingSystem.Links.AddRange(new object[2] { printableComponentLink, compositeLink });
			printableComponentLink.Component = gridStudentPayment;
			compositeLink.PrintingSystem.ClearContent();
			compositeLink.Links.AddRange(new object[1] { printableComponentLink });
			compositeLink.PrintingSystem = printingSystem;
			ReportHeaderStatistics(compositeLink, $"{lblName.Caption} [{lblStudentNo.Caption}]");
			compositeLink.ExportToXlsx(saveFileDialog.FileName + ".Xlsx");
			if (XtraMessageBox.Show("Do you want to open the file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Process.Start(saveFileDialog.FileName + ".Xlsx");
			}
		}
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (gridViewStudentPayment.GetFocusedDataSourceRowIndex() != -1)
			{
				string s_name = $"{lblName.Caption}";
				DataRow dataRow = dt_FeesLedger.Rows[gridViewStudentPayment.GetFocusedDataSourceRowIndex()];
				if (Convert.ToDouble(dataRow["Cr"].ToString()) > 0.0)
				{
					Receipt.PrintReceipt(txtConfirmStudentNumber.Text, s_name, lblClass.Caption, lblStream.Caption, lblStudyStatus.Caption, dataRow["TRef"].ToString());
				}
				else if (Convert.ToDouble(dataRow["Cr"].ToString()) == 0.0)
				{
					XtraMessageBox.Show("Sorry! You cannot print a receipt for a debit transaction.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				XtraMessageBox.Show("Please select a transaction you want to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (gridViewStudentPayment.GetFocusedDataSourceRowIndex() != -1)
			{
				string s_name = $"{lblName.Caption}";
				DataRow dataRow = dt_FeesLedger.Rows[gridViewStudentPayment.GetFocusedDataSourceRowIndex()];
				if (Convert.ToDouble(dataRow["Cr"].ToString()) > 0.0)
				{
					Receipt.PrintReceipt(txtConfirmStudentNumber.Text, s_name, lblClass.Caption, lblStream.Caption, lblStudyStatus.Caption, dataRow["TRef"].ToString());
				}
				else if (Convert.ToDouble(dataRow["Cr"].ToString()) == 0.0)
				{
					XtraMessageBox.Show("Sorry! You cannot print a receipt for a debit transaction.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				XtraMessageBox.Show("Please select a transaction you want to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (lblName.Caption != string.Empty || txtAccNo.Text != string.Empty)
		{
			barButtonItem4.Enabled = true;
			barButtonItem5.Enabled = true;
			barButtonItem6.Enabled = true;
			barButtonItem12.Enabled = true;
			barButtonItem15.Enabled = true;
			if (CurrentUser.CanBillStudent)
			{
				barButtonItem9.Enabled = true;
			}
			else
			{
				barButtonItem9.Enabled = false;
			}
			if (CurrentUser.CanPayInFees)
			{
				btnProcessPayment.Enabled = true;
			}
			else
			{
				btnProcessPayment.Enabled = false;
			}
			if (CurrentUser.CanEditFees)
			{
				barButtonItem8.Enabled = true;
				barButtonItem10.Enabled = true;
				barButtonItem13.Enabled = true;
			}
			else
			{
				barButtonItem8.Enabled = false;
				barButtonItem10.Enabled = false;
				barButtonItem13.Enabled = false;
			}
		}
		else
		{
			btnProcessPayment.Enabled = false;
			barButtonItem15.Enabled = false;
			barButtonItem8.Enabled = false;
			barButtonItem10.Enabled = false;
			barButtonItem9.Enabled = false;
			barButtonItem4.Enabled = false;
			barButtonItem5.Enabled = false;
			barButtonItem6.Enabled = false;
			barButtonItem12.Enabled = false;
			barButtonItem13.Enabled = false;
		}
		if (gridPayableItems.DataSource != null && gridView1.RowCount > 0)
		{
			GridSummaryItem gridSummaryItem = new GridSummaryItem();
			gridSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridSummaryItem.FieldName = "Amount";
			gridView1.Columns["Amount"].SummaryItem.Assign(gridSummaryItem);
		}
	}

	private void LoadTransactingAccount()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo,gas.SubAccoutName,ga.accName AS accType FROM tbl_generalAccounts ga RIGHT OUTER JOIN tbl_generalAccounts_Sub gas ON gas.accNo = ga.accNo GROUP BY gas.subAccountNo,gas.SubAccoutName,ga.accName HAVING  (ga.accName = 'Bank Accounts' OR ga.accName = 'Cash' OR ga.accName = 'Mobile Money')", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			_dt_TA = new DataTable();
			_dt_TA = dataSet.Tables[0];
			cboPayToAccount.Properties.Items.Clear();
			foreach (DataRow row in _dt_TA.Rows)
			{
				cboPayToAccount.Properties.Items.Add(row["SubAccoutName"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboPayToAccount_Closed(object sender, ClosedEventArgs e)
	{
		dxValidationProvider1.RemoveControlError(cboPayToAccount);
		dxValidationProvider2.RemoveControlError(cboPayToAccount);
		if (cboPayToAccount.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_TA.Rows[cboPayToAccount.SelectedIndex];
			txtAccNo.Text = dataRow["subAccountNo"].ToString();
			accGroup = dataRow["accType"].ToString();
			if (accGroup.Contains("Cash"))
			{
				txtReceiptNumber.Properties.NullText = "Receipt#";
				txtReceiptNumber.Properties.NullValuePrompt = "Receipt#";
			}
			else
			{
				txtReceiptNumber.Properties.NullText = "Bankslip#.";
				txtReceiptNumber.Properties.NullValuePrompt = "Bankslip#.";
			}
		}
		else
		{
			txtAccNo.Text = string.Empty;
		}
	}

	private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridViewStudentPayment.RowCount <= 0)
		{
			return;
		}
		gridViewStudentPayment.FocusedRowHandle = gridViewStudentPayment.RowCount - 1;
		using editFeesPay editFeesPay = new editFeesPay(lblStudentNo.Caption, paymentID, OLD_BAL);
		editFeesPay.txtNumber.Text = txtConfirmStudentNumber.Text;
		editFeesPay.txtCLass.Text = lblClass.Caption;
		editFeesPay.txtFullName.Text = $"{lblName.Caption}";
		editFeesPay.editMode = "LastEntry";
		editFeesPay.bankId = bankID_To_DEL;
		editFeesPay.accNo = accountNo_To_DEL;
		editFeesPay.labelControl1.Text = "Editing can apply to both appended items and payments\nEditing will affect the last ledger entry only.";
		byte[] array = new byte[0];
		array = (byte[])barEditItem3.EditValue;
		stream = new MemoryStream(array);
		editFeesPay.pictureEdit1.Image = Image.FromStream(stream);
		if (editFeesPay.ShowDialog() == DialogResult.OK)
		{
			LoadStudentLegder();
			LoadSemesterRequiredItems(lblStudentNo.Caption);
			LoadSemesterPIKItems(lblStudentNo.Caption);
		}
	}

	private void cboItem_Closed(object sender, ClosedEventArgs e)
	{
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		popupControlContainer1.HidePopup();
	}

	private void simpleButton4_Click(object sender, EventArgs e)
	{
		double result = (double.TryParse(txtAmount.Text, out result) ? result : 0.0);
		if (cboItem.SelectedIndex > -1)
		{
			_ = dtBillingDate.DateTime;
			if (true)
			{
				try
				{
					if (result == 0.0 && !checkEdit2.Checked)
					{
						XtraMessageBox.Show("Please enter the amount", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					popupControlContainer1.HidePopup();
					string text = cboItem.SelectedItem.ToString();
					string commandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,Narration,CaptureDate,IsSent) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@Narration,@CaptureDate,@IsSent)";
					if (checkEdit2.Checked)
					{
						PayableInKind.AddNewStockItem(text);
						commandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,Narration,CaptureDate,IsSent,IsPIK,PIKPaid,PIKQty) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@Narration,@CaptureDate,@IsSent,@IsPIK,@PIKPaid,@PIKQty)";
					}
					DateTime dateTime = dtBillingDate.DateTime;
					double num = Convert.ToDouble(gridViewStudentPayment.Columns["Bal"].SummaryItem.SummaryValue) + result;
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
					string captureDate = CaptureDate.GetCaptureDate();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Transaction = sqlTransaction,
						Connection = sqlConnection,
						CommandText = commandText,
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter.Value = lblStudentNo.Caption;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@DateOfPayment", SqlDbType.DateTime);
						sqlParameter.Value = dateTime.ToShortDateString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 18);
						sqlParameter.Value = lblSemester.Caption;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
						sqlParameter.Value = _AccountNumber;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
						sqlParameter.Value = text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
						sqlParameter.Value = result;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
						sqlParameter.Value = 0;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Balance", SqlDbType.Money);
						sqlParameter.Value = num;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar, 25);
						sqlParameter.Value = string.Empty;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@BankId", SqlDbType.VarChar, 50);
						sqlParameter.Value = string.Empty;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@BankSlipNo", SqlDbType.VarChar, 50);
						sqlParameter.Value = string.Empty;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
						sqlParameter.Value = string.Empty;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
						sqlParameter.Value = captureDate;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand.Parameters.Add("@IsSent", SqlDbType.Bit);
						sqlParameter.Value = 1;
						sqlParameter.Direction = ParameterDirection.Input;
						if (checkEdit2.Checked)
						{
							sqlParameter = sqlCommand.Parameters.Add("@IsPIK", SqlDbType.Bit);
							sqlParameter.Value = 1;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@PIKPaid", SqlDbType.Bit);
							sqlParameter.Value = 0;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand.Parameters.Add("@PIKQty", SqlDbType.Int);
							sqlParameter.Value = 1;
							sqlParameter.Direction = ParameterDirection.Input;
						}
						sqlCommand.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Transaction = sqlTransaction,
						Connection = sqlConnection,
						CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = lblStudentNo.Caption;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@cashOnAccount", SqlDbType.Float);
						sqlParameter2.Value = num;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					sqlTransaction.Commit();
					sqlConnection.Close();
					LoadStudentLegder();
					LoadSemesterRequiredItems(lblStudentNo.Caption);
					LoadSemesterPIKItems(lblStudentNo.Caption);
					return;
				}
				catch (Exception ex)
				{
					XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					popupControlContainer1.HidePopup();
					return;
				}
			}
		}
		XtraMessageBox.Show("Sorry! We cannot do that. Please select Date and the item you wish to append.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void cboItem_SelectedValueChanged(object sender, EventArgs e)
	{
	}

	private void gridViewStudentPayment_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridViewStudentPayment.GetFocusedDataSourceRowIndex() >= 0)
		{
			DataRow dataRow = dt_FeesLedger.Rows[gridViewStudentPayment.GetFocusedDataSourceRowIndex()];
			paymentID = Convert.ToInt32(dataRow["Ref"].ToString());
			accountNo_To_DEL = dataRow["accNo"].ToString();
			bankID_To_DEL = dataRow["BankId"].ToString();
			OLD_BAL = Convert.ToDouble(gridViewStudentPayment.Columns["Bal"].SummaryItem.SummaryValue.ToString());
		}
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		using editFeesPay editFeesPay = new editFeesPay(lblStudentNo.Caption, paymentID, OLD_BAL);
		editFeesPay.txtNumber.Text = txtConfirmStudentNumber.Text;
		editFeesPay.txtCLass.Text = lblClass.Caption;
		editFeesPay.txtFullName.Text = $"{lblName.Caption}";
		editFeesPay.editMode = "SelectedEntry";
		editFeesPay.bankId = bankID_To_DEL;
		editFeesPay.accNo = accountNo_To_DEL;
		editFeesPay.labelControl1.Text = "Editing can apply to both appended items and payments\nEditing will affect the selected ledger entry only.";
		byte[] array = new byte[0];
		array = (byte[])barEditItem3.EditValue;
		stream = new MemoryStream(array);
		editFeesPay.pictureEdit1.Image = Image.FromStream(stream);
		if (editFeesPay.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		using LedgerUpdateProgress ledgerUpdateProgress = new LedgerUpdateProgress(lblStudentNo.Caption);
		if (ledgerUpdateProgress.ShowDialog() == DialogResult.OK)
		{
			LoadStudentLegder();
			LoadSemesterRequiredItems(lblStudentNo.Caption);
			LoadSemesterPIKItems(lblStudentNo.Caption);
		}
	}

	private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
	{
		using editFeesPay editFeesPay = new editFeesPay(lblStudentNo.Caption, paymentID, OLD_BAL);
		editFeesPay.txtNumber.Text = txtConfirmStudentNumber.Text;
		editFeesPay.txtCLass.Text = lblClass.Caption;
		editFeesPay.txtFullName.Text = $"{lblName.Caption}";
		editFeesPay.editMode = "SelectedEntry";
		editFeesPay.bankId = bankID_To_DEL;
		editFeesPay.accNo = accountNo_To_DEL;
		editFeesPay.labelControl1.Text = "Editing can apply to both appended items and payments\nEditing will affect the selected ledger entry only.";
		byte[] array = new byte[0];
		array = (byte[])barEditItem3.EditValue;
		stream = new MemoryStream(array);
		editFeesPay.pictureEdit1.Image = Image.FromStream(stream);
		if (editFeesPay.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		using LedgerUpdateProgress ledgerUpdateProgress = new LedgerUpdateProgress(lblStudentNo.Caption);
		if (ledgerUpdateProgress.ShowDialog() == DialogResult.OK)
		{
			LoadStudentLegder();
			LoadSemesterRequiredItems(lblStudentNo.Caption);
			LoadSemesterPIKItems(lblStudentNo.Caption);
		}
	}

	private void cboStudents_Closed(object sender, ClosedEventArgs e)
	{
		ClearFields();
		AdvancedSearch();
	}

	private void cboPayToAccount_QueryPopUp(object sender, CancelEventArgs e)
	{
		txtAccNo.Text = string.Empty;
	}

	private void gridViewStudentPayment_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
	{
		GridView gridView = (GridView)sender;
		if (e.Column.FieldName == "Bal" && e.IsGetData)
		{
			decimal num = default(decimal);
			int rowHandle = gridView.GetRowHandle(e.ListSourceRowIndex);
			for (int i = -1; i <= rowHandle - 1; i++)
			{
				num += Convert.ToDecimal(gridView.GetRowCellValue(i + 1, "Amount"));
			}
			e.Value = num;
		}
	}

	private void StudentFeesPayment_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (formMode == "AppendForm")
		{
			base.DialogResult = DialogResult.Yes;
		}
	}

	private void barButtonItem12_DownChanged(object sender, ItemClickEventArgs e)
	{
		if (barButtonItem12.Down)
		{
			barButtonItem12.Caption = "Collapse Ledger";
			LoadStudentLegderAll();
			barButtonItem12.LargeGlyph = Resources.emptytablerowseparator_32x32;
			barButtonItem12.Glyph = Resources.emptytablerowseparator_16x16;
		}
		else
		{
			barButtonItem12.Caption = "Expand Ledger";
			LoadStudentLegder();
			barButtonItem12.LargeGlyph = Resources.separator_32x32;
			barButtonItem12.Glyph = Resources.separator_16x16;
		}
	}

	private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridViewStudentPayment.RowCount <= 0)
		{
			return;
		}
		using editFeesPayChangeValues editFeesPayChangeValues = new editFeesPayChangeValues(lblStudentNo.Caption, paymentID, OLD_BAL);
		editFeesPayChangeValues.txtNumber.Text = txtConfirmStudentNumber.Text;
		editFeesPayChangeValues.txtCLass.Text = lblClass.Caption;
		editFeesPayChangeValues.txtFullName.Text = $"{lblName.Caption}";
		editFeesPayChangeValues.editMode = "ChangeValues";
		editFeesPayChangeValues.bankId = bankID_To_DEL;
		editFeesPayChangeValues.accNo = accountNo_To_DEL;
		byte[] array = new byte[0];
		array = (byte[])barEditItem3.EditValue;
		stream = new MemoryStream(array);
		editFeesPayChangeValues.pictureEdit1.Image = Image.FromStream(stream);
		if (editFeesPayChangeValues.ShowDialog() == DialogResult.OK)
		{
			LoadStudentLegder();
			LoadSemesterRequiredItems(lblStudentNo.Caption);
			LoadSemesterPIKItems(lblStudentNo.Caption);
		}
	}

	private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridViewStudentPayment.FocusedRowHandle <= -1)
		{
			return;
		}
		DataRow dataRow = dt_FeesLedger.Rows[gridViewStudentPayment.GetFocusedDataSourceRowIndex()];
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT userId FROM tbl_StatementOfAffairs WHERE captureDate='{0}'", dataRow["CaptureDate"]), DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TrxRef");
		IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow2 = (DataRow)enumerator.Current;
				XtraMessageBox.Show(dataRow2["userId"].ToString(), "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

	private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
	{
	}

	private void toggleSwitch1_Toggled(object sender, EventArgs e)
	{
		if (toggleSwitch1.IsOn)
		{
			navigationFrame1.SelectedPageIndex = 1;
		}
		else
		{
			navigationFrame1.SelectedPageIndex = 0;
		}
	}

	private void cboItem_EditValueChanged(object sender, EventArgs e)
	{
		if (cboItem.EditValue == null)
		{
			return;
		}
		checkEdit2.Text = cboItem.EditValue.ToString() + " Payable In Kind";
		if (!checkEdit2.Checked)
		{
			DataRow dataRow = dt_PI.Rows[cboItem.SelectedIndex];
			if (dataRow["accNo"].ToString() == "1001-0001")
			{
				txtAmount.Text = feesRequired.ToString("#,#.0");
			}
			_AccountNumber = dataRow["accNo"].ToString();
		}
	}

	private void checkEdit2_CheckedChanged(object sender, EventArgs e)
	{
		if (checkEdit2.Checked)
		{
			txtAmount.Text = string.Empty;
			txtAmount.ReadOnly = true;
		}
		else
		{
			txtAmount.ReadOnly = false;
		}
	}

	private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
	{
		AwardWaiver awardWaiver = new AwardWaiver();
		if (awardWaiver.ShowDialog() == DialogResult.OK)
		{
			if (!LicenceStatus.IsTrialExpired)
			{
				FinalizeFeesPaymentWaiver(awardWaiver.WaiverAmount, awardWaiver.Narration);
				LoadStudentLegder();
				LoadSemesterRequiredItems(lblStudentNo.Caption);
				LoadSemesterPIKItems(lblStudentNo.Caption);
			}
			else
			{
				XtraMessageBox.Show("Sorry! Your license expired. Please renew.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
			if (__TranS != null)
			{
				__TranS.Dispose();
				__TranS = null;
			}
			if (_transPrep != null)
			{
				_transPrep.Dispose();
				_transPrep = null;
			}
			if (dt_FeesLedger != null)
			{
				dt_FeesLedger.Dispose();
				dt_FeesLedger = null;
			}
			if (dataTable != null)
			{
				dataTable.Dispose();
				dataTable = null;
			}
			if (dataSet != null)
			{
				dataSet.Dispose();
				dataSet = null;
			}
			if (dt_s != null)
			{
				dt_s.Dispose();
				dt_s = null;
			}
			if (dt_PI != null)
			{
				dt_PI.Dispose();
				dt_PI = null;
			}
			if (_dt_TA != null)
			{
				_dt_TA.Dispose();
				_dt_TA = null;
			}
			if (stream != null)
			{
				stream.Dispose();
				stream = null;
			}
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.DialogForms.StudentFeesPayment));
		DevExpress.XtraEditors.Controls.EditorButtonImageOptions imageOptions = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
		DevExpress.Utils.SerializableAppearanceObject appearance = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.Utils.SerializableAppearanceObject appearanceHovered = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.Utils.SerializableAppearanceObject appearancePressed = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.Utils.SerializableAppearanceObject appearanceDisabled = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item2 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
		this.picStudentPicture = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
		this.lblName = new DevExpress.XtraBars.BarStaticItem();
		this.lblClass = new DevExpress.XtraBars.BarStaticItem();
		this.lblStream = new DevExpress.XtraBars.BarStaticItem();
		this.lblSemester = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.lblStudentNo = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.txtDateTime = new DevExpress.XtraBars.BarEditItem();
		this.lblStudyStatus = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
		this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
		this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
		this.dtBillingDate = new DevExpress.XtraEditors.DateEdit();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.txtAmount = new DevExpress.XtraEditors.TextEdit();
		this.cboItem = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
		this.lblIsOnBursary = new DevExpress.XtraBars.BarStaticItem();
		this.lblBursaryScheme = new DevExpress.XtraBars.BarStaticItem();
		this.lblDiscount = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem8 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
		this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
		this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
		this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridPayableItems = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.cboPayToAccount = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtAccNo = new DevExpress.XtraEditors.TextEdit();
		this.cboStudents = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
		this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
		this.txtConfirmStudentNumber = new DevExpress.XtraEditors.TextEdit();
		this.btnProcessPayment = new DevExpress.XtraEditors.SimpleButton();
		this.dtPayment = new DevExpress.XtraEditors.DateEdit();
		this.txtReceiptNumber = new DevExpress.XtraEditors.TextEdit();
		this.gridStudentPayment = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewStudentPayment = new AlienAge.CustomGrid.MyGridView();
		this.gridColDate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColRef = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColSemester = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColParticulars = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBills = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColPayment = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBalance = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.lookUpStudents = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutBankSlip = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.dxValidationProvider2 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.repositoryItemComboBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStudentPicture).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupControlContainer1).BeginInit();
		this.popupControlContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).BeginInit();
		this.layoutControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.checkEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBillingDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBillingDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemCheckEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemToggleSwitch1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.toggleSwitch1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).BeginInit();
		this.navigationFrame1.SuspendLayout();
		this.navigationPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridPayableItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		this.navigationPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboPayToAccount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStudents.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtConfirmStudentNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceiptNumber.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridStudentPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpStudents.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutBankSlip).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider2).BeginInit();
		base.SuspendLayout();
		this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemComboBox2.Items.AddRange(new object[6] { "S.1", "S.2", "S.3", "S.4", "S.5", "S.6" });
		this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
		this.repositoryItemComboBox2.NullText = "Search by Class";
		this.repositoryItemComboBox2.NullValuePrompt = "Search by Class";
		this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(20);
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[35]
		{
			this.ribbonControl1.ExpandCollapseItem,
			this.ribbonControl1.SearchEditItem,
			this.barButtonItem1,
			this.barButtonItem2,
			this.barButtonItem3,
			this.barEditItem3,
			this.barStaticItem1,
			this.barStaticItem2,
			this.barStaticItem3,
			this.lblName,
			this.lblClass,
			this.lblStream,
			this.lblSemester,
			this.barButtonItem6,
			this.barStaticItem5,
			this.barButtonItem7,
			this.barButtonItem4,
			this.barButtonItem5,
			this.lblStudentNo,
			this.barButtonItem8,
			this.txtDateTime,
			this.lblStudyStatus,
			this.barButtonItem9,
			this.barButtonItem10,
			this.barButtonItem11,
			this.barStaticItem6,
			this.barStaticItem7,
			this.lblIsOnBursary,
			this.lblBursaryScheme,
			this.lblDiscount,
			this.barStaticItem8,
			this.barButtonItem12,
			this.barButtonItem13,
			this.barButtonItem14,
			this.barButtonItem15
		});
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 25;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.OptionsMenuMinWidth = 220;
		this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[3] { this.picStudentPicture, this.repositoryItemCheckEdit1, this.repositoryItemToggleSwitch1 });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(775, 132);
		this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.barButtonItem1.Caption = "Print this receipt";
		this.barButtonItem1.Id = 3;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
		this.barButtonItem2.Caption = "Print Ledger";
		this.barButtonItem2.Id = 4;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Export Ledger";
		this.barButtonItem3.Id = 5;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barEditItem3.Edit = this.picStudentPicture;
		this.barEditItem3.EditHeight = 75;
		this.barEditItem3.EditWidth = 75;
		this.barEditItem3.Id = 6;
		this.barEditItem3.Name = "barEditItem3";
		this.picStudentPicture.Name = "picStudentPicture";
		this.picStudentPicture.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.barStaticItem1.Caption = "Name:";
		this.barStaticItem1.Id = 7;
		this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
		this.barStaticItem1.Name = "barStaticItem1";
		this.barStaticItem2.Caption = "Class:";
		this.barStaticItem2.Id = 8;
		this.barStaticItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.barStaticItem2.ItemAppearance.Normal.Options.UseFont = true;
		this.barStaticItem2.Name = "barStaticItem2";
		this.barStaticItem3.Caption = "Stream:";
		this.barStaticItem3.Id = 9;
		this.barStaticItem3.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.barStaticItem3.ItemAppearance.Normal.Options.UseFont = true;
		this.barStaticItem3.Name = "barStaticItem3";
		this.lblName.Id = 10;
		this.lblName.Name = "lblName";
		this.lblClass.Id = 11;
		this.lblClass.Name = "lblClass";
		this.lblStream.Id = 12;
		this.lblStream.Name = "lblStream";
		this.lblSemester.Caption = "Semester";
		this.lblSemester.Id = 13;
		this.lblSemester.Name = "lblSemester";
		this.barButtonItem6.Caption = "Export Ledger";
		this.barButtonItem6.Id = 20;
		this.barButtonItem6.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem6.ImageOptions.Image");
		this.barButtonItem6.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem6.ImageOptions.LargeImage");
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barStaticItem5.Caption = "Term:";
		this.barStaticItem5.Id = 24;
		this.barStaticItem5.Name = "barStaticItem5";
		this.barButtonItem7.ActAsDropDown = true;
		this.barButtonItem7.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem7.Caption = "Find";
		this.barButtonItem7.Id = 27;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem4.Caption = "Print Receipt";
		this.barButtonItem4.Id = 28;
		this.barButtonItem4.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.receipt_print;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem5.Caption = "Print Ledger";
		this.barButtonItem5.Id = 29;
		this.barButtonItem5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.Image");
		this.barButtonItem5.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.LargeImage");
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.lblStudentNo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.lblStudentNo.Id = 30;
		this.lblStudentNo.Name = "lblStudentNo";
		this.barButtonItem8.Caption = "Delete Last";
		this.barButtonItem8.Id = 32;
		this.barButtonItem8.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem8.ImageOptions.Image");
		this.barButtonItem8.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem8.ImageOptions.LargeImage");
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem8_ItemClick);
		this.txtDateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.txtDateTime.Edit = this.repositoryItemComboBox2;
		this.txtDateTime.EditWidth = 200;
		this.txtDateTime.Id = 34;
		this.txtDateTime.Name = "txtDateTime";
		this.lblStudyStatus.Id = 5;
		this.lblStudyStatus.Name = "lblStudyStatus";
		this.lblStudyStatus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem9.ActAsDropDown = true;
		this.barButtonItem9.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem9.Caption = "Bill More";
		this.barButtonItem9.DropDownControl = this.popupControlContainer1;
		this.barButtonItem9.Id = 7;
		this.barButtonItem9.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem9.ImageOptions.Image");
		this.barButtonItem9.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem9.ImageOptions.LargeImage");
		this.barButtonItem9.Name = "barButtonItem9";
		this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.popupControlContainer1.Controls.Add(this.layoutControl2);
		this.popupControlContainer1.Location = new System.Drawing.Point(390, 165);
		this.popupControlContainer1.Name = "popupControlContainer1";
		this.popupControlContainer1.Ribbon = this.ribbonControl1;
		this.popupControlContainer1.Size = new System.Drawing.Size(259, 158);
		this.popupControlContainer1.TabIndex = 25;
		this.popupControlContainer1.Visible = false;
		this.layoutControl2.Controls.Add(this.checkEdit2);
		this.layoutControl2.Controls.Add(this.dtBillingDate);
		this.layoutControl2.Controls.Add(this.simpleButton4);
		this.layoutControl2.Controls.Add(this.simpleButton3);
		this.layoutControl2.Controls.Add(this.txtAmount);
		this.layoutControl2.Controls.Add(this.cboItem);
		this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl2.Location = new System.Drawing.Point(0, 0);
		this.layoutControl2.Name = "layoutControl2";
		this.layoutControl2.Root = this.layoutControlGroup2;
		this.layoutControl2.Size = new System.Drawing.Size(259, 158);
		this.layoutControl2.TabIndex = 0;
		this.layoutControl2.Text = "layoutControl2";
		this.checkEdit2.Location = new System.Drawing.Point(3, 59);
		this.checkEdit2.Name = "checkEdit2";
		this.checkEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.checkEdit2.Properties.Appearance.Options.UseFont = true;
		this.checkEdit2.Properties.Caption = "Item payable in kind";
		this.checkEdit2.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
		this.checkEdit2.Size = new System.Drawing.Size(253, 20);
		this.checkEdit2.StyleController = this.layoutControl2;
		this.checkEdit2.TabIndex = 45;
		this.checkEdit2.CheckedChanged += new System.EventHandler(checkEdit2_CheckedChanged);
		this.dtBillingDate.EditValue = null;
		this.dtBillingDate.Location = new System.Drawing.Point(66, 3);
		this.dtBillingDate.MenuManager = this.ribbonControl1;
		this.dtBillingDate.Name = "dtBillingDate";
		this.dtBillingDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtBillingDate.Properties.Appearance.Options.UseFont = true;
		this.dtBillingDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dtBillingDate.Properties.AppearanceDropDown.Options.UseFont = true;
		this.dtBillingDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtBillingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "Billing Date", -1, true, true, false, imageOptions, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), appearance, appearanceHovered, appearancePressed, appearanceDisabled, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)
		});
		this.dtBillingDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtBillingDate.Properties.DisplayFormat.FormatString = "dd-MM-yy";
		this.dtBillingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtBillingDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtBillingDate.Size = new System.Drawing.Size(190, 24);
		this.dtBillingDate.StyleController = this.layoutControl2;
		this.dtBillingDate.TabIndex = 8;
		this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton4.Appearance.Options.UseFont = true;
		this.simpleButton4.Location = new System.Drawing.Point(3, 133);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(126, 22);
		this.simpleButton4.StyleController = this.layoutControl2;
		this.simpleButton4.TabIndex = 7;
		this.simpleButton4.Text = "Bill Student";
		this.simpleButton4.Click += new System.EventHandler(simpleButton4_Click);
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.Location = new System.Drawing.Point(133, 133);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(123, 22);
		this.simpleButton3.StyleController = this.layoutControl2;
		this.simpleButton3.TabIndex = 6;
		this.simpleButton3.Text = "Cancel";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.txtAmount.Location = new System.Drawing.Point(66, 83);
		this.txtAmount.MenuManager = this.ribbonControl1;
		this.txtAmount.Name = "txtAmount";
		this.txtAmount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAmount.Properties.Appearance.Options.UseFont = true;
		this.txtAmount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAmount.Properties.Mask.EditMask = "n0";
		this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAmount.Size = new System.Drawing.Size(190, 24);
		this.txtAmount.StyleController = this.layoutControl2;
		this.txtAmount.TabIndex = 5;
		this.cboItem.Location = new System.Drawing.Point(66, 31);
		this.cboItem.MenuManager = this.ribbonControl1;
		this.cboItem.Name = "cboItem";
		this.cboItem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboItem.Properties.Appearance.Options.UseFont = true;
		this.cboItem.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.cboItem.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboItem.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboItem.Size = new System.Drawing.Size(190, 24);
		this.cboItem.StyleController = this.layoutControl2;
		this.cboItem.TabIndex = 4;
		this.cboItem.SelectedValueChanged += new System.EventHandler(cboItem_SelectedValueChanged);
		this.cboItem.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboItem_Closed);
		this.cboItem.EditValueChanged += new System.EventHandler(cboItem_EditValueChanged);
		this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup2.GroupBordersVisible = false;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem8, this.layoutControlItem10, this.layoutControlItem13, this.layoutControlItem16, this.emptySpaceItem1, this.layoutControlItem17, this.layoutControlItem18 });
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup2.Size = new System.Drawing.Size(259, 158);
		this.layoutControlGroup2.TextVisible = false;
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.cboItem;
		this.layoutControlItem8.CustomizationFormText = "Item";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(257, 28);
		this.layoutControlItem8.Text = "Item";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(51, 18);
		this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem10.Control = this.txtAmount;
		this.layoutControlItem10.CustomizationFormText = "Amount";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 80);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(257, 28);
		this.layoutControlItem10.Text = "Amount";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(51, 18);
		this.layoutControlItem13.Control = this.simpleButton3;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(130, 130);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(127, 26);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem16.Control = this.simpleButton4;
		this.layoutControlItem16.CustomizationFormText = "layoutControlItem16";
		this.layoutControlItem16.Location = new System.Drawing.Point(0, 130);
		this.layoutControlItem16.Name = "layoutControlItem16";
		this.layoutControlItem16.Size = new System.Drawing.Size(130, 26);
		this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem16.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 108);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(257, 22);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem17.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem17.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem17.Control = this.dtBillingDate;
		this.layoutControlItem17.CustomizationFormText = "Bill Date";
		this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem17.Name = "layoutControlItem17";
		this.layoutControlItem17.Size = new System.Drawing.Size(257, 28);
		this.layoutControlItem17.Text = "Bill Date";
		this.layoutControlItem17.TextSize = new System.Drawing.Size(51, 18);
		this.layoutControlItem18.Control = this.checkEdit2;
		this.layoutControlItem18.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem18.Name = "layoutControlItem18";
		this.layoutControlItem18.Size = new System.Drawing.Size(257, 24);
		this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem18.TextVisible = false;
		this.barButtonItem10.Caption = "Delete Selected";
		this.barButtonItem10.Id = 8;
		this.barButtonItem10.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem10.ImageOptions.Image");
		this.barButtonItem10.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem10.ImageOptions.LargeImage");
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.barButtonItem11.Caption = "Delete this entry";
		this.barButtonItem11.Id = 9;
		this.barButtonItem11.Name = "barButtonItem11";
		this.barButtonItem11.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem11_ItemClick);
		this.barStaticItem6.Caption = "Bursary Scheme:";
		this.barStaticItem6.Id = 11;
		this.barStaticItem6.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.barStaticItem6.ItemAppearance.Normal.Options.UseFont = true;
		this.barStaticItem6.Name = "barStaticItem6";
		this.barStaticItem7.Caption = "Discount: ";
		this.barStaticItem7.Id = 12;
		this.barStaticItem7.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.barStaticItem7.ItemAppearance.Normal.Options.UseFont = true;
		this.barStaticItem7.LeftIndent = 42;
		this.barStaticItem7.Name = "barStaticItem7";
		this.lblIsOnBursary.Id = 14;
		this.lblIsOnBursary.Name = "lblIsOnBursary";
		this.lblBursaryScheme.Id = 15;
		this.lblBursaryScheme.Name = "lblBursaryScheme";
		this.lblDiscount.Id = 17;
		this.lblDiscount.Name = "lblDiscount";
		this.barStaticItem8.Caption = "Is on Bursary:";
		this.barStaticItem8.Id = 18;
		this.barStaticItem8.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.barStaticItem8.ItemAppearance.Normal.Options.UseFont = true;
		this.barStaticItem8.LeftIndent = 17;
		this.barStaticItem8.Name = "barStaticItem8";
		this.barButtonItem12.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
		this.barButtonItem12.Caption = "Expand Ledger";
		this.barButtonItem12.Id = 19;
		this.barButtonItem12.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.emptytablerowseparator_32x32;
		this.barButtonItem12.Name = "barButtonItem12";
		this.barButtonItem12.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem12_DownChanged);
		this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem12_ItemClick);
		this.barButtonItem13.Caption = "Change Values";
		this.barButtonItem13.Id = 21;
		this.barButtonItem13.ImageOptions.Image = I_Xtreme.Properties.Resources.converttoparagraphs_16x16;
		this.barButtonItem13.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.converttoparagraphs_32x32;
		this.barButtonItem13.Name = "barButtonItem13";
		this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem13_ItemClick);
		this.barButtonItem14.Caption = "Logged User";
		this.barButtonItem14.Id = 23;
		this.barButtonItem14.Name = "barButtonItem14";
		this.barButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem14_ItemClick);
		this.barButtonItem15.Caption = "Award Waiver";
		this.barButtonItem15.Id = 24;
		this.barButtonItem15.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem15.ImageOptions.Image");
		this.barButtonItem15.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem15.ImageOptions.LargeImage");
		this.barButtonItem15.Name = "barButtonItem15";
		this.barButtonItem15.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
		this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem15_ItemClick);
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup2, this.ribbonPageGroup5, this.ribbonPageGroup1, this.ribbonPageGroup3 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "ribbonPage1";
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup2.ItemLinks.Add(this.barEditItem3);
		this.ribbonPageGroup2.ItemLinks.Add(this.barStaticItem1, true);
		this.ribbonPageGroup2.ItemLinks.Add(this.barStaticItem2);
		this.ribbonPageGroup2.ItemLinks.Add(this.barStaticItem3);
		this.ribbonPageGroup2.ItemLinks.Add(this.lblName);
		this.ribbonPageGroup2.ItemLinks.Add(this.lblClass);
		this.ribbonPageGroup2.ItemLinks.Add(this.lblStream);
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.Text = "Student details";
		this.ribbonPageGroup5.AllowTextClipping = false;
		this.ribbonPageGroup5.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem12);
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem9);
		this.ribbonPageGroup5.Name = "ribbonPageGroup5";
		this.ribbonPageGroup5.Text = "Fees Ledger";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem15, true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem8, true, "", "", true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem10);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem13);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup1.Text = "Ledger Entry Editing";
		this.ribbonPageGroup3.AllowTextClipping = false;
		this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem5);
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem6);
		this.ribbonPageGroup3.Name = "ribbonPageGroup3";
		this.ribbonPageGroup3.Text = "Printing && Exporting";
		this.repositoryItemCheckEdit1.AutoHeight = false;
		this.repositoryItemCheckEdit1.Caption = "Check";
		this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
		this.repositoryItemToggleSwitch1.AutoHeight = false;
		this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
		this.repositoryItemToggleSwitch1.OffText = "Off";
		this.repositoryItemToggleSwitch1.OnText = "On";
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem5);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblSemester);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblStudentNo);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblStudyStatus);
		this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 501);
		this.ribbonStatusBar1.Name = "ribbonStatusBar1";
		this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
		this.ribbonStatusBar1.Size = new System.Drawing.Size(775, 24);
		this.layoutControl1.Controls.Add(this.toggleSwitch1);
		this.layoutControl1.Controls.Add(this.navigationFrame1);
		this.layoutControl1.Controls.Add(this.cboPayToAccount);
		this.layoutControl1.Controls.Add(this.popupControlContainer1);
		this.layoutControl1.Controls.Add(this.txtAccNo);
		this.layoutControl1.Controls.Add(this.cboStudents);
		this.layoutControl1.Controls.Add(this.gridLookUpEdit1);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtConfirmStudentNumber);
		this.layoutControl1.Controls.Add(this.btnProcessPayment);
		this.layoutControl1.Controls.Add(this.dtPayment);
		this.layoutControl1.Controls.Add(this.txtReceiptNumber);
		this.layoutControl1.Controls.Add(this.gridStudentPayment);
		this.layoutControl1.Controls.Add(this.lookUpStudents);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 132);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(587, 305, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(775, 369);
		this.layoutControl1.TabIndex = 23;
		this.layoutControl1.Text = "layoutControl1";
		this.toggleSwitch1.Location = new System.Drawing.Point(2, 172);
		this.toggleSwitch1.MenuManager = this.ribbonControl1;
		this.toggleSwitch1.Name = "toggleSwitch1";
		this.toggleSwitch1.Properties.OffText = "Switch to Non-Cash Payment";
		this.toggleSwitch1.Properties.OnText = "Switch to Cash Payment";
		this.toggleSwitch1.Size = new System.Drawing.Size(285, 17);
		this.toggleSwitch1.StyleController = this.layoutControl1;
		this.toggleSwitch1.TabIndex = 27;
		this.toggleSwitch1.Toggled += new System.EventHandler(toggleSwitch1_Toggled);
		this.navigationFrame1.Controls.Add(this.navigationPage1);
		this.navigationFrame1.Controls.Add(this.navigationPage2);
		this.navigationFrame1.Location = new System.Drawing.Point(2, 193);
		this.navigationFrame1.Name = "navigationFrame1";
		this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[2] { this.navigationPage1, this.navigationPage2 });
		this.navigationFrame1.SelectedPage = this.navigationPage1;
		this.navigationFrame1.Size = new System.Drawing.Size(285, 147);
		this.navigationFrame1.TabIndex = 26;
		this.navigationFrame1.Text = "navigationFrame1";
		this.navigationPage1.Controls.Add(this.gridPayableItems);
		this.navigationPage1.Name = "navigationPage1";
		this.navigationPage1.Size = new System.Drawing.Size(285, 147);
		this.gridPayableItems.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridPayableItems.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
		this.gridPayableItems.Location = new System.Drawing.Point(0, 0);
		this.gridPayableItems.MainView = this.gridView1;
		this.gridPayableItems.MenuManager = this.ribbonControl1;
		this.gridPayableItems.Name = "gridPayableItems";
		this.gridPayableItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemTextEdit1 });
		this.gridPayableItems.Size = new System.Drawing.Size(285, 147);
		this.gridPayableItems.TabIndex = 8;
		this.gridPayableItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn2 });
		this.gridView1.DetailHeight = 233;
		this.gridView1.GridControl = this.gridPayableItems;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsCustomization.AllowColumnMoving = false;
		this.gridView1.OptionsCustomization.AllowFilter = false;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView1.OptionsCustomization.AllowSort = false;
		this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
		this.gridView1.OptionsFilter.AllowFilterEditor = false;
		this.gridView1.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.gridView1.OptionsFilter.AllowMRUFilterList = false;
		this.gridView1.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.RowHeight = 15;
		this.gridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gridView1_InvalidValueException);
		this.gridColumn1.Caption = "Particulars";
		this.gridColumn1.FieldName = "Particulars";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.OptionsColumn.AllowEdit = false;
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Amount";
		this.gridColumn2.ColumnEdit = this.repositoryItemTextEdit1;
		this.gridColumn2.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn2.FieldName = "Amount";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 50;
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.DisplayFormat.FormatString = "{0:#,#}";
		this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.repositoryItemTextEdit1.EditFormat.FormatString = "{0:#,#}";
		this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.repositoryItemTextEdit1.Mask.BeepOnError = true;
		this.repositoryItemTextEdit1.Mask.EditMask = "n0";
		this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.navigationPage2.Controls.Add(this.gridControl1);
		this.navigationPage2.Name = "navigationPage2";
		this.navigationPage2.Size = new System.Drawing.Size(285, 147);
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView2;
		this.gridControl1.MenuManager = this.ribbonControl1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemTextEdit2 });
		this.gridControl1.Size = new System.Drawing.Size(285, 147);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn4, this.gridColumn5, this.gridColumn6 });
		this.gridView2.GridControl = this.gridControl1;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsSelection.MultiSelect = true;
		this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
		this.gridView2.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridColumn4.Caption = "Particulars";
		this.gridColumn4.FieldName = "Particulars";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 1;
		this.gridColumn4.Width = 140;
		this.gridColumn5.Caption = "accNo";
		this.gridColumn5.FieldName = "accNo";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn6.Caption = "Qty";
		this.gridColumn6.ColumnEdit = this.repositoryItemTextEdit2;
		this.gridColumn6.FieldName = "PIKQty";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 2;
		this.gridColumn6.Width = 45;
		this.repositoryItemTextEdit2.AutoHeight = false;
		this.repositoryItemTextEdit2.BeepOnError = true;
		this.repositoryItemTextEdit2.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.repositoryItemTextEdit2.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
		this.repositoryItemTextEdit2.MaskSettings.Set("mask", "d");
		this.repositoryItemTextEdit2.MaskSettings.Set("hideInsignificantZeros", true);
		this.repositoryItemTextEdit2.MaskSettings.Set("autoHideDecimalSeparator", true);
		this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
		this.repositoryItemTextEdit2.UseMaskAsDisplayFormat = true;
		this.dxValidationProvider1.SetIconAlignment(this.cboPayToAccount, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidationProvider2.SetIconAlignment(this.cboPayToAccount, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboPayToAccount.Location = new System.Drawing.Point(50, 32);
		this.cboPayToAccount.MenuManager = this.ribbonControl1;
		this.cboPayToAccount.Name = "cboPayToAccount";
		this.cboPayToAccount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboPayToAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboPayToAccount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboPayToAccount.Size = new System.Drawing.Size(237, 22);
		this.cboPayToAccount.StyleController = this.layoutControl1;
		this.cboPayToAccount.TabIndex = 0;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "Please choose payment mode";
		this.dxValidationProvider1.SetValidationRule(this.cboPayToAccount, conditionValidationRule);
		this.cboPayToAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(cboPayToAccount_QueryPopUp);
		this.cboPayToAccount.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboPayToAccount_Closed);
		this.txtAccNo.Location = new System.Drawing.Point(2, 88);
		this.txtAccNo.MenuManager = this.ribbonControl1;
		this.txtAccNo.Name = "txtAccNo";
		this.txtAccNo.Properties.ReadOnly = true;
		this.txtAccNo.Size = new System.Drawing.Size(285, 20);
		this.txtAccNo.StyleController = this.layoutControl1;
		this.txtAccNo.TabIndex = 23;
		this.cboStudents.Location = new System.Drawing.Point(2, 2);
		this.cboStudents.MenuManager = this.ribbonControl1;
		this.cboStudents.Name = "cboStudents";
		this.cboStudents.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboStudents.Properties.Appearance.Options.UseFont = true;
		this.cboStudents.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboStudents.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStudents.Properties.NullText = "Search by class";
		this.cboStudents.Properties.NullValuePrompt = "Search by class";
		this.cboStudents.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStudents.Size = new System.Drawing.Size(285, 26);
		this.cboStudents.StyleController = this.layoutControl1;
		this.cboStudents.TabIndex = 3;
		this.cboStudents.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboStudents_Closed);
		this.gridLookUpEdit1.EditValue = "Select Student";
		this.gridLookUpEdit1.Location = new System.Drawing.Point(291, 32);
		this.gridLookUpEdit1.MenuManager = this.ribbonControl1;
		this.gridLookUpEdit1.Name = "gridLookUpEdit1";
		this.gridLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridLookUpEdit1.Properties.Appearance.Options.UseFont = true;
		this.gridLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.gridLookUpEdit1.Properties.NullText = "Select student";
		this.gridLookUpEdit1.Properties.NullValuePrompt = "Select student";
		this.gridLookUpEdit1.Properties.PopupFormMinSize = new System.Drawing.Size(367, 267);
		this.gridLookUpEdit1.Properties.PopupFormSize = new System.Drawing.Size(367, 267);
		this.gridLookUpEdit1.Properties.PopupView = this.gridLookUpEdit1View;
		this.gridLookUpEdit1.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
		this.gridLookUpEdit1.Size = new System.Drawing.Size(482, 26);
		this.gridLookUpEdit1.StyleController = this.layoutControl1;
		this.gridLookUpEdit1.TabIndex = 22;
		this.gridLookUpEdit1.TabStop = false;
		this.gridLookUpEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(gridLookUpEdit1_CloseUp);
		this.gridLookUpEdit1View.Appearance.FocusedRow.BackColor = System.Drawing.Color.Fuchsia;
		this.gridLookUpEdit1View.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Fuchsia;
		this.gridLookUpEdit1View.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
		this.gridLookUpEdit1View.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridLookUpEdit1View.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridLookUpEdit1View.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.gridLookUpEdit1View.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(255, 128, 0);
		this.gridLookUpEdit1View.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
		this.gridLookUpEdit1View.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridLookUpEdit1View.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridLookUpEdit1View.DetailHeight = 233;
		this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
		this.gridLookUpEdit1View.OptionsBehavior.Editable = false;
		this.gridLookUpEdit1View.OptionsFind.AlwaysVisible = true;
		this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridLookUpEdit1View.OptionsView.EnableAppearanceEvenRow = true;
		this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
		this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
		this.gridLookUpEdit1View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridLookUpEdit1View.OptionsView.ShowIndicator = false;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(722, 2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(51, 23);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.Text = "Search";
		this.simpleButton1.ToolTip = "[Enter/Return]";
		this.simpleButton1.ToolTipController = this.toolTipController1;
		this.simpleButton1.ToolTipTitle = "Shortcut";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtConfirmStudentNumber.Enabled = false;
		this.txtConfirmStudentNumber.Location = new System.Drawing.Point(2, 58);
		this.txtConfirmStudentNumber.MenuManager = this.ribbonControl1;
		this.txtConfirmStudentNumber.Name = "txtConfirmStudentNumber";
		this.txtConfirmStudentNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtConfirmStudentNumber.Properties.Appearance.Options.UseFont = true;
		this.txtConfirmStudentNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtConfirmStudentNumber.Properties.NullText = "Search by Student#";
		this.txtConfirmStudentNumber.Properties.NullValuePrompt = "Search by Student#";
		this.txtConfirmStudentNumber.Properties.ReadOnly = true;
		this.txtConfirmStudentNumber.Size = new System.Drawing.Size(285, 26);
		this.txtConfirmStudentNumber.StyleController = this.layoutControl1;
		toolTipTitleItem.Text = "Search by Student Number";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "You can search a student by using his/her student number.";
		toolTipTitleItem2.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem2.Appearance.Options.UseImage = true;
		toolTipTitleItem2.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem2.LeftIndent = 6;
		toolTipTitleItem2.Text = "Press F1 for help.";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		superToolTip.Items.Add(item);
		superToolTip.Items.Add(toolTipTitleItem2);
		this.txtConfirmStudentNumber.SuperTip = superToolTip;
		this.txtConfirmStudentNumber.TabIndex = 0;
		this.txtConfirmStudentNumber.TextChanged += new System.EventHandler(txtConfirmStudentNumber_TextChanged);
		this.btnProcessPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.btnProcessPayment.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnProcessPayment.Appearance.Options.UseFont = true;
		this.btnProcessPayment.Location = new System.Drawing.Point(2, 344);
		this.btnProcessPayment.Name = "btnProcessPayment";
		this.btnProcessPayment.Size = new System.Drawing.Size(285, 23);
		this.btnProcessPayment.StyleController = this.layoutControl1;
		toolTipItem2.Text = "[Ctrl + Enter]";
		superToolTip2.Items.Add(toolTipItem2);
		this.btnProcessPayment.SuperTip = superToolTip2;
		this.btnProcessPayment.TabIndex = 10;
		this.btnProcessPayment.Text = "Process Payment";
		this.btnProcessPayment.ToolTip = "Confirm Fees Payment\r\n[Ctrl + Enter]";
		this.btnProcessPayment.Click += new System.EventHandler(btnProcessPayment_Click);
		this.dtPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dtPayment.EditValue = null;
		this.dxValidationProvider1.SetIconAlignment(this.dtPayment, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidationProvider2.SetIconAlignment(this.dtPayment, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dtPayment.Location = new System.Drawing.Point(2, 142);
		this.dtPayment.Name = "dtPayment";
		this.dtPayment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtPayment.Properties.Appearance.Options.UseFont = true;
		this.dtPayment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtPayment.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton()
		});
		this.dtPayment.Properties.DisplayFormat.FormatString = "{0:dd-MMM-yyyy}";
		this.dtPayment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtPayment.Properties.Mask.EditMask = "";
		this.dtPayment.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.dtPayment.Properties.NullText = "Payment Date";
		this.dtPayment.Properties.NullValuePrompt = "Payment Date";
		this.dtPayment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtPayment.Size = new System.Drawing.Size(285, 26);
		this.dtPayment.StyleController = this.layoutControl1;
		this.dtPayment.TabIndex = 7;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "Please choose payment date";
		this.dxValidationProvider2.SetValidationRule(this.dtPayment, conditionValidationRule2);
		this.dtPayment.EditValueChanged += new System.EventHandler(dtPayment_EditValueChanged);
		this.txtReceiptNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.txtReceiptNumber.EditValue = "";
		this.dxValidationProvider2.SetIconAlignment(this.txtReceiptNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.dxValidationProvider1.SetIconAlignment(this.txtReceiptNumber, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtReceiptNumber.Location = new System.Drawing.Point(2, 112);
		this.txtReceiptNumber.Name = "txtReceiptNumber";
		this.txtReceiptNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtReceiptNumber.Properties.Appearance.Options.UseFont = true;
		this.txtReceiptNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReceiptNumber.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtReceiptNumber.Properties.NullText = "Bankslip No";
		this.txtReceiptNumber.Properties.NullValuePrompt = "Bankslip No";
		this.txtReceiptNumber.Size = new System.Drawing.Size(285, 26);
		this.txtReceiptNumber.StyleController = this.layoutControl1;
		this.txtReceiptNumber.TabIndex = 6;
		this.txtReceiptNumber.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "Please enter Bankslip/ReceiptNo/MobileNo";
		this.dxValidationProvider1.SetValidationRule(this.txtReceiptNumber, conditionValidationRule3);
		this.txtReceiptNumber.TextChanged += new System.EventHandler(txtReceiptNumber_TextChanged);
		this.gridStudentPayment.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.gridStudentPayment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
		this.gridStudentPayment.Location = new System.Drawing.Point(291, 88);
		this.gridStudentPayment.MainView = this.gridViewStudentPayment;
		this.gridStudentPayment.Name = "gridStudentPayment";
		this.gridStudentPayment.Size = new System.Drawing.Size(482, 279);
		this.gridStudentPayment.TabIndex = 13;
		this.gridStudentPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewStudentPayment });
		this.gridViewStudentPayment.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewStudentPayment.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewStudentPayment.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewStudentPayment.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewStudentPayment.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewStudentPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[9] { this.gridColDate, this.gridColRef, this.gridColSemester, this.gridColParticulars, this.gridColBills, this.gridColPayment, this.gridColBalance, this.gridColAmount, this.gridColumn3 });
		this.gridViewStudentPayment.DetailHeight = 233;
		this.gridViewStudentPayment.GridControl = this.gridStudentPayment;
		this.gridViewStudentPayment.Name = "gridViewStudentPayment";
		this.gridViewStudentPayment.OptionsBehavior.Editable = false;
		this.gridViewStudentPayment.OptionsCustomization.AllowGroup = false;
		this.gridViewStudentPayment.OptionsCustomization.AllowSort = false;
		this.gridViewStudentPayment.OptionsPrint.PrintFooter = false;
		this.gridViewStudentPayment.OptionsPrint.PrintGroupFooter = false;
		this.gridViewStudentPayment.OptionsPrint.PrintHorzLines = false;
		this.gridViewStudentPayment.OptionsView.ShowFooter = true;
		this.gridViewStudentPayment.OptionsView.ShowGroupPanel = false;
		this.gridViewStudentPayment.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewStudentPayment.OptionsView.ShowIndicator = false;
		this.gridViewStudentPayment.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridViewStudentPayment_RowClick);
		this.gridViewStudentPayment.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridViewStudentPayment_CustomSummaryCalculate);
		this.gridViewStudentPayment.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewStudentPayment_FocusedRowChanged);
		this.gridViewStudentPayment.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridViewStudentPayment_CustomUnboundColumnData);
		this.gridViewStudentPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(gridViewStudentPayment_KeyDown);
		this.gridColDate.Caption = "Date";
		this.gridColDate.DisplayFormat.FormatString = "dd-MMM-yy";
		this.gridColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColDate.FieldName = "Date";
		this.gridColDate.MinWidth = 13;
		this.gridColDate.Name = "gridColDate";
		this.gridColDate.Visible = true;
		this.gridColDate.VisibleIndex = 0;
		this.gridColDate.Width = 37;
		this.gridColRef.Caption = "T_REF";
		this.gridColRef.FieldName = "TRef";
		this.gridColRef.MinWidth = 13;
		this.gridColRef.Name = "gridColRef";
		this.gridColRef.Visible = true;
		this.gridColRef.VisibleIndex = 2;
		this.gridColRef.Width = 31;
		this.gridColSemester.Caption = "Semester";
		this.gridColSemester.FieldName = "Term";
		this.gridColSemester.MinWidth = 13;
		this.gridColSemester.Name = "gridColSemester";
		this.gridColSemester.Visible = true;
		this.gridColSemester.VisibleIndex = 1;
		this.gridColSemester.Width = 53;
		this.gridColParticulars.Caption = "Particulars";
		this.gridColParticulars.FieldName = "Particulars";
		this.gridColParticulars.MinWidth = 13;
		this.gridColParticulars.Name = "gridColParticulars";
		this.gridColParticulars.Visible = true;
		this.gridColParticulars.VisibleIndex = 3;
		this.gridColParticulars.Width = 67;
		this.gridColBills.Caption = "Bills";
		this.gridColBills.DisplayFormat.FormatString = "{0:#,#.0;(#,#.0);' '}";
		this.gridColBills.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBills.FieldName = "Dr";
		this.gridColBills.MinWidth = 13;
		this.gridColBills.Name = "gridColBills";
		this.gridColBills.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Dr", "{0:#,#.0}")
		});
		this.gridColBills.Visible = true;
		this.gridColBills.VisibleIndex = 4;
		this.gridColBills.Width = 56;
		this.gridColPayment.Caption = "Payment";
		this.gridColPayment.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColPayment.FieldName = "Cr";
		this.gridColPayment.MinWidth = 13;
		this.gridColPayment.Name = "gridColPayment";
		this.gridColPayment.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cr", "{0:#,#.0}")
		});
		this.gridColPayment.Visible = true;
		this.gridColPayment.VisibleIndex = 5;
		this.gridColPayment.Width = 56;
		this.gridColBalance.Caption = "Balance";
		this.gridColBalance.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBalance.FieldName = "Bal";
		this.gridColBalance.MinWidth = 13;
		this.gridColBalance.Name = "gridColBalance";
		this.gridColBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColBalance.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
		this.gridColBalance.Visible = true;
		this.gridColBalance.VisibleIndex = 6;
		this.gridColBalance.Width = 59;
		this.gridColAmount.Caption = "Amount";
		this.gridColAmount.FieldName = "Amount";
		this.gridColAmount.MinWidth = 13;
		this.gridColAmount.Name = "gridColAmount";
		this.gridColAmount.Width = 50;
		this.gridColumn3.Caption = "PaymentID";
		this.gridColumn3.FieldName = "Ref";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Width = 50;
		this.lookUpStudents.Location = new System.Drawing.Point(291, 2);
		this.lookUpStudents.MenuManager = this.ribbonControl1;
		this.lookUpStudents.Name = "lookUpStudents";
		this.lookUpStudents.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lookUpStudents.Properties.Appearance.Options.UseFont = true;
		this.lookUpStudents.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.lookUpStudents.Properties.NullText = "Search by Name";
		this.lookUpStudents.Properties.NullValuePrompt = "Search by Name";
		this.lookUpStudents.Size = new System.Drawing.Size(427, 26);
		this.lookUpStudents.StyleController = this.layoutControl1;
		toolTipTitleItem3.Text = "Search by name";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "Search a student by his/her name. You can use Surname or LastName.";
		toolTipTitleItem4.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem4.Appearance.Options.UseImage = true;
		toolTipTitleItem4.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem4.LeftIndent = 6;
		toolTipTitleItem4.Text = "Press F1 for help.";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		superToolTip3.Items.Add(item2);
		superToolTip3.Items.Add(toolTipTitleItem4);
		this.lookUpStudents.SuperTip = superToolTip3;
		this.lookUpStudents.TabIndex = 1;
		this.lookUpStudents.TextChanged += new System.EventHandler(lookUpStudents_TextChanged);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[13]
		{
			this.layoutControlItem1, this.layoutBankSlip, this.layoutControlItem6, this.layoutControlItem14, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem9, this.layoutControlItem3, this.layoutControlItem15, this.layoutControlItem2,
			this.layoutControlItem12, this.layoutControlItem4, this.layoutControlItem11
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(775, 369);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridStudentPayment;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(289, 86);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(486, 283);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutBankSlip.Control = this.txtReceiptNumber;
		this.layoutBankSlip.CustomizationFormText = "Bankslip No.";
		this.layoutBankSlip.Location = new System.Drawing.Point(0, 110);
		this.layoutBankSlip.Name = "layoutBankSlip";
		this.layoutBankSlip.Size = new System.Drawing.Size(289, 30);
		this.layoutBankSlip.Text = "Bankslip No.";
		this.layoutBankSlip.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutBankSlip.TextSize = new System.Drawing.Size(0, 0);
		this.layoutBankSlip.TextVisible = false;
		this.layoutControlItem6.Control = this.dtPayment;
		this.layoutControlItem6.CustomizationFormText = "Date:";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 140);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(289, 30);
		this.layoutControlItem6.Text = "Date:";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem14.Control = this.lookUpStudents;
		this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
		this.layoutControlItem14.Location = new System.Drawing.Point(289, 0);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(431, 30);
		this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem14.TextVisible = false;
		this.layoutControlItem5.Control = this.txtConfirmStudentNumber;
		this.layoutControlItem5.CustomizationFormText = "Student #";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(289, 30);
		this.layoutControlItem5.Text = "Student #";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem7.Control = this.txtAccNo;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 86);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(289, 24);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem9.Control = this.btnProcessPayment;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 342);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(289, 27);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem3.Control = this.navigationFrame1;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 191);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(289, 151);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem15.Control = this.toggleSwitch1;
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 170);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(289, 21);
		this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem15.TextVisible = false;
		this.layoutControlItem2.Control = this.cboStudents;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(289, 30);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem12.Control = this.gridLookUpEdit1;
		this.layoutControlItem12.CustomizationFormText = "Advanced Search";
		this.layoutControlItem12.Location = new System.Drawing.Point(289, 30);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(486, 56);
		this.layoutControlItem12.Text = "Advanced Search";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextVisible = false;
		this.layoutControlItem4.Control = this.cboPayToAccount;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 30);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(289, 26);
		this.layoutControlItem4.Text = "Pay By:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(36, 13);
		this.layoutControlItem11.Control = this.simpleButton1;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(720, 0);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(55, 30);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.popupMenu1.ItemLinks.Add(this.barButtonItem1);
		this.popupMenu1.ItemLinks.Add(this.barButtonItem2);
		this.popupMenu1.ItemLinks.Add(this.barButtonItem3);
		this.popupMenu1.ItemLinks.Add(this.barButtonItem11);
		this.popupMenu1.ItemLinks.Add(this.barButtonItem14);
		this.popupMenu1.Name = "popupMenu1";
		this.popupMenu1.Ribbon = this.ribbonControl1;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.ClientSize = new System.Drawing.Size(775, 525);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.ribbonStatusBar1);
		base.Controls.Add(this.ribbonControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "StudentFeesPayment";
		this.Ribbon = this.ribbonControl1;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.StatusBar = this.ribbonStatusBar1;
		this.Text = "Fees Payment";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(StudentFeesPayment_FormClosing);
		base.Load += new System.EventHandler(FeesPayment_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(StudentFeesPayment_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.repositoryItemComboBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStudentPicture).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupControlContainer1).EndInit();
		this.popupControlContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).EndInit();
		this.layoutControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.checkEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBillingDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBillingDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemCheckEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemToggleSwitch1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.toggleSwitch1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).EndInit();
		this.navigationFrame1.ResumeLayout(false);
		this.navigationPage1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridPayableItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		this.navigationPage2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboPayToAccount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStudents.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtConfirmStudentNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtPayment.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceiptNumber.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridStudentPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpStudents.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutBankSlip).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
