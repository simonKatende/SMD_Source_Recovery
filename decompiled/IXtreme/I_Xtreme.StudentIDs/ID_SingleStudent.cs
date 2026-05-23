using System.ComponentModel;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.dSetStudentIdsTableAdapters;

namespace I_Xtreme.StudentIDs;

public class ID_SingleStudent : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRPanel xrPanel1;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel2;

	private XRLabel xrLabel6;

	private XRLabel xrLabel7;

	private XRLabel xrLabel5;

	private XRLabel xrLabel1;

	private XRLabel xrLabel13;

	private XRLabel xrLabel15;

	private XRLabel xrLabel14;

	private XRPictureBox xrPictureBox1;

	private XRLabel xrLabel16;

	private XRLabel xrLabel17;

	private XRLabel xrLabel12;

	private XRSubreport xrSubreport1;

	private XRBarCode xrBarCode1;

	private XRLine xrLine3;

	private XRLine xrLine2;

	private XRLine xrLine1;

	private XRPanel xrPanel2;

	private XRControlStyle xrControlStyle1;

	private XRSubreport xrSubreport2;

	private XRLabel xrLabel3;

	private XRLabel xrLabel4;

	private studentsTableAdapter studentsTableAdapter;

	public Parameter Id_No;

	private XRPictureBox xrPictureBox2;

	public ID_SingleStudent()
	{
		InitializeComponent();
	}

	private void StudentPS_ParametersRequestValueChanged(object sender, ParametersRequestValueChangedEventArgs e)
	{
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
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ID_SingleStudent));
		Code39ExtendedGenerator code39ExtendedGenerator = new Code39ExtendedGenerator();
		Detail = new DetailBand();
		xrSubreport1 = new XRSubreport();
		xrPanel1 = new XRPanel();
		xrPictureBox2 = new XRPictureBox();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLine3 = new XRLine();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		xrBarCode1 = new XRBarCode();
		xrLabel2 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		xrLabel16 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrLabel12 = new XRLabel();
		xrPanel2 = new XRPanel();
		xrSubreport2 = new XRSubreport();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		Id_No = new Parameter();
		xrControlStyle1 = new XRControlStyle();
		studentsTableAdapter = new studentsTableAdapter();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[4] { xrSubreport1, xrPanel1, xrPanel2, xrSubreport2 });
		Detail.HeightF = 235f;
		Detail.MultiColumn.ColumnWidth = 390f;
		Detail.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrSubreport1.LocationFloat = new PointFloat(6.000021f, 5.000002f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.ReportSource = new SchoolDetails_Small();
		xrSubreport1.SizeF = new SizeF(379f, 41.75f);
		xrPanel1.Borders = BorderSide.All;
		xrPanel1.BorderWidth = 2f;
		xrPanel1.CanGrow = false;
		xrPanel1.Controls.AddRange(new XRControl[19]
		{
			xrPictureBox2, xrLabel4, xrLabel3, xrLine3, xrLine2, xrLine1, xrBarCode1, xrLabel2, xrLabel6, xrLabel7,
			xrLabel5, xrLabel1, xrLabel13, xrLabel15, xrLabel14, xrPictureBox1, xrLabel16, xrLabel17, xrLabel12
		});
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(390f, 235f);
		xrPanel1.StylePriority.UseBorderWidth = false;
		xrPictureBox2.Borders = BorderSide.None;
		xrPictureBox2.ImageSource = new ImageSource("img", componentResourceManager.GetString("xrPictureBox2.ImageSource"));
		xrPictureBox2.LocationFloat = new PointFloat(280f, 172.5f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.SizeF = new SizeF(100f, 17.50005f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox2.StylePriority.UseBorders = false;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.ForeColor = Color.Maroon;
		xrLabel4.LocationFloat = new PointFloat(113.5f, 128f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(63.49999f, 20.99997f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseForeColor = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "ID No";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[view_Ids.idAuto]")
		});
		xrLabel3.ForeColor = Color.Red;
		xrLabel3.LocationFloat = new PointFloat(177f, 126.5f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(100f, 23f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseForeColor = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "xrLabel3";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		xrLine3.BorderWidth = 0f;
		xrLine3.ForeColor = Color.Maroon;
		xrLine3.LineWidth = 8f;
		xrLine3.LocationFloat = new PointFloat(6.000002f, 221f);
		xrLine3.Name = "xrLine3";
		xrLine3.SizeF = new SizeF(379f, 8.333333f);
		xrLine3.StylePriority.UseBorderWidth = false;
		xrLine3.StylePriority.UseForeColor = false;
		xrLine2.BorderWidth = 0f;
		xrLine2.ForeColor = Color.PaleGoldenrod;
		xrLine2.LineWidth = 8f;
		xrLine2.LocationFloat = new PointFloat(6.000002f, 213f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(379f, 8.333333f);
		xrLine2.StylePriority.UseBorderWidth = false;
		xrLine2.StylePriority.UseForeColor = false;
		xrLine1.BorderWidth = 0f;
		xrLine1.LineWidth = 8f;
		xrLine1.LocationFloat = new PointFloat(5.000031f, 205f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(380f, 8.333333f);
		xrLine1.StylePriority.UseBorderWidth = false;
		xrBarCode1.AutoModule = true;
		xrBarCode1.Borders = BorderSide.None;
		xrBarCode1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[view_Ids.idAuto]")
		});
		xrBarCode1.Font = new DXFont("Tahoma", 7f);
		xrBarCode1.LocationFloat = new PointFloat(7.000001f, 179f);
		xrBarCode1.Module = 1f;
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(10, 10, 0, 0, 100f);
		xrBarCode1.ShowText = false;
		xrBarCode1.SizeF = new SizeF(93.03999f, 23.04156f);
		xrBarCode1.StylePriority.UseBorders = false;
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		code39ExtendedGenerator.WideNarrowRatio = 3f;
		xrBarCode1.Symbology = code39ExtendedGenerator;
		xrBarCode1.Text = "xrBarCode1";
		xrBarCode1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel2.Borders = BorderSide.None;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[view_Ids.StudentNumber]")
		});
		xrLabel2.Font = new DXFont("Tahoma", 10f);
		xrLabel2.LocationFloat = new PointFloat(175.4166f, 103.125f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(208.5833f, 23.00002f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.Borders = BorderSide.None;
		xrLabel6.Font = new DXFont("Tahoma", 10f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.ForeColor = Color.Maroon;
		xrLabel6.LocationFloat = new PointFloat(113.4583f, 80.125f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(61.95826f, 23f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Name:";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel7.Borders = BorderSide.None;
		xrLabel7.Font = new DXFont("Tahoma", 10f);
		xrLabel7.ForeColor = Color.Maroon;
		xrLabel7.LocationFloat = new PointFloat(113.4583f, 103.125f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(61.95827f, 23f);
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseForeColor = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "Stud No:";
		xrLabel7.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel5.BackColor = Color.Maroon;
		xrLabel5.Borders = BorderSide.None;
		xrLabel5.Font = new DXFont("Tahoma", 11f, DXFontStyle.Bold);
		xrLabel5.ForeColor = Color.White;
		xrLabel5.LocationFloat = new PointFloat(151f, 54f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(108f, 20.91668f);
		xrLabel5.StylePriority.UseBackColor = false;
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseForeColor = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Student ID";
		xrLabel5.TextAlignment = TextAlignment.TopCenter;
		xrLabel1.BorderColor = Color.Gainsboro;
		xrLabel1.Borders = BorderSide.None;
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[view_Ids.fullName]")
		});
		xrLabel1.Font = new DXFont("Tahoma", 10f);
		xrLabel1.LocationFloat = new PointFloat(175.4167f, 80.12498f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(208.5832f, 23.00002f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseBorderColor = false;
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel1";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel13.BorderColor = SystemColors.AppWorkspace;
		xrLabel13.Borders = BorderSide.Top;
		xrLabel13.Font = new DXFont("Times New Roman", 7f, DXFontStyle.Italic, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel13.LocationFloat = new PointFloat(282.4172f, 190f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(101.5827f, 14.49994f);
		xrLabel13.StylePriority.UseBorderColor = false;
		xrLabel13.StylePriority.UseBorders = false;
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Issuing Sign & Stamp";
		xrLabel13.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel15.Borders = BorderSide.None;
		xrLabel15.Font = new DXFont("Tahoma", 7f);
		xrLabel15.ForeColor = Color.Maroon;
		xrLabel15.LocationFloat = new PointFloat(250f, 149.5f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(39.54169f, 22.99998f);
		xrLabel15.StylePriority.UseBorders = false;
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseForeColor = false;
		xrLabel15.StylePriority.UsePadding = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Validity:";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel14.Borders = BorderSide.None;
		xrLabel14.Font = new DXFont("Tahoma", 7f);
		xrLabel14.ForeColor = Color.Maroon;
		xrLabel14.LocationFloat = new PointFloat(112.4584f, 149.5f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(38.54167f, 23.00002f);
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseForeColor = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.Text = "Issued:";
		xrLabel14.TextAlignment = TextAlignment.MiddleLeft;
		xrPictureBox1.Borders = BorderSide.None;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[view_Ids.Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(7.000001f, 78.00001f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(93.04f, 93.04157f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrLabel16.BorderColor = SystemColors.AppWorkspace;
		xrLabel16.Borders = BorderSide.None;
		xrLabel16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[view_Ids.IssueDate]")
		});
		xrLabel16.Font = new DXFont("Tahoma", 9.75f);
		xrLabel16.LocationFloat = new PointFloat(151f, 149.5f);
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(99f, 22.99989f);
		xrLabel16.StylePriority.UseBorderColor = false;
		xrLabel16.StylePriority.UseBorders = false;
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.StylePriority.UseTextAlignment = false;
		xrLabel16.Text = "xrLabel16";
		xrLabel16.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel16.TextFormatString = "{0:MMM-yyyy}";
		xrLabel17.BorderColor = SystemColors.AppWorkspace;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[view_Ids.Validity]")
		});
		xrLabel17.Font = new DXFont("Tahoma", 9.75f);
		xrLabel17.LocationFloat = new PointFloat(289.5417f, 149.5f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(94.45831f, 22.99998f);
		xrLabel17.StylePriority.UseBorderColor = false;
		xrLabel17.StylePriority.UseBorders = false;
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "xrLabel17";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.TextFormatString = "{0:MMM-yyyy}";
		xrLabel12.BorderColor = SystemColors.AppWorkspace;
		xrLabel12.Borders = BorderSide.Top;
		xrLabel12.Font = new DXFont("Times New Roman", 7f, DXFontStyle.Italic, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel12.LocationFloat = new PointFloat(151f, 191f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(101.7084f, 13.50003f);
		xrLabel12.StylePriority.UseBorderColor = false;
		xrLabel12.StylePriority.UseBorders = false;
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Holder's signature";
		xrLabel12.TextAlignment = TextAlignment.MiddleCenter;
		xrPanel2.Borders = BorderSide.All;
		xrPanel2.BorderWidth = 1f;
		xrPanel2.LocationFloat = new PointFloat(4.999987f, 3.999996f);
		xrPanel2.Name = "xrPanel2";
		xrPanel2.SizeF = new SizeF(381f, 226f);
		xrPanel2.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrPanel2.StylePriority.UseBorders = false;
		xrPanel2.StylePriority.UseBorderWidth = false;
		xrSubreport2.LocationFloat = new PointFloat(245.5f, 54f);
		xrSubreport2.Name = "xrSubreport2";
		xrSubreport2.SizeF = new SizeF(134.5f, 148.0415f);
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		Id_No.Description = "InNo";
		Id_No.Name = "Id_No";
		Id_No.Type = typeof(int);
		Id_No.ValueInfo = "0";
		xrControlStyle1.Name = "xrControlStyle1";
		xrControlStyle1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		studentsTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		FilterString = "[idAuto] = ?Id_No";
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[1] { Id_No });
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 4;
		base.SnapGridSize = 0.5f;
		base.StyleSheet.AddRange(new XRControlStyle[1] { xrControlStyle1 });
		base.Version = "21.2";
		base.ParametersRequestValueChanged += StudentPS_ParametersRequestValueChanged;
		((ISupportInitialize)this).EndInit();
	}
}
