using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme.DialogForms;

public class TransferTarget_Deposit : XtraForm
{
	public int accountNumber = 0;

	public string refNumber = string.Empty;

	public int c_accountNumber = 0;

	public string c_accName = string.Empty;

	private IContainer components = null;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton4;

	public TransferTarget_Deposit()
	{
		InitializeComponent();
	}

	private void TransferTarget_Load(object sender, EventArgs e)
	{
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		CreditorList creditorList = new CreditorList();
		DialogResult dialogResult = creditorList.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		CashAccountList cashAccountList = new CashAccountList();
		DialogResult dialogResult = cashAccountList.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			base.DialogResult = DialogResult.Yes;
			Close();
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
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		base.SuspendLayout();
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton3.Location = new System.Drawing.Point(462, 5);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(145, 39);
		this.simpleButton3.TabIndex = 2;
		this.simpleButton3.Text = "Cancel";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(156, 5);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(145, 39);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Loan";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(5, 5);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(145, 39);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Debtor Payment";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton4.Appearance.Options.UseFont = true;
		this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton4.Location = new System.Drawing.Point(310, 5);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(145, 39);
		this.simpleButton4.TabIndex = 3;
		this.simpleButton4.Text = "Other Sources";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(611, 49);
		base.Controls.Add(this.simpleButton4);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.simpleButton3);
		base.Controls.Add(this.simpleButton2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "TransferTarget_Deposit";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Deposit Source";
		base.Load += new System.EventHandler(TransferTarget_Load);
		base.ResumeLayout(false);
	}
}
