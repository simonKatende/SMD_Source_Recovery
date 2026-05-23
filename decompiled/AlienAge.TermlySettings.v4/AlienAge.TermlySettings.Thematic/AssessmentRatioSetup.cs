using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using AlienAge.TermlySettings.Thematic.Primary;
using AlienAge.TermlySettings.Thematic.Secondary.ALevel;
using AlienAge.TermlySettings.Thematic.Secondary.OLevel;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace AlienAge.TermlySettings.Thematic;

public class AssessmentRatioSetup : XtraForm
{
	private DataSet ds;

	private readonly string schoolType = SchoolSettings.SchoolGeneralCurriculum;

	private IContainer components = null;

	private TextEdit txtHoP;

	private LayoutControl layoutControl1;

	private MemoEdit memoEdit1;

	private CheckEdit chkProcessAs;

	private CheckEdit chkMOT;

	private CheckEdit chkEOT;

	private CheckEdit chkBOT;

	private CheckEdit chkHoP;

	private SimpleButton simpleButton1;

	private TextEdit txtEOT;

	private TextEdit txtMOT;

	private TextEdit txtBOT;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem17;

	private LayoutControlItem layoutControlItem18;

	private LayoutControlItem layoutControlItem20;

	private LayoutControlItem layoutControlItem19;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private SimpleButton simpleButton2;

	private LayoutControlItem layoutControlItem7;

	private Timer timer1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem6;

	private ComboBoxEdit cboClass;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem12;

	private DateEdit dtBegins;

	private LayoutControlItem layoutControlItem13;

	private TextEdit txtReportHeader;

	private LayoutControlItem layoutControlItem15;

	private TextEdit txtTerm;

	private CheckEdit checkEdit1;

	private LayoutControlItem layoutNotPerc;

	private TextEdit txthEOT;

	private TextEdit txthMOT;

	private TextEdit txthBOT;

	private TextEdit txthHoP;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem14;

	private LayoutControlItem layoutControlItem16;

	private LayoutControlItem layoutControlItem21;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private DateEdit dtEndsOn;

	private LayoutControlItem layoutControlItem22;

	private CheckEdit chkEOTOnly;

	private LayoutControlItem layoutControlItem23;

	public AssessmentRatioSetup()
	{
		InitializeComponent();
		Classes.LoadComboWithClasses(new ComboBoxEdit[1] { cboClass });
		txtTerm.Text = WorkingSemesters.GetWorkingSemester();
		LoadSetValues();
		layoutControlItem17.Visibility = LayoutVisibility.Never;
		layoutControlItem18.Visibility = LayoutVisibility.Never;
		layoutControlItem20.Visibility = LayoutVisibility.Never;
		layoutControlItem19.Visibility = LayoutVisibility.Never;
		txtHoP.Properties.ReadOnly = false;
		txtBOT.Properties.ReadOnly = false;
		txtMOT.Properties.ReadOnly = false;
		txtEOT.Properties.ReadOnly = false;
		layoutControlGroup2.Text = "Set ratios";
		memoEdit1.Text = "Reports will be processed and sets output as per assigned ratios";
	}

