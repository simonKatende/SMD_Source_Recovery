using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrPeformanceSheetNC : XtraUserControl
{
	private string _class = string.Empty;

	private string _term = string.Empty;

	private int scopeIndex = 0;

	private string subHeader = string.Empty;

	private IContainer components = null;

	private BarStaticItem lblCurrentUser;

	private BarStaticItem lblWorkStation;

	private BarStaticItem lblAccountAction;

	public BarStaticItem lblWorkingSemester;

	private BarStaticItem lblTime;

	private BarStaticItem lblMarkType;

	private BarStaticItem lblSelectedClass;

	private RibbonPage ribbonWelcome;

	private RibbonPageGroup ribbonPageGroup44;

	private RibbonGalleryBarItem ribbonGalleryBarItem2;

	private RibbonPageGroup ribbonPageGroup37;

	private BarButtonItem barButtonItem169;

	private BarButtonItem barButtonItem172;

	private BarButtonItem barButtonItem173;

	private BarButtonItem barButtonItem174;

	private RibbonPage ribbonStudents;

	private RibbonPageGroup ribbonPageGroup22;

	private BarButtonItem barButtonItem16;

	private BarButtonItem barButtonItem133;

	private BarButtonItem barButtonItem134;

	private BarButtonItem barButtonItem17;

	private BarButtonItem barButtonItem213;

	private BarButtonItem barButtonItem205;

	private RibbonPageGroup ribbonPageGroup1;

	private BarButtonItem barButtonItem93;

	private BarButtonItem barButtonItem94;

	private RibbonPageGroup ribbonPageGroup40;

	private BarButtonItem barButtonItem142;

	private RibbonPageGroup ribbonPageGroup18;

	private BarButtonItem barButtonItem18;

	private BarButtonItem barButtonItem19;

	private BarButtonItem barButtonItem20;

	private RibbonPage ribbonEmployees;

	private RibbonPageGroup ribbonPageGroup16;

	private BarButtonItem barButtonAGS;

	private BarButtonItem barButtonItem22;

	private BarButtonItem barButtonItem182;

	private BarButtonItem barButtonItem185;

	private BarButtonItem barButtonItem189;

	private RibbonPageGroup ribbonPageGroup35;

	private BarButtonItem barButtonItem124;

	private BarButtonItem barButtonItem125;

	private RibbonPageGroup ribbonPageGroup36;

	private BarButtonItem barButtonItem42;

	private BarButtonItem barButtonItem83;

	private RibbonPageGroup ribbonPageGroup9;

	private BarButtonItem barButtonItem73;

	private BarButtonItem barButtonItem74;

	private BarButtonItem barButtonItem177;

	private RibbonPage ribbonSuppliers;

	private RibbonPageGroup ribbonPageGroup25;

	private BarButtonItem barButtonItem33;

	private BarButtonItem barButtonItem180;

	private BarButtonItem barButtonItem181;

	private BarButtonItem barButtonItem187;

	private BarButtonItem barButtonItem32;

	private RibbonPageGroup ribbonPageGroup45;

	private BarButtonItem barButtonItem43;

	private BarButtonItem barButtonItem186;

	private RibbonPageGroup ribbonPageGroup6;

	private BarButtonItem barButtonAddDeliveries;

	private BarButtonItem barButtonItem31;

	private BarButtonItem barButtonItem101;

	private BarButtonItem barButtonItem21;

	private RibbonPageGroup ribbonPageGroup26;

	private BarButtonItem barButtonItem75;

	private BarButtonItem barButtonItem76;

	private BarButtonItem barButtonItem178;

	private RibbonPageGroup ribbonPageGroup21;

	private RibbonPage ribbonAcademics;

	private RibbonPageGroup ribbonPageGroup13;

	private BarButtonItem barBtnSelectSubjects;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem188;

	private RibbonPageGroup ribbonPageGroup14;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem4;

	private RibbonPageGroup ribbonPageGroup15;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem10;

	private BarButtonItem barButtonItem13;

	private BarButtonItem barButtonItem15;

	private BarButtonItem barButtonItem14;

	private RibbonPageGroup ribbonPageGroup17;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem6;

	private RibbonPageGroup ribbonPageGroup34;

	private BarButtonItem barButtonItem67;

	private RibbonPageGroup ribbonPageGroup48;

	private BarButtonItem barButtonItem214;

	private RibbonPageGroup ribbonPageGroup47;

	private BarButtonItem barButtonItem212;

	private RibbonPage ribbonAccounts;

	private RibbonPageGroup ribbonPageGroup3;

	private BarButtonItem barButtonItem23;

	private BarButtonItem barButtonItem154;

	private BarButtonItem barButtonItem153;

	private RibbonPageGroup ribbonPageGroup7;

	private BarButtonItem barButtonItem25;

	private BarButtonItem barButtonItem159;

	private BarButtonItem barButtonItem160;

	private RibbonPageGroup ribbonPageGroup4;

	private BarButtonItem barButtonItem27;

	private BarButtonItem barButtonItem28;

	private BarButtonItem barButtonItem29;

	private BarButtonItem barButtonItem35;

	private RibbonPageGroup ribbonPageGroup5;

	private BarButtonItem barButtonItem24;

	private BarButtonItem barButtonItem37;

	private BarButtonItem barButtonItem36;

	private RibbonPageGroup ribbonPageGroup8;

	private BarButtonItem barButtonItem26;

	private BarButtonItem barButtonItem39;

	private BarButtonItem barButtonItem99;

	private BarButtonItem barButtonItem34;

	private RibbonPageGroup ribbonPageGroup27;

	private BarButtonItem barButtonItem38;

	private BarButtonItem barButtonItem57;

	private BarButtonItem barButtonItem58;

	private RibbonPageGroup ribbonPageGroup46;

	private BarButtonItem barButtonItem194;

	private BarButtonItem barButtonItem195;

	private BarButtonItem barButtonItem206;

	private BarEditItem barEditItem1;

	private BarEditItem barEditItem2;

	private BarEditItem barEditItem3;

	private BarButtonItem barButtonItem44;

	private BarButtonItem barButtonItem45;

	private BarButtonItem barButtonItem46;

	private BarButtonItem barButtonItem47;

	private BarButtonItem barButtonItem48;

	private BarButtonItem barButtonItem49;

	private BarButtonItem barButtonItem50;

	private BarButtonItem barButtonItem51;

	private BarButtonItem barButtonItem54;

	private BarButtonItem barButtonItem62;

	private BarButtonItem barButtonItem63;

	private RibbonGalleryBarItem ribbonGalleryBarItem1;

	private BarButtonItem barButtonGS;

	private BarButtonItem barButtonItemDS;

	private BarButtonItem barButtonItem64;

	private BarButtonItem barButtonPB;

	private BarEditItem lookUpOrders;

	private BarButtonItem barButtonAllSets;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem40;

	private PrintPreviewStaticItem printPreviewStaticItem1;

	private BarStaticItem barStaticItem1;

	private BarButtonItem barButtonItem55;

	private PrintPreviewStaticItem printPreviewStaticItem2;

	private BarButtonItem barButtonItem56;

	private BarButtonItem barButtonItem59;

	private BarStaticItem barStaticItem2;

	private BarButtonItem barButtonItem60;

	private BarButtonItem barButtonItem41;

	private BarButtonItem barButtonItem61;

	private BarButtonItem barButtonItem65;

	private BarStaticItem barStaticItem3;

	private BarButtonItem barButtonItem66;

	private BarButtonItem barButtonItem68;

	private BarButtonItem barButtonItem69;

	private BarButtonItem barButtonItem70;

	private BarButtonItem barButtonItemPrintIE;

	private BarButtonItem barButtonItem71;

	private BarButtonItem barButtonItem72;

	private BarButtonItem barButtonItem77;

	private BarButtonItem barButtonItem78;

	private BarButtonItem barButtonItem79;

	private BarButtonItem barButtonItem80;

	private BarButtonItem barButtonItem81;

	private BarEditItem barEditItem7;

	private BarButtonItem barButtonItem82;

	private BarEditItem cboSemesterBudget;

	private BarEditItem cboBudgetAnnual;

	private BarButtonItem barButtonItem84;

	private BarButtonItem barButtonItem85;

	private BarButtonItem barButtonItem86;

	private BarButtonItem barButtonItem87;

	private BarButtonItem barButtonItem88;

	private BarButtonItem barButtonItem89;

	private BarButtonItem barButtonItem91;

	private BarLinkContainerItem barLinkContainerItem1;

	private BarListItem barListItem1;

	private BarSubItem barSubItem1;

	private BarListItem barListItem2;

	private BarListItem barListItem3;

	private BarButtonItem barButtonItem95;

	private BarButtonItem barButtonItem96;

	private BarButtonItem barButtonItem97;

	private BarButtonItem barButtonItem98;

	private BarButtonItem barButtonItem100;

	private BarButtonItem barButtonItem103;

	private BarButtonItem barButtonItem104;

	private BarButtonItem barButtonItem105;

	private BarButtonItem barButtonItem106;

	private BarButtonItem barButtonItem107;

	private BarButtonItem barButtonItem108;

	private BarButtonItem barButtonItem109;

	private BarButtonItem barButtonItem110;

	private BarButtonItem barButtonItem111;

	private BarButtonItem barButtonItem112;

	private BarButtonItem barButtonItem113;

	private BarButtonItem barButtonItem114;

	private BarButtonItem barButtonItem115;

	private BarButtonItem barButtonItem116;

	private BarButtonItem barButtonItem117;

	private BarButtonItem barButtonItem118;

	private BarButtonItem barButtonItem119;

	private BarEditItem barEditItem6;

	private BarButtonItem barButtonItem90;

	private BarButtonItem barButtonItem92;

	private BarSubItem barSubItem2;

	private BarButtonItem barButtonItem102;

	private BarButtonItem barButtonItem120;

	private BarButtonItem barButtonItem121;

	private BarButtonItem barButtonItem122;

	private BarButtonItem barButtonItem123;

	private BarButtonItem barButtonItem126;

	private BarStaticItem barStaticItem4;

	private BarStaticItem barStaticItem5;

	private BarStaticItem barStaticItem6;

	private BarButtonItem barButtonItem127;

	private BarButtonItem barButtonItem128;

	private BarButtonItem barButtonItem129;

	private BarButtonItem barButtonItem130;

	private BarButtonItem barButtonItem131;

	private BarButtonItem barButtonItem132;

	private BarButtonItem barButtonItem136;

	private BarButtonItem barButtonItem137;

	private BarButtonItem barButtonItem138;

	private BarButtonItem barButtonItem139;

	private BarButtonItem barButtonItem140;

	private BarButtonItem barButtonItem141;

	private BarButtonItem barButtonItem143;

	private BarButtonItem barButtonItem144;

	private BarButtonItem barButtonItem145;

	private BarButtonItem barButtonItem146;

	private BarButtonItem barButtonItem147;

	private BarButtonItem barButtonItem148;

	private BarButtonItem barButtonItem149;

	private BarButtonItem barButtonItem52;

	private BarButtonItem barButtonItem53;

	private BarEditItem barEditItem8;

	private BarEditItem barEditItem9;

	private BarButtonItem barButtonItem150;

	private BarEditItem barEditItem10;

	private BarEditItem barEditItem11;

	private BarButtonItem barButtonItem151;

	private BarEditItem barCBOSemester;

	private BarEditItem barCBOSemesterIncome;

	private BarButtonItem barButtonItem152;

	private BarButtonItem barButtonItem155;

	private BarButtonItem barButtonItem156;

	private BarButtonItem barButtonItem157;

	private BarButtonItem barButtonItem135;

	private BarButtonItem barButtonItem158;

	private BarButtonItem barButtonItem161;

	private BarButtonItem barButtonItem162;

	private BarButtonItem barButtonItem163;

	private BarButtonItem barButtonItem164;

	private BarButtonItem barButtonItem165;

	private BarButtonItem barButtonItem166;

	private BarButtonItem barButtonItem167;

	private BarButtonItem barButtonItem168;

	private BarEditItem barEditItem12;

	private BarButtonItem barButtonItem170;

	private BarButtonItem barButtonItem171;

	private BarButtonItem barButtonItem175;

	private BarButtonItem barButtonItem176;

	private BarButtonItem barButtonItem179;

	private BarButtonItem barButtonItem183;

	private BarButtonItem barButtonItem184;

	private BarButtonItem barButtonItem190;

	private BarButtonItem barButtonItem192;

	private BarButtonItem barButtonItem193;

	private BarButtonItem barButtonItem196;

	private BarButtonItem barButtonItem197;

	private BarButtonItem barButtonItem198;

	private BarButtonItem barButtonItem199;

	private BarButtonItem barButtonItem200;

	private BarButtonItem barButtonItem201;

	private BarButtonItem barButtonItem202;

	private BarCheckItem barCheckItem1;

	private BarButtonItem barButtonItem203;

	private BarCheckItem barCheckItem2;

	private BarCheckItem barCheckItem3;

	private BarCheckItem barCheckItem4;

	private BarCheckItem barCheckItem5;

	private BarCheckItem barCheckItem6;

	private BarCheckItem barCheckItem7;

	private BarCheckItem barCheckItem8;

	private BarButtonItem barButtonItem204;

	private BarCheckItem chkS1;

	private BarCheckItem chkS2;

	private BarCheckItem chkS3;

	private BarCheckItem chkS4;

	private BarCheckItem chkS5;

	private BarCheckItem chkS6;

	private BarCheckItem chkAll;

	private BarCheckItem chkNA;

	private BarEditItem barEditItem13;

	private BarButtonItem barButtonItem191;

	private BarButtonItem barButtonItem207;

	private BarButtonItem barButtonItem208;

	private BarButtonItem barButtonItem209;

	private BarButtonItem barButtonItem210;

	private BarButtonItem barButtonItem211;

	private BarStaticItem lblListType;

	private LayoutControl layoutControl1;

	private PivotGridControl pivotGridMarkSheets;

	private LayoutControlGroup layoutControlGroup2;

	private LayoutControlItem layoutControlItem2;

	private BackgroundWorker backgroundWorker1;

	private System.Windows.Forms.Timer timer1;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private LabelControl lblSubHeader;

	private LabelControl lblHeader;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem1;

	public usrPeformanceSheetNC(string _class, string _term, int scopeIndex)
	{
		InitializeComponent();
		this._class = _class;
		this._term = _term;
		this.scopeIndex = scopeIndex;
	}

	private void GeneralMarkSheet()
	{
		try
		{
			string selectCommandText = string.Empty;
			if (scopeIndex == 0)
			{
				selectCommandText = $"SELECT s.fullName, s.StudentNumber, sc.CategoryAIOnly, sc.OutOfHund, Substring(sc.SubjectId,5,3) AS SubjectId, sc.ClassId, CONVERT(varchar(5), sc.OutOfHund) + '(' + sc.CategoryAIOnly + ')' AS Score100 FROM tbl_Scores_OL_Report sc INNER JOIN tbl_Stud s ON sc.StudentNumber = s.StudentNumber WHERE(sc.SemesterId = '{_term}') AND (sc.ClassId = '{_class}') ";
				subHeader = "Analysis based on Assessment of Integration only";
			}
			else if (scopeIndex == 1)
			{
				selectCommandText = $"SELECT s.fullName, s.StudentNumber,sc.Category, sc.ETAv, Substring(sc.SubjectId,5,3) AS SubjectId, sc.ClassId, CONVERT(varchar(5), sc.ETAv) + '(' + sc.Category + ')' AS Score100  FROM tbl_Scores_OL_Report sc INNER JOIN tbl_Stud s ON sc.StudentNumber = s.StudentNumber WHERE(sc.SemesterId = '{_term}') AND (sc.ClassId = '{_class}') ";
				subHeader = "Analysis based on Assessment of Integration and EOT Examination";
			}
			else if (scopeIndex == 2)
			{
				selectCommandText = $"SELECT s.fullName, s.StudentNumber, sc.ETA, sc.P5, Substring(sc.SubjectId,5,3) AS SubjectId, sc.ClassId, CONVERT(varchar(5), sc.ETA) + '(' + sc.P5 + ')' AS Score100 FROM tbl_Scores_OL_Report sc INNER JOIN tbl_Stud s ON sc.StudentNumber = s.StudentNumber WHERE(sc.SemesterId = '{_term}') AND (sc.ClassId = '{_class}') ";
				subHeader = "Analysis based on EOT Examination only";
			}
			lblHeader.Text = "Students' Average Performance. " + _class + "-" + _term;
			lblSubHeader.Text = subHeader;
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelReport");
			pivotGridMarkSheets.DataSource = dataSet.Tables["OLevelReport"];
			PrintableControl.SavePrintableControl(pivotGridMarkSheets);
			MarkSheet.SetMarkSheetViewType("PivotGrid");
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrPeformanceSheet_Load(object sender, EventArgs e)
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Generating Marksheet...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.GenerateMarkSheet, 0);
		Thread.Sleep(25);
		InitializeAllMarkSheets();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void InitializeAllMarkSheets()
	{
		try
		{
			GeneralMarkSheet();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView7_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "No")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		for (int i = 0; i < 4; i++)
		{
			if (i == 3)
			{
				timer1.Enabled = false;
				i = 0;
			}
		}
	}

	private void pivotGridMarkSheets_Click(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.usrPeformanceSheetNC));
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item2 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item3 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem9 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item4 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem10 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem11 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem12 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem13 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item5 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem14 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem15 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item6 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem16 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem17 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item7 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem18 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem19 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item8 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem20 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem21 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip13 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem22 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem13 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip14 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem23 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem14 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip15 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem24 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem15 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item9 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem25 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip16 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem26 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem16 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item10 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem27 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip17 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem28 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem17 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item11 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem29 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip18 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem30 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem18 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item12 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem31 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip19 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem32 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem19 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item13 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem33 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip20 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem34 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem20 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item14 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem35 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip21 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem36 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem21 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item15 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem37 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip22 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem38 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem22 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item16 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem39 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip23 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem40 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem23 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item17 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem41 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip24 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem42 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem24 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item18 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem43 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip25 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem44 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem25 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item19 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem45 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip26 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem46 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem26 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item20 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem47 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip27 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem48 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem27 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item21 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem49 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip28 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem50 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem28 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item22 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem51 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip29 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem52 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem29 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item23 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem53 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip30 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem54 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem30 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item24 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem55 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip31 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem56 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem31 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item25 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem57 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip32 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem58 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem32 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item26 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem59 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip33 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem60 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem33 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item27 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem61 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip34 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem62 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem34 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item28 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem63 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip35 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem64 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem35 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item29 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem65 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip36 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem66 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem36 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item30 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem67 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip37 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem68 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem37 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item31 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem69 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip38 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem70 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem38 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item32 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem71 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip39 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem72 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem39 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item33 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem73 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip40 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem74 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem40 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item34 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem75 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip41 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem76 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem41 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item35 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem77 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip42 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem78 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem42 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item36 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem79 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip43 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem80 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem43 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item37 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem81 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip44 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem82 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem44 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item38 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem83 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip45 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem84 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem45 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item39 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem85 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip46 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem86 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem46 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item40 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem87 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip47 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem88 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem47 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item41 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem89 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip48 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem90 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem48 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item42 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem91 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip49 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem92 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem49 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item43 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem93 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip50 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem94 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem50 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item44 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem95 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip51 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem96 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem51 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item45 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem97 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip52 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem98 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem52 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item46 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem99 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip53 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem100 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem53 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item47 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem101 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip54 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem102 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem54 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip55 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem103 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem55 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item48 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem104 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip56 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem105 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem56 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item49 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem106 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip57 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem107 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem57 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item50 = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem108 = new DevExpress.Utils.ToolTipTitleItem();
		this.lblCurrentUser = new DevExpress.XtraBars.BarStaticItem();
		this.lblWorkStation = new DevExpress.XtraBars.BarStaticItem();
		this.lblAccountAction = new DevExpress.XtraBars.BarStaticItem();
		this.lblWorkingSemester = new DevExpress.XtraBars.BarStaticItem();
		this.lblTime = new DevExpress.XtraBars.BarStaticItem();
		this.lblMarkType = new DevExpress.XtraBars.BarStaticItem();
		this.lblSelectedClass = new DevExpress.XtraBars.BarStaticItem();
		this.ribbonWelcome = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup44 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonGalleryBarItem2 = new DevExpress.XtraBars.RibbonGalleryBarItem();
		this.ribbonPageGroup37 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem169 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem172 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem173 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem174 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonStudents = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup22 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem133 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem134 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem213 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem205 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem93 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem94 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup40 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem142 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup18 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonEmployees = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonAGS = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem182 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem185 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem189 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup35 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem124 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem125 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup36 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem42 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem83 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem73 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem74 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem177 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonSuppliers = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup25 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem33 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem180 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem181 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem187 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem32 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup45 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem43 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem186 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonAddDeliveries = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem31 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem101 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem21 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup26 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem75 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem76 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem178 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup21 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonAcademics = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barBtnSelectSubjects = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem188 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup34 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem67 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup48 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem214 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup47 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem212 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonAccounts = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem154 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem153 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem159 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem160 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem27 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem28 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem29 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem35 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem24 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem37 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem36 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem26 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem39 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem99 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem34 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup27 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem38 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem57 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem58 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPageGroup46 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.barButtonItem194 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem195 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem206 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
		this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
		this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem44 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem45 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem46 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem47 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem48 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem49 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem50 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem51 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem54 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem62 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem63 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
		this.barButtonGS = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItemDS = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem64 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonPB = new DevExpress.XtraBars.BarButtonItem();
		this.lookUpOrders = new DevExpress.XtraBars.BarEditItem();
		this.barButtonAllSets = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem40 = new DevExpress.XtraBars.BarButtonItem();
		this.printPreviewStaticItem1 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
		this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem55 = new DevExpress.XtraBars.BarButtonItem();
		this.printPreviewStaticItem2 = new DevExpress.XtraPrinting.Preview.PrintPreviewStaticItem();
		this.barButtonItem56 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem59 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem60 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem41 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem61 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem65 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem66 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem68 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem69 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem70 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItemPrintIE = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem71 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem72 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem77 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem78 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem79 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem80 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem81 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem7 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem82 = new DevExpress.XtraBars.BarButtonItem();
		this.cboSemesterBudget = new DevExpress.XtraBars.BarEditItem();
		this.cboBudgetAnnual = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem84 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem85 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem86 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem87 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem88 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem89 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem91 = new DevExpress.XtraBars.BarButtonItem();
		this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
		this.barListItem1 = new DevExpress.XtraBars.BarListItem();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.barListItem2 = new DevExpress.XtraBars.BarListItem();
		this.barListItem3 = new DevExpress.XtraBars.BarListItem();
		this.barButtonItem95 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem96 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem97 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem98 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem100 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem103 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem104 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem105 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem106 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem107 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem108 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem109 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem110 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem111 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem112 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem113 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem114 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem115 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem116 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem117 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem118 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem119 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem6 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem90 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem92 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem102 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem120 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem121 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem122 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem123 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem126 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem127 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem128 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem129 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem130 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem131 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem132 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem136 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem137 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem138 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem139 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem140 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem141 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem143 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem144 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem145 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem146 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem147 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem148 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem149 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem52 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem53 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem8 = new DevExpress.XtraBars.BarEditItem();
		this.barEditItem9 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem150 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem10 = new DevExpress.XtraBars.BarEditItem();
		this.barEditItem11 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem151 = new DevExpress.XtraBars.BarButtonItem();
		this.barCBOSemester = new DevExpress.XtraBars.BarEditItem();
		this.barCBOSemesterIncome = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem152 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem155 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem156 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem157 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem135 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem158 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem161 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem162 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem163 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem164 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem165 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem166 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem167 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem168 = new DevExpress.XtraBars.BarButtonItem();
		this.barEditItem12 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem170 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem171 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem175 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem176 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem179 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem183 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem184 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem190 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem192 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem193 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem196 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem197 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem198 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem199 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem200 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem201 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem202 = new DevExpress.XtraBars.BarButtonItem();
		this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
		this.barButtonItem203 = new DevExpress.XtraBars.BarButtonItem();
		this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
		this.barCheckItem3 = new DevExpress.XtraBars.BarCheckItem();
		this.barCheckItem4 = new DevExpress.XtraBars.BarCheckItem();
		this.barCheckItem5 = new DevExpress.XtraBars.BarCheckItem();
		this.barCheckItem6 = new DevExpress.XtraBars.BarCheckItem();
		this.barCheckItem7 = new DevExpress.XtraBars.BarCheckItem();
		this.barCheckItem8 = new DevExpress.XtraBars.BarCheckItem();
		this.barButtonItem204 = new DevExpress.XtraBars.BarButtonItem();
		this.chkS1 = new DevExpress.XtraBars.BarCheckItem();
		this.chkS2 = new DevExpress.XtraBars.BarCheckItem();
		this.chkS3 = new DevExpress.XtraBars.BarCheckItem();
		this.chkS4 = new DevExpress.XtraBars.BarCheckItem();
		this.chkS5 = new DevExpress.XtraBars.BarCheckItem();
		this.chkS6 = new DevExpress.XtraBars.BarCheckItem();
		this.chkAll = new DevExpress.XtraBars.BarCheckItem();
		this.chkNA = new DevExpress.XtraBars.BarCheckItem();
		this.barEditItem13 = new DevExpress.XtraBars.BarEditItem();
		this.barButtonItem191 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem207 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem208 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem209 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem210 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem211 = new DevExpress.XtraBars.BarButtonItem();
		this.lblListType = new DevExpress.XtraBars.BarStaticItem();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pivotGridMarkSheets = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.lblSubHeader = new DevExpress.XtraEditors.LabelControl();
		this.lblHeader = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridMarkSheets).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		ribbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		ribbonPageGroup.KeyTip = "IE";
		ribbonPageGroup.Name = "ribbonPageGroup19";
		ribbonPageGroup.Text = "Inventory";
		ribbonPageGroup.Visible = false;
		this.lblCurrentUser.Caption = "User";
		this.lblCurrentUser.Id = 476;
		this.lblCurrentUser.Name = "lblCurrentUser";
		this.lblWorkStation.Caption = "Workstation";
		this.lblWorkStation.Id = 479;
		this.lblWorkStation.Name = "lblWorkStation";
		this.lblAccountAction.Id = 426;
		this.lblAccountAction.Name = "lblAccountAction";
		this.lblAccountAction.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.lblWorkingSemester.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.lblWorkingSemester.Id = 484;
		this.lblWorkingSemester.Name = "lblWorkingSemester";
		this.lblTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.lblTime.Caption = "Time";
		this.lblTime.Id = 480;
		this.lblTime.Name = "lblTime";
		this.lblMarkType.Caption = "MarType";
		this.lblMarkType.Id = 665;
		this.lblMarkType.Name = "lblMarkType";
		this.lblMarkType.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.lblSelectedClass.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
		this.lblSelectedClass.Id = 669;
		this.lblSelectedClass.Name = "lblSelectedClass";
		this.ribbonWelcome.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[2] { this.ribbonPageGroup44, this.ribbonPageGroup37 });
		this.ribbonWelcome.Name = "ribbonWelcome";
		this.ribbonWelcome.Text = "Common settings";
		this.ribbonPageGroup44.AllowTextClipping = false;
		this.ribbonPageGroup44.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup44.ItemLinks.Add(this.ribbonGalleryBarItem2);
		this.ribbonPageGroup44.Name = "ribbonPageGroup44";
		this.ribbonPageGroup44.Text = "Look and Feel";
		this.ribbonGalleryBarItem2.Caption = "ribbonGalleryBarItem2";
		this.ribbonGalleryBarItem2.Id = 596;
		this.ribbonGalleryBarItem2.Name = "ribbonGalleryBarItem2";
		this.ribbonPageGroup37.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup37.ItemLinks.Add(this.barButtonItem169);
		this.ribbonPageGroup37.ItemLinks.Add(this.barButtonItem172);
		this.ribbonPageGroup37.ItemLinks.Add(this.barButtonItem173);
		this.ribbonPageGroup37.ItemLinks.Add(this.barButtonItem174);
		this.ribbonPageGroup37.Name = "ribbonPageGroup37";
		this.ribbonPageGroup37.Text = "iXtreme 2014";
		this.barButtonItem169.Caption = "Connect to Database";
		this.barButtonItem169.Id = 597;
		this.barButtonItem169.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem169.ImageOptions.Image");
		this.barButtonItem169.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem169.ImageOptions.LargeImage");
		this.barButtonItem169.Name = "barButtonItem169";
		toolTipTitleItem.Text = "Connect to database";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Ctrl + Shift + C";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.barButtonItem169.SuperTip = superToolTip;
		this.barButtonItem172.Caption = "Log out";
		this.barButtonItem172.Id = 598;
		this.barButtonItem172.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem172.ImageOptions.Image");
		this.barButtonItem172.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem172.ImageOptions.LargeImage");
		this.barButtonItem172.Name = "barButtonItem172";
		toolTipTitleItem2.Text = "Log out";
		toolTipItem2.LeftIndent = 6;
		toolTipItem2.Text = "Ctrl + L";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.barButtonItem172.SuperTip = superToolTip2;
		this.barButtonItem173.Caption = "Help";
		this.barButtonItem173.Id = 599;
		this.barButtonItem173.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem173.ImageOptions.Image");
		this.barButtonItem173.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem173.ImageOptions.LargeImage");
		this.barButtonItem173.Name = "barButtonItem173";
		this.barButtonItem174.Caption = "About";
		this.barButtonItem174.Id = 600;
		this.barButtonItem174.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem174.ImageOptions.Image");
		this.barButtonItem174.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem174.ImageOptions.LargeImage");
		this.barButtonItem174.Name = "barButtonItem174";
		this.ribbonStudents.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup22, this.ribbonPageGroup1, this.ribbonPageGroup40, this.ribbonPageGroup18 });
		this.ribbonStudents.KeyTip = "ST";
		this.ribbonStudents.Name = "ribbonStudents";
		this.ribbonStudents.Text = "Students";
		this.ribbonPageGroup22.AllowTextClipping = false;
		this.ribbonPageGroup22.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup22.ItemLinks.Add(this.barButtonItem16, "A");
		this.ribbonPageGroup22.ItemLinks.Add(this.barButtonItem133);
		this.ribbonPageGroup22.ItemLinks.Add(this.barButtonItem134);
		this.ribbonPageGroup22.ItemLinks.Add(this.barButtonItem17);
		this.ribbonPageGroup22.ItemLinks.Add(this.barButtonItem213);
		this.ribbonPageGroup22.ItemLinks.Add(this.barButtonItem205);
		this.ribbonPageGroup22.KeyTip = "ST";
		this.ribbonPageGroup22.Name = "ribbonPageGroup22";
		this.ribbonPageGroup22.Text = "Student";
		this.barButtonItem16.Caption = "Add New";
		this.barButtonItem16.Id = 95;
		this.barButtonItem16.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem16.ImageOptions.Image");
		this.barButtonItem16.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem16.ImageOptions.LargeImage");
		this.barButtonItem16.Name = "barButtonItem16";
		this.barButtonItem133.Caption = "Edit/View";
		this.barButtonItem133.Id = 530;
		this.barButtonItem133.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem133.ImageOptions.Image");
		this.barButtonItem133.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem133.ImageOptions.LargeImage");
		this.barButtonItem133.Name = "barButtonItem133";
		this.barButtonItem134.Caption = "Delete";
		this.barButtonItem134.Id = 531;
		this.barButtonItem134.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem134.ImageOptions.Image");
		this.barButtonItem134.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem134.ImageOptions.LargeImage");
		this.barButtonItem134.Name = "barButtonItem134";
		this.barButtonItem17.ActAsDropDown = true;
		this.barButtonItem17.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem17.Caption = "Lists";
		this.barButtonItem17.Id = 96;
		this.barButtonItem17.ImageOptions.Image = I_Xtreme.Properties.Resources._16fullList;
		this.barButtonItem17.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.fullList;
		this.barButtonItem17.Name = "barButtonItem17";
		toolTipTitleItem3.Text = "Load/Refresh";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "Refresh a loaded class list or Load a new class";
		toolTipTitleItem4.LeftIndent = 6;
		toolTipTitleItem4.Text = "Press F1 for help.";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		superToolTip3.Items.Add(item);
		superToolTip3.Items.Add(toolTipTitleItem4);
		this.barButtonItem17.SuperTip = superToolTip3;
		this.barButtonItem213.ActAsDropDown = true;
		this.barButtonItem213.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem213.Caption = "Custom Lists";
		this.barButtonItem213.Id = 667;
		this.barButtonItem213.ImageOptions.Image = I_Xtreme.Properties.Resources._16emptyLists;
		this.barButtonItem213.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.emptyLists;
		this.barButtonItem213.Name = "barButtonItem213";
		toolTipTitleItem5.Text = "Custom lists";
		toolTipItem4.LeftIndent = 6;
		toolTipItem4.Text = "Custom student lists you can use for other purposes.";
		toolTipTitleItem6.LeftIndent = 6;
		toolTipTitleItem6.Text = "Press F1 for help.";
		superToolTip4.Items.Add(toolTipTitleItem5);
		superToolTip4.Items.Add(toolTipItem4);
		superToolTip4.Items.Add(item2);
		superToolTip4.Items.Add(toolTipTitleItem6);
		this.barButtonItem213.SuperTip = superToolTip4;
		this.barButtonItem205.Caption = "Enrollment";
		this.barButtonItem205.Id = 652;
		this.barButtonItem205.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem205.ImageOptions.Image");
		this.barButtonItem205.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem205.ImageOptions.LargeImage");
		this.barButtonItem205.Name = "barButtonItem205";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem93, "PR");
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem94, "NE");
		this.ribbonPageGroup1.KeyTip = "NA";
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.Text = "Navigation";
		this.barButtonItem93.Caption = "Previous";
		this.barButtonItem93.Id = 458;
		this.barButtonItem93.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem93.ImageOptions.Image");
		this.barButtonItem93.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem93.ImageOptions.LargeImage");
		this.barButtonItem93.Name = "barButtonItem93";
		this.barButtonItem94.Caption = "Next";
		this.barButtonItem94.Id = 459;
		this.barButtonItem94.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem94.ImageOptions.Image");
		this.barButtonItem94.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem94.ImageOptions.LargeImage");
		this.barButtonItem94.Name = "barButtonItem94";
		this.ribbonPageGroup40.AllowTextClipping = false;
		this.ribbonPageGroup40.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup40.ItemLinks.Add(this.barButtonItem142);
		this.ribbonPageGroup40.Name = "ribbonPageGroup40";
		this.ribbonPageGroup40.Text = "Cards";
		this.barButtonItem142.Caption = "Cards";
		this.barButtonItem142.Id = 539;
		this.barButtonItem142.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem142.ImageOptions.Image");
		this.barButtonItem142.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem142.ImageOptions.LargeImage");
		this.barButtonItem142.Name = "barButtonItem142";
		this.ribbonPageGroup18.AllowTextClipping = false;
		this.ribbonPageGroup18.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem18, "PN");
		this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem19);
		this.ribbonPageGroup18.ItemLinks.Add(this.barButtonItem20, true, "E");
		this.ribbonPageGroup18.KeyTip = "PI";
		this.ribbonPageGroup18.Name = "ribbonPageGroup18";
		this.ribbonPageGroup18.Text = "Printing and Exporting";
		this.barButtonItem18.Caption = "Print";
		this.barButtonItem18.Id = 97;
		this.barButtonItem18.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem18.ImageOptions.Image");
		this.barButtonItem18.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem18.ImageOptions.LargeImage");
		this.barButtonItem18.Name = "barButtonItem18";
		this.barButtonItem18.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.All;
		this.barButtonItem19.Caption = "Preview";
		this.barButtonItem19.Id = 98;
		this.barButtonItem19.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem19.ImageOptions.Image");
		this.barButtonItem19.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem19.ImageOptions.LargeImage");
		this.barButtonItem19.Name = "barButtonItem19";
		this.barButtonItem19.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.All;
		this.barButtonItem20.Caption = "Export";
		this.barButtonItem20.Id = 99;
		this.barButtonItem20.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem20.ImageOptions.Image");
		this.barButtonItem20.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem20.ImageOptions.LargeImage");
		this.barButtonItem20.Name = "barButtonItem20";
		this.barButtonItem20.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.All;
		toolTipTitleItem7.Text = "Export";
		toolTipItem5.LeftIndent = 6;
		toolTipItem5.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem8.LeftIndent = 6;
		toolTipTitleItem8.Text = "Press F1 for help";
		superToolTip5.Items.Add(toolTipTitleItem7);
		superToolTip5.Items.Add(toolTipItem5);
		superToolTip5.Items.Add(item3);
		superToolTip5.Items.Add(toolTipTitleItem8);
		this.barButtonItem20.SuperTip = superToolTip5;
		this.ribbonEmployees.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup16, this.ribbonPageGroup35, this.ribbonPageGroup36, this.ribbonPageGroup9 });
		this.ribbonEmployees.KeyTip = "E";
		this.ribbonEmployees.Name = "ribbonEmployees";
		this.ribbonEmployees.Text = "Employees";
		this.ribbonPageGroup16.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonAGS, "R");
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem22);
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem182);
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem185);
		this.ribbonPageGroup16.ItemLinks.Add(this.barButtonItem189, true);
		this.ribbonPageGroup16.KeyTip = "EM";
		this.ribbonPageGroup16.Name = "ribbonPageGroup16";
		this.ribbonPageGroup16.Text = "Employee";
		this.barButtonAGS.Caption = "Add New";
		this.barButtonAGS.Id = 100;
		this.barButtonAGS.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonAGS.ImageOptions.Image");
		this.barButtonAGS.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonAGS.ImageOptions.LargeImage");
		this.barButtonAGS.Name = "barButtonAGS";
		this.barButtonItem22.Caption = "Edit/View";
		this.barButtonItem22.Id = 101;
		this.barButtonItem22.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem22.ImageOptions.Image");
		this.barButtonItem22.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem22.ImageOptions.LargeImage");
		this.barButtonItem22.Name = "barButtonItem22";
		this.barButtonItem182.Caption = "Delete";
		this.barButtonItem182.Id = 609;
		this.barButtonItem182.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem182.ImageOptions.Image");
		this.barButtonItem182.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem182.ImageOptions.LargeImage");
		this.barButtonItem182.Name = "barButtonItem182";
		this.barButtonItem185.Caption = "Refresh";
		this.barButtonItem185.Id = 612;
		this.barButtonItem185.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem185.ImageOptions.Image");
		this.barButtonItem185.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem185.ImageOptions.LargeImage");
		this.barButtonItem185.Name = "barButtonItem185";
		this.barButtonItem189.Caption = "Email";
		this.barButtonItem189.Id = 617;
		this.barButtonItem189.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem189.ImageOptions.Image");
		this.barButtonItem189.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem189.ImageOptions.LargeImage");
		this.barButtonItem189.Name = "barButtonItem189";
		toolTipTitleItem9.Text = "Email";
		toolTipItem6.LeftIndent = 6;
		toolTipItem6.Text = "Send an Email to an employee";
		toolTipTitleItem10.LeftIndent = 6;
		toolTipTitleItem10.Text = "Press F1 for help.";
		superToolTip6.Items.Add(toolTipTitleItem9);
		superToolTip6.Items.Add(toolTipItem6);
		superToolTip6.Items.Add(item4);
		superToolTip6.Items.Add(toolTipTitleItem10);
		this.barButtonItem189.SuperTip = superToolTip6;
		this.ribbonPageGroup35.AllowTextClipping = false;
		this.ribbonPageGroup35.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup35.ItemLinks.Add(this.barButtonItem124);
		this.ribbonPageGroup35.ItemLinks.Add(this.barButtonItem125);
		this.ribbonPageGroup35.Name = "ribbonPageGroup35";
		this.ribbonPageGroup35.Text = "Navigation";
		this.barButtonItem124.Caption = "Previous";
		this.barButtonItem124.Id = 517;
		this.barButtonItem124.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem124.ImageOptions.Image");
		this.barButtonItem124.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem124.ImageOptions.LargeImage");
		this.barButtonItem124.Name = "barButtonItem124";
		this.barButtonItem125.Caption = "Next";
		this.barButtonItem125.Id = 518;
		this.barButtonItem125.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem125.ImageOptions.Image");
		this.barButtonItem125.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem125.ImageOptions.LargeImage");
		this.barButtonItem125.Name = "barButtonItem125";
		this.ribbonPageGroup36.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup36.ItemLinks.Add(this.barButtonItem42);
		this.ribbonPageGroup36.ItemLinks.Add(this.barButtonItem83);
		this.ribbonPageGroup36.Name = "ribbonPageGroup36";
		this.ribbonPageGroup36.Text = "Documents";
		this.barButtonItem42.ActAsDropDown = true;
		this.barButtonItem42.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem42.Caption = "Employee IDs";
		this.barButtonItem42.Id = 132;
		this.barButtonItem42.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem42.ImageOptions.Image");
		this.barButtonItem42.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem42.ImageOptions.LargeImage");
		this.barButtonItem42.Name = "barButtonItem42";
		this.barButtonItem83.ActAsDropDown = true;
		this.barButtonItem83.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem83.Caption = "Payroll Sheet";
		this.barButtonItem83.Id = 448;
		this.barButtonItem83.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem83.ImageOptions.Image");
		this.barButtonItem83.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem83.ImageOptions.LargeImage");
		this.barButtonItem83.Name = "barButtonItem83";
		this.ribbonPageGroup9.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem73, "PI");
		this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem74);
		this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem177);
		this.ribbonPageGroup9.KeyTip = "PR";
		this.ribbonPageGroup9.Name = "ribbonPageGroup9";
		this.ribbonPageGroup9.Text = "Printing and Exporting";
		this.barButtonItem73.Caption = "Print";
		this.barButtonItem73.Id = 430;
		this.barButtonItem73.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem73.ImageOptions.Image");
		this.barButtonItem73.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem73.ImageOptions.LargeImage");
		this.barButtonItem73.Name = "barButtonItem73";
		this.barButtonItem74.Caption = "Preview";
		this.barButtonItem74.Id = 431;
		this.barButtonItem74.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem74.ImageOptions.Image");
		this.barButtonItem74.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem74.ImageOptions.LargeImage");
		this.barButtonItem74.Name = "barButtonItem74";
		this.barButtonItem177.Caption = "Export";
		this.barButtonItem177.Id = 604;
		this.barButtonItem177.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem177.ImageOptions.Image");
		this.barButtonItem177.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem177.ImageOptions.LargeImage");
		this.barButtonItem177.Name = "barButtonItem177";
		toolTipTitleItem11.Text = "Export";
		toolTipItem7.LeftIndent = 6;
		toolTipItem7.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem12.LeftIndent = 6;
		toolTipTitleItem12.Text = "Press F1 for help.";
		superToolTip7.Items.Add(toolTipTitleItem11);
		superToolTip7.Items.Add(toolTipItem7);
		superToolTip7.Items.Add(toolTipTitleItem12);
		this.barButtonItem177.SuperTip = superToolTip7;
		this.ribbonSuppliers.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[6] { this.ribbonPageGroup25, this.ribbonPageGroup45, this.ribbonPageGroup6, this.ribbonPageGroup26, ribbonPageGroup, this.ribbonPageGroup21 });
		this.ribbonSuppliers.KeyTip = "SU";
		this.ribbonSuppliers.Name = "ribbonSuppliers";
		this.ribbonSuppliers.Text = "Suppliers";
		this.ribbonPageGroup25.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup25.ItemLinks.Add(this.barButtonItem33, "AD");
		this.ribbonPageGroup25.ItemLinks.Add(this.barButtonItem180);
		this.ribbonPageGroup25.ItemLinks.Add(this.barButtonItem181);
		this.ribbonPageGroup25.ItemLinks.Add(this.barButtonItem187);
		this.ribbonPageGroup25.ItemLinks.Add(this.barButtonItem32, true);
		this.ribbonPageGroup25.KeyTip = "SU";
		this.ribbonPageGroup25.Name = "ribbonPageGroup25";
		this.ribbonPageGroup25.Text = "Supplier";
		this.barButtonItem33.Caption = "Add New";
		this.barButtonItem33.Id = 112;
		this.barButtonItem33.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem33.ImageOptions.Image");
		this.barButtonItem33.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem33.ImageOptions.LargeImage");
		this.barButtonItem33.Name = "barButtonItem33";
		toolTipTitleItem13.Text = "Add New";
		toolTipItem8.LeftIndent = 6;
		toolTipItem8.Text = "Add new supplier";
		toolTipTitleItem14.LeftIndent = 6;
		toolTipTitleItem14.Text = "Press F1 for help.";
		superToolTip8.Items.Add(toolTipTitleItem13);
		superToolTip8.Items.Add(toolTipItem8);
		superToolTip8.Items.Add(item5);
		superToolTip8.Items.Add(toolTipTitleItem14);
		this.barButtonItem33.SuperTip = superToolTip8;
		this.barButtonItem180.Caption = "Edit/View";
		this.barButtonItem180.Id = 607;
		this.barButtonItem180.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem180.ImageOptions.Image");
		this.barButtonItem180.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem180.ImageOptions.LargeImage");
		this.barButtonItem180.Name = "barButtonItem180";
		toolTipTitleItem15.Text = "Edit";
		toolTipItem9.LeftIndent = 6;
		toolTipItem9.Text = "Edit an existing supplier";
		toolTipTitleItem16.LeftIndent = 6;
		toolTipTitleItem16.Text = "Press F1 for help.";
		superToolTip9.Items.Add(toolTipTitleItem15);
		superToolTip9.Items.Add(toolTipItem9);
		superToolTip9.Items.Add(item6);
		superToolTip9.Items.Add(toolTipTitleItem16);
		this.barButtonItem180.SuperTip = superToolTip9;
		this.barButtonItem181.Caption = "Delete";
		this.barButtonItem181.Id = 608;
		this.barButtonItem181.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem181.ImageOptions.Image");
		this.barButtonItem181.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem181.ImageOptions.LargeImage");
		this.barButtonItem181.Name = "barButtonItem181";
		toolTipTitleItem17.Text = "Delete";
		toolTipItem10.LeftIndent = 6;
		toolTipItem10.Text = "Delete an existing supplier";
		toolTipTitleItem18.LeftIndent = 6;
		toolTipTitleItem18.Text = "Press F1 for help.";
		superToolTip10.Items.Add(toolTipTitleItem17);
		superToolTip10.Items.Add(toolTipItem10);
		superToolTip10.Items.Add(item7);
		superToolTip10.Items.Add(toolTipTitleItem18);
		this.barButtonItem181.SuperTip = superToolTip10;
		this.barButtonItem187.Caption = "Refresh";
		this.barButtonItem187.Id = 615;
		this.barButtonItem187.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem187.ImageOptions.Image");
		this.barButtonItem187.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem187.ImageOptions.LargeImage");
		this.barButtonItem187.Name = "barButtonItem187";
		this.barButtonItem32.Caption = "Email";
		this.barButtonItem32.Id = 111;
		this.barButtonItem32.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem32.ImageOptions.Image");
		this.barButtonItem32.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem32.ImageOptions.LargeImage");
		this.barButtonItem32.Name = "barButtonItem32";
		toolTipTitleItem19.Text = "Email";
		toolTipItem11.LeftIndent = 6;
		toolTipItem11.Text = "Send an Email message to a supplier";
		toolTipTitleItem20.LeftIndent = 6;
		toolTipTitleItem20.Text = "Press F1 help.";
		superToolTip11.Items.Add(toolTipTitleItem19);
		superToolTip11.Items.Add(toolTipItem11);
		superToolTip11.Items.Add(item8);
		superToolTip11.Items.Add(toolTipTitleItem20);
		this.barButtonItem32.SuperTip = superToolTip11;
		this.ribbonPageGroup45.AllowTextClipping = false;
		this.ribbonPageGroup45.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup45.ItemLinks.Add(this.barButtonItem43);
		this.ribbonPageGroup45.ItemLinks.Add(this.barButtonItem186);
		this.ribbonPageGroup45.Name = "ribbonPageGroup45";
		this.ribbonPageGroup45.Text = "Navigation";
		this.barButtonItem43.Caption = "Previous";
		this.barButtonItem43.Id = 613;
		this.barButtonItem43.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem43.ImageOptions.Image");
		this.barButtonItem43.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem43.ImageOptions.LargeImage");
		this.barButtonItem43.Name = "barButtonItem43";
		this.barButtonItem186.Caption = "Next";
		this.barButtonItem186.Id = 614;
		this.barButtonItem186.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem186.ImageOptions.Image");
		this.barButtonItem186.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem186.ImageOptions.LargeImage");
		this.barButtonItem186.Name = "barButtonItem186";
		this.ribbonPageGroup6.AllowTextClipping = false;
		this.ribbonPageGroup6.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup6.ItemLinks.Add(this.barButtonAddDeliveries, "R");
		this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem31, "IV");
		this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem101, "AL");
		this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem21, true, "PA");
		this.ribbonPageGroup6.KeyTip = "IN";
		this.ribbonPageGroup6.Name = "ribbonPageGroup6";
		this.ribbonPageGroup6.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup6.Text = "Invoice";
		this.barButtonAddDeliveries.Caption = "Receive New";
		this.barButtonAddDeliveries.Id = 110;
		this.barButtonAddDeliveries.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonAddDeliveries.ImageOptions.Image");
		this.barButtonAddDeliveries.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonAddDeliveries.ImageOptions.LargeImage");
		this.barButtonAddDeliveries.Name = "barButtonAddDeliveries";
		toolTipTitleItem21.Text = "Receive invoices";
		toolTipItem12.LeftIndent = 6;
		toolTipItem12.Text = "Receive new supplier deliveries";
		superToolTip12.Items.Add(toolTipTitleItem21);
		superToolTip12.Items.Add(toolTipItem12);
		this.barButtonAddDeliveries.SuperTip = superToolTip12;
		this.barButtonItem31.ActAsDropDown = true;
		this.barButtonItem31.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem31.Caption = "Edit/View";
		this.barButtonItem31.Id = 161;
		this.barButtonItem31.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem31.ImageOptions.Image");
		this.barButtonItem31.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem31.ImageOptions.LargeImage");
		this.barButtonItem31.Name = "barButtonItem31";
		toolTipTitleItem22.Text = "Edit invoices";
		toolTipItem13.LeftIndent = 6;
		toolTipItem13.Text = "Edit an existing supplier invoice";
		superToolTip13.Items.Add(toolTipTitleItem22);
		superToolTip13.Items.Add(toolTipItem13);
		this.barButtonItem31.SuperTip = superToolTip13;
		this.barButtonItem101.Caption = "View All";
		this.barButtonItem101.Id = 474;
		this.barButtonItem101.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem101.ImageOptions.Image");
		this.barButtonItem101.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem101.ImageOptions.LargeImage");
		this.barButtonItem101.Name = "barButtonItem101";
		this.barButtonItem21.Caption = "Pay Invoices";
		this.barButtonItem21.Id = 160;
		this.barButtonItem21.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem21.ImageOptions.Image");
		this.barButtonItem21.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem21.ImageOptions.LargeImage");
		this.barButtonItem21.Name = "barButtonItem21";
		toolTipTitleItem23.Text = "Pay invoices";
		toolTipItem14.LeftIndent = 6;
		toolTipItem14.Text = "Make payment to a supplier";
		superToolTip14.Items.Add(toolTipTitleItem23);
		superToolTip14.Items.Add(toolTipItem14);
		this.barButtonItem21.SuperTip = superToolTip14;
		this.ribbonPageGroup26.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup26.ItemLinks.Add(this.barButtonItem75, "PI");
		this.ribbonPageGroup26.ItemLinks.Add(this.barButtonItem76);
		this.ribbonPageGroup26.ItemLinks.Add(this.barButtonItem178);
		this.ribbonPageGroup26.KeyTip = "PR";
		this.ribbonPageGroup26.Name = "ribbonPageGroup26";
		this.ribbonPageGroup26.Text = "Printing and Exporting";
		this.barButtonItem75.Caption = "Print";
		this.barButtonItem75.Id = 432;
		this.barButtonItem75.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem75.ImageOptions.Image");
		this.barButtonItem75.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem75.ImageOptions.LargeImage");
		this.barButtonItem75.Name = "barButtonItem75";
		this.barButtonItem76.Caption = "Preview";
		this.barButtonItem76.Id = 433;
		this.barButtonItem76.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem76.ImageOptions.Image");
		this.barButtonItem76.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem76.ImageOptions.LargeImage");
		this.barButtonItem76.Name = "barButtonItem76";
		this.barButtonItem178.Caption = "Export";
		this.barButtonItem178.Id = 605;
		this.barButtonItem178.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem178.ImageOptions.Image");
		this.barButtonItem178.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem178.ImageOptions.LargeImage");
		this.barButtonItem178.Name = "barButtonItem178";
		toolTipTitleItem24.Text = "Export";
		toolTipItem15.LeftIndent = 6;
		toolTipItem15.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem25.LeftIndent = 6;
		toolTipTitleItem25.Text = "Press F1 for help.";
		superToolTip15.Items.Add(toolTipTitleItem24);
		superToolTip15.Items.Add(toolTipItem15);
		superToolTip15.Items.Add(item9);
		superToolTip15.Items.Add(toolTipTitleItem25);
		this.barButtonItem178.SuperTip = superToolTip15;
		this.ribbonPageGroup21.AllowTextClipping = false;
		this.ribbonPageGroup21.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup21.KeyTip = "PU";
		this.ribbonPageGroup21.Name = "ribbonPageGroup21";
		this.ribbonPageGroup21.Text = "Purchasing";
		this.ribbonPageGroup21.Visible = false;
		this.ribbonAcademics.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[7] { this.ribbonPageGroup13, this.ribbonPageGroup14, this.ribbonPageGroup15, this.ribbonPageGroup17, this.ribbonPageGroup34, this.ribbonPageGroup48, this.ribbonPageGroup47 });
		this.ribbonAcademics.KeyTip = "AC";
		this.ribbonAcademics.Name = "ribbonAcademics";
		this.ribbonAcademics.Text = "Academics";
		this.ribbonPageGroup13.AllowTextClipping = false;
		this.ribbonPageGroup13.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup13.ItemLinks.Add(this.barBtnSelectSubjects, "SE");
		this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem3, true, "AL");
		this.ribbonPageGroup13.ItemLinks.Add(this.barButtonItem188, true);
		this.ribbonPageGroup13.KeyTip = "SU";
		this.ribbonPageGroup13.Name = "ribbonPageGroup13";
		this.ribbonPageGroup13.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup13.Text = "Subjects";
		this.barBtnSelectSubjects.Caption = "Add New";
		this.barBtnSelectSubjects.Id = 62;
		this.barBtnSelectSubjects.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barBtnSelectSubjects.ImageOptions.Image");
		this.barBtnSelectSubjects.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barBtnSelectSubjects.ImageOptions.LargeImage");
		this.barBtnSelectSubjects.Name = "barBtnSelectSubjects";
		toolTipTitleItem26.Text = "Select subjects";
		toolTipItem16.LeftIndent = 6;
		toolTipItem16.Text = "Use this option to select all the subjects done at each level in this school";
		toolTipTitleItem27.LeftIndent = 6;
		toolTipTitleItem27.Text = "Press F1 for help.";
		superToolTip16.Items.Add(toolTipTitleItem26);
		superToolTip16.Items.Add(toolTipItem16);
		superToolTip16.Items.Add(item10);
		superToolTip16.Items.Add(toolTipTitleItem27);
		this.barBtnSelectSubjects.SuperTip = superToolTip16;
		this.barButtonItem3.Caption = "A Level Papers";
		this.barButtonItem3.Id = 63;
		this.barButtonItem3.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem3.ImageOptions.Image");
		this.barButtonItem3.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem3.ImageOptions.LargeImage");
		this.barButtonItem3.Name = "barButtonItem3";
		toolTipTitleItem28.Text = "A Level subject settings";
		toolTipItem17.LeftIndent = 6;
		toolTipItem17.Text = "Use this option to set the Papers in a particular subject. These settings apply for A Level classes only";
		toolTipTitleItem29.LeftIndent = 6;
		toolTipTitleItem29.Text = "Press F1 for help.";
		superToolTip17.Items.Add(toolTipTitleItem28);
		superToolTip17.Items.Add(toolTipItem17);
		superToolTip17.Items.Add(item11);
		superToolTip17.Items.Add(toolTipTitleItem29);
		this.barButtonItem3.SuperTip = superToolTip17;
		this.barButtonItem188.Caption = "Drop";
		this.barButtonItem188.Id = 616;
		this.barButtonItem188.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem188.ImageOptions.Image");
		this.barButtonItem188.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem188.ImageOptions.LargeImage");
		this.barButtonItem188.Name = "barButtonItem188";
		toolTipTitleItem30.Text = "Drop subjects";
		toolTipItem18.LeftIndent = 6;
		toolTipItem18.Text = "Use this option to delete subjects/papers for a particular student/class.";
		toolTipTitleItem31.LeftIndent = 6;
		toolTipTitleItem31.Text = "Press F1 for help.";
		superToolTip18.Items.Add(toolTipTitleItem30);
		superToolTip18.Items.Add(toolTipItem18);
		superToolTip18.Items.Add(item12);
		superToolTip18.Items.Add(toolTipTitleItem31);
		this.barButtonItem188.SuperTip = superToolTip18;
		this.ribbonPageGroup14.AllowTextClipping = false;
		this.ribbonPageGroup14.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup14.ItemLinks.Add(this.barButtonItem2, "SD");
		this.ribbonPageGroup14.ItemLinks.Add(this.barButtonItem4, true, "SN");
		this.ribbonPageGroup14.KeyTip = "ST";
		this.ribbonPageGroup14.Name = "ribbonPageGroup14";
		this.ribbonPageGroup14.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup14.Text = "Student registration";
		this.barButtonItem2.Caption = "Simple";
		this.barButtonItem2.Id = 65;
		this.barButtonItem2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem2.ImageOptions.Image");
		this.barButtonItem2.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem2.ImageOptions.LargeImage");
		this.barButtonItem2.Name = "barButtonItem2";
		toolTipTitleItem32.Text = "Simple students registration";
		toolTipItem19.LeftIndent = 6;
		toolTipItem19.Text = "Use this options to assign subjects to an entirely selected class or to  a single student";
		toolTipTitleItem33.LeftIndent = 6;
		toolTipTitleItem33.Text = "Press F1 for help.";
		superToolTip19.Items.Add(toolTipTitleItem32);
		superToolTip19.Items.Add(toolTipItem19);
		superToolTip19.Items.Add(item13);
		superToolTip19.Items.Add(toolTipTitleItem33);
		this.barButtonItem2.SuperTip = superToolTip19;
		this.barButtonItem4.Caption = "Advanced";
		this.barButtonItem4.Id = 66;
		this.barButtonItem4.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.Image");
		this.barButtonItem4.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.LargeImage");
		this.barButtonItem4.Name = "barButtonItem4";
		toolTipTitleItem34.Text = "Advanced students registration";
		toolTipItem20.LeftIndent = 6;
		toolTipItem20.Text = "Use this option to assign subjects to students.Advanced mode allows registration of custom students for different subjects";
		toolTipTitleItem35.LeftIndent = 6;
		toolTipTitleItem35.Text = "Press F1 for help.";
		superToolTip20.Items.Add(toolTipTitleItem34);
		superToolTip20.Items.Add(toolTipItem20);
		superToolTip20.Items.Add(item14);
		superToolTip20.Items.Add(toolTipTitleItem35);
		this.barButtonItem4.SuperTip = superToolTip20;
		this.ribbonPageGroup15.AllowTextClipping = false;
		this.ribbonPageGroup15.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem7, "O");
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem10, "AE");
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem13, true, "GP");
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem15, "C");
		this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItem14, "SB");
		this.ribbonPageGroup15.KeyTip = "GR";
		this.ribbonPageGroup15.Name = "ribbonPageGroup15";
		this.ribbonPageGroup15.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup15.Text = "Grades and Comments";
		this.barButtonItem7.ActAsDropDown = true;
		this.barButtonItem7.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem7.Caption = "O Level";
		this.barButtonItem7.Id = 75;
		this.barButtonItem7.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem7.ImageOptions.Image");
		this.barButtonItem7.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem7.ImageOptions.LargeImage");
		this.barButtonItem7.Name = "barButtonItem7";
		toolTipTitleItem36.Text = "Grades and Comment";
		toolTipItem21.LeftIndent = 6;
		toolTipItem21.Text = "Use this this option to set the Grading Scale and Automated comments for O Level";
		toolTipTitleItem37.LeftIndent = 6;
		toolTipTitleItem37.Text = "Press F1 for help.";
		superToolTip21.Items.Add(toolTipTitleItem36);
		superToolTip21.Items.Add(toolTipItem21);
		superToolTip21.Items.Add(item15);
		superToolTip21.Items.Add(toolTipTitleItem37);
		this.barButtonItem7.SuperTip = superToolTip21;
		this.barButtonItem10.ActAsDropDown = true;
		this.barButtonItem10.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem10.Caption = "A Level";
		this.barButtonItem10.Id = 84;
		this.barButtonItem10.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem10.ImageOptions.Image");
		this.barButtonItem10.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem10.ImageOptions.LargeImage");
		this.barButtonItem10.Name = "barButtonItem10";
		toolTipTitleItem38.Text = "Grades and Comments";
		toolTipItem22.LeftIndent = 6;
		toolTipItem22.Text = "Use this this option to set the Grading Scale and Automated comments for A Level";
		toolTipTitleItem39.LeftIndent = 6;
		toolTipTitleItem39.Text = "Press F1 for help.";
		superToolTip22.Items.Add(toolTipTitleItem38);
		superToolTip22.Items.Add(toolTipItem22);
		superToolTip22.Items.Add(item16);
		superToolTip22.Items.Add(toolTipTitleItem39);
		this.barButtonItem10.SuperTip = superToolTip22;
		this.barButtonItem13.ActAsDropDown = true;
		this.barButtonItem13.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem13.Caption = "GP Cut-off";
		this.barButtonItem13.Id = 87;
		this.barButtonItem13.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem13.ImageOptions.Image");
		this.barButtonItem13.Name = "barButtonItem13";
		toolTipTitleItem40.Text = "General paper cutoff";
		toolTipItem23.LeftIndent = 6;
		toolTipItem23.Text = "Set the mark at which a student can obtain a point in General paper";
		toolTipTitleItem41.LeftIndent = 6;
		toolTipTitleItem41.Text = "Press F1 for help.";
		superToolTip23.Items.Add(toolTipTitleItem40);
		superToolTip23.Items.Add(toolTipItem23);
		superToolTip23.Items.Add(item17);
		superToolTip23.Items.Add(toolTipTitleItem41);
		this.barButtonItem13.SuperTip = superToolTip23;
		this.barButtonItem15.ActAsDropDown = true;
		this.barButtonItem15.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem15.Caption = "Computer Cut-off";
		this.barButtonItem15.Id = 89;
		this.barButtonItem15.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem15.ImageOptions.Image");
		this.barButtonItem15.Name = "barButtonItem15";
		toolTipTitleItem42.Text = "Computer cutoff";
		toolTipItem24.LeftIndent = 6;
		toolTipItem24.Text = "Set the mark at which a student can obtain a point in Computing";
		toolTipTitleItem43.LeftIndent = 6;
		toolTipTitleItem43.Text = "Press F1 for help.";
		superToolTip24.Items.Add(toolTipTitleItem42);
		superToolTip24.Items.Add(toolTipItem24);
		superToolTip24.Items.Add(item18);
		superToolTip24.Items.Add(toolTipTitleItem43);
		this.barButtonItem15.SuperTip = superToolTip24;
		this.barButtonItem14.ActAsDropDown = true;
		this.barButtonItem14.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem14.Caption = "Sub-Maths Cut-off";
		this.barButtonItem14.Id = 88;
		this.barButtonItem14.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem14.ImageOptions.Image");
		this.barButtonItem14.Name = "barButtonItem14";
		toolTipTitleItem44.Text = "Sub-Maths cutoff";
		toolTipItem25.LeftIndent = 6;
		toolTipItem25.Text = "Set the mark at which a student can obtain a point in Sub-Maths";
		toolTipTitleItem45.LeftIndent = 6;
		toolTipTitleItem45.Text = "Press F1 for help.";
		superToolTip25.Items.Add(toolTipTitleItem44);
		superToolTip25.Items.Add(toolTipItem25);
		superToolTip25.Items.Add(item19);
		superToolTip25.Items.Add(toolTipTitleItem45);
		this.barButtonItem14.SuperTip = superToolTip25;
		this.ribbonPageGroup17.AllowTextClipping = false;
		this.ribbonPageGroup17.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup17.ItemLinks.Add(this.barButtonItem5, "PO");
		this.ribbonPageGroup17.ItemLinks.Add(this.barButtonItem6, "PC");
		this.ribbonPageGroup17.KeyTip = "PR";
		this.ribbonPageGroup17.Name = "ribbonPageGroup17";
		this.ribbonPageGroup17.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup17.Text = "Process reports";
		this.barButtonItem5.Caption = "O Level reports";
		this.barButtonItem5.Id = 67;
		this.barButtonItem5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.Image");
		this.barButtonItem5.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.LargeImage");
		this.barButtonItem5.Name = "barButtonItem5";
		toolTipTitleItem46.Text = "Process reports";
		toolTipItem26.LeftIndent = 6;
		toolTipItem26.Text = "Use this option to process student reports";
		toolTipTitleItem47.LeftIndent = 6;
		toolTipTitleItem47.Text = "Press F1 for help.";
		superToolTip26.Items.Add(toolTipTitleItem46);
		superToolTip26.Items.Add(toolTipItem26);
		superToolTip26.Items.Add(item20);
		superToolTip26.Items.Add(toolTipTitleItem47);
		this.barButtonItem5.SuperTip = superToolTip26;
		this.barButtonItem6.Caption = "A Level reports";
		this.barButtonItem6.Id = 74;
		this.barButtonItem6.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem6.ImageOptions.Image");
		this.barButtonItem6.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem6.ImageOptions.LargeImage");
		this.barButtonItem6.Name = "barButtonItem6";
		toolTipTitleItem48.Text = "Process A-Level reports";
		toolTipItem27.LeftIndent = 6;
		toolTipItem27.Text = "Use this option to process student reports";
		toolTipTitleItem49.LeftIndent = 6;
		toolTipTitleItem49.Text = "Press F1 for help.";
		superToolTip27.Items.Add(toolTipTitleItem48);
		superToolTip27.Items.Add(toolTipItem27);
		superToolTip27.Items.Add(item21);
		superToolTip27.Items.Add(toolTipTitleItem49);
		this.barButtonItem6.SuperTip = superToolTip27;
		this.ribbonPageGroup34.AllowTextClipping = false;
		this.ribbonPageGroup34.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup34.ItemLinks.Add(this.barButtonItem67);
		this.ribbonPageGroup34.Name = "ribbonPageGroup34";
		this.ribbonPageGroup34.Text = "Mark sheets";
		this.barButtonItem67.Caption = "Mark Sheets";
		this.barButtonItem67.Id = 422;
		this.barButtonItem67.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem67.ImageOptions.Image");
		this.barButtonItem67.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem67.ImageOptions.LargeImage");
		this.barButtonItem67.Name = "barButtonItem67";
		this.ribbonPageGroup48.AllowTextClipping = false;
		this.ribbonPageGroup48.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup48.ItemLinks.Add(this.barButtonItem214);
		this.ribbonPageGroup48.Name = "ribbonPageGroup48";
		this.ribbonPageGroup48.Text = "Promotion";
		this.barButtonItem214.ActAsDropDown = true;
		this.barButtonItem214.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem214.Caption = "Promote";
		this.barButtonItem214.Id = 668;
		this.barButtonItem214.ImageOptions.Image = I_Xtreme.Properties.Resources.promote16;
		this.barButtonItem214.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.promote32;
		this.barButtonItem214.Name = "barButtonItem214";
		toolTipTitleItem50.Text = "Promote students";
		toolTipItem28.LeftIndent = 6;
		toolTipItem28.Text = "Use this option to promote students to next classes";
		toolTipTitleItem51.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem51.Appearance.Options.UseImage = true;
		toolTipTitleItem51.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem51.LeftIndent = 6;
		toolTipTitleItem51.Text = "Press F1 for help";
		superToolTip28.Items.Add(toolTipTitleItem50);
		superToolTip28.Items.Add(toolTipItem28);
		superToolTip28.Items.Add(item22);
		superToolTip28.Items.Add(toolTipTitleItem51);
		this.barButtonItem214.SuperTip = superToolTip28;
		this.ribbonPageGroup47.AllowTextClipping = false;
		this.ribbonPageGroup47.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup47.ItemLinks.Add(this.barButtonItem212);
		this.ribbonPageGroup47.Name = "ribbonPageGroup47";
		toolTipTitleItem52.Text = "Teacher evaluation";
		toolTipItem29.LeftIndent = 6;
		toolTipItem29.Text = "Evaluate teaching staff by getting total subjects taught per month";
		toolTipTitleItem53.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem53.Appearance.Options.UseImage = true;
		toolTipTitleItem53.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem53.LeftIndent = 6;
		toolTipTitleItem53.Text = "Press F1 for help";
		superToolTip29.Items.Add(toolTipTitleItem52);
		superToolTip29.Items.Add(toolTipItem29);
		superToolTip29.Items.Add(item23);
		superToolTip29.Items.Add(toolTipTitleItem53);
		this.ribbonPageGroup47.SuperTip = superToolTip29;
		this.ribbonPageGroup47.Text = "Teacher Valuation";
		this.barButtonItem212.ActAsDropDown = true;
		this.barButtonItem212.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem212.Caption = "Lessons Count";
		this.barButtonItem212.Id = 661;
		this.barButtonItem212.ImageOptions.Image = I_Xtreme.Properties.Resources.counter16;
		this.barButtonItem212.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.counter32;
		this.barButtonItem212.Name = "barButtonItem212";
		toolTipTitleItem54.Text = "Teacher Valuation";
		toolTipItem30.LeftIndent = 6;
		toolTipItem30.Text = "Valuate teaching staff by getting total subjects taught per month";
		toolTipTitleItem55.Appearance.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem55.Appearance.Options.UseImage = true;
		toolTipTitleItem55.ImageOptions.Image = I_Xtreme.Properties.Resources.help;
		toolTipTitleItem55.LeftIndent = 6;
		toolTipTitleItem55.Text = "Press F1 for help";
		superToolTip30.Items.Add(toolTipTitleItem54);
		superToolTip30.Items.Add(toolTipItem30);
		superToolTip30.Items.Add(item24);
		superToolTip30.Items.Add(toolTipTitleItem55);
		this.barButtonItem212.SuperTip = superToolTip30;
		this.ribbonAccounts.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[7] { this.ribbonPageGroup3, this.ribbonPageGroup7, this.ribbonPageGroup4, this.ribbonPageGroup5, this.ribbonPageGroup8, this.ribbonPageGroup27, this.ribbonPageGroup46 });
		this.ribbonAccounts.KeyTip = "AO";
		this.ribbonAccounts.Name = "ribbonAccounts";
		this.ribbonAccounts.Text = "Accounts";
		this.ribbonPageGroup3.AllowTextClipping = false;
		this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem23, "BN");
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem154);
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem153);
		this.ribbonPageGroup3.KeyTip = "BA";
		this.ribbonPageGroup3.Name = "ribbonPageGroup3";
		this.ribbonPageGroup3.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup3.Text = "Assets";
		this.barButtonItem23.Caption = "Add/Edit Account";
		this.barButtonItem23.Id = 102;
		this.barButtonItem23.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem23.ImageOptions.Image");
		this.barButtonItem23.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem23.ImageOptions.LargeImage");
		this.barButtonItem23.Name = "barButtonItem23";
		toolTipTitleItem56.Text = "Add/Edit Accounts";
		toolTipItem31.LeftIndent = 6;
		toolTipItem31.Text = "Use this option to add or remove an account";
		toolTipTitleItem57.LeftIndent = 6;
		toolTipTitleItem57.Text = "Press F1 for help.";
		superToolTip31.Items.Add(toolTipTitleItem56);
		superToolTip31.Items.Add(toolTipItem31);
		superToolTip31.Items.Add(item25);
		superToolTip31.Items.Add(toolTipTitleItem57);
		this.barButtonItem23.SuperTip = superToolTip31;
		this.barButtonItem154.Caption = "Chart of Accounts";
		this.barButtonItem154.Id = 570;
		this.barButtonItem154.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem154.ImageOptions.Image");
		this.barButtonItem154.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem154.ImageOptions.LargeImage");
		this.barButtonItem154.Name = "barButtonItem154";
		this.barButtonItem153.Caption = "Fixed Assets";
		this.barButtonItem153.Id = 569;
		this.barButtonItem153.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem153.ImageOptions.Image");
		this.barButtonItem153.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem153.ImageOptions.LargeImage");
		this.barButtonItem153.Name = "barButtonItem153";
		this.ribbonPageGroup7.AllowTextClipping = false;
		this.ribbonPageGroup7.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem25, "C");
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem159);
		this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItem160);
		this.ribbonPageGroup7.KeyTip = "BU";
		this.ribbonPageGroup7.Name = "ribbonPageGroup7";
		this.ribbonPageGroup7.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup7.Text = "Budget";
		this.barButtonItem25.Caption = "Create";
		this.barButtonItem25.Id = 104;
		this.barButtonItem25.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem25.ImageOptions.Image");
		this.barButtonItem25.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem25.ImageOptions.LargeImage");
		this.barButtonItem25.Name = "barButtonItem25";
		toolTipTitleItem58.Text = "Create Budget";
		toolTipItem32.LeftIndent = 6;
		toolTipItem32.Text = "Create a new budget";
		toolTipTitleItem59.LeftIndent = 6;
		toolTipTitleItem59.Text = "Press F1 for help.";
		superToolTip32.Items.Add(toolTipTitleItem58);
		superToolTip32.Items.Add(toolTipItem32);
		superToolTip32.Items.Add(item26);
		superToolTip32.Items.Add(toolTipTitleItem59);
		this.barButtonItem25.SuperTip = superToolTip32;
		this.barButtonItem159.ActAsDropDown = true;
		this.barButtonItem159.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem159.Caption = "Edit";
		this.barButtonItem159.Id = 578;
		this.barButtonItem159.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem159.ImageOptions.Image");
		this.barButtonItem159.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem159.ImageOptions.LargeImage");
		this.barButtonItem159.Name = "barButtonItem159";
		toolTipTitleItem60.Text = "Edit budget";
		toolTipItem33.LeftIndent = 6;
		toolTipItem33.Text = "Edit an existing budget";
		toolTipTitleItem61.LeftIndent = 6;
		toolTipTitleItem61.Text = "Press F1 for help.";
		superToolTip33.Items.Add(toolTipTitleItem60);
		superToolTip33.Items.Add(toolTipItem33);
		superToolTip33.Items.Add(item27);
		superToolTip33.Items.Add(toolTipTitleItem61);
		this.barButtonItem159.SuperTip = superToolTip33;
		this.barButtonItem160.Caption = "Delete Item";
		this.barButtonItem160.Id = 579;
		this.barButtonItem160.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem160.ImageOptions.Image");
		this.barButtonItem160.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem160.ImageOptions.LargeImage");
		this.barButtonItem160.Name = "barButtonItem160";
		this.ribbonPageGroup4.AllowTextClipping = false;
		this.ribbonPageGroup4.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem27, "SU");
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem28, "R");
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem29, "SD");
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem35, true);
		this.ribbonPageGroup4.KeyTip = "ST";
		this.ribbonPageGroup4.Name = "ribbonPageGroup4";
		this.ribbonPageGroup4.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup4.Text = "Student accounts";
		this.barButtonItem27.Caption = "Append Fees";
		this.barButtonItem27.Id = 106;
		this.barButtonItem27.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem27.ImageOptions.Image");
		this.barButtonItem27.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem27.ImageOptions.LargeImage");
		this.barButtonItem27.Name = "barButtonItem27";
		toolTipTitleItem62.Text = "Append Fees";
		toolTipItem34.LeftIndent = 6;
		toolTipItem34.Text = "Attach (Debit) student accounts with fees and other requirements";
		toolTipTitleItem63.LeftIndent = 6;
		toolTipTitleItem63.Text = "Press F1 for help.";
		superToolTip34.Items.Add(toolTipTitleItem62);
		superToolTip34.Items.Add(toolTipItem34);
		superToolTip34.Items.Add(item28);
		superToolTip34.Items.Add(toolTipTitleItem63);
		this.barButtonItem27.SuperTip = superToolTip34;
		this.barButtonItem28.Caption = "Pay Fees";
		this.barButtonItem28.Id = 107;
		this.barButtonItem28.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem28.ImageOptions.Image");
		this.barButtonItem28.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem28.ImageOptions.LargeImage");
		this.barButtonItem28.Name = "barButtonItem28";
		toolTipTitleItem64.Text = "Pay Fees";
		toolTipItem35.LeftIndent = 6;
		toolTipItem35.Text = "Receive fees payments FROM tbl_Stud";
		toolTipTitleItem65.LeftIndent = 6;
		toolTipTitleItem65.Text = "Press F1 for help.";
		superToolTip35.Items.Add(toolTipTitleItem64);
		superToolTip35.Items.Add(toolTipItem35);
		superToolTip35.Items.Add(item29);
		superToolTip35.Items.Add(toolTipTitleItem65);
		this.barButtonItem28.SuperTip = superToolTip35;
		this.barButtonItem29.Caption = "Reports";
		this.barButtonItem29.Id = 108;
		this.barButtonItem29.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem29.ImageOptions.Image");
		this.barButtonItem29.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem29.ImageOptions.LargeImage");
		this.barButtonItem29.Name = "barButtonItem29";
		toolTipTitleItem66.Text = "Reports";
		toolTipItem36.LeftIndent = 6;
		toolTipItem36.Text = "Students' financial reports";
		toolTipTitleItem67.LeftIndent = 6;
		toolTipTitleItem67.Text = "Press F1 for help.";
		superToolTip36.Items.Add(toolTipTitleItem66);
		superToolTip36.Items.Add(toolTipItem36);
		superToolTip36.Items.Add(item30);
		superToolTip36.Items.Add(toolTipTitleItem67);
		this.barButtonItem29.SuperTip = superToolTip36;
		this.barButtonItem35.ActAsDropDown = true;
		this.barButtonItem35.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem35.Caption = "Ledgers";
		this.barButtonItem35.Id = 114;
		this.barButtonItem35.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem35.ImageOptions.Image");
		this.barButtonItem35.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem35.ImageOptions.LargeImage");
		this.barButtonItem35.Name = "barButtonItem35";
		toolTipTitleItem68.Text = "Ledgers";
		toolTipItem37.LeftIndent = 6;
		toolTipItem37.Text = "Students' ledger accounts";
		toolTipTitleItem69.LeftIndent = 6;
		toolTipTitleItem69.Text = "Press F1 for help.";
		superToolTip37.Items.Add(toolTipTitleItem68);
		superToolTip37.Items.Add(toolTipItem37);
		superToolTip37.Items.Add(item31);
		superToolTip37.Items.Add(toolTipTitleItem69);
		this.barButtonItem35.SuperTip = superToolTip37;
		this.ribbonPageGroup5.AllowTextClipping = false;
		this.ribbonPageGroup5.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem24, "QU");
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem37, "QI");
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem36, "F");
		this.ribbonPageGroup5.KeyTip = "SC";
		this.ribbonPageGroup5.Name = "ribbonPageGroup5";
		this.ribbonPageGroup5.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup5.Text = "School accounts";
		this.barButtonItem24.Caption = "Quick Income";
		this.barButtonItem24.Id = 124;
		this.barButtonItem24.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem24.ImageOptions.Image");
		this.barButtonItem24.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem24.ImageOptions.LargeImage");
		this.barButtonItem24.Name = "barButtonItem24";
		toolTipTitleItem70.Text = "Quick income";
		toolTipItem38.LeftIndent = 6;
		toolTipItem38.Text = "Use this option to register an income received by the school outside students' payable requirements";
		toolTipTitleItem71.LeftIndent = 6;
		toolTipTitleItem71.Text = "Press F1 for help.";
		superToolTip38.Items.Add(toolTipTitleItem70);
		superToolTip38.Items.Add(toolTipItem38);
		superToolTip38.Items.Add(item32);
		superToolTip38.Items.Add(toolTipTitleItem71);
		this.barButtonItem24.SuperTip = superToolTip38;
		this.barButtonItem37.Caption = "Quick Expenses ";
		this.barButtonItem37.Id = 116;
		this.barButtonItem37.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem37.ImageOptions.Image");
		this.barButtonItem37.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem37.ImageOptions.LargeImage");
		this.barButtonItem37.Name = "barButtonItem37";
		toolTipTitleItem72.Text = "Quick expenses";
		toolTipItem39.LeftIndent = 6;
		toolTipItem39.Text = "Use this option to register an expense made by the school.";
		toolTipTitleItem73.LeftIndent = 6;
		toolTipTitleItem73.Text = "Press F1 for help.";
		superToolTip39.Items.Add(toolTipTitleItem72);
		superToolTip39.Items.Add(toolTipItem39);
		superToolTip39.Items.Add(item33);
		superToolTip39.Items.Add(toolTipTitleItem73);
		this.barButtonItem37.SuperTip = superToolTip39;
		this.barButtonItem36.Caption = "Financial Reports";
		this.barButtonItem36.Id = 115;
		this.barButtonItem36.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem36.ImageOptions.Image");
		this.barButtonItem36.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem36.ImageOptions.LargeImage");
		this.barButtonItem36.Name = "barButtonItem36";
		toolTipTitleItem74.Text = "Financial report";
		toolTipItem40.LeftIndent = 6;
		toolTipItem40.Text = "Financial reports regarding all the school's accounts";
		toolTipTitleItem75.LeftIndent = 6;
		toolTipTitleItem75.Text = "Press F1 for help.";
		superToolTip40.Items.Add(toolTipTitleItem74);
		superToolTip40.Items.Add(toolTipItem40);
		superToolTip40.Items.Add(item34);
		superToolTip40.Items.Add(toolTipTitleItem75);
		this.barButtonItem36.SuperTip = superToolTip40;
		this.ribbonPageGroup8.AllowTextClipping = false;
		this.ribbonPageGroup8.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem26, "EP");
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem39, "P");
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem99, "EL");
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem34, true, "EO");
		this.ribbonPageGroup8.KeyTip = "EM";
		this.ribbonPageGroup8.Name = "ribbonPageGroup8";
		this.ribbonPageGroup8.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup8.Text = "Employee accounts";
		this.barButtonItem26.Caption = "Append Debts";
		this.barButtonItem26.Id = 174;
		this.barButtonItem26.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem26.ImageOptions.Image");
		this.barButtonItem26.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem26.ImageOptions.LargeImage");
		this.barButtonItem26.Name = "barButtonItem26";
		toolTipTitleItem76.Text = "Append Debts";
		toolTipItem41.LeftIndent = 6;
		toolTipItem41.Text = "Credit employee accounts and Debit school accounts";
		toolTipTitleItem77.LeftIndent = 6;
		toolTipTitleItem77.Text = "Press F1 for help";
		superToolTip41.Items.Add(toolTipTitleItem76);
		superToolTip41.Items.Add(toolTipItem41);
		superToolTip41.Items.Add(item35);
		superToolTip41.Items.Add(toolTipTitleItem77);
		this.barButtonItem26.SuperTip = superToolTip41;
		this.barButtonItem39.Caption = "Pay Debts";
		this.barButtonItem39.Id = 118;
		this.barButtonItem39.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem39.ImageOptions.Image");
		this.barButtonItem39.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem39.ImageOptions.LargeImage");
		this.barButtonItem39.Name = "barButtonItem39";
		toolTipTitleItem78.Text = "Pay Debts";
		toolTipItem42.LeftIndent = 6;
		toolTipItem42.Text = "Pay employee debts";
		toolTipTitleItem79.LeftIndent = 6;
		toolTipTitleItem79.Text = "Press F1 for help.";
		superToolTip42.Items.Add(toolTipTitleItem78);
		superToolTip42.Items.Add(toolTipItem42);
		superToolTip42.Items.Add(item36);
		superToolTip42.Items.Add(toolTipTitleItem79);
		this.barButtonItem39.SuperTip = superToolTip42;
		this.barButtonItem99.Caption = "Reports";
		this.barButtonItem99.Id = 472;
		this.barButtonItem99.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem99.ImageOptions.Image");
		this.barButtonItem99.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem99.ImageOptions.LargeImage");
		this.barButtonItem99.Name = "barButtonItem99";
		toolTipTitleItem80.Text = "Reports";
		toolTipItem43.LeftIndent = 6;
		toolTipItem43.Text = "Employee financial reports";
		toolTipTitleItem81.LeftIndent = 6;
		toolTipTitleItem81.Text = "Press F1 for help.";
		superToolTip43.Items.Add(toolTipTitleItem80);
		superToolTip43.Items.Add(toolTipItem43);
		superToolTip43.Items.Add(item37);
		superToolTip43.Items.Add(toolTipTitleItem81);
		this.barButtonItem99.SuperTip = superToolTip43;
		this.barButtonItem34.ActAsDropDown = true;
		this.barButtonItem34.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem34.Caption = "Ledgers";
		this.barButtonItem34.CausesValidation = true;
		this.barButtonItem34.Id = 113;
		this.barButtonItem34.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem34.ImageOptions.Image");
		this.barButtonItem34.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem34.ImageOptions.LargeImage");
		this.barButtonItem34.Name = "barButtonItem34";
		toolTipTitleItem82.Text = "Ledgers";
		toolTipItem44.LeftIndent = 6;
		toolTipItem44.Text = "Employee ledgers";
		toolTipTitleItem83.LeftIndent = 6;
		toolTipTitleItem83.Text = "Press F1 for help.";
		superToolTip44.Items.Add(toolTipTitleItem82);
		superToolTip44.Items.Add(toolTipItem44);
		superToolTip44.Items.Add(item38);
		superToolTip44.Items.Add(toolTipTitleItem83);
		this.barButtonItem34.SuperTip = superToolTip44;
		this.ribbonPageGroup27.AllowTextClipping = false;
		this.ribbonPageGroup27.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup27.ItemLinks.Add(this.barButtonItem38, "ED");
		this.ribbonPageGroup27.ItemLinks.Add(this.barButtonItem57, "EI");
		this.ribbonPageGroup27.ItemLinks.Add(this.barButtonItem58, "ET");
		this.ribbonPageGroup27.KeyTip = "D";
		this.ribbonPageGroup27.Name = "ribbonPageGroup27";
		this.ribbonPageGroup27.Text = "Data editing";
		this.barButtonItem38.Caption = "Fees Payment";
		this.barButtonItem38.Id = 182;
		this.barButtonItem38.Name = "barButtonItem38";
		this.barButtonItem38.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		toolTipTitleItem84.Text = "Edit student payments";
		toolTipItem45.LeftIndent = 6;
		toolTipItem45.Text = "Edit student payments. This option will remove the last item on the ledger";
		toolTipTitleItem85.LeftIndent = 6;
		toolTipTitleItem85.Text = "Press F1 for help.";
		superToolTip45.Items.Add(toolTipTitleItem84);
		superToolTip45.Items.Add(toolTipItem45);
		superToolTip45.Items.Add(item39);
		superToolTip45.Items.Add(toolTipTitleItem85);
		this.barButtonItem38.SuperTip = superToolTip45;
		this.barButtonItem57.Caption = "Quick Transactions";
		this.barButtonItem57.Id = 185;
		this.barButtonItem57.Name = "barButtonItem57";
		this.barButtonItem57.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		toolTipTitleItem86.Text = "Edit quick transactions";
		toolTipItem46.LeftIndent = 6;
		toolTipItem46.Text = "Use this option to edit quick Expenses/Income transactions";
		toolTipTitleItem87.LeftIndent = 6;
		toolTipTitleItem87.Text = "Press F1 for help";
		superToolTip46.Items.Add(toolTipTitleItem86);
		superToolTip46.Items.Add(toolTipItem46);
		superToolTip46.Items.Add(item40);
		superToolTip46.Items.Add(toolTipTitleItem87);
		this.barButtonItem57.SuperTip = superToolTip46;
		this.barButtonItem58.Caption = "Employee payment";
		this.barButtonItem58.Id = 186;
		this.barButtonItem58.Name = "barButtonItem58";
		this.barButtonItem58.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		toolTipTitleItem88.Text = "Edit employee payments";
		toolTipItem47.LeftIndent = 6;
		toolTipItem47.Text = "Edit payments made to an employee";
		toolTipTitleItem89.LeftIndent = 6;
		toolTipTitleItem89.Text = "Press F1 for help";
		superToolTip47.Items.Add(toolTipTitleItem88);
		superToolTip47.Items.Add(toolTipItem47);
		superToolTip47.Items.Add(item41);
		superToolTip47.Items.Add(toolTipTitleItem89);
		this.barButtonItem58.SuperTip = superToolTip47;
		this.ribbonPageGroup46.AllowTextClipping = false;
		this.ribbonPageGroup46.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup46.ItemLinks.Add(this.barButtonItem194);
		this.ribbonPageGroup46.ItemLinks.Add(this.barButtonItem195);
		this.ribbonPageGroup46.ItemLinks.Add(this.barButtonItem206);
		this.ribbonPageGroup46.Name = "ribbonPageGroup46";
		this.ribbonPageGroup46.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
		this.ribbonPageGroup46.Text = "Printing and Exporting";
		this.barButtonItem194.Caption = "Print";
		this.barButtonItem194.Id = 623;
		this.barButtonItem194.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem194.ImageOptions.Image");
		this.barButtonItem194.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem194.ImageOptions.LargeImage");
		this.barButtonItem194.Name = "barButtonItem194";
		this.barButtonItem195.Caption = "Preview";
		this.barButtonItem195.Id = 624;
		this.barButtonItem195.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem195.ImageOptions.Image");
		this.barButtonItem195.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem195.ImageOptions.LargeImage");
		this.barButtonItem195.Name = "barButtonItem195";
		this.barButtonItem206.Caption = "Export";
		this.barButtonItem206.Id = 654;
		this.barButtonItem206.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem206.ImageOptions.Image");
		this.barButtonItem206.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem206.ImageOptions.LargeImage");
		this.barButtonItem206.Name = "barButtonItem206";
		this.barEditItem1.Caption = "GP Cutoff";
		this.barEditItem1.Edit = null;
		this.barEditItem1.Id = 127;
		this.barEditItem1.Name = "barEditItem1";
		this.barEditItem2.Caption = "Computer Cutoff";
		this.barEditItem2.Edit = null;
		this.barEditItem2.Id = 128;
		this.barEditItem2.Name = "barEditItem2";
		this.barEditItem3.Caption = "Sub-Maths Cutoff";
		this.barEditItem3.Edit = null;
		this.barEditItem3.Id = 129;
		this.barEditItem3.Name = "barEditItem3";
		this.barButtonItem44.ActAsDropDown = true;
		this.barButtonItem44.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem44.Caption = "Expenses";
		this.barButtonItem44.Id = 134;
		this.barButtonItem44.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem44.ImageOptions.Image");
		this.barButtonItem44.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem44.ImageOptions.LargeImage");
		this.barButtonItem44.Name = "barButtonItem44";
		this.barButtonItem45.Caption = "Close";
		this.barButtonItem45.Id = 135;
		this.barButtonItem45.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem45.ImageOptions.Image");
		this.barButtonItem45.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem45.ImageOptions.LargeImage");
		this.barButtonItem45.Name = "barButtonItem45";
		this.barButtonItem46.Caption = "Preview";
		this.barButtonItem46.Id = 136;
		this.barButtonItem46.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem46.ImageOptions.Image");
		this.barButtonItem46.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem46.ImageOptions.LargeImage");
		this.barButtonItem46.Name = "barButtonItem46";
		this.barButtonItem47.Caption = "Print";
		this.barButtonItem47.Id = 137;
		this.barButtonItem47.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem47.ImageOptions.Image");
		this.barButtonItem47.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem47.ImageOptions.LargeImage");
		this.barButtonItem47.Name = "barButtonItem47";
		this.barButtonItem48.Caption = "Export";
		this.barButtonItem48.Id = 138;
		this.barButtonItem48.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem48.ImageOptions.Image");
		this.barButtonItem48.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem48.ImageOptions.LargeImage");
		this.barButtonItem48.Name = "barButtonItem48";
		toolTipTitleItem90.Text = "Export";
		toolTipItem48.LeftIndent = 6;
		toolTipItem48.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem91.LeftIndent = 6;
		toolTipTitleItem91.Text = "Press F1 for help";
		superToolTip48.Items.Add(toolTipTitleItem90);
		superToolTip48.Items.Add(toolTipItem48);
		superToolTip48.Items.Add(item42);
		superToolTip48.Items.Add(toolTipTitleItem91);
		this.barButtonItem48.SuperTip = superToolTip48;
		this.barButtonItem49.Caption = "Find";
		this.barButtonItem49.Id = 139;
		this.barButtonItem49.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem49.ImageOptions.Image");
		this.barButtonItem49.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem49.ImageOptions.LargeImage");
		this.barButtonItem49.Name = "barButtonItem49";
		this.barButtonItem50.ActAsDropDown = true;
		this.barButtonItem50.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem50.Caption = "Expenses analysis";
		this.barButtonItem50.Id = 140;
		this.barButtonItem50.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem50.ImageOptions.Image");
		this.barButtonItem50.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem50.ImageOptions.LargeImage");
		this.barButtonItem50.Name = "barButtonItem50";
		this.barButtonItem51.ActAsDropDown = true;
		this.barButtonItem51.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem51.Caption = "Income";
		this.barButtonItem51.Id = 141;
		this.barButtonItem51.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem51.ImageOptions.Image");
		this.barButtonItem51.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem51.ImageOptions.LargeImage");
		this.barButtonItem51.Name = "barButtonItem51";
		this.barButtonItem54.ActAsDropDown = true;
		this.barButtonItem54.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem54.Caption = "Exam Permits";
		this.barButtonItem54.Id = 144;
		this.barButtonItem54.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem54.ImageOptions.Image");
		this.barButtonItem54.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem54.ImageOptions.LargeImage");
		this.barButtonItem54.Name = "barButtonItem54";
		this.barButtonItem62.Caption = "General settings";
		this.barButtonItem62.Id = 152;
		this.barButtonItem62.Name = "barButtonItem62";
		this.barButtonItem63.Caption = "Users settings";
		this.barButtonItem63.Id = 153;
		this.barButtonItem63.Name = "barButtonItem63";
		this.ribbonGalleryBarItem1.Caption = "ribbonGalleryBarItem1";
		this.ribbonGalleryBarItem1.Id = 155;
		this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
		this.barButtonGS.Caption = "Grading Scale";
		this.barButtonGS.Id = 156;
		this.barButtonGS.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonGS.ImageOptions.Image");
		this.barButtonGS.Name = "barButtonGS";
		this.barButtonItemDS.Caption = "Division scale";
		this.barButtonItemDS.Id = 157;
		this.barButtonItemDS.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItemDS.ImageOptions.Image");
		this.barButtonItemDS.Name = "barButtonItemDS";
		this.barButtonItem64.Caption = "Grading scale";
		this.barButtonItem64.Id = 158;
		this.barButtonItem64.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem64.ImageOptions.Image");
		this.barButtonItem64.Name = "barButtonItem64";
		this.barButtonPB.Caption = "Paper balancing scale";
		this.barButtonPB.Id = 159;
		this.barButtonPB.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonPB.ImageOptions.Image");
		this.barButtonPB.Name = "barButtonPB";
		this.lookUpOrders.Edit = null;
		this.lookUpOrders.EditWidth = 100;
		this.lookUpOrders.Id = 162;
		this.lookUpOrders.Name = "lookUpOrders";
		this.barButtonAllSets.ActAsDropDown = true;
		this.barButtonAllSets.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonAllSets.Caption = "Marks";
		this.barButtonAllSets.Id = 244;
		this.barButtonAllSets.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonAllSets.ImageOptions.Image");
		this.barButtonAllSets.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonAllSets.ImageOptions.LargeImage");
		this.barButtonAllSets.Name = "barButtonAllSets";
		this.barButtonItem1.ActAsDropDown = true;
		this.barButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem1.Caption = "Performance";
		this.barButtonItem1.Id = 253;
		this.barButtonItem1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem1.ImageOptions.Image");
		this.barButtonItem1.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem1.ImageOptions.LargeImage");
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem40.ActAsDropDown = true;
		this.barButtonItem40.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem40.Caption = "Grading";
		this.barButtonItem40.Id = 254;
		this.barButtonItem40.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem40.ImageOptions.Image");
		this.barButtonItem40.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem40.ImageOptions.LargeImage");
		this.barButtonItem40.Name = "barButtonItem40";
		this.printPreviewStaticItem1.Caption = "Nothing";
		this.printPreviewStaticItem1.Id = 302;
		this.printPreviewStaticItem1.LeftIndent = 1;
		this.printPreviewStaticItem1.Name = "printPreviewStaticItem1";
		this.printPreviewStaticItem1.RightIndent = 1;
		this.printPreviewStaticItem1.Type = "PageOfPages";
		this.barStaticItem1.Id = 303;
		this.barStaticItem1.Name = "barStaticItem1";
		this.barStaticItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.barButtonItem55.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
		this.barButtonItem55.Enabled = false;
		this.barButtonItem55.Id = 306;
		this.barButtonItem55.Name = "barButtonItem55";
		this.barButtonItem55.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.printPreviewStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.printPreviewStaticItem2.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.printPreviewStaticItem2.Caption = "100%";
		this.printPreviewStaticItem2.Id = 307;
		this.printPreviewStaticItem2.Name = "printPreviewStaticItem2";
		this.printPreviewStaticItem2.Size = new System.Drawing.Size(42, 0);
		this.printPreviewStaticItem2.Type = "ZoomFactorText";
		this.printPreviewStaticItem2.Width = 42;
		this.barButtonItem56.Caption = "Exit";
		this.barButtonItem56.Id = 309;
		this.barButtonItem56.Name = "barButtonItem56";
		this.barButtonItem59.Caption = "Connect to database";
		this.barButtonItem59.Id = 310;
		this.barButtonItem59.Name = "barButtonItem59";
		this.barStaticItem2.Caption = "Nothing";
		this.barStaticItem2.Id = 358;
		this.barStaticItem2.Name = "barStaticItem2";
		this.barStaticItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.barButtonItem60.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
		this.barButtonItem60.Enabled = false;
		this.barButtonItem60.Id = 361;
		this.barButtonItem60.Name = "barButtonItem60";
		this.barButtonItem60.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.barButtonItem41.Caption = "Student's Ledger";
		this.barButtonItem41.Id = 365;
		this.barButtonItem41.Name = "barButtonItem41";
		this.barButtonItem61.Caption = "Class Ledgers";
		this.barButtonItem61.Id = 366;
		this.barButtonItem61.Name = "barButtonItem61";
		this.barButtonItem65.ActAsDropDown = true;
		this.barButtonItem65.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem65.Caption = "Income statement";
		this.barButtonItem65.Id = 367;
		this.barButtonItem65.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem65.ImageOptions.Image");
		this.barButtonItem65.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem65.ImageOptions.LargeImage");
		this.barButtonItem65.Name = "barButtonItem65";
		this.barStaticItem3.Id = 416;
		this.barStaticItem3.Name = "barStaticItem3";
		this.barStaticItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.barButtonItem66.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
		this.barButtonItem66.Enabled = false;
		this.barButtonItem66.Id = 419;
		this.barButtonItem66.Name = "barButtonItem66";
		this.barButtonItem66.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime;
		this.barButtonItem68.Caption = "Close";
		this.barButtonItem68.Id = 423;
		this.barButtonItem68.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem68.ImageOptions.Image");
		this.barButtonItem68.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem68.ImageOptions.LargeImage");
		this.barButtonItem68.Name = "barButtonItem68";
		this.barButtonItem69.Caption = "Close";
		this.barButtonItem69.Id = 424;
		this.barButtonItem69.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem69.ImageOptions.Image");
		this.barButtonItem69.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem69.ImageOptions.LargeImage");
		this.barButtonItem69.Name = "barButtonItem69";
		this.barButtonItem70.Caption = "Print Priview";
		this.barButtonItem70.Id = 425;
		this.barButtonItem70.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem70.ImageOptions.Image");
		this.barButtonItem70.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem70.ImageOptions.LargeImage");
		this.barButtonItem70.Name = "barButtonItem70";
		this.barButtonItemPrintIE.Caption = "Print";
		this.barButtonItemPrintIE.Id = 427;
		this.barButtonItemPrintIE.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItemPrintIE.ImageOptions.Image");
		this.barButtonItemPrintIE.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItemPrintIE.ImageOptions.LargeImage");
		this.barButtonItemPrintIE.Name = "barButtonItemPrintIE";
		this.barButtonItem71.Caption = "Print";
		this.barButtonItem71.Id = 428;
		this.barButtonItem71.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem71.ImageOptions.Image");
		this.barButtonItem71.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem71.ImageOptions.LargeImage");
		this.barButtonItem71.Name = "barButtonItem71";
		this.barButtonItem72.Caption = "Preview";
		this.barButtonItem72.Id = 429;
		this.barButtonItem72.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem72.ImageOptions.Image");
		this.barButtonItem72.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem72.ImageOptions.LargeImage");
		this.barButtonItem72.Name = "barButtonItem72";
		this.barButtonItem77.Caption = "Detailed view";
		this.barButtonItem77.Id = 434;
		this.barButtonItem77.Name = "barButtonItem77";
		this.barButtonItem78.Caption = "Simple view";
		this.barButtonItem78.Id = 435;
		this.barButtonItem78.Name = "barButtonItem78";
		this.barButtonItem79.ActAsDropDown = true;
		this.barButtonItem79.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem79.Caption = "Fees collection";
		this.barButtonItem79.Id = 436;
		this.barButtonItem79.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem79.ImageOptions.Image");
		this.barButtonItem79.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem79.ImageOptions.LargeImage");
		this.barButtonItem79.Name = "barButtonItem79";
		this.barButtonItem80.Caption = "Detailed view";
		this.barButtonItem80.Id = 437;
		this.barButtonItem80.Name = "barButtonItem80";
		this.barButtonItem81.Caption = "Grouped view";
		this.barButtonItem81.Id = 438;
		this.barButtonItem81.Name = "barButtonItem81";
		this.barEditItem7.Edit = null;
		this.barEditItem7.EditWidth = 80;
		this.barEditItem7.Id = 443;
		this.barEditItem7.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barEditItem7.ImageOptions.Image");
		this.barEditItem7.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barEditItem7.ImageOptions.LargeImage");
		this.barEditItem7.Name = "barEditItem7";
		this.barButtonItem82.ActAsDropDown = true;
		this.barButtonItem82.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem82.Caption = "Budget comparison";
		this.barButtonItem82.Id = 444;
		this.barButtonItem82.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem82.ImageOptions.Image");
		this.barButtonItem82.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem82.ImageOptions.LargeImage");
		this.barButtonItem82.Name = "barButtonItem82";
		toolTipTitleItem92.Text = "Budget preview";
		toolTipItem49.LeftIndent = 6;
		toolTipItem49.Text = "Select a year from the dropdown list on the far left and click here to review any budget for the whole year";
		toolTipTitleItem93.LeftIndent = 6;
		toolTipTitleItem93.Text = "Press F1 for help";
		superToolTip49.Items.Add(toolTipTitleItem92);
		superToolTip49.Items.Add(toolTipItem49);
		superToolTip49.Items.Add(item43);
		superToolTip49.Items.Add(toolTipTitleItem93);
		this.barButtonItem82.SuperTip = superToolTip49;
		this.cboSemesterBudget.Edit = null;
		this.cboSemesterBudget.EditWidth = 100;
		this.cboSemesterBudget.Id = 445;
		this.cboSemesterBudget.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("cboSemesterBudget.ImageOptions.Image");
		this.cboSemesterBudget.Name = "cboSemesterBudget";
		toolTipTitleItem94.Text = "Budget preview";
		toolTipItem50.LeftIndent = 6;
		toolTipItem50.Text = "Use this option to review budgets created per semester";
		toolTipTitleItem95.LeftIndent = 6;
		toolTipTitleItem95.Text = "Press F1 for help";
		superToolTip50.Items.Add(toolTipTitleItem94);
		superToolTip50.Items.Add(toolTipItem50);
		superToolTip50.Items.Add(item44);
		superToolTip50.Items.Add(toolTipTitleItem95);
		this.cboSemesterBudget.SuperTip = superToolTip50;
		this.cboBudgetAnnual.Edit = null;
		this.cboBudgetAnnual.EditWidth = 100;
		this.cboBudgetAnnual.Id = 447;
		this.cboBudgetAnnual.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("cboBudgetAnnual.ImageOptions.Image");
		this.cboBudgetAnnual.Name = "cboBudgetAnnual";
		this.barButtonItem84.Caption = "All Employees";
		this.barButtonItem84.Id = 449;
		this.barButtonItem84.Name = "barButtonItem84";
		this.barButtonItem85.Caption = "Currently Working";
		this.barButtonItem85.Id = 450;
		this.barButtonItem85.Name = "barButtonItem85";
		this.barButtonItem86.Caption = "Discontinued";
		this.barButtonItem86.Id = 451;
		this.barButtonItem86.Name = "barButtonItem86";
		this.barButtonItem87.Caption = "All Employees";
		this.barButtonItem87.Id = 452;
		this.barButtonItem87.Name = "barButtonItem87";
		this.barButtonItem88.Caption = "Currently Working";
		this.barButtonItem88.Id = 453;
		this.barButtonItem88.Name = "barButtonItem88";
		this.barButtonItem89.Caption = "Discontinued";
		this.barButtonItem89.Id = 454;
		this.barButtonItem89.Name = "barButtonItem89";
		this.barButtonItem91.Caption = "Connect to database";
		this.barButtonItem91.Id = 456;
		this.barButtonItem91.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem91.ImageOptions.Image");
		this.barButtonItem91.Name = "barButtonItem91";
		this.barLinkContainerItem1.Caption = "barLinkContainerItem1";
		this.barLinkContainerItem1.Id = 463;
		this.barLinkContainerItem1.Name = "barLinkContainerItem1";
		this.barListItem1.Caption = "barListItem1";
		this.barListItem1.Id = 464;
		this.barListItem1.Name = "barListItem1";
		this.barSubItem1.Caption = "barSubItem1";
		this.barSubItem1.Id = 465;
		this.barSubItem1.Name = "barSubItem1";
		this.barListItem2.Caption = "S.1";
		this.barListItem2.Id = 466;
		this.barListItem2.Name = "barListItem2";
		this.barListItem3.Caption = "S.2";
		this.barListItem3.Id = 467;
		this.barListItem3.Name = "barListItem3";
		this.barButtonItem95.Caption = "Edit student";
		this.barButtonItem95.Id = 468;
		this.barButtonItem95.Name = "barButtonItem95";
		this.barButtonItem96.Caption = "Delete student";
		this.barButtonItem96.Id = 469;
		this.barButtonItem96.Name = "barButtonItem96";
		this.barButtonItem97.Caption = "Receive fees";
		this.barButtonItem97.Id = 470;
		this.barButtonItem97.Name = "barButtonItem97";
		this.barButtonItem98.Caption = "Print";
		this.barButtonItem98.Id = 471;
		this.barButtonItem98.Name = "barButtonItem98";
		this.barButtonItem100.Caption = "Logout";
		this.barButtonItem100.Id = 475;
		this.barButtonItem100.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem100.ImageOptions.Image");
		this.barButtonItem100.Name = "barButtonItem100";
		this.barButtonItem103.Caption = "Report Comments";
		this.barButtonItem103.Id = 485;
		this.barButtonItem103.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem103.ImageOptions.Image");
		this.barButtonItem103.Name = "barButtonItem103";
		this.barButtonItem104.ActAsDropDown = true;
		this.barButtonItem104.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem104.Caption = "Points";
		this.barButtonItem104.Id = 486;
		this.barButtonItem104.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem104.ImageOptions.Image");
		this.barButtonItem104.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem104.ImageOptions.LargeImage");
		this.barButtonItem104.Name = "barButtonItem104";
		this.barButtonItem105.Caption = "Entire Class";
		this.barButtonItem105.Id = 487;
		this.barButtonItem105.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem105.ImageOptions.Image");
		this.barButtonItem105.Name = "barButtonItem105";
		this.barButtonItem106.Caption = "Single Student";
		this.barButtonItem106.Id = 488;
		this.barButtonItem106.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem106.ImageOptions.Image");
		this.barButtonItem106.Name = "barButtonItem106";
		this.barButtonItem107.Caption = "Entire Class";
		this.barButtonItem107.Id = 489;
		this.barButtonItem107.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem107.ImageOptions.Image");
		this.barButtonItem107.Name = "barButtonItem107";
		this.barButtonItem108.Caption = "Single Student";
		this.barButtonItem108.Id = 490;
		this.barButtonItem108.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem108.ImageOptions.Image");
		this.barButtonItem108.Name = "barButtonItem108";
		this.barButtonItem109.Caption = "Find Meal Card";
		this.barButtonItem109.Id = 491;
		this.barButtonItem109.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem109.ImageOptions.Image");
		this.barButtonItem109.Name = "barButtonItem109";
		this.barButtonItem110.Caption = "Entire Class";
		this.barButtonItem110.Id = 492;
		this.barButtonItem110.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem110.ImageOptions.Image");
		this.barButtonItem110.Name = "barButtonItem110";
		this.barButtonItem111.Caption = "Single Student";
		this.barButtonItem111.Id = 493;
		this.barButtonItem111.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem111.ImageOptions.Image");
		this.barButtonItem111.Name = "barButtonItem111";
		this.barButtonItem112.Caption = "Entire Class";
		this.barButtonItem112.Id = 494;
		this.barButtonItem112.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem112.ImageOptions.Image");
		this.barButtonItem112.Name = "barButtonItem112";
		this.barButtonItem113.Caption = "Single Student";
		this.barButtonItem113.Id = 495;
		this.barButtonItem113.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem113.ImageOptions.Image");
		this.barButtonItem113.Name = "barButtonItem113";
		this.barButtonItem114.Caption = "Settings";
		this.barButtonItem114.Id = 496;
		this.barButtonItem114.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem114.ImageOptions.Image");
		this.barButtonItem114.Name = "barButtonItem114";
		this.barButtonItem115.Caption = "User Logins";
		this.barButtonItem115.Id = 497;
		this.barButtonItem115.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem115.ImageOptions.Image");
		this.barButtonItem115.Name = "barButtonItem115";
		this.barButtonItem116.Caption = "Subject Logins";
		this.barButtonItem116.Id = 498;
		this.barButtonItem116.Name = "barButtonItem116";
		this.barButtonItem117.Caption = "Connect to database";
		this.barButtonItem117.Id = 499;
		this.barButtonItem117.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem117.ImageOptions.Image");
		this.barButtonItem117.Name = "barButtonItem117";
		this.barButtonItem118.Caption = "Log out";
		this.barButtonItem118.Id = 500;
		this.barButtonItem118.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem118.ImageOptions.Image");
		this.barButtonItem118.Name = "barButtonItem118";
		this.barButtonItem119.Caption = "Change Bank";
		this.barButtonItem119.Id = 501;
		this.barButtonItem119.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem119.ImageOptions.Image");
		this.barButtonItem119.Name = "barButtonItem119";
		this.barEditItem6.Edit = null;
		this.barEditItem6.EditWidth = 150;
		this.barEditItem6.Id = 508;
		this.barEditItem6.Name = "barEditItem6";
		this.barButtonItem90.Caption = "barButtonItem90";
		this.barButtonItem90.Id = 509;
		this.barButtonItem90.Name = "barButtonItem90";
		this.barButtonItem92.Caption = "barButtonItem92";
		this.barButtonItem92.Id = 510;
		this.barButtonItem92.Name = "barButtonItem92";
		this.barSubItem2.Caption = "Create Gate Pass";
		this.barSubItem2.Id = 511;
		this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem102),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem120),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem121)
		});
		this.barSubItem2.Name = "barSubItem2";
		this.barButtonItem102.Id = 670;
		this.barButtonItem102.Name = "barButtonItem102";
		this.barButtonItem120.Id = 671;
		this.barButtonItem120.Name = "barButtonItem120";
		this.barButtonItem121.Id = 672;
		this.barButtonItem121.Name = "barButtonItem121";
		this.barButtonItem122.ActAsDropDown = true;
		this.barButtonItem122.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem122.Caption = "Gate Pass";
		this.barButtonItem122.Id = 515;
		this.barButtonItem122.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem122.ImageOptions.Image");
		this.barButtonItem122.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem122.ImageOptions.LargeImage");
		this.barButtonItem122.Name = "barButtonItem122";
		toolTipTitleItem96.Text = "Gate Pass";
		toolTipItem51.LeftIndent = 6;
		toolTipItem51.Text = "Click here to create Students' Gate Passes";
		toolTipTitleItem97.LeftIndent = 6;
		toolTipTitleItem97.Text = "Press F1 for more help";
		superToolTip51.Items.Add(toolTipTitleItem96);
		superToolTip51.Items.Add(toolTipItem51);
		superToolTip51.Items.Add(item45);
		superToolTip51.Items.Add(toolTipTitleItem97);
		this.barButtonItem122.SuperTip = superToolTip51;
		this.barButtonItem123.ActAsDropDown = true;
		this.barButtonItem123.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem123.Caption = "Meal Cards";
		this.barButtonItem123.Id = 516;
		this.barButtonItem123.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem123.ImageOptions.Image");
		this.barButtonItem123.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem123.ImageOptions.LargeImage");
		this.barButtonItem123.Name = "barButtonItem123";
		toolTipTitleItem98.Text = "Meal Cards";
		toolTipItem52.LeftIndent = 6;
		toolTipItem52.Text = "Click here to create Students' Meal Cards";
		toolTipTitleItem99.LeftIndent = 6;
		toolTipTitleItem99.Text = "Press F1 for more Help";
		superToolTip52.Items.Add(toolTipTitleItem98);
		superToolTip52.Items.Add(toolTipItem52);
		superToolTip52.Items.Add(item46);
		superToolTip52.Items.Add(toolTipTitleItem99);
		this.barButtonItem123.SuperTip = superToolTip52;
		this.barButtonItem126.ActAsDropDown = true;
		this.barButtonItem126.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem126.Caption = "Bank Payments";
		this.barButtonItem126.Id = 519;
		this.barButtonItem126.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem126.ImageOptions.Image");
		this.barButtonItem126.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem126.ImageOptions.LargeImage");
		this.barButtonItem126.Name = "barButtonItem126";
		this.barStaticItem4.Caption = "barStaticItem4";
		this.barStaticItem4.Id = 521;
		this.barStaticItem4.Name = "barStaticItem4";
		this.barStaticItem5.Caption = "barStaticItem5";
		this.barStaticItem5.Id = 522;
		this.barStaticItem5.Name = "barStaticItem5";
		this.barStaticItem6.Caption = "barStaticItem6";
		this.barStaticItem6.Id = 523;
		this.barStaticItem6.Name = "barStaticItem6";
		this.barButtonItem127.ActAsDropDown = true;
		this.barButtonItem127.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem127.Caption = "Ranking";
		this.barButtonItem127.Id = 524;
		this.barButtonItem127.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem127.ImageOptions.Image");
		this.barButtonItem127.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem127.ImageOptions.LargeImage");
		this.barButtonItem127.Name = "barButtonItem127";
		this.barButtonItem128.Caption = "Exit";
		this.barButtonItem128.Id = 525;
		this.barButtonItem128.Name = "barButtonItem128";
		this.barButtonItem129.Caption = "All Classes";
		this.barButtonItem129.Id = 526;
		this.barButtonItem129.Name = "barButtonItem129";
		this.barButtonItem130.Caption = "Class Not Assigned";
		this.barButtonItem130.Id = 527;
		this.barButtonItem130.Name = "barButtonItem130";
		this.barButtonItem131.Caption = "Back Side";
		this.barButtonItem131.Id = 528;
		this.barButtonItem131.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem131.ImageOptions.Image");
		this.barButtonItem131.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem131.ImageOptions.LargeImage");
		this.barButtonItem131.Name = "barButtonItem131";
		this.barButtonItem132.ActAsDropDown = true;
		this.barButtonItem132.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem132.Caption = "Create";
		this.barButtonItem132.Id = 529;
		this.barButtonItem132.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem132.ImageOptions.Image");
		this.barButtonItem132.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem132.ImageOptions.LargeImage");
		this.barButtonItem132.Name = "barButtonItem132";
		this.barButtonItem136.Caption = "Delete";
		this.barButtonItem136.Id = 533;
		this.barButtonItem136.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem136.ImageOptions.Image");
		this.barButtonItem136.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem136.ImageOptions.LargeImage");
		this.barButtonItem136.Name = "barButtonItem136";
		this.barButtonItem137.Caption = "Home";
		this.barButtonItem137.Id = 534;
		this.barButtonItem137.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem137.ImageOptions.Image");
		this.barButtonItem137.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem137.ImageOptions.LargeImage");
		this.barButtonItem137.Name = "barButtonItem137";
		this.barButtonItem138.Caption = "Print";
		this.barButtonItem138.Id = 535;
		this.barButtonItem138.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem138.ImageOptions.Image");
		this.barButtonItem138.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem138.ImageOptions.LargeImage");
		this.barButtonItem138.Name = "barButtonItem138";
		this.barButtonItem139.Caption = "Preview";
		this.barButtonItem139.Id = 536;
		this.barButtonItem139.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem139.ImageOptions.Image");
		this.barButtonItem139.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem139.ImageOptions.LargeImage");
		this.barButtonItem139.Name = "barButtonItem139";
		this.barButtonItem140.Caption = "Export";
		this.barButtonItem140.Id = 537;
		this.barButtonItem140.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem140.ImageOptions.Image");
		this.barButtonItem140.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem140.ImageOptions.LargeImage");
		this.barButtonItem140.Name = "barButtonItem140";
		toolTipTitleItem100.Text = "Export";
		toolTipItem53.LeftIndent = 6;
		toolTipItem53.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem101.LeftIndent = 6;
		toolTipTitleItem101.Text = "Press F1 for help.";
		superToolTip53.Items.Add(toolTipTitleItem100);
		superToolTip53.Items.Add(toolTipItem53);
		superToolTip53.Items.Add(item47);
		superToolTip53.Items.Add(toolTipTitleItem101);
		this.barButtonItem140.SuperTip = superToolTip53;
		this.barButtonItem141.Caption = "Documents";
		this.barButtonItem141.Id = 538;
		this.barButtonItem141.Name = "barButtonItem141";
		this.barButtonItem143.Caption = "Close";
		this.barButtonItem143.Id = 540;
		this.barButtonItem143.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem143.ImageOptions.Image");
		this.barButtonItem143.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem143.ImageOptions.LargeImage");
		this.barButtonItem143.Name = "barButtonItem143";
		this.barButtonItem144.Caption = "Balance <=";
		this.barButtonItem144.Id = 541;
		this.barButtonItem144.Name = "barButtonItem144";
		this.barButtonItem145.Caption = "Balance >=";
		this.barButtonItem145.Id = 542;
		this.barButtonItem145.Name = "barButtonItem145";
		this.barButtonItem146.Caption = "Advanced";
		this.barButtonItem146.Id = 543;
		this.barButtonItem146.Name = "barButtonItem146";
		this.barButtonItem147.Caption = "Per Student";
		this.barButtonItem147.Id = 544;
		this.barButtonItem147.Name = "barButtonItem147";
		this.barButtonItem147.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem148.ActAsDropDown = true;
		this.barButtonItem148.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem148.Caption = "General";
		this.barButtonItem148.Id = 545;
		this.barButtonItem148.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem148.ImageOptions.Image");
		this.barButtonItem148.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem148.ImageOptions.LargeImage");
		this.barButtonItem148.Name = "barButtonItem148";
		this.barButtonItem149.Caption = "Home";
		this.barButtonItem149.Id = 546;
		this.barButtonItem149.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem149.ImageOptions.Image");
		this.barButtonItem149.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem149.ImageOptions.LargeImage");
		this.barButtonItem149.Name = "barButtonItem149";
		this.barButtonItem52.ActAsDropDown = true;
		this.barButtonItem52.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem52.Caption = "Query Expenses";
		this.barButtonItem52.Id = 547;
		this.barButtonItem52.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem52.ImageOptions.Image");
		this.barButtonItem52.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem52.ImageOptions.LargeImage");
		this.barButtonItem52.Name = "barButtonItem52";
		this.barButtonItem53.ActAsDropDown = true;
		this.barButtonItem53.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem53.Caption = "Query Income";
		this.barButtonItem53.Id = 548;
		this.barButtonItem53.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem53.ImageOptions.Image");
		this.barButtonItem53.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem53.ImageOptions.LargeImage");
		this.barButtonItem53.Name = "barButtonItem53";
		this.barEditItem8.Caption = "Start:";
		this.barEditItem8.Edit = null;
		this.barEditItem8.Id = 551;
		this.barEditItem8.Name = "barEditItem8";
		this.barEditItem9.Caption = "End :";
		this.barEditItem9.Edit = null;
		this.barEditItem9.Id = 552;
		this.barEditItem9.Name = "barEditItem9";
		this.barButtonItem150.Caption = "OK";
		this.barButtonItem150.Id = 553;
		this.barButtonItem150.Name = "barButtonItem150";
		this.barEditItem10.Caption = "barEditItem10";
		this.barEditItem10.Edit = null;
		this.barEditItem10.Id = 554;
		this.barEditItem10.Name = "barEditItem10";
		this.barEditItem11.Caption = "barEditItem11";
		this.barEditItem11.Edit = null;
		this.barEditItem11.Id = 555;
		this.barEditItem11.Name = "barEditItem11";
		this.barButtonItem151.ActAsDropDown = true;
		this.barButtonItem151.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem151.Caption = "Statement of Affairs";
		this.barButtonItem151.Id = 556;
		this.barButtonItem151.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem151.ImageOptions.Image");
		this.barButtonItem151.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem151.ImageOptions.LargeImage");
		this.barButtonItem151.Name = "barButtonItem151";
		this.barCBOSemester.Edit = null;
		this.barCBOSemester.EditWidth = 150;
		this.barCBOSemester.Id = 562;
		this.barCBOSemester.Name = "barCBOSemester";
		this.barCBOSemesterIncome.Edit = null;
		this.barCBOSemesterIncome.EditWidth = 150;
		this.barCBOSemesterIncome.Id = 565;
		this.barCBOSemesterIncome.Name = "barCBOSemesterIncome";
		this.barButtonItem152.Caption = "Home";
		this.barButtonItem152.Id = 567;
		this.barButtonItem152.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem152.ImageOptions.Image");
		this.barButtonItem152.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem152.ImageOptions.LargeImage");
		this.barButtonItem152.Name = "barButtonItem152";
		this.barButtonItem155.Caption = "Print All";
		this.barButtonItem155.Id = 571;
		this.barButtonItem155.Name = "barButtonItem155";
		this.barButtonItem156.Caption = "Print Selected";
		this.barButtonItem156.Id = 572;
		this.barButtonItem156.Name = "barButtonItem156";
		this.barButtonItem157.Caption = "Delete";
		this.barButtonItem157.Id = 573;
		this.barButtonItem157.Name = "barButtonItem157";
		this.barButtonItem135.Caption = "Bursary Providers";
		this.barButtonItem135.Id = 575;
		this.barButtonItem135.Name = "barButtonItem135";
		this.barButtonItem158.Caption = "Bursary Students";
		this.barButtonItem158.Id = 576;
		this.barButtonItem158.Name = "barButtonItem158";
		this.barButtonItem161.Caption = "Print";
		this.barButtonItem161.Id = 580;
		this.barButtonItem161.Name = "barButtonItem161";
		this.barButtonItem162.Caption = "Export Budget";
		this.barButtonItem162.Id = 581;
		this.barButtonItem162.Name = "barButtonItem162";
		this.barButtonItem163.Caption = "Delete Item";
		this.barButtonItem163.Id = 582;
		this.barButtonItem163.Name = "barButtonItem163";
		this.barButtonItem164.Caption = "Preview";
		this.barButtonItem164.Id = 583;
		this.barButtonItem164.Name = "barButtonItem164";
		this.barButtonItem165.Caption = "Print";
		this.barButtonItem165.Id = 584;
		this.barButtonItem165.Name = "barButtonItem165";
		this.barButtonItem166.Caption = "Preview";
		this.barButtonItem166.Id = 585;
		this.barButtonItem166.Name = "barButtonItem166";
		this.barButtonItem167.Caption = "Export Budget";
		this.barButtonItem167.Id = 586;
		this.barButtonItem167.Name = "barButtonItem167";
		this.barButtonItem168.Caption = "Delete Item";
		this.barButtonItem168.Id = 587;
		this.barButtonItem168.Name = "barButtonItem168";
		this.barEditItem12.Edit = null;
		this.barEditItem12.EditWidth = 100;
		this.barEditItem12.Id = 588;
		this.barEditItem12.Name = "barEditItem12";
		this.barButtonItem170.Caption = "About iXtreme 2014";
		this.barButtonItem170.Id = 591;
		this.barButtonItem170.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem170.ImageOptions.Image");
		this.barButtonItem170.Name = "barButtonItem170";
		this.barButtonItem171.Caption = "Help";
		this.barButtonItem171.Id = 592;
		this.barButtonItem171.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem171.ImageOptions.Image");
		this.barButtonItem171.Name = "barButtonItem171";
		toolTipTitleItem102.Text = "Help";
		toolTipItem54.LeftIndent = 6;
		toolTipItem54.Text = "Press F1";
		superToolTip54.Items.Add(toolTipTitleItem102);
		superToolTip54.Items.Add(toolTipItem54);
		this.barButtonItem171.SuperTip = superToolTip54;
		this.barButtonItem175.Caption = "Export";
		this.barButtonItem175.Id = 602;
		this.barButtonItem175.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem175.ImageOptions.Image");
		this.barButtonItem175.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem175.ImageOptions.LargeImage");
		this.barButtonItem175.Name = "barButtonItem175";
		toolTipTitleItem103.Text = "Export";
		toolTipItem55.LeftIndent = 6;
		toolTipItem55.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem104.LeftIndent = 6;
		toolTipTitleItem104.Text = "Press F1 for help.";
		superToolTip55.Items.Add(toolTipTitleItem103);
		superToolTip55.Items.Add(toolTipItem55);
		superToolTip55.Items.Add(item48);
		superToolTip55.Items.Add(toolTipTitleItem104);
		this.barButtonItem175.SuperTip = superToolTip55;
		this.barButtonItem176.Caption = "Export";
		this.barButtonItem176.Id = 603;
		this.barButtonItem176.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem176.ImageOptions.Image");
		this.barButtonItem176.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem176.ImageOptions.LargeImage");
		this.barButtonItem176.Name = "barButtonItem176";
		toolTipTitleItem105.Text = "Export";
		toolTipItem56.LeftIndent = 6;
		toolTipItem56.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem106.LeftIndent = 6;
		toolTipTitleItem106.Text = "Press F1 for help.";
		superToolTip56.Items.Add(toolTipTitleItem105);
		superToolTip56.Items.Add(toolTipItem56);
		superToolTip56.Items.Add(item49);
		superToolTip56.Items.Add(toolTipTitleItem106);
		this.barButtonItem176.SuperTip = superToolTip56;
		this.barButtonItem179.Caption = "Export";
		this.barButtonItem179.Id = 606;
		this.barButtonItem179.ImageOptions.Image = I_Xtreme.Properties.Resources.exp16;
		this.barButtonItem179.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.exp32;
		this.barButtonItem179.Name = "barButtonItem179";
		toolTipTitleItem107.Text = "Export";
		toolTipItem57.LeftIndent = 6;
		toolTipItem57.Text = "Export to Excel (.Xlsx)";
		toolTipTitleItem108.LeftIndent = 6;
		toolTipTitleItem108.Text = "Press F1 for help.";
		superToolTip57.Items.Add(toolTipTitleItem107);
		superToolTip57.Items.Add(toolTipItem57);
		superToolTip57.Items.Add(item50);
		superToolTip57.Items.Add(toolTipTitleItem108);
		this.barButtonItem179.SuperTip = superToolTip57;
		this.barButtonItem183.Caption = "Edit/View";
		this.barButtonItem183.Id = 610;
		this.barButtonItem183.Name = "barButtonItem183";
		this.barButtonItem184.Caption = "Delete";
		this.barButtonItem184.Id = 611;
		this.barButtonItem184.Name = "barButtonItem184";
		this.barButtonItem190.Caption = "Print this Receipt";
		this.barButtonItem190.Id = 618;
		this.barButtonItem190.Name = "barButtonItem190";
		this.barButtonItem192.Caption = "Preview Full Ledger";
		this.barButtonItem192.Id = 620;
		this.barButtonItem192.Name = "barButtonItem192";
		this.barButtonItem193.Caption = "Print Full Ledger";
		this.barButtonItem193.Id = 621;
		this.barButtonItem193.Name = "barButtonItem193";
		this.barButtonItem196.Caption = "S.1";
		this.barButtonItem196.Id = 626;
		this.barButtonItem196.Name = "barButtonItem196";
		this.barButtonItem197.Caption = "S.2";
		this.barButtonItem197.Id = 627;
		this.barButtonItem197.Name = "barButtonItem197";
		this.barButtonItem198.Caption = "S.3";
		this.barButtonItem198.Id = 628;
		this.barButtonItem198.Name = "barButtonItem198";
		this.barButtonItem199.Caption = "S.4";
		this.barButtonItem199.Id = 629;
		this.barButtonItem199.Name = "barButtonItem199";
		this.barButtonItem200.Caption = "S.5";
		this.barButtonItem200.Id = 630;
		this.barButtonItem200.Name = "barButtonItem200";
		this.barButtonItem201.Caption = "S.6";
		this.barButtonItem201.Id = 631;
		this.barButtonItem201.Name = "barButtonItem201";
		this.barButtonItem202.Caption = "N/A";
		this.barButtonItem202.Id = 632;
		this.barButtonItem202.Name = "barButtonItem202";
		this.barCheckItem1.Caption = "All";
		this.barCheckItem1.Id = 633;
		this.barCheckItem1.Name = "barCheckItem1";
		this.barButtonItem203.Caption = "barButtonItem203";
		this.barButtonItem203.Id = 634;
		this.barButtonItem203.Name = "barButtonItem203";
		this.barCheckItem2.Caption = "S.1";
		this.barCheckItem2.Id = 635;
		this.barCheckItem2.Name = "barCheckItem2";
		this.barCheckItem3.Caption = "S.2";
		this.barCheckItem3.Id = 636;
		this.barCheckItem3.Name = "barCheckItem3";
		this.barCheckItem4.Caption = "S.3";
		this.barCheckItem4.Id = 637;
		this.barCheckItem4.Name = "barCheckItem4";
		this.barCheckItem5.Caption = "S.4";
		this.barCheckItem5.Id = 638;
		this.barCheckItem5.Name = "barCheckItem5";
		this.barCheckItem6.Caption = "S.5";
		this.barCheckItem6.Id = 639;
		this.barCheckItem6.Name = "barCheckItem6";
		this.barCheckItem7.Caption = "S.6";
		this.barCheckItem7.Id = 640;
		this.barCheckItem7.Name = "barCheckItem7";
		this.barCheckItem8.Caption = "All";
		this.barCheckItem8.Id = 641;
		this.barCheckItem8.Name = "barCheckItem8";
		this.barButtonItem204.Caption = "N/A";
		this.barButtonItem204.Id = 642;
		this.barButtonItem204.Name = "barButtonItem204";
		this.chkS1.Caption = "S.1";
		this.chkS1.Id = 643;
		this.chkS1.Name = "chkS1";
		this.chkS2.Caption = "S.2";
		this.chkS2.Id = 644;
		this.chkS2.Name = "chkS2";
		this.chkS3.Caption = "S.3";
		this.chkS3.Id = 645;
		this.chkS3.Name = "chkS3";
		this.chkS4.Caption = "S.4";
		this.chkS4.Id = 646;
		this.chkS4.Name = "chkS4";
		this.chkS5.Caption = "S.5";
		this.chkS5.Id = 647;
		this.chkS5.Name = "chkS5";
		this.chkS6.Caption = "S.6";
		this.chkS6.Id = 648;
		this.chkS6.Name = "chkS6";
		this.chkAll.Caption = "All";
		this.chkAll.Id = 649;
		this.chkAll.Name = "chkAll";
		this.chkNA.Caption = "N/A";
		this.chkNA.Id = 650;
		this.chkNA.Name = "chkNA";
		this.barEditItem13.Caption = "dd";
		this.barEditItem13.Edit = null;
		this.barEditItem13.Id = 651;
		this.barEditItem13.Name = "barEditItem13";
		this.barButtonItem191.ActAsDropDown = true;
		this.barButtonItem191.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem191.Caption = "Load Report";
		this.barButtonItem191.Id = 655;
		this.barButtonItem191.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem191.ImageOptions.LargeImage");
		this.barButtonItem191.Name = "barButtonItem191";
		this.barButtonItem207.Caption = "Remove Item";
		this.barButtonItem207.Id = 656;
		this.barButtonItem207.Name = "barButtonItem207";
		this.barButtonItem208.Caption = "Print Payslip";
		this.barButtonItem208.Id = 657;
		this.barButtonItem208.Name = "barButtonItem208";
		this.barButtonItem209.Caption = "Preview Payslip";
		this.barButtonItem209.Id = 658;
		this.barButtonItem209.Name = "barButtonItem209";
		this.barButtonItem210.Caption = "Export Payslip";
		this.barButtonItem210.Id = 659;
		this.barButtonItem210.Name = "barButtonItem210";
		this.barButtonItem211.Caption = "Change Bank";
		this.barButtonItem211.Id = 660;
		this.barButtonItem211.Name = "barButtonItem211";
		this.lblListType.Caption = "ListType";
		this.lblListType.Id = 666;
		this.lblListType.Name = "lblListType";
		this.layoutControl1.Controls.Add(this.lblSubHeader);
		this.layoutControl1.Controls.Add(this.lblHeader);
		this.layoutControl1.Controls.Add(this.pivotGridMarkSheets);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup2;
		this.layoutControl1.Size = new System.Drawing.Size(823, 540);
		this.layoutControl1.TabIndex = 3;
		this.layoutControl1.Text = "layoutControl1";
		this.pivotGridMarkSheets.Appearance.Cell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.Cell.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.ColumnHeaderArea.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.CustomTotalCell.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.DataHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.DataHeaderArea.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.Empty.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.ExpandButton.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FieldHeader.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FieldHeader.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FieldValue.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FieldValue.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FieldValueTotal.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FilterHeaderArea.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FilterPanel.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FilterPanel.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FilterSeparator.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FilterSeparator.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FixedLine.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.FocusedCell.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.GrandTotalCell.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.HeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.HeaderArea.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.HeaderFilterButton.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.HeaderFilterButton.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.HeaderFilterButtonActive.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.HeaderFilterButtonActive.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.HeaderGroupLine.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.Lines.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.Lines.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.RowHeaderArea.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.RowHeaderArea.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.SelectedCell.Options.UseFont = true;
		this.pivotGridMarkSheets.Appearance.TotalCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.Appearance.TotalCell.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.Cell.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.Cell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.Cell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.Cell.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.Cell.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.CustomTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.CustomTotalCell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.CustomTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.CustomTotalCell.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.CustomTotalCell.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldHeader.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldHeader.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldHeader.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.FieldHeader.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldHeader.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldValue.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldValue.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldValue.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.FieldValue.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldValue.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueGrandTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueGrandTotal.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueGrandTotal.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.FieldValueGrandTotal.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueGrandTotal.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueTotal.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueTotal.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueTotal.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.FieldValueTotal.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.FieldValueTotal.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.FilterSeparator.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FilterSeparator.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.FilterSeparator.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.FilterSeparator.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.FilterSeparator.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.GrandTotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.GrandTotalCell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.GrandTotalCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.GrandTotalCell.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.GrandTotalCell.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.HeaderGroupLine.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.HeaderGroupLine.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.HeaderGroupLine.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.HeaderGroupLine.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.HeaderGroupLine.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.Lines.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.Lines.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.Lines.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.Lines.Options.UseFont = true;
		this.pivotGridMarkSheets.AppearancePrint.TotalCell.BackColor = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.TotalCell.BackColor2 = System.Drawing.Color.White;
		this.pivotGridMarkSheets.AppearancePrint.TotalCell.Font = new System.Drawing.Font("Cascadia Mono", 9.75f);
		this.pivotGridMarkSheets.AppearancePrint.TotalCell.Options.UseBackColor = true;
		this.pivotGridMarkSheets.AppearancePrint.TotalCell.Options.UseFont = true;
		this.pivotGridMarkSheets.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[4] { this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField4 });
		this.pivotGridMarkSheets.Location = new System.Drawing.Point(7, 59);
		this.pivotGridMarkSheets.Name = "pivotGridMarkSheets";
		this.pivotGridMarkSheets.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridMarkSheets.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridMarkSheets.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridMarkSheets.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridMarkSheets.OptionsPrint.UsePrintAppearance = true;
		this.pivotGridMarkSheets.OptionsView.ShowColumnGrandTotals = false;
		this.pivotGridMarkSheets.OptionsView.ShowColumnHeaders = false;
		this.pivotGridMarkSheets.OptionsView.ShowDataHeaders = false;
		this.pivotGridMarkSheets.OptionsView.ShowFilterHeaders = false;
		this.pivotGridMarkSheets.Size = new System.Drawing.Size(809, 474);
		this.pivotGridMarkSheets.TabIndex = 5;
		this.pivotGridMarkSheets.Click += new System.EventHandler(pivotGridMarkSheets_Click);
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Name";
		this.pivotGridField1.FieldName = "fullName";
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.Options.ShowCustomTotals = false;
		this.pivotGridField1.Options.ShowGrandTotal = false;
		this.pivotGridField1.Options.ShowTotals = false;
		this.pivotGridField1.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
		this.pivotGridField1.Width = 200;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "Student No";
		this.pivotGridField2.FieldName = "StudentNumber";
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField3.AreaIndex = 0;
		this.pivotGridField3.Caption = "Subject";
		this.pivotGridField3.FieldName = "SubjectId";
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.Width = 60;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField4.AreaIndex = 0;
		this.pivotGridField4.Caption = "Score 100";
		this.pivotGridField4.FieldName = "Score100";
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField4.Options.ShowGrandTotal = false;
		this.pivotGridField4.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
		this.pivotGridField4.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
		this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
		this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup2.GroupBordersVisible = false;
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem2, this.layoutControlItem3, this.layoutControlItem1 });
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
		this.layoutControlGroup2.Size = new System.Drawing.Size(823, 540);
		this.layoutControlGroup2.TextVisible = false;
		this.layoutControlItem2.Control = this.pivotGridMarkSheets;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(813, 478);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.lblSubHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.lblSubHeader.Appearance.Options.UseFont = true;
		this.lblSubHeader.Appearance.Options.UseTextOptions = true;
		this.lblSubHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblSubHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblSubHeader.Location = new System.Drawing.Point(7, 36);
		this.lblSubHeader.Name = "lblSubHeader";
		this.lblSubHeader.Size = new System.Drawing.Size(809, 19);
		this.lblSubHeader.StyleController = this.layoutControl1;
		this.lblSubHeader.TabIndex = 9;
		this.lblHeader.Appearance.Font = new System.Drawing.Font("Tahoma", 16f);
		this.lblHeader.Appearance.Options.UseFont = true;
		this.lblHeader.Appearance.Options.UseTextOptions = true;
		this.lblHeader.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader.Location = new System.Drawing.Point(7, 7);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(809, 25);
		this.lblHeader.StyleController = this.layoutControl1;
		this.lblHeader.TabIndex = 8;
		this.layoutControlItem1.Control = this.lblSubHeader;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 29);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(813, 23);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.lblHeader;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(813, 29);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrPeformanceSheetNC";
		base.Size = new System.Drawing.Size(823, 540);
		base.Load += new System.EventHandler(usrPeformanceSheet_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridMarkSheets).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
