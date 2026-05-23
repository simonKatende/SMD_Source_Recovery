using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.DataSet_Previews;
using I_Xtreme.DataSet_Previews.GatePassTableAdapters;

namespace I_Xtreme;

public class gatePass_Multiple : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRLabel lblMessage;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private PageHeaderBand PageHeader;

	private XRLine xrLine2;

	private XRLine xrLine1;

	private XRLabel xrLabel35;

	private XRLabel xrLabel33;

	private XRLabel xrLabel31;

	private XRLabel xrLabel30;

	private XRLabel xrLabel29;

	private XRLabel xrLabel28;

	private XRPictureBox xrPictureBox1;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel lblClass;

	private XRLabel xrLabel2;

	private XRLabel lblName;

	private XRLabel xrLabel37;

	private XRLabel xrLabel36;

	private XRLabel xrLabel34;

	private XRPageInfo xrPageInfo3;

	private XRPageInfo xrPageInfo2;

	private XRPageInfo xrPageInfo1;

	private PageFooterBand PageFooter;

	public Parameter CapDate;

	private XRLabel xrLabel24;

	private XRLabel xrLabel23;

	private XRLabel xrLabel22;

	private XRLabel xrLabel27;

	private XRLabel xrLabel26;

	private XRLabel xrLabel25;

	private XRLabel xrLabel21;

	private XRLabel xrLabel17;

	private XRLabel xrLabel16;

	private XRLabel xrLabel15;

	private XRLabel xrLabel20;

	private XRLabel xrLabel19;

	private XRLabel xrLabel18;

	private XRLabel xrLabel13;

	private XRLabel xrLabel14;

	private XRLabel xrLabel12;

	private XRLabel xrLabel8;

	private XRLabel xrLabel39;

	private XRLabel xrLabel40;

	private XRSubreport xrSubreport1;

	private XRBarCode xrBarCode1;

	private GatePass gatePass1;

	private tbl_GatePassTableAdapter tbl_GatePassTableAdapter;

	private XRLabel lblSex;

	private XRLabel xrLabel1;

	public gatePass_Multiple()
	{
		InitializeComponent();
	}

	private void gatePass_Multiple_BeforePrint(object sender, CancelEventArgs e)
	{
		lblClass.Text = StudentOptions.ActiveClass();
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
		Code39ExtendedGenerator code39ExtendedGenerator = new Code39ExtendedGenerator();
		Detail = new DetailBand();
		xrLabel40 = new XRLabel();
		xrLabel39 = new XRLabel();
		lblMessage = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel10 = new XRLabel();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		PageHeader = new PageHeaderBand();
		xrLabel1 = new XRLabel();
		lblSex = new XRLabel();
		xrBarCode1 = new XRBarCode();
		xrSubreport1 = new XRSubreport();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		xrLabel35 = new XRLabel();
		xrLabel33 = new XRLabel();
		xrLabel31 = new XRLabel();
		xrLabel30 = new XRLabel();
		xrLabel29 = new XRLabel();
		xrLabel28 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		lblClass = new XRLabel();
		xrLabel2 = new XRLabel();
		lblName = new XRLabel();
		xrPageInfo1 = new XRPageInfo();
		xrPageInfo2 = new XRPageInfo();
		xrPageInfo3 = new XRPageInfo();
		xrLabel34 = new XRLabel();
		xrLabel36 = new XRLabel();
		xrLabel37 = new XRLabel();
		PageFooter = new PageFooterBand();
		xrLabel24 = new XRLabel();
		xrLabel23 = new XRLabel();
		xrLabel22 = new XRLabel();
		xrLabel27 = new XRLabel();
		xrLabel26 = new XRLabel();
		xrLabel25 = new XRLabel();
		xrLabel21 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrLabel16 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel20 = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel18 = new XRLabel();
		CapDate = new Parameter();
		gatePass1 = new GatePass();
		tbl_GatePassTableAdapter = new tbl_GatePassTableAdapter();
		((ISupportInitialize)gatePass1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[3] { xrLabel40, xrLabel39, lblMessage });
		Detail.HeightF = 61.45833f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrLabel40.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel40.Borders = BorderSide.Bottom;
		xrLabel40.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.amountInWords", "{0:(###)}")
		});
		xrLabel40.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel40.LocationFloat = new PointFloat(103f, 31f);
		xrLabel40.Name = "xrLabel40";
		xrLabel40.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel40.SizeF = new SizeF(552f, 24.00001f);
		xrLabel40.StylePriority.UseBorderDashStyle = false;
		xrLabel40.StylePriority.UseBorders = false;
		xrLabel40.StylePriority.UseFont = false;
		xrLabel40.StylePriority.UseTextAlignment = false;
		xrLabel40.Text = "xrLabel40";
		xrLabel40.TextAlignment = TextAlignment.BottomCenter;
		xrLabel39.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.amount", "{0:(#,#.0)}")
		});
		xrLabel39.Font = new DXFont("Tahoma", 10f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel39.LocationFloat = new PointFloat(5.999724f, 31f);
		xrLabel39.Name = "xrLabel39";
		xrLabel39.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel39.SizeF = new SizeF(97.00028f, 24f);
		xrLabel39.StylePriority.UseFont = false;
		xrLabel39.StylePriority.UseTextAlignment = false;
		xrLabel39.Text = "xrLabel39";
		xrLabel39.TextAlignment = TextAlignment.BottomLeft;
		lblMessage.Font = new DXFont("Tahoma", 10f);
		lblMessage.LocationFloat = new PointFloat(7.000001f, 8f);
		lblMessage.Name = "lblMessage";
		lblMessage.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblMessage.SizeF = new SizeF(647.8751f, 23f);
		lblMessage.StylePriority.UseFont = false;
		lblMessage.StylePriority.UseTextAlignment = false;
		lblMessage.Text = "Your child has been sent back home to collect school fees balance and any other requirements of:";
		lblMessage.TextAlignment = TextAlignment.BottomLeft;
		xrLabel9.Font = new DXFont("Tahoma", 10f);
		xrLabel9.LocationFloat = new PointFloat(5.583318f, 229f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(85.41666f, 23f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "Dear Mr/Ms.";
		xrLabel9.TextAlignment = TextAlignment.BottomLeft;
		xrLabel13.Font = new DXFont("Tahoma", 10f);
		xrLabel13.LocationFloat = new PointFloat(331f, 0f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(100f, 23f);
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Approved by:";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		xrLabel8.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel8.Borders = BorderSide.Bottom;
		xrLabel8.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.CreatedBy")
		});
		xrLabel8.Font = new DXFont("Tahoma", 10f);
		xrLabel8.LocationFloat = new PointFloat(93f, 0f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(238f, 23f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "xrLabel8";
		xrLabel8.TextAlignment = TextAlignment.BottomCenter;
		xrLabel12.Font = new DXFont("Tahoma", 10f);
		xrLabel12.LocationFloat = new PointFloat(7.000001f, 0f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(86.00001f, 23f);
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Created by:";
		xrLabel12.TextAlignment = TextAlignment.BottomLeft;
		xrLabel14.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel14.Borders = BorderSide.Bottom;
		xrLabel14.Font = new DXFont("Tahoma", 10f);
		xrLabel14.LocationFloat = new PointFloat(431f, 0f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(225f, 23f);
		xrLabel14.StylePriority.UseBorderDashStyle = false;
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.TextAlignment = TextAlignment.BottomLeft;
		xrLabel10.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel10.Borders = BorderSide.Bottom;
		xrLabel10.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.Guardian", "{0:(###)}")
		});
		xrLabel10.Font = new DXFont("Tahoma", 10f);
		xrLabel10.LocationFloat = new PointFloat(90.99998f, 229f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(562.5834f, 23.00002f);
		xrLabel10.StylePriority.UseBorderDashStyle = false;
		xrLabel10.StylePriority.UseBorders = false;
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.Text = "xrLabel10";
		xrLabel10.TextAlignment = TextAlignment.BottomCenter;
		TopMargin.HeightF = 20f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		BottomMargin.HeightF = 20f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		PageHeader.Controls.AddRange(new XRControl[20]
		{
			xrLabel1, lblSex, xrBarCode1, xrSubreport1, xrLine2, xrLine1, xrLabel35, xrLabel33, xrLabel31, xrLabel30,
			xrLabel29, xrLabel28, xrPictureBox1, xrLabel6, xrLabel5, lblClass, xrLabel2, lblName, xrLabel10, xrLabel9
		});
		PageHeader.HeightF = 257.4166f;
		PageHeader.Name = "PageHeader";
		PageHeader.StylePriority.UseForeColor = false;
		xrLabel1.Font = new DXFont("Tahoma", 9.75f);
		xrLabel1.LocationFloat = new PointFloat(560f, 137.4165f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(34f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Sex:";
		xrLabel1.TextAlignment = TextAlignment.BottomLeft;
		lblSex.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.Sex")
		});
		lblSex.Font = new DXFont("Tahoma", 9.75f);
		lblSex.LocationFloat = new PointFloat(594f, 137.4165f);
		lblSex.Name = "lblSex";
		lblSex.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSex.SizeF = new SizeF(66f, 23.00002f);
		lblSex.StylePriority.UseFont = false;
		lblSex.StylePriority.UseTextAlignment = false;
		lblSex.Text = "lblSex";
		lblSex.TextAlignment = TextAlignment.MiddleCenter;
		xrBarCode1.AutoModule = true;
		xrBarCode1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.StudentNumber")
		});
		xrBarCode1.Font = new DXFont("Microsoft Sans Serif", 6f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrBarCode1.LocationFloat = new PointFloat(504f, 170f);
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode1.ShowText = false;
		xrBarCode1.SizeF = new SizeF(152f, 32f);
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UsePadding = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		code39ExtendedGenerator.WideNarrowRatio = 3f;
		xrBarCode1.Symbology = code39ExtendedGenerator;
		xrBarCode1.Text = "xrBarCode1";
		xrBarCode1.TextAlignment = TextAlignment.MiddleCenter;
		xrSubreport1.LocationFloat = new PointFloat(6.999715f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.ReportSource = new reportHeaderGP();
		xrSubreport1.SizeF = new SizeF(648f, 96f);
		xrLine2.Borders = BorderSide.All;
		xrLine2.BorderWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(5.999851f, 211.7915f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(650f, 2.083328f);
		xrLine2.StylePriority.UseBorders = false;
		xrLine2.StylePriority.UseBorderWidth = false;
		xrLine1.LocationFloat = new PointFloat(5.999851f, 207.4165f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(650f, 2.083328f);
		xrLabel35.BackColor = Color.FromArgb(128, 64, 64);
		xrLabel35.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.PassType")
		});
		xrLabel35.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrLabel35.ForeColor = Color.White;
		xrLabel35.LocationFloat = new PointFloat(5.999851f, 106.6666f);
		xrLabel35.Name = "xrLabel35";
		xrLabel35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel35.SizeF = new SizeF(651.0001f, 22.99999f);
		xrLabel35.StylePriority.UseBackColor = false;
		xrLabel35.StylePriority.UseFont = false;
		xrLabel35.StylePriority.UseForeColor = false;
		xrLabel35.StylePriority.UseTextAlignment = false;
		xrLabel35.Text = "xrLabel35";
		xrLabel35.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel33.Font = new DXFont("Tahoma", 10f);
		xrLabel33.LocationFloat = new PointFloat(385.9998f, 175.4166f);
		xrLabel33.Name = "xrLabel33";
		xrLabel33.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel33.SizeF = new SizeF(33.54163f, 23.99998f);
		xrLabel33.StylePriority.UseFont = false;
		xrLabel33.StylePriority.UseTextAlignment = false;
		xrLabel33.Text = "D/B:";
		xrLabel33.TextAlignment = TextAlignment.BottomLeft;
		xrLabel31.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel31.LocationFloat = new PointFloat(217.9999f, 175.4166f);
		xrLabel31.Name = "xrLabel31";
		xrLabel31.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel31.SizeF = new SizeF(67.99997f, 24.00002f);
		xrLabel31.StylePriority.UseFont = false;
		xrLabel31.StylePriority.UseTextAlignment = false;
		xrLabel31.Text = "Stream:";
		xrLabel31.TextAlignment = TextAlignment.BottomLeft;
		xrLabel30.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel30.LocationFloat = new PointFloat(343.9999f, 137.4165f);
		xrLabel30.Name = "xrLabel30";
		xrLabel30.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel30.SizeF = new SizeF(72f, 23.99998f);
		xrLabel30.StylePriority.UseFont = false;
		xrLabel30.StylePriority.UseTextAlignment = false;
		xrLabel30.Text = "Stud No.";
		xrLabel30.TextAlignment = TextAlignment.BottomLeft;
		xrLabel29.Font = new DXFont("Tahoma", 10f);
		xrLabel29.LocationFloat = new PointFloat(83.99986f, 175.4166f);
		xrLabel29.Name = "xrLabel29";
		xrLabel29.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel29.SizeF = new SizeF(43.99998f, 24.00002f);
		xrLabel29.StylePriority.UseFont = false;
		xrLabel29.StylePriority.UseTextAlignment = false;
		xrLabel29.Text = "Class:";
		xrLabel29.TextAlignment = TextAlignment.BottomLeft;
		xrLabel28.Font = new DXFont("Tahoma", 10f);
		xrLabel28.LocationFloat = new PointFloat(83.99986f, 137.4165f);
		xrLabel28.Name = "xrLabel28";
		xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel28.SizeF = new SizeF(47.99998f, 23.99998f);
		xrLabel28.StylePriority.UseFont = false;
		xrLabel28.StylePriority.UseTextAlignment = false;
		xrLabel28.Text = "Name:";
		xrLabel28.TextAlignment = TextAlignment.BottomLeft;
		xrPictureBox1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Image", null, "tbl_GatePass.pic")
		});
		xrPictureBox1.LocationFloat = new PointFloat(7.999865f, 137.4165f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(64.99996f, 62.00003f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrLabel6.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel6.Borders = BorderSide.Bottom;
		xrLabel6.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.DB")
		});
		xrLabel6.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.LocationFloat = new PointFloat(423.9998f, 175.4166f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(53.99997f, 23.00003f);
		xrLabel6.StylePriority.UseBorderDashStyle = false;
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "xrLabel6";
		xrLabel6.TextAlignment = TextAlignment.BottomCenter;
		xrLabel5.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel5.Borders = BorderSide.Bottom;
		xrLabel5.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.Stream")
		});
		xrLabel5.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel5.LocationFloat = new PointFloat(285.9998f, 175.4166f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(100f, 23f);
		xrLabel5.StylePriority.UseBorderDashStyle = false;
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "xrLabel5";
		xrLabel5.TextAlignment = TextAlignment.BottomCenter;
		lblClass.BorderDashStyle = BorderDashStyle.Dash;
		lblClass.Borders = BorderSide.Bottom;
		lblClass.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblClass.LocationFloat = new PointFloat(127.9998f, 175.4166f);
		lblClass.Name = "lblClass";
		lblClass.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblClass.SizeF = new SizeF(88.41667f, 23.00002f);
		lblClass.StylePriority.UseBorderDashStyle = false;
		lblClass.StylePriority.UseBorders = false;
		lblClass.StylePriority.UseFont = false;
		lblClass.StylePriority.UseTextAlignment = false;
		lblClass.Text = "lblClass";
		lblClass.TextAlignment = TextAlignment.BottomCenter;
		xrLabel2.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel2.Borders = BorderSide.Bottom;
		xrLabel2.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.StudentNumber")
		});
		xrLabel2.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel2.LocationFloat = new PointFloat(415.9999f, 137.4165f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(143.4168f, 23f);
		xrLabel2.StylePriority.UseBorderDashStyle = false;
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.BottomCenter;
		lblName.BorderDashStyle = BorderDashStyle.Dash;
		lblName.Borders = BorderSide.Bottom;
		lblName.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.Name")
		});
		lblName.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblName.LocationFloat = new PointFloat(131.9999f, 137.4165f);
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblName.SizeF = new SizeF(210f, 23.00002f);
		lblName.StylePriority.UseBorderDashStyle = false;
		lblName.StylePriority.UseBorders = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "lblName";
		lblName.TextAlignment = TextAlignment.BottomCenter;
		xrPageInfo1.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo1.LocationFloat = new PointFloat(69.99966f, 135.75f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.PageInfo = PageInfo.DateTime;
		xrPageInfo1.SizeF = new SizeF(116.1667f, 23f);
		xrPageInfo1.StylePriority.UseFont = false;
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.BottomLeft;
		xrPageInfo1.TextFormatString = "{0:dd-MMM-yy}";
		xrPageInfo2.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo2.LocationFloat = new PointFloat(310.9998f, 135.75f);
		xrPageInfo2.Name = "xrPageInfo2";
		xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo2.PageInfo = PageInfo.DateTime;
		xrPageInfo2.SizeF = new SizeF(102f, 23f);
		xrPageInfo2.StylePriority.UseFont = false;
		xrPageInfo2.StylePriority.UseTextAlignment = false;
		xrPageInfo2.TextAlignment = TextAlignment.BottomLeft;
		xrPageInfo2.TextFormatString = "{0:hh:mm:ss tt}";
		xrPageInfo3.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo3.LocationFloat = new PointFloat(514.9997f, 135.75f);
		xrPageInfo3.Name = "xrPageInfo3";
		xrPageInfo3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo3.PageInfo = PageInfo.UserName;
		xrPageInfo3.SizeF = new SizeF(140.8754f, 23f);
		xrPageInfo3.StylePriority.UseFont = false;
		xrPageInfo3.StylePriority.UseTextAlignment = false;
		xrPageInfo3.TextAlignment = TextAlignment.MiddleRight;
		xrLabel34.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel34.LocationFloat = new PointFloat(6.999715f, 135.75f);
		xrLabel34.Name = "xrLabel34";
		xrLabel34.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel34.SizeF = new SizeF(62.99995f, 23f);
		xrLabel34.StylePriority.UseFont = false;
		xrLabel34.StylePriority.UseTextAlignment = false;
		xrLabel34.Text = "PrintDate:";
		xrLabel34.TextAlignment = TextAlignment.BottomLeft;
		xrLabel36.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel36.LocationFloat = new PointFloat(239.1248f, 135.75f);
		xrLabel36.Name = "xrLabel36";
		xrLabel36.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel36.SizeF = new SizeF(71.87497f, 23f);
		xrLabel36.StylePriority.UseFont = false;
		xrLabel36.StylePriority.UseTextAlignment = false;
		xrLabel36.Text = "PrintTime:";
		xrLabel36.TextAlignment = TextAlignment.BottomLeft;
		xrLabel37.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel37.LocationFloat = new PointFloat(454.9997f, 135.75f);
		xrLabel37.Name = "xrLabel37";
		xrLabel37.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel37.SizeF = new SizeF(60f, 23f);
		xrLabel37.StylePriority.UseFont = false;
		xrLabel37.StylePriority.UseTextAlignment = false;
		xrLabel37.Text = "Source:";
		xrLabel37.TextAlignment = TextAlignment.BottomLeft;
		PageFooter.Controls.AddRange(new XRControl[23]
		{
			xrLabel24, xrLabel23, xrLabel22, xrLabel27, xrLabel26, xrLabel25, xrLabel21, xrLabel17, xrLabel16, xrLabel15,
			xrLabel20, xrLabel19, xrLabel18, xrPageInfo3, xrPageInfo2, xrPageInfo1, xrLabel34, xrLabel36, xrLabel37, xrLabel8,
			xrLabel12, xrLabel13, xrLabel14
		});
		PageFooter.HeightF = 168.75f;
		PageFooter.Name = "PageFooter";
		xrLabel24.Font = new DXFont("Tahoma", 10f);
		xrLabel24.LocationFloat = new PointFloat(478.9996f, 63.75005f);
		xrLabel24.Name = "xrLabel24";
		xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel24.SizeF = new SizeF(81.25003f, 23f);
		xrLabel24.StylePriority.UseFont = false;
		xrLabel24.StylePriority.UseTextAlignment = false;
		xrLabel24.Text = "Arrival time:";
		xrLabel24.TextAlignment = TextAlignment.BottomLeft;
		xrLabel23.Font = new DXFont("Tahoma", 10f);
		xrLabel23.LocationFloat = new PointFloat(224.9997f, 95.75005f);
		xrLabel23.Name = "xrLabel23";
		xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel23.SizeF = new SizeF(106.6667f, 23f);
		xrLabel23.StylePriority.UseFont = false;
		xrLabel23.StylePriority.UseTextAlignment = false;
		xrLabel23.Text = "Departure time:";
		xrLabel23.TextAlignment = TextAlignment.BottomLeft;
		xrLabel22.Font = new DXFont("Tahoma", 10f);
		xrLabel22.LocationFloat = new PointFloat(312.9997f, 63.75005f);
		xrLabel22.Name = "xrLabel22";
		xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel22.SizeF = new SizeF(86.00003f, 23.00003f);
		xrLabel22.StylePriority.UseFont = false;
		xrLabel22.StylePriority.UseTextAlignment = false;
		xrLabel22.Text = "Arrival date:";
		xrLabel22.TextAlignment = TextAlignment.BottomLeft;
		xrLabel27.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel27.Borders = BorderSide.Bottom;
		xrLabel27.Font = new DXFont("Tahoma", 10f);
		xrLabel27.LocationFloat = new PointFloat(560.2497f, 63.75005f);
		xrLabel27.Name = "xrLabel27";
		xrLabel27.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel27.SizeF = new SizeF(96.75031f, 22.99998f);
		xrLabel27.StylePriority.UseBorderDashStyle = false;
		xrLabel27.StylePriority.UseBorders = false;
		xrLabel27.StylePriority.UseFont = false;
		xrLabel27.StylePriority.UseTextAlignment = false;
		xrLabel27.TextAlignment = TextAlignment.BottomLeft;
		xrLabel26.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel26.Borders = BorderSide.Bottom;
		xrLabel26.Font = new DXFont("Tahoma", 10f);
		xrLabel26.LocationFloat = new PointFloat(331.6664f, 95.75005f);
		xrLabel26.Name = "xrLabel26";
		xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel26.SizeF = new SizeF(99.33331f, 23f);
		xrLabel26.StylePriority.UseBorderDashStyle = false;
		xrLabel26.StylePriority.UseBorders = false;
		xrLabel26.StylePriority.UseFont = false;
		xrLabel26.StylePriority.UseTextAlignment = false;
		xrLabel26.TextAlignment = TextAlignment.BottomLeft;
		xrLabel25.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel25.Borders = BorderSide.Bottom;
		xrLabel25.Font = new DXFont("Tahoma", 10f);
		xrLabel25.LocationFloat = new PointFloat(398.9997f, 63.75005f);
		xrLabel25.Name = "xrLabel25";
		xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel25.SizeF = new SizeF(79.54169f, 23f);
		xrLabel25.StylePriority.UseBorderDashStyle = false;
		xrLabel25.StylePriority.UseBorders = false;
		xrLabel25.StylePriority.UseFont = false;
		xrLabel25.StylePriority.UseTextAlignment = false;
		xrLabel25.TextAlignment = TextAlignment.BottomLeft;
		xrLabel21.Font = new DXFont("Tahoma", 10f);
		xrLabel21.LocationFloat = new PointFloat(430.9997f, 95.75005f);
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(71.00003f, 23.00003f);
		xrLabel21.StylePriority.UseFont = false;
		xrLabel21.StylePriority.UseTextAlignment = false;
		xrLabel21.Text = "Signature:";
		xrLabel21.TextAlignment = TextAlignment.BottomLeft;
		xrLabel17.Font = new DXFont("Tahoma", 10f);
		xrLabel17.LocationFloat = new PointFloat(6.999715f, 95.75005f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(102f, 24f);
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "Departure date:";
		xrLabel17.TextAlignment = TextAlignment.BottomLeft;
		xrLabel16.Font = new DXFont("Tahoma", 10f);
		xrLabel16.LocationFloat = new PointFloat(6.999715f, 63.75005f);
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(83.42f, 23f);
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.StylePriority.UseTextAlignment = false;
		xrLabel16.Text = "Destination:";
		xrLabel16.TextAlignment = TextAlignment.BottomLeft;
		xrLabel15.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold);
		xrLabel15.ForeColor = Color.FromArgb(128, 64, 64);
		xrLabel15.LocationFloat = new PointFloat(6.999715f, 35f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(650.0003f, 24.00001f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseForeColor = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Parent Acknowledgement";
		xrLabel15.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel20.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel20.Borders = BorderSide.Bottom;
		xrLabel20.Font = new DXFont("Tahoma", 10f);
		xrLabel20.LocationFloat = new PointFloat(108.9997f, 95.75005f);
		xrLabel20.Name = "xrLabel20";
		xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel20.SizeF = new SizeF(116f, 23f);
		xrLabel20.StylePriority.UseBorderDashStyle = false;
		xrLabel20.StylePriority.UseBorders = false;
		xrLabel20.StylePriority.UseFont = false;
		xrLabel20.StylePriority.UseTextAlignment = false;
		xrLabel20.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel19.Borders = BorderSide.Bottom;
		xrLabel19.Font = new DXFont("Tahoma", 10f);
		xrLabel19.LocationFloat = new PointFloat(90.41971f, 63.75005f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(222.58f, 23f);
		xrLabel19.StylePriority.UseBorderDashStyle = false;
		xrLabel19.StylePriority.UseBorders = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel18.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel18.Borders = BorderSide.Bottom;
		xrLabel18.Font = new DXFont("Tahoma", 10f);
		xrLabel18.LocationFloat = new PointFloat(501.9997f, 95.75005f);
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(155.0003f, 23f);
		xrLabel18.StylePriority.UseBorderDashStyle = false;
		xrLabel18.StylePriority.UseBorders = false;
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.TextAlignment = TextAlignment.BottomLeft;
		CapDate.Description = "Created Date";
		CapDate.Name = "CapDate";
		gatePass1.DataSetName = "GatePass";
		gatePass1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tbl_GatePassTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[5] { Detail, TopMargin, BottomMargin, PageHeader, PageFooter });
		base.DataAdapter = tbl_GatePassTableAdapter;
		base.DataMember = "tbl_GatePass";
		base.DataSource = gatePass1;
		FilterString = "[CaptureDate] = ?CapDate";
		base.Margins = new DXMargins(20f, 20f, 20f, 20f);
		base.PageHeight = 540;
		base.PageWidth = 700;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[1] { CapDate });
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "17.2";
		BeforePrint += gatePass_Multiple_BeforePrint;
		((ISupportInitialize)gatePass1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
