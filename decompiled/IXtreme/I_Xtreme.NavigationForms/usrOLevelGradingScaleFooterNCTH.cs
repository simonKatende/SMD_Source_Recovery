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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class usrOLevelGradingScaleFooterNCTH : XtraUserControl
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

	private CategoryRow category;

	private EditorRow row6;

	private EditorRow row1;

	private EditorRow row2;

	private EditorRow row;

	private CategoryRow category1;

	private EditorRow row7;

	private EditorRow row3;

	private EditorRow row4;

	private EditorRow row5;

	private VGridControl vGridControl2;

	private CategoryRow categoryRow1;

	private EditorRow editorRow1;

	private EditorRow editorRow2;

	private EditorRow editorRow3;

	private EditorRow editorRow4;

	private CategoryRow categoryRow2;

	private EditorRow editorRow5;

	private EditorRow editorRow6;

	private EditorRow editorRow7;

	private EditorRow editorRow8;

	private LayoutControlItem layoutControlItem4;

	public usrOLevelGradingScaleFooterNCTH()
	{
		InitializeComponent();
	}

	private void LoadOLevelGrades()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNCTH", DataConnection.ConnectToDatabase());
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNCTH WHERE Id=" + Id, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GradingScale");
			vGridControl1.DataSource = dataSet.Tables[0].DefaultView;
			vGridControl2.DataSource = dataSet.Tables[0].DefaultView;
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
				CommandText = string.Format("UPDATE OLevelAutoCommentsNCTH SET {0}=@{0} WHERE Id='{1}'", fieldName, Id),
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 500);
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

	private void vGridControl2_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		try
		{
			string fieldName = e.Row.Properties.FieldName;
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("UPDATE OLevelAutoCommentsNCTH SET {0}=@{0} WHERE Id='{1}'", fieldName, Id),
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.NVarChar, 500);
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.categoryRow1 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.editorRow1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.editorRow2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.editorRow3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.editorRow4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.categoryRow2 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.editorRow5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.editorRow6 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.editorRow7 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.editorRow8 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.category = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row6 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.category1 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row7 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		base.SuspendLayout();
		this.dgOLevelGrades.Location = new System.Drawing.Point(3, 26);
		this.dgOLevelGrades.MainView = this.gridViewOLevelGrades;
		this.dgOLevelGrades.Name = "dgOLevelGrades";
		this.dgOLevelGrades.Size = new System.Drawing.Size(128, 505);
		this.dgOLevelGrades.TabIndex = 0;
		this.dgOLevelGrades.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewOLevelGrades });
		this.gridViewOLevelGrades.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewOLevelGrades.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.Preview.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.Row.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewOLevelGrades.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewOLevelGrades.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewOLevelGrades.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewOLevelGrades.Appearance.TopNewRow.Options.UseFont = true;
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
		this.gridViewOLevelGrades.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
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
		this.layoutControl1.Controls.Add(this.vGridControl2);
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
		this.vGridControl2.Appearance.BandBorder.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl2.Appearance.Caption.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.Caption.Options.UseFont = true;
		this.vGridControl2.Appearance.Category.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.Category.Options.UseFont = true;
		this.vGridControl2.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridControl2.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.DisabledRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridControl2.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.Empty.Options.UseFont = true;
		this.vGridControl2.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridControl2.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FixedLine.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedCell.BackColor = System.Drawing.Color.Azure;
		this.vGridControl2.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
		this.vGridControl2.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.vGridControl2.Appearance.FocusedCell.Options.UseBorderColor = true;
		this.vGridControl2.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRecord.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridControl2.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.HorzLine.Options.UseFont = true;
		this.vGridControl2.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.ModifiedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.PressedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.PressedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridControl2.Appearance.RecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.RecordValue.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.RecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedCategory.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRecord.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Mono", 12.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl2.BandsInterval = 1;
		this.vGridControl2.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl2.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridControl2.Location = new System.Drawing.Point(135, 280);
		this.vGridControl2.Margin = new System.Windows.Forms.Padding(2);
		this.vGridControl2.Name = "vGridControl2";
		this.vGridControl2.OptionsView.FixedLineWidth = 1;
		this.vGridControl2.OptionsView.LevelIndent = 50;
		this.vGridControl2.OptionsView.ShowCollapseButtons = false;
		this.vGridControl2.RecordWidth = 142;
		this.vGridControl2.RowHeaderWidth = 58;
		this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[10] { this.categoryRow1, this.editorRow1, this.editorRow2, this.editorRow3, this.editorRow4, this.categoryRow2, this.editorRow5, this.editorRow6, this.editorRow7, this.editorRow8 });
		this.vGridControl2.Size = new System.Drawing.Size(657, 251);
		this.vGridControl2.TabIndex = 31;
		this.vGridControl2.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl2_CellValueChanged);
		this.categoryRow1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.categoryRow1.AppearanceCell.Options.UseFont = true;
		this.categoryRow1.Name = "categoryRow1";
		this.categoryRow1.Properties.Caption = "Classteacher Remarks - Arabic";
		this.editorRow1.Name = "editorRow1";
		this.editorRow1.Properties.Caption = "Remark 1";
		this.editorRow1.Properties.FieldName = "Classteacher1Ar";
		this.editorRow2.Name = "editorRow2";
		this.editorRow2.Properties.Caption = "Remark 2";
		this.editorRow2.Properties.FieldName = "Classteacher2Ar";
		this.editorRow3.Name = "editorRow3";
		this.editorRow3.Properties.Caption = "Remark 3";
		this.editorRow3.Properties.FieldName = "Classteacher3Ar";
		this.editorRow4.Name = "editorRow4";
		this.editorRow4.Properties.Caption = "Remark 4";
		this.editorRow4.Properties.FieldName = "Classteacher4Ar";
		this.categoryRow2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.categoryRow2.AppearanceCell.Options.UseFont = true;
		this.categoryRow2.Name = "categoryRow2";
		this.categoryRow2.Properties.Caption = "Headteacher Remarks - Arabic";
		this.editorRow5.Name = "editorRow5";
		this.editorRow5.Properties.Caption = "Remark 1";
		this.editorRow5.Properties.FieldName = "Headteacher1Ar";
		this.editorRow6.Name = "editorRow6";
		this.editorRow6.Properties.Caption = "Remark 2";
		this.editorRow6.Properties.FieldName = "Headteacher2Ar";
		this.editorRow7.Name = "editorRow7";
		this.editorRow7.Properties.Caption = "Remark 3";
		this.editorRow7.Properties.FieldName = "Headteacher3Ar";
		this.editorRow8.Name = "editorRow8";
		this.editorRow8.Properties.Caption = "Remark 4";
		this.editorRow8.Properties.FieldName = "Headteacher4Ar";
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
		this.vGridControl1.Location = new System.Drawing.Point(135, 26);
		this.vGridControl1.Margin = new System.Windows.Forms.Padding(2);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.FixedLineWidth = 1;
		this.vGridControl1.OptionsView.LevelIndent = 50;
		this.vGridControl1.OptionsView.ShowCollapseButtons = false;
		this.vGridControl1.RecordWidth = 142;
		this.vGridControl1.RowHeaderWidth = 58;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[10] { this.category, this.row6, this.row1, this.row2, this.row, this.category1, this.row7, this.row3, this.row4, this.row5 });
		this.vGridControl1.Size = new System.Drawing.Size(657, 250);
		this.vGridControl1.TabIndex = 30;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.category.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.category.AppearanceCell.Options.UseFont = true;
		this.category.Name = "category";
		this.category.Properties.Caption = "Classteacher Remarks - English";
		this.row6.Name = "row6";
		this.row6.Properties.Caption = "Remark 1";
		this.row6.Properties.FieldName = "Classteacher1";
		this.row1.Name = "row1";
		this.row1.Properties.Caption = "Remark 2";
		this.row1.Properties.FieldName = "Classteacher2";
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "Remark 3";
		this.row2.Properties.FieldName = "Classteacher3";
		this.row.Name = "row";
		this.row.Properties.Caption = "Remark 4";
		this.row.Properties.FieldName = "Classteacher4";
		this.category1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.category1.AppearanceCell.Options.UseFont = true;
		this.category1.Name = "category1";
		this.category1.Properties.Caption = "Headteacher Remarks - English";
		this.row7.Name = "row7";
		this.row7.Properties.Caption = "Remark 1";
		this.row7.Properties.FieldName = "Headteacher1";
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Remark 2";
		this.row3.Properties.FieldName = "Headteacher2";
		this.row4.Name = "row4";
		this.row4.Properties.Caption = "Remark 3";
		this.row4.Properties.FieldName = "Headteacher3";
		this.row5.Name = "row5";
		this.row5.Properties.Caption = "Remark 4";
		this.row5.Properties.FieldName = "Headteacher4";
		this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl16.Appearance.Options.UseFont = true;
		this.labelControl16.Location = new System.Drawing.Point(3, 3);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(454, 19);
		this.labelControl16.StyleController = this.layoutControl1;
		this.labelControl16.TabIndex = 29;
		this.labelControl16.Text = "Theology Report,  Classteacher && Headteacher remarks";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem2, this.layoutControlItem4 });
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
		this.layoutControlItem1.MaxSize = new System.Drawing.Size(132, 0);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(132, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(132, 509);
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
		this.layoutControlItem2.Location = new System.Drawing.Point(132, 23);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(661, 254);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem4.Control = this.vGridControl2;
		this.layoutControlItem4.Location = new System.Drawing.Point(132, 277);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(661, 255);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrOLevelGradingScaleFooterNCTH";
		base.Size = new System.Drawing.Size(795, 534);
		base.Load += new System.EventHandler(usrOLevelGradingScale2_Load);
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		base.ResumeLayout(false);
	}
}
