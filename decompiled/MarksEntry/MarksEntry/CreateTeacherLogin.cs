using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MarksEntry;

public class CreateTeacherLogin : XtraForm
{
	public string newPassWord = string.Empty;

	public string newPassWord2 = string.Empty;

	public string userId = string.Empty;

	public string subjectId = string.Empty;

	public string classId = string.Empty;

	private IContainer components = null;

	private TextEdit txtPassword;

	private TextEdit txtPassword2;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	public TextEdit txtNewUserId;

	private Timer timer1;

	public LabelControl lblReason;

	public CreateTeacherLogin()
	{
		InitializeComponent();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		newPassWord = CryptorEngine.Encrypt(txtPassword.Text + userId.ToLower() + classId);
		newPassWord2 = txtPassword2.Text;
		base.DialogResult = DialogResult.OK;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtPassword.Text) && txtPassword.Text == txtPassword2.Text)
		{
			simpleButton2.Enabled = true;
		}
		else
		{
			simpleButton2.Enabled = false;
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
		this.txtNewUserId = new DevExpress.XtraEditors.TextEdit();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.txtPassword2 = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.lblReason = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtNewUserId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword2.Properties).BeginInit();
		base.SuspendLayout();
		this.txtNewUserId.Location = new System.Drawing.Point(105, 80);
		this.txtNewUserId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtNewUserId.Name = "txtNewUserId";
		this.txtNewUserId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNewUserId.Properties.ReadOnly = true;
		this.txtNewUserId.Size = new System.Drawing.Size(453, 52);
		this.txtNewUserId.TabIndex = 0;
		this.txtPassword.Location = new System.Drawing.Point(105, 140);
		this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Size = new System.Drawing.Size(453, 52);
		this.txtPassword.TabIndex = 1;
		this.txtPassword2.Location = new System.Drawing.Point(105, 200);
		this.txtPassword2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtPassword2.Name = "txtPassword2";
		this.txtPassword2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPassword2.Properties.UseSystemPasswordChar = true;
		this.txtPassword2.Size = new System.Drawing.Size(453, 52);
		this.txtPassword2.TabIndex = 2;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(458, 260);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(100, 65);
		this.simpleButton1.TabIndex = 3;
		this.simpleButton1.Text = "Cancel";
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(350, 260);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(100, 65);
		this.simpleButton2.TabIndex = 4;
		this.simpleButton2.Text = "Create";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.labelControl1.Location = new System.Drawing.Point(20, 113);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(45, 19);
		this.labelControl1.TabIndex = 5;
		this.labelControl1.Text = "Login:";
		this.labelControl2.Location = new System.Drawing.Point(20, 173);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(73, 19);
		this.labelControl2.TabIndex = 6;
		this.labelControl2.Text = "Password:";
		this.labelControl3.Location = new System.Drawing.Point(20, 233);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(63, 19);
		this.labelControl3.TabIndex = 7;
		this.labelControl3.Text = "Confirm:";
		this.timer1.Enabled = true;
		this.timer1.Interval = 200;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.lblReason.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.lblReason.Appearance.Options.UseBackColor = true;
		this.lblReason.Appearance.Options.UseTextOptions = true;
		this.lblReason.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.lblReason.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.lblReason.AutoEllipsis = true;
		this.lblReason.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblReason.Location = new System.Drawing.Point(20, 18);
		this.lblReason.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.lblReason.Name = "lblReason";
		this.lblReason.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
		this.lblReason.Size = new System.Drawing.Size(538, 54);
		this.lblReason.TabIndex = 9;
		this.lblReason.Text = "labelControl5";
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(569, 335);
		base.Controls.Add(this.lblReason);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtPassword2);
		base.Controls.Add(this.txtPassword);
		base.Controls.Add(this.txtNewUserId);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "CreateTeacherLogin";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Create Your Password";
		((System.ComponentModel.ISupportInitialize)this.txtNewUserId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword2.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
