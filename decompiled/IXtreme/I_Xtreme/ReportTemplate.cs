using System.ComponentModel;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace I_Xtreme;

public class ReportTemplate : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private ReportHeaderBand ReportHeader;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell3;

	private XRLabel xrLabel7;

	private ReportFooterBand ReportFooter;

	private GroupFooterBand GroupFooter1;

	public XRTable xrTable1;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell9;

	private XRLabel xrLabel29;

	private XRLabel xrLabel32;

	private XRLabel xrLabel28;

	private XRLabel xrLabel26;

	private XRLabel xrLabel27;

	private XRLabel xrLabel33;

	private XRLabel xrLabel37;

	private XRLabel xrLabel38;

	private XRLabel xrLabel36;

	private XRLabel xrLabel34;

	private XRLabel xrLabel35;

	private XRLabel xrLabel17;

	private XRLabel xrLabel47;

	private XRLabel xrLabel59;

	private XRLabel xrLabel41;

	private XRLabel xrLabel16;

	private XRLabel xrLabel15;

	private XRLabel xrLabel51;

	private XRLabel xrLabel20;

	private XRLabel xrLabel18;

	private XRLabel xrLabel40;

	private XRLabel xrLabel50;

	private XRLabel xrLabel19;

	private XRLabel xrLabel21;

	private XRLabel xrLabel30;

	private XRLabel xrLabel31;

	private XRLabel xrLabel25;

	private XRLabel xrLabel24;

	private XRLabel xrLabel23;

	private XRLabel xrLabel44;

	private XRLabel xrLabel45;

	private XRLabel xrLabel46;

	private XRLabel xrLabel14;

	private XRLabel xrLabel43;

	private XRLabel xrLabel22;

	private XRLabel xrLabel39;

	private XRLabel xrLabel13;

	private XRLabel xrLabel12;

	private XRLabel xrLabel49;

	private XRLabel xrLabel48;

	private XRLabel xrLabel42;

	private XRLabel xrLabel11;

	private XRLabel xrLabel6;

	private XRLabel xrLabel1;

	private XRPictureBox xrPictureBox2;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRLabel xrLabel8;

	private XRTable xrTable2;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell19;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell29;

	public XRTable xrTable3;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell33;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell38;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell39;

	private XRTableCell xrTableCell40;

	private XRTableCell xrTableCell41;

	private XRTableCell xrTableCell42;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell47;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell48;

	private XRTableCell xrTableCell49;

	private XRTableCell xrTableCell50;

	private XRTableCell xrTableCell51;

	private XRTableCell xrTableCell53;

	private XRTableCell xrTableCell54;

	private XRTableCell xrTableCell55;

	private XRTableCell xrTableCell56;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell57;

	private XRTableCell xrTableCell58;

	private XRTableCell xrTableCell59;

	private XRTableCell xrTableCell60;

	private XRTableCell xrTableCell62;

	private XRTableCell xrTableCell63;

	private XRTableCell xrTableCell64;

	private XRTableCell xrTableCell65;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell66;

	private XRTableCell xrTableCell67;

	private XRTableCell xrTableCell68;

	private XRTableCell xrTableCell69;

	private XRTableCell xrTableCell71;

	private XRTableCell xrTableCell72;

	private XRTableCell xrTableCell73;

	private XRTableCell xrTableCell74;

	private XRTableRow xrTableRow9;

	private XRTableCell xrTableCell75;

	private XRTableCell xrTableCell76;

	private XRTableCell xrTableCell77;

	private XRTableCell xrTableCell78;

	private XRTableCell xrTableCell80;

	private XRTableCell xrTableCell81;

	private XRTableCell xrTableCell82;

	private XRTableCell xrTableCell83;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell84;

	private XRTableCell xrTableCell85;

	private XRTableCell xrTableCell86;

	private XRTableCell xrTableCell87;

	private XRTableCell xrTableCell89;

	private XRTableCell xrTableCell90;

	private XRTableCell xrTableCell91;

	private XRTableCell xrTableCell92;

	private XRTableRow xrTableRow11;

	private XRTableCell xrTableCell93;

	private XRTableCell xrTableCell94;

	private XRTableCell xrTableCell95;

	private XRTableCell xrTableCell96;

	private XRTableCell xrTableCell98;

	private XRTableCell xrTableCell99;

	private XRTableCell xrTableCell100;

	private XRTableCell xrTableCell101;

	private XRTableRow xrTableRow12;

	private XRTableCell xrTableCell102;

	private XRTableCell xrTableCell103;

	private XRTableCell xrTableCell104;

	private XRTableCell xrTableCell105;

	private XRTableCell xrTableCell107;

	private XRTableCell xrTableCell108;

	private XRTableCell xrTableCell109;

	private XRTableCell xrTableCell110;

	private XRTableRow xrTableRow13;

	private XRTableCell xrTableCell111;

	private XRTableCell xrTableCell112;

	private XRTableCell xrTableCell113;

	private XRTableCell xrTableCell114;

	private XRTableCell xrTableCell116;

	private XRTableCell xrTableCell117;

	private XRTableCell xrTableCell118;

	private XRTableCell xrTableCell119;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell120;

	private XRTableCell xrTableCell121;

	private XRTableCell xrTableCell122;

	private XRTableCell xrTableCell123;

	private XRTableCell xrTableCell125;

	private XRTableCell xrTableCell126;

	private XRTableCell xrTableCell127;

	private XRTableCell xrTableCell128;

	private XRTableRow xrTableRow15;

	private XRTableCell xrTableCell129;

	private XRTableCell xrTableCell130;

	private XRTableCell xrTableCell131;

	private XRTableCell xrTableCell132;

	private XRTableCell xrTableCell134;

	private XRTableCell xrTableCell135;

	private XRTableCell xrTableCell136;

	private XRTableCell xrTableCell137;

	private XRTableRow xrTableRow16;

	private XRTableCell xrTableCell138;

	private XRTableCell xrTableCell139;

	private XRTableCell xrTableCell140;

	private XRTableCell xrTableCell141;

	private XRTableCell xrTableCell143;

	private XRTableCell xrTableCell144;

	private XRTableCell xrTableCell145;

	private XRTableCell xrTableCell146;

	private XRTableRow xrTableRow17;

	private XRTableCell xrTableCell147;

	private XRTableCell xrTableCell148;

	private XRTableCell xrTableCell149;

	private XRTableCell xrTableCell150;

	private XRTableCell xrTableCell152;

	private XRTableCell xrTableCell153;

	private XRTableCell xrTableCell154;

	private XRTableCell xrTableCell155;

	private XRTableRow xrTableRow18;

	private XRTableCell xrTableCell156;

	private XRTableCell xrTableCell157;

	private XRTableCell xrTableCell158;

	private XRTableCell xrTableCell159;

	private XRTableCell xrTableCell161;

	private XRTableCell xrTableCell162;

	private XRTableCell xrTableCell163;

	private XRTableCell xrTableCell164;

	private XRTableRow xrTableRow19;

	private XRTableCell xrTableCell165;

	private XRTableCell xrTableCell166;

	private XRTableCell xrTableCell167;

	private XRTableCell xrTableCell168;

	private XRTableCell xrTableCell170;

	private XRTableCell xrTableCell171;

	private XRTableCell xrTableCell172;

	private XRTableCell xrTableCell173;

	private XRTableRow xrTableRow20;

	private XRTableCell xrTableCell175;

	private XRTableCell xrTableCell176;

	private XRTableCell xrTableCell179;

	private XRTableCell xrTableCell180;

	private XRTableCell xrTableCell182;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell52;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell70;

	private XRTableCell xrTableCell79;

	private XRTableCell xrTableCell88;

	private XRTableCell xrTableCell97;

	private XRTableCell xrTableCell106;

	private XRTableCell xrTableCell115;

	private XRTableCell xrTableCell124;

	private XRTableCell xrTableCell133;

	private XRTableCell xrTableCell142;

	private XRTableCell xrTableCell151;

	private XRTableCell xrTableCell160;

	private XRTableCell xrTableCell174;

	private XRTableCell xrTableCell45;

	private XRTableCell xrTableCell36;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell46;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell34;

	private XRSubreport xrSubreport1;

	public ReportTemplate()
	{
		InitializeComponent();
	}

	private void ReportTemplate_BeforePrint(object sender, CancelEventArgs e)
	{
		xrLabel7.BackColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrLabel7.ForeColor = Color.FromArgb((int)ReportColors.ReportForeColor);
		xrTable1.BackColor = Color.FromArgb((int)ReportColors.ReportBannerColor);
		xrTable1.ForeColor = Color.FromArgb((int)ReportColors.ReportForeColor);
		if (ReportHeaderVisibility.ReportHeaderVisible)
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
			xrSubreport1.Visible = true;
			xrLabel7.Visible = true;
		}
		else
		{
			xrSubreport1.Visible = false;
			xrLabel7.Visible = false;
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ReportTemplate));
		Detail = new DetailBand();
		xrTable3 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell46 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableCell47 = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		xrTableCell48 = new XRTableCell();
		xrTableCell49 = new XRTableCell();
		xrTableCell50 = new XRTableCell();
		xrTableCell51 = new XRTableCell();
		xrTableCell53 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		xrTableCell54 = new XRTableCell();
		xrTableCell55 = new XRTableCell();
		xrTableCell56 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell57 = new XRTableCell();
		xrTableCell58 = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableCell60 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		xrTableCell52 = new XRTableCell();
		xrTableCell63 = new XRTableCell();
		xrTableCell64 = new XRTableCell();
		xrTableCell65 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell66 = new XRTableCell();
		xrTableCell67 = new XRTableCell();
		xrTableCell68 = new XRTableCell();
		xrTableCell69 = new XRTableCell();
		xrTableCell71 = new XRTableCell();
		xrTableCell61 = new XRTableCell();
		xrTableCell72 = new XRTableCell();
		xrTableCell73 = new XRTableCell();
		xrTableCell74 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		xrTableCell75 = new XRTableCell();
		xrTableCell76 = new XRTableCell();
		xrTableCell77 = new XRTableCell();
		xrTableCell78 = new XRTableCell();
		xrTableCell80 = new XRTableCell();
		xrTableCell70 = new XRTableCell();
		xrTableCell81 = new XRTableCell();
		xrTableCell82 = new XRTableCell();
		xrTableCell83 = new XRTableCell();
		xrTableRow10 = new XRTableRow();
		xrTableCell84 = new XRTableCell();
		xrTableCell85 = new XRTableCell();
		xrTableCell86 = new XRTableCell();
		xrTableCell87 = new XRTableCell();
		xrTableCell89 = new XRTableCell();
		xrTableCell79 = new XRTableCell();
		xrTableCell90 = new XRTableCell();
		xrTableCell91 = new XRTableCell();
		xrTableCell92 = new XRTableCell();
		xrTableRow11 = new XRTableRow();
		xrTableCell93 = new XRTableCell();
		xrTableCell94 = new XRTableCell();
		xrTableCell95 = new XRTableCell();
		xrTableCell96 = new XRTableCell();
		xrTableCell98 = new XRTableCell();
		xrTableCell88 = new XRTableCell();
		xrTableCell99 = new XRTableCell();
		xrTableCell100 = new XRTableCell();
		xrTableCell101 = new XRTableCell();
		xrTableRow12 = new XRTableRow();
		xrTableCell102 = new XRTableCell();
		xrTableCell103 = new XRTableCell();
		xrTableCell104 = new XRTableCell();
		xrTableCell105 = new XRTableCell();
		xrTableCell107 = new XRTableCell();
		xrTableCell97 = new XRTableCell();
		xrTableCell108 = new XRTableCell();
		xrTableCell109 = new XRTableCell();
		xrTableCell110 = new XRTableCell();
		xrTableRow13 = new XRTableRow();
		xrTableCell111 = new XRTableCell();
		xrTableCell112 = new XRTableCell();
		xrTableCell113 = new XRTableCell();
		xrTableCell114 = new XRTableCell();
		xrTableCell116 = new XRTableCell();
		xrTableCell106 = new XRTableCell();
		xrTableCell117 = new XRTableCell();
		xrTableCell118 = new XRTableCell();
		xrTableCell119 = new XRTableCell();
		xrTableRow14 = new XRTableRow();
		xrTableCell120 = new XRTableCell();
		xrTableCell121 = new XRTableCell();
		xrTableCell122 = new XRTableCell();
		xrTableCell123 = new XRTableCell();
		xrTableCell125 = new XRTableCell();
		xrTableCell115 = new XRTableCell();
		xrTableCell126 = new XRTableCell();
		xrTableCell127 = new XRTableCell();
		xrTableCell128 = new XRTableCell();
		xrTableRow15 = new XRTableRow();
		xrTableCell129 = new XRTableCell();
		xrTableCell130 = new XRTableCell();
		xrTableCell131 = new XRTableCell();
		xrTableCell132 = new XRTableCell();
		xrTableCell134 = new XRTableCell();
		xrTableCell124 = new XRTableCell();
		xrTableCell135 = new XRTableCell();
		xrTableCell136 = new XRTableCell();
		xrTableCell137 = new XRTableCell();
		xrTableRow16 = new XRTableRow();
		xrTableCell138 = new XRTableCell();
		xrTableCell139 = new XRTableCell();
		xrTableCell140 = new XRTableCell();
		xrTableCell141 = new XRTableCell();
		xrTableCell143 = new XRTableCell();
		xrTableCell133 = new XRTableCell();
		xrTableCell144 = new XRTableCell();
		xrTableCell145 = new XRTableCell();
		xrTableCell146 = new XRTableCell();
		xrTableRow17 = new XRTableRow();
		xrTableCell147 = new XRTableCell();
		xrTableCell148 = new XRTableCell();
		xrTableCell149 = new XRTableCell();
		xrTableCell150 = new XRTableCell();
		xrTableCell152 = new XRTableCell();
		xrTableCell142 = new XRTableCell();
		xrTableCell153 = new XRTableCell();
		xrTableCell154 = new XRTableCell();
		xrTableCell155 = new XRTableCell();
		xrTableRow18 = new XRTableRow();
		xrTableCell156 = new XRTableCell();
		xrTableCell157 = new XRTableCell();
		xrTableCell158 = new XRTableCell();
		xrTableCell159 = new XRTableCell();
		xrTableCell161 = new XRTableCell();
		xrTableCell151 = new XRTableCell();
		xrTableCell162 = new XRTableCell();
		xrTableCell163 = new XRTableCell();
		xrTableCell164 = new XRTableCell();
		xrTableRow19 = new XRTableRow();
		xrTableCell165 = new XRTableCell();
		xrTableCell166 = new XRTableCell();
		xrTableCell167 = new XRTableCell();
		xrTableCell168 = new XRTableCell();
		xrTableCell170 = new XRTableCell();
		xrTableCell160 = new XRTableCell();
		xrTableCell171 = new XRTableCell();
		xrTableCell172 = new XRTableCell();
		xrTableCell173 = new XRTableCell();
		xrTableRow20 = new XRTableRow();
		xrTableCell175 = new XRTableCell();
		xrTableCell176 = new XRTableCell();
		xrTableCell179 = new XRTableCell();
		xrTableCell180 = new XRTableCell();
		xrTableCell182 = new XRTableCell();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		ReportHeader = new ReportHeaderBand();
		xrLabel39 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel49 = new XRLabel();
		xrLabel48 = new XRLabel();
		xrLabel42 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrPictureBox2 = new XRPictureBox();
		xrLabel10 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell4 = new XRTableCell();
		xrTableCell174 = new XRTableCell();
		xrTableCell1 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		ReportFooter = new ReportFooterBand();
		xrTable2 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell15 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrLabel29 = new XRLabel();
		xrLabel32 = new XRLabel();
		xrLabel28 = new XRLabel();
		xrLabel26 = new XRLabel();
		xrLabel27 = new XRLabel();
		xrLabel33 = new XRLabel();
		xrLabel37 = new XRLabel();
		xrLabel38 = new XRLabel();
		xrLabel36 = new XRLabel();
		xrLabel34 = new XRLabel();
		xrLabel35 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrLabel47 = new XRLabel();
		xrLabel59 = new XRLabel();
		xrLabel41 = new XRLabel();
		xrLabel16 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel51 = new XRLabel();
		xrLabel20 = new XRLabel();
		xrLabel18 = new XRLabel();
		xrLabel40 = new XRLabel();
		xrLabel50 = new XRLabel();
		xrLabel19 = new XRLabel();
		GroupFooter1 = new GroupFooterBand();
		xrLabel21 = new XRLabel();
		xrLabel30 = new XRLabel();
		xrLabel31 = new XRLabel();
		xrLabel25 = new XRLabel();
		xrLabel24 = new XRLabel();
		xrLabel23 = new XRLabel();
		xrLabel44 = new XRLabel();
		xrLabel45 = new XRLabel();
		xrLabel46 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel43 = new XRLabel();
		xrLabel22 = new XRLabel();
		xrSubreport1 = new XRSubreport();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrTable3 });
		Detail.HeightF = 449.9996f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrTable3.BackColor = Color.Transparent;
		xrTable3.Borders = BorderSide.All;
		xrTable3.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable3.ForeColor = Color.Black;
		xrTable3.LocationFloat = new PointFloat(0f, 0f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(2, 2, 2, 2, 100f);
		xrTable3.Rows.AddRange(new XRTableRow[17]
		{
			xrTableRow2, xrTableRow5, xrTableRow6, xrTableRow7, xrTableRow8, xrTableRow9, xrTableRow10, xrTableRow11, xrTableRow12, xrTableRow13,
			xrTableRow14, xrTableRow15, xrTableRow16, xrTableRow17, xrTableRow18, xrTableRow19, xrTableRow20
		});
		xrTable3.SizeF = new SizeF(786.9999f, 424.9996f);
		xrTable3.StylePriority.UseBackColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseForeColor = false;
		xrTable3.StylePriority.UsePadding = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow2.Cells.AddRange(new XRTableCell[9] { xrTableCell30, xrTableCell31, xrTableCell32, xrTableCell33, xrTableCell35, xrTableCell45, xrTableCell36, xrTableCell7, xrTableCell38 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell30.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.Text = "SUBJECT";
		xrTableCell30.Weight = 0.5;
		xrTableCell31.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.Text = "HoP";
		xrTableCell31.Weight = 0.1814769294422453;
		xrTableCell32.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.Text = "BOT";
		xrTableCell32.Weight = 0.18144573219029342;
		xrTableCell33.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.Text = "MOT";
		xrTableCell33.Weight = 0.18147099839594621;
		xrTableCell35.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.Text = "EOT";
		xrTableCell35.Weight = 0.18151398021227785;
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.Weight = 0.23068840264344911;
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.Weight = 0.1814764558867774;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.Weight = 0.9526339061940924;
		xrTableCell38.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.Weight = 0.22782259663897186;
		xrTableRow5.Cells.AddRange(new XRTableCell[9] { xrTableCell39, xrTableCell40, xrTableCell41, xrTableCell42, xrTableCell44, xrTableCell46, xrTableCell37, xrTableCell34, xrTableCell47 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.StylePriority.UseTextAlignment = false;
		xrTableCell39.Text = "Marks Out of:";
		xrTableCell39.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell39.Weight = 0.5;
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.Text = "0";
		xrTableCell40.Weight = 0.18145166609464247;
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.Text = "0";
		xrTableCell41.Weight = 0.18147099553789625;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.Text = "0";
		xrTableCell42.Weight = 0.18147099839594621;
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.Text = "100";
		xrTableCell44.Weight = 0.18147693840113038;
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.Weight = 0.23072546873293726;
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.Weight = 0.18147656340514307;
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.Weight = 0.9526335662973235;
		xrTableCell47.Name = "xrTableCell47";
		xrTableCell47.Weight = 0.22782280473903457;
		xrTableRow6.Cells.AddRange(new XRTableCell[9] { xrTableCell48, xrTableCell49, xrTableCell50, xrTableCell51, xrTableCell53, xrTableCell43, xrTableCell54, xrTableCell55, xrTableCell56 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell48.Name = "xrTableCell48";
		xrTableCell48.StylePriority.UseTextAlignment = false;
		xrTableCell48.Text = "112-English";
		xrTableCell48.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell48.Weight = 0.5;
		xrTableCell49.Name = "xrTableCell49";
		xrTableCell49.Text = "-";
		xrTableCell49.Weight = 0.18145166609464247;
		xrTableCell50.Name = "xrTableCell50";
		xrTableCell50.Text = "-";
		xrTableCell50.Weight = 0.18147099553789625;
		xrTableCell51.Name = "xrTableCell51";
		xrTableCell51.Text = "-";
		xrTableCell51.Weight = 0.18147099839594621;
		xrTableCell53.ForeColor = Color.Maroon;
		xrTableCell53.Name = "xrTableCell53";
		xrTableCell53.StylePriority.UseForeColor = false;
		xrTableCell53.Text = "50";
		xrTableCell53.Weight = 0.18151386922557777;
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.Text = "50";
		xrTableCell43.Weight = 0.2306883163509643;
		xrTableCell54.ForeColor = Color.Maroon;
		xrTableCell54.Name = "xrTableCell54";
		xrTableCell54.StylePriority.UseForeColor = false;
		xrTableCell54.Text = "C5";
		xrTableCell54.Weight = 0.18147692721534445;
		xrTableCell55.Name = "xrTableCell55";
		xrTableCell55.Text = "Subject Comment";
		xrTableCell55.Weight = 0.9526335625559157;
		xrTableCell56.Name = "xrTableCell56";
		xrTableCell56.Text = "SHJ";
		xrTableCell56.Weight = 0.22782266622776676;
		xrTableRow7.Cells.AddRange(new XRTableCell[9] { xrTableCell57, xrTableCell58, xrTableCell59, xrTableCell60, xrTableCell62, xrTableCell52, xrTableCell63, xrTableCell64, xrTableCell65 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell57.Name = "xrTableCell57";
		xrTableCell57.StylePriority.UseTextAlignment = false;
		xrTableCell57.Text = "223-CRE";
		xrTableCell57.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell57.Weight = 0.5;
		xrTableCell58.Name = "xrTableCell58";
		xrTableCell58.Text = "-";
		xrTableCell58.Weight = 0.18145166609464247;
		xrTableCell59.Name = "xrTableCell59";
		xrTableCell59.Text = "-";
		xrTableCell59.Weight = 0.18147099553789625;
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.Text = "-";
		xrTableCell60.Weight = 0.18147099839594621;
		xrTableCell62.ForeColor = Color.Maroon;
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.StylePriority.UseForeColor = false;
		xrTableCell62.Text = "63";
		xrTableCell62.Weight = 0.18151386922557777;
		xrTableCell52.Name = "xrTableCell52";
		xrTableCell52.Text = "63";
		xrTableCell52.Weight = 0.2306883163509643;
		xrTableCell63.ForeColor = Color.Maroon;
		xrTableCell63.Name = "xrTableCell63";
		xrTableCell63.StylePriority.UseForeColor = false;
		xrTableCell63.Text = "C4";
		xrTableCell63.Weight = 0.18147692721534445;
		xrTableCell64.Name = "xrTableCell64";
		xrTableCell64.Text = "Subject Comment";
		xrTableCell64.Weight = 0.9526335625559157;
		xrTableCell65.Name = "xrTableCell65";
		xrTableCell65.Text = "AMR";
		xrTableCell65.Weight = 0.22782266622776676;
		xrTableRow8.Cells.AddRange(new XRTableCell[9] { xrTableCell66, xrTableCell67, xrTableCell68, xrTableCell69, xrTableCell71, xrTableCell61, xrTableCell72, xrTableCell73, xrTableCell74 });
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell66.Name = "xrTableCell66";
		xrTableCell66.StylePriority.UseTextAlignment = false;
		xrTableCell66.Text = "241-History";
		xrTableCell66.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell66.Weight = 0.5;
		xrTableCell67.Name = "xrTableCell67";
		xrTableCell67.Text = "-";
		xrTableCell67.Weight = 0.18145166609464247;
		xrTableCell68.Name = "xrTableCell68";
		xrTableCell68.Text = "-";
		xrTableCell68.Weight = 0.18147099553789625;
		xrTableCell69.Name = "xrTableCell69";
		xrTableCell69.Text = "-";
		xrTableCell69.Weight = 0.18147099839594621;
		xrTableCell71.ForeColor = Color.Maroon;
		xrTableCell71.Name = "xrTableCell71";
		xrTableCell71.StylePriority.UseForeColor = false;
		xrTableCell71.Text = "80";
		xrTableCell71.Weight = 0.18151386922557777;
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.Text = "80";
		xrTableCell61.Weight = 0.23068831635096435;
		xrTableCell72.ForeColor = Color.Maroon;
		xrTableCell72.Name = "xrTableCell72";
		xrTableCell72.StylePriority.UseForeColor = false;
		xrTableCell72.Text = "D1";
		xrTableCell72.Weight = 0.18147703820204447;
		xrTableCell73.Name = "xrTableCell73";
		xrTableCell73.Text = "Subject Comment";
		xrTableCell73.Weight = 0.9526334515692156;
		xrTableCell74.Name = "xrTableCell74";
		xrTableCell74.Text = "GRT";
		xrTableCell74.Weight = 0.22782266622776676;
		xrTableRow9.Cells.AddRange(new XRTableCell[9] { xrTableCell75, xrTableCell76, xrTableCell77, xrTableCell78, xrTableCell80, xrTableCell70, xrTableCell81, xrTableCell82, xrTableCell83 });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		xrTableCell75.Name = "xrTableCell75";
		xrTableCell75.StylePriority.UseTextAlignment = false;
		xrTableCell75.Text = "273-Geography";
		xrTableCell75.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell75.Weight = 0.5;
		xrTableCell76.Name = "xrTableCell76";
		xrTableCell76.Text = "-";
		xrTableCell76.Weight = 0.18145166609464247;
		xrTableCell77.Name = "xrTableCell77";
		xrTableCell77.Text = "-";
		xrTableCell77.Weight = 0.18147099553789625;
		xrTableCell78.Name = "xrTableCell78";
		xrTableCell78.Text = "-";
		xrTableCell78.Weight = 0.18147099839594621;
		xrTableCell80.ForeColor = Color.Maroon;
		xrTableCell80.Name = "xrTableCell80";
		xrTableCell80.StylePriority.UseForeColor = false;
		xrTableCell80.Text = "58";
		xrTableCell80.Weight = 0.18151386922557777;
		xrTableCell70.Name = "xrTableCell70";
		xrTableCell70.Text = "58";
		xrTableCell70.Weight = 0.23068831635096435;
		xrTableCell81.ForeColor = Color.Maroon;
		xrTableCell81.Name = "xrTableCell81";
		xrTableCell81.StylePriority.UseForeColor = false;
		xrTableCell81.Text = "C5";
		xrTableCell81.Weight = 0.18147703820204447;
		xrTableCell82.Name = "xrTableCell82";
		xrTableCell82.Text = "Subject Comment";
		xrTableCell82.Weight = 0.9526334515692156;
		xrTableCell83.Name = "xrTableCell83";
		xrTableCell83.Text = "AOP";
		xrTableCell83.Weight = 0.22782266622776676;
		xrTableRow10.Cells.AddRange(new XRTableCell[9] { xrTableCell84, xrTableCell85, xrTableCell86, xrTableCell87, xrTableCell89, xrTableCell79, xrTableCell90, xrTableCell91, xrTableCell92 });
		xrTableRow10.Name = "xrTableRow10";
		xrTableRow10.Weight = 1.0;
		xrTableCell84.Name = "xrTableCell84";
		xrTableCell84.StylePriority.UseTextAlignment = false;
		xrTableCell84.Text = "335-Luganda";
		xrTableCell84.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell84.Weight = 0.5;
		xrTableCell85.Name = "xrTableCell85";
		xrTableCell85.Text = "-";
		xrTableCell85.Weight = 0.18145166609464247;
		xrTableCell86.Name = "xrTableCell86";
		xrTableCell86.Text = "-";
		xrTableCell86.Weight = 0.18147099553789625;
		xrTableCell87.Name = "xrTableCell87";
		xrTableCell87.Text = "-";
		xrTableCell87.Weight = 0.18147099839594621;
		xrTableCell89.ForeColor = Color.Maroon;
		xrTableCell89.Name = "xrTableCell89";
		xrTableCell89.StylePriority.UseForeColor = false;
		xrTableCell89.Text = "40";
		xrTableCell89.Weight = 0.18151386922557777;
		xrTableCell79.Name = "xrTableCell79";
		xrTableCell79.Text = "40";
		xrTableCell79.Weight = 0.23068831635096435;
		xrTableCell90.ForeColor = Color.Maroon;
		xrTableCell90.Name = "xrTableCell90";
		xrTableCell90.StylePriority.UseForeColor = false;
		xrTableCell90.Text = "C6";
		xrTableCell90.Weight = 0.18147703820204447;
		xrTableCell91.Name = "xrTableCell91";
		xrTableCell91.Text = "Subject Comment";
		xrTableCell91.Weight = 0.9526334515692156;
		xrTableCell92.Name = "xrTableCell92";
		xrTableCell92.Text = "NG";
		xrTableCell92.Weight = 0.22782266622776676;
		xrTableRow11.Cells.AddRange(new XRTableCell[9] { xrTableCell93, xrTableCell94, xrTableCell95, xrTableCell96, xrTableCell98, xrTableCell88, xrTableCell99, xrTableCell100, xrTableCell101 });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		xrTableCell93.Name = "xrTableCell93";
		xrTableCell93.StylePriority.UseTextAlignment = false;
		xrTableCell93.Text = "336-Kiswahili";
		xrTableCell93.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell93.Weight = 0.5;
		xrTableCell94.Name = "xrTableCell94";
		xrTableCell94.Text = "-";
		xrTableCell94.Weight = 0.18145166609464247;
		xrTableCell95.Name = "xrTableCell95";
		xrTableCell95.Text = "-";
		xrTableCell95.Weight = 0.18147099553789625;
		xrTableCell96.Name = "xrTableCell96";
		xrTableCell96.Text = "-";
		xrTableCell96.Weight = 0.18147099839594621;
		xrTableCell98.ForeColor = Color.Maroon;
		xrTableCell98.Name = "xrTableCell98";
		xrTableCell98.StylePriority.UseForeColor = false;
		xrTableCell98.Text = "74";
		xrTableCell98.Weight = 0.18151386922557777;
		xrTableCell88.Name = "xrTableCell88";
		xrTableCell88.Text = "74";
		xrTableCell88.Weight = 0.23068831635096435;
		xrTableCell99.ForeColor = Color.Maroon;
		xrTableCell99.Name = "xrTableCell99";
		xrTableCell99.StylePriority.UseForeColor = false;
		xrTableCell99.Text = "D2";
		xrTableCell99.Weight = 0.18147703820204447;
		xrTableCell100.Name = "xrTableCell100";
		xrTableCell100.Text = "Subject Comment";
		xrTableCell100.Weight = 0.9526334515692156;
		xrTableCell101.Name = "xrTableCell101";
		xrTableCell101.Text = "NT";
		xrTableCell101.Weight = 0.22782266622776676;
		xrTableRow12.Cells.AddRange(new XRTableCell[9] { xrTableCell102, xrTableCell103, xrTableCell104, xrTableCell105, xrTableCell107, xrTableCell97, xrTableCell108, xrTableCell109, xrTableCell110 });
		xrTableRow12.Name = "xrTableRow12";
		xrTableRow12.Weight = 1.0;
		xrTableCell102.Name = "xrTableCell102";
		xrTableCell102.StylePriority.UseTextAlignment = false;
		xrTableCell102.Text = "456-Mathematics";
		xrTableCell102.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell102.Weight = 0.5;
		xrTableCell103.Name = "xrTableCell103";
		xrTableCell103.Text = "-";
		xrTableCell103.Weight = 0.18145166609464247;
		xrTableCell104.Name = "xrTableCell104";
		xrTableCell104.Text = "-";
		xrTableCell104.Weight = 0.18147099553789625;
		xrTableCell105.Name = "xrTableCell105";
		xrTableCell105.Text = "-";
		xrTableCell105.Weight = 0.18147099839594621;
		xrTableCell107.ForeColor = Color.Maroon;
		xrTableCell107.Name = "xrTableCell107";
		xrTableCell107.StylePriority.UseForeColor = false;
		xrTableCell107.Text = "64";
		xrTableCell107.Weight = 0.18151386922557777;
		xrTableCell97.Name = "xrTableCell97";
		xrTableCell97.Text = "64";
		xrTableCell97.Weight = 0.23068831635096435;
		xrTableCell108.ForeColor = Color.Maroon;
		xrTableCell108.Name = "xrTableCell108";
		xrTableCell108.StylePriority.UseForeColor = false;
		xrTableCell108.Text = "C4";
		xrTableCell108.Weight = 0.18147703820204447;
		xrTableCell109.Name = "xrTableCell109";
		xrTableCell109.Text = "Subject Comment";
		xrTableCell109.Weight = 0.9526334515692156;
		xrTableCell110.Name = "xrTableCell110";
		xrTableCell110.Text = "KJ";
		xrTableCell110.Weight = 0.22782266622776676;
		xrTableRow13.Cells.AddRange(new XRTableCell[9] { xrTableCell111, xrTableCell112, xrTableCell113, xrTableCell114, xrTableCell116, xrTableCell106, xrTableCell117, xrTableCell118, xrTableCell119 });
		xrTableRow13.Name = "xrTableRow13";
		xrTableRow13.Weight = 1.0;
		xrTableCell111.Name = "xrTableCell111";
		xrTableCell111.StylePriority.UseTextAlignment = false;
		xrTableCell111.Text = "527-Agriculture";
		xrTableCell111.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell111.Weight = 0.5;
		xrTableCell112.Name = "xrTableCell112";
		xrTableCell112.Text = "-";
		xrTableCell112.Weight = 0.18145166609464247;
		xrTableCell113.Name = "xrTableCell113";
		xrTableCell113.Text = "-";
		xrTableCell113.Weight = 0.18147099553789625;
		xrTableCell114.Name = "xrTableCell114";
		xrTableCell114.Text = "-";
		xrTableCell114.Weight = 0.18147099839594621;
		xrTableCell116.ForeColor = Color.Maroon;
		xrTableCell116.Name = "xrTableCell116";
		xrTableCell116.StylePriority.UseForeColor = false;
		xrTableCell116.Text = "70";
		xrTableCell116.Weight = 0.18151386922557777;
		xrTableCell106.Name = "xrTableCell106";
		xrTableCell106.Text = "70";
		xrTableCell106.Weight = 0.23068831635096435;
		xrTableCell117.ForeColor = Color.Maroon;
		xrTableCell117.Name = "xrTableCell117";
		xrTableCell117.StylePriority.UseForeColor = false;
		xrTableCell117.Text = "D2";
		xrTableCell117.Weight = 0.18147703820204447;
		xrTableCell118.Name = "xrTableCell118";
		xrTableCell118.Text = "Subject Comment";
		xrTableCell118.Weight = 0.9526334515692156;
		xrTableCell119.Name = "xrTableCell119";
		xrTableCell119.Text = "BKJ";
		xrTableCell119.Weight = 0.22782266622776676;
		xrTableRow14.Cells.AddRange(new XRTableCell[9] { xrTableCell120, xrTableCell121, xrTableCell122, xrTableCell123, xrTableCell125, xrTableCell115, xrTableCell126, xrTableCell127, xrTableCell128 });
		xrTableRow14.Name = "xrTableRow14";
		xrTableRow14.Weight = 1.0;
		xrTableCell120.Name = "xrTableCell120";
		xrTableCell120.StylePriority.UseTextAlignment = false;
		xrTableCell120.Text = "535-Physics";
		xrTableCell120.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell120.Weight = 0.5;
		xrTableCell121.Name = "xrTableCell121";
		xrTableCell121.Text = "-";
		xrTableCell121.Weight = 0.18145166609464247;
		xrTableCell122.Name = "xrTableCell122";
		xrTableCell122.Text = "-";
		xrTableCell122.Weight = 0.18147099553789625;
		xrTableCell123.Name = "xrTableCell123";
		xrTableCell123.Text = "-";
		xrTableCell123.Weight = 0.18147099839594621;
		xrTableCell125.ForeColor = Color.Maroon;
		xrTableCell125.Name = "xrTableCell125";
		xrTableCell125.StylePriority.UseForeColor = false;
		xrTableCell125.Text = "74";
		xrTableCell125.Weight = 0.18151386922557777;
		xrTableCell115.Name = "xrTableCell115";
		xrTableCell115.Text = "74";
		xrTableCell115.Weight = 0.23068831635096435;
		xrTableCell126.ForeColor = Color.Maroon;
		xrTableCell126.Name = "xrTableCell126";
		xrTableCell126.StylePriority.UseForeColor = false;
		xrTableCell126.Text = "D2";
		xrTableCell126.Weight = 0.18147703820204447;
		xrTableCell127.Name = "xrTableCell127";
		xrTableCell127.Text = "Subject Comment";
		xrTableCell127.Weight = 0.9526334515692156;
		xrTableCell128.Name = "xrTableCell128";
		xrTableCell128.Text = "NP";
		xrTableCell128.Weight = 0.22782266622776676;
		xrTableRow15.Cells.AddRange(new XRTableCell[9] { xrTableCell129, xrTableCell130, xrTableCell131, xrTableCell132, xrTableCell134, xrTableCell124, xrTableCell135, xrTableCell136, xrTableCell137 });
		xrTableRow15.Name = "xrTableRow15";
		xrTableRow15.Weight = 1.0;
		xrTableCell129.Name = "xrTableCell129";
		xrTableCell129.StylePriority.UseTextAlignment = false;
		xrTableCell129.Text = "545-Chemistry";
		xrTableCell129.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell129.Weight = 0.5;
		xrTableCell130.Name = "xrTableCell130";
		xrTableCell130.Text = "-";
		xrTableCell130.Weight = 0.18145166609464247;
		xrTableCell131.Name = "xrTableCell131";
		xrTableCell131.Text = "-";
		xrTableCell131.Weight = 0.18147099553789625;
		xrTableCell132.Name = "xrTableCell132";
		xrTableCell132.Text = "-";
		xrTableCell132.Weight = 0.18147099839594621;
		xrTableCell134.ForeColor = Color.Maroon;
		xrTableCell134.Name = "xrTableCell134";
		xrTableCell134.StylePriority.UseForeColor = false;
		xrTableCell134.Text = "56";
		xrTableCell134.Weight = 0.18151386922557777;
		xrTableCell124.Name = "xrTableCell124";
		xrTableCell124.Text = "56";
		xrTableCell124.Weight = 0.23068831635096435;
		xrTableCell135.ForeColor = Color.Maroon;
		xrTableCell135.Name = "xrTableCell135";
		xrTableCell135.StylePriority.UseForeColor = false;
		xrTableCell135.Text = "C5";
		xrTableCell135.Weight = 0.18147703820204447;
		xrTableCell136.Name = "xrTableCell136";
		xrTableCell136.Text = "Subject Comment";
		xrTableCell136.Weight = 0.9526334515692156;
		xrTableCell137.Name = "xrTableCell137";
		xrTableCell137.Text = "DM";
		xrTableCell137.Weight = 0.22782266622776676;
		xrTableRow16.Cells.AddRange(new XRTableCell[9] { xrTableCell138, xrTableCell139, xrTableCell140, xrTableCell141, xrTableCell143, xrTableCell133, xrTableCell144, xrTableCell145, xrTableCell146 });
		xrTableRow16.Name = "xrTableRow16";
		xrTableRow16.Weight = 1.0;
		xrTableCell138.Name = "xrTableCell138";
		xrTableCell138.StylePriority.UseTextAlignment = false;
		xrTableCell138.Text = "553-Biology";
		xrTableCell138.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell138.Weight = 0.5;
		xrTableCell139.Name = "xrTableCell139";
		xrTableCell139.Text = "-";
		xrTableCell139.Weight = 0.18145166609464247;
		xrTableCell140.Name = "xrTableCell140";
		xrTableCell140.Text = "-";
		xrTableCell140.Weight = 0.18147099553789625;
		xrTableCell141.Name = "xrTableCell141";
		xrTableCell141.Text = "-";
		xrTableCell141.Weight = 0.18147099839594621;
		xrTableCell143.ForeColor = Color.Maroon;
		xrTableCell143.Name = "xrTableCell143";
		xrTableCell143.StylePriority.UseForeColor = false;
		xrTableCell143.Text = "65";
		xrTableCell143.Weight = 0.18151386922557777;
		xrTableCell133.Name = "xrTableCell133";
		xrTableCell133.Text = "65";
		xrTableCell133.Weight = 0.23068831635096435;
		xrTableCell144.ForeColor = Color.Maroon;
		xrTableCell144.Name = "xrTableCell144";
		xrTableCell144.StylePriority.UseForeColor = false;
		xrTableCell144.Text = "C3";
		xrTableCell144.Weight = 0.18147703820204447;
		xrTableCell145.Name = "xrTableCell145";
		xrTableCell145.Text = "Subject Comment";
		xrTableCell145.Weight = 0.9526334515692156;
		xrTableCell146.Name = "xrTableCell146";
		xrTableCell146.Text = "KM";
		xrTableCell146.Weight = 0.22782266622776676;
		xrTableRow17.Cells.AddRange(new XRTableCell[9] { xrTableCell147, xrTableCell148, xrTableCell149, xrTableCell150, xrTableCell152, xrTableCell142, xrTableCell153, xrTableCell154, xrTableCell155 });
		xrTableRow17.Name = "xrTableRow17";
		xrTableRow17.Weight = 1.0;
		xrTableCell147.Name = "xrTableCell147";
		xrTableCell147.StylePriority.UseTextAlignment = false;
		xrTableCell147.Text = "610-Fine-Art";
		xrTableCell147.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell147.Weight = 0.5;
		xrTableCell148.Name = "xrTableCell148";
		xrTableCell148.Text = "-";
		xrTableCell148.Weight = 0.18145166609464247;
		xrTableCell149.Name = "xrTableCell149";
		xrTableCell149.Text = "-";
		xrTableCell149.Weight = 0.18147099553789625;
		xrTableCell150.Name = "xrTableCell150";
		xrTableCell150.Text = "-";
		xrTableCell150.Weight = 0.18147099839594621;
		xrTableCell152.ForeColor = Color.Maroon;
		xrTableCell152.Name = "xrTableCell152";
		xrTableCell152.StylePriority.UseForeColor = false;
		xrTableCell152.Text = "70";
		xrTableCell152.Weight = 0.18151386922557777;
		xrTableCell142.Name = "xrTableCell142";
		xrTableCell142.Text = "70";
		xrTableCell142.Weight = 0.23068831635096435;
		xrTableCell153.ForeColor = Color.Maroon;
		xrTableCell153.Name = "xrTableCell153";
		xrTableCell153.StylePriority.UseForeColor = false;
		xrTableCell153.Text = "D2";
		xrTableCell153.Weight = 0.18147703820204447;
		xrTableCell154.Name = "xrTableCell154";
		xrTableCell154.Text = "Subject Comment";
		xrTableCell154.Weight = 0.9526334515692156;
		xrTableCell155.Name = "xrTableCell155";
		xrTableCell155.Text = "LP";
		xrTableCell155.Weight = 0.22782266622776676;
		xrTableRow18.Cells.AddRange(new XRTableCell[9] { xrTableCell156, xrTableCell157, xrTableCell158, xrTableCell159, xrTableCell161, xrTableCell151, xrTableCell162, xrTableCell163, xrTableCell164 });
		xrTableRow18.Name = "xrTableRow18";
		xrTableRow18.Weight = 1.0;
		xrTableCell156.Name = "xrTableCell156";
		xrTableCell156.StylePriority.UseTextAlignment = false;
		xrTableCell156.Text = "800-Commerce";
		xrTableCell156.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell156.Weight = 0.5;
		xrTableCell157.Name = "xrTableCell157";
		xrTableCell157.Text = "-";
		xrTableCell157.Weight = 0.18145166609464247;
		xrTableCell158.Name = "xrTableCell158";
		xrTableCell158.Text = "-";
		xrTableCell158.Weight = 0.18147099553789625;
		xrTableCell159.Name = "xrTableCell159";
		xrTableCell159.Text = "-";
		xrTableCell159.Weight = 0.18147099839594621;
		xrTableCell161.ForeColor = Color.Maroon;
		xrTableCell161.Name = "xrTableCell161";
		xrTableCell161.StylePriority.UseForeColor = false;
		xrTableCell161.Text = "78";
		xrTableCell161.Weight = 0.18151386922557777;
		xrTableCell151.Name = "xrTableCell151";
		xrTableCell151.Text = "78";
		xrTableCell151.Weight = 0.23068831635096435;
		xrTableCell162.ForeColor = Color.Maroon;
		xrTableCell162.Name = "xrTableCell162";
		xrTableCell162.StylePriority.UseForeColor = false;
		xrTableCell162.Text = "D1";
		xrTableCell162.Weight = 0.18147703820204447;
		xrTableCell163.Name = "xrTableCell163";
		xrTableCell163.Text = "Subject Comment";
		xrTableCell163.Weight = 0.9526334515692156;
		xrTableCell164.Name = "xrTableCell164";
		xrTableCell164.Text = "JK";
		xrTableCell164.Weight = 0.22782266622776676;
		xrTableRow19.Cells.AddRange(new XRTableCell[9] { xrTableCell165, xrTableCell166, xrTableCell167, xrTableCell168, xrTableCell170, xrTableCell160, xrTableCell171, xrTableCell172, xrTableCell173 });
		xrTableRow19.Name = "xrTableRow19";
		xrTableRow19.Weight = 1.0;
		xrTableCell165.Name = "xrTableCell165";
		xrTableCell165.StylePriority.UseTextAlignment = false;
		xrTableCell165.Text = "840-Computer";
		xrTableCell165.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell165.Weight = 0.5;
		xrTableCell166.Name = "xrTableCell166";
		xrTableCell166.Text = "-";
		xrTableCell166.Weight = 0.18145166609464247;
		xrTableCell167.Name = "xrTableCell167";
		xrTableCell167.Text = "-";
		xrTableCell167.Weight = 0.18147099553789625;
		xrTableCell168.Name = "xrTableCell168";
		xrTableCell168.Text = "-";
		xrTableCell168.Weight = 0.18147099839594621;
		xrTableCell170.ForeColor = Color.Maroon;
		xrTableCell170.Name = "xrTableCell170";
		xrTableCell170.StylePriority.UseForeColor = false;
		xrTableCell170.Text = "80";
		xrTableCell170.Weight = 0.18151386922557777;
		xrTableCell160.Name = "xrTableCell160";
		xrTableCell160.Text = "80";
		xrTableCell160.Weight = 0.23068831635096435;
		xrTableCell171.ForeColor = Color.Maroon;
		xrTableCell171.Name = "xrTableCell171";
		xrTableCell171.StylePriority.UseForeColor = false;
		xrTableCell171.Text = "D1";
		xrTableCell171.Weight = 0.18147703820204447;
		xrTableCell172.Name = "xrTableCell172";
		xrTableCell172.Text = "Subject Comment";
		xrTableCell172.Weight = 0.9526334515692156;
		xrTableCell173.Name = "xrTableCell173";
		xrTableCell173.Text = "SM";
		xrTableCell173.Weight = 0.22782266622776676;
		xrTableRow20.Cells.AddRange(new XRTableCell[5] { xrTableCell175, xrTableCell176, xrTableCell179, xrTableCell180, xrTableCell182 });
		xrTableRow20.Name = "xrTableRow20";
		xrTableRow20.Weight = 1.0;
		xrTableCell175.Name = "xrTableCell175";
		xrTableCell175.StylePriority.UseTextAlignment = false;
		xrTableCell175.Text = "Total Marks";
		xrTableCell175.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell175.Weight = 1.044393713452949;
		xrTableCell176.Name = "xrTableCell176";
		xrTableCell176.Text = "922";
		xrTableCell176.Weight = 0.18147682233964985;
		xrTableCell179.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell179.Name = "xrTableCell179";
		xrTableCell179.StylePriority.UseFont = false;
		xrTableCell179.Text = "AVERAGE MARKS";
		xrTableCell179.Weight = 0.4122023347347902;
		xrTableCell180.Name = "xrTableCell180";
		xrTableCell180.Text = "65.86";
		xrTableCell180.Weight = 0.952633154848233;
		xrTableCell182.Name = "xrTableCell182";
		xrTableCell182.Weight = 0.22782297622843184;
		TopMargin.HeightF = 20f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		BottomMargin.HeightF = 20f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		ReportHeader.Controls.AddRange(new XRControl[16]
		{
			xrSubreport1, xrLabel39, xrLabel13, xrLabel12, xrLabel49, xrLabel48, xrLabel42, xrLabel11, xrLabel6, xrLabel1,
			xrPictureBox2, xrLabel10, xrLabel9, xrLabel8, xrLabel7, xrTable1
		});
		ReportHeader.HeightF = 273.9584f;
		ReportHeader.Name = "ReportHeader";
		xrLabel39.Font = new DXFont("Tahoma", 10f);
		xrLabel39.LocationFloat = new PointFloat(470.9999f, 174f);
		xrLabel39.Name = "xrLabel39";
		xrLabel39.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel39.SizeF = new SizeF(36.42569f, 23f);
		xrLabel39.StylePriority.UseFont = false;
		xrLabel39.StylePriority.UseTextAlignment = false;
		xrLabel39.Text = "Sex:";
		xrLabel39.TextAlignment = TextAlignment.BottomLeft;
		xrLabel13.Font = new DXFont("Tahoma", 10f);
		xrLabel13.LocationFloat = new PointFloat(91f, 214f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(81.00001f, 23.00002f);
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Student No.";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		xrLabel12.Font = new DXFont("Tahoma", 10f);
		xrLabel12.LocationFloat = new PointFloat(91f, 174f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(48f, 22.99998f);
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Name:";
		xrLabel12.TextAlignment = TextAlignment.BottomLeft;
		xrLabel49.Font = new DXFont("Tahoma", 10f);
		xrLabel49.LocationFloat = new PointFloat(617.9999f, 214f);
		xrLabel49.Name = "xrLabel49";
		xrLabel49.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel49.SizeF = new SizeF(55.99988f, 23.00002f);
		xrLabel49.StylePriority.UseFont = false;
		xrLabel49.StylePriority.UseTextAlignment = false;
		xrLabel49.Text = "Stream:";
		xrLabel49.TextAlignment = TextAlignment.BottomLeft;
		xrLabel48.Font = new DXFont("Tahoma", 10f);
		xrLabel48.LocationFloat = new PointFloat(619f, 174f);
		xrLabel48.Name = "xrLabel48";
		xrLabel48.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel48.SizeF = new SizeF(42.99994f, 22.99999f);
		xrLabel48.StylePriority.UseFont = false;
		xrLabel48.StylePriority.UseTextAlignment = false;
		xrLabel48.Text = "Term:";
		xrLabel48.TextAlignment = TextAlignment.BottomLeft;
		xrLabel42.Font = new DXFont("Tahoma", 10f);
		xrLabel42.LocationFloat = new PointFloat(473f, 214f);
		xrLabel42.Name = "xrLabel42";
		xrLabel42.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel42.SizeF = new SizeF(42.42566f, 23.00002f);
		xrLabel42.StylePriority.UseFont = false;
		xrLabel42.StylePriority.UseTextAlignment = false;
		xrLabel42.Text = "Class:";
		xrLabel42.TextAlignment = TextAlignment.BottomLeft;
		xrLabel11.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel11.Borders = BorderSide.Bottom;
		xrLabel11.Font = new DXFont("Tahoma", 10f);
		xrLabel11.ForeColor = Color.Maroon;
		xrLabel11.LocationFloat = new PointFloat(661.9999f, 174f);
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(125.0001f, 23f);
		xrLabel11.StylePriority.UseBorderDashStyle = false;
		xrLabel11.StylePriority.UseBorders = false;
		xrLabel11.StylePriority.UseFont = false;
		xrLabel11.StylePriority.UseForeColor = false;
		xrLabel11.StylePriority.UseTextAlignment = false;
		xrLabel11.Text = "TermIII-2010";
		xrLabel11.TextAlignment = TextAlignment.BottomCenter;
		xrLabel6.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel6.Borders = BorderSide.Bottom;
		xrLabel6.Font = new DXFont("Tahoma", 10f);
		xrLabel6.ForeColor = Color.Maroon;
		xrLabel6.LocationFloat = new PointFloat(507.4257f, 174f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(111.1486f, 22.99998f);
		xrLabel6.StylePriority.UseBorderDashStyle = false;
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "M";
		xrLabel6.TextAlignment = TextAlignment.BottomCenter;
		xrLabel1.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel1.Borders = BorderSide.Bottom;
		xrLabel1.Font = new DXFont("Tahoma", 10f);
		xrLabel1.ForeColor = Color.Maroon;
		xrLabel1.LocationFloat = new PointFloat(139f, 174f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(332f, 22.99998f);
		xrLabel1.StylePriority.UseBorderDashStyle = false;
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Sitantebe Moses Peter";
		xrLabel1.TextAlignment = TextAlignment.BottomCenter;
		xrPictureBox2.Borders = BorderSide.None;
		xrPictureBox2.Image = (Image)componentResourceManager.GetObject("xrPictureBox2.Image");
		xrPictureBox2.LocationFloat = new PointFloat(1.999998f, 172f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.SizeF = new SizeF(80.20834f, 74.04169f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox2.StylePriority.UseBorders = false;
		xrLabel10.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel10.Borders = BorderSide.Bottom;
		xrLabel10.Font = new DXFont("Tahoma", 10f);
		xrLabel10.ForeColor = Color.Maroon;
		xrLabel10.LocationFloat = new PointFloat(674f, 214f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(112.9998f, 23.00002f);
		xrLabel10.StylePriority.UseBorderDashStyle = false;
		xrLabel10.StylePriority.UseBorders = false;
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseForeColor = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.Text = "East";
		xrLabel10.TextAlignment = TextAlignment.BottomCenter;
		xrLabel9.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel9.Borders = BorderSide.Bottom;
		xrLabel9.Font = new DXFont("Tahoma", 10f);
		xrLabel9.ForeColor = Color.Maroon;
		xrLabel9.LocationFloat = new PointFloat(172f, 214f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(300.9999f, 23.00002f);
		xrLabel9.StylePriority.UseBorderDashStyle = false;
		xrLabel9.StylePriority.UseBorders = false;
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseForeColor = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "INT-2010-678";
		xrLabel9.TextAlignment = TextAlignment.BottomCenter;
		xrLabel8.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel8.Borders = BorderSide.Bottom;
		xrLabel8.Font = new DXFont("Tahoma", 10f);
		xrLabel8.ForeColor = Color.Maroon;
		xrLabel8.LocationFloat = new PointFloat(515.4256f, 214f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(102.1489f, 23.00003f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseForeColor = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "S.2";
		xrLabel8.TextAlignment = TextAlignment.BottomCenter;
		xrLabel7.BackColor = Color.Purple;
		xrLabel7.Font = new DXFont("Tw Cen MT Condensed", 14.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel7.ForeColor = Color.White;
		xrLabel7.LocationFloat = new PointFloat(1.999982f, 143f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(784.9999f, 22.99998f);
		xrLabel7.StylePriority.UseBackColor = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseForeColor = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "TERMINAL REPORT CARD";
		xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
		xrTable1.BackColor = Color.Purple;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable1.ForeColor = Color.White;
		xrTable1.LocationFloat = new PointFloat(0f, 248.9584f);
		xrTable1.Name = "xrTable1";
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(787f, 24.99997f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseForeColor = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[9] { xrTableCell4, xrTableCell174, xrTableCell1, xrTableCell8, xrTableCell5, xrTableCell2, xrTableCell6, xrTableCell3, xrTableCell9 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Text = "SUBJECT";
		xrTableCell4.Weight = 0.532192545393231;
		xrTableCell174.Name = "xrTableCell174";
		xrTableCell174.Text = "HoP";
		xrTableCell174.Weight = 0.193161321731874;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Text = "BOT";
		xrTableCell1.Weight = 0.19316132173187398;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Text = "MOT";
		xrTableCell8.Weight = 0.19316132458992405;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.Text = "EOT";
		xrTableCell5.Weight = 0.193161324589924;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Text = "AvMark";
		xrTableCell2.Weight = 0.24554092749819764;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "Grade";
		xrTableCell6.Weight = 0.19316140937863088;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.Text = "Comment";
		xrTableCell3.Weight = 1.0077817970807044;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Text = "Initials";
		xrTableCell9.Weight = 0.24867802800564;
		ReportFooter.Controls.AddRange(new XRControl[24]
		{
			xrTable2, xrLabel29, xrLabel32, xrLabel28, xrLabel26, xrLabel27, xrLabel33, xrLabel37, xrLabel38, xrLabel36,
			xrLabel34, xrLabel35, xrLabel17, xrLabel47, xrLabel59, xrLabel41, xrLabel16, xrLabel15, xrLabel51, xrLabel20,
			xrLabel18, xrLabel40, xrLabel50, xrLabel19
		});
		ReportFooter.HeightF = 271.875f;
		ReportFooter.Name = "ReportFooter";
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Tahoma", 10f);
		xrTable2.LocationFloat = new PointFloat(0f, 213.9999f);
		xrTable2.Name = "xrTable2";
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow4, xrTableRow3 });
		xrTable2.SizeF = new SizeF(786.9999f, 49.99997f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow4.Cells.AddRange(new XRTableCell[10] { xrTableCell15, xrTableCell10, xrTableCell13, xrTableCell25, xrTableCell11, xrTableCell23, xrTableCell12, xrTableCell21, xrTableCell17, xrTableCell19 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "GRADE";
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 0.7539062881469727;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "D1";
		xrTableCell10.Weight = 0.24609371185302736;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Text = "D2";
		xrTableCell13.Weight = 0.24607501983642577;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Text = "C3";
		xrTableCell25.Weight = 0.2460750198364258;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.Text = "C4";
		xrTableCell11.Weight = 0.24607501983642582;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.Text = "C5";
		xrTableCell23.Weight = 0.24607501983642577;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Text = "C6";
		xrTableCell12.Weight = 0.24607501983642577;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Text = "P7";
		xrTableCell21.Weight = 0.2460750198364258;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Text = "P8";
		xrTableCell17.Weight = 0.24607501983642574;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.Text = "F9";
		xrTableCell19.Weight = 0.24607481956481933;
		xrTableRow3.Cells.AddRange(new XRTableCell[10] { xrTableCell16, xrTableCell14, xrTableCell18, xrTableCell26, xrTableCell20, xrTableCell24, xrTableCell22, xrTableCell27, xrTableCell28, xrTableCell29 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "SCORE RANGE";
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.Weight = 0.7539062881469727;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.Text = "75-100";
		xrTableCell14.Weight = 0.24609371185302736;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.Text = "70-74";
		xrTableCell18.Weight = 0.24607501979859833;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.Text = "65-69";
		xrTableCell26.Weight = 0.24607501979859836;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.Text = "60-64";
		xrTableCell20.Weight = 0.2460750197985983;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Text = "50-59";
		xrTableCell24.Weight = 0.24607501979859833;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Text = "45-49";
		xrTableCell22.Weight = 0.2460750197985983;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Text = "40-44";
		xrTableCell27.Weight = 0.2460750197985983;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Text = "35-39";
		xrTableCell28.Weight = 0.24607501979859833;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.Text = "0-34";
		xrTableCell29.Weight = 0.24607481982961155;
		xrLabel29.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel29.Borders = BorderSide.Bottom;
		xrLabel29.Font = new DXFont("Tahoma", 10f);
		xrLabel29.LocationFloat = new PointFloat(503.9999f, 31.99997f);
		xrLabel29.Name = "xrLabel29";
		xrLabel29.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel29.SizeF = new SizeF(282.9998f, 23f);
		xrLabel29.StylePriority.UseBorderDashStyle = false;
		xrLabel29.StylePriority.UseBorders = false;
		xrLabel29.StylePriority.UseFont = false;
		xrLabel29.StylePriority.UseTextAlignment = false;
		xrLabel29.TextAlignment = TextAlignment.BottomCenter;
		xrLabel32.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel32.Borders = BorderSide.Bottom;
		xrLabel32.Font = new DXFont("Tahoma", 10f);
		xrLabel32.LocationFloat = new PointFloat(503.9999f, 90.00002f);
		xrLabel32.Name = "xrLabel32";
		xrLabel32.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel32.SizeF = new SizeF(282.9997f, 23f);
		xrLabel32.StylePriority.UseBorderDashStyle = false;
		xrLabel32.StylePriority.UseBorders = false;
		xrLabel32.StylePriority.UseFont = false;
		xrLabel32.StylePriority.UseTextAlignment = false;
		xrLabel32.TextAlignment = TextAlignment.BottomCenter;
		xrLabel28.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel28.Borders = BorderSide.Bottom;
		xrLabel28.Font = new DXFont("Comic Sans MS", 10f);
		xrLabel28.ForeColor = Color.Blue;
		xrLabel28.LocationFloat = new PointFloat(105f, 62.00002f);
		xrLabel28.Name = "xrLabel28";
		xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel28.SizeF = new SizeF(681.9998f, 22.99999f);
		xrLabel28.StylePriority.UseBorderDashStyle = false;
		xrLabel28.StylePriority.UseBorders = false;
		xrLabel28.StylePriority.UseFont = false;
		xrLabel28.StylePriority.UseForeColor = false;
		xrLabel28.StylePriority.UseTextAlignment = false;
		xrLabel28.Text = "DOS's Comment";
		xrLabel28.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel26.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel26.Borders = BorderSide.Bottom;
		xrLabel26.Font = new DXFont("Comic Sans MS", 10f);
		xrLabel26.ForeColor = Color.Blue;
		xrLabel26.LocationFloat = new PointFloat(172f, 0f);
		xrLabel26.Name = "xrLabel26";
		xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel26.SizeF = new SizeF(614.9998f, 22.99999f);
		xrLabel26.StylePriority.UseBorderDashStyle = false;
		xrLabel26.StylePriority.UseBorders = false;
		xrLabel26.StylePriority.UseFont = false;
		xrLabel26.StylePriority.UseForeColor = false;
		xrLabel26.StylePriority.UseTextAlignment = false;
		xrLabel26.Text = "Class Teacher's comment";
		xrLabel26.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel27.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel27.Borders = BorderSide.Bottom;
		xrLabel27.Font = new DXFont("Comic Sans MS", 10f);
		xrLabel27.ForeColor = Color.Blue;
		xrLabel27.LocationFloat = new PointFloat(160.0001f, 119.9999f);
		xrLabel27.Name = "xrLabel27";
		xrLabel27.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel27.SizeF = new SizeF(626.9995f, 22.99999f);
		xrLabel27.StylePriority.UseBorderDashStyle = false;
		xrLabel27.StylePriority.UseBorders = false;
		xrLabel27.StylePriority.UseFont = false;
		xrLabel27.StylePriority.UseForeColor = false;
		xrLabel27.StylePriority.UseTextAlignment = false;
		xrLabel27.Text = "Head Teacher's comment";
		xrLabel27.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel33.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel33.Borders = BorderSide.Bottom;
		xrLabel33.Font = new DXFont("Tahoma", 10f);
		xrLabel33.LocationFloat = new PointFloat(503.9999f, 150f);
		xrLabel33.Name = "xrLabel33";
		xrLabel33.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel33.SizeF = new SizeF(282.9998f, 22.99998f);
		xrLabel33.StylePriority.UseBorderDashStyle = false;
		xrLabel33.StylePriority.UseBorders = false;
		xrLabel33.StylePriority.UseFont = false;
		xrLabel33.StylePriority.UseTextAlignment = false;
		xrLabel33.TextAlignment = TextAlignment.BottomCenter;
		xrLabel37.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel37.Borders = BorderSide.Bottom;
		xrLabel37.Font = new DXFont("Tahoma", 10f);
		xrLabel37.LocationFloat = new PointFloat(439.9402f, 180f);
		xrLabel37.Name = "xrLabel37";
		xrLabel37.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel37.SizeF = new SizeF(140.0597f, 23f);
		xrLabel37.StylePriority.UseBorderDashStyle = false;
		xrLabel37.StylePriority.UseBorders = false;
		xrLabel37.StylePriority.UseFont = false;
		xrLabel37.StylePriority.UseTextAlignment = false;
		xrLabel37.TextAlignment = TextAlignment.BottomCenter;
		xrLabel38.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel38.Borders = BorderSide.Bottom;
		xrLabel38.Font = new DXFont("Tahoma", 10f);
		xrLabel38.LocationFloat = new PointFloat(619.5742f, 180f);
		xrLabel38.Name = "xrLabel38";
		xrLabel38.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel38.SizeF = new SizeF(167.4257f, 23f);
		xrLabel38.StylePriority.UseBorderDashStyle = false;
		xrLabel38.StylePriority.UseBorders = false;
		xrLabel38.StylePriority.UseFont = false;
		xrLabel38.StylePriority.UseTextAlignment = false;
		xrLabel38.TextAlignment = TextAlignment.BottomCenter;
		xrLabel36.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel36.Borders = BorderSide.Bottom;
		xrLabel36.Font = new DXFont("Tahoma", 10f);
		xrLabel36.LocationFloat = new PointFloat(0f, 150f);
		xrLabel36.Name = "xrLabel36";
		xrLabel36.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel36.SizeF = new SizeF(422.4258f, 22.99998f);
		xrLabel36.StylePriority.UseBorderDashStyle = false;
		xrLabel36.StylePriority.UseBorders = false;
		xrLabel36.StylePriority.UseFont = false;
		xrLabel36.StylePriority.UseTextAlignment = false;
		xrLabel36.TextAlignment = TextAlignment.BottomCenter;
		xrLabel34.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel34.Borders = BorderSide.Bottom;
		xrLabel34.Font = new DXFont("Tahoma", 10f);
		xrLabel34.LocationFloat = new PointFloat(0f, 32f);
		xrLabel34.Name = "xrLabel34";
		xrLabel34.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel34.SizeF = new SizeF(422.4257f, 23f);
		xrLabel34.StylePriority.UseBorderDashStyle = false;
		xrLabel34.StylePriority.UseBorders = false;
		xrLabel34.StylePriority.UseFont = false;
		xrLabel34.StylePriority.UseTextAlignment = false;
		xrLabel34.TextAlignment = TextAlignment.BottomCenter;
		xrLabel35.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel35.Borders = BorderSide.Bottom;
		xrLabel35.Font = new DXFont("Tahoma", 10f);
		xrLabel35.LocationFloat = new PointFloat(0f, 89.99999f);
		xrLabel35.Name = "xrLabel35";
		xrLabel35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel35.SizeF = new SizeF(422.4257f, 23f);
		xrLabel35.StylePriority.UseBorderDashStyle = false;
		xrLabel35.StylePriority.UseBorders = false;
		xrLabel35.StylePriority.UseFont = false;
		xrLabel35.StylePriority.UseTextAlignment = false;
		xrLabel35.TextAlignment = TextAlignment.BottomCenter;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.Font = new DXFont("Tahoma", 10f);
		xrLabel17.LocationFloat = new PointFloat(0f, 119.9999f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(160f, 23.00002f);
		xrLabel17.StylePriority.UseBorders = false;
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "Headteacher's Comment:";
		xrLabel17.TextAlignment = TextAlignment.BottomLeft;
		xrLabel47.Borders = BorderSide.None;
		xrLabel47.Font = new DXFont("Tahoma", 10f);
		xrLabel47.LocationFloat = new PointFloat(0f, 0f);
		xrLabel47.Name = "xrLabel47";
		xrLabel47.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel47.SizeF = new SizeF(172f, 22.99999f);
		xrLabel47.StylePriority.UseBorders = false;
		xrLabel47.StylePriority.UseFont = false;
		xrLabel47.StylePriority.UseTextAlignment = false;
		xrLabel47.Text = "Class Teacher's Comment:";
		xrLabel47.TextAlignment = TextAlignment.BottomLeft;
		xrLabel59.Borders = BorderSide.None;
		xrLabel59.Font = new DXFont("Tahoma", 10f);
		xrLabel59.LocationFloat = new PointFloat(428f, 32f);
		xrLabel59.Name = "xrLabel59";
		xrLabel59.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel59.SizeF = new SizeF(70.42563f, 22.99998f);
		xrLabel59.StylePriority.UseBorders = false;
		xrLabel59.StylePriority.UseFont = false;
		xrLabel59.StylePriority.UseTextAlignment = false;
		xrLabel59.Text = "Signature:";
		xrLabel59.TextAlignment = TextAlignment.BottomLeft;
		xrLabel41.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel41.Borders = BorderSide.None;
		xrLabel41.Font = new DXFont("Comic Sans MS", 8.5f, DXFontStyle.Bold);
		xrLabel41.ForeColor = Color.Blue;
		xrLabel41.LocationFloat = new PointFloat(269.8017f, 180f);
		xrLabel41.Name = "xrLabel41";
		xrLabel41.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel41.SizeF = new SizeF(78.19824f, 22.99995f);
		xrLabel41.StylePriority.UseBorderDashStyle = false;
		xrLabel41.StylePriority.UseBorders = false;
		xrLabel41.StylePriority.UseFont = false;
		xrLabel41.StylePriority.UseForeColor = false;
		xrLabel41.StylePriority.UseTextAlignment = false;
		xrLabel41.Text = "28-4-2010";
		xrLabel41.TextAlignment = TextAlignment.BottomCenter;
		xrLabel16.Borders = BorderSide.None;
		xrLabel16.Font = new DXFont("Tahoma", 10f);
		xrLabel16.LocationFloat = new PointFloat(428f, 89.99999f);
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(70.42563f, 23.00002f);
		xrLabel16.StylePriority.UseBorders = false;
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.StylePriority.UseTextAlignment = false;
		xrLabel16.Text = "Signature:";
		xrLabel16.TextAlignment = TextAlignment.BottomLeft;
		xrLabel15.Borders = BorderSide.None;
		xrLabel15.Font = new DXFont("Tahoma", 10f);
		xrLabel15.LocationFloat = new PointFloat(0f, 62.00002f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(105f, 22.99999f);
		xrLabel15.StylePriority.UseBorders = false;
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "DOS Comment:";
		xrLabel15.TextAlignment = TextAlignment.BottomLeft;
		xrLabel51.Borders = BorderSide.None;
		xrLabel51.Font = new DXFont("Tahoma", 10f);
		xrLabel51.LocationFloat = new PointFloat(204f, 180f);
		xrLabel51.Name = "xrLabel51";
		xrLabel51.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel51.SizeF = new SizeF(65.80167f, 23f);
		xrLabel51.StylePriority.UseBorders = false;
		xrLabel51.StylePriority.UseFont = false;
		xrLabel51.StylePriority.UseTextAlignment = false;
		xrLabel51.Text = "Ends on:";
		xrLabel51.TextAlignment = TextAlignment.BottomLeft;
		xrLabel20.Font = new DXFont("Tahoma", 10f);
		xrLabel20.LocationFloat = new PointFloat(579.9999f, 180f);
		xrLabel20.Name = "xrLabel20";
		xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel20.SizeF = new SizeF(38.57434f, 23.00006f);
		xrLabel20.StylePriority.UseFont = false;
		xrLabel20.StylePriority.UseTextAlignment = false;
		xrLabel20.Text = "Fees";
		xrLabel20.TextAlignment = TextAlignment.BottomLeft;
		xrLabel18.Borders = BorderSide.None;
		xrLabel18.Font = new DXFont("Tahoma", 10f);
		xrLabel18.LocationFloat = new PointFloat(428f, 150f);
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(70.42563f, 23f);
		xrLabel18.StylePriority.UseBorders = false;
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.Text = "Signature:";
		xrLabel18.TextAlignment = TextAlignment.BottomLeft;
		xrLabel40.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel40.Borders = BorderSide.None;
		xrLabel40.Font = new DXFont("Comic Sans MS", 8.5f, DXFontStyle.Bold);
		xrLabel40.ForeColor = Color.Blue;
		xrLabel40.LocationFloat = new PointFloat(116f, 180f);
		xrLabel40.Name = "xrLabel40";
		xrLabel40.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel40.SizeF = new SizeF(88.00002f, 23.00008f);
		xrLabel40.StylePriority.UseBorderDashStyle = false;
		xrLabel40.StylePriority.UseBorders = false;
		xrLabel40.StylePriority.UseFont = false;
		xrLabel40.StylePriority.UseForeColor = false;
		xrLabel40.StylePriority.UseTextAlignment = false;
		xrLabel40.Text = "28-2-2010";
		xrLabel40.TextAlignment = TextAlignment.BottomCenter;
		xrLabel50.Borders = BorderSide.None;
		xrLabel50.Font = new DXFont("Tahoma", 10f);
		xrLabel50.LocationFloat = new PointFloat(0f, 180f);
		xrLabel50.Name = "xrLabel50";
		xrLabel50.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel50.SizeF = new SizeF(114.4257f, 23.00002f);
		xrLabel50.StylePriority.UseBorders = false;
		xrLabel50.StylePriority.UseFont = false;
		xrLabel50.StylePriority.UseTextAlignment = false;
		xrLabel50.Text = "Next term begins:";
		xrLabel50.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.Font = new DXFont("Tahoma", 10f);
		xrLabel19.LocationFloat = new PointFloat(347.9999f, 180f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(91.94028f, 23.00006f);
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Fees balance";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		GroupFooter1.Controls.AddRange(new XRControl[12]
		{
			xrLabel21, xrLabel30, xrLabel31, xrLabel25, xrLabel24, xrLabel23, xrLabel44, xrLabel45, xrLabel46, xrLabel14,
			xrLabel43, xrLabel22
		});
		GroupFooter1.HeightF = 93.75f;
		GroupFooter1.Name = "GroupFooter1";
		xrLabel21.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel21.Borders = BorderSide.Bottom;
		xrLabel21.Font = new DXFont("Tahoma", 10f);
		xrLabel21.ForeColor = Color.Maroon;
		xrLabel21.LocationFloat = new PointFloat(122f, 34.00002f);
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(231.0001f, 22.99999f);
		xrLabel21.StylePriority.UseBorderDashStyle = false;
		xrLabel21.StylePriority.UseBorders = false;
		xrLabel21.StylePriority.UseFont = false;
		xrLabel21.StylePriority.UseForeColor = false;
		xrLabel21.StylePriority.UseTextAlignment = false;
		xrLabel21.Text = "2";
		xrLabel21.TextAlignment = TextAlignment.BottomCenter;
		xrLabel30.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel30.Borders = BorderSide.Bottom;
		xrLabel30.Font = new DXFont("Tahoma", 10f);
		xrLabel30.ForeColor = Color.Maroon;
		xrLabel30.LocationFloat = new PointFloat(494f, 2.000013f);
		xrLabel30.Name = "xrLabel30";
		xrLabel30.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel30.SizeF = new SizeF(121f, 22.99999f);
		xrLabel30.StylePriority.UseBorderDashStyle = false;
		xrLabel30.StylePriority.UseBorders = false;
		xrLabel30.StylePriority.UseFont = false;
		xrLabel30.StylePriority.UseForeColor = false;
		xrLabel30.StylePriority.UseTextAlignment = false;
		xrLabel30.Text = "14";
		xrLabel30.TextAlignment = TextAlignment.BottomCenter;
		xrLabel31.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel31.Borders = BorderSide.Bottom;
		xrLabel31.Font = new DXFont("Tahoma", 10f);
		xrLabel31.ForeColor = Color.Maroon;
		xrLabel31.LocationFloat = new PointFloat(672f, 2.000013f);
		xrLabel31.Name = "xrLabel31";
		xrLabel31.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel31.SizeF = new SizeF(115f, 22.99999f);
		xrLabel31.StylePriority.UseBorderDashStyle = false;
		xrLabel31.StylePriority.UseBorders = false;
		xrLabel31.StylePriority.UseFont = false;
		xrLabel31.StylePriority.UseForeColor = false;
		xrLabel31.StylePriority.UseTextAlignment = false;
		xrLabel31.Text = "I";
		xrLabel31.TextAlignment = TextAlignment.BottomCenter;
		xrLabel25.Font = new DXFont("Tahoma", 10f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel25.ForeColor = Color.Black;
		xrLabel25.LocationFloat = new PointFloat(353f, 34.00002f);
		xrLabel25.Name = "xrLabel25";
		xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel25.SizeF = new SizeF(125.9999f, 23f);
		xrLabel25.StylePriority.UseFont = false;
		xrLabel25.StylePriority.UseForeColor = false;
		xrLabel25.StylePriority.UseTextAlignment = false;
		xrLabel25.Text = "Students in stream:";
		xrLabel25.TextAlignment = TextAlignment.BottomLeft;
		xrLabel24.Font = new DXFont("Tahoma", 10f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel24.ForeColor = Color.Black;
		xrLabel24.LocationFloat = new PointFloat(0.9999593f, 34.00002f);
		xrLabel24.Name = "xrLabel24";
		xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel24.SizeF = new SizeF(121f, 22.99999f);
		xrLabel24.StylePriority.UseFont = false;
		xrLabel24.StylePriority.UseForeColor = false;
		xrLabel24.StylePriority.UseTextAlignment = false;
		xrLabel24.Text = "Position in stream:";
		xrLabel24.TextAlignment = TextAlignment.BottomLeft;
		xrLabel23.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel23.Borders = BorderSide.Bottom;
		xrLabel23.Font = new DXFont("Tahoma", 10f);
		xrLabel23.ForeColor = Color.Maroon;
		xrLabel23.LocationFloat = new PointFloat(479f, 34.00002f);
		xrLabel23.Name = "xrLabel23";
		xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel23.SizeF = new SizeF(307.9998f, 23f);
		xrLabel23.StylePriority.UseBorderDashStyle = false;
		xrLabel23.StylePriority.UseBorders = false;
		xrLabel23.StylePriority.UseFont = false;
		xrLabel23.StylePriority.UseForeColor = false;
		xrLabel23.StylePriority.UseTextAlignment = false;
		xrLabel23.Text = "60";
		xrLabel23.TextAlignment = TextAlignment.BottomCenter;
		xrLabel44.Borders = BorderSide.None;
		xrLabel44.Font = new DXFont("Tahoma", 10f);
		xrLabel44.ForeColor = Color.Black;
		xrLabel44.LocationFloat = new PointFloat(187f, 2.000013f);
		xrLabel44.Name = "xrLabel44";
		xrLabel44.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel44.SizeF = new SizeF(116f, 22.99999f);
		xrLabel44.StylePriority.UseBorders = false;
		xrLabel44.StylePriority.UseFont = false;
		xrLabel44.StylePriority.UseForeColor = false;
		xrLabel44.StylePriority.UseTextAlignment = false;
		xrLabel44.Text = "Students in class:";
		xrLabel44.TextAlignment = TextAlignment.BottomLeft;
		xrLabel45.Borders = BorderSide.None;
		xrLabel45.Font = new DXFont("Tahoma", 10f);
		xrLabel45.ForeColor = Color.Black;
		xrLabel45.LocationFloat = new PointFloat(419f, 2.000013f);
		xrLabel45.Name = "xrLabel45";
		xrLabel45.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel45.SizeF = new SizeF(75f, 22.99999f);
		xrLabel45.StylePriority.UseBorders = false;
		xrLabel45.StylePriority.UseFont = false;
		xrLabel45.StylePriority.UseForeColor = false;
		xrLabel45.StylePriority.UseTextAlignment = false;
		xrLabel45.Text = "Best Eight:";
		xrLabel45.TextAlignment = TextAlignment.BottomLeft;
		xrLabel46.Borders = BorderSide.None;
		xrLabel46.Font = new DXFont("Tahoma", 10f);
		xrLabel46.ForeColor = Color.Black;
		xrLabel46.LocationFloat = new PointFloat(614.9999f, 2.000013f);
		xrLabel46.Name = "xrLabel46";
		xrLabel46.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel46.SizeF = new SizeF(57f, 22.99999f);
		xrLabel46.StylePriority.UseBorders = false;
		xrLabel46.StylePriority.UseFont = false;
		xrLabel46.StylePriority.UseForeColor = false;
		xrLabel46.StylePriority.UseTextAlignment = false;
		xrLabel46.Text = "Division:";
		xrLabel46.TextAlignment = TextAlignment.BottomLeft;
		xrLabel14.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel14.Borders = BorderSide.Bottom;
		xrLabel14.Font = new DXFont("Tahoma", 10f);
		xrLabel14.ForeColor = Color.Maroon;
		xrLabel14.LocationFloat = new PointFloat(110f, 2.000013f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(76.99998f, 22.99999f);
		xrLabel14.StylePriority.UseBorderDashStyle = false;
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseForeColor = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.Text = "5";
		xrLabel14.TextAlignment = TextAlignment.BottomCenter;
		xrLabel43.Borders = BorderSide.None;
		xrLabel43.Font = new DXFont("Tahoma", 10f);
		xrLabel43.ForeColor = Color.Black;
		xrLabel43.LocationFloat = new PointFloat(0.9999593f, 2.000014f);
		xrLabel43.Name = "xrLabel43";
		xrLabel43.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel43.SizeF = new SizeF(108f, 22.99999f);
		xrLabel43.StylePriority.UseBorders = false;
		xrLabel43.StylePriority.UseFont = false;
		xrLabel43.StylePriority.UseForeColor = false;
		xrLabel43.StylePriority.UseTextAlignment = false;
		xrLabel43.Text = "Position in class:";
		xrLabel43.TextAlignment = TextAlignment.BottomLeft;
		xrLabel22.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel22.Borders = BorderSide.Bottom;
		xrLabel22.Font = new DXFont("Tahoma", 10f);
		xrLabel22.ForeColor = Color.Maroon;
		xrLabel22.LocationFloat = new PointFloat(302.9999f, 2.000013f);
		xrLabel22.Name = "xrLabel22";
		xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel22.SizeF = new SizeF(116.0001f, 22.99999f);
		xrLabel22.StylePriority.UseBorderDashStyle = false;
		xrLabel22.StylePriority.UseBorders = false;
		xrLabel22.StylePriority.UseFont = false;
		xrLabel22.StylePriority.UseForeColor = false;
		xrLabel22.StylePriority.UseTextAlignment = false;
		xrLabel22.Text = "156";
		xrLabel22.TextAlignment = TextAlignment.BottomCenter;
		xrSubreport1.Id = 0;
		xrSubreport1.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.SizeF = new SizeF(787f, 90f);
		base.Bands.AddRange(new Band[6] { Detail, TopMargin, BottomMargin, ReportHeader, ReportFooter, GroupFooter1 });
		base.Margins = new DXMargins(20f, 20f, 20f, 20f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.ShowPrintStatusDialog = false;
		base.SnapGridSize = 1f;
		base.Version = "13.1";
		BeforePrint += ReportTemplate_BeforePrint;
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
