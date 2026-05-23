using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.IslamicTheology.TheologySubDSTableAdapters;

namespace I_Xtreme.IslamicTheology;

public class TheologyReportSub : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRControlStyle TitleStyle;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell5;

	private XRTableRow xrTableRow2;

	private XRTable xrTable2;

	private GroupHeaderBand GroupHeader1;

	private Parameter studentNo;

	private XRLine xrLine1;

	private GroupFooterBand GroupFooter1;

	private XRLine xrLine2;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell4;

	private TheologySubDS theologySubDS1;

	private tbl_Scores_OL_ReportTHTableAdapter tbl_Scores_OL_ReportTHTableAdapter;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell11;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private GroupFooterBand GroupFooter2;

	private XRTable xrTable4;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell20;

	private GroupFooterBand GroupFooter3;

	private XRTable xrTable5;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell23;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	public TheologyReportSub()
	{
		InitializeComponent();
	}

	private void DescriptiveUltimateReportSub_BeforePrint(object sender, CancelEventArgs e)
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
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		TitleStyle = new XRControlStyle();
		xrTableCell13 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell4 = new XRTableCell();
		xrTable2 = new XRTable();
		GroupHeader1 = new GroupHeaderBand();
		xrLine1 = new XRLine();
		studentNo = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrLine2 = new XRLine();
		theologySubDS1 = new TheologySubDS();
		tbl_Scores_OL_ReportTHTableAdapter = new tbl_Scores_OL_ReportTHTableAdapter();
		xrTableRow3 = new XRTableRow();
		xrTableCell2 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		GroupFooter2 = new GroupFooterBand();
		xrTable4 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell17 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		GroupFooter3 = new GroupFooterBand();
		xrTable5 = new XRTable();
		xrTableRow6 = new XRTableRow();
		xrTableCell21 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)theologySubDS1).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)xrTable5).BeginInit();
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
		xrTableRow1.Cells.AddRange(new XRTableCell[4] { xrTableCell1, xrTableCell8, xrTableCell3, xrTableCell7 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.CanShrink = true;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Concat(Concat([SubjectId],NewLine() ), [SubjectIdAr])\n")
		});
		xrTableCell1.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell1.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 1.940324303543876;
		xrTableCell8.CanShrink = true;
		xrTableCell8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Concat(Concat([Topic],NewLine() ), [TopicAr])")
		});
		xrTableCell8.Font = new DXFont("KFGQPC Uthman Taha Naskh", 10f);
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell8.Weight = 3.9330890114892862;
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
		xrTableCell3.Weight = 0.6712469021200869;
		xrTableCell7.CanShrink = true;
		xrTableCell7.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Text", "[TeacherRemarks]")
		});
		xrTableCell7.Font = new DXFont("Arial Narrow", 11f);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell7.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.StylePriority.UseTextAlignment = false;
		xrTableCell7.Tag = "SubjectId";
		xrTableCell7.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell7.Weight = 3.284915946918671;
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
		xrTableCell13.Text = "TEACHER'S REMARKS";
		xrTableCell13.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell13.Weight = 3.284916174841713;
		xrTableCell10.BackColor = Color.AliceBlue;
		xrTableCell10.CanGrow = false;
		xrTableCell10.Font = new DXFont("Arial Narrow", 9.75f, DXFontStyle.Bold);
		xrTableCell10.ForeColor = Color.DarkBlue;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBackColor = false;
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseForeColor = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "Score";
		xrTableCell10.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell10.Weight = 0.6712473361637826;
		xrTableCell10.WordWrap = false;
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
		xrTableCell5.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell5.Weight = 1.9403240451235897;
		xrTableCell5.WordWrap = false;
		xrTableRow2.Cells.AddRange(new XRTableCell[4] { xrTableCell5, xrTableCell4, xrTableCell10, xrTableCell13 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell4.BackColor = Color.AliceBlue;
		xrTableCell4.Font = new DXFont("Arial Narrow", 9f, DXFontStyle.Bold);
		xrTableCell4.ForeColor = Color.DarkBlue;
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseBackColor = false;
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UseForeColor = false;
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.Text = "TOPICS";
		xrTableCell4.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell4.Weight = 3.933089128842901;
		xrTable2.BorderColor = Color.MidnightBlue;
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTable2.ForeColor = Color.White;
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow3, xrTableRow2 });
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
		GroupFooter1.Controls.AddRange(new XRControl[2] { xrTable3, xrLine2 });
		GroupFooter1.HeightF = 50.41666f;
		GroupFooter1.Level = 1;
		GroupFooter1.Name = "GroupFooter1";
		xrLine2.BorderColor = Color.MidnightBlue;
		xrLine2.ForeColor = Color.MidnightBlue;
		xrLine2.LineWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(0f, 0f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(781f, 2.083333f);
		xrLine2.StylePriority.UseBorderColor = false;
		xrLine2.StylePriority.UseForeColor = false;
		theologySubDS1.DataSetName = "TheologySubDS";
		theologySubDS1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tbl_Scores_OL_ReportTHTableAdapter.ClearBeforeFill = true;
		xrTableRow3.Cells.AddRange(new XRTableCell[4] { xrTableCell2, xrTableCell6, xrTableCell9, xrTableCell11 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell2.BackColor = Color.AliceBlue;
		xrTableCell2.Font = new DXFont("KFGQPC Uthman Taha Naskh", 14f, DXFontStyle.Bold);
		xrTableCell2.ForeColor = Color.DarkBlue;
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.RightToLeft = RightToLeft.Yes;
		xrTableCell2.StylePriority.UseBackColor = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseForeColor = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "المادة";
		xrTableCell2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell2.Weight = 1.9403240451235897;
		xrTableCell6.BackColor = Color.AliceBlue;
		xrTableCell6.Font = new DXFont("KFGQPC Uthman Taha Naskh", 14f, DXFontStyle.Bold);
		xrTableCell6.ForeColor = Color.DarkBlue;
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.RightToLeft = RightToLeft.Yes;
		xrTableCell6.StylePriority.UseBackColor = false;
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseForeColor = false;
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.Text = "المواضيع";
		xrTableCell6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell6.Weight = 3.933089128842901;
		xrTableCell9.BackColor = Color.AliceBlue;
		xrTableCell9.Font = new DXFont("KFGQPC Uthman Taha Naskh", 14f, DXFontStyle.Bold);
		xrTableCell9.ForeColor = Color.DarkBlue;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.RightToLeft = RightToLeft.Yes;
		xrTableCell9.StylePriority.UseBackColor = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseForeColor = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.Text = "الدرجة";
		xrTableCell9.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell9.Weight = 0.6712473361637826;
		xrTableCell11.BackColor = Color.AliceBlue;
		xrTableCell11.Font = new DXFont("KFGQPC Uthman Taha Naskh", 14f, DXFontStyle.Bold);
		xrTableCell11.ForeColor = Color.DarkBlue;
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.RightToLeft = RightToLeft.Yes;
		xrTableCell11.StylePriority.UseBackColor = false;
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.StylePriority.UseForeColor = false;
		xrTableCell11.StylePriority.UseTextAlignment = false;
		xrTableCell11.Text = "ملاحظة المعلم";
		xrTableCell11.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell11.Weight = 3.284916174841713;
		xrTable3.BorderColor = Color.MidnightBlue;
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(0f, 15f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow4 });
		xrTable3.SizeF = new SizeF(781f, 25f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTableRow4.Cells.AddRange(new XRTableCell[6] { xrTableCell12, xrTableCell22, xrTableCell14, xrTableCell15, xrTableCell24, xrTableCell16 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell12.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell12.CanShrink = true;
		xrTableCell12.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f, DXFontStyle.Bold);
		xrTableCell12.Multiline = true;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell12.RightToLeft = RightToLeft.Yes;
		xrTableCell12.StylePriority.UseBorders = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UsePadding = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.Text = "المجموع";
		xrTableCell12.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell12.Weight = 1.7961106610930526;
		xrTableCell14.CanShrink = true;
		xrTableCell14.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell14.Weight = 1.1432187386408799;
		xrTableCell15.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell15.CanGrow = false;
		xrTableCell15.CanShrink = true;
		xrTableCell15.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f, DXFontStyle.Bold);
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.RightToLeft = RightToLeft.Yes;
		xrTableCell15.StylePriority.UseBorders = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "النسبة المتوسة";
		xrTableCell15.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell15.Weight = 1.7043369055330104;
		xrTableCell16.CanShrink = true;
		xrTableCell16.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell16.Multiline = true;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell16.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Tag = "SubjectId";
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 1.2397104069545613;
		GroupFooter2.Controls.AddRange(new XRControl[1] { xrTable4 });
		GroupFooter2.HeightF = 40f;
		GroupFooter2.Level = 2;
		GroupFooter2.Name = "GroupFooter2";
		xrTable4.BorderColor = Color.MidnightBlue;
		xrTable4.Borders = BorderSide.All;
		xrTable4.LocationFloat = new PointFloat(0f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable4.Rows.AddRange(new XRTableRow[1] { xrTableRow5 });
		xrTable4.SizeF = new SizeF(781f, 25f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTableRow5.Cells.AddRange(new XRTableCell[3] { xrTableCell17, xrTableCell25, xrTableCell20 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell17.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell17.CanShrink = true;
		xrTableCell17.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f, DXFontStyle.Bold);
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell17.RightToLeft = RightToLeft.Yes;
		xrTableCell17.StylePriority.UseBorders = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UsePadding = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "المجاميع الكلية";
		xrTableCell17.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell17.Weight = 1.9403243970184387;
		xrTableCell20.CanShrink = true;
		xrTableCell20.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell20.Multiline = true;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell20.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Tag = "SubjectId";
		xrTableCell20.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell20.Weight = 5.1596883320369855;
		GroupFooter3.Controls.AddRange(new XRControl[1] { xrTable5 });
		GroupFooter3.HeightF = 53f;
		GroupFooter3.Level = 3;
		GroupFooter3.Name = "GroupFooter3";
		xrTable5.BorderColor = Color.MidnightBlue;
		xrTable5.Borders = BorderSide.All;
		xrTable5.LocationFloat = new PointFloat(0f, 0f);
		xrTable5.Name = "xrTable5";
		xrTable5.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable5.Rows.AddRange(new XRTableRow[2] { xrTableRow6, xrTableRow7 });
		xrTable5.SizeF = new SizeF(781f, 50f);
		xrTable5.StylePriority.UseBorderColor = false;
		xrTable5.StylePriority.UseBorders = false;
		xrTableRow6.Cells.AddRange(new XRTableCell[4] { xrTableCell21, xrTableCell27, xrTableCell23, xrTableCell28 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell21.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell21.CanShrink = true;
		xrTableCell21.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f, DXFontStyle.Bold);
		xrTableCell21.Multiline = true;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell21.RightToLeft = RightToLeft.Yes;
		xrTableCell21.StylePriority.UseBorders = false;
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UsePadding = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.Text = "الترتيب";
		xrTableCell21.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell21.Weight = 2.936706465471217;
		xrTableCell23.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell23.CanGrow = false;
		xrTableCell23.CanShrink = true;
		xrTableCell23.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f, DXFontStyle.Bold);
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.RightToLeft = RightToLeft.Yes;
		xrTableCell23.StylePriority.UseBorders = false;
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.StylePriority.UseTextAlignment = false;
		xrTableCell23.Text = "التقدير";
		xrTableCell23.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell23.Weight = 1.9780816165647426;
		xrTableRow7.Cells.AddRange(new XRTableCell[3] { xrTableCell18, xrTableCell19, xrTableCell26 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell18.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UsePadding = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell18.Weight = 2.9367064478241964;
		xrTableCell19.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell19.Multiline = true;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.StylePriority.UseTextAlignment = false;
		xrTableCell19.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell19.Weight = 2.9367064427279574;
		xrTableCell26.Font = new DXFont("KFGQPC Uthman Taha Naskh", 12f);
		xrTableCell26.Multiline = true;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.StylePriority.UseTextAlignment = false;
		xrTableCell26.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell26.Weight = 3.956163273519766;
		xrTableCell22.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell22.Font = new DXFont("Cascadia Code", 12f);
		xrTableCell22.Multiline = true;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell22.StylePriority.UseBorders = false;
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.StylePriority.UsePadding = false;
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xrTableCell22.Text = " / Total Marks";
		xrTableCell22.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell22.Weight = 1.9009931638999906;
		xrTableCell24.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell24.Font = new DXFont("Cascadia Code", 12f);
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseBorders = false;
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.StylePriority.UseTextAlignment = false;
		xrTableCell24.Text = " / Average Mark";
		xrTableCell24.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell24.Weight = 2.0452062879504256;
		xrTableCell25.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell25.Font = new DXFont("Cascadia Code", 12f);
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell25.StylePriority.UseBorders = false;
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.StylePriority.UsePadding = false;
		xrTableCell25.StylePriority.UseTextAlignment = false;
		xrTableCell25.Text = " / Total Aggregates";
		xrTableCell25.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell25.Weight = 2.729563435016496;
		xrTableCell27.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell27.Font = new DXFont("Cascadia Code", 12f);
		xrTableCell27.Multiline = true;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Padding = new PaddingInfo(4, 2, 0, 0, 100f);
		xrTableCell27.StylePriority.UseBorders = false;
		xrTableCell27.StylePriority.UseFont = false;
		xrTableCell27.StylePriority.UsePadding = false;
		xrTableCell27.StylePriority.UseTextAlignment = false;
		xrTableCell27.Text = " / Position In Class";
		xrTableCell27.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell27.Weight = 2.936706465471217;
		xrTableCell28.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell28.Font = new DXFont("Cascadia Code", 12f);
		xrTableCell28.Multiline = true;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UseTextAlignment = false;
		xrTableCell28.Text = " / Grade";
		xrTableCell28.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell28.Weight = 1.9780816165647426;
		base.Bands.AddRange(new Band[7] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupFooter1, GroupFooter2, GroupFooter3 });
		base.ComponentStorage.AddRange(new IComponent[1] { theologySubDS1 });
		base.DataAdapter = tbl_Scores_OL_ReportTHTableAdapter;
		base.DataMember = "tbl_Scores_OL_ReportTH";
		base.DataSource = theologySubDS1;
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
		base.Version = "22.2";
		base.VerticalContentSplitting = VerticalContentSplitting.Smart;
		BeforePrint += DescriptiveUltimateReportSub_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)theologySubDS1).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)xrTable5).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
