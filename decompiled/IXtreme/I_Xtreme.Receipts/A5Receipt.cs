using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using AlienAge.Connectivity;
using AlienAge.ReportHeaders;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.Receipts.dsReceiptTableAdapters;

namespace I_Xtreme.Receipts;

public class A5Receipt : XtraReport
{
	private string studentNumber = string.Empty;

	private string receiptNo = string.Empty;

	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private GroupHeaderBand GroupHeader1;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private GroupFooterBand GroupFooter1;

	private XRLabel lblTotal;

	private XRPictureBox xrPictureBox1;

	private XRLabel xrLabel6;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	private ReportFooterBand ReportFooter;

	private XRLabel xrLabel9;

	private XRLabel xrLabel11;

	private XRLabel lblCashier;

	private XRLabel xrLabel14;

	private XRLabel xrLabel13;

	private XRLabel xrLabel12;

	private XRLabel xrLabel10;

	private PageHeaderBand PageHeader;

	private XRLabel lblContact;

	private XRLabel lblLocation;

	private XRLabel lblSchool;

	private XRLabel lblAmountInWords;

	private Parameter ReceiptNo;

	private CalculatedField TotalReceipt;

	private XRLabel lblBalance;

	private XRLabel xrLabel5;

	private XRPageInfo xrPageInfo1;

	private XRLine xrLine1;

	private XRLabel xrLabel16;

	private XRLabel xrLabel15;

	private XRPictureBox xrPictureBox2;

	private XRLabel xrLabel19;

	private XRLabel xrLabel18;

	private XRLabel lblStudentNumber;

	private BackgroundWorker backgroundWorker1;

	private XRCrossBandBox xrCrossBandBox1;

	private XRLabel xrLabel22;

	private XRLabel xrLabel21;

	private XRLabel xrLabel20;

	private dsReceipt dsReceipt1;

	private rctDataAdapter rctDataAdapter;

	private XRLabel xrLabel17;

	private double FeesBalance
	{
		get
		{
			double result = 0.0;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SUM(Debit) - SUM(Credit) AS cashOnAccount FROM    FeesPayment  WHERE (StudentNumber = '{studentNumber}') GROUP BY StudentNumber", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "FeesBalance");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				IEnumerator enumerator = dataTable.Rows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						result = (double.TryParse(dataRow["cashOnAccount"].ToString(), out result) ? result : 0.0);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			return result;
		}
	}

	private double ReceiptTotal
	{
		get
		{
			double result = 0.0;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SUM(Credit) AS Total FROM    FeesPayment  WHERE (BankSlipNo = '{receiptNo}') GROUP BY BankSlipNo", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "FeesBalance");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				IEnumerator enumerator = dataTable.Rows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						result = (double.TryParse(dataRow["Total"].ToString(), out result) ? result : 0.0);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			return result;
		}
	}

	public A5Receipt(string StudentNumber, string ReceipNo, bool PrintImage)
	{
		InitializeComponent();
		studentNumber = StudentNumber;
		ReceiptNo.Value = ReceipNo;
		receiptNo = ReceipNo;
		xrPictureBox1.Visible = PrintImage;
		xrPictureBox2.Visible = PrintImage;
	}

