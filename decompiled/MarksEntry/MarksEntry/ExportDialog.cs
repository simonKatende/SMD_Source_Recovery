using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraWaitForm;

namespace MarksEntry;

public class ExportDialog : XtraForm
{
	private IContainer components = null;

	public ProgressPanel progressPanel1;

	private Timer timer1;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	public ExportDialog()
	{
		InitializeComponent();
	}

	public static string ProgressCaption(string caption)
	{
		return caption;
	}

	public static string ProgressDescription(string description)
	{
		return description;
	}

	private void timer1_Tick(object sender, EventArgs e)
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
		this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
		this.timer1 = new System.Windows.Forms.Timer();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		base.SuspendLayout();
		this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.progressPanel1.Appearance.Options.UseBackColor = true;
		this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
		this.progressPanel1.AppearanceCaption.Options.UseFont = true;
		this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
		this.progressPanel1.AppearanceDescription.Options.UseFont = true;
		this.progressPanel1.Location = new System.Drawing.Point(0, 0);
		this.progressPanel1.Name = "progressPanel1";
		this.progressPanel1.Size = new System.Drawing.Size(284, 54);
		this.progressPanel1.TabIndex = 0;
		this.progressPanel1.Text = "progressPanel1";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(4, 71);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(131, 23);
		this.simpleButton1.TabIndex = 1;
		this.simpleButton1.Text = "Yes";
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(150, 71);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(131, 23);
		this.simpleButton2.TabIndex = 2;
		this.simpleButton2.Text = "No";
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(4, 57);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(277, 10);
		this.labelControl1.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 103);
		base.ControlBox = false;
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.progressPanel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ExportDialog";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Exporting. Please wait...";
		base.ResumeLayout(false);
	}
}
