using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace ExtremeMessenger;

public class MainDashBoard : XtraForm
{
	private IContainer components = null;

	private BarManager barManager1;

	private Bar bar1;

	private Bar bar3;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private BarSubItem barSubItem1;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarSubItem barSubItem2;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem5;

	private BarStaticItem barStaticItem1;

	private BarSubItem barSubItem3;

	private BarButtonItem barButtonItem6;

	private BarButtonItem barButtonItem7;

	private BarSubItem barSubItem4;

	private BarSubItem barSubItem5;

	private BarListItem barListItem1;

	private BarSubItem barSubItem6;

	private BarToolbarsListItem barToolbarsListItem1;

	private PopupMenu popupMenu1;

	private BarStaticItem lblInternetStatus;

	private Timer timer1;

	private RepositoryItemPictureEdit repositoryItemPictureEdit1;

	private BarStaticItem lblLocalConnection;

	private PanelControl panelControl1;

	private BarButtonItem barButtonItem8;

	private BarButtonItem barButtonItem9;

	private BarButtonItem barButtonItem10;

	public MainDashBoard()
	{
		InitializeComponent();
		try
		{
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
	{
		Close();
	}

	private void MainDashBoard_FormClosing(object sender, FormClosingEventArgs e)
	{
		using ExitDialog exitDialog = new ExitDialog();
		if (exitDialog.ShowDialog() == DialogResult.No)
		{
			e.Cancel = true;
		}
	}

	private void barLargeButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void MainDashBoard_Resize(object sender, EventArgs e)
	{
	}

	private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
	{
		Show();
		base.WindowState = FormWindowState.Normal;
	}

	private void MainDashBoard_Load(object sender, EventArgs e)
	{
		Rectangle workingArea = Screen.GetWorkingArea(this);
		base.Location = new Point(workingArea.Right - base.Size.Width, workingArea.Bottom - base.Size.Height);
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		userInternalTexting value = new userInternalTexting();
		panelControl1.Controls.Clear();
		panelControl1.Controls.Add(value);
		panelControl1.Dock = DockStyle.Fill;
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		userFeesReminder value = new userFeesReminder();
		panelControl1.Controls.Clear();
		panelControl1.Controls.Add(value);
		panelControl1.Dock = DockStyle.Fill;
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		userInternalServer value = new userInternalServer();
		panelControl1.Controls.Clear();
		panelControl1.Controls.Add(value);
		panelControl1.Dock = DockStyle.Fill;
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		base.WindowState = FormWindowState.Minimized;
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		Application.ExitThread();
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		userVoiceCast value = new userVoiceCast();
		panelControl1.Controls.Clear();
		panelControl1.Controls.Add(value);
		panelControl1.Dock = DockStyle.Fill;
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
		this.barManager1 = new DevExpress.XtraBars.BarManager();
		this.bar1 = new DevExpress.XtraBars.Bar();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.bar3 = new DevExpress.XtraBars.Bar();
		this.lblInternetStatus = new DevExpress.XtraBars.BarStaticItem();
		this.lblLocalConnection = new DevExpress.XtraBars.BarStaticItem();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
		this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
		this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
		this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
		this.barListItem1 = new DevExpress.XtraBars.BarListItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
		this.timer1 = new System.Windows.Forms.Timer();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		base.SuspendLayout();
		this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[2] { this.bar1, this.bar3 });
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[21]
		{
			this.barSubItem1, this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barSubItem2, this.barButtonItem4, this.barButtonItem5, this.barStaticItem1, this.barSubItem3, this.barButtonItem6,
			this.barButtonItem7, this.barSubItem4, this.barSubItem5, this.barSubItem6, this.barToolbarsListItem1, this.barListItem1, this.lblInternetStatus, this.lblLocalConnection, this.barButtonItem8, this.barButtonItem9,
			this.barButtonItem10
		});
		this.barManager1.MaxItemId = 29;
		this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemPictureEdit1 });
		this.barManager1.StatusBar = this.bar3;
		this.bar1.BarName = "Tools";
		this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
		this.bar1.DockCol = 0;
		this.bar1.DockRow = 0;
		this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
		this.bar1.FloatLocation = new System.Drawing.Point(231, 135);
		this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
			new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4)
		});
		this.bar1.OptionsBar.AllowQuickCustomization = false;
		this.bar1.OptionsBar.DisableClose = true;
		this.bar1.OptionsBar.DisableCustomization = true;
		this.bar1.OptionsBar.DrawDragBorder = false;
		this.bar1.OptionsBar.UseWholeRow = true;
		this.bar1.Text = "Tools";
		this.barSubItem1.Caption = "&File";
		this.barSubItem1.Id = 1;
		this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)
		});
		this.barSubItem1.Name = "barSubItem1";
		this.barButtonItem2.Caption = "Minimize to Try";
		this.barButtonItem2.Id = 3;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Exit";
		this.barButtonItem3.Id = 4;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barSubItem2.Caption = "Messenger";
		this.barSubItem2.Id = 5;
		this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem10)
		});
		this.barSubItem2.Name = "barSubItem2";
		this.barButtonItem4.Caption = "Freestyle";
		this.barButtonItem4.Id = 6;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem9.Caption = "Fees Reminder";
		this.barButtonItem9.Id = 27;
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.barButtonItem10.Caption = "Voice Cast";
		this.barButtonItem10.Id = 28;
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.barSubItem4.Caption = "Options";
		this.barSubItem4.Id = 12;
		this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[1]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)
		});
		this.barSubItem4.Name = "barSubItem4";
		this.barButtonItem1.Caption = "Servers Connectivity";
		this.barButtonItem1.Id = 2;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.bar3.BarName = "Status bar";
		this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
		this.bar3.DockCol = 0;
		this.bar3.DockRow = 0;
		this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
		this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.lblInternetStatus),
			new DevExpress.XtraBars.LinkPersistInfo(this.lblLocalConnection)
		});
		this.bar3.OptionsBar.AllowQuickCustomization = false;
		this.bar3.OptionsBar.DrawDragBorder = false;
		this.bar3.OptionsBar.UseWholeRow = true;
		this.bar3.Text = "Status bar";
		this.lblInternetStatus.Id = 23;
		this.lblInternetStatus.Name = "lblInternetStatus";
		this.lblLocalConnection.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.lblLocalConnection.Id = 25;
		this.lblLocalConnection.Name = "lblLocalConnection";
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(301, 24);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 486);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(301, 24);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 462);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(301, 24);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 462);
		this.barButtonItem5.Caption = "Text - External";
		this.barButtonItem5.Id = 7;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barStaticItem1.Caption = "VoIP";
		this.barStaticItem1.Id = 8;
		this.barStaticItem1.Name = "barStaticItem1";
		this.barSubItem3.Caption = "Help";
		this.barSubItem3.Id = 9;
		this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7)
		});
		this.barSubItem3.Name = "barSubItem3";
		this.barButtonItem6.Caption = "View Help";
		this.barButtonItem6.Id = 10;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem7.Caption = "About Extreme Messenger";
		this.barButtonItem7.Id = 11;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barSubItem5.Caption = "Look and Feel";
		this.barSubItem5.Id = 13;
		this.barSubItem5.Name = "barSubItem5";
		this.barSubItem6.Caption = "View";
		this.barSubItem6.Id = 14;
		this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[1]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barToolbarsListItem1)
		});
		this.barSubItem6.Name = "barSubItem6";
		this.barToolbarsListItem1.Caption = "barToolbarsListItem1";
		this.barToolbarsListItem1.Id = 15;
		this.barToolbarsListItem1.Name = "barToolbarsListItem1";
		this.barListItem1.Caption = "barListItem1";
		this.barListItem1.Id = 16;
		this.barListItem1.Name = "barListItem1";
		this.barButtonItem8.Caption = "SMS Gateway link";
		this.barButtonItem8.Id = 26;
		this.barButtonItem8.Name = "barButtonItem8";
		this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panelControl1.Location = new System.Drawing.Point(0, 24);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(301, 462);
		this.panelControl1.TabIndex = 5;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(301, 510);
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.IconOptions.ShowIcon = false;
		base.MaximizeBox = false;
		base.Name = "MainDashBoard";
		this.Text = "SMD Messenger";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainDashBoard_FormClosing);
		base.Load += new System.EventHandler(MainDashBoard_Load);
		base.Resize += new System.EventHandler(MainDashBoard_Resize);
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
