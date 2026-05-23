using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.GradingScales;
using AlienAge.TermlySettings.Thematic;
using DevExpress.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.Utils.Animation;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace I_Xtreme.NavigationForms;

public class MainOLevelNewCur : XtraUserControl
{
	private OLevelGradingScale gradingScale = OLevelGradingScale.Instance;

	private int i = 0;

	private string _Student = string.Empty;

	private string _Class = string.Empty;

	private string _Term = string.Empty;

	private string _Stream = string.Empty;

	private DataTable dt;

	private int u1f = 0;

	private int u2f = 0;

	private int u3f = 0;

	private int u4f = 0;

	private int u5f = 0;

	private int u6f = 0;

	private static readonly string connectionString = DataConnection.ConnectToDatabase();

	public NavigateToHome EnableDisableButton;

	private DataTable _dt;

	private IContainer components = null;

	private MyGridControl dgMain;

	private Timer tmUpdate;

	private BarSubItem barSubItem9;

	private BackgroundWorker bgSaveMarks;

	private PrintingSystem printingSystem1;

	private PrintableComponentLink printableComponentLink1;

	private Timer timer1;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;

	private GridView repositoryItemGridLookUpEdit1View;

	private MyBandedGridView bandedGridView1;

	private FlyoutPanel flyoutPanel1;

	private FlyoutPanelControl flyoutPanelControl1;

	private GridControl gridControl1;

	private GridView gridView1;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private BandedGridColumn colU1;

	private BandedGridColumn colU2;

	private BandedGridColumn colU3;

	private BandedGridColumn colU4;

	private BandedGridColumn colU5;

	private BandedGridColumn colU6;

	private BandedGridColumn bandedGridColumn16;

	private BandedGridColumn bandedGridColumn17;

	private BandedGridColumn bandedGridColumn18;

	private NavigationFrame navigationFrame1;

	private NavigationPage navPageLO;

	private NavigationPage navPage20;

	private MyGridControl dgMain20;

	private MyBandedGridView gv20;

	private BandedGridColumn colScore1;

	private BandedGridColumn colScore2;

	private BandedGridColumn colScore3;

	private BandedGridColumn colScore4;

	private BandedGridColumn colScore5;

	private BandedGridColumn colScore6;

	private BandedGridColumn bandedGridColumn24;

	private BandedGridColumn bandedGridColumn26;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;

	private GridView gridView2;

	private NavigationPage navPage100;

	private MyGridControl dgMain100;

	private MyBandedGridView gv100;

	private BandedGridColumn colHund1;

	private BandedGridColumn colHund2;

	private BandedGridColumn colHund3;

	private BandedGridColumn colHund4;

	private BandedGridColumn colHund5;

	private BandedGridColumn colHund6;

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

	private BandedGridColumn bandedGridColumn41;

	private BandedGridColumn bandedGridColumn43;

	private BandedGridColumn bandedGridColumn23;

	private BandedGridColumn bandedGridColumn22;

	private BandedGridColumn bandedGridColumn40;

	private RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit4;

	private GridView gridView4;

	private BandedGridColumn bandedGridColumn25;

	private GridColumn gridColumn3;

	private NavigationPage navPage10;

	private MyGridControl dgMain10;

	private MyBandedGridView gv10;

	private BandedGridColumn colT1;

	private BandedGridColumn colT2;

	private BandedGridColumn colT3;

	private BandedGridColumn colT4;

	private BandedGridColumn colT5;

	private BandedGridColumn colT6;

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

	private VGridControl vGridControl1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit1;

	private RepositoryItemMemoEdit repositoryItemMemoEdit2;

	private RepositoryItemMemoEdit repositoryItemMemoEdit3;

	private EditorRow rowId;

	private EditorRow row1;

	private EditorRow row3;

	private EditorRow row4;

	private EditorRow row5;

	private EditorRow row6;

	private EditorRow row7;

	private EditorRow row8;

	private EditorRow row9;

	private EditorRow row10;

	private EditorRow row11;

	private PanelControl panelControl1;

	private TileItem tileItem1;

	private BandedGridColumn bandedGridColumn37;

	private BandedGridColumn bandedGridColumn39;

	private BandedGridColumn bandedGridColumn45;

	private BandedGridColumn bandedGridColumn38;

	private NavigationPage navPageOtherComp;

	private VGridControl vGridControl2;

	private RepositoryItemMemoEdit repositoryItemMemoEdit4;

	private RepositoryItemMemoEdit repositoryItemMemoEdit5;

	private RepositoryItemMemoEdit repositoryItemMemoEdit6;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private EditorRow GamesAndSports;

	private EditorRow ProjectTitle;

	private EditorRow Project;

	private EditorRow Clubs;

	private FlyoutPanel flyoutPanel2;

	private FlyoutPanelControl flyoutPanelControl2;

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

	private EditorRow row;

	private BandedGridColumn colProject;

	private SplitContainerControl splitContainerControl3;

	private GroupControl groupControl1;

	private GridControl gridControl2;

	private GridView gridView6;

	private GridColumn colNo;

	private GridColumn gridColumn13;

	private GridColumn gridColumn14;

	private GridBand gridBand2;

	private BandedGridColumn bandedGridColumn1;

	private GridBand gridBand3;

	private GridBand gridBand5;

	private BandedGridColumn bandedGridColumn3;

	private GridBand gridBand6;

	private GridBand gridBand8;

	private BandedGridColumn bandedGridColumn4;

	private GridBand gridBand9;

	private GridBand gridBand11;

	private BandedGridColumn bandedGridColumn5;

	private GridBand gridBand12;

	private GridBand gridBand14;

	private BandedGridColumn bandedGridColumn2;

	private GridBand gridBandProject;

	private GridBand gridBand15;

	private DataTable dtEOY { get; set; }

	public void NavigateToHomeCallFN(bool ShowMenu)
	{
		if (ShowMenu)
		{
			splitContainerControl3.PanelVisibility = SplitPanelVisibility.Both;
		}
		else
		{
			splitContainerControl3.PanelVisibility = SplitPanelVisibility.Panel2;
		}
		navigationFrame1.SelectedPageIndex = 0;
	}

	public MainOLevelNewCur(string _Class, string _Stream, string _Term)
	{
		InitializeComponent();
		this._Class = _Class;
		this._Term = _Term;
		this._Stream = _Stream;
		LoadStudents();
		dtEOY = gradingScale.EndOfYearScale;
	}

	private void LoadStudents()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT fullName,StudentNumber FROM tbl_Stud WHERE ClassId='{_Class}' AND StreamId='{_Stream}'", connectionString);
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		gridControl2.DataSource = dataTable.DefaultView;
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

	private bool ProjectUsed(string _Subject)
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

