using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using LibraryManagement.Properties;

namespace LibraryManagement;

public class Login : XtraForm
{
	private SqlTransaction trans;

	private IContainer components = null;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private TextEdit txtUserName;

	private TextEdit txtPassword;

	private SimpleButton btnCancel;

	private SimpleButton btnLogin;

	private GroupControl groupControl1;

	private PictureEdit pictureEdit1;

	private LabelControl lblStatus;

	private LabelControl labelControl3;

	public Login()
	{
		InitializeComponent();
	}

	public static string Encrypt(string inp)
	{
		using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.ASCII.GetBytes(inp);
		byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.AppendFormat("{0:x2}", array[i]);
		}
		return stringBuilder.ToString();
	}

	private void LogIntoSystem()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_userLogin WHERE userName='{txtUserName.Text.ToLower()}'", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "UserLogin");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					string arg = CryptorEngine.Encrypt(row["GroupName"].ToString().Trim() + txtUserName.Text.ToLower() + txtPassword.Text);
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = string.Format("SELECT * FROM tbl_userLogin WHERE GroupName='{0}' AND userName='{1}' AND Password='{2}'", row["GroupName"].ToString().Trim(), txtUserName.Text.ToLower().Trim(), arg),
						CommandType = CommandType.Text
					};
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						XtraMessageBox.Show("INVALID LOGIN, ACCESS DENIED!", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						base.DialogResult = DialogResult.None;
						btnLogin.Enabled = true;
						btnCancel.Enabled = true;
						lblStatus.Text = "";
						break;
					}
					SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					trans = sqlConnection2.BeginTransaction();
					using (SqlCommand sqlCommand2 = new SqlCommand())
					{
						sqlCommand2.Transaction = trans;
						sqlCommand2.Connection = sqlConnection2;
						sqlCommand2.CommandText = "INSERT INTO tbl_loginLog(userRole,userName,loginDate)VALUES(@userRole,@userName,@loginDate)";
						sqlCommand2.CommandType = CommandType.Text;
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@userRole", SqlDbType.VarChar, 50);
						sqlParameter.Value = row["GroupName"];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@userName", SqlDbType.VarChar, 50);
						sqlParameter.Value = txtUserName.Text;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@loginDate", SqlDbType.DateTime);
						sqlParameter.Value = DateTime.Now.ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand())
					{
						sqlCommand3.Transaction = trans;
						sqlCommand3.Connection = sqlConnection2;
						sqlCommand3.CommandText = "UPDATE tbl_StudentIDSNo SET _pppppppppp=@_pppppppppp WHERE _vvvv=@_vvvv";
						sqlCommand3.CommandType = CommandType.Text;
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@_pppppppppp", SqlDbType.VarChar, 50);
						sqlParameter2.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@_vvvv", SqlDbType.VarChar, 50);
						sqlParameter2.Value = CryptorEngine.Encrypt("MainKeyValidator");
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					trans.Commit();
					CurrentUser.SetSystemUser(string.Format("{0}/{1}", row["GroupName"], row["Name"]));
					sqlConnection2.Close();
					base.DialogResult = DialogResult.OK;
					Close();
				}
				return;
			}
			XtraMessageBox.Show("A user with the provided UserName does not exist. Please contact the System Administrator", "Invalid User");
			base.DialogResult = DialogResult.None;
			btnLogin.Enabled = true;
			btnCancel.Enabled = true;
			lblStatus.Text = "";
		}
		catch
		{
			XtraMessageBox.Show("CANNOT CONNECT TO THE SERVER.\nPlease enter the correct server/database parameters or check your Network Integrity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			btnLogin.Enabled = true;
			btnCancel.Enabled = true;
			lblStatus.Text = "";
			using ConnectToDatabase connectToDatabase = new ConnectToDatabase();
			connectToDatabase.ShowDialog();
		}
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		LogIntoSystem();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Application.ExitThread();
	}

	private void Login_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			LogIntoSystem();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			Application.ExitThread();
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.txtUserName = new DevExpress.XtraEditors.TextEdit();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
		this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.lblStatus = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl1.Location = new System.Drawing.Point(68, 35);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(51, 13);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "User name";
		this.labelControl2.Location = new System.Drawing.Point(68, 69);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(46, 13);
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Password";
		this.txtUserName.Location = new System.Drawing.Point(125, 32);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new System.Drawing.Size(218, 20);
		this.txtUserName.TabIndex = 0;
		this.txtPassword.Location = new System.Drawing.Point(125, 66);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Size = new System.Drawing.Size(218, 20);
		this.txtPassword.TabIndex = 1;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(205, 130);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(64, 23);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.No;
		this.btnLogin.Location = new System.Drawing.Point(275, 130);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(64, 23);
		this.btnLogin.TabIndex = 2;
		this.btnLogin.Text = "Login";
		this.btnLogin.Click += new System.EventHandler(btnLogin_Click);
		this.groupControl1.Controls.Add(this.labelControl3);
		this.groupControl1.Controls.Add(this.lblStatus);
		this.groupControl1.Controls.Add(this.pictureEdit1);
		this.groupControl1.Controls.Add(this.txtUserName);
		this.groupControl1.Controls.Add(this.btnLogin);
		this.groupControl1.Controls.Add(this.labelControl1);
		this.groupControl1.Controls.Add(this.btnCancel);
		this.groupControl1.Controls.Add(this.labelControl2);
		this.groupControl1.Controls.Add(this.txtPassword);
		this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupControl1.Location = new System.Drawing.Point(0, 0);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(348, 157);
		this.groupControl1.TabIndex = 7;
		this.groupControl1.Text = "Login";
		this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblStatus.Location = new System.Drawing.Point(125, 93);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(218, 19);
		this.lblStatus.TabIndex = 9;
		this.pictureEdit1.EditValue = LibraryManagement.Properties.Resources.Login64;
		this.pictureEdit1.Location = new System.Drawing.Point(5, 30);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(57, 61);
		this.pictureEdit1.TabIndex = 8;
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
		this.labelControl3.Visible = true;
		this.labelControl3.Location = new System.Drawing.Point(0, 113);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(348, 14);
		this.labelControl3.TabIndex = 11;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(348, 157);
		base.Controls.Add(this.groupControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.KeyPreview = true;
		base.Name = "Login";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Login";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(Login_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		this.groupControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
