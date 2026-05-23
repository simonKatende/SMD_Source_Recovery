using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.ExtremeMessenger;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace ExtremeMessenger;

public class userInternalServer : UserControl
{
	private static string connectionString = DataConnection.ConnectToDatabase();

	private SMSGateWay gateWay;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private TextEdit txtPassword;

	private TextEdit txtUsername;

	private TextEdit txtDatabase;

	private TextEdit txtServer;

	private SimpleButton simpleButton1;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private EmptySpaceItem emptySpaceItem1;

	private LabelControl labelControl4;

	private TextEdit txtLoginPassword;

	private TextEdit txtLoginID;

	private LayoutControlItem layoutUsername;

	private LayoutControlItem layoutPassword;

	private LayoutControlItem layoutControlItem13;

	private LabelControl labelControl5;

	private LayoutControlItem layoutControlItem10;

	private TextEdit txturl;

	private TextEdit txtSender;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem11;

	public userInternalServer()
	{
		InitializeComponent();
		gateWay = new SMSGateWay(connectionString);
		gateWay.InitializeAccount();
		txtDatabase.Text = DataConnection.DatabaseName();
		txtPassword.Text = DataConnection.ServerPassword();
		txtServer.Text = DataConnection.ServerName();
		txtUsername.Text = DataConnection.ServerUID();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		DataConnection.SaveConnectionString(txtDatabase.Text, txtPassword.Text, txtServer.Text, txtUsername.Text, "1433");
		gateWay.SetSMSAccount(txturl.Text, txtLoginID.Text, txtLoginPassword.Text, txtSender.Text, "EgoSMS");
	}

