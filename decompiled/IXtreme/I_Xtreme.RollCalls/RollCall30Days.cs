using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.RollCalls.RollCallSourceTableAdapters;

namespace I_Xtreme.RollCalls;

public class RollCall30Days : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private RollCallSource rollCallSource1;

	private AttendanceSheetRollCallTableAdapter attendanceSheetRollCallTableAdapter;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private ReportHeaderBand ReportHeader;

	private PageFooterBand PageFooter;

	private XRPageInfo xrPageInfo1;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRSubreport xrSubreport1;

	private XRLabel xrLabel3;

	private CalculatedField calculatedField1;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell45;

	private XRTableCell xrTableCell42;

	private XRTableCell xrTableCell41;

	private XRTableCell xrTableCell40;

	private XRTableCell xrTableCell39;

	private XRTableCell xrTableCell38;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell36;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell33;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell43;

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

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell46;

	private XRTableCell xrTableCell47;

	private XRTableCell xrTableCell48;

	private XRTableCell xrTableCell49;

	private XRTableCell xrTableCell50;

	private XRTableCell xrTableCell51;

	private XRTableCell xrTableCell52;

	private XRTableCell xrTableCell53;

	private XRTableCell xrTableCell54;

	private XRTableCell xrTableCell55;

	private XRTableCell xrTableCell56;

	private XRTableCell xrTableCell57;

	private XRTableCell xrTableCell58;

	private XRTableCell xrTableCell59;

	private XRTableCell xrTableCell60;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell62;

	private XRTableCell xrTableCell63;

	private XRTableCell xrTableCell64;

	private XRTableCell xrTableCell65;

	private XRTableCell xrTableCell66;

	public RollCall30Days()
	{
		InitializeComponent();
	}

	private void RollCall7Days_BeforePrint(object sender, CancelEventArgs e)
	{
		xrLabel2.Text = RollCallHelper.ClassId + "," + RollCallHelper.StreamId;
		xrLabel3.Text = RollCallHelper.ClassId + "," + RollCallHelper.StreamId;
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
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		rollCallSource1 = new RollCallSource();
		attendanceSheetRollCallTableAdapter = new AttendanceSheetRollCallTableAdapter();
		GroupHeader1 = new GroupHeaderBand();
		xrTable2 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell20 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		ReportHeader = new ReportHeaderBand();
		xrSubreport1 = new XRSubreport();
		PageFooter = new PageFooterBand();
		xrLabel3 = new XRLabel();
		xrPageInfo1 = new XRPageInfo();
		calculatedField1 = new CalculatedField();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell39 = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
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
		xrTableCell21 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell46 = new XRTableCell();
		xrTableCell47 = new XRTableCell();
		xrTableCell48 = new XRTableCell();
		xrTableCell49 = new XRTableCell();
		xrTableCell50 = new XRTableCell();
		xrTableCell51 = new XRTableCell();
		xrTableCell52 = new XRTableCell();
		xrTableCell53 = new XRTableCell();
		xrTableCell54 = new XRTableCell();
		xrTableCell55 = new XRTableCell();
		xrTableCell56 = new XRTableCell();
		xrTableCell57 = new XRTableCell();
		xrTableCell58 = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableCell60 = new XRTableCell();
		xrTableCell61 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		xrTableCell63 = new XRTableCell();
		xrTableCell64 = new XRTableCell();
		xrTableCell65 = new XRTableCell();
		xrTableCell66 = new XRTableCell();
		((ISupportInitialize)rollCallSource1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 23f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 23f;
		BottomMargin.Name = "BottomMargin";
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		Detail.SortFields.AddRange(new GroupField[2]
		{
			new GroupField("Sex", XRColumnSortOrder.Ascending),
			new GroupField("Name", XRColumnSortOrder.Ascending)
		});
		rollCallSource1.DataSetName = "RollCallSource";
		rollCallSource1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		attendanceSheetRollCallTableAdapter.ClearBeforeFill = true;
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrTable2 });
		GroupHeader1.HeightF = 25f;
		GroupHeader1.Name = "GroupHeader1";
		GroupHeader1.RepeatEveryPage = true;
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(1120f, 25f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow2.Cells.AddRange(new XRTableCell[33]
		{
			xrTableCell20, xrTableCell11, xrTableCell44, xrTableCell45, xrTableCell12, xrTableCell42, xrTableCell13, xrTableCell41, xrTableCell14, xrTableCell40,
			xrTableCell15, xrTableCell39, xrTableCell16, xrTableCell38, xrTableCell17, xrTableCell37, xrTableCell18, xrTableCell36, xrTableCell19, xrTableCell35,
			xrTableCell23, xrTableCell29, xrTableCell24, xrTableCell30, xrTableCell25, xrTableCell31, xrTableCell26, xrTableCell32, xrTableCell27, xrTableCell33,
			xrTableCell28, xrTableCell34, xrTableCell43
		});
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell20.Font = new DXFont("Arial", 7f);
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "No.";
		xrTableCell20.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell20.Weight = 0.7105634747354511;
		xrTableCell11.Font = new DXFont("Arial", 7f);
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.StylePriority.UseTextAlignment = false;
		xrTableCell11.Text = "Name";
		xrTableCell11.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell11.Weight = 3.789671683786834;
		xrTableCell12.CanGrow = false;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date2]")
		});
		xrTableCell12.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.Text = "Sex";
		xrTableCell12.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell12.TextFormatString = "{0:dd-MMM}";
		xrTableCell12.Weight = 0.7105634239504894;
		xrTableCell12.WordWrap = false;
		xrTableCell13.CanGrow = false;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date4]")
		});
		xrTableCell13.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.StylePriority.UseTextAlignment = false;
		xrTableCell13.Text = "xrTableCell2";
		xrTableCell13.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell13.TextFormatString = "{0:dd-MMM}";
		xrTableCell13.Weight = 0.7105635063575222;
		xrTableCell13.WordWrap = false;
		xrTableCell14.CanGrow = false;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date6]")
		});
		xrTableCell14.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.Text = "xrTableCell3";
		xrTableCell14.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell14.TextFormatString = "{0:dd-MMM}";
		xrTableCell14.Weight = 0.7105635021115675;
		xrTableCell14.WordWrap = false;
		xrTableCell15.CanGrow = false;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date8]")
		});
		xrTableCell15.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "xrTableCell4";
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.TextFormatString = "{0:dd-MMM}";
		xrTableCell15.Weight = 0.7105636050148907;
		xrTableCell15.WordWrap = false;
		xrTableCell16.CanGrow = false;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date10]")
		});
		xrTableCell16.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "xrTableCell5";
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.TextFormatString = "{0:dd-MMM}";
		xrTableCell16.Weight = 0.7105635089387565;
		xrTableCell16.WordWrap = false;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date12]")
		});
		xrTableCell17.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "xrTableCell6";
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.TextFormatString = "{0:dd-MMM}";
		xrTableCell17.Weight = 0.7105635292422536;
		xrTableCell17.WordWrap = false;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date14]")
		});
		xrTableCell18.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "xrTableCell7";
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.TextFormatString = "{0:dd-MMM}";
		xrTableCell18.Weight = 0.7105635537894894;
		xrTableCell18.WordWrap = false;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date16]")
		});
		xrTableCell19.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.Text = "xrTableCell8";
		xrTableCell19.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell19.TextFormatString = "{0:dd-MMM}";
		xrTableCell19.Weight = 0.7105635532295023;
		xrTableCell19.WordWrap = false;
		xrLabel2.Borders = BorderSide.Bottom;
		xrLabel2.Font = new DXFont("Arial", 12f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(0f, 155.375f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(1120f, 23f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel1";
		xrLabel2.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.Borders = BorderSide.Top;
		xrLabel1.Font = new DXFont("Arial", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(0f, 132.375f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(1120f, 23f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Monthly Rollcall";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		ReportHeader.Controls.AddRange(new XRControl[3] { xrLabel2, xrLabel1, xrSubreport1 });
		ReportHeader.HeightF = 191.4166f;
		ReportHeader.Name = "ReportHeader";
		xrSubreport1.LocationFloat = new PointFloat(158f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.ReportSource = new SchoolHeader_Center();
		xrSubreport1.SizeF = new SizeF(804f, 119.0833f);
		PageFooter.Controls.AddRange(new XRControl[2] { xrLabel3, xrPageInfo1 });
		PageFooter.HeightF = 36.87509f;
		PageFooter.Name = "PageFooter";
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.Font = new DXFont("Arial", 10f, DXFontStyle.Bold);
		xrLabel3.LocationFloat = new PointFloat(9.999998f, 6.00001f);
		xrLabel3.Multiline = true;
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(422f, 23f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "xrLabel1";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		xrPageInfo1.Font = new DXFont("Arial", 10f, DXFontStyle.Bold);
		xrPageInfo1.LocationFloat = new PointFloat(892f, 6f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.SizeF = new SizeF(215.625f, 23f);
		xrPageInfo1.StylePriority.UseFont = false;
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
		xrPageInfo1.TextFormatString = "Page {0} of {1}";
		calculatedField1.DataMember = "AttendanceSheetRollCall";
		calculatedField1.Name = "calculatedField1";
		xrTableCell23.CanGrow = false;
		xrTableCell23.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date18]")
		});
		xrTableCell23.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.StylePriority.UseTextAlignment = false;
		xrTableCell23.Text = "xrTableCell23";
		xrTableCell23.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell23.TextFormatString = "{0:dd-MMM}";
		xrTableCell23.Weight = 0.7105634160718959;
		xrTableCell23.WordWrap = false;
		xrTableCell24.CanGrow = false;
		xrTableCell24.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date20]")
		});
		xrTableCell24.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.StylePriority.UseTextAlignment = false;
		xrTableCell24.Text = "xrTableCell24";
		xrTableCell24.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell24.TextFormatString = "{0:dd-MMM}";
		xrTableCell24.Weight = 0.7105634160718959;
		xrTableCell24.WordWrap = false;
		xrTableCell25.CanGrow = false;
		xrTableCell25.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date22]")
		});
		xrTableCell25.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.StylePriority.UseTextAlignment = false;
		xrTableCell25.Text = "xrTableCell25";
		xrTableCell25.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell25.TextFormatString = "{0:dd-MMM}";
		xrTableCell25.Weight = 0.7105634160718959;
		xrTableCell25.WordWrap = false;
		xrTableCell26.CanGrow = false;
		xrTableCell26.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date24]")
		});
		xrTableCell26.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.StylePriority.UseTextAlignment = false;
		xrTableCell26.Text = "xrTableCell26";
		xrTableCell26.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell26.TextFormatString = "{0:dd-MMM}";
		xrTableCell26.Weight = 0.7105635064247134;
		xrTableCell26.WordWrap = false;
		xrTableCell27.CanGrow = false;
		xrTableCell27.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date26]")
		});
		xrTableCell27.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.StylePriority.UseFont = false;
		xrTableCell27.StylePriority.UseTextAlignment = false;
		xrTableCell27.Text = "xrTableCell27";
		xrTableCell27.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell27.TextFormatString = "{0:dd-MMM}";
		xrTableCell27.Weight = 0.7105635064247136;
		xrTableCell27.WordWrap = false;
		xrTableCell28.CanGrow = false;
		xrTableCell28.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date28]")
		});
		xrTableCell28.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UseTextAlignment = false;
		xrTableCell28.Text = "xrTableCell28";
		xrTableCell28.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell28.TextFormatString = "{0:dd-MMM}";
		xrTableCell28.Weight = 0.7105635064247133;
		xrTableCell28.WordWrap = false;
		xrTableCell29.CanGrow = false;
		xrTableCell29.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date19]")
		});
		xrTableCell29.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.StylePriority.UseTextAlignment = false;
		xrTableCell29.Text = "xrTableCell29";
		xrTableCell29.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell29.TextFormatString = "{0:dd-MMM}";
		xrTableCell29.Weight = 0.7105634160718957;
		xrTableCell29.WordWrap = false;
		xrTableCell30.CanGrow = false;
		xrTableCell30.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date21]")
		});
		xrTableCell30.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.StylePriority.UseTextAlignment = false;
		xrTableCell30.Text = "xrTableCell30";
		xrTableCell30.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell30.TextFormatString = "{0:dd-MMM}";
		xrTableCell30.Weight = 0.7105634160718959;
		xrTableCell30.WordWrap = false;
		xrTableCell31.CanGrow = false;
		xrTableCell31.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date23]")
		});
		xrTableCell31.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UseTextAlignment = false;
		xrTableCell31.Text = "xrTableCell31";
		xrTableCell31.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell31.TextFormatString = "{0:dd-MMM}";
		xrTableCell31.Weight = 0.710563416071896;
		xrTableCell31.WordWrap = false;
		xrTableCell32.CanGrow = false;
		xrTableCell32.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date25]")
		});
		xrTableCell32.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.StylePriority.UseTextAlignment = false;
		xrTableCell32.Text = "xrTableCell32";
		xrTableCell32.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell32.TextFormatString = "{0:dd-MMM}";
		xrTableCell32.Weight = 0.7105635064247136;
		xrTableCell32.WordWrap = false;
		xrTableCell33.CanGrow = false;
		xrTableCell33.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date27]")
		});
		xrTableCell33.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.StylePriority.UseTextAlignment = false;
		xrTableCell33.Text = "xrTableCell33";
		xrTableCell33.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell33.TextFormatString = "{0:dd-MMM}";
		xrTableCell33.Weight = 0.7105635064247136;
		xrTableCell33.WordWrap = false;
		xrTableCell34.CanGrow = false;
		xrTableCell34.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date29]")
		});
		xrTableCell34.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.StylePriority.UseTextAlignment = false;
		xrTableCell34.Text = "xrTableCell34";
		xrTableCell34.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell34.TextFormatString = "{0:dd-MMM}";
		xrTableCell34.Weight = 0.7105635064247134;
		xrTableCell34.WordWrap = false;
		xrTableCell35.CanGrow = false;
		xrTableCell35.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date17]")
		});
		xrTableCell35.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.StylePriority.UseTextAlignment = false;
		xrTableCell35.Text = "xrTableCell35";
		xrTableCell35.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell35.TextFormatString = "{0:dd-MMM}";
		xrTableCell35.Weight = 0.7105634160718961;
		xrTableCell35.WordWrap = false;
		xrTableCell36.CanGrow = false;
		xrTableCell36.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date15]")
		});
		xrTableCell36.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.StylePriority.UseFont = false;
		xrTableCell36.StylePriority.UseTextAlignment = false;
		xrTableCell36.Text = "xrTableCell36";
		xrTableCell36.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell36.TextFormatString = "{0:dd-MMM}";
		xrTableCell36.Weight = 0.7105635537894894;
		xrTableCell36.WordWrap = false;
		xrTableCell37.CanGrow = false;
		xrTableCell37.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date13]")
		});
		xrTableCell37.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.StylePriority.UseTextAlignment = false;
		xrTableCell37.Text = "xrTableCell37";
		xrTableCell37.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell37.TextFormatString = "{0:dd-MMM}";
		xrTableCell37.Weight = 0.7105635292422532;
		xrTableCell37.WordWrap = false;
		xrTableCell38.CanGrow = false;
		xrTableCell38.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date11]")
		});
		xrTableCell38.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.StylePriority.UseTextAlignment = false;
		xrTableCell38.Text = "xrTableCell38";
		xrTableCell38.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell38.TextFormatString = "{0:dd-MMM}";
		xrTableCell38.Weight = 0.7105635537894894;
		xrTableCell38.WordWrap = false;
		xrTableCell39.CanGrow = false;
		xrTableCell39.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date9]")
		});
		xrTableCell39.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.StylePriority.UseFont = false;
		xrTableCell39.StylePriority.UseTextAlignment = false;
		xrTableCell39.Text = "xrTableCell39";
		xrTableCell39.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell39.TextFormatString = "{0:dd-MMM}";
		xrTableCell39.Weight = 0.7105635153134258;
		xrTableCell39.WordWrap = false;
		xrTableCell40.CanGrow = false;
		xrTableCell40.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date7]")
		});
		xrTableCell40.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.StylePriority.UseFont = false;
		xrTableCell40.StylePriority.UseTextAlignment = false;
		xrTableCell40.Text = "xrTableCell40";
		xrTableCell40.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell40.TextFormatString = "{0:dd-MMM}";
		xrTableCell40.Weight = 0.7105635918130337;
		xrTableCell40.WordWrap = false;
		xrTableCell41.CanGrow = false;
		xrTableCell41.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date5]")
		});
		xrTableCell41.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.StylePriority.UseFont = false;
		xrTableCell41.StylePriority.UseTextAlignment = false;
		xrTableCell41.Text = "xrTableCell41";
		xrTableCell41.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell41.TextFormatString = "{0:dd-MMM}";
		xrTableCell41.Weight = 0.7105635063575217;
		xrTableCell41.WordWrap = false;
		xrTableCell42.CanGrow = false;
		xrTableCell42.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date3]")
		});
		xrTableCell42.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.StylePriority.UseFont = false;
		xrTableCell42.StylePriority.UseTextAlignment = false;
		xrTableCell42.Text = "xrTableCell42";
		xrTableCell42.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell42.TextFormatString = "{0:dd-MMM}";
		xrTableCell42.Weight = 0.710563510588881;
		xrTableCell42.WordWrap = false;
		xrTableCell43.CanGrow = false;
		xrTableCell43.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date30]")
		});
		xrTableCell43.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.StylePriority.UseFont = false;
		xrTableCell43.StylePriority.UseTextAlignment = false;
		xrTableCell43.Text = "xrTableCell43";
		xrTableCell43.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell43.TextFormatString = "{0:dd-MMM}";
		xrTableCell43.Weight = 0.7105629923159441;
		xrTableCell43.WordWrap = false;
		xrTableCell44.CanGrow = false;
		xrTableCell44.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.StylePriority.UseFont = false;
		xrTableCell44.StylePriority.UseTextAlignment = false;
		xrTableCell44.Text = "Sex";
		xrTableCell44.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell44.Weight = 0.7105634660643113;
		xrTableCell44.WordWrap = false;
		xrTableCell45.CanGrow = false;
		xrTableCell45.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date1]")
		});
		xrTableCell45.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.StylePriority.UseFont = false;
		xrTableCell45.StylePriority.UseTextAlignment = false;
		xrTableCell45.Text = "xrTableCell45";
		xrTableCell45.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell45.TextFormatString = "{0:dd-MMM}";
		xrTableCell45.Weight = 0.7105633881301983;
		xrTableCell45.WordWrap = false;
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(1120f, 25f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[33]
		{
			xrTableCell1, xrTableCell2, xrTableCell3, xrTableCell4, xrTableCell5, xrTableCell6, xrTableCell7, xrTableCell8, xrTableCell9, xrTableCell10,
			xrTableCell21, xrTableCell22, xrTableCell46, xrTableCell47, xrTableCell48, xrTableCell49, xrTableCell50, xrTableCell51, xrTableCell52, xrTableCell53,
			xrTableCell54, xrTableCell55, xrTableCell56, xrTableCell57, xrTableCell58, xrTableCell59, xrTableCell60, xrTableCell61, xrTableCell62, xrTableCell63,
			xrTableCell64, xrTableCell65, xrTableCell66
		});
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumRecordNumber([calculatedField1])")
		});
		xrTableCell1.Font = new DXFont("Arial", 7f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Report;
		xrTableCell1.Summary = xRSummary;
		xrTableCell1.Text = "No.";
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 0.7105634747354511;
		xrTableCell1.WordWrap = false;
		xrTableCell2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Name]")
		});
		xrTableCell2.Font = new DXFont("Arial", 7f);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "Name";
		xrTableCell2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell2.Weight = 3.789671683786834;
		xrTableCell3.CanGrow = false;
		xrTableCell3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell3.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "xrTableCell44";
		xrTableCell3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell3.Weight = 0.7105634660643113;
		xrTableCell3.WordWrap = false;
		xrTableCell4.CanGrow = false;
		xrTableCell4.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell4.Weight = 0.7105633881301983;
		xrTableCell4.WordWrap = false;
		xrTableCell5.CanGrow = false;
		xrTableCell5.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell5.Weight = 0.7105634239504894;
		xrTableCell5.WordWrap = false;
		xrTableCell6.CanGrow = false;
		xrTableCell6.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell6.Weight = 0.710563510588881;
		xrTableCell6.WordWrap = false;
		xrTableCell7.CanGrow = false;
		xrTableCell7.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell7.Weight = 0.7105635063575222;
		xrTableCell7.WordWrap = false;
		xrTableCell8.CanGrow = false;
		xrTableCell8.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 0.7105635063575217;
		xrTableCell8.WordWrap = false;
		xrTableCell9.CanGrow = false;
		xrTableCell9.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell9.Weight = 0.7105635021115675;
		xrTableCell9.WordWrap = false;
		xrTableCell10.CanGrow = false;
		xrTableCell10.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.7105635918130337;
		xrTableCell10.WordWrap = false;
		xrTableCell21.CanGrow = false;
		xrTableCell21.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 0.7105636050148907;
		xrTableCell21.WordWrap = false;
		xrTableCell22.CanGrow = false;
		xrTableCell22.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xrTableCell22.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell22.Weight = 0.7105635153134258;
		xrTableCell22.WordWrap = false;
		xrTableCell46.CanGrow = false;
		xrTableCell46.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.StylePriority.UseFont = false;
		xrTableCell46.StylePriority.UseTextAlignment = false;
		xrTableCell46.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell46.Weight = 0.7105635089387565;
		xrTableCell46.WordWrap = false;
		xrTableCell47.CanGrow = false;
		xrTableCell47.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell47.Name = "xrTableCell47";
		xrTableCell47.StylePriority.UseFont = false;
		xrTableCell47.StylePriority.UseTextAlignment = false;
		xrTableCell47.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell47.Weight = 0.7105635537894894;
		xrTableCell47.WordWrap = false;
		xrTableCell48.CanGrow = false;
		xrTableCell48.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell48.Name = "xrTableCell48";
		xrTableCell48.StylePriority.UseFont = false;
		xrTableCell48.StylePriority.UseTextAlignment = false;
		xrTableCell48.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell48.Weight = 0.7105635292422536;
		xrTableCell48.WordWrap = false;
		xrTableCell49.CanGrow = false;
		xrTableCell49.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell49.Name = "xrTableCell49";
		xrTableCell49.StylePriority.UseFont = false;
		xrTableCell49.StylePriority.UseTextAlignment = false;
		xrTableCell49.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell49.Weight = 0.7105635292422532;
		xrTableCell49.WordWrap = false;
		xrTableCell50.CanGrow = false;
		xrTableCell50.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell50.Name = "xrTableCell50";
		xrTableCell50.StylePriority.UseFont = false;
		xrTableCell50.StylePriority.UseTextAlignment = false;
		xrTableCell50.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell50.Weight = 0.7105635537894894;
		xrTableCell50.WordWrap = false;
		xrTableCell51.CanGrow = false;
		xrTableCell51.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell51.Name = "xrTableCell51";
		xrTableCell51.StylePriority.UseFont = false;
		xrTableCell51.StylePriority.UseTextAlignment = false;
		xrTableCell51.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell51.Weight = 0.7105635537894894;
		xrTableCell51.WordWrap = false;
		xrTableCell52.CanGrow = false;
		xrTableCell52.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell52.Name = "xrTableCell52";
		xrTableCell52.StylePriority.UseFont = false;
		xrTableCell52.StylePriority.UseTextAlignment = false;
		xrTableCell52.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell52.Weight = 0.7105635532295023;
		xrTableCell52.WordWrap = false;
		xrTableCell53.CanGrow = false;
		xrTableCell53.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell53.Name = "xrTableCell53";
		xrTableCell53.StylePriority.UseFont = false;
		xrTableCell53.StylePriority.UseTextAlignment = false;
		xrTableCell53.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell53.Weight = 0.7105634160718961;
		xrTableCell53.WordWrap = false;
		xrTableCell54.CanGrow = false;
		xrTableCell54.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell54.Name = "xrTableCell54";
		xrTableCell54.StylePriority.UseFont = false;
		xrTableCell54.StylePriority.UseTextAlignment = false;
		xrTableCell54.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell54.Weight = 0.7105634160718959;
		xrTableCell54.WordWrap = false;
		xrTableCell55.CanGrow = false;
		xrTableCell55.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell55.Name = "xrTableCell55";
		xrTableCell55.StylePriority.UseFont = false;
		xrTableCell55.StylePriority.UseTextAlignment = false;
		xrTableCell55.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell55.Weight = 0.7105634160718957;
		xrTableCell55.WordWrap = false;
		xrTableCell56.CanGrow = false;
		xrTableCell56.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell56.Name = "xrTableCell56";
		xrTableCell56.StylePriority.UseFont = false;
		xrTableCell56.StylePriority.UseTextAlignment = false;
		xrTableCell56.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell56.Weight = 0.7105634160718959;
		xrTableCell56.WordWrap = false;
		xrTableCell57.CanGrow = false;
		xrTableCell57.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell57.Name = "xrTableCell57";
		xrTableCell57.StylePriority.UseFont = false;
		xrTableCell57.StylePriority.UseTextAlignment = false;
		xrTableCell57.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell57.Weight = 0.7105634160718959;
		xrTableCell57.WordWrap = false;
		xrTableCell58.CanGrow = false;
		xrTableCell58.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell58.Name = "xrTableCell58";
		xrTableCell58.StylePriority.UseFont = false;
		xrTableCell58.StylePriority.UseTextAlignment = false;
		xrTableCell58.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell58.Weight = 0.7105634160718959;
		xrTableCell58.WordWrap = false;
		xrTableCell59.CanGrow = false;
		xrTableCell59.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell59.Name = "xrTableCell59";
		xrTableCell59.StylePriority.UseFont = false;
		xrTableCell59.StylePriority.UseTextAlignment = false;
		xrTableCell59.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell59.Weight = 0.710563416071896;
		xrTableCell59.WordWrap = false;
		xrTableCell60.CanGrow = false;
		xrTableCell60.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.StylePriority.UseFont = false;
		xrTableCell60.StylePriority.UseTextAlignment = false;
		xrTableCell60.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell60.Weight = 0.7105635064247134;
		xrTableCell60.WordWrap = false;
		xrTableCell61.CanGrow = false;
		xrTableCell61.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.StylePriority.UseFont = false;
		xrTableCell61.StylePriority.UseTextAlignment = false;
		xrTableCell61.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell61.Weight = 0.7105635064247136;
		xrTableCell61.WordWrap = false;
		xrTableCell62.CanGrow = false;
		xrTableCell62.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.StylePriority.UseFont = false;
		xrTableCell62.StylePriority.UseTextAlignment = false;
		xrTableCell62.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell62.Weight = 0.7105635064247136;
		xrTableCell62.WordWrap = false;
		xrTableCell63.CanGrow = false;
		xrTableCell63.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell63.Name = "xrTableCell63";
		xrTableCell63.StylePriority.UseFont = false;
		xrTableCell63.StylePriority.UseTextAlignment = false;
		xrTableCell63.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell63.Weight = 0.7105635064247136;
		xrTableCell63.WordWrap = false;
		xrTableCell64.CanGrow = false;
		xrTableCell64.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell64.Name = "xrTableCell64";
		xrTableCell64.StylePriority.UseFont = false;
		xrTableCell64.StylePriority.UseTextAlignment = false;
		xrTableCell64.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell64.Weight = 0.7105635064247133;
		xrTableCell64.WordWrap = false;
		xrTableCell65.CanGrow = false;
		xrTableCell65.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell65.Name = "xrTableCell65";
		xrTableCell65.StylePriority.UseFont = false;
		xrTableCell65.StylePriority.UseTextAlignment = false;
		xrTableCell65.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell65.Weight = 0.7105635064247134;
		xrTableCell65.WordWrap = false;
		xrTableCell66.CanGrow = false;
		xrTableCell66.Font = new DXFont("Arial Narrow", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell66.Name = "xrTableCell66";
		xrTableCell66.StylePriority.UseFont = false;
		xrTableCell66.StylePriority.UseTextAlignment = false;
		xrTableCell66.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell66.Weight = 0.7105629923159441;
		xrTableCell66.WordWrap = false;
		base.Bands.AddRange(new Band[6] { TopMargin, BottomMargin, Detail, GroupHeader1, ReportHeader, PageFooter });
		base.CalculatedFields.AddRange(new CalculatedField[1] { calculatedField1 });
		base.ComponentStorage.AddRange(new IComponent[1] { rollCallSource1 });
		base.DataAdapter = attendanceSheetRollCallTableAdapter;
		base.DataMember = "AttendanceSheetRollCall";
		base.DataSource = rollCallSource1;
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.PageHeight = 827;
		base.PageWidth = 1169;
		base.PaperKind = DXPaperKind.A4Rotated;
		base.SnapGridSize = 2f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "21.2";
		BeforePrint += RollCall7Days_BeforePrint;
		((ISupportInitialize)rollCallSource1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
