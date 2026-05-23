using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.NavigationForms;

public class UserUserWasteHistory : XtraUserControl
{
	private DataTable dt;

	private IContainer components = null;

	private GridControl gridControl1;

	private GridView gridView1;

	public UserUserWasteHistory()
	{
		InitializeComponent();
	}

	private void LoadWasteHistory()
	{
		try
		{
			string selectCommandText = "SELECT   d.Name AS Deparment,rh._Date AS Date, sc.CategoryName, s.LocalCode, s.ItemName, rh.JobType,rh.Issued AS QtyWasted FROM     tbl_ReceivIssueHistory rh INNER JOIN  tbl_Departments d INNER JOIN tbl_StockCategories sc ON d.departmentId = sc.departmentId INNER JOIN tbl_Stock s ON sc.categoryId = s.categoryId ON rh.LocalCode = s.LocalCode GROUP BY d.Name, sc.CategoryName, s.LocalCode, s.ItemName, rh.JobType, rh.Rate,rh.Issued, rh._Date HAVING        (rh.JobType = 'Waste')";
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
			PrintableControl.SavePrintableControl(gridControl1);
			PrintableControl.SavePrintableControl(gridView1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void UserUserWasteHistory_Load(object sender, EventArgs e)
	{
		LoadWasteHistory();
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
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		base.SuspendLayout();
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(453, 406);
		this.gridControl1.TabIndex = 5;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.gridControl1);
		base.Name = "UserUserWasteHistory";
		base.Size = new System.Drawing.Size(453, 406);
		base.Load += new System.EventHandler(UserUserWasteHistory_Load);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		base.ResumeLayout(false);
	}
}
