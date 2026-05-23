using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.AcademicExtensiveAnalysis.ALevelPrincipals;

public class AWP : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell8;

	private XRTable xrTable2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell11;

	private ReportHeaderBand ReportHeader;

	private XRLabel xrLabel1;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell23;

	private ReportFooterBand ReportFooter;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel5;

	private XRLine xrLine1;

	private XRLine xrLine2;

	public AWP(string ClassEn, string StreamEn, string Term)
	{
		InitializeComponent();
		base.DataSource = GradeSummaryService.GetAlevelGradeSummaryAWP(ClassEn, StreamEn, Term);
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
		XRWatermark xRWatermark = new XRWatermark();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable2 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		ReportHeader = new ReportHeaderBand();
		xrLabel1 = new XRLabel();
		ReportFooter = new ReportFooterBand();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 0f;
		BottomMargin.Name = "BottomMargin";
		Detail.Controls.AddRange(new XRControl[1] { xrTable2 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(766f, 25f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow2.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell12, xrTableCell14, xrTableCell15, xrTableCell16, xrTableCell17, xrTableCell18, xrTableCell19, xrTableCell22, xrTableCell9, xrTableCell13,
			xrTableCell21, xrTableCell24
		});
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell12.CanGrow = false;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Subject]")
		});
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell12.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell12.StylePriority.UsePadding = false;
		xrTableCell12.Text = "SUBJECT";
		xrTableCell12.Weight = 1.5070888543722099;
		xrTableCell12.WordWrap = false;
		xrTableCell14.CanGrow = false;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[A]")
		});
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell14.Weight = 0.4169626099612068;
		xrTableCell14.WordWrap = false;
		xrTableCell15.CanGrow = false;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[B]")
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 0.42546232347491486;
		xrTableCell15.WordWrap = false;
		xrTableCell16.CanGrow = false;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[C]")
		});
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.Weight = 0.44246150148485525;
		xrTableCell16.WordWrap = false;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[D]")
		});
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.3914634694200825;
		xrTableCell17.WordWrap = false;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[E]")
		});
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 0.39996288789404666;
		xrTableCell18.WordWrap = false;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[O]")
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell19.Weight = 0.3489643577943218;
		xrTableCell19.WordWrap = false;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[F]")
		});
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xrTableCell22.Text = "F";
		xrTableCell22.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell22.Weight = 0.3234644892947878;
		xrTableCell22.WordWrap = false;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[TotalStudents]")
		});
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.Text = "TotalStudents";
		xrTableCell9.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell9.Weight = 0.7399544357461049;
		xrTableCell13.CanGrow = false;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[TotalWeightedScore]")
		});
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseTextAlignment = false;
		xrTableCell13.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell13.Weight = 0.5784581981176863;
		xrTableCell13.WordWrap = false;
		xrTableCell21.CanGrow = false;
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[AWP]")
		});
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 0.3829630441800661;
		xrTableCell21.WordWrap = false;
		xrTableCell24.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Rank]")
		});
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseTextAlignment = false;
		xrTableCell24.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell24.Weight = 0.3829630441800661;
		GroupHeader1.Controls.AddRange(new XRControl[2] { xrLine2, xrTable1 });
		GroupHeader1.HeightF = 27.08333f;
		GroupHeader1.Name = "GroupHeader1";
		xrTable1.BackColor = Color.LightGray;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Consolas", 11f, DXFontStyle.Bold);
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
		xrTableRow1.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell1, xrTableCell3, xrTableCell4, xrTableCell5, xrTableCell6, xrTableCell7, xrTableCell8, xrTableCell11, xrTableCell2, xrTableCell10,
			xrTableCell20, xrTableCell23
		});
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.Text = "SUBJECT";
		xrTableCell1.Weight = 1.5070888543722099;
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "A";
		xrTableCell3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell3.Weight = 0.4169626099612068;
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.Text = "B";
		xrTableCell4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell4.Weight = 0.42546232347491486;
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "C";
		xrTableCell5.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell5.Weight = 0.44246150148485525;
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.Text = "D";
		xrTableCell6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell6.Weight = 0.3914634694200825;
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Text = "E";
		xrTableCell7.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell7.Weight = 0.39996288789404666;
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.Text = "O";
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 0.3489643577943218;
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseTextAlignment = false;
		xrTableCell11.Text = "F";
		xrTableCell11.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell11.Weight = 0.3234644892947878;
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "TTL Stud";
		xrTableCell2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell2.Weight = 0.7399544357461049;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "WSS";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.5784581981176863;
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "AWP";
		xrTableCell20.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell20.Weight = 0.3829630441800661;
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseTextAlignment = false;
		xrTableCell23.Text = "Rank";
		xrTableCell23.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell23.Weight = 0.3829630441800661;
		ReportHeader.Controls.AddRange(new XRControl[1] { xrLabel1 });
		ReportHeader.HeightF = 23.95833f;
		ReportHeader.Name = "ReportHeader";
		xrLabel1.Font = new DXFont("Consolas", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(0f, 0f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(767f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Subject Performance Ranking";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		ReportFooter.Controls.AddRange(new XRControl[5] { xrLine1, xrLabel5, xrLabel4, xrLabel3, xrLabel2 });
		ReportFooter.HeightF = 100.3333f;
		ReportFooter.Name = "ReportFooter";
		xrLabel5.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel5.LocationFloat = new PointFloat(0f, 31.33332f);
		xrLabel5.Multiline = true;
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(623.8287f, 23f);
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "TTL Stud: Total of students who registered for the subject";
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel4.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel4.LocationFloat = new PointFloat(0f, 77.33326f);
		xrLabel4.Multiline = true;
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(332.162f, 23f);
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "AWP: Average Weighted Performance";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel3.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel3.LocationFloat = new PointFloat(0f, 54.33331f);
		xrLabel3.Multiline = true;
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(332.162f, 23f);
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "WSS: Weighted Score Summation";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel2.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(0f, 8.333333f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(100f, 23f);
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "KEY";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLine1.LineWidth = 2f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(766f, 2.083333f);
		xrLine2.LineWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(0f, 0f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(766f, 2.083333f);
		base.Bands.AddRange(new Band[6] { TopMargin, BottomMargin, Detail, GroupHeader1, ReportHeader, ReportFooter });
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 1169;
		base.PageWidth = 767;
		base.PaperKind = DXPaperKind.Custom;
		base.RollPaper = true;
		base.Version = "23.2";
		xRWatermark.Id = "Watermark1";
		base.Watermarks.AddRange(new Watermark[1] { xRWatermark });
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
