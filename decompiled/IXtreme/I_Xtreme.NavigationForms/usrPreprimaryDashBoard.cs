using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme.NavigationForms;

public class usrPreprimaryDashBoard : XtraUserControl
{
	private IContainer components = null;

	public usrPreprimaryDashBoard()
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
		base.Name = "usrPreprimaryDashBoard";
		base.Size = new System.Drawing.Size(741, 522);
		base.ResumeLayout(false);
	}
}
