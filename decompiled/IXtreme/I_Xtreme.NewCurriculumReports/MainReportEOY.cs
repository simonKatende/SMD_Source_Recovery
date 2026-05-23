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
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.NewCurriculumReports.ReportDatasets;
using I_Xtreme.NewCurriculumReports.ReportDatasets.StudentsSourceDSTableAdapters;
using I_Xtreme.NewCurriculumReports.SubReports;

namespace I_Xtreme.NewCurriculumReports;

public class MainReportEOY : XtraReport
{
	private bool showUnAssessed = false;

	private int viewMode = 0;

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

	private XRSubreport xrSubreport1;

	private GroupFooterBand footerComment1;

	private GroupFooterBand footerFeesInfo;

	private PageHeaderBand PageHeader;

	private GroupFooterBand footerOtherSubjects;

	private XRSubreport xrSubreport2;

	private GroupHeaderBand groupHeaderBand1;

	private XRSubreport xrSubreport3;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell14;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell1;

	private XRTableRow xrTableRow3;

	private XRTable xrTable1;

	private XRLabel xrLabel9;

	private GroupFooterBand footerKeysUsed;

	private XRShape xrShape7;

	private XRLabel xrLabel13;

	private StudentsSourceDS studentsSourceDS1;

	private adapterStudentsDS adapterStudentsDS;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell41;

	private XRTableRow xrTableRow2;

	private XRTableCell lblNextTermBegins;

	private XRTableCell lblNextTermEndsOn;

	private XRBarCode xrBarCode2;

	private XRTable xrTable5;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell54;

	private XRTableCell xrTableCell55;

	private XRTableRow xrTableRow5;

	private XRTableCell lblSemester;

	private XRTableCell xrTableCell56;

	private XRTable xrTable3;

	private XRTableRow xrTableRow12;

	private XRTableCell xrTableCell57;

	private XRTableCell xrTableCell58;

	private XRTableCell xrTableCell59;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell60;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell62;

	private XRTable xrTable2;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell63;

	private XRTableCell lblNumberHeader;

	private XRTableCell xrTableCell64;

	private XRTableRow xrTableRow9;

	private XRTableCell lblName;

	private XRTableCell lblStudentNumber;

	private XRTableCell xrTableCell65;

	private XRPictureBox xrPictureBox1;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell66;

	private XRTableCell xrTableCell67;

	private XRTableRow xrTableRow13;

	private XRTableCell lblFeesBalance;

	private XRTableCell lblFeesNextTerm;

	private XRLabel xrLabel1;

	private XRLabel lblOtherRequirements;

	private XRTable xrTable4;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell42;

	private XRTableRow xrTableRow20;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell33;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell36;

	private XRTableRow xrTableRow21;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell45;

	private XRTableCell xrTableCell46;

	private XRTableCell xrTableCell47;

	public MainReportEOY(bool showUnAssessed, int viewMode)
	{
		InitializeComponent();
		this.showUnAssessed = showUnAssessed;
		this.viewMode = viewMode;
		lblSemester.Text = ReportParameters.Semester;
	}

	private void OLevel_Report_LowerAll_BeforePrint(object sender, CancelEventArgs e)
	{
		xrShape7.BorderColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrShape7.FillColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrLabel13.ForeColor = Color.FromArgb((int)ReportColors.ReportForeColor);
		xrSubreport1.Visible = ReportCustomization.ShowHeader;
		if (ReportHeaderAlign.HeaderAlignment == "Left")
		{
			SchoolHeaderM reportSource = new SchoolHeaderM();
			xrSubreport1.ReportSource = reportSource;
		}
		else if (ReportHeaderAlign.HeaderAlignment == "Center")
		{
			SchoolHeader_CenterM reportSource2 = new SchoolHeader_CenterM();
			xrSubreport1.ReportSource = reportSource2;
		}
		else if (ReportHeaderAlign.HeaderAlignment == "Right")
		{
			SchoolHeader_RightM reportSource3 = new SchoolHeader_RightM();
			xrSubreport1.ReportSource = reportSource3;
		}
		xrLabel13.Text = ReportHeader.HeaderString;
		if (!ReportCustomization.ShowFeesBalance)
		{
			lblFeesBalance.ExpressionBindings.Clear();
		}
		if (!ReportCustomization.ShowFeesNextTerm)
		{
			lblFeesNextTerm.ExpressionBindings.Clear();
		}
		if (showUnAssessed)
		{
			footerOtherSubjects.Visible = true;
		}
		else
		{
			footerOtherSubjects.Visible = false;
		}
		EOY100 reportSource4 = new EOY100();
		xrSubreport2.ReportSource = reportSource4;
		lblNextTermBegins.Text = ReportHeader.NextTermBeginsOn.ToString("dd-MMM-yyyy");
		lblNextTermEndsOn.Text = ReportHeader.NextTermEndsOn.ToString("dd-MMM-yyyy");
	}

