using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.GradingScales;
using AlienAge.Semesters;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Data;
using DevExpress.Drawing.Printing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraBars.Ribbon.Internal;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using MarksEntry.DialogForms;
using MarksEntry.MarksEntryClasses;
using MarksEntry.Properties;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace MarksEntry.MarksEntryForms;

public class MainOLevelNewCur : RibbonForm
{
	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private string suffix = string.Empty;

	private int i = 0;

	private int UnitsUsed = 0;

	private bool ProjectUsed = false;

	private string NewStudentName = string.Empty;

	private string NewStudentNumber = string.Empty;

	private string _Student = string.Empty;

	private readonly string timeExported = DateTime.Now.ToString("HHMMss");

	private string ScoreLoadMode = string.Empty;

	private string _Class = string.Empty;

	private string _Subject = string.Empty;

	private string _Term = string.Empty;

	private string _TR = string.Empty;

	private SqlTransaction trans;

	private FlyoutDialog dialog;

	private DataTable dt;

	private DataTable dts;

	private int u1f = 0;

	private int u2f = 0;

	private int u3f = 0;

	private int u4f = 0;

	private int u5f = 0;

	private static readonly string connectionString = DataConnection.ConnectToDatabase();

	private usrGenerateChapterNames usrGenerateChapter;

	private DataTable _dt;

	private string SelectedClass = string.Empty;

	public string SelectedClassGroup = string.Empty;

	private string genericSkill = string.Empty;

	private int rowHandle = 0;

	private IContainer components = null;

	private MyGridControl dgMain;

	private System.Windows.Forms.Timer tmUpdate;

	private BarSubItem barSubItem9;

	private DefaultLookAndFeel defaultLookAndFeel1;

	private BackgroundWorker bgSaveMarks;

	private PrintingSystem printingSystem1;

	private PrintableComponentLink printableComponentLink1;

	private System.Windows.Forms.Timer timer1;

	private PopupMenu popupMenu1;

	private PopupMenu popupMenu2;

	private MyBandedGridView bandedGridView1;

	private BandedGridColumn bandedGridColumn1;

	private BandedGridColumn bandedGridColumn2;

	private BandedGridColumn bandedGridColumn3;

	private BandedGridColumn bandedGridColumn4;

	private BandedGridColumn bandedGridColumn5;

	private FlyoutPanel flyoutPanel1;

	private FlyoutPanelControl flyoutPanelControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private BandedGridColumn colU1;

	private BandedGridColumn colU2;

	private BandedGridColumn colU3;

	private BandedGridColumn bandedGridColumn16;

	private BandedGridColumn bandedGridColumn17;

	private BandedGridColumn bandedGridColumn18;

	private NavigationFrame navigationFrame1;

	private NavigationPage navPageLO;

	private NavigationPage navPage20;

	private MyGridControl dgMain20;

	private MyBandedGridView gv20;

	private BandedGridColumn bandedGridColumn6;

	private BandedGridColumn bandedGridColumn7;

	private BandedGridColumn bandedGridColumn8;

	private BandedGridColumn bandedGridColumn9;

	private BandedGridColumn bandedGridColumn10;

	private BandedGridColumn colScore1;

	private BandedGridColumn colScore2;

	private BandedGridColumn colScore3;

	private BandedGridColumn bandedGridColumn24;

	private BandedGridColumn bandedGridColumn26;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;

	private GridView gridView2;

	private NavigationPage navPage100;

	private MyGridControl dgMain100;

	private MyBandedGridView gv100;

	private BandedGridColumn bandedGridColumn27;

	private BandedGridColumn bandedGridColumn28;

	private BandedGridColumn bandedGridColumn29;

	private BandedGridColumn bandedGridColumn30;

	private BandedGridColumn bandedGridColumn31;

	private BandedGridColumn colHund1;

	private BandedGridColumn colHund2;

	private BandedGridColumn colHund3;

	private BandedGridColumn bandedGridColumn42;

	private BandedGridColumn bandedGridColumn44;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit3;

	private GridView gridView3;

	private BandedGridColumn bandedGridColumn11;

	private BandedGridColumn bandedGridColumn12;

	private BandedGridColumn bandedGridColumn13;

	private NavigationPage navPageEOT;

	private MyGridControl gridEOT;

	private MyBandedGridView gvEOT;

	private BandedGridColumn bandedGridColumn14;

	private BandedGridColumn bandedGridColumn15;

	private BandedGridColumn bandedGridColumn19;

	private BandedGridColumn bandedGridColumn20;

	private BandedGridColumn bandedGridColumn21;

	private BandedGridColumn bandedGridColumn41;

	private BandedGridColumn bandedGridColumn43;

	private BandedGridColumn bandedGridColumn23;

	private BandedGridColumn bandedGridColumn22;

	private BandedGridColumn bandedGridColumn40;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit4;

	private GridView gridView4;

	private GridBand gridBand10;

	private GridBand gridBand11;

	private GridBand gridBand12;

	private BandedGridColumn bandedGridColumn25;

	private GridColumn gridColumn3;

	private NavigationPage navPage10;

	private MyGridControl dgMain10;

	private MyBandedGridView gv10;

	private BandedGridColumn bandedGridColumn32;

	private BandedGridColumn bandedGridColumn33;

	private BandedGridColumn bandedGridColumn34;

	private BandedGridColumn bandedGridColumn35;

	private BandedGridColumn bandedGridColumn36;

	private BandedGridColumn colT1;

	private BandedGridColumn colT2;

	private BandedGridColumn colT3;

	private BandedGridColumn bandedGridColumn52;

	private BandedGridColumn bandedGridColumn53;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit5;

	private GridView gridView5;

	private NavigationPage navPageHome;

	private TileControl tileControl2;

	private TileGroup tileGroup4;

	private TileItem tileItemLO;

	private TileItem tileItemR10;

	private TileItem tileItemR20;

	private TileItem tileItemR100;

	private TileItem tileItemREOT;

	private TileGroup tileGroup5;

	private TileGroup tileGroup7;

	private TileItem tileItemRDes;

	private NavigationPage navPageDescr;

	private SplitContainerControl splitContainerControl2;

	private GridControl dgMainDescriptive;

	private GridView gvDescriptive;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumn6;

	private GridColumn gridColumn7;

	private VGridControl vGridControl1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit3;

	private EditorRow rowId;

	private EditorRow row6;

	private RibbonControl ribbonControl1;

	private RibbonPage ribbonPage1;

	private RibbonPageGroup ribbonPageGroup1;

	private BarButtonItem barButtonItem1;

	private BarButtonItem barButtonItem2;

	private BarButtonItem barButtonItem3;

	private BarButtonItem barButtonItem4;

	private BarButtonItem barButtonItem5;

	private BarButtonItem lblStream;

	private BarListItem barListItem1;

	private BarStaticItem tileItemClassSettings;

	private BarStaticItem lblTerm;

	private BarStaticItem lblSubject;

	private RibbonPageGroup ribbonPageGroup5;

	private RibbonPageGroup ribbonPageGroup4;

	private RibbonPageGroup ribbonPageGroup2;

	private RibbonPageGroup ribbonPageGroup3;

	private RibbonStatusBar ribbonStatusBar1;

	private LabelControl lblWelcome;

	private PanelControl panelControl1;

	private SkinDropDownButtonItem skinDropDownButtonItem1;

	private SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;

	private RibbonPageGroup ribbonPageGroup7;

	private SkinDropDownButtonItem skinDropDownButtonItem2;

	private BarStaticItem barStaticItem1;

	private BarStaticItem lblTeacher;

	private BarStaticItem lblIPAddress;

	private BarStaticItem barStaticItem2;

	private RepositoryItemPictureEdit picStudentPicture;

	private RibbonPageGroup ribbonPageGroup8;

	private BarStaticItem lblStudentName;

	private BarStaticItem lblStudentNo;

	private BarStaticItem lblStudentID;

	private BarButtonItem barButtonItem8;

	private TileItem tileItem1;

	private BandedGridColumn bandedGridColumn37;

	private BandedGridColumn bandedGridColumn39;

	private BandedGridColumn bandedGridColumn45;

	private BandedGridColumn bandedGridColumn38;

	private RepositoryItemPictureEdit repositoryItemPictureEdit1;

	private NavigationPage navPageOtherComp;

	private GridControl dgOtherComp;

	private GridView gvOtherComp;

	private GridColumn gridColumn8;

	private GridColumn gridColumn9;

	private GridColumn gridColumn10;

	private GridColumn gridColumn11;

	private VGridControl vGridControl2;

	private EditorRow ProjectTitle;

	private EditorRow Project;

	private SplitContainerControl splitContainerControl1;

	private FlyoutPanel flyoutPanel2;

	private FlyoutPanelControl flyoutPanelControl2;

	private BarButtonItem barButtonItem9;

	private RibbonPageGroup ribbonPageGroup9;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private ComboBoxEdit cboSubject;

	private TextEdit txtPassword;

	private TextEdit txtUserId;

	private LookUpEdit lookupClasses;

	private LabelControl labelControl4;

	private LabelControl labelControl3;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private PictureEdit pictureEdit1;

	private DXValidationProvider dxValidationLogin;

	private BandedGridColumn colProject;

	private EditorRow row;

	private EditorRow row1;

	private EditorRow row3;

	private RepositoryItemMemoEdit repositoryItemMemoEdit4;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit5;

	private BandedGridColumn bandedGridColumn46;

	private BandedGridColumn bandedGridColumn47;

	private BandedGridColumn bandedGridColumn48;

	private BandedGridColumn bandedGridColumn49;

	private FlyoutPanel flyoutPanel3;

	private FlyoutPanelControl flyoutPanelControl3;

	private GridControl gridControl2;

	private GridView gridView6;

	private GridColumn gridColumn12;

	private GridColumn gridColumn13;

	private RepositoryItemRibbonSearchEdit repositoryItemRibbonSearchEdit1;

	private BandedGridColumn bandedGridColumn50;

	private EditorRow row2;

	private EditorRow row4;

	private EditorRow row5;

	private EditorRow row7;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit2;

	private RepositoryItemMemoEdit repositoryItemMemoEdit6;

	private RepositoryItemMemoEdit repositoryItemMemoEdit7;

	private BandedGridColumn colU4;

	private BandedGridColumn colScore4;

	private BandedGridColumn colHund4;

	private BandedGridColumn colT4;

	private BandedGridColumn bandedGridColumn51;

	private TileItem tileItem2;

	private NavigationPage navPageCompetence;

	private VGridControl vGridLoadChapters;

	private RepositoryItemMemoEdit repositoryItemMemoEdit8;

	private RepositoryItemTextEdit repositoryItemTextEdit2;

	private EditorRow rowTopic1;

	private EditorRow rowTopic2;

	private EditorRow rowCompetence2;

	private EditorRow rowTopic3;

	private EditorRow rowCompetence3;

	private EditorRow rowTopic4;

	private EditorRow rowCompetence4;

	private RepositoryItemTextEdit repositoryItemTextEdit3;

	private RepositoryItemTextEdit repositoryItemTextEdit4;

	private RepositoryItemTextEdit repositoryItemTextEdit5;

	private RepositoryItemMemoEdit repositoryItemMemoEdit9;

	private RepositoryItemMemoEdit repositoryItemMemoEdit10;

	private RepositoryItemMemoEdit repositoryItemMemoEdit11;

	private GridBand gridBand1;

	private GridBand gridBand2;

	private BandedGridColumn colU5;

	private GridBand gridBand3;

	private GridBand gridBand16;

	private GridBand gridBand13;

	private GridBand gridBand14;

	private BandedGridColumn colT5;

	private GridBand gridBandProject;

	private GridBand gridBand15;

	private GridBand gridBand17;

	private GridBand gridBand4;

	private GridBand gridBand5;

	private BandedGridColumn colScore5;

	private GridBand gridBand6;

	private GridBand gridBand18;

	private GridBand gridBand7;

	private GridBand gridBand8;

	private BandedGridColumn colHund5;

	private GridBand gridBand9;

	private GridBand gridBand19;

	private DataTable dtEOY { get; set; }

