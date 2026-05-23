using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using AlienAge.ReportHeaders;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.AdvancedReports.StorageSub;
using I_Xtreme.AdvancedReports.StorageSub.ALevelReportSubTableAdapters;

namespace I_Xtreme.AdvancedReports.ReportsSub;

public class ALevelSubLandScape : XtraReport
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

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private Parameter semesters;

	private Parameter classes;

	private CalculatedField TotalPoints;

	private Parameter StudentNo;

	private XRLine xrLine1;

	private ALevelReportSub aLevelReportSub1;

	private adapterALevelReportSub adapterALevelReportSub;

	private Parameter classId;

	private GroupFooterBand footerTotalPoints;

	private GroupFooterBand footerComment1;

	private GroupFooterBand footerComment3;

	private XRLabel lblComment1;

	private XRLabel xrLabel6;

	private XRLabel lblComment3;

	private XRLabel xrLabel4;

	private GroupFooterBand footerPromotion;

	private Parameter cashOnAccount;

	private XRLabel lblPromoStatus;

	private XRTable xrTable1;

	private XRTableRow xrTableRow20;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell12;

	private XRTable tableValue;

	private XRTableRow xrTableRow21;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell17;

	private XRTableCell vHOP;

	private XRTableCell vBOT;

	private XRTableCell vMOT;

	private XRTableCell vEOT;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell30;

	private XRTable tableHeader;

	private XRTableRow xrTableRow22;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell35;

	private XRTableCell hHOP;

	private XRTableCell hBOT;

	private XRTableCell hMOT;

	private XRTableCell hEOT;

	private XRTableCell xrTableCell47;

	private XRTableCell xrTableCell48;

	private XRTableCell xrTableCell49;

	private XRTableCell xrTableCell50;

	private XRTableCell xrTableCell51;

	private XRTableRow xrTableRow23;

	private XRTableCell xrTableCell52;

	private XRTableCell xrTableCell53;

	private XRTableCell rHoP;

	private XRTableCell rBOT;

	private XRTableCell rMOT;

	private XRTableCell rEOT;

	private XRTableCell hTTL;

	private XRTableCell xrTableCell59;

	private XRTableCell xrTableCell60;

	private XRTableCell xrTableCell61;

	private XRTableCell xrTableCell62;

	private GroupFooterBand footerCommentHeader;

	private XRLabel xrLabel1;

	private GroupHeaderBand headerGroup;

	private Parameter term;

	public ALevelSubLandScape()
	{
		InitializeComponent();
		lblComment1.Text = ReportCustomization.Comment1Label;
		lblComment3.Text = ReportCustomization.Comment2Label;
		rHoP.Text = ReportHeader.HoP.ToString();
		rBOT.Text = ReportHeader.BOT.ToString();
		rMOT.Text = ReportHeader.MOT.ToString();
		rEOT.Text = ReportHeader.EOT.ToString();
		hRow = new XRTableCell[4] { hHOP, hBOT, hMOT, hEOT };
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
				tableHeader.DeleteColumn(hRow[i]);
				tableValue.DeleteColumn(vRow[i]);
			}
		}
		footerComment1.Visible = ReportCustomization.Comment1;
		footerComment3.Visible = ReportCustomization.Comment2;
		footerPromotion.Visible = ReportCustomization.ShowOLevelPromo;
		lblPromoStatus.Visible = ReportCustomization.ShowALevelPromo;
		hHOP.Text = ExamsOutputString.hHoP;
		hBOT.Text = ExamsOutputString.hBOT;
		hMOT.Text = ExamsOutputString.hMOT;
		hEOT.Text = ExamsOutputString.hEOT;
		double num = ReportHeader.HoP + ReportHeader.BOT + ReportHeader.MOT + ReportHeader.EOT;
		if (num > 100.0)
		{
			hTTL.Text = string.Empty;
		}
		else
		{
			hTTL.Text = (ReportHeader.HoP + ReportHeader.BOT + ReportHeader.MOT + ReportHeader.EOT).ToString();
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
		tableValue = new XRTable();
		xrTableRow21 = new XRTableRow();
		xrTableCell13 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		vHOP = new XRTableCell();
		vBOT = new XRTableCell();
		vMOT = new XRTableCell();
		vEOT = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		semesters = new Parameter();
		classes = new Parameter();
		TotalPoints = new CalculatedField();
		StudentNo = new Parameter();
		xrLine1 = new XRLine();
		aLevelReportSub1 = new ALevelReportSub();
		adapterALevelReportSub = new adapterALevelReportSub();
		classId = new Parameter();
		tableHeader = new XRTable();
		xrTableRow22 = new XRTableRow();
		xrTableCell34 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		hHOP = new XRTableCell();
		hBOT = new XRTableCell();
		hMOT = new XRTableCell();
		hEOT = new XRTableCell();
		xrTableCell47 = new XRTableCell();
		xrTableCell48 = new XRTableCell();
		xrTableCell49 = new XRTableCell();
		xrTableCell50 = new XRTableCell();
		xrTableCell51 = new XRTableCell();
		xrTableRow23 = new XRTableRow();
		xrTableCell52 = new XRTableCell();
		xrTableCell53 = new XRTableCell();
		rHoP = new XRTableCell();
		rBOT = new XRTableCell();
		rMOT = new XRTableCell();
		rEOT = new XRTableCell();
		hTTL = new XRTableCell();
		xrTableCell59 = new XRTableCell();
		xrTableCell60 = new XRTableCell();
		xrTableCell61 = new XRTableCell();
		xrTableCell62 = new XRTableCell();
		footerTotalPoints = new GroupFooterBand();
		xrTable1 = new XRTable();
		xrTableRow20 = new XRTableRow();
		xrTableCell9 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		footerComment1 = new GroupFooterBand();
		lblComment1 = new XRLabel();
		xrLabel6 = new XRLabel();
		footerComment3 = new GroupFooterBand();
		lblComment3 = new XRLabel();
		xrLabel4 = new XRLabel();
		cashOnAccount = new Parameter();
		footerPromotion = new GroupFooterBand();
		lblPromoStatus = new XRLabel();
		footerCommentHeader = new GroupFooterBand();
		xrLabel1 = new XRLabel();
		headerGroup = new GroupHeaderBand();
		term = new Parameter();
		((ISupportInitialize)tableValue).BeginInit();
		((ISupportInitialize)aLevelReportSub1).BeginInit();
		((ISupportInitialize)tableHeader).BeginInit();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { tableValue });
		Detail.HeightF = 25f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.SortFields.AddRange(new GroupField[3]
		{
			new GroupField("SubGroup", XRColumnSortOrder.Ascending),
			new GroupField("SubjectId", XRColumnSortOrder.Ascending),
			new GroupField("Paper", XRColumnSortOrder.Ascending)
		});
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		tableValue.BackColor = Color.Transparent;
		tableValue.BorderColor = Color.Black;
		tableValue.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		tableValue.Font = new DXFont("Tahoma", 9f);
		tableValue.ForeColor = Color.Black;
		tableValue.LocationFloat = new PointFloat(0f, 0f);
		tableValue.Name = "tableValue";
		tableValue.Rows.AddRange(new XRTableRow[1] { xrTableRow21 });
		tableValue.SizeF = new SizeF(779f, 25f);
		tableValue.StylePriority.UseBackColor = false;
		tableValue.StylePriority.UseBorderColor = false;
		tableValue.StylePriority.UseBorders = false;
		tableValue.StylePriority.UseFont = false;
		tableValue.StylePriority.UseForeColor = false;
		tableValue.StylePriority.UseTextAlignment = false;
		tableValue.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow21.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell13, xrTableCell17, vHOP, vBOT, vMOT, vEOT, xrTableCell22, xrTableCell24, xrTableCell27, xrTableCell28,
			xrTableCell30
		});
		xrTableRow21.Name = "xrTableRow21";
		xrTableRow21.Weight = 1.0;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell13.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell13.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell13.StylePriority.UsePadding = false;
		xrTableCell13.Weight = 1.83568674853892;
		xrTableCell17.BackColor = Color.WhiteSmoke;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Paper]")
		});
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell17.StylePriority.UseBackColor = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.706033400607813;
		vHOP.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HoP]")
		});
		vHOP.Name = "vHOP";
		vHOP.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		vHOP.StylePriority.UseTextAlignment = false;
		vHOP.TextAlignment = TextAlignment.MiddleCenter;
		vHOP.Weight = 0.480102666382306;
		vBOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[BOT]")
		});
		vBOT.Name = "vBOT";
		vBOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		vBOT.StylePriority.UsePadding = false;
		vBOT.StylePriority.UseTextAlignment = false;
		vBOT.TextAlignment = TextAlignment.MiddleCenter;
		vBOT.Weight = 0.480102693315342;
		vMOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[MOT]")
		});
		vMOT.Name = "vMOT";
		vMOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		vMOT.StylePriority.UsePadding = false;
		vMOT.StylePriority.UseTextAlignment = false;
		vMOT.TextAlignment = TextAlignment.MiddleCenter;
		vMOT.Weight = 0.480102693315342;
		vEOT.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[EOT]")
		});
		vEOT.Name = "vEOT";
		vEOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		vEOT.StylePriority.UsePadding = false;
		vEOT.StylePriority.UseTextAlignment = false;
		vEOT.TextAlignment = TextAlignment.MiddleCenter;
		vEOT.Weight = 0.48010277411445;
		xrTableCell22.BackColor = Color.WhiteSmoke;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[AvMark]")
		});
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell22.StylePriority.UseBackColor = false;
		xrTableCell22.StylePriority.UsePadding = false;
		xrTableCell22.StylePriority.UseTextAlignment = false;
		xrTableCell22.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell22.Weight = 0.48010277411445;
		xrTableCell24.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Category]")
		});
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell24.StylePriority.UsePadding = false;
		xrTableCell24.StylePriority.UseTextAlignment = false;
		xrTableCell24.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell24.Weight = 0.480102774114449;
		xrTableCell27.BackColor = Color.WhiteSmoke;
		xrTableCell27.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Grade]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell27.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell27.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell27.StylePriority.UseBackColor = false;
		xrTableCell27.StylePriority.UsePadding = false;
		xrTableCell27.StylePriority.UseTextAlignment = false;
		xrTableCell27.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell27.Weight = 0.494223387770842;
		xrTableCell28.ExpressionBindings.AddRange(new ExpressionBinding[2]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Comment]"),
			new ExpressionBinding("BeforePrint", "Tag", "[SubjectId]")
		});
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrTableCell28.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell28.ProcessDuplicatesTarget = ProcessDuplicatesTarget.Tag;
		xrTableCell28.StylePriority.UsePadding = false;
		xrTableCell28.Weight = 4.23620038895613;
		xrTableCell30.BackColor = Color.WhiteSmoke;
		xrTableCell30.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell30.StylePriority.UseBackColor = false;
		xrTableCell30.StylePriority.UsePadding = false;
		xrTableCell30.StylePriority.UseTextAlignment = false;
		xrTableCell30.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell30.Weight = 0.847239698769958;
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
		semesters.Description = "Semester";
		semesters.Name = "semesters";
		classes.Description = "Class";
		classes.Name = "classes";
		TotalPoints.DataMember = "ALevelReport_With_Picture";
		TotalPoints.FieldType = FieldType.Double;
		TotalPoints.Name = "TotalPoints";
		StudentNo.Description = "StudentNo";
		StudentNo.Name = "StudentNo";
		StudentNo.Visible = false;
		xrLine1.BorderColor = Color.Black;
		xrLine1.BorderWidth = 0f;
		xrLine1.ForeColor = Color.Black;
		xrLine1.LineWidth = 2f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(779f, 2.083333f);
		xrLine1.StylePriority.UseBorderColor = false;
		xrLine1.StylePriority.UseBorderWidth = false;
		xrLine1.StylePriority.UseForeColor = false;
		aLevelReportSub1.DataSetName = "ALevelReportSub";
		aLevelReportSub1.EnforceConstraints = false;
		aLevelReportSub1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterALevelReportSub.ClearBeforeFill = true;
		classId.Description = "Class";
		classId.Name = "classId";
		classId.Visible = false;
		tableHeader.BorderColor = Color.Black;
		tableHeader.Borders = BorderSide.All;
		tableHeader.Font = new DXFont("Tahoma", 8f);
		tableHeader.ForeColor = Color.Black;
		tableHeader.LocationFloat = new PointFloat(0f, 0f);
		tableHeader.Name = "tableHeader";
		tableHeader.Rows.AddRange(new XRTableRow[2] { xrTableRow22, xrTableRow23 });
		tableHeader.SizeF = new SizeF(779f, 50f);
		tableHeader.StylePriority.UseBorderColor = false;
		tableHeader.StylePriority.UseBorders = false;
		tableHeader.StylePriority.UseFont = false;
		tableHeader.StylePriority.UseForeColor = false;
		tableHeader.StylePriority.UseTextAlignment = false;
		tableHeader.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow22.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell34, xrTableCell35, hHOP, hBOT, hMOT, hEOT, xrTableCell47, xrTableCell48, xrTableCell49, xrTableCell50,
			xrTableCell51
		});
		xrTableRow22.Name = "xrTableRow22";
		xrTableRow22.Weight = 1.0;
		xrTableCell34.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.Text = "SUBJECT";
		xrTableCell34.Weight = 1.83568674853892;
		xrTableCell35.BackColor = Color.WhiteSmoke;
		xrTableCell35.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell35.StylePriority.UseBackColor = false;
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.Text = "PAPER";
		xrTableCell35.Weight = 0.706033400607813;
		hHOP.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		hHOP.Name = "hHOP";
		hHOP.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		hHOP.StylePriority.UseFont = false;
		hHOP.Text = "HoP";
		hHOP.Weight = 0.480102666382306;
		hBOT.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		hBOT.Name = "hBOT";
		hBOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		hBOT.StylePriority.UseFont = false;
		hBOT.StylePriority.UsePadding = false;
		hBOT.Text = "BOT";
		hBOT.Weight = 0.480102693315342;
		hMOT.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		hMOT.Name = "hMOT";
		hMOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		hMOT.StylePriority.UseFont = false;
		hMOT.StylePriority.UsePadding = false;
		hMOT.Text = "MOT";
		hMOT.Weight = 0.480102693315342;
		hEOT.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		hEOT.Name = "hEOT";
		hEOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		hEOT.StylePriority.UseFont = false;
		hEOT.StylePriority.UsePadding = false;
		hEOT.Text = "EOT";
		hEOT.Weight = 0.48010277411445;
		xrTableCell47.BackColor = Color.WhiteSmoke;
		xrTableCell47.Font = new DXFont("Tahoma", 6f, DXFontStyle.Bold);
		xrTableCell47.Name = "xrTableCell47";
		xrTableCell47.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell47.StylePriority.UseBackColor = false;
		xrTableCell47.StylePriority.UseFont = false;
		xrTableCell47.StylePriority.UsePadding = false;
		xrTableCell47.Text = "TOTAL";
		xrTableCell47.Weight = 0.48010277411445;
		xrTableCell48.Font = new DXFont("Tahoma", 6f, DXFontStyle.Bold);
		xrTableCell48.Name = "xrTableCell48";
		xrTableCell48.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell48.StylePriority.UseFont = false;
		xrTableCell48.StylePriority.UsePadding = false;
		xrTableCell48.Text = "SCORE";
		xrTableCell48.Weight = 0.480102774114449;
		xrTableCell49.BackColor = Color.WhiteSmoke;
		xrTableCell49.Font = new DXFont("Tahoma", 6f, DXFontStyle.Bold);
		xrTableCell49.Name = "xrTableCell49";
		xrTableCell49.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell49.StylePriority.UseBackColor = false;
		xrTableCell49.StylePriority.UseFont = false;
		xrTableCell49.StylePriority.UsePadding = false;
		xrTableCell49.Text = "GRADE";
		xrTableCell49.Weight = 0.494223387770842;
		xrTableCell50.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell50.Name = "xrTableCell50";
		xrTableCell50.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell50.StylePriority.UseFont = false;
		xrTableCell50.StylePriority.UsePadding = false;
		xrTableCell50.Text = "COMMENT";
		xrTableCell50.Weight = 4.23620038895613;
		xrTableCell51.BackColor = Color.WhiteSmoke;
		xrTableCell51.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell51.Name = "xrTableCell51";
		xrTableCell51.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell51.StylePriority.UseBackColor = false;
		xrTableCell51.StylePriority.UseFont = false;
		xrTableCell51.StylePriority.UsePadding = false;
		xrTableCell51.Text = "INITIALS";
		xrTableCell51.Weight = 0.847239698769958;
		xrTableRow23.Cells.AddRange(new XRTableCell[11]
		{
			xrTableCell52, xrTableCell53, rHoP, rBOT, rMOT, rEOT, hTTL, xrTableCell59, xrTableCell60, xrTableCell61,
			xrTableCell62
		});
		xrTableRow23.Name = "xrTableRow23";
		xrTableRow23.Weight = 1.0;
		xrTableCell52.Font = new DXFont("Tahoma", 9f);
		xrTableCell52.Name = "xrTableCell52";
		xrTableCell52.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell52.StylePriority.UseFont = false;
		xrTableCell52.StylePriority.UsePadding = false;
		xrTableCell52.Text = "Marks contribute";
		xrTableCell52.Weight = 1.83568674853892;
		xrTableCell53.BackColor = Color.WhiteSmoke;
		xrTableCell53.Name = "xrTableCell53";
		xrTableCell53.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell53.StylePriority.UseBackColor = false;
		xrTableCell53.StylePriority.UsePadding = false;
		xrTableCell53.Weight = 0.706033400607813;
		rHoP.Name = "rHoP";
		rHoP.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		rHoP.StylePriority.UsePadding = false;
		rHoP.Weight = 0.480102666382306;
		rBOT.Name = "rBOT";
		rBOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		rBOT.StylePriority.UsePadding = false;
		rBOT.Weight = 0.480102693315342;
		rMOT.Name = "rMOT";
		rMOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		rMOT.StylePriority.UsePadding = false;
		rMOT.Weight = 0.480102693315342;
		rEOT.Name = "rEOT";
		rEOT.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		rEOT.StylePriority.UsePadding = false;
		rEOT.Weight = 0.48010277411445;
		hTTL.BackColor = Color.WhiteSmoke;
		hTTL.Name = "hTTL";
		hTTL.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		hTTL.StylePriority.UseBackColor = false;
		hTTL.StylePriority.UsePadding = false;
		hTTL.Weight = 0.48010277411445;
		xrTableCell59.Name = "xrTableCell59";
		xrTableCell59.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell59.StylePriority.UsePadding = false;
		xrTableCell59.Weight = 0.480102774114449;
		xrTableCell60.BackColor = Color.WhiteSmoke;
		xrTableCell60.Name = "xrTableCell60";
		xrTableCell60.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell60.StylePriority.UseBackColor = false;
		xrTableCell60.StylePriority.UsePadding = false;
		xrTableCell60.Weight = 0.494223387770842;
		xrTableCell61.Name = "xrTableCell61";
		xrTableCell61.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell61.StylePriority.UsePadding = false;
		xrTableCell61.Weight = 4.23620038895613;
		xrTableCell62.BackColor = Color.WhiteSmoke;
		xrTableCell62.Name = "xrTableCell62";
		xrTableCell62.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell62.StylePriority.UseBackColor = false;
		xrTableCell62.StylePriority.UsePadding = false;
		xrTableCell62.Weight = 0.847239698769958;
		footerTotalPoints.Controls.AddRange(new XRControl[2] { xrLine1, xrTable1 });
		footerTotalPoints.HeightF = 53f;
		footerTotalPoints.Name = "footerTotalPoints";
		xrTable1.BorderColor = Color.DarkGray;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Tahoma", 9.75f);
		xrTable1.LocationFloat = new PointFloat(0f, 18f);
		xrTable1.Name = "xrTable1";
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow20 });
		xrTable1.SizeF = new SizeF(779f, 25f);
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow20.Cells.AddRange(new XRTableCell[2] { xrTableCell9, xrTableCell12 });
		xrTableRow20.Name = "xrTableRow20";
		xrTableRow20.Weight = 1.0;
		xrTableCell9.BackColor = Color.Black;
		xrTableCell9.BorderColor = Color.Black;
		xrTableCell9.CanGrow = false;
		xrTableCell9.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold);
		xrTableCell9.ForeColor = Color.White;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell9.StylePriority.UseBackColor = false;
		xrTableCell9.StylePriority.UseBorderColor = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseForeColor = false;
		xrTableCell9.Text = "Total Points";
		xrTableCell9.Weight = 1.0;
		xrTableCell9.WordWrap = false;
		xrTableCell12.BorderColor = Color.Black;
		xrTableCell12.CanGrow = false;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Totals]")
		});
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell12.StylePriority.UseBorderColor = false;
		xrTableCell12.StylePriority.UseTextAlignment = false;
		xrTableCell12.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell12.Weight = 1.0;
		xrTableCell12.WordWrap = false;
		footerComment1.Controls.AddRange(new XRControl[2] { lblComment1, xrLabel6 });
		footerComment1.HeightF = 55f;
		footerComment1.Level = 3;
		footerComment1.Name = "footerComment1";
		footerComment1.PrintAtBottom = true;
		lblComment1.BackColor = Color.Transparent;
		lblComment1.BorderColor = Color.Black;
		lblComment1.BorderDashStyle = BorderDashStyle.Dash;
		lblComment1.Borders = BorderSide.None;
		lblComment1.CanGrow = false;
		lblComment1.Font = new DXFont("Tahoma", 10f);
		lblComment1.ForeColor = Color.Black;
		lblComment1.LocationFloat = new PointFloat(0f, 0f);
		lblComment1.Name = "lblComment1";
		lblComment1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblComment1.SizeF = new SizeF(175f, 23f);
		lblComment1.StylePriority.UseBackColor = false;
		lblComment1.StylePriority.UseBorderColor = false;
		lblComment1.StylePriority.UseBorderDashStyle = false;
		lblComment1.StylePriority.UseBorders = false;
		lblComment1.StylePriority.UseFont = false;
		lblComment1.StylePriority.UseForeColor = false;
		lblComment1.StylePriority.UseTextAlignment = false;
		lblComment1.Text = "Comment 1:";
		lblComment1.TextAlignment = TextAlignment.BottomLeft;
		lblComment1.WordWrap = false;
		xrLabel6.BorderColor = Color.Black;
		xrLabel6.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel6.Borders = BorderSide.Bottom;
		xrLabel6.CanGrow = false;
		xrLabel6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassTeacherComments]")
		});
		xrLabel6.Font = new DXFont("Tahoma", 11f);
		xrLabel6.ForeColor = Color.Black;
		xrLabel6.LocationFloat = new PointFloat(0.5278375f, 23f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(130, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(778.4719f, 23f);
		xrLabel6.StylePriority.UseBorderColor = false;
		xrLabel6.StylePriority.UseBorderDashStyle = false;
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseForeColor = false;
		xrLabel6.StylePriority.UsePadding = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.TextAlignment = TextAlignment.BottomLeft;
		xrLabel6.WordWrap = false;
		footerComment3.Controls.AddRange(new XRControl[2] { lblComment3, xrLabel4 });
		footerComment3.HeightF = 55f;
		footerComment3.Level = 4;
		footerComment3.Name = "footerComment3";
		footerComment3.PrintAtBottom = true;
		lblComment3.BackColor = Color.Transparent;
		lblComment3.BorderColor = Color.Black;
		lblComment3.BorderDashStyle = BorderDashStyle.Dash;
		lblComment3.Borders = BorderSide.None;
		lblComment3.CanGrow = false;
		lblComment3.Font = new DXFont("Tahoma", 10f);
		lblComment3.ForeColor = Color.Black;
		lblComment3.LocationFloat = new PointFloat(0f, 0f);
		lblComment3.Name = "lblComment3";
		lblComment3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblComment3.SizeF = new SizeF(175f, 23f);
		lblComment3.StylePriority.UseBackColor = false;
		lblComment3.StylePriority.UseBorderColor = false;
		lblComment3.StylePriority.UseBorderDashStyle = false;
		lblComment3.StylePriority.UseBorders = false;
		lblComment3.StylePriority.UseFont = false;
		lblComment3.StylePriority.UseForeColor = false;
		lblComment3.StylePriority.UseTextAlignment = false;
		lblComment3.Text = "Comment 3:";
		lblComment3.TextAlignment = TextAlignment.BottomLeft;
		lblComment3.WordWrap = false;
		xrLabel4.BorderColor = Color.Black;
		xrLabel4.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel4.Borders = BorderSide.Bottom;
		xrLabel4.CanGrow = false;
		xrLabel4.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadTeacherComments]")
		});
		xrLabel4.Font = new DXFont("Tahoma", 11f);
		xrLabel4.ForeColor = Color.Black;
		xrLabel4.LocationFloat = new PointFloat(0f, 23f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(130, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(778.4719f, 23f);
		xrLabel4.StylePriority.UseBorderColor = false;
		xrLabel4.StylePriority.UseBorderDashStyle = false;
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseForeColor = false;
		xrLabel4.StylePriority.UsePadding = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.TextAlignment = TextAlignment.BottomLeft;
		xrLabel4.WordWrap = false;
		cashOnAccount.Description = "CashOnAccount";
		cashOnAccount.Name = "cashOnAccount";
		cashOnAccount.Type = typeof(double);
		cashOnAccount.ValueInfo = "0";
		cashOnAccount.Visible = false;
		footerPromotion.Controls.AddRange(new XRControl[1] { lblPromoStatus });
		footerPromotion.HeightF = 27.08333f;
		footerPromotion.Level = 1;
		footerPromotion.Name = "footerPromotion";
		lblPromoStatus.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[promoStatus]")
		});
		lblPromoStatus.Font = new DXFont("Tahoma", 11f, DXFontStyle.Bold);
		lblPromoStatus.ForeColor = Color.Black;
		lblPromoStatus.LocationFloat = new PointFloat(116.3798f, 0f);
		lblPromoStatus.Name = "lblPromoStatus";
		lblPromoStatus.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblPromoStatus.SizeF = new SizeF(546.2404f, 23f);
		lblPromoStatus.StylePriority.UseFont = false;
		lblPromoStatus.StylePriority.UseForeColor = false;
		lblPromoStatus.StylePriority.UseTextAlignment = false;
		lblPromoStatus.Text = "lblPromoStatus";
		lblPromoStatus.TextAlignment = TextAlignment.MiddleCenter;
		footerCommentHeader.Controls.AddRange(new XRControl[1] { xrLabel1 });
		footerCommentHeader.HeightF = 23f;
		footerCommentHeader.Level = 2;
		footerCommentHeader.Name = "footerCommentHeader";
		footerCommentHeader.PrintAtBottom = true;
		xrLabel1.Font = new DXFont("Tahoma", 9.75f);
		xrLabel1.LocationFloat = new PointFloat(0f, 0f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(295.2999f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Remarks";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		headerGroup.Controls.AddRange(new XRControl[1] { tableHeader });
		headerGroup.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("StudentNumber", XRColumnSortOrder.Ascending)
		});
		headerGroup.HeightF = 50f;
		headerGroup.Name = "headerGroup";
		term.Description = "Term";
		term.Name = "term";
		term.Visible = false;
		base.Bands.AddRange(new Band[9] { Detail, topMarginBand1, bottomMarginBand1, footerTotalPoints, footerComment1, footerComment3, footerPromotion, footerCommentHeader, headerGroup });
		base.CalculatedFields.AddRange(new CalculatedField[1] { TotalPoints });
		base.ComponentStorage.AddRange(new IComponent[1] { aLevelReportSub1 });
		base.DataAdapter = adapterALevelReportSub;
		base.DataMember = "ALevelReportSub";
		base.DataSource = aLevelReportSub1;
		FilterString = "[StudentNumber] = ?StudentNo And [ClassId] = ?classId And [SemesterId] = ?term";
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 600;
		base.PageWidth = 780;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[4] { StudentNo, classId, cashOnAccount, term });
		base.ReportPrintOptions.PrintOnEmptyDataSource = false;
		base.RollPaper = true;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 1f;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "21.2";
		((ISupportInitialize)tableValue).EndInit();
		((ISupportInitialize)aLevelReportSub1).EndInit();
		((ISupportInitialize)tableHeader).EndInit();
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
