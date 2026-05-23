using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class ParentInfo : XtraForm
{
	public string FName = string.Empty;

	public string FContact = string.Empty;

	public string FAddress = string.Empty;

	public string FEmail = string.Empty;

	public string MName = string.Empty;

	public string MContact = string.Empty;

	public string MAddress = string.Empty;

	public string MEmail = string.Empty;

	public string M_NIN = string.Empty;

	public string F_NIN = string.Empty;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LabelControl labelControl3;

	private TextEdit txtmEmail;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private TextEdit txtmContact;

	private TextEdit txtmAddress;

	private TextEdit txtmName;

	private TextEdit txtfEmail;

	private TextEdit txtfContact;

	private TextEdit txtfAddress;

	private TextEdit txtfName;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem12;

	private LayoutControlItem layoutControlItem13;

	private EmptySpaceItem emptySpaceItem1;

	private TextEdit txtMotherNIN;

	private TextEdit txtFatherNIN;

	private LayoutControlItem layoutControlItem14;

	private LayoutControlItem layoutControlItem15;

	public ParentInfo(string F_Name, string F_Contact, string F_Address, string F_Email, string M_Name, string M_Contact, string M_Address, string M_Email, string F_Nin, string M_Nin)
	{
		InitializeComponent();
		FName = F_Name;
		FContact = F_Contact;
		FAddress = F_Address;
		FEmail = F_Email;
		MName = M_Name;
		MContact = M_Contact;
		MAddress = M_Address;
		MEmail = M_Email;
		F_NIN = F_Nin;
		M_NIN = M_Nin;
	}

	private void ParentInfo_Load(object sender, EventArgs e)
	{
		txtfName.Text = FName;
		txtfAddress.Text = FAddress;
		txtfEmail.Text = FEmail;
		txtfContact.Text = FContact;
		txtmName.Text = MName;
		txtmAddress.Text = MAddress;
		txtmEmail.Text = MEmail;
		txtmContact.Text = MContact;
		txtFatherNIN.Text = F_NIN;
		txtMotherNIN.Text = M_NIN;
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		FName = txtfName.Text;
		FAddress = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtfAddress.Text.ToUpper());
		FEmail = txtfEmail.Text;
		FContact = txtfContact.Text;
		MName = txtmName.Text;
		MAddress = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtmAddress.Text.ToUpper());
		MEmail = txtmEmail.Text;
		MContact = txtmContact.Text;
		M_NIN = txtMotherNIN.Text.ToUpper();
		F_NIN = txtFatherNIN.Text.ToUpper();
		base.DialogResult = DialogResult.OK;
		Close();
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
		this.txtMotherNIN = new DevExpress.XtraEditors.TextEdit();
		this.txtFatherNIN = new DevExpress.XtraEditors.TextEdit();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.txtmEmail = new DevExpress.XtraEditors.TextEdit();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtmContact = new DevExpress.XtraEditors.TextEdit();
		this.txtmAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtmName = new DevExpress.XtraEditors.TextEdit();
		this.txtfEmail = new DevExpress.XtraEditors.TextEdit();
		this.txtfContact = new DevExpress.XtraEditors.TextEdit();
		this.txtfAddress = new DevExpress.XtraEditors.TextEdit();
		this.txtfName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtMotherNIN.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtFatherNIN.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtmEmail.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtmContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtmAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtmName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtfEmail.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtfContact.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtfAddress.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtfName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txtMotherNIN);
		this.layoutControl1.Controls.Add(this.txtFatherNIN);
		this.layoutControl1.Controls.Add(this.labelControl3);
		this.layoutControl1.Controls.Add(this.txtmEmail);
		this.layoutControl1.Controls.Add(this.labelControl2);
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtmContact);
		this.layoutControl1.Controls.Add(this.txtmAddress);
		this.layoutControl1.Controls.Add(this.txtmName);
		this.layoutControl1.Controls.Add(this.txtfEmail);
		this.layoutControl1.Controls.Add(this.txtfContact);
		this.layoutControl1.Controls.Add(this.txtfAddress);
		this.layoutControl1.Controls.Add(this.txtfName);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(388, 376);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.txtMotherNIN.Location = new System.Drawing.Point(73, 284);
		this.txtMotherNIN.Name = "txtMotherNIN";
		this.txtMotherNIN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtMotherNIN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtMotherNIN.Properties.MaxLength = 14;
		this.txtMotherNIN.Size = new System.Drawing.Size(311, 22);
		this.txtMotherNIN.StyleController = this.layoutControl1;
		this.txtMotherNIN.TabIndex = 18;
		this.txtFatherNIN.Location = new System.Drawing.Point(73, 131);
		this.txtFatherNIN.Name = "txtFatherNIN";
		this.txtFatherNIN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtFatherNIN.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtFatherNIN.Properties.MaxLength = 14;
		this.txtFatherNIN.Size = new System.Drawing.Size(311, 22);
		this.txtFatherNIN.StyleController = this.layoutControl1;
		this.txtFatherNIN.TabIndex = 17;
		this.labelControl3.Location = new System.Drawing.Point(4, 310);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(380, 13);
		this.labelControl3.StyleController = this.layoutControl1;
		this.labelControl3.TabIndex = 16;
		this.txtmEmail.Location = new System.Drawing.Point(76, 258);
		this.txtmEmail.Name = "txtmEmail";
		this.txtmEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtmEmail.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
		this.txtmEmail.Properties.MaxLength = 50;
		this.txtmEmail.Size = new System.Drawing.Size(308, 22);
		this.txtmEmail.StyleController = this.layoutControl1;
		this.txtmEmail.TabIndex = 15;
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Location = new System.Drawing.Point(4, 157);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(380, 19);
		this.labelControl2.StyleController = this.layoutControl1;
		this.labelControl2.TabIndex = 14;
		this.labelControl2.Text = "Mother";
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(380, 19);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 13;
		this.labelControl1.Text = "Father";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton2.Location = new System.Drawing.Point(195, 349);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(189, 23);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 12;
		this.simpleButton2.Text = "Cancel";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(4, 349);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(187, 23);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 11;
		this.simpleButton1.Text = "Continue";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtmContact.Location = new System.Drawing.Point(76, 232);
		this.txtmContact.Name = "txtmContact";
		this.txtmContact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtmContact.Properties.MaxLength = 10;
		this.txtmContact.Size = new System.Drawing.Size(308, 22);
		this.txtmContact.StyleController = this.layoutControl1;
		this.txtmContact.TabIndex = 10;
		this.txtmAddress.Location = new System.Drawing.Point(76, 206);
		this.txtmAddress.Name = "txtmAddress";
		this.txtmAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtmAddress.Properties.MaxLength = 50;
		this.txtmAddress.Size = new System.Drawing.Size(308, 22);
		this.txtmAddress.StyleController = this.layoutControl1;
		this.txtmAddress.TabIndex = 9;
		this.txtmName.Location = new System.Drawing.Point(76, 180);
		this.txtmName.Name = "txtmName";
		this.txtmName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtmName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtmName.Properties.MaxLength = 50;
		this.txtmName.Size = new System.Drawing.Size(308, 22);
		this.txtmName.StyleController = this.layoutControl1;
		this.txtmName.TabIndex = 8;
		this.txtfEmail.Location = new System.Drawing.Point(76, 105);
		this.txtfEmail.Name = "txtfEmail";
		this.txtfEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtfEmail.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
		this.txtfEmail.Properties.MaxLength = 50;
		this.txtfEmail.Size = new System.Drawing.Size(308, 22);
		this.txtfEmail.StyleController = this.layoutControl1;
		this.txtfEmail.TabIndex = 7;
		this.txtfContact.Location = new System.Drawing.Point(76, 79);
		this.txtfContact.Name = "txtfContact";
		this.txtfContact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtfContact.Properties.MaxLength = 10;
		this.txtfContact.Size = new System.Drawing.Size(308, 22);
		this.txtfContact.StyleController = this.layoutControl1;
		this.txtfContact.TabIndex = 6;
		this.txtfAddress.Location = new System.Drawing.Point(76, 53);
		this.txtfAddress.Name = "txtfAddress";
		this.txtfAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtfAddress.Properties.MaxLength = 50;
		this.txtfAddress.Size = new System.Drawing.Size(308, 22);
		this.txtfAddress.StyleController = this.layoutControl1;
		this.txtfAddress.TabIndex = 5;
		this.txtfName.Location = new System.Drawing.Point(76, 27);
		this.txtfName.Name = "txtfName";
		this.txtfName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtfName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtfName.Properties.MaxLength = 50;
		this.txtfName.Size = new System.Drawing.Size(308, 22);
		this.txtfName.StyleController = this.layoutControl1;
		this.txtfName.TabIndex = 4;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[16]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem4, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10,
			this.layoutControlItem11, this.layoutControlItem12, this.layoutControlItem13, this.emptySpaceItem1, this.layoutControlItem14, this.layoutControlItem15
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(388, 376);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.txtfName;
		this.layoutControlItem1.CustomizationFormText = "Name:";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem1.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem1.Text = "Name:";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtfAddress;
		this.layoutControlItem2.CustomizationFormText = "Address:";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 49);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem2.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem2.Text = "Address:";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtfContact;
		this.layoutControlItem3.CustomizationFormText = "Contact#:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 75);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem3.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem3.Text = "Contact#:";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtfEmail;
		this.layoutControlItem4.CustomizationFormText = "Email:";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 101);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem4.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem4.Text = "Email:";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.txtmName;
		this.layoutControlItem5.CustomizationFormText = "Name:";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 176);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem5.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem5.Text = "Name:";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.txtmAddress;
		this.layoutControlItem6.CustomizationFormText = "Address:";
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 202);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem6.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem6.Text = "Address:";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtmContact;
		this.layoutControlItem7.CustomizationFormText = "Contact#:";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 228);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem7.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem7.Text = "Contact#:";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem8.Control = this.simpleButton1;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 345);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(191, 27);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.simpleButton2;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(191, 345);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(193, 27);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem10.Control = this.labelControl1;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(384, 23);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.Control = this.labelControl2;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 153);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(384, 23);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem12.Control = this.txtmEmail;
		this.layoutControlItem12.CustomizationFormText = "Email:";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 254);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem12.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem12.Text = "Email:";
		this.layoutControlItem12.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem13.Control = this.labelControl3;
		this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 306);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(384, 17);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 323);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(384, 22);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem14.Control = this.txtFatherNIN;
		this.layoutControlItem14.Location = new System.Drawing.Point(0, 127);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem14.Text = "NIN:";
		this.layoutControlItem14.TextSize = new System.Drawing.Size(57, 16);
		this.layoutControlItem15.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem15.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem15.Control = this.txtMotherNIN;
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 280);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(384, 26);
		this.layoutControlItem15.Text = "NIN:";
		this.layoutControlItem15.TextSize = new System.Drawing.Size(57, 16);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(388, 376);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "ParentInfo";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Parent Information";
		base.Load += new System.EventHandler(ParentInfo_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtMotherNIN.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtFatherNIN.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtmEmail.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtmContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtmAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtmName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtfEmail.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtfContact.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtfAddress.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtfName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		base.ResumeLayout(false);
	}
}
