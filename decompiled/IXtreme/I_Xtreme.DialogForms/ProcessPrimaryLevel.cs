using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Semesters;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;
using Microsoft.Win32;

namespace I_Xtreme.DialogForms;

public class ProcessPrimaryLevel : XtraForm
{
	private IContainer components = null;

	private LayoutControl layoutControl12;

	private SimpleButton simpleButton13;

	private TextEdit txtODebutRepeat;

	private TextEdit txtOEndProbation;

	private TextEdit txtODebutProbation;

	private TextEdit txtODebutPromotion;

	private SimpleButton btnProcessOLevelReports;

	private CheckEdit chkMandatory;

	private CheckEdit chkF9InMathematics;

	private CheckEdit chkF9English;

	private CheckEdit chkP7nP8InEnglish;

	private LayoutControlGroup layoutControlGroup16;

	private LayoutControlItem layoutControlItem102;

	private LayoutControlGroup layoutControlGroup18;

	private LayoutControlItem layoutControlItem103;

	private LayoutControlItem layoutControlItem104;

	private LayoutControlItem layoutControlItem105;

	private LayoutControlItem layoutControlItem106;

	private LayoutControlItem layoutControlItem108;

	private LayoutControlGroup layoutControlGroup19;

	private LayoutControlItem layoutControlItem130;

	private LayoutControlItem layoutControlItem114;

	private LayoutControlItem layoutControlItem99;

	private LayoutControlItem layoutControlItem133;

	private DXValidationProvider dxValidationProvider1;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem1;

	private LabelControl lblSemester;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem4;

	private ComboBoxEdit cboClassProcess;

