using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class AddDebtors : XtraForm
{
	private IContainer components = null;

	private TextEdit txtName;

	private TextEdit txtTel;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private MemoEdit txtAddress;

	public AddDebtors()
	{
		InitializeComponent();
	}

	private void AddNewDebtor()
	{
		try
		{
			if (txtAddress.Text != string.Empty && txtName.Text != string.Empty && txtTel.Text != string.Empty)
			{
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = "INSERT INTO tbl_debtors (Name,Tel,Address)VALUES(@Name,@Tel,@Address)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 80);
					sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Tel", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtTel.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar, 100);
					sqlParameter.Value = txtAddress.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					base.DialogResult = DialogResult.OK;
					Close();
					return;
				}
			}
			XtraMessageBox.Show("Please input all the fields", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		AddNewDebtor();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void AddDebtors_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			AddNewDebtor();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			Close();
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
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.txtTel = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTel.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAddress.Properties).BeginInit();
		base.SuspendLayout();
		this.txtName.Location = new System.Drawing.Point(52, 12);
		this.txtName.Name = "txtName";
		this.txtName.Size = new System.Drawing.Size(230, 20);
		this.txtName.TabIndex = 0;
		this.txtTel.Location = new System.Drawing.Point(52, 38);
		this.txtTel.Name = "txtTel";
		this.txtTel.Size = new System.Drawing.Size(230, 20);
		this.txtTel.TabIndex = 1;
		this.simpleButton1.Location = new System.Drawing.Point(207, 145);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 3;
		this.simpleButton1.Text = "OK";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Location = new System.Drawing.Point(52, 145);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(75, 23);
		this.simpleButton2.TabIndex = 4;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.labelControl1.Location = new System.Drawing.Point(7, 19);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(27, 13);
		this.labelControl1.TabIndex = 5;
		this.labelControl1.Text = "Name";
		this.labelControl2.Location = new System.Drawing.Point(7, 45);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(14, 13);
		this.labelControl2.TabIndex = 6;
		this.labelControl2.Text = "Tel";
		this.labelControl3.Location = new System.Drawing.Point(7, 64);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(39, 13);
		this.labelControl3.TabIndex = 7;
		this.labelControl3.Text = "Address";
		this.txtAddress.Location = new System.Drawing.Point(52, 64);
		this.txtAddress.Name = "txtAddress";
		this.txtAddress.Size = new System.Drawing.Size(230, 75);
		this.txtAddress.TabIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 173);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtTel);
		base.Controls.Add(this.txtName);
		base.Controls.Add(this.txtAddress);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "AddDebtors";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "New Debtor";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(AddDebtors_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTel.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAddress.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
