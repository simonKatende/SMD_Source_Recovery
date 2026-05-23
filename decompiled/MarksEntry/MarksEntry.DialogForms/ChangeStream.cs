using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace MarksEntry.DialogForms;

public class ChangeStream : XtraForm
{
	public string stream = string.Empty;

	private IContainer components = null;

	private RadialMenu radialMenu1;

	private BarManager barManager1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private ComboBoxEdit comboBoxEdit1;

	private Timer timer1;

	public ChangeStream(string _Class)
	{
		InitializeComponent();
		TeacherLogin.LoadStreams(_Class, comboBoxEdit1);
	}

	private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
	{
		if (comboBoxEdit1.EditValue != null)
		{
			stream = comboBoxEdit1.EditValue.ToString();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (comboBoxEdit1.EditValue != null)
		{
			simpleButton1.Enabled = true;
		}
		else
		{
			simpleButton1.Enabled = false;
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
		this.radialMenu1 = new DevExpress.XtraBars.Ribbon.RadialMenu(this.components);
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.radialMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.radialMenu1.Manager = this.barManager1;
		this.radialMenu1.Name = "radialMenu1";
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.MaxItemId = 5;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(460, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 97);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(460, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 97);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(460, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 97);
		this.comboBoxEdit1.Location = new System.Drawing.Point(98, 12);
		this.comboBoxEdit1.MenuManager = this.barManager1;
		this.comboBoxEdit1.Name = "comboBoxEdit1";
		this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
		this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.comboBoxEdit1.Size = new System.Drawing.Size(350, 32);
		this.comboBoxEdit1.TabIndex = 4;
		this.comboBoxEdit1.EditValueChanged += new System.EventHandler(comboBoxEdit1_EditValueChanged);
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.simpleButton1.Location = new System.Drawing.Point(242, 50);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(100, 34);
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Continue";
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(348, 50);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(100, 34);
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Cancel";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Location = new System.Drawing.Point(12, 20);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(64, 24);
		this.labelControl1.TabIndex = 7;
		this.labelControl1.Text = "Stream";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(460, 97);
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.simpleButton2);
		base.Controls.Add(this.simpleButton1);
		base.Controls.Add(this.comboBoxEdit1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ChangeStream";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Change Stream";
		((System.ComponentModel.ISupportInitialize)this.radialMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.comboBoxEdit1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
