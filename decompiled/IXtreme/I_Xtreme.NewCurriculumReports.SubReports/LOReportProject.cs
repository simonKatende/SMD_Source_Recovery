using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.NewCurriculumReports.ReportDatasets;
using I_Xtreme.NewCurriculumReports.ReportDatasets.NewCurriculumSubReportTableAdapters;

namespace I_Xtreme.NewCurriculumReports.SubReports;

public class LOReportProject : XtraReport
{
	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private GroupHeaderBand GroupHeader1;

	private XRTable xrTable2;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell4;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell38;

	private XRTableCell xrTableCell42;

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell5;

	private NewCurriculumSubReport newCurriculumSubReport1;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed;

	private NewCurriculumSubReport newCurriculumSubReport2;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed1;

	private NewCurriculumSubReport newCurriculumSubReport3;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed2;

	private CalculatedField calculatedField1;

	private GroupFooterBand GroupFooter1;

	private XRTable xrTable3;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell17;

	private GroupFooterBand GroupFooter2;

	private XRTable xrTable4;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell39;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell18;

	public Parameter studNumber;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed3;

	private GroupFooterBand footerClassTeacher;

	private GroupFooterBand footerHeadTeacher;

	private XRShape xrShape1;

	private XRLabel lblClassteacherComment;

	private XRShape xrShape2;

	private XRLabel xrLabel9;

	private XRLabel xrLabel17;

	private XRShape xrShape4;

	private XRLabel lblHeadteacherComment;

	private XRLabel xrLabel19;

	private XRLabel xrLabel15;

	private XRShape xrShape3;

	private NewCurriculumSubReport newCurriculumSubReport4;

	private Parameter OtherFeesRequirements;

	private NewCurriculumSubReport newCurriculumSubReport5;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed4;

	private XRLabel xrLabel1;

	private CalculatedField AverageScore;

	public LOReportProject()
	{
		InitializeComponent();
		footerClassTeacher.Visible = ReportCustomization.Comment1;
		footerHeadTeacher.Visible = ReportCustomization.Comment2;
	}

