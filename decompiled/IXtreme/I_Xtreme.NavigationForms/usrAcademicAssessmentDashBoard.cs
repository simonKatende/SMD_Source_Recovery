using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrAcademicAssessmentDashBoard : XtraUserControl
{
	private IContainer components = null;

	private PictureEdit pictureEdit1;

	private LabelControl labelControl1;

	public usrAcademicAssessmentDashBoard()
	{
		InitializeComponent();
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
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.academicAssessmentDB;
		this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
		this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(646, 451);
		this.pictureEdit1.TabIndex = 0;
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl1.Location = new System.Drawing.Point(0, 81);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
		this.labelControl1.Size = new System.Drawing.Size(646, 37);
		this.labelControl1.TabIndex = 5;
		this.labelControl1.Text = "Academic Assessment";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.pictureEdit1);
		base.Name = "usrAcademicAssessmentDashBoard";
		base.Size = new System.Drawing.Size(646, 451);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
