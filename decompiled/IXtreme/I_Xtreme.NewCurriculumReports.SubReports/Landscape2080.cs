using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.GradingScales;
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

public class Landscape2080 : XtraReport
{
	private OLevelGradingScale gs;

	private double _out_3 = 0.0;

	private IContainer components = null;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private DetailBand Detail;

	private XRTable xrTable2;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell3;

	private XRTableCell xrTableCell4;

	private XRTableRow xrTableRow8;

	private XRTableCell xrTableCell16;

	private XRTableCell xrTableCell23;

	private XRTableCell xrTableCell24;

	private XRTableCell xrTableCell25;

	private XRTableCell xrTableCell38;

	private XRTableCell xrTableCell42;

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell5;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed;

	private Parameter studNumber;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell29;

	private XRTableCell xrTableCell28;

	private PageHeaderBand PageHeader;

	private GroupFooterBand GroupFooter3;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell33;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell34;

	private GroupFooterBand GroupFooter1;

	private XRTable xrTable4;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell39;

	private XRTableCell xrTableCell43;

	private GroupFooterBand GroupFooter2;

	private XRShape xrShape1;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell15;

	private NewCurriculumSubReport newCurriculumSubReport1;

	private GroupFooterBand GroupFooter4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel4;

	private GroupFooterBand GroupFooter5;

	private XRLabel xrLabel14;

	private XRLabel xrLabel19;

	public Landscape2080()
	{
		InitializeComponent();
	}

	private void xrTableCell19_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("Score1");
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

	private void xrTableCell20_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("Score2");
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

	private void xrTableCell22_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("Score3");
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

	private void xrTableCell2_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("Score4");
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