	private void LoadOLevelMarks(int pageIndex, string StudentNumber)
	{
		try
		{
			string text = $"SELECT U1,U2,U3,U4,U5,U6,TTLPoints,AvLO,TUnits,ETA,ETA80,SubjectId,AvMark,Category,ETAv FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND ClassId='{_Class}' AND StudentNumber='{StudentNumber}'";
			string text2 = $"SELECT T1,T2,T3,T4,T5,T6,OutOfTen,ETA80,P1,SubjectId,TUnits,AvMark,ETA,Category,ETAv FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND ClassId='{_Class}' AND StudentNumber='{StudentNumber}'";
			string text3 = $"SELECT Score1,Score2,Score3,Score4,Score5,Score6,OutOfTwenty,ETA80,P1,SubjectId,TUnits,AvMark,ETA,Category,ETAv FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND ClassId='{_Class}' AND StudentNumber='{StudentNumber}'";
			string text4 = $"SELECT Hund1,Hund2,Hund3,Hund4,Hund5,Hund6,OutOfHund,AvMark,ETA,ETA80,SubjectId,TUnits,Category,ETAv FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND ClassId='{_Class}' AND StudentNumber='{StudentNumber}'";
			string text5 = $"SELECT TUnits,AvMark,ETA,Category,ETAv,ETA80,SubjectId FROM tbl_Scores_OL_Report WHERE SemesterId='{_Term}' AND ClassId='{_Class}' AND StudentNumber='{StudentNumber}'";
			string selectCommandText = "";
			switch (pageIndex)
			{
			case 1:
				selectCommandText = text;
				break;
			case 2:
				selectCommandText = text2;
				break;
			case 3:
				selectCommandText = text3;
				break;
			case 4:
				selectCommandText = text4;
				break;
			case 5:
				selectCommandText = text5;
				break;
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, connectionString);
			dt = new DataTable();
			sqlDataAdapter.Fill(dt);
			if (dt.Rows.Count > 0)
			{
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
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void MainWindow_Load(object sender, EventArgs e)
	{
		tmUpdate.Enabled = true;
	}

	private void bandedGridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (bandedGridView1.FocusedRowHandle > -1 && (bandedGridView1.FocusedColumn != bandedGridView1.Columns["StudentNumber"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["fullName"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["StreamId"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["Sex"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["TTLPoints"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["AvMark"]))
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
			Application.Exit();
		}
	}

	private void xtraTabControl1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
		{
			e.Handled = true;
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

	private void MarksCalculator(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e, int UnitsUsed, string _Subject)
	{
		switch (UnitsUsed)
		{
		case 1:
			u1f = 1;
			u2f = 0;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 2:
			u1f = 1;
			u2f = 1;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 3:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 4:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 0;
			u6f = 0;
			break;
		case 5:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 0;
			break;
		case 6:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 1;
			break;
		}
		if (!(e.Column.FieldName == "U1") && !(e.Column.FieldName == "U2") && !(e.Column.FieldName == "U3") && !(e.Column.FieldName == "U4") && !(e.Column.FieldName == "U5") && !(e.Column.FieldName == "U6"))
		{
			return;
		}
		int rowHandle = e.RowHandle;
		double result = (double.TryParse(bandedGridView1.GetRowCellValue(rowHandle, "U1").ToString(), out result) ? result : 0.0);
		double result2 = (double.TryParse(bandedGridView1.GetRowCellValue(rowHandle, "U2").ToString(), out result2) ? result2 : 0.0);
		double result3 = (double.TryParse(bandedGridView1.GetRowCellValue(rowHandle, "U3").ToString(), out result3) ? result3 : 0.0);
		double result4 = (double.TryParse(bandedGridView1.GetRowCellValue(rowHandle, "U4").ToString(), out result4) ? result4 : 0.0);
		double result5 = (double.TryParse(bandedGridView1.GetRowCellValue(rowHandle, "U5").ToString(), out result5) ? result5 : 0.0);
		double result6 = (double.TryParse(bandedGridView1.GetRowCellValue(rowHandle, "U6").ToString(), out result6) ? result6 : 0.0);
		double result7 = (double.TryParse(e.Value.ToString(), out result7) ? result7 : 0.0);
		double num = Math.Round(result7 / 3.0 * 100.0, 0, MidpointRounding.AwayFromZero);
		double num2 = Math.Round(result7 / 3.0 * 20.0, 0, MidpointRounding.AwayFromZero);
		double num3 = Math.Round(result7 / 3.0 * 10.0, 0, MidpointRounding.AwayFromZero);
		double num4 = result + result2 + result3 + result4 + result5 + result6;
		double num5 = Convert.ToDouble((num4 / (double)UnitsUsed).ToString().PadRight(5).Substring(0, 3));
		double value = num5 / 3.0 * 20.0;
		double value2 = num5 / 3.0 * 10.0;
		double value3 = num5 / 3.0 * 100.0;
		double num6 = Math.Round(value, 1, MidpointRounding.AwayFromZero);
		double num7 = Math.Round(value2, 1, MidpointRounding.AwayFromZero);
		double num8 = Math.Round(value3, 1, MidpointRounding.AwayFromZero);
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Column.FieldName;
		string arg = fieldName.PadRight(3).Substring(1, 2).Trim();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET U{0}=@U{0},Score{0}=@Score{0},Hund{0}=@Hund{0},T{0}=@T{0},AvLo=@AvLo,TTLPoints=@TTLPoints,OutOfTwenty=@OutOfTwenty,OutOfHund=@OutOfHund,OutOfTen=@OutOfTen WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
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
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", e.Value.ToString());
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", num2);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", num3);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", num);
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num8);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num6);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num7);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num5);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num4);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num5);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			bandedGridView1.SetRowCellValue(e.RowHandle, "TTLPoints", num4);
			bandedGridView1.SetRowCellValue(e.RowHandle, "OutOfTwenty", num6);
			bandedGridView1.SetRowCellValue(e.RowHandle, "AvLO", num5);
		}
		sqlConnection.Close();
	}

	private void MarksCalculator10(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e, int UnitsUsed, string _Subject)
	{
		switch (UnitsUsed)
		{
		case 1:
			u1f = 1;
			u2f = 0;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 2:
			u1f = 1;
			u2f = 1;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 3:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 4:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 0;
			u6f = 0;
			break;
		case 5:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 0;
			break;
		case 6:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 1;
			break;
		}
		if (!(e.Column.FieldName == "T1") && !(e.Column.FieldName == "T2") && !(e.Column.FieldName == "T3") && !(e.Column.FieldName == "T4") && !(e.Column.FieldName == "T5") && !(e.Column.FieldName == "T6") && !(e.Column.FieldName == "P1"))
		{
			return;
		}
		int rowHandle = e.RowHandle;
		double result = (double.TryParse(gv10.GetRowCellValue(rowHandle, "T1").ToString(), out result) ? result : 0.0) * (double)u1f;
		double result2 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "T2").ToString(), out result2) ? result2 : 0.0) * (double)u2f;
		double result3 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "T3").ToString(), out result3) ? result3 : 0.0) * (double)u3f;
		double result4 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "T4").ToString(), out result4) ? result4 : 0.0) * (double)u4f;
		double result5 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "T5").ToString(), out result5) ? result5 : 0.0) * (double)u5f;
		double result6 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "T6").ToString(), out result6) ? result6 : 0.0) * (double)u6f;
		double result7 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "P1").ToString(), out result7) ? result7 : 0.0);
		double result8 = (double.TryParse(gv10.GetRowCellValue(rowHandle, "ETA80").ToString(), out result8) ? result8 : 0.0);
		double num = result + result2 + result3 + result4 + result5 + result6;
		double value = result / 10.0 * 3.0;
		double num2 = Math.Round(value, 1);
		double value2 = result2 / 10.0 * 3.0;
		double num3 = Math.Round(value2, 1);
		double value3 = result3 / 10.0 * 3.0;
		double num4 = Math.Round(value3, 1);
		double value4 = result4 / 10.0 * 3.0;
		double num5 = Math.Round(value4, 1);
		double value5 = result5 / 10.0 * 3.0;
		double num6 = Math.Round(value5, 1);
		double value6 = result6 / 10.0 * 3.0;
		double num7 = Math.Round(value6, 1);
		double value7 = result7 / 10.0 * 3.0;
		double num8 = Math.Round(value7, 1);
		double num9 = num2 + num3 + num4 + num5 + num6 + num7;
		double num10 = Math.Round(num9 / (double)UnitsUsed, 1);
		double num11 = Math.Round(num9 / (double)(UnitsUsed * 3) * 20.0, 1, MidpointRounding.AwayFromZero);
		double num12 = num / (double)UnitsUsed;
		double num13 = Math.Round(num12, 1, MidpointRounding.AwayFromZero);
		double value8 = num12 / 10.0 * 20.0;
		double num14 = Math.Round(value8, 1, MidpointRounding.AwayFromZero);
		double value9 = num12 / 10.0 * 100.0;
		double num15 = Math.Round(value9, 1, MidpointRounding.AwayFromZero);
		double result9 = (double.TryParse(e.Value.ToString(), out result9) ? result9 : 0.0);
		double value10 = Math.Round(result9 / 10.0 * 20.0, 0, MidpointRounding.AwayFromZero);
		double value11 = Math.Round(result9 / 10.0 * 100.0, 0, MidpointRounding.AwayFromZero);
		double value12 = result9 / 10.0 * 3.0;
		value12 = Math.Round(value12, 1);
		double avgScore = num14 + result8;
		string key = EOYYearGrade(avgScore).Key;
		string value13 = EOYYearGrade(avgScore).Value;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string arg = e.Column.FieldName.ToString().PadRight(3).Substring(1, 2)
			.Trim();
		double num16 = Math.Round((num14 + result8) / 100.0 * 3.0, 1);
		string value14 = gradingScale.GetGradingScale(num10).Value;
		string value15 = gradingScale.GetGradingScale(num16).Value;
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET T{0}=@T{0},Hund{0}=@Hund{0},U{0}=@U{0},Score{0}=@Score{0},OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen,AvMark=@AvMark,TTLPoints=@TTLPoints,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,Score100=@Score100,P1=@P1,P2=@P2,P4=@P4,P5=@P5,P6=@P6,Category=@Category WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
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
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", result9);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", value12);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", Math.Round(value10, 0, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", Math.Round(value11, 0, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			if (ProjectUsed(_Subject))
			{
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P1", result7);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P2", num13 + result7);
				sqlParameter.Direction = ParameterDirection.Input;
				double scoreOutOf = Math.Round((num13 + result7) / 20.0 * 3.0, 1);
				string value16 = gradingScale.GetGradingScale(scoreOutOf).Value;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P4", value16);
				sqlParameter.Direction = ParameterDirection.Input;
			}
			else
			{
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P1", DBNull.Value);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P2", num14);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@P4", value14);
				sqlParameter.Direction = ParameterDirection.Input;
			}
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num13);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num14);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num15);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@TTLPoints", num9);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num14 + result8);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value14);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value15);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num16);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P5", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P6", value13);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gv10.SetRowCellValue(e.RowHandle, "OutOfTen", num13);
		}
		sqlConnection.Close();
	}

	private void MarksCalculator20(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e, int UnitsUsed, string _Subject)
	{
		switch (UnitsUsed)
		{
		case 1:
			u1f = 1;
			u2f = 0;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 2:
			u1f = 1;
			u2f = 1;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 3:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 4:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 0;
			u6f = 0;
			break;
		case 5:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 0;
			break;
		case 6:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 1;
			break;
		}
		if (!(e.Column.FieldName == "Score1") && !(e.Column.FieldName == "Score2") && !(e.Column.FieldName == "Score3") && !(e.Column.FieldName == "Score4") && !(e.Column.FieldName == "Score5") && !(e.Column.FieldName == "Score6"))
		{
			return;
		}
		int rowHandle = e.RowHandle;
		double result = (double.TryParse(gv20.GetRowCellValue(rowHandle, "Score1").ToString(), out result) ? result : 0.0) * (double)u1f;
		double result2 = (double.TryParse(gv20.GetRowCellValue(rowHandle, "Score2").ToString(), out result2) ? result2 : 0.0) * (double)u2f;
		double result3 = (double.TryParse(gv20.GetRowCellValue(rowHandle, "Score3").ToString(), out result3) ? result3 : 0.0) * (double)u3f;
		double result4 = (double.TryParse(gv20.GetRowCellValue(rowHandle, "Score4").ToString(), out result4) ? result4 : 0.0) * (double)u4f;
		double result5 = (double.TryParse(gv20.GetRowCellValue(rowHandle, "Score5").ToString(), out result5) ? result5 : 0.0) * (double)u5f;
		double result6 = (double.TryParse(gv20.GetRowCellValue(rowHandle, "Score6").ToString(), out result6) ? result6 : 0.0) * (double)u6f;
		double result7 = (double.TryParse(gv20.GetRowCellValue(rowHandle, "ETA80").ToString(), out result7) ? result7 : 0.0);
		double num = result + result2 + result3 + result4 + result5 + result6;
		double value = result / 20.0 * 3.0;
		double num2 = Math.Round(value, 1);
		double value2 = result2 / 20.0 * 3.0;
		double num3 = Math.Round(value2, 1);
		double value3 = result3 / 20.0 * 3.0;
		double num4 = Math.Round(value3, 1);
		double value4 = result4 / 20.0 * 3.0;
		double num5 = Math.Round(value4, 1);
		double value5 = result5 / 20.0 * 3.0;
		double num6 = Math.Round(value5, 1);
		double value6 = result6 / 20.0 * 3.0;
		double num7 = Math.Round(value6, 1);
		double num8 = num2 + num3 + num4 + num5 + num6 + num7;
		double num9 = Math.Round(num8 / (double)UnitsUsed, 1);
		double num10 = Math.Round(num8 / (double)(UnitsUsed * 3) * 20.0, 1, MidpointRounding.AwayFromZero);
		double num11 = num / (double)UnitsUsed;
		double num12 = Math.Round(num11, 1, MidpointRounding.AwayFromZero);
		double value7 = num11 / 20.0 * 10.0;
		double num13 = Math.Round(value7, 1, MidpointRounding.AwayFromZero);
		double value8 = num11 / 20.0 * 100.0;
		double num14 = Math.Round(value8, 1, MidpointRounding.AwayFromZero);
		double result8 = (double.TryParse(e.Value.ToString(), out result8) ? result8 : 0.0);
		double num15 = Math.Round(result8 / 20.0 * 10.0, 1, MidpointRounding.AwayFromZero);
		double num16 = Math.Round(result8 / 20.0 * 100.0, 0, MidpointRounding.AwayFromZero);
		double value9 = result8 / 20.0 * 3.0;
		value9 = Math.Round(value9, 1);
		double avgScore = num12 + result7;
		string key = EOYYearGrade(avgScore).Key;
		string value10 = EOYYearGrade(avgScore).Value;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Column.FieldName;
		string arg = fieldName.PadRight(7).Substring(5, 2).Trim();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET Score{0}=@Score{0},Hund{0}=@Hund{0},U{0}=@U{0},T{0}=@T{0},OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen,AvMark=@AvMark,TTLPoints=@TTLPoints,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,Score100=@Score100,P5=@P5,P6=@P6,Category=@Category WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
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
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", result8);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", num16);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", value9);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", num15);
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num14);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num13);
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
		double num17 = Math.Round((num12 + result7) / 100.0 * 3.0, 1);
		string value11 = gradingScale.GetGradingScale(num9).Value;
		string value12 = gradingScale.GetGradingScale(num17).Value;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num9);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num17);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P5", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P6", value10);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gv20.SetRowCellValue(e.RowHandle, "OutOfTwenty", num12);
		}
		sqlConnection.Close();
	}

	private void MarksCalculator100(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e, int UnitsUsed, string _Subject)
	{
		switch (UnitsUsed)
		{
		case 1:
			u1f = 1;
			u2f = 0;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 2:
			u1f = 1;
			u2f = 1;
			u3f = 0;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 3:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 0;
			u5f = 0;
			u6f = 0;
			break;
		case 4:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 0;
			u6f = 0;
			break;
		case 5:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 0;
			break;
		case 6:
			u1f = 1;
			u2f = 1;
			u3f = 1;
			u4f = 1;
			u5f = 1;
			u6f = 1;
			break;
		}
		if (!(e.Column.FieldName == "Hund1") && !(e.Column.FieldName == "Hund2") && !(e.Column.FieldName == "Hund3") && !(e.Column.FieldName == "Hund4") && !(e.Column.FieldName == "Hund5") && !(e.Column.FieldName == "Hund6"))
		{
			return;
		}
		int rowHandle = e.RowHandle;
		double result = (double.TryParse(gv100.GetRowCellValue(rowHandle, "Hund1").ToString(), out result) ? result : 0.0) * (double)u1f;
		double result2 = (double.TryParse(gv100.GetRowCellValue(rowHandle, "Hund2").ToString(), out result2) ? result2 : 0.0) * (double)u2f;
		double result3 = (double.TryParse(gv100.GetRowCellValue(rowHandle, "Hund3").ToString(), out result3) ? result3 : 0.0) * (double)u3f;
		double result4 = (double.TryParse(gv100.GetRowCellValue(rowHandle, "Hund4").ToString(), out result4) ? result4 : 0.0) * (double)u4f;
		double result5 = (double.TryParse(gv100.GetRowCellValue(rowHandle, "Hund5").ToString(), out result5) ? result5 : 0.0) * (double)u5f;
		double result6 = (double.TryParse(gv100.GetRowCellValue(rowHandle, "Hund6").ToString(), out result6) ? result6 : 0.0) * (double)u6f;
		double result7 = (double.TryParse(gv100.GetRowCellValue(rowHandle, "ETA80").ToString(), out result7) ? result7 : 0.0);
		double num = result + result2 + result3 + result4 + result5 + result6;
		double value = result / 100.0 * 3.0;
		double num2 = Math.Round(value, 1);
		double value2 = result2 / 100.0 * 3.0;
		double num3 = Math.Round(value2, 1);
		double value3 = result3 / 100.0 * 3.0;
		double num4 = Math.Round(value3, 1);
		double value4 = result4 / 100.0 * 3.0;
		double num5 = Math.Round(value4, 1);
		double value5 = result5 / 100.0 * 3.0;
		double num6 = Math.Round(value5, 1);
		double value6 = result6 / 100.0 * 3.0;
		double num7 = Math.Round(value6, 1);
		double num8 = num2 + num3 + num4 + num5 + num6 + num7;
		double num9 = Math.Round(num8 / (double)UnitsUsed, 1);
		double num10 = Math.Round(num8 / (double)(UnitsUsed * 3) * 20.0, 1, MidpointRounding.AwayFromZero);
		double num11 = num / (double)UnitsUsed;
		double num12 = Math.Round(num11, 1, MidpointRounding.AwayFromZero);
		double value7 = num11 / 100.0 * 20.0;
		double num13 = Math.Round(value7, 1, MidpointRounding.AwayFromZero);
		double value8 = num11 / 100.0 * 10.0;
		double num14 = Math.Round(value8, 1, MidpointRounding.AwayFromZero);
		double result8 = (double.TryParse(e.Value.ToString(), out result8) ? result8 : 0.0);
		double num15 = result8 / 100.0 * 20.0;
		double value9 = result8 / 100.0 * 10.0;
		double value10 = num15 / 20.0 * 3.0;
		value10 = Math.Round(value10, 1);
		double avgScore = num13 + result7;
		string key = EOYYearGrade(avgScore).Key;
		string value11 = EOYYearGrade(avgScore).Value;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string fieldName = e.Column.FieldName;
		string arg = fieldName.PadRight(6).Substring(4, 2).Trim();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("UPDATE tbl_Scores_OL_Report SET Hund{0}=@Hund{0},Score{0}=@Score{0},U{0}=@U{0},T{0}=@T{0},TTLPoints=@TTLPoints,OutOfHund=@OutOfHund,OutOfTwenty=@OutOfTwenty,OutOfTen=@OutOfTen,AvMark=@AvMark,ETAv=@ETAv,AvLO=@AvLO,Comment=@Comment,Descriptor100=@Descriptor100,Score100=@Score100,P5=@P5,P6=@P6,Category=@Category WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId", arg),
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter;
		if (e.Value.ToString() == "-")
		{
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
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Hund{arg}", result8);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@Score{arg}", Math.Round(num15, 1, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@T{arg}", Math.Round(value9, 1, MidpointRounding.AwayFromZero));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue($"@U{arg}", value10);
			sqlParameter.Direction = ParameterDirection.Input;
		}
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfHund", num12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTwenty", num13);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@OutOfTen", num14);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvMark", num10);
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
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num13 + result7);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P5", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P6", value11);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		double num16 = Math.Round((num13 + result7) / 100.0 * 3.0, 1);
		string value12 = gradingScale.GetGradingScale(num9).Value;
		string value13 = gradingScale.GetGradingScale(num16).Value;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@AvLo", num9);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Comment", value12);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value13);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num16);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gv100.SetRowCellValue(e.RowHandle, "OutOfHund", num12);
		}
		sqlConnection.Close();
	}

	private void MarksCalculatorEOT(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e, string _Subject)
	{
		if (!(e.Column.FieldName == "ETA"))
		{
			return;
		}
		int rowHandle = e.RowHandle;
		double result = (double.TryParse(gvEOT.GetRowCellValue(rowHandle, "AvMark").ToString(), out result) ? result : 0.0);
		double result2 = (double.TryParse(e.Value.ToString(), out result2) ? result2 : 0.0);
		double num = Math.Round(result2 / 100.0 * 80.0, 1, MidpointRounding.AwayFromZero);
		double num2 = Math.Round(result + num, 0, MidpointRounding.AwayFromZero);
		string key = EOYYearGrade(num2).Key;
		string value = EOYYearGrade(num2).Value;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "UPDATE tbl_Scores_OL_Report SET ETA=@ETA, ETA80=@ETA80,ETAv=@ETAv,Descriptor100=@Descriptor100,Score100=@Score100,P5=@P5,P6=@P6,Category=@Category WHERE StudentNumber=@StudentNumber AND SubjectId=@SubjectId AND ClassId=@ClassId AND SemesterId=@SemesterId",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@ETA", result2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETA80", num);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ETAv", num2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", _Student);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", _Subject);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", _Class);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", _Term);
		sqlParameter.Direction = ParameterDirection.Input;
		double num3 = Math.Round(num2 / 100.0 * 3.0, 1);
		string value2 = gradingScale.GetGradingScale(num3).Value;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Descriptor100", value2);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Score100", num3);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P5", key);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@P6", value);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("@Category", key);
		sqlParameter.Direction = ParameterDirection.Input;
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			gvEOT.SetRowCellValue(e.RowHandle, "ETA80", num);
			gvEOT.SetRowCellValue(e.RowHandle, "ETAv", num2);
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
				int result = (int.TryParse(bandedGridView1.GetRowCellValue(e.RowHandle, "TUnits").ToString(), out result) ? result : 0);
				string subject = bandedGridView1.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
				MarksCalculator(e, result, subject);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void bgSaveMarks_DoWork(object sender, DoWorkEventArgs e)
	{
		ThematicRatios.InitializeRatios(_Class, _Term);
		ExamsOutputString.InitializeExamsOutputStrings(_Class, _Term);
	}

	private void bgSaveMarks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		tmUpdate.Enabled = true;
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
		printableComponentLink1.ShowPreview();
	}

	private void gv20_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gv20.FocusedRowHandle > -1 && (gv20.FocusedColumn != bandedGridView1.Columns["StudentNumber"] || gv20.FocusedColumn != bandedGridView1.Columns["fullName"] || gv20.FocusedColumn != bandedGridView1.Columns["StreamId"] || gv20.FocusedColumn != bandedGridView1.Columns["Sex"] || gv20.FocusedColumn != bandedGridView1.Columns["bandedGridColumn6"] || gv20.FocusedColumn != bandedGridView1.Columns["OutOfTwenty"]))
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

	private void gv100_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if (gv100.FocusedRowHandle > -1 && (bandedGridView1.FocusedColumn != bandedGridView1.Columns["StudentNumber"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["fullName"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["StreamId"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["Sex"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["bandedGridColumn27"] || bandedGridView1.FocusedColumn != bandedGridView1.Columns["OutOfHund"]))
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
		try
		{
			if (navigationFrame1.SelectedPage == navPage20)
			{
				int result = (int.TryParse(gv20.GetRowCellValue(e.RowHandle, "TUnits").ToString(), out result) ? result : 0);
				string subject = gv20.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
				MarksCalculator20(e, result, subject);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gv100_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		try
		{
			if (navigationFrame1.SelectedPage == navPage100)
			{
				int result = (int.TryParse(gv100.GetRowCellValue(e.RowHandle, "TUnits").ToString(), out result) ? result : 0);
				string subject = gv100.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
				MarksCalculator100(e, result, subject);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gvEOT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		if (navigationFrame1.SelectedPage == navPageEOT)
		{
			string subject = gvEOT.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
			MarksCalculatorEOT(e, subject);
		}
	}

	private void gvEOT_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == string.Empty)
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void SetPanelVisibility(bool both)
	{
		if (both)
		{
			splitContainerControl3.PanelVisibility = SplitPanelVisibility.Both;
		}
		else
		{
			splitContainerControl3.PanelVisibility = SplitPanelVisibility.Panel2;
		}
	}

	private void tileItemLO_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageLO;
		SetPanelVisibility(both: true);
		EnableDisableButton(ShowMenu: true);
	}

	private void tileItemR10_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPage10;
		SetPanelVisibility(both: true);
		EnableDisableButton(ShowMenu: true);
	}

	private void tileItemR20_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPage20;
		SetPanelVisibility(both: true);
		EnableDisableButton(ShowMenu: true);
	}

	private void tileItemR100_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPage100;
		SetPanelVisibility(both: true);
		EnableDisableButton(ShowMenu: true);
	}

	private void tileItemREOT_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageEOT;
		SetPanelVisibility(both: true);
		EnableDisableButton(ShowMenu: true);
	}

	private void tileItemRDes_ItemClick(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageDescr;
		SetPanelVisibility(both: true);
		EnableDisableButton(ShowMenu: true);
	}

	private void LoadScoreSheet(string StudentNo)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM OLevelReportNC WHERE StudentNo='{StudentNo}' AND ClassId='{_Class}' AND SemesterId='{_Term}'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		vGridControl1.DataSource = dataTable.DefaultView;
	}

	private void gvDescriptive_RowClick(object sender, RowClickEventArgs e)
	{
		if (e.RowHandle > -1)
		{
			LoadScoreSheet(_Student);
		}
	}

	private void gvDescriptive_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void UpdateMarks(string col, string values, long Id)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string commandText = string.Format("UPDATE OLevelReportNC SET {0}=@{0} WHERE Id={1} ", col, Id);
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = commandText,
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add($"{col}", SqlDbType.NVarChar, 500);
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
		string fieldName = e.Row.Properties.FieldName;
		long id = Convert.ToInt64(vGridControl1.GetCellValue(rowId, e.RecordIndex).ToString());
		UpdateMarks(fieldName, values, id);
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
		printableComponentLink1.ShowPreview();
	}

	private void gv10_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
	{
		try
		{
			if (navigationFrame1.SelectedPage == navPage10)
			{
				int result = (int.TryParse(gv10.GetRowCellValue(e.RowHandle, "TUnits").ToString(), out result) ? result : 0);
				string subject = gv10.GetRowCellValue(e.RowHandle, "SubjectId").ToString();
				MarksCalculator10(e, result, subject);
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
		if (gv10.FocusedRowHandle > -1 && (gv10.FocusedColumn != gv10.Columns["StudentNumber"] || gv10.FocusedColumn != gv10.Columns["fullName"] || gv10.FocusedColumn != gv10.Columns["StreamId"] || gv10.FocusedColumn != gv10.Columns["Sex"] || gv10.FocusedColumn != gv10.Columns["OutOfTen"]))
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

	private void tileItem1_ItemClick_1(object sender, TileItemEventArgs e)
	{
		navigationFrame1.SelectedPage = navPageOtherComp;
	}

	private void LoadReportAssessment()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM ReportCommentsNC WHERE ClassId='{_Class}' AND SemesterId='{_Term}' AND StudentNumber='{_Student}'", DataConnection.ConnectToDatabase());
		_dt = new DataTable();
		sqlDataAdapter.Fill(_dt);
		if (_dt.Rows.Count > 0)
		{
			vGridControl2.DataSource = _dt.DefaultView;
			return;
		}
		_dt = new DataTable();
		_dt.Columns.Add("ClassId", typeof(string));
		_dt.Columns.Add("SemesterId", typeof(string));
		_dt.Columns.Add("StudentNumber", typeof(string));
		_dt.Columns.Add("GamesAndSports", typeof(string));
		_dt.Columns.Add("Clubs", typeof(string));
		_dt.Columns.Add("ProjectTitle", typeof(string));
		_dt.Columns.Add("Project", typeof(string));
		_dt.Rows.Add(_Class, _Term, _Student, "", "", "", "");
		vGridControl2.DataSource = _dt.DefaultView;
		vGridControl2.SetCellValue(GamesAndSports, 0, "");
		vGridControl2.SetCellValue(Clubs, 0, "");
		vGridControl2.SetCellValue(ProjectTitle, 0, "");
		vGridControl2.SetCellValue(Project, 0, "");
	}

	private void vGridControl2_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "SELECT * FROM ReportCommentsNC WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId",
			CommandType = CommandType.Text
		};
		sqlCommand.Parameters.Add(new SqlParameter("@StudentNumber ", _Student));
		sqlCommand.Parameters.Add(new SqlParameter("@SemesterId", _Term));
		sqlCommand.Parameters.Add(new SqlParameter("@ClassId", _Class));
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		string arg = e.Row.Name.ToString();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			sqlConnection.Open();
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = string.Format("UPDATE ReportCommentsNC SET {0}=@{0} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND ClassId=@ClassId ", arg),
				CommandType = CommandType.Text
			};
			sqlCommand2.Parameters.Add(new SqlParameter($"@{arg}", e.Value));
			sqlCommand2.Parameters.Add(new SqlParameter("@StudentNumber ", _Student));
			sqlCommand2.Parameters.Add(new SqlParameter("@SemesterId", _Term));
			sqlCommand2.Parameters.Add(new SqlParameter("@ClassId", _Class));
			sqlCommand2.ExecuteNonQuery();
			sqlConnection.Close();
			return;
		}
		sqlConnection.Close();
		sqlConnection.Open();
		using SqlCommand sqlCommand3 = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = string.Format("INSERT INTO ReportCommentsNC ({0},StudentNumber,SemesterId,ClassId) VALUES (@{0},@StudentNumber,@SemesterId,@ClassId)", arg),
			CommandType = CommandType.Text
		};
		sqlCommand3.Parameters.Add(new SqlParameter($"@{arg}", e.Value));
		sqlCommand3.Parameters.Add(new SqlParameter("@StudentNumber ", _Student));
		sqlCommand3.Parameters.Add(new SqlParameter("@SemesterId", _Term));
		sqlCommand3.Parameters.Add(new SqlParameter("@ClassId", _Class));
		sqlCommand3.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private void gvOtherComp_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		Application.ExitThread();
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

	private void gridView6_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
	{
		if (e.Column.FieldName == "")
		{
			e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
		}
	}

	private void gridView6_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
	{
	}

	private void gridView6_RowClick(object sender, RowClickEventArgs e)
	{
		if (e.RowHandle > -1)
		{
			_Student = gridView6.GetRowCellValue(e.RowHandle, "StudentNumber").ToString();
			LoadOLevelMarks(navigationFrame1.SelectedPageIndex, _Student);
		}
	}

	private void DisableCellEditing(CancelEventArgs e, string Header, BandedGridView view)
	{
		int num = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "TUnits").ToString());
		if (view.FocusedColumn.FieldName == Header + "1" && num < 1)
		{
			e.Cancel = true;
		}
		else if (view.FocusedColumn.FieldName == Header + "2" && num < 2)
		{
			e.Cancel = true;
		}
		else if (view.FocusedColumn.FieldName == Header + "3" && num < 3)
		{
			e.Cancel = true;
		}
		else if (view.FocusedColumn.FieldName == Header + "4" && num < 4)
		{
			e.Cancel = true;
		}
		else if (view.FocusedColumn.FieldName == Header + "5" && num < 5)
		{
			e.Cancel = true;
		}
		else if (view.FocusedColumn.FieldName == Header + "6" && num < 6)
		{
			e.Cancel = true;
		}
		else
		{
			e.Cancel = false;
		}
	}

	private void ChangeCellStyle(RowCellStyleEventArgs e, string Header)
	{
		if (e.Column.FieldName == Header + "1" && e.CellValue.ToString() == "x")
		{
			e.Appearance.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
			e.Appearance.ForeColor = Color.Transparent;
		}
		else if (e.Column.FieldName == Header + "2" && e.CellValue.ToString() == "x")
		{
			e.Appearance.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
			e.Appearance.ForeColor = Color.Transparent;
		}
		else if (e.Column.FieldName == Header + "3" && e.CellValue.ToString() == "x")
		{
			e.Appearance.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
			e.Appearance.ForeColor = Color.Transparent;
		}
		else if (e.Column.FieldName == Header + "4" && e.CellValue.ToString() == "x")
		{
			e.Appearance.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
			e.Appearance.ForeColor = Color.Transparent;
		}
		else if (e.Column.FieldName == Header + "5" && e.CellValue.ToString() == "x")
		{
			e.Appearance.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
			e.Appearance.ForeColor = Color.Transparent;
		}
		else if (e.Column.FieldName == Header + "6" && e.CellValue.ToString() == "x")
		{
			e.Appearance.BackColor = Color.FromKnownColor(KnownColor.InactiveCaption);
			e.Appearance.ForeColor = Color.Transparent;
		}
	}

	private void bandedGridView1_ShowingEditor(object sender, CancelEventArgs e)
	{
		DisableCellEditing(e, "U", bandedGridView1);
	}

	private void bandedGridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
		ChangeCellStyle(e, "U");
	}

	private void gv10_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
		ChangeCellStyle(e, "T");
	}

	private void gv20_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
		ChangeCellStyle(e, "Score");
	}

	private void gv100_RowCellStyle(object sender, RowCellStyleEventArgs e)
	{
		ChangeCellStyle(e, "Hund");
	}

	private void gv10_ShowingEditor(object sender, CancelEventArgs e)
	{
		DisableCellEditing(e, "T", gv10);
	}

	private void gv20_ShowingEditor(object sender, CancelEventArgs e)
	{
		DisableCellEditing(e, "Score", gv20);
	}

	private void gv100_ShowingEditor(object sender, CancelEventArgs e)
	{
		DisableCellEditing(e, "Hund", gv100);
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
		DevExpress.XtraGrid.GridLevelNode gridLevelNode = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(I_Xtreme.NavigationForms.MainOLevelNewCur));
		DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
		DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem = new DevExpress.Utils.ToolTipItem();
		DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
		DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
		DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
		DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
		DevExpress.XtraGrid.GridLevelNode gridLevelNode5 = new DevExpress.XtraGrid.GridLevelNode();
		DevExpress.XtraEditors.TileItemElement tileItemElement = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
		DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
		this.colU1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colU6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.dgMain = new AlienAge.CustomGrid.MyGridControl();
		this.bandedGridView1 = new AlienAge.CustomGrid.MyBandedGridView();
		this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn16 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn17 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn18 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn37 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.tmUpdate = new System.Windows.Forms.Timer(this.components);
		this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
		this.bgSaveMarks = new System.ComponentModel.BackgroundWorker();
		this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
		this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
		this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
		this.navPageLO = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.navPage20 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.dgMain20 = new AlienAge.CustomGrid.MyGridControl();
		this.gv20 = new AlienAge.CustomGrid.MyBandedGridView();
		this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colScore6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn24 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn26 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn39 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.navPage100 = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.dgMain100 = new AlienAge.CustomGrid.MyGridControl();
		this.gv100 = new AlienAge.CustomGrid.MyBandedGridView();
		this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colHund6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn42 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn44 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.bandedGridColumn45 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.repositoryItemGridLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
		this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.navPageEOT = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.gridEOT = new AlienAge.CustomGrid.MyGridControl();
		this.gvEOT = new AlienAge.CustomGrid.MyBandedGridView();
		this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
		this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.colT6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBandProject = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.colProject = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
		this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
		this.bandedGridColumn52 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
		this.navPageDescr = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.rowId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row3 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row4 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row5 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row6 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row7 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row8 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row9 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row10 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.row11 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.navPageOtherComp = new DevExpress.XtraBars.Navigation.NavigationPage();
		this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
		this.repositoryItemMemoEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemMemoEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.GamesAndSports = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.ProjectTitle = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Project = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.Clubs = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
		this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
		this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
		this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
		this.gridControl2 = new DevExpress.XtraGrid.GridControl();
		this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
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
		((System.ComponentModel.ISupportInitialize)this.dgMain).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel1).BeginInit();
		this.flyoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl1).BeginInit();
		this.flyoutPanelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.navigationFrame1).BeginInit();
		this.navigationFrame1.SuspendLayout();
		this.navPageLO.SuspendLayout();
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
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).BeginInit();
		this.navPageOtherComp.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).BeginInit();
		this.panelControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl3.Panel1).BeginInit();
		this.splitContainerControl3.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl3.Panel2).BeginInit();
		this.splitContainerControl3.Panel2.SuspendLayout();
		this.splitContainerControl3.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.groupControl1).BeginInit();
		this.groupControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel2).BeginInit();
		this.flyoutPanel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl2).BeginInit();
		this.flyoutPanelControl2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.lookupClasses.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		base.SuspendLayout();
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
		this.colU1.Width = 33;
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
		this.colU2.Width = 33;
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
		this.colU3.Width = 33;
		this.colU4.AppearanceCell.Options.UseTextOptions = true;
		this.colU4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU4.AppearanceHeader.Options.UseTextOptions = true;
		this.colU4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU4.Caption = "C4";
		this.colU4.DisplayFormat.FormatString = "{0:f1}";
		this.colU4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU4.FieldName = "U4";
		this.colU4.MinWidth = 33;
		this.colU4.Name = "colU4";
		this.colU4.Visible = true;
		this.colU4.Width = 33;
		this.colU5.AppearanceCell.Options.UseTextOptions = true;
		this.colU5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU5.AppearanceHeader.Options.UseTextOptions = true;
		this.colU5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU5.Caption = "C5";
		this.colU5.DisplayFormat.FormatString = "{0:f1}";
		this.colU5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU5.FieldName = "U5";
		this.colU5.MinWidth = 33;
		this.colU5.Name = "colU5";
		this.colU5.Visible = true;
		this.colU5.Width = 33;
		this.colU6.AppearanceCell.Options.UseTextOptions = true;
		this.colU6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU6.AppearanceHeader.Options.UseTextOptions = true;
		this.colU6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colU6.Caption = "C6";
		this.colU6.DisplayFormat.FormatString = "{0:f1}";
		this.colU6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.colU6.FieldName = "U6";
		this.colU6.MinWidth = 33;
		this.colU6.Name = "colU6";
		this.colU6.Visible = true;
		this.colU6.Width = 33;
		this.dgMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.dgMain.Dock = System.Windows.Forms.DockStyle.Fill;
		gridLevelNode.RelationName = "Level1";
		this.dgMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[1] { gridLevelNode });
		this.dgMain.Location = new System.Drawing.Point(0, 0);
		this.dgMain.MainView = this.bandedGridView1;
		this.dgMain.Margin = new System.Windows.Forms.Padding(2);
		this.dgMain.Name = "dgMain";
		this.dgMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[1] { this.repositoryItemGridLookUpEdit1 });
		this.dgMain.Size = new System.Drawing.Size(1264, 512);
		this.dgMain.TabIndex = 4;
		this.dgMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.bandedGridView1 });
		this.dgMain.KeyDown += new System.Windows.Forms.KeyEventHandler(dgMain_KeyDown);
		this.bandedGridView1.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.BandPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.BandPanel.Options.UseTextOptions = true;
		this.bandedGridView1.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridView1.Appearance.BandPanelBackground.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.BandPanelBackground.Options.UseFont = true;
		this.bandedGridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
		this.bandedGridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
		this.bandedGridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.DetailTip.Options.UseFont = true;
		this.bandedGridView1.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.Empty.Options.UseFont = true;
		this.bandedGridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.EvenRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.FilterCloseButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.FilterPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.FixedLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.FocusedCell.Options.UseFont = true;
		this.bandedGridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.FocusedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
		this.bandedGridView1.Appearance.FooterPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.GroupButton.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.GroupFooter.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.GroupPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.GroupRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.HeaderPanel.Options.UseFont = true;
		this.bandedGridView1.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.HeaderPanelBackground.Options.UseFont = true;
		this.bandedGridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.HideSelectionRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.HorzLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.HotTrackedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.OddRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.Preview.Options.UseFont = true;
		this.bandedGridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.Row.Options.UseFont = true;
		this.bandedGridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.RowSeparator.Options.UseFont = true;
		this.bandedGridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.SelectedRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.TopNewRow.Options.UseFont = true;
		this.bandedGridView1.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.VertLine.Options.UseFont = true;
		this.bandedGridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bandedGridView1.Appearance.ViewCaption.Options.UseFont = true;
		this.bandedGridView1.AppearancePrint.Preview.BackColor = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.Transparent;
		this.bandedGridView1.AppearancePrint.Preview.Options.UseBackColor = true;
		this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[2] { this.gridBand2, this.gridBand3 });
		this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[12]
		{
			this.colU1, this.colU2, this.colU3, this.colU4, this.colU5, this.colU6, this.bandedGridColumn16, this.bandedGridColumn17, this.bandedGridColumn18, this.bandedGridColumn11,
			this.bandedGridColumn37, this.bandedGridColumn1
		});
		this.bandedGridView1.DetailHeight = 239;
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
		this.bandedGridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(bandedGridView1_RowCellStyle);
		this.bandedGridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(bandedGridView1_ShowingEditor);
		this.bandedGridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(bandedGridView1_CellValueChanged);
		this.bandedGridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(bandedGridView1_CustomColumnDisplayText_1);
		this.bandedGridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(bandedGridView1_ValidatingEditor);
		this.bandedGridView1.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(bandedGridView1_InvalidValueException);
		this.gridBand2.Caption = "LEARNING OUTCOMES";
		this.gridBand2.Columns.Add(this.bandedGridColumn1);
		this.gridBand2.Columns.Add(this.colU1);
		this.gridBand2.Columns.Add(this.colU2);
		this.gridBand2.Columns.Add(this.colU3);
		this.gridBand2.Columns.Add(this.colU4);
		this.gridBand2.Columns.Add(this.colU5);
		this.gridBand2.Columns.Add(this.colU6);
		this.gridBand2.MinWidth = 49;
		this.gridBand2.Name = "gridBand2";
		this.gridBand2.OptionsBand.AllowHotTrack = false;
		this.gridBand2.OptionsBand.AllowMove = false;
		this.gridBand2.OptionsBand.AllowPress = false;
		this.gridBand2.VisibleIndex = 0;
		this.gridBand2.Width = 273;
		this.bandedGridColumn1.AppearanceCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridColumn1.AppearanceCell.Options.UseForeColor = true;
		this.bandedGridColumn1.Caption = "Subject";
		this.bandedGridColumn1.FieldName = "SubjectId";
		this.bandedGridColumn1.Name = "bandedGridColumn1";
		this.bandedGridColumn1.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn1.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn1.Visible = true;
		this.gridBand3.Caption = "GRADING";
		this.gridBand3.Columns.Add(this.bandedGridColumn16);
		this.gridBand3.Columns.Add(this.bandedGridColumn17);
		this.gridBand3.MinWidth = 49;
		this.gridBand3.Name = "gridBand3";
		this.gridBand3.OptionsBand.AllowHotTrack = false;
		this.gridBand3.OptionsBand.AllowMove = false;
		this.gridBand3.OptionsBand.AllowPress = false;
		this.gridBand3.VisibleIndex = 1;
		this.gridBand3.Width = 300;
		this.bandedGridColumn16.AppearanceCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridColumn16.AppearanceCell.Options.UseForeColor = true;
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
		this.bandedGridColumn16.Visible = true;
		this.bandedGridColumn16.Width = 150;
		this.bandedGridColumn17.AppearanceCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridColumn17.AppearanceCell.Options.UseForeColor = true;
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
		this.bandedGridColumn17.Width = 150;
		this.bandedGridColumn18.AppearanceCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridColumn18.AppearanceCell.Options.UseForeColor = true;
		this.bandedGridColumn18.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn18.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn18.Caption = "TUnits";
		this.bandedGridColumn18.FieldName = "TUnits";
		this.bandedGridColumn18.MinWidth = 67;
		this.bandedGridColumn18.Name = "bandedGridColumn18";
		this.bandedGridColumn18.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn18.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn18.Visible = true;
		this.bandedGridColumn18.Width = 252;
		this.bandedGridColumn11.AppearanceCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridColumn11.AppearanceCell.Options.UseForeColor = true;
		this.bandedGridColumn11.Caption = "ETA";
		this.bandedGridColumn11.FieldName = "ETA";
		this.bandedGridColumn11.Name = "bandedGridColumn11";
		this.bandedGridColumn11.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn11.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn37.AppearanceCell.ForeColor = System.Drawing.Color.Black;
		this.bandedGridColumn37.AppearanceCell.Options.UseForeColor = true;
		this.bandedGridColumn37.Caption = "ETA80";
		this.bandedGridColumn37.FieldName = "ETA80";
		this.bandedGridColumn37.Name = "bandedGridColumn37";
		this.bandedGridColumn37.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn37.OptionsColumn.ReadOnly = true;
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
		this.tmUpdate.Interval = 1000;
		this.tmUpdate.Tick += new System.EventHandler(tmUpdate_Tick);
		this.barSubItem9.Caption = "Theme";
		this.barSubItem9.Id = 142;
		this.barSubItem9.MergeType = DevExpress.XtraBars.BarMenuMerge.MergeItems;
		this.barSubItem9.Name = "barSubItem9";
		this.bgSaveMarks.DoWork += new System.ComponentModel.DoWorkEventHandler(bgSaveMarks_DoWork);
		this.bgSaveMarks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgSaveMarks_RunWorkerCompleted);
		this.printingSystem1.Links.AddRange(new object[1] { this.printableComponentLink1 });
		this.printingSystem1.ShowMarginsWarning = false;
		this.printableComponentLink1.Component = this.dgMain;
		this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 50);
		this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(null, new DevExpress.XtraPrinting.PageFooterArea(new string[3] { "[Page # of Pages #]", "", "Printed on: [Date Printed], [Time Printed]" }, new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0), DevExpress.XtraPrinting.BrickAlignment.Near));
		this.printableComponentLink1.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
		this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
		this.timer1.Enabled = true;
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
		this.flyoutPanel1.Size = new System.Drawing.Size(575, 109);
		this.flyoutPanel1.TabIndex = 5;
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
		this.navigationFrame1.Controls.Add(this.navPageLO);
		this.navigationFrame1.Controls.Add(this.navPage20);
		this.navigationFrame1.Controls.Add(this.navPage100);
		this.navigationFrame1.Controls.Add(this.navPageEOT);
		this.navigationFrame1.Controls.Add(this.navPage10);
		this.navigationFrame1.Controls.Add(this.navPageHome);
		this.navigationFrame1.Controls.Add(this.navPageDescr);
		this.navigationFrame1.Controls.Add(this.navPageOtherComp);
		this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.navigationFrame1.Location = new System.Drawing.Point(0, 0);
		this.navigationFrame1.Margin = new System.Windows.Forms.Padding(2);
		this.navigationFrame1.Name = "navigationFrame1";
		this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[8] { this.navPageHome, this.navPageLO, this.navPage10, this.navPage20, this.navPage100, this.navPageEOT, this.navPageDescr, this.navPageOtherComp });
		this.navigationFrame1.SelectedPage = this.navPageHome;
		this.navigationFrame1.Size = new System.Drawing.Size(1264, 512);
		this.navigationFrame1.TabIndex = 6;
		this.navigationFrame1.Text = "navigationFrame1";
		this.navigationFrame1.TransitionType = DevExpress.Utils.Animation.Transitions.Shape;
		this.navPageLO.AutoSize = true;
		this.navPageLO.BackgroundPadding = new System.Windows.Forms.Padding(8);
		this.navPageLO.Caption = "navPageLO";
		this.navPageLO.Controls.Add(this.dgMain);
		this.navPageLO.Margin = new System.Windows.Forms.Padding(2);
		this.navPageLO.Name = "navPageLO";
		this.navPageLO.Size = new System.Drawing.Size(1264, 512);
		toolTipTitleItem.Text = "Learning Outcomes";
		toolTipItem.ImageOptions.Image = (System.Drawing.Image)resources.GetObject("resource.Image");
		toolTipItem.Text = "Enter marks as learning outcomes computed on a scale of 3";
		superToolTip.Items.Add(toolTipTitleItem);
		superToolTip.Items.Add(toolTipItem);
		this.navPageLO.SuperTip = superToolTip;
		this.navPage20.AutoSize = true;
		this.navPage20.Caption = "navPage20";
		this.navPage20.Controls.Add(this.dgMain20);
		this.navPage20.Margin = new System.Windows.Forms.Padding(2);
		this.navPage20.Name = "navPage20";
		this.navPage20.Size = new System.Drawing.Size(1264, 512);
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
		this.dgMain20.Size = new System.Drawing.Size(1264, 512);
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
		this.gv20.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[2] { this.gridBand5, this.gridBand6 });
		this.gv20.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[10] { this.colScore1, this.colScore2, this.colScore3, this.colScore4, this.colScore5, this.colScore6, this.bandedGridColumn24, this.bandedGridColumn26, this.bandedGridColumn39, this.bandedGridColumn3 });
		this.gv20.DetailHeight = 239;
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
		this.gv20.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gv20_RowCellStyle);
		this.gv20.ShowingEditor += new System.ComponentModel.CancelEventHandler(gv20_ShowingEditor);
		this.gv20.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gv20_CellValueChanged);
		this.gv20.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gv20_CustomColumnDisplayText);
		this.gv20.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gv20_ValidatingEditor);
		this.gv20.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gv20_InvalidValueException);
		this.gridBand5.Caption = "SCORES OUT OF 20";
		this.gridBand5.Columns.Add(this.bandedGridColumn3);
		this.gridBand5.Columns.Add(this.colScore1);
		this.gridBand5.Columns.Add(this.colScore2);
		this.gridBand5.Columns.Add(this.colScore3);
		this.gridBand5.Columns.Add(this.colScore4);
		this.gridBand5.Columns.Add(this.colScore5);
		this.gridBand5.Columns.Add(this.colScore6);
		this.gridBand5.MinWidth = 73;
		this.gridBand5.Name = "gridBand5";
		this.gridBand5.OptionsBand.AllowHotTrack = false;
		this.gridBand5.OptionsBand.AllowMove = false;
		this.gridBand5.OptionsBand.AllowPress = false;
		this.gridBand5.VisibleIndex = 0;
		this.gridBand5.Width = 375;
		this.bandedGridColumn3.Caption = "Subject";
		this.bandedGridColumn3.FieldName = "SubjectId";
		this.bandedGridColumn3.Name = "bandedGridColumn3";
		this.bandedGridColumn3.Visible = true;
		this.colScore1.AppearanceCell.Options.UseTextOptions = true;
		this.colScore1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore1.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore1.Caption = "C1";
		this.colScore1.FieldName = "Score1";
		this.colScore1.MinWidth = 50;
		this.colScore1.Name = "colScore1";
		this.colScore1.Visible = true;
		this.colScore1.Width = 50;
		this.colScore2.AppearanceCell.Options.UseTextOptions = true;
		this.colScore2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore2.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore2.Caption = "C2";
		this.colScore2.FieldName = "Score2";
		this.colScore2.MinWidth = 50;
		this.colScore2.Name = "colScore2";
		this.colScore2.Visible = true;
		this.colScore2.Width = 50;
		this.colScore3.AppearanceCell.Options.UseTextOptions = true;
		this.colScore3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore3.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore3.Caption = "C3";
		this.colScore3.FieldName = "Score3";
		this.colScore3.MinWidth = 50;
		this.colScore3.Name = "colScore3";
		this.colScore3.Visible = true;
		this.colScore3.Width = 50;
		this.colScore4.AppearanceCell.Options.UseTextOptions = true;
		this.colScore4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore4.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore4.Caption = "C4";
		this.colScore4.FieldName = "Score4";
		this.colScore4.MinWidth = 50;
		this.colScore4.Name = "colScore4";
		this.colScore4.Visible = true;
		this.colScore4.Width = 50;
		this.colScore5.AppearanceCell.Options.UseTextOptions = true;
		this.colScore5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore5.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore5.Caption = "C5";
		this.colScore5.FieldName = "Score5";
		this.colScore5.MinWidth = 50;
		this.colScore5.Name = "colScore5";
		this.colScore5.Visible = true;
		this.colScore5.Width = 50;
		this.colScore6.AppearanceCell.Options.UseTextOptions = true;
		this.colScore6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore6.AppearanceHeader.Options.UseTextOptions = true;
		this.colScore6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colScore6.Caption = "C6";
		this.colScore6.FieldName = "Score6";
		this.colScore6.MinWidth = 50;
		this.colScore6.Name = "colScore6";
		this.colScore6.Visible = true;
		this.colScore6.Width = 50;
		this.gridBand6.Caption = "GRADING";
		this.gridBand6.Columns.Add(this.bandedGridColumn24);
		this.gridBand6.MinWidth = 73;
		this.gridBand6.Name = "gridBand6";
		this.gridBand6.OptionsBand.AllowHotTrack = false;
		this.gridBand6.OptionsBand.AllowMove = false;
		this.gridBand6.OptionsBand.AllowPress = false;
		this.gridBand6.VisibleIndex = 1;
		this.gridBand6.Width = 225;
		this.bandedGridColumn24.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn24.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn24.Caption = "Av. Score";
		this.bandedGridColumn24.FieldName = "OutOfTwenty";
		this.bandedGridColumn24.MinWidth = 60;
		this.bandedGridColumn24.Name = "bandedGridColumn24";
		this.bandedGridColumn24.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn24.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn24.Visible = true;
		this.bandedGridColumn24.Width = 225;
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
		this.navPage100.Caption = "navPage100";
		this.navPage100.Controls.Add(this.dgMain100);
		this.navPage100.Margin = new System.Windows.Forms.Padding(2);
		this.navPage100.Name = "navPage100";
		this.navPage100.Size = new System.Drawing.Size(1264, 512);
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
		this.dgMain100.Size = new System.Drawing.Size(1264, 512);
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
		this.gv100.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[2] { this.gridBand8, this.gridBand9 });
		this.gv100.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[12]
		{
			this.colHund1, this.colHund2, this.colHund3, this.colHund4, this.colHund5, this.colHund6, this.bandedGridColumn42, this.bandedGridColumn44, this.bandedGridColumn12, this.bandedGridColumn13,
			this.bandedGridColumn45, this.bandedGridColumn4
		});
		this.gv100.DetailHeight = 239;
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
		this.gv100.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gv100_RowCellStyle);
		this.gv100.ShowingEditor += new System.ComponentModel.CancelEventHandler(gv100_ShowingEditor);
		this.gv100.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gv100_CellValueChanged);
		this.gv100.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gv100_CustomColumnDisplayText);
		this.gv100.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gv100_ValidatingEditor);
		this.gv100.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gv100_InvalidValueException);
		this.gridBand8.Caption = "SCORES OUT OF 100";
		this.gridBand8.Columns.Add(this.bandedGridColumn4);
		this.gridBand8.Columns.Add(this.colHund1);
		this.gridBand8.Columns.Add(this.colHund2);
		this.gridBand8.Columns.Add(this.colHund3);
		this.gridBand8.Columns.Add(this.colHund4);
		this.gridBand8.Columns.Add(this.colHund5);
		this.gridBand8.Columns.Add(this.colHund6);
		this.gridBand8.MinWidth = 163;
		this.gridBand8.Name = "gridBand8";
		this.gridBand8.OptionsBand.AllowHotTrack = false;
		this.gridBand8.OptionsBand.AllowMove = false;
		this.gridBand8.OptionsBand.AllowPress = false;
		this.gridBand8.VisibleIndex = 0;
		this.gridBand8.Width = 273;
		this.bandedGridColumn4.Caption = "Subject";
		this.bandedGridColumn4.FieldName = "SubjectId";
		this.bandedGridColumn4.Name = "bandedGridColumn4";
		this.bandedGridColumn4.Visible = true;
		this.colHund1.AppearanceCell.Options.UseTextOptions = true;
		this.colHund1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund1.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund1.Caption = "C1";
		this.colHund1.FieldName = "Hund1";
		this.colHund1.MinWidth = 33;
		this.colHund1.Name = "colHund1";
		this.colHund1.Visible = true;
		this.colHund1.Width = 33;
		this.colHund2.AppearanceCell.Options.UseTextOptions = true;
		this.colHund2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund2.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund2.Caption = "C2";
		this.colHund2.FieldName = "Hund2";
		this.colHund2.MinWidth = 33;
		this.colHund2.Name = "colHund2";
		this.colHund2.Visible = true;
		this.colHund2.Width = 33;
		this.colHund3.AppearanceCell.Options.UseTextOptions = true;
		this.colHund3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund3.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund3.Caption = "C3";
		this.colHund3.FieldName = "Hund3";
		this.colHund3.MinWidth = 33;
		this.colHund3.Name = "colHund3";
		this.colHund3.Visible = true;
		this.colHund3.Width = 33;
		this.colHund4.AppearanceCell.Options.UseTextOptions = true;
		this.colHund4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund4.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund4.Caption = "C4";
		this.colHund4.FieldName = "Hund4";
		this.colHund4.MinWidth = 33;
		this.colHund4.Name = "colHund4";
		this.colHund4.Visible = true;
		this.colHund4.Width = 33;
		this.colHund5.AppearanceCell.Options.UseTextOptions = true;
		this.colHund5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund5.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund5.Caption = "C5";
		this.colHund5.FieldName = "Hund5";
		this.colHund5.MinWidth = 33;
		this.colHund5.Name = "colHund5";
		this.colHund5.Visible = true;
		this.colHund5.Width = 33;
		this.colHund6.AppearanceCell.Options.UseTextOptions = true;
		this.colHund6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund6.AppearanceHeader.Options.UseTextOptions = true;
		this.colHund6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colHund6.Caption = "C6";
		this.colHund6.FieldName = "Hund6";
		this.colHund6.MinWidth = 33;
		this.colHund6.Name = "colHund6";
		this.colHund6.Visible = true;
		this.colHund6.Width = 33;
		this.gridBand9.Caption = "GRADING";
		this.gridBand9.Columns.Add(this.bandedGridColumn42);
		this.gridBand9.MinWidth = 163;
		this.gridBand9.Name = "gridBand9";
		this.gridBand9.OptionsBand.AllowHotTrack = false;
		this.gridBand9.OptionsBand.AllowMove = false;
		this.gridBand9.OptionsBand.AllowPress = false;
		this.gridBand9.VisibleIndex = 1;
		this.gridBand9.Width = 163;
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
		this.bandedGridColumn42.Width = 163;
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
		this.navPageEOT.Caption = "navPageEOT";
		this.navPageEOT.Controls.Add(this.gridEOT);
		this.navPageEOT.Margin = new System.Windows.Forms.Padding(2);
		this.navPageEOT.Name = "navPageEOT";
		this.navPageEOT.Size = new System.Drawing.Size(1264, 512);
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
		this.gridEOT.Size = new System.Drawing.Size(1264, 512);
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
		this.gvEOT.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[2] { this.gridBand11, this.gridBand12 });
		this.gvEOT.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[7] { this.bandedGridColumn40, this.bandedGridColumn41, this.bandedGridColumn43, this.bandedGridColumn22, this.bandedGridColumn23, this.bandedGridColumn25, this.bandedGridColumn5 });
		this.gvEOT.DetailHeight = 239;
		styleFormatCondition.Appearance.ForeColor = System.Drawing.Color.Red;
		styleFormatCondition.Appearance.Options.UseForeColor = true;
		styleFormatCondition.ApplyToRow = true;
		styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
		styleFormatCondition.Value1 = "F9";
		this.gvEOT.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[1] { styleFormatCondition });
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
		this.gvEOT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gvEOT_CellValueChanged);
		this.gvEOT.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gvEOT_CustomColumnDisplayText);
		this.gridBand11.Caption = "END OF TERM ASSESSMENT";
		this.gridBand11.Columns.Add(this.bandedGridColumn5);
		this.gridBand11.Columns.Add(this.bandedGridColumn43);
		this.gridBand11.MinWidth = 112;
		this.gridBand11.Name = "gridBand11";
		this.gridBand11.OptionsBand.AllowHotTrack = false;
		this.gridBand11.OptionsBand.AllowMove = false;
		this.gridBand11.OptionsBand.AllowPress = false;
		this.gridBand11.VisibleIndex = 0;
		this.gridBand11.Width = 236;
		this.bandedGridColumn5.Caption = "Subject";
		this.bandedGridColumn5.FieldName = "SubjectId";
		this.bandedGridColumn5.Name = "bandedGridColumn5";
		this.bandedGridColumn5.Visible = true;
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
		this.gridBand12.VisibleIndex = 1;
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
		this.navPage10.Caption = "navPage10";
		this.navPage10.Controls.Add(this.dgMain10);
		this.navPage10.Name = "navPage10";
		this.navPage10.Size = new System.Drawing.Size(1264, 512);
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
		this.dgMain10.Size = new System.Drawing.Size(1264, 512);
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
		this.gv10.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[3] { this.gridBand14, this.gridBandProject, this.gridBand15 });
		this.gv10.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[11]
		{
			this.colT1, this.colT2, this.colT3, this.colT4, this.colT5, this.colT6, this.bandedGridColumn52, this.bandedGridColumn53, this.bandedGridColumn38, this.colProject,
			this.bandedGridColumn2
		});
		this.gv10.DetailHeight = 239;
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
		this.gv10.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gv10_RowCellStyle);
		this.gv10.ShowingEditor += new System.ComponentModel.CancelEventHandler(gv10_ShowingEditor);
		this.gv10.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gv10_CellValueChanged);
		this.gv10.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gv10_CustomColumnDisplayText);
		this.gv10.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(gv10_ValidatingEditor);
		this.gv10.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(gv10_InvalidValueException);
		this.gridBand14.Caption = "SCORES OUT OF 10";
		this.gridBand14.Columns.Add(this.bandedGridColumn2);
		this.gridBand14.Columns.Add(this.colT1);
		this.gridBand14.Columns.Add(this.colT2);
		this.gridBand14.Columns.Add(this.colT3);
		this.gridBand14.Columns.Add(this.colT4);
		this.gridBand14.Columns.Add(this.colT5);
		this.gridBand14.Columns.Add(this.colT6);
		this.gridBand14.MinWidth = 73;
		this.gridBand14.Name = "gridBand14";
		this.gridBand14.OptionsBand.AllowHotTrack = false;
		this.gridBand14.OptionsBand.AllowMove = false;
		this.gridBand14.OptionsBand.AllowPress = false;
		this.gridBand14.VisibleIndex = 0;
		this.gridBand14.Width = 375;
		this.bandedGridColumn2.Caption = "Subject";
		this.bandedGridColumn2.FieldName = "SubjectId";
		this.bandedGridColumn2.Name = "bandedGridColumn2";
		this.bandedGridColumn2.Visible = true;
		this.colT1.AppearanceCell.Options.UseTextOptions = true;
		this.colT1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT1.AppearanceHeader.Options.UseTextOptions = true;
		this.colT1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT1.Caption = "C1";
		this.colT1.FieldName = "T1";
		this.colT1.MinWidth = 50;
		this.colT1.Name = "colT1";
		this.colT1.Visible = true;
		this.colT1.Width = 50;
		this.colT2.AppearanceCell.Options.UseTextOptions = true;
		this.colT2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT2.AppearanceHeader.Options.UseTextOptions = true;
		this.colT2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT2.Caption = "C2";
		this.colT2.FieldName = "T2";
		this.colT2.MinWidth = 50;
		this.colT2.Name = "colT2";
		this.colT2.Visible = true;
		this.colT2.Width = 50;
		this.colT3.AppearanceCell.Options.UseTextOptions = true;
		this.colT3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT3.AppearanceHeader.Options.UseTextOptions = true;
		this.colT3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT3.Caption = "C3";
		this.colT3.FieldName = "T3";
		this.colT3.MinWidth = 50;
		this.colT3.Name = "colT3";
		this.colT3.Visible = true;
		this.colT3.Width = 50;
		this.colT4.AppearanceCell.Options.UseTextOptions = true;
		this.colT4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT4.AppearanceHeader.Options.UseTextOptions = true;
		this.colT4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT4.Caption = "C4";
		this.colT4.FieldName = "T4";
		this.colT4.MinWidth = 50;
		this.colT4.Name = "colT4";
		this.colT4.Visible = true;
		this.colT4.Width = 50;
		this.colT5.AppearanceCell.Options.UseTextOptions = true;
		this.colT5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT5.AppearanceHeader.Options.UseTextOptions = true;
		this.colT5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT5.Caption = "C5";
		this.colT5.FieldName = "T5";
		this.colT5.MinWidth = 50;
		this.colT5.Name = "colT5";
		this.colT5.Visible = true;
		this.colT5.Width = 50;
		this.colT6.AppearanceCell.Options.UseTextOptions = true;
		this.colT6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT6.AppearanceHeader.Options.UseTextOptions = true;
		this.colT6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colT6.Caption = "C6";
		this.colT6.FieldName = "T6";
		this.colT6.MinWidth = 50;
		this.colT6.Name = "colT6";
		this.colT6.Visible = true;
		this.colT6.Width = 50;
		this.gridBandProject.Caption = "Project";
		this.gridBandProject.Columns.Add(this.colProject);
		this.gridBandProject.Name = "gridBandProject";
		this.gridBandProject.VisibleIndex = 1;
		this.gridBandProject.Width = 59;
		this.colProject.AppearanceCell.Options.UseTextOptions = true;
		this.colProject.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colProject.AppearanceHeader.Options.UseTextOptions = true;
		this.colProject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.colProject.Caption = "Score";
		this.colProject.FieldName = "P1";
		this.colProject.Name = "colProject";
		this.colProject.Visible = true;
		this.colProject.Width = 59;
		this.gridBand15.Caption = "GRADING";
		this.gridBand15.Columns.Add(this.bandedGridColumn52);
		this.gridBand15.MinWidth = 73;
		this.gridBand15.Name = "gridBand15";
		this.gridBand15.OptionsBand.AllowHotTrack = false;
		this.gridBand15.OptionsBand.AllowMove = false;
		this.gridBand15.OptionsBand.AllowPress = false;
		this.gridBand15.VisibleIndex = 2;
		this.gridBand15.Width = 225;
		this.bandedGridColumn52.AppearanceCell.Options.UseTextOptions = true;
		this.bandedGridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn52.AppearanceHeader.Options.UseTextOptions = true;
		this.bandedGridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.bandedGridColumn52.Caption = "Total Score";
		this.bandedGridColumn52.FieldName = "OutOfTen";
		this.bandedGridColumn52.MinWidth = 60;
		this.bandedGridColumn52.Name = "bandedGridColumn52";
		this.bandedGridColumn52.OptionsColumn.AllowEdit = false;
		this.bandedGridColumn52.OptionsColumn.ReadOnly = true;
		this.bandedGridColumn52.Visible = true;
		this.bandedGridColumn52.Width = 225;
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
		this.navPageHome.Caption = "navPageHome";
		this.navPageHome.Controls.Add(this.tileControl2);
		this.navPageHome.Name = "navPageHome";
		this.navPageHome.Size = new System.Drawing.Size(1264, 512);
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
		this.tileControl2.MaxId = 17;
		this.tileControl2.Name = "tileControl2";
		this.tileControl2.ShowGroupText = true;
		this.tileControl2.Size = new System.Drawing.Size(1264, 512);
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
		this.tileGroup7.Name = "tileGroup7";
		this.tileGroup7.Text = "Descriptive Model";
		this.tileItemRDes.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
		this.tileItemRDes.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement6.Text = "Generic Skills and Teacher Remarks";
		this.tileItemRDes.Elements.Add(tileItemElement6);
		this.tileItemRDes.Id = 15;
		this.tileItemRDes.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItemRDes.Name = "tileItemRDes";
		this.tileItemRDes.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItemRDes_ItemClick);
		this.tileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkCyan;
		this.tileItem1.AppearanceItem.Normal.Options.UseBackColor = true;
		tileItemElement7.Text = "Games and Sports, Projects and Clubs";
		this.tileItem1.Elements.Add(tileItemElement7);
		this.tileItem1.Id = 16;
		this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
		this.tileItem1.Name = "tileItem1";
		this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(tileItem1_ItemClick_1);
		this.navPageDescr.Caption = "navPageDescr";
		this.navPageDescr.Controls.Add(this.vGridControl1);
		this.navPageDescr.Name = "navPageDescr";
		this.navPageDescr.Size = new System.Drawing.Size(1264, 512);
		this.vGridControl1.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.vGridControl1.Appearance.Caption.Options.UseFont = true;
		this.vGridControl1.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.vGridControl1.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl1.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.vGridControl1.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.vGridControl1.Location = new System.Drawing.Point(0, 0);
		this.vGridControl1.Name = "vGridControl1";
		this.vGridControl1.OptionsView.AutoScaleBands = true;
		this.vGridControl1.OptionsView.ShowCollapseButtons = false;
		this.vGridControl1.OptionsView.ShowFocusedFrame = false;
		this.vGridControl1.RecordWidth = 230;
		this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[3] { this.repositoryItemMemoEdit1, this.repositoryItemMemoEdit2, this.repositoryItemMemoEdit3 });
		this.vGridControl1.RowHeaderWidth = 150;
		this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[10] { this.rowId, this.row1, this.row, this.row5, this.row6, this.row7, this.row8, this.row9, this.row10, this.row11 });
		this.vGridControl1.Size = new System.Drawing.Size(1264, 512);
		this.vGridControl1.TabIndex = 1;
		this.vGridControl1.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl1_CellValueChanged);
		this.repositoryItemMemoEdit1.MaxLength = 500;
		this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
		this.repositoryItemMemoEdit2.MaxLength = 500;
		this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
		this.repositoryItemMemoEdit3.MaxLength = 500;
		this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
		this.rowId.Name = "rowId";
		this.rowId.Properties.Caption = "Id";
		this.rowId.Properties.FieldName = "Id";
		this.rowId.Visible = false;
		this.row1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.row1.AppearanceCell.Options.UseFont = true;
		this.row1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.row1.AppearanceHeader.Options.UseFont = true;
		this.row1.ChildRows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[2] { this.row3, this.row4 });
		this.row1.Name = "row1";
		this.row1.Properties.AllowEdit = false;
		this.row1.Properties.Caption = "CHAPTER";
		this.row1.Properties.FieldName = "CompetencyNo";
		this.row1.Properties.ReadOnly = true;
		this.row3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.row3.AppearanceCell.Options.UseFont = true;
		this.row3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.row3.AppearanceHeader.Options.UseFont = true;
		this.row3.Name = "row3";
		this.row3.Properties.AllowEdit = false;
		this.row3.Properties.Caption = "Score";
		this.row3.Properties.FieldName = "Score";
		this.row3.Properties.ReadOnly = true;
		this.row4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.row4.AppearanceCell.Options.UseFont = true;
		this.row4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
		this.row4.AppearanceHeader.Options.UseFont = true;
		this.row4.Name = "row4";
		this.row4.Properties.AllowEdit = false;
		this.row4.Properties.Caption = "Descriptor";
		this.row4.Properties.FieldName = "Descriptor";
		this.row4.Properties.ReadOnly = true;
		this.row.Height = 180;
		this.row.Name = "row";
		this.row.Properties.Caption = "Competency";
		this.row.Properties.FieldName = "Competency";
		this.row5.Height = 180;
		this.row5.Name = "row5";
		this.row5.Properties.Caption = "Generic Skills";
		this.row5.Properties.FieldName = "GeneralSkills";
		this.row5.Properties.RowEdit = this.repositoryItemMemoEdit1;
		this.row6.Height = 180;
		this.row6.Name = "row6";
		this.row6.Properties.Caption = "Teacher Remarks";
		this.row6.Properties.FieldName = "TeacherRemarks";
		this.row6.Properties.RowEdit = this.repositoryItemMemoEdit3;
		this.row7.Name = "row7";
		this.row7.Properties.Caption = "TeacherInitial";
		this.row7.Properties.FieldName = "TeacherInitial";
		this.row7.Visible = false;
		this.row8.Name = "row8";
		this.row8.Properties.Caption = "SemesterId";
		this.row8.Properties.FieldName = "SemesterId";
		this.row8.Visible = false;
		this.row9.Name = "row9";
		this.row9.Properties.Caption = "StudentNo";
		this.row9.Properties.FieldName = "StudentNo";
		this.row9.Visible = false;
		this.row10.Name = "row10";
		this.row10.Properties.Caption = "SubjectId";
		this.row10.Properties.FieldName = "SubjectId";
		this.row10.Visible = false;
		this.row11.Name = "row11";
		this.row11.Properties.Caption = "ClassId";
		this.row11.Properties.FieldName = "ClassId";
		this.row11.Visible = false;
		this.navPageOtherComp.Caption = "navPageOtherComp";
		this.navPageOtherComp.Controls.Add(this.vGridControl2);
		this.navPageOtherComp.Name = "navPageOtherComp";
		this.navPageOtherComp.Size = new System.Drawing.Size(1264, 512);
		this.vGridControl2.Appearance.BandBorder.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.BandBorder.Options.UseFont = true;
		this.vGridControl2.Appearance.Caption.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.Caption.Options.UseFont = true;
		this.vGridControl2.Appearance.Category.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.Category.Options.UseFont = true;
		this.vGridControl2.Appearance.CategoryExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.CategoryExpandButton.Options.UseFont = true;
		this.vGridControl2.Appearance.DisabledRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.DisabledRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.DisabledRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.DisabledRow.Options.UseFont = true;
		this.vGridControl2.Appearance.Empty.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.Empty.Options.UseFont = true;
		this.vGridControl2.Appearance.ExpandButton.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ExpandButton.Options.UseFont = true;
		this.vGridControl2.Appearance.FixedLine.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FixedLine.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedCell.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedCell.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRecord.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedRecord.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.FocusedRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.FocusedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.HideSelectionRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.HideSelectionRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.vGridControl2.Appearance.HorzLine.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.HorzLine.Options.UseFont = true;
		this.vGridControl2.Appearance.ModifiedRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ModifiedRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.ModifiedRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ModifiedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.PressedRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.PressedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.ReadOnlyRecordValue.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ReadOnlyRecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.ReadOnlyRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.ReadOnlyRow.Options.UseFont = true;
		this.vGridControl2.Appearance.RecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.RecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.RecordValue.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.RecordValue.Options.UseFont = true;
		this.vGridControl2.Appearance.RowHeaderPanel.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.RowHeaderPanel.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedCategory.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedCategory.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedCell.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedCell.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRecord.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedRecord.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRecordHeader.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedRecordHeader.Options.UseFont = true;
		this.vGridControl2.Appearance.SelectedRow.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.SelectedRow.Options.UseFont = true;
		this.vGridControl2.Appearance.VertLine.Font = new System.Drawing.Font("Cascadia Mono", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.vGridControl2.Appearance.VertLine.Options.UseFont = true;
		this.vGridControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.vGridControl2.Cursor = System.Windows.Forms.Cursors.Default;
		this.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.vGridControl2.Location = new System.Drawing.Point(0, 0);
		this.vGridControl2.Name = "vGridControl2";
		this.vGridControl2.OptionsFilter.AllowFilter = false;
		this.vGridControl2.RecordWidth = 994;
		this.vGridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[4] { this.repositoryItemMemoEdit4, this.repositoryItemMemoEdit5, this.repositoryItemMemoEdit6, this.repositoryItemTextEdit1 });
		this.vGridControl2.RowHeaderWidth = 190;
		this.vGridControl2.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[4] { this.GamesAndSports, this.ProjectTitle, this.Project, this.Clubs });
		this.vGridControl2.ScrollVisibility = DevExpress.XtraVerticalGrid.ScrollVisibility.Never;
		this.vGridControl2.Size = new System.Drawing.Size(1264, 512);
		this.vGridControl2.TabIndex = 12;
		this.vGridControl2.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(vGridControl2_CellValueChanged);
		this.repositoryItemMemoEdit4.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit4.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit4.Appearance.Font = new System.Drawing.Font("Cascadia Mono", 12f);
		this.repositoryItemMemoEdit4.Appearance.Options.UseFont = true;
		this.repositoryItemMemoEdit4.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemMemoEdit4.AppearanceDisabled.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit4.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemMemoEdit4.AppearanceFocused.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit4.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemMemoEdit4.LinesCount = 8;
		this.repositoryItemMemoEdit4.Name = "repositoryItemMemoEdit4";
		this.repositoryItemMemoEdit4.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit5.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit5.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit5.Appearance.Font = new System.Drawing.Font("Cascadia Mono", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.repositoryItemMemoEdit5.Appearance.Options.UseFont = true;
		this.repositoryItemMemoEdit5.Appearance.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemMemoEdit5.AppearanceDisabled.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit5.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemMemoEdit5.AppearanceFocused.Options.UseTextOptions = true;
		this.repositoryItemMemoEdit5.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
		this.repositoryItemMemoEdit5.LinesCount = 8;
		this.repositoryItemMemoEdit5.Name = "repositoryItemMemoEdit5";
		this.repositoryItemMemoEdit5.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit6.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit6.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemMemoEdit6.LinesCount = 8;
		this.repositoryItemMemoEdit6.Name = "repositoryItemMemoEdit6";
		this.repositoryItemMemoEdit6.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.GamesAndSports.Name = "GamesAndSports";
		this.GamesAndSports.Properties.Caption = "Games and Sports";
		this.GamesAndSports.Properties.FieldName = "GamesAndSports";
		this.GamesAndSports.Properties.RowEdit = this.repositoryItemMemoEdit4;
		this.ProjectTitle.Name = "ProjectTitle";
		this.ProjectTitle.Properties.Caption = "Project Title";
		this.ProjectTitle.Properties.FieldName = "ProjectTitle";
		this.ProjectTitle.Properties.RowEdit = this.repositoryItemTextEdit1;
		this.Project.Name = "Project";
		this.Project.Properties.Caption = "Project";
		this.Project.Properties.FieldName = "Project";
		this.Project.Properties.RowEdit = this.repositoryItemMemoEdit5;
		this.Clubs.Name = "Clubs";
		this.Clubs.Properties.Caption = "Clubs";
		this.Clubs.Properties.FieldName = "Clubs";
		this.Clubs.Properties.RowEdit = this.repositoryItemMemoEdit6;
		this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.panelControl1.Appearance.Options.UseBackColor = true;
		this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.panelControl1.Controls.Add(this.splitContainerControl3);
		this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panelControl1.Location = new System.Drawing.Point(0, 0);
		this.panelControl1.Name = "panelControl1";
		this.panelControl1.Size = new System.Drawing.Size(1264, 512);
		this.panelControl1.TabIndex = 8;
		this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
		this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
		this.splitContainerControl3.Name = "splitContainerControl3";
		this.splitContainerControl3.Panel1.Controls.Add(this.groupControl1);
		this.splitContainerControl3.Panel1.Text = "Panel1";
		this.splitContainerControl3.Panel2.Controls.Add(this.navigationFrame1);
		this.splitContainerControl3.Panel2.Text = "Panel2";
		this.splitContainerControl3.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
		this.splitContainerControl3.Size = new System.Drawing.Size(1264, 512);
		this.splitContainerControl3.SplitterPosition = 290;
		this.splitContainerControl3.TabIndex = 8;
		this.groupControl1.Controls.Add(this.gridControl2);
		this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.groupControl1.Location = new System.Drawing.Point(0, 0);
		this.groupControl1.Name = "groupControl1";
		this.groupControl1.Size = new System.Drawing.Size(0, 0);
		this.groupControl1.TabIndex = 1;
		this.groupControl1.Text = "Select a student";
		this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.gridControl2.Location = new System.Drawing.Point(0, 22);
		this.gridControl2.MainView = this.gridView6;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(0, 0);
		this.gridControl2.TabIndex = 0;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView6 });
		this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[3] { this.colNo, this.gridColumn13, this.gridColumn14 });
		this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
		this.gridView6.GridControl = this.gridControl2;
		this.gridView6.Name = "gridView6";
		this.gridView6.OptionsBehavior.Editable = false;
		this.gridView6.OptionsCustomization.AllowColumnMoving = false;
		this.gridView6.OptionsFind.AlwaysVisible = true;
		this.gridView6.OptionsFind.ShowFindButton = false;
		this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.gridView6.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
		this.gridView6.OptionsView.RowAutoHeight = true;
		this.gridView6.OptionsView.ShowGroupPanel = false;
		this.gridView6.OptionsView.ShowIndicator = false;
		this.gridView6.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(gridView6_RowClick);
		this.gridView6.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView6_FocusedRowChanged);
		this.gridView6.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView6_CustomColumnDisplayText);
		this.colNo.Caption = "No";
		this.colNo.Name = "colNo";
		this.colNo.OptionsColumn.AllowEdit = false;
		this.colNo.OptionsColumn.FixedWidth = true;
		this.colNo.OptionsColumn.ReadOnly = true;
		this.colNo.Visible = true;
		this.colNo.VisibleIndex = 0;
		this.colNo.Width = 45;
		this.gridColumn13.Caption = "Name]";
		this.gridColumn13.FieldName = "fullName";
		this.gridColumn13.Name = "gridColumn13";
		this.gridColumn13.OptionsColumn.AllowEdit = false;
		this.gridColumn13.OptionsColumn.ReadOnly = true;
		this.gridColumn13.Visible = true;
		this.gridColumn13.VisibleIndex = 1;
		this.gridColumn13.Width = 103;
		this.gridColumn14.Caption = "Student No.";
		this.gridColumn14.FieldName = "StudentNumber";
		this.gridColumn14.Name = "gridColumn14";
		this.gridColumn14.OptionsColumn.AllowEdit = false;
		this.gridColumn14.OptionsColumn.ReadOnly = true;
		this.gridColumn14.Visible = true;
		this.gridColumn14.VisibleIndex = 2;
		this.gridColumn14.Width = 104;
		this.flyoutPanel2.Controls.Add(this.flyoutPanelControl2);
		this.flyoutPanel2.Location = new System.Drawing.Point(13, 261);
		this.flyoutPanel2.Name = "flyoutPanel2";
		this.flyoutPanel2.Options.CloseOnHidingOwner = false;
		this.flyoutPanel2.OwnerControl = this;
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
		this.lookupClasses.Location = new System.Drawing.Point(187, 34);
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
		this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.txtPassword.Location = new System.Drawing.Point(187, 118);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.txtPassword.Properties.Appearance.Options.UseFont = true;
		this.txtPassword.Properties.UseSystemPasswordChar = true;
		this.txtPassword.Size = new System.Drawing.Size(293, 26);
		this.txtPassword.TabIndex = 6;
		this.cboSubject.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.cboSubject.Location = new System.Drawing.Point(187, 62);
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
		this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton2.Location = new System.Drawing.Point(337, 155);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.True;
		this.simpleButton2.Size = new System.Drawing.Size(143, 28);
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Exit";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.txtUserId.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.txtUserId.Location = new System.Drawing.Point(187, 90);
		this.txtUserId.Name = "txtUserId";
		this.txtUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f);
		this.txtUserId.Properties.Appearance.Options.UseFont = true;
		this.txtUserId.Size = new System.Drawing.Size(293, 26);
		this.txtUserId.TabIndex = 5;
		this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
		this.pictureEdit1.Properties.ShowMenu = false;
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(573, 204);
		this.pictureEdit1.TabIndex = 1;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.panelControl1);
		base.Controls.Add(this.flyoutPanel2);
		base.Controls.Add(this.flyoutPanel1);
		base.Name = "MainOLevelNewCur";
		base.Size = new System.Drawing.Size(1264, 512);
		base.Load += new System.EventHandler(MainWindow_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(MainWindow_KeyDown);
		((System.ComponentModel.ISupportInitialize)this.dgMain).EndInit();
		((System.ComponentModel.ISupportInitialize)this.bandedGridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemGridLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.printingSystem1).EndInit();
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
		((System.ComponentModel.ISupportInitialize)this.vGridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit3).EndInit();
		this.navPageOtherComp.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.vGridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemMemoEdit6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.panelControl1).EndInit();
		this.panelControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl3.Panel1).EndInit();
		this.splitContainerControl3.Panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl3.Panel2).EndInit();
		this.splitContainerControl3.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.splitContainerControl3).EndInit();
		this.splitContainerControl3.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.groupControl1).EndInit();
		this.groupControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.flyoutPanel2).EndInit();
		this.flyoutPanel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.flyoutPanelControl2).EndInit();
		this.flyoutPanelControl2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.lookupClasses.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtPassword.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubject.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtUserId.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
