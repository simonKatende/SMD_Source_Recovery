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

public class MainReportNewCurLO : XtraReport
{
	private string studNo = string.Empty;

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

	private PageHeaderBand PageHeader;

	private XRSubreport xrSubreport2;

	private GroupHeaderBand groupHeaderBand1;

	private XRShape xrShape7;

	private XRLabel xrLabel13;

	private GroupFooterBand GroupFooter2;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell41;

	private XRTableRow xrTableRow2;

	private XRTableCell lblNextTermBegins;

	private XRTableCell lblNextTermEndsOn;

	private XRBarCode xrBarCode2;

	private XRPictureBox xrPictureBox1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell6;

	private XRTableCell lblNumberHeader;

	private XRTableCell xrTableCell28;

	private XRTableRow xrTableRow4;

	private XRTableCell lblName;

	private XRTableCell lblStudentNumber;

	private XRTableCell xrTableCell21;

	private XRTable xrTable3;

	private XRTableRow xrTableRow12;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell36;

	private XRTableRow xrTableRow9;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTable xrTable5;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell38;

	private XRTableRow xrTableRow5;

	private XRTableCell lblSemester;

	private XRTableCell xrTableCell33;

	private StudentsSourceDS studentsSourceDS1;

	private adapterStudentsDS adapterStudentsDS;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell12;

	private XRTableRow xrTableRow15;

	private XRTableCell lblFeesBalance;

	private XRTableCell lblFeesNextTerm;

	private XRLabel lblOtherRequirements;

	private XRLabel xrLabel1;

