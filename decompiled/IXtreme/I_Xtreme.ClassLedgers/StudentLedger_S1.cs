using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using I_Xtreme.DataSets_Ledgers;
using I_Xtreme.DataSets_Ledgers.ClassLedgerTableAdapters;

namespace I_Xtreme.ClassLedgers;

public class StudentLedger_S1 : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRControlStyle Title;

	private XRControlStyle FieldCaption;

	private XRControlStyle PageInfo;

	private XRControlStyle DataField;

	private PageFooterBand pageFooterBand1;

	private XRPageInfo xrPageInfo1;

	private XRPageInfo xrPageInfo2;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel3;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLabel xrLabel9;

	private XRLabel xrLabel8;

	private XRLabel xrLabel26;

	private XRLabel xrLabel25;

	private XRLabel xrLabel24;

	private XRLabel xrLabel23;

	private XRLabel xrLabel22;

	private XRLabel xrLabel21;

	private XRLine xrLine2;

	private XRLine xrLine1;

	private XRLabel xrLabel30;

	private GroupHeaderBand GroupHeader1;

	private XRLabel xrLabel27;

	private XRLabel xrLabel28;

	private XRLabel xrLabel11;

	private XRLabel xrLabel7;

	private XRLabel lblSchoolAddress;

	private XRLabel lblSchoolName;

	private XRLabel xrLabel13;

	private XRLabel xrLabel12;

	private ClassLedger classLedger1;

	private DTClassTablesTableAdapter dTClassTablesTableAdapter;

	private XRLabel xrLabel10;

	public StudentLedger_S1()
	{
		InitializeComponent();
	}

	private void StudentLedger_S1_BeforePrint(object sender, CancelEventArgs e)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		string empty = string.Empty;
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SchoolName,fullContact,location FROM SchoolDetails", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "header");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					text = FingerPrint.SchoolName;
					text2 = row["fullContact"].ToString();
					empty = FingerPrint.Village;
				}
				lblSchoolName.Text = text;
				lblSchoolAddress.Text = text2;
			}
			xrLabel10.Text = $"{StudentOptions.ActiveClass()} - Student's Ledger";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
		xrLabel27 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel3 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		Title = new XRControlStyle();
		FieldCaption = new XRControlStyle();
		PageInfo = new XRControlStyle();
		DataField = new XRControlStyle();
		xrLabel11 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel28 = new XRLabel();
		xrLabel30 = new XRLabel();
		xrLine2 = new XRLine();
		xrLine1 = new XRLine();
		xrLabel26 = new XRLabel();
		xrLabel25 = new XRLabel();
		xrLabel24 = new XRLabel();
		xrLabel23 = new XRLabel();
		xrLabel22 = new XRLabel();
		xrLabel21 = new XRLabel();
		xrLabel9 = new XRLabel();
		xrLabel8 = new XRLabel();
		pageFooterBand1 = new PageFooterBand();
		xrLabel10 = new XRLabel();
		xrPageInfo1 = new XRPageInfo();
		xrPageInfo2 = new XRPageInfo();
		topMarginBand1 = new TopMarginBand();
		lblSchoolAddress = new XRLabel();
		lblSchoolName = new XRLabel();
		bottomMarginBand1 = new BottomMarginBand();
		GroupHeader1 = new GroupHeaderBand();
		xrLabel13 = new XRLabel();
		xrLabel12 = new XRLabel();
		classLedger1 = new ClassLedger();
		dTClassTablesTableAdapter = new DTClassTablesTableAdapter();
		((ISupportInitialize)classLedger1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[7] { xrLabel27, xrLabel6, xrLabel5, xrLabel4, xrLabel3, xrLabel2, xrLabel1 });
		Detail.HeightF = 23f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.StyleName = "DataField";
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrLabel27.BackColor = Color.Transparent;
		xrLabel27.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[BankSlipNo]")
		});
		xrLabel27.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel27.LocationFloat = new PointFloat(87.41662f, 0f);
		xrLabel27.Name = "xrLabel27";
		xrLabel27.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel27.SizeF = new SizeF(74.58338f, 22.99999f);
		xrLabel27.StylePriority.UseBackColor = false;
		xrLabel27.StylePriority.UseFont = false;
		xrLabel27.StylePriority.UseTextAlignment = false;
		xrLabel27.Text = "xrLabel27";
		xrLabel27.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.BackColor = Color.Transparent;
		xrLabel6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[SemesterId]")
		});
		xrLabel6.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.LocationFloat = new PointFloat(162f, 0f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(86.47f, 23f);
		xrLabel6.StylePriority.UseBackColor = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "xrLabel6";
		xrLabel6.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel5.BackColor = Color.Transparent;
		xrLabel5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[DateOfPayment]")
		});
		xrLabel5.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel5.LocationFloat = new PointFloat(0f, 0f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(86.78f, 23f);
		xrLabel5.StylePriority.UseBackColor = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "xrLabel5";
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel5.TextFormatString = "{0:dd-MMM-yy}";
		xrLabel4.BackColor = Color.Transparent;
		xrLabel4.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Particulars]")
		});
		xrLabel4.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel4.LocationFloat = new PointFloat(248.475f, 0f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(118.525f, 23f);
		xrLabel4.StylePriority.UseBackColor = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "xrLabel4";
		xrLabel4.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel3.BackColor = Color.Transparent;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Balance]")
		});
		xrLabel3.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel3.LocationFloat = new PointFloat(567f, 0f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(100f, 23f);
		xrLabel3.StylePriority.UseBackColor = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "xrLabel3";
		xrLabel3.TextAlignment = TextAlignment.MiddleRight;
		xrLabel3.TextFormatString = "{0:#,#.0}";
		xrLabel2.BackColor = Color.Transparent;
		xrLabel2.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Credit]")
		});
		xrLabel2.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel2.LocationFloat = new PointFloat(467f, 0f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(100f, 23f);
		xrLabel2.StylePriority.UseBackColor = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "xrLabel2";
		xrLabel2.TextAlignment = TextAlignment.MiddleRight;
		xrLabel2.TextFormatString = "{0:#,#.0}";
		xrLabel1.BackColor = Color.Transparent;
		xrLabel1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Debit]")
		});
		xrLabel1.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel1.LocationFloat = new PointFloat(367f, 0f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(100f, 23f);
		xrLabel1.StylePriority.UseBackColor = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "xrLabel1";
		xrLabel1.TextAlignment = TextAlignment.MiddleRight;
		xrLabel1.TextFormatString = "{0:#,#.0}";
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
		xrLabel11.Borders = BorderSide.Bottom;
		xrLabel11.Font = new DXFont("Tahoma", 11f);
		xrLabel11.LocationFloat = new PointFloat(0f, 0f);
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(262f, 24f);
		xrLabel11.StylePriority.UseBorders = false;
		xrLabel11.StylePriority.UseFont = false;
		xrLabel11.StylePriority.UseTextAlignment = false;
		xrLabel11.TextAlignment = TextAlignment.BottomCenter;
		xrLabel7.Borders = BorderSide.Bottom;
		xrLabel7.Font = new DXFont("Tahoma", 11f);
		xrLabel7.LocationFloat = new PointFloat(405.9999f, 0f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(261f, 24f);
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.TextAlignment = TextAlignment.BottomCenter;
		xrLabel28.Font = new DXFont("Tahoma", 9f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel28.LocationFloat = new PointFloat(87.41655f, 98f);
		xrLabel28.Name = "xrLabel28";
		xrLabel28.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel28.SizeF = new SizeF(74.58338f, 22.99999f);
		xrLabel28.StylePriority.UseFont = false;
		xrLabel28.StylePriority.UseTextAlignment = false;
		xrLabel28.Text = "TRef";
		xrLabel28.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel30.Font = new DXFont("Tahoma", 11f);
		xrLabel30.LocationFloat = new PointFloat(262f, 0f);
		xrLabel30.Name = "xrLabel30";
		xrLabel30.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel30.SizeF = new SizeF(143f, 24.00001f);
		xrLabel30.StylePriority.UseFont = false;
		xrLabel30.StylePriority.UseTextAlignment = false;
		xrLabel30.Text = "STUDENT'S LEDGER";
		xrLabel30.TextAlignment = TextAlignment.BottomCenter;
		xrLine2.LocationFloat = new PointFloat(0f, 96f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(667f, 2f);
		xrLine1.LocationFloat = new PointFloat(0f, 122f);
		xrLine1.Name = "xrLine1";
		xrLine1.SizeF = new SizeF(667f, 2f);
		xrLabel26.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel26.LocationFloat = new PointFloat(566.9999f, 98f);
		xrLabel26.Name = "xrLabel26";
		xrLabel26.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel26.SizeF = new SizeF(100f, 22.99999f);
		xrLabel26.StylePriority.UseFont = false;
		xrLabel26.StylePriority.UseTextAlignment = false;
		xrLabel26.Text = "Bal";
		xrLabel26.TextAlignment = TextAlignment.MiddleRight;
		xrLabel25.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel25.LocationFloat = new PointFloat(466.9999f, 98f);
		xrLabel25.Name = "xrLabel25";
		xrLabel25.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel25.SizeF = new SizeF(100f, 23f);
		xrLabel25.StylePriority.UseFont = false;
		xrLabel25.StylePriority.UseTextAlignment = false;
		xrLabel25.Text = "Cr";
		xrLabel25.TextAlignment = TextAlignment.MiddleRight;
		xrLabel24.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel24.LocationFloat = new PointFloat(366.9999f, 98f);
		xrLabel24.Name = "xrLabel24";
		xrLabel24.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel24.SizeF = new SizeF(100f, 23f);
		xrLabel24.StylePriority.UseFont = false;
		xrLabel24.StylePriority.UseTextAlignment = false;
		xrLabel24.Text = "Dr";
		xrLabel24.TextAlignment = TextAlignment.MiddleRight;
		xrLabel23.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel23.LocationFloat = new PointFloat(248.4685f, 98f);
		xrLabel23.Name = "xrLabel23";
		xrLabel23.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel23.SizeF = new SizeF(118.5314f, 22.99999f);
		xrLabel23.StylePriority.UseFont = false;
		xrLabel23.StylePriority.UseTextAlignment = false;
		xrLabel23.Text = "Particulars";
		xrLabel23.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel22.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel22.LocationFloat = new PointFloat(0f, 98f);
		xrLabel22.Name = "xrLabel22";
		xrLabel22.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel22.SizeF = new SizeF(86.78156f, 22.99999f);
		xrLabel22.StylePriority.UseFont = false;
		xrLabel22.StylePriority.UseTextAlignment = false;
		xrLabel22.Text = "Date";
		xrLabel22.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel21.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel21.LocationFloat = new PointFloat(162f, 98f);
		xrLabel21.Name = "xrLabel21";
		xrLabel21.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel21.SizeF = new SizeF(86.46852f, 22.99999f);
		xrLabel21.StylePriority.UseFont = false;
		xrLabel21.StylePriority.UseTextAlignment = false;
		xrLabel21.Text = "Term";
		xrLabel21.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel9.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel9.Borders = BorderSide.None;
		xrLabel9.CanGrow = false;
		xrLabel9.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel9.Font = new DXFont("Tahoma", 9.75f);
		xrLabel9.LocationFloat = new PointFloat(92.00001f, 39.99999f);
		xrLabel9.Name = "xrLabel9";
		xrLabel9.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel9.SizeF = new SizeF(506f, 22.99999f);
		xrLabel9.StylePriority.UseBorderDashStyle = false;
		xrLabel9.StylePriority.UseBorders = false;
		xrLabel9.StylePriority.UseFont = false;
		xrLabel9.StylePriority.UseTextAlignment = false;
		xrLabel9.Text = "xrLabel9";
		xrLabel9.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel9.WordWrap = false;
		xrLabel8.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel8.Borders = BorderSide.None;
		xrLabel8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentID]")
		});
		xrLabel8.Font = new DXFont("Tahoma", 9.75f);
		xrLabel8.LocationFloat = new PointFloat(92.00001f, 64f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(506f, 22.99998f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "xrLabel8";
		xrLabel8.TextAlignment = TextAlignment.MiddleLeft;
		pageFooterBand1.Controls.AddRange(new XRControl[3] { xrLabel10, xrPageInfo1, xrPageInfo2 });
		pageFooterBand1.HeightF = 26.00001f;
		pageFooterBand1.Name = "pageFooterBand1";
		xrLabel10.CanGrow = false;
		xrLabel10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel10.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrLabel10.LocationFloat = new PointFloat(2.000046f, 0f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(381.9999f, 24f);
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.Text = "xrLabel10";
		xrLabel10.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel10.WordWrap = false;
		xrPageInfo1.BackColor = Color.Transparent;
		xrPageInfo1.Font = new DXFont("Tahoma", 10f);
		xrPageInfo1.LocationFloat = new PointFloat(390f, 0f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
		xrPageInfo1.SizeF = new SizeF(194f, 22.99999f);
		xrPageInfo1.StyleName = "PageInfo";
		xrPageInfo1.StylePriority.UseBackColor = false;
		xrPageInfo1.StylePriority.UseFont = false;
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleRight;
		xrPageInfo2.BackColor = Color.Transparent;
		xrPageInfo2.Font = new DXFont("Tahoma", 10f);
		xrPageInfo2.LocationFloat = new PointFloat(584f, 0f);
		xrPageInfo2.Name = "xrPageInfo2";
		xrPageInfo2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo2.SizeF = new SizeF(81.99994f, 22.99999f);
		xrPageInfo2.StyleName = "PageInfo";
		xrPageInfo2.StylePriority.UseBackColor = false;
		xrPageInfo2.StylePriority.UseFont = false;
		xrPageInfo2.TextAlignment = TextAlignment.TopRight;
		xrPageInfo2.TextFormatString = "{0} of {1}";
		topMarginBand1.Controls.AddRange(new XRControl[2] { lblSchoolAddress, lblSchoolName });
		topMarginBand1.HeightF = 66f;
		topMarginBand1.Name = "topMarginBand1";
		lblSchoolAddress.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblSchoolAddress.LocationFloat = new PointFloat(2.00002f, 37.31035f);
		lblSchoolAddress.Name = "lblSchoolAddress";
		lblSchoolAddress.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolAddress.SizeF = new SizeF(664f, 23f);
		lblSchoolAddress.StylePriority.UseFont = false;
		lblSchoolAddress.StylePriority.UseTextAlignment = false;
		lblSchoolAddress.TextAlignment = TextAlignment.MiddleCenter;
		lblSchoolName.Font = new DXFont("Tahoma", 12f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblSchoolName.LocationFloat = new PointFloat(2.00002f, 9.999999f);
		lblSchoolName.Name = "lblSchoolName";
		lblSchoolName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblSchoolName.SizeF = new SizeF(664f, 27.31035f);
		lblSchoolName.StylePriority.UseFont = false;
		lblSchoolName.StylePriority.UseTextAlignment = false;
		lblSchoolName.TextAlignment = TextAlignment.MiddleCenter;
		bottomMarginBand1.HeightF = 30f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		GroupHeader1.Controls.AddRange(new XRControl[16]
		{
			xrLabel13, xrLabel12, xrLabel7, xrLabel9, xrLabel21, xrLabel22, xrLabel23, xrLabel24, xrLabel25, xrLabel26,
			xrLine1, xrLine2, xrLabel30, xrLabel28, xrLabel8, xrLabel11
		});
		GroupHeader1.GroupFields.AddRange(new GroupField[1]
		{
			new GroupField("auto", XRColumnSortOrder.Ascending)
		});
		GroupHeader1.HeightF = 124f;
		GroupHeader1.KeepTogether = true;
		GroupHeader1.Name = "GroupHeader1";
		GroupHeader1.PageBreak = PageBreak.BeforeBand;
		xrLabel13.Font = new DXFont("Tahoma", 9.75f);
		xrLabel13.LocationFloat = new PointFloat(4f, 64f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(87.99998f, 22.99999f);
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "StudentNo:";
		xrLabel13.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel12.Font = new DXFont("Tahoma", 9.75f);
		xrLabel12.LocationFloat = new PointFloat(4f, 40f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(87.99998f, 22.99999f);
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Name:";
		xrLabel12.TextAlignment = TextAlignment.MiddleLeft;
		classLedger1.DataSetName = "ClassLedger";
		classLedger1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		dTClassTablesTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[5] { Detail, pageFooterBand1, topMarginBand1, bottomMarginBand1, GroupHeader1 });
		base.ComponentStorage.AddRange(new IComponent[1] { classLedger1 });
		base.DataAdapter = dTClassTablesTableAdapter;
		base.DataMember = "DTClassTables";
		base.DataSource = classLedger1;
		base.Margins = new DXMargins(80f, 80f, 66f, 30f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.ShowPreviewMarginLines = false;
		base.ShowPrintMarginsWarning = false;
		base.SnapGridSize = 2f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.StyleSheet.AddRange(new XRControlStyle[4] { Title, FieldCaption, PageInfo, DataField });
		base.Version = "22.2";
		BeforePrint += StudentLedger_S1_BeforePrint;
		((ISupportInitialize)classLedger1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
