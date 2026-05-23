using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
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
using DevExpress.XtraPivotGrid;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrStatistics : XtraUserControl
{
	private string schoolType = SchoolSettings.SchoolGeneralCurriculum.ToString();

	private string ClassForProcessing = StudentOptions.ActiveClass();

	private IContainer components = null;

	private PivotGridControl pivotGridCounts;

	private PivotGridControl pivotGridPercentages;

	private ChartControl chartControl1;

	private SplitContainerControl splitContainerControl1;

	private SplitContainerControl splitContainerControl2;

	private BarManager barManager1;

	private CreateBarBaseItem createBarBaseItem1;

	private GalleryDropDown galleryDropDown1;

	private CreateLineBaseItem createLineBaseItem1;

	private GalleryDropDown galleryDropDown2;

	private CreatePieBaseItem createPieBaseItem1;

	private GalleryDropDown galleryDropDown3;

	private CreateRotatedBarBaseItem createRotatedBarBaseItem1;

	private GalleryDropDown galleryDropDown4;

	private CreateAreaBaseItem createAreaBaseItem1;

	private GalleryDropDown galleryDropDown5;

	private CreateOtherSeriesTypesBaseItem createOtherSeriesTypesBaseItem1;

	private GalleryDropDown galleryDropDown6;

	private ChangePaletteGalleryBaseItem changePaletteGalleryBaseItem1;

	private GalleryDropDown galleryDropDown7;

	private ChangeAppearanceGalleryBaseBarManagerItem changeAppearanceGalleryBaseBarManagerItem1;

	private GalleryDropDown galleryDropDown8;

	private RunWizardChartItem runWizardChartItem1;

	private SaveAsTemplateChartItem saveAsTemplateChartItem1;

	private LoadTemplateChartItem loadTemplateChartItem1;

	private ChartPrintExportBar chartPrintExportBar1;

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

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private ChartBarController chartBarController1;

	private BarAndDockingController barAndDockingController1;

	public usrStatistics()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Generating Statistical data...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadStatisticalGraph, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadStatisticalGraph();
		MarkSheet.SetMarkSheetViewType("Charts");
		PrintableControl.SavePrintableControl(pivotGridPercentages, pivotGridCounts, chartControl1);
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadStatisticalGraph()
	{
		try
		{
			chartControl1.DataSource = null;
			chartControl1.Series.Clear();
			chartControl1.Titles.Clear();
			chartControl1.SeriesDataMember = string.Empty;
			chartControl1.SeriesTemplate.ArgumentDataMember = string.Empty;
			chartControl1.SeriesTemplate.ValueDataMembersSerializable = string.Empty;
			if (schoolType == SchoolSettings.SchoolType.Primary.ToString() || (schoolType == SchoolSettings.SchoolType.Secondary.ToString() && SchoolSettings.ClassLevel(ClassForProcessing) == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
			{
				if (StatisticalSummaries.StatisticalSummaryType == StatisticalSummaries.SummaryType.DivisionFrequency.ToString())
				{
					if (StatisticalSummaries.IsStreamSummarizable)
					{
						chartControl1.DataSource = StatisticalSummaries.DivisionFrenquenciesStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "Div";
						chartControl1.SeriesTemplate.ArgumentDataMember = "Div";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "BestinEight";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
						chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
						ChartTitle chartTitle = new ChartTitle
						{
							Text = $"Division Frequencies, {StudentOptions.ActiveClass()} ({StatisticalSummaries.SummarizableStream()})-{StudentOptions.ActiveSemester()}"
						};
						ChartTitle chartTitle2 = new ChartTitle
						{
							Text = "No. of students",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle, chartTitle2 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.DivisionFrenquenciesStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField = new PivotGridField("BestInEight", PivotArea.DataArea)
						{
							Caption = "Percentage",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField2 = new PivotGridField("Div", PivotArea.ColumnArea)
						{
							Caption = "Division"
						};
						pivotGridField2.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField2.Options.AllowSort = DefaultBoolean.False;
						pivotGridField.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[2] { pivotGridField, pivotGridField2 });
						pivotGridCounts.DataSource = StatisticalSummaries.DivisionFrenquenciesStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField3 = new PivotGridField("BestInEight", PivotArea.DataArea)
						{
							Caption = "Frequency",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField4 = new PivotGridField("Div", PivotArea.ColumnArea)
						{
							Caption = "Division"
						};
						pivotGridField4.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField3.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField4.Options.AllowSort = DefaultBoolean.False;
						pivotGridField3.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[2] { pivotGridField3, pivotGridField4 });
					}
					else
					{
						chartControl1.DataSource = StatisticalSummaries.DivisionFrenquencies(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "Div";
						chartControl1.SeriesTemplate.ArgumentDataMember = "StreamId";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "BestinEight";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
						ChartTitle chartTitle3 = new ChartTitle
						{
							Text = $"Division Frequencies ({StudentOptions.ActiveClass()}-{StudentOptions.ActiveSemester()})"
						};
						ChartTitle chartTitle4 = new ChartTitle
						{
							Text = "No. of students",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle3, chartTitle4 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.True;
						chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.DivisionFrenquencies(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField5 = new PivotGridField("BestInEight", PivotArea.DataArea)
						{
							Caption = "Percentage",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField6 = new PivotGridField("StreamId", PivotArea.RowArea)
						{
							Caption = "Stream"
						};
						PivotGridField pivotGridField7 = new PivotGridField("Div", PivotArea.ColumnArea)
						{
							Caption = "Division"
						};
						pivotGridField7.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField5.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField6.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField7.Options.AllowSort = DefaultBoolean.False;
						pivotGridField5.Options.AllowSort = DefaultBoolean.False;
						pivotGridField6.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField6, pivotGridField5, pivotGridField7 });
						pivotGridCounts.DataSource = StatisticalSummaries.DivisionFrenquencies(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField8 = new PivotGridField("BestInEight", PivotArea.DataArea)
						{
							Caption = "Frequency",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField9 = new PivotGridField("StreamId", PivotArea.RowArea)
						{
							Caption = "Stream"
						};
						PivotGridField pivotGridField10 = new PivotGridField("Div", PivotArea.ColumnArea)
						{
							Caption = "Division"
						};
						pivotGridField10.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField8.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField9.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField10.Options.AllowSort = DefaultBoolean.False;
						pivotGridField8.Options.AllowSort = DefaultBoolean.False;
						pivotGridField9.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField9, pivotGridField8, pivotGridField10 });
					}
				}
				else if (StatisticalSummaries.StatisticalSummaryType == StatisticalSummaries.SummaryType.OLSubjectPerformance.ToString())
				{
					if (StatisticalSummaries.IsStreamSummarizable)
					{
						chartControl1.DataSource = StatisticalSummaries.SubjectFrenquenciesOLevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "Category";
						chartControl1.SeriesTemplate.ArgumentDataMember = "SubjectId";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "AvMark";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "AVERAGE([AvMark])";
						ChartTitle chartTitle5 = new ChartTitle
						{
							Text = $"Performance per subject, {StudentOptions.ActiveClass()} ({StatisticalSummaries.SummarizableStream()})-{StudentOptions.ActiveSemester()}"
						};
						ChartTitle chartTitle6 = new ChartTitle
						{
							Text = "Average Mark",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle5, chartTitle6 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
						chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.SubjectFrenquenciesOLevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField11 = new PivotGridField("AvMark", PivotArea.DataArea)
						{
							Caption = "Percentage",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField12 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField13 = new PivotGridField("Category", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField11.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField12.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField13.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField11.Options.AllowSort = DefaultBoolean.False;
						pivotGridField12.Options.AllowSort = DefaultBoolean.False;
						pivotGridField13.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField12, pivotGridField11, pivotGridField13 });
						pivotGridCounts.DataSource = StatisticalSummaries.SubjectFrenquenciesOLevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField14 = new PivotGridField("AvMark", PivotArea.DataArea)
						{
							Caption = "Frequency",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField15 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField16 = new PivotGridField("Category", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField14.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField15.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField16.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField14.Options.AllowSort = DefaultBoolean.False;
						pivotGridField15.Options.AllowSort = DefaultBoolean.False;
						pivotGridField16.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField15, pivotGridField14, pivotGridField16 });
					}
					else
					{
						chartControl1.DataSource = StatisticalSummaries.SubjectFrenquenciesOLevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "Category";
						chartControl1.SeriesTemplate.ArgumentDataMember = "SubjectId";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "AvMark";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "AVERAGE([AvMark])";
						ChartTitle chartTitle7 = new ChartTitle
						{
							Text = $"Performance per subject ({StudentOptions.ActiveClass()}-{StudentOptions.ActiveSemester()})"
						};
						ChartTitle chartTitle8 = new ChartTitle
						{
							Text = "Average Mark",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle7, chartTitle8 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
						chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.SubjectFrenquenciesOLevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField17 = new PivotGridField("AvMark", PivotArea.DataArea)
						{
							Caption = "Percentage",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField18 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField19 = new PivotGridField("Category", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField17.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField18.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField19.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField17.Options.AllowSort = DefaultBoolean.False;
						pivotGridField18.Options.AllowSort = DefaultBoolean.False;
						pivotGridField19.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField18, pivotGridField17, pivotGridField19 });
						pivotGridCounts.DataSource = StatisticalSummaries.SubjectFrenquenciesOLevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField20 = new PivotGridField("AvMark", PivotArea.DataArea)
						{
							Caption = "Frequency",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField21 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField22 = new PivotGridField("Category", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField20.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField21.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField22.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField20.Options.AllowSort = DefaultBoolean.False;
						pivotGridField21.Options.AllowSort = DefaultBoolean.False;
						pivotGridField22.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField21, pivotGridField20, pivotGridField22 });
					}
				}
				else if (StatisticalSummaries.StatisticalSummaryType == StatisticalSummaries.SummaryType.SetsComparison.ToString() && !StatisticalSummaries.IsStreamSummarizable)
				{
				}
			}
			else
			{
				if (!(schoolType == SchoolSettings.SchoolType.Secondary.ToString()) || !(SchoolSettings.ClassLevel(ClassForProcessing) == SchoolSettings.SecondaryClassLevels.ALevel.ToString()))
				{
					return;
				}
				if (StatisticalSummaries.StatisticalSummaryType == StatisticalSummaries.SummaryType.ALSubjectPerformance.ToString())
				{
					if (StatisticalSummaries.IsStreamSummarizable)
					{
						chartControl1.DataSource = StatisticalSummaries.PerformanceGradesALevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "Grade";
						chartControl1.SeriesTemplate.ArgumentDataMember = "SubjectId";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "TotalPoints";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
						ChartTitle chartTitle9 = new ChartTitle
						{
							Text = $"Subject Performance, {StudentOptions.ActiveClass()}{StudentOptions.ActiveStream()}-{StudentOptions.ActiveSemester()}"
						};
						ChartTitle chartTitle10 = new ChartTitle
						{
							Text = "No. of students",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle9, chartTitle10 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
						chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.PerformanceGradesALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField23 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "Percentage",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField24 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField25 = new PivotGridField("Grade", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField23.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField24.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField25.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField23.Options.AllowSort = DefaultBoolean.False;
						pivotGridField24.Options.AllowSort = DefaultBoolean.False;
						pivotGridField25.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField24, pivotGridField23, pivotGridField25 });
						pivotGridCounts.DataSource = StatisticalSummaries.PerformanceGradesALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField26 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "Frequency",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField27 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField28 = new PivotGridField("Grade", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField26.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField27.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField28.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField26.Options.AllowSort = DefaultBoolean.False;
						pivotGridField27.Options.AllowSort = DefaultBoolean.False;
						pivotGridField28.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField27, pivotGridField26, pivotGridField28 });
					}
					else
					{
						chartControl1.DataSource = StatisticalSummaries.PerformanceGradesALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "Grade";
						chartControl1.SeriesTemplate.ArgumentDataMember = "SubjectId";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "TotalPoints";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
						ChartTitle chartTitle11 = new ChartTitle
						{
							Text = $"Subject Performance, {StudentOptions.ActiveClass()}-{StudentOptions.ActiveSemester()}"
						};
						ChartTitle chartTitle12 = new ChartTitle
						{
							Text = "No. of students",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle11, chartTitle12 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
						chartControl1.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.PerformanceGradesALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField29 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "Percentage",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField30 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField31 = new PivotGridField("Grade", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField29.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField30.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField31.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField29.Options.AllowSort = DefaultBoolean.False;
						pivotGridField30.Options.AllowSort = DefaultBoolean.False;
						pivotGridField31.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField30, pivotGridField29, pivotGridField31 });
						pivotGridCounts.DataSource = StatisticalSummaries.PerformanceGradesALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField32 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "Frequency",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField33 = new PivotGridField("SubjectId", PivotArea.RowArea)
						{
							Caption = "Subject"
						};
						PivotGridField pivotGridField34 = new PivotGridField("Grade", PivotArea.ColumnArea)
						{
							Caption = "Grade"
						};
						pivotGridField32.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField33.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField34.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField32.Options.AllowSort = DefaultBoolean.False;
						pivotGridField33.Options.AllowSort = DefaultBoolean.False;
						pivotGridField34.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField33, pivotGridField32, pivotGridField34 });
					}
				}
				else if (StatisticalSummaries.StatisticalSummaryType == StatisticalSummaries.SummaryType.PointsFrequencies.ToString())
				{
					if (StatisticalSummaries.IsStreamSummarizable)
					{
						chartControl1.DataSource = StatisticalSummaries.PerformanceGradesPointsALevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "TotalPoints";
						chartControl1.SeriesTemplate.ArgumentDataMember = "TotalPoints";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "TotalPoints";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
						ChartTitle chartTitle13 = new ChartTitle
						{
							Text = $"Points Accrued, {StudentOptions.ActiveClass()}{StatisticalSummaries.SummarizableStream()}-{StudentOptions.ActiveSemester()}"
						};
						ChartTitle chartTitle14 = new ChartTitle
						{
							Text = "No. of students",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle13, chartTitle14 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.PerformanceGradesPointsALevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField35 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "points",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField36 = new PivotGridField("TotalPoints", PivotArea.RowArea)
						{
							Caption = "points"
						};
						PivotGridField pivotGridField37 = new PivotGridField("TotalPoints", PivotArea.ColumnArea)
						{
							Caption = "points"
						};
						pivotGridField35.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField37.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField35.Options.AllowSort = DefaultBoolean.False;
						pivotGridField37.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField36, pivotGridField35, pivotGridField37 });
						pivotGridCounts.DataSource = StatisticalSummaries.PerformanceGradesPointsALevelStream(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField38 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "points",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField39 = new PivotGridField("TotalPoints", PivotArea.RowArea)
						{
							Caption = "points"
						};
						PivotGridField pivotGridField40 = new PivotGridField("TotalPoints", PivotArea.ColumnArea)
						{
							Caption = "points"
						};
						pivotGridField38.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField40.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField39.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField38.Options.AllowSort = DefaultBoolean.False;
						pivotGridField40.Options.AllowSort = DefaultBoolean.False;
						pivotGridField39.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField39, pivotGridField38, pivotGridField40 });
					}
					else
					{
						chartControl1.DataSource = StatisticalSummaries.PerformanceGradesPointsALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						chartControl1.SeriesDataMember = "TotalPoints";
						chartControl1.SeriesTemplate.ArgumentDataMember = "TotalPoints";
						chartControl1.SeriesTemplate.ValueDataMembersSerializable = "TotalPoints";
						chartControl1.SeriesTemplate.NumericSummaryOptions.SummaryFunction = "COUNT()";
						ChartTitle chartTitle15 = new ChartTitle
						{
							Text = $"Points Accrued, {StudentOptions.ActiveClass()}-{StudentOptions.ActiveSemester()}"
						};
						ChartTitle chartTitle16 = new ChartTitle
						{
							Text = "No. of students",
							Dock = ChartTitleDockStyle.Left
						};
						chartControl1.Titles.AddRange(new ChartTitle[2] { chartTitle15, chartTitle16 });
						chartControl1.SeriesTemplate.LabelsVisibility = DefaultBoolean.False;
						chartControl1.ClearCache();
						pivotGridPercentages.DataSource = StatisticalSummaries.PerformanceGradesPointsALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField41 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "points",
							SummaryDisplayType = PivotSummaryDisplayType.PercentOfRow,
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField42 = new PivotGridField("TotalPoints", PivotArea.RowArea)
						{
							Caption = "points"
						};
						PivotGridField pivotGridField43 = new PivotGridField("TotalPoints", PivotArea.ColumnArea)
						{
							Caption = "points"
						};
						pivotGridField41.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField43.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField42.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField41.Options.AllowSort = DefaultBoolean.False;
						pivotGridField43.Options.AllowSort = DefaultBoolean.False;
						pivotGridField42.Options.AllowSort = DefaultBoolean.False;
						pivotGridPercentages.Fields.Clear();
						pivotGridPercentages.Fields.AddRange(new PivotGridField[3] { pivotGridField42, pivotGridField41, pivotGridField43 });
						pivotGridCounts.DataSource = StatisticalSummaries.PerformanceGradesPointsALevel(StudentOptions.ActiveClass(), StudentOptions.ActiveSemester());
						PivotGridField pivotGridField44 = new PivotGridField("TotalPoints", PivotArea.DataArea)
						{
							Caption = "points",
							SummaryType = PivotSummaryType.Count
						};
						PivotGridField pivotGridField45 = new PivotGridField("TotalPoints", PivotArea.RowArea)
						{
							Caption = "points"
						};
						PivotGridField pivotGridField46 = new PivotGridField("TotalPoints", PivotArea.ColumnArea)
						{
							Caption = "points"
						};
						pivotGridField44.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField46.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField45.Options.AllowFilter = DefaultBoolean.False;
						pivotGridField44.Options.AllowSort = DefaultBoolean.False;
						pivotGridField46.Options.AllowSort = DefaultBoolean.False;
						pivotGridField45.Options.AllowSort = DefaultBoolean.False;
						pivotGridCounts.Fields.Clear();
						pivotGridCounts.Fields.AddRange(new PivotGridField[3] { pivotGridField45, pivotGridField44, pivotGridField46 });
					}
				}
			}
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
		DevExpress.XtraCharts.UI.CreateDoughnutChartItem createDoughnutChartItem = new DevExpress.XtraCharts.UI.CreateDoughnutChartItem();
		DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DPie chartControlCommandGalleryItemGroup3DPie = new DevExpress.XtraCharts.UI.ChartControlCommandGalleryItemGroup3DPie();
		DevExpress.XtraCharts.UI.CreatePie3DChartItem createPie3DChartItem = new DevExpress.XtraCharts.UI.CreatePie3DChartItem();
		DevExpress.XtraCharts.UI.CreateDoughnut3DChartItem createDoughnut3DChartItem = new DevExpress.XtraCharts.UI.CreateDoughnut3DChartItem();
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
		this.pivotGridCounts = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridPercentages = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.chartPrintExportBar1 = new DevExpress.XtraCharts.UI.ChartPrintExportBar();
		this.runWizardChartItem1 = new DevExpress.XtraCharts.UI.RunWizardChartItem();
		this.changePaletteGalleryBaseItem1 = new DevExpress.XtraCharts.UI.ChangePaletteGalleryBaseItem();
		this.galleryDropDown7 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.changeAppearanceGalleryBaseBarManagerItem1 = new DevExpress.XtraCharts.UI.ChangeAppearanceGalleryBaseBarManagerItem();
		this.galleryDropDown8 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateBarBaseItem();
		this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createLineBaseItem1 = new DevExpress.XtraCharts.UI.CreateLineBaseItem();
		this.galleryDropDown2 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createPieBaseItem1 = new DevExpress.XtraCharts.UI.CreatePieBaseItem();
		this.galleryDropDown3 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createRotatedBarBaseItem1 = new DevExpress.XtraCharts.UI.CreateRotatedBarBaseItem();
		this.galleryDropDown4 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createAreaBaseItem1 = new DevExpress.XtraCharts.UI.CreateAreaBaseItem();
		this.galleryDropDown5 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.createOtherSeriesTypesBaseItem1 = new DevExpress.XtraCharts.UI.CreateOtherSeriesTypesBaseItem();
		this.galleryDropDown6 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
		this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.saveAsTemplateChartItem1 = new DevExpress.XtraCharts.UI.SaveAsTemplateChartItem();
		this.loadTemplateChartItem1 = new DevExpress.XtraCharts.UI.LoadTemplateChartItem();
		this.exportToPDFChartItem1 = new DevExpress.XtraCharts.UI.ExportToPDFChartItem();
		this.exportToHTMLChartItem1 = new DevExpress.XtraCharts.UI.ExportToHTMLChartItem();
		this.exportToMHTChartItem1 = new DevExpress.XtraCharts.UI.ExportToMHTChartItem();
		this.exportToXLSChartItem1 = new DevExpress.XtraCharts.UI.ExportToXLSChartItem();
		this.exportToXLSXChartItem1 = new DevExpress.XtraCharts.UI.ExportToXLSXChartItem();
		this.exportToRTFChartItem1 = new DevExpress.XtraCharts.UI.ExportToRTFChartItem();
		this.exportToBMPChartItem1 = new DevExpress.XtraCharts.UI.ExportToBMPChartItem();
		this.exportToGIFChartItem1 = new DevExpress.XtraCharts.UI.ExportToGIFChartItem();
		this.exportToJPEGChartItem1 = new DevExpress.XtraCharts.UI.ExportToJPEGChartItem();
		this.exportToPNGChartItem1 = new DevExpress.XtraCharts.UI.ExportToPNGChartItem();
		this.exportToTIFFChartItem1 = new DevExpress.XtraCharts.UI.ExportToTIFFChartItem();
		this.createExportToImageBaseItem1 = new DevExpress.XtraCharts.UI.CreateExportToImageBaseItem();
		this.chartBarController1 = new DevExpress.XtraCharts.UI.ChartBarController();
		((System.ComponentModel.ISupportInitialize)this.pivotGridCounts).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridPercentages).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chartControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)xYDiagram).BeginInit();
		((System.ComponentModel.ISupportInitialize)series).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel).BeginInit();
		((System.ComponentModel.ISupportInitialize)series2).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel2).BeginInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).BeginInit();
		this.splitContainerControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barAndDockingController1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chartBarController1).BeginInit();
		base.SuspendLayout();
		this.pivotGridCounts.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridCounts.Location = new System.Drawing.Point(0, 0);
		this.pivotGridCounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.pivotGridCounts.Name = "pivotGridCounts";
		this.pivotGridCounts.OptionsCustomization.AllowDrag = false;
		this.pivotGridCounts.OptionsCustomization.AllowDragInCustomizationForm = false;
		this.pivotGridCounts.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridCounts.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridCounts.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridCounts.OptionsView.ShowFilterHeaders = false;
		this.pivotGridCounts.Size = new System.Drawing.Size(481, 367);
		this.pivotGridCounts.TabIndex = 6;
		this.pivotGridPercentages.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridPercentages.Location = new System.Drawing.Point(0, 0);
		this.pivotGridPercentages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.pivotGridPercentages.Name = "pivotGridPercentages";
		this.pivotGridPercentages.OptionsCustomization.AllowDrag = false;
		this.pivotGridPercentages.OptionsCustomization.AllowDragInCustomizationForm = false;
		this.pivotGridPercentages.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridPercentages.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridPercentages.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridPercentages.OptionsPrint.PrintHeadersOnEveryPage = true;
		this.pivotGridPercentages.OptionsView.ShowFilterHeaders = false;
		this.pivotGridPercentages.Prefilter.Enabled = false;
		this.pivotGridPercentages.Size = new System.Drawing.Size(481, 411);
		this.pivotGridPercentages.TabIndex = 5;
		this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
		this.chartControl1.DataBindings = null;
		xYDiagram.AxisX.VisibleInPanesSerializable = "-1";
		xYDiagram.AxisY.VisibleInPanesSerializable = "-1";
		xYDiagram.EnableAxisXZooming = true;
		xYDiagram.EnableAxisYZooming = true;
		this.chartControl1.Diagram = xYDiagram;
		this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.chartControl1.Legend.Name = "Default Legend";
		this.chartControl1.Location = new System.Drawing.Point(0, 0);
		this.chartControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
		this.chartControl1.Size = new System.Drawing.Size(965, 786);
		this.chartControl1.TabIndex = 4;
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.Location = new System.Drawing.Point(52, 0);
		this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.chartControl1);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(1454, 786);
		this.splitContainerControl1.SplitterPosition = 965;
		this.splitContainerControl1.TabIndex = 1;
		this.splitContainerControl1.Text = "splitContainerControl1";
		this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl2.Horizontal = false;
		this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.splitContainerControl2.Name = "splitContainerControl2";
		this.splitContainerControl2.Panel1.Controls.Add(this.pivotGridPercentages);
		this.splitContainerControl2.Panel1.Text = "Panel1";
		this.splitContainerControl2.Panel2.Controls.Add(this.pivotGridCounts);
		this.splitContainerControl2.Panel2.Text = "Panel2";
		this.splitContainerControl2.Size = new System.Drawing.Size(481, 786);
		this.splitContainerControl2.SplitterPosition = 411;
		this.splitContainerControl2.TabIndex = 0;
		this.splitContainerControl2.Text = "splitContainerControl2";
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[1] { this.chartPrintExportBar1 });
		this.barManager1.Controller = this.barAndDockingController1;
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[23]
		{
			this.createBarBaseItem1, this.createLineBaseItem1, this.createPieBaseItem1, this.createRotatedBarBaseItem1, this.createAreaBaseItem1, this.createOtherSeriesTypesBaseItem1, this.changePaletteGalleryBaseItem1, this.changeAppearanceGalleryBaseBarManagerItem1, this.runWizardChartItem1, this.saveAsTemplateChartItem1,
			this.loadTemplateChartItem1, this.exportToPDFChartItem1, this.exportToHTMLChartItem1, this.exportToMHTChartItem1, this.exportToXLSChartItem1, this.exportToXLSXChartItem1, this.exportToRTFChartItem1, this.exportToBMPChartItem1, this.exportToGIFChartItem1, this.exportToJPEGChartItem1,
			this.exportToPNGChartItem1, this.exportToTIFFChartItem1, this.createExportToImageBaseItem1
		});
		this.barManager1.MaxItemId = 26;
		this.chartPrintExportBar1.Control = this.chartControl1;
		this.chartPrintExportBar1.DockCol = 0;
		this.chartPrintExportBar1.DockRow = 0;
		this.chartPrintExportBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
		this.chartPrintExportBar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[9]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.runWizardChartItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.changePaletteGalleryBaseItem1, true),
			new DevExpress.XtraBars.LinkPersistInfo(this.changeAppearanceGalleryBaseBarManagerItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createBarBaseItem1, true),
			new DevExpress.XtraBars.LinkPersistInfo(this.createLineBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createPieBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createRotatedBarBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createAreaBaseItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.createOtherSeriesTypesBaseItem1)
		});
		this.chartPrintExportBar1.OptionsBar.AllowQuickCustomization = false;
		this.chartPrintExportBar1.OptionsBar.DisableClose = true;
		this.chartPrintExportBar1.OptionsBar.DisableCustomization = true;
		this.chartPrintExportBar1.OptionsBar.DrawBorder = false;
		this.chartPrintExportBar1.OptionsBar.UseWholeRow = true;
		this.runWizardChartItem1.Id = 8;
		this.runWizardChartItem1.Name = "runWizardChartItem1";
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
		this.createBarBaseItem1.DropDownControl = this.galleryDropDown1;
		this.createBarBaseItem1.Id = 0;
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
		this.createLineBaseItem1.DropDownControl = this.galleryDropDown2;
		this.createLineBaseItem1.Id = 1;
		this.createLineBaseItem1.Name = "createLineBaseItem1";
		this.galleryDropDown2.Gallery.AllowFilter = false;
		this.galleryDropDown2.Gallery.ColumnCount = 3;
		chartControlCommandGalleryItemGroup2DLine.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[6] { createLineChartItem, createFullStackedLineChartItem, createScatterLineChartItem, createSplineChartItem, createStackedLineChartItem, createStepLineChartItem });
		chartControlCommandGalleryItemGroup3DLine.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[5] { createLine3DChartItem, createFullStackedLine3DChartItem, createSpline3DChartItem, createStackedLine3DChartItem, createStepLine3DChartItem });
		this.galleryDropDown2.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DLine, chartControlCommandGalleryItemGroup3DLine });
		this.galleryDropDown2.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown2.Gallery.RowCount = 4;
		this.galleryDropDown2.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown2.Manager = this.barManager1;
		this.galleryDropDown2.Name = "galleryDropDown2";
		this.createPieBaseItem1.DropDownControl = this.galleryDropDown3;
		this.createPieBaseItem1.Id = 2;
		this.createPieBaseItem1.Name = "createPieBaseItem1";
		this.galleryDropDown3.Gallery.AllowFilter = false;
		this.galleryDropDown3.Gallery.ColumnCount = 3;
		chartControlCommandGalleryItemGroup2DPie.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createPieChartItem, createDoughnutChartItem });
		chartControlCommandGalleryItemGroup3DPie.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createPie3DChartItem, createDoughnut3DChartItem });
		this.galleryDropDown3.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[2] { chartControlCommandGalleryItemGroup2DPie, chartControlCommandGalleryItemGroup3DPie });
		this.galleryDropDown3.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown3.Gallery.RowCount = 2;
		this.galleryDropDown3.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown3.Manager = this.barManager1;
		this.galleryDropDown3.Name = "galleryDropDown3";
		this.createRotatedBarBaseItem1.DropDownControl = this.galleryDropDown4;
		this.createRotatedBarBaseItem1.Id = 3;
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
		this.createAreaBaseItem1.Id = 4;
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
		this.createOtherSeriesTypesBaseItem1.DropDownControl = this.galleryDropDown6;
		this.createOtherSeriesTypesBaseItem1.Id = 5;
		this.createOtherSeriesTypesBaseItem1.Name = "createOtherSeriesTypesBaseItem1";
		this.galleryDropDown6.Gallery.AllowFilter = false;
		this.galleryDropDown6.Gallery.ColumnCount = 4;
		chartControlCommandGalleryItemGroupPoint.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createPointChartItem, createBubbleChartItem });
		chartControlCommandGalleryItemGroupFunnel.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createFunnelChartItem, createFunnel3DChartItem });
		chartControlCommandGalleryItemGroupFinancial.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createStockChartItem, createCandleStickChartItem });
		chartControlCommandGalleryItemGroupRadar.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[3] { createRadarPointChartItem, createRadarLineChartItem, createRadarAreaChartItem });
		chartControlCommandGalleryItemGroupPolar.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[3] { createPolarPointChartItem, createPolarLineChartItem, createPolarAreaChartItem });
		chartControlCommandGalleryItemGroupRange.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[4] { createRangeBarChartItem, createSideBySideRangeBarChartItem, createRangeAreaChartItem, createRangeArea3DChartItem });
		chartControlCommandGalleryItemGroupGantt.Items.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItem[2] { createGanttChartItem, createSideBySideGanttChartItem });
		this.galleryDropDown6.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[7] { chartControlCommandGalleryItemGroupPoint, chartControlCommandGalleryItemGroupFunnel, chartControlCommandGalleryItemGroupFinancial, chartControlCommandGalleryItemGroupRadar, chartControlCommandGalleryItemGroupPolar, chartControlCommandGalleryItemGroupRange, chartControlCommandGalleryItemGroupGantt });
		this.galleryDropDown6.Gallery.ImageSize = new System.Drawing.Size(32, 32);
		this.galleryDropDown6.Gallery.RowCount = 7;
		this.galleryDropDown6.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.Auto;
		this.galleryDropDown6.Manager = this.barManager1;
		this.galleryDropDown6.Name = "galleryDropDown6";
		this.barAndDockingController1.PaintStyleName = "Skin";
		this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
		this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
		this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlTop.Size = new System.Drawing.Size(1506, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 786);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlBottom.Size = new System.Drawing.Size(1506, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlLeft.Size = new System.Drawing.Size(52, 786);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(1506, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.barDockControlRight.Size = new System.Drawing.Size(0, 786);
		this.saveAsTemplateChartItem1.Id = 9;
		this.saveAsTemplateChartItem1.Name = "saveAsTemplateChartItem1";
		this.loadTemplateChartItem1.Id = 10;
		this.loadTemplateChartItem1.Name = "loadTemplateChartItem1";
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
		this.chartBarController1.BarItems.Add(this.createBarBaseItem1);
		this.chartBarController1.BarItems.Add(this.createLineBaseItem1);
		this.chartBarController1.BarItems.Add(this.createPieBaseItem1);
		this.chartBarController1.BarItems.Add(this.createRotatedBarBaseItem1);
		this.chartBarController1.BarItems.Add(this.createAreaBaseItem1);
		this.chartBarController1.BarItems.Add(this.createOtherSeriesTypesBaseItem1);
		this.chartBarController1.BarItems.Add(this.changePaletteGalleryBaseItem1);
		this.chartBarController1.BarItems.Add(this.changeAppearanceGalleryBaseBarManagerItem1);
		this.chartBarController1.BarItems.Add(this.runWizardChartItem1);
		this.chartBarController1.BarItems.Add(this.saveAsTemplateChartItem1);
		this.chartBarController1.BarItems.Add(this.loadTemplateChartItem1);
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
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.splitContainerControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "usrStatistics";
		base.Size = new System.Drawing.Size(1506, 786);
		((System.ComponentModel.ISupportInitialize)this.pivotGridCounts).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pivotGridPercentages).EndInit();
		((System.ComponentModel.ISupportInitialize)xYDiagram).EndInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel).EndInit();
		((System.ComponentModel.ISupportInitialize)series).EndInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel2).EndInit();
		((System.ComponentModel.ISupportInitialize)series2).EndInit();
		((System.ComponentModel.ISupportInitialize)sideBySideBarSeriesLabel3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chartControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).EndInit();
		this.splitContainerControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.galleryDropDown6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barAndDockingController1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chartBarController1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