	private void xrTableCell19_BeforePrint(object sender, CancelEventArgs e)
	{
		try
		{
			if (!ReportParameters.ShadeReport)
			{
				return;
			}
			XRTableCell xRTableCell = sender as XRTableCell;
			object currentColumnValue = GetCurrentColumnValue("U1");
			if (currentColumnValue != null)
			{
				if (currentColumnValue.ToString() == "x")
				{
					xRTableCell.BackColor = Color.LightGray;
					xRTableCell.ForeColor = Color.LightGray;
				}
				else
				{
					xRTableCell.BackColor = Color.Transparent;
					xRTableCell.ForeColor = Color.Black;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void xrTableCell22_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("U2");
		if (currentColumnValue != null)
		{
			if (currentColumnValue.ToString() == "x")
			{
				xRTableCell.BackColor = Color.LightGray;
				xRTableCell.ForeColor = Color.LightGray;
			}
			else
			{
				xRTableCell.BackColor = Color.Transparent;
				xRTableCell.ForeColor = Color.Black;
			}
		}
	}

	private void xrTableCell10_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell10.Text == "0")
		{
			xrTableCell10.Text = string.Empty;
		}
	}

	private void xrTableCell8_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell8.Text == "0")
		{
			xrTableCell8.Text = string.Empty;
		}
	}

	private void NewCurriculumSubUpperLO_BeforePrint(object sender, CancelEventArgs e)
	{
	}

	private void xrLabel1_BeforePrint(object sender, CancelEventArgs e)
	{
		base.Parameters["OtherFeesRequirements"].Value = xrLabel1.Text;
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
		XRSummary xRSummary = new XRSummary();
		ShapeLine shape = new ShapeLine();
		ShapeRectangle shape2 = new ShapeRectangle();
		ShapeLine shape3 = new ShapeLine();
		ShapeRectangle shape4 = new ShapeRectangle();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow3 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrTable2 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		studNumber = new Parameter();
		calculatedField1 = new CalculatedField();
		GroupFooter1 = new GroupFooterBand();
		xrTable3 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		GroupFooter2 = new GroupFooterBand();
		xrTable4 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		footerClassTeacher = new GroupFooterBand();
		xrLabel1 = new XRLabel();
		lblClassteacherComment = new XRLabel();
		xrShape2 = new XRShape();
		xrLabel9 = new XRLabel();
		xrLabel17 = new XRLabel();
		xrShape1 = new XRShape();
		footerHeadTeacher = new GroupFooterBand();
		lblHeadteacherComment = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrShape3 = new XRShape();
		xrShape4 = new XRShape();
		OtherFeesRequirements = new Parameter();
		newCurriculumSubReport5 = new NewCurriculumSubReport();
		adapterNewCurriculumSubAssessed4 = new adapterNewCurriculumSubAssessed();
		AverageScore = new CalculatedField();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)newCurriculumSubReport5).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 0.2083461f;
		BottomMargin.Name = "BottomMargin";
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		Detail.SortFields.AddRange(new GroupField[1]
		{
			new GroupField("SubjectId", XRColumnSortOrder.Ascending)
		});
		xrTable1.BackColor = Color.Transparent;
		xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTable1.Font = new DXFont("Tahoma", 8f);
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow3 });
		xrTable1.SizeF = new SizeF(778f, 25f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow3.Cells.AddRange(new XRTableCell[8] { xrTableCell1, xrTableCell19, xrTableCell20, xrTableCell22, xrTableCell10, xrTableCell8, xrTableCell6, xrTableCell5 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 9.5f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 3.5643565049840884;
		xrTableCell1.WordWrap = false;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[T1]")
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.TextFormatString = "{0:N1}";
		xrTableCell19.Weight = 0.7931991433625968;
		xrTableCell19.WordWrap = false;
		xrTableCell19.BeforePrint += xrTableCell19_BeforePrint;
		xrTableCell20.CanGrow = false;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[P1]")
		});
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.TextFormatString = "{0:N1}";
		xrTableCell20.Weight = 0.7931993955138043;
		xrTableCell20.WordWrap = false;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[T2]")
		});
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.TextFormatString = "{0:N1}";
		xrTableCell22.Weight = 0.7931991168316415;
		xrTableCell22.WordWrap = false;
		xrTableCell22.BeforePrint += xrTableCell22_BeforePrint;
		xrTableCell10.CanGrow = false;
		xrTableCell10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ProjLO]")
		});
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "xrTableCell10";
		xrTableCell10.Weight = 0.7931991265249303;
		xrTableCell10.WordWrap = false;
		xrTableCell10.BeforePrint += xrTableCell10_BeforePrint;
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Weight = 1.221168066750537;
		xrTableCell8.BeforePrint += xrTableCell8_BeforePrint;
		xrTableCell6.CanGrow = false;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ProjRemark]")
		});
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "xrTableCell6";
		xrTableCell6.Weight = 6.041678630149936;
		xrTableCell6.WordWrap = false;
		xrTableCell5.CanGrow = false;
		xrTableCell5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.Text = "xrTableCell5";
		xrTableCell5.Weight = 0.6930693042190524;
		xrTableCell5.WordWrap = false;
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrTable2 });
		GroupHeader1.HeightF = 50f;
		GroupHeader1.KeepTogether = true;
		GroupHeader1.Name = "GroupHeader1";
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow5, xrTableRow8 });
		xrTable2.SizeF = new SizeF(778f, 50f);
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow5.Cells.AddRange(new XRTableCell[2] { xrTableCell3, xrTableCell4 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell3.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell3.CanGrow = false;
		xrTableCell3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrTableCell3.ForeColor = Color.Transparent;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell3.StylePriority.UseBorders = false;
		xrTableCell3.StylePriority.UseForeColor = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell3.Weight = 3.3962261041621025;
		xrTableCell3.WordWrap = false;
		xrTableCell4.Font = new DXFont("Cascadia Mono", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "End of Chapter Progress Assessment  Score Identifiers";
		xrTableCell4.Weight = 10.603773895837898;
		xrTableRow8.Cells.AddRange(new XRTableCell[8] { xrTableCell16, xrTableCell23, xrTableCell24, xrTableCell25, xrTableCell9, xrTableCell37, xrTableCell38, xrTableCell42 });
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell16.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell16.CanGrow = false;
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell16.StylePriority.UseBorders = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "SUBJECT";
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 3.5643565049840884;
		xrTableCell16.WordWrap = false;
		xrTableCell23.CanGrow = false;
		xrTableCell23.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold);
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.Text = "AO1";
		xrTableCell23.Weight = 0.7931991433625969;
		xrTableCell23.WordWrap = false;
		xrTableCell24.Font = new DXFont("Tahoma", 7f, DXFontStyle.Bold);
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.Text = "Project";
		xrTableCell24.Weight = 0.7931993955138043;
		xrTableCell25.CanGrow = false;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Text = "AO2";
		xrTableCell25.Weight = 0.7931991168316415;
		xrTableCell25.WordWrap = false;
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Text = "Av.";
		xrTableCell9.Weight = 0.7931991265249303;
		xrTableCell37.CanGrow = false;
		xrTableCell37.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.Text = "Grade";
		xrTableCell37.Weight = 1.221168066750537;
		xrTableCell37.WordWrap = false;
		xrTableCell38.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell38.Multiline = true;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.Text = "Facilitor Remark";
		xrTableCell38.Weight = 6.041678630149936;
		xrTableCell42.Multiline = true;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.Text = "TR";
		xrTableCell42.Weight = 0.6930693042190524;
		studNumber.Description = "StudNumber";
		studNumber.Name = "studNumber";
		studNumber.ValueInfo = "285028000001";
		calculatedField1.DataMember = "dsNewCurriculumSubAssessed";
		calculatedField1.Expression = "Sum([AvLO])";
		calculatedField1.FieldType = FieldType.Double;
		calculatedField1.Name = "calculatedField1";
		GroupFooter1.Controls.AddRange(new XRControl[1] { xrTable3 });
		GroupFooter1.HeightF = 25f;
		GroupFooter1.KeepTogether = true;
		GroupFooter1.Name = "GroupFooter1";
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(0f, 0f);
		xrTable3.Name = "xrTable3";
		xrTable3.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable3.SizeF = new SizeF(778f, 25f);
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[3] { xrTableCell12, xrTableCell17, xrTableCell18 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell12.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell12.Multiline = true;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.Text = "AVERAGE SCORES";
		xrTableCell12.Weight = 1.2105039504567763;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumAvg([ProjLO])")
		});
		xrTableCell17.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell17.Summary = xRSummary;
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.16153737440794805;
		xrTableCell17.WordWrap = false;
		xrTableCell18.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 1.6202462636619863;
		xrTableCell18.WordWrap = false;
		GroupFooter2.Controls.AddRange(new XRControl[1] { xrTable4 });
		GroupFooter2.HeightF = 31.91665f;
		GroupFooter2.KeepTogether = true;
		GroupFooter2.Level = 1;
		GroupFooter2.Name = "GroupFooter2";
		xrTable4.BorderColor = Color.Black;
		xrTable4.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable4.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable4.ForeColor = Color.Black;
		xrTable4.LocationFloat = new PointFloat(0f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Rows.AddRange(new XRTableRow[1] { xrTableRow2 });
		xrTable4.SizeF = new SizeF(775.9999f, 25f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseForeColor = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow2.Cells.AddRange(new XRTableCell[2] { xrTableCell39, xrTableCell43 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell39.BorderColor = Color.DimGray;
		xrTableCell39.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell39.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell39.ForeColor = Color.Black;
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell39.StylePriority.UseBorderColor = false;
		xrTableCell39.StylePriority.UseBorders = false;
		xrTableCell39.StylePriority.UseFont = false;
		xrTableCell39.StylePriority.UseForeColor = false;
		xrTableCell39.StylePriority.UsePadding = false;
		xrTableCell39.Text = "OVERALL PERFORMANCE";
		xrTableCell39.Weight = 0.8354018155852547;
		xrTableCell43.BorderColor = Color.DimGray;
		xrTableCell43.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell43.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformance]")
		});
		xrTableCell43.Font = new DXFont("Tahoma", 11f, DXFontStyle.Bold);
		xrTableCell43.ForeColor = Color.Black;
		xrTableCell43.Multiline = true;
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell43.StylePriority.UseBorderColor = false;
		xrTableCell43.StylePriority.UseBorders = false;
		xrTableCell43.StylePriority.UseFont = false;
		xrTableCell43.StylePriority.UseForeColor = false;
		xrTableCell43.StylePriority.UsePadding = false;
		xrTableCell43.StylePriority.UseTextAlignment = false;
		xrTableCell43.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell43.Weight = 0.9061985784249773;
		footerClassTeacher.Controls.AddRange(new XRControl[6] { xrLabel1, lblClassteacherComment, xrShape2, xrLabel9, xrLabel17, xrShape1 });
		footerClassTeacher.HeightF = 74f;
		footerClassTeacher.KeepTogether = true;
		footerClassTeacher.Level = 2;
		footerClassTeacher.Name = "footerClassTeacher";
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OtherRequirements]")
		});
		xrLabel1.LocationFloat = new PointFloat(622.9999f, 41.00002f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(100f, 23f);
		xrLabel1.Visible = false;
		xrLabel1.BeforePrint += xrLabel1_BeforePrint;
		lblClassteacherComment.CanGrow = false;
		lblClassteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassteacherRemark]")
		});
		lblClassteacherComment.Font = new DXFont("Tahoma", 11f);
		lblClassteacherComment.LocationFloat = new PointFloat(8.500006f, 41.00001f);
		lblClassteacherComment.Name = "lblClassteacherComment";
		lblClassteacherComment.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblClassteacherComment.SizeF = new SizeF(603.9999f, 23f);
		lblClassteacherComment.StylePriority.UseFont = false;
		lblClassteacherComment.WordWrap = false;
		xrShape2.LocationFloat = new PointFloat(617.9999f, 10f);
		xrShape2.Name = "xrShape2";
		xrShape2.Shape = shape;
		xrShape2.SizeF = new SizeF(2f, 64f);
		xrLabel9.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel9.LocationFloat = new PointFloat(622.9999f, 14f);
		xrLabel9.Multiline = true;
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(100f, 23f);
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "Signature";
		xrLabel9.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.BackColor = Color.Transparent;
		xrLabel17.BorderColor = Color.Black;
		xrLabel17.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.CanGrow = false;
		xrLabel17.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrLabel17.ForeColor = Color.Black;
		xrLabel17.LocationFloat = new PointFloat(9.000019f, 14.99999f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(451.0417f, 23f);
		xrLabel17.StylePriority.UseBackColor = false;
		xrLabel17.StylePriority.UseBorderColor = false;
		xrLabel17.StylePriority.UseBorderDashStyle = false;
		xrLabel17.StylePriority.UseBorders = false;
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseForeColor = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "Classteacher remarks:";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.WordWrap = false;
		xrShape1.LocationFloat = new PointFloat(0f, 10f);
		xrShape1.Name = "xrShape1";
		xrShape1.Shape = shape2;
		xrShape1.SizeF = new SizeF(774.9998f, 64f);
		footerHeadTeacher.Controls.AddRange(new XRControl[5] { lblHeadteacherComment, xrLabel19, xrLabel15, xrShape3, xrShape4 });
		footerHeadTeacher.HeightF = 74f;
		footerHeadTeacher.KeepTogether = true;
		footerHeadTeacher.Level = 3;
		footerHeadTeacher.Name = "footerHeadTeacher";
		lblHeadteacherComment.CanGrow = false;
		lblHeadteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadteacherRemark]")
		});
		lblHeadteacherComment.Font = new DXFont("Tahoma", 11f);
		lblHeadteacherComment.LocationFloat = new PointFloat(7.500013f, 42.99999f);
		lblHeadteacherComment.Name = "lblHeadteacherComment";
		lblHeadteacherComment.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblHeadteacherComment.SizeF = new SizeF(603.0001f, 23f);
		lblHeadteacherComment.StylePriority.UseFont = false;
		lblHeadteacherComment.WordWrap = false;
		xrLabel19.BackColor = Color.Transparent;
		xrLabel19.BorderColor = Color.Black;
		xrLabel19.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel19.Borders = BorderSide.None;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Consolas", 11f, DXFontStyle.Bold);
		xrLabel19.ForeColor = Color.Black;
		xrLabel19.LocationFloat = new PointFloat(9.000019f, 14.99999f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(451.0417f, 23f);
		xrLabel19.StylePriority.UseBackColor = false;
		xrLabel19.StylePriority.UseBorderColor = false;
		xrLabel19.StylePriority.UseBorderDashStyle = false;
		xrLabel19.StylePriority.UseBorders = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Headteacher remarks:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.WordWrap = false;
		xrLabel15.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel15.LocationFloat = new PointFloat(622.9999f, 14f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape3.LocationFloat = new PointFloat(617.9999f, 10f);
		xrShape3.Name = "xrShape3";
		xrShape3.Shape = shape3;
		xrShape3.SizeF = new SizeF(2f, 64f);
		xrShape4.LocationFloat = new PointFloat(0f, 10f);
		xrShape4.Name = "xrShape4";
		xrShape4.Shape = shape4;
		xrShape4.SizeF = new SizeF(774.9998f, 64f);
		OtherFeesRequirements.Description = "Other Fees Requirements";
		OtherFeesRequirements.Name = "OtherFeesRequirements";
		OtherFeesRequirements.Visible = false;
		newCurriculumSubReport5.DataSetName = "NewCurriculumSubReport";
		newCurriculumSubReport5.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterNewCurriculumSubAssessed4.ClearBeforeFill = true;
		AverageScore.DataMember = "tbl_Scores_OL_Report";
		AverageScore.Name = "AverageScore";
		base.Bands.AddRange(new Band[8] { TopMargin, BottomMargin, Detail, GroupHeader1, GroupFooter1, GroupFooter2, footerClassTeacher, footerHeadTeacher });
		base.CalculatedFields.AddRange(new CalculatedField[2] { calculatedField1, AverageScore });
		base.ComponentStorage.AddRange(new IComponent[1] { newCurriculumSubReport5 });
		base.DataAdapter = adapterNewCurriculumSubAssessed4;
		base.DataMember = "tbl_Scores_OL_Report";
		base.DataSource = newCurriculumSubReport5;
		FilterString = "[StudentNumber] = ?studNumber";
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(0f, 0f, 0f, 0.2083461f);
		base.PageColor = Color.Transparent;
		base.PageWidth = 778;
		base.PaperKind = DXPaperKind.Custom;
		base.ParameterPanelLayoutItems.AddRange(new ParameterPanelLayoutItem[2]
		{
			new ParameterLayoutItem(studNumber),
			new ParameterLayoutItem(OtherFeesRequirements)
		});
		base.Parameters.AddRange(new Parameter[2] { studNumber, OtherFeesRequirements });
		base.RollPaper = true;
		base.Version = "23.2";
		BeforePrint += NewCurriculumSubUpperLO_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)newCurriculumSubReport5).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
