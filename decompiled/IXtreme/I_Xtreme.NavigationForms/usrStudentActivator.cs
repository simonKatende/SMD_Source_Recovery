using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.ReportHeaders;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.TableLayout;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.GeneralReports;
using I_Xtreme.Properties;

namespace I_Xtreme.NavigationForms;

public class usrStudentActivator : XtraUserControl
{
	private string StudentNo = string.Empty;

	private string Contact = string.Empty;

	private string GuardianEmail = string.Empty;

	private string Sex = string.Empty;

	private string DB = string.Empty;

	private string Guardian = string.Empty;

	private SqlTransaction trans;

	private IContainer components = null;

	private TabPane tabPane1;

	private TabNavigationPage tabNavigationPage1;

	private TabNavigationPage tabNavigationPage2;

	private WindowsUIButtonPanel windowsUIButtonPanel1;

	private SplitContainerControl splitContainerControl1;

	private LayoutControl layoutControl1;

	private PictureEdit pictureEdit1;

	private SearchControl txtSearchInput;

	private BarCodeControl barCodeControl1;

	private LayoutControlGroup Root;

	private EmptySpaceItem emptySpaceItem2;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlGroup layoutControlGroup1;

	private TextEdit txtClass;

	private TextEdit txtStudentNo;

	private TextEdit txtName;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem5;

	private LayoutControlItem layoutControlItem6;

	private TabNavigationPage tabNavigationPage3;

	private TabNavigationPage tabNavigationPage4;

	private SimpleButton simpleButton1;

	private TextEdit txtStream;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlItem layoutControlItem9;

	private PanelControl panelControl1;

	private LayoutControlItem layoutControlItem8;

	private FlyoutPanel flyoutPanel1;

	private FlyoutPanelControl flyoutPanelControl1;

	private GridControl gridControl1;

	private TileView tileView1;

	private TileViewColumn gridColumn1;

	private TileViewColumn gridColumn2;

	private TileViewColumn gridColumn3;

	private TileViewColumn gridColumn4;

	private TileViewColumn gridColumn5;

	private TileViewColumn gridColumn6;

	private TileViewColumn gridColumn7;

	private SeparatorControl separatorControl2;

	public usrStudentActivator()
	{
		InitializeComponent();
		Dock = DockStyle.Fill;
		flyoutPanel1.Height = base.Height;
	}

	public void ClassChangedCallBackFN(string DestinationClass)
	{
		if (DestinationClass == "-N/A-")
		{
			txtClass.Text = string.Empty;
			txtName.Text = string.Empty;
			txtSearchInput.Text = string.Empty;
			txtStream.Text = string.Empty;
			txtStudentNo.Text = string.Empty;
			pictureEdit1.Image = null;
			StudentOptions.SetActiveClass("");
			StudentOptions.SetActiveStudent("");
			layoutControlItem9.Visibility = LayoutVisibility.Never;
			barCodeControl1.ForeColor = Color.Black;
			barCodeControl1.Text = string.Empty;
			windowsUIButtonPanel1.Enabled = false;
		}
		else
		{
			txtClass.Text = DestinationClass;
			StudentOptions.SetActiveClass(DestinationClass);
		}
	}

	private void PaintSearchResults(bool IsActiveStudent)
	{
		if (IsActiveStudent)
		{
			simpleButton1.Appearance.BackColor = Color.Green;
			simpleButton1.Appearance.ForeColor = Color.White;
			simpleButton1.Text = "De-activate Student";
			barCodeControl1.ForeColor = Color.Green;
			windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
			windowsUIButtonPanel1.Buttons[4].Properties.Enabled = true;
			windowsUIButtonPanel1.Buttons[5].Properties.Enabled = true;
		}
		else
		{
			simpleButton1.Appearance.BackColor = Color.Red;
			simpleButton1.Appearance.ForeColor = Color.White;
			simpleButton1.Text = "Activate Student";
			barCodeControl1.ForeColor = Color.Red;
			windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
			windowsUIButtonPanel1.Buttons[4].Properties.Enabled = false;
			windowsUIButtonPanel1.Buttons[5].Properties.Enabled = false;
		}
	}

