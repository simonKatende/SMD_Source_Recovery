using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Security;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class OldStudentsPayment : RibbonForm
{
	private DataTable e_dt;

	private DataTable dt_FeesLedger;

	private SqlTransaction transaction;

	private IContainer components = null;

	private RibbonControl ribbon;

	private RibbonPage ribbonPage1;

	private RibbonPageGroup ribbonPageGroup1;

	private LayoutControl layoutControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private GridColumn colStudentNo;

	private GridColumn colName;

	private GridColumn colSex;

	private GridColumn colHouse;

	private GridColumn colBursaryStatus;

	private GridColumn colcashOnAccount;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private RibbonPageGroup ribbonPageGroup2;

	private PrintingSystem printingSystem1;

	private PrintableComponentLink printableComponentLink1;

	private BarButtonItem barButtonItem4;

	private RibbonPageGroup ribbonPageGroup3;

	private GridControl gridControl2;

	private GridView gridView2;

	private LayoutControlItem layoutControlItem4;

	private GridColumn gridColumn1;

	private GridColumn colClass;

	private GridColumn colExitYear;

	private System.Windows.Forms.Timer timer1;

	private BarButtonItem barButtonItem5;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private BarButtonItem barButtonItem6;

	public OldStudentsPayment()
	{
		SplashScreenManager.ShowForm(this, typeof(WaitForm1), useFadeIn: false, useFadeOut: false, throwExceptionIfAlreadyOpened: false);
		SplashScreenManager.Default.SetWaitFormDescription("Loading former Candidates...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadPreviousCandidates, 0);
		Thread.Sleep(25);
		InitializeComponent();
		base.WindowState = FormWindowState.Maximized;
		LoadLeftStudents();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private string ReportHeader(string report_header)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
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
				text = AlienAge.Security.CryptorEngine.Decrypt(row["SchoolName"].ToString());
				text2 = AlienAge.Security.CryptorEngine.Decrypt(row["fullContact"].ToString());
				text3 = AlienAge.Security.CryptorEngine.Decrypt(row["location"].ToString());
			}
		}
		catch (Exception)
		{
		}
		return printableComponentLink1.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs22 {text}\\par\r\n{text3}\\par\r\n{text2}\\par\r\n{string.Empty}\\par\r\n\\par\r\n{report_header}\\par\r\n}}\r\n";
	}

	private void LoadStudentLegder(string studentNumber)
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT PaymentId AS Ref, StudentNumber,DateOfPayment AS Date,BankSlipNo,SemesterId AS Term,Particulars, Debit AS Dr, Credit AS Cr,Balance AS Bal FROM FeesPayment WHERE StudentNumber='{studentNumber}' ORDER BY PaymentId", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "StudentLedger");
		dt_FeesLedger = new DataTable();
		dt_FeesLedger = dataSet.Tables[0];
		gridControl2.DataSource = dt_FeesLedger.DefaultView;
		gridView2.OptionsBehavior.Editable = false;
		gridView2.OptionsCustomization.AllowGroup = false;
		gridView2.OptionsCustomization.AllowSort = false;
		gridView2.OptionsView.ShowGroupPanel = false;
		gridView2.Columns["Ref"].Visible = false;
		gridView2.Columns["StudentNumber"].Visible = false;
		gridView2.Columns["Dr"].DisplayFormat.FormatType = FormatType.Numeric;
		gridView2.Columns["Dr"].DisplayFormat.FormatString = "{0:#,#.0}";
		gridView2.Columns["Cr"].DisplayFormat.FormatType = FormatType.Numeric;
		gridView2.Columns["Cr"].DisplayFormat.FormatString = "{0:#,#.0}";
		gridView2.Columns["Bal"].DisplayFormat.FormatType = FormatType.Numeric;
		gridView2.Columns["Bal"].DisplayFormat.FormatString = "{0:#,#.0}";
		gridView2.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
		gridView2.Columns["Date"].DisplayFormat.FormatString = "{0:dd-MMM-yy}";
		GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
		gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
		gridColumnSummaryItem.FieldName = "Dr";
		gridView2.Columns["Dr"].SummaryItem.Assign(gridColumnSummaryItem);
		GridColumnSummaryItem gridColumnSummaryItem2 = new GridColumnSummaryItem();
		gridColumnSummaryItem2.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
		gridColumnSummaryItem2.FieldName = "Cr";
		gridView2.Columns["Cr"].SummaryItem.Assign(gridColumnSummaryItem2);
		GridColumnSummaryItem gridColumnSummaryItem3 = new GridColumnSummaryItem();
		gridColumnSummaryItem3.SetSummary(SummaryItemType.Custom, "{0:#,#.0}");
		gridColumnSummaryItem3.FieldName = "Bal";
		gridView2.Columns["Bal"].SummaryItem.Assign(gridColumnSummaryItem3);
	}

	private void LoadLeftStudents()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT (RequiredFees-RequiredFees) AS No, fullName, GuardianRelation, sNIN, fName, ReportCentre, HealthStatus, Cocurricular, fAddress, fContact, fEmail, mName, mAddress, mContact, mEmail, Oid, UPPER(StudentNumber) AS StudentNumber, ClassId, StreamId, Sex, StudyStatus, HouseId, Religion, Guardian, FormerSchool, DOB, BursaryStatus, RequiredFees, BursaryProvider, AdmissionDate, Picture, HomeCountry, Status, Notes, cashOnAccount, ExitYear, PriorityContact, OtherContact, LIN, StudentID,GuardianAddress FROM tbl_oldStudents", selectConnection);
			e_dt = new DataTable();
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "LeftStudents");
			e_dt = dataSet.Tables[0];
			gridControl1.DataSource = e_dt;
			timer1.Enabled = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public void OldStudentCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = e_dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			using StudentFeesPayment studentFeesPayment = new StudentFeesPayment("OldStudentPayment")
			{
				Text = "Old Student Fees Payment"
			};
			StudentOptions.SetActiveStudent(dataRow["StudentNumber"].ToString());
			StudentOptions.SetPaymentMode("SingleStudentOld");
			studentFeesPayment.RefreshList = OldStudentCallBackFN;
			studentFeesPayment.ShowDialog();
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			printableComponentLink1.ClearDocument();
			DataRow dataRow = e_dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			LoadStudentLegder(dataRow["StudentNumber"].ToString());
			printableComponentLink1.Component = gridControl2;
			ReportHeader(string.Format("{0} ({1})", dataRow["fullName"], dataRow["StudentNumber"]));
			printableComponentLink1.PrintDlg();
		}
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			printableComponentLink1.ClearDocument();
			DataRow dataRow = e_dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			LoadStudentLegder(dataRow["StudentNumber"].ToString());
			printableComponentLink1.Component = gridControl2;
			ReportHeader(string.Format("{0} ({1})", dataRow["fullName"], dataRow["StudentNumber"]));
			printableComponentLink1.ShowRibbonPreview(UserLookAndFeel.Default.ActiveLookAndFeel);
		}
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		printableComponentLink1.ClearDocument();
		printableComponentLink1.Component = gridControl1;
		ReportHeader("Students Through this School");
		printableComponentLink1.ShowRibbonPreview(UserLookAndFeel.Default.ActiveLookAndFeel);
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "No" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void OldStudentsPayment_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Dispose();
		}
	}

	private void OldStudentsPayment_Load(object sender, EventArgs e)
	{
		AppendFeesArreatsAccount();
	}

	private void AppendFeesArreatsAccount()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_generalAccounts_Sub WHERE SubAccoutName='Fees Arrears'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				return;
			}
			sqlDataReader.Close();
			string nextSubAccountNumber = FinalAccounts.GetNextSubAccountNumber(1000, 1001);
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
			sqlParameter.Value = 1001;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand2.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = nextSubAccountNumber;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand2.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
			sqlParameter.Value = "Fees Arrears";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand2.Parameters.Add("@RefNo", SqlDbType.VarChar, 25);
			sqlParameter.Value = string.Empty;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		LoadLeftStudents();
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		NormalizeLedgers_OldStuds normalizeLedgers_OldStuds = new NormalizeLedgers_OldStuds();
		normalizeLedgers_OldStuds.RefreshList = OldStudentCallBackFN;
		normalizeLedgers_OldStuds.ShowDialog();
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (XtraMessageBox.Show("Do you really want to re-enroll this students?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}
		using ReAssignClass reAssignClass = new ReAssignClass();
		if (reAssignClass.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string value = reAssignClass.txtTargetClass.SelectedItem.ToString();
		string value2 = reAssignClass.txtTargetStream.SelectedItem.ToString();
		Image @default = Resources.Default;
		int num = @default.Height;
		int num2 = @default.Width;
		num = num * 220 / num2;
		num2 = 220;
		if (num > 250)
		{
			num2 = num2 * 250 / num;
			num = 250;
		}
		Bitmap bitmap = new Bitmap(@default, num2, num);
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		byte[] array = new byte[memoryStream.Length + 1];
		memoryStream.Read(array, 0, array.Length);
		using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection.Open();
			transaction = sqlConnection.BeginTransaction();
			DataRow dataRow = e_dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			string value3 = dataRow["StudentID"].ToString();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_Stud (StudentNumber,HouseId,ClassId,StreamId,Oid,FormerSchool,StudyStatus,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Sex,Picture,Religion,HomeCountry,fullName,Status,Notes,cashOnAccount,fName,fContact,fAddress,fEmail,mName,mContact,mAddress,mEmail,DOB,IsTheologyStud,PrimaryScores1,StudentID,PriorityContact,OtherContact,GuardianAddress)VALUES(@StudentNumber,@HouseId,@ClassId,@StreamId,@Oid,@FormerSchool,@StudyStatus,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Sex,@Picture,@Religion,@HomeCountry,@fullName,@Status,@Notes,@cashOnAccount,@fName,@fContact,@fAddress,@fEmail,@mName,@mContact,@mAddress,@mEmail,@DOB,@IsTheologyStud,@PrimaryScores1,@StudentID,@PriorityContact,@OtherContact,@GuardianAddress)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = dataRow["StudentNumber"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar, 12);
				sqlParameter.Value = value3;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["HouseId"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 50);
				sqlParameter.Value = value2;
				sqlParameter.Direction = ParameterDirection.Input;
				Guid guid = new Guid(dataRow["Oid"].ToString());
				sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = guid;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
				sqlParameter.Value = "";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
				sqlParameter.Value = dataRow["StudyStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.Bit);
				sqlParameter.Value = false;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
				sqlParameter.Value = 0;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
				sqlParameter.Value = "";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
				sqlParameter.Value = Convert.ToInt32(dataRow["AdmissionDate"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = dataRow["Sex"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
				sqlParameter.Value = array;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["Religion"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["HomeCountry"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 100);
				sqlParameter.Value = dataRow["fullName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
				sqlParameter.Value = dataRow["Notes"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 30);
				sqlParameter.Value = "Active";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(dataRow["cashOnAccount"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fName", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = dataRow["fContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fEmail"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mName", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["mName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["mAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = dataRow["mContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["mEmail"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				DateTime result = (DateTime.TryParse(dataRow["DOB"].ToString(), out result) ? result : DateTime.Now);
				sqlParameter = sqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@IsTheologyStud", SqlDbType.Bit);
				sqlParameter.Value = false;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PrimaryScores1", SqlDbType.VarChar, 50);
				sqlParameter.Value = "";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@sNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["sNIN"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@LIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["LIN"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ReportCentre", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["ReportCentre"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Cocurricular", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["Cocurricular"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HealthStatus", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["HealthStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianPic", SqlDbType.Image);
				sqlParameter.Value = DBNull.Value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianRelation", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["GuardianRelation"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PriorityContact", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["PriorityContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@OtherContact", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["OtherContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianAddress", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["GuardianAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_oldStudents WHERE StudentNumber=@StudentNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter2.Value = dataRow["StudentNumber"].ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			transaction.Commit();
			sqlConnection.Close();
		}
		LoadLeftStudents();
		CustomDialog.ShowCustomDialog("Re-assignment successful.");
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
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item2 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item3 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item4 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.OldStudentsPayment));
		this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStudentNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colClass = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colHouse = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colBursaryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colcashOnAccount = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colExitYear = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
		this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		((System.ComponentModel.ISupportInitialize)this.ribbon).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		base.SuspendLayout();
		this.ribbon.ApplicationButtonText = null;
		this.ribbon.ExpandCollapseItem.Id = 0;
		this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[7]
		{
			this.ribbon.ExpandCollapseItem,
			this.barButtonItem1,
			this.barButtonItem2,
			this.barButtonItem3,
			this.barButtonItem4,
			this.barButtonItem5,
			this.barButtonItem6
		});
		this.ribbon.Location = new System.Drawing.Point(0, 0);
		this.ribbon.MaxItemId = 7;
		this.ribbon.Name = "ribbon";
		this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbon.ShowToolbarCustomizeItem = false;
		this.ribbon.Size = new System.Drawing.Size(903, 158);
		this.ribbon.Toolbar.ShowCustomizeItem = false;
		this.barButtonItem1.Caption = "Pay Fees";
		this.barButtonItem1.Id = 1;
		this.barButtonItem1.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.PayFees;
		this.barButtonItem1.Name = "barButtonItem1";
		toolTipTitleItem.Text = "Fees Payment";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Receive fees payment from former candidates.";
		toolTipTitleItem2.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem2.Appearance.Options.UseImage = true;
		toolTipTitleItem2.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem2.LeftIndent = 6;
		toolTipTitleItem2.Text = "Press F1 for help.";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		superToolTip.Items.Add(item);
		superToolTip.Items.Add(toolTipTitleItem2);
		this.barButtonItem1.SuperTip = superToolTip;
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Print";
		this.barButtonItem2.Id = 2;
		this.barButtonItem2.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.printLedger;
		this.barButtonItem2.Name = "barButtonItem2";
		toolTipTitleItem3.Text = "Print Ledger";
		toolTipItem2.LeftIndent = 6;
		toolTipItem2.Text = "Print Ledger for the currently selected former candidate.";
		toolTipTitleItem4.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem4.Appearance.Options.UseImage = true;
		toolTipTitleItem4.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem4.LeftIndent = 6;
		toolTipTitleItem4.Text = "Press F1 for help.";
		superToolTip2.Items.Add(toolTipTitleItem3);
		superToolTip2.Items.Add(toolTipItem2);
		superToolTip2.Items.Add(item2);
		superToolTip2.Items.Add(toolTipTitleItem4);
		this.barButtonItem2.SuperTip = superToolTip2;
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Preview";
		this.barButtonItem3.Id = 3;
		this.barButtonItem3.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.previewLedger;
		this.barButtonItem3.Name = "barButtonItem3";
		toolTipTitleItem5.Text = "Preview Ledger";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "Preview Ledger for the currently selected former candidate.";
		toolTipTitleItem6.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem6.Appearance.Options.UseImage = true;
		toolTipTitleItem6.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem6.LeftIndent = 6;
		toolTipTitleItem6.Text = "Press F1 for help.";
		superToolTip3.Items.Add(toolTipTitleItem5);
		superToolTip3.Items.Add(toolTipItem3);
		superToolTip3.Items.Add(item3);
		superToolTip3.Items.Add(toolTipTitleItem6);
		this.barButtonItem3.SuperTip = superToolTip3;
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "Print List";
		this.barButtonItem4.Id = 4;
		this.barButtonItem4.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.printList;
		this.barButtonItem4.Name = "barButtonItem4";
		toolTipTitleItem7.Text = "Print List";
		toolTipItem4.LeftIndent = 6;
		toolTipItem4.Text = "Print the entire former candidates list.";
		toolTipTitleItem8.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem8.Appearance.Options.UseImage = true;
		toolTipTitleItem8.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem8.LeftIndent = 6;
		toolTipTitleItem8.Text = "Press F1 for help.";
		superToolTip4.Items.Add(toolTipTitleItem7);
		superToolTip4.Items.Add(toolTipItem4);
		superToolTip4.Items.Add(item4);
		superToolTip4.Items.Add(toolTipTitleItem8);
		this.barButtonItem4.SuperTip = superToolTip4;
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem5.Caption = "Normalize Ledgers";
		this.barButtonItem5.Id = 5;
		this.barButtonItem5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.Image");
		this.barButtonItem5.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.LargeImage");
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[3] { this.ribbonPageGroup1, this.ribbonPageGroup2, this.ribbonPageGroup3 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "Tasks";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem6);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.Text = "Tasks";
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.Text = "Ledger";
		this.ribbonPageGroup3.AllowTextClipping = false;
		this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup3.Name = "ribbonPageGroup3";
		this.ribbonPageGroup3.Text = "Printing";
		this.layoutControl1.Controls.Add(this.gridControl2);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 158);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(903, 461);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControl2.Location = new System.Drawing.Point(107, 427);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(794, 32);
		this.gridControl2.TabIndex = 7;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsCustomization.AllowGroup = false;
		this.gridView2.OptionsFind.AlwaysVisible = true;
		this.gridView2.OptionsView.ShowAutoFilterRow = true;
		this.gridView2.OptionsView.ShowFooter = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(440, 401);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(461, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.simpleButton1.Location = new System.Drawing.Point(2, 401);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(434, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "OK";
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(899, 395);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[11]
		{
			this.gridColumn1, this.colStudentNo, this.colName, this.colSex, this.colClass, this.colHouse, this.colBursaryStatus, this.colcashOnAccount, this.colExitYear, this.gridColumn2,
			this.gridColumn3
		});
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsPrint.PrintFilterInfo = true;
		this.gridView1.OptionsPrint.PrintHorzLines = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowAutoFilterRow = true;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.gridColumn1.Caption = "No.";
		this.gridColumn1.FieldName = "No";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 33;
		this.colStudentNo.Caption = "Student#";
		this.colStudentNo.FieldName = "StudentNumber";
		this.colStudentNo.Name = "colStudentNo";
		this.colStudentNo.Visible = true;
		this.colStudentNo.VisibleIndex = 1;
		this.colStudentNo.Width = 106;
		this.colName.Caption = "Name";
		this.colName.FieldName = "fullName";
		this.colName.Name = "colName";
		this.colName.Visible = true;
		this.colName.VisibleIndex = 2;
		this.colName.Width = 206;
		this.colSex.Caption = "Sex";
		this.colSex.FieldName = "Sex";
		this.colSex.Name = "colSex";
		this.colSex.Visible = true;
		this.colSex.VisibleIndex = 3;
		this.colSex.Width = 31;
		this.colClass.Caption = "Class";
		this.colClass.FieldName = "ClassId";
		this.colClass.Name = "colClass";
		this.colClass.Visible = true;
		this.colClass.VisibleIndex = 4;
		this.colClass.Width = 42;
		this.colHouse.Caption = "House";
		this.colHouse.FieldName = "HouseId";
		this.colHouse.Name = "colHouse";
		this.colHouse.Visible = true;
		this.colHouse.VisibleIndex = 5;
		this.colHouse.Width = 100;
		this.colBursaryStatus.Caption = "Bursary Status";
		this.colBursaryStatus.FieldName = "BursaryStatus";
		this.colBursaryStatus.Name = "colBursaryStatus";
		this.colBursaryStatus.Visible = true;
		this.colBursaryStatus.VisibleIndex = 6;
		this.colBursaryStatus.Width = 92;
		this.colcashOnAccount.Caption = "Fees Balance";
		this.colcashOnAccount.DisplayFormat.FormatString = "{0:#,#}";
		this.colcashOnAccount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colcashOnAccount.FieldName = "cashOnAccount";
		this.colcashOnAccount.Name = "colcashOnAccount";
		this.colcashOnAccount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cashOnAccount", "{0:#,#.0}")
		});
		this.colcashOnAccount.Visible = true;
		this.colcashOnAccount.VisibleIndex = 7;
		this.colcashOnAccount.Width = 108;
		this.colExitYear.Caption = "ExitYear";
		this.colExitYear.FieldName = "ExitYear";
		this.colExitYear.Name = "colExitYear";
		this.colExitYear.Visible = true;
		this.colExitYear.VisibleIndex = 8;
		this.colExitYear.Width = 48;
		this.gridColumn2.Caption = "Priority Contact";
		this.gridColumn2.FieldName = "PriorityContact";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 9;
		this.gridColumn2.Width = 55;
		this.gridColumn3.Caption = "Other Contact";
		this.gridColumn3.FieldName = "OtherContact";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 10;
		this.gridColumn3.Width = 55;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(903, 461);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(903, 399);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 399);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(438, 26);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton2;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(438, 399);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(465, 26);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.gridControl2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 425);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(903, 36);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
		this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.printingSystem1.ShowMarginsWarning = false;
		this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.barButtonItem6.Caption = "Re-Enroll";
		this.barButtonItem6.Id = 6;
		this.barButtonItem6.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem6.ImageOptions.LargeImage");
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(903, 619);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.ribbon);
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "OldStudentsPayment";
		this.Ribbon = this.ribbon;
		base.ShowInTaskbar = false;
		base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Former candidates accounts information";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.Load += new System.EventHandler(OldStudentsPayment_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(OldStudentsPayment_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.ribbon).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
