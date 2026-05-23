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

public class usrPrePrimaryEnterMarks : XtraUserControl
{
	private string StudentClass = string.Empty;

	private string Semester = string.Empty;

	private string StudentNo = string.Empty;

	private IContainer components = null;

	private GridControl dgMain;

	private LayoutControl layoutControl1;

	private LabelControl lblCurrentActions;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private RepositoryItemComboBox repositoryItemComboBox1;

	private VGridControl vGridControl1;

	private LayoutControlItem layoutControlItem3;

	private GridView gridView1;

	private GridColumn bandedGridColumn1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private EditorRow rowNumeracy;

	private EditorRow rowVocabulary;

	private EditorRow rowGeneralKnowledge;

	private EditorRow rowPhysicalEducation;

	private EditorRow rowWriting;

	private EditorRow rowGodsCreation;

	private EditorRow rowLifeSkills;

	private EditorRow rowStoryTelling;

	private EditorRow rowRhymesMusic;

	private EditorRow rowPanctuality;

	private EditorRow rowSmartness;

	private EditorRow rowHeadteacherComment;

	private EditorRow rowClassteacherComment;

	private EditorRow rowReading;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit2;

	private RepositoryItemMemoEdit repositoryItemMemoEdit3;

	private RepositoryItemMemoEdit repositoryItemMemoEdit4;

	private RepositoryItemMemoEdit repositoryItemMemoEdit5;

	private RepositoryItemMemoEdit repositoryItemMemoEdit7;

	private RepositoryItemMemoEdit repositoryItemMemoEdit8;

	private RepositoryItemMemoEdit repositoryItemMemoEdit9;

	private RepositoryItemMemoEdit repositoryItemMemoEdit10;

	private RepositoryItemMemoEdit repositoryItemMemoEdit11;

	private RepositoryItemMemoEdit repositoryItemMemoEdit12;

	private RepositoryItemMemoEdit repositoryItemMemoEdit13;

	private RepositoryItemMemoEdit repositoryItemMemoEdit14;

	private RepositoryItemMemoEdit repositoryItemMemoEdit15;

	private GridColumn gridColumn6;

	private RepositoryItemMemoEdit repositoryItemMemoEdit16;

	private EditorRow rowSwimming;

	public usrPrePrimaryEnterMarks(string _Class, string _Semester)
	{
		InitializeComponent();
		StudentClass = _Class;
		Semester = _Semester;
	}

