using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.NavigationForms;

public class usrStockItems : XtraUserControl
{
	private DataTable dti;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private Timer timer1;

	private GridColumn gridColNo;

	private GridColumn gridColCategory;

	private GridColumn gridColName;

	private GridColumn gridColDescription;

	private GridColumn gridColQty;

	private GridColumn gridColUnitCost;

	private GridColumn gridColCostPrice;

	private GridColumn gridColCanDepreciate;

	private GridColumn gridColDepreciationRate;

	private GridColumn gridColLifeSpan;

	private GridColumn gridColAssetValue;

	public usrStockItems()
	{
		InitializeComponent();
		LoadStockItems();
	}

	public void StockTimerCallBack(bool callBackValue)
	{
		timer1.Enabled = callBackValue;
	}

	private void LoadOutstandingStock()
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(DataConnection.ConnectToDatabase(), "SELECT s.AssetName, s.Qty,o.unitcost, ISNULL(s.Qty, 0) * ISNULL(o.unitcost, 0) AS StockValue FROM  tbl_StockItems s INNER JOIN tbl_OrderdDetails o ON s.id = o.itemId");
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		foreach (DataRow row in dataTable.Rows)
		{
			using SqlConnection sqlConnection = new SqlConnection();
			sqlConnection.Open();
			using (new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO OutstandingStock (ItemId,Particulars,Units,QtyRec,RateRec,Amount,QtyIssued,RateIssued,AmountIssued,QtyBalance,AmountBalance,PhysicalStock,Variance) VALUES (@ItemId,@Particulars,@Units,@QtyRec,@RateRec,@Amount,@QtyIssued,@RateIssued,@AmountIssued,@QtyBalance,@AmountBalance,@PhysicalStock,@Variance)",
				CommandType = CommandType.Text
			})
			{
			}
		}
	}

	public void LoadStockItems()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT c.category,i.id AS catID,i.AssetName,i.Description,i.Qty,i.InitialCost,(i.Qty * i.InitialCost) AS CostPrice,i.IsDepreciable,i.DepreMethod,i.DepreRate,i.lifeSpan,i.AssetValue FROM tbl_StockItems i INNER JOIN tbl_StockCategories c ON i.category=c.id", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockItems");
			dti = new DataTable();
			dti = dataSet.Tables[0];
			gridControl1.DataSource = dti.DefaultView;
			PrintableControl.SavePrintableControl(gridControl1);
			ActiveFormSelected.SetActiveForm("Inventory Catalog");
			timer1.Enabled = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		LoadStockItems();
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "gridColNo" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (gridView1.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		try
		{
			if (gridView1.GetFocusedDataSourceRowIndex() > -1)
			{
				DataRow dataRow = dti.Rows[gridView1.GetFocusedDataSourceRowIndex()];
				InventoryItem.SetItemCategoryID(Convert.ToInt64(dataRow["catID"].ToString()), dataRow["AssetName"].ToString());
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		this.components = new System.ComponentModel.Container();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.gridColNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCategory = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColDescription = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColQty = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCostPrice = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCanDepreciate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColDepreciationRate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColLifeSpan = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColAssetValue = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
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
		this.layoutControl1.Size = new System.Drawing.Size(1338, 641);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(1334, 637);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[11]
		{
			this.gridColNo, this.gridColCategory, this.gridColName, this.gridColDescription, this.gridColQty, this.gridColUnitCost, this.gridColCostPrice, this.gridColCanDepreciate, this.gridColDepreciationRate, this.gridColLifeSpan,
			this.gridColAssetValue
		});
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.GroupFormat = "{1} {2}";
		this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AssetValue", null, "{0:#,#.0}")
		});
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsPrint.PrintHorzLines = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColCategory, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.gridColNo.Caption = "#";
		this.gridColNo.Name = "gridColNo";
		this.gridColNo.Visible = true;
		this.gridColNo.VisibleIndex = 0;
		this.gridColNo.Width = 50;
		this.gridColCategory.Caption = "Category";
		this.gridColCategory.FieldName = "category";
		this.gridColCategory.Name = "gridColCategory";
		this.gridColCategory.Visible = true;
		this.gridColCategory.VisibleIndex = 1;
		this.gridColCategory.Width = 114;
		this.gridColName.Caption = "Item";
		this.gridColName.FieldName = "AssetName";
		this.gridColName.Name = "gridColName";
		this.gridColName.Visible = true;
		this.gridColName.VisibleIndex = 1;
		this.gridColName.Width = 177;
		this.gridColDescription.Caption = "Description";
		this.gridColDescription.FieldName = "Description";
		this.gridColDescription.Name = "gridColDescription";
		this.gridColDescription.Width = 104;
		this.gridColQty.Caption = "Qty";
		this.gridColQty.FieldName = "Qty";
		this.gridColQty.Name = "gridColQty";
		this.gridColQty.Visible = true;
		this.gridColQty.VisibleIndex = 2;
		this.gridColQty.Width = 61;
		this.gridColUnitCost.Caption = "Unit Cost";
		this.gridColUnitCost.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColUnitCost.FieldName = "InitialCost";
		this.gridColUnitCost.Name = "gridColUnitCost";
		this.gridColUnitCost.Visible = true;
		this.gridColUnitCost.VisibleIndex = 3;
		this.gridColUnitCost.Width = 112;
		this.gridColCostPrice.Caption = "Total Cost";
		this.gridColCostPrice.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColCostPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColCostPrice.FieldName = "CostPrice";
		this.gridColCostPrice.Name = "gridColCostPrice";
		this.gridColCostPrice.Visible = true;
		this.gridColCostPrice.VisibleIndex = 4;
		this.gridColCostPrice.Width = 112;
		this.gridColCanDepreciate.Caption = "IsDeprec.";
		this.gridColCanDepreciate.FieldName = "IsDepreciable";
		this.gridColCanDepreciate.Name = "gridColCanDepreciate";
		this.gridColCanDepreciate.ToolTip = "Indicates whether an item is depreciable.";
		this.gridColCanDepreciate.Width = 84;
		this.gridColDepreciationRate.Caption = "Depre. Rate";
		this.gridColDepreciationRate.FieldName = "DepreRate";
		this.gridColDepreciationRate.Name = "gridColDepreciationRate";
		this.gridColDepreciationRate.ToolTip = "Depreciation Rate.";
		this.gridColDepreciationRate.Width = 86;
		this.gridColLifeSpan.Caption = "Lifespan";
		this.gridColLifeSpan.FieldName = "lifeSpan";
		this.gridColLifeSpan.Name = "gridColLifeSpan";
		this.gridColLifeSpan.ToolTip = "Lifespan of the asset (Years).";
		this.gridColLifeSpan.Width = 89;
		this.gridColAssetValue.Caption = "Asset Value";
		this.gridColAssetValue.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColAssetValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColAssetValue.FieldName = "AssetValue";
		this.gridColAssetValue.Name = "gridColAssetValue";
		this.gridColAssetValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AssetValue", "{0:#,#.0}")
		});
		this.gridColAssetValue.Width = 209;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(1338, 641);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(1338, 641);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrStockItems";
		base.Size = new System.Drawing.Size(1338, 641);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
