using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AwardWaiver : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit textEdit1;

	private LayoutControlItem layoutControlItem1;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private DXValidationProvider dxValidationProvider1;

	private MemoEdit txtNarration;

	private LayoutControlItem layoutControlItem4;

	public double WaiverAmount { get; set; }

	public string Narration { get; set; }

	public AwardWaiver()
	{
		InitializeComponent();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count == 0)
			{
				double result = (double.TryParse(textEdit1.Text, out result) ? result : 0.0);
				Narration = txtNarration.Text;
				WaiverAmount = result;
				base.DialogResult = DialogResult.OK;
				Close();
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtNarration = new DevExpress.XtraEditors.MemoEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txtNarration);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.textEdit1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(307, 150);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.txtNarration.Location = new System.Drawing.Point(4, 53);
		this.txtNarration.Name = "txtNarration";
		this.txtNarration.Properties.MaxLength = 50;
		this.txtNarration.Size = new System.Drawing.Size(299, 56);
		this.txtNarration.StyleController = this.layoutControl1;
		this.txtNarration.TabIndex = 7;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "Narration cannot be blank";
		this.dxValidationProvider1.SetValidationRule(this.txtNarration, conditionValidationRule);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(4, 123);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(140, 23);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 6;
		this.simpleButton2.Text = "Add Waiver";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(148, 123);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(155, 23);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 5;
		this.simpleButton1.Text = "Close";
		this.dxValidationProvider1.SetIconAlignment(this.textEdit1, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.textEdit1.Location = new System.Drawing.Point(109, 4);
		this.textEdit1.Name = "textEdit1";
		this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.textEdit1.Properties.Appearance.Options.UseFont = true;
		this.textEdit1.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.textEdit1.Properties.MaskSettings.Set("mask", "##,###,###,###");
		this.textEdit1.Properties.UseMaskAsDisplayFormat = true;
		this.textEdit1.Size = new System.Drawing.Size(194, 24);
		this.textEdit1.StyleController = this.layoutControl1;
		this.textEdit1.TabIndex = 4;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
		conditionValidationRule2.ErrorText = "This value must be greater than Zero (0)";
		conditionValidationRule2.Value1 = 0.0;
		this.dxValidationProvider1.SetValidationRule(this.textEdit1, conditionValidationRule2);
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem1, this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(307, 150);
		this.Root.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.textEdit1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(303, 28);
		this.layoutControlItem1.Text = "Waiver Amount";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(101, 18);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 109);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(303, 10);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.Control = this.simpleButton1;
		this.layoutControlItem2.Location = new System.Drawing.Point(144, 119);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(159, 27);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton2;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 119);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(144, 27);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtNarration;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(303, 81);
		this.layoutControlItem4.Text = "Narration";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(101, 18);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(307, 150);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AwardWaiver";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Award Waiver";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.textEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
