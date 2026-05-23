using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class usrSummativeAssessment : XtraUserControl
{
	private string connection = DataConnection.ConnectToDatabase();

	private DataTable dt;

	private DataTable _dt;

	private DataTable __dt;

	private string scoresTable = SchoolSettings.ScoresTableSource(StudentOptions.ActiveClass());

	private string generalReport = SchoolSettings.GeneralReportTableSource(StudentOptions.ActiveClass());

	private string generalReportGrading = SchoolSettings.GeneralReportGradingTableSource(StudentOptions.ActiveClass());

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumn6;

	private LabelControl lblCurrentView;

	private PictureEdit pictureEdit1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem5;

	private EmptySpaceItem emptySpaceItem1;

	private LabelControl lblStudentNo;

	private LabelControl labelControl4;

	private LabelControl lblName;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private MultiEditorRow row3;

	private PivotGridControl pivotGridControl1;

	private LayoutControlItem layoutControlItem6;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField7;

	private PivotGridField pivotGridField8;

	private PivotGridControl pivotGridControl2;

	private LayoutControlItem layoutControlItem3;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	public usrSummativeAssessment()
	{
		InitializeComponent();
		LoadStudents();
	}

	private void LoadComments(string studentNo)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM {generalReportGrading} WHERE StudentNumber='{studentNo}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScoreCard");
			__dt = new DataTable();
			__dt = dataSet.Tables[0];
			pivotGridControl2.DataSource = __dt.DefaultView;
			if (!(StudentOptions.ActiveClass() == "S.3") && !(StudentOptions.ActiveClass() == "S.4"))
			{
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadStudents()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{StudentOptions.ActiveClass()}' AND StreamId='{StudentOptions.ActiveStream()}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScoreCard");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			gridControl1.DataSource = _dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadReportData(string studentNo)
	{
		try
		{
			double result = 0.0;
			double result2 = 0.0;
			double result3 = 0.0;
			double result4 = 0.0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings WHERE ClassId='{StudentOptions.ActiveClass()}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GradingRatios");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (double.TryParse(row["HoP"].ToString(), out result) ? result : 0.0);
				result2 = (double.TryParse(row["BOT"].ToString(), out result2) ? result2 : 0.0);
				result3 = (double.TryParse(row["MOT"].ToString(), out result3) ? result3 : 0.0);
				result4 = (double.TryParse(row["EOT"].ToString(), out result4) ? result4 : 0.0);
			}
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM {generalReport} WHERE StudentNumber='{studentNo}'", connection);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "ScoreCard");
			dt = new DataTable();
			dt = dataSet2.Tables[0];
			pivotGridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrCustomComments_Load(object sender, EventArgs e)
	{
		lblCurrentView.Text = $"Summative Assessment [{StudentOptions.ActiveClass()}{StudentOptions.ActiveStream()}]";
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = _dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			byte[] array = new byte[0];
			array = (byte[])dataRow["Picture"];
			lblName.Text = dataRow["fullName"].ToString();
			lblStudentNo.Text = dataRow["StudentNumber"].ToString();
			StudentOptions.SetActiveStudent(dataRow["fullName"].ToString());
			using (MemoryStream stream = new MemoryStream(array))
			{
				pictureEdit1.Image = Image.FromStream(stream);
			}
			LoadReportData(dataRow["StudentNumber"].ToString());
			LoadComments(dataRow["StudentNumber"].ToString());
			PrintableControl.SavePrintableControl(pivotGridControl1, pivotGridControl2);
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
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pivotGridControl2 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblCurrentView = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.MultiEditorRow();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField2.AreaIndex = 0;
		this.pivotGridField2.Caption = "Best Aggregates";
		this.pivotGridField2.FieldName = "BestinEight";
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField3.AreaIndex = 1;
		this.pivotGridField3.Caption = "Div";
		this.pivotGridField3.FieldName = "Div";
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.layoutControl1.Controls.Add(this.pivotGridControl2);
		this.layoutControl1.Controls.Add(this.pivotGridControl1);
		this.layoutControl1.Controls.Add(this.lblStudentNo);
		this.layoutControl1.Controls.Add(this.labelControl4);
		this.layoutControl1.Controls.Add(this.lblName);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.lblCurrentView);
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(831, 0, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(816, 529);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.pivotGridControl2.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[4] { this.pivotGridField2, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5 });
		this.pivotGridControl2.Location = new System.Drawing.Point(118, 464);
		this.pivotGridControl2.Name = "pivotGridControl2";
		this.pivotGridControl2.OptionsView.DrawFocusedCellRect = false;
		this.pivotGridControl2.OptionsView.GroupFieldsInCustomizationWindow = false;
		this.pivotGridControl2.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl2.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl2.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl2.OptionsView.ShowColumnTotals = false;
		this.pivotGridControl2.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl2.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl2.OptionsView.ShowFilterSeparatorBar = false;
		this.pivotGridControl2.OptionsView.ShowGrandTotalsForSingleValues = true;
		this.pivotGridControl2.OptionsView.ShowHorzLines = false;
		this.pivotGridControl2.OptionsView.ShowRowGrandTotalHeader = false;
		this.pivotGridControl2.OptionsView.ShowRowGrandTotals = false;
		this.pivotGridControl2.OptionsView.ShowRowHeaders = false;
		this.pivotGridControl2.OptionsView.ShowRowTotals = false;
		this.pivotGridControl2.Size = new System.Drawing.Size(498, 63);
		this.pivotGridControl2.TabIndex = 21;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField4.AreaIndex = 0;
		this.pivotGridField4.Caption = "Semester";
		this.pivotGridField4.FieldName = "SemesterId";
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField5.AreaIndex = 0;
		this.pivotGridField5.Caption = "Student#";
		this.pivotGridField5.FieldName = "StudentNumber";
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.Width = 123;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[4] { this.pivotGridField1, this.pivotGridField6, this.pivotGridField7, this.pivotGridField8 });
		this.pivotGridControl1.Location = new System.Drawing.Point(118, 25);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterSeparatorBar = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(498, 435);
		this.pivotGridControl1.TabIndex = 20;
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Subject";
		this.pivotGridField1.FieldName = "SubjectId";
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField6.AreaIndex = 0;
		this.pivotGridField6.Caption = "Score";
		this.pivotGridField6.FieldName = "AvMark";
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField7.AreaIndex = 1;
		this.pivotGridField7.Caption = "Grade";
		this.pivotGridField7.FieldName = "Category";
		this.pivotGridField7.Name = "pivotGridField7";
		this.pivotGridField7.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField8.AreaIndex = 0;
		this.pivotGridField8.Caption = "Semester";
		this.pivotGridField8.FieldName = "SemesterId";
		this.pivotGridField8.Name = "pivotGridField8";
		this.lblStudentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblStudentNo.Location = new System.Drawing.Point(634, 82);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(180, 19);
		this.lblStudentNo.StyleController = this.layoutControl1;
		this.lblStudentNo.TabIndex = 19;
		this.lblStudentNo.Text = "[Student No]";
		this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl4.Location = new System.Drawing.Point(634, 65);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(180, 13);
		this.labelControl4.StyleController = this.layoutControl1;
		this.labelControl4.TabIndex = 18;
		this.labelControl4.Text = "Student#";
		this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblName.Location = new System.Drawing.Point(634, 42);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(180, 19);
		this.lblName.StyleController = this.layoutControl1;
		this.lblName.TabIndex = 17;
		this.lblName.Text = "[Name]";
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Location = new System.Drawing.Point(634, 25);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(180, 13);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 16;
		this.labelControl2.Text = "Name";
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
		this.labelControl1.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(620, 25);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(10, 502);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 15;
		this.lblCurrentView.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCurrentView.Location = new System.Drawing.Point(2, 2);
		this.lblCurrentView.Name = "lblCurrentView";
		this.lblCurrentView.Size = new System.Drawing.Size(812, 19);
		this.lblCurrentView.StyleController = this.layoutControl1;
		this.lblCurrentView.TabIndex = 14;
		this.pictureEdit1.Location = new System.Drawing.Point(634, 105);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(180, 256);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 13;
		this.gridControl1.Location = new System.Drawing.Point(2, 25);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(112, 502);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Magenta;
		this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Magenta;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.Magenta;
		this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Magenta;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold);
		this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[1] { this.gridColumn6 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsFind.ShowClearButton = false;
		this.gridView1.OptionsFind.ShowCloseButton = false;
		this.gridView1.OptionsFind.ShowFindButton = false;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridColumn6.Caption = "Name";
		this.gridColumn6.FieldName = "fullName";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 0;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[11]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem5, this.emptySpaceItem1, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem11, this.layoutControlItem6,
			this.layoutControlItem3
		});
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(816, 529);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(116, 506);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.pictureEdit1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(632, 103);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(184, 260);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem5.Control = this.lblCurrentView;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(816, 23);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(632, 363);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(184, 166);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.Control = this.labelControl1;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(618, 23);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(14, 506);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.Control = this.labelControl2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(632, 23);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(184, 17);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.lblName;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(632, 40);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(184, 23);
		this.layoutControlItem9.Text = "layoutControlItem9";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextToControlDistance = 0;
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem10.Control = this.labelControl4;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(632, 63);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(184, 17);
		this.layoutControlItem10.Text = "layoutControlItem10";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextToControlDistance = 0;
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.lblStudentNo;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(632, 80);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(184, 23);
		this.layoutControlItem11.Text = "layoutControlItem11";
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextToControlDistance = 0;
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem6.Control = this.pivotGridControl1;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(116, 23);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(502, 439);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem3.Control = this.pivotGridControl2;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(116, 462);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(502, 67);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.row3.Name = "row3";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrSummativeAssessment";
		base.Size = new System.Drawing.Size(816, 529);
		base.Load += new System.EventHandler(usrCustomComments_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
