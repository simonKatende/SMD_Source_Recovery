using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.ReportHeaders;
using AlienAge.Semesters;
using BiotimeDevice;
using DevExpress.Data.Linq;
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
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraTab;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.GeneralReports;
using I_Xtreme.Properties;
using SMDFastLane.AppData;
using SMDFastLane.Models;
using zkemkeeper;

namespace I_Xtreme.NavigationForms;

public class usrStudentList : XtraUserControl
{
	private int machineNumber = 1;

	private string _Name = string.Empty;

	private string password = "123456";

	private int fingerIndex = 0;

	private string userId = "";

	private string guardianEmail = string.Empty;

	private string sex = string.Empty;

	private double amount = 0.0;

	private string amountInWords = string.Empty;

	private string StudentClass = string.Empty;

	private string connection = string.Empty;

	private StartOrStopTimer StartTimer;

	private SqlTransaction transaction;

	public StatusMessage StatusMessage;

	private IContainer components = null;

	private PanelControl panelControl7;

	private PictureEdit pictureEdit8;

	private LabelControl lblName;

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

	private NavBarControl navBarControl1;

	private NavBarGroup navBarGroup1;

	private NavBarItem navBarItem4;

	private NavBarItem navBarItem5;

	private NavBarItem navBarItem1;

	private NavBarItem navBarItem2;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem3;

	private NavBarItem navBarItem6;

	private NavBarItem navBarItem12;

	private NavBarItem navBarItem15;

	private NavBarItem navBarItem16;

	private NavBarItem navBarItem18;

	private XtraTabControl xtraTabControl1;

	private XtraTabPage xtraTabPage1;

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

	private XtraTabPage xtraTabPage2;

	private XtraTabPage xtraTabPage3;

	private LabelControl lblStudentAdmitDate;

	private LabelControl labelControl156;

	private LabelControl lblGuardianAddress;

	private LabelControl labelControl154;

	private LabelControl labelControl153;

	private LabelControl Guardian;

	private LabelControl lblGuardianPhone;

	private LabelControl lblGuardianName;

	private LabelControl labelControl159;

	private LabelControl labelControl158;

	private LabelControl labelControl157;

	private LabelControl lblStudentFees;

	private LabelControl lblStudentBursaryProv;

	private LabelControl lblStudentBursary;

	private LabelControl labelControl1;

	private MemoEdit txtNotes;

	private BarButtonItem barButtonItem9;

	private GridControl gridStudentRecords;

	private GridView gv;

	private LayoutControlItem layoutControlItem4;

	private GridColumn colNo;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn37;

	private GridColumn gridColumn41;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private GridColumn gridColumn12;

	private GridColumn gridColumn45;

	private GridColumn gridColumn44;

	private GridColumn gridColumn43;

	private GridColumn gridColumn47;

	private GridColumn gridColumn42;

	private GridColumn gridColumn13;

	private GridColumn gridColumn14;

	private GridColumn gridColumn15;

	private GridColumn gridColumn16;

	private GridColumn gridColumn17;

	private GridColumn gridColumn18;

	private GridColumn gridColumn19;

	private GridColumn gridColumn20;

	private GridColumn gridColumn21;

	private GridColumn gridColumn22;

	private GridColumn gridColumn23;

	private GridColumn gridColumn24;

	private GridColumn gridColumn25;

	private GridColumn gridColumn26;

	private GridColumn gridColumn27;

	private GridColumn gridColumn34;

	private GridColumn gridColumn28;

	private GridColumn gridColumn29;

	private GridColumn gridColumn30;

	private GridColumn gridColumn31;

	private GridColumn gridColumn33;

	private GridColumn gridColumn32;

	private GridColumn gridColumn35;

	private GridColumn gridColumn36;

	private GridColumn gridColumn38;

	private GridColumn gridColumn39;

	private GridColumn gridColumn40;

	private EntityInstantFeedbackSource entityInstantFeedbackSource1;

	private GridColumn gridColumn1;

	private XtraTabPage xtraTabPage4;

	private SimpleButton simpleButton1;

	private LabelControl lblStatus;

	private ProgressBarControl progressBarControl1;

	public string errorMessage { get; set; }

	public usrStudentList(string StudentClass)
	{
		InitializeComponent();
		this.StudentClass = StudentClass;
		LoadStudents();
	}

	private void EntityInstantFeedbackSource1_DismissQueryable(object sender, GetQueryableEventArgs e)
	{
		((SMDDBContext)e.Tag).Dispose();
	}

	private void EntityInstantFeedbackSource1_GetQueryable(object sender, GetQueryableEventArgs e)
	{
		int num = 0;
		SMDDBContext sMDDBContext = new SMDDBContext();
		if (StudentOptions.LoadingMode() == "Auto")
		{
			string[] array = Classes.ListOfClasses().Split();
			foreach (string _class in array)
			{
				IQueryable<Student> source = sMDDBContext.Students.Where((Student p) => p.ClassId.Equals(_class) && p.Status.Equals("Active"));
				num = source.Count();
				e.QueryableSource = source.AsQueryable();
				e.Tag = sMDDBContext;
				if (num > 0)
				{
					StudentClass = _class;
					break;
				}
			}
		}
		else
		{
			if (!(StudentOptions.LoadingMode() == "Custom"))
			{
				return;
			}
			if (StudentClass == "All")
			{
				SMDDBContext sMDDBContext2 = new SMDDBContext();
				IQueryable<Student> source2 = sMDDBContext2.Students.Where((Student p) => p.Status.Equals("Active"));
				e.QueryableSource = source2.AsQueryable();
				e.Tag = sMDDBContext2;
			}
			else
			{
				SMDDBContext sMDDBContext3 = new SMDDBContext();
				IQueryable<Student> source3 = sMDDBContext3.Students.Where((Student p) => p.ClassId.Equals(StudentClass) && p.Status.Equals("Active"));
				e.QueryableSource = source3.AsQueryable();
				e.Tag = sMDDBContext3;
			}
			StudentOptions.SetActiveClass(StudentClass);
			ActiveFormSelected.SetActiveForm(StudentClass + " Students' List");
		}
	}

	private void LoadStudents()
	{
		try
		{
			entityInstantFeedbackSource1.GetQueryable += EntityInstantFeedbackSource1_GetQueryable;
			entityInstantFeedbackSource1.DismissQueryable += EntityInstantFeedbackSource1_DismissQueryable;
			PrintableControl.SavePrintableControl(gridStudentRecords);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show("Error", ex.Message.ToString());
		}
	}

	public void StudentCallBackFN(bool timerStatus)
	{
		if (timerStatus)
		{
			LoadStudents();
		}
	}

	private void dgRecords_ColumnFilterChanged(object sender, EventArgs e)
	{
		gv.FocusedRowHandle = -1;
	}

	private void GetFocusedStudentRecord(int i)
	{
		byte[] array = new byte[0];
		if (!string.IsNullOrEmpty(gv.GetRowCellValue(i, "Picture").ToString()))
		{
			array = (byte[])gv.GetRowCellValue(i, "Picture");
			using MemoryStream stream = new MemoryStream(array);
			pictureEdit8.Image = Image.FromStream(stream);
		}
		string text = gv.GetRowCellValue(i, "fullName").ToString();
		string text2 = gv.GetRowCellValue(i, "StudentNumber").ToString();
		lblName.Text = text;
		lblStudentClass.Text = gv.GetRowCellValue(i, "ClassId").ToString();
		lblStudentStream.Text = gv.GetRowCellValue(i, "StreamId").ToString();
		lblStudentNo.Text = text2;
		lblStudentDB.Text = gv.GetRowCellValue(i, "StudyStatus").ToString();
		lblStudentAdmitDate.Text = gv.GetRowCellValue(i, "AdmissionDate").ToString();
		double result = (double.TryParse(gv.GetRowCellValue(i, "RequiredFees").ToString(), out result) ? result : 0.0);
		lblStudentFees.Text = result.ToString("#,#.0");
		object rowCellValue = gv.GetRowCellValue(i, "Guardian");
		if (rowCellValue != null)
		{
			lblGuardianName.Text = rowCellValue.ToString();
		}
		else
		{
			lblGuardianName.Text = "";
		}
		object rowCellValue2 = gv.GetRowCellValue(i, "PriorityContact");
		if (rowCellValue2 != null)
		{
			lblGuardianPhone.Text = rowCellValue2.ToString();
		}
		else
		{
			lblGuardianPhone.Text = "";
		}
		object rowCellValue3 = gv.GetRowCellValue(i, "GuardianAddress");
		if (rowCellValue3 != null)
		{
			lblGuardianAddress.Text = rowCellValue3.ToString();
		}
		else
		{
			lblGuardianAddress.Text = "";
		}
		object rowCellValue4 = gv.GetRowCellValue(i, "Email");
		if (rowCellValue4 != null)
		{
			guardianEmail = rowCellValue4.ToString();
		}
		else
		{
			guardianEmail = "";
		}
		popupMenu1.MenuCaption = gv.GetRowCellValue(i, "fullName").ToString();
		sex = gv.GetRowCellValue(i, "Sex").ToString();
		amount = (double.TryParse(gv.GetRowCellValue(i, "cashOnAccount").ToString(), out amount) ? amount : 0.0);
		NumberToWordsConverter numberToWordsConverter = new NumberToWordsConverter();
		amountInWords = numberToWordsConverter.NumberToWords((long)amount).ToString();
		navBarGroup1.Caption = gv.GetRowCellValue(i, "fullName").ToString();
		StudentOptions.SetActiveStudent(gv.GetRowCellValue(i, "StudentNumber").ToString().ToUpper());
		StudentForCapture.SetStudentForCapture(text2, text);
		userId = text2;
		password = text2;
		if (userId.Length >= 10)
		{
			userId = text2.Substring(1, 9);
		}
		_Name = text.PadRight(24).Substring(0, 24).Trim();
	}