	private void userInternalServer_Load(object sender, EventArgs e)
	{
		txturl.Text = SMSGateWay.SMSURL;
		txtLoginID.Text = SMSGateWay.SMSUserName;
		txtLoginPassword.Text = SMSGateWay.SMSPassword;
		txtSender.Text = SMSGateWay.SMSSender;
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
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.txtLoginPassword = new DevExpress.XtraEditors.TextEdit();
		this.txtLoginID = new DevExpress.XtraEditors.TextEdit();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.txtUsername = new DevExpress.XtraEditors.TextEdit();
		this.txtDatabase = new DevExpress.XtraEditors.TextEdit();
		this.txtServer = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutUsername = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutPassword = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txtSender = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.txturl = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtLoginPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtLoginID.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUsername.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDatabase.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtServer.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutUsername).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutPassword).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSender.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txturl.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txturl);
		this.layoutControl1.Controls.Add(this.txtSender);
		this.layoutControl1.Controls.Add(this.labelControl5);
		this.layoutControl1.Controls.Add(this.labelControl4);
		this.layoutControl1.Controls.Add(this.txtLoginPassword);
		this.layoutControl1.Controls.Add(this.txtLoginID);
		this.layoutControl1.Controls.Add(this.txtPassword);
		this.layoutControl1.Controls.Add(this.txtUsername);
		this.layoutControl1.Controls.Add(this.txtDatabase);
		this.layoutControl1.Controls.Add(this.txtServer);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.labelControl3);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(484, 712);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl5.Location = new System.Drawing.Point(18, 446);
		this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(448, 19);
		this.labelControl5.StyleController = this.layoutControl1;
		this.labelControl5.TabIndex = 17;
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.Location = new System.Drawing.Point(28, 406);
		this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(408, 35);
		this.labelControl4.StyleController = this.layoutControl1;
		this.labelControl4.TabIndex = 16;
		this.labelControl4.Text = "Remote Server Connection Info.";
		this.txtLoginPassword.Location = new System.Drawing.Point(129, 601);
		this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtLoginPassword.Name = "txtLoginPassword";
		this.txtLoginPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtLoginPassword.Properties.Appearance.Options.UseFont = true;
		this.txtLoginPassword.Size = new System.Drawing.Size(338, 30);
		this.txtLoginPassword.StyleController = this.layoutControl1;
		this.txtLoginPassword.TabIndex = 15;
		this.txtLoginID.Location = new System.Drawing.Point(129, 567);
		this.txtLoginID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtLoginID.Name = "txtLoginID";
		this.txtLoginID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtLoginID.Properties.Appearance.Options.UseFont = true;
		this.txtLoginID.Size = new System.Drawing.Size(338, 30);
		this.txtLoginID.StyleController = this.layoutControl1;
		this.txtLoginID.TabIndex = 14;
		this.txtPassword.Location = new System.Drawing.Point(129, 183);
		this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtPassword.Properties.Appearance.Options.UseFont = true;
		this.txtPassword.Size = new System.Drawing.Size(338, 30);
		this.txtPassword.StyleController = this.layoutControl1;
		this.txtPassword.TabIndex = 11;
		this.txtUsername.Location = new System.Drawing.Point(129, 149);
		this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtUsername.Name = "txtUsername";
		this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtUsername.Properties.Appearance.Options.UseFont = true;
		this.txtUsername.Size = new System.Drawing.Size(338, 30);
		this.txtUsername.StyleController = this.layoutControl1;
		this.txtUsername.TabIndex = 10;
		this.txtDatabase.Location = new System.Drawing.Point(129, 115);
		this.txtDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtDatabase.Name = "txtDatabase";
		this.txtDatabase.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtDatabase.Properties.Appearance.Options.UseFont = true;
		this.txtDatabase.Size = new System.Drawing.Size(338, 30);
		this.txtDatabase.StyleController = this.layoutControl1;
		this.txtDatabase.TabIndex = 9;
		this.txtServer.Location = new System.Drawing.Point(129, 81);
		this.txtServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtServer.Name = "txtServer";
		this.txtServer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtServer.Properties.Appearance.Options.UseFont = true;
		this.txtServer.Size = new System.Drawing.Size(338, 30);
		this.txtServer.StyleController = this.layoutControl1;
		this.txtServer.TabIndex = 8;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(18, 661);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(448, 33);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 7;
		this.simpleButton1.Text = "Connect";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.labelControl3.Location = new System.Drawing.Point(18, 636);
		this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(448, 19);
		this.labelControl3.StyleController = this.layoutControl1;
		this.labelControl3.TabIndex = 6;
		this.labelControl2.Location = new System.Drawing.Point(18, 57);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(448, 19);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 5;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Location = new System.Drawing.Point(28, 17);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(375, 35);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 4;
		this.labelControl1.Text = "Local Server Connection Info.\r\n";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[15]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.emptySpaceItem1, this.layoutUsername,
			this.layoutPassword, this.layoutControlItem13, this.layoutControlItem10, this.layoutControlItem9, this.layoutControlItem11
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(484, 712);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.labelControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(13, 2, 2, 2);
		this.layoutControlItem1.Size = new System.Drawing.Size(454, 39);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.labelControl2;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 39);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(454, 25);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.labelControl3;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 618);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(454, 25);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 643);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(454, 39);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.txtServer;
		this.layoutControlItem5.CustomizationFormText = "Server Name:";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 64);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem5.Size = new System.Drawing.Size(454, 34);
		this.layoutControlItem5.Text = "Server Name:";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(106, 22);
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.txtDatabase;
		this.layoutControlItem6.CustomizationFormText = "Database:";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 98);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem6.Size = new System.Drawing.Size(454, 34);
		this.layoutControlItem6.Text = "Database:";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(106, 22);
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtUsername;
		this.layoutControlItem7.CustomizationFormText = "Username:";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 132);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem7.Size = new System.Drawing.Size(454, 34);
		this.layoutControlItem7.Text = "Username:";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(106, 22);
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.txtPassword;
		this.layoutControlItem8.CustomizationFormText = "Password:";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 166);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem8.Size = new System.Drawing.Size(454, 34);
		this.layoutControlItem8.Text = "Password:";
		this.layoutControlItem8.TextSize = new System.Drawing.Size(106, 22);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 200);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(454, 189);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutUsername.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutUsername.AppearanceItemCaption.Options.UseFont = true;
		this.layoutUsername.Control = this.txtLoginID;
		this.layoutUsername.CustomizationFormText = "Username:";
		this.layoutUsername.Location = new System.Drawing.Point(0, 550);
		this.layoutUsername.Name = "layoutUsername";
		this.layoutUsername.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutUsername.Size = new System.Drawing.Size(454, 34);
		this.layoutUsername.Text = "Username:";
		this.layoutUsername.TextSize = new System.Drawing.Size(106, 22);
		this.layoutPassword.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutPassword.AppearanceItemCaption.Options.UseFont = true;
		this.layoutPassword.Control = this.txtLoginPassword;
		this.layoutPassword.CustomizationFormText = "Password:";
		this.layoutPassword.Location = new System.Drawing.Point(0, 584);
		this.layoutPassword.Name = "layoutPassword";
		this.layoutPassword.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutPassword.Size = new System.Drawing.Size(454, 34);
		this.layoutPassword.Text = "Password:";
		this.layoutPassword.TextSize = new System.Drawing.Size(106, 22);
		this.layoutControlItem13.Control = this.labelControl4;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 389);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Padding = new DevExpress.XtraLayout.Utils.Padding(13, 2, 2, 2);
		this.layoutControlItem13.Size = new System.Drawing.Size(454, 39);
		this.layoutControlItem13.Text = "SMS Server Connection Info.";
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem10.Control = this.labelControl5;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 428);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(454, 25);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.txtSender.Location = new System.Drawing.Point(127, 532);
		this.txtSender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtSender.Name = "txtSender";
		this.txtSender.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtSender.Properties.Appearance.Options.UseFont = true;
		this.txtSender.Properties.MaxLength = 11;
		this.txtSender.Size = new System.Drawing.Size(339, 30);
		this.txtSender.StyleController = this.layoutControl1;
		this.txtSender.TabIndex = 18;
		this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem9.Control = this.txtSender;
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 514);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(454, 36);
		this.layoutControlItem9.Text = "Sender:";
		this.layoutControlItem9.TextSize = new System.Drawing.Size(106, 22);
		this.txturl.EditValue = "http://smshour.com/smsserver/bulksms-api.php";
		this.txturl.Location = new System.Drawing.Point(18, 496);
		this.txturl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txturl.Name = "txturl";
		this.txturl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txturl.Properties.Appearance.Options.UseFont = true;
		this.txturl.Size = new System.Drawing.Size(448, 30);
		this.txturl.StyleController = this.layoutControl1;
		this.txturl.TabIndex = 19;
		this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem11.Control = this.txturl;
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 453);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(454, 61);
		this.layoutControlItem11.Text = "URL:";
		this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem11.TextSize = new System.Drawing.Size(106, 22);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		base.Name = "userInternalServer";
		base.Size = new System.Drawing.Size(484, 712);
		base.Load += new System.EventHandler(userInternalServer_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtLoginPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtLoginID.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUsername.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDatabase.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtServer.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutUsername).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutPassword).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSender.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txturl.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		base.ResumeLayout(false);
	}
}
