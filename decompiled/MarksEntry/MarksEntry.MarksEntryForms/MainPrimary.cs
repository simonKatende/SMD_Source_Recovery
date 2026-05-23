using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Drawing.Printing;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using MarksEntry.Properties;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace MarksEntry.MarksEntryForms;

public class MainPrimary : RibbonForm
{
	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private string suffix = string.Empty;

	private int i = 0;

	private int hotTrackRow = int.MinValue;

	private readonly string timeExported = DateTime.Now.ToString("HHMMss");

	private SqlTransaction trans;

	private SqlTransaction trans_s;

	private SqlTransaction transaction;

	private DataTable _dt;

	private DataTable dt;

	private DataTable dts;

	private double O___HOP = 0.0;

	private double O___BOT = 0.0;

	private double O___MOT = 0.0;

	private double O___EOT = 0.0;

	private bool O_ProcessAsPercentages = true;

	private bool NotAs100 = true;

	private bool aeot = false;

	private DataTable O__dt_g;

	private static readonly string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private GridControl dgMain;

	private BarStaticItem lblSubject;

	private BarStaticItem lblSemester;

	private BarStaticItem lblClass;

	private BarStaticItem lblStream;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarStaticItem barStaticItem6;

	private BarStaticItem lblInitial;

	private BarSubItem barSubItem1;

	private BarButtonItem barButtonItem5;

	private BarButtonItem barButtonItem6;

	private BarSubItem barSubItem2;

	private BarButtonItem barButtonItem8;

	private BarButtonItem barButtonItem7;

	private BarButtonItem barButtonItem9;

	private BarButtonItem barButtonItem10;

	private BarButtonItem barButtonItem11;

	private Timer tmUpdate;

	private BarSubItem barSubItem3;

	private BarListItem barListItem1;

	private BarCheckItem barCaramel;

	private BarCheckItem barMoneyTwins;

	private BarCheckItem barIMaginary;

	private BarCheckItem barCoffee;

	private BarCheckItem barLiquidSky;

	private BarCheckItem barValentine;

	private BarCheckItem barMcSkin;

	private BarCheckItem barSummer2008;

	private BarCheckItem barPumpkin;

	private BarCheckItem barBlue;

	private BarCheckItem barSpringtime;

	private BarCheckItem barDarkroom;

	private BarCheckItem barOffice2007Blue;

	private BarCheckItem barOffice2007Green;

	private BarCheckItem barOffice2010Blue;

	private BarCheckItem barOffice2010Black;

	private BarSubItem barSubItem9;

	private DefaultLookAndFeel defaultLookAndFeel1;

	private BarStaticItem lblMachineName;

	private BarStaticItem barStaticItem7;

	private BarStaticItem barStaticItem8;

	private BarStaticItem lblIpAddress;

	private BackgroundWorker bgSaveMarks;

	private BarButtonItem barButtonItem12;

	private PrintingSystem printingSystem1;

	private PrintableComponentLink printableComponentLink1;

	private BarButtonItem barButtonItem13;

	private BarButtonItem barButtonItem14;

	private BarButtonItem barButtonItem15;

	private BarButtonItem barButtonItem16;

	private XtraTabControl xtraTabControl1;

	private XtraTabPage xtraTabMarksEntry;

	private XtraTabPage xtraTabFileLogo;

	private BarButtonItem barButtonItem18;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private Timer timer1;

	private GridColumn gridColumn8;

	private BarSubItem barSubItem6;

	private BarButtonItem barButtonItem21;

	private BarButtonItem barButtonItem22;

	private BarButtonItem barButtonItem19;

	private BarButtonItem barButtonItem20;

	private PopupMenu popupMenu1;

	private BarButtonItem barButtonItem23;

	private BarButtonItem barButtonItem24;

	private PopupControlContainer popupControlContainer1;

	private GridControl gridControlStudents;

	private GridView gridViewStudents;

	private XtraTabPage xtraTabPage1;

	private GridColumn gridColumn9;

	private RepositoryItemPictureEdit repositoryItemPictureEdit1;

	private GridColumn gridColumn10;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;

	private GridView repositoryItemGridLookUpEdit1View;

	private BarEditItem barComboSubjects;

	private RibbonControl ribbonControl1;

	private RepositoryItemComboBox cboSelectedSubject;

	private RibbonPage ribbonPage1;

	private RibbonPageGroup ribbonPageGroup3;

	private RibbonStatusBar ribbonStatusBar1;

	private RibbonPageGroup ribbonPageGroup4;

	private RibbonPageGroup ribbonPageGroup5;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private BarEditItem txtSemester;

	private RepositoryItemTextEdit repositoryItemTextEdit2;

	private BarStaticItem lblLANStatus;

	private BarEditItem barEditItem1;

	private RepositoryItemPictureEdit repositoryItemPictureEdit2;

	private BarEditItem barComboClasses;

	private RepositoryItemComboBox cboSelectedClass;

	private BarEditItem barComboStream;

	private RepositoryItemComboBox cboSelectedStream;

	private BarButtonItem barButtonItem4;

	private PopupMenu popupMenu2;

	private BarButtonItem barButtonItem17;

	private RibbonPageGroup ribbonPageGroup1;

	private BarStaticItem barStaticItem1;

	private BarStaticItem barStaticItem2;

	private BandedGridView bandedGridView1;

	private BandedGridColumn gridColNo;

	private BandedGridColumn gridColumn11;

	private BandedGridColumn gridColumn12;

	private BandedGridColumn gridColumn13;

	private BandedGridColumn gridColumn14;

	private BandedGridColumn gridColHoP;

	private BandedGridColumn gridColBOT;

	private BandedGridColumn gridColMOT;

	private BandedGridColumn gridColEOT;

	private BandedGridColumn gridColumn19;

	private BandedGridColumn gridColumnGrade;

	private BandedGridColumn gridColumn21;

	private GridBand gridBand1;

	private GridBand gridBand2;

	private GridBand gridBand3;

	private GridBand gridBand4;

	private BandedGridColumn bandedGridColumn1;

	private int HotTrackRow
	{
		get
		{
			return hotTrackRow;
		}
		set
		{
			if (hotTrackRow != value)
			{
				int rowHandle = hotTrackRow;
				hotTrackRow = value;
				gridViewStudents.RefreshRow(rowHandle);
				gridViewStudents.RefreshRow(hotTrackRow);
				if (hotTrackRow >= 0)
				{
					gridControlStudents.Cursor = Cursors.Hand;
				}
				else
				{
					gridControlStudents.Cursor = Cursors.Default;
				}
			}
		}
	}

	private static SuperToolTip GetSuperToolTip3()
	{
		ToolTipTitleItem toolTipTitleItem = new ToolTipTitleItem();
		ToolTipTitleItem toolTipTitleItem2 = new ToolTipTitleItem();
		ToolTipItem toolTipItem = new ToolTipItem();
		SuperToolTip superToolTip = new SuperToolTip();
		ToolTipSeparatorItem item = new ToolTipSeparatorItem();
		toolTipTitleItem2.Text = "Enter Marks";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Continue entering marks for students.";
		toolTipTitleItem.LeftIndent = 6;
		toolTipTitleItem.Text = "Press F1 for help.";
		superToolTip.Items.Add(toolTipTitleItem2);
		superToolTip.Items.Add(toolTipItem);
		superToolTip.Items.Add(item);
		superToolTip.Items.Add(toolTipTitleItem);
		return superToolTip;
	}

	private static SuperToolTip GetSuperToolTip4()
	{
		ToolTipTitleItem toolTipTitleItem = new ToolTipTitleItem();
		ToolTipTitleItem toolTipTitleItem2 = new ToolTipTitleItem();
		ToolTipItem toolTipItem = new ToolTipItem();
		SuperToolTip superToolTip = new SuperToolTip();
		ToolTipSeparatorItem item = new ToolTipSeparatorItem();
		toolTipTitleItem2.Text = "File Log";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "List of Exported and Imported marks files.";
		toolTipTitleItem.LeftIndent = 6;
		toolTipTitleItem.Text = "Press F1 for help.";
		superToolTip.Items.Add(toolTipTitleItem2);
		superToolTip.Items.Add(toolTipItem);
		superToolTip.Items.Add(item);
		superToolTip.Items.Add(toolTipTitleItem);
		return superToolTip;
	}

