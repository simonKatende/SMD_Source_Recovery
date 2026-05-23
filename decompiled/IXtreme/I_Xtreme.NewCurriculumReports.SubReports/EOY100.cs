using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using AlienAge.GradingScales;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.NewCurriculumReports.ReportDatasets;
using I_Xtreme.NewCurriculumReports.ReportDatasets.NewCurriculumSubReportTableAdapters;

namespace I_Xtreme.NewCurriculumReports.SubReports;

public class EOY100 : XtraReport
{
	private OLevelGradingScale gradingScale;

	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable2;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell3;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell42;

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell5;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed;

	private Parameter studNumber;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell7;

	private GroupFooterBand GroupFooter1;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell31;

	private XRTableCell lblAvg;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell13;

	private CalculatedField calculatedField1;

	private CalculatedField learningOutcomes;

	private CalculatedField learningOutComeAverage;

	private GroupFooterBand footerClassTeacher;

	private GroupFooterBand footerHeadTeacher;

	private XRShape xrShape3;

	private XRLabel xrLabel17;

	private XRLabel lblClassteacherComment;

	private XRLabel xrLabel1;

	private XRShape xrShape2;

	private XRShape xrShape6;

	private XRLabel lblHeadteacherComment;

	private XRLabel xrLabel19;

	private XRLabel xrLabel15;

	private XRShape xrShape5;

	private NewCurriculumSubReport newCurriculumSubReport1;

	private XRLabel xrLabel2;

	private Parameter OtherFeesRequirements;

	private GroupFooterBand GroupFooter2;

	private XRTable tblClassRanking;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell6;

	private XRTableCell colStreamPosition;

	private XRTableRow xrTableRow6;

	private XRTableCell colClass1;

	private XRTableCell colClass2;

	private XRTableCell colStream1;

	private XRTableCell colStream2;

	private XRTable xrTable4;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell39;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell8;

	private XRLine xrLine1;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell11;

	public EOY100()
	{
		InitializeComponent();
		footerClassTeacher.Visible = ReportCustomization.Comment1;
		footerHeadTeacher.Visible = ReportCustomization.Comment2;
	}

