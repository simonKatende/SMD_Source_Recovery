using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraPivotGrid;

namespace I_Xtreme.NavigationForms;

public class usrAttendanceHistoryTermly : XtraUserControl
{
	private string Term = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem2;

	private PivotGridControl pivotGridControl2;

	private PivotGridField pivotGridField5;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField7;

	private PivotGridField pivotGridField8;

	private PivotGridField pivotGridField9;

	private LayoutControlItem layoutControlItem3;

	public usrAttendanceHistoryTermly(string Term)
	{
		InitializeComponent();
		this.Term = Term;
		LoadUnSummerisedReport();
		labelControl1.Text = Term + " Arrival-Departure report";
	}

	private void LoadUnSummerisedReport()
	{
		string selectCommandText = $"SELECT  s.ClassId, s.StreamId, s.Sex, SUM(a.AttendanceCount) AS AttendanceCount, a.AttendanceCategory, a.SemesterId FROM    tbl_Stud s LEFT OUTER JOIN     AttendanceSheet a ON s.StudentNumber = a.StudentNo WHERE(s.Status = 'Active') GROUP BY s.ClassId, s.StreamId, s.Sex, a.AttendanceCategory, a.SemesterId HAVING(a.AttendanceCategory <> N'Reporting') AND (a.SemesterId = N'{Term}')";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		pivotGridControl2.DataSource = dataTable.DefaultView;
		PrintableControl.SavePrintableControl(pivotGridControl2);
		ActiveFormSelected.SetActiveForm(Term + " Arrival-Departure report");
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
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding2 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding3 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding4 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding5 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pivotGridControl2 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.pivotGridControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(647, 450);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.pivotGridControl2.Appearance.Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.pivotGridControl2.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.DataHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.DataHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl2.Appearance.ExpandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldHeader.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.FieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FilterHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.FilterHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.FilterSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FixedLine.Options.UseFont = true;
		this.pivotGridControl2.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.HeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderFilterButton.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.HeaderFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.HeaderFilterButtonActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl2.Appearance.HeaderGroupLine.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.HeaderGroupLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.Lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl2.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl2.Appearance.RowHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl2.Appearance.RowHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.Appearance.SelectedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl2.Appearance.TotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl2.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldHeader.Options.UseTextOptions = true;
		this.pivotGridControl2.AppearancePrint.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl2.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.HeaderGroupLine.Options.UseTextOptions = true;
		this.pivotGridControl2.AppearancePrint.HeaderGroupLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl2.AppearancePrint.Lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl2.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl2.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl2.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[5] { this.pivotGridField5, this.pivotGridField6, this.pivotGridField7, this.pivotGridField8, this.pivotGridField9 });
		this.pivotGridControl2.Location = new System.Drawing.Point(12, 40);
		this.pivotGridControl2.Name = "pivotGridControl2";
		this.pivotGridControl2.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized;
		this.pivotGridControl2.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl2.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl2.OptionsPrint.UsePrintAppearance = true;
		this.pivotGridControl2.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl2.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl2.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl2.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl2.Size = new System.Drawing.Size(623, 398);
		this.pivotGridControl2.TabIndex = 9;
		this.pivotGridField5.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField5.Appearance.Header.Options.UseFont = true;
		this.pivotGridField5.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField5.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField5.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField5.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField5.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField5.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField5.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField5.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField5.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField5.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField5.AreaIndex = 0;
		this.pivotGridField5.Caption = "Class";
		dataSourceColumnBinding.ColumnName = "ClassId";
		this.pivotGridField5.DataBinding = dataSourceColumnBinding;
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField5.Width = 75;
		this.pivotGridField6.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField6.Appearance.Header.Options.UseFont = true;
		this.pivotGridField6.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField6.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField6.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField6.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField6.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField6.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField6.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField6.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField6.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField6.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField6.AreaIndex = 1;
		this.pivotGridField6.Caption = "Stream";
		dataSourceColumnBinding2.ColumnName = "StreamId";
		this.pivotGridField6.DataBinding = dataSourceColumnBinding2;
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField6.Width = 95;
		this.pivotGridField7.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField7.Appearance.Header.Options.UseFont = true;
		this.pivotGridField7.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField7.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField7.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField7.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField7.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField7.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField7.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField7.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField7.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField7.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField7.AreaIndex = 1;
		this.pivotGridField7.Caption = "Sex";
		dataSourceColumnBinding3.ColumnName = "Sex";
		this.pivotGridField7.DataBinding = dataSourceColumnBinding3;
		this.pivotGridField7.Name = "pivotGridField7";
		this.pivotGridField7.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField7.Width = 95;
		this.pivotGridField8.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField8.Appearance.Header.Options.UseFont = true;
		this.pivotGridField8.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField8.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField8.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField8.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField8.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField8.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField8.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField8.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField8.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField8.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField8.AreaIndex = 0;
		this.pivotGridField8.Caption = "Attendance Category";
		dataSourceColumnBinding4.ColumnName = "AttendanceCategory";
		this.pivotGridField8.DataBinding = dataSourceColumnBinding4;
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField8.Width = 95;
		this.pivotGridField9.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField9.Appearance.Header.Options.UseFont = true;
		this.pivotGridField9.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField9.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField9.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField9.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField9.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField9.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField9.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField9.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField9.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField9.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField9.AreaIndex = 0;
		this.pivotGridField9.Caption = "Attendance Count";
		dataSourceColumnBinding5.ColumnName = "AttendanceCount";
		this.pivotGridField9.DataBinding = dataSourceColumnBinding5;
		this.pivotGridField9.Name = "pivotGridField9";
		this.pivotGridField9.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(12, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(623, 24);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 7;
		this.labelControl1.Text = "labelControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem2, this.layoutControlItem3 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(647, 450);
		this.Root.TextVisible = false;
		this.layoutControlItem2.Control = this.labelControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(627, 28);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.pivotGridControl2;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(627, 402);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrAttendanceHistoryTermly";
		base.Size = new System.Drawing.Size(647, 450);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
