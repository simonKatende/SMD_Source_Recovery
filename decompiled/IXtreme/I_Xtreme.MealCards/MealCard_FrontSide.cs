using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.MealCards.dsMealCardsTableAdapters;
using I_Xtreme.StudentID_Datasets.DataSet_S1TableAdapters;

namespace I_Xtreme.MealCards;

public class MealCard_FrontSide : XtraReport
{
	private ComboBoxEdit cboStreams;

	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	public DetailBand Detail1;

	private XRPanel xrPanel1;

	private XRLabel lblSchoolName;

	private XRLabel xrLabel7;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRBarCode xrBarCode1;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRPictureBox xrPictureBox1;

	private S_1ID_DataTable1TableAdapter s_1ID_DataTable1TableAdapter;

	private XRLabel lblBoxNumber;

	private dsMealCards dsMealCards1;

	private MealCardsTableAdapter mealCardsTableAdapter;

	public MealCard_FrontSide()
	{
		InitializeComponent();
	}

	private void BackSide_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchoolName.Text = ReportHeader.SchoolName;
		lblBoxNumber.Text = ReportHeader.SchoolFullAddress;
	}

	private void MealCard_FrontSide_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
	{
		ParameterInfo[] parametersInformation = e.ParametersInformation;
		foreach (ParameterInfo parameterInfo in parametersInformation)
		{
			if (parameterInfo.Parameter.Name == "StudentStream")
			{
				cboStreams = new ComboBoxEdit();
				Stream.LoadStreams("S.1", cboStreams);
				parameterInfo.Editor = cboStreams;
			}
		}
	}

	private void xrLabel5_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrLabel5.Text.ToString().Length > 16 && xrLabel5.Text.ToString().Length < 21)
		{
			xrLabel5.Font = new Font("Tahoma", 11f);
		}
		else if (xrLabel5.Text.ToString().Length <= 16)
		{
			xrLabel5.Font = new Font("Tahoma", 12f);
		}
		else if (xrLabel5.Text.ToString().Length >= 21)
		{
			xrLabel5.Font = new Font("Tahoma", 10f);
		}
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
		Code39ExtendedGenerator code39ExtendedGenerator = new Code39ExtendedGenerator();
		Detail1 = new DetailBand();
		xrPanel1 = new XRPanel();
		lblBoxNumber = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrBarCode1 = new XRBarCode();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		lblSchoolName = new XRLabel();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		s_1ID_DataTable1TableAdapter = new S_1ID_DataTable1TableAdapter();
		dsMealCards1 = new dsMealCards();
		mealCardsTableAdapter = new MealCardsTableAdapter();
		((ISupportInitialize)dsMealCards1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[1] { xrPanel1 });
		Detail1.Dpi = 100f;
		Detail1.HeightF = 220f;
		Detail1.KeepTogether = true;
		Detail1.KeepTogetherWithDetailReports = true;
		Detail1.MultiColumn.ColumnCount = 2;
		Detail1.MultiColumn.ColumnSpacing = 5f;
		Detail1.MultiColumn.ColumnWidth = 400f;
		Detail1.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail1.MultiColumn.Mode = MultiColumnMode.UseColumnWidth;
		Detail1.Name = "Detail1";
		Detail1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.TextAlignment = TextAlignment.TopLeft;
		xrPanel1.BackColor = Color.Transparent;
		xrPanel1.BorderColor = Color.DarkGray;
		xrPanel1.Borders = BorderSide.All;
		xrPanel1.BorderWidth = 1f;
		xrPanel1.Controls.AddRange(new XRControl[11]
		{
			lblBoxNumber, xrLabel7, xrLabel6, xrLabel5, xrBarCode1, xrLabel4, xrLabel3, xrLabel2, xrLabel1, xrPictureBox1,
			lblSchoolName
		});
		xrPanel1.Dpi = 100f;
		xrPanel1.LocationFloat = new PointFloat(5f, 7f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(389f, 207.2917f);
		xrPanel1.StylePriority.UseBackColor = false;
		xrPanel1.StylePriority.UseBorderColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		xrPanel1.StylePriority.UseBorderWidth = false;
		lblBoxNumber.Borders = BorderSide.None;
		lblBoxNumber.CanGrow = false;
		lblBoxNumber.Dpi = 100f;
		lblBoxNumber.Font = new DXFont("Tahoma", 8f);
		lblBoxNumber.LocationFloat = new PointFloat(7f, 30f);
		lblBoxNumber.Name = "lblBoxNumber";
		lblBoxNumber.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblBoxNumber.SizeF = new SizeF(375f, 16.99999f);
		lblBoxNumber.StylePriority.UseBorders = false;
		lblBoxNumber.StylePriority.UseFont = false;
		lblBoxNumber.StylePriority.UseTextAlignment = false;
		lblBoxNumber.Text = "School Address";
		lblBoxNumber.TextAlignment = TextAlignment.MiddleCenter;
		lblBoxNumber.WordWrap = false;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = BorderSide.Bottom;
		xrLabel7.BorderWidth = 1f;
		xrLabel7.CanGrow = false;
		xrLabel7.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "dtMealCards.StreamId")
		});
		xrLabel7.Dpi = 100f;
		xrLabel7.Font = new DXFont("Tahoma", 12f);
		xrLabel7.LocationFloat = new PointFloat(282.4583f, 168f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(99.54166f, 20.99997f);
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseBorderWidth = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel7.WordWrap = false;
		xrLabel6.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel6.Borders = BorderSide.Bottom;
		xrLabel6.BorderWidth = 1f;
		xrLabel6.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "dtMealCards.ClassId")
		});
		xrLabel6.Dpi = 100f;
		xrLabel6.Font = new DXFont("Tahoma", 12f);
		xrLabel6.LocationFloat = new PointFloat(155f, 168f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(99.54166f, 21f);
		xrLabel6.StylePriority.UseBorderDashStyle = false;
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseBorderWidth = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel5.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel5.Borders = BorderSide.Bottom;
		xrLabel5.BorderWidth = 1f;
		xrLabel5.CanGrow = false;
		xrLabel5.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "dtMealCards.fullName")
		});
		xrLabel5.Dpi = 100f;
		xrLabel5.Font = new DXFont("Tahoma", 11f);
		xrLabel5.LocationFloat = new PointFloat(155f, 101f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(227f, 20.99999f);
		xrLabel5.StylePriority.UseBorderDashStyle = false;
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseBorderWidth = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel5.WordWrap = false;
		xrLabel5.BeforePrint += xrLabel5_BeforePrint;
		xrBarCode1.AutoModule = true;
		xrBarCode1.BarCodeOrientation = BarCodeOrientation.RotateLeft;
		xrBarCode1.Borders = BorderSide.None;
		xrBarCode1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "dtMealCards.StudentNumber")
		});
		xrBarCode1.Dpi = 100f;
		xrBarCode1.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrBarCode1.LocationFloat = new PointFloat(7f, 77f);
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode1.SizeF = new SizeF(37f, 115f);
		xrBarCode1.StylePriority.UseBorders = false;
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UsePadding = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		code39ExtendedGenerator.WideNarrowRatio = 3f;
		xrBarCode1.Symbology = code39ExtendedGenerator;
		xrBarCode1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.Dpi = 100f;
		xrLabel4.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel4.LocationFloat = new PointFloat(155f, 146f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(99.54166f, 20.99998f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Class:";
		xrLabel4.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel3.Borders = BorderSide.None;
		xrLabel3.Dpi = 100f;
		xrLabel3.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel3.LocationFloat = new PointFloat(282.4584f, 146f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(99.54169f, 20.99998f);
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "Stream:";
		xrLabel3.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel2.Borders = BorderSide.None;
		xrLabel2.Dpi = 100f;
		xrLabel2.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel2.LocationFloat = new PointFloat(155f, 78.00001f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(57.70833f, 20.99999f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "Name:";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.BackColor = Color.Red;
		xrLabel1.Borders = BorderSide.None;
		xrLabel1.Dpi = 100f;
		xrLabel1.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel1.ForeColor = Color.White;
		xrLabel1.LocationFloat = new PointFloat(0f, 50f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(388.9999f, 20.99998f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "STUDENT'S MEAL CARD";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrPictureBox1.BorderColor = Color.Gray;
		xrPictureBox1.BorderWidth = 1f;
		xrPictureBox1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Image", null, "dtMealCards.Picture")
		});
		xrPictureBox1.Dpi = 100f;
		xrPictureBox1.LocationFloat = new PointFloat(44f, 78.00002f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(105f, 114f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorderWidth = false;
		lblSchoolName.Borders = BorderSide.None;
		lblSchoolName.CanGrow = false;
		lblSchoolName.Dpi = 100f;
		lblSchoolName.Font = new DXFont("Tahoma", 14f);
		lblSchoolName.LocationFloat = new PointFloat(7f, 5f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(375f, 23.99999f);
		lblSchoolName.StylePriority.UseBorders = false;
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.Text = "SCHOOL NAME";
		lblSchoolName.TextAlignment = TextAlignment.MiddleCenter;
		lblSchoolName.WordWrap = false;
		topMarginBand1.Dpi = 100f;
		topMarginBand1.HeightF = 30f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.Dpi = 100f;
		bottomMarginBand1.HeightF = 5f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		s_1ID_DataTable1TableAdapter.ClearBeforeFill = true;
		dsMealCards1.DataSetName = "dsMealCards";
		dsMealCards1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		mealCardsTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		base.DataAdapter = mealCardsTableAdapter;
		base.DataMember = "dtMealCards";
		base.DataSource = dsMealCards1;
		base.DesignerOptions.ShowPrintingWarnings = false;
		base.Margins = new DXMargins(10f, 10f, 30f, 5f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 2;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "16.2";
		base.Watermark.ImageTiling = true;
		base.ParametersRequestBeforeShow += MealCard_FrontSide_ParametersRequestBeforeShow;
		BeforePrint += BackSide_BeforePrint;
		((ISupportInitialize)dsMealCards1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
