using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MarksEntry;

public class NewInitials : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	public TextEdit textEdit1;

	private LabelControl labelControl1;

	public NewInitials()
	{
		InitializeComponent();
	}

	private void AcceptNewInitials()
	{
		if (textEdit1.Text == string.Empty)
		{
			XtraMessageBox.Show("Please enter your initials", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		TeacherInitials.SetInitials(textEdit1.Text.ToUpper());
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		AcceptNewInitials();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
	}

	private void simpleButton1_Enter(object sender, EventArgs e)
	{
		AcceptNewInitials();
	}

	private void NewInitials_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			AcceptNewInitials();
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(222, 72);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(100, 34);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "C&ontinue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton1.Enter += new System.EventHandler(simpleButton1_Enter);
		this.textEdit1.EnterMoveNextControl = true;
		this.textEdit1.Location = new System.Drawing.Point(6, 35);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.textEdit1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.textEdit1.Properties.MaxLength = 3;
		this.textEdit1.Size = new System.Drawing.Size(317, 30);
		this.textEdit1.TabIndex = 0;
		this.labelControl1.Location = new System.Drawing.Point(4, 7);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(89, 19);
		this.labelControl1.TabIndex = 7;
		this.labelControl1.Text = "New Initials:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(335, 120);
		base.ControlBox = false;
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.textEdit1);
		base.Controls.Add(this.simpleButton1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "NewInitials";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Change Initials";
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(NewInitials_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
