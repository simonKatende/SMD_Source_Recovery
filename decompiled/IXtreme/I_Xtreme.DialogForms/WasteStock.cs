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
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class WasteStock : XtraForm
{
	private DataTable dt;

	private SqlTransaction trans;

	public StartOrStopTimer StartTimer;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit textEdit3;

	private TextEdit textEdit2;

	private TextEdit textEdit1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem8;

	private GridColumn gridCategory;

	private GridColumn gridItem;

	private GridColumn gridQty;

	private TextEdit textEdit4;

	private LayoutControlItem layoutControlItem9;

	public WasteStock()
	{
		InitializeComponent();
		LoadStockItems();
	}

	private void LoadStockItems()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT c.category,i.id AS catID,i.AssetName,i.Description,i.Qty,i.InitialCost FROM tbl_StockItems i INNER JOIN tbl_StockCategories c ON i.category=c.id WHERE i.ItemType='Stock Item'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StockItems");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			textEdit1.Text = dataRow["CatID"].ToString();
			textEdit2.Text = dataRow["Qty"].ToString();
			textEdit4.Text = dataRow["AssetName"].ToString();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(textEdit3.Text))
		{
			try
			{
				int num = Convert.ToInt32(textEdit2.Text) - Convert.ToInt32(textEdit3.Text);
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_WasteDispenseDetails (JobType,itemId,Issued) VALUES (@JobType,@itemId,@Issued)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@JobType", SqlDbType.VarChar, 30);
					sqlParameter.Value = "Waste";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@itemId", SqlDbType.VarChar, 30);
					sqlParameter.Value = textEdit1.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Issued", SqlDbType.Int);
					sqlParameter.Value = Convert.ToInt32(textEdit3.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "UPDATE tbl_StockItems SET Qty=@Qty WHERE id=@id",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@id", SqlDbType.BigInt);
					sqlParameter2.Value = Convert.ToInt64(textEdit1.Text);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Qty", SqlDbType.Int);
					sqlParameter2.Value = num;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
				DialogResult dialogResult = XtraMessageBox.Show("Item wasted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				LoadStockItems();
				StartTimer(timerStatus: true);
				textEdit4.Text = string.Empty;
				textEdit1.Text = string.Empty;
				textEdit2.Text = string.Empty;
				textEdit3.Text = string.Empty;
				return;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		XtraMessageBox.Show("Either Date or Quantity is missing.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
		this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridCategory = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridItem = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridQty = new DevExpress.XtraGrid.Columns.GridColumn();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.textEdit4.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit3.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.textEdit4);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.textEdit3);
		this.layoutControl1.Controls.Add(this.textEdit2);
		this.layoutControl1.Controls.Add(this.textEdit1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(662, 482);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.textEdit4.Location = new System.Drawing.Point(71, 334);
		this.textEdit4.Name = "textEdit4";
		this.textEdit4.Properties.ReadOnly = true;
		this.textEdit4.Size = new System.Drawing.Size(589, 20);
		this.textEdit4.StyleController = this.layoutControl1;
		this.textEdit4.TabIndex = 13;
		this.textEdit4.TabStop = false;
		this.gridControl1.Location = new System.Drawing.Point(2, 18);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(658, 312);
		this.gridControl1.TabIndex = 11;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridCategory, this.gridItem, this.gridQty });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.GroupFormat = "{1} {2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridCategory, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridCategory.Caption = "Category";
		this.gridCategory.FieldName = "category";
		this.gridCategory.Name = "gridCategory";
		this.gridCategory.Visible = true;
		this.gridCategory.VisibleIndex = 0;
		this.gridCategory.Width = 364;
		this.gridItem.Caption = "Item";
		this.gridItem.FieldName = "AssetName";
		this.gridItem.Name = "gridItem";
		this.gridItem.Visible = true;
		this.gridItem.VisibleIndex = 0;
		this.gridItem.Width = 535;
		this.gridQty.Caption = "Stock Bal.";
		this.gridQty.FieldName = "Qty";
		this.gridQty.Name = "gridQty";
		this.gridQty.Visible = true;
		this.gridQty.VisibleIndex = 1;
		this.gridQty.Width = 195;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(2, 441);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(658, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 10;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(333, 458);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(327, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 9;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.Location = new System.Drawing.Point(2, 458);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(327, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 8;
		this.simpleButton1.Text = "Waste Item";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.textEdit3.EnterMoveNextControl = true;
		this.textEdit3.Location = new System.Drawing.Point(71, 406);
		this.textEdit3.Name = "textEdit3";
		this.textEdit3.Properties.Mask.EditMask = "f0";
		this.textEdit3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.textEdit3.Size = new System.Drawing.Size(589, 20);
		this.textEdit3.StyleController = this.layoutControl1;
		this.textEdit3.TabIndex = 1;
		this.textEdit2.Location = new System.Drawing.Point(71, 382);
		this.textEdit2.Name = "textEdit2";
		this.textEdit2.Properties.ReadOnly = true;
		this.textEdit2.Size = new System.Drawing.Size(589, 20);
		this.textEdit2.StyleController = this.layoutControl1;
		this.textEdit2.TabIndex = 6;
		this.textEdit2.TabStop = false;
		this.textEdit1.Location = new System.Drawing.Point(71, 358);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Properties.ReadOnly = true;
		this.textEdit1.Size = new System.Drawing.Size(589, 20);
		this.textEdit1.StyleController = this.layoutControl1;
		this.textEdit1.TabIndex = 5;
		this.textEdit1.TabStop = false;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.emptySpaceItem1, this.layoutControlItem8, this.layoutControlItem9 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(662, 482);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.textEdit1;
		this.layoutControlItem2.CustomizationFormText = "Local Code";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 356);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(662, 24);
		this.layoutControlItem2.Text = "Local Code";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 13);
		this.layoutControlItem3.Control = this.textEdit2;
		this.layoutControlItem3.CustomizationFormText = "Stock Balance";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 380);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(662, 24);
		this.layoutControlItem3.Text = "Stock Balance";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(66, 13);
		this.layoutControlItem4.Control = this.textEdit3;
		this.layoutControlItem4.CustomizationFormText = "Waste Qty";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 404);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(662, 24);
		this.layoutControlItem4.Text = "Waste Qty";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(66, 13);
		this.layoutControlItem5.Control = this.simpleButton1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 456);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(331, 26);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.simpleButton2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(331, 456);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(331, 26);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.Control = this.labelControl1;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 439);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(662, 17);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 428);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(662, 11);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.Control = this.gridControl1;
		this.layoutControlItem8.CustomizationFormText = "Stock Items";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(662, 332);
		this.layoutControlItem8.Text = "Stock Items";
		this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(66, 13);
		this.layoutControlItem9.Control = this.textEdit4;
		this.layoutControlItem9.CustomizationFormText = "Item";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 332);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(662, 24);
		this.layoutControlItem9.Text = "Item";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(66, 13);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(662, 482);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "WasteStock";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Waste Stock Item";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.textEdit4.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit3.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		base.ResumeLayout(false);
	}
}
