using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using AlienAge.Connectivity;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace AlienAge.GradingScales;

public class OLevel_Report_Footer : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell3;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell6;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell19;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell16;

	private XRTableCell xrCell1;

	private XRTableCell xrCell2;

	private XRTableCell xrCell3;

	private XRTableCell xrCell4;

	private XRTableCell xrCell5;

	private XRTableCell xrCell6;

	private XRTableCell xrCell7;

	private XRTableCell xrCell8;

	private XRTableCell xrCell9;

	public OLevel_Report_Footer()
	{
		InitializeComponent();
	}

	private void OLevel_Report_Footer_BeforePrint(object sender, CancelEventArgs e)
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelGradingScale", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "OLevelGradingScale");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			switch (row["Category"].ToString())
			{
			case "D1":
				xrCell1.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "D2":
				xrCell2.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "C3":
				xrCell3.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "C4":
				xrCell4.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "C5":
				xrCell5.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "C6":
				xrCell6.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "P7":
				xrCell7.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "P8":
				xrCell8.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "F9":
				xrCell9.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			default:
				xrCell9.Text = string.Format("{0}-{1}", "-", "-");
				break;
			}
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
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell15 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrCell1 = new XRTableCell();
		xrCell2 = new XRTableCell();
		xrCell3 = new XRTableCell();
		xrCell4 = new XRTableCell();
		xrCell5 = new XRTableCell();
		xrCell6 = new XRTableCell();
		xrCell7 = new XRTableCell();
		xrCell8 = new XRTableCell();
		xrCell9 = new XRTableCell();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell4 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 50f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Tahoma", 10f);
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Rows.AddRange(new XRTableRow[2] { xrTableRow4, xrTableRow3 });
		xrTable1.SizeF = new SizeF(780f, 50f);
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow4.Cells.AddRange(new XRTableCell[10] { xrTableCell15, xrTableCell10, xrTableCell13, xrTableCell25, xrTableCell11, xrTableCell23, xrTableCell12, xrTableCell21, xrTableCell17, xrTableCell19 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseTextAlignment = false;
		xrTableCell15.Text = "GRADE";
		xrTableCell15.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell15.Weight = 0.7539062881469727;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "D1";
		xrTableCell10.Weight = 0.24609371185302736;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Text = "D2";
		xrTableCell13.Weight = 0.24607501983642577;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Text = "C3";
		xrTableCell25.Weight = 0.2460750198364258;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.Text = "C4";
		xrTableCell11.Weight = 0.24607501983642582;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.Text = "C5";
		xrTableCell23.Weight = 0.24607501983642577;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Text = "C6";
		xrTableCell12.Weight = 0.24607501983642577;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.Text = "P7";
		xrTableCell21.Weight = 0.2460750198364258;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Text = "P8";
		xrTableCell17.Weight = 0.24607501983642574;
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.Text = "F9";
		xrTableCell19.Weight = 0.24607481956481933;
		xrTableRow3.Cells.AddRange(new XRTableCell[10] { xrTableCell16, xrCell1, xrCell2, xrCell3, xrCell4, xrCell5, xrCell6, xrCell7, xrCell8, xrCell9 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "SCORE RANGE";
		xrTableCell16.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell16.Weight = 0.7539062881469727;
		xrCell1.Name = "xrCell1";
		xrCell1.Text = "xrCell1";
		xrCell1.Weight = 0.24609371185302736;
		xrCell2.Name = "xrCell2";
		xrCell2.Text = "xrCell2";
		xrCell2.Weight = 0.24607501979859833;
		xrCell3.Name = "xrCell3";
		xrCell3.Text = "xrCell3";
		xrCell3.Weight = 0.24607501979859836;
		xrCell4.Name = "xrCell4";
		xrCell4.Text = "xrCell4";
		xrCell4.Weight = 0.2460750197985983;
		xrCell5.Name = "xrCell5";
		xrCell5.Text = "xrCell5";
		xrCell5.Weight = 0.24607501979859833;
		xrCell6.Name = "xrCell6";
		xrCell6.Text = "xrCell6";
		xrCell6.Weight = 0.2460750197985983;
		xrCell7.Name = "xrCell7";
		xrCell7.Text = "xrCell7";
		xrCell7.Weight = 0.2460750197985983;
		xrCell8.Name = "xrCell8";
		xrCell8.Text = "xrCell8";
		xrCell8.Weight = 0.24607501979859833;
		xrCell9.Name = "xrCell9";
		xrCell9.Text = "xrCell9";
		xrCell9.Weight = 0.24607481982961155;
		Title.BackColor = Color.White;
		Title.BorderColor = SystemColors.ControlText;
		Title.Borders = BorderSide.None;
		Title.BorderWidth = 1f;
		Title.Font = new DXFont("Times New Roman", 20f, DXFontStyle.Bold);
		Title.ForeColor = Color.Maroon;
		Title.Name = "Title";
		FieldCaption.BackColor = Color.White;
		FieldCaption.BorderColor = SystemColors.ControlText;
		FieldCaption.Borders = BorderSide.Bottom;
		FieldCaption.BorderWidth = 1f;
		FieldCaption.Font = new DXFont("Arial", 10f, DXFontStyle.Bold);
		FieldCaption.ForeColor = Color.Maroon;
		FieldCaption.Name = "FieldCaption";
		PageInfo.BackColor = Color.White;
		PageInfo.BorderColor = SystemColors.ControlText;
		PageInfo.Borders = BorderSide.None;
		PageInfo.BorderWidth = 1f;
		PageInfo.Font = new DXFont("Times New Roman", 10f, DXFontStyle.Bold);
		PageInfo.ForeColor = SystemColors.ControlText;
		PageInfo.Name = "PageInfo";
		DataField.BackColor = Color.White;
		DataField.BorderColor = SystemColors.ControlText;
		DataField.Borders = BorderSide.None;
		DataField.BorderWidth = 1f;
		DataField.Font = new DXFont("Times New Roman", 10f);
		DataField.ForeColor = SystemColors.ControlText;
		DataField.Name = "DataField";
		DataField.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableRow1.Cells.AddRange(new XRTableCell[3] { xrTableCell1, xrTableCell2, xrTableCell3 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.Weight = 1.0;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Text = "xrTableCell2";
		xrTableCell2.Weight = 1.0;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.Text = "xrTableCell3";
		xrTableCell3.Weight = 1.0;
		xrTableRow2.Cells.AddRange(new XRTableCell[3] { xrTableCell4, xrTableCell5, xrTableCell6 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.Text = "xrTableCell4";
		xrTableCell4.Weight = 1.0;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.Text = "xrTableCell5";
		xrTableCell5.Weight = 1.0;
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "xrTableCell6";
		xrTableCell6.Weight = 1.0;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 53;
		base.PageWidth = 780;
		base.PaperKind = DXPaperKind.Custom;
		base.SnapGridSize = 2f;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "13.1";
		BeforePrint += OLevel_Report_Footer_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
