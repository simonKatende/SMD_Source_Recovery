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

public class MainReportNewCur2080 : XtraReport
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

	private GroupFooterBand footerKeysUsed;

	private XRShape xrShape7;

	private XRLabel xrLabel13;

	private XRPictureBox xrPictureBox1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell1;

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

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTable xrTable5;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell38;

	private XRTableRow xrTableRow6;

	private XRTableCell lblSemester;

	private XRTableCell xrTableCell4;

	private GroupFooterBand GroupFooter1;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell41;

	private XRTableRow xrTableRow9;

	private XRTableCell lblNextTermBegins;

	private XRTableCell lblNextTermEndsOn;

	private XRBarCode xrBarCode2;

	private XRTable xrTable7;

	private XRTableRow xrTableRow22;

	private XRTableCell xrTableCell49;

	private XRTableRow xrTableRow23;

	private XRTableCell xrTableCell50;

	private XRTableCell xrTableCell51;

	private XRTableRow xrTableRow24;

	private XRTableCell xrTableCell52;

	private XRTableCell xrTableCell55;

	private StudentsSourceDS studentsSourceDS1;

	private adapterStudentsDS adapterStudentsDS;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell53;

	private XRTableRow xrTableRow15;

	private XRTableCell lblFeesBalance;

	private XRTableCell lblFeesNextTerm;

	private XRLabel xrLabel1;

	private XRLabel lblOtherRequirements;

	private XRTable xrTable6;

	private XRTableRow xrTableRow19;

	private XRTableCell xrTableCell18;

	private XRTableRow xrTableRow20;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell29;

	private XRTableRow xrTableRow21;

	private XRTableCell xrTableCell42;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell45;

	private XRTableCell xrTableCell46;

	public MainReportNewCur2080(bool showUnAssessed, bool showClassRank, bool showStreamRank)
	{
		InitializeComponent();
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
		xrTableCell1 = new XRTableCell();
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
		xrTableRow5 = new XRTableRow();
		xrTableCell2 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTable5 = new XRTable();
		xrTableRow14 = new XRTableRow();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		lblSemester = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrLabel13 = new XRLabel();
		xrShape7 = new XRShape();
		footerKeysUsed = new GroupFooterBand();
		xrTable6 = new XRTable();
		xrTableRow19 = new XRTableRow();
		xrTableCell18 = new XRTableCell();
		xrTableRow20 = new XRTableRow();
		xrTableCell20 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableRow21 = new XRTableRow();
		xrTableCell42 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
		xrTableCell46 = new XRTableCell();
		xrTable7 = new XRTable();
		xrTableRow22 = new XRTableRow();
		xrTableCell49 = new XRTableCell();
		xrTableRow23 = new XRTableRow();
		xrTableCell50 = new XRTableCell();
		xrTableCell51 = new XRTableCell();
		xrTableRow24 = new XRTableRow();
		xrTableCell52 = new XRTableCell();
		xrTableCell55 = new XRTableCell();
		GroupFooter1 = new GroupFooterBand();
		xrLabel1 = new XRLabel();
		lblOtherRequirements = new XRLabel();
		tblFeesInfo = new XRTable();
		xrTableRow10 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell53 = new XRTableCell();
		xrTableRow15 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		lblFeesNextTerm = new XRTableCell();
		xrBarCode2 = new XRBarCode();
		tblTermBegins = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell17 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		lblNextTermEndsOn = new XRTableCell();
		studentsSourceDS1 = new StudentsSourceDS();
		adapterStudentsDS = new adapterStudentsDS();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
		((ISupportInitialize)xrTable6).BeginInit();
		((ISupportInitialize)xrTable7).BeginInit();
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
		xrSubreport2.LocationFloat = new PointFloat(0.9999116f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("studNumber", null, "dsMainReportNewCurr.StudentNumber"));
		xrSubreport2.ReportSource = new NewCurriculumSubUpper2080();
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
		PageHeader.Controls.AddRange(new XRControl[1] { xrSubreport1 });
		PageHeader.HeightF = 90.00001f;
		PageHeader.Name = "PageHeader";
		groupHeaderBand1.Controls.AddRange(new XRControl[6] { xrPictureBox1, xrTable1, xrTable3, xrTable5, xrLabel13, xrShape7 });
		groupHeaderBand1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		groupHeaderBand1.HeightF = 175f;
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
		xrPictureBox1.LocationFloat = new PointFloat(666.62f, 54f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(107f, 109f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrTable1.BorderColor = Color.MidnightBlue;
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(3.12f, 56f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable1.Rows.AddRange(new XRTableRow[2] { xrTableRow3, xrTableRow4 });
		xrTable1.SizeF = new SizeF(662.5f, 50f);
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UsePadding = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow3.Cells.AddRange(new XRTableCell[3] { xrTableCell1, lblNumberHeader, xrTableCell28 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell1.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.Text = "Name";
		xrTableCell1.Weight = 1.9975988453832167;
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
		lblName.Text = "xrTableCell17";
		lblName.Weight = 1.9975988453832167;
		lblName.WordWrap = false;
		lblName.PrintOnPage += lblName_PrintOnPage;
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
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell21.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrTableCell21.Multiline = true;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.Text = "xrTableCell21";
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 0.4907030562832473;
		xrTable3.BorderColor = Color.MidnightBlue;
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(3.125f, 113f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable3.Rows.AddRange(new XRTableRow[2] { xrTableRow12, xrTableRow5 });
		xrTable3.SizeF = new SizeF(340.875f, 49.99999f);
		xrTable3.StylePriority.UseBorderColor = false;
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
		xrTableRow5.Cells.AddRange(new XRTableCell[3] { xrTableCell2, xrTableCell30, xrTableCell31 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrTableCell2.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UsePadding = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "xrTableCell29";
		xrTableCell2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell2.Weight = 0.4846629834597481;
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
		xrTableCell30.Text = "xrTableCell30";
		xrTableCell30.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell30.Weight = 0.6783332443108346;
		xrTableCell31.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HouseId]")
		});
		xrTableCell31.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell31.Multiline = true;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.StylePriority.UseTextAlignment = false;
		xrTableCell31.Text = "xrTableCell31";
		xrTableCell31.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell31.Weight = 0.99154933081207;
		xrTable5.BorderColor = Color.MidnightBlue;
		xrTable5.Borders = BorderSide.All;
		xrTable5.LocationFloat = new PointFloat(344f, 113f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow14, xrTableRow6 });
		xrTable5.SizeF = new SizeF(321.625f, 49.99999f);
		xrTable5.StylePriority.UseBorderColor = false;
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
		xrTableRow6.Cells.AddRange(new XRTableCell[2] { lblSemester, xrTableCell4 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
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
		xrTableCell4.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryScores1]")
		});
		xrTableCell4.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UsePadding = false;
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.Text = "xrTableCell33";
		xrTableCell4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell4.Weight = 1.4468210236841679;
		xrLabel13.BackColor = Color.Transparent;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel13.ForeColor = Color.Black;
		xrLabel13.LocationFloat = new PointFloat(207.25f, 14f);
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
		xrShape7.LocationFloat = new PointFloat(193.75f, 7.5f);
		xrShape7.Name = "xrShape7";
		shapeRectangle.Fillet = 60;
		xrShape7.Shape = shapeRectangle;
		xrShape7.SizeF = new SizeF(390.4999f, 35.00001f);
		xrShape7.Stretch = true;
		footerKeysUsed.Controls.AddRange(new XRControl[2] { xrTable6, xrTable7 });
		footerKeysUsed.HeightF = 65f;
		footerKeysUsed.KeepTogether = true;
		footerKeysUsed.Name = "footerKeysUsed";
		footerKeysUsed.RepeatEveryPage = true;
		xrTable6.Borders = BorderSide.All;
		xrTable6.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable6.LocationFloat = new PointFloat(321.2278f, 0f);
		xrTable6.Name = "xrTable6";
		xrTable6.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable6.Rows.AddRange(new XRTableRow[3] { xrTableRow19, xrTableRow20, xrTableRow21 });
		xrTable6.SizeF = new SizeF(455f, 60f);
		xrTable6.StylePriority.UseBorders = false;
		xrTable6.StylePriority.UseFont = false;
		xrTable6.StylePriority.UseTextAlignment = false;
		xrTable6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow19.Cells.AddRange(new XRTableCell[1] { xrTableCell18 });
		xrTableRow19.Name = "xrTableRow19";
		xrTableRow19.Weight = 1.0;
		xrTableCell18.Font = new DXFont("Cascadia Mono", 9.75f, DXFontStyle.Bold);
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.Text = "GRADING SCALE";
		xrTableCell18.Weight = 8.0;
		xrTableRow20.Cells.AddRange(new XRTableCell[5] { xrTableCell20, xrTableCell25, xrTableCell26, xrTableCell27, xrTableCell29 });
		xrTableRow20.Name = "xrTableRow20";
		xrTableRow20.Weight = 1.0;
		xrTableCell20.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.Text = "A";
		xrTableCell20.Weight = 1.6;
		xrTableCell25.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.Text = "B";
		xrTableCell25.Weight = 1.5999999438011858;
		xrTableCell26.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell26.Multiline = true;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.Text = "C";
		xrTableCell26.Weight = 1.6000000285859124;
		xrTableCell27.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell27.Multiline = true;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.StylePriority.UseFont = false;
		xrTableCell27.Text = "D";
		xrTableCell27.Weight = 1.6000000637100829;
		xrTableCell29.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell29.Multiline = true;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.Text = "E";
		xrTableCell29.Weight = 1.5999999639028188;
		xrTableRow21.Cells.AddRange(new XRTableCell[5] { xrTableCell42, xrTableCell43, xrTableCell44, xrTableCell45, xrTableCell46 });
		xrTableRow21.Name = "xrTableRow21";
		xrTableRow21.Weight = 1.0;
		xrTableCell42.Multiline = true;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.Text = "80 - 100";
		xrTableCell42.Weight = 1.6;
		xrTableCell43.Multiline = true;
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.Text = "70 - 79";
		xrTableCell43.Weight = 1.5999999438011858;
		xrTableCell44.Multiline = true;
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.Text = "60 - 69";
		xrTableCell44.Weight = 1.6000000285859124;
		xrTableCell45.Multiline = true;
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.Text = "35 - 59";
		xrTableCell45.Weight = 1.6000000637100829;
		xrTableCell46.Multiline = true;
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.Text = "0 - 34";
		xrTableCell46.Weight = 1.5999999639028188;
		xrTable7.BorderColor = Color.Black;
		xrTable7.BorderDashStyle = BorderDashStyle.Solid;
		xrTable7.Borders = BorderSide.All;
		xrTable7.Font = new DXFont("Tahoma", 9f);
		xrTable7.ForeColor = Color.Black;
		xrTable7.LocationFloat = new PointFloat(0f, 0f);
		xrTable7.Name = "xrTable7";
		xrTable7.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable7.Rows.AddRange(new XRTableRow[3] { xrTableRow22, xrTableRow23, xrTableRow24 });
		xrTable7.SizeF = new SizeF(321.2278f, 60f);
		xrTable7.StylePriority.UseBorderColor = false;
		xrTable7.StylePriority.UseBorderDashStyle = false;
		xrTable7.StylePriority.UseBorders = false;
		xrTable7.StylePriority.UseFont = false;
		xrTable7.StylePriority.UseForeColor = false;
		xrTable7.StylePriority.UseTextAlignment = false;
		xrTable7.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow22.Cells.AddRange(new XRTableCell[1] { xrTableCell49 });
		xrTableRow22.Name = "xrTableRow22";
		xrTableRow22.Weight = 1.0;
		xrTableCell49.Borders = BorderSide.All;
		xrTableCell49.Font = new DXFont("Cascadia Code", 8.25f, DXFontStyle.Bold);
		xrTableCell49.Multiline = true;
		xrTableCell49.Name = "xrTableCell49";
		xrTableCell49.StylePriority.UseBorders = false;
		xrTableCell49.StylePriority.UseFont = false;
		xrTableCell49.StylePriority.UseTextAlignment = false;
		xrTableCell49.Text = "Key to Terms Used";
		xrTableCell49.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell49.Weight = 3.0;
		xrTableRow23.Cells.AddRange(new XRTableCell[2] { xrTableCell50, xrTableCell51 });
		xrTableRow23.Name = "xrTableRow23";
		xrTableRow23.Weight = 1.0;
		xrTableCell50.Borders = BorderSide.All;
		xrTableCell50.BorderWidth = 1f;
		xrTableCell50.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell50.Multiline = true;
		xrTableCell50.Name = "xrTableCell50";
		xrTableCell50.StylePriority.UseBorders = false;
		xrTableCell50.StylePriority.UseBorderWidth = false;
		xrTableCell50.StylePriority.UseFont = false;
		xrTableCell50.StylePriority.UseTextAlignment = false;
		xrTableCell50.Text = "AI";
		xrTableCell50.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell50.Weight = 0.5237483149675795;
		xrTableCell51.Borders = BorderSide.All;
		xrTableCell51.Font = new DXFont("Cascadia Mono", 9f);
		xrTableCell51.Multiline = true;
		xrTableCell51.Name = "xrTableCell51";
		xrTableCell51.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell51.StylePriority.UseBorders = false;
		xrTableCell51.StylePriority.UseFont = false;
		xrTableCell51.StylePriority.UsePadding = false;
		xrTableCell51.Text = "Average of Chapter Assessments";
		xrTableCell51.Weight = 2.47625168503242;
		xrTableRow24.Cells.AddRange(new XRTableCell[2] { xrTableCell52, xrTableCell55 });
		xrTableRow24.Name = "xrTableRow24";
		xrTableRow24.Weight = 1.0;
		xrTableCell52.BackColor = Color.Transparent;
		xrTableCell52.Borders = BorderSide.All;
		xrTableCell52.BorderWidth = 1f;
		xrTableCell52.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell52.Multiline = true;
		xrTableCell52.Name = "xrTableCell52";
		xrTableCell52.StylePriority.UseBackColor = false;
		xrTableCell52.StylePriority.UseBorders = false;
		xrTableCell52.StylePriority.UseBorderWidth = false;
		xrTableCell52.StylePriority.UseFont = false;
		xrTableCell52.StylePriority.UseTextAlignment = false;
		xrTableCell52.Text = "EOT";
		xrTableCell52.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell52.Weight = 0.5237483739577526;
		xrTableCell55.BackColor = Color.Transparent;
		xrTableCell55.Borders = BorderSide.All;
		xrTableCell55.Font = new DXFont("Cascadia Mono", 9f);
		xrTableCell55.Multiline = true;
		xrTableCell55.Name = "xrTableCell55";
		xrTableCell55.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell55.StylePriority.UseBackColor = false;
		xrTableCell55.StylePriority.UseBorders = false;
		xrTableCell55.StylePriority.UseFont = false;
		xrTableCell55.StylePriority.UsePadding = false;
		xrTableCell55.Text = "End of term assessment";
		xrTableCell55.Weight = 2.476251626042247;
		GroupFooter1.Controls.AddRange(new XRControl[5] { xrLabel1, lblOtherRequirements, tblFeesInfo, xrBarCode2, tblTermBegins });
		GroupFooter1.HeightF = 82f;
		GroupFooter1.Level = 1;
		GroupFooter1.Name = "GroupFooter1";
		GroupFooter1.PrintAtBottom = true;
		GroupFooter1.RepeatEveryPage = true;
		xrLabel1.Font = new DXFont("Consolas", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(3f, 59f);
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
		lblOtherRequirements.LocationFloat = new PointFloat(184.5f, 59f);
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
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow10, xrTableRow15 });
		tblFeesInfo.SizeF = new SizeF(309.6474f, 50f);
		tblFeesInfo.StylePriority.UseBorders = false;
		xrTableRow10.Cells.AddRange(new XRTableCell[2] { xrTableCell12, xrTableCell53 });
		xrTableRow10.Name = "xrTableRow10";
		xrTableRow10.Weight = 1.0;
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
		xrTableCell12.Text = "Fees Balance";
		xrTableCell12.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell12.Weight = 0.37753038223003454;
		xrTableCell53.BackColor = Color.Black;
		xrTableCell53.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell53.Borders = BorderSide.All;
		xrTableCell53.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell53.ForeColor = Color.White;
		xrTableCell53.Multiline = true;
		xrTableCell53.Name = "xrTableCell53";
		xrTableCell53.StylePriority.UseBackColor = false;
		xrTableCell53.StylePriority.UseBorderDashStyle = false;
		xrTableCell53.StylePriority.UseBorders = false;
		xrTableCell53.StylePriority.UseFont = false;
		xrTableCell53.StylePriority.UseForeColor = false;
		xrTableCell53.StylePriority.UseTextAlignment = false;
		xrTableCell53.Text = "Fees Next Term";
		xrTableCell53.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell53.Weight = 0.3775304025255647;
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
		xrBarCode2.LocationFloat = new PointFloat(652f, 0f);
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
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow2, xrTableRow9 });
		tblTermBegins.SizeF = new SizeF(300f, 50f);
		tblTermBegins.StylePriority.UseBorders = false;
		xrTableRow2.Cells.AddRange(new XRTableCell[2] { xrTableCell17, xrTableCell41 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell17.BackColor = Color.Black;
		xrTableCell17.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell17.Borders = BorderSide.All;
		xrTableCell17.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell17.ForeColor = Color.White;
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseBackColor = false;
		xrTableCell17.StylePriority.UseBorderDashStyle = false;
		xrTableCell17.StylePriority.UseBorders = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseForeColor = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "Next Term Begins";
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.5614441542693065;
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
		xrTableRow9.Cells.AddRange(new XRTableCell[2] { lblNextTermBegins, lblNextTermEndsOn });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
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
		base.Bands.AddRange(new Band[7] { Detail, topMarginBand1, bottomMarginBand1, PageHeader, groupHeaderBand1, footerKeysUsed, GroupFooter1 });
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
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)xrTable6).EndInit();
		((ISupportInitialize)xrTable7).EndInit();
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)studentsSourceDS1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