	private void LoadPupils()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{StudentClass}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		dgMain.DataSource = dataTable.DefaultView;
	}

	private void LoadCommentsSheet(string _Class, string Term, string StudentNo)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_PrePrimary WHERE ClassId='{_Class}' AND SemesterId='{Term}' AND StudentNumber='{StudentNo}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		vGridControl1.DataSource = dataTable.DefaultView;
	}

	private void usrPrePrimaryEnterMarks_Load(object sender, EventArgs e)
	{
		LoadPupils();
	}

	private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1)
		{
			StudentNo = gridView1.GetRowCellValue(e.FocusedRowHandle, "StudentNumber").ToString();
			LoadCommentsSheet(StudentClass, Semester, StudentNo);
		}
	}

	private void vGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Row.Properties.FieldName;
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_PrePrimary SET {0}=@{0} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId", fieldName),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", StudentNo);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", Semester);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue($"@{fieldName}", e.Value.ToString());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void vGridControl1_HiddenEditor(object sender, EventArgs e)
	{
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
		this.dgMain = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit12 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit13 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit14 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit15 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit16 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.rowNumeracy = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowReading = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowVocabulary = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowGeneralKnowledge = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowPhysicalEducation = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowSwimming = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowWriting = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowGodsCreation = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowLifeSkills = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowStoryTelling = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowRhymesMusic = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowPanctuality = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowSmartness = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowClassteacherComment = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowHeadteacherComment = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.lblCurrentActions = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.dgMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemComboBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.dgMain.Location = new System.Drawing.Point(4, 26);
		this.dgMain.MainView = this.gridView1;
		this.dgMain.Name = "dgMain";
		this.dgMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemComboBox1 });
		this.dgMain.Size = new System.Drawing.Size(315, 458);
		this.dgMain.TabIndex = 0;
		this.dgMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7] { this.bandedGridColumn1, this.gridColumn1, this.gridColumn6, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5 });
		this.gridView1.GridControl = this.dgMain;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsCustomization.AllowSort = false;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.RowHeight = 27;
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.bandedGridColumn1.Caption = "---";
		this.bandedGridColumn1.FieldName = "Picture";
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.Width = 23;
		this.gridColumn1.Caption = "Name";
		this.gridColumn1.FieldName = "fullName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.OptionsColumn.ReadOnly = true;
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 155;
		this.gridColumn6.Caption = "Student ID";
		this.gridColumn6.FieldName = "StudentID";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 1;
		this.gridColumn6.Width = 63;
		this.gridColumn2.Caption = "Pupils#";
		this.gridColumn2.FieldName = "StudentNumber";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.OptionsColumn.ReadOnly = true;
		this.gridColumn2.Width = 135;
		this.gridColumn3.Caption = "Stream";
		this.gridColumn3.FieldName = "StreamId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.OptionsColumn.ReadOnly = true;
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 40;
		this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn4.Caption = "Sex";
		this.gridColumn4.FieldName = "Sex";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.OptionsColumn.ReadOnly = true;
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn4.Width = 20;
		this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn5.Caption = "DB";
		this.gridColumn5.FieldName = "StudyStatus";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.OptionsColumn.ReadOnly = true;
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 4;
		this.gridColumn5.Width = 20;
		this.repositoryItemComboBox1.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11f);
		this.repositoryItemComboBox1.AppearanceDropDown.Options.UseFont = true;
		this.repositoryItemComboBox1.AutoHeight = false;
		this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemComboBox1.Items.AddRange(new object[5] { "A*", "A", "B", "C", "D" });
		this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
		this.layoutControl1.Controls.Add(this.vGridControl1);
		this.layoutControl1.Controls.Add(this.lblCurrentActions);
		this.layoutControl1.Controls.Add(this.dgMain);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(854, 488);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.vGridControl1.ActiveFilterEnabled = false;
		this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridControl1.Location = new System.Drawing.Point(323, 4);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsFilter.AllowFilter = false;
		this.vGridControl1.OptionsFilter.AllowFilterEditor = false;
		this.vGridControl1.OptionsFilter.AllowMRUFilterList = false;
		this.vGridControl1.RecordWidth = 152;
		this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[15]
		{
			this.repositoryItemMemoEdit1, this.repositoryItemMemoEdit2, this.repositoryItemMemoEdit3, this.repositoryItemMemoEdit4, this.repositoryItemMemoEdit5, this.repositoryItemMemoEdit7, this.repositoryItemMemoEdit8, this.repositoryItemMemoEdit9, this.repositoryItemMemoEdit10, this.repositoryItemMemoEdit11,
			this.repositoryItemMemoEdit12, this.repositoryItemMemoEdit13, this.repositoryItemMemoEdit14, this.repositoryItemMemoEdit15, this.repositoryItemMemoEdit16
		});
		this.vGridControl1.RowHeaderWidth = 48;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[15]
		{
			this.rowNumeracy, this.rowReading, this.rowVocabulary, this.rowGeneralKnowledge, this.rowPhysicalEducation, this.rowSwimming, this.rowWriting, this.rowGodsCreation, this.rowLifeSkills, this.rowStoryTelling,
			this.rowRhymesMusic, this.rowPanctuality, this.rowSmartness, this.rowClassteacherComment, this.rowHeadteacherComment
		});
		this.vGridControl1.Size = new System.Drawing.Size(527, 480);
		this.vGridControl1.TabIndex = 5;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.vGridControl1.HiddenEditor += new System.EventHandler(vGridControl1_HiddenEditor);
		this.repositoryItemMemoEdit1.LinesCount = 5;
		this.repositoryItemMemoEdit1.MaxLength = 100;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.repositoryItemMemoEdit1.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit2.LinesCount = 5;
		this.repositoryItemMemoEdit2.MaxLength = 100;
		this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
		this.repositoryItemMemoEdit2.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit3.LinesCount = 5;
		this.repositoryItemMemoEdit3.MaxLength = 100;
		this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
		this.repositoryItemMemoEdit3.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit4.LinesCount = 5;
		this.repositoryItemMemoEdit4.MaxLength = 100;
		this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
		this.repositoryItemMemoEdit4.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit5.LinesCount = 5;
		this.repositoryItemMemoEdit5.MaxLength = 100;
		this.repositoryItemMemoEdit5.Name = "repositoryItemMemoEdit5";
		this.repositoryItemMemoEdit5.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit7.LinesCount = 5;
		this.repositoryItemMemoEdit7.MaxLength = 100;
		this.repositoryItemMemoEdit7.Name = "repositoryItemMemoEdit7";
		this.repositoryItemMemoEdit7.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit8.LinesCount = 5;
		this.repositoryItemMemoEdit8.MaxLength = 100;
		this.repositoryItemMemoEdit8.Name = "repositoryItemMemoEdit8";
		this.repositoryItemMemoEdit8.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit9.LinesCount = 5;
		this.repositoryItemMemoEdit9.MaxLength = 100;
		this.repositoryItemMemoEdit9.Name = "repositoryItemMemoEdit9";
		this.repositoryItemMemoEdit9.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit10.LinesCount = 5;
		this.repositoryItemMemoEdit10.MaxLength = 100;
		this.repositoryItemMemoEdit10.Name = "repositoryItemMemoEdit10";
		this.repositoryItemMemoEdit10.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit11.LinesCount = 5;
		this.repositoryItemMemoEdit11.MaxLength = 100;
		this.repositoryItemMemoEdit11.Name = "repositoryItemMemoEdit11";
		this.repositoryItemMemoEdit11.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit12.LinesCount = 5;
		this.repositoryItemMemoEdit12.MaxLength = 100;
		this.repositoryItemMemoEdit12.Name = "repositoryItemMemoEdit12";
		this.repositoryItemMemoEdit12.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit13.LinesCount = 5;
		this.repositoryItemMemoEdit13.MaxLength = 100;
		this.repositoryItemMemoEdit13.Name = "repositoryItemMemoEdit13";
		this.repositoryItemMemoEdit13.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit14.LinesCount = 5;
		this.repositoryItemMemoEdit14.MaxLength = 100;
		this.repositoryItemMemoEdit14.Name = "repositoryItemMemoEdit14";
		this.repositoryItemMemoEdit14.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit15.LinesCount = 5;
		this.repositoryItemMemoEdit15.MaxLength = 100;
		this.repositoryItemMemoEdit15.Name = "repositoryItemMemoEdit15";
		this.repositoryItemMemoEdit15.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.repositoryItemMemoEdit16.LinesCount = 5;
		this.repositoryItemMemoEdit16.MaxLength = 100;
		this.repositoryItemMemoEdit16.Name = "repositoryItemMemoEdit16";
		this.rowNumeracy.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowNumeracy.Name = "rowNumeracy";
		this.rowNumeracy.Properties.Caption = "Numeracy";
		this.rowNumeracy.Properties.FieldName = "Numeracy";
		this.rowNumeracy.Properties.RowEdit = this.repositoryItemMemoEdit1;
		this.rowReading.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowReading.Name = "rowReading";
		this.rowReading.Properties.Caption = "Reading";
		this.rowReading.Properties.FieldName = "Reading";
		this.rowReading.Properties.RowEdit = this.repositoryItemMemoEdit15;
		this.rowVocabulary.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowVocabulary.Name = "rowVocabulary";
		this.rowVocabulary.Properties.Caption = "Vocabulary";
		this.rowVocabulary.Properties.FieldName = "Vocabulary";
		this.rowVocabulary.Properties.RowEdit = this.repositoryItemMemoEdit2;
		this.rowGeneralKnowledge.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowGeneralKnowledge.Name = "rowGeneralKnowledge";
		this.rowGeneralKnowledge.Properties.Caption = "General Knowledge";
		this.rowGeneralKnowledge.Properties.FieldName = "GeneralKnowledge";
		this.rowGeneralKnowledge.Properties.RowEdit = this.repositoryItemMemoEdit3;
		this.rowPhysicalEducation.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowPhysicalEducation.Name = "rowPhysicalEducation";
		this.rowPhysicalEducation.Properties.Caption = "Physical Education";
		this.rowPhysicalEducation.Properties.FieldName = "PhysicalEducation";
		this.rowPhysicalEducation.Properties.RowEdit = this.repositoryItemMemoEdit4;
		this.rowSwimming.Name = "rowSwimming";
		this.rowSwimming.Properties.Caption = "Swimming";
		this.rowSwimming.Properties.FieldName = "Swimming";
		this.rowSwimming.Properties.RowEdit = this.repositoryItemMemoEdit16;
		this.rowWriting.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowWriting.Name = "rowWriting";
		this.rowWriting.Properties.Caption = "Writing";
		this.rowWriting.Properties.FieldName = "Writing";
		this.rowWriting.Properties.RowEdit = this.repositoryItemMemoEdit5;
		this.rowGodsCreation.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowGodsCreation.Name = "rowGodsCreation";
		this.rowGodsCreation.Properties.Caption = "Gods Creation";
		this.rowGodsCreation.Properties.FieldName = "GodsCreation";
		this.rowGodsCreation.Properties.RowEdit = this.repositoryItemMemoEdit7;
		this.rowLifeSkills.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowLifeSkills.Name = "rowLifeSkills";
		this.rowLifeSkills.Properties.Caption = "Life Skills";
		this.rowLifeSkills.Properties.FieldName = "LifeSkills";
		this.rowLifeSkills.Properties.RowEdit = this.repositoryItemMemoEdit8;
		this.rowStoryTelling.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowStoryTelling.Name = "rowStoryTelling";
		this.rowStoryTelling.Properties.Caption = "Story Telling";
		this.rowStoryTelling.Properties.FieldName = "StoryTelling";
		this.rowStoryTelling.Properties.RowEdit = this.repositoryItemMemoEdit9;
		this.rowRhymesMusic.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowRhymesMusic.Name = "rowRhymesMusic";
		this.rowRhymesMusic.Properties.Caption = "Rhymes/Music";
		this.rowRhymesMusic.Properties.FieldName = "RhymesMusic";
		this.rowRhymesMusic.Properties.RowEdit = this.repositoryItemMemoEdit10;
		this.rowPanctuality.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowPanctuality.Name = "rowPanctuality";
		this.rowPanctuality.Properties.Caption = "Panctuality";
		this.rowPanctuality.Properties.FieldName = "Panctuality";
		this.rowPanctuality.Properties.RowEdit = this.repositoryItemMemoEdit11;
		this.rowSmartness.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowSmartness.Name = "rowSmartness";
		this.rowSmartness.Properties.Caption = "Smartness";
		this.rowSmartness.Properties.FieldName = "Smartness";
		this.rowSmartness.Properties.RowEdit = this.repositoryItemMemoEdit12;
		this.rowClassteacherComment.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowClassteacherComment.Name = "rowClassteacherComment";
		this.rowClassteacherComment.Properties.Caption = "Classteacher Comment";
		this.rowClassteacherComment.Properties.FieldName = "ClassteacherComment";
		this.rowClassteacherComment.Properties.RowEdit = this.repositoryItemMemoEdit14;
		this.rowHeadteacherComment.AllowCollapse = DevExpress.Utils.DefaultBoolean.False;
		this.rowHeadteacherComment.Name = "rowHeadteacherComment";
		this.rowHeadteacherComment.Properties.Caption = "Headteacher Comment";
		this.rowHeadteacherComment.Properties.FieldName = "HeadteacherComment";
		this.rowHeadteacherComment.Properties.RowEdit = this.repositoryItemMemoEdit13;
		this.lblCurrentActions.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCurrentActions.Appearance.Options.UseFont = true;
		this.lblCurrentActions.Location = new System.Drawing.Point(4, 4);
		this.lblCurrentActions.Name = "lblCurrentActions";
		this.lblCurrentActions.Size = new System.Drawing.Size(315, 18);
		this.lblCurrentActions.StyleController = this.layoutControl1;
		this.lblCurrentActions.TabIndex = 4;
		this.lblCurrentActions.Text = "Select Pupil";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(854, 488);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.dgMain;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 22);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(319, 462);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.vGridControl1;
		this.layoutControlItem3.Location = new System.Drawing.Point(319, 0);
		this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 24);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(531, 484);
		this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem2.Control = this.lblCurrentActions;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.MinSize = new System.Drawing.Size(123, 22);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(319, 22);
		this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrPrePrimaryEnterMarks";
		base.Size = new System.Drawing.Size(854, 488);
		base.Load += new System.EventHandler(usrPrePrimaryEnterMarks_Load);
		((System.ComponentModel.ISupportInitialize)this.dgMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemComboBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
