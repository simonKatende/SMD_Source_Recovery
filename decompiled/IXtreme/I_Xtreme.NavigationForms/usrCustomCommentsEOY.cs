using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class usrCustomCommentsEOY : XtraUserControl
{
	private string connection = DataConnection.ConnectToDatabase();

	private DataTable dt;

	private DataTable _dt;

	private DataTable __dt;

	private string _Class;

	private string _Stream;

	private string _SemesterId;

	private string studentNo = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gridControl2;

	private GridView gridView2;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem6;

	private GridColumn gridColumn6;

	private PictureEdit pictureEdit1;

	private LayoutControlItem layoutControlItem2;

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

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private GridColumn gridColumn21;

	private GridColumn gridColumn17;

	private GridColumn gridColumn18;

	private LabelControl labelControl3;

	private LayoutControlItem layoutControlItem4;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	public usrCustomCommentsEOY(string _Class, string _Stream, string _SemesterId)
	{
		InitializeComponent();
		this._Class = _Class;
		this._SemesterId = _SemesterId;
		this._Stream = _Stream;
		LoadStudents();
		labelControl3.Text = "Student Report Comments - " + _SemesterId;
	}

	private void LoadStudentPerformanceSheet()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_OL_Report WHERE ClassId='{_Class}' AND StudentNumber='{studentNo}' AND SemesterId='{_SemesterId}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScoreCard");
			__dt = new DataTable();
			__dt = dataSet.Tables[0];
			gridControl2.DataSource = __dt.DefaultView;
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
			string selectCommandText = $"SELECT  s.StudentNumber,s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId FROM    tbl_Stud AS s INNER JOIN   tbl_Scores_OL_Report AS r ON s.StudentNumber = r.StudentNumber AND s.ClassId = r.ClassId GROUP BY s.StudentNumber, s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId HAVING (s.StreamId = '{_Stream}') AND (r.SemesterId = '{_SemesterId}') AND (s.ClassId = '{_Class}') ORDER BY s.fullName";
			if (string.IsNullOrEmpty(_Stream))
			{
				selectCommandText = $"SELECT  s.StudentNumber,s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId FROM    tbl_Stud AS s INNER JOIN   tbl_Scores_OL_Report AS r ON s.StudentNumber = r.StudentNumber AND s.ClassId = r.ClassId GROUP BY s.StudentNumber, s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId HAVING (r.SemesterId = '{_SemesterId}') AND (s.ClassId = '{_Class}') ORDER BY s.fullName";
			}
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connection);
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

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = _dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			lblName.Text = dataRow["fullName"].ToString();
			lblStudentNo.Text = dataRow["StudentNumber"].ToString();
			studentNo = dataRow["StudentNumber"].ToString();
			LoadStudentPerformanceSheet();
		}
	}

	private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "TeacherRemarks")
		{
			string value = gridView2.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_Scores_OL_Report SET TeacherRemarks=@TeacherRemarks, WriteComment=1 WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId AND SubjectId=@SubjectId",
				CommandType = CommandType.Text
			};
			sqlCommand.Parameters.Add(new SqlParameter("TeacherRemarks", e.Value));
			sqlCommand.Parameters.Add(new SqlParameter("@StudentNumber ", studentNo));
			sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", _SemesterId));
			sqlCommand.Parameters.Add(new SqlParameter("@ClassId", _Class));
			sqlCommand.Parameters.Add(new SqlParameter("@SubjectId", value));
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
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
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl3);
		this.layoutControl1.Controls.Add(this.lblStudentNo);
		this.layoutControl1.Controls.Add(this.labelControl4);
		this.layoutControl1.Controls.Add(this.lblName);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.gridControl2);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(831, 0, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(816, 529);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.Appearance.Options.UseTextOptions = true;
		this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.Location = new System.Drawing.Point(2, 2);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(812, 19);
		this.labelControl3.StyleController = this.layoutControl1;
		this.labelControl3.TabIndex = 20;
		this.labelControl3.Text = "labelControl3";
		this.lblStudentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentNo.Appearance.Options.UseFont = true;
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
		this.lblName.Appearance.Options.UseFont = true;
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
		this.labelControl1.Location = new System.Drawing.Point(620, 25);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(10, 1);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 15;
		this.pictureEdit1.Location = new System.Drawing.Point(634, 105);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(180, 366);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 13;
		this.gridControl2.Location = new System.Drawing.Point(118, 25);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemTextEdit1 });
		this.gridControl2.Size = new System.Drawing.Size(498, 502);
		this.gridControl2.TabIndex = 9;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView2.Appearance.DetailTip.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.DetailTip.Options.UseFont = true;
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FixedLine.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupButton.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HorzLine.Options.UseFont = true;
		this.gridView2.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.RowSeparator.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.VertLine.Options.UseFont = true;
		this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Cascadia Mono", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView2.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView2.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView2.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView2.AppearancePrint.Row.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[10] { this.gridColumn7, this.gridColumn8, this.gridColumn9, this.gridColumn10, this.gridColumn11, this.gridColumn21, this.gridColumn17, this.gridColumn18, this.gridColumn1, this.gridColumn2 });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsPrint.EnableAppearanceOddRow = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView2_CellValueChanged);
		this.gridColumn7.Caption = "Subject";
		this.gridColumn7.FieldName = "SubjectId";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.OptionsColumn.AllowEdit = false;
		this.gridColumn7.OptionsColumn.ReadOnly = true;
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 0;
		this.gridColumn7.Width = 85;
		this.gridColumn8.Caption = "U1";
		this.gridColumn8.FieldName = "U1";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.OptionsColumn.AllowEdit = false;
		this.gridColumn8.OptionsColumn.ReadOnly = true;
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 1;
		this.gridColumn8.Width = 28;
		this.gridColumn9.Caption = "U2";
		this.gridColumn9.FieldName = "U2";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.OptionsColumn.AllowEdit = false;
		this.gridColumn9.OptionsColumn.ReadOnly = true;
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 2;
		this.gridColumn9.Width = 28;
		this.gridColumn10.Caption = "U3";
		this.gridColumn10.FieldName = "U3";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.OptionsColumn.AllowEdit = false;
		this.gridColumn10.OptionsColumn.ReadOnly = true;
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 3;
		this.gridColumn10.Width = 28;
		this.gridColumn11.Caption = "U4";
		this.gridColumn11.FieldName = "U4";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.OptionsColumn.AllowEdit = false;
		this.gridColumn11.OptionsColumn.ReadOnly = true;
		this.gridColumn11.Visible = true;
		this.gridColumn11.VisibleIndex = 4;
		this.gridColumn11.Width = 28;
		this.gridColumn21.Caption = "AI/20%";
		this.gridColumn21.FieldName = "OutOfTwenty";
		this.gridColumn21.Name = "gridColumn21";
		this.gridColumn21.OptionsColumn.AllowEdit = false;
		this.gridColumn21.OptionsColumn.ReadOnly = true;
		this.gridColumn21.Visible = true;
		this.gridColumn21.VisibleIndex = 5;
		this.gridColumn21.Width = 28;
		this.gridColumn17.Caption = "EOT/80%";
		this.gridColumn17.FieldName = "ETA80";
		this.gridColumn17.Name = "gridColumn17";
		this.gridColumn17.OptionsColumn.AllowEdit = false;
		this.gridColumn17.OptionsColumn.ReadOnly = true;
		this.gridColumn17.Visible = true;
		this.gridColumn17.VisibleIndex = 6;
		this.gridColumn17.Width = 28;
		this.gridColumn18.Caption = "Score";
		this.gridColumn18.FieldName = "ETAv";
		this.gridColumn18.Name = "gridColumn18";
		this.gridColumn18.OptionsColumn.AllowEdit = false;
		this.gridColumn18.OptionsColumn.ReadOnly = true;
		this.gridColumn18.Visible = true;
		this.gridColumn18.VisibleIndex = 7;
		this.gridColumn18.Width = 28;
		this.gridColumn1.Caption = "Grade";
		this.gridColumn1.FieldName = "P5";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 8;
		this.gridColumn1.Width = 28;
		this.gridColumn2.Caption = "Facilitaor Remarks";
		this.gridColumn2.ColumnEdit = this.repositoryItemTextEdit1;
		this.gridColumn2.FieldName = "TeacherRemarks";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 9;
		this.gridColumn2.Width = 187;
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
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[10] { this.layoutControlItem1, this.layoutControlItem6, this.layoutControlItem2, this.emptySpaceItem1, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10, this.layoutControlItem11, this.layoutControlItem4 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(816, 529);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(116, 506);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem6.Control = this.gridControl2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(116, 23);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(502, 506);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem2.Control = this.pictureEdit1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(632, 103);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(184, 370);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(632, 473);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(184, 56);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.Control = this.labelControl1;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(618, 23);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(14, 506);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.Control = this.labelControl2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(632, 23);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(184, 17);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.lblName;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(632, 40);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(184, 23);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem10.Control = this.labelControl4;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(632, 63);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(184, 17);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.lblStudentNo;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(632, 80);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(184, 23);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem4.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.layoutControlItem4.Control = this.labelControl3;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(816, 23);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.MaxLength = 200;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrCustomCommentsEOY";
		base.Size = new System.Drawing.Size(816, 529);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		base.ResumeLayout(false);
	}
}
