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
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class userCompetancy : XtraUserControl
{
	private string ClassId = string.Empty;

	private string SemesterId = string.Empty;

	private string SubjectId = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private GridControl gridUnits;

	private GridView gridView2;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlGroup layoutControlGroup1;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlGroup layoutControlGroup2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn2;

	private VGridControl vGridControl1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	private EditorRow row;

	private EditorRow row1;

	private EditorRow row2;

	private EditorRow row3;

	private LayoutControlItem layoutControlItem4;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	public userCompetancy(string ClassId, string SemesterId)
	{
		InitializeComponent();
		this.ClassId = ClassId;
		this.SemesterId = SemesterId;
		labelControl1.Text = "Learner Topic Competencies - " + ClassId + ", " + SemesterId;
		LoadTermSubjects();
	}

	private void LoadChapters()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT  SubjectId,'1' AS Chapter,Topic_1 AS Topic,Competence_1 AS Competence FROM tbl_Scores_OL_Report  WHERE ClassId='{1}' AND SemesterId='{2}' AND SubjectId='{0}' GROUP BY SubjectId,Topic_1,Competence_1 UNION ALL SELECT  SubjectId,'2' AS Chapter,Topic_2 AS Topic,Competence_2 AS Competence FROM tbl_Scores_OL_Report WHERE ClassId='{1}' AND SemesterId='{2}' AND TUnits>=2 AND SubjectId='{0}' GROUP BY SubjectId,Topic_1,Topic_2,Competence_1,Competence_2 UNION ALL SELECT  SubjectId,'3' AS Chapter,Topic_2 AS Topic,Competence_3 AS Competence FROM tbl_Scores_OL_Report WHERE ClassId='{1}' AND SemesterId='{2}' AND TUnits>=3 AND SubjectId='{0}' GROUP BY SubjectId,Topic_2,Topic_3,Competence_2,Competence_3 UNION ALL SELECT  SubjectId,'4' AS Chapter,Topic_4 AS Topic,Competence_4 AS Competence FROM tbl_Scores_OL_Report WHERE ClassId='{1}' AND SemesterId='{2}' AND TUnits>=4 AND SubjectId='{0}' GROUP BY SubjectId,Topic_2,Topic_3,Topic_4,Competence_2,Competence_3,Competence_4", SubjectId, ClassId, SemesterId), DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		vGridControl1.DataSource = dataTable.DefaultView;
	}

	private void LoadTermSubjects()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettingsNC   WHERE SemesterId='{SemesterId}' AND ClassId='{ClassId}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		gridUnits.DataSource = dataTable.DefaultView;
	}

	private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (e.FocusedRowHandle > -1)
		{
			SubjectId = gridView2.GetRowCellValue(e.FocusedRowHandle, "SubjectId").ToString();
			layoutControlGroup2.Text = SubjectId;
			LoadChapters();
		}
	}

	private void gridView2_RowClick(object sender, RowClickEventArgs e)
	{
		if (e.RowHandle > -1)
		{
			SubjectId = gridView2.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
			layoutControlGroup2.Text = SubjectId;
		}
	}

	private void UpdateMarks(string col, string values, int compNo)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string empty = string.Empty;
		empty = ((!(col == "Topic")) ? string.Format("UPDATE tbl_Scores_OL_Report SET Competence_{0}=@Competence_{0} WHERE SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", compNo) : string.Format("UPDATE tbl_Scores_OL_Report SET Topic_{0}=@Topic_{0} WHERE SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", compNo));
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = empty,
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (col == "Topic")
		{
			sqlParameter = sqlCommand.Parameters.Add($"Topic_{compNo}", SqlDbType.NVarChar, 100);
			sqlParameter.Value = values;
			sqlParameter.Direction = ParameterDirection.Input;
		}
		else
		{
			sqlParameter = sqlCommand.Parameters.Add($"Competence_{compNo}", SqlDbType.NVarChar, 500);
			sqlParameter.Value = values;
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.Add("SubjectId", SqlDbType.NVarChar, 50);
		sqlParameter.Value = SubjectId;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("ClassId", SqlDbType.NVarChar, 50);
		sqlParameter.Value = ClassId;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("SemesterId", SqlDbType.NVarChar, 50);
		sqlParameter.Value = SemesterId;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
		}
	}

	private void vGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		string values = e.Value.ToString();
		string fieldName = e.Row.Properties.FieldName;
		int compNo = Convert.ToInt32(vGridControl1.GetCellValue(row1, e.RecordIndex).ToString());
		UpdateMarks(fieldName, values, compNo);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.userCompetancy));
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.gridUnits = new DevExpress.XtraGrid.GridControl();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridUnits).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.vGridControl1);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.gridUnits);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(857, 611);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.vGridControl1.Appearance.BandBorder.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl1.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.Caption.Options.UseFont = true;
		this.vGridControl1.Appearance.Caption.Options.UseTextOptions = true;
		this.vGridControl1.Appearance.Caption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.vGridControl1.Appearance.Caption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.vGridControl1.Appearance.Category.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.Category.Options.UseFont = true;
		this.vGridControl1.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridControl1.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.DisabledRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.Empty.Options.UseFont = true;
		this.vGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecord.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridControl1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.HorzLine.Options.UseFont = true;
		this.vGridControl1.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.ModifiedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.PressedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.PressedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridControl1.Appearance.RecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.RecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.RecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedCategory.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRecord.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl1.Location = new System.Drawing.Point(179, 49);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.AutoScaleBands = true;
		this.vGridControl1.RecordWidth = 320;
		this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemMemoEdit1, this.repositoryItemTextEdit1 });
		this.vGridControl1.RowHeaderWidth = 105;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[4] { this.row, this.row1, this.row2, this.row3 });
		this.vGridControl1.Size = new System.Drawing.Size(671, 555);
		this.vGridControl1.TabIndex = 8;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.repositoryItemMemoEdit1.LinesCount = 10;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.row.Name = "row";
		this.row.Properties.Caption = "Subject";
		this.row.Properties.FieldName = "SubjectId";
		this.row.Visible = false;
		this.row1.Name = "row1";
		this.row1.Properties.Caption = "Topic #";
		this.row1.Properties.FieldName = "Chapter";
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "Title";
		this.row2.Properties.FieldName = "Topic";
		this.row2.Properties.RowEdit = this.repositoryItemTextEdit1;
		this.row2.Properties.ToolTip = "Chapter Title";
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Competency";
		this.row3.Properties.FieldName = "Competence";
		this.row3.Properties.RowEdit = this.repositoryItemMemoEdit1;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(849, 19);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 6;
		this.labelControl1.Text = "Learner Topic Competencies";
		this.gridUnits.Location = new System.Drawing.Point(7, 49);
		this.gridUnits.MainView = this.gridView2;
		this.gridUnits.Name = "gridUnits";
		this.gridUnits.Size = new System.Drawing.Size(162, 555);
		this.gridUnits.TabIndex = 5;
		this.gridUnits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView2.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.DetailTip.Options.UseFont = true;
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.FixedLine.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.GroupButton.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.HorzLine.Options.UseFont = true;
		this.gridView2.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.VertLine.Options.UseFont = true;
		this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn3, this.gridColumn2 });
		this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView2.GridControl = this.gridUnits;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView2.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView2_RowClick);
		this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView2_FocusedRowChanged);
		this.gridColumn3.Caption = "Subject";
		this.gridColumn3.FieldName = "SubjectId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 0;
		this.gridColumn2.Caption = "Topics";
		this.gridColumn2.FieldName = "TUnits";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 40;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlGroup1, this.layoutControlItem3, this.layoutControlGroup2 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(857, 611);
		this.Root.TextVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem2 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(172, 584);
		this.layoutControlGroup1.Text = "Registered Subjects";
		this.layoutControlItem2.Control = this.gridUnits;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(166, 559);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.labelControl1;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(853, 23);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlGroup2.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlGroup2.AppearanceGroup.Options.UseFont = true;
		this.layoutControlGroup2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlGroup2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlGroup2.CaptionImageOptions.Image = (System.Drawing.Image)resources.GetObject("layoutControlGroup2.CaptionImageOptions.Image");
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem4 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(172, 23);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup2.Size = new System.Drawing.Size(681, 584);
		this.layoutControlGroup2.Text = " ";
		this.layoutControlItem4.Control = this.vGridControl1;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(675, 559);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "userCompetancy";
		base.Size = new System.Drawing.Size(857, 611);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridUnits).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		base.ResumeLayout(false);
	}
}
