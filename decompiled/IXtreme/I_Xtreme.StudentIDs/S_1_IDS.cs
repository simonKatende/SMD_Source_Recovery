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
using I_Xtreme.StudentID_Datasets;
using I_Xtreme.StudentID_Datasets.DataSet_S1TableAdapters;

namespace I_Xtreme.StudentIDs;

public class S_1_IDS : XtraReport
{
	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRControlStyle xrControlStyle1;

	public DetailBand Detail1;

	public XRPanel xrPanel1;

	private DataSet_S1 dataSet_S11;

	private S_1ID_DataTable1TableAdapter s_1ID_DataTable1TableAdapter;

	private XRLine xrLine3;

	private XRPanel pnlColors;

	private XRLine xrLine1;

	private XRLine xrLine2;

	private XRBarCode xrBarCode1;

	private XRPictureBox xrPictureBox1;

	private XRLabel lblName;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLabel lblExpiryDate;

	private XRLabel xrLabel15;

	private XRPictureBox picSchoolLogo;

	private XRLabel lblHeader;

	private XRPictureBox picSignatory;

	private XRLabel xrLabel1;

	private XRLabel xrLabel2;

	private XRLabel xrLabel3;

	private XRLabel xrLabel4;

	public S_1_IDS()
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
		lblExpiryDate.Text = IDCustomization.ExpiryDate.ToString("MMM-yyyy");
		lblHeader.Text = ReportHeader.SchoolName;
		picSchoolLogo.Image = ReportHeader.SchoolLogo;
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
		EAN13Generator symbology = new EAN13Generator();
		XRWatermark xRWatermark = new XRWatermark();
		Detail1 = new DetailBand();
		xrLine3 = new XRLine();
		pnlColors = new XRPanel();
		xrLine1 = new XRLine();
		xrLine2 = new XRLine();
		xrPanel1 = new XRPanel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		picSignatory = new XRPictureBox();
		picSchoolLogo = new XRPictureBox();
		lblHeader = new XRLabel();
		lblName = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		lblExpiryDate = new XRLabel();
		xrLabel15 = new XRLabel();
		xrBarCode1 = new XRBarCode();
		xrPictureBox1 = new XRPictureBox();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		xrControlStyle1 = new XRControlStyle();
		dataSet_S11 = new DataSet_S1();
		s_1ID_DataTable1TableAdapter = new S_1ID_DataTable1TableAdapter();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		((ISupportInitialize)dataSet_S11).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[3] { xrLine3, pnlColors, xrPanel1 });
		Detail1.HeightF = 216.1667f;
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
		xrLine3.BorderWidth = 0f;
		xrLine3.ForeColor = Color.Black;
		xrLine3.LineWidth = 4f;
		xrLine3.LocationFloat = new PointFloat(0f, 212f);
		xrLine3.Name = "xrLine3";
		xrLine3.SizeF = new SizeF(339f, 4.166667f);
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
		xrLine1.SizeF = new SizeF(339f, 4.166667f);
		xrLine1.StylePriority.UseBorderWidth = false;
		xrLine1.StylePriority.UseForeColor = false;
		xrLine2.BorderWidth = 0f;
		xrLine2.ForeColor = Color.Cornsilk;
		xrLine2.LineWidth = 4f;
		xrLine2.LocationFloat = new PointFloat(0f, 3.999989f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(339f, 4.166667f);
		xrLine2.StylePriority.UseBorderWidth = false;
		xrLine2.StylePriority.UseForeColor = false;
		xrPanel1.BorderColor = Color.Transparent;
		xrPanel1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrPanel1.BorderWidth = 1f;
		xrPanel1.CanGrow = false;
		xrPanel1.Controls.AddRange(new XRControl[14]
		{
			xrLabel4, xrLabel3, xrLabel2, xrLabel1, picSignatory, picSchoolLogo, lblHeader, lblName, xrLabel7, xrLabel6,
			lblExpiryDate, xrLabel15, xrBarCode1, xrPictureBox1
		});
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(339f, 216f);
		xrPanel1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrPanel1.StylePriority.UseBorderColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		xrPanel1.StylePriority.UseBorderWidth = false;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrLabel2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(157.5f, 45.00001f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(177f, 13f);
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.Borders = BorderSide.None;
		xrLabel1.Font = new DXFont("Microsoft Sans Serif", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel1.ForeColor = Color.Maroon;
		xrLabel1.LocationFloat = new PointFloat(121.5f, 45.00001f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(33.99996f, 13f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UsePadding = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "ID No";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		picSignatory.Borders = BorderSide.None;
		picSignatory.ImageAlignment = ImageAlignment.MiddleCenter;
		picSignatory.ImageSource = new ImageSource(Resources.signature_TL, isSharedResource: true);
		picSignatory.LocationFloat = new PointFloat(174.5f, 160f);
		picSignatory.Name = "picSignatory";
		picSignatory.SizeF = new SizeF(156f, 39f);
		picSignatory.Sizing = ImageSizeMode.StretchImage;
		picSignatory.StylePriority.UseBorders = false;
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
		lblName.BorderColor = Color.Gainsboro;
		lblName.Borders = BorderSide.None;
		lblName.CanGrow = false;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblName.LocationFloat = new PointFloat(157.5f, 60.5f);
		lblName.Multiline = true;
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		lblName.SizeF = new SizeF(178.4999f, 36.50001f);
		lblName.StylePriority.UseBackColor = false;
		lblName.StylePriority.UseBorderColor = false;
		lblName.StylePriority.UseBorders = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UsePadding = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "lblName";
		lblName.TextAlignment = TextAlignment.TopLeft;
		lblName.PrintOnPage += lblName_PrintOnPage;
		xrLabel7.BorderColor = Color.DimGray;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = BorderSide.None;
		xrLabel7.Font = new DXFont("Microsoft Sans Serif", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel7.ForeColor = Color.Maroon;
		xrLabel7.LocationFloat = new PointFloat(123f, 169f);
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
		xrLabel6.LocationFloat = new PointFloat(121.5f, 60.5f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(33.99997f, 13f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UsePadding = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Name:";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		lblExpiryDate.BackColor = Color.Silver;
		lblExpiryDate.BorderColor = Color.Black;
		lblExpiryDate.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		lblExpiryDate.Font = new DXFont("Tahoma", 6.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblExpiryDate.ForeColor = Color.Black;
		lblExpiryDate.LocationFloat = new PointFloat(2f, 178f);
		lblExpiryDate.Name = "lblExpiryDate";
		lblExpiryDate.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
		lblExpiryDate.SizeF = new SizeF(115.5f, 18.99998f);
		lblExpiryDate.StylePriority.UseBackColor = false;
		lblExpiryDate.StylePriority.UseBorderColor = false;
		lblExpiryDate.StylePriority.UseBorders = false;
		lblExpiryDate.StylePriority.UseFont = false;
		lblExpiryDate.StylePriority.UseForeColor = false;
		lblExpiryDate.StylePriority.UsePadding = false;
		lblExpiryDate.StylePriority.UseTextAlignment = false;
		lblExpiryDate.TextAlignment = TextAlignment.MiddleCenter;
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
		xrBarCode1.AutoModule = true;
		xrBarCode1.Borders = BorderSide.None;
		xrBarCode1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode1.Font = new DXFont("Tahoma", 12f);
		xrBarCode1.ForeColor = Color.Black;
		xrBarCode1.LocationFloat = new PointFloat(123f, 114.5f);
		xrBarCode1.Module = 1f;
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode1.ShowText = false;
		xrBarCode1.SizeF = new SizeF(212f, 41.45852f);
		xrBarCode1.StylePriority.UseBorders = false;
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UseForeColor = false;
		xrBarCode1.StylePriority.UsePadding = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		xrBarCode1.Symbology = symbology;
		xrBarCode1.Text = "123456789012812345678901283456789012812345678901281234567890128";
		xrBarCode1.TextAlignment = TextAlignment.MiddleCenter;
		xrPictureBox1.BorderColor = Color.Black;
		xrPictureBox1.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(2f, 44.00001f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(115.5f, 115f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		xrControlStyle1.Name = "xrControlStyle1";
		xrControlStyle1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		dataSet_S11.DataSetName = "DataSet_S1";
		dataSet_S11.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		s_1ID_DataTable1TableAdapter.ClearBeforeFill = true;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HouseId]")
		});
		xrLabel3.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrLabel3.LocationFloat = new PointFloat(157.5f, 98f);
		xrLabel3.Multiline = true;
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrLabel3.SizeF = new SizeF(100f, 12.99999f);
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.Font = new DXFont("Microsoft Sans Serif", 6.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel4.ForeColor = Color.Maroon;
		xrLabel4.LocationFloat = new PointFloat(121.5f, 98f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(33.99997f, 13f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseForeColor = false;
		xrLabel4.StylePriority.UsePadding = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "House:";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		Bookmark = "Students List";
		base.DataAdapter = s_1ID_DataTable1TableAdapter;
		base.DataMember = "S_1ID_DataTable1";
		base.DataSource = dataSet_S11;
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
		base.Version = "23.2";
		xRWatermark.Font = new DXFont("Verdana", 18f);
		xRWatermark.Id = "Watermark1";
		base.Watermarks.Add(xRWatermark);
		BeforePrint += ID_Fullpage_BeforePrint;
		((ISupportInitialize)dataSet_S11).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
