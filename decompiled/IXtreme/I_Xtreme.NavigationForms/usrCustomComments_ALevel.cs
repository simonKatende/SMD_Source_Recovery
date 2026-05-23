using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class usrCustomComments_ALevel : XtraUserControl
{
	private string connection = DataConnection.ConnectToDatabase();

	private DataTable dt;

	private DataTable _dt;

	private DataTable __dt;

	private string reportSource = "tbl_GeneralReport_" + StudentOptions.ActiveClass().Substring(2, 1);

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem1;

	private VGridControl vGridControl2;

	private LayoutControlItem layoutControlItem3;

	private BandedGridView bandedGridView1;

	private BandedGridColumn gridColumn1;

	private BandedGridColumn gridColumn2;

	private BandedGridColumn gridColumn3;

	private BandedGridColumn gridColumn4;

	private BandedGridColumn gridColumn5;

	private BandedGridColumn bandedGridColumn2;

	private BandedGridColumn bandedGridColumn1;

	private BandedGridColumn bandedGridColumn3;

	private BandedGridColumn bandedGridColumn4;

	private GridColumn gridColumn6;

	private GridBand gridBand1;

	private GridBand gridBand3;

	private GridBand gridBand2;

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

	private PivotGridControl pivotGridControl1;

	private LayoutControlItem layoutControlItem12;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField7;

	private PivotGridField pivotGridField8;

	private PivotGridField pivotGridField9;

	private PivotGridField pivotGridField10;

	private PivotGridField pivotGridField11;

	private EditorRow row;

	private EditorRow row2;

	private EditorRow row3;

	private EditorRow row1;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	public usrCustomComments_ALevel()
	{
		InitializeComponent();
		LoadStudents();
	}

	private void LoadComments(string studentNo)
	{
		try
		{
			string selectCommandText = $"SELECT MAX(id) AS id,Grade,TotalPoints,HeadTeacherComments,DOSComments,ClassTeacherComments,ClassId FROM tbl_ALevelReport  WHERE (SemesterId = '{StudentOptions.ActiveSemester()}') AND (StudentNumber = '{studentNo}') AND Grade<>'' AND ClassId='{StudentOptions.ActiveClass()}' GROUP BY Grade,TotalPoints,HeadTeacherComments,DOSComments,ClassTeacherComments,ClassId";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScoreCard");
			__dt = new DataTable();
			__dt = dataSet.Tables[0];
			vGridControl2.DataSource = __dt.DefaultView;
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings WHERE SemesterId='{StudentOptions.ActiveSemester()}' AND ClassId='{StudentOptions.ActiveClass()}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GradingRatios");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (double.TryParse(row["HoP"].ToString(), out result) ? result : 0.0);
				result2 = (double.TryParse(row["BOT"].ToString(), out result2) ? result2 : 0.0);
				result3 = (double.TryParse(row["MOT"].ToString(), out result3) ? result3 : 0.0);
				result4 = (double.TryParse(row["EOT"].ToString(), out result4) ? result4 : 0.0);
			}
			string text = $"SELECT gr.StudentNumber, gr.SubjectId, s.Paper, gr.HoP, gr.BOT,gr.MOT, gr.EOT, gr.AvMark, gr.Category, gg.Grade, gr.Initial, gg.Comment FROM  tbl_GeneralReport_Grading_AL gg INNER JOIN tbl_GeneralReport_AL gr ON gg.StudentNumber = gr.StudentNumber AND gg.SemesterId = gr.SemesterId AND gg.SubjectId = gr.SubjectId INNER JOIN  ALevelSubjects_Categorised s ON gr.PaperId = s.PaperId WHERE (gr.ClassId = '{StudentOptions.ActiveClass()}') AND (gr.SemesterId = '{StudentOptions.ActiveSemester()}') AND (gr.StudentNumber = '{studentNo}')";
			string selectCommandText = $"SELECT * FROM tbl_ALevelReport WHERE SemesterId='{StudentOptions.ActiveSemester()}' AND StudentNumber='{studentNo}' AND ClassId='{StudentOptions.ActiveClass()}'";
			using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, connection);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "ScoreCard");
			dt = new DataTable();
			dt = dataSet2.Tables[0];
			pivotGridControl1.DataSource = dt.DefaultView;
			if (result == 0.0)
			{
				pivotGridField3.Visible = false;
			}
			if (result2 == 0.0)
			{
				pivotGridField4.Visible = false;
			}
			if (result3 == 0.0)
			{
				pivotGridField5.Visible = false;
			}
			if (result4 == 0.0)
			{
				pivotGridField6.Visible = false;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrCustomComments_Load(object sender, EventArgs e)
	{
		lblCurrentView.Text = $"Comments customization: ({StudentOptions.ActiveClass()}{StudentOptions.ActiveStream()}-{StudentOptions.ActiveSemester()})";
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
			using (MemoryStream stream = new MemoryStream(array))
			{
				pictureEdit1.Image = Image.FromStream(stream);
			}
			LoadReportData(dataRow["StudentNumber"].ToString());
			LoadComments(dataRow["StudentNumber"].ToString());
		}
	}

	private void vGridControl2_HiddenEditor(object sender, EventArgs e)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(connection);
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_ALevelReport SET ClassTeacherComments=@ClassTeacherComments,HeadTeacherComments=@HeadTeacherComments,DOSComments=@DOSComments WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
			sqlParameter.Value = lblStudentNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
			sqlParameter.Value = StudentOptions.ActiveSemester();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComments", SqlDbType.VarChar, 80);
			sqlParameter.Value = vGridControl2.GetCellValue(row1, 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@DOSComments", SqlDbType.VarChar, 80);
			sqlParameter.Value = vGridControl2.GetCellValue(row2, 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComments", SqlDbType.VarChar, 80);
			sqlParameter.Value = vGridControl2.GetCellValue(row3, 0);
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblCurrentView = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.pivotGridControl1);
		this.layoutControl1.Controls.Add(this.lblStudentNo);
		this.layoutControl1.Controls.Add(this.labelControl4);
		this.layoutControl1.Controls.Add(this.lblName);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.lblCurrentView);
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.vGridControl2);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(831, 0, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(816, 529);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[11]
		{
			this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5, this.pivotGridField6, this.pivotGridField7, this.pivotGridField8, this.pivotGridField9, this.pivotGridField10,
			this.pivotGridField11
		});
		this.pivotGridControl1.Location = new System.Drawing.Point(118, 25);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsCustomization.AllowCustomizationForm = false;
		this.pivotGridControl1.OptionsCustomization.AllowDrag = false;
		this.pivotGridControl1.OptionsCustomization.AllowDragInCustomizationForm = false;
		this.pivotGridControl1.OptionsCustomization.AllowEdit = false;
		this.pivotGridControl1.OptionsCustomization.AllowExpand = false;
		this.pivotGridControl1.OptionsCustomization.AllowExpandOnDoubleClick = false;
		this.pivotGridControl1.OptionsCustomization.AllowFilter = false;
		this.pivotGridControl1.OptionsCustomization.AllowFilterBySummary = false;
		this.pivotGridControl1.OptionsCustomization.AllowPrefilter = false;
		this.pivotGridControl1.OptionsCustomization.AllowResizing = false;
		this.pivotGridControl1.OptionsCustomization.AllowSort = false;
		this.pivotGridControl1.OptionsCustomization.AllowSortBySummary = false;
		this.pivotGridControl1.OptionsData.AllowCrossGroupVariation = false;
		this.pivotGridControl1.OptionsData.AutoExpandGroups = DevExpress.Utils.DefaultBoolean.True;
		this.pivotGridControl1.OptionsDataField.AreaIndex = 0;
		this.pivotGridControl1.OptionsFilterPopup.AllowContextMenu = false;
		this.pivotGridControl1.OptionsFilterPopup.AllowIncrementalSearch = false;
		this.pivotGridControl1.OptionsFilterPopup.ShowToolbar = false;
		this.pivotGridControl1.OptionsView.DrawFocusedCellRect = false;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterSeparatorBar = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
		this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
		this.pivotGridControl1.OptionsView.ShowRowTotals = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(498, 319);
		this.pivotGridControl1.TabIndex = 20;
		this.pivotGridField1.Appearance.Value.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField1.Appearance.Value.Options.UseFont = true;
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Subject";
		this.pivotGridField1.FieldName = "SubjectId";
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField1.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField1.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField1.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField1.Width = 170;
		this.pivotGridField2.Appearance.Value.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField2.Appearance.Value.Options.UseFont = true;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "Paper";
		this.pivotGridField2.FieldName = "Paper";
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField2.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField2.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridField2.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField3.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField3.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField3.AreaIndex = 0;
		this.pivotGridField3.Caption = "HoP";
		this.pivotGridField3.FieldName = "HoP";
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField3.Width = 44;
		this.pivotGridField4.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField4.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField4.AreaIndex = 1;
		this.pivotGridField4.Caption = "BOT";
		this.pivotGridField4.FieldName = "BOT";
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField4.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField4.Width = 44;
		this.pivotGridField5.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField5.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField5.AreaIndex = 2;
		this.pivotGridField5.Caption = "MOT";
		this.pivotGridField5.FieldName = "MOT";
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField5.Width = 44;
		this.pivotGridField6.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField6.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField6.AreaIndex = 3;
		this.pivotGridField6.Caption = "EOT";
		this.pivotGridField6.FieldName = "EOT";
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField6.Width = 44;
		this.pivotGridField7.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField7.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField7.AreaIndex = 4;
		this.pivotGridField7.Caption = "AvMark";
		this.pivotGridField7.FieldName = "AvMark";
		this.pivotGridField7.Name = "pivotGridField7";
		this.pivotGridField7.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField7.Width = 47;
		this.pivotGridField8.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField8.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField8.AreaIndex = 5;
		this.pivotGridField8.Caption = "Grade";
		this.pivotGridField8.FieldName = "Category";
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField8.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField8.Width = 44;
		this.pivotGridField9.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField9.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField9.AreaIndex = 6;
		this.pivotGridField9.Caption = "Score";
		this.pivotGridField9.FieldName = "Grade";
		this.pivotGridField9.Name = "pivotGridField9";
		this.pivotGridField9.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField9.Width = 44;
		this.pivotGridField10.Appearance.Cell.Options.UseTextOptions = true;
		this.pivotGridField10.Appearance.Cell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.pivotGridField10.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Comic Sans MS", 8.25f);
		this.pivotGridField10.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField10.Appearance.CellGrandTotal.Options.UseTextOptions = true;
		this.pivotGridField10.Appearance.CellGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField10.AreaIndex = 7;
		this.pivotGridField10.Caption = "Comment";
		this.pivotGridField10.FieldName = "Comment";
		this.pivotGridField10.Name = "pivotGridField10";
		this.pivotGridField10.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField10.Width = 250;
		this.pivotGridField11.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.pivotGridField11.Appearance.CellGrandTotal.Options.UseFont = true;
		this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField11.AreaIndex = 8;
		this.pivotGridField11.Caption = "Initial";
		this.pivotGridField11.FieldName = "Initial";
		this.pivotGridField11.Name = "pivotGridField11";
		this.pivotGridField11.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField11.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.pivotGridField11.Width = 44;
		this.lblStudentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblStudentNo.Location = new System.Drawing.Point(634, 82);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(180, 19);
		this.lblStudentNo.StyleController = this.layoutControl1;
		this.lblStudentNo.TabIndex = 19;
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
		this.lblCurrentView.Size = new System.Drawing.Size(110, 19);
		this.lblCurrentView.StyleController = this.layoutControl1;
		this.lblCurrentView.TabIndex = 14;
		this.lblCurrentView.Text = "labelControl1";
		this.pictureEdit1.Location = new System.Drawing.Point(634, 105);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(180, 302);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 13;
		this.vGridControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.vGridControl2.Location = new System.Drawing.Point(118, 370);
		this.vGridControl2.Name = "vGridControl2";
		this.vGridControl2.RecordWidth = 994;
		this.vGridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemTextEdit1 });
		this.vGridControl2.RowHeaderWidth = 104;
		this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[4] { this.row, this.row1, this.row2, this.row3 });
		this.vGridControl2.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Never;
		this.vGridControl2.Size = new System.Drawing.Size(498, 157);
		this.vGridControl2.TabIndex = 11;
		this.vGridControl2.HiddenEditor += new System.EventHandler(vGridControl2_HiddenEditor);
		this.repositoryItemTextEdit1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.repositoryItemTextEdit1.Appearance.Options.UseFont = true;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.row.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.row.Appearance.Options.UseFont = true;
		this.row.Appearance.Options.UseTextOptions = true;
		this.row.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.row.Height = 27;
		this.row.Name = "row";
		this.row.OptionsRow.AllowMove = false;
		this.row.OptionsRow.AllowMoveToCustomizationForm = false;
		this.row.OptionsRow.AllowSize = false;
		this.row.OptionsRow.DblClickExpanding = false;
		this.row.OptionsRow.ShowInCustomizationForm = false;
		this.row.Properties.FieldName = "TotalPoints";
		this.row.Properties.Format.FormatString = "{0:#.0 Points}";
		this.row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Custom;
		this.row.Properties.ReadOnly = true;
		this.row.Properties.RowEdit = this.repositoryItemTextEdit1;
		this.row1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.row1.Appearance.Options.UseFont = true;
		this.row1.Height = 24;
		this.row1.Name = "row1";
		this.row1.Properties.Caption = "Classteacher";
		this.row1.Properties.FieldName = "ClassTeacherComments";
		this.row2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.row2.Appearance.Options.UseFont = true;
		this.row2.Height = 24;
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "DOS";
		this.row2.Properties.FieldName = "DOSComments";
		this.row3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.row3.Appearance.Options.UseFont = true;
		this.row3.Height = 24;
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Headteacher";
		this.row3.Properties.FieldName = "HeadTeacherComments";
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
			this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem2, this.layoutControlItem5, this.emptySpaceItem1, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem11,
			this.layoutControlItem12
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
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.vGridControl2;
		this.layoutControlItem3.CustomizationFormText = "Report Comments";
		this.layoutControlItem3.Location = new System.Drawing.Point(116, 346);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(502, 183);
		this.layoutControlItem3.Text = "Report Comments";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(147, 19);
		this.layoutControlItem2.Control = this.pictureEdit1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(632, 103);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(184, 306);
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
		this.emptySpaceItem1.Location = new System.Drawing.Point(632, 409);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(184, 120);
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
		this.layoutControlItem12.Control = this.pivotGridControl1;
		this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem12.Location = new System.Drawing.Point(116, 23);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(502, 323);
		this.layoutControlItem12.Text = "layoutControlItem12";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextToControlDistance = 0;
		this.layoutControlItem12.TextVisible = false;
		this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[3] { this.gridBand1, this.gridBand3, this.gridBand2 });
		this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[9] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.bandedGridColumn1, this.bandedGridColumn2, this.bandedGridColumn3, this.bandedGridColumn4 });
		this.bandedGridView1.Name = "bandedGridView1";
		this.bandedGridView1.OptionsView.ShowGroupPanel = false;
		this.bandedGridView1.OptionsView.ShowIndicator = false;
		this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.gridBand1.AppearanceHeader.Options.UseFont = true;
		this.gridBand1.Caption = "OVERALL ASSESSMENT";
		this.gridBand1.Columns.Add(this.gridColumn1);
		this.gridBand1.Columns.Add(this.gridColumn2);
		this.gridBand1.Columns.Add(this.gridColumn3);
		this.gridBand1.Columns.Add(this.gridColumn4);
		this.gridBand1.Columns.Add(this.gridColumn5);
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.OptionsBand.AllowHotTrack = false;
		this.gridBand1.OptionsBand.AllowMove = false;
		this.gridBand1.OptionsBand.AllowPress = false;
		this.gridBand1.VisibleIndex = 0;
		this.gridBand1.Width = 616;
		this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumn1.AppearanceCell.Options.UseFont = true;
		this.gridColumn1.Caption = "Agg";
		this.gridColumn1.FieldName = "Agg";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.Width = 87;
		this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumn2.AppearanceCell.Options.UseFont = true;
		this.gridColumn2.Caption = "BestinEight";
		this.gridColumn2.FieldName = "BestinEight";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.Width = 123;
		this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumn3.AppearanceCell.Options.UseFont = true;
		this.gridColumn3.Caption = "Div";
		this.gridColumn3.FieldName = "Div";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.Width = 107;
		this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumn4.AppearanceCell.Options.UseFont = true;
		this.gridColumn4.Caption = "TotalMark";
		this.gridColumn4.FieldName = "TotalMark";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.Width = 122;
		this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumn5.AppearanceCell.Options.UseFont = true;
		this.gridColumn5.Caption = "AvMark";
		this.gridColumn5.FieldName = "AvMark";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.Width = 177;
		this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.gridBand3.AppearanceHeader.Options.UseFont = true;
		this.gridBand3.Caption = "CLASS RANKING";
		this.gridBand3.Columns.Add(this.bandedGridColumn3);
		this.gridBand3.Columns.Add(this.bandedGridColumn4);
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.OptionsBand.AllowHotTrack = false;
		this.gridBand3.OptionsBand.AllowMove = false;
		this.gridBand3.OptionsBand.AllowPress = false;
		this.gridBand3.VisibleIndex = 1;
		this.gridBand3.Width = 155;
		this.bandedGridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridColumn3.AppearanceCell.Options.UseFont = true;
		this.bandedGridColumn3.Caption = "Position";
		this.bandedGridColumn3.FieldName = "Position";
		this.bandedGridColumn3.Name = "bandedGridColumn3";
		this.bandedGridColumn3.Visible = true;
		this.bandedGridColumn3.Width = 77;
		this.bandedGridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridColumn4.AppearanceCell.Options.UseFont = true;
		this.bandedGridColumn4.Caption = "#InClass";
		this.bandedGridColumn4.FieldName = "OutOf";
		this.bandedGridColumn4.Name = "bandedGridColumn4";
		this.bandedGridColumn4.Visible = true;
		this.bandedGridColumn4.Width = 78;
		this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.gridBand2.AppearanceHeader.Options.UseFont = true;
		this.gridBand2.Caption = "STREAM RANKING";
		this.gridBand2.Columns.Add(this.bandedGridColumn1);
		this.gridBand2.Columns.Add(this.bandedGridColumn2);
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.OptionsBand.AllowHotTrack = false;
		this.gridBand2.OptionsBand.AllowMove = false;
		this.gridBand2.OptionsBand.AllowPress = false;
		this.gridBand2.VisibleIndex = 2;
		this.gridBand2.Width = 309;
		this.bandedGridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridColumn1.AppearanceCell.Options.UseFont = true;
		this.bandedGridColumn1.Caption = "Position";
		this.bandedGridColumn1.FieldName = "PositionInStream";
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.Visible = true;
		this.bandedGridColumn1.Width = 160;
		this.bandedGridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridColumn2.AppearanceCell.Options.UseFont = true;
		this.bandedGridColumn2.Caption = "#InStream";
		this.bandedGridColumn2.FieldName = "StudentsInStream";
		this.bandedGridColumn2.Name = "bandedGridColumn2";
		this.bandedGridColumn2.Visible = true;
		this.bandedGridColumn2.Width = 149;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrCustomComments_ALevel";
		base.Size = new System.Drawing.Size(816, 529);
		base.Load += new System.EventHandler(usrCustomComments_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).EndInit();
		base.ResumeLayout(false);
	}
}
