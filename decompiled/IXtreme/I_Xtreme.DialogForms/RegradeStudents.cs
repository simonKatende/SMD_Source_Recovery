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

public class RegradeStudents : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private ComboBoxEdit cboTerm;

	private ComboBoxEdit cboClass;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private DXValidationProvider dxValidationProvider1;

	private ComboBoxEdit cboStream;

	private LayoutControlItem layoutControlItem5;

	private CheckEdit chkClassPosition;

	private LayoutControlItem layoutControlItem7;

	private CheckEdit chkSubjectPosition;

	private LayoutControlItem layoutControlItem6;

	public RegradeStudents()
	{
		InitializeComponent();
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboTerm });
		cboTerm.SelectedItem = WorkingSemesters.GetWorkingSemester();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count == 0)
			{
				RegradeStudentsProgressNC regradeStudentsProgressNC = new RegradeStudentsProgressNC(cboClass.EditValue.ToString(), cboTerm.EditValue.ToString(), cboStream.Text, Convert.ToBoolean(chkClassPosition.EditValue), Convert.ToBoolean(chkSubjectPosition.EditValue));
				regradeStudentsProgressNC.ShowDialog();
				break;
			}
		}
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		if (cboClass.EditValue != null)
		{
			Stream.LoadStreams(cboClass.EditValue.ToString(), cboStream);
			cboStream.Properties.Items.Add(" All Streams ");
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.chkSubjectPosition = new DevExpress.XtraEditors.CheckEdit();
		this.chkClassPosition = new DevExpress.XtraEditors.CheckEdit();
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
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chkSubjectPosition.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkClassPosition.Properties).BeginInit();
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
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.chkSubjectPosition);
		this.layoutControl1.Controls.Add(this.chkClassPosition);
		this.layoutControl1.Controls.Add(this.cboStream);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.cboTerm);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(2);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(375, 197);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.chkSubjectPosition.Location = new System.Drawing.Point(3, 29);
		this.chkSubjectPosition.Name = "chkSubjectPosition";
		this.chkSubjectPosition.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.chkSubjectPosition.Properties.Appearance.Options.UseFont = true;
		this.chkSubjectPosition.Properties.Caption = "Process subject positions";
		this.chkSubjectPosition.Size = new System.Drawing.Size(369, 22);
		this.chkSubjectPosition.StyleController = this.layoutControl1;
		this.chkSubjectPosition.TabIndex = 11;
		this.chkClassPosition.Location = new System.Drawing.Point(3, 3);
		this.chkClassPosition.Name = "chkClassPosition";
		this.chkClassPosition.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.chkClassPosition.Properties.Appearance.Options.UseFont = true;
		this.chkClassPosition.Properties.Caption = "Process class and stream positions";
		this.chkClassPosition.Size = new System.Drawing.Size(369, 22);
		this.chkClassPosition.StyleController = this.layoutControl1;
		this.chkClassPosition.TabIndex = 10;
		this.dxValidationProvider1.SetIconAlignment(this.cboStream, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboStream.Location = new System.Drawing.Point(57, 83);
		this.cboStream.Margin = new System.Windows.Forms.Padding(2);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Appearance.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboStream.Properties.Appearance.Options.UseFont = true;
		this.cboStream.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboStream.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Properties.Sorted = true;
		this.cboStream.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStream.Size = new System.Drawing.Size(315, 24);
		this.cboStream.StyleController = this.layoutControl1;
		this.cboStream.TabIndex = 8;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule.ErrorText = "This value is not valid";
		conditionValidationRule.Value1 = "-N/A-";
		this.dxValidationProvider1.SetValidationRule(this.cboStream, conditionValidationRule);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(3, 170);
		this.simpleButton2.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(187, 24);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 7;
		this.simpleButton2.Text = "Continue";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(194, 170);
		this.simpleButton1.Margin = new System.Windows.Forms.Padding(2);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(178, 24);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 6;
		this.simpleButton1.Text = "Close";
		this.cboTerm.Location = new System.Drawing.Point(57, 111);
		this.cboTerm.Margin = new System.Windows.Forms.Padding(2);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.Appearance.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboTerm.Properties.Appearance.Options.UseFont = true;
		this.cboTerm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboTerm.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTerm.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboTerm.Size = new System.Drawing.Size(315, 24);
		this.cboTerm.StyleController = this.layoutControl1;
		this.cboTerm.TabIndex = 5;
		this.dxValidationProvider1.SetIconAlignment(this.cboClass, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboClass.Location = new System.Drawing.Point(57, 55);
		this.cboClass.Margin = new System.Windows.Forms.Padding(2);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Appearance.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboClass.Properties.Appearance.Options.UseFont = true;
		this.cboClass.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Cascadia Code", 9.5f);
		this.cboClass.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(315, 24);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 4;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
		conditionValidationRule2.ErrorText = "This value is not valid";
		conditionValidationRule2.Value1 = "-N/A-";
		this.dxValidationProvider1.SetValidationRule(this.cboClass, conditionValidationRule2);
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem1, this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem6 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.Root.Size = new System.Drawing.Size(375, 197);
		this.Root.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboClass;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(373, 28);
		this.layoutControlItem1.Text = "Class";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 19);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 136);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(373, 31);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.cboTerm;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 108);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(373, 28);
		this.layoutControlItem2.Text = "Term";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 19);
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(191, 167);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(182, 28);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 167);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(191, 28);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.cboStream;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 80);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(373, 28);
		this.layoutControlItem5.Text = "Stream";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 19);
		this.layoutControlItem7.Control = this.chkClassPosition;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(373, 26);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem6.Control = this.chkSubjectPosition;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 26);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(373, 26);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(375, 197);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.MaximizeBox = false;
		base.Name = "RegradeStudents";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Process Reports";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.chkSubjectPosition.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkClassPosition.Properties).EndInit();
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
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
