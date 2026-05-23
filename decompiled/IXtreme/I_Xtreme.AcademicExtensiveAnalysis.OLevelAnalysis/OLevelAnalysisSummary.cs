using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Security;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.AcademicExtensiveAnalysis.OLevelAnalysis;

public class OLevelAnalysisSummary : XtraReport
{
	private string ClassEn = string.Empty;

	private string Term = string.Empty;

	private int scopeIndex = 0;

	private string subHeader = string.Empty;

	private string StreamEn = string.Empty;

	private DataTable dt;

	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell23;

	private XRTable xrTable2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell26;

	private ReportHeaderBand ReportHeader;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private GroupFooterBand GroupFooter1;

	private XRLine xrLine1;

	private XRLine xrLine2;

	private GroupHeaderBand GroupHeader2;

	private XRLabel lblSchoolName;

	private PageFooterBand PageFooter;

	private XRPageInfo xrPageInfo1;

	private GroupFooterBand GroupFooter2;

	private XRChart xrChart1;

	public OLevelAnalysisSummary(string ClassEn, string StreamEn, string Term, int scopeIndex)
	{
		InitializeComponent();
		this.ClassEn = ClassEn;
		this.Term = Term;
		this.scopeIndex = scopeIndex;
		this.StreamEn = StreamEn;
		if (StreamEn.Equals("-Entire Class-") || string.IsNullOrEmpty(StreamEn))
		{
			xrLabel1.Text = "Subject performance analysis, " + ClassEn + "-" + Term;
			base.Name = "Performance Analysis_" + ClassEn.Replace('.', '_') + "_" + Term;
		}
		else
		{
			xrLabel1.Text = "Subject performance analysis, " + ClassEn + " (" + StreamEn + ")-" + Term;
			base.Name = "Performance Analysis_" + ClassEn.Replace('.', '_') + "_" + StreamEn.Replace('.', '_') + "_" + Term;
		}
		LoadMarks();
	}

	private void LoadMarks()
	{
		try
		{
			string empty = string.Empty;
			if (scopeIndex == 0)
			{
				subHeader = "Analysis based on Assessment of Integration only";
				dt = GradeSummaryService.GetGradeSummaryAI(ClassEn, StreamEn, Term);
			}
			else if (scopeIndex == 1)
			{
				subHeader = "Analysis based on Assessment of Integration and EOT Examination";
				dt = GradeSummaryService.GetGradeSummaryAIEOT(ClassEn, StreamEn, Term);
			}
			else if (scopeIndex == 2)
			{
				subHeader = "Analysis based on EOT Examination only";
				dt = GradeSummaryService.GetGradeSummaryEOT(ClassEn, StreamEn, Term);
			}
			base.DataSource = dt;
			xrChart1.DataSource = base.DataSource;
			xrLabel2.Text = subHeader;
			xrChart1.Series[0].ArgumentDataMember = "Sub";
			xrChart1.Series[0].ValueDataMembersSerializable = "TotalStudents";
			xrChart1.Series[1].ArgumentDataMember = "Sub";
			xrChart1.Series[1].ValueDataMembersSerializable = "AWP";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
		}
	}

