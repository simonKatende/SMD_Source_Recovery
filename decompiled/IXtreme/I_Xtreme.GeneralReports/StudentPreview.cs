using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using I_Xtreme.DataSet_Previews;
using I_Xtreme.DataSet_Previews.StudentPreviewSourceTableAdapters;

namespace I_Xtreme.GeneralReports;

public class StudentPreview : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRPictureBox xrPictureBox1;

	private XRLabel xrLabel17;

	private XRLabel xrLabel18;

	private XRLabel xrLabel15;

	private XRLabel xrLabel16;

	private XRLabel xrLabel13;

	private XRLabel lblClass;

	private XRLabel xrLabel6;

	private XRLabel xrLabel5;

	private XRLabel lblContacts;

	private XRLabel lblAddress;

	private XRLabel lblName;

	private XRBarCode xrBarCode1;

	private XRLine xrLine2;

	private XRLabel xrLabel12;

	private PageFooterBand PageFooter;

	private XRLabel xrLabel19;

	private XRLine xrLine3;

	private XRPageInfo xrPageInfo1;

	public Parameter StudentNo;

	private XRLabel xrLabel14;

	private XRTable xrTable1;

	private XRTableRow xrTableRow1;

	private XRTableCell xrTableCell1;

	private XRTableCell xrTableCell2;

	private XRTableCell xrTableCell4;

	private XRTableCell xrTableCell3;

	private XRTableRow xrTableRow2;

	private XRTableCell xrTableCell5;

	private XRTableCell xrTableCell6;

	private XRTableCell xrTableCell7;

	private XRTableCell xrTableCell8;

	private XRTableRow xrTableRow3;

	private XRTableCell xrTableCell9;

	private XRTableCell xrTableCell10;

	private XRTableCell xrTableCell11;

	private XRTableCell xrTableCell12;

	private XRTableRow xrTableRow4;

	private XRTableCell xrTableCell13;

	private XRTableCell xrTableCell14;

	private XRTableCell xrTableCell15;

	private XRTableCell xrTableCell16;

	private XRTableRow xrTableRow5;

	private XRTableCell xrTableCell17;

	private XRTableCell xrTableCell18;

	private XRTableCell xrTableCell19;

	private XRTableCell xrTableCell20;

	private GroupHeaderBand GroupHeader1;

	private StudentPreviewSource studentPreviewSource1;

	private StudentPreviewSourceTableAdapter studentPreviewSourceTableAdapter;

	public StudentPreview()
	{
		InitializeComponent();
	}

	private void StudentPreview_BeforePrint(object sender, CancelEventArgs e)
	{
		lblClass.Text = StudentOptions.ActiveClass();
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SchoolName,fullContact,location FROM SchoolDetails", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "header");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				lblName.Text = AlienAge.Security.CryptorEngine.Decrypt(row["SchoolName"].ToString());
				lblContacts.Text = row["fullContact"].ToString();
				lblAddress.Text = AlienAge.Security.CryptorEngine.Decrypt(row["location"].ToString());
			}
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
		EAN13Generator symbology = new EAN13Generator();
		Detail = new DetailBand();
		xrTable1 = new XRTable();
		xrTableRow1 = new XRTableRow();
		xrTableCell1 = new XRTableCell();
		xrTableCell2 = new XRTableCell();
		xrTableCell4 = new XRTableCell();
		xrTableCell3 = new XRTableCell();
		xrTableRow2 = new XRTableRow();
		xrTableCell5 = new XRTableCell();
		xrTableCell6 = new XRTableCell();
		xrTableCell7 = new XRTableCell();
		xrTableCell8 = new XRTableCell();
		xrTableRow3 = new XRTableRow();
		xrTableCell9 = new XRTableCell();
		xrTableCell10 = new XRTableCell();
		xrTableCell11 = new XRTableCell();
		xrTableCell12 = new XRTableCell();
		xrTableRow4 = new XRTableRow();
		xrTableCell13 = new XRTableCell();
		xrTableCell14 = new XRTableCell();
		xrTableCell15 = new XRTableCell();
		xrTableCell16 = new XRTableCell();
		xrTableRow5 = new XRTableRow();
		xrTableCell17 = new XRTableCell();
		xrTableCell18 = new XRTableCell();
		xrTableCell19 = new XRTableCell();
		xrTableCell20 = new XRTableCell();
		xrLabel17 = new XRLabel();
		xrLabel18 = new XRLabel();
		xrLabel15 = new XRLabel();
		xrLabel16 = new XRLabel();
		xrLabel13 = new XRLabel();
		lblClass = new XRLabel();
		xrLabel6 = new XRLabel();
		xrLabel5 = new XRLabel();
		TopMargin = new TopMarginBand();
		xrLabel14 = new XRLabel();
		lblContacts = new XRLabel();
		lblAddress = new XRLabel();
		lblName = new XRLabel();
		xrBarCode1 = new XRBarCode();
		xrPictureBox1 = new XRPictureBox();
		xrLine2 = new XRLine();
		xrLabel12 = new XRLabel();
		BottomMargin = new BottomMarginBand();
		PageFooter = new PageFooterBand();
		xrLabel19 = new XRLabel();
		xrLine3 = new XRLine();
		xrPageInfo1 = new XRPageInfo();
		StudentNo = new Parameter();
		GroupHeader1 = new GroupHeaderBand();
		studentPreviewSource1 = new StudentPreviewSource();
		studentPreviewSourceTableAdapter = new StudentPreviewSourceTableAdapter();
		((ISupportInitialize)xrTable1).BeginInit();
		((ISupportInitialize)studentPreviewSource1).BeginInit();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[1] { xrTable1 });
		Detail.HeightF = 131.6667f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrTable1.BorderColor = Color.DarkGray;
		xrTable1.Borders = BorderSide.All;
		xrTable1.Font = new DXFont("Tahoma", 10f);
		xrTable1.LocationFloat = new PointFloat(2.000014f, 0f);
		xrTable1.Name = "xrTable1";
		xrTable1.Padding = new PaddingInfo(2, 0, 0, 0, 100f);
		xrTable1.Rows.AddRange(new XRTableRow[5] { xrTableRow1, xrTableRow2, xrTableRow3, xrTableRow4, xrTableRow5 });
		xrTable1.SizeF = new SizeF(774.9999f, 125f);
		xrTable1.StylePriority.UseBorderColor = false;
		xrTable1.StylePriority.UseBorders = false;
		xrTable1.StylePriority.UseFont = false;
		xrTable1.StylePriority.UsePadding = false;
		xrTable1.StylePriority.UseTextAlignment = false;
		xrTable1.TextAlignment = TextAlignment.MiddleLeft;
		xrTableRow1.Cells.AddRange(new XRTableCell[4] { xrTableCell1, xrTableCell2, xrTableCell4, xrTableCell3 });
		xrTableRow1.Name = "xrTableRow1";
		xrTableRow1.Weight = 1.0;
		xrTableCell1.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell1.Name = "xrTableCell1";
		xrTableCell1.StylePriority.UseFont = false;
		xrTableCell1.Text = "Details";
		xrTableCell1.Weight = 0.29411768049792564;
		xrTableCell2.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell2.Name = "xrTableCell2";
		xrTableCell2.StylePriority.UseFont = false;
		xrTableCell2.Text = "Mother";
		xrTableCell2.Weight = 0.9991829366593056;
		xrTableCell4.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell4.Name = "xrTableCell4";
		xrTableCell4.StylePriority.UseFont = false;
		xrTableCell4.Text = "Father";
		xrTableCell4.Weight = 0.9983660328876598;
		xrTableCell3.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell3.Name = "xrTableCell3";
		xrTableCell3.StylePriority.UseFont = false;
		xrTableCell3.Text = "Guardian";
		xrTableCell3.Weight = 0.7083333499551092;
		xrTableRow2.Cells.AddRange(new XRTableCell[4] { xrTableCell5, xrTableCell6, xrTableCell7, xrTableCell8 });
		xrTableRow2.Name = "xrTableRow2";
		xrTableRow2.Weight = 1.0;
		xrTableCell5.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell5.Name = "xrTableCell5";
		xrTableCell5.StylePriority.UseFont = false;
		xrTableCell5.Text = "Name";
		xrTableCell5.Weight = 0.29411765057872896;
		xrTableCell6.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[mName]")
		});
		xrTableCell6.Name = "xrTableCell6";
		xrTableCell6.Text = "xrTableCell6";
		xrTableCell6.Weight = 0.9991828469017155;
		xrTableCell7.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fName]")
		});
		xrTableCell7.Name = "xrTableCell7";
		xrTableCell7.Text = "xrTableCell7";
		xrTableCell7.Weight = 0.9983662722412325;
		xrTableCell8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Guardian]")
		});
		xrTableCell8.Name = "xrTableCell8";
		xrTableCell8.Text = "xrTableCell8";
		xrTableCell8.Weight = 0.7083332302783227;
		xrTableRow3.Cells.AddRange(new XRTableCell[4] { xrTableCell9, xrTableCell10, xrTableCell11, xrTableCell12 });
		xrTableRow3.Name = "xrTableRow3";
		xrTableRow3.Weight = 1.0;
		xrTableCell9.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell9.Name = "xrTableCell9";
		xrTableCell9.StylePriority.UseFont = false;
		xrTableCell9.Text = "Address";
		xrTableCell9.Weight = 0.29411765057872896;
		xrTableCell10.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[mAddress]")
		});
		xrTableCell10.Name = "xrTableCell10";
		xrTableCell10.Text = "xrTableCell10";
		xrTableCell10.Weight = 0.9991828469017155;
		xrTableCell11.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fAddress]")
		});
		xrTableCell11.Name = "xrTableCell11";
		xrTableCell11.Text = "xrTableCell11";
		xrTableCell11.Weight = 0.9983662722412325;
		xrTableCell12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[GuardianAddress]")
		});
		xrTableCell12.Name = "xrTableCell12";
		xrTableCell12.Text = "xrTableCell12";
		xrTableCell12.Weight = 0.7083332302783227;
		xrTableRow4.Cells.AddRange(new XRTableCell[4] { xrTableCell13, xrTableCell14, xrTableCell15, xrTableCell16 });
		xrTableRow4.Name = "xrTableRow4";
		xrTableRow4.Weight = 1.0;
		xrTableCell13.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell13.Name = "xrTableCell13";
		xrTableCell13.StylePriority.UseFont = false;
		xrTableCell13.Text = "Contact#";
		xrTableCell13.Weight = 0.29411765057872896;
		xrTableCell14.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[mContact]")
		});
		xrTableCell14.Name = "xrTableCell14";
		xrTableCell14.Text = "xrTableCell14";
		xrTableCell14.Weight = 0.9991828469017155;
		xrTableCell15.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fContact]")
		});
		xrTableCell15.Name = "xrTableCell15";
		xrTableCell15.Text = "xrTableCell15";
		xrTableCell15.Weight = 0.9983662722412325;
		xrTableCell16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[PriorityContact]")
		});
		xrTableCell16.Name = "xrTableCell16";
		xrTableCell16.Text = "xrTableCell16";
		xrTableCell16.Weight = 0.7083332302783227;
		xrTableRow5.Cells.AddRange(new XRTableCell[4] { xrTableCell17, xrTableCell18, xrTableCell19, xrTableCell20 });
		xrTableRow5.Name = "xrTableRow5";
		xrTableRow5.Weight = 1.0;
		xrTableCell17.Font = new DXFont("Tahoma", 10f, DXFontStyle.Bold);
		xrTableCell17.Name = "xrTableCell17";
		xrTableCell17.StylePriority.UseFont = false;
		xrTableCell17.Text = "Email";
		xrTableCell17.Weight = 0.29411765057872896;
		xrTableCell18.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[mEmail]")
		});
		xrTableCell18.Name = "xrTableCell18";
		xrTableCell18.Text = "xrTableCell18";
		xrTableCell18.Weight = 0.9991828469017155;
		xrTableCell19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fEmail]")
		});
		xrTableCell19.Name = "xrTableCell19";
		xrTableCell19.Text = "xrTableCell19";
		xrTableCell19.Weight = 0.9983662722412325;
		xrTableCell20.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[Email]")
		});
		xrTableCell20.Name = "xrTableCell20";
		xrTableCell20.Text = "xrTableCell20";
		xrTableCell20.Weight = 0.7083332302783227;
		xrLabel17.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[HouseId]")
		});
		xrLabel17.Font = new DXFont("Trebuchet MS", 20.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel17.LocationFloat = new PointFloat(2.000014f, 215f);
		xrLabel17.Name = "xrLabel17";
		xrLabel17.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel17.SizeF = new SizeF(774.9999f, 30.29166f);
		xrLabel17.StylePriority.UseFont = false;
		xrLabel17.StylePriority.UseTextAlignment = false;
		xrLabel17.Text = "xrLabel17";
		xrLabel17.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel18.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel18.LocationFloat = new PointFloat(2.000014f, 192f);
		xrLabel18.Name = "xrLabel18";
		xrLabel18.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel18.SizeF = new SizeF(100f, 23f);
		xrLabel18.StylePriority.UseFont = false;
		xrLabel18.StylePriority.UseTextAlignment = false;
		xrLabel18.Text = "House";
		xrLabel18.TextAlignment = TextAlignment.BottomLeft;
		xrLabel15.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel15.LocationFloat = new PointFloat(2.000014f, 127f);
		xrLabel15.Name = "xrLabel15";
		xrLabel15.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel15.SizeF = new SizeF(100f, 23f);
		xrLabel15.StylePriority.UseFont = false;
		xrLabel15.StylePriority.UseTextAlignment = false;
		xrLabel15.Text = "Stream";
		xrLabel15.TextAlignment = TextAlignment.BottomLeft;
		xrLabel16.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StreamId]")
		});
		xrLabel16.Font = new DXFont("Trebuchet MS", 20.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel16.LocationFloat = new PointFloat(2.000014f, 150f);
		xrLabel16.Name = "xrLabel16";
		xrLabel16.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel16.SizeF = new SizeF(774.9999f, 30.29166f);
		xrLabel16.StylePriority.UseFont = false;
		xrLabel16.StylePriority.UseTextAlignment = false;
		xrLabel16.Text = "xrLabel16";
		xrLabel16.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel13.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel13.LocationFloat = new PointFloat(2.000014f, 62.00002f);
		xrLabel13.Name = "xrLabel13";
		xrLabel13.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel13.SizeF = new SizeF(100f, 23f);
		xrLabel13.StylePriority.UseFont = false;
		xrLabel13.StylePriority.UseTextAlignment = false;
		xrLabel13.Text = "Class";
		xrLabel13.TextAlignment = TextAlignment.BottomLeft;
		lblClass.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		lblClass.Font = new DXFont("Trebuchet MS", 20.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblClass.LocationFloat = new PointFloat(2.000014f, 84.99998f);
		lblClass.Name = "lblClass";
		lblClass.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblClass.SizeF = new SizeF(774.9999f, 30.29166f);
		lblClass.StylePriority.UseFont = false;
		lblClass.StylePriority.UseTextAlignment = false;
		lblClass.Text = "lblClass";
		lblClass.TextAlignment = TextAlignment.MiddleLeft;
		xrLabel6.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel6.LocationFloat = new PointFloat(2.000014f, 0f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(100f, 23f);
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Name";
		xrLabel6.TextAlignment = TextAlignment.BottomLeft;
		xrLabel5.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel5.Font = new DXFont("Trebuchet MS", 20.25f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel5.LocationFloat = new PointFloat(2.000014f, 23.00002f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(774.9999f, 30.29166f);
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "xrLabel5";
		xrLabel5.TextAlignment = TextAlignment.MiddleLeft;
		TopMargin.Controls.AddRange(new XRControl[8] { xrLabel14, lblContacts, lblAddress, lblName, xrBarCode1, xrPictureBox1, xrLine2, xrLabel12 });
		TopMargin.HeightF = 316.125f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		xrLabel14.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel14.LocationFloat = new PointFloat(1.999982f, 10.00001f);
		xrLabel14.Name = "xrLabel14";
		xrLabel14.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel14.SizeF = new SizeF(775f, 23f);
		xrLabel14.StylePriority.UseFont = false;
		xrLabel14.StylePriority.UseTextAlignment = false;
		xrLabel14.Text = "Student Information";
		xrLabel14.TextAlignment = TextAlignment.MiddleCenter;
		lblContacts.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblContacts.LocationFloat = new PointFloat(0f, 121.3333f);
		lblContacts.Name = "lblContacts";
		lblContacts.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblContacts.SizeF = new SizeF(492.625f, 23f);
		lblContacts.StylePriority.UseFont = false;
		lblContacts.StylePriority.UseTextAlignment = false;
		lblContacts.Text = "lblContacts";
		lblContacts.TextAlignment = TextAlignment.MiddleLeft;
		lblAddress.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblAddress.LocationFloat = new PointFloat(0f, 98.33336f);
		lblAddress.Name = "lblAddress";
		lblAddress.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblAddress.SizeF = new SizeF(492.625f, 23f);
		lblAddress.StylePriority.UseFont = false;
		lblAddress.StylePriority.UseTextAlignment = false;
		lblAddress.Text = "lblAddress";
		lblAddress.TextAlignment = TextAlignment.MiddleLeft;
		lblName.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblName.LocationFloat = new PointFloat(0f, 75.33336f);
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblName.SizeF = new SizeF(492.625f, 23f);
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "lblName";
		lblName.TextAlignment = TextAlignment.MiddleLeft;
		xrBarCode1.AutoModule = true;
		xrBarCode1.BarCodeOrientation = BarCodeOrientation.RotateLeft;
		xrBarCode1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrBarCode1.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrBarCode1.LocationFloat = new PointFloat(702f, 75.33336f);
		xrBarCode1.Module = 1f;
		xrBarCode1.Name = "xrBarCode1";
		xrBarCode1.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		xrBarCode1.SizeF = new SizeF(75f, 217.7917f);
		xrBarCode1.StylePriority.UseFont = false;
		xrBarCode1.StylePriority.UsePadding = false;
		xrBarCode1.StylePriority.UseTextAlignment = false;
		xrBarCode1.Symbology = symbology;
		xrBarCode1.TextAlignment = TextAlignment.BottomCenter;
		xrPictureBox1.BorderColor = Color.Gainsboro;
		xrPictureBox1.Borders = BorderSide.All;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(492.625f, 75.33336f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(209.375f, 217.7917f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorderColor = false;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrLine2.LocationFloat = new PointFloat(126.0417f, 293.125f);
		xrLine2.Name = "xrLine2";
		xrLine2.SizeF = new SizeF(650.9583f, 23f);
		xrLabel12.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel12.LocationFloat = new PointFloat(0f, 293.125f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(126.0417f, 23f);
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "Student Information";
		xrLabel12.TextAlignment = TextAlignment.MiddleLeft;
		BottomMargin.HeightF = 25f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		PageFooter.Controls.AddRange(new XRControl[3] { xrLabel19, xrLine3, xrPageInfo1 });
		PageFooter.HeightF = 61f;
		PageFooter.Name = "PageFooter";
		xrLabel19.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel19.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel19.LocationFloat = new PointFloat(337.3333f, 38f);
		xrLabel19.Name = "xrLabel19";
		xrLabel19.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel19.SizeF = new SizeF(439.6666f, 23f);
		xrLabel19.StylePriority.UseFont = false;
		xrLabel19.StylePriority.UseTextAlignment = false;
		xrLabel19.Text = "xrLabel19";
		xrLabel19.TextAlignment = TextAlignment.MiddleRight;
		xrLine3.LocationFloat = new PointFloat(2.000014f, 14f);
		xrLine3.Name = "xrLine3";
		xrLine3.SizeF = new SizeF(774.9999f, 23f);
		xrPageInfo1.Font = new DXFont("Trebuchet MS", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrPageInfo1.LocationFloat = new PointFloat(2.000014f, 38f);
		xrPageInfo1.Name = "xrPageInfo1";
		xrPageInfo1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrPageInfo1.PageInfo = PageInfo.DateTime;
		xrPageInfo1.SizeF = new SizeF(175f, 23f);
		xrPageInfo1.StylePriority.UseFont = false;
		xrPageInfo1.StylePriority.UseTextAlignment = false;
		xrPageInfo1.TextAlignment = TextAlignment.MiddleLeft;
		StudentNo.Description = "StudentNumber";
		StudentNo.Name = "StudentNo";
		StudentNo.Visible = false;
		GroupHeader1.Controls.AddRange(new XRControl[8] { xrLabel6, xrLabel5, lblClass, xrLabel13, xrLabel16, xrLabel15, xrLabel18, xrLabel17 });
		GroupHeader1.HeightF = 256.25f;
		GroupHeader1.Name = "GroupHeader1";
		studentPreviewSource1.DataSetName = "StudentPreviewSource";
		studentPreviewSource1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
		studentPreviewSourceTableAdapter.ClearBeforeFill = true;
		base.Bands.AddRange(new Band[5] { Detail, TopMargin, BottomMargin, PageFooter, GroupHeader1 });
		base.ComponentStorage.AddRange(new IComponent[1] { studentPreviewSource1 });
		base.DataAdapter = studentPreviewSourceTableAdapter;
		base.DataMember = "StudentPreviewSource";
		base.DataSource = studentPreviewSource1;
		base.Margins = new DXMargins(25f, 25f, 316.125f, 25f);
		base.PageHeight = 1169;
		base.PageWidth = 827;
		base.PaperKind = DXPaperKind.A4;
		base.Parameters.AddRange(new Parameter[1] { StudentNo });
		base.ShowPreviewMarginLines = false;
		base.SnapGridSize = 2f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "23.2";
		BeforePrint += StudentPreview_BeforePrint;
		((ISupportInitialize)xrTable1).EndInit();
		((ISupportInitialize)studentPreviewSource1).EndInit();
		((ISupportInitialize)this).EndInit();
	}
}
