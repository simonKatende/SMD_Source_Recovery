using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;

namespace I_Xtreme.DialogForms;

public class PayrollCreator : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private TextBox textBox1;

	private TextEdit textEdit1;

	private ComboBoxEdit cboPaymentCycle;

	private LayoutControlGroup layoutControlGroup1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layOutRate;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem5;

	private TextEdit textEdit2;

	private LayoutControlItem layoutControlItem3;

	public PayrollCreator()
	{
		InitializeComponent();
	}

	private void cboPaymentCycle_Closed(object sender, ClosedEventArgs e)
	{
		if (cboPaymentCycle.SelectedIndex > -1)
		{
			layOutRate.Text = $"{cboPaymentCycle.SelectedItem.ToString()} Rate";
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.cboPaymentCycle = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.layOutRate = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboPaymentCycle.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layOutRate).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.textEdit2);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.textBox1);
		this.layoutControl1.Controls.Add(this.textEdit1);
		this.layoutControl1.Controls.Add(this.cboPaymentCycle);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(734, 559);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.emptySpaceItem1, this.layoutControlItem2, this.layOutRate, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem3, this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Size = new System.Drawing.Size(734, 559);
		this.layoutControlGroup1.TextVisible = false;
		this.cboPaymentCycle.Location = new System.Drawing.Point(87, 36);
		this.cboPaymentCycle.Name = "cboPaymentCycle";
		this.cboPaymentCycle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboPaymentCycle.Properties.Items.AddRange(new object[8] { "Daily", "Weekly", "Bi-Weekly", "Semi-Monthly", "Monthly", "Quarterly", "Semi-Annually", "Annualy" });
		this.cboPaymentCycle.Size = new System.Drawing.Size(635, 20);
		this.cboPaymentCycle.StyleController = this.layoutControl1;
		this.cboPaymentCycle.TabIndex = 4;
		this.cboPaymentCycle.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboPaymentCycle_Closed);
		this.layoutControlItem1.Control = this.cboPaymentCycle;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(714, 24);
		this.layoutControlItem1.Text = "Payment Cycle";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(71, 13);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 130);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(714, 409);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.textEdit1.Location = new System.Drawing.Point(87, 118);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Size = new System.Drawing.Size(635, 20);
		this.textEdit1.StyleController = this.layoutControl1;
		this.textEdit1.TabIndex = 5;
		this.layoutControlItem2.Control = this.textEdit1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 106);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(714, 24);
		this.layoutControlItem2.Text = "Rate";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(71, 13);
		this.textBox1.Location = new System.Drawing.Point(87, 77);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(635, 20);
		this.textBox1.TabIndex = 6;
		this.layOutRate.Control = this.textBox1;
		this.layOutRate.Location = new System.Drawing.Point(0, 65);
		this.layOutRate.Name = "layOutRate";
		this.layOutRate.Size = new System.Drawing.Size(714, 24);
		this.layOutRate.Text = "Basic Pay";
		this.layOutRate.TextSize = new System.Drawing.Size(71, 13);
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.LineVisible = true;
		this.labelControl1.Location = new System.Drawing.Point(12, 101);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(710, 13);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 7;
		this.labelControl1.Text = "Salary 2";
		this.layoutControlItem4.Control = this.labelControl1;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 89);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(714, 17);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.LineVisible = true;
		this.labelControl2.Location = new System.Drawing.Point(12, 60);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(710, 13);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 8;
		this.labelControl2.Text = "Salary 1";
		this.layoutControlItem5.Control = this.labelControl2;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(714, 17);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.textEdit2.Location = new System.Drawing.Point(87, 12);
		this.textEdit2.Name = "textEdit2";
		this.textEdit2.Size = new System.Drawing.Size(635, 20);
		this.textEdit2.StyleController = this.layoutControl1;
		this.textEdit2.TabIndex = 9;
		this.layoutControlItem3.Control = this.textEdit2;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(714, 24);
		this.layoutControlItem3.Text = "Gross Pay";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(71, 13);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(734, 559);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "PayrollCreator";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "PayrollCreator";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboPaymentCycle.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layOutRate).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit2.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
