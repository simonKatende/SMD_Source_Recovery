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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.Properties;

namespace I_Xtreme.DialogForms;

public class DispenseItems : RibbonForm
{
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

	private TextEdit txtDispenseTo;

	private TextEdit txtDisID;

	private TextEdit txtTel;

	private GridControl gridSales;

	private GridView gridViewSales;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem5;

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

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem7;

	private TextEdit txtNotes;

	private LayoutControlItem layoutControlItem1;

	private TextEdit txtDate;

	private LayoutControlItem layoutControlItem7;

	public DispenseItems()
	{
		InitializeComponent();
	}

	private void LoadIssueDetails(float IssueNumber)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT o.itemId,o.auto,o.Issued AS qty,o.OldStock,s.AssetName FROM tbl_WasteDispenseDetails o INNER JOIN tbl_StockItems s ON s.id=o.itemId WHERE o.DispID='{IssueNumber}' AND JobType='Issue'", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "IssueDetails");
			dtOrdersDetails = new DataTable();
			dtOrdersDetails = dataSet.Tables[0];
			gridItems.DataSource = dtOrdersDetails.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
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
				switch (XtraMessageBox.Show("Are you sure you want to remove this item?", "School Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
				case DialogResult.Yes:
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = string.Format("DELETE FROM tbl_WasteDispenseDetails WHERE auto={0}", Convert.ToInt64(dataRow["auto"].ToString())),
						CommandType = CommandType.Text
					};
					sqlCommand.ExecuteNonQuery();
					XtraMessageBox.Show("Item has been successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					LoadIssueDetails(Convert.ToInt64(txtDisID.Text));
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
		XtraMessageBox.Show("Please select an Item from the list on the Right", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void AddItemToList()
	{
		if (gridViewSales.GetFocusedDataSourceRowIndex() > -1 && !string.IsNullOrEmpty(txtTel.Text))
		{
			DataRow dataRow = dti.Rows[gridViewSales.GetFocusedDataSourceRowIndex()];
			using AddToListDispense addToListDispense = new AddToListDispense();
			addToListDispense.txtItem.Text = dataRow["AssetName"].ToString();
			addToListDispense.txtInvoiceNo.Text = txtDisID.Text;
			addToListDispense.lblItemId.Text = dataRow["catID"].ToString();
			addToListDispense.lblQty.Text = dataRow["Qty"].ToString();
			if (addToListDispense.ShowDialog() == DialogResult.OK)
			{
				LoadIssueDetails(Convert.ToInt64(txtDisID.Text));
			}
			return;
		}
		XtraMessageBox.Show("Please select an Item from the list on the Left or Start a new voucher.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void ReceiveInvoices_Load(object sender, EventArgs e)
	{
		UnclosedIssuesExists();
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

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (!string.IsNullOrEmpty(txtTel.Text))
			{
				DialogResult dialogResult = XtraMessageBox.Show("Do you really want to close this voucher?\nNote that editing is not available after closing the voucher.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
					sqlParameter.Value = num4 - num3;
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
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "UPDATE tbl_WasteDispense SET Status=@Status WHERE DispID=@DispID",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@DispID", SqlDbType.BigInt);
				sqlParameter2.Value = Convert.ToDouble(txtDisID.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@Status", SqlDbType.VarChar, 6);
				sqlParameter2.Value = "Closed";
				sqlParameter2.Direction = ParameterDirection.Input;
				if (sqlCommand2.ExecuteNonQuery() > 0)
				{
					sqlConnection2.Close();
					CustomDialog.ShowCustomDialog("Voucher closed successfully");
					txtTel.Text = string.Empty;
					txtDispenseTo.Text = string.Empty;
					txtDisID.Text = string.Empty;
					txtDate.Text = string.Empty;
					gridSales.DataSource = null;
					gridViewSales.Columns.Clear();
					gridItems.DataSource = null;
					gridViewItems.Columns.Clear();
					StartTimer(timerStatus: true);
				}
				return;
			}
			XtraMessageBox.Show("Sorry! There is no issueing voucher to close.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void UnclosedIssuesExists()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT DispID,DispTo,Notes,Mob,_Date FROM tbl_WasteDispense WHERE Status='Open'", DataConnection.ConnectToDatabase());
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
			txtTel.Text = row["Mob"].ToString();
			txtDisID.Text = row["DispID"].ToString();
			txtDispenseTo.Text = row["DispTo"].ToString();
			txtNotes.Text = row["Notes"].ToString();
			txtDate.Text = Convert.ToDateTime(row["_Date"]).ToString("dd-MMM-yy");
			LoadIssueDetails(Convert.ToInt64(row["DispID"].ToString()));
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
		if (string.IsNullOrEmpty(txtTel.Text))
		{
			using (NewDispense newDispense = new NewDispense())
			{
				newDispense.DispenseInitialization = DispenseCallbackFn;
				newDispense.ShowDialog();
				UnclosedIssuesExists();
				return;
			}
		}
		XtraMessageBox.Show("There is an unclosed issuing voucher. Please close it first before you can start on another one.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void DispenseCallbackFn(string _name, string tel, string notes, string date)
	{
		txtDispenseTo.Text = _name;
		txtTel.Text = tel;
		txtNotes.Text = notes;
		txtDate.Text = date;
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
		if (!string.IsNullOrEmpty(txtTel.Text))
		{
			if (XtraMessageBox.Show("Do you really want to cancel the current issuing voucher?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
				CommandText = "DELETE FROM tbl_WasteDispense",
				CommandType = CommandType.Text
			})
			{
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = trans,
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_WasteDispenseDetails WHERE DispID=@DispID",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@DispID", SqlDbType.BigInt);
				sqlParameter.Value = Convert.ToInt64(txtDisID.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			CustomDialog.ShowCustomDialog("Voucher cancelled.");
			txtTel.Text = string.Empty;
			txtDate.Text = string.Empty;
			txtDispenseTo.Text = string.Empty;
			txtDisID.Text = string.Empty;
			gridSales.DataSource = null;
			gridViewSales.Columns.Clear();
			gridItems.DataSource = null;
			gridViewItems.Columns.Clear();
			return;
		}
		XtraMessageBox.Show("Sorry! There is no issuing voucher to cancel.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
		this.txtDispenseTo = new DevExpress.XtraEditors.TextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtDate = new DevExpress.XtraEditors.TextEdit();
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
		this.txtNotes = new DevExpress.XtraEditors.TextEdit();
		this.btnRemoveItem = new DevExpress.XtraEditors.SimpleButton();
		this.btnAddToList = new DevExpress.XtraEditors.SimpleButton();
		this.gridSales = new DevExpress.XtraGrid.GridControl();
		this.gridViewSales = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColItem = new DevExpress.XtraGrid.Columns.GridColumn();
		this.txtTel = new DevExpress.XtraEditors.TextEdit();
		this.txtDisID = new DevExpress.XtraEditors.TextEdit();
		this.gridItems = new DevExpress.XtraGrid.GridControl();
		this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridNO = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridItem = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridQty = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.lblNameItem = new DevExpress.XtraEditors.LabelControl();
		this.lblCodeItem = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtDispenseTo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNotes.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridSales).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSales).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDisID.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewItems).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		base.SuspendLayout();
		this.txtDispenseTo.Location = new System.Drawing.Point(100, 4);
		this.txtDispenseTo.Name = "txtDispenseTo";
		this.txtDispenseTo.Properties.ReadOnly = true;
		this.txtDispenseTo.Size = new System.Drawing.Size(343, 20);
		this.txtDispenseTo.StyleController = this.layoutControl1;
		this.txtDispenseTo.TabIndex = 0;
		this.layoutControl1.Controls.Add(this.txtDate);
		this.layoutControl1.Controls.Add(this.txtNotes);
		this.layoutControl1.Controls.Add(this.btnRemoveItem);
		this.layoutControl1.Controls.Add(this.btnAddToList);
		this.layoutControl1.Controls.Add(this.gridSales);
		this.layoutControl1.Controls.Add(this.txtTel);
		this.layoutControl1.Controls.Add(this.txtDisID);
		this.layoutControl1.Controls.Add(this.gridItems);
		this.layoutControl1.Controls.Add(this.txtDispenseTo);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 125);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(186, 96, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(880, 520);
		this.layoutControl1.TabIndex = 79;
		this.layoutControl1.Text = "layoutControl1";
		this.txtDate.Location = new System.Drawing.Point(100, 52);
		this.txtDate.MenuManager = this.ribbonControl1;
		this.txtDate.Name = "txtDate";
		this.txtDate.Properties.ReadOnly = true;
		this.txtDate.Size = new System.Drawing.Size(343, 20);
		this.txtDate.StyleController = this.layoutControl1;
		this.txtDate.TabIndex = 76;
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
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowCategoryInCaption = false;
		this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(880, 125);
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.barButtonItem2.Caption = "Close";
		this.barButtonItem2.Id = 2;
		this.barButtonItem2.Name = "barButtonItem2";
		toolTipTitleItem.Text = "Close Voucher";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Finish and Close the current voucher.";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.barButtonItem2.SuperTip = superToolTip;
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem1.Caption = "Previous";
		this.barButtonItem1.Id = 3;
		this.barButtonItem1.LargeGlyph = I_Xtreme.Properties.Resources.left_32_vc;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem3.Caption = "Next";
		this.barButtonItem3.Id = 4;
		this.barButtonItem3.LargeGlyph = I_Xtreme.Properties.Resources.right_32_vc;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem5.Caption = "Add";
		this.barButtonItem5.Id = 6;
		this.barButtonItem5.LargeGlyph = I_Xtreme.Properties.Resources.vc_Give;
		this.barButtonItem5.Name = "barButtonItem5";
		toolTipTitleItem2.Text = "Add Item";
		toolTipItem2.LeftIndent = 6;
		toolTipItem2.Text = "Add another item on the voucer.";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.barButtonItem5.SuperTip = superToolTip2;
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem6.Caption = "Remove";
		this.barButtonItem6.Id = 7;
		this.barButtonItem6.LargeGlyph = I_Xtreme.Properties.Resources.vc_Rec;
		this.barButtonItem6.Name = "barButtonItem6";
		toolTipTitleItem3.Text = "Remove Item";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "Remove item from the voucher.";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		this.barButtonItem6.SuperTip = superToolTip3;
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem4.Caption = "Cancel";
		this.barButtonItem4.Id = 8;
		this.barButtonItem4.LargeGlyph = I_Xtreme.Properties.Resources.delete_ticket_32;
		this.barButtonItem4.Name = "barButtonItem4";
		toolTipTitleItem4.Text = "Cancel Voucher";
		toolTipItem4.LeftIndent = 6;
		toolTipItem4.Text = "Cancel the current voucher.";
		superToolTip4.Items.Add(toolTipTitleItem4);
		superToolTip4.Items.Add(toolTipItem4);
		this.barButtonItem4.SuperTip = superToolTip4;
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem7.Caption = "New";
		this.barButtonItem7.Id = 9;
		this.barButtonItem7.LargeGlyph = I_Xtreme.Properties.Resources.vc_New;
		this.barButtonItem7.Name = "barButtonItem7";
		toolTipTitleItem5.Text = "New Voucher";
		toolTipItem5.LeftIndent = 6;
		toolTipItem5.Text = "Initialize a new voucher.";
		superToolTip5.Items.Add(toolTipTitleItem5);
		superToolTip5.Items.Add(toolTipItem5);
		this.barButtonItem7.SuperTip = superToolTip5;
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[2] { this.ribbonPageGroup1, this.ribbonPageGroup2 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "ribbonPage1";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem7);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5, true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem6);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2, true);
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.ShowCaptionButton = false;
		this.ribbonPageGroup1.Text = "Invoice Details";
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1, true);
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.ShowCaptionButton = false;
		this.ribbonPageGroup2.Text = "Navigation";
		this.txtNotes.Location = new System.Drawing.Point(100, 100);
		this.txtNotes.MenuManager = this.ribbonControl1;
		this.txtNotes.Name = "txtNotes";
		this.txtNotes.Properties.ReadOnly = true;
		this.txtNotes.Size = new System.Drawing.Size(343, 20);
		this.txtNotes.StyleController = this.layoutControl1;
		this.txtNotes.TabIndex = 75;
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
		this.gridSales.Location = new System.Drawing.Point(4, 124);
		this.gridSales.MainView = this.gridViewSales;
		this.gridSales.Name = "gridSales";
		this.gridSales.Size = new System.Drawing.Size(439, 392);
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
		this.txtTel.Location = new System.Drawing.Point(100, 28);
		this.txtTel.Name = "txtTel";
		this.txtTel.Properties.ReadOnly = true;
		this.txtTel.Size = new System.Drawing.Size(343, 20);
		this.txtTel.StyleController = this.layoutControl1;
		this.txtTel.TabIndex = 4;
		this.txtDisID.Location = new System.Drawing.Point(100, 76);
		this.txtDisID.Name = "txtDisID";
		this.txtDisID.Properties.MaxLength = 300;
		this.txtDisID.Properties.ReadOnly = true;
		this.txtDisID.Size = new System.Drawing.Size(343, 20);
		this.txtDisID.StyleController = this.layoutControl1;
		this.txtDisID.TabIndex = 3;
		this.gridItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridItems.Location = new System.Drawing.Point(483, 4);
		this.gridItems.MainView = this.gridViewItems;
		this.gridItems.Name = "gridItems";
		this.gridItems.Size = new System.Drawing.Size(393, 512);
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
		this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridNO, this.gridItem, this.gridQty });
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
		this.gridQty.Caption = "Qty Out";
		this.gridQty.FieldName = "qty";
		this.gridQty.Name = "gridQty";
		this.gridQty.Visible = true;
		this.gridQty.VisibleIndex = 2;
		this.gridQty.Width = 113;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.layoutControlItem6, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem5, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem4, this.layoutControlItem1, this.layoutControlItem7 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(880, 520);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem6.Control = this.gridItems;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(479, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(397, 516);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem2.Control = this.txtDispenseTo;
		this.layoutControlItem2.CustomizationFormText = "Supplier";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(443, 24);
		this.layoutControlItem2.Text = "Dispensing To:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
		this.layoutControlItem3.Control = this.txtTel;
		this.layoutControlItem3.CustomizationFormText = "Invoice #";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(443, 24);
		this.layoutControlItem3.Text = "Mob. #:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(93, 13);
		this.layoutControlItem5.Control = this.gridSales;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 120);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(443, 396);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem8.Control = this.btnAddToList;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(443, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 220, 2);
		this.layoutControlItem8.Size = new System.Drawing.Size(36, 244);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.btnRemoveItem;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(443, 244);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(36, 272);
		this.layoutControlItem9.Text = "layoutControlItem9";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextToControlDistance = 0;
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem4.Control = this.txtDisID;
		this.layoutControlItem4.CustomizationFormText = "Code";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(443, 24);
		this.layoutControlItem4.Text = "Code:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
		this.layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem1.Control = this.txtNotes;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 96);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(443, 24);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(93, 13);
		this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem7.Control = this.txtDate;
		this.layoutControlItem7.CustomizationFormText = "Date:";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(443, 24);
		this.layoutControlItem7.Text = "Date:";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(93, 13);
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
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(880, 645);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.lblNameItem);
		base.Controls.Add(this.lblCodeItem);
		base.Controls.Add(this.ribbonControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "DispenseItems";
		this.Ribbon = this.ribbonControl1;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Dispense Inventory Items";
		base.Load += new System.EventHandler(ReceiveInvoices_Load);
		((System.ComponentModel.ISupportInitialize)this.txtDispenseTo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNotes.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridSales).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewSales).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDisID.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewItems).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
