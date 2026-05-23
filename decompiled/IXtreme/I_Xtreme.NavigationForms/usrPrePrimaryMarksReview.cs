using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.NavigationForms;

public class usrPrePrimaryMarksReview : XtraUserControl
{
	private string connection = DataConnection.ConnectToDatabase();

	private DataTable dt;

	private DataTable _dt;

	private DataTable __dt;

	private string Class = string.Empty;

	private string Semester = string.Empty;

	private string StudentNumber = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private GridControl gridControl2;

	private GridView gridView2;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem6;

	private VGridControl vGridControl2;

	private LayoutControlItem layoutControlItem3;

	private GridColumn gridColumn6;

	private LabelControl lblCurrentActions;

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

	private EditorRow rowClassTeacher;

	private EditorRow rowHeadTeacher;

	private GridColumn gridColumn7;

	private GridColumn gridColTotal;

	private GridColumn gridColScore;

	private GridColumn gridColComment;

	private GridColumn gridColPoor;

	private GridColumn gridColGood;

	private GridColumn gridColVeryGood;

	private GridColumn gridColExcellent;

	private GridColumn gridColumnInitial;

	private EditorRow rowRequirements;

	public usrPrePrimaryMarksReview(string _Class, string _Semester)
	{
		InitializeComponent();
		Class = _Class;
		Semester = _Semester;
		LoadStudents();
	}

