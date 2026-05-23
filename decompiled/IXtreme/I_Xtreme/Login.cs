using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.DialogForms;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class Login : XtraForm
{
	private IContainer components = null;

	private TextEdit txtUserName;

	private TextEdit txtPassword;

	private SimpleButton btnCancel;

	private SimpleButton btnLogin;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private LabelControl lblStatus;

	private string TrialLicenceStatus
	{
		get
		{
			string result = "Expired";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT * FROM tbl_StudentIDSNo WHERE _vvvv='{0}'", CryptorEngine.Encrypt("MainKeyValidator")), DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SecurityCheck");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					string text = dataRow["_pppp"].ToString().Substring(39, 3);
					int result2 = (int.TryParse(text.ToString(), out result2) ? result2 : 0);
					DateTime dateTime = Convert.ToDateTime(CryptorEngine.Decrypt(dataRow["_pppppppppp"].ToString()));
					DateTime dateTime2 = Convert.ToDateTime(CryptorEngine.Decrypt(dataRow["_pppppppp"].ToString()));
					int num = (int)(DateTime.Now - dateTime2).TotalDays;
					result = ((DateTime.Now.ToOADate() < dateTime.ToOADate()) ? "Expired" : ((DateTime.Now.ToOADate() == dateTime.ToOADate()) ? "NotExpired" : ((DateTime.Now.ToOADate() > dateTime.ToOADate() && num < result2) ? "NotExpired" : ((!(DateTime.Now.ToOADate() > dateTime.ToOADate()) || num <= result2) ? "NotExpired" : "Expired"))));
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return result;
		}
	}

	public Login()
	{
		InitializeComponent();
	}

	private void LogIntoSystem()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_userLogin WHERE GroupName='Admin'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AdminUser");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM tbl_userLogin WHERE userName='{txtUserName.Text.ToLower()}'", selectConnection);
					using DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "UserLogin");
					DataTable dataTable2 = new DataTable();
					dataTable2 = dataSet2.Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						foreach (DataRow row in dataTable2.Rows)
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
								XtraMessageBox.Show("ACCESS DENIED!\nYou have entered a wrong password.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								base.DialogResult = DialogResult.None;
								btnLogin.Enabled = true;
								btnCancel.Enabled = true;
								lblStatus.Text = string.Empty;
								txtPassword.Properties.ReadOnly = false;
								txtUserName.Properties.ReadOnly = false;
								break;
							}
							SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection2.Open();
							using (SqlCommand sqlCommand2 = new SqlCommand())
							{
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
							bool result = !bool.TryParse(row["EditContact"].ToString(), out result) || result;
							CurrentUser.SetSystemUser(Convert.ToInt32(row["userId"].ToString()), row["userName"].ToString(), row["Name"].ToString(), row["GroupName"].ToString(), Convert.ToBoolean(row["ReadOnly"].ToString()), Convert.ToBoolean(row["Bill"].ToString()), Convert.ToBoolean(row["Receive"].ToString()), Convert.ToBoolean(row["Edit"].ToString()), Convert.ToBoolean(row["sAdd"].ToString()), Convert.ToBoolean(row["sEdit"].ToString()), Convert.ToBoolean(row["eDelete"].ToString()), result);
							sqlConnection2.Close();
							base.DialogResult = DialogResult.OK;
							Close();
						}
						return;
					}
					XtraMessageBox.Show("ACCESS DENIED!\nThe username you provided does not exist.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					base.DialogResult = DialogResult.None;
					btnLogin.Enabled = true;
					btnCancel.Enabled = true;
					lblStatus.Text = string.Empty;
					txtPassword.Properties.ReadOnly = false;
					txtUserName.Properties.ReadOnly = false;
					return;
				}
			}
			XtraMessageBox.Show("The system has not detected an Administrative User Account!\nPress OK to create an Administrator Account first.", "School Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			AddSuperUser addSuperUser = new AddSuperUser();
			if (addSuperUser.ShowDialog() == DialogResult.OK)
			{
				btnLogin.Enabled = true;
				btnCancel.Enabled = true;
				txtPassword.Properties.ReadOnly = false;
				txtUserName.Properties.ReadOnly = false;
				lblStatus.Text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			btnLogin.Enabled = true;
			btnCancel.Enabled = true;
			txtPassword.Properties.ReadOnly = false;
			txtUserName.Properties.ReadOnly = false;
			lblStatus.Text = string.Empty;
			using ConnectToDatabase connectToDatabase = new ConnectToDatabase();
			connectToDatabase.ShowDialog();
		}
	}

	private void ConfirmLogin()
	{
		try
		{
			btnLogin.Enabled = false;
			btnCancel.Enabled = false;
			txtPassword.Properties.ReadOnly = true;
			txtUserName.Properties.ReadOnly = true;
			lblStatus.Text = "Validating user...";
			LogIntoSystem();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			btnLogin.Enabled = true;
			btnCancel.Enabled = true;
			txtPassword.Properties.ReadOnly = false;
			txtUserName.Properties.ReadOnly = false;
			lblStatus.Text = string.Empty;
			using ConnectToDatabase connectToDatabase = new ConnectToDatabase();
			connectToDatabase.ShowDialog();
		}
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		ConfirmLogin();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Application.ExitThread();
	}

	private void Login_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			ConfirmLogin();
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
		this.txtUserName = new DevExpress.XtraEditors.TextEdit();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
		this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.lblStatus = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		base.SuspendLayout();
		this.txtUserName.EnterMoveNextControl = true;
		this.txtUserName.Location = new System.Drawing.Point(33, 51);
		this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
		this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtUserName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
		this.txtUserName.Properties.Appearance.Options.UseFont = true;
		this.txtUserName.Properties.Appearance.Options.UseForeColor = true;
		this.txtUserName.Properties.Appearance.Options.UseTextOptions = true;
		this.txtUserName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtUserName.Properties.NullText = "Username";
		this.txtUserName.Properties.NullValuePrompt = "Username";
		this.txtUserName.Size = new System.Drawing.Size(354, 26);
		this.txtUserName.TabIndex = 0;
		this.txtPassword.Location = new System.Drawing.Point(33, 95);
		this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
		this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
		this.txtPassword.Properties.Appearance.Options.UseFont = true;
		this.txtPassword.Properties.Appearance.Options.UseForeColor = true;
		this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
		this.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPassword.Properties.NullText = "Password";
		this.txtPassword.Properties.NullValuePrompt = "Password";
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Size = new System.Drawing.Size(353, 26);
		this.txtPassword.TabIndex = 1;
		this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCancel.Appearance.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.btnCancel.Appearance.Options.UseFont = true;
		this.btnCancel.Appearance.Options.UseForeColor = true;
		this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(213, 178);
		this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(105, 26);
		this.btnCancel.TabIndex = 3;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnLogin.Appearance.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
		this.btnLogin.Appearance.Options.UseFont = true;
		this.btnLogin.Appearance.Options.UseForeColor = true;
		this.btnLogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.No;
		this.btnLogin.Location = new System.Drawing.Point(102, 178);
		this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(105, 26);
		this.btnLogin.TabIndex = 2;
		this.btnLogin.Text = "Login";
		this.btnLogin.Click += new System.EventHandler(btnLogin_Click);
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.Location = new System.Drawing.Point(33, 28);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(63, 16);
		this.labelControl1.TabIndex = 11;
		this.labelControl1.Text = "Username:";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.Appearance.Options.UseForeColor = true;
		this.labelControl2.Location = new System.Drawing.Point(33, 78);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(60, 16);
		this.labelControl2.TabIndex = 12;
		this.labelControl2.Text = "Password:";
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
		this.labelControl3.Location = new System.Drawing.Point(102, 150);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(232, 10);
		this.labelControl3.TabIndex = 10;
		this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus.Appearance.ForeColor = System.Drawing.Color.White;
		this.lblStatus.Appearance.Options.UseFont = true;
		this.lblStatus.Appearance.Options.UseForeColor = true;
		this.lblStatus.Appearance.Options.UseTextOptions = true;
		this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblStatus.Location = new System.Drawing.Point(102, 125);
		this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(215, 14);
		this.lblStatus.TabIndex = 13;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
		base.BackgroundImageStore = I_Xtreme.Properties.Resources.loginShader;
		base.ClientSize = new System.Drawing.Size(408, 238);
		base.Controls.Add(this.lblStatus);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnLogin);
		base.Controls.Add(this.txtUserName);
		base.Controls.Add(this.txtPassword);
		this.DoubleBuffered = true;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		base.Name = "Login";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Login";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(Login_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
