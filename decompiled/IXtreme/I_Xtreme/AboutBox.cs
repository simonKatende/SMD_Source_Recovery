using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class AboutBox : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private LabelControl labelProductName;

	private LabelControl labelVersion;

	private LabelControl labelCopyright;

	private LabelControl labelCompanyName;

	private MemoEdit textBoxDescription;

	private PictureEdit pictureEdit1;

	private Timer tmrFade;

	public static string AssemblyTitle
	{
		get
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
			if (customAttributes.Length != 0)
			{
				AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
				if (assemblyTitleAttribute.Title != string.Empty)
				{
					return assemblyTitleAttribute.Title;
				}
			}
			return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
		}
	}

	public static string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

	public static string AssemblyDescription
	{
		get
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return string.Empty;
			}
			return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
		}
	}

	public static string AssemblyProduct
	{
		get
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return string.Empty;
			}
			return ((AssemblyProductAttribute)customAttributes[0]).Product;
		}
	}

	public static string AssemblyCopyright
	{
		get
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return string.Empty;
			}
			return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
		}
	}

	public static string AssemblyCompany
	{
		get
		{
			object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), inherit: false);
			if (customAttributes.Length == 0)
			{
				return string.Empty;
			}
			return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
		}
	}

	public AboutBox()
	{
		InitializeComponent();
		base.Opacity = 0.0;
		tmrFade.Enabled = true;
		Text = $"About {AssemblyTitle}";
		labelProductName.Text = AssemblyProduct;
		labelVersion.Text = $"Version {AssemblyVersion}";
		labelCopyright.Text = AssemblyCopyright;
		labelCompanyName.Text = AssemblyCompany;
		textBoxDescription.Text = AssemblyDescription;
	}

	private void tmrFade_Tick(object sender, EventArgs e)
	{
		base.Opacity += 0.05;
		if (base.Opacity >= 0.95)
		{
			base.Opacity = 1.0;
			tmrFade.Enabled = false;
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelProductName = new DevExpress.XtraEditors.LabelControl();
		this.labelVersion = new DevExpress.XtraEditors.LabelControl();
		this.labelCopyright = new DevExpress.XtraEditors.LabelControl();
		this.labelCompanyName = new DevExpress.XtraEditors.LabelControl();
		this.textBoxDescription = new DevExpress.XtraEditors.MemoEdit();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.tmrFade = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.textBoxDescription.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.simpleButton1.Location = new System.Drawing.Point(319, 163);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(90, 23);
		this.simpleButton1.TabIndex = 28;
		this.simpleButton1.Text = "&OK";
		this.labelProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.labelProductName.Location = new System.Drawing.Point(102, 5);
		this.labelProductName.Name = "labelProductName";
		this.labelProductName.Size = new System.Drawing.Size(94, 19);
		this.labelProductName.TabIndex = 30;
		this.labelProductName.Text = "labelControl1";
		this.labelVersion.Location = new System.Drawing.Point(102, 31);
		this.labelVersion.Name = "labelVersion";
		this.labelVersion.Size = new System.Drawing.Size(63, 13);
		this.labelVersion.TabIndex = 31;
		this.labelVersion.Text = "labelControl1";
		this.labelCopyright.Location = new System.Drawing.Point(102, 50);
		this.labelCopyright.Name = "labelCopyright";
		this.labelCopyright.Size = new System.Drawing.Size(63, 13);
		this.labelCopyright.TabIndex = 32;
		this.labelCopyright.Text = "labelControl1";
		this.labelCompanyName.Location = new System.Drawing.Point(102, 69);
		this.labelCompanyName.Name = "labelCompanyName";
		this.labelCompanyName.Size = new System.Drawing.Size(63, 13);
		this.labelCompanyName.TabIndex = 33;
		this.labelCompanyName.Text = "labelControl1";
		this.textBoxDescription.Location = new System.Drawing.Point(2, 88);
		this.textBoxDescription.Name = "textBoxDescription";
		this.textBoxDescription.Properties.ReadOnly = true;
		this.textBoxDescription.Size = new System.Drawing.Size(407, 69);
		this.textBoxDescription.TabIndex = 34;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources._3dicon2;
		this.pictureEdit1.Location = new System.Drawing.Point(2, 3);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(84, 79);
		this.pictureEdit1.TabIndex = 35;
		this.tmrFade.Tick += new System.EventHandler(tmrFade_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(411, 188);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.textBoxDescription);
		base.Controls.Add(this.labelCompanyName);
		base.Controls.Add(this.labelCopyright);
		base.Controls.Add(this.labelVersion);
		base.Controls.Add(this.labelProductName);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "AboutBox";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "About";
		((System.ComponentModel.ISupportInitialize)this.textBoxDescription.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
