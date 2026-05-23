using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.NavigationForms;

public class usrChartOfAccounts : XtraUserControl
{
	private DataSet ds_Accounts;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private MyGridControl gridControl9;

	private MyGridView gridView2;

	private LayoutControlItem layoutControlItem1;

	private System.Windows.Forms.Timer timer1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	public usrChartOfAccounts()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Initializing accounts...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.InitializeChartOfAccounts, 0);
		Thread.Sleep(25);
		InitializeComponent();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	public void ChartOfAccounts()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT at.categoryId AS TypeRef, at.accountName AS AccountGroup, ga.accNo, ga.accName AS Account, gas.subAccountNo, gas.SubAccoutName AS SubAccount FROM  tbl_generalAccounts_Sub AS gas RIGHT OUTER JOIN   tbl_generalAccounts AS ga ON gas.accNo = ga.accNo LEFT OUTER JOIN tbl_account_types AS at ON ga.categoryId = at.categoryId GROUP BY at.categoryId, at.accountName, ga.accName, ga.accNo, gas.subAccountNo, gas.SubAccoutName ORDER BY AccountGroup, ga.accNo", DataConnection.ConnectToDatabase());
			ds_Accounts = new DataSet();
			sqlDataAdapter.Fill(ds_Accounts, "AccCategory");
			gridControl9.DataSource = ds_Accounts.Tables[0].DefaultView;
			PrintableControl.SavePrintableControl(gridControl9);
			ActiveFormSelected.SetActiveForm("List of Accounts");
			timer1.Enabled = false;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public void AccountsCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void usrChartOfAccounts_Load(object sender, EventArgs e)
	{
		ChartOfAccounts();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		ChartOfAccounts();
	}

	private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (e.FocusedRowHandle > -1)
		{
			string accountNo = gridView2.GetRowCellValue(e.FocusedRowHandle, "subAccountNo").ToString();
			string accountName = gridView2.GetRowCellValue(e.FocusedRowHandle, "SubAccount").ToString();
			ChartAccounts.SetSelectedAccount(accountNo, accountName);
		}
	}

	private void gridView2_RowClick(object sender, RowClickEventArgs e)
	{
		if (e.RowHandle > -1)
		{
			string accountNo = gridView2.GetRowCellValue(e.RowHandle, "subAccountNo").ToString();
			string accountName = gridView2.GetRowCellValue(e.RowHandle, "SubAccount").ToString();
			ChartAccounts.SetSelectedAccount(accountNo, accountName);
		}
	}

	private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "SubAccount")
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_generalAccounts_Sub SET SubAccoutName=@SubAccoutName WHERE subAccountNo=@subAccountNo ",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
			sqlParameter.Value = e.Value.ToString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = ChartAccounts.SelectedAccount;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
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
		this.components = new System.ComponentModel.Container();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControl9 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView2 = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.gridControl9);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(860, 545);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControl9.Location = new System.Drawing.Point(3, 3);
		this.gridControl9.MainView = this.gridView2;
		this.gridControl9.Name = "gridControl9";
		this.gridControl9.Size = new System.Drawing.Size(854, 539);
		this.gridControl9.TabIndex = 1;
		this.gridControl9.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridView2.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.EvenRow.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.White;
		this.gridView2.Appearance.GroupRow.BackColor2 = System.Drawing.Color.White;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.OddRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.gridView2.AppearancePrint.GroupRow.Options.UseBackColor = true;
		this.gridView2.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.GroupRow.Options.UseForeColor = true;
		this.gridView2.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView2.AppearancePrint.Lines.BackColor = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.Transparent;
		this.gridView2.AppearancePrint.Lines.Options.UseBackColor = true;
		this.gridView2.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView2.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView2.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView2.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.AppearancePrint.Row.Options.UseFont = true;
		this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6 });
		this.gridView2.DetailHeight = 239;
		this.gridView2.GridControl = this.gridControl9;
		this.gridView2.GroupCount = 2;
		this.gridView2.GroupFormat = "{1}";
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsCustomization.AllowFilter = false;
		this.gridView2.OptionsCustomization.AllowQuickHideColumns = false;
		this.gridView2.OptionsEditForm.PopupEditFormWidth = 533;
		this.gridView2.OptionsMenu.EnableFooterMenu = false;
		this.gridView2.OptionsPrint.PrintGroupFooter = false;
		this.gridView2.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView2.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[2]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending),
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView2_RowClick);
		this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView2_FocusedRowChanged);
		this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView2_CellValueChanged);
		this.gridColumn1.Caption = "CatRef";
		this.gridColumn1.FieldName = "TypeRef";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Account Category";
		this.gridColumn2.FieldName = "AccountGroup";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.OptionsColumn.AllowEdit = false;
		this.gridColumn2.OptionsColumn.ReadOnly = true;
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 0;
		this.gridColumn2.Width = 50;
		this.gridColumn3.Caption = "General Ledger#";
		this.gridColumn3.FieldName = "accNo";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Width = 50;
		this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn4.Caption = "General Account";
		this.gridColumn4.FieldName = "Account";
		this.gridColumn4.MinWidth = 13;
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.OptionsColumn.AllowEdit = false;
		this.gridColumn4.OptionsColumn.ReadOnly = true;
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 2;
		this.gridColumn4.Width = 50;
		this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn5.Caption = "Sub Ledger#";
		this.gridColumn5.FieldName = "subAccountNo";
		this.gridColumn5.MinWidth = 13;
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.OptionsColumn.AllowEdit = false;
		this.gridColumn5.OptionsColumn.ReadOnly = true;
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 0;
		this.gridColumn5.Width = 50;
		this.gridColumn6.Caption = "Sub Account";
		this.gridColumn6.FieldName = "SubAccount";
		this.gridColumn6.MinWidth = 13;
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 1;
		this.gridColumn6.Width = 50;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem1 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
		this.layoutControlGroup1.Size = new System.Drawing.Size(860, 545);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl9;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(858, 543);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrChartOfAccounts";
		base.Size = new System.Drawing.Size(860, 545);
		base.Load += new System.EventHandler(usrChartOfAccounts_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