	private bool ProjectAvailable
	{
		get
		{
			bool result = false;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM  tbl_TermSettingsNC WHERE ClassId='{_Class}' AND SemesterId='{_Term}' AND SubjectId='{_Subject}'", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				result = bool.TryParse(dataTable.Rows[0]["ProjectAvailable"].ToString(), out result) && result;
			}
			return result;
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

	private void LoadUnRegisteredStudents()
	{
		WaitDialogForm waitDialogForm = new WaitDialogForm();
		try
		{
			waitDialogForm.Caption = "Generating list...";
			waitDialogForm.Show();
			string selectCommandText = $"SELECT fullName,StudentNumber,StreamId FROM tbl_Stud WHERE ClassId='{tileItemClassSettings.Caption}' ORDER BY fullName ASC";
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString))
			{
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SubjectsList");
				dts = new DataTable();
				dts = dataSet.Tables[0];
				gridControl1.DataSource = dts.DefaultView;
			}
			waitDialogForm.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			waitDialogForm.Close();
		}
	}

	public MainOLevelNewCur(string _Class, string _Subject, string _Term, string _TR)
	{
		InitializeComponent();
		gridControl2.DataSource = GenericSkillsAutomator.GenericSkillsSource;
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
		this._Class = _Class;
		this._Subject = _Subject;
		this._Term = _Term;
		this._TR = _TR;
		dtEOY = gradingScale.EndOfYearScale;
		RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Alien Age\\School Management Dynamics\\Skins");
		try
		{
			defaultLookAndFeel1.LookAndFeel.SkinName = registryKey.GetValue("Teacher Gateway").ToString();
		}
		catch
		{
			defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
		}
		tileItemClassSettings.Caption = _Class;
		lblSubject.Caption = _Subject;
		lblTerm.Caption = _Term;
		lblStream.Caption = "Stream";
		lblTeacher.Caption = _TR;
		lblIPAddress.Caption = GetIp();
		UnitsUsed = TotalUnits();
		ProjectUsed = ProjectAvailable;
	}

	private void LoadChapters()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT TOP (1) Topic_1,Topic_2,Topic_3,Topic_4,Competence_1,Competence_2,Competence_3,Competence_4,SubjectId FROM  tbl_Scores_OL_Report WHERE SubjectId='{_Subject}' AND ClassId='{_Class}' AND SemesterId='{_Term}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		vGridLoadChapters.DataSource = dataTable.DefaultView;
	}

	private KeyValuePair<string, string> EOYYearGrade(double AvgScore)
	{
		KeyValuePair<string, string> result = new KeyValuePair<string, string>("", "");
		DataRow[] array = dtEOY.Select(string.Format("E100>={0} AND D100<={0}", AvgScore));
		try
		{
			result = new KeyValuePair<string, string>(array[0]["Grade"].ToString(), array[0]["Descriptor"].ToString());
			return result;
		}
		catch (Exception)
		{
		}
		return result;
	}

	private int TotalUnits()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ClassId, SemesterId, SubjectId, TUnits FROM tbl_TermSettingsNC  WHERE (SubjectId = '{_Subject}') AND (SemesterId = '{_Term}') AND (ClassId = '{_Class}')", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count == 0)
		{
			return 1;
		}
		int result;
		return (!int.TryParse(dataTable.Rows[0]["TUnits"].ToString(), out result)) ? 1 : result;
	}

	private void DropSubjectsWholeClass()
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to do this? Note that you cannot undo this action\nPlease Re-Process the reports for the selected Study Level, Semester and Class after this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
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
							CommandText = $"DELETE FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND SubjectId='{_Subject}' AND ClassId='{_Class}'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection,
							Transaction = trans,
							CommandText = $"DELETE FROM OLevelReportNC WHERE SubjectId='{_Subject}' AND SemesterId='{_Term}' AND ClassId='{_Class}'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand2.ExecuteNonQuery();
						}
						trans.Commit();
						sqlConnection.Close();
					}
					using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_OL_Report WHERE SemesterId='{lblTerm.Caption}' AND ClassId='{tileItemClassSettings.Caption}'", DataConnection.ConnectToDatabase());
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "StudentChecker");
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							sqlConnection2.Open();
							using (SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection2,
								CommandText = $"DELETE FROM tbl_GeneralReport_OL WHERE SemesterId='{lblTerm.Caption}' AND ClassId='{tileItemClassSettings.Caption}'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand3.ExecuteNonQuery();
							}
							sqlConnection2.Close();
							return;
						}
					}
					return;
				}
				catch (Exception ex)
				{
					XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			dialogResult = DialogResult.Cancel;
		}
		catch (Exception ex2)
		{
			XtraMessageBox.Show(ex2.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DropSubjectsSingle()
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to do this? Note that you cannot undo this action\nPlease Re-Process the reports for the selected Study Level, Semester and Class after this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			DataRow dataRow = null;
			if (navigationFrame1.SelectedPageIndex == 1)
			{
				dataRow = dt.Rows[bandedGridView1.GetFocusedDataSourceRowIndex()];
			}
			else if (navigationFrame1.SelectedPageIndex == 2)
			{
				dataRow = dt.Rows[gv10.GetFocusedDataSourceRowIndex()];
			}
			else if (navigationFrame1.SelectedPageIndex == 3)
			{
				dataRow = dt.Rows[gv20.GetFocusedDataSourceRowIndex()];
			}
			else if (navigationFrame1.SelectedPageIndex == 4)
			{
				dataRow = dt.Rows[gv100.GetFocusedDataSourceRowIndex()];
			}
			else if (navigationFrame1.SelectedPageIndex == 5)
			{
				dataRow = dt.Rows[gvEOT.GetFocusedDataSourceRowIndex()];
			}
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.Connection = sqlConnection;
				sqlCommand.Transaction = trans;
				sqlCommand.CommandText = string.Format("DELETE FROM tbl_Scores_OL_Report WHERE SubjectId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}' AND ClassId='{3}'", lblSubject.Caption, dataRow["StudentNumber"], lblTerm.Caption, tileItemClassSettings.Caption);
				sqlCommand.CommandType = CommandType.Text;
				using (SqlCommand sqlCommand2 = sqlCommand)
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlCommand = new SqlCommand();
				sqlCommand.Connection = sqlConnection;
				sqlCommand.Transaction = trans;
				sqlCommand.CommandText = string.Format("DELETE FROM OLevelReportNC WHERE SubjectId='{0}' AND StudentNo='{1}' AND SemesterId='{2}' AND ClassId='{3}'", lblSubject.Caption, dataRow["StudentNumber"], lblTerm.Caption, tileItemClassSettings.Caption);
				sqlCommand.CommandType = CommandType.Text;
				using (SqlCommand sqlCommand3 = sqlCommand)
				{
					sqlCommand3.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
			}
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT * FROM tbl_Scores_OL_Report WHERE StudentNumber='{0}' AND SemesterId='{1}' AND ClassId='{2}'", dataRow["StudentNumber"], lblTerm.Caption, tileItemClassSettings.Caption), DataConnection.ConnectToDatabase());
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
				CommandText = string.Format("DELETE FROM tbl_GeneralReport_OL WHERE StudentNumber='{0}' AND SemesterId='{1}' AND ClassId='{2}'", dataRow["StudentNumber"], lblTerm.Caption, tileItemClassSettings.Caption),
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection2.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadOLevelMarks(int pageIndex)
	{
		try
		{
			if (pageIndex > 0 && pageIndex < 6)
			{
				string selectCommandText = $"SELECT s.StudentNumber, s.fullName, s.StreamId, s.Sex,s.StudentID, c.SemesterId, c.SubjectId, c.ClassId, c.U1, c.U2, c.U3, c.U4,c.AvLO, c.Score1, c.Score2, c.Score3, c.Score4, c.T1, c.T2, c.T3, c.T4,c.P1,c.OutOfTen,c.Hund1, c.Hund2, c.Hund3, c.Hund4, c.TTLPoints, c.OutOfTwenty, c.OutOfHund, c.Initial,c.TUnits,c.ETA,c.ETA80,c.ETAv,c.Comment,c.AvMark,c.Grade,c.Category,c.GenericSkills FROM   tbl_Stud s INNER JOIN tbl_Scores_OL_Report c ON s.StudentNumber = c.StudentNumber WHERE (c.SemesterId = '{_Term}') AND (c.SubjectId = '{_Subject}') AND (c.ClassId = '{_Class}') Order By s.fullName";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString);
				dt = new DataTable();
				sqlDataAdapter.Fill(dt);
				bandedGridColumn5.Visible = true;
				if (dt.Rows.Count > 0)
				{
					barButtonItem4.Enabled = true;
					switch (pageIndex)
					{
					case 1:
						dgMain.DataSource = dt.DefaultView;
						break;
					case 2:
						dgMain10.DataSource = dt.DefaultView;
						break;
					case 3:
						dgMain20.DataSource = dt.DefaultView;
						break;
					case 4:
						dgMain100.DataSource = dt.DefaultView;
						break;
					case 5:
						gridEOT.DataSource = dt.DefaultView;
						break;
					}
				}
				else
				{
					dgMain.DataSource = null;
					dgMain10.DataSource = null;
					dgMain20.DataSource = null;
					dgMain100.DataSource = null;
					gridEOT.DataSource = null;
					barButtonItem4.Enabled = false;
				}
			}
			else if (pageIndex >= 6)
			{
				LoadStudentsList();
			}
			UnitsUsed = TotalUnits();
			gridBandProject.Visible = ProjectAvailable;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadOLevelMarks(string _stream, int pageIndex)
	{
		try
		{
			if (pageIndex > 0 && pageIndex < 6)
			{
				string selectCommandText = $"SELECT s.StudentNumber, s.fullName, s.StreamId, s.Sex,s.StudentID, c.SemesterId, c.SubjectId, c.ClassId, c.U1, c.U2, c.U3, c.U4,c.AvLO, c.Score1, c.Score2, c.Score3, c.Score4,c.T1, c.T2, c.T3, c.T4,c.P1,c.OutOfTen,c.Hund1, c.Hund2, c.Hund3, c.Hund4, c.TTLPoints, c.OutOfTwenty, c.OutOfHund, c.Initial,c.TUnits,c.ETA,c.ETA80,c.ETAv,c.Comment,c.AvMark,c.Grade,c.Category,c.GenericSkills FROM   tbl_Stud s INNER JOIN tbl_Scores_OL_Report c ON s.StudentNumber = c.StudentNumber WHERE (c.SemesterId = '{_Term}') AND (c.SubjectId = '{_Subject}') AND (c.ClassId = '{_Class}') AND s.StreamId='{_stream}' Order By s.fullName ASC";
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString);
				dt = new DataTable();
				sqlDataAdapter.Fill(dt);
				bandedGridColumn5.Visible = true;
				if (dt.Rows.Count > 0)
				{
					barButtonItem4.Enabled = true;
					switch (pageIndex)
					{
					case 1:
						dgMain.DataSource = dt.DefaultView;
						break;
					case 2:
						dgMain10.DataSource = dt.DefaultView;
						break;
					case 3:
						dgMain20.DataSource = dt.DefaultView;
						break;
					case 4:
						dgMain100.DataSource = dt.DefaultView;
						break;
					case 5:
						gridEOT.DataSource = dt.DefaultView;
						break;
					}
				}
				else
				{
					dgMain.DataSource = null;
					dgMain10.DataSource = null;
					dgMain20.DataSource = null;
					dgMain100.DataSource = null;
					gridEOT.DataSource = null;
					barButtonItem4.Enabled = false;
				}
			}
			else if (pageIndex >= 6)
			{
				LoadStudentsList(_stream);
			}
			UnitsUsed = TotalUnits();
			gridBandProject.Visible = ProjectAvailable;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

	private void MainWindow_Load(object sender, EventArgs e)
	{
		SkinHelper.InitSkinPopupMenu(popupMenu2);
		if (UnitsUsed == 0)
		{
			u1f = 0;
			u2f = 0;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			colU1.Visible = false;
			colU2.Visible = false;
			colU3.Visible = false;
			colU4.Visible = false;
			colU5.Visible = false;
			colT1.Visible = false;
			colT2.Visible = false;
			colT3.Visible = false;
			colT4.Visible = false;
			colT5.Visible = false;
			colScore1.Visible = false;
			colScore2.Visible = false;
			colScore3.Visible = false;
			colScore4.Visible = false;
			colScore5.Visible = false;
			colHund1.Visible = false;
			colHund2.Visible = false;
			colHund3.Visible = false;
			colHund4.Visible = false;
			colHund5.Visible = false;
		}
		else if (UnitsUsed == 1)
		{
			u1f = 1;
			u2f = 0;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			colU2.Visible = false;
			colU3.Visible = false;
			colU4.Visible = false;
			colU5.Visible = false;
			colT2.Visible = false;
			colT3.Visible = false;
			colT4.Visible = false;
			colT5.Visible = false;
			colScore2.Visible = false;
			colScore3.Visible = false;
			colScore4.Visible = false;
			colScore5.Visible = false;
			colHund2.Visible = false;
			colHund3.Visible = false;
			colHund4.Visible = false;
			colHund5.Visible = false;
		}
		else if (UnitsUsed == 2)
		{
			u1f = 1;
			u2f = 1;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			colU3.Visible = false;
			colU4.Visible = false;
			colU5.Visible = false;
			colT3.Visible = false;
			colT4.Visible = false;
			colT5.Visible = false;
			colScore3.Visible = false;
			colScore4.Visible = false;
			colScore5.Visible = false;
			colHund3.Visible = false;
			colHund4.Visible = false;
			colHund5.Visible = false;
		}
		else if (UnitsUsed == 3)
		{
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 0;
			u5f = 0;
			colU4.Visible = false;
			colU5.Visible = false;
			colT4.Visible = false;
			colT5.Visible = false;
			colScore4.Visible = false;
			colScore5.Visible = false;
			colHund4.Visible = false;
			colHund5.Visible = false;
		}
		else if (UnitsUsed == 4)
		{
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 0;
			colU5.Visible = false;
			colT5.Visible = false;
			colScore5.Visible = false;
			colHund5.Visible = false;
		}
		else if (UnitsUsed == 5)
		{
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
		}
		tmUpdate.Enabled = true;
	}

	private void bandedGridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (bandedGridView1.FocusedRowHandle > -1 && (bandedGridView1.FocusedColumn == bandedGridView1.Columns["U1"] || bandedGridView1.FocusedColumn == bandedGridView1.Columns["U2"] || bandedGridView1.FocusedColumn == bandedGridView1.Columns["U3"] || bandedGridView1.FocusedColumn == bandedGridView1.Columns["U4"]))
		{
			double result;
			if (e.Value.ToString() == "-")
			{
				e.Valid = true;
			}
			else if (!double.TryParse(e.Value.ToString(), out result) || result > 3.0 || result < 0.9)
			{
				e.Valid = false;
			}
			else if (!double.TryParse(e.Value.ToString(), out result))
			{
				e.Valid = true;
			}
		}
	}

	private void bandedGridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 0.9 to 3.0 only.";
		bandedGridView1.HideEditor();
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

	private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
	{
		ExportReportToExcel(dgMain, $"{lblSubject.Caption}!{tileItemClassSettings.Caption}${lblTerm.Caption}");
	}

	private string ReportHeader(string report_header)
	{
		if (report_header == string.Empty)
		{
			string text = $"{tileItemClassSettings.Caption} {lblStream.Caption}";
			string caption = lblSubject.Caption;
			return printableComponentLink1.RtfReportHeader = string.Format("{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\ql\\f0\\fs22 {0}\\par\r\n{1}\\par\r\n{2}\\par\r\n{3}\\par\r\n\\par\r\n{4}\\par\r\n}}\r\n", "Mark Sheet", text, caption, _TR, report_header);
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
				if (XtraMessageBox.Show("Finished Exporting.\nDo you want to open the file?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
			sqlParameter.Value = tileItemClassSettings.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@subjectId", SqlDbType.VarChar, 50);
			sqlParameter.Value = lblSubject.Caption;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@semesterId", SqlDbType.VarChar, 50);
			sqlParameter.Value = lblTerm.Caption;
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
		if (text2.ToLower() == tileItemClassSettings.Caption && text3.ToLower() == lblSubject.Caption.ToLower().Replace('/', '#') && text4 == lblTerm.Caption)
		{
			waitDialogForm.Caption = $"Importing {tileItemClassSettings.Caption} scores";
			ImportScoresFromExcel.GetScoresFromExcel(tileItemClassSettings.Caption, lblTerm.Caption, lblSubject.Caption);
			LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
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

	private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
	{
		ImportScores();
	}

	private void xtraTabControl1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
		{
			e.Handled = true;
		}
	}

	private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
	{
		DropSubjectsSingle();
		LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
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

	private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
	{
		DialogResult dialogResult = XtraMessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult == DialogResult.Yes)
		{
			if (bandedGridView1.RowCount > 0)
			{
				bandedGridView1.HideEditor();
				e.Cancel = false;
			}
		}
		else
		{
			e.Cancel = true;
		}
	}

	public static string LastName(string text)
	{
		string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length >= 2)
		{
			return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(array[1].ToLower());
		}
		return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
	}

	private void MarksCalculator(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		_Student = bandedGridView1.GetRowCellValue(e.RowHandle, "StudentNumber").ToString();
		string text = bandedGridView1.GetRowCellValue(e.RowHandle, "fullName").ToString();
		string text2 = bandedGridView1.GetRowCellValue(e.RowHandle, "Sex").ToString();
		if (e.Column.FieldName == "U1" || e.Column.FieldName == "U2" || e.Column.FieldName == "U3" || e.Column.FieldName == "U4" || e.Column.FieldName == "U5")
		{
			int num = e.RowHandle;
			double result = (double.TryParse(bandedGridView1.GetRowCellValue(num, "U1").ToString(), out result) ? result : 0.0);
			double result2 = (double.TryParse(bandedGridView1.GetRowCellValue(num, "U2").ToString(), out result2) ? result2 : 0.0);
			double result3 = (double.TryParse(bandedGridView1.GetRowCellValue(num, "U3").ToString(), out result3) ? result3 : 0.0);
			double result4 = (double.TryParse(bandedGridView1.GetRowCellValue(num, "U4").ToString(), out result4) ? result4 : 0.0);
			double result5 = (double.TryParse(bandedGridView1.GetRowCellValue(num, "U5").ToString(), out result5) ? result5 : 0.0);
			double result6 = (double.TryParse(bandedGridView1.GetRowCellValue(num, "ETA80").ToString(), out result6) ? result6 : 0.0);
			double result7 = (double.TryParse(e.Value.ToString(), out result7) ? result7 : 0.0);
			double num2 = Math.Round(result7 / 3.0 * 100.0, 0, MidpointRounding.AwayFromZero);
			double num3 = Math.Round(result7 / 3.0 * 20.0, 0, MidpointRounding.AwayFromZero);
			double num4 = Math.Round(result7 / 3.0 * 10.0, 0, MidpointRounding.AwayFromZero);
			double num5 = result + result2 + result3 + result4 + result5;
			double num6 = Convert.ToDouble((num5 / (double)UnitsUsed).ToString().PadRight(5).Substring(0, 3));
			double value = num6 / 3.0 * 10.0;
			double value2 = num6 / 3.0 * 20.0;
			double value3 = num6 / 3.0 * 100.0;
			double num7 = Math.Round(value2, 1, MidpointRounding.AwayFromZero);
			double num8 = Math.Round(value, 1, MidpointRounding.AwayFromZero);
			double num9 = Math.Round(value3, 1, MidpointRounding.AwayFromZero);
			double num10 = num7 + result6;
			string key = EOYYearGrade(num10).Key;
			string key2 = EOYYearGrade(num2).Key;
			double num11 = Math.Round(num2 / 100.0 * 3.0, 1);
			double num12 = Math.Round(num10 / 100.0 * 3.0, 1);
			string value4 = gradingScale.GetGradingScale(result7).Value;
			string value5 = gradingScale.GetGradingScale(num6).Value;
			string key3 = gradingScale.GetGradingScale(num12).Key;
			string value6 = gradingScale.GetGradingScale(num12).Value;
			string automaticSubjectComment = gradingScale.GetAutomaticSubjectComment((float)num12, useSmallScale: false);
			string automaticSubjectComment2 = gradingScale.GetAutomaticSubjectComment((float)num11);
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			string fieldName = e.Column.FieldName;
			string arg = fieldName.PadRight(3).Substring(1, 2).Trim();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET Descriptor_{0}=@Descriptor_{0}, TeacherRemarks=@TeacherRemarks,TeacherRemarksAIOnly=@TeacherRemarksAIOnly, U{0}=@U{0},Score{0}=@Score{0},Hund{0}=@Hund{0},T{0}=@T{0},AvLo=@AvLo,TTLPoints=@TTLPoints,OutOfTwenty=@OutOfTwenty,OutOfHund=@OutOfHund,OutOfTen=@OutOfTen,Initial=@Initial,Comment=@Comment,CategoryAIOnly=@CategoryAIOnly,Category=@Category,ETAv=@ETAv,Descriptor100=@Descriptor100,Score100=@Score100,AvMark=@AvMark,IsEdited=1 WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter;
			if (e.Value.ToString() == "-")
			{
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", "-");
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", "-");
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", "-");
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", "-");
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", "-");
				sqlParameter.Direction = ParameterDirection.Input;
			}
			else
			{
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", value4);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", e.Value.ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", num3);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", num4);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", num2);
				sqlParameter.Direction = ParameterDirection.Input;
			}
			sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num9);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num7);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num8);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num7);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num5);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Initial", TeacherInitials.GetTeacherInitials());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num6);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num10);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarks", automaticSubjectComment);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarksAIOnly", automaticSubjectComment2);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value5);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value6);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num12);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@CategoryAIOnly", key2);
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				bandedGridView1.SetRowCellValue(e.RowHandle, "AvLO", num6);
			}
			sqlConnection.Close();
			return;
		}
		if (e.Column.FieldName == "GenericSkills")
		{
			string newValue = LastName(text);
			string newValue2 = "his";
			if (text2 == "F")
			{
				newValue2 = "her";
			}
			string value7 = e.Value.ToString().Replace("#", newValue).Replace("$", newValue2);
			SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "UPDATE tbl_Scores_OL_Report SET GenericSkills=@GenericSkills WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@GenericSkills", value7);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@StudentNumber", _Student);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SubjectId", _Subject);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SemesterId", _Term);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@ClassId", _Class);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
			sqlConnection2.Close();
		}
	}

	private void MarksCalculator10(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (!(e.Column.FieldName == "T1") && !(e.Column.FieldName == "T2") && !(e.Column.FieldName == "T3") && !(e.Column.FieldName == "T4") && !(e.Column.FieldName == "T5") && !(e.Column.FieldName == "P1"))
		{
			return;
		}
		_Student = gv10.GetRowCellValue(e.RowHandle, "StudentNumber").ToString();
		int num = e.RowHandle;
		double result = (double.TryParse(gv10.GetRowCellValue(num, "T1").ToString(), out result) ? result : 0.0) * (double)u1f;
		double result2 = (double.TryParse(gv10.GetRowCellValue(num, "T2").ToString(), out result2) ? result2 : 0.0) * (double)u2f;
		double result3 = (double.TryParse(gv10.GetRowCellValue(num, "T3").ToString(), out result3) ? result3 : 0.0) * (double)u3f;
		double result4 = (double.TryParse(gv10.GetRowCellValue(num, "T4").ToString(), out result4) ? result4 : 0.0) * (double)u4f;
		double result5 = (double.TryParse(gv10.GetRowCellValue(num, "T5").ToString(), out result5) ? result5 : 0.0) * (double)u5f;
		double result6 = (double.TryParse(gv10.GetRowCellValue(num, "P1").ToString(), out result6) ? result6 : 0.0);
		double result7 = (double.TryParse(gv10.GetRowCellValue(num, "ETA80").ToString(), out result7) ? result7 : 0.0);
		double num2 = result + result2 + result3 + result4 + result5;
		double value = result / 10.0 * 3.0;
		double num3 = Math.Round(value, 1);
		double value2 = result2 / 10.0 * 3.0;
		double num4 = Math.Round(value2, 1);
		double value3 = result3 / 10.0 * 3.0;
		double num5 = Math.Round(value3, 1);
		double value4 = result4 / 10.0 * 3.0;
		double num6 = Math.Round(value4, 1);
		double value5 = result5 / 10.0 * 3.0;
		double num7 = Math.Round(value5, 1);
		double num8 = num3 + num4 + num5 + num6 + num7;
		double num9 = Math.Round(num8 / (double)UnitsUsed, 1);
		double num10 = num2 / (double)UnitsUsed;
		double num11 = Math.Round(num10, 1, MidpointRounding.AwayFromZero);
		double value6 = num10 / 10.0 * 20.0;
		double num12 = Math.Round(value6, 1, MidpointRounding.AwayFromZero);
		double value7 = num10 / 10.0 * 100.0;
		double num13 = Math.Round(value7, 1, MidpointRounding.AwayFromZero);
		double result8 = (double.TryParse(e.Value.ToString(), out result8) ? result8 : 0.0);
		double value8 = Math.Round(result8 / 10.0 * 20.0, 0, MidpointRounding.AwayFromZero);
		double num14 = Math.Round(result8 / 10.0 * 100.0, 0, MidpointRounding.AwayFromZero);
		double value9 = result8 / 10.0 * 3.0;
		value9 = Math.Round(value9, 1);
		double num15 = num12 + result7;
		string key = EOYYearGrade(num15).Key;
		string key2 = EOYYearGrade(num14).Key;
		string arg = e.Column.FieldName.ToString().PadRight(3).Substring(1, 2)
			.Trim();
		double num16 = Math.Round(num15 / 100.0 * 3.0, 1);
		double num17 = Math.Round(num14 / 100.0 * 3.0, 1);
		string key3 = gradingScale.GetGradingScale(num9).Key;
		string value10 = gradingScale.GetGradingScale(num9).Value;
		string key4 = gradingScale.GetGradingScale(num16).Key;
		string value11 = gradingScale.GetGradingScale(num16).Value;
		string automaticSubjectComment = gradingScale.GetAutomaticSubjectComment((float)num16, useSmallScale: false);
		string automaticSubjectComment2 = gradingScale.GetAutomaticSubjectComment((float)num17);
		string value12 = gradingScale.GetGradingScale(value9).Value;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET Descriptor_{0}=@Descriptor_{0},TeacherRemarks=@TeacherRemarks,TeacherRemarksAIOnly=@TeacherRemarksAIOnly, T{0}=@T{0},Hund{0}=@Hund{0},U{0}=@U{0},Score{0}=@Score{0},OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen,AvMark=@AvMark,Initial=@Initial,TTLPoints=@TTLPoints,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,Score100=@Score100,P1=@P1,P2=@P2,P4=@P4,Category=@Category,CategoryAIOnly=@CategoryAIOnly,IsEdited=1 WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@P1", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@P2", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@P4", "-");
			sqlParameter.Direction = ParameterDirection.Input;
		}
		else
		{
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", value12);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", result8);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", value9);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", Math.Round(value8, 0, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", Math.Round(num14, 0, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			if (ProjectUsed)
			{
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P1", result6);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P2", num11 + result6);
				sqlParameter.Direction = ParameterDirection.Input;
				double scoreOutOf = Math.Round((num11 + result6) / 20.0 * 3.0, 1);
				string key5 = gradingScale.GetGradingScale(scoreOutOf).Key;
				string value13 = gradingScale.GetGradingScale(scoreOutOf).Value;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P4", value13);
				sqlParameter.Direction = ParameterDirection.Input;
			}
			else
			{
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P1", DBNull.Value);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P2", num12);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P4", value11);
				sqlParameter.Direction = ParameterDirection.Input;
			}
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num13);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Initial", TeacherInitials.GetTeacherInitials());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num8);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num12 + result7);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num9);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarks", automaticSubjectComment);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarksAIOnly", automaticSubjectComment2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num16);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@CategoryAIOnly", key2);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gv10.SetRowCellValue(e.RowHandle, "OutOfTen", num11);
		}
		sqlConnection.Close();
	}

	private void MarksCalculator20(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (!(e.Column.FieldName == "Score1") && !(e.Column.FieldName == "Score2") && !(e.Column.FieldName == "Score3") && !(e.Column.FieldName == "Score4"))
		{
			return;
		}
		_Student = gv20.GetRowCellValue(e.RowHandle, "StudentNumber").ToString();
		int num = e.RowHandle;
		double result = (double.TryParse(gv20.GetRowCellValue(num, "Score1").ToString(), out result) ? result : 0.0) * (double)u1f;
		double result2 = (double.TryParse(gv20.GetRowCellValue(num, "Score2").ToString(), out result2) ? result2 : 0.0) * (double)u2f;
		double result3 = (double.TryParse(gv20.GetRowCellValue(num, "Score3").ToString(), out result3) ? result3 : 0.0) * (double)u3f;
		double result4 = (double.TryParse(gv20.GetRowCellValue(num, "Score4").ToString(), out result4) ? result4 : 0.0) * (double)u4f;
		double result5 = (double.TryParse(gv20.GetRowCellValue(num, "ETA80").ToString(), out result5) ? result5 : 0.0);
		double num2 = result + result2 + result3 + result4;
		double value = result / 20.0 * 3.0;
		double num3 = Math.Round(value, 1);
		double value2 = result2 / 20.0 * 3.0;
		double num4 = Math.Round(value2, 1);
		double value3 = result3 / 20.0 * 3.0;
		double num5 = Math.Round(value3, 1);
		double value4 = result4 / 20.0 * 3.0;
		double num6 = Math.Round(value4, 1);
		double num7 = num3 + num4 + num5 + num6;
		double num8 = Math.Round(num7 / (double)UnitsUsed, 1);
		double num9 = num2 / (double)UnitsUsed;
		double num10 = Math.Round(num9, 1, MidpointRounding.AwayFromZero);
		double value5 = num9 / 20.0 * 10.0;
		double num11 = Math.Round(value5, 1, MidpointRounding.AwayFromZero);
		double value6 = num9 / 20.0 * 100.0;
		double num12 = Math.Round(value6, 1, MidpointRounding.AwayFromZero);
		double result6 = (double.TryParse(e.Value.ToString(), out result6) ? result6 : 0.0);
		double num13 = Math.Round(result6 / 20.0 * 10.0, 1, MidpointRounding.AwayFromZero);
		double num14 = Math.Round(result6 / 20.0 * 100.0, 0, MidpointRounding.AwayFromZero);
		double value7 = result6 / 20.0 * 3.0;
		value7 = Math.Round(value7, 1);
		double num15 = num10 + result5;
		string key = EOYYearGrade(num15).Key;
		string key2 = EOYYearGrade(num14).Key;
		double num16 = Math.Round(num15 / 100.0 * 3.0, 1);
		double num17 = Math.Round(num14 / 100.0 * 3.0, 1);
		string value8 = gradingScale.GetGradingScale(num8).Value;
		string value9 = gradingScale.GetGradingScale(num16).Value;
		string automaticSubjectComment = gradingScale.GetAutomaticSubjectComment((float)num16, useSmallScale: false);
		string automaticSubjectComment2 = gradingScale.GetAutomaticSubjectComment((float)num17);
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Column.FieldName;
		string arg = fieldName.PadRight(7).Substring(5, 2).Trim();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET Descriptor_{0}=@Descriptor_{0},TeacherRemarks=@TeacherRemarks,TeacherRemarksAIOnly=@TeacherRemarksAIOnly, Score{0}=@Score{0},Hund{0}=@Hund{0},U{0}=@U{0},T{0}=@T{0},OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen,AvMark=@AvMark,Initial=@Initial,TTLPoints=@TTLPoints,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,Score100=@Score100,Category=@Category,CategoryAIOnly=@CategoryAIOnly,IsEdited=1 WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
		}
		else
		{
			string value10 = gradingScale.GetGradingScale(value7).Value;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", value10);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", result6);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", num14);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", value7);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", num13);
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Initial", TeacherInitials.GetTeacherInitials());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num7);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num15);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num8);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarks", automaticSubjectComment);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarksAIOnly", automaticSubjectComment2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value8);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value9);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num16);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@CategoryAIOnly", key2);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gv20.SetRowCellValue(e.RowHandle, "OutOfTwenty", num10);
		}
		sqlConnection.Close();
	}

	private void MarksCalculator100(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (!(e.Column.FieldName == "Hund1") && !(e.Column.FieldName == "Hund2") && !(e.Column.FieldName == "Hund3") && !(e.Column.FieldName == "Hund4") && !(e.Column.FieldName == "Hund5"))
		{
			return;
		}
		_Student = gv100.GetRowCellValue(e.RowHandle, "StudentNumber").ToString();
		int num = e.RowHandle;
		double result = (double.TryParse(gv100.GetRowCellValue(num, "Hund1").ToString(), out result) ? result : 0.0) * (double)u1f;
		double result2 = (double.TryParse(gv100.GetRowCellValue(num, "Hund2").ToString(), out result2) ? result2 : 0.0) * (double)u2f;
		double result3 = (double.TryParse(gv100.GetRowCellValue(num, "Hund3").ToString(), out result3) ? result3 : 0.0) * (double)u3f;
		double result4 = (double.TryParse(gv100.GetRowCellValue(num, "Hund4").ToString(), out result4) ? result4 : 0.0) * (double)u4f;
		double result5 = (double.TryParse(gv100.GetRowCellValue(num, "Hund5").ToString(), out result5) ? result5 : 0.0) * (double)u5f;
		double result6 = (double.TryParse(gv100.GetRowCellValue(num, "ETA80").ToString(), out result6) ? result6 : 0.0);
		double num2 = result + result2 + result3 + result4 + result5;
		double value = result / 100.0 * 3.0;
		double num3 = Math.Round(value, 1);
		double value2 = result2 / 100.0 * 3.0;
		double num4 = Math.Round(value2, 1);
		double value3 = result3 / 100.0 * 3.0;
		double num5 = Math.Round(value3, 1);
		double value4 = result4 / 100.0 * 3.0;
		double num6 = Math.Round(value4, 1);
		double value5 = result5 / 100.0 * 3.0;
		double num7 = Math.Round(value5, 1);
		double num8 = num3 + num4 + num5 + num6 + num7;
		double num9 = Math.Round(num8 / (double)UnitsUsed, 1);
		double num10 = num2 / (double)UnitsUsed;
		double num11 = Math.Round(num10, 1, MidpointRounding.AwayFromZero);
		double value6 = num10 / 100.0 * 20.0;
		double num12 = Math.Round(value6, 1, MidpointRounding.AwayFromZero);
		double value7 = num10 / 100.0 * 10.0;
		double num13 = Math.Round(value7, 1, MidpointRounding.AwayFromZero);
		double result7 = (double.TryParse(e.Value.ToString(), out result7) ? result7 : 0.0);
		double num14 = result7 / 100.0 * 20.0;
		double value8 = result7 / 100.0 * 10.0;
		double value9 = num14 / 20.0 * 3.0;
		value9 = Math.Round(value9, 1);
		double num15 = num12 + result6;
		string key = EOYYearGrade(num15).Key;
		string key2 = EOYYearGrade(result7).Key;
		double num16 = Math.Round(num15 / 100.0 * 3.0, 1);
		double num17 = Math.Round(result7 / 100.0 * 3.0, 1);
		string value10 = gradingScale.GetGradingScale(num9).Value;
		string value11 = gradingScale.GetGradingScale(num16).Value;
		string automaticSubjectComment = gradingScale.GetAutomaticSubjectComment((float)num16, useSmallScale: false);
		string automaticSubjectComment2 = gradingScale.GetAutomaticSubjectComment((float)num17);
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Column.FieldName;
		string arg = fieldName.PadRight(6).Substring(4, 2).Trim();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET Descriptor_{0}=@Descriptor_{0},TeacherRemarks=@TeacherRemarks,TeacherRemarksAIOnly=@TeacherRemarksAIOnly, Hund{0}=@Hund{0},Score{0}=@Score{0},U{0}=@U{0},T{0}=@T{0},TTLPoints=@TTLPoints,OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen,Initial=@Initial,AvMark=@AvMark,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,Score100=@Score100,Category=@Category,CategoryAIOnly=@CategoryAIOnly,IsEdited=1 WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", "-");
			sqlParameter.Direction = ParameterDirection.Input;
		}
		else
		{
			string value12 = gradingScale.GetGradingScale(value9).Value;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Descriptor_{arg}", value12);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", result7);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", Math.Round(num14, 1, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", Math.Round(value8, 1, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", value9);
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num13);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Initial", TeacherInitials.GetTeacherInitials());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num8);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num9);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num15);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@CategoryAIOnly", key2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarks", automaticSubjectComment);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarksAIOnly", automaticSubjectComment2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num16);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gv100.SetRowCellValue(e.RowHandle, "OutOfHund", num11);
		}
		sqlConnection.Close();
	}

	private void MarksCalculatorEOT(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (!(e.Column.FieldName == "ETA"))
		{
			return;
		}
		_Student = gvEOT.GetRowCellValue(e.RowHandle, "StudentNumber").ToString();
		int num = e.RowHandle;
		double result = (double.TryParse(gvEOT.GetRowCellValue(num, "AvMark").ToString(), out result) ? result : 0.0);
		double result2 = (double.TryParse(e.Value.ToString(), out result2) ? result2 : 0.0);
		double num2 = Math.Round(result2 / 100.0 * 80.0, 1, MidpointRounding.AwayFromZero);
		double num3 = result + num2;
		double result3 = (double.TryParse(e.Value.ToString(), out result3) ? result3 : 0.0);
		string key = EOYYearGrade(num3).Key;
		string key2 = EOYYearGrade(result3).Key;
		double num4 = Math.Round(num3 / 100.0 * 3.0, 1);
		double num5 = Math.Round(result3 / 100.0 * 3.0, 1);
		string key3 = gradingScale.GetGradingScale(num4).Key;
		string value = gradingScale.GetGradingScale(num4).Value;
		string automaticSubjectComment = gradingScale.GetAutomaticSubjectComment((float)num4, useSmallScale: false);
		string automaticSubjectComment2 = gradingScale.GetAutomaticSubjectComment((float)num5, useSmallScale: false);
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_Scores_OL_Report SET ETA=@ETA, ETA80=@ETA80,ETAv=@ETAv,Descriptor100=@Descriptor100,Score100=@Score100,P5=@P5,P6=@P6,Category=@Category,TeacherRemarks=@TeacherRemarks,IsEdited=1 WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ETA", result2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETA80", num2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num3);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Initial", TeacherInitials.GetTeacherInitials());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num4);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P5", key2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P6", automaticSubjectComment2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TeacherRemarks", automaticSubjectComment);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gvEOT.SetRowCellValue(e.RowHandle, "ETA80", num2);
			gvEOT.SetRowCellValue(e.RowHandle, "ETAv", num3);
			gvEOT.SetRowCellValue(e.RowHandle, "Category", key);
		}
		sqlConnection.Close();
	}

	private void tmUpdate_Tick(object sender, EventArgs e)
	{
		i++;
		if (i == 3)
		{
			i = 0;
			bgSaveMarks.RunWorkerAsync();
		}
	}

	private void dgMain_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
		{
			e.Handled = true;
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

	private void bandedGridView1_CustomColumnDisplayText_1(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void bandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		try
		{
			if (navigationFrame1.SelectedPage == navPageLO)
			{
				MarksCalculator(e);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void bgSaveMarks_DoWork(object sender, DoWorkEventArgs e)
	{
		ExamsOutputString.InitializeExamsOutputStrings(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
	}

	private void bgSaveMarks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		tmUpdate.Enabled = true;
	}

	private void StudentImage(string StudentNumber)
	{
	}

	private void LoadImage(DataRow row)
	{
		if (row != null)
		{
			NewStudentName = row["fullName"].ToString();
			NewStudentNumber = row["StudentNumber"].ToString();
			lblStudentName.Caption = NewStudentName;
			lblStudentNo.Caption = NewStudentNumber;
			lblStudentID.Caption = row["StudentID"].ToString();
		}
		else
		{
			NewStudentName = "";
			NewStudentNumber = "";
			lblStudentName.Caption = NewStudentName;
			lblStudentNo.Caption = NewStudentNumber;
			lblStudentID.Caption = "";
		}
	}

	private void bandedGridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (bandedGridView1.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
		}
	}

	private void tileItemClassSettings_ItemClick(object sender, TileItemEventArgs e)
	{
		ScoreLoadMode = "AfterStudentDelete";
		DropSubjectsWholeClass();
		LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
	}

	private void tileItemPrint_ItemClick(object sender, TileItemEventArgs e)
	{
		printableComponentLink1.PrintingSystem.ClearContent();
		if (navigationFrame1.SelectedPageIndex == 0)
		{
			printableComponentLink1.Component = dgMain;
		}
		else if (navigationFrame1.SelectedPageIndex == 1)
		{
			printableComponentLink1.Component = dgMain20;
		}
		else if (navigationFrame1.SelectedPageIndex == 2)
		{
			printableComponentLink1.Component = dgMain100;
		}
		else if (navigationFrame1.SelectedPageIndex == 3)
		{
			printableComponentLink1.Component = gridEOT;
		}
		ReportHeader(string.Empty);
		printableComponentLink1.ShowPreview();
	}

	private void flyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
	{
		if (e.Button == flyoutPanel1.OptionsButtonPanel.Buttons[0])
		{
			string caption = lblTerm.Caption;
			string s = caption.Substring(caption.IndexOf('-') + 1, 4);
			int result = (int.TryParse(s, out result) ? result : 1984);
			RegisterStudentsNewCur registerStudentsNewCur = new RegisterStudentsNewCur(_Class, _Term, gridView1, _Subject, UnitsUsed);
			if (registerStudentsNewCur.ShowDialog() == DialogResult.OK)
			{
				flyoutPanel1.HidePopup();
				LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
			}
		}
		else if (e.Button == flyoutPanel1.OptionsButtonPanel.Buttons[1])
		{
			flyoutPanel1.HidePopup();
		}
	}

	private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
	{
		LoadUnRegisteredStudents();
		flyoutPanel1.Height = base.Height - 50;
		flyoutPanel1.ShowPopup();
	}

	private void gv20_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gv20.FocusedRowHandle > -1 && (gv20.FocusedColumn != bandedGridView1.Columns["StudentNumber"] || gv20.FocusedColumn != bandedGridView1.Columns["fullName"] || gv20.FocusedColumn != bandedGridView1.Columns["StreamId"] || gv20.FocusedColumn != bandedGridView1.Columns["Sex"] || gv20.FocusedColumn != bandedGridView1.Columns["GenericSkills"] || gv20.FocusedColumn != bandedGridView1.Columns["bandedGridColumn6"] || gv20.FocusedColumn != bandedGridView1.Columns["OutOfTwenty"]))
		{
			if ((!double.TryParse(e.Value.ToString(), out var result) && e.Value.ToString() != "-") || result > 20.0 || result < 0.0)
			{
				e.Valid = false;
			}
			else if (!double.TryParse(e.Value.ToString(), out result) && e.Value.ToString() == "-")
			{
				e.Valid = true;
			}
		}
	}

	private void gv20_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 0 to 20 only.";
		gv20.HideEditor();
	}

	private void gv20_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gv100_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gv20_KeyDown(object sender, KeyEventArgs e)
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

	private void gv100_KeyDown(object sender, KeyEventArgs e)
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

	private void gv20_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gv20.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
		}
	}

	private void gv100_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gv100.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
		}
	}

	private void gv20_RowClick(object sender, RowClickEventArgs e)
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

	private void gv100_RowClick(object sender, RowClickEventArgs e)
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

	private void gv100_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gv100.FocusedRowHandle > -1 && (bandedGridView1.FocusedColumn != bandedGridView1.Columns["StudentNumber"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["fullName"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["StreamId"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["Sex"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["GenericSkills"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["bandedGridColumn27"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["OutOfHund"]))
		{
			if ((!int.TryParse(e.Value.ToString(), out var result) && e.Value.ToString() != "-") || result > 100 || result < 0)
			{
				e.Valid = false;
			}
			else if (!int.TryParse(e.Value.ToString(), out result) && e.Value.ToString() == "-")
			{
				e.Valid = true;
			}
		}
	}

	private void gv100_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 0 to 100 only.";
		gv100.HideEditor();
	}

	private void gv20_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (navigationFrame1.SelectedPage == navPage20)
		{
			MarksCalculator20(e);
		}
	}

	private void gv100_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		try
		{
			if (navigationFrame1.SelectedPage == navPage100)
			{
				MarksCalculator100(e);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void navigationFrame1_SelectedPageIndexChanged(object sender, EventArgs e)
	{
		if (navigationFrame1.SelectedPageIndex == 8)
		{
			LoadChapters();
		}
		else
		{
			LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
		}
	}

	private void gvEOT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (navigationFrame1.SelectedPage == navPageEOT)
		{
			MarksCalculatorEOT(e);
		}
	}

	private void gvEOT_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gvEOT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gvEOT.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
		}
	}

	private void ChangeHeaderTextDes(bool IsEnabled)
	{
	}

	private void ChangeHeaderText(bool IsEnabled)
	{
		barButtonItem5.Enabled = IsEnabled;
		ribbonPageGroup8.Visible = IsEnabled;
		barButtonItem1.Enabled = IsEnabled;
		barButtonItem4.Enabled = IsEnabled;
		lblStream.Enabled = IsEnabled;
		barButtonItem2.Enabled = IsEnabled;
		barButtonItem3.Enabled = IsEnabled;
	}

	private void ChangeHeaderText(TileItemEventArgs e, bool IsEnabled)
	{
		barButtonItem5.Enabled = IsEnabled;
		ribbonPageGroup8.Visible = IsEnabled;
		ribbonPage1.Text = e.Item.Text;
		lblWelcome.Text = e.Item.Text;
		barButtonItem1.Enabled = IsEnabled;
		barButtonItem4.Enabled = IsEnabled;
		lblStream.Enabled = IsEnabled;
		barButtonItem2.Enabled = IsEnabled;
		barButtonItem3.Enabled = IsEnabled;
		lblWelcome.BackColor = e.Item.AppearanceItem.Normal.BackColor;
	}

	private void tileItemLO_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageLO;
		ChangeHeaderText(e, IsEnabled: true);
	}

	private void tileItemR10_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPage10;
		ChangeHeaderText(e, IsEnabled: true);
	}

	private void tileItemR20_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPage20;
		ChangeHeaderText(e, IsEnabled: true);
	}

	private void tileItemR100_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPage100;
		ChangeHeaderText(e, IsEnabled: true);
	}

	private void tileItemREOT_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageEOT;
		ChangeHeaderText(e, IsEnabled: true);
	}

	private void tileItemRDes_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageDescr;
		ChangeHeaderText(e, IsEnabled: true);
		ChangeHeaderTextDes(IsEnabled: true);
	}

	private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
	{
		ChangeStream changeStream = new ChangeStream(tileItemClassSettings.Caption);
		if (changeStream.ShowDialog() == DialogResult.OK)
		{
			if (changeStream.stream == "Entire Class")
			{
				LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
			}
			else
			{
				LoadOLevelMarks(changeStream.stream, navigationFrame1.SelectedPageIndex);
			}
			lblStream.Caption = changeStream.stream;
		}
	}

	private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
	{
		LoadUnRegisteredStudents();
		flyoutPanel1.Height = base.Height - 50;
		flyoutPanel1.ShowPopup();
	}

	private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
	{
		ScoreLoadMode = "AfterStudentDelete";
		DropSubjectsSingle();
		LoadOLevelMarks(navigationFrame1.SelectedPageIndex);
	}

	private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
	{
		if (navigationFrame1.SelectedPage == navPageLO)
		{
			ExportReportToExcel(dgMain, $"{lblSubject.Caption}!{tileItemClassSettings.Caption}${lblTerm.Caption}");
		}
		else if (navigationFrame1.SelectedPage == navPage10)
		{
			ExportReportToExcel(dgMain10, $"{lblSubject.Caption}!{tileItemClassSettings.Caption}${lblTerm.Caption}");
		}
		else if (navigationFrame1.SelectedPage == navPage20)
		{
			ExportReportToExcel(dgMain20, $"{lblSubject.Caption}!{tileItemClassSettings.Caption}${lblTerm.Caption}");
		}
		else if (navigationFrame1.SelectedPage == navPage100)
		{
			ExportReportToExcel(dgMain100, $"{lblSubject.Caption}!{tileItemClassSettings.Caption}${lblTerm.Caption}");
		}
		else if (navigationFrame1.SelectedPage == navPageEOT)
		{
			ExportReportToExcel(gridEOT, $"{lblSubject.Caption}!{tileItemClassSettings.Caption}${lblTerm.Caption}");
		}
	}

	private void LoadStudentsList(string _Stream)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT  s.StudentNumber,s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId FROM    tbl_Stud AS s INNER JOIN   tbl_Scores_OL_Report AS r ON s.StudentNumber = r.StudentNumber AND s.ClassId = r.ClassId GROUP BY s.StudentNumber,s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId HAVING   (s.StreamId = '{_Stream}') AND (r.SemesterId = '{_Term}') AND (s.ClassId = '{_Class}') ORDER BY s.fullName", DataConnection.ConnectToDatabase());
		dt = new DataTable();
		sqlDataAdapter.Fill(dt);
		if (dt.Rows.Count > 0)
		{
			barButtonItem4.Enabled = true;
			if (navigationFrame1.SelectedPage == navPageDescr)
			{
				dgMainDescriptive.DataSource = dt.DefaultView;
			}
			else if (navigationFrame1.SelectedPage == navPageOtherComp)
			{
				dgOtherComp.DataSource = dt.DefaultView;
			}
		}
		else
		{
			barButtonItem4.Enabled = false;
			dgMainDescriptive.DataSource = null;
			dgOtherComp.DataSource = null;
		}
	}

	private void LoadStudentsList()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT  s.StudentNumber,s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId FROM    tbl_Stud AS s INNER JOIN   tbl_Scores_OL_Report AS r ON s.StudentNumber = r.StudentNumber AND s.ClassId = r.ClassId GROUP BY s.StudentNumber,s.StudentId, s.fullName, s.StreamId, s.Sex, s.StudyStatus, r.SemesterId, s.ClassId HAVING   (r.SemesterId = '{_Term}') AND (s.ClassId = '{_Class}') ORDER BY s.fullName", DataConnection.ConnectToDatabase());
		dt = new DataTable();
		sqlDataAdapter.Fill(dt);
		if (dt.Rows.Count > 0)
		{
			barButtonItem4.Enabled = true;
			if (navigationFrame1.SelectedPage == navPageDescr)
			{
				dgMainDescriptive.DataSource = dt.DefaultView;
			}
			else if (navigationFrame1.SelectedPage == navPageOtherComp)
			{
				dgOtherComp.DataSource = dt.DefaultView;
			}
		}
		else
		{
			barButtonItem4.Enabled = false;
			dgMainDescriptive.DataSource = null;
			dgOtherComp.DataSource = null;
		}
	}

	private void LoadScoreSheet(string StudentNo)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT AvLO,ISNULL(TeacherRemarks,'') AS TeacherRemarks,Id,ISNULL(GenericSkills,'') AS GenericSkills,GenericSkill_1,GenericSkill_2,GenericSkill_3,GenericSkill_4 FROM tbl_Scores_OL_Report WHERE StudentNumber='{StudentNo}' AND ClassId='{_Class}' AND SemesterId='{_Term}' AND SubjectId='{_Subject}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		if (dataTable.Rows.Count > 0)
		{
			vGridControl1.DataSource = dataTable.DefaultView;
		}
		else
		{
			vGridControl1.DataSource = null;
		}
	}

	private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
	}

	private void gvDescriptive_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gvDescriptive.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
			LoadScoreSheet(NewStudentNumber);
		}
	}

	private void gvDescriptive_RowClick(object sender, RowClickEventArgs e)
	{
		if (e.RowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.RowHandle];
			LoadImage(dataRow);
			LoadScoreSheet(NewStudentNumber);
		}
	}

	private void gvDescriptive_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void UpdateMarks(string values, long Id, string col)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string commandText = string.Format("UPDATE tbl_Scores_OL_Report SET {0}=@{0} WHERE Id={1} ", col, Id);
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = commandText,
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add($"@{col}", SqlDbType.NVarChar);
		sqlParameter.Value = values;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
		}
	}

	private void vGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		string values = e.Value.ToString();
		long id = Convert.ToInt64(vGridControl1.GetCellValue(rowId, e.RecordIndex).ToString());
		string fieldName = e.Row.Properties.FieldName;
		UpdateMarks(values, id, fieldName);
	}

	private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
	{
		GenerateDescriptive generateDescriptive = new GenerateDescriptive(_Subject, _Class, _Term, TeacherInitials.GetTeacherInitials());
		if (generateDescriptive.ShowDialog() == DialogResult.OK)
		{
			LoadScoreSheet(NewStudentNumber);
		}
	}

	private void CloseFlyoutDialogCallBackFN()
	{
		dialog.Close();
	}

	private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
	{
		usrGenerateChapter = new usrGenerateChapterNames(lblSubject.Caption, tileItemClassSettings.Caption, lblTerm.Caption);
		usrGenerateChapter.CloseFlyoutDialog = CloseFlyoutDialogCallBackFN;
		dialog = new FlyoutDialog(this, usrGenerateChapter);
		dialog.ShowDialog();
	}

	private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
	{
		printableComponentLink1.PrintingSystem.ClearContent();
		if (navigationFrame1.SelectedPage == navPageLO)
		{
			printableComponentLink1.Component = dgMain;
		}
		else if (navigationFrame1.SelectedPage == navPage20)
		{
			printableComponentLink1.Component = dgMain20;
		}
		else if (navigationFrame1.SelectedPage == navPage100)
		{
			printableComponentLink1.Component = dgMain100;
		}
		else if (navigationFrame1.SelectedPage == navPageEOT)
		{
			printableComponentLink1.Component = gridEOT;
		}
		ReportHeader(string.Empty);
		printableComponentLink1.ShowPreview();
	}

	private void gv10_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		try
		{
			if (navigationFrame1.SelectedPage == navPage10)
			{
				MarksCalculator10(e);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gv10_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gv10_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 1 to 10 only.";
		gv10.HideEditor();
	}

	private void gv10_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gv10.FocusedRowHandle > -1 && (gv10.FocusedColumn != gv10.Columns["StudentNumber"] || gv10.FocusedColumn != gv10.Columns["fullName"] || gv10.FocusedColumn != gv10.Columns["StreamId"] || gv10.FocusedColumn != gv10.Columns["Sex"] || gv10.FocusedColumn != gv10.Columns["GenericSkills"] || gv10.FocusedColumn != gv10.Columns["OutOfTen"]))
		{
			double result;
			if (e.Value.ToString() == "-")
			{
				e.Valid = true;
			}
			else if (!double.TryParse(e.Value.ToString(), out result) || result > 10.0 || result < 1.0)
			{
				e.Valid = false;
			}
			else if (!double.TryParse(e.Value.ToString(), out result))
			{
				e.Valid = true;
			}
		}
	}

	private void gv10_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gv10.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
		}
	}

	private void tileItem1_ItemClick_1(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageOtherComp;
		ChangeHeaderText(e, IsEnabled: true);
	}

	private void LoadReportAssessment()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT Id,ISNULL(Project,'') AS Project,ISNULL(ProjectTitle,'') AS ProjectTitle  FROM tbl_Scores_OL_Report WHERE ClassId='{_Class}' AND SemesterId='{_Term}' AND StudentNumber='{NewStudentNumber}'", DataConnection.ConnectToDatabase());
		_dt = new DataTable();
		sqlDataAdapter.Fill(_dt);
		if (_dt.Rows.Count > 0)
		{
			vGridControl2.DataSource = _dt.DefaultView;
		}
		else
		{
			vGridControl2.DataSource = null;
		}
	}

	private void gvOtherComp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
		if (gvOtherComp.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			LoadImage(dataRow);
			LoadReportAssessment();
		}
	}

	private void vGridControl2_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Row.Properties.FieldName;
		long num = Convert.ToInt64(vGridControl2.GetCellValue(row1, e.RecordIndex).ToString());
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET {0}=@{0} WHERE Id=@Id", fieldName),
			CommandType = CommandType.Text
		};
		sqlCommand.Parameters.Add(new SqlParameter($"@{fieldName}", e.Value));
		sqlCommand.Parameters.Add(new SqlParameter("@Id", num));
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void gvOtherComp_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void NavigateHome()
	{
		navigationFrame1.SelectedPage = navPageHome;
		barButtonItem4.Enabled = false;
		barButtonItem5.Enabled = false;
		ribbonPage1.Text = "Marks Entry";
		lblWelcome.Text = "Choose Data Entry Model to Begin";
		lblWelcome.BackColor = Color.MidnightBlue;
		ChangeHeaderTextDes(IsEnabled: false);
		ChangeHeaderText(IsEnabled: false);
		ribbonPageGroup8.Visible = false;
		NewStudentName = "";
		NewStudentNumber = "";
		lblStudentName.Caption = "";
		lblStudentNo.Caption = "";
		lblStudentID.Caption = "";
	}

	private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
	{
		NavigateHome();
		flyoutPanel2.Height = base.Height;
		Classes.LoadLookUpWithClasses(lookupClasses);
		flyoutPanel2.ShowPopup();
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		System.Windows.Forms.Application.ExitThread();
	}

	private void LoginToSubjects()
	{
		try
		{
			string text = CryptorEngine.Encrypt(txtPassword.Text + txtUserId.Text.ToLower() + SelectedClass);
			string arg = CryptorEngine.Encrypt($"DOS{txtUserId.Text.ToLower()}{txtPassword.Text}");
			_Class = SelectedClass;
			_Subject = cboSubject.Text;
			tileItemClassSettings.Caption = SelectedClass;
			lblSubject.Caption = _Subject;
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_userLogin WHERE GroupName='DOS' AND userName='{txtUserId.Text.ToUpper()}' AND Password='{arg}'",
				CommandType = CommandType.Text
			};
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				using (SubjectInitials subjectInitials = new SubjectInitials())
				{
					if (subjectInitials.ShowDialog() == DialogResult.OK)
					{
						TeacherLogin.InitializeLogin(SelectedClass, WorkingSemesters.GetWorkingSemester(), cboSubject.SelectedItem.ToString(), TeacherInitials.GetTeacherInitials(), txtUserId.Text.ToUpper(), "DOS");
						LoginStatus.SaveLoginStatus(loggedIn: true);
						MarksGateway.SetLoginParameters(TeacherInitials.GetTeacherInitials(), cboSubject.SelectedItem.ToString(), SelectedClass, WorkingSemesters.GetWorkingSemester(), "New");
						_TR = TeacherInitials.GetTeacherInitials();
						lblTeacher.Caption = TeacherInitials.GetTeacherInitials();
						flyoutPanel2.HidePopup();
					}
					else
					{
						LoginStatus.SaveLoginStatus(loggedIn: false);
					}
					return;
				}
			}
			SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			SqlCommand sqlCommand2 = new SqlCommand();
			sqlCommand2.Connection = sqlConnection2;
			string commandText = $"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtUserId.Text.ToUpper()}' AND SubjectId = '{cboSubject.Text}' AND ClassId='{SelectedClass}'";
			sqlCommand2.CommandText = commandText;
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			if (sqlDataReader2.HasRows)
			{
				sqlConnection2.Close();
				string commandText2 = "SELECT * FROM tbl_subjectLogin WHERE staffId=@staffId AND SubjectId=@SubjectId AND ClassId=@ClassId AND Password=@Password";
				SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection3.Open();
				SqlCommand sqlCommand3 = new SqlCommand();
				sqlCommand3.Connection = sqlConnection3;
				sqlCommand3.CommandText = commandText2;
				sqlCommand3.CommandType = CommandType.Text;
				SqlParameter sqlParameter = sqlCommand3.Parameters.Add("@staffId", SqlDbType.VarChar, 50);
				sqlParameter.Value = txtUserId.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand3.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
				sqlParameter.Value = cboSubject.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
				sqlParameter.Value = SelectedClass;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand3.Parameters.Add("@Password", SqlDbType.VarChar, 80);
				sqlParameter.Value = string.Empty;
				sqlParameter.Direction = ParameterDirection.Input;
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				if (sqlDataReader3.HasRows)
				{
					using (CreateTeacherLogin createTeacherLogin = new CreateTeacherLogin())
					{
						createTeacherLogin.userId = txtUserId.Text;
						createTeacherLogin.subjectId = cboSubject.SelectedItem.ToString();
						createTeacherLogin.classId = SelectedClass;
						createTeacherLogin.txtNewUserId.Text = txtUserId.Text.ToUpper();
						createTeacherLogin.lblReason.Text = $"You must create a secret password that will enable you login to {cboSubject.SelectedItem.ToString()} for {SelectedClass} and enter marks";
						if (createTeacherLogin.ShowDialog() == DialogResult.OK)
						{
							using (SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase()))
							{
								sqlConnection4.Open();
								using SqlCommand sqlCommand4 = new SqlCommand
								{
									Connection = sqlConnection4,
									CommandText = "UPDATE tbl_subjectLogin SET Password=@Password,Password2=@Password2,Login=@Login WHERE staffId=@staffId AND SubjectId LIKE '%" + createTeacherLogin.subjectId + "%' AND ClassId=@ClassId",
									CommandType = CommandType.Text
								};
								SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@Password", SqlDbType.VarChar, 80);
								sqlParameter2.Value = createTeacherLogin.newPassWord;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@Password2", SqlDbType.VarChar, 50);
								sqlParameter2.Value = createTeacherLogin.newPassWord2;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@Login", SqlDbType.VarChar, 50);
								sqlParameter2.Value = createTeacherLogin.userId;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@staffId", SqlDbType.VarChar, 50);
								sqlParameter2.Value = createTeacherLogin.userId;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
								sqlParameter2.Value = createTeacherLogin.classId;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlCommand4.ExecuteNonQuery();
								sqlConnection4.Close();
								return;
							}
						}
						return;
					}
				}
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_subjectLogin WHERE staffId='{txtUserId.Text.ToUpper()}' AND SubjectId='{cboSubject.Text}' AND ClassId='{SelectedClass}' AND Password='{text}'", DataConnection.ConnectToDatabase());
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "ValidateLogin");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						TeacherLogin.InitializeLogin(SelectedClass, WorkingSemesters.GetWorkingSemester(), cboSubject.SelectedItem.ToString(), row["StaffName"].ToString(), txtUserId.Text, "Teacher");
						TeacherInitials.SetInitials(row["StaffName"].ToString());
						MarksGateway.SetLoginParameters(TeacherInitials.GetTeacherInitials(), cboSubject.SelectedItem.ToString(), SelectedClass, WorkingSemesters.GetWorkingSemester(), "New");
						_TR = TeacherInitials.GetTeacherInitials();
						lblTeacher.Caption = TeacherInitials.GetTeacherInitials();
						flyoutPanel2.HidePopup();
					}
					return;
				}
				XtraMessageBox.Show("Invalid Login!\nEither the Password or Username is incorrect", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				sqlConnection2.Close();
				XtraMessageBox.Show($"The Staff ID [{txtUserId.Text.ToUpper()}] you provided is not mapped for login in {cboSubject.SelectedItem.ToString()} in {SelectedClass}.\nPlease contact your system administrator.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message + "\nCANNOT CONNECT TO THE SERVER.\nPlease enter the correct server/database parameters or check your Network Integrity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			using ConnectToDatabase connectToDatabase = new ConnectToDatabase();
			connectToDatabase.ShowDialog();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		while (dxValidationLogin.Validate())
		{
			if (dxValidationLogin.GetInvalidControls().Count == 0)
			{
				LoginToSubjects();
				txtPassword.Text = string.Empty;
				txtUserId.Text = string.Empty;
				break;
			}
		}
	}

	private void LoadOLevelSubjects()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * from OLevelSubjects", selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "subject");
			DataTable dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				cboSubject.Properties.Items.Clear();
				foreach (DataRow row in dataTable.Rows)
				{
					cboSubject.Properties.Items.Add(row["SubjectId"].ToString());
				}
				cboSubject.SelectedIndex = 0;
				cboSubject.ForeColor = Color.Black;
			}
			else
			{
				cboSubject.Properties.Items.Clear();
				cboSubject.Properties.Items.Add("No Subjects");
				cboSubject.SelectedIndex = 0;
				cboSubject.ForeColor = Color.Red;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	private void lookupClasses_EditValueChanged(object sender, EventArgs e)
	{
		if (lookupClasses.EditValue == null)
		{
			return;
		}
		try
		{
			if (!string.IsNullOrEmpty(lookupClasses.Text) || lookupClasses.Text != "N/A")
			{
				cboSubject.Enabled = true;
				SelectedClass = lookupClasses.Properties.GetDataSourceValue("ClassId", lookupClasses.ItemIndex).ToString();
				SelectedClassGroup = lookupClasses.Properties.GetDataSourceValue("ClassGroup", lookupClasses.ItemIndex).ToString();
				if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString() || (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && SchoolSettings.ClassLevel(SelectedClass) == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
				{
					LoadOLevelSubjects();
				}
				else
				{
					cboSubject.Properties.Items.Clear();
				}
			}
			else
			{
				SelectedClass = string.Empty;
				SelectedClassGroup = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void lookupClasses_QueryPopUp(object sender, CancelEventArgs e)
	{
		SelectedClass = string.Empty;
		SelectedClassGroup = string.Empty;
		cboSubject.Text = string.Empty;
	}

	private void ShowPopup()
	{
		flyoutPanel3.Height = base.Height;
		flyoutPanel3.ShowPopup();
	}

	private void gridView6_RowClick(object sender, RowClickEventArgs e)
	{
		if (gridView6.FocusedRowHandle > -1)
		{
			genericSkill = gridView6.GetRowCellValue(e.RowHandle, "Remark").ToString();
			if (navigationFrame1.SelectedPage == navPageLO)
			{
				bandedGridView1.SetRowCellValue(rowHandle, "GenericSkills", genericSkill);
				flyoutPanel3.HidePopup();
			}
		}
	}

	private void gridView6_DoubleClick(object sender, EventArgs e)
	{
	}

	private void flyoutPanel3_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
	{
		if (e.Button == flyoutPanel3.OptionsButtonPanel.Buttons[0])
		{
			flyoutPanel3.HidePopup();
		}
	}

	private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
	{
	}

	private void repositoryItemRibbonSearchEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
	{
		if (bandedGridView1.FocusedRowHandle > -1)
		{
			rowHandle = bandedGridView1.FocusedRowHandle;
			ShowPopup();
		}
	}

	private void UpdateCompetence(string col, string values, int compNo)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string empty = string.Empty;
		empty = ((!col.Contains("Topic")) ? string.Format("UPDATE tbl_Scores_OL_Report SET Competence_{0}=@Competence_{0} WHERE SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", compNo) : string.Format("UPDATE tbl_Scores_OL_Report SET Topic_{0}=@Topic_{0} WHERE SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", compNo));
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = empty,
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (col.Contains("Topic"))
		{
			sqlParameter = sqlCommand.Parameters.Add($"Topic_{compNo}", SqlDbType.NVarChar, 100);
			sqlParameter.Value = values;
			sqlParameter.Direction = ParameterDirection.Input;
		}
		else
		{
			sqlParameter = sqlCommand.Parameters.Add($"Competence_{compNo}", SqlDbType.NVarChar, 500);
			sqlParameter.Value = values;
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.Add("SubjectId", SqlDbType.NVarChar, 50);
		sqlParameter.Value = _Subject;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("ClassId", SqlDbType.NVarChar, 50);
		sqlParameter.Value = _Class;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("SemesterId", SqlDbType.NVarChar, 50);
		sqlParameter.Value = _Term;
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
		}
	}

	private void vGridLoadChapters_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		string values = e.Value.ToString();
		string fieldName = e.Row.Properties.FieldName;
		int compNo = Convert.ToInt32(e.Row.Tag.ToString());
		UpdateCompetence(fieldName, values, compNo);
	}

	private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageCompetence;
		ChangeHeaderText(e, IsEnabled: true);
		ChangeHeaderTextDes(IsEnabled: true);
		lblWelcome.Text = "Write Competences";
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarksEntry.MarksEntryForms.MainOLevelNewCur));
		DevExpress.Skins.SkinPaddingEdges skinPaddingEdges = new DevExpress.Skins.SkinPaddingEdges();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
		DevExpress.Utils.SerializableAppearanceObject appearance = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.Utils.SerializableAppearanceObject appearanceHovered = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.Utils.SerializableAppearanceObject appearancePressed = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.Utils.SerializableAppearanceObject appearanceDisabled = new DevExpress.Utils.SerializableAppearanceObject();
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode5 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.XtraEditors.TileItemElement tileItemElement = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule4 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
		this.repositoryItemMemoEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
		this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
		this.lblStream = new DevExpress.XtraBars.BarButtonItem();
		this.barListItem1 = new DevExpress.XtraBars.BarListItem();
		this.tileItemClassSettings = new DevExpress.XtraBars.BarStaticItem();
		this.lblTerm = new DevExpress.XtraBars.BarStaticItem();
		this.lblSubject = new DevExpress.XtraBars.BarStaticItem();
		this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
		this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
		this.skinDropDownButtonItem2 = new DevExpress.XtraBars.SkinDropDownButtonItem();
		this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
		this.lblTeacher = new DevExpress.XtraBars.BarStaticItem();
		this.lblIPAddress = new DevExpress.XtraBars.BarStaticItem();
		this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
		this.lblStudentName = new DevExpress.XtraBars.BarStaticItem();
		this.lblStudentNo = new DevExpress.XtraBars.BarStaticItem();
		this.lblStudentID = new DevExpress.XtraBars.BarStaticItem();
		this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
		this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
		this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
		this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
		this.picStudentPicture = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
		this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
		this.dgMain = new AlienAge.CustomGrid.MyGridControl();
		this.bandedGridView1 = new AlienAge.CustomGrid.MyBandedGridView();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn46 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemRibbonSearchEdit1 = new DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit();
		this.bandedGridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn37 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn50 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn51 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.tmUpdate = new System.Windows.Forms.Timer(this.components);
		this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
		this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
		this.bgSaveMarks = new System.ComponentModel.BackgroundWorker();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
		this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
		this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.navPageLO = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.flyoutPanel3 = new DevExpress.Utils.FlyoutPanel();
		this.flyoutPanelControl3 = new DevExpress.Utils.FlyoutPanelControl();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.navPage20 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.dgMain20 = new AlienAge.CustomGrid.MyGridControl();
		this.gv20 = new AlienAge.CustomGrid.MyBandedGridView();
		this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn24 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn48 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn26 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn39 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.navPage100 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.dgMain100 = new AlienAge.CustomGrid.MyGridControl();
		this.gv100 = new AlienAge.CustomGrid.MyBandedGridView();
		this.bandedGridColumn27 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn28 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn29 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn30 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn31 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn49 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn45 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.navPageEOT = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridEOT = new AlienAge.CustomGrid.MyGridControl();
		this.gvEOT = new AlienAge.CustomGrid.MyBandedGridView();
		this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn14 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn15 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn19 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn20 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn21 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn43 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn41 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn25 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn23 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn22 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn40 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.navPage10 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.dgMain10 = new AlienAge.CustomGrid.MyGridControl();
		this.gv10 = new AlienAge.CustomGrid.MyBandedGridView();
		this.bandedGridColumn32 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn33 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn34 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn35 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn36 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colProject = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn47 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn53 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn38 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.navPageHome = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.tileControl2 = new DevExpress.XtraEditors.TileControl();
		this.tileGroup5 = new DevExpress.XtraEditors.TileGroup();
		this.tileItemLO = new DevExpress.XtraEditors.TileItem();
		this.tileItemR10 = new DevExpress.XtraEditors.TileItem();
		this.tileGroup4 = new DevExpress.XtraEditors.TileGroup();
		this.tileItemR20 = new DevExpress.XtraEditors.TileItem();
		this.tileItemR100 = new DevExpress.XtraEditors.TileItem();
		this.tileItemREOT = new DevExpress.XtraEditors.TileItem();
		this.tileGroup7 = new DevExpress.XtraEditors.TileGroup();
		this.tileItemRDes = new DevExpress.XtraEditors.TileItem();
		this.tileItem1 = new DevExpress.XtraEditors.TileItem();
		this.tileItem2 = new DevExpress.XtraEditors.TileItem();
		this.navPageDescr = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
		this.dgMainDescriptive = new DevExpress.XtraGrid.GridControl();
		this.gvDescriptive = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.rowId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row6 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row7 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.navPageOtherComp = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
		this.dgOtherComp = new DevExpress.XtraGrid.GridControl();
		this.gvOtherComp = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.ProjectTitle = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Project = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.navPageCompetence = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.vGridLoadChapters = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.repositoryItemMemoEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit10 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit11 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.rowTopic1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowTopic2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowCompetence2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowTopic3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowCompetence3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowTopic4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.rowCompetence4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.lblWelcome = new DevExpress.XtraEditors.LabelControl();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.flyoutPanel2 = new DevExpress.Utils.FlyoutPanel();
		this.flyoutPanelControl2 = new DevExpress.Utils.FlyoutPanelControl();
		this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.lookupClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtPassword = new DevExpress.XtraEditors.TextEdit();
		this.cboSubject = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.txtUserId = new DevExpress.XtraEditors.TextEdit();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.dxValidationLogin = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
		this.colU5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand16 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.colT5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBandProject = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand17 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.colScore5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand19 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		DevExpress.XtraVerticalGrid.Rows.EditorRow editorRow = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picStudentPicture).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemRibbonSearchEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).BeginInit();
		this.flyoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).BeginInit();
		this.flyoutPanelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).BeginInit();
		this.navigationFrame1.SuspendLayout();
		this.navPageLO.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel3).BeginInit();
		this.flyoutPanel3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl3).BeginInit();
		this.flyoutPanelControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView6).BeginInit();
		this.navPage20.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgMain20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gv20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		this.navPage100.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgMain100).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gv100).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView3).BeginInit();
		this.navPageEOT.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridEOT).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gvEOT).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView4).BeginInit();
		this.navPage10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgMain10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gv10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView5).BeginInit();
		this.navPageHome.SuspendLayout();
		this.navPageDescr.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2.Panel1).BeginInit();
		this.splitContainerControl2.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2.Panel2).BeginInit();
		this.splitContainerControl2.Panel2.SuspendLayout();
		this.splitContainerControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgMainDescriptive).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gvDescriptive).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit7).BeginInit();
		this.navPageOtherComp.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel1).BeginInit();
		this.splitContainerControl1.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel2).BeginInit();
		this.splitContainerControl1.Panel2.SuspendLayout();
		this.splitContainerControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgOtherComp).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gvOtherComp).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		this.navPageCompetence.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridLoadChapters).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel2).BeginInit();
		this.flyoutPanel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl2).BeginInit();
		this.flyoutPanelControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.lookupClasses.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationLogin).BeginInit();
		base.SuspendLayout();
		editorRow.AppearanceHeader.Options.UseTextOptions = true;
		editorRow.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		editorRow.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		editorRow.Name = "rowCompetence1";
		editorRow.Properties.Caption = "Competency 1";
		editorRow.Properties.FieldName = "Competence_1";
		editorRow.Properties.RowEdit = this.repositoryItemMemoEdit8;
		editorRow.Tag = (short)1;
		this.repositoryItemMemoEdit8.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit8.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.repositoryItemMemoEdit8.LinesCount = 5;
		this.repositoryItemMemoEdit8.Name = "repositoryItemMemoEdit8";
		this.popupMenu2.Name = "popupMenu2";
		this.popupMenu2.Ribbon = this.ribbonControl1;
		this.popupMenu2.CloseUp += new System.EventHandler(popupMenu2_CloseUp);
		this.ribbonControl1.AllowMinimizeRibbon = false;
		this.ribbonControl1.ExpandCollapseItem.Id = 0;
		this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[23]
		{
			this.ribbonControl1.ExpandCollapseItem,
			this.barButtonItem1,
			this.barButtonItem2,
			this.barButtonItem3,
			this.barButtonItem4,
			this.barButtonItem5,
			this.lblStream,
			this.barListItem1,
			this.tileItemClassSettings,
			this.lblTerm,
			this.lblSubject,
			this.skinDropDownButtonItem1,
			this.skinRibbonGalleryBarItem1,
			this.skinDropDownButtonItem2,
			this.barStaticItem1,
			this.lblTeacher,
			this.lblIPAddress,
			this.barStaticItem2,
			this.lblStudentName,
			this.lblStudentNo,
			this.lblStudentID,
			this.barButtonItem8,
			this.barButtonItem9
		});
		this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
		this.ribbonControl1.MaxItemId = 28;
		this.ribbonControl1.Name = "ribbonControl1";
		this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[1] { this.ribbonPage1 });
		this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.picStudentPicture, this.repositoryItemPictureEdit1 });
		this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
		this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
		this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
		this.ribbonControl1.ShowToolbarCustomizeItem = false;
		this.ribbonControl1.Size = new System.Drawing.Size(1322, 147);
		this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
		this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
		this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
		this.barButtonItem1.Caption = "Register More";
		this.barButtonItem1.Enabled = false;
		this.barButtonItem1.Id = 1;
		this.barButtonItem1.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem1.ImageOptions.Image");
		this.barButtonItem1.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem1.ImageOptions.LargeImage");
		this.barButtonItem1.Name = "barButtonItem1";
		this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem1_ItemClick);
		this.barButtonItem2.Caption = "Preview";
		this.barButtonItem2.Enabled = false;
		this.barButtonItem2.Id = 2;
		this.barButtonItem2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem2.ImageOptions.Image");
		this.barButtonItem2.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem2.ImageOptions.LargeImage");
		this.barButtonItem2.Name = "barButtonItem2";
		this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem2_ItemClick);
		this.barButtonItem3.Caption = "Export";
		this.barButtonItem3.Enabled = false;
		this.barButtonItem3.Id = 3;
		this.barButtonItem3.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem3.ImageOptions.Image");
		this.barButtonItem3.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem3.ImageOptions.LargeImage");
		this.barButtonItem3.Name = "barButtonItem3";
		this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem3_ItemClick);
		this.barButtonItem4.Caption = "Drop this Student";
		this.barButtonItem4.Enabled = false;
		this.barButtonItem4.Id = 4;
		this.barButtonItem4.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.Image");
		this.barButtonItem4.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem4.ImageOptions.LargeImage");
		this.barButtonItem4.Name = "barButtonItem4";
		this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
		this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem4_ItemClick);
		this.barButtonItem5.Caption = "Home";
		this.barButtonItem5.Enabled = false;
		this.barButtonItem5.Id = 5;
		this.barButtonItem5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.Image");
		this.barButtonItem5.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem5.ImageOptions.LargeImage");
		this.barButtonItem5.Name = "barButtonItem5";
		this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem5_ItemClick);
		this.lblStream.Caption = "Filter";
		this.lblStream.Enabled = false;
		this.lblStream.Id = 6;
		this.lblStream.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("lblStream.ImageOptions.Image");
		this.lblStream.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("lblStream.ImageOptions.LargeImage");
		this.lblStream.Name = "lblStream";
		this.lblStream.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem6_ItemClick);
		this.barListItem1.Caption = "barListItem1";
		this.barListItem1.Id = 7;
		this.barListItem1.Name = "barListItem1";
		this.tileItemClassSettings.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.tileItemClassSettings.Enabled = false;
		this.tileItemClassSettings.Id = 8;
		this.tileItemClassSettings.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.tileItemClassSettings.ItemAppearance.Disabled.Options.UseFont = true;
		this.tileItemClassSettings.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.tileItemClassSettings.ItemAppearance.Normal.Options.UseFont = true;
		this.tileItemClassSettings.Name = "tileItemClassSettings";
		this.tileItemClassSettings.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.tileItemClassSettings.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.tileItemClassSettings.Width = 120;
		this.lblTerm.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.lblTerm.Enabled = false;
		this.lblTerm.Id = 9;
		this.lblTerm.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.lblTerm.ItemAppearance.Disabled.Options.UseFont = true;
		this.lblTerm.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.lblTerm.ItemAppearance.Normal.Options.UseFont = true;
		this.lblTerm.Name = "lblTerm";
		this.lblTerm.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.lblTerm.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.lblTerm.Width = 180;
		this.lblSubject.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.lblSubject.Enabled = false;
		this.lblSubject.Id = 10;
		this.lblSubject.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.lblSubject.ItemAppearance.Disabled.Options.UseFont = true;
		this.lblSubject.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.lblSubject.ItemAppearance.Normal.Options.UseFont = true;
		this.lblSubject.Name = "lblSubject";
		this.lblSubject.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.lblSubject.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.lblSubject.Width = 180;
		this.skinDropDownButtonItem1.Id = 13;
		this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
		this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
		this.skinRibbonGalleryBarItem1.Gallery.AllowHoverImages = true;
		this.skinRibbonGalleryBarItem1.Gallery.ColumnCount = 4;
		this.skinRibbonGalleryBarItem1.Gallery.FixedHoverImageSize = false;
		this.skinRibbonGalleryBarItem1.Gallery.ImageSize = new System.Drawing.Size(16, 16);
		this.skinRibbonGalleryBarItem1.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleRadio;
		this.skinRibbonGalleryBarItem1.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.Squeeze;
		this.skinRibbonGalleryBarItem1.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
		skinPaddingEdges.Left = 8;
		skinPaddingEdges.Right = 8;
		this.skinRibbonGalleryBarItem1.Gallery.ItemImagePadding = skinPaddingEdges;
		this.skinRibbonGalleryBarItem1.Id = 14;
		this.skinRibbonGalleryBarItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("skinRibbonGalleryBarItem1.ImageOptions.SvgImage");
		this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
		this.skinDropDownButtonItem2.Id = 15;
		this.skinDropDownButtonItem2.Name = "skinDropDownButtonItem2";
		this.barStaticItem1.Caption = "Teacher >>";
		this.barStaticItem1.Id = 16;
		this.barStaticItem1.Name = "barStaticItem1";
		this.lblTeacher.Caption = "barStaticItem2";
		this.lblTeacher.Id = 17;
		this.lblTeacher.Name = "lblTeacher";
		this.lblIPAddress.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.lblIPAddress.Caption = "barStaticItem2";
		this.lblIPAddress.Id = 18;
		this.lblIPAddress.Name = "lblIPAddress";
		this.barStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
		this.barStaticItem2.Caption = "Local Address >>";
		this.barStaticItem2.Id = 19;
		this.barStaticItem2.Name = "barStaticItem2";
		this.lblStudentName.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.lblStudentName.Enabled = false;
		this.lblStudentName.Id = 21;
		this.lblStudentName.ItemAppearance.Disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.lblStudentName.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.lblStudentName.ItemAppearance.Disabled.Options.UseFont = true;
		this.lblStudentName.ItemAppearance.Disabled.Options.UseForeColor = true;
		this.lblStudentName.ItemAppearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.lblStudentName.ItemAppearance.Normal.Options.UseFont = true;
		this.lblStudentName.Name = "lblStudentName";
		this.lblStudentName.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.lblStudentName.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.lblStudentName.Width = 250;
		this.lblStudentNo.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.lblStudentNo.Enabled = false;
		this.lblStudentNo.Id = 22;
		this.lblStudentNo.ItemAppearance.Disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.lblStudentNo.ItemAppearance.Disabled.Options.UseFont = true;
		this.lblStudentNo.ItemAppearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.lblStudentNo.ItemAppearance.Normal.Options.UseFont = true;
		this.lblStudentNo.Name = "lblStudentNo";
		this.lblStudentNo.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.lblStudentNo.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.lblStudentNo.Width = 250;
		this.lblStudentID.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
		this.lblStudentID.Enabled = false;
		this.lblStudentID.Id = 23;
		this.lblStudentID.ItemAppearance.Disabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.lblStudentID.ItemAppearance.Disabled.Options.UseFont = true;
		this.lblStudentID.ItemAppearance.Normal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
		this.lblStudentID.ItemAppearance.Normal.Options.UseFont = true;
		this.lblStudentID.Name = "lblStudentID";
		this.lblStudentID.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
		this.lblStudentID.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.lblStudentID.Width = 250;
		this.barButtonItem8.Enabled = false;
		this.barButtonItem8.Id = 24;
		this.barButtonItem8.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem8.ImageOptions.Image");
		this.barButtonItem8.ImageOptions.LargeImage = (System.Drawing.Image)resources.GetObject("barButtonItem8.ImageOptions.LargeImage");
		this.barButtonItem8.Name = "barButtonItem8";
		this.barButtonItem8.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.All;
		this.barButtonItem8.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.False;
		this.barButtonItem9.Caption = "Signout";
		this.barButtonItem9.Id = 26;
		this.barButtonItem9.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("barButtonItem9.ImageOptions.Image");
		this.barButtonItem9.Name = "barButtonItem9";
		this.barButtonItem9.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
		this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItem9_ItemClick);
		this.ribbonPage1.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.ribbonPage1.Appearance.Options.UseFont = true;
		this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[8] { this.ribbonPageGroup1, this.ribbonPageGroup5, this.ribbonPageGroup4, this.ribbonPageGroup2, this.ribbonPageGroup7, this.ribbonPageGroup3, this.ribbonPageGroup8, this.ribbonPageGroup9 });
		this.ribbonPage1.Name = "ribbonPage1";
		this.ribbonPage1.Text = "Marks Entry";
		this.ribbonPageGroup1.AllowTextClipping = false;
		this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem5);
		this.ribbonPageGroup1.Name = "ribbonPageGroup1";
		this.ribbonPageGroup1.Text = "Home";
		this.ribbonPageGroup5.AllowTextClipping = false;
		this.ribbonPageGroup5.ItemLinks.Add(this.tileItemClassSettings);
		this.ribbonPageGroup5.ItemLinks.Add(this.lblSubject);
		this.ribbonPageGroup5.ItemLinks.Add(this.lblTerm);
		this.ribbonPageGroup5.Name = "ribbonPageGroup5";
		this.ribbonPageGroup5.Text = "Parameters";
		this.ribbonPageGroup4.AllowTextClipping = false;
		this.ribbonPageGroup4.ItemLinks.Add(this.lblStream);
		this.ribbonPageGroup4.Name = "ribbonPageGroup4";
		this.ribbonPageGroup4.Text = "Stream";
		this.ribbonPageGroup2.AllowTextClipping = false;
		this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
		this.ribbonPageGroup2.Name = "ribbonPageGroup2";
		this.ribbonPageGroup2.Text = "Student";
		this.ribbonPageGroup7.AllowTextClipping = false;
		this.ribbonPageGroup7.ItemLinks.Add(this.skinDropDownButtonItem2);
		this.ribbonPageGroup7.Name = "ribbonPageGroup7";
		this.ribbonPageGroup7.Text = "Appearance";
		this.ribbonPageGroup3.AllowTextClipping = false;
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2, true);
		this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem3);
		this.ribbonPageGroup3.Name = "ribbonPageGroup3";
		this.ribbonPageGroup3.Text = "Print";
		this.ribbonPageGroup8.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
		this.ribbonPageGroup8.AllowTextClipping = false;
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem4);
		this.ribbonPageGroup8.ItemLinks.Add(this.barButtonItem8, true);
		this.ribbonPageGroup8.ItemLinks.Add(this.lblStudentName, true);
		this.ribbonPageGroup8.ItemLinks.Add(this.lblStudentNo);
		this.ribbonPageGroup8.ItemLinks.Add(this.lblStudentID);
		this.ribbonPageGroup8.Name = "ribbonPageGroup8";
		this.ribbonPageGroup8.Text = "Student Information";
		this.ribbonPageGroup8.Visible = false;
		this.ribbonPageGroup9.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
		this.ribbonPageGroup9.AllowTextClipping = false;
		this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem9);
		this.ribbonPageGroup9.Name = "ribbonPageGroup9";
		this.ribbonPageGroup9.Text = "Signout";
		this.picStudentPicture.Name = "picStudentPicture";
		this.picStudentPicture.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblTeacher);
		this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
		this.ribbonStatusBar1.ItemLinks.Add(this.lblIPAddress);
		this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 671);
		this.ribbonStatusBar1.Name = "ribbonStatusBar1";
		this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
		this.ribbonStatusBar1.Size = new System.Drawing.Size(1322, 23);
		this.dgMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode.RelationName = "Level1";
		this.dgMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode });
		this.dgMain.Location = new System.Drawing.Point(0, 0);
		this.dgMain.MainView = this.bandedGridView1;
		this.dgMain.Margin = new System.Windows.Forms.Padding(2);
		this.dgMain.Name = "dgMain";
		this.dgMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemRibbonSearchEdit1 });
		this.dgMain.Size = new System.Drawing.Size(1318, 496);
		this.dgMain.TabIndex = 4;
		this.dgMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.bandedGridView1 });
		this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(dgMain_KeyDown);
		this.bandedGridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.bandedGridView1.Appearance.BandPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.BandPanel.Options.UseTextOptions = true;
		this.bandedGridView1.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridView1.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.BandPanelBackground.Options.UseFont = true;
		this.bandedGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.bandedGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.bandedGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.bandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.Empty.Options.UseFont = true;
		this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.Preview.Options.UseFont = true;
		this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.Row.Options.UseFont = true;
		this.bandedGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.VertLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.Options.UseBackColor = true;
		this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[4] { this.gridBand1, this.gridBand2, this.gridBand3, this.gridBand16 });
		this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[18]
		{
			this.bandedGridColumn1, this.bandedGridColumn2, this.bandedGridColumn3, this.bandedGridColumn4, this.bandedGridColumn5, this.colU1, this.colU2, this.colU3, this.colU4, this.colU5,
			this.bandedGridColumn16, this.bandedGridColumn17, this.bandedGridColumn18, this.bandedGridColumn11, this.bandedGridColumn37, this.bandedGridColumn46, this.bandedGridColumn50, this.bandedGridColumn51
		});
		this.bandedGridView1.DetailHeight = 239;
		styleFormatCondition.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition.Appearance.Options.UseForeColor = true;
		styleFormatCondition.ApplyToRow = true;
		styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition.Value1 = "F9";
		this.bandedGridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition });
		this.bandedGridView1.GridControl = this.dgMain;
		this.bandedGridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
		this.bandedGridView1.IndicatorWidth = 23;
		this.bandedGridView1.Name = "bandedGridView1";
		this.bandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsCustomization.AllowColumnMoving = false;
		this.bandedGridView1.OptionsCustomization.AllowFilter = false;
		this.bandedGridView1.OptionsCustomization.AllowGroup = false;
		this.bandedGridView1.OptionsCustomization.AllowSort = false;
		this.bandedGridView1.OptionsFilter.AllowColumnMRUFilterList = false;
		this.bandedGridView1.OptionsFilter.AllowFilterEditor = false;
		this.bandedGridView1.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.bandedGridView1.OptionsFilter.AllowMRUFilterList = false;
		this.bandedGridView1.OptionsPrint.PrintFilterInfo = true;
		this.bandedGridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.bandedGridView1.OptionsView.ShowGroupPanel = false;
		this.bandedGridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsView.ShowIndicator = false;
		this.bandedGridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.bandedGridView1.RowHeight = 17;
		this.bandedGridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(bandedGridView1_RowClick);
		this.bandedGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(bandedGridView1_FocusedRowChanged);
		this.bandedGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(bandedGridView1_CellValueChanged);
		this.bandedGridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(bandedGridView1_CustomColumnDisplayText_1);
		this.bandedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(bandedGridView1_KeyDown);
		this.bandedGridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(bandedGridView1_ValidatingEditor);
		this.bandedGridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(bandedGridView1_InvalidValueException);
		this.bandedGridColumn1.Caption = "#";
		this.bandedGridColumn1.MinWidth = 27;
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn1.Visible = true;
		this.bandedGridColumn1.Width = 32;
		this.bandedGridColumn2.Caption = "Name";
		this.bandedGridColumn2.FieldName = "fullName";
		this.bandedGridColumn2.MinWidth = 200;
		this.bandedGridColumn2.Name = "bandedGridColumn2";
		this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn2.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn2.Visible = true;
		this.bandedGridColumn2.Width = 240;
		this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn4.Caption = "Sex";
		this.bandedGridColumn4.FieldName = "Sex";
		this.bandedGridColumn4.MinWidth = 100;
		this.bandedGridColumn4.Name = "bandedGridColumn4";
		this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn4.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn4.Visible = true;
		this.bandedGridColumn4.Width = 134;
		this.bandedGridColumn3.Caption = "Stud#";
		this.bandedGridColumn3.FieldName = "StudentNumber";
		this.bandedGridColumn3.MinWidth = 100;
		this.bandedGridColumn3.Name = "bandedGridColumn3";
		this.bandedGridColumn3.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn3.Visible = true;
		this.bandedGridColumn3.Width = 120;
		this.bandedGridColumn5.Caption = "Stream";
		this.bandedGridColumn5.FieldName = "StreamId";
		this.bandedGridColumn5.MinWidth = 70;
		this.bandedGridColumn5.Name = "bandedGridColumn5";
		this.bandedGridColumn5.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn5.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn5.Visible = true;
		this.bandedGridColumn5.Width = 88;
		this.colU1.AppearanceCell.Options.UseTextOptions = true;
		this.colU1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU1.AppearanceHeader.Options.UseTextOptions = true;
		this.colU1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU1.Caption = "C1";
		this.colU1.DisplayFormat.FormatString = "{0:f1}";
		this.colU1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU1.FieldName = "U1";
		this.colU1.MinWidth = 33;
		this.colU1.Name = "colU1";
		this.colU1.Visible = true;
		this.colU1.Width = 50;
		this.colU2.AppearanceCell.Options.UseTextOptions = true;
		this.colU2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU2.AppearanceHeader.Options.UseTextOptions = true;
		this.colU2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU2.Caption = "C2";
		this.colU2.DisplayFormat.FormatString = "{0:f1}";
		this.colU2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU2.FieldName = "U2";
		this.colU2.MinWidth = 33;
		this.colU2.Name = "colU2";
		this.colU2.Visible = true;
		this.colU2.Width = 50;
		this.colU3.AppearanceCell.Options.UseTextOptions = true;
		this.colU3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU3.AppearanceHeader.Options.UseTextOptions = true;
		this.colU3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU3.Caption = "C3";
		this.colU3.DisplayFormat.FormatString = "{0:f1}";
		this.colU3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU3.FieldName = "U3";
		this.colU3.MinWidth = 33;
		this.colU3.Name = "colU3";
		this.colU3.Visible = true;
		this.colU3.Width = 50;
		this.colU4.AppearanceCell.Options.UseTextOptions = true;
		this.colU4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU4.Caption = "C4";
		this.colU4.DisplayFormat.FormatString = "{0:f1}";
		this.colU4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU4.FieldName = "U4";
		this.colU4.Name = "colU4";
		this.colU4.Visible = true;
		this.colU4.Width = 50;
		this.bandedGridColumn16.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn16.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn16.Caption = "Total";
		this.bandedGridColumn16.FieldName = "TTLPoints";
		this.bandedGridColumn16.MinWidth = 40;
		this.bandedGridColumn16.Name = "bandedGridColumn16";
		this.bandedGridColumn16.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn16.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn16.Width = 40;
		this.bandedGridColumn17.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn17.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn17.Caption = "Av. Mark";
		this.bandedGridColumn17.FieldName = "AvLO";
		this.bandedGridColumn17.MinWidth = 40;
		this.bandedGridColumn17.Name = "bandedGridColumn17";
		this.bandedGridColumn17.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn17.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn17.Visible = true;
		this.bandedGridColumn17.Width = 40;
		this.bandedGridColumn46.Caption = "Generic Skills";
		this.bandedGridColumn46.ColumnEdit = this.repositoryItemRibbonSearchEdit1;
		this.bandedGridColumn46.FieldName = "GenericSkills";
		this.bandedGridColumn46.Name = "bandedGridColumn46";
		this.bandedGridColumn46.Visible = true;
		this.bandedGridColumn46.Width = 422;
		this.repositoryItemRibbonSearchEdit1.AutoHeight = false;
		editorButtonImageOptions.Image = (System.Drawing.Image)resources.GetObject("editorButtonImageOptions1.Image");
		this.repositoryItemRibbonSearchEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), appearance, appearanceHovered, appearancePressed, appearanceDisabled, "Select from storage", null, null, DevExpress.Utils.ToolTipAnchor.Default)
		});
		this.repositoryItemRibbonSearchEdit1.Name = "repositoryItemRibbonSearchEdit1";
		this.repositoryItemRibbonSearchEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemRibbonSearchEdit1_ButtonClick);
		this.bandedGridColumn18.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn18.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn18.Caption = "TUnits";
		this.bandedGridColumn18.FieldName = "TUnits";
		this.bandedGridColumn18.MinWidth = 67;
		this.bandedGridColumn18.Name = "bandedGridColumn18";
		this.bandedGridColumn18.Visible = true;
		this.bandedGridColumn18.Width = 252;
		this.bandedGridColumn11.Caption = "ETA";
		this.bandedGridColumn11.FieldName = "ETA";
		this.bandedGridColumn11.Name = "bandedGridColumn11";
		this.bandedGridColumn37.Caption = "ETA80";
		this.bandedGridColumn37.FieldName = "ETA80";
		this.bandedGridColumn37.Name = "bandedGridColumn37";
		this.bandedGridColumn50.Caption = "Sex";
		this.bandedGridColumn50.FieldName = "Sex";
		this.bandedGridColumn50.Name = "bandedGridColumn50";
		this.bandedGridColumn51.Caption = "ETA80";
		this.bandedGridColumn51.FieldName = "ETA80";
		this.bandedGridColumn51.Name = "bandedGridColumn51";
		this.tmUpdate.Interval = 1000;
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
		this.printableComponentLink1.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
		this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
		this.timer1.Enabled = true;
		this.popupMenu1.Name = "popupMenu1";
		this.popupMenu1.Ribbon = this.ribbonControl1;
		this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
		this.flyoutPanel1.Location = new System.Drawing.Point(11, 147);
		this.flyoutPanel1.Margin = new System.Windows.Forms.Padding(2);
		this.flyoutPanel1.Name = "flyoutPanel1";
		this.flyoutPanel1.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
		this.flyoutPanel1.OptionsButtonPanel.AppearanceButton.Normal.Font = new System.Drawing.Font("Tahoma", 12f);
		this.flyoutPanel1.OptionsButtonPanel.AppearanceButton.Normal.Options.UseFont = true;
		this.flyoutPanel1.OptionsButtonPanel.ButtonPanelContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
		this.flyoutPanel1.OptionsButtonPanel.ButtonPanelHeight = 34;
		this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
		buttonImageOptions.Image = (System.Drawing.Image)resources.GetObject("buttonImageOptions1.Image");
		buttonImageOptions2.Image = (System.Drawing.Image)resources.GetObject("buttonImageOptions2.Image");
		this.flyoutPanel1.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[2]
		{
			new DevExpress.Utils.PeekFormButton("Register", true, buttonImageOptions, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
			new DevExpress.Utils.PeekFormButton("Cancel", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)
		});
		this.flyoutPanel1.OptionsButtonPanel.ShowButtonPanel = true;
		this.flyoutPanel1.OwnerControl = this;
		this.flyoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 34);
		this.flyoutPanel1.ParentForm = this;
		this.flyoutPanel1.Size = new System.Drawing.Size(575, 109);
		this.flyoutPanel1.TabIndex = 5;
		this.flyoutPanel1.ButtonClick += new DevExpress.Utils.FlyoutPanelButtonClickEventHandler(flyoutPanel1_ButtonClick);
		this.flyoutPanelControl1.Controls.Add(this.gridControl1);
		this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
		this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
		this.flyoutPanelControl1.Margin = new System.Windows.Forms.Padding(2);
		this.flyoutPanelControl1.Name = "flyoutPanelControl1";
		this.flyoutPanelControl1.Size = new System.Drawing.Size(575, 75);
		this.flyoutPanelControl1.TabIndex = 0;
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(571, 71);
		this.gridControl1.TabIndex = 0;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.DetailTip.Options.UseFont = true;
		this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Empty.Options.UseFont = true;
		this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.EvenRow.Options.UseFont = true;
		this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FixedLine.Options.UseFont = true;
		this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupButton.Options.UseFont = true;
		this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.GroupRow.Options.UseFont = true;
		this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.HorzLine.Options.UseFont = true;
		this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.OddRow.Options.UseFont = true;
		this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Preview.Options.UseFont = true;
		this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.Row.Options.UseFont = true;
		this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.VertLine.Options.UseFont = true;
		this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.gridColumn1, this.gridColumn2, this.gridColumn3 });
		this.gridView1.DetailHeight = 239;
		this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.gridView1.OptionsBehavior.Editable = false;
		this.gridView1.OptionsFind.ShowFindButton = false;
		this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView1.OptionsSelection.MultiSelect = true;
		this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
		this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
		this.gridView1.OptionsView.ShowGroupPanel = false;
		this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView1.OptionsView.ShowIndicator = false;
		this.gridColumn1.Caption = "Name";
		this.gridColumn1.FieldName = "fullName";
		this.gridColumn1.MinWidth = 13;
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn1.Visible = true;
		this.gridColumn1.VisibleIndex = 1;
		this.gridColumn1.Width = 50;
		this.gridColumn2.Caption = "Student No.";
		this.gridColumn2.FieldName = "StudentNumber";
		this.gridColumn2.MinWidth = 13;
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn2.Visible = true;
		this.gridColumn2.VisibleIndex = 3;
		this.gridColumn2.Width = 50;
		this.gridColumn3.Caption = "Stream";
		this.gridColumn3.FieldName = "StreamId";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn3.Visible = true;
		this.gridColumn3.VisibleIndex = 2;
		this.navigationFrame1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.navigationFrame1.Controls.Add(this.navPageLO);
		this.navigationFrame1.Controls.Add(this.navPage20);
		this.navigationFrame1.Controls.Add(this.navPage100);
		this.navigationFrame1.Controls.Add(this.navPageEOT);
		this.navigationFrame1.Controls.Add(this.navPage10);
		this.navigationFrame1.Controls.Add(this.navPageHome);
		this.navigationFrame1.Controls.Add(this.navPageDescr);
		this.navigationFrame1.Controls.Add(this.navPageOtherComp);
		this.navigationFrame1.Controls.Add(this.navPageCompetence);
		this.navigationFrame1.Location = new System.Drawing.Point(2, 26);
		this.navigationFrame1.Margin = new System.Windows.Forms.Padding(2);
		this.navigationFrame1.Name = "navigationFrame1";
		this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[9] { this.navPageHome, this.navPageLO, this.navPage10, this.navPage20, this.navPage100, this.navPageEOT, this.navPageDescr, this.navPageOtherComp, this.navPageCompetence });
		this.navigationFrame1.SelectedPage = this.navPageHome;
		this.navigationFrame1.Size = new System.Drawing.Size(1318, 496);
		this.navigationFrame1.TabIndex = 6;
		this.navigationFrame1.Text = "navigationFrame1";
		this.navigationFrame1.TransitionType = DevExpress.Utils.Animation.Transitions.Shape;
		this.navigationFrame1.SelectedPageIndexChanged += new System.EventHandler(navigationFrame1_SelectedPageIndexChanged);
		this.navPageLO.AutoSize = true;
		this.navPageLO.BackgroundPadding = new System.Windows.Forms.Padding(8);
		this.navPageLO.Controls.Add(this.flyoutPanel3);
		this.navPageLO.Controls.Add(this.dgMain);
		this.navPageLO.Margin = new System.Windows.Forms.Padding(2);
		this.navPageLO.Name = "navPageLO";
		this.navPageLO.Size = new System.Drawing.Size(1318, 496);
		toolTipTitleItem.Text = "Learning Outcomes";
		toolTipItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		toolTipItem.Text = "Enter marks as learning outcomes computed on a scale of 3";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.navPageLO.SuperTip = superToolTip;
		this.flyoutPanel3.Controls.Add(this.flyoutPanelControl3);
		this.flyoutPanel3.Location = new System.Drawing.Point(31, 25);
		this.flyoutPanel3.Name = "flyoutPanel3";
		this.flyoutPanel3.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
		buttonImageOptions3.Image = (System.Drawing.Image)resources.GetObject("buttonImageOptions3.Image");
		this.flyoutPanel3.OptionsButtonPanel.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[1]
		{
			new DevExpress.Utils.PeekFormButton("X", false, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Close", -1, true, null, true, false, true, null, -1, false)
		});
		this.flyoutPanel3.OptionsButtonPanel.ShowButtonPanel = true;
		this.flyoutPanel3.OwnerControl = this;
		this.flyoutPanel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
		this.flyoutPanel3.Size = new System.Drawing.Size(682, 402);
		this.flyoutPanel3.TabIndex = 5;
		this.flyoutPanel3.ButtonClick += new DevExpress.Utils.FlyoutPanelButtonClickEventHandler(flyoutPanel3_ButtonClick);
		this.flyoutPanelControl3.Controls.Add(this.gridControl2);
		this.flyoutPanelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.flyoutPanelControl3.FlyoutPanel = this.flyoutPanel3;
		this.flyoutPanelControl3.Location = new System.Drawing.Point(0, 0);
		this.flyoutPanelControl3.Name = "flyoutPanelControl3";
		this.flyoutPanelControl3.Size = new System.Drawing.Size(682, 372);
		this.flyoutPanelControl3.TabIndex = 0;
		this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl2.Location = new System.Drawing.Point(2, 2);
		this.gridControl2.MainView = this.gridView6;
		this.gridControl2.MenuManager = this.ribbonControl1;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(678, 368);
		this.gridControl2.TabIndex = 0;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView6 });
		this.gridView6.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gridView6.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gridView6.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gridView6.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.DetailTip.Options.UseFont = true;
		this.gridView6.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.Empty.Options.UseFont = true;
		this.gridView6.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.EvenRow.Options.UseFont = true;
		this.gridView6.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gridView6.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView6.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.FixedLine.Options.UseFont = true;
		this.gridView6.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView6.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView6.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView6.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.GroupButton.Options.UseFont = true;
		this.gridView6.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView6.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.GroupPanel.Options.UseFont = true;
		this.gridView6.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.GroupRow.Options.UseFont = true;
		this.gridView6.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView6.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView6.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.HorzLine.Options.UseFont = true;
		this.gridView6.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gridView6.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.OddRow.Options.UseFont = true;
		this.gridView6.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.Preview.Options.UseFont = true;
		this.gridView6.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.Row.Options.UseFont = true;
		this.gridView6.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.RowSeparator.Options.UseFont = true;
		this.gridView6.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView6.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView6.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.VertLine.Options.UseFont = true;
		this.gridView6.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 12f);
		this.gridView6.Appearance.ViewCaption.Options.UseFont = true;
		this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn12, this.gridColumn13 });
		this.gridView6.GridControl = this.gridControl2;
		this.gridView6.GroupCount = 1;
		this.gridView6.GroupFormat = "{1} {2}";
		this.gridView6.Name = "gridView6";
		this.gridView6.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView6.OptionsBehavior.Editable = false;
		this.gridView6.OptionsCustomization.AllowColumnMoving = false;
		this.gridView6.OptionsFind.AlwaysVisible = true;
		this.gridView6.OptionsView.RowAutoHeight = true;
		this.gridView6.OptionsView.ShowGroupPanel = false;
		this.gridView6.OptionsView.ShowIndicator = false;
		this.gridView6.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[1]
		{
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)
		});
		this.gridView6.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView6_RowClick);
		this.gridView6.DoubleClick += new System.EventHandler(gridView6_DoubleClick);
		this.gridColumn12.Caption = "Group";
		this.gridColumn12.FieldName = "Group";
		this.gridColumn12.Name = "gridColumn12";
		this.gridColumn12.Visible = true;
		this.gridColumn12.VisibleIndex = 0;
		this.gridColumn13.Caption = "Remark";
		this.gridColumn13.FieldName = "Remark";
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn13.Visible = true;
		this.gridColumn13.VisibleIndex = 0;
		this.navPage20.AutoSize = true;
		this.navPage20.Controls.Add(this.dgMain20);
		this.navPage20.Margin = new System.Windows.Forms.Padding(2);
		this.navPage20.Name = "navPage20";
		this.navPage20.Size = new System.Drawing.Size(1318, 496);
		toolTipTitleItem2.Text = "Scores out- of 20";
		toolTipItem2.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image1");
		toolTipItem2.Text = "Enter marks as scores computed on a scale of 20";
		superToolTip2.Items.Add(toolTipTitleItem2);
		superToolTip2.Items.Add(toolTipItem2);
		this.navPage20.SuperTip = superToolTip2;
		this.dgMain20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain20.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode2.RelationName = "Level1";
		this.dgMain20.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode2 });
		this.dgMain20.Location = new System.Drawing.Point(0, 0);
		this.dgMain20.MainView = this.gv20;
		this.dgMain20.Margin = new System.Windows.Forms.Padding(2);
		this.dgMain20.Name = "dgMain20";
		this.dgMain20.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit2 });
		this.dgMain20.Size = new System.Drawing.Size(1318, 496);
		this.dgMain20.TabIndex = 5;
		this.dgMain20.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gv20 });
		this.gv20.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gv20.Appearance.BandPanel.Options.UseFont = true;
		this.gv20.Appearance.BandPanel.Options.UseTextOptions = true;
		this.gv20.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gv20.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.BandPanelBackground.Options.UseFont = true;
		this.gv20.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv20.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gv20.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv20.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gv20.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gv20.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.DetailTip.Options.UseFont = true;
		this.gv20.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.Empty.Options.UseFont = true;
		this.gv20.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.EvenRow.Options.UseFont = true;
		this.gv20.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv20.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gv20.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.FilterPanel.Options.UseFont = true;
		this.gv20.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.FixedLine.Options.UseFont = true;
		this.gv20.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.FocusedCell.Options.UseFont = true;
		this.gv20.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.FocusedRow.Options.UseFont = true;
		this.gv20.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv20.Appearance.FooterPanel.Options.UseFont = true;
		this.gv20.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.GroupButton.Options.UseFont = true;
		this.gv20.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.GroupFooter.Options.UseFont = true;
		this.gv20.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.GroupPanel.Options.UseFont = true;
		this.gv20.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.GroupRow.Options.UseFont = true;
		this.gv20.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.gv20.Appearance.HeaderPanel.Options.UseFont = true;
		this.gv20.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.gv20.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gv20.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.HorzLine.Options.UseFont = true;
		this.gv20.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.OddRow.Options.UseFont = true;
		this.gv20.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.Preview.Options.UseFont = true;
		this.gv20.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.Row.Options.UseFont = true;
		this.gv20.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.RowSeparator.Options.UseFont = true;
		this.gv20.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.SelectedRow.Options.UseFont = true;
		this.gv20.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.TopNewRow.Options.UseFont = true;
		this.gv20.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.VertLine.Options.UseFont = true;
		this.gv20.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv20.Appearance.ViewCaption.Options.UseFont = true;
		this.gv20.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.gv20.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.gv20.AppearancePrint.Preview.Options.UseBackColor = true;
		this.gv20.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[4] { this.gridBand4, this.gridBand5, this.gridBand6, this.gridBand18 });
		this.gv20.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[14]
		{
			this.bandedGridColumn6, this.bandedGridColumn7, this.bandedGridColumn8, this.bandedGridColumn9, this.bandedGridColumn10, this.colScore1, this.colScore2, this.colScore3, this.colScore4, this.colScore5,
			this.bandedGridColumn24, this.bandedGridColumn26, this.bandedGridColumn39, this.bandedGridColumn48
		});
		this.gv20.DetailHeight = 239;
		styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition2.Appearance.Options.UseForeColor = true;
		styleFormatCondition2.ApplyToRow = true;
		styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition2.Value1 = "F9";
		this.gv20.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition2 });
		this.gv20.GridControl = this.dgMain20;
		this.gv20.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
		this.gv20.IndicatorWidth = 23;
		this.gv20.Name = "gv20";
		this.gv20.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv20.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv20.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gv20.OptionsCustomization.AllowColumnMoving = false;
		this.gv20.OptionsCustomization.AllowFilter = false;
		this.gv20.OptionsCustomization.AllowGroup = false;
		this.gv20.OptionsCustomization.AllowSort = false;
		this.gv20.OptionsFilter.AllowColumnMRUFilterList = false;
		this.gv20.OptionsFilter.AllowFilterEditor = false;
		this.gv20.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.gv20.OptionsFilter.AllowMRUFilterList = false;
		this.gv20.OptionsPrint.PrintFilterInfo = true;
		this.gv20.OptionsView.EnableAppearanceEvenRow = true;
		this.gv20.OptionsView.ShowGroupPanel = false;
		this.gv20.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gv20.OptionsView.ShowIndicator = false;
		this.gv20.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gv20.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gv20.RowHeight = 17;
		this.gv20.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gv20_RowClick);
		this.gv20.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gv20_FocusedRowChanged);
		this.gv20.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gv20_CellValueChanged);
		this.gv20.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gv20_CustomColumnDisplayText);
		this.gv20.KeyDown += new System.Windows.Forms.KeyEventHandler(gv20_KeyDown);
		this.gv20.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gv20_ValidatingEditor);
		this.gv20.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gv20_InvalidValueException);
		this.bandedGridColumn6.Caption = "#";
		this.bandedGridColumn6.MinWidth = 40;
		this.bandedGridColumn6.Name = "bandedGridColumn6";
		this.bandedGridColumn6.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn6.Visible = true;
		this.bandedGridColumn6.Width = 42;
		this.bandedGridColumn7.Caption = "Name";
		this.bandedGridColumn7.FieldName = "fullName";
		this.bandedGridColumn7.MinWidth = 300;
		this.bandedGridColumn7.Name = "bandedGridColumn7";
		this.bandedGridColumn7.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn7.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn7.Visible = true;
		this.bandedGridColumn7.Width = 318;
		this.bandedGridColumn8.Caption = "Stud#";
		this.bandedGridColumn8.FieldName = "StudentNumber";
		this.bandedGridColumn8.MinWidth = 170;
		this.bandedGridColumn8.Name = "bandedGridColumn8";
		this.bandedGridColumn8.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn8.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn8.Visible = true;
		this.bandedGridColumn8.Width = 180;
		this.bandedGridColumn9.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn9.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn9.Caption = "Sex";
		this.bandedGridColumn9.FieldName = "Sex";
		this.bandedGridColumn9.MinWidth = 150;
		this.bandedGridColumn9.Name = "bandedGridColumn9";
		this.bandedGridColumn9.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn9.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn9.Width = 276;
		this.bandedGridColumn10.Caption = "Stream";
		this.bandedGridColumn10.FieldName = "StreamId";
		this.bandedGridColumn10.MinWidth = 70;
		this.bandedGridColumn10.Name = "bandedGridColumn10";
		this.bandedGridColumn10.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn10.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn10.Visible = true;
		this.colScore1.AppearanceCell.Options.UseTextOptions = true;
		this.colScore1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore1.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore1.Caption = "C1";
		this.colScore1.FieldName = "Score1";
		this.colScore1.MinWidth = 50;
		this.colScore1.Name = "colScore1";
		this.colScore1.Visible = true;
		this.colScore1.Width = 52;
		this.colScore2.AppearanceCell.Options.UseTextOptions = true;
		this.colScore2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore2.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore2.Caption = "C2";
		this.colScore2.FieldName = "Score2";
		this.colScore2.MinWidth = 50;
		this.colScore2.Name = "colScore2";
		this.colScore2.Visible = true;
		this.colScore2.Width = 52;
		this.colScore3.AppearanceCell.Options.UseTextOptions = true;
		this.colScore3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore3.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore3.Caption = "C3";
		this.colScore3.FieldName = "Score3";
		this.colScore3.MinWidth = 50;
		this.colScore3.Name = "colScore3";
		this.colScore3.Visible = true;
		this.colScore3.Width = 52;
		this.colScore4.AppearanceCell.Options.UseTextOptions = true;
		this.colScore4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore4.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore4.Caption = "C4";
		this.colScore4.FieldName = "Score4";
		this.colScore4.Name = "colScore4";
		this.colScore4.Visible = true;
		this.colScore4.Width = 50;
		this.bandedGridColumn24.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn24.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn24.Caption = "AVG. Score";
		this.bandedGridColumn24.FieldName = "OutOfTwenty";
		this.bandedGridColumn24.MinWidth = 60;
		this.bandedGridColumn24.Name = "bandedGridColumn24";
		this.bandedGridColumn24.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn24.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn24.Visible = true;
		this.bandedGridColumn24.Width = 254;
		this.bandedGridColumn48.Caption = "Generic Skills";
		this.bandedGridColumn48.FieldName = "GenericSkills";
		this.bandedGridColumn48.Name = "bandedGridColumn48";
		this.bandedGridColumn48.Visible = true;
		this.bandedGridColumn48.Width = 241;
		this.bandedGridColumn26.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn26.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn26.Caption = "TUnits";
		this.bandedGridColumn26.FieldName = "TUnits";
		this.bandedGridColumn26.MinWidth = 60;
		this.bandedGridColumn26.Name = "bandedGridColumn26";
		this.bandedGridColumn26.Visible = true;
		this.bandedGridColumn26.Width = 378;
		this.bandedGridColumn39.Caption = "ETA80";
		this.bandedGridColumn39.FieldName = "ETA80";
		this.bandedGridColumn39.Name = "bandedGridColumn39";
		this.repositoryItemGridLookUpEdit2.AutoHeight = false;
		this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
		this.repositoryItemGridLookUpEdit2.PopupView = this.gridView2;
		this.gridView2.DetailHeight = 239;
		this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.navPage100.AutoSize = true;
		this.navPage100.Controls.Add(this.dgMain100);
		this.navPage100.Margin = new System.Windows.Forms.Padding(2);
		this.navPage100.Name = "navPage100";
		this.navPage100.Size = new System.Drawing.Size(1318, 496);
		toolTipTitleItem3.Text = "Scores out-of 100";
		toolTipItem3.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image2");
		toolTipItem3.Text = "Enter marks as scores computed on a scale of 100%";
		superToolTip3.Items.Add(toolTipTitleItem3);
		superToolTip3.Items.Add(toolTipItem3);
		this.navPage100.SuperTip = superToolTip3;
		this.dgMain100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain100.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode3.RelationName = "Level1";
		this.dgMain100.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode3 });
		this.dgMain100.Location = new System.Drawing.Point(0, 0);
		this.dgMain100.MainView = this.gv100;
		this.dgMain100.Margin = new System.Windows.Forms.Padding(2);
		this.dgMain100.Name = "dgMain100";
		this.dgMain100.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit3 });
		this.dgMain100.Size = new System.Drawing.Size(1318, 496);
		this.dgMain100.TabIndex = 5;
		this.dgMain100.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gv100 });
		this.gv100.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gv100.Appearance.BandPanel.Options.UseFont = true;
		this.gv100.Appearance.BandPanel.Options.UseTextOptions = true;
		this.gv100.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gv100.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.BandPanelBackground.Options.UseFont = true;
		this.gv100.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv100.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gv100.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv100.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gv100.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gv100.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.DetailTip.Options.UseFont = true;
		this.gv100.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.Empty.Options.UseFont = true;
		this.gv100.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.EvenRow.Options.UseFont = true;
		this.gv100.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv100.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gv100.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.FilterPanel.Options.UseFont = true;
		this.gv100.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.FixedLine.Options.UseFont = true;
		this.gv100.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.FocusedCell.Options.UseFont = true;
		this.gv100.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.FocusedRow.Options.UseFont = true;
		this.gv100.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv100.Appearance.FooterPanel.Options.UseFont = true;
		this.gv100.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.GroupButton.Options.UseFont = true;
		this.gv100.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.GroupFooter.Options.UseFont = true;
		this.gv100.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.GroupPanel.Options.UseFont = true;
		this.gv100.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.GroupRow.Options.UseFont = true;
		this.gv100.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.gv100.Appearance.HeaderPanel.Options.UseFont = true;
		this.gv100.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.gv100.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gv100.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.HorzLine.Options.UseFont = true;
		this.gv100.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.OddRow.Options.UseFont = true;
		this.gv100.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.Preview.Options.UseFont = true;
		this.gv100.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.Row.Options.UseFont = true;
		this.gv100.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.RowSeparator.Options.UseFont = true;
		this.gv100.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.SelectedRow.Options.UseFont = true;
		this.gv100.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.TopNewRow.Options.UseFont = true;
		this.gv100.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.VertLine.Options.UseFont = true;
		this.gv100.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv100.Appearance.ViewCaption.Options.UseFont = true;
		this.gv100.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.gv100.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.gv100.AppearancePrint.Preview.Options.UseBackColor = true;
		this.gv100.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[4] { this.gridBand7, this.gridBand8, this.gridBand9, this.gridBand19 });
		this.gv100.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[16]
		{
			this.bandedGridColumn27, this.bandedGridColumn28, this.bandedGridColumn29, this.bandedGridColumn30, this.bandedGridColumn31, this.colHund1, this.colHund2, this.colHund3, this.colHund4, this.colHund5,
			this.bandedGridColumn42, this.bandedGridColumn44, this.bandedGridColumn12, this.bandedGridColumn13, this.bandedGridColumn45, this.bandedGridColumn49
		});
		this.gv100.DetailHeight = 239;
		styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition3.Appearance.Options.UseForeColor = true;
		styleFormatCondition3.ApplyToRow = true;
		styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition3.Value1 = "F9";
		this.gv100.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition3 });
		this.gv100.GridControl = this.dgMain100;
		this.gv100.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
		this.gv100.IndicatorWidth = 23;
		this.gv100.Name = "gv100";
		this.gv100.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv100.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv100.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gv100.OptionsCustomization.AllowColumnMoving = false;
		this.gv100.OptionsCustomization.AllowFilter = false;
		this.gv100.OptionsCustomization.AllowGroup = false;
		this.gv100.OptionsCustomization.AllowSort = false;
		this.gv100.OptionsFilter.AllowColumnMRUFilterList = false;
		this.gv100.OptionsFilter.AllowFilterEditor = false;
		this.gv100.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.gv100.OptionsFilter.AllowMRUFilterList = false;
		this.gv100.OptionsPrint.PrintFilterInfo = true;
		this.gv100.OptionsView.EnableAppearanceEvenRow = true;
		this.gv100.OptionsView.ShowGroupPanel = false;
		this.gv100.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gv100.OptionsView.ShowIndicator = false;
		this.gv100.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gv100.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gv100.RowHeight = 17;
		this.gv100.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gv100_RowClick);
		this.gv100.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gv100_FocusedRowChanged);
		this.gv100.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gv100_CellValueChanged);
		this.gv100.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gv100_CustomColumnDisplayText);
		this.gv100.KeyDown += new System.Windows.Forms.KeyEventHandler(gv100_KeyDown);
		this.gv100.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gv100_ValidatingEditor);
		this.gv100.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gv100_InvalidValueException);
		this.bandedGridColumn27.Caption = "#";
		this.bandedGridColumn27.MinWidth = 40;
		this.bandedGridColumn27.Name = "bandedGridColumn27";
		this.bandedGridColumn27.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn27.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn27.Visible = true;
		this.bandedGridColumn27.Width = 52;
		this.bandedGridColumn28.Caption = "Name";
		this.bandedGridColumn28.FieldName = "fullName";
		this.bandedGridColumn28.MinWidth = 200;
		this.bandedGridColumn28.Name = "bandedGridColumn28";
		this.bandedGridColumn28.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn28.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn28.Visible = true;
		this.bandedGridColumn28.Width = 264;
		this.bandedGridColumn29.Caption = "Stud#";
		this.bandedGridColumn29.FieldName = "StudentNumber";
		this.bandedGridColumn29.MinWidth = 80;
		this.bandedGridColumn29.Name = "bandedGridColumn29";
		this.bandedGridColumn29.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn29.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn29.Visible = true;
		this.bandedGridColumn29.Width = 105;
		this.bandedGridColumn30.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn30.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn30.Caption = "Sex";
		this.bandedGridColumn30.FieldName = "Sex";
		this.bandedGridColumn30.MinWidth = 337;
		this.bandedGridColumn30.Name = "bandedGridColumn30";
		this.bandedGridColumn30.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn30.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn30.Width = 621;
		this.bandedGridColumn31.Caption = "Stream";
		this.bandedGridColumn31.FieldName = "StreamId";
		this.bandedGridColumn31.MinWidth = 70;
		this.bandedGridColumn31.Name = "bandedGridColumn31";
		this.bandedGridColumn31.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn31.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn31.Visible = true;
		this.bandedGridColumn31.Width = 94;
		this.colHund1.AppearanceCell.Options.UseTextOptions = true;
		this.colHund1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund1.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund1.Caption = "C1";
		this.colHund1.FieldName = "Hund1";
		this.colHund1.MinWidth = 33;
		this.colHund1.Name = "colHund1";
		this.colHund1.Visible = true;
		this.colHund1.Width = 50;
		this.colHund2.AppearanceCell.Options.UseTextOptions = true;
		this.colHund2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund2.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund2.Caption = "C2";
		this.colHund2.FieldName = "Hund2";
		this.colHund2.MinWidth = 33;
		this.colHund2.Name = "colHund2";
		this.colHund2.Visible = true;
		this.colHund2.Width = 50;
		this.colHund3.AppearanceCell.Options.UseTextOptions = true;
		this.colHund3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund3.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund3.Caption = "C3";
		this.colHund3.FieldName = "Hund3";
		this.colHund3.MinWidth = 33;
		this.colHund3.Name = "colHund3";
		this.colHund3.Visible = true;
		this.colHund3.Width = 50;
		this.colHund4.AppearanceCell.Options.UseTextOptions = true;
		this.colHund4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund4.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund4.Caption = "C4";
		this.colHund4.FieldName = "Hund4";
		this.colHund4.Name = "colHund4";
		this.colHund4.Visible = true;
		this.colHund4.Width = 50;
		this.bandedGridColumn42.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn42.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn42.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn42.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn42.Caption = "Av. Score";
		this.bandedGridColumn42.FieldName = "OutOfHund";
		this.bandedGridColumn42.MinWidth = 40;
		this.bandedGridColumn42.Name = "bandedGridColumn42";
		this.bandedGridColumn42.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn42.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn42.Visible = true;
		this.bandedGridColumn42.Width = 263;
		this.bandedGridColumn49.Caption = "Generic Skills";
		this.bandedGridColumn49.FieldName = "GenericSkills";
		this.bandedGridColumn49.Name = "bandedGridColumn49";
		this.bandedGridColumn49.Visible = true;
		this.bandedGridColumn49.Width = 338;
		this.bandedGridColumn44.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn44.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn44.Caption = "TUnits";
		this.bandedGridColumn44.FieldName = "TUnits";
		this.bandedGridColumn44.MinWidth = 40;
		this.bandedGridColumn44.Name = "bandedGridColumn44";
		this.bandedGridColumn44.Visible = true;
		this.bandedGridColumn44.Width = 850;
		this.bandedGridColumn12.Caption = "AvMark";
		this.bandedGridColumn12.FieldName = "AvMark";
		this.bandedGridColumn12.Name = "bandedGridColumn12";
		this.bandedGridColumn13.Caption = "ETA";
		this.bandedGridColumn13.FieldName = "ETA";
		this.bandedGridColumn13.Name = "bandedGridColumn13";
		this.bandedGridColumn45.Caption = "ETA80";
		this.bandedGridColumn45.FieldName = "ETA80";
		this.bandedGridColumn45.Name = "bandedGridColumn45";
		this.repositoryItemGridLookUpEdit3.AutoHeight = false;
		this.repositoryItemGridLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemGridLookUpEdit3.Name = "repositoryItemGridLookUpEdit3";
		this.repositoryItemGridLookUpEdit3.PopupView = this.gridView3;
		this.gridView3.DetailHeight = 239;
		this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridView3.Name = "gridView3";
		this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView3.OptionsView.ShowGroupPanel = false;
		this.navPageEOT.Controls.Add(this.gridEOT);
		this.navPageEOT.Margin = new System.Windows.Forms.Padding(2);
		this.navPageEOT.Name = "navPageEOT";
		this.navPageEOT.Size = new System.Drawing.Size(1318, 496);
		toolTipTitleItem4.Text = "EOT Assessment";
		toolTipItem4.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image3");
		toolTipItem4.Text = "Enter marks scored from the End of Term examination. Entries should be out-of 100%";
		superToolTip4.Items.Add(toolTipTitleItem4);
		superToolTip4.Items.Add(toolTipItem4);
		this.navPageEOT.SuperTip = superToolTip4;
		this.gridEOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.gridEOT.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode4.RelationName = "Level1";
		this.gridEOT.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode4 });
		this.gridEOT.Location = new System.Drawing.Point(0, 0);
		this.gridEOT.MainView = this.gvEOT;
		this.gridEOT.Margin = new System.Windows.Forms.Padding(2);
		this.gridEOT.Name = "gridEOT";
		this.gridEOT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit4 });
		this.gridEOT.Size = new System.Drawing.Size(1318, 496);
		this.gridEOT.TabIndex = 6;
		this.gridEOT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gvEOT });
		this.gvEOT.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gvEOT.Appearance.BandPanel.Options.UseFont = true;
		this.gvEOT.Appearance.BandPanel.Options.UseTextOptions = true;
		this.gvEOT.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gvEOT.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.BandPanelBackground.Options.UseFont = true;
		this.gvEOT.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gvEOT.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gvEOT.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gvEOT.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gvEOT.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gvEOT.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.DetailTip.Options.UseFont = true;
		this.gvEOT.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.Empty.Options.UseFont = true;
		this.gvEOT.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.EvenRow.Options.UseFont = true;
		this.gvEOT.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gvEOT.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gvEOT.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.FilterPanel.Options.UseFont = true;
		this.gvEOT.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.FixedLine.Options.UseFont = true;
		this.gvEOT.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.FocusedCell.Options.UseFont = true;
		this.gvEOT.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.FocusedRow.Options.UseFont = true;
		this.gvEOT.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gvEOT.Appearance.FooterPanel.Options.UseFont = true;
		this.gvEOT.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.GroupButton.Options.UseFont = true;
		this.gvEOT.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.GroupFooter.Options.UseFont = true;
		this.gvEOT.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.GroupPanel.Options.UseFont = true;
		this.gvEOT.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.GroupRow.Options.UseFont = true;
		this.gvEOT.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.gvEOT.Appearance.HeaderPanel.Options.UseFont = true;
		this.gvEOT.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.gvEOT.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gvEOT.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.HorzLine.Options.UseFont = true;
		this.gvEOT.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.OddRow.Options.UseFont = true;
		this.gvEOT.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.Preview.Options.UseFont = true;
		this.gvEOT.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.Row.Options.UseFont = true;
		this.gvEOT.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.RowSeparator.Options.UseFont = true;
		this.gvEOT.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.SelectedRow.Options.UseFont = true;
		this.gvEOT.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.TopNewRow.Options.UseFont = true;
		this.gvEOT.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.VertLine.Options.UseFont = true;
		this.gvEOT.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvEOT.Appearance.ViewCaption.Options.UseFont = true;
		this.gvEOT.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.gvEOT.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.gvEOT.AppearancePrint.Preview.Options.UseBackColor = true;
		this.gvEOT.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[3] { this.gridBand10, this.gridBand11, this.gridBand12 });
		this.gvEOT.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[11]
		{
			this.bandedGridColumn14, this.bandedGridColumn15, this.bandedGridColumn19, this.bandedGridColumn20, this.bandedGridColumn21, this.bandedGridColumn40, this.bandedGridColumn41, this.bandedGridColumn43, this.bandedGridColumn22, this.bandedGridColumn23,
			this.bandedGridColumn25
		});
		this.gvEOT.DetailHeight = 239;
		styleFormatCondition4.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition4.Appearance.Options.UseForeColor = true;
		styleFormatCondition4.ApplyToRow = true;
		styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition4.Value1 = "F9";
		this.gvEOT.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition4 });
		this.gvEOT.GridControl = this.gridEOT;
		this.gvEOT.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
		this.gvEOT.IndicatorWidth = 23;
		this.gvEOT.Name = "gvEOT";
		this.gvEOT.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.gvEOT.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.gvEOT.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gvEOT.OptionsCustomization.AllowColumnMoving = false;
		this.gvEOT.OptionsCustomization.AllowFilter = false;
		this.gvEOT.OptionsCustomization.AllowGroup = false;
		this.gvEOT.OptionsCustomization.AllowSort = false;
		this.gvEOT.OptionsFilter.AllowColumnMRUFilterList = false;
		this.gvEOT.OptionsFilter.AllowFilterEditor = false;
		this.gvEOT.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.gvEOT.OptionsFilter.AllowMRUFilterList = false;
		this.gvEOT.OptionsPrint.PrintFilterInfo = true;
		this.gvEOT.OptionsView.EnableAppearanceEvenRow = true;
		this.gvEOT.OptionsView.ShowGroupPanel = false;
		this.gvEOT.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gvEOT.OptionsView.ShowIndicator = false;
		this.gvEOT.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gvEOT.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gvEOT.RowHeight = 17;
		this.gvEOT.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gvEOT_FocusedRowChanged);
		this.gvEOT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvEOT_CellValueChanged);
		this.gvEOT.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gvEOT_CustomColumnDisplayText);
		this.gridBand10.Caption = "STUDENT'S INFORMATION";
		this.gridBand10.Columns.Add(this.bandedGridColumn14);
		this.gridBand10.Columns.Add(this.bandedGridColumn15);
		this.gridBand10.Columns.Add(this.bandedGridColumn19);
		this.gridBand10.Columns.Add(this.bandedGridColumn20);
		this.gridBand10.Columns.Add(this.bandedGridColumn21);
		this.gridBand10.MinWidth = 202;
		this.gridBand10.Name = "gridBand10";
		this.gridBand10.OptionsBand.AllowHotTrack = false;
		this.gridBand10.OptionsBand.AllowMove = false;
		this.gridBand10.OptionsBand.AllowPress = false;
		this.gridBand10.VisibleIndex = 0;
		this.gridBand10.Width = 510;
		this.bandedGridColumn14.Caption = "#";
		this.bandedGridColumn14.MinWidth = 60;
		this.bandedGridColumn14.Name = "bandedGridColumn14";
		this.bandedGridColumn14.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn14.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn14.Visible = true;
		this.bandedGridColumn14.Width = 60;
		this.bandedGridColumn15.Caption = "Name";
		this.bandedGridColumn15.FieldName = "fullName";
		this.bandedGridColumn15.MinWidth = 255;
		this.bandedGridColumn15.Name = "bandedGridColumn15";
		this.bandedGridColumn15.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn15.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn15.Visible = true;
		this.bandedGridColumn15.Width = 255;
		this.bandedGridColumn19.Caption = "Stud#";
		this.bandedGridColumn19.FieldName = "StudentNumber";
		this.bandedGridColumn19.MinWidth = 105;
		this.bandedGridColumn19.Name = "bandedGridColumn19";
		this.bandedGridColumn19.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn19.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn19.Visible = true;
		this.bandedGridColumn19.Width = 105;
		this.bandedGridColumn20.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn20.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn20.Caption = "Sex";
		this.bandedGridColumn20.FieldName = "Sex";
		this.bandedGridColumn20.MinWidth = 60;
		this.bandedGridColumn20.Name = "bandedGridColumn20";
		this.bandedGridColumn20.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn20.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn20.Width = 10599;
		this.bandedGridColumn21.Caption = "Stream";
		this.bandedGridColumn21.FieldName = "StreamId";
		this.bandedGridColumn21.MinWidth = 90;
		this.bandedGridColumn21.Name = "bandedGridColumn21";
		this.bandedGridColumn21.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn21.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn21.Visible = true;
		this.bandedGridColumn21.Width = 90;
		this.gridBand11.Caption = "END OF TERM ASSESSMENT";
		this.gridBand11.Columns.Add(this.bandedGridColumn43);
		this.gridBand11.MinWidth = 112;
		this.gridBand11.Name = "gridBand11";
		this.gridBand11.OptionsBand.AllowHotTrack = false;
		this.gridBand11.OptionsBand.AllowMove = false;
		this.gridBand11.OptionsBand.AllowPress = false;
		this.gridBand11.VisibleIndex = 1;
		this.gridBand11.Width = 161;
		this.bandedGridColumn43.Caption = "ETA (100%)";
		this.bandedGridColumn43.FieldName = "ETA";
		this.bandedGridColumn43.MinWidth = 60;
		this.bandedGridColumn43.Name = "bandedGridColumn43";
		this.bandedGridColumn43.ToolTip = "End of Term Assessment. Marks are entered as percentage scores";
		this.bandedGridColumn43.Visible = true;
		this.bandedGridColumn43.Width = 161;
		this.gridBand12.Caption = "GRADING";
		this.gridBand12.Columns.Add(this.bandedGridColumn41);
		this.gridBand12.Columns.Add(this.bandedGridColumn25);
		this.gridBand12.Columns.Add(this.bandedGridColumn23);
		this.gridBand12.Columns.Add(this.bandedGridColumn22);
		this.gridBand12.MinWidth = 112;
		this.gridBand12.Name = "gridBand12";
		this.gridBand12.OptionsBand.AllowHotTrack = false;
		this.gridBand12.OptionsBand.AllowMove = false;
		this.gridBand12.OptionsBand.AllowPress = false;
		this.gridBand12.VisibleIndex = 2;
		this.gridBand12.Width = 342;
		this.bandedGridColumn41.Caption = "CTA (20)";
		this.bandedGridColumn41.FieldName = "AvMark";
		this.bandedGridColumn41.MinWidth = 60;
		this.bandedGridColumn41.Name = "bandedGridColumn41";
		this.bandedGridColumn41.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn41.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn41.ToolTip = "Cummulative Topic Assessment, expressed as a fraction of 20.";
		this.bandedGridColumn41.Visible = true;
		this.bandedGridColumn25.Caption = "ETA (80)";
		this.bandedGridColumn25.FieldName = "ETA80";
		this.bandedGridColumn25.MinWidth = 45;
		this.bandedGridColumn25.Name = "bandedGridColumn25";
		this.bandedGridColumn25.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn25.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn25.ToolTip = "End of Term Assessment, expressed as a fraction of 80";
		this.bandedGridColumn25.Visible = true;
		this.bandedGridColumn25.Width = 74;
		this.bandedGridColumn23.Caption = "TOTAL SCORE";
		this.bandedGridColumn23.FieldName = "ETAv";
		this.bandedGridColumn23.MinWidth = 60;
		this.bandedGridColumn23.Name = "bandedGridColumn23";
		this.bandedGridColumn23.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn23.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn23.ToolTip = "Sum of CTA (20) and ETA (80)";
		this.bandedGridColumn23.Visible = true;
		this.bandedGridColumn23.Width = 104;
		this.bandedGridColumn22.Caption = "Grade";
		this.bandedGridColumn22.FieldName = "Category";
		this.bandedGridColumn22.MinWidth = 60;
		this.bandedGridColumn22.Name = "bandedGridColumn22";
		this.bandedGridColumn22.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn22.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn22.Visible = true;
		this.bandedGridColumn22.Width = 89;
		this.bandedGridColumn40.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn40.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn40.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn40.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn40.Caption = "TUnits";
		this.bandedGridColumn40.FieldName = "TUnits";
		this.bandedGridColumn40.MinWidth = 60;
		this.bandedGridColumn40.Name = "bandedGridColumn40";
		this.bandedGridColumn40.Visible = true;
		this.bandedGridColumn40.Width = 14518;
		this.repositoryItemGridLookUpEdit4.AutoHeight = false;
		this.repositoryItemGridLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemGridLookUpEdit4.Name = "repositoryItemGridLookUpEdit4";
		this.repositoryItemGridLookUpEdit4.PopupView = this.gridView4;
		this.gridView4.DetailHeight = 239;
		this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridView4.Name = "gridView4";
		this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView4.OptionsView.ShowGroupPanel = false;
		this.navPage10.AutoSize = true;
		this.navPage10.Controls.Add(this.dgMain10);
		this.navPage10.Name = "navPage10";
		this.navPage10.Size = new System.Drawing.Size(1318, 496);
		toolTipTitleItem5.Text = "RACI Model";
		toolTipItem5.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image4");
		toolTipItem5.Text = "Enter marks as scores computed on a scale of 10 using RACI model";
		superToolTip5.Items.Add(toolTipTitleItem5);
		superToolTip5.Items.Add(toolTipItem5);
		this.navPage10.SuperTip = superToolTip5;
		this.dgMain10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain10.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode5.RelationName = "Level1";
		this.dgMain10.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode5 });
		this.dgMain10.Location = new System.Drawing.Point(0, 0);
		this.dgMain10.MainView = this.gv10;
		this.dgMain10.Margin = new System.Windows.Forms.Padding(2);
		this.dgMain10.Name = "dgMain10";
		this.dgMain10.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit5 });
		this.dgMain10.Size = new System.Drawing.Size(1318, 496);
		this.dgMain10.TabIndex = 6;
		this.dgMain10.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gv10 });
		this.gv10.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gv10.Appearance.BandPanel.Options.UseFont = true;
		this.gv10.Appearance.BandPanel.Options.UseTextOptions = true;
		this.gv10.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gv10.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.BandPanelBackground.Options.UseFont = true;
		this.gv10.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv10.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gv10.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv10.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gv10.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gv10.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.DetailTip.Options.UseFont = true;
		this.gv10.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.Empty.Options.UseFont = true;
		this.gv10.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.EvenRow.Options.UseFont = true;
		this.gv10.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv10.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gv10.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.FilterPanel.Options.UseFont = true;
		this.gv10.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.FixedLine.Options.UseFont = true;
		this.gv10.Appearance.FocusedCell.BorderColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.gv10.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.FocusedCell.Options.UseBorderColor = true;
		this.gv10.Appearance.FocusedCell.Options.UseFont = true;
		this.gv10.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.FocusedRow.Options.UseFont = true;
		this.gv10.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.gv10.Appearance.FooterPanel.Options.UseFont = true;
		this.gv10.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.GroupButton.Options.UseFont = true;
		this.gv10.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.GroupFooter.Options.UseFont = true;
		this.gv10.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.GroupPanel.Options.UseFont = true;
		this.gv10.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.GroupRow.Options.UseFont = true;
		this.gv10.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold);
		this.gv10.Appearance.HeaderPanel.Options.UseFont = true;
		this.gv10.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.gv10.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gv10.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.HorzLine.Options.UseFont = true;
		this.gv10.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.OddRow.Options.UseFont = true;
		this.gv10.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.Preview.Options.UseFont = true;
		this.gv10.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.Row.Options.UseFont = true;
		this.gv10.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.RowSeparator.Options.UseFont = true;
		this.gv10.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.SelectedRow.Options.UseFont = true;
		this.gv10.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.TopNewRow.Options.UseFont = true;
		this.gv10.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.VertLine.Options.UseFont = true;
		this.gv10.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gv10.Appearance.ViewCaption.Options.UseFont = true;
		this.gv10.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.gv10.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.gv10.AppearancePrint.Preview.Options.UseBackColor = true;
		this.gv10.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[5] { this.gridBand13, this.gridBand14, this.gridBandProject, this.gridBand15, this.gridBand17 });
		this.gv10.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[15]
		{
			this.bandedGridColumn32, this.bandedGridColumn33, this.bandedGridColumn34, this.bandedGridColumn35, this.bandedGridColumn36, this.colT1, this.colT2, this.colT3, this.colT4, this.colT5,
			this.bandedGridColumn52, this.bandedGridColumn53, this.bandedGridColumn38, this.colProject, this.bandedGridColumn47
		});
		this.gv10.DetailHeight = 239;
		styleFormatCondition5.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition5.Appearance.Options.UseForeColor = true;
		styleFormatCondition5.ApplyToRow = true;
		styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition5.Value1 = "F9";
		this.gv10.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition5 });
		this.gv10.GridControl = this.dgMain10;
		this.gv10.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
		this.gv10.IndicatorWidth = 23;
		this.gv10.Name = "gv10";
		this.gv10.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv10.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.gv10.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
		this.gv10.OptionsCustomization.AllowColumnMoving = false;
		this.gv10.OptionsCustomization.AllowFilter = false;
		this.gv10.OptionsCustomization.AllowGroup = false;
		this.gv10.OptionsCustomization.AllowSort = false;
		this.gv10.OptionsFilter.AllowColumnMRUFilterList = false;
		this.gv10.OptionsFilter.AllowFilterEditor = false;
		this.gv10.OptionsFilter.AllowFilterIncrementalSearch = false;
		this.gv10.OptionsFilter.AllowMRUFilterList = false;
		this.gv10.OptionsPrint.PrintFilterInfo = true;
		this.gv10.OptionsView.EnableAppearanceEvenRow = true;
		this.gv10.OptionsView.ShowGroupPanel = false;
		this.gv10.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gv10.OptionsView.ShowIndicator = false;
		this.gv10.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.gv10.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
		this.gv10.RowHeight = 17;
		this.gv10.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gv10_FocusedRowChanged);
		this.gv10.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gv10_CellValueChanged);
		this.gv10.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gv10_CustomColumnDisplayText);
		this.gv10.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gv10_ValidatingEditor);
		this.gv10.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gv10_InvalidValueException);
		this.bandedGridColumn32.Caption = "#";
		this.bandedGridColumn32.MinWidth = 40;
		this.bandedGridColumn32.Name = "bandedGridColumn32";
		this.bandedGridColumn32.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn32.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn32.Visible = true;
		this.bandedGridColumn32.Width = 42;
		this.bandedGridColumn33.Caption = "Name";
		this.bandedGridColumn33.FieldName = "fullName";
		this.bandedGridColumn33.MinWidth = 300;
		this.bandedGridColumn33.Name = "bandedGridColumn33";
		this.bandedGridColumn33.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn33.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn33.Visible = true;
		this.bandedGridColumn33.Width = 317;
		this.bandedGridColumn34.Caption = "Stud#";
		this.bandedGridColumn34.FieldName = "StudentNumber";
		this.bandedGridColumn34.MinWidth = 170;
		this.bandedGridColumn34.Name = "bandedGridColumn34";
		this.bandedGridColumn34.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn34.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn34.Visible = true;
		this.bandedGridColumn34.Width = 179;
		this.bandedGridColumn35.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn35.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn35.Caption = "Sex";
		this.bandedGridColumn35.FieldName = "Sex";
		this.bandedGridColumn35.MinWidth = 150;
		this.bandedGridColumn35.Name = "bandedGridColumn35";
		this.bandedGridColumn35.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn35.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn35.Width = 276;
		this.bandedGridColumn36.Caption = "Stream";
		this.bandedGridColumn36.FieldName = "StreamId";
		this.bandedGridColumn36.MinWidth = 70;
		this.bandedGridColumn36.Name = "bandedGridColumn36";
		this.bandedGridColumn36.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn36.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn36.Visible = true;
		this.colT1.AppearanceCell.Options.UseTextOptions = true;
		this.colT1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT1.AppearanceHeader.Options.UseTextOptions = true;
		this.colT1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT1.Caption = "C1";
		this.colT1.FieldName = "T1";
		this.colT1.MinWidth = 50;
		this.colT1.Name = "colT1";
		this.colT1.Visible = true;
		this.colT1.Width = 52;
		this.colT2.AppearanceCell.Options.UseTextOptions = true;
		this.colT2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT2.AppearanceHeader.Options.UseTextOptions = true;
		this.colT2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT2.Caption = "C2";
		this.colT2.FieldName = "T2";
		this.colT2.MinWidth = 50;
		this.colT2.Name = "colT2";
		this.colT2.Visible = true;
		this.colT2.Width = 52;
		this.colT3.AppearanceCell.Options.UseTextOptions = true;
		this.colT3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT3.AppearanceHeader.Options.UseTextOptions = true;
		this.colT3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT3.Caption = "C3";
		this.colT3.FieldName = "T3";
		this.colT3.MinWidth = 50;
		this.colT3.Name = "colT3";
		this.colT3.Visible = true;
		this.colT3.Width = 54;
		this.colT4.AppearanceCell.Options.UseTextOptions = true;
		this.colT4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT4.AppearanceHeader.Options.UseTextOptions = true;
		this.colT4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT4.Caption = "C4";
		this.colT4.FieldName = "T4";
		this.colT4.Name = "colT4";
		this.colT4.Visible = true;
		this.colT4.Width = 50;
		this.colProject.AppearanceCell.Options.UseTextOptions = true;
		this.colProject.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colProject.AppearanceHeader.Options.UseTextOptions = true;
		this.colProject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colProject.Caption = "Score";
		this.colProject.FieldName = "P1";
		this.colProject.Name = "colProject";
		this.colProject.Visible = true;
		this.colProject.Width = 63;
		this.bandedGridColumn52.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn52.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn52.Caption = "AVG. Score";
		this.bandedGridColumn52.FieldName = "OutOfTen";
		this.bandedGridColumn52.MinWidth = 60;
		this.bandedGridColumn52.Name = "bandedGridColumn52";
		this.bandedGridColumn52.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn52.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn52.Visible = true;
		this.bandedGridColumn52.Width = 254;
		this.bandedGridColumn47.Caption = "Generic Skills";
		this.bandedGridColumn47.FieldName = "GenericSkills";
		this.bandedGridColumn47.Name = "bandedGridColumn47";
		this.bandedGridColumn47.Visible = true;
		this.bandedGridColumn47.Width = 178;
		this.bandedGridColumn53.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn53.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn53.Caption = "TUnits";
		this.bandedGridColumn53.FieldName = "TUnits";
		this.bandedGridColumn53.MinWidth = 60;
		this.bandedGridColumn53.Name = "bandedGridColumn53";
		this.bandedGridColumn53.Visible = true;
		this.bandedGridColumn53.Width = 378;
		this.bandedGridColumn38.Caption = "ETA80";
		this.bandedGridColumn38.FieldName = "ETA80";
		this.bandedGridColumn38.Name = "bandedGridColumn38";
		this.repositoryItemGridLookUpEdit5.AutoHeight = false;
		this.repositoryItemGridLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.repositoryItemGridLookUpEdit5.Name = "repositoryItemGridLookUpEdit5";
		this.repositoryItemGridLookUpEdit5.PopupView = this.gridView5;
		this.gridView5.DetailHeight = 239;
		this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.gridView5.Name = "gridView5";
		this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView5.OptionsView.ShowGroupPanel = false;
		this.navPageHome.Controls.Add(this.tileControl2);
		this.navPageHome.Name = "navPageHome";
		this.navPageHome.Size = new System.Drawing.Size(1318, 496);
		this.tileControl2.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.tileControl2.AppearanceItem.Hovered.ForeColor = System.Drawing.Color.Orange;
		this.tileControl2.AppearanceItem.Hovered.Options.UseFont = true;
		this.tileControl2.AppearanceItem.Hovered.Options.UseForeColor = true;
		this.tileControl2.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10f);
		this.tileControl2.AppearanceItem.Normal.Options.UseFont = true;
		this.tileControl2.AppearanceItem.Pressed.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.tileControl2.AppearanceItem.Pressed.Options.UseFont = true;
		this.tileControl2.AppearanceItem.Selected.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.tileControl2.AppearanceItem.Selected.Options.UseFont = true;
		this.tileControl2.AppearanceText.Font = new System.Drawing.Font("Tahoma", 10f);
		this.tileControl2.AppearanceText.Options.UseFont = true;
		this.tileControl2.BackColor = System.Drawing.Color.Lavender;
		this.tileControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.tileControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tileControl2.Groups.Add(this.tileGroup5);
		this.tileControl2.Groups.Add(this.tileGroup4);
		this.tileControl2.Groups.Add(this.tileGroup7);
		this.tileControl2.Location = new System.Drawing.Point(0, 0);
		this.tileControl2.MaxId = 18;
		this.tileControl2.Name = "tileControl2";
		this.tileControl2.ShowGroupText = true;
		this.tileControl2.Size = new System.Drawing.Size(1318, 496);
		this.tileControl2.TabIndex = 0;
		this.tileControl2.Text = "tileControl2";
		this.tileGroup5.Items.Add(this.tileItemLO);
		this.tileGroup5.Items.Add(this.tileItemR10);
		this.tileGroup5.Name = "tileGroup5";
		this.tileGroup5.Text = "RACE Model";
		this.tileItemLO.AppearanceItem.Normal.BackColor = System.Drawing.Color.MidnightBlue;
		this.tileItemLO.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement.Text = "Scale of 3 scores";
		this.tileItemLO.Elements.Add(tileItemElement);
		this.tileItemLO.Id = 8;
		this.tileItemLO.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemLO.Name = "tileItemLO";
		this.tileItemLO.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemLO_ItemClick);
		this.tileItemR10.AppearanceItem.Normal.BackColor = System.Drawing.Color.SteelBlue;
		this.tileItemR10.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement2.Text = "Scale of 10 scores";
		this.tileItemR10.Elements.Add(tileItemElement2);
		this.tileItemR10.Id = 9;
		this.tileItemR10.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemR10.Name = "tileItemR10";
		this.tileItemR10.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemR10_ItemClick);
		this.tileGroup4.Items.Add(this.tileItemR20);
		this.tileGroup4.Items.Add(this.tileItemR100);
		this.tileGroup4.Items.Add(this.tileItemREOT);
		this.tileGroup4.Name = "tileGroup4";
		this.tileGroup4.Text = "Standard Model";
		this.tileItemR20.AppearanceItem.Normal.BackColor = System.Drawing.Color.Crimson;
		this.tileItemR20.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement3.Text = "Scale of 20 scores";
		this.tileItemR20.Elements.Add(tileItemElement3);
		this.tileItemR20.Id = 10;
		this.tileItemR20.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemR20.Name = "tileItemR20";
		this.tileItemR20.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemR20_ItemClick);
		this.tileItemR100.AppearanceItem.Normal.BackColor = System.Drawing.Color.PaleVioletRed;
		this.tileItemR100.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement4.Text = "Scale of 100% scores";
		this.tileItemR100.Elements.Add(tileItemElement4);
		this.tileItemR100.Id = 11;
		this.tileItemR100.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItemR100.Name = "tileItemR100";
		this.tileItemR100.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemR100_ItemClick);
		this.tileItemREOT.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkRed;
		this.tileItemREOT.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement5.Text = "EOT Examination";
		this.tileItemREOT.Elements.Add(tileItemElement5);
		this.tileItemREOT.Id = 12;
		this.tileItemREOT.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItemREOT.Name = "tileItemREOT";
		this.tileItemREOT.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemREOT_ItemClick);
		this.tileGroup7.Items.Add(this.tileItemRDes);
		this.tileGroup7.Items.Add(this.tileItem1);
		this.tileGroup7.Items.Add(this.tileItem2);
		this.tileGroup7.Name = "tileGroup7";
		this.tileGroup7.Text = "Descriptive Model";
		this.tileItemRDes.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
		this.tileItemRDes.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement6.Text = "Write Generic Skills";
		this.tileItemRDes.Elements.Add(tileItemElement6);
		this.tileItemRDes.Id = 15;
		this.tileItemRDes.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemRDes.Name = "tileItemRDes";
		this.tileItemRDes.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemRDes_ItemClick);
		this.tileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkCyan;
		this.tileItem1.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement7.Text = "Project Particulars";
		this.tileItem1.Elements.Add(tileItemElement7);
		this.tileItem1.Id = 16;
		this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItem1.Name = "tileItem1";
		this.tileItem1.Visible = false;
		this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItem1_ItemClick_1);
		this.tileItem2.AppearanceItem.Hovered.BackColor = System.Drawing.Color.Purple;
		this.tileItem2.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItem2.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		this.tileItem2.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement8.Text = "Write Competence";
		this.tileItem2.Elements.Add(tileItemElement8);
		this.tileItem2.Id = 17;
		this.tileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItem2.Name = "tileItem2";
		this.tileItem2.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItem2_ItemClick);
		this.navPageDescr.Controls.Add(this.splitContainerControl2);
		this.navPageDescr.Name = "navPageDescr";
		this.navPageDescr.Size = new System.Drawing.Size(1318, 496);
		this.splitContainerControl2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitContainerControl2.Location = new System.Drawing.Point(-1, 4);
		this.splitContainerControl2.Name = "splitContainerControl2";
		this.splitContainerControl2.Panel1.Controls.Add(this.dgMainDescriptive);
		this.splitContainerControl2.Panel1.Text = "Panel1";
		this.splitContainerControl2.Panel2.Controls.Add(this.vGridControl1);
		this.splitContainerControl2.Panel2.Text = "Panel2";
		this.splitContainerControl2.Size = new System.Drawing.Size(1320, 488);
		this.splitContainerControl2.SplitterPosition = 424;
		this.splitContainerControl2.TabIndex = 5;
		this.dgMainDescriptive.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgMainDescriptive.Location = new System.Drawing.Point(0, 0);
		this.dgMainDescriptive.MainView = this.gvDescriptive;
		this.dgMainDescriptive.Name = "dgMainDescriptive";
		this.dgMainDescriptive.Size = new System.Drawing.Size(424, 488);
		this.dgMainDescriptive.TabIndex = 0;
		this.dgMainDescriptive.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gvDescriptive });
		this.gvDescriptive.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gvDescriptive.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gvDescriptive.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gvDescriptive.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.DetailTip.Options.UseFont = true;
		this.gvDescriptive.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.Empty.Options.UseFont = true;
		this.gvDescriptive.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.EvenRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gvDescriptive.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.FilterPanel.Options.UseFont = true;
		this.gvDescriptive.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.FixedLine.Options.UseFont = true;
		this.gvDescriptive.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.FocusedCell.Options.UseFont = true;
		this.gvDescriptive.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.FocusedRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.FooterPanel.Options.UseFont = true;
		this.gvDescriptive.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.GroupButton.Options.UseFont = true;
		this.gvDescriptive.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.GroupFooter.Options.UseFont = true;
		this.gvDescriptive.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.GroupPanel.Options.UseFont = true;
		this.gvDescriptive.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.GroupRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.HeaderPanel.Options.UseFont = true;
		this.gvDescriptive.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.HorzLine.Options.UseFont = true;
		this.gvDescriptive.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.OddRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.Preview.Options.UseFont = true;
		this.gvDescriptive.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.Row.Options.UseFont = true;
		this.gvDescriptive.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.RowSeparator.Options.UseFont = true;
		this.gvDescriptive.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.SelectedRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.TopNewRow.Options.UseFont = true;
		this.gvDescriptive.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.VertLine.Options.UseFont = true;
		this.gvDescriptive.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvDescriptive.Appearance.ViewCaption.Options.UseFont = true;
		this.gvDescriptive.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColumn4, this.gridColumn5, this.gridColumn6, this.gridColumn7 });
		this.gvDescriptive.GridControl = this.dgMainDescriptive;
		this.gvDescriptive.Name = "gvDescriptive";
		this.gvDescriptive.OptionsBehavior.Editable = false;
		this.gvDescriptive.OptionsCustomization.AllowSort = false;
		this.gvDescriptive.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gvDescriptive.OptionsView.ShowGroupPanel = false;
		this.gvDescriptive.OptionsView.ShowIndicator = false;
		this.gvDescriptive.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gvDescriptive_RowClick);
		this.gvDescriptive.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gvDescriptive_FocusedRowChanged);
		this.gvDescriptive.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gvDescriptive_CustomColumnDisplayText);
		this.gridColumn4.Caption = "#";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 0;
		this.gridColumn4.Width = 30;
		this.gridColumn5.Caption = "Student#";
		this.gridColumn5.FieldName = "StudentNumber";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 1;
		this.gridColumn5.Width = 60;
		this.gridColumn6.Caption = "Name";
		this.gridColumn6.FieldName = "fullName";
		this.gridColumn6.Name = "gridColumn6";
		this.gridColumn6.Visible = true;
		this.gridColumn6.VisibleIndex = 2;
		this.gridColumn6.Width = 191;
		this.gridColumn7.Caption = "Stream";
		this.gridColumn7.FieldName = "StreamId";
		this.gridColumn7.Name = "gridColumn7";
		this.gridColumn7.Visible = true;
		this.gridColumn7.VisibleIndex = 3;
		this.vGridControl1.Appearance.BandBorder.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl1.Appearance.Caption.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.Caption.Options.UseFont = true;
		this.vGridControl1.Appearance.Category.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.Category.Options.UseFont = true;
		this.vGridControl1.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridControl1.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.DisabledRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridControl1.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.Empty.Options.UseFont = true;
		this.vGridControl1.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridControl1.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FixedLine.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecord.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridControl1.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.HorzLine.Options.UseFont = true;
		this.vGridControl1.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.ModifiedRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.PressedRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.PressedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridControl1.Appearance.RecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.RecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.RecordValue.Options.UseFont = true;
		this.vGridControl1.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedCategory.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRecord.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl1.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Code", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl1.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridControl1.Location = new System.Drawing.Point(0, 0);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.AutoScaleBands = true;
		this.vGridControl1.OptionsView.ShowCollapseButtons = false;
		this.vGridControl1.OptionsView.ShowFocusedFrame = false;
		this.vGridControl1.RecordWidth = 160;
		this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[6] { this.repositoryItemMemoEdit3, this.repositoryItemMemoEdit5, this.repositoryItemMemoEdit1, this.repositoryItemMemoEdit2, this.repositoryItemMemoEdit6, this.repositoryItemMemoEdit7 });
		this.vGridControl1.RowHeaderWidth = 40;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[8] { this.rowId, this.row, this.row6, this.row3, this.row2, this.row4, this.row5, this.row7 });
		this.vGridControl1.Size = new System.Drawing.Size(884, 488);
		this.vGridControl1.TabIndex = 1;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.repositoryItemMemoEdit3.MaxLength = 120;
		this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
		this.repositoryItemMemoEdit5.MaxLength = 120;
		this.repositoryItemMemoEdit5.Name = "repositoryItemMemoEdit5";
		this.repositoryItemMemoEdit1.MaxLength = 120;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.repositoryItemMemoEdit2.MaxLength = 120;
		this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
		this.repositoryItemMemoEdit6.MaxLength = 120;
		this.repositoryItemMemoEdit6.Name = "repositoryItemMemoEdit6";
		this.repositoryItemMemoEdit7.MaxLength = 120;
		this.repositoryItemMemoEdit7.Name = "repositoryItemMemoEdit7";
		this.rowId.Name = "rowId";
		this.rowId.Properties.Caption = "Id";
		this.rowId.Properties.FieldName = "Id";
		this.rowId.Visible = false;
		this.row.Name = "row";
		this.row.Properties.Caption = "Average LO";
		this.row.Properties.FieldName = "AvLO";
		this.row.Properties.ReadOnly = false;
		this.row6.Height = 120;
		this.row6.Name = "row6";
		this.row6.Properties.Caption = "Facilitator Remarks";
		this.row6.Properties.FieldName = "TeacherRemarks";
		this.row6.Properties.ReadOnly = false;
		this.row6.Properties.RowEdit = this.repositoryItemMemoEdit3;
		this.row6.Visible = false;
		this.row3.AppearanceHeader.Options.UseTextOptions = true;
		this.row3.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
		this.row3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		this.row3.Height = 120;
		this.row3.Name = "row3";
		this.row3.Properties.Caption = "Generic Skills (For Avg. Score)";
		this.row3.Properties.FieldName = "GenericSkills";
		this.row3.Properties.RowEdit = this.repositoryItemMemoEdit5;
		this.row3.Properties.ToolTip = "Generic skill for average of all the chapter. This input is usable on report templatev1";
		this.row2.Height = 120;
		this.row2.Name = "row2";
		this.row2.Properties.Caption = "Generic Skill T1";
		this.row2.Properties.FieldName = "GenericSkill_1";
		this.row2.Properties.RowEdit = this.repositoryItemMemoEdit1;
		this.row2.Properties.ToolTip = "Generic Skills for Topic 1";
		this.row4.Height = 120;
		this.row4.Name = "row4";
		this.row4.Properties.Caption = "Generic Skill T2";
		this.row4.Properties.FieldName = "GenericSkill_2";
		this.row4.Properties.RowEdit = this.repositoryItemMemoEdit2;
		this.row4.Properties.ToolTip = "Generic Skills for Topic 2";
		this.row5.Height = 120;
		this.row5.Name = "row5";
		this.row5.Properties.Caption = "Generic Skill T3";
		this.row5.Properties.FieldName = "GenericSkill_3";
		this.row5.Properties.RowEdit = this.repositoryItemMemoEdit6;
		this.row5.Properties.ToolTip = "Generic Skills for Topic 3";
		this.row7.Height = 120;
		this.row7.Name = "row7";
		this.row7.Properties.Caption = "Generic Skill T4";
		this.row7.Properties.FieldName = "GenericSkill_4";
		this.row7.Properties.RowEdit = this.repositoryItemMemoEdit7;
		this.row7.Properties.ToolTip = "Generic Skills for Topic 4";
		this.navPageOtherComp.Controls.Add(this.splitContainerControl1);
		this.navPageOtherComp.Name = "navPageOtherComp";
		this.navPageOtherComp.Size = new System.Drawing.Size(1318, 496);
		this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl1.Name = "splitContainerControl1";
		this.splitContainerControl1.Panel1.Controls.Add(this.dgOtherComp);
		this.splitContainerControl1.Panel1.Text = "Panel1";
		this.splitContainerControl1.Panel2.Controls.Add(this.vGridControl2);
		this.splitContainerControl1.Panel2.Text = "Panel2";
		this.splitContainerControl1.Size = new System.Drawing.Size(1318, 496);
		this.splitContainerControl1.SplitterPosition = 424;
		this.splitContainerControl1.TabIndex = 14;
		this.dgOtherComp.Dock = System.Windows.Forms.DockStyle.Fill;
		this.dgOtherComp.Location = new System.Drawing.Point(0, 0);
		this.dgOtherComp.MainView = this.gvOtherComp;
		this.dgOtherComp.Name = "dgOtherComp";
		this.dgOtherComp.Size = new System.Drawing.Size(424, 496);
		this.dgOtherComp.TabIndex = 13;
		this.dgOtherComp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gvOtherComp });
		this.gvOtherComp.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.gvOtherComp.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.gvOtherComp.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.gvOtherComp.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.DetailTip.Options.UseFont = true;
		this.gvOtherComp.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.Empty.Options.UseFont = true;
		this.gvOtherComp.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.EvenRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.FilterCloseButton.Options.UseFont = true;
		this.gvOtherComp.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.FilterPanel.Options.UseFont = true;
		this.gvOtherComp.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.FixedLine.Options.UseFont = true;
		this.gvOtherComp.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.FocusedCell.Options.UseFont = true;
		this.gvOtherComp.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.FocusedRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.FooterPanel.Options.UseFont = true;
		this.gvOtherComp.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.GroupButton.Options.UseFont = true;
		this.gvOtherComp.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.GroupFooter.Options.UseFont = true;
		this.gvOtherComp.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.GroupPanel.Options.UseFont = true;
		this.gvOtherComp.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.GroupRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.HeaderPanel.Options.UseFont = true;
		this.gvOtherComp.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.HorzLine.Options.UseFont = true;
		this.gvOtherComp.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.HotTrackedRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.OddRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.Preview.Options.UseFont = true;
		this.gvOtherComp.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.Row.Options.UseFont = true;
		this.gvOtherComp.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.RowSeparator.Options.UseFont = true;
		this.gvOtherComp.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.SelectedRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.TopNewRow.Options.UseFont = true;
		this.gvOtherComp.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.VertLine.Options.UseFont = true;
		this.gvOtherComp.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.gvOtherComp.Appearance.ViewCaption.Options.UseFont = true;
		this.gvOtherComp.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[4] { this.gridColumn8, this.gridColumn9, this.gridColumn10, this.gridColumn11 });
		this.gvOtherComp.GridControl = this.dgOtherComp;
		this.gvOtherComp.Name = "gvOtherComp";
		this.gvOtherComp.OptionsBehavior.Editable = false;
		this.gvOtherComp.OptionsCustomization.AllowSort = false;
		this.gvOtherComp.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gvOtherComp.OptionsView.ShowGroupPanel = false;
		this.gvOtherComp.OptionsView.ShowIndicator = false;
		this.gvOtherComp.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gvOtherComp_FocusedRowChanged);
		this.gvOtherComp.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gvOtherComp_CustomColumnDisplayText);
		this.gridColumn8.Caption = "#";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 0;
		this.gridColumn8.Width = 30;
		this.gridColumn9.Caption = "Student#";
		this.gridColumn9.FieldName = "StudentNumber";
		this.gridColumn9.Name = "gridColumn9";
		this.gridColumn9.Visible = true;
		this.gridColumn9.VisibleIndex = 1;
		this.gridColumn9.Width = 60;
		this.gridColumn10.Caption = "Name";
		this.gridColumn10.FieldName = "fullName";
		this.gridColumn10.Name = "gridColumn10";
		this.gridColumn10.Visible = true;
		this.gridColumn10.VisibleIndex = 2;
		this.gridColumn10.Width = 191;
		this.gridColumn11.Caption = "Stream";
		this.gridColumn11.FieldName = "StreamId";
		this.gridColumn11.Name = "gridColumn11";
		this.gridColumn11.Visible = true;
		this.gridColumn11.VisibleIndex = 3;
		this.vGridControl2.Appearance.BandBorder.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl2.Appearance.Caption.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.Caption.Options.UseFont = true;
		this.vGridControl2.Appearance.Category.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.Category.Options.UseFont = true;
		this.vGridControl2.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridControl2.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.DisabledRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridControl2.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.Empty.Options.UseFont = true;
		this.vGridControl2.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridControl2.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.FixedLine.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRecord.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridControl2.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.HorzLine.Options.UseFont = true;
		this.vGridControl2.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.ModifiedRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.PressedRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.PressedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridControl2.Appearance.RecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.RecordValue.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.RecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedCategory.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRecord.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Code", 12f);
		this.vGridControl2.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.vGridControl2.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.vGridControl2.Location = new System.Drawing.Point(0, 0);
		this.vGridControl2.Name = "vGridControl2";
		this.vGridControl2.OptionsFilter.AllowFilter = false;
		this.vGridControl2.RecordWidth = 994;
		this.vGridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemMemoEdit4, this.repositoryItemTextEdit1 });
		this.vGridControl2.RowHeaderWidth = 190;
		this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[3] { this.row1, this.ProjectTitle, this.Project });
		this.vGridControl2.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Never;
		this.vGridControl2.Size = new System.Drawing.Size(882, 496);
		this.vGridControl2.TabIndex = 12;
		this.vGridControl2.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl2_CellValueChanged);
		this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.row1.Name = "row1";
		this.row1.Properties.AllowEdit = false;
		this.row1.Properties.Caption = "row1";
		this.row1.Properties.FieldName = "Id";
		this.row1.Properties.ReadOnly = true;
		this.row1.Visible = false;
		this.ProjectTitle.Name = "ProjectTitle";
		this.ProjectTitle.Properties.Caption = "Project Title";
		this.ProjectTitle.Properties.FieldName = "ProjectTitle";
		this.ProjectTitle.Properties.RowEdit = this.repositoryItemTextEdit1;
		this.Project.Height = 200;
		this.Project.Name = "Project";
		this.Project.Properties.Caption = "Project";
		this.Project.Properties.FieldName = "Project";
		this.Project.Properties.RowEdit = this.repositoryItemMemoEdit4;
		this.navPageCompetence.Controls.Add(this.vGridLoadChapters);
		this.navPageCompetence.Name = "navPageCompetence";
		this.navPageCompetence.Size = new System.Drawing.Size(1318, 496);
		this.vGridLoadChapters.Appearance.BandBorder.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.BandBorder.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.Caption.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.Caption.Options.UseTextOptions = true;
		this.vGridLoadChapters.Appearance.Caption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.vGridLoadChapters.Appearance.Caption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.vGridLoadChapters.Appearance.Category.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.Category.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.DisabledRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.Empty.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.ExpandButton.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.FixedLine.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.FocusedRecord.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.HorzLine.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.ModifiedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.PressedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.PressedRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.RecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.RecordHeader.Options.UseTextOptions = true;
		this.vGridLoadChapters.Appearance.RecordHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.vGridLoadChapters.Appearance.RecordValue.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.RecordValue.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.SelectedCategory.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.SelectedCell.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.SelectedRecord.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridLoadChapters.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 10f);
		this.vGridLoadChapters.Appearance.VertLine.Options.UseFont = true;
		this.vGridLoadChapters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.vGridLoadChapters.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridLoadChapters.Dock = System.Windows.Forms.DockStyle.Fill;
		this.vGridLoadChapters.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
		this.vGridLoadChapters.Location = new System.Drawing.Point(0, 0);
		this.vGridLoadChapters.Name = "vGridLoadChapters";
		this.vGridLoadChapters.OptionsView.AutoScaleBands = true;
		this.vGridLoadChapters.RecordWidth = 177;
		this.vGridLoadChapters.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[8] { this.repositoryItemMemoEdit8, this.repositoryItemTextEdit2, this.repositoryItemTextEdit3, this.repositoryItemTextEdit4, this.repositoryItemTextEdit5, this.repositoryItemMemoEdit9, this.repositoryItemMemoEdit10, this.repositoryItemMemoEdit11 });
		this.vGridLoadChapters.RowHeaderWidth = 23;
		this.vGridLoadChapters.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[8] { this.rowTopic1, editorRow, this.rowTopic2, this.rowCompetence2, this.rowTopic3, this.rowCompetence3, this.rowTopic4, this.rowCompetence4 });
		this.vGridLoadChapters.Size = new System.Drawing.Size(1318, 496);
		this.vGridLoadChapters.TabIndex = 9;
		this.vGridLoadChapters.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridLoadChapters_CellValueChanged);
		this.repositoryItemTextEdit2.AutoHeight = false;
		this.repositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
		this.repositoryItemTextEdit3.AutoHeight = false;
		this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
		this.repositoryItemTextEdit4.AutoHeight = false;
		this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
		this.repositoryItemTextEdit5.AutoHeight = false;
		this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
		this.repositoryItemMemoEdit9.LinesCount = 5;
		this.repositoryItemMemoEdit9.Name = "repositoryItemMemoEdit9";
		this.repositoryItemMemoEdit10.LinesCount = 5;
		this.repositoryItemMemoEdit10.Name = "repositoryItemMemoEdit10";
		this.repositoryItemMemoEdit11.LinesCount = 5;
		this.repositoryItemMemoEdit11.Name = "repositoryItemMemoEdit11";
		this.rowTopic1.AppearanceHeader.Options.UseTextOptions = true;
		this.rowTopic1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowTopic1.Name = "rowTopic1";
		this.rowTopic1.Properties.Caption = "Topic 1";
		this.rowTopic1.Properties.FieldName = "Topic_1";
		this.rowTopic1.Properties.RowEdit = this.repositoryItemTextEdit2;
		this.rowTopic1.Tag = (short)1;
		this.rowTopic2.AppearanceHeader.Options.UseTextOptions = true;
		this.rowTopic2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowTopic2.Name = "rowTopic2";
		this.rowTopic2.Properties.Caption = "Topic 2";
		this.rowTopic2.Properties.FieldName = "Topic_2";
		this.rowTopic2.Properties.RowEdit = this.repositoryItemTextEdit3;
		this.rowTopic2.Tag = (short)2;
		this.rowCompetence2.AppearanceHeader.Options.UseTextOptions = true;
		this.rowCompetence2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowCompetence2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.rowCompetence2.Name = "rowCompetence2";
		this.rowCompetence2.Properties.Caption = "Competency 2";
		this.rowCompetence2.Properties.FieldName = "Competence_2";
		this.rowCompetence2.Properties.RowEdit = this.repositoryItemMemoEdit9;
		this.rowCompetence2.Tag = (short)2;
		this.rowTopic3.AppearanceHeader.Options.UseTextOptions = true;
		this.rowTopic3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowTopic3.Name = "rowTopic3";
		this.rowTopic3.Properties.Caption = "Topic 3";
		this.rowTopic3.Properties.FieldName = "Topic_3";
		this.rowTopic3.Properties.RowEdit = this.repositoryItemTextEdit4;
		this.rowTopic3.Tag = (short)3;
		this.rowCompetence3.AppearanceHeader.Options.UseTextOptions = true;
		this.rowCompetence3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowCompetence3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.rowCompetence3.Name = "rowCompetence3";
		this.rowCompetence3.Properties.Caption = "Competency 3";
		this.rowCompetence3.Properties.FieldName = "Competence_3";
		this.rowCompetence3.Properties.RowEdit = this.repositoryItemMemoEdit10;
		this.rowCompetence3.Tag = (short)3;
		this.rowTopic4.AppearanceHeader.Options.UseTextOptions = true;
		this.rowTopic4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowTopic4.Name = "rowTopic4";
		this.rowTopic4.Properties.Caption = "Topic 4";
		this.rowTopic4.Properties.FieldName = "Topic_4";
		this.rowTopic4.Properties.RowEdit = this.repositoryItemTextEdit5;
		this.rowTopic4.Tag = (short)4;
		this.rowCompetence4.AppearanceHeader.Options.UseTextOptions = true;
		this.rowCompetence4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
		this.rowCompetence4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
		this.rowCompetence4.Name = "rowCompetence4";
		this.rowCompetence4.Properties.Caption = "Competency 4";
		this.rowCompetence4.Properties.FieldName = "Competence_4";
		this.rowCompetence4.Properties.RowEdit = this.repositoryItemMemoEdit11;
		this.rowCompetence4.Tag = (short)4;
		this.lblWelcome.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
		this.lblWelcome.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold);
		this.lblWelcome.Appearance.ForeColor = System.Drawing.Color.White;
		this.lblWelcome.Appearance.Options.UseBackColor = true;
		this.lblWelcome.Appearance.Options.UseFont = true;
		this.lblWelcome.Appearance.Options.UseForeColor = true;
		this.lblWelcome.Appearance.Options.UseTextOptions = true;
		this.lblWelcome.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.lblWelcome.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
		this.lblWelcome.Location = new System.Drawing.Point(0, 0);
		this.lblWelcome.Name = "lblWelcome";
		this.lblWelcome.Size = new System.Drawing.Size(1322, 26);
		this.lblWelcome.TabIndex = 7;
		this.lblWelcome.Text = "Choose Data Entry Model to Begin";
		this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl1.Appearance.Options.UseBackColor = true;
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Controls.Add(this.lblWelcome);
		this.panelControl1.Controls.Add(this.navigationFrame1);
		this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panelControl1.Location = new System.Drawing.Point(0, 147);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(1322, 524);
		this.panelControl1.TabIndex = 8;
		this.flyoutPanel2.Controls.Add(this.flyoutPanelControl2);
		this.flyoutPanel2.Location = new System.Drawing.Point(13, 261);
		this.flyoutPanel2.Name = "flyoutPanel2";
		this.flyoutPanel2.Options.CloseOnHidingOwner = false;
		this.flyoutPanel2.OwnerControl = this;
		this.flyoutPanel2.ParentForm = this;
		this.flyoutPanel2.Size = new System.Drawing.Size(573, 204);
		this.flyoutPanel2.TabIndex = 11;
		this.flyoutPanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.flyoutPanelControl2.Controls.Add(this.labelControl4);
		this.flyoutPanelControl2.Controls.Add(this.labelControl3);
		this.flyoutPanelControl2.Controls.Add(this.labelControl2);
		this.flyoutPanelControl2.Controls.Add(this.lookupClasses);
		this.flyoutPanelControl2.Controls.Add(this.labelControl1);
		this.flyoutPanelControl2.Controls.Add(this.simpleButton1);
		this.flyoutPanelControl2.Controls.Add(this.txtPassword);
		this.flyoutPanelControl2.Controls.Add(this.cboSubject);
		this.flyoutPanelControl2.Controls.Add(this.simpleButton2);
		this.flyoutPanelControl2.Controls.Add(this.txtUserId);
		this.flyoutPanelControl2.Controls.Add(this.pictureEdit1);
		this.flyoutPanelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.flyoutPanelControl2.FlyoutPanel = this.flyoutPanel2;
		this.flyoutPanelControl2.Location = new System.Drawing.Point(0, 0);
		this.flyoutPanelControl2.Name = "flyoutPanelControl2";
		this.flyoutPanelControl2.Size = new System.Drawing.Size(573, 204);
		this.flyoutPanelControl2.TabIndex = 0;
		this.labelControl4.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.labelControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
		this.labelControl4.Appearance.Options.UseBackColor = true;
		this.labelControl4.Appearance.Options.UseFont = true;
		this.labelControl4.Appearance.Options.UseForeColor = true;
		this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
		this.labelControl4.Location = new System.Drawing.Point(95, 118);
		this.labelControl4.Name = "labelControl4";
		this.labelControl4.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.labelControl4.Size = new System.Drawing.Size(86, 26);
		this.labelControl4.TabIndex = 11;
		this.labelControl4.Text = "Password";
		this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
		this.labelControl3.Appearance.Options.UseBackColor = true;
		this.labelControl3.Appearance.Options.UseFont = true;
		this.labelControl3.Appearance.Options.UseForeColor = true;
		this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
		this.labelControl3.Location = new System.Drawing.Point(95, 90);
		this.labelControl3.Name = "labelControl3";
		this.labelControl3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.labelControl3.Size = new System.Drawing.Size(86, 26);
		this.labelControl3.TabIndex = 10;
		this.labelControl3.Text = "Login ID";
		this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
		this.labelControl2.Appearance.Options.UseBackColor = true;
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.Appearance.Options.UseForeColor = true;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
		this.labelControl2.Location = new System.Drawing.Point(95, 62);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.labelControl2.Size = new System.Drawing.Size(86, 26);
		this.labelControl2.TabIndex = 9;
		this.labelControl2.Text = "Subject";
		this.lookupClasses.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dxValidationLogin.SetIconAlignment(this.lookupClasses, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.lookupClasses.Location = new System.Drawing.Point(187, 34);
		this.lookupClasses.MenuManager = this.ribbonControl1;
		this.lookupClasses.Name = "lookupClasses";
		this.lookupClasses.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.lookupClasses.Properties.Appearance.Options.UseFont = true;
		this.lookupClasses.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.lookupClasses.Properties.AppearanceDropDown.Options.UseFont = true;
		this.lookupClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookupClasses.Properties.NullText = "";
		this.lookupClasses.Properties.PopupSizeable = false;
		this.lookupClasses.Size = new System.Drawing.Size(293, 26);
		this.lookupClasses.TabIndex = 4;
		conditionValidationRule.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule.ErrorText = "This value is not valid";
		this.dxValidationLogin.SetValidationRule(this.lookupClasses, conditionValidationRule);
		this.lookupClasses.QueryPopUp += new System.ComponentModel.CancelEventHandler(lookupClasses_QueryPopUp);
		this.lookupClasses.EditValueChanged += new System.EventHandler(lookupClasses_EditValueChanged);
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11f);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
		this.labelControl1.Appearance.Options.UseBackColor = true;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
		this.labelControl1.Location = new System.Drawing.Point(95, 34);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
		this.labelControl1.Size = new System.Drawing.Size(86, 26);
		this.labelControl1.TabIndex = 8;
		this.labelControl1.Text = "Class";
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton1.Location = new System.Drawing.Point(187, 155);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
		this.simpleButton1.Size = new System.Drawing.Size(143, 28);
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Login";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dxValidationLogin.SetIconAlignment(this.txtPassword, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtPassword.Location = new System.Drawing.Point(187, 118);
		this.txtPassword.MenuManager = this.ribbonControl1;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.txtPassword.Properties.Appearance.Options.UseFont = true;
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Size = new System.Drawing.Size(293, 26);
		this.txtPassword.TabIndex = 6;
		conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule2.ErrorText = "This value is not valid";
		this.dxValidationLogin.SetValidationRule(this.txtPassword, conditionValidationRule2);
		this.cboSubject.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dxValidationLogin.SetIconAlignment(this.cboSubject, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.cboSubject.Location = new System.Drawing.Point(187, 62);
		this.cboSubject.MenuManager = this.ribbonControl1;
		this.cboSubject.Name = "cboSubject";
		this.cboSubject.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.cboSubject.Properties.Appearance.Options.UseFont = true;
		this.cboSubject.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSubject.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSubject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboSubject.Size = new System.Drawing.Size(293, 26);
		this.cboSubject.TabIndex = 7;
		conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule3.ErrorText = "This value is not valid";
		this.dxValidationLogin.SetValidationRule(this.cboSubject, conditionValidationRule3);
		this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton2.Location = new System.Drawing.Point(337, 155);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
		this.simpleButton2.Size = new System.Drawing.Size(143, 28);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Exit";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.txtUserId.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.dxValidationLogin.SetIconAlignment(this.txtUserId, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
		this.txtUserId.Location = new System.Drawing.Point(187, 90);
		this.txtUserId.MenuManager = this.ribbonControl1;
		this.txtUserId.Name = "txtUserId";
		this.txtUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.txtUserId.Properties.Appearance.Options.UseFont = true;
		this.txtUserId.Size = new System.Drawing.Size(293, 26);
		this.txtUserId.TabIndex = 5;
		conditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
		conditionValidationRule4.ErrorText = "This value is not valid";
		this.dxValidationLogin.SetValidationRule(this.txtUserId, conditionValidationRule4);
		this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureEdit1.EditValue = MarksEntry.Properties.Resources.subtle_waves1024;
		this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
		this.pictureEdit1.MenuManager = this.ribbonControl1;
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.ShowMenu = false;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(573, 204);
		this.pictureEdit1.TabIndex = 1;
		this.colU5.Caption = "C5";
		this.colU5.DisplayFormat.FormatString = "{0:f1}";
		this.colU5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU5.FieldName = "U5";
		this.colU5.Name = "colU5";
		this.colU5.Visible = true;
		this.colU5.Width = 50;
		this.gridBand1.Caption = "STUDENT'S INFORMATION";
		this.gridBand1.Columns.Add(this.bandedGridColumn1);
		this.gridBand1.Columns.Add(this.bandedGridColumn2);
		this.gridBand1.Columns.Add(this.bandedGridColumn4);
		this.gridBand1.Columns.Add(this.bandedGridColumn3);
		this.gridBand1.Columns.Add(this.bandedGridColumn5);
		this.gridBand1.MinWidth = 49;
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.OptionsBand.AllowHotTrack = false;
		this.gridBand1.OptionsBand.AllowMove = false;
		this.gridBand1.OptionsBand.AllowPress = false;
		this.gridBand1.VisibleIndex = 0;
		this.gridBand1.Width = 614;
		this.gridBand2.Caption = "LEARNING OUTCOMES";
		this.gridBand2.Columns.Add(this.colU1);
		this.gridBand2.Columns.Add(this.colU2);
		this.gridBand2.Columns.Add(this.colU3);
		this.gridBand2.Columns.Add(this.colU4);
		this.gridBand2.Columns.Add(this.colU5);
		this.gridBand2.MinWidth = 49;
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.OptionsBand.AllowHotTrack = false;
		this.gridBand2.OptionsBand.AllowMove = false;
		this.gridBand2.OptionsBand.AllowPress = false;
		this.gridBand2.VisibleIndex = 1;
		this.gridBand2.Width = 250;
		this.gridBand3.Caption = "GRADING";
		this.gridBand3.Columns.Add(this.bandedGridColumn16);
		this.gridBand3.Columns.Add(this.bandedGridColumn17);
		this.gridBand3.MinWidth = 49;
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.OptionsBand.AllowHotTrack = false;
		this.gridBand3.OptionsBand.AllowMove = false;
		this.gridBand3.OptionsBand.AllowPress = false;
		this.gridBand3.VisibleIndex = 2;
		this.gridBand3.Width = 49;
		this.gridBand16.Caption = "Generic Skills";
		this.gridBand16.Columns.Add(this.bandedGridColumn46);
		this.gridBand16.Name = "gridBand16";
		this.gridBand16.VisibleIndex = 3;
		this.gridBand16.Width = 422;
		this.colT5.Caption = "C5";
		this.colT5.FieldName = "T5";
		this.colT5.Name = "colT5";
		this.colT5.Visible = true;
		this.colT5.Width = 50;
		this.gridBand13.Caption = "STUDENT'S INFORMATION";
		this.gridBand13.Columns.Add(this.bandedGridColumn32);
		this.gridBand13.Columns.Add(this.bandedGridColumn33);
		this.gridBand13.Columns.Add(this.bandedGridColumn34);
		this.gridBand13.Columns.Add(this.bandedGridColumn35);
		this.gridBand13.Columns.Add(this.bandedGridColumn36);
		this.gridBand13.MinWidth = 280;
		this.gridBand13.Name = "gridBand13";
		this.gridBand13.OptionsBand.AllowHotTrack = false;
		this.gridBand13.OptionsBand.AllowMove = false;
		this.gridBand13.OptionsBand.AllowPress = false;
		this.gridBand13.VisibleIndex = 0;
		this.gridBand13.Width = 613;
		this.gridBand14.Caption = "SCORES OUT OF 10";
		this.gridBand14.Columns.Add(this.colT1);
		this.gridBand14.Columns.Add(this.colT2);
		this.gridBand14.Columns.Add(this.colT3);
		this.gridBand14.Columns.Add(this.colT4);
		this.gridBand14.Columns.Add(this.colT5);
		this.gridBand14.MinWidth = 73;
		this.gridBand14.Name = "gridBand14";
		this.gridBand14.OptionsBand.AllowHotTrack = false;
		this.gridBand14.OptionsBand.AllowMove = false;
		this.gridBand14.OptionsBand.AllowPress = false;
		this.gridBand14.VisibleIndex = 1;
		this.gridBand14.Width = 258;
		this.gridBandProject.Caption = "Project";
		this.gridBandProject.Columns.Add(this.colProject);
		this.gridBandProject.Name = "gridBandProject";
		this.gridBandProject.VisibleIndex = 2;
		this.gridBandProject.Width = 63;
		this.gridBand15.Caption = "GRADING";
		this.gridBand15.Columns.Add(this.bandedGridColumn52);
		this.gridBand15.MinWidth = 73;
		this.gridBand15.Name = "gridBand15";
		this.gridBand15.OptionsBand.AllowHotTrack = false;
		this.gridBand15.OptionsBand.AllowMove = false;
		this.gridBand15.OptionsBand.AllowPress = false;
		this.gridBand15.VisibleIndex = 3;
		this.gridBand15.Width = 254;
		this.gridBand17.Caption = "Generic Skills";
		this.gridBand17.Columns.Add(this.bandedGridColumn47);
		this.gridBand17.Name = "gridBand17";
		this.gridBand17.VisibleIndex = 4;
		this.gridBand17.Width = 178;
		this.colScore5.Caption = "C5";
		this.colScore5.FieldName = "Score5";
		this.colScore5.Name = "colScore5";
		this.colScore5.Visible = true;
		this.colScore5.Width = 50;
		this.colHund5.Caption = "C5";
		this.colHund5.FieldName = "Hund5";
		this.colHund5.Name = "colHund5";
		this.colHund5.Visible = true;
		this.colHund5.Width = 50;
		this.gridBand7.Caption = "STUDENT'S INFORMATION";
		this.gridBand7.Columns.Add(this.bandedGridColumn27);
		this.gridBand7.Columns.Add(this.bandedGridColumn28);
		this.gridBand7.Columns.Add(this.bandedGridColumn29);
		this.gridBand7.Columns.Add(this.bandedGridColumn30);
		this.gridBand7.Columns.Add(this.bandedGridColumn31);
		this.gridBand7.MinWidth = 247;
		this.gridBand7.Name = "gridBand7";
		this.gridBand7.OptionsBand.AllowHotTrack = false;
		this.gridBand7.OptionsBand.AllowMove = false;
		this.gridBand7.OptionsBand.AllowPress = false;
		this.gridBand7.VisibleIndex = 0;
		this.gridBand7.Width = 515;
		this.gridBand8.Caption = "SCORES OUT OF 100";
		this.gridBand8.Columns.Add(this.colHund1);
		this.gridBand8.Columns.Add(this.colHund2);
		this.gridBand8.Columns.Add(this.colHund3);
		this.gridBand8.Columns.Add(this.colHund4);
		this.gridBand8.Columns.Add(this.colHund5);
		this.gridBand8.MinWidth = 163;
		this.gridBand8.Name = "gridBand8";
		this.gridBand8.OptionsBand.AllowHotTrack = false;
		this.gridBand8.OptionsBand.AllowMove = false;
		this.gridBand8.OptionsBand.AllowPress = false;
		this.gridBand8.VisibleIndex = 1;
		this.gridBand8.Width = 250;
		this.gridBand9.Caption = "GRADING";
		this.gridBand9.Columns.Add(this.bandedGridColumn42);
		this.gridBand9.MinWidth = 163;
		this.gridBand9.Name = "gridBand9";
		this.gridBand9.OptionsBand.AllowHotTrack = false;
		this.gridBand9.OptionsBand.AllowMove = false;
		this.gridBand9.OptionsBand.AllowPress = false;
		this.gridBand9.VisibleIndex = 2;
		this.gridBand9.Width = 263;
		this.gridBand19.Caption = "Generic Skills";
		this.gridBand19.Columns.Add(this.bandedGridColumn49);
		this.gridBand19.Name = "gridBand19";
		this.gridBand19.VisibleIndex = 3;
		this.gridBand19.Width = 338;
		this.gridBand4.Caption = "STUDENT'S INFORMATION";
		this.gridBand4.Columns.Add(this.bandedGridColumn6);
		this.gridBand4.Columns.Add(this.bandedGridColumn7);
		this.gridBand4.Columns.Add(this.bandedGridColumn8);
		this.gridBand4.Columns.Add(this.bandedGridColumn9);
		this.gridBand4.Columns.Add(this.bandedGridColumn10);
		this.gridBand4.MinWidth = 280;
		this.gridBand4.Name = "gridBand4";
		this.gridBand4.OptionsBand.AllowHotTrack = false;
		this.gridBand4.OptionsBand.AllowMove = false;
		this.gridBand4.OptionsBand.AllowPress = false;
		this.gridBand4.VisibleIndex = 0;
		this.gridBand4.Width = 615;
		this.gridBand5.Caption = "SCORES OUT OF 20";
		this.gridBand5.Columns.Add(this.colScore1);
		this.gridBand5.Columns.Add(this.colScore2);
		this.gridBand5.Columns.Add(this.colScore3);
		this.gridBand5.Columns.Add(this.colScore4);
		this.gridBand5.Columns.Add(this.colScore5);
		this.gridBand5.MinWidth = 73;
		this.gridBand5.Name = "gridBand5";
		this.gridBand5.OptionsBand.AllowHotTrack = false;
		this.gridBand5.OptionsBand.AllowMove = false;
		this.gridBand5.OptionsBand.AllowPress = false;
		this.gridBand5.VisibleIndex = 1;
		this.gridBand5.Width = 256;
		this.gridBand6.Caption = "GRADING";
		this.gridBand6.Columns.Add(this.bandedGridColumn24);
		this.gridBand6.MinWidth = 73;
		this.gridBand6.Name = "gridBand6";
		this.gridBand6.OptionsBand.AllowHotTrack = false;
		this.gridBand6.OptionsBand.AllowMove = false;
		this.gridBand6.OptionsBand.AllowPress = false;
		this.gridBand6.VisibleIndex = 2;
		this.gridBand6.Width = 254;
		this.gridBand18.Caption = "Generic Skills";
		this.gridBand18.Columns.Add(this.bandedGridColumn48);
		this.gridBand18.Name = "gridBand18";
		this.gridBand18.VisibleIndex = 3;
		this.gridBand18.Width = 241;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1322, 694);
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.flyoutPanel2);
		base.Controls.Add(this.ribbonStatusBar1);
		base.Controls.Add(this.flyoutPanel1);
		base.Controls.Add(this.ribbonControl1);
		base.IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("MainOLevelNewCur.IconOptions.Icon");
		base.KeyPreview = true;
		base.Name = "MainOLevelNewCur";
		this.Ribbon = this.ribbonControl1;
		this.StatusBar = this.ribbonStatusBar1;
		this.Text = "School Management Dynamics - Teachers' Workstation";
		base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainWindow_FormClosing);
		base.Load += new System.EventHandler(MainWindow_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(MainWindow_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.ribbonControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picStudentPicture).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemPictureEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemRibbonSearchEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).EndInit();
		this.flyoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).EndInit();
		this.flyoutPanelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).EndInit();
		this.navigationFrame1.ResumeLayout(false);
		this.navigationFrame1.PerformLayout();
		this.navPageLO.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel3).EndInit();
		this.flyoutPanel3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl3).EndInit();
		this.flyoutPanelControl3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView6).EndInit();
		this.navPage20.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgMain20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gv20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		this.navPage100.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgMain100).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gv100).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView3).EndInit();
		this.navPageEOT.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridEOT).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gvEOT).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView4).EndInit();
		this.navPage10.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgMain10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gv10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView5).EndInit();
		this.navPageHome.ResumeLayout(false);
		this.navPageDescr.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2.Panel1).EndInit();
		this.splitContainerControl2.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2.Panel2).EndInit();
		this.splitContainerControl2.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl2).EndInit();
		this.splitContainerControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgMainDescriptive).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gvDescriptive).EndInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit7).EndInit();
		this.navPageOtherComp.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel1).EndInit();
		this.splitContainerControl1.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1.Panel2).EndInit();
		this.splitContainerControl1.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl1).EndInit();
		this.splitContainerControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgOtherComp).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gvOtherComp).EndInit();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		this.navPageCompetence.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridLoadChapters).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel2).EndInit();
		this.flyoutPanel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl2).EndInit();
		this.flyoutPanelControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.lookupClasses.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dxValidationLogin).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
