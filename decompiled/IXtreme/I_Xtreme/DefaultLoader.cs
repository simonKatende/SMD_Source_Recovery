using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class DefaultLoader : XtraUserControl
{
	private IContainer components = null;

	public DefaultLoader()
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
		this.components = new System.ComponentModel.Container();
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	}
}
