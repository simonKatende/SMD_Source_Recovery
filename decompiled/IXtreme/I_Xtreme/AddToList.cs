using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace I_Xtreme;

public class AddToList : XtraForm
{
	private SqlTransaction trans;

	private IContainer components = null;

	private TextEdit txtUnitCost;

	private TextEdit txtQty;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private LabelControl labelControl4;

	private TextEdit txtTotal;

	private SimpleButton btnCancel;

	private SimpleButton btnOk;

	public TextEdit txtItem;

	private Timer timer1;

	public TextEdit txtInvoiceNo;

	public LabelControl lblItemId;

	private LabelControl labelControl5;

	public LabelControl lblQty;

	public AddToList()
	{
		InitializeComponent();
		txtQty.Focus();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_OrderdDetails WHERE OrderNumber='{Convert.ToInt64(txtInvoiceNo.Text)}' AND itemId={Convert.ToInt64(lblItemId.Text)}",
				CommandType = CommandType.Text
			};
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText = $"SELECT * FROM tbl_OrderdDetails WHERE OrderNumber='{txtInvoiceNo.Text}' AND itemId={Convert.ToInt64(lblItemId.Text)}";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Orders");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				int num = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["qty"]);
				}
				int num2 = num + Convert.ToInt32(txtQty.Text);
				double num3 = (double)num2 * Convert.ToDouble(txtUnitCost.Text);
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "UPDATE tbl_OrderdDetails SET qty = @qty WHERE OrderNumber=@OrderNumber AND itemId=@itemId",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@qty", SqlDbType.Int);
					sqlParameter.Value = num2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@OrderNumber", SqlDbType.BigInt);
					sqlParameter.Value = Convert.ToInt64(txtInvoiceNo.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@itemId", SqlDbType.BigInt);
					sqlParameter.Value = Convert.ToInt64(lblItemId.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
					sqlConnection2.Close();
				}
				base.DialogResult = DialogResult.OK;
				Close();
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection3.Open();
			trans = sqlConnection3.BeginTransaction();
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = "INSERT INTO tbl_OrderdDetails (OrderNumber,itemId,unitcost,qty,OldStock)VALUES(@OrderNumber,@itemId,@unitcost,@qty,@OldStock)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@qty", SqlDbType.Int);
				sqlParameter2.Value = Convert.ToInt32(txtQty.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@OrderNumber", SqlDbType.BigInt);
				sqlParameter2.Value = Convert.ToInt64(txtInvoiceNo.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@itemId", SqlDbType.BigInt);
				sqlParameter2.Value = Convert.ToInt64(lblItemId.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@unitcost", SqlDbType.Money);
				sqlParameter2.Value = Convert.ToDouble(txtUnitCost.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand3.Parameters.Add("@OldStock", SqlDbType.Int);
				sqlParameter2.Value = Convert.ToInt32(lblQty.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection3,
				Transaction = trans,
				CommandText = "INSERT INTO tbl_WasteDispenseDetails (DispID,itemId,Issued,OldStock,JobType,UPP)VALUES(@DispID,@itemId,@Issued,@OldStock,@JobType,@UPP)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter3 = sqlCommand4.Parameters.Add("@Issued", SqlDbType.Int);
				sqlParameter3.Value = Convert.ToInt32(txtQty.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@DispID", SqlDbType.BigInt);
				sqlParameter3.Value = Convert.ToInt64(txtInvoiceNo.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@itemId", SqlDbType.BigInt);
				sqlParameter3.Value = Convert.ToInt64(lblItemId.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@OldStock", SqlDbType.Int);
				sqlParameter3.Value = Convert.ToInt32(lblQty.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@JobType", SqlDbType.VarChar, 30);
				sqlParameter3.Value = "Receive";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@UPP", SqlDbType.Money);
				sqlParameter3.Value = Convert.ToDouble(txtUnitCost.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand4.ExecuteNonQuery();
				trans.Commit();
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtQty.Text == string.Empty && txtUnitCost.Text == string.Empty)
		{
			btnOk.Enabled = false;
		}
		else
		{
			btnOk.Enabled = true;
		}
	}

	private void txtUnitCost_EditValueChanged(object sender, EventArgs e)
	{
		int result = ((!int.TryParse(txtQty.Text, out result)) ? 1 : result);
		double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
		txtTotal.Text = ((double)result * result2).ToString();
	}

	private void txtQty_EditValueChanged(object sender, EventArgs e)
	{
		int result = ((!int.TryParse(txtQty.Text, out result)) ? 1 : result);
		double result2 = (double.TryParse(txtUnitCost.Text, out result2) ? result2 : 0.0);
		txtTotal.Text = ((double)result * result2).ToString();
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
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.txtUnitCost = new DevExpress.XtraEditors.TextEdit();
		this.txtQty = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.txtTotal = new DevExpress.XtraEditors.TextEdit();
		this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
		this.btnOk = new DevExpress.XtraEditors.SimpleButton();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.txtInvoiceNo = new DevExpress.XtraEditors.TextEdit();
		this.lblItemId = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.lblQty = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUnitCost.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTotal.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceNo.Properties).BeginInit();
		base.SuspendLayout();
		this.txtItem.Location = new System.Drawing.Point(71, 11);
		this.txtItem.Name = "txtItem";
		this.txtItem.Properties.ReadOnly = true;
		this.txtItem.Size = new System.Drawing.Size(332, 20);
		this.txtItem.TabIndex = 0;
		this.txtItem.TabStop = false;
		this.txtUnitCost.EditValue = "0";
		this.txtUnitCost.EnterMoveNextControl = true;
		this.txtUnitCost.Location = new System.Drawing.Point(71, 61);
		this.txtUnitCost.Name = "txtUnitCost";
		this.txtUnitCost.Properties.Mask.EditMask = "f0";
		this.txtUnitCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtUnitCost.Size = new System.Drawing.Size(332, 20);
		this.txtUnitCost.TabIndex = 1;
		this.txtUnitCost.EditValueChanged += new System.EventHandler(txtUnitCost_EditValueChanged);
		this.txtQty.EditValue = "1";
		this.txtQty.EnterMoveNextControl = true;
		this.txtQty.Location = new System.Drawing.Point(71, 36);
		this.txtQty.Name = "txtQty";
		this.txtQty.Properties.Mask.EditMask = "f";
		this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtQty.Size = new System.Drawing.Size(332, 20);
		this.txtQty.TabIndex = 0;
		this.txtQty.EditValueChanged += new System.EventHandler(txtQty_EditValueChanged);
		this.labelControl1.Location = new System.Drawing.Point(4, 18);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(26, 13);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Item:";
		this.labelControl2.Location = new System.Drawing.Point(4, 68);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(27, 13);
		this.labelControl2.TabIndex = 4;
		this.labelControl2.Text = "Rate:";
		this.labelControl3.Location = new System.Drawing.Point(4, 43);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(22, 13);
		this.labelControl3.TabIndex = 5;
		this.labelControl3.Text = "Qty:";
		this.labelControl4.Location = new System.Drawing.Point(4, 93);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(28, 13);
		this.labelControl4.TabIndex = 6;
		this.labelControl4.Text = "Total:";
		this.txtTotal.Location = new System.Drawing.Point(71, 86);
		this.txtTotal.Name = "txtTotal";
		this.txtTotal.Properties.ReadOnly = true;
		this.txtTotal.Size = new System.Drawing.Size(332, 20);
		this.txtTotal.TabIndex = 7;
		this.txtTotal.TabStop = false;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(211, 162);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(192, 23);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		this.btnOk.Location = new System.Drawing.Point(4, 162);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(192, 23);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "Ok";
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.txtInvoiceNo.Location = new System.Drawing.Point(71, 108);
		this.txtInvoiceNo.Name = "txtInvoiceNo";
		this.txtInvoiceNo.Properties.ReadOnly = true;
		this.txtInvoiceNo.Size = new System.Drawing.Size(100, 20);
		this.txtInvoiceNo.TabIndex = 9;
		this.txtInvoiceNo.Visible = false;
		this.lblItemId.Location = new System.Drawing.Point(222, 113);
		this.lblItemId.Name = "lblItemId";
		this.lblItemId.Size = new System.Drawing.Size(63, 13);
		this.lblItemId.TabIndex = 10;
		this.lblItemId.Text = "labelControl5";
		this.lblItemId.Visible = false;
		this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl5.Visible = true;
		this.labelControl5.Location = new System.Drawing.Point(4, 136);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(399, 20);
		this.labelControl5.TabIndex = 11;
		this.lblQty.Location = new System.Drawing.Point(305, 113);
		this.lblQty.Name = "lblQty";
		this.lblQty.Size = new System.Drawing.Size(63, 13);
		this.lblQty.TabIndex = 12;
		this.lblQty.Text = "labelControl6";
		this.lblQty.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(405, 190);
		base.Controls.Add(this.lblQty);
		base.Controls.Add(this.labelControl5);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.lblItemId);
		base.Controls.Add(this.btnOk);
		base.Controls.Add(this.txtInvoiceNo);
		base.Controls.Add(this.txtTotal);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtQty);
		base.Controls.Add(this.txtUnitCost);
		base.Controls.Add(this.txtItem);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "AddToList";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add to list";
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUnitCost.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTotal.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceNo.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
