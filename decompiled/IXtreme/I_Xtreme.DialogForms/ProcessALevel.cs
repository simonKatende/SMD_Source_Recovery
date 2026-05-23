using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Semesters;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;
using Microsoft.Win32;

namespace I_Xtreme.DialogForms;

public class ProcessALevel : XtraForm
{
	private bool formLoaded = false;

	private IContainer components = null;

	private LayoutControl layoutControl13;

	private SimpleButton simpleButton12;

	private SimpleButton simpleButton11;

	private TextEdit txtPromoted;

	private TextEdit txtEndProbation;

	private TextEdit txtDebutProbation;

	private TextEdit txtRepeat;

	private ComboBoxEdit cboALevelClass;

	private LayoutControlGroup layoutControlGroup17;

	private LayoutControlItem layoutControlItem140;

	private LayoutControlGroup layoutControlGroup12;

	private LayoutControlItem layoutControlItem88;

	private LayoutControlItem layoutControlItem89;

	private LayoutControlItem layoutControlItem90;

	private LayoutControlItem layoutControlItem91;

	private LayoutControlItem layoutControlItem100;

	private LayoutControlItem layoutControlItem101;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem1;

	private ComboBoxEdit cboTerm;

	private LayoutControlItem layoutControlItem2;

	private ComboBoxEdit cboStream;

	private LayoutControlItem layoutControlItem3;

	private EmptySpaceItem emptySpaceItem1;

