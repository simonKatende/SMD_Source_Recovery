using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme.NavigationForms;

public class usrArabicTheology : XtraUserControl
{
	private IContainer components = null;

	public usrArabicTheology()
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
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Name = "usrArabicTheology";
		base.Size = new System.Drawing.Size(825, 543);
		base.ResumeLayout(false);
	}
}
