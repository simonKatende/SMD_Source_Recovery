using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data.Mask;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace I_Xtreme;

public class AddToListDispense : XtraForm
{
	private IContainer components = null;

	private TextEdit txtQty;

	private LabelControl labelControl1;

	private LabelControl labelControl3;

	private SimpleButton btnCancel;

	private SimpleButton btnOk;

	public TextEdit txtItem;

	private Timer timer1;

	public TextEdit txtInvoiceNo;

	public LabelControl lblItemId;

	private LabelControl labelControl5;

	public LabelControl lblQty;

	private TextEdit txtRate;

	private LabelControl labelControl2;

	public AddToListDispense()
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
				CommandText = $"SELECT * FROM tbl_WasteDispenseDetails WHERE DispID='{Convert.ToInt64(txtInvoiceNo.Text)}' AND itemId={Convert.ToInt64(lblItemId.Text)} AND JobType='Issue'",
				CommandType = CommandType.Text
			};
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText = $"SELECT * FROM tbl_WasteDispenseDetails WHERE DispID='{txtInvoiceNo.Text}' AND itemId={Convert.ToInt64(lblItemId.Text)} AND JobType='Issue'";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Dispenses");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				int num = 0;
				int num2 = 0;
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["Issued"]);
					num2 = Convert.ToInt32(row["OldStock"]);
				}
				int num3 = num + Convert.ToInt32(txtQty.Text);
				if (num3 <= num2)
				{
					using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						sqlConnection2.Open();
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection2,
							CommandText = "UPDATE tbl_WasteDispenseDetails SET Issued = @Issued WHERE DispID=@DispID AND itemId=@itemId",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Issued", SqlDbType.Int);
							sqlParameter.Value = num3;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@DispID", SqlDbType.BigInt);
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
				}
				XtraMessageBox.Show("Sorry! You cannot issue quantity greater than the current stock balance.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			sqlConnection.Close();
			if (Convert.ToInt32(txtQty.Text) <= Convert.ToInt32(lblQty.Text))
			{
				using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection3.Open();
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection3,
						CommandText = "INSERT INTO tbl_WasteDispenseDetails (DispID,itemId,Issued,OldStock,JobType,UPP)VALUES(@DispID,@itemId,@Issued,@OldStock,@JobType,@UPP)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@Issued", SqlDbType.Int);
						sqlParameter2.Value = Convert.ToInt32(txtQty.Text);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@DispID", SqlDbType.BigInt);
						sqlParameter2.Value = Convert.ToInt64(txtInvoiceNo.Text);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@itemId", SqlDbType.BigInt);
						sqlParameter2.Value = Convert.ToInt64(lblItemId.Text);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@OldStock", SqlDbType.Int);
						sqlParameter2.Value = Convert.ToInt32(lblQty.Text);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@JobType", SqlDbType.VarChar, 30);
						sqlParameter2.Value = "Issue";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@UPP", SqlDbType.Money);
						sqlParameter2.Value = Convert.ToDouble(txtRate.Text);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					base.DialogResult = DialogResult.OK;
					Close();
					return;
				}
			}
			XtraMessageBox.Show("Sorry! You cannot issue quantity greater than the current stock balance.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtQty.Text == string.Empty || txtRate.Text == string.Empty)
		{
			btnOk.Enabled = false;
		}
		else
		{
			btnOk.Enabled = true;
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
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.txtQty = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
		this.btnOk = new DevExpress.XtraEditors.SimpleButton();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.txtInvoiceNo = new DevExpress.XtraEditors.TextEdit();
		this.lblItemId = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.lblQty = new DevExpress.XtraEditors.LabelControl();
		this.txtRate = new DevExpress.XtraEditors.TextEdit();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).BeginInit();
		base.SuspendLayout();
		this.txtItem.Location = new System.Drawing.Point(71, 11);
		this.txtItem.Name = "txtItem";
		this.txtItem.Properties.ReadOnly = true;
		this.txtItem.Size = new System.Drawing.Size(332, 20);
		this.txtItem.TabIndex = 0;
		this.txtItem.TabStop = false;
		this.txtQty.EditValue = "1";
		this.txtQty.EnterMoveNextControl = true;
		this.txtQty.Location = new System.Drawing.Point(71, 36);
		this.txtQty.Name = "txtQty";
		this.txtQty.Properties.Mask.EditMask = "f0";
		this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtQty.Size = new System.Drawing.Size(332, 20);
		this.txtQty.TabIndex = 0;
		this.labelControl1.Location = new System.Drawing.Point(4, 18);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(26, 13);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Item:";
		this.labelControl3.Location = new System.Drawing.Point(4, 43);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(22, 13);
		this.labelControl3.TabIndex = 5;
		this.labelControl3.Text = "Qty:";
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(211, 140);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(192, 23);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		this.btnOk.Location = new System.Drawing.Point(4, 140);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(192, 23);
		this.btnOk.TabIndex = 2;
		this.btnOk.Text = "Ok";
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.txtInvoiceNo.Location = new System.Drawing.Point(253, 85);
		this.txtInvoiceNo.Name = "txtInvoiceNo";
		this.txtInvoiceNo.Properties.ReadOnly = true;
		this.txtInvoiceNo.Size = new System.Drawing.Size(150, 20);
		this.txtInvoiceNo.TabIndex = 9;
		this.txtInvoiceNo.Visible = false;
		this.lblItemId.Location = new System.Drawing.Point(72, 87);
		this.lblItemId.Name = "lblItemId";
		this.lblItemId.Size = new System.Drawing.Size(63, 13);
		this.lblItemId.TabIndex = 10;
		this.lblItemId.Text = "labelControl5";
		this.lblItemId.Visible = false;
		this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl5.Location = new System.Drawing.Point(4, 114);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(399, 20);
		this.labelControl5.TabIndex = 11;
		this.lblQty.Location = new System.Drawing.Point(155, 87);
		this.lblQty.Name = "lblQty";
		this.lblQty.Size = new System.Drawing.Size(63, 13);
		this.lblQty.TabIndex = 12;
		this.lblQty.Text = "labelControl6";
		this.lblQty.Visible = false;
		this.txtRate.EditValue = "";
		this.txtRate.EnterMoveNextControl = true;
		this.txtRate.Location = new System.Drawing.Point(69, 60);
		this.txtRate.Name = "txtRate";
		this.txtRate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.txtRate.Properties.MaskSettings.Set("mask", "n3");
		this.txtRate.Size = new System.Drawing.Size(332, 20);
		this.txtRate.TabIndex = 13;
		this.labelControl2.Location = new System.Drawing.Point(4, 67);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(27, 13);
		this.labelControl2.TabIndex = 14;
		this.labelControl2.Text = "Rate:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(405, 175);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.txtRate);
		base.Controls.Add(this.lblQty);
		base.Controls.Add(this.labelControl5);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.lblItemId);
		base.Controls.Add(this.btnOk);
		base.Controls.Add(this.txtInvoiceNo);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtQty);
		base.Controls.Add(this.txtItem);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "AddToListDispense";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Dispense Quantity";
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtQty.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtInvoiceNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRate.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
