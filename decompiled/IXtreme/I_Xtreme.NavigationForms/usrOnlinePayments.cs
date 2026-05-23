using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.DataAccess.Json;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme.NavigationForms;

public class usrOnlinePayments : XtraUserControl
{
	private string SchoolId = string.Empty;

	private string sName = string.Empty;

	private string classId = string.Empty;

	private string streamId = string.Empty;

	private string studyStatus = string.Empty;

	private string studentNumber = string.Empty;

	private IContainer components = null;

	private GridControl gridControl1;

	private GridView gridViewStudentPayment;

	private GridColumn gridColumn1;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private PopupMenu popupMenu1;

	private BarButtonItem barButtonItem1;

	private BarManager barManager1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private GridColumn gridColumn13;

	private GridColumn gridColumn12;

	private GridColumn gridColumn2;

	public usrOnlinePayments(bool IsAll, DateTime dtFrom, DateTime dtTo)
	{
		InitializeComponent();
		SchoolId = SerialNumber.GetSchoolCode(DataConnection.ConnectToDatabase());
		if (!IsAll)
		{
			GetFeesPaymentByDateRange(SchoolId, dtFrom, dtTo);
		}
		else
		{
			GetFeesPaymentBySchool(SchoolId);
		}
	}

	private async void GetFeesPaymentByDateRange(string SchoolId, DateTime StartDate, DateTime EndDate)
	{
		try
		{
			JsonDataSource jsonDataSource = new JsonDataSource();
			HttpClient httpClient = new HttpClient();
			try
			{
				httpClient.BaseAddress = new Uri("https://sims.surepayltd.com");
				((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Accept", "application/json");
				((HttpHeaders)httpClient.DefaultRequestHeaders).Add("6CD14B34-E080-4AEC-995A-0BC03CCABE6B", "111f942a-0c00-4bb8-ac95-f514e2229066");
				HttpResponseMessage response = await httpClient.GetAsync("/api/feespayment/payments/" + SchoolId + "/" + StartDate.ToString("yyyy-MM-dd") + "/" + EndDate.ToString("yyyy-MM-dd"));
				if (response.IsSuccessStatusCode)
				{
					jsonDataSource.JsonSource = new CustomJsonSource(await response.Content.ReadAsStringAsync());
					jsonDataSource.Fill();
					gridControl1.DataSource = jsonDataSource;
				}
			}
			finally
			{
				((IDisposable)httpClient)?.Dispose();
			}
		}
		finally
		{
			int num = 0;
			if (num >= 0)
			{
			}
		}
	}

	private async void GetFeesPaymentBySchool(string SchoolId)
	{
		try
		{
			JsonDataSource jsonDataSource = new JsonDataSource();
			HttpClient httpClient = new HttpClient();
			try
			{
				httpClient.BaseAddress = new Uri("https://sims.surepayltd.com");
				((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Accept", "application/json");
				((HttpHeaders)httpClient.DefaultRequestHeaders).Add("6CD14B34-E080-4AEC-995A-0BC03CCABE6B", "111f942a-0c00-4bb8-ac95-f514e2229066");
				HttpResponseMessage response = await httpClient.GetAsync("/api/feespayment/payments/" + SchoolId);
				if (response.IsSuccessStatusCode)
				{
					jsonDataSource.JsonSource = new CustomJsonSource(await response.Content.ReadAsStringAsync());
					jsonDataSource.Fill();
					gridControl1.DataSource = jsonDataSource;
				}
			}
			finally
			{
				((IDisposable)httpClient)?.Dispose();
			}
		}
		finally
		{
			int num = 0;
			if (num >= 0)
			{
			}
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			if (gridViewStudentPayment.GetFocusedDataSourceRowIndex() != -1)
			{
				string receiptNo = gridViewStudentPayment.GetRowCellValue(gridViewStudentPayment.GetFocusedDataSourceRowIndex(), "transactionRef").ToString();
				Receipt.PrintReceipt(studentNumber, sName, classId, streamId, studyStatus, receiptNo);
			}
			else
			{
				XtraMessageBox.Show("Please select a transaction you want to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridViewStudentPayment_KeyDown(object sender, KeyEventArgs e)
	{
		if (gridViewStudentPayment.FocusedRowHandle > -1)
		{
			if (e.KeyCode == Keys.Apps)
			{
				GetStudentInformation();
				popupMenu1.ShowCaption = true;
				popupMenu1.MenuCaption = sName;
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
	}

	private void GetStudentInformation()
	{
		studentNumber = gridViewStudentPayment.GetRowCellValue(gridViewStudentPayment.GetFocusedDataSourceRowIndex(), "studentNo").ToString();
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT fullName,ClassId,StreamId,StudyStatus FROM tbl_Stud WHERE StudentNumber='{studentNumber}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		sName = dataTable.Rows[0]["fullName"].ToString();
		classId = dataTable.Rows[0]["ClassId"].ToString();
		streamId = dataTable.Rows[0]["StreamId"].ToString();
		studyStatus = dataTable.Rows[0]["StudyStatus"].ToString();
	}

	private void gridViewStudentPayment_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridViewStudentPayment.FocusedRowHandle > -1)
		{
			if (e.Button == MouseButtons.Right)
			{
				GetStudentInformation();
				popupMenu1.ShowCaption = true;
				popupMenu1.MenuCaption = sName;
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
	}

	private void gridViewStudentPayment_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gridViewStudentPayment.GetFocusedDataSourceRowIndex() >= 0)
		{
			GetStudentInformation();
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
		DevExpress.XtraGrid.GridFormatRule gridFormatRule = new DevExpress.XtraGrid.GridFormatRule();
		DevExpress.XtraEditors.FormatConditionRuleValue rule = new DevExpress.XtraEditors.FormatConditionRuleValue();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridViewStudentPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		base.SuspendLayout();
		this.gridColumn11.Caption = "Term";
		this.gridColumn11.FieldName = "term";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.Visible = true;
		this.gridColumn11.VisibleIndex = 8;
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridViewStudentPayment;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(693, 427);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewStudentPayment });
		this.gridViewStudentPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[13]
		{
			this.gridColumn13, this.gridColumn6, this.gridColumn12, this.gridColumn2, this.gridColumn1, this.gridColumn10, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn7,
			this.gridColumn8, this.gridColumn9, this.gridColumn11
		});
		gridFormatRule.Column = this.gridColumn11;
		gridFormatRule.ColumnApplyTo = this.gridColumn11;
		gridFormatRule.Name = "Format0";
		gridFormatRule.Rule = rule;
		this.gridViewStudentPayment.FormatRules.Add(gridFormatRule);
		this.gridViewStudentPayment.GridControl = this.gridControl1;
		this.gridViewStudentPayment.Name = "gridViewStudentPayment";
		this.gridViewStudentPayment.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridViewStudentPayment_RowClick);
		this.gridViewStudentPayment.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewStudentPayment_FocusedRowChanged);
		this.gridViewStudentPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(gridViewStudentPayment_KeyDown);
		this.gridColumn13.Caption = "Name";
		this.gridColumn13.FieldName = "name";
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn13.Visible = true;
		this.gridColumn13.VisibleIndex = 0;
		this.gridColumn6.Caption = "StudentNo";
		this.gridColumn6.FieldName = "studentNo";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 1;
		this.gridColumn12.Caption = "Class";
		this.gridColumn12.FieldName = "studentClass";
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn12.Visible = true;
		this.gridColumn12.VisibleIndex = 2;
		this.gridColumn2.Caption = "Stream";
		this.gridColumn2.FieldName = "studentStream";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 3;
		this.gridColumn1.Caption = "PaymentId";
		this.gridColumn1.FieldName = "paymentId";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn10.Caption = "Date";
		this.gridColumn10.DisplayFormat.FormatString = "dd-MMM-yyyy";
		this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn10.FieldName = "trxDate";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 4;
		this.gridColumn3.Caption = "AmountPaid";
		this.gridColumn3.DisplayFormat.FormatString = "#,#";
		this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn3.FieldName = "amountPaid";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 5;
		this.gridColumn4.Caption = "Particulars";
		this.gridColumn4.FieldName = "particulars";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 6;
		this.gridColumn5.Caption = "School Ref";
		this.gridColumn5.FieldName = "schoolRef";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn7.Caption = "TelcomCarrier";
		this.gridColumn7.FieldName = "telcomCarrier";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn8.Caption = "Transaction Ref";
		this.gridColumn8.FieldName = "transactionRef";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 7;
		this.gridColumn9.Caption = "TransactionUniqueId";
		this.gridColumn9.FieldName = "transactionUniqueId";
		this.gridColumn9.Name = "gridColumn9";
		this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[1]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)
		});
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		this.barButtonItem1.Caption = "Print Receipt";
		this.barButtonItem1.Id = 0;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[1] { this.barButtonItem1 });
		this.barManager1.MaxItemId = 1;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(693, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 427);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(693, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 427);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(693, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 427);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.gridControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrOnlinePayments";
		base.Size = new System.Drawing.Size(693, 427);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudentPayment).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
