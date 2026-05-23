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

public class ALevelGrading_Footer_GradingMini : XtraReport
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

	private XRTable xrTable2;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell33;

	private XRTableCell xrTableCell34;

	private XRTableRow xrTableRow6;

	private XRTableCell xrTableCell35;

	private XRTableCell xr1;

	private XRTableCell xr2;

	private XRTableCell xr3;

	private XRTableCell xr4;

	private XRTableCell xr5;

	private XRTableCell xr6;

	private XRTableCell xr7;

	public ALevelGrading_Footer_GradingMini()
	{
		InitializeComponent();
	}

	private void ALevelGrading_Footer_BeforePrint(object sender, CancelEventArgs e)
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ALevelGradingScale", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ALevelGradingScale");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			switch (row["Category"].ToString())
			{
			case "A":
				xr1.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "B":
				xr2.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "C":
				xr3.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "D":
				xr4.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "E":
				xr5.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "O":
				xr6.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			case "F":
				xr7.Text = string.Format("{0}-{1}", row["Debut"].ToString(), row["End"].ToString());
				break;
			default:
				xr7.Text = string.Format("{0}-{1}", "-", "-");
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
		xrTable2 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		xrTableCell35 = new XRTableCell();
		xr1 = new XRTableCell();
		xr2 = new XRTableCell();
		xr3 = new XRTableCell();
		xr4 = new XRTableCell();
		xr5 = new XRTableCell();
		xr6 = new XRTableCell();
		xr7 = new XRTableCell();
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
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrTable2 });
		Detail.HeightF = 40f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Tahoma", 10f);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow5, xrTableRow6 });
		xrTable2.SizeF = new SizeF(536.5f, 40f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow5.Cells.AddRange(new XRTableCell[8] { xrTableCell27, xrTableCell28, xrTableCell29, xrTableCell30, xrTableCell31, xrTableCell32, xrTableCell33, xrTableCell34 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell27.Font = new DXFont("Tahoma", 8f);
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.StylePriority.UseFont = false;
		xrTableCell27.Text = "GRADE";
		xrTableCell27.Weight = 1.0397945528273422;
		xrTableCell28.Font = new DXFont("Tahoma", 8f);
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.Text = "A";
		xrTableCell28.Weight = 0.2800384590715918;
		xrTableCell29.Font = new DXFont("Tahoma", 8f);
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.Text = "B";
		xrTableCell29.Weight = 0.280038453242083;
		xrTableCell30.Font = new DXFont("Tahoma", 8f);
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.Text = "C";
		xrTableCell30.Weight = 0.2800384389408497;
		xrTableCell31.Font = new DXFont("Tahoma", 8f);
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.Text = "D";
		xrTableCell31.Weight = 0.2800384449171567;
		xrTableCell32.Font = new DXFont("Tahoma", 8f);
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.Text = "E";
		xrTableCell32.Weight = 0.2800384521484375;
		xrTableCell33.Font = new DXFont("Tahoma", 8f);
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.Text = "O";
		xrTableCell33.Weight = 0.2800384521484375;
		xrTableCell34.Font = new DXFont("Tahoma", 8f);
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.Text = "F";
		xrTableCell34.Weight = 0.27997474670410155;
		xrTableRow6.Cells.AddRange(new XRTableCell[8] { xrTableCell35, xr1, xr2, xr3, xr4, xr5, xr6, xr7 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		xrTableCell35.Font = new DXFont("Tahoma", 8f);
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.Text = "SCORE RANGE";
		xrTableCell35.Weight = 1.0397945528273422;
		xr1.Font = new DXFont("Tahoma", 8f);
		xr1.Name = "xr1";
		xr1.StylePriority.UseFont = false;
		xr1.Text = "xr1";
		xr1.Weight = 0.28003846660567666;
		xr2.Font = new DXFont("Tahoma", 8f);
		xr2.Name = "xr2";
		xr2.StylePriority.UseFont = false;
		xr2.Text = "xr2";
		xr2.Weight = 0.2800384467069892;
		xr3.Font = new DXFont("Tahoma", 8f);
		xr3.Name = "xr3";
		xr3.StylePriority.UseFont = false;
		xr3.Text = "xr3";
		xr3.Weight = 0.2800384534620788;
		xr4.Font = new DXFont("Tahoma", 8f);
		xr4.Name = "xr4";
		xr4.StylePriority.UseFont = false;
		xr4.Text = "xr4";
		xr4.Weight = 0.28003845874076166;
		xr5.Font = new DXFont("Tahoma", 8f);
		xr5.Name = "xr5";
		xr5.StylePriority.UseFont = false;
		xr5.Text = "xr5";
		xr5.Weight = 0.2800384521484375;
		xr6.Font = new DXFont("Tahoma", 8f);
		xr6.Name = "xr6";
		xr6.StylePriority.UseFont = false;
		xr6.Text = "xr6";
		xr6.Weight = 0.2800384521484375;
		xr7.Font = new DXFont("Tahoma", 8f);
		xr7.Name = "xr7";
		xr7.StylePriority.UseFont = false;
		xr7.Text = "xr7";
		xr7.Weight = 0.27997471736027646;
		Title.BackColor = Color.White;
		Title.BorderColor = SystemColors.ControlText;
		Title.Borders = BorderSide.None;
		Title.BorderWidth = 1f;
		Title.Font = new DXFont("Times New Roman", 24f);
		Title.ForeColor = Color.Black;
		Title.Name = "Title";
		FieldCaption.BackColor = Color.White;
		FieldCaption.BorderColor = SystemColors.ControlText;
		FieldCaption.Borders = BorderSide.Bottom;
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
		base.PageHeight = 41;
		base.PageWidth = 537;
		base.PaperKind = DXPaperKind.Custom;
		base.SnapGridSize = 2f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "17.2";
		BeforePrint += ALevelGrading_Footer_BeforePrint;
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
