using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Accounts;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class PayrollInitialization : XtraForm
{
	public string PayrollPeriod = string.Empty;

	public BudgetParameters InitializeBudget;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem5;

	private Timer timer1;

	private ComboBoxEdit cboMonth;

	private LayoutControlItem layoutControlItem6;

	private SpinEdit spnYear;

	public PayrollInitialization()
	{
		InitializeComponent();
		LoadYears();
	}

	private void LoadYears()
	{
		spnYear.Properties.MinValue = DateTime.Now.Year - 1;
		spnYear.Properties.MaxValue = DateTime.Now.Year + 1;
		spnYear.EditValue = DateTime.Now.Year;
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		string text = $"{cboMonth.SelectedItem.ToString()}-{spnYear.EditValue.ToString()}";
		Payroll payroll = new Payroll(text);
		if (payroll.PayrollNotExists)
		{
			PayrollProgress payrollProgress = new PayrollProgress(cboMonth.SelectedItem.ToString(), Convert.ToInt32(spnYear.EditValue.ToString()));
			if (payrollProgress.ShowDialog() == DialogResult.OK)
			{
				PayrollPeriod = text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
		else if (XtraMessageBox.Show("The payroll for period (" + text + ") already exists. Do you wish to re-run the process?", "Duplicate Entry", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			PayrollProgress payrollProgress2 = new PayrollProgress(cboMonth.SelectedItem.ToString(), Convert.ToInt32(spnYear.EditValue.ToString()));
			if (payrollProgress2.ShowDialog() == DialogResult.OK)
			{
				PayrollPeriod = text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (cboMonth.EditValue == null)
		{
			simpleButton1.Enabled = false;
		}
		else
		{
			simpleButton1.Enabled = true;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.cboMonth = new DevExpress.XtraEditors.ComboBoxEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.spnYear = new DevExpress.XtraEditors.SpinEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboMonth.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.spnYear.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboMonth);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.spnYear);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(535, 186);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.cboMonth.Location = new System.Drawing.Point(71, 2);
		this.cboMonth.Margin = new System.Windows.Forms.Padding(4);
		this.cboMonth.Name = "cboMonth";
		this.cboMonth.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.cboMonth.Properties.Appearance.Options.UseFont = true;
		this.cboMonth.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.cboMonth.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboMonth.Properties.Items.AddRange(new object[12]
		{
			"January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
			"November", "December"
		});
		this.cboMonth.Size = new System.Drawing.Size(462, 38);
		this.cboMonth.StyleController = this.layoutControl1;
		this.cboMonth.TabIndex = 9;
		this.labelControl1.Location = new System.Drawing.Point(2, 84);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(531, 19);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 8;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(270, 147);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(4);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(263, 37);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 7;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(2, 147);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(264, 37);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.spnYear.EditValue = new decimal(new int[4]);
		this.spnYear.Location = new System.Drawing.Point(71, 44);
		this.spnYear.Margin = new System.Windows.Forms.Padding(4);
		this.spnYear.Name = "spnYear";
		this.spnYear.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.spnYear.Properties.Appearance.Options.UseFont = true;
		this.spnYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.spnYear.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
		this.spnYear.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
		this.spnYear.Properties.MaxLength = 4;
		this.spnYear.Size = new System.Drawing.Size(462, 36);
		this.spnYear.StyleController = this.layoutControl1;
		this.spnYear.TabIndex = 5;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem3, this.layoutControlItem4, this.emptySpaceItem1, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(535, 186);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 145);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(268, 41);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(268, 145);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(267, 41);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 105);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(535, 40);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.Control = this.labelControl1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 82);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(535, 23);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.cboMonth;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(535, 42);
		this.layoutControlItem6.Text = "Month";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(66, 29);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.spnYear;
		this.layoutControlItem2.CustomizationFormText = "Year:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 42);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(535, 40);
		this.layoutControlItem2.Text = "Year";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 29);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(535, 186);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.Name = "PayrollInitialization";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Payroll Initialization";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboMonth.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.spnYear.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
