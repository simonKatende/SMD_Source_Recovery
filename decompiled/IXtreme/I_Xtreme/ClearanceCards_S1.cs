using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.DataSet_Previews;
using I_Xtreme.DataSet_Previews.StudentPreviewClearingCardTableAdapters;

namespace I_Xtreme;

public class ClearanceCards_S1 : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRPanel xrPanel1;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel10;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLabel xrLabel11;

	private XRLabel xrLabel9;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	private XRPictureBox xrPictureBox2;

	private XRLabel xrLabel3;

	private XRLabel xrLabel6;

	public Parameter feesBalance;

	public Parameter stream;

	private XRLabel lblAddress;

	private XRLabel lblSchoolName;

	public Parameter studentClass;

	private StudentPreviewClearingCard studentPreviewClearingCard1;

	private StudentClearanceSourceTableAdapter studentClearanceSourceTableAdapter;

	public ClearanceCards_S1()
	{
		InitializeComponent();
	}

	private void ClearanceCards_S1_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.Text = ReportHeader.SchoolName;
		lblAddress.Text = ReportHeader.SchoolFullAddress;
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
		xrPanel1 = new XRPanel();
		lblAddress = new XRLabel();
		lblSchoolName = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrPictureBox2 = new XRPictureBox();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		feesBalance = new Parameter();
		stream = new Parameter();
		studentClass = new Parameter();
		studentPreviewClearingCard1 = new StudentPreviewClearingCard();
		studentClearanceSourceTableAdapter = new StudentClearanceSourceTableAdapter();
		((ISupportInitialize)studentPreviewClearingCard1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrPanel1 });
		Detail.HeightF = 277.8772f;
		Detail.MultiColumn.ColumnCount = 2;
		Detail.MultiColumn.ColumnSpacing = 25f;
		Detail.MultiColumn.ColumnWidth = 390f;
		Detail.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail.MultiColumn.Mode = MultiColumnMode.UseColumnWidth;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrPanel1.Borders = BorderSide.All;
		xrPanel1.CanGrow = false;
		xrPanel1.Controls.AddRange(new XRControl[14]
		{
			lblAddress, lblSchoolName, xrLabel3, xrLabel6, xrLabel9, xrLabel8, xrLabel7, xrLabel11, xrLabel10, xrLabel5,
			xrLabel4, xrLabel2, xrLabel1, xrPictureBox2
		});
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(390f, 235f);
		lblAddress.Borders = BorderSide.None;
		lblAddress.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblAddress.LocationFloat = new PointFloat(3.999996f, 28.99998f);
		lblAddress.Name = "lblAddress";
		lblAddress.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblAddress.SizeF = new SizeF(381f, 23f);
		lblAddress.StylePriority.UseBorders = false;
		lblAddress.StylePriority.UseFont = false;
		lblAddress.StylePriority.UseTextAlignment = false;
		lblAddress.Text = "lblAddress";
		lblAddress.TextAlignment = TextAlignment.TopCenter;
		lblSchoolName.Borders = BorderSide.None;
		lblSchoolName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold);
		lblSchoolName.LocationFloat = new PointFloat(3.999996f, 5.999979f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(381f, 23f);
		lblSchoolName.StylePriority.UseBorders = false;
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.Text = "lblSchoolName";
		lblSchoolName.TextAlignment = TextAlignment.TopCenter;
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.Font = new DXFont("Tahoma", 9f);
		xrLabel3.LocationFloat = new PointFloat(3.999996f, 137f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(72.9167f, 23f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "Class:";
		xrLabel3.TextAlignment = TextAlignment.BottomLeft;
		xrLabel6.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel6.Borders = BorderSide.Bottom;
		xrLabel6.CanGrow = false;
		xrLabel6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel6.Font = new DXFont("Tahoma", 9f);
		xrLabel6.LocationFloat = new PointFloat(76.91669f, 137f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(193.5833f, 23.00002f);
		xrLabel6.StylePriority.UseBorderDashStyle = false;
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "xrLabel6";
		xrLabel6.TextAlignment = TextAlignment.BottomLeft;
		xrLabel6.TextFormatString = "[ClassId], [StreamId]";
		xrLabel6.WordWrap = false;
		xrLabel9.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel9.Borders = BorderSide.Bottom;
		xrLabel9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[cashOnAccount]")
		});
		xrLabel9.Font = new DXFont("Tahoma", 10f);
		xrLabel9.LocationFloat = new PointFloat(76.91669f, 163f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(193.5833f, 23f);
		xrLabel9.StylePriority.UseBorderDashStyle = false;
		xrLabel9.StylePriority.UseBorders = false;
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "xrLabel9";
		xrLabel9.TextAlignment = TextAlignment.BottomLeft;
		xrLabel9.TextFormatString = "{0:#,#.0}";
		xrLabel8.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel8.Borders = BorderSide.Bottom;
		xrLabel8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentID]")
		});
		xrLabel8.Font = new DXFont("Tahoma", 10f);
		xrLabel8.LocationFloat = new PointFloat(76.91669f, 112f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(193.5833f, 23.00001f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "xrLabel8";
		xrLabel8.TextAlignment = TextAlignment.BottomLeft;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = BorderSide.Bottom;
		xrLabel7.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel7.Font = new DXFont("Tahoma", 10f);
		xrLabel7.LocationFloat = new PointFloat(76.91669f, 86f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(193.5833f, 23f);
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "xrLabel7";
		xrLabel7.TextAlignment = TextAlignment.BottomLeft;
		xrLabel11.BackColor = Color.Black;
		xrLabel11.Borders = BorderSide.None;
		xrLabel11.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrLabel11.ForeColor = Color.White;
		xrLabel11.LocationFloat = new PointFloat(3.999996f, 56f);
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(381f, 24.00001f);
		xrLabel11.StylePriority.UseBackColor = false;
		xrLabel11.StylePriority.UseBorders = false;
		xrLabel11.StylePriority.UseFont = false;
		xrLabel11.StylePriority.UseForeColor = false;
		xrLabel11.StylePriority.UseTextAlignment = false;
		xrLabel11.Text = "FEES CLEARANCE CARD";
		xrLabel11.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel10.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel10.Borders = BorderSide.Bottom;
		xrLabel10.Font = new DXFont("Tahoma", 9f);
		xrLabel10.LocationFloat = new PointFloat(76.91669f, 190f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(193.5833f, 23.00005f);
		xrLabel10.StylePriority.UseBorderDashStyle = false;
		xrLabel10.StylePriority.UseBorders = false;
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.TextAlignment = TextAlignment.BottomLeft;
		xrLabel5.Borders = BorderSide.None;
		xrLabel5.Font = new DXFont("Tahoma", 9f);
		xrLabel5.LocationFloat = new PointFloat(3.999996f, 190f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(72.9167f, 23f);
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Valid Until:";
		xrLabel5.TextAlignment = TextAlignment.BottomLeft;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.Font = new DXFont("Tahoma", 9f);
		xrLabel4.LocationFloat = new PointFloat(3.999996f, 163f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(72.9167f, 23f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Balance:";
		xrLabel4.TextAlignment = TextAlignment.BottomLeft;
		xrLabel2.Borders = BorderSide.None;
		xrLabel2.Font = new DXFont("Tahoma", 9f);
		xrLabel2.LocationFloat = new PointFloat(3.999996f, 112f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(72.9167f, 23.00001f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "Student No:";
		xrLabel2.TextAlignment = TextAlignment.BottomLeft;
		xrLabel1.Borders = BorderSide.None;
		xrLabel1.Font = new DXFont("Tahoma", 9f);
		xrLabel1.LocationFloat = new PointFloat(3.999996f, 86f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(72.9167f, 23f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Name:";
		xrLabel1.TextAlignment = TextAlignment.BottomLeft;
		xrPictureBox2.Borders = BorderSide.None;
		xrPictureBox2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox2.LocationFloat = new PointFloat(270.5f, 86f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.SizeF = new SizeF(114.5f, 127f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox2.StylePriority.UseBorders = false;
		topMarginBand1.HeightF = 30f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 10f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		feesBalance.Description = "Fees balance (<=)";
		feesBalance.Name = "feesBalance";
		feesBalance.Type = typeof(decimal);
		feesBalance.ValueInfo = "0";
		feesBalance.Visible = false;
		stream.Description = "Stream";
		stream.Name = "stream";
		stream.Visible = false;
		studentClass.Description = "Student Class";
		studentClass.Name = "studentClass";
		studentClass.Visible = false;
		studentPreviewClearingCard1.DataSetName = "StudentPreviewClearingCard";
		studentPreviewClearingCard1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		studentClearanceSourceTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		base.ComponentStorage.AddRange(new IComponent[1] { studentPreviewClearingCard1 });
		base.DataAdapter = studentClearanceSourceTableAdapter;
		base.DataMember = "StudentClearanceSource";
		base.DataSource = studentPreviewClearingCard1;
		base.DesignerOptions.ShowPrintingWarnings = false;
		base.Margins = new DXMargins(10f, 10f, 30f, 10f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.Parameters.AddRange(new Parameter[3] { stream, feesBalance, studentClass });
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 10;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "23.2";
		BeforePrint += ClearanceCards_S1_BeforePrint;
		((ISupportInitialize)studentPreviewClearingCard1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
