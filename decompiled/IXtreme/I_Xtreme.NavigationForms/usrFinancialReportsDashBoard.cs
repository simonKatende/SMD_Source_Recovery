using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrFinancialReportsDashBoard : XtraUserControl
{
	private int k = 0;

	private int ___LedgerNo = 0;

	private IContainer components = null;

	private PictureEdit pictureEdit1;

	private LabelControl labelControl1;

	private NavigationFrame navigationFinancialReports;

	private NavigationPage pageMain;

	private NavigationPage pageIncome;

	private NavigationPage pageExpenses;

	private PivotGridControl pivotGridControl1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField7;

	private PivotGridField pivotGridField8;

	private LayoutControl layoutControl1;

	private LabelControl lblDateRange;

	private LabelControl lblReportHeader;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlReportHeader;

	private LayoutControlItem layoutControlIReportDate;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private NavigationPage pageTrialBalance;

	private NavigationPage pageIncomeStatement;

	private NavigationPage pageBalanceSheet;

	private NavigationPage pageCashbook;

	private NavigationPage pageAccountLedgers;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private PivotGridControl pivotGridControl2;

	private PivotGridField pivotGridFieldMajorGroup;

	private PivotGridField pivotGridFieldCategory;

	private PivotGridField pivotGridFieldSubAccountName;

	private PivotGridField pivotGridFieldSubAccountNo;

	private PivotGridField pivotGridFieldOpenningBalance;

	private PivotGridField pivotGridFieldAccountBalance;

	private PivotGridField pivotGridFieldTotal;

	private GridBand gridBand1;

	private BandedGridColumn bandedGridColDate;

	private BandedGridColumn bandedGridColParticulars;

	private BandedGridColumn bandedGridColTrxRef;

	private BandedGridColumn bandedGridColAccountRef;

	private GridBand gridBandDR;

	private BandedGridColumn bandedGridColcDr;

	private BandedGridColumn bandedGridColbDr;

	private GridBand gridBandCR;

	private BandedGridColumn bandedGridColcCr;

	private BandedGridColumn bandedGridColbCr;

	private Timer timer1;

	private MyGridControl myGridControl2;

	private MyBandedGridView myBandedGridView1;

	private GridBand gridBand2;

	private BandedGridColumn bandedGridColumn1;

	private BandedGridColumn bandedGridColumn2;

	private BandedGridColumn bandedGridColumn3;

	private BandedGridColumn bandedGridColumn4;

	private GridBand gridBand3;

	private BandedGridColumn bandedGridColumn5;

	private BandedGridColumn bandedGridColumn6;

	private GridBand gridBand4;

	private BandedGridColumn bandedGridColumn7;

	private BandedGridColumn bandedGridColumn8;

	private MyGridControl gridControlAccountLedger;

	private MyGridView gridViewAccountLedger;

	private GridColumn gridColDate;

	private GridColumn gridColParticulars;

	private GridColumn gridTrRef;

	private GridColumn gridColDr;

	private GridColumn gridColCr;

	private GridColumn gridColBal;

	private GridColumn gridColumn12;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private MyGridControl myGridControl1;

	private MyGridView myGridView1;

	private GridColumn gridColumn13;

	private GridColumn gridColumn14;

	private GridColumn gridColumn15;

	private GridColumn gridRevenue;

	private GridColumn gridExpenses;

	private GridColumn gridColumn18;

	private GridColumn gridColumn16;

	private GridColumn gridColumn17;

	private GridColumn gridColumn19;

	private GridColumn gridColumn20;

	private GridColumn gridColumn21;

	private NavigationPage pageExpensesGrouped;

	private LayoutControl layoutControl2;

	private MyGridControl gridControl2;

	private MyGridView gridView2;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem2;

	private GridColumn gridColumn22;

	private GridColumn gridColumn23;

	private GridColumn gridColumn24;

	private GridColumn gridColumn25;

	private GridColumn gridColumn26;

	private GridColumn gridColumn27;

	private GridControl gridTrialBalance;

	private GridView gridView3;

	public usrFinancialReportsDashBoard()
	{
		InitializeComponent();
	}

	public void AccountReportFN(DateTime StartDate, DateTime EndDate, string navPage, string AccountName, DataTable dt, int LedgerNo)
	{
		switch (navPage)
		{
		case "pageMain":
			layoutControlReportHeader.Visibility = LayoutVisibility.Never;
			layoutControlIReportDate.Visibility = LayoutVisibility.Never;
			navigationFinancialReports.SelectedPage = pageMain;
			break;
		case "pageIncome":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			gridControl1.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(gridControl1);
			navigationFinancialReports.SelectedPage = pageIncome;
			lblReportHeader.Text = "Total Income";
			break;
		case "pageExpenses":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			pivotGridControl1.DataSource = dt;
			PrintableControl.SavePrintableControl(pivotGridControl1);
			navigationFinancialReports.SelectedPage = pageExpenses;
			lblReportHeader.Text = "Total Expenditure";
			break;
		case "pageExpensesGrouped":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			gridControl2.DataSource = dt;
			PrintableControl.SavePrintableControl(gridControl2);
			navigationFinancialReports.SelectedPage = pageExpensesGrouped;
			lblReportHeader.Text = "Total Expenditure";
			break;
		case "pageTrialBalance":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			gridTrialBalance.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(gridTrialBalance);
			navigationFinancialReports.SelectedPage = pageTrialBalance;
			lblReportHeader.Text = "Trial Balance";
			break;
		case "pageIncomeStatement":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			myGridControl1.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(myGridControl1);
			navigationFinancialReports.SelectedPage = pageIncomeStatement;
			lblReportHeader.Text = "Income Statement";
			break;
		case "pageBalanceSheet":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			pivotGridControl2.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(pivotGridControl2);
			navigationFinancialReports.SelectedPage = pageBalanceSheet;
			lblReportHeader.Text = "Balance Sheet";
			break;
		case "pageCashbook":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			myGridControl2.DataSource = dt.DefaultView;
			navigationFinancialReports.SelectedPage = pageCashbook;
			lblReportHeader.Text = "Cashbook Analysis";
			k = 0;
			timer1.Enabled = true;
			break;
		case "pageAccountLedgers":
			layoutControlReportHeader.Visibility = LayoutVisibility.Always;
			layoutControlIReportDate.Visibility = LayoutVisibility.Always;
			gridControlAccountLedger.DataSource = dt.DefaultView;
			___LedgerNo = LedgerNo;
			PrintableControl.SavePrintableControl(gridControlAccountLedger);
			navigationFinancialReports.SelectedPage = pageAccountLedgers;
			lblReportHeader.Text = $"{AccountName} Analysis";
			break;
		}
		lblDateRange.Text = string.Format("From {0} to {1}", StartDate.ToString("dd-MM-yyyy"), EndDate.ToString("dd-MM-yyyy"));
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 3)
		{
			timer1.Enabled = false;
			k = 0;
			double num = Convert.ToDouble(myBandedGridView1.Columns["dBank"].SummaryItem.SummaryValue) - Convert.ToDouble(myBandedGridView1.Columns["cBank"].SummaryItem.SummaryValue);
			double num2 = Convert.ToDouble(myBandedGridView1.Columns["dCash"].SummaryItem.SummaryValue) - Convert.ToDouble(myBandedGridView1.Columns["cCash"].SummaryItem.SummaryValue);
			if (num > 0.0)
			{
				myBandedGridView1.SetRowCellValue(myBandedGridView1.RowCount - 1, "cBank", num);
			}
			else if (num < 0.0)
			{
				myBandedGridView1.SetRowCellValue(myBandedGridView1.RowCount - 1, "dBank", Math.Abs(num));
			}
			if (num2 > 0.0)
			{
				myBandedGridView1.SetRowCellValue(myBandedGridView1.RowCount - 1, "cCash", num2);
			}
			else if (num2 < 0.0)
			{
				myBandedGridView1.SetRowCellValue(myBandedGridView1.RowCount - 1, "dCash", Math.Abs(num2));
			}
			PrintableControl.SavePrintableControl(myGridControl2);
		}
	}

	private void gridViewAccountLedger_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
	{
		if (___LedgerNo >= 5000)
		{
			if (((GridSummaryItem)e.Item).FieldName == "Bal")
			{
				double num = Convert.ToDouble(gridColCr.SummaryItem.SummaryValue) - Convert.ToDouble(gridColDr.SummaryItem.SummaryValue);
				e.TotalValue = num;
			}
		}
		else if (((GridSummaryItem)e.Item).FieldName == "Bal")
		{
			double num2 = Convert.ToDouble(gridColDr.SummaryItem.SummaryValue) - Convert.ToDouble(gridColCr.SummaryItem.SummaryValue);
			e.TotalValue = num2;
		}
	}

	private void gridViewAccountLedger_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
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

	private void gridViewAccountLedger_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
	{
		EmptyForeGroundCustomDraw.DrawEmptyForeGround(e, "No data records found to display!");
	}

	private void myGridView1_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
	{
		if (((GridSummaryItem)e.Item).FieldName == "Bal")
		{
			double num = Convert.ToDouble(myGridView1.Columns["Credit"].SummaryItem.SummaryValue) - Convert.ToDouble(myGridView1.Columns["Debit"].SummaryItem.SummaryValue);
			e.TotalValue = num;
		}
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
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
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.navigationFinancialReports = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.pageMain = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.pageExpenses = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pageBalanceSheet = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.pivotGridControl2 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridFieldMajorGroup = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldCategory = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldSubAccountName = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldSubAccountNo = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldOpenningBalance = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldAccountBalance = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldTotal = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pageCashbook = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.myGridControl2 = new AlienAge.CustomGrid.MyGridControl();
		this.myBandedGridView1 = new AlienAge.CustomGrid.MyBandedGridView();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.pageIncome = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.pageIncomeStatement = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.myGridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.myGridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridRevenue = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridExpenses = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.pageTrialBalance = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridTrialBalance = new DevExpress.XtraGrid.GridControl();
		this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.pageAccountLedgers = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridControlAccountLedger = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewAccountLedger = new AlienAge.CustomGrid.MyGridView();
		this.gridColDate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColParticulars = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridTrRef = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColDr = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCr = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColBal = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.pageExpensesGrouped = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControl2 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView2 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColParticulars = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColTrxRef = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColAccountRef = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBandDR = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColcDr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColbDr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBandCR = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColcCr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColbCr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lblDateRange = new DevExpress.XtraEditors.LabelControl();
		this.lblReportHeader = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlReportHeader = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlIReportDate = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFinancialReports).BeginInit();
		this.navigationFinancialReports.SuspendLayout();
		this.pageMain.SuspendLayout();
		this.pageExpenses.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		this.pageBalanceSheet.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).BeginInit();
		this.pageCashbook.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.myGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myBandedGridView1).BeginInit();
		this.pageIncome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		this.pageIncomeStatement.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).BeginInit();
		this.pageTrialBalance.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridTrialBalance).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView3).BeginInit();
		this.pageAccountLedgers.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControlAccountLedger).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewAccountLedger).BeginInit();
		this.pageExpensesGrouped.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).BeginInit();
		this.layoutControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlReportHeader).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlIReportDate).BeginInit();
		base.SuspendLayout();
		this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.accounts__1_;
		this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(856, 495);
		this.pictureEdit1.TabIndex = 0;
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl1.Appearance.Options.UseBackColor = true;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl1.Location = new System.Drawing.Point(3, 86);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
		this.labelControl1.Size = new System.Drawing.Size(1139, 37);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Financial Reports";
		this.navigationFinancialReports.Controls.Add(this.pageMain);
		this.navigationFinancialReports.Controls.Add(this.pageExpenses);
		this.navigationFinancialReports.Controls.Add(this.pageBalanceSheet);
		this.navigationFinancialReports.Controls.Add(this.pageCashbook);
		this.navigationFinancialReports.Controls.Add(this.pageIncome);
		this.navigationFinancialReports.Controls.Add(this.pageIncomeStatement);
		this.navigationFinancialReports.Controls.Add(this.pageTrialBalance);
		this.navigationFinancialReports.Controls.Add(this.pageAccountLedgers);
		this.navigationFinancialReports.Controls.Add(this.pageExpensesGrouped);
		this.navigationFinancialReports.Location = new System.Drawing.Point(3, 52);
		this.navigationFinancialReports.Name = "navigationFinancialReports";
		this.navigationFinancialReports.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[9] { this.pageMain, this.pageIncome, this.pageExpenses, this.pageTrialBalance, this.pageIncomeStatement, this.pageBalanceSheet, this.pageCashbook, this.pageAccountLedgers, this.pageExpensesGrouped });
		this.navigationFinancialReports.SelectedPage = this.pageMain;
		this.navigationFinancialReports.Size = new System.Drawing.Size(856, 495);
		this.navigationFinancialReports.TabIndex = 5;
		this.navigationFinancialReports.Text = "navigationFrame1";
		this.pageMain.Caption = "pageMain";
		this.pageMain.Controls.Add(this.labelControl1);
		this.pageMain.Controls.Add(this.pictureEdit1);
		this.pageMain.Name = "pageMain";
		this.pageMain.Size = new System.Drawing.Size(856, 495);
		this.pageExpenses.Caption = "pageExpenses";
		this.pageExpenses.Controls.Add(this.pivotGridControl1);
		this.pageExpenses.Name = "pageExpenses";
		this.pageExpenses.Size = new System.Drawing.Size(856, 495);
		this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Cell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[8] { this.pivotGridField2, this.pivotGridField1, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5, this.pivotGridField6, this.pivotGridField7, this.pivotGridField8 });
		this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsDataField.RowHeaderWidth = 67;
		this.pivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsView.RowTreeOffset = 14;
		this.pivotGridControl1.OptionsView.RowTreeWidth = 67;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(856, 495);
		this.pivotGridControl1.TabIndex = 1;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "Vote Name";
		this.pivotGridField2.FieldName = "expenseSource";
		this.pivotGridField2.MinWidth = 13;
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.Width = 120;
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 2;
		this.pivotGridField1.Caption = "Item";
		this.pivotGridField1.FieldName = "ExpenseName";
		this.pivotGridField1.MinWidth = 13;
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.Width = 117;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField3.AreaIndex = 3;
		this.pivotGridField3.Caption = "Particulars";
		this.pivotGridField3.FieldName = "Narration";
		this.pivotGridField3.MinWidth = 13;
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.Width = 117;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField4.AreaIndex = 5;
		this.pivotGridField4.Caption = "Cheque #";
		this.pivotGridField4.FieldName = "ChequeNo";
		this.pivotGridField4.MinWidth = 13;
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField4.Width = 57;
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField5.AreaIndex = 4;
		this.pivotGridField5.Caption = "Vouher. #";
		this.pivotGridField5.FieldName = "VoucherNo";
		this.pivotGridField5.MinWidth = 13;
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.Width = 57;
		this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField6.AreaIndex = 0;
		this.pivotGridField6.Caption = "Amount";
		this.pivotGridField6.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField6.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField6.FieldName = "ExpenseValue";
		this.pivotGridField6.MinWidth = 13;
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.Width = 67;
		this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField7.AreaIndex = 0;
		this.pivotGridField7.Caption = "Date";
		this.pivotGridField7.CellFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField7.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField7.FieldName = "DateOfExpense";
		this.pivotGridField7.MinWidth = 13;
		this.pivotGridField7.Name = "pivotGridField7";
		this.pivotGridField7.ValueFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField7.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField7.Width = 57;
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField8.AreaIndex = 0;
		this.pivotGridField8.Caption = "PaymentMode";
		this.pivotGridField8.FieldName = "PaymentMode";
		this.pivotGridField8.MinWidth = 13;
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField8.Width = 66;
		this.pageBalanceSheet.Caption = "pageBalanceSheet";
		this.pageBalanceSheet.Controls.Add(this.pivotGridControl2);
		this.pageBalanceSheet.Name = "pageBalanceSheet";
		this.pageBalanceSheet.Size = new System.Drawing.Size(856, 495);
		this.pivotGridControl2.Appearance.Cell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.Cell.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.Cell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.Cell.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.Cell.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.ColumnHeaderArea.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.CustomTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.CustomTotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.CustomTotalCell.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.CustomTotalCell.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.DataHeaderArea.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.DataHeaderArea.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.DataHeaderArea.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.DataHeaderArea.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.Empty.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.Empty.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.Empty.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl2.Appearance.Empty.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.ExpandButton.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.ExpandButton.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.ExpandButton.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.ExpandButton.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl2.Appearance.ExpandButton.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.FieldHeader.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FieldHeader.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.FieldHeader.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldHeader.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.FieldValue.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.FieldValue.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldValue.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.FieldValueTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FieldValueTotal.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.FieldValueTotal.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldValueTotal.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.FilterHeaderArea.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FilterHeaderArea.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.FilterHeaderArea.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FilterHeaderArea.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.FilterSeparator.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FocusedCell.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.GrandTotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.GrandTotalCell.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.GrandTotalCell.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.HeaderArea.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.HeaderArea.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.HeaderArea.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.HeaderArea.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderArea.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.HeaderFilterButton.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.HeaderFilterButton.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.HeaderFilterButton.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderFilterButton.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl2.Appearance.Lines.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl2.Appearance.RowHeaderArea.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.RowHeaderArea.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.RowHeaderArea.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.RowHeaderArea.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.SelectedCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.SelectedCell.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.SelectedCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.SelectedCell.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.SelectedCell.Options.UseForeColor = true;
		this.pivotGridControl2.Appearance.TotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.Appearance.TotalCell.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridControl2.Appearance.TotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.Appearance.TotalCell.Options.UseBackColor = true;
		this.pivotGridControl2.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.TotalCell.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.Cell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.Cell.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.Cell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.Cell.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.Cell.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.FieldHeader.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.FieldHeader.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.FieldHeader.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldHeader.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.FieldValue.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.FieldValue.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldValue.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.Options.UseForeColor = true;
		this.pivotGridControl2.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.TotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl2.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.pivotGridControl2.AppearancePrint.TotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl2.AppearancePrint.TotalCell.Options.UseBackColor = true;
		this.pivotGridControl2.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.TotalCell.Options.UseForeColor = true;
		this.pivotGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridControl2.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[7] { this.pivotGridFieldMajorGroup, this.pivotGridFieldCategory, this.pivotGridFieldSubAccountName, this.pivotGridFieldSubAccountNo, this.pivotGridFieldOpenningBalance, this.pivotGridFieldAccountBalance, this.pivotGridFieldTotal });
		this.pivotGridControl2.Location = new System.Drawing.Point(0, 0);
		this.pivotGridControl2.Name = "pivotGridControl2";
		this.pivotGridControl2.OptionsDataField.RowHeaderWidth = 67;
		this.pivotGridControl2.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl2.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.True;
		this.pivotGridControl2.OptionsView.RowTreeOffset = 14;
		this.pivotGridControl2.OptionsView.RowTreeWidth = 67;
		this.pivotGridControl2.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl2.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl2.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl2.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl2.Size = new System.Drawing.Size(856, 495);
		this.pivotGridControl2.TabIndex = 6;
		this.pivotGridFieldMajorGroup.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridFieldMajorGroup.AreaIndex = 0;
		this.pivotGridFieldMajorGroup.Caption = "Category";
		this.pivotGridFieldMajorGroup.FieldName = "MajorGroup";
		this.pivotGridFieldMajorGroup.MinWidth = 13;
		this.pivotGridFieldMajorGroup.Name = "pivotGridFieldMajorGroup";
		this.pivotGridFieldMajorGroup.Width = 54;
		this.pivotGridFieldCategory.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridFieldCategory.AreaIndex = 1;
		this.pivotGridFieldCategory.Caption = "Acc Group";
		this.pivotGridFieldCategory.FieldName = "Category";
		this.pivotGridFieldCategory.MinWidth = 13;
		this.pivotGridFieldCategory.Name = "pivotGridFieldCategory";
		this.pivotGridFieldCategory.Width = 67;
		this.pivotGridFieldSubAccountName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridFieldSubAccountName.AreaIndex = 3;
		this.pivotGridFieldSubAccountName.Caption = "Account Title";
		this.pivotGridFieldSubAccountName.FieldName = "SubAccountName";
		this.pivotGridFieldSubAccountName.MinWidth = 13;
		this.pivotGridFieldSubAccountName.Name = "pivotGridFieldSubAccountName";
		this.pivotGridFieldSubAccountName.Width = 67;
		this.pivotGridFieldSubAccountNo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridFieldSubAccountNo.AreaIndex = 2;
		this.pivotGridFieldSubAccountNo.Caption = "Acc#";
		this.pivotGridFieldSubAccountNo.FieldName = "SubAccountNo";
		this.pivotGridFieldSubAccountNo.MinWidth = 13;
		this.pivotGridFieldSubAccountNo.Name = "pivotGridFieldSubAccountNo";
		this.pivotGridFieldSubAccountNo.Width = 67;
		this.pivotGridFieldOpenningBalance.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldOpenningBalance.AreaIndex = 0;
		this.pivotGridFieldOpenningBalance.Caption = "B/Foward";
		this.pivotGridFieldOpenningBalance.CellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldOpenningBalance.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldOpenningBalance.FieldName = "OpenningBalance";
		this.pivotGridFieldOpenningBalance.GrandTotalCellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldOpenningBalance.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldOpenningBalance.MinWidth = 13;
		this.pivotGridFieldOpenningBalance.Name = "pivotGridFieldOpenningBalance";
		this.pivotGridFieldOpenningBalance.TotalCellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldOpenningBalance.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldOpenningBalance.TotalValueFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldOpenningBalance.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldOpenningBalance.ValueFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldOpenningBalance.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldOpenningBalance.Width = 157;
		this.pivotGridFieldAccountBalance.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldAccountBalance.AreaIndex = 1;
		this.pivotGridFieldAccountBalance.Caption = "Curr. Bal.";
		this.pivotGridFieldAccountBalance.CellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldAccountBalance.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldAccountBalance.FieldName = "AccountBalance";
		this.pivotGridFieldAccountBalance.GrandTotalCellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldAccountBalance.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldAccountBalance.MinWidth = 13;
		this.pivotGridFieldAccountBalance.Name = "pivotGridFieldAccountBalance";
		this.pivotGridFieldAccountBalance.TotalCellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldAccountBalance.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldAccountBalance.TotalValueFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldAccountBalance.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldAccountBalance.ValueFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldAccountBalance.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldAccountBalance.Width = 157;
		this.pivotGridFieldTotal.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldTotal.AreaIndex = 2;
		this.pivotGridFieldTotal.Caption = "Total";
		this.pivotGridFieldTotal.CellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldTotal.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldTotal.FieldName = "Total";
		this.pivotGridFieldTotal.GrandTotalCellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldTotal.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldTotal.MinWidth = 13;
		this.pivotGridFieldTotal.Name = "pivotGridFieldTotal";
		this.pivotGridFieldTotal.TotalCellFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldTotal.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldTotal.TotalValueFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldTotal.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldTotal.ValueFormat.FormatString = "{0:#,#}";
		this.pivotGridFieldTotal.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridFieldTotal.Width = 173;
		this.pageCashbook.Caption = "pageCashbook";
		this.pageCashbook.Controls.Add(this.myGridControl2);
		this.pageCashbook.Name = "pageCashbook";
		this.pageCashbook.Size = new System.Drawing.Size(856, 495);
		this.myGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.myGridControl2.Location = new System.Drawing.Point(0, 0);
		this.myGridControl2.MainView = this.myBandedGridView1;
		this.myGridControl2.Name = "myGridControl2";
		this.myGridControl2.Size = new System.Drawing.Size(856, 495);
		this.myGridControl2.TabIndex = 10;
		this.myGridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myBandedGridView1 });
		this.myBandedGridView1.Appearance.BandPanel.BackColor = System.Drawing.Color.White;
		this.myBandedGridView1.Appearance.BandPanel.BackColor2 = System.Drawing.Color.White;
		this.myBandedGridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.BandPanel.ForeColor = System.Drawing.Color.Black;
		this.myBandedGridView1.Appearance.BandPanel.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.BandPanel.Options.UseFont = true;
		this.myBandedGridView1.Appearance.BandPanel.Options.UseForeColor = true;
		this.myBandedGridView1.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.BandPanelBackground.Options.UseFont = true;
		this.myBandedGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.myBandedGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.myBandedGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.myBandedGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.myBandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.Empty.Options.UseFont = true;
		this.myBandedGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myBandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.myBandedGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.myBandedGridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.Red;
		this.myBandedGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.FixedLine.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.myBandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.myBandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.myBandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myBandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.myBandedGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.myBandedGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.myBandedGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.myBandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.White;
		this.myBandedGridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.White;
		this.myBandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myBandedGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.myBandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.myBandedGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
		this.myBandedGridView1.Appearance.HeaderPanelBackground.BackColor = System.Drawing.Color.White;
		this.myBandedGridView1.Appearance.HeaderPanelBackground.BackColor2 = System.Drawing.Color.White;
		this.myBandedGridView1.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myBandedGridView1.Appearance.HeaderPanelBackground.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.myBandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myBandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.myBandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.OddRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.Preview.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.Preview.Options.UseFont = true;
		this.myBandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.Row.Options.UseFont = true;
		this.myBandedGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.myBandedGridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myBandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.myBandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.myBandedGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.VertLine.Options.UseFont = true;
		this.myBandedGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Courier New", 10f);
		this.myBandedGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.BandPanel.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myBandedGridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.myBandedGridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.myBandedGridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.myBandedGridView1.AppearancePrint.Row.Options.UseFont = true;
		this.myBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[3] { this.gridBand2, this.gridBand3, this.gridBand4 });
		this.myBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[8] { this.bandedGridColumn1, this.bandedGridColumn2, this.bandedGridColumn4, this.bandedGridColumn3, this.bandedGridColumn5, this.bandedGridColumn6, this.bandedGridColumn7, this.bandedGridColumn8 });
		this.myBandedGridView1.DetailHeight = 239;
		this.myBandedGridView1.GridControl = this.myGridControl2;
		this.myBandedGridView1.Name = "myBandedGridView1";
		this.myBandedGridView1.OptionsBehavior.Editable = false;
		this.myBandedGridView1.OptionsCustomization.AllowBandMoving = false;
		this.myBandedGridView1.OptionsCustomization.AllowColumnMoving = false;
		this.myBandedGridView1.OptionsCustomization.AllowFilter = false;
		this.myBandedGridView1.OptionsCustomization.AllowGroup = false;
		this.myBandedGridView1.OptionsCustomization.AllowSort = false;
		this.myBandedGridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.myBandedGridView1.OptionsPrint.PrintHorzLines = false;
		this.myBandedGridView1.OptionsPrint.UsePrintStyles = false;
		this.myBandedGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.myBandedGridView1.OptionsView.ShowFooter = true;
		this.myBandedGridView1.OptionsView.ShowGroupPanel = false;
		this.myBandedGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.myBandedGridView1.OptionsView.ShowIndicator = false;
		this.myBandedGridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.myBandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.bandedGridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBand2.AppearanceHeader.Options.UseFont = true;
		this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBand2.Caption = "Transaction Details";
		this.gridBand2.Columns.Add(this.bandedGridColumn1);
		this.gridBand2.Columns.Add(this.bandedGridColumn2);
		this.gridBand2.Columns.Add(this.bandedGridColumn3);
		this.gridBand2.Columns.Add(this.bandedGridColumn4);
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.OptionsBand.AllowHotTrack = false;
		this.gridBand2.OptionsBand.AllowMove = false;
		this.gridBand2.OptionsBand.AllowPress = false;
		this.gridBand2.OptionsBand.ShowInCustomizationForm = false;
		this.gridBand2.VisibleIndex = 0;
		this.gridBand2.Width = 364;
		this.bandedGridColumn1.Caption = "Date";
		this.bandedGridColumn1.DisplayFormat.FormatString = "dd.MM.yy";
		this.bandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.bandedGridColumn1.FieldName = "Date";
		this.bandedGridColumn1.MinWidth = 13;
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
		this.bandedGridColumn1.Visible = true;
		this.bandedGridColumn1.Width = 47;
		this.bandedGridColumn2.Caption = "Particulars";
		this.bandedGridColumn2.FieldName = "Particulars";
		this.bandedGridColumn2.MinWidth = 13;
		this.bandedGridColumn2.Name = "bandedGridColumn2";
		this.bandedGridColumn2.Visible = true;
		this.bandedGridColumn2.Width = 167;
		this.bandedGridColumn3.Caption = "Trx. Ref.";
		this.bandedGridColumn3.DisplayFormat.FormatString = "{0:#}";
		this.bandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColumn3.FieldName = "TrxRef";
		this.bandedGridColumn3.MinWidth = 13;
		this.bandedGridColumn3.Name = "bandedGridColumn3";
		this.bandedGridColumn3.Visible = true;
		this.bandedGridColumn4.Caption = "Account Title";
		this.bandedGridColumn4.FieldName = "AccountRef";
		this.bandedGridColumn4.MinWidth = 13;
		this.bandedGridColumn4.Name = "bandedGridColumn4";
		this.bandedGridColumn4.Visible = true;
		this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBand3.AppearanceHeader.Options.UseFont = true;
		this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBand3.Caption = "DR.";
		this.gridBand3.Columns.Add(this.bandedGridColumn5);
		this.gridBand3.Columns.Add(this.bandedGridColumn6);
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.OptionsBand.AllowHotTrack = false;
		this.gridBand3.OptionsBand.AllowMove = false;
		this.gridBand3.OptionsBand.AllowPress = false;
		this.gridBand3.OptionsBand.ShowInCustomizationForm = false;
		this.gridBand3.RowCount = 2;
		this.gridBand3.VisibleIndex = 1;
		this.gridBand3.Width = 116;
		this.bandedGridColumn5.Caption = "Cash";
		this.bandedGridColumn5.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColumn5.FieldName = "dCash";
		this.bandedGridColumn5.MinWidth = 13;
		this.bandedGridColumn5.Name = "bandedGridColumn5";
		this.bandedGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dCash", "{0:#,#.0}")
		});
		this.bandedGridColumn5.Visible = true;
		this.bandedGridColumn5.Width = 57;
		this.bandedGridColumn6.Caption = "Bank";
		this.bandedGridColumn6.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColumn6.FieldName = "dBank";
		this.bandedGridColumn6.MinWidth = 13;
		this.bandedGridColumn6.Name = "bandedGridColumn6";
		this.bandedGridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dBank", "{0:#,#.0}")
		});
		this.bandedGridColumn6.Visible = true;
		this.bandedGridColumn6.Width = 59;
		this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBand4.AppearanceHeader.Options.UseFont = true;
		this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBand4.Caption = "CR.";
		this.gridBand4.Columns.Add(this.bandedGridColumn7);
		this.gridBand4.Columns.Add(this.bandedGridColumn8);
		this.gridBand4.Name = "gridBand4";
		this.gridBand4.OptionsBand.AllowHotTrack = false;
		this.gridBand4.OptionsBand.AllowMove = false;
		this.gridBand4.OptionsBand.AllowPress = false;
		this.gridBand4.OptionsBand.ShowInCustomizationForm = false;
		this.gridBand4.VisibleIndex = 2;
		this.gridBand4.Width = 119;
		this.bandedGridColumn7.Caption = "Cash";
		this.bandedGridColumn7.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColumn7.FieldName = "cCash";
		this.bandedGridColumn7.MinWidth = 13;
		this.bandedGridColumn7.Name = "bandedGridColumn7";
		this.bandedGridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cCash", "{0:#,#.0}")
		});
		this.bandedGridColumn7.Visible = true;
		this.bandedGridColumn7.Width = 58;
		this.bandedGridColumn8.Caption = "Bank";
		this.bandedGridColumn8.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColumn8.FieldName = "cBank";
		this.bandedGridColumn8.MinWidth = 13;
		this.bandedGridColumn8.Name = "bandedGridColumn8";
		this.bandedGridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cBank", "{0:#,#.0}")
		});
		this.bandedGridColumn8.Visible = true;
		this.bandedGridColumn8.Width = 61;
		this.pageIncome.Caption = "pageIncome";
		this.pageIncome.Controls.Add(this.gridControl1);
		this.pageIncome.Name = "pageIncome";
		this.pageIncome.Size = new System.Drawing.Size(856, 495);
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(856, 495);
		this.gridControl1.TabIndex = 5;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Bold);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Bold);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Bold);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.FooterPanel.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Options.UseForeColor = true;
		this.gridView1.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.GroupFooter.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Options.UseForeColor = true;
		this.gridView1.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.GroupRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Options.UseForeColor = true;
		this.gridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.BackColor = System.Drawing.Color.White;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.Preview.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.Preview.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Options.UseForeColor = true;
		this.gridView1.AppearancePrint.Row.BackColor = System.Drawing.Color.White;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black;
		this.gridView1.AppearancePrint.Row.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Options.UseForeColor = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColumn16, this.gridColumn17, this.gridColumn19, this.gridColumn21, this.gridColumn20 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.GroupFormat = "{1} ({2})";
		this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "{0:#,#.0}")
		});
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsPrint.PrintHorzLines = false;
		this.gridView1.OptionsPrint.UsePrintStyles = false;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn16, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridColumn16.Caption = "SubAccoutName";
		this.gridColumn16.FieldName = "SubAccoutName";
		this.gridColumn16.MinWidth = 13;
		this.gridColumn16.Name = "gridColumn16";
		this.gridColumn16.Visible = true;
		this.gridColumn16.VisibleIndex = 0;
		this.gridColumn16.Width = 50;
		this.gridColumn17.Caption = "Date";
		this.gridColumn17.DisplayFormat.FormatString = "dd.MM.yy";
		this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn17.FieldName = "Date";
		this.gridColumn17.MinWidth = 13;
		this.gridColumn17.Name = "gridColumn17";
		this.gridColumn17.Visible = true;
		this.gridColumn17.VisibleIndex = 0;
		this.gridColumn17.Width = 123;
		this.gridColumn19.Caption = "Particulars";
		this.gridColumn19.FieldName = "Particulars";
		this.gridColumn19.MinWidth = 13;
		this.gridColumn19.Name = "gridColumn19";
		this.gridColumn19.Visible = true;
		this.gridColumn19.VisibleIndex = 1;
		this.gridColumn19.Width = 323;
		this.gridColumn21.Caption = "Trx. Ref";
		this.gridColumn21.FieldName = "TrRef";
		this.gridColumn21.MinWidth = 13;
		this.gridColumn21.Name = "gridColumn21";
		this.gridColumn21.Visible = true;
		this.gridColumn21.VisibleIndex = 2;
		this.gridColumn21.Width = 95;
		this.gridColumn20.Caption = "Amount";
		this.gridColumn20.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn20.FieldName = "Amount";
		this.gridColumn20.MinWidth = 13;
		this.gridColumn20.Name = "gridColumn20";
		this.gridColumn20.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#.0}")
		});
		this.gridColumn20.Visible = true;
		this.gridColumn20.VisibleIndex = 3;
		this.gridColumn20.Width = 187;
		this.pageIncomeStatement.Caption = "pageIncomeStatement";
		this.pageIncomeStatement.Controls.Add(this.myGridControl1);
		this.pageIncomeStatement.Name = "pageIncomeStatement";
		this.pageIncomeStatement.Size = new System.Drawing.Size(856, 495);
		this.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.myGridControl1.Location = new System.Drawing.Point(0, 0);
		this.myGridControl1.MainView = this.myGridView1;
		this.myGridControl1.Name = "myGridControl1";
		this.myGridControl1.Size = new System.Drawing.Size(856, 495);
		this.myGridControl1.TabIndex = 7;
		this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myGridView1 });
		this.myGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.myGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.myGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.myGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.myGridView1.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.Empty.Options.UseFont = true;
		this.myGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.myGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.myGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.myGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.myGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.myGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.myGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.myGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Bold);
		this.myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.myGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.myGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.myGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.OddRow.Options.UseFont = true;
		this.myGridView1.Appearance.Preview.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.Preview.Options.UseFont = true;
		this.myGridView1.Appearance.Row.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.Row.Options.UseFont = true;
		this.myGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.myGridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.myGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.myGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.myGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.VertLine.Options.UseFont = true;
		this.myGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Courier New", 11f);
		this.myGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.myGridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myGridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.myGridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.myGridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.myGridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.myGridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myGridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.myGridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myGridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.myGridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White;
		this.myGridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Courier New", 10f, System.Drawing.FontStyle.Bold);
		this.myGridView1.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.myGridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
		this.myGridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.myGridView1.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
		this.myGridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.myGridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.myGridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.myGridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Courier New", 10f);
		this.myGridView1.AppearancePrint.Row.Options.UseFont = true;
		this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn13, this.gridColumn14, this.gridColumn15, this.gridRevenue, this.gridExpenses, this.gridColumn18 });
		this.myGridView1.DetailHeight = 239;
		this.myGridView1.GridControl = this.myGridControl1;
		this.myGridView1.GroupCount = 1;
		this.myGridView1.GroupFormat = "{1} {2}";
		this.myGridView1.Name = "myGridView1";
		this.myGridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.myGridView1.OptionsBehavior.Editable = false;
		this.myGridView1.OptionsCustomization.AllowColumnMoving = false;
		this.myGridView1.OptionsCustomization.AllowFilter = false;
		this.myGridView1.OptionsCustomization.AllowQuickHideColumns = false;
		this.myGridView1.OptionsCustomization.AllowSort = false;
		this.myGridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.myGridView1.OptionsPrint.PrintGroupFooter = false;
		this.myGridView1.OptionsPrint.PrintHorzLines = false;
		this.myGridView1.OptionsPrint.UsePrintStyles = false;
		this.myGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.myGridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.myGridView1.OptionsView.ShowFooter = true;
		this.myGridView1.OptionsView.ShowGroupPanel = false;
		this.myGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.myGridView1.OptionsView.ShowIndicator = false;
		this.myGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn13, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.myGridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(myGridView1_CustomSummaryCalculate);
		this.gridColumn13.Caption = "Category";
		this.gridColumn13.FieldName = "MajorGroup";
		this.gridColumn13.MinWidth = 13;
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn13.Visible = true;
		this.gridColumn13.VisibleIndex = 0;
		this.gridColumn13.Width = 50;
		this.gridColumn14.Caption = "Account#";
		this.gridColumn14.FieldName = "SubAccountNo";
		this.gridColumn14.MinWidth = 13;
		this.gridColumn14.Name = "gridColumn14";
		this.gridColumn14.Visible = true;
		this.gridColumn14.VisibleIndex = 0;
		this.gridColumn14.Width = 119;
		this.gridColumn15.Caption = "Account";
		this.gridColumn15.FieldName = "SubAccountName";
		this.gridColumn15.MinWidth = 13;
		this.gridColumn15.Name = "gridColumn15";
		this.gridColumn15.Visible = true;
		this.gridColumn15.VisibleIndex = 1;
		this.gridColumn15.Width = 158;
		this.gridRevenue.Caption = "Revenue";
		this.gridRevenue.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridRevenue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridRevenue.FieldName = "Credit";
		this.gridRevenue.MinWidth = 13;
		this.gridRevenue.Name = "gridRevenue";
		this.gridRevenue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:#,#.0}")
		});
		this.gridRevenue.Visible = true;
		this.gridRevenue.VisibleIndex = 2;
		this.gridRevenue.Width = 158;
		this.gridExpenses.Caption = "Expenses";
		this.gridExpenses.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridExpenses.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridExpenses.FieldName = "Debit";
		this.gridExpenses.MinWidth = 13;
		this.gridExpenses.Name = "gridExpenses";
		this.gridExpenses.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:#,#.0}")
		});
		this.gridExpenses.Visible = true;
		this.gridExpenses.VisibleIndex = 3;
		this.gridExpenses.Width = 158;
		this.gridColumn18.Caption = "Net Profit/Loss";
		this.gridColumn18.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn18.FieldName = "Bal";
		this.gridColumn18.MinWidth = 13;
		this.gridColumn18.Name = "gridColumn18";
		this.gridColumn18.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColumn18.Visible = true;
		this.gridColumn18.VisibleIndex = 4;
		this.gridColumn18.Width = 163;
		this.pageTrialBalance.Caption = "pageTrialBalance";
		this.pageTrialBalance.Controls.Add(this.gridTrialBalance);
		this.pageTrialBalance.Name = "pageTrialBalance";
		this.pageTrialBalance.Size = new System.Drawing.Size(856, 495);
		this.gridTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridTrialBalance.Location = new System.Drawing.Point(0, 0);
		this.gridTrialBalance.MainView = this.gridView3;
		this.gridTrialBalance.Name = "gridTrialBalance";
		this.gridTrialBalance.Size = new System.Drawing.Size(856, 495);
		this.gridTrialBalance.TabIndex = 0;
		this.gridTrialBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView3 });
		this.gridView3.GridControl = this.gridTrialBalance;
		this.gridView3.Name = "gridView3";
		this.pageAccountLedgers.Caption = "pageAccountLedgers";
		this.pageAccountLedgers.Controls.Add(this.gridControlAccountLedger);
		this.pageAccountLedgers.Name = "pageAccountLedgers";
		this.pageAccountLedgers.Size = new System.Drawing.Size(856, 495);
		this.gridControlAccountLedger.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControlAccountLedger.Location = new System.Drawing.Point(0, 0);
		this.gridControlAccountLedger.MainView = this.gridViewAccountLedger;
		this.gridControlAccountLedger.Name = "gridControlAccountLedger";
		this.gridControlAccountLedger.Size = new System.Drawing.Size(856, 495);
		this.gridControlAccountLedger.TabIndex = 5;
		this.gridControlAccountLedger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewAccountLedger });
		this.gridViewAccountLedger.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.DetailTip.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.DetailTip.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.Empty.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.EvenRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.EvenRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.FilterPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.FixedLine.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.FixedLine.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.FocusedRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.FooterPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.GroupButton.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.GroupButton.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.GroupFooter.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.GroupPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.GroupPanel.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.GroupRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.HeaderPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.HorzLine.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.HorzLine.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.OddRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.OddRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.Preview.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.Preview.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.Row.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.Row.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.RowSeparator.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.RowSeparator.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.SelectedRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.TopNewRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.VertLine.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.VertLine.Options.UseFont = true;
		this.gridViewAccountLedger.Appearance.ViewCaption.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.Appearance.ViewCaption.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridViewAccountLedger.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridViewAccountLedger.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.Lines.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.OddRow.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.Preview.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.Preview.Options.UseFont = true;
		this.gridViewAccountLedger.AppearancePrint.Row.Font = new System.Drawing.Font("Courier New", 9.75f);
		this.gridViewAccountLedger.AppearancePrint.Row.Options.UseFont = true;
		this.gridViewAccountLedger.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7] { this.gridColDate, this.gridColParticulars, this.gridTrRef, this.gridColDr, this.gridColCr, this.gridColBal, this.gridColumn12 });
		this.gridViewAccountLedger.DetailHeight = 239;
		this.gridViewAccountLedger.GridControl = this.gridControlAccountLedger;
		this.gridViewAccountLedger.Name = "gridViewAccountLedger";
		this.gridViewAccountLedger.OptionsBehavior.Editable = false;
		this.gridViewAccountLedger.OptionsCustomization.AllowSort = false;
		this.gridViewAccountLedger.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridViewAccountLedger.OptionsPrint.PrintHorzLines = false;
		this.gridViewAccountLedger.OptionsPrint.PrintPreview = true;
		this.gridViewAccountLedger.OptionsPrint.UsePrintStyles = false;
		this.gridViewAccountLedger.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridViewAccountLedger.OptionsSelection.EnableAppearanceFocusedRow = false;
		this.gridViewAccountLedger.OptionsView.EnableAppearanceEvenRow = true;
		this.gridViewAccountLedger.OptionsView.ShowDetailButtons = false;
		this.gridViewAccountLedger.OptionsView.ShowFooter = true;
		this.gridViewAccountLedger.OptionsView.ShowGroupPanel = false;
		this.gridViewAccountLedger.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewAccountLedger.OptionsView.ShowIndicator = false;
		this.gridViewAccountLedger.PaintStyleName = "Skin";
		this.gridViewAccountLedger.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridViewAccountLedger_CustomSummaryCalculate);
		this.gridViewAccountLedger.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gridViewAccountLedger_CustomDrawEmptyForeground);
		this.gridViewAccountLedger.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(gridViewAccountLedger_CustomUnboundColumnData);
		this.gridColDate.Caption = "Date";
		this.gridColDate.DisplayFormat.FormatString = "dd.MM.yy";
		this.gridColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColDate.FieldName = "Date";
		this.gridColDate.MinWidth = 13;
		this.gridColDate.Name = "gridColDate";
		this.gridColDate.Visible = true;
		this.gridColDate.VisibleIndex = 0;
		this.gridColDate.Width = 89;
		this.gridColParticulars.Caption = "Particulars";
		this.gridColParticulars.FieldName = "Particulars";
		this.gridColParticulars.MinWidth = 13;
		this.gridColParticulars.Name = "gridColParticulars";
		this.gridColParticulars.Visible = true;
		this.gridColParticulars.VisibleIndex = 1;
		this.gridColParticulars.Width = 227;
		this.gridTrRef.Caption = "TrRef";
		this.gridTrRef.FieldName = "TrRef";
		this.gridTrRef.MinWidth = 13;
		this.gridTrRef.Name = "gridTrRef";
		this.gridTrRef.Visible = true;
		this.gridTrRef.VisibleIndex = 2;
		this.gridTrRef.Width = 88;
		this.gridColDr.Caption = "Dr";
		this.gridColDr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColDr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColDr.FieldName = "Dr";
		this.gridColDr.MinWidth = 13;
		this.gridColDr.Name = "gridColDr";
		this.gridColDr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Dr", "{0:#,#.0}")
		});
		this.gridColDr.Visible = true;
		this.gridColDr.VisibleIndex = 3;
		this.gridColDr.Width = 130;
		this.gridColCr.Caption = "Cr";
		this.gridColCr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColCr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColCr.FieldName = "Cr";
		this.gridColCr.MinWidth = 13;
		this.gridColCr.Name = "gridColCr";
		this.gridColCr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cr", "{0:#,#.0}")
		});
		this.gridColCr.Visible = true;
		this.gridColCr.VisibleIndex = 4;
		this.gridColCr.Width = 105;
		this.gridColBal.Caption = "Amount";
		this.gridColBal.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColBal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColBal.FieldName = "Amount";
		this.gridColBal.MinWidth = 13;
		this.gridColBal.Name = "gridColBal";
		this.gridColBal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColBal.Width = 79;
		this.gridColumn12.Caption = "Balance";
		this.gridColumn12.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn12.FieldName = "Bal";
		this.gridColumn12.MinWidth = 13;
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColumn12.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
		this.gridColumn12.Visible = true;
		this.gridColumn12.VisibleIndex = 5;
		this.gridColumn12.Width = 117;
		this.pageExpensesGrouped.Caption = "pageExpensesGrouped";
		this.pageExpensesGrouped.Controls.Add(this.layoutControl2);
		this.pageExpensesGrouped.Margin = new System.Windows.Forms.Padding(2);
		this.pageExpensesGrouped.Name = "pageExpensesGrouped";
		this.pageExpensesGrouped.Size = new System.Drawing.Size(856, 495);
		this.layoutControl2.Controls.Add(this.gridControl2);
		this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl2.Location = new System.Drawing.Point(0, 0);
		this.layoutControl2.Margin = new System.Windows.Forms.Padding(2);
		this.layoutControl2.Name = "layoutControl2";
		this.layoutControl2.Root = this.layoutControlGroup2;
		this.layoutControl2.Size = new System.Drawing.Size(856, 495);
		this.layoutControl2.TabIndex = 0;
		this.layoutControl2.Text = "layoutControl2";
		this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
		this.gridControl2.Location = new System.Drawing.Point(3, 3);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(850, 489);
		this.gridControl2.TabIndex = 4;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView2.Appearance.DetailTip.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.DetailTip.Options.UseFont = true;
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView2.Appearance.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FixedLine.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.FixedLine.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.GroupButton.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.HorzLine.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.HorzLine.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.RowSeparator.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.VertLine.Options.UseFont = true;
		this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView2.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView2.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView2.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView2.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.Lines.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView2.AppearancePrint.OddRow.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.Preview.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView2.AppearancePrint.Row.Font = new System.Drawing.Font("Consolas", 10f);
		this.gridView2.AppearancePrint.Row.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn22, this.gridColumn23, this.gridColumn24, this.gridColumn25, this.gridColumn26, this.gridColumn27 });
		this.gridView2.DetailHeight = 239;
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.GroupCount = 1;
		this.gridView2.GroupFormat = "{1} {2}";
		this.gridView2.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpenseValue", null, "{0:#,#.0}")
		});
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsCustomization.AllowColumnMoving = false;
		this.gridView2.OptionsCustomization.AllowGroup = false;
		this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView2.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsPrint.PrintHorzLines = false;
		this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView2.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
		this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView2.OptionsView.ShowFooter = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn24, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridColumn22.Caption = "Date";
		this.gridColumn22.DisplayFormat.FormatString = "dd-MMM-yy";
		this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn22.FieldName = "DateOfExpense";
		this.gridColumn22.MinWidth = 13;
		this.gridColumn22.Name = "gridColumn22";
		this.gridColumn22.Visible = true;
		this.gridColumn22.VisibleIndex = 0;
		this.gridColumn22.Width = 50;
		this.gridColumn23.Caption = "Item";
		this.gridColumn23.FieldName = "ExpenseName";
		this.gridColumn23.MinWidth = 13;
		this.gridColumn23.Name = "gridColumn23";
		this.gridColumn23.Visible = true;
		this.gridColumn23.VisibleIndex = 1;
		this.gridColumn23.Width = 50;
		this.gridColumn24.Caption = "Vote";
		this.gridColumn24.FieldName = "expenseSource";
		this.gridColumn24.MinWidth = 13;
		this.gridColumn24.Name = "gridColumn24";
		this.gridColumn24.Visible = true;
		this.gridColumn24.VisibleIndex = 2;
		this.gridColumn24.Width = 50;
		this.gridColumn25.Caption = "Ref";
		this.gridColumn25.FieldName = "VoucherNo";
		this.gridColumn25.MinWidth = 13;
		this.gridColumn25.Name = "gridColumn25";
		this.gridColumn25.Visible = true;
		this.gridColumn25.VisibleIndex = 2;
		this.gridColumn25.Width = 50;
		this.gridColumn26.Caption = "Narration";
		this.gridColumn26.FieldName = "Narration";
		this.gridColumn26.MinWidth = 13;
		this.gridColumn26.Name = "gridColumn26";
		this.gridColumn26.Visible = true;
		this.gridColumn26.VisibleIndex = 3;
		this.gridColumn26.Width = 50;
		this.gridColumn27.Caption = "Amount";
		this.gridColumn27.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn27.FieldName = "ExpenseValue";
		this.gridColumn27.MinWidth = 13;
		this.gridColumn27.Name = "gridColumn27";
		this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ExpenseValue", "{0:#,#.0}")
		});
		this.gridColumn27.Visible = true;
		this.gridColumn27.VisibleIndex = 4;
		this.gridColumn27.Width = 50;
		this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup2.GroupBordersVisible = false;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem2 });
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 5;
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup2.Size = new System.Drawing.Size(856, 495);
		this.layoutControlGroup2.TextVisible = false;
		this.layoutControlItem2.Control = this.gridControl2;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(854, 493);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.gridColumn1.Caption = "Category";
		this.gridColumn1.FieldName = "Category";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Date";
		this.gridColumn2.DisplayFormat.FormatString = "dd-MMM-yy";
		this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn2.FieldName = "Date";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 142;
		this.gridColumn3.Caption = "Ref#";
		this.gridColumn3.FieldName = "Ref#";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 153;
		this.gridColumn4.Caption = "Particulars";
		this.gridColumn4.FieldName = "Particulars";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn4.Width = 516;
		this.gridColumn5.Caption = "Amount";
		this.gridColumn5.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn5.FieldName = "Amount";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#}")
		});
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.gridColumn5.Width = 323;
		this.gridColumn6.Caption = "Category";
		this.gridColumn6.FieldName = "MajorGroup";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 0;
		this.gridColumn7.Caption = "Account#";
		this.gridColumn7.FieldName = "SubAccountNo";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 0;
		this.gridColumn8.Caption = "Account";
		this.gridColumn8.FieldName = "SubAccountName";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 1;
		this.gridColumn9.Caption = "Revenue";
		this.gridColumn9.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn9.FieldName = "Credit";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:#,#.0}")
		});
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 2;
		this.gridColumn10.Caption = "Expenses";
		this.gridColumn10.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn10.FieldName = "Debit";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:#,#.0}")
		});
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 3;
		this.gridColumn11.Caption = "Net Profit/Loss";
		this.gridColumn11.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn11.FieldName = "Bal";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColumn11.Visible = true;
		this.gridColumn11.VisibleIndex = 4;
		this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBand1.AppearanceHeader.Options.UseFont = true;
		this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBand1.Caption = "Transaction Details";
		this.gridBand1.Columns.Add(this.bandedGridColDate);
		this.gridBand1.Columns.Add(this.bandedGridColParticulars);
		this.gridBand1.Columns.Add(this.bandedGridColTrxRef);
		this.gridBand1.Columns.Add(this.bandedGridColAccountRef);
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.OptionsBand.AllowHotTrack = false;
		this.gridBand1.OptionsBand.AllowMove = false;
		this.gridBand1.OptionsBand.AllowPress = false;
		this.gridBand1.OptionsBand.ShowInCustomizationForm = false;
		this.gridBand1.VisibleIndex = -1;
		this.gridBand1.Width = 545;
		this.bandedGridColDate.Caption = "Date";
		this.bandedGridColDate.DisplayFormat.FormatString = "dd.MMM.yy";
		this.bandedGridColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.bandedGridColDate.FieldName = "Date";
		this.bandedGridColDate.Name = "bandedGridColDate";
		this.bandedGridColDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
		this.bandedGridColDate.Visible = true;
		this.bandedGridColDate.Width = 70;
		this.bandedGridColParticulars.Caption = "Particulars";
		this.bandedGridColParticulars.FieldName = "Particulars";
		this.bandedGridColParticulars.Name = "bandedGridColParticulars";
		this.bandedGridColParticulars.Visible = true;
		this.bandedGridColParticulars.Width = 250;
		this.bandedGridColTrxRef.Caption = "Trx. Ref.";
		this.bandedGridColTrxRef.DisplayFormat.FormatString = "{0:#}";
		this.bandedGridColTrxRef.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColTrxRef.FieldName = "TrxRef";
		this.bandedGridColTrxRef.Name = "bandedGridColTrxRef";
		this.bandedGridColTrxRef.Visible = true;
		this.bandedGridColTrxRef.Width = 112;
		this.bandedGridColAccountRef.Caption = "Account Title";
		this.bandedGridColAccountRef.FieldName = "AccountRef";
		this.bandedGridColAccountRef.Name = "bandedGridColAccountRef";
		this.bandedGridColAccountRef.Visible = true;
		this.bandedGridColAccountRef.Width = 113;
		this.gridBandDR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBandDR.AppearanceHeader.Options.UseFont = true;
		this.gridBandDR.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBandDR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBandDR.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBandDR.Caption = "DR.";
		this.gridBandDR.Columns.Add(this.bandedGridColcDr);
		this.gridBandDR.Columns.Add(this.bandedGridColbDr);
		this.gridBandDR.Name = "gridBandDR";
		this.gridBandDR.OptionsBand.AllowHotTrack = false;
		this.gridBandDR.OptionsBand.AllowMove = false;
		this.gridBandDR.OptionsBand.AllowPress = false;
		this.gridBandDR.OptionsBand.ShowInCustomizationForm = false;
		this.gridBandDR.RowCount = 2;
		this.gridBandDR.VisibleIndex = -1;
		this.gridBandDR.Width = 174;
		this.bandedGridColcDr.Caption = "Cash";
		this.bandedGridColcDr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColcDr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColcDr.FieldName = "dCash";
		this.bandedGridColcDr.Name = "bandedGridColcDr";
		this.bandedGridColcDr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dCash", "{0:#,#.0}")
		});
		this.bandedGridColcDr.Visible = true;
		this.bandedGridColcDr.Width = 85;
		this.bandedGridColbDr.Caption = "Bank";
		this.bandedGridColbDr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColbDr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColbDr.FieldName = "dBank";
		this.bandedGridColbDr.Name = "bandedGridColbDr";
		this.bandedGridColbDr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dBank", "{0:#,#.0}")
		});
		this.bandedGridColbDr.Visible = true;
		this.bandedGridColbDr.Width = 89;
		this.gridBandCR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBandCR.AppearanceHeader.Options.UseFont = true;
		this.gridBandCR.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBandCR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBandCR.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBandCR.Caption = "CR.";
		this.gridBandCR.Columns.Add(this.bandedGridColcCr);
		this.gridBandCR.Columns.Add(this.bandedGridColbCr);
		this.gridBandCR.Name = "gridBandCR";
		this.gridBandCR.OptionsBand.AllowHotTrack = false;
		this.gridBandCR.OptionsBand.AllowMove = false;
		this.gridBandCR.OptionsBand.AllowPress = false;
		this.gridBandCR.OptionsBand.ShowInCustomizationForm = false;
		this.gridBandCR.VisibleIndex = -1;
		this.gridBandCR.Width = 179;
		this.bandedGridColcCr.Caption = "Cash";
		this.bandedGridColcCr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColcCr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColcCr.FieldName = "cCash";
		this.bandedGridColcCr.Name = "bandedGridColcCr";
		this.bandedGridColcCr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cCash", "{0:#,#.0}")
		});
		this.bandedGridColcCr.Visible = true;
		this.bandedGridColcCr.Width = 87;
		this.bandedGridColbCr.Caption = "Bank";
		this.bandedGridColbCr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColbCr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColbCr.FieldName = "cBank";
		this.bandedGridColbCr.Name = "bandedGridColbCr";
		this.bandedGridColbCr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cBank", "{0:#,#.0}")
		});
		this.bandedGridColbCr.Visible = true;
		this.bandedGridColbCr.Width = 92;
		this.layoutControl1.Controls.Add(this.lblDateRange);
		this.layoutControl1.Controls.Add(this.lblReportHeader);
		this.layoutControl1.Controls.Add(this.navigationFinancialReports);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(862, 550);
		this.layoutControl1.TabIndex = 6;
		this.layoutControl1.Text = "layoutControl1";
		this.lblDateRange.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.lblDateRange.Appearance.Options.UseFont = true;
		this.lblDateRange.Appearance.Options.UseTextOptions = true;
		this.lblDateRange.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblDateRange.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblDateRange.Location = new System.Drawing.Point(3, 30);
		this.lblDateRange.Name = "lblDateRange";
		this.lblDateRange.Size = new System.Drawing.Size(856, 18);
		this.lblDateRange.StyleController = this.layoutControl1;
		this.lblDateRange.TabIndex = 7;
		this.lblReportHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.lblReportHeader.Appearance.Options.UseFont = true;
		this.lblReportHeader.Appearance.Options.UseTextOptions = true;
		this.lblReportHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblReportHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblReportHeader.Location = new System.Drawing.Point(3, 3);
		this.lblReportHeader.Name = "lblReportHeader";
		this.lblReportHeader.Size = new System.Drawing.Size(856, 23);
		this.lblReportHeader.StyleController = this.layoutControl1;
		this.lblReportHeader.TabIndex = 6;
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlReportHeader, this.layoutControlIReportDate });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(862, 550);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.navigationFinancialReports;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 49);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(860, 499);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlReportHeader.Control = this.lblReportHeader;
		this.layoutControlReportHeader.Location = new System.Drawing.Point(0, 0);
		this.layoutControlReportHeader.Name = "layoutControlReportHeader";
		this.layoutControlReportHeader.Size = new System.Drawing.Size(860, 27);
		this.layoutControlReportHeader.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlReportHeader.TextVisible = false;
		this.layoutControlReportHeader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlIReportDate.Control = this.lblDateRange;
		this.layoutControlIReportDate.Location = new System.Drawing.Point(0, 27);
		this.layoutControlIReportDate.Name = "layoutControlIReportDate";
		this.layoutControlIReportDate.Size = new System.Drawing.Size(860, 22);
		this.layoutControlIReportDate.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlIReportDate.TextVisible = false;
		this.layoutControlIReportDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrFinancialReportsDashBoard";
		base.Size = new System.Drawing.Size(862, 550);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFinancialReports).EndInit();
		this.navigationFinancialReports.ResumeLayout(false);
		this.pageMain.ResumeLayout(false);
		this.pageExpenses.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		this.pageBalanceSheet.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).EndInit();
		this.pageCashbook.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.myGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myBandedGridView1).EndInit();
		this.pageIncome.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		this.pageIncomeStatement.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).EndInit();
		this.pageTrialBalance.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridTrialBalance).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView3).EndInit();
		this.pageAccountLedgers.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControlAccountLedger).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewAccountLedger).EndInit();
		this.pageExpensesGrouped.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl2).EndInit();
		this.layoutControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlReportHeader).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlIReportDate).EndInit();
		base.ResumeLayout(false);
	}
}
