using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrBursaryInformation : XtraUserControl
{
	private DataTable dt;

	private IContainer components = null;

	private MyGridControl gridControl12;

	private MyGridView gridView13;

	private ChartControl chartControl1;

	private PivotGridControl pivotGridControl1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private SplitContainerControl splitContainerControl1;

	private SplitContainerControl splitContainerControl2;

	private PivotGridField pivotGridFieldClass;

	private PivotGridField pivotGridFieldStudNo;

	private PivotGridField pivotGridFieldBType;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private BarManager barManager1;

	private ChartTypeBar chartTypeBar1;

	private ChangePaletteGalleryBaseItem changePaletteGalleryBaseItem1;

	private GalleryDropDown galleryDropDown7;

	private ChangeAppearanceGalleryBaseBarManagerItem changeAppearanceGalleryBaseBarManagerItem1;

	private GalleryDropDown galleryDropDown8;

	private CreateBarBaseItem createBarBaseItem1;

	private GalleryDropDown galleryDropDown1;

	private GalleryDropDown galleryDropDown2;

	private GalleryDropDown galleryDropDown3;

	private CreateRotatedBarBaseItem createRotatedBarBaseItem1;

	private GalleryDropDown galleryDropDown4;

	private CreateAreaBaseItem createAreaBaseItem1;

	private GalleryDropDown galleryDropDown5;

	private GalleryDropDown galleryDropDown6;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private RunWizardChartItem runWizardChartItem1;

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

	private BarAndDockingController barAndDockingController1;

	private GridColumn gridColumn7;

	public usrBursaryInformation()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Generating list. Please wait...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.StudentsOnBursary, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadStudentsOnBursary();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadStudentsOnBursary()
	{
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Stud WHERE BursaryStatus = 'True'", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "StudentsOnBursary");
				dt = new DataTable();
				dt = dataSet.Tables[0];
				gridControl12.DataSource = dt.DefaultView;
				pivotGridControl1.DataSource = dt.DefaultView;
			}
			chartControl1.DataSource = null;
			chartControl1.Series.Clear();
			chartControl1.Titles.Clear();
			chartControl1.SeriesDataMember = string.Empty;
			chartControl1.SeriesTemplate.ArgumentDataMember = string.Empty;
			chartControl1.SeriesTemplate.ValueDataMembersSerializable = string.Empty;
			chartControl1.DataSource = dt.DefaultView;
			chartControl1.SeriesDataMember = "BursaryProvider";
			chartControl1.SeriesTemplate.ArgumentDataMember = "ClassId";
			chartControl1.SeriesTemplate.ValueDataMembersSerializable = "ClassId";
			chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
			chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
			ChartTitle chartTitle = new ChartTitle
			{
				Text = "Students on bursary"
			};
			chartControl1.Titles.AddRange(new ChartTitle[1] { chartTitle });
			chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;
			chartControl1.ClearCache();
			ActiveFormSelected.SetActiveForm("Students on Bursary-Graphical summary");
			PrintableControl.SavePrintableControl(pivotGridControl1, gridControl12, chartControl1);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void gridView13_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
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
		DevExpress.XtraCharts.XYDiagram xYDiagram = new DevExpress.XtraCharts.XYDiagram();
		DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series();
		DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
		DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
		DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
		DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
		DevExpress.Skins.SkinPaddingEdges skinPaddingEdges = new DevExpress.Skins.SkinPaddingEdges();
		DevExpress.Skins.SkinPaddingEdges skinPaddingEdges2 = new DevExpress.Skins.SkinPaddingEdges();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DColumn chartControlCommandGalleryItemGroup2DColumn = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DColumn();
		DevExpress.XtraCharts.UI.CreateBarChartItem createBarChartItem = new DevExpress.XtraCharts.UI.CreateBarChartItem();
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
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DBar chartControlCommandGalleryItemGroup2DBar = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DBar();
		DevExpress.XtraCharts.UI.CreateRotatedBarChartItem createRotatedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedFullStackedBarChartItem createRotatedFullStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedFullStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedSideBySideFullStackedBarChartItem createRotatedSideBySideFullStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedSideBySideFullStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedSideBySideStackedBarChartItem createRotatedSideBySideStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedSideBySideStackedBarChartItem();
		DevExpress.XtraCharts.UI.CreateRotatedStackedBarChartItem createRotatedStackedBarChartItem = new DevExpress.XtraCharts.UI.CreateRotatedStackedBarChartItem();
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
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DPie chartControlCommandGalleryItemGroup2DPie = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup2DPie();
		DevExpress.XtraCharts.UI.CreatePieChartItem createPieChartItem = new DevExpress.XtraCharts.UI.CreatePieChartItem();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.usrBursaryInformation));
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
		this.gridControl12 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView13 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridFieldClass = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldStudNo = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridFieldBType = new DevExpress.XtraPivotGrid.PivotGridField();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.chartTypeBar1 = new DevExpress.XtraCharts.UI.ChartTypeBar();
		this.changePaletteGalleryBaseItem1 = new DevExpress.XtraCharts.UI.ChangePaletteGalleryBaseItem();
		this.galleryDropDown7 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.changeAppearanceGalleryBaseBarManagerItem1 = new DevExpress.XtraCharts.UI.ChangeAppearanceGalleryBaseBarManagerItem();
		this.galleryDropDown8 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateBarBaseItem();
		this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createRotatedBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateRotatedBarBaseItem();
		this.galleryDropDown4 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createAreaBaseItem1 = new DevExpress.XtraCharts.UI.CreateAreaBaseItem();
		this.galleryDropDown5 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
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
		this.chartBarController1 = new DevExpress.XtraCharts.UI.ChartBarController();
		this.galleryDropDown2 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.galleryDropDown3 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.galleryDropDown6 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.gridControl12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chartControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)xYDiagram).BeginInit();
		((System.ComponentModel.ISupportInitialize)series).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel).BeginInit();
		((System.ComponentModel.ISupportInitialize)series2).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel2).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).BeginInit();
		this.splitContainerControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barAndDockingController1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chartBarController1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown6).BeginInit();
		base.SuspendLayout();
		this.gridControl12.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl12.Location = new System.Drawing.Point(0, 0);
		this.gridControl12.MainView = this.gridView13;
		this.gridControl12.Name = "gridControl12";
		this.gridControl12.Size = new System.Drawing.Size(749, 536);
		this.gridControl12.TabIndex = 1;
		this.gridControl12.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView13 });
		this.gridView13.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView13.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView13.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView13.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.DetailTip.Options.UseFont = true;
		this.gridView13.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.Empty.Options.UseFont = true;
		this.gridView13.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView13.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView13.Appearance.EvenRow.Options.UseFont = true;
		this.gridView13.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView13.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView13.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.FixedLine.Options.UseFont = true;
		this.gridView13.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView13.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.gridView13.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView13.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView13.Appearance.FocusedCell.Options.UseForeColor = true;
		this.gridView13.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView13.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
		this.gridView13.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView13.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView13.Appearance.FocusedRow.Options.UseForeColor = true;
		this.gridView13.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView13.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.GroupButton.Options.UseFont = true;
		this.gridView13.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView13.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView13.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.GroupRow.Options.UseFont = true;
		this.gridView13.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView13.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView13.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView13.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView13.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.HorzLine.Options.UseFont = true;
		this.gridView13.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.OddRow.Options.UseFont = true;
		this.gridView13.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.Preview.Options.UseFont = true;
		this.gridView13.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.Row.Options.UseFont = true;
		this.gridView13.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView13.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView13.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
		this.gridView13.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView13.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView13.Appearance.SelectedRow.Options.UseForeColor = true;
		this.gridView13.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView13.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.VertLine.Options.UseFont = true;
		this.gridView13.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView13.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView13.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView13.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView13.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView13.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView13.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView13.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView13.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView13.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView13.AppearancePrint.OddRow.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.gridView13.AppearancePrint.OddRow.BackColor2 = System.Drawing.Color.FromArgb(255, 224, 192);
		this.gridView13.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.OddRow.ForeColor = System.Drawing.Color.Black;
		this.gridView13.AppearancePrint.OddRow.Options.UseBackColor = true;
		this.gridView13.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView13.AppearancePrint.OddRow.Options.UseForeColor = true;
		this.gridView13.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView13.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView13.AppearancePrint.Row.Options.UseFont = true;
		this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[9] { this.gridColumn9, this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn8, this.gridColumn7 });
		this.gridView13.GridControl = this.gridControl12;
		this.gridView13.GroupCount = 1;
		this.gridView13.GroupFormat = "{1} {2}";
		this.gridView13.IndicatorWidth = 35;
		this.gridView13.Name = "gridView13";
		this.gridView13.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView13.OptionsBehavior.Editable = false;
		this.gridView13.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView13.OptionsFind.AlwaysVisible = true;
		this.gridView13.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView13.OptionsPrint.PrintFilterInfo = true;
		this.gridView13.OptionsPrint.PrintHorzLines = false;
		this.gridView13.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView13.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView13.OptionsView.ShowFooter = true;
		this.gridView13.OptionsView.ShowGroupPanel = false;
		this.gridView13.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView13.OptionsView.ShowIndicator = false;
		this.gridView13.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn8, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView13.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView13_CustomColumnDisplayText);
		this.gridColumn9.Caption = "No";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 0;
		this.gridColumn9.Width = 65;
		this.gridColumn1.Caption = "Name";
		this.gridColumn1.FieldName = "fullName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "StudName", "{0:#}")
		});
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn1.Width = 446;
		this.gridColumn2.Caption = "Student#";
		this.gridColumn2.FieldName = "StudentNumber";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 2;
		this.gridColumn2.Width = 155;
		this.gridColumn3.Caption = "Class";
		this.gridColumn3.FieldName = "ClassId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 3;
		this.gridColumn3.Width = 81;
		this.gridColumn4.Caption = "Stream";
		this.gridColumn4.FieldName = "StreamId";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 4;
		this.gridColumn4.Width = 95;
		this.gridColumn5.Caption = "Sex";
		this.gridColumn5.FieldName = "Sex";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 5;
		this.gridColumn5.Width = 56;
		this.gridColumn6.Caption = "DB";
		this.gridColumn6.FieldName = "StudyStatus";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 6;
		this.gridColumn6.Width = 47;
		this.gridColumn8.Caption = "B. Scheme";
		this.gridColumn8.FieldName = "BursaryProvider";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 7;
		this.gridColumn8.Width = 238;
		xYDiagram.AxisX.WholeRange.AlwaysShowZeroLevel = true;
		xYDiagram.AxisX.WholeRange.AutoSideMargins = true;
		xYDiagram.AxisX.VisualRange.AutoSideMargins = true;
		xYDiagram.AxisX.VisibleInPanesSerializable = "-1";
		xYDiagram.AxisY.WholeRange.AlwaysShowZeroLevel = true;
		xYDiagram.AxisY.WholeRange.AutoSideMargins = true;
		xYDiagram.AxisY.VisualRange.AutoSideMargins = true;
		xYDiagram.AxisY.VisibleInPanesSerializable = "-1";
		this.chartControl1.Diagram = xYDiagram;
		this.chartControl1.Location = new System.Drawing.Point(2, 2);
		this.chartControl1.Name = "chartControl1";
		sideBySideBarSeriesLabel.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
		series.Label = sideBySideBarSeriesLabel;
		series.Name = "Series 1";
		sideBySideBarSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
		series2.Label = sideBySideBarSeriesLabel2;
		series2.Name = "Series 2";
		this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[2] { series, series2 };
		sideBySideBarSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
		this.chartControl1.SeriesTemplate.Label = sideBySideBarSeriesLabel3;
		this.chartControl1.Size = new System.Drawing.Size(100, 244);
		this.chartControl1.TabIndex = 5;
		this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[3] { this.pivotGridFieldClass, this.pivotGridFieldStudNo, this.pivotGridFieldBType });
		this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(33, 266);
		this.pivotGridControl1.TabIndex = 4;
		this.pivotGridFieldClass.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridFieldClass.AreaIndex = 0;
		this.pivotGridFieldClass.Caption = "Class";
		this.pivotGridFieldClass.FieldName = "ClassId";
		this.pivotGridFieldClass.Name = "pivotGridFieldClass";
		this.pivotGridFieldStudNo.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridFieldStudNo.AreaIndex = 0;
		this.pivotGridFieldStudNo.Caption = "StudentNo";
		this.pivotGridFieldStudNo.FieldName = "StudentNumber";
		this.pivotGridFieldStudNo.Name = "pivotGridFieldStudNo";
		this.pivotGridFieldStudNo.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Count;
		this.pivotGridFieldBType.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridFieldBType.AreaIndex = 0;
		this.pivotGridFieldBType.Caption = "B_Type";
		this.pivotGridFieldBType.FieldName = "BursaryProvider";
		this.pivotGridFieldBType.Name = "pivotGridFieldBType";
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.gridControl12);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(787, 536);
		this.splitContainerControl1.SplitterPosition = 749;
		this.splitContainerControl1.TabIndex = 3;
		this.splitContainerControl1.Text = "splitContainerControl1";
		this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl2.Horizontal = false;
		this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl2.Name = "splitContainerControl2";
		this.splitContainerControl2.Panel1.Controls.Add(this.layoutControl1);
		this.splitContainerControl2.Panel1.Text = "Panel1";
		this.splitContainerControl2.Panel2.Controls.Add(this.pivotGridControl1);
		this.splitContainerControl2.Panel2.Text = "Panel2";
		this.splitContainerControl2.Size = new System.Drawing.Size(33, 536);
		this.splitContainerControl2.SplitterPosition = 265;
		this.splitContainerControl2.TabIndex = 0;
		this.splitContainerControl2.Text = "splitContainerControl2";
		this.layoutControl1.Controls.Add(this.chartControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(33, 265);
		this.layoutControl1.TabIndex = 6;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(104, 248);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.chartControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(104, 248);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.chartTypeBar1 });
		this.barManager1.Controller = this.barAndDockingController1;
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[23]
		{
			this.createBarBaseItem1, this.createRotatedBarBaseItem1, this.createAreaBaseItem1, this.changePaletteGalleryBaseItem1, this.changeAppearanceGalleryBaseBarManagerItem1, this.runWizardChartItem1, this.saveAsTemplateChartItem1, this.loadTemplateChartItem1, this.printPreviewChartItem1, this.printChartItem1,
			this.createExportBaseItem1, this.exportToPDFChartItem1, this.exportToHTMLChartItem1, this.exportToMHTChartItem1, this.exportToXLSChartItem1, this.exportToXLSXChartItem1, this.exportToRTFChartItem1, this.exportToBMPChartItem1, this.exportToGIFChartItem1, this.exportToJPEGChartItem1,
			this.exportToPNGChartItem1, this.exportToTIFFChartItem1, this.createExportToImageBaseItem1
		});
		this.barManager1.MaxItemId = 26;
		this.chartTypeBar1.Control = this.chartControl1;
		this.chartTypeBar1.DockCol = 0;
		this.chartTypeBar1.DockRow = 0;
		this.chartTypeBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Right;
		this.chartTypeBar1.FloatLocation = new System.Drawing.Point(668, 177);
		this.chartTypeBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[5]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.changePaletteGalleryBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.changeAppearanceGalleryBaseBarManagerItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createBarBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createRotatedBarBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createAreaBaseItem1)
		});
		this.chartTypeBar1.OptionsBar.AllowQuickCustomization = false;
		this.chartTypeBar1.OptionsBar.DrawBorder = false;
		this.chartTypeBar1.OptionsBar.UseWholeRow = true;
		this.changePaletteGalleryBaseItem1.DropDownControl = this.galleryDropDown7;
		this.changePaletteGalleryBaseItem1.Id = 0;
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
		this.changeAppearanceGalleryBaseBarManagerItem1.Id = 1;
		this.changeAppearanceGalleryBaseBarManagerItem1.Name = "changeAppearanceGalleryBaseBarManagerItem1";
		this.galleryDropDown8.Gallery.AllowFilter = false;
		this.galleryDropDown8.Gallery.ColumnCount = 7;
		this.galleryDropDown8.Gallery.ImageSize = new System.Drawing.Size(80, 50);
		this.galleryDropDown8.Gallery.RowCount = 4;
		this.galleryDropDown8.Gallery.ShowGroupCaption = false;
		this.galleryDropDown8.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown8.Manager = this.barManager1;
		this.galleryDropDown8.Name = "galleryDropDown8";
		this.createBarBaseItem1.DropDownControl = this.galleryDropDown1;
		this.createBarBaseItem1.Id = 2;
		this.createBarBaseItem1.Name = "createBarBaseItem1";
		this.galleryDropDown1.Gallery.AllowFilter = false;
		this.galleryDropDown1.Gallery.ColumnCount = 4;
		chartControlCommandGalleryItemGroup2DColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createBarChartItem, createFullStackedBarChartItem, createSideBySideFullStackedBarChartItem, createSideBySideStackedBarChartItem, createStackedBarChartItem });
		chartControlCommandGalleryItemGroup3DColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createBar3DChartItem, createFullStackedBar3DChartItem, createManhattanBarChartItem, createSideBySideFullStackedBar3DChartItem, createSideBySideStackedBar3DChartItem, createStackedBar3DChartItem });
		chartControlCommandGalleryItemGroupCylinderColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createCylinderBar3DChartItem, createCylinderFullStackedBar3DChartItem, createCylinderManhattanBarChartItem, createCylinderSideBySideFullStackedBar3DChartItem, createCylinderSideBySideStackedBar3DChartItem, createCylinderStackedBar3DChartItem });
		chartControlCommandGalleryItemGroupConeColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createConeBar3DChartItem, createConeFullStackedBar3DChartItem, createConeManhattanBarChartItem, createConeSideBySideFullStackedBar3DChartItem, createConeSideBySideStackedBar3DChartItem, createConeStackedBar3DChartItem });
		chartControlCommandGalleryItemGroupPyramidColumn.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createPyramidBar3DChartItem, createPyramidFullStackedBar3DChartItem, createPyramidManhattanBarChartItem, createPyramidSideBySideFullStackedBar3DChartItem, createPyramidSideBySideStackedBar3DChartItem, createPyramidStackedBar3DChartItem });
		this.galleryDropDown1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[5] { chartControlCommandGalleryItemGroup2DColumn, chartControlCommandGalleryItemGroup3DColumn, chartControlCommandGalleryItemGroupCylinderColumn, chartControlCommandGalleryItemGroupConeColumn, chartControlCommandGalleryItemGroupPyramidColumn });
		this.galleryDropDown1.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown1.Gallery.RowCount = 10;
		this.galleryDropDown1.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown1.Manager = this.barManager1;
		this.galleryDropDown1.Name = "galleryDropDown1";
		this.createRotatedBarBaseItem1.DropDownControl = this.galleryDropDown4;
		this.createRotatedBarBaseItem1.Id = 5;
		this.createRotatedBarBaseItem1.Name = "createRotatedBarBaseItem1";
		this.galleryDropDown4.Gallery.AllowFilter = false;
		this.galleryDropDown4.Gallery.ColumnCount = 3;
		chartControlCommandGalleryItemGroup2DBar.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createRotatedBarChartItem, createRotatedFullStackedBarChartItem, createRotatedSideBySideFullStackedBarChartItem, createRotatedSideBySideStackedBarChartItem, createRotatedStackedBarChartItem });
		this.galleryDropDown4.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[1] { chartControlCommandGalleryItemGroup2DBar });
		this.galleryDropDown4.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown4.Gallery.RowCount = 2;
		this.galleryDropDown4.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown4.Manager = this.barManager1;
		this.galleryDropDown4.Name = "galleryDropDown4";
		this.createAreaBaseItem1.DropDownControl = this.galleryDropDown5;
		this.createAreaBaseItem1.Id = 6;
		this.createAreaBaseItem1.Name = "createAreaBaseItem1";
		this.galleryDropDown5.Gallery.AllowFilter = false;
		this.galleryDropDown5.Gallery.ColumnCount = 4;
		chartControlCommandGalleryItemGroup2DArea.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[7] { createAreaChartItem, createFullStackedAreaChartItem, createFullStackedSplineAreaChartItem, createSplineAreaChartItem, createStackedAreaChartItem, createStackedSplineAreaChartItem, createStepAreaChartItem });
		chartControlCommandGalleryItemGroup3DArea.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[7] { createArea3DChartItem, createFullStackedArea3DChartItem, createFullStackedSplineArea3DChartItem, createSplineArea3DChartItem, createStackedArea3DChartItem, createStackedSplineArea3DChartItem, createStepArea3DChartItem });
		this.galleryDropDown5.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DArea, chartControlCommandGalleryItemGroup3DArea });
		this.galleryDropDown5.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown5.Gallery.RowCount = 4;
		this.galleryDropDown5.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown5.Manager = this.barManager1;
		this.galleryDropDown5.Name = "galleryDropDown5";
		this.barAndDockingController1.PaintStyleName = "Skin";
		this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
		this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
		this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Size = new System.Drawing.Size(818, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 536);
		this.barDockControlBottom.Size = new System.Drawing.Size(818, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 536);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(787, 0);
		this.barDockControlRight.Size = new System.Drawing.Size(31, 536);
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
		this.chartBarController1.BarItems.Add(this.createBarBaseItem1);
		this.chartBarController1.BarItems.Add(this.createRotatedBarBaseItem1);
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
		createLineChartItem.Caption = "Line";
		createLineChartItem.Hint = "Display trend overtime (dates, years) or ordered categories. Useful when there are many data points and the order is important.";
		createFullStackedLineChartItem.Caption = "100% Stacked Line";
		createFullStackedLineChartItem.Hint = "Display the trend of the percentage each value contributes over time or ordered categories.";
		createScatterLineChartItem.Caption = "Scatter Line";
		createScatterLineChartItem.Hint = "Represent series points in the same order that they have in the collection.";
		createSplineChartItem.Caption = "Spline";
		createSplineChartItem.Hint = "Plot a fitted curve through each data point in a series.";
		createStackedLineChartItem.Caption = "Stacked Line";
		createStackedLineChartItem.Hint = "Display the trend of the contribution of each value over time or ordered categories.";
		createStepLineChartItem.Caption = "Step Line";
		createStepLineChartItem.Hint = "Show to what extent values have changed for different points in the same series.";
		chartControlCommandGalleryItemGroup2DLine.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createLineChartItem, createFullStackedLineChartItem, createScatterLineChartItem, createSplineChartItem, createStackedLineChartItem, createStepLineChartItem });
		createLine3DChartItem.Caption = "3-D Line";
		createLine3DChartItem.Hint = "Display each row or column of data as a 3-D ribbon on three axes.";
		createFullStackedLine3DChartItem.Caption = "100% Stacked Line in 3-D";
		createFullStackedLine3DChartItem.Hint = "Display all series stacked and is useful when it is necessary to compare how much each series adds to the total aggregate value for specific arguments (as percents).";
		createSpline3DChartItem.Caption = "3-D Spline";
		createSpline3DChartItem.Hint = "Plot a fitted curve through each data point in a series.";
		createStackedLine3DChartItem.Caption = "Stacked Line in 3-D";
		createStackedLine3DChartItem.Hint = "Display all points from different series in a stacked manner and is useful when it is necessary to compare how much each series adds to the total aggregate value for specific arguments.";
		createStepLine3DChartItem.Caption = "Step Line in 3-D";
		createStepLine3DChartItem.Hint = "Show to what extent values have changed for different points in the same series.";
		chartControlCommandGalleryItemGroup3DLine.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createLine3DChartItem, createFullStackedLine3DChartItem, createSpline3DChartItem, createStackedLine3DChartItem, createStepLine3DChartItem });
		this.galleryDropDown2.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DLine, chartControlCommandGalleryItemGroup3DLine });
		this.galleryDropDown2.Manager = this.barManager1;
		this.galleryDropDown2.Name = "galleryDropDown2";
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
		this.gridColumn7.Caption = "Fees Discount";
		this.gridColumn7.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn7.FieldName = "FeesDiscount";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FeesDiscount", "{0:#,#.0}")
		});
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 7;
		this.gridColumn7.Width = 149;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.splitContainerControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrBursaryInformation";
		base.Size = new System.Drawing.Size(818, 536);
		((System.ComponentModel.ISupportInitialize)this.gridControl12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView13).EndInit();
		((System.ComponentModel.ISupportInitialize)xYDiagram).EndInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel).EndInit();
		((System.ComponentModel.ISupportInitialize)series).EndInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel2).EndInit();
		((System.ComponentModel.ISupportInitialize)series2).EndInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chartControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).EndInit();
		this.splitContainerControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barAndDockingController1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chartBarController1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown6).EndInit();
		base.ResumeLayout(false);
	}
}
