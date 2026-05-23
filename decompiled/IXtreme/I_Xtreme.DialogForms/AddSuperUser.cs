using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AddSuperUser : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit txtConfirm;

	private TextEdit txtPassword;

	private TextEdit txtFullName;

	private TextEdit txtUserName;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem8;

	private DXValidationProvider dxValidationProvider1;

	public AddSuperUser()
	{
		InitializeComponent();
	}

	private void CreateSuperUser()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_userLogin (Name,GroupName,userName,Password,ReadOnly,Bill,Receive,Edit,sAdd,sEdit,eDelete,EditContact)VALUES(@Name,@GroupName,@userName,@Password,@ReadOnly,@Bill,@Receive,@Edit,@sAdd,@sEdit,@eDelete,@EditContact)",
				CommandType = CommandType.Text
			};
			string text = "Admin";
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 70);
			sqlParameter.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtFullName.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@GroupName", SqlDbType.VarChar, 50);
			sqlParameter.Value = "Admin";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@userName", SqlDbType.VarChar, 50);
			sqlParameter.Value = txtUserName.Text.ToLower();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar, 100);
			sqlParameter.Value = CryptorEngine.Encrypt(text + txtUserName.Text.ToLower() + txtPassword.Text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ReadOnly", SqlDbType.Bit);
			sqlParameter.Value = false;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Bill", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Receive", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Edit", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@sAdd", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@sEdit", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@eDelete", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@EditContact", SqlDbType.Bit);
			sqlParameter.Value = true;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
				XtraMessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (txtFullName.Text != string.Empty && txtUserName.Text != string.Empty && txtPassword.Text != string.Empty)
		{
			if (txtPassword.Text == txtConfirm.Text)
			{
				CreateSuperUser();
			}
			else
			{
				dxValidationProvider1.Validate(txtConfirm);
			}
		}
		else
		{
			dxValidationProvider1.Validate(txtFullName);
			dxValidationProvider1.Validate(txtUserName);
			dxValidationProvider1.Validate(txtPassword);
		}
	}

	private void txtFullName_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtFullName);
	}

	private void txtUserName_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtUserName);
	}

	private void txtPassword_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtPassword);
	}

	private void txtConfirm_TextChanged(object sender, EventArgs e)
	{
		dxValidationProvider1.RemoveControlError(txtConfirm);
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.txtUserName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtFullName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtConfirm = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFullName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtConfirm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtConfirm);
		this.layoutControl1.Controls.Add(this.txtPassword);
		this.layoutControl1.Controls.Add(this.txtFullName);
		this.layoutControl1.Controls.Add(this.txtUserName);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(394, 189);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.layoutControlItem2, this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.emptySpaceItem1, this.layoutControlItem8 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(394, 189);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.txtUserName.EnterMoveNextControl = true;
		this.dxValidationProvider1.SetIconAlignment(this.txtUserName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtUserName.Location = new System.Drawing.Point(60, 55);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Properties.MaxLength = 50;
		this.txtUserName.Properties.ValidateOnEnterKey = true;
		this.txtUserName.Size = new System.Drawing.Size(332, 20);
		this.txtUserName.StyleController = this.layoutControl1;
		this.txtUserName.TabIndex = 1;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "Username is required";
		this.dxValidationProvider1.SetValidationRule(this.txtUserName, conditionValidationRule);
		this.txtUserName.TextChanged += new System.EventHandler(txtUserName_TextChanged);
		this.layoutControlItem1.Control = this.txtUserName;
		this.layoutControlItem1.CustomizationFormText = "Username:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 53);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem1.Size = new System.Drawing.Size(394, 24);
		this.layoutControlItem1.Text = "Username:";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 13);
		this.txtFullName.EnterMoveNextControl = true;
		this.dxValidationProvider1.SetIconAlignment(this.txtFullName, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtFullName.Location = new System.Drawing.Point(60, 31);
		this.txtFullName.Name = "txtFullName";
		this.txtFullName.Properties.MaxLength = 70;
		this.txtFullName.Properties.ValidateOnEnterKey = true;
		this.txtFullName.Size = new System.Drawing.Size(332, 20);
		this.txtFullName.StyleController = this.layoutControl1;
		this.txtFullName.TabIndex = 0;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "Full Name is required";
		this.dxValidationProvider1.SetValidationRule(this.txtFullName, conditionValidationRule2);
		this.txtFullName.TextChanged += new System.EventHandler(txtFullName_TextChanged);
		this.layoutControlItem2.Control = this.txtFullName;
		this.layoutControlItem2.CustomizationFormText = "Full Name:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 29);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem2.Size = new System.Drawing.Size(394, 24);
		this.layoutControlItem2.Text = "Full Name:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(52, 13);
		this.txtPassword.EnterMoveNextControl = true;
		this.dxValidationProvider1.SetIconAlignment(this.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtPassword.Location = new System.Drawing.Point(60, 79);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Properties.ValidateOnEnterKey = true;
		this.txtPassword.Size = new System.Drawing.Size(332, 20);
		this.txtPassword.StyleController = this.layoutControl1;
		this.txtPassword.TabIndex = 2;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "Password is required";
		this.dxValidationProvider1.SetValidationRule(this.txtPassword, conditionValidationRule3);
		this.txtPassword.TextChanged += new System.EventHandler(txtPassword_TextChanged);
		this.layoutControlItem3.Control = this.txtPassword;
		this.layoutControlItem3.CustomizationFormText = "Password:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 77);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem3.Size = new System.Drawing.Size(394, 24);
		this.layoutControlItem3.Text = "Password:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 13);
		this.txtConfirm.EnterMoveNextControl = true;
		this.dxValidationProvider1.SetIconAlignment(this.txtConfirm, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtConfirm.Location = new System.Drawing.Point(60, 103);
		this.txtConfirm.Name = "txtConfirm";
		this.txtConfirm.Properties.UseSystemPasswordChar = true;
		this.txtConfirm.Properties.ValidateOnEnterKey = true;
		this.txtConfirm.Size = new System.Drawing.Size(332, 20);
		this.txtConfirm.StyleController = this.layoutControl1;
		this.txtConfirm.TabIndex = 3;
		compareAgainstControlValidationRule.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Equals;
		compareAgainstControlValidationRule.Control = this.txtPassword;
		compareAgainstControlValidationRule.ErrorText = "The passwords do not match";
		this.dxValidationProvider1.SetValidationRule(this.txtConfirm, compareAgainstControlValidationRule);
		this.txtConfirm.TextChanged += new System.EventHandler(txtConfirm_TextChanged);
		this.layoutControlItem4.Control = this.txtConfirm;
		this.layoutControlItem4.CustomizationFormText = "Confirm:";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 101);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem4.Size = new System.Drawing.Size(394, 24);
		this.layoutControlItem4.Text = "Confirm:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(52, 13);
		this.simpleButton1.Location = new System.Drawing.Point(2, 165);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(207, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 4;
		this.simpleButton1.Text = "Create User";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControlItem5.Control = this.simpleButton1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 163);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(211, 26);
		this.layoutControlItem5.Text = "layoutControlItem5";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(213, 165);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(179, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "Cancel";
		this.layoutControlItem6.Control = this.simpleButton2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(211, 163);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(183, 26);
		this.layoutControlItem6.Text = "layoutControlItem6";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(2, 127);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(390, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 10;
		this.layoutControlItem7.Control = this.labelControl1;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 125);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(394, 17);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 142);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(394, 21);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Visible = true;
		this.labelControl2.Location = new System.Drawing.Point(5, 5);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(384, 19);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 11;
		this.labelControl2.Text = "Create super user account";
		this.layoutControlItem8.Control = this.labelControl2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
		this.layoutControlItem8.Size = new System.Drawing.Size(394, 29);
		this.layoutControlItem8.Text = "layoutControlItem8";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextToControlDistance = 0;
		this.layoutControlItem8.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(394, 189);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "AddSuperUser";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Create Super User";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFullName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtConfirm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
