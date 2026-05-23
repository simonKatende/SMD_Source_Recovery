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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;

namespace I_Xtreme.NavigationForms;

public class usrInvoiceLists : XtraUserControl
{
	private DataSet dataSet11;

	private IContainer components = null;

	private GridControl gridSupplierLedger;

	private GridView gridViewSL;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private ComboBoxEdit comboBoxEdit1;

	private LayoutControlItem layoutControlItem2;

	private TextEdit txtPaySupplierName;

	private LayoutControlItem layoutControlItem3;

	public usrInvoiceLists()
	{
		InitializeComponent();
	}

	private void LoadInvoices()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT InvoiceNo,supplier AS Supplier FROM tbl_InvoiceNumbers", selectConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT OrderNumber AS InvoiceNo, ItemName AS Particulars, Price,Quantity,Total FROM tbl_OrderdDetails", selectConnection);
			dataSet11 = new DataSet();
			sqlDataAdapter.Fill(dataSet11, "Orders");
			sqlDataAdapter2.Fill(dataSet11, "OrderDetails");
			DataColumn parentColumn = dataSet11.Tables["Orders"].Columns["InvoiceNo"];
			DataColumn childColumn = dataSet11.Tables["OrderDetails"].Columns["InvoiceNo"];
			if (dataSet11.Tables["Orders"].Rows.Count > 0)
			{
				dataSet11.Relations.Add("InvoiceDetails", parentColumn, childColumn);
				gridSupplierLedger.DataSource = dataSet11.Tables["Orders"];
				gridSupplierLedger.ForceInitialize();
			}
			else
			{
				dataSet11.Relations.Clear();
				gridSupplierLedger.DataSource = dataSet11.Tables["Orders"];
				gridSupplierLedger.ForceInitialize();
			}
			gridViewSL = new GridView(gridSupplierLedger);
			gridSupplierLedger.LevelTree.Nodes.Add("InvoiceDetails", gridViewSL);
			gridViewSL.ViewCaption = "Invoice details";
			gridViewSL.PopulateColumns(dataSet11.Tables["OrderDetails"]);
			gridViewSL.Columns["Quantity"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Quantity"].DisplayFormat.FormatString = "{0}";
			gridViewSL.Columns["Price"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Price"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridViewSL.Columns["Total"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Total"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridViewSL.OptionsView.AllowCellMerge = true;
			gridViewSL.OptionsView.ShowGroupPanel = false;
			gridViewSL.OptionsView.ShowFooter = true;
			GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
			gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem.FieldName = "Total";
			gridViewSL.Columns["Total"].SummaryItem.Assign(gridColumnSummaryItem);
			gridViewSL.UpdateSummary();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void LoadSupplierLedger(string supplierCompany)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT OrderNumber AS Ref,Particulars,SupplyDate AS Date,Credit,Debit,Balance FROM tbl_Orders WHERE Supplier='{supplierCompany}'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SupplierLedger");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			gridSupplierLedger.DataSource = dataTable.DefaultView;
			gridViewSL.Columns["Ref"].Width = 50;
			gridViewSL.Columns["Date"].Width = 70;
			gridViewSL.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
			gridViewSL.Columns["Date"].DisplayFormat.FormatString = "{0:dd-MMM-yy}";
			gridViewSL.Columns["Credit"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Credit"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridViewSL.Columns["Debit"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Debit"].DisplayFormat.FormatString = "{0:#,#.0}";
			gridViewSL.Columns["Balance"].DisplayFormat.FormatType = FormatType.Numeric;
			gridViewSL.Columns["Balance"].DisplayFormat.FormatString = "{0:#,#.0}";
			GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
			gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem.FieldName = "Credit";
			gridViewSL.Columns["Credit"].SummaryItem.Assign(gridColumnSummaryItem);
			GridColumnSummaryItem gridColumnSummaryItem2 = new GridColumnSummaryItem();
			gridColumnSummaryItem2.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem2.FieldName = "Debit";
			gridViewSL.Columns["Debit"].SummaryItem.Assign(gridColumnSummaryItem2);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrInvoiceLists_Load(object sender, EventArgs e)
	{
		LoadSupplierLedger(txtPaySupplierName.Text);
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
		this.gridSupplierLedger = new DevExpress.XtraGrid.GridControl();
		this.gridViewSL = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtPaySupplierName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLedger).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSL).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.gridSupplierLedger.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridSupplierLedger.Location = new System.Drawing.Point(212, 12);
		this.gridSupplierLedger.MainView = this.gridViewSL;
		this.gridSupplierLedger.Name = "gridSupplierLedger";
		this.gridSupplierLedger.Size = new System.Drawing.Size(594, 495);
		this.gridSupplierLedger.TabIndex = 5;
		this.gridSupplierLedger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSL });
		this.gridViewSL.GridControl = this.gridSupplierLedger;
		this.gridViewSL.Name = "gridViewSL";
		this.gridViewSL.OptionsBehavior.Editable = false;
		this.gridViewSL.OptionsDetail.AutoZoomDetail = true;
		this.gridViewSL.OptionsView.ShowGroupPanel = false;
		this.layoutControl1.Controls.Add(this.txtPaySupplierName);
		this.layoutControl1.Controls.Add(this.comboBoxEdit1);
		this.layoutControl1.Controls.Add(this.gridSupplierLedger);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(818, 519);
		this.layoutControl1.TabIndex = 6;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(818, 519);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridSupplierLedger;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(200, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(598, 499);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.comboBoxEdit1.Location = new System.Drawing.Point(12, 36);
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Size = new System.Drawing.Size(196, 20);
		this.comboBoxEdit1.StyleController = this.layoutControl1;
		this.comboBoxEdit1.TabIndex = 6;
		this.layoutControlItem2.Control = this.comboBoxEdit1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(200, 475);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.txtPaySupplierName.Location = new System.Drawing.Point(12, 12);
		this.txtPaySupplierName.Name = "txtPaySupplierName";
		this.txtPaySupplierName.Size = new System.Drawing.Size(196, 20);
		this.txtPaySupplierName.StyleController = this.layoutControl1;
		this.txtPaySupplierName.TabIndex = 7;
		this.layoutControlItem3.Control = this.txtPaySupplierName;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(200, 24);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrInvoiceLists";
		base.Size = new System.Drawing.Size(818, 519);
		base.Load += new System.EventHandler(usrInvoiceLists_Load);
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLedger).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSL).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPaySupplierName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
