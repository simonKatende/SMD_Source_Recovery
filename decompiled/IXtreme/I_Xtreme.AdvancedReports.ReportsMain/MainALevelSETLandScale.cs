using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using AlienAge.GradingScales;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.AdvancedReports.ReportsSub;
using I_Xtreme.AdvancedReports.StorageMain;
using I_Xtreme.AdvancedReports.StorageMain.ALevelMainReportTableAdapters;

namespace I_Xtreme.AdvancedReports.ReportsMain;

public class MainALevelSETLandScale : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private Parameter semesters;

	private Parameter classes;

	private CalculatedField TotalPoints;

	private ALevelMainReport aLevelMainReport1;

	private adapterALevelReportMain adapterALevelReportMain;

	private XRSubreport xrSubreport2;

	private Parameter termOfStudy;

	private XRLabel xrLabel4;

	private XRLabel xrLabel8;

	private XRPictureBox xrPictureBox2;

	private XRLabel xrLabel9;

	private XRLabel xrLabel13;

	private XRLabel xrLabel14;

	private XRLabel xrLabel15;

	private XRLabel xrLabel5;

	private XRLabel xrLabel7;

	private XRLabel xrLabel19;

	private XRLabel lblSemester;

	private XRLabel xrLabel10;

	private XRBarCode xrBarCode2;

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

	private XRLabel lblName;

	private XRLine xrLine1;

	private XRLabel xrLabel1;

	public MainALevelSETLandScale()
	{
		InitializeComponent();
		lblSemester.Text = ReportParameters.Semester;
		termOfStudy.Value = ReportParameters.Semester;
	}

	private void xrLabel1_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		string text = lblName.Text;
		((XRLabel)sender).Bookmark += text;
	}

	private void S_5_Report_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSemester.Text = ReportParameters.Semester;
		xrLabel1.BackColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrLabel1.ForeColor = Color.FromArgb((int)ReportColors.ReportForeColor);
		xrLabel1.Text = ReportHeader.HeaderString;
		if (ReportHeaderAlign.HeaderAlignment == "Left" || ReportHeaderAlign.HeaderAlignment == "Center" || ReportHeaderAlign.HeaderAlignment == "Right")
		{
		}
		xrLabel1.Text = ReportHeader.HeaderString;
		tblFeesInfo.Visible = ReportCustomization.ShowFeesBalance;
		lblNextTermBegins.Text = ReportHeader.NextTermBeginsOn.ToString("dd-MMM-yyyy");
		if (!(ALevelGradingScale.GradingSystemInUse == ALevelGradingScale.GradingSystem.OldGradingSystem.ToString()))
		{
		}
	}

	private void MainALevelSET_FillEmptySpace(object sender, BandEventArgs e)
	{
		int num = GraphicsUnitConverter.Convert(e.Band.Height, base.ReportUnit.ToDpi(), ReportUnit.HundredthsOfAnInch.ToDpi());
		if (num > 30)
		{
			Size size = new Size(612, num - 30);
			XRLabel xRLabel = new XRLabel();
			xRLabel.Font = new Font("Tahoma", 13f);
			xRLabel.Text = "School stamp and signature:";
			xRLabel.BackColor = Color.Transparent;
			xRLabel.Size = size;
			xRLabel.Location = new Point(19, 15);
			e.Band.Controls.Add(xRLabel);
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
		QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
		Detail = new DetailBand();
		xrLine1 = new XRLine();
		lblName = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrPictureBox2 = new XRPictureBox();
		xrLabel9 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel19 = new XRLabel();
		lblSemester = new XRLabel();
		xrLabel10 = new XRLabel();
		xrBarCode2 = new XRBarCode();
		tblTermBegins = new XRTable();
		xrTableRow1 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell18 = new XRTableCell();
		tblFeesInfo = new XRTable();
		xrTableRow11 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		xrTableCell39 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		xrTableCell29 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrSubreport2 = new XRSubreport();
		termOfStudy = new Parameter();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		xrLabel1 = new XRLabel();
		bottomMarginBand1 = new BottomMarginBand();
		semesters = new Parameter();
		classes = new Parameter();
		TotalPoints = new CalculatedField();
		aLevelMainReport1 = new ALevelMainReport();
		adapterALevelReportMain = new adapterALevelReportMain();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)aLevelMainReport1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[18]
		{
			xrLine1, lblName, xrLabel4, xrLabel8, xrPictureBox2, xrLabel9, xrLabel13, xrLabel14, xrLabel15, xrLabel5,
			xrLabel7, xrLabel19, lblSemester, xrLabel10, xrBarCode2, tblTermBegins, tblFeesInfo, xrSubreport2
		});
		Detail.HeightF = 641.9305f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrLine1.AnchorVertical = VerticalAnchorStyles.Both;
		xrLine1.BackColor = Color.Transparent;
		xrLine1.ForeColor = Color.Gray;
		xrLine1.LineDirection = LineDirection.Vertical;
		xrLine1.LocationFloat = new PointFloat(329f, 3.999996f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(10f, 587.0001f);
		xrLine1.StylePriority.UseBackColor = false;
		xrLine1.StylePriority.UseForeColor = false;
		lblName.AnchorVertical = VerticalAnchorStyles.Top;
		lblName.AutoWidth = true;
		lblName.BackColor = Color.Transparent;
		lblName.CanGrow = false;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Arial", 14f);
		lblName.LocationFloat = new PointFloat(3.999996f, 3.000005f);
		lblName.Multiline = true;
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblName.SizeF = new SizeF(315.75f, 27f);
		lblName.StylePriority.UseBackColor = false;
		lblName.StylePriority.UseBorderDashStyle = false;
		lblName.StylePriority.UseBorders = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UseForeColor = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel4.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel4.BackColor = Color.Transparent;
		xrLabel4.CanGrow = false;
		xrLabel4.Font = new DXFont("Arial", 10f);
		xrLabel4.LocationFloat = new PointFloat(5.999994f, 321.9999f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(90.99999f, 22.61371f);
		xrLabel4.StylePriority.UseBackColor = false;
		xrLabel4.StylePriority.UseBorderWidth = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseForeColor = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "UCE Results:";
		xrLabel4.TextAlignment = TextAlignment.BottomLeft;
		xrLabel4.WordWrap = false;
		xrLabel8.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel8.BackColor = Color.Transparent;
		xrLabel8.CanGrow = false;
		xrLabel8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentID]")
		});
		xrLabel8.Font = new DXFont("Arial", 14f);
		xrLabel8.LocationFloat = new PointFloat(65.625f, 236f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(192.5f, 22.1136f);
		xrLabel8.StylePriority.UseBackColor = false;
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseForeColor = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "123456789012";
		xrLabel8.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel8.WordWrap = false;
		xrPictureBox2.AnchorVertical = VerticalAnchorStyles.Top;
		xrPictureBox2.BackColor = Color.Transparent;
		xrPictureBox2.Borders = BorderSide.None;
		xrPictureBox2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox2.ImageAlignment = ImageAlignment.MiddleCenter;
		xrPictureBox2.LocationFloat = new PointFloat(65.625f, 35f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrPictureBox2.SizeF = new SizeF(192.5f, 196.1136f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox2.StylePriority.UseBackColor = false;
		xrPictureBox2.StylePriority.UseBorderColor = false;
		xrPictureBox2.StylePriority.UseBorders = false;
		xrLabel9.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel9.BackColor = Color.Transparent;
		xrLabel9.CanGrow = false;
		xrLabel9.Font = new DXFont("Arial", 10f);
		xrLabel9.LocationFloat = new PointFloat(6f, 294f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(49f, 22.61359f);
		xrLabel9.StylePriority.UseBackColor = false;
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseForeColor = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "Sex:";
		xrLabel9.TextAlignment = TextAlignment.BottomLeft;
		xrLabel13.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel13.BackColor = Color.Transparent;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("Arial", 10f);
		xrLabel13.LocationFloat = new PointFloat(6f, 266f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(49f, 22.61359f);
		xrLabel13.StylePriority.UseBackColor = false;
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseForeColor = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Class:";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		xrLabel14.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel14.BackColor = Color.Transparent;
		xrLabel14.CanGrow = false;
		xrLabel14.Font = new DXFont("Arial", 10f);
		xrLabel14.LocationFloat = new PointFloat(135.7917f, 266f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(57.49997f, 22.61359f);
		xrLabel14.StylePriority.UseBackColor = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseForeColor = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.Text = "Stream:";
		xrLabel14.TextAlignment = TextAlignment.BottomLeft;
		xrLabel15.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel15.BackColor = Color.Transparent;
		xrLabel15.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel15.Borders = BorderSide.Bottom;
		xrLabel15.CanGrow = false;
		xrLabel15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrLabel15.Font = new DXFont("Arial", 10f);
		xrLabel15.LocationFloat = new PointFloat(56.50004f, 294f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(79.29166f, 22.61359f);
		xrLabel15.StylePriority.UseBackColor = false;
		xrLabel15.StylePriority.UseBorderDashStyle = false;
		xrLabel15.StylePriority.UseBorders = false;
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseForeColor = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel15.WordWrap = false;
		xrLabel5.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel5.BackColor = Color.Transparent;
		xrLabel5.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel5.Borders = BorderSide.Bottom;
		xrLabel5.CanGrow = false;
		xrLabel5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel5.Font = new DXFont("Arial", 10f);
		xrLabel5.LocationFloat = new PointFloat(56.50001f, 266f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(79.29169f, 22.61359f);
		xrLabel5.StylePriority.UseBackColor = false;
		xrLabel5.StylePriority.UseBorderDashStyle = false;
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseForeColor = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel5.WordWrap = false;
		xrLabel7.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel7.BackColor = Color.Transparent;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = BorderSide.Bottom;
		xrLabel7.CanGrow = false;
		xrLabel7.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrLabel7.Font = new DXFont("Arial", 10f);
		xrLabel7.LocationFloat = new PointFloat(193.2916f, 266f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(124.9584f, 22.61359f);
		xrLabel7.StylePriority.UseBackColor = false;
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseForeColor = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.WordWrap = false;
		xrLabel19.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel19.BackColor = Color.Transparent;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Arial", 10f);
		xrLabel19.LocationFloat = new PointFloat(135.7917f, 294f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(57.49997f, 22.61359f);
		xrLabel19.StylePriority.UseBackColor = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Term:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		lblSemester.AnchorVertical = VerticalAnchorStyles.Top;
		lblSemester.BackColor = Color.Transparent;
		lblSemester.BorderDashStyle = BorderDashStyle.Dash;
		lblSemester.Borders = BorderSide.Bottom;
		lblSemester.CanGrow = false;
		lblSemester.Font = new DXFont("Arial", 10f);
		lblSemester.LocationFloat = new PointFloat(193.2916f, 294f);
		lblSemester.Name = "lblSemester";
		lblSemester.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSemester.SizeF = new SizeF(124.9584f, 22.61359f);
		lblSemester.StylePriority.UseBackColor = false;
		lblSemester.StylePriority.UseBorderDashStyle = false;
		lblSemester.StylePriority.UseBorders = false;
		lblSemester.StylePriority.UseFont = false;
		lblSemester.StylePriority.UseForeColor = false;
		lblSemester.StylePriority.UseTextAlignment = false;
		lblSemester.TextAlignment = TextAlignment.MiddleCenter;
		lblSemester.WordWrap = false;
		xrLabel10.AnchorVertical = VerticalAnchorStyles.Top;
		xrLabel10.BackColor = Color.Transparent;
		xrLabel10.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel10.Borders = BorderSide.Bottom;
		xrLabel10.CanGrow = false;
		xrLabel10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryScores1]")
		});
		xrLabel10.Font = new DXFont("Arial", 10f);
		xrLabel10.LocationFloat = new PointFloat(102f, 321.9999f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(216.75f, 22.61371f);
		xrLabel10.StylePriority.UseBackColor = false;
		xrLabel10.StylePriority.UseBorderDashStyle = false;
		xrLabel10.StylePriority.UseBorders = false;
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseForeColor = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel10.WordWrap = false;
		xrBarCode2.AnchorVertical = VerticalAnchorStyles.Bottom;
		xrBarCode2.AutoModule = true;
		xrBarCode2.BackColor = Color.Transparent;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.LocationFloat = new PointFloat(116.375f, 526.5441f);
		xrBarCode2.Name = "xrBarCode2";
		xrBarCode2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode2.ShowText = false;
		xrBarCode2.SizeF = new SizeF(91f, 88f);
		xrBarCode2.StylePriority.UseBackColor = false;
		xrBarCode2.StylePriority.UseBorderColor = false;
		xrBarCode2.StylePriority.UseBorders = false;
		xrBarCode2.StylePriority.UseFont = false;
		xrBarCode2.StylePriority.UseForeColor = false;
		xrBarCode2.StylePriority.UsePadding = false;
		xrBarCode2.StylePriority.UseTextAlignment = false;
		qRCodeGenerator.Version = QRCodeVersion.Version1;
		xrBarCode2.Symbology = qRCodeGenerator;
		xrBarCode2.TextAlignment = TextAlignment.MiddleCenter;
		tblTermBegins.BackColor = Color.Transparent;
		tblTermBegins.Font = new DXFont("Arial", 10f);
		tblTermBegins.LocationFloat = new PointFloat(86.25f, 355.1969f);
		tblTermBegins.Name = "tblTermBegins";
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow2 });
		tblTermBegins.SizeF = new SizeF(151.25f, 49.41669f);
		tblTermBegins.StylePriority.UseBackColor = false;
		tblTermBegins.StylePriority.UseFont = false;
		xrTableRow1.Cells.AddRange(new XRTableCell[1] { lblNextTermBegins });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		lblNextTermBegins.BorderDashStyle = BorderDashStyle.Dash;
		lblNextTermBegins.Borders = BorderSide.Bottom;
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
		xrTableRow2.Cells.AddRange(new XRTableCell[1] { xrTableCell18 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell18.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell18.ForeColor = Color.Black;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseForeColor = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "Next Term Begins";
		xrTableCell18.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell18.Weight = 0.55863693349796;
		tblFeesInfo.BackColor = Color.Transparent;
		tblFeesInfo.Font = new DXFont("Arial", 11f);
		tblFeesInfo.LocationFloat = new PointFloat(3.875f, 412.6136f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow11, xrTableRow9 });
		tblFeesInfo.SizeF = new SizeF(316f, 48f);
		tblFeesInfo.StylePriority.UseBackColor = false;
		tblFeesInfo.StylePriority.UseFont = false;
		xrTableRow11.Cells.AddRange(new XRTableCell[2] { lblFeesBalance, xrTableCell39 });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		lblFeesBalance.BorderDashStyle = BorderDashStyle.Dash;
		lblFeesBalance.Borders = BorderSide.Bottom;
		lblFeesBalance.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[cashOnAccount]")
		});
		lblFeesBalance.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
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
		xrTableCell39.BorderDashStyle = BorderDashStyle.Dash;
		xrTableCell39.Borders = BorderSide.Bottom;
		xrTableCell39.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
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
		xrTableCell29.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
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
		xrTableCell33.BorderDashStyle = BorderDashStyle.Dash;
		xrTableCell33.Borders = BorderSide.Right;
		xrTableCell33.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
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
		xrSubreport2.LocationFloat = new PointFloat(343f, 2.000014f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("StudentNo", null, "ALevelReportMain.StudentNumber"));
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("classId", null, "ALevelReportMain.ClassId"));
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("cashOnAccount", null, "ALevelReportMain.cashOnAccount"));
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("term", termOfStudy));
		xrSubreport2.ReportSource = new ALevelSubLandScape();
		xrSubreport2.SizeF = new SizeF(777.9999f, 513f);
		termOfStudy.Description = "Term of study";
		termOfStudy.Name = "termOfStudy";
		termOfStudy.Visible = false;
		Title.BackColor = Color.White;
		Title.BorderColor = SystemColors.ControlText;
		Title.Borders = BorderSide.None;
		Title.BorderWidth = 1f;
		Title.Font = new DXFont("Times New Roman", 24f);
		Title.ForeColor = Color.Black;
		Title.Name = "Title";
		FieldCaption.BackColor = Color.White;
		FieldCaption.BorderColor = SystemColors.ControlText;
		FieldCaption.Borders = BorderSide.None;
		FieldCaption.BorderWidth = 1f;
		FieldCaption.Font = new DXFont("Times New Roman", 10f, DXFontStyle.Bold);
		FieldCaption.ForeColor = Color.Black;
		FieldCaption.Name = "FieldCaption";
		PageInfo.BackColor = Color.White;
		PageInfo.BorderColor = SystemColors.ControlText;
		PageInfo.Borders = BorderSide.None;
		PageInfo.BorderWidth = 1f;
		PageInfo.Font = new DXFont("Times New Roman", 8f);
		PageInfo.ForeColor = Color.Black;
		PageInfo.Name = "PageInfo";
		DataField.BackColor = Color.White;
		DataField.BorderColor = SystemColors.ControlText;
		DataField.Borders = BorderSide.None;
		DataField.BorderWidth = 1f;
		DataField.Font = new DXFont("Times New Roman", 8f);
		DataField.ForeColor = SystemColors.ControlText;
		DataField.Name = "DataField";
		DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		topMarginBand1.Controls.AddRange(new XRControl[1] { xrLabel1 });
		topMarginBand1.HeightF = 180f;
		topMarginBand1.Name = "topMarginBand1";
		xrLabel1.BackColor = Color.Transparent;
		xrLabel1.CanGrow = false;
		xrLabel1.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel1.ForeColor = Color.Black;
		xrLabel1.LocationFloat = new PointFloat(3.999996f, 153f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(1117f, 22.99998f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel13";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.WordWrap = false;
		bottomMarginBand1.HeightF = 23f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semesters.Description = "Semester";
		semesters.Name = "semesters";
		classes.Description = "Class";
		classes.Name = "classes";
		TotalPoints.DataMember = "ALevelReport_With_Picture";
		TotalPoints.FieldType = FieldType.Double;
		TotalPoints.Name = "TotalPoints";
		aLevelMainReport1.DataSetName = "ALevelMainReport";
		aLevelMainReport1.EnforceConstraints = false;
		aLevelMainReport1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterALevelReportMain.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		Bookmark = "Students in stream";
		base.CalculatedFields.AddRange(new CalculatedField[1] { TotalPoints });
		base.ComponentStorage.AddRange(new IComponent[1] { aLevelMainReport1 });
		base.DataAdapter = adapterALevelReportMain;
		base.DataMember = "ALevelReportMain";
		base.DataSource = aLevelMainReport1;
		base.Margins = new DXMargins(23f, 23f, 180f, 23f);
		base.PageHeight = 827;
		base.PageWidth = 1169;
		base.PaperKind = DXPaperKind.A4Rotated;
		base.Parameters.AddRange(new Parameter[1] { termOfStudy });
		base.ReportPrintOptions.PrintOnEmptyDataSource = false;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "21.2";
		FillEmptySpace += MainALevelSET_FillEmptySpace;
		BeforePrint += S_5_Report_BeforePrint;
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)aLevelMainReport1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
