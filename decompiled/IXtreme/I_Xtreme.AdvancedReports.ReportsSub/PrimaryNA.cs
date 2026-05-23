using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.AdvancedReports.StorageSub;
using I_Xtreme.AdvancedReports.StorageSub.PrimaryNASubDSTableAdapters;

namespace I_Xtreme.AdvancedReports.ReportsSub;

public class PrimaryNA : XtraReport
{
	private XRTableCell[] hRow;

	private XRTableCell[] vRow;

	private int[] sets;

	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private PageHeaderBand pageHeaderBand1;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell vBOT;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell6;

	private XRTable xrTable2;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell20;

	private XRTableCell rBOT;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell16;

	private Parameter semester;

	private Parameter studentClass;

	private Parameter StudentNo;

	private XRTableCell vMOT;

	private XRTableCell xrTableCell12;

	private XRTableCell rMOT;

	private XRTableCell xrTableCell10;

	private XRTableCell vEOT;

	private XRTableCell rEOT;

	private XRTableCell vHOP;

	private XRTableCell rHoP;

	private Parameter term;

	private Parameter classID;

	private PrimaryNASubDS primaryNASubDS1;

	private adapterPrimaryNASubDS adapterPrimaryNASubDS;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell3;

	private GroupHeaderBand GroupHeader1;

	private XRLabel xrLabel1;

	private XRShape xrShape1;