	private void dgRecords_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (gv.GetFocusedDataSourceRowIndex() > -1)
		{
			GetFocusedStudentRecord(gv.GetFocusedDataSourceRowIndex());
		}
	}

	private void dgRecords_RowClick(object sender, RowClickEventArgs e)
	{
		if (gv.GetFocusedDataSourceRowIndex() > -1)
		{
			GetFocusedStudentRecord(gv.GetFocusedDataSourceRowIndex());
			if (e.Button == MouseButtons.Right)
			{
				popupMenu1.ShowCaption = true;
				popupMenu1.ShowPopup(Control.MousePosition);
			}
			else
			{
				popupMenu1.HidePopup();
			}
		}
		StudentOptions.SetRowHandle(gv.FocusedRowHandle);
	}

	private void dgRecords_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Apps)
		{
			popupMenu1.ShowCaption = true;
			popupMenu1.MenuCaption = gv.GetRowCellValue(gv.GetFocusedDataSourceRowIndex(), "fullName").ToString();
			popupMenu1.ShowPopup(Control.MousePosition);
		}
		else
		{
			popupMenu1.HidePopup();
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (StudentOptions.ActiveStudent() != string.Empty)
		{
			using (editStudents editStudents = new editStudents(EditMode: true))
			{
				editStudents.Text = "Edit Student details";
				StudentOptions.ChangeLoadingMode("Custom");
				editStudents.txtStudentNumber.Text = StudentOptions.ActiveStudent();
				if (editStudents.ShowDialog() == DialogResult.OK)
				{
					LoadStudents();
				}
				return;
			}
		}
		XtraMessageBox.Show("Please select a student you wish to edit", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		using ConfirmDelete confirmDelete = new ConfirmDelete();
		confirmDelete.lblDeleteWhat.Text = "student";
		confirmDelete.StartTimer = StudentCallBackFN;
		confirmDelete.ShowDialog();
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		StudentOptions.SetActiveStudent(lblStudentNo.Text);
		StudentOptions.SetPaymentMode("SingleStudent");
		using StudentFeesPayment studentFeesPayment = new StudentFeesPayment("SingleStudentPayment");
		studentFeesPayment.ShowDialog();
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		try
		{
			using (new StudentPreview())
			{
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to create a Gate Pass for: " + lblName.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			StudentOptions.SetActiveClass(lblStudentClass.Text);
			StudentGatePasses.CreateStudentGatePass("Student Fees GatePass", lblStudentNo.Text, lblName.Text, lblStudentClass.Text, lblStudentStream.Text, lblStudentDB.Text, lblGuardianName.Text, pictureEdit8.Image, sex, amount, amountInWords);
			StudentGatePasses.ShowFeesGatePass();
		}
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to create a Gate Pass for: " + lblName.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			StudentOptions.SetActiveClass(lblStudentClass.Text);
			StudentGatePasses.CreateStudentGatePass("Student Medical GatePass", lblStudentNo.Text, lblName.Text, lblStudentClass.Text, lblStudentStream.Text, lblStudentDB.Text, lblGuardianName.Text, pictureEdit8.Image, sex, amount, amountInWords);
			StudentGatePasses.ShowMedicalGatePass();
		}
	}

	private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
	{
		using generalGatePass generalGatePass = new generalGatePass(lblStudentClass.Text);
		StudentOptions.SetActiveClass(lblStudentClass.Text);
		generalGatePass.lblSemester.Text = WorkingSemesters.GetWorkingSemester();
		generalGatePass.lblStudentNo.Text = lblStudentNo.Text;
		generalGatePass.lblCurrentUsers.Text = CurrentUser.GetSystemUser();
		generalGatePass.lblNames.Text = lblName.Text;
		generalGatePass.pictureEdit1.Image = pictureEdit8.Image;
		generalGatePass.sex = sex;
		generalGatePass.streamId = lblStudentStream.Text;
		generalGatePass.db = lblStudentDB.Text;
		generalGatePass.guardian = lblGuardianName.Text;
		generalGatePass.ShowDialog();
	}

	private void navBarItem5_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		if (PrintableControl.GridViewControl.FocusedRowHandle > -1)
		{
			using (ConfirmDelete confirmDelete = new ConfirmDelete())
			{
				confirmDelete.lblDeleteWhat.Text = "student";
				confirmDelete.StartTimer = StudentCallBackFN;
				confirmDelete.ShowDialog();
			}
		}
	}

	private void navBarItem4_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		if (StudentOptions.ActiveStudent() != string.Empty)
		{
			using (editStudents editStudents = new editStudents(EditMode: true))
			{
				editStudents.Text = "Edit Student details";
				StudentOptions.ChangeLoadingMode("Custom");
				editStudents.txtStudentNumber.Text = StudentOptions.ActiveStudent();
				if (editStudents.ShowDialog() == DialogResult.OK)
				{
					LoadStudents();
				}
				return;
			}
		}
		XtraMessageBox.Show("Please select a student you wish to edit", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void navBarItem2_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		try
		{
			using StudentPreview studentPreview = new StudentPreview();
			studentPreview.StudentNo.Value = lblStudentNo.Text;
			ReportPrintTool reportPrintTool = new ReportPrintTool(studentPreview);
			reportPrintTool.ShowRibbonPreviewDialog();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void navBarItem1_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		try
		{
			using StudentPreview studentPreview = new StudentPreview();
			studentPreview.StudentNo.Value = lblStudentNo.Text;
			ReportPrintTool reportPrintTool = new ReportPrintTool(studentPreview);
			reportPrintTool.PrintDialog();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void navBarItem6_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		if (gv.GetFocusedDataSourceRowIndex() > -1)
		{
			using (generalGatePass generalGatePass = new generalGatePass(lblStudentNo.Text))
			{
				StudentOptions.SetActiveClass(lblStudentClass.Text);
				generalGatePass.lblSemester.Text = WorkingSemesters.GetWorkingSemester();
				generalGatePass.lblStudentNo.Text = lblStudentNo.Text;
				generalGatePass.lblCurrentUsers.Text = CurrentUser.GetSystemUser();
				generalGatePass.lblNames.Text = lblName.Text;
				generalGatePass.pictureEdit1.Image = pictureEdit8.Image;
				generalGatePass.sex = sex;
				generalGatePass.streamId = lblStudentStream.Text;
				generalGatePass.db = lblStudentDB.Text;
				generalGatePass.guardian = lblGuardianName.Text;
				generalGatePass.ShowDialog();
				return;
			}
		}
		XtraMessageBox.Show("Please select a student from the list.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private void navBarItem7_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		StudentOptions.SetActiveStudent(lblStudentNo.Text);
		StudentOptions.SetActiveClass(lblStudentClass.Text);
		StudentOptions.SetPaymentMode("SingleStudent");
		using StudentFeesPayment studentFeesPayment = new StudentFeesPayment("SingleStudentPayment");
		studentFeesPayment.ShowDialog();
	}

	private void navBarItem18_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		using SMSGuardian sMSGuardian = new SMSGuardian();
		sMSGuardian.txtReceipient.Text = lblGuardianPhone.Text;
		if (sMSGuardian.ShowDialog() == System.Windows.Forms.DialogResult.OK
			&& !string.IsNullOrEmpty(lblStudentNo.Text))
		{
			try
			{
				new I_Xtreme.ExtremeClasses.FeesFollowUpService().LogContact(
					new I_Xtreme.Models.FeesContactLog
					{
						StudentNumber = lblStudentNo.Text,
						ContactDate   = System.DateTime.Now,
						LoggedBy      = CurrentUser.GetSystemUser(),
						Channel       = I_Xtreme.Models.ContactChannel.SMS,
						Outcome       = I_Xtreme.Models.ContactOutcome.Contacted,
						Note          = string.IsNullOrWhiteSpace(sMSGuardian.SentMessage)
										? "SMS sent from Students tab"
										: sMSGuardian.SentMessage,
					});
			}
			catch (System.Exception logEx)
			{
				// Non-critical: auto-log failure must never interrupt the user's SMS flow
				System.Diagnostics.Debug.WriteLine(
					$"FeesFollowUp auto-log failed for {lblStudentNo.Text}: {logEx.Message}");
			}
		}
	}

	private void navBarItem15_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		using StudentSubjectRegistration studentSubjectRegistration = new StudentSubjectRegistration(string.Empty);
		int selectedIndex = 1;
		studentSubjectRegistration.radioGroupMode.SelectedIndex = selectedIndex;
		studentSubjectRegistration.txtName.Text = lblName.Text;
		studentSubjectRegistration.txtClass.Text = lblStudentClass.Text;
		studentSubjectRegistration.txtStream.Text = lblStudentStream.Text;
		studentSubjectRegistration.studentClass = lblStudentClass.Text;
		studentSubjectRegistration.pictureEdit14.Image = pictureEdit8.Image;
		studentSubjectRegistration.StudentNumber = lblStudentNo.Text;
		studentSubjectRegistration.radioGroupMode.Enabled = false;
		studentSubjectRegistration.lookUpClasses.Enabled = false;
		studentSubjectRegistration.searchLookUpEdit1.Properties.ReadOnly = true;
		studentSubjectRegistration.ShowDialog();
	}

	private void navBarItem16_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		SubjectDropingMode.DropFromMainForm(DropMode: false);
		using dropSubjects dropSubjects = new dropSubjects(string.Empty);
		int selectedIndex = 0;
		dropSubjects.radioGroupDrop.SelectedIndex = selectedIndex;
		dropSubjects.txtName.Text = lblName.Text;
		dropSubjects.txtClass.Text = lblStudentClass.Text;
		dropSubjects.studentClass = lblStudentClass.Text;
		dropSubjects.txtStream.Text = lblStudentStream.Text;
		dropSubjects.studentNo = lblStudentNo.Text;
		dropSubjects.pictureEdit1.Image = pictureEdit8.Image;
		dropSubjects.classLevel = "OLevel";
		dropSubjects.lookUpClasses.Enabled = false;
		dropSubjects.radioGroupDrop.Enabled = false;
		dropSubjects.searchLookUpEdit1.Enabled = false;
		dropSubjects.ShowDialog();
	}

	private void dgRecords_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.Name == "colNo")
		{
			e.DisplayText = (gv.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();
		}
	}

	private void navBarItem12_LinkClicked(object sender, NavBarLinkEventArgs e)
	{
		if (gv.GetFocusedDataSourceRowIndex() > -1)
		{
			WaitDialogForm waitDialogForm = new WaitDialogForm();
			try
			{
				waitDialogForm.SetCaption("Client Email Application is loading");
				string empty = string.Empty;
				empty = ((!(empty == string.Empty)) ? guardianEmail : "guardian_email@domain.com");
				Process.Start($"mailto:{empty}?subject={ReportHeader.SchoolName}");
				waitDialogForm.Close();
			}
			catch (Exception ex)
			{
				waitDialogForm.Close();
				XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void usrStudentList_Load(object sender, EventArgs e)
	{
		if (CurrentUser.GetSystemUser().Contains("Admin"))
		{
			navBarItem5.Enabled = true;
			barButtonItem2.Enabled = true;
			navBarItem4.Enabled = true;
			barButtonItem1.Enabled = true;
			navBarItem6.Enabled = true;
			barSubItem1.Enabled = true;
			navBarItem12.Enabled = true;
			navBarItem18.Enabled = true;
			barButtonItem3.Enabled = true;
			navBarItem15.Enabled = true;
			navBarItem16.Enabled = true;
		}
		else if (CurrentUser.GetSystemUser().Contains("Bursar"))
		{
			navBarItem5.Enabled = true;
			barButtonItem2.Enabled = true;
			navBarItem4.Enabled = true;
			barButtonItem1.Enabled = true;
			navBarItem6.Enabled = true;
			barSubItem1.Enabled = true;
			navBarItem12.Enabled = true;
			navBarItem18.Enabled = true;
			barButtonItem3.Enabled = true;
			navBarItem15.Enabled = false;
			navBarItem16.Enabled = false;
		}
		else if (CurrentUser.GetSystemUser().Contains("Secretary"))
		{
			navBarItem5.Enabled = false;
			barButtonItem2.Enabled = false;
			navBarItem4.Enabled = false;
			barButtonItem1.Enabled = false;
			navBarItem6.Enabled = false;
			barSubItem1.Enabled = false;
			navBarItem12.Enabled = false;
			navBarItem18.Enabled = false;
			barButtonItem3.Enabled = false;
			navBarItem15.Enabled = false;
			navBarItem16.Enabled = false;
		}
		else if (CurrentUser.GetSystemUser().Contains("Librarian"))
		{
			navBarItem5.Enabled = false;
			barButtonItem2.Enabled = false;
			navBarItem4.Enabled = false;
			barButtonItem1.Enabled = false;
			navBarItem6.Enabled = false;
			barSubItem1.Enabled = false;
			navBarItem12.Enabled = false;
			navBarItem18.Enabled = false;
			barButtonItem3.Enabled = false;
			navBarItem15.Enabled = false;
			navBarItem16.Enabled = false;
		}
		else if (CurrentUser.GetSystemUser().Contains("Registrar"))
		{
			navBarItem5.Enabled = false;
			barButtonItem2.Enabled = false;
			navBarItem4.Enabled = true;
			barButtonItem1.Enabled = true;
			navBarItem6.Enabled = true;
			barSubItem1.Enabled = true;
			barButtonItem6.Enabled = false;
			navBarItem12.Enabled = true;
			navBarItem18.Enabled = true;
			barButtonItem3.Enabled = false;
			navBarItem15.Enabled = false;
			navBarItem16.Enabled = false;
		}
		else if (CurrentUser.GetSystemUser().Contains("DOS"))
		{
			navBarItem5.Enabled = false;
			barButtonItem2.Enabled = false;
			navBarItem4.Enabled = true;
			barButtonItem1.Enabled = true;
			navBarItem6.Enabled = true;
			barSubItem1.Enabled = true;
			barButtonItem6.Enabled = false;
			navBarItem12.Enabled = true;
			navBarItem18.Enabled = true;
			barButtonItem3.Enabled = false;
			navBarItem15.Enabled = true;
			navBarItem16.Enabled = true;
		}
	}

	private void TransferCandidates()
	{
		try
		{
			string text = DataConnection.ConnectToDatabase();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Stud WHERE StudentNumber='" + StudentOptions.ActiveStudent() + "'", text);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count <= 0)
			{
				return;
			}
			DataRow dataRow = dataTable.Rows[0];
			Guid result = (Guid.TryParse(dataRow["Oid"].ToString(), out result) ? result : Guid.NewGuid());
			using SqlConnection sqlConnection = new SqlConnection(text);
			sqlConnection.Open();
			transaction = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_oldStudents (StudentNumber,HouseId,StreamId,Oid,FormerSchool,StudyStatus,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Sex,Picture,Religion,HomeCountry,fullName,Status,Notes,cashOnAccount,ClassId,ExitYear,Guardian,PriorityContact,OtherContact,GuardianAddress)VALUES(@StudentNumber,@HouseId,@StreamId,@Oid,@FormerSchool,@StudyStatus,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Sex,@Picture,@Religion,@HomeCountry,@fullName,@Status,@Notes,@cashOnAccount,@ClassId,@ExitYear,@Guardian,@PriorityContact,@OtherContact,@GuardianAddress)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = dataRow["StudentNumber"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 25);
				sqlParameter.Value = dataRow["HouseId"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 8);
				sqlParameter.Value = dataRow["StreamId"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = result;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@FormerSchool", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["FormerSchool"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@StudyStatus", SqlDbType.VarChar, 1);
				sqlParameter.Value = dataRow["StudyStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.VarChar, 7);
				sqlParameter.Value = dataRow["BursaryStatus"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(dataRow["RequiredFees"]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["BursaryProvider"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.VarChar, 4);
				sqlParameter.Value = dataRow["AdmissionDate"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Sex", SqlDbType.VarChar, 1);
				sqlParameter.Value = dataRow["Sex"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
				sqlParameter.Value = dataRow["Picture"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["Religion"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["HomeCountry"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["fullName"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Notes", SqlDbType.VarChar);
				sqlParameter.Value = dataRow["Notes"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 15);
				sqlParameter.Value = dataRow["Status"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@cashOnAccount", SqlDbType.Money);
				sqlParameter.Value = Convert.ToDouble(dataRow["cashOnAccount"]);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 3);
				sqlParameter.Value = lblStudentClass.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ExitYear", SqlDbType.Int);
				sqlParameter.Value = DateTime.Now.Year;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["Guardian"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PriorityContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = dataRow["PriorityContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@OtherContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = dataRow["OtherContact"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = dataRow["GuardianAddress"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM tbl_Stud WHERE StudentNumber='{0}'", dataRow["StudentNumber"].ToString()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM tbl_Scores_OL_Report WHERE StudentNumber='{0}'", dataRow["StudentNumber"].ToString()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand3.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM tbl_Scores_AL WHERE StudentNumber='{0}'", dataRow["StudentNumber"].ToString()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand5 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM tbl_GeneralReport_Grading_AL WHERE StudentNumber='{0}'", dataRow["StudentNumber"].ToString()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand5.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand6 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM tbl_GeneralReport_AL WHERE StudentNumber='{0}'", dataRow["StudentNumber"].ToString()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand6.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand7 = new SqlCommand
			{
				Transaction = transaction,
				Connection = sqlConnection,
				CommandText = string.Format("DELETE FROM tbl_ALevelReport WHERE StudentNumber='{0}'", dataRow["StudentNumber"].ToString()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand7.ExecuteNonQuery();
			}
			transaction.Commit();
			sqlConnection.Close();
			XtraMessageBox.Show("Transfer successful", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			StartTimer(timerStatus: true);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (lblStudentClass.Text == "S.4" || lblStudentClass.Text == "S.6")
		{
			StudentOptions.ChangeLoadingMode("Custom");
			StartTimer = StudentCallBackFN;
			TransferCandidates();
		}
		else
		{
			XtraMessageBox.Show("Sorry we cannot do that! This action is valid for candidate classes only.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private async void simpleButton1_Click(object sender, EventArgs e)
	{
		await StartUserEnrollmentAsync();
	}

	private async Task StartUserEnrollmentAsync()
	{
		((IZKEM)BiometricDevice.Device).RefreshData(machineNumber);
		((IZKEM)BiometricDevice.Device).EnableDevice(machineNumber, false);
		await Task.Delay(500);
		string TempFPID = "122";
		if (((IZKEM)BiometricDevice.Device).StartEnroll(Convert.ToInt32(TempFPID), fingerIndex))
		{
			StatusMessage("Please place your finger on the device...", "Ready");
		}
	}

	private async void Device_OnEnrollFinger(int enrollNumber, int fingerIndex, int actionResult, int templateLength)
	{
		byte[] fingerprintTemplate = new byte[602];
		((IZKEM)BiometricDevice.Device).EnableDevice(machineNumber, false);
		if (!((IZKEM)BiometricDevice.Device).SSR_GetUserTmp(machineNumber, "z", fingerIndex, out fingerprintTemplate[0], out templateLength))
		{
			await HandleEnrollmentFailureAsync("Failed to capture FP. Please try again");
			((IZKEM)BiometricDevice.Device).EnableDevice(machineNumber, true);
			return;
		}
		if (!((IZKEM)BiometricDevice.Device).SSR_SetUserInfo(machineNumber, userId, _Name, password, 0, true))
		{
			await HandleEnrollmentFailureAsync("Failed to save user information.");
			((IZKEM)BiometricDevice.Device).EnableDevice(machineNumber, true);
			return;
		}
		if (!((IZKEM)BiometricDevice.Device).SSR_SetUserTmp(machineNumber, userId, fingerIndex, ref fingerprintTemplate[0]))
		{
			await HandleEnrollmentFailureAsync("Failed to save FP Data.");
			((IZKEM)BiometricDevice.Device).EnableDevice(machineNumber, true);
			return;
		}
		if (!(await DeleteTemporaryEnrollmentDataAsync()))
		{
			StatusMessage("Failed to delete temporary fingerprint data.", "Failure");
		}
		((IZKEM)BiometricDevice.Device).RefreshData(machineNumber);
		((IZKEM)BiometricDevice.Device).EnableDevice(machineNumber, true);
		StatusMessage("Success", "Captured");
	}

	private async Task HandleEnrollmentFailureAsync(string errorMessage)
	{
		((IZKEM)BiometricDevice.Device).SSR_DeleteEnrollData(machineNumber, "z", 12);
		((IZKEM)BiometricDevice.Device).RefreshData(machineNumber);
		StatusMessage(errorMessage, "Failure");
	}

	private async Task<bool> DeleteTemporaryEnrollmentDataAsync()
	{
		bool isDeleted = false;
		for (int attempt = 0; attempt < 3; attempt++)
		{
			isDeleted = ((IZKEM)BiometricDevice.Device).SSR_DeleteEnrollData(machineNumber, "z", 12);
			((IZKEM)BiometricDevice.Device).RefreshData(machineNumber);
			if (isDeleted)
			{
				break;
			}
			await Task.Delay(100);
		}
		return isDeleted;
	}

	private bool IsDeviceConnected()
	{
		return ((IZKEM)BiometricDevice.Device).Connect_Net(BiometricDeviceInMemory.IpAddress, BiometricDeviceInMemory.Port);
	}

	private void Device_OnFingerFeature(int Score)
	{
		if (progressBarControl1.InvokeRequired)
		{
			progressBarControl1.Invoke((Action)delegate
			{
				progressBarControl1.Position = Score;
			});
		}
		else
		{
			progressBarControl1.Position = Score;
		}
	}

	private void Device_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
	{
		string text = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;
	}

	private void UploadFingerData()
	{
		Thread.Sleep(200);
		if (!((IZKEM)BiometricDevice.Device).SSR_SetUserInfo(machineNumber, userId, _Name, password, 0, true))
		{
			StatusMessage("Failed to save user information.", "Failure");
			return;
		}
		Thread.Sleep(200);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT BiometricData, FingerData from tbl_Stud WHERE StudentNumber = '4443401416'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		byte[] array = new byte[0];
		array = (byte[])dataTable.Rows[0]["FingerData"];
		int num = array.Length;
		if (!((IZKEM)BiometricDevice.Device).SSR_SetUserTmp(machineNumber, userId, fingerIndex, ref array[num]))
		{
			StatusMessage("Saving FP failed", "Failure");
			return;
		}
		StatusMessage("Success", "Saved");
		Thread.Sleep(200);
		((IZKEM)BiometricDevice.Device).RefreshData(machineNumber);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.usrStudentList));
		this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
		this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
		this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
		this.lblStudentAdmitDate = new DevExpress.XtraEditors.LabelControl();
		this.labelControl156 = new DevExpress.XtraEditors.LabelControl();
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
		this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianAddress = new DevExpress.XtraEditors.LabelControl();
		this.labelControl154 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl153 = new DevExpress.XtraEditors.LabelControl();
		this.Guardian = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianPhone = new DevExpress.XtraEditors.LabelControl();
		this.lblGuardianName = new DevExpress.XtraEditors.LabelControl();
		this.labelControl159 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl158 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl157 = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentFees = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentBursaryProv = new DevExpress.XtraEditors.LabelControl();
		this.lblStudentBursary = new DevExpress.XtraEditors.LabelControl();
		this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
		this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
		this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
		this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
		this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
		this.lblStatus = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.pictureEdit8 = new DevExpress.XtraEditors.PictureEdit();
		this.lblName = new DevExpress.XtraEditors.LabelControl();
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
		this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
		this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem18 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem15 = new DevExpress.XtraNavBar.NavBarItem();
		this.navBarItem16 = new DevExpress.XtraNavBar.NavBarItem();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridStudentRecords = new DevExpress.XtraGrid.GridControl();
		this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
		this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.panelControl7).BeginInit();
		this.panelControl7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
		this.xtraTabControl1.SuspendLayout();
		this.xtraTabPage1.SuspendLayout();
		this.xtraTabPage2.SuspendLayout();
		this.xtraTabPage3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtNotes.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).BeginInit();
		this.xtraTabPage4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit8.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.navBarControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gv).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.panelControl7.Controls.Add(this.xtraTabControl1);
		this.panelControl7.Controls.Add(this.pictureEdit8);
		this.panelControl7.Controls.Add(this.lblName);
		this.panelControl7.Location = new System.Drawing.Point(709, 7);
		this.panelControl7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
		this.panelControl7.Name = "panelControl7";
		this.panelControl7.Size = new System.Drawing.Size(230, 623);
		this.panelControl7.TabIndex = 4;
		this.xtraTabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
		this.xtraTabControl1.Location = new System.Drawing.Point(5, 298);
		this.xtraTabControl1.Name = "xtraTabControl1";
		this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
		this.xtraTabControl1.Size = new System.Drawing.Size(220, 320);
		this.xtraTabControl1.TabIndex = 34;
		this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[4] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3, this.xtraTabPage4 });
		this.xtraTabPage1.Controls.Add(this.lblStudentAdmitDate);
		this.xtraTabPage1.Controls.Add(this.labelControl156);
		this.xtraTabPage1.Controls.Add(this.labelControl150);
		this.xtraTabPage1.Controls.Add(this.lblStudentHouse);
		this.xtraTabPage1.Controls.Add(this.lblStudentReligion);
		this.xtraTabPage1.Controls.Add(this.labelControl147);
		this.xtraTabPage1.Controls.Add(this.labelControl146);
		this.xtraTabPage1.Controls.Add(this.lblStudentDB);
		this.xtraTabPage1.Controls.Add(this.lblStudentStream);
		this.xtraTabPage1.Controls.Add(this.lblStudentClass);
		this.xtraTabPage1.Controls.Add(this.lblStudentNo);
		this.xtraTabPage1.Controls.Add(this.labelControl144);
		this.xtraTabPage1.Controls.Add(this.labelControl143);
		this.xtraTabPage1.Controls.Add(this.labelControl142);
		this.xtraTabPage1.Name = "xtraTabPage1";
		this.xtraTabPage1.Size = new System.Drawing.Size(194, 318);
		this.xtraTabPage1.Text = "General Info";
		this.lblStudentAdmitDate.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.lblStudentAdmitDate.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentAdmitDate.Appearance.Options.UseBackColor = true;
		this.lblStudentAdmitDate.Appearance.Options.UseFont = true;
		this.lblStudentAdmitDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.lblStudentAdmitDate.Location = new System.Drawing.Point(13, 210);
		this.lblStudentAdmitDate.Name = "lblStudentAdmitDate";
		this.lblStudentAdmitDate.Size = new System.Drawing.Size(0, 18);
		this.lblStudentAdmitDate.TabIndex = 67;
		this.labelControl156.Location = new System.Drawing.Point(13, 197);
		this.labelControl156.Name = "labelControl156";
		this.labelControl156.Size = new System.Drawing.Size(77, 13);
		this.labelControl156.TabIndex = 66;
		this.labelControl156.Text = "Admission Date:";
		this.labelControl150.Appearance.Options.UseTextOptions = true;
		this.labelControl150.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl150.Location = new System.Drawing.Point(13, 166);
		this.labelControl150.Name = "labelControl150";
		this.labelControl150.Size = new System.Drawing.Size(30, 13);
		this.labelControl150.TabIndex = 43;
		this.labelControl150.Text = "House";
		this.lblStudentHouse.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.lblStudentHouse.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentHouse.Appearance.Options.UseBackColor = true;
		this.lblStudentHouse.Appearance.Options.UseFont = true;
		this.lblStudentHouse.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.lblStudentHouse.Location = new System.Drawing.Point(13, 179);
		this.lblStudentHouse.Name = "lblStudentHouse";
		this.lblStudentHouse.Size = new System.Drawing.Size(0, 18);
		this.lblStudentHouse.TabIndex = 42;
		this.lblStudentReligion.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.lblStudentReligion.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentReligion.Appearance.Options.UseBackColor = true;
		this.lblStudentReligion.Appearance.Options.UseFont = true;
		this.lblStudentReligion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.lblStudentReligion.Location = new System.Drawing.Point(13, 148);
		this.lblStudentReligion.Name = "lblStudentReligion";
		this.lblStudentReligion.Size = new System.Drawing.Size(0, 18);
		this.lblStudentReligion.TabIndex = 41;
		this.labelControl147.Appearance.Options.UseTextOptions = true;
		this.labelControl147.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl147.Location = new System.Drawing.Point(13, 135);
		this.labelControl147.Name = "labelControl147";
		this.labelControl147.Size = new System.Drawing.Size(37, 13);
		this.labelControl147.TabIndex = 40;
		this.labelControl147.Text = "Religion";
		this.labelControl146.Appearance.Options.UseTextOptions = true;
		this.labelControl146.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl146.Location = new System.Drawing.Point(13, 104);
		this.labelControl146.Name = "labelControl146";
		this.labelControl146.Size = new System.Drawing.Size(17, 13);
		this.labelControl146.TabIndex = 39;
		this.labelControl146.Text = "D/B";
		this.lblStudentDB.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.lblStudentDB.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentDB.Appearance.Options.UseBackColor = true;
		this.lblStudentDB.Appearance.Options.UseFont = true;
		this.lblStudentDB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.lblStudentDB.Location = new System.Drawing.Point(13, 117);
		this.lblStudentDB.Name = "lblStudentDB";
		this.lblStudentDB.Size = new System.Drawing.Size(0, 18);
		this.lblStudentDB.TabIndex = 38;
		this.lblStudentStream.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.lblStudentStream.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentStream.Appearance.Options.UseBackColor = true;
		this.lblStudentStream.Appearance.Options.UseFont = true;
		this.lblStudentStream.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.lblStudentStream.Location = new System.Drawing.Point(13, 86);
		this.lblStudentStream.Name = "lblStudentStream";
		this.lblStudentStream.Size = new System.Drawing.Size(0, 18);
		this.lblStudentStream.TabIndex = 37;
		this.lblStudentClass.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentClass.Appearance.Options.UseFont = true;
		this.lblStudentClass.Location = new System.Drawing.Point(13, 55);
		this.lblStudentClass.Name = "lblStudentClass";
		this.lblStudentClass.Size = new System.Drawing.Size(0, 18);
		this.lblStudentClass.TabIndex = 36;
		this.lblStudentNo.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.lblStudentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStudentNo.Appearance.Options.UseBackColor = true;
		this.lblStudentNo.Appearance.Options.UseFont = true;
		this.lblStudentNo.Location = new System.Drawing.Point(13, 24);
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.Size = new System.Drawing.Size(0, 18);
		this.lblStudentNo.TabIndex = 35;
		this.labelControl144.Appearance.Options.UseTextOptions = true;
		this.labelControl144.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl144.Location = new System.Drawing.Point(13, 73);
		this.labelControl144.Name = "labelControl144";
		this.labelControl144.Size = new System.Drawing.Size(34, 13);
		this.labelControl144.TabIndex = 34;
		this.labelControl144.Text = "Stream";
		this.labelControl143.Appearance.Options.UseTextOptions = true;
		this.labelControl143.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl143.Location = new System.Drawing.Point(13, 42);
		this.labelControl143.Name = "labelControl143";
		this.labelControl143.Size = new System.Drawing.Size(25, 13);
		this.labelControl143.TabIndex = 33;
		this.labelControl143.Text = "Class";
		this.labelControl142.Appearance.Options.UseTextOptions = true;
		this.labelControl142.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl142.Location = new System.Drawing.Point(13, 11);
		this.labelControl142.Name = "labelControl142";
		this.labelControl142.Size = new System.Drawing.Size(38, 13);
		this.labelControl142.TabIndex = 32;
		this.labelControl142.Text = "Stud No";
		this.xtraTabPage2.Controls.Add(this.labelControl1);
		this.xtraTabPage2.Controls.Add(this.lblGuardianAddress);
		this.xtraTabPage2.Controls.Add(this.labelControl154);
		this.xtraTabPage2.Controls.Add(this.labelControl153);
		this.xtraTabPage2.Controls.Add(this.Guardian);
		this.xtraTabPage2.Controls.Add(this.lblGuardianPhone);
		this.xtraTabPage2.Controls.Add(this.lblGuardianName);
		this.xtraTabPage2.Controls.Add(this.labelControl159);
		this.xtraTabPage2.Controls.Add(this.labelControl158);
		this.xtraTabPage2.Controls.Add(this.labelControl157);
		this.xtraTabPage2.Controls.Add(this.lblStudentFees);
		this.xtraTabPage2.Controls.Add(this.lblStudentBursaryProv);
		this.xtraTabPage2.Controls.Add(this.lblStudentBursary);
		this.xtraTabPage2.Name = "xtraTabPage2";
		this.xtraTabPage2.Size = new System.Drawing.Size(194, 318);
		this.xtraTabPage2.Text = "Fees Info";
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(7, 113);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(147, 10);
		this.labelControl1.TabIndex = 72;
		this.labelControl1.Text = "Guardian Info";
		this.lblGuardianAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.lblGuardianAddress.Appearance.Options.UseFont = true;
		this.lblGuardianAddress.Appearance.Options.UseTextOptions = true;
		this.lblGuardianAddress.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.lblGuardianAddress.Location = new System.Drawing.Point(7, 211);
		this.lblGuardianAddress.Name = "lblGuardianAddress";
		this.lblGuardianAddress.Size = new System.Drawing.Size(0, 0);
		this.lblGuardianAddress.TabIndex = 71;
		this.labelControl154.Location = new System.Drawing.Point(7, 196);
		this.labelControl154.Name = "labelControl154";
		this.labelControl154.Size = new System.Drawing.Size(39, 13);
		this.labelControl154.TabIndex = 70;
		this.labelControl154.Text = "Address";
		this.labelControl153.Location = new System.Drawing.Point(7, 161);
		this.labelControl153.Name = "labelControl153";
		this.labelControl153.Size = new System.Drawing.Size(30, 13);
		this.labelControl153.TabIndex = 69;
		this.labelControl153.Text = "Phone";
		this.Guardian.Location = new System.Drawing.Point(7, 126);
		this.Guardian.Name = "Guardian";
		this.Guardian.Size = new System.Drawing.Size(27, 13);
		this.Guardian.TabIndex = 68;
		this.Guardian.Text = "Name";
		this.lblGuardianPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.lblGuardianPhone.Appearance.Options.UseFont = true;
		this.lblGuardianPhone.Location = new System.Drawing.Point(7, 176);
		this.lblGuardianPhone.Name = "lblGuardianPhone";
		this.lblGuardianPhone.Size = new System.Drawing.Size(0, 18);
		this.lblGuardianPhone.TabIndex = 67;
		this.lblGuardianName.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.lblGuardianName.Appearance.Options.UseFont = true;
		this.lblGuardianName.Location = new System.Drawing.Point(7, 141);
		this.lblGuardianName.Name = "lblGuardianName";
		this.lblGuardianName.Size = new System.Drawing.Size(0, 18);
		this.lblGuardianName.TabIndex = 66;
		this.labelControl159.Location = new System.Drawing.Point(7, 77);
		this.labelControl159.Name = "labelControl159";
		this.labelControl159.Size = new System.Drawing.Size(23, 13);
		this.labelControl159.TabIndex = 64;
		this.labelControl159.Text = "Fees";
		this.labelControl158.Location = new System.Drawing.Point(7, 42);
		this.labelControl158.Name = "labelControl158";
		this.labelControl158.Size = new System.Drawing.Size(66, 13);
		this.labelControl158.TabIndex = 63;
		this.labelControl158.Text = "Bursary Prov.";
		this.labelControl157.Location = new System.Drawing.Point(7, 7);
		this.labelControl157.Name = "labelControl157";
		this.labelControl157.Size = new System.Drawing.Size(71, 13);
		this.labelControl157.TabIndex = 62;
		this.labelControl157.Text = "Bursary Status";
		this.lblStudentFees.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.lblStudentFees.Appearance.Options.UseFont = true;
		this.lblStudentFees.Location = new System.Drawing.Point(7, 92);
		this.lblStudentFees.Name = "lblStudentFees";
		this.lblStudentFees.Size = new System.Drawing.Size(0, 18);
		this.lblStudentFees.TabIndex = 60;
		this.lblStudentBursaryProv.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.lblStudentBursaryProv.Appearance.Options.UseFont = true;
		this.lblStudentBursaryProv.Location = new System.Drawing.Point(7, 57);
		this.lblStudentBursaryProv.Name = "lblStudentBursaryProv";
		this.lblStudentBursaryProv.Size = new System.Drawing.Size(0, 18);
		this.lblStudentBursaryProv.TabIndex = 59;
		this.lblStudentBursary.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.lblStudentBursary.Appearance.Options.UseFont = true;
		this.lblStudentBursary.Location = new System.Drawing.Point(7, 22);
		this.lblStudentBursary.Name = "lblStudentBursary";
		this.lblStudentBursary.Size = new System.Drawing.Size(0, 18);
		this.lblStudentBursary.TabIndex = 58;
		this.xtraTabPage3.Controls.Add(this.txtNotes);
		this.xtraTabPage3.Name = "xtraTabPage3";
		this.xtraTabPage3.Size = new System.Drawing.Size(194, 318);
		this.xtraTabPage3.Text = "Notes";
		this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtNotes.Location = new System.Drawing.Point(0, 0);
		this.txtNotes.MenuManager = this.barManager1;
		this.txtNotes.Name = "txtNotes";
		this.txtNotes.Properties.ReadOnly = true;
		this.txtNotes.Size = new System.Drawing.Size(194, 318);
		this.txtNotes.TabIndex = 0;
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
		this.barDockControlBottom.Location = new System.Drawing.Point(0, 637);
		this.barDockControlBottom.Manager = this.barManager1;
		this.barDockControlBottom.Size = new System.Drawing.Size(946, 0);
		this.barDockControlLeft.CausesValidation = false;
		this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
		this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
		this.barDockControlLeft.Manager = this.barManager1;
		this.barDockControlLeft.Size = new System.Drawing.Size(0, 637);
		this.barDockControlRight.CausesValidation = false;
		this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
		this.barDockControlRight.Location = new System.Drawing.Point(946, 0);
		this.barDockControlRight.Manager = this.barManager1;
		this.barDockControlRight.Size = new System.Drawing.Size(0, 637);
		this.barButtonItem1.Caption = "Edit Student";
		this.barButtonItem1.Id = 0;
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Delete Student";
		this.barButtonItem2.Id = 1;
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Receive Fees";
		this.barButtonItem3.Id = 2;
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "Print";
		this.barButtonItem4.Id = 3;
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem5.Caption = "Create Gatepass";
		this.barButtonItem5.Id = 4;
		this.barButtonItem5.Name = "barButtonItem5";
		this.barSubItem1.Caption = "Create Gatepass";
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
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem7.Caption = "Medical";
		this.barButtonItem7.Id = 7;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem7_ItemClick);
		this.barButtonItem8.Caption = "General";
		this.barButtonItem8.Id = 8;
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem8_ItemClick);
		this.barButtonItem9.Caption = "Move to Old Students";
		this.barButtonItem9.Id = 9;
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.xtraTabPage4.Controls.Add(this.progressBarControl1);
		this.xtraTabPage4.Controls.Add(this.lblStatus);
		this.xtraTabPage4.Controls.Add(this.simpleButton1);
		this.xtraTabPage4.Name = "xtraTabPage4";
		this.xtraTabPage4.Size = new System.Drawing.Size(194, 318);
		this.xtraTabPage4.Text = "Fingerprint";
		this.lblStatus.Location = new System.Drawing.Point(30, 109);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(63, 13);
		this.lblStatus.TabIndex = 1;
		this.lblStatus.Text = "labelControl2";
		this.simpleButton1.Location = new System.Drawing.Point(30, 56);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(132, 23);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Start Enroll";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.pictureEdit8.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.pictureEdit8.Cursor = System.Windows.Forms.Cursors.Default;
		this.pictureEdit8.Location = new System.Drawing.Point(6, 40);
		this.pictureEdit8.Name = "pictureEdit8";
		this.pictureEdit8.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit8.Size = new System.Drawing.Size(218, 252);
		this.pictureEdit8.TabIndex = 33;
		this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.lblName.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.lblName.Appearance.Options.UseFont = true;
		this.lblName.Appearance.Options.UseTextOptions = true;
		this.lblName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.lblName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
		this.lblName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblName.Location = new System.Drawing.Point(6, 5);
		this.lblName.Name = "lblName";
		this.lblName.Size = new System.Drawing.Size(220, 29);
		this.lblName.TabIndex = 1;
		this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[6]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
			new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9)
		});
		this.popupMenu1.Manager = this.barManager1;
		this.popupMenu1.Name = "popupMenu1";
		this.navBarControl1.ActiveGroup = this.navBarGroup1;
		this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[1] { this.navBarGroup1 });
		this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[9] { this.navBarItem1, this.navBarItem2, this.navBarItem4, this.navBarItem5, this.navBarItem6, this.navBarItem12, this.navBarItem15, this.navBarItem16, this.navBarItem18 });
		this.navBarControl1.Location = new System.Drawing.Point(7, 7);
		this.navBarControl1.Name = "navBarControl1";
		this.navBarControl1.OptionsLayout.StoreAppearance = true;
		this.navBarControl1.OptionsNavPane.ExpandedWidth = 150;
		this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
		this.navBarControl1.OptionsNavPane.ShowSplitter = false;
		this.navBarControl1.Size = new System.Drawing.Size(150, 623);
		this.navBarControl1.TabIndex = 5;
		this.navBarControl1.Text = "navBarControl1";
		this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
		this.navBarGroup1.Caption = "Student";
		this.navBarGroup1.Expanded = true;
		this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[9]
		{
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem12),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem18),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem15),
			new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem16)
		});
		this.navBarGroup1.Name = "navBarGroup1";
		this.navBarItem4.Caption = "Edit";
		this.navBarItem4.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.user_edit;
		this.navBarItem4.ImageOptions.SmallImage = I_Xtreme.Properties.Resources.user_edit_16;
		this.navBarItem4.Name = "navBarItem4";
		this.navBarItem4.Visible = false;
		this.navBarItem4.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem4_LinkClicked);
		this.navBarItem5.Caption = "Delete";
		this.navBarItem5.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.user_remove;
		this.navBarItem5.ImageOptions.SmallImage = I_Xtreme.Properties.Resources.user_remove_16;
		this.navBarItem5.Name = "navBarItem5";
		this.navBarItem5.Visible = false;
		this.navBarItem5.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem5_LinkClicked);
		this.navBarItem1.Caption = "Print";
		this.navBarItem1.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("navBarItem1.ImageOptions.LargeImage");
		this.navBarItem1.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("navBarItem1.ImageOptions.SmallImage");
		this.navBarItem1.Name = "navBarItem1";
		this.navBarItem1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem1_LinkClicked);
		this.navBarItem2.Caption = "Preview";
		this.navBarItem2.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("navBarItem2.ImageOptions.LargeImage");
		this.navBarItem2.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("navBarItem2.ImageOptions.SmallImage");
		this.navBarItem2.Name = "navBarItem2";
		this.navBarItem2.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem2_LinkClicked);
		this.navBarItem6.Caption = "Give Gatepass";
		this.navBarItem6.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("navBarItem6.ImageOptions.LargeImage");
		this.navBarItem6.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("navBarItem6.ImageOptions.SmallImage");
		this.navBarItem6.Name = "navBarItem6";
		this.navBarItem6.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem6_LinkClicked);
		this.navBarItem12.Caption = "Email guardian";
		this.navBarItem12.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("navBarItem12.ImageOptions.LargeImage");
		this.navBarItem12.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("navBarItem12.ImageOptions.SmallImage");
		this.navBarItem12.Name = "navBarItem12";
		this.navBarItem12.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem12_LinkClicked);
		this.navBarItem18.Caption = "SMS guardian";
		this.navBarItem18.ImageOptions.LargeImage = I_Xtreme.Properties.Resources.smart_phone;
		this.navBarItem18.ImageOptions.SmallImage = I_Xtreme.Properties.Resources.smart_phone;
		this.navBarItem18.Name = "navBarItem18";
		this.navBarItem18.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem18_LinkClicked);
		this.navBarItem15.Caption = "Register";
		this.navBarItem15.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("navBarItem15.ImageOptions.LargeImage");
		this.navBarItem15.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("navBarItem15.ImageOptions.SmallImage");
		this.navBarItem15.Name = "navBarItem15";
		this.navBarItem15.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem15_LinkClicked);
		this.navBarItem16.Caption = "Drop Subjects";
		this.navBarItem16.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("navBarItem16.ImageOptions.LargeImage");
		this.navBarItem16.ImageOptions.SmallImage = (System.Drawing.Image)resources.GetObject("navBarItem16.ImageOptions.SmallImage");
		this.navBarItem16.Name = "navBarItem16";
		this.navBarItem16.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(navBarItem16_LinkClicked);
		this.layoutControl1.Controls.Add(this.gridStudentRecords);
		this.layoutControl1.Controls.Add(this.navBarControl1);
		this.layoutControl1.Controls.Add(this.panelControl7);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(420, 288, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(946, 637);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.gridStudentRecords.DataSource = this.entityInstantFeedbackSource1;
		this.gridStudentRecords.Location = new System.Drawing.Point(161, 7);
		this.gridStudentRecords.MainView = this.gv;
		this.gridStudentRecords.MenuManager = this.barManager1;
		this.gridStudentRecords.Name = "gridStudentRecords";
		this.gridStudentRecords.Size = new System.Drawing.Size(544, 623);
		this.gridStudentRecords.TabIndex = 36;
		this.gridStudentRecords.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gv });
		this.entityInstantFeedbackSource1.GetQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(EntityInstantFeedbackSource1_GetQueryable);
		this.entityInstantFeedbackSource1.DismissQueryable += new System.EventHandler<DevExpress.Data.Linq.GetQueryableEventArgs>(EntityInstantFeedbackSource1_DismissQueryable);
		this.gv.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gv.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gv.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gv.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.DetailTip.Options.UseFont = true;
		this.gv.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.Empty.Options.UseFont = true;
		this.gv.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.EvenRow.Options.UseFont = true;
		this.gv.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gv.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.FilterPanel.Options.UseFont = true;
		this.gv.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.FixedLine.Options.UseFont = true;
		this.gv.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.FocusedCell.Options.UseFont = true;
		this.gv.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.FocusedRow.Options.UseFont = true;
		this.gv.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.FooterPanel.Options.UseFont = true;
		this.gv.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.GroupButton.Options.UseFont = true;
		this.gv.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.GroupFooter.Options.UseFont = true;
		this.gv.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.GroupPanel.Options.UseFont = true;
		this.gv.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.GroupRow.Options.UseFont = true;
		this.gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.HeaderPanel.Options.UseFont = true;
		this.gv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gv.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.HorzLine.Options.UseFont = true;
		this.gv.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gv.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.OddRow.Options.UseFont = true;
		this.gv.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.Preview.Options.UseFont = true;
		this.gv.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.Row.Options.UseFont = true;
		this.gv.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.RowSeparator.Options.UseFont = true;
		this.gv.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.SelectedRow.Options.UseFont = true;
		this.gv.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.TopNewRow.Options.UseFont = true;
		this.gv.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.VertLine.Options.UseFont = true;
		this.gv.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.Appearance.ViewCaption.Options.UseFont = true;
		this.gv.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.EvenRow.Options.UseFont = true;
		this.gv.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.gv.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.gv.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.gv.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.GroupRow.Options.UseFont = true;
		this.gv.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.gv.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.Lines.Options.UseFont = true;
		this.gv.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.OddRow.Options.UseFont = true;
		this.gv.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.Preview.Options.UseFont = true;
		this.gv.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv.AppearancePrint.Row.Options.UseFont = true;
		this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[47]
		{
			this.colNo, this.gridColumn2, this.gridColumn3, this.gridColumn37, this.gridColumn41, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7, this.gridColumn8,
			this.gridColumn9, this.gridColumn10, this.gridColumn11, this.gridColumn12, this.gridColumn45, this.gridColumn44, this.gridColumn43, this.gridColumn47, this.gridColumn42, this.gridColumn13,
			this.gridColumn14, this.gridColumn15, this.gridColumn16, this.gridColumn17, this.gridColumn18, this.gridColumn19, this.gridColumn20, this.gridColumn21, this.gridColumn22, this.gridColumn23,
			this.gridColumn24, this.gridColumn25, this.gridColumn26, this.gridColumn27, this.gridColumn34, this.gridColumn28, this.gridColumn29, this.gridColumn30, this.gridColumn31, this.gridColumn33,
			this.gridColumn32, this.gridColumn35, this.gridColumn36, this.gridColumn38, this.gridColumn39, this.gridColumn40, this.gridColumn1
		});
		this.gv.GridControl = this.gridStudentRecords;
		this.gv.Name = "gv";
		this.gv.OptionsBehavior.AutoPopulateColumns = false;
		this.gv.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
		this.gv.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gv.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
		this.gv.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
		this.gv.OptionsFind.AlwaysVisible = true;
		this.gv.OptionsFind.FindPanelLocation = DevExpress.XtraGrid.Views.Grid.GridFindPanelLocation.Panel;
		this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gv.OptionsView.RowAutoHeight = true;
		this.gv.OptionsView.ShowErrorPanel = DevExpress.Utils.DefaultBoolean.True;
		this.gv.OptionsView.ShowGroupPanel = false;
		this.gv.OptionsView.ShowIndicator = false;
		this.gv.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gv.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(dgRecords_RowClick);
		this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(dgRecords_FocusedRowChanged);
		this.gv.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(dgRecords_CustomColumnDisplayText);
		this.colNo.Caption = "#";
		this.colNo.Name = "colNo";
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 45;
		this.gridColumn2.Caption = "auto";
		this.gridColumn2.FieldName = "auto";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn3.Caption = "Student#";
		this.gridColumn3.FieldName = "StudentNumber";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 1;
		this.gridColumn3.Width = 137;
		this.gridColumn37.Caption = "Student ID";
		this.gridColumn37.FieldName = "StudentID";
		this.gridColumn37.Name = "gridColumn37";
		this.gridColumn37.Visible = true;
		this.gridColumn37.VisibleIndex = 2;
		this.gridColumn37.Width = 133;
		this.gridColumn41.Caption = "LIN";
		this.gridColumn41.FieldName = "LIN";
		this.gridColumn41.Name = "gridColumn41";
		this.gridColumn4.Caption = "Oid";
		this.gridColumn4.FieldName = "Oid";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn5.Caption = "Name";
		this.gridColumn5.FieldName = "fullName";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 3;
		this.gridColumn5.Width = 310;
		this.gridColumn6.Caption = "Class";
		this.gridColumn6.FieldName = "ClassId";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 4;
		this.gridColumn6.Width = 69;
		this.gridColumn7.Caption = "Stream";
		this.gridColumn7.FieldName = "StreamId";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 5;
		this.gridColumn7.Width = 69;
		this.gridColumn8.Caption = "Sex";
		this.gridColumn8.FieldName = "Sex";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 6;
		this.gridColumn8.Width = 69;
		this.gridColumn9.Caption = "D/B";
		this.gridColumn9.FieldName = "StudyStatus";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 7;
		this.gridColumn9.Width = 69;
		this.gridColumn10.Caption = "House";
		this.gridColumn10.FieldName = "HouseId";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn11.Caption = "Religion";
		this.gridColumn11.FieldName = "Religion";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn12.Caption = "Guardian Name";
		this.gridColumn12.FieldName = "Guardian";
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn45.Caption = "Contact";
		this.gridColumn45.FieldName = "PriorityContact";
		this.gridColumn45.Name = "gridColumn45";
		this.gridColumn45.Visible = true;
		this.gridColumn45.VisibleIndex = 8;
		this.gridColumn45.Width = 100;
		this.gridColumn44.Caption = "Contact2";
		this.gridColumn44.FieldName = "OtherContact";
		this.gridColumn44.Name = "gridColumn44";
		this.gridColumn43.Caption = "Address";
		this.gridColumn43.FieldName = "GuardianAddress";
		this.gridColumn43.Name = "gridColumn43";
		this.gridColumn47.Caption = "Guardian Relationship";
		this.gridColumn47.FieldName = "GuardianRelation";
		this.gridColumn47.Name = "gridColumn47";
		this.gridColumn42.Caption = "Email";
		this.gridColumn42.FieldName = "Email";
		this.gridColumn42.Name = "gridColumn42";
		this.gridColumn13.Caption = "Former School";
		this.gridColumn13.FieldName = "FormerSchool";
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn14.Caption = "Bursary Status";
		this.gridColumn14.FieldName = "BursaryStatus";
		this.gridColumn14.Name = "gridColumn14";
		this.gridColumn15.Caption = "Bursary Provider";
		this.gridColumn15.FieldName = "BursaryProvider";
		this.gridColumn15.Name = "gridColumn15";
		this.gridColumn16.Caption = "Admission Date";
		this.gridColumn16.FieldName = "AdmissionDate";
		this.gridColumn16.Name = "gridColumn16";
		this.gridColumn17.Caption = "Picture";
		this.gridColumn17.FieldName = "Picture";
		this.gridColumn17.Name = "gridColumn17";
		this.gridColumn18.Caption = "Home Country";
		this.gridColumn18.FieldName = "HomeCountry";
		this.gridColumn18.Name = "gridColumn18";
		this.gridColumn19.Caption = "Status";
		this.gridColumn19.FieldName = "Status";
		this.gridColumn19.Name = "gridColumn19";
		this.gridColumn20.Caption = "Fees";
		this.gridColumn20.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn20.FieldName = "RequiredFees";
		this.gridColumn20.Name = "gridColumn20";
		this.gridColumn21.Caption = "Fees Balance";
		this.gridColumn21.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn21.FieldName = "cashOnAccount";
		this.gridColumn21.Name = "gridColumn21";
		this.gridColumn22.Caption = "Fees Discount";
		this.gridColumn22.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn22.FieldName = "FeesDiscount";
		this.gridColumn22.Name = "gridColumn22";
		this.gridColumn23.Caption = "Combination";
		this.gridColumn23.FieldName = "Comb";
		this.gridColumn23.Name = "gridColumn23";
		this.gridColumn24.Caption = "Fr. Name";
		this.gridColumn24.Name = "gridColumn24";
		this.gridColumn25.Caption = "Fr. Address";
		this.gridColumn25.Name = "gridColumn25";
		this.gridColumn26.Caption = "Fr. Contact";
		this.gridColumn26.FieldName = "fContact";
		this.gridColumn26.Name = "gridColumn26";
		this.gridColumn27.Caption = "Fr. Email";
		this.gridColumn27.FieldName = "fEmail";
		this.gridColumn27.Name = "gridColumn27";
		this.gridColumn34.Caption = "Fr. NIN";
		this.gridColumn34.FieldName = "fNIN";
		this.gridColumn34.Name = "gridColumn34";
		this.gridColumn28.Caption = "M_Name";
		this.gridColumn28.Name = "gridColumn28";
		this.gridColumn29.Caption = "M_Address";
		this.gridColumn29.FieldName = "mAddress";
		this.gridColumn29.Name = "gridColumn29";
		this.gridColumn30.Caption = "M_Contact";
		this.gridColumn30.FieldName = "mContact";
		this.gridColumn30.Name = "gridColumn30";
		this.gridColumn31.Caption = "M_Email";
		this.gridColumn31.FieldName = "mEmail";
		this.gridColumn31.Name = "gridColumn31";
		this.gridColumn33.Caption = "M_NIN";
		this.gridColumn33.FieldName = "mNIN";
		this.gridColumn33.Name = "gridColumn33";
		this.gridColumn32.Caption = "DOB";
		this.gridColumn32.FieldName = "DOB";
		this.gridColumn32.Name = "gridColumn32";
		this.gridColumn35.Caption = " Theol. Stud";
		this.gridColumn35.FieldName = "IsTheologyStud";
		this.gridColumn35.Name = "gridColumn35";
		this.gridColumn36.Caption = "PLE/UCE Results";
		this.gridColumn36.FieldName = "PrimaryScores1";
		this.gridColumn36.Name = "gridColumn36";
		this.gridColumn38.Caption = "NIN";
		this.gridColumn38.FieldName = "sNIN";
		this.gridColumn38.Name = "gridColumn38";
		this.gridColumn39.Caption = "Cocurricular";
		this.gridColumn39.FieldName = "Cocurricular";
		this.gridColumn39.Name = "gridColumn39";
		this.gridColumn40.Caption = "Health Status";
		this.gridColumn40.FieldName = "HealthStatus";
		this.gridColumn40.Name = "gridColumn40";
		this.gridColumn1.Caption = "Report Centre";
		this.gridColumn1.FieldName = "ReportCentre";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 9;
		this.gridColumn1.Width = 83;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[3] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem4 });
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
		this.layoutControlGroup1.Size = new System.Drawing.Size(946, 637);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.navBarControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(154, 627);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.panelControl7;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(702, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(234, 627);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.gridStudentRecords;
		this.layoutControlItem4.Location = new System.Drawing.Point(154, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(548, 627);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.progressBarControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.progressBarControl1.Location = new System.Drawing.Point(12, 20);
		this.progressBarControl1.MenuManager = this.barManager1;
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(175, 30);
		this.progressBarControl1.TabIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.barDockControlLeft);
		base.Controls.Add(this.barDockControlRight);
		base.Controls.Add(this.barDockControlBottom);
		base.Controls.Add(this.barDockControlTop);
		base.Name = "usrStudentList";
		base.Size = new System.Drawing.Size(946, 637);
		base.Load += new System.EventHandler(usrStudentList_Load);
		((System.ComponentModel.ISupportInitialize)this.panelControl7).EndInit();
		this.panelControl7.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
		this.xtraTabControl1.ResumeLayout(false);
		this.xtraTabPage1.ResumeLayout(false);
		this.xtraTabPage1.PerformLayout();
		this.xtraTabPage2.ResumeLayout(false);
		this.xtraTabPage2.PerformLayout();
		this.xtraTabPage3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtNotes.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.barManager1).EndInit();
		this.xtraTabPage4.ResumeLayout(false);
		this.xtraTabPage4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit8.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.navBarControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridStudentRecords).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gv).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