	private void RegradeClass()
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			double result = (double.TryParse(txtHoP.Text, out result) ? result : 0.0);
			double result2 = (double.TryParse(txtBOT.Text, out result2) ? result2 : 0.0);
			double result3 = (double.TryParse(txtMOT.Text, out result3) ? result3 : 0.0);
			double result4 = (double.TryParse(txtEOT.Text, out result4) ? result4 : 0.0);
			bool pROCESSASPER = Convert.ToBoolean(chkProcessAs.EditValue);
			bool aeot = Convert.ToBoolean(chkEOTOnly.EditValue);
			using PrimaryProcessProgress primaryProcessProgress = new PrimaryProcessProgress(result, result2, result3, result4, pROCESSASPER, dtBegins.DateTime, txtReportHeader.Text.ToUpper(), SelectedSets(), cboClass.SelectedItem.ToString(), txtTerm.Text, Convert.ToBoolean(checkEdit1.EditValue), txthHoP.Text, txthBOT.Text, txthMOT.Text, txthEOT.Text, aeot);
			primaryProcessProgress.Text = $"Re-grading {cboClass.SelectedItem} students. Please wait...";
			if (primaryProcessProgress.ShowDialog() == DialogResult.OK)
			{
				LoadSetValues();
			}
			return;
		}
		if (schoolType == SchoolSettings.SchoolType.Secondary.ToString() && SchoolSettings.ClassLevel(cboClass.SelectedItem.ToString()) == SchoolSettings.SecondaryClassLevels.OLevel.ToString())
		{
			double result5 = (double.TryParse(txtHoP.Text, out result5) ? result5 : 0.0);
			double result6 = (double.TryParse(txtBOT.Text, out result6) ? result6 : 0.0);
			double result7 = (double.TryParse(txtMOT.Text, out result7) ? result7 : 0.0);
			double result8 = (double.TryParse(txtEOT.Text, out result8) ? result8 : 0.0);
			bool pROCESSASPER2 = Convert.ToBoolean(chkProcessAs.EditValue);
			using OLevelProcessProgress oLevelProcessProgress = new OLevelProcessProgress(result5, result6, result7, result8, pROCESSASPER2, dtBegins.DateTime, txtReportHeader.Text.ToUpper(), SelectedSets(), cboClass.SelectedItem.ToString(), txtTerm.Text, Convert.ToBoolean(checkEdit1.EditValue), txthHoP.Text, txthBOT.Text, txthMOT.Text, txthEOT.Text);
			oLevelProcessProgress.Text = $"Re-grading {cboClass.SelectedItem} students. Please wait...";
			if (oLevelProcessProgress.ShowDialog() == DialogResult.OK)
			{
				LoadSetValues();
			}
			return;
		}
		if (!(schoolType == SchoolSettings.SchoolType.Secondary.ToString()) || !(SchoolSettings.ClassLevel(cboClass.SelectedItem.ToString()) == SchoolSettings.SecondaryClassLevels.ALevel.ToString()))
		{
			return;
		}
		double result9 = (double.TryParse(txtHoP.Text, out result9) ? result9 : 0.0);
		double result10 = (double.TryParse(txtBOT.Text, out result10) ? result10 : 0.0);
		double result11 = (double.TryParse(txtMOT.Text, out result11) ? result11 : 0.0);
		double result12 = (double.TryParse(txtEOT.Text, out result12) ? result12 : 0.0);
		bool pROCESSASPER3 = Convert.ToBoolean(chkProcessAs.EditValue);
		using (ALevelProcessProgress aLevelProcessProgress = new ALevelProcessProgress(result9, result10, result11, result12, pROCESSASPER3, dtBegins.DateTime, txtReportHeader.Text.ToUpper(), SelectedSets(), cboClass.SelectedItem.ToString(), txtTerm.Text, Convert.ToBoolean(checkEdit1.EditValue), txthHoP.Text, txthBOT.Text, txthMOT.Text, txthEOT.Text))
		{
			aLevelProcessProgress.Text = $"Re-grading {cboClass.SelectedItem} students. Please wait...";
			if (aLevelProcessProgress.ShowDialog() == DialogResult.OK)
			{
				LoadSetValues();
			}
		}
		double result13 = (double.TryParse(txtHoP.Text, out result13) ? result13 : 0.0);
		double result14 = (double.TryParse(txtBOT.Text, out result14) ? result14 : 0.0);
		double result15 = (double.TryParse(txtMOT.Text, out result15) ? result15 : 0.0);
		double result16 = (double.TryParse(txtEOT.Text, out result16) ? result16 : 0.0);
		double num = result13 + result14 + result15 + result16;
		try
		{
			LoadSetValues();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (simpleButton1.Text == "Add Settings")
		{
			double result = (double.TryParse(txtHoP.Text, out result) ? result : 0.0);
			double result2 = (double.TryParse(txtBOT.Text, out result2) ? result2 : 0.0);
			double result3 = (double.TryParse(txtMOT.Text, out result3) ? result3 : 0.0);
			double result4 = (double.TryParse(txtEOT.Text, out result4) ? result4 : 0.0);
			bool aEOT = Convert.ToBoolean(chkEOTOnly.EditValue);
			SemesterSettings.SetClassTermSettings(cboClass.SelectedItem.ToString(), txtTerm.Text, result, result2, result3, result4, Convert.ToBoolean(chkProcessAs.EditValue), dtBegins.DateTime, dtEndsOn.DateTime, txtReportHeader.Text.ToUpper(), SelectedSets(), Convert.ToBoolean(checkEdit1.EditValue), txthHoP.Text, txthBOT.Text, txthMOT.Text, txthEOT.Text, aEOT);
			LoadSetValues();
			simpleButton1.Text = "Change Settings";
		}
		else if (simpleButton1.Text == "Change Settings")
		{
			DialogResult dialogResult = XtraMessageBox.Show("You are about to change your sets configuration.\nThe system will automatically re-grade students basing on the selected settings.\n Click Yes if you wish to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
			if (dialogResult == DialogResult.Yes)
			{
				double result5 = (double.TryParse(txtHoP.Text, out result5) ? result5 : 0.0);
				double result6 = (double.TryParse(txtBOT.Text, out result6) ? result6 : 0.0);
				double result7 = (double.TryParse(txtMOT.Text, out result7) ? result7 : 0.0);
				double result8 = (double.TryParse(txtEOT.Text, out result8) ? result8 : 0.0);
				bool aEOT2 = Convert.ToBoolean(chkEOTOnly.EditValue);
				SemesterSettings.UpdateClassTermSettings(cboClass.SelectedItem.ToString(), txtTerm.Text, result5, result6, result7, result8, Convert.ToBoolean(chkProcessAs.EditValue), dtBegins.DateTime, dtEndsOn.DateTime, txtReportHeader.Text.ToUpper(), SelectedSets(), Convert.ToBoolean(checkEdit1.EditValue), txthHoP.Text, txthBOT.Text, txthMOT.Text, txthEOT.Text, aEOT2);
				RegradeClass();
			}
		}
	}

	private void chkProcessAs_CheckedChanged(object sender, EventArgs e)
	{
		if (chkProcessAs.Checked)
		{
			checkEdit1.Checked = false;
			checkEdit1.Enabled = false;
			layoutControlItem17.Visibility = LayoutVisibility.Always;
			layoutControlItem18.Visibility = LayoutVisibility.Always;
			layoutControlItem20.Visibility = LayoutVisibility.Always;
			layoutControlItem19.Visibility = LayoutVisibility.Always;
			txtHoP.Properties.ReadOnly = true;
			txtBOT.Properties.ReadOnly = true;
			txtMOT.Properties.ReadOnly = true;
			txtEOT.Properties.ReadOnly = true;
			txtBOT.Text = "0";
			txtMOT.Text = "0";
			txtEOT.Text = "0";
			txtHoP.Text = "0";
			layoutControlGroup2.Text = "Select sets";
			memoEdit1.Text = "All sets selected will contribute equally to the Final Mark";
		}
		else
		{
			checkEdit1.Enabled = true;
			layoutControlItem17.Visibility = LayoutVisibility.Never;
			layoutControlItem18.Visibility = LayoutVisibility.Never;
			layoutControlItem20.Visibility = LayoutVisibility.Never;
			layoutControlItem19.Visibility = LayoutVisibility.Never;
			txtHoP.Properties.ReadOnly = false;
			txtBOT.Properties.ReadOnly = false;
			txtMOT.Properties.ReadOnly = false;
			txtEOT.Properties.ReadOnly = false;
			layoutControlGroup2.Text = "Set ratios";
			memoEdit1.Text = "Reports will be processed and sets output as per assigned ratios";
		}
		LoadClassSettings(cboClass.SelectedItem.ToString(), txtTerm.Text, Convert.ToInt32(chkProcessAs.EditValue));
	}

	private void chkHoP_CheckedChanged(object sender, EventArgs e)
	{
		if (chkHoP.Checked)
		{
			txtHoP.Text = "100";
		}
		else
		{
			txtHoP.Text = "0";
		}
	}

	private void chkBOT_CheckedChanged(object sender, EventArgs e)
	{
		if (chkBOT.Checked)
		{
			txtBOT.Text = "100";
		}
		else
		{
			txtBOT.Text = "0";
		}
	}

	private void chkMOT_CheckedChanged(object sender, EventArgs e)
	{
		if (chkMOT.Checked)
		{
			txtMOT.Text = "100";
		}
		else
		{
			txtMOT.Text = "0";
		}
	}

	private void chkEOT_CheckedChanged(object sender, EventArgs e)
	{
		if (chkEOT.Checked)
		{
			txtEOT.Text = "100";
		}
		else
		{
			txtEOT.Text = "0";
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		double result = (double.TryParse(txtHoP.Text, out result) ? result : 0.0);
		double result2 = (double.TryParse(txtBOT.Text, out result2) ? result2 : 0.0);
		double result3 = (double.TryParse(txtMOT.Text, out result3) ? result3 : 0.0);
		double result4 = (double.TryParse(txtEOT.Text, out result4) ? result4 : 0.0);
		double num = result + result2 + result3 + result4;
		if (chkProcessAs.Checked)
		{
			if (num > 0.0 && dtBegins.EditValue != null && dtEndsOn.EditValue != null && txtReportHeader.Text != "")
			{
				simpleButton1.Enabled = true;
			}
			else
			{
				simpleButton1.Enabled = false;
			}
		}
		else if (!chkProcessAs.Checked)
		{
			if (num == 100.0 && dtBegins.EditValue != null && txtReportHeader.Text != "")
			{
				simpleButton1.Enabled = true;
			}
			else
			{
				simpleButton1.Enabled = false;
			}
		}
	}

	private void LoadSetValues()
	{
		try
		{
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings WHERE SemesterId='{txtTerm.Text}' Order By SemesterId,ClassId", DataConnection.ConnectToDatabase()))
			{
				ds = new DataSet();
				sqlDataAdapter.Fill(ds, "TermSettings");
				gridControl1.DataSource = ds.Tables[0].DefaultView;
			}
			gridView1.FocusedRowHandle = -1;
			chkProcessAs.Focus();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private string SelectedSets()
	{
		string result = "";
		if (txtHoP.Text != "0" && txtBOT.Text != "0" && txtMOT.Text != "0" && txtEOT.Text != "0")
		{
			result = "HBME";
		}
		else if (txtBOT.Text != "0" && txtMOT.Text != "0" && txtEOT.Text != "0" && txtHoP.Text == "0")
		{
			result = "BME";
		}
		else if (txtBOT.Text != "0" && txtMOT.Text != "0" && txtEOT.Text == "0" && txtHoP.Text != "0")
		{
			result = "HBM";
		}
		else if (txtBOT.Text != "0" && txtMOT.Text == "0" && txtEOT.Text != "0" && txtHoP.Text != "0")
		{
			result = "HBE";
		}
		else if (txtBOT.Text == "0" && txtMOT.Text != "0" && txtEOT.Text != "0" && txtHoP.Text != "0")
		{
			result = "HME";
		}
		else if (txtBOT.Text != "0" && txtMOT.Text != "0" && txtHoP.Text == "0" && txtEOT.Text == "0")
		{
			result = "BM";
		}
		else if (txtBOT.Text != "0" && txtMOT.Text == "0" && txtHoP.Text != "0" && txtEOT.Text == "0")
		{
			result = "HB";
		}
		else if (txtBOT.Text == "0" && txtMOT.Text != "0" && txtHoP.Text != "0" && txtEOT.Text == "0")
		{
			result = "HM";
		}
		else if (txtBOT.Text == "0" && txtMOT.Text == "0" && txtHoP.Text != "0" && txtEOT.Text != "0")
		{
			result = "HE";
		}
		else if (txtBOT.Text != "0" && txtEOT.Text != "0" && txtHoP.Text == "0" && txtMOT.Text == "0")
		{
			result = "BE";
		}
		else if (txtMOT.Text != "0" && txtEOT.Text != "0" && txtHoP.Text == "0" && txtBOT.Text == "0")
		{
			result = "ME";
		}
		else if (txtBOT.Text != "0" && txtHoP.Text == "0" && txtEOT.Text == "0" && txtMOT.Text == "0")
		{
			result = "B";
		}
		else if (txtMOT.Text != "0" && txtHoP.Text == "0" && txtEOT.Text == "0" && txtBOT.Text == "0")
		{
			result = "M";
		}
		else if (txtEOT.Text != "0" && txtHoP.Text == "0" && txtBOT.Text == "0" && txtMOT.Text == "0")
		{
			result = "E";
		}
		else if (txtEOT.Text == "0" && txtHoP.Text != "0" && txtBOT.Text == "0" && txtMOT.Text == "0")
		{
			result = "H";
		}
		else
		{
			XtraMessageBox.Show("The selected Sets Configuration is not valid. Valid Configurations are:\n HBME or BME or BM or BE or ME or B or M or E", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		return result;
	}

	private void txtHoP_TextChanged(object sender, EventArgs e)
	{
		if (chkProcessAs.Checked && txtHoP.Text != "0")
		{
			chkHoP.Checked = true;
		}
		else
		{
			chkHoP.Checked = false;
		}
	}

	private void txtBOT_TextChanged(object sender, EventArgs e)
	{
		if (chkProcessAs.Checked && txtBOT.Text != "0")
		{
			chkBOT.Checked = true;
		}
		else
		{
			chkBOT.Checked = false;
		}
	}

	private void txtMOT_TextChanged(object sender, EventArgs e)
	{
		if (chkProcessAs.Checked && txtMOT.Text != "0")
		{
			chkMOT.Checked = true;
		}
		else
		{
			chkMOT.Checked = false;
		}
	}

	private void txtEOT_TextChanged(object sender, EventArgs e)
	{
		if (chkProcessAs.Checked && txtEOT.Text != "0")
		{
			chkEOT.Checked = true;
		}
		else
		{
			chkEOT.Checked = false;
		}
	}

	private void LoadClassSettings(string ClassId, string TermId)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings WHERE ClassId='{ClassId}' AND SemesterId='{TermId}'", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				chkProcessAs.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsPercentage"]);
				checkEdit1.Checked = Convert.ToBoolean(dataTable.Rows[0]["EnterAs100"]);
				cboClass.SelectedItem = dataTable.Rows[0]["ClassId"].ToString();
				txtTerm.Text = dataTable.Rows[0]["SemesterId"].ToString();
				txtBOT.Text = dataTable.Rows[0]["BOT"].ToString();
				txtEOT.Text = dataTable.Rows[0]["EOT"].ToString();
				txtHoP.Text = dataTable.Rows[0]["HoP"].ToString();
				txtMOT.Text = dataTable.Rows[0]["MOT"].ToString();
				txthBOT.Text = dataTable.Rows[0]["hBOT"].ToString();
				txthEOT.Text = dataTable.Rows[0]["hEOT"].ToString();
				txthHoP.Text = dataTable.Rows[0]["hHoP"].ToString();
				txthMOT.Text = dataTable.Rows[0]["hMOT"].ToString();
				txtReportHeader.Text = dataTable.Rows[0]["ReportHeader"].ToString();
				bool result = bool.TryParse(dataTable.Rows[0]["AEOT"].ToString(), out result) && result;
				chkEOTOnly.Checked = result;
				DateTime result2 = (DateTime.TryParse(dataTable.Rows[0]["TermEndsOn"].ToString(), out result2) ? result2 : DateTime.Now);
				DateTime result3 = (DateTime.TryParse(dataTable.Rows[0]["TermBeginsOn"].ToString(), out result3) ? result3 : DateTime.Now);
				dtBegins.DateTime = result3;
				dtEndsOn.DateTime = result2;
			}
		}
	}

	private void LoadClassSettings(string ClassId, string TermId, int ProcessType)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings WHERE ClassId='{ClassId}' AND SemesterId='{TermId}' AND IsPercentage={ProcessType}", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				chkProcessAs.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsPercentage"]);
				checkEdit1.Checked = Convert.ToBoolean(dataTable.Rows[0]["EnterAs100"]);
				cboClass.SelectedItem = dataTable.Rows[0]["ClassId"].ToString();
				txtTerm.Text = dataTable.Rows[0]["SemesterId"].ToString();
				txtBOT.Text = dataTable.Rows[0]["BOT"].ToString();
				txtEOT.Text = dataTable.Rows[0]["EOT"].ToString();
				txtHoP.Text = dataTable.Rows[0]["HoP"].ToString();
				txtMOT.Text = dataTable.Rows[0]["MOT"].ToString();
				txthBOT.Text = dataTable.Rows[0]["hBOT"].ToString();
				txthEOT.Text = dataTable.Rows[0]["hEOT"].ToString();
				txthHoP.Text = dataTable.Rows[0]["hHoP"].ToString();
				txthMOT.Text = dataTable.Rows[0]["hMOT"].ToString();
				txtReportHeader.Text = dataTable.Rows[0]["ReportHeader"].ToString();
				bool result = bool.TryParse(dataTable.Rows[0]["AEOT"].ToString(), out result) && result;
				chkEOTOnly.Checked = result;
				DateTime result2 = (DateTime.TryParse(dataTable.Rows[0]["TermEndsOn"].ToString(), out result2) ? result2 : DateTime.Now);
				DateTime result3 = (DateTime.TryParse(dataTable.Rows[0]["TermBeginsOn"].ToString(), out result3) ? result3 : DateTime.Now);
				dtBegins.DateTime = result3;
				dtEndsOn.DateTime = result2;
			}
		}
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		if (SemesterSettings.IsSemesterSet(cboClass.SelectedItem.ToString(), txtTerm.Text))
		{
			LoadClassSettings(cboClass.SelectedItem.ToString(), txtTerm.Text);
			simpleButton1.Text = "Change Settings";
			return;
		}
		simpleButton1.Text = "Add Settings";
		txthHoP.Text = "HoP";
		txthBOT.Text = "BOT";
		txthMOT.Text = "MOT";
		txthEOT.Text = "EOT";
	}

	private void AssessmentRatioSetup_Load(object sender, EventArgs e)
	{
		if (schoolType == SchoolSettings.SchoolType.Primary.ToString())
		{
			layoutControlItem23.Visibility = LayoutVisibility.Always;
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
		this.txtHoP = new DevExpress.XtraEditors.TextEdit();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.dtEndsOn = new DevExpress.XtraEditors.DateEdit();
		this.txthEOT = new DevExpress.XtraEditors.TextEdit();
		this.txthMOT = new DevExpress.XtraEditors.TextEdit();
		this.txthBOT = new DevExpress.XtraEditors.TextEdit();
		this.txthHoP = new DevExpress.XtraEditors.TextEdit();
		this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
		this.txtReportHeader = new DevExpress.XtraEditors.TextEdit();
		this.dtBegins = new DevExpress.XtraEditors.DateEdit();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
		this.chkProcessAs = new DevExpress.XtraEditors.CheckEdit();
		this.chkMOT = new DevExpress.XtraEditors.CheckEdit();
		this.chkEOT = new DevExpress.XtraEditors.CheckEdit();
		this.chkBOT = new DevExpress.XtraEditors.CheckEdit();
		this.chkHoP = new DevExpress.XtraEditors.CheckEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtEOT = new DevExpress.XtraEditors.TextEdit();
		this.txtMOT = new DevExpress.XtraEditors.TextEdit();
		this.txtBOT = new DevExpress.XtraEditors.TextEdit();
		this.txtTerm = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutNotPerc = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.chkEOTOnly = new DevExpress.XtraEditors.CheckEdit();
		this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.txtHoP.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dtEndsOn.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtEndsOn.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txthEOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txthMOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txthBOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txthHoP.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkProcessAs.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkMOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkEOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkBOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkHoP.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtMOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem22).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutNotPerc).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkEOTOnly.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).BeginInit();
		base.SuspendLayout();
		this.txtHoP.Location = new System.Drawing.Point(53, 230);
		this.txtHoP.Margin = new System.Windows.Forms.Padding(2);
		this.txtHoP.Name = "txtHoP";
		this.txtHoP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtHoP.Properties.Mask.EditMask = "d";
		this.txtHoP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtHoP.Properties.MaxLength = 3;
		this.txtHoP.Size = new System.Drawing.Size(53, 22);
		this.txtHoP.StyleController = this.layoutControl1;
		this.txtHoP.TabIndex = 4;
		this.txtHoP.TextChanged += new System.EventHandler(txtHoP_TextChanged);
		this.layoutControl1.Controls.Add(this.chkEOTOnly);
		this.layoutControl1.Controls.Add(this.dtEndsOn);
		this.layoutControl1.Controls.Add(this.txthEOT);
		this.layoutControl1.Controls.Add(this.txthMOT);
		this.layoutControl1.Controls.Add(this.txthBOT);
		this.layoutControl1.Controls.Add(this.txthHoP);
		this.layoutControl1.Controls.Add(this.checkEdit1);
		this.layoutControl1.Controls.Add(this.txtReportHeader);
		this.layoutControl1.Controls.Add(this.dtBegins);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.memoEdit1);
		this.layoutControl1.Controls.Add(this.chkProcessAs);
		this.layoutControl1.Controls.Add(this.chkMOT);
		this.layoutControl1.Controls.Add(this.chkEOT);
		this.layoutControl1.Controls.Add(this.chkBOT);
		this.layoutControl1.Controls.Add(this.chkHoP);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtEOT);
		this.layoutControl1.Controls.Add(this.txtMOT);
		this.layoutControl1.Controls.Add(this.txtBOT);
		this.layoutControl1.Controls.Add(this.txtHoP);
		this.layoutControl1.Controls.Add(this.txtTerm);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(524, 115, 527, 518);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(606, 451);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.dtEndsOn.EditValue = null;
		this.dtEndsOn.Location = new System.Drawing.Point(117, 394);
		this.dtEndsOn.Name = "dtEndsOn";
		this.dtEndsOn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtEndsOn.Properties.Appearance.Options.UseFont = true;
		this.dtEndsOn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtEndsOn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtEndsOn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtEndsOn.Properties.DisplayFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtEndsOn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEndsOn.Properties.EditFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtEndsOn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtEndsOn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtEndsOn.Size = new System.Drawing.Size(119, 24);
		this.dtEndsOn.StyleController = this.layoutControl1;
		this.dtEndsOn.TabIndex = 40;
		this.txthEOT.Location = new System.Drawing.Point(172, 314);
		this.txthEOT.Margin = new System.Windows.Forms.Padding(2);
		this.txthEOT.Name = "txthEOT";
		this.txthEOT.Properties.MaxLength = 12;
		this.txthEOT.Size = new System.Drawing.Size(64, 20);
		this.txthEOT.StyleController = this.layoutControl1;
		this.txthEOT.TabIndex = 39;
		this.txthMOT.Location = new System.Drawing.Point(172, 286);
		this.txthMOT.Margin = new System.Windows.Forms.Padding(2);
		this.txthMOT.Name = "txthMOT";
		this.txthMOT.Properties.MaxLength = 12;
		this.txthMOT.Size = new System.Drawing.Size(64, 20);
		this.txthMOT.StyleController = this.layoutControl1;
		this.txthMOT.TabIndex = 38;
		this.txthBOT.Location = new System.Drawing.Point(172, 258);
		this.txthBOT.Margin = new System.Windows.Forms.Padding(2);
		this.txthBOT.Name = "txthBOT";
		this.txthBOT.Properties.MaxLength = 12;
		this.txthBOT.Size = new System.Drawing.Size(64, 20);
		this.txthBOT.StyleController = this.layoutControl1;
		this.txthBOT.TabIndex = 37;
		this.txthHoP.Location = new System.Drawing.Point(172, 230);
		this.txthHoP.Margin = new System.Windows.Forms.Padding(2);
		this.txthHoP.Name = "txthHoP";
		this.txthHoP.Properties.MaxLength = 12;
		this.txthHoP.Size = new System.Drawing.Size(64, 20);
		this.txthHoP.StyleController = this.layoutControl1;
		this.txthHoP.TabIndex = 36;
		this.checkEdit1.Location = new System.Drawing.Point(3, 31);
		this.checkEdit1.Margin = new System.Windows.Forms.Padding(2);
		this.checkEdit1.Name = "checkEdit1";
		this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
		this.checkEdit1.Properties.Appearance.Options.UseFont = true;
		this.checkEdit1.Properties.Caption = "Marks ARE NOT entered out of 100%";
		this.checkEdit1.Size = new System.Drawing.Size(236, 20);
		this.checkEdit1.StyleController = this.layoutControl1;
		this.checkEdit1.TabIndex = 35;
		this.txtReportHeader.Location = new System.Drawing.Point(3, 178);
		this.txtReportHeader.Name = "txtReportHeader";
		this.txtReportHeader.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtReportHeader.Properties.Appearance.Options.UseFont = true;
		this.txtReportHeader.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReportHeader.Size = new System.Drawing.Size(236, 24);
		this.txtReportHeader.StyleController = this.layoutControl1;
		this.txtReportHeader.TabIndex = 34;
		this.dtBegins.EditValue = null;
		this.dtBegins.Location = new System.Drawing.Point(117, 366);
		this.dtBegins.Name = "dtBegins";
		this.dtBegins.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtBegins.Properties.Appearance.Options.UseFont = true;
		this.dtBegins.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtBegins.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtBegins.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtBegins.Properties.DisplayFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtBegins.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtBegins.Properties.EditFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtBegins.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtBegins.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.dtBegins.Size = new System.Drawing.Size(119, 24);
		this.dtBegins.StyleController = this.layoutControl1;
		this.dtBegins.TabIndex = 32;
		this.cboClass.Location = new System.Drawing.Point(122, 134);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboClass.Properties.Appearance.Options.UseFont = true;
		this.cboClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(117, 24);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 30;
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.gridControl1.Location = new System.Drawing.Point(243, 3);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(360, 418);
		this.gridControl1.TabIndex = 28;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.GroupFormat = "{1} {2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridColumn1.Caption = "SemesterId";
		this.gridColumn1.FieldName = "SemesterId";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Class";
		this.gridColumn2.FieldName = "ClassId";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 50;
		this.gridColumn3.Caption = "HoP";
		this.gridColumn3.FieldName = "HoP";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 50;
		this.gridColumn4.Caption = "BOT";
		this.gridColumn4.FieldName = "BOT";
		this.gridColumn4.MinWidth = 13;
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn4.Width = 50;
		this.gridColumn5.Caption = "MOT";
		this.gridColumn5.FieldName = "MOT";
		this.gridColumn5.MinWidth = 13;
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.gridColumn5.Width = 50;
		this.gridColumn6.Caption = "EOT";
		this.gridColumn6.FieldName = "EOT";
		this.gridColumn6.MinWidth = 13;
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 4;
		this.gridColumn6.Width = 50;
		this.gridColumn7.Caption = "Is (%)";
		this.gridColumn7.FieldName = "IsPercentage";
		this.gridColumn7.MinWidth = 13;
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 5;
		this.gridColumn7.Width = 50;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(289, 425);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(314, 23);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 27;
		this.simpleButton2.Text = "Close";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.memoEdit1.Location = new System.Drawing.Point(3, 55);
		this.memoEdit1.Name = "memoEdit1";
		this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.memoEdit1.Size = new System.Drawing.Size(236, 59);
		this.memoEdit1.StyleController = this.layoutControl1;
		this.memoEdit1.TabIndex = 26;
		this.chkProcessAs.Location = new System.Drawing.Point(3, 3);
		this.chkProcessAs.Name = "chkProcessAs";
		this.chkProcessAs.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
		this.chkProcessAs.Properties.Appearance.Options.UseFont = true;
		this.chkProcessAs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkProcessAs.Properties.Caption = "Process reports as Percentages";
		this.chkProcessAs.Size = new System.Drawing.Size(236, 24);
		this.chkProcessAs.StyleController = this.layoutControl1;
		this.chkProcessAs.TabIndex = 16;
		this.chkProcessAs.CheckedChanged += new System.EventHandler(chkProcessAs_CheckedChanged);
		this.chkMOT.Location = new System.Drawing.Point(6, 286);
		this.chkMOT.Margin = new System.Windows.Forms.Padding(0);
		this.chkMOT.Name = "chkMOT";
		this.chkMOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkMOT.Properties.Caption = "";
		this.chkMOT.Size = new System.Drawing.Size(25, 24);
		this.chkMOT.StyleController = this.layoutControl1;
		this.chkMOT.TabIndex = 25;
		this.chkMOT.CheckedChanged += new System.EventHandler(chkMOT_CheckedChanged);
		this.chkEOT.Location = new System.Drawing.Point(6, 314);
		this.chkEOT.Margin = new System.Windows.Forms.Padding(0);
		this.chkEOT.Name = "chkEOT";
		this.chkEOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkEOT.Properties.Caption = "";
		this.chkEOT.Size = new System.Drawing.Size(25, 24);
		this.chkEOT.StyleController = this.layoutControl1;
		this.chkEOT.TabIndex = 24;
		this.chkEOT.CheckedChanged += new System.EventHandler(chkEOT_CheckedChanged);
		this.chkBOT.Location = new System.Drawing.Point(6, 258);
		this.chkBOT.Margin = new System.Windows.Forms.Padding(0);
		this.chkBOT.Name = "chkBOT";
		this.chkBOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkBOT.Properties.Caption = "";
		this.chkBOT.Size = new System.Drawing.Size(25, 24);
		this.chkBOT.StyleController = this.layoutControl1;
		this.chkBOT.TabIndex = 23;
		this.chkBOT.CheckedChanged += new System.EventHandler(chkBOT_CheckedChanged);
		this.chkHoP.Location = new System.Drawing.Point(6, 230);
		this.chkHoP.Margin = new System.Windows.Forms.Padding(0);
		this.chkHoP.Name = "chkHoP";
		this.chkHoP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkHoP.Properties.Caption = "";
		this.chkHoP.Size = new System.Drawing.Size(25, 24);
		this.chkHoP.StyleController = this.layoutControl1;
		this.chkHoP.TabIndex = 22;
		this.chkHoP.CheckedChanged += new System.EventHandler(chkHoP_CheckedChanged);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(3, 425);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(282, 23);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 9;
		this.simpleButton1.Text = "Add Settings";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtEOT.Location = new System.Drawing.Point(52, 314);
		this.txtEOT.Margin = new System.Windows.Forms.Padding(2);
		this.txtEOT.Name = "txtEOT";
		this.txtEOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEOT.Properties.Mask.EditMask = "d";
		this.txtEOT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtEOT.Properties.MaxLength = 3;
		this.txtEOT.Size = new System.Drawing.Size(54, 22);
		this.txtEOT.StyleController = this.layoutControl1;
		this.txtEOT.TabIndex = 8;
		this.txtEOT.TextChanged += new System.EventHandler(txtEOT_TextChanged);
		this.txtMOT.Location = new System.Drawing.Point(54, 286);
		this.txtMOT.Margin = new System.Windows.Forms.Padding(2);
		this.txtMOT.Name = "txtMOT";
		this.txtMOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtMOT.Properties.Mask.EditMask = "d";
		this.txtMOT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtMOT.Properties.MaxLength = 3;
		this.txtMOT.Size = new System.Drawing.Size(52, 22);
		this.txtMOT.StyleController = this.layoutControl1;
		this.txtMOT.TabIndex = 7;
		this.txtMOT.TextChanged += new System.EventHandler(txtMOT_TextChanged);
		this.txtBOT.Location = new System.Drawing.Point(52, 258);
		this.txtBOT.Margin = new System.Windows.Forms.Padding(2);
		this.txtBOT.Name = "txtBOT";
		this.txtBOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBOT.Properties.Mask.EditMask = "d";
		this.txtBOT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtBOT.Properties.MaxLength = 3;
		this.txtBOT.Size = new System.Drawing.Size(54, 22);
		this.txtBOT.StyleController = this.layoutControl1;
		this.txtBOT.TabIndex = 5;
		this.txtBOT.TextChanged += new System.EventHandler(txtBOT_TextChanged);
		this.txtTerm.Location = new System.Drawing.Point(3, 134);
		this.txtTerm.Name = "txtTerm";
		this.txtTerm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTerm.Properties.Appearance.Options.UseFont = true;
		this.txtTerm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTerm.Properties.ReadOnly = true;
		this.txtTerm.Size = new System.Drawing.Size(115, 24);
		this.txtTerm.StyleController = this.layoutControl1;
		this.txtTerm.TabIndex = 31;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[10] { this.layoutControlGroup2, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem6, this.layoutControlItem15, this.layoutControlItem12, this.layoutNotPerc, this.layoutControlItem5, this.layoutControlItem7, this.layoutControlItem11 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(606, 451);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[15]
		{
			this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem4, this.layoutControlItem3, this.layoutControlItem17, this.layoutControlItem18, this.layoutControlItem20, this.layoutControlItem19, this.layoutControlItem13, this.layoutControlItem10,
			this.layoutControlItem14, this.layoutControlItem16, this.layoutControlItem21, this.layoutControlItem22, this.layoutControlItem23
		});
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 203);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup2.Size = new System.Drawing.Size(240, 219);
		this.layoutControlItem1.Control = this.txtHoP;
		this.layoutControlItem1.CustomizationFormText = "HoP:";
		this.layoutControlItem1.Location = new System.Drawing.Point(29, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(75, 28);
		this.layoutControlItem1.Text = "HP";
		this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(13, 13);
		this.layoutControlItem1.TextToControlDistance = 5;
		this.layoutControlItem2.Control = this.txtBOT;
		this.layoutControlItem2.CustomizationFormText = "BOT:";
		this.layoutControlItem2.Location = new System.Drawing.Point(29, 28);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(75, 28);
		this.layoutControlItem2.Text = "BT";
		this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(12, 13);
		this.layoutControlItem2.TextToControlDistance = 5;
		this.layoutControlItem4.Control = this.txtMOT;
		this.layoutControlItem4.CustomizationFormText = "MOT:";
		this.layoutControlItem4.Location = new System.Drawing.Point(29, 56);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(75, 28);
		this.layoutControlItem4.Text = "MT";
		this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(14, 13);
		this.layoutControlItem4.TextToControlDistance = 5;
		this.layoutControlItem3.Control = this.txtEOT;
		this.layoutControlItem3.CustomizationFormText = "EOT:";
		this.layoutControlItem3.Location = new System.Drawing.Point(29, 84);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(75, 28);
		this.layoutControlItem3.Text = "ET";
		this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(12, 13);
		this.layoutControlItem3.TextToControlDistance = 5;
		this.layoutControlItem17.Control = this.chkHoP;
		this.layoutControlItem17.CustomizationFormText = "layoutControlItem17";
		this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem17.Name = "layoutControlItem17";
		this.layoutControlItem17.Size = new System.Drawing.Size(29, 28);
		this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem17.TextVisible = false;
		this.layoutControlItem18.Control = this.chkBOT;
		this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
		this.layoutControlItem18.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem18.Name = "layoutControlItem18";
		this.layoutControlItem18.Size = new System.Drawing.Size(29, 28);
		this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem18.TextVisible = false;
		this.layoutControlItem20.Control = this.chkMOT;
		this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
		this.layoutControlItem20.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem20.Name = "layoutControlItem20";
		this.layoutControlItem20.Size = new System.Drawing.Size(29, 28);
		this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem20.TextVisible = false;
		this.layoutControlItem19.Control = this.chkEOT;
		this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
		this.layoutControlItem19.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem19.Name = "layoutControlItem19";
		this.layoutControlItem19.Size = new System.Drawing.Size(29, 28);
		this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem19.TextVisible = false;
		this.layoutControlItem13.Control = this.dtBegins;
		this.layoutControlItem13.CustomizationFormText = "Next Term Begins on:";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 136);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(234, 28);
		this.layoutControlItem13.Text = "Next Term Begins on";
		this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem13.TextSize = new System.Drawing.Size(99, 13);
		this.layoutControlItem10.Control = this.txthHoP;
		this.layoutControlItem10.Location = new System.Drawing.Point(104, 0);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(130, 28);
		this.layoutControlItem10.Text = "Output text";
		this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem10.TextSize = new System.Drawing.Size(57, 13);
		this.layoutControlItem10.TextToControlDistance = 5;
		this.layoutControlItem14.Control = this.txthBOT;
		this.layoutControlItem14.Location = new System.Drawing.Point(104, 28);
		this.layoutControlItem14.Name = "layoutControlItem14";
		this.layoutControlItem14.Size = new System.Drawing.Size(130, 28);
		this.layoutControlItem14.Text = "Output text";
		this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem14.TextSize = new System.Drawing.Size(57, 13);
		this.layoutControlItem14.TextToControlDistance = 5;
		this.layoutControlItem16.Control = this.txthMOT;
		this.layoutControlItem16.Location = new System.Drawing.Point(104, 56);
		this.layoutControlItem16.Name = "layoutControlItem16";
		this.layoutControlItem16.Size = new System.Drawing.Size(130, 28);
		this.layoutControlItem16.Text = "Output text";
		this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem16.TextSize = new System.Drawing.Size(57, 13);
		this.layoutControlItem16.TextToControlDistance = 5;
		this.layoutControlItem21.Control = this.txthEOT;
		this.layoutControlItem21.Location = new System.Drawing.Point(104, 84);
		this.layoutControlItem21.Name = "layoutControlItem21";
		this.layoutControlItem21.Size = new System.Drawing.Size(130, 28);
		this.layoutControlItem21.Text = "Output text";
		this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem21.TextSize = new System.Drawing.Size(57, 13);
		this.layoutControlItem21.TextToControlDistance = 5;
		this.layoutControlItem22.Control = this.dtEndsOn;
		this.layoutControlItem22.Location = new System.Drawing.Point(0, 164);
		this.layoutControlItem22.Name = "layoutControlItem22";
		this.layoutControlItem22.Size = new System.Drawing.Size(234, 28);
		this.layoutControlItem22.Text = "Next Term Ends On";
		this.layoutControlItem22.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem22.TextSize = new System.Drawing.Size(99, 13);
		this.layoutControlItem8.Control = this.chkProcessAs;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(240, 28);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.memoEdit1;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(240, 63);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem6.Control = this.gridControl1;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(240, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(364, 422);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem11.Control = this.cboClass;
		this.layoutControlItem11.CustomizationFormText = "Class";
		this.layoutControlItem11.Location = new System.Drawing.Point(119, 115);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(121, 44);
		this.layoutControlItem11.Text = "Class";
		this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem11.TextSize = new System.Drawing.Size(99, 13);
		this.layoutControlItem15.Control = this.txtReportHeader;
		this.layoutControlItem15.CustomizationFormText = "Report Header";
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 159);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(240, 44);
		this.layoutControlItem15.Text = "Report Header";
		this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem15.TextSize = new System.Drawing.Size(99, 13);
		this.layoutControlItem12.Control = this.txtTerm;
		this.layoutControlItem12.CustomizationFormText = "Semester";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 115);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(119, 44);
		this.layoutControlItem12.Text = "Term";
		this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem12.TextSize = new System.Drawing.Size(99, 13);
		this.layoutNotPerc.Control = this.checkEdit1;
		this.layoutNotPerc.Location = new System.Drawing.Point(0, 28);
		this.layoutNotPerc.Name = "layoutNotPerc";
		this.layoutNotPerc.Size = new System.Drawing.Size(240, 24);
		this.layoutNotPerc.TextSize = new System.Drawing.Size(0, 0);
		this.layoutNotPerc.TextVisible = false;
		this.layoutControlItem5.Control = this.simpleButton1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 422);
		this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 27);
		this.layoutControlItem5.MinSize = new System.Drawing.Size(86, 27);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(286, 27);
		this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextToControlDistance = 0;
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlItem7.Control = this.simpleButton2;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(286, 422);
		this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 27);
		this.layoutControlItem7.MinSize = new System.Drawing.Size(43, 27);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(318, 27);
		this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.chkEOTOnly.Location = new System.Drawing.Point(6, 342);
		this.chkEOTOnly.Name = "chkEOTOnly";
		this.chkEOTOnly.Properties.Caption = "Assess EOT Examination only";
		this.chkEOTOnly.Size = new System.Drawing.Size(230, 20);
		this.chkEOTOnly.StyleController = this.layoutControl1;
		this.chkEOTOnly.TabIndex = 41;
		this.layoutControlItem23.Control = this.chkEOTOnly;
		this.layoutControlItem23.Location = new System.Drawing.Point(0, 112);
		this.layoutControlItem23.Name = "layoutControlItem23";
		this.layoutControlItem23.Size = new System.Drawing.Size(234, 24);
		this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem23.TextVisible = false;
		this.layoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(606, 451);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "AssessmentRatioSetup";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Term Settings";
		base.Load += new System.EventHandler(AssessmentRatioSetup_Load);
		((System.ComponentModel.ISupportInitialize)this.txtHoP.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dtEndsOn.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtEndsOn.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txthEOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txthMOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txthBOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txthHoP.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkProcessAs.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkMOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkEOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkBOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkHoP.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtMOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem22).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutNotPerc).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkEOTOnly.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem23).EndInit();
		base.ResumeLayout(false);
	}
}
