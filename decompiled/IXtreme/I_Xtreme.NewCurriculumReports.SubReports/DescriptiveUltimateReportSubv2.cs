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

public class DescriptiveUltimateReportSubv2 : XtraReport
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

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell25;

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

	private DescriptiveUltimateReport descriptiveUltimateReport1;

	private GroupFooterBand GroupFooter3;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell40;

	private XRTableCell xrTableCell41;

	public DescriptiveUltimateReportSubv2()
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
		XRSummary xRSummary2 = new XRSummary();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		TitleStyle = new XRControlStyle();
		xrTableCell13 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell25 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTable2 = new XRTable();
		GroupHeader1 = new GroupHeaderBand();
		xrLine1 = new XRLine();
		studentNo = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrLine2 = new XRLine();
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
		descriptiveUltimateReport1 = new DescriptiveUltimateReport();
		GroupFooter3 = new GroupFooterBand();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell4 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
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
		xrTableRow1.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell1, xrTableCell26, xrTableCell2, xrTableCell3, xrTableCell6, xrTableCell16, xrTableCell21, xrTableCell20, xrTableCell19, xrTableCell8,
			xrTableCell7, xrTableCell24
		});
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.CanGrow = false;
		xrTableCell1.CanShrink = true;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Arial Narrow", 7f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell1.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 2.670812984775381;
		xrTableCell1.WordWrap = false;
		xrTableCell26.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Topic]")
		});
		xrTableCell26.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell26.Multiline = true;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.StylePriority.UseTextAlignment = false;
		xrTableCell26.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell26.Weight = 2.513706444500506;
		xrTableCell2.CanShrink = true;
		xrTableCell2.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Font.Bold", "[Topic]"),
			new ExpressionBinding("BeforePrint", "Text", "[Competence]")
		});
		xrTableCell2.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell2.Weight = 3.6134529874780306;
		xrTableCell3.CanGrow = false;
		xrTableCell3.CanShrink = true;
		xrTableCell3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[LO]")
		});
		xrTableCell3.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell3.Weight = 1.0997465343616752;
		xrTableCell6.CanGrow = false;
		xrTableCell6.CanShrink = true;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "[Descriptor]")
		});
		xrTableCell6.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell6.Weight = 1.8852798219995295;
		xrTableCell16.CanShrink = true;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "[GenericSkill]")
		});
		xrTableCell16.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 5.184519472555611;
		xrTableCell21.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[AvMark]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell21.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell21.Multiline = true;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell21.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.Tag = "SubjectId";
		xrTableCell21.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell21.Weight = 1.099746570808307;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETA80]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell20.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell20.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Tag = "SubjectId";
		xrTableCell20.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell20.Weight = 1.0997465708083065;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Total]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell19.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell19.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.Tag = "SubjectId";
		xrTableCell19.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell19.Weight = 1.099746570808307;
		xrTableCell19.WordWrap = false;
		xrTableCell8.CanGrow = false;
		xrTableCell8.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Category]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell8.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell8.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.Tag = "SubjectId";
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 1.0997465708083067;
		xrTableCell8.WordWrap = false;
		xrTableCell7.CanShrink = true;
		xrTableCell7.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "[TeacherRemarks]")
		});
		xrTableCell7.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell7.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Tag = "SubjectId";
		xrTableCell7.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell7.Weight = 1.7281731261572346;
		xrTableCell24.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell24.Font = new DXFont("Arial Narrow", 8f);
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell24.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.StylePriority.UseTextAlignment = false;
		xrTableCell24.Tag = "SubjectId";
		xrTableCell24.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell24.Weight = 1.445380918237292;
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 0f;
		BottomMargin.Name = "BottomMargin";
		TitleStyle.Font = new DXFont("Arial", 18f);
		TitleStyle.Name = "TitleStyle";
		TitleStyle.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell13.BackColor = Color.Transparent;
		xrTableCell13.CanGrow = false;
		xrTableCell13.Font = new DXFont("Tahoma", 7f);
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
		xrTableCell13.Text = "Teacher's Comments";
		xrTableCell13.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell13.Weight = 1.7281732416998605;
		xrTableCell12.BackColor = Color.Transparent;
		xrTableCell12.CanGrow = false;
		xrTableCell12.Font = new DXFont("Tahoma", 7f);
		xrTableCell12.ForeColor = Color.DarkBlue;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell12.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell12.StylePriority.UseBackColor = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UseForeColor = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.Text = "Descriptor";
		xrTableCell12.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell12.Weight = 1.885279915209101;
		xrTableCell12.WordWrap = false;
		xrTableCell10.BackColor = Color.Transparent;
		xrTableCell10.CanGrow = false;
		xrTableCell10.Font = new DXFont("Tahoma", 7f);
		xrTableCell10.ForeColor = Color.DarkBlue;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBackColor = false;
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseForeColor = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "CBC SCORE";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 1.099746614573111;
		xrTableCell9.BackColor = Color.Transparent;
		xrTableCell9.CanGrow = false;
		xrTableCell9.Font = new DXFont("Tahoma", 7f);
		xrTableCell9.ForeColor = Color.DarkBlue;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseBackColor = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseForeColor = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.Text = "Competency";
		xrTableCell9.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell9.Weight = 3.6134531361692757;
		xrTableCell5.BackColor = Color.Transparent;
		xrTableCell5.CanGrow = false;
		xrTableCell5.Font = new DXFont("Tahoma", 7f);
		xrTableCell5.ForeColor = Color.DarkBlue;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell5.StylePriority.UseBackColor = false;
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.StylePriority.UseForeColor = false;
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "SUBJECT";
		xrTableCell5.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell5.Weight = 2.6708130977049795;
		xrTableCell5.WordWrap = false;
		xrTableRow2.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell5, xrTableCell25, xrTableCell9, xrTableCell10, xrTableCell12, xrTableCell15, xrTableCell18, xrTableCell17, xrTableCell14, xrTableCell11,
			xrTableCell13, xrTableCell23
		});
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell25.BackColor = Color.Transparent;
		xrTableCell25.Font = new DXFont("Tahoma", 7f);
		xrTableCell25.ForeColor = Color.DarkBlue;
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseBackColor = false;
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.StylePriority.UseForeColor = false;
		xrTableCell25.StylePriority.UseTextAlignment = false;
		xrTableCell25.Text = "CHAPTER";
		xrTableCell25.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell25.Weight = 2.5137065350302135;
		xrTableCell15.BackColor = Color.Transparent;
		xrTableCell15.Font = new DXFont("Tahoma", 7f);
		xrTableCell15.ForeColor = Color.DarkBlue;
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBackColor = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.StylePriority.UseForeColor = false;
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "Remarks on Generic Skills";
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 5.184519643314829;
		xrTableCell18.BackColor = Color.Transparent;
		xrTableCell18.Font = new DXFont("Tahoma", 7f);
		xrTableCell18.ForeColor = Color.DarkBlue;
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseBackColor = false;
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseForeColor = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "ASSMT (20)";
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 1.0997465772544;
		xrTableCell17.BackColor = Color.Transparent;
		xrTableCell17.Font = new DXFont("Tahoma", 7f);
		xrTableCell17.ForeColor = Color.DarkBlue;
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseBackColor = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseForeColor = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "EXAM (80)";
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 1.0997465772544008;
		xrTableCell14.BackColor = Color.Transparent;
		xrTableCell14.Font = new DXFont("Tahoma", 7f);
		xrTableCell14.ForeColor = Color.DarkBlue;
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseBackColor = false;
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseForeColor = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.Text = "TOTAL (100)";
		xrTableCell14.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell14.Weight = 1.099746577254399;
		xrTableCell11.BackColor = Color.Transparent;
		xrTableCell11.Font = new DXFont("Tahoma", 7f);
		xrTableCell11.ForeColor = Color.DarkBlue;
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseBackColor = false;
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.StylePriority.UseForeColor = false;
		xrTableCell11.StylePriority.UseTextAlignment = false;
		xrTableCell11.Text = "Grade";
		xrTableCell11.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell11.Weight = 1.0997465772544004;
		xrTableCell23.BackColor = Color.Transparent;
		xrTableCell23.Font = new DXFont("Tahoma", 7f);
		xrTableCell23.ForeColor = Color.DarkBlue;
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseBackColor = false;
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.StylePriority.UseForeColor = false;
		xrTableCell23.StylePriority.UseTextAlignment = false;
		xrTableCell23.Text = "TEACHER";
		xrTableCell23.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell23.Weight = 1.4453813784126828;
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
		adapterDescriptiveUltimateReport.ClearBeforeFill = true;
		footerClassTeacher.Controls.AddRange(new XRControl[5] { xrLabel17, lblClassteacherComment, xrLabel1, xrShape2, xrShape3 });
		footerClassTeacher.HeightF = 74f;
		footerClassTeacher.Level = 2;
		footerClassTeacher.Name = "footerClassTeacher";
		footerClassTeacher.PrintAtBottom = true;
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
		lblHeadteacherComment.LocationFloat = new PointFloat(6.500008f, 40.87498f);
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
		xrLabel19.LocationFloat = new PointFloat(6.500019f, 17.37498f);
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
		xrLabel15.LocationFloat = new PointFloat(620.5f, 16.37498f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape5.LocationFloat = new PointFloat(615.5f, 14.37498f);
		xrShape5.Name = "xrShape5";
		xrShape5.Shape = shape3;
		xrShape5.SizeF = new SizeF(2f, 64f);
		xrShape6.LocationFloat = new PointFloat(0f, 14.37498f);
		xrShape6.Name = "xrShape6";
		xrShape6.Shape = shape4;
		xrShape6.SizeF = new SizeF(774.9998f, 64f);
		descriptiveUltimateReport1.DataSetName = "DescriptiveUltimateReport";
		descriptiveUltimateReport1.EnforceConstraints = false;
		descriptiveUltimateReport1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
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
		xrTableRow4.Cells.AddRange(new XRTableCell[4] { xrTableCell4, xrTableCell22, xrTableCell40, xrTableCell41 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell4.BorderColor = Color.DimGray;
		xrTableCell4.Borders = BorderSide.Bottom;
		xrTableCell4.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell4.ForeColor = Color.Black;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell4.StylePriority.UseBorderColor = false;
		xrTableCell4.StylePriority.UseBorders = false;
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UseForeColor = false;
		xrTableCell4.StylePriority.UsePadding = false;
		xrTableCell4.Text = "AVERAGE SCORES:";
		xrTableCell4.Weight = 0.47172995858568256;
		xrTableCell22.BorderColor = Color.DimGray;
		xrTableCell22.Borders = BorderSide.Right | BorderSide.Bottom;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumAvg([LO])")
		});
		xrTableCell22.Font = new DXFont("Tahoma", 10f);
		xrTableCell22.ForeColor = Color.Black;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell22.StylePriority.UseBorderColor = false;
		xrTableCell22.StylePriority.UseBorders = false;
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.StylePriority.UseForeColor = false;
		xrTableCell22.StylePriority.UsePadding = false;
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell22.Summary = xRSummary;
		xrTableCell22.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell22.TextFormatString = "{0:n2}";
		xrTableCell22.Weight = 0.23070818608106952;
		xrTableCell22.WordWrap = false;
		xrTableCell40.BorderColor = Color.DimGray;
		xrTableCell40.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell40.CanGrow = false;
		xrTableCell40.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Substring(sumAvg([Total]),0,4)")
		});
		xrTableCell40.Font = new DXFont("Tahoma", 10f);
		xrTableCell40.ForeColor = Color.Black;
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell40.StylePriority.UseBorderColor = false;
		xrTableCell40.StylePriority.UseBorders = false;
		xrTableCell40.StylePriority.UseFont = false;
		xrTableCell40.StylePriority.UseForeColor = false;
		xrTableCell40.StylePriority.UsePadding = false;
		xrTableCell40.StylePriority.UseTextAlignment = false;
		xRSummary2.Running = SummaryRunning.Page;
		xrTableCell40.Summary = xRSummary2;
		xrTableCell40.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell40.Weight = 0.7358874468049666;
		xrTableCell40.WordWrap = false;
		xrTableCell41.BorderColor = Color.DimGray;
		xrTableCell41.Borders = BorderSide.Left | BorderSide.Bottom;
		xrTableCell41.CanGrow = false;
		xrTableCell41.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformance]")
		});
		xrTableCell41.Font = new DXFont("Tahoma", 10f);
		xrTableCell41.ForeColor = Color.Black;
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell41.StylePriority.UseBorderColor = false;
		xrTableCell41.StylePriority.UseBorders = false;
		xrTableCell41.StylePriority.UseFont = false;
		xrTableCell41.StylePriority.UseForeColor = false;
		xrTableCell41.StylePriority.UsePadding = false;
		xrTableCell41.StylePriority.UseTextAlignment = false;
		xrTableCell41.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell41.Weight = 0.3032748025385135;
		xrTableCell41.WordWrap = false;
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
