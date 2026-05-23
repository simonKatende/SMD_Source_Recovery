using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrMainDashBoard : XtraUserControl
{
	private IContainer components = null;

	private PanelControl panelControl1;

	private LabelControl labelProductName;

	private LabelControl labelCopyright;

	private LabelControl labelVersion;

	private LabelControl labelCompanyName;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private LinkLabel linkLabel1;

	private PictureEdit pictureEdit1;

	private LabelControl labelControl1;

	private LabelControl labelControl4;

	private LabelControl labelControl5;

	private LabelControl labelControl6;

	private PictureEdit pictureEdit2;

	private PictureEdit pictureEdit3;

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

	public usrMainDashBoard()
	{
		InitializeComponent();
		labelProductName.Text = AssemblyProduct;
		labelVersion.Text = $"Version {AssemblyVersion}";
		labelCopyright.Text = AssemblyCopyright;
		labelCompanyName.Text = AssemblyCompany;
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("http://www.alienage.info");
	}

	private void usrMainDashBoard_Load(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.usrMainDashBoard));
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.labelCompanyName = new DevExpress.XtraEditors.LabelControl();
		this.labelProductName = new DevExpress.XtraEditors.LabelControl();
		this.labelCopyright = new DevExpress.XtraEditors.LabelControl();
		this.labelVersion = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
		this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit3.Properties).BeginInit();
		base.SuspendLayout();
		this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.panelControl1.Appearance.BackColor = System.Drawing.Color.SteelBlue;
		this.panelControl1.Appearance.Options.UseBackColor = true;
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Controls.Add(this.labelCompanyName);
		this.panelControl1.Controls.Add(this.labelProductName);
		this.panelControl1.Controls.Add(this.labelCopyright);
		this.panelControl1.Controls.Add(this.labelVersion);
		this.panelControl1.Location = new System.Drawing.Point(0, 67);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(663, 105);
		this.panelControl1.TabIndex = 0;
		this.labelCompanyName.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelCompanyName.Appearance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.labelCompanyName.Appearance.Options.UseFont = true;
		this.labelCompanyName.Appearance.Options.UseForeColor = true;
		this.labelCompanyName.Location = new System.Drawing.Point(22, 18);
		this.labelCompanyName.Name = "labelCompanyName";
		this.labelCompanyName.Size = new System.Drawing.Size(61, 13);
		this.labelCompanyName.TabIndex = 4;
		this.labelCompanyName.Text = "labelControl2";
		this.labelProductName.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Bold);
		this.labelProductName.Appearance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.labelProductName.Appearance.Options.UseFont = true;
		this.labelProductName.Appearance.Options.UseForeColor = true;
		this.labelProductName.Location = new System.Drawing.Point(22, 32);
		this.labelProductName.Name = "labelProductName";
		this.labelProductName.Size = new System.Drawing.Size(102, 18);
		this.labelProductName.TabIndex = 3;
		this.labelProductName.Text = "labelControl4";
		this.labelCopyright.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelCopyright.Appearance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.labelCopyright.Appearance.Options.UseFont = true;
		this.labelCopyright.Appearance.Options.UseForeColor = true;
		this.labelCopyright.Location = new System.Drawing.Point(22, 65);
		this.labelCopyright.Name = "labelCopyright";
		this.labelCopyright.Size = new System.Drawing.Size(61, 13);
		this.labelCopyright.TabIndex = 2;
		this.labelCopyright.Text = "labelControl3";
		this.labelVersion.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelVersion.Appearance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.labelVersion.Appearance.Options.UseFont = true;
		this.labelVersion.Appearance.Options.UseForeColor = true;
		this.labelVersion.Location = new System.Drawing.Point(22, 51);
		this.labelVersion.Name = "labelVersion";
		this.labelVersion.Size = new System.Drawing.Size(35, 13);
		this.labelVersion.TabIndex = 1;
		this.labelVersion.Text = "Version";
		this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.Location = new System.Drawing.Point(476, 260);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(80, 13);
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Contact us on:";
		this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.Location = new System.Drawing.Point(476, 278);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(140, 13);
		this.labelControl3.TabIndex = 2;
		this.labelControl3.Text = "Email: alienageltd@gmail.com";
		this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.Location = new System.Drawing.Point(473, 350);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(94, 13);
		this.linkLabel1.TabIndex = 3;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "www.alienage.info";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Location = new System.Drawing.Point(477, 314);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(81, 13);
		this.labelControl1.TabIndex = 13;
		this.labelControl1.Text = "256 752 162 444";
		this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.Location = new System.Drawing.Point(477, 332);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(81, 13);
		this.labelControl4.TabIndex = 14;
		this.labelControl4.Text = "256 392 000 153";
		this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl5.Appearance.Options.UseFont = true;
		this.labelControl5.Location = new System.Drawing.Point(476, 296);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(54, 13);
		this.labelControl5.TabIndex = 15;
		this.labelControl5.Text = "Contacts:";
		this.pictureEdit1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.poweredBy;
		this.pictureEdit1.Location = new System.Drawing.Point(476, 0);
		this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(183, 50);
		this.pictureEdit1.TabIndex = 12;
		this.labelControl6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl6.Appearance.Options.UseFont = true;
		this.labelControl6.Location = new System.Drawing.Point(22, 238);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(464, 16);
		this.labelControl6.TabIndex = 16;
		this.labelControl6.Text = "Fees collection made easy with Surepay.  Powered by Airtel Money && MTN MoMo";
		this.pictureEdit2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.pictureEdit2.EditValue = resources.GetObject("pictureEdit2.EditValue");
		this.pictureEdit2.Location = new System.Drawing.Point(22, 261);
		this.pictureEdit2.Name = "pictureEdit2";
		this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
		this.pictureEdit2.Properties.ShowMenu = false;
		this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit2.Size = new System.Drawing.Size(266, 102);
		this.pictureEdit2.TabIndex = 17;
		this.pictureEdit3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.pictureEdit3.EditValue = resources.GetObject("pictureEdit3.EditValue");
		this.pictureEdit3.Location = new System.Drawing.Point(294, 300);
		this.pictureEdit3.Name = "pictureEdit3";
		this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
		this.pictureEdit3.Properties.ShowMenu = false;
		this.pictureEdit3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit3.Size = new System.Drawing.Size(176, 63);
		this.pictureEdit3.TabIndex = 18;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.pictureEdit3);
		base.Controls.Add(this.pictureEdit2);
		base.Controls.Add(this.labelControl6);
		base.Controls.Add(this.labelControl5);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.linkLabel1);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.panelControl1);
		base.Name = "usrMainDashBoard";
		base.Size = new System.Drawing.Size(662, 411);
		base.Load += new System.EventHandler(usrMainDashBoard_Load);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		this.panelControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit3.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
