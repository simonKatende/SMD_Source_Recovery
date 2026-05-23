using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace I_Xtreme.StudentIDs;

public class ID_Fullpage : XtraReport
{
	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRControlStyle xrControlStyle1;

	private XRPanel xrPanel1;

	private XRLabel lblHeader;

	private XRPictureBox picSignatory;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel6;

	private XRLabel xrLabel7;

	private XRLabel xrLabel5;

	private XRLabel lblName;

	private XRLabel xrLabel13;

	private XRLabel xrLabel15;

	private XRLabel xrLabel14;

	private XRLabel lblIssueDate;

	private XRLabel lblExpiryDate;

	private XRLabel xrLabel12;

	private XRBarCode xrBarCode1;

	private XRPictureBox xrPictureBox1;

	private XRPanel pnlColors;

	private XRLine xrLine3;

	private XRLine xrLine1;

	private XRLine xrLine2;

	public DetailBand Detail1;

	public ID_Fullpage()
	{
		InitializeComponent();
	}

	private void ID_Fullpage_BeforePrint(object sender, CancelEventArgs e)
	{
		lblHeader.BackColor = Color.FromArgb(IDCustomization.HBColor);
		lblHeader.ForeColor = Color.FromArgb(IDCustomization.HFColor);
		xrLine1.ForeColor = Color.FromArgb(IDCustomization.FCol1);
		xrLine2.ForeColor = Color.FromArgb(IDCustomization.FCol2);
		xrLine3.ForeColor = Color.FromArgb(IDCustomization.FCol3);
		lblHeader.Font = new Font(IDCustomization.HFont, (float)IDCustomization.FontSize);
		picSignatory.Image = IDCustomization.Signatory;
		lblIssueDate.Text = IDCustomization.IssueDate.ToString("MMM-yy");
		lblExpiryDate.Text = IDCustomization.ExpiryDate.ToString("MMM-yy");
	}

