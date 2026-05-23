using System;
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
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.AdvancedReports.ReportsSub;
using I_Xtreme.AdvancedReports.StorageMain;
using I_Xtreme.AdvancedReports.StorageMain.PrimaryMainReportTableAdapters;

namespace I_Xtreme.AdvancedReports.ReportsMain;

public class MainPrimary : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private Parameter semester;

	private Parameter studentClass;

	private GroupFooterBand GroupFooter1;

	private XRSubreport xrSubreport1;

	private XRSubreport xrSubreport2;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell28;

	private XRTableCell cBOT;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTable xrTable4;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell4;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell10;

	private PageFooterBand pageFooterBand1;

	private XRTable xrTable6;

	private XRTableRow xrTableRow20;

	private XRTableCell xrTableCell12;

	private XRPictureBox xrPictureBox2;

	private XRTableCell xrTableCell21;

	private GroupFooterBand footerGradingScale;

	private XRLabel lblPromoStatus;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell17;

	private XRSubreport xrSubreport3;

	private GroupFooterBand footerComment1;

	private GroupFooterBand footerComment2;

	private GroupFooterBand footerFeesInfo;

	private GroupFooterBand footerPromotion;

	private XRTableCell colClassPosition;

	private XRTableCell xrTableCell6;

	private XRTableCell colStreamPosition;

	private XRTableCell colClass1;

	private XRTableCell colClass2;

	private XRTableCell colStream1;

	private XRTableCell colStream2;

	private GroupHeaderBand GroupHeader1;

	private GroupFooterBand footerCommentHeader;

	private XRLabel xrLabel21;

	private XRSubreport xrSubreport4;

	private PrimaryMainReport primaryMainReport1;

	private adapterPrimaryMainReport adapterPrimaryMainReport;

	private GroupFooterBand footerOtherSubjects;

	private XRLine xrLine1;

	private XRShape xrShape5;

	private XRLabel xrLabel6;

	private XRLabel lblClassteacherComment;

	private XRLabel xrLabel17;

	private XRShape xrShape4;

	private XRShape xrShape6;

	private XRLabel xrLabel9;

	private XRLabel xrLabel18;

	private XRLabel xrLabel22;

	private XRShape xrShape3;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell41;

	private XRTableRow xrTableRow2;

	private XRTableCell lblNextTermBegins;

	private XRTableCell lblNextTermEndsOn;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell1;

	private XRTableRow xrTableRow15;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRBarCode xrBarCode2;

	private XRShape xrShape7;

	private XRLabel xrLabel13;

	private XRPictureBox xrPictureBox1;

	private XRTable xrTable2;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell63;

	private XRTableCell lblNumberHeader;

	private XRTableCell xrTableCell64;

	private XRTableRow xrTableRow9;

	private XRTableCell lblName;

	private XRTableCell lblStudentNumber;

	private XRTableCell xrTableCell65;

	private XRTable xrTable1;

	private XRTableRow xrTableRow12;

	private XRTableCell xrTableCell57;

	private XRTableCell xrTableCell58;

	private XRTableCell xrTableCell59;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell60;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell62;

	private XRTable xrTable5;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell54;

	private XRTableRow xrTableRow11;

	private XRTableCell lblSemester;

	public MainPrimary()
	{
		InitializeComponent();
		xrLabel17.Text = ReportCustomization.Comment1Label;
		xrLabel22.Text = ReportCustomization.Comment2Label;
	}

	private void OLevel_Report_LowerAll_BeforePrint(object sender, CancelEventArgs e)
	{
		if (ReportHeaderAlign.HeaderAlignment == "Left")
		{
			SchoolHeader reportSource = new SchoolHeader();
			xrSubreport1.ReportSource = reportSource;
		}
		else if (ReportHeaderAlign.HeaderAlignment == "Center")
		{
			SchoolHeader_Center reportSource2 = new SchoolHeader_Center();
			xrSubreport1.ReportSource = reportSource2;
		}
		else if (ReportHeaderAlign.HeaderAlignment == "Right")
		{
			SchoolHeader_Right reportSource3 = new SchoolHeader_Right();
			xrSubreport1.ReportSource = reportSource3;
		}
		xrSubreport1.Visible = ReportCustomization.ShowHeader;
		xrLabel13.Text = ReportHeader.HeaderString;
		footerComment1.Visible = ReportCustomization.Comment1;
		footerComment2.Visible = ReportCustomization.Comment2;
		footerPromotion.Visible = ReportCustomization.ShowOLevelPromo;
		tblFeesInfo.Visible = ReportCustomization.ShowFeesBalance;
		lblNextTermBegins.Text = ReportHeader.NextTermBeginsOn.ToString("dd-MMM-yyyy");
		lblNextTermEndsOn.Text = ReportHeader.NextTermEndsOn.ToString("dd-MMM-yyyy");
		if (!Convert.ToBoolean(ReportCustomization.ShowPositionInClass))
		{
			colClass1.ExpressionBindings.Clear();
			colClass2.ExpressionBindings.Clear();
		}
		if (!Convert.ToBoolean(ReportCustomization.ShowPositionInStream))
		{
			colStream1.ExpressionBindings.Clear();
			colStream2.ExpressionBindings.Clear();
		}
	}

	private void xrLabel1_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		string text = lblName.Text;
		((XRLabel)sender).Bookmark += text;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainPrimary));
		ShapeRectangle shape = new ShapeRectangle();
		ShapeLine shape2 = new ShapeLine();
		ShapeRectangle shape3 = new ShapeRectangle();
		ShapeLine shape4 = new ShapeLine();
		EAN13Generator symbology = new EAN13Generator();
		ShapeRectangle shapeRectangle = new ShapeRectangle();
		Detail = new DetailBand();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell28 = new XRTableCell();
		cBOT = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrSubreport3 = new XRSubreport();
		xrSubreport4 = new XRSubreport();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		xrSubreport1 = new XRSubreport();
		xrSubreport2 = new XRSubreport();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		semester = new Parameter();
		studentClass = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrTable4 = new XRTable();
		xrTableRow7 = new XRTableRow();
		colClassPosition = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		xrTableCell6 = new XRTableCell();
		colStreamPosition = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		colClass1 = new XRTableCell();
		colClass2 = new XRTableCell();
		colStream1 = new XRTableCell();
		colStream2 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		lblPromoStatus = new XRLabel();
		pageFooterBand1 = new PageFooterBand();
		xrLine1 = new XRLine();
		xrPictureBox2 = new XRPictureBox();
		xrTable6 = new XRTable();
		xrTableRow20 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		footerGradingScale = new GroupFooterBand();
		footerComment1 = new GroupFooterBand();
		footerComment2 = new GroupFooterBand();
		footerFeesInfo = new GroupFooterBand();
		footerPromotion = new GroupFooterBand();
		GroupHeader1 = new GroupHeaderBand();
		footerCommentHeader = new GroupFooterBand();
		xrLabel21 = new XRLabel();
		primaryMainReport1 = new PrimaryMainReport();
		adapterPrimaryMainReport = new adapterPrimaryMainReport();
		footerOtherSubjects = new GroupFooterBand();
		xrShape4 = new XRShape();
		xrShape5 = new XRShape();
		xrLabel6 = new XRLabel();
		lblClassteacherComment = new XRLabel();
		xrLabel17 = new XRLabel();
		xrShape3 = new XRShape();
		xrShape6 = new XRShape();
		xrLabel9 = new XRLabel();
		xrLabel18 = new XRLabel();
		xrLabel22 = new XRLabel();
		tblTermBegins = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell5 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		lblNextTermEndsOn = new XRTableCell();
		tblFeesInfo = new XRTable();
		xrTableRow10 = new XRTableRow();
		xrTableCell7 = new XRTableCell();
		xrTableCell1 = new XRTableCell();
		xrTableRow15 = new XRTableRow();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrBarCode2 = new XRBarCode();
		xrShape7 = new XRShape();
		xrLabel13 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		xrTable2 = new XRTable();
		xrTableRow8 = new XRTableRow();
		xrTableCell63 = new XRTableCell();
		lblNumberHeader = new XRTableCell();
		xrTableCell64 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		lblName = new XRTableCell();
		lblStudentNumber = new XRTableCell();
		xrTableCell65 = new XRTableCell();
		xrTable1 = new XRTable();
		xrTableRow12 = new XRTableRow();
		xrTableCell57 = new XRTableCell();
		xrTableCell58 = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTableCell60 = new XRTableCell();
		xrTableCell61 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		xrTable5 = new XRTable();
		xrTableRow14 = new XRTableRow();
		xrTableCell54 = new XRTableCell();
		xrTableRow11 = new XRTableRow();
		lblSemester = new XRTableCell();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)xrTable6).BeginInit();
		((ISupportInitialize)primaryMainReport1).BeginInit();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[2] { xrTable3, xrSubreport3 });
		Detail.HeightF = 61.66888f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.SortFields.AddRange(new GroupField[1]
		{
			new GroupField("SubjectId", XRColumnSortOrder.Ascending)
		});
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrTable3.BorderColor = Color.Black;
		xrTable3.Borders = BorderSide.Bottom;
		xrTable3.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable3.ForeColor = Color.Maroon;
		xrTable3.LocationFloat = new PointFloat(0.9999699f, 32f);
		xrTable3.Name = "xrTable3";
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow4 });
		xrTable3.SizeF = new SizeF(780f, 25f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseForeColor = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow4.Cells.AddRange(new XRTableCell[4] { xrTableCell28, cBOT, xrTableCell31, xrTableCell32 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell28.Borders = BorderSide.Bottom;
		xrTableCell28.Font = new DXFont("Tahoma", 10f);
		xrTableCell28.ForeColor = Color.Black;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UseForeColor = false;
		xrTableCell28.StylePriority.UsePadding = false;
		xrTableCell28.Text = "TOTAL MARKS:";
		xrTableCell28.Weight = 0.435400092707217;
		cBOT.Borders = BorderSide.Bottom;
		cBOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryMainDS.TotalMark]")
		});
		cBOT.Font = new DXFont("Tahoma", 10f);
		cBOT.ForeColor = Color.Black;
		cBOT.Name = "cBOT";
		cBOT.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
		cBOT.StylePriority.UseBorders = false;
		cBOT.StylePriority.UseFont = false;
		cBOT.StylePriority.UseForeColor = false;
		cBOT.StylePriority.UsePadding = false;
		cBOT.StylePriority.UseTextAlignment = false;
		cBOT.TextAlignment = TextAlignment.MiddleCenter;
		cBOT.Weight = 0.43540009338592;
		xrTableCell31.Borders = BorderSide.Bottom;
		xrTableCell31.Font = new DXFont("Tahoma", 10f);
		xrTableCell31.ForeColor = Color.Black;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(5, 0, 0, 0, 100f);
		xrTableCell31.StylePriority.UseBorders = false;
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UseForeColor = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.Text = "AVERAGE MARKS:";
		xrTableCell31.Weight = 0.435400110735519;
		xrTableCell32.Borders = BorderSide.Bottom;
		xrTableCell32.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryMainDS.AvMark]")
		});
		xrTableCell32.Font = new DXFont("Tahoma", 9f);
		xrTableCell32.ForeColor = Color.Black;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.StylePriority.UseBorders = false;
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.StylePriority.UseForeColor = false;
		xrTableCell32.StylePriority.UseTextAlignment = false;
		xrTableCell32.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell32.Weight = 0.435400097181576;
		xrSubreport3.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport3.Name = "xrSubreport3";
		xrSubreport3.ParameterBindings.Add(new ParameterBinding("StudentNo", null, "PrimaryMainDS.StudentNumber"));
		xrSubreport3.ParameterBindings.Add(new ParameterBinding("term", null, "PrimaryMainDS.SemesterId"));
		xrSubreport3.ParameterBindings.Add(new ParameterBinding("classID", null, "PrimaryMainDS.ClassId"));
		xrSubreport3.ReportSource = new PrimaryA();
		xrSubreport3.SizeF = new SizeF(780f, 30f);
		xrSubreport4.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport4.Name = "xrSubreport4";
		xrSubreport4.ParameterBindings.Add(new ParameterBinding("StudentNo", null, "PrimaryMainDS.StudentNumber"));
		xrSubreport4.ParameterBindings.Add(new ParameterBinding("term", null, "PrimaryMainDS.SemesterId"));
		xrSubreport4.ParameterBindings.Add(new ParameterBinding("classID", null, "PrimaryMainDS.ClassId"));
		xrSubreport4.ReportSource = new PrimaryNA();
		xrSubreport4.SizeF = new SizeF(780f, 30f);
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
		xrSubreport1.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.SizeF = new SizeF(780f, 90f);
		xrSubreport2.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ReportSource = new OLevel_Report_Footer();
		xrSubreport2.SizeF = new SizeF(780f, 77f);
		topMarginBand1.HeightF = 24f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 20f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semester.Description = "Semester:";
		semester.Name = "semester";
		studentClass.Description = "Student Class:";
		studentClass.Name = "studentClass";
		GroupFooter1.Controls.AddRange(new XRControl[1] { xrTable4 });
		GroupFooter1.HeightF = 85.83331f;
		GroupFooter1.KeepTogether = true;
		GroupFooter1.Level = 1;
		GroupFooter1.Name = "GroupFooter1";
		GroupFooter1.RepeatEveryPage = true;
		GroupFooter1.StylePriority.UseTextAlignment = false;
		GroupFooter1.TextAlignment = TextAlignment.TopCenter;
		xrTable4.BorderColor = Color.Black;
		xrTable4.Borders = BorderSide.All;
		xrTable4.Font = new DXFont("Tahoma", 9f);
		xrTable4.LocationFloat = new PointFloat(0f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Rows.AddRange(new XRTableRow[3] { xrTableRow7, xrTableRow5, xrTableRow6 });
		xrTable4.SizeF = new SizeF(780f, 82.5f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow7.Cells.AddRange(new XRTableCell[2] { colClassPosition, xrTableCell17 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		colClassPosition.BackColor = Color.Gainsboro;
		colClassPosition.BorderColor = Color.Black;
		colClassPosition.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		colClassPosition.ForeColor = Color.Black;
		colClassPosition.Name = "colClassPosition";
		colClassPosition.StylePriority.UseBackColor = false;
		colClassPosition.StylePriority.UseBorderColor = false;
		colClassPosition.StylePriority.UseFont = false;
		colClassPosition.StylePriority.UseForeColor = false;
		colClassPosition.Text = "Position";
		colClassPosition.Weight = 3.00000000173306;
		xrTableCell17.BackColor = Color.Gainsboro;
		xrTableCell17.BorderColor = Color.Black;
		xrTableCell17.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell17.ForeColor = Color.Black;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseBackColor = false;
		xrTableCell17.StylePriority.UseBorderColor = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseForeColor = false;
		xrTableCell17.Text = "General  Assessment";
		xrTableCell17.Weight = 2.99999999826694;
		xrTableRow5.Cells.AddRange(new XRTableCell[4] { xrTableCell6, colStreamPosition, xrTableCell3, xrTableCell4 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell6.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell6.ForeColor = Color.Black;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseForeColor = false;
		xrTableCell6.Text = "Class";
		xrTableCell6.Weight = 1.12499987501708;
		colStreamPosition.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		colStreamPosition.ForeColor = Color.Black;
		colStreamPosition.Name = "colStreamPosition";
		colStreamPosition.StylePriority.UseFont = false;
		colStreamPosition.StylePriority.UseForeColor = false;
		colStreamPosition.Text = "Stream";
		colStreamPosition.Weight = 1.12500013911148;
		xrTableCell3.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell3.ForeColor = Color.Black;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseForeColor = false;
		xrTableCell3.Text = "Aggregates";
		xrTableCell3.Weight = 1.1249999293575;
		xrTableCell4.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell4.ForeColor = Color.Black;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UseForeColor = false;
		xrTableCell4.Text = "Division";
		xrTableCell4.Weight = 1.12499969134641;
		xrTableRow6.Cells.AddRange(new XRTableCell[6] { colClass1, colClass2, colStream1, colStream2, xrTableCell9, xrTableCell10 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		colClass1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Position]")
		});
		colClass1.ForeColor = Color.Maroon;
		colClass1.Name = "colClass1";
		colClass1.StylePriority.UseForeColor = false;
		colClass1.Weight = 0.559615322358004;
		colClass2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OutOf]")
		});
		colClass2.ForeColor = Color.Maroon;
		colClass2.Name = "colClass2";
		colClass2.StylePriority.UseForeColor = false;
		colClass2.Weight = 0.565384684706274;
		colStream1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PositionInStream]")
		});
		colStream1.ForeColor = Color.Maroon;
		colStream1.Name = "colStream1";
		colStream1.StylePriority.UseForeColor = false;
		colStream1.Weight = 0.559615322358004;
		colStream2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentsInStream]")
		});
		colStream2.ForeColor = Color.Maroon;
		colStream2.Name = "colStream2";
		colStream2.StylePriority.UseForeColor = false;
		colStream2.Weight = 0.565384332580401;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[BestinEight]")
		});
		xrTableCell9.ForeColor = Color.Maroon;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseForeColor = false;
		xrTableCell9.Weight = 1.1249999293575;
		xrTableCell10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Div]")
		});
		xrTableCell10.ForeColor = Color.Maroon;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseForeColor = false;
		xrTableCell10.Weight = 1.12500004347228;
		lblPromoStatus.BorderColor = Color.Black;
		lblPromoStatus.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[promoStatus]")
		});
		lblPromoStatus.Font = new DXFont("Tahoma", 11f, DXFontStyle.Bold);
		lblPromoStatus.ForeColor = Color.Black;
		lblPromoStatus.LocationFloat = new PointFloat(0f, 0f);
		lblPromoStatus.Name = "lblPromoStatus";
		lblPromoStatus.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblPromoStatus.SizeF = new SizeF(780f, 22f);
		lblPromoStatus.StylePriority.UseBorderColor = false;
		lblPromoStatus.StylePriority.UseFont = false;
		lblPromoStatus.StylePriority.UseForeColor = false;
		lblPromoStatus.StylePriority.UseTextAlignment = false;
		lblPromoStatus.TextAlignment = TextAlignment.MiddleCenter;
		pageFooterBand1.Controls.AddRange(new XRControl[3] { xrLine1, xrPictureBox2, xrTable6 });
		pageFooterBand1.HeightF = 35.00001f;
		pageFooterBand1.Name = "pageFooterBand1";
		pageFooterBand1.Visible = false;
		xrLine1.ForeColor = Color.Black;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(780f, 2f);
		xrLine1.StylePriority.UseForeColor = false;
		xrPictureBox2.ImageSource = new ImageSource("img", componentResourceManager.GetString("xrPictureBox2.ImageSource"));
		xrPictureBox2.LocationFloat = new PointFloat(640.42f, 5f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.SizeF = new SizeF(139.58f, 30.00001f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		xrTable6.BorderColor = Color.CadetBlue;
		xrTable6.Borders = BorderSide.None;
		xrTable6.Font = new DXFont("Tahoma", 7f);
		xrTable6.LocationFloat = new PointFloat(0.9999699f, 5f);
		xrTable6.Name = "xrTable6";
		xrTable6.Rows.AddRange(new XRTableRow[1] { xrTableRow20 });
		xrTable6.SizeF = new SizeF(639.4199f, 30f);
		xrTable6.StylePriority.UseBorderColor = false;
		xrTable6.StylePriority.UseBorders = false;
		xrTable6.StylePriority.UseFont = false;
		xrTable6.StylePriority.UseTextAlignment = false;
		xrTable6.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow20.Cells.AddRange(new XRTableCell[2] { xrTableCell12, xrTableCell21 });
		xrTableRow20.Name = "xrTableRow20";
		xrTableRow20.Weight = 1.0;
		xrTableCell12.Borders = BorderSide.None;
		xrTableCell12.ForeColor = Color.DodgerBlue;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Padding = new PaddingInfo(2, 2, 2, 2, 100f);
		xrTableCell12.StylePriority.UseBorders = false;
		xrTableCell12.StylePriority.UseForeColor = false;
		xrTableCell12.StylePriority.UsePadding = false;
		xrTableCell12.Text = "Software developed by:";
		xrTableCell12.Weight = 0.540692314734826;
		xrTableCell21.Borders = BorderSide.None;
		xrTableCell21.ForeColor = Color.DodgerBlue;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Padding = new PaddingInfo(2, 2, 2, 2, 100f);
		xrTableCell21.StylePriority.UseBorders = false;
		xrTableCell21.StylePriority.UseForeColor = false;
		xrTableCell21.StylePriority.UsePadding = false;
		xrTableCell21.Text = "http://www.alienage.info | 0392000153, 0752162444 | Email: alienageltd@gmail.com";
		xrTableCell21.Weight = 1.60419808100267;
		footerGradingScale.Controls.AddRange(new XRControl[1] { xrSubreport2 });
		footerGradingScale.HeightF = 77f;
		footerGradingScale.KeepTogether = true;
		footerGradingScale.Level = 7;
		footerGradingScale.Name = "footerGradingScale";
		footerGradingScale.PrintAtBottom = true;
		footerGradingScale.RepeatEveryPage = true;
		footerComment1.Controls.AddRange(new XRControl[5] { xrShape5, xrLabel6, lblClassteacherComment, xrLabel17, xrShape4 });
		footerComment1.HeightF = 69f;
		footerComment1.KeepTogether = true;
		footerComment1.Level = 4;
		footerComment1.Name = "footerComment1";
		footerComment1.PrintAtBottom = true;
		footerComment1.RepeatEveryPage = true;
		footerComment2.Controls.AddRange(new XRControl[5] { xrShape6, xrLabel9, xrLabel18, xrLabel22, xrShape3 });
		footerComment2.HeightF = 69f;
		footerComment2.KeepTogether = true;
		footerComment2.Level = 5;
		footerComment2.Name = "footerComment2";
		footerComment2.PrintAtBottom = true;
		footerComment2.RepeatEveryPage = true;
		footerFeesInfo.Controls.AddRange(new XRControl[3] { tblTermBegins, tblFeesInfo, xrBarCode2 });
		footerFeesInfo.HeightF = 61.72223f;
		footerFeesInfo.KeepTogether = true;
		footerFeesInfo.Level = 6;
		footerFeesInfo.Name = "footerFeesInfo";
		footerFeesInfo.PrintAtBottom = true;
		footerFeesInfo.RepeatEveryPage = true;
		footerPromotion.Controls.AddRange(new XRControl[1] { lblPromoStatus });
		footerPromotion.HeightF = 24f;
		footerPromotion.KeepTogether = true;
		footerPromotion.Level = 2;
		footerPromotion.Name = "footerPromotion";
		footerPromotion.RepeatEveryPage = true;
		GroupHeader1.Controls.AddRange(new XRControl[7] { xrLabel13, xrPictureBox1, xrTable2, xrTable1, xrTable5, xrSubreport1, xrShape7 });
		GroupHeader1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		GroupHeader1.HeightF = 265.1717f;
		GroupHeader1.Name = "GroupHeader1";
		GroupHeader1.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
		footerCommentHeader.Controls.AddRange(new XRControl[1] { xrLabel21 });
		footerCommentHeader.HeightF = 23f;
		footerCommentHeader.KeepTogether = true;
		footerCommentHeader.Level = 3;
		footerCommentHeader.Name = "footerCommentHeader";
		footerCommentHeader.PrintAtBottom = true;
		footerCommentHeader.RepeatEveryPage = true;
		xrLabel21.Font = new DXFont("Tahoma", 9.75f);
		xrLabel21.LocationFloat = new PointFloat(0f, 0f);
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(295.2999f, 23f);
		xrLabel21.StylePriority.UseFont = false;
		xrLabel21.StylePriority.UseTextAlignment = false;
		xrLabel21.Text = "Comments/Remarks";
		xrLabel21.TextAlignment = TextAlignment.MiddleLeft;
		primaryMainReport1.DataSetName = "PrimaryMainReport";
		primaryMainReport1.EnforceConstraints = false;
		primaryMainReport1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterPrimaryMainReport.ClearBeforeFill = true;
		footerOtherSubjects.Controls.AddRange(new XRControl[1] { xrSubreport4 });
		footerOtherSubjects.HeightF = 34.02778f;
		footerOtherSubjects.Name = "footerOtherSubjects";
		xrShape4.LocationFloat = new PointFloat(3.041665f, 2.525647f);
		xrShape4.Name = "xrShape4";
		xrShape4.Shape = shape;
		xrShape4.SizeF = new SizeF(774.9998f, 64f);
		xrShape5.LocationFloat = new PointFloat(618.0417f, 2.525647f);
		xrShape5.Name = "xrShape5";
		xrShape5.Shape = shape2;
		xrShape5.SizeF = new SizeF(2f, 64f);
		xrLabel6.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel6.LocationFloat = new PointFloat(623.0417f, 4.525638f);
		xrLabel6.Multiline = true;
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(100f, 23f);
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Signature";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		lblClassteacherComment.AutoWidth = true;
		lblClassteacherComment.BorderColor = Color.Black;
		lblClassteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblClassteacherComment.Borders = BorderSide.None;
		lblClassteacherComment.CanGrow = false;
		lblClassteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassTeacherComment]")
		});
		lblClassteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblClassteacherComment.ForeColor = Color.Black;
		lblClassteacherComment.LocationFloat = new PointFloat(9.041672f, 29.02565f);
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
		xrLabel17.BackColor = Color.Transparent;
		xrLabel17.BorderColor = Color.Black;
		xrLabel17.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.CanGrow = false;
		xrLabel17.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrLabel17.ForeColor = Color.Black;
		xrLabel17.LocationFloat = new PointFloat(9.041684f, 5.525627f);
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
		xrLabel17.Text = "Classteacher's Remarks:";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.WordWrap = false;
		xrShape3.LocationFloat = new PointFloat(4.083332f, 1.932716f);
		xrShape3.Name = "xrShape3";
		xrShape3.Shape = shape3;
		xrShape3.SizeF = new SizeF(774.9998f, 64f);
		xrShape6.LocationFloat = new PointFloat(619.0833f, 1.932716f);
		xrShape6.Name = "xrShape6";
		xrShape6.Shape = shape4;
		xrShape6.SizeF = new SizeF(2f, 64f);
		xrLabel9.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel9.LocationFloat = new PointFloat(624.0833f, 3.932706f);
		xrLabel9.Multiline = true;
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(100f, 23f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "Signature";
		xrLabel9.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel18.AutoWidth = true;
		xrLabel18.BorderColor = Color.Black;
		xrLabel18.BorderDashStyle = BorderDashStyle.Solid;
		xrLabel18.Borders = BorderSide.None;
		xrLabel18.CanGrow = false;
		xrLabel18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadTeacherComment]")
		});
		xrLabel18.Font = new DXFont("Cascadia Mono", 11f);
		xrLabel18.ForeColor = Color.Black;
		xrLabel18.LocationFloat = new PointFloat(10.08334f, 28.43272f);
		xrLabel18.Multiline = true;
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(603f, 23f);
		xrLabel18.StylePriority.UseBorderColor = false;
		xrLabel18.StylePriority.UseBorderDashStyle = false;
		xrLabel18.StylePriority.UseBorders = false;
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseForeColor = false;
		xrLabel18.StylePriority.UsePadding = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel22.BackColor = Color.Transparent;
		xrLabel22.BorderColor = Color.Black;
		xrLabel22.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel22.Borders = BorderSide.None;
		xrLabel22.CanGrow = false;
		xrLabel22.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrLabel22.ForeColor = Color.Black;
		xrLabel22.LocationFloat = new PointFloat(10.08335f, 4.932696f);
		xrLabel22.Name = "xrLabel22";
		xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel22.SizeF = new SizeF(451.0417f, 23f);
		xrLabel22.StylePriority.UseBackColor = false;
		xrLabel22.StylePriority.UseBorderColor = false;
		xrLabel22.StylePriority.UseBorderDashStyle = false;
		xrLabel22.StylePriority.UseBorders = false;
		xrLabel22.StylePriority.UseFont = false;
		xrLabel22.StylePriority.UseForeColor = false;
		xrLabel22.StylePriority.UseTextAlignment = false;
		xrLabel22.Text = "Headteacher's Remarks:";
		xrLabel22.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel22.WordWrap = false;
		tblTermBegins.Borders = BorderSide.All;
		tblTermBegins.LocationFloat = new PointFloat(4.5f, 0f);
		tblTermBegins.Name = "tblTermBegins";
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow2 });
		tblTermBegins.SizeF = new SizeF(300f, 50f);
		tblTermBegins.StylePriority.UseBorders = false;
		xrTableRow1.Cells.AddRange(new XRTableCell[2] { xrTableCell5, xrTableCell41 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell5.BackColor = Color.Black;
		xrTableCell5.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell5.Borders = BorderSide.All;
		xrTableCell5.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell5.ForeColor = Color.White;
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseBackColor = false;
		xrTableCell5.StylePriority.UseBorderDashStyle = false;
		xrTableCell5.StylePriority.UseBorders = false;
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.StylePriority.UseForeColor = false;
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "Next Term Begins";
		xrTableCell5.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell5.Weight = 0.5614441542693065;
		xrTableCell41.BackColor = Color.Black;
		xrTableCell41.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell41.Borders = BorderSide.All;
		xrTableCell41.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell41.ForeColor = Color.White;
		xrTableCell41.Multiline = true;
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.StylePriority.UseBackColor = false;
		xrTableCell41.StylePriority.UseBorderDashStyle = false;
		xrTableCell41.StylePriority.UseBorders = false;
		xrTableCell41.StylePriority.UseFont = false;
		xrTableCell41.StylePriority.UseForeColor = false;
		xrTableCell41.StylePriority.UseTextAlignment = false;
		xrTableCell41.Text = "Next Term Ends On";
		xrTableCell41.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell41.Weight = 0.5614441542693065;
		xrTableRow2.Cells.AddRange(new XRTableCell[2] { lblNextTermBegins, lblNextTermEndsOn });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		lblNextTermBegins.BorderDashStyle = BorderDashStyle.Solid;
		lblNextTermBegins.Borders = BorderSide.All;
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
		lblNextTermBegins.TextAlignment = TextAlignment.MiddleCenter;
		lblNextTermBegins.Weight = 0.5614441542693065;
		lblNextTermEndsOn.BorderDashStyle = BorderDashStyle.Solid;
		lblNextTermEndsOn.Borders = BorderSide.All;
		lblNextTermEndsOn.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblNextTermEndsOn.ForeColor = Color.Black;
		lblNextTermEndsOn.Multiline = true;
		lblNextTermEndsOn.Name = "lblNextTermEndsOn";
		lblNextTermEndsOn.StylePriority.UseBorderDashStyle = false;
		lblNextTermEndsOn.StylePriority.UseBorders = false;
		lblNextTermEndsOn.StylePriority.UseFont = false;
		lblNextTermEndsOn.StylePriority.UseForeColor = false;
		lblNextTermEndsOn.StylePriority.UseTextAlignment = false;
		lblNextTermEndsOn.TextAlignment = TextAlignment.MiddleCenter;
		lblNextTermEndsOn.Weight = 0.5614441542693065;
		tblFeesInfo.Borders = BorderSide.All;
		tblFeesInfo.LocationFloat = new PointFloat(325.73f, 0f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow10, xrTableRow15 });
		tblFeesInfo.SizeF = new SizeF(309.6474f, 50f);
		tblFeesInfo.StylePriority.UseBorders = false;
		xrTableRow10.Cells.AddRange(new XRTableCell[2] { xrTableCell7, xrTableCell1 });
		xrTableRow10.Name = "xrTableRow10";
		xrTableRow10.Weight = 1.0;
		xrTableCell7.BackColor = Color.Black;
		xrTableCell7.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell7.Borders = BorderSide.All;
		xrTableCell7.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell7.ForeColor = Color.White;
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseBackColor = false;
		xrTableCell7.StylePriority.UseBorderDashStyle = false;
		xrTableCell7.StylePriority.UseBorders = false;
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.StylePriority.UseForeColor = false;
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Text = "Fees Balance";
		xrTableCell7.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell7.Weight = 0.37753038223003454;
		xrTableCell1.BackColor = Color.Black;
		xrTableCell1.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell1.Borders = BorderSide.All;
		xrTableCell1.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell1.ForeColor = Color.White;
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseBackColor = false;
		xrTableCell1.StylePriority.UseBorderDashStyle = false;
		xrTableCell1.StylePriority.UseBorders = false;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseForeColor = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.Text = "Fees Next Term";
		xrTableCell1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell1.Weight = 0.3775304025255647;
		xrTableRow15.Cells.AddRange(new XRTableCell[2] { xrTableCell14, xrTableCell15 });
		xrTableRow15.Name = "xrTableRow15";
		xrTableRow15.Weight = 1.0;
		xrTableCell14.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell14.Borders = BorderSide.All;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[cashOnAccount]")
		});
		xrTableCell14.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell14.ForeColor = Color.Black;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseBorderDashStyle = false;
		xrTableCell14.StylePriority.UseBorders = false;
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseForeColor = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell14.TextFormatString = "{0:#,#}";
		xrTableCell14.Weight = 0.37753038223003454;
		xrTableCell15.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell15.Borders = BorderSide.All;
		xrTableCell15.CanGrow = false;
		xrTableCell15.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBorderDashStyle = false;
		xrTableCell15.StylePriority.UseBorders = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.TextFormatString = "{0:#,#}";
		xrTableCell15.Weight = 0.3775304025255647;
		xrTableCell15.WordWrap = false;
		xrBarCode2.AutoModule = true;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.ForeColor = Color.DarkSlateBlue;
		xrBarCode2.LocationFloat = new PointFloat(655.5f, 0f);
		xrBarCode2.Module = 1f;
		xrBarCode2.Name = "xrBarCode2";
		xrBarCode2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode2.SizeF = new SizeF(125f, 50f);
		xrBarCode2.StylePriority.UseForeColor = false;
		xrBarCode2.StylePriority.UsePadding = false;
		xrBarCode2.Symbology = symbology;
		xrShape7.BackColor = Color.Transparent;
		xrShape7.FillColor = Color.Black;
		xrShape7.LineWidth = 3;
		xrShape7.LocationFloat = new PointFloat(198.25f, 105.5f);
		xrShape7.Name = "xrShape7";
		shapeRectangle.Fillet = 60;
		xrShape7.Shape = shapeRectangle;
		xrShape7.SizeF = new SizeF(390.4999f, 35.00001f);
		xrShape7.Stretch = true;
		xrShape7.StylePriority.UseBackColor = false;
		xrLabel13.BackColor = Color.Transparent;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel13.ForeColor = Color.White;
		xrLabel13.LocationFloat = new PointFloat(211.75f, 112f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(363.4999f, 22.99999f);
		xrLabel13.StylePriority.UseBackColor = false;
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseForeColor = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "xrLabel13";
		xrLabel13.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel13.WordWrap = false;
		xrPictureBox1.BorderColor = Color.Gainsboro;
		xrPictureBox1.Borders = BorderSide.All;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(669f, 150.2966f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(107f, 109f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrTable2.BorderColor = Color.MidnightBlue;
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(5.5f, 152.2966f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow8, xrTableRow9 });
		xrTable2.SizeF = new SizeF(662.5f, 50f);
		xrTable2.StylePriority.UseBorderColor = false;
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UsePadding = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow8.Cells.AddRange(new XRTableCell[3] { xrTableCell63, lblNumberHeader, xrTableCell64 });
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell63.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell63.Multiline = true;
		xrTableCell63.Name = "xrTableCell63";
		xrTableCell63.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell63.StylePriority.UseFont = false;
		xrTableCell63.StylePriority.UsePadding = false;
		xrTableCell63.Text = "Name";
		xrTableCell63.Weight = 1.9975988453832167;
		lblNumberHeader.Font = new DXFont("Cascadia Mono", 10f);
		lblNumberHeader.Multiline = true;
		lblNumberHeader.Name = "lblNumberHeader";
		lblNumberHeader.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblNumberHeader.StylePriority.UseFont = false;
		lblNumberHeader.StylePriority.UsePadding = false;
		lblNumberHeader.StylePriority.UseTextAlignment = false;
		lblNumberHeader.Text = "Student No";
		lblNumberHeader.TextAlignment = TextAlignment.MiddleCenter;
		lblNumberHeader.Weight = 0.511698098333536;
		xrTableCell64.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell64.Multiline = true;
		xrTableCell64.Name = "xrTableCell64";
		xrTableCell64.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell64.StylePriority.UseFont = false;
		xrTableCell64.StylePriority.UsePadding = false;
		xrTableCell64.StylePriority.UseTextAlignment = false;
		xrTableCell64.Text = "Gender";
		xrTableCell64.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell64.Weight = 0.4907030562832473;
		xrTableRow9.Cells.AddRange(new XRTableCell[3] { lblName, lblStudentNumber, xrTableCell65 });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		lblName.CanGrow = false;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		lblName.Name = "lblName";
		lblName.StylePriority.UseFont = false;
		lblName.Weight = 1.9975988453832167;
		lblName.WordWrap = false;
		lblName.PrintOnPage += xrLabel1_PrintOnPage;
		lblStudentNumber.CanGrow = false;
		lblStudentNumber.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		lblStudentNumber.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		lblStudentNumber.Name = "lblStudentNumber";
		lblStudentNumber.StylePriority.UseFont = false;
		lblStudentNumber.StylePriority.UseTextAlignment = false;
		lblStudentNumber.TextAlignment = TextAlignment.MiddleCenter;
		lblStudentNumber.Weight = 0.511698098333536;
		lblStudentNumber.WordWrap = false;
		xrTableCell65.CanGrow = false;
		xrTableCell65.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell65.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrTableCell65.Name = "xrTableCell65";
		xrTableCell65.StylePriority.UseFont = false;
		xrTableCell65.StylePriority.UseTextAlignment = false;
		xrTableCell65.Text = "xrTableCell21";
		xrTableCell65.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell65.Weight = 0.4907030562832473;
		xrTableCell65.WordWrap = false;
		xrTable1.BorderColor = Color.MidnightBlue;
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(5.505f, 209.2967f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable1.Rows.AddRange(new XRTableRow[2] { xrTableRow12, xrTableRow3 });
		xrTable1.SizeF = new SizeF(340.875f, 49.99999f);
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UsePadding = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow12.Cells.AddRange(new XRTableCell[3] { xrTableCell57, xrTableCell58, xrTableCell59 });
		xrTableRow12.Name = "xrTableRow12";
		xrTableRow12.Weight = 1.0;
		xrTableCell57.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell57.Multiline = true;
		xrTableCell57.Name = "xrTableCell57";
		xrTableCell57.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell57.StylePriority.UseFont = false;
		xrTableCell57.StylePriority.UsePadding = false;
		xrTableCell57.StylePriority.UseTextAlignment = false;
		xrTableCell57.Text = "Class";
		xrTableCell57.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell57.Weight = 0.4846629834597481;
		xrTableCell58.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell58.Multiline = true;
		xrTableCell58.Name = "xrTableCell58";
		xrTableCell58.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell58.StylePriority.UseFont = false;
		xrTableCell58.StylePriority.UsePadding = false;
		xrTableCell58.StylePriority.UseTextAlignment = false;
		xrTableCell58.Text = "Stream";
		xrTableCell58.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell58.Weight = 0.6783332443108346;
		xrTableCell59.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell59.Multiline = true;
		xrTableCell59.Name = "xrTableCell59";
		xrTableCell59.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell59.StylePriority.UseFont = false;
		xrTableCell59.StylePriority.UsePadding = false;
		xrTableCell59.StylePriority.UseTextAlignment = false;
		xrTableCell59.Text = "House";
		xrTableCell59.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell59.Weight = 0.99154933081207;
		xrTableRow3.Cells.AddRange(new XRTableCell[3] { xrTableCell60, xrTableCell61, xrTableCell62 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell60.CanGrow = false;
		xrTableCell60.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrTableCell60.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell60.StylePriority.UseFont = false;
		xrTableCell60.StylePriority.UsePadding = false;
		xrTableCell60.StylePriority.UseTextAlignment = false;
		xrTableCell60.Text = "xrTableCell29";
		xrTableCell60.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell60.Weight = 0.4846629834597481;
		xrTableCell60.WordWrap = false;
		xrTableCell61.CanGrow = false;
		xrTableCell61.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrTableCell61.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell61.StylePriority.UseFont = false;
		xrTableCell61.StylePriority.UsePadding = false;
		xrTableCell61.StylePriority.UseTextAlignment = false;
		xrTableCell61.Text = "xrTableCell30";
		xrTableCell61.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell61.Weight = 0.6783332443108346;
		xrTableCell61.WordWrap = false;
		xrTableCell62.CanGrow = false;
		xrTableCell62.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HouseId]")
		});
		xrTableCell62.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell62.StylePriority.UseFont = false;
		xrTableCell62.StylePriority.UsePadding = false;
		xrTableCell62.StylePriority.UseTextAlignment = false;
		xrTableCell62.Text = "xrTableCell31";
		xrTableCell62.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell62.Weight = 0.99154933081207;
		xrTableCell62.WordWrap = false;
		xrTable5.BorderColor = Color.MidnightBlue;
		xrTable5.Borders = BorderSide.All;
		xrTable5.LocationFloat = new PointFloat(346.38f, 209.2967f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow14, xrTableRow11 });
		xrTable5.SizeF = new SizeF(321.12f, 49.99998f);
		xrTable5.StylePriority.UseBorderColor = false;
		xrTable5.StylePriority.UseBorders = false;
		xrTable5.StylePriority.UsePadding = false;
		xrTable5.StylePriority.UseTextAlignment = false;
		xrTable5.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow14.Cells.AddRange(new XRTableCell[1] { xrTableCell54 });
		xrTableRow14.Name = "xrTableRow14";
		xrTableRow14.Weight = 1.0;
		xrTableCell54.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell54.Multiline = true;
		xrTableCell54.Name = "xrTableCell54";
		xrTableCell54.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell54.StylePriority.UseFont = false;
		xrTableCell54.StylePriority.UsePadding = false;
		xrTableCell54.StylePriority.UseTextAlignment = false;
		xrTableCell54.Text = "Term";
		xrTableCell54.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell54.Weight = 0.655303159322368;
		xrTableRow11.Cells.AddRange(new XRTableCell[1] { lblSemester });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		lblSemester.CanGrow = false;
		lblSemester.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SemesterId]")
		});
		lblSemester.Font = new DXFont("Tahoma", 8.5f, DXFontStyle.Bold);
		lblSemester.Name = "lblSemester";
		lblSemester.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblSemester.StylePriority.UseFont = false;
		lblSemester.StylePriority.UsePadding = false;
		lblSemester.StylePriority.UseTextAlignment = false;
		lblSemester.TextAlignment = TextAlignment.MiddleCenter;
		lblSemester.Weight = 0.655303159322368;
		lblSemester.WordWrap = false;
		base.Bands.AddRange(new Band[13]
		{
			Detail, pageFooterBand1, topMarginBand1, bottomMarginBand1, GroupFooter1, footerGradingScale, footerComment1, footerComment2, footerFeesInfo, footerPromotion,
			GroupHeader1, footerCommentHeader, footerOtherSubjects
		});
		base.ComponentStorage.AddRange(new IComponent[1] { primaryMainReport1 });
		base.DataAdapter = adapterPrimaryMainReport;
		base.DataMember = "PrimaryMainReport";
		base.DataSource = primaryMainReport1;
		base.Margins = new DXMargins(23f, 23f, 24f, 20f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ReportPrintOptions.PrintOnEmptyDataSource = false;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "23.2";
		BeforePrint += OLevel_Report_LowerAll_BeforePrint;
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)xrTable6).EndInit();
		((ISupportInitialize)primaryMainReport1).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
