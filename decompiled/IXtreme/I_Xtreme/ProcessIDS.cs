using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme;

public class ProcessIDS : XtraForm
{
	private int k;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	public LabelControl lblStudentClass;

	public LabelControl lblStudentStream;

	public LabelControl lblIssueDate;

	public LabelControl lblValidityDate;

	private Timer timer1;

	public ProcessIDS()
	{
		InitializeComponent();
	}

	private void ProcessIDS_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to Cancel the process?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				base.KeyPreview = false;
				Text = "Deleting records...";
				StudentIdentityCards.DeleteIds(Convert.ToDateTime(lblIssueDate.Text).Year, lblStudentClass.Text, lblStudentStream.Text, progressBarControl1);
				base.KeyPreview = true;
				Close();
			}
			else
			{
				progressBarControl1.Position = 0;
				StudentIdentityCards.GenerateClassIds(lblStudentClass.Text, lblStudentStream.Text, Convert.ToDateTime(lblIssueDate.Text), Convert.ToDateTime(lblValidityDate.Text), progressBarControl1);
			}
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 5)
		{
			timer1.Enabled = false;
			progressBarControl1.Position = 0;
			StudentIdentityCards.GenerateClassIds(lblStudentClass.Text, lblStudentStream.Text, Convert.ToDateTime(lblIssueDate.Text), Convert.ToDateTime(lblValidityDate.Text), progressBarControl1);
			Close();
		}
	}

	private void ProcessIDS_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
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
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.lblStudentClass = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentStream = new DevExpress.XtraEditors.LabelControl();
		this.lblIssueDate = new DevExpress.XtraEditors.LabelControl();
		this.lblValidityDate = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.progressBarControl1.Location = new System.Drawing.Point(3, 12);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Size = new System.Drawing.Size(276, 18);
		this.progressBarControl1.TabIndex = 0;
		this.lblStudentClass.Location = new System.Drawing.Point(12, 31);
		this.lblStudentClass.Name = "lblStudentClass";
		this.lblStudentClass.Size = new System.Drawing.Size(25, 13);
		this.lblStudentClass.TabIndex = 1;
		this.lblStudentClass.Text = "Class";
		this.lblStudentClass.Visible = false;
		this.lblStudentStream.Location = new System.Drawing.Point(43, 32);
		this.lblStudentStream.Name = "lblStudentStream";
		this.lblStudentStream.Size = new System.Drawing.Size(34, 13);
		this.lblStudentStream.TabIndex = 2;
		this.lblStudentStream.Text = "Stream";
		this.lblStudentStream.Visible = false;
		this.lblIssueDate.Location = new System.Drawing.Point(83, 31);
		this.lblIssueDate.Name = "lblIssueDate";
		this.lblIssueDate.Size = new System.Drawing.Size(49, 13);
		this.lblIssueDate.TabIndex = 3;
		this.lblIssueDate.Text = "IssueDate";
		this.lblIssueDate.Visible = false;
		this.lblValidityDate.Location = new System.Drawing.Point(148, 32);
		this.lblValidityDate.Name = "lblValidityDate";
		this.lblValidityDate.Size = new System.Drawing.Size(57, 13);
		this.lblValidityDate.TabIndex = 4;
		this.lblValidityDate.Text = "ValidityDate";
		this.lblValidityDate.Visible = false;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 45);
		base.Controls.Add(this.lblValidityDate);
		base.Controls.Add(this.lblIssueDate);
		base.Controls.Add(this.lblStudentStream);
		base.Controls.Add(this.lblStudentClass);
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.Name = "ProcessIDS";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Creatings Ids... Press ESC to cancel";
		base.Load += new System.EventHandler(ProcessIDS_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(ProcessIDS_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
