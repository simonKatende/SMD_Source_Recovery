using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AlienAge.ReportHeaders;

public class Form1 : XtraForm
{
	private IContainer components = null;

	public Form1()
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
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(948, 406);
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "Form1";
		this.Text = "Form1";
		base.ResumeLayout(false);
	}
}
