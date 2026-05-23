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

public class gatePass_General : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRLabel xrLabel14;

	private XRLabel xrLabel13;

	private XRLabel xrLabel12;

	private XRLabel xrLabel11;

	private XRLabel xrLabel8;

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

	private XRSubreport xrSubreport1;

	private PageFooterBand PageFooter;

	public Parameter PassNos3;

	private XRLabel xrLabel20;

	private XRLabel xrLabel19;

	private XRLabel xrLabel18;

	private XRLabel xrLabel17;

	private XRLabel xrLabel16;

	private XRLabel xrLabel15;

	private XRPageInfo xrPageInfo4;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRBarCode xrBarCode1;

	private GatePass gatePass1;

	private tbl_GatePassTableAdapter tbl_GatePassTableAdapter;

	private XRLabel lblSex;

	private XRLabel xrLabel1;

	public gatePass_General()
	{
		InitializeComponent();
	}

	private void lblClass_BeforePrint(object sender, CancelEventArgs e)
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
		xrLabel20 = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel18 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrLabel16 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrPageInfo4 = new XRPageInfo();
		xrLabel10 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel8 = new XRLabel();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		PageHeader = new PageHeaderBand();
		lblSex = new XRLabel();
		xrBarCode1 = new XRBarCode();
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
		PassNos3 = new Parameter();
		gatePass1 = new GatePass();
		tbl_GatePassTableAdapter = new tbl_GatePassTableAdapter();
		xrSubreport1 = new XRSubreport();
		xrLabel1 = new XRLabel();
		((ISupportInitialize)gatePass1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[14]
		{
			xrLabel20, xrLabel19, xrLabel18, xrLabel17, xrLabel16, xrLabel15, xrPageInfo4, xrLabel10, xrLabel9, xrLabel14,
			xrLabel13, xrLabel12, xrLabel11, xrLabel8
		});
		Detail.HeightF = 217.7083f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrLabel20.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel20.Borders = BorderSide.Bottom;
		xrLabel20.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.Destination")
		});
		xrLabel20.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel20.LocationFloat = new PointFloat(81.08333f, 68f);
		xrLabel20.Name = "xrLabel20";
		xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel20.SizeF = new SizeF(575.9167f, 23f);
		xrLabel20.StylePriority.UseBorderDashStyle = false;
		xrLabel20.StylePriority.UseBorders = false;
		xrLabel20.StylePriority.UseFont = false;
		xrLabel20.StylePriority.UseTextAlignment = false;
		xrLabel20.Text = "xrLabel20";
		xrLabel20.TextAlignment = TextAlignment.BottomCenter;
		xrLabel19.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel19.LocationFloat = new PointFloat(3.999996f, 68f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(77.08333f, 23f);
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Destination";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel18.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel18.Borders = BorderSide.Bottom;
		xrLabel18.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.ReturnDate", "{0:dd-MMM-yy}")
		});
		xrLabel18.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel18.LocationFloat = new PointFloat(36f, 30.00002f);
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(93.99997f, 24.00001f);
		xrLabel18.StylePriority.UseBorderDashStyle = false;
		xrLabel18.StylePriority.UseBorders = false;
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.Text = "xrLabel18";
		xrLabel18.TextAlignment = TextAlignment.BottomCenter;
		xrLabel17.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel17.LocationFloat = new PointFloat(3.999996f, 30.00002f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(32f, 24.00001f);
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "on";
		xrLabel17.TextAlignment = TextAlignment.BottomLeft;
		xrLabel16.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel16.Borders = BorderSide.Bottom;
		xrLabel16.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.ReturnTime", "{0:hh:mm tt}")
		});
		xrLabel16.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel16.LocationFloat = new PointFloat(580.9167f, 5.999979f);
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(76.08337f, 24.00001f);
		xrLabel16.StylePriority.UseBorderDashStyle = false;
		xrLabel16.StylePriority.UseBorders = false;
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.StylePriority.UseTextAlignment = false;
		xrLabel16.Text = "xrLabel16";
		xrLabel16.TextAlignment = TextAlignment.BottomCenter;
		xrLabel15.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel15.LocationFloat = new PointFloat(558f, 6.00001f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(22.91669f, 24f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "to";
		xrLabel15.TextAlignment = TextAlignment.BottomLeft;
		xrPageInfo4.BorderDashStyle = BorderDashStyle.Dash;
		xrPageInfo4.Borders = BorderSide.Bottom;
		xrPageInfo4.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo4.Format = "{0:hh:mm tt}";
		xrPageInfo4.LocationFloat = new PointFloat(447.5833f, 6.00001f);
		xrPageInfo4.Name = "xrPageInfo4";
		xrPageInfo4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo4.PageInfo = PageInfo.DateTime;
		xrPageInfo4.SizeF = new SizeF(110.4167f, 24f);
		xrPageInfo4.StylePriority.UseBorderDashStyle = false;
		xrPageInfo4.StylePriority.UseBorders = false;
		xrPageInfo4.StylePriority.UseFont = false;
		xrPageInfo4.StylePriority.UseTextAlignment = false;
		xrPageInfo4.TextAlignment = TextAlignment.BottomCenter;
		xrLabel10.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel10.LocationFloat = new PointFloat(3.999996f, 6.00001f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(443.5833f, 24.00001f);
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.Text = "The Student indicated above has been allowed to go out of campus from";
		xrLabel10.TextAlignment = TextAlignment.BottomLeft;
		xrLabel9.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel9.LocationFloat = new PointFloat(3.999869f, 104.0417f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(652.0001f, 23.75002f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "He/ She shall be responsible for his/her conduct and events that take place outside of campus.";
		xrLabel9.TextAlignment = TextAlignment.BottomLeft;
		xrLabel14.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel14.Borders = BorderSide.Bottom;
		xrLabel14.Font = new DXFont("Tahoma", 10f);
		xrLabel14.LocationFloat = new PointFloat(414f, 166.0417f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(242f, 23f);
		xrLabel14.StylePriority.UseBorderDashStyle = false;
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.TextAlignment = TextAlignment.BottomLeft;
		xrLabel13.Font = new DXFont("Tahoma", 10f);
		xrLabel13.LocationFloat = new PointFloat(327.4165f, 166.0417f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(86.58347f, 23f);
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Approved by:";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		xrLabel12.Font = new DXFont("Tahoma", 10f);
		xrLabel12.LocationFloat = new PointFloat(3.999869f, 166.0417f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(85.41665f, 23f);
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Created by:";
		xrLabel12.TextAlignment = TextAlignment.BottomLeft;
		xrLabel11.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel11.LocationFloat = new PointFloat(130f, 29.99999f);
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(527.0001f, 24.00001f);
		xrLabel11.StylePriority.UseFont = false;
		xrLabel11.StylePriority.UseTextAlignment = false;
		xrLabel11.Text = "to market / local guardian/ doctor/travelling/ place of worship";
		xrLabel11.TextAlignment = TextAlignment.BottomLeft;
		xrLabel8.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel8.Borders = BorderSide.Bottom;
		xrLabel8.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.CreatedBy")
		});
		xrLabel8.Font = new DXFont("Tahoma", 10f);
		xrLabel8.LocationFloat = new PointFloat(89.41653f, 166.0417f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(238f, 23f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "xrLabel8";
		xrLabel8.TextAlignment = TextAlignment.BottomCenter;
		TopMargin.HeightF = 20f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		BottomMargin.HeightF = 20f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		PageHeader.Controls.AddRange(new XRControl[18]
		{
			xrLabel1, lblSex, xrBarCode1, xrSubreport1, xrLine2, xrLine1, xrLabel35, xrLabel33, xrLabel31, xrLabel30,
			xrLabel29, xrLabel28, xrPictureBox1, xrLabel6, xrLabel5, lblClass, xrLabel2, lblName
		});
		PageHeader.HeightF = 223.9583f;
		PageHeader.Name = "PageHeader";
		PageHeader.StylePriority.UseForeColor = false;
		lblSex.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.Sex")
		});
		lblSex.Font = new DXFont("Tahoma", 9.75f);
		lblSex.LocationFloat = new PointFloat(591.4168f, 140f);
		lblSex.Name = "lblSex";
		lblSex.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSex.SizeF = new SizeF(66.58319f, 23f);
		lblSex.StylePriority.UseFont = false;
		lblSex.StylePriority.UseTextAlignment = false;
		lblSex.Text = "lblSex";
		lblSex.TextAlignment = TextAlignment.MiddleCenter;
		xrBarCode1.AutoModule = true;
		xrBarCode1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.StudentNumber")
		});
		xrBarCode1.Font = new DXFont("Arial Unicode MS", 6f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrBarCode1.LocationFloat = new PointFloat(503.0001f, 170f);
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
		xrLine2.Borders = BorderSide.All;
		xrLine2.BorderWidth = 2f;
		xrLine2.LocationFloat = new PointFloat(4f, 214.375f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(650f, 2.083328f);
		xrLine2.StylePriority.UseBorders = false;
		xrLine2.StylePriority.UseBorderWidth = false;
		xrLine1.LocationFloat = new PointFloat(4f, 210f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(650f, 2.083328f);
		xrLabel35.BackColor = Color.FromArgb(128, 64, 64);
		xrLabel35.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "tbl_GatePass.PassType")
		});
		xrLabel35.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrLabel35.ForeColor = Color.White;
		xrLabel35.LocationFloat = new PointFloat(4f, 109.25f);
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
		xrLabel33.LocationFloat = new PointFloat(384f, 178f);
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
		xrLabel31.LocationFloat = new PointFloat(216f, 178f);
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
		xrLabel30.LocationFloat = new PointFloat(342f, 140f);
		xrLabel30.Name = "xrLabel30";
		xrLabel30.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel30.SizeF = new SizeF(72f, 23.99998f);
		xrLabel30.StylePriority.UseFont = false;
		xrLabel30.StylePriority.UseTextAlignment = false;
		xrLabel30.Text = "Stud No.";
		xrLabel30.TextAlignment = TextAlignment.BottomLeft;
		xrLabel29.Font = new DXFont("Tahoma", 10f);
		xrLabel29.LocationFloat = new PointFloat(82f, 178f);
		xrLabel29.Name = "xrLabel29";
		xrLabel29.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel29.SizeF = new SizeF(43.99998f, 24.00002f);
		xrLabel29.StylePriority.UseFont = false;
		xrLabel29.StylePriority.UseTextAlignment = false;
		xrLabel29.Text = "Class:";
		xrLabel29.TextAlignment = TextAlignment.BottomLeft;
		xrLabel28.Font = new DXFont("Tahoma", 10f);
		xrLabel28.LocationFloat = new PointFloat(82f, 140f);
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
		xrPictureBox1.LocationFloat = new PointFloat(6f, 140f);
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
		xrLabel6.LocationFloat = new PointFloat(422f, 178f);
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
		xrLabel5.LocationFloat = new PointFloat(284f, 178f);
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
		lblClass.LocationFloat = new PointFloat(126f, 178f);
		lblClass.Name = "lblClass";
		lblClass.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblClass.SizeF = new SizeF(88.41667f, 23.00002f);
		lblClass.StylePriority.UseBorderDashStyle = false;
		lblClass.StylePriority.UseBorders = false;
		lblClass.StylePriority.UseFont = false;
		lblClass.StylePriority.UseTextAlignment = false;
		lblClass.Text = "lblClass";
		lblClass.TextAlignment = TextAlignment.BottomCenter;
		lblClass.BeforePrint += lblClass_BeforePrint;
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
		xrLabel2.LocationFloat = new PointFloat(414f, 140f);
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
		lblName.LocationFloat = new PointFloat(130f, 140f);
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
		xrPageInfo1.Format = "{0:dd-MMM-yy}";
		xrPageInfo1.LocationFloat = new PointFloat(70.99991f, 2.000014f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.PageInfo = PageInfo.DateTime;
		xrPageInfo1.SizeF = new SizeF(116.1667f, 23f);
		xrPageInfo1.StylePriority.UseFont = false;
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.BottomLeft;
		xrPageInfo2.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo2.Format = "{0:hh:mm:ss tt}";
		xrPageInfo2.LocationFloat = new PointFloat(312f, 2.000014f);
		xrPageInfo2.Name = "xrPageInfo2";
		xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo2.PageInfo = PageInfo.DateTime;
		xrPageInfo2.SizeF = new SizeF(102f, 23f);
		xrPageInfo2.StylePriority.UseFont = false;
		xrPageInfo2.StylePriority.UseTextAlignment = false;
		xrPageInfo2.TextAlignment = TextAlignment.BottomLeft;
		xrPageInfo3.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo3.LocationFloat = new PointFloat(516f, 2.000014f);
		xrPageInfo3.Name = "xrPageInfo3";
		xrPageInfo3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo3.PageInfo = PageInfo.UserName;
		xrPageInfo3.SizeF = new SizeF(139.0001f, 23f);
		xrPageInfo3.StylePriority.UseFont = false;
		xrPageInfo3.StylePriority.UseTextAlignment = false;
		xrPageInfo3.TextAlignment = TextAlignment.MiddleRight;
		xrLabel34.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel34.LocationFloat = new PointFloat(7.99996f, 2.000014f);
		xrLabel34.Name = "xrLabel34";
		xrLabel34.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel34.SizeF = new SizeF(62.99995f, 23f);
		xrLabel34.StylePriority.UseFont = false;
		xrLabel34.StylePriority.UseTextAlignment = false;
		xrLabel34.Text = "Print date:";
		xrLabel34.TextAlignment = TextAlignment.BottomLeft;
		xrLabel36.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel36.LocationFloat = new PointFloat(240.125f, 2.000014f);
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
		xrLabel37.LocationFloat = new PointFloat(455.9999f, 2.000014f);
		xrLabel37.Name = "xrLabel37";
		xrLabel37.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel37.SizeF = new SizeF(60f, 23f);
		xrLabel37.StylePriority.UseFont = false;
		xrLabel37.StylePriority.UseTextAlignment = false;
		xrLabel37.Text = "Source:";
		xrLabel37.TextAlignment = TextAlignment.BottomLeft;
		PageFooter.Controls.AddRange(new XRControl[6] { xrPageInfo3, xrPageInfo2, xrPageInfo1, xrLabel34, xrLabel36, xrLabel37 });
		PageFooter.HeightF = 29.16667f;
		PageFooter.Name = "PageFooter";
		PassNos3.Description = "PassNumber";
		PassNos3.Name = "PassNos3";
		PassNos3.Type = typeof(int);
		PassNos3.ValueInfo = "0";
		gatePass1.DataSetName = "GatePass";
		gatePass1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tbl_GatePassTableAdapter.ClearBeforeFill = true;
		xrSubreport1.Id = 0;
		xrSubreport1.LocationFloat = new PointFloat(6.00001f, 3.999996f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.ReportSource = new reportHeaderGP();
		xrSubreport1.SizeF = new SizeF(647.9999f, 96f);
		xrLabel1.Font = new DXFont("Tahoma", 9.75f);
		xrLabel1.LocationFloat = new PointFloat(557.4168f, 140f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(34f, 24f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Sex:";
		xrLabel1.TextAlignment = TextAlignment.BottomLeft;
		base.Bands.AddRange(new Band[5] { Detail, TopMargin, BottomMargin, PageHeader, PageFooter });
		base.DataAdapter = tbl_GatePassTableAdapter;
		base.DataMember = "tbl_GatePass";
		base.DataSource = gatePass1;
		FilterString = "[passNo] = ?PassNos3";
		base.Margins = new DXMargins(20f, 20f, 20f, 20f);
		base.PageHeight = 540;
		base.PageWidth = 700;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[1] { PassNos3 });
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 2f;
		base.Version = "13.1";
		((ISupportInitialize)gatePass1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
