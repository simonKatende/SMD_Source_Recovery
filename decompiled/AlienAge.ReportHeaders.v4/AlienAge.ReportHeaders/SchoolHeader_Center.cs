using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace AlienAge.ReportHeaders;

public class SchoolHeader_Center : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel lblTelephone;

	private XRLabel lblSchoolName;

	private XRPictureBox xrPictureBox1;

	private XRLabel lblBox;

	private XRLabel lblLocation;

	private XRLabel lblMotto;

	public SchoolHeader_Center()
	{
		InitializeComponent();
	}

	private void SchoolHeader_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.ForeColor = Color.FromArgb((int)ReportColors.ReportHeaderTextColor);
		lblSchoolName.Font = new Font(ReportFonts.HeaderFont, ReportFonts.FontSize);
		lblSchoolName.Text = ReportHeader.SchoolName;
		lblBox.Text = ReportHeader.SchoolBoxNo;
		lblLocation.Text = ReportHeader.SchoolLocation;
		lblMotto.Text = ReportHeader.SchoolMotto;
		lblTelephone.Text = ReportHeader.SchoolTel;
		xrPictureBox1.Image = ReportHeader.SchoolLogo;
		lblMotto.ForeColor = Color.FromArgb((int)ReportColors.ReportHeaderTextColor);
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
		lblLocation = new XRLabel();
		lblMotto = new XRLabel();
		lblTelephone = new XRLabel();
		lblSchoolName = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		lblBox = new XRLabel();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[6] { lblLocation, lblMotto, lblTelephone, lblSchoolName, xrPictureBox1, lblBox });
		Detail.HeightF = 110f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		lblLocation.BackColor = Color.Transparent;
		lblLocation.CanGrow = false;
		lblLocation.Font = new DXFont("Microsoft Sans Serif", 12f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblLocation.LocationFloat = new PointFloat(0f, 62f);
		lblLocation.Name = "lblLocation";
		lblLocation.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblLocation.SizeF = new SizeF(344.9999f, 20.99999f);
		lblLocation.StyleName = "DataField";
		lblLocation.StylePriority.UseBackColor = false;
		lblLocation.StylePriority.UseFont = false;
		lblLocation.StylePriority.UsePadding = false;
		lblLocation.StylePriority.UseTextAlignment = false;
		lblLocation.Text = "Location";
		lblLocation.TextAlignment = TextAlignment.MiddleRight;
		lblLocation.WordWrap = false;
		lblMotto.BackColor = Color.Transparent;
		lblMotto.CanGrow = false;
		lblMotto.Font = new DXFont("Microsoft Sans Serif", 12f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblMotto.LocationFloat = new PointFloat(431f, 62f);
		lblMotto.Name = "lblMotto";
		lblMotto.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblMotto.SizeF = new SizeF(342.0001f, 20.99999f);
		lblMotto.StyleName = "DataField";
		lblMotto.StylePriority.UseBackColor = false;
		lblMotto.StylePriority.UseFont = false;
		lblMotto.StylePriority.UsePadding = false;
		lblMotto.StylePriority.UseTextAlignment = false;
		lblMotto.Text = "Motto";
		lblMotto.TextAlignment = TextAlignment.MiddleLeft;
		lblMotto.WordWrap = false;
		lblTelephone.BackColor = Color.Transparent;
		lblTelephone.CanGrow = false;
		lblTelephone.Font = new DXFont("Microsoft Sans Serif", 12f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblTelephone.LocationFloat = new PointFloat(431f, 39f);
		lblTelephone.Name = "lblTelephone";
		lblTelephone.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblTelephone.SizeF = new SizeF(342f, 21f);
		lblTelephone.StyleName = "DataField";
		lblTelephone.StylePriority.UseBackColor = false;
		lblTelephone.StylePriority.UseFont = false;
		lblTelephone.StylePriority.UsePadding = false;
		lblTelephone.StylePriority.UseTextAlignment = false;
		lblTelephone.Text = "Telephone";
		lblTelephone.TextAlignment = TextAlignment.MiddleLeft;
		lblTelephone.WordWrap = false;
		lblSchoolName.BackColor = Color.Transparent;
		lblSchoolName.CanGrow = false;
		lblSchoolName.Font = new DXFont("Microsoft Sans Serif", 24f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblSchoolName.ForeColor = Color.FromArgb(0, 64, 128);
		lblSchoolName.LocationFloat = new PointFloat(0f, 0f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(775f, 37f);
		lblSchoolName.StyleName = "DataField";
		lblSchoolName.StylePriority.UseBackColor = false;
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseForeColor = false;
		lblSchoolName.StylePriority.UsePadding = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.Text = "Name";
		lblSchoolName.TextAlignment = TextAlignment.TopCenter;
		lblSchoolName.WordWrap = false;
		xrPictureBox1.BackColor = Color.Transparent;
		xrPictureBox1.LocationFloat = new PointFloat(347f, 39f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(80.99997f, 71f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StyleName = "DataField";
		xrPictureBox1.StylePriority.UseBackColor = false;
		lblBox.BackColor = Color.Transparent;
		lblBox.CanGrow = false;
		lblBox.Font = new DXFont("Microsoft Sans Serif", 12f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblBox.LocationFloat = new PointFloat(0f, 39f);
		lblBox.Name = "lblBox";
		lblBox.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblBox.SizeF = new SizeF(344.9999f, 21f);
		lblBox.StyleName = "DataField";
		lblBox.StylePriority.UseBackColor = false;
		lblBox.StylePriority.UseFont = false;
		lblBox.StylePriority.UsePadding = false;
		lblBox.StylePriority.UseTextAlignment = false;
		lblBox.Text = "Box";
		lblBox.TextAlignment = TextAlignment.MiddleRight;
		lblBox.WordWrap = false;
		Title.BackColor = Color.White;
		Title.BorderColor = SystemColors.ControlText;
		Title.Borders = BorderSide.None;
		Title.BorderWidth = 1f;
		Title.Font = new DXFont("Times New Roman", 24f);
		Title.ForeColor = Color.Black;
		Title.Name = "Title";
		FieldCaption.BackColor = Color.White;
		FieldCaption.BorderColor = SystemColors.ControlText;
		FieldCaption.Borders = BorderSide.None;
		FieldCaption.BorderWidth = 1f;
		FieldCaption.Font = new DXFont("Times New Roman", 10f, DXFontStyle.Bold);
		FieldCaption.ForeColor = Color.Black;
		FieldCaption.Name = "FieldCaption";
		PageInfo.BackColor = Color.White;
		PageInfo.BorderColor = SystemColors.ControlText;
		PageInfo.Borders = BorderSide.None;
		PageInfo.BorderWidth = 1f;
		PageInfo.Font = new DXFont("Times New Roman", 8f);
		PageInfo.ForeColor = Color.Black;
		PageInfo.Name = "PageInfo";
		DataField.BackColor = Color.White;
		DataField.BorderColor = SystemColors.ControlText;
		DataField.Borders = BorderSide.None;
		DataField.BorderWidth = 1f;
		DataField.Font = new DXFont("Times New Roman", 8f);
		DataField.ForeColor = SystemColors.ControlText;
		DataField.Name = "DataField";
		DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 110;
		base.PageWidth = 775;
		base.PaperKind = DXPaperKind.Custom;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "17.2";
		BeforePrint += SchoolHeader_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