	private void SearchSingleStudentByNo(string _StudentNo)
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		try
		{
			waitDialogForm.Caption = "Searching...";
			waitDialogForm.Show();
			string empty = string.Empty;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE StudentNumber='{_StudentNo}'", DataConnection.ConnectToDatabase()))
			{
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				if (dataTable.Rows.Count > 0)
				{
					waitDialogForm.Close();
					StudentOptions.SetActiveStudent(dataTable.Rows[0]["StudentNumber"].ToString());
					txtName.Text = dataTable.Rows[0]["fullName"].ToString().ToUpper();
					txtStudentNo.Text = dataTable.Rows[0]["StudentNumber"].ToString().ToUpper();
					empty = dataTable.Rows[0]["Status"].ToString();
					Contact = dataTable.Rows[0]["PriorityContact"].ToString();
					GuardianEmail = dataTable.Rows[0]["Email"].ToString();
					Sex = dataTable.Rows[0]["Sex"].ToString();
					DB = dataTable.Rows[0]["StudyStatus"].ToString();
					Guardian = dataTable.Rows[0]["Guardian"].ToString();
					txtClass.Text = dataTable.Rows[0]["ClassId"].ToString();
					txtStream.Text = dataTable.Rows[0]["StreamId"].ToString();
					barCodeControl1.Text = dataTable.Rows[0]["StudentNumber"].ToString().ToUpper();
					StudentOptions.SetActiveClass(dataTable.Rows[0]["ClassId"].ToString());
					windowsUIButtonPanel1.Enabled = true;
					byte[] array = new byte[0];
					array = (byte[])dataTable.Rows[0]["picture"];
					using (MemoryStream stream = new MemoryStream(array))
					{
						pictureEdit1.Image = Image.FromStream(stream);
					}
					waitDialogForm.Close();
					layoutControlItem9.Visibility = LayoutVisibility.Always;
					if (empty.ToLower() == "active")
					{
						PaintSearchResults(IsActiveStudent: true);
					}
					else
					{
						PaintSearchResults(IsActiveStudent: false);
					}
					StudentForCapture.SetStudentForCapture(txtStudentNo.Text, txtName.Text);
					return;
				}
			}
			using (SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE StudentID='{txtSearchInput.Text}'", DataConnection.ConnectToDatabase()))
			{
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				if (dataTable2.Rows.Count > 0)
				{
					waitDialogForm.Close();
					StudentOptions.SetActiveStudent(dataTable2.Rows[0]["StudentNumber"].ToString());
					txtName.Text = dataTable2.Rows[0]["fullName"].ToString().ToUpper();
					txtStudentNo.Text = dataTable2.Rows[0]["StudentNumber"].ToString().ToUpper();
					txtClass.Text = dataTable2.Rows[0]["ClassId"].ToString().ToUpper();
					txtStream.Text = dataTable2.Rows[0]["StreamId"].ToString();
					empty = dataTable2.Rows[0]["Status"].ToString();
					Contact = dataTable2.Rows[0]["PriorityContact"].ToString();
					GuardianEmail = dataTable2.Rows[0]["Email"].ToString();
					Sex = dataTable2.Rows[0]["Sex"].ToString();
					DB = dataTable2.Rows[0]["StudyStatus"].ToString();
					Guardian = dataTable2.Rows[0]["Guardian"].ToString();
					barCodeControl1.Text = dataTable2.Rows[0]["StudentNumber"].ToString().ToUpper();
					byte[] array2 = new byte[0];
					array2 = (byte[])dataTable2.Rows[0]["picture"];
					windowsUIButtonPanel1.Enabled = true;
					using (MemoryStream stream2 = new MemoryStream(array2))
					{
						pictureEdit1.Image = Image.FromStream(stream2);
					}
					waitDialogForm.Close();
					MessageBox.Show(empty);
					layoutControlItem9.Visibility = LayoutVisibility.Always;
					if (empty.ToLower() == "active")
					{
						PaintSearchResults(IsActiveStudent: true);
					}
					else
					{
						PaintSearchResults(IsActiveStudent: false);
					}
					return;
				}
			}
			using (SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE fullName LIKE '%{_StudentNo}%'", DataConnection.ConnectToDatabase()))
			{
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				if (dataTable3.Rows.Count > 0)
				{
					waitDialogForm.Close();
					gridControl1.DataSource = dataTable3.DefaultView;
					StudentNo = string.Empty;
					flyoutPanel1.ShowPopup();
					return;
				}
			}
			waitDialogForm.Close();
			windowsUIButtonPanel1.Enabled = false;
			layoutControlItem9.Visibility = LayoutVisibility.Never;
			XtraMessageBox.Show("The student you searched for does not exist.", "Search results", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex)
		{
			waitDialogForm.Close();
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtSearchInput_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return && !string.IsNullOrEmpty(txtSearchInput.Text))
		{
			SearchSingleStudentByNo(txtSearchInput.Text);
		}
	}

	private void txtSearchInput_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
		if (!string.IsNullOrEmpty(txtSearchInput.Text))
		{
			SearchSingleStudentByNo(txtSearchInput.Text);
		}
	}

	private void flyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
	{
		if (e.Button == flyoutPanel1.OptionsButtonPanel.Buttons[0])
		{
			if (!string.IsNullOrEmpty(StudentNo))
			{
				flyoutPanel1.HidePopup();
				SearchSingleStudentByNo(StudentNo);
			}
		}
		else
		{
			flyoutPanel1.HidePopup();
			if (string.IsNullOrEmpty(StudentNo))
			{
				txtSearchInput.Text = string.Empty;
			}
		}
	}

	private void tileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
	{
		if (tileView1.FocusedRowHandle > -1)
		{
			StudentNo = tileView1.GetRowCellValue(e.Item.RowHandle, "StudentNumber").ToString();
			txtSearchInput.Text = tileView1.GetRowCellValue(e.Item.RowHandle, "fullName").ToString();
		}
	}

	private void tileView1_ItemDoubleClick(object sender, TileViewItemClickEventArgs e)
	{
		if (tileView1.FocusedRowHandle > -1)
		{
			StudentNo = tileView1.GetRowCellValue(e.Item.RowHandle, "StudentNumber").ToString();
			txtSearchInput.Text = tileView1.GetRowCellValue(e.Item.RowHandle, "fullName").ToString();
			flyoutPanel1.HidePopup();
			SearchSingleStudentByNo(StudentNo);
		}
	}

	private void UpdateStudentStatus()
	{
		try
		{
			DateTime timeZoneTime = CurrentTime.TimeZoneTime;
			string text = "";
			bool flag = false;
			if (simpleButton1.Text == "Activate Student")
			{
				text = "Active";
				flag = true;
			}
			else
			{
				text = "Suspended";
				flag = false;
			}
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "UPDATE tbl_Stud SET Status=@Status WHERE StudentNumber=@StudentNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("Status", text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("StudentNumber", txtStudentNo.Text);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			if (simpleButton1.Text == "Activate Student")
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM AttendanceSheet WHERE StudentNo='{txtStudentNo.Text}' AND SemesterId='{WorkingSemesters.GetWorkingSemester()}' AND AttendanceCategory='Reporting'", DataConnection.ConnectToDatabase());
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				if (dataTable.Rows.Count > 0)
				{
					XtraMessageBox.Show("Reporting is already captured for this student", "Action denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO AttendanceSheet (StudentNo,MonthInt,MonthString,AttendanceDate,SemesterId,AttendanceCount,CheckedIn,CheckedOut,AttendanceCategory) VALUES (@StudentNo,@MonthInt,@MonthString,@AttendanceDate,@SemesterId,@AttendanceCount,@CheckedIn,@CheckedOut,@AttendanceCategory)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@StudentNo", txtStudentNo.Text);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@MonthInt", timeZoneTime.Month);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@MonthString", timeZoneTime.ToString("MMMM"));
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@AttendanceDate", timeZoneTime.ToShortDateString());
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SemesterId", WorkingSemesters.GetWorkingSemester());
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@AttendanceCount", 1);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@CheckedIn", true);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@CheckedOut", false);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@AttendanceCategory", "Reporting");
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			else
			{
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "DELETE FROM AttendanceSheet WHERE StudentNo=@StudentNo AND SemesterId=@SemesterId AND AttendanceCategory=@AttendanceCategory",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter3 = sqlCommand3.Parameters.AddWithValue("@StudentNo", txtStudentNo.Text);
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.AddWithValue("@SemesterId", WorkingSemesters.GetWorkingSemester());
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand3.Parameters.AddWithValue("@AttendanceCategory", "Reporting");
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			PaintSearchResults(flag);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		UpdateStudentStatus();
	}

	private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
	{
		if (e.Button == windowsUIButtonPanel1.Buttons[0])
		{
			if (!string.IsNullOrEmpty(StudentOptions.ActiveStudent()))
			{
				editStudents editStudents = new editStudents(EditMode: true);
				StudentOptions.ChangeLoadingMode("Custom");
				editStudents.txtStudentNumber.Text = StudentOptions.ActiveStudent();
				editStudents.ClassChanged = ClassChangedCallBackFN;
				editStudents.Text = "Edit Student details";
				editStudents.ShowDialog();
			}
			else
			{
				XtraMessageBox.Show("Please select a student you wish to edit", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			return;
		}
		if (e.Button == windowsUIButtonPanel1.Buttons[1])
		{
			try
			{
				using StudentPreview studentPreview = new StudentPreview();
				studentPreview.StudentNo.Value = txtStudentNo.Text;
				ReportPrintTool reportPrintTool = new ReportPrintTool(studentPreview);
				reportPrintTool.ShowRibbonPreviewDialog();
				return;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		if (e.Button == windowsUIButtonPanel1.Buttons[2])
		{
			WaitDialogForm waitDialogForm = new WaitDialogForm();
			try
			{
				waitDialogForm.SetCaption("Client Email Application is loading");
				string empty = string.Empty;
				empty = ((!(empty == string.Empty)) ? GuardianEmail : "guardian_email@domain.com");
				Process.Start($"mailto:{empty}?subject={ReportHeader.SchoolName}");
				waitDialogForm.Close();
				return;
			}
			catch (Exception ex2)
			{
				waitDialogForm.Close();
				XtraMessageBox.Show(ex2.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		if (e.Button == windowsUIButtonPanel1.Buttons[3])
		{
			using (SMSGuardian sMSGuardian = new SMSGuardian())
			{
				sMSGuardian.txtReceipient.Text = Contact;
				sMSGuardian.ShowDialog();
				return;
			}
		}
		if (e.Button == windowsUIButtonPanel1.Buttons[4])
		{
			using (StudentSubjectRegistration studentSubjectRegistration = new StudentSubjectRegistration(string.Empty))
			{
				int selectedIndex = 1;
				studentSubjectRegistration.radioGroupMode.SelectedIndex = selectedIndex;
				studentSubjectRegistration.txtName.Text = txtName.Text;
				studentSubjectRegistration.txtClass.Text = txtClass.Text;
				studentSubjectRegistration.txtStream.Text = txtStream.Text;
				studentSubjectRegistration.studentClass = txtClass.Text;
				studentSubjectRegistration.pictureEdit14.Image = pictureEdit1.Image;
				studentSubjectRegistration.StudentNumber = txtStudentNo.Text;
				studentSubjectRegistration.radioGroupMode.Enabled = false;
				studentSubjectRegistration.lookUpClasses.Enabled = false;
				studentSubjectRegistration.searchLookUpEdit1.Properties.ReadOnly = true;
				studentSubjectRegistration.ShowDialog();
				return;
			}
		}
		if (e.Button != windowsUIButtonPanel1.Buttons[5])
		{
			return;
		}
		using generalGatePass generalGatePass = new generalGatePass(txtStudentNo.Text);
		StudentOptions.SetActiveStudent(txtStudentNo.Text);
		generalGatePass.lblSemester.Text = WorkingSemesters.GetWorkingSemester();
		generalGatePass.lblStudentNo.Text = txtStudentNo.Text;
		generalGatePass.lblCurrentUsers.Text = CurrentUser.GetSystemUser();
		generalGatePass.lblNames.Text = txtName.Text;
		generalGatePass.pictureEdit1.Image = pictureEdit1.Image;
		generalGatePass.sex = Sex;
		generalGatePass.streamId = txtStream.Text;
		generalGatePass.db = DB;
		generalGatePass.guardian = Guardian;
		generalGatePass.ShowDialog();
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
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
		DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
		DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
		DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
		DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
		DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
		DevExpress.XtraEditors.TableLayout.TableSpan tableSpan = new DevExpress.XtraEditors.TableLayout.TableSpan();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
		DevExpress.XtraPrinting.BarCode.EAN13Generator symbology = new DevExpress.XtraPrinting.BarCode.EAN13Generator();
		DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.usrStudentActivator));
		DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
		DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
		DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
		DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
		DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.TileViewColumn();
		this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
		this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
		this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
		this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.tileView1 = new DevExpress.XtraGrid.Views.Tile.TileView();
		this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
		this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
		this.tabNavigationPage4 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.barCodeControl1 = new DevExpress.XtraEditors.BarCodeControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtStream = new DevExpress.XtraEditors.TextEdit();
		this.txtClass = new DevExpress.XtraEditors.TextEdit();
		this.txtStudentNo = new DevExpress.XtraEditors.TextEdit();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.txtSearchInput = new DevExpress.XtraEditors.SearchControl();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
		this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
		((System.ComponentModel.ISupportInitialize)this.tabPane1).BeginInit();
		this.tabPane1.SuspendLayout();
		this.tabNavigationPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).BeginInit();
		this.flyoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).BeginInit();
		this.flyoutPanelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.tileView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel1).BeginInit();
		this.splitContainerControl1.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel2).BeginInit();
		this.splitContainerControl1.Panel2.SuspendLayout();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtSearchInput.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.separatorControl2).BeginInit();
		base.SuspendLayout();
		this.gridColumn7.Caption = "Picture";
		this.gridColumn7.FieldName = "Picture";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 6;
		this.gridColumn7.Width = 50;
		this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
		this.gridColumn1.AppearanceCell.Options.UseFont = true;
		this.gridColumn1.Caption = "fullName";
		this.gridColumn1.FieldName = "fullName";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 0;
		this.gridColumn3.Caption = "StudentNumber";
		this.gridColumn3.FieldName = "StudentNumber";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.gridColumn2.Caption = "StudentID";
		this.gridColumn2.FieldName = "StudentID";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 1;
		this.gridColumn4.Caption = "ClassId";
		this.gridColumn4.FieldName = "ClassId";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 3;
		this.gridColumn5.Caption = "StreamId";
		this.gridColumn5.FieldName = "StreamId";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 4;
		this.gridColumn6.Caption = "StudyStatus";
		this.gridColumn6.FieldName = "StudyStatus";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 5;
		this.tabPane1.Controls.Add(this.tabNavigationPage1);
		this.tabPane1.Controls.Add(this.tabNavigationPage2);
		this.tabPane1.Controls.Add(this.tabNavigationPage3);
		this.tabPane1.Controls.Add(this.tabNavigationPage4);
		this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabPane1.Location = new System.Drawing.Point(0, 0);
		this.tabPane1.Name = "tabPane1";
		this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[4] { this.tabNavigationPage1, this.tabNavigationPage2, this.tabNavigationPage3, this.tabNavigationPage4 });
		this.tabPane1.RegularSize = new System.Drawing.Size(545, 501);
		this.tabPane1.SelectedPage = this.tabNavigationPage1;
		this.tabPane1.Size = new System.Drawing.Size(545, 501);
		this.tabPane1.TabIndex = 0;
		this.tabPane1.Text = "tabPane1";
		this.tabNavigationPage1.Caption = "Academics";
		this.tabNavigationPage1.Controls.Add(this.flyoutPanel1);
		this.tabNavigationPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage1.Name = "tabNavigationPage1";
		this.tabNavigationPage1.Properties.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage1.Properties.AppearanceCaption.Options.UseFont = true;
		this.tabNavigationPage1.Size = new System.Drawing.Size(545, 474);
		this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
		this.flyoutPanel1.Location = new System.Drawing.Point(3, 16);
		this.flyoutPanel1.Name = "flyoutPanel1";
		this.flyoutPanel1.Options.CloseOnOuterClick = true;
		this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
		buttonImageOptions.Image = I_Xtreme.Properties.Resources.checkbox_32x32;
		buttonImageOptions2.Image = I_Xtreme.Properties.Resources.close_32x32;
		this.flyoutPanel1.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[2]
		{
			new DevExpress.Utils.PeekFormButton("Button", false, buttonImageOptions, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.Utils.PeekFormButton("Button", false, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)
		});
		this.flyoutPanel1.OptionsButtonPanel.ShowButtonPanel = true;
		this.flyoutPanel1.OwnerControl = this;
		this.flyoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
		this.flyoutPanel1.Size = new System.Drawing.Size(563, 458);
		this.flyoutPanel1.TabIndex = 0;
		this.flyoutPanel1.ButtonClick += new DevExpress.Utils.FlyoutPanelButtonClickEventHandler(flyoutPanel1_ButtonClick);
		this.flyoutPanelControl1.Controls.Add(this.gridControl1);
		this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
		this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
		this.flyoutPanelControl1.Name = "flyoutPanelControl1";
		this.flyoutPanelControl1.Size = new System.Drawing.Size(563, 428);
		this.flyoutPanelControl1.TabIndex = 0;
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.tileView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(559, 424);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.tileView1 });
		this.tileView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
		this.tileView1.GridControl = this.gridControl1;
		this.tileView1.Name = "tileView1";
		this.tileView1.OptionsFind.AlwaysVisible = true;
		this.tileView1.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(12, 8, 12, 8);
		this.tileView1.OptionsTiles.IndentBetweenGroups = 0;
		this.tileView1.OptionsTiles.IndentBetweenItems = 0;
		this.tileView1.OptionsTiles.ItemSize = new System.Drawing.Size(548, 88);
		this.tileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
		this.tileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
		this.tileView1.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
		this.tileView1.OptionsTiles.RowCount = 0;
		tableColumnDefinition.Length.Value = 77.0;
		tableColumnDefinition2.Length.Value = 355.0;
		tableColumnDefinition3.Length.Value = 92.0;
		this.tileView1.TileColumns.Add(tableColumnDefinition);
		this.tileView1.TileColumns.Add(tableColumnDefinition2);
		this.tileView1.TileColumns.Add(tableColumnDefinition3);
		tableRowDefinition.Length.Value = 44.0;
		tableRowDefinition2.Length.Value = 29.0;
		tableRowDefinition3.Length.Value = 21.0;
		this.tileView1.TileRows.Add(tableRowDefinition);
		this.tileView1.TileRows.Add(tableRowDefinition2);
		this.tileView1.TileRows.Add(tableRowDefinition3);
		tableSpan.RowSpan = 3;
		this.tileView1.TileSpans.Add(tableSpan);
		tileViewItemElement.Column = this.gridColumn7;
		tileViewItemElement.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement.Text = "gridColumn7";
		tileViewItemElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement2.Appearance.Disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
		tileViewItemElement2.Appearance.Disabled.Options.UseFont = true;
		tileViewItemElement2.Appearance.Hovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Bold);
		tileViewItemElement2.Appearance.Hovered.Options.UseFont = true;
		tileViewItemElement2.Appearance.Hovered.Options.UseTextOptions = true;
		tileViewItemElement2.Appearance.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f, System.Drawing.FontStyle.Bold);
		tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
		tileViewItemElement2.Appearance.Pressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
		tileViewItemElement2.Appearance.Pressed.Options.UseFont = true;
		tileViewItemElement2.Appearance.Selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
		tileViewItemElement2.Appearance.Selected.Options.UseFont = true;
		tileViewItemElement2.Column = this.gridColumn1;
		tileViewItemElement2.ColumnIndex = 1;
		tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement2.Text = "gridColumn1";
		tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
		tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
		tileViewItemElement3.Appearance.Normal.Options.UseTextOptions = true;
		tileViewItemElement3.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		tileViewItemElement3.Column = this.gridColumn3;
		tileViewItemElement3.ColumnIndex = 1;
		tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement3.RowIndex = 1;
		tileViewItemElement3.Text = "gridColumn3";
		tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
		tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
		tileViewItemElement4.Appearance.Normal.Options.UseTextOptions = true;
		tileViewItemElement4.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		tileViewItemElement4.Column = this.gridColumn2;
		tileViewItemElement4.ColumnIndex = 1;
		tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement4.RowIndex = 2;
		tileViewItemElement4.Text = "gridColumn2";
		tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
		tileViewItemElement5.Appearance.Disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Bold);
		tileViewItemElement5.Appearance.Disabled.Options.UseFont = true;
		tileViewItemElement5.Appearance.Hovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Bold);
		tileViewItemElement5.Appearance.Hovered.Options.UseFont = true;
		tileViewItemElement5.Appearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Bold);
		tileViewItemElement5.Appearance.Normal.Options.UseFont = true;
		tileViewItemElement5.Appearance.Pressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Bold);
		tileViewItemElement5.Appearance.Pressed.Options.UseFont = true;
		tileViewItemElement5.Appearance.Selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Bold);
		tileViewItemElement5.Appearance.Selected.Options.UseFont = true;
		tileViewItemElement5.Column = this.gridColumn4;
		tileViewItemElement5.ColumnIndex = 2;
		tileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement5.Text = "gridColumn4";
		tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement6.Column = this.gridColumn5;
		tileViewItemElement6.ColumnIndex = 2;
		tileViewItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement6.RowIndex = 1;
		tileViewItemElement6.Text = "gridColumn5";
		tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement7.Column = this.gridColumn6;
		tileViewItemElement7.ColumnIndex = 2;
		tileViewItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileViewItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
		tileViewItemElement7.RowIndex = 2;
		tileViewItemElement7.Text = "gridColumn6";
		tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		this.tileView1.TileTemplate.Add(tileViewItemElement);
		this.tileView1.TileTemplate.Add(tileViewItemElement2);
		this.tileView1.TileTemplate.Add(tileViewItemElement3);
		this.tileView1.TileTemplate.Add(tileViewItemElement4);
		this.tileView1.TileTemplate.Add(tileViewItemElement5);
		this.tileView1.TileTemplate.Add(tileViewItemElement6);
		this.tileView1.TileTemplate.Add(tileViewItemElement7);
		this.tileView1.ItemClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(tileView1_ItemClick);
		this.tileView1.ItemDoubleClick += new DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventHandler(tileView1_ItemDoubleClick);
		this.tabNavigationPage2.Caption = "Fees Information";
		this.tabNavigationPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage2.Name = "tabNavigationPage2";
		this.tabNavigationPage2.Properties.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage2.Properties.AppearanceCaption.Options.UseFont = true;
		this.tabNavigationPage2.Size = new System.Drawing.Size(545, 501);
		this.tabNavigationPage3.Caption = "Attendances";
		this.tabNavigationPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage3.Name = "tabNavigationPage3";
		this.tabNavigationPage3.Properties.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage3.Properties.AppearanceCaption.Options.UseFont = true;
		this.tabNavigationPage3.Size = new System.Drawing.Size(545, 501);
		this.tabNavigationPage4.Caption = "Conduct";
		this.tabNavigationPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage4.Name = "tabNavigationPage4";
		this.tabNavigationPage4.Properties.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11f);
		this.tabNavigationPage4.Properties.AppearanceCaption.Options.UseFont = true;
		this.tabNavigationPage4.Size = new System.Drawing.Size(545, 501);
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.layoutControl1);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.separatorControl2);
		this.splitContainerControl1.Panel2.Controls.Add(this.tabPane1);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(807, 501);
		this.splitContainerControl1.SplitterPosition = 250;
		this.splitContainerControl1.TabIndex = 2;
		this.layoutControl1.Controls.Add(this.panelControl1);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtStream);
		this.layoutControl1.Controls.Add(this.txtClass);
		this.layoutControl1.Controls.Add(this.txtStudentNo);
		this.layoutControl1.Controls.Add(this.txtName);
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.txtSearchInput);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(250, 501);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.panelControl1.Controls.Add(this.barCodeControl1);
		this.panelControl1.Location = new System.Drawing.Point(10, 329);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(213, 37);
		this.panelControl1.TabIndex = 14;
		this.barCodeControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.barCodeControl1.Appearance.Options.UseBackColor = true;
		this.barCodeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.barCodeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.barCodeControl1.Location = new System.Drawing.Point(2, 2);
		this.barCodeControl1.Name = "barCodeControl1";
		this.barCodeControl1.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
		this.barCodeControl1.Size = new System.Drawing.Size(209, 33);
		this.barCodeControl1.Symbology = symbology;
		this.barCodeControl1.TabIndex = 4;
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(10, 474);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(213, 25);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 11;
		this.simpleButton1.Text = "simpleButton1";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtStream.Location = new System.Drawing.Point(66, 448);
		this.txtStream.Name = "txtStream";
		this.txtStream.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtStream.Properties.Appearance.Options.UseFont = true;
		this.txtStream.Properties.ReadOnly = true;
		this.txtStream.Size = new System.Drawing.Size(157, 22);
		this.txtStream.StyleController = this.layoutControl1;
		this.txtStream.TabIndex = 13;
		this.txtClass.Location = new System.Drawing.Point(66, 422);
		this.txtClass.Name = "txtClass";
		this.txtClass.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtClass.Properties.Appearance.Options.UseFont = true;
		this.txtClass.Properties.ReadOnly = true;
		this.txtClass.Size = new System.Drawing.Size(157, 22);
		this.txtClass.StyleController = this.layoutControl1;
		this.txtClass.TabIndex = 10;
		this.txtStudentNo.Location = new System.Drawing.Point(66, 396);
		this.txtStudentNo.Name = "txtStudentNo";
		this.txtStudentNo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtStudentNo.Properties.Appearance.Options.UseFont = true;
		this.txtStudentNo.Properties.ReadOnly = true;
		this.txtStudentNo.Size = new System.Drawing.Size(157, 22);
		this.txtStudentNo.StyleController = this.layoutControl1;
		this.txtStudentNo.TabIndex = 9;
		this.txtName.Location = new System.Drawing.Point(66, 370);
		this.txtName.Name = "txtName";
		this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.txtName.Properties.Appearance.Options.UseFont = true;
		this.txtName.Properties.ReadOnly = true;
		this.txtName.Size = new System.Drawing.Size(157, 22);
		this.txtName.StyleController = this.layoutControl1;
		this.txtName.TabIndex = 8;
		this.pictureEdit1.Location = new System.Drawing.Point(10, 84);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(213, 241);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 7;
		this.txtSearchInput.Location = new System.Drawing.Point(4, 29);
		this.txtSearchInput.Name = "txtSearchInput";
		this.txtSearchInput.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
		this.txtSearchInput.Properties.Appearance.Options.UseFont = true;
		this.txtSearchInput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[2]
		{
			new DevExpress.XtraEditors.Repository.SearchButton(),
			new DevExpress.XtraEditors.Repository.SearchByButton()
		});
		this.txtSearchInput.Properties.ShowClearButton = false;
		this.txtSearchInput.Properties.ShowSearchByButton = true;
		this.txtSearchInput.Size = new System.Drawing.Size(225, 26);
		this.txtSearchInput.StyleController = this.layoutControl1;
		this.txtSearchInput.TabIndex = 5;
		this.txtSearchInput.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtSearchInput_ButtonClick);
		this.txtSearchInput.KeyDown += new System.Windows.Forms.KeyEventHandler(txtSearchInput_KeyDown);
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[2] { this.layoutControlItem2, this.layoutControlGroup1 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.Root.Size = new System.Drawing.Size(233, 519);
		this.Root.TextVisible = false;
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = true;
		this.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.layoutControlItem2.Control = this.txtSearchInput;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(229, 55);
		this.layoutControlItem2.Text = "Search by Name/Student Number";
		this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(50, 20);
		this.layoutControlItem2.TextToControlDistance = 5;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[8] { this.layoutControlItem4, this.layoutControlItem3, this.layoutControlItem5, this.layoutControlItem6, this.layoutControlItem9, this.emptySpaceItem2, this.layoutControlItem8, this.layoutControlItem7 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 55);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
		this.layoutControlGroup1.Size = new System.Drawing.Size(229, 460);
		this.layoutControlGroup1.Text = "Student Information";
		this.layoutControlItem4.Control = this.pictureEdit1;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 245);
		this.layoutControlItem4.MinSize = new System.Drawing.Size(24, 245);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(217, 245);
		this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem3.Control = this.txtName;
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 286);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(217, 26);
		this.layoutControlItem3.Text = "Name";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(52, 16);
		this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem5.Control = this.txtStudentNo;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 312);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(217, 26);
		this.layoutControlItem5.Text = "Student#";
		this.layoutControlItem5.TextSize = new System.Drawing.Size(52, 16);
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.txtClass;
		this.layoutControlItem6.Location = new System.Drawing.Point(0, 338);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(217, 26);
		this.layoutControlItem6.Text = "Class";
		this.layoutControlItem6.TextSize = new System.Drawing.Size(52, 16);
		this.layoutControlItem9.Control = this.simpleButton1;
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 390);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(217, 29);
		this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem9.TextVisible = false;
		this.layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.Location = new System.Drawing.Point(0, 419);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(217, 10);
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.Control = this.panelControl1;
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 245);
		this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 41);
		this.layoutControlItem8.MinSize = new System.Drawing.Size(5, 41);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(217, 41);
		this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem8.TextVisible = false;
		this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem7.Control = this.txtStream;
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 364);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(217, 26);
		this.layoutControlItem7.Text = "Stream";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(52, 16);
		this.separatorControl2.Dock = System.Windows.Forms.DockStyle.Right;
		this.separatorControl2.LineOrientation = System.Windows.Forms.Orientation.Vertical;
		this.separatorControl2.Location = new System.Drawing.Point(526, 0);
		this.separatorControl2.Name = "separatorControl2";
		this.separatorControl2.Size = new System.Drawing.Size(19, 501);
		this.separatorControl2.TabIndex = 1;
		windowsUIButtonImageOptions.Image = (System.Drawing.Image)resources.GetObject("windowsUIButtonImageOptions1.Image");
		windowsUIButtonImageOptions2.Image = (System.Drawing.Image)resources.GetObject("windowsUIButtonImageOptions2.Image");
		windowsUIButtonImageOptions3.Image = (System.Drawing.Image)resources.GetObject("windowsUIButtonImageOptions3.Image");
		windowsUIButtonImageOptions4.Image = (System.Drawing.Image)resources.GetObject("windowsUIButtonImageOptions4.Image");
		windowsUIButtonImageOptions5.Image = (System.Drawing.Image)resources.GetObject("windowsUIButtonImageOptions5.Image");
		windowsUIButtonImageOptions6.Image = (System.Drawing.Image)resources.GetObject("windowsUIButtonImageOptions6.Image");
		this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[6]
		{
			new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.XtraBars.Docking2010.WindowsUIButton("Preview", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.XtraBars.Docking2010.WindowsUIButton("Email", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.XtraBars.Docking2010.WindowsUIButton("SMS", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.XtraBars.Docking2010.WindowsUIButton("Register", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.XtraBars.Docking2010.WindowsUIButton("Passout", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)
		});
		this.windowsUIButtonPanel1.Dock = System.Windows.Forms.DockStyle.Right;
		this.windowsUIButtonPanel1.Enabled = false;
		this.windowsUIButtonPanel1.Location = new System.Drawing.Point(807, 0);
		this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
		this.windowsUIButtonPanel1.Orientation = System.Windows.Forms.Orientation.Vertical;
		this.windowsUIButtonPanel1.Size = new System.Drawing.Size(63, 501);
		this.windowsUIButtonPanel1.TabIndex = 1;
		this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
		this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(windowsUIButtonPanel1_ButtonClick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.splitContainerControl1);
		base.Controls.Add(this.windowsUIButtonPanel1);
		base.Name = "usrStudentActivator";
		base.Size = new System.Drawing.Size(870, 501);
		((System.ComponentModel.ISupportInitialize)this.tabPane1).EndInit();
		this.tabPane1.ResumeLayout(false);
		this.tabNavigationPage1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).EndInit();
		this.flyoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).EndInit();
		this.flyoutPanelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.tileView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel1).EndInit();
		this.splitContainerControl1.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel2).EndInit();
		this.splitContainerControl1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStudentNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtSearchInput.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.separatorControl2).EndInit();
		base.ResumeLayout(false);
	}
}
