using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class SupplierList : XtraForm
{
	private DataTable dt;

	public InitializeNewSupplierInvoice ReturnSupplierDetails;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private GridColumn gridColNo;

	private GridColumn gridColCode;

	private GridColumn gridColCompany;

	private GridColumn gridColContacPeson;

	private GridColumn gridColMobile;

	private DateEdit dtDate;

	private LayoutControlItem layoutControlItem5;

	private float InvoiceNo
	{
		get
		{
			float result = 0f;
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT OrderNumber FROM tbl_Orders WHERE Status='Open'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "InvoiceNo");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				result = Convert.ToInt64(row["OrderNumber"].ToString());
			}
			return result;
		}
	}

	public SupplierList()
	{
		InitializeComponent();
		LoadSupplierList();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() <= -1)
		{
			return;
		}
		if (dtDate.EditValue != null)
		{
			DataRow dataRow = dt.Rows[gridView1.GetFocusedDataSourceRowIndex()];
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_Orders (SupplierID,Particulars,date,Status) VALUES (@SupplierID,@Particulars,@date,@Status)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SupplierID", SqlDbType.BigInt);
			sqlParameter.Value = Convert.ToInt64(dataRow["Code"].ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
			sqlParameter.Value = "Supplies";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
			sqlParameter.Value = dtDate.DateTime.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 10);
			sqlParameter.Value = "Open";
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				ReturnSupplierDetails(dataRow["Company"].ToString(), dataRow["Code"].ToString(), InvoiceNo.ToString(), dtDate.DateTime.ToString("dd-MMM-yy"));
				Close();
			}
			return;
		}
		dtDate.BackColor = Color.Red;
		dtDate.Focus();
	}

	private void LoadSupplierList()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SupplierCode AS Code,Company,(Surname + ' ' + OtherNames) AS ContactPerson,Mobile FROM tbl_Suppliers", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Suppliers");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl1.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "gridColNo" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void dtDate_Closed(object sender, ClosedEventArgs e)
	{
		dtDate.BackColor = Color.WhiteSmoke;
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
		this.dtDate = new DevExpress.XtraEditors.DateEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCode = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColCompany = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColContacPeson = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColMobile = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.dtDate);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(599, 495);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.dtDate.EditValue = null;
		this.dtDate.Location = new System.Drawing.Point(2, 18);
		this.dtDate.Name = "dtDate";
		this.dtDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
		this.dtDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
		this.dtDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtDate.Size = new System.Drawing.Size(595, 20);
		this.dtDate.StyleController = this.layoutControl1;
		this.dtDate.TabIndex = 8;
		this.dtDate.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(dtDate_Closed);
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(301, 471);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(296, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.Location = new System.Drawing.Point(2, 471);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(295, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Select Supplier";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.gridControl1.Location = new System.Drawing.Point(2, 42);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(595, 425);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColNo, this.gridColCode, this.gridColCompany, this.gridColContacPeson, this.gridColMobile });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.gridColNo.Caption = "#";
		this.gridColNo.Name = "gridColNo";
		this.gridColNo.Visible = true;
		this.gridColNo.VisibleIndex = 0;
		this.gridColNo.Width = 60;
		this.gridColCode.Caption = "Code";
		this.gridColCode.FieldName = "Code";
		this.gridColCode.Name = "gridColCode";
		this.gridColCode.Visible = true;
		this.gridColCode.VisibleIndex = 1;
		this.gridColCode.Width = 79;
		this.gridColCompany.Caption = "Company";
		this.gridColCompany.FieldName = "Company";
		this.gridColCompany.Name = "gridColCompany";
		this.gridColCompany.Visible = true;
		this.gridColCompany.VisibleIndex = 2;
		this.gridColCompany.Width = 383;
		this.gridColContacPeson.Caption = "Contact Person";
		this.gridColContacPeson.FieldName = "ContactPerson";
		this.gridColContacPeson.Name = "gridColContacPeson";
		this.gridColContacPeson.Visible = true;
		this.gridColContacPeson.VisibleIndex = 3;
		this.gridColContacPeson.Width = 362;
		this.gridColMobile.Caption = "Mobile#";
		this.gridColMobile.FieldName = "Mobile";
		this.gridColMobile.Name = "gridColMobile";
		this.gridColMobile.Visible = true;
		this.gridColMobile.VisibleIndex = 4;
		this.gridColMobile.Width = 194;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem5 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(599, 495);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(599, 429);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 469);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(299, 26);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton2;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(299, 469);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(300, 26);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem5.Control = this.dtDate;
		this.layoutControlItem5.CustomizationFormText = "Invoice Date:";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(599, 40);
		this.layoutControlItem5.Text = "Invoice Date:";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(65, 13);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(599, 495);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "SupplierList";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Select Supplier";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		base.ResumeLayout(false);
	}
}
