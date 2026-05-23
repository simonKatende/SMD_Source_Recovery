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

public class usrOLevelGradingScale2 : XtraUserControl
{
	private DataTable dataTableOLDivisions;

	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private int scaleID = 0;

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

	private CategoryRow Comment1;

	private EditorRow row;

	private EditorRow row1;

	private EditorRow row2;

	private EditorRow row3;

	private EditorRow row4;

	private CategoryRow Comment2;

	private EditorRow row5;

	private EditorRow row6;

	private EditorRow row7;

	private EditorRow row8;

	private EditorRow row9;

	private CategoryRow Comment3;

	private EditorRow row19;

	private EditorRow row18;

	private EditorRow row17;

	private EditorRow row16;

	private EditorRow row10;

	private CategoryRow Comment4;

	private EditorRow row15;

	private EditorRow row14;

	private EditorRow row13;

	private EditorRow row12;

	private EditorRow row11;

	public usrOLevelGradingScale2()
	{
		InitializeComponent();
		ReportCustomization.LoadCustomizedFields();
		Comment1.Properties.Caption = ReportCustomization.Comment1Label;
		Comment2.Properties.Caption = ReportCustomization.Comment2Label;
	}

	private void LoadOLevelGrades()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelDivisionScale", DataConnection.ConnectToDatabase());
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelDivisionScale WHERE ScaleId=" + scaleID, DataConnection.ConnectToDatabase());
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
			scaleID = Convert.ToInt32(dataRow["ScaleId"].ToString());
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
				CommandText = string.Format("UPDATE OLevelDivisionScale SET {0}=@{0} WHERE ScaleId='{1}'", fieldName, scaleID),
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 80);
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
			scaleID = Convert.ToInt32(dataRow["ScaleId"].ToString());
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.Comment1 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Comment2 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row6 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row7 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row8 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row9 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Comment3 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row19 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row18 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row17 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row16 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row10 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Comment4 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row15 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row14 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row13 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row12 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row11 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.dgOLevelGrades.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
		this.dgOLevelGrades.Location = new System.Drawing.Point(5, 40);
		this.dgOLevelGrades.MainView = this.gridViewOLevelGrades;
		this.dgOLevelGrades.Margin = new System.Windows.Forms.Padding(4);
		this.dgOLevelGrades.Name = "dgOLevelGrades";
		this.dgOLevelGrades.Size = new System.Drawing.Size(266, 735);
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
		this.gridViewOLevelGrades.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridViewOLevelGrades.GridControl = this.dgOLevelGrades;
		this.gridViewOLevelGrades.Name = "gridViewOLevelGrades";
		this.gridViewOLevelGrades.OptionsBehavior.Editable = false;
		this.gridViewOLevelGrades.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewOLevelGrades.OptionsCustomization.AllowGroup = false;
		this.gridViewOLevelGrades.OptionsView.ShowGroupPanel = false;
		this.gridViewOLevelGrades.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewOLevelGrades.OptionsView.ShowIndicator = false;
		this.gridViewOLevelGrades.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridViewOLevelGrades_RowClick);
		this.gridViewOLevelGrades.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewOLevelGrades_FocusedRowChanged);
		this.gridColumn1.Caption = "Division";
		this.gridColumn1.FieldName = "Grade";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Start";
		this.gridColumn2.FieldName = "Debut";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn3.Caption = "End";
		this.gridColumn3.FieldName = "EndMark";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.layoutControl1.Controls.Add(this.vGridControl1);
		this.layoutControl1.Controls.Add(this.labelControl16);
		this.layoutControl1.Controls.Add(this.dgOLevelGrades);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(1192, 780);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.vGridControl1.Appearance.BandBorder.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl1.Appearance.Category.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
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
		this.vGridControl1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Azure;
		this.vGridControl1.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
		this.vGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.vGridControl1.Appearance.FocusedCell.Options.UseBorderColor = true;
		this.vGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecord.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.FocusedRow.Options.UseFont = true;
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
		this.vGridControl1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridControl1.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridControl1.Location = new System.Drawing.Point(277, 40);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.LevelIndent = 50;
		this.vGridControl1.OptionsView.ShowButtons = false;
		this.vGridControl1.RecordWidth = 150;
		this.vGridControl1.RowHeaderWidth = 50;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[4] { this.Comment1, this.Comment2, this.Comment3, this.Comment4 });
		this.vGridControl1.Size = new System.Drawing.Size(910, 735);
		this.vGridControl1.TabIndex = 30;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.vGridControl1.Click += new System.EventHandler(vGridControl1_Click);
		this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl16.Appearance.Options.UseFont = true;
		this.labelControl16.Location = new System.Drawing.Point(5, 5);
		this.labelControl16.Margin = new System.Windows.Forms.Padding(4);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(287, 29);
		this.labelControl16.StyleController = this.layoutControl1;
		this.labelControl16.TabIndex = 29;
		this.labelControl16.Text = "O Level Report Remarks";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(1192, 780);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.layoutControlItem1.Control = this.dgOLevelGrades;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 35);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(272, 741);
		this.layoutControlItem1.Text = "Report Remarks";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.labelControl16;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(1188, 35);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem2.Control = this.vGridControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(272, 35);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(916, 741);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.Comment1.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[5] { this.row, this.row1, this.row2, this.row3, this.row4 });
		this.Comment1.Name = "Comment1";
		this.Comment1.Properties.Caption = "Comment Group1";
		this.row.Name = "row";
		this.row.Properties.Caption = "Option 1";
		this.row.Properties.FieldName = "ClassTeacherComment";
		this.row1.Name = "row1";
		this.row1.Properties.Caption = "Option 2";
		this.row1.Properties.FieldName = "ClassTeacherComment1";
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "Option 3";
		this.row2.Properties.FieldName = "ClassTeacherComment2";
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Option 4";
		this.row3.Properties.FieldName = "ClassTeacherComment3";
		this.row4.Name = "row4";
		this.row4.Properties.Caption = "Option 5";
		this.row4.Properties.FieldName = "ClassTeacherComment4";
		this.Comment2.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[5] { this.row5, this.row6, this.row7, this.row8, this.row9 });
		this.Comment2.Name = "Comment2";
		this.Comment2.Properties.Caption = "Comment Group2";
		this.row5.Name = "row5";
		this.row5.Properties.Caption = "Option 1";
		this.row5.Properties.FieldName = "DOSComment";
		this.row6.Name = "row6";
		this.row6.Properties.Caption = "Option 2";
		this.row6.Properties.FieldName = "DOSComment1";
		this.row7.Name = "row7";
		this.row7.Properties.Caption = "Option 3";
		this.row7.Properties.FieldName = "DOSComment2";
		this.row8.Name = "row8";
		this.row8.Properties.Caption = "Option 4";
		this.row8.Properties.FieldName = "DOSComment3";
		this.row9.Name = "row9";
		this.row9.Properties.Caption = "Option 5";
		this.row9.Properties.FieldName = "DOSComment4";
		this.Comment3.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[5] { this.row19, this.row18, this.row17, this.row16, this.row10 });
		this.Comment3.Name = "Comment3";
		this.Comment3.Properties.Caption = "Comment Group3";
		this.row19.Name = "row19";
		this.row19.Properties.Caption = "Option 1";
		this.row19.Properties.FieldName = "HeadTeacherComment";
		this.row18.Name = "row18";
		this.row18.Properties.Caption = "Option 2";
		this.row18.Properties.FieldName = "HeadTeacherComment1";
		this.row17.Name = "row17";
		this.row17.Properties.Caption = "Option 3";
		this.row17.Properties.FieldName = "HeadTeacherComment2";
		this.row16.Name = "row16";
		this.row16.Properties.Caption = "Option 4";
		this.row16.Properties.FieldName = "HeadTeacherComment3";
		this.row10.Name = "row10";
		this.row10.Properties.Caption = "Option 5";
		this.row10.Properties.FieldName = "HeadTeacherComment4";
		this.Comment4.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[5] { this.row15, this.row14, this.row13, this.row12, this.row11 });
		this.Comment4.Name = "Comment4";
		this.Comment4.Properties.Caption = "Comment Group4";
		this.row15.Name = "row15";
		this.row15.Properties.Caption = "Option 1";
		this.row15.Properties.FieldName = "Comment4";
		this.row14.Name = "row14";
		this.row14.Properties.Caption = "Option 2";
		this.row14.Properties.FieldName = "Comment41";
		this.row13.Name = "row13";
		this.row13.Properties.Caption = "Option 3";
		this.row13.Properties.FieldName = "Comment42";
		this.row12.Name = "row12";
		this.row12.Properties.Caption = "Option 4";
		this.row12.Properties.FieldName = "Comment43";
		this.row11.Name = "row11";
		this.row11.Properties.Caption = "Option 5";
		this.row11.Properties.FieldName = "Comment44";
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "usrOLevelGradingScale2";
		base.Size = new System.Drawing.Size(1192, 780);
		base.Load += new System.EventHandler(usrOLevelGradingScale2_Load);
		((System.ComponentModel.ISupportInitialize)this.dgOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewOLevelGrades).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
