using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Drawing;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;

namespace I_Xtreme;

public class ClearanceCards_PS : XtraReport
{
	private IContainer components = null;

	private DetailBand Detail;

	private XRPanel xrPanel1;

	private TopMarginBand topMarginBand1;

	private BottomMarginBand bottomMarginBand1;

	private XRSubreport xrSubreport1;

	private XRLabel xrLabel10;

	private XRLabel xrLabel5;

	private XRLabel xrLabel4;

	private XRLabel xrLabel2;

	private XRLabel xrLabel1;

	private XRLabel xrLabel11;

	private XRLabel xrLabel12;

	private XRLabel xrLabel8;

	private XRLabel xrLabel7;

	public Parameter StudentNumber;

	private XRPictureBox xrPictureBox1;

	private XRLabel xrLabel3;

	private XRLabel xrLabel6;

	public ClearanceCards_PS()
	{
		InitializeComponent();
	}

	private void ClearanceCards_PS_ParametersRequestBeforeShow(object sender, ParametersRequestEventArgs e)
	{
		try
		{
			ParameterInfo[] parametersInformation = e.ParametersInformation;
			foreach (ParameterInfo parameterInfo in parametersInformation)
			{
				if (!(parameterInfo.Parameter.Name == "StudentNumber"))
				{
					continue;
				}
				LookUpEdit lookUpEdit = new LookUpEdit();
				using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT fullName AS Name,StudentNumber AS StudentNo,ClassId AS Class FROM tbl_Stud", selectConnection);
					using DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "Students");
					DataTable dataTable = new DataTable();
					dataTable = dataSet.Tables[0];
					lookUpEdit.Properties.DataSource = dataTable.DefaultView;
					lookUpEdit.Properties.ValueMember = "StudentNo";
					lookUpEdit.Properties.DisplayMember = "Name";
					LookUpColumnInfoCollection columns = lookUpEdit.Properties.Columns;
					columns.Add(new LookUpColumnInfo("Name", 0));
					columns.Add(new LookUpColumnInfo("StudentNo", 0));
					columns.Add(new LookUpColumnInfo("Class", 0));
					lookUpEdit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
					lookUpEdit.Properties.SearchMode = SearchMode.AutoComplete;
					lookUpEdit.Properties.AutoSearchColumnIndex = 0;
				}
				parameterInfo.Editor = lookUpEdit;
			}
			ParameterInfo[] parametersInformation2 = e.ParametersInformation;
			foreach (ParameterInfo parameterInfo2 in parametersInformation2)
			{
				if (parameterInfo2.Parameter.Name == "semester")
				{
					ComboBoxEdit comboBoxEdit = new ComboBoxEdit();
					WorkingSemesters.GetSemesters(new ComboBoxEdit[1] { comboBoxEdit });
					parameterInfo2.Editor = comboBoxEdit;
					comboBoxEdit.SelectedIndex = 0;
				}
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
		xrSubreport1 = new XRSubreport();
		xrPanel1 = new XRPanel();
		xrLabel3 = new XRLabel();
		xrLabel6 = new XRLabel();
		xrPictureBox1 = new XRPictureBox();
		xrLabel12 = new XRLabel();
		xrLabel8 = new XRLabel();
		xrLabel7 = new XRLabel();
		xrLabel11 = new XRLabel();
		xrLabel10 = new XRLabel();
		xrLabel5 = new XRLabel();
		xrLabel4 = new XRLabel();
		xrLabel2 = new XRLabel();
		xrLabel1 = new XRLabel();
		topMarginBand1 = new TopMarginBand();
		bottomMarginBand1 = new BottomMarginBand();
		StudentNumber = new Parameter();
		((ISupportInitialize)this).BeginInit();
		Detail.Controls.AddRange(new XRControl[2] { xrSubreport1, xrPanel1 });
		Detail.HeightF = 277.8772f;
		Detail.MultiColumn.ColumnCount = 2;
		Detail.MultiColumn.ColumnSpacing = 5f;
		Detail.MultiColumn.ColumnWidth = 475f;
		Detail.MultiColumn.Layout = ColumnLayout.AcrossThenDown;
		Detail.MultiColumn.Mode = MultiColumnMode.UseColumnCount;
		Detail.Name = "Detail";
		Detail.Padding = new PaddingInfo(0, 0, 0, 0, 100f);
		Detail.TextAlignment = TextAlignment.TopLeft;
		xrSubreport1.LocationFloat = new PointFloat(6f, 5f);
		xrSubreport1.Name = "xrSubreport1";
		xrSubreport1.ReportSource = new SchoolDetails_Small();
		xrSubreport1.SizeF = new SizeF(379f, 41.75f);
		xrPanel1.Borders = DevExpress.XtraPrinting.BorderSide.All;
		xrPanel1.CanGrow = false;
		xrPanel1.Controls.AddRange(new XRControl[12]
		{
			xrLabel3, xrLabel6, xrPictureBox1, xrLabel12, xrLabel8, xrLabel7, xrLabel11, xrLabel10, xrLabel5, xrLabel4,
			xrLabel2, xrLabel1
		});
		xrPanel1.LocationFloat = new PointFloat(0f, 0f);
		xrPanel1.Name = "xrPanel1";
		xrPanel1.SizeF = new SizeF(390f, 235f);
		xrLabel3.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
		xrLabel3.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[ClassId]")
		});
		xrLabel3.Font = new DXFont("Tahoma", 9f);
		xrLabel3.LocationFloat = new PointFloat(77f, 138f);
		xrLabel3.Name = "xrLabel3";
		xrLabel3.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel3.SizeF = new SizeF(193.5f, 23.00005f);
		xrLabel3.StylePriority.UseBorderDashStyle = false;
		xrLabel3.StylePriority.UseBorders = false;
		xrLabel3.StylePriority.UseFont = false;
		xrLabel3.StylePriority.UseTextAlignment = false;
		xrLabel3.Text = "xrLabel3";
		xrLabel3.TextAlignment = TextAlignment.BottomLeft;
		xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrLabel6.Font = new DXFont("Tahoma", 9f);
		xrLabel6.LocationFloat = new PointFloat(3.999996f, 138f);
		xrLabel6.Name = "xrLabel6";
		xrLabel6.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel6.SizeF = new SizeF(72.9167f, 23f);
		xrLabel6.StylePriority.UseBorders = false;
		xrLabel6.StylePriority.UseFont = false;
		xrLabel6.StylePriority.UseTextAlignment = false;
		xrLabel6.Text = "Class:";
		xrLabel6.TextAlignment = TextAlignment.BottomLeft;
		xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrPictureBox1.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "ImageSource", "[Picture]")
		});
		xrPictureBox1.LocationFloat = new PointFloat(270.5f, 86.00006f);
		xrPictureBox1.Name = "xrPictureBox1";
		xrPictureBox1.SizeF = new SizeF(114.5f, 127f);
		xrPictureBox1.Sizing = ImageSizeMode.StretchImage;
		xrPictureBox1.StylePriority.UseBorders = false;
		xrLabel12.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
		xrLabel12.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[cashOnAccount]")
		});
		xrLabel12.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel12.LocationFloat = new PointFloat(76.91669f, 164f);
		xrLabel12.Name = "xrLabel12";
		xrLabel12.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel12.SizeF = new SizeF(193.5833f, 23f);
		xrLabel12.StylePriority.UseBorderDashStyle = false;
		xrLabel12.StylePriority.UseBorders = false;
		xrLabel12.StylePriority.UseFont = false;
		xrLabel12.StylePriority.UseTextAlignment = false;
		xrLabel12.Text = "xrLabel12";
		xrLabel12.TextAlignment = TextAlignment.BottomLeft;
		xrLabel8.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
		xrLabel8.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[StudentNumber]")
		});
		xrLabel8.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel8.LocationFloat = new PointFloat(76.91669f, 112f);
		xrLabel8.Name = "xrLabel8";
		xrLabel8.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel8.SizeF = new SizeF(193.5833f, 23.00001f);
		xrLabel8.StylePriority.UseBorderDashStyle = false;
		xrLabel8.StylePriority.UseBorders = false;
		xrLabel8.StylePriority.UseFont = false;
		xrLabel8.StylePriority.UseTextAlignment = false;
		xrLabel8.Text = "xrLabel8";
		xrLabel8.TextAlignment = TextAlignment.BottomLeft;
		xrLabel7.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
		xrLabel7.ExpressionBindings.AddRange(new ExpressionBinding[1]
		{
			new ExpressionBinding("BeforePrint", "Text", "[fullName]")
		});
		xrLabel7.Font = new DXFont("Tahoma", 9.75f, DXFontStyle.Regular, DXGraphicsUnit.Point, new DXFontAdditionalProperty[1]
		{
			new DXFontAdditionalProperty("GdiCharSet", (byte)0)
		});
		xrLabel7.LocationFloat = new PointFloat(76.91669f, 86f);
		xrLabel7.Name = "xrLabel7";
		xrLabel7.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel7.SizeF = new SizeF(193.5833f, 23f);
		xrLabel7.StylePriority.UseBorderDashStyle = false;
		xrLabel7.StylePriority.UseBorders = false;
		xrLabel7.StylePriority.UseFont = false;
		xrLabel7.StylePriority.UseTextAlignment = false;
		xrLabel7.Text = "xrLabel7";
		xrLabel7.TextAlignment = TextAlignment.BottomLeft;
		xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrLabel11.Font = new DXFont("Tahoma", 9f, DXFontStyle.Bold);
		xrLabel11.LocationFloat = new PointFloat(3.999996f, 51.99998f);
		xrLabel11.Name = "xrLabel11";
		xrLabel11.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel11.SizeF = new SizeF(381f, 24.00001f);
		xrLabel11.StylePriority.UseBorders = false;
		xrLabel11.StylePriority.UseFont = false;
		xrLabel11.StylePriority.UseTextAlignment = false;
		xrLabel11.Text = "FEES CLEARANCE CARD";
		xrLabel11.TextAlignment = TextAlignment.MiddleCenter;
		xrLabel10.BorderDashStyle = BorderDashStyle.Dash;
		xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
		xrLabel10.Font = new DXFont("Tahoma", 9f);
		xrLabel10.LocationFloat = new PointFloat(76.91669f, 190f);
		xrLabel10.Name = "xrLabel10";
		xrLabel10.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel10.SizeF = new SizeF(193.5833f, 23.00005f);
		xrLabel10.StylePriority.UseBorderDashStyle = false;
		xrLabel10.StylePriority.UseBorders = false;
		xrLabel10.StylePriority.UseFont = false;
		xrLabel10.StylePriority.UseTextAlignment = false;
		xrLabel10.TextAlignment = TextAlignment.BottomLeft;
		xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrLabel5.Font = new DXFont("Tahoma", 9f);
		xrLabel5.LocationFloat = new PointFloat(3.999996f, 190f);
		xrLabel5.Name = "xrLabel5";
		xrLabel5.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel5.SizeF = new SizeF(72.9167f, 23f);
		xrLabel5.StylePriority.UseBorders = false;
		xrLabel5.StylePriority.UseFont = false;
		xrLabel5.StylePriority.UseTextAlignment = false;
		xrLabel5.Text = "Valid Until:";
		xrLabel5.TextAlignment = TextAlignment.BottomLeft;
		xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrLabel4.Font = new DXFont("Tahoma", 9f);
		xrLabel4.LocationFloat = new PointFloat(3.999996f, 164f);
		xrLabel4.Name = "xrLabel4";
		xrLabel4.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel4.SizeF = new SizeF(72.9167f, 23f);
		xrLabel4.StylePriority.UseBorders = false;
		xrLabel4.StylePriority.UseFont = false;
		xrLabel4.StylePriority.UseTextAlignment = false;
		xrLabel4.Text = "Balance:";
		xrLabel4.TextAlignment = TextAlignment.BottomLeft;
		xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrLabel2.Font = new DXFont("Tahoma", 9f);
		xrLabel2.LocationFloat = new PointFloat(3.999996f, 112f);
		xrLabel2.Name = "xrLabel2";
		xrLabel2.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel2.SizeF = new SizeF(72.9167f, 23.00001f);
		xrLabel2.StylePriority.UseBorders = false;
		xrLabel2.StylePriority.UseFont = false;
		xrLabel2.StylePriority.UseTextAlignment = false;
		xrLabel2.Text = "Student No:";
		xrLabel2.TextAlignment = TextAlignment.BottomLeft;
		xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
		xrLabel1.Font = new DXFont("Tahoma", 9f);
		xrLabel1.LocationFloat = new PointFloat(3.999996f, 86f);
		xrLabel1.Name = "xrLabel1";
		xrLabel1.Padding = new PaddingInfo(2, 2, 0, 0, 100f);
		xrLabel1.SizeF = new SizeF(72.9167f, 23f);
		xrLabel1.StylePriority.UseBorders = false;
		xrLabel1.StylePriority.UseFont = false;
		xrLabel1.StylePriority.UseTextAlignment = false;
		xrLabel1.Text = "Name:";
		xrLabel1.TextAlignment = TextAlignment.BottomLeft;
		topMarginBand1.HeightF = 30f;
		topMarginBand1.Name = "topMarginBand1";
		bottomMarginBand1.HeightF = 10f;
		bottomMarginBand1.Name = "bottomMarginBand1";
		StudentNumber.Description = "Student";
		StudentNumber.Name = "StudentNumber";
		base.Bands.AddRange(new Band[3] { Detail, topMarginBand1, bottomMarginBand1 });
		FilterString = "[StudentNumber] = ?StudentNumber";
		base.Margins = new DXMargins(10f, 10f, 30f, 10f);
		base.PageHeight = 235;
		base.PageWidth = 410;
		base.PaperKind = DXPaperKind.Custom;
		base.Parameters.AddRange(new Parameter[1] { StudentNumber });
		base.SnapGridSize = 1f;
		base.SnappingMode = SnappingMode.SnapToGrid;
		base.Version = "21.2";
		base.ParametersRequestBeforeShow += ClearanceCards_PS_ParametersRequestBeforeShow;
		((ISupportInitialize)this).EndInit();
	}
}
