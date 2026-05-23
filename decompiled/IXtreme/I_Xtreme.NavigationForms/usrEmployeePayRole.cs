using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPivotGrid;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrEmployeePayRole : XtraUserControl
{
	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LabelControl lblHeader2;

	private LabelControl lblHeader1;

	private NavigationFrame navigationPayroll;

	private NavigationPage pageReviewPayroll;

	private NavigationPage pagePayrollHome;

	private PictureEdit pictureEdit1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private PivotGridControl pivotGridControl1;

	private PivotGridField pivotGridField1;

	private PivotGridField pivotGridField2;

	private PivotGridField pivotGridField3;

	private PivotGridField pivotGridField4;

	private PivotGridField pivotGridField5;

	private PivotGridField pivotGridField6;

	private PivotGridField pivotGridField7;

	private PivotGridField pivotGridField8;

	private PivotGridField pivotGridField9;

	private PivotGridField pivotGridField10;

	private PivotGridField pivotGridField11;

	private PivotGridField pivotGridField12;

	public usrEmployeePayRole()
	{
		InitializeComponent();
	}

	public void PayrollCallBackFN(string navHeader, string BudgetPeriod, DataTable dt)
	{
		if (navHeader == "pagePayrollHome")
		{
			layoutControlItem2.Visibility = LayoutVisibility.Never;
			layoutControlItem3.Visibility = LayoutVisibility.Never;
			navigationPayroll.SelectedPage = pagePayrollHome;
		}
		else if (navHeader == "pageReviewPayroll")
		{
			layoutControlItem2.Visibility = LayoutVisibility.Always;
			layoutControlItem3.Visibility = LayoutVisibility.Always;
			pivotGridControl1.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(pivotGridControl1);
			navigationPayroll.SelectedPage = pageReviewPayroll;
			lblHeader1.Text = "Payroll";
		}
		lblHeader2.Text = BudgetPeriod;
	}

	private void pivotGridControl1_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
	{
		if (e.ValueType == PivotGridValueType.GrandTotal)
		{
			e.Info.Caption = "NET PAY";
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lblHeader2 = new DevExpress.XtraEditors.LabelControl();
		this.lblHeader1 = new DevExpress.XtraEditors.LabelControl();
		this.navigationPayroll = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.pageReviewPayroll = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
		this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField5 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField6 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField7 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField8 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField9 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField10 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField11 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pivotGridField12 = new DevExpress.XtraPivotGrid.PivotGridField();
		this.pagePayrollHome = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.navigationPayroll).BeginInit();
		this.navigationPayroll.SuspendLayout();
		this.pageReviewPayroll.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).BeginInit();
		this.pagePayrollHome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.lblHeader2);
		this.layoutControl1.Controls.Add(this.lblHeader1);
		this.layoutControl1.Controls.Add(this.navigationPayroll);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Margin = new System.Windows.Forms.Padding(4);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(1234, 750);
		this.layoutControl1.TabIndex = 2;
		this.layoutControl1.Text = "layoutControl1";
		this.lblHeader2.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.lblHeader2.Appearance.Options.UseFont = true;
		this.lblHeader2.Appearance.Options.UseTextOptions = true;
		this.lblHeader2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader2.Location = new System.Drawing.Point(4, 42);
		this.lblHeader2.Margin = new System.Windows.Forms.Padding(4);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(1226, 27);
		this.lblHeader2.StyleController = this.layoutControl1;
		this.lblHeader2.TabIndex = 5;
		this.lblHeader1.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.lblHeader1.Appearance.Options.UseFont = true;
		this.lblHeader1.Appearance.Options.UseTextOptions = true;
		this.lblHeader1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader1.Location = new System.Drawing.Point(4, 4);
		this.lblHeader1.Margin = new System.Windows.Forms.Padding(4);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(1226, 34);
		this.lblHeader1.StyleController = this.layoutControl1;
		this.lblHeader1.TabIndex = 4;
		this.navigationPayroll.Controls.Add(this.pageReviewPayroll);
		this.navigationPayroll.Controls.Add(this.pagePayrollHome);
		this.navigationPayroll.Location = new System.Drawing.Point(4, 73);
		this.navigationPayroll.Name = "navigationPayroll";
		this.navigationPayroll.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[2] { this.pagePayrollHome, this.pageReviewPayroll });
		this.navigationPayroll.SelectedPage = this.pagePayrollHome;
		this.navigationPayroll.Size = new System.Drawing.Size(1226, 673);
		this.navigationPayroll.TabIndex = 0;
		this.navigationPayroll.Text = "navigationFrame1";
		this.navigationPayroll.TransitionType = DevExpress.Utils.Animation.Transitions.Shape;
		this.pageReviewPayroll.Controls.Add(this.pivotGridControl1);
		this.pageReviewPayroll.Margin = new System.Windows.Forms.Padding(4);
		this.pageReviewPayroll.Name = "pageReviewPayroll";
		this.pageReviewPayroll.Size = new System.Drawing.Size(1226, 673);
		this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[12]
		{
			this.pivotGridField1, this.pivotGridField2, this.pivotGridField3, this.pivotGridField4, this.pivotGridField5, this.pivotGridField6, this.pivotGridField7, this.pivotGridField8, this.pivotGridField9, this.pivotGridField10,
			this.pivotGridField11, this.pivotGridField12
		});
		this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
		this.pivotGridControl1.Name = "pivotGridControl1";
		this.pivotGridControl1.OptionsBehavior.ApplyBestFitOnFieldDragging = true;
		this.pivotGridControl1.OptionsBehavior.UseAsyncMode = true;
		this.pivotGridControl1.OptionsPrint.PrintColumnAreaOnEveryPage = true;
		this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
		this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
		this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
		this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
		this.pivotGridControl1.Size = new System.Drawing.Size(1226, 673);
		this.pivotGridControl1.TabIndex = 0;
		this.pivotGridControl1.CustomDrawFieldValue += new DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventHandler(pivotGridControl1_CustomDrawFieldValue);
		this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField1.AreaIndex = 0;
		this.pivotGridField1.Caption = "Staff No.";
		this.pivotGridField1.FieldName = "StaffId";
		this.pivotGridField1.Name = "pivotGridField1";
		this.pivotGridField1.Width = 150;
		this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField2.AreaIndex = 1;
		this.pivotGridField2.Caption = "Name";
		this.pivotGridField2.FieldName = "StaffName";
		this.pivotGridField2.Name = "pivotGridField2";
		this.pivotGridField2.Width = 250;
		this.pivotGridField3.AreaIndex = 5;
		this.pivotGridField3.Caption = "LedgerNo";
		this.pivotGridField3.FieldName = "LedgerNo";
		this.pivotGridField3.Name = "pivotGridField3";
		this.pivotGridField4.AreaIndex = 3;
		this.pivotGridField4.Caption = "Responsibility";
		this.pivotGridField4.FieldName = "Responsibility";
		this.pivotGridField4.Name = "pivotGridField4";
		this.pivotGridField5.AreaIndex = 4;
		this.pivotGridField5.Caption = "Qualification";
		this.pivotGridField5.FieldName = "Qualification";
		this.pivotGridField5.Name = "pivotGridField5";
		this.pivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
		this.pivotGridField6.AreaIndex = 2;
		this.pivotGridField6.Caption = "Contact";
		this.pivotGridField6.FieldName = "ContactNumber";
		this.pivotGridField6.Name = "pivotGridField6";
		this.pivotGridField6.Width = 120;
		this.pivotGridField7.AreaIndex = 1;
		this.pivotGridField7.Caption = "Month";
		this.pivotGridField7.FieldName = "Month";
		this.pivotGridField7.Name = "pivotGridField7";
		this.pivotGridField8.AreaIndex = 2;
		this.pivotGridField8.Caption = "Year";
		this.pivotGridField8.FieldName = "Year";
		this.pivotGridField8.Name = "pivotGridField8";
		this.pivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField9.AreaIndex = 0;
		this.pivotGridField9.Caption = "Category";
		this.pivotGridField9.FieldName = "Category";
		this.pivotGridField9.GrandTotalText = "NET PAYc";
		this.pivotGridField9.Name = "pivotGridField9";
		this.pivotGridField10.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
		this.pivotGridField10.AreaIndex = 1;
		this.pivotGridField10.Caption = "Particulars";
		this.pivotGridField10.FieldName = "Particulars";
		this.pivotGridField10.GrandTotalText = "NET PAYp";
		this.pivotGridField10.Name = "pivotGridField10";
		this.pivotGridField10.Width = 150;
		this.pivotGridField11.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
		this.pivotGridField11.AreaIndex = 0;
		this.pivotGridField11.Caption = "Requirements";
		this.pivotGridField11.CellFormat.FormatString = "#,#;#,#";
		this.pivotGridField11.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField11.EmptyCellText = "-";
		this.pivotGridField11.EmptyValueText = "-";
		this.pivotGridField11.FieldName = "Requirements";
		this.pivotGridField11.GrandTotalCellFormat.FormatString = "#,#;#,#";
		this.pivotGridField11.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField11.GrandTotalText = "NET PAY";
		this.pivotGridField11.Name = "pivotGridField11";
		this.pivotGridField11.TotalCellFormat.FormatString = "#,#;#,#";
		this.pivotGridField11.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField11.TotalValueFormat.FormatString = "#,#;#,#";
		this.pivotGridField11.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField11.ValueFormat.FormatString = "#,#;#,#";
		this.pivotGridField11.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.pivotGridField11.Width = 120;
		this.pivotGridField12.AreaIndex = 0;
		this.pivotGridField12.Caption = "PayrollPeriod";
		this.pivotGridField12.FieldName = "PayrollPeriod";
		this.pivotGridField12.Name = "pivotGridField12";
		this.pagePayrollHome.Caption = "pagePayrollHome";
		this.pagePayrollHome.Controls.Add(this.pictureEdit1);
		this.pagePayrollHome.Margin = new System.Windows.Forms.Padding(4);
		this.pagePayrollHome.Name = "pagePayrollHome";
		this.pagePayrollHome.Size = new System.Drawing.Size(1226, 673);
		this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureEdit1.EditValue = I_Xtreme.Properties.Resources.budget_2;
		this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
		this.pictureEdit1.Margin = new System.Windows.Forms.Padding(0);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(1226, 673);
		this.pictureEdit1.TabIndex = 0;
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(1234, 750);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.navigationPayroll;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 69);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(1230, 677);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.lblHeader1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(1230, 38);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem3.Control = this.lblHeader2;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 38);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(1230, 31);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 19f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "usrEmployeePayRole";
		base.Size = new System.Drawing.Size(1234, 750);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.navigationPayroll).EndInit();
		this.navigationPayroll.ResumeLayout(false);
		this.pageReviewPayroll.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pivotGridControl1).EndInit();
		this.pagePayrollHome.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
