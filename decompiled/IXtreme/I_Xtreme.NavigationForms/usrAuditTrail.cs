using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class usrAuditTrail : XtraUserControl
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LabelControl labelControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem3;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn15;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private GridColumn gridColumn12;

	private GridColumn gridColumn13;

	private GridColumn gridColumn14;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	public usrAuditTrail()
	{
		InitializeComponent();
		Dock = DockStyle.Fill;
	}

	private void LoadAuditTrail()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM TrailsAudit ORDER BY Id DESC", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			gridControl1.DataSource = dataTable.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrAuditTrail_Load(object sender, EventArgs e)
	{
		LoadAuditTrail();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		gridControl1.ShowRibbonPrintPreview();
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(892, 637);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.simpleButton1.Location = new System.Drawing.Point(814, 4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(74, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Preview";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(806, 23);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 5;
		this.labelControl1.Text = "Audit  Trail";
		this.gridControl1.Location = new System.Drawing.Point(4, 31);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemMemoEdit1 });
		this.gridControl1.Size = new System.Drawing.Size(884, 602);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gridView1.Appearance.NoSearchResults.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.NoSearchResults.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[15]
		{
			this.gridColumn1, this.gridColumn10, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn9, this.gridColumn8,
			this.gridColumn15, this.gridColumn11, this.gridColumn12, this.gridColumn13, this.gridColumn14
		});
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.RowAutoHeight = true;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridColumn1.Caption = "Id";
		this.gridColumn1.FieldName = "Id";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn10.Caption = "Channel";
		this.gridColumn10.FieldName = "Department";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 0;
		this.gridColumn10.Width = 60;
		this.gridColumn2.Caption = "Action";
		this.gridColumn2.FieldName = "Action";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 60;
		this.gridColumn3.Caption = "Description";
		this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
		this.gridColumn3.FieldName = "ActionDetails";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 80;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.gridColumn4.Caption = "Date";
		this.gridColumn4.FieldName = "Date";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn4.Width = 50;
		this.gridColumn5.Caption = "Time";
		this.gridColumn5.FieldName = "Time";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 4;
		this.gridColumn5.Width = 50;
		this.gridColumn6.Caption = "UserName";
		this.gridColumn6.FieldName = "UserName";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn7.Caption = "Name";
		this.gridColumn7.FieldName = "Name";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 5;
		this.gridColumn7.Width = 70;
		this.gridColumn9.Caption = "User Group";
		this.gridColumn9.FieldName = "UserGroup";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 6;
		this.gridColumn9.Width = 70;
		this.gridColumn8.Caption = "Computer Name";
		this.gridColumn8.FieldName = "SourcePC";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 8;
		this.gridColumn8.Width = 73;
		this.gridColumn15.Caption = "Computer IP";
		this.gridColumn15.FieldName = "SourceIP";
		this.gridColumn15.Name = "gridColumn15";
		this.gridColumn15.Visible = true;
		this.gridColumn15.VisibleIndex = 7;
		this.gridColumn15.Width = 50;
		this.gridColumn11.Caption = "StudentNo";
		this.gridColumn11.FieldName = "StudentNo";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.Visible = true;
		this.gridColumn11.VisibleIndex = 9;
		this.gridColumn11.Width = 50;
		this.gridColumn12.Caption = "Class";
		this.gridColumn12.FieldName = "ClassEn";
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn12.Visible = true;
		this.gridColumn12.VisibleIndex = 10;
		this.gridColumn12.Width = 50;
		this.gridColumn13.Caption = "Old Value";
		this.gridColumn13.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn13.FieldName = "OldValues";
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn13.Visible = true;
		this.gridColumn13.VisibleIndex = 11;
		this.gridColumn13.Width = 90;
		this.gridColumn14.Caption = "New Value";
		this.gridColumn14.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn14.FieldName = "NewValues";
		this.gridColumn14.Name = "gridColumn14";
		this.gridColumn14.Visible = true;
		this.gridColumn14.VisibleIndex = 12;
		this.gridColumn14.Width = 142;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(892, 637);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 27);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(888, 606);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.labelControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(810, 27);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(810, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(78, 27);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrAuditTrail";
		base.Size = new System.Drawing.Size(892, 637);
		base.Load += new System.EventHandler(usrAuditTrail_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
