using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class usrPrePriSubjects : XtraUserControl
{
	private DataTable dt;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private GridControl myGridControl1;

	private GridView myGridView1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private Timer timer1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	public usrPrePriSubjects()
	{
		InitializeComponent();
		LoadSubjects();
	}

	public void SubjectListCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void LoadSubjects()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelSubjects WHERE ClassLevel='PrePrimary'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SubGroups");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			myGridControl1.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(myGridControl1);
			ActiveFormSelected.SetActiveForm("Pre-primary assessable areas");
			timer1.Enabled = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		LoadSubjects();
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
		this.myGridControl1 = new DevExpress.XtraGrid.GridControl();
		this.myGridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.myGridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(678, 519);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.myGridControl1.Location = new System.Drawing.Point(4, 4);
		this.myGridControl1.MainView = this.myGridView1;
		this.myGridControl1.Name = "myGridControl1";
		this.myGridControl1.Size = new System.Drawing.Size(670, 511);
		this.myGridControl1.TabIndex = 4;
		this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.myGridView1 });
		this.myGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.myGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.myGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.myGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.myGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.Empty.Options.UseFont = true;
		this.myGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.myGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.myGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.myGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.myGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.myGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.myGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.myGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.myGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.myGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.myGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.myGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.myGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.myGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.OddRow.Options.UseFont = true;
		this.myGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.Preview.Options.UseFont = true;
		this.myGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.Row.Options.UseFont = true;
		this.myGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.myGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.myGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.myGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.VertLine.Options.UseFont = true;
		this.myGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.myGridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.myGridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.myGridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.myGridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.myGridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.myGridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.myGridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.myGridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.myGridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.myGridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.myGridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.myGridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.myGridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.myGridView1.AppearancePrint.Row.Options.UseFont = true;
		this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.myGridView1.GridControl = this.myGridControl1;
		this.myGridView1.Name = "myGridView1";
		this.myGridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.myGridView1.OptionsBehavior.Editable = false;
		this.myGridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.myGridView1.OptionsView.AllowCellMerge = true;
		this.myGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.myGridView1.OptionsView.ShowGroupPanel = false;
		this.myGridView1.OptionsView.ShowIndicator = false;
		this.gridColumn1.Caption = "Assessment Area";
		this.gridColumn1.FieldName = "SubGroup";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 599;
		this.gridColumn2.Caption = "Subject";
		this.gridColumn2.FieldName = "SubjectId";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 375;
		this.gridColumn3.Caption = "Short Code";
		this.gridColumn3.FieldName = "ShortCode";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Width = 120;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(678, 519);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.myGridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(674, 515);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrPrePriSubjects";
		base.Size = new System.Drawing.Size(678, 519);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.myGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.myGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
