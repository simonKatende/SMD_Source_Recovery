using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;

namespace I_Xtreme;

public class EmpDeductions : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private SimpleButton simpleButton2;

	private LabelControl labelControl3;

	public TextEdit txtItem;

	public TextEdit txtAmount;

	public EmpDeductions()
	{
		InitializeComponent();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (txtAmount.Text != string.Empty && txtItem.Text != string.Empty)
		{
			base.DialogResult = DialogResult.OK;
			Close();
		}
		else
		{
			XtraMessageBox.Show("Please provide a valid item name and amount", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtItem = new DevExpress.XtraEditors.TextEdit();
		this.txtAmount = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmount.Properties).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Location = new System.Drawing.Point(219, 81);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(75, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "OK";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtItem.Location = new System.Drawing.Point(62, 9);
		this.txtItem.Name = "txtItem";
		this.txtItem.Size = new System.Drawing.Size(232, 20);
		this.txtItem.TabIndex = 1;
		this.txtAmount.Location = new System.Drawing.Point(62, 35);
		this.txtAmount.Name = "txtAmount";
		this.txtAmount.Properties.Mask.EditMask = "n";
		this.txtAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtAmount.Size = new System.Drawing.Size(232, 20);
		this.txtAmount.TabIndex = 2;
		this.labelControl1.Location = new System.Drawing.Point(12, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(22, 13);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Item";
		this.labelControl2.Location = new System.Drawing.Point(12, 43);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(37, 13);
		this.labelControl2.TabIndex = 4;
		this.labelControl2.Text = "Amount";
		this.simpleButton2.Location = new System.Drawing.Point(138, 81);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(75, 23);
		this.simpleButton2.TabIndex = 5;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
		this.labelControl3.Visible = true;
		this.labelControl3.Location = new System.Drawing.Point(-2, 61);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(307, 14);
		this.labelControl3.TabIndex = 6;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(306, 107);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.txtAmount);
		base.Controls.Add(this.txtItem);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Name = "EmpDeductions";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Employee Deductions";
		((System.ComponentModel.ISupportInitialize)this.txtItem.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAmount.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
