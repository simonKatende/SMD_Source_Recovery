using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Data.PivotGrid;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrEnrollmentcs : XtraUserControl
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private PivotGridControl pivotEnrollmentSheet;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private PivotGridField flClass;

	private PivotGridField flStream;

	private PivotGridField flDB;

	private PivotGridField flSex;

	private PivotGridField flCount;

	private ChartControl chartControl1;

	private LayoutControlItem layoutControlItem2;

	private BarManager barManager1;

	private ChartTypeBar chartTypeBar1;

	private CreateBarBaseItem createBarBaseItem1;

	private GalleryDropDown galleryDropDown1;

	private CreateLineBaseItem createLineBaseItem1;

	private GalleryDropDown galleryDropDown2;

	private GalleryDropDown galleryDropDown3;

	private GalleryDropDown galleryDropDown4;

	private CreateAreaBaseItem createAreaBaseItem1;

	private GalleryDropDown galleryDropDown5;

	private GalleryDropDown galleryDropDown6;

	private ChangePaletteGalleryBaseItem changePaletteGalleryBaseItem1;

	private GalleryDropDown galleryDropDown7;

	private ChangeAppearanceGalleryBaseBarManagerItem changeAppearanceGalleryBaseBarManagerItem1;

	private GalleryDropDown galleryDropDown8;

	private RunWizardChartItem runWizardChartItem1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private SaveAsTemplateChartItem saveAsTemplateChartItem1;

	private LoadTemplateChartItem loadTemplateChartItem1;

	private PrintPreviewChartItem printPreviewChartItem1;

	private PrintChartItem printChartItem1;

	private CreateExportBaseItem createExportBaseItem1;

	private ExportToPDFChartItem exportToPDFChartItem1;

	private ExportToHTMLChartItem exportToHTMLChartItem1;

	private ExportToMHTChartItem exportToMHTChartItem1;

	private ExportToXLSChartItem exportToXLSChartItem1;

	private ExportToXLSXChartItem exportToXLSXChartItem1;

	private ExportToRTFChartItem exportToRTFChartItem1;

	private CreateExportToImageBaseItem createExportToImageBaseItem1;

	private ExportToBMPChartItem exportToBMPChartItem1;

	private ExportToGIFChartItem exportToGIFChartItem1;

	private ExportToJPEGChartItem exportToJPEGChartItem1;

	private ExportToPNGChartItem exportToPNGChartItem1;

	private ExportToTIFFChartItem exportToTIFFChartItem1;

	private ChartBarController chartBarController1;

	private DataTable EnrollmentSource
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Stream", typeof(string));
			dataTable.Columns.Add("Sex", typeof(string));
			dataTable.Columns.Add("DB", typeof(string));
			dataTable.Columns.Add("Class", typeof(string));
			dataTable.Columns.Add("ClassCount", typeof(string));
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT StreamId AS Stream, Sex,ClassId, StudyStatus AS DB FROM tbl_Stud WHERE Status='Active'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "studentsList");
			DataTable dataTable2 = new DataTable();
			dataTable2 = dataSet.Tables[0];
			foreach (DataRow row in dataTable2.Rows)
			{
				dataTable.Rows.Add(row["Stream"], row["Sex"], row["DB"], row["ClassId"], row["ClassId"]);
			}
			return dataTable;
		}
	}

	public usrEnrollmentcs()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Calculating Total Enrollment...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadStudentList, 0);
		Thread.Sleep(25);
		InitializeComponent();
		StandardEnrollment();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void StandardEnrollment()
	{
		try
		{
			pivotEnrollmentSheet.DataSource = EnrollmentSource.DefaultView;
			chartControl1.DataSource = EnrollmentSource.DefaultView;
			chartControl1.SeriesDataMember = "Sex";
			chartControl1.SeriesTemplate.ArgumentDataMember = "Class";
			chartControl1.SeriesTemplate.ValueDataMembersSerializable = "Stream";
			chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
			ChartTitle chartTitle = new ChartTitle
			{
				Text = "Total Enrollment Per Class"
			};
			ChartTitle chartTitle2 = new ChartTitle
			{
				Text = "No. of students",
				Dock = ChartTitleDockStyle.Left
			};
			chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle, chartTitle2 });
			chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;
			chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
			chartControl1.ClearCache();
			PrintableControl.SavePrintableControl(pivotEnrollmentSheet, chartControl1);
			ActiveFormSelected.SetActiveForm("Total Students' Enrollment");
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DColumn chartControlCommandGalleryItemGroup2DColumn = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DColumn();
		DevExpress.XtraCharts.UI.CreateBarChartItem createBarChartItem = new DevExpress.XtraCharts.UI.CreateBarChartItem();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.usrEnrollmentcs));
		DevExpress.XtraCharts.UI.CreateFullStackedBarChartItem createFullStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBarChartItem createSideBySideFullStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateSideBySideStackedBarChartItem createSideBySideStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateSideBySideStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateStackedBarChartItem createStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateStackedBarChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DColumn chartControlCommandGalleryItemGroup3DColumn = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DColumn();
		DevExpress.XtraCharts.UI.CreateBar3DChartItem createBar3DChartItem = new DevExpress.XtraCharts.UI.CreateBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedBar3DChartItem createFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateManhattanBarChartItem createManhattanBarChartItem = new DevExpress.XtraCharts.UI.CreateManhattanBarChartItem();
		DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBar3DChartItem createSideBySideFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateSideBySideFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateSideBySideStackedBar3DChartItem createSideBySideStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateSideBySideStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateStackedBar3DChartItem createStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupCylinderColumn chartControlCommandGalleryItemGroupCylinderColumn = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupCylinderColumn();
		DevExpress.XtraCharts.UI.CreateCylinderBar3DChartItem createCylinderBar3DChartItem = new DevExpress.XtraCharts.UI.CreateCylinderBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateCylinderFullStackedBar3DChartItem createCylinderFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateCylinderFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateCylinderManhattanBarChartItem createCylinderManhattanBarChartItem = new DevExpress.XtraCharts.UI.CreateCylinderManhattanBarChartItem();
		DevExpress.XtraCharts.UI.CreateCylinderSideBySideFullStackedBar3DChartItem createCylinderSideBySideFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateCylinderSideBySideFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateCylinderSideBySideStackedBar3DChartItem createCylinderSideBySideStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateCylinderSideBySideStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateCylinderStackedBar3DChartItem createCylinderStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateCylinderStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupConeColumn chartControlCommandGalleryItemGroupConeColumn = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupConeColumn();
		DevExpress.XtraCharts.UI.CreateConeBar3DChartItem createConeBar3DChartItem = new DevExpress.XtraCharts.UI.CreateConeBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateConeFullStackedBar3DChartItem createConeFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateConeFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateConeManhattanBarChartItem createConeManhattanBarChartItem = new DevExpress.XtraCharts.UI.CreateConeManhattanBarChartItem();
		DevExpress.XtraCharts.UI.CreateConeSideBySideFullStackedBar3DChartItem createConeSideBySideFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateConeSideBySideFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateConeSideBySideStackedBar3DChartItem createConeSideBySideStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateConeSideBySideStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreateConeStackedBar3DChartItem createConeStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreateConeStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPyramidColumn chartControlCommandGalleryItemGroupPyramidColumn = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPyramidColumn();
		DevExpress.XtraCharts.UI.CreatePyramidBar3DChartItem createPyramidBar3DChartItem = new DevExpress.XtraCharts.UI.CreatePyramidBar3DChartItem();
		DevExpress.XtraCharts.UI.CreatePyramidFullStackedBar3DChartItem createPyramidFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreatePyramidFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreatePyramidManhattanBarChartItem createPyramidManhattanBarChartItem = new DevExpress.XtraCharts.UI.CreatePyramidManhattanBarChartItem();
		DevExpress.XtraCharts.UI.CreatePyramidSideBySideFullStackedBar3DChartItem createPyramidSideBySideFullStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreatePyramidSideBySideFullStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreatePyramidSideBySideStackedBar3DChartItem createPyramidSideBySideStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreatePyramidSideBySideStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.CreatePyramidStackedBar3DChartItem createPyramidStackedBar3DChartItem = new DevExpress.XtraCharts.UI.CreatePyramidStackedBar3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DLine chartControlCommandGalleryItemGroup2DLine = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DLine();
		DevExpress.XtraCharts.UI.CreateLineChartItem createLineChartItem = new DevExpress.XtraCharts.UI.CreateLineChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedLineChartItem createFullStackedLineChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedLineChartItem();
		DevExpress.XtraCharts.UI.CreateScatterLineChartItem createScatterLineChartItem = new DevExpress.XtraCharts.UI.CreateScatterLineChartItem();
		DevExpress.XtraCharts.UI.CreateSplineChartItem createSplineChartItem = new DevExpress.XtraCharts.UI.CreateSplineChartItem();
		DevExpress.XtraCharts.UI.CreateStackedLineChartItem createStackedLineChartItem = new DevExpress.XtraCharts.UI.CreateStackedLineChartItem();
		DevExpress.XtraCharts.UI.CreateStepLineChartItem createStepLineChartItem = new DevExpress.XtraCharts.UI.CreateStepLineChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DLine chartControlCommandGalleryItemGroup3DLine = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DLine();
		DevExpress.XtraCharts.UI.CreateLine3DChartItem createLine3DChartItem = new DevExpress.XtraCharts.UI.CreateLine3DChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedLine3DChartItem createFullStackedLine3DChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedLine3DChartItem();
		DevExpress.XtraCharts.UI.CreateSpline3DChartItem createSpline3DChartItem = new DevExpress.XtraCharts.UI.CreateSpline3DChartItem();
		DevExpress.XtraCharts.UI.CreateStackedLine3DChartItem createStackedLine3DChartItem = new DevExpress.XtraCharts.UI.CreateStackedLine3DChartItem();
		DevExpress.XtraCharts.UI.CreateStepLine3DChartItem createStepLine3DChartItem = new DevExpress.XtraCharts.UI.CreateStepLine3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DArea chartControlCommandGalleryItemGroup2DArea = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DArea();
		DevExpress.XtraCharts.UI.CreateAreaChartItem createAreaChartItem = new DevExpress.XtraCharts.UI.CreateAreaChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedAreaChartItem createFullStackedAreaChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedAreaChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedSplineAreaChartItem createFullStackedSplineAreaChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedSplineAreaChartItem();
		DevExpress.XtraCharts.UI.CreateSplineAreaChartItem createSplineAreaChartItem = new DevExpress.XtraCharts.UI.CreateSplineAreaChartItem();
		DevExpress.XtraCharts.UI.CreateStackedAreaChartItem createStackedAreaChartItem = new DevExpress.XtraCharts.UI.CreateStackedAreaChartItem();
		DevExpress.XtraCharts.UI.CreateStackedSplineAreaChartItem createStackedSplineAreaChartItem = new DevExpress.XtraCharts.UI.CreateStackedSplineAreaChartItem();
		DevExpress.XtraCharts.UI.CreateStepAreaChartItem createStepAreaChartItem = new DevExpress.XtraCharts.UI.CreateStepAreaChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DArea chartControlCommandGalleryItemGroup3DArea = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DArea();
		DevExpress.XtraCharts.UI.CreateArea3DChartItem createArea3DChartItem = new DevExpress.XtraCharts.UI.CreateArea3DChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedArea3DChartItem createFullStackedArea3DChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedArea3DChartItem();
		DevExpress.XtraCharts.UI.CreateFullStackedSplineArea3DChartItem createFullStackedSplineArea3DChartItem = new DevExpress.XtraCharts.UI.CreateFullStackedSplineArea3DChartItem();
		DevExpress.XtraCharts.UI.CreateSplineArea3DChartItem createSplineArea3DChartItem = new DevExpress.XtraCharts.UI.CreateSplineArea3DChartItem();
		DevExpress.XtraCharts.UI.CreateStackedArea3DChartItem createStackedArea3DChartItem = new DevExpress.XtraCharts.UI.CreateStackedArea3DChartItem();
		DevExpress.XtraCharts.UI.CreateStackedSplineArea3DChartItem createStackedSplineArea3DChartItem = new DevExpress.XtraCharts.UI.CreateStackedSplineArea3DChartItem();
		DevExpress.XtraCharts.UI.CreateStepArea3DChartItem createStepArea3DChartItem = new DevExpress.XtraCharts.UI.CreateStepArea3DChartItem();
		DevExpress.Skins.SkinPaddingEdges skinPaddingEdges = new DevExpress.Skins.SkinPaddingEdges();
		DevExpress.Skins.SkinPaddingEdges skinPaddingEdges2 = new DevExpress.Skins.SkinPaddingEdges();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DBar chartControlCommandGalleryItemGroup2DBar = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DBar();
		DevExpress.XtraCharts.UI.CreateRotatedBarChartItem createRotatedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedFullStackedBarChartItem createRotatedFullStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedFullStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedSideBySideFullStackedBarChartItem createRotatedSideBySideFullStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedSideBySideFullStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedSideBySideStackedBarChartItem createRotatedSideBySideStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedSideBySideStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedStackedBarChartItem createRotatedStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedStackedBarChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DPie chartControlCommandGalleryItemGroup2DPie = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DPie();
		DevExpress.XtraCharts.UI.CreatePieChartItem createPieChartItem = new DevExpress.XtraCharts.UI.CreatePieChartItem();
		DevExpress.XtraCharts.UI.CreateDoughnutChartItem createDoughnutChartItem = new DevExpress.XtraCharts.UI.CreateDoughnutChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DPie chartControlCommandGalleryItemGroup3DPie = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DPie();
		DevExpress.XtraCharts.UI.CreatePie3DChartItem createPie3DChartItem = new DevExpress.XtraCharts.UI.CreatePie3DChartItem();
		DevExpress.XtraCharts.UI.CreateDoughnut3DChartItem createDoughnut3DChartItem = new DevExpress.XtraCharts.UI.CreateDoughnut3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPoint chartControlCommandGalleryItemGroupPoint = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPoint();
		DevExpress.XtraCharts.UI.CreatePointChartItem createPointChartItem = new DevExpress.XtraCharts.UI.CreatePointChartItem();
		DevExpress.XtraCharts.UI.CreateBubbleChartItem createBubbleChartItem = new DevExpress.XtraCharts.UI.CreateBubbleChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFunnel chartControlCommandGalleryItemGroupFunnel = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFunnel();
		DevExpress.XtraCharts.UI.CreateFunnelChartItem createFunnelChartItem = new DevExpress.XtraCharts.UI.CreateFunnelChartItem();
		DevExpress.XtraCharts.UI.CreateFunnel3DChartItem createFunnel3DChartItem = new DevExpress.XtraCharts.UI.CreateFunnel3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFinancial chartControlCommandGalleryItemGroupFinancial = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupFinancial();
		DevExpress.XtraCharts.UI.CreateStockChartItem createStockChartItem = new DevExpress.XtraCharts.UI.CreateStockChartItem();
		DevExpress.XtraCharts.UI.CreateCandleStickChartItem createCandleStickChartItem = new DevExpress.XtraCharts.UI.CreateCandleStickChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRadar chartControlCommandGalleryItemGroupRadar = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRadar();
		DevExpress.XtraCharts.UI.CreateRadarPointChartItem createRadarPointChartItem = new DevExpress.XtraCharts.UI.CreateRadarPointChartItem();
		DevExpress.XtraCharts.UI.CreateRadarLineChartItem createRadarLineChartItem = new DevExpress.XtraCharts.UI.CreateRadarLineChartItem();
		DevExpress.XtraCharts.UI.CreateRadarAreaChartItem createRadarAreaChartItem = new DevExpress.XtraCharts.UI.CreateRadarAreaChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPolar chartControlCommandGalleryItemGroupPolar = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupPolar();
		DevExpress.XtraCharts.UI.CreatePolarPointChartItem createPolarPointChartItem = new DevExpress.XtraCharts.UI.CreatePolarPointChartItem();
		DevExpress.XtraCharts.UI.CreatePolarLineChartItem createPolarLineChartItem = new DevExpress.XtraCharts.UI.CreatePolarLineChartItem();
		DevExpress.XtraCharts.UI.CreatePolarAreaChartItem createPolarAreaChartItem = new DevExpress.XtraCharts.UI.CreatePolarAreaChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRange chartControlCommandGalleryItemGroupRange = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupRange();
		DevExpress.XtraCharts.UI.CreateRangeBarChartItem createRangeBarChartItem = new DevExpress.XtraCharts.UI.CreateRangeBarChartItem();
		DevExpress.XtraCharts.UI.CreateSideBySideRangeBarChartItem createSideBySideRangeBarChartItem = new DevExpress.XtraCharts.UI.CreateSideBySideRangeBarChartItem();
		DevExpress.XtraCharts.UI.CreateRangeAreaChartItem createRangeAreaChartItem = new DevExpress.XtraCharts.UI.CreateRangeAreaChartItem();
		DevExpress.XtraCharts.UI.CreateRangeArea3DChartItem createRangeArea3DChartItem = new DevExpress.XtraCharts.UI.CreateRangeArea3DChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupGantt chartControlCommandGalleryItemGroupGantt = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroupGantt();
		DevExpress.XtraCharts.UI.CreateGanttChartItem createGanttChartItem = new DevExpress.XtraCharts.UI.CreateGanttChartItem();
		DevExpress.XtraCharts.UI.CreateSideBySideGanttChartItem createSideBySideGanttChartItem = new DevExpress.XtraCharts.UI.CreateSideBySideGanttChartItem();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
		this.pivotEnrollmentSheet = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.flClass = new DevExpress.XtraPivotGrid.PivotGridField();
		this.flStream = new DevExpress.XtraPivotGrid.PivotGridField();
		this.flDB = new DevExpress.XtraPivotGrid.PivotGridField();
		this.flSex = new DevExpress.XtraPivotGrid.PivotGridField();
		this.flCount = new DevExpress.XtraPivotGrid.PivotGridField();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.chartTypeBar1 = new DevExpress.XtraCharts.UI.ChartTypeBar();
		this.createBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateBarBaseItem();
		this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createLineBaseItem1 = new DevExpress.XtraCharts.UI.CreateLineBaseItem();
		this.galleryDropDown2 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createAreaBaseItem1 = new DevExpress.XtraCharts.UI.CreateAreaBaseItem();
		this.galleryDropDown5 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.changePaletteGalleryBaseItem1 = new DevExpress.XtraCharts.UI.ChangePaletteGalleryBaseItem();
		this.galleryDropDown7 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.changeAppearanceGalleryBaseBarManagerItem1 = new DevExpress.XtraCharts.UI.ChangeAppearanceGalleryBaseBarManagerItem();
		this.galleryDropDown8 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.runWizardChartItem1 = new DevExpress.XtraCharts.UI.RunWizardChartItem();
		this.saveAsTemplateChartItem1 = new DevExpress.XtraCharts.UI.SaveAsTemplateChartItem();
		this.loadTemplateChartItem1 = new DevExpress.XtraCharts.UI.LoadTemplateChartItem();
		this.printPreviewChartItem1 = new DevExpress.XtraCharts.UI.PrintPreviewChartItem();
		this.printChartItem1 = new DevExpress.XtraCharts.UI.PrintChartItem();
		this.createExportBaseItem1 = new DevExpress.XtraCharts.UI.CreateExportBaseItem();
		this.exportToPDFChartItem1 = new DevExpress.XtraCharts.UI.ExportToPDFChartItem();
		this.exportToHTMLChartItem1 = new DevExpress.XtraCharts.UI.ExportToHTMLChartItem();
		this.exportToMHTChartItem1 = new DevExpress.XtraCharts.UI.ExportToMHTChartItem();
		this.exportToXLSChartItem1 = new DevExpress.XtraCharts.UI.ExportToXLSChartItem();
		this.exportToXLSXChartItem1 = new DevExpress.XtraCharts.UI.ExportToXLSXChartItem();
		this.exportToRTFChartItem1 = new DevExpress.XtraCharts.UI.ExportToRTFChartItem();
		this.createExportToImageBaseItem1 = new DevExpress.XtraCharts.UI.CreateExportToImageBaseItem();
		this.exportToBMPChartItem1 = new DevExpress.XtraCharts.UI.ExportToBMPChartItem();
		this.exportToGIFChartItem1 = new DevExpress.XtraCharts.UI.ExportToGIFChartItem();
		this.exportToJPEGChartItem1 = new DevExpress.XtraCharts.UI.ExportToJPEGChartItem();
		this.exportToPNGChartItem1 = new DevExpress.XtraCharts.UI.ExportToPNGChartItem();
		this.exportToTIFFChartItem1 = new DevExpress.XtraCharts.UI.ExportToTIFFChartItem();
		this.galleryDropDown4 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.chartBarController1 = new DevExpress.XtraCharts.UI.ChartBarController(this.components);
		this.galleryDropDown3 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.galleryDropDown6 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.chartControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pivotEnrollmentSheet).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chartBarController1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown6).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.chartControl1);
		this.layoutControl1.Controls.Add(this.pivotEnrollmentSheet);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(958, 618);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
		this.chartControl1.Legend.Name = "Default Legend";
		this.chartControl1.Location = new System.Drawing.Point(482, 5);
		this.chartControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.chartControl1.Name = "chartControl1";
		this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
		sideBySideBarSeriesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		sideBySideBarSeriesLabel.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
		this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel;
		this.chartControl1.Size = new System.Drawing.Size(471, 608);
		this.chartControl1.TabIndex = 5;
		this.pivotEnrollmentSheet.ActiveFilterString = "";
		this.pivotEnrollmentSheet.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[5] { this.flClass, this.flStream, this.flDB, this.flSex, this.flCount });
		this.pivotEnrollmentSheet.Location = new System.Drawing.Point(5, 5);
		this.pivotEnrollmentSheet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.pivotEnrollmentSheet.Name = "pivotEnrollmentSheet";
		this.pivotEnrollmentSheet.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotEnrollmentSheet.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotEnrollmentSheet.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotEnrollmentSheet.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
		this.pivotEnrollmentSheet.OptionsView.ShowColumnHeaders = false;
		this.pivotEnrollmentSheet.OptionsView.ShowDataHeaders = false;
		this.pivotEnrollmentSheet.OptionsView.ShowFilterSeparatorBar = false;
		this.pivotEnrollmentSheet.Size = new System.Drawing.Size(471, 608);
		this.pivotEnrollmentSheet.TabIndex = 4;
		this.flClass.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.flClass.AreaIndex = 0;
		this.flClass.Caption = "Class";
		this.flClass.FieldName = "Class";
		this.flClass.Name = "flClass";
		this.flStream.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.flStream.AreaIndex = 1;
		this.flStream.Caption = "Stream";
		this.flStream.FieldName = "Stream";
		this.flStream.Name = "flStream";
		this.flStream.Width = 205;
		this.flDB.AreaIndex = 0;
		this.flDB.Caption = "DB";
		this.flDB.FieldName = "DB";
		this.flDB.Name = "flDB";
		this.flDB.Width = 150;
		this.flSex.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.flSex.AreaIndex = 0;
		this.flSex.Caption = "Sex";
		this.flSex.FieldName = "Sex";
		this.flSex.Name = "flSex";
		this.flSex.Width = 150;
		this.flCount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.flCount.AreaIndex = 0;
		this.flCount.FieldName = "ClassCount";
		this.flCount.Name = "flCount";
		this.flCount.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem2 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(958, 618);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.pivotEnrollmentSheet;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(477, 614);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.chartControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(477, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(477, 614);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.chartTypeBar1 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[23]
		{
			this.createBarBaseItem1, this.createLineBaseItem1, this.createAreaBaseItem1, this.changePaletteGalleryBaseItem1, this.changeAppearanceGalleryBaseBarManagerItem1, this.runWizardChartItem1, this.saveAsTemplateChartItem1, this.loadTemplateChartItem1, this.printPreviewChartItem1, this.printChartItem1,
			this.createExportBaseItem1, this.exportToPDFChartItem1, this.exportToHTMLChartItem1, this.exportToMHTChartItem1, this.exportToXLSChartItem1, this.exportToXLSXChartItem1, this.exportToRTFChartItem1, this.exportToBMPChartItem1, this.exportToGIFChartItem1, this.exportToJPEGChartItem1,
			this.exportToPNGChartItem1, this.exportToTIFFChartItem1, this.createExportToImageBaseItem1
		});
		this.barManager1.MaxItemId = 26;
		this.chartTypeBar1.Control = this.chartControl1;
		this.chartTypeBar1.DockCol = 0;
		this.chartTypeBar1.DockRow = 0;
		this.chartTypeBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
		this.chartTypeBar1.FloatLocation = new System.Drawing.Point(928, 219);
		this.chartTypeBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[5]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.createBarBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createLineBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createAreaBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.changePaletteGalleryBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.changeAppearanceGalleryBaseBarManagerItem1)
		});
		this.chartTypeBar1.OptionsBar.AllowQuickCustomization = false;
		this.chartTypeBar1.OptionsBar.DisableClose = true;
		this.chartTypeBar1.OptionsBar.UseWholeRow = true;
		this.createBarBaseItem1.DropDownControl = this.galleryDropDown1;
		this.createBarBaseItem1.Id = 0;
		this.createBarBaseItem1.Name = "createBarBaseItem1";
		this.galleryDropDown1.Gallery.AllowFilter = false;
		this.galleryDropDown1.Gallery.ColumnCount = 4;
		createBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		createFullStackedBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		createSideBySideFullStackedBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		createSideBySideStackedBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image3");
		createStackedBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image4");
		chartControlCommandGalleryItemGroup2DColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createBarChartItem, createFullStackedBarChartItem, createSideBySideFullStackedBarChartItem, createSideBySideStackedBarChartItem, createStackedBarChartItem });
		createBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image5");
		createFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image6");
		createManhattanBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image7");
		createSideBySideFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image8");
		createSideBySideStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image9");
		createStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image10");
		chartControlCommandGalleryItemGroup3DColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createBar3DChartItem, createFullStackedBar3DChartItem, createManhattanBarChartItem, createSideBySideFullStackedBar3DChartItem, createSideBySideStackedBar3DChartItem, createStackedBar3DChartItem });
		createCylinderBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image11");
		createCylinderFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image12");
		createCylinderManhattanBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image13");
		createCylinderSideBySideFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image14");
		createCylinderSideBySideStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image15");
		createCylinderStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image16");
		chartControlCommandGalleryItemGroupCylinderColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createCylinderBar3DChartItem, createCylinderFullStackedBar3DChartItem, createCylinderManhattanBarChartItem, createCylinderSideBySideFullStackedBar3DChartItem, createCylinderSideBySideStackedBar3DChartItem, createCylinderStackedBar3DChartItem });
		createConeBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image17");
		createConeFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image18");
		createConeManhattanBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image19");
		createConeSideBySideFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image20");
		createConeSideBySideStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image21");
		createConeStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image22");
		chartControlCommandGalleryItemGroupConeColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createConeBar3DChartItem, createConeFullStackedBar3DChartItem, createConeManhattanBarChartItem, createConeSideBySideFullStackedBar3DChartItem, createConeSideBySideStackedBar3DChartItem, createConeStackedBar3DChartItem });
		createPyramidBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image23");
		createPyramidFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image24");
		createPyramidManhattanBarChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image25");
		createPyramidSideBySideFullStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image26");
		createPyramidSideBySideStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image27");
		createPyramidStackedBar3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image28");
		chartControlCommandGalleryItemGroupPyramidColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createPyramidBar3DChartItem, createPyramidFullStackedBar3DChartItem, createPyramidManhattanBarChartItem, createPyramidSideBySideFullStackedBar3DChartItem, createPyramidSideBySideStackedBar3DChartItem, createPyramidStackedBar3DChartItem });
		this.galleryDropDown1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[5] { chartControlCommandGalleryItemGroup2DColumn, chartControlCommandGalleryItemGroup3DColumn, chartControlCommandGalleryItemGroupCylinderColumn, chartControlCommandGalleryItemGroupConeColumn, chartControlCommandGalleryItemGroupPyramidColumn });
		this.galleryDropDown1.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown1.Gallery.RowCount = 10;
		this.galleryDropDown1.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown1.Manager = this.barManager1;
		this.galleryDropDown1.Name = "galleryDropDown1";
		this.createLineBaseItem1.DropDownControl = this.galleryDropDown2;
		this.createLineBaseItem1.Id = 1;
		this.createLineBaseItem1.Name = "createLineBaseItem1";
		this.galleryDropDown2.Gallery.AllowFilter = false;
		this.galleryDropDown2.Gallery.ColumnCount = 3;
		createLineChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image29");
		createFullStackedLineChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image30");
		createScatterLineChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image31");
		createSplineChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image32");
		createStackedLineChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image33");
		createStepLineChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image34");
		chartControlCommandGalleryItemGroup2DLine.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createLineChartItem, createFullStackedLineChartItem, createScatterLineChartItem, createSplineChartItem, createStackedLineChartItem, createStepLineChartItem });
		createLine3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image35");
		createFullStackedLine3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image36");
		createSpline3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image37");
		createStackedLine3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image38");
		createStepLine3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image39");
		chartControlCommandGalleryItemGroup3DLine.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createLine3DChartItem, createFullStackedLine3DChartItem, createSpline3DChartItem, createStackedLine3DChartItem, createStepLine3DChartItem });
		this.galleryDropDown2.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DLine, chartControlCommandGalleryItemGroup3DLine });
		this.galleryDropDown2.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown2.Gallery.RowCount = 4;
		this.galleryDropDown2.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown2.Manager = this.barManager1;
		this.galleryDropDown2.Name = "galleryDropDown2";
		this.createAreaBaseItem1.DropDownControl = this.galleryDropDown5;
		this.createAreaBaseItem1.Id = 4;
		this.createAreaBaseItem1.Name = "createAreaBaseItem1";
		this.galleryDropDown5.Gallery.AllowFilter = false;
		this.galleryDropDown5.Gallery.ColumnCount = 4;
		createAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image40");
		createFullStackedAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image41");
		createFullStackedSplineAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image42");
		createSplineAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image43");
		createStackedAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image44");
		createStackedSplineAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image45");
		createStepAreaChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image46");
		chartControlCommandGalleryItemGroup2DArea.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[7] { createAreaChartItem, createFullStackedAreaChartItem, createFullStackedSplineAreaChartItem, createSplineAreaChartItem, createStackedAreaChartItem, createStackedSplineAreaChartItem, createStepAreaChartItem });
		createArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image47");
		createFullStackedArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image48");
		createFullStackedSplineArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image49");
		createSplineArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image50");
		createStackedArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image51");
		createStackedSplineArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image52");
		createStepArea3DChartItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image53");
		chartControlCommandGalleryItemGroup3DArea.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[7] { createArea3DChartItem, createFullStackedArea3DChartItem, createFullStackedSplineArea3DChartItem, createSplineArea3DChartItem, createStackedArea3DChartItem, createStackedSplineArea3DChartItem, createStepArea3DChartItem });
		this.galleryDropDown5.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DArea, chartControlCommandGalleryItemGroup3DArea });
		this.galleryDropDown5.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown5.Gallery.RowCount = 5;
		this.galleryDropDown5.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown5.Manager = this.barManager1;
		this.galleryDropDown5.Name = "galleryDropDown5";
		this.changePaletteGalleryBaseItem1.DropDownControl = this.galleryDropDown7;
		this.changePaletteGalleryBaseItem1.Id = 6;
		this.changePaletteGalleryBaseItem1.Name = "changePaletteGalleryBaseItem1";
		this.galleryDropDown7.Gallery.AllowFilter = false;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseFont = true;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.Options.UseTextOptions = true;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseFont = true;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.Options.UseTextOptions = true;
		this.galleryDropDown7.Gallery.Appearance.ItemCaptionAppearance.Pressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseFont = true;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.Options.UseTextOptions = true;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseFont = true;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.Options.UseTextOptions = true;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseFont = true;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.Options.UseTextOptions = true;
		this.galleryDropDown7.Gallery.Appearance.ItemDescriptionAppearance.Pressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.galleryDropDown7.Gallery.ColumnCount = 1;
		this.galleryDropDown7.Gallery.ImageSize = new System.Drawing.Size(160, 10);
		this.galleryDropDown7.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleLeft;
		this.galleryDropDown7.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Right;
		skinPaddingEdges.Bottom = -3;
		skinPaddingEdges.Top = -3;
		this.galleryDropDown7.Gallery.ItemImagePadding = skinPaddingEdges;
		skinPaddingEdges2.Bottom = -3;
		skinPaddingEdges2.Top = -3;
		this.galleryDropDown7.Gallery.ItemTextPadding = skinPaddingEdges2;
		this.galleryDropDown7.Gallery.RowCount = 10;
		this.galleryDropDown7.Gallery.ShowGroupCaption = false;
		this.galleryDropDown7.Gallery.ShowItemText = true;
		this.galleryDropDown7.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown7.Manager = this.barManager1;
		this.galleryDropDown7.Name = "galleryDropDown7";
		this.changeAppearanceGalleryBaseBarManagerItem1.DropDownControl = this.galleryDropDown8;
		this.changeAppearanceGalleryBaseBarManagerItem1.Id = 7;
		this.changeAppearanceGalleryBaseBarManagerItem1.Name = "changeAppearanceGalleryBaseBarManagerItem1";
		this.galleryDropDown8.Gallery.AllowFilter = false;
		this.galleryDropDown8.Gallery.ColumnCount = 7;
		this.galleryDropDown8.Gallery.ImageSize = new System.Drawing.Size(80, 50);
		this.galleryDropDown8.Gallery.RowCount = 4;
		this.galleryDropDown8.Gallery.ShowGroupCaption = false;
		this.galleryDropDown8.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown8.Manager = this.barManager1;
		this.galleryDropDown8.Name = "galleryDropDown8";
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlTop.Size = new System.Drawing.Size(1010, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 618);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlBottom.Size = new System.Drawing.Size(1010, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 618);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(958, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlRight.Size = new System.Drawing.Size(52, 618);
		this.runWizardChartItem1.Id = 8;
		this.runWizardChartItem1.Name = "runWizardChartItem1";
		this.saveAsTemplateChartItem1.Id = 9;
		this.saveAsTemplateChartItem1.Name = "saveAsTemplateChartItem1";
		this.loadTemplateChartItem1.Id = 10;
		this.loadTemplateChartItem1.Name = "loadTemplateChartItem1";
		this.printPreviewChartItem1.Id = 11;
		this.printPreviewChartItem1.Name = "printPreviewChartItem1";
		this.printChartItem1.Id = 12;
		this.printChartItem1.Name = "printChartItem1";
		this.createExportBaseItem1.Id = 13;
		this.createExportBaseItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[7]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToPDFChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToHTMLChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToMHTChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToXLSChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToXLSXChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToRTFChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createExportToImageBaseItem1)
		});
		this.createExportBaseItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText;
		this.createExportBaseItem1.Name = "createExportBaseItem1";
		this.exportToPDFChartItem1.Id = 14;
		this.exportToPDFChartItem1.Name = "exportToPDFChartItem1";
		this.exportToHTMLChartItem1.Id = 15;
		this.exportToHTMLChartItem1.Name = "exportToHTMLChartItem1";
		this.exportToMHTChartItem1.Id = 16;
		this.exportToMHTChartItem1.Name = "exportToMHTChartItem1";
		this.exportToXLSChartItem1.Id = 17;
		this.exportToXLSChartItem1.Name = "exportToXLSChartItem1";
		this.exportToXLSXChartItem1.Id = 18;
		this.exportToXLSXChartItem1.Name = "exportToXLSXChartItem1";
		this.exportToRTFChartItem1.Id = 19;
		this.exportToRTFChartItem1.Name = "exportToRTFChartItem1";
		this.createExportToImageBaseItem1.Id = 20;
		this.createExportToImageBaseItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[5]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToBMPChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToGIFChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToJPEGChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToPNGChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.exportToTIFFChartItem1)
		});
		this.createExportToImageBaseItem1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.SmallImagesText;
		this.createExportToImageBaseItem1.Name = "createExportToImageBaseItem1";
		this.exportToBMPChartItem1.Id = 21;
		this.exportToBMPChartItem1.Name = "exportToBMPChartItem1";
		this.exportToGIFChartItem1.Id = 22;
		this.exportToGIFChartItem1.Name = "exportToGIFChartItem1";
		this.exportToJPEGChartItem1.Id = 23;
		this.exportToJPEGChartItem1.Name = "exportToJPEGChartItem1";
		this.exportToPNGChartItem1.Id = 24;
		this.exportToPNGChartItem1.Name = "exportToPNGChartItem1";
		this.exportToTIFFChartItem1.Id = 25;
		this.exportToTIFFChartItem1.Name = "exportToTIFFChartItem1";
		this.galleryDropDown4.Gallery.AllowFilter = false;
		this.galleryDropDown4.Gallery.ColumnCount = 3;
		createRotatedBarChartItem.Caption = "Bar";
		createRotatedBarChartItem.Hint = "Insert a bar chart.\r\n\r\nBar charts are the best chart type for comparing multiple values.\r\n    ";
		createRotatedFullStackedBarChartItem.Caption = "100% Stacked Bar";
		createRotatedFullStackedBarChartItem.Hint = resources.GetString("createRotatedFullStackedBarChartItem1.Hint");
		createRotatedSideBySideFullStackedBarChartItem.Caption = "Clustered 100% Stacked Bar";
		createRotatedSideBySideFullStackedBarChartItem.Hint = "Combine the advantages of both the 100% Stacked Bar and Clustered Bar chart types, so you can stack different bars, and combine them into groups across the same axis value.";
		createRotatedSideBySideStackedBarChartItem.Caption = "Clustered Stacked Bar";
		createRotatedSideBySideStackedBarChartItem.Hint = "Combine the advantages of both the Stacked Bar and Clustered Bar chart types, so that you can stack different bars, and combine them into groups across the same axis value.";
		createRotatedStackedBarChartItem.Caption = "Stacked Bar";
		createRotatedStackedBarChartItem.Hint = "Compare the contribution of each value to a total across categories by using horizontal rectangles.";
		chartControlCommandGalleryItemGroup2DBar.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createRotatedBarChartItem, createRotatedFullStackedBarChartItem, createRotatedSideBySideFullStackedBarChartItem, createRotatedSideBySideStackedBarChartItem, createRotatedStackedBarChartItem });
		this.galleryDropDown4.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[1] { chartControlCommandGalleryItemGroup2DBar });
		this.galleryDropDown4.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown4.Gallery.RowCount = 2;
		this.galleryDropDown4.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown4.Manager = this.barManager1;
		this.galleryDropDown4.Name = "galleryDropDown4";
		this.chartBarController1.BarItems.Add(this.createBarBaseItem1);
		this.chartBarController1.BarItems.Add(this.createLineBaseItem1);
		this.chartBarController1.BarItems.Add(this.createAreaBaseItem1);
		this.chartBarController1.BarItems.Add(this.changePaletteGalleryBaseItem1);
		this.chartBarController1.BarItems.Add(this.changeAppearanceGalleryBaseBarManagerItem1);
		this.chartBarController1.BarItems.Add(this.runWizardChartItem1);
		this.chartBarController1.BarItems.Add(this.saveAsTemplateChartItem1);
		this.chartBarController1.BarItems.Add(this.loadTemplateChartItem1);
		this.chartBarController1.BarItems.Add(this.printPreviewChartItem1);
		this.chartBarController1.BarItems.Add(this.printChartItem1);
		this.chartBarController1.BarItems.Add(this.createExportBaseItem1);
		this.chartBarController1.BarItems.Add(this.exportToPDFChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToHTMLChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToMHTChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToXLSChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToXLSXChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToRTFChartItem1);
		this.chartBarController1.BarItems.Add(this.createExportToImageBaseItem1);
		this.chartBarController1.BarItems.Add(this.exportToBMPChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToGIFChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToJPEGChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToPNGChartItem1);
		this.chartBarController1.BarItems.Add(this.exportToTIFFChartItem1);
		this.chartBarController1.Control = this.chartControl1;
		createPieChartItem.Caption = "Pie";
		createPieChartItem.Hint = resources.GetString("createPieChartItem1.Hint");
		createDoughnutChartItem.Caption = "Doughnut";
		createDoughnutChartItem.Hint = "Display the contribution of each value to a total like a pie chart, but it can contain multiple series.";
		chartControlCommandGalleryItemGroup2DPie.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createPieChartItem, createDoughnutChartItem });
		createPie3DChartItem.Caption = "Pie in 3-D";
		createPie3DChartItem.Hint = "Display the contribution of each value to a total.";
		createDoughnut3DChartItem.Caption = "Doughnut in 3-D";
		createDoughnut3DChartItem.Hint = "Compare the percentage values of different point arguments in the same series, and illustrate these values as easy to understand pie slices, but with a hole in its center.";
		chartControlCommandGalleryItemGroup3DPie.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createPie3DChartItem, createDoughnut3DChartItem });
		this.galleryDropDown3.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DPie, chartControlCommandGalleryItemGroup3DPie });
		this.galleryDropDown3.Manager = this.barManager1;
		this.galleryDropDown3.Name = "galleryDropDown3";
		createPointChartItem.Caption = "Point";
		createPointChartItem.Hint = "Use it when it's necessary to show stand-alone data points on the same chart plot.";
		createBubbleChartItem.Caption = "Bubble";
		createBubbleChartItem.Hint = "Resemble a Scatter chart, but compare sets of three values instead of two. The third value determines the size of the bubble marker.";
		chartControlCommandGalleryItemGroupPoint.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createPointChartItem, createBubbleChartItem });
		createFunnelChartItem.Caption = "Funnel";
		createFunnelChartItem.Hint = resources.GetString("createFunnelChartItem1.Hint");
		createFunnel3DChartItem.Caption = "3-D Funnel";
		createFunnel3DChartItem.Hint = resources.GetString("createFunnel3DChartItem1.Hint");
		chartControlCommandGalleryItemGroupFunnel.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createFunnelChartItem, createFunnel3DChartItem });
		createStockChartItem.Caption = "Stock";
		createStockChartItem.Hint = resources.GetString("createStockChartItem1.Hint");
		createCandleStickChartItem.Caption = "Candle Stick";
		createCandleStickChartItem.Hint = resources.GetString("createCandleStickChartItem1.Hint");
		chartControlCommandGalleryItemGroupFinancial.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createStockChartItem, createCandleStickChartItem });
		createRadarPointChartItem.Caption = "Radar Point";
		createRadarPointChartItem.Hint = "Show points from two or more different series on the same points arguments on a circular grid that has multiple axes along which data can be plotted.";
		createRadarLineChartItem.Caption = "Radar Line";
		createRadarLineChartItem.Hint = "Show trends for several series and compare their values for the same points arguments on a circular grid that has multiple axes along which data can be plotted.";
		createRadarAreaChartItem.Caption = "Radar Area";
		createRadarAreaChartItem.Hint = "Display series as filled area on a circular grid that has multiple axes along which data can be plotted.";
		chartControlCommandGalleryItemGroupRadar.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[3] { createRadarPointChartItem, createRadarLineChartItem, createRadarAreaChartItem });
		createPolarPointChartItem.Caption = "Polar Point";
		createPolarPointChartItem.Hint = "Show points from two or more different series on the same circular diagram on the basis of angles.";
		createPolarLineChartItem.Caption = "Polar Line";
		createPolarLineChartItem.Hint = "Show trends for several series and compare their values for the same points arguments on a circular diagram on the basis of angles.";
		createPolarAreaChartItem.Caption = "Polar Area";
		createPolarAreaChartItem.Hint = "Display series as filled area on a circular diagram on the basis of angles.";
		chartControlCommandGalleryItemGroupPolar.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[3] { createPolarPointChartItem, createPolarLineChartItem, createPolarAreaChartItem });
		createRangeBarChartItem.Caption = "Range Column";
		createRangeBarChartItem.Hint = "Display vertical columns along the Y-axis (the axis of values). Each column represents a range of data for each argument value.";
		createSideBySideRangeBarChartItem.Caption = "Clustered Range Column";
		createSideBySideRangeBarChartItem.Hint = "Show activity columns from different series grouped by their arguments. Each column represents a range of data with two values for each argument value.";
		createRangeAreaChartItem.Caption = "Range Area";
		createRangeAreaChartItem.Hint = "Display series as filled areas on a diagram, with two data points that define minimum and maximum limits.\r\n\r\nUse it when you need to accentuate the delta between start and end values.\r\n    ";
		createRangeArea3DChartItem.Caption = "Range Area in 3-D";
		createRangeArea3DChartItem.Hint = "Display series as filled areas on a diagram, with two data points that define minimum and maximum limits.\r\n\r\nUse it when you need to accentuate the delta between start and end values.\r\n    ";
		chartControlCommandGalleryItemGroupRange.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[4] { createRangeBarChartItem, createSideBySideRangeBarChartItem, createRangeAreaChartItem, createRangeArea3DChartItem });
		createGanttChartItem.Caption = "Gantt";
		createGanttChartItem.Hint = "Track different activities during the time frame.";
		createSideBySideGanttChartItem.Caption = "Clustered Gantt";
		createSideBySideGanttChartItem.Hint = resources.GetString("createSideBySideGanttChartItem1.Hint");
		chartControlCommandGalleryItemGroupGantt.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createGanttChartItem, createSideBySideGanttChartItem });
		this.galleryDropDown6.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[7] { chartControlCommandGalleryItemGroupPoint, chartControlCommandGalleryItemGroupFunnel, chartControlCommandGalleryItemGroupFinancial, chartControlCommandGalleryItemGroupRadar, chartControlCommandGalleryItemGroupPolar, chartControlCommandGalleryItemGroupRange, chartControlCommandGalleryItemGroupGantt });
		this.galleryDropDown6.Manager = this.barManager1;
		this.galleryDropDown6.Name = "galleryDropDown6";
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "usrEnrollmentcs";
		base.Size = new System.Drawing.Size(1010, 618);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chartControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pivotEnrollmentSheet).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chartBarController1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown6).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
