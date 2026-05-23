using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;

namespace I_Xtreme.DialogForms;

public class ConfirmVoucherClose : XtraForm
{
	private IContainer components = null;

	private SimpleButton simpleButton1;

	private SimpleButton simpleButton2;

	private LabelControl labelControl1;

	private LabelControl labelControl2;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private DXValidationProvider dxValidationProvider1;

	private LayoutControlItem layoutControlItem6;

	public MemoEdit txtNarration;

	public TextEdit txtContact;

	public TextEdit txtAddress;

	public TextEdit txtPayee;

	public ConfirmVoucherClose()
	{
		InitializeComponent();
		simpleButton1.Focus();
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		while (dxValidationProvider1.Validate())
		{
			if (dxValidationProvider1.GetInvalidControls().Count == 0)
			{
				base.DialogResult = DialogResult.Yes;
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
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtNarration = new DevExpress.XtraEditors.MemoEdit();
		this.txtContact = new DevExpress.XtraEditors.TextEdit();
		this.txtAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtPayee = new DevExpress.XtraEditors.TextEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayee.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton1.Location = new System.Drawing.Point(12, 208);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(179, 23);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "&Yes";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControl1.Controls.Add(this.txtNarration);
		this.layoutControl1.Controls.Add(this.txtContact);
		this.layoutControl1.Controls.Add(this.txtAddress);
		this.layoutControl1.Controls.Add(this.txtPayee);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 46);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(387, 243);
		this.layoutControl1.TabIndex = 5;
		this.layoutControl1.Text = "layoutControl1";
		this.txtNarration.Location = new System.Drawing.Point(12, 109);
		this.txtNarration.Name = "txtNarration";
		this.txtNarration.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtNarration.Properties.Appearance.Options.UseFont = true;
		this.txtNarration.Properties.MaxLength = 500;
		this.txtNarration.Size = new System.Drawing.Size(363, 95);
		this.txtNarration.StyleController = this.layoutControl1;
		this.txtNarration.TabIndex = 7;
		this.txtContact.Location = new System.Drawing.Point(79, 64);
		this.txtContact.Name = "txtContact";
		this.txtContact.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtContact.Properties.Appearance.Options.UseFont = true;
		this.txtContact.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegularMaskManager));
		this.txtContact.Properties.MaskSettings.Set("mask", "\\d\\d\\d\\d\\d\\d\\d\\d\\d\\d");
		this.txtContact.Properties.MaxLength = 10;
		this.txtContact.Size = new System.Drawing.Size(296, 22);
		this.txtContact.StyleController = this.layoutControl1;
		this.txtContact.TabIndex = 6;
		this.txtAddress.Location = new System.Drawing.Point(79, 38);
		this.txtAddress.Name = "txtAddress";
		this.txtAddress.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtAddress.Properties.Appearance.Options.UseFont = true;
		this.txtAddress.Size = new System.Drawing.Size(296, 22);
		this.txtAddress.StyleController = this.layoutControl1;
		this.txtAddress.TabIndex = 5;
		this.dxValidationProvider1.SetIconAlignment(this.txtPayee, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtPayee.Location = new System.Drawing.Point(79, 12);
		this.txtPayee.Name = "txtPayee";
		this.txtPayee.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtPayee.Properties.Appearance.Options.UseFont = true;
		this.txtPayee.Size = new System.Drawing.Size(296, 22);
		this.txtPayee.StyleController = this.layoutControl1;
		this.txtPayee.TabIndex = 4;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationProvider1.SetValidationRule(this.txtPayee, conditionValidationRule);
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.No;
		this.simpleButton2.Location = new System.Drawing.Point(195, 208);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(180, 23);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "&No";
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6 });
		this.Root.Name = "Root";
		this.Root.Size = new System.Drawing.Size(387, 243);
		this.Root.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.txtPayee;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(367, 26);
		this.layoutControlItem1.Text = "Payee";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 16);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtAddress;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(367, 26);
		this.layoutControlItem2.Text = "Address";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 16);
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 196);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(183, 27);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.Location = new System.Drawing.Point(183, 196);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(184, 27);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.txtContact;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(367, 26);
		this.layoutControlItem5.Text = "Contact #";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(55, 16);
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.txtNarration;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 78);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(367, 118);
		this.layoutControlItem6.Text = "Narration";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(55, 16);
		this.labelControl1.Appearance.BackColor = System.Drawing.Color.MintCream;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Appearance.Options.UseBackColor = true;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
		this.labelControl1.Location = new System.Drawing.Point(0, 0);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(0);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(387, 46);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Do you really want to close this voucher?\r\nNote that you will not be able to edit it afterwards.\r\n\r\n";
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Location = new System.Drawing.Point(12, 51);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(363, 15);
		this.labelControl2.TabIndex = 4;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(387, 289);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.labelControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ConfirmVoucherClose";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Confirm";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtNarration.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPayee.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
