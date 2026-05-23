using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme.DialogForms;

public class TransferTarget : XtraForm
{
	public string accountNumber = string.Empty;

	public double amount = 0.0;

	public string bankAccountNo = string.Empty;

	public string bankName = string.Empty;

	public string cheaqueNo = string.Empty;

	public DateTime _dtDate;

	private IContainer components = null;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton4;

	private LabelControl labelControl1;

	public TransferTarget()
	{
		InitializeComponent();
	}

	private void PayCreditor()
	{
		CreditorList creditorList = new CreditorList();
		creditorList.txtCheaqueTotal.Text = amount.ToString("#,#.0");
		creditorList.bankAccountNo = bankAccountNo;
		creditorList.cheaqueNo = cheaqueNo;
		creditorList.dtDate = _dtDate;
		DialogResult dialogResult = creditorList.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void DepositToCashAccount()
	{
		CashAccountList cashAccountList = new CashAccountList();
		cashAccountList.bankAccountNo = bankAccountNo;
		cashAccountList.dtDate = _dtDate;
		cashAccountList.cheaqueNo = cheaqueNo;
		cashAccountList.bankName = bankName;
		cashAccountList.txtAmount.Text = amount.ToString("#,#.0");
		DialogResult dialogResult = cashAccountList.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void PayRequisition()
	{
		RequisitionDetails requisitionDetails = new RequisitionDetails();
		requisitionDetails.txtAmount.Text = amount.ToString("#,#.0");
		requisitionDetails._bankAccountNo = bankAccountNo;
		requisitionDetails.dtDate = _dtDate;
		requisitionDetails._cheaqueNo = cheaqueNo;
		DialogResult dialogResult = requisitionDetails.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		PayCreditor();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		DepositToCashAccount();
	}

	private void simpleButton4_Click(object sender, EventArgs e)
	{
		PayRequisition();
	}

	private void TransferTarget_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.P)
		{
			PayCreditor();
		}
		else if (e.KeyCode == Keys.D)
		{
			DepositToCashAccount();
		}
		else if (e.KeyCode == Keys.R)
		{
			PayRequisition();
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
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		base.SuspendLayout();
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton3.Location = new System.Drawing.Point(133, 64);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(123, 26);
		this.simpleButton3.TabIndex = 2;
		this.simpleButton3.Text = "Cancel";
		this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.simpleButton4.Appearance.Options.UseFont = true;
		this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton4.Location = new System.Drawing.Point(265, 9);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(123, 26);
		this.simpleButton4.TabIndex = 4;
		this.simpleButton4.Text = "Pay &Requisition";
		this.simpleButton4.Click += new System.EventHandler(simpleButton4_Click);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(5, 9);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(123, 26);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "&Pay Creditor";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(135, 9);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(123, 26);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "&Deposit to Cash";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(5, 43);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(383, 15);
		this.labelControl1.TabIndex = 5;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(392, 98);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton4);
		base.Controls.Add(this.simpleButton3);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "TransferTarget";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Transfer Target";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(TransferTarget_KeyDown);
		base.ResumeLayout(false);
	}
}
