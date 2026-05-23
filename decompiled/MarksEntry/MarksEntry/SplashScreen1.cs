using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using MarksEntry.Properties;

namespace MarksEntry;

public class SplashScreen1 : SplashScreen
{
	public enum SplashScreenCommand
	{

	}

	private IContainer components = null;

	private PictureEdit pictureEdit1;

	private LabelControl lblVersion;

	private MarqueeProgressBarControl marqueeProgressBarControl1;

	private LabelControl labelControl2;

	public static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

	public SplashScreen1()
	{
		InitializeComponent();
		lblVersion.Text = $"Version {AssemblyVersion}";
	}

	public override void ProcessCommand(Enum cmd, object arg)
	{
		base.ProcessCommand(cmd, arg);
		SplashScreenCommand splashScreenCommand = (SplashScreenCommand)(object)cmd;
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
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.lblVersion = new DevExpress.XtraEditors.LabelControl();
		this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.marqueeProgressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.pictureEdit1.EditValue = MarksEntry.Properties.Resources.poweredBy_2;
		this.pictureEdit1.Location = new System.Drawing.Point(44, 233);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(100, 33);
		this.pictureEdit1.TabIndex = 17;
		this.lblVersion.Appearance.ForeColor = System.Drawing.Color.White;
		this.lblVersion.Location = new System.Drawing.Point(315, 243);
		this.lblVersion.Name = "lblVersion";
		this.lblVersion.Size = new System.Drawing.Size(75, 13);
		this.lblVersion.TabIndex = 16;
		this.lblVersion.Text = "Product Version";
		this.marqueeProgressBarControl1.EditValue = 0;
		this.marqueeProgressBarControl1.Location = new System.Drawing.Point(157, 168);
		this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
		this.marqueeProgressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.marqueeProgressBarControl1.Size = new System.Drawing.Size(125, 10);
		this.marqueeProgressBarControl1.TabIndex = 14;
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl2.Location = new System.Drawing.Point(41, 74);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(121, 19);
		this.labelControl2.TabIndex = 18;
		this.labelControl2.Text = "Teacher Gateway";
		base.AllowControlsInImageMode = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(439, 279);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.lblVersion);
		base.Controls.Add(this.marqueeProgressBarControl1);
		base.Name = "SplashScreen1";
		base.ShowIcon = false;
		base.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image;
		base.SplashImage = MarksEntry.Properties.Resources.background_tg;
		this.Text = "Form1";
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.marqueeProgressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
