using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.Drawing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.PaymentVoucher.PaymentVoucherTableAdapters;

namespace I_Xtreme.PaymentVoucher;

public class PaymentVoucherRpt : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRTable detailTable;

	private XRTableRow detailTableRow;

	private XRTableCell productName;

	private XRTableCell lineTotal;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private GroupHeaderBand GroupHeader1;

	private XRLabel invoiceDate;

	private XRTable vendorTable;

	private XRTableRow vendorNameRow;

	private XRTableCell lblName;

	private XRTableRow vendorAddressRow;

	private XRTableCell lblContacts;

	private XRTableRow vendorCityRow;

	private XRTableCell lblAddress;

	private XRTable customerTable;

	private XRTableRow customerNameRow;

	private XRTableCell customerName;

	private XRTableRow customerAddressRow;

	private XRTableCell customerAddress;

	private XRTableRow customerCityRow;

	private XRTableCell customerCity;

	private XRTableRow customerCountryRow;

	private XRTableCell customerCountry;

	private SubBand SubBand1;

	private XRTable headerTable;

	private XRTableRow headerTableRow;

	private XRTableCell productNameCaption;

	private XRTableCell lineTotalCaption;

	private XRTable invoiceNumberTable;

	private XRTableRow invoiceNumberCaptionRow;

	private XRTableCell invoiceNumberCaption;

	private XRTableRow invoiceNumberRow;

	private XRTableCell invoiceNumber;

	private XRLabel invoiceLabel;

	private GroupFooterBand footerTotals;

	private XRTable totalTable;

	private XRTableRow totalRow;

	private XRTableCell totalCaption;

	private XRTableCell lblTotal;

	private XRControlStyle baseControlStyle;

	private PaymentVoucher paymentVoucher1;

	private PaymentVoucherTableAdapter paymentVoucherTableAdapter;

	private XRLabel xrLabel1;

	private XRLabel xrLabel2;

	private GroupFooterBand footerAuthorities;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel14;

	private XRLabel xrLabel13;

	private XRLabel xrLabel12;

	private XRLabel xrLabel11;

	private XRLabel xrLabel10;

	private XRLabel xrLabel9;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	private SubBand SubBand2;

	private XRLabel lblAmountInWords;

	private XRLabel xrLabel15;

	private GroupFooterBand footerPaymentMode;

	private XRLabel xrLabel16;

	private XRLabel xrLabel17;

	private XRPictureBox xrPictureBox1;

	private CalculatedField calculatedField1;

	private Parameter voucherNo;

	private XRLabel xrLabel18;

	private XRLabel xrLabel19;

	private XRLabel xrLabel20;

	private XRLabel xrLabel21;

	public PaymentVoucherRpt()
	{
		InitializeComponent();
		voucherNo.Value = VoucherParameters.VoucherNoSelected;
	}

	private void PaymentVoucherRpt_BeforePrint(object sender, CancelEventArgs e)
	{
		try
		{
			string selectConnectionString = DataConnection.ConnectToDatabase();
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SchoolName,fullContact,location,logo FROM SchoolDetails", selectConnectionString))
			{
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "header");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					lblName.Text = AlienAge.Security.CryptorEngine.Decrypt(row["SchoolName"].ToString());
					lblContacts.Text = row["fullContact"].ToString();
					lblAddress.Text = AlienAge.Security.CryptorEngine.Decrypt(row["location"].ToString());
					byte[] array = new byte[0];
					array = (byte[])row["logo"];
					using MemoryStream stream = new MemoryStream(array);
					xrPictureBox1.Image = Image.FromStream(stream);
					base.Watermark.Image = Image.FromStream(stream);
					base.Watermark.ImageTransparency = 230;
				}
			}
			NumberToWordsConverter numberToWordsConverter = new NumberToWordsConverter();
			lblAmountInWords.Text = numberToWordsConverter.NumberToWords(I_Xtreme.ExtremeClasses.PaymentVoucher.VoucherTotal) + " shillings only";
		}
		catch (Exception)
		{
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
		Detail = new DetailBand();
		detailTable = new XRTable();
		detailTableRow = new XRTableRow();
		productName = new XRTableCell();
		lineTotal = new XRTableCell();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		GroupHeader1 = new GroupHeaderBand();
		xrPictureBox1 = new XRPictureBox();
		invoiceNumberTable = new XRTable();
		invoiceNumberCaptionRow = new XRTableRow();
		invoiceNumberCaption = new XRTableCell();
		invoiceNumberRow = new XRTableRow();
		invoiceNumber = new XRTableCell();
		invoiceLabel = new XRLabel();
		invoiceDate = new XRLabel();
		vendorTable = new XRTable();
		vendorNameRow = new XRTableRow();
		lblName = new XRTableCell();
		vendorAddressRow = new XRTableRow();
		lblContacts = new XRTableCell();
		vendorCityRow = new XRTableRow();
		lblAddress = new XRTableCell();
		customerTable = new XRTable();
		customerNameRow = new XRTableRow();
		customerName = new XRTableCell();
		customerAddressRow = new XRTableRow();
		customerAddress = new XRTableCell();
		customerCityRow = new XRTableRow();
		customerCity = new XRTableCell();
		customerCountryRow = new XRTableRow();
		customerCountry = new XRTableCell();
		SubBand1 = new SubBand();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		headerTable = new XRTable();
		headerTableRow = new XRTableRow();
		productNameCaption = new XRTableCell();
		lineTotalCaption = new XRTableCell();
		footerTotals = new GroupFooterBand();
		totalTable = new XRTable();
		totalRow = new XRTableRow();
		totalCaption = new XRTableCell();
		lblTotal = new XRTableCell();
		SubBand2 = new SubBand();
		lblAmountInWords = new XRLabel();
		xrLabel15 = new XRLabel();
		baseControlStyle = new XRControlStyle();
		paymentVoucher1 = new PaymentVoucher();
		paymentVoucherTableAdapter = new PaymentVoucherTableAdapter();
		footerAuthorities = new GroupFooterBand();
		xrLabel18 = new XRLabel();
		xrLabel19 = new XRLabel();
		xrLabel20 = new XRLabel();
		xrLabel21 = new XRLabel();
		xrLabel14 = new XRLabel();
		xrLabel13 = new XRLabel();
		xrLabel12 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		footerPaymentMode = new GroupFooterBand();
		xrLabel16 = new XRLabel();
		xrLabel17 = new XRLabel();
		calculatedField1 = new CalculatedField();
		voucherNo = new Parameter();
		((ISupportInitialize)detailTable).BeginInit();
		((ISupportInitialize)invoiceNumberTable).BeginInit();
		((ISupportInitialize)vendorTable).BeginInit();
		((ISupportInitialize)customerTable).BeginInit();
		((ISupportInitialize)headerTable).BeginInit();
		((ISupportInitialize)totalTable).BeginInit();
		((ISupportInitialize)paymentVoucher1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { detailTable });
		Detail.HeightF = 30f;
		Detail.KeepTogether = true;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "baseControlStyle";
		Detail.TextAlignment = TextAlignment.TopLeft;
		detailTable.AnchorHorizontal = HorizontalAnchorStyles.Right;
		detailTable.BorderColor = Color.FromArgb(198, 198, 198);
		detailTable.Borders = BorderSide.Bottom;
		detailTable.LocationFloat = new PointFloat(0f, 0f);
		detailTable.Name = "detailTable";
		detailTable.Rows.AddRange(new XRTableRow[1] { detailTableRow });
		detailTable.SizeF = new SizeF(669.6851f, 30f);
		detailTable.StylePriority.UseBorderColor = false;
		detailTable.StylePriority.UseBorders = false;
		detailTable.StylePriority.UseFont = false;
		detailTableRow.Cells.AddRange(new XRTableCell[2] { productName, lineTotal });
		detailTableRow.Name = "detailTableRow";
		detailTableRow.Weight = 10.58;
		productName.CanGrow = false;
		productName.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ExpenseName]")
		});
		productName.Name = "productName";
		productName.Padding = new PaddingInfo(10, 2, 5, 0, 100f);
		productName.StylePriority.UsePadding = false;
		productName.Text = "ExpenseName";
		productName.Weight = 1.3510234578775113;
		productName.WordWrap = false;
		lineTotal.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ExpenseValue]")
		});
		lineTotal.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		lineTotal.Name = "lineTotal";
		lineTotal.Padding = new PaddingInfo(2, 2, 5, 0, 100f);
		lineTotal.StylePriority.UseFont = false;
		lineTotal.StylePriority.UseForeColor = false;
		lineTotal.StylePriority.UsePadding = false;
		lineTotal.StylePriority.UseTextAlignment = false;
		lineTotal.Text = "0.00";
		lineTotal.TextAlignment = TextAlignment.TopRight;
		lineTotal.TextFormatString = "{0:#,#}";
		lineTotal.Weight = 0.5796564761248313;
		TopMargin.HeightF = 25f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.StylePriority.UseBackColor = false;
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		BottomMargin.HeightF = 30f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		GroupHeader1.Controls.AddRange(new XRControl[6] { xrPictureBox1, invoiceNumberTable, invoiceLabel, invoiceDate, vendorTable, customerTable });
		GroupHeader1.GroupUnion = GroupUnion.WithFirstDetail;
		GroupHeader1.HeightF = 233.625f;
		GroupHeader1.Name = "GroupHeader1";
		GroupHeader1.StyleName = "baseControlStyle";
		GroupHeader1.StylePriority.UseBackColor = false;
		GroupHeader1.SubBands.AddRange(new SubBand[1] { SubBand1 });
		xrPictureBox1.LocationFloat = new PointFloat(582.1851f, 0f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(87.5f, 75f);
		xrPictureBox1.Sizing = ImageSizeMode.ZoomImage;
		invoiceNumberTable.LocationFloat = new PointFloat(475f, 150f);
		invoiceNumberTable.Name = "invoiceNumberTable";
		invoiceNumberTable.Rows.AddRange(new XRTableRow[2] { invoiceNumberCaptionRow, invoiceNumberRow });
		invoiceNumberTable.SizeF = new SizeF(190.6667f, 40f);
		invoiceNumberCaptionRow.Cells.AddRange(new XRTableCell[1] { invoiceNumberCaption });
		invoiceNumberCaptionRow.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		invoiceNumberCaptionRow.Name = "invoiceNumberCaptionRow";
		invoiceNumberCaptionRow.StylePriority.UseFont = false;
		invoiceNumberCaptionRow.Weight = 0.2666666666666667;
		invoiceNumberCaption.CanShrink = true;
		invoiceNumberCaption.Name = "invoiceNumberCaption";
		invoiceNumberCaption.StylePriority.UseTextAlignment = false;
		invoiceNumberCaption.Text = "Voucher No";
		invoiceNumberCaption.TextAlignment = TextAlignment.TopRight;
		invoiceNumberCaption.Weight = 1.0235326443596697;
		invoiceNumberRow.Cells.AddRange(new XRTableCell[1] { invoiceNumber });
		invoiceNumberRow.Name = "invoiceNumberRow";
		invoiceNumberRow.Weight = 4.0 / 15.0;
		invoiceNumber.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[VoucherNo]")
		});
		invoiceNumber.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		invoiceNumber.ForeColor = Color.Red;
		invoiceNumber.Name = "invoiceNumber";
		invoiceNumber.StylePriority.UseFont = false;
		invoiceNumber.StylePriority.UseForeColor = false;
		invoiceNumber.StylePriority.UseTextAlignment = false;
		invoiceNumber.Text = "VoucherNo";
		invoiceNumber.TextAlignment = TextAlignment.TopRight;
		invoiceNumber.Weight = 1.0235326443596697;
		invoiceLabel.Font = new DXFont("Segoe UI", 24f, DXFontStyle.Bold);
		invoiceLabel.LocationFloat = new PointFloat(0f, 0f);
		invoiceLabel.Name = "invoiceLabel";
		invoiceLabel.SizeF = new SizeF(294.79f, 45f);
		invoiceLabel.StylePriority.UseFont = false;
		invoiceLabel.StylePriority.UsePadding = false;
		invoiceLabel.StylePriority.UseTextAlignment = false;
		invoiceLabel.Text = "Payment Voucher";
		invoiceLabel.TextAlignment = TextAlignment.TopLeft;
		invoiceDate.AnchorHorizontal = HorizontalAnchorStyles.Right;
		invoiceDate.CanGrow = false;
		invoiceDate.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[DateOfExpense]")
		});
		invoiceDate.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		invoiceDate.LocationFloat = new PointFloat(475f, 197f);
		invoiceDate.Name = "invoiceDate";
		invoiceDate.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		invoiceDate.SizeF = new SizeF(194.6851f, 22.99998f);
		invoiceDate.StylePriority.UseFont = false;
		invoiceDate.StylePriority.UseTextAlignment = false;
		invoiceDate.TextAlignment = TextAlignment.MiddleRight;
		invoiceDate.TextFormatString = "Date: {0:dd-MMM-yyyy}";
		invoiceDate.WordWrap = false;
		vendorTable.AnchorHorizontal = HorizontalAnchorStyles.Right;
		vendorTable.Font = new DXFont("Segoe UI", 8.25f);
		vendorTable.LocationFloat = new PointFloat(262.5f, 75f);
		vendorTable.Name = "vendorTable";
		vendorTable.Rows.AddRange(new XRTableRow[3] { vendorNameRow, vendorAddressRow, vendorCityRow });
		vendorTable.SizeF = new SizeF(407.1851f, 60f);
		vendorTable.StylePriority.UseFont = false;
		vendorTable.StylePriority.UseTextAlignment = false;
		vendorTable.TextAlignment = TextAlignment.TopRight;
		vendorNameRow.Cells.AddRange(new XRTableCell[1] { lblName });
		vendorNameRow.Name = "vendorNameRow";
		vendorNameRow.Weight = 0.8;
		lblName.CanShrink = true;
		lblName.Font = new DXFont("Segoe UI", 12f, DXFontStyle.Bold);
		lblName.Name = "lblName";
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UsePadding = false;
		lblName.Text = "VendorName";
		lblName.Weight = 1.0;
		vendorAddressRow.Cells.AddRange(new XRTableCell[1] { lblContacts });
		vendorAddressRow.Name = "vendorAddressRow";
		vendorAddressRow.Weight = 0.8;
		lblContacts.CanShrink = true;
		lblContacts.Name = "lblContacts";
		lblContacts.StylePriority.UseFont = false;
		lblContacts.Text = "VendorAddress";
		lblContacts.Weight = 1.0;
		vendorCityRow.Cells.AddRange(new XRTableCell[1] { lblAddress });
		vendorCityRow.Name = "vendorCityRow";
		vendorCityRow.Weight = 0.8;
		lblAddress.CanShrink = true;
		lblAddress.Name = "lblAddress";
		lblAddress.StylePriority.UseFont = false;
		lblAddress.Text = "VendorCity";
		lblAddress.Weight = 1.0;
		customerTable.LocationFloat = new PointFloat(0f, 75f);
		customerTable.Name = "customerTable";
		customerTable.Rows.AddRange(new XRTableRow[4] { customerNameRow, customerAddressRow, customerCityRow, customerCountryRow });
		customerTable.SizeF = new SizeF(250f, 100f);
		customerNameRow.Cells.AddRange(new XRTableCell[1] { customerName });
		customerNameRow.Name = "customerNameRow";
		customerNameRow.Weight = 1.0;
		customerName.CanShrink = true;
		customerName.Font = new DXFont("Segoe UI", 12f, DXFontStyle.Bold);
		customerName.Name = "customerName";
		customerName.StylePriority.UseFont = false;
		customerName.StylePriority.UsePadding = false;
		customerName.Text = "Payee";
		customerName.Weight = 1.191547728468558;
		customerAddressRow.Cells.AddRange(new XRTableCell[1] { customerAddress });
		customerAddressRow.Name = "customerAddressRow";
		customerAddressRow.Weight = 1.0;
		customerAddress.CanShrink = true;
		customerAddress.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Payee]")
		});
		customerAddress.Name = "customerAddress";
		customerAddress.Text = "CustomerAddress";
		customerAddress.Weight = 1.191547728468558;
		customerCityRow.Cells.AddRange(new XRTableCell[1] { customerCity });
		customerCityRow.Name = "customerCityRow";
		customerCityRow.Weight = 1.0;
		customerCity.CanGrow = false;
		customerCity.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Contact]")
		});
		customerCity.Name = "customerCity";
		customerCity.Text = "CustomerCity";
		customerCity.Weight = 1.191547728468558;
		customerCity.WordWrap = false;
		customerCountryRow.Cells.AddRange(new XRTableCell[1] { customerCountry });
		customerCountryRow.Name = "customerCountryRow";
		customerCountryRow.Weight = 1.0;
		customerCountry.CanShrink = true;
		customerCountry.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Address]")
		});
		customerCountry.Multiline = true;
		customerCountry.Name = "customerCountry";
		customerCountry.Text = "CustomerCountry";
		customerCountry.Weight = 1.191547728468558;
		SubBand1.Controls.AddRange(new XRControl[3] { xrLabel2, xrLabel1, headerTable });
		SubBand1.HeightF = 95.00002f;
		SubBand1.KeepTogether = true;
		SubBand1.Name = "SubBand1";
		xrLabel2.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		xrLabel2.LocationFloat = new PointFloat(0f, 0f);
		xrLabel2.Multiline = true;
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(37.08334f, 23f);
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.Text = "Ref:";
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[NarrationBig]")
		});
		xrLabel1.Font = new DXFont("Segoe UI", 12f);
		xrLabel1.LocationFloat = new PointFloat(37.08334f, 0f);
		xrLabel1.Multiline = true;
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(632.6018f, 60.00002f);
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.Text = "xrLabel1";
		headerTable.AnchorHorizontal = HorizontalAnchorStyles.Right;
		headerTable.BorderColor = Color.FromArgb(121, 121, 121);
		headerTable.Borders = BorderSide.Bottom;
		headerTable.BorderWidth = 3f;
		headerTable.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		headerTable.LocationFloat = new PointFloat(0f, 60.00001f);
		headerTable.Name = "headerTable";
		headerTable.Padding = new PaddingInfo(0, 0, 5, 0, 100f);
		headerTable.Rows.AddRange(new XRTableRow[1] { headerTableRow });
		headerTable.SizeF = new SizeF(669.6851f, 35.00002f);
		headerTable.StylePriority.UseBorderColor = false;
		headerTable.StylePriority.UseBorders = false;
		headerTable.StylePriority.UseBorderWidth = false;
		headerTable.StylePriority.UseFont = false;
		headerTable.StylePriority.UsePadding = false;
		headerTableRow.Cells.AddRange(new XRTableCell[2] { productNameCaption, lineTotalCaption });
		headerTableRow.Name = "headerTableRow";
		headerTableRow.Weight = 11.5;
		productNameCaption.Name = "productNameCaption";
		productNameCaption.Padding = new PaddingInfo(10, 0, 5, 0, 100f);
		productNameCaption.StylePriority.UsePadding = false;
		productNameCaption.Text = "Particulars";
		productNameCaption.Weight = 1.4003968501938324;
		lineTotalCaption.Name = "lineTotalCaption";
		lineTotalCaption.StylePriority.UseTextAlignment = false;
		lineTotalCaption.Text = "Amount";
		lineTotalCaption.TextAlignment = TextAlignment.TopRight;
		lineTotalCaption.Weight = 0.6814456926576941;
		footerTotals.Controls.AddRange(new XRControl[1] { totalTable });
		footerTotals.GroupUnion = GroupFooterUnion.WithLastDetail;
		footerTotals.HeightF = 49.29168f;
		footerTotals.KeepTogether = true;
		footerTotals.Name = "footerTotals";
		footerTotals.PageBreak = PageBreak.AfterBandExceptLastEntry;
		footerTotals.StyleName = "baseControlStyle";
		footerTotals.SubBands.AddRange(new SubBand[1] { SubBand2 });
		totalTable.AnchorHorizontal = HorizontalAnchorStyles.Right;
		totalTable.BorderColor = Color.FromArgb(198, 198, 198);
		totalTable.Borders = BorderSide.All;
		totalTable.Font = new DXFont("Segoe UI", 9.75f, DXFontStyle.Bold);
		totalTable.ForeColor = Color.Black;
		totalTable.LocationFloat = new PointFloat(0f, 0f);
		totalTable.Name = "totalTable";
		totalTable.Padding = new PaddingInfo(2, 2, 5, 0, 100f);
		totalTable.Rows.AddRange(new XRTableRow[1] { totalRow });
		totalTable.SizeF = new SizeF(669.6851f, 35f);
		totalTable.StylePriority.UseBorderColor = false;
		totalTable.StylePriority.UseBorders = false;
		totalTable.StylePriority.UseFont = false;
		totalTable.StylePriority.UseForeColor = false;
		totalTable.StylePriority.UsePadding = false;
		totalRow.BorderColor = Color.FromArgb(121, 121, 121);
		totalRow.BorderWidth = 3f;
		totalRow.Cells.AddRange(new XRTableCell[2] { totalCaption, lblTotal });
		totalRow.Font = new DXFont("Segoe UI", 14.25f, DXFontStyle.Bold);
		totalRow.Name = "totalRow";
		totalRow.StylePriority.UseBorderColor = false;
		totalRow.StylePriority.UseBorderWidth = false;
		totalRow.StylePriority.UseFont = false;
		totalRow.Weight = 1.5217391304347823;
		totalCaption.Name = "totalCaption";
		totalCaption.StylePriority.UseFont = false;
		totalCaption.StylePriority.UseTextAlignment = false;
		totalCaption.Text = "Total";
		totalCaption.TextAlignment = TextAlignment.BottomLeft;
		totalCaption.Weight = 6.200501765810458;
		lblTotal.CanGrow = false;
		lblTotal.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "sum([ExpenseValue])")
		});
		lblTotal.Name = "lblTotal";
		lblTotal.StylePriority.UseFont = false;
		lblTotal.StylePriority.UseTextAlignment = false;
		xRSummary.Running = SummaryRunning.Report;
		lblTotal.Summary = xRSummary;
		lblTotal.Text = "0.00";
		lblTotal.TextAlignment = TextAlignment.MiddleRight;
		lblTotal.TextFormatString = "{0:#,#}";
		lblTotal.Weight = 2.660321823400148;
		lblTotal.WordWrap = false;
		SubBand2.Controls.AddRange(new XRControl[2] { lblAmountInWords, xrLabel15 });
		SubBand2.HeightF = 42.83333f;
		SubBand2.Name = "SubBand2";
		lblAmountInWords.AutoWidth = true;
		lblAmountInWords.Font = new DXFont("Cascadia Code", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblAmountInWords.LocationFloat = new PointFloat(150f, 0f);
		lblAmountInWords.Multiline = true;
		lblAmountInWords.Name = "lblAmountInWords";
		lblAmountInWords.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblAmountInWords.SizeF = new SizeF(512.5f, 23f);
		lblAmountInWords.StylePriority.UseFont = false;
		lblAmountInWords.StylePriority.UseTextAlignment = false;
		lblAmountInWords.Text = "lblAmountInWords";
		lblAmountInWords.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel15.Font = new DXFont("Segoe UI", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel15.LocationFloat = new PointFloat(0f, 0f);
		xrLabel15.Multiline = true;
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(150f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Amount in words";
		xrLabel15.TextAlignment = TextAlignment.MiddleLeft;
		baseControlStyle.Font = new DXFont("Segoe UI", 9.75f);
		baseControlStyle.Name = "baseControlStyle";
		baseControlStyle.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		paymentVoucher1.DataSetName = "PaymentVoucher";
		paymentVoucher1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		paymentVoucherTableAdapter.ClearBeforeFill = true;
		footerAuthorities.Controls.AddRange(new XRControl[16]
		{
			xrLabel18, xrLabel19, xrLabel20, xrLabel21, xrLabel14, xrLabel13, xrLabel12, xrLabel11, xrLabel10, xrLabel9,
			xrLabel8, xrLabel7, xrLabel6, xrLabel5, xrLabel4, xrLabel3
		});
		footerAuthorities.HeightF = 200f;
		footerAuthorities.Level = 2;
		footerAuthorities.Name = "footerAuthorities";
		xrLabel18.Font = new DXFont("Arial", 12f);
		xrLabel18.LocationFloat = new PointFloat(10.00001f, 162.5f);
		xrLabel18.Multiline = true;
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(115f, 23f);
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.Text = "Received By:";
		xrLabel18.TextAlignment = TextAlignment.BottomLeft;
		xrLabel19.Font = new DXFont("Arial", 12f);
		xrLabel19.LocationFloat = new PointFloat(487.5049f, 162.5f);
		xrLabel19.Multiline = true;
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(52.08334f, 23f);
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "Date";
		xrLabel19.TextAlignment = TextAlignment.BottomLeft;
		xrLabel20.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel20.Borders = BorderSide.Bottom;
		xrLabel20.LocationFloat = new PointFloat(550f, 162.5f);
		xrLabel20.Multiline = true;
		xrLabel20.Name = "xrLabel20";
		xrLabel20.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel20.SizeF = new SizeF(100f, 23f);
		xrLabel20.StylePriority.UseBorderDashStyle = false;
		xrLabel20.StylePriority.UseBorders = false;
		xrLabel21.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel21.Borders = BorderSide.Bottom;
		xrLabel21.LocationFloat = new PointFloat(125f, 162.5f);
		xrLabel21.Multiline = true;
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(362.5f, 23f);
		xrLabel21.StylePriority.UseBorderDashStyle = false;
		xrLabel21.StylePriority.UseBorders = false;
		xrLabel14.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel14.Borders = BorderSide.Bottom;
		xrLabel14.LocationFloat = new PointFloat(125f, 112.5f);
		xrLabel14.Multiline = true;
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(362.5f, 23f);
		xrLabel14.StylePriority.UseBorderDashStyle = false;
		xrLabel14.StylePriority.UseBorders = false;
		xrLabel13.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel13.Borders = BorderSide.Bottom;
		xrLabel13.LocationFloat = new PointFloat(125f, 62.5f);
		xrLabel13.Multiline = true;
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(362.5f, 23f);
		xrLabel13.StylePriority.UseBorderDashStyle = false;
		xrLabel13.StylePriority.UseBorders = false;
		xrLabel12.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel12.Borders = BorderSide.Bottom;
		xrLabel12.LocationFloat = new PointFloat(549.9951f, 12.5f);
		xrLabel12.Multiline = true;
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(100f, 23f);
		xrLabel12.StylePriority.UseBorderDashStyle = false;
		xrLabel12.StylePriority.UseBorders = false;
		xrLabel11.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel11.Borders = BorderSide.Bottom;
		xrLabel11.LocationFloat = new PointFloat(549.9951f, 66.50009f);
		xrLabel11.Multiline = true;
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(100f, 23f);
		xrLabel11.StylePriority.UseBorderDashStyle = false;
		xrLabel11.StylePriority.UseBorders = false;
		xrLabel10.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel10.Borders = BorderSide.Bottom;
		xrLabel10.LocationFloat = new PointFloat(549.9951f, 112.5f);
		xrLabel10.Multiline = true;
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(100f, 23f);
		xrLabel10.StylePriority.UseBorderDashStyle = false;
		xrLabel10.StylePriority.UseBorders = false;
		xrLabel9.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel9.Borders = BorderSide.Bottom;
		xrLabel9.LocationFloat = new PointFloat(125f, 12.5f);
		xrLabel9.Multiline = true;
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(362.5f, 23f);
		xrLabel9.StylePriority.UseBorderDashStyle = false;
		xrLabel9.StylePriority.UseBorders = false;
		xrLabel8.Font = new DXFont("Arial", 12f);
		xrLabel8.LocationFloat = new PointFloat(487.5f, 112.5f);
		xrLabel8.Multiline = true;
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(52.08334f, 23f);
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "Date";
		xrLabel8.TextAlignment = TextAlignment.BottomLeft;
		xrLabel7.Font = new DXFont("Arial", 12f);
		xrLabel7.LocationFloat = new PointFloat(487.5f, 62.5f);
		xrLabel7.Multiline = true;
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(52.08334f, 23f);
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "Date";
		xrLabel7.TextAlignment = TextAlignment.BottomLeft;
		xrLabel6.Font = new DXFont("Arial", 12f);
		xrLabel6.LocationFloat = new PointFloat(487.5f, 12.5f);
		xrLabel6.Multiline = true;
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(52.08334f, 23f);
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Date";
		xrLabel6.TextAlignment = TextAlignment.BottomLeft;
		xrLabel5.Font = new DXFont("Arial", 12f);
		xrLabel5.LocationFloat = new PointFloat(10.00001f, 112.5f);
		xrLabel5.Multiline = true;
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(115f, 23f);
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Authorised By:";
		xrLabel5.TextAlignment = TextAlignment.BottomLeft;
		xrLabel4.Font = new DXFont("Arial", 12f);
		xrLabel4.LocationFloat = new PointFloat(10.00001f, 62.5f);
		xrLabel4.Multiline = true;
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(115f, 23f);
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Approved By";
		xrLabel4.TextAlignment = TextAlignment.BottomLeft;
		xrLabel3.Font = new DXFont("Arial", 12f);
		xrLabel3.LocationFloat = new PointFloat(10.00001f, 12.50006f);
		xrLabel3.Multiline = true;
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(115f, 23f);
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "Prepared By:";
		xrLabel3.TextAlignment = TextAlignment.BottomLeft;
		footerPaymentMode.Controls.AddRange(new XRControl[2] { xrLabel16, xrLabel17 });
		footerPaymentMode.HeightF = 170.6668f;
		footerPaymentMode.Level = 1;
		footerPaymentMode.Name = "footerPaymentMode";
		xrLabel16.Font = new DXFont("Segoe UI", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel16.LocationFloat = new PointFloat(0f, 0f);
		xrLabel16.Multiline = true;
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(150f, 23f);
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.Text = "Payment Mode";
		xrLabel17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PaymentMode]")
		});
		xrLabel17.Font = new DXFont("Cascadia Code", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel17.LocationFloat = new PointFloat(150f, 0f);
		xrLabel17.Multiline = true;
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(512.5f, 23f);
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "lblAmountInWords";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		calculatedField1.DataMember = "PaymentVoucher";
		calculatedField1.Expression = "SUM([ExpenseValue])";
		calculatedField1.Name = "calculatedField1";
		voucherNo.Description = "VoucherNo";
		voucherNo.Name = "voucherNo";
		voucherNo.Visible = false;
		base.Bands.AddRange(new Band[7] { Detail, TopMargin, BottomMargin, GroupHeader1, footerTotals, footerAuthorities, footerPaymentMode });
		base.CalculatedFields.AddRange(new CalculatedField[1] { calculatedField1 });
		base.ComponentStorage.AddRange(new IComponent[1] { paymentVoucher1 });
		base.DataAdapter = paymentVoucherTableAdapter;
		base.DataMember = "PaymentVoucher";
		base.DataSource = paymentVoucher1;
		FilterString = "[VoucherNo] = ?voucherNo";
		Font = new DXFont("Arial", 9.75f);
		base.Margins = new DXMargins(90f, 90f, 25f, 30f);
		base.ParameterPanelLayoutItems.AddRange(new ParameterPanelLayoutItem[1]
		{
			new ParameterLayoutItem(voucherNo)
		});
		base.Parameters.AddRange(new Parameter[1] { voucherNo });
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[1] { baseControlStyle });
		base.Version = "23.2";
		BeforePrint += PaymentVoucherRpt_BeforePrint;
		((ISupportInitialize)detailTable).EndInit();
		((ISupportInitialize)invoiceNumberTable).EndInit();
		((ISupportInitialize)vendorTable).EndInit();
		((ISupportInitialize)customerTable).EndInit();
		((ISupportInitialize)headerTable).EndInit();
		((ISupportInitialize)totalTable).EndInit();
		((ISupportInitialize)paymentVoucher1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
