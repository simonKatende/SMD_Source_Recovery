using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme.DialogForms;

public class ExpenseNarration : XtraForm
{
	private IContainer components = null;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	public TextEdit txtReceivedBy;

	public MemoEdit txtNarration;

	public ExpenseNarration()
	{
		InitializeComponent();
	}

	private void ExpenseNarration_Load(object sender, EventArgs e)
	{
		txtReceivedBy.Focus();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void ExpenseNarration_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			base.DialogResult = DialogResult.Cancel;
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.txtReceivedBy = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.txtNarration = new DevExpress.XtraEditors.MemoEdit();
		((System.ComponentModel.ISupportInitialize)this.txtReceivedBy.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl1.Location = new System.Drawing.Point(13, 21);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(59, 13);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Received By";
		this.labelControl2.Location = new System.Drawing.Point(13, 66);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(45, 13);
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Narration";
		this.txtReceivedBy.EnterMoveNextControl = true;
		this.txtReceivedBy.Location = new System.Drawing.Point(78, 12);
		this.txtReceivedBy.Name = "txtReceivedBy";
		this.txtReceivedBy.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReceivedBy.Properties.MaxLength = 80;
		this.txtReceivedBy.Size = new System.Drawing.Size(255, 22);
		this.txtReceivedBy.TabIndex = 0;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(210, 113);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(123, 23);
		this.simpleButton1.TabIndex = 3;
		this.simpleButton1.TabStop = false;
		this.simpleButton1.Text = "Cancel";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(78, 113);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(123, 23);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Continue";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.txtNarration.EnterMoveNextControl = true;
		this.txtNarration.Location = new System.Drawing.Point(78, 40);
		this.txtNarration.Name = "txtNarration";
		this.txtNarration.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtNarration.Properties.MaxLength = 50;
		this.txtNarration.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtNarration.Size = new System.Drawing.Size(255, 64);
		this.txtNarration.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(344, 145);
		base.Controls.Add(this.txtNarration);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtReceivedBy);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ExpenseNarration";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Narration";
		base.Load += new System.EventHandler(ExpenseNarration_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(ExpenseNarration_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtReceivedBy.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
