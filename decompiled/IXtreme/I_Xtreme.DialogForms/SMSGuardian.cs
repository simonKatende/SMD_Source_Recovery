using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.ReportHeaders;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme.DialogForms;

public class SMSGuardian : XtraForm
{
	private string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private MemoEdit txtMessage;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl lblTel;

	private LabelControl lblCharCounter;

	private LabelControl lblMessageCounter;

	public TextEdit txtReceipient;

	public SMSGuardian()
	{
		InitializeComponent();
	}

	private void memoEdit1_TextChanged(object sender, EventArgs e)
	{
		if (txtMessage.Text.Length < 145 && txtMessage.Text.Length > 0)
		{
			lblMessageCounter.Text = "1 Message";
			txtMessage.ForeColor = Color.Black;
			simpleButton1.Enabled = true;
		}
		else if (txtMessage.Text.Length < 289 && txtMessage.Text.Length > 144)
		{
			lblMessageCounter.Text = "2 Messages";
			txtMessage.ForeColor = Color.FromArgb(153, 102, 0);
			simpleButton1.Enabled = true;
		}
		else if (txtMessage.Text.Length < 433 && txtMessage.Text.Length > 288)
		{
			lblMessageCounter.Text = "3 Messages";
			txtMessage.ForeColor = Color.Red;
			simpleButton1.Enabled = true;
		}
		else
		{
			lblMessageCounter.Text = "0 Messages";
			simpleButton1.Enabled = false;
		}
		lblCharCounter.Text = txtMessage.Text.Length + " Characters";
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
			XtraMessageBox.Show("Message Sent Successfully.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		try
		{
			GET("http://api.kayesms.com/api/v1/sms/send/?apiKey=2518228a-d923-42a4-83bb-cf90848f773a&message=" + txtMessage.Text + "&from=" + ReportHeader.ShortName + "&to=" + txtReceipient.Text);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static string GET(string url)
	{
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			responseStream.Close();
			return result;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return null;
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Dispose();
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
		this.txtReceipient = new DevExpress.XtraEditors.TextEdit();
		this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.lblTel = new DevExpress.XtraEditors.LabelControl();
		this.lblCharCounter = new DevExpress.XtraEditors.LabelControl();
		this.lblMessageCounter = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtReceipient.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtMessage.Properties).BeginInit();
		base.SuspendLayout();
		this.txtReceipient.EnterMoveNextControl = true;
		this.txtReceipient.Location = new System.Drawing.Point(44, 19);
		this.txtReceipient.Name = "txtReceipient";
		this.txtReceipient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReceipient.Properties.MaxLength = 15;
		this.txtReceipient.Size = new System.Drawing.Size(236, 22);
		this.txtReceipient.TabIndex = 0;
		this.txtMessage.Location = new System.Drawing.Point(2, 91);
		this.txtMessage.Name = "txtMessage";
		this.txtMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtMessage.Size = new System.Drawing.Size(278, 131);
		this.txtMessage.TabIndex = 1;
		this.txtMessage.TextChanged += new System.EventHandler(memoEdit1_TextChanged);
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(2, 227);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(131, 23);
		this.simpleButton1.TabIndex = 2;
		this.simpleButton1.Text = "Send SMS";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(149, 227);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(131, 23);
		this.simpleButton2.TabIndex = 3;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.lblTel.Location = new System.Drawing.Point(2, 26);
		this.lblTel.Name = "lblTel";
		this.lblTel.Size = new System.Drawing.Size(34, 13);
		this.lblTel.TabIndex = 8;
		this.lblTel.Text = "Tel No.";
		this.lblCharCounter.Location = new System.Drawing.Point(4, 51);
		this.lblCharCounter.Name = "lblCharCounter";
		this.lblCharCounter.Size = new System.Drawing.Size(62, 13);
		this.lblCharCounter.TabIndex = 9;
		this.lblCharCounter.Text = "0 Characters";
		this.lblMessageCounter.Location = new System.Drawing.Point(4, 70);
		this.lblMessageCounter.Name = "lblMessageCounter";
		this.lblMessageCounter.Size = new System.Drawing.Size(56, 13);
		this.lblMessageCounter.TabIndex = 10;
		this.lblMessageCounter.Text = "0 Messages";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 256);
		base.Controls.Add(this.lblMessageCounter);
		base.Controls.Add(this.lblCharCounter);
		base.Controls.Add(this.lblTel);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtMessage);
		base.Controls.Add(this.txtReceipient);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "SMSGuardian";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "SMS Guardian";
		((System.ComponentModel.ISupportInitialize)this.txtReceipient.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtMessage.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
