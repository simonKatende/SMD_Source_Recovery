using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.AcademicExtensiveAnalysis.ALevelSubsidiary;

public class SummaryPerPaperSub : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell11;

	private XRTable xrTable2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell22;

	private ReportHeaderBand ReportHeader;

	private XRLabel xrLabel1;

	private GroupFooterBand GroupFooter1;

	private XRLine xrLine1;

	private XRLine xrLine2;

	public SummaryPerPaperSub(string ClassEn, string StreamEn, string Term)
	{
		InitializeComponent();
		base.DataSource = GradeSummaryService.GetAlevelGradeSummaryPerPaperSub(ClassEn, StreamEn, Term);
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
		xrTableCell13 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrLine2 = new XRLine();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		ReportHeader = new ReportHeaderBand();
		xrLabel1 = new XRLabel();
		GroupFooter1 = new GroupFooterBand();
		xrLine1 = new XRLine();
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
		xrTable2.Font = new DXFont("Consolas", 11f);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(766f, 25f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow2.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell12, xrTableCell13, xrTableCell14, xrTableCell15, xrTableCell16, xrTableCell17, xrTableCell18, xrTableCell19, xrTableCell20, xrTableCell21,
			xrTableCell22
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
		xrTableCell12.Weight = 2.12757404180107;
		xrTableCell12.WordWrap = false;
		xrTableCell13.CanGrow = false;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Paper]")
		});
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell13.StylePriority.UsePadding = false;
		xrTableCell13.Text = "PAPER";
		xrTableCell13.Weight = 0.8689510547240269;
		xrTableCell13.WordWrap = false;
		xrTableCell14.CanGrow = false;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[D1]")
		});
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.Text = "D1";
		xrTableCell14.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell14.Weight = 0.3829633201257908;
		xrTableCell14.WordWrap = false;
		xrTableCell15.CanGrow = false;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[D2]")
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "D2";
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 0.382963320125791;
		xrTableCell15.WordWrap = false;
		xrTableCell16.CanGrow = false;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[C3]")
		});
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "C3";
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.Weight = 0.38296332012579115;
		xrTableCell16.WordWrap = false;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[C4]")
		});
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "C4";
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.38296332012579093;
		xrTableCell17.WordWrap = false;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[C5]")
		});
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "C5";
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 0.38296333635789237;
		xrTableCell18.WordWrap = false;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[C6]")
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.Text = "C6";
		xrTableCell19.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell19.Weight = 0.38296333635789237;
		xrTableCell19.WordWrap = false;
		xrTableCell20.CanGrow = false;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[P7]")
		});
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "P7";
		xrTableCell20.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell20.Weight = 0.38296333635789237;
		xrTableCell20.WordWrap = false;
		xrTableCell21.CanGrow = false;
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[P8]")
		});
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.Text = "P8";
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 0.38296333635789215;
		xrTableCell21.WordWrap = false;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[F9]")
		});
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xrTableCell22.Text = "F9";
		xrTableCell22.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell22.Weight = 0.3829630441800661;
		xrTableCell22.WordWrap = false;
		GroupHeader1.Controls.AddRange(new XRControl[2] { xrLine2, xrTable1 });
		GroupHeader1.HeightF = 27.08333f;
		GroupHeader1.Name = "GroupHeader1";
		xrLine2.LineWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(0f, 0f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(766f, 2.083333f);
		xrTable1.BackColor = Color.LightGray;
		xrTable1.BorderColor = Color.Black;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Consolas", 11f, DXFontStyle.Bold);
		xrTable1.ForeColor = Color.Black;
		xrTable1.LocationFloat = new PointFloat(0f, 2.083333f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(766f, 25f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseForeColor = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell1, xrTableCell2, xrTableCell3, xrTableCell4, xrTableCell5, xrTableCell6, xrTableCell7, xrTableCell8, xrTableCell9, xrTableCell10,
			xrTableCell11
		});
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.Text = "SUBJECT";
		xrTableCell1.Weight = 2.12757404180107;
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell2.StylePriority.UsePadding = false;
		xrTableCell2.Text = "PAPER";
		xrTableCell2.Weight = 0.8689510547240269;
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "D1";
		xrTableCell3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell3.Weight = 0.3829633201257908;
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.Text = "D2";
		xrTableCell4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell4.Weight = 0.382963320125791;
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "C3";
		xrTableCell5.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell5.Weight = 0.38296332012579115;
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.Text = "C4";
		xrTableCell6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell6.Weight = 0.38296332012579093;
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Text = "C5";
		xrTableCell7.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell7.Weight = 0.38296333635789237;
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.Text = "C6";
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 0.38296333635789237;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.Text = "P7";
		xrTableCell9.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell9.Weight = 0.38296333635789237;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "P8";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.38296333635789215;
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseTextAlignment = false;
		xrTableCell11.Text = "F9";
		xrTableCell11.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell11.Weight = 0.3829630441800661;
		ReportHeader.Controls.AddRange(new XRControl[1] { xrLabel1 });
		ReportHeader.HeightF = 23f;
		ReportHeader.Name = "ReportHeader";
		xrLabel1.Font = new DXFont("Consolas", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(0f, 0f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(767f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Count of grades per paper (Subsidiary subjects)";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		GroupFooter1.Controls.AddRange(new XRControl[1] { xrLine1 });
		GroupFooter1.HeightF = 2.083333f;
		GroupFooter1.Name = "GroupFooter1";
		xrLine1.LineWidth = 2f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(766f, 2.083333f);
		base.Bands.AddRange(new Band[6] { TopMargin, BottomMargin, Detail, GroupHeader1, ReportHeader, GroupFooter1 });
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
