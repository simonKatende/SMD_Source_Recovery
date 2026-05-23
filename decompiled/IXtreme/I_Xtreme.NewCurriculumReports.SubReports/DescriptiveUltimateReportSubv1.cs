using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.NewCurriculumReports.ReportDatasets;
using I_Xtreme.NewCurriculumReports.ReportDatasets.DescriptiveUltimateReportTableAdapters;

namespace I_Xtreme.NewCurriculumReports.SubReports;

public class DescriptiveUltimateReportSubv1 : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRControlStyle TitleStyle;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell5;

	private XRTableRow xrTableRow2;

	private XRTable xrTable2;

	private GroupHeaderBand GroupHeader1;

	private Parameter studentNo;

	private XRLine xrLine1;

	private GroupFooterBand GroupFooter1;

	private XRLine xrLine2;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell15;

	private DescriptiveUltimateReport descriptiveUltimateReport1;

	private adapterDescriptiveUltimateReport adapterDescriptiveUltimateReport;

	private GroupFooterBand footerClassTeacher;

	private XRShape xrShape3;

	private XRLabel xrLabel17;

	private XRLabel lblClassteacherComment;

	private XRLabel xrLabel1;

	private XRShape xrShape2;

	private GroupFooterBand footerHeadTeacher;

	private XRLabel lblHeadteacherComment;

	private XRLabel xrLabel19;

	private XRLabel xrLabel15;

	private XRShape xrShape5;

	private XRShape xrShape6;

	private GroupFooterBand GroupFooter3;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell37;

	public DescriptiveUltimateReportSubv1()
	{
		InitializeComponent();
		footerClassTeacher.Visible = ReportCustomization.Comment1;
		footerHeadTeacher.Visible = ReportCustomization.Comment2;
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
		ShapeLine shape = new ShapeLine();
		ShapeRectangle shape2 = new ShapeRectangle();
		ShapeLine shape3 = new ShapeLine();
		ShapeRectangle shape4 = new ShapeRectangle();
		XRSummary xRSummary = new XRSummary();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		TitleStyle = new XRControlStyle();
		xrTableCell13 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell15 = new XRTableCell();
		xrTable2 = new XRTable();
		GroupHeader1 = new GroupHeaderBand();
		xrLine1 = new XRLine();
		studentNo = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrLine2 = new XRLine();
		descriptiveUltimateReport1 = new DescriptiveUltimateReport();
		adapterDescriptiveUltimateReport = new adapterDescriptiveUltimateReport();
		footerClassTeacher = new GroupFooterBand();
		xrLabel17 = new XRLabel();
		lblClassteacherComment = new XRLabel();
		xrLabel1 = new XRLabel();
		xrShape2 = new XRShape();
		xrShape3 = new XRShape();
		footerHeadTeacher = new GroupFooterBand();
		lblHeadteacherComment = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrShape5 = new XRShape();
		xrShape6 = new XRShape();
		GroupFooter3 = new GroupFooterBand();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)descriptiveUltimateReport1).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		xrTable1.BorderColor = Color.MidnightBlue;
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(781f, 25f);
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTableRow1.Cells.AddRange(new XRTableCell[6] { xrTableCell1, xrTableCell2, xrTableCell3, xrTableCell6, xrTableCell16, xrTableCell7 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.CanGrow = false;
		xrTableCell1.CanShrink = true;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Arial Narrow", 9f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell1.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 2.0450049128467445;
		xrTableCell1.WordWrap = false;
		xrTableCell2.CanShrink = true;
		xrTableCell2.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Font.Bold", "[Topic]"),
			new ExpressionBinding("BeforePrint", "Text", "Concat(Concat([Topic],NewLine() ),[Competence] )")
		});
		xrTableCell2.Font = new DXFont("Arial Narrow", 10f);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell2.Weight = 4.090009807555285;
		xrTableCell3.CanGrow = false;
		xrTableCell3.CanShrink = true;
		xrTableCell3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[LO]")
		});
		xrTableCell3.Font = new DXFont("Arial Narrow", 9f);
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "xrTableCell3";
		xrTableCell3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell3.Weight = 0.4908011739095139;
		xrTableCell6.CanGrow = false;
		xrTableCell6.CanShrink = true;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "[Descriptor]")
		});
		xrTableCell6.Font = new DXFont("Arial Narrow", 9f);
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell6.Weight = 0.8589020424985931;
		xrTableCell16.CanShrink = true;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "[GenGenericSkill]")
		});
		xrTableCell16.Font = new DXFont("Arial Narrow", 9f);
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell16.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Tag = "SubjectId";
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 1.5405703129436192;
		xrTableCell7.CanShrink = true;
		xrTableCell7.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "Concat(Concat([TeacherRemarksDesc],Concat(NewLine(),NewLine() ) ), [Initial])")
		});
		xrTableCell7.Font = new DXFont("Arial Narrow", 9f);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell7.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Tag = "SubjectId";
		xrTableCell7.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell7.Weight = 1.6223704185948506;
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 0f;
		BottomMargin.Name = "BottomMargin";
		TitleStyle.Font = new DXFont("Arial", 18f);
		TitleStyle.Name = "TitleStyle";
		TitleStyle.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell13.BackColor = Color.AliceBlue;
		xrTableCell13.Font = new DXFont("Arial Narrow", 9.75f, DXFontStyle.Bold);
		xrTableCell13.ForeColor = Color.DarkBlue;
		xrTableCell13.Multiline = true;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell13.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell13.StylePriority.UseBackColor = false;
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.StylePriority.UseForeColor = false;
		xrTableCell13.StylePriority.UseTextAlignment = false;
		xrTableCell13.Tag = "SubjectId";
		xrTableCell13.Text = "FACILITATOR REMARKS";
		xrTableCell13.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell13.Weight = 1.6223707682676958;
		xrTableCell12.BackColor = Color.AliceBlue;
		xrTableCell12.CanGrow = false;
		xrTableCell12.Font = new DXFont("Arial Narrow", 9.75f, DXFontStyle.Bold);
		xrTableCell12.ForeColor = Color.DarkBlue;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell12.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell12.StylePriority.UseBackColor = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UseForeColor = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.Text = "Descriptor";
		xrTableCell12.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell12.Weight = 0.8589020721243562;
		xrTableCell12.WordWrap = false;
		xrTableCell10.BackColor = Color.AliceBlue;
		xrTableCell10.CanShrink = true;
		xrTableCell10.Font = new DXFont("Arial Narrow", 9.75f, DXFontStyle.Bold);
		xrTableCell10.ForeColor = Color.DarkBlue;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBackColor = false;
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseForeColor = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "CBC Score";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.49080121190073733;
		xrTableCell9.BackColor = Color.AliceBlue;
		xrTableCell9.CanGrow = false;
		xrTableCell9.Font = new DXFont("Arial Narrow", 9f, DXFontStyle.Bold);
		xrTableCell9.ForeColor = Color.DarkBlue;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseBackColor = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseForeColor = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.Text = "CHAPTER  \r\nCOMPETENCY";
		xrTableCell9.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell9.Weight = 4.090009986202299;
		xrTableCell5.BackColor = Color.AliceBlue;
		xrTableCell5.CanGrow = false;
		xrTableCell5.Font = new DXFont("Arial Narrow", 9.75f, DXFontStyle.Bold);
		xrTableCell5.ForeColor = Color.DarkBlue;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell5.StylePriority.UseBackColor = false;
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.StylePriority.UseForeColor = false;
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "SUBJECT";
		xrTableCell5.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell5.Weight = 2.045004992679663;
		xrTableCell5.WordWrap = false;
		xrTableRow2.Cells.AddRange(new XRTableCell[6] { xrTableCell5, xrTableCell9, xrTableCell10, xrTableCell12, xrTableCell15, xrTableCell13 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell15.BackColor = Color.AliceBlue;
		xrTableCell15.Font = new DXFont("Arial Narrow", 9.75f, DXFontStyle.Bold);
		xrTableCell15.ForeColor = Color.DarkBlue;
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBackColor = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.StylePriority.UseForeColor = false;
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "GENERIC SKILLS";
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 1.540570237405764;
		xrTable2.BorderColor = Color.MidnightBlue;
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTable2.ForeColor = Color.White;
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(781f, 50f);
		xrTable2.StylePriority.UseBorderColor = false;
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseForeColor = false;
		GroupHeader1.Controls.AddRange(new XRControl[2] { xrLine1, xrTable2 });
		GroupHeader1.HeightF = 52.08333f;
		GroupHeader1.Name = "GroupHeader1";
		xrLine1.BorderColor = Color.MidnightBlue;
		xrLine1.ForeColor = Color.MidnightBlue;
		xrLine1.LineWidth = 2f;
		xrLine1.LocationFloat = new PointFloat(0f, 50f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(781f, 2.083333f);
		xrLine1.StylePriority.UseBorderColor = false;
		xrLine1.StylePriority.UseForeColor = false;
		studentNo.Description = "StudentNo";
		studentNo.Name = "studentNo";
		studentNo.Visible = false;
		GroupFooter1.Controls.AddRange(new XRControl[1] { xrLine2 });
		GroupFooter1.HeightF = 2.083333f;
		GroupFooter1.Name = "GroupFooter1";
		xrLine2.BorderColor = Color.MidnightBlue;
		xrLine2.ForeColor = Color.MidnightBlue;
		xrLine2.LineWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(0f, 0f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(781f, 2.083333f);
		xrLine2.StylePriority.UseBorderColor = false;
		xrLine2.StylePriority.UseForeColor = false;
		descriptiveUltimateReport1.DataSetName = "DescriptiveUltimateReport";
		descriptiveUltimateReport1.EnforceConstraints = false;
		descriptiveUltimateReport1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterDescriptiveUltimateReport.ClearBeforeFill = true;
		footerClassTeacher.Controls.AddRange(new XRControl[5] { xrLabel17, lblClassteacherComment, xrLabel1, xrShape2, xrShape3 });
		footerClassTeacher.HeightF = 74f;
		footerClassTeacher.Level = 2;
		footerClassTeacher.Name = "footerClassTeacher";
		xrLabel17.BackColor = Color.Transparent;
		xrLabel17.BorderColor = Color.Black;
		xrLabel17.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.CanGrow = false;
		xrLabel17.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrLabel17.ForeColor = Color.Black;
		xrLabel17.LocationFloat = new PointFloat(7.000019f, 12.99998f);
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
		xrLabel17.Text = "Classteacher Remarks:";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.WordWrap = false;
		lblClassteacherComment.BorderColor = Color.Black;
		lblClassteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblClassteacherComment.Borders = BorderSide.None;
		lblClassteacherComment.CanGrow = false;
		lblClassteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassteacherRemark]")
		});
		lblClassteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblClassteacherComment.ForeColor = Color.Black;
		lblClassteacherComment.LocationFloat = new PointFloat(7.000008f, 36.5f);
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
		xrLabel1.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel1.LocationFloat = new PointFloat(621f, 11.99999f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(100f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Signature";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		xrShape2.LocationFloat = new PointFloat(616f, 10f);
		xrShape2.Name = "xrShape2";
		xrShape2.Shape = shape;
		xrShape2.SizeF = new SizeF(2f, 64f);
		xrShape3.LocationFloat = new PointFloat(1f, 10f);
		xrShape3.Name = "xrShape3";
		xrShape3.Shape = shape2;
		xrShape3.SizeF = new SizeF(774.9998f, 64f);
		footerHeadTeacher.Controls.AddRange(new XRControl[5] { lblHeadteacherComment, xrLabel19, xrLabel15, xrShape5, xrShape6 });
		footerHeadTeacher.HeightF = 85f;
		footerHeadTeacher.Level = 3;
		footerHeadTeacher.Name = "footerHeadTeacher";
		lblHeadteacherComment.BorderColor = Color.Black;
		lblHeadteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblHeadteacherComment.Borders = BorderSide.None;
		lblHeadteacherComment.CanGrow = false;
		lblHeadteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadteacherRemark]")
		});
		lblHeadteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblHeadteacherComment.ForeColor = Color.Black;
		lblHeadteacherComment.LocationFloat = new PointFloat(6.500007f, 36.5f);
		lblHeadteacherComment.Name = "lblHeadteacherComment";
		lblHeadteacherComment.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblHeadteacherComment.SizeF = new SizeF(603f, 23f);
		lblHeadteacherComment.StylePriority.UseBorderColor = false;
		lblHeadteacherComment.StylePriority.UseBorderDashStyle = false;
		lblHeadteacherComment.StylePriority.UseBorders = false;
		lblHeadteacherComment.StylePriority.UseFont = false;
		lblHeadteacherComment.StylePriority.UseForeColor = false;
		lblHeadteacherComment.StylePriority.UsePadding = false;
		lblHeadteacherComment.StylePriority.UseTextAlignment = false;
		lblHeadteacherComment.TextAlignment = TextAlignment.MiddleLeft;
		lblHeadteacherComment.WordWrap = false;
		xrLabel19.BackColor = Color.Transparent;
		xrLabel19.BorderColor = Color.Black;
		xrLabel19.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel19.Borders = BorderSide.None;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Consolas", 11f, DXFontStyle.Bold);
		xrLabel19.ForeColor = Color.Black;
		xrLabel19.LocationFloat = new PointFloat(6.500019f, 13f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(451.0417f, 23f);
		xrLabel19.StylePriority.UseBackColor = false;
		xrLabel19.StylePriority.UseBorderColor = false;
		xrLabel19.StylePriority.UseBorderDashStyle = false;
		xrLabel19.StylePriority.UseBorders = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Headteacher Remarks:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.WordWrap = false;
		xrLabel15.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel15.LocationFloat = new PointFloat(620.5f, 12f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape5.LocationFloat = new PointFloat(615.5f, 10f);
		xrShape5.Name = "xrShape5";
		xrShape5.Shape = shape3;
		xrShape5.SizeF = new SizeF(2f, 64f);
		xrShape6.LocationFloat = new PointFloat(0f, 10f);
		xrShape6.Name = "xrShape6";
		xrShape6.Shape = shape4;
		xrShape6.SizeF = new SizeF(774.9998f, 64f);
		GroupFooter3.Controls.AddRange(new XRControl[1] { xrTable3 });
		GroupFooter3.HeightF = 25f;
		GroupFooter3.Level = 1;
		GroupFooter3.Name = "GroupFooter3";
		xrTable3.BorderColor = Color.Black;
		xrTable3.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable3.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable3.ForeColor = Color.Black;
		xrTable3.LocationFloat = new PointFloat(0f, 0f);
		xrTable3.Name = "xrTable3";
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow4 });
		xrTable3.SizeF = new SizeF(781f, 25f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseForeColor = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow4.Cells.AddRange(new XRTableCell[3] { xrTableCell31, xrTableCell32, xrTableCell37 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell31.BorderColor = Color.DimGray;
		xrTableCell31.Borders = BorderSide.Bottom;
		xrTableCell31.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell31.ForeColor = Color.Black;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell31.StylePriority.UseBorderColor = false;
		xrTableCell31.StylePriority.UseBorders = false;
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UseForeColor = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.Text = "AVERAGE SCORES:";
		xrTableCell31.Weight = 0.7136972463728747;
		xrTableCell32.BorderColor = Color.DimGray;
		xrTableCell32.Borders = BorderSide.Right | BorderSide.Bottom;
		xrTableCell32.CanGrow = false;
		xrTableCell32.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumAvg([LO])")
		});
		xrTableCell32.Font = new DXFont("Tahoma", 12f);
		xrTableCell32.ForeColor = Color.Black;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell32.StylePriority.UseBorderColor = false;
		xrTableCell32.StylePriority.UseBorders = false;
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.StylePriority.UseForeColor = false;
		xrTableCell32.StylePriority.UsePadding = false;
		xrTableCell32.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell32.Summary = xRSummary;
		xrTableCell32.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell32.TextFormatString = "{0:n2}";
		xrTableCell32.Weight = 0.3700643724386303;
		xrTableCell32.WordWrap = false;
		xrTableCell37.BorderColor = Color.DimGray;
		xrTableCell37.Borders = BorderSide.Left | BorderSide.Bottom;
		xrTableCell37.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformance]")
		});
		xrTableCell37.Font = new DXFont("Tahoma", 12f);
		xrTableCell37.ForeColor = Color.Black;
		xrTableCell37.Multiline = true;
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell37.StylePriority.UseBorderColor = false;
		xrTableCell37.StylePriority.UseBorders = false;
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.StylePriority.UseForeColor = false;
		xrTableCell37.StylePriority.UsePadding = false;
		xrTableCell37.StylePriority.UseTextAlignment = false;
		xrTableCell37.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell37.Weight = 0.6578387751987272;
		base.Bands.AddRange(new Band[8] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupFooter1, footerClassTeacher, footerHeadTeacher, GroupFooter3 });
		base.ComponentStorage.AddRange(new IComponent[1] { descriptiveUltimateReport1 });
		base.DataAdapter = adapterDescriptiveUltimateReport;
		base.DataMember = "DescriptiveUltimateReportDS";
		base.DataSource = descriptiveUltimateReport1;
		FilterString = "[StudentNumber] = ?studentNo";
		Font = new DXFont("Arial", 9.75f);
		base.HorizontalContentSplitting = HorizontalContentSplitting.Smart;
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 2371;
		base.PageWidth = 781;
		base.PaperKind = DXPaperKind.Custom;
		base.ParameterPanelLayoutItems.AddRange(new ParameterPanelLayoutItem[1]
		{
			new ParameterLayoutItem(studentNo)
		});
		base.Parameters.AddRange(new Parameter[1] { studentNo });
		base.RollPaper = true;
		base.StyleSheet.AddRange(new XRControlStyle[1] { TitleStyle });
		base.Version = "23.2";
		base.VerticalContentSplitting = VerticalContentSplitting.Smart;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)descriptiveUltimateReport1).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
