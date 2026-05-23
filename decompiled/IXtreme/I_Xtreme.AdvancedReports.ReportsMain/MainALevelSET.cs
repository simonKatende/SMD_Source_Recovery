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

public class MainALevelSET : XtraReport
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

	private XRLabel xrLabel25;

	private CalculatedField TotalPoints;

	private XRSubreport xrSubreport1;

	private XRSubreport xrSubreport3;

	private GroupFooterBand GroupFooter4;

	private GroupHeaderBand GroupHeader1;

	private ALevelMainReport aLevelMainReport1;

	private adapterALevelReportMain adapterALevelReportMain;

	private XRSubreport xrSubreport2;

	private Parameter termOfStudy;

	private XRPictureBox xrPictureBox3;

	private XRTable xrTable2;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell24;

	private XRTableCell lblNumberHeader;

	private XRTableCell xrTableCell28;

	private XRTableRow xrTableRow2;

	private XRTableCell lblName;

	private XRTableCell lblStudentNumber;

	private XRTableCell xrTableCell1;

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

	private XRTableRow xrTableRow13;

	private XRTableCell lblSemester;

	private XRTableCell xrTableCell33;

	private GroupFooterBand GroupFooter3;

	private GroupFooterBand GroupFooter5;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableRow xrTableRow11;

	private XRTableCell lblFeesBalance;

	private XRTableCell lblFeesNextTerm;

	private XRTableCell xrTableCell40;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell41;

	private XRTableRow xrTableRow4;

	private XRTableCell lblNextTermBegins;

	private XRTableCell lblNextTermEndsOn;

	private XRBarCode xrBarCode2;

	private CalculatedField FeesNextTerm;

	private adapterALevelReportMain adapterALevelReportMain1;

	private ALevelMainReport aLevelMainReport2;

	public MainALevelSET()
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
		xrSubreport1.Visible = ReportCustomization.ShowHeader;
		xrLabel25.BackColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrLabel25.ForeColor = Color.FromArgb((int)ReportColors.ReportForeColor);
		xrLabel25.Text = ReportHeader.HeaderString;
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
		if (!ReportCustomization.ShowFeesBalance)
		{
			lblFeesBalance.ExpressionBindings.Clear();
		}
		if (!ReportCustomization.ShowFeesNextTerm)
		{
			lblFeesNextTerm.ExpressionBindings.Clear();
		}
		xrLabel25.Text = ReportHeader.HeaderString;
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
		EAN13Generator symbology = new EAN13Generator();
		Detail = new DetailBand();
		xrSubreport2 = new XRSubreport();
		termOfStudy = new Parameter();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		xrSubreport1 = new XRSubreport();
		xrLabel25 = new XRLabel();
		xrSubreport3 = new XRSubreport();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		semesters = new Parameter();
		classes = new Parameter();
		TotalPoints = new CalculatedField();
		GroupFooter4 = new GroupFooterBand();
		GroupHeader1 = new GroupHeaderBand();
		xrPictureBox3 = new XRPictureBox();
		xrTable2 = new XRTable();
		xrTableRow8 = new XRTableRow();
		xrTableCell24 = new XRTableCell();
		lblNumberHeader = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		lblName = new XRTableCell();
		lblStudentNumber = new XRTableCell();
		xrTableCell1 = new XRTableCell();
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
		xrTableRow13 = new XRTableRow();
		lblSemester = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		GroupFooter3 = new GroupFooterBand();
		tblFeesInfo = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableRow11 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		lblFeesNextTerm = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		GroupFooter5 = new GroupFooterBand();
		xrBarCode2 = new XRBarCode();
		tblTermBegins = new XRTable();
		xrTableRow3 = new XRTableRow();
		xrTableCell20 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableRow4 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		lblNextTermEndsOn = new XRTableCell();
		FeesNextTerm = new CalculatedField();
		adapterALevelReportMain1 = new adapterALevelReportMain();
		aLevelMainReport2 = new ALevelMainReport();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)aLevelMainReport2).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrSubreport2 });
		Detail.HeightF = 52.02777f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrSubreport2.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("StudentNo", null, "ALevelReportMain.StudentNumber"));
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("classId", null, "ALevelReportMain.ClassId"));
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("cashOnAccount", null, "ALevelReportMain.cashOnAccount"));
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("term", termOfStudy));
		xrSubreport2.ReportSource = new ALevelSub();
		xrSubreport2.SizeF = new SizeF(779.9999f, 41.00001f);
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
		xrSubreport1.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.SizeF = new SizeF(780f, 87f);
		xrLabel25.BackColor = Color.SteelBlue;
		xrLabel25.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel25.ForeColor = Color.Black;
		xrLabel25.LocationFloat = new PointFloat(0f, 92.99998f);
		xrLabel25.Name = "xrLabel25";
		xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel25.SizeF = new SizeF(780f, 23f);
		xrLabel25.StylePriority.UseBackColor = false;
		xrLabel25.StylePriority.UseFont = false;
		xrLabel25.StylePriority.UseForeColor = false;
		xrLabel25.StylePriority.UseTextAlignment = false;
		xrLabel25.Text = "xrLabel25";
		xrLabel25.TextAlignment = TextAlignment.MiddleCenter;
		xrSubreport3.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport3.Name = "xrSubreport3";
		xrSubreport3.ReportSource = new ALevelGrading_Footer_Subjects();
		xrSubreport3.SizeF = new SizeF(780f, 65f);
		topMarginBand1.HeightF = 23f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 23f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semesters.Description = "Semester";
		semesters.Name = "semesters";
		classes.Description = "Class";
		classes.Name = "classes";
		TotalPoints.DataMember = "ALevelReport_With_Picture";
		TotalPoints.FieldType = FieldType.Double;
		TotalPoints.Name = "TotalPoints";
		GroupFooter4.Controls.AddRange(new XRControl[1] { xrSubreport3 });
		GroupFooter4.HeightF = 73.33331f;
		GroupFooter4.KeepTogether = true;
		GroupFooter4.Level = 1;
		GroupFooter4.Name = "GroupFooter4";
		GroupFooter4.PrintAtBottom = true;
		GroupFooter4.RepeatEveryPage = true;
		GroupHeader1.Controls.AddRange(new XRControl[6] { xrPictureBox3, xrTable2, xrTable3, xrTable5, xrLabel25, xrSubreport1 });
		GroupHeader1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		GroupHeader1.HeightF = 246.486f;
		GroupHeader1.Name = "GroupHeader1";
		GroupHeader1.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
		xrPictureBox3.BorderColor = Color.Gainsboro;
		xrPictureBox3.Borders = BorderSide.All;
		xrPictureBox3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox3.LocationFloat = new PointFloat(669.5001f, 123f);
		xrPictureBox3.Name = "xrPictureBox3";
		xrPictureBox3.SizeF = new SizeF(107f, 109f);
		xrPictureBox3.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox3.StylePriority.UseBorderColor = false;
		xrPictureBox3.StylePriority.UseBorders = false;
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(6.000002f, 125f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow8, xrTableRow2 });
		xrTable2.SizeF = new SizeF(662.5f, 50f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UsePadding = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow8.Cells.AddRange(new XRTableCell[3] { xrTableCell24, lblNumberHeader, xrTableCell28 });
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell24.Font = new DXFont("Cascadia Mono", 10f);
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.StylePriority.UsePadding = false;
		xrTableCell24.Text = "Name";
		xrTableCell24.Weight = 1.9975988453832167;
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
		xrTableRow2.Cells.AddRange(new XRTableCell[3] { lblName, lblStudentNumber, xrTableCell1 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		lblName.CanGrow = false;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		lblName.Name = "lblName";
		lblName.StylePriority.UseFont = false;
		lblName.Text = "lblName";
		lblName.Weight = 1.9975988453832167;
		lblName.WordWrap = false;
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
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Sex]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.Text = "xrTableCell21";
		xrTableCell1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell1.Weight = 0.4907030562832473;
		xrTableCell1.WordWrap = false;
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(6.000002f, 182f);
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
		xrTableCell36.Text = "Combination";
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
		xrTableCell30.CanGrow = false;
		xrTableCell30.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrTableCell30.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.StylePriority.UsePadding = false;
		xrTableCell30.StylePriority.UseTextAlignment = false;
		xrTableCell30.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell30.Weight = 0.6783332443108346;
		xrTableCell30.WordWrap = false;
		xrTableCell31.CanGrow = false;
		xrTableCell31.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Comb]")
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
		xrTable5.LocationFloat = new PointFloat(346.875f, 182f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow14, xrTableRow13 });
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
		xrTableCell38.Text = "UCE Results";
		xrTableCell38.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell38.Weight = 1.4468210236841679;
		xrTableRow13.Cells.AddRange(new XRTableCell[2] { lblSemester, xrTableCell33 });
		xrTableRow13.Name = "xrTableRow13";
		xrTableRow13.Weight = 1.0;
		lblSemester.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		lblSemester.Multiline = true;
		lblSemester.Name = "lblSemester";
		lblSemester.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblSemester.StylePriority.UseFont = false;
		lblSemester.StylePriority.UsePadding = false;
		lblSemester.StylePriority.UseTextAlignment = false;
		lblSemester.TextAlignment = TextAlignment.MiddleCenter;
		lblSemester.Weight = 0.655303159322368;
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
		xrTableCell33.Text = "xrTableCell33";
		xrTableCell33.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell33.Weight = 1.4468210236841679;
		xrTableCell33.WordWrap = false;
		GroupFooter3.Controls.AddRange(new XRControl[1] { tblFeesInfo });
		GroupFooter3.HeightF = 55f;
		GroupFooter3.Level = 2;
		GroupFooter3.Name = "GroupFooter3";
		GroupFooter3.PrintAtBottom = true;
		GroupFooter3.RepeatEveryPage = true;
		tblFeesInfo.Borders = BorderSide.All;
		tblFeesInfo.LocationFloat = new PointFloat(0f, 0f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow11 });
		tblFeesInfo.SizeF = new SizeF(780f, 50f);
		tblFeesInfo.StylePriority.UseBorders = false;
		xrTableRow1.Cells.AddRange(new XRTableCell[3] { xrTableCell16, xrTableCell18, xrTableCell19 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell16.BackColor = Color.Black;
		xrTableCell16.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell16.Borders = BorderSide.All;
		xrTableCell16.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell16.ForeColor = Color.White;
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseBackColor = false;
		xrTableCell16.StylePriority.UseBorderDashStyle = false;
		xrTableCell16.StylePriority.UseBorders = false;
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseForeColor = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "Fees Balance";
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.Weight = 0.37753038223003454;
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
		xrTableCell18.Text = "Fees Next Term";
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 0.3775304025255647;
		xrTableCell19.BackColor = Color.Black;
		xrTableCell19.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell19.Borders = BorderSide.All;
		xrTableCell19.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell19.ForeColor = Color.White;
		xrTableCell19.Multiline = true;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseBackColor = false;
		xrTableCell19.StylePriority.UseBorderDashStyle = false;
		xrTableCell19.StylePriority.UseBorders = false;
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.StylePriority.UseForeColor = false;
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.Text = "Other Requirements";
		xrTableCell19.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell19.Weight = 1.6863022817464408;
		xrTableRow11.Cells.AddRange(new XRTableCell[3] { lblFeesBalance, lblFeesNextTerm, xrTableCell40 });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		lblFeesBalance.BorderDashStyle = BorderDashStyle.Solid;
		lblFeesBalance.Borders = BorderSide.All;
		lblFeesBalance.CanGrow = false;
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
		lblFeesBalance.WordWrap = false;
		lblFeesNextTerm.BorderDashStyle = BorderDashStyle.Solid;
		lblFeesNextTerm.Borders = BorderSide.All;
		lblFeesNextTerm.CanGrow = false;
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
		lblFeesNextTerm.WordWrap = false;
		xrTableCell40.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell40.Borders = BorderSide.All;
		xrTableCell40.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.StylePriority.UseBorderDashStyle = false;
		xrTableCell40.StylePriority.UseBorders = false;
		xrTableCell40.StylePriority.UseFont = false;
		xrTableCell40.StylePriority.UseTextAlignment = false;
		xrTableCell40.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell40.Weight = 1.6863022817464408;
		GroupFooter5.Controls.AddRange(new XRControl[2] { xrBarCode2, tblTermBegins });
		GroupFooter5.HeightF = 50f;
		GroupFooter5.Level = 3;
		GroupFooter5.Name = "GroupFooter5";
		GroupFooter5.PrintAtBottom = true;
		GroupFooter5.RepeatEveryPage = true;
		xrBarCode2.AutoModule = true;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.ForeColor = Color.DarkSlateBlue;
		xrBarCode2.LocationFloat = new PointFloat(650f, 0f);
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
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow3, xrTableRow4 });
		tblTermBegins.SizeF = new SizeF(300f, 50f);
		tblTermBegins.StylePriority.UseBorders = false;
		xrTableRow3.Cells.AddRange(new XRTableCell[2] { xrTableCell20, xrTableCell41 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell20.BackColor = Color.Black;
		xrTableCell20.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell20.Borders = BorderSide.All;
		xrTableCell20.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell20.ForeColor = Color.White;
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseBackColor = false;
		xrTableCell20.StylePriority.UseBorderDashStyle = false;
		xrTableCell20.StylePriority.UseBorders = false;
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.StylePriority.UseForeColor = false;
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "Next Term Begins";
		xrTableCell20.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell20.Weight = 0.5614441542693065;
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
		xrTableRow4.Cells.AddRange(new XRTableCell[2] { lblNextTermBegins, lblNextTermEndsOn });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
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
		FeesNextTerm.DataMember = "ALevelReportMain";
		FeesNextTerm.Expression = "[RequiredFees]-[FeesDiscount]";
		FeesNextTerm.Name = "FeesNextTerm";
		adapterALevelReportMain1.ClearBeforeFill = true;
		aLevelMainReport2.DataSetName = "ALevelMainReport";
		aLevelMainReport2.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		base.Bands.AddRange(new Band[7] { Detail, topMarginBand1, bottomMarginBand1, GroupFooter4, GroupHeader1, GroupFooter3, GroupFooter5 });
		Bookmark = "Students in stream";
		base.CalculatedFields.AddRange(new CalculatedField[2] { TotalPoints, FeesNextTerm });
		base.ComponentStorage.AddRange(new IComponent[1] { aLevelMainReport2 });
		base.DataAdapter = adapterALevelReportMain1;
		base.DataMember = "ALevelReportMain";
		base.DataSource = aLevelMainReport2;
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.Parameters.AddRange(new Parameter[1] { termOfStudy });
		base.ReportPrintOptions.PrintOnEmptyDataSource = false;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "23.2";
		FillEmptySpace += MainALevelSET_FillEmptySpace;
		BeforePrint += S_5_Report_BeforePrint;
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)aLevelMainReport2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