	public PrimaryNA()
	{
		InitializeComponent();
		rHoP.Text = ReportHeader.HoP.ToString();
		rBOT.Text = ReportHeader.BOT.ToString();
		rMOT.Text = ReportHeader.MOT.ToString();
		rEOT.Text = ReportHeader.EOT.ToString();
		hRow = new XRTableCell[4] { rHoP, rBOT, rMOT, rEOT };
		vRow = new XRTableCell[4] { vHOP, vBOT, vMOT, vEOT };
		sets = new int[4]
		{
			(int)ReportHeader.HoP,
			(int)ReportHeader.BOT,
			(int)ReportHeader.MOT,
			(int)ReportHeader.EOT
		};
		for (int i = 0; i < sets.Length; i++)
		{
			if (sets[i] == 0)
			{
				xrTable2.DeleteColumn(hRow[i]);
				xrTable1.DeleteColumn(vRow[i]);
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
		ShapePolygon shape = new ShapePolygon();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		vHOP = new XRTableCell();
		vBOT = new XRTableCell();
		vMOT = new XRTableCell();
		vEOT = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		pageHeaderBand1 = new PageHeaderBand();
		xrShape1 = new XRShape();
		xrLabel1 = new XRLabel();
		xrTable2 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell20 = new XRTableCell();
		rHoP = new XRTableCell();
		rBOT = new XRTableCell();
		rMOT = new XRTableCell();
		rEOT = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		semester = new Parameter();
		studentClass = new Parameter();
		StudentNo = new Parameter();
		term = new Parameter();
		classID = new Parameter();
		primaryNASubDS1 = new PrimaryNASubDS();
		adapterPrimaryNASubDS = new adapterPrimaryNASubDS();
		GroupHeader1 = new GroupHeaderBand();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)primaryNASubDS1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 25f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.SortFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		Detail.StyleName = "DataField";
		Detail.StylePriority.UsePadding = false;
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrTable1.BorderColor = Color.Black;
		xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTable1.Font = new DXFont("Tahoma", 8f);
		xrTable1.ForeColor = Color.Black;
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable1.SizeF = new SizeF(780f, 25f);
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseForeColor = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[9] { xrTableCell1, vHOP, vBOT, vMOT, vEOT, xrTableCell12, xrTableCell8, xrTableCell4, xrTableCell6 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.BackColor = Color.Transparent;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 10f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.Padding = new PaddingInfo(3, 0, 0, 0, 100f);
		xrTableCell1.StylePriority.UseBackColor = false;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UsePadding = false;
		xrTableCell1.Weight = 0.6468937561591;
		vHOP.BackColor = Color.Transparent;
		vHOP.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HoP]")
		});
		vHOP.Font = new DXFont("Tahoma", 10f);
		vHOP.Name = "vHOP";
		vHOP.StylePriority.UseBackColor = false;
		vHOP.StylePriority.UseFont = false;
		vHOP.StylePriority.UseTextAlignment = false;
		vHOP.TextAlignment = TextAlignment.MiddleCenter;
		vHOP.Weight = 0.17170636550035084;
		vBOT.BackColor = Color.Transparent;
		vBOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[BOT]")
		});
		vBOT.Font = new DXFont("Tahoma", 10f);
		vBOT.Name = "vBOT";
		vBOT.StylePriority.UseBackColor = false;
		vBOT.StylePriority.UseFont = false;
		vBOT.StylePriority.UseTextAlignment = false;
		vBOT.TextAlignment = TextAlignment.MiddleCenter;
		vBOT.Weight = 0.17170636550035073;
		vMOT.BackColor = Color.Transparent;
		vMOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[MOT]")
		});
		vMOT.Font = new DXFont("Tahoma", 10f);
		vMOT.Name = "vMOT";
		vMOT.StylePriority.UseBackColor = false;
		vMOT.StylePriority.UseFont = false;
		vMOT.StylePriority.UseTextAlignment = false;
		vMOT.TextAlignment = TextAlignment.MiddleCenter;
		vMOT.Weight = 0.17170636537694295;
		vEOT.BackColor = Color.Transparent;
		vEOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[EOT]")
		});
		vEOT.Font = new DXFont("Tahoma", 10f);
		vEOT.Name = "vEOT";
		vEOT.StylePriority.UseBackColor = false;
		vEOT.StylePriority.UseFont = false;
		vEOT.StylePriority.UseTextAlignment = false;
		vEOT.TextAlignment = TextAlignment.MiddleCenter;
		vEOT.Weight = 0.17170636359779157;
		xrTableCell12.BackColor = Color.Transparent;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[AvMark]")
		});
		xrTableCell12.Font = new DXFont("Tahoma", 10f);
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseBackColor = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell12.Weight = 0.17170636359779168;
		xrTableCell8.BackColor = Color.Transparent;
		xrTableCell8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Category]")
		});
		xrTableCell8.Font = new DXFont("Tahoma", 10f);
		xrTableCell8.ForeColor = Color.Maroon;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseBackColor = false;
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.StylePriority.UseForeColor = false;
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell8.Weight = 0.17170637176352355;
		xrTableCell4.BackColor = Color.Transparent;
		xrTableCell4.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Comment]")
		});
		xrTableCell4.Font = new DXFont("Comic Sans MS", 8.5f);
		xrTableCell4.ForeColor = Color.Blue;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseBackColor = false;
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.StylePriority.UseForeColor = false;
		xrTableCell4.StylePriority.UseTextAlignment = false;
		xrTableCell4.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell4.Weight = 1.1979513765995349;
		xrTableCell6.BackColor = Color.Transparent;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell6.Font = new DXFont("Tahoma", 10f);
		xrTableCell6.ForeColor = Color.FromArgb(0, 0, 192);
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseBackColor = false;
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.StylePriority.UseForeColor = false;
		xrTableCell6.StylePriority.UseTextAlignment = false;
		xrTableCell6.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell6.Weight = 0.2395902274380332;
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
		pageHeaderBand1.Controls.AddRange(new XRControl[2] { xrShape1, xrLabel1 });
		pageHeaderBand1.HeightF = 55f;
		pageHeaderBand1.Name = "pageHeaderBand1";
		xrShape1.Angle = 180;
		xrShape1.BorderColor = Color.Black;
		xrShape1.BorderWidth = 0f;
		xrShape1.FillColor = Color.DarkGray;
		xrShape1.ForeColor = Color.DarkGray;
		xrShape1.LineWidth = 0;
		xrShape1.LocationFloat = new PointFloat(340f, 25f);
		xrShape1.Name = "xrShape1";
		xrShape1.Shape = shape;
		xrShape1.SizeF = new SizeF(100f, 23f);
		xrShape1.StylePriority.UseBorderColor = false;
		xrShape1.StylePriority.UseBorderWidth = false;
		xrShape1.StylePriority.UseForeColor = false;
		xrLabel1.BackColor = Color.DarkGray;
		xrLabel1.BorderColor = Color.DarkGray;
		xrLabel1.Borders = BorderSide.All;
		xrLabel1.Font = new DXFont("Tahoma", 12f);
		xrLabel1.ForeColor = Color.Black;
		xrLabel1.LocationFloat = new PointFloat(160f, 0f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(460f, 25f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseBorderColor = false;
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseForeColor = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Other subjects (Not part of Assessment)";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		xrTable2.BorderColor = Color.Black;
		xrTable2.Borders = BorderSide.All;
		xrTable2.BorderWidth = 1f;
		xrTable2.Font = new DXFont("Tahoma", 11f);
		xrTable2.ForeColor = Color.Black;
		xrTable2.LocationFloat = new PointFloat(2.119276E-05f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable2.SizeF = new SizeF(780f, 25f);
		xrTable2.StylePriority.UseBorderColor = false;
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseBorderWidth = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseForeColor = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow2.Cells.AddRange(new XRTableCell[9] { xrTableCell20, rHoP, rBOT, rMOT, rEOT, xrTableCell10, xrTableCell24, xrTableCell3, xrTableCell16 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell20.BackColor = Color.Transparent;
		xrTableCell20.Font = new DXFont("Tahoma", 10f);
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseBackColor = false;
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.StylePriority.UseTextAlignment = false;
		xrTableCell20.Text = "Marks contribute:";
		xrTableCell20.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell20.Weight = 0.31093873522372995;
		rHoP.Font = new DXFont("Tahoma", 10f);
		rHoP.Name = "rHoP";
		rHoP.StylePriority.UseFont = false;
		rHoP.Text = "rHoP";
		rHoP.Weight = 0.0825331212874699;
		rBOT.Font = new DXFont("Tahoma", 10f);
		rBOT.Name = "rBOT";
		rBOT.StylePriority.UseFont = false;
		rBOT.Text = "rBOT";
		rBOT.Weight = 0.0825331212874699;
		rMOT.Font = new DXFont("Tahoma", 10f);
		rMOT.Name = "rMOT";
		rMOT.StylePriority.UseFont = false;
		rMOT.Text = "rMOT";
		rMOT.Weight = 0.08253312136326213;
		rEOT.Font = new DXFont("Tahoma", 10f);
		rEOT.Name = "rEOT";
		rEOT.StylePriority.UseFont = false;
		rEOT.Text = "rEOT";
		rEOT.Weight = 0.08253311919797568;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Weight = 0.08253311919797568;
		xrTableCell24.BackColor = Color.Transparent;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseBackColor = false;
		xrTableCell24.Weight = 0.08253312355965536;
		xrTableCell3.BackColor = Color.Transparent;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseBackColor = false;
		xrTableCell3.Weight = 0.5758124536104685;
		xrTableCell16.BackColor = Color.Transparent;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.StylePriority.UseBackColor = false;
		xrTableCell16.Weight = 0.11516253773797447;
		topMarginBand1.HeightF = 0f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 0f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		semester.Description = "Semester:";
		semester.Name = "semester";
		studentClass.Description = "Student Class:";
		studentClass.Name = "studentClass";
		StudentNo.Description = "StudentNo";
		StudentNo.Name = "StudentNo";
		StudentNo.Visible = false;
		term.Description = "Term";
		term.Name = "term";
		term.Visible = false;
		classID.Description = "Class";
		classID.Name = "classID";
		classID.Visible = false;
		primaryNASubDS1.DataSetName = "PrimaryNASubDS";
		primaryNASubDS1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterPrimaryNASubDS.ClearBeforeFill = true;
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrTable2 });
		GroupHeader1.HeightF = 25f;
		GroupHeader1.Name = "GroupHeader1";
		base.Bands.AddRange(new Band[5] { Detail, pageHeaderBand1, topMarginBand1, bottomMarginBand1, GroupHeader1 });
		base.ComponentStorage.AddRange(new IComponent[1] { primaryNASubDS1 });
		base.DataAdapter = adapterPrimaryNASubDS;
		base.DataMember = "PrimaryNASubDS";
		base.DataSource = primaryNASubDS1;
		FilterString = "[StudentNumber] = ?StudentNo And [SemesterId] = ?term And [ClassId] = ?classID";
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 600;
		base.PageWidth = 780;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[3] { StudentNo, term, classID });
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 0.5f;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "21.2";
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)primaryNASubDS1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
