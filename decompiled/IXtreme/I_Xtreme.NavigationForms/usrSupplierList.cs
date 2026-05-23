using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme.NavigationForms;

public class usrSupplierList : XtraUserControl
{
	private DataSet dsSuppliers;

	private DataTable dtSuppliers;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private NavBarControl navBarControl1;

	private NavBarGroup navBarGroup1;

	private NavBarItem navBarItem1;

	private NavBarItem navBarItem2;

	private NavBarItem navBarItem3;

	private NavBarItem navBarItem4;

	private NavBarItem navBarItem5;

	private NavBarItem navBarItem6;

	private GroupControl groupControl1;

	private SplitContainerControl splitContainerControl2;

	private MyGridControl gridSupplierLists;

	private MyGridView gridView26;

	private GridColumn gridColumn23;

	private GridColumn gridColumn24;

	private GridColumn gridColumn25;

	private GridColumn gridColumn26;

	private GridColumn gridColumn27;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private GridView gridView1;

	private LabelControl labelControl12;

	private LabelControl lblEmail;

	private LabelControl lblFax;

	private LabelControl lblMobile;

	private LabelControl lblTel;

	private LabelControl labelControl7;

	private LabelControl labelControl6;

	private LabelControl lblFirstName;

	private LabelControl lblName;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	private LabelControl lblCode;

	private LabelControl labelControl5;

	private LabelControl lblNotes;

	private LabelControl lblCity;

	private LabelControl labelControl9;

	private LabelControl lblStreet2;

	private LabelControl lblStreet1;

	private LabelControl labelControl4;

	private GridColumn colNo;

	private System.Windows.Forms.Timer timer1;

