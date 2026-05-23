using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.NavigationForms;

public class XtraReceiveHistory : XtraUserControl
{
	private DataTable dt;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	public XtraReceiveHistory()
	{
		InitializeComponent();
	}

	private void LoadReceiveHistory()
	{
		try
		{
			string selectCommandText = "SELECT   d.Name AS Deparment,rh._Date AS Date, sc.CategoryName, s.LocalCode, s.ItemName, rh.JobType, rh.Rate,rh.Received AS Qty, rh.Rate * rh.Received AS Total FROM     tbl_ReceivIssueHistory rh INNER JOIN  tbl_Departments d INNER JOIN tbl_StockCategories sc ON d.departmentId = sc.departmentId INNER JOIN tbl_Stock s ON sc.categoryId = s.categoryId ON rh.LocalCode = s.LocalCode GROUP BY d.Name, sc.CategoryName, s.LocalCode, s.ItemName, rh.JobType, rh.Rate,rh.Received, rh._Date HAVING        (rh.JobType = 'Receive')";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "IssueHistory");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl1.DataSource = dt.DefaultView;
			gridView1.Columns["JobType"].Visible = false;
			gridView1.Columns["CategoryName"].Visible = false;
			gridView1.Columns["LocalCode"].Visible = false;
			gridView1.Columns["Deparment"].GroupIndex = 0;
			gridView1.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
			gridView1.Columns["Date"].DisplayFormat.FormatString = "dd-MMM-yy";
			gridView1.Columns["Rate"].DisplayFormat.FormatType = FormatType.Numeric;
			gridView1.Columns["Rate"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridView1.Columns["Total"].DisplayFormat.FormatType = FormatType.Numeric;
			gridView1.Columns["Total"].DisplayFormat.FormatString = "{0:#,#.0}";
			GridGroupSummaryItem gridGroupSummaryItem = new GridGroupSummaryItem();
			gridGroupSummaryItem.FieldName = "Total";
			gridGroupSummaryItem.SummaryType = SummaryItemType.Sum;
			gridView1.GroupSummary.Add(gridGroupSummaryItem);
			GridSummaryItem gridSummaryItem = new GridSummaryItem();
			gridSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridSummaryItem.FieldName = "Total";
			gridView1.Columns["Total"].SummaryItem.Assign(gridSummaryItem);
			PrintableControl.SavePrintableControl(gridControl1);
			PrintableControl.SavePrintableControl(gridView1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void XtraReceiveHistory_Load(object sender, EventArgs e)
	{
		LoadReceiveHistory();
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
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(759, 480);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(755, 476);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(759, 480);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(759, 480);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "XtraReceiveHistory";
		base.Size = new System.Drawing.Size(759, 480);
		base.Load += new System.EventHandler(XtraReceiveHistory_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
