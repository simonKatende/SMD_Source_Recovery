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

public class itemCategories : XtraForm
{
	private DataTable d_table;

	private DataSet d_set;

	private IContainer components = null;

	private ComboBoxEdit cboCategory;

	private TextEdit txtItem;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private SimpleButton btnAdd;

	private SimpleButton simpleButton2;

	private System.Windows.Forms.Timer timer1;

	private TextEdit txtAccNo;

	public itemCategories()
	{
		InitializeComponent();
	}

	private void LoadDepartments()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_account_types at INNER JOIN tbl_generalAccounts ga ON at.categoryId = ga.categoryId WHERE at.accountName='EXPENSES'", selectConnection);
			d_set = new DataSet();
			sqlDataAdapter.Fill(d_set, "departments");
			d_table = new DataTable();
			d_table = d_set.Tables[0];
			cboCategory.Properties.Items.Clear();
			cboCategory.Properties.Items.Add("Select");
			foreach (DataRow row in d_table.Rows)
			{
				cboCategory.Properties.Items.Add(row["accName"]);
			}
			cboCategory.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtItem.Text == string.Empty || txtItem.Text.Contains("'") || cboCategory.SelectedIndex == 0)
		{
			btnAdd.Enabled = false;
		}
		else
		{
			btnAdd.Enabled = true;
		}
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * FROM tbl_SubVote WHERE accNo='{txtAccNo.Text}' AND SubVotename='{txtItem.Text}'";
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "items");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				XtraMessageBox.Show("The item you are adding to that Department already exists", "Warning");
				return;
			}
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_SubVote (accNo,SubVotename) VALUES (@accNo,@SubVotename)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.Int);
			sqlParameter.Value = Convert.ToInt32(txtAccNo.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SubVotename", SqlDbType.VarChar, 50);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtItem.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			XtraMessageBox.Show("Item successfully added", "Success");
			base.DialogResult = DialogResult.OK;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (cboCategory.SelectedIndex > 0)
			{
				DataRow dataRow = d_table.Rows[cboCategory.SelectedIndex - 1];
				txtAccNo.Text = dataRow["accNo"].ToString();
			}
			else
			{
				txtAccNo.Text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void itemCategories_Load(object sender, EventArgs e)
	{
		LoadDepartments();
	}

	private void itemCategories_FormClosed(object sender, FormClosedEventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		this.cboCategory = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.txtAccNo = new DevExpress.XtraEditors.TextEdit();
		((System.ComponentModel.ISupportInitialize)this.cboCategory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).BeginInit();
		base.SuspendLayout();
		this.cboCategory.Location = new System.Drawing.Point(67, 5);
		this.cboCategory.Name = "cboCategory";
		this.cboCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCategory.Size = new System.Drawing.Size(212, 20);
		this.cboCategory.TabIndex = 0;
		this.cboCategory.SelectedIndexChanged += new System.EventHandler(cboCategory_SelectedIndexChanged);
		this.txtItem.Location = new System.Drawing.Point(67, 31);
		this.txtItem.Name = "txtItem";
		this.txtItem.Size = new System.Drawing.Size(212, 20);
		this.txtItem.TabIndex = 1;
		this.labelControl1.Location = new System.Drawing.Point(12, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(49, 13);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Category:";
		this.labelControl2.Location = new System.Drawing.Point(12, 34);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(26, 13);
		this.labelControl2.TabIndex = 3;
		this.labelControl2.Text = "Item:";
		this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnAdd.Location = new System.Drawing.Point(221, 57);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Size = new System.Drawing.Size(58, 23);
		this.btnAdd.TabIndex = 4;
		this.btnAdd.Text = "Add Item";
		this.btnAdd.Click += new System.EventHandler(btnAdd_Click);
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(67, 57);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(59, 23);
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "Close";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.txtAccNo.Location = new System.Drawing.Point(133, 59);
		this.txtAccNo.Name = "txtAccNo";
		this.txtAccNo.Properties.ReadOnly = true;
		this.txtAccNo.Size = new System.Drawing.Size(82, 20);
		this.txtAccNo.TabIndex = 6;
		this.txtAccNo.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 85);
		base.Controls.Add(this.txtAccNo);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.btnAdd);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtItem);
		base.Controls.Add(this.cboCategory);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "itemCategories";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = " Add Items";
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(itemCategories_FormClosed);
		base.Load += new System.EventHandler(itemCategories_Load);
		((System.ComponentModel.ISupportInitialize)this.cboCategory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
