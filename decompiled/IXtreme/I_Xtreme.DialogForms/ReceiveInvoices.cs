using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.Properties;

namespace I_Xtreme.DialogForms;

public class ReceiveInvoices : RibbonForm
{
	private SqlTransaction trans_orders;

	private SqlTransaction trans;

	private DataTable dtOrdersDetails;

	private DataTable dti;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private GridControl gridItems;

	private GridView gridViewItems;

	public LabelControl lblNameItem;

	public LabelControl lblCodeItem;

	private SimpleButton btnRemoveItem;

	private SimpleButton btnAddToList;

	private TextEdit txtSupplier;

	private TextEdit txtSupplierId;

	private TextEdit txtInvoiceNo;

	private GridControl gridSales;

	private GridView gridViewSales;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem4;

	private RibbonControl ribbonControl1;

	private RibbonPage ribbonPage1;

	private RibbonPageGroup ribbonPageGroup1;

	private BarButtonItem barButtonItem2;

	private RibbonPageGroup ribbonPageGroup2;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem3;

	private GridColumn gridColNo;

	private GridColumn gridColumn1;

	private GridColumn gridColItem;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem6;

	private GridColumn gridNO;

	private GridColumn gridItem;

	private GridColumn gridQty;

	private GridColumn gridRate;

	private GridColumn gridTotal;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem7;

	private TextEdit txtInvoiceDate;

	public ReceiveInvoices()
	{
		InitializeComponent();
	}

