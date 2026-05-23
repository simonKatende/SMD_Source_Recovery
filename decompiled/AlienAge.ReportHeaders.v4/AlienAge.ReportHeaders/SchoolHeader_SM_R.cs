using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace AlienAge.ReportHeaders;

public class SchoolHeader_SM_R : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRPictureBox xrPictureBox1;

	private XRLabel lblFullContact;

	private XRLabel lblSchoolName;

	private XRLabel lblLocation;

	public SchoolHeader_SM_R()
	{
		InitializeComponent();
	}

	private void SchoolHeader_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.ForeColor = Color.FromArgb((int)ReportColors.ReportHeaderTextColor);
		lblSchoolName.Font = new Font(ReportFonts.HeaderFont, ReportFonts.FontSize);
		lblSchoolName.Text = ReportHeader.SchoolName;
		lblLocation.Text = ReportHeader.SchoolLocation;
		lblFullContact.Text = ReportHeader.SchoolFullAddress;
		xrPictureBox1.Image = ReportHeader.SchoolLogo;
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
		lblFullContact = new XRLabel();
		lblSchoolName = new XRLabel();
		lblLocation = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[4] { lblFullContact, lblSchoolName, lblLocation, xrPictureBox1 });
		Detail.HeightF = 77f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		lblFullContact.BackColor = Color.Transparent;
		lblFullContact.CanGrow = false;
		lblFullContact.Font = new DXFont("Microsoft Sans Serif", 8f);
		lblFullContact.LocationFloat = new PointFloat(75.77612f, 29.99998f);
		lblFullContact.Name = "lblFullContact";
		lblFullContact.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblFullContact.SizeF = new SizeF(460.2239f, 21f);
		lblFullContact.StyleName = "DataField";
		lblFullContact.StylePriority.UseBackColor = false;
		lblFullContact.StylePriority.UseFont = false;
		lblFullContact.StylePriority.UsePadding = false;
		lblFullContact.StylePriority.UseTextAlignment = false;
		lblFullContact.Text = "Full Contact";
		lblFullContact.TextAlignment = TextAlignment.MiddleRight;
		lblFullContact.WordWrap = false;
		lblSchoolName.BackColor = Color.Transparent;
		lblSchoolName.CanGrow = false;
		lblSchoolName.Font = new DXFont("Microsoft Sans Serif", 10f, DXFontStyle.Bold);
		lblSchoolName.ForeColor = Color.FromArgb(0, 64, 128);
		lblSchoolName.LocationFloat = new PointFloat(75.77612f, 0f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(460.2239f, 27.5f);
		lblSchoolName.StyleName = "DataField";
		lblSchoolName.StylePriority.UseBackColor = false;
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseForeColor = false;
		lblSchoolName.StylePriority.UsePadding = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.Text = "Name";
		lblSchoolName.TextAlignment = TextAlignment.MiddleRight;
		lblSchoolName.WordWrap = false;
		lblLocation.BackColor = Color.Transparent;
		lblLocation.CanGrow = false;
		lblLocation.Font = new DXFont("Microsoft Sans Serif", 8f);
		lblLocation.LocationFloat = new PointFloat(75.77612f, 54f);
		lblLocation.Name = "lblLocation";
		lblLocation.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblLocation.SizeF = new SizeF(460.2239f, 21f);
		lblLocation.StyleName = "DataField";
		lblLocation.StylePriority.UseBackColor = false;
		lblLocation.StylePriority.UseFont = false;
		lblLocation.StylePriority.UsePadding = false;
		lblLocation.StylePriority.UseTextAlignment = false;
		lblLocation.Text = "Location";
		lblLocation.TextAlignment = TextAlignment.MiddleRight;
		lblLocation.WordWrap = false;
		xrPictureBox1.BackColor = Color.Transparent;
		xrPictureBox1.LocationFloat = new PointFloat(0f, 0f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(72f, 75f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StyleName = "DataField";
		xrPictureBox1.StylePriority.UseBackColor = false;
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
		base.PageHeight = 120;
		base.PageWidth = 536;
		base.PaperKind = DXPaperKind.Custom;
		base.SnapGridSize = 1f;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "17.2";
		BeforePrint += SchoolHeader_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
