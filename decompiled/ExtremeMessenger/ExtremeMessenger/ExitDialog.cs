using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ExtremeMessenger;

public class ExitDialog : XtraForm
{
	private IContainer components = null;

	private LabelControl labelControl1;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private CheckEdit checkEdit1;

	private PanelControl panelControl1;

	public ExitDialog()
	{
		InitializeComponent();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Yes;
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.No;
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		base.SuspendLayout();
		this.labelControl1.Location = new System.Drawing.Point(31, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(227, 13);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Do you really want to exit Extreme Messenger?";
		this.simpleButton1.Location = new System.Drawing.Point(202, 5);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(57, 23);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "Yes";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton2.Location = new System.Drawing.Point(264, 5);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(57, 23);
		this.simpleButton2.TabIndex = 2;
		this.simpleButton2.Text = "No";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.checkEdit1.Location = new System.Drawing.Point(5, 7);
		this.checkEdit1.Name = "checkEdit1";
		this.checkEdit1.Properties.Caption = "Dont ask me again.";
		this.checkEdit1.Size = new System.Drawing.Size(126, 19);
		this.checkEdit1.TabIndex = 3;
		this.panelControl1.Controls.Add(this.checkEdit1);
		this.panelControl1.Controls.Add(this.simpleButton2);
		this.panelControl1.Controls.Add(this.simpleButton1);
		this.panelControl1.Location = new System.Drawing.Point(2, 42);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(326, 33);
		this.panelControl1.TabIndex = 4;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(331, 78);
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ExitDialog";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Confirm";
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
