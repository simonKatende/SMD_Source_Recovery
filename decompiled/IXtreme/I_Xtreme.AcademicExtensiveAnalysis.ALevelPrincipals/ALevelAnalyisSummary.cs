using System.ComponentModel;
using System.Drawing;
using AlienAge.Security;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using I_Xtreme.AcademicExtensiveAnalysis.ALevelSubsidiary;

namespace I_Xtreme.AcademicExtensiveAnalysis.ALevelPrincipals;

public class ALevelAnalyisSummary : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private XRSubreport xrSubreport1;

	private SubBand SubBand1;

	private XRSubreport xrSubreport2;

	private SubBand SubBand2;

	private XRSubreport xrSubreport3;

	private SubBand SubBand3;

	private XRSubreport xrSubreport4;

	private SubBand SubBand4;

	private GroupHeaderBand GroupHeader1;

	private ReportHeaderBand ReportHeader;

	private XRLabel lblSchoolName;

	private XRLabel xrLabel1;

	private PageFooterBand PageFooter;

	private XRPageInfo xrPageInfo1;

	private SubBand SubBand5;

	private XRSubreport xrSubreport5;

	public ALevelAnalyisSummary(string ClassEn, string StreamEn, string Term)
	{
		InitializeComponent();
		xrSubreport1.ReportSource = new SummaryPerPaper(ClassEn, StreamEn, Term);
		xrSubreport2.ReportSource = new SummaryPerSubject(ClassEn, StreamEn, Term);
		xrSubreport3.ReportSource = new AWP(ClassEn, StreamEn, Term);
		xrSubreport4.ReportSource = new PrincipalPassCount(ClassEn, StreamEn, Term);
		xrSubreport5.ReportSource = new SummaryPerPaperSub(ClassEn, StreamEn, Term);
		if (StreamEn.Equals("-Entire Class-") || string.IsNullOrEmpty(StreamEn))
		{
			xrLabel1.Text = "Subject performance analysis, " + ClassEn + "-" + Term;
			base.Name = "Performance Analysis_" + ClassEn.Replace('.', '_') + "_" + Term;
			return;
		}
		xrLabel1.Text = "Subject performance analysis, " + ClassEn + " (" + StreamEn + ")-" + Term;
		base.Name = "Performance Analysis_" + ClassEn.Replace('.', '_') + "_" + StreamEn.Replace('.', '_') + "_" + Term;
	}

	private void ALevelAnalyisSummary_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.Text = FingerPrint.SchoolName;
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
		XRWatermark xRWatermark = new XRWatermark();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		SubBand1 = new SubBand();
		xrSubreport1 = new XRSubreport();
		SubBand2 = new SubBand();
		xrSubreport2 = new XRSubreport();
		SubBand3 = new SubBand();
		xrSubreport3 = new XRSubreport();
		SubBand4 = new SubBand();
		xrSubreport4 = new XRSubreport();
		GroupHeader1 = new GroupHeaderBand();
		xrLabel1 = new XRLabel();
		ReportHeader = new ReportHeaderBand();
		lblSchoolName = new XRLabel();
		PageFooter = new PageFooterBand();
		xrPageInfo1 = new XRPageInfo();
		SubBand5 = new SubBand();
		xrSubreport5 = new XRSubreport();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 30f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 30f;
		BottomMargin.Name = "BottomMargin";
		Detail.HeightF = 0f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.SubBands.AddRange(new SubBand[5] { SubBand1, SubBand2, SubBand3, SubBand4, SubBand5 });
		SubBand1.Controls.AddRange(new XRControl[1] { xrSubreport1 });
		SubBand1.HeightF = 30f;
		SubBand1.Name = "SubBand1";
		xrSubreport1.LocationFloat = new PointFloat(9.536743E-05f, 0f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.SizeF = new SizeF(766.9999f, 23f);
		SubBand2.Controls.AddRange(new XRControl[1] { xrSubreport2 });
		SubBand2.HeightF = 30f;
		SubBand2.KeepTogether = true;
		SubBand2.Name = "SubBand2";
		xrSubreport2.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.SizeF = new SizeF(767f, 23f);
		SubBand3.Controls.AddRange(new XRControl[1] { xrSubreport3 });
		SubBand3.HeightF = 30f;
		SubBand3.KeepTogether = true;
		SubBand3.Name = "SubBand3";
		xrSubreport3.LocationFloat = new PointFloat(3.178914E-05f, 0f);
		xrSubreport3.Name = "xrSubreport3";
		xrSubreport3.SizeF = new SizeF(767f, 23f);
		SubBand4.Controls.AddRange(new XRControl[1] { xrSubreport4 });
		SubBand4.HeightF = 30f;
		SubBand4.KeepTogether = true;
		SubBand4.Name = "SubBand4";
		xrSubreport4.LocationFloat = new PointFloat(0f, 0f);
		xrSubreport4.Name = "xrSubreport4";
		xrSubreport4.SizeF = new SizeF(767f, 23f);
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrLabel1 });
		GroupHeader1.HeightF = 30f;
		GroupHeader1.Name = "GroupHeader1";
		xrLabel1.Font = new DXFont("Tahoma", 13f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(9.536743E-05f, 0f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(767f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		ReportHeader.Controls.AddRange(new XRControl[1] { lblSchoolName });
		ReportHeader.HeightF = 40f;
		ReportHeader.Name = "ReportHeader";
		lblSchoolName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblSchoolName.LocationFloat = new PointFloat(1.000122f, 0f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(766f, 27.31035f);
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.TextAlignment = TextAlignment.MiddleCenter;
		PageFooter.Controls.AddRange(new XRControl[1] { xrPageInfo1 });
		PageFooter.HeightF = 23f;
		PageFooter.Name = "PageFooter";
		xrPageInfo1.LocationFloat = new PointFloat(531.5833f, 0f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.SizeF = new SizeF(235.4167f, 23f);
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
		xrPageInfo1.TextFormatString = "Page {0} of {1}";
		SubBand5.Controls.AddRange(new XRControl[1] { xrSubreport5 });
		SubBand5.HeightF = 30f;
		SubBand5.Name = "SubBand5";
		xrSubreport5.LocationFloat = new PointFloat(0.0001220703f, 0f);
		xrSubreport5.Name = "xrSubreport5";
		xrSubreport5.SizeF = new SizeF(767f, 23f);
		base.Bands.AddRange(new Band[6] { TopMargin, BottomMargin, Detail, GroupHeader1, ReportHeader, PageFooter });
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(30f, 30f, 30f, 30f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.Version = "23.2";
		xRWatermark.Id = "Watermark1";
		base.Watermarks.AddRange(new Watermark[1] { xRWatermark });
		BeforePrint += ALevelAnalyisSummary_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
