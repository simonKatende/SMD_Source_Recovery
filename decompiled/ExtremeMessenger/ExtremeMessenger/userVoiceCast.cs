using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace ExtremeMessenger;

public class userVoiceCast : XtraUserControl
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private ListBoxControl listBoxControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private SimpleButton simpleButton3;

	private TextEdit txtNewMessage;

	private TextEdit txtConnectionStatus;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem2;

	private TextBox txtMessages;

	private LayoutControlItem layoutControlItem3;

	private ListBoxControl lstViwUsers;

	private LayoutControlItem layoutControlItem7;

	private ImageList imgList;

	public userVoiceCast()
	{
		InitializeComponent();
	}

	private void userVoiceCast_Load(object sender, EventArgs e)
	{
		try
		{
			NetworkBrowser networkBrowser = new NetworkBrowser();
			foreach (string networkComputer in networkBrowser.getNetworkComputers())
			{
				listBoxControl1.Items.Add(networkComputer);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
	}

	private void listBoxControl1_DoubleClick(object sender, EventArgs e)
	{
		if (listBoxControl1.SelectedIndex != -1)
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(listBoxControl1.SelectedItem.ToString());
				IPAddress[] addressList = hostEntry.AddressList;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtremeMessenger.userVoiceCast));
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lstViwUsers = new DevExpress.XtraEditors.ListBoxControl();
		this.txtMessages = new System.Windows.Forms.TextBox();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.txtNewMessage = new DevExpress.XtraEditors.TextEdit();
		this.txtConnectionStatus = new DevExpress.XtraEditors.TextEdit();
		this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.imgList = new System.Windows.Forms.ImageList();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.lstViwUsers).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNewMessage.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtConnectionStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.lstViwUsers);
		this.layoutControl1.Controls.Add(this.txtMessages);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.simpleButton3);
		this.layoutControl1.Controls.Add(this.txtNewMessage);
		this.layoutControl1.Controls.Add(this.txtConnectionStatus);
		this.layoutControl1.Controls.Add(this.listBoxControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(1064, 789);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.lstViwUsers.Location = new System.Drawing.Point(275, 18);
		this.lstViwUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.lstViwUsers.Name = "lstViwUsers";
		this.lstViwUsers.Size = new System.Drawing.Size(250, 753);
		this.lstViwUsers.StyleController = this.layoutControl1;
		this.lstViwUsers.TabIndex = 13;
		this.txtMessages.Location = new System.Drawing.Point(531, 88);
		this.txtMessages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtMessages.Multiline = true;
		this.txtMessages.Name = "txtMessages";
		this.txtMessages.Size = new System.Drawing.Size(515, 613);
		this.txtMessages.TabIndex = 12;
		this.simpleButton1.Location = new System.Drawing.Point(531, 739);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(515, 32);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 11;
		this.simpleButton1.Text = "Send Message";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton3.Location = new System.Drawing.Point(531, 50);
		this.simpleButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(515, 32);
		this.simpleButton3.StyleController = this.layoutControl1;
		this.simpleButton3.TabIndex = 9;
		this.simpleButton3.Text = "Connect To Server";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.txtNewMessage.Location = new System.Drawing.Point(610, 707);
		this.txtNewMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtNewMessage.Name = "txtNewMessage";
		this.txtNewMessage.Size = new System.Drawing.Size(436, 26);
		this.txtNewMessage.StyleController = this.layoutControl1;
		this.txtNewMessage.TabIndex = 8;
		this.txtConnectionStatus.Location = new System.Drawing.Point(610, 18);
		this.txtConnectionStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtConnectionStatus.Name = "txtConnectionStatus";
		this.txtConnectionStatus.Size = new System.Drawing.Size(436, 26);
		this.txtConnectionStatus.StyleController = this.layoutControl1;
		this.txtConnectionStatus.TabIndex = 7;
		this.listBoxControl1.Location = new System.Drawing.Point(18, 18);
		this.listBoxControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.listBoxControl1.Name = "listBoxControl1";
		this.listBoxControl1.Size = new System.Drawing.Size(251, 753);
		this.listBoxControl1.StyleController = this.layoutControl1;
		this.listBoxControl1.TabIndex = 4;
		this.listBoxControl1.DoubleClick += new System.EventHandler(listBoxControl1_DoubleClick);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem1, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem7 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(1064, 789);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.listBoxControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(257, 759);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem4.Control = this.txtConnectionStatus;
		this.layoutControlItem4.CustomizationFormText = "Nick Name";
		this.layoutControlItem4.Location = new System.Drawing.Point(513, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(521, 32);
		this.layoutControlItem4.Text = "Nick Name";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(76, 19);
		this.layoutControlItem5.Control = this.txtNewMessage;
		this.layoutControlItem5.CustomizationFormText = "Message";
		this.layoutControlItem5.Location = new System.Drawing.Point(513, 689);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(521, 32);
		this.layoutControlItem5.Text = "Message";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(76, 19);
		this.layoutControlItem6.Control = this.simpleButton3;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(513, 32);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(521, 38);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(513, 721);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(521, 38);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.txtMessages;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(513, 70);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(521, 619);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem7.Control = this.lstViwUsers;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(257, 0);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(256, 759);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.imgList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgList.ImageStream");
		this.imgList.TransparentColor = System.Drawing.Color.Transparent;
		this.imgList.Images.SetKeyName(0, "Smiely.ico");
		this.imgList.Images.SetKeyName(1, "Private.ico");
		this.imgList.Images.SetKeyName(2, "SendMessage.ico");
		this.imgList.Images.SetKeyName(3, "Enter.ico");
		this.imgList.Images.SetKeyName(4, "Exit.ico");
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "userVoiceCast";
		base.Size = new System.Drawing.Size(1064, 789);
		base.Load += new System.EventHandler(userVoiceCast_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.lstViwUsers).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNewMessage.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtConnectionStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.listBoxControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		base.ResumeLayout(false);
	}
}
