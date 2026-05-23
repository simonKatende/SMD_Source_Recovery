using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class PromoteProgress : XtraForm
{
	private int k;

	public string promoType;

	public static string studentClass;

	public string currentSemester;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private Timer timer1;

	public PromoteProgress()
	{
		InitializeComponent();
	}

	private void PromoteProgress_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 2)
		{
			timer1.Enabled = false;
			if (promoType == "Unconditionally")
			{
				StudentPromotion.PromoteAllStudents(progressBarControl1, currentSemester);
			}
			else if (promoType == "Conditionally")
			{
				StudentPromotion.StudentsPromoteConditionally(currentSemester, progressBarControl1);
			}
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
		this.components = new System.ComponentModel.Container();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.progressBarControl1.Location = new System.Drawing.Point(12, 12);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Size = new System.Drawing.Size(326, 18);
		this.progressBarControl1.TabIndex = 0;
		this.timer1.Interval = 500;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(350, 44);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Name = "PromoteProgress";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "PromoteProgress";
		base.Load += new System.EventHandler(PromoteProgress_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
