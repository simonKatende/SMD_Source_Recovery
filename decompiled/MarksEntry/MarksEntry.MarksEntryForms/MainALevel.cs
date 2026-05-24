using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.GradingScales;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Drawing.Printing;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using MarksEntry.Properties;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using DataTable = System.Data.DataTable;
using Point = System.Drawing.Point;

namespace MarksEntry.MarksEntryForms;

public class MainALevel : XtraForm
{
	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private string suffix = string.Empty;

	private int i = 0;

	private bool IsInitialized = false;

	private string _paper = string.Empty;

	private readonly string timeExported = DateTime.Now.ToString("HHMMss");

	private SqlTransaction _trans;

	private SqlTransaction transs;

	private string ScoreLoadMode = string.Empty;

	private SqlTransaction _transaction;

	private DataTable _dt;

	private DataTable dt;

	private DataTable dts;

	private double A___HOP = 0.0;

	private double A___BOT = 0.0;

	private double A___MOT = 0.0;

	private double A___EOT = 0.0;

	private bool A_ProcessAsPercentages = true;

	private bool NotAs100 = true;

	private DataTable A__dt_g;

	private static readonly string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private Timer tmUpdate;

	private BarSubItem barSubItem9;

	private DefaultLookAndFeel defaultLookAndFeel1;

	private BackgroundWorker bgSaveMarks;

	private PrintingSystem printingSystem1;

	private PrintableComponentLink printableComponentLink1;

	private Timer timer1;

	private PopupMenu popupMenu1;

	private PopupMenu popupMenu2;

	private GridView gridView2;

	private GridControl dgMain;

	private BandedGridView bandedGridView1;

	private GridBand gridBand1;

	private BandedGridColumn bandedGridColumn1;

	private BandedGridColumn bandedGridColumn2;

	private BandedGridColumn bandedGridColumn3;

	private BandedGridColumn bandedGridColumn4;

	private BandedGridColumn bandedGridColumn5;

	private GridBand gridBand2;

	private BandedGridColumn gridColHoP;

	private BandedGridColumn gridColBOT;

	private BandedGridColumn gridColMOT;

	private BandedGridColumn gridColEOT;

	private GridBand gridBand3;

	private BandedGridColumn bandedGridColumn10;

	private BandedGridColumn bandedGridColumn11;

	private BandedGridColumn bandedGridColumn6;

	private BandedGridColumn bandedGridColumn7;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;

	private GridView repositoryItemGridLookUpEdit1View;

	private PanelControl panelControl2;

	private ComboBoxEdit cboSelectedSubject;

	private TileControl tileControl1;

	private TileGroup tileGroup1;

	private TileItem tileItem1;

	private TileItem tileItemStudent;

	private TileItem tileItemClassSettings;

	private TileGroup tileGroup3;

	private TileItem tileItemStream;

	private TileItem tileItemTerm;

	private TileGroup tileGroup2;

	private TileItem tileItemExport;

	private TileItem tileItemImport;

	private TileItem tileItemPrint;

	private PanelControl panelControl3;

	private ComboBoxEdit cboStream;

	private LabelControl lblLANStatus;

	private LabelControl lblInitial;

	private LabelControl labelControl2;

	private LabelControl labelControl1;

	private PictureEdit pictureEdit1;

	private FlyoutPanel flyoutPanel1;

	private FlyoutPanelControl flyoutPanelControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

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
			string selectCommandText = $"SELECT Picture,fullName,StudentNumber,StreamId FROM tbl_Stud WHERE ClassId='{tileItemClassSettings.Elements[1].Text}'";
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

