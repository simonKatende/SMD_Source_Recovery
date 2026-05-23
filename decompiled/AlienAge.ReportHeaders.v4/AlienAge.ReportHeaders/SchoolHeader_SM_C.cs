using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace AlienAge.ReportHeaders;

public class SchoolHeader_SM_C : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel lblSchoolName;

	private XRLabel lblBox;

	private XRLabel lblLocation;

	private XRPictureBox xrPictureBox1;

	private XRLabel lblTelephone;

	private XRLabel lblMotto;

	public SchoolHeader_SM_C()
	{
		InitializeComponent();
	}

	private void SchoolHeader_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.ForeColor = Color.FromArgb((int)ReportColors.ReportHeaderTextColor);
		lblSchoolName.Font = new Font(ReportFonts.HeaderFont, ReportFonts.FontSize);
		lblMotto.Text = ReportHeader.SchoolMotto;
		lblSchoolName.Text = ReportHeader.SchoolName;
		lblLocation.Text = ReportHeader.SchoolLocation;
		lblTelephone.Text = ReportHeader.SchoolTel;
		xrPictureBox1.Image = ReportHeader.SchoolLogo;
		lblBox.Text = ReportHeader.SchoolBoxNo;
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
		lblSchoolName = new XRLabel();
		lblBox = new XRLabel();
		lblLocation = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		lblTelephone = new XRLabel();
		lblMotto = new XRLabel();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[6] { lblSchoolName, lblBox, lblLocation, xrPictureBox1, lblTelephone, lblMotto });
		Detail.HeightF = 77f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		lblSchoolName.BackColor = Color.Transparent;
		lblSchoolName.CanGrow = false;
		lblSchoolName.Font = new DXFont("Microsoft Sans Serif", 10f, DXFontStyle.Bold);
		lblSchoolName.ForeColor = Color.FromArgb(0, 64, 128);
		lblSchoolName.LocationFloat = new PointFloat(0f, 0f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(536f, 27.5f);
		lblSchoolName.StyleName = "DataField";
		lblSchoolName.StylePriority.UseBackColor = false;
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseForeColor = false;
		lblSchoolName.StylePriority.UsePadding = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.Text = "Name";
		lblSchoolName.TextAlignment = TextAlignment.TopCenter;
		lblSchoolName.WordWrap = false;
		lblBox.BackColor = Color.Transparent;
		lblBox.CanGrow = false;
		lblBox.Font = new DXFont("Microsoft Sans Serif", 10f);
		lblBox.LocationFloat = new PointFloat(0f, 30.00001f);
		lblBox.Name = "lblBox";
		lblBox.Padding = new PaddingInfo(0, 2, 0, 0, 100f);
		lblBox.SizeF = new SizeF(239f, 21f);
		lblBox.StyleName = "DataField";
		lblBox.StylePriority.UseBackColor = false;
		lblBox.StylePriority.UseFont = false;
		lblBox.StylePriority.UsePadding = false;
		lblBox.StylePriority.UseTextAlignment = false;
		lblBox.Text = "Box";
		lblBox.TextAlignment = TextAlignment.MiddleRight;
		lblBox.WordWrap = false;
		lblLocation.BackColor = Color.Transparent;
		lblLocation.CanGrow = false;
		lblLocation.Font = new DXFont("Microsoft Sans Serif", 10f);
		lblLocation.LocationFloat = new PointFloat(0f, 54.00001f);
		lblLocation.Name = "lblLocation";
		lblLocation.Padding = new PaddingInfo(0, 2, 0, 0, 100f);
		lblLocation.SizeF = new SizeF(239f, 20.99999f);
		lblLocation.StyleName = "DataField";
		lblLocation.StylePriority.UseBackColor = false;
		lblLocation.StylePriority.UseFont = false;
		lblLocation.StylePriority.UsePadding = false;
		lblLocation.StylePriority.UseTextAlignment = false;
		lblLocation.Text = "Location";
		lblLocation.TextAlignment = TextAlignment.MiddleRight;
		lblLocation.WordWrap = false;
		xrPictureBox1.BackColor = Color.Transparent;
		xrPictureBox1.LocationFloat = new PointFloat(243.25f, 30.00001f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(49.49998f, 44.99999f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StyleName = "DataField";
		xrPictureBox1.StylePriority.UseBackColor = false;
		lblTelephone.BackColor = Color.Transparent;
		lblTelephone.CanGrow = false;
		lblTelephone.Font = new DXFont("Microsoft Sans Serif", 10f);
		lblTelephone.LocationFloat = new PointFloat(296f, 30.00001f);
		lblTelephone.Name = "lblTelephone";
		lblTelephone.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		lblTelephone.SizeF = new SizeF(240f, 21f);
		lblTelephone.StyleName = "DataField";
		lblTelephone.StylePriority.UseBackColor = false;
		lblTelephone.StylePriority.UseFont = false;
		lblTelephone.StylePriority.UsePadding = false;
		lblTelephone.StylePriority.UseTextAlignment = false;
		lblTelephone.Text = "Telephone";
		lblTelephone.TextAlignment = TextAlignment.MiddleLeft;
		lblTelephone.WordWrap = false;
		lblMotto.BackColor = Color.Transparent;
		lblMotto.CanGrow = false;
		lblMotto.Font = new DXFont("Microsoft Sans Serif", 10f);
		lblMotto.LocationFloat = new PointFloat(296f, 54.00001f);
		lblMotto.Name = "lblMotto";
		lblMotto.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		lblMotto.SizeF = new SizeF(240f, 21f);
		lblMotto.StyleName = "DataField";
		lblMotto.StylePriority.UseBackColor = false;
		lblMotto.StylePriority.UseFont = false;
		lblMotto.StylePriority.UsePadding = false;
		lblMotto.StylePriority.UseTextAlignment = false;
		lblMotto.Text = "Motto";
		lblMotto.TextAlignment = TextAlignment.MiddleLeft;
		lblMotto.WordWrap = false;
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
		base.SnapGridSize = 0.5f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "17.2";
		BeforePrint += SchoolHeader_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
