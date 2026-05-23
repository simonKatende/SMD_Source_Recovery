using System.ComponentModel;
using System.Data;
using System.Drawing;
using AlienAge.CommonSettings;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.NewCurriculumReports.ReportDatasets;
using I_Xtreme.NewCurriculumReports.ReportDatasets.NewCurriculumSubReportTableAdapters;

namespace I_Xtreme.NewCurriculumReports.SubReports;

public class UltimateReportSub : XtraReport
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

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell6;

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

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell35;

	private XRTableCell xrTableCell30;

	private XRTableCell xrTableCell34;

	private XRTableCell xrTableCell37;

	private GroupFooterBand GroupFooter2;

	private XRTable xrTable4;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell39;

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

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell7;

	private XRTable tblClassRanking;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell13;

	private XRTableCell colStreamPosition;

	private XRTableRow xrTableRow6;

	private XRTableCell colClass1;

	private XRTableCell colClass2;

	private XRTableCell colStream1;

	private XRTableCell colStream2;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell27;

	private XRTableCell xrTableCell36;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell33;

	private XRTableCell xrTableCell40;

	private XRTableCell xrTableCell41;

	public UltimateReportSub()
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
		else
		{
			xRTableCell.BackColor = Color.LightGray;
			xRTableCell.ForeColor = Color.LightGray;
		}
	}

	private void xrLabel2_BeforePrint(object sender, CancelEventArgs e)
	{
		base.Parameters["OtherFeesRequirements"].Value = xrLabel2.Text;
	}

	private void UltimateReportSub_BeforePrint(object sender, CancelEventArgs e)
	{
		tblClassRanking.Visible = ReportCustomization.ShowPositionInClass;
	}

	private void xrTableCell28_BeforePrint(object sender, CancelEventArgs e)
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
		object currentColumnValue = GetCurrentColumnValue("Score5");
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
		XRWatermark xRWatermark = new XRWatermark();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow3 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrTableCell22 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell41 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableCell35 = new XRTableCell();
		xrTableCell36 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		GroupHeader1 = new GroupHeaderBand();
		xrTable2 = new XRTable();
		xrTableRow5 = new XRTableRow();
		xrTableCell3 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell29 = new XRTableCell();
		xrTableCell30 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell5 = new XRTableCell();
		xrTableRow8 = new XRTableRow();
		xrTableCell16 = new XRTableCell();
		xrTableCell23 = new XRTableCell();
		xrTableCell24 = new XRTableCell();
		xrTableCell25 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell40 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableCell34 = new XRTableCell();
		xrTableCell33 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		studNumber = new Parameter();
		GroupFooter1 = new GroupFooterBand();
		xrLine1 = new XRLine();
		xrTable3 = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell31 = new XRTableCell();
		xrTableCell32 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		GroupFooter2 = new GroupFooterBand();
		tblClassRanking = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell13 = new XRTableCell();
		colStreamPosition = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		colClass1 = new XRTableCell();
		colClass2 = new XRTableCell();
		colStream1 = new XRTableCell();
		colStream2 = new XRTableCell();
		xrTable4 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell17 = new XRTableCell();
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
		((ISupportInitialize)tblClassRanking).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
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
			xrTableCell1, xrTableCell19, xrTableCell20, xrTableCell22, xrTableCell28, xrTableCell41, xrTableCell6, xrTableCell12, xrTableCell35, xrTableCell36,
			xrTableCell26, xrTableCell14, xrTableCell9
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
		xrTableCell1.Weight = 3.6847512388636305;
		xrTableCell1.WordWrap = false;
		xrTableCell19.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell19.CanGrow = false;
		xrTableCell19.CanShrink = true;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score1]")
		});
		xrTableCell19.Font = new DXFont("Tahoma", 8f);
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseBorders = false;
		xrTableCell19.StylePriority.UseFont = false;
		xrTableCell19.Weight = 0.8286258144272695;
		xrTableCell19.WordWrap = false;
		xrTableCell20.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell20.CanGrow = false;
		xrTableCell20.CanShrink = true;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score2]")
		});
		xrTableCell20.Font = new DXFont("Tahoma", 8f);
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseBorders = false;
		xrTableCell20.StylePriority.UseFont = false;
		xrTableCell20.Weight = 0.8286258530827166;
		xrTableCell20.WordWrap = false;
		xrTableCell20.BeforePrint += xrTableCell20_BeforePrint;
		xrTableCell22.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell22.CanGrow = false;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score3]")
		});
		xrTableCell22.Font = new DXFont("Tahoma", 8f);
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseBorders = false;
		xrTableCell22.StylePriority.UseFont = false;
		xrTableCell22.Weight = 0.8286258135415521;
		xrTableCell22.WordWrap = false;
		xrTableCell22.BeforePrint += xrTableCell22_BeforePrint;
		xrTableCell28.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell28.CanGrow = false;
		xrTableCell28.CanShrink = true;
		xrTableCell28.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score4]")
		});
		xrTableCell28.Font = new DXFont("Tahoma", 8f);
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.StylePriority.UseFont = false;
		xrTableCell28.Weight = 0.8286258286657873;
		xrTableCell28.WordWrap = false;
		xrTableCell28.BeforePrint += xrTableCell28_BeforePrint;
		xrTableCell41.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell41.CanGrow = false;
		xrTableCell41.CanShrink = true;
		xrTableCell41.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Score5]")
		});
		xrTableCell41.Font = new DXFont("Tahoma", 8f);
		xrTableCell41.Name = "xrTableCell41";
		xrTableCell41.StylePriority.UseBorders = false;
		xrTableCell41.StylePriority.UseFont = false;
		xrTableCell41.Weight = 0.8286258286657874;
		xrTableCell41.WordWrap = false;
		xrTableCell41.BeforePrint += xrTableCell41_BeforePrint;
		xrTableCell6.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell6.CanGrow = false;
		xrTableCell6.CanShrink = true;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OutOfTwenty]")
		});
		xrTableCell6.Font = new DXFont("Tahoma", 9f);
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseBorders = false;
		xrTableCell6.StylePriority.UseFont = false;
		xrTableCell6.Text = "xrTableCell6";
		xrTableCell6.Weight = 1.0155225329135527;
		xrTableCell6.WordWrap = false;
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
		xrTableCell12.Weight = 1.0317303278082885;
		xrTableCell12.WordWrap = false;
		xrTableCell35.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell35.CanGrow = false;
		xrTableCell35.CanShrink = true;
		xrTableCell35.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ETAv]")
		});
		xrTableCell35.Font = new DXFont("Tahoma", 9f);
		xrTableCell35.Name = "xrTableCell35";
		xrTableCell35.StylePriority.UseBorders = false;
		xrTableCell35.StylePriority.UseFont = false;
		xrTableCell35.Text = "xrTableCell35";
		xrTableCell35.Weight = 1.031730351359617;
		xrTableCell35.WordWrap = false;
		xrTableCell36.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell36.CanGrow = false;
		xrTableCell36.CanShrink = true;
		xrTableCell36.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Concat([SubPosLOEOT],Concat('/',[TotalStudents]))\n")
		});
		xrTableCell36.Font = new DXFont("Tahoma", 9f);
		xrTableCell36.Name = "xrTableCell36";
		xrTableCell36.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTableCell36.StylePriority.UseBorders = false;
		xrTableCell36.StylePriority.UseFont = false;
		xrTableCell36.StylePriority.UsePadding = false;
		xrTableCell36.Weight = 1.3014646680190274;
		xrTableCell36.WordWrap = false;
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
		xrTableCell26.Weight = 1.2205453600564353;
		xrTableCell26.WordWrap = false;
		xrTableCell14.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[TeacherRemarks]")
		});
		xrTableCell14.Font = new DXFont("Tahoma", 7f);
		xrTableCell14.Multiline = true;
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseBorders = false;
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.StylePriority.UseTextAlignment = false;
		xrTableCell14.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell14.Weight = 5.977482697636734;
		xrTableCell9.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell9.CanGrow = false;
		xrTableCell9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell9.Font = new DXFont("Tahoma", 7.5f);
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseBorders = false;
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.StylePriority.UseTextAlignment = false;
		xrTableCell9.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell9.Weight = 0.6878203968676463;
		xrTableCell9.WordWrap = false;
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
		xrTableRow5.Cells.AddRange(new XRTableCell[9] { xrTableCell3, xrTableCell4, xrTableCell21, xrTableCell29, xrTableCell30, xrTableCell18, xrTableCell2, xrTableCell10, xrTableCell5 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell3.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell3.CanGrow = false;
		xrTableCell3.CanShrink = true;
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
		xrTableCell3.Weight = 5.487621767019185;
		xrTableCell3.WordWrap = false;
		xrTableCell4.CanGrow = false;
		xrTableCell4.Font = new DXFont("Cascadia Code", 9f);
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "Ass. of Integration";
		xrTableCell4.Weight = 6.170274885397782;
		xrTableCell4.WordWrap = false;
		xrTableCell21.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell21.CanGrow = false;
		xrTableCell21.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseBorders = false;
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.Text = "A1";
		xrTableCell21.Weight = 1.5123967627115393;
		xrTableCell21.WordWrap = false;
		xrTableCell29.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell29.CanGrow = false;
		xrTableCell29.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell29.Name = "xrTableCell29";
		xrTableCell29.StylePriority.UseBorders = false;
		xrTableCell29.StylePriority.UseFont = false;
		xrTableCell29.Text = "EOT";
		xrTableCell29.Weight = 1.536534171592327;
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
		xrTableCell30.Weight = 1.5365341957965786;
		xrTableCell30.WordWrap = false;
		xrTableCell18.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell18.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseBorders = false;
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.Text = "Sub";
		xrTableCell18.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell18.Weight = 1.9382438015408674;
		xrTableCell2.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell2.CanGrow = false;
		xrTableCell2.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseBorders = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.Text = "Grade";
		xrTableCell2.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell2.Weight = 1.8177323669035923;
		xrTableCell2.WordWrap = false;
		xrTableCell10.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell10.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell10.Multiline = true;
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBorders = false;
		xrTableCell10.StylePriority.UseFont = false;
		xrTableCell10.StylePriority.UseTextAlignment = false;
		xrTableCell10.Text = "Facilitator Remarks";
		xrTableCell10.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell10.Weight = 8.902138332185391;
		xrTableCell5.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell5.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell5.Multiline = true;
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseBorders = false;
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.StylePriority.UseTextAlignment = false;
		xrTableCell5.Text = "Tr.";
		xrTableCell5.TextAlignment = TextAlignment.BottomCenter;
		xrTableCell5.Weight = 1.024355567492198;
		xrTableRow8.Cells.AddRange(new XRTableCell[13]
		{
			xrTableCell16, xrTableCell23, xrTableCell24, xrTableCell25, xrTableCell27, xrTableCell40, xrTableCell38, xrTableCell8, xrTableCell34, xrTableCell33,
			xrTableCell15, xrTableCell11, xrTableCell7
		});
		xrTableRow8.Name = "xrTableRow8";
		xrTableRow8.Weight = 1.0;
		xrTableCell16.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell16.CanShrink = true;
		xrTableCell16.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.ProcessDuplicatesMode = ProcessDuplicatesMode.Merge;
		xrTableCell16.StylePriority.UseBorders = false;
		xrTableCell16.StylePriority.UseFont = false;
		xrTableCell16.StylePriority.UseTextAlignment = false;
		xrTableCell16.Text = "SUBJECT";
		xrTableCell16.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell16.Weight = 3.8939500324154483;
		xrTableCell16.WordWrap = false;
		xrTableCell23.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell23.Multiline = true;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.StylePriority.UseFont = false;
		xrTableCell23.Text = "C1";
		xrTableCell23.Weight = 0.8756703553674686;
		xrTableCell24.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell24.Multiline = true;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.StylePriority.UseFont = false;
		xrTableCell24.Text = "C2";
		xrTableCell24.Weight = 0.8756704016056984;
		xrTableCell25.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell25.Multiline = true;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.StylePriority.UseFont = false;
		xrTableCell25.Text = "C3";
		xrTableCell25.Weight = 0.8756703757465301;
		xrTableCell27.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell27.Multiline = true;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.StylePriority.UseFont = false;
		xrTableCell27.Text = "C4";
		xrTableCell27.Weight = 0.8756703836780859;
		xrTableCell40.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell40.Multiline = true;
		xrTableCell40.Name = "xrTableCell40";
		xrTableCell40.StylePriority.UseFont = false;
		xrTableCell40.Text = "C5";
		xrTableCell40.Weight = 0.875670383678086;
		xrTableCell38.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell38.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell38.Multiline = true;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseBorders = false;
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.Text = "20%";
		xrTableCell38.Weight = 1.0731780160117803;
		xrTableCell8.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell8.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell8.Multiline = true;
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseBorders = false;
		xrTableCell8.StylePriority.UseFont = false;
		xrTableCell8.Text = "80%";
		xrTableCell8.Weight = 1.0903059956864267;
		xrTableCell34.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell34.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell34.Multiline = true;
		xrTableCell34.Name = "xrTableCell34";
		xrTableCell34.StylePriority.UseBorders = false;
		xrTableCell34.StylePriority.UseFont = false;
		xrTableCell34.Text = "100%";
		xrTableCell34.Weight = 1.0903059696339348;
		xrTableCell33.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell33.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell33.Multiline = true;
		xrTableCell33.Name = "xrTableCell33";
		xrTableCell33.StylePriority.UseBorders = false;
		xrTableCell33.StylePriority.UseFont = false;
		xrTableCell33.Text = "Pos.";
		xrTableCell33.Weight = 1.37535422931573;
		xrTableCell15.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell15.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell15.Multiline = true;
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBorders = false;
		xrTableCell15.StylePriority.UseFont = false;
		xrTableCell15.Weight = 1.2898408181615744;
		xrTableCell11.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell11.CanGrow = false;
		xrTableCell11.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseBorders = false;
		xrTableCell11.StylePriority.UseFont = false;
		xrTableCell11.Weight = 6.316849099046882;
		xrTableCell11.WordWrap = false;
		xrTableCell7.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell7.CanGrow = false;
		xrTableCell7.Font = new DXFont("Tahoma", 7.5f, DXFontStyle.Bold);
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.StylePriority.UseBorders = false;
		xrTableCell7.StylePriority.UseFont = false;
		xrTableCell7.Weight = 0.7268709361861689;
		xrTableCell7.WordWrap = false;
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
		xrTableCell31.Borders = BorderSide.Bottom;
		xrTableCell31.CanGrow = false;
		xrTableCell31.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell31.ForeColor = Color.Black;
		xrTableCell31.Name = "xrTableCell31";
		xrTableCell31.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell31.StylePriority.UseBorderColor = false;
		xrTableCell31.StylePriority.UseBorders = false;
		xrTableCell31.StylePriority.UseFont = false;
		xrTableCell31.StylePriority.UseForeColor = false;
		xrTableCell31.StylePriority.UsePadding = false;
		xrTableCell31.Text = "AVERAGE SCORES:";
		xrTableCell31.Weight = 0.7136972463728747;
		xrTableCell31.WordWrap = false;
		xrTableCell32.BorderColor = Color.DimGray;
		xrTableCell32.Borders = BorderSide.Right | BorderSide.Bottom;
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
		xrTableCell32.Weight = 0.231621263947204;
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
		xrTableCell37.Weight = 0.7962818836901535;
		GroupFooter2.Controls.AddRange(new XRControl[2] { tblClassRanking, xrTable4 });
		GroupFooter2.HeightF = 55f;
		GroupFooter2.Level = 1;
		GroupFooter2.Name = "GroupFooter2";
		tblClassRanking.BorderColor = Color.Black;
		tblClassRanking.Borders = BorderSide.All;
		tblClassRanking.Font = new DXFont("Tahoma", 9f);
		tblClassRanking.LocationFloat = new PointFloat(387.4999f, 0f);
		tblClassRanking.Name = "tblClassRanking";
		tblClassRanking.Rows.AddRange(new XRTableRow[2] { xrTableRow2, xrTableRow6 });
		tblClassRanking.SizeF = new SizeF(387.4999f, 55f);
		tblClassRanking.StylePriority.UseBorderColor = false;
		tblClassRanking.StylePriority.UseBorders = false;
		tblClassRanking.StylePriority.UseFont = false;
		tblClassRanking.StylePriority.UseTextAlignment = false;
		tblClassRanking.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow2.Cells.AddRange(new XRTableCell[2] { xrTableCell13, colStreamPosition });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell13.BackColor = Color.Black;
		xrTableCell13.BorderColor = Color.White;
		xrTableCell13.Borders = BorderSide.Right;
		xrTableCell13.CanGrow = false;
		xrTableCell13.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell13.ForeColor = Color.White;
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseBackColor = false;
		xrTableCell13.StylePriority.UseBorderColor = false;
		xrTableCell13.StylePriority.UseBorders = false;
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.StylePriority.UseForeColor = false;
		xrTableCell13.Text = "Position in Class";
		xrTableCell13.Weight = 1.12499987501708;
		xrTableCell13.WordWrap = false;
		colStreamPosition.BackColor = Color.Black;
		colStreamPosition.BorderColor = Color.White;
		colStreamPosition.Borders = BorderSide.Left;
		colStreamPosition.CanGrow = false;
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
		colStreamPosition.WordWrap = false;
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
		xrTable4.BorderColor = Color.Black;
		xrTable4.Borders = BorderSide.Top | BorderSide.Bottom;
		xrTable4.Font = new DXFont("Times New Roman", 11.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTable4.ForeColor = Color.Black;
		xrTable4.LocationFloat = new PointFloat(0f, 0f);
		xrTable4.Name = "xrTable4";
		xrTable4.Rows.AddRange(new XRTableRow[2] { xrTableRow1, xrTableRow7 });
		xrTable4.SizeF = new SizeF(375.625f, 55f);
		xrTable4.StylePriority.UseBorderColor = false;
		xrTable4.StylePriority.UseBorders = false;
		xrTable4.StylePriority.UseFont = false;
		xrTable4.StylePriority.UseForeColor = false;
		xrTable4.StylePriority.UseTextAlignment = false;
		xrTable4.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[1] { xrTableCell39 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell39.BackColor = Color.Black;
		xrTableCell39.BorderColor = Color.DimGray;
		xrTableCell39.Borders = BorderSide.None;
		xrTableCell39.CanGrow = false;
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
		xrTableCell39.WordWrap = false;
		xrTableRow7.Cells.AddRange(new XRTableCell[1] { xrTableCell17 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell17.BorderColor = Color.DimGray;
		xrTableCell17.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformance]")
		});
		xrTableCell17.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell17.ForeColor = Color.Black;
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell17.StylePriority.UseBorderColor = false;
		xrTableCell17.StylePriority.UseBorders = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseForeColor = false;
		xrTableCell17.StylePriority.UsePadding = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xrTableCell17.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell17.Weight = 0.9022209284166749;
		xrTableCell17.WordWrap = false;
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
		xrLabel2.LocationFloat = new PointFloat(620.5f, 31.5f);
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
		lblClassteacherComment.LocationFloat = new PointFloat(6.000007f, 31.5f);
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
		lblHeadteacherComment.LocationFloat = new PointFloat(6.500007f, 30.5f);
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
		xrLabel19.LocationFloat = new PointFloat(6.50002f, 7f);
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
		xrLabel15.LocationFloat = new PointFloat(620.5f, 6f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape5.LocationFloat = new PointFloat(615.5f, 4f);
		xrShape5.Name = "xrShape5";
		xrShape5.Shape = shape3;
		xrShape5.SizeF = new SizeF(2f, 64f);
		xrShape6.LocationFloat = new PointFloat(0f, 4f);
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
		xRWatermark.Id = "Watermark1";
		base.Watermarks.AddRange(new Watermark[1] { xRWatermark });
		BeforePrint += UltimateReportSub_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)tblClassRanking).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)newCurriculumSubReport2).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
