using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace I_Xtreme.AccountingDocuments;

public class PaymentVoucher : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell3;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell10;

	private GroupFooterBand GroupFooter1;

	public PaymentVoucher()
	{
		InitializeComponent();
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
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		GroupFooter1 = new GroupFooterBand();
		xrTable2 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 23f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 23f;
		BottomMargin.Name = "BottomMargin";
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 405.0416f;
		Detail.Name = "Detail";
		xrTable1.Borders = BorderSide.All;
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(781f, 395.0416f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[5] { xrTableCell1, xrTableCell2, xrTableCell4, xrTableCell5, xrTableCell3 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Multiline = true;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.Weight = 0.2597631241997439;
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Text = "xrTableCell2";
		xrTableCell2.Weight = 2.5471618886793777;
		xrTableCell3.Multiline = true;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.Text = "xrTableCell3";
		xrTableCell3.Weight = 1.1800576184379001;
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Text = "xrTableCell4";
		xrTableCell4.Weight = 0.2797690378108494;
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.Text = "xrTableCell5";
		xrTableCell5.Weight = 0.7332483308721292;
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrTable2 });
		GroupHeader1.HeightF = 25f;
		GroupHeader1.Name = "GroupHeader1";
		GroupFooter1.Name = "GroupFooter1";
		xrTable2.Borders = BorderSide.All;
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(781f, 25f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow2.Cells.AddRange(new XRTableCell[5] { xrTableCell6, xrTableCell7, xrTableCell8, xrTableCell9, xrTableCell10 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell6.Multiline = true;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "xrTableCell1";
		xrTableCell6.Weight = 0.2597631241997439;
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.Text = "xrTableCell2";
		xrTableCell7.Weight = 2.5471618886793777;
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Text = "xrTableCell4";
		xrTableCell8.Weight = 0.27976864706080945;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Text = "xrTableCell5";
		xrTableCell9.Weight = 0.733248330872129;
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "xrTableCell3";
		xrTableCell10.Weight = 1.1800580091879402;
		base.Bands.AddRange(new Band[5] { TopMargin, BottomMargin, Detail, GroupHeader1, GroupFooter1 });
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(23f, 23f, 23f, 23f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.Version = "21.2";
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
