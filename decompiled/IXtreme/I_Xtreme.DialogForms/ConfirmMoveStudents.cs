using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme.DialogForms;

public class ConfirmMoveStudents : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private CheckEdit checkEdit1;

	private LabelControl labelControl2;

	public ConfirmMoveStudents()
	{
		InitializeComponent();
		simpleButton1.Focus();
	}

	private void checkEdit1_CheckedChanged(object sender, EventArgs e)
	{
		StudentMoveDialog.SetDialogShowProperty(Convert.ToBoolean(checkEdit1.EditValue));
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
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.simpleButton1.Location = new System.Drawing.Point(9, 96);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(180, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "&Yes";
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.No;
		this.simpleButton2.Location = new System.Drawing.Point(197, 96);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(180, 23);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "&No";
		this.labelControl1.Appearance.BackColor = System.Drawing.Color.MintCream;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(0, 0);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(0);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(386, 46);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Do you really want to move this student?\r\nNote that you will not be able to undo this action.\r\n\r\n";
		this.checkEdit1.Location = new System.Drawing.Point(10, 70);
		this.checkEdit1.Name = "checkEdit1";
		this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.checkEdit1.Properties.Appearance.Options.UseFont = true;
		this.checkEdit1.Properties.Caption = "Do not warm me again. I know what am doing.";
		this.checkEdit1.Size = new System.Drawing.Size(365, 21);
		this.checkEdit1.TabIndex = 3;
		this.checkEdit1.CheckedChanged += new System.EventHandler(checkEdit1_CheckedChanged);
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Visible = true;
		this.labelControl2.Location = new System.Drawing.Point(12, 51);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(363, 15);
		this.labelControl2.TabIndex = 4;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(387, 131);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.checkEdit1);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ConfirmMoveStudents";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Confirm";
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