	private void A5Receipt_BeforePrint(object sender, CancelEventArgs e)
	{
		lblSchool.Text = ReportHeader.SchoolName;
		lblLocation.Text = ReportHeader.SchoolFullAddress;
		lblContact.Text = ReportHeader.SchoolLocation;
		xrPictureBox2.Image = ReportHeader.SchoolLogo;
		lblCashier.Text = "Printed by: " + CurrentUser.UserFullName;
		if (ReportHeader.SelectedCode == 0)
		{
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]"));
		}
		else if (ReportHeader.SelectedCode == 1)
		{
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[StudentID]"));
		}
		else if (ReportHeader.SelectedCode == 2)
		{
			lblStudentNumber.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[LIN]"));
		}
	}

	private void lblBalance_BeforePrint(object sender, CancelEventArgs e)
	{
		if (FeesBalance == 0.0)
		{
			lblBalance.Text = "NIL";
		}
		else
		{
			lblBalance.Text = FeesBalance.ToString("#,#");
		}
	}

	private void lblAmountInWords_BeforePrint(object sender, CancelEventArgs e)
	{
		NumberToWordsConverter numberToWordsConverter = new NumberToWordsConverter();
		lblAmountInWords.Text = "Amount in words: " + numberToWordsConverter.NumberToWords((long)ReceiptTotal);
	}

	private void lblTotal_BeforePrint(object sender, CancelEventArgs e)
	{
		lblTotal.Text = ReceiptTotal.ToString("#,#");
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
		xrLine1 = new XRLine();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		GroupHeader1 = new GroupHeaderBand();
		xrLabel19 = new XRLabel();
		xrLabel18 = new XRLabel();
		lblStudentNumber = new XRLabel();
		xrLabel16 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		xrLabel6 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		GroupFooter1 = new GroupFooterBand();
		xrLabel5 = new XRLabel();
		lblBalance = new XRLabel();
		xrLabel11 = new XRLabel();
		lblTotal = new XRLabel();
		ReportFooter = new ReportFooterBand();
		xrLabel22 = new XRLabel();
		xrLabel21 = new XRLabel();
		xrLabel20 = new XRLabel();
		xrPageInfo1 = new XRPageInfo();
		lblAmountInWords = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel12 = new XRLabel();
		lblCashier = new XRLabel();
		xrLabel9 = new XRLabel();
		PageHeader = new PageHeaderBand();
		xrPictureBox2 = new XRPictureBox();
		lblContact = new XRLabel();
		lblLocation = new XRLabel();
		lblSchool = new XRLabel();
		ReceiptNo = new Parameter();
		TotalReceipt = new CalculatedField();
		backgroundWorker1 = new BackgroundWorker();
		xrCrossBandBox1 = new XRCrossBandBox();
		dsReceipt1 = new dsReceipt();
		rctDataAdapter = new rctDataAdapter();
		xrLabel17 = new XRLabel();
		((ISupportInitialize)dsReceipt1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[3] { xrLine1, xrLabel2, xrLabel1 });
		Detail.HeightF = 25f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrLine1.LineStyle = DXDashStyle.Dash;
		xrLine1.LocationFloat = new PointFloat(1.000002f, 23f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(775.9999f, 2f);
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Credit]")
		});
		xrLabel2.LocationFloat = new PointFloat(599.2222f, 0f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(177.7778f, 23f);
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.TextAlignment = TextAlignment.MiddleRight;
		xrLabel2.TextFormatString = "{0:#,#}";
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Particulars]")
		});
		xrLabel1.LocationFloat = new PointFloat(0f, 0f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(143.75f, 23f);
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.TextAlignment = TextAlignment.MiddleLeft;
		TopMargin.HeightF = 25f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		BottomMargin.HeightF = 25f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		GroupHeader1.Controls.AddRange(new XRControl[12]
		{
			xrLabel17, xrLabel19, xrLabel18, lblStudentNumber, xrLabel16, xrLabel15, xrLabel8, xrLabel7, xrPictureBox1, xrLabel6,
			xrLabel4, xrLabel3
		});
		GroupHeader1.HeightF = 215f;
		GroupHeader1.Name = "GroupHeader1";
		xrLabel19.BackColor = Color.Black;
		xrLabel19.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel19.ForeColor = Color.White;
		xrLabel19.LocationFloat = new PointFloat(686f, 7.000001f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(85.00012f, 27.00001f);
		xrLabel19.StylePriority.UseBackColor = false;
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseForeColor = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "RECEIPT";
		xrLabel19.TextAlignment = TextAlignment.MiddleRight;
		xrLabel18.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrLabel18.LocationFloat = new PointFloat(4.000012f, 45f);
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(193f, 23f);
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.Text = "Student Information";
		xrLabel18.TextAlignment = TextAlignment.MiddleLeft;
		lblStudentNumber.CanGrow = false;
		lblStudentNumber.Font = new DXFont("Consolas", 13f);
		lblStudentNumber.LocationFloat = new PointFloat(115f, 135f);
		lblStudentNumber.Name = "lblStudentNumber";
		lblStudentNumber.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblStudentNumber.SizeF = new SizeF(299f, 23f);
		lblStudentNumber.StylePriority.UseFont = false;
		lblStudentNumber.StylePriority.UseTextAlignment = false;
		lblStudentNumber.Text = "lblStudentNumber";
		lblStudentNumber.TextAlignment = TextAlignment.MiddleLeft;
		lblStudentNumber.TextFormatString = "Fees Code:{0}";
		lblStudentNumber.WordWrap = false;
		xrLabel16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrLabel16.Font = new DXFont("Consolas", 13f);
		xrLabel16.LocationFloat = new PointFloat(568.0001f, 135f);
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(201f, 23f);
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.StylePriority.UseTextAlignment = false;
		xrLabel16.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel16.TextFormatString = "Stream: {0}";
		xrLabel15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel15.Font = new DXFont("Consolas", 13f);
		xrLabel15.LocationFloat = new PointFloat(416f, 135f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(151f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel15.TextFormatString = "Class: {0}";
		xrLabel8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[DateOfPayment]")
		});
		xrLabel8.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrLabel8.LocationFloat = new PointFloat(445.0001f, 43f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(326.3889f, 23f);
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.TextAlignment = TextAlignment.MiddleRight;
		xrLabel8.TextFormatString = "Date: {0:dd-MMM-yy}";
		xrLabel7.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel7.Font = new DXFont("Consolas", 13f);
		xrLabel7.LocationFloat = new PointFloat(117f, 95f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(652.0001f, 23f);
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel7.TextFormatString = "Name: {0}";
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(11f, 84f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(98.99988f, 89.00002f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrLabel6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PaymentId]")
		});
		xrLabel6.Font = new DXFont("Tahoma", 12f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.LocationFloat = new PointFloat(3.999996f, 7.999992f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(238f, 27.00001f);
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.TextFormatString = "Receipt No: [{0}] ";
		xrLabel4.LocationFloat = new PointFloat(596f, 192f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(177.7778f, 23f);
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Amount";
		xrLabel4.TextAlignment = TextAlignment.MiddleRight;
		xrLabel3.LocationFloat = new PointFloat(5.000003f, 192f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(143.75f, 23f);
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "Particulars";
		xrLabel3.TextAlignment = TextAlignment.MiddleLeft;
		GroupFooter1.Controls.AddRange(new XRControl[4] { xrLabel5, lblBalance, xrLabel11, lblTotal });
		GroupFooter1.HeightF = 49.47221f;
		GroupFooter1.Name = "GroupFooter1";
		xrLabel5.LocationFloat = new PointFloat(0f, 26f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(143.75f, 23f);
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Balance:";
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		lblBalance.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		lblBalance.LocationFloat = new PointFloat(599.0001f, 26f);
		lblBalance.Name = "lblBalance";
		lblBalance.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblBalance.SizeF = new SizeF(177.9999f, 23f);
		lblBalance.StylePriority.UseFont = false;
		lblBalance.StylePriority.UseTextAlignment = false;
		lblBalance.TextAlignment = TextAlignment.MiddleRight;
		lblBalance.TextFormatString = "{0:#,#.0}";
		lblBalance.BeforePrint += lblBalance_BeforePrint;
		xrLabel11.LocationFloat = new PointFloat(0f, 0f);
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(143.75f, 23f);
		xrLabel11.StylePriority.UseTextAlignment = false;
		xrLabel11.Text = "Total:";
		xrLabel11.TextAlignment = TextAlignment.MiddleLeft;
		lblTotal.CanGrow = false;
		lblTotal.LocationFloat = new PointFloat(599.2222f, 0f);
		lblTotal.Name = "lblTotal";
		lblTotal.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblTotal.SizeF = new SizeF(177.7778f, 23f);
		lblTotal.StylePriority.UseTextAlignment = false;
		lblTotal.TextAlignment = TextAlignment.MiddleRight;
		lblTotal.WordWrap = false;
		lblTotal.BeforePrint += lblTotal_BeforePrint;
		ReportFooter.Controls.AddRange(new XRControl[11]
		{
			xrLabel22, xrLabel21, xrLabel20, xrPageInfo1, lblAmountInWords, xrLabel10, xrLabel14, xrLabel13, xrLabel12, lblCashier,
			xrLabel9
		});
		ReportFooter.Name = "ReportFooter";
		xrLabel22.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrLabel22.LocationFloat = new PointFloat(633.9999f, 47.99995f);
		xrLabel22.Multiline = true;
		xrLabel22.Name = "xrLabel22";
		xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel22.SizeF = new SizeF(140.0001f, 22.99999f);
		xrLabel22.StylePriority.UseFont = false;
		xrLabel22.StylePriority.UseTextAlignment = false;
		xrLabel22.Text = "Airtel: *165*6*4#";
		xrLabel22.TextAlignment = TextAlignment.MiddleRight;
		xrLabel21.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrLabel21.LocationFloat = new PointFloat(633.9999f, 23.99991f);
		xrLabel21.Multiline = true;
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(140.0001f, 23f);
		xrLabel21.StylePriority.UseFont = false;
		xrLabel21.StylePriority.UseTextAlignment = false;
		xrLabel21.Text = "MTN: *165*4*3*6#";
		xrLabel21.TextAlignment = TextAlignment.MiddleRight;
		xrLabel20.Font = new DXFont("Consolas", 10f, DXFontStyle.Bold);
		xrLabel20.LocationFloat = new PointFloat(469f, 23.99998f);
		xrLabel20.Multiline = true;
		xrLabel20.Name = "xrLabel20";
		xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel20.SizeF = new SizeF(165f, 23f);
		xrLabel20.StylePriority.UseFont = false;
		xrLabel20.StylePriority.UseTextAlignment = false;
		xrLabel20.Text = "Pay with surepay";
		xrLabel20.TextAlignment = TextAlignment.MiddleRight;
		xrPageInfo1.LocationFloat = new PointFloat(549.0001f, 77f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.PageInfo = PageInfo.DateTime;
		xrPageInfo1.SizeF = new SizeF(225.9999f, 23f);
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
		lblAmountInWords.LocationFloat = new PointFloat(0f, 0f);
		lblAmountInWords.Name = "lblAmountInWords";
		lblAmountInWords.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblAmountInWords.SizeF = new SizeF(777f, 23f);
		lblAmountInWords.StylePriority.UseTextAlignment = false;
		lblAmountInWords.Text = "Amount in words";
		lblAmountInWords.TextAlignment = TextAlignment.MiddleCenter;
		lblAmountInWords.BeforePrint += lblAmountInWords_BeforePrint;
		xrLabel10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[BankSlipNo]")
		});
		xrLabel10.LocationFloat = new PointFloat(0f, 76f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(141f, 24f);
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel10.TextFormatString = "rct#:{0}";
		xrLabel14.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel14.Borders = BorderSide.Bottom;
		xrLabel14.LocationFloat = new PointFloat(320.4445f, 77f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(136.1111f, 23f);
		xrLabel14.StylePriority.UseBorderDashStyle = false;
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel13.LocationFloat = new PointFloat(456.5556f, 77f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(91.66666f, 23f);
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "THANK YOU";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		xrLabel12.LocationFloat = new PointFloat(228.7778f, 77f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(91.66666f, 23f);
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Signature:";
		xrLabel12.TextAlignment = TextAlignment.BottomLeft;
		lblCashier.LocationFloat = new PointFloat(0f, 46.22218f);
		lblCashier.Name = "lblCashier";
		lblCashier.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblCashier.SizeF = new SizeF(272.9999f, 23f);
		lblCashier.StylePriority.UseTextAlignment = false;
		lblCashier.Text = "Cashier's name";
		lblCashier.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ModeOfPayment]")
		});
		xrLabel9.LocationFloat = new PointFloat(0f, 23.22222f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(274f, 23f);
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel9.TextFormatString = "Payment by: {0}";
		PageHeader.Controls.AddRange(new XRControl[4] { xrPictureBox2, lblContact, lblLocation, lblSchool });
		PageHeader.HeightF = 71f;
		PageHeader.Name = "PageHeader";
		xrPictureBox2.LocationFloat = new PointFloat(2.000003f, 1.000002f);
		xrPictureBox2.Name = "xrPictureBox2";
		xrPictureBox2.SizeF = new SizeF(81.00002f, 69.99999f);
		xrPictureBox2.Sizing = ImageSizeMode.StretchImage;
		lblContact.LocationFloat = new PointFloat(91.00001f, 48f);
		lblContact.Name = "lblContact";
		lblContact.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblContact.SizeF = new SizeF(685.9999f, 23f);
		lblContact.StylePriority.UseTextAlignment = false;
		lblContact.Text = "Contact";
		lblContact.TextAlignment = TextAlignment.MiddleCenter;
		lblLocation.LocationFloat = new PointFloat(91.00001f, 28.00001f);
		lblLocation.Name = "lblLocation";
		lblLocation.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblLocation.SizeF = new SizeF(685.9999f, 19.99999f);
		lblLocation.StylePriority.UseTextAlignment = false;
		lblLocation.Text = "Location";
		lblLocation.TextAlignment = TextAlignment.MiddleCenter;
		lblSchool.Font = new DXFont("Consolas", 18f, DXFontStyle.Bold);
		lblSchool.LocationFloat = new PointFloat(91.00001f, 0f);
		lblSchool.Name = "lblSchool";
		lblSchool.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchool.SizeF = new SizeF(685.9999f, 28.00001f);
		lblSchool.StylePriority.UseFont = false;
		lblSchool.StylePriority.UseTextAlignment = false;
		lblSchool.Text = "School";
		lblSchool.TextAlignment = TextAlignment.MiddleCenter;
		ReceiptNo.Description = "ReceiptNo";
		ReceiptNo.Name = "ReceiptNo";
		ReceiptNo.Visible = false;
		TotalReceipt.DataMember = "DataTableFeesPayment";
		TotalReceipt.Name = "TotalReceipt";
		xrCrossBandBox1.AnchorVertical = VerticalAnchorStyles.None;
		xrCrossBandBox1.EndBand = GroupHeader1;
		xrCrossBandBox1.EndPointFloat = new PointFloat(3.999996f, 191f);
		xrCrossBandBox1.Name = "xrCrossBandBox1";
		xrCrossBandBox1.StartBand = GroupHeader1;
		xrCrossBandBox1.StartPointFloat = new PointFloat(3.999996f, 71f);
		xrCrossBandBox1.WidthF = 769.9999f;
		dsReceipt1.DataSetName = "dsReceipt";
		dsReceipt1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		rctDataAdapter.ClearBeforeFill = true;
		xrLabel17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[BankSlipNo]")
		});
		xrLabel17.Font = new DXFont("Tahoma", 12f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel17.LocationFloat = new PointFloat(299f, 7.999992f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(238f, 27.00001f);
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel17.TextFormatString = "Tranx. Ref: [{0}] ";
		base.Bands.AddRange(new Band[7] { Detail, TopMargin, BottomMargin, GroupHeader1, GroupFooter1, ReportFooter, PageHeader });
		base.CalculatedFields.AddRange(new CalculatedField[1] { TotalReceipt });
		base.ComponentStorage.AddRange(new IComponent[1] { dsReceipt1 });
		base.CrossBandControls.AddRange(new XRCrossBandControl[1] { xrCrossBandBox1 });
		base.DataAdapter = rctDataAdapter;
		base.DataMember = "dtReceipt";
		base.DataSource = dsReceipt1;
		FilterString = "[BankSlipNo] = ?ReceiptNo";
		Font = new DXFont("Consolas", 10f);
		base.Margins = new DXMargins(25f, 25f, 25f, 25f);
		base.PageHeight = 583;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A5Rotated;
		base.Parameters.AddRange(new Parameter[1] { ReceiptNo });
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "23.2";
		BeforePrint += A5Receipt_BeforePrint;
		((ISupportInitialize)dsReceipt1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
