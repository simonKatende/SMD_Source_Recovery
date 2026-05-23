using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme;

public class BursaryProvider : XtraForm
{
	private IContainer components = null;

	private TextEdit txtCompanyName;

	private TextEdit txtName;

	private TextEdit txtLastName;

	private TextEdit txtTel;

	private MemoEdit txtAddress;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private LabelControl labelControl4;

	private LabelControl labelControl5;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	public BursaryProvider()
	{
		InitializeComponent();
	}

	private void AddBursaryProvider()
	{
		try
		{
			if (txtCompanyName.Text != string.Empty && txtTel.Text != string.Empty)
			{
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = $"SELECT * FROM  tbl_bursaryProvider WHERE providerName='{txtCompanyName.Text.ToUpper()}'",
						CommandType = CommandType.Text
					};
					using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						sqlConnection.Close();
						XtraMessageBox.Show("The Company you provided already exists. Please use another company name.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_bursaryProvider (providerName,lastName,firstName,tel,address)VALUES(@providerName,@lastName,@firstName,@tel,@address)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@providerName", SqlDbType.VarChar, 100);
					sqlParameter.Value = txtCompanyName.Text.ToUpper();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@lastName", SqlDbType.VarChar, 50);
					sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@firstName", SqlDbType.VarChar, 50);
					sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@tel", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtTel.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@address", SqlDbType.VarChar, 100);
					sqlParameter.Value = txtAddress.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
					CustomDialog.ShowCustomDialog("Success");
					base.DialogResult = DialogResult.OK;
					Close();
					return;
				}
			}
			XtraMessageBox.Show("Please input the Organisation name and Telephone Contact", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		AddBursaryProvider();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void BursaryProvider_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void simpleButton2_Enter(object sender, EventArgs e)
	{
		AddBursaryProvider();
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
		this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.txtLastName = new DevExpress.XtraEditors.TextEdit();
		this.txtTel = new DevExpress.XtraEditors.TextEdit();
		this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.txtCompanyName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLastName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAddress.Properties).BeginInit();
		base.SuspendLayout();
		this.txtCompanyName.EnterMoveNextControl = true;
		this.txtCompanyName.Location = new System.Drawing.Point(131, 5);
		this.txtCompanyName.Name = "txtCompanyName";
		this.txtCompanyName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtCompanyName.Size = new System.Drawing.Size(251, 22);
		this.txtCompanyName.TabIndex = 0;
		this.txtName.EnterMoveNextControl = true;
		this.txtName.Location = new System.Drawing.Point(131, 28);
		this.txtName.Name = "txtName";
		this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtName.Size = new System.Drawing.Size(251, 22);
		this.txtName.TabIndex = 1;
		this.txtLastName.EnterMoveNextControl = true;
		this.txtLastName.Location = new System.Drawing.Point(131, 51);
		this.txtLastName.Name = "txtLastName";
		this.txtLastName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtLastName.Size = new System.Drawing.Size(251, 22);
		this.txtLastName.TabIndex = 2;
		this.txtTel.EnterMoveNextControl = true;
		this.txtTel.Location = new System.Drawing.Point(131, 74);
		this.txtTel.Name = "txtTel";
		this.txtTel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTel.Size = new System.Drawing.Size(251, 22);
		this.txtTel.TabIndex = 3;
		this.txtAddress.Location = new System.Drawing.Point(131, 97);
		this.txtAddress.Name = "txtAddress";
		this.txtAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAddress.Size = new System.Drawing.Size(251, 70);
		this.txtAddress.TabIndex = 4;
		this.labelControl1.Location = new System.Drawing.Point(6, 14);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(110, 13);
		this.labelControl1.TabIndex = 5;
		this.labelControl1.Text = "Company/Organisation";
		this.labelControl2.Location = new System.Drawing.Point(66, 37);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(50, 13);
		this.labelControl2.TabIndex = 6;
		this.labelControl2.Text = "First name";
		this.labelControl3.Location = new System.Drawing.Point(67, 60);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(49, 13);
		this.labelControl3.TabIndex = 7;
		this.labelControl3.Text = "Last name";
		this.labelControl4.Location = new System.Drawing.Point(102, 83);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(14, 13);
		this.labelControl4.TabIndex = 8;
		this.labelControl4.Text = "Tel";
		this.labelControl5.Location = new System.Drawing.Point(77, 130);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(39, 13);
		this.labelControl5.TabIndex = 9;
		this.labelControl5.Text = "Address";
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(206, 186);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(176, 23);
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Cancel";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(12, 186);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(176, 23);
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "OK";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton2.Enter += new System.EventHandler(simpleButton2_Enter);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(392, 216);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.labelControl5);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtAddress);
		base.Controls.Add(this.txtTel);
		base.Controls.Add(this.txtLastName);
		base.Controls.Add(this.txtName);
		base.Controls.Add(this.txtCompanyName);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Name = "BursaryProvider";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add New Bursary Provider";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(BursaryProvider_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtCompanyName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLastName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAddress.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
