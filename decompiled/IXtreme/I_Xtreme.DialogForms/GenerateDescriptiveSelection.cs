using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class GenerateDescriptiveSelection : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private ComboBoxEdit cboStream;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private ComboBoxEdit cboTerm;

	private ComboBoxEdit cboClass;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private DXValidationProvider dxValidationProvider1;

	public GenerateDescriptiveSelection()
	{
		InitializeComponent();
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboTerm });
		cboTerm.SelectedItem = WorkingSemesters.GetWorkingSemester();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
		cboClass.EditValueChanged += CboClass_EditValueChanged;
	}

	private void CboClass_EditValueChanged(object sender, EventArgs e)
	{
		if (cboClass.EditValue != null)
		{
			Stream.LoadStreams(cboClass.Text, cboStream);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count == 0)
			{
				ReportCustomization.InitializeReportSetting();
				GenerateDescriptive generateDescriptive = new GenerateDescriptive(cboClass.Text, cboStream.Text, cboTerm.Text);
				generateDescriptive.ShowDialog();
				break;
			}
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
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.cboTerm = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.cboStream);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.cboTerm);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(365, 129);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.dxValidationProvider1.SetIconAlignment(this.cboStream, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboStream.Location = new System.Drawing.Point(58, 32);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Appearance.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboStream.Properties.Appearance.Options.UseFont = true;
		this.cboStream.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboStream.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Size = new System.Drawing.Size(303, 24);
		this.cboStream.StyleController = this.layoutControl1;
		this.cboStream.TabIndex = 1;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboStream, conditionValidationRule);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(184, 103);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(177, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 4;
		this.simpleButton2.Text = "Close";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(4, 103);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(176, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 3;
		this.simpleButton1.Text = "Populate Datasheet";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.cboTerm.Location = new System.Drawing.Point(58, 60);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.Appearance.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboTerm.Properties.Appearance.Options.UseFont = true;
		this.cboTerm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboTerm.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTerm.Size = new System.Drawing.Size(303, 24);
		this.cboTerm.StyleController = this.layoutControl1;
		this.cboTerm.TabIndex = 2;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboTerm, conditionValidationRule2);
		this.cboClass.Location = new System.Drawing.Point(58, 4);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Appearance.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboClass.Properties.Appearance.Options.UseFont = true;
		this.cboClass.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboClass.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Size = new System.Drawing.Size(303, 24);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 0;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.cboClass, conditionValidationRule3);
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem1, this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(365, 129);
		this.Root.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboClass;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem1.Text = "Class";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(42, 16);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 84);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(361, 15);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.cboTerm;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem2.Text = "Term";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(42, 16);
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 99);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(180, 26);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.Location = new System.Drawing.Point(180, 99);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(181, 26);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.cboStream;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem5.Text = "Stream";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(42, 16);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(365, 129);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "GenerateDescriptiveSelection";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Populate Datasheet - Descriptive Report";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
