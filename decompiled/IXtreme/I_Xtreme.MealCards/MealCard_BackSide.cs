using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace I_Xtreme.MealCards;

public class MealCard_BackSide : XtraReport
{
	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	public DetailBand Detail1;

	private XRPanel xrPanel1;

	private XRTable xrTable3;

	private XRTableRow xrTableRow15;

	private XRTableCell xrTableCell71;

	private XRTableCell xrTableCell72;

	private XRTableCell xrTableCell73;

	private XRTableCell xrTableCell74;

	private XRTableCell xrTableCell75;

	private XRTableRow xrTableRow16;

	private XRTableCell xrTableCell76;

	private XRTableCell xrTableCell77;

	private XRTableCell xrTableCell78;

	private XRTableCell xrTableCell79;

	private XRTableCell xrTableCell80;

	private XRTableRow xrTableRow17;

	private XRTableCell xrTableCell81;

	private XRTableCell xrTableCell82;

	private XRTableCell xrTableCell83;

	private XRTableCell xrTableCell84;

	private XRTableCell xrTableCell85;

	private XRTableRow xrTableRow18;

	private XRTableCell xrTableCell86;

	private XRTableCell xrTableCell87;

	private XRTableCell xrTableCell88;

	private XRTableCell xrTableCell89;

	private XRTableCell xrTableCell90;

	private XRTableRow xrTableRow19;

	private XRTableCell xrTableCell91;

	private XRTableCell xrTableCell92;

	private XRTableCell xrTableCell93;

	private XRTableCell xrTableCell94;

	private XRTableCell xrTableCell95;

	private XRTableRow xrTableRow20;

	private XRTableCell xrTableCell96;

	private XRTableCell xrTableCell97;

	private XRTableCell xrTableCell98;

	private XRTableCell xrTableCell99;

	private XRTableCell xrTableCell100;

	private XRTableRow xrTableRow21;

	private XRTableCell xrTableCell101;

	private XRTableCell xrTableCell102;

	private XRTable xrTable2;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell36;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell38;

	private XRTableCell xrTableCell39;

	private XRTableCell xrTableCell40;

	private XRTableRow xrTableRow9;

	private XRTableCell xrTableCell41;

	private XRTableCell xrTableCell42;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell45;

	private XRTableRow xrTableRow10;

	private XRTableCell xrTableCell46;

	private XRTableCell xrTableCell47;

	private XRTableCell xrTableCell48;

	private XRTableCell xrTableCell49;

	private XRTableCell xrTableCell50;

	private XRTableRow xrTableRow11;

	private XRTableCell xrTableCell51;

	private XRTableCell xrTableCell52;

	private XRTableCell xrTableCell53;

	private XRTableCell xrTableCell54;

	private XRTableCell xrTableCell55;

	private XRTableRow xrTableRow12;

	private XRTableCell xrTableCell56;

	private XRTableCell xrTableCell57;

	private XRTableCell xrTableCell58;

	private XRTableCell xrTableCell59;

	private XRTableCell xrTableCell60;

	private XRTableRow xrTableRow13;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell62;

	private XRTableCell xrTableCell63;

	private XRTableCell xrTableCell64;

	private XRTableCell xrTableCell65;

	private XRTableRow xrTableRow14;

	private XRTableCell xrTableCell66;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell4;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell10;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell30;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRTableCell xrTableCell67;

	public MealCard_BackSide()
	{
		InitializeComponent();
	}

