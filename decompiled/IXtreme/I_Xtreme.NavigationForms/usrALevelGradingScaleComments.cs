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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class usrALevelGradingScaleComments : XtraUserControl
{
	private DataTable _dt;

	private int scaleID = 0;

	private IContainer components = null;

	private MyGridControl gridControl4;

	private MyGridView gridView8;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private LabelControl labelControl16;

	private LayoutControlItem layoutControlItem3;

	private VGridControl vGridControl1;

	private CategoryRow Comment1;

	private EditorRow row;

	private EditorRow row1;

	private EditorRow row2;

	private EditorRow row3;

	private EditorRow row4;

	private CategoryRow Comment3;

	private EditorRow row19;

	private EditorRow row18;

	private EditorRow row17;

	private EditorRow row16;

	private EditorRow row10;

	private LayoutControlItem layoutControlItem2;

	public usrALevelGradingScaleComments()
	{
		InitializeComponent();
		ReportCustomization.LoadCustomizedFields();
		Comment1.Properties.Caption = ReportCustomization.Comment1Label;
		Comment3.Properties.Caption = ReportCustomization.Comment2Label;
	}

	private void LoadALevelComments()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from tbl_ALevel_Comments", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "myScale");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			gridControl4.DataSource = _dt.DefaultView;
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_ALevel_Comments WHERE id=" + scaleID, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "GradingScale");
			vGridControl1.DataSource = dataSet.Tables[0].DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void gridView8_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gridView8.FocusedRowHandle > -1)
		{
			DataRow dataRow = _dt.Rows[e.FocusedRowHandle];
			scaleID = Convert.ToInt32(dataRow["id"].ToString());
			LoadSelectedScaleValues();
		}
	}

	private void usrALevelGradingScaleComments_Load(object sender, EventArgs e)
	{
		LoadALevelComments();
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
				CommandText = string.Format("UPDATE tbl_ALevel_Comments SET {0}=@{0} WHERE id=@id", fieldName),
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
			sqlParameter.Value = scaleID;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 80);
			sqlParameter.Value = e.Value;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void gridView8_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridView8.FocusedRowHandle > -1)
		{
			DataRow dataRow = _dt.Rows[e.RowHandle];
			scaleID = Convert.ToInt32(dataRow["id"].ToString());
			LoadSelectedScaleValues();
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
		this.gridControl4 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView8 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.Comment1 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Comment3 = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
		this.row19 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row18 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row17 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row16 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row10 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.gridControl4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.gridControl4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridControl4.Location = new System.Drawing.Point(2, 23);
		this.gridControl4.MainView = this.gridView8;
		this.gridControl4.Name = "gridControl4";
		this.gridControl4.Size = new System.Drawing.Size(213, 502);
		this.gridControl4.TabIndex = 0;
		this.gridControl4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView8 });
		this.gridView8.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView8.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView8.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView8.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView8.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView8.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView8.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView8.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.GroupRow.Options.UseFont = true;
		this.gridView8.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView8.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView8.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView8.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView8.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.Preview.Options.UseFont = true;
		this.gridView8.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.Row.Options.UseFont = true;
		this.gridView8.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView8.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView8.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView8.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn2 });
		this.gridView8.DetailHeight = 239;
		this.gridView8.GridControl = this.gridControl4;
		this.gridView8.Name = "gridView8";
		this.gridView8.OptionsBehavior.Editable = false;
		this.gridView8.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView8.OptionsCustomization.AllowGroup = false;
		this.gridView8.OptionsEditForm.PopupEditFormWidth = 533;
		this.gridView8.OptionsView.ShowGroupPanel = false;
		this.gridView8.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView8.OptionsView.ShowIndicator = false;
		this.gridView8.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView8_RowClick);
		this.gridView8.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView8_FocusedRowChanged);
		this.gridColumn1.Caption = "Start";
		this.gridColumn1.FieldName = "Debut";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "End";
		this.gridColumn2.FieldName = "EndMark";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 50;
		this.layoutControl1.Controls.Add(this.vGridControl1);
		this.layoutControl1.Controls.Add(this.labelControl16);
		this.layoutControl1.Controls.Add(this.gridControl4);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(968, 527);
		this.layoutControl1.TabIndex = 5;
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
		this.vGridControl1.BandsInterval = 1;
		this.vGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridControl1.Location = new System.Drawing.Point(217, 23);
		this.vGridControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.FixedLineWidth = 1;
		this.vGridControl1.OptionsView.LevelIndent = 50;
		this.vGridControl1.OptionsView.ShowCollapseButtons = false;
		this.vGridControl1.RecordWidth = 158;
		this.vGridControl1.RowHeaderWidth = 42;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[2] { this.Comment1, this.Comment3 });
		this.vGridControl1.Size = new System.Drawing.Size(749, 502);
		this.vGridControl1.TabIndex = 31;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.Comment1.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[5] { this.row, this.row1, this.row2, this.row3, this.row4 });
		this.Comment1.Name = "Comment1";
		this.Comment1.Properties.Caption = "Comment Group1";
		this.row.Name = "row";
		this.row.Properties.Caption = "Option 1";
		this.row.Properties.FieldName = "ClassTeacherComments1";
		this.row1.Name = "row1";
		this.row1.Properties.Caption = "Option 2";
		this.row1.Properties.FieldName = "ClassTeacherComments2";
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "Option 3";
		this.row2.Properties.FieldName = "ClassTeacherComments3";
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Option 4";
		this.row3.Properties.FieldName = "ClassTeacherComments4";
		this.row4.Name = "row4";
		this.row4.Properties.Caption = "Option 5";
		this.row4.Properties.FieldName = "ClassTeacherComments5";
		this.Comment3.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[5] { this.row19, this.row18, this.row17, this.row16, this.row10 });
		this.Comment3.Name = "Comment3";
		this.Comment3.Properties.Caption = "Comment Group3";
		this.row19.Name = "row19";
		this.row19.Properties.Caption = "Option 1";
		this.row19.Properties.FieldName = "HeadTeacherComment1";
		this.row18.Name = "row18";
		this.row18.Properties.Caption = "Option 2";
		this.row18.Properties.FieldName = "HeadTeacherComment2";
		this.row17.Name = "row17";
		this.row17.Properties.Caption = "Option 3";
		this.row17.Properties.FieldName = "HeadTeacherComment3";
		this.row16.Name = "row16";
		this.row16.Properties.Caption = "Option 4";
		this.row16.Properties.FieldName = "HeadTeacherComment4";
		this.row10.Name = "row10";
		this.row10.Properties.Caption = "Option 5";
		this.row10.Properties.FieldName = "HeadTeacherComment5";
		this.labelControl16.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl16.Appearance.Options.UseFont = true;
		this.labelControl16.Location = new System.Drawing.Point(2, 2);
		this.labelControl16.Name = "labelControl16";
		this.labelControl16.Size = new System.Drawing.Size(198, 19);
		this.labelControl16.StyleController = this.layoutControl1;
		this.labelControl16.TabIndex = 5;
		this.labelControl16.Text = "A Level Report Remarks";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(968, 527);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl4;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 21);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(215, 504);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.labelControl16;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(966, 21);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem2.Control = this.vGridControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(215, 21);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(751, 504);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrALevelGradingScaleComments";
		base.Size = new System.Drawing.Size(968, 527);
		base.Load += new System.EventHandler(usrALevelGradingScaleComments_Load);
		((System.ComponentModel.ISupportInitialize)this.gridControl4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView8).EndInit();
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