	public MainReportNewCurLO(bool showUnAssessed)
	{
		InitializeComponent();
		xrLabel13.Text = "END OF " + ReportParameters.Semester + " REPORT CARD";
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
		if (ReportHeader.SelectedCode == 0)
		{
			lblNumberHeader.Text = "Student No.";
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]"));
		}
		else if (ReportHeader.SelectedCode == 1)
		{
			lblNumberHeader.Text = "Student ID";
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentID]"));
		}
		else if (ReportHeader.SelectedCode == 2)
		{
			lblNumberHeader.Text = "LIN";
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[LIN]"));
		}
		lblNextTermBegins.Text = ReportHeader.NextTermBeginsOn.ToString("dd-MMM-yyyy");
		lblNextTermEndsOn.Text = ReportHeader.NextTermEndsOn.ToString("dd-MMM-yyyy");
	}

	private void lblName_PrintOnPage(object sender, PrintOnPageEventArgs e)
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
		ShapeRectangle shapeRectangle = new ShapeRectangle();
		EAN13Generator symbology = new EAN13Generator();
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
		PageHeader = new PageHeaderBand();
		groupHeaderBand1 = new GroupHeaderBand();
		xrPictureBox1 = new XRPictureBox();
		xrTable1 = new XRTable();
		xrTableRow3 = new XRTableRow();
		xrTableCell6 = new XRTableCell();
		lblNumberHeader = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableRow4 = new XRTableRow();
		lblName = new XRTableCell();
		lblStudentNumber = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTable3 = new XRTable();
		xrTableRow12 = new XRTableRow();
		xrTableCell34 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTable5 = new XRTable();
		xrTableRow14 = new XRTableRow();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		lblSemester = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrLabel13 = new XRLabel();
		xrShape7 = new XRShape();
		GroupFooter2 = new GroupFooterBand();
		lblOtherRequirements = new XRLabel();
		xrLabel1 = new XRLabel();
		tblFeesInfo = new XRTable();
		xrTableRow10 = new XRTableRow();
		xrTableCell7 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableRow15 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		lblFeesNextTerm = new XRTableCell();
		xrBarCode2 = new XRBarCode();
		tblTermBegins = new XRTable();
		xrTableRow6 = new XRTableRow();
		xrTableCell5 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		lblNextTermEndsOn = new XRTableCell();
		studentsSourceDS1 = new StudentsSourceDS();
		adapterStudentsDS = new adapterStudentsDS();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)studentsSourceDS1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrSubreport2 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrSubreport2.LocationFloat = new PointFloat(0.9999105f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("studNumber", null, "dsMainReportNewCurr.StudentNumber"));
		xrSubreport2.ReportSource = new NewCurriculumSubUpperLO();
		xrSubreport2.SizeF = new SizeF(778f, 23f);
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
		xrSubreport1.SizeF = new SizeF(778f, 90.00001f);
		topMarginBand1.HeightF = 23f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 23f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semester.Description = "Semester:";
		semester.Name = "semester";
		studentClass.Description = "Student Class:";
		studentClass.Name = "studentClass";
		PageHeader.Controls.AddRange(new XRControl[1] { xrSubreport1 });
		PageHeader.HeightF = 90.00001f;
		PageHeader.Name = "PageHeader";
		groupHeaderBand1.Controls.AddRange(new XRControl[6] { xrPictureBox1, xrTable1, xrTable3, xrTable5, xrLabel13, xrShape7 });
		groupHeaderBand1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		groupHeaderBand1.HeightF = 170f;
		groupHeaderBand1.KeepTogether = true;
		groupHeaderBand1.Name = "groupHeaderBand1";
		groupHeaderBand1.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
		groupHeaderBand1.RepeatEveryPage = true;
		xrPictureBox1.BorderColor = Color.Gainsboro;
		xrPictureBox1.Borders = BorderSide.All;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(668f, 47.5f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(107f, 109f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(1f, 49.5f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable1.Rows.AddRange(new XRTableRow[2] { xrTableRow3, xrTableRow4 });
		xrTable1.SizeF = new SizeF(662.5f, 50f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UsePadding = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow3.Cells.AddRange(new XRTableCell[3] { xrTableCell6, lblNumberHeader, xrTableCell28 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell6.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UsePadding = false;
		xrTableCell6.Text = "Name";
		xrTableCell6.Weight = 1.9975988453832167;
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
		xrTableCell28.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell28.Multiline = true;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UsePadding = false;
		xrTableCell28.StylePriority.UseTextAlignment = false;
		xrTableCell28.Text = "Gender";
		xrTableCell28.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell28.Weight = 0.4907030562832473;
		xrTableRow4.Cells.AddRange(new XRTableCell[3] { lblName, lblStudentNumber, xrTableCell21 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		lblName.CanShrink = true;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		lblName.Name = "lblName";
		lblName.StylePriority.UseFont = false;
		lblName.Weight = 1.9975988453832167;
		lblName.WordWrap = false;
		lblName.PrintOnPage += lblName_PrintOnPage;
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
		xrTableCell21.CanGrow = false;
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell21.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 0.4907030562832473;
		xrTableCell21.WordWrap = false;
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(1f, 106.5f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable3.Rows.AddRange(new XRTableRow[2] { xrTableRow12, xrTableRow9 });
		xrTable3.SizeF = new SizeF(340.875f, 49.99999f);
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UsePadding = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow12.Cells.AddRange(new XRTableCell[3] { xrTableCell34, xrTableCell35, xrTableCell36 });
		xrTableRow12.Name = "xrTableRow12";
		xrTableRow12.Weight = 1.0;
		xrTableCell34.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell34.Multiline = true;
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.StylePriority.UsePadding = false;
		xrTableCell34.StylePriority.UseTextAlignment = false;
		xrTableCell34.Text = "Class";
		xrTableCell34.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell34.Weight = 0.4846629834597481;
		xrTableCell35.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell35.Multiline = true;
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.StylePriority.UsePadding = false;
		xrTableCell35.StylePriority.UseTextAlignment = false;
		xrTableCell35.Text = "Stream";
		xrTableCell35.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell35.Weight = 0.6783332443108346;
		xrTableCell36.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell36.Multiline = true;
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell36.StylePriority.UseFont = false;
		xrTableCell36.StylePriority.UsePadding = false;
		xrTableCell36.StylePriority.UseTextAlignment = false;
		xrTableCell36.Text = "House";
		xrTableCell36.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell36.Weight = 0.99154933081207;
		xrTableRow9.Cells.AddRange(new XRTableCell[3] { xrTableCell29, xrTableCell30, xrTableCell31 });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		xrTableCell29.CanGrow = false;
		xrTableCell29.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrTableCell29.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.StylePriority.UsePadding = false;
		xrTableCell29.StylePriority.UseTextAlignment = false;
		xrTableCell29.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell29.Weight = 0.4846629834597481;
		xrTableCell29.WordWrap = false;
		xrTableCell30.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrTableCell30.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell30.Multiline = true;
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.StylePriority.UsePadding = false;
		xrTableCell30.StylePriority.UseTextAlignment = false;
		xrTableCell30.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell30.Weight = 0.6783332443108346;
		xrTableCell31.CanGrow = false;
		xrTableCell31.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HouseId]")
		});
		xrTableCell31.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.StylePriority.UseTextAlignment = false;
		xrTableCell31.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell31.Weight = 0.99154933081207;
		xrTableCell31.WordWrap = false;
		xrTable5.Borders = BorderSide.All;
		xrTable5.LocationFloat = new PointFloat(341.88f, 106.5f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow14, xrTableRow5 });
		xrTable5.SizeF = new SizeF(321.625f, 49.99999f);
		xrTable5.StylePriority.UseBorders = false;
		xrTable5.StylePriority.UsePadding = false;
		xrTable5.StylePriority.UseTextAlignment = false;
		xrTable5.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow14.Cells.AddRange(new XRTableCell[2] { xrTableCell37, xrTableCell38 });
		xrTableRow14.Name = "xrTableRow14";
		xrTableRow14.Weight = 1.0;
		xrTableCell37.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell37.Multiline = true;
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.StylePriority.UsePadding = false;
		xrTableCell37.StylePriority.UseTextAlignment = false;
		xrTableCell37.Text = "Term";
		xrTableCell37.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell37.Weight = 0.655303159322368;
		xrTableCell38.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell38.Multiline = true;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.StylePriority.UsePadding = false;
		xrTableCell38.StylePriority.UseTextAlignment = false;
		xrTableCell38.Text = "PLE Results";
		xrTableCell38.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell38.Weight = 1.4468210236841679;
		xrTableRow5.Cells.AddRange(new XRTableCell[2] { lblSemester, xrTableCell33 });
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
		xrTableCell33.CanGrow = false;
		xrTableCell33.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryScores1]")
		});
		xrTableCell33.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.StylePriority.UsePadding = false;
		xrTableCell33.StylePriority.UseTextAlignment = false;
		xrTableCell33.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell33.Weight = 1.4468210236841679;
		xrTableCell33.WordWrap = false;
		xrLabel13.BackColor = Color.Transparent;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel13.ForeColor = Color.Black;
		xrLabel13.LocationFloat = new PointFloat(206.25f, 12f);
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
		xrShape7.LocationFloat = new PointFloat(192.75f, 5.5f);
		xrShape7.Name = "xrShape7";
		shapeRectangle.Fillet = 60;
		xrShape7.Shape = shapeRectangle;
		xrShape7.SizeF = new SizeF(390.4999f, 35.00001f);
		xrShape7.Stretch = true;
		GroupFooter2.Controls.AddRange(new XRControl[5] { lblOtherRequirements, xrLabel1, tblFeesInfo, xrBarCode2, tblTermBegins });
		GroupFooter2.HeightF = 82f;
		GroupFooter2.Level = 1;
		GroupFooter2.Name = "GroupFooter2";
		GroupFooter2.PrintAtBottom = true;
		GroupFooter2.RepeatEveryPage = true;
		lblOtherRequirements.CanGrow = false;
		lblOtherRequirements.Font = new DXFont("Consolas", 11f);
		lblOtherRequirements.LocationFloat = new PointFloat(186.375f, 59f);
		lblOtherRequirements.Name = "lblOtherRequirements";
		lblOtherRequirements.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblOtherRequirements.SizeF = new SizeF(588.625f, 23f);
		lblOtherRequirements.StylePriority.UseFont = false;
		lblOtherRequirements.StylePriority.UseTextAlignment = false;
		lblOtherRequirements.TextAlignment = TextAlignment.MiddleLeft;
		lblOtherRequirements.WordWrap = false;
		xrLabel1.Font = new DXFont("Consolas", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(3.000005f, 59f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(181.5f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Other Requirements:";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		tblFeesInfo.Borders = BorderSide.All;
		tblFeesInfo.LocationFloat = new PointFloat(321.23f, 0f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow10, xrTableRow15 });
		tblFeesInfo.SizeF = new SizeF(309.6474f, 50f);
		tblFeesInfo.StylePriority.UseBorders = false;
		xrTableRow10.Cells.AddRange(new XRTableCell[2] { xrTableCell7, xrTableCell12 });
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
		xrTableCell12.BackColor = Color.Black;
		xrTableCell12.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell12.Borders = BorderSide.All;
		xrTableCell12.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell12.ForeColor = Color.White;
		xrTableCell12.Multiline = true;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseBackColor = false;
		xrTableCell12.StylePriority.UseBorderDashStyle = false;
		xrTableCell12.StylePriority.UseBorders = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UseForeColor = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.Text = "Fees Next Term";
		xrTableCell12.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell12.Weight = 0.3775304025255647;
		xrTableRow15.Cells.AddRange(new XRTableCell[2] { lblFeesBalance, lblFeesNextTerm });
		xrTableRow15.Name = "xrTableRow15";
		xrTableRow15.Weight = 1.0;
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
		xrBarCode2.AutoModule = true;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.ForeColor = Color.DarkSlateBlue;
		xrBarCode2.LocationFloat = new PointFloat(656f, 0f);
		xrBarCode2.Module = 1f;
		xrBarCode2.Name = "xrBarCode2";
		xrBarCode2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode2.SizeF = new SizeF(125f, 50f);
		xrBarCode2.StylePriority.UseForeColor = false;
		xrBarCode2.StylePriority.UsePadding = false;
		xrBarCode2.Symbology = symbology;
		tblTermBegins.Borders = BorderSide.All;
		tblTermBegins.LocationFloat = new PointFloat(0f, 0f);
		tblTermBegins.Name = "tblTermBegins";
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow6, xrTableRow2 });
		tblTermBegins.SizeF = new SizeF(300f, 50f);
		tblTermBegins.StylePriority.UseBorders = false;
		xrTableRow6.Cells.AddRange(new XRTableCell[2] { xrTableCell5, xrTableCell41 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
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
		studentsSourceDS1.DataSetName = "StudentsSourceDS";
		studentsSourceDS1.EnforceConstraints = false;
		studentsSourceDS1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterStudentsDS.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[6] { Detail, topMarginBand1, bottomMarginBand1, PageHeader, groupHeaderBand1, GroupFooter2 });
		base.ComponentStorage.AddRange(new IComponent[1] { studentsSourceDS1 });
		base.DataAdapter = adapterStudentsDS;
		base.DataMember = "StudentsDS";
		base.DataSource = studentsSourceDS1;
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "23.2";
		BeforePrint += OLevel_Report_LowerAll_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)studentsSourceDS1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
