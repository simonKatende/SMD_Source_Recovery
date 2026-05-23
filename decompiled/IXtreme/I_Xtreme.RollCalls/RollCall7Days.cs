using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.RollCalls.RollCallSourceTableAdapters;

namespace I_Xtreme.RollCalls;

public class RollCall7Days : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

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

	private XRTableCell xrTableCell10;

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

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell20;

	private ReportHeaderBand ReportHeader;

	private PageFooterBand PageFooter;

	private XRPageInfo xrPageInfo1;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRSubreport xrSubreport1;

	private XRLabel xrLabel3;

	private CalculatedField calculatedField1;

	public RollCall7Days()
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
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell9 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		rollCallSource1 = new RollCallSource();
		attendanceSheetRollCallTableAdapter = new AttendanceSheetRollCallTableAdapter();
		GroupHeader1 = new GroupHeaderBand();
		xrTable2 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell20 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
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
		xrPageInfo1 = new XRPageInfo();
		xrLabel3 = new XRLabel();
		calculatedField1 = new CalculatedField();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)rollCallSource1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
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
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(804f, 25f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell9, xrTableCell10, xrTableCell21, xrTableCell1, xrTableCell2, xrTableCell3, xrTableCell4, xrTableCell5, xrTableCell6, xrTableCell7,
			xrTableCell8
		});
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell9.CanGrow = false;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumRecordNumber([calculatedField1])")
		});
		xrTableCell9.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Report;
		xrTableCell9.Summary = xRSummary;
		xrTableCell9.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell9.Weight = 0.5098086455792148;
		xrTableCell9.WordWrap = false;
		xrTableCell10.CanGrow = false;
		xrTableCell10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Name]")
		});
		xrTableCell10.Font = new DXFont("Arial", 8f);
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "xrTableCell10";
		xrTableCell10.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell10.Weight = 2.5898276592666685;
		xrTableCell10.WordWrap = false;
		xrTableCell21.CanGrow = false;
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentId]")
		});
		xrTableCell21.Font = new DXFont("Arial", 8f);
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.Text = "xrTableCell21";
		xrTableCell21.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell21.Weight = 1.0196171880876173;
		xrTableCell21.WordWrap = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell1.Font = new DXFont("Arial", 8f);
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.Weight = 0.5098085523759897;
		xrTableCell2.Font = new DXFont("Arial", 8f);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.TextFormatString = "{0:dd-MMM}";
		xrTableCell2.Weight = 0.509808550773251;
		xrTableCell3.Font = new DXFont("Arial", 8f);
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.TextFormatString = "{0:dd-MMM}";
		xrTableCell3.Weight = 0.5098085520327842;
		xrTableCell4.Font = new DXFont("Arial", 8f);
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.TextFormatString = "{0:dd-MMM}";
		xrTableCell4.Weight = 0.5098085520327902;
		xrTableCell5.Font = new DXFont("Arial", 8f);
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.TextFormatString = "{0:dd-MMM}";
		xrTableCell5.Weight = 0.5098085909280977;
		xrTableCell6.Font = new DXFont("Arial", 8f);
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.TextFormatString = "{0:dd-MMM}";
		xrTableCell6.Weight = 0.5098085909280983;
		xrTableCell7.Font = new DXFont("Arial", 8f);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.TextFormatString = "{0:dd-MMM}";
		xrTableCell7.Weight = 0.5098085869156881;
		xrTableCell8.Font = new DXFont("Arial", 8f);
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.TextFormatString = "{0:dd-MMM}";
		xrTableCell8.Weight = 0.5098085262009404;
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
		xrTable2.SizeF = new SizeF(804f, 25f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow2.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell20, xrTableCell11, xrTableCell22, xrTableCell12, xrTableCell13, xrTableCell14, xrTableCell15, xrTableCell16, xrTableCell17, xrTableCell18,
			xrTableCell19
		});
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell20.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "No.";
		xrTableCell20.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell20.Weight = 1.1694864279272608;
		xrTableCell11.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.StylePriority.UseTextAlignment = false;
		xrTableCell11.Text = "Name";
		xrTableCell11.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell11.Weight = 5.9409915392474195;
		xrTableCell22.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell22.Multiline = true;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xrTableCell22.Text = "StudentID";
		xrTableCell22.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell22.Weight = 2.3389730146579497;
		xrTableCell12.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell12.Multiline = true;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.Text = "Sex";
		xrTableCell12.Weight = 1.1694864731076817;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date1]")
		});
		xrTableCell13.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell13.Multiline = true;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.Text = "xrTableCell2";
		xrTableCell13.TextFormatString = "{0:dd-MMM}";
		xrTableCell13.Weight = 1.1694864646449643;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date2]")
		});
		xrTableCell14.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.Text = "xrTableCell3";
		xrTableCell14.TextFormatString = "{0:dd-MMM}";
		xrTableCell14.Weight = 1.169486635555986;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date3]")
		});
		xrTableCell15.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.Text = "xrTableCell4";
		xrTableCell15.TextFormatString = "{0:dd-MMM}";
		xrTableCell15.Weight = 1.169486482556771;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date4]")
		});
		xrTableCell16.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.Text = "xrTableCell5";
		xrTableCell16.TextFormatString = "{0:dd-MMM}";
		xrTableCell16.Weight = 1.1694865595088986;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date5]")
		});
		xrTableCell17.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.Text = "xrTableCell6";
		xrTableCell17.TextFormatString = "{0:dd-MMM}";
		xrTableCell17.Weight = 1.1694865104144272;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date6]")
		});
		xrTableCell18.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.Text = "xrTableCell7";
		xrTableCell18.TextFormatString = "{0:dd-MMM}";
		xrTableCell18.Weight = 1.1694865595088983;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Date7]")
		});
		xrTableCell19.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell19.Multiline = true;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.Text = "xrTableCell8";
		xrTableCell19.TextFormatString = "{0:dd-MMM}";
		xrTableCell19.Weight = 1.1694870068962526;
		xrLabel2.Borders = BorderSide.Bottom;
		xrLabel2.Font = new DXFont("Arial", 12f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(0f, 155.375f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(804.0001f, 23f);
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
		xrLabel1.SizeF = new SizeF(804.0001f, 23f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Weekly Rollcall";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		ReportHeader.Controls.AddRange(new XRControl[3] { xrLabel2, xrLabel1, xrSubreport1 });
		ReportHeader.HeightF = 191.4166f;
		ReportHeader.Name = "ReportHeader";
		xrSubreport1.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.ReportSource = new SchoolHeader_Center();
		xrSubreport1.SizeF = new SizeF(804f, 119.0833f);
		PageFooter.Controls.AddRange(new XRControl[2] { xrLabel3, xrPageInfo1 });
		PageFooter.HeightF = 36.87509f;
		PageFooter.Name = "PageFooter";
		xrPageInfo1.Font = new DXFont("Arial", 10f, DXFontStyle.Bold);
		xrPageInfo1.LocationFloat = new PointFloat(578.375f, 6f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.SizeF = new SizeF(215.625f, 23f);
		xrPageInfo1.StylePriority.UseFont = false;
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
		xrPageInfo1.TextFormatString = "Page {0} of {1}";
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
		calculatedField1.DataMember = "AttendanceSheetRollCall";
		calculatedField1.Name = "calculatedField1";
		base.Bands.AddRange(new Band[6] { TopMargin, BottomMargin, Detail, GroupHeader1, ReportHeader, PageFooter });
		base.CalculatedFields.AddRange(new CalculatedField[1] { calculatedField1 });
		base.ComponentStorage.AddRange(new IComponent[1] { rollCallSource1 });
		base.DataAdapter = attendanceSheetRollCallTableAdapter;
		base.DataMember = "AttendanceSheetRollCall";
		base.DataSource = rollCallSource1;
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.SnapGridSize = 2f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "21.2";
		BeforePrint += RollCall7Days_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)rollCallSource1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
