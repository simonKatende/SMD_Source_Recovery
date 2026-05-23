using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class CustomDialog : XtraForm
{
	private int i;

	private IContainer components = null;

	private LabelControl labelControl132;

	private Timer timer1;

	public CustomDialog()
	{
		InitializeComponent();
	}

	private void CustomDialog_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	public static void ShowCustomDialog(string message)
	{
		using CustomDialog customDialog = new CustomDialog();
		customDialog.labelControl132.Text = message;
		customDialog.ShowDialog();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 5)
		{
			timer1.Enabled = false;
			i = 0;
			Dispose();
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
		this.labelControl132 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		base.SuspendLayout();
		this.labelControl132.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.labelControl132.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl132.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl132.Location = new System.Drawing.Point(0, 12);
		this.labelControl132.Name = "labelControl132";
		this.labelControl132.Size = new System.Drawing.Size(240, 23);
		this.labelControl132.TabIndex = 26;
		this.labelControl132.Text = "Success!";
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(241, 49);
		base.Controls.Add(this.labelControl132);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "CustomDialog";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Success";
		base.Load += new System.EventHandler(CustomDialog_Load);
		base.ResumeLayout(false);
	}
}
