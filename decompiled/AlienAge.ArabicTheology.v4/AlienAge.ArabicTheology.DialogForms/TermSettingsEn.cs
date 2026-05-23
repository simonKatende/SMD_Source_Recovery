using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.ArabicTheology.TheologyHelperClasses;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace AlienAge.ArabicTheology.DialogForms;

public class TermSettingsEn : XtraForm
{
	private ReportViewMode.ReportViewLanguage viewLanguage = default(ReportViewMode.ReportViewLanguage);

	private DataSet ds;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private MemoEdit memoEdit1;

	private CheckEdit chkProcessAs;

	private CheckEdit chkMOT;

	private CheckEdit chkEOT;

	private CheckEdit chkBOT;

	private SimpleButton simpleButton1;

	private TextEdit txtEOT;

	private TextEdit txtMOT;

	private TextEdit txtBOT;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem18;

	private LayoutControlItem layoutControlItem20;

	private LayoutControlItem layoutControlItem19;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private SimpleButton simpleButton2;

	private LayoutControlItem layoutControlItem7;

	private Timer timer1;

	private GridControl gridControl1;

	private LayoutControlItem layoutControlItem6;

	private ComboBoxEdit cboClass;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlItem layoutControlItem11;

	private LayoutControlItem layoutControlItem12;

	private DateEdit dtBegins;

	private LayoutControlItem layoutControlItem13;

	private TextEdit txtReportHeader;

	private LayoutControlItem layoutControlItem15;

	private BandedGridView gridView1;

	private BandedGridColumn gridColumn1;

	private BandedGridColumn gridColumn2;

	private BandedGridColumn gridColumn3;

	private BandedGridColumn gridColumn4;

	private BandedGridColumn gridColumn5;

	private BandedGridColumn gridColumn6;

	private BandedGridColumn gridColumn7;

	private BandedGridColumn gridColumn8;

	private BandedGridColumn gridColumn9;

	private GridBand gridBand1;

	private GridBand gridBand2;

	private GridBand gridBand3;

	private TextEdit txtReportHeaderAr;

	private LayoutControlItem layoutControlItem1;

	private TextEdit txtTerm;

	public TermSettingsEn()
	{
		InitializeComponent();
		txtTerm.Text = WorkingSemesters.GetWorkingSemester();
		layoutControlItem18.Visibility = LayoutVisibility.Never;
		layoutControlItem20.Visibility = LayoutVisibility.Never;
		layoutControlItem19.Visibility = LayoutVisibility.Never;
		txtBOT.Properties.ReadOnly = false;
		txtMOT.Properties.ReadOnly = false;
		txtEOT.Properties.ReadOnly = false;
		layoutControlGroup2.Text = "Set ratios";
		txtBOT.Text = TheologyRatios.BOT.ToString();
		txtMOT.Text = TheologyRatios.MOT.ToString();
		txtEOT.Text = TheologyRatios.EOT.ToString();
		memoEdit1.Text = "Reports will be processed and sets output as per assigned ratios";
	}