	private void SavePupilReportComments()
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_GeneralReports_Grading_PrePrimary SET ClassTeacherComment=@ClassTeacherComment,HeadTeacherComment=@HeadTeacherComment,OtherRequirements=@OtherRequirements,promoStatus=@promoStatus WHERE StudentNumber=@StudentNumber AND ClassId=@ClassId AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
			sqlParameter.Value = vGridControl2.GetCellValue(rowClassTeacher, 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
			sqlParameter.Value = vGridControl2.GetCellValue(rowHeadTeacher, 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@OtherRequirements", SqlDbType.VarChar, 100);
			sqlParameter.Value = vGridControl2.GetCellValue(rowRequirements, 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@promoStatus", SqlDbType.VarChar, 50);
			sqlParameter.Value = string.Empty;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = StudentNumber;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
			sqlParameter.Value = Class;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 12);
			sqlParameter.Value = Semester;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadComments()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber='{StudentNumber}' AND SemesterId='{Semester}'", connection);
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
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{Class}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScoreCard");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			gridControl1.DataSource = _dt.DefaultView;
			lblCurrentActions.Text = $"SCORES REVIEW: {Class}, {Semester}";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadReportData()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_PrePrimary WHERE StudentNumber='{StudentNumber}' AND SemesterId='{Semester}'", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ScoreCard");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl2.DataSource = dt.DefaultView;
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
			byte[] array = new byte[0];
			array = (byte[])dataRow["Picture"];
			lblName.Text = dataRow["fullName"].ToString();
			lblStudentNo.Text = dataRow["StudentNumber"].ToString();
			StudentNumber = dataRow["StudentNumber"].ToString();
			using (MemoryStream stream = new MemoryStream(array))
			{
				pictureEdit1.Image = Image.FromStream(stream);
			}
			LoadReportData();
			LoadComments();
		}
	}

	private void vGridControl2_HiddenEditor(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			SavePupilReportComments();
		}
	}

	private void usrPrePrimaryMarksReview_Load(object sender, EventArgs e)
	{
		rowClassTeacher.Properties.Caption = PreprimaryReportDesigner.Label1;
		rowHeadTeacher.Properties.Caption = PreprimaryReportDesigner.Label2;
		if (PreprimaryAssessmentScale.OrdinalScaleInUse)
		{
			gridColComment.Visible = false;
			gridColScore.Visible = false;
			gridColTotal.Visible = false;
			gridColPoor.Visible = true;
			gridColGood.Visible = true;
			gridColVeryGood.Visible = true;
			gridColExcellent.Visible = true;
			string[] assessmentScaleKeys = PreprimaryAssessmentScale.AssessmentScaleKeys;
			switch (assessmentScaleKeys.Length)
			{
			case 3:
				gridColExcellent.Visible = false;
				gridColPoor.Caption = assessmentScaleKeys[0];
				gridColGood.Caption = assessmentScaleKeys[1];
				gridColVeryGood.Caption = assessmentScaleKeys[2];
				break;
			case 4:
				gridColExcellent.Visible = true;
				gridColPoor.Caption = assessmentScaleKeys[0];
				gridColGood.Caption = assessmentScaleKeys[1];
				gridColVeryGood.Caption = assessmentScaleKeys[2];
				gridColExcellent.Caption = assessmentScaleKeys[3];
				break;
			default:
				gridColPoor.Visible = false;
				gridColGood.Visible = false;
				gridColVeryGood.Visible = false;
				gridColExcellent.Visible = false;
				break;
			}
		}
		else
		{
			gridColComment.Visible = true;
			gridColScore.Visible = true;
			gridColTotal.Visible = true;
			gridColPoor.Visible = false;
			gridColGood.Visible = false;
			gridColVeryGood.Visible = false;
			gridColExcellent.Visible = false;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblCurrentActions = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.rowClassTeacher = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowHeadTeacher = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowRequirements = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColTotal = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColScore = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColComment = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColPoor = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColGood = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColVeryGood = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColExcellent = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnInitial = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.lblStudentNo);
		this.layoutControl1.Controls.Add(this.labelControl4);
		this.layoutControl1.Controls.Add(this.lblName);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.lblCurrentActions);
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.vGridControl2);
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
		this.lblStudentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblStudentNo.Location = new System.Drawing.Point(634, 81);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(180, 19);
		this.lblStudentNo.StyleController = this.layoutControl1;
		this.lblStudentNo.TabIndex = 19;
		this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl4.Location = new System.Drawing.Point(634, 64);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(180, 13);
		this.labelControl4.StyleController = this.layoutControl1;
		this.labelControl4.TabIndex = 18;
		this.labelControl4.Text = "Pupil#";
		this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblName.Location = new System.Drawing.Point(634, 41);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(180, 19);
		this.lblName.StyleController = this.layoutControl1;
		this.lblName.TabIndex = 17;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Location = new System.Drawing.Point(634, 24);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(180, 13);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 16;
		this.labelControl2.Text = "Name";
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
		this.labelControl1.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Vertical;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(620, 24);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(10, 503);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 15;
		this.lblCurrentActions.Appearance.Font = new System.Drawing.Font("Tahoma", 11.5f, System.Drawing.FontStyle.Bold);
		this.lblCurrentActions.Location = new System.Drawing.Point(2, 2);
		this.lblCurrentActions.Name = "lblCurrentActions";
		this.lblCurrentActions.Size = new System.Drawing.Size(112, 18);
		this.lblCurrentActions.StyleController = this.layoutControl1;
		this.lblCurrentActions.TabIndex = 14;
		this.lblCurrentActions.Text = "CurrentActions";
		this.pictureEdit1.Location = new System.Drawing.Point(634, 104);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(180, 303);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 13;
		this.vGridControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.vGridControl2.Location = new System.Drawing.Point(118, 429);
		this.vGridControl2.Name = "vGridControl2";
		this.vGridControl2.RecordWidth = 994;
		this.vGridControl2.RowHeaderWidth = 104;
		this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[3] { this.rowClassTeacher, this.rowHeadTeacher, this.rowRequirements });
		this.vGridControl2.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Never;
		this.vGridControl2.Size = new System.Drawing.Size(498, 98);
		this.vGridControl2.TabIndex = 11;
		this.vGridControl2.HiddenEditor += new System.EventHandler(vGridControl2_HiddenEditor);
		this.rowClassTeacher.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rowClassTeacher.Appearance.Options.UseFont = true;
		this.rowClassTeacher.Appearance.Options.UseTextOptions = true;
		this.rowClassTeacher.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowClassTeacher.Height = 30;
		this.rowClassTeacher.Name = "rowClassTeacher";
		this.rowClassTeacher.Properties.Caption = "Class Teacher";
		this.rowClassTeacher.Properties.FieldName = "ClassTeacherComment";
		this.rowClassTeacher.Properties.Value = "";
		this.rowHeadTeacher.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.rowHeadTeacher.Appearance.Options.UseFont = true;
		this.rowHeadTeacher.Appearance.Options.UseTextOptions = true;
		this.rowHeadTeacher.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowHeadTeacher.Height = 30;
		this.rowHeadTeacher.Name = "rowHeadTeacher";
		this.rowHeadTeacher.Properties.Caption = "Head Teacher";
		this.rowHeadTeacher.Properties.FieldName = "HeadTeacherComment";
		this.rowRequirements.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rowRequirements.Appearance.Options.UseFont = true;
		this.rowRequirements.Appearance.Options.UseTextOptions = true;
		this.rowRequirements.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowRequirements.Height = 30;
		this.rowRequirements.Name = "rowRequirements";
		this.rowRequirements.Properties.Caption = " Requirements";
		this.rowRequirements.Properties.FieldName = "OtherRequirements";
		this.gridControl2.Location = new System.Drawing.Point(118, 24);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(498, 379);
		this.gridControl2.TabIndex = 9;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView2.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.DetailTip.Options.UseFont = true;
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FixedLine.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupButton.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
		this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.HorzLine.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.VertLine.Options.UseFont = true;
		this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[9] { this.gridColumn7, this.gridColTotal, this.gridColScore, this.gridColComment, this.gridColPoor, this.gridColGood, this.gridColVeryGood, this.gridColExcellent, this.gridColumnInitial });
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsCustomization.AllowColumnMoving = false;
		this.gridView2.OptionsCustomization.AllowFilter = false;
		this.gridView2.OptionsCustomization.AllowSort = false;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumn7.AppearanceHeader.Options.UseFont = true;
		this.gridColumn7.Caption = "Subject";
		this.gridColumn7.FieldName = "SubjectId";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.OptionsColumn.ReadOnly = true;
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 0;
		this.gridColumn7.Width = 188;
		this.gridColTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColTotal.AppearanceHeader.Options.UseFont = true;
		this.gridColTotal.Caption = "Total";
		this.gridColTotal.FieldName = "Total";
		this.gridColTotal.Name = "gridColTotal";
		this.gridColTotal.Visible = true;
		this.gridColTotal.VisibleIndex = 1;
		this.gridColTotal.Width = 101;
		this.gridColScore.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColScore.AppearanceHeader.Options.UseFont = true;
		this.gridColScore.Caption = "Score";
		this.gridColScore.FieldName = "Score";
		this.gridColScore.Name = "gridColScore";
		this.gridColScore.Visible = true;
		this.gridColScore.VisibleIndex = 2;
		this.gridColScore.Width = 101;
		this.gridColComment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColComment.AppearanceHeader.Options.UseFont = true;
		this.gridColComment.Caption = "Comment";
		this.gridColComment.FieldName = "StringComment";
		this.gridColComment.Name = "gridColComment";
		this.gridColComment.Visible = true;
		this.gridColComment.VisibleIndex = 3;
		this.gridColComment.Width = 284;
		this.gridColPoor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColPoor.AppearanceHeader.Options.UseFont = true;
		this.gridColPoor.Caption = "Scale1";
		this.gridColPoor.FieldName = "Scale1";
		this.gridColPoor.Name = "gridColPoor";
		this.gridColPoor.Visible = true;
		this.gridColPoor.VisibleIndex = 4;
		this.gridColPoor.Width = 101;
		this.gridColGood.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColGood.AppearanceHeader.Options.UseFont = true;
		this.gridColGood.Caption = "Scale2";
		this.gridColGood.FieldName = "Scale2";
		this.gridColGood.Name = "gridColGood";
		this.gridColGood.Visible = true;
		this.gridColGood.VisibleIndex = 5;
		this.gridColGood.Width = 101;
		this.gridColVeryGood.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColVeryGood.AppearanceHeader.Options.UseFont = true;
		this.gridColVeryGood.Caption = "Scale3";
		this.gridColVeryGood.FieldName = "Scale3";
		this.gridColVeryGood.Name = "gridColVeryGood";
		this.gridColVeryGood.Visible = true;
		this.gridColVeryGood.VisibleIndex = 6;
		this.gridColVeryGood.Width = 82;
		this.gridColExcellent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColExcellent.AppearanceHeader.Options.UseFont = true;
		this.gridColExcellent.Caption = "Scale4";
		this.gridColExcellent.FieldName = "Scale4";
		this.gridColExcellent.Name = "gridColExcellent";
		this.gridColExcellent.Visible = true;
		this.gridColExcellent.VisibleIndex = 7;
		this.gridColExcellent.Width = 77;
		this.gridColumnInitial.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridColumnInitial.AppearanceHeader.Options.UseFont = true;
		this.gridColumnInitial.Caption = "Initials";
		this.gridColumnInitial.FieldName = "Initial";
		this.gridColumnInitial.Name = "gridColumnInitial";
		this.gridColumnInitial.Width = 59;
		this.gridControl1.Location = new System.Drawing.Point(2, 24);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(112, 503);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
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
			this.layoutControlItem1, this.layoutControlItem6, this.layoutControlItem3, this.layoutControlItem2, this.layoutControlItem5, this.emptySpaceItem1, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10,
			this.layoutControlItem11
		});
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(816, 529);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 22);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(116, 507);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem6.Control = this.gridControl2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(116, 22);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(502, 383);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.vGridControl2;
		this.layoutControlItem3.CustomizationFormText = "Report Comments";
		this.layoutControlItem3.Location = new System.Drawing.Point(116, 405);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(502, 124);
		this.layoutControlItem3.Text = "Report Comments";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(147, 19);
		this.layoutControlItem2.Control = this.pictureEdit1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(632, 102);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(184, 307);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem5.Control = this.lblCurrentActions;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(816, 22);
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
		this.layoutControlItem7.Location = new System.Drawing.Point(618, 22);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(14, 507);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.Control = this.labelControl2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(632, 22);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(184, 17);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.lblName;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(632, 39);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(184, 23);
		this.layoutControlItem9.Text = "layoutControlItem9";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextToControlDistance = 0;
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem10.Control = this.labelControl4;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(632, 62);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(184, 17);
		this.layoutControlItem10.Text = "layoutControlItem10";
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextToControlDistance = 0;
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.lblStudentNo;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(632, 79);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(184, 23);
		this.layoutControlItem11.Text = "layoutControlItem11";
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextToControlDistance = 0;
		this.layoutControlItem11.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrPrePrimaryMarksReview";
		base.Size = new System.Drawing.Size(816, 529);
		base.Load += new System.EventHandler(usrPrePrimaryMarksReview_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		base.ResumeLayout(false);
	}
}
