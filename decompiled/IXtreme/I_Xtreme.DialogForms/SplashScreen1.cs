using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using I_Xtreme.Properties;

namespace I_Xtreme.DialogForms;

public class SplashScreen1 : SplashScreen
{
	public enum SplashScreenCommand
	{
		InitializeDataWareHouse
	}

	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private IContainer components = null;

	private MarqueeProgressBarControl marqueeProgressBarControl1;

	private DefaultLookAndFeel defaultLookAndFeel1;

	private LabelControl lblVersion;

	private PictureEdit pictureEdit1;

	public static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

	public SplashScreen1()
	{
		InitializeComponent();
		lblVersion.Text = $"Version {AssemblyVersion}";
	}

	public override void ProcessCommand(Enum cmd, object arg)
	{
		base.ProcessCommand(cmd, arg);
		if ((SplashScreenCommand)(object)cmd == SplashScreenCommand.InitializeDataWareHouse)
		{
			FinalAccounts.InitializeChartsOfAccounts();
			ReportCustomization.InitializeReportSetting();
			gradingScale.InitializeSubjectGradingScale();
			gradingScale.InitializeNewCurriculumGrades();
			ALevelGradingScale.InitializeSubjectGradingScale(DataConnection.ConnectToDatabase());
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
		this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
		this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
		this.lblVersion = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		((System.ComponentModel.ISupportInitialize)this.marqueeProgressBarControl1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.marqueeProgressBarControl1.EditValue = 0;
		this.marqueeProgressBarControl1.Location = new System.Drawing.Point(157, 168);
		this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
		this.marqueeProgressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.marqueeProgressBarControl1.Size = new System.Drawing.Size(125, 10);
		this.marqueeProgressBarControl1.TabIndex = 10;
		this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
		this.defaultLookAndFeel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
		this.lblVersion.Appearance.ForeColor = System.Drawing.Color.White;
		this.lblVersion.Location = new System.Drawing.Point(315, 243);
		this.lblVersion.Name = "lblVersion";
		this.lblVersion.Size = new System.Drawing.Size(75, 13);
		this.lblVersion.TabIndex = 12;
		this.lblVersion.Text = "Product Version";
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.poweredBy_2;
		this.pictureEdit1.Location = new System.Drawing.Point(44, 233);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(100, 33);
		this.pictureEdit1.TabIndex = 13;
		base.AllowControlsInImageMode = true;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(439, 279);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.lblVersion);
		base.Controls.Add(this.marqueeProgressBarControl1);
		base.Name = "SplashScreen1";
		base.ShowMode = DevExpress.XtraSplashScreen.ShowMode.Image;
		base.SplashImage = I_Xtreme.Properties.Resources.background;
		this.Text = "Form1";
		base.TransparencyKey = System.Drawing.Color.FromArgb(235, 236, 239);
		((System.ComponentModel.ISupportInitialize)this.marqueeProgressBarControl1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
