using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Accounts;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrBudgetReports : XtraUserControl
{
	private string BudgetItemName = string.Empty;

	private string BudgetItemID = string.Empty;

	private IContainer components = null;

	private NavigationFrame navigationBudget;

	private NavigationPage pageBudgetHome;

	private NavigationPage pageBudgetCreate;

	private MyGridControl gridControl1;

	private MyGridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn colNo;

	private NavigationPage pageBudgetCompare;

	private MyGridControl gridControl2;

	private MyGridView gridView2;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private LayoutControl layoutControl1;

	private LabelControl lblHeader2;

	private LabelControl lblHeader1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private PictureEdit pictureEdit1;

	public usrBudgetReports()
	{
		InitializeComponent();
	}

	public void BudgetFN(string navHeader, string BudgetType, string BudgetPeriod, DataTable dt)
	{
		switch (navHeader)
		{
		case "pageBudgetHome":
			layoutControlItem2.Visibility = LayoutVisibility.Never;
			layoutControlItem3.Visibility = LayoutVisibility.Never;
			navigationBudget.SelectedPage = pageBudgetHome;
			break;
		case "pageBudgetCreate":
			layoutControlItem2.Visibility = LayoutVisibility.Always;
			layoutControlItem3.Visibility = LayoutVisibility.Always;
			gridControl1.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(gridControl1);
			navigationBudget.SelectedPage = pageBudgetCreate;
			lblHeader1.Text = "Budget";
			break;
		case "pageBudgetCompare":
			layoutControlItem2.Visibility = LayoutVisibility.Always;
			layoutControlItem3.Visibility = LayoutVisibility.Always;
			gridControl2.DataSource = dt.DefaultView;
			PrintableControl.SavePrintableControl(gridControl2);
			navigationBudget.SelectedPage = pageBudgetCompare;
			lblHeader1.Text = "Budget Comparison";
			break;
		}
		lblHeader2.Text = BudgetPeriod;
	}

	private void gridView1_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
	{
		EmptyForeGroundCustomDraw.DrawEmptyForeGround(e, "Budget Initialized. Use the 'Add Item' option to add items to the budget");
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (gridView1.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void gridView2_CustomDrawEmptyForeground(object sender, CustomDrawEventArgs e)
	{
		EmptyForeGroundCustomDraw.DrawEmptyForeGround(e, "Nothing to compare. The budget is blank");
	}

	private void gridView1_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1)
		{
			BudgetItemID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "subAccountNo").ToString();
			BudgetItemName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubVote").ToString();
			BudgetItems.SetItemId(BudgetItemID, BudgetItemName);
		}
	}

	private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView1.FocusedRowHandle > -1)
		{
			BudgetItemID = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "subAccountNo").ToString();
			BudgetItemName = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SubVote").ToString();
			BudgetItems.SetItemId(BudgetItemID, BudgetItemName);
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
		this.navigationBudget = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.pageBudgetCreate = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView1 = new AlienAge.CustomGrid.MyGridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.pageBudgetHome = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.pageBudgetCompare = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridControl2 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView2 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.lblHeader2 = new DevExpress.XtraEditors.LabelControl();
		this.lblHeader1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.navigationBudget).BeginInit();
		this.navigationBudget.SuspendLayout();
		this.pageBudgetCreate.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		this.pageBudgetHome.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		this.pageBudgetCompare.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.navigationBudget.Controls.Add(this.pageBudgetCreate);
		this.navigationBudget.Controls.Add(this.pageBudgetHome);
		this.navigationBudget.Controls.Add(this.pageBudgetCompare);
		this.navigationBudget.Location = new System.Drawing.Point(1, 42);
		this.navigationBudget.Name = "navigationBudget";
		this.navigationBudget.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[3] { this.pageBudgetHome, this.pageBudgetCreate, this.pageBudgetCompare });
		this.navigationBudget.SelectedPage = this.pageBudgetHome;
		this.navigationBudget.Size = new System.Drawing.Size(801, 481);
		this.navigationBudget.TabIndex = 0;
		this.navigationBudget.Text = "navigationFrame1";
		this.navigationBudget.TransitionType = DevExpress.Utils.Animation.Transitions.Shape;
		this.pageBudgetCreate.Caption = "pageBudgetCreate";
		this.pageBudgetCreate.Controls.Add(this.gridControl1);
		this.pageBudgetCreate.Name = "pageBudgetCreate";
		this.pageBudgetCreate.Size = new System.Drawing.Size(801, 481);
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(801, 481);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Courier New", 11f, System.Drawing.FontStyle.Bold);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Courier New", 11f);
		this.gridView1.AppearancePrint.Row.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.colNo, this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.GroupCount = 1;
		this.gridView1.GroupFormat = "{1} ({2})";
		this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "{0:#,#.0}")
		});
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsCustomization.AllowColumnMoving = false;
		this.gridView1.OptionsCustomization.AllowFilter = false;
		this.gridView1.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView1.OptionsFind.AlwaysVisible = true;
		this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsPrint.UsePrintStyles = false;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView1.OptionsView.ShowFooter = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView1_RowClick);
		this.gridView1.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gridView1_CustomDrawEmptyForeground);
		this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.colNo.Caption = "#";
		this.colNo.MinWidth = 13;
		this.colNo.Name = "colNo";
		this.colNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
		this.colNo.OptionsColumn.ReadOnly = true;
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 43;
		this.gridColumn1.Caption = "Vote";
		this.gridColumn1.FieldName = "Vote";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Item";
		this.gridColumn2.FieldName = "SubVote";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn2.Width = 356;
		this.gridColumn3.Caption = "Amount";
		this.gridColumn3.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn3.FieldName = "Amount";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,#.0}")
		});
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn3.Width = 357;
		this.pageBudgetHome.Caption = "pageBudgetHome";
		this.pageBudgetHome.Controls.Add(this.pictureEdit1);
		this.pageBudgetHome.Name = "pageBudgetHome";
		this.pageBudgetHome.Size = new System.Drawing.Size(801, 481);
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
		this.pictureEdit1.Size = new System.Drawing.Size(801, 481);
		this.pictureEdit1.TabIndex = 0;
		this.pageBudgetCompare.Caption = "pageBudgetCompare";
		this.pageBudgetCompare.Controls.Add(this.gridControl2);
		this.pageBudgetCompare.Name = "pageBudgetCompare";
		this.pageBudgetCompare.Size = new System.Drawing.Size(801, 481);
		this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl2.Location = new System.Drawing.Point(0, 0);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(801, 481);
		this.gridControl2.TabIndex = 0;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView2.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView2.Appearance.DetailTip.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.DetailTip.Options.UseFont = true;
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView2.Appearance.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FixedLine.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.FixedLine.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupButton.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.GroupButton.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Courier New", 12f, System.Drawing.FontStyle.Bold);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.HorzLine.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.HorzLine.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.RowSeparator.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.Appearance.VertLine.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.VertLine.Options.UseFont = true;
		this.gridView2.Appearance.ViewCaption.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView2.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.gridView2.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.GhostWhite;
		this.gridView2.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.gridView2.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Courier New", 12f, System.Drawing.FontStyle.Bold);
		this.gridView2.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Courier New", 12f, System.Drawing.FontStyle.Bold);
		this.gridView2.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Courier New", 12f, System.Drawing.FontStyle.Bold);
		this.gridView2.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.Lines.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.Lines.Options.UseFont = true;
		this.gridView2.AppearancePrint.OddRow.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.Preview.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView2.AppearancePrint.Row.Font = new System.Drawing.Font("Courier New", 12f);
		this.gridView2.AppearancePrint.Row.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[5] { this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn8, this.gridColumn9 });
		this.gridView2.DetailHeight = 239;
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.GroupCount = 1;
		this.gridView2.GroupFormat = "{1} {2}";
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsCustomization.AllowColumnMoving = false;
		this.gridView2.OptionsCustomization.AllowGroup = false;
		this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView2.OptionsPrint.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsPrint.PrintHorzLines = false;
		this.gridView2.OptionsPrint.UsePrintStyles = false;
		this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView2.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView2.OptionsView.ShowFooter = true;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView2.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(gridView2_CustomDrawEmptyForeground);
		this.gridColumn5.Caption = "Category";
		this.gridColumn5.FieldName = "accName";
		this.gridColumn5.MinWidth = 13;
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 0;
		this.gridColumn5.Width = 50;
		this.gridColumn6.Caption = "Item";
		this.gridColumn6.FieldName = "SubAccoutName";
		this.gridColumn6.MinWidth = 13;
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 0;
		this.gridColumn6.Width = 50;
		this.gridColumn7.Caption = "Budget";
		this.gridColumn7.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn7.FieldName = "Budget";
		this.gridColumn7.MinWidth = 13;
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Budget", "{0:#,#.0}")
		});
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 1;
		this.gridColumn7.Width = 50;
		this.gridColumn8.Caption = "Actual Expense";
		this.gridColumn8.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn8.FieldName = "Actual";
		this.gridColumn8.MinWidth = 13;
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Actual", "{0:#,#.0}")
		});
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 2;
		this.gridColumn8.Width = 50;
		this.gridColumn9.Caption = "Variance";
		this.gridColumn9.DisplayFormat.FormatString = "{0:#,#.0}";
		this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn9.FieldName = "Variance";
		this.gridColumn9.MinWidth = 13;
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Variance", "{0:#,#.0}")
		});
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 3;
		this.gridColumn9.Width = 50;
		this.layoutControl1.Controls.Add(this.lblHeader2);
		this.layoutControl1.Controls.Add(this.lblHeader1);
		this.layoutControl1.Controls.Add(this.navigationBudget);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(803, 524);
		this.layoutControl1.TabIndex = 1;
		this.layoutControl1.Text = "layoutControl1";
		this.lblHeader2.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.lblHeader2.Appearance.Options.UseFont = true;
		this.lblHeader2.Appearance.Options.UseTextOptions = true;
		this.lblHeader2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader2.Location = new System.Drawing.Point(1, 24);
		this.lblHeader2.Name = "lblHeader2";
		this.lblHeader2.Size = new System.Drawing.Size(801, 18);
		this.lblHeader2.StyleController = this.layoutControl1;
		this.lblHeader2.TabIndex = 5;
		this.lblHeader1.Appearance.Font = new System.Drawing.Font("Tahoma", 14f);
		this.lblHeader1.Appearance.Options.UseFont = true;
		this.lblHeader1.Appearance.Options.UseTextOptions = true;
		this.lblHeader1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblHeader1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblHeader1.Location = new System.Drawing.Point(1, 1);
		this.lblHeader1.Name = "lblHeader1";
		this.lblHeader1.Size = new System.Drawing.Size(801, 23);
		this.lblHeader1.StyleController = this.layoutControl1;
		this.lblHeader1.TabIndex = 4;
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(803, 524);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.navigationBudget;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 41);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem1.Size = new System.Drawing.Size(801, 481);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.lblHeader1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem2.Size = new System.Drawing.Size(801, 23);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem3.Control = this.lblHeader2;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 23);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlItem3.Size = new System.Drawing.Size(801, 18);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrBudgetReports";
		base.Size = new System.Drawing.Size(803, 524);
		((System.ComponentModel.ISupportInitialize)this.navigationBudget).EndInit();
		this.navigationBudget.ResumeLayout(false);
		this.pageBudgetCreate.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		this.pageBudgetHome.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		this.pageBudgetCompare.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
	}
}
