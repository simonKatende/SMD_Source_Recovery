using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrStudentListNA : XtraUserControl
{
	private SqlTransaction transaction;

	private DataSet student_DataSet;

	private DataTable student_dataTable;

	private IContainer components = null;

	private PanelControl panelControl7;

	private PictureEdit picStudent;

	private LabelControl labelControl154;

	private LabelControl labelControl153;

	private LabelControl Guardian;

	private LabelControl lblGuardianAddress;

	private LabelControl lblGuardianPhone;

	private LabelControl lblGuardianName;

	private LabelControl lblStudentAdmitDate;

	private LabelControl labelControl159;

	private LabelControl labelControl158;

	private LabelControl labelControl157;

	private LabelControl labelControl156;

	private LabelControl lblStudentFees;

	private LabelControl lblStudentBursaryProv;

	private LabelControl lblStudentBursary;

	private LabelControl labelControl150;

	private LabelControl lblStudentHouse;

	private LabelControl lblStudentReligion;

	private LabelControl labelControl147;

	private LabelControl labelControl146;

	private LabelControl lblStudentDB;

	private LabelControl lblStudentStream;

	private LabelControl lblStudentClass;

	private LabelControl lblStudentNo;

	private LabelControl labelControl144;

	private LabelControl labelControl143;

	private LabelControl labelControl142;

	private LabelControl lblName;

	private MyGridControl gridStudentRecords;

	private MyGridView dgRecords;

	private GridColumn colName;

	private GridColumn colStudentNo;

	private GridColumn colStream;

	private GridColumn colDB;

	private GridColumn colSex;

	private GridColumn colStudNotes;

	private GridColumn colPicture;

	private GridColumn colBursaryStatus;

	private GridColumn colBursaryProvider;

	private GridColumn colFees;

	private GridColumn colFormerSchool;

	private GridColumn colAdmitDate;

	private GridColumn colHouse;

	private GridColumn colGuardian;

	private GridColumn colReligion;

	private PopupMenu popupMenu1;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarSubItem barSubItem1;

	private BarButtonItem barButtonItem6;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem8;

	private BarManager barManager1;

	private BarDockControl barDockControlTop;

	private BarDockControl barDockControlBottom;

	private BarDockControl barDockControlLeft;

	private BarDockControl barDockControlRight;

	private BarButtonItem barButtonItem5;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem3;

	private GridColumn colNo;

	private BarButtonItem barButtonItem9;

	private LabelControl lblGuid;

	private LabelControl lblSourceClass;

	private GridColumn colSourceClass;

	public usrStudentListNA()
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Loading Students' List...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadStudentList, 0);
		Thread.Sleep(25);
		InitializeComponent();
		LoadStudentsNA();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadStudentsNA()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * From tbl_suspendedStudents s LEFT OUTER JOIN tbl_suspendedGuardians g ON s.Oid = g.studentOid", selectConnection);
			student_DataSet = new DataSet();
			sqlDataAdapter.Fill(student_DataSet, "studentRecords");
			student_dataTable = new DataTable();
			student_dataTable = student_DataSet.Tables[0];
			if (student_dataTable.Rows.Count > 0)
			{
				gridStudentRecords.DataSource = student_dataTable.DefaultView;
				StudentOptions.SetActiveClass("N/A");
				PrintableControl.SavePrintableControl(dgRecords);
				PrintableControl.SavePrintableControl(gridStudentRecords);
				ActiveFormSelected.SetActiveForm("List of suspended students");
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void dgRecords_ColumnFilterChanged(object sender, EventArgs e)
	{
		dgRecords.FocusedRowHandle = -1;
	}

	private void dgRecords_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (dgRecords.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = student_dataTable.Rows[dgRecords.GetFocusedDataSourceRowIndex()];
			byte[] array = new byte[0];
			array = (byte[])dataRow["Picture"];
			using (MemoryStream stream = new MemoryStream(array))
			{
				picStudent.Image = Image.FromStream(stream);
			}
			lblName.Text = dataRow["fullName"].ToString();
			lblStudentClass.Text = StudentOptions.ActiveClass();
			lblStudentStream.Text = dataRow["StreamId"].ToString();
			lblStudentNo.Text = dataRow["StudentNumber"].ToString().ToUpper();
			lblStudentReligion.Text = dataRow["Religion"].ToString();
			lblStudentHouse.Text = dataRow["HouseId"].ToString();
			lblStudentDB.Text = dataRow["StudyStatus"].ToString();
			lblStudentBursary.Text = dataRow["BursaryStatus"].ToString();
			lblStudentBursaryProv.Text = dataRow["BursaryProvider"].ToString();
			lblStudentAdmitDate.Text = dataRow["AdmissionDate"].ToString();
			lblStudentFees.Text = dataRow["RequiredFees"].ToString();
			lblGuardianName.Text = dataRow["GuardianName"].ToString();
			lblGuardianPhone.Text = dataRow["GuardianContact"].ToString();
			lblGuardianAddress.Text = dataRow["GuardianAddress"].ToString();
			lblGuid.Text = dataRow["Oid"].ToString();
			lblSourceClass.Text = dataRow["ClassId"].ToString();
			StudentOptions.SetActiveStudent(dataRow["StudentNumber"].ToString().ToUpper());
		}
	}

	private void dgRecords_RowClick(object sender, RowClickEventArgs e)
	{
		if (dgRecords.FocusedRowHandle > -1)
		{
			if (e.Button == MouseButtons.Right)
			{
				popupMenu1.ShowCaption = true;
				DataRow dataRow = student_dataTable.Rows[dgRecords.GetFocusedDataSourceRowIndex()];
				popupMenu1.MenuCaption = dataRow["fullName"].ToString();
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
		StudentOptions.SetRowHandle(dgRecords.FocusedRowHandle);
	}

	private void dgRecords_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Apps)
		{
			popupMenu1.ShowCaption = true;
			DataRow dataRow = student_dataTable.Rows[dgRecords.GetFocusedDataSourceRowIndex()];
			popupMenu1.MenuCaption = dataRow["fullName"].ToString();
			popupMenu1.ShowPopup(Control.MousePosition);
		}
		else
		{
			popupMenu1.HidePopup();
		}
	}

	private void dgRecords_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo" && e.ListSourceRowIndex > -1)
		{
			e.DisplayText = (dgRecords.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		StudentOptions.DeleteStudentUnConditionally(_guid: new Guid(lblGuid.Text), studentNumber: lblStudentNo.Text, StudClass: lblSourceClass.Text.Trim(), name: lblName.Text);
		LoadStudentsNA();
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		using ReAssignClass reAssignClass = new ReAssignClass();
		if (reAssignClass.ShowDialog() == DialogResult.OK)
		{
			string value = reAssignClass.txtTargetClass.SelectedItem.ToString();
			string value2 = reAssignClass.txtTargetStream.SelectedItem.ToString();
			Image image = null;
			image = ((picStudent.Image != null) ? picStudent.Image : Resources.Default);
			int num = image.Height;
			int num2 = image.Width;
			num = num * 220 / num2;
			num2 = 220;
			if (num > 250)
			{
				num2 = num2 * 250 / num;
				num = 250;
			}
			Bitmap bitmap = new Bitmap(image, num2, num);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length + 1];
			memoryStream.Read(array, 0, array.Length);
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			transaction = sqlConnection.BeginTransaction();
			DataRow dataRow = student_dataTable.Rows[dgRecords.GetFocusedDataSourceRowIndex()];
			string value3 = dataRow["StudentID"].ToString();
			if (string.IsNullOrEmpty(value3))
			{
				value3 = dataRow["StudentNumber"].ToString();
			}
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_Stud (StudentNumber,HouseId,ClassId,StreamId,Oid,FormerSchool,StudyStatus,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Sex,Picture,Religion,HomeCountry,fullName,Status,Notes,cashOnAccount,fName,fContact,fAddress,fEmail,mName,mContact,mAddress,mEmail,DOB,IsTheologyStud,PrimaryScores1,StudentID,PriorityContact,OtherContact,GuardianAddress)VALUES(@StudentNumber,@HouseId,@ClassId,@StreamId,@Oid,@FormerSchool,@StudyStatus,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Sex,@Picture,@Religion,@HomeCountry,@fullName,@Status,@Notes,@cashOnAccount,@fName,@fContact,@fAddress,@fEmail,@mName,@mContact,@mAddress,@mEmail,@DOB,@IsTheologyStud,@PrimaryScores1,@StudentID,@PriorityContact,@OtherContact,@GuardianAddress)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = lblStudentNo.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudentID", SqlDbType.VarChar, 12);
				sqlParameter.Value = value3;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["HouseId"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 50);
				sqlParameter.Value = value2;
				sqlParameter.Direction = ParameterDirection.Input;
				Guid guid = new Guid(dataRow["Oid"].ToString());
				sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = guid;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["FormerSchool"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
				sqlParameter.Value = dataRow["StudyStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["BursaryStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(dataRow["RequiredFees"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["BursaryProvider"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
				sqlParameter.Value = Convert.ToInt32(dataRow["AdmissionDate"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = dataRow["Sex"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
				sqlParameter.Value = array;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["Religion"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["HomeCountry"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 100);
				sqlParameter.Value = dataRow["fullName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
				sqlParameter.Value = dataRow["Notes"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 30);
				sqlParameter.Value = dataRow["Status"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(dataRow["cashOnAccount"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fName", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = dataRow["fContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fEmail"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mName", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["mName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["mAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mContact", SqlDbType.VarChar, 10);
				sqlParameter.Value = dataRow["mContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@mEmail", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["mEmail"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				DateTime result = (DateTime.TryParse(dataRow["DOB"].ToString(), out result) ? result : DateTime.Now);
				sqlParameter = sqlCommand.Parameters.Add("@DOB", SqlDbType.DateTime);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				bool result2 = bool.TryParse(dataRow["IsTheologyStud"].ToString(), out result2) && result2;
				sqlParameter = sqlCommand.Parameters.Add("@IsTheologyStud", SqlDbType.Bit);
				sqlParameter.Value = result2;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PrimaryScores1", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["PrimaryScores1"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@sNIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["sNIN"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@LIN", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["LIN"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ReportCentre", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["ReportCentre"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Cocurricular", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["Cocurricular"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HealthStatus", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["HealthStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianPic", SqlDbType.Image);
				sqlParameter.Value = DBNull.Value;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianRelation", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["GuardianRelation"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PriorityContact", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["PriorityContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@OtherContact", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["OtherContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianAddress", SqlDbType.NVarChar, 100);
				sqlParameter.Value = dataRow["GuardianAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_suspendedStudents WHERE StudentNumber=@StudentNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter2.Value = lblStudentNo.Text.ToUpper();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			transaction.Commit();
			LoadStudentsNA();
			CustomDialog.ShowCustomDialog("Re-assignment successful.");
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
		this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
		this.lblSourceClass = new DevExpress.XtraEditors.LabelControl();
		this.lblGuid = new DevExpress.XtraEditors.LabelControl();
		this.picStudent = new DevExpress.XtraEditors.PictureEdit();
		this.labelControl154 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl153 = new DevExpress.XtraEditors.LabelControl();
		this.Guardian = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianAddress = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianPhone = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianName = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentAdmitDate = new DevExpress.XtraEditors.LabelControl();
		this.labelControl159 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl158 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl157 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl156 = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentFees = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentBursaryProv = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentBursary = new DevExpress.XtraEditors.LabelControl();
		this.labelControl150 = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentHouse = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentReligion = new DevExpress.XtraEditors.LabelControl();
		this.labelControl147 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl146 = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentDB = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentStream = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentClass = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentNo = new DevExpress.XtraEditors.LabelControl();
		this.labelControl144 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl143 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl142 = new DevExpress.XtraEditors.LabelControl();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.gridStudentRecords = new AlienAge.CustomGrid.MyGridControl();
		this.dgRecords = new AlienAge.CustomGrid.MyGridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStudentNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colSourceClass = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStream = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colDB = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colStudNotes = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colPicture = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colBursaryStatus = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colBursaryProvider = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colFees = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colFormerSchool = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colAdmitDate = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colHouse = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colGuardian = new DevExpress.XtraGrid.Columns.GridColumn();
		this.colReligion = new DevExpress.XtraGrid.Columns.GridColumn();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barManager1 = new DevExpress.XtraBars.BarManager();
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.panelControl7).BeginInit();
		this.panelControl7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.picStudent.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgRecords).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		base.SuspendLayout();
		this.panelControl7.Controls.Add(this.lblSourceClass);
		this.panelControl7.Controls.Add(this.lblGuid);
		this.panelControl7.Controls.Add(this.picStudent);
		this.panelControl7.Controls.Add(this.labelControl154);
		this.panelControl7.Controls.Add(this.labelControl153);
		this.panelControl7.Controls.Add(this.Guardian);
		this.panelControl7.Controls.Add(this.lblGuardianAddress);
		this.panelControl7.Controls.Add(this.lblGuardianPhone);
		this.panelControl7.Controls.Add(this.lblGuardianName);
		this.panelControl7.Controls.Add(this.lblStudentAdmitDate);
		this.panelControl7.Controls.Add(this.labelControl159);
		this.panelControl7.Controls.Add(this.labelControl158);
		this.panelControl7.Controls.Add(this.labelControl157);
		this.panelControl7.Controls.Add(this.labelControl156);
		this.panelControl7.Controls.Add(this.lblStudentFees);
		this.panelControl7.Controls.Add(this.lblStudentBursaryProv);
		this.panelControl7.Controls.Add(this.lblStudentBursary);
		this.panelControl7.Controls.Add(this.labelControl150);
		this.panelControl7.Controls.Add(this.lblStudentHouse);
		this.panelControl7.Controls.Add(this.lblStudentReligion);
		this.panelControl7.Controls.Add(this.labelControl147);
		this.panelControl7.Controls.Add(this.labelControl146);
		this.panelControl7.Controls.Add(this.lblStudentDB);
		this.panelControl7.Controls.Add(this.lblStudentStream);
		this.panelControl7.Controls.Add(this.lblStudentClass);
		this.panelControl7.Controls.Add(this.lblStudentNo);
		this.panelControl7.Controls.Add(this.labelControl144);
		this.panelControl7.Controls.Add(this.labelControl143);
		this.panelControl7.Controls.Add(this.labelControl142);
		this.panelControl7.Controls.Add(this.lblName);
		this.panelControl7.Location = new System.Drawing.Point(742, 4);
		this.panelControl7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
		this.panelControl7.Name = "panelControl7";
		this.panelControl7.Size = new System.Drawing.Size(200, 509);
		this.panelControl7.TabIndex = 4;
		this.lblSourceClass.Location = new System.Drawing.Point(3, 292);
		this.lblSourceClass.Name = "lblSourceClass";
		this.lblSourceClass.Size = new System.Drawing.Size(63, 13);
		this.lblSourceClass.TabIndex = 35;
		this.lblSourceClass.Text = "labelControl1";
		this.lblSourceClass.Visible = false;
		this.lblGuid.Location = new System.Drawing.Point(3, 342);
		this.lblGuid.Name = "lblGuid";
		this.lblGuid.Size = new System.Drawing.Size(63, 13);
		this.lblGuid.TabIndex = 34;
		this.lblGuid.Text = "labelControl1";
		this.lblGuid.Visible = false;
		this.picStudent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.picStudent.Location = new System.Drawing.Point(5, 30);
		this.picStudent.Name = "picStudent";
		this.picStudent.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.picStudent.Size = new System.Drawing.Size(190, 242);
		this.picStudent.TabIndex = 33;
		this.labelControl154.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl154.Location = new System.Drawing.Point(5, 491);
		this.labelControl154.Name = "labelControl154";
		this.labelControl154.Size = new System.Drawing.Size(39, 13);
		this.labelControl154.TabIndex = 31;
		this.labelControl154.Text = "Address";
		this.labelControl153.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl153.Location = new System.Drawing.Point(5, 473);
		this.labelControl153.Name = "labelControl153";
		this.labelControl153.Size = new System.Drawing.Size(30, 13);
		this.labelControl153.TabIndex = 30;
		this.labelControl153.Text = "Phone";
		this.Guardian.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Guardian.Location = new System.Drawing.Point(5, 455);
		this.Guardian.Name = "Guardian";
		this.Guardian.Size = new System.Drawing.Size(43, 13);
		this.Guardian.TabIndex = 29;
		this.Guardian.Text = "Guardian";
		this.lblGuardianAddress.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblGuardianAddress.Appearance.Options.UseTextOptions = true;
		this.lblGuardianAddress.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.lblGuardianAddress.Location = new System.Drawing.Point(79, 491);
		this.lblGuardianAddress.Name = "lblGuardianAddress";
		this.lblGuardianAddress.Size = new System.Drawing.Size(0, 0);
		this.lblGuardianAddress.TabIndex = 28;
		this.lblGuardianPhone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblGuardianPhone.Location = new System.Drawing.Point(79, 473);
		this.lblGuardianPhone.Name = "lblGuardianPhone";
		this.lblGuardianPhone.Size = new System.Drawing.Size(0, 13);
		this.lblGuardianPhone.TabIndex = 27;
		this.lblGuardianName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblGuardianName.Location = new System.Drawing.Point(79, 455);
		this.lblGuardianName.Name = "lblGuardianName";
		this.lblGuardianName.Size = new System.Drawing.Size(0, 13);
		this.lblGuardianName.TabIndex = 26;
		this.lblStudentAdmitDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentAdmitDate.Location = new System.Drawing.Point(79, 439);
		this.lblStudentAdmitDate.Name = "lblStudentAdmitDate";
		this.lblStudentAdmitDate.Size = new System.Drawing.Size(0, 13);
		this.lblStudentAdmitDate.TabIndex = 24;
		this.labelControl159.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl159.Location = new System.Drawing.Point(5, 421);
		this.labelControl159.Name = "labelControl159";
		this.labelControl159.Size = new System.Drawing.Size(23, 13);
		this.labelControl159.TabIndex = 22;
		this.labelControl159.Text = "Fees";
		this.labelControl158.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl158.Location = new System.Drawing.Point(5, 403);
		this.labelControl158.Name = "labelControl158";
		this.labelControl158.Size = new System.Drawing.Size(66, 13);
		this.labelControl158.TabIndex = 21;
		this.labelControl158.Text = "Bursary Prov.";
		this.labelControl157.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl157.Location = new System.Drawing.Point(5, 385);
		this.labelControl157.Name = "labelControl157";
		this.labelControl157.Size = new System.Drawing.Size(40, 13);
		this.labelControl157.TabIndex = 20;
		this.labelControl157.Text = "Bursary ";
		this.labelControl156.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl156.Location = new System.Drawing.Point(5, 439);
		this.labelControl156.Name = "labelControl156";
		this.labelControl156.Size = new System.Drawing.Size(52, 13);
		this.labelControl156.TabIndex = 19;
		this.labelControl156.Text = "Admit date";
		this.lblStudentFees.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentFees.Location = new System.Drawing.Point(79, 421);
		this.lblStudentFees.Name = "lblStudentFees";
		this.lblStudentFees.Size = new System.Drawing.Size(0, 13);
		this.lblStudentFees.TabIndex = 18;
		this.lblStudentBursaryProv.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentBursaryProv.Location = new System.Drawing.Point(79, 403);
		this.lblStudentBursaryProv.Name = "lblStudentBursaryProv";
		this.lblStudentBursaryProv.Size = new System.Drawing.Size(0, 13);
		this.lblStudentBursaryProv.TabIndex = 17;
		this.lblStudentBursary.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentBursary.Location = new System.Drawing.Point(79, 385);
		this.lblStudentBursary.Name = "lblStudentBursary";
		this.lblStudentBursary.Size = new System.Drawing.Size(0, 13);
		this.lblStudentBursary.TabIndex = 16;
		this.labelControl150.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl150.Location = new System.Drawing.Point(5, 368);
		this.labelControl150.Name = "labelControl150";
		this.labelControl150.Size = new System.Drawing.Size(30, 13);
		this.labelControl150.TabIndex = 13;
		this.labelControl150.Text = "House";
		this.lblStudentHouse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentHouse.Location = new System.Drawing.Point(79, 368);
		this.lblStudentHouse.Name = "lblStudentHouse";
		this.lblStudentHouse.Size = new System.Drawing.Size(0, 13);
		this.lblStudentHouse.TabIndex = 12;
		this.lblStudentReligion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentReligion.Location = new System.Drawing.Point(79, 350);
		this.lblStudentReligion.Name = "lblStudentReligion";
		this.lblStudentReligion.Size = new System.Drawing.Size(0, 13);
		this.lblStudentReligion.TabIndex = 11;
		this.labelControl147.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl147.Location = new System.Drawing.Point(5, 350);
		this.labelControl147.Name = "labelControl147";
		this.labelControl147.Size = new System.Drawing.Size(37, 13);
		this.labelControl147.TabIndex = 10;
		this.labelControl147.Text = "Religion";
		this.labelControl146.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl146.Location = new System.Drawing.Point(5, 332);
		this.labelControl146.Name = "labelControl146";
		this.labelControl146.Size = new System.Drawing.Size(17, 13);
		this.labelControl146.TabIndex = 9;
		this.labelControl146.Text = "D/B";
		this.lblStudentDB.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentDB.Location = new System.Drawing.Point(79, 332);
		this.lblStudentDB.Name = "lblStudentDB";
		this.lblStudentDB.Size = new System.Drawing.Size(0, 13);
		this.lblStudentDB.TabIndex = 8;
		this.lblStudentStream.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentStream.Location = new System.Drawing.Point(79, 314);
		this.lblStudentStream.Name = "lblStudentStream";
		this.lblStudentStream.Size = new System.Drawing.Size(0, 13);
		this.lblStudentStream.TabIndex = 7;
		this.lblStudentClass.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentClass.Location = new System.Drawing.Point(79, 296);
		this.lblStudentClass.Name = "lblStudentClass";
		this.lblStudentClass.Size = new System.Drawing.Size(0, 13);
		this.lblStudentClass.TabIndex = 6;
		this.lblStudentNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.lblStudentNo.Location = new System.Drawing.Point(79, 278);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(0, 13);
		this.lblStudentNo.TabIndex = 5;
		this.labelControl144.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl144.Location = new System.Drawing.Point(5, 314);
		this.labelControl144.Name = "labelControl144";
		this.labelControl144.Size = new System.Drawing.Size(34, 13);
		this.labelControl144.TabIndex = 4;
		this.labelControl144.Text = "Stream";
		this.labelControl143.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl143.Location = new System.Drawing.Point(5, 296);
		this.labelControl143.Name = "labelControl143";
		this.labelControl143.Size = new System.Drawing.Size(25, 13);
		this.labelControl143.TabIndex = 3;
		this.labelControl143.Text = "Class";
		this.labelControl142.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.labelControl142.Location = new System.Drawing.Point(5, 278);
		this.labelControl142.Name = "labelControl142";
		this.labelControl142.Size = new System.Drawing.Size(38, 13);
		this.labelControl142.TabIndex = 2;
		this.labelControl142.Text = "Stud No";
		this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.lblName.Appearance.Options.UseFont = true;
		this.lblName.Appearance.Options.UseTextOptions = true;
		this.lblName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.lblName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
		this.lblName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblName.Location = new System.Drawing.Point(5, 5);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(190, 19);
		this.lblName.TabIndex = 1;
		this.gridStudentRecords.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.gridStudentRecords.Location = new System.Drawing.Point(4, 4);
		this.gridStudentRecords.MainView = this.dgRecords;
		this.gridStudentRecords.Name = "gridStudentRecords";
		this.gridStudentRecords.Size = new System.Drawing.Size(734, 509);
		this.gridStudentRecords.TabIndex = 0;
		this.gridStudentRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.dgRecords });
		this.dgRecords.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.dgRecords.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.dgRecords.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.dgRecords.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.DetailTip.Options.UseFont = true;
		this.dgRecords.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.Empty.Options.UseFont = true;
		this.dgRecords.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.dgRecords.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.EvenRow.Options.UseBackColor = true;
		this.dgRecords.Appearance.EvenRow.Options.UseFont = true;
		this.dgRecords.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.FilterCloseButton.Options.UseFont = true;
		this.dgRecords.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.FilterPanel.Options.UseFont = true;
		this.dgRecords.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.FixedLine.Options.UseFont = true;
		this.dgRecords.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.dgRecords.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.FocusedCell.Options.UseBackColor = true;
		this.dgRecords.Appearance.FocusedCell.Options.UseFont = true;
		this.dgRecords.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dgRecords.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.FocusedRow.Options.UseBackColor = true;
		this.dgRecords.Appearance.FocusedRow.Options.UseFont = true;
		this.dgRecords.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.FooterPanel.Options.UseFont = true;
		this.dgRecords.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.GroupButton.Options.UseFont = true;
		this.dgRecords.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.GroupFooter.Options.UseFont = true;
		this.dgRecords.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.GroupPanel.Options.UseFont = true;
		this.dgRecords.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.GroupRow.Options.UseFont = true;
		this.dgRecords.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.HeaderPanel.Options.UseFont = true;
		this.dgRecords.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dgRecords.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.dgRecords.Appearance.HideSelectionRow.Options.UseFont = true;
		this.dgRecords.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.HorzLine.Options.UseFont = true;
		this.dgRecords.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.OddRow.Options.UseFont = true;
		this.dgRecords.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.Preview.Options.UseFont = true;
		this.dgRecords.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.Row.Options.UseFont = true;
		this.dgRecords.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.RowSeparator.Options.UseFont = true;
		this.dgRecords.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dgRecords.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.SelectedRow.Options.UseBackColor = true;
		this.dgRecords.Appearance.SelectedRow.Options.UseFont = true;
		this.dgRecords.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.TopNewRow.Options.UseFont = true;
		this.dgRecords.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.VertLine.Options.UseFont = true;
		this.dgRecords.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.Appearance.ViewCaption.Options.UseFont = true;
		this.dgRecords.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.dgRecords.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.dgRecords.AppearancePrint.EvenRow.Options.UseFont = true;
		this.dgRecords.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.dgRecords.AppearancePrint.FilterPanel.Options.UseTextOptions = true;
		this.dgRecords.AppearancePrint.FilterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.dgRecords.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.dgRecords.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.dgRecords.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.GroupRow.Options.UseFont = true;
		this.dgRecords.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.dgRecords.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.Lines.Options.UseFont = true;
		this.dgRecords.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.OddRow.Options.UseFont = true;
		this.dgRecords.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.Preview.Options.UseFont = true;
		this.dgRecords.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.dgRecords.AppearancePrint.Row.Options.UseFont = true;
		this.dgRecords.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[17]
		{
			this.colNo, this.colName, this.colStudentNo, this.colSourceClass, this.colStream, this.colDB, this.colSex, this.colStudNotes, this.colPicture, this.colBursaryStatus,
			this.colBursaryProvider, this.colFees, this.colFormerSchool, this.colAdmitDate, this.colHouse, this.colGuardian, this.colReligion
		});
		this.dgRecords.GridControl = this.gridStudentRecords;
		this.dgRecords.IndicatorWidth = 35;
		this.dgRecords.Name = "dgRecords";
		this.dgRecords.OptionsBehavior.Editable = false;
		this.dgRecords.OptionsFind.AlwaysVisible = true;
		this.dgRecords.OptionsPrint.EnableAppearanceEvenRow = true;
		this.dgRecords.OptionsPrint.PrintFilterInfo = true;
		this.dgRecords.OptionsPrint.PrintFooter = false;
		this.dgRecords.OptionsView.EnableAppearanceEvenRow = true;
		this.dgRecords.OptionsView.ShowGroupPanel = false;
		this.dgRecords.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.dgRecords.OptionsView.ShowIndicator = false;
		this.dgRecords.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(dgRecords_RowClick);
		this.dgRecords.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(dgRecords_FocusedRowChanged);
		this.dgRecords.ColumnFilterChanged += new System.EventHandler(dgRecords_ColumnFilterChanged);
		this.dgRecords.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(dgRecords_CustomColumnDisplayText);
		this.dgRecords.KeyDown += new System.Windows.Forms.KeyEventHandler(dgRecords_KeyDown);
		this.colNo.Caption = "#";
		this.colNo.Name = "colNo";
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 52;
		this.colName.Caption = "Name";
		this.colName.FieldName = "fullName";
		this.colName.Name = "colName";
		this.colName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "fullName", "TOTAL STUDENTS: {0:#,#}")
		});
		this.colName.Visible = true;
		this.colName.VisibleIndex = 1;
		this.colName.Width = 264;
		this.colStudentNo.Caption = "StudentNo";
		this.colStudentNo.FieldName = "StudentNumber";
		this.colStudentNo.Name = "colStudentNo";
		this.colStudentNo.Visible = true;
		this.colStudentNo.VisibleIndex = 2;
		this.colStudentNo.Width = 205;
		this.colSourceClass.Caption = "Former Class";
		this.colSourceClass.FieldName = "ClassId";
		this.colSourceClass.Name = "colSourceClass";
		this.colSourceClass.Visible = true;
		this.colSourceClass.VisibleIndex = 3;
		this.colSourceClass.Width = 84;
		this.colStream.Caption = "Stream";
		this.colStream.FieldName = "StreamId";
		this.colStream.Name = "colStream";
		this.colStream.Width = 41;
		this.colDB.Caption = "DB";
		this.colDB.FieldName = "StudyStatus";
		this.colDB.Name = "colDB";
		this.colDB.Visible = true;
		this.colDB.VisibleIndex = 4;
		this.colDB.Width = 61;
		this.colSex.Caption = "Sex";
		this.colSex.FieldName = "Sex";
		this.colSex.Name = "colSex";
		this.colSex.Visible = true;
		this.colSex.VisibleIndex = 5;
		this.colSex.Width = 61;
		this.colStudNotes.Caption = "Notes";
		this.colStudNotes.FieldName = "Notes";
		this.colStudNotes.Name = "colStudNotes";
		this.colPicture.Caption = "Picture";
		this.colPicture.FieldName = "Picture";
		this.colPicture.Name = "colPicture";
		this.colBursaryStatus.Caption = "Bursary status";
		this.colBursaryStatus.FieldName = "BursaryStatus";
		this.colBursaryStatus.Name = "colBursaryStatus";
		this.colBursaryProvider.Caption = "Bursary prov";
		this.colBursaryProvider.FieldName = "BursaryProvider";
		this.colBursaryProvider.Name = "colBursaryProvider";
		this.colFees.Caption = "Fees";
		this.colFees.DisplayFormat.FormatString = "{0:#,#.0}";
		this.colFees.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colFees.FieldName = "RequiredFees";
		this.colFees.Name = "colFees";
		this.colFormerSchool.Caption = "Former school";
		this.colFormerSchool.FieldName = "FormerSchool";
		this.colFormerSchool.Name = "colFormerSchool";
		this.colAdmitDate.Caption = "Admit date";
		this.colAdmitDate.FieldName = "AdmissionDate";
		this.colAdmitDate.Name = "colAdmitDate";
		this.colHouse.Caption = "House";
		this.colHouse.FieldName = "HouseId";
		this.colHouse.Name = "colHouse";
		this.colHouse.Visible = true;
		this.colHouse.VisibleIndex = 6;
		this.colHouse.Width = 148;
		this.colGuardian.Caption = "Guardian";
		this.colGuardian.FieldName = "Guardian";
		this.colGuardian.Name = "colGuardian";
		this.colReligion.Caption = "Religion";
		this.colReligion.FieldName = "Religion";
		this.colReligion.Name = "colReligion";
		this.colReligion.Visible = true;
		this.colReligion.VisibleIndex = 7;
		this.colReligion.Width = 219;
		this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[2]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)
		});
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		this.barButtonItem9.Caption = "Re-assign Class";
		this.barButtonItem9.Id = 9;
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.barButtonItem2.Caption = "Delete Student";
		this.barButtonItem2.Id = 1;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barManager1.DockControls.Add(this.barDockControlTop);
		this.barManager1.DockControls.Add(this.barDockControlBottom);
		this.barManager1.DockControls.Add(this.barDockControlLeft);
		this.barManager1.DockControls.Add(this.barDockControlRight);
		this.barManager1.Form = this;
		this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[10] { this.barButtonItem1, this.barButtonItem2, this.barButtonItem3, this.barButtonItem4, this.barButtonItem5, this.barSubItem1, this.barButtonItem6, this.barButtonItem7, this.barButtonItem8, this.barButtonItem9 });
		this.barManager1.MaxItemId = 10;
		this.barDockControlTop.CausesValidation = false;
		this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
		this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
		this.barDockControlTop.Manager = this.barManager1;
		this.barDockControlTop.Size = new System.Drawing.Size(946, 0);
		this.barDockControlBottom.CausesValidation = false;
		this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 517);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(946, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 517);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(946, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 517);
		this.barButtonItem1.Caption = "Edit Student";
		this.barButtonItem1.Id = 0;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem3.Caption = "Receive Fees";
		this.barButtonItem3.Id = 2;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem4.Caption = "Print";
		this.barButtonItem4.Id = 3;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem5.Caption = "Create Gatepass";
		this.barButtonItem5.Id = 4;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barSubItem1.Caption = "Assign Class";
		this.barSubItem1.Id = 5;
		this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[3]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8)
		});
		this.barSubItem1.Name = "barSubItem1";
		this.barButtonItem6.Caption = "Fees";
		this.barButtonItem6.Id = 6;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem7.Caption = "Medical";
		this.barButtonItem7.Id = 7;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem8.Caption = "General";
		this.barButtonItem8.Id = 8;
		this.barButtonItem8.Name = "barButtonItem8";
		this.layoutControl1.Controls.Add(this.panelControl7);
		this.layoutControl1.Controls.Add(this.gridStudentRecords);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(420, 288, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(946, 517);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(946, 517);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem2.Control = this.gridStudentRecords;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(738, 513);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem3.Control = this.panelControl7;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(738, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(204, 513);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrStudentListNA";
		base.Size = new System.Drawing.Size(946, 517);
		((System.ComponentModel.ISupportInitialize)this.panelControl7).EndInit();
		this.panelControl7.ResumeLayout(false);
		this.panelControl7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.picStudent.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgRecords).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
