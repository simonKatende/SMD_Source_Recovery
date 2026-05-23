using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using AlienAge.Semesters;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.DataSet_Previews.StudentPreviewSourceTableAdapters;
using I_Xtreme.MealCards.dsMealCardv2TableAdapters;

namespace I_Xtreme.MealCards;

public class MealCardsV2 : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRPanel panel1;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell33;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell38;

	private XRTableCell xrTableCell39;

	private XRTableCell xrTableCell40;

	private XRTableCell xrTableCell41;

	private XRTableCell xrTableCell42;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell45;

	private XRTableCell xrTableCell46;

	private XRTableCell xrTableCell47;

	private XRTableCell xrTableCell48;

	private XRTableCell xrTableCell49;

	private XRTableCell xrTableCell50;

	private XRTableCell xrTableCell51;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell55;

	private XRTableCell xrTableCell56;

	private XRTableCell xrTableCell57;

	private XRTableCell xrTableCell58;

	private XRTableCell xrTableCell59;

	private XRTableCell xrTableCell60;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell62;

	private XRTableCell xrTableCell63;

	private XRTableCell xrTableCell64;

	private XRTableCell xrTableCell65;

	private XRTableCell xrTableCell66;

	private XRTableCell xrTableCell67;

	private XRTableCell xrTableCell68;

	private XRTableCell xrTableCell69;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell73;

	private XRTableCell xrTableCell74;

	private XRTableCell xrTableCell75;

	private XRTableCell xrTableCell76;

	private XRTableCell xrTableCell77;

	private XRTableCell xrTableCell78;

	private XRTableCell xrTableCell79;

	private XRTableCell xrTableCell80;

	private XRTableCell xrTableCell81;

	private XRTableCell xrTableCell82;

	private XRTableCell xrTableCell83;

	private XRTableCell xrTableCell84;

	private XRTableCell xrTableCell85;

	private XRTableCell xrTableCell86;

	private XRTableCell xrTableCell87;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell91;

	private XRTableCell xrTableCell92;

	private XRTableCell xrTableCell93;

	private XRTableCell xrTableCell94;

	private XRTableCell xrTableCell95;

	private XRTableCell xrTableCell96;

	private XRTableCell xrTableCell97;

	private XRTableCell xrTableCell98;

	private XRTableCell xrTableCell99;

	private XRTableCell xrTableCell100;

	private XRTableCell xrTableCell101;

	private XRTableCell xrTableCell102;

	private XRTableCell xrTableCell103;

	private XRTableCell xrTableCell104;

	private XRTableCell xrTableCell105;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell109;

	private XRTableCell xrTableCell110;

	private XRTableCell xrTableCell111;

	private XRTableCell xrTableCell112;

	private XRTableCell xrTableCell113;

	private XRTableCell xrTableCell114;

	private XRTableCell xrTableCell115;

	private XRTableCell xrTableCell116;

	private XRTableCell xrTableCell117;

	private XRTableCell xrTableCell118;

	private XRTableCell xrTableCell119;

	private XRTableCell xrTableCell120;

	private XRTableCell xrTableCell121;

	private XRTableCell xrTableCell122;

	private XRTableCell xrTableCell123;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell127;

	private XRTableCell xrTableCell128;

	private XRTableCell xrTableCell129;

	private XRTableCell xrTableCell130;

	private XRTableCell xrTableCell131;

	private XRTableCell xrTableCell132;

	private XRTableCell xrTableCell133;

	private XRTableCell xrTableCell134;

	private XRTableCell xrTableCell135;

	private XRTableCell xrTableCell136;

	private XRTableCell xrTableCell137;

	private XRTableCell xrTableCell138;

	private XRTableCell xrTableCell139;

	private XRTableCell xrTableCell140;

	private XRTableCell xrTableCell141;

	private XRTable xrTable2;

	private XRTableRow xrTableRow9;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell36;

	private XRTableCell xrTableCell52;

	private XRTableCell xrTableCell53;

	private XRTableCell xrTableCell54;

	private XRTableCell xrTableCell70;

	private XRTableCell xrTableCell71;

	private XRTableCell xrTableCell72;

	private XRTableCell xrTableCell88;

	private XRTableCell xrTableCell89;

	private XRTableCell xrTableCell90;

	private XRTableCell xrTableCell106;

	private XRTableRow xrTableRow11;

	private XRTableCell xrTableCell107;

	private XRTableCell xrTableCell108;

	private XRTableCell xrTableCell124;

	private XRTableCell xrTableCell125;

	private XRTableCell xrTableCell126;

	private XRTableCell xrTableCell142;

	private XRTableCell xrTableCell143;

	private XRTableCell xrTableCell144;

	private XRTableCell xrTableCell145;

	private XRTableCell xrTableCell146;

	private XRTableCell xrTableCell147;

	private XRTableCell xrTableCell148;

	private XRTableCell xrTableCell149;

	private XRTableCell xrTableCell150;

	private XRTableCell xrTableCell151;

	private XRTableRow xrTableRow12;

	private XRTableCell xrTableCell152;

	private XRTableCell xrTableCell153;

	private XRTableCell xrTableCell154;

	private XRTableCell xrTableCell155;

	private XRTableCell xrTableCell156;

	private XRTableCell xrTableCell157;

	private XRTableCell xrTableCell158;

	private XRTableCell xrTableCell159;

	private XRTableCell xrTableCell160;

	private XRTableCell xrTableCell161;

	private XRTableCell xrTableCell162;

	private XRTableCell xrTableCell163;

	private XRTableCell xrTableCell164;

	private XRTableCell xrTableCell165;

	private XRTableCell xrTableCell166;

	private XRTableRow xrTableRow13;

	private XRTableCell xrTableCell167;

	private XRTableCell xrTableCell168;

	private XRTableCell xrTableCell169;

	private XRTableCell xrTableCell170;

	private XRTableCell xrTableCell171;

	private XRTableCell xrTableCell172;

	private XRTableCell xrTableCell173;

	private XRTableCell xrTableCell174;

	private XRTableCell xrTableCell175;

	private XRTableCell xrTableCell176;

	private XRTableCell xrTableCell177;

	private XRTableCell xrTableCell178;

	private XRTableCell xrTableCell179;

	private XRTableCell xrTableCell180;

	private XRTableCell xrTableCell181;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell182;

	private XRTableCell xrTableCell183;

	private XRTableCell xrTableCell184;

	private XRTableCell xrTableCell185;

	private XRTableCell xrTableCell186;

	private XRTableCell xrTableCell187;

	private XRTableCell xrTableCell188;

	private XRTableCell xrTableCell189;

	private XRTableCell xrTableCell190;

	private XRTableCell xrTableCell191;

	private XRTableCell xrTableCell192;

	private XRTableCell xrTableCell193;

	private XRTableCell xrTableCell194;

	private XRTableCell xrTableCell195;

	private XRTableCell xrTableCell196;

	private XRTableRow xrTableRow15;

	private XRTableCell xrTableCell197;

	private XRTableCell xrTableCell198;

	private XRTableCell xrTableCell199;

	private XRTableCell xrTableCell200;

	private XRTableCell xrTableCell201;

	private XRTableCell xrTableCell202;

	private XRTableCell xrTableCell203;

	private XRTableCell xrTableCell204;

	private XRTableCell xrTableCell205;

	private XRTableCell xrTableCell206;

	private XRTableCell xrTableCell207;

	private XRTableCell xrTableCell208;

	private XRTableCell xrTableCell209;

	private XRTableCell xrTableCell210;

	private XRTableCell xrTableCell211;

	private XRTableRow xrTableRow16;

	private XRTableCell xrTableCell212;

	private XRTableCell xrTableCell213;

	private XRTableCell xrTableCell214;

	private XRTableCell xrTableCell215;

	private XRTableCell xrTableCell216;

	private XRTableCell xrTableCell217;

	private XRTableCell xrTableCell218;

	private XRTableCell xrTableCell219;

	private XRTableCell xrTableCell220;

	private XRTableCell xrTableCell221;

	private XRTableCell xrTableCell222;

	private XRTableCell xrTableCell223;

	private XRTableCell xrTableCell224;

	private XRTableCell xrTableCell225;

	private XRTableCell xrTableCell226;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private StudentPreviewSourceTableAdapter studentPreviewSourceTableAdapter;

	private XRTable xrTable3;

	private XRTableRow xrTableRow17;

	private XRTableCell xrTableCell228;

	private XRTableCell xrTableCell229;

	private XRTableRow xrTableRow18;

	private XRTableCell xrTableCell227;

	private XRTableCell xrTableCell230;

	private XRTableRow xrTableRow19;

	private XRTableCell xrTableCell231;

	private XRTableCell xrTableCell232;

	private XRLabel xrLabel8;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRPictureBox xrPictureBox1;

	private CalculatedField Paid;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLine xrLine2;

	private XRLine xrLine1;

	private XRLabel lblTerm;

	private XRLabel xrLabel7;

	private XRLabel lblSchool;

	private Parameter studStream;

	private Parameter studClass;

	private dsMealCardv2 dsMealCardv21;

	private DTableMealCardAdapter dTableMealCardAdapter;

	private CalculatedField calculatedField1;

	public MealCardsV2(string ClassId, string StreamId)
	{
		InitializeComponent();
		studStream.Value = StreamId;
		studClass.Value = ClassId;
	}

	private void MealCardsV2_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchool.Text = ReportHeader.SchoolName;
		lblTerm.Text = WorkingSemesters.GetWorkingSemester();
	}

	private void xrTableCell232_BeforePrint(object sender, CancelEventArgs e)
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
		panel1 = new XRPanel();
		lblSchool = new XRLabel();
		xrLabel7 = new XRLabel();
		lblTerm = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		xrTable3 = new XRTable();
		xrTableRow17 = new XRTableRow();
		xrTableCell228 = new XRTableCell();
		xrTableCell229 = new XRTableCell();
		xrTableRow18 = new XRTableRow();
		xrTableCell227 = new XRTableCell();
		xrTableCell230 = new XRTableCell();
		xrTableRow19 = new XRTableRow();
		xrTableCell231 = new XRTableCell();
		xrTableCell232 = new XRTableCell();
		xrLabel8 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrTable2 = new XRTable();
		xrTableRow9 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableRow10 = new XRTableRow();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableCell52 = new XRTableCell();
		xrTableCell53 = new XRTableCell();
		xrTableCell54 = new XRTableCell();
		xrTableCell70 = new XRTableCell();
		xrTableCell71 = new XRTableCell();
		xrTableCell72 = new XRTableCell();
		xrTableCell88 = new XRTableCell();
		xrTableCell89 = new XRTableCell();
		xrTableCell90 = new XRTableCell();
		xrTableCell106 = new XRTableCell();
		xrTableRow11 = new XRTableRow();
		xrTableCell107 = new XRTableCell();
		xrTableCell108 = new XRTableCell();
		xrTableCell124 = new XRTableCell();
		xrTableCell125 = new XRTableCell();
		xrTableCell126 = new XRTableCell();
		xrTableCell142 = new XRTableCell();
		xrTableCell143 = new XRTableCell();
		xrTableCell144 = new XRTableCell();
		xrTableCell145 = new XRTableCell();
		xrTableCell146 = new XRTableCell();
		xrTableCell147 = new XRTableCell();
		xrTableCell148 = new XRTableCell();
		xrTableCell149 = new XRTableCell();
		xrTableCell150 = new XRTableCell();
		xrTableCell151 = new XRTableCell();
		xrTableRow12 = new XRTableRow();
		xrTableCell152 = new XRTableCell();
		xrTableCell153 = new XRTableCell();
		xrTableCell154 = new XRTableCell();
		xrTableCell155 = new XRTableCell();
		xrTableCell156 = new XRTableCell();
		xrTableCell157 = new XRTableCell();
		xrTableCell158 = new XRTableCell();
		xrTableCell159 = new XRTableCell();
		xrTableCell160 = new XRTableCell();
		xrTableCell161 = new XRTableCell();
		xrTableCell162 = new XRTableCell();
		xrTableCell163 = new XRTableCell();
		xrTableCell164 = new XRTableCell();
		xrTableCell165 = new XRTableCell();
		xrTableCell166 = new XRTableCell();
		xrTableRow13 = new XRTableRow();
		xrTableCell167 = new XRTableCell();
		xrTableCell168 = new XRTableCell();
		xrTableCell169 = new XRTableCell();
		xrTableCell170 = new XRTableCell();
		xrTableCell171 = new XRTableCell();
		xrTableCell172 = new XRTableCell();
		xrTableCell173 = new XRTableCell();
		xrTableCell174 = new XRTableCell();
		xrTableCell175 = new XRTableCell();
		xrTableCell176 = new XRTableCell();
		xrTableCell177 = new XRTableCell();
		xrTableCell178 = new XRTableCell();
		xrTableCell179 = new XRTableCell();
		xrTableCell180 = new XRTableCell();
		xrTableCell181 = new XRTableCell();
		xrTableRow14 = new XRTableRow();
		xrTableCell182 = new XRTableCell();
		xrTableCell183 = new XRTableCell();
		xrTableCell184 = new XRTableCell();
		xrTableCell185 = new XRTableCell();
		xrTableCell186 = new XRTableCell();
		xrTableCell187 = new XRTableCell();
		xrTableCell188 = new XRTableCell();
		xrTableCell189 = new XRTableCell();
		xrTableCell190 = new XRTableCell();
		xrTableCell191 = new XRTableCell();
		xrTableCell192 = new XRTableCell();
		xrTableCell193 = new XRTableCell();
		xrTableCell194 = new XRTableCell();
		xrTableCell195 = new XRTableCell();
		xrTableCell196 = new XRTableCell();
		xrTableRow15 = new XRTableRow();
		xrTableCell197 = new XRTableCell();
		xrTableCell198 = new XRTableCell();
		xrTableCell199 = new XRTableCell();
		xrTableCell200 = new XRTableCell();
		xrTableCell201 = new XRTableCell();
		xrTableCell202 = new XRTableCell();
		xrTableCell203 = new XRTableCell();
		xrTableCell204 = new XRTableCell();
		xrTableCell205 = new XRTableCell();
		xrTableCell206 = new XRTableCell();
		xrTableCell207 = new XRTableCell();
		xrTableCell208 = new XRTableCell();
		xrTableCell209 = new XRTableCell();
		xrTableCell210 = new XRTableCell();
		xrTableCell211 = new XRTableCell();
		xrTableRow16 = new XRTableRow();
		xrTableCell212 = new XRTableCell();
		xrTableCell213 = new XRTableCell();
		xrTableCell214 = new XRTableCell();
		xrTableCell215 = new XRTableCell();
		xrTableCell216 = new XRTableCell();
		xrTableCell217 = new XRTableCell();
		xrTableCell218 = new XRTableCell();
		xrTableCell219 = new XRTableCell();
		xrTableCell220 = new XRTableCell();
		xrTableCell221 = new XRTableCell();
		xrTableCell222 = new XRTableCell();
		xrTableCell223 = new XRTableCell();
		xrTableCell224 = new XRTableCell();
		xrTableCell225 = new XRTableCell();
		xrTableCell226 = new XRTableCell();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell39 = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
		xrTableCell46 = new XRTableCell();
		xrTableCell47 = new XRTableCell();
		xrTableCell48 = new XRTableCell();
		xrTableCell49 = new XRTableCell();
		xrTableCell50 = new XRTableCell();
		xrTableCell51 = new XRTableCell();
		xrTableRow4 = new XRTableRow();
		xrTableCell55 = new XRTableCell();
		xrTableCell56 = new XRTableCell();
		xrTableCell57 = new XRTableCell();
		xrTableCell58 = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableCell60 = new XRTableCell();
		xrTableCell61 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		xrTableCell63 = new XRTableCell();
		xrTableCell64 = new XRTableCell();
		xrTableCell65 = new XRTableCell();
		xrTableCell66 = new XRTableCell();
		xrTableCell67 = new XRTableCell();
		xrTableCell68 = new XRTableCell();
		xrTableCell69 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		xrTableCell73 = new XRTableCell();
		xrTableCell74 = new XRTableCell();
		xrTableCell75 = new XRTableCell();
		xrTableCell76 = new XRTableCell();
		xrTableCell77 = new XRTableCell();
		xrTableCell78 = new XRTableCell();
		xrTableCell79 = new XRTableCell();
		xrTableCell80 = new XRTableCell();
		xrTableCell81 = new XRTableCell();
		xrTableCell82 = new XRTableCell();
		xrTableCell83 = new XRTableCell();
		xrTableCell84 = new XRTableCell();
		xrTableCell85 = new XRTableCell();
		xrTableCell86 = new XRTableCell();
		xrTableCell87 = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		xrTableCell91 = new XRTableCell();
		xrTableCell92 = new XRTableCell();
		xrTableCell93 = new XRTableCell();
		xrTableCell94 = new XRTableCell();
		xrTableCell95 = new XRTableCell();
		xrTableCell96 = new XRTableCell();
		xrTableCell97 = new XRTableCell();
		xrTableCell98 = new XRTableCell();
		xrTableCell99 = new XRTableCell();
		xrTableCell100 = new XRTableCell();
		xrTableCell101 = new XRTableCell();
		xrTableCell102 = new XRTableCell();
		xrTableCell103 = new XRTableCell();
		xrTableCell104 = new XRTableCell();
		xrTableCell105 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell109 = new XRTableCell();
		xrTableCell110 = new XRTableCell();
		xrTableCell111 = new XRTableCell();
		xrTableCell112 = new XRTableCell();
		xrTableCell113 = new XRTableCell();
		xrTableCell114 = new XRTableCell();
		xrTableCell115 = new XRTableCell();
		xrTableCell116 = new XRTableCell();
		xrTableCell117 = new XRTableCell();
		xrTableCell118 = new XRTableCell();
		xrTableCell119 = new XRTableCell();
		xrTableCell120 = new XRTableCell();
		xrTableCell121 = new XRTableCell();
		xrTableCell122 = new XRTableCell();
		xrTableCell123 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell127 = new XRTableCell();
		xrTableCell128 = new XRTableCell();
		xrTableCell129 = new XRTableCell();
		xrTableCell130 = new XRTableCell();
		xrTableCell131 = new XRTableCell();
		xrTableCell132 = new XRTableCell();
		xrTableCell133 = new XRTableCell();
		xrTableCell134 = new XRTableCell();
		xrTableCell135 = new XRTableCell();
		xrTableCell136 = new XRTableCell();
		xrTableCell137 = new XRTableCell();
		xrTableCell138 = new XRTableCell();
		xrTableCell139 = new XRTableCell();
		xrTableCell140 = new XRTableCell();
		xrTableCell141 = new XRTableCell();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		studentPreviewSourceTableAdapter = new StudentPreviewSourceTableAdapter();
		Paid = new CalculatedField();
		studStream = new Parameter();
		studClass = new Parameter();
		dsMealCardv21 = new dsMealCardv2();
		dTableMealCardAdapter = new DTableMealCardAdapter();
		calculatedField1 = new CalculatedField();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)dsMealCardv21).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { panel1 });
		Detail.Dpi = 254f;
		Detail.HeightF = 1013.351f;
		Detail.HierarchyPrintOptions.Indent = 50.8f;
		Detail.MultiColumn.ColumnCount = 2;
		Detail.MultiColumn.ColumnSpacing = 25f;
		Detail.MultiColumn.ColumnWidth = 1500f;
		Detail.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail.Name = "Detail";
		panel1.Borders = BorderSide.All;
		panel1.CanGrow = false;
		panel1.Controls.AddRange(new XRControl[16]
		{
			lblSchool, xrLabel7, lblTerm, xrLabel6, xrLabel5, xrLine2, xrLine1, xrTable3, xrLabel8, xrLabel4,
			xrLabel3, xrPictureBox1, xrLabel2, xrLabel1, xrTable2, xrTable1
		});
		panel1.Dpi = 254f;
		panel1.LocationFloat = new PointFloat(0f, 23.78949f);
		panel1.Name = "panel1";
		panel1.SizeF = new SizeF(1449.5f, 989.5615f);
		lblSchool.Borders = BorderSide.None;
		lblSchool.Dpi = 254f;
		lblSchool.Font = new DXFont("Arial", 14f, DXFontStyle.Bold);
		lblSchool.LocationFloat = new PointFloat(16.75f, 16.21051f);
		lblSchool.Multiline = true;
		lblSchool.Name = "lblSchool";
		lblSchool.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		lblSchool.SizeF = new SizeF(1416f, 58.41995f);
		lblSchool.StylePriority.UseBorders = false;
		lblSchool.StylePriority.UseFont = false;
		lblSchool.StylePriority.UseTextAlignment = false;
		lblSchool.Text = "STUDENT'S MEAL/CLEARANCE CARD";
		lblSchool.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.Borders = BorderSide.None;
		xrLabel7.CanGrow = false;
		xrLabel7.Dpi = 254f;
		xrLabel7.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel7.LocationFloat = new PointFloat(16.75f, 130.2105f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel7.SizeF = new SizeF(1416f, 58.41995f);
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "STUDENT'S MEAL/CLEARANCE CARD";
		xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.WordWrap = false;
		lblTerm.Borders = BorderSide.None;
		lblTerm.Dpi = 254f;
		lblTerm.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		lblTerm.LocationFloat = new PointFloat(478f, 409.7905f);
		lblTerm.Multiline = true;
		lblTerm.Name = "lblTerm";
		lblTerm.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		lblTerm.SizeF = new SizeF(352f, 58.41995f);
		lblTerm.StylePriority.UseBorders = false;
		lblTerm.StylePriority.UseFont = false;
		lblTerm.StylePriority.UseTextAlignment = false;
		lblTerm.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.Borders = BorderSide.None;
		xrLabel6.CanGrow = false;
		xrLabel6.Dpi = 254f;
		xrLabel6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrLabel6.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel6.LocationFloat = new PointFloat(595.9999f, 350.2105f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel6.SizeF = new SizeF(232f, 58.42001f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "xrLabel6";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.WordWrap = false;
		xrLabel5.Borders = BorderSide.None;
		xrLabel5.Dpi = 254f;
		xrLabel5.LocationFloat = new PointFloat(284f, 409.7905f);
		xrLabel5.Multiline = true;
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel5.SizeF = new SizeF(190f, 58.41995f);
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "VALIDITY:";
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		xrLine2.Borders = BorderSide.None;
		xrLine2.Dpi = 254f;
		xrLine2.LocationFloat = new PointFloat(0f, 480.2105f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(1449.5f, 5f);
		xrLine2.StylePriority.UseBorders = false;
		xrLine1.Dpi = 254f;
		xrLine1.LocationFloat = new PointFloat(0f, 196.2105f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(1449.5f, 5f);
		xrTable3.Dpi = 254f;
		xrTable3.LocationFloat = new PointFloat(864f, 276.2105f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable3.Rows.AddRange(new XRTableRow[3] { xrTableRow17, xrTableRow18, xrTableRow19 });
		xrTable3.SizeF = new SizeF(576f, 190.5f);
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow17.Cells.AddRange(new XRTableCell[2] { xrTableCell228, xrTableCell229 });
		xrTableRow17.Dpi = 254f;
		xrTableRow17.Name = "xrTableRow17";
		xrTableRow17.Weight = 1.0;
		xrTableCell228.Dpi = 254f;
		xrTableCell228.Multiline = true;
		xrTableCell228.Name = "xrTableCell228";
		xrTableCell228.Text = "PAYABLE";
		xrTableCell228.Weight = 119.0 / 144.0;
		xrTableCell229.CanGrow = false;
		xrTableCell229.Dpi = 254f;
		xrTableCell229.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[RequiredFees]")
		});
		xrTableCell229.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell229.Name = "xrTableCell229";
		xrTableCell229.StylePriority.UseFont = false;
		xrTableCell229.StylePriority.UseTextAlignment = false;
		xrTableCell229.Text = "xrTableCell229";
		xrTableCell229.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell229.TextFormatString = "{0:#,#}";
		xrTableCell229.Weight = 1.1736111111111112;
		xrTableCell229.WordWrap = false;
		xrTableRow18.Cells.AddRange(new XRTableCell[2] { xrTableCell227, xrTableCell230 });
		xrTableRow18.Dpi = 254f;
		xrTableRow18.Name = "xrTableRow18";
		xrTableRow18.Weight = 1.0;
		xrTableCell227.Dpi = 254f;
		xrTableCell227.Multiline = true;
		xrTableCell227.Name = "xrTableCell227";
		xrTableCell227.Text = "PAID";
		xrTableCell227.Weight = 119.0 / 144.0;
		xrTableCell230.CanGrow = false;
		xrTableCell230.Dpi = 254f;
		xrTableCell230.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[calculatedField1]")
		});
		xrTableCell230.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell230.Name = "xrTableCell230";
		xrTableCell230.StylePriority.UseFont = false;
		xrTableCell230.StylePriority.UseTextAlignment = false;
		xrTableCell230.Text = "xrTableCell230";
		xrTableCell230.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell230.TextFormatString = "{0:#,#}";
		xrTableCell230.Weight = 1.1736111111111112;
		xrTableCell230.WordWrap = false;
		xrTableRow19.Cells.AddRange(new XRTableCell[2] { xrTableCell231, xrTableCell232 });
		xrTableRow19.Dpi = 254f;
		xrTableRow19.Name = "xrTableRow19";
		xrTableRow19.Weight = 1.0;
		xrTableCell231.Dpi = 254f;
		xrTableCell231.Multiline = true;
		xrTableCell231.Name = "xrTableCell231";
		xrTableCell231.Text = "BALANCE";
		xrTableCell231.Weight = 119.0 / 144.0;
		xrTableCell232.CanGrow = false;
		xrTableCell232.Dpi = 254f;
		xrTableCell232.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[cashOnAccount]")
		});
		xrTableCell232.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell232.Name = "xrTableCell232";
		xrTableCell232.StylePriority.UseFont = false;
		xrTableCell232.StylePriority.UseTextAlignment = false;
		xrTableCell232.Text = "xrTableCell232";
		xrTableCell232.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell232.TextFormatString = "{0:#,#}";
		xrTableCell232.Weight = 1.1736111111111112;
		xrTableCell232.WordWrap = false;
		xrTableCell232.BeforePrint += xrTableCell232_BeforePrint;
		xrLabel8.Borders = BorderSide.None;
		xrLabel8.Dpi = 254f;
		xrLabel8.LocationFloat = new PointFloat(284f, 350.2105f);
		xrLabel8.Multiline = true;
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel8.SizeF = new SizeF(190f, 58.42001f);
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "CLASS:";
		xrLabel8.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.CanGrow = false;
		xrLabel4.Dpi = 254f;
		xrLabel4.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel4.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel4.LocationFloat = new PointFloat(478f, 350.2105f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel4.SizeF = new SizeF(116f, 58.42001f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "xrLabel4";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel4.WordWrap = false;
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.Dpi = 254f;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel3.Font = new DXFont("Arial", 11f, DXFontStyle.Bold);
		xrLabel3.LocationFloat = new PointFloat(284f, 214.2105f);
		xrLabel3.Multiline = true;
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel3.SizeF = new SizeF(1158f, 57.99997f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "xrLabel3";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		xrPictureBox1.Dpi = 254f;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(16.00007f, 214.2105f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(254f, 254f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrLabel2.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel2.Borders = BorderSide.Bottom;
		xrLabel2.Dpi = 254f;
		xrLabel2.LocationFloat = new PointFloat(556f, 906.2104f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel2.SizeF = new SizeF(873.9999f, 58.41998f);
		xrLabel2.StylePriority.UseBorderDashStyle = false;
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel1.Borders = BorderSide.None;
		xrLabel1.Dpi = 254f;
		xrLabel1.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(17.99999f, 906.2104f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel1.SizeF = new SizeF(528f, 58.41992f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "BURSAR/ISSUER SIGNATURE:";
		xrLabel1.TextAlignment = TextAlignment.BottomLeft;
		xrTable2.Dpi = 254f;
		xrTable2.Font = new DXFont("Arial", 8f);
		xrTable2.LocationFloat = new PointFloat(744f, 494.2105f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		xrTable2.Rows.AddRange(new XRTableRow[8] { xrTableRow9, xrTableRow10, xrTableRow11, xrTableRow12, xrTableRow13, xrTableRow14, xrTableRow15, xrTableRow16 });
		xrTable2.SizeF = new SizeF(688f, 399.9999f);
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UsePadding = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow9.Cells.AddRange(new XRTableCell[8] { xrTableCell3, xrTableCell5, xrTableCell7, xrTableCell9, xrTableCell11, xrTableCell13, xrTableCell15, xrTableCell16 });
		xrTableRow9.Dpi = 254f;
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		xrTableCell3.Dpi = 254f;
		xrTableCell3.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.Text = "Week";
		xrTableCell3.Weight = 2.651531797907593;
		xrTableCell5.Dpi = 254f;
		xrTableCell5.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.Text = "MON";
		xrTableCell5.Weight = 2.6515317858527174;
		xrTableCell7.Dpi = 254f;
		xrTableCell7.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.Text = "TUE";
		xrTableCell7.Weight = 2.6515317858527183;
		xrTableCell9.Dpi = 254f;
		xrTableCell9.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.Text = "WED";
		xrTableCell9.Weight = 2.6515317858527174;
		xrTableCell11.Dpi = 254f;
		xrTableCell11.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.Text = "THU";
		xrTableCell11.Weight = 2.6515317858527174;
		xrTableCell13.Dpi = 254f;
		xrTableCell13.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.Text = "FRI";
		xrTableCell13.Weight = 2.6515317858527174;
		xrTableCell15.Dpi = 254f;
		xrTableCell15.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.Text = "SAT";
		xrTableCell15.Weight = 2.651531785852717;
		xrTableCell16.Dpi = 254f;
		xrTableCell16.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.Text = "SUN";
		xrTableCell16.Weight = 2.6515318238862715;
		xrTableRow10.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell17, xrTableCell18, xrTableCell34, xrTableCell35, xrTableCell36, xrTableCell52, xrTableCell53, xrTableCell54, xrTableCell70, xrTableCell71,
			xrTableCell72, xrTableCell88, xrTableCell89, xrTableCell90, xrTableCell106
		});
		xrTableRow10.Dpi = 254f;
		xrTableRow10.Name = "xrTableRow10";
		xrTableRow10.Weight = 1.0;
		xrTableCell17.Dpi = 254f;
		xrTableCell17.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.Text = "1";
		xrTableCell17.Weight = 2.8283006612105996;
		xrTableCell18.Dpi = 254f;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.Weight = 1.4141503436999736;
		xrTableCell34.Dpi = 254f;
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.Weight = 1.4141502951642275;
		xrTableCell35.Dpi = 254f;
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.Weight = 1.4141502951642275;
		xrTableCell36.Dpi = 254f;
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.Weight = 1.4141502951642275;
		xrTableCell52.Dpi = 254f;
		xrTableCell52.Name = "xrTableCell52";
		xrTableCell52.Weight = 1.4141502951642275;
		xrTableCell53.Dpi = 254f;
		xrTableCell53.Name = "xrTableCell53";
		xrTableCell53.Weight = 1.4141502951642275;
		xrTableCell54.Dpi = 254f;
		xrTableCell54.Name = "xrTableCell54";
		xrTableCell54.Weight = 1.4141502951642275;
		xrTableCell70.Dpi = 254f;
		xrTableCell70.Name = "xrTableCell70";
		xrTableCell70.Weight = 1.4141502951642275;
		xrTableCell71.Dpi = 254f;
		xrTableCell71.Name = "xrTableCell71";
		xrTableCell71.Weight = 1.4141502951642275;
		xrTableCell72.Dpi = 254f;
		xrTableCell72.Name = "xrTableCell72";
		xrTableCell72.Weight = 1.4141502951642275;
		xrTableCell88.Dpi = 254f;
		xrTableCell88.Name = "xrTableCell88";
		xrTableCell88.Weight = 1.4141502951642275;
		xrTableCell89.Dpi = 254f;
		xrTableCell89.Name = "xrTableCell89";
		xrTableCell89.Weight = 1.4141502951642275;
		xrTableCell90.Dpi = 254f;
		xrTableCell90.Name = "xrTableCell90";
		xrTableCell90.Weight = 1.4141502951642275;
		xrTableCell106.Dpi = 254f;
		xrTableCell106.Name = "xrTableCell106";
		xrTableCell106.Weight = 1.414150079156211;
		xrTableRow11.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell107, xrTableCell108, xrTableCell124, xrTableCell125, xrTableCell126, xrTableCell142, xrTableCell143, xrTableCell144, xrTableCell145, xrTableCell146,
			xrTableCell147, xrTableCell148, xrTableCell149, xrTableCell150, xrTableCell151
		});
		xrTableRow11.Dpi = 254f;
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		xrTableCell107.Dpi = 254f;
		xrTableCell107.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell107.Name = "xrTableCell107";
		xrTableCell107.StylePriority.UseFont = false;
		xrTableCell107.Text = "2";
		xrTableCell107.Weight = 2.8283006612105996;
		xrTableCell108.Dpi = 254f;
		xrTableCell108.Name = "xrTableCell108";
		xrTableCell108.Weight = 1.4141503436999736;
		xrTableCell124.Dpi = 254f;
		xrTableCell124.Name = "xrTableCell124";
		xrTableCell124.Weight = 1.4141502951642275;
		xrTableCell125.Dpi = 254f;
		xrTableCell125.Name = "xrTableCell125";
		xrTableCell125.Weight = 1.4141502951642275;
		xrTableCell126.Dpi = 254f;
		xrTableCell126.Name = "xrTableCell126";
		xrTableCell126.Weight = 1.4141502951642275;
		xrTableCell142.Dpi = 254f;
		xrTableCell142.Name = "xrTableCell142";
		xrTableCell142.Weight = 1.4141502951642275;
		xrTableCell143.Dpi = 254f;
		xrTableCell143.Name = "xrTableCell143";
		xrTableCell143.Weight = 1.4141502951642275;
		xrTableCell144.Dpi = 254f;
		xrTableCell144.Name = "xrTableCell144";
		xrTableCell144.Weight = 1.4141502951642275;
		xrTableCell145.Dpi = 254f;
		xrTableCell145.Name = "xrTableCell145";
		xrTableCell145.Weight = 1.4141502951642275;
		xrTableCell146.Dpi = 254f;
		xrTableCell146.Name = "xrTableCell146";
		xrTableCell146.Weight = 1.4141502951642275;
		xrTableCell147.Dpi = 254f;
		xrTableCell147.Name = "xrTableCell147";
		xrTableCell147.Weight = 1.4141502951642275;
		xrTableCell148.Dpi = 254f;
		xrTableCell148.Name = "xrTableCell148";
		xrTableCell148.Weight = 1.4141502951642275;
		xrTableCell149.Dpi = 254f;
		xrTableCell149.Name = "xrTableCell149";
		xrTableCell149.Weight = 1.4141502951642275;
		xrTableCell150.Dpi = 254f;
		xrTableCell150.Name = "xrTableCell150";
		xrTableCell150.Weight = 1.4141502951642275;
		xrTableCell151.Dpi = 254f;
		xrTableCell151.Name = "xrTableCell151";
		xrTableCell151.Weight = 1.414150079156211;
		xrTableRow12.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell152, xrTableCell153, xrTableCell154, xrTableCell155, xrTableCell156, xrTableCell157, xrTableCell158, xrTableCell159, xrTableCell160, xrTableCell161,
			xrTableCell162, xrTableCell163, xrTableCell164, xrTableCell165, xrTableCell166
		});
		xrTableRow12.Dpi = 254f;
		xrTableRow12.Name = "xrTableRow12";
		xrTableRow12.Weight = 1.0;
		xrTableCell152.Dpi = 254f;
		xrTableCell152.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell152.Name = "xrTableCell152";
		xrTableCell152.StylePriority.UseFont = false;
		xrTableCell152.Text = "3";
		xrTableCell152.Weight = 2.8283006612105996;
		xrTableCell153.Dpi = 254f;
		xrTableCell153.Name = "xrTableCell153";
		xrTableCell153.Weight = 1.4141503436999736;
		xrTableCell154.Dpi = 254f;
		xrTableCell154.Name = "xrTableCell154";
		xrTableCell154.Weight = 1.4141502951642275;
		xrTableCell155.Dpi = 254f;
		xrTableCell155.Name = "xrTableCell155";
		xrTableCell155.Weight = 1.4141502951642275;
		xrTableCell156.Dpi = 254f;
		xrTableCell156.Name = "xrTableCell156";
		xrTableCell156.Weight = 1.4141502951642275;
		xrTableCell157.Dpi = 254f;
		xrTableCell157.Name = "xrTableCell157";
		xrTableCell157.Weight = 1.4141502951642275;
		xrTableCell158.Dpi = 254f;
		xrTableCell158.Name = "xrTableCell158";
		xrTableCell158.Weight = 1.4141502951642275;
		xrTableCell159.Dpi = 254f;
		xrTableCell159.Name = "xrTableCell159";
		xrTableCell159.Weight = 1.4141502951642275;
		xrTableCell160.Dpi = 254f;
		xrTableCell160.Name = "xrTableCell160";
		xrTableCell160.Weight = 1.4141502951642275;
		xrTableCell161.Dpi = 254f;
		xrTableCell161.Name = "xrTableCell161";
		xrTableCell161.Weight = 1.4141502951642275;
		xrTableCell162.Dpi = 254f;
		xrTableCell162.Name = "xrTableCell162";
		xrTableCell162.Weight = 1.4141502951642275;
		xrTableCell163.Dpi = 254f;
		xrTableCell163.Name = "xrTableCell163";
		xrTableCell163.Weight = 1.4141502951642275;
		xrTableCell164.Dpi = 254f;
		xrTableCell164.Name = "xrTableCell164";
		xrTableCell164.Weight = 1.4141502951642275;
		xrTableCell165.Dpi = 254f;
		xrTableCell165.Name = "xrTableCell165";
		xrTableCell165.Weight = 1.4141502951642275;
		xrTableCell166.Dpi = 254f;
		xrTableCell166.Name = "xrTableCell166";
		xrTableCell166.Weight = 1.414150079156211;
		xrTableRow13.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell167, xrTableCell168, xrTableCell169, xrTableCell170, xrTableCell171, xrTableCell172, xrTableCell173, xrTableCell174, xrTableCell175, xrTableCell176,
			xrTableCell177, xrTableCell178, xrTableCell179, xrTableCell180, xrTableCell181
		});
		xrTableRow13.Dpi = 254f;
		xrTableRow13.Name = "xrTableRow13";
		xrTableRow13.Weight = 1.0;
		xrTableCell167.Dpi = 254f;
		xrTableCell167.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell167.Name = "xrTableCell167";
		xrTableCell167.StylePriority.UseFont = false;
		xrTableCell167.Text = "4";
		xrTableCell167.Weight = 2.8283006612105996;
		xrTableCell168.Dpi = 254f;
		xrTableCell168.Name = "xrTableCell168";
		xrTableCell168.Weight = 1.4141503436999736;
		xrTableCell169.Dpi = 254f;
		xrTableCell169.Name = "xrTableCell169";
		xrTableCell169.Weight = 1.4141502951642275;
		xrTableCell170.Dpi = 254f;
		xrTableCell170.Name = "xrTableCell170";
		xrTableCell170.Weight = 1.4141502951642275;
		xrTableCell171.Dpi = 254f;
		xrTableCell171.Name = "xrTableCell171";
		xrTableCell171.Weight = 1.4141502951642275;
		xrTableCell172.Dpi = 254f;
		xrTableCell172.Name = "xrTableCell172";
		xrTableCell172.Weight = 1.4141502951642275;
		xrTableCell173.Dpi = 254f;
		xrTableCell173.Name = "xrTableCell173";
		xrTableCell173.Weight = 1.4141502951642275;
		xrTableCell174.Dpi = 254f;
		xrTableCell174.Name = "xrTableCell174";
		xrTableCell174.Weight = 1.4141502951642275;
		xrTableCell175.Dpi = 254f;
		xrTableCell175.Name = "xrTableCell175";
		xrTableCell175.Weight = 1.4141502951642275;
		xrTableCell176.Dpi = 254f;
		xrTableCell176.Name = "xrTableCell176";
		xrTableCell176.Weight = 1.4141502951642275;
		xrTableCell177.Dpi = 254f;
		xrTableCell177.Name = "xrTableCell177";
		xrTableCell177.Weight = 1.4141502951642275;
		xrTableCell178.Dpi = 254f;
		xrTableCell178.Name = "xrTableCell178";
		xrTableCell178.Weight = 1.4141502951642275;
		xrTableCell179.Dpi = 254f;
		xrTableCell179.Name = "xrTableCell179";
		xrTableCell179.Weight = 1.4141502951642275;
		xrTableCell180.Dpi = 254f;
		xrTableCell180.Name = "xrTableCell180";
		xrTableCell180.Weight = 1.4141502951642275;
		xrTableCell181.Dpi = 254f;
		xrTableCell181.Name = "xrTableCell181";
		xrTableCell181.Weight = 1.414150079156211;
		xrTableRow14.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell182, xrTableCell183, xrTableCell184, xrTableCell185, xrTableCell186, xrTableCell187, xrTableCell188, xrTableCell189, xrTableCell190, xrTableCell191,
			xrTableCell192, xrTableCell193, xrTableCell194, xrTableCell195, xrTableCell196
		});
		xrTableRow14.Dpi = 254f;
		xrTableRow14.Name = "xrTableRow14";
		xrTableRow14.Weight = 1.0;
		xrTableCell182.Dpi = 254f;
		xrTableCell182.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell182.Name = "xrTableCell182";
		xrTableCell182.StylePriority.UseFont = false;
		xrTableCell182.Text = "5";
		xrTableCell182.Weight = 2.8283006612105996;
		xrTableCell183.Dpi = 254f;
		xrTableCell183.Name = "xrTableCell183";
		xrTableCell183.Weight = 1.4141503436999736;
		xrTableCell184.Dpi = 254f;
		xrTableCell184.Name = "xrTableCell184";
		xrTableCell184.Weight = 1.4141502951642275;
		xrTableCell185.Dpi = 254f;
		xrTableCell185.Name = "xrTableCell185";
		xrTableCell185.Weight = 1.4141502951642275;
		xrTableCell186.Dpi = 254f;
		xrTableCell186.Name = "xrTableCell186";
		xrTableCell186.Weight = 1.4141502951642275;
		xrTableCell187.Dpi = 254f;
		xrTableCell187.Name = "xrTableCell187";
		xrTableCell187.Weight = 1.4141502951642275;
		xrTableCell188.Dpi = 254f;
		xrTableCell188.Name = "xrTableCell188";
		xrTableCell188.Weight = 1.4141502951642275;
		xrTableCell189.Dpi = 254f;
		xrTableCell189.Name = "xrTableCell189";
		xrTableCell189.Weight = 1.4141502951642275;
		xrTableCell190.Dpi = 254f;
		xrTableCell190.Name = "xrTableCell190";
		xrTableCell190.Weight = 1.4141502951642275;
		xrTableCell191.Dpi = 254f;
		xrTableCell191.Name = "xrTableCell191";
		xrTableCell191.Weight = 1.4141502951642275;
		xrTableCell192.Dpi = 254f;
		xrTableCell192.Name = "xrTableCell192";
		xrTableCell192.Weight = 1.4141502951642275;
		xrTableCell193.Dpi = 254f;
		xrTableCell193.Name = "xrTableCell193";
		xrTableCell193.Weight = 1.4141502951642275;
		xrTableCell194.Dpi = 254f;
		xrTableCell194.Name = "xrTableCell194";
		xrTableCell194.Weight = 1.4141502951642275;
		xrTableCell195.Dpi = 254f;
		xrTableCell195.Name = "xrTableCell195";
		xrTableCell195.Weight = 1.4141502951642275;
		xrTableCell196.Dpi = 254f;
		xrTableCell196.Name = "xrTableCell196";
		xrTableCell196.Weight = 1.414150079156211;
		xrTableRow15.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell197, xrTableCell198, xrTableCell199, xrTableCell200, xrTableCell201, xrTableCell202, xrTableCell203, xrTableCell204, xrTableCell205, xrTableCell206,
			xrTableCell207, xrTableCell208, xrTableCell209, xrTableCell210, xrTableCell211
		});
		xrTableRow15.Dpi = 254f;
		xrTableRow15.Name = "xrTableRow15";
		xrTableRow15.Weight = 1.0;
		xrTableCell197.Dpi = 254f;
		xrTableCell197.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell197.Name = "xrTableCell197";
		xrTableCell197.StylePriority.UseFont = false;
		xrTableCell197.Text = "6";
		xrTableCell197.Weight = 2.8283006612105996;
		xrTableCell198.Dpi = 254f;
		xrTableCell198.Name = "xrTableCell198";
		xrTableCell198.Weight = 1.4141503436999736;
		xrTableCell199.Dpi = 254f;
		xrTableCell199.Name = "xrTableCell199";
		xrTableCell199.Weight = 1.4141502951642275;
		xrTableCell200.Dpi = 254f;
		xrTableCell200.Name = "xrTableCell200";
		xrTableCell200.Weight = 1.4141502951642275;
		xrTableCell201.Dpi = 254f;
		xrTableCell201.Name = "xrTableCell201";
		xrTableCell201.Weight = 1.4141502951642275;
		xrTableCell202.Dpi = 254f;
		xrTableCell202.Name = "xrTableCell202";
		xrTableCell202.Weight = 1.4141502951642275;
		xrTableCell203.Dpi = 254f;
		xrTableCell203.Name = "xrTableCell203";
		xrTableCell203.Weight = 1.4141502951642275;
		xrTableCell204.Dpi = 254f;
		xrTableCell204.Name = "xrTableCell204";
		xrTableCell204.Weight = 1.4141502951642275;
		xrTableCell205.Dpi = 254f;
		xrTableCell205.Name = "xrTableCell205";
		xrTableCell205.Weight = 1.4141502951642275;
		xrTableCell206.Dpi = 254f;
		xrTableCell206.Name = "xrTableCell206";
		xrTableCell206.Weight = 1.4141502951642275;
		xrTableCell207.Dpi = 254f;
		xrTableCell207.Name = "xrTableCell207";
		xrTableCell207.Weight = 1.4141502951642275;
		xrTableCell208.Dpi = 254f;
		xrTableCell208.Name = "xrTableCell208";
		xrTableCell208.Weight = 1.4141502951642275;
		xrTableCell209.Dpi = 254f;
		xrTableCell209.Name = "xrTableCell209";
		xrTableCell209.Weight = 1.4141502951642275;
		xrTableCell210.Dpi = 254f;
		xrTableCell210.Name = "xrTableCell210";
		xrTableCell210.Weight = 1.4141502951642275;
		xrTableCell211.Dpi = 254f;
		xrTableCell211.Name = "xrTableCell211";
		xrTableCell211.Weight = 1.414150079156211;
		xrTableRow16.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell212, xrTableCell213, xrTableCell214, xrTableCell215, xrTableCell216, xrTableCell217, xrTableCell218, xrTableCell219, xrTableCell220, xrTableCell221,
			xrTableCell222, xrTableCell223, xrTableCell224, xrTableCell225, xrTableCell226
		});
		xrTableRow16.Dpi = 254f;
		xrTableRow16.Name = "xrTableRow16";
		xrTableRow16.Weight = 1.0;
		xrTableCell212.Dpi = 254f;
		xrTableCell212.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell212.Name = "xrTableCell212";
		xrTableCell212.StylePriority.UseFont = false;
		xrTableCell212.Text = "7";
		xrTableCell212.Weight = 2.8283006612105996;
		xrTableCell213.Dpi = 254f;
		xrTableCell213.Name = "xrTableCell213";
		xrTableCell213.Weight = 1.4141503436999736;
		xrTableCell214.Dpi = 254f;
		xrTableCell214.Name = "xrTableCell214";
		xrTableCell214.Weight = 1.4141502951642275;
		xrTableCell215.Dpi = 254f;
		xrTableCell215.Name = "xrTableCell215";
		xrTableCell215.Weight = 1.4141502951642275;
		xrTableCell216.Dpi = 254f;
		xrTableCell216.Name = "xrTableCell216";
		xrTableCell216.Weight = 1.4141502951642275;
		xrTableCell217.Dpi = 254f;
		xrTableCell217.Name = "xrTableCell217";
		xrTableCell217.Weight = 1.4141502951642275;
		xrTableCell218.Dpi = 254f;
		xrTableCell218.Name = "xrTableCell218";
		xrTableCell218.Weight = 1.4141502951642275;
		xrTableCell219.Dpi = 254f;
		xrTableCell219.Name = "xrTableCell219";
		xrTableCell219.Weight = 1.4141502951642275;
		xrTableCell220.Dpi = 254f;
		xrTableCell220.Name = "xrTableCell220";
		xrTableCell220.Weight = 1.4141502951642275;
		xrTableCell221.Dpi = 254f;
		xrTableCell221.Name = "xrTableCell221";
		xrTableCell221.Weight = 1.4141502951642275;
		xrTableCell222.Dpi = 254f;
		xrTableCell222.Name = "xrTableCell222";
		xrTableCell222.Weight = 1.4141502951642275;
		xrTableCell223.Dpi = 254f;
		xrTableCell223.Name = "xrTableCell223";
		xrTableCell223.Weight = 1.4141502951642275;
		xrTableCell224.Dpi = 254f;
		xrTableCell224.Name = "xrTableCell224";
		xrTableCell224.Weight = 1.4141502951642275;
		xrTableCell225.Dpi = 254f;
		xrTableCell225.Name = "xrTableCell225";
		xrTableCell225.Weight = 1.4141502951642275;
		xrTableCell226.Dpi = 254f;
		xrTableCell226.Name = "xrTableCell226";
		xrTableCell226.Weight = 1.414150079156211;
		xrTable1.Dpi = 254f;
		xrTable1.Font = new DXFont("Arial", 8f);
		xrTable1.LocationFloat = new PointFloat(16.00007f, 494.2105f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(0, 0, 0, 0, 254f);
		xrTable1.Rows.AddRange(new XRTableRow[8] { xrTableRow1, xrTableRow2, xrTableRow3, xrTableRow4, xrTableRow5, xrTableRow6, xrTableRow7, xrTableRow8 });
		xrTable1.SizeF = new SizeF(688f, 399.9999f);
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UsePadding = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[8] { xrTableCell1, xrTableCell2, xrTableCell4, xrTableCell6, xrTableCell8, xrTableCell10, xrTableCell12, xrTableCell14 });
		xrTableRow1.Dpi = 254f;
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Dpi = 254f;
		xrTableCell1.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.Text = "Week";
		xrTableCell1.Weight = 2.651531797907593;
		xrTableCell2.Dpi = 254f;
		xrTableCell2.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.Text = "MON";
		xrTableCell2.Weight = 2.6515317858527174;
		xrTableCell4.Dpi = 254f;
		xrTableCell4.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "TUE";
		xrTableCell4.Weight = 2.6515317858527183;
		xrTableCell6.Dpi = 254f;
		xrTableCell6.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.Text = "WED";
		xrTableCell6.Weight = 2.6515317858527174;
		xrTableCell8.Dpi = 254f;
		xrTableCell8.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.Text = "THU";
		xrTableCell8.Weight = 2.6515317858527174;
		xrTableCell10.Dpi = 254f;
		xrTableCell10.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.Text = "FRI";
		xrTableCell10.Weight = 2.6515317858527174;
		xrTableCell12.Dpi = 254f;
		xrTableCell12.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.Text = "SAT";
		xrTableCell12.Weight = 2.651531785852717;
		xrTableCell14.Dpi = 254f;
		xrTableCell14.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.Text = "SUN";
		xrTableCell14.Weight = 2.6515318238862715;
		xrTableRow2.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell19, xrTableCell20, xrTableCell21, xrTableCell22, xrTableCell23, xrTableCell24, xrTableCell25, xrTableCell26, xrTableCell27, xrTableCell28,
			xrTableCell29, xrTableCell30, xrTableCell31, xrTableCell32, xrTableCell33
		});
		xrTableRow2.Dpi = 254f;
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell19.Dpi = 254f;
		xrTableCell19.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.Text = "1";
		xrTableCell19.Weight = 2.8283006612105996;
		xrTableCell20.Dpi = 254f;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.Weight = 1.4141503436999736;
		xrTableCell21.Dpi = 254f;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Weight = 1.4141502951642275;
		xrTableCell22.Dpi = 254f;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Weight = 1.4141502951642275;
		xrTableCell23.Dpi = 254f;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.Weight = 1.4141502951642275;
		xrTableCell24.Dpi = 254f;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Weight = 1.4141502951642275;
		xrTableCell25.Dpi = 254f;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Weight = 1.4141502951642275;
		xrTableCell26.Dpi = 254f;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.Weight = 1.4141502951642275;
		xrTableCell27.Dpi = 254f;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Weight = 1.4141502951642275;
		xrTableCell28.Dpi = 254f;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Weight = 1.4141502951642275;
		xrTableCell29.Dpi = 254f;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.Weight = 1.4141502951642275;
		xrTableCell30.Dpi = 254f;
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.Weight = 1.4141502951642275;
		xrTableCell31.Dpi = 254f;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Weight = 1.4141502951642275;
		xrTableCell32.Dpi = 254f;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.Weight = 1.4141502951642275;
		xrTableCell33.Dpi = 254f;
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.Weight = 1.414150079156211;
		xrTableRow3.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell37, xrTableCell38, xrTableCell39, xrTableCell40, xrTableCell41, xrTableCell42, xrTableCell43, xrTableCell44, xrTableCell45, xrTableCell46,
			xrTableCell47, xrTableCell48, xrTableCell49, xrTableCell50, xrTableCell51
		});
		xrTableRow3.Dpi = 254f;
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell37.Dpi = 254f;
		xrTableCell37.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.Text = "2";
		xrTableCell37.Weight = 2.8283006612105996;
		xrTableCell38.Dpi = 254f;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.Weight = 1.4141503436999736;
		xrTableCell39.Dpi = 254f;
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.Weight = 1.4141502951642275;
		xrTableCell40.Dpi = 254f;
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.Weight = 1.4141502951642275;
		xrTableCell41.Dpi = 254f;
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.Weight = 1.4141502951642275;
		xrTableCell42.Dpi = 254f;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.Weight = 1.4141502951642275;
		xrTableCell43.Dpi = 254f;
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.Weight = 1.4141502951642275;
		xrTableCell44.Dpi = 254f;
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.Weight = 1.4141502951642275;
		xrTableCell45.Dpi = 254f;
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.Weight = 1.4141502951642275;
		xrTableCell46.Dpi = 254f;
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.Weight = 1.4141502951642275;
		xrTableCell47.Dpi = 254f;
		xrTableCell47.Name = "xrTableCell47";
		xrTableCell47.Weight = 1.4141502951642275;
		xrTableCell48.Dpi = 254f;
		xrTableCell48.Name = "xrTableCell48";
		xrTableCell48.Weight = 1.4141502951642275;
		xrTableCell49.Dpi = 254f;
		xrTableCell49.Name = "xrTableCell49";
		xrTableCell49.Weight = 1.4141502951642275;
		xrTableCell50.Dpi = 254f;
		xrTableCell50.Name = "xrTableCell50";
		xrTableCell50.Weight = 1.4141502951642275;
		xrTableCell51.Dpi = 254f;
		xrTableCell51.Name = "xrTableCell51";
		xrTableCell51.Weight = 1.414150079156211;
		xrTableRow4.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell55, xrTableCell56, xrTableCell57, xrTableCell58, xrTableCell59, xrTableCell60, xrTableCell61, xrTableCell62, xrTableCell63, xrTableCell64,
			xrTableCell65, xrTableCell66, xrTableCell67, xrTableCell68, xrTableCell69
		});
		xrTableRow4.Dpi = 254f;
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell55.Dpi = 254f;
		xrTableCell55.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell55.Name = "xrTableCell55";
		xrTableCell55.StylePriority.UseFont = false;
		xrTableCell55.Text = "3";
		xrTableCell55.Weight = 2.8283006612105996;
		xrTableCell56.Dpi = 254f;
		xrTableCell56.Name = "xrTableCell56";
		xrTableCell56.Weight = 1.4141503436999736;
		xrTableCell57.Dpi = 254f;
		xrTableCell57.Name = "xrTableCell57";
		xrTableCell57.Weight = 1.4141502951642275;
		xrTableCell58.Dpi = 254f;
		xrTableCell58.Name = "xrTableCell58";
		xrTableCell58.Weight = 1.4141502951642275;
		xrTableCell59.Dpi = 254f;
		xrTableCell59.Name = "xrTableCell59";
		xrTableCell59.Weight = 1.4141502951642275;
		xrTableCell60.Dpi = 254f;
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.Weight = 1.4141502951642275;
		xrTableCell61.Dpi = 254f;
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.Weight = 1.4141502951642275;
		xrTableCell62.Dpi = 254f;
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.Weight = 1.4141502951642275;
		xrTableCell63.Dpi = 254f;
		xrTableCell63.Name = "xrTableCell63";
		xrTableCell63.Weight = 1.4141502951642275;
		xrTableCell64.Dpi = 254f;
		xrTableCell64.Name = "xrTableCell64";
		xrTableCell64.Weight = 1.4141502951642275;
		xrTableCell65.Dpi = 254f;
		xrTableCell65.Name = "xrTableCell65";
		xrTableCell65.Weight = 1.4141502951642275;
		xrTableCell66.Dpi = 254f;
		xrTableCell66.Name = "xrTableCell66";
		xrTableCell66.Weight = 1.4141502951642275;
		xrTableCell67.Dpi = 254f;
		xrTableCell67.Name = "xrTableCell67";
		xrTableCell67.Weight = 1.4141502951642275;
		xrTableCell68.Dpi = 254f;
		xrTableCell68.Name = "xrTableCell68";
		xrTableCell68.Weight = 1.4141502951642275;
		xrTableCell69.Dpi = 254f;
		xrTableCell69.Name = "xrTableCell69";
		xrTableCell69.Weight = 1.414150079156211;
		xrTableRow5.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell73, xrTableCell74, xrTableCell75, xrTableCell76, xrTableCell77, xrTableCell78, xrTableCell79, xrTableCell80, xrTableCell81, xrTableCell82,
			xrTableCell83, xrTableCell84, xrTableCell85, xrTableCell86, xrTableCell87
		});
		xrTableRow5.Dpi = 254f;
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell73.Dpi = 254f;
		xrTableCell73.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell73.Name = "xrTableCell73";
		xrTableCell73.StylePriority.UseFont = false;
		xrTableCell73.Text = "4";
		xrTableCell73.Weight = 2.8283006612105996;
		xrTableCell74.Dpi = 254f;
		xrTableCell74.Name = "xrTableCell74";
		xrTableCell74.Weight = 1.4141503436999736;
		xrTableCell75.Dpi = 254f;
		xrTableCell75.Name = "xrTableCell75";
		xrTableCell75.Weight = 1.4141502951642275;
		xrTableCell76.Dpi = 254f;
		xrTableCell76.Name = "xrTableCell76";
		xrTableCell76.Weight = 1.4141502951642275;
		xrTableCell77.Dpi = 254f;
		xrTableCell77.Name = "xrTableCell77";
		xrTableCell77.Weight = 1.4141502951642275;
		xrTableCell78.Dpi = 254f;
		xrTableCell78.Name = "xrTableCell78";
		xrTableCell78.Weight = 1.4141502951642275;
		xrTableCell79.Dpi = 254f;
		xrTableCell79.Name = "xrTableCell79";
		xrTableCell79.Weight = 1.4141502951642275;
		xrTableCell80.Dpi = 254f;
		xrTableCell80.Name = "xrTableCell80";
		xrTableCell80.Weight = 1.4141502951642275;
		xrTableCell81.Dpi = 254f;
		xrTableCell81.Name = "xrTableCell81";
		xrTableCell81.Weight = 1.4141502951642275;
		xrTableCell82.Dpi = 254f;
		xrTableCell82.Name = "xrTableCell82";
		xrTableCell82.Weight = 1.4141502951642275;
		xrTableCell83.Dpi = 254f;
		xrTableCell83.Name = "xrTableCell83";
		xrTableCell83.Weight = 1.4141502951642275;
		xrTableCell84.Dpi = 254f;
		xrTableCell84.Name = "xrTableCell84";
		xrTableCell84.Weight = 1.4141502951642275;
		xrTableCell85.Dpi = 254f;
		xrTableCell85.Name = "xrTableCell85";
		xrTableCell85.Weight = 1.4141502951642275;
		xrTableCell86.Dpi = 254f;
		xrTableCell86.Name = "xrTableCell86";
		xrTableCell86.Weight = 1.4141502951642275;
		xrTableCell87.Dpi = 254f;
		xrTableCell87.Name = "xrTableCell87";
		xrTableCell87.Weight = 1.414150079156211;
		xrTableRow6.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell91, xrTableCell92, xrTableCell93, xrTableCell94, xrTableCell95, xrTableCell96, xrTableCell97, xrTableCell98, xrTableCell99, xrTableCell100,
			xrTableCell101, xrTableCell102, xrTableCell103, xrTableCell104, xrTableCell105
		});
		xrTableRow6.Dpi = 254f;
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell91.Dpi = 254f;
		xrTableCell91.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell91.Name = "xrTableCell91";
		xrTableCell91.StylePriority.UseFont = false;
		xrTableCell91.Text = "5";
		xrTableCell91.Weight = 2.8283006612105996;
		xrTableCell92.Dpi = 254f;
		xrTableCell92.Name = "xrTableCell92";
		xrTableCell92.Weight = 1.4141503436999736;
		xrTableCell93.Dpi = 254f;
		xrTableCell93.Name = "xrTableCell93";
		xrTableCell93.Weight = 1.4141502951642275;
		xrTableCell94.Dpi = 254f;
		xrTableCell94.Name = "xrTableCell94";
		xrTableCell94.Weight = 1.4141502951642275;
		xrTableCell95.Dpi = 254f;
		xrTableCell95.Name = "xrTableCell95";
		xrTableCell95.Weight = 1.4141502951642275;
		xrTableCell96.Dpi = 254f;
		xrTableCell96.Name = "xrTableCell96";
		xrTableCell96.Weight = 1.4141502951642275;
		xrTableCell97.Dpi = 254f;
		xrTableCell97.Name = "xrTableCell97";
		xrTableCell97.Weight = 1.4141502951642275;
		xrTableCell98.Dpi = 254f;
		xrTableCell98.Name = "xrTableCell98";
		xrTableCell98.Weight = 1.4141502951642275;
		xrTableCell99.Dpi = 254f;
		xrTableCell99.Name = "xrTableCell99";
		xrTableCell99.Weight = 1.4141502951642275;
		xrTableCell100.Dpi = 254f;
		xrTableCell100.Name = "xrTableCell100";
		xrTableCell100.Weight = 1.4141502951642275;
		xrTableCell101.Dpi = 254f;
		xrTableCell101.Name = "xrTableCell101";
		xrTableCell101.Weight = 1.4141502951642275;
		xrTableCell102.Dpi = 254f;
		xrTableCell102.Name = "xrTableCell102";
		xrTableCell102.Weight = 1.4141502951642275;
		xrTableCell103.Dpi = 254f;
		xrTableCell103.Name = "xrTableCell103";
		xrTableCell103.Weight = 1.4141502951642275;
		xrTableCell104.Dpi = 254f;
		xrTableCell104.Name = "xrTableCell104";
		xrTableCell104.Weight = 1.4141502951642275;
		xrTableCell105.Dpi = 254f;
		xrTableCell105.Name = "xrTableCell105";
		xrTableCell105.Weight = 1.414150079156211;
		xrTableRow7.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell109, xrTableCell110, xrTableCell111, xrTableCell112, xrTableCell113, xrTableCell114, xrTableCell115, xrTableCell116, xrTableCell117, xrTableCell118,
			xrTableCell119, xrTableCell120, xrTableCell121, xrTableCell122, xrTableCell123
		});
		xrTableRow7.Dpi = 254f;
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell109.Dpi = 254f;
		xrTableCell109.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell109.Name = "xrTableCell109";
		xrTableCell109.StylePriority.UseFont = false;
		xrTableCell109.Text = "6";
		xrTableCell109.Weight = 2.8283006612105996;
		xrTableCell110.Dpi = 254f;
		xrTableCell110.Name = "xrTableCell110";
		xrTableCell110.Weight = 1.4141503436999736;
		xrTableCell111.Dpi = 254f;
		xrTableCell111.Name = "xrTableCell111";
		xrTableCell111.Weight = 1.4141502951642275;
		xrTableCell112.Dpi = 254f;
		xrTableCell112.Name = "xrTableCell112";
		xrTableCell112.Weight = 1.4141502951642275;
		xrTableCell113.Dpi = 254f;
		xrTableCell113.Name = "xrTableCell113";
		xrTableCell113.Weight = 1.4141502951642275;
		xrTableCell114.Dpi = 254f;
		xrTableCell114.Name = "xrTableCell114";
		xrTableCell114.Weight = 1.4141502951642275;
		xrTableCell115.Dpi = 254f;
		xrTableCell115.Name = "xrTableCell115";
		xrTableCell115.Weight = 1.4141502951642275;
		xrTableCell116.Dpi = 254f;
		xrTableCell116.Name = "xrTableCell116";
		xrTableCell116.Weight = 1.4141502951642275;
		xrTableCell117.Dpi = 254f;
		xrTableCell117.Name = "xrTableCell117";
		xrTableCell117.Weight = 1.4141502951642275;
		xrTableCell118.Dpi = 254f;
		xrTableCell118.Name = "xrTableCell118";
		xrTableCell118.Weight = 1.4141502951642275;
		xrTableCell119.Dpi = 254f;
		xrTableCell119.Name = "xrTableCell119";
		xrTableCell119.Weight = 1.4141502951642275;
		xrTableCell120.Dpi = 254f;
		xrTableCell120.Name = "xrTableCell120";
		xrTableCell120.Weight = 1.4141502951642275;
		xrTableCell121.Dpi = 254f;
		xrTableCell121.Name = "xrTableCell121";
		xrTableCell121.Weight = 1.4141502951642275;
		xrTableCell122.Dpi = 254f;
		xrTableCell122.Name = "xrTableCell122";
		xrTableCell122.Weight = 1.4141502951642275;
		xrTableCell123.Dpi = 254f;
		xrTableCell123.Name = "xrTableCell123";
		xrTableCell123.Weight = 1.414150079156211;
		xrTableRow8.Cells.AddRange(new XRTableCell[15]
		{
			xrTableCell127, xrTableCell128, xrTableCell129, xrTableCell130, xrTableCell131, xrTableCell132, xrTableCell133, xrTableCell134, xrTableCell135, xrTableCell136,
			xrTableCell137, xrTableCell138, xrTableCell139, xrTableCell140, xrTableCell141
		});
		xrTableRow8.Dpi = 254f;
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell127.Dpi = 254f;
		xrTableCell127.Font = new DXFont("Arial", 8f, DXFontStyle.Bold);
		xrTableCell127.Name = "xrTableCell127";
		xrTableCell127.StylePriority.UseFont = false;
		xrTableCell127.Text = "7";
		xrTableCell127.Weight = 2.8283006612105996;
		xrTableCell128.Dpi = 254f;
		xrTableCell128.Name = "xrTableCell128";
		xrTableCell128.Weight = 1.4141503436999736;
		xrTableCell129.Dpi = 254f;
		xrTableCell129.Name = "xrTableCell129";
		xrTableCell129.Weight = 1.4141502951642275;
		xrTableCell130.Dpi = 254f;
		xrTableCell130.Name = "xrTableCell130";
		xrTableCell130.Weight = 1.4141502951642275;
		xrTableCell131.Dpi = 254f;
		xrTableCell131.Name = "xrTableCell131";
		xrTableCell131.Weight = 1.4141502951642275;
		xrTableCell132.Dpi = 254f;
		xrTableCell132.Name = "xrTableCell132";
		xrTableCell132.Weight = 1.4141502951642275;
		xrTableCell133.Dpi = 254f;
		xrTableCell133.Name = "xrTableCell133";
		xrTableCell133.Weight = 1.4141502951642275;
		xrTableCell134.Dpi = 254f;
		xrTableCell134.Name = "xrTableCell134";
		xrTableCell134.Weight = 1.4141502951642275;
		xrTableCell135.Dpi = 254f;
		xrTableCell135.Name = "xrTableCell135";
		xrTableCell135.Weight = 1.4141502951642275;
		xrTableCell136.Dpi = 254f;
		xrTableCell136.Name = "xrTableCell136";
		xrTableCell136.Weight = 1.4141502951642275;
		xrTableCell137.Dpi = 254f;
		xrTableCell137.Name = "xrTableCell137";
		xrTableCell137.Weight = 1.4141502951642275;
		xrTableCell138.Dpi = 254f;
		xrTableCell138.Name = "xrTableCell138";
		xrTableCell138.Weight = 1.4141502951642275;
		xrTableCell139.Dpi = 254f;
		xrTableCell139.Name = "xrTableCell139";
		xrTableCell139.Weight = 1.4141502951642275;
		xrTableCell140.Dpi = 254f;
		xrTableCell140.Name = "xrTableCell140";
		xrTableCell140.Weight = 1.4141502951642275;
		xrTableCell141.Dpi = 254f;
		xrTableCell141.Name = "xrTableCell141";
		xrTableCell141.Weight = 1.414150079156211;
		TopMargin.Dpi = 254f;
		TopMargin.HeightF = 23f;
		TopMargin.Name = "TopMargin";
		BottomMargin.Dpi = 254f;
		BottomMargin.HeightF = 23f;
		BottomMargin.Name = "BottomMargin";
		studentPreviewSourceTableAdapter.ClearBeforeFill = true;
		Paid.DataMember = "StudentPreviewSource";
		Paid.Expression = "[RequiredFees]-[cashOnAccount]";
		Paid.Name = "Paid";
		studStream.Description = "Student Stream";
		studStream.Name = "studStream";
		studStream.Visible = false;
		studClass.Description = "StudClass";
		studClass.Name = "studClass";
		studClass.Visible = false;
		dsMealCardv21.DataSetName = "dsMealCardv2";
		dsMealCardv21.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		dTableMealCardAdapter.ClearBeforeFill = true;
		calculatedField1.DataMember = "DTableMealCard";
		calculatedField1.Expression = "[RequiredFees]-[cashOnAccount]";
		calculatedField1.Name = "calculatedField1";
		base.Bands.AddRange(new Band[3] { Detail, TopMargin, BottomMargin });
		base.CalculatedFields.AddRange(new CalculatedField[2] { Paid, calculatedField1 });
		base.ComponentStorage.AddRange(new IComponent[1] { dsMealCardv21 });
		base.DataAdapter = dTableMealCardAdapter;
		base.DataMember = "DTableMealCard";
		base.DataSource = dsMealCardv21;
		Dpi = 254f;
		FilterString = "[StreamId] = ?studStream And [ClassId] = ?studClass";
		Font = new DXFont("Arial", 9.75f);
		base.Landscape = true;
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.PageHeight = 2100;
		base.PageWidth = 2970;
		base.PaperKind = DXPaperKind.A4;
		base.Parameters.AddRange(new Parameter[2] { studStream, studClass });
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 4;
		base.ReportUnit = ReportUnit.TenthsOfAMillimeter;
		base.SnapGridSize = 2f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "21.2";
		BeforePrint += MealCardsV2_BeforePrint;
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)dsMealCardv21).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