	private void xrTableCell18_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell18.Text == "0")
		{
			xrTableCell18.Text = "-";
		}
	}

	private void xrLabel2_BeforePrint(object sender, CancelEventArgs e)
	{
		base.Parameters["OtherFeesRequirements"].Value = xrLabel2.Text;
	}

	private void EOY100_BeforePrint(object sender, CancelEventArgs e)
	{
		tblClassRanking.Visible = ReportCustomization.ShowPositionInClass;
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
		XRSummary xRSummary = new XRSummary();
		XRSummary xRSummary2 = new XRSummary();
		ShapeLine shape = new ShapeLine();
		ShapeRectangle shape2 = new ShapeRectangle();
		ShapeLine shape3 = new ShapeLine();
		ShapeRectangle shape4 = new ShapeRectangle();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow3 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrTable2 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		adapterNewCurriculumSubAssessed = new adapterNewCurriculumSubAssessed();
		studNumber = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrLine1 = new XRLine();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell14 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		lblAvg = new XRTableCell();
		calculatedField1 = new CalculatedField();
		learningOutcomes = new CalculatedField();
		learningOutComeAverage = new CalculatedField();
		footerClassTeacher = new GroupFooterBand();
		xrLabel2 = new XRLabel();
		xrLabel17 = new XRLabel();
		lblClassteacherComment = new XRLabel();
		xrLabel1 = new XRLabel();
		xrShape2 = new XRShape();
		xrShape3 = new XRShape();
		footerHeadTeacher = new GroupFooterBand();
		lblHeadteacherComment = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrShape5 = new XRShape();
		xrShape6 = new XRShape();
		newCurriculumSubReport1 = new NewCurriculumSubReport();
		OtherFeesRequirements = new Parameter();
		GroupFooter2 = new GroupFooterBand();
		tblClassRanking = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell6 = new XRTableCell();
		colStreamPosition = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		colClass1 = new XRTableCell();
		colClass2 = new XRTableCell();
		colStream1 = new XRTableCell();
		colStream2 = new XRTableCell();
		xrTable4 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell8 = new XRTableCell();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)newCurriculumSubReport1).BeginInit();
		((ISupportInitialize)tblClassRanking).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 0f;
		BottomMargin.Name = "BottomMargin";
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 25f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.SortFields.AddRange(new GroupField[2]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending),
			new GroupField("SubjectId", XRColumnSortOrder.Ascending)
		});
		xrTable1.BackColor = Color.Transparent;
		xrTable1.BorderColor = Color.DimGray;
		xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTable1.Font = new DXFont("Tahoma", 9f);
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow3 });
		xrTable1.SizeF = new SizeF(776f, 25f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow3.Cells.AddRange(new XRTableCell[5] { xrTableCell1, xrTableCell18, xrTableCell12, xrTableCell5, xrTableCell9 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell1.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 9f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseBorders = false;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 3.360757107664414;
		xrTableCell1.WordWrap = false;
		xrTableCell18.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETA]")
		});
		xrTableCell18.Font = new DXFont("Tahoma", 9f);
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseBorders = false;
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.Text = "xrTableCell18";
		xrTableCell18.Weight = 0.9410119813173216;
		xrTableCell18.WordWrap = false;
		xrTableCell18.BeforePrint += xrTableCell18_BeforePrint;
		xrTableCell12.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell12.CanGrow = false;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Concat([SubPosEOT],Concat('/',[TotalStudents]) )\n\n")
		});
		xrTableCell12.Font = new DXFont("Tahoma", 7f);
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTableCell12.StylePriority.UseBorders = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UsePadding = false;
		xrTableCell12.Weight = 1.3536382975849337;
		xrTableCell12.WordWrap = false;
		xrTableCell5.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell5.CanGrow = false;
		xrTableCell5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[P5]")
		});
		xrTableCell5.Font = new DXFont("Tahoma", 9f);
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseBorders = false;
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.Text = "xrTableCell5";
		xrTableCell5.Weight = 0.9410137550445613;
		xrTableCell5.WordWrap = false;
		xrTableCell9.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[P6]")
		});
		xrTableCell9.Font = new DXFont("Consolas", 9f);
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseBorders = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell9.Weight = 10.789896452838635;
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrTable2 });
		GroupHeader1.HeightF = 50f;
		GroupHeader1.KeepTogether = true;
		GroupHeader1.Name = "GroupHeader1";
		xrTable2.BorderColor = Color.DimGray;
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow5, xrTableRow8 });
		xrTable2.SizeF = new SizeF(776f, 50f);
		xrTable2.StylePriority.UseBorderColor = false;
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow5.Cells.AddRange(new XRTableCell[5] { xrTableCell3, xrTableCell28, xrTableCell10, xrTableCell2, xrTableCell4 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell3.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell3.CanGrow = false;
		xrTableCell3.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell3.StylePriority.UseBorders = false;
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "SUBJECT";
		xrTableCell3.TextAlignment = TextAlignment.BottomLeft;
		xrTableCell3.Weight = 3.8049197613025156;
		xrTableCell3.WordWrap = false;
		xrTableCell28.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell28.CanGrow = false;
		xrTableCell28.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UseTextAlignment = false;
		xrTableCell28.Text = "EOT";
		xrTableCell28.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell28.Weight = 1.0653774158974367;
		xrTableCell28.WordWrap = false;
		xrTableCell10.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell10.CanGrow = false;
		xrTableCell10.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBorders = false;
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "Sub.";
		xrTableCell10.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell10.Weight = 1.5325373454535118;
		xrTableCell10.WordWrap = false;
		xrTableCell2.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseBorders = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "Grade";
		xrTableCell2.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell2.Weight = 1.0653793854608546;
		xrTableCell4.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.Text = "Teacher Remark";
		xrTableCell4.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell4.Weight = 12.215903473068355;
		xrTableRow8.Cells.AddRange(new XRTableCell[5] { xrTableCell16, xrTableCell17, xrTableCell11, xrTableCell42, xrTableCell7 });
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell16.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell16.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell16.StylePriority.UseBorders = false;
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 3.3607574016440465;
		xrTableCell17.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell17.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseBorders = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.Text = "Score";
		xrTableCell17.Weight = 0.9410119792909027;
		xrTableCell11.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell11.CanGrow = false;
		xrTableCell11.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseBorders = false;
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.Text = "Pos.";
		xrTableCell11.Weight = 1.3536386019486946;
		xrTableCell11.WordWrap = false;
		xrTableCell42.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell42.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell42.Multiline = true;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.StylePriority.UseBorders = false;
		xrTableCell42.StylePriority.UseFont = false;
		xrTableCell42.Weight = 0.9410137159633188;
		xrTableCell7.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.Weight = 10.7898959618024;
		adapterNewCurriculumSubAssessed.ClearBeforeFill = true;
		studNumber.Description = "StudNumber";
		studNumber.Name = "studNumber";
		studNumber.Visible = false;
		GroupFooter1.Controls.AddRange(new XRControl[2] { xrLine1, xrTable3 });
		GroupFooter1.HeightF = 30f;
		GroupFooter1.Name = "GroupFooter1";
		xrLine1.BorderWidth = 2f;
		xrLine1.LineWidth = 3f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(775.9999f, 3.125f);
		xrLine1.StylePriority.UseBorderWidth = false;
		xrTable3.BorderColor = Color.Black;
		xrTable3.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable3.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable3.ForeColor = Color.Black;
		xrTable3.LocationFloat = new PointFloat(0f, 3.125f);
		xrTable3.Name = "xrTable3";
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow4 });
		xrTable3.SizeF = new SizeF(776f, 25f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseForeColor = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow4.Cells.AddRange(new XRTableCell[4] { xrTableCell14, xrTableCell13, xrTableCell31, lblAvg });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell14.BorderColor = Color.DimGray;
		xrTableCell14.Borders = BorderSide.Bottom;
		xrTableCell14.CanGrow = false;
		xrTableCell14.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell14.ForeColor = Color.Black;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell14.StylePriority.UseBorderColor = false;
		xrTableCell14.StylePriority.UseBorders = false;
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseForeColor = false;
		xrTableCell14.StylePriority.UsePadding = false;
		xrTableCell14.Text = "TOTAL MARKS:";
		xrTableCell14.Weight = 0.3651690120450403;
		xrTableCell14.WordWrap = false;
		xrTableCell13.BorderColor = Color.DimGray;
		xrTableCell13.Borders = BorderSide.Right | BorderSide.Bottom;
		xrTableCell13.CanGrow = false;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumSum([ETA])")
		});
		xrTableCell13.Font = new DXFont("Tahoma", 10f);
		xrTableCell13.ForeColor = Color.Black;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell13.StylePriority.UseBorderColor = false;
		xrTableCell13.StylePriority.UseBorders = false;
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.StylePriority.UseForeColor = false;
		xrTableCell13.StylePriority.UsePadding = false;
		xrTableCell13.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell13.Summary = xRSummary;
		xrTableCell13.Text = "xrTableCell13";
		xrTableCell13.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell13.Weight = 0.19979391506410937;
		xrTableCell13.WordWrap = false;
		xrTableCell31.BorderColor = Color.DimGray;
		xrTableCell31.Borders = BorderSide.Left | BorderSide.Bottom;
		xrTableCell31.CanGrow = false;
		xrTableCell31.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell31.ForeColor = Color.Black;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell31.StylePriority.UseBorderColor = false;
		xrTableCell31.StylePriority.UseBorders = false;
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UseForeColor = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.Text = "AVERAGE SCORES:";
		xrTableCell31.Weight = 1.409552115856099;
		xrTableCell31.WordWrap = false;
		lblAvg.BorderColor = Color.DimGray;
		lblAvg.Borders = BorderSide.Bottom;
		lblAvg.CanGrow = false;
		lblAvg.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumAvg([ETA])")
		});
		lblAvg.Font = new DXFont("Tahoma", 10f);
		lblAvg.ForeColor = Color.Black;
		lblAvg.Name = "lblAvg";
		lblAvg.Padding = new PaddingInfo(2, 5, 0, 0, 100f);
		lblAvg.StylePriority.UseBorderColor = false;
		lblAvg.StylePriority.UseBorders = false;
		lblAvg.StylePriority.UseFont = false;
		lblAvg.StylePriority.UseForeColor = false;
		lblAvg.StylePriority.UsePadding = false;
		lblAvg.StylePriority.UseTextAlignment = false;
		xRSummary2.Running = SummaryRunning.Group;
		lblAvg.Summary = xRSummary2;
		lblAvg.TextAlignment = TextAlignment.MiddleRight;
		lblAvg.TextFormatString = "{0:n2}";
		lblAvg.Weight = 0.30887680592211625;
		lblAvg.WordWrap = false;
		calculatedField1.DataMember = "dsNewCurriculumSubAssessed";
		calculatedField1.Name = "calculatedField1";
		learningOutcomes.DataMember = "dsNewCurriculumSubAssessed";
		learningOutcomes.Expression = "Substring(([ETAv]*0.01*3),0,3)";
		learningOutcomes.FieldType = FieldType.Decimal;
		learningOutcomes.Name = "learningOutcomes";
		learningOutComeAverage.DataMember = "dsNewCurriculumSubAssessed";
		learningOutComeAverage.Expression = "Avg(sum([ETAv]))";
		learningOutComeAverage.FieldType = FieldType.Decimal;
		learningOutComeAverage.Name = "learningOutComeAverage";
		footerClassTeacher.Controls.AddRange(new XRControl[6] { xrLabel2, xrLabel17, lblClassteacherComment, xrLabel1, xrShape2, xrShape3 });
		footerClassTeacher.HeightF = 69f;
		footerClassTeacher.Level = 2;
		footerClassTeacher.Name = "footerClassTeacher";
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OtherRequirements]")
		});
		xrLabel2.LocationFloat = new PointFloat(620.5f, 31.5f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(100f, 23f);
		xrLabel2.Visible = false;
		xrLabel2.BeforePrint += xrLabel2_BeforePrint;
		xrLabel17.BackColor = Color.Transparent;
		xrLabel17.BorderColor = Color.Black;
		xrLabel17.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.CanGrow = false;
		xrLabel17.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrLabel17.ForeColor = Color.Black;
		xrLabel17.LocationFloat = new PointFloat(6.000019f, 7.99998f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(451.0417f, 23f);
		xrLabel17.StylePriority.UseBackColor = false;
		xrLabel17.StylePriority.UseBorderColor = false;
		xrLabel17.StylePriority.UseBorderDashStyle = false;
		xrLabel17.StylePriority.UseBorders = false;
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseForeColor = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "Classteacher Remarks:";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.WordWrap = false;
		lblClassteacherComment.BorderColor = Color.Black;
		lblClassteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblClassteacherComment.Borders = BorderSide.None;
		lblClassteacherComment.CanGrow = false;
		lblClassteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassteacherRemark]")
		});
		lblClassteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblClassteacherComment.ForeColor = Color.Black;
		lblClassteacherComment.LocationFloat = new PointFloat(6.000007f, 31.5f);
		lblClassteacherComment.Multiline = true;
		lblClassteacherComment.Name = "lblClassteacherComment";
		lblClassteacherComment.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblClassteacherComment.SizeF = new SizeF(603f, 23f);
		lblClassteacherComment.StylePriority.UseBorderColor = false;
		lblClassteacherComment.StylePriority.UseBorderDashStyle = false;
		lblClassteacherComment.StylePriority.UseBorders = false;
		lblClassteacherComment.StylePriority.UseFont = false;
		lblClassteacherComment.StylePriority.UseForeColor = false;
		lblClassteacherComment.StylePriority.UsePadding = false;
		lblClassteacherComment.StylePriority.UseTextAlignment = false;
		lblClassteacherComment.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel1.LocationFloat = new PointFloat(620f, 6.99999f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(100f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Signature";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		xrShape2.LocationFloat = new PointFloat(615f, 5f);
		xrShape2.Name = "xrShape2";
		xrShape2.Shape = shape;
		xrShape2.SizeF = new SizeF(2f, 64f);
		xrShape3.LocationFloat = new PointFloat(0f, 5f);
		xrShape3.Name = "xrShape3";
		xrShape3.Shape = shape2;
		xrShape3.SizeF = new SizeF(774.9998f, 64f);
		footerHeadTeacher.Controls.AddRange(new XRControl[5] { lblHeadteacherComment, xrLabel19, xrLabel15, xrShape5, xrShape6 });
		footerHeadTeacher.HeightF = 69f;
		footerHeadTeacher.Level = 3;
		footerHeadTeacher.Name = "footerHeadTeacher";
		lblHeadteacherComment.BorderColor = Color.Black;
		lblHeadteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblHeadteacherComment.Borders = BorderSide.None;
		lblHeadteacherComment.CanGrow = false;
		lblHeadteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadteacherRemark]")
		});
		lblHeadteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblHeadteacherComment.ForeColor = Color.Black;
		lblHeadteacherComment.LocationFloat = new PointFloat(6.500008f, 31.5f);
		lblHeadteacherComment.Name = "lblHeadteacherComment";
		lblHeadteacherComment.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblHeadteacherComment.SizeF = new SizeF(603f, 23f);
		lblHeadteacherComment.StylePriority.UseBorderColor = false;
		lblHeadteacherComment.StylePriority.UseBorderDashStyle = false;
		lblHeadteacherComment.StylePriority.UseBorders = false;
		lblHeadteacherComment.StylePriority.UseFont = false;
		lblHeadteacherComment.StylePriority.UseForeColor = false;
		lblHeadteacherComment.StylePriority.UsePadding = false;
		lblHeadteacherComment.StylePriority.UseTextAlignment = false;
		lblHeadteacherComment.TextAlignment = TextAlignment.MiddleLeft;
		lblHeadteacherComment.WordWrap = false;
		xrLabel19.BackColor = Color.Transparent;
		xrLabel19.BorderColor = Color.Black;
		xrLabel19.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel19.Borders = BorderSide.None;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Consolas", 11f, DXFontStyle.Bold);
		xrLabel19.ForeColor = Color.Black;
		xrLabel19.LocationFloat = new PointFloat(6.50002f, 8f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(451.0417f, 23f);
		xrLabel19.StylePriority.UseBackColor = false;
		xrLabel19.StylePriority.UseBorderColor = false;
		xrLabel19.StylePriority.UseBorderDashStyle = false;
		xrLabel19.StylePriority.UseBorders = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Headteacher Remarks:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.WordWrap = false;
		xrLabel15.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel15.LocationFloat = new PointFloat(620.5f, 7f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape5.LocationFloat = new PointFloat(615.5f, 5f);
		xrShape5.Name = "xrShape5";
		xrShape5.Shape = shape3;
		xrShape5.SizeF = new SizeF(2f, 64f);
		xrShape6.LocationFloat = new PointFloat(0f, 5f);
		xrShape6.Name = "xrShape6";
		xrShape6.Shape = shape4;
		xrShape6.SizeF = new SizeF(774.9998f, 64f);
		newCurriculumSubReport1.DataSetName = "NewCurriculumSubReport";
		newCurriculumSubReport1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		OtherFeesRequirements.Description = "Otherm Fees Requirements";
		OtherFeesRequirements.Name = "OtherFeesRequirements";
		OtherFeesRequirements.Visible = false;
		GroupFooter2.Controls.AddRange(new XRControl[2] { tblClassRanking, xrTable4 });
		GroupFooter2.HeightF = 55f;
		GroupFooter2.Level = 1;
		GroupFooter2.Name = "GroupFooter2";
		tblClassRanking.BorderColor = Color.Black;
		tblClassRanking.Borders = BorderSide.All;
		tblClassRanking.Font = new DXFont("Tahoma", 9f);
		tblClassRanking.LocationFloat = new PointFloat(387.4999f, 0f);
		tblClassRanking.Name = "tblClassRanking";
		tblClassRanking.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow6 });
		tblClassRanking.SizeF = new SizeF(387.4999f, 55f);
		tblClassRanking.StylePriority.UseBorderColor = false;
		tblClassRanking.StylePriority.UseBorders = false;
		tblClassRanking.StylePriority.UseFont = false;
		tblClassRanking.StylePriority.UseTextAlignment = false;
		tblClassRanking.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[2] { xrTableCell6, colStreamPosition });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell6.BackColor = Color.Black;
		xrTableCell6.BorderColor = Color.White;
		xrTableCell6.Borders = BorderSide.Right;
		xrTableCell6.CanGrow = false;
		xrTableCell6.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell6.ForeColor = Color.White;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseBackColor = false;
		xrTableCell6.StylePriority.UseBorderColor = false;
		xrTableCell6.StylePriority.UseBorders = false;
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseForeColor = false;
		xrTableCell6.Text = "Position in Class";
		xrTableCell6.Weight = 1.12499987501708;
		xrTableCell6.WordWrap = false;
		colStreamPosition.BackColor = Color.Black;
		colStreamPosition.BorderColor = Color.White;
		colStreamPosition.Borders = BorderSide.Left;
		colStreamPosition.CanGrow = false;
		colStreamPosition.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		colStreamPosition.ForeColor = Color.White;
		colStreamPosition.Name = "colStreamPosition";
		colStreamPosition.StylePriority.UseBackColor = false;
		colStreamPosition.StylePriority.UseBorderColor = false;
		colStreamPosition.StylePriority.UseBorders = false;
		colStreamPosition.StylePriority.UseFont = false;
		colStreamPosition.StylePriority.UseForeColor = false;
		colStreamPosition.Text = "Position in Stream";
		colStreamPosition.Weight = 1.12500013911148;
		colStreamPosition.WordWrap = false;
		xrTableRow6.Cells.AddRange(new XRTableCell[4] { colClass1, colClass2, colStream1, colStream2 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		colClass1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colClass1.CanGrow = false;
		colClass1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PICEOT]")
		});
		colClass1.Font = new DXFont("Cascadia Mono", 10f);
		colClass1.ForeColor = Color.Black;
		colClass1.Name = "colClass1";
		colClass1.StylePriority.UseBorders = false;
		colClass1.StylePriority.UseFont = false;
		colClass1.StylePriority.UseForeColor = false;
		colClass1.Weight = 0.559615322358004;
		colClass1.WordWrap = false;
		colClass2.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colClass2.CanGrow = false;
		colClass2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SIC]")
		});
		colClass2.Font = new DXFont("Cascadia Mono", 10f);
		colClass2.ForeColor = Color.Black;
		colClass2.Name = "colClass2";
		colClass2.StylePriority.UseBorders = false;
		colClass2.StylePriority.UseFont = false;
		colClass2.StylePriority.UseForeColor = false;
		colClass2.Weight = 0.565384684706274;
		colClass2.WordWrap = false;
		colStream1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colStream1.CanGrow = false;
		colStream1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PISEOT]")
		});
		colStream1.Font = new DXFont("Cascadia Mono", 10f);
		colStream1.ForeColor = Color.Black;
		colStream1.Name = "colStream1";
		colStream1.StylePriority.UseBorders = false;
		colStream1.StylePriority.UseFont = false;
		colStream1.StylePriority.UseForeColor = false;
		colStream1.Weight = 0.559615322358004;
		colStream1.WordWrap = false;
		colStream2.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colStream2.CanGrow = false;
		colStream2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SIS]")
		});
		colStream2.Font = new DXFont("Cascadia Mono", 10f);
		colStream2.ForeColor = Color.Black;
		colStream2.Name = "colStream2";
		colStream2.StylePriority.UseBorders = false;
		colStream2.StylePriority.UseFont = false;
		colStream2.StylePriority.UseForeColor = false;
		colStream2.Weight = 0.565384332580401;
		colStream2.WordWrap = false;
		xrTable4.BorderColor = Color.Black;
		xrTable4.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable4.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable4.ForeColor = Color.Black;
		xrTable4.LocationFloat = new PointFloat(0f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Rows.AddRange(new XRTableRow[2] { xrTableRow2, xrTableRow7 });
		xrTable4.SizeF = new SizeF(375.625f, 55f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseForeColor = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow2.Cells.AddRange(new XRTableCell[1] { xrTableCell39 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell39.BackColor = Color.Black;
		xrTableCell39.BorderColor = Color.DimGray;
		xrTableCell39.Borders = BorderSide.None;
		xrTableCell39.CanGrow = false;
		xrTableCell39.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell39.ForeColor = Color.White;
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell39.StylePriority.UseBackColor = false;
		xrTableCell39.StylePriority.UseBorderColor = false;
		xrTableCell39.StylePriority.UseBorders = false;
		xrTableCell39.StylePriority.UseFont = false;
		xrTableCell39.StylePriority.UseForeColor = false;
		xrTableCell39.StylePriority.UsePadding = false;
		xrTableCell39.StylePriority.UseTextAlignment = false;
		xrTableCell39.Text = "OVERALL PERFORMANCE";
		xrTableCell39.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell39.Weight = 0.9022209284166749;
		xrTableCell39.WordWrap = false;
		xrTableRow7.Cells.AddRange(new XRTableCell[1] { xrTableCell8 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell8.BorderColor = Color.DimGray;
		xrTableCell8.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell8.CanGrow = false;
		xrTableCell8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformance100]")
		});
		xrTableCell8.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell8.ForeColor = Color.Black;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell8.StylePriority.UseBorderColor = false;
		xrTableCell8.StylePriority.UseBorders = false;
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.StylePriority.UseForeColor = false;
		xrTableCell8.StylePriority.UsePadding = false;
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 0.9022209284166749;
		xrTableCell8.WordWrap = false;
		base.Bands.AddRange(new Band[8] { TopMargin, BottomMargin, Detail, GroupHeader1, GroupFooter1, footerClassTeacher, footerHeadTeacher, GroupFooter2 });
		base.CalculatedFields.AddRange(new CalculatedField[3] { calculatedField1, learningOutcomes, learningOutComeAverage });
		base.ComponentStorage.AddRange(new IComponent[1] { newCurriculumSubReport1 });
		base.DataAdapter = adapterNewCurriculumSubAssessed;
		base.DataMember = "tbl_Scores_OL_Report";
		base.DataSource = newCurriculumSubReport1;
		FilterString = "[StudentNumber] = ?studNumber";
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageColor = Color.Transparent;
		base.PageWidth = 776;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[2] { studNumber, OtherFeesRequirements });
		base.RollPaper = true;
		base.SnapGridSize = 1f;
		base.Version = "23.2";
		BeforePrint += EOY100_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)newCurriculumSubReport1).EndInit();
		((ISupportInitialize)tblClassRanking).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
