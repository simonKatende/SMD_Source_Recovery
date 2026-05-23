using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using I_Xtreme.Properties;
using I_Xtreme.StaffIDS.StaffDataTableAdapters;
using I_Xtreme.StudentIDs;

namespace I_Xtreme.StaffIDS;

public class Staff_IDS : XtraReport
{
	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRControlStyle xrControlStyle1;

	public DetailBand Detail1;

	private StaffData staffData1;

	private StaffTableAdapter staffTableAdapter;

	private XRPictureBox picSchoolLogo;

	private XRLabel lblHeader;

	private XRPictureBox xrPictureBox1;

	private XRLabel xrLabel6;

	private XRLabel lblName;

	private XRBarCode xrBarCode1;

	private XRLabel xrLabel15;

	private XRLabel lblValidity;

	private XRLabel xrLabel7;

	private XRPictureBox picSignatory;

	private XRLabel xrLabel1;

	public XRPanel xrPanel1;

	private XRLabel xrLabel2;

	private XRLabel xrLabel3;

	public Staff_IDS()
	{
		InitializeComponent();
	}

	private void ID_Fullpage_BeforePrint(object sender, CancelEventArgs e)
	{
		lblHeader.BackColor = Color.FromArgb(I_Xtreme.StudentIDs.IDCustomization.HBColor);
		lblHeader.ForeColor = Color.FromArgb(I_Xtreme.StudentIDs.IDCustomization.HFColor);
		lblHeader.Font = new Font(I_Xtreme.StudentIDs.IDCustomization.HFont, (float)I_Xtreme.StudentIDs.IDCustomization.FontSize);
		picSignatory.Image = IDCustomization.Signatory;
		lblHeader.Text = ReportHeader.SchoolName;
		picSchoolLogo.Image = ReportHeader.SchoolLogo;
		lblValidity.Text = IDCustomization.Validity.ToString("dd.MMM.yy");
		picSignatory.Image = I_Xtreme.StudentIDs.IDCustomization.Signatory;
	}

