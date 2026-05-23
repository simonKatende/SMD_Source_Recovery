using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LibraryManagement.NavigationForms;

public class usrMainDashBoard : XtraUserControl
{
	private IContainer components = null;

	public usrMainDashBoard()
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
		base.Name = "usrMainDashBoard";
		base.Size = new System.Drawing.Size(738, 517);
		base.ResumeLayout(false);
	}
}
