using System;
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

public class usrAttendanceHistorySummary : XtraUserControl
{
	private DataTable dt;

	private string Term = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private PivotGridControl pivotGridControl1;

	private LayoutControlItem layoutControlItem2;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField5;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem1;

	private PivotGridField pivotGridField4;

	public usrAttendanceHistorySummary(string Term)
	{
		InitializeComponent();
		this.Term = Term;
		labelControl1.Text = Term + " population analysis";
		LoadUnSummerisedReport();
	}

	private void LoadUnSummerisedReport()
	{
		try
		{
			dt = new DataTable();
			dt.Columns.Add("ClassId", typeof(string));
			dt.Columns.Add("StreamId", typeof(string));
			dt.Columns.Add("Sex", typeof(string));
			dt.Columns.Add("TotalStudents", typeof(int));
			dt.Columns.Add("Category", typeof(string));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT TOP (100) PERCENT ClassId, StreamId, Sex, COUNT_BIG(StudentNumber) AS TotalStudents  FROM tbl_Stud GROUP BY ClassId, StreamId, Sex ORDER BY ClassId", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				dt.Rows.Add(row["ClassId"], row["StreamId"], row["Sex"], Convert.ToInt32(row["TotalStudents"].ToString()), "Expected");
			}
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT TOP (100) PERCENT s.ClassId, s.StreamId, s.Sex, SUM(a.AttendanceCount) AS TotalStudents FROM   tbl_Stud s INNER JOIN   AttendanceSheet a ON s.StudentNumber = a.StudentNo GROUP BY s.ClassId, s.StreamId, s.Sex, a.AttendanceCategory, a.SemesterId HAVING(a.AttendanceCategory = N'Reporting') AND(a.SemesterId = N'{Term}') ", DataConnection.ConnectToDatabase());
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			foreach (DataRow row2 in dataTable2.Rows)
			{
				dt.Rows.Add(row2["ClassId"], row2["StreamId"], row2["Sex"], Convert.ToInt32(row2["TotalStudents"].ToString()), "Reported");
			}
			pivotGridControl1.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(pivotGridControl1);
			ActiveFormSelected.SetActiveForm(Term + " population analysis");
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message);
		}
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
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
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.pivotGridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(647, 450);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(12, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(623, 24);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 6;
		this.labelControl1.Text = "labelControl1";
		this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterSeparator.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseTextOptions = true;
		this.pivotGridControl1.Appearance.HeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridControl1.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Lines.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.TotalCell.Font = new System.Drawing.Font("Consolas", 11.25f);
		this.pivotGridControl1.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Cell.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Consolas", 11f, System.Drawing.FontStyle.Bold);
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Lines.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Consolas", 11f);
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[5] { this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField5, this.pivotGridField4 });
		this.pivotGridControl1.Location = new System.Drawing.Point(12, 40);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized;
		this.pivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintRowAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(623, 398);
		this.pivotGridControl1.TabIndex = 5;
		this.pivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(pivotGridControl1_FieldValueDisplayText);
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Class";
		dataSourceColumnBinding.ColumnName = "ClassId";
		this.pivotGridField1.DataBinding = dataSourceColumnBinding;
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "Stream";
		dataSourceColumnBinding2.ColumnName = "StreamId";
		this.pivotGridField2.DataBinding = dataSourceColumnBinding2;
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField3.AreaIndex = 1;
		this.pivotGridField3.Caption = "Sex";
		dataSourceColumnBinding3.ColumnName = "Sex";
		this.pivotGridField3.DataBinding = dataSourceColumnBinding3;
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField5.AreaIndex = 0;
		this.pivotGridField5.Caption = "Reported";
		dataSourceColumnBinding4.ColumnName = "TotalStudents";
		this.pivotGridField5.DataBinding = dataSourceColumnBinding4;
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField5.Width = 70;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField4.AreaIndex = 0;
		this.pivotGridField4.Caption = "Category";
		dataSourceColumnBinding5.ColumnName = "Category";
		this.pivotGridField4.DataBinding = dataSourceColumnBinding5;
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField4.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField4.Width = 70;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem2, this.layoutControlItem1 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(647, 450);
		this.Root.TextVisible = false;
		this.layoutControlItem2.Control = this.pivotGridControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(627, 402);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem1.Control = this.labelControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(627, 28);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrAttendanceHistorySummary";
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
