using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrScoreboardReview : XtraUserControl
{
	private string _Class = string.Empty;

	private string Year = string.Empty;

	private IContainer components = null;

	private PivotGridControl pivotGridControl1;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField8;

	private PivotGridField pivotGridField10;

	private PivotGridField pivotGridField2;

	private LayoutControl layoutControl1;

	private LabelControl lblHeader;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	public usrScoreboardReview(string _Class, string Year)
	{
		Dock = DockStyle.Fill;
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading score summary...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadStudentList, 0);
		Thread.Sleep(25);
		InitializeComponent();
		this._Class = _Class;
		this.Year = Year;
		LoadReviewScoreboard();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadReviewScoreboard()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT sc.ClassId AS PrevClass, (s.fullName + '-' + s.StudentNumber + '(' + s.ClassId +')') AS fullName,s.LIN, sc.SemesterId, s.StreamId, sc.AvLO, sc.AvMark, sc.ETAv, sc.SubjectId, sc.OutOfTen, sc.P1, sc.PTotal  FROM            tbl_Stud AS s INNER JOIN     tbl_Scores_OL_Report AS sc ON s.StudentNumber = sc.StudentNumber  WHERE(sc.ClassId = '{_Class}') AND(sc.SemesterId LIKE '%{Year}%')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		pivotGridControl1.DataSource = dataTable.DefaultView;
		string activeForm = _Class + " Class of " + Year + " annual performance summary";
		lblHeader.Text = activeForm;
		PrintableControl.SavePrintableControl(pivotGridControl1);
		ActiveFormSelected.SetActiveForm(activeForm);
	}

	private void pivotGridControl1_CustomDrawFieldHeader(object sender, PivotCustomDrawFieldHeaderEventArgs e)
	{
	}

	private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
	{
		if (e.ValueType == PivotGridValueType.GrandTotal && e.IsColumn)
		{
			e.DisplayText = "Avg. Score";
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
		DevExpress.XtraPivotGrid.PivotGridGroup pivotGridGroup = new DevExpress.XtraPivotGrid.PivotGridGroup();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding2 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding3 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding4 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding5 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding6 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.lblHeader = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterSeparator.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Lines.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.TotalCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Cell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Lines.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Consolas", 10f);
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[6] { this.pivotGridField1, this.pivotGridField3, this.pivotGridField6, this.pivotGridField8, this.pivotGridField10, this.pivotGridField2 });
		pivotGridGroup.Fields.Add(this.pivotGridField1);
		this.pivotGridControl1.Groups.AddRange(new DevExpress.XtraPivotGrid.PivotGridGroup[1] { pivotGridGroup });
		this.pivotGridControl1.Location = new System.Drawing.Point(4, 31);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized;
		this.pivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintRowAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(480, 344);
		this.pivotGridControl1.TabIndex = 0;
		this.pivotGridControl1.FieldValueDisplayText += new DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventHandler(pivotGridControl1_FieldValueDisplayText);
		this.pivotGridControl1.CustomDrawFieldHeader += new DevExpress.XtraPivotGrid.PivotCustomDrawFieldHeaderEventHandler(pivotGridControl1_CustomDrawFieldHeader);
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Name >>StudentNo >>Class";
		dataSourceColumnBinding.ColumnName = "fullName";
		this.pivotGridField1.DataBinding = dataSourceColumnBinding;
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField1.Width = 300;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField3.AreaIndex = 0;
		this.pivotGridField3.Caption = "Term";
		dataSourceColumnBinding2.ColumnName = "SemesterId";
		this.pivotGridField3.DataBinding = dataSourceColumnBinding2;
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Value;
		this.pivotGridField6.AreaIndex = 0;
		this.pivotGridField6.Caption = "Stream";
		dataSourceColumnBinding3.ColumnName = "StreamId";
		this.pivotGridField6.DataBinding = dataSourceColumnBinding3;
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField8.AreaIndex = 0;
		this.pivotGridField8.Caption = "AvMark";
		dataSourceColumnBinding4.ColumnName = "AvMark";
		this.pivotGridField8.DataBinding = dataSourceColumnBinding4;
		this.pivotGridField8.GrandTotalCellFormat.FormatString = "{0:n1}";
		this.pivotGridField8.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField8.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField8.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
		this.pivotGridField8.TotalCellFormat.FormatString = "{0:n1}";
		this.pivotGridField8.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField10.AreaIndex = 2;
		this.pivotGridField10.Caption = "Subject";
		dataSourceColumnBinding5.ColumnName = "SubjectId";
		this.pivotGridField10.DataBinding = dataSourceColumnBinding5;
		this.pivotGridField10.Name = "pivotGridField10";
		this.pivotGridField10.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Value;
		this.pivotGridField10.Width = 170;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "LIN";
		dataSourceColumnBinding6.ColumnName = "LIN";
		this.pivotGridField2.DataBinding = dataSourceColumnBinding6;
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField2.Width = 135;
		this.layoutControl1.Controls.Add(this.lblHeader);
		this.layoutControl1.Controls.Add(this.pivotGridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(488, 379);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem2 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(488, 379);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.pivotGridControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 27);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(484, 348);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.lblHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.lblHeader.Appearance.Options.UseFont = true;
		this.lblHeader.Appearance.Options.UseTextOptions = true;
		this.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader.Location = new System.Drawing.Point(4, 4);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(480, 23);
		this.lblHeader.StyleController = this.layoutControl1;
		this.lblHeader.TabIndex = 4;
		this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.layoutControlItem2.Control = this.lblHeader;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(484, 27);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrScoreboardReview";
		base.Size = new System.Drawing.Size(488, 379);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
