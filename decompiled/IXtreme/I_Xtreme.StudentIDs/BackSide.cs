using System.ComponentModel;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace I_Xtreme.StudentIDs;

public class BackSide : XtraReport
{
	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel lblFullContact;

	private XRLabel lblName;

	private XRLabel lblLocation;

	private XRLabel lblNetAddress;

	private XRLabel xrLabel1;

	private XRPanel xrPanel1;

	private XRLabel lblMotto;

	public DetailBand Detail1;

	public BackSide()
	{
		InitializeComponent();
	}

	private void BackSide_BeforePrint(object sender, CancelEventArgs e)
	{
		lblName.Text = ReportHeader.SchoolName;
		lblLocation.Text = ReportHeader.SchoolLocation;
		lblFullContact.Text = ReportHeader.SchoolFullAddress;
		lblNetAddress.Text = ReportHeader.SchoolNetAddress;
		lblMotto.Text = ReportHeader.SchoolMotto;
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
		lblFullContact = new XRLabel();
		lblName = new XRLabel();
		lblLocation = new XRLabel();
		lblNetAddress = new XRLabel();
		xrLabel1 = new XRLabel();
		xrPanel1 = new XRPanel();
		lblMotto = new XRLabel();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[6] { lblFullContact, lblName, lblLocation, lblNetAddress, xrLabel1, xrPanel1 });
		Detail1.HeightF = 216f;
		Detail1.MultiColumn.ColumnSpacing = 100f;
		Detail1.MultiColumn.ColumnWidth = 339f;
		Detail1.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail1.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail1.Name = "Detail1";
		Detail1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.TextAlignment = TextAlignment.TopLeft;
		lblFullContact.BackColor = Color.Transparent;
		lblFullContact.CanShrink = true;
		lblFullContact.Font = new DXFont("Tahoma", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblFullContact.LocationFloat = new PointFloat(0f, 140f);
		lblFullContact.Multiline = true;
		lblFullContact.Name = "lblFullContact";
		lblFullContact.SizeF = new SizeF(338f, 18f);
		lblFullContact.StylePriority.UseBackColor = false;
		lblFullContact.StylePriority.UseFont = false;
		lblFullContact.StylePriority.UseTextAlignment = false;
		lblFullContact.Text = "P.O.Box 1488 Kampala";
		lblFullContact.TextAlignment = TextAlignment.MiddleCenter;
		lblName.BackColor = Color.Black;
		lblName.CanShrink = true;
		lblName.Font = new DXFont("Tahoma", 11.25f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblName.ForeColor = Color.White;
		lblName.LocationFloat = new PointFloat(0f, 41f);
		lblName.Multiline = true;
		lblName.Name = "lblName";
		lblName.SizeF = new SizeF(338f, 28f);
		lblName.StylePriority.UseBackColor = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UseForeColor = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "INTELLIGENT WORKS";
		lblName.TextAlignment = TextAlignment.MiddleCenter;
		lblLocation.BackColor = Color.Transparent;
		lblLocation.Font = new DXFont("Tahoma", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblLocation.LocationFloat = new PointFloat(0f, 92.00001f);
		lblLocation.Name = "lblLocation";
		lblLocation.SizeF = new SizeF(338f, 18f);
		lblLocation.StylePriority.UseBackColor = false;
		lblLocation.StylePriority.UseFont = false;
		lblLocation.StylePriority.UseTextAlignment = false;
		lblLocation.Text = "Kampala Mengo";
		lblLocation.TextAlignment = TextAlignment.TopCenter;
		lblNetAddress.BackColor = Color.Transparent;
		lblNetAddress.CanShrink = true;
		lblNetAddress.Font = new DXFont("Tahoma", 8.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblNetAddress.LocationFloat = new PointFloat(0f, 110f);
		lblNetAddress.Multiline = true;
		lblNetAddress.Name = "lblNetAddress";
		lblNetAddress.SizeF = new SizeF(338f, 30f);
		lblNetAddress.StylePriority.UseBackColor = false;
		lblNetAddress.StylePriority.UseFont = false;
		lblNetAddress.StylePriority.UseTextAlignment = false;
		lblNetAddress.Text = "www.intelligentworks.co.ug, Email:admin@intelligentworks.co.ug";
		lblNetAddress.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.BackColor = Color.Transparent;
		xrLabel1.Font = new DXFont("Tahoma", 10f);
		xrLabel1.LocationFloat = new PointFloat(0f, 18f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(338f, 23f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "This card is property of";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrPanel1.BorderColor = Color.Silver;
		xrPanel1.Borders = BorderSide.All;
		xrPanel1.Controls.AddRange(new XRControl[1] { lblMotto });
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(339f, 216f);
		xrPanel1.StylePriority.UseBorderColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		lblMotto.BackColor = Color.Black;
		lblMotto.Borders = BorderSide.None;
		lblMotto.Font = new DXFont("Times New Roman", 9f, DXFontStyle.Bold | DXFontStyle.Italic, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblMotto.ForeColor = Color.White;
		lblMotto.LocationFloat = new PointFloat(0f, 193f);
		lblMotto.Name = "lblMotto";
		lblMotto.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		lblMotto.SizeF = new SizeF(339f, 23f);
		lblMotto.StylePriority.UseBackColor = false;
		lblMotto.StylePriority.UseBorders = false;
		lblMotto.StylePriority.UseFont = false;
		lblMotto.StylePriority.UseForeColor = false;
		lblMotto.StylePriority.UsePadding = false;
		lblMotto.StylePriority.UseTextAlignment = false;
		lblMotto.Text = "If found please return it to the above address";
		lblMotto.TextAlignment = TextAlignment.MiddleCenter;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		base.DesignerOptions.ShowPrintingWarnings = false;
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 216;
		base.PageWidth = 339;
		base.PaperKind = DXPaperKind.Custom;
		base.ReportPrintOptions.DetailCount = 1;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.Version = "13.1";
		base.Watermark.ImageTiling = true;
		BeforePrint += BackSide_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
