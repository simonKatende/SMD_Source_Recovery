using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Camera;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class CameraCapture : XtraForm
{
	private readonly Rectangle rect;

	private IContainer components = null;

	private SimpleButton btnCapture;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem6;

	private SeparatorControl separatorControl1;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private CameraControl cameraControl1;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem1;

	public CameraCapture()
	{
		InitializeComponent();
		rect = new Rectangle
		{
			Size = new Size(405, 409),
			Location = new Point(7, 5)
		};
	}

	public Image GetCroppedImage()
	{
		try
		{
			int srcWidth = 500;
			int srcHeight = 480;
			int srcX = 60;
			int srcY = 3;
			Image image = Image.FromFile(Path.GetTempPath() + "\\SMD_Cam_OriginalImage.Bmp");
			Bitmap bitmap = new Bitmap(srcWidth, srcHeight, PixelFormat.Format24bppRgb);
			bitmap.SetResolution(80f, 80f);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.DrawImage(image, new Rectangle(0, 0, srcWidth, srcHeight), srcX, srcY, srcWidth, srcHeight, GraphicsUnit.Pixel);
			image.Dispose();
			graphics.Dispose();
			return bitmap;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message);
			return null;
		}
	}

	private void btnCapture_Click(object sender, EventArgs e)
	{
		try
		{
			cameraControl1.Device.CurrentFrame.Save(Path.GetTempPath() + "\\SMD_Cam_OriginalImage.Bmp");
			base.DialogResult = DialogResult.OK;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CameraCapture_KeyDown(object sender, KeyEventArgs e)
	{
		try
		{
			if (e.KeyCode == Keys.C && btnCapture.Enabled)
			{
				cameraControl1.Device.CurrentFrame.Save(Path.GetTempPath() + "\\SMD_Cam_OriginalImage.Bmp");
				base.DialogResult = DialogResult.OK;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				Dispose();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show($"{ex.Message}\n{ex.HelpLink}\n{ex.InnerException}\n{ex.Source}\n{ex.StackTrace}", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cameraControl1_Paint(object sender, PaintEventArgs e)
	{
		Pen yellowGreen = Pens.YellowGreen;
		e.Graphics.DrawRectangle(yellowGreen, rect);
	}

	private void CameraCapture_Load(object sender, EventArgs e)
	{
		if (cameraControl1.Device == null)
		{
			btnCapture.Enabled = false;
		}
		else
		{
			btnCapture.Enabled = true;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.cameraControl1 = new DevExpress.XtraEditors.Camera.CameraControl();
		this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.btnCapture = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.separatorControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.separatorControl1);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.btnCapture);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(424, 481);
		this.layoutControl1.TabIndex = 23;
		this.layoutControl1.Text = "layoutControl1";
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Controls.Add(this.cameraControl1);
		this.panelControl1.Location = new System.Drawing.Point(2, 2);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(420, 419);
		this.panelControl1.TabIndex = 21;
		this.cameraControl1.BackgroundImage = I_Xtreme.Properties.Resources.cam_backImg;
		this.cameraControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.cameraControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.cameraControl1.DeviceNotFoundString = "No camera detected";
		this.cameraControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cameraControl1.Location = new System.Drawing.Point(0, 0);
		this.cameraControl1.Name = "cameraControl1";
		this.cameraControl1.Size = new System.Drawing.Size(420, 419);
		this.cameraControl1.TabIndex = 0;
		this.cameraControl1.Text = "cameraControl1";
		this.cameraControl1.VideoStretchMode = DevExpress.XtraEditors.Camera.VideoStretchMode.None;
		this.cameraControl1.Paint += new System.Windows.Forms.PaintEventHandler(cameraControl1_Paint);
		this.separatorControl1.Location = new System.Drawing.Point(2, 425);
		this.separatorControl1.Name = "separatorControl1";
		this.separatorControl1.Size = new System.Drawing.Size(420, 20);
		this.separatorControl1.TabIndex = 20;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(209, 449);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(213, 30);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 18;
		this.simpleButton1.Text = "C&lose";
		this.btnCapture.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.btnCapture.Appearance.Options.UseFont = true;
		this.btnCapture.Location = new System.Drawing.Point(2, 449);
		this.btnCapture.Name = "btnCapture";
		this.btnCapture.Size = new System.Drawing.Size(203, 30);
		this.btnCapture.StyleController = this.layoutControl1;
		this.btnCapture.TabIndex = 17;
		this.btnCapture.Text = "&Capture";
		this.btnCapture.Click += new System.EventHandler(btnCapture_Click);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem6, this.layoutControlItem2, this.layoutControlItem4, this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(424, 481);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem6.Control = this.btnCapture;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 447);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(207, 34);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.Location = new System.Drawing.Point(207, 447);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(217, 34);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem4.Control = this.separatorControl1;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 423);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(424, 24);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem1.Control = this.panelControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(5, 5);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(424, 423);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.labelControl1.Location = new System.Drawing.Point(101, 470);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(50, 13);
		this.labelControl1.TabIndex = 21;
		this.labelControl1.Text = "Brightness";
		this.labelControl2.Location = new System.Drawing.Point(357, 470);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(42, 13);
		this.labelControl2.TabIndex = 22;
		this.labelControl2.Text = "Contrast";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(424, 481);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "CameraCapture";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Capture Photo";
		base.TopMost = true;
		base.Load += new System.EventHandler(CameraCapture_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(CameraCapture_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.separatorControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