	public ProcessPrimaryLevel()
	{
		InitializeComponent();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClassProcess });
		Text = "Process Report Cards - " + WorkingSemesters.GetWorkingSemester();
		lblSemester.Text = WorkingSemesters.GetWorkingSemester();
		if (WorkingSemesters.GetWorkingSemester().Contains("TermIII"))
		{
			layoutControlGroup18.Visibility = LayoutVisibility.Always;
			layoutControlGroup18.Expanded = true;
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\O Level Cutoff");
			txtODebutPromotion.Text = registryKey.GetValue("Promoted").ToString();
			txtODebutProbation.Text = registryKey.GetValue("ProbationDebut").ToString();
			base.Height = 476;
		}
		else
		{
			layoutControlGroup18.Visibility = LayoutVisibility.Never;
			layoutControlGroup18.Expanded = false;
			base.Height = 310;
		}
	}

	private void btnProcessOLevelReports_Click(object sender, EventArgs e)
	{
		ProcessPrimaryReports.InitializePrimaryProcessing(SemesterSettings.NextTermBeginsOn(WorkingSemesters.GetWorkingSemester(), cboClassProcess.SelectedItem.ToString()), cboClassProcess.SelectedItem.ToString(), WorkingSemesters.GetWorkingSemester(), Convert.ToBoolean(chkF9English.EditValue), Convert.ToBoolean(chkP7nP8InEnglish.EditValue), Convert.ToBoolean(chkF9InMathematics.EditValue), Convert.ToBoolean(chkMandatory.EditValue));
		using ProcessProgressPrimary processProgressPrimary = new ProcessProgressPrimary();
		processProgressPrimary.ShowDialog();
	}

	private void simpleButton13_Click(object sender, EventArgs e)
	{
		if (txtODebutPromotion.Text != string.Empty || txtODebutProbation.Text != string.Empty)
		{
			if (Convert.ToInt32(txtODebutPromotion.Text) > Convert.ToInt32(txtODebutProbation.Text))
			{
				try
				{
					double result = (double.TryParse(txtODebutPromotion.Text, out result) ? result : 0.0);
					double result2 = (double.TryParse(txtODebutProbation.Text, out result2) ? result2 : 0.0);
					RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\O Level Cutoff");
					registryKey.SetValue("Promoted", result);
					registryKey.SetValue("ProbationDebut", result2);
					XtraMessageBox.Show("Settings saved successfully", "School Management Dynamics");
					return;
				}
				catch (Exception ex)
				{
					XtraMessageBox.Show(ex.Message, "School Management Dynamics");
					return;
				}
			}
			XtraMessageBox.Show("Probation Start Mark cannot be greater than Promotion Cutoff-Mark", "Invalid inputs");
		}
		else
		{
			XtraMessageBox.Show("Please enter valid values in all fields", "School Management Dynamics");
		}
	}

	private void txtODebutPromotion_TextChanged(object sender, EventArgs e)
	{
		txtOEndProbation.Text = txtODebutPromotion.Text;
	}

	private void txtODebutProbation_TextChanged(object sender, EventArgs e)
	{
		txtODebutRepeat.Text = txtODebutProbation.Text;
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
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
		this.layoutControl12 = new DevExpress.XtraLayout.LayoutControl();
		this.lblSemester = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton13 = new DevExpress.XtraEditors.SimpleButton();
		this.txtODebutRepeat = new DevExpress.XtraEditors.TextEdit();
		this.txtOEndProbation = new DevExpress.XtraEditors.TextEdit();
		this.txtODebutProbation = new DevExpress.XtraEditors.TextEdit();
		this.txtODebutPromotion = new DevExpress.XtraEditors.TextEdit();
		this.btnProcessOLevelReports = new DevExpress.XtraEditors.SimpleButton();
		this.chkMandatory = new DevExpress.XtraEditors.CheckEdit();
		this.chkF9InMathematics = new DevExpress.XtraEditors.CheckEdit();
		this.chkF9English = new DevExpress.XtraEditors.CheckEdit();
		this.chkP7nP8InEnglish = new DevExpress.XtraEditors.CheckEdit();
		this.cboClassProcess = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup16 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem102 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup18 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem103 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem104 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem105 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem106 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem108 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup19 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem130 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem114 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem99 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem133 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
		((System.ComponentModel.ISupportInitialize)this.layoutControl12).BeginInit();
		this.layoutControl12.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtODebutRepeat.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtOEndProbation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtODebutProbation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtODebutPromotion.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkMandatory.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9InMathematics.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9English.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkP7nP8InEnglish.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassProcess.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem102).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem103).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem104).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem105).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem106).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem108).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem130).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem114).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem99).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem133).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).BeginInit();
		base.SuspendLayout();
		this.layoutControl12.Controls.Add(this.lblSemester);
		this.layoutControl12.Controls.Add(this.labelControl1);
		this.layoutControl12.Controls.Add(this.simpleButton1);
		this.layoutControl12.Controls.Add(this.simpleButton13);
		this.layoutControl12.Controls.Add(this.txtODebutRepeat);
		this.layoutControl12.Controls.Add(this.txtOEndProbation);
		this.layoutControl12.Controls.Add(this.txtODebutProbation);
		this.layoutControl12.Controls.Add(this.txtODebutPromotion);
		this.layoutControl12.Controls.Add(this.btnProcessOLevelReports);
		this.layoutControl12.Controls.Add(this.chkMandatory);
		this.layoutControl12.Controls.Add(this.chkF9InMathematics);
		this.layoutControl12.Controls.Add(this.chkF9English);
		this.layoutControl12.Controls.Add(this.chkP7nP8InEnglish);
		this.layoutControl12.Controls.Add(this.cboClassProcess);
		this.layoutControl12.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl12.Location = new System.Drawing.Point(0, 0);
		this.layoutControl12.Name = "layoutControl12";
		this.layoutControl12.Root = this.layoutControlGroup16;
		this.layoutControl12.Size = new System.Drawing.Size(375, 429);
		this.layoutControl12.TabIndex = 4;
		this.layoutControl12.Text = "layoutControl12";
		this.lblSemester.Location = new System.Drawing.Point(308, 4);
		this.lblSemester.Name = "lblSemester";
		this.lblSemester.Size = new System.Drawing.Size(63, 13);
		this.lblSemester.StyleController = this.layoutControl12;
		this.lblSemester.TabIndex = 28;
		this.lblSemester.Text = "labelControl2";
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Visible = true;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(300, 13);
		this.labelControl1.StyleController = this.layoutControl12;
		this.labelControl1.TabIndex = 27;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(189, 402);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(182, 23);
		this.simpleButton1.StyleController = this.layoutControl12;
		this.simpleButton1.TabIndex = 26;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton13.Location = new System.Drawing.Point(9, 205);
		this.simpleButton13.Name = "simpleButton13";
		this.simpleButton13.Size = new System.Drawing.Size(357, 22);
		this.simpleButton13.StyleController = this.layoutControl12;
		this.simpleButton13.TabIndex = 25;
		this.simpleButton13.Text = "Save Cutoffs";
		this.simpleButton13.Click += new System.EventHandler(simpleButton13_Click);
		this.txtODebutRepeat.Location = new System.Drawing.Point(244, 177);
		this.txtODebutRepeat.Name = "txtODebutRepeat";
		this.txtODebutRepeat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtODebutRepeat.Properties.Appearance.Options.UseFont = true;
		this.txtODebutRepeat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtODebutRepeat.Properties.ReadOnly = true;
		this.txtODebutRepeat.Size = new System.Drawing.Size(122, 24);
		this.txtODebutRepeat.StyleController = this.layoutControl12;
		this.txtODebutRepeat.TabIndex = 23;
		this.txtOEndProbation.Location = new System.Drawing.Point(244, 149);
		this.txtOEndProbation.Name = "txtOEndProbation";
		this.txtOEndProbation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOEndProbation.Properties.Appearance.Options.UseFont = true;
		this.txtOEndProbation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOEndProbation.Properties.ReadOnly = true;
		this.txtOEndProbation.Size = new System.Drawing.Size(122, 24);
		this.txtOEndProbation.StyleController = this.layoutControl12;
		this.txtOEndProbation.TabIndex = 22;
		this.txtODebutProbation.Location = new System.Drawing.Point(244, 121);
		this.txtODebutProbation.Name = "txtODebutProbation";
		this.txtODebutProbation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtODebutProbation.Properties.Appearance.Options.UseFont = true;
		this.txtODebutProbation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtODebutProbation.Size = new System.Drawing.Size(122, 24);
		this.txtODebutProbation.StyleController = this.layoutControl12;
		this.txtODebutProbation.TabIndex = 21;
		this.txtODebutProbation.TextChanged += new System.EventHandler(txtODebutProbation_TextChanged);
		this.txtODebutPromotion.Location = new System.Drawing.Point(244, 93);
		this.txtODebutPromotion.Name = "txtODebutPromotion";
		this.txtODebutPromotion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtODebutPromotion.Properties.Appearance.Options.UseFont = true;
		this.txtODebutPromotion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtODebutPromotion.Size = new System.Drawing.Size(122, 24);
		this.txtODebutPromotion.StyleController = this.layoutControl12;
		this.txtODebutPromotion.TabIndex = 20;
		this.txtODebutPromotion.TextChanged += new System.EventHandler(txtODebutPromotion_TextChanged);
		this.btnProcessOLevelReports.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnProcessOLevelReports.Appearance.Options.UseFont = true;
		this.btnProcessOLevelReports.Location = new System.Drawing.Point(4, 402);
		this.btnProcessOLevelReports.Name = "btnProcessOLevelReports";
		this.btnProcessOLevelReports.Size = new System.Drawing.Size(181, 23);
		this.btnProcessOLevelReports.StyleController = this.layoutControl12;
		this.btnProcessOLevelReports.TabIndex = 0;
		this.btnProcessOLevelReports.Text = "Process";
		this.btnProcessOLevelReports.Click += new System.EventHandler(btnProcessOLevelReports_Click);
		this.chkMandatory.Location = new System.Drawing.Point(9, 332);
		this.chkMandatory.Name = "chkMandatory";
		this.chkMandatory.Properties.Caption = "Assign Grade U for fewer than mandatory number of sujects";
		this.chkMandatory.Size = new System.Drawing.Size(357, 19);
		this.chkMandatory.StyleController = this.layoutControl12;
		this.chkMandatory.TabIndex = 10;
		this.chkF9InMathematics.Location = new System.Drawing.Point(9, 309);
		this.chkF9InMathematics.Name = "chkF9InMathematics";
		this.chkF9InMathematics.Properties.Caption = "Automatically send to division 2 for F9 in Mathematics";
		this.chkF9InMathematics.Size = new System.Drawing.Size(357, 19);
		this.chkF9InMathematics.StyleController = this.layoutControl12;
		this.chkF9InMathematics.TabIndex = 9;
		this.chkF9English.Location = new System.Drawing.Point(9, 263);
		this.chkF9English.Name = "chkF9English";
		this.chkF9English.Properties.Caption = "Automatically send to division 3 for F9 in English";
		this.chkF9English.Size = new System.Drawing.Size(357, 19);
		this.chkF9English.StyleController = this.layoutControl12;
		this.chkF9English.TabIndex = 7;
		this.chkP7nP8InEnglish.Location = new System.Drawing.Point(9, 286);
		this.chkP7nP8InEnglish.Name = "chkP7nP8InEnglish";
		this.chkP7nP8InEnglish.Properties.Caption = "Automatically send to division 2 for P7 or P8 in English";
		this.chkP7nP8InEnglish.Size = new System.Drawing.Size(357, 19);
		this.chkP7nP8InEnglish.StyleController = this.layoutControl12;
		this.chkP7nP8InEnglish.TabIndex = 8;
		this.cboClassProcess.Location = new System.Drawing.Point(4, 40);
		this.cboClassProcess.Name = "cboClassProcess";
		this.cboClassProcess.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboClassProcess.Properties.Appearance.Options.UseFont = true;
		this.cboClassProcess.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboClassProcess.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboClassProcess.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClassProcess.Properties.NullText = "[EditValue is null]";
		this.cboClassProcess.Properties.PopupSizeable = true;
		this.cboClassProcess.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClassProcess.Size = new System.Drawing.Size(367, 22);
		this.cboClassProcess.StyleController = this.layoutControl12;
		this.cboClassProcess.TabIndex = 29;
		this.layoutControlGroup16.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup16.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup16.GroupBordersVisible = false;
		this.layoutControlGroup16.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem102, this.layoutControlGroup18, this.layoutControlGroup19, this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3, this.emptySpaceItem1, this.layoutControlItem4 });
		this.layoutControlGroup16.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup16.Name = "layoutControlGroup1";
		this.layoutControlGroup16.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup16.Size = new System.Drawing.Size(375, 429);
		this.layoutControlGroup16.Text = "layoutControlGroup1";
		this.layoutControlGroup16.TextVisible = false;
		this.layoutControlItem102.Control = this.btnProcessOLevelReports;
		this.layoutControlItem102.CustomizationFormText = "layoutControlItem102";
		this.layoutControlItem102.Location = new System.Drawing.Point(0, 398);
		this.layoutControlItem102.Name = "layoutControlItem102";
		this.layoutControlItem102.Size = new System.Drawing.Size(185, 27);
		this.layoutControlItem102.Text = "layoutControlItem102";
		this.layoutControlItem102.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem102.TextToControlDistance = 0;
		this.layoutControlItem102.TextVisible = false;
		this.layoutControlGroup18.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlGroup18.AppearanceGroup.Options.UseFont = true;
		this.layoutControlGroup18.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlGroup18.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlGroup18.CustomizationFormText = "Student Cutoffs";
		this.layoutControlGroup18.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem103, this.layoutControlItem104, this.layoutControlItem105, this.layoutControlItem106, this.layoutControlItem108 });
		this.layoutControlGroup18.Location = new System.Drawing.Point(0, 62);
		this.layoutControlGroup18.Name = "layoutControlGroup18";
		this.layoutControlGroup18.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup18.Size = new System.Drawing.Size(371, 170);
		this.layoutControlGroup18.Text = "Student Cutoffs";
		this.layoutControlItem103.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem103.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem103.Control = this.txtODebutPromotion;
		this.layoutControlItem103.CustomizationFormText = "Promote students for Average Mark >";
		this.layoutControlItem103.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem103.Name = "layoutControlItem103";
		this.layoutControlItem103.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem103.Text = "Promote students for Average Mark >";
		this.layoutControlItem103.TextSize = new System.Drawing.Size(232, 16);
		this.layoutControlItem104.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem104.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem104.Control = this.txtODebutProbation;
		this.layoutControlItem104.CustomizationFormText = "Promote on Probation for Average Mark:";
		this.layoutControlItem104.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem104.Name = "layoutControlItem104";
		this.layoutControlItem104.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem104.Text = "Promote on Probation for Average Mark:";
		this.layoutControlItem104.TextSize = new System.Drawing.Size(232, 16);
		this.layoutControlItem105.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem105.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem105.Control = this.txtOEndProbation;
		this.layoutControlItem105.CustomizationFormText = "To:";
		this.layoutControlItem105.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem105.Name = "layoutControlItem105";
		this.layoutControlItem105.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem105.Text = "To:";
		this.layoutControlItem105.TextSize = new System.Drawing.Size(232, 16);
		this.layoutControlItem106.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem106.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem106.Control = this.txtODebutRepeat;
		this.layoutControlItem106.CustomizationFormText = "Repeat class for Average Mark <";
		this.layoutControlItem106.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem106.Name = "layoutControlItem106";
		this.layoutControlItem106.Size = new System.Drawing.Size(361, 28);
		this.layoutControlItem106.Text = "Repeat class for Average Mark <";
		this.layoutControlItem106.TextSize = new System.Drawing.Size(232, 16);
		this.layoutControlItem108.Control = this.simpleButton13;
		this.layoutControlItem108.CustomizationFormText = "layoutControlItem108";
		this.layoutControlItem108.Location = new System.Drawing.Point(0, 112);
		this.layoutControlItem108.Name = "layoutControlItem108";
		this.layoutControlItem108.Size = new System.Drawing.Size(361, 26);
		this.layoutControlItem108.Text = "layoutControlItem108";
		this.layoutControlItem108.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem108.TextToControlDistance = 0;
		this.layoutControlItem108.TextVisible = false;
		this.layoutControlGroup19.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlGroup19.AppearanceGroup.Options.UseFont = true;
		this.layoutControlGroup19.CustomizationFormText = "Advanced Student Grading";
		this.layoutControlGroup19.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem130, this.layoutControlItem114, this.layoutControlItem99, this.layoutControlItem133 });
		this.layoutControlGroup19.Location = new System.Drawing.Point(0, 232);
		this.layoutControlGroup19.Name = "layoutControlGroup19";
		this.layoutControlGroup19.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup19.Size = new System.Drawing.Size(371, 124);
		this.layoutControlGroup19.Text = "Advanced Student Grading";
		this.layoutControlItem130.Control = this.chkF9InMathematics;
		this.layoutControlItem130.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem130.Location = new System.Drawing.Point(0, 46);
		this.layoutControlItem130.Name = "layoutControlItem6";
		this.layoutControlItem130.Size = new System.Drawing.Size(361, 23);
		this.layoutControlItem130.Text = "layoutControlItem6";
		this.layoutControlItem130.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem130.TextToControlDistance = 0;
		this.layoutControlItem130.TextVisible = false;
		this.layoutControlItem114.Control = this.chkP7nP8InEnglish;
		this.layoutControlItem114.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem114.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem114.Name = "layoutControlItem5";
		this.layoutControlItem114.Size = new System.Drawing.Size(361, 23);
		this.layoutControlItem114.Text = "layoutControlItem5";
		this.layoutControlItem114.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem114.TextToControlDistance = 0;
		this.layoutControlItem114.TextVisible = false;
		this.layoutControlItem99.Control = this.chkF9English;
		this.layoutControlItem99.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem99.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem99.Name = "layoutControlItem4";
		this.layoutControlItem99.Size = new System.Drawing.Size(361, 23);
		this.layoutControlItem99.Text = "layoutControlItem4";
		this.layoutControlItem99.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem99.TextToControlDistance = 0;
		this.layoutControlItem99.TextVisible = false;
		this.layoutControlItem133.Control = this.chkMandatory;
		this.layoutControlItem133.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem133.Location = new System.Drawing.Point(0, 69);
		this.layoutControlItem133.Name = "layoutControlItem7";
		this.layoutControlItem133.Size = new System.Drawing.Size(361, 23);
		this.layoutControlItem133.Text = "layoutControlItem7";
		this.layoutControlItem133.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem133.TextToControlDistance = 0;
		this.layoutControlItem133.TextVisible = false;
		this.layoutControlItem1.Control = this.simpleButton1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(185, 398);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(186, 27);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.labelControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(304, 17);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.lblSemester;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(304, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(67, 17);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 356);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(371, 42);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.cboClassProcess;
		this.layoutControlItem4.CustomizationFormText = "Class:";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 17);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(371, 45);
		this.layoutControlItem4.Text = "Class:";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(232, 16);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(375, 429);
		base.Controls.Add(this.layoutControl12);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "ProcessPrimaryLevel";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Process Report Cards";
		((System.ComponentModel.ISupportInitialize)this.layoutControl12).EndInit();
		this.layoutControl12.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtODebutRepeat.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtOEndProbation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtODebutProbation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtODebutPromotion.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkMandatory.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9InMathematics.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkF9English.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkP7nP8InEnglish.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClassProcess.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem102).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem103).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem104).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem105).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem106).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem108).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem130).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem114).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem99).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem133).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationProvider1).EndInit();
		base.ResumeLayout(false);
	}
}
