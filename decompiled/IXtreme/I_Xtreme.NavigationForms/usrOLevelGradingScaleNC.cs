using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class usrOLevelGradingScaleNC : XtraUserControl
{
	private DataTable dataTableOLDivisions;

	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private int Id = 0;

	private IContainer components = null;

	private MyGridControl dgOLevelGrades;

	private MyGridView gridViewOLevelGrades;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private LabelControl labelControl16;

	private LayoutControlItem layoutControlItem3;

	private VGridControl vGridControl1;

	private LayoutControlItem layoutControlItem2;

	private EditorRow row;

	private EditorRow row1;

	private EditorRow row2;

	private EditorRow row3;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit2;

	private RepositoryItemMemoEdit repositoryItemMemoEdit3;

	private RepositoryItemMemoEdit repositoryItemMemoEdit4;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	public usrOLevelGradingScaleNC()
	{
		InitializeComponent();
	}

	private void LoadOLevelGrades()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNC", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "myScales");
			dataTableOLDivisions = new DataTable();
			dataTableOLDivisions = dataSet.Tables[0];
			dgOLevelGrades.DataSource = dataTableOLDivisions.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadSelectedScaleValues()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNC WHERE Id=" + Id, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GradingScale");
			vGridControl1.DataSource = dataSet.Tables[0].DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void gridViewOLevelGrades_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gridViewOLevelGrades.FocusedRowHandle > -1)
		{
			DataRow dataRow = dataTableOLDivisions.Rows[e.FocusedRowHandle];
			Id = Convert.ToInt32(dataRow["Id"].ToString());
			LoadSelectedScaleValues();
		}
	}

	private void usrOLevelGradingScale2_Load(object sender, EventArgs e)
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			labelControl16.Text = "Pupils' Report Remarks";
		}
		LoadOLevelGrades();
	}

	private void vGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		try
		{
			string fieldName = e.Row.Properties.FieldName;
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("UPDATE OLevelAutoCommentsNC SET {0}=@{0} WHERE Id='{1}'", fieldName, Id),
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 2000);
			sqlParameter.Value = e.Value.ToString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void gridViewOLevelGrades_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridViewOLevelGrades.FocusedRowHandle > -1)
		{
			DataRow dataRow = dataTableOLDivisions.Rows[e.RowHandle];
			Id = Convert.ToInt32(dataRow["Id"].ToString());
			LoadSelectedScaleValues();
		}
	}

	private void vGridControl1_Click(object sender, EventArgs e)
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
		this.dgOLevelGrades = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewOLevelGrades = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.dgOLevelGrades.Location = new System.Drawing.Point(3, 26);
		this.dgOLevelGrades.MainView = this.gridViewOLevelGrades;
		this.dgOLevelGrades.Name = "dgOLevelGrades";
		this.dgOLevelGrades.Size = new System.Drawing.Size(258, 505);
		this.dgOLevelGrades.TabIndex = 0;
		this.dgOLevelGrades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewOLevelGrades });
		this.gridViewOLevelGrades.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.DetailTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.DetailTip.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.Empty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.Empty.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.EvenRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.EvenRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FilterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FixedLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FixedLine.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.FocusedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.GroupButton.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.GroupFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.GroupPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.GroupPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.GroupRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.HorzLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.HorzLine.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.NoSearchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.NoSearchResults.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.OddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.OddRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.Preview.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.Row.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.RowSeparator.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.RowSeparator.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.SelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.TopNewRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.VertLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.VertLine.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.ViewCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.ViewCaption.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.Lines.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.Lines.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.OddRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.Preview.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.Preview.Options.UseFont = true;
		this.gridViewOLevelGrades.AppearancePrint.Row.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.AppearancePrint.Row.Options.UseFont = true;
		this.gridViewOLevelGrades.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5 });
		this.gridViewOLevelGrades.DetailHeight = 239;
		this.gridViewOLevelGrades.GridControl = this.dgOLevelGrades;
		this.gridViewOLevelGrades.Name = "gridViewOLevelGrades";
		this.gridViewOLevelGrades.OptionsBehavior.Editable = false;
		this.gridViewOLevelGrades.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewOLevelGrades.OptionsCustomization.AllowGroup = false;
		this.gridViewOLevelGrades.OptionsCustomization.AllowSort = false;
		this.gridViewOLevelGrades.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridViewOLevelGrades.OptionsPrint.EnableAppearanceOddRow = true;
		this.gridViewOLevelGrades.OptionsView.ShowGroupPanel = false;
		this.gridViewOLevelGrades.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewOLevelGrades.OptionsView.ShowIndicator = false;
		this.gridViewOLevelGrades.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridViewOLevelGrades_RowClick);
		this.gridViewOLevelGrades.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewOLevelGrades_FocusedRowChanged);
		this.gridColumn1.Caption = "Division";
		this.gridColumn1.FieldName = "Grade";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Start";
		this.gridColumn2.FieldName = "D3";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 50;
		this.gridColumn3.Caption = "End";
		this.gridColumn3.FieldName = "E3";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 50;
		this.gridColumn4.Caption = "Start - 100";
		this.gridColumn4.FieldName = "D100";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn5.Caption = "End - 100";
		this.gridColumn5.FieldName = "E100";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.layoutControl1.Controls.Add(this.vGridControl1);
		this.layoutControl1.Controls.Add(this.labelControl16);
		this.layoutControl1.Controls.Add(this.dgOLevelGrades);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(795, 534);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.vGridControl1.Appearance.BandBorder.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl1.Appearance.Caption.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.Caption.Options.UseFont = true;
		this.vGridControl1.Appearance.Category.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.Category.Options.UseFont = true;
		this.vGridControl1.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridControl1.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.DisabledRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.Empty.Options.UseFont = true;
		this.vGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Azure;
		this.vGridControl1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
		this.vGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.vGridControl1.Appearance.FocusedCell.Options.UseBorderColor = true;
		this.vGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecord.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridControl1.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.HorzLine.Options.UseFont = true;
		this.vGridControl1.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.ModifiedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.PressedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.PressedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridControl1.Appearance.RecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.RecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.RecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedCategory.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRecord.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl1.BandsInterval = 1;
		this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridControl1.Location = new System.Drawing.Point(265, 26);
		this.vGridControl1.Margin = new System.Windows.Forms.Padding(2);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.FixedLineWidth = 1;
		this.vGridControl1.OptionsView.LevelIndent = 50;
		this.vGridControl1.OptionsView.ShowCollapseButtons = false;
		this.vGridControl1.RecordWidth = 125;
		this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[4] { this.repositoryItemMemoEdit1, this.repositoryItemMemoEdit2, this.repositoryItemMemoEdit3, this.repositoryItemMemoEdit4 });
		this.vGridControl1.RowHeaderWidth = 75;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[4] { this.row, this.row1, this.row2, this.row3 });
		this.vGridControl1.Size = new System.Drawing.Size(527, 505);
		this.vGridControl1.TabIndex = 30;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.vGridControl1.Click += new System.EventHandler(vGridControl1_Click);
		this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.repositoryItemMemoEdit1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.repositoryItemMemoEdit1.LinesCount = 5;
		this.repositoryItemMemoEdit1.MaxLength = 200;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.repositoryItemMemoEdit2.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.repositoryItemMemoEdit2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.repositoryItemMemoEdit2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.repositoryItemMemoEdit2.LinesCount = 5;
		this.repositoryItemMemoEdit2.MaxLength = 200;
		this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
		this.repositoryItemMemoEdit3.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.repositoryItemMemoEdit3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.repositoryItemMemoEdit3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.repositoryItemMemoEdit3.LinesCount = 5;
		this.repositoryItemMemoEdit3.MaxLength = 200;
		this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
		this.repositoryItemMemoEdit4.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.repositoryItemMemoEdit4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.repositoryItemMemoEdit4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.repositoryItemMemoEdit4.LinesCount = 5;
		this.repositoryItemMemoEdit4.MaxLength = 200;
		this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
		this.row.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row.AppearanceCell.Options.UseFont = true;
		this.row.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row.AppearanceHeader.Options.UseFont = true;
		this.row.AppearanceHeader.Options.UseTextOptions = true;
		this.row.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.row.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.row.Name = "row";
		this.row.Properties.Caption = "Comment 1";
		this.row.Properties.FieldName = "Comment1";
		this.row.Properties.RowEdit = this.repositoryItemMemoEdit1;
		this.row1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row1.AppearanceCell.Options.UseFont = true;
		this.row1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row1.AppearanceHeader.Options.UseFont = true;
		this.row1.AppearanceHeader.Options.UseTextOptions = true;
		this.row1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.row1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.row1.Name = "row1";
		this.row1.Properties.Caption = "Comment 2";
		this.row1.Properties.FieldName = "Comment2";
		this.row1.Properties.RowEdit = this.repositoryItemMemoEdit2;
		this.row2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row2.AppearanceCell.Options.UseFont = true;
		this.row2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row2.AppearanceHeader.Options.UseFont = true;
		this.row2.AppearanceHeader.Options.UseTextOptions = true;
		this.row2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.row2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "Comment 3";
		this.row2.Properties.FieldName = "Comment3";
		this.row2.Properties.RowEdit = this.repositoryItemMemoEdit3;
		this.row3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row3.AppearanceCell.Options.UseFont = true;
		this.row3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f);
		this.row3.AppearanceHeader.Options.UseFont = true;
		this.row3.AppearanceHeader.Options.UseTextOptions = true;
		this.row3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.row3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Comment 4";
		this.row3.Properties.FieldName = "Comment4";
		this.row3.Properties.RowEdit = this.repositoryItemMemoEdit4;
		this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl16.Appearance.Options.UseFont = true;
		this.labelControl16.Location = new System.Drawing.Point(3, 3);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(291, 19);
		this.labelControl16.StyleController = this.layoutControl1;
		this.labelControl16.TabIndex = 29;
		this.labelControl16.Text = "O Level Subject Facilitator Remarks";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(795, 534);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.layoutControlItem1.Control = this.dgOLevelGrades;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(262, 509);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.Text = "Report Remarks";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.labelControl16;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(793, 23);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem2.Control = this.vGridControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(262, 23);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(531, 509);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrOLevelGradingScaleNC";
		base.Size = new System.Drawing.Size(795, 534);
		base.Load += new System.EventHandler(usrOLevelGradingScale2_Load);
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
