using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace AlienAge.Connectivity;

public class ConnectToDatabase : XtraForm
{
	private string baseIP = NetworkBrowser.GetBaseIpAddress();

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private TextEdit txtPassword;

	private TextEdit txtUserId;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private SimpleButton btnCreateConnection;

	private LayoutControlItem layoutControlItem7;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem8;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private EmptySpaceItem emptySpaceItem1;

	private ToolTipController toolTipController1;

	private DefaultToolTipController defaultToolTipController1;

	private ComboBoxEdit txtServerAddress;

	private ComboBoxEdit txtDabaseName;

	public ConnectToDatabase()
	{
		InitializeComponent();
	}

	private void EnterServerParameters()
	{
		DataConnection.SaveConnectionString(txtDabaseName.Text, txtPassword.Text, txtServerAddress.Text, txtUserId.Text, "1433");
		if (DataConnection.DatabaseConnected())
		{
			base.DialogResult = DialogResult.OK;
			DataConnection.SaveConnectionStringL(txtDabaseName.Text, txtPassword.Text, txtServerAddress.Text, txtUserId.Text, "1433");
			Close();
		}
		else
		{
			XtraMessageBox.Show("Connection to database not successful", "Invalid Connection Parameters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void btnCreateConnection_Click(object sender, EventArgs e)
	{
		EnterServerParameters();
	}

	private void connectivity_Load(object sender, EventArgs e)
	{
		txtServerAddress.Text = DataConnection.ServerName();
		txtDabaseName.Text = DataConnection.DatabaseName();
		txtUserId.Text = DataConnection.ServerUID();
		txtPassword.Text = DataConnection.ServerPassword();
	}

	private void connectToDatabase_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			EnterServerParameters();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void txtDabaseName_QueryPopUp(object sender, CancelEventArgs e)
	{
		List<string> databases = NetworkBrowser.GetDatabases(txtServerAddress.Text, txtUserId.Text, txtPassword.Text);
		if (databases == null || databases.Count == 0)
		{
			e.Cancel = true;
			return;
		}
		for (int i = 0; i < databases.Count; i++)
		{
			txtDabaseName.Properties.Items.Add(databases[i]);
		}
	}

	private void txtServerAddress_QueryPopUp(object sender, CancelEventArgs e)
	{
		if (baseIP == "No IPAddress")
		{
			string machineName = Environment.MachineName;
			txtServerAddress.Properties.Items.Clear();
			txtServerAddress.Properties.Items.Add(machineName);
			return;
		}
		List<string> networkComputerNamesUsingPing = NetworkBrowser.GetNetworkComputerNamesUsingPing(baseIP);
		if (networkComputerNamesUsingPing == null || networkComputerNamesUsingPing.Count == 0)
		{
			e.Cancel = true;
			return;
		}
		txtServerAddress.Properties.Items.Clear();
		for (int i = 0; i < networkComputerNamesUsingPing.Count; i++)
		{
			txtServerAddress.Properties.Items.Add(networkComputerNamesUsingPing[i].ToString());
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
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.btnCreateConnection = new DevExpress.XtraEditors.SimpleButton();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.txtUserId = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
		this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
		this.txtServerAddress = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtDabaseName = new DevExpress.XtraEditors.ComboBoxEdit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtServerAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDabaseName.Properties).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.btnCreateConnection);
		this.layoutControl1.Controls.Add(this.txtPassword);
		this.layoutControl1.Controls.Add(this.txtUserId);
		this.layoutControl1.Controls.Add(this.txtServerAddress);
		this.layoutControl1.Controls.Add(this.txtDabaseName);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(412, 243);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
		this.labelControl2.Location = new System.Drawing.Point(1, 1);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(400, 48);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 13;
		this.labelControl2.Text = "To use this software, you must connect to the Sql database hosted on\r\nyour local server.\r\nEnter the information below to connect to the database";
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.LineVisible = true;
		this.labelControl1.Location = new System.Drawing.Point(1, 167);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(410, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 12;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(196, 219);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(215, 23);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 11;
		this.simpleButton1.Text = "Cancel";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.btnCreateConnection.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreateConnection.Appearance.Options.UseFont = true;
		this.btnCreateConnection.Location = new System.Drawing.Point(1, 219);
		this.btnCreateConnection.Name = "btnCreateConnection";
		this.btnCreateConnection.Size = new System.Drawing.Size(193, 23);
		this.btnCreateConnection.StyleController = this.layoutControl1;
		this.btnCreateConnection.TabIndex = 10;
		this.btnCreateConnection.Text = "Connect";
		this.btnCreateConnection.Click += new System.EventHandler(btnCreateConnection_Click);
		this.txtPassword.Location = new System.Drawing.Point(179, 95);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPassword.Size = new System.Drawing.Size(232, 22);
		this.txtPassword.StyleController = this.layoutControl1;
		toolTipTitleItem.Text = "Password";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "The   password of the sql server instance installed on your server computer";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.txtPassword.SuperTip = superToolTip;
		this.txtPassword.TabIndex = 7;
		this.txtUserId.Location = new System.Drawing.Point(179, 119);
		this.txtUserId.Name = "txtUserId";
		this.txtUserId.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtUserId.Size = new System.Drawing.Size(232, 22);
		this.txtUserId.StyleController = this.layoutControl1;
		toolTipTitleItem2.Text = "Login";
		toolTipItem2.LeftIndent = 6;
		toolTipItem2.Text = "The   user id/login of the sql server instance installed on your server computer";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.txtUserId.SuperTip = superToolTip2;
		this.txtUserId.TabIndex = 6;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[9] { this.layoutControlItem8, this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem5, this.layoutControlItem6, this.emptySpaceItem1, this.layoutControlItem7, this.layoutControlItem4, this.layoutControlItem3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(412, 243);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem8.Control = this.simpleButton1;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(195, 218);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(217, 25);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.txtServerAddress;
		this.layoutControlItem1.CustomizationFormText = "Server";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 50);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(412, 44);
		this.layoutControlItem1.Text = "Server Name/IP Address:";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(168, 18);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtDabaseName;
		this.layoutControlItem2.CustomizationFormText = "Database";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 142);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 1, 1, 1);
		this.layoutControlItem2.Size = new System.Drawing.Size(412, 24);
		this.layoutControlItem2.Text = "Database:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(168, 18);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtUserId;
		this.layoutControlItem3.CustomizationFormText = "UserId";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 118);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 1, 1, 1);
		this.layoutControlItem3.Size = new System.Drawing.Size(412, 24);
		this.layoutControlItem3.Text = "Login :";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(168, 18);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtPassword;
		this.layoutControlItem4.CustomizationFormText = "Password";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 94);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 1, 1, 1);
		this.layoutControlItem4.Size = new System.Drawing.Size(412, 24);
		this.layoutControlItem4.Text = "Password:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(168, 18);
		this.layoutControlItem5.Control = this.labelControl1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 166);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(412, 15);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(192, 192, 0);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseBackColor = true;
		this.layoutControlItem6.Control = this.labelControl2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(412, 50);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 181);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(412, 37);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.Control = this.btnCreateConnection;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 218);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(195, 25);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.txtServerAddress.Location = new System.Drawing.Point(1, 71);
		this.txtServerAddress.Name = "txtServerAddress";
		this.txtServerAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtServerAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtServerAddress.Size = new System.Drawing.Size(410, 22);
		this.txtServerAddress.StyleController = this.layoutControl1;
		toolTipTitleItem3.Text = "Server Name/IP Address";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "Server Name/IP Address: This is the the name or IP Address of the computer working as your server.";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		this.txtServerAddress.SuperTip = superToolTip3;
		this.txtServerAddress.TabIndex = 4;
		this.txtServerAddress.QueryPopUp += new System.ComponentModel.CancelEventHandler(txtServerAddress_QueryPopUp);
		this.txtDabaseName.Location = new System.Drawing.Point(179, 143);
		this.txtDabaseName.Name = "txtDabaseName";
		this.txtDabaseName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDabaseName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtDabaseName.Size = new System.Drawing.Size(232, 22);
		this.txtDabaseName.StyleController = this.layoutControl1;
		toolTipTitleItem4.Text = "Database";
		toolTipItem4.LeftIndent = 6;
		toolTipItem4.Text = "Name of the sql server database hosted on your server computer";
		superToolTip4.Items.Add(toolTipTitleItem4);
		superToolTip4.Items.Add(toolTipItem4);
		this.txtDabaseName.SuperTip = superToolTip4;
		this.txtDabaseName.TabIndex = 5;
		this.txtDabaseName.QueryPopUp += new System.ComponentModel.CancelEventHandler(txtDabaseName_QueryPopUp);
		this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(412, 243);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "ConnectToDatabase";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Connect to database";
		base.Load += new System.EventHandler(connectivity_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(connectToDatabase_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtServerAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDabaseName.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