	private void AddNewSettings()
	{
		try
		{
			double result = (double.TryParse(txtBOT.Text, out result) ? result : 0.0);
			double result2 = (double.TryParse(txtMOT.Text, out result2) ? result2 : 0.0);
			double result3 = (double.TryParse(txtEOT.Text, out result3) ? result3 : 0.0);
			TermSettings.SetTermSettingsEn(cboClass.SelectedItem.ToString(), txtTerm.Text, result, result2, result3, Convert.ToBoolean(chkProcessAs.EditValue), dtBegins.DateTime, txtReportHeader.Text.ToUpper(), txtReportHeaderAr.Text, SelectedSets());
			LoadSetValues();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void ChangeExistingSettings()
	{
		double result = (double.TryParse(txtBOT.Text, out result) ? result : 0.0);
		double result2 = (double.TryParse(txtMOT.Text, out result2) ? result2 : 0.0);
		double result3 = (double.TryParse(txtEOT.Text, out result3) ? result3 : 0.0);
		bool pROCESSASPER = Convert.ToBoolean(chkProcessAs.EditValue);
		string empty = string.Empty;
		using ProcessProgressEn processProgressEn = new ProcessProgressEn(ClassLevel: cboClass.SelectedItem.ToString().Contains("Shu`ba") ? "Shuuba" : (cboClass.SelectedItem.ToString().Contains("Idaad") ? "Idaad" : ((!cboClass.SelectedItem.ToString().Contains("Thanawi")) ? "Shuuba" : "Thanawi")), BOT: result, MOT: result2, EOT: result3, PROCESSASPER: pROCESSASPER, DTBEGINS: dtBegins.DateTime, REPORTHEADER: txtReportHeader.Text.ToUpper(), REPORTHEADERAr: txtReportHeaderAr.Text, SELECTEDSETS: SelectedSets(), STUDENTCLASS: cboClass.SelectedItem.ToString(), SEMESTER: txtTerm.Text);
		processProgressEn.Text = $"Re-grading {cboClass.SelectedItem} students. Please wait...";
		if (processProgressEn.ShowDialog() == DialogResult.OK)
		{
			LoadSetValues();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		if (simpleButton1.Text == "Add Settings")
		{
			double result = (double.TryParse(txtBOT.Text, out result) ? result : 0.0);
			double result2 = (double.TryParse(txtMOT.Text, out result2) ? result2 : 0.0);
			double result3 = (double.TryParse(txtEOT.Text, out result3) ? result3 : 0.0);
			TermSettings.SetTermSettingsEn(cboClass.SelectedItem.ToString(), txtTerm.Text, result, result2, result3, Convert.ToBoolean(chkProcessAs.EditValue), dtBegins.DateTime, txtReportHeader.Text.ToUpper(), txtReportHeaderAr.Text, SelectedSets());
			LoadSetValues();
			simpleButton1.Text = "Change Settings";
		}
		else
		{
			if (!(simpleButton1.Text == "Change Settings"))
			{
				return;
			}
			DialogResult dialogResult = XtraMessageBox.Show("You are about to change your sets configuration.\nThe system will automatically re-grade students basing on the selected settings.\n Click Yes if you wish to continue.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			double result4 = (double.TryParse(txtBOT.Text, out result4) ? result4 : 0.0);
			double result5 = (double.TryParse(txtMOT.Text, out result5) ? result5 : 0.0);
			double result6 = (double.TryParse(txtEOT.Text, out result6) ? result6 : 0.0);
			bool pROCESSASPER = Convert.ToBoolean(chkProcessAs.EditValue);
			string classLevel = string.Empty;
			if (cboClass.SelectedItem.ToString().Contains("Shu`ba"))
			{
				classLevel = "Shuuba";
			}
			else if (cboClass.SelectedItem.ToString().Contains("Idaad"))
			{
				classLevel = "Idaad";
			}
			else if (cboClass.SelectedItem.ToString().Contains("Thanawi"))
			{
				classLevel = "Thanawi";
			}
			using ProcessProgressEn processProgressEn = new ProcessProgressEn(result4, result5, result6, pROCESSASPER, dtBegins.DateTime, txtReportHeader.Text.ToUpper(), txtReportHeaderAr.Text, SelectedSets(), cboClass.SelectedItem.ToString(), txtTerm.Text, classLevel);
			processProgressEn.Text = $"Re-grading {cboClass.SelectedItem} students. Please wait...";
			if (processProgressEn.ShowDialog() == DialogResult.OK)
			{
				LoadSetValues();
			}
		}
	}

	private void chkProcessAs_CheckedChanged(object sender, EventArgs e)
	{
		if (chkProcessAs.Checked)
		{
			layoutControlItem18.Visibility = LayoutVisibility.Always;
			layoutControlItem20.Visibility = LayoutVisibility.Always;
			layoutControlItem19.Visibility = LayoutVisibility.Always;
			txtBOT.Properties.ReadOnly = true;
			txtMOT.Properties.ReadOnly = true;
			txtEOT.Properties.ReadOnly = true;
			txtBOT.Text = "0";
			txtMOT.Text = "0";
			txtEOT.Text = "0";
			layoutControlGroup2.Text = "Select sets";
			memoEdit1.Text = "All sets selected will contribute equally to the Final Mark";
		}
		else
		{
			layoutControlItem18.Visibility = LayoutVisibility.Never;
			layoutControlItem20.Visibility = LayoutVisibility.Never;
			layoutControlItem19.Visibility = LayoutVisibility.Never;
			txtBOT.Properties.ReadOnly = false;
			txtMOT.Properties.ReadOnly = false;
			txtEOT.Properties.ReadOnly = false;
			layoutControlGroup2.Text = "Set ratios";
			txtBOT.Text = TheologyRatios.BOT.ToString();
			txtMOT.Text = TheologyRatios.MOT.ToString();
			txtEOT.Text = TheologyRatios.EOT.ToString();
			memoEdit1.Text = "Reports will be processed and sets output as per assigned ratios";
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
		double result = (double.TryParse(txtBOT.Text, out result) ? result : 0.0);
		double result2 = (double.TryParse(txtMOT.Text, out result2) ? result2 : 0.0);
		double result3 = (double.TryParse(txtEOT.Text, out result3) ? result3 : 0.0);
		double num = result + result2 + result3;
		if (chkProcessAs.Checked)
		{
			if (num > 0.0 && dtBegins.EditValue != null && txtReportHeader.Text != "")
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
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE SemesterId='{WorkingSemesters.GetWorkingSemester()}' Order By SemesterId,ClassIdEn", DataConnection.ConnectToDatabase()))
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
		if (txtBOT.Text != "0" && txtMOT.Text != "0" && txtEOT.Text != "0")
		{
			result = "BME";
		}
		else if (txtBOT.Text != "0" && txtMOT.Text != "0" && txtEOT.Text == "0")
		{
			result = "BM";
		}
		else if (txtBOT.Text != "0" && txtEOT.Text != "0" && txtMOT.Text == "0")
		{
			result = "BE";
		}
		else if (txtMOT.Text != "0" && txtEOT.Text != "0" && txtBOT.Text == "0")
		{
			result = "ME";
		}
		else if (txtBOT.Text != "0" && txtEOT.Text == "0" && txtMOT.Text == "0")
		{
			result = "B";
		}
		else if (txtMOT.Text != "0" && txtEOT.Text == "0" && txtBOT.Text == "0")
		{
			result = "M";
		}
		else if (txtEOT.Text != "0" && txtBOT.Text == "0" && txtMOT.Text == "0")
		{
			result = "E";
		}
		else
		{
			XtraMessageBox.Show("The selected Sets Configuration is not valid. Valid Configurations are:\n BME or BM or BE or ME or B or M or E", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		return result;
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

	private void cboSemester_EditValueChanged(object sender, EventArgs e)
	{
		simpleButton1.Text = "Add Settings";
	}

	private void cboClass_Closed(object sender, ClosedEventArgs e)
	{
		try
		{
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				if (gridView1.GetRowCellValue(i, "ClassIdEn").ToString() == cboClass.SelectedItem.ToString())
				{
					gridView1.FocusedRowHandle = i;
					simpleButton1.Text = "Change Settings";
					break;
				}
				simpleButton1.Text = "Add Settings";
			}
		}
		catch (Exception)
		{
		}
	}

	private void cboClass_QueryPopUp(object sender, CancelEventArgs e)
	{
		simpleButton1.Text = "Add Settings";
	}

	private void gridView1_DoubleClick(object sender, EventArgs e)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			if (Convert.ToBoolean(gridView1.GetRowCellValue(gridView1.GetFocusedDataSourceRowIndex(), "IsPercentage")))
			{
				layoutControlItem18.Visibility = LayoutVisibility.Always;
				layoutControlItem20.Visibility = LayoutVisibility.Always;
				layoutControlItem19.Visibility = LayoutVisibility.Always;
			}
			DataRow dataRow = ds.Tables[0].Rows[gridView1.GetFocusedDataSourceRowIndex()];
			chkProcessAs.Checked = Convert.ToBoolean(dataRow["IsPercentage"]);
			cboClass.SelectedItem = dataRow["ClassIdEn"].ToString();
			txtTerm.Text = dataRow["SemesterId"].ToString();
			txtBOT.Text = dataRow["BOT"].ToString();
			txtEOT.Text = dataRow["EOT"].ToString();
			txtMOT.Text = dataRow["MOT"].ToString();
			txtReportHeader.Text = dataRow["ReportHeader"].ToString();
			DateTime result = (DateTime.TryParse(dataRow["TermEndsOn"].ToString(), out result) ? result : DateTime.Now);
			DateTime result2 = (DateTime.TryParse(dataRow["TermBeginsOn"].ToString(), out result2) ? result2 : DateTime.Now);
			dtBegins.DateTime = result2;
			simpleButton1.Text = "Change Settings";
		}
	}

	private void AssessmentRatioSetup_Load(object sender, EventArgs e)
	{
		Classes classes = new Classes();
		classes.PopulateAllClassesToComboEn(new ComboBoxEdit[1] { cboClass });
		LoadSetValues();
	}

	private bool IsSemesterSet(string ClassIdEn, string SemesterId)
	{
		bool result = false;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{ClassIdEn}' AND SemesterId='{SemesterId}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			result = true;
		}
		return result;
	}

	private void LoadClassSettings(string ClassId, string TermId)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{ClassId}' AND SemesterId='{TermId}'", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				chkProcessAs.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsPercentage"]);
				cboClass.SelectedItem = dataTable.Rows[0]["ClassIdEn"].ToString();
				txtTerm.Text = dataTable.Rows[0]["SemesterId"].ToString();
				txtBOT.Text = dataTable.Rows[0]["BOTEn"].ToString();
				txtEOT.Text = dataTable.Rows[0]["EOTEn"].ToString();
				txtMOT.Text = dataTable.Rows[0]["MOTEn"].ToString();
				txtReportHeader.Text = dataTable.Rows[0]["ReportHeaderEn"].ToString();
				txtReportHeaderAr.Text = dataTable.Rows[0]["ReportHeaderAr"].ToString();
				DateTime result = (DateTime.TryParse(dataTable.Rows[0]["TermBeginsOnEn"].ToString(), out result) ? result : DateTime.Now);
				dtBegins.DateTime = result;
			}
		}
	}

	private void LoadClassSettings(string ClassId, string TermId, int ProcessType)
	{
		if (gridView1.GetFocusedDataSourceRowIndex() > -1)
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{ClassId}' AND SemesterId='{TermId}' AND IsPercentage={ProcessType}", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				chkProcessAs.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsPercentage"]);
				cboClass.SelectedItem = dataTable.Rows[0]["ClassIdEn"].ToString();
				txtTerm.Text = dataTable.Rows[0]["SemesterId"].ToString();
				txtBOT.Text = dataTable.Rows[0]["BOTEn"].ToString();
				txtEOT.Text = dataTable.Rows[0]["EOTEn"].ToString();
				txtMOT.Text = dataTable.Rows[0]["MOTEn"].ToString();
				txtReportHeader.Text = dataTable.Rows[0]["ReportHeaderAr"].ToString();
				txtReportHeaderAr.Text = dataTable.Rows[0]["ReportHeaderEn"].ToString();
				DateTime result = (DateTime.TryParse(dataTable.Rows[0]["TermBeginsOnEn"].ToString(), out result) ? result : DateTime.Now);
				dtBegins.DateTime = result;
			}
		}
	}

