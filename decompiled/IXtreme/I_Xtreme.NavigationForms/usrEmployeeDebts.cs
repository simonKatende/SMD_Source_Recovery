using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;

namespace I_Xtreme.NavigationForms;

public class usrEmployeeDebts : XtraUserControl
{
	private DataTable dt_paySlip;

	private IContainer components = null;

	private LayoutControl layoutControl33;

	private PivotGridControl pivotGridControl1;

	private PivotGridField pivotGridField14;

	private PivotGridField pivotGridField10;

	private PivotGridField pivotGridField11;

	private PivotGridField pivotGridField12;

	private PivotGridField pivotGridField15;

	private PivotGridField pivotGridField13;

	private PivotGridField pivotGridField16;

	private GridControl gridControl16;

	private GridView gridView25;

	private GridColumn gridColumn32;

	private GridColumn gridColumn28;

	private GridColumn gridColumn29;

	private LayoutControlGroup layoutControlGroup5;

	private LayoutControlItem layoutControlItem35;

	private LayoutControlItem layoutControlItem26;

	private PopupMenu popupMenu1;

	private BarManager barManager1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarCheckItem barCheckItem1;

	public usrEmployeeDebts()
	{
		InitializeComponent();
	}

	private void PaySlipMultipleEmployees(string month, int year)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ps.Category,ps.EmployeeNo,ps.Month,ps.Year,ps.Particulars, ps.Requirements,ps.CapDate,s.StaffName AS Name FROM tbl_EmployeePaySlip ps INNER JOIN Staff s ON ps.EmployeeNo=s.StaffId WHERE ps.month='{month}' AND ps.Year={year} Order By ps.Category Desc", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PaySlip");
			dt_paySlip = new DataTable();
			dt_paySlip = dataSet.Tables[0];
			pivotGridControl1.DataSource = dt_paySlip.DefaultView;
			PrintableControl.SavePrintableControl(pivotGridControl1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadPaySlip(string month, string emploYeeNo, int year)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_EmployeePaySlip WHERE month='{month}' AND EmployeeNo='{emploYeeNo}' AND Year={year} ORDER BY Category DESC", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "PaySlip");
			dt_paySlip = new DataTable();
			dt_paySlip = dataSet.Tables[0];
			gridControl16.DataSource = dt_paySlip.DefaultView;
			GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
			gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "Net Pay: {0:#,#.0}");
			gridColumnSummaryItem.FieldName = "Requirements";
			gridView25.Columns["Requirements"].SummaryItem.Assign(gridColumnSummaryItem);
			GridGroupSummaryItem summaryItem = new GridGroupSummaryItem
			{
				FieldName = "Requirements",
				SummaryType = SummaryItemType.Sum,
				DisplayFormat = "{0:#,#.0}",
				ShowInGroupColumnFooter = gridColumn29
			};
			gridView25.GroupSummary.Add(summaryItem);
			PrintableControl.SavePrintableControl(gridControl16);
			PrintableControl.SavePrintableControl(gridView25);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void dtMonth_DateTimeChanged(object sender, EventArgs e)
	{
	}

	private void gridView25_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
	{
		if (((GridSummaryItem)e.Item).FieldName == "NetPay")
		{
			double num = Convert.ToDouble(gridView25.Columns["Requirements"].SummaryItem.SummaryValue) - Convert.ToDouble(gridView25.Columns["Deductions"].SummaryItem.SummaryValue);
			e.TotalValue = num;
		}
	}

	private void gridView25_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
	}

	private void gridView25_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridView25.FocusedRowHandle > -1)
		{
			if (e.Button == MouseButtons.Right)
			{
				popupMenu1.ShowCaption = true;
				DataRow dataRow = dt_paySlip.Rows[gridView25.GetFocusedDataSourceRowIndex()];
				popupMenu1.MenuCaption = dataRow["Particulars"].ToString();
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
	}

	private void gridView25_KeyDown(object sender, KeyEventArgs e)
	{
		if (gridView25.FocusedRowHandle > -1)
		{
			if (e.KeyCode == Keys.Apps)
			{
				popupMenu1.ShowCaption = true;
				DataRow dataRow = dt_paySlip.Rows[gridView25.GetFocusedDataSourceRowIndex()];
				popupMenu1.MenuCaption = dataRow["Particulars"].ToString();
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
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
		this.layoutControl33 = new DevExpress.XtraLayout.LayoutControl();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField14 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField15 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField13 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField16 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.gridControl16 = new DevExpress.XtraGrid.GridControl();
		this.gridView25 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl33).BeginInit();
		this.layoutControl33.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView25).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem35).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		base.SuspendLayout();
		this.layoutControl33.Controls.Add(this.pivotGridControl1);
		this.layoutControl33.Controls.Add(this.gridControl16);
		this.layoutControl33.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl33.Location = new System.Drawing.Point(0, 0);
		this.layoutControl33.Name = "layoutControl33";
		this.layoutControl33.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(188, 0, 668, 654);
		this.layoutControl33.Root = this.layoutControlGroup5;
		this.layoutControl33.Size = new System.Drawing.Size(872, 543);
		this.layoutControl33.TabIndex = 33;
		this.layoutControl33.Text = "layoutControl33";
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[5] { this.barButtonItem1, this.barCheckItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4 });
		this.barManager1.MaxItemId = 5;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Size = new System.Drawing.Size(872, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 543);
		this.barDockControlBottom.Size = new System.Drawing.Size(872, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 543);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(872, 0);
		this.barDockControlRight.Size = new System.Drawing.Size(0, 543);
		this.barButtonItem1.Caption = "Remove Item";
		this.barButtonItem1.Id = 0;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barCheckItem1.Caption = "barCheckItem1";
		this.barCheckItem1.Id = 1;
		this.barCheckItem1.Name = "barCheckItem1";
		this.barButtonItem2.Caption = "Print Payslip";
		this.barButtonItem2.Id = 2;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem3.Caption = "Preview Payslip";
		this.barButtonItem3.Id = 3;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem4.Caption = "Export Payslip";
		this.barButtonItem4.Id = 4;
		this.barButtonItem4.Name = "barButtonItem4";
		this.pivotGridControl1.AppearancePrint.Cell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.Cell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.Cell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldHeader.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldHeader.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.FieldValue.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldValue.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldValue.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.Lines.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.Lines.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseForeColor = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.TotalCell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridControl1.AppearancePrint.TotalCell.ForeColor = System.Drawing.Color.Black;
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseBackColor = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseForeColor = true;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[7] { this.pivotGridField14, this.pivotGridField10, this.pivotGridField11, this.pivotGridField12, this.pivotGridField15, this.pivotGridField13, this.pivotGridField16 });
		this.pivotGridControl1.Location = new System.Drawing.Point(4, 4);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintHeadersOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(864, 266);
		this.pivotGridControl1.TabIndex = 43;
		this.pivotGridField14.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField14.AreaIndex = 0;
		this.pivotGridField14.Caption = "Name";
		this.pivotGridField14.FieldName = "Name";
		this.pivotGridField14.Name = "pivotGridField14";
		this.pivotGridField14.Width = 198;
		this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField10.AreaIndex = 1;
		this.pivotGridField10.FieldName = "EmployeeNo";
		this.pivotGridField10.Name = "pivotGridField10";
		this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField11.AreaIndex = 1;
		this.pivotGridField11.FieldName = "Particulars";
		this.pivotGridField11.Name = "pivotGridField11";
		this.pivotGridField12.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField12.AreaIndex = 0;
		this.pivotGridField12.Caption = "Amount";
		this.pivotGridField12.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField12.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField12.FieldName = "Requirements";
		this.pivotGridField12.GrandTotalCellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField12.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField12.GrandTotalText = "Net Pay";
		this.pivotGridField12.Name = "pivotGridField12";
		this.pivotGridField12.ValueFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField12.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField15.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField15.AreaIndex = 0;
		this.pivotGridField15.Caption = "Category";
		this.pivotGridField15.FieldName = "Category";
		this.pivotGridField15.Name = "pivotGridField15";
		this.pivotGridField15.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField13.AreaIndex = 1;
		this.pivotGridField13.Caption = "Month";
		this.pivotGridField13.FieldName = "Month";
		this.pivotGridField13.Name = "pivotGridField13";
		this.pivotGridField16.AreaIndex = 0;
		this.pivotGridField16.Caption = "Year";
		this.pivotGridField16.FieldName = "Year";
		this.pivotGridField16.Name = "pivotGridField16";
		this.gridControl16.Location = new System.Drawing.Point(4, 274);
		this.gridControl16.MainView = this.gridView25;
		this.gridControl16.Name = "gridControl16";
		this.gridControl16.Size = new System.Drawing.Size(864, 265);
		this.gridControl16.TabIndex = 37;
		this.gridControl16.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView25 });
		this.gridView25.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.gridView25.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView25.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.gridView25.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView25.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.gridView25.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView25.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn32, this.gridColumn28, this.gridColumn29 });
		this.gridView25.GridControl = this.gridControl16;
		this.gridView25.GroupCount = 1;
		this.gridView25.GroupFormat = "{1}";
		this.gridView25.Name = "gridView25";
		this.gridView25.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView25.OptionsBehavior.Editable = false;
		this.gridView25.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
		this.gridView25.OptionsView.ShowFooter = true;
		this.gridView25.OptionsView.ShowGroupPanel = false;
		this.gridView25.OptionsView.ShowIndicator = false;
		this.gridView25.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn32, DevExpress.Data.ColumnSortOrder.Descending)
		});
		this.gridView25.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView25_RowClick);
		this.gridView25.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView25_RowCellStyle);
		this.gridView25.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridView25_CustomSummaryCalculate);
		this.gridView25.KeyDown += new System.Windows.Forms.KeyEventHandler(gridView25_KeyDown);
		this.gridColumn32.Caption = "Category";
		this.gridColumn32.FieldName = "Category";
		this.gridColumn32.Name = "gridColumn32";
		this.gridColumn28.Caption = "Particulars";
		this.gridColumn28.FieldName = "Particulars";
		this.gridColumn28.Name = "gridColumn28";
		this.gridColumn28.Visible = true;
		this.gridColumn28.VisibleIndex = 0;
		this.gridColumn29.Caption = "Amount";
		this.gridColumn29.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn29.FieldName = "Requirements";
		this.gridColumn29.GroupFormat.FormatString = "{0:#,#.0}";
		this.gridColumn29.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn29.Name = "gridColumn29";
		this.gridColumn29.Visible = true;
		this.gridColumn29.VisibleIndex = 1;
		this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
		this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup5.GroupBordersVisible = false;
		this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem35, this.layoutControlItem26 });
		this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup5.Name = "layoutControlGroup5";
		this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup5.Size = new System.Drawing.Size(872, 543);
		this.layoutControlGroup5.Text = "layoutControlGroup5";
		this.layoutControlGroup5.TextVisible = false;
		this.layoutControlItem35.Control = this.gridControl16;
		this.layoutControlItem35.CustomizationFormText = "layoutControlItem35";
		this.layoutControlItem35.Location = new System.Drawing.Point(0, 270);
		this.layoutControlItem35.Name = "layoutControlItem35";
		this.layoutControlItem35.Size = new System.Drawing.Size(868, 269);
		this.layoutControlItem35.Text = "layoutControlItem35";
		this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem35.TextToControlDistance = 0;
		this.layoutControlItem35.TextVisible = false;
		this.layoutControlItem26.Control = this.pivotGridControl1;
		this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
		this.layoutControlItem26.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem26.Name = "layoutControlItem26";
		this.layoutControlItem26.Size = new System.Drawing.Size(868, 270);
		this.layoutControlItem26.Text = "layoutControlItem26";
		this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem26.TextToControlDistance = 0;
		this.layoutControlItem26.TextVisible = false;
		this.layoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)
		});
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl33);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrEmployeeDebts";
		base.Size = new System.Drawing.Size(872, 543);
		((System.ComponentModel.ISupportInitialize)this.layoutControl33).EndInit();
		this.layoutControl33.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView25).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem35).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		base.ResumeLayout(false);
	}
}