	private void BackSide_BeforePrint(object sender, CancelEventArgs e)
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
		Detail1 = new DetailBand();
		xrPanel1 = new XRPanel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrTable3 = new XRTable();
		xrTableRow15 = new XRTableRow();
		xrTableCell71 = new XRTableCell();
		xrTableCell72 = new XRTableCell();
		xrTableCell73 = new XRTableCell();
		xrTableCell74 = new XRTableCell();
		xrTableCell75 = new XRTableCell();
		xrTableRow16 = new XRTableRow();
		xrTableCell76 = new XRTableCell();
		xrTableCell77 = new XRTableCell();
		xrTableCell78 = new XRTableCell();
		xrTableCell79 = new XRTableCell();
		xrTableCell80 = new XRTableCell();
		xrTableRow17 = new XRTableRow();
		xrTableCell81 = new XRTableCell();
		xrTableCell82 = new XRTableCell();
		xrTableCell83 = new XRTableCell();
		xrTableCell84 = new XRTableCell();
		xrTableCell85 = new XRTableCell();
		xrTableRow18 = new XRTableRow();
		xrTableCell86 = new XRTableCell();
		xrTableCell87 = new XRTableCell();
		xrTableCell88 = new XRTableCell();
		xrTableCell89 = new XRTableCell();
		xrTableCell90 = new XRTableCell();
		xrTableRow19 = new XRTableRow();
		xrTableCell91 = new XRTableCell();
		xrTableCell92 = new XRTableCell();
		xrTableCell93 = new XRTableCell();
		xrTableCell94 = new XRTableCell();
		xrTableCell95 = new XRTableCell();
		xrTableRow20 = new XRTableRow();
		xrTableCell96 = new XRTableCell();
		xrTableCell97 = new XRTableCell();
		xrTableCell98 = new XRTableCell();
		xrTableCell99 = new XRTableCell();
		xrTableCell100 = new XRTableCell();
		xrTableRow21 = new XRTableRow();
		xrTableCell101 = new XRTableCell();
		xrTableCell102 = new XRTableCell();
		xrTable2 = new XRTable();
		xrTableRow8 = new XRTableRow();
		xrTableCell36 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell39 = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		xrTableRow9 = new XRTableRow();
		xrTableCell41 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
		xrTableRow10 = new XRTableRow();
		xrTableCell46 = new XRTableCell();
		xrTableCell47 = new XRTableCell();
		xrTableCell48 = new XRTableCell();
		xrTableCell49 = new XRTableCell();
		xrTableCell50 = new XRTableCell();
		xrTableRow11 = new XRTableRow();
		xrTableCell51 = new XRTableCell();
		xrTableCell52 = new XRTableCell();
		xrTableCell53 = new XRTableCell();
		xrTableCell54 = new XRTableCell();
		xrTableCell55 = new XRTableCell();
		xrTableRow12 = new XRTableRow();
		xrTableCell56 = new XRTableCell();
		xrTableCell57 = new XRTableCell();
		xrTableCell58 = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableCell60 = new XRTableCell();
		xrTableRow13 = new XRTableRow();
		xrTableCell61 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		xrTableCell63 = new XRTableCell();
		xrTableCell64 = new XRTableCell();
		xrTableCell65 = new XRTableCell();
		xrTableRow14 = new XRTableRow();
		xrTableCell66 = new XRTableCell();
		xrTableCell67 = new XRTableCell();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTableCell11 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableRow4 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		xrTableCell21 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		xrTableCell26 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[1] { xrPanel1 });
		Detail1.HeightF = 220f;
		Detail1.KeepTogether = true;
		Detail1.KeepTogetherWithDetailReports = true;
		Detail1.MultiColumn.ColumnCount = 2;
		Detail1.MultiColumn.ColumnSpacing = 5f;
		Detail1.MultiColumn.ColumnWidth = 400f;
		Detail1.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail1.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail1.Name = "Detail1";
		Detail1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.TextAlignment = TextAlignment.TopLeft;
		xrPanel1.BackColor = Color.Transparent;
		xrPanel1.Borders = BorderSide.All;
		xrPanel1.BorderWidth = 2f;
		xrPanel1.Controls.AddRange(new XRControl[9] { xrLabel6, xrLabel5, xrLabel4, xrLabel3, xrLabel2, xrLabel1, xrTable3, xrTable2, xrTable1 });
		xrPanel1.LocationFloat = new PointFloat(5f, 7f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(389f, 207.2917f);
		xrPanel1.StylePriority.UseBackColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		xrPanel1.StylePriority.UseBorderWidth = false;
		xrLabel6.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel6.Borders = BorderSide.Bottom;
		xrLabel6.BorderWidth = 1f;
		xrLabel6.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.LocationFloat = new PointFloat(263f, 27f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(115f, 20.99999f);
		xrLabel6.StylePriority.UseBorderDashStyle = false;
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseBorderWidth = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel5.Borders = BorderSide.None;
		xrLabel5.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel5.LocationFloat = new PointFloat(263f, 5.000005f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(115f, 20.99999f);
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "MONTH";
		xrLabel5.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel4.LocationFloat = new PointFloat(138f, 5.000005f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(115f, 20.99999f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "MONTH";
		xrLabel4.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel3.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel3.Borders = BorderSide.Bottom;
		xrLabel3.BorderWidth = 1f;
		xrLabel3.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel3.LocationFloat = new PointFloat(138f, 27f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(115f, 20.99999f);
		xrLabel3.StylePriority.UseBorderDashStyle = false;
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseBorderWidth = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel2.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel2.Borders = BorderSide.Bottom;
		xrLabel2.BorderWidth = 1f;
		xrLabel2.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel2.LocationFloat = new PointFloat(8.000008f, 27f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(115f, 20.99999f);
		xrLabel2.StylePriority.UseBorderDashStyle = false;
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseBorderWidth = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.Borders = BorderSide.None;
		xrLabel1.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel1.LocationFloat = new PointFloat(8.000008f, 5.000005f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(115f, 20.99999f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "MONTH";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrTable3.Borders = BorderSide.All;
		xrTable3.BorderWidth = 1f;
		xrTable3.Font = new DXFont("Tahoma", 8.25f);
		xrTable3.LocationFloat = new PointFloat(263f, 67f);
		xrTable3.Name = "xrTable3";
		xrTable3.Rows.AddRange(new XRTableRow[7] { xrTableRow15, xrTableRow16, xrTableRow17, xrTableRow18, xrTableRow19, xrTableRow20, xrTableRow21 });
		xrTable3.SizeF = new SizeF(115f, 125f);
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseBorderWidth = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow15.Cells.AddRange(new XRTableCell[5] { xrTableCell71, xrTableCell72, xrTableCell73, xrTableCell74, xrTableCell75 });
		xrTableRow15.Name = "xrTableRow15";
		xrTableRow15.Weight = 1.0;
		xrTableCell71.Name = "xrTableCell71";
		xrTableCell71.Text = "1";
		xrTableCell71.Weight = 0.15000000000000002;
		xrTableCell72.Name = "xrTableCell72";
		xrTableCell72.Text = "2";
		xrTableCell72.Weight = 0.14999999999999994;
		xrTableCell73.Name = "xrTableCell73";
		xrTableCell73.Text = "3";
		xrTableCell73.Weight = 0.14999999999999986;
		xrTableCell74.Name = "xrTableCell74";
		xrTableCell74.Text = "4";
		xrTableCell74.Weight = 0.15000000000000008;
		xrTableCell75.Name = "xrTableCell75";
		xrTableCell75.Text = "5";
		xrTableCell75.Weight = 0.14999999999999997;
		xrTableRow16.Cells.AddRange(new XRTableCell[5] { xrTableCell76, xrTableCell77, xrTableCell78, xrTableCell79, xrTableCell80 });
		xrTableRow16.Name = "xrTableRow16";
		xrTableRow16.Weight = 1.0;
		xrTableCell76.Name = "xrTableCell76";
		xrTableCell76.Text = "6";
		xrTableCell76.Weight = 0.15000000000000002;
		xrTableCell77.Name = "xrTableCell77";
		xrTableCell77.Text = "7";
		xrTableCell77.Weight = 0.14999999999999994;
		xrTableCell78.Name = "xrTableCell78";
		xrTableCell78.Text = "8";
		xrTableCell78.Weight = 0.14999999999999986;
		xrTableCell79.Name = "xrTableCell79";
		xrTableCell79.Text = "9";
		xrTableCell79.Weight = 0.15000000000000008;
		xrTableCell80.Name = "xrTableCell80";
		xrTableCell80.Text = "10";
		xrTableCell80.Weight = 0.14999999999999997;
		xrTableRow17.Cells.AddRange(new XRTableCell[5] { xrTableCell81, xrTableCell82, xrTableCell83, xrTableCell84, xrTableCell85 });
		xrTableRow17.Name = "xrTableRow17";
		xrTableRow17.Weight = 1.0;
		xrTableCell81.Name = "xrTableCell81";
		xrTableCell81.Text = "11";
		xrTableCell81.Weight = 0.15000000000000002;
		xrTableCell82.Name = "xrTableCell82";
		xrTableCell82.Text = "12";
		xrTableCell82.Weight = 0.14999999999999994;
		xrTableCell83.Name = "xrTableCell83";
		xrTableCell83.Text = "13";
		xrTableCell83.Weight = 0.14999999999999986;
		xrTableCell84.Name = "xrTableCell84";
		xrTableCell84.Text = "14";
		xrTableCell84.Weight = 0.15000000000000008;
		xrTableCell85.Name = "xrTableCell85";
		xrTableCell85.Text = "15";
		xrTableCell85.Weight = 0.14999999999999997;
		xrTableRow18.Cells.AddRange(new XRTableCell[5] { xrTableCell86, xrTableCell87, xrTableCell88, xrTableCell89, xrTableCell90 });
		xrTableRow18.Name = "xrTableRow18";
		xrTableRow18.Weight = 1.0;
		xrTableCell86.Name = "xrTableCell86";
		xrTableCell86.Text = "16";
		xrTableCell86.Weight = 0.15000000000000002;
		xrTableCell87.Name = "xrTableCell87";
		xrTableCell87.Text = "17";
		xrTableCell87.Weight = 0.14999999999999994;
		xrTableCell88.Name = "xrTableCell88";
		xrTableCell88.Text = "18";
		xrTableCell88.Weight = 0.14999999999999986;
		xrTableCell89.Name = "xrTableCell89";
		xrTableCell89.Text = "19";
		xrTableCell89.Weight = 0.15000000000000008;
		xrTableCell90.Name = "xrTableCell90";
		xrTableCell90.Text = "20";
		xrTableCell90.Weight = 0.14999999999999997;
		xrTableRow19.Cells.AddRange(new XRTableCell[5] { xrTableCell91, xrTableCell92, xrTableCell93, xrTableCell94, xrTableCell95 });
		xrTableRow19.Name = "xrTableRow19";
		xrTableRow19.Weight = 1.0;
		xrTableCell91.Name = "xrTableCell91";
		xrTableCell91.Text = "21";
		xrTableCell91.Weight = 0.15000000000000002;
		xrTableCell92.Name = "xrTableCell92";
		xrTableCell92.Text = "22";
		xrTableCell92.Weight = 0.14999999999999994;
		xrTableCell93.Name = "xrTableCell93";
		xrTableCell93.Text = "23";
		xrTableCell93.Weight = 0.14999999999999986;
		xrTableCell94.Name = "xrTableCell94";
		xrTableCell94.Text = "24";
		xrTableCell94.Weight = 0.15000000000000008;
		xrTableCell95.Name = "xrTableCell95";
		xrTableCell95.Text = "25";
		xrTableCell95.Weight = 0.14999999999999997;
		xrTableRow20.Cells.AddRange(new XRTableCell[5] { xrTableCell96, xrTableCell97, xrTableCell98, xrTableCell99, xrTableCell100 });
		xrTableRow20.Name = "xrTableRow20";
		xrTableRow20.Weight = 1.0;
		xrTableCell96.Name = "xrTableCell96";
		xrTableCell96.Text = "26";
		xrTableCell96.Weight = 0.15000000000000002;
		xrTableCell97.Name = "xrTableCell97";
		xrTableCell97.Text = "27";
		xrTableCell97.Weight = 0.14999999999999994;
		xrTableCell98.Name = "xrTableCell98";
		xrTableCell98.Text = "28";
		xrTableCell98.Weight = 0.14999999999999986;
		xrTableCell99.Name = "xrTableCell99";
		xrTableCell99.Text = "29";
		xrTableCell99.Weight = 0.15000000000000008;
		xrTableCell100.Name = "xrTableCell100";
		xrTableCell100.Text = "30";
		xrTableCell100.Weight = 0.14999999999999997;
		xrTableRow21.Cells.AddRange(new XRTableCell[2] { xrTableCell101, xrTableCell102 });
		xrTableRow21.Name = "xrTableRow21";
		xrTableRow21.Weight = 1.0;
		xrTableCell101.Name = "xrTableCell101";
		xrTableCell101.Text = "31";
		xrTableCell101.Weight = 0.15000000000000002;
		xrTableCell102.Borders = BorderSide.Left | BorderSide.Top;
		xrTableCell102.Name = "xrTableCell102";
		xrTableCell102.StylePriority.UseBorders = false;
		xrTableCell102.Weight = 0.5999999999999999;
		xrTable2.Borders = BorderSide.All;
		xrTable2.BorderWidth = 1f;
		xrTable2.Font = new DXFont("Tahoma", 8.25f);
		xrTable2.LocationFloat = new PointFloat(138f, 67f);
		xrTable2.Name = "xrTable2";
		xrTable2.Rows.AddRange(new XRTableRow[7] { xrTableRow8, xrTableRow9, xrTableRow10, xrTableRow11, xrTableRow12, xrTableRow13, xrTableRow14 });
		xrTable2.SizeF = new SizeF(115f, 125f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseBorderWidth = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow8.Cells.AddRange(new XRTableCell[5] { xrTableCell36, xrTableCell37, xrTableCell38, xrTableCell39, xrTableCell40 });
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.Text = "1";
		xrTableCell36.Weight = 0.15000000000000002;
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.Text = "2";
		xrTableCell37.Weight = 0.14999999999999994;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.Text = "3";
		xrTableCell38.Weight = 0.14999999999999986;
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.Text = "4";
		xrTableCell39.Weight = 0.15000000000000008;
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.Text = "5";
		xrTableCell40.Weight = 0.14999999999999997;
		xrTableRow9.Cells.AddRange(new XRTableCell[5] { xrTableCell41, xrTableCell42, xrTableCell43, xrTableCell44, xrTableCell45 });
		xrTableRow9.Name = "xrTableRow9";
		xrTableRow9.Weight = 1.0;
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.Text = "6";
		xrTableCell41.Weight = 0.15000000000000002;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.Text = "7";
		xrTableCell42.Weight = 0.14999999999999994;
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.Text = "8";
		xrTableCell43.Weight = 0.14999999999999986;
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.Text = "9";
		xrTableCell44.Weight = 0.15000000000000008;
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.Text = "10";
		xrTableCell45.Weight = 0.14999999999999997;
		xrTableRow10.Cells.AddRange(new XRTableCell[5] { xrTableCell46, xrTableCell47, xrTableCell48, xrTableCell49, xrTableCell50 });
		xrTableRow10.Name = "xrTableRow10";
		xrTableRow10.Weight = 1.0;
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.Text = "11";
		xrTableCell46.Weight = 0.15000000000000002;
		xrTableCell47.Name = "xrTableCell47";
		xrTableCell47.Text = "12";
		xrTableCell47.Weight = 0.14999999999999994;
		xrTableCell48.Name = "xrTableCell48";
		xrTableCell48.Text = "13";
		xrTableCell48.Weight = 0.14999999999999986;
		xrTableCell49.Name = "xrTableCell49";
		xrTableCell49.Text = "14";
		xrTableCell49.Weight = 0.15000000000000008;
		xrTableCell50.Name = "xrTableCell50";
		xrTableCell50.Text = "15";
		xrTableCell50.Weight = 0.14999999999999997;
		xrTableRow11.Cells.AddRange(new XRTableCell[5] { xrTableCell51, xrTableCell52, xrTableCell53, xrTableCell54, xrTableCell55 });
		xrTableRow11.Name = "xrTableRow11";
		xrTableRow11.Weight = 1.0;
		xrTableCell51.Name = "xrTableCell51";
		xrTableCell51.Text = "16";
		xrTableCell51.Weight = 0.15000000000000002;
		xrTableCell52.Name = "xrTableCell52";
		xrTableCell52.Text = "17";
		xrTableCell52.Weight = 0.14999999999999994;
		xrTableCell53.Name = "xrTableCell53";
		xrTableCell53.Text = "18";
		xrTableCell53.Weight = 0.14999999999999986;
		xrTableCell54.Name = "xrTableCell54";
		xrTableCell54.Text = "19";
		xrTableCell54.Weight = 0.15000000000000008;
		xrTableCell55.Name = "xrTableCell55";
		xrTableCell55.Text = "20";
		xrTableCell55.Weight = 0.14999999999999997;
		xrTableRow12.Cells.AddRange(new XRTableCell[5] { xrTableCell56, xrTableCell57, xrTableCell58, xrTableCell59, xrTableCell60 });
		xrTableRow12.Name = "xrTableRow12";
		xrTableRow12.Weight = 1.0;
		xrTableCell56.Name = "xrTableCell56";
		xrTableCell56.Text = "21";
		xrTableCell56.Weight = 0.15000000000000002;
		xrTableCell57.Name = "xrTableCell57";
		xrTableCell57.Text = "22";
		xrTableCell57.Weight = 0.14999999999999994;
		xrTableCell58.Name = "xrTableCell58";
		xrTableCell58.Text = "23";
		xrTableCell58.Weight = 0.14999999999999986;
		xrTableCell59.Name = "xrTableCell59";
		xrTableCell59.Text = "24";
		xrTableCell59.Weight = 0.15000000000000008;
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.Text = "25";
		xrTableCell60.Weight = 0.14999999999999997;
		xrTableRow13.Cells.AddRange(new XRTableCell[5] { xrTableCell61, xrTableCell62, xrTableCell63, xrTableCell64, xrTableCell65 });
		xrTableRow13.Name = "xrTableRow13";
		xrTableRow13.Weight = 1.0;
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.Text = "26";
		xrTableCell61.Weight = 0.15000000000000002;
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.Text = "27";
		xrTableCell62.Weight = 0.14999999999999994;
		xrTableCell63.Name = "xrTableCell63";
		xrTableCell63.Text = "28";
		xrTableCell63.Weight = 0.14999999999999986;
		xrTableCell64.Name = "xrTableCell64";
		xrTableCell64.Text = "29";
		xrTableCell64.Weight = 0.15000000000000008;
		xrTableCell65.Name = "xrTableCell65";
		xrTableCell65.Text = "30";
		xrTableCell65.Weight = 0.14999999999999997;
		xrTableRow14.Cells.AddRange(new XRTableCell[2] { xrTableCell66, xrTableCell67 });
		xrTableRow14.Name = "xrTableRow14";
		xrTableRow14.Weight = 1.0;
		xrTableCell66.Name = "xrTableCell66";
		xrTableCell66.Text = "31";
		xrTableCell66.Weight = 0.15000000000000002;
		xrTableCell67.Borders = BorderSide.Left | BorderSide.Top;
		xrTableCell67.Name = "xrTableCell67";
		xrTableCell67.StylePriority.UseBorders = false;
		xrTableCell67.Weight = 0.5999999999999999;
		xrTable1.Borders = BorderSide.All;
		xrTable1.BorderWidth = 1f;
		xrTable1.Font = new DXFont("Tahoma", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable1.LocationFloat = new PointFloat(10.00001f, 67f);
		xrTable1.Name = "xrTable1";
		xrTable1.Rows.AddRange(new XRTableRow[7] { xrTableRow1, xrTableRow2, xrTableRow3, xrTableRow4, xrTableRow5, xrTableRow6, xrTableRow7 });
		xrTable1.SizeF = new SizeF(115f, 125f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseBorderWidth = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[5] { xrTableCell1, xrTableCell5, xrTableCell2, xrTableCell3, xrTableCell4 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Text = "1";
		xrTableCell1.Weight = 0.15000000000000002;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.Text = "2";
		xrTableCell5.Weight = 0.14999999999999994;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Text = "3";
		xrTableCell2.Weight = 0.14999999999999986;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.Text = "4";
		xrTableCell3.Weight = 0.15000000000000008;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Text = "5";
		xrTableCell4.Weight = 0.14999999999999997;
		xrTableRow2.Cells.AddRange(new XRTableCell[5] { xrTableCell6, xrTableCell7, xrTableCell8, xrTableCell9, xrTableCell10 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "6";
		xrTableCell6.Weight = 0.15000000000000002;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.Text = "7";
		xrTableCell7.Weight = 0.14999999999999994;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Text = "8";
		xrTableCell8.Weight = 0.14999999999999986;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Text = "9";
		xrTableCell9.Weight = 0.15000000000000008;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "10";
		xrTableCell10.Weight = 0.14999999999999997;
		xrTableRow3.Cells.AddRange(new XRTableCell[5] { xrTableCell11, xrTableCell12, xrTableCell13, xrTableCell14, xrTableCell15 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.Text = "11";
		xrTableCell11.Weight = 0.15000000000000002;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Text = "12";
		xrTableCell12.Weight = 0.14999999999999994;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Text = "13";
		xrTableCell13.Weight = 0.14999999999999986;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.Text = "14";
		xrTableCell14.Weight = 0.15000000000000008;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.Text = "15";
		xrTableCell15.Weight = 0.14999999999999997;
		xrTableRow4.Cells.AddRange(new XRTableCell[5] { xrTableCell16, xrTableCell17, xrTableCell18, xrTableCell19, xrTableCell20 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.Text = "16";
		xrTableCell16.Weight = 0.15000000000000002;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Text = "17";
		xrTableCell17.Weight = 0.14999999999999994;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.Text = "18";
		xrTableCell18.Weight = 0.14999999999999986;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.Text = "19";
		xrTableCell19.Weight = 0.15000000000000008;
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.Text = "20";
		xrTableCell20.Weight = 0.14999999999999997;
		xrTableRow5.Cells.AddRange(new XRTableCell[5] { xrTableCell21, xrTableCell22, xrTableCell23, xrTableCell24, xrTableCell25 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Text = "21";
		xrTableCell21.Weight = 0.15000000000000002;
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Text = "22";
		xrTableCell22.Weight = 0.14999999999999994;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.Text = "23";
		xrTableCell23.Weight = 0.14999999999999986;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Text = "24";
		xrTableCell24.Weight = 0.15000000000000008;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Text = "25";
		xrTableCell25.Weight = 0.14999999999999997;
		xrTableRow6.Cells.AddRange(new XRTableCell[5] { xrTableCell26, xrTableCell27, xrTableCell28, xrTableCell29, xrTableCell30 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.Text = "26";
		xrTableCell26.Weight = 0.15000000000000002;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Text = "27";
		xrTableCell27.Weight = 0.14999999999999994;
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Text = "28";
		xrTableCell28.Weight = 0.14999999999999986;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.Text = "29";
		xrTableCell29.Weight = 0.15000000000000008;
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.Text = "30";
		xrTableCell30.Weight = 0.14999999999999997;
		xrTableRow7.Cells.AddRange(new XRTableCell[2] { xrTableCell31, xrTableCell32 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Text = "31";
		xrTableCell31.Weight = 0.15000000000000002;
		xrTableCell32.Borders = BorderSide.Left | BorderSide.Top;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.StylePriority.UseBorders = false;
		xrTableCell32.Weight = 0.5999999999999999;
		topMarginBand1.HeightF = 30f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 5f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		base.DesignerOptions.ShowPrintingWarnings = false;
		base.Margins = new DXMargins(10f, 10f, 30f, 5f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ReportPrintOptions.DetailCount = 10;
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 10;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "13.1";
		base.Watermark.ImageTiling = true;
		BeforePrint += BackSide_BeforePrint;
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
