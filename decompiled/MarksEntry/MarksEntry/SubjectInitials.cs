using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MarksEntry;

public class SubjectInitials : XtraForm
{
	private IContainer components = null;

	private LabelControl labelControl1;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	public TextEdit txtInitials;

	public SubjectInitials()
	{
		InitializeComponent();
	}

	private void AcceptTeacherInitials()
	{
		if (txtInitials.Text != string.Empty)
		{
			if (txtInitials.Text.Length <= 3)
			{
				TeacherInitials.SetInitials(txtInitials.Text);
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				XtraMessageBox.Show("Initials cannot greater than Three (3) letters", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtInitials.Focus();
			}
		}
		else
		{
			XtraMessageBox.Show("Initials cannot be blank", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		AcceptTeacherInitials();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void SubjectInitials_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			AcceptTeacherInitials();
		}
		else if (e.KeyCode == Keys.Escape)
		{
			base.DialogResult = DialogResult.Cancel;
			Close();
		}
	}

	private void simpleButton1_Enter(object sender, EventArgs e)
	{
		AcceptTeacherInitials();
	}

	private void SubjectInitials_Load(object sender, EventArgs e)
	{
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
		this.txtInitials = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.txtInitials.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl1.Location = new System.Drawing.Point(4, 7);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(171, 19);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Subject Teacher Initials:";
		this.txtInitials.EnterMoveNextControl = true;
		this.txtInitials.Location = new System.Drawing.Point(6, 35);
		this.txtInitials.Name = "txtInitials";
		this.txtInitials.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtInitials.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtInitials.Properties.MaxLength = 3;
		this.txtInitials.Size = new System.Drawing.Size(328, 30);
		this.txtInitials.TabIndex = 0;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(122, 71);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(100, 34);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "&OK";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton1.Enter += new System.EventHandler(simpleButton1_Enter);
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(230, 71);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(100, 34);
		this.simpleButton2.TabIndex = 2;
		this.simpleButton2.Text = "&Cancel";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(342, 113);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.txtInitials);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.Name = "SubjectInitials";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Teacher Initials";
		base.Load += new System.EventHandler(SubjectInitials_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(SubjectInitials_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.txtInitials.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
