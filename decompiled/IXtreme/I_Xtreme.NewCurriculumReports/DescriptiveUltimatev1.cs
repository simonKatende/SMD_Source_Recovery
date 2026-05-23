using System;
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

public class DescriptiveUltimatev1 : XtraReport
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

	private XRSubreport xrSubreport2;

	private GroupFooterBand footerLearningOutcomeScale;

	private XRLabel xrLabel13;

	private XRSubreport xrSubreport1;

	private GroupHeaderBand groupHeaderBand1;

	private XRLabel xrLabel9;

	private XRLabel lblStudentNumber2;

	private PageFooterBand PageFooter;

	private XRShape xrShape1;

	private XRTable tblFeesInfo;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell14;

	private XRTableRow xrTableRow11;

	private XRTableCell lblFeesBalance;

	private XRTableCell lblFeesNextTerm;

	private XRTableCell xrTableCell40;

	private XRTable tblTermBegins;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell41;

	private XRTableRow xrTableRow1;

	private XRTableCell lblNextTermBegins;

	private XRTableCell lblNextTermEndsOn;

	private XRBarCode xrBarCode2;

	private XRPictureBox xrPictureBox1;

	private XRTable xrTable2;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell24;

	private XRTableCell lblNumberHeader;

	private XRTableCell xrTableCell28;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell17;

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

	private XRTableRow xrTableRow13;

	private XRTableCell lblSemester;

	private XRTableCell xrTableCell33;

	private XRShape xrShape4;

	private XRLabel xrLabel2;

	private StudentsSourceDS studentsSourceDS1;

	private StudentsSourceDS studentsSourceDS2;

	private adapterStudentsDS adapterStudentsDS;

	private StudentsSourceDS studentsSourceDS3;

	private adapterStudentsDS adapterStudentsDS1;

	private StudentsSourceDS studentsSourceDS4;

	private adapterStudentsDS adapterStudentsDS2;

	private XRRichText xrRichText1;

	private SubBand SubBand2;

	private SubBand SubBand3;

	public DescriptiveUltimatev1()
	{
		InitializeComponent();
		lblSemester.Text = ReportParameters.Semester;
	}

	private void MainReportNCDescriptive_BeforePrint(object sender, CancelEventArgs e)
	{
		xrShape4.BorderColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrShape4.FillColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
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
		xrLabel13.Text = "END OF " + ReportParameters.Semester + " REPORT CARD";
		if (!ReportCustomization.ShowFeesBalance)
		{
			lblFeesBalance.ExpressionBindings.Clear();
		}
		SubBand2.Visible = ReportCustomization.ShowFeesBalance;
		if (!ReportCustomization.ShowFeesNextTerm)
		{
			lblFeesNextTerm.ExpressionBindings.Clear();
		}
		lblNextTermBegins.Text = ReportHeader.NextTermBeginsOn.ToString("dd-MMM-yyyy");
		if (ReportHeader.SelectedCode == 0)
		{
			lblNumberHeader.Text = "Student No.";
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]"));
			lblStudentNumber2.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]"));
		}
		else if (ReportHeader.SelectedCode == 1)
		{
			lblNumberHeader.Text = "Student ID";
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentID]"));
			lblStudentNumber2.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentID]"));
		}
		else if (ReportHeader.SelectedCode == 2)
		{
			lblNumberHeader.Text = "LIN";
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[LIN]"));
			lblStudentNumber2.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[LIN]"));
		}
	}

	private void xrTableCell17_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		string text = xrTableCell17.Text;
		((XRLabel)sender).Bookmark += text;
	}

	private void xrLabel2_AfterPrint(object sender, EventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DescriptiveUltimatev1));
		EAN13Generator symbology = new EAN13Generator();
		ShapeRectangle shapeRectangle = new ShapeRectangle();
		ShapePolygon shape = new ShapePolygon();
		Detail = new DetailBand();
		xrSubreport2 = new XRSubreport();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		semester = new Parameter();
		studentClass = new Parameter();
		footerLearningOutcomeScale = new GroupFooterBand();
		xrRichText1 = new XRRichText();
		SubBand2 = new SubBand();
		tblFeesInfo = new XRTable();
		xrTableRow7 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableRow11 = new XRTableRow();
		lblFeesBalance = new XRTableCell();
		lblFeesNextTerm = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		SubBand3 = new SubBand();
		xrBarCode2 = new XRBarCode();
		tblTermBegins = new XRTable();
		xrTableRow6 = new XRTableRow();
		xrTableCell2 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableRow1 = new XRTableRow();
		lblNextTermBegins = new XRTableCell();
		lblNextTermEndsOn = new XRTableCell();
		xrLabel13 = new XRLabel();
		xrSubreport1 = new XRSubreport();
		groupHeaderBand1 = new GroupHeaderBand();
		xrLabel2 = new XRLabel();
		xrShape4 = new XRShape();
		xrPictureBox1 = new XRPictureBox();
		xrTable2 = new XRTable();
		xrTableRow8 = new XRTableRow();
		xrTableCell24 = new XRTableCell();
		lblNumberHeader = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell17 = new XRTableCell();
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
		xrTableRow13 = new XRTableRow();
		lblSemester = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		lblStudentNumber2 = new XRLabel();
		xrLabel9 = new XRLabel();
		PageFooter = new PageFooterBand();
		xrShape1 = new XRShape();
		studentsSourceDS4 = new StudentsSourceDS();
		adapterStudentsDS2 = new adapterStudentsDS();
		((ISupportInitialize)xrRichText1).BeginInit();
		((ISupportInitialize)tblFeesInfo).BeginInit();
		((ISupportInitialize)tblTermBegins).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
		((ISupportInitialize)studentsSourceDS4).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrSubreport2 });
		Detail.HeightF = 32.57898f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrSubreport2.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.ParameterBindings.Add(new ParameterBinding("studentNo", null, "tbl_Stud.StudentNumber"));
		xrSubreport2.ReportSource = new DescriptiveUltimateReportSubv1();
		xrSubreport2.SizeF = new SizeF(778.9999f, 23f);
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
		topMarginBand1.HeightF = 23f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 23f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semester.Description = "Semester:";
		semester.Name = "semester";
		studentClass.Description = "Student Class:";
		studentClass.Name = "studentClass";
		footerLearningOutcomeScale.Controls.AddRange(new XRControl[1] { xrRichText1 });
		footerLearningOutcomeScale.HeightF = 292.7721f;
		footerLearningOutcomeScale.Name = "footerLearningOutcomeScale";
		footerLearningOutcomeScale.SubBands.AddRange(new SubBand[2] { SubBand2, SubBand3 });
		xrRichText1.CanGrow = false;
		xrRichText1.Font = new DXFont("Times New Roman", 9.75f);
		xrRichText1.LocationFloat = new PointFloat(1.5f, 0f);
		xrRichText1.Name = "xrRichText1";
		xrRichText1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrRichText1.SerializableRtfString = componentResourceManager.GetString("xrRichText1.SerializableRtfString");
		xrRichText1.SizeF = new SizeF(778.9999f, 281.5f);
		SubBand2.Controls.AddRange(new XRControl[1] { tblFeesInfo });
		SubBand2.HeightF = 55f;
		SubBand2.Name = "SubBand2";
		tblFeesInfo.Borders = BorderSide.All;
		tblFeesInfo.LocationFloat = new PointFloat(1.5f, 0f);
		tblFeesInfo.Name = "tblFeesInfo";
		tblFeesInfo.Rows.AddRange(new XRTableRow[2] { xrTableRow7, xrTableRow11 });
		tblFeesInfo.SizeF = new SizeF(778.9999f, 50f);
		tblFeesInfo.StylePriority.UseBorders = false;
		xrTableRow7.Cells.AddRange(new XRTableCell[3] { xrTableCell3, xrTableCell10, xrTableCell14 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell3.BackColor = Color.Black;
		xrTableCell3.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell3.Borders = BorderSide.All;
		xrTableCell3.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell3.ForeColor = Color.White;
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseBackColor = false;
		xrTableCell3.StylePriority.UseBorderDashStyle = false;
		xrTableCell3.StylePriority.UseBorders = false;
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseForeColor = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "Fees Balance";
		xrTableCell3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell3.Weight = 0.37753038223003454;
		xrTableCell10.BackColor = Color.Black;
		xrTableCell10.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell10.Borders = BorderSide.All;
		xrTableCell10.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell10.ForeColor = Color.White;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBackColor = false;
		xrTableCell10.StylePriority.UseBorderDashStyle = false;
		xrTableCell10.StylePriority.UseBorders = false;
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseForeColor = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "Fees Next Term";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.3775304025255647;
		xrTableCell14.BackColor = Color.Black;
		xrTableCell14.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell14.Borders = BorderSide.All;
		xrTableCell14.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell14.ForeColor = Color.White;
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseBackColor = false;
		xrTableCell14.StylePriority.UseBorderDashStyle = false;
		xrTableCell14.StylePriority.UseBorders = false;
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseForeColor = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.Text = "Other Requirements";
		xrTableCell14.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell14.Weight = 1.6863022817464408;
		xrTableRow11.Cells.AddRange(new XRTableCell[3] { lblFeesBalance, lblFeesNextTerm, xrTableCell40 });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
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
		xrTableCell40.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell40.Borders = BorderSide.All;
		xrTableCell40.CanGrow = false;
		xrTableCell40.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OtherRequirements]")
		});
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
		xrTableCell40.WordWrap = false;
		SubBand3.Controls.AddRange(new XRControl[2] { xrBarCode2, tblTermBegins });
		SubBand3.HeightF = 50f;
		SubBand3.Name = "SubBand3";
		xrBarCode2.AutoModule = true;
		xrBarCode2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode2.ForeColor = Color.DarkSlateBlue;
		xrBarCode2.LocationFloat = new PointFloat(655.9999f, 0f);
		xrBarCode2.Module = 1f;
		xrBarCode2.Name = "xrBarCode2";
		xrBarCode2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode2.SizeF = new SizeF(125f, 50f);
		xrBarCode2.StylePriority.UseForeColor = false;
		xrBarCode2.StylePriority.UsePadding = false;
		xrBarCode2.Symbology = symbology;
		tblTermBegins.Borders = BorderSide.All;
		tblTermBegins.LocationFloat = new PointFloat(1.999998f, 0f);
		tblTermBegins.Name = "tblTermBegins";
		tblTermBegins.Rows.AddRange(new XRTableRow[2] { xrTableRow6, xrTableRow1 });
		tblTermBegins.SizeF = new SizeF(300f, 50f);
		tblTermBegins.StylePriority.UseBorders = false;
		xrTableRow6.Cells.AddRange(new XRTableCell[2] { xrTableCell2, xrTableCell41 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell2.BackColor = Color.Black;
		xrTableCell2.BorderDashStyle = BorderDashStyle.Solid;
		xrTableCell2.Borders = BorderSide.All;
		xrTableCell2.Font = new DXFont("Cascadia Code", 9.75f, DXFontStyle.Bold);
		xrTableCell2.ForeColor = Color.White;
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseBackColor = false;
		xrTableCell2.StylePriority.UseBorderDashStyle = false;
		xrTableCell2.StylePriority.UseBorders = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseForeColor = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "Next Term Begins";
		xrTableCell2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell2.Weight = 0.5614441542693065;
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
		xrTableRow1.Cells.AddRange(new XRTableCell[2] { lblNextTermBegins, lblNextTermEndsOn });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
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
		xrLabel13.BackColor = Color.Transparent;
		xrLabel13.CanGrow = false;
		xrLabel13.Font = new DXFont("SimSun-ExtB", 12f, DXFontStyle.Bold);
		xrLabel13.ForeColor = Color.Black;
		xrLabel13.LocationFloat = new PointFloat(207.5f, 106.5f);
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
		xrSubreport1.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.SizeF = new SizeF(778.9999f, 90.00001f);
		groupHeaderBand1.Controls.AddRange(new XRControl[8] { xrLabel2, xrShape4, xrPictureBox1, xrTable2, xrTable3, xrTable5, xrSubreport1, xrLabel13 });
		groupHeaderBand1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		groupHeaderBand1.HeightF = 264.0416f;
		groupHeaderBand1.KeepTogether = true;
		groupHeaderBand1.Name = "groupHeaderBand1";
		groupHeaderBand1.PageBreak = PageBreak.BeforeBandExceptFirstEntry;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrLabel2.LocationFloat = new PointFloat(10.00001f, 106.5f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(100f, 23f);
		xrLabel2.Text = "xrLabel2";
		xrLabel2.Visible = false;
		xrLabel2.AfterPrint += xrLabel2_AfterPrint;
		xrShape4.LineWidth = 3;
		xrShape4.LocationFloat = new PointFloat(194.25f, 100f);
		xrShape4.Name = "xrShape4";
		shapeRectangle.Fillet = 60;
		xrShape4.Shape = shapeRectangle;
		xrShape4.SizeF = new SizeF(390.4999f, 35.00001f);
		xrShape4.Stretch = true;
		xrPictureBox1.BorderColor = Color.Gainsboro;
		xrPictureBox1.Borders = BorderSide.All;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(667f, 141.5f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(107f, 109f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrTable2.BorderColor = Color.MidnightBlue;
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(3.5f, 143.5f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow8, xrTableRow2 });
		xrTable2.SizeF = new SizeF(662.5f, 50f);
		xrTable2.StylePriority.UseBorderColor = false;
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
		xrTableRow2.Cells.AddRange(new XRTableCell[3] { xrTableCell17, lblStudentNumber, xrTableCell21 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell17.CanShrink = true;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrTableCell17.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.Text = "xrTableCell17";
		xrTableCell17.Weight = 1.9975988453832167;
		xrTableCell17.WordWrap = false;
		xrTableCell17.PrintOnPage += xrTableCell17_PrintOnPage;
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
		xrTable3.LocationFloat = new PointFloat(3.500002f, 200.5f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable3.Rows.AddRange(new XRTableRow[2] { xrTableRow12, xrTableRow9 });
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
		xrTableRow9.Cells.AddRange(new XRTableCell[3] { xrTableCell29, xrTableCell30, xrTableCell31 });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		xrTableCell29.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrTableCell29.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell29.Multiline = true;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.StylePriority.UsePadding = false;
		xrTableCell29.StylePriority.UseTextAlignment = false;
		xrTableCell29.Text = "xrTableCell29";
		xrTableCell29.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell29.Weight = 0.4846629834597481;
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
		xrTable5.LocationFloat = new PointFloat(344.375f, 200.5f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow14, xrTableRow13 });
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
		xrTableRow13.Cells.AddRange(new XRTableCell[2] { lblSemester, xrTableCell33 });
		xrTableRow13.Name = "xrTableRow13";
		xrTableRow13.Weight = 1.0;
		lblSemester.CanGrow = false;
		lblSemester.Font = new DXFont("Tahoma", 8.5f, DXFontStyle.Bold);
		lblSemester.Name = "lblSemester";
		lblSemester.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblSemester.StylePriority.UseFont = false;
		lblSemester.StylePriority.UsePadding = false;
		lblSemester.StylePriority.UseTextAlignment = false;
		lblSemester.Text = "lblSemester";
		lblSemester.TextAlignment = TextAlignment.MiddleCenter;
		lblSemester.Weight = 0.655303159322368;
		lblSemester.WordWrap = false;
		xrTableCell33.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PrimaryScores1]")
		});
		xrTableCell33.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell33.Multiline = true;
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.StylePriority.UsePadding = false;
		xrTableCell33.StylePriority.UseTextAlignment = false;
		xrTableCell33.Text = "xrTableCell33";
		xrTableCell33.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell33.Weight = 1.4468210236841679;
		lblStudentNumber2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		lblStudentNumber2.Font = new DXFont("Cascadia Code", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblStudentNumber2.LocationFloat = new PointFloat(600f, 5.500031f);
		lblStudentNumber2.Multiline = true;
		lblStudentNumber2.Name = "lblStudentNumber2";
		lblStudentNumber2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblStudentNumber2.SizeF = new SizeF(178f, 23f);
		lblStudentNumber2.StylePriority.UseFont = false;
		lblStudentNumber2.StylePriority.UseTextAlignment = false;
		lblStudentNumber2.Text = "lblStudentNumber2";
		lblStudentNumber2.TextAlignment = TextAlignment.MiddleRight;
		xrLabel9.CanGrow = false;
		xrLabel9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel9.Font = new DXFont("Cascadia Code", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel9.LocationFloat = new PointFloat(28.5f, 5.500031f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(403f, 23f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "xrLabel9";
		xrLabel9.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel9.WordWrap = false;
		PageFooter.Controls.AddRange(new XRControl[3] { xrShape1, lblStudentNumber2, xrLabel9 });
		PageFooter.HeightF = 35.16229f;
		PageFooter.Name = "PageFooter";
		xrShape1.Angle = 270;
		xrShape1.FillColor = Color.DimGray;
		xrShape1.LocationFloat = new PointFloat(0f, 5.500031f);
		xrShape1.Name = "xrShape1";
		xrShape1.Shape = shape;
		xrShape1.SizeF = new SizeF(21.99999f, 23f);
		studentsSourceDS4.DataSetName = "StudentsSourceDS";
		studentsSourceDS4.EnforceConstraints = false;
		studentsSourceDS4.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterStudentsDS2.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[6] { Detail, topMarginBand1, bottomMarginBand1, groupHeaderBand1, footerLearningOutcomeScale, PageFooter });
		base.ComponentStorage.AddRange(new IComponent[1] { studentsSourceDS4 });
		base.DataAdapter = adapterStudentsDS2;
		base.DataMember = "StudentsDS";
		base.DataSource = studentsSourceDS4;
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "23.1";
		BeforePrint += MainReportNCDescriptive_BeforePrint;
		((ISupportInitialize)xrRichText1).EndInit();
		((ISupportInitialize)tblFeesInfo).EndInit();
		((ISupportInitialize)tblTermBegins).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)studentsSourceDS4).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
