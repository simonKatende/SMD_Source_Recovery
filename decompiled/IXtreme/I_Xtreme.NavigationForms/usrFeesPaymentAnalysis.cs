using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;

namespace I_Xtreme.NavigationForms;

public class usrFeesPaymentAnalysis : XtraUserControl
{
	private bool SummaryType = false;

	private string semester = string.Empty;

	private string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private PivotGridControl pivotGridExpenses;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	public usrFeesPaymentAnalysis(string _Semester, bool _SummaryType)
	{
		InitializeComponent();
		semester = _Semester;
		SummaryType = _SummaryType;
	}

	private void LoadFeesAnalysis_General()
	{
		try
		{
			string selectCommandText = string.Empty;
			if (SummaryType)
			{
				ActiveFormSelected.SetActiveForm("Fees Billing Analysis");
				selectCommandText = $"SELECT f.DateOfPayment, s.fullName,s.ClassId AS Class, f.PaymentId, f.Particulars, f.Debit AS Amount,f.SemesterId,f.ModeOfPayment FROM tbl_Stud s INNER JOIN FeesPayment f ON s.StudentNumber = f.StudentNumber WHERE f.SemesterId LIKE '%{semester}%' AND f.Credit=0";
			}
			else if (!SummaryType)
			{
				ActiveFormSelected.SetActiveForm("Fees Payment Analysis");
				selectCommandText = $"SELECT f.DateOfPayment, s.fullName,s.ClassId AS Class, f.PaymentId, f.Particulars,f.Credit AS Amount,f.SemesterId,f.ModeOfPayment FROM tbl_Stud s INNER JOIN FeesPayment f ON s.StudentNumber = f.StudentNumber WHERE f.SemesterId LIKE '%{semester}%' AND f.Debit=0 AND f.Particulars<>'Waiver on Fees'";
			}
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "FeesAnalysis");
			pivotGridExpenses.DataSource = null;
			pivotGridExpenses.DataSource = dataSet.Tables["FeesAnalysis"];
			PrintableControl.SavePrintableControl(pivotGridExpenses);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void usrFeesPaymentAnalysis_Load(object sender, EventArgs e)
	{
		LoadFeesAnalysis_General();
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pivotGridExpenses = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridExpenses).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.pivotGridExpenses);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(887, 512);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.pivotGridExpenses.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[5] { this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5 });
		this.pivotGridExpenses.Location = new System.Drawing.Point(3, 3);
		this.pivotGridExpenses.Name = "pivotGridExpenses";
		this.pivotGridExpenses.OptionsDataField.RowHeaderWidth = 67;
		this.pivotGridExpenses.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridExpenses.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridExpenses.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridExpenses.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridExpenses.OptionsView.RowTreeOffset = 14;
		this.pivotGridExpenses.OptionsView.RowTreeWidth = 67;
		this.pivotGridExpenses.OptionsView.ShowColumnHeaders = false;
		this.pivotGridExpenses.OptionsView.ShowDataHeaders = false;
		this.pivotGridExpenses.OptionsView.ShowFilterHeaders = false;
		this.pivotGridExpenses.Size = new System.Drawing.Size(881, 506);
		this.pivotGridExpenses.TabIndex = 4;
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Class";
		this.pivotGridField1.FieldName = "Class";
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.Width = 133;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "Date";
		this.pivotGridField2.CellFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField2.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField2.FieldName = "DateOfPayment";
		this.pivotGridField2.GrandTotalCellFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField2.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.TotalCellFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField2.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField2.TotalValueFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField2.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField2.ValueFormat.FormatString = "dd-MMM-yy";
		this.pivotGridField2.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField3.AreaIndex = 2;
		this.pivotGridField3.Caption = "Name";
		this.pivotGridField3.FieldName = "fullName";
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField3.Width = 200;
		this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField4.AreaIndex = 0;
		this.pivotGridField4.Caption = "Particulars";
		this.pivotGridField4.FieldName = "Particulars";
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField5.AreaIndex = 0;
		this.pivotGridField5.Caption = "Amount";
		this.pivotGridField5.CellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField5.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField5.FieldName = "Amount";
		this.pivotGridField5.GrandTotalCellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField5.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField5.TotalCellFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField5.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField5.TotalValueFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField5.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField5.ValueFormat.FormatString = "{0:#,#.0}";
		this.pivotGridField5.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(887, 512);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.pivotGridExpenses;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(883, 508);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrFeesPaymentAnalysis";
		base.Size = new System.Drawing.Size(887, 512);
		base.Load += new System.EventHandler(usrFeesPaymentAnalysis_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridExpenses).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
