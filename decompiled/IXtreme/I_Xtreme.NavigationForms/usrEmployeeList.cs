using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using I_Xtreme.DialogForms;

namespace I_Xtreme.NavigationForms;

public class usrEmployeeList : XtraUserControl
{
	private DataSet ds_Staff;

	private DataTable dt_Staff;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private MyGridControl dgRecords_emp;

	private MyGridView gridViewEmployees;

	private LayoutControlItem layoutControlItem1;

	private PanelControl panelControl2;

	private LabelControl lblEHouse;

	private LabelControl lblECountry;

	private LabelControl lblEPostalAddress;

	private LabelControl lblEEmail;

	private LabelControl lblEAddress;

	private LabelControl lblEPhone;

	private LabelControl lblEMobile;

	private LabelControl lblEStaffNumber;

	private LabelControl labelControl171;

	private LabelControl labelControl169;

	private LabelControl labelControl168;

	private LabelControl labelControl167;

	private LabelControl labelControl164;

	private LabelControl labelControl162;

	private LabelControl labelControl155;

	private LabelControl labelControl151;

	private LabelControl lblEName;

	private PictureEdit pictureEdit9;

	private LayoutControlItem layoutControlItem2;

	private PopupMenu popupMenu1;

	private BarManager barManager1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private NavBarControl navBarControl1;

	private NavBarGroup navBarGroup1;

	private NavBarItem navBarItem1;

	private NavBarItem navBarItem2;

	private NavBarItem navBarItem3;

	private LayoutControlItem layoutControlItem3;

	private GridColumn colNo;

	private GridColumn colStaffId;

	private GridColumn colLastName;

	private GridColumn colSex;

	private GridColumn colResponsibility;

	private GridColumn colstatus;

	private GridColumn gridWorkingStatus;

	private System.Windows.Forms.Timer timer1;

	private XtraTabControl xtraTabControl1;

	private XtraTabPage xtraTabPage1;

	private XtraTabPage xtraTabPage2;

	private LabelControl lblEStatus;

	private LabelControl labelControl172;

	private LabelControl lblEHireDate;

	private LabelControl lblEResponsibility;

	private LabelControl labelControl161;

	private LabelControl labelControl163;

	private GridColumn gridColumn1;

	public usrEmployeeList()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading Employee List....");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadEmployeeList, 0);
		Thread.Sleep(25);
		InitializeComponent();
		EmployeeList();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	public void EmployeeCallBackFN(bool timerStatus)
	{
		timer1.Enabled = timerStatus;
	}

	private void gridViewEmployees_ColumnFilterChanged(object sender, EventArgs e)
	{
		gridViewEmployees.FocusedRowHandle = -1;
	}

	private void EmployeeList()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Staff", selectConnection);
			ds_Staff = new DataSet();
			sqlDataAdapter.Fill(ds_Staff, "staffList");
			dt_Staff = new DataTable();
			dt_Staff = ds_Staff.Tables["staffList"];
			dgRecords_emp.DataSource = dt_Staff;
			timer1.Enabled = false;
			PrintableControl.SavePrintableControl(dgRecords_emp);
			PrintableControl.SavePrintableControl(gridViewEmployees);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void gridViewEmployees_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo")
		{
			e.DisplayText = (gridViewEmployees.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void gridViewEmployees_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridViewEmployees.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt_Staff.Rows[gridViewEmployees.GetFocusedDataSourceRowIndex()];
			byte[] array = new byte[0];
			array = (byte[])dataRow["Pic"];
			using (MemoryStream stream = new MemoryStream(array))
			{
				pictureEdit9.Image = Image.FromStream(stream);
			}
			lblEName.Text = dataRow["StaffName"].ToString();
			lblEAddress.Text = dataRow["Address"].ToString();
			lblECountry.Text = dataRow["Country"].ToString();
			lblEEmail.Text = dataRow["Email"].ToString();
			lblEHireDate.Text = Convert.ToDateTime(dataRow["DateOfHire"].ToString()).ToString("dd-MMM-yy");
			lblEHouse.Text = dataRow["HouseId"].ToString();
			lblEMobile.Text = dataRow["ContactNumber"].ToString();
			lblEPhone.Text = dataRow["HomePhone"].ToString();
			lblEPostalAddress.Text = dataRow["PostalAddress"].ToString();
			lblEResponsibility.Text = dataRow["Responsibility"].ToString();
			lblEStaffNumber.Text = dataRow["StaffId"].ToString();
			lblEStatus.Text = dataRow["WorkingStatus"].ToString();
			StaffOptions.SetActiveStaff(dataRow["StaffId"].ToString(), dataRow["Email"].ToString(), dataRow["StaffName"].ToString());
			navBarGroup1.Caption = StaffOptions.ActiveStaffName().ToUpper();
		}
	}