	private void lblName_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		string text = lblName.Text;
		((XRLabel)sender).Bookmark += text;
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
		QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
		Detail1 = new DetailBand();
		xrPanel1 = new XRPanel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		picSignatory = new XRPictureBox();
		lblName = new XRLabel();
		xrBarCode1 = new XRBarCode();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		lblValidity = new XRLabel();
		xrLabel15 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		picSchoolLogo = new XRPictureBox();
		lblHeader = new XRLabel();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		xrControlStyle1 = new XRControlStyle();
		staffData1 = new StaffData();
		staffTableAdapter = new StaffTableAdapter();
		((ISupportInitialize)staffData1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[1] { xrPanel1 });
		Detail1.HeightF = 228.625f;
		Detail1.MultiColumn.ColumnSpacing = 100f;
		Detail1.MultiColumn.ColumnWidth = 339f;
		Detail1.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail1.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail1.Name = "Detail1";
		Detail1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.PageBreak = PageBreak.AfterBand;
		Detail1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.SortFields.AddRange(new GroupField[1]
		{
			new GroupField("fullName", XRColumnSortOrder.Ascending)
		});
		Detail1.TextAlignment = TextAlignment.TopLeft;
		xrPanel1.BorderColor = Color.Transparent;
		xrPanel1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrPanel1.BorderWidth = 1f;
		xrPanel1.CanGrow = false;
		xrPanel1.Controls.AddRange(new XRControl[13]
		{
			xrLabel3, xrLabel2, xrLabel1, picSignatory, lblName, xrBarCode1, xrLabel7, xrLabel6, lblValidity, xrLabel15,
			xrPictureBox1, picSchoolLogo, lblHeader
		});
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(339f, 216f);
		xrPanel1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrPanel1.StylePriority.UseBorderColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		xrPanel1.StylePriority.UseBorderWidth = false;
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.Font = new DXFont("Microsoft Sans Serif", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel3.ForeColor = Color.Maroon;
		xrLabel3.LocationFloat = new PointFloat(122f, 115.5f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(158.5f, 18.99999f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseForeColor = false;
		xrLabel3.StylePriority.UsePadding = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "Staff ID No.";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StaffId]")
		});
		xrLabel2.Font = new DXFont("Times New Roman", 9.75f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(122f, 135.5f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(158.5f, 23f);
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.BackColor = Color.Transparent;
		xrLabel1.CanShrink = true;
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Responsibility]")
		});
		xrLabel1.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold);
		xrLabel1.ForeColor = Color.Black;
		xrLabel1.LocationFloat = new PointFloat(122.5f, 89.5f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(209.5f, 23f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel1";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.WordWrap = false;
		picSignatory.Borders = BorderSide.None;
		picSignatory.ImageAlignment = ImageAlignment.MiddleCenter;
		picSignatory.ImageSource = new ImageSource(Resources.signature_TL, isSharedResource: true);
		picSignatory.LocationFloat = new PointFloat(175.5f, 174.5f);
		picSignatory.Name = "picSignatory";
		picSignatory.SizeF = new SizeF(156f, 39f);
		picSignatory.Sizing = ImageSizeMode.StretchImage;
		picSignatory.StylePriority.UseBorders = false;
		lblName.BorderColor = Color.Gainsboro;
		lblName.Borders = BorderSide.None;
		lblName.CanGrow = false;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StaffName]")
		});
		lblName.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		lblName.LocationFloat = new PointFloat(123f, 65.50002f);
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		lblName.SizeF = new SizeF(212f, 18.99999f);
		lblName.StylePriority.UseBackColor = false;
		lblName.StylePriority.UseBorderColor = false;
		lblName.StylePriority.UseBorders = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UsePadding = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "lblName";
		lblName.TextAlignment = TextAlignment.MiddleLeft;
		lblName.WordWrap = false;
		xrBarCode1.Alignment = TextAlignment.MiddleRight;
		xrBarCode1.AutoModule = true;
		xrBarCode1.Borders = BorderSide.None;
		xrBarCode1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StaffId]")
		});
		xrBarCode1.Font = new DXFont("Tahoma", 12f);
		xrBarCode1.ForeColor = Color.Black;
		xrBarCode1.LocationFloat = new PointFloat(280.5f, 117f);
		xrBarCode1.Module = 1f;
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode1.ShowText = false;
		xrBarCode1.SizeF = new SizeF(54.5f, 51.95853f);
		xrBarCode1.StylePriority.UseBorders = false;
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UseForeColor = false;
		xrBarCode1.StylePriority.UsePadding = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		qRCodeGenerator.Version = QRCodeVersion.Version1;
		xrBarCode1.Symbology = qRCodeGenerator;
		xrBarCode1.Text = "KHS-0001";
		xrBarCode1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.BorderColor = Color.DimGray;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = BorderSide.None;
		xrLabel7.Font = new DXFont("Microsoft Sans Serif", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel7.ForeColor = Color.Maroon;
		xrLabel7.LocationFloat = new PointFloat(124f, 183.5f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(49.49994f, 19f);
		xrLabel7.StylePriority.UseBorderColor = false;
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseForeColor = false;
		xrLabel7.StylePriority.UsePadding = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "Issued By";
		xrLabel7.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.Borders = BorderSide.None;
		xrLabel6.Font = new DXFont("Microsoft Sans Serif", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.ForeColor = Color.Maroon;
		xrLabel6.LocationFloat = new PointFloat(123f, 46.50002f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(212f, 18.99999f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UsePadding = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Name:";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		lblValidity.BackColor = Color.Silver;
		lblValidity.BorderColor = Color.Black;
		lblValidity.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		lblValidity.Font = new DXFont("Tahoma", 6.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblValidity.ForeColor = Color.Black;
		lblValidity.LocationFloat = new PointFloat(2f, 178f);
		lblValidity.Name = "lblValidity";
		lblValidity.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
		lblValidity.SizeF = new SizeF(115.5f, 18.99998f);
		lblValidity.StylePriority.UseBackColor = false;
		lblValidity.StylePriority.UseBorderColor = false;
		lblValidity.StylePriority.UseBorders = false;
		lblValidity.StylePriority.UseFont = false;
		lblValidity.StylePriority.UseForeColor = false;
		lblValidity.StylePriority.UsePadding = false;
		lblValidity.StylePriority.UseTextAlignment = false;
		lblValidity.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel15.BackColor = Color.Black;
		xrLabel15.BorderColor = Color.Black;
		xrLabel15.Borders = BorderSide.Left | BorderSide.Right;
		xrLabel15.Font = new DXFont("Tahoma", 7f);
		xrLabel15.ForeColor = Color.Silver;
		xrLabel15.LocationFloat = new PointFloat(2f, 159f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(115.5f, 18.99998f);
		xrLabel15.StylePriority.UseBackColor = false;
		xrLabel15.StylePriority.UseBorderColor = false;
		xrLabel15.StylePriority.UseBorders = false;
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseForeColor = false;
		xrLabel15.StylePriority.UsePadding = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Expiry Date";
		xrLabel15.TextAlignment = TextAlignment.MiddleCenter;
		xrPictureBox1.BorderColor = Color.Black;
		xrPictureBox1.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Pic]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(2f, 44f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(115.5f, 115f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		picSchoolLogo.Borders = BorderSide.None;
		picSchoolLogo.LocationFloat = new PointFloat(2f, 1.5f);
		picSchoolLogo.Name = "picSchoolLogo";
		picSchoolLogo.SizeF = new SizeF(46.875f, 41f);
		picSchoolLogo.Sizing = ImageSizeMode.StretchImage;
		picSchoolLogo.StylePriority.UseBorders = false;
		lblHeader.BackColor = Color.CadetBlue;
		lblHeader.Borders = BorderSide.None;
		lblHeader.BorderWidth = 0f;
		lblHeader.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblHeader.ForeColor = Color.White;
		lblHeader.LocationFloat = new PointFloat(50f, 0f);
		lblHeader.Name = "lblHeader";
		lblHeader.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblHeader.SizeF = new SizeF(287.5f, 43f);
		lblHeader.StylePriority.UseBackColor = false;
		lblHeader.StylePriority.UseBorders = false;
		lblHeader.StylePriority.UseBorderWidth = false;
		lblHeader.StylePriority.UseFont = false;
		lblHeader.StylePriority.UseForeColor = false;
		lblHeader.StylePriority.UsePadding = false;
		lblHeader.StylePriority.UseTextAlignment = false;
		lblHeader.TextAlignment = TextAlignment.MiddleCenter;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		xrControlStyle1.Name = "xrControlStyle1";
		xrControlStyle1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		staffData1.DataSetName = "StaffData";
		staffData1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		staffTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		Bookmark = "Staff Identity Cards";
		base.DataAdapter = staffTableAdapter;
		base.DataMember = "Staff";
		base.DataSource = staffData1;
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 216;
		base.PageWidth = 339;
		base.PaperKind = DXPaperKind.Custom;
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
		base.ReportPrintOptions.PrintOnEmptyDataSource = false;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[1] { xrControlStyle1 });
		base.Version = "21.2";
		base.Watermark.Font = new DXFont("Verdana", 18f);
		BeforePrint += ID_Fullpage_BeforePrint;
		((ISupportInitialize)staffData1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