	private void OLevelAnalysisSummary_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.Text = FingerPrint.SchoolName;
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
		XYDiagram xYDiagram = new XYDiagram();
		XYDiagramPane xYDiagramPane = new XYDiagramPane();
		SecondaryAxisY secondaryAxisY = new SecondaryAxisY();
		Series series = new Series();
		StackedBarSeriesView stackedBarSeriesView = new StackedBarSeriesView();
		Series series2 = new Series();
		LineSeriesView lineSeriesView = new LineSeriesView();
		StackedBarSeriesView stackedBarSeriesView2 = new StackedBarSeriesView();
		XRWatermark xRWatermark = new XRWatermark();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable2 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrLine2 = new XRLine();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		ReportHeader = new ReportHeaderBand();
		lblSchoolName = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		GroupFooter1 = new GroupFooterBand();
		xrLine1 = new XRLine();
		GroupHeader2 = new GroupHeaderBand();
		PageFooter = new PageFooterBand();
		xrPageInfo1 = new XRPageInfo();
		GroupFooter2 = new GroupFooterBand();
		xrChart1 = new XRChart();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrChart1).BeginInit();
		((ISupportInitialize)xYDiagram).BeginInit();
		((ISupportInitialize)xYDiagramPane).BeginInit();
		((ISupportInitialize)secondaryAxisY).BeginInit();
		((ISupportInitialize)series).BeginInit();
		((ISupportInitialize)stackedBarSeriesView).BeginInit();
		((ISupportInitialize)series2).BeginInit();
		((ISupportInitialize)lineSeriesView).BeginInit();
		((ISupportInitialize)stackedBarSeriesView2).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 30f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 30f;
		BottomMargin.Name = "BottomMargin";
		Detail.Controls.AddRange(new XRControl[1] { xrTable2 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Consolas", 10f);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(766f, 25f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow2.Cells.AddRange(new XRTableCell[10] { xrTableCell12, xrTableCell15, xrTableCell16, xrTableCell17, xrTableCell18, xrTableCell19, xrTableCell25, xrTableCell13, xrTableCell21, xrTableCell24 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell12.CanGrow = false;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell12.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell12.StylePriority.UsePadding = false;
		xrTableCell12.Text = "SUBJECT";
		xrTableCell12.Weight = 1.4956378822916967;
		xrTableCell12.WordWrap = false;
		xrTableCell15.CanGrow = false;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[A]")
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 0.4094204244358257;
		xrTableCell15.WordWrap = false;
		xrTableCell16.CanGrow = false;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[B]")
		});
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.Weight = 0.40942041803036894;
		xrTableCell16.WordWrap = false;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[C]")
		});
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.409420406639765;
		xrTableCell17.WordWrap = false;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[D]")
		});
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 0.40942041523435724;
		xrTableCell18.WordWrap = false;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[E]")
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell19.Weight = 0.4094204282034426;
		xrTableCell19.WordWrap = false;
		xrTableCell25.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[TotalStudents]")
		});
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseTextAlignment = false;
		xrTableCell25.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell25.Weight = 0.40942042646595;
		xrTableCell13.CanGrow = false;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[WeightedGradeSummation]")
		});
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseTextAlignment = false;
		xrTableCell13.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell13.Weight = 0.40942042646595;
		xrTableCell13.WordWrap = false;
		xrTableCell21.CanGrow = false;
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[AWP]")
		});
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 0.409420418506635;
		xrTableCell21.WordWrap = false;
		xrTableCell24.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Rank]")
		});
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseTextAlignment = false;
		xrTableCell24.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell24.Weight = 0.4094202895724611;
		GroupHeader1.Controls.AddRange(new XRControl[2] { xrLine2, xrTable1 });
		GroupHeader1.HeightF = 27.08333f;
		GroupHeader1.Name = "GroupHeader1";
		xrLine2.LineWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(0f, 0f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(766f, 2.083333f);
		xrTable1.BackColor = Color.LightGray;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrTable1.ForeColor = Color.Black;
		xrTable1.LocationFloat = new PointFloat(0f, 2.083333f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(766f, 25f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseForeColor = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[10] { xrTableCell1, xrTableCell4, xrTableCell5, xrTableCell6, xrTableCell7, xrTableCell8, xrTableCell26, xrTableCell10, xrTableCell20, xrTableCell23 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.Text = "SUBJECT";
		xrTableCell1.Weight = 1.6146470780556006;
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.Text = "A";
		xrTableCell4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell4.Weight = 0.4419983580873726;
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "B";
		xrTableCell5.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell5.Weight = 0.44199836010603116;
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.Text = "C";
		xrTableCell6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell6.Weight = 0.4419983549600866;
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Text = "D";
		xrTableCell7.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell7.Weight = 0.44199834888590417;
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.Text = "E";
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 0.4419983618549894;
		xrTableCell26.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrTableCell26.Multiline = true;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.StylePriority.UseTextAlignment = false;
		xrTableCell26.Text = "TTL Stud.";
		xrTableCell26.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell26.Weight = 0.4419983626537216;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "WSS";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.44199836265372167;
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "AWP";
		xrTableCell20.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell20.Weight = 0.441998352158182;
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseTextAlignment = false;
		xrTableCell23.Text = "Rank";
		xrTableCell23.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell23.Weight = 0.44199838656818086;
		ReportHeader.Controls.AddRange(new XRControl[1] { lblSchoolName });
		ReportHeader.HeightF = 35f;
		ReportHeader.Name = "ReportHeader";
		lblSchoolName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblSchoolName.LocationFloat = new PointFloat(0f, 0f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(766f, 27.31035f);
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel2.Font = new DXFont("Consolas", 12f);
		xrLabel2.LocationFloat = new PointFloat(2.384186E-05f, 23.00002f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(767f, 23f);
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.Font = new DXFont("Consolas", 14f);
		xrLabel1.LocationFloat = new PointFloat(2.384186E-05f, 0f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(767f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		GroupFooter1.Controls.AddRange(new XRControl[1] { xrLine1 });
		GroupFooter1.HeightF = 2.083333f;
		GroupFooter1.Name = "GroupFooter1";
		xrLine1.LineWidth = 2f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(766f, 2.083333f);
		GroupHeader2.Controls.AddRange(new XRControl[2] { xrLabel2, xrLabel1 });
		GroupHeader2.HeightF = 65f;
		GroupHeader2.Level = 1;
		GroupHeader2.Name = "GroupHeader2";
		PageFooter.Controls.AddRange(new XRControl[1] { xrPageInfo1 });
		PageFooter.HeightF = 23f;
		PageFooter.Name = "PageFooter";
		xrPageInfo1.LocationFloat = new PointFloat(531.5833f, 0f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.SizeF = new SizeF(235.4167f, 23f);
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
		xrPageInfo1.TextFormatString = "Page {0} of {1}";
		GroupFooter2.Controls.AddRange(new XRControl[1] { xrChart1 });
		GroupFooter2.HeightF = 461.6667f;
		GroupFooter2.Level = 1;
		GroupFooter2.Name = "GroupFooter2";
		xrChart1.AutoLayout = true;
		xrChart1.BorderColor = Color.Black;
		xrChart1.Borders = BorderSide.None;
		xYDiagram.AxisX.Color = Color.FromArgb(79, 97, 40);
		xYDiagram.AxisX.GridLines.Visible = true;
		xYDiagram.AxisX.Title.Text = "Subjects";
		xYDiagram.AxisX.VisibleInPanesSerializable = "0";
		xYDiagram.AxisY.VisibleInPanesSerializable = "-1";
		xYDiagram.DefaultPane.EnableAxisXScrolling = DefaultBoolean.False;
		xYDiagram.DefaultPane.EnableAxisXZooming = DefaultBoolean.False;
		xYDiagram.DefaultPane.EnableAxisYScrolling = DefaultBoolean.False;
		xYDiagram.DefaultPane.EnableAxisYZooming = DefaultBoolean.False;
		xYDiagram.DefaultPane.Title.Alignment = StringAlignment.Center;
		xYDiagram.DefaultPane.Title.Text = "Total Number of Students Registered for the Subject";
		xYDiagram.DefaultPane.Title.Visibility = DefaultBoolean.True;
		xYDiagramPane.Name = "Pane 1";
		xYDiagramPane.PaneID = 0;
		xYDiagramPane.RuntimeCollapse = DefaultBoolean.False;
		xYDiagramPane.StackedBarTotalLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;
		xYDiagramPane.StackedBarTotalLabel.ShowConnector = true;
		xYDiagramPane.StackedBarTotalLabel.Visible = true;
		xYDiagramPane.Title.Alignment = StringAlignment.Center;
		xYDiagramPane.Title.DXFont = new DXFont("Tahoma", 12f);
		xYDiagramPane.Title.Text = "Average Weighted Performance";
		xYDiagramPane.Title.Visibility = DefaultBoolean.True;
		xYDiagram.Panes.AddRange(new XYDiagramPane[1] { xYDiagramPane });
		xYDiagram.RuntimePaneCollapse = false;
		secondaryAxisY.Alignment = AxisAlignment.Near;
		secondaryAxisY.AxisID = 4;
		secondaryAxisY.Name = "Secondary AxisY 1";
		secondaryAxisY.VisibleInPanesSerializable = "0";
		xYDiagram.SecondaryAxesY.AddRange(new SecondaryAxisY[1] { secondaryAxisY });
		xrChart1.Diagram = xYDiagram;
		xrChart1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center;
		xrChart1.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
		xrChart1.Legend.Direction = LegendDirection.LeftToRight;
		xrChart1.Legend.LegendID = -1;
		xrChart1.Legend.Visibility = DefaultBoolean.False;
		xrChart1.LocationFloat = new PointFloat(0f, 0f);
		xrChart1.Name = "xrChart1";
		xrChart1.PaletteName = "Concourse";
		series.Name = "Series 1";
		series.SeriesID = 1;
		stackedBarSeriesView.ColorEach = true;
		series.View = stackedBarSeriesView;
		series2.Name = "Series 2";
		series2.SeriesID = 4;
		lineSeriesView.AxisYName = "Secondary AxisY 1";
		lineSeriesView.PaneName = "Pane 1";
		series2.View = lineSeriesView;
		xrChart1.SeriesSerializable = new Series[2] { series, series2 };
		xrChart1.SeriesTemplate.View = stackedBarSeriesView2;
		xrChart1.SizeF = new SizeF(767f, 461.6667f);
		base.Bands.AddRange(new Band[9] { TopMargin, BottomMargin, Detail, GroupHeader1, ReportHeader, GroupFooter1, GroupHeader2, PageFooter, GroupFooter2 });
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(30f, 30f, 30f, 30f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.Version = "23.2";
		xRWatermark.Id = "Watermark1";
		base.Watermarks.AddRange(new Watermark[1] { xRWatermark });
		BeforePrint += OLevelAnalysisSummary_BeforePrint;
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xYDiagramPane).EndInit();
		((ISupportInitialize)secondaryAxisY).EndInit();
		((ISupportInitialize)xYDiagram).EndInit();
		((ISupportInitialize)stackedBarSeriesView).EndInit();
		((ISupportInitialize)series).EndInit();
		((ISupportInitialize)lineSeriesView).EndInit();
		((ISupportInitialize)series2).EndInit();
		((ISupportInitialize)stackedBarSeriesView2).EndInit();
		((ISupportInitialize)xrChart1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
