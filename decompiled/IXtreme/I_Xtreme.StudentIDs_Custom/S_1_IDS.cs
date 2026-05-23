using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.StudentID_Datasets;
using I_Xtreme.StudentID_Datasets.DataSet_S1TableAdapters;
using I_Xtreme.StudentIDs;

namespace I_Xtreme.StudentIDs_Custom;

public class S_1_IDS : XtraReport
{
	private IContainer components = null;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRControlStyle xrControlStyle1;

	public DetailBand Detail1;

	private DataSet_S1 dataSet_S11;

	private S_1ID_DataTable1TableAdapter s_1ID_DataTable1TableAdapter;

	private XRLabel lblName;

	private XRLabel xrLabel2;

	private XRLabel lblExpiryDate;

	private XRPictureBox xrPictureBox1;

	private XRPictureBox xrPictureBox2;

	private XRPanel xrPanel1;

	public S_1_IDS()
	{
		InitializeComponent();
	}

	private void ID_Fullpage_BeforePrint(object sender, CancelEventArgs e)
	{
		lblExpiryDate.Text = string.Format("{0} - {1}", IDCustomization.IssueDate.ToString("dd.MMM.yy"), IDCustomization.ExpiryDate.ToString("dd.MMM.yy"));
		xrPictureBox2.Image = Image.FromFile(Application.StartupPath + "\\id_resources\\student\\studid_0001.png");
	}

	private void lblName_PrintOnPage(object sender, PrintOnPageEventArgs e)
	{
		string text = lblName.Text;
		((XRLabel)sender).Bookmark += text;
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
		lblName = new XRLabel();
		xrLabel2 = new XRLabel();
		lblExpiryDate = new XRLabel();
		xrPanel1 = new XRPanel();
		xrPictureBox1 = new XRPictureBox();
		xrPictureBox2 = new XRPictureBox();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		xrControlStyle1 = new XRControlStyle();
		dataSet_S11 = new DataSet_S1();
		s_1ID_DataTable1TableAdapter = new S_1ID_DataTable1TableAdapter();
		((ISupportInitialize)dataSet_S11).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail1.Controls.AddRange(new XRControl[6] { lblName, xrLabel2, lblExpiryDate, xrPanel1, xrPictureBox1, xrPictureBox2 });
		Detail1.HeightF = 238f;
		Detail1.MultiColumn.ColumnSpacing = 100f;
		Detail1.MultiColumn.ColumnWidth = 339f;
		Detail1.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail1.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail1.Name = "Detail1";
		Detail1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.PageBreak = PageBreak.AfterBand;
		Detail1.SnapLinePadding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail1.SortFields.AddRange(new GroupField[1]
		{
			new GroupField("fullName", XRColumnSortOrder.Ascending)
		});
		Detail1.TextAlignment = TextAlignment.TopLeft;
		lblName.BorderColor = Color.Gainsboro;
		lblName.Borders = BorderSide.None;
		lblName.CanGrow = false;
		lblName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		lblName.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblName.LocationFloat = new PointFloat(74.00001f, 110f);
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		lblName.SizeF = new SizeF(164.4999f, 18.99999f);
		lblName.StylePriority.UseBackColor = false;
		lblName.StylePriority.UseBorderColor = false;
		lblName.StylePriority.UseBorders = false;
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UsePadding = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "lblName";
		lblName.TextAlignment = TextAlignment.MiddleLeft;
		lblName.WordWrap = false;
		xrLabel2.Borders = BorderSide.None;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrLabel2.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel2.LocationFloat = new PointFloat(74.00001f, 87f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(164.4999f, 18.99998f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UsePadding = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		lblExpiryDate.BorderColor = SystemColors.AppWorkspace;
		lblExpiryDate.Borders = BorderSide.None;
		lblExpiryDate.Font = new DXFont("Tahoma", 6.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblExpiryDate.LocationFloat = new PointFloat(74.00001f, 134.5f);
		lblExpiryDate.Name = "lblExpiryDate";
		lblExpiryDate.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
		lblExpiryDate.SizeF = new SizeF(164.4999f, 18.99998f);
		lblExpiryDate.StylePriority.UseBorderColor = false;
		lblExpiryDate.StylePriority.UseBorders = false;
		lblExpiryDate.StylePriority.UseFont = false;
		lblExpiryDate.StylePriority.UsePadding = false;
		lblExpiryDate.StylePriority.UseTextAlignment = false;
		lblExpiryDate.TextAlignment = TextAlignment.MiddleLeft;
		xrPanel1.BorderColor = Color.FromArgb(255, 128, 128);
		xrPanel1.Borders = BorderSide.All;
		xrPanel1.BorderWidth = 2f;
		xrPanel1.LocationFloat = new PointFloat(242.5f, 66.5f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(85.50002f, 95.49999f);
		xrPanel1.StylePriority.UseBorderColor = false;
		xrPanel1.StylePriority.UseBorders = false;
		xrPanel1.StylePriority.UseBorderWidth = false;
		xrPictureBox1.BorderColor = Color.Silver;
		xrPictureBox1.Borders = BorderSide.None;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(242.5f, 68.5f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(85.5f, 92.5f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrPictureBox2.LocationFloat = new PointFloat(0f, 0.5f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.SizeF = new SizeF(339f, 216f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		xrControlStyle1.Name = "xrControlStyle1";
		xrControlStyle1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		dataSet_S11.DataSetName = "DataSet_S1";
		dataSet_S11.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		s_1ID_DataTable1TableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[3] { Detail1, topMarginBand1, bottomMarginBand1 });
		Bookmark = "Students List";
		base.DataAdapter = s_1ID_DataTable1TableAdapter;
		base.DataMember = "S_1ID_DataTable1";
		base.DataSource = dataSet_S11;
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 216;
		base.PageWidth = 339;
		base.PaperKind = DXPaperKind.Custom;
		base.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
		base.ReportPrintOptions.PrintOnEmptyDataSource = false;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[1] { xrControlStyle1 });
		base.Version = "21.2";
		base.Watermark.Font = new DXFont("Verdana", 18f);
		BeforePrint += ID_Fullpage_BeforePrint;
		((ISupportInitialize)dataSet_S11).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
