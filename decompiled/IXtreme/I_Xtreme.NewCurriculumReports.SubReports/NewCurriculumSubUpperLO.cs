using System;
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

public class NewCurriculumSubUpperLO : XtraReport
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

	private XRTableCell xrTableCell42;

	private XRTable xrTable1;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private XRTableCell xrTableCell22;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell8;

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

	private XRTable xrTable4;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell39;

	private XRTableRow xrTableRow7;

	private XRTableCell xrTableCell2;

	private XRTable tblClassRanking;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell13;

	private XRTableCell colStreamPosition;

	private XRTableRow xrTableRow6;

	private XRTableCell colClass1;

	private XRTableCell colClass2;

	private XRTableCell colStream1;

	private XRTableCell colStream2;

	private XRLine xrLine1;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell26;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell21;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell37;

	private XRTableCell xrTableCell38;

	private XRTableCell xrTableCell28;

	private XRTableCell xrTableCell27;

	public NewCurriculumSubUpperLO()
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

	private void xrLabel1_BeforePrint(object sender, CancelEventArgs e)
	{
		base.Parameters["OtherFeesRequirements"].Value = xrLabel1.Text;
	}

	private void NewCurriculumSubUpperLO_BeforePrint(object sender, CancelEventArgs e)
	{
		tblClassRanking.Visible = ReportCustomization.ShowPositionInClass;
	}

	private void xrTableCell11_BeforePrint(object sender, CancelEventArgs e)
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
	}

	private void xrTableCell28_BeforePrint(object sender, CancelEventArgs e)
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
		xrTableCell11 = new XRTableCell();
		xrTableCell28 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell26 = new XRTableCell();
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
		xrTableCell7 = new XRTableCell();
		xrTableCell27 = new XRTableCell();
		xrTableCell9 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell21 = new XRTableCell();
		xrTableCell37 = new XRTableCell();
		xrTableCell38 = new XRTableCell();
		xrTableCell42 = new XRTableCell();
		studNumber = new Parameter();
		calculatedField1 = new CalculatedField();
		GroupFooter1 = new GroupFooterBand();
		xrLine1 = new XRLine();
		xrTable3 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell12 = new XRTableCell();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		GroupFooter2 = new GroupFooterBand();
		xrTable4 = new XRTable();
		xrTableRow2 = new XRTableRow();
		xrTableCell39 = new XRTableCell();
		xrTableRow7 = new XRTableRow();
		xrTableCell2 = new XRTableCell();
		tblClassRanking = new XRTable();
		xrTableRow4 = new XRTableRow();
		xrTableCell13 = new XRTableCell();
		colStreamPosition = new XRTableCell();
		xrTableRow6 = new XRTableRow();
		colClass1 = new XRTableCell();
		colClass2 = new XRTableCell();
		colStream1 = new XRTableCell();
		colStream2 = new XRTableCell();
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
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)xrTable2).BeginInit();
		((ISupportInitialize)xrTable3).BeginInit();
		((ISupportInitialize)xrTable4).BeginInit();
		((ISupportInitialize)tblClassRanking).BeginInit();
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
		xrTableRow3.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell1, xrTableCell19, xrTableCell20, xrTableCell22, xrTableCell11, xrTableCell28, xrTableCell10, xrTableCell15, xrTableCell26, xrTableCell8,
			xrTableCell6, xrTableCell5
		});
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell1.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell1.CanGrow = false;
		xrTableCell1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SubjectId]")
		});
		xrTableCell1.Font = new DXFont("Tahoma", 9.5f);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseBorders = false;
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.StylePriority.UseTextAlignment = false;
		xrTableCell1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableCell1.Weight = 3.4955523949734344;
		xrTableCell1.WordWrap = false;
		xrTableCell19.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell19.CanGrow = false;
		xrTableCell19.CanShrink = true;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U1]")
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.StylePriority.UseBorders = false;
		xrTableCell19.TextFormatString = "{0:N1}";
		xrTableCell19.Weight = 0.9321473002688252;
		xrTableCell19.WordWrap = false;
		xrTableCell19.BeforePrint += xrTableCell19_BeforePrint;
		xrTableCell20.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell20.CanGrow = false;
		xrTableCell20.CanShrink = true;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U2]")
		});
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.StylePriority.UseBorders = false;
		xrTableCell20.TextFormatString = "{0:N1}";
		xrTableCell20.Weight = 0.9321473086954722;
		xrTableCell20.WordWrap = false;
		xrTableCell20.BeforePrint += xrTableCell20_BeforePrint;
		xrTableCell22.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell22.CanGrow = false;
		xrTableCell22.CanShrink = true;
		xrTableCell22.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U3]")
		});
		xrTableCell22.Name = "xrTableCell22";
		xrTableCell22.StylePriority.UseBorders = false;
		xrTableCell22.TextFormatString = "{0:N1}";
		xrTableCell22.Weight = 0.932147318186118;
		xrTableCell22.WordWrap = false;
		xrTableCell22.BeforePrint += xrTableCell22_BeforePrint;
		xrTableCell11.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell11.CanGrow = false;
		xrTableCell11.CanShrink = true;
		xrTableCell11.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U4]")
		});
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.StylePriority.UseBorders = false;
		xrTableCell11.Weight = 0.9321473202892889;
		xrTableCell11.WordWrap = false;
		xrTableCell11.BeforePrint += xrTableCell11_BeforePrint;
		xrTableCell28.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell28.CanGrow = false;
		xrTableCell28.CanShrink = true;
		xrTableCell28.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[U5]")
		});
		xrTableCell28.Name = "xrTableCell28";
		xrTableCell28.StylePriority.UseBorders = false;
		xrTableCell28.Weight = 0.9321473202892889;
		xrTableCell28.WordWrap = false;
		xrTableCell28.BeforePrint += xrTableCell28_BeforePrint;
		xrTableCell10.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell10.CanGrow = false;
		xrTableCell10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[AvLO]")
		});
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.StylePriority.UseBorders = false;
		xrTableCell10.Weight = 0.9321473251381834;
		xrTableCell10.WordWrap = false;
		xrTableCell10.BeforePrint += xrTableCell10_BeforePrint;
		xrTableCell15.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell15.CanGrow = false;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OutOfTwenty]")
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.StylePriority.UseBorders = false;
		xrTableCell15.Weight = 0.9321473246438781;
		xrTableCell15.WordWrap = false;
		xrTableCell26.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell26.CanGrow = false;
		xrTableCell26.CanShrink = true;
		xrTableCell26.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Concat([SubPosLO],Concat('/',[TotalStudents]) )\n\n")
		});
		xrTableCell26.Font = new DXFont("Tahoma", 8f);
		xrTableCell26.Name = "xrTableCell26";
		xrTableCell26.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrTableCell26.StylePriority.UseBorders = false;
		xrTableCell26.StylePriority.UseFont = false;
		xrTableCell26.StylePriority.UsePadding = false;
		xrTableCell26.Weight = 1.1651841107937446;
		xrTableCell26.WordWrap = false;
		xrTableCell8.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell8.CanGrow = false;
		xrTableCell8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[CategoryAIOnly]")
		});
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.StylePriority.UseBorders = false;
		xrTableCell8.Weight = 1.0486656954946874;
		xrTableCell8.WordWrap = false;
		xrTableCell8.BeforePrint += xrTableCell8_BeforePrint;
		xrTableCell6.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell6.CanGrow = false;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Comment]")
		});
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.StylePriority.UseBorders = false;
		xrTableCell6.Weight = 4.906397425503129;
		xrTableCell6.WordWrap = false;
		xrTableCell5.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Right;
		xrTableCell5.CanGrow = false;
		xrTableCell5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Initial]")
		});
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseBorders = false;
		xrTableCell5.Weight = 0.9894345762572948;
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
		xrTableCell3.Weight = 2.699228743579579;
		xrTableCell3.WordWrap = false;
		xrTableCell4.CanGrow = false;
		xrTableCell4.Font = new DXFont("Cascadia Mono", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "Chapter Progressive Assessment";
		xrTableCell4.Weight = 11.300771256420422;
		xrTableCell4.WordWrap = false;
		xrTableRow8.Cells.AddRange(new XRTableCell[12]
		{
			xrTableCell16, xrTableCell23, xrTableCell24, xrTableCell25, xrTableCell7, xrTableCell27, xrTableCell9, xrTableCell14, xrTableCell21, xrTableCell37,
			xrTableCell38, xrTableCell42
		});
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
		xrTableCell16.Weight = 3.4955523949734344;
		xrTableCell16.WordWrap = false;
		xrTableCell23.CanGrow = false;
		xrTableCell23.Name = "xrTableCell23";
		xrTableCell23.Text = "C1";
		xrTableCell23.Weight = 0.9321473002688252;
		xrTableCell23.WordWrap = false;
		xrTableCell24.CanGrow = false;
		xrTableCell24.Name = "xrTableCell24";
		xrTableCell24.Text = "C2";
		xrTableCell24.Weight = 0.9321473086954722;
		xrTableCell24.WordWrap = false;
		xrTableCell25.CanGrow = false;
		xrTableCell25.Name = "xrTableCell25";
		xrTableCell25.Text = "C3";
		xrTableCell25.Weight = 0.9321473181861181;
		xrTableCell25.WordWrap = false;
		xrTableCell7.CanGrow = false;
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.Text = "C4";
		xrTableCell7.Weight = 0.9321473202892889;
		xrTableCell7.WordWrap = false;
		xrTableCell27.Multiline = true;
		xrTableCell27.Name = "xrTableCell27";
		xrTableCell27.Text = "C5";
		xrTableCell27.Weight = 0.9321473202892891;
		xrTableCell9.CanGrow = false;
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.Text = "Avg.";
		xrTableCell9.Weight = 0.9321473251381834;
		xrTableCell9.WordWrap = false;
		xrTableCell14.CanGrow = false;
		xrTableCell14.Font = new DXFont("Tahoma", 8f, DXFontStyle.Bold);
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.StylePriority.UseFont = false;
		xrTableCell14.Text = "/20";
		xrTableCell14.Weight = 0.9321473246438784;
		xrTableCell14.WordWrap = false;
		xrTableCell21.CanGrow = false;
		xrTableCell21.Font = new DXFont("Tahoma", 7.5f, DXFontStyle.Bold);
		xrTableCell21.Name = "xrTableCell21";
		xrTableCell21.StylePriority.UseFont = false;
		xrTableCell21.Text = "Sub. Pos.";
		xrTableCell21.Weight = 1.1651841107937446;
		xrTableCell21.WordWrap = false;
		xrTableCell37.CanGrow = false;
		xrTableCell37.Font = new DXFont("Tahoma", 7.5f, DXFontStyle.Bold);
		xrTableCell37.Name = "xrTableCell37";
		xrTableCell37.StylePriority.UseFont = false;
		xrTableCell37.Text = "Grade";
		xrTableCell37.Weight = 1.0486656954946874;
		xrTableCell37.WordWrap = false;
		xrTableCell38.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrTableCell38.Multiline = true;
		xrTableCell38.Name = "xrTableCell38";
		xrTableCell38.StylePriority.UseFont = false;
		xrTableCell38.Text = "Remark";
		xrTableCell38.Weight = 4.906397425503129;
		xrTableCell42.CanGrow = false;
		xrTableCell42.Name = "xrTableCell42";
		xrTableCell42.Text = "TR";
		xrTableCell42.Weight = 0.9894345762572948;
		xrTableCell42.WordWrap = false;
		studNumber.Description = "StudNumber";
		studNumber.Name = "studNumber";
		studNumber.ValueInfo = "285028000001";
		calculatedField1.DataMember = "dsNewCurriculumSubAssessed";
		calculatedField1.Expression = "Sum([AvLO])";
		calculatedField1.FieldType = FieldType.Double;
		calculatedField1.Name = "calculatedField1";
		GroupFooter1.Controls.AddRange(new XRControl[2] { xrLine1, xrTable3 });
		GroupFooter1.HeightF = 30f;
		GroupFooter1.KeepTogether = true;
		GroupFooter1.Name = "GroupFooter1";
		xrLine1.BorderWidth = 2f;
		xrLine1.LineWidth = 3f;
		xrLine1.LocationFloat = new PointFloat(0f, 0f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(778f, 3.125f);
		xrLine1.StylePriority.UseBorderWidth = false;
		xrTable3.Borders = BorderSide.All;
		xrTable3.LocationFloat = new PointFloat(0f, 3.125f);
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
		xrTableCell12.Borders = BorderSide.Bottom;
		xrTableCell12.CanGrow = false;
		xrTableCell12.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.StylePriority.UseBorders = false;
		xrTableCell12.StylePriority.UseFont = false;
		xrTableCell12.Text = "AVERAGE SCORES:";
		xrTableCell12.Weight = 1.0615313983363923;
		xrTableCell12.WordWrap = false;
		xrTableCell17.Borders = BorderSide.Right | BorderSide.Bottom;
		xrTableCell17.CanGrow = false;
		xrTableCell17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "Substring(PadRight(sumAvg([AvLO]),4),0 ,4 ) ")
		});
		xrTableCell17.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseBorders = false;
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Group;
		xrTableCell17.Summary = xRSummary;
		xrTableCell17.TextAlignment = TextAlignment.MiddleRight;
		xrTableCell17.Weight = 0.43845859082687244;
		xrTableCell17.WordWrap = false;
		xrTableCell18.Borders = BorderSide.Left | BorderSide.Bottom;
		xrTableCell18.Font = new DXFont("Arial", 9.75f, DXFontStyle.Bold);
		xrTableCell18.Multiline = true;
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.StylePriority.UseBorders = false;
		xrTableCell18.StylePriority.UseFont = false;
		xrTableCell18.StylePriority.UseTextAlignment = false;
		xrTableCell18.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell18.Weight = 1.492297599363446;
		xrTableCell18.WordWrap = false;
		GroupFooter2.Controls.AddRange(new XRControl[2] { xrTable4, tblClassRanking });
		GroupFooter2.HeightF = 55f;
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
		xrTableRow7.Cells.AddRange(new XRTableCell[1] { xrTableCell2 });
		xrTableRow7.Name = "xrTableRow7";
		xrTableRow7.Weight = 1.0;
		xrTableCell2.BorderColor = Color.DimGray;
		xrTableCell2.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
		xrTableCell2.CanGrow = false;
		xrTableCell2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OverallPerformanceLO]")
		});
		xrTableCell2.Font = new DXFont("Cascadia Mono", 11f, DXFontStyle.Bold);
		xrTableCell2.ForeColor = Color.Black;
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTableCell2.StylePriority.UseBorderColor = false;
		xrTableCell2.StylePriority.UseBorders = false;
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.StylePriority.UseForeColor = false;
		xrTableCell2.StylePriority.UsePadding = false;
		xrTableCell2.StylePriority.UseTextAlignment = false;
		xrTableCell2.TextAlignment = TextAlignment.MiddleCenter;
		xrTableCell2.Weight = 0.9022209284166749;
		xrTableCell2.WordWrap = false;
		tblClassRanking.BorderColor = Color.Black;
		tblClassRanking.Borders = BorderSide.All;
		tblClassRanking.Font = new DXFont("Tahoma", 9f);
		tblClassRanking.LocationFloat = new PointFloat(387.4999f, 0f);
		tblClassRanking.Name = "tblClassRanking";
		tblClassRanking.Rows.AddRange(new XRTableRow[2] { xrTableRow4, xrTableRow6 });
		tblClassRanking.SizeF = new SizeF(387.4999f, 55f);
		tblClassRanking.StylePriority.UseBorderColor = false;
		tblClassRanking.StylePriority.UseBorders = false;
		tblClassRanking.StylePriority.UseFont = false;
		tblClassRanking.StylePriority.UseTextAlignment = false;
		tblClassRanking.TextAlignment = TextAlignment.MiddleCenter;
		xrTableRow4.Cells.AddRange(new XRTableCell[2] { xrTableCell13, colStreamPosition });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
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
			new ExpressionBinding("BeforePrint", "Text", "[PICLO]")
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
			new ExpressionBinding("BeforePrint", "Text", "[PISLO]")
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
		footerClassTeacher.Controls.AddRange(new XRControl[6] { xrLabel1, lblClassteacherComment, xrShape2, xrLabel9, xrLabel17, xrShape1 });
		footerClassTeacher.HeightF = 69f;
		footerClassTeacher.KeepTogether = true;
		footerClassTeacher.Level = 2;
		footerClassTeacher.Name = "footerClassTeacher";
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[OtherRequirements]")
		});
		xrLabel1.LocationFloat = new PointFloat(620.5f, 31.5f);
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
		lblClassteacherComment.LocationFloat = new PointFloat(8.500006f, 36.00001f);
		lblClassteacherComment.Name = "lblClassteacherComment";
		lblClassteacherComment.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblClassteacherComment.SizeF = new SizeF(603.9999f, 23f);
		lblClassteacherComment.StylePriority.UseFont = false;
		lblClassteacherComment.WordWrap = false;
		xrShape2.LocationFloat = new PointFloat(617.9999f, 5f);
		xrShape2.Name = "xrShape2";
		xrShape2.Shape = shape;
		xrShape2.SizeF = new SizeF(2f, 64f);
		xrLabel9.Font = new DXFont("Cascadia Mono", 10f);
		xrLabel9.LocationFloat = new PointFloat(622.9999f, 9f);
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
		xrLabel17.LocationFloat = new PointFloat(9.000019f, 9.99999f);
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
		xrShape1.LocationFloat = new PointFloat(0f, 5f);
		xrShape1.Name = "xrShape1";
		xrShape1.Shape = shape2;
		xrShape1.SizeF = new SizeF(774.9998f, 64f);
		footerHeadTeacher.Controls.AddRange(new XRControl[5] { lblHeadteacherComment, xrLabel19, xrLabel15, xrShape3, xrShape4 });
		footerHeadTeacher.HeightF = 69f;
		footerHeadTeacher.KeepTogether = true;
		footerHeadTeacher.Level = 3;
		footerHeadTeacher.Name = "footerHeadTeacher";
		lblHeadteacherComment.CanGrow = false;
		lblHeadteacherComment.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HeadteacherRemark]")
		});
		lblHeadteacherComment.Font = new DXFont("Tahoma", 11f);
		lblHeadteacherComment.LocationFloat = new PointFloat(7.500013f, 37.99999f);
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
		xrLabel19.LocationFloat = new PointFloat(9.000019f, 9.99999f);
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
		xrLabel15.LocationFloat = new PointFloat(622.9999f, 9f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Signature";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrShape3.LocationFloat = new PointFloat(617.9999f, 5f);
		xrShape3.Name = "xrShape3";
		xrShape3.Shape = shape3;
		xrShape3.SizeF = new SizeF(2f, 64f);
		xrShape4.LocationFloat = new PointFloat(0f, 5f);
		xrShape4.Name = "xrShape4";
		xrShape4.Shape = shape4;
		xrShape4.SizeF = new SizeF(774.9998f, 64f);
		OtherFeesRequirements.Description = "Other Fees Requirements";
		OtherFeesRequirements.Name = "OtherFeesRequirements";
		OtherFeesRequirements.Visible = false;
		newCurriculumSubReport5.DataSetName = "NewCurriculumSubReport";
		newCurriculumSubReport5.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		adapterNewCurriculumSubAssessed4.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[8] { TopMargin, BottomMargin, Detail, GroupHeader1, GroupFooter1, GroupFooter2, footerClassTeacher, footerHeadTeacher });
		base.CalculatedFields.AddRange(new CalculatedField[1] { calculatedField1 });
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
		base.SnapGridSize = 1f;
		base.Version = "23.2";
		xRWatermark.Id = "Watermark1";
		base.Watermarks.AddRange(new Watermark[1] { xRWatermark });
		BeforePrint += NewCurriculumSubUpperLO_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)xrTable2).EndInit();
		((ISupportInitialize)xrTable3).EndInit();
		((ISupportInitialize)xrTable4).EndInit();
		((ISupportInitialize)tblClassRanking).EndInit();
		((ISupportInitialize)newCurriculumSubReport5).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