	public MainALevel()
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
		tileItemClassSettings.Elements[1].Text = TeacherLogin.StudentClass();
		tileItemClassSettings.Elements[2].Text = TeacherLogin.CurrentSubject();
		tileItemTerm.Elements[1].Text = TeacherLogin.CurrentSemester();
		tileItemStream.Elements[2].Text = TeacherLogin.StudentClass();
		lblInitial.Text = TeacherInitials.GetTeacherInitials();
		TeacherLogin.LoadStreams(TeacherLogin.StudentClass(), cboStream);
		cboStream.SelectedIndex = 0;
		ThematicRatios.InitializeRatios(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
		ExamsOutputString.InitializeExamsOutputStrings(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
	}

	private void DropSingleALevel()
	{
		try
		{
			DataRow dataRow = dt.Rows[bandedGridView1.GetFocusedDataSourceRowIndex()];
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT SubjectId  FROM tbl_GeneralReport_AL WHERE SubjectId='{0}' AND SemesterId='{1}' AND StudentNumber='{2}' AND ClassId='{3}'", TeacherLogin.CurrentSubject(), TeacherLogin.CurrentSemester(), dataRow["Stud#"], TeacherLogin.StudentClass()), DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "CountOfPapers");
			if (dataSet.Tables[0].Rows.Count == 1)
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					_trans = sqlConnection.BeginTransaction();
					SqlCommand sqlCommand = new SqlCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.Transaction = _trans;
					sqlCommand.CommandText = string.Format("DELETE FROM tbl_GeneralReport_Grading_AL WHERE  StudentNumber='{0}' AND SemesterId='{1}' AND SubjectId='{2}' AND ClassId='{3}'", dataRow["Stud#"], TeacherLogin.CurrentSemester(), TeacherLogin.CurrentSubject(), TeacherLogin.StudentClass());
					sqlCommand.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand2 = sqlCommand)
					{
						sqlCommand2.ExecuteNonQuery();
					}
					sqlCommand = new SqlCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.Transaction = _trans;
					sqlCommand.CommandText = string.Format("DELETE FROM tbl_GeneralReport_AL WHERE SubjectId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}' AND ClassId='{3}'", TeacherLogin.CurrentSubject(), dataRow["Stud#"], TeacherLogin.CurrentSemester(), TeacherLogin.StudentClass());
					sqlCommand.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand3 = sqlCommand)
					{
						sqlCommand3.ExecuteNonQuery();
					}
					sqlCommand = new SqlCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.Transaction = _trans;
					sqlCommand.CommandText = string.Format("DELETE FROM tbl_Scores_AL WHERE SubjectId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}' AND ClassId='{3}'", TeacherLogin.CurrentSubject(), dataRow["Stud#"], TeacherLogin.CurrentSemester(), TeacherLogin.StudentClass());
					sqlCommand.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand4 = sqlCommand)
					{
						sqlCommand4.ExecuteNonQuery();
					}
					_trans.Commit();
					sqlConnection.Close();
					return;
				}
			}
			if (dataSet.Tables[0].Rows.Count <= 1)
			{
				return;
			}
			using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
			sqlConnection2.Open();
			_trans = sqlConnection2.BeginTransaction();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = sqlConnection2;
			cmd.Transaction = _trans;
			cmd.CommandText = string.Format("DELETE FROM tbl_GeneralReport_AL WHERE PaperId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}' AND ClassId='{3}'", cboSelectedSubject.EditValue.ToString(), dataRow["Stud#"], TeacherLogin.CurrentSemester(), TeacherLogin.StudentClass());
			cmd.CommandType = CommandType.Text;
			using (SqlCommand sqlCommand5 = cmd)
			{
				sqlCommand5.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand6 = new SqlCommand
			{
				Connection = sqlConnection2,
				Transaction = _trans,
				CommandText = string.Format("DELETE FROM tbl_Scores_AL WHERE PaperId='{0}' AND StudentNumber='{1}' AND SemesterId='{2}'", cboSelectedSubject.EditValue.ToString(), dataRow["Stud#"], TeacherLogin.CurrentSemester()),
				CommandType = CommandType.Text
			})
			{
				sqlCommand6.ExecuteNonQuery();
			}
			_trans.Commit();
			sqlConnection2.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Surepay School Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DropAllALevel()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SubjectId,PaperId FROM tbl_GeneralReport_AL WHERE SubjectId='{TeacherLogin.CurrentSubject()}' AND SemesterId='{TeacherLogin.CurrentSemester()}' AND ClassId='{TeacherLogin.StudentClass()}' Group By SubjectId,PaperId", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "CountOfPapers");
			if (dataSet.Tables[0].Rows.Count == 1)
			{
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					sqlConnection.Open();
					transs = sqlConnection.BeginTransaction();
					using (SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						Transaction = transs,
						CommandText = $"DELETE FROM tbl_GeneralReport_Grading_AL WHERE  SemesterId='{TeacherLogin.CurrentSemester()}' AND SubjectId='{TeacherLogin.CurrentSubject()}' AND ClassId='{TeacherLogin.StudentClass()}'",
						CommandType = CommandType.Text
					})
					{
						sqlCommand.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection,
						Transaction = transs,
						CommandText = $"DELETE FROM tbl_GeneralReport_AL WHERE SemesterId='{TeacherLogin.CurrentSemester()}' AND SubjectId='{TeacherLogin.CurrentSubject()}' AND ClassId='{TeacherLogin.StudentClass()}'",
						CommandType = CommandType.Text
					})
					{
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection,
						Transaction = transs,
						CommandText = $"DELETE FROM tbl_Scores_AL WHERE SemesterId='{TeacherLogin.CurrentSemester()}' AND SubjectId='{TeacherLogin.CurrentSubject()}' AND ClassId='{TeacherLogin.StudentClass()}'",
						CommandType = CommandType.Text
					})
					{
						sqlCommand3.ExecuteNonQuery();
					}
					transs.Commit();
					sqlConnection.Close();
					return;
				}
			}
			if (dataSet.Tables[0].Rows.Count <= 1)
			{
				return;
			}
			using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
			sqlConnection2.Open();
			transs = sqlConnection2.BeginTransaction();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection2,
				Transaction = transs,
				CommandText = $"DELETE FROM tbl_GeneralReport_AL WHERE SemesterId='{TeacherLogin.CurrentSemester()}' AND PaperId='{cboSelectedSubject.EditValue.ToString()}' AND ClassId='{TeacherLogin.StudentClass()}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand5 = new SqlCommand
			{
				Connection = sqlConnection2,
				Transaction = transs,
				CommandText = $"DELETE FROM tbl_Scores_AL WHERE SemesterId='{TeacherLogin.CurrentSemester()}' AND PaperId='{cboSelectedSubject.EditValue.ToString()}' AND ClassId='{TeacherLogin.StudentClass()}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand5.ExecuteNonQuery();
			}
			transs.Commit();
			sqlConnection2.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Surepay School Manager", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DropSubjectsWholeClass()
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to do this? Note that you cannot undo this action\nPlease Re-Process the reports for the selected Study Level, Semester and Class after this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				DropAllALevel();
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
				DropSingleALevel();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static string LoadDefaultALevelPaperForTeacher(string SubjectId)
	{
		string result = string.Empty;
		using (SqlConnection selectConnection = new SqlConnection(connectionString))
		{
			string selectCommandText = $"SELECT * FROM tbl_subjectLogin WHERE SubjectId LIKE '%{SubjectId}%' AND staffId='{TeacherLogin.TeacherID()}' AND ClassId='{TeacherLogin.StudentClass()}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelSubjects");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = dataRow["SubjectId"].ToString();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		return result;
	}

	private void LoadAllALevelPapersForTeacher(string SubjectId)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			string selectCommandText = $"SELECT * FROM tbl_subjectLogin WHERE SubjectId LIKE '%{SubjectId}%' AND staffId='{TeacherLogin.TeacherID()}' AND ClassId='{TeacherLogin.StudentClass()}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelSubjects");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			cboSelectedSubject.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				cboSelectedSubject.Properties.Items.Add(row["SubjectId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static string LoadDefaultALevelPaperForDOS(string SubjectId)
	{
		string result = string.Empty;
		using (SqlConnection selectConnection = new SqlConnection(connectionString))
		{
			string selectCommandText = $"SELECT * FROM ALevelSubjects_Categorised WHERE SubjectId = '{SubjectId}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelSubjects");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = dataRow["PaperId"].ToString();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
		return result;
	}

	private void LoadAllALevelPapersForDOS(string SubjectId)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			string selectCommandText = $"SELECT PaperId FROM ALevelSubjects_Categorised WHERE SubjectId='{SubjectId}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelSubjects");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			cboSelectedSubject.Properties.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				cboSelectedSubject.Properties.Items.Add(row["PaperId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadALevelMarks(string paperId)
	{
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				string selectCommandText = $"SELECT UPPER(s.fullName) AS Name,UPPER(s.StudentNumber) AS Stud#,(s.StreamId) AS Stream,s.Sex,gr.SubjectId,gr.PaperId,gr.SemesterId, sc.HoP,sc.BOT,sc.MOT,sc.EOT,(gr.AvMark) AS Score,(gr.Grade) AS GradeScore,(gr.Category) AS Grade FROM tbl_Stud s INNER JOIN tbl_GeneralReport_AL gr ON s.StudentNumber = gr.StudentNumber INNER JOIN tbl_Scores_AL sc ON gr.StudentNumber = sc.StudentNumber AND gr.PaperId = sc.PaperId AND gr.SemesterId = sc.SemesterId WHERE gr.PaperId='{paperId}' AND gr.SemesterId='{TeacherLogin.CurrentSemester()}' AND s.ClassId='{TeacherLogin.StudentClass()}' ORDER BY s.fullName,s.ClassId";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Marks");
				dt = new DataTable();
				dt.Columns.Clear();
				dt = dataSet.Tables[0];
				dgMain.DataSource = dt.DefaultView;
				bandedGridView1.Columns["PaperId"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Custom, null, paperId);
				bandedGridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
			}
			SetsVisibility();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadALevelMarks(string paperId, string _stream)
	{
		try
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				string selectCommandText = $"SELECT UPPER(s.fullName) AS Name,UPPER(s.StudentNumber) AS Stud#,s.Sex,gr.SubjectId,gr.PaperId,gr.SemesterId,sc.HoP,sc.BOT,sc.MOT,sc.EOT,(gr.AvMark) AS Score,(gr.Grade) AS GradeScore,(gr.Category) AS Grade FROM tbl_Stud s INNER JOIN tbl_GeneralReport_AL gr ON s.StudentNumber = gr.StudentNumber INNER JOIN tbl_Scores_AL sc ON gr.StudentNumber = sc.StudentNumber AND gr.PaperId = sc.PaperId AND gr.SemesterId = sc.SemesterId WHERE gr.PaperId='{paperId}' AND gr.SemesterId='{TeacherLogin.CurrentSemester()}' AND s.StreamId='{_stream}' AND s.ClassId='{TeacherLogin.StudentClass()}' ORDER BY s.fullName,s.ClassId";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "Marks");
				dt = new DataTable();
				dt.Columns.Clear();
				dt = dataSet.Tables[0];
				dgMain.DataSource = dt.DefaultView;
				bandedGridView1.Columns["PaperId"].FilterInfo = new ColumnFilterInfo(ColumnFilterType.Custom, null, paperId);
				bandedGridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
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
		try
		{
			if (TeacherLogin.LogginInUser() == "DOS")
			{
				_paper = LoadDefaultALevelPaperForDOS(TeacherLogin.CurrentSubject());
				LoadALevelMarks(_paper);
				if (ScoreLoadMode != "AfterStudentDelete")
				{
					LoadAllALevelPapersForDOS(TeacherLogin.CurrentSubject());
					cboSelectedSubject.EditValue = _paper;
					cboSelectedSubject.SelectedItem = _paper;
				}
			}
			else if (TeacherLogin.LogginInUser() == "Teacher")
			{
				_paper = LoadDefaultALevelPaperForTeacher(TeacherLogin.CurrentSubject());
				LoadALevelMarks(_paper);
				if (ScoreLoadMode != "AfterStudentDelete")
				{
					LoadAllALevelPapersForTeacher(TeacherLogin.CurrentSubject());
					cboSelectedSubject.EditValue = _paper;
					cboSelectedSubject.SelectedItem = _paper;
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void MainWindow_Load(object sender, EventArgs e)
	{
		SkinHelper.InitSkinPopupMenu(popupMenu2);
		LoadScoreSheet();
		A___HOP = ThematicRatios.HoP;
		A___BOT = ThematicRatios.BOT;
		A___MOT = ThematicRatios.MOT;
		A___EOT = ThematicRatios.EOT;
		A_ProcessAsPercentages = ThematicRatios.ProcessAsPercentages;
		A__dt_g = ALevelGradingScale.SubjectGradingScale;
		NotAs100 = ThematicRatios.MarksNot100;
		IsInitialized = true;
		gridColHoP.Caption = ExamsOutputString.hHoP;
		gridColBOT.Caption = ExamsOutputString.hBOT;
		gridColMOT.Caption = ExamsOutputString.hMOT;
		gridColEOT.Caption = ExamsOutputString.hEOT;
		tmUpdate.Enabled = true;
	}

	private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
	{
		System.Windows.Forms.Application.ExitThread();
	}

	private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
	{
		ExportReportToExcel(dgMain, $"{cboSelectedSubject.EditValue.ToString()}!{TeacherLogin.StudentClass()}${TeacherLogin.CurrentSemester()}");
	}

	private string ReportHeader(string report_header)
	{
		if (report_header == string.Empty)
		{
			string text = $"{TeacherLogin.StudentClass()} {cboStream.SelectedItem.ToString()}";
			string text2 = cboSelectedSubject.EditValue.ToString();
			return printableComponentLink1.RtfReportHeader = string.Format("{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\ql\\f0\\fs22 {0}\\par\r\n{1}\\par\r\n{2}\\par\r\n{3}\\par\r\n\\par\r\n{4}\\par\r\n}}\r\n", "Mark Sheet", text, text2, lblInitial.Text, report_header);
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
		ExportReportToExcel(dgMain, $"{cboSelectedSubject.EditValue.ToString()}!{TeacherLogin.StudentClass()}${TeacherLogin.CurrentSemester()}");
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
			sqlParameter.Value = TeacherLogin.StudentClass();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@subjectId", SqlDbType.VarChar, 50);
			sqlParameter.Value = cboSelectedSubject.EditValue.ToString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@semesterId", SqlDbType.VarChar, 50);
			sqlParameter.Value = TeacherLogin.CurrentSemester();
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
		if (text2.ToLower() == TeacherLogin.StudentClass().ToLower() && text3.ToLower() == cboSelectedSubject.EditValue.ToString().ToLower().Replace('/', '#') && text4 == TeacherLogin.CurrentSemester())
		{
			waitDialogForm.Caption = $"Importing {TeacherLogin.StudentClass()} scores";
			ImportScoresFromExcel.GetScoresFromExcel(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester(), cboSelectedSubject.EditValue.ToString());
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
		LoadScoreSheet();
	}

	private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
	{
		ScoreLoadMode = "AfterStudentDelete";
		DropSubjectsSingle();
		LoadScoreSheet();
	}

	private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
	{
		ScoreLoadMode = "AfterStudentDelete";
		DropSubjectsWholeClass();
		LoadScoreSheet();
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

	private void UpdateScores(string AvMark, string Category, float Grade, CellValueChangedEventArgs e)
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
				num = Math.Round(result / 100.0 * A___HOP, 0, MidpointRounding.AwayFromZero);
				num2 = Math.Round(result2 / 100.0 * A___BOT, 0, MidpointRounding.AwayFromZero);
				num3 = Math.Round(result3 / 100.0 * A___MOT, 0, MidpointRounding.AwayFromZero);
				num4 = Math.Round(result4 / 100.0 * A___EOT, 0, MidpointRounding.AwayFromZero);
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
			_transaction = sqlConnection.BeginTransaction();
			string commandText = string.Format("UPDATE tbl_GeneralReport_AL SET {0} = @{0},AvMark = @AvMark,Grade = @Grade,Category = @Category,Initial = @Initial WHERE StudentNumber = @StudentNumber AND PaperId = @PaperId AND SemesterId = @SemesterId AND ClassId=@ClassId", fieldName);
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = _transaction,
				CommandText = commandText,
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = bandedGridView1.GetRowCellValue(e.RowHandle, "Stud#").ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter.Value = TeacherLogin.StudentClass();
				sqlParameter.Direction = ParameterDirection.Input;
				if (string.IsNullOrEmpty(AvMark))
				{
					sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 4);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 6);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 3);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.Float);
					sqlParameter.Value = DBNull.Value;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				else
				{
					sqlParameter = sqlCommand.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 4);
					sqlParameter.Value = num5;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@AvMark", SqlDbType.VarChar, 6);
					sqlParameter.Value = AvMark;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar, 3);
					sqlParameter.Value = Category;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Grade", SqlDbType.Float);
					sqlParameter.Value = Grade;
					sqlParameter.Direction = ParameterDirection.Input;
				}
				sqlParameter = sqlCommand.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
				sqlParameter.Value = lblInitial.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter.Value = TeacherLogin.CurrentSemester();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
				sqlParameter.Value = cboSelectedSubject.EditValue.ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = _transaction,
				CommandText = string.Format("UPDATE tbl_Scores_AL SET {0}=@{0} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId AND ClassId=@ClassId", fieldName),
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter2.Value = bandedGridView1.GetRowCellValue(e.RowHandle, "Stud#").ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 8);
				sqlParameter2.Value = TeacherLogin.StudentClass();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add($"@{fieldName}", SqlDbType.VarChar, 6);
				sqlParameter2.Value = e.Value;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter2.Value = TeacherLogin.CurrentSemester();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
				sqlParameter2.Value = cboSelectedSubject.EditValue.ToString();
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			_transaction.Commit();
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
			num = Math.Round(result / 100.0 * A___HOP, 0, MidpointRounding.AwayFromZero);
			num2 = Math.Round(result2 / 100.0 * A___BOT, 0, MidpointRounding.AwayFromZero);
			num3 = Math.Round(result3 / 100.0 * A___MOT, 0, MidpointRounding.AwayFromZero);
			num4 = Math.Round(result4 / 100.0 * A___EOT, 0, MidpointRounding.AwayFromZero);
		}
		foreach (DataRow row in A__dt_g.Rows)
		{
			double num5 = 0.0;
			double num6 = 0.0;
			if (A_ProcessAsPercentages)
			{
				int num7 = 0;
				double[] array = new double[4] { A___HOP, A___BOT, A___MOT, A___EOT };
				for (int i = 0; i < 4; i++)
				{
					if (array[i] > 0.0)
					{
						num7++;
					}
				}
				num6 = (Math.Round(result, 0, MidpointRounding.AwayFromZero) + Math.Round(result2, 0, MidpointRounding.AwayFromZero) + Math.Round(result3, 0, MidpointRounding.AwayFromZero) + Math.Round(result4, 0, MidpointRounding.AwayFromZero)) / (double)num7;
				num5 = Math.Round(num6, 0, MidpointRounding.AwayFromZero);
			}
			else if (!A_ProcessAsPercentages)
			{
				num6 = num + num2 + num3 + num4;
				num5 = num6;
			}
			if (Convert.ToDouble(row["Debut"]) <= num5 && num5 <= Convert.ToDouble(row["End"]))
			{
				Random random = new Random();
				int num8 = (int)(random.NextDouble() * 5.0 + 1.0);
				bandedGridView1.SetRowCellValue(e.RowHandle, "Score", num5);
				bandedGridView1.SetRowCellValue(e.RowHandle, "Grade", row["Category"].ToString());
				bandedGridView1.SetRowCellValue(e.RowHandle, "GradeScore", row["Points"]);
				UpdateScores(bandedGridView1.GetRowCellValue(e.RowHandle, "Score").ToString(), bandedGridView1.GetRowCellValue(e.RowHandle, "Grade").ToString(), Convert.ToInt64(bandedGridView1.GetRowCellValue(e.RowHandle, "GradeScore").ToString()), e);
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
			if (DataConnection.DatabaseConnected())
			{
				lblLANStatus.Text = "Connected to Server.";
				pictureEdit1.Image = Resources.database_accept;
			}
			else
			{
				lblLANStatus.Text = "Lost Server Connection";
				pictureEdit1.Image = Resources.database_remove;
			}
		}
		catch (Exception ex)
		{
			lblLANStatus.Text = ex.Message;
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
			if ((A___EOT > 0.0 && A___HOP == 0.0 && A___BOT == 0.0 && A___MOT == 0.0) || (A___BOT > 0.0 && A___HOP == 0.0 && A___EOT == 0.0 && A___MOT == 0.0) || (A___MOT > 0.0 && A___HOP == 0.0 && A___BOT == 0.0 && A___EOT == 0.0))
			{
				Point pt = dgMain.PointToClient(Control.MousePosition);
				BandedGridHitInfo bandedGridHitInfo = bandedGridView1.CalcHitInfo(pt);
				if (bandedGridHitInfo.InRowCell)
				{
					int rowHandle = bandedGridHitInfo.RowHandle;
					GridColumn column = bandedGridHitInfo.Column;
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Score", null);
					bandedGridView1.SetRowCellValue(bandedGridView1.GetFocusedDataSourceRowIndex(), "Grade", "-");
				}
			}
			else if (A___BOT > 0.0 && A___HOP == 0.0 && A___EOT > 0.0 && A___MOT == 0.0)
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
				}
			}
			else if (A___MOT > 0.0 && A___HOP == 0.0 && A___BOT == 0.0 && A___EOT > 0.0)
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
				}
			}
			else if (A___MOT > 0.0 && A___HOP == 0.0 && A___BOT > 0.0 && A___EOT == 0.0)
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
				}
			}
			else if (A___MOT > 0.0 && A___HOP == 0.0 && A___BOT > 0.0 && A___EOT > 0.0)
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
				}
			}
			else if (A___MOT > 0.0 && A___HOP > 0.0 && A___BOT > 0.0 && A___EOT > 0.0)
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
				}
			}
		}
	}

	private void bandedGridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits ranging from 0 to 100 only.";
		bandedGridView1.HideEditor();
	}

	private void MainALevel_KeyDown(object sender, KeyEventArgs e)
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

	private void bandedGridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
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

	private void bandedGridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
	{
		if (e.Column.FieldName == "HoP" || e.Column.FieldName == "BOT" || e.Column.FieldName == "MOT" || e.Column.FieldName == "EOT")
		{
			MarksCalculator(e);
		}
	}

	private void bgSaveMarks_DoWork(object sender, DoWorkEventArgs e)
	{
		ThematicRatios.InitializeRatios(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
		ExamsOutputString.InitializeExamsOutputStrings(TeacherLogin.StudentClass(), TeacherLogin.CurrentSemester());
	}

	private void bgSaveMarks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		A___HOP = ThematicRatios.HoP;
		A___BOT = ThematicRatios.BOT;
		A___MOT = ThematicRatios.MOT;
		A___EOT = ThematicRatios.EOT;
		A_ProcessAsPercentages = ThematicRatios.ProcessAsPercentages;
		A__dt_g = gradingScale.SubjectGradingScale;
		NotAs100 = ThematicRatios.MarksNot100;
		gridColHoP.Caption = ExamsOutputString.hHoP;
		gridColBOT.Caption = ExamsOutputString.hBOT;
		gridColMOT.Caption = ExamsOutputString.hMOT;
		gridColEOT.Caption = ExamsOutputString.hEOT;
		tmUpdate.Enabled = true;
	}

	private void cboStream_EditValueChanged(object sender, EventArgs e)
	{
	}

	private void cboSelectedSubject_EditValueChanged(object sender, EventArgs e)
	{
	}

	private void cboStream_Closed(object sender, ClosedEventArgs e)
	{
		if (cboStream.EditValue != null)
		{
			if (cboStream.EditValue.ToString() == "Entire Class")
			{
				LoadALevelMarks(cboSelectedSubject.EditValue.ToString());
			}
			else
			{
				LoadALevelMarks(cboSelectedSubject.EditValue.ToString(), cboStream.EditValue.ToString());
			}
		}
	}

	private void bandedGridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		if (bandedGridView1.FocusedRowHandle > -1)
		{
			DataRow dataRow = dt.Rows[e.FocusedRowHandle];
			tileItemStudent.Elements[1].Text = dataRow["Name"].ToString();
			tileItemStudent.Elements[2].Text = dataRow["Stud#"].ToString();
		}
	}

	private void cboSelectedSubject_Closed(object sender, ClosedEventArgs e)
	{
		if (!IsInitialized || !(_paper != cboSelectedSubject.EditValue.ToString()))
		{
			return;
		}
		using NewInitials newInitials = new NewInitials();
		if (newInitials.ShowDialog() == DialogResult.OK)
		{
			LoadALevelMarks(cboSelectedSubject.EditValue.ToString());
			lblInitial.Text = TeacherInitials.GetTeacherInitials();
			_paper = cboSelectedSubject.SelectedItem.ToString();
		}
	}

	private void cboSelectedSubject_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
		{
			e.Handled = true;
		}
	}

	private void cboStream_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
		{
			e.Handled = true;
		}
	}

	private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
	{
		LoadUnRegisteredStudents();
		flyoutPanel1.Height = base.Height - 50;
		flyoutPanel1.ShowPopup();
	}

	private void flyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
	{
		if (e.Button == flyoutPanel1.OptionsButtonPanel.Buttons[0])
		{
			string text = tileItemTerm.Elements[1].Text;
			string s = text.Substring(text.IndexOf('-') + 1, 4);
			int result = (int.TryParse(s, out result) ? result : 1984);
			StudentRegistration.SetRegistrationParameters(gridView1, tileItemClassSettings.Elements[1].Text, result, 1, 1);
			using RegisterStudents registerStudents = new RegisterStudents("ALevel", tileItemClassSettings.Elements[2].Text, cboSelectedSubject.SelectedItem.ToString());
			if (registerStudents.ShowDialog() == DialogResult.OK)
			{
				flyoutPanel1.HidePopup();
				if (tileItemStream.Elements[1].Text == "Entire Class")
				{
					LoadALevelMarks(cboSelectedSubject.Text);
				}
				else
				{
					LoadALevelMarks(cboSelectedSubject.Text, cboStream.Text);
				}
			}
			return;
		}
		if (e.Button == flyoutPanel1.OptionsButtonPanel.Buttons[1])
		{
			flyoutPanel1.HidePopup();
		}
	}

	private void tileItemStudent_ItemClick(object sender, TileItemEventArgs e)
	{
		ScoreLoadMode = "AfterStudentDelete";
		DropSubjectsSingle();
		LoadScoreSheet();
	}

	private void tileItemClassSettings_ItemClick(object sender, TileItemEventArgs e)
	{
		ScoreLoadMode = "AfterStudentDelete";
		DropSubjectsWholeClass();
		LoadScoreSheet();
	}

	private void tileItemPrint_ItemClick(object sender, TileItemEventArgs e)
	{
		printableComponentLink1.PrintingSystem.ClearContent();
		printableComponentLink1.Component = dgMain;
		ReportHeader(string.Empty);
		printableComponentLink1.ShowPreview();
	}

	private void tileItemExport_ItemClick(object sender, TileItemEventArgs e)
	{
		ExportReportToExcel(dgMain, $"{tileItemClassSettings.Elements[2].Text}!{tileItemClassSettings.Elements[1].Text}${tileItemTerm.Elements[1].Text}");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (components != null)
			{
				components.Dispose();
			}
			if (_trans != null)
			{
				_trans.Dispose();
				_trans = null;
			}
			if (transs != null)
			{
				transs.Dispose();
				transs = null;
			}
			if (_transaction != null)
			{
				_transaction.Dispose();
				_transaction = null;
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
			if (A__dt_g != null)
			{
				A__dt_g.Dispose();
				A__dt_g = null;
			}
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.XtraEditors.TileItemElement tileItemElement = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement13 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement14 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement15 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement16 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement17 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarksEntry.MarksEntryForms.MainALevel));
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		this.popupMenu2 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.tmUpdate = new System.Windows.Forms.Timer(this.components);
		this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
		this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
		this.bgSaveMarks = new System.ComponentModel.BackgroundWorker();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
		this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
		this.dgMain = new DevExpress.XtraGrid.GridControl();
		this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
		this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.gridColHoP = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColBOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColMOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridColEOT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.cboStream = new DevExpress.XtraEditors.ComboBoxEdit();
		this.cboSelectedSubject = new DevExpress.XtraEditors.ComboBoxEdit();
		this.tileControl1 = new DevExpress.XtraEditors.TileControl();
		this.tileGroup1 = new DevExpress.XtraEditors.TileGroup();
		this.tileItem1 = new DevExpress.XtraEditors.TileItem();
		this.tileItemStudent = new DevExpress.XtraEditors.TileItem();
		this.tileItemClassSettings = new DevExpress.XtraEditors.TileItem();
		this.tileGroup3 = new DevExpress.XtraEditors.TileGroup();
		this.tileItemStream = new DevExpress.XtraEditors.TileItem();
		this.tileItemTerm = new DevExpress.XtraEditors.TileItem();
		this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
		this.tileItemExport = new DevExpress.XtraEditors.TileItem();
		this.tileItemImport = new DevExpress.XtraEditors.TileItem();
		this.tileItemPrint = new DevExpress.XtraEditors.TileItem();
		this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.lblLANStatus = new DevExpress.XtraEditors.LabelControl();
		this.lblInitial = new DevExpress.XtraEditors.LabelControl();
		this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
		this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		((System.ComponentModel.ISupportInitialize)this.popupMenu2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dgMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl2).BeginInit();
		this.panelControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedSubject.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl3).BeginInit();
		this.panelControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).BeginInit();
		this.flyoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).BeginInit();
		this.flyoutPanelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		base.SuspendLayout();
		this.popupMenu2.Name = "popupMenu2";
		this.popupMenu2.CloseUp += new System.EventHandler(popupMenu2_CloseUp);
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
		this.dgMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode.RelationName = "Level1";
		this.dgMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode });
		this.dgMain.Location = new System.Drawing.Point(0, 101);
		this.dgMain.MainView = this.bandedGridView1;
		this.dgMain.Name = "dgMain";
		this.dgMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit1 });
		this.dgMain.Size = new System.Drawing.Size(895, 378);
		this.dgMain.TabIndex = 4;
		this.dgMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.bandedGridView1 });
		this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(dgMain_KeyDown);
		this.bandedGridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.bandedGridView1.Appearance.BandPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.BandPanelBackground.Options.UseFont = true;
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
		this.bandedGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(231, 242, 254);
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
		this.bandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(132, 171, 228);
		this.bandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(221, 236, 254);
		this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
		this.bandedGridView1.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
		this.bandedGridView1.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 9.75f);
		this.bandedGridView1.Appearance.HeaderPanelBackground.Options.UseFont = true;
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
		this.bandedGridView1.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.BandPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.EvenRow.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.FilterPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.FooterPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.GroupFooter.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.GroupRow.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.bandedGridView1.AppearancePrint.HeaderPanel.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Lines.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.Lines.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.OddRow.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.OddRow.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.Preview.Options.UseBackColor = true;
		this.bandedGridView1.AppearancePrint.Preview.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 10f);
		this.bandedGridView1.AppearancePrint.Row.Options.UseFont = true;
		this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[3] { this.gridBand1, this.gridBand2, this.gridBand3 });
		this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[13]
		{
			this.bandedGridColumn1, this.bandedGridColumn2, this.bandedGridColumn3, this.bandedGridColumn4, this.bandedGridColumn5, this.gridColHoP, this.gridColBOT, this.gridColMOT, this.gridColEOT, this.bandedGridColumn10,
			this.bandedGridColumn11, this.bandedGridColumn6, this.bandedGridColumn7
		});
		this.bandedGridView1.DetailHeight = 239;
		styleFormatCondition.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition.Appearance.Options.UseForeColor = true;
		styleFormatCondition.ApplyToRow = true;
		styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition.Value1 = 9;
		this.bandedGridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition });
		this.bandedGridView1.GridControl = this.dgMain;
		this.bandedGridView1.IndicatorWidth = 23;
		this.bandedGridView1.Name = "bandedGridView1";
		this.bandedGridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
		this.bandedGridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
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
		this.bandedGridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(bandedGridView1_FocusedRowChanged);
		this.bandedGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(bandedGridView1_CellValueChanged);
		this.bandedGridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(bandedGridView1_CustomColumnDisplayText);
		this.bandedGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(bandedGridView1_KeyDown);
		this.bandedGridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(bandedGridView1_ValidatingEditor);
		this.bandedGridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(bandedGridView1_InvalidValueException);
		this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand1.Caption = "Student's Information";
		this.gridBand1.Columns.Add(this.bandedGridColumn1);
		this.gridBand1.Columns.Add(this.bandedGridColumn2);
		this.gridBand1.Columns.Add(this.bandedGridColumn3);
		this.gridBand1.Columns.Add(this.bandedGridColumn4);
		this.gridBand1.Columns.Add(this.bandedGridColumn5);
		this.gridBand1.Name = "gridBand1";
		this.gridBand1.OptionsBand.AllowHotTrack = false;
		this.gridBand1.OptionsBand.AllowMove = false;
		this.gridBand1.OptionsBand.AllowPress = false;
		this.gridBand1.VisibleIndex = 0;
		this.gridBand1.Width = 505;
		this.bandedGridColumn1.Caption = "#";
		this.bandedGridColumn1.MinWidth = 13;
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn1.Visible = true;
		this.bandedGridColumn1.Width = 29;
		this.bandedGridColumn2.Caption = "Name";
		this.bandedGridColumn2.FieldName = "Name";
		this.bandedGridColumn2.MinWidth = 13;
		this.bandedGridColumn2.Name = "bandedGridColumn2";
		this.bandedGridColumn2.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn2.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn2.Visible = true;
		this.bandedGridColumn2.Width = 242;
		this.bandedGridColumn3.Caption = "Stud#";
		this.bandedGridColumn3.FieldName = "Stud#";
		this.bandedGridColumn3.MinWidth = 13;
		this.bandedGridColumn3.Name = "bandedGridColumn3";
		this.bandedGridColumn3.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn3.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn3.Visible = true;
		this.bandedGridColumn3.Width = 105;
		this.bandedGridColumn4.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn4.Caption = "Sex";
		this.bandedGridColumn4.FieldName = "Sex";
		this.bandedGridColumn4.MinWidth = 13;
		this.bandedGridColumn4.Name = "bandedGridColumn4";
		this.bandedGridColumn4.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn4.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn4.Visible = true;
		this.bandedGridColumn4.Width = 53;
		this.bandedGridColumn5.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn5.Caption = "Stream";
		this.bandedGridColumn5.FieldName = "Stream";
		this.bandedGridColumn5.MinWidth = 13;
		this.bandedGridColumn5.Name = "bandedGridColumn5";
		this.bandedGridColumn5.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn5.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn5.Visible = true;
		this.bandedGridColumn5.Width = 76;
		this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand2.Caption = "Marks";
		this.gridBand2.Columns.Add(this.gridColHoP);
		this.gridBand2.Columns.Add(this.gridColBOT);
		this.gridBand2.Columns.Add(this.gridColMOT);
		this.gridBand2.Columns.Add(this.gridColEOT);
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.OptionsBand.AllowHotTrack = false;
		this.gridBand2.OptionsBand.AllowMove = false;
		this.gridBand2.OptionsBand.AllowPress = false;
		this.gridBand2.VisibleIndex = 1;
		this.gridBand2.Width = 201;
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
		this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
		this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.gridBand3.Caption = "Grading";
		this.gridBand3.Columns.Add(this.bandedGridColumn10);
		this.gridBand3.Columns.Add(this.bandedGridColumn11);
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.OptionsBand.AllowHotTrack = false;
		this.gridBand3.OptionsBand.AllowMove = false;
		this.gridBand3.OptionsBand.AllowPress = false;
		this.gridBand3.VisibleIndex = 2;
		this.gridBand3.Width = 301;
		this.bandedGridColumn10.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn10.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn10.Caption = "Score";
		this.bandedGridColumn10.FieldName = "Score";
		this.bandedGridColumn10.MinWidth = 13;
		this.bandedGridColumn10.Name = "bandedGridColumn10";
		this.bandedGridColumn10.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn10.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn10.Visible = true;
		this.bandedGridColumn10.Width = 142;
		this.bandedGridColumn11.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn11.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn11.Caption = "Grade";
		this.bandedGridColumn11.FieldName = "Grade";
		this.bandedGridColumn11.MinWidth = 13;
		this.bandedGridColumn11.Name = "bandedGridColumn11";
		this.bandedGridColumn11.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn11.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn11.Visible = true;
		this.bandedGridColumn11.Width = 159;
		this.bandedGridColumn6.Caption = "PaperId";
		this.bandedGridColumn6.FieldName = "PaperId";
		this.bandedGridColumn6.MinWidth = 13;
		this.bandedGridColumn6.Name = "bandedGridColumn6";
		this.bandedGridColumn6.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn6.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn6.Width = 50;
		this.bandedGridColumn7.Caption = "GradeScore";
		this.bandedGridColumn7.FieldName = "GradeScore";
		this.bandedGridColumn7.MinWidth = 13;
		this.bandedGridColumn7.Name = "bandedGridColumn7";
		this.bandedGridColumn7.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn7.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn7.Width = 50;
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
		this.timer1.Enabled = true;
		this.popupMenu1.Name = "popupMenu1";
		this.gridView2.Name = "gridView2";
		this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.panelControl2.Appearance.Options.UseBackColor = true;
		this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl2.Controls.Add(this.labelControl2);
		this.panelControl2.Controls.Add(this.labelControl1);
		this.panelControl2.Controls.Add(this.cboStream);
		this.panelControl2.Controls.Add(this.cboSelectedSubject);
		this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
		this.panelControl2.Location = new System.Drawing.Point(0, 0);
		this.panelControl2.Margin = new System.Windows.Forms.Padding(2);
		this.panelControl2.Name = "panelControl2";
		this.panelControl2.Size = new System.Drawing.Size(895, 33);
		this.panelControl2.TabIndex = 2;
		this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl2.Appearance.Options.UseFont = true;
		this.labelControl2.Appearance.Options.UseForeColor = true;
		this.labelControl2.Appearance.Options.UseTextOptions = true;
		this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl2.Location = new System.Drawing.Point(474, 6);
		this.labelControl2.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(56, 22);
		this.labelControl2.TabIndex = 3;
		this.labelControl2.Text = "Stream";
		this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseForeColor = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.labelControl1.Location = new System.Drawing.Point(665, 6);
		this.labelControl1.Margin = new System.Windows.Forms.Padding(2);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(56, 22);
		this.labelControl1.TabIndex = 2;
		this.labelControl1.Text = "Paper";
		this.cboStream.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.cboStream.Location = new System.Drawing.Point(534, 6);
		this.cboStream.Margin = new System.Windows.Forms.Padding(2);
		this.cboStream.Name = "cboStream";
		this.cboStream.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboStream.Properties.Appearance.Options.UseFont = true;
		this.cboStream.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboStream.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboStream.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboStream.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboStream.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboStream.Size = new System.Drawing.Size(127, 24);
		this.cboStream.TabIndex = 0;
		this.cboStream.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboStream_Closed);
		this.cboStream.EditValueChanged += new System.EventHandler(cboStream_EditValueChanged);
		this.cboStream.KeyDown += new System.Windows.Forms.KeyEventHandler(cboStream_KeyDown);
		this.cboSelectedSubject.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.cboSelectedSubject.Location = new System.Drawing.Point(723, 6);
		this.cboSelectedSubject.Margin = new System.Windows.Forms.Padding(2);
		this.cboSelectedSubject.Name = "cboSelectedSubject";
		this.cboSelectedSubject.Properties.AllowMouseWheel = false;
		this.cboSelectedSubject.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSelectedSubject.Properties.Appearance.Options.UseFont = true;
		this.cboSelectedSubject.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 10f);
		this.cboSelectedSubject.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboSelectedSubject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSelectedSubject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSelectedSubject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboSelectedSubject.Size = new System.Drawing.Size(168, 24);
		this.cboSelectedSubject.TabIndex = 0;
		this.cboSelectedSubject.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboSelectedSubject_Closed);
		this.cboSelectedSubject.EditValueChanged += new System.EventHandler(cboSelectedSubject_EditValueChanged);
		this.cboSelectedSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(cboSelectedSubject_KeyDown);
		this.tileControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.tileControl1.Dock = System.Windows.Forms.DockStyle.Top;
		this.tileControl1.Groups.Add(this.tileGroup1);
		this.tileControl1.Groups.Add(this.tileGroup3);
		this.tileControl1.Groups.Add(this.tileGroup2);
		this.tileControl1.IndentBetweenGroups = 0;
		this.tileControl1.IndentBetweenItems = 0;
		this.tileControl1.ItemPadding = new System.Windows.Forms.Padding(5);
		this.tileControl1.LayoutMode = DevExpress.XtraEditors.TileControlLayoutMode.Adaptive;
		this.tileControl1.Location = new System.Drawing.Point(0, 33);
		this.tileControl1.Margin = new System.Windows.Forms.Padding(2);
		this.tileControl1.MaxId = 10;
		this.tileControl1.Name = "tileControl1";
		this.tileControl1.Padding = new System.Windows.Forms.Padding(0);
		this.tileControl1.RowCount = 1;
		this.tileControl1.Size = new System.Drawing.Size(895, 68);
		this.tileControl1.TabIndex = 3;
		this.tileControl1.Text = "tileControl1";
		this.tileGroup1.Items.Add(this.tileItem1);
		this.tileGroup1.Items.Add(this.tileItemStudent);
		this.tileGroup1.Items.Add(this.tileItemClassSettings);
		this.tileGroup1.Name = "tileGroup1";
		this.tileGroup1.Text = "tileGroup1";
		this.tileItem1.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(64, 0, 64);
		this.tileItem1.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItem1.AppearanceItem.Normal.Options.UseBackColor = true;
		this.tileItem1.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileItemElement.AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
		tileItemElement.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12f);
		tileItemElement.Appearance.Hovered.Options.UseFont = true;
		tileItemElement.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12f);
		tileItemElement.Appearance.Normal.Options.UseFont = true;
		tileItemElement.Appearance.Normal.Options.UseTextOptions = true;
		tileItemElement.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		tileItemElement.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
		tileItemElement.Text = "Register Students";
		tileItemElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		this.tileItem1.Elements.Add(tileItemElement);
		this.tileItem1.Id = 0;
		this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItem1.Name = "tileItem1";
		this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItem1_ItemClick);
		this.tileItemStudent.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemStudent.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemStudent.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
		this.tileItemStudent.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement2.Text = "Drop Student";
		tileItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f);
		tileItemElement3.Appearance.Normal.Options.UseFont = true;
		tileItemElement3.Text = "Student";
		tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
		tileItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f);
		tileItemElement4.Appearance.Normal.Options.UseFont = true;
		tileItemElement4.Text = "StudentNum";
		this.tileItemStudent.Elements.Add(tileItemElement2);
		this.tileItemStudent.Elements.Add(tileItemElement3);
		this.tileItemStudent.Elements.Add(tileItemElement4);
		this.tileItemStudent.Id = 1;
		this.tileItemStudent.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemStudent.Name = "tileItemStudent";
		this.tileItemStudent.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemStudent_ItemClick);
		this.tileItemClassSettings.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemClassSettings.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemClassSettings.AppearanceItem.Normal.BackColor = System.Drawing.Color.DeepPink;
		this.tileItemClassSettings.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement5.Text = "Drop Class";
		tileItemElement6.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f);
		tileItemElement6.Appearance.Normal.Options.UseFont = true;
		tileItemElement6.Text = "Class";
		tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
		tileItemElement7.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f);
		tileItemElement7.Appearance.Normal.Options.UseFont = true;
		tileItemElement7.Text = "Subject";
		tileItemElement8.Text = "ClassTotal";
		tileItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
		this.tileItemClassSettings.Elements.Add(tileItemElement5);
		this.tileItemClassSettings.Elements.Add(tileItemElement6);
		this.tileItemClassSettings.Elements.Add(tileItemElement7);
		this.tileItemClassSettings.Elements.Add(tileItemElement8);
		this.tileItemClassSettings.Id = 2;
		this.tileItemClassSettings.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItemClassSettings.Name = "tileItemClassSettings";
		this.tileItemClassSettings.Visible = false;
		this.tileItemClassSettings.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemClassSettings_ItemClick);
		this.tileGroup3.Items.Add(this.tileItemStream);
		this.tileGroup3.Items.Add(this.tileItemTerm);
		this.tileGroup3.Name = "tileGroup3";
		this.tileGroup3.Text = "tileGroup3";
		this.tileItemStream.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemStream.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemStream.AppearanceItem.Normal.BackColor = System.Drawing.Color.Teal;
		this.tileItemStream.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement9.Text = "Stream Filter";
		tileItemElement10.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12f);
		tileItemElement10.Appearance.Normal.Options.UseFont = true;
		tileItemElement10.Text = "Entire Class";
		tileItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileItemElement11.Text = "FilteredClass";
		tileItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight;
		this.tileItemStream.Elements.Add(tileItemElement9);
		this.tileItemStream.Elements.Add(tileItemElement10);
		this.tileItemStream.Elements.Add(tileItemElement11);
		this.tileItemStream.Id = 8;
		this.tileItemStream.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemStream.Name = "tileItemStream";
		this.tileItemTerm.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemTerm.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemTerm.AppearanceItem.Normal.BackColor = System.Drawing.Color.SteelBlue;
		this.tileItemTerm.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement12.Text = "Term";
		tileItemElement13.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 10f);
		tileItemElement13.Appearance.Normal.Options.UseFont = true;
		tileItemElement13.Text = "term";
		tileItemElement13.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		tileItemElement14.Text = "initial";
		tileItemElement14.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight;
		this.tileItemTerm.Elements.Add(tileItemElement12);
		this.tileItemTerm.Elements.Add(tileItemElement13);
		this.tileItemTerm.Elements.Add(tileItemElement14);
		this.tileItemTerm.Id = 9;
		this.tileItemTerm.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemTerm.Name = "tileItemTerm";
		this.tileGroup2.Items.Add(this.tileItemExport);
		this.tileGroup2.Items.Add(this.tileItemImport);
		this.tileGroup2.Items.Add(this.tileItemPrint);
		this.tileGroup2.Name = "tileGroup2";
		this.tileGroup2.Text = "tileGroup2";
		this.tileItemExport.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemExport.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemExport.AppearanceItem.Normal.BackColor = System.Drawing.Color.Indigo;
		this.tileItemExport.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement15.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12f);
		tileItemElement15.Appearance.Normal.Options.UseFont = true;
		tileItemElement15.Text = "Export";
		tileItemElement15.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		this.tileItemExport.Elements.Add(tileItemElement15);
		this.tileItemExport.Id = 3;
		this.tileItemExport.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItemExport.Name = "tileItemExport";
		this.tileItemExport.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemExport_ItemClick);
		this.tileItemImport.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemImport.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemImport.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkOliveGreen;
		this.tileItemImport.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement16.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12f);
		tileItemElement16.Appearance.Normal.Options.UseFont = true;
		tileItemElement16.Text = "Import";
		tileItemElement16.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		this.tileItemImport.Elements.Add(tileItemElement16);
		this.tileItemImport.Id = 4;
		this.tileItemImport.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItemImport.Name = "tileItemImport";
		this.tileItemPrint.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.tileItemPrint.AppearanceItem.Hovered.Options.UseBackColor = true;
		this.tileItemPrint.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkKhaki;
		this.tileItemPrint.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement17.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 12f);
		tileItemElement17.Appearance.Normal.Options.UseFont = true;
		tileItemElement17.Text = "Print";
		tileItemElement17.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
		this.tileItemPrint.Elements.Add(tileItemElement17);
		this.tileItemPrint.Id = 5;
		this.tileItemPrint.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
		this.tileItemPrint.Name = "tileItemPrint";
		this.tileItemPrint.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemPrint_ItemClick);
		this.panelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.panelControl3.Appearance.Options.UseBackColor = true;
		this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl3.Controls.Add(this.pictureEdit1);
		this.panelControl3.Controls.Add(this.lblLANStatus);
		this.panelControl3.Controls.Add(this.lblInitial);
		this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panelControl3.Location = new System.Drawing.Point(0, 479);
		this.panelControl3.Margin = new System.Windows.Forms.Padding(2);
		this.panelControl3.Name = "panelControl3";
		this.panelControl3.Size = new System.Drawing.Size(895, 33);
		this.panelControl3.TabIndex = 4;
		this.pictureEdit1.Location = new System.Drawing.Point(7, 9);
		this.pictureEdit1.Margin = new System.Windows.Forms.Padding(2);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(17, 17);
		this.pictureEdit1.TabIndex = 2;
		this.lblLANStatus.Appearance.ForeColor = System.Drawing.Color.White;
		this.lblLANStatus.Appearance.Options.UseForeColor = true;
		this.lblLANStatus.Location = new System.Drawing.Point(33, 12);
		this.lblLANStatus.Margin = new System.Windows.Forms.Padding(2);
		this.lblLANStatus.Name = "lblLANStatus";
		this.lblLANStatus.Size = new System.Drawing.Size(0, 13);
		this.lblLANStatus.TabIndex = 1;
		this.lblInitial.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.lblInitial.Appearance.ForeColor = System.Drawing.Color.White;
		this.lblInitial.Appearance.Options.UseForeColor = true;
		this.lblInitial.Location = new System.Drawing.Point(867, 13);
		this.lblInitial.Margin = new System.Windows.Forms.Padding(2);
		this.lblInitial.Name = "lblInitial";
		this.lblInitial.Size = new System.Drawing.Size(20, 13);
		this.lblInitial.TabIndex = 0;
		this.lblInitial.Text = "GHF";
		this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
		this.flyoutPanel1.Location = new System.Drawing.Point(8, 105);
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
		this.flyoutPanel1.Size = new System.Drawing.Size(468, 441);
		this.flyoutPanel1.TabIndex = 6;
		this.flyoutPanel1.ButtonClick += new DevExpress.Utils.FlyoutPanelButtonClickEventHandler(flyoutPanel1_ButtonClick);
		this.flyoutPanelControl1.Controls.Add(this.gridControl1);
		this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
		this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
		this.flyoutPanelControl1.Margin = new System.Windows.Forms.Padding(2);
		this.flyoutPanelControl1.Name = "flyoutPanelControl1";
		this.flyoutPanelControl1.Size = new System.Drawing.Size(468, 407);
		this.flyoutPanelControl1.TabIndex = 0;
		this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(464, 403);
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
		this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[2] { this.gridColumn1, this.gridColumn2 });
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
		this.gridColumn2.VisibleIndex = 2;
		this.gridColumn2.Width = 50;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(895, 512);
		base.Controls.Add(this.flyoutPanel1);
		base.Controls.Add(this.dgMain);
		base.Controls.Add(this.panelControl3);
		base.Controls.Add(this.tileControl1);
		base.Controls.Add(this.panelControl2);
		base.KeyPreview = true;
		base.Name = "MainALevel";
		this.Text = "School Management Dynamics - Teachers' Workstation";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainWindow_FormClosing);
		base.Load += new System.EventHandler(MainWindow_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(MainALevel_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.popupMenu2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dgMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.popupMenu1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl2).EndInit();
		this.panelControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.cboStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSelectedSubject.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl3).EndInit();
		this.panelControl3.ResumeLayout(false);
		this.panelControl3.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).EndInit();
		this.flyoutPanel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).EndInit();
		this.flyoutPanelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		base.ResumeLayout(false);
	}
}
