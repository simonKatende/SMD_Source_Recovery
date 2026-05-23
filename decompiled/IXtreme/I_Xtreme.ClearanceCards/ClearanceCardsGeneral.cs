using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.ClearanceCards.KTBFeesCardsTableAdapters;
using I_Xtreme.DataSet_Previews.StudentPreviewSourceTableAdapters;

namespace I_Xtreme.ClearanceCards;

public class ClearanceCardsGeneral : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRPanel panel1;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private StudentPreviewSourceTableAdapter studentPreviewSourceTableAdapter;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLabel xrLabel3;

	private KTBFeesCards ktbFeesCards1;

	private tbl_StudTableAdapter tbl_StudTableAdapter;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel8;

	private XRLabel xrLabel11;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRPictureBox xrPictureBox1;

	public ClearanceCardsGeneral()
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
		Detail = new DetailBand();
		panel1 = new XRPanel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		ktbFeesCards1 = new KTBFeesCards();
		tbl_StudTableAdapter = new tbl_StudTableAdapter();
		xrPictureBox1 = new XRPictureBox();
		xrLabel9 = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel11 = new XRLabel();
		((ISupportInitialize)ktbFeesCards1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { panel1 });
		Detail.Dpi = 254f;
		Detail.FillEmptySpace = true;
		Detail.HeightF = 729f;
		Detail.HierarchyPrintOptions.Indent = 50.8f;
		Detail.MultiColumn.ColumnCount = 2;
		Detail.MultiColumn.ColumnSpacing = 15f;
		Detail.MultiColumn.ColumnWidth = 1026f;
		Detail.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail.MultiColumn.Mode = MultiColumnMode.UseColumnWidth;
		Detail.Name = "Detail";
		panel1.Borders = BorderSide.All;
		panel1.CanGrow = false;
		panel1.Controls.AddRange(new XRControl[12]
		{
			xrLabel11, xrLabel10, xrLabel9, xrPictureBox1, xrLabel8, xrLabel7, xrLabel6, xrLabel5, xrLabel4, xrLabel3,
			xrLabel2, xrLabel1
		});
		panel1.Dpi = 254f;
		panel1.LocationFloat = new PointFloat(4f, 15f);
		panel1.Name = "panel1";
		panel1.SizeF = new SizeF(1022f, 711f);
		xrLabel8.BackColor = Color.Maroon;
		xrLabel8.BorderColor = Color.Maroon;
		xrLabel8.Borders = BorderSide.None;
		xrLabel8.Dpi = 254f;
		xrLabel8.Font = new DXFont("Arial", 11f, DXFontStyle.Bold);
		xrLabel8.ForeColor = Color.Wheat;
		xrLabel8.LocationFloat = new PointFloat(310.4556f, 258.4133f);
		xrLabel8.Multiline = true;
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel8.SizeF = new SizeF(391.9583f, 58.41998f);
		xrLabel8.StylePriority.UseBackColor = false;
		xrLabel8.StylePriority.UseBorderColor = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseForeColor = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "Examination Card";
		xrLabel8.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = BorderSide.Top;
		xrLabel7.Dpi = 254f;
		xrLabel7.LocationFloat = new PointFloat(138.0001f, 632.9999f);
		xrLabel7.Multiline = true;
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel7.SizeF = new SizeF(809.9999f, 58.41998f);
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "Signature & Stamp";
		xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel6.Borders = BorderSide.None;
		xrLabel6.Dpi = 254f;
		xrLabel6.Font = new DXFont("Arial", 11f);
		xrLabel6.LocationFloat = new PointFloat(414f, 465f);
		xrLabel6.Multiline = true;
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel6.SizeF = new SizeF(146f, 58.42001f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Stream:";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel5.Borders = BorderSide.None;
		xrLabel5.Dpi = 254f;
		xrLabel5.Font = new DXFont("Arial", 11f);
		xrLabel5.LocationFloat = new PointFloat(24.00001f, 465f);
		xrLabel5.Multiline = true;
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel5.SizeF = new SizeF(129f, 58.42001f);
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Class:";
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.Dpi = 254f;
		xrLabel4.Font = new DXFont("Arial", 11f);
		xrLabel4.LocationFloat = new PointFloat(24.00001f, 338f);
		xrLabel4.Multiline = true;
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel4.SizeF = new SizeF(302f, 58.41998f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Student's Name:";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel3.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel3.Borders = BorderSide.Bottom;
		xrLabel3.Dpi = 254f;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrLabel3.Font = new DXFont("Arial", 11f, DXFontStyle.Bold);
		xrLabel3.LocationFloat = new PointFloat(564f, 465.42f);
		xrLabel3.Multiline = true;
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel3.SizeF = new SizeF(442.0001f, 58.00003f);
		xrLabel3.StylePriority.UseBorderDashStyle = false;
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "xrLabel3";
		xrLabel3.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel2.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel2.Borders = BorderSide.Bottom;
		xrLabel2.Dpi = 254f;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel2.Font = new DXFont("Arial", 11f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(154f, 465.42f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel2.SizeF = new SizeF(254f, 58f);
		xrLabel2.StylePriority.UseBorderDashStyle = false;
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel1.Borders = BorderSide.Bottom;
		xrLabel1.Dpi = 254f;
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel1.Font = new DXFont("Arial", 11f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(24.00001f, 396.9999f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(5, 5, 0, 0, 254f);
		xrLabel1.SizeF = new SizeF(982.0001f, 58f);
		xrLabel1.StylePriority.UseBorderDashStyle = false;
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel1";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		TopMargin.Dpi = 254f;
		TopMargin.HeightF = 23f;
		TopMargin.Name = "TopMargin";
		BottomMargin.Dpi = 254f;
		BottomMargin.HeightF = 23f;
		BottomMargin.Name = "BottomMargin";
		ktbFeesCards1.DataSetName = "KTBFeesCards";
		ktbFeesCards1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		tbl_StudTableAdapter.ClearBeforeFill = true;
		xrPictureBox1.Dpi = 254f;
		xrPictureBox1.LocationFloat = new PointFloat(21.99992f, 23f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(208.0001f, 210f);
		xrPictureBox1.Sizing = ImageSizeMode.ZoomImage;
		xrLabel9.Dpi = 254f;
		xrLabel9.LocationFloat = new PointFloat(265.0001f, 24.99998f);
		xrLabel9.Multiline = true;
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrLabel9.SizeF = new SizeF(684.0001f, 58.42f);
		xrLabel9.Text = "xrLabel9";
		xrLabel10.Dpi = 254f;
		xrLabel10.LocationFloat = new PointFloat(265.0001f, 86.00002f);
		xrLabel10.Multiline = true;
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrLabel10.SizeF = new SizeF(684.0001f, 58.41999f);
		xrLabel10.Text = "xrLabel10";
		xrLabel11.Dpi = 254f;
		xrLabel11.LocationFloat = new PointFloat(265.0001f, 148f);
		xrLabel11.Multiline = true;
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrLabel11.SizeF = new SizeF(684.0001f, 58.42f);
		xrLabel11.Text = "xrLabel11";
		base.Bands.AddRange(new Band[3] { Detail, TopMargin, BottomMargin });
		base.ComponentStorage.AddRange(new IComponent[1] { ktbFeesCards1 });
		base.DataAdapter = tbl_StudTableAdapter;
		base.DataMember = "tbl_Stud";
		base.DataSource = ktbFeesCards1;
		Dpi = 254f;
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(10f, 10f, 23f, 23f);
		base.PageHeight = 2970;
		base.PageWidth = 2100;
		base.PaperKind = DXPaperKind.A4;
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 8;
		base.ReportUnit = ReportUnit.TenthsOfAMillimeter;
		base.SnapGridSize = 1f;
		base.SnapGridStepCount = 1;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "22.2";
		((ISupportInitialize)ktbFeesCards1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
