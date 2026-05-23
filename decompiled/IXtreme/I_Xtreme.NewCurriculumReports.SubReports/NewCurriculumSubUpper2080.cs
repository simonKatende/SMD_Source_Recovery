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

public class NewCurriculumSubUpper2080 : XtraReport
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

	private NewCurriculumSubReport newCurriculumSubReport1;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed;

	private Parameter studNumber;

	private XRTableCell xrTableCell12;

	private XRTableCell xrTableCell8;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell29;

	private GroupFooterBand GroupFooter1;

	private XRTable xrTable3;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell31;

	private XRTableCell xrTableCell32;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell36;

	private XRTableCell xrTableCell37;

	private GroupFooterBand GroupFooter2;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell15;

	private XRLine xrLine1;

	private NewCurriculumSubReport newCurriculumSubReport2;

	private adapterNewCurriculumSubAssessed adapterNewCurriculumSubAssessed1;

	private GroupFooterBand footerClassTeacher;

	private GroupFooterBand footerHeadTeacher;

	private XRShape xrShape3;

	private XRLabel xrLabel17;

	private XRLabel lblClassteacherComment;

	private XRLabel xrLabel1;

	private XRShape xrShape2;

	private XRShape xrShape6;

	private XRLabel lblHeadteacherComment;

	private XRLabel xrLabel19;

	private XRLabel xrLabel15;

	private XRShape xrShape5;

	private XRLabel xrLabel2;

	private Parameter OtherFeesRequirements;

	private XRTable tblClassRanking;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell27;

	private XRTableCell colStreamPosition;

	private XRTableRow xrTableRow6;

	private XRTableCell colClass1;

	private XRTableCell colClass2;

	private XRTableCell colStream1;

	private XRTableCell colStream2;

	private XRTable xrTable4;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell39;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell40;

	private XRTableCell xrTableCell41;

	private XRTableCell xrTableCell43;

	private XRTableCell xrTableCell46;

	private XRTableCell xrTableCell44;

	private XRTableCell xrTableCell45;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell7;

	public NewCurriculumSubUpper2080()
	{
		InitializeComponent();
		footerClassTeacher.Visible = ReportCustomization.Comment1;
		footerHeadTeacher.Visible = ReportCustomization.Comment2;
	}

	private void xrTableCell20_BeforePrint(object sender, CancelEventArgs e)
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
		else
		{
			xRTableCell.BackColor = Color.LightGray;
			xRTableCell.ForeColor = Color.LightGray;
		}
	}

	private void xrTableCell22_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("U3");
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
		else
		{
			xRTableCell.BackColor = Color.LightGray;
			xRTableCell.ForeColor = Color.LightGray;
		}
	}

	private void xrTableCell41_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("U4");
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
		else
		{
			xRTableCell.BackColor = Color.LightGray;
			xRTableCell.ForeColor = Color.LightGray;
		}
	}

	private void xrTableCell18_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell18.Text == "0")
		{
			xrTableCell18.Text = string.Empty;
		}
	}

	private void xrTableCell35_BeforePrint(object sender, CancelEventArgs e)
	{
		if (xrTableCell35.Text == "0")
		{
			xrTableCell35.Text = string.Empty;
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

	private void xrLabel2_BeforePrint(object sender, CancelEventArgs e)
	{
		base.Parameters["OtherFeesRequirements"].Value = xrLabel2.Text;
	}

	private void NewCurriculumSubUpper2080_BeforePrint(object sender, CancelEventArgs e)
	{
		tblClassRanking.Visible = ReportCustomization.ShowPositionInClass;
	}

	private void xrTableCell9_BeforePrint(object sender, CancelEventArgs e)
	{
		if (!ReportParameters.ShadeReport)
		{
			return;
		}
		XRTableCell xRTableCell = sender as XRTableCell;
		object currentColumnValue = GetCurrentColumnValue("U5");
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
		else
		{
			xRTableCell.BackColor = Color.LightGray;
			xRTableCell.ForeColor = Color.LightGray;
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
		xrTableCell41 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell46 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrTable2 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell44 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell43 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableCell45 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		studNumber = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrLine1 = new XRLine();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		GroupFooter2 = new GroupFooterBand();
		xrTable4 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell40 = new XRTableCell();
		tblClassRanking = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell27 = new XRTableCell();
		colStreamPosition = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		colClass1 = new XRTableCell();
		colClass2 = new XRTableCell();
		colStream1 = new XRTableCell();
		colStream2 = new XRTableCell();
		newCurriculumSubReport2 = new NewCurriculumSubReport();
		adapterNewCurriculumSubAssessed1 = new adapterNewCurriculumSubAssessed();
		footerClassTeacher = new GroupFooterBand();
		xrLabel2 = new XRLabel();
		xrLabel17 = new XRLabel();
		lblClassteacherComment = new XRLabel();
		xrLabel1 = new XRLabel();
		xrShape2 = new XRShape();
		xrShape3 = new XRShape();
		footerHeadTeacher = new GroupFooterBand();
		lblHeadteacherComment = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrShape5 = new XRShape();
		xrShape6 = new XRShape();
		OtherFeesRequirements = new Parameter();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)tblClassRanking).BeginInit();
		((ISupportInitialize)newCurriculumSubReport2).BeginInit();
		((ISupportInitialize)this).BeginInit();
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		BottomMargin.HeightF = 0f;
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
		xrTable1.SizeF = new SizeF(776f, 25f);
		xrTable1.StylePriority.UseBackColor = false;
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow3.Cells.AddRange(new XRTableCell[13]
		{
			xrTableCell1, xrTableCell19, xrTableCell20, xrTableCell22, xrTableCell41, xrTableCell9, xrTableCell6, xrTableCell12, xrTableCell35, xrTableCell46,
			xrTableCell26, xrTableCell18, xrTableCell5
		});
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell1.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 9f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseBorders = false;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.Text = "xrTableCell1";
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 4.1918569072941505;
		xrTableCell1.WordWrap = false;
		xrTableCell19.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell19.CanGrow = false;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U1]")
		});
		xrTableCell19.Font = new DXFont("Tahoma", 9f);
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseBorders = false;
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.Weight = 1.0354541337168592;
		xrTableCell19.WordWrap = false;
		xrTableCell20.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell20.CanGrow = false;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U2]")
		});
		xrTableCell20.Font = new DXFont("Tahoma", 9f);
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseBorders = false;
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.Weight = 1.0354541229980059;
		xrTableCell20.WordWrap = false;
		xrTableCell20.BeforePrint += xrTableCell20_BeforePrint;
		xrTableCell22.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U3]")
		});
		xrTableCell22.Font = new DXFont("Tahoma", 9f);
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseBorders = false;
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.Weight = 1.0354541328311424;
		xrTableCell22.WordWrap = false;
		xrTableCell22.BeforePrint += xrTableCell22_BeforePrint;
		xrTableCell41.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell41.CanGrow = false;
		xrTableCell41.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U4]")
		});
		xrTableCell41.Font = new DXFont("Tahoma", 9f);
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.StylePriority.UseBorders = false;
		xrTableCell41.StylePriority.UseFont = false;
		xrTableCell41.Weight = 1.0354541344271082;
		xrTableCell41.WordWrap = false;
		xrTableCell41.BeforePrint += xrTableCell41_BeforePrint;
		xrTableCell9.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell9.CanGrow = false;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U5]")
		});
		xrTableCell9.Font = new DXFont("Tahoma", 9f);
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseBorders = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.Weight = 1.0354545787958152;
		xrTableCell9.WordWrap = false;
		xrTableCell9.BeforePrint += xrTableCell9_BeforePrint;
		xrTableCell6.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell6.CanGrow = false;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OutOfTwenty]")
		});
		xrTableCell6.Font = new DXFont("Tahoma", 9f);
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseBorders = false;
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.Text = "xrTableCell6";
		xrTableCell6.Weight = 1.0354533022465557;
		xrTableCell6.WordWrap = false;
		xrTableCell6.BeforePrint += xrTableCell6_BeforePrint;
		xrTableCell12.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell12.CanGrow = false;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETA80]")
		});
		xrTableCell12.Font = new DXFont("Tahoma", 9f);
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseBorders = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.Text = "xrTableCell12";
		xrTableCell12.Weight = 1.0354541009543001;
		xrTableCell12.WordWrap = false;
		xrTableCell12.BeforePrint += xrTableCell12_BeforePrint;
		xrTableCell35.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell35.CanGrow = false;
		xrTableCell35.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETAv]")
		});
		xrTableCell35.Font = new DXFont("Tahoma", 9f);
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.StylePriority.UseBorders = false;
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.Text = "xrTableCell35";
		xrTableCell35.Weight = 1.1131131847073594;
		xrTableCell35.WordWrap = false;
		xrTableCell35.BeforePrint += xrTableCell35_BeforePrint;
		xrTableCell46.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell46.CanGrow = false;
		xrTableCell46.CanShrink = true;
		xrTableCell46.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Concat([SubPosLOEOT],Concat('/',[TotalStudents]))\n")
		});
		xrTableCell46.Font = new DXFont("Tahoma", 8f);
		xrTableCell46.Name = "xrTableCell46";
		xrTableCell46.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTableCell46.StylePriority.UseBorders = false;
		xrTableCell46.StylePriority.UseFont = false;
		xrTableCell46.StylePriority.UsePadding = false;
		xrTableCell46.Text = "xrTableCell46";
		xrTableCell46.Weight = 1.1648858761554604;
		xrTableCell46.WordWrap = false;
		xrTableCell26.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell26.CanGrow = false;
		xrTableCell26.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Category]")
		});
		xrTableCell26.Font = new DXFont("Tahoma", 9f);
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.StylePriority.UseBorders = false;
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.Text = "xrTableCell26";
		xrTableCell26.Weight = 1.0354541091525764;
		xrTableCell26.WordWrap = false;
		xrTableCell18.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell18.CanGrow = false;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Descriptor100]")
		});
		xrTableCell18.Font = new DXFont("Tahoma", 9f);
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseBorders = false;
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.Text = "xrTableCell18";
		xrTableCell18.Weight = 4.516830594440898;
		xrTableCell18.WordWrap = false;
		xrTableCell18.BeforePrint += xrTableCell18_BeforePrint;
		xrTableCell5.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell5.CanGrow = false;
		xrTableCell5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell5.Font = new DXFont("Tahoma", 9f);
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseBorders = false;
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.Text = "xrTableCell5";
		xrTableCell5.Weight = 0.8174910611274078;
		xrTableCell5.WordWrap = false;
		GroupHeader1.Controls.AddRange(new XRControl[1] { xrTable2 });
		GroupHeader1.HeightF = 50f;
		GroupHeader1.Name = "GroupHeader1";
		xrTable2.BorderColor = Color.DimGray;
		xrTable2.Borders = BorderSide.All;
		xrTable2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTable2.LocationFloat = new PointFloat(0f, 0f);
		xrTable2.Name = "xrTable2";
		xrTable2.Padding = new PaddingInfo(2, 2, 0, 0, 96f);
		xrTable2.Rows.AddRange(new XRTableRow[2] { xrTableRow5, xrTableRow8 });
		xrTable2.SizeF = new SizeF(776f, 50f);
		xrTable2.StylePriority.UseBorderColor = false;
		xrTable2.StylePriority.UseBorders = false;
		xrTable2.StylePriority.UseFont = false;
		xrTable2.StylePriority.UseTextAlignment = false;
		xrTable2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow5.Cells.AddRange(new XRTableCell[9] { xrTableCell3, xrTableCell4, xrTableCell21, xrTableCell29, xrTableCell30, xrTableCell44, xrTableCell2, xrTableCell28, xrTableCell17 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell3.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell3.CanGrow = false;
		xrTableCell3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrTableCell3.Font = new DXFont("Tahoma", 2f, DXFontStyle.Bold);
		xrTableCell3.ForeColor = Color.Transparent;
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell3.StylePriority.UseBorders = false;
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.StylePriority.UseForeColor = false;
		xrTableCell3.StylePriority.UseTextAlignment = false;
		xrTableCell3.Text = "SUBJECT";
		xrTableCell3.TextAlignment = TextAlignment.BottomLeft;
		xrTableCell3.Weight = 6.2448224563605015;
		xrTableCell3.WordWrap = false;
		xrTableCell4.CanGrow = false;
		xrTableCell4.Font = new DXFont("Cascadia Code", 10f);
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "Ass. of Integration";
		xrTableCell4.Weight = 7.712842951190082;
		xrTableCell4.WordWrap = false;
		xrTableCell21.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell21.CanGrow = false;
		xrTableCell21.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseBorders = false;
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.Text = "A1";
		xrTableCell21.Weight = 1.5425686484997496;
		xrTableCell21.WordWrap = false;
		xrTableCell29.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell29.CanGrow = false;
		xrTableCell29.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseBorders = false;
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.Text = "EOT";
		xrTableCell29.Weight = 1.542568629051725;
		xrTableCell29.WordWrap = false;
		xrTableCell30.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell30.CanGrow = false;
		xrTableCell30.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell30.Name = "xrTableCell30";
		xrTableCell30.StylePriority.UseBorders = false;
		xrTableCell30.StylePriority.UseFont = false;
		xrTableCell30.StylePriority.UseTextAlignment = false;
		xrTableCell30.Text = "Total";
		xrTableCell30.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell30.Weight = 1.658261304088325;
		xrTableCell30.WordWrap = false;
		xrTableCell44.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell44.CanGrow = false;
		xrTableCell44.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell44.Name = "xrTableCell44";
		xrTableCell44.StylePriority.UseBorders = false;
		xrTableCell44.StylePriority.UseFont = false;
		xrTableCell44.StylePriority.UseTextAlignment = false;
		xrTableCell44.Text = "Sub.";
		xrTableCell44.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell44.Weight = 1.7353897225456432;
		xrTableCell44.WordWrap = false;
		xrTableCell2.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell2.CanGrow = false;
		xrTableCell2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseBorders = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "Grade";
		xrTableCell2.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell2.Weight = 1.542568709456165;
		xrTableCell2.WordWrap = false;
		xrTableCell28.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell28.CanGrow = false;
		xrTableCell28.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.StylePriority.UseTextAlignment = false;
		xrTableCell28.Text = "Remark";
		xrTableCell28.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell28.Weight = 6.728953007637506;
		xrTableCell28.WordWrap = false;
		xrTableCell17.CanGrow = false;
		xrTableCell17.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.Text = "TR";
		xrTableCell17.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell17.Weight = 1.217856421730929;
		xrTableCell17.WordWrap = false;
		xrTableRow8.Cells.AddRange(new XRTableCell[13]
		{
			xrTableCell16, xrTableCell23, xrTableCell24, xrTableCell25, xrTableCell43, xrTableCell7, xrTableCell38, xrTableCell8, xrTableCell34, xrTableCell45,
			xrTableCell15, xrTableCell36, xrTableCell42
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
		xrTableCell16.Weight = 4.4312500476954115;
		xrTableCell16.WordWrap = false;
		xrTableCell23.CanGrow = false;
		xrTableCell23.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.Text = "C1";
		xrTableCell23.Weight = 1.094588028503072;
		xrTableCell23.WordWrap = false;
		xrTableCell24.CanGrow = false;
		xrTableCell24.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.Text = "C2";
		xrTableCell24.Weight = 1.0945879740316866;
		xrTableCell24.WordWrap = false;
		xrTableCell25.CanGrow = false;
		xrTableCell25.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.Text = "C3";
		xrTableCell25.Weight = 1.0945879461153212;
		xrTableCell25.WordWrap = false;
		xrTableCell43.CanGrow = false;
		xrTableCell43.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell43.Name = "xrTableCell43";
		xrTableCell43.StylePriority.UseFont = false;
		xrTableCell43.Text = "C4";
		xrTableCell43.Weight = 1.094587954932762;
		xrTableCell43.WordWrap = false;
		xrTableCell7.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell7.Multiline = true;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.Text = "C5";
		xrTableCell7.Weight = 1.0945879549327617;
		xrTableCell38.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell38.CanGrow = false;
		xrTableCell38.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseBorders = false;
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.Text = "20%";
		xrTableCell38.Weight = 1.0945879725639802;
		xrTableCell38.WordWrap = false;
		xrTableCell8.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell8.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseBorders = false;
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.Text = "80%";
		xrTableCell8.Weight = 1.0945879816795352;
		xrTableCell34.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell34.CanGrow = false;
		xrTableCell34.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.StylePriority.UseBorders = false;
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.Text = "100%";
		xrTableCell34.Weight = 1.1766820528034272;
		xrTableCell34.WordWrap = false;
		xrTableCell45.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell45.CanGrow = false;
		xrTableCell45.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell45.Name = "xrTableCell45";
		xrTableCell45.StylePriority.UseBorders = false;
		xrTableCell45.StylePriority.UseFont = false;
		xrTableCell45.Text = "Pos.";
		xrTableCell45.Weight = 1.231411482782629;
		xrTableCell45.WordWrap = false;
		xrTableCell15.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell15.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBorders = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.Weight = 1.0945880299191553;
		xrTableCell36.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell36.CanGrow = false;
		xrTableCell36.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.StylePriority.UseBorders = false;
		xrTableCell36.StylePriority.UseFont = false;
		xrTableCell36.StylePriority.UseTextAlignment = false;
		xrTableCell36.TextAlignment = TextAlignment.TopCenter;
		xrTableCell36.Weight = 4.774782151752889;
		xrTableCell36.WordWrap = false;
		xrTableCell42.CanGrow = false;
		xrTableCell42.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.StylePriority.UseFont = false;
		xrTableCell42.Weight = 0.8641774280184178;
		xrTableCell42.WordWrap = false;
		studNumber.Description = "StudNumber";
		studNumber.Name = "studNumber";
		studNumber.Visible = false;
		GroupFooter1.Controls.AddRange(new XRControl[2] { xrLine1, xrTable3 });
		GroupFooter1.HeightF = 30f;
		GroupFooter1.Name = "GroupFooter1";
		xrLine1.BorderWidth = 2f;
		xrLine1.LineWidth = 3f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(775.9999f, 3.125f);
		xrLine1.StylePriority.UseBorderWidth = false;
		xrTable3.BorderColor = Color.Black;
		xrTable3.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable3.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable3.ForeColor = Color.Black;
		xrTable3.LocationFloat = new PointFloat(0f, 3.125f);
		xrTable3.Name = "xrTable3";
		xrTable3.Rows.AddRange(new XRTableRow[1] { xrTableRow4 });
		xrTable3.SizeF = new SizeF(775.9999f, 25f);
		xrTable3.StylePriority.UseBorderColor = false;
		xrTable3.StylePriority.UseBorders = false;
		xrTable3.StylePriority.UseFont = false;
		xrTable3.StylePriority.UseForeColor = false;
		xrTable3.StylePriority.UseTextAlignment = false;
		xrTable3.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow4.Cells.AddRange(new XRTableCell[3] { xrTableCell31, xrTableCell32, xrTableCell37 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell31.BorderColor = Color.DimGray;
		xrTableCell31.Borders = BorderSide.Right | BorderSide.Bottom;
		xrTableCell31.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell31.ForeColor = Color.Black;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell31.StylePriority.UseBorderColor = false;
		xrTableCell31.StylePriority.UseBorders = false;
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UseForeColor = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.Text = "AVERAGE SCORES";
		xrTableCell31.Weight = 0.7136972463728747;
		xrTableCell32.BorderColor = Color.DimGray;
		xrTableCell32.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell32.CanGrow = false;
		xrTableCell32.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sumAvg([ETAv])")
		});
		xrTableCell32.Font = new DXFont("Tahoma", 10f);
		xrTableCell32.ForeColor = Color.Black;
		xrTableCell32.Name = "xrTableCell32";
		xrTableCell32.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrTableCell32.StylePriority.UseBorderColor = false;
		xrTableCell32.StylePriority.UseBorders = false;
		xrTableCell32.StylePriority.UseFont = false;
		xrTableCell32.StylePriority.UseForeColor = false;
		xrTableCell32.StylePriority.UsePadding = false;
		xrTableCell32.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell32.Summary = xRSummary;
		xrTableCell32.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell32.TextFormatString = "{0:n2}";
		xrTableCell32.Weight = 0.37228528321338505;
		xrTableCell32.WordWrap = false;
		xrTableCell37.BorderColor = Color.DimGray;
		xrTableCell37.Borders = BorderSide.Left | BorderSide.Bottom;
		xrTableCell37.Font = new DXFont("Tahoma", 10f);
		xrTableCell37.ForeColor = Color.Black;
		xrTableCell37.Multiline = true;
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell37.StylePriority.UseBorderColor = false;
		xrTableCell37.StylePriority.UseBorders = false;
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.StylePriority.UseForeColor = false;
		xrTableCell37.StylePriority.UsePadding = false;
		xrTableCell37.Weight = 0.6556178644239724;
		GroupFooter2.Controls.AddRange(new XRControl[2] { xrTable4, tblClassRanking });
		GroupFooter2.HeightF = 55f;
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
		xrTable4.Rows.AddRange(new XRTableRow[2] { xrTableRow2, xrTableRow7 });
		xrTable4.SizeF = new SizeF(375.625f, 55f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseForeColor = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow2.Cells.AddRange(new XRTableCell[1] { xrTableCell39 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell39.BackColor = Color.Black;
		xrTableCell39.BorderColor = Color.DimGray;
		xrTableCell39.Borders = BorderSide.None;
		xrTableCell39.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell39.ForeColor = Color.White;
		xrTableCell39.Name = "xrTableCell39";
		xrTableCell39.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell39.StylePriority.UseBackColor = false;
		xrTableCell39.StylePriority.UseBorderColor = false;
		xrTableCell39.StylePriority.UseBorders = false;
		xrTableCell39.StylePriority.UseFont = false;
		xrTableCell39.StylePriority.UseForeColor = false;
		xrTableCell39.StylePriority.UsePadding = false;
		xrTableCell39.StylePriority.UseTextAlignment = false;
		xrTableCell39.Text = "OVERALL PERFORMANCE";
		xrTableCell39.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell39.Weight = 0.9022209284166749;
		xrTableRow7.Cells.AddRange(new XRTableCell[1] { xrTableCell40 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell40.BorderColor = Color.DimGray;
		xrTableCell40.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell40.CanGrow = false;
		xrTableCell40.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformance]")
		});
		xrTableCell40.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell40.ForeColor = Color.Black;
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell40.StylePriority.UseBorderColor = false;
		xrTableCell40.StylePriority.UseBorders = false;
		xrTableCell40.StylePriority.UseFont = false;
		xrTableCell40.StylePriority.UseForeColor = false;
		xrTableCell40.StylePriority.UsePadding = false;
		xrTableCell40.StylePriority.UseTextAlignment = false;
		xrTableCell40.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell40.Weight = 0.9022209284166749;
		xrTableCell40.WordWrap = false;
		tblClassRanking.BorderColor = Color.Black;
		tblClassRanking.Borders = BorderSide.All;
		tblClassRanking.Font = new DXFont("Tahoma", 9f);
		tblClassRanking.LocationFloat = new PointFloat(387.4999f, 0f);
		tblClassRanking.Name = "tblClassRanking";
		tblClassRanking.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow6 });
		tblClassRanking.SizeF = new SizeF(387.4999f, 55f);
		tblClassRanking.StylePriority.UseBorderColor = false;
		tblClassRanking.StylePriority.UseBorders = false;
		tblClassRanking.StylePriority.UseFont = false;
		tblClassRanking.StylePriority.UseTextAlignment = false;
		tblClassRanking.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow1.Cells.AddRange(new XRTableCell[2] { xrTableCell27, colStreamPosition });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell27.BackColor = Color.Black;
		xrTableCell27.BorderColor = Color.White;
		xrTableCell27.Borders = BorderSide.Right;
		xrTableCell27.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell27.ForeColor = Color.White;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.StylePriority.UseBackColor = false;
		xrTableCell27.StylePriority.UseBorderColor = false;
		xrTableCell27.StylePriority.UseBorders = false;
		xrTableCell27.StylePriority.UseFont = false;
		xrTableCell27.StylePriority.UseForeColor = false;
		xrTableCell27.Text = "Position in Class";
		xrTableCell27.Weight = 1.12499987501708;
		colStreamPosition.BackColor = Color.Black;
		colStreamPosition.BorderColor = Color.White;
		colStreamPosition.Borders = BorderSide.Left;
		colStreamPosition.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		colStreamPosition.ForeColor = Color.White;
		colStreamPosition.Name = "colStreamPosition";
		colStreamPosition.StylePriority.UseBackColor = false;
		colStreamPosition.StylePriority.UseBorderColor = false;
		colStreamPosition.StylePriority.UseBorders = false;
		colStreamPosition.StylePriority.UseFont = false;
		colStreamPosition.StylePriority.UseForeColor = false;
		colStreamPosition.Text = "Position in Stream";
		colStreamPosition.Weight = 1.12500013911148;
		xrTableRow6.Cells.AddRange(new XRTableCell[4] { colClass1, colClass2, colStream1, colStream2 });
		xrTableRow6.Name = "xrTableRow6";
		xrTableRow6.Weight = 1.0;
		colClass1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colClass1.CanGrow = false;
		colClass1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PICLOEOT]")
		});
		colClass1.Font = new DXFont("Cascadia Mono", 10f);
		colClass1.ForeColor = Color.Black;
		colClass1.Name = "colClass1";
		colClass1.StylePriority.UseBorders = false;
		colClass1.StylePriority.UseFont = false;
		colClass1.StylePriority.UseForeColor = false;
		colClass1.Weight = 0.559615322358004;
		colClass1.WordWrap = false;
		colClass2.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colClass2.CanGrow = false;
		colClass2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SIC]")
		});
		colClass2.Font = new DXFont("Cascadia Mono", 10f);
		colClass2.ForeColor = Color.Black;
		colClass2.Name = "colClass2";
		colClass2.StylePriority.UseBorders = false;
		colClass2.StylePriority.UseFont = false;
		colClass2.StylePriority.UseForeColor = false;
		colClass2.Weight = 0.565384684706274;
		colClass2.WordWrap = false;
		colStream1.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colStream1.CanGrow = false;
		colStream1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PISLOEOT]")
		});
		colStream1.Font = new DXFont("Cascadia Mono", 10f);
		colStream1.ForeColor = Color.Black;
		colStream1.Name = "colStream1";
		colStream1.StylePriority.UseBorders = false;
		colStream1.StylePriority.UseFont = false;
		colStream1.StylePriority.UseForeColor = false;
		colStream1.Weight = 0.559615322358004;
		colStream1.WordWrap = false;
		colStream2.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		colStream2.CanGrow = false;
		colStream2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SIS]")
		});
		colStream2.Font = new DXFont("Cascadia Mono", 10f);
		colStream2.ForeColor = Color.Black;
		colStream2.Name = "colStream2";
		colStream2.StylePriority.UseBorders = false;
		colStream2.StylePriority.UseFont = false;
		colStream2.StylePriority.UseForeColor = false;
		colStream2.Weight = 0.565384332580401;
		colStream2.WordWrap = false;
		newCurriculumSubReport2.DataSetName = "NewCurriculumSubReport";
		newCurriculumSubReport2.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterNewCurriculumSubAssessed1.ClearBeforeFill = true;
		footerClassTeacher.Controls.AddRange(new XRControl[6] { xrLabel2, xrLabel17, lblClassteacherComment, xrLabel1, xrShape2, xrShape3 });
		footerClassTeacher.HeightF = 69f;
		footerClassTeacher.Level = 2;
		footerClassTeacher.Name = "footerClassTeacher";
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OtherRequirements]")
		});
		xrLabel2.LocationFloat = new PointFloat(620.5f, 31.50001f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(100f, 23f);
		xrLabel2.Visible = false;
		xrLabel2.BeforePrint += xrLabel2_BeforePrint;
		xrLabel17.BackColor = Color.Transparent;
		xrLabel17.BorderColor = Color.Black;
		xrLabel17.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel17.Borders = BorderSide.None;
		xrLabel17.CanGrow = false;
		xrLabel17.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrLabel17.ForeColor = Color.Black;
		xrLabel17.LocationFloat = new PointFloat(6.000019f, 7.99998f);
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
		xrLabel17.Text = "Classteacher Remarks:";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.WordWrap = false;
		lblClassteacherComment.AutoWidth = true;
		lblClassteacherComment.BorderColor = Color.Black;
		lblClassteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblClassteacherComment.Borders = BorderSide.None;
		lblClassteacherComment.CanGrow = false;
		lblClassteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassteacherRemarkFA]")
		});
		lblClassteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblClassteacherComment.ForeColor = Color.Black;
		lblClassteacherComment.LocationFloat = new PointFloat(6.000019f, 31.5f);
		lblClassteacherComment.Multiline = true;
		lblClassteacherComment.Name = "lblClassteacherComment";
		lblClassteacherComment.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblClassteacherComment.SizeF = new SizeF(603f, 23f);
		lblClassteacherComment.StylePriority.UseBorderColor = false;
		lblClassteacherComment.StylePriority.UseBorderDashStyle = false;
		lblClassteacherComment.StylePriority.UseBorders = false;
		lblClassteacherComment.StylePriority.UseFont = false;
		lblClassteacherComment.StylePriority.UseForeColor = false;
		lblClassteacherComment.StylePriority.UsePadding = false;
		lblClassteacherComment.StylePriority.UseTextAlignment = false;
		lblClassteacherComment.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel1.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel1.LocationFloat = new PointFloat(620f, 6.99999f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(100f, 23f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Signature";
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		xrShape2.LocationFloat = new PointFloat(615f, 5f);
		xrShape2.Name = "xrShape2";
		xrShape2.Shape = shape;
		xrShape2.SizeF = new SizeF(2f, 64f);
		xrShape3.LocationFloat = new PointFloat(0f, 5f);
		xrShape3.Name = "xrShape3";
		xrShape3.Shape = shape2;
		xrShape3.SizeF = new SizeF(774.9998f, 64f);
		footerHeadTeacher.Controls.AddRange(new XRControl[5] { lblHeadteacherComment, xrLabel19, xrLabel15, xrShape5, xrShape6 });
		footerHeadTeacher.HeightF = 69f;
		footerHeadTeacher.Level = 3;
		footerHeadTeacher.Name = "footerHeadTeacher";
		lblHeadteacherComment.AutoWidth = true;
		lblHeadteacherComment.BorderColor = Color.Black;
		lblHeadteacherComment.BorderDashStyle = BorderDashStyle.Solid;
		lblHeadteacherComment.Borders = BorderSide.None;
		lblHeadteacherComment.CanGrow = false;
		lblHeadteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadteacherRemarkFA]")
		});
		lblHeadteacherComment.Font = new DXFont("Cascadia Mono", 11f);
		lblHeadteacherComment.ForeColor = Color.Black;
		lblHeadteacherComment.LocationFloat = new PointFloat(6.000019f, 31.5f);
		lblHeadteacherComment.Multiline = true;
		lblHeadteacherComment.Name = "lblHeadteacherComment";
		lblHeadteacherComment.Padding = new PaddingInfo(5, 2, 0, 0, 100f);
		lblHeadteacherComment.SizeF = new SizeF(603f, 23f);
		lblHeadteacherComment.StylePriority.UseBorderColor = false;
		lblHeadteacherComment.StylePriority.UseBorderDashStyle = false;
		lblHeadteacherComment.StylePriority.UseBorders = false;
		lblHeadteacherComment.StylePriority.UseFont = false;
		lblHeadteacherComment.StylePriority.UseForeColor = false;
		lblHeadteacherComment.StylePriority.UsePadding = false;
		lblHeadteacherComment.StylePriority.UseTextAlignment = false;
		lblHeadteacherComment.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel19.BackColor = Color.Transparent;
		xrLabel19.BorderColor = Color.Black;
		xrLabel19.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel19.Borders = BorderSide.None;
		xrLabel19.CanGrow = false;
		xrLabel19.Font = new DXFont("Consolas", 11f, DXFontStyle.Bold);
		xrLabel19.ForeColor = Color.Black;
		xrLabel19.LocationFloat = new PointFloat(6.000019f, 8f);
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
		xrLabel19.Text = "Headteacher Remarks:";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.WordWrap = false;
		xrLabel15.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel15.LocationFloat = new PointFloat(620.5f, 7f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape5.LocationFloat = new PointFloat(615.5f, 5f);
		xrShape5.Name = "xrShape5";
		xrShape5.Shape = shape3;
		xrShape5.SizeF = new SizeF(2f, 64f);
		xrShape6.LocationFloat = new PointFloat(0f, 5f);
		xrShape6.Name = "xrShape6";
		xrShape6.Shape = shape4;
		xrShape6.SizeF = new SizeF(774.9998f, 64f);
		OtherFeesRequirements.Description = "Other Fees Requirements";
		OtherFeesRequirements.Name = "OtherFeesRequirements";
		OtherFeesRequirements.Visible = false;
		base.Bands.AddRange(new Band[8] { TopMargin, BottomMargin, Detail, GroupHeader1, GroupFooter1, GroupFooter2, footerClassTeacher, footerHeadTeacher });
		base.ComponentStorage.AddRange(new IComponent[1] { newCurriculumSubReport2 });
		base.DataAdapter = adapterNewCurriculumSubAssessed1;
		base.DataMember = "tbl_Scores_OL_Report";
		base.DataSource = newCurriculumSubReport2;
		FilterString = "[StudentNumber] = ?studNumber";
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageColor = Color.Transparent;
		base.PageWidth = 776;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[2] { studNumber, OtherFeesRequirements });
		base.RollPaper = true;
		base.SnapGridSize = 1f;
		base.Version = "23.2";
		BeforePrint += NewCurriculumSubUpper2080_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)tblClassRanking).EndInit();
		((ISupportInitialize)newCurriculumSubReport2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