	public ProcessALevel()
	{
		InitializeComponent();
		WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { cboTerm });
		cboTerm.SelectedItem = WorkingSemesters.GetWorkingSemester();
		if (cboTerm.SelectedItem.ToString().Contains("TermIII"))
		{
			layoutControlGroup12.Visibility = LayoutVisibility.Always;
			layoutControlGroup12.Expanded = true;
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\A Level Cutoff");
			txtRepeat.Text = registryKey.GetValue("Repeat").ToString();
			txtEndProbation.Text = registryKey.GetValue("ProbationEnd").ToString();
			base.Height = 346;
		}
		else
		{
			layoutControlGroup12.Expanded = false;
			layoutControlGroup12.Visibility = LayoutVisibility.Never;
			base.Height = 195;
		}
	}

	private void simpleButton11_Click(object sender, EventArgs e)
	{
		SaveALevelCutoff();
	}

	private void SaveALevelCutoff()
	{
		if (txtRepeat.Text != string.Empty || txtEndProbation.Text != string.Empty)
		{
			if (Convert.ToInt32(txtEndProbation.Text) > Convert.ToInt32(txtRepeat.Text))
			{
				try
				{
					double result = (double.TryParse(txtRepeat.Text, out result) ? result : 0.0);
					double result2 = (double.TryParse(txtEndProbation.Text, out result2) ? result2 : 0.0);
					RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\A Level Cutoff");
					registryKey.SetValue("Repeat", result);
					registryKey.SetValue("ProbationEnd", result2);
					XtraMessageBox.Show("Settings saved successfully", "School Management Dynamics");
					return;
				}
				catch (Exception ex)
				{
					XtraMessageBox.Show(ex.Message, "School Management Dynamics");
					return;
				}
			}
			XtraMessageBox.Show("Repeating cuttoff cannot be greater than probation End Mark", "Invalid inputs");
		}
		else
		{
			XtraMessageBox.Show("Please enter valid values in all fields", "School Management Dynamics");
		}
	}

	private void simpleButton12_Click(object sender, EventArgs e)
	{
		if (cboALevelClass.SelectedIndex > 0)
		{
			ProcessALevelReports.InitializeALevelProcessing(SemesterSettings.NextTermBeginsOn(cboTerm.SelectedItem.ToString(), cboALevelClass.SelectedItem.ToString()), cboALevelClass.SelectedItem.ToString(), cboTerm.SelectedItem.ToString());
			using ProcessProgressALevel processProgressALevel = new ProcessProgressALevel(cboALevelClass.SelectedItem.ToString(), cboTerm.SelectedItem.ToString(), cboStream.SelectedItem.ToString());
			processProgressALevel.ShowDialog();
			return;
		}
		XtraMessageBox.Show("Please select a semester you wish to process.", "School Management Dynamics");
	}

	private void txtRepeat_TextChanged(object sender, EventArgs e)
	{
		if (txtRepeat.Text != string.Empty)
		{
			int num = Convert.ToInt32(txtRepeat.Text) + 1;
			txtDebutProbation.Text = num.ToString();
		}
		else
		{
			txtDebutProbation.Text = string.Empty;
		}
	}

	private void txtEndProbation_TextChanged(object sender, EventArgs e)
	{
		if (txtEndProbation.Text != string.Empty)
		{
			int num = Convert.ToInt32(txtEndProbation.Text) + 1;
			txtPromoted.Text = num.ToString();
		}
		else
		{
			txtPromoted.Text = string.Empty;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void ProcessALevel_Load(object sender, EventArgs e)
	{
		using GradingSystemChange gradingSystemChange = new GradingSystemChange();
		gradingSystemChange.ShowDialog();
	}

	private void cboTerm_Closed(object sender, ClosedEventArgs e)
	{
		if (cboTerm.SelectedItem.ToString().Contains("TermIII"))
		{
			layoutControlGroup12.Visibility = LayoutVisibility.Always;
			layoutControlGroup12.Expanded = true;
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\A Level Cutoff");
			txtRepeat.Text = registryKey.GetValue("Repeat").ToString();
			txtEndProbation.Text = registryKey.GetValue("ProbationEnd").ToString();
			base.Height = 346;
		}
		else
		{
			layoutControlGroup12.Expanded = false;
			layoutControlGroup12.Visibility = LayoutVisibility.Never;
			base.Height = 195;
		}
	}

	private void cboALevelClass_EditValueChanged(object sender, EventArgs e)
	{
		if (cboALevelClass.EditValue != null)
		{
			Stream.LoadStreams(cboALevelClass.SelectedItem.ToString(), cboStream);
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
		this.layoutControl13 = new DevExpress.XtraLayout.LayoutControl();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboTerm = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton12 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton11 = new DevExpress.XtraEditors.SimpleButton();
		this.txtPromoted = new DevExpress.XtraEditors.TextEdit();
		this.txtEndProbation = new DevExpress.XtraEditors.TextEdit();
		this.txtDebutProbation = new DevExpress.XtraEditors.TextEdit();
		this.txtRepeat = new DevExpress.XtraEditors.TextEdit();
		this.cboALevelClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup17 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup12 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem88 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem89 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem90 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem91 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem100 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem101 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem140 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl13).BeginInit();
		this.layoutControl13.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPromoted.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEndProbation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebutProbation.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtRepeat.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboALevelClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem88).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem89).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem90).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem91).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem100).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem101).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem140).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl13.Controls.Add(this.cboStream);
		this.layoutControl13.Controls.Add(this.cboTerm);
		this.layoutControl13.Controls.Add(this.simpleButton1);
		this.layoutControl13.Controls.Add(this.simpleButton12);
		this.layoutControl13.Controls.Add(this.simpleButton11);
		this.layoutControl13.Controls.Add(this.txtPromoted);
		this.layoutControl13.Controls.Add(this.txtEndProbation);
		this.layoutControl13.Controls.Add(this.txtDebutProbation);
		this.layoutControl13.Controls.Add(this.txtRepeat);
		this.layoutControl13.Controls.Add(this.cboALevelClass);
		this.layoutControl13.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl13.Location = new System.Drawing.Point(0, 0);
		this.layoutControl13.Name = "layoutControl13";
		this.layoutControl13.Root = this.layoutControlGroup17;
		this.layoutControl13.Size = new System.Drawing.Size(365, 307);
		this.layoutControl13.TabIndex = 6;
		this.layoutControl13.Text = "layoutControl13";
		this.cboStream.Location = new System.Drawing.Point(196, 59);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboStream.Properties.Appearance.Options.UseFont = true;
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Size = new System.Drawing.Size(166, 22);
		this.cboStream.StyleController = this.layoutControl13;
		this.cboStream.TabIndex = 28;
		this.cboTerm.Location = new System.Drawing.Point(196, 3);
		this.cboTerm.Name = "cboTerm";
		this.cboTerm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboTerm.Properties.Appearance.Options.UseFont = true;
		this.cboTerm.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboTerm.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboTerm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboTerm.Size = new System.Drawing.Size(166, 24);
		this.cboTerm.StyleController = this.layoutControl13;
		this.cboTerm.TabIndex = 27;
		this.cboTerm.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboTerm_Closed);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(184, 282);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(178, 22);
		this.simpleButton1.StyleController = this.layoutControl13;
		this.simpleButton1.TabIndex = 23;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.simpleButton12.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton12.Appearance.Options.UseFont = true;
		this.simpleButton12.Location = new System.Drawing.Point(3, 282);
		this.simpleButton12.Name = "simpleButton12";
		this.simpleButton12.Size = new System.Drawing.Size(177, 22);
		this.simpleButton12.StyleController = this.layoutControl13;
		this.simpleButton12.TabIndex = 22;
		this.simpleButton12.Text = "Process";
		this.simpleButton12.Click += new System.EventHandler(simpleButton12_Click);
		this.simpleButton11.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton11.Appearance.Options.UseFont = true;
		this.simpleButton11.Location = new System.Drawing.Point(8, 221);
		this.simpleButton11.Name = "simpleButton11";
		this.simpleButton11.Size = new System.Drawing.Size(349, 22);
		this.simpleButton11.StyleController = this.layoutControl13;
		this.simpleButton11.TabIndex = 21;
		this.simpleButton11.Text = "Save Cutoffs";
		this.simpleButton11.Click += new System.EventHandler(simpleButton11_Click);
		this.txtPromoted.Location = new System.Drawing.Point(200, 193);
		this.txtPromoted.Name = "txtPromoted";
		this.txtPromoted.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtPromoted.Properties.Appearance.Options.UseFont = true;
		this.txtPromoted.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtPromoted.Properties.ReadOnly = true;
		this.txtPromoted.Size = new System.Drawing.Size(157, 24);
		this.txtPromoted.StyleController = this.layoutControl13;
		this.txtPromoted.TabIndex = 19;
		this.txtEndProbation.Location = new System.Drawing.Point(200, 165);
		this.txtEndProbation.Name = "txtEndProbation";
		this.txtEndProbation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtEndProbation.Properties.Appearance.Options.UseFont = true;
		this.txtEndProbation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEndProbation.Properties.Mask.EditMask = "d";
		this.txtEndProbation.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtEndProbation.Size = new System.Drawing.Size(157, 24);
		this.txtEndProbation.StyleController = this.layoutControl13;
		this.txtEndProbation.TabIndex = 18;
		this.txtEndProbation.TextChanged += new System.EventHandler(txtEndProbation_TextChanged);
		this.txtDebutProbation.Location = new System.Drawing.Point(200, 137);
		this.txtDebutProbation.Name = "txtDebutProbation";
		this.txtDebutProbation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtDebutProbation.Properties.Appearance.Options.UseFont = true;
		this.txtDebutProbation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtDebutProbation.Properties.ReadOnly = true;
		this.txtDebutProbation.Size = new System.Drawing.Size(157, 24);
		this.txtDebutProbation.StyleController = this.layoutControl13;
		this.txtDebutProbation.TabIndex = 17;
		this.txtRepeat.Location = new System.Drawing.Point(200, 109);
		this.txtRepeat.Name = "txtRepeat";
		this.txtRepeat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtRepeat.Properties.Appearance.Options.UseFont = true;
		this.txtRepeat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtRepeat.Properties.Mask.EditMask = "d";
		this.txtRepeat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtRepeat.Size = new System.Drawing.Size(157, 24);
		this.txtRepeat.StyleController = this.layoutControl13;
		this.txtRepeat.TabIndex = 16;
		this.txtRepeat.TextChanged += new System.EventHandler(txtRepeat_TextChanged);
		this.cboALevelClass.EditValue = "-Select class-";
		this.cboALevelClass.Location = new System.Drawing.Point(196, 31);
		this.cboALevelClass.Name = "cboALevelClass";
		this.cboALevelClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboALevelClass.Properties.Appearance.Options.UseFont = true;
		this.cboALevelClass.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboALevelClass.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboALevelClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboALevelClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboALevelClass.Properties.Items.AddRange(new object[3] { "-Select class-", "S.5", "S.6" });
		this.cboALevelClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboALevelClass.Size = new System.Drawing.Size(166, 24);
		this.cboALevelClass.StyleController = this.layoutControl13;
		this.cboALevelClass.TabIndex = 4;
		this.cboALevelClass.EditValueChanged += new System.EventHandler(cboALevelClass_EditValueChanged);
		this.layoutControlGroup17.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup17.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup17.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlGroup12, this.layoutControlItem2, this.layoutControlItem140, this.layoutControlItem3, this.layoutControlItem101, this.layoutControlItem1, this.emptySpaceItem1 });
		this.layoutControlGroup17.Name = "layoutControlGroup1";
		this.layoutControlGroup17.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup17.Size = new System.Drawing.Size(365, 307);
		this.layoutControlGroup17.TextVisible = false;
		this.layoutControlGroup12.CustomizationFormText = "Student Cutoffs";
		this.layoutControlGroup12.GroupStyle = DevExpress.Utils.GroupStyle.Card;
		this.layoutControlGroup12.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem88, this.layoutControlItem89, this.layoutControlItem90, this.layoutControlItem91, this.layoutControlItem100 });
		this.layoutControlGroup12.Location = new System.Drawing.Point(0, 82);
		this.layoutControlGroup12.Name = "layoutControlGroup12";
		this.layoutControlGroup12.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup12.Size = new System.Drawing.Size(363, 167);
		this.layoutControlGroup12.Text = "Student Cutoffs";
		this.layoutControlItem88.Control = this.txtRepeat;
		this.layoutControlItem88.CustomizationFormText = "Repeat class for Total Points <=";
		this.layoutControlItem88.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem88.Name = "layoutControlItem88";
		this.layoutControlItem88.Size = new System.Drawing.Size(353, 28);
		this.layoutControlItem88.Text = "Repeat class for Total Points <=";
		this.layoutControlItem88.TextSize = new System.Drawing.Size(188, 13);
		this.layoutControlItem89.Control = this.txtDebutProbation;
		this.layoutControlItem89.CustomizationFormText = "Promoted on Probation for Points from:";
		this.layoutControlItem89.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem89.Name = "layoutControlItem89";
		this.layoutControlItem89.Size = new System.Drawing.Size(353, 28);
		this.layoutControlItem89.Text = "Promoted on Probation for Points from:";
		this.layoutControlItem89.TextSize = new System.Drawing.Size(188, 13);
		this.layoutControlItem90.Control = this.txtEndProbation;
		this.layoutControlItem90.CustomizationFormText = "To:";
		this.layoutControlItem90.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem90.Name = "layoutControlItem90";
		this.layoutControlItem90.Size = new System.Drawing.Size(353, 28);
		this.layoutControlItem90.Text = "To:";
		this.layoutControlItem90.TextSize = new System.Drawing.Size(188, 13);
		this.layoutControlItem91.Control = this.txtPromoted;
		this.layoutControlItem91.CustomizationFormText = "Promoted for Total Points >=";
		this.layoutControlItem91.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem91.Name = "layoutControlItem91";
		this.layoutControlItem91.Size = new System.Drawing.Size(353, 28);
		this.layoutControlItem91.Text = "Promoted for Total Points >=";
		this.layoutControlItem91.TextSize = new System.Drawing.Size(188, 13);
		this.layoutControlItem100.Control = this.simpleButton11;
		this.layoutControlItem100.CustomizationFormText = "layoutControlItem100";
		this.layoutControlItem100.Location = new System.Drawing.Point(0, 112);
		this.layoutControlItem100.Name = "layoutControlItem100";
		this.layoutControlItem100.Size = new System.Drawing.Size(353, 26);
		this.layoutControlItem100.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem100.TextVisible = false;
		this.layoutControlItem101.Control = this.simpleButton12;
		this.layoutControlItem101.CustomizationFormText = "layoutControlItem101";
		this.layoutControlItem101.Location = new System.Drawing.Point(0, 279);
		this.layoutControlItem101.Name = "layoutControlItem101";
		this.layoutControlItem101.Size = new System.Drawing.Size(181, 26);
		this.layoutControlItem101.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem101.TextVisible = false;
		this.layoutControlItem1.Control = this.simpleButton1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(181, 279);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(182, 26);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.cboTerm;
		this.layoutControlItem2.CustomizationFormText = "Term";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(363, 28);
		this.layoutControlItem2.Text = "Term";
		this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(188, 16);
		this.layoutControlItem2.TextToControlDistance = 5;
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.cboStream;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(363, 26);
		this.layoutControlItem3.Text = "Stream";
		this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(188, 16);
		this.layoutControlItem3.TextToControlDistance = 5;
		this.layoutControlItem140.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem140.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem140.Control = this.cboALevelClass;
		this.layoutControlItem140.CustomizationFormText = "Class:";
		this.layoutControlItem140.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem140.Name = "layoutControlItem1";
		this.layoutControlItem140.Size = new System.Drawing.Size(363, 28);
		this.layoutControlItem140.Text = "Class";
		this.layoutControlItem140.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem140.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem140.TextSize = new System.Drawing.Size(188, 16);
		this.layoutControlItem140.TextToControlDistance = 5;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 249);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(363, 30);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(365, 307);
		base.Controls.Add(this.layoutControl13);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "ProcessALevel";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Process A Level";
		base.Load += new System.EventHandler(ProcessALevel_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl13).EndInit();
		this.layoutControl13.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPromoted.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEndProbation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtDebutProbation.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtRepeat.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboALevelClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem88).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem89).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem90).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem91).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem100).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem101).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem140).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		base.ResumeLayout(false);
	}
}
