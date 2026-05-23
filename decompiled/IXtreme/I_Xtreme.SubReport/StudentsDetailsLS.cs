using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.UI;
using I_Xtreme.NewCurriculumReports.ReportDatasets;
using I_Xtreme.NewCurriculumReports.ReportDatasets.StudentsSourceDSTableAdapters;
using I_Xtreme.NewCurriculumReports.SubReports;

namespace I_Xtreme.SubReport;

public class StudentsDetailsLS : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private XRBarCode xrBarCode2;

	private XRLabel xrLabel21;

	private XRLabel xrLabel20;

	private XRLabel xrLabel19;

	private XRLabel xrLabel18;

	private XRLabel xrLabel17;

	private XRLabel xrLabel15;

	private XRLabel xrLabel14;

	private XRLabel xrLabel13;

	private XRLabel xrLabel9;

	private XRPictureBox xrPictureBox2;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLine xrLine1;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow1;

	private XRTableCell lblNextTermBegins;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell18;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow11;

	private XRTableCell lblFeesBalance;

	private XRTableCell xrTableCell39;

	private XRTableRow xrTableRow9;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell33;

	private XRLabel xrLabel1;

	private StudentsSourceDS studentsSourceDS1;

	private adapterStudentsDS adapterStudentsDS;

	private XRShape xrShape7;

	public StudentsDetailsLS()
	{
		InitializeComponent();
	}

	private void StudentsDetailsLS_BeforePrint(object sender, CancelEventArgs e)
	{
		xrLabel1.Text = "END OF " + ReportParameters.Semester + " REPORT CARD";
		xrLabel20.Text = ReportParameters.Semester;
		lblNextTermBegins.Text = ReportHeader.NextTermBeginsOn.ToString("dd-MMM-yyyy");
		tblFeesInfo.Visible = ReportCustomization.ShowFeesBalance;
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
		QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
		ShapeRectangle shapeRectangle = new ShapeRectangle();
		TopMargin = new TopMarginBand();
		xrLabel1 = new XRLabel();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		tblFeesInfo = new XRTable();
		xrTableRow11 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		xrTableCell39 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		xrTableCell29 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		tblTermBegins = new XRTable();
		xrTableRow1 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell18 = new XRTableCell();
		xrBarCode2 = new XRBarCode();
		xrLabel21 = new XRLabel();
		xrLabel20 = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel18 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrPictureBox2 = new XRPictureBox();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLine1 = new XRLine();
		studentsSourceDS1 = new StudentsSourceDS();
		adapterStudentsDS = new adapterStudentsDS();
		xrShape7 = new XRShape();
		XRSubreport xRSubreport = new XRSubreport();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)studentsSourceDS1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		xRSubreport.LocationFloat = new PointFloat(337.0417f, 5.416711f);
		xRSubreport.Name = "xrSubreport1";
		xRSubreport.ParameterBindings.Add(new ParameterBinding("studNumber", null, "StudentsDS.StudentNumber"));
		xRSubreport.ReportSource = new Landscape2080();
		xRSubreport.SizeF = new SizeF(705.0001f, 578.5833f);
		TopMargin.BackColor = Color.Transparent;
		TopMargin.Controls.AddRange(new XRControl[2] { xrLabel1, xrShape7 });
		TopMargin.HeightF = 180f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.StylePriority.UseBackColor = false;
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		xrLabel1.BackColor = Color.Transparent;
		xrLabel1.CanGrow = false;
		xrLabel1.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel1.ForeColor = Color.Black;
		xrLabel1.LocationFloat = new PointFloat(350.0833f, 141.5833f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(355.375f, 22.99998f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel13";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.WordWrap = false;
		BottomMargin.HeightF = 23f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		Detail.Controls.AddRange(new XRControl[18]
		{
			tblFeesInfo, tblTermBegins, xrBarCode2, xrLabel21, xrLabel20, xrLabel19, xrLabel18, xrLabel17, xrLabel15, xrLabel14,
			xrLabel13, xrLabel9, xrPictureBox2, xrLabel8, xrLabel7, xrLabel6, xRSubreport, xrLine1
		});
		Detail.HeightF = 592f;
		Detail.Name = "Detail";
		Detail.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
		tblFeesInfo.LocationFloat = new PointFloat(2.916672f, 442f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow11, xrTableRow9 });
		tblFeesInfo.SizeF = new SizeF(316f, 48f);
		xrTableRow11.Cells.AddRange(new XRTableCell[2] { lblFeesBalance, xrTableCell39 });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		lblFeesBalance.BorderDashStyle = BorderDashStyle.Dash;
		lblFeesBalance.Borders = BorderSide.Bottom;
		lblFeesBalance.CanGrow = false;
		lblFeesBalance.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[cashOnAccount]")
		});
		lblFeesBalance.Font = new DXFont("Cascadia Mono", 9.75f);
		lblFeesBalance.ForeColor = Color.Black;
		lblFeesBalance.Name = "lblFeesBalance";
		lblFeesBalance.StylePriority.UseBorderDashStyle = false;
		lblFeesBalance.StylePriority.UseBorders = false;
		lblFeesBalance.StylePriority.UseFont = false;
		lblFeesBalance.StylePriority.UseForeColor = false;
		lblFeesBalance.StylePriority.UseTextAlignment = false;
		lblFeesBalance.TextAlignment = TextAlignment.BottomCenter;
		lblFeesBalance.TextFormatString = "{0:#,#.0}";
		lblFeesBalance.Weight = 0.55863693349796;
		lblFeesBalance.WordWrap = false;
		xrTableCell39.BorderDashStyle = BorderDashStyle.Dash;
		xrTableCell39.Borders = BorderSide.Bottom;
		xrTableCell39.Font = new DXFont("Cascadia Mono", 9.75f);
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.StylePriority.UseBorderDashStyle = false;
		xrTableCell39.StylePriority.UseBorders = false;
		xrTableCell39.StylePriority.UseFont = false;
		xrTableCell39.StylePriority.UseTextAlignment = false;
		xrTableCell39.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell39.Weight = 0.55863695379349;
		xrTableRow9.Cells.AddRange(new XRTableCell[2] { xrTableCell29, xrTableCell33 });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		xrTableCell29.BorderDashStyle = BorderDashStyle.Dash;
		xrTableCell29.Borders = BorderSide.Left | BorderSide.Right;
		xrTableCell29.CanGrow = false;
		xrTableCell29.Font = new DXFont("Cascadia Mono", 9.75f);
		xrTableCell29.ForeColor = Color.Black;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseBorderDashStyle = false;
		xrTableCell29.StylePriority.UseBorders = false;
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.StylePriority.UseForeColor = false;
		xrTableCell29.StylePriority.UseTextAlignment = false;
		xrTableCell29.Text = "Fees Balance";
		xrTableCell29.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell29.Weight = 0.55863693349796;
		xrTableCell29.WordWrap = false;
		xrTableCell33.BorderDashStyle = BorderDashStyle.Dash;
		xrTableCell33.Borders = BorderSide.Right;
		xrTableCell33.Font = new DXFont("Cascadia Mono", 9.75f);
		xrTableCell33.ForeColor = Color.Black;
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.StylePriority.UseBorderDashStyle = false;
		xrTableCell33.StylePriority.UseBorders = false;
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.StylePriority.UseForeColor = false;
		xrTableCell33.StylePriority.UseTextAlignment = false;
		xrTableCell33.Text = "Fees Next Term";
		xrTableCell33.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell33.Weight = 0.55863695379349;
		tblTermBegins.LocationFloat = new PointFloat(85.29166f, 384.5833f);
		tblTermBegins.Name = "tblTermBegins";
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow2 });
		tblTermBegins.SizeF = new SizeF(151.25f, 49.41669f);
		xrTableRow1.Cells.AddRange(new XRTableCell[1] { lblNextTermBegins });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		lblNextTermBegins.BorderDashStyle = BorderDashStyle.Dash;
		lblNextTermBegins.Borders = BorderSide.Bottom;
		lblNextTermBegins.CanGrow = false;
		lblNextTermBegins.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblNextTermBegins.ForeColor = Color.Black;
		lblNextTermBegins.Name = "lblNextTermBegins";
		lblNextTermBegins.StylePriority.UseBorderDashStyle = false;
		lblNextTermBegins.StylePriority.UseBorders = false;
		lblNextTermBegins.StylePriority.UseFont = false;
		lblNextTermBegins.StylePriority.UseForeColor = false;
		lblNextTermBegins.StylePriority.UseTextAlignment = false;
		lblNextTermBegins.TextAlignment = TextAlignment.BottomCenter;
		lblNextTermBegins.Weight = 0.55863693349796;
		lblNextTermBegins.WordWrap = false;
		xrTableRow2.Cells.AddRange(new XRTableCell[1] { xrTableCell18 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell18.Font = new DXFont("Consolas Mono", 9.75f);
		xrTableCell18.ForeColor = Color.Black;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseForeColor = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "Next Term Begins";
		xrTableCell18.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell18.Weight = 0.55863693349796;
		xrBarCode2.AnchorVertical = VerticalAnchorStyles.Bottom;
		xrBarCode2.AutoModule = true;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.LocationFloat = new PointFloat(115.4167f, 498f);
		xrBarCode2.Name = "xrBarCode2";
		xrBarCode2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode2.ShowText = false;
		xrBarCode2.SizeF = new SizeF(91f, 88f);
		xrBarCode2.StylePriority.UseBorderColor = false;
		xrBarCode2.StylePriority.UseBorders = false;
		xrBarCode2.StylePriority.UseFont = false;
		xrBarCode2.StylePriority.UseForeColor = false;
		xrBarCode2.StylePriority.UsePadding = false;
		xrBarCode2.StylePriority.UseTextAlignment = false;
		qRCodeGenerator.Version = QRCodeVersion.Version1;
		xrBarCode2.Symbology = qRCodeGenerator;
		xrBarCode2.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel21.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel21.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel21.Borders = BorderSide.Bottom;
		xrLabel21.CanGrow = false;
		xrLabel21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryScores1]")
		});
		xrLabel21.Font = new DXFont("Consolas Mono", 9.75f);
		xrLabel21.LocationFloat = new PointFloat(115.4167f, 351.3863f);
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(203.8749f, 22.61371f);
		xrLabel21.StylePriority.UseBorderDashStyle = false;
		xrLabel21.StylePriority.UseBorders = false;
		xrLabel21.StylePriority.UseFont = false;
		xrLabel21.StylePriority.UseForeColor = false;
		xrLabel21.StylePriority.UseTextAlignment = false;
		xrLabel21.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel21.WordWrap = false;
		xrLabel20.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel20.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel20.Borders = BorderSide.Bottom;
		xrLabel20.CanGrow = false;
		xrLabel20.LocationFloat = new PointFloat(193.8333f, 323.3864f);
		xrLabel20.Name = "xrLabel20";
		xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel20.SizeF = new SizeF(124.9584f, 22.61359f);
		xrLabel20.StylePriority.UseBorderDashStyle = false;
		xrLabel20.StylePriority.UseBorders = false;
		xrLabel20.StylePriority.UseFont = false;
		xrLabel20.StylePriority.UseForeColor = false;
		xrLabel20.StylePriority.UseTextAlignment = false;
		xrLabel20.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel20.WordWrap = false;
		xrLabel19.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel19.LocationFloat = new PointFloat(128.3333f, 323.3864f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(65.49995f, 22.61359f);
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Term:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel18.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel18.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel18.Borders = BorderSide.Bottom;
		xrLabel18.CanGrow = false;
		xrLabel18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrLabel18.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel18.LocationFloat = new PointFloat(193.8333f, 295.3864f);
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(124.9584f, 22.61359f);
		xrLabel18.StylePriority.UseBorderDashStyle = false;
		xrLabel18.StylePriority.UseBorders = false;
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseForeColor = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel18.WordWrap = false;
		xrLabel17.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel17.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel17.Borders = BorderSide.Bottom;
		xrLabel17.CanGrow = false;
		xrLabel17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel17.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel17.LocationFloat = new PointFloat(59.99998f, 295.3864f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(68.33336f, 22.61359f);
		xrLabel17.StylePriority.UseBorderDashStyle = false;
		xrLabel17.StylePriority.UseBorders = false;
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseForeColor = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel17.WordWrap = false;
		xrLabel15.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel15.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel15.Borders = BorderSide.Bottom;
		xrLabel15.CanGrow = false;
		xrLabel15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrLabel15.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel15.LocationFloat = new PointFloat(59.99998f, 323.3864f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(68.33336f, 22.61359f);
		xrLabel15.StylePriority.UseBorderDashStyle = false;
		xrLabel15.StylePriority.UseBorders = false;
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseForeColor = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel15.WordWrap = false;
		xrLabel14.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel14.CanGrow = false;
		xrLabel14.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel14.LocationFloat = new PointFloat(128.3334f, 295.3864f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(65.49995f, 22.61359f);
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseForeColor = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.Text = "Stream:";
		xrLabel14.TextAlignment = TextAlignment.BottomLeft;
		xrLabel13.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel13.LocationFloat = new PointFloat(6.541649f, 295.3864f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(53.45833f, 22.61359f);
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseForeColor = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Class:";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		xrLabel9.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel9.CanGrow = false;
		xrLabel9.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel9.LocationFloat = new PointFloat(6.541652f, 323.3864f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(53.45833f, 22.61359f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseForeColor = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "Sex:";
		xrLabel9.TextAlignment = TextAlignment.BottomLeft;
		xrPictureBox2.AnchorVertical = VerticalAnchorStyles.Top;
		xrPictureBox2.Borders = BorderSide.None;
		xrPictureBox2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox2.ImageAlignment = ImageAlignment.MiddleCenter;
		xrPictureBox2.LocationFloat = new PointFloat(64.66666f, 47.88637f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrPictureBox2.SizeF = new SizeF(192.5f, 196.1136f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox2.StylePriority.UseBorderColor = false;
		xrPictureBox2.StylePriority.UseBorders = false;
		xrLabel8.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel8.CanGrow = false;
		xrLabel8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrLabel8.Font = new DXFont("Cascadia Mono", 14f);
		xrLabel8.LocationFloat = new PointFloat(64.66666f, 251.8864f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(192.5f, 24.19695f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseForeColor = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "123456789012";
		xrLabel8.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel8.WordWrap = false;
		xrLabel7.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel7.CanGrow = false;
		xrLabel7.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel7.Font = new DXFont("Cascadia Mono", 14f);
		xrLabel7.LocationFloat = new PointFloat(3.041665f, 5.416689f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(315.75f, 27f);
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseForeColor = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.WordWrap = false;
		xrLabel6.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel6.CanGrow = false;
		xrLabel6.Font = new DXFont("Cascadia Mono", 9.75f);
		xrLabel6.LocationFloat = new PointFloat(6.541649f, 351.3863f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(108.8751f, 22.61371f);
		xrLabel6.StylePriority.UseBorderWidth = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "PLE Results:";
		xrLabel6.TextAlignment = TextAlignment.BottomLeft;
		xrLabel6.WordWrap = false;
		xrLine1.AnchorVertical = VerticalAnchorStyles.Both;
		xrLine1.ForeColor = Color.Gray;
		xrLine1.LineDirection = LineDirection.Vertical;
		xrLine1.LocationFloat = new PointFloat(323.0417f, 5.416679f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(10f, 586.5833f);
		xrLine1.StylePriority.UseForeColor = false;
		studentsSourceDS1.DataSetName = "StudentsSourceDS";
		studentsSourceDS1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterStudentsDS.ClearBeforeFill = true;
		xrShape7.LineWidth = 3;
		xrShape7.LocationFloat = new PointFloat(328.7501f, 136f);
		xrShape7.Name = "xrShape7";
		shapeRectangle.Fillet = 60;
		xrShape7.Shape = shapeRectangle;
		xrShape7.SizeF = new SizeF(390.4999f, 35.00001f);
		xrShape7.Stretch = true;
		base.Bands.AddRange(new Band[3] { TopMargin, BottomMargin, Detail });
		base.ComponentStorage.AddRange(new IComponent[1] { studentsSourceDS1 });
		base.DataAdapter = adapterStudentsDS;
		base.DataMember = "StudentsDS";
		base.DataSource = studentsSourceDS1;
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(98f, 23f, 180f, 23f);
		base.PageHeight = 827;
		base.PageWidth = 1169;
		base.PaperKind = DXPaperKind.A4Rotated;
		base.ShowPreviewMarginLines = false;
		base.SnapGridSize = 1f;
		base.SnapGridStepCount = 2;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "23.2";
		BeforePrint += StudentsDetailsLS_BeforePrint;
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)studentsSourceDS1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
