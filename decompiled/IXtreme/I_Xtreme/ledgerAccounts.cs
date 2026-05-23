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

namespace I_Xtreme;

public class ledgerAccounts : XtraForm
{
	private GridView gridView2;

	private DataSet dataSet13;

	private DataSet dataSet14;

	private IContainer components = null;

	private GridControl gridControl1;

	private GridView gridView1;

	public ledgerAccounts()
	{
		InitializeComponent();
	}

	public void ChartOfAccounts()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT categoryId AS TypeRef,accountName AS AccountName FROM tbl_account_types", selectConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT at.categoryId AS TypeRef, at.accountName AS AccountType, ga.accNo AS AccountNumber,   ga.accName AS AccountName FROM  tbl_account_types at INNER JOIN tbl_generalAccounts ga ON at.categoryId = ga.categoryId", selectConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter("SELECT at.categoryId AS TypeRef,bs.accNo AS AccountNumber, bs._date AS Date, bs.particulars AS Particulars,bs.debit AS Dedit,bs.credit AS Credit FROM tbl_generalAccounts ga INNER JOIN tbl_account_types at ON ga.categoryId = at.categoryId INNER JOIN tbl_StatementOfAffairs bs ON ga.accNo = bs.accNo", selectConnection);
			dataSet13 = new DataSet();
			sqlDataAdapter.Fill(dataSet13, "AccCategory");
			sqlDataAdapter2.Fill(dataSet13, "GeneralAccounts");
			sqlDataAdapter3.Fill(dataSet13, "BalanceSheet");
			DataColumn parentColumn = dataSet13.Tables["AccCategory"].Columns["TypeRef"];
			DataColumn childColumn = dataSet13.Tables["GeneralAccounts"].Columns["TypeRef"];
			DataColumn parentColumn2 = dataSet13.Tables["GeneralAccounts"].Columns["AccountNumber"];
			DataColumn childColumn2 = dataSet13.Tables["BalanceSheet"].Columns["AccountNumber"];
			dataSet13.Relations.Add("ChartOfAccount", parentColumn, childColumn);
			dataSet13.Relations.Add("CashFlow", parentColumn2, childColumn2);
			gridControl1.DataSource = dataSet13.Tables["AccCategory"].DefaultView;
			gridControl1.ForceInitialize();
			gridView1 = new GridView(gridControl1);
			gridView2 = new GridView(gridControl1);
			gridControl1.LevelTree.Nodes.Add("ChartOfAccount", gridView1);
			gridControl1.LevelTree.Nodes.Add("CashFlow", gridView2);
			gridView1.ViewCaption = "Chart of Accounts";
			gridView2.ViewCaption = "Cash Flow";
			gridView1.PopulateColumns(dataSet13.Tables["GeneralAccounts"]);
			gridView2.PopulateColumns(dataSet13.Tables["BalanceSheet"]);
			gridView1.OptionsView.AllowCellMerge = true;
			gridView1.Columns["AccountType"].GroupIndex = 0;
			gridView1.OptionsBehavior.AutoExpandAllGroups = true;
			gridView1.Columns["TypeRef"].Visible = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public void GroupedChartOfAccounts()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT at.categoryId AS TypeRef, at.accountName AS AccountType, ga.accNo AS AccountNumber,ga.accName AS AccountName FROM  tbl_account_types at INNER JOIN tbl_generalAccounts ga ON at.categoryId = ga.categoryId", selectConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT at.accountName AS AccountName,ga.accNo AS AccountNumber, bs._date AS Date, bs.particulars AS Particulars,bs.debit AS Debit,bs.credit AS Credit FROM tbl_generalAccounts ga INNER JOIN tbl_account_types at ON ga.categoryId = at.categoryId INNER JOIN tbl_StatementOfAffairs bs ON ga.accNo = bs.accNo", selectConnection);
			dataSet14 = new DataSet();
			sqlDataAdapter.Fill(dataSet14, "GeneralAccounts");
			sqlDataAdapter2.Fill(dataSet14, "BalanceSheet");
			DataColumn parentColumn = dataSet14.Tables["GeneralAccounts"].Columns["AccountNumber"];
			DataColumn childColumn = dataSet14.Tables["BalanceSheet"].Columns["AccountNumber"];
			dataSet14.Relations.Add("ChartOfAccount", parentColumn, childColumn);
			gridControl1.DataSource = dataSet14.Tables["GeneralAccounts"].DefaultView;
			gridView1.Columns["TypeRef"].GroupIndex = 0;
			gridControl1.ForceInitialize();
			gridView1 = new GridView(gridControl1);
			gridControl1.LevelTree.Nodes.Add("ChartOfAccount", gridView1);
			gridView1.ViewCaption = "Chart of Accounts";
			gridView1.PopulateColumns(dataSet14.Tables["BalanceSheet"]);
			gridView1.OptionsView.AllowCellMerge = true;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void ledgerAccounts_Load(object sender, EventArgs e)
	{
		ChartOfAccounts();
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
		this.gridControl1.Size = new System.Drawing.Size(621, 463);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsCustomization.AllowColumnMoving = false;
		this.gridView1.OptionsCustomization.AllowFilter = false;
		this.gridView1.OptionsCustomization.AllowGroup = false;
		this.gridView1.OptionsDetail.AutoZoomDetail = true;
		this.gridView1.OptionsView.AllowCellMerge = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(621, 463);
		base.Controls.Add(this.gridControl1);
		base.Name = "ledgerAccounts";
		base.Load += new System.EventHandler(ledgerAccounts_Load);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		base.ResumeLayout(false);
	}
}