	private void cboClass_EditValueChanged(object sender, EventArgs e)
	{
		if (IsSemesterSet(cboClass.SelectedItem.ToString(), txtTerm.Text))
		{
			LoadClassSettings(cboClass.SelectedItem.ToString(), txtTerm.Text);
			simpleButton1.Text = "Change Settings";
		}
		else
		{
			simpleButton1.Text = "Add Settings";
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
		this.txtReportHeaderAr = new DevExpress.XtraEditors.TextEdit();
		this.txtReportHeader = new DevExpress.XtraEditors.TextEdit();
		this.dtBegins = new DevExpress.XtraEditors.DateEdit();
		this.cboClass = new DevExpress.XtraEditors.ComboBoxEdit();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
		this.chkProcessAs = new DevExpress.XtraEditors.CheckEdit();
		this.chkMOT = new DevExpress.XtraEditors.CheckEdit();
		this.chkEOT = new DevExpress.XtraEditors.CheckEdit();
		this.chkBOT = new DevExpress.XtraEditors.CheckEdit();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtEOT = new DevExpress.XtraEditors.TextEdit();
		this.txtMOT = new DevExpress.XtraEditors.TextEdit();
		this.txtBOT = new DevExpress.XtraEditors.TextEdit();
		this.txtTerm = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeaderAr.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkProcessAs.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkMOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkEOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkBOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtEOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtMOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtBOT.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtTerm.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.txtReportHeaderAr);
		this.layoutControl1.Controls.Add(this.txtReportHeader);
		this.layoutControl1.Controls.Add(this.dtBegins);
		this.layoutControl1.Controls.Add(this.cboClass);
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.memoEdit1);
		this.layoutControl1.Controls.Add(this.chkProcessAs);
		this.layoutControl1.Controls.Add(this.chkMOT);
		this.layoutControl1.Controls.Add(this.chkEOT);
		this.layoutControl1.Controls.Add(this.chkBOT);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtEOT);
		this.layoutControl1.Controls.Add(this.txtMOT);
		this.layoutControl1.Controls.Add(this.txtBOT);
		this.layoutControl1.Controls.Add(this.txtTerm);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(524, 115, 527, 518);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(670, 450);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.txtReportHeaderAr.Location = new System.Drawing.Point(3, 239);
		this.txtReportHeaderAr.Name = "txtReportHeaderAr";
		this.txtReportHeaderAr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtReportHeaderAr.Properties.Appearance.Options.UseFont = true;
		this.txtReportHeaderAr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReportHeaderAr.Properties.MaxLength = 50;
		this.txtReportHeaderAr.Size = new System.Drawing.Size(235, 24);
		this.txtReportHeaderAr.StyleController = this.layoutControl1;
		this.txtReportHeaderAr.TabIndex = 35;
		this.txtReportHeader.Location = new System.Drawing.Point(3, 194);
		this.txtReportHeader.Name = "txtReportHeader";
		this.txtReportHeader.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtReportHeader.Properties.Appearance.Options.UseFont = true;
		this.txtReportHeader.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtReportHeader.Properties.MaxLength = 50;
		this.txtReportHeader.Size = new System.Drawing.Size(235, 24);
		this.txtReportHeader.StyleController = this.layoutControl1;
		this.txtReportHeader.TabIndex = 34;
		this.dtBegins.EditValue = null;
		this.dtBegins.Location = new System.Drawing.Point(6, 394);
		this.dtBegins.Name = "dtBegins";
		this.dtBegins.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
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
		this.dtBegins.Size = new System.Drawing.Size(229, 24);
		this.dtBegins.StyleController = this.layoutControl1;
		this.dtBegins.TabIndex = 32;
		this.cboClass.Location = new System.Drawing.Point(43, 121);
		this.cboClass.Name = "cboClass";
		this.cboClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboClass.Properties.Appearance.Options.UseFont = true;
		this.cboClass.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboClass.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboClass.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboClass.Size = new System.Drawing.Size(195, 24);
		this.cboClass.StyleController = this.layoutControl1;
		this.cboClass.TabIndex = 30;
		this.cboClass.QueryPopUp += new System.ComponentModel.CancelEventHandler(cboClass_QueryPopUp);
		this.cboClass.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboClass_Closed);
		this.cboClass.EditValueChanged += new System.EventHandler(cboClass_EditValueChanged);
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Location = new System.Drawing.Point(242, 425);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(243, 22);
		this.panelControl1.TabIndex = 29;
		this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
		this.gridControl1.Location = new System.Drawing.Point(242, 3);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(425, 418);
		this.gridControl1.TabIndex = 28;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.BandPanel.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
		this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
		this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[3] { this.gridBand1, this.gridBand2, this.gridBand3 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[9] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn8, this.gridColumn9 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupFormat = "{1} {2}";
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridBand1.Caption = "Scale Parameters";
		this.gridBand1.Columns.Add(this.gridColumn1);
		this.gridBand1.Columns.Add(this.gridColumn2);
		this.gridBand1.Columns.Add(this.gridColumn3);
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.VisibleIndex = 0;
		this.gridBand1.Width = 204;
		this.gridColumn1.Caption = "Term";
		this.gridColumn1.FieldName = "SemesterId";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.Width = 67;
		this.gridColumn2.Caption = "Class";
		this.gridColumn2.FieldName = "ClassIdEn";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.Width = 67;
		this.gridColumn3.Caption = "Assess as %";
		this.gridColumn3.FieldName = "IsPercentage";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.Width = 70;
		this.gridBand2.Caption = "Assessment Ratios";
		this.gridBand2.Columns.Add(this.gridColumn4);
		this.gridBand2.Columns.Add(this.gridColumn5);
		this.gridBand2.Columns.Add(this.gridColumn6);
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.VisibleIndex = 1;
		this.gridBand2.Width = 150;
		this.gridColumn4.Caption = "BOT";
		this.gridColumn4.FieldName = "BOTEn";
		this.gridColumn4.MinWidth = 13;
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.Width = 50;
		this.gridColumn5.Caption = "MOT";
		this.gridColumn5.FieldName = "MOTEn";
		this.gridColumn5.MinWidth = 13;
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.Width = 50;
		this.gridColumn6.Caption = "EOT";
		this.gridColumn6.FieldName = "EOTEn";
		this.gridColumn6.MinWidth = 13;
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.Width = 50;
		this.gridBand3.Caption = "Arabic";
		this.gridBand3.Columns.Add(this.gridColumn7);
		this.gridBand3.Columns.Add(this.gridColumn8);
		this.gridBand3.Columns.Add(this.gridColumn9);
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.Visible = false;
		this.gridBand3.VisibleIndex = -1;
		this.gridBand3.Width = 150;
		this.gridColumn7.Caption = "BOT";
		this.gridColumn7.FieldName = "BOTAr";
		this.gridColumn7.MinWidth = 13;
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.Width = 50;
		this.gridColumn8.Caption = "MOT";
		this.gridColumn8.FieldName = "MOTAr";
		this.gridColumn8.MinWidth = 13;
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.Width = 50;
		this.gridColumn9.Caption = "EOT";
		this.gridColumn9.FieldName = "EOTAr";
		this.gridColumn9.MinWidth = 13;
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.Width = 50;
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Location = new System.Drawing.Point(489, 425);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(178, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 27;
		this.simpleButton2.Text = "Close";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.memoEdit1.Location = new System.Drawing.Point(3, 31);
		this.memoEdit1.Name = "memoEdit1";
		this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.memoEdit1.Size = new System.Drawing.Size(235, 86);
		this.memoEdit1.StyleController = this.layoutControl1;
		this.memoEdit1.TabIndex = 26;
		this.chkProcessAs.Location = new System.Drawing.Point(3, 3);
		this.chkProcessAs.Name = "chkProcessAs";
		this.chkProcessAs.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkProcessAs.Properties.Appearance.Options.UseFont = true;
		this.chkProcessAs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkProcessAs.Properties.Caption = "Process reports as Percentages";
		this.chkProcessAs.Size = new System.Drawing.Size(235, 24);
		this.chkProcessAs.StyleController = this.layoutControl1;
		this.chkProcessAs.TabIndex = 16;
		this.chkProcessAs.CheckedChanged += new System.EventHandler(chkProcessAs_CheckedChanged);
		this.chkMOT.Location = new System.Drawing.Point(6, 319);
		this.chkMOT.Name = "chkMOT";
		this.chkMOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkMOT.Properties.Caption = "";
		this.chkMOT.Size = new System.Drawing.Size(24, 24);
		this.chkMOT.StyleController = this.layoutControl1;
		this.chkMOT.TabIndex = 25;
		this.chkMOT.CheckedChanged += new System.EventHandler(chkMOT_CheckedChanged);
		this.chkEOT.Location = new System.Drawing.Point(6, 347);
		this.chkEOT.Name = "chkEOT";
		this.chkEOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkEOT.Properties.Caption = "";
		this.chkEOT.Size = new System.Drawing.Size(24, 24);
		this.chkEOT.StyleController = this.layoutControl1;
		this.chkEOT.TabIndex = 24;
		this.chkEOT.CheckedChanged += new System.EventHandler(chkEOT_CheckedChanged);
		this.chkBOT.Location = new System.Drawing.Point(6, 291);
		this.chkBOT.Name = "chkBOT";
		this.chkBOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.chkBOT.Properties.Caption = "";
		this.chkBOT.Size = new System.Drawing.Size(24, 24);
		this.chkBOT.StyleController = this.layoutControl1;
		this.chkBOT.TabIndex = 23;
		this.chkBOT.CheckedChanged += new System.EventHandler(chkBOT_CheckedChanged);
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(3, 425);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(235, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 9;
		this.simpleButton1.Text = "Add Settings";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtEOT.Location = new System.Drawing.Point(170, 347);
		this.txtEOT.Name = "txtEOT";
		this.txtEOT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtEOT.Properties.Appearance.Options.UseFont = true;
		this.txtEOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtEOT.Properties.Mask.EditMask = "d";
		this.txtEOT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtEOT.Size = new System.Drawing.Size(65, 24);
		this.txtEOT.StyleController = this.layoutControl1;
		this.txtEOT.TabIndex = 8;
		this.txtEOT.TextChanged += new System.EventHandler(txtEOT_TextChanged);
		this.txtMOT.Location = new System.Drawing.Point(170, 319);
		this.txtMOT.Name = "txtMOT";
		this.txtMOT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtMOT.Properties.Appearance.Options.UseFont = true;
		this.txtMOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtMOT.Properties.Mask.EditMask = "d";
		this.txtMOT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtMOT.Size = new System.Drawing.Size(65, 24);
		this.txtMOT.StyleController = this.layoutControl1;
		this.txtMOT.TabIndex = 7;
		this.txtMOT.TextChanged += new System.EventHandler(txtMOT_TextChanged);
		this.txtBOT.Location = new System.Drawing.Point(170, 291);
		this.txtBOT.Name = "txtBOT";
		this.txtBOT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtBOT.Properties.Appearance.Options.UseFont = true;
		this.txtBOT.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtBOT.Properties.Mask.EditMask = "d";
		this.txtBOT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtBOT.Size = new System.Drawing.Size(65, 24);
		this.txtBOT.StyleController = this.layoutControl1;
		this.txtBOT.TabIndex = 5;
		this.txtBOT.TextChanged += new System.EventHandler(txtBOT_TextChanged);
		this.txtTerm.Location = new System.Drawing.Point(44, 149);
		this.txtTerm.Name = "txtTerm";
		this.txtTerm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.txtTerm.Properties.Appearance.Options.UseFont = true;
		this.txtTerm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtTerm.Properties.ReadOnly = true;
		this.txtTerm.Size = new System.Drawing.Size(194, 24);
		this.txtTerm.StyleController = this.layoutControl1;
		this.txtTerm.TabIndex = 31;
		this.txtTerm.EditValueChanged += new System.EventHandler(cboSemester_EditValueChanged);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[11]
		{
			this.layoutControlItem5, this.layoutControlGroup2, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem6, this.layoutControlItem7, this.layoutControlItem10, this.layoutControlItem11, this.layoutControlItem12, this.layoutControlItem15,
			this.layoutControlItem1
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(670, 450);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem5.Control = this.simpleButton1;
		this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 422);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(239, 26);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[7] { this.layoutControlItem2, this.layoutControlItem4, this.layoutControlItem3, this.layoutControlItem18, this.layoutControlItem20, this.layoutControlItem19, this.layoutControlItem13 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(0, 264);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup2.Size = new System.Drawing.Size(239, 158);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtBOT;
		this.layoutControlItem2.CustomizationFormText = "BOT:";
		this.layoutControlItem2.Location = new System.Drawing.Point(28, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(205, 28);
		this.layoutControlItem2.Text = "BOT";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(124, 16);
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.txtMOT;
		this.layoutControlItem4.CustomizationFormText = "MOT:";
		this.layoutControlItem4.Location = new System.Drawing.Point(28, 28);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(205, 28);
		this.layoutControlItem4.Text = "MOT";
		this.layoutControlItem4.TextSize = new System.Drawing.Size(124, 16);
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtEOT;
		this.layoutControlItem3.CustomizationFormText = "EOT:";
		this.layoutControlItem3.Location = new System.Drawing.Point(28, 56);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(205, 28);
		this.layoutControlItem3.Text = "EOT";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(124, 16);
		this.layoutControlItem18.Control = this.chkBOT;
		this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
		this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem18.Name = "layoutControlItem18";
		this.layoutControlItem18.Size = new System.Drawing.Size(28, 28);
		this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem18.TextVisible = false;
		this.layoutControlItem20.Control = this.chkMOT;
		this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
		this.layoutControlItem20.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem20.Name = "layoutControlItem20";
		this.layoutControlItem20.Size = new System.Drawing.Size(28, 28);
		this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem20.TextVisible = false;
		this.layoutControlItem19.Control = this.chkEOT;
		this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
		this.layoutControlItem19.Location = new System.Drawing.Point(0, 56);
		this.layoutControlItem19.Name = "layoutControlItem19";
		this.layoutControlItem19.Size = new System.Drawing.Size(28, 28);
		this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem19.TextVisible = false;
		this.layoutControlItem13.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem13.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem13.Control = this.dtBegins;
		this.layoutControlItem13.CustomizationFormText = "Next Term Begins on:";
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 84);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(233, 47);
		this.layoutControlItem13.Text = "Next Term Begins on:";
		this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem13.TextSize = new System.Drawing.Size(124, 16);
		this.layoutControlItem8.Control = this.chkProcessAs;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(239, 28);
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem9.Control = this.memoEdit1;
		this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(239, 90);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem6.Control = this.gridControl1;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(239, 0);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(429, 422);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem7.Control = this.simpleButton2;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(486, 422);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(182, 26);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem10.Control = this.panelControl1;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(239, 422);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(247, 26);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem11.Control = this.cboClass;
		this.layoutControlItem11.CustomizationFormText = "Class:";
		this.layoutControlItem11.Location = new System.Drawing.Point(0, 118);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(239, 28);
		this.layoutControlItem11.Text = "Class:";
		this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem11.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem11.TextSize = new System.Drawing.Size(35, 16);
		this.layoutControlItem11.TextToControlDistance = 5;
		this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem12.Control = this.txtTerm;
		this.layoutControlItem12.CustomizationFormText = "Semester";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 146);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(239, 28);
		this.layoutControlItem12.Text = "Term:";
		this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
		this.layoutControlItem12.TextLocation = DevExpress.Utils.Locations.Left;
		this.layoutControlItem12.TextSize = new System.Drawing.Size(36, 16);
		this.layoutControlItem12.TextToControlDistance = 5;
		this.layoutControlItem15.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem15.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem15.Control = this.txtReportHeader;
		this.layoutControlItem15.CustomizationFormText = "Report Header";
		this.layoutControlItem15.Location = new System.Drawing.Point(0, 174);
		this.layoutControlItem15.Name = "layoutControlItem15";
		this.layoutControlItem15.Size = new System.Drawing.Size(239, 45);
		this.layoutControlItem15.Text = "Report Header (En)";
		this.layoutControlItem15.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem15.TextSize = new System.Drawing.Size(124, 14);
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.txtReportHeaderAr;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 219);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(239, 45);
		this.layoutControlItem1.Text = "Report Header (Ar)";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(124, 14);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(670, 450);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "TermSettingsEn";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Term Settings";
		base.Load += new System.EventHandler(AssessmentRatioSetup_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtReportHeaderAr.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtReportHeader.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtBegins.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.memoEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkProcessAs.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkMOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkEOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkBOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtEOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtMOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtBOT.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtTerm.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