	public MainPrimary()
	{
		InitializeComponent();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Skins");
		try
		{
			defaultLookAndFeel1.LookAndFeel.SkinName = registryKey.GetValue("Teacher Gateway").ToString();
		}
		catch
		{
			defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
		}
		base.WindowState = FormWindowState.Maximized;
		barEditItem1.EditValue = ByteImageConverter.ToByteArray(Resources.database, ImageFormat.Png);
		lblIpAddress.Caption = GetIp();
		lblMachineName.Caption = WindowsIdentity.GetCurrent().Name.Substring(0, WindowsIdentity.GetCurrent().Name.IndexOf('\\'));
		lblClass.Caption = TeacherLogin.StudentClass();
		barComboSubjects.EditValue = TeacherLogin.CurrentSubject();
		barComboClasses.EditValue = TeacherLogin.StudentClass();
		lblSubject.Caption = TeacherLogin.CurrentSubject();
		lblInitial.Caption = TeacherInitials.GetTeacherInitials();
		lblSemester.Caption = TeacherLogin.CurrentSemester();
		txtSemester.EditValue = TeacherLogin.CurrentSemester();
		TeacherLogin.LoadStreams(TeacherLogin.StudentClass(), cboSelectedStream);
		ThematicRatios.InitializeRatios(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
	}

	private void DropSingleOLevel()
	{
		DataRow dataRow = dt.Rows[bandedGridView1.GetFocusedDataSourceRowIndex()];
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			trans_s = sqlConnection.BeginTransaction();
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Transaction = trans_s;
			sqlCommand.CommandText = string.Format("DELETE FROM tbl_GeneralReportCards_Primary WHERE SubjectId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}' AND ClassId='{3}'", lblSubject.Caption, dataRow["Stud#"], lblSemester.Caption, lblClass.Caption);
			sqlCommand.CommandType = CommandType.Text;
			using (SqlCommand sqlCommand2 = sqlCommand)
			{
				sqlCommand2.ExecuteNonQuery();
			}
			sqlCommand = new SqlCommand();
			sqlCommand.Connection = sqlConnection;
			sqlCommand.Transaction = trans_s;
			sqlCommand.CommandText = string.Format("DELETE FROM tbl_Scores_Primary WHERE SubjectId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}' AND ClassId='{3}'", lblSubject.Caption, dataRow["Stud#"], lblSemester.Caption, lblClass.Caption);
			sqlCommand.CommandType = CommandType.Text;
			using (SqlCommand sqlCommand3 = sqlCommand)
			{
				sqlCommand3.ExecuteNonQuery();
			}
			trans_s.Commit();
			sqlConnection.Close();
		}
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT * FROM tbl_GeneralReportCards_Primary WHERE StudentNumber='{0}' AND SemesterId='{1}' AND ClassId='{2}'", dataRow["Stud#"], lblSemester.Caption, lblClass.Caption), DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "StudentChecker");
		if (dataSet.Tables[0].Rows.Count != 0)
		{
			return;
		}
		using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection2.Open();
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Connection = sqlConnection2,
			CommandText = string.Format("DELETE FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber='{0}' AND SemesterId='{1}' AND ClassId='{2}'", dataRow["Stud#"], lblSemester.Caption, lblClass.Caption),
			CommandType = CommandType.Text
		})
		{
			sqlCommand4.ExecuteNonQuery();
		}
		sqlConnection2.Close();
	}

	private void DropAllOLevel()
	{
		try
		{
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = $"DELETE FROM tbl_GeneralReportCards_Primary WHERE SemesterId='{lblSemester.Caption}' AND SubjectId='{lblSubject.Caption}' AND ClassId='{lblClass.Caption}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = $"DELETE FROM tbl_Scores_Primary WHERE SemesterId='{lblSemester.Caption}' AND SubjectId='{lblSubject.Caption}' AND ClassId='{lblClass.Caption}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
			}
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_GeneralReportCards_Primary WHERE SemesterId='{lblSemester.Caption}' AND ClassId='{lblClass.Caption}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentChecker");
			if (dataSet.Tables[0].Rows.Count != 0)
			{
				return;
			}
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = $"DELETE FROM tbl_GeneralReports_Grading_PrePrimary WHERE SemesterId='{lblSemester.Caption}' AND ClassId='{lblClass.Caption}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand3.ExecuteNonQuery();
			}
			sqlConnection2.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DropSubjectsWholeClass()
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to do this? Note that you cannot undo this action\nPlease Re-Process the reports for the selected Study Level, Semester and Class after this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				DropAllOLevel();
			}
			else
			{
				dialogResult = DialogResult.Cancel;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DropSubjectsSingle()
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to do this? Note that you cannot undo this action\nPlease Re-Process the reports for the selected Study Level, Semester and Class after this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				DropSingleOLevel();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadUnRegisteredStudents()
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		try
		{
			waitDialogForm.Caption = "Generating list...";
			waitDialogForm.Show();
			string selectCommandText = $"SELECT s.Picture,s.StudentNumber,(UPPER(s.StudentNumber) + CHAR(13) + CHAR(10) + '-----------------------------------------------------' + CHAR(13) + CHAR(10) + UPPER(fullName)) AS fullName FROM  tbl_Stud s WHERE ClassId = '{lblClass.Caption}'";
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString))
			{
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SubjectsList");
				dts = new DataTable();
				dts = dataSet.Tables[0];
				gridControlStudents.DataSource = dts.DefaultView;
			}
			waitDialogForm.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			waitDialogForm.Close();
		}
	}

	private void LoadOLevelMarks()
	{
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				string selectCommandText = $"SELECT UPPER(s.fullName) AS Name,UPPER(s.StudentNumber) AS Stud#,s.StreamId AS Stream,s.Sex,sc.HoP,sc.BOT,sc.MOT,sc.EOT,gr.AvMark AS Score,gr.Grade AS GradeScore,gr.Category AS Grade,gr.Comment FROM tbl_GeneralReportCards_Primary gr INNER JOIN tbl_Stud s ON s.StudentNumber = gr.StudentNumber  INNER JOIN tbl_Scores_Primary sc ON gr.StudentNumber = sc.StudentNumber AND gr.SubjectId = sc.SubjectId AND gr.SemesterId = sc.SemesterId WHERE (gr.SemesterId = '{TeacherLogin.CurrentSemester()}') AND (gr.SubjectId = '{TeacherLogin.CurrentSubject()}') AND (s.ClassId='{lblClass.Caption}') ORDER BY s.fullName";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Marks");
				dt = new DataTable();
				dt.Columns.Clear();
				dt = dataSet.Tables[0];
				dgMain.DataSource = dt.DefaultView;
			}
			SetsVisibility();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private void LoadOLevelMarks(string _stream)
	{
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				string selectCommandText = $"SELECT UPPER(s.fullName) AS Name,UPPER(s.StudentNumber) AS Stud#,s.Sex,sc.HoP,sc.BOT, sc.MOT,sc.EOT,gr.AvMark AS Score,gr.Grade AS GradeScore,gr.Category AS Grade,gr.Comment FROM tbl_GeneralReportCards_Primary gr INNER JOIN  tbl_Stud s ON gr.StudentNumber = s.StudentNumber INNER JOIN tbl_Scores_Primary sc ON gr.StudentNumber = sc.StudentNumber AND gr.SubjectId = sc.SubjectId AND gr.SemesterId = sc.SemesterId WHERE (gr.SemesterId = '{TeacherLogin.CurrentSemester()}') AND (gr.SubjectId = '{TeacherLogin.CurrentSubject()}') AND (s.StreamId='{_stream}') AND (s.ClassId='{lblClass.Caption}') ORDER BY s.fullName";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Marks");
				dt = new DataTable();
				dt.Columns.Clear();
				dt = dataSet.Tables[0];
				dgMain.DataSource = dt.DefaultView;
			}
			SetsVisibility();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	private static string GetIp()
	{
		string result = null;
		IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
		IPAddress[] addressList = hostEntry.AddressList;
		foreach (IPAddress iPAddress in addressList)
		{
			if (iPAddress.AddressFamily.ToString() == "InterNetwork")
			{
				result = iPAddress.ToString();
			}
		}
		return result;
	}

	private void LoadScoreSheet()
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm
		{
			ShowIcon = true,
			Caption = "Generating Marks Entry Platform..."
		};
		try
		{
			waitDialogForm.Show();
			LoadOLevelMarks();
			bandedGridView1.BestFitColumns();
			xtraTabControl1.SelectedTabPage = xtraTabMarksEntry;
			waitDialogForm.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			waitDialogForm.Close();
		}
	}

	private void MainWindow_Load(object sender, EventArgs e)
	{
		SkinHelper.InitSkinPopupMenu(popupMenu2);
		LoadScoreSheet();
		O___HOP = ThematicRatios.HoP;
		O___BOT = ThematicRatios.BOT;
		O___MOT = ThematicRatios.MOT;
		O___EOT = ThematicRatios.EOT;
		aeot = ThematicRatios.AEOT;
		O_ProcessAsPercentages = ThematicRatios.ProcessAsPercentages;
		O__dt_g = gradingScale.SubjectGradingScale;
		NotAs100 = ThematicRatios.MarksNot100;
		gridColHoP.Caption = ExamsOutputString.hHoP;
		gridColBOT.Caption = ExamsOutputString.hBOT;
		gridColMOT.Caption = ExamsOutputString.hMOT;
		gridColEOT.Caption = ExamsOutputString.hEOT;
		tmUpdate.Enabled = true;
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = dgMain;
			ReportHeader("Exported/Imported files log");
			printableComponentLink1.PrintDlg();
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = gridControl1;
			ReportHeader(string.Empty);
			printableComponentLink1.PrintDlg();
		}
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = dgMain;
			ReportHeader(string.Empty);
			printableComponentLink1.ShowPreview();
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = gridControl1;
			ReportHeader("Exported/Imported files log");
			printableComponentLink1.ShowPreview();
		}
	}

	private void MainWindow_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.P && e.Control)
		{
			dgMain.Print();
		}
		else if (e.KeyCode == Keys.F4 && e.Alt)
		{
			System.Windows.Forms.Application.Exit();
		}
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		System.Windows.Forms.Application.ExitThread();
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = dgMain;
			ReportHeader(string.Empty);
			printableComponentLink1.PrintDlg();
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = gridControl1;
			ReportHeader("Exported/Imported files log");
			printableComponentLink1.PrintDlg();
		}
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = dgMain;
			ReportHeader(string.Empty);
			printableComponentLink1.ShowPreview();
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			printableComponentLink1.PrintingSystem.ClearContent();
			printableComponentLink1.Component = gridControl1;
			ReportHeader("Exported/Imported files log");
			printableComponentLink1.ShowPreview();
		}
	}

	private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
	{
		ExportReportToExcel(dgMain, $"{lblSubject.Caption}!{lblClass.Caption}${lblSemester.Caption}");
	}

	private string ReportHeader(string report_header)
	{
		if (report_header == string.Empty)
		{
			string text = $"{lblClass.Caption} {lblStream.Caption}";
			string caption = lblSubject.Caption;
			return printableComponentLink1.RtfReportHeader = string.Format("{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\ql\\f0\\fs22 {0}\\par\r\n{1}\\par\r\n{2}\\par\r\n{3}\\par\r\n\\par\r\n{4}\\par\r\n}}\r\n", "Mark Sheet", text, caption, lblInitial.Caption, report_header);
		}
		return printableComponentLink1.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\ql\\f0\\fs22 {report_header}\\par\r\n";
	}

	private void ExportReportToExcel(GridControl gridControl, string _fileName)
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm
		{
			Caption = "Exporting Marksheet...",
			ShowIcon = true
		};
		try
		{
			if (ThematicRatios.HoP > 0.0)
			{
				suffix += "HoP ";
			}
			if (ThematicRatios.BOT > 0.0)
			{
				suffix += "BOT ";
			}
			if (ThematicRatios.MOT > 0.0)
			{
				suffix += "MOT ";
			}
			if (ThematicRatios.EOT > 0.0)
			{
				suffix += "EOT ";
			}
			using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string text = $"{_fileName}_{timeExported}";
				printableComponentLink1.Component = gridControl;
				printableComponentLink1.Landscape = false;
				printableComponentLink1.PrintingSystem.ClearContent();
				waitDialogForm.Show();
				printableComponentLink1.ExportToXls($"{folderBrowserDialog.SelectedPath}\\{text.Replace('/', '#')}_{suffix.TrimEnd()}.xls");
				object value = Missing.Value;
				Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
				string filename = $"{folderBrowserDialog.SelectedPath}\\{text.Replace('/', '#')}_{suffix.TrimEnd()}.xls";
				Workbook workbook = application.Workbooks.Open(filename, value, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
				Worksheet worksheet = (Worksheet)(dynamic)workbook.Worksheets.get_Item((object)1);
				worksheet.Name = "ScoreSheet";
				workbook.Save();
				application.Application.Workbooks.Close();
				SaveExportReference($"{text.Replace('/', '#')}_{suffix.TrimEnd()}.xls");
				waitDialogForm.Close();
				if (XtraMessageBox.Show("Finished Exporting. Please DO NOT change the name of the file.\nDo you want to open the file?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Process.Start($"{folderBrowserDialog.SelectedPath}\\{text.Replace('/', '#')}_{suffix.TrimEnd()}.xls");
				}
			}
			else
			{
				waitDialogForm.Close();
			}
		}
		catch (Exception ex)
		{
			waitDialogForm.Close();
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
	{
		ExportReportToExcel(dgMain, $"{lblSubject.Caption}!{lblClass.Caption}${lblSemester.Caption}");
	}

	private void SaveExportReference(string fileName)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_filesExported (fileName,classId,subjectId,semesterId,dateExported,imported,importDate)VALUES(@fileName,@classId,@subjectId,@semesterId,@dateExported,@imported,@importDate)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@fileName", SqlDbType.VarChar, 80);
			sqlParameter.Value = fileName.Replace('/', '#');
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@classId", SqlDbType.VarChar, 3);
			sqlParameter.Value = lblClass.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@subjectId", SqlDbType.VarChar, 50);
			sqlParameter.Value = lblSubject.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@semesterId", SqlDbType.VarChar, 50);
			sqlParameter.Value = lblSemester.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@dateExported", SqlDbType.DateTime);
			sqlParameter.Value = DateTime.Now.ToLongDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@imported", SqlDbType.Bit);
			sqlParameter.Value = false;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@importDate", SqlDbType.VarChar, 50);
			sqlParameter.Value = string.Empty;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
		sqlConnection.Dispose();
	}

	private void ImportScores()
	{
		using ImportScores importScores = new ImportScores();
		if (importScores.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		string text = importScores.txtSource.Text.Trim();
		int length = text.Length;
		int num = text.IndexOf('!');
		string text2 = text.Substring(num + 1, 3);
		string text3 = text.Substring(0, num);
		string text4 = text.Substring(text.IndexOf('$') + 1, text.IndexOf('_') - text.IndexOf('$') - 1);
		string text5 = (length - text.IndexOf('_')).ToString();
		using WaitDialogForm waitDialogForm = new WaitDialogForm();
		if (text2.ToLower() == lblClass.Caption.ToLower() && text3.ToLower() == lblSubject.Caption.ToLower().Replace('/', '#') && text4 == lblSemester.Caption)
		{
			waitDialogForm.Caption = $"Importing {lblClass.Caption} scores";
			ImportScoresFromExcel.GetScoresFromExcel(lblClass.Caption, lblSemester.Caption, lblSubject.Caption);
			LoadScoreSheet();
			UpdateImportedFile(text);
			waitDialogForm.Close();
		}
		else
		{
			XtraMessageBox.Show("IMPORTING SCORES FAILED!\nThe file you imported does not match with the logged in Subject, Class or Semester", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			waitDialogForm.Close();
		}
	}

	private static void UpdateImportedFile(string fileName)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = $"UPDATE tbl_filesExported SET imported='True',importDate='{DateTime.Now.ToLongDateString()}' WHERE fileName='{fileName}'",
			CommandType = CommandType.Text
		})
		{
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
		sqlConnection.Dispose();
	}

	private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
	{
		ImportScores();
	}

	private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
	{
		ImportScores();
	}

	private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			barButtonItem16.Caption = "Enter Marks";
			xtraTabControl1.SelectedTabPage = xtraTabFileLogo;
			LoadFileLogo();
		}
		else if (xtraTabControl1.SelectedTabPageIndex == 1)
		{
			barButtonItem16.Caption = "File Log";
			xtraTabControl1.SelectedTabPageIndex = 0;
		}
	}

	private void xtraTabControl1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
		{
			e.Handled = true;
		}
	}

	private void LoadFileLogo()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECt * FROM tbl_filesExported", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "scoreLogo");
			_dt = new DataTable();
			_dt = dataSet.Tables[0];
			gridControl1.DataSource = _dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (xtraTabControl1.SelectedTabPageIndex == 0)
		{
			barButtonItem12.Enabled = true;
			barButtonItem15.Enabled = true;
			barButtonItem3.Enabled = true;
			barButtonItem13.Enabled = true;
			barButtonItem14.Enabled = true;
			barButtonItem21.Enabled = true;
			barButtonItem22.Enabled = true;
			barButtonItem24.Enabled = true;
			barButtonItem16.LargeGlyph = Resources.log;
			SuperToolTip superToolTip = GetSuperToolTip4();
			barButtonItem16.SuperTip = superToolTip;
		}
		else
		{
			barButtonItem12.Enabled = false;
			barButtonItem15.Enabled = false;
			barButtonItem3.Enabled = false;
			barButtonItem13.Enabled = false;
			barButtonItem14.Enabled = false;
			barButtonItem21.Enabled = false;
			barButtonItem22.Enabled = false;
			barButtonItem24.Enabled = false;
			barButtonItem16.LargeGlyph = Resources.book_edit;
			SuperToolTip superToolTip2 = GetSuperToolTip3();
			barButtonItem16.SuperTip = superToolTip2;
		}
	}

	private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
	{
		DropSubjectsSingle();
		LoadScoreSheet();
	}

	private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
	{
		DropSubjectsSingle();
		LoadScoreSheet();
	}

	private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
	{
		DropSubjectsWholeClass();
		LoadScoreSheet();
	}

	private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
	{
		LoadUnRegisteredStudents();
	}

	private void gridViewStudents_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
		if (e.RowHandle == HotTrackRow)
		{
			e.Appearance.BackColor = Color.FromArgb(255, 102, 0);
		}
	}

	private void gridViewStudents_MouseMove(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		GridHitInfo gridHitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
		if (gridHitInfo.InRowCell)
		{
			HotTrackRow = gridHitInfo.RowHandle;
		}
		else
		{
			HotTrackRow = int.MinValue;
		}
	}

	private void gridControlStudents_DoubleClick(object sender, EventArgs e)
	{
		try
		{
			if (gridViewStudents.FocusedRowHandle > -1)
			{
				DataRow dataRow = dts.Rows[gridViewStudents.GetFocusedDataSourceRowIndex()];
				string empty = string.Empty;
				string empty2 = string.Empty;
				empty = lblSubject.Caption;
				empty2 = string.Empty;
				string value = lblSemester.Caption.Substring(lblSemester.Caption.Length - 4, 4);
				int num = Convert.ToInt32(value);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			bandedGridView1.HideEditor();
			e.Cancel = false;
		}
		else
		{
			e.Cancel = true;
		}
	}

	private void UpdateScores(string AvMark, string Category, string Grade, string Comment, CellValueChangedEventArgs e)
	{
		try
		{
			double result = (double.TryParse(bandedGridView1.GetRowCellValue(e.RowHandle, "HoP").ToString(), out result) ? result : 0.0);
			double result2 = (double.TryParse(bandedGridView1.GetRowCellValue(e.RowHandle, "BOT").ToString(), out result2) ? result2 : 0.0);
			double result3 = (double.TryParse(bandedGridView1.GetRowCellValue(e.RowHandle, "MOT").ToString(), out result3) ? result3 : 0.0);
			double result4 = (double.TryParse(bandedGridView1.GetRowCellValue(e.RowHandle, "EOT").ToString(), out result4) ? result4 : 0.0);
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			if (NotAs100)
			{
				num = result;
				num2 = result2;
				num3 = result3;
				num4 = result3;
			}
			else
			{
				num = Math.Round(result / 100.0 * O___HOP);
				num2 = Math.Round(result2 / 100.0 * O___BOT);
				num3 = Math.Round(result3 / 100.0 * O___MOT);
				num4 = Math.Round(result4 / 100.0 * O___EOT);
			}
			string fieldName = e.Column.FieldName;
			double num5 = 0.0;
			switch (fieldName)
			{
			case "HoP":
				num5 = num;
				break;
			case "BOT":
				num5 = num2;
				break;
			case "MOT":
				num5 = num3;
				break;
			case "EOT":
				num5 = num4;
				break;
			}
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			transaction = sqlConnection.BeginTransaction();
			string commandText = string.Format("UPDATE tbl_GeneralReportCards_Primary SET {0} = @{0},AvMark = @AvMark,Grade = @Grade,Category = @Category,Initial = @Initial,Comment = @Comment WHERE StudentNumber = @StudentNumber AND SubjectId = @SubjectId AND SemesterId = @SemesterId AND ClassId=@ClassId", fieldName);
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = transaction,
				CommandText = commandText,
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = bandedGridView1.GetRowCellValue(e.RowHandle, "Stud#").ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = lblClass.Caption;
				sqlParameter.Direction = ParameterDirection.Input;
				if (string.IsNullOrEmpty(AvMark))
				{
					sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 4);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 3);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.VarChar, 1);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				else
				{
					sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 4);
					sqlParameter.Value = num5;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 3);
					sqlParameter.Value = AvMark;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.VarChar, 1);
					sqlParameter.Value = Grade;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 3);
				sqlParameter.Value = Category;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
				sqlParameter.Value = Comment;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
				sqlParameter.Value = lblInitial.Caption;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter.Value = lblSemester.Caption;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter.Value = TeacherLogin.CurrentSubject();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = transaction,
				CommandText = string.Format("UPDATE tbl_Scores_Primary SET {0}=@{0} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId AND ClassId=@ClassId", fieldName),
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter2.Value = bandedGridView1.GetRowCellValue(e.RowHandle, "Stud#").ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter2.Value = lblClass.Caption;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 6);
				sqlParameter2.Value = e.Value;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter2.Value = lblSemester.Caption;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter2.Value = TeacherLogin.CurrentSubject();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			transaction.Commit();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void MarksCalculator(CellValueChangedEventArgs e)
	{
		string s = bandedGridView1.GetRowCellValue(e.RowHandle, "HoP").ToString();
		string s2 = bandedGridView1.GetRowCellValue(e.RowHandle, "BOT").ToString();
		string s3 = bandedGridView1.GetRowCellValue(e.RowHandle, "MOT").ToString();
		string s4 = bandedGridView1.GetRowCellValue(e.RowHandle, "EOT").ToString();
		double result = (double.TryParse(s, out result) ? result : 0.0);
		double result2 = (double.TryParse(s2, out result2) ? result2 : 0.0);
		double result3 = (double.TryParse(s3, out result3) ? result3 : 0.0);
		double result4 = (double.TryParse(s4, out result4) ? result4 : 0.0);
		double num = result;
		double num2 = result2;
		double num3 = result3;
		double num4 = result4;
		if (!NotAs100)
		{
			num = result / 100.0 * O___HOP;
			num2 = result2 / 100.0 * O___BOT;
			num3 = result3 / 100.0 * O___MOT;
			num4 = result4 / 100.0 * O___EOT;
		}
		foreach (DataRow row in O__dt_g.Rows)
		{
			double num5 = 0.0;
			double num6 = 0.0;
			if (O_ProcessAsPercentages)
			{
				int num7 = 0;
				double[] array = new double[4] { O___HOP, O___BOT, O___MOT, O___EOT };
				for (int i = 0; i < 4; i++)
				{
					if (array[i] > 0.0)
					{
						num7++;
					}
				}
				num6 = ((!aeot) ? ((result + result2 + result3 + result4) / (double)num7) : result4);
				num5 = Math.Round(num6, 0, MidpointRounding.AwayFromZero);
			}
			else if (!O_ProcessAsPercentages)
			{
				num6 = ((!aeot) ? (num + num2 + num3 + num4) : num4);
				num5 = Math.Round(num6, 0, MidpointRounding.AwayFromZero);
			}
			if (Convert.ToDouble(row["Debut"]) <= num5 && num5 <= Convert.ToDouble(row["End"]))
			{
				Random random = new Random();
				int num8 = (int)(random.NextDouble() * 5.0 + 1.0);
				bandedGridView1.SetRowCellValue(e.RowHandle, "Score", num5);
				bandedGridView1.SetRowCellValue(e.RowHandle, "Grade", row["Category"].ToString());
				bandedGridView1.SetRowCellValue(e.RowHandle, "GradeScore", row["Points"]);
				switch (num8)
				{
				case 1:
					bandedGridView1.SetRowCellValue(e.RowHandle, "Comment", row["Comment"].ToString());
					break;
				case 2:
					bandedGridView1.SetRowCellValue(e.RowHandle, "Comment", row["Comment2"].ToString());
					break;
				case 3:
					bandedGridView1.SetRowCellValue(e.RowHandle, "Comment", row["Comment3"].ToString());
					break;
				case 4:
					bandedGridView1.SetRowCellValue(e.RowHandle, "Comment", row["Comment4"].ToString());
					break;
				case 5:
					bandedGridView1.SetRowCellValue(e.RowHandle, "Comment", row["Comment5"].ToString());
					break;
				}
				UpdateScores(bandedGridView1.GetRowCellValue(e.RowHandle, "Score").ToString(), bandedGridView1.GetRowCellValue(e.RowHandle, "Grade").ToString(), bandedGridView1.GetRowCellValue(e.RowHandle, "GradeScore").ToString(), bandedGridView1.GetRowCellValue(e.RowHandle, "Comment").ToString(), e);
			}
		}
	}

	private void SetsVisibility()
	{
		if (ThematicRatios.HoP > 0.0)
		{
			gridColHoP.Visible = true;
		}
		if (ThematicRatios.BOT > 0.0)
		{
			gridColBOT.Visible = true;
		}
		if (ThematicRatios.MOT > 0.0)
		{
			gridColMOT.Visible = true;
		}
		if (ThematicRatios.EOT > 0.0)
		{
			gridColEOT.Visible = true;
		}
	}

	private void tmUpdate_Tick(object sender, EventArgs e)
	{
		try
		{
			i++;
			if (i == 3)
			{
				i = 0;
				bgSaveMarks.RunWorkerAsync();
			}
		}
		catch (Exception ex)
		{
			lblLANStatus.Caption = ex.Message;
		}
	}

	private void dgMain_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
		{
			e.Handled = true;
		}
	}

	private void barComboStream_HiddenEditor(object sender, ItemClickEventArgs e)
	{
		if (barComboStream.EditValue != null)
		{
			if (barComboStream.EditValue.ToString() == "Entire Class")
			{
				LoadOLevelMarks();
			}
			else
			{
				LoadOLevelMarks(barComboStream.EditValue.ToString());
			}
		}
	}

	private void popupMenu2_CloseUp(object sender, EventArgs e)
	{
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Skins");
			registryKey.SetValue("TeacherStation", defaultLookAndFeel1.LookAndFeel.SkinName);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void bandedGridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (bandedGridView1.FocusedRowHandle <= -1 || (bandedGridView1.FocusedColumn != bandedGridView1.Columns["HoP"] && bandedGridView1.FocusedColumn != bandedGridView1.Columns["BOT"] && bandedGridView1.FocusedColumn != bandedGridView1.Columns["MOT"] && bandedGridView1.FocusedColumn != bandedGridView1.Columns["EOT"]))
		{
			return;
		}
		if ((!int.TryParse(e.Value.ToString(), out var result) && e.Value.ToString() != "-") || result > 100 || result < 0)
		{
			e.Valid = false;
		}
		else
		{
			if (int.TryParse(e.Value.ToString(), out result) || !(e.Value.ToString() == "-"))
			{
				return;
			}
			e.Valid = true;
			if ((O___EOT > 0.0 && O___HOP == 0.0 && O___BOT == 0.0 && O___MOT == 0.0) || (O___BOT > 0.0 && O___HOP == 0.0 && O___EOT == 0.0 && O___MOT == 0.0) || (O___MOT > 0.0 && O___HOP == 0.0 && O___BOT == 0.0 && O___EOT == 0.0))
			{
				Point pt = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo = bandedGridView1.CalcHitInfo(pt);
				if (bandedGridHitInfo.InRowCell)
				{
					int rowHandle = bandedGridHitInfo.RowHandle;
					GridColumn column = bandedGridHitInfo.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), column.ToString(), "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "GradeScore", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Comment", "-");
				}
			}
			else if (O___BOT > 0.0 && O___HOP == 0.0 && O___EOT > 0.0 && O___MOT == 0.0)
			{
				Point pt2 = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo2 = bandedGridView1.CalcHitInfo(pt2);
				if (bandedGridHitInfo2.InRowCell)
				{
					int rowHandle2 = bandedGridHitInfo2.RowHandle;
					GridColumn column2 = bandedGridHitInfo2.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), column2.ToString(), null);
				}
				string text = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "EOT").ToString();
				string text2 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "BOT").ToString();
				if ((text == "-" || string.IsNullOrEmpty(text)) && (text2 == "-" || string.IsNullOrEmpty(text2)))
				{
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "GradeScore", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Comment", "-");
				}
			}
			else if (O___MOT > 0.0 && O___HOP == 0.0 && O___BOT == 0.0 && O___EOT > 0.0)
			{
				Point pt3 = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo3 = bandedGridView1.CalcHitInfo(pt3);
				if (bandedGridHitInfo3.InRowCell)
				{
					int rowHandle3 = bandedGridHitInfo3.RowHandle;
					GridColumn column3 = bandedGridHitInfo3.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), column3.ToString(), null);
				}
				string text3 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "MOT").ToString();
				string text4 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "EOT").ToString();
				if ((text3 == "-" || string.IsNullOrEmpty(text3)) && (text4 == "-" || string.IsNullOrEmpty(text4)))
				{
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "GradeScore", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Comment", "-");
				}
			}
			else if (O___MOT > 0.0 && O___HOP == 0.0 && O___BOT > 0.0 && O___EOT == 0.0)
			{
				Point pt4 = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo4 = bandedGridView1.CalcHitInfo(pt4);
				if (bandedGridHitInfo4.InRowCell)
				{
					int rowHandle4 = bandedGridHitInfo4.RowHandle;
					GridColumn column4 = bandedGridHitInfo4.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), column4.ToString(), null);
				}
				string text5 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "MOT").ToString();
				string text6 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "BOT").ToString();
				if ((text5 == "-" || string.IsNullOrEmpty(text5)) && (text6 == "-" || string.IsNullOrEmpty(text6)))
				{
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "GradeScore", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Comment", "-");
				}
			}
			else if (O___MOT > 0.0 && O___HOP == 0.0 && O___BOT > 0.0 && O___EOT > 0.0)
			{
				Point pt5 = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo5 = bandedGridView1.CalcHitInfo(pt5);
				if (bandedGridHitInfo5.InRowCell)
				{
					int rowHandle5 = bandedGridHitInfo5.RowHandle;
					GridColumn column5 = bandedGridHitInfo5.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), column5.ToString(), null);
				}
				string text7 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "EOT").ToString();
				string text8 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "MOT").ToString();
				string text9 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "BOT").ToString();
				if ((text7 == "-" || string.IsNullOrEmpty(text7)) && (text9 == "-" || string.IsNullOrEmpty(text9)) && (text8 == "-" || string.IsNullOrEmpty(text8)))
				{
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "GradeScore", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Comment", "-");
				}
			}
			else if (O___MOT > 0.0 && O___HOP > 0.0 && O___BOT > 0.0 && O___EOT > 0.0)
			{
				Point pt6 = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo6 = bandedGridView1.CalcHitInfo(pt6);
				if (bandedGridHitInfo6.InRowCell)
				{
					int rowHandle6 = bandedGridHitInfo6.RowHandle;
					GridColumn column6 = bandedGridHitInfo6.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), column6.ToString(), null);
				}
				string text10 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "EOT").ToString();
				string text11 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "MOT").ToString();
				string text12 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "BOT").ToString();
				string text13 = bandedGridView1.GetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "HoP").ToString();
				if ((text10 == "-" || string.IsNullOrEmpty(text10)) && (text12 == "-" || string.IsNullOrEmpty(text12)) && (text11 == "-" || string.IsNullOrEmpty(text11)) && (text13 == "-" || string.IsNullOrEmpty(text13)))
				{
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "GradeScore", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Comment", "-");
				}
			}
		}
	}

	private void bandedGridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void bandedGridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 0 to 100 only.";
		bandedGridView1.HideEditor();
	}

	private void bandedGridView1_RowClick(object sender, RowClickEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			popupMenu1.MenuCaption = "Drop Subject";
			popupMenu1.ShowPopup(Control.MousePosition);
		}
		else
		{
			popupMenu1.HidePopup();
		}
	}

	private void bandedGridView1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Apps)
		{
			popupMenu1.MenuCaption = "Drop Subject";
			popupMenu1.ShowPopup(Control.MousePosition);
		}
		else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
		{
			e.Handled = true;
		}
		else
		{
			popupMenu1.HidePopup();
		}
	}

	private void bandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "HoP" || e.Column.FieldName == "BOT" || e.Column.FieldName == "MOT" || e.Column.FieldName == "EOT")
		{
			MarksCalculator(e);
		}
	}

	private void bgSaveMarks_DoWork(object sender, DoWorkEventArgs e)
	{
		ThematicRatios.InitializeRatios(lblClass.Caption, lblSemester.Caption);
		ExamsOutputString.InitializeExamsOutputStrings(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
	}

	private void bgSaveMarks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		O___HOP = ThematicRatios.HoP;
		O___BOT = ThematicRatios.BOT;
		O___MOT = ThematicRatios.MOT;
		O___EOT = ThematicRatios.EOT;
		O_ProcessAsPercentages = ThematicRatios.ProcessAsPercentages;
		O__dt_g = gradingScale.SubjectGradingScale;
		NotAs100 = ThematicRatios.MarksNot100;
		gridColHoP.Caption = ExamsOutputString.hHoP;
		gridColBOT.Caption = ExamsOutputString.hBOT;
		gridColMOT.Caption = ExamsOutputString.hMOT;
		gridColEOT.Caption = ExamsOutputString.hEOT;
		tmUpdate.Enabled = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
			if (trans != null)
			{
				trans.Dispose();
				trans = null;
			}
			if (trans_s != null)
			{
				trans_s.Dispose();
				trans_s = null;
			}
			if (transaction != null)
			{
				transaction.Dispose();
				transaction = null;
			}
			if (_dt != null)
			{
				_dt.Dispose();
				_dt = null;
			}
			if (dt != null)
			{
				dt.Dispose();
				dt = null;
			}
			if (dts != null)
			{
				dts.Dispose();
				dts = null;
			}
			if (O__dt_g != null)
			{
				O__dt_g.Dispose();
				O__dt_g = null;
			}
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem9 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem10 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem11 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.ToolTipSeparatorItem item = new DevExpress.Utils.ToolTipSeparatorItem();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem12 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.SuperToolTip superToolTip13 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem13 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem13 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip14 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipItem toolTipItem14 = new DevExpress.Utils.ToolTipItem();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarksEntry.MarksEntryForms.MainPrimary));
		DevExpress.Utils.SuperToolTip superToolTip15 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem14 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem15 = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip16 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem15 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem16 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
		this.gridColumnGrade = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.lblSubject = new DevExpress.XtraBars.BarStaticItem();
		this.lblSemester = new DevExpress.XtraBars.BarStaticItem();
		this.lblClass = new DevExpress.XtraBars.BarStaticItem();
		this.lblStream = new DevExpress.XtraBars.BarStaticItem();
		this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
		this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
		this.barCaramel = new DevExpress.XtraBars.BarCheckItem();
		this.barMoneyTwins = new DevExpress.XtraBars.BarCheckItem();
		this.barIMaginary = new DevExpress.XtraBars.BarCheckItem();
		this.barCoffee = new DevExpress.XtraBars.BarCheckItem();
		this.barLiquidSky = new DevExpress.XtraBars.BarCheckItem();
		this.barValentine = new DevExpress.XtraBars.BarCheckItem();
		this.barMcSkin = new DevExpress.XtraBars.BarCheckItem();
		this.barSummer2008 = new DevExpress.XtraBars.BarCheckItem();
		this.barPumpkin = new DevExpress.XtraBars.BarCheckItem();
		this.barBlue = new DevExpress.XtraBars.BarCheckItem();
		this.barSpringtime = new DevExpress.XtraBars.BarCheckItem();
		this.barDarkroom = new DevExpress.XtraBars.BarCheckItem();
		this.barOffice2007Blue = new DevExpress.XtraBars.BarCheckItem();
		this.barOffice2007Green = new DevExpress.XtraBars.BarCheckItem();
		this.barOffice2010Blue = new DevExpress.XtraBars.BarCheckItem();
		this.barOffice2010Black = new DevExpress.XtraBars.BarCheckItem();
		this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem21 = new DevExpress.XtraBars.BarButtonItem();
		this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
		this.gridControlStudents = new DevExpress.XtraGrid.GridControl();
		this.gridViewStudents = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
		this.lblInitial = new DevExpress.XtraBars.BarStaticItem();
		this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
		this.barListItem1 = new DevExpress.XtraBars.BarListItem();
		this.lblMachineName = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem7 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem8 = new DevExpress.XtraBars.BarStaticItem();
		this.lblIpAddress = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem22 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem23 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem24 = new DevExpress.XtraBars.BarButtonItem();
		this.barComboSubjects = new DevExpress.XtraBars.BarEditItem();
		this.cboSelectedSubject = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
		this.txtSemester = new DevExpress.XtraBars.BarEditItem();
		this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.lblLANStatus = new DevExpress.XtraBars.BarStaticItem();
		this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
		this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.barComboClasses = new DevExpress.XtraBars.BarEditItem();
		this.cboSelectedClass = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
		this.barComboStream = new DevExpress.XtraBars.BarEditItem();
		this.cboSelectedStream = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
		this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
		this.dgMain = new DevExpress.XtraGrid.GridControl();
		this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColHoP = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColBOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColMOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColEOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColumn19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColumn21 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tmUpdate = new System.Windows.Forms.Timer(this.components);
		this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
		this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
		this.bgSaveMarks = new System.ComponentModel.BackgroundWorker();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
		this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
		this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
		this.xtraTabMarksEntry = new DevExpress.XtraTab.XtraTabPage();
		this.xtraTabFileLogo = new DevExpress.XtraTab.XtraTabPage();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		((System.ComponentModel.ISupportInitialize)this.popupControlContainer1).BeginInit();
		this.popupControlContainer1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControlStudents).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudents).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedSubject).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedClass).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedStream).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).BeginInit();
		this.xtraTabControl1.SuspendLayout();
		this.xtraTabMarksEntry.SuspendLayout();
		this.xtraTabFileLogo.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		this.xtraTabPage1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		base.SuspendLayout();
		this.gridColumnGrade.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumnGrade.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumnGrade.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumnGrade.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumnGrade.Caption = "Grade";
		this.gridColumnGrade.FieldName = "Grade";
		this.gridColumnGrade.MinWidth = 13;
		this.gridColumnGrade.Name = "gridColumnGrade";
		this.gridColumnGrade.OptionsColumn.AllowEdit = false;
		this.gridColumnGrade.OptionsColumn.ReadOnly = true;
		this.gridColumnGrade.Visible = true;
		this.gridColumnGrade.Width = 41;
		this.lblSubject.Caption = "Subject";
		this.lblSubject.Id = 0;
		this.lblSubject.Name = "lblSubject";
		this.lblSubject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.lblSemester.Caption = "Semester";
		this.lblSemester.Id = 1;
		this.lblSemester.Name = "lblSemester";
		this.lblClass.Caption = "Class";
		this.lblClass.Id = 2;
		this.lblClass.Name = "lblClass";
		this.lblStream.Id = 3;
		this.lblStream.Name = "lblStream";
		this.barSubItem1.Caption = "&File";
		this.barSubItem1.Id = 24;
		this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[6]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5, true),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem13, true),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem14),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem16),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem10)
		});
		this.barSubItem1.Name = "barSubItem1";
		this.barButtonItem5.Caption = "Print";
		this.barButtonItem5.Id = 26;
		this.barButtonItem5.ImageOptions.LargeImage = MarksEntry.Properties.Resources.print_32x32;
		this.barButtonItem5.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control);
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.barButtonItem6.Caption = "Print priview";
		this.barButtonItem6.Id = 27;
		this.barButtonItem6.ImageOptions.LargeImage = MarksEntry.Properties.Resources.preview_32x32;
		this.barButtonItem6.Name = "barButtonItem6";
		this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barButtonItem13.Caption = "Export";
		this.barButtonItem13.Id = 70;
		this.barButtonItem13.ImageOptions.LargeImage = MarksEntry.Properties.Resources.accExport;
		this.barButtonItem13.Name = "barButtonItem13";
		toolTipTitleItem.Text = "Export to Excel";
		toolTipItem.LeftIndent = 6;
		toolTipItem.Text = "Export marksheet to excel.";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.barButtonItem13.SuperTip = superToolTip;
		this.barButtonItem13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem13_ItemClick);
		this.barButtonItem14.Caption = "Import";
		this.barButtonItem14.Id = 71;
		this.barButtonItem14.ImageOptions.LargeImage = MarksEntry.Properties.Resources.accExport;
		this.barButtonItem14.Name = "barButtonItem14";
		toolTipTitleItem2.Text = "Import from Excel";
		toolTipItem2.LeftIndent = 6;
		toolTipItem2.Text = "Import marksheets previous exported to excel.";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.barButtonItem14.SuperTip = superToolTip2;
		this.barButtonItem14.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem14_ItemClick);
		this.barButtonItem16.Caption = "File Log";
		this.barButtonItem16.Id = 77;
		this.barButtonItem16.ImageOptions.LargeImage = MarksEntry.Properties.Resources.log;
		this.barButtonItem16.Name = "barButtonItem16";
		toolTipTitleItem3.Text = "File Log";
		toolTipItem3.LeftIndent = 6;
		toolTipItem3.Text = "List of Exported and Imported Files.";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		this.barButtonItem16.SuperTip = superToolTip3;
		this.barButtonItem16.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem16_ItemClick);
		this.barButtonItem10.Caption = "Exit";
		this.barButtonItem10.Id = 32;
		this.barButtonItem10.ImageOptions.LargeImage = MarksEntry.Properties.Resources.delete;
		this.barButtonItem10.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4 | System.Windows.Forms.Keys.Alt);
		this.barButtonItem10.Name = "barButtonItem10";
		this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem10_ItemClick);
		this.barSubItem3.Caption = "&View";
		this.barSubItem3.Id = 41;
		this.barSubItem3.Name = "barSubItem3";
		this.barCaramel.AllowAllUp = true;
		this.barCaramel.Caption = "Caramel";
		this.barCaramel.GroupIndex = 1;
		this.barCaramel.Id = 47;
		this.barCaramel.Name = "barCaramel";
		this.barMoneyTwins.AllowAllUp = true;
		this.barMoneyTwins.Caption = "Money Twins";
		this.barMoneyTwins.GroupIndex = 1;
		this.barMoneyTwins.Id = 48;
		this.barMoneyTwins.Name = "barMoneyTwins";
		this.barIMaginary.AllowAllUp = true;
		this.barIMaginary.Caption = "iMaginary";
		this.barIMaginary.GroupIndex = 1;
		this.barIMaginary.Id = 49;
		this.barIMaginary.Name = "barIMaginary";
		this.barCoffee.AllowAllUp = true;
		this.barCoffee.Caption = "Coffee";
		this.barCoffee.GroupIndex = 1;
		this.barCoffee.Id = 50;
		this.barCoffee.Name = "barCoffee";
		this.barLiquidSky.AllowAllUp = true;
		this.barLiquidSky.Caption = "Liquid Sky";
		this.barLiquidSky.GroupIndex = 1;
		this.barLiquidSky.Id = 51;
		this.barLiquidSky.Name = "barLiquidSky";
		this.barValentine.AllowAllUp = true;
		this.barValentine.Caption = "Valentine";
		this.barValentine.GroupIndex = 1;
		this.barValentine.Id = 52;
		this.barValentine.Name = "barValentine";
		this.barMcSkin.AllowAllUp = true;
		this.barMcSkin.Caption = "McSkin";
		this.barMcSkin.GroupIndex = 1;
		this.barMcSkin.Id = 53;
		this.barMcSkin.Name = "barMcSkin";
		this.barSummer2008.AllowAllUp = true;
		this.barSummer2008.Caption = "Summer 2008";
		this.barSummer2008.GroupIndex = 1;
		this.barSummer2008.Id = 54;
		this.barSummer2008.Name = "barSummer2008";
		this.barPumpkin.AllowAllUp = true;
		this.barPumpkin.Caption = "Pumpkin";
		this.barPumpkin.GroupIndex = 1;
		this.barPumpkin.Id = 55;
		this.barPumpkin.Name = "barPumpkin";
		this.barBlue.AllowAllUp = true;
		this.barBlue.Caption = "Blue";
		this.barBlue.GroupIndex = 1;
		this.barBlue.Id = 56;
		this.barBlue.Name = "barBlue";
		this.barSpringtime.AllowAllUp = true;
		this.barSpringtime.Caption = "Springtime";
		this.barSpringtime.GroupIndex = 1;
		this.barSpringtime.Id = 57;
		this.barSpringtime.Name = "barSpringtime";
		this.barDarkroom.AllowAllUp = true;
		this.barDarkroom.Caption = "Darkroom";
		this.barDarkroom.GroupIndex = 1;
		this.barDarkroom.Id = 58;
		this.barDarkroom.Name = "barDarkroom";
		this.barOffice2007Blue.AllowAllUp = true;
		this.barOffice2007Blue.Caption = "Office 2007 Blue";
		this.barOffice2007Blue.GroupIndex = 1;
		this.barOffice2007Blue.Id = 59;
		this.barOffice2007Blue.Name = "barOffice2007Blue";
		this.barOffice2007Green.AllowAllUp = true;
		this.barOffice2007Green.Caption = "Office 2007 Green";
		this.barOffice2007Green.GroupIndex = 1;
		this.barOffice2007Green.Id = 60;
		this.barOffice2007Green.Name = "barOffice2007Green";
		this.barOffice2010Blue.AllowAllUp = true;
		this.barOffice2010Blue.Caption = "Office 2010 Blue";
		this.barOffice2010Blue.GroupIndex = 1;
		this.barOffice2010Blue.Id = 61;
		this.barOffice2010Blue.Name = "barOffice2010Blue";
		this.barOffice2010Black.AllowAllUp = true;
		this.barOffice2010Black.Caption = "Office 2010 Black";
		this.barOffice2010Black.GroupIndex = 1;
		this.barOffice2010Black.Id = 62;
		this.barOffice2010Black.Name = "barOffice2010Black";
		this.barSubItem6.Caption = "Subject";
		this.barSubItem6.Id = 86;
		this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem21),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem22),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem24),
			new DevExpress.XtraBars.LinkPersistInfo(this.barComboSubjects)
		});
		this.barSubItem6.Name = "barSubItem6";
		this.barButtonItem21.ActAsDropDown = true;
		this.barButtonItem21.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem21.Caption = "Register";
		this.barButtonItem21.DropDownControl = this.popupControlContainer1;
		this.barButtonItem21.Id = 87;
		this.barButtonItem21.ImageOptions.Image = MarksEntry.Properties.Resources.subAdd;
		this.barButtonItem21.ImageOptions.LargeImage = MarksEntry.Properties.Resources.subAdd;
		this.barButtonItem21.Name = "barButtonItem21";
		toolTipTitleItem4.Text = "Register";
		toolTipItem4.LeftIndent = 6;
		toolTipItem4.Text = "Register more students for this subject.";
		superToolTip4.Items.Add(toolTipTitleItem4);
		superToolTip4.Items.Add(toolTipItem4);
		this.barButtonItem21.SuperTip = superToolTip4;
		this.barButtonItem21.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem21_ItemClick);
		this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.popupControlContainer1.Controls.Add(this.gridControlStudents);
		this.popupControlContainer1.Location = new System.Drawing.Point(265, 3);
		this.popupControlContainer1.Name = "popupControlContainer1";
		this.popupControlContainer1.Ribbon = this.ribbonControl1;
		this.popupControlContainer1.ShowCloseButton = true;
		this.popupControlContainer1.ShowSizeGrip = true;
		this.popupControlContainer1.Size = new System.Drawing.Size(521, 444);
		this.popupControlContainer1.TabIndex = 0;
		this.popupControlContainer1.Visible = false;
		this.gridControlStudents.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControlStudents.Location = new System.Drawing.Point(0, 0);
		this.gridControlStudents.MainView = this.gridViewStudents;
		this.gridControlStudents.Name = "gridControlStudents";
		this.gridControlStudents.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemPictureEdit1, this.repositoryItemMemoEdit1 });
		this.gridControlStudents.Size = new System.Drawing.Size(521, 444);
		this.gridControlStudents.TabIndex = 0;
		this.gridControlStudents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridViewStudents });
		this.gridControlStudents.DoubleClick += new System.EventHandler(gridControlStudents_DoubleClick);
		this.gridViewStudents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn9, this.gridColumn10 });
		this.gridViewStudents.DetailHeight = 239;
		this.gridViewStudents.GridControl = this.gridControlStudents;
		this.gridViewStudents.Name = "gridViewStudents";
		this.gridViewStudents.OptionsBehavior.Editable = false;
		this.gridViewStudents.OptionsFind.AlwaysVisible = true;
		this.gridViewStudents.OptionsView.ShowGroupPanel = false;
		this.gridViewStudents.OptionsView.ShowIndicator = false;
		this.gridViewStudents.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridViewStudents.RowHeight = 48;
		this.gridViewStudents.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridViewStudents_RowCellStyle);
		this.gridViewStudents.MouseMove += new System.Windows.Forms.MouseEventHandler(gridViewStudents_MouseMove);
		this.gridColumn9.Caption = "Photo";
		this.gridColumn9.ColumnEdit = this.repositoryItemPictureEdit1;
		this.gridColumn9.FieldName = "Picture";
		this.gridColumn9.MinWidth = 13;
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 0;
		this.gridColumn9.Width = 116;
		this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
		this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.gridColumn10.Caption = "Details";
		this.gridColumn10.ColumnEdit = this.repositoryItemMemoEdit1;
		this.gridColumn10.FieldName = "fullName";
		this.gridColumn10.MinWidth = 13;
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 1;
		this.gridColumn10.Width = 671;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(20, 21, 20, 21);
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[65]
		{
			this.ribbonControl1.ExpandCollapseItem,
			this.ribbonControl1.SearchEditItem,
			this.lblSubject,
			this.lblSemester,
			this.lblClass,
			this.lblStream,
			this.barButtonItem1,
			this.barButtonItem2,
			this.barButtonItem3,
			this.barStaticItem6,
			this.lblInitial,
			this.barSubItem1,
			this.barButtonItem5,
			this.barButtonItem6,
			this.barSubItem2,
			this.barButtonItem7,
			this.barButtonItem8,
			this.barButtonItem9,
			this.barButtonItem10,
			this.barButtonItem11,
			this.barSubItem3,
			this.barListItem1,
			this.barCaramel,
			this.barMoneyTwins,
			this.barIMaginary,
			this.barCoffee,
			this.barLiquidSky,
			this.barValentine,
			this.barMcSkin,
			this.barSummer2008,
			this.barPumpkin,
			this.barBlue,
			this.barSpringtime,
			this.barDarkroom,
			this.barOffice2007Blue,
			this.barOffice2007Green,
			this.barOffice2010Blue,
			this.barOffice2010Black,
			this.lblMachineName,
			this.barStaticItem7,
			this.barStaticItem8,
			this.lblIpAddress,
			this.barButtonItem12,
			this.barButtonItem13,
			this.barButtonItem14,
			this.barButtonItem15,
			this.barButtonItem16,
			this.barButtonItem18,
			this.barButtonItem19,
			this.barButtonItem20,
			this.barSubItem6,
			this.barButtonItem21,
			this.barButtonItem22,
			this.barButtonItem23,
			this.barButtonItem24,
			this.barComboSubjects,
			this.txtSemester,
			this.lblLANStatus,
			this.barEditItem1,
			this.barComboClasses,
			this.barComboStream,
			this.barButtonItem4,
			this.barButtonItem17,
			this.barStaticItem1,
			this.barStaticItem2
		});
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 116;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.OptionsMenuMinWidth = 220;
		this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
		this.ribbonControl1.PageHeaderItemLinks.Add(this.barComboSubjects);
		this.ribbonControl1.PageHeaderItemLinks.Add(this.barComboClasses);
		this.ribbonControl1.PageHeaderItemLinks.Add(this.barComboStream);
		this.ribbonControl1.PageHeaderItemLinks.Add(this.lblSubject);
		this.ribbonControl1.PageHeaderItemLinks.Add(this.txtSemester, true);
		this.ribbonControl1.PageHeaderItemLinks.Add(this.barButtonItem4);
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[6] { this.cboSelectedSubject, this.repositoryItemTextEdit1, this.repositoryItemTextEdit2, this.repositoryItemPictureEdit2, this.cboSelectedClass, this.cboSelectedStream });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
		this.ribbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(907, 147);
		this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.barButtonItem1.Caption = "Print";
		this.barButtonItem1.Id = 17;
		this.barButtonItem1.ImageOptions.Image = MarksEntry.Properties.Resources.print_32x32;
		this.barButtonItem1.Name = "barButtonItem1";
		toolTipTitleItem5.Text = "Print";
		toolTipItem5.LeftIndent = 6;
		toolTipItem5.Text = "Print...";
		superToolTip5.Items.Add(toolTipTitleItem5);
		superToolTip5.Items.Add(toolTipItem5);
		this.barButtonItem1.SuperTip = superToolTip5;
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Print preview";
		this.barButtonItem2.Id = 18;
		this.barButtonItem2.ImageOptions.Image = MarksEntry.Properties.Resources.preview_32x32;
		this.barButtonItem2.Name = "barButtonItem2";
		toolTipTitleItem6.Text = "Print preview";
		toolTipItem6.LeftIndent = 6;
		toolTipItem6.Text = "Preview report to custom it before printing";
		superToolTip6.Items.Add(toolTipTitleItem6);
		superToolTip6.Items.Add(toolTipItem6);
		this.barButtonItem2.SuperTip = superToolTip6;
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Save";
		this.barButtonItem3.Id = 19;
		this.barButtonItem3.ImageOptions.Image = MarksEntry.Properties.Resources.save;
		this.barButtonItem3.ImageOptions.LargeImage = MarksEntry.Properties.Resources.save;
		this.barButtonItem3.Name = "barButtonItem3";
		toolTipTitleItem7.Text = "Save";
		toolTipItem7.LeftIndent = 6;
		toolTipItem7.Text = "Save...";
		superToolTip7.Items.Add(toolTipTitleItem7);
		superToolTip7.Items.Add(toolTipItem7);
		this.barButtonItem3.SuperTip = superToolTip7;
		this.barStaticItem6.Caption = "Current user:";
		this.barStaticItem6.Id = 22;
		this.barStaticItem6.Name = "barStaticItem6";
		this.lblInitial.Caption = "Initials";
		this.lblInitial.Id = 23;
		this.lblInitial.Name = "lblInitial";
		this.barSubItem2.Caption = "Export to";
		this.barSubItem2.Id = 28;
		this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[4]
		{
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
			new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem11)
		});
		this.barSubItem2.Name = "barSubItem2";
		this.barButtonItem8.Id = 73;
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem7.Id = 72;
		this.barButtonItem7.Name = "barButtonItem7";
		this.barButtonItem9.Id = 74;
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem11.Id = 75;
		this.barButtonItem11.Name = "barButtonItem11";
		this.barListItem1.Caption = "Tool bars";
		this.barListItem1.Id = 43;
		this.barListItem1.Name = "barListItem1";
		this.lblMachineName.Caption = "Work station";
		this.lblMachineName.Id = 63;
		this.lblMachineName.Name = "lblMachineName";
		this.barStaticItem7.Caption = "Workstation:";
		this.barStaticItem7.Id = 65;
		this.barStaticItem7.Name = "barStaticItem7";
		this.barStaticItem8.Caption = "IP Address:";
		this.barStaticItem8.Id = 66;
		this.barStaticItem8.Name = "barStaticItem8";
		this.lblIpAddress.Id = 67;
		this.lblIpAddress.Name = "lblIpAddress";
		this.barButtonItem12.Caption = "Export";
		this.barButtonItem12.Id = 69;
		this.barButtonItem12.ImageOptions.Image = MarksEntry.Properties.Resources.page_next;
		this.barButtonItem12.Name = "barButtonItem12";
		this.barButtonItem12.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem12_ItemClick);
		this.barButtonItem15.Caption = "Import";
		this.barButtonItem15.Id = 76;
		this.barButtonItem15.ImageOptions.Image = MarksEntry.Properties.Resources.page_previous;
		this.barButtonItem15.Name = "barButtonItem15";
		this.barButtonItem15.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem15_ItemClick);
		this.barButtonItem18.Caption = "Log out";
		this.barButtonItem18.Id = 79;
		this.barButtonItem18.Name = "barButtonItem18";
		this.barButtonItem19.Caption = "Register Subject";
		this.barButtonItem19.Id = 81;
		this.barButtonItem19.ImageOptions.Image = MarksEntry.Properties.Resources.subAdd;
		this.barButtonItem19.ImageOptions.LargeImage = MarksEntry.Properties.Resources.subAdd;
		this.barButtonItem19.Name = "barButtonItem19";
		this.barButtonItem20.Caption = "Drop for selected Student";
		this.barButtonItem20.Id = 82;
		this.barButtonItem20.ImageOptions.Image = MarksEntry.Properties.Resources.subRemove;
		this.barButtonItem20.ImageOptions.LargeImage = MarksEntry.Properties.Resources.subRemove;
		this.barButtonItem20.Name = "barButtonItem20";
		this.barButtonItem20.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem20_ItemClick);
		this.barButtonItem22.Caption = "Drop Student";
		this.barButtonItem22.Id = 88;
		this.barButtonItem22.ImageOptions.Image = MarksEntry.Properties.Resources.subRemove;
		this.barButtonItem22.ImageOptions.LargeImage = MarksEntry.Properties.Resources.book;
		this.barButtonItem22.Name = "barButtonItem22";
		toolTipTitleItem8.Text = "Drop Student";
		toolTipItem8.LeftIndent = 6;
		toolTipItem8.Text = "Drop/Unregister this subject for the selected student.";
		superToolTip8.Items.Add(toolTipTitleItem8);
		superToolTip8.Items.Add(toolTipItem8);
		this.barButtonItem22.SuperTip = superToolTip8;
		this.barButtonItem22.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem22_ItemClick);
		this.barButtonItem23.Caption = "Drop for this Class";
		this.barButtonItem23.Id = 89;
		this.barButtonItem23.Name = "barButtonItem23";
		this.barButtonItem24.Caption = "Drop Class";
		this.barButtonItem24.Id = 90;
		this.barButtonItem24.ImageOptions.LargeImage = MarksEntry.Properties.Resources.bookClass;
		this.barButtonItem24.Name = "barButtonItem24";
		toolTipTitleItem9.Text = "Drop Class";
		toolTipItem9.LeftIndent = 6;
		toolTipItem9.Text = "Drop/Unregister this Subject/Paper for the entire  class.";
		superToolTip9.Items.Add(toolTipTitleItem9);
		superToolTip9.Items.Add(toolTipItem9);
		this.barButtonItem24.SuperTip = superToolTip9;
		this.barButtonItem24.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem24_ItemClick);
		this.barComboSubjects.Edit = this.cboSelectedSubject;
		this.barComboSubjects.EditWidth = 150;
		this.barComboSubjects.Id = 91;
		this.barComboSubjects.Name = "barComboSubjects";
		toolTipTitleItem10.Text = "Change paper";
		toolTipItem10.LeftIndent = 6;
		toolTipItem10.Text = "Change and Enter Marks to another paper for currently logged in Class.\r\n\r\nThis option works for A Level classes only.";
		superToolTip10.Items.Add(toolTipTitleItem10);
		superToolTip10.Items.Add(toolTipItem10);
		this.barComboSubjects.SuperTip = superToolTip10;
		this.cboSelectedSubject.AutoHeight = false;
		this.cboSelectedSubject.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedSubject.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSelectedSubject.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedSubject.Name = "cboSelectedSubject";
		this.txtSemester.Edit = this.repositoryItemTextEdit2;
		this.txtSemester.EditWidth = 75;
		this.txtSemester.Enabled = false;
		this.txtSemester.Id = 98;
		this.txtSemester.Name = "txtSemester";
		toolTipItem11.Text = "Active Semester";
		superToolTip11.Items.Add(toolTipItem11);
		this.txtSemester.SuperTip = superToolTip11;
		this.txtSemester.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.repositoryItemTextEdit2.AutoHeight = false;
		this.repositoryItemTextEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
		this.repositoryItemTextEdit2.ReadOnly = true;
		this.lblLANStatus.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.lblLANStatus.Id = 100;
		this.lblLANStatus.Name = "lblLANStatus";
		this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.barEditItem1.Edit = this.repositoryItemPictureEdit2;
		this.barEditItem1.EditHeight = 24;
		this.barEditItem1.EditWidth = 24;
		this.barEditItem1.Id = 102;
		this.barEditItem1.Name = "barEditItem1";
		this.repositoryItemPictureEdit2.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.Appearance.BackColor2 = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.Appearance.BorderColor = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.Appearance.Options.UseBackColor = true;
		this.repositoryItemPictureEdit2.Appearance.Options.UseBorderColor = true;
		this.repositoryItemPictureEdit2.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.AppearanceDisabled.BackColor2 = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.AppearanceDisabled.Options.UseBackColor = true;
		this.repositoryItemPictureEdit2.AppearanceDisabled.Options.UseBorderColor = true;
		this.repositoryItemPictureEdit2.AppearanceFocused.BackColor = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.AppearanceFocused.BorderColor = System.Drawing.Color.Transparent;
		this.repositoryItemPictureEdit2.AppearanceFocused.Options.UseBackColor = true;
		this.repositoryItemPictureEdit2.AppearanceFocused.Options.UseBorderColor = true;
		this.repositoryItemPictureEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
		this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.barComboClasses.Edit = this.cboSelectedClass;
		this.barComboClasses.Id = 113;
		this.barComboClasses.Name = "barComboClasses";
		toolTipTitleItem11.Text = "Class";
		toolTipItem12.LeftIndent = 6;
		toolTipItem12.Text = "Change to Enter Marks for another class by using  current login credentials.";
		toolTipTitleItem12.LeftIndent = 6;
		toolTipTitleItem12.Text = "Press F1 for help.";
		superToolTip12.Items.Add(toolTipTitleItem11);
		superToolTip12.Items.Add(toolTipItem12);
		superToolTip12.Items.Add(item);
		superToolTip12.Items.Add(toolTipTitleItem12);
		this.barComboClasses.SuperTip = superToolTip12;
		this.barComboClasses.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
		this.cboSelectedClass.AutoHeight = false;
		this.cboSelectedClass.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedClass.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSelectedClass.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedClass.Name = "cboSelectedClass";
		this.barComboStream.Edit = this.cboSelectedStream;
		this.barComboStream.EditWidth = 100;
		this.barComboStream.Id = 119;
		this.barComboStream.Name = "barComboStream";
		toolTipTitleItem13.Text = "Stream";
		toolTipItem13.LeftIndent = 6;
		toolTipItem13.Text = "Filter Marksheet by stream.";
		superToolTip13.Items.Add(toolTipTitleItem13);
		superToolTip13.Items.Add(toolTipItem13);
		this.barComboStream.SuperTip = superToolTip13;
		this.barComboStream.HiddenEditor += new DevExpress.XtraBars.ItemClickEventHandler(barComboStream_HiddenEditor);
		this.cboSelectedStream.AutoHeight = false;
		this.cboSelectedStream.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedStream.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSelectedStream.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedStream.Name = "cboSelectedStream";
		this.cboSelectedStream.NullText = "Stream Filter";
		this.cboSelectedStream.NullValuePrompt = "Stream Filter";
		this.barButtonItem4.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
		this.barButtonItem4.Caption = "Skin";
		this.barButtonItem4.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
		this.barButtonItem4.DropDownControl = this.popupMenu2;
		toolTipItem14.Text = "Click here to show skins.";
		superToolTip14.Items.Add(toolTipItem14);
		this.barButtonItem4.DropDownSuperTip = superToolTip14;
		this.barButtonItem4.Id = 1;
		this.barButtonItem4.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.Image");
		this.barButtonItem4.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.LargeImage");
		this.barButtonItem4.Name = "barButtonItem4";
		toolTipTitleItem14.Text = "Look and Feel";
		toolTipItem15.LeftIndent = 6;
		toolTipItem15.Text = "Change your application Look and Feel (skin) from here.";
		superToolTip15.Items.Add(toolTipTitleItem14);
		superToolTip15.Items.Add(toolTipItem15);
		this.barButtonItem4.SuperTip = superToolTip15;
		this.popupMenu2.Name = "popupMenu2";
		this.popupMenu2.Ribbon = this.ribbonControl1;
		this.popupMenu2.CloseUp += new System.EventHandler(popupMenu2_CloseUp);
		this.barButtonItem17.Caption = "Logout";
		this.barButtonItem17.Id = 87;
		this.barButtonItem17.ImageOptions.LargeImage = MarksEntry.Properties.Resources.business_user_lock;
		this.barButtonItem17.Name = "barButtonItem17";
		toolTipTitleItem15.Text = "Logout";
		toolTipItem16.LeftIndent = 6;
		toolTipItem16.Text = "Logout of your account or easily switch to another class or subject without exiting the program";
		superToolTip16.Items.Add(toolTipTitleItem15);
		superToolTip16.Items.Add(toolTipItem16);
		this.barButtonItem17.SuperTip = superToolTip16;
		this.barStaticItem1.Caption = "Term:";
		this.barStaticItem1.Id = 93;
		this.barStaticItem1.Name = "barStaticItem1";
		this.barStaticItem2.Caption = "Class:";
		this.barStaticItem2.Id = 94;
		this.barStaticItem2.Name = "barStaticItem2";
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[4] { this.ribbonPageGroup3, this.ribbonPageGroup4, this.ribbonPageGroup1, this.ribbonPageGroup5 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "Main Menu";
		this.ribbonPageGroup3.AllowTextClipping = false;
		this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem21);
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem22);
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem24);
		this.ribbonPageGroup3.Name = "ribbonPageGroup3";
		this.ribbonPageGroup3.Text = "Subject";
		this.ribbonPageGroup4.AllowTextClipping = false;
		this.ribbonPageGroup4.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem13);
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem14);
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem16);
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem5, true);
		this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem6);
		this.ribbonPageGroup4.Name = "ribbonPageGroup4";
		this.ribbonPageGroup4.Text = "Printing and Exporting";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem17);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.Text = "Logout";
		this.ribbonPageGroup5.AllowTextClipping = false;
		this.ribbonPageGroup5.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem10);
		this.ribbonPageGroup5.Name = "ribbonPageGroup5";
		this.ribbonPageGroup5.Text = "Close";
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.repositoryItemTextEdit1.ReadOnly = true;
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem6);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblInitial);
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem7, true);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblMachineName);
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem8, true);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblIpAddress);
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1, true);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblSemester);
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2, true);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblClass);
		this.ribbonStatusBar1.ItemLinks.Add(this.barEditItem1);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblLANStatus);
		this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 513);
		this.ribbonStatusBar1.Name = "ribbonStatusBar1";
		this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
		this.ribbonStatusBar1.Size = new System.Drawing.Size(907, 23);
		this.dgMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode.RelationName = "Level1";
		this.dgMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode });
		this.dgMain.Location = new System.Drawing.Point(0, 0);
		this.dgMain.MainView = this.bandedGridView1;
		this.dgMain.Name = "dgMain";
		this.dgMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit1 });
		this.dgMain.Size = new System.Drawing.Size(905, 364);
		this.dgMain.TabIndex = 4;
		this.dgMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.bandedGridView1 });
		this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(dgMain_KeyDown);
		this.bandedGridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(132, 171, 228);
		this.bandedGridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(247, 251, 255);
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(154, 190, 243);
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(247, 251, 255);
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.bandedGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.bandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.Empty.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.Empty.Options.UseFont = true;
		this.bandedGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.EvenRow.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.EvenRow.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(132, 171, 228);
		this.bandedGridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.FilterCloseButton.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(62, 109, 185);
		this.bandedGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.FilterPanel.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.FilterPanel.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(59, 97, 156);
		this.bandedGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.FixedLine.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedCell.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(49, 106, 197);
		this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedRow.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(132, 171, 228);
		this.bandedGridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.FooterPanel.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.FooterPanel.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(193, 216, 247);
		this.bandedGridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(193, 216, 247);
		this.bandedGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.GroupButton.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.GroupButton.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupButton.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(193, 216, 247);
		this.bandedGridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(193, 216, 247);
		this.bandedGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.GroupFooter.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupFooter.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(62, 109, 185);
		this.bandedGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.GroupPanel.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupPanel.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(193, 216, 247);
		this.bandedGridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(193, 216, 247);
		this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.GroupRow.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.GroupRow.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupRow.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.bandedGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(106, 153, 228);
		this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(208, 224, 251);
		this.bandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(99, 127, 196);
		this.bandedGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.HorzLine.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.OddRow.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.OddRow.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(249, 252, 255);
		this.bandedGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(88, 129, 185);
		this.bandedGridView1.Appearance.Preview.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.Preview.Options.UseFont = true;
		this.bandedGridView1.Appearance.Preview.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.Row.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.Row.Options.UseFont = true;
		this.bandedGridView1.Appearance.Row.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.RowSeparator.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.bandedGridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(69, 126, 217);
		this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
		this.bandedGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.SelectedRow.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(99, 127, 196);
		this.bandedGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.VertLine.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.VertLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.BandPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.GhostWhite;
		this.bandedGridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
		this.bandedGridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.Preview.Options.UseBackColor = true;
		this.bandedGridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.AppearancePrint.Row.Options.UseFont = true;
		this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[4] { this.gridBand1, this.gridBand2, this.gridBand3, this.gridBand4 });
		this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[13]
		{
			this.gridColNo, this.gridColumn11, this.gridColumn12, this.gridColumn13, this.gridColumn14, this.gridColHoP, this.gridColBOT, this.gridColMOT, this.gridColEOT, this.gridColumn19,
			this.gridColumnGrade, this.gridColumn21, this.bandedGridColumn1
		});
		this.bandedGridView1.DetailHeight = 239;
		styleFormatCondition.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition.Appearance.Options.UseForeColor = true;
		styleFormatCondition.ApplyToRow = true;
		styleFormatCondition.Column = this.gridColumnGrade;
		styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition.Value1 = "F9";
		this.bandedGridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition });
		this.bandedGridView1.GridControl = this.dgMain;
		this.bandedGridView1.IndicatorWidth = 23;
		this.bandedGridView1.Name = "bandedGridView1";
		this.bandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.bandedGridView1.OptionsCustomization.AllowBandMoving = false;
		this.bandedGridView1.OptionsCustomization.AllowColumnMoving = false;
		this.bandedGridView1.OptionsCustomization.AllowFilter = false;
		this.bandedGridView1.OptionsCustomization.AllowGroup = false;
		this.bandedGridView1.OptionsCustomization.AllowSort = false;
		this.bandedGridView1.OptionsFilter.AllowColumnMRUFilterList = false;
		this.bandedGridView1.OptionsFilter.AllowFilterEditor = false;
		this.bandedGridView1.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.bandedGridView1.OptionsFilter.AllowMRUFilterList = false;
		this.bandedGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.bandedGridView1.OptionsView.ShowGroupPanel = false;
		this.bandedGridView1.OptionsView.ShowIndicator = false;
		this.bandedGridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.bandedGridView1.RowHeight = 17;
		this.bandedGridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(bandedGridView1_RowClick);
		this.bandedGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(bandedGridView1_CellValueChanged);
		this.bandedGridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(bandedGridView1_CustomColumnDisplayText);
		this.bandedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(bandedGridView1_KeyDown);
		this.bandedGridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(bandedGridView1_ValidatingEditor);
		this.bandedGridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(bandedGridView1_InvalidValueException);
		this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridBand1.AppearanceHeader.Options.UseFont = true;
		this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand1.Caption = "Pupil's Information";
		this.gridBand1.Columns.Add(this.gridColNo);
		this.gridBand1.Columns.Add(this.gridColumn11);
		this.gridBand1.Columns.Add(this.gridColumn12);
		this.gridBand1.Columns.Add(this.gridColumn13);
		this.gridBand1.Columns.Add(this.gridColumn14);
		this.gridBand1.MinWidth = 7;
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.OptionsBand.AllowHotTrack = false;
		this.gridBand1.OptionsBand.AllowMove = false;
		this.gridBand1.OptionsBand.AllowPress = false;
		this.gridBand1.VisibleIndex = 0;
		this.gridBand1.Width = 379;
		this.gridColNo.Caption = "#";
		this.gridColNo.MinWidth = 13;
		this.gridColNo.Name = "gridColNo";
		this.gridColNo.OptionsColumn.AllowEdit = false;
		this.gridColNo.OptionsColumn.ReadOnly = true;
		this.gridColNo.Visible = true;
		this.gridColNo.Width = 33;
		this.gridColumn11.Caption = "Name";
		this.gridColumn11.FieldName = "Name";
		this.gridColumn11.MinWidth = 13;
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.OptionsColumn.AllowEdit = false;
		this.gridColumn11.OptionsColumn.ReadOnly = true;
		this.gridColumn11.Visible = true;
		this.gridColumn11.Width = 167;
		this.gridColumn12.Caption = "Stud#";
		this.gridColumn12.FieldName = "Stud#";
		this.gridColumn12.MinWidth = 13;
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn12.OptionsColumn.AllowEdit = false;
		this.gridColumn12.OptionsColumn.ReadOnly = true;
		this.gridColumn12.Visible = true;
		this.gridColumn12.Width = 87;
		this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn13.Caption = "Sex";
		this.gridColumn13.FieldName = "Sex";
		this.gridColumn13.MinWidth = 13;
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn13.OptionsColumn.AllowEdit = false;
		this.gridColumn13.OptionsColumn.ReadOnly = true;
		this.gridColumn13.Visible = true;
		this.gridColumn13.Width = 31;
		this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn14.Caption = "Stream";
		this.gridColumn14.FieldName = "Stream";
		this.gridColumn14.MinWidth = 13;
		this.gridColumn14.Name = "gridColumn14";
		this.gridColumn14.OptionsColumn.AllowEdit = false;
		this.gridColumn14.OptionsColumn.ReadOnly = true;
		this.gridColumn14.Visible = true;
		this.gridColumn14.Width = 61;
		this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridBand2.AppearanceHeader.Options.UseFont = true;
		this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand2.Caption = "Term Marks";
		this.gridBand2.Columns.Add(this.gridColHoP);
		this.gridBand2.Columns.Add(this.gridColBOT);
		this.gridBand2.Columns.Add(this.gridColMOT);
		this.gridBand2.Columns.Add(this.gridColEOT);
		this.gridBand2.MinWidth = 7;
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.OptionsBand.AllowHotTrack = false;
		this.gridBand2.OptionsBand.AllowMove = false;
		this.gridBand2.OptionsBand.AllowPress = false;
		this.gridBand2.VisibleIndex = 1;
		this.gridBand2.Width = 37;
		this.gridColHoP.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColHoP.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColHoP.AppearanceCell.Options.UseBackColor = true;
		this.gridColHoP.AppearanceCell.Options.UseTextOptions = true;
		this.gridColHoP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColHoP.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColHoP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColHoP.Caption = "HoP";
		this.gridColHoP.FieldName = "HoP";
		this.gridColHoP.MinWidth = 13;
		this.gridColHoP.Name = "gridColHoP";
		this.gridColHoP.Width = 33;
		this.gridColBOT.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColBOT.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColBOT.AppearanceCell.Options.UseBackColor = true;
		this.gridColBOT.AppearanceCell.Options.UseTextOptions = true;
		this.gridColBOT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColBOT.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColBOT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColBOT.Caption = "BOT";
		this.gridColBOT.FieldName = "BOT";
		this.gridColBOT.MinWidth = 13;
		this.gridColBOT.Name = "gridColBOT";
		this.gridColBOT.Width = 33;
		this.gridColMOT.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColMOT.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColMOT.AppearanceCell.Options.UseBackColor = true;
		this.gridColMOT.AppearanceCell.Options.UseTextOptions = true;
		this.gridColMOT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColMOT.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColMOT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColMOT.Caption = "MOT";
		this.gridColMOT.FieldName = "MOT";
		this.gridColMOT.MinWidth = 13;
		this.gridColMOT.Name = "gridColMOT";
		this.gridColMOT.Width = 33;
		this.gridColEOT.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColEOT.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(255, 255, 192);
		this.gridColEOT.AppearanceCell.Options.UseBackColor = true;
		this.gridColEOT.AppearanceCell.Options.UseTextOptions = true;
		this.gridColEOT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColEOT.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColEOT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColEOT.Caption = "EOT";
		this.gridColEOT.FieldName = "EOT";
		this.gridColEOT.MinWidth = 13;
		this.gridColEOT.Name = "gridColEOT";
		this.gridColEOT.Width = 33;
		this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridBand3.AppearanceHeader.Options.UseFont = true;
		this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand3.Caption = "Grading";
		this.gridBand3.Columns.Add(this.gridColumn19);
		this.gridBand3.Columns.Add(this.gridColumnGrade);
		this.gridBand3.MinWidth = 7;
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.OptionsBand.AllowHotTrack = false;
		this.gridBand3.OptionsBand.AllowMove = false;
		this.gridBand3.OptionsBand.AllowPress = false;
		this.gridBand3.VisibleIndex = 2;
		this.gridBand3.Width = 82;
		this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
		this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
		this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridColumn19.Caption = "Score";
		this.gridColumn19.FieldName = "Score";
		this.gridColumn19.MinWidth = 13;
		this.gridColumn19.Name = "gridColumn19";
		this.gridColumn19.OptionsColumn.AllowEdit = false;
		this.gridColumn19.OptionsColumn.ReadOnly = true;
		this.gridColumn19.Visible = true;
		this.gridColumn19.Width = 41;
		this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridBand4.AppearanceHeader.Options.UseFont = true;
		this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand4.Caption = "Commentry";
		this.gridBand4.Columns.Add(this.gridColumn21);
		this.gridBand4.MinWidth = 7;
		this.gridBand4.Name = "gridBand4";
		this.gridBand4.OptionsBand.AllowHotTrack = false;
		this.gridBand4.OptionsBand.AllowMove = false;
		this.gridBand4.OptionsBand.AllowPress = false;
		this.gridBand4.VisibleIndex = 3;
		this.gridBand4.Width = 231;
		this.gridColumn21.Caption = "Comment";
		this.gridColumn21.FieldName = "Comment";
		this.gridColumn21.MinWidth = 13;
		this.gridColumn21.Name = "gridColumn21";
		this.gridColumn21.OptionsColumn.ReadOnly = true;
		this.gridColumn21.Visible = true;
		this.gridColumn21.Width = 231;
		this.bandedGridColumn1.Caption = "GradeScore";
		this.bandedGridColumn1.FieldName = "GradeScore";
		this.bandedGridColumn1.MinWidth = 13;
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.Width = 50;
		this.repositoryItemGridLookUpEdit1.AutoHeight = false;
		this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
		this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
		this.repositoryItemGridLookUpEdit1View.DetailHeight = 239;
		this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
		this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
		this.tmUpdate.Enabled = true;
		this.tmUpdate.Tick += new System.EventHandler(tmUpdate_Tick);
		this.barSubItem9.Caption = "Theme";
		this.barSubItem9.Id = 142;
		this.barSubItem9.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems;
		this.barSubItem9.Name = "barSubItem9";
		this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
		this.bgSaveMarks.DoWork += new System.ComponentModel.DoWorkEventHandler(bgSaveMarks_DoWork);
		this.bgSaveMarks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgSaveMarks_RunWorkerCompleted);
		this.printingSystem1.Links.AddRange(new object[1] { this.printableComponentLink1 });
		this.printingSystem1.ShowMarginsWarning = false;
		this.printableComponentLink1.Component = this.dgMain;
		this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 50);
		this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(null, new DevExpress.XtraPrinting.PageFooterArea(new string[3] { "[Page # of Pages #]", "", "Printed on: [Date Printed], [Time Printed]" }, new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0), DevExpress.XtraPrinting.BrickAlignment.Near));
		this.printableComponentLink1.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
		this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
		this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.xtraTabControl1.Location = new System.Drawing.Point(0, 147);
		this.xtraTabControl1.Name = "xtraTabControl1";
		this.xtraTabControl1.SelectedTabPage = this.xtraTabMarksEntry;
		this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
		this.xtraTabControl1.Size = new System.Drawing.Size(907, 366);
		this.xtraTabControl1.TabIndex = 9;
		this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[3] { this.xtraTabMarksEntry, this.xtraTabFileLogo, this.xtraTabPage1 });
		this.xtraTabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(xtraTabControl1_KeyDown);
		this.xtraTabMarksEntry.Controls.Add(this.dgMain);
		this.xtraTabMarksEntry.Name = "xtraTabMarksEntry";
		this.xtraTabMarksEntry.Size = new System.Drawing.Size(905, 364);
		this.xtraTabMarksEntry.Text = "xtraTabPage2";
		this.xtraTabFileLogo.Controls.Add(this.gridControl1);
		this.xtraTabFileLogo.Name = "xtraTabFileLogo";
		this.xtraTabFileLogo.Size = new System.Drawing.Size(905, 367);
		this.xtraTabFileLogo.Text = "xtraTabPage3";
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.Location = new System.Drawing.Point(0, 0);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(905, 367);
		this.gridControl1.TabIndex = 1;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[8] { this.gridColumn8, this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
		this.gridColumn8.Caption = "No";
		this.gridColumn8.MinWidth = 13;
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 0;
		this.gridColumn8.Width = 50;
		this.gridColumn1.Caption = "File";
		this.gridColumn1.FieldName = "fileName";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn1.Width = 200;
		this.gridColumn2.Caption = "Class";
		this.gridColumn2.FieldName = "classId";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 2;
		this.gridColumn2.Width = 40;
		this.gridColumn3.Caption = "Subject";
		this.gridColumn3.FieldName = "subjectId";
		this.gridColumn3.MinWidth = 13;
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 3;
		this.gridColumn3.Width = 89;
		this.gridColumn4.Caption = "Semester";
		this.gridColumn4.FieldName = "semesterId";
		this.gridColumn4.MinWidth = 13;
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 4;
		this.gridColumn4.Width = 111;
		this.gridColumn5.Caption = "Export Date";
		this.gridColumn5.DisplayFormat.FormatString = "{0:dd-MMM-yy}";
		this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn5.FieldName = "dateExported";
		this.gridColumn5.MinWidth = 13;
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 5;
		this.gridColumn5.Width = 150;
		this.gridColumn6.Caption = "ISImported";
		this.gridColumn6.FieldName = "imported";
		this.gridColumn6.MinWidth = 13;
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 6;
		this.gridColumn6.Width = 33;
		this.gridColumn7.Caption = "Import Date";
		this.gridColumn7.DisplayFormat.FormatString = "{0:dd-MMM-yy : HH.MM.ss}";
		this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.gridColumn7.FieldName = "importDate";
		this.gridColumn7.MinWidth = 13;
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 7;
		this.gridColumn7.Width = 163;
		this.xtraTabPage1.Controls.Add(this.popupControlContainer1);
		this.xtraTabPage1.Name = "xtraTabPage1";
		this.xtraTabPage1.Size = new System.Drawing.Size(905, 367);
		this.xtraTabPage1.Text = "xtraTabPage1";
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.popupMenu1.ItemLinks.Add(this.barButtonItem20);
		this.popupMenu1.Name = "popupMenu1";
		this.popupMenu1.Ribbon = this.ribbonControl1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(907, 536);
		base.Controls.Add(this.xtraTabControl1);
		base.Controls.Add(this.ribbonStatusBar1);
		base.Controls.Add(this.ribbonControl1);
		base.IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("MainPrimary.IconOptions.Icon");
		base.KeyPreview = true;
		base.Name = "MainPrimary";
		this.Ribbon = this.ribbonControl1;
		this.StatusBar = this.ribbonStatusBar1;
		this.Text = "School Management Dynamics - Teachers' Workstation";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainWindow_FormClosing);
		base.Load += new System.EventHandler(MainWindow_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(MainWindow_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.popupControlContainer1).EndInit();
		this.popupControlContainer1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControlStudents).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridViewStudents).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedSubject).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedClass).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedStream).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.xtraTabControl1).EndInit();
		this.xtraTabControl1.ResumeLayout(false);
		this.xtraTabMarksEntry.ResumeLayout(false);
		this.xtraTabFileLogo.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		this.xtraTabPage1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