	public usrSupplierList()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading Supplier List....");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadSupplierList, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadSupplierList();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadSupplierList()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT  * FROM tbl_Suppliers", selectConnection);
			dsSuppliers = new DataSet();
			sqlDataAdapter.Fill(dsSuppliers, "Suppliers");
			dtSuppliers = new DataTable();
			dtSuppliers = dsSuppliers.Tables[0];
			gridSupplierLists.DataSource = dtSuppliers.DefaultView;
			timer1.Enabled = false;
			PrintableControl.SavePrintableControl(gridSupplierLists);
			PrintableControl.SavePrintableControl(gridView26);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public void SupplierTimerCallBackn(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void gridView26_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridView26.FocusedRowHandle > -1)
		{
			DataRow dataRow = dtSuppliers.Rows[gridView26.GetFocusedDataSourceRowIndex()];
			SupplierOptions.SetActiveSupplier(Convert.ToInt64(dataRow["SupplierCode"]), dataRow["Company"].ToString(), dataRow["Email"].ToString());
			navBarGroup1.Caption = dataRow["Company"].ToString();
			groupControl1.Text = dataRow["Company"].ToString();
			lblCity.Text = dataRow["City"].ToString();
			lblCode.Text = dataRow["SupplierCode"].ToString();
			lblEmail.Text = dataRow["Email"].ToString();
			lblFax.Text = dataRow["Fax"].ToString();
			lblFirstName.Text = dataRow["OtherNames"].ToString();
			lblMobile.Text = dataRow["Mobile"].ToString();
			if (dataRow["Mobile"].ToString() != string.Empty)
			{
				lblName.Text = dataRow["JobTitle"].ToString() + " " + dataRow["Surname"].ToString();
			}
			else
			{
				lblName.Text = dataRow["Surname"].ToString();
			}
			lblNotes.Text = dataRow["Notes"].ToString();
			lblStreet1.Text = dataRow["Street"].ToString();
			lblStreet2.Text = dataRow["Street1"].ToString();
			lblTel.Text = dataRow["Phone"].ToString();
		}
	}

	private void gridView26_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridView26.FocusedRowHandle > -1)
		{
			DataRow dataRow = dtSuppliers.Rows[gridView26.GetFocusedDataSourceRowIndex()];
			SupplierOptions.SetActiveSupplier(Convert.ToInt64(dataRow["SupplierCode"]), dataRow["Company"].ToString(), dataRow["Email"].ToString());
			navBarGroup1.Caption = dataRow["Company"].ToString();
			groupControl1.Text = dataRow["Company"].ToString();
			lblCity.Text = dataRow["City"].ToString();
			lblCode.Text = dataRow["SupplierCode"].ToString();
			lblEmail.Text = dataRow["Email"].ToString();
			lblFax.Text = dataRow["Fax"].ToString();
			lblFirstName.Text = dataRow["OtherNames"].ToString();
			lblMobile.Text = dataRow["Mobile"].ToString();
			if (dataRow["JobTitle"].ToString() != string.Empty)
			{
				lblName.Text = dataRow["JobTitle"].ToString() + " " + dataRow["Surname"].ToString();
			}
			else
			{
				lblName.Text = dataRow["Surname"].ToString();
			}
			lblNotes.Text = dataRow["Notes"].ToString();
			lblStreet1.Text = dataRow["Street"].ToString();
			lblStreet2.Text = dataRow["Street1"].ToString();
			lblTel.Text = dataRow["Phone"].ToString();
		}
	}

	private void gridView26_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo" && e.ListSourceRowIndex > -1 && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (gridView26.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		LoadSupplierList();
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
		this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
		this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
		this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
		this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
		this.gridSupplierLists = new AlienAge.CustomGrid.MyGridControl();
		this.gridView26 = new AlienAge.CustomGrid.MyGridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
		this.lblNotes = new DevExpress.XtraEditors.LabelControl();
		this.lblCity = new DevExpress.XtraEditors.LabelControl();
		this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
		this.lblStreet2 = new DevExpress.XtraEditors.LabelControl();
		this.lblStreet1 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
		this.lblEmail = new DevExpress.XtraEditors.LabelControl();
		this.lblFax = new DevExpress.XtraEditors.LabelControl();
		this.lblMobile = new DevExpress.XtraEditors.LabelControl();
		this.lblTel = new DevExpress.XtraEditors.LabelControl();
		this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
		this.lblFirstName = new DevExpress.XtraEditors.LabelControl();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.lblCode = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.navBarControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).BeginInit();
		this.splitContainerControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLists).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.navBarControl1);
		this.layoutControl1.Controls.Add(this.splitContainerControl2);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(918, 538);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.navBarControl1.ActiveGroup = this.navBarGroup1;
		this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[1] { this.navBarGroup1 });
		this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[6] { this.navBarItem1, this.navBarItem2, this.navBarItem3, this.navBarItem4, this.navBarItem5, this.navBarItem6 });
		this.navBarControl1.Location = new System.Drawing.Point(7, 7);
		this.navBarControl1.Name = "navBarControl1";
		this.navBarControl1.OptionsNavPane.ExpandedWidth = 154;
		this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
		this.navBarControl1.OptionsNavPane.ShowSplitter = false;
		this.navBarControl1.Size = new System.Drawing.Size(154, 524);
		this.navBarControl1.TabIndex = 6;
		this.navBarControl1.Text = "navBarControl1";
		this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
		this.navBarGroup1.Caption = "Company Name";
		this.navBarGroup1.Expanded = true;
		this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[6]
		{
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6)
		});
		this.navBarGroup1.Name = "navBarGroup1";
		this.navBarItem1.Caption = "Edit";
		this.navBarItem1.Name = "navBarItem1";
		this.navBarItem2.Caption = "Delete";
		this.navBarItem2.Name = "navBarItem2";
		this.navBarItem3.Caption = "Receive Invoices";
		this.navBarItem3.Name = "navBarItem3";
		this.navBarItem4.Caption = "Pay Invoices";
		this.navBarItem4.Name = "navBarItem4";
		this.navBarItem5.Caption = "SMS";
		this.navBarItem5.Name = "navBarItem5";
		this.navBarItem6.Caption = "Email";
		this.navBarItem6.Name = "navBarItem6";
		this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
		this.splitContainerControl2.Location = new System.Drawing.Point(165, 7);
		this.splitContainerControl2.Name = "splitContainerControl2";
		this.splitContainerControl2.Panel1.Controls.Add(this.gridSupplierLists);
		this.splitContainerControl2.Panel1.Text = "Panel1";
		this.splitContainerControl2.Panel2.Controls.Add(this.groupControl1);
		this.splitContainerControl2.Panel2.Text = "Panel2";
		this.splitContainerControl2.Size = new System.Drawing.Size(746, 524);
		this.splitContainerControl2.SplitterPosition = 182;
		this.splitContainerControl2.TabIndex = 4;
		this.splitContainerControl2.Text = "splitContainerControl2";
		this.gridSupplierLists.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridSupplierLists.Location = new System.Drawing.Point(0, 0);
		this.gridSupplierLists.MainView = this.gridView26;
		this.gridSupplierLists.Name = "gridSupplierLists";
		this.gridSupplierLists.Size = new System.Drawing.Size(559, 524);
		this.gridSupplierLists.TabIndex = 5;
		this.gridSupplierLists.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[2] { this.gridView26, this.gridView1 });
		this.gridView26.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.Empty.Options.UseFont = true;
		this.gridView26.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView26.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView26.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView26.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView26.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView26.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView26.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView26.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView26.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView26.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView26.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.GroupRow.Options.UseFont = true;
		this.gridView26.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView26.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView26.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView26.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView26.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView26.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.Preview.Options.UseFont = true;
		this.gridView26.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.Row.Options.UseFont = true;
		this.gridView26.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView26.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView26.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView26.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridView26.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView26.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridView26.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridView26.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridView26.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridView26.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridView26.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridView26.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridView26.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.Preview.Options.UseFont = true;
		this.gridView26.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView26.AppearancePrint.Row.Options.UseFont = true;
		this.gridView26.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[6] { this.colNo, this.gridColumn23, this.gridColumn24, this.gridColumn25, this.gridColumn26, this.gridColumn27 });
		this.gridView26.GridControl = this.gridSupplierLists;
		this.gridView26.IndicatorWidth = 35;
		this.gridView26.Name = "gridView26";
		this.gridView26.OptionsBehavior.Editable = false;
		this.gridView26.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView26.OptionsFind.AlwaysVisible = true;
		this.gridView26.OptionsPrint.PrintHorzLines = false;
		this.gridView26.OptionsView.ShowGroupPanel = false;
		this.gridView26.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView26.OptionsView.ShowIndicator = false;
		this.gridView26.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView26_RowClick);
		this.gridView26.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView26_FocusedRowChanged);
		this.gridView26.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView26_CustomColumnDisplayText);
		this.colNo.Caption = "#";
		this.colNo.Name = "colNo";
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 30;
		this.gridColumn23.Caption = "Supplier Code";
		this.gridColumn23.FieldName = "SupplierCode";
		this.gridColumn23.Name = "gridColumn23";
		this.gridColumn24.Caption = "Company";
		this.gridColumn24.FieldName = "Company";
		this.gridColumn24.Name = "gridColumn24";
		this.gridColumn24.Visible = true;
		this.gridColumn24.VisibleIndex = 1;
		this.gridColumn24.Width = 128;
		this.gridColumn25.Caption = "Phone#";
		this.gridColumn25.FieldName = "Phone";
		this.gridColumn25.Name = "gridColumn25";
		this.gridColumn25.Visible = true;
		this.gridColumn25.VisibleIndex = 2;
		this.gridColumn25.Width = 128;
		this.gridColumn26.Caption = "Mobile#";
		this.gridColumn26.FieldName = "Mobile";
		this.gridColumn26.Name = "gridColumn26";
		this.gridColumn26.Visible = true;
		this.gridColumn26.VisibleIndex = 3;
		this.gridColumn26.Width = 128;
		this.gridColumn27.Caption = "Email";
		this.gridColumn27.FieldName = "Email";
		this.gridColumn27.Name = "gridColumn27";
		this.gridColumn27.Visible = true;
		this.gridColumn27.VisibleIndex = 4;
		this.gridColumn27.Width = 134;
		this.gridView1.GridControl = this.gridSupplierLists;
		this.gridView1.Name = "gridView1";
		this.groupControl1.Controls.Add(this.labelControl5);
		this.groupControl1.Controls.Add(this.lblNotes);
		this.groupControl1.Controls.Add(this.lblCity);
		this.groupControl1.Controls.Add(this.labelControl9);
		this.groupControl1.Controls.Add(this.lblStreet2);
		this.groupControl1.Controls.Add(this.lblStreet1);
		this.groupControl1.Controls.Add(this.labelControl4);
		this.groupControl1.Controls.Add(this.labelControl12);
		this.groupControl1.Controls.Add(this.lblEmail);
		this.groupControl1.Controls.Add(this.lblFax);
		this.groupControl1.Controls.Add(this.lblMobile);
		this.groupControl1.Controls.Add(this.lblTel);
		this.groupControl1.Controls.Add(this.labelControl7);
		this.groupControl1.Controls.Add(this.labelControl6);
		this.groupControl1.Controls.Add(this.lblFirstName);
		this.groupControl1.Controls.Add(this.lblName);
		this.groupControl1.Controls.Add(this.labelControl3);
		this.groupControl1.Controls.Add(this.labelControl2);
		this.groupControl1.Controls.Add(this.lblCode);
		this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupControl1.Location = new System.Drawing.Point(0, 0);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(182, 524);
		this.groupControl1.TabIndex = 7;
		this.groupControl1.Text = "Company Name";
		this.labelControl5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl5.Visible = true;
		this.labelControl5.Location = new System.Drawing.Point(40, 356);
		this.labelControl5.Name = "labelControl5";
		this.labelControl5.Size = new System.Drawing.Size(137, 10);
		this.labelControl5.TabIndex = 18;
		this.lblNotes.Location = new System.Drawing.Point(6, 372);
		this.lblNotes.Name = "lblNotes";
		this.lblNotes.Size = new System.Drawing.Size(0, 13);
		this.lblNotes.TabIndex = 17;
		this.lblCity.Location = new System.Drawing.Point(6, 286);
		this.lblCity.Name = "lblCity";
		this.lblCity.Size = new System.Drawing.Size(0, 13);
		this.lblCity.TabIndex = 16;
		this.labelControl9.Location = new System.Drawing.Point(6, 353);
		this.labelControl9.Name = "labelControl9";
		this.labelControl9.Size = new System.Drawing.Size(28, 13);
		this.labelControl9.TabIndex = 15;
		this.labelControl9.Text = "Notes";
		this.lblStreet2.Location = new System.Drawing.Point(6, 324);
		this.lblStreet2.Name = "lblStreet2";
		this.lblStreet2.Size = new System.Drawing.Size(0, 13);
		this.lblStreet2.TabIndex = 14;
		this.lblStreet1.Location = new System.Drawing.Point(6, 305);
		this.lblStreet1.Name = "lblStreet1";
		this.lblStreet1.Size = new System.Drawing.Size(0, 13);
		this.lblStreet1.TabIndex = 13;
		this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl4.Visible = true;
		this.labelControl4.Location = new System.Drawing.Point(50, 255);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Size = new System.Drawing.Size(127, 10);
		this.labelControl4.TabIndex = 12;
		this.labelControl12.Location = new System.Drawing.Point(6, 255);
		this.labelControl12.Name = "labelControl12";
		this.labelControl12.Size = new System.Drawing.Size(39, 13);
		this.labelControl12.TabIndex = 11;
		this.labelControl12.Text = "Address";
		this.lblEmail.Location = new System.Drawing.Point(6, 187);
		this.lblEmail.Name = "lblEmail";
		this.lblEmail.Size = new System.Drawing.Size(0, 13);
		this.lblEmail.TabIndex = 10;
		this.lblFax.Location = new System.Drawing.Point(6, 168);
		this.lblFax.Name = "lblFax";
		this.lblFax.Size = new System.Drawing.Size(0, 13);
		this.lblFax.TabIndex = 9;
		this.lblMobile.Location = new System.Drawing.Point(6, 148);
		this.lblMobile.Name = "lblMobile";
		this.lblMobile.Size = new System.Drawing.Size(0, 13);
		this.lblMobile.TabIndex = 8;
		this.lblTel.Location = new System.Drawing.Point(6, 128);
		this.lblTel.Name = "lblTel";
		this.lblTel.Size = new System.Drawing.Size(0, 13);
		this.lblTel.TabIndex = 7;
		this.labelControl7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl7.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
		this.labelControl7.Visible = true;
		this.labelControl7.Location = new System.Drawing.Point(50, 110);
		this.labelControl7.Name = "labelControl7";
		this.labelControl7.Size = new System.Drawing.Size(127, 10);
		this.labelControl7.TabIndex = 6;
		this.labelControl6.Location = new System.Drawing.Point(6, 109);
		this.labelControl6.Name = "labelControl6";
		this.labelControl6.Size = new System.Drawing.Size(38, 13);
		this.labelControl6.TabIndex = 5;
		this.labelControl6.Text = "Contact";
		this.lblFirstName.Location = new System.Drawing.Point(6, 76);
		this.lblFirstName.Name = "lblFirstName";
		this.lblFirstName.Size = new System.Drawing.Size(0, 13);
		this.lblFirstName.TabIndex = 4;
		this.lblName.Location = new System.Drawing.Point(6, 56);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(0, 13);
		this.lblName.TabIndex = 3;
		this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
		this.labelControl3.Visible = true;
		this.labelControl3.Location = new System.Drawing.Point(85, 38);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Size = new System.Drawing.Size(92, 10);
		this.labelControl3.TabIndex = 2;
		this.labelControl2.Location = new System.Drawing.Point(6, 37);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(74, 13);
		this.labelControl2.TabIndex = 1;
		this.labelControl2.Text = "Contact Person";
		this.lblCode.Location = new System.Drawing.Point(8, 418);
		this.lblCode.Name = "lblCode";
		this.lblCode.Size = new System.Drawing.Size(0, 13);
		this.lblCode.TabIndex = 0;
		this.lblCode.Visible = false;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem1, this.layoutControlItem2 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
		this.layoutControlGroup1.Size = new System.Drawing.Size(918, 538);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.splitContainerControl2;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(158, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(750, 528);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.navBarControl1;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(158, 528);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrSupplierList";
		base.Size = new System.Drawing.Size(918, 538);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.navBarControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).EndInit();
		this.splitContainerControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridSupplierLists).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		this.groupControl1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		base.ResumeLayout(false);
	}
}
