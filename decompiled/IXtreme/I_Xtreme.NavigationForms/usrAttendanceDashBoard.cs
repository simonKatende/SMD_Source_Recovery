using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrAttendanceDashBoard : XtraUserControl
{
	private IContainer components = null;

	private PictureEdit pictureEdit1;

	private LabelControl labelControl1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private GridBand gridBand1;

	private BandedGridColumn bandedGridColDate;

	private BandedGridColumn bandedGridColParticulars;

	private BandedGridColumn bandedGridColTrxRef;

	private BandedGridColumn bandedGridColAccountRef;

	private GridBand gridBandDR;

	private BandedGridColumn bandedGridColcDr;

	private BandedGridColumn bandedGridColbDr;

	private GridBand gridBandCR;

	private BandedGridColumn bandedGridColcCr;

	private BandedGridColumn bandedGridColbCr;

	public usrAttendanceDashBoard()
	{
		InitializeComponent();
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
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColParticulars = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColTrxRef = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColAccountRef = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBandDR = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColcDr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColbDr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBandCR = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColcCr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColbCr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
		this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.fingerprint_reader1;
		this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(862, 550);
		this.pictureEdit1.TabIndex = 0;
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.Appearance.BackColor = System.Drawing.SystemColors.HotTrack;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl1.Appearance.Options.UseBackColor = true;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl1.Location = new System.Drawing.Point(3, 91);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
		this.labelControl1.Size = new System.Drawing.Size(859, 37);
		this.labelControl1.TabIndex = 3;
		this.labelControl1.Text = "Class and School Attendance";
		this.gridColumn1.Caption = "Category";
		this.gridColumn1.FieldName = "Category";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn2.Caption = "Date";
		this.gridColumn2.DisplayFormat.FormatString = "dd-MMM-yy";
		this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn2.FieldName = "Date";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 142;
		this.gridColumn3.Caption = "Ref#";
		this.gridColumn3.FieldName = "Ref#";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 153;
		this.gridColumn4.Caption = "Particulars";
		this.gridColumn4.FieldName = "Particulars";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn4.Width = 516;
		this.gridColumn5.Caption = "Amount";
		this.gridColumn5.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn5.FieldName = "Amount";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#}")
		});
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.gridColumn5.Width = 323;
		this.gridColumn6.Caption = "Category";
		this.gridColumn6.FieldName = "MajorGroup";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 0;
		this.gridColumn7.Caption = "Account#";
		this.gridColumn7.FieldName = "SubAccountNo";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 0;
		this.gridColumn8.Caption = "Account";
		this.gridColumn8.FieldName = "SubAccountName";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 1;
		this.gridColumn9.Caption = "Revenue";
		this.gridColumn9.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn9.FieldName = "Credit";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Credit", "{0:#,#.0}")
		});
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 2;
		this.gridColumn10.Caption = "Expenses";
		this.gridColumn10.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn10.FieldName = "Debit";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Debit", "{0:#,#.0}")
		});
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 3;
		this.gridColumn11.Caption = "Net Profit/Loss";
		this.gridColumn11.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn11.FieldName = "Bal";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Bal", "{0:#,#.0}")
		});
		this.gridColumn11.Visible = true;
		this.gridColumn11.VisibleIndex = 4;
		this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBand1.AppearanceHeader.Options.UseFont = true;
		this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBand1.Caption = "Transaction Details";
		this.gridBand1.Columns.Add(this.bandedGridColDate);
		this.gridBand1.Columns.Add(this.bandedGridColParticulars);
		this.gridBand1.Columns.Add(this.bandedGridColTrxRef);
		this.gridBand1.Columns.Add(this.bandedGridColAccountRef);
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.OptionsBand.AllowHotTrack = false;
		this.gridBand1.OptionsBand.AllowMove = false;
		this.gridBand1.OptionsBand.AllowPress = false;
		this.gridBand1.OptionsBand.ShowInCustomizationForm = false;
		this.gridBand1.VisibleIndex = -1;
		this.gridBand1.Width = 545;
		this.bandedGridColDate.Caption = "Date";
		this.bandedGridColDate.DisplayFormat.FormatString = "dd.MMM.yy";
		this.bandedGridColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.bandedGridColDate.FieldName = "Date";
		this.bandedGridColDate.Name = "bandedGridColDate";
		this.bandedGridColDate.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
		this.bandedGridColDate.Visible = true;
		this.bandedGridColDate.Width = 70;
		this.bandedGridColParticulars.Caption = "Particulars";
		this.bandedGridColParticulars.FieldName = "Particulars";
		this.bandedGridColParticulars.Name = "bandedGridColParticulars";
		this.bandedGridColParticulars.Visible = true;
		this.bandedGridColParticulars.Width = 250;
		this.bandedGridColTrxRef.Caption = "Trx. Ref.";
		this.bandedGridColTrxRef.DisplayFormat.FormatString = "{0:#}";
		this.bandedGridColTrxRef.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColTrxRef.FieldName = "TrxRef";
		this.bandedGridColTrxRef.Name = "bandedGridColTrxRef";
		this.bandedGridColTrxRef.Visible = true;
		this.bandedGridColTrxRef.Width = 112;
		this.bandedGridColAccountRef.Caption = "Account Title";
		this.bandedGridColAccountRef.FieldName = "AccountRef";
		this.bandedGridColAccountRef.Name = "bandedGridColAccountRef";
		this.bandedGridColAccountRef.Visible = true;
		this.bandedGridColAccountRef.Width = 113;
		this.gridBandDR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBandDR.AppearanceHeader.Options.UseFont = true;
		this.gridBandDR.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBandDR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBandDR.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBandDR.Caption = "DR.";
		this.gridBandDR.Columns.Add(this.bandedGridColcDr);
		this.gridBandDR.Columns.Add(this.bandedGridColbDr);
		this.gridBandDR.Name = "gridBandDR";
		this.gridBandDR.OptionsBand.AllowHotTrack = false;
		this.gridBandDR.OptionsBand.AllowMove = false;
		this.gridBandDR.OptionsBand.AllowPress = false;
		this.gridBandDR.OptionsBand.ShowInCustomizationForm = false;
		this.gridBandDR.RowCount = 2;
		this.gridBandDR.VisibleIndex = -1;
		this.gridBandDR.Width = 174;
		this.bandedGridColcDr.Caption = "Cash";
		this.bandedGridColcDr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColcDr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColcDr.FieldName = "dCash";
		this.bandedGridColcDr.Name = "bandedGridColcDr";
		this.bandedGridColcDr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dCash", "{0:#,#.0}")
		});
		this.bandedGridColcDr.Visible = true;
		this.bandedGridColcDr.Width = 85;
		this.bandedGridColbDr.Caption = "Bank";
		this.bandedGridColbDr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColbDr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColbDr.FieldName = "dBank";
		this.bandedGridColbDr.Name = "bandedGridColbDr";
		this.bandedGridColbDr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "dBank", "{0:#,#.0}")
		});
		this.bandedGridColbDr.Visible = true;
		this.bandedGridColbDr.Width = 89;
		this.gridBandCR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.gridBandCR.AppearanceHeader.Options.UseFont = true;
		this.gridBandCR.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBandCR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBandCR.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.gridBandCR.Caption = "CR.";
		this.gridBandCR.Columns.Add(this.bandedGridColcCr);
		this.gridBandCR.Columns.Add(this.bandedGridColbCr);
		this.gridBandCR.Name = "gridBandCR";
		this.gridBandCR.OptionsBand.AllowHotTrack = false;
		this.gridBandCR.OptionsBand.AllowMove = false;
		this.gridBandCR.OptionsBand.AllowPress = false;
		this.gridBandCR.OptionsBand.ShowInCustomizationForm = false;
		this.gridBandCR.VisibleIndex = -1;
		this.gridBandCR.Width = 179;
		this.bandedGridColcCr.Caption = "Cash";
		this.bandedGridColcCr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColcCr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColcCr.FieldName = "cCash";
		this.bandedGridColcCr.Name = "bandedGridColcCr";
		this.bandedGridColcCr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cCash", "{0:#,#.0}")
		});
		this.bandedGridColcCr.Visible = true;
		this.bandedGridColcCr.Width = 87;
		this.bandedGridColbCr.Caption = "Bank";
		this.bandedGridColbCr.DisplayFormat.FormatString = "{0:#,#.0}";
		this.bandedGridColbCr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.bandedGridColbCr.FieldName = "cBank";
		this.bandedGridColbCr.Name = "bandedGridColbCr";
		this.bandedGridColbCr.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cBank", "{0:#,#.0}")
		});
		this.bandedGridColbCr.Visible = true;
		this.bandedGridColbCr.Width = 92;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.labelControl1);
		base.Controls.Add(this.pictureEdit1);
		base.Name = "usrAttendanceDashBoard";
		base.Size = new System.Drawing.Size(862, 550);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