	private void gridViewEmployees_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Apps)
		{
			popupMenu1.ShowCaption = true;
			DataRow dataRow = dt_Staff.Rows[gridViewEmployees.GetFocusedDataSourceRowIndex()];
			popupMenu1.MenuCaption = dataRow["StaffName"].ToString();
			popupMenu1.ShowPopup(Control.MousePosition);
		}
		else
		{
			popupMenu1.HidePopup();
		}
	}

	private void gridViewEmployees_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridViewEmployees.FocusedRowHandle > -1)
		{
			if (e.Button == MouseButtons.Right)
			{
				popupMenu1.ShowCaption = true;
				DataRow dataRow = dt_Staff.Rows[gridViewEmployees.GetFocusedDataSourceRowIndex()];
				popupMenu1.MenuCaption = dataRow["StaffName"].ToString();
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		using EmployeeAdmission employeeAdmission = new EmployeeAdmission("MainForm", string.Empty);
		DataRow dataRow = dt_Staff.Rows[gridViewEmployees.GetFocusedDataSourceRowIndex()];
		employeeAdmission.txtStaffNumber.Text = dataRow["StaffId"].ToString();
		employeeAdmission.txtStaffNumber.Properties.ReadOnly = true;
		employeeAdmission.Text = "Edit Employee details";
		if (employeeAdmission.ShowDialog() == DialogResult.OK)
		{
			EmployeeList();
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (gridViewEmployees.FocusedRowHandle > -1)
		{
			using (ConfirmDelete confirmDelete = new ConfirmDelete())
			{
				confirmDelete.lblDeleteWhat.Text = "employee";
				confirmDelete.StartTimer = EmployeeCallBackFN;
				confirmDelete.ShowDialog();
			}
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		EmployeeList();
	}

	private void panelControl2_Paint(object sender, PaintEventArgs e)
	{
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
		this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
		this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
		this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
		this.labelControl171 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl151 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl155 = new DevExpress.XtraEditors.LabelControl();
		this.lblEHouse = new DevExpress.XtraEditors.LabelControl();
		this.labelControl162 = new DevExpress.XtraEditors.LabelControl();
		this.lblECountry = new DevExpress.XtraEditors.LabelControl();
		this.lblEPostalAddress = new DevExpress.XtraEditors.LabelControl();
		this.labelControl164 = new DevExpress.XtraEditors.LabelControl();
		this.lblEEmail = new DevExpress.XtraEditors.LabelControl();
		this.labelControl167 = new DevExpress.XtraEditors.LabelControl();
		this.lblEAddress = new DevExpress.XtraEditors.LabelControl();
		this.labelControl168 = new DevExpress.XtraEditors.LabelControl();
		this.lblEPhone = new DevExpress.XtraEditors.LabelControl();
		this.labelControl169 = new DevExpress.XtraEditors.LabelControl();
		this.lblEMobile = new DevExpress.XtraEditors.LabelControl();
		this.lblEStaffNumber = new DevExpress.XtraEditors.LabelControl();
		this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
		this.lblEStatus = new DevExpress.XtraEditors.LabelControl();
		this.labelControl172 = new DevExpress.XtraEditors.LabelControl();
		this.lblEHireDate = new DevExpress.XtraEditors.LabelControl();
		this.lblEResponsibility = new DevExpress.XtraEditors.LabelControl();
		this.labelControl161 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl163 = new DevExpress.XtraEditors.LabelControl();
		this.lblEName = new DevExpress.XtraEditors.LabelControl();
		this.pictureEdit9 = new DevExpress.XtraEditors.PictureEdit();
		this.dgRecords_emp = new AlienAge.CustomGrid.MyGridControl();
		this.gridViewEmployees = new AlienAge.CustomGrid.MyGridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colResponsibility = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridWorkingStatus = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.navBarControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl2).BeginInit();
		this.panelControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
		this.xtraTabControl1.SuspendLayout();
		this.xtraTabPage1.SuspendLayout();
		this.xtraTabPage2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit9.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgRecords_emp).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewEmployees).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.navBarControl1);
		this.layoutControl1.Controls.Add(this.panelControl2);
		this.layoutControl1.Controls.Add(this.dgRecords_emp);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(771, 520);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.navBarControl1.ActiveGroup = this.navBarGroup1;
		this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[1] { this.navBarGroup1 });
		this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[3] { this.navBarItem1, this.navBarItem2, this.navBarItem3 });
		this.navBarControl1.Location = new System.Drawing.Point(4, 4);
		this.navBarControl1.Name = "navBarControl1";
		this.navBarControl1.OptionsNavPane.ExpandedWidth = 119;
		this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
		this.navBarControl1.OptionsNavPane.ShowSplitter = false;
		this.navBarControl1.Size = new System.Drawing.Size(119, 512);
		this.navBarControl1.TabIndex = 6;
		this.navBarControl1.Text = "navBarControl1";
		this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
		this.navBarGroup1.Caption = "Employee Details";
		this.navBarGroup1.Expanded = true;
		this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[3]
		{
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3)
		});
		this.navBarGroup1.Name = "navBarGroup1";
		this.navBarItem1.Caption = "Edit";
		this.navBarItem1.Name = "navBarItem1";
		this.navBarItem2.Caption = "Delete";
		this.navBarItem2.Name = "navBarItem2";
		this.navBarItem3.Caption = "Ledger";
		this.navBarItem3.Name = "navBarItem3";
		this.panelControl2.Controls.Add(this.xtraTabControl1);
		this.panelControl2.Controls.Add(this.lblEName);
		this.panelControl2.Controls.Add(this.pictureEdit9);
		this.panelControl2.Location = new System.Drawing.Point(601, 4);
		this.panelControl2.Name = "panelControl2";
		this.panelControl2.Size = new System.Drawing.Size(166, 512);
		this.panelControl2.TabIndex = 5;
		this.panelControl2.Paint += new System.Windows.Forms.PaintEventHandler(panelControl2_Paint);
		this.xtraTabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
		this.xtraTabControl1.Location = new System.Drawing.Point(2, 307);
		this.xtraTabControl1.Name = "xtraTabControl1";
		this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
		this.xtraTabControl1.Size = new System.Drawing.Size(159, 200);
		this.xtraTabControl1.TabIndex = 28;
		this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[2] { this.xtraTabPage1, this.xtraTabPage2 });
		this.xtraTabPage1.Controls.Add(this.labelControl171);
		this.xtraTabPage1.Controls.Add(this.labelControl151);
		this.xtraTabPage1.Controls.Add(this.labelControl155);
		this.xtraTabPage1.Controls.Add(this.lblEHouse);
		this.xtraTabPage1.Controls.Add(this.labelControl162);
		this.xtraTabPage1.Controls.Add(this.lblECountry);
		this.xtraTabPage1.Controls.Add(this.lblEPostalAddress);
		this.xtraTabPage1.Controls.Add(this.labelControl164);
		this.xtraTabPage1.Controls.Add(this.lblEEmail);
		this.xtraTabPage1.Controls.Add(this.labelControl167);
		this.xtraTabPage1.Controls.Add(this.lblEAddress);
		this.xtraTabPage1.Controls.Add(this.labelControl168);
		this.xtraTabPage1.Controls.Add(this.lblEPhone);
		this.xtraTabPage1.Controls.Add(this.labelControl169);
		this.xtraTabPage1.Controls.Add(this.lblEMobile);
		this.xtraTabPage1.Controls.Add(this.lblEStaffNumber);
		this.xtraTabPage1.Name = "xtraTabPage1";
		this.xtraTabPage1.Size = new System.Drawing.Size(134, 198);
		this.xtraTabPage1.Text = "Biodata";
		this.labelControl171.Location = new System.Drawing.Point(10, 7);
		this.labelControl171.Name = "labelControl171";
		this.labelControl171.Size = new System.Drawing.Size(32, 13);
		this.labelControl171.TabIndex = 14;
		this.labelControl171.Text = "Staff #";
		this.labelControl151.Location = new System.Drawing.Point(10, 123);
		this.labelControl151.Name = "labelControl151";
		this.labelControl151.Size = new System.Drawing.Size(28, 13);
		this.labelControl151.TabIndex = 2;
		this.labelControl151.Text = "Email:";
		this.labelControl155.Location = new System.Drawing.Point(10, 140);
		this.labelControl155.Name = "labelControl155";
		this.labelControl155.Size = new System.Drawing.Size(42, 13);
		this.labelControl155.TabIndex = 3;
		this.labelControl155.Text = "Postal #:";
		this.lblEHouse.Location = new System.Drawing.Point(64, 175);
		this.lblEHouse.Name = "lblEHouse";
		this.lblEHouse.Size = new System.Drawing.Size(0, 13);
		this.lblEHouse.TabIndex = 24;
		this.labelControl162.Location = new System.Drawing.Point(10, 156);
		this.labelControl162.Name = "labelControl162";
		this.labelControl162.Size = new System.Drawing.Size(39, 13);
		this.labelControl162.TabIndex = 5;
		this.labelControl162.Text = "Country:";
		this.lblECountry.Location = new System.Drawing.Point(64, 157);
		this.lblECountry.Name = "lblECountry";
		this.lblECountry.Size = new System.Drawing.Size(0, 13);
		this.lblECountry.TabIndex = 23;
		this.lblEPostalAddress.Location = new System.Drawing.Point(64, 141);
		this.lblEPostalAddress.Name = "lblEPostalAddress";
		this.lblEPostalAddress.Size = new System.Drawing.Size(0, 13);
		this.lblEPostalAddress.TabIndex = 22;
		this.labelControl164.Location = new System.Drawing.Point(10, 174);
		this.labelControl164.Name = "labelControl164";
		this.labelControl164.Size = new System.Drawing.Size(34, 13);
		this.labelControl164.TabIndex = 7;
		this.labelControl164.Text = "House:";
		this.lblEEmail.Location = new System.Drawing.Point(64, 124);
		this.lblEEmail.Name = "lblEEmail";
		this.lblEEmail.Size = new System.Drawing.Size(0, 13);
		this.lblEEmail.TabIndex = 21;
		this.labelControl167.Location = new System.Drawing.Point(10, 106);
		this.labelControl167.Name = "labelControl167";
		this.labelControl167.Size = new System.Drawing.Size(41, 13);
		this.labelControl167.TabIndex = 10;
		this.labelControl167.Text = "Address:";
		this.lblEAddress.Location = new System.Drawing.Point(64, 107);
		this.lblEAddress.Name = "lblEAddress";
		this.lblEAddress.Size = new System.Drawing.Size(0, 13);
		this.lblEAddress.TabIndex = 20;
		this.labelControl168.Location = new System.Drawing.Point(10, 74);
		this.labelControl168.Name = "labelControl168";
		this.labelControl168.Size = new System.Drawing.Size(44, 13);
		this.labelControl168.TabIndex = 11;
		this.labelControl168.Text = "Phone #:";
		this.lblEPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblEPhone.Appearance.Options.UseFont = true;
		this.lblEPhone.Location = new System.Drawing.Point(10, 91);
		this.lblEPhone.Name = "lblEPhone";
		this.lblEPhone.Size = new System.Drawing.Size(0, 13);
		this.lblEPhone.TabIndex = 19;
		this.labelControl169.Location = new System.Drawing.Point(10, 40);
		this.labelControl169.Name = "labelControl169";
		this.labelControl169.Size = new System.Drawing.Size(44, 13);
		this.labelControl169.TabIndex = 12;
		this.labelControl169.Text = "Mobile #:";
		this.lblEMobile.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblEMobile.Appearance.Options.UseFont = true;
		this.lblEMobile.Location = new System.Drawing.Point(10, 57);
		this.lblEMobile.Name = "lblEMobile";
		this.lblEMobile.Size = new System.Drawing.Size(0, 16);
		this.lblEMobile.TabIndex = 18;
		this.lblEStaffNumber.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblEStaffNumber.Appearance.Options.UseFont = true;
		this.lblEStaffNumber.Location = new System.Drawing.Point(10, 23);
		this.lblEStaffNumber.Name = "lblEStaffNumber";
		this.lblEStaffNumber.Size = new System.Drawing.Size(0, 16);
		this.lblEStaffNumber.TabIndex = 16;
		this.xtraTabPage2.Controls.Add(this.lblEStatus);
		this.xtraTabPage2.Controls.Add(this.labelControl172);
		this.xtraTabPage2.Controls.Add(this.lblEHireDate);
		this.xtraTabPage2.Controls.Add(this.lblEResponsibility);
		this.xtraTabPage2.Controls.Add(this.labelControl161);
		this.xtraTabPage2.Controls.Add(this.labelControl163);
		this.xtraTabPage2.Name = "xtraTabPage2";
		this.xtraTabPage2.Size = new System.Drawing.Size(134, 198);
		this.xtraTabPage2.Text = "Appoint Info";
		this.lblEStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblEStatus.Appearance.Options.UseFont = true;
		this.lblEStatus.Location = new System.Drawing.Point(13, 106);
		this.lblEStatus.Name = "lblEStatus";
		this.lblEStatus.Size = new System.Drawing.Size(0, 16);
		this.lblEStatus.TabIndex = 32;
		this.labelControl172.Location = new System.Drawing.Point(13, 88);
		this.labelControl172.Name = "labelControl172";
		this.labelControl172.Size = new System.Drawing.Size(30, 13);
		this.labelControl172.TabIndex = 31;
		this.labelControl172.Text = "Status";
		this.lblEHireDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblEHireDate.Appearance.Options.UseFont = true;
		this.lblEHireDate.Location = new System.Drawing.Point(13, 67);
		this.lblEHireDate.Name = "lblEHireDate";
		this.lblEHireDate.Size = new System.Drawing.Size(0, 16);
		this.lblEHireDate.TabIndex = 30;
		this.lblEResponsibility.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblEResponsibility.Appearance.Options.UseFont = true;
		this.lblEResponsibility.Location = new System.Drawing.Point(13, 28);
		this.lblEResponsibility.Name = "lblEResponsibility";
		this.lblEResponsibility.Size = new System.Drawing.Size(0, 16);
		this.lblEResponsibility.TabIndex = 29;
		this.labelControl161.Location = new System.Drawing.Point(13, 10);
		this.labelControl161.Name = "labelControl161";
		this.labelControl161.Size = new System.Drawing.Size(64, 13);
		this.labelControl161.TabIndex = 27;
		this.labelControl161.Text = "Responsibility";
		this.labelControl163.Location = new System.Drawing.Point(13, 49);
		this.labelControl163.Name = "labelControl163";
		this.labelControl163.Size = new System.Drawing.Size(45, 13);
		this.labelControl163.TabIndex = 28;
		this.labelControl163.Text = "Hire Date";
		this.lblEName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.lblEName.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.lblEName.Appearance.Options.UseFont = true;
		this.lblEName.Appearance.Options.UseTextOptions = true;
		this.lblEName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblEName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblEName.Location = new System.Drawing.Point(5, 6);
		this.lblEName.Name = "lblEName";
		this.lblEName.Size = new System.Drawing.Size(156, 19);
		this.lblEName.TabIndex = 1;
		this.pictureEdit9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pictureEdit9.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureEdit9.Location = new System.Drawing.Point(5, 30);
		this.pictureEdit9.Name = "pictureEdit9";
		this.pictureEdit9.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit9.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.pictureEdit9.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit9.Size = new System.Drawing.Size(156, 271);
		this.pictureEdit9.TabIndex = 0;
		this.dgRecords_emp.Location = new System.Drawing.Point(127, 4);
		this.dgRecords_emp.MainView = this.gridViewEmployees;
		this.dgRecords_emp.Name = "dgRecords_emp";
		this.dgRecords_emp.Size = new System.Drawing.Size(470, 512);
		this.dgRecords_emp.TabIndex = 1;
		this.dgRecords_emp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewEmployees });
		this.gridViewEmployees.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridViewEmployees.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.Empty.Options.UseFont = true;
		this.gridViewEmployees.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.FilterPanel.Options.UseFont = true;
		this.gridViewEmployees.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmployees.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewEmployees.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridViewEmployees.Appearance.FocusedCell.Options.UseFont = true;
		this.gridViewEmployees.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmployees.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridViewEmployees.Appearance.FocusedRow.Options.UseFont = true;
		this.gridViewEmployees.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.FooterPanel.Options.UseFont = true;
		this.gridViewEmployees.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.GroupFooter.Options.UseFont = true;
		this.gridViewEmployees.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.GroupRow.Options.UseFont = true;
		this.gridViewEmployees.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewEmployees.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridViewEmployees.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewEmployees.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridViewEmployees.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.Preview.Options.UseFont = true;
		this.gridViewEmployees.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.Row.Options.UseFont = true;
		this.gridViewEmployees.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridViewEmployees.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridViewEmployees.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridViewEmployees.Appearance.SelectedRow.Options.UseFont = true;
		this.gridViewEmployees.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.Appearance.TopNewRow.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.Lines.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.OddRow.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.Preview.Options.UseFont = true;
		this.gridViewEmployees.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.gridViewEmployees.AppearancePrint.Row.Options.UseFont = true;
		this.gridViewEmployees.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[8] { this.colNo, this.colLastName, this.colStaffId, this.colSex, this.colResponsibility, this.colstatus, this.gridWorkingStatus, this.gridColumn1 });
		this.gridViewEmployees.GridControl = this.dgRecords_emp;
		this.gridViewEmployees.IndicatorWidth = 35;
		this.gridViewEmployees.Name = "gridViewEmployees";
		this.gridViewEmployees.OptionsBehavior.Editable = false;
		this.gridViewEmployees.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridViewEmployees.OptionsFind.AlwaysVisible = true;
		this.gridViewEmployees.OptionsPrint.PrintHorzLines = false;
		this.gridViewEmployees.OptionsView.ShowGroupPanel = false;
		this.gridViewEmployees.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewEmployees.OptionsView.ShowIndicator = false;
		this.gridViewEmployees.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridViewEmployees_RowClick);
		this.gridViewEmployees.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewEmployees_FocusedRowChanged);
		this.gridViewEmployees.ColumnFilterChanged += new System.EventHandler(gridViewEmployees_ColumnFilterChanged);
		this.gridViewEmployees.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridViewEmployees_CustomColumnDisplayText);
		this.gridViewEmployees.KeyDown += new System.Windows.Forms.KeyEventHandler(gridViewEmployees_KeyDown);
		this.colNo.Caption = "#";
		this.colNo.Name = "colNo";
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 68;
		this.colLastName.Caption = "Name";
		this.colLastName.FieldName = "StaffName";
		this.colLastName.Name = "colLastName";
		this.colLastName.Visible = true;
		this.colLastName.VisibleIndex = 2;
		this.colLastName.Width = 221;
		this.colStaffId.Caption = "Staff#";
		this.colStaffId.FieldName = "StaffId";
		this.colStaffId.Name = "colStaffId";
		this.colStaffId.Visible = true;
		this.colStaffId.VisibleIndex = 1;
		this.colStaffId.Width = 221;
		this.colSex.Caption = "Sex";
		this.colSex.FieldName = "Sex";
		this.colSex.Name = "colSex";
		this.colSex.Visible = true;
		this.colSex.VisibleIndex = 3;
		this.colSex.Width = 58;
		this.colResponsibility.Caption = "Responsibility";
		this.colResponsibility.FieldName = "Responsibility";
		this.colResponsibility.Name = "colResponsibility";
		this.colResponsibility.Width = 251;
		this.colstatus.Caption = "Status";
		this.colstatus.FieldName = "status";
		this.colstatus.Name = "colstatus";
		this.colstatus.Width = 195;
		this.gridWorkingStatus.Caption = "Empl. Type";
		this.gridWorkingStatus.FieldName = "WorkingStatus";
		this.gridWorkingStatus.Name = "gridWorkingStatus";
		this.gridWorkingStatus.Visible = true;
		this.gridWorkingStatus.VisibleIndex = 4;
		this.gridWorkingStatus.Width = 303;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(771, 520);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.dgRecords_emp;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(123, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(474, 516);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.panelControl2;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(597, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(170, 516);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.navBarControl1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(123, 516);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)
		});
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		this.barButtonItem1.Caption = "Edit/View";
		this.barButtonItem1.Id = 0;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Delete";
		this.barButtonItem2.Id = 1;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[2] { this.barButtonItem1, this.barButtonItem2 });
		this.barManager1.MaxItemId = 2;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(771, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 520);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(771, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 520);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(771, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 520);
		this.timer1.Interval = 1000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.gridColumn1.Caption = "Contact#";
		this.gridColumn1.FieldName = "ContactNumber";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 5;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrEmployeeList";
		base.Size = new System.Drawing.Size(771, 520);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.navBarControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl2).EndInit();
		this.panelControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
		this.xtraTabControl1.ResumeLayout(false);
		this.xtraTabPage1.ResumeLayout(false);
		this.xtraTabPage1.PerformLayout();
		this.xtraTabPage2.ResumeLayout(false);
		this.xtraTabPage2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit9.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgRecords_emp).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewEmployees).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
