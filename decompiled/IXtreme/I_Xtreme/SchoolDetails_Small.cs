using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.dSetStudentIdsTableAdapters;
using I_Xtreme.dSet_SchoolDetails_SmallTableAdapters;

namespace I_Xtreme;

public class SchoolDetails_Small : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private SchoolDetailsAdapter schoolDetailsAdapter1;

	private dSet_SchoolDetails_Small dSet_SchoolDetails_Small1;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel1;

	private XRPictureBox xrPictureBox1;

	private studentsTableAdapter studentsTableAdapter;

	private XRLabel xrLabel2;

	public SchoolDetails_Small()
	{
		InitializeComponent();
	}

	private void SchoolDetails_Small_BeforePrint(object sender, CancelEventArgs e)
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
		Detail = new DetailBand();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		schoolDetailsAdapter1 = new SchoolDetailsAdapter();
		dSet_SchoolDetails_Small1 = new dSet_SchoolDetails_Small();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		studentsTableAdapter = new studentsTableAdapter();
		((ISupportInitialize)dSet_SchoolDetails_Small1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[3] { xrLabel2, xrLabel1, xrPictureBox1 });
		Detail.HeightF = 55f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.StylePriority.UsePadding = false;
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrLabel2.BackColor = Color.Black;
		xrLabel2.BorderWidth = 0f;
		xrLabel2.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "SchoolDetails.schoolMotto")
		});
		xrLabel2.Font = new DXFont("Tahoma", 10f);
		xrLabel2.ForeColor = Color.White;
		xrLabel2.LocationFloat = new PointFloat(57.20835f, 25.16672f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(322.79f, 19.79167f);
		xrLabel2.StylePriority.UseBackColor = false;
		xrLabel2.StylePriority.UseBorderWidth = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseForeColor = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel2.WordWrap = false;
		xrLabel1.BackColor = Color.PaleGoldenrod;
		xrLabel1.BorderWidth = 0f;
		xrLabel1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Text", null, "SchoolDetails.SchoolName")
		});
		xrLabel1.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrLabel1.ForeColor = Color.Maroon;
		xrLabel1.LocationFloat = new PointFloat(57.20835f, 0.7500172f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(322.7917f, 25f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseBorderWidth = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UsePadding = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel1";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel1.WordWrap = false;
		xrPictureBox1.BackColor = Color.Transparent;
		xrPictureBox1.DataBindings.AddRange(new XRBinding[1]
		{
			new XRBinding("Image", null, "SchoolDetails.logo")
		});
		xrPictureBox1.LocationFloat = new PointFloat(0f, 0.7500191f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(55.20834f, 53.20836f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBackColor = false;
		schoolDetailsAdapter1.ClearBeforeFill = true;
		dSet_SchoolDetails_Small1.DataSetName = "dSet_SchoolDetails_Small";
		dSet_SchoolDetails_Small1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
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
		studentsTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		base.DataAdapter = schoolDetailsAdapter1;
		base.DataMember = "SchoolDetails";
		base.DataSource = dSet_SchoolDetails_Small1;
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 55;
		base.PageWidth = 380;
		base.PaperKind = DXPaperKind.Custom;
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapLines;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "11.1";
		BeforePrint += SchoolDetails_Small_BeforePrint;
		((ISupportInitialize)dSet_SchoolDetails_Small1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
