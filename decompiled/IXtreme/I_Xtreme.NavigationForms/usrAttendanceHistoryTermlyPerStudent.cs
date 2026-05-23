using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;

namespace I_Xtreme.NavigationForms;

public class usrAttendanceHistoryTermlyPerStudent : XtraUserControl
{
	private string Term = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem2;

	private PivotGridControl pivotGridControl1;

	private LayoutControlItem layoutControlItem1;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField7;

	private PivotGridField pivotGridField8;

	public usrAttendanceHistoryTermlyPerStudent(string Term)
	{
		InitializeComponent();
		this.Term = Term;
		LoadUnSummerisedReport();
		labelControl1.Text = "Arrival-Departure report (" + Term + ")";
	}

	private void LoadUnSummerisedReport()
	{
		string selectCommandText = $"SELECT  s.fullName, s.StudentNumber, s.StudentID, s.ClassId, s.StreamId,s.Sex, COUNT(a.AttendanceCount) AS AttendanceCount, a.AttendanceCategory FROM            dbo.tbl_Stud AS s INNER JOIN  AttendanceSheet AS a ON s.StudentNumber = a.StudentNo WHERE(s.Status = 'Active') AND(a.SemesterId = N'{Term}') GROUP BY s.fullName, s.StudentNumber, s.StudentID, s.ClassId, s.StreamId,s.Sex, a.AttendanceCategory HAVING(a.AttendanceCategory <> N'Reporting')";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		pivotGridControl1.DataSource = dataTable.DefaultView;
		PrintableControl.SavePrintableControl(pivotGridControl1);
		ActiveFormSelected.SetActiveForm("Arrival-Departure report (" + Term + ")");
	}

	private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
	{
		if (e.ValueType == PivotGridValueType.Total && e.IsColumn)
		{
			e.DisplayText = e.DisplayText.Substring(0, 3) + ". TOTAL";
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
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding2 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding3 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding4 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding5 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding6 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding7 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding8 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.pivotGridControl1);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(647, 450);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.FilterSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.HeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.HeaderFilterButton.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.HeaderGroupLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.Lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.TotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseTextOptions = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseTextOptions = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.AppearancePrint.Lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[8] { this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5, this.pivotGridField6, this.pivotGridField7, this.pivotGridField8 });
		this.pivotGridControl1.Location = new System.Drawing.Point(4, 32);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized;
		this.pivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(639, 414);
		this.pivotGridControl1.TabIndex = 8;
		this.pivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(pivotGridControl1_FieldValueDisplayText);
		this.pivotGridField1.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField1.Appearance.Header.Options.UseFont = true;
		this.pivotGridField1.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField1.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField1.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField1.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField1.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField1.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField1.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField1.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField1.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField1.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 2;
		this.pivotGridField1.Caption = "Name";
		dataSourceColumnBinding.ColumnName = "fullName";
		this.pivotGridField1.DataBinding = dataSourceColumnBinding;
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.Width = 200;
		this.pivotGridField2.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField2.Appearance.Header.Options.UseFont = true;
		this.pivotGridField2.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField2.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField2.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField2.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField2.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField2.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField2.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField2.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField2.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField2.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 3;
		this.pivotGridField2.Caption = "System ID";
		dataSourceColumnBinding2.ColumnName = "StudentNumber";
		this.pivotGridField2.DataBinding = dataSourceColumnBinding2;
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField2.Visible = false;
		this.pivotGridField3.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField3.Appearance.Header.Options.UseFont = true;
		this.pivotGridField3.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField3.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField3.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField3.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField3.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField3.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField3.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField3.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField3.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField3.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField3.AreaIndex = 3;
		this.pivotGridField3.Caption = "Student ID";
		dataSourceColumnBinding3.ColumnName = "StudentID";
		this.pivotGridField3.DataBinding = dataSourceColumnBinding3;
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.Width = 120;
		this.pivotGridField4.Appearance.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.pivotGridField4.Appearance.Header.Options.UseFont = true;
		this.pivotGridField4.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField4.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField4.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.pivotGridField4.Appearance.ValueGrandTotal.Options.UseFont = true;
		this.pivotGridField4.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField4.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField4.Appearance.ValueTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.pivotGridField4.Appearance.ValueTotal.Options.UseFont = true;
		this.pivotGridField4.Appearance.ValueTotal.Options.UseTextOptions = true;
		this.pivotGridField4.Appearance.ValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField4.AreaIndex = 0;
		this.pivotGridField4.Caption = "Class";
		dataSourceColumnBinding4.ColumnName = "ClassId";
		this.pivotGridField4.DataBinding = dataSourceColumnBinding4;
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField4.Width = 80;
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
		this.pivotGridField5.AreaIndex = 1;
		this.pivotGridField5.Caption = "Stream";
		dataSourceColumnBinding5.ColumnName = "StreamId";
		this.pivotGridField5.DataBinding = dataSourceColumnBinding5;
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.Width = 80;
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
		this.pivotGridField6.AreaIndex = 4;
		this.pivotGridField6.Caption = "Sex";
		dataSourceColumnBinding6.ColumnName = "Sex";
		this.pivotGridField6.DataBinding = dataSourceColumnBinding6;
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.Width = 50;
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
		this.pivotGridField7.AreaIndex = 0;
		this.pivotGridField7.Caption = "Attendance Category";
		dataSourceColumnBinding7.ColumnName = "AttendanceCategory";
		this.pivotGridField7.DataBinding = dataSourceColumnBinding7;
		this.pivotGridField7.Name = "pivotGridField7";
		this.pivotGridField7.Width = 105;
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
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField8.AreaIndex = 0;
		this.pivotGridField8.Caption = "Attendance Count";
		dataSourceColumnBinding8.ColumnName = "AttendanceCount";
		this.pivotGridField8.DataBinding = dataSourceColumnBinding8;
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField8.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(639, 24);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 7;
		this.labelControl1.Text = "labelControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem2, this.layoutControlItem1 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(647, 450);
		this.Root.TextVisible = false;
		this.layoutControlItem2.Control = this.labelControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(643, 28);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem1.Control = this.pivotGridControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(643, 418);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrAttendanceHistoryTermlyPerStudent";
		base.Size = new System.Drawing.Size(647, 450);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
