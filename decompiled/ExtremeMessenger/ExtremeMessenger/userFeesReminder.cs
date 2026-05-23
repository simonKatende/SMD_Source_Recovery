using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.ExtremeMessenger;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace ExtremeMessenger;

public class userFeesReminder : UserControl
{
	private int i = 0;

	private int maximum = 0;

	private SMSGateWay gateWay;

	private static string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton1;

	private MemoEdit memoEdit1;

	private ComboBoxEdit cboClass;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LabelControl lblMessages;

	private LabelControl lblCharacters;

	private LabelControl labelControl5;

	private LabelControl labelControl4;

	private TextEdit textEdit1;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private System.Windows.Forms.Timer timer1;

	private ProgressBarControl progressBarControl1;

	private LayoutControlItem layoutControlItem12;

	private LabelControl lblErrorCatch;

	private LayoutControlItem layoutControlItem13;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer2;

	private TextEdit txtSender;

	private LayoutControlItem layoutControlItem14;

	private ComboBoxEdit cboStudyStatus;

	private LayoutControlItem layoutControlItem15;

	public userFeesReminder()
	{
		InitializeComponent();
		lblErrorCatch.Text = string.Empty;
		gateWay = new SMSGateWay(connectionString);
		gateWay.InitializeAccount();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		layoutControlItem12.Visibility = LayoutVisibility.Always;
		simpleButton1.Enabled = false;
		backgroundWorker1.RunWorkerAsync();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		lblCharacters.Text = memoEdit1.Text.Length.ToString();
		int length = memoEdit1.Text.Length;
		if (memoEdit1.Text != "" || memoEdit1.Text != null)
		{
			if (length > 0 && length <= 160)
			{
				lblMessages.Text = "1 Msg.";
			}
			else if (length > 160 && length <= 320)
			{
				lblMessages.Text = "2 Msgs.";
			}
			else if (length > 320)
			{
				lblMessages.Text = "3 Msgs.";
			}
		}
		else
		{
			lblMessages.Text = "0 Msgs.";
		}
		if (cboClass.SelectedIndex > -1 && textEdit1.Text != "")
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
		}
	}

	private void SendFeesReminder(string classId, double feesBalance)
	{
		try
		{
			string selectCommandText = $"SELECT Oid,StudentNumber,fullName,cashOnAccount,PriorityContact,OtherContact FROM tbl_Stud WHERE ClassId = '{classId}' AND cashOnAccount >= {feesBalance}";
			if (cboStudyStatus.SelectedIndex > 0)
			{
				selectCommandText = string.Format("SELECT Oid,StudentNumber,fullName,cashOnAccount,PriorityContact,OtherContact FROM tbl_Stud WHERE ClassId = '{0}' AND cashOnAccount >= {1} AND StudyStatus='2'", classId, feesBalance, cboStudyStatus.SelectedItem.ToString());
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "FeesBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			i = 0;
			maximum = dataTable.Rows.Count;
			foreach (DataRow row in dataTable.Rows)
			{
				i++;
				string text = "";
				string text2 = "";
				double result = (double.TryParse(row["cashOnAccount"].ToString(), out result) ? result : 0.0);
				string message = memoEdit1.Text.Replace("$", result.ToString()).Replace("#", row["fullName"].ToString()).ToString();
				if (row["PriorityContact"].ToString().Length >= 10)
				{
					text = "256" + row["PriorityContact"].ToString().Substring(1, 9);
					gateWay.SendSMSViaPOST(text, message);
				}
				if (row["OtherContact"].ToString().Length >= 10)
				{
					text2 = "256" + row["OtherContact"].ToString().Substring(1, 9);
					gateWay.SendSMSViaPOST(text2, message);
				}
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(i);
			}
		}
		catch (Exception ex)
		{
			lblErrorCatch.ForeColor = Color.Red;
			lblErrorCatch.Text = ex.Message;
			simpleButton1.Enabled = true;
			progressBarControl1.Position = 0;
			layoutControlItem12.Visibility = LayoutVisibility.Never;
			backgroundWorker1.CancelAsync();
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		SendFeesReminder(cboClass.SelectedItem.ToString(), Convert.ToDouble(textEdit1.Text));
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		layoutControlItem12.Visibility = LayoutVisibility.Never;
		simpleButton1.Enabled = true;
		lblErrorCatch.ForeColor = Color.Green;
		lblErrorCatch.Text = "Fees reminders sent successfully.";
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void userFeesReminder_Load(object sender, EventArgs e)
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
		this.components = new System.ComponentModel.Container();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtSender = new DevExpress.XtraEditors.TextEdit();
		this.lblErrorCatch = new DevExpress.XtraEditors.LabelControl();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.lblMessages = new DevExpress.XtraEditors.LabelControl();
		this.lblCharacters = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
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
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.timer2 = new System.Windows.Forms.Timer(this.components);
		this.cboStudyStatus = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtSender.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboStudyStatus.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboStudyStatus);
		this.layoutControl1.Controls.Add(this.txtSender);
		this.layoutControl1.Controls.Add(this.lblErrorCatch);
		this.layoutControl1.Controls.Add(this.progressBarControl1);
		this.layoutControl1.Controls.Add(this.lblMessages);
		this.layoutControl1.Controls.Add(this.lblCharacters);
		this.layoutControl1.Controls.Add(this.labelControl5);
		this.layoutControl1.Controls.Add(this.labelControl4);
		this.layoutControl1.Controls.Add(this.textEdit1);
		this.layoutControl1.Controls.Add(this.labelControl3);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.memoEdit1);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(323, 463);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.txtSender.Location = new System.Drawing.Point(8, 67);
		this.txtSender.Name = "txtSender";
		this.txtSender.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtSender.Properties.Appearance.Options.UseFont = true;
		this.txtSender.Properties.MaxLength = 13;
		this.txtSender.Size = new System.Drawing.Size(307, 22);
		this.txtSender.StyleController = this.layoutControl1;
		this.txtSender.TabIndex = 17;
		this.lblErrorCatch.Location = new System.Drawing.Point(8, 403);
		this.lblErrorCatch.Name = "lblErrorCatch";
		this.lblErrorCatch.Size = new System.Drawing.Size(307, 13);
		this.lblErrorCatch.StyleController = this.layoutControl1;
		this.lblErrorCatch.TabIndex = 16;
		this.progressBarControl1.Location = new System.Drawing.Point(8, 418);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(307, 14);
		this.progressBarControl1.StyleController = this.layoutControl1;
		this.progressBarControl1.TabIndex = 15;
		this.lblMessages.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMessages.Appearance.Options.UseFont = true;
		this.lblMessages.Appearance.Options.UseTextOptions = true;
		this.lblMessages.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.lblMessages.Location = new System.Drawing.Point(77, 366);
		this.lblMessages.Name = "lblMessages";
		this.lblMessages.Size = new System.Drawing.Size(238, 20);
		this.lblMessages.StyleController = this.layoutControl1;
		this.lblMessages.TabIndex = 14;
		this.lblCharacters.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCharacters.Appearance.Options.UseFont = true;
		this.lblCharacters.Appearance.Options.UseTextOptions = true;
		this.lblCharacters.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.lblCharacters.Location = new System.Drawing.Point(83, 344);
		this.lblCharacters.Name = "lblCharacters";
		this.lblCharacters.Size = new System.Drawing.Size(232, 20);
		this.lblCharacters.StyleController = this.layoutControl1;
		this.lblCharacters.TabIndex = 13;
		this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl5.Appearance.Options.UseFont = true;
		this.labelControl5.Location = new System.Drawing.Point(8, 366);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(61, 16);
		this.labelControl5.StyleController = this.layoutControl1;
		this.labelControl5.TabIndex = 12;
		this.labelControl5.Text = "Messages:";
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.Location = new System.Drawing.Point(8, 344);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(67, 16);
		this.labelControl4.StyleController = this.layoutControl1;
		this.labelControl4.TabIndex = 11;
		this.labelControl4.Text = "Characters:";
		this.textEdit1.Location = new System.Drawing.Point(8, 190);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.textEdit1.Properties.Appearance.Options.UseFont = true;
		this.textEdit1.Properties.Mask.EditMask = "n0";
		this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.textEdit1.Size = new System.Drawing.Size(307, 22);
		this.textEdit1.StyleController = this.layoutControl1;
		this.textEdit1.TabIndex = 10;
		this.labelControl3.Location = new System.Drawing.Point(8, 388);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(307, 13);
		this.labelControl3.StyleController = this.layoutControl1;
		this.labelControl3.TabIndex = 9;
		this.labelControl2.Location = new System.Drawing.Point(8, 34);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(307, 13);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 8;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(8, 434);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(307, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 7;
		this.simpleButton1.Text = "Send Fees Reminder";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.memoEdit1.EditValue = "Dear Parent,You are reminded to pay fees balance of $ for # to avoid sending the student back home";
		this.memoEdit1.Location = new System.Drawing.Point(8, 232);
		this.memoEdit1.Name = "memoEdit1";
		this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.memoEdit1.Properties.Appearance.Options.UseFont = true;
		this.memoEdit1.Properties.MaxLength = 480;
		this.memoEdit1.Size = new System.Drawing.Size(307, 110);
		this.memoEdit1.StyleController = this.layoutControl1;
		this.memoEdit1.TabIndex = 6;
		this.cboClass.Location = new System.Drawing.Point(8, 109);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboClass.Properties.Appearance.Options.UseFont = true;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.Items.AddRange(new object[6] { "S.1", "S.2", "S.3", "S.4", "S.5", "S.6" });
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(307, 22);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 5;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.Location = new System.Drawing.Point(27, 7);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(239, 25);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 4;
		this.labelControl1.Text = "Fees Collection reminder";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[15]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10,
			this.layoutControlItem11, this.layoutControlItem12, this.layoutControlItem13, this.layoutControlItem14, this.layoutControlItem15
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(323, 463);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.labelControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 1, 1, 1);
		this.layoutControlItem1.Size = new System.Drawing.Size(309, 27);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.layoutControlItem2.Control = this.cboClass;
		this.layoutControlItem2.CustomizationFormText = "Class:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(309, 42);
		this.layoutControlItem2.Text = "Class:";
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(222, 16);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.memoEdit1;
		this.layoutControlItem3.CustomizationFormText = "Message Preview";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 207);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(309, 130);
		this.layoutControlItem3.Text = "Message Preview";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(222, 16);
		this.layoutControlItem4.Control = this.simpleButton1;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 427);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(309, 24);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.Control = this.labelControl2;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 27);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(309, 15);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.Control = this.labelControl3;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 381);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(309, 15);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.textEdit1;
		this.layoutControlItem7.CustomizationFormText = "Fees Balance Greater than or Equal to:";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 165);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(309, 42);
		this.layoutControlItem7.Text = "Fees Balance Greater than or Equal to:";
		this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem7.TextSize = new System.Drawing.Size(222, 16);
		this.layoutControlItem8.Control = this.labelControl4;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 337);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(69, 22);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.labelControl5;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 359);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(63, 22);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem10.Control = this.lblCharacters;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(69, 337);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 1, 1, 1);
		this.layoutControlItem10.Size = new System.Drawing.Size(240, 22);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.lblMessages;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(63, 359);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Padding = new DevExpress.XtraLayout.Utils.Padding(7, 1, 1, 1);
		this.layoutControlItem11.Size = new System.Drawing.Size(246, 22);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem12.Control = this.progressBarControl1;
		this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 411);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(309, 16);
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextVisible = false;
		this.layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem13.Control = this.lblErrorCatch;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 396);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(309, 15);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem14.Control = this.txtSender;
		this.layoutControlItem14.CustomizationFormText = "Sender:";
		this.layoutControlItem14.Location = new System.Drawing.Point(0, 42);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(309, 42);
		this.layoutControlItem14.Text = "Sender:";
		this.layoutControlItem14.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem14.TextSize = new System.Drawing.Size(222, 16);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.timer2.Enabled = true;
		this.cboStudyStatus.EditValue = "All";
		this.cboStudyStatus.Location = new System.Drawing.Point(8, 148);
		this.cboStudyStatus.Name = "cboStudyStatus";
		this.cboStudyStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboStudyStatus.Properties.Appearance.Options.UseFont = true;
		this.cboStudyStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStudyStatus.Properties.Items.AddRange(new object[3] { "All", "B", "D" });
		this.cboStudyStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStudyStatus.Size = new System.Drawing.Size(307, 22);
		this.cboStudyStatus.StyleController = this.layoutControl1;
		this.cboStudyStatus.TabIndex = 18;
		this.layoutControlItem15.Control = this.cboStudyStatus;
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 126);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(309, 39);
		this.layoutControlItem15.Text = "Study Status";
		this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem15.TextSize = new System.Drawing.Size(222, 13);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "userFeesReminder";
		base.Size = new System.Drawing.Size(323, 463);
		base.Load += new System.EventHandler(userFeesReminder_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtSender.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboStudyStatus.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		base.ResumeLayout(false);
	}
}
