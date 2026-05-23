using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.Properties;

namespace I_Xtreme.DialogForms;

public class TrialExpired : XtraForm
{
	private IContainer components = null;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl3;

	private SimpleButton simpleButton1;

	private LabelControl labelControl4;

	private PictureEdit pictureEdit1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton3;

	private SimpleButton simpleButton4;

	private SimpleButton simpleButton5;

	public TrialExpired()
	{
		InitializeComponent();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Application.ExitThread();
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
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tempus Sans ITC", 21.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(53, 12);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(393, 35);
		this.labelControl1.TabIndex = 0;
		this.labelControl1.Text = "Ooops!";
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
		this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl2.Location = new System.Drawing.Point(53, 185);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(405, 38);
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Your  license has expired.\r\n Please renew your license to continue using the software";
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.Location = new System.Drawing.Point(53, 247);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(405, 19);
		this.labelControl3.TabIndex = 2;
		this.labelControl3.Text = "You may contact your software vendor.";
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(118, 397);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(88, 23);
		this.simpleButton1.TabIndex = 3;
		this.simpleButton1.Text = "Renew License";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl4.Visible = true;
		this.labelControl4.Location = new System.Drawing.Point(53, 164);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(393, 25);
		this.labelControl4.TabIndex = 4;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources._lock;
		this.pictureEdit1.Location = new System.Drawing.Point(193, 53);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(113, 110);
		this.pictureEdit1.TabIndex = 5;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.Location = new System.Drawing.Point(433, 397);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(88, 23);
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Exit";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton3.Location = new System.Drawing.Point(13, 397);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(88, 23);
		this.simpleButton3.TabIndex = 7;
		this.simpleButton3.Text = "Buy";
		this.simpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton4.Location = new System.Drawing.Point(328, 397);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(88, 23);
		this.simpleButton4.TabIndex = 8;
		this.simpleButton4.Text = "Learn More...";
		this.simpleButton5.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton5.Location = new System.Drawing.Point(223, 397);
		this.simpleButton5.Name = "simpleButton5";
		this.simpleButton5.Size = new System.Drawing.Size(88, 23);
		this.simpleButton5.TabIndex = 9;
		this.simpleButton5.Text = "Try";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(530, 433);
		base.Controls.Add(this.simpleButton5);
		base.Controls.Add(this.simpleButton4);
		base.Controls.Add(this.simpleButton3);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.labelControl4);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.labelControl3);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "TrialExpired";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Trial Expired";
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