	private void LoadOrdersDetails(float orderNumber)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT o.id,o.qty,o.unitcost,(o.qty*o.unitcost) AS Total,o.OldStock,o.itemId,s.AssetName FROM tbl_OrderdDetails o INNER JOIN tbl_StockItems s ON s.id=o.itemId WHERE o.OrderNumber='{orderNumber}'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "orderDetails");
			dtOrdersDetails = new DataTable();
			dtOrdersDetails = dataSet.Tables[0];
			gridItems.DataSource = dtOrdersDetails.DefaultView;
			GridColumnSummaryItem gridColumnSummaryItem = new GridColumnSummaryItem();
			gridColumnSummaryItem.SetSummary(SummaryItemType.Sum, "{0:#,#.0}");
			gridColumnSummaryItem.FieldName = "Total";
			gridViewItems.Columns["Total"].SummaryItem.Assign(gridColumnSummaryItem);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
	}

	private void btnRemoveItem_Click(object sender, EventArgs e)
	{
		RemoveFromList();
	}

	private void btnAddToList_Click(object sender, EventArgs e)
	{
		AddItemToList();
	}

	private void RemoveFromList()
	{
		if (gridViewItems.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dtOrdersDetails.Rows[gridViewItems.GetFocusedDataSourceRowIndex()];
			try
			{
				switch (XtraMessageBox.Show("Are you sure you want to remove this item from the supplies list?", "School Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_OrderdDetails WHERE Id={0}", Convert.ToInt64(dataRow["id"].ToString())),
						CommandType = CommandType.Text
					};
					sqlCommand.ExecuteNonQuery();
					XtraMessageBox.Show("Item has been successfully removed from the supplies list", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					LoadOrdersDetails(Convert.ToInt64(txtInvoiceNo.Text));
					break;
				}
				}
				return;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		XtraMessageBox.Show("Please select an Item from the list on the Right.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void AddItemToList()
	{
		if (gridViewSales.GetFocusedDataSourceRowIndex() > -1 && !string.IsNullOrEmpty(txtInvoiceNo.Text))
		{
			DataRow dataRow = dti.Rows[gridViewSales.GetFocusedDataSourceRowIndex()];
			using AddToList addToList = new AddToList();
			addToList.txtItem.Text = dataRow["AssetName"].ToString();
			addToList.txtInvoiceNo.Text = txtInvoiceNo.Text;
			addToList.lblItemId.Text = dataRow["catID"].ToString();
			addToList.lblQty.Text = dataRow["Qty"].ToString();
			if (addToList.ShowDialog() == DialogResult.OK)
			{
				LoadOrdersDetails(Convert.ToInt64(txtInvoiceNo.Text));
			}
			return;
		}
		XtraMessageBox.Show("Please select an Item from the list on the left or Start a new invoice.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void txtSupplyId_TextChanged(object sender, EventArgs e)
	{
		try
		{
			float result = (float.TryParse(txtInvoiceNo.Text, out result) ? result : 0f);
			LoadOrdersDetails(result);
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Supplier,OrderNumber FROM tbl_Orders WHERE OrderNumber=" + txtInvoiceNo.Text, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Supplier");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				txtSupplierId.Text = row["Supplier"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ReceiveInvoices_Load(object sender, EventArgs e)
	{
		UnclosedInvoiceExists();
		LoadStockItems();
	}

	private void LoadStockItems()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT c.category,i.id AS catID,i.AssetName,i.Description,i.Qty,i.InitialCost,(i.Qty * i.InitialCost) AS CostPrice,i.IsDepreciable,i.DepreMethod,i.DepreRate,i.lifeSpan,i.AssetValue FROM tbl_StockItems i INNER JOIN tbl_StockCategories c ON i.category=c.id WHERE i.ItemType='Stock Item'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockItems");
			dti = new DataTable();
			dti = dataSet.Tables[0];
			gridSales.DataSource = dti.DefaultView;
			PrintableControl.SavePrintableControl(gridViewSales);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ReceiveInvoices_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to close this Invoice?\nNote that editing is not available after closing the Invoice.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < gridViewItems.RowCount; i++)
			{
				int num2 = Convert.ToInt32(gridViewItems.GetRowCellValue(i, "itemId").ToString());
				int num3 = Convert.ToInt32(gridViewItems.GetRowCellValue(i, "qty").ToString());
				int num4 = Convert.ToInt32(gridViewItems.GetRowCellValue(i, "OldStock").ToString());
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE tbl_StockItems SET Qty=@Qty WHERE id=@id",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Qty", SqlDbType.Int);
				sqlParameter.Value = num3 + num4;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@id", SqlDbType.Int);
				sqlParameter.Value = num2;
				sqlParameter.Direction = ParameterDirection.Input;
				if (sqlCommand.ExecuteNonQuery() > -1)
				{
					num++;
					sqlCommand.Clone();
				}
			}
			if (num != gridViewItems.RowCount)
			{
				return;
			}
			double num5 = Convert.ToDouble(gridViewItems.Columns["Total"].SummaryItem.SummaryValue);
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			trans_orders = sqlConnection2.BeginTransaction();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				Transaction = trans_orders,
				CommandText = "UPDATE tbl_Orders SET credit=@credit,Status=@Status WHERE OrderNumber=@OrderNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@OrderNumber", SqlDbType.Float);
				sqlParameter2.Value = Convert.ToDouble(txtInvoiceNo.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@credit", SqlDbType.Money);
				sqlParameter2.Value = num5;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Status", SqlDbType.VarChar, 10);
				sqlParameter2.Value = "Closed";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Transaction = trans_orders,
				Connection = sqlConnection2,
				CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.Int);
				sqlParameter3.Value = 5001;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
				sqlParameter3.Value = $"Supplies ({txtSupplierId.Text})";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@_date", SqlDbType.DateTime);
				sqlParameter3.Value = Convert.ToDateTime(txtInvoiceDate.Text).ToShortDateString();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 9);
				sqlParameter3.Value = Convert.ToDateTime(txtInvoiceDate.Text).ToString("MMMM");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
				sqlParameter3.Value = Convert.ToDateTime(txtInvoiceDate.Text).Year;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@debit", SqlDbType.Money);
				sqlParameter3.Value = 0;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@credit", SqlDbType.Money);
				sqlParameter3.Value = num5;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
				sqlParameter3.Value = DateTime.Now.ToOADate();
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			trans_orders.Commit();
			sqlConnection2.Close();
			CustomDialog.ShowCustomDialog("Invoice closed successfully");
			txtInvoiceNo.Text = string.Empty;
			txtSupplier.Text = string.Empty;
			txtSupplierId.Text = string.Empty;
			txtInvoiceDate.Text = string.Empty;
			gridSales.DataSource = null;
			gridViewSales.Columns.Clear();
			gridItems.DataSource = null;
			gridViewItems.Columns.Clear();
			StartTimer(timerStatus: true);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void UnclosedInvoiceExists()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT o.OrderNumber,o.SupplierID,o.date,s.Company FROM tbl_Orders o INNER JOIN tbl_Suppliers s ON s.SupplierCode=o.SupplierID WHERE o.Status='Open'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Orders");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		foreach (DataRow row in dataTable.Rows)
		{
			txtInvoiceNo.Text = row["OrderNumber"].ToString();
			txtSupplierId.Text = row["SupplierID"].ToString();
			txtInvoiceDate.Text = Convert.ToDateTime(row["date"].ToString()).ToString("dd-MMM-yy");
			txtSupplier.Text = row["Company"].ToString();
			LoadOrdersDetails(Convert.ToInt64(row["OrderNumber"].ToString()));
		}
	}

	private void gridViewSales_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "gridColNo" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gridViewItems_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "gridNO" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (string.IsNullOrEmpty(txtInvoiceNo.Text))
		{
			using (SupplierList supplierList = new SupplierList())
			{
				supplierList.ReturnSupplierDetails = SupplierCallbackFn;
				supplierList.ShowDialog();
				return;
			}
		}
		XtraMessageBox.Show("There is an unclosed invoice. Please close it first before you can start on another one.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void SupplierCallbackFn(string Supplier, string SupplierID, string InvoiceNo, string date)
	{
		txtSupplier.Text = Supplier;
		txtSupplierId.Text = SupplierID;
		txtInvoiceNo.Text = InvoiceNo;
		txtInvoiceDate.Text = date;
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		AddItemToList();
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		RemoveFromList();
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		GridViewNavigation.NavigateBack();
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		GridViewNavigation.NavigateForward();
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
		{
			if (XtraMessageBox.Show("Do you really want to cancel the current invoice?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_Orders",
				CommandType = CommandType.Text
			})
			{
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_OrderdDetails WHERE OrderNumber=@OrderNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@OrderNumber", SqlDbType.BigInt);
				sqlParameter.Value = Convert.ToInt64(txtInvoiceNo.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			CustomDialog.ShowCustomDialog("Invoice Closed Successfully.");
			txtInvoiceNo.Text = string.Empty;
			txtSupplier.Text = string.Empty;
			txtSupplierId.Text = string.Empty;
			txtInvoiceDate.Text = string.Empty;
			gridSales.DataSource = null;
			gridViewSales.Columns.Clear();
			gridItems.DataSource = null;
			gridViewItems.Columns.Clear();
			return;
		}
		XtraMessageBox.Show("Sorry! There is no invoice to cancel.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
		this.txtSupplier = new DevExpress.XtraEditors.TextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.btnRemoveItem = new DevExpress.XtraEditors.SimpleButton();
		this.btnAddToList = new DevExpress.XtraEditors.SimpleButton();
		this.gridSales = new DevExpress.XtraGrid.GridControl();
		this.gridViewSales = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColItem = new DevExpress.XtraGrid.Columns.GridColumn();
		this.txtInvoiceNo = new DevExpress.XtraEditors.TextEdit();
		this.txtSupplierId = new DevExpress.XtraEditors.TextEdit();
		this.gridItems = new DevExpress.XtraGrid.GridControl();
		this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridNO = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridItem = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridQty = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridRate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridTotal = new DevExpress.XtraGrid.Columns.GridColumn();
		this.txtInvoiceDate = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.lblNameItem = new DevExpress.XtraEditors.LabelControl();
		this.lblCodeItem = new DevExpress.XtraEditors.LabelControl();
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		((System.ComponentModel.ISupportInitialize)this.txtSupplier.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridSales).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSales).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		base.SuspendLayout();
		this.txtSupplier.Location = new System.Drawing.Point(73, 44);
		this.txtSupplier.Name = "txtSupplier";
		this.txtSupplier.Properties.ReadOnly = true;
		this.txtSupplier.Size = new System.Drawing.Size(247, 20);
		this.txtSupplier.StyleController = this.layoutControl1;
		this.txtSupplier.TabIndex = 0;
		this.layoutControl1.Controls.Add(this.btnRemoveItem);
		this.layoutControl1.Controls.Add(this.btnAddToList);
		this.layoutControl1.Controls.Add(this.gridSales);
		this.layoutControl1.Controls.Add(this.txtInvoiceNo);
		this.layoutControl1.Controls.Add(this.txtSupplierId);
		this.layoutControl1.Controls.Add(this.gridItems);
		this.layoutControl1.Controls.Add(this.txtSupplier);
		this.layoutControl1.Controls.Add(this.txtInvoiceDate);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 147);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(186, 96, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(880, 498);
		this.layoutControl1.TabIndex = 79;
		this.layoutControl1.Text = "layoutControl1";
		this.btnRemoveItem.Location = new System.Drawing.Point(447, 248);
		this.btnRemoveItem.Name = "btnRemoveItem";
		this.btnRemoveItem.Size = new System.Drawing.Size(32, 22);
		this.btnRemoveItem.StyleController = this.layoutControl1;
		this.btnRemoveItem.TabIndex = 74;
		this.btnRemoveItem.Text = "<<";
		this.btnRemoveItem.Click += new System.EventHandler(btnRemoveItem_Click);
		this.btnAddToList.Location = new System.Drawing.Point(447, 222);
		this.btnAddToList.Name = "btnAddToList";
		this.btnAddToList.Size = new System.Drawing.Size(32, 22);
		this.btnAddToList.StyleController = this.layoutControl1;
		this.btnAddToList.TabIndex = 73;
		this.btnAddToList.Text = ">>";
		this.btnAddToList.Click += new System.EventHandler(btnAddToList_Click);
		this.gridSales.Location = new System.Drawing.Point(4, 92);
		this.gridSales.MainView = this.gridViewSales;
		this.gridSales.Name = "gridSales";
		this.gridSales.Size = new System.Drawing.Size(439, 402);
		this.gridSales.TabIndex = 5;
		this.gridSales.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewSales });
		this.gridViewSales.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColNo, this.gridColumn1, this.gridColItem });
		this.gridViewSales.GridControl = this.gridSales;
		this.gridViewSales.GroupCount = 1;
		this.gridViewSales.GroupFormat = "{1} {2}";
		this.gridViewSales.Name = "gridViewSales";
		this.gridViewSales.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridViewSales.OptionsBehavior.Editable = false;
		this.gridViewSales.OptionsFind.AlwaysVisible = true;
		this.gridViewSales.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridViewSales.OptionsView.ShowGroupPanel = false;
		this.gridViewSales.OptionsView.ShowIndicator = false;
		this.gridViewSales.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridViewSales.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridViewSales_CustomColumnDisplayText);
		this.gridColNo.Caption = "#";
		this.gridColNo.Name = "gridColNo";
		this.gridColNo.Visible = true;
		this.gridColNo.VisibleIndex = 0;
		this.gridColNo.Width = 56;
		this.gridColumn1.Caption = "Category";
		this.gridColumn1.FieldName = "category";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColItem.Caption = "Item Name";
		this.gridColItem.FieldName = "AssetName";
		this.gridColItem.Name = "gridColItem";
		this.gridColItem.Visible = true;
		this.gridColItem.VisibleIndex = 1;
		this.gridColItem.Width = 1038;
		this.txtInvoiceNo.Location = new System.Drawing.Point(73, 68);
		this.txtInvoiceNo.Name = "txtInvoiceNo";
		this.txtInvoiceNo.Properties.ReadOnly = true;
		this.txtInvoiceNo.Size = new System.Drawing.Size(370, 20);
		this.txtInvoiceNo.StyleController = this.layoutControl1;
		this.txtInvoiceNo.TabIndex = 4;
		this.txtSupplierId.Location = new System.Drawing.Point(393, 44);
		this.txtSupplierId.Name = "txtSupplierId";
		this.txtSupplierId.Properties.ReadOnly = true;
		this.txtSupplierId.Size = new System.Drawing.Size(50, 20);
		this.txtSupplierId.StyleController = this.layoutControl1;
		this.txtSupplierId.TabIndex = 3;
		this.gridItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridItems.Location = new System.Drawing.Point(483, 4);
		this.gridItems.MainView = this.gridViewItems;
		this.gridItems.Name = "gridItems";
		this.gridItems.Size = new System.Drawing.Size(393, 490);
		this.gridItems.TabIndex = 1;
		this.gridItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewItems });
		this.gridViewItems.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
		this.gridViewItems.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(255, 192, 255);
		this.gridViewItems.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridViewItems.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
		this.gridViewItems.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(255, 192, 255);
		this.gridViewItems.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridViewItems.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
		this.gridViewItems.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(255, 192, 255);
		this.gridViewItems.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
		this.gridViewItems.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewItems.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridNO, this.gridItem, this.gridQty, this.gridRate, this.gridTotal });
		this.gridViewItems.GridControl = this.gridItems;
		this.gridViewItems.Name = "gridViewItems";
		this.gridViewItems.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridViewItems.OptionsBehavior.Editable = false;
		this.gridViewItems.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewItems.OptionsView.ShowFooter = true;
		this.gridViewItems.OptionsView.ShowGroupPanel = false;
		this.gridViewItems.OptionsView.ShowIndicator = false;
		this.gridViewItems.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridViewItems_CustomColumnDisplayText);
		this.gridNO.Caption = "#";
		this.gridNO.Name = "gridNO";
		this.gridNO.Visible = true;
		this.gridNO.VisibleIndex = 0;
		this.gridNO.Width = 82;
		this.gridItem.Caption = "Item";
		this.gridItem.FieldName = "AssetName";
		this.gridItem.Name = "gridItem";
		this.gridItem.Visible = true;
		this.gridItem.VisibleIndex = 1;
		this.gridItem.Width = 425;
		this.gridQty.Caption = "Qty";
		this.gridQty.FieldName = "qty";
		this.gridQty.Name = "gridQty";
		this.gridQty.Visible = true;
		this.gridQty.VisibleIndex = 2;
		this.gridQty.Width = 113;
		this.gridRate.Caption = "Rate";
		this.gridRate.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridRate.FieldName = "unitcost";
		this.gridRate.Name = "gridRate";
		this.gridRate.Visible = true;
		this.gridRate.VisibleIndex = 3;
		this.gridRate.Width = 232;
		this.gridTotal.Caption = "Total";
		this.gridTotal.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridTotal.FieldName = "Total";
		this.gridTotal.Name = "gridTotal";
		this.gridTotal.Visible = true;
		this.gridTotal.VisibleIndex = 4;
		this.gridTotal.Width = 242;
		this.txtInvoiceDate.Location = new System.Drawing.Point(4, 20);
		this.txtInvoiceDate.Name = "txtInvoiceDate";
		this.txtInvoiceDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
		this.txtInvoiceDate.Properties.ReadOnly = true;
		this.txtInvoiceDate.Size = new System.Drawing.Size(439, 20);
		this.txtInvoiceDate.StyleController = this.layoutControl1;
		this.txtInvoiceDate.TabIndex = 2;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem6, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem5, this.layoutControlItem1, this.layoutControlItem4, this.layoutControlItem8, this.layoutControlItem9 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(880, 498);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem6.Control = this.gridItems;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(479, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(397, 494);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem2.Control = this.txtSupplier;
		this.layoutControlItem2.CustomizationFormText = "Supplier";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(320, 24);
		this.layoutControlItem2.Text = "Supplier:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(65, 13);
		this.layoutControlItem3.Control = this.txtInvoiceNo;
		this.layoutControlItem3.CustomizationFormText = "Invoice #";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 64);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(443, 24);
		this.layoutControlItem3.Text = "Invoice #:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(65, 13);
		this.layoutControlItem5.Control = this.gridSales;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 88);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(443, 406);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem1.Control = this.txtInvoiceDate;
		this.layoutControlItem1.CustomizationFormText = "Date";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(443, 40);
		this.layoutControlItem1.Text = "Invoice Date:";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 13);
		this.layoutControlItem4.Control = this.txtSupplierId;
		this.layoutControlItem4.CustomizationFormText = "Code";
		this.layoutControlItem4.Location = new System.Drawing.Point(320, 40);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(123, 24);
		this.layoutControlItem4.Text = "Code:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(65, 13);
		this.layoutControlItem8.Control = this.btnAddToList;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(443, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 220, 2);
		this.layoutControlItem8.Size = new System.Drawing.Size(36, 244);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.btnRemoveItem;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(443, 244);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(36, 250);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.lblNameItem.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblNameItem.Location = new System.Drawing.Point(446, 279);
		this.lblNameItem.Name = "lblNameItem";
		this.lblNameItem.Size = new System.Drawing.Size(0, 13);
		this.lblNameItem.TabIndex = 76;
		this.lblNameItem.Visible = false;
		this.lblCodeItem.Location = new System.Drawing.Point(446, 246);
		this.lblCodeItem.Name = "lblCodeItem";
		this.lblCodeItem.Size = new System.Drawing.Size(0, 13);
		this.lblCodeItem.TabIndex = 75;
		this.lblCodeItem.Visible = false;
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[8]
		{
			this.ribbonControl1.ExpandCollapseItem,
			this.barButtonItem2,
			this.barButtonItem1,
			this.barButtonItem3,
			this.barButtonItem5,
			this.barButtonItem6,
			this.barButtonItem4,
			this.barButtonItem7
		});
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 10;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(880, 147);
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.barButtonItem2.Caption = "Close";
		this.barButtonItem2.Id = 2;
		this.barButtonItem2.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__2_;
		this.barButtonItem2.Name = "barButtonItem2";
		toolTipTitleItem.Text = "Close Invoice";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Finish and Close the current invoice.";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.barButtonItem2.SuperTip = superToolTip;
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem1.Caption = "Previous";
		this.barButtonItem1.Id = 3;
		this.barButtonItem1.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__4_;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem3.Caption = "Next";
		this.barButtonItem3.Id = 4;
		this.barButtonItem3.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__1_;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem5.Caption = "Add";
		this.barButtonItem5.Id = 6;
		this.barButtonItem5.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__3_;
		this.barButtonItem5.Name = "barButtonItem5";
		toolTipTitleItem2.Text = "Add Item";
		toolTipItem2.LeftIndent = 6;
		toolTipItem2.Text = "Add another item on the invoice.";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.barButtonItem5.SuperTip = superToolTip2;
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem6.Caption = "Remove";
		this.barButtonItem6.Id = 7;
		this.barButtonItem6.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__5_;
		this.barButtonItem6.Name = "barButtonItem6";
		toolTipTitleItem3.Text = "Remove Item";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "Remove item from the invoice.";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		this.barButtonItem6.SuperTip = superToolTip3;
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem4.Caption = "Cancel";
		this.barButtonItem4.Id = 8;
		this.barButtonItem4.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__6_;
		this.barButtonItem4.Name = "barButtonItem4";
		toolTipTitleItem4.Text = "Cancel invoice";
		toolTipItem4.LeftIndent = 6;
		toolTipItem4.Text = "Cancel the current invoice.";
		superToolTip4.Items.Add(toolTipTitleItem4);
		superToolTip4.Items.Add(toolTipItem4);
		this.barButtonItem4.SuperTip = superToolTip4;
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem7.Caption = "New Invoice";
		this.barButtonItem7.Id = 9;
		this.barButtonItem7.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.invoice__7_;
		this.barButtonItem7.Name = "barButtonItem7";
		toolTipTitleItem5.Text = "New Invoice";
		toolTipItem5.LeftIndent = 6;
		toolTipItem5.Text = "Initialize a new invoice.";
		superToolTip5.Items.Add(toolTipTitleItem5);
		superToolTip5.Items.Add(toolTipItem5);
		this.barButtonItem7.SuperTip = superToolTip5;
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[2] { this.ribbonPageGroup1, this.ribbonPageGroup2 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "ribbonPage1";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem7);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5, true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem6);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2, true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.Text = "Invoice Details";
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1, true);
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.Text = "Navigation";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(880, 645);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.lblNameItem);
		base.Controls.Add(this.lblCodeItem);
		base.Controls.Add(this.ribbonControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "ReceiveInvoices";
		this.Ribbon = this.ribbonControl1;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Receive Invoices";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ReceiveInvoices_FormClosing);
		base.Load += new System.EventHandler(ReceiveInvoices_Load);
		((System.ComponentModel.ISupportInitialize)this.txtSupplier.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridSales).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSales).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSupplierId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
