using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.ExtremeMessenger;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace ExtremeMessenger;

public class userInternalTexting : UserControl
{
	private SMSGateWay sMSGateWay;

	private static string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private MemoEdit txtMessage;

	private SimpleButton simpleButton1;

	private TextEdit txtReceipient;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem4;

	private LabelControl lblStatus;

	private LayoutControlItem layoutControlItem5;

	private Timer timer1;

	private LabelControl labelControl2;

	private LayoutControlItem layoutControlItem6;

	private TextEdit txtSender;

	private LayoutControlItem layoutControlItem7;

	public userInternalTexting()
	{
		InitializeComponent();
		sMSGateWay = new SMSGateWay(connectionString);
		sMSGateWay.InitializeAccount();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		try
		{
			lblStatus.Text = "";
			string recipients = "256" + txtReceipient.Text.Substring(1, 9);
			if (!sMSGateWay.TrySendSMSViaPOST(recipients, txtMessage.Text, out string error))
			{
				lblStatus.ForeColor = Color.Red;
				lblStatus.Text = error;
				return;
			}
			lblStatus.ForeColor = Color.Green;
			lblStatus.Text = $"Message sent to {recipients}.";
		}
		catch (Exception ex)
		{
			lblStatus.ForeColor = Color.Red;
			lblStatus.Text = ex.Message;
		}
	}

	public void StoreMessageToServer(string Recepient, string Subject, string MessageBody, string SentBy)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_MessageCenter (recepient,subject,body,dateSent,sentBy,processed) VALUES (@recepient,@subject,@body,@dateSent,@sentBy,@processed)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@recepient", SqlDbType.VarChar, 50);
		sqlParameter.Value = Recepient;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@subject", SqlDbType.VarChar, 50);
		sqlParameter.Value = Subject;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@body", SqlDbType.VarChar, 162);
		sqlParameter.Value = MessageBody;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@dateSent", SqlDbType.DateTime);
		sqlParameter.Value = DateTime.Now;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@sentBy", SqlDbType.VarChar, 50);
		sqlParameter.Value = SentBy;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@processed", SqlDbType.Bit);
		sqlParameter.Value = false;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			lblStatus.ForeColor = Color.Green;
			lblStatus.Text = "Message Sent Successfully.";
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (txtReceipient.Text.Length == 10 && txtMessage.Text != "")
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
		}
	}

	private void userInternalTexting_Load(object sender, EventArgs e)
	{
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
		this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtSender = new DevExpress.XtraEditors.TextEdit();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.lblStatus = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.txtReceipient = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer();
		((System.ComponentModel.ISupportInitialize)this.txtMessage.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSender.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceipient.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		base.SuspendLayout();
		this.txtMessage.Location = new System.Drawing.Point(18, 185);
		this.txtMessage.Name = "txtMessage";
		this.txtMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.txtMessage.Properties.Appearance.Options.UseFont = true;
		this.txtMessage.Size = new System.Drawing.Size(448, 433);
		this.txtMessage.StyleController = this.layoutControl1;
		this.txtMessage.TabIndex = 2;
		this.layoutControl1.Controls.Add(this.txtSender);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.lblStatus);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.txtMessage);
		this.layoutControl1.Controls.Add(this.txtReceipient);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(484, 712);
		this.layoutControl1.TabIndex = 8;
		this.layoutControl1.Text = "layoutControl1";
		this.txtSender.Location = new System.Drawing.Point(121, 86);
		this.txtSender.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtSender.Name = "txtSender";
		this.txtSender.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtSender.Properties.Appearance.Options.UseFont = true;
		this.txtSender.Properties.MaxLength = 10;
		this.txtSender.Size = new System.Drawing.Size(345, 30);
		this.txtSender.StyleController = this.layoutControl1;
		this.txtSender.TabIndex = 11;
		this.labelControl2.Location = new System.Drawing.Point(18, 61);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(447, 19);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 10;
		this.labelControl2.Text = "Receipient  must be in international format e.g. 2567XXXXXXXX";
		this.lblStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 13f);
		this.lblStatus.Appearance.Options.UseFont = true;
		this.lblStatus.Location = new System.Drawing.Point(18, 624);
		this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(448, 31);
		this.lblStatus.StyleController = this.layoutControl1;
		this.lblStatus.TabIndex = 9;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Location = new System.Drawing.Point(60, 17);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(314, 39);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 8;
		this.labelControl1.Text = "Freestyle Texting Tool";
		this.txtReceipient.Location = new System.Drawing.Point(121, 122);
		this.txtReceipient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.txtReceipient.Name = "txtReceipient";
		this.txtReceipient.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtReceipient.Properties.Appearance.Options.UseFont = true;
		this.txtReceipient.Properties.MaxLength = 10;
		this.txtReceipient.Size = new System.Drawing.Size(345, 30);
		this.txtReceipient.StyleController = this.layoutControl1;
		this.txtReceipient.TabIndex = 7;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(18, 661);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(448, 33);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Send Message";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(484, 712);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.txtMessage;
		this.layoutControlItem1.CustomizationFormText = "Message";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 140);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(454, 466);
		this.layoutControlItem1.Text = "Message";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(100, 24);
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 643);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(454, 39);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtReceipient;
		this.layoutControlItem3.CustomizationFormText = "Receipient:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 104);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(454, 36);
		this.layoutControlItem3.Text = "Receipient:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(100, 24);
		this.layoutControlItem4.Control = this.labelControl1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(45, 2, 2, 2);
		this.layoutControlItem4.Size = new System.Drawing.Size(454, 43);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.Control = this.lblStatus;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 606);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(454, 37);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.labelControl2;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 43);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(454, 25);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtSender;
		this.layoutControlItem7.CustomizationFormText = "Sender";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 68);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(454, 36);
		this.layoutControlItem7.Text = "Sender";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(100, 24);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		base.Name = "userInternalTexting";
		base.Size = new System.Drawing.Size(484, 712);
		base.Load += new System.EventHandler(userInternalTexting_Load);
		((System.ComponentModel.ISupportInitialize)this.txtMessage.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtSender.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReceipient.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		base.ResumeLayout(false);
	}
}