	private void ID_Fullpage_AfterPrint(object sender, EventArgs e)
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ID_Fullpage));
		Code39ExtendedGenerator code39ExtendedGenerator = new Code39ExtendedGenerator();
		Detail1 = new DetailBand();
		xrPanel1 = new XRPanel();
		lblName = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel3 = new XRLabel();
		lblExpiryDate = new XRLabel();
		lblHeader = new XRLabel();
		picSignatory = new XRPictureBox();
		xrLabel5 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel15 = new XRLabel();
		lblIssueDate = new XRLabel();
		xrLabel12 = new XRLabel();
		xrBarCode1 = new XRBarCode();
		xrPictureBox1 = new XRPictureBox();
		xrLine3 = new XRLine();
		pnlColors = new XRPanel();
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		xrControlStyle1 = new XRControlStyle();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[3] { xrPanel1, xrLine3, pnlColors });
		Detail1.HeightF = 216f;
		Detail1.MultiColumn.ColumnSpacing = 100f;
		Detail1.MultiColumn.ColumnWidth = 339f;
		Detail1.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail1.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail1.Name = "Detail1";
		Detail1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.PageBreak = PageBreak.AfterBand;
		Detail1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.TextAlignment = TextAlignment.TopLeft;
		xrPanel1.BorderColor = Color.Gainsboro;
		xrPanel1.Borders = BorderSide.None;
		xrPanel1.BorderWidth = 1f;
		xrPanel1.CanGrow = false;
		xrPanel1.Controls.AddRange(new XRControl[17]
		{
			lblName, xrLabel7, xrLabel4, xrLabel14, xrLabel6, xrLabel2, xrLabel3, lblExpiryDate, lblHeader, picSignatory,
			xrLabel5, xrLabel13, xrLabel15, lblIssueDate, xrLabel12, xrBarCode1, xrPictureBox1
		});
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(339f, 216f);
		xrPanel1.StylePriority.UseBorderColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		xrPanel1.StylePriority.UseBorderWidth = false;
		lblName.BorderColor = Color.Gainsboro;
		lblName.Borders = BorderSide.None;
		lblName.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Bold);
		lblName.LocationFloat = new PointFloat(180.5f, 44.5f);
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblName.SizeF = new SizeF(151.541f, 23.00002f);
		lblName.StylePriority.UseBackColor = false;
		lblName.StylePriority.UseBorderColor = false;
		lblName.StylePriority.UseBorders = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UsePadding = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "Kiberu Mudathel";
		lblName.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel7.Borders = BorderSide.None;
		xrLabel7.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel7.ForeColor = Color.Maroon;
		xrLabel7.LocationFloat = new PointFloat(141.5f, 67.49999f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(39.00002f, 23.00002f);
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseForeColor = false;
		xrLabel7.StylePriority.UsePadding = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "Stud #:";
		xrLabel7.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel4.ForeColor = Color.Maroon;
		xrLabel4.LocationFloat = new PointFloat(141.5f, 90.50002f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(39.00002f, 20.99995f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseForeColor = false;
		xrLabel4.StylePriority.UsePadding = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "ID No:";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel14.Borders = BorderSide.None;
		xrLabel14.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel14.ForeColor = Color.Maroon;
		xrLabel14.LocationFloat = new PointFloat(141.5f, 135.5f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(38.5f, 23.00002f);
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseForeColor = false;
		xrLabel14.StylePriority.UsePadding = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.Text = "Issued:";
		xrLabel14.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.Borders = BorderSide.None;
		xrLabel6.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.ForeColor = Color.Maroon;
		xrLabel6.LocationFloat = new PointFloat(141.5f, 44.5f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(39.00002f, 23.00002f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UsePadding = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Name:";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel2.Borders = BorderSide.None;
		xrLabel2.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(180.5f, 67.49999f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(151.541f, 23.00002f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UsePadding = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "STUD003";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Bold);
		xrLabel3.ForeColor = Color.Red;
		xrLabel3.LocationFloat = new PointFloat(180.5f, 90.5f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(151.541f, 20.99998f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseForeColor = false;
		xrLabel3.StylePriority.UsePadding = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "0130";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		lblExpiryDate.BorderColor = SystemColors.AppWorkspace;
		lblExpiryDate.Borders = BorderSide.None;
		lblExpiryDate.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Bold);
		lblExpiryDate.LocationFloat = new PointFloat(277.2084f, 135.5f);
		lblExpiryDate.Name = "lblExpiryDate";
		lblExpiryDate.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblExpiryDate.SizeF = new SizeF(54.83264f, 22.99998f);
		lblExpiryDate.StylePriority.UseBorderColor = false;
		lblExpiryDate.StylePriority.UseBorders = false;
		lblExpiryDate.StylePriority.UseFont = false;
		lblExpiryDate.StylePriority.UsePadding = false;
		lblExpiryDate.StylePriority.UseTextAlignment = false;
		lblExpiryDate.Text = "Dec-14";
		lblExpiryDate.TextAlignment = TextAlignment.MiddleCenter;
		lblHeader.BackColor = Color.CadetBlue;
		lblHeader.Borders = BorderSide.None;
		lblHeader.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblHeader.ForeColor = Color.White;
		lblHeader.LocationFloat = new PointFloat(0f, 0f);
		lblHeader.Name = "lblHeader";
		lblHeader.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblHeader.SizeF = new SizeF(339f, 23f);
		lblHeader.StylePriority.UseBackColor = false;
		lblHeader.StylePriority.UseBorders = false;
		lblHeader.StylePriority.UseFont = false;
		lblHeader.StylePriority.UseForeColor = false;
		lblHeader.StylePriority.UsePadding = false;
		lblHeader.StylePriority.UseTextAlignment = false;
		lblHeader.Text = "INTELLIGENT WORKS";
		lblHeader.TextAlignment = TextAlignment.MiddleCenter;
		picSignatory.Borders = BorderSide.None;
		picSignatory.Image = (Image)componentResourceManager.GetObject("picSignatory.Image");
		picSignatory.LocationFloat = new PointFloat(244.5f, 162f);
		picSignatory.Name = "picSignatory";
		picSignatory.SizeF = new SizeF(87.58269f, 18.62459f);
		picSignatory.Sizing = ImageSizeMode.StretchImage;
		picSignatory.StylePriority.UseBorders = false;
		xrLabel5.BackColor = Color.Transparent;
		xrLabel5.Borders = BorderSide.None;
		xrLabel5.Font = new DXFont("Microsoft Sans Serif", 11f, DXFontStyle.Bold);
		xrLabel5.ForeColor = Color.Red;
		xrLabel5.LocationFloat = new PointFloat(110.5f, 23f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(108f, 17.99999f);
		xrLabel5.StylePriority.UseBackColor = false;
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseForeColor = false;
		xrLabel5.StylePriority.UsePadding = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Student ID";
		xrLabel5.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel13.BorderColor = SystemColors.AppWorkspace;
		xrLabel13.Borders = BorderSide.Top;
		xrLabel13.Font = new DXFont("Times New Roman", 7f, DXFontStyle.Italic, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel13.LocationFloat = new PointFloat(244.5f, 182.5f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(87.58269f, 15.95999f);
		xrLabel13.StylePriority.UseBorderColor = false;
		xrLabel13.StylePriority.UseBorders = false;
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Issued by";
		xrLabel13.TextAlignment = TextAlignment.BottomCenter;
		xrLabel15.Borders = BorderSide.None;
		xrLabel15.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel15.ForeColor = Color.Maroon;
		xrLabel15.LocationFloat = new PointFloat(232.7915f, 135.5f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(44.41685f, 22.99998f);
		xrLabel15.StylePriority.UseBorders = false;
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseForeColor = false;
		xrLabel15.StylePriority.UsePadding = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Expires:";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		lblIssueDate.BorderColor = SystemColors.AppWorkspace;
		lblIssueDate.Borders = BorderSide.None;
		lblIssueDate.Font = new DXFont("Microsoft Sans Serif", 8.25f, DXFontStyle.Bold);
		lblIssueDate.LocationFloat = new PointFloat(180f, 135.5f);
		lblIssueDate.Name = "lblIssueDate";
		lblIssueDate.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblIssueDate.SizeF = new SizeF(52.50002f, 22.99989f);
		lblIssueDate.StylePriority.UseBorderColor = false;
		lblIssueDate.StylePriority.UseBorders = false;
		lblIssueDate.StylePriority.UseFont = false;
		lblIssueDate.StylePriority.UsePadding = false;
		lblIssueDate.StylePriority.UseTextAlignment = false;
		lblIssueDate.Text = "Jan-12";
		lblIssueDate.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel12.BorderColor = SystemColors.AppWorkspace;
		xrLabel12.Borders = BorderSide.Top;
		xrLabel12.Font = new DXFont("Times New Roman", 7f, DXFontStyle.Italic, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel12.LocationFloat = new PointFloat(154.3751f, 182.5f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(86.36194f, 15.95845f);
		xrLabel12.StylePriority.UseBorderColor = false;
		xrLabel12.StylePriority.UseBorders = false;
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Holder's signature";
		xrLabel12.TextAlignment = TextAlignment.BottomCenter;
		xrBarCode1.AutoModule = true;
		xrBarCode1.Borders = BorderSide.None;
		xrBarCode1.Font = new DXFont("Tahoma", 7f);
		xrBarCode1.LocationFloat = new PointFloat(8.499993f, 178.5f);
		xrBarCode1.Module = 1f;
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode1.ShowText = false;
		xrBarCode1.SizeF = new SizeF(125f, 19.95847f);
		xrBarCode1.StylePriority.UseBorders = false;
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UsePadding = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		code39ExtendedGenerator.WideNarrowRatio = 3f;
		xrBarCode1.Symbology = code39ExtendedGenerator;
		xrBarCode1.Text = "xrBarCode1";
		xrBarCode1.TextAlignment = TextAlignment.MiddleCenter;
		xrPictureBox1.BorderColor = Color.Silver;
		xrPictureBox1.Borders = BorderSide.None;
		xrPictureBox1.Image = (Image)componentResourceManager.GetObject("xrPictureBox1.Image");
		xrPictureBox1.LocationFloat = new PointFloat(6.00001f, 44.00001f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(130.5f, 132.5f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrLine3.BorderWidth = 0f;
		xrLine3.ForeColor = Color.Black;
		xrLine3.LineWidth = 4f;
		xrLine3.LocationFloat = new PointFloat(0f, 212f);
		xrLine3.Name = "xrLine3";
		xrLine3.SizeF = new SizeF(339f, 4f);
		xrLine3.StylePriority.UseBorderWidth = false;
		xrLine3.StylePriority.UseForeColor = false;
		pnlColors.Controls.AddRange(new XRControl[2] { xrLine1, xrLine2 });
		pnlColors.LocationFloat = new PointFloat(0f, 204f);
		pnlColors.Name = "pnlColors";
		pnlColors.SizeF = new SizeF(339f, 12f);
		xrLine1.BorderWidth = 0f;
		xrLine1.ForeColor = Color.SteelBlue;
		xrLine1.LineWidth = 4f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(339f, 4f);
		xrLine1.StylePriority.UseBorderWidth = false;
		xrLine1.StylePriority.UseForeColor = false;
		xrLine2.BorderWidth = 0f;
		xrLine2.ForeColor = Color.Cornsilk;
		xrLine2.LineWidth = 4f;
		xrLine2.LocationFloat = new PointFloat(0f, 3.999989f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(339f, 4f);
		xrLine2.StylePriority.UseBorderWidth = false;
		xrLine2.StylePriority.UseForeColor = false;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		xrControlStyle1.Name = "xrControlStyle1";
		xrControlStyle1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		Bookmark = "Students List";
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 216;
		base.PageWidth = 339;
		base.PaperKind = DXPaperKind.Custom;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[1] { xrControlStyle1 });
		base.Version = "13.1";
		BeforePrint += ID_Fullpage_BeforePrint;
		AfterPrint += ID_Fullpage_AfterPrint;
		((ISupportInitialize)this).EndInit();
	}
}