	private void xrLabel1_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		string text = lblName.Text;
		((XRLabel)sender).Bookmark += text;
	}

	private void xrSubreport2_BeforePrint(object sender, CancelEventArgs e)
	{
		lblOtherRequirements.Text = ((XRSubreport)sender).ReportSource.Parameters["OtherFeesRequirements"].Value.ToString();
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
		EAN13Generator symbology = new EAN13Generator();
		ShapeRectangle shapeRectangle = new ShapeRectangle();
		Detail = new DetailBand();
		xrSubreport2 = new XRSubreport();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		xrSubreport1 = new XRSubreport();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		semester = new Parameter();
		studentClass = new Parameter();
		footerComment1 = new GroupFooterBand();
		footerFeesInfo = new GroupFooterBand();
		xrLabel1 = new XRLabel();
		lblOtherRequirements = new XRLabel();
		tblFeesInfo = new XRTable();
		xrTableRow10 = new XRTableRow();
		xrTableCell66 = new XRTableCell();
		xrTableCell67 = new XRTableCell();
		xrTableRow13 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		lblFeesNextTerm = new XRTableCell();
		tblTermBegins = new XRTable();
		xrTableRow6 = new XRTableRow();
		xrTableCell18 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		lblNextTermEndsOn = new XRTableCell();
		xrBarCode2 = new XRBarCode();
		PageHeader = new PageHeaderBand();
		footerOtherSubjects = new GroupFooterBand();
		xrSubreport3 = new XRSubreport();
		groupHeaderBand1 = new GroupHeaderBand();
		xrTable5 = new XRTable();
		xrTableRow14 = new XRTableRow();
		xrTableCell54 = new XRTableCell();
		xrTableCell55 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		lblSemester = new XRTableCell();
		xrTableCell56 = new XRTableCell();
		xrTable3 = new XRTable();
		xrTableRow12 = new XRTableRow();
		xrTableCell57 = new XRTableCell();
		xrTableCell58 = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell60 = new XRTableCell();
		xrTableCell61 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		xrTable2 = new XRTable();
		xrTableRow8 = new XRTableRow();
		xrTableCell63 = new XRTableCell();
		lblNumberHeader = new XRTableCell();
		xrTableCell64 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		lblName = new XRTableCell();
		lblStudentNumber = new XRTableCell();
		xrTableCell65 = new XRTableCell();
		xrPictureBox1 = new XRPictureBox();
		xrLabel13 = new XRLabel();
		xrShape7 = new XRShape();
		xrTableCell32 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableRow4 = new XRTableRow();
		xrTableCell31 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell1 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTable1 = new XRTable();
		xrLabel9 = new XRLabel();
		footerKeysUsed = new GroupFooterBand();
		studentsSourceDS1 = new StudentsSourceDS();
		adapterStudentsDS = new adapterStudentsDS();
		xrTable4 = new XRTable();
		xrTableRow20 = new XRTableRow();
		xrTableCell29 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableRow21 = new XRTableRow();
		xrTableCell43 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
		xrTableCell46 = new XRTableCell();
		xrTableCell47 = new XRTableCell();
		xrTableRow1 = new XRTableRow();
		xrTableCell42 = new XRTableCell();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)studentsSourceDS1).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrSubreport2 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrSubreport2.LocationFloat = new PointFloat(0.9999116f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("studNumber", null, "StudentsDS.StudentNumber"));
		xrSubreport2.ReportSource = new EOY100();
		xrSubreport2.SizeF = new SizeF(776.0001f, 23f);
		xrSubreport2.BeforePrint += xrSubreport2_BeforePrint;
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
		xrSubreport1.SizeF = new SizeF(775.9999f, 90.00001f);
		topMarginBand1.HeightF = 23f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 23f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semester.Description = "Semester:";
		semester.Name = "semester";
		studentClass.Description = "Student Class:";
		studentClass.Name = "studentClass";
		footerComment1.Controls.AddRange(new XRControl[1] { xrTable4 });
		footerComment1.Font = new DXFont("Times New Roman", 9f);
		footerComment1.HeightF = 69.87502f;
		footerComment1.Level = 2;
		footerComment1.Name = "footerComment1";
		footerComment1.PrintAtBottom = true;
		footerComment1.RepeatEveryPage = true;
		footerComment1.StylePriority.UseFont = false;
		footerFeesInfo.Controls.AddRange(new XRControl[5] { xrLabel1, lblOtherRequirements, tblFeesInfo, tblTermBegins, xrBarCode2 });
		footerFeesInfo.HeightF = 82f;
		footerFeesInfo.Level = 3;
		footerFeesInfo.Name = "footerFeesInfo";
		footerFeesInfo.PrintAtBottom = true;
		footerFeesInfo.RepeatEveryPage = true;
		xrLabel1.Font = new DXFont("Consolas", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(0f, 56.45835f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(181.5f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Other Requirements:";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		lblOtherRequirements.CanGrow = false;
		lblOtherRequirements.Font = new DXFont("Consolas", 11f);
		lblOtherRequirements.LocationFloat = new PointFloat(183.375f, 56.45835f);
		lblOtherRequirements.Name = "lblOtherRequirements";
		lblOtherRequirements.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblOtherRequirements.SizeF = new SizeF(588.625f, 23f);
		lblOtherRequirements.StylePriority.UseFont = false;
		lblOtherRequirements.StylePriority.UseTextAlignment = false;
		lblOtherRequirements.TextAlignment = TextAlignment.MiddleLeft;
		lblOtherRequirements.WordWrap = false;
		tblFeesInfo.Borders = BorderSide.All;
		tblFeesInfo.LocationFloat = new PointFloat(321.23f, 0f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow10, xrTableRow13 });
		tblFeesInfo.SizeF = new SizeF(309.6474f, 50f);
		tblFeesInfo.StylePriority.UseBorders = false;
		xrTableRow10.Cells.AddRange(new XRTableCell[2] { xrTableCell66, xrTableCell67 });
		xrTableRow10.Name = "xrTableRow10";
		xrTableRow10.Weight = 1.0;
		xrTableCell66.BackColor = Color.Black;
		xrTableCell66.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell66.Borders = BorderSide.All;
		xrTableCell66.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell66.ForeColor = Color.White;
		xrTableCell66.Multiline = true;
		xrTableCell66.Name = "xrTableCell66";
		xrTableCell66.StylePriority.UseBackColor = false;
		xrTableCell66.StylePriority.UseBorderDashStyle = false;
		xrTableCell66.StylePriority.UseBorders = false;
		xrTableCell66.StylePriority.UseFont = false;
		xrTableCell66.StylePriority.UseForeColor = false;
		xrTableCell66.StylePriority.UseTextAlignment = false;
		xrTableCell66.Text = "Fees Balance";
		xrTableCell66.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell66.Weight = 0.37753038223003454;
		xrTableCell67.BackColor = Color.Black;
		xrTableCell67.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell67.Borders = BorderSide.All;
		xrTableCell67.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell67.ForeColor = Color.White;
		xrTableCell67.Multiline = true;
		xrTableCell67.Name = "xrTableCell67";
		xrTableCell67.StylePriority.UseBackColor = false;
		xrTableCell67.StylePriority.UseBorderDashStyle = false;
		xrTableCell67.StylePriority.UseBorders = false;
		xrTableCell67.StylePriority.UseFont = false;
		xrTableCell67.StylePriority.UseForeColor = false;
		xrTableCell67.StylePriority.UseTextAlignment = false;
		xrTableCell67.Text = "Fees Next Term";
		xrTableCell67.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell67.Weight = 0.3775304025255647;
		xrTableRow13.Cells.AddRange(new XRTableCell[2] { lblFeesBalance, lblFeesNextTerm });
		xrTableRow13.Name = "xrTableRow13";
		xrTableRow13.Weight = 1.0;
		lblFeesBalance.BorderDashStyle = BorderDashStyle.Solid;
		lblFeesBalance.Borders = BorderSide.All;
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
		lblFeesBalance.TextAlignment = TextAlignment.MiddleCenter;
		lblFeesBalance.TextFormatString = "{0:#,#}";
		lblFeesBalance.Weight = 0.37753038223003454;
		lblFeesNextTerm.BorderDashStyle = BorderDashStyle.Solid;
		lblFeesNextTerm.Borders = BorderSide.All;
		lblFeesNextTerm.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[FeesNextTerm]")
		});
		lblFeesNextTerm.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblFeesNextTerm.Name = "lblFeesNextTerm";
		lblFeesNextTerm.StylePriority.UseBorderDashStyle = false;
		lblFeesNextTerm.StylePriority.UseBorders = false;
		lblFeesNextTerm.StylePriority.UseFont = false;
		lblFeesNextTerm.StylePriority.UseTextAlignment = false;
		lblFeesNextTerm.TextAlignment = TextAlignment.MiddleCenter;
		lblFeesNextTerm.TextFormatString = "{0:#,#}";
		lblFeesNextTerm.Weight = 0.3775304025255647;
		tblTermBegins.Borders = BorderSide.All;
		tblTermBegins.LocationFloat = new PointFloat(0f, 0f);
		tblTermBegins.Name = "tblTermBegins";
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow6, xrTableRow2 });
		tblTermBegins.SizeF = new SizeF(300f, 50f);
		tblTermBegins.StylePriority.UseBorders = false;
		xrTableRow6.Cells.AddRange(new XRTableCell[2] { xrTableCell18, xrTableCell41 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell18.BackColor = Color.Black;
		xrTableCell18.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell18.Borders = BorderSide.All;
		xrTableCell18.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell18.ForeColor = Color.White;
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseBackColor = false;
		xrTableCell18.StylePriority.UseBorderDashStyle = false;
		xrTableCell18.StylePriority.UseBorders = false;
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseForeColor = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "Next Term Begins";
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 0.5614441542693065;
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
		xrBarCode2.AutoModule = true;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.ForeColor = Color.DarkSlateBlue;
		xrBarCode2.LocationFloat = new PointFloat(652.0001f, 0f);
		xrBarCode2.Module = 1f;
		xrBarCode2.Name = "xrBarCode2";
		xrBarCode2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode2.SizeF = new SizeF(125f, 50f);
		xrBarCode2.StylePriority.UseForeColor = false;
		xrBarCode2.StylePriority.UsePadding = false;
		xrBarCode2.Symbology = symbology;
		PageHeader.Controls.AddRange(new XRControl[1] { xrSubreport1 });
		PageHeader.HeightF = 90.00001f;
		PageHeader.Name = "PageHeader";
		footerOtherSubjects.Controls.AddRange(new XRControl[1] { xrSubreport3 });
		footerOtherSubjects.HeightF = 23f;
		footerOtherSubjects.KeepTogether = true;
		footerOtherSubjects.Level = 1;
		footerOtherSubjects.Name = "footerOtherSubjects";
		footerOtherSubjects.RepeatEveryPage = true;
		xrSubreport3.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport3.Name = "xrSubreport3";
		xrSubreport3.ParameterBindings.Add(new ParameterBinding("StudNumber", null, "dsMainReportNewCurr.StudentNumber"));
		xrSubreport3.SizeF = new SizeF(775.9999f, 23f);
		groupHeaderBand1.Controls.AddRange(new XRControl[6] { xrTable5, xrTable3, xrTable2, xrPictureBox1, xrLabel13, xrShape7 });
		groupHeaderBand1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		groupHeaderBand1.HeightF = 175f;
		groupHeaderBand1.KeepTogether = true;
		groupHeaderBand1.Name = "groupHeaderBand1";
		groupHeaderBand1.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
		groupHeaderBand1.RepeatEveryPage = true;
		xrTable5.BorderColor = Color.MidnightBlue;
		xrTable5.Borders = BorderSide.All;
		xrTable5.LocationFloat = new PointFloat(341.88f, 118.1667f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow14, xrTableRow5 });
		xrTable5.SizeF = new SizeF(321.625f, 49.99999f);
		xrTable5.StylePriority.UseBorderColor = false;
		xrTable5.StylePriority.UseBorders = false;
		xrTable5.StylePriority.UsePadding = false;
		xrTable5.StylePriority.UseTextAlignment = false;
		xrTable5.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow14.Cells.AddRange(new XRTableCell[2] { xrTableCell54, xrTableCell55 });
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
		xrTableCell55.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell55.Multiline = true;
		xrTableCell55.Name = "xrTableCell55";
		xrTableCell55.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell55.StylePriority.UseFont = false;
		xrTableCell55.StylePriority.UsePadding = false;
		xrTableCell55.StylePriority.UseTextAlignment = false;
		xrTableCell55.Text = "PLE Results";
		xrTableCell55.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell55.Weight = 1.4468210236841679;
		xrTableRow5.Cells.AddRange(new XRTableCell[2] { lblSemester, xrTableCell56 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		lblSemester.CanGrow = false;
		lblSemester.Font = new DXFont("Tahoma", 8.5f, DXFontStyle.Bold);
		lblSemester.Name = "lblSemester";
		lblSemester.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblSemester.StylePriority.UseFont = false;
		lblSemester.StylePriority.UsePadding = false;
		lblSemester.StylePriority.UseTextAlignment = false;
		lblSemester.TextAlignment = TextAlignment.MiddleCenter;
		lblSemester.Weight = 0.655303159322368;
		lblSemester.WordWrap = false;
		xrTableCell56.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryScores1]")
		});
		xrTableCell56.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell56.Multiline = true;
		xrTableCell56.Name = "xrTableCell56";
		xrTableCell56.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell56.StylePriority.UseFont = false;
		xrTableCell56.StylePriority.UsePadding = false;
		xrTableCell56.StylePriority.UseTextAlignment = false;
		xrTableCell56.Text = "xrTableCell33";
		xrTableCell56.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell56.Weight = 1.4468210236841679;
		xrTable3.BorderColor = Color.MidnightBlue;
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(1.004991f, 118.1667f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable3.Rows.AddRange(new XRTableRow[2] { xrTableRow12, xrTableRow7 });
		xrTable3.SizeF = new SizeF(340.875f, 49.99999f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UsePadding = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
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
		xrTableRow7.Cells.AddRange(new XRTableCell[3] { xrTableCell60, xrTableCell61, xrTableCell62 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell60.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrTableCell60.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell60.Multiline = true;
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell60.StylePriority.UseFont = false;
		xrTableCell60.StylePriority.UsePadding = false;
		xrTableCell60.StylePriority.UseTextAlignment = false;
		xrTableCell60.Text = "xrTableCell29";
		xrTableCell60.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell60.Weight = 0.4846629834597481;
		xrTableCell61.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrTableCell61.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell61.Multiline = true;
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell61.StylePriority.UseFont = false;
		xrTableCell61.StylePriority.UsePadding = false;
		xrTableCell61.StylePriority.UseTextAlignment = false;
		xrTableCell61.Text = "xrTableCell30";
		xrTableCell61.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell61.Weight = 0.6783332443108346;
		xrTableCell62.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HouseId]")
		});
		xrTableCell62.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell62.Multiline = true;
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell62.StylePriority.UseFont = false;
		xrTableCell62.StylePriority.UsePadding = false;
		xrTableCell62.StylePriority.UseTextAlignment = false;
		xrTableCell62.Text = "xrTableCell31";
		xrTableCell62.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell62.Weight = 0.99154933081207;
		xrTable2.BorderColor = Color.MidnightBlue;
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(0.9999909f, 61.16665f);
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
		lblName.CanShrink = true;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		lblName.Name = "lblName";
		lblName.StylePriority.UseFont = false;
		lblName.Text = "xrTableCell17";
		lblName.Weight = 1.9975988453832167;
		lblName.WordWrap = false;
		lblName.PrintOnPage += xrLabel1_PrintOnPage;
		lblStudentNumber.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		lblStudentNumber.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		lblStudentNumber.Multiline = true;
		lblStudentNumber.Name = "lblStudentNumber";
		lblStudentNumber.StylePriority.UseFont = false;
		lblStudentNumber.StylePriority.UseTextAlignment = false;
		lblStudentNumber.TextAlignment = TextAlignment.MiddleCenter;
		lblStudentNumber.Weight = 0.511698098333536;
		xrTableCell65.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell65.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrTableCell65.Multiline = true;
		xrTableCell65.Name = "xrTableCell65";
		xrTableCell65.StylePriority.UseFont = false;
		xrTableCell65.StylePriority.UseTextAlignment = false;
		xrTableCell65.Text = "xrTableCell21";
		xrTableCell65.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell65.Weight = 0.4907030562832473;
		xrPictureBox1.BorderColor = Color.Gainsboro;
		xrPictureBox1.Borders = BorderSide.All;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(664.5f, 59.16665f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(107f, 109f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrLabel13.BackColor = Color.Transparent;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel13.ForeColor = Color.Black;
		xrLabel13.LocationFloat = new PointFloat(207.25f, 20.87f);
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
		xrShape7.LineWidth = 3;
		xrShape7.LocationFloat = new PointFloat(193.75f, 14.37f);
		xrShape7.Name = "xrShape7";
		shapeRectangle.Fillet = 60;
		xrShape7.Shape = shapeRectangle;
		xrShape7.SizeF = new SizeF(390.4999f, 35.00001f);
		xrShape7.Stretch = true;
		xrTableCell32.Multiline = true;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.Weight = 1.0;
		xrTableCell30.Multiline = true;
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.Weight = 1.0;
		xrTableCell27.Multiline = true;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Weight = 1.0;
		xrTableCell26.Multiline = true;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.Weight = 1.0;
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Weight = 1.0;
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Weight = 1.0;
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.Weight = 1.0;
		xrTableCell22.Multiline = true;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Weight = 1.0;
		xrTableCell21.Multiline = true;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Weight = 1.0;
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.Weight = 1.0;
		xrTableCell19.Multiline = true;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.Weight = 1.0;
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Weight = 1.0;
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.Weight = 1.0;
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.Weight = 1.0;
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.Weight = 1.0;
		xrTableRow4.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell14, xrTableCell15, xrTableCell16, xrTableCell17, xrTableCell19, xrTableCell20, xrTableCell21, xrTableCell22, xrTableCell23, xrTableCell24,
			xrTableCell25, xrTableCell26, xrTableCell27, xrTableCell30, xrTableCell32
		});
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell31.Multiline = true;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Text = "IRE";
		xrTableCell31.Weight = 1.0;
		xrTableCell28.Multiline = true;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Text = "CRE";
		xrTableCell28.Weight = 1.0;
		xrTableCell13.Multiline = true;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Text = "Ent";
		xrTableCell13.Weight = 1.0;
		xrTableCell12.Multiline = true;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Text = "Com";
		xrTableCell12.Weight = 1.0;
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.Text = "IPS";
		xrTableCell11.Weight = 1.0;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "Bio";
		xrTableCell10.Weight = 1.0;
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.Text = "Che";
		xrTableCell7.Weight = 1.0;
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "Phy";
		xrTableCell6.Weight = 1.0;
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.Text = "Agr";
		xrTableCell5.Weight = 1.0;
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Text = "PE";
		xrTableCell4.Weight = 1.0;
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.Text = "Mat";
		xrTableCell3.Weight = 1.0;
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Text = "Kis";
		xrTableCell2.Weight = 1.0;
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Text = "Geo";
		xrTableCell8.Weight = 1.0;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Text = "His";
		xrTableCell9.Weight = 1.0;
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Text = "Eng";
		xrTableCell1.Weight = 1.0;
		xrTableRow3.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell1, xrTableCell9, xrTableCell8, xrTableCell2, xrTableCell3, xrTableCell4, xrTableCell5, xrTableCell6, xrTableCell7, xrTableCell10,
			xrTableCell11, xrTableCell12, xrTableCell13, xrTableCell28, xrTableCell31
		});
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTable1.LocationFloat = new PointFloat(0.9999911f, 29.33334f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[2] { xrTableRow3, xrTableRow4 });
		xrTable1.SizeF = new SizeF(776f, 50f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel9.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrLabel9.LocationFloat = new PointFloat(179.8461f, 6.333336f);
		xrLabel9.Multiline = true;
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(404.6475f, 23f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "Project Scores";
		xrLabel9.TextAlignment = TextAlignment.MiddleCenter;
		footerKeysUsed.Controls.AddRange(new XRControl[2] { xrLabel9, xrTable1 });
		footerKeysUsed.HeightF = 79.33334f;
		footerKeysUsed.KeepTogether = true;
		footerKeysUsed.Name = "footerKeysUsed";
		footerKeysUsed.RepeatEveryPage = true;
		footerKeysUsed.Visible = false;
		studentsSourceDS1.DataSetName = "StudentsSourceDS";
		studentsSourceDS1.EnforceConstraints = false;
		studentsSourceDS1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterStudentsDS.ClearBeforeFill = true;
		xrTable4.Borders = BorderSide.All;
		xrTable4.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable4.LocationFloat = new PointFloat(1.00499f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable4.Rows.AddRange(new XRTableRow[3] { xrTableRow1, xrTableRow20, xrTableRow21 });
		xrTable4.SizeF = new SizeF(775.9952f, 69.87502f);
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow20.Cells.AddRange(new XRTableCell[5] { xrTableCell29, xrTableCell33, xrTableCell34, xrTableCell35, xrTableCell36 });
		xrTableRow20.Name = "xrTableRow20";
		xrTableRow20.Weight = 1.0;
		xrTableCell29.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell29.Multiline = true;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.Text = "A";
		xrTableCell29.Weight = 1.0;
		xrTableCell33.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell33.Multiline = true;
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.Text = "B";
		xrTableCell33.Weight = 1.0;
		xrTableCell34.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell34.Multiline = true;
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.Text = "C";
		xrTableCell34.Weight = 1.0;
		xrTableCell35.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell35.Multiline = true;
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.Text = "D";
		xrTableCell35.Weight = 1.0;
		xrTableCell36.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell36.Multiline = true;
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.StylePriority.UseFont = false;
		xrTableCell36.Text = "E";
		xrTableCell36.Weight = 1.0;
		xrTableRow21.Cells.AddRange(new XRTableCell[5] { xrTableCell43, xrTableCell44, xrTableCell45, xrTableCell46, xrTableCell47 });
		xrTableRow21.Name = "xrTableRow21";
		xrTableRow21.Weight = 1.0;
		xrTableCell43.Multiline = true;
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.Text = "80 - 100";
		xrTableCell43.Weight = 1.0;
		xrTableCell44.Multiline = true;
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.Text = "70 - 79";
		xrTableCell44.Weight = 1.0;
		xrTableCell45.Multiline = true;
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.Text = "50 - 69";
		xrTableCell45.Weight = 1.0;
		xrTableCell46.Multiline = true;
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.Text = "35 - 49";
		xrTableCell46.Weight = 1.0;
		xrTableCell47.Multiline = true;
		xrTableCell47.Name = "xrTableCell47";
		xrTableCell47.Text = "0 - 34";
		xrTableCell47.Weight = 1.0;
		xrTableRow1.Cells.AddRange(new XRTableCell[1] { xrTableCell42 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell42.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell42.Multiline = true;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.StylePriority.UseFont = false;
		xrTableCell42.Text = "GRADING SCALE";
		xrTableCell42.Weight = 5.0;
		base.Bands.AddRange(new Band[9] { Detail, topMarginBand1, bottomMarginBand1, footerComment1, footerFeesInfo, PageHeader, footerOtherSubjects, groupHeaderBand1, footerKeysUsed });
		base.ComponentStorage.AddRange(new IComponent[1] { studentsSourceDS1 });
		base.DataAdapter = adapterStudentsDS;
		base.DataMember = "StudentsDS";
		base.DataSource = studentsSourceDS1;
		base.Margins = new DXMargins(25f, 25f, 23f, 23f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "23.2";
		BeforePrint += OLevel_Report_LowerAll_BeforePrint;
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)studentsSourceDS1).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
