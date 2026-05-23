using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme.DialogForms;

public class ConfirmSubjectLoginDelete : XtraForm
{
	private IContainer components = null;

	private SimpleButton btnThisSubject;

	private SimpleButton btnAllSubjects;

	private SimpleButton simpleButton3;

	public LabelControl lblDeleteAction;

	public ConfirmSubjectLoginDelete()
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
		this.btnThisSubject = new DevExpress.XtraEditors.SimpleButton();
		this.btnAllSubjects = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.lblDeleteAction = new DevExpress.XtraEditors.LabelControl();
		base.SuspendLayout();
		this.btnThisSubject.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnThisSubject.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.btnThisSubject.Location = new System.Drawing.Point(12, 57);
		this.btnThisSubject.Name = "btnThisSubject";
		this.btnThisSubject.Size = new System.Drawing.Size(126, 23);
		this.btnThisSubject.TabIndex = 0;
		this.btnThisSubject.Text = "Selected Subject Only";
		this.btnAllSubjects.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnAllSubjects.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.btnAllSubjects.Location = new System.Drawing.Point(144, 57);
		this.btnAllSubjects.Name = "btnAllSubjects";
		this.btnAllSubjects.Size = new System.Drawing.Size(139, 23);
		this.btnAllSubjects.TabIndex = 1;
		this.btnAllSubjects.Text = "All Subjects";
		this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton3.Location = new System.Drawing.Point(289, 57);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(142, 23);
		this.simpleButton3.TabIndex = 2;
		this.simpleButton3.Text = "Cancel";
		this.lblDeleteAction.Appearance.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDeleteAction.Location = new System.Drawing.Point(13, 13);
		this.lblDeleteAction.Name = "lblDeleteAction";
		this.lblDeleteAction.Size = new System.Drawing.Size(235, 14);
		this.lblDeleteAction.TabIndex = 3;
		this.lblDeleteAction.Text = "How do you wish to delete this user login?";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(443, 95);
		base.Controls.Add(this.lblDeleteAction);
		base.Controls.Add(this.simpleButton3);
		base.Controls.Add(this.btnAllSubjects);
		base.Controls.Add(this.btnThisSubject);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ConfirmSubjectLoginDelete";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Confirm";
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
