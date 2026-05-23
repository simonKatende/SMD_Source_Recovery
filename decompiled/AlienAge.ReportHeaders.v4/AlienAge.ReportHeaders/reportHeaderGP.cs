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

namespace AlienAge.ReportHeaders;

public class reportHeaderGP : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private TopMarginBand TopMargin;

	private BottomMarginBand BottomMargin;

	private XRLabel lblName;

	private XRLabel lblFullAddress;

	private XRLabel lblLocation;

	public reportHeaderGP()
	{
		InitializeComponent();
	}

	private void reportHeaderGP_BeforePrint(object sender, CancelEventArgs e)
	{
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
				lblName.Text = FingerPrint.SchoolName;
				lblFullAddress.Text = row["fullContact"].ToString();
				lblLocation.Text = FingerPrint.Village;
			}
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
		lblFullAddress = new XRLabel();
		lblLocation = new XRLabel();
		lblName = new XRLabel();
		TopMargin = new TopMarginBand();
		BottomMargin = new BottomMarginBand();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[3] { lblFullAddress, lblLocation, lblName });
		Detail.HeightF = 77.08334f;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		lblFullAddress.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblFullAddress.LocationFloat = new PointFloat(0f, 46f);
		lblFullAddress.Name = "lblFullAddress";
		lblFullAddress.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblFullAddress.SizeF = new SizeF(620f, 23f);
		lblFullAddress.StylePriority.UseFont = false;
		lblFullAddress.StylePriority.UseTextAlignment = false;
		lblFullAddress.Text = "lblFullAddress";
		lblFullAddress.TextAlignment = TextAlignment.MiddleCenter;
		lblLocation.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblLocation.LocationFloat = new PointFloat(0f, 23f);
		lblLocation.Name = "lblLocation";
		lblLocation.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblLocation.SizeF = new SizeF(619.9999f, 23f);
		lblLocation.StylePriority.UseFont = false;
		lblLocation.StylePriority.UseTextAlignment = false;
		lblLocation.Text = "lblLocation";
		lblLocation.TextAlignment = TextAlignment.MiddleCenter;
		lblName.Font = new DXFont("Tahoma", 11.25f, DXFontStyle.Bold, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		lblName.LocationFloat = new PointFloat(0f, 0f);
		lblName.Name = "lblName";
		lblName.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		lblName.SizeF = new SizeF(619.9999f, 23f);
		lblName.StylePriority.UseFont = false;
		lblName.StylePriority.UseTextAlignment = false;
		lblName.Text = "lblName";
		lblName.TextAlignment = TextAlignment.MiddleCenter;
		TopMargin.HeightF = 0f;
		TopMargin.Name = "TopMargin";
		TopMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		TopMargin.TextAlignment = TextAlignment.TopLeft;
		BottomMargin.HeightF = 0f;
		BottomMargin.Name = "BottomMargin";
		BottomMargin.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		BottomMargin.TextAlignment = TextAlignment.TopLeft;
		base.Bands.AddRange(new Band[3] { Detail, TopMargin, BottomMargin });
		base.Margins = new DXMargins(0f, 0f, 0f, 0f);
		base.PageHeight = 100;
		base.PageWidth = 620;
		base.PaperKind = DXPaperKind.Custom;
		base.SnapGridSize = 1f;
		base.Version = "13.1";
		BeforePrint += reportHeaderGP_BeforePrint;
		((ISupportInitialize)this).EndInit();
	}
}
