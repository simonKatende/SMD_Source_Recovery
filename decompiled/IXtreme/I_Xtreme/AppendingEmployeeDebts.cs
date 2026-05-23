using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using I_Xtreme.Properties;

namespace I_Xtreme;

public class AppendingEmployeeDebts : XtraForm
{
	private int i;

	private IContainer components = null;

	private Timer timer1;

	private BackgroundWorker backgroundWorker1;

	private SimpleButton btnOk;

	private PictureEdit pictureEdit1;

	private LabelControl labelControl1;

	public AppendingEmployeeDebts()
	{
		InitializeComponent();
	}

	private void AppendingEmployeeDebts_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 5)
		{
			timer1.Enabled = false;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		EmployeeDebts.AppendEmployeeDebts();
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		btnOk.Enabled = true;
		labelControl1.Text = EmployeeDebts.Particular() + " Successfully appended";
		Text = "Success";
		SystemSounds.Exclamation.Play();
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
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.btnOk = new DevExpress.XtraEditors.SimpleButton();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnOk.Enabled = false;
		this.btnOk.Location = new System.Drawing.Point(115, 49);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(51, 23);
		this.btnOk.TabIndex = 5;
		this.btnOk.Text = "Ok";
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.indicator_32;
		this.pictureEdit1.Location = new System.Drawing.Point(237, 3);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(41, 41);
		this.pictureEdit1.TabIndex = 4;
		this.labelControl1.Location = new System.Drawing.Point(12, 18);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(200, 13);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Please wait as this may take a longer time";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
		base.BackgroundImageStore = I_Xtreme.Properties.Resources.bg;
		base.ClientSize = new System.Drawing.Size(284, 76);
		base.Controls.Add(this.btnOk);
		base.Controls.Add(this.pictureEdit1);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "AppendingEmployeeDebts";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Appending Employee Debts...";
		base.Load += new System.EventHandler(AppendingEmployeeDebts_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