	private void xrTableCell6_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell6.Text == "0")
		{
			xrTableCell6.Text = string.Empty;
		}
	}

	private void xrTableCell12_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell12.Text == "0")
		{
			xrTableCell12.Text = string.Empty;
		}
	}

	private void xrTableCell18_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell18.Text == "0")
		{
			xrTableCell18.Text = string.Empty;
		}
	}

	private void xrTableCell3_AfterPrint(object sender, EventArgs e)
	{
	}

	private void xrTableCell11_BeforePrint_1(object sender, CancelEventArgs e)
	{
		if (xrTableCell11.Text == "0")
		{
			xrTableCell11.Text = string.Empty;
		}
	}

	private void xrTableCell13_BeforePrint_1(object sender, CancelEventArgs e)
	{
		if (xrTableCell13.Text == "0")
		{
			xrTableCell13.Text = string.Empty;
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
		XRSummary xRSummary = new XRSummary();
		XRSummary xRSummary2 = new XRSummary();
		ShapePolygon shape = new ShapePolygon();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow3 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell13 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTable2 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell31 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		adapterNewCurriculumSubAssessed = new adapterNewCurriculumSubAssessed();
		studNumber = new Parameter();
		PageHeader = new PageHeaderBand();
		GroupFooter3 = new GroupFooterBand();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell32 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		GroupFooter1 = new GroupFooterBand();
		xrTable4 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		GroupFooter2 = new GroupFooterBand();
		xrShape1 = new XRShape();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		newCurriculumSubReport1 = new NewCurriculumSubReport();
		GroupFooter4 = new GroupFooterBand();
		xrLabel3 = new XRLabel();
		xrLabel4 = new XRLabel();
		GroupFooter5 = new GroupFooterBand();
		xrLabel14 = new XRLabel();
		xrLabel19 = new XRLabel();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)newCurriculumSubReport1).BeginInit();
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
		xrTable1.BorderColor = Color.DimGray;
		xrTable1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTable1.Font = new DXFont("Tahoma", 9f);
		xrTable1.LocationFloat = new PointFloat(0f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable1.Rows.AddRange(new XRTableRow[1] { xrTableRow3 });
		xrTable1.SizeF = new SizeF(704f, 25f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow3.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell1, xrTableCell19, xrTableCell20, xrTableCell22, xrTableCell6, xrTableCell12, xrTableCell18, xrTableCell26, xrTableCell13, xrTableCell11,
			xrTableCell9, xrTableCell5
		});
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 9f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 3.5037432007318237;
		xrTableCell1.WordWrap = false;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score1]")
		});
		xrTableCell19.Font = new DXFont("Tahoma", 9f);
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.Text = "xrTableCell19";
		xrTableCell19.Weight = 1.001069524854926;
		xrTableCell19.WordWrap = false;
		xrTableCell19.BeforePrint += xrTableCell19_BeforePrint;
		xrTableCell20.CanGrow = false;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score2]")
		});
		xrTableCell20.Font = new DXFont("Tahoma", 9f);
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.Text = "xrTableCell20";
		xrTableCell20.Weight = 1.0010695266693377;
		xrTableCell20.WordWrap = false;
		xrTableCell20.BeforePrint += xrTableCell20_BeforePrint;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score3]")
		});
		xrTableCell22.Font = new DXFont("Tahoma", 9f);
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.Text = "xrTableCell22";
		xrTableCell22.Weight = 1.0010694931272799;
		xrTableCell22.WordWrap = false;
		xrTableCell22.BeforePrint += xrTableCell22_BeforePrint;
		xrTableCell6.CanGrow = false;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OutOfTwenty]")
		});
		xrTableCell6.Font = new DXFont("Tahoma", 9f);
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.Text = "xrTableCell6";
		xrTableCell6.Weight = 1.0010694926186199;
		xrTableCell6.WordWrap = false;
		xrTableCell6.BeforePrint += xrTableCell6_BeforePrint;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETA80]")
		});
		xrTableCell12.Font = new DXFont("Tahoma", 9f);
		xrTableCell12.Multiline = true;
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.Text = "xrTableCell12";
		xrTableCell12.Weight = 1.0010695057375727;
		xrTableCell12.BeforePrint += xrTableCell12_BeforePrint;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETAv]")
		});
		xrTableCell18.Font = new DXFont("Tahoma", 9f);
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.Text = "xrTableCell18";
		xrTableCell18.Weight = 1.0511229757410936;
		xrTableCell18.WordWrap = false;
		xrTableCell18.BeforePrint += xrTableCell18_BeforePrint;
		xrTableCell26.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[P5]")
		});
		xrTableCell26.Font = new DXFont("Tahoma", 9f);
		xrTableCell26.Multiline = true;
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.Text = "xrTableCell26";
		xrTableCell26.Weight = 1.2513368768524522;
		xrTableCell13.CanGrow = false;
		xrTableCell13.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score100]")
		});
		xrTableCell13.Font = new DXFont("Tahoma", 9f);
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.Text = "xrTableCell13";
		xrTableCell13.Weight = 1.2429076276477076;
		xrTableCell13.WordWrap = false;
		xrTableCell13.BeforePrint += xrTableCell13_BeforePrint_1;
		xrTableCell11.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Identifier100]")
		});
		xrTableCell11.Font = new DXFont("Tahoma", 9f);
		xrTableCell11.Multiline = true;
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.Text = "xrTableCell11";
		xrTableCell11.Weight = 1.6878005184353149;
		xrTableCell11.BeforePrint += xrTableCell11_BeforePrint_1;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Descriptor100]")
		});
		xrTableCell9.Font = new DXFont("Tahoma", 9f);
		xrTableCell9.Multiline = true;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.Text = "xrTableCell9";
		xrTableCell9.Weight = 2.897286288232819;
		xrTableCell5.CanGrow = false;
		xrTableCell5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell5.Font = new DXFont("Tahoma", 9f);
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.Text = "xrTableCell5";
		xrTableCell5.Weight = 0.9792782671505966;
		xrTableCell5.WordWrap = false;
		xrTable2.BorderColor = Color.DimGray;
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow5, xrTableRow8 });
		xrTable2.SizeF = new SizeF(704f, 50f);
		xrTable2.StylePriority.UseBorderColor = false;
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow5.Cells.AddRange(new XRTableCell[8] { xrTableCell3, xrTableCell4, xrTableCell21, xrTableCell29, xrTableCell28, xrTableCell2, xrTableCell30, xrTableCell31 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell3.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell3.CanGrow = false;
		xrTableCell3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrTableCell3.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell3.StylePriority.UseBorders = false;
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell3.Weight = 2.9501872238902394;
		xrTableCell3.WordWrap = false;
		xrTableCell3.AfterPrint += xrTableCell3_AfterPrint;
		xrTableCell4.Font = new DXFont("Cascadia Code", 10f);
		xrTableCell4.Multiline = true;
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "Progress Ass.";
		xrTableCell4.Weight = 2.528731899706723;
		xrTableCell21.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell21.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell21.Multiline = true;
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseBorders = false;
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.StylePriority.UseTextAlignment = false;
		xrTableCell21.Text = "A1";
		xrTableCell21.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell21.Weight = 0.8429106486407942;
		xrTableCell29.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell29.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell29.Multiline = true;
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseBorders = false;
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.StylePriority.UseTextAlignment = false;
		xrTableCell29.Text = "A2";
		xrTableCell29.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell29.Weight = 0.8429106486407942;
		xrTableCell28.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell28.CanGrow = false;
		xrTableCell28.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UseTextAlignment = false;
		xrTableCell28.Text = "TT";
		xrTableCell28.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell28.Weight = 0.8850561762501492;
		xrTableCell28.WordWrap = false;
		xrTableCell2.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell2.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell2.Multiline = true;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseBorders = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "Grade";
		xrTableCell2.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell2.Weight = 1.0536383045319078;
		xrTableCell30.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell30.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell30.Multiline = true;
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.StylePriority.UseBorders = false;
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.StylePriority.UseTextAlignment = false;
		xrTableCell30.Text = "Out";
		xrTableCell30.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell30.Weight = 1.0465419234174873;
		xrTableCell31.Multiline = true;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Weight = 4.685250463716677;
		xrTableRow8.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell16, xrTableCell23, xrTableCell24, xrTableCell25, xrTableCell38, xrTableCell8, xrTableCell17, xrTableCell15, xrTableCell14, xrTableCell7,
			xrTableCell10, xrTableCell42
		});
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell16.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell16.CanGrow = false;
		xrTableCell16.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell16.StylePriority.UseBorders = false;
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "SUBJECT";
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 3.0910497084391313;
		xrTableCell16.WordWrap = false;
		xrTableCell23.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.Text = "C1";
		xrTableCell23.Weight = 0.8831570458017648;
		xrTableCell24.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.Text = "C2";
		xrTableCell24.Weight = 0.8831570399392941;
		xrTableCell25.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.Text = "C3";
		xrTableCell25.Weight = 0.8831570514183529;
		xrTableCell38.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell38.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell38.Multiline = true;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseBorders = false;
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.StylePriority.UseTextAlignment = false;
		xrTableCell38.Text = "20%";
		xrTableCell38.TextAlignment = TextAlignment.TopCenter;
		xrTableCell38.Weight = 0.8831570297927078;
		xrTableCell8.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell8.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseBorders = false;
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.StylePriority.UseTextAlignment = false;
		xrTableCell8.Text = "80%";
		xrTableCell8.TextAlignment = TextAlignment.TopCenter;
		xrTableCell8.Weight = 0.883157061112577;
		xrTableCell17.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell17.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell17.Multiline = true;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseBorders = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "100%";
		xrTableCell17.TextAlignment = TextAlignment.TopCenter;
		xrTableCell17.Weight = 0.9273148813206473;
		xrTableCell15.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell15.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBorders = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.Weight = 1.1039463331527397;
		xrTableCell14.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell14.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseBorders = false;
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.Text = "of 3";
		xrTableCell14.TextAlignment = TextAlignment.TopCenter;
		xrTableCell14.Weight = 1.0965110226503705;
		xrTableCell7.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.Text = "Identifier";
		xrTableCell7.Weight = 1.4889996209485026;
		xrTableCell10.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.Text = "Descriptor";
		xrTableCell10.Weight = 2.5560256782136945;
		xrTableCell42.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell42.Multiline = true;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.StylePriority.UseFont = false;
		xrTableCell42.Text = "TR";
		xrTableCell42.Weight = 0.8639315825598949;
		adapterNewCurriculumSubAssessed.ClearBeforeFill = true;
		studNumber.Description = "StudNumber";
		studNumber.Enabled = false;
		studNumber.Name = "studNumber";
		studNumber.Visible = false;
		PageHeader.Controls.AddRange(new XRControl[1] { xrTable2 });
		PageHeader.HeightF = 50f;
		PageHeader.Name = "PageHeader";
		GroupFooter3.Controls.AddRange(new XRControl[1] { xrTable3 });
		GroupFooter3.HeightF = 25f;
		GroupFooter3.Name = "GroupFooter3";
		xrTable3.BorderColor = Color.Black;
		xrTable3.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable3.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable3.ForeColor = Color.Black;
		xrTable3.LocationFloat = new PointFloat(0f, 0f);
		xrTable3.Name = "xrTable3";
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow4 });
		xrTable3.SizeF = new SizeF(704f, 25f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseForeColor = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow4.Cells.AddRange(new XRTableCell[4] { xrTableCell32, xrTableCell33, xrTableCell37, xrTableCell34 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell32.BorderColor = Color.DimGray;
		xrTableCell32.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell32.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell32.ForeColor = Color.Black;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell32.StylePriority.UseBorderColor = false;
		xrTableCell32.StylePriority.UseBorders = false;
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.StylePriority.UseForeColor = false;
		xrTableCell32.StylePriority.UsePadding = false;
		xrTableCell32.Text = "AVERAGE SCORES";
		xrTableCell32.Weight = 0.7421592332218413;
		xrTableCell33.BorderColor = Color.DimGray;
		xrTableCell33.Borders = BorderSide.Top | BorderSide.Right | BorderSide.Bottom;
		xrTableCell33.CanGrow = false;
		xrTableCell33.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumAvg([ETAv])")
		});
		xrTableCell33.Font = new DXFont("Tahoma", 10f);
		xrTableCell33.ForeColor = Color.Black;
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell33.StylePriority.UseBorderColor = false;
		xrTableCell33.StylePriority.UseBorders = false;
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.StylePriority.UseForeColor = false;
		xrTableCell33.StylePriority.UsePadding = false;
		xrTableCell33.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell33.Summary = xRSummary;
		xrTableCell33.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell33.TextFormatString = "{0:n2}";
		xrTableCell33.Weight = 0.202856867432681;
		xrTableCell33.WordWrap = false;
		xrTableCell37.BorderColor = Color.DimGray;
		xrTableCell37.Borders = BorderSide.All;
		xrTableCell37.CanGrow = false;
		xrTableCell37.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Substring(sumAvg([Score100]),0,4)")
		});
		xrTableCell37.Font = new DXFont("Tahoma", 10f);
		xrTableCell37.ForeColor = Color.Black;
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell37.StylePriority.UseBorderColor = false;
		xrTableCell37.StylePriority.UseBorders = false;
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.StylePriority.UseForeColor = false;
		xrTableCell37.StylePriority.UsePadding = false;
		xrTableCell37.StylePriority.UseTextAlignment = false;
		xRSummary2.Running = SummaryRunning.Page;
		xrTableCell37.Summary = xRSummary2;
		xrTableCell37.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell37.Weight = 0.2465530926388666;
		xrTableCell37.WordWrap = false;
		xrTableCell34.BorderColor = Color.DimGray;
		xrTableCell34.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
		xrTableCell34.Font = new DXFont("Tahoma", 10f);
		xrTableCell34.ForeColor = Color.Black;
		xrTableCell34.Multiline = true;
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell34.StylePriority.UseBorderColor = false;
		xrTableCell34.StylePriority.UseBorders = false;
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.StylePriority.UseForeColor = false;
		xrTableCell34.StylePriority.UsePadding = false;
		xrTableCell34.Weight = 0.5500312007168433;
		GroupFooter1.Controls.AddRange(new XRControl[1] { xrTable4 });
		GroupFooter1.HeightF = 30f;
		GroupFooter1.Level = 1;
		GroupFooter1.Name = "GroupFooter1";
		xrTable4.BorderColor = Color.Black;
		xrTable4.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable4.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable4.ForeColor = Color.Black;
		xrTable4.LocationFloat = new PointFloat(0f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Rows.AddRange(new XRTableRow[1] { xrTableRow1 });
		xrTable4.SizeF = new SizeF(704f, 25f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseForeColor = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[2] { xrTableCell39, xrTableCell43 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
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
		xrTableCell39.Weight = 0.94501610253502;
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
		xrTableCell43.Weight = 0.796584291475212;
		GroupFooter2.Controls.AddRange(new XRControl[3] { xrShape1, xrLabel2, xrLabel1 });
		GroupFooter2.HeightF = 33.54168f;
		GroupFooter2.Level = 2;
		GroupFooter2.Name = "GroupFooter2";
		xrShape1.Angle = 270;
		xrShape1.BorderColor = Color.DarkGray;
		xrShape1.FillColor = Color.Black;
		xrShape1.LocationFloat = new PointFloat(153.875f, 2.708372f);
		xrShape1.Name = "xrShape1";
		xrShape1.Shape = shape;
		xrShape1.SizeF = new SizeF(23f, 23f);
		xrShape1.StylePriority.UseBorderColor = false;
		xrLabel2.BackColor = Color.LightGray;
		xrLabel2.Borders = BorderSide.All;
		xrLabel2.Font = new DXFont("Arial", 12f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(0f, 2.708371f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(153.875f, 23f);
		xrLabel2.StylePriority.UseBackColor = false;
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "Key to terms used";
		xrLabel2.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.Font = new DXFont("Arial", 12f, DXFontStyle.Bold);
		xrLabel1.LocationFloat = new PointFloat(176.875f, 2.708371f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(517.125f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "0.9 - 1.49: Basic, 1.5 - 2.49: Moderate, 2.5 - 3.0: Outstanding";
		xrLabel1.TextAlignment = TextAlignment.MiddleCenter;
		newCurriculumSubReport1.DataSetName = "NewCurriculumSubReport";
		newCurriculumSubReport1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		GroupFooter4.Controls.AddRange(new XRControl[2] { xrLabel3, xrLabel4 });
		GroupFooter4.HeightF = 53f;
		GroupFooter4.Level = 3;
		GroupFooter4.Name = "GroupFooter4";
		xrLabel3.BorderColor = Color.Black;
		xrLabel3.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel3.Borders = BorderSide.Bottom;
		xrLabel3.CanGrow = false;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassteacherRemarkFA]")
		});
		xrLabel3.Font = new DXFont("Tahoma", 9f);
		xrLabel3.ForeColor = Color.Black;
		xrLabel3.LocationFloat = new PointFloat(0.0001220703f, 25f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(703.9999f, 23f);
		xrLabel3.StylePriority.UseBorderColor = false;
		xrLabel3.StylePriority.UseBorderDashStyle = false;
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseForeColor = false;
		xrLabel3.StylePriority.UsePadding = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.TextAlignment = TextAlignment.BottomCenter;
		xrLabel3.WordWrap = false;
		xrLabel4.BackColor = Color.Transparent;
		xrLabel4.BorderColor = Color.Black;
		xrLabel4.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel4.Borders = BorderSide.None;
		xrLabel4.CanGrow = false;
		xrLabel4.Font = new DXFont("Tahoma", 11f);
		xrLabel4.ForeColor = Color.Black;
		xrLabel4.LocationFloat = new PointFloat(0.0001220703f, 0f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(175f, 23f);
		xrLabel4.StylePriority.UseBackColor = false;
		xrLabel4.StylePriority.UseBorderColor = false;
		xrLabel4.StylePriority.UseBorderDashStyle = false;
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseForeColor = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Classteacher:";
		xrLabel4.TextAlignment = TextAlignment.BottomLeft;
		xrLabel4.WordWrap = false;
		GroupFooter5.Controls.AddRange(new XRControl[2] { xrLabel14, xrLabel19 });
		GroupFooter5.HeightF = 53f;
		GroupFooter5.Level = 4;
		GroupFooter5.Name = "GroupFooter5";
		xrLabel14.BorderColor = Color.Black;
		xrLabel14.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel14.Borders = BorderSide.Bottom;
		xrLabel14.CanGrow = false;
		xrLabel14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadteacherRemarkFA]")
		});
		xrLabel14.Font = new DXFont("Tahoma", 9f);
		xrLabel14.ForeColor = Color.Black;
		xrLabel14.LocationFloat = new PointFloat(0.0001220703f, 25f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(703.9999f, 23f);
		xrLabel14.StylePriority.UseBorderColor = false;
		xrLabel14.StylePriority.UseBorderDashStyle = false;
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseForeColor = false;
		xrLabel14.StylePriority.UsePadding = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.TextAlignment = TextAlignment.BottomCenter;
		xrLabel14.WordWrap = false;
		xrLabel19.BackColor = Color.Transparent;
		xrLabel19.BorderColor = Color.Black;
		xrLabel19.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel19.Borders = BorderSide.None;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Tahoma", 11f);
		xrLabel19.ForeColor = Color.Black;
		xrLabel19.LocationFloat = new PointFloat(0.0001220703f, 0f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(175f, 23f);
		xrLabel19.StylePriority.UseBackColor = false;
		xrLabel19.StylePriority.UseBorderColor = false;
		xrLabel19.StylePriority.UseBorderDashStyle = false;
		xrLabel19.StylePriority.UseBorders = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Headteacher:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.WordWrap = false;
		base.Bands.AddRange(new Band[9] { TopMargin, BottomMargin, Detail, PageHeader, GroupFooter3, GroupFooter1, GroupFooter2, GroupFooter4, GroupFooter5 });
		base.ComponentStorage.AddRange(new IComponent[1] { newCurriculumSubReport1 });
		base.DataAdapter = adapterNewCurriculumSubAssessed;
		base.DataMember = "tbl_Scores_OL_Report";
		base.DataSource = newCurriculumSubReport1;
		FilterString = "[StudentNumber] = ?studNumber";
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(0f, 0f, 0f, 0.2083461f);
		base.PageColor = Color.Transparent;
		base.PageHeight = 505;
		base.PageWidth = 704;
		base.PaperKind = DXPaperKind.Custom;
		base.ParameterPanelLayoutItems.AddRange(new ParameterPanelLayoutItem[1]
		{
			new ParameterLayoutItem(studNumber)
		});
		base.Parameters.AddRange(new Parameter[1] { studNumber });
		base.RollPaper = true;
		base.Version = "23.2";
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)newCurriculumSubReport1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
