using System;
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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrNewCurriculumMarkSheet : XtraUserControl
{
	private string Term = "";

	private string _Class = "";

	private int reportType = 0;

	private string subHeader = string.Empty;

	private IContainer components = null;

	private PivotGridControl pivotGridControl1;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField13;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private PivotGridField pivotGridField14;

	private PivotGridField pivotGridField15;

	private LayoutControl layoutControl1;

	private LabelControl lblSubHeader;

	private LabelControl lblHeader;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	public usrNewCurriculumMarkSheet(string Term, string _Class, int reportType)
	{
		InitializeComponent();
		this.Term = Term;
		this._Class = _Class;
		this.reportType = reportType;
	}

	private void LoadMarkSheet()
	{
		try
		{
			string empty = string.Empty;
			string text = $"SELECT s.fullName, s.StreamId, r.SemesterId, r.SubjectId, r.ClassId, r.U1 AS Score1, r.U2 AS Score2, r.U3 AS Score3, r.U4 AS Score4,r.TTLPoints, r.PrevTTLPoints, r.OutOfTwenty, r.PrevOutOfTwenty, r.OutOfHund, r.PrevOutOfHund, r.TUnits, r.IsAssessed, r.Initial, r.Grade, r.Category, r.ETA, r.ETA80, r.ETAv, r.Comment, r.AvMark FROM tbl_Scores_OL_Report r INNER JOIN tbl_Stud s ON r.StudentNumber = s.StudentNumber WHERE (r.ClassId = '{_Class}') AND(r.SemesterId = '{Term}')";
			string text2 = $"SELECT s.fullName, s.StreamId, r.SemesterId, r.SubjectId, r.ClassId, r.T1 AS Score1, r.T2 AS Score2, r.T3 AS Score3, r.T4 AS Score4,r.TTLPoints, r.PrevTTLPoints, r.OutOfTwenty, r.PrevOutOfTwenty, r.OutOfHund, r.PrevOutOfHund, r.TUnits, r.IsAssessed, r.Initial, r.Grade, r.Category, r.ETA, r.ETA80, r.ETAv, r.Comment, r.AvMark FROM tbl_Scores_OL_Report r INNER JOIN tbl_Stud s ON r.StudentNumber = s.StudentNumber WHERE (r.ClassId = '{_Class}') AND(r.SemesterId = '{Term}')";
			string text3 = $"SELECT s.fullName, s.StreamId, r.SemesterId, r.SubjectId, r.ClassId, r.Score1, r.Score2, r.Score3, r.Score4, r.TTLPoints, r.PrevTTLPoints, r.OutOfTwenty, r.PrevOutOfTwenty, r.OutOfHund, r.PrevOutOfHund, r.TUnits, r.IsAssessed, r.Initial, r.Grade, r.Category, r.ETA, r.ETA80, r.ETAv, r.Comment, r.AvMark FROM tbl_Scores_OL_Report r INNER JOIN tbl_Stud s ON r.StudentNumber = s.StudentNumber WHERE (r.ClassId = '{_Class}') AND(r.SemesterId = '{Term}')";
			string text4 = $" SELECT s.fullName, s.StreamId, r.SemesterId, r.SubjectId,  r.Hund1 AS Score1, r.Hund2 AS Score2, r.Hund3 AS Score3, r.Hund4 AS Score4, r.TTLPoints, r.PrevTTLPoints, r.PrevOutOfTwenty, r.OutOfHund AS OutOfTwenty, r.PrevOutOfHund, r.TUnits, r.IsAssessed, r.Initial, r.Grade, r.Category, r.ETA, r.ETA80, r.ETAv, r.Comment, r.AvMark  FROM tbl_Scores_OL_Report r INNER JOIN tbl_Stud s ON r.StudentNumber = s.StudentNumber  WHERE (r.ClassId = '{_Class}') AND(r.SemesterId = '{Term}')";
			if (reportType == 0)
			{
				empty = text;
				subHeader = "Marks on Scale 3";
			}
			else if (reportType == 1)
			{
				empty = text2;
				subHeader = "Marks on Scale 10";
			}
			else if (reportType == 2)
			{
				empty = text3;
				subHeader = "Marks on Scale 20";
			}
			else
			{
				empty = text4;
				subHeader = "Marks on Scale 100";
			}
			lblHeader.Text = "Students' raw marks. " + _Class + "-" + Term;
			lblSubHeader.Text = subHeader;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			pivotGridControl1.DataSource = dataTable.DefaultView;
			PrintableControl.SavePrintableControl(pivotGridControl1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrNewCurriculumMarkSheet_Load(object sender, EventArgs e)
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading marksheet. Please wait...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadStudentList, 0);
		Thread.Sleep(25);
		LoadMarkSheet();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
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
		DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding9 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField13 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField14 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField15 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.lblSubHeader = new DevExpress.XtraEditors.LabelControl();
		this.lblHeader = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.pivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.Cell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.pivotGridControl1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.Empty.Options.UseFont = true;
		this.pivotGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FilterPanel.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FilterSeparator.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridControl1.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.Appearance.Lines.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.Lines.Options.UseFont = true;
		this.pivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridControl1.Appearance.TotalCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Cell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.Lines.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridControl1.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Cascadia Mono", 10f);
		this.pivotGridControl1.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[9] { this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5, this.pivotGridField6, this.pivotGridField13, this.pivotGridField14, this.pivotGridField15 });
		this.pivotGridControl1.Location = new System.Drawing.Point(12, 64);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized;
		this.pivotGridControl1.OptionsPrint.UsePrintAppearance = true;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemTextEdit1 });
		this.pivotGridControl1.Size = new System.Drawing.Size(952, 572);
		this.pivotGridControl1.TabIndex = 0;
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Name";
		dataSourceColumnBinding.ColumnName = "fullName";
		this.pivotGridField1.DataBinding = dataSourceColumnBinding;
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField1.Width = 200;
		this.pivotGridField2.AreaIndex = 0;
		this.pivotGridField2.Caption = "Stream";
		dataSourceColumnBinding2.ColumnName = "StreamId";
		this.pivotGridField2.DataBinding = dataSourceColumnBinding2;
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField3.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField3.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField3.AreaIndex = 0;
		this.pivotGridField3.Caption = "U1";
		dataSourceColumnBinding3.ColumnName = "Score1";
		this.pivotGridField3.DataBinding = dataSourceColumnBinding3;
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField3.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField3.Width = 30;
		this.pivotGridField4.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField4.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField4.AreaIndex = 1;
		this.pivotGridField4.Caption = "U2";
		dataSourceColumnBinding4.ColumnName = "Score2";
		this.pivotGridField4.DataBinding = dataSourceColumnBinding4;
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField4.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField4.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField4.Width = 30;
		this.pivotGridField5.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField5.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField5.AreaIndex = 2;
		this.pivotGridField5.Caption = "U3";
		dataSourceColumnBinding5.ColumnName = "Score3";
		this.pivotGridField5.DataBinding = dataSourceColumnBinding5;
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField5.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField5.Width = 30;
		this.pivotGridField6.Appearance.Header.Options.UseTextOptions = true;
		this.pivotGridField6.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField6.AreaIndex = 3;
		this.pivotGridField6.Caption = "U4";
		dataSourceColumnBinding6.ColumnName = "Score4";
		this.pivotGridField6.DataBinding = dataSourceColumnBinding6;
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField6.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField6.Width = 30;
		this.pivotGridField13.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField13.AreaIndex = 1;
		this.pivotGridField13.Caption = "TTL Points";
		dataSourceColumnBinding7.ColumnName = "TTLPoints";
		this.pivotGridField13.DataBinding = dataSourceColumnBinding7;
		this.pivotGridField13.Name = "pivotGridField13";
		this.pivotGridField13.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField13.Visible = false;
		this.pivotGridField14.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField14.AreaIndex = 1;
		this.pivotGridField14.Caption = "Av. Mark";
		dataSourceColumnBinding8.ColumnName = "OutOfTwenty";
		this.pivotGridField14.DataBinding = dataSourceColumnBinding8;
		this.pivotGridField14.Name = "pivotGridField14";
		this.pivotGridField14.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField14.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField14.Visible = false;
		this.pivotGridField15.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField15.AreaIndex = 0;
		this.pivotGridField15.Caption = "Subject";
		dataSourceColumnBinding9.ColumnName = "SubjectId";
		this.pivotGridField15.DataBinding = dataSourceColumnBinding9;
		this.pivotGridField15.Name = "pivotGridField15";
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.layoutControl1.Controls.Add(this.lblSubHeader);
		this.layoutControl1.Controls.Add(this.pivotGridControl1);
		this.layoutControl1.Controls.Add(this.lblHeader);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(976, 648);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(976, 648);
		this.Root.TextVisible = false;
		this.lblSubHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.lblSubHeader.Appearance.Options.UseFont = true;
		this.lblSubHeader.Appearance.Options.UseTextOptions = true;
		this.lblSubHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblSubHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblSubHeader.Location = new System.Drawing.Point(12, 41);
		this.lblSubHeader.Name = "lblSubHeader";
		this.lblSubHeader.Size = new System.Drawing.Size(952, 19);
		this.lblSubHeader.StyleController = this.layoutControl1;
		this.lblSubHeader.TabIndex = 9;
		this.lblHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 16f);
		this.lblHeader.Appearance.Options.UseFont = true;
		this.lblHeader.Appearance.Options.UseTextOptions = true;
		this.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader.Location = new System.Drawing.Point(12, 12);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(952, 25);
		this.lblHeader.StyleController = this.layoutControl1;
		this.lblHeader.TabIndex = 8;
		this.layoutControlItem1.Control = this.lblHeader;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(956, 29);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.lblSubHeader;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 29);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(956, 23);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.pivotGridControl1;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(956, 576);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrNewCurriculumMarkSheet";
		base.Size = new System.Drawing.Size(976, 648);
		base.Load += new System.EventHandler(usrNewCurriculumMarkSheet_Load);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
