using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using AlienAge.Semesters;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme;

public class dropSubjects : XtraForm
{
	private SqlTransaction trs;

	private SqlTransaction _trans;

	private SqlTransaction transs;

	private SqlTransaction trans;

	private SqlTransaction trans_s;

	public string studentClass = string.Empty;

	public string classLevel = string.Empty;

	private string levelRanking = string.Empty;

	public string studentNo = string.Empty;

	private string ClassGroup = string.Empty;

	private string semester = WorkingSemesters.GetWorkingSemester();

	private static string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private CheckedListBoxControl chkListSubjects;

	private CheckEdit chkSelectAll;

	private SimpleButton btnClose;

	private SimpleButton btnDrop;

	private Timer timer1;

	public RadioGroup radioGroupDrop;

	public TextEdit txtName;

	public TextEdit txtClass;

	public TextEdit txtStream;

	public LabelControl lblStudentNumber;

	private LabelControl labelControl2;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem2;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem8;

	private LayoutControlItem layoutControlItem9;

	private LayoutControlItem layoutControlItem10;

	private LayoutControlGroup layoutControlGroup2;

	private GridView searchLookUpEdit1View;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem7;

	private LayoutControlGroup layoutControlGroup3;

	public LookUpEdit lookUpClasses;

	private EmptySpaceItem emptySpaceItem1;

	public SearchLookUpEdit searchLookUpEdit1;

	public PictureEdit pictureEdit1;

	public dropSubjects(string _ClassGroup)
	{
		InitializeComponent();
		ClassGroup = _ClassGroup;
		Classes.LoadLookUpWithClasses(lookUpClasses);
	}

	private static void LoadStudentsLookUp(SearchLookUpEdit lookUpEdit, string _class)
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT fullName AS Name, StudentNumber AS StudentNo,StreamId AS Stream,Picture,RequiredFees FROM tbl_Stud WHERE ClassId='{_class}'", connectionString);
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentList");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			lookUpEdit.Properties.DataSource = dataTable;
			lookUpEdit.Properties.DisplayMember = "Name";
			lookUpEdit.Properties.ValueMember = "StudentNo";
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
	{
		if (chkSelectAll.Checked)
		{
			chkListSubjects.CheckAll();
		}
		else
		{
			chkListSubjects.UnCheckAll();
		}
	}

	private void DropSingleOLevel()
	{
		if (classLevel == "Nursery")
		{
			foreach (CheckedListBoxItem item in (IEnumerable)chkListSubjects.CheckedItems)
			{
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"DELETE FROM tbl_Scores_PrePrimary WHERE SubjectId='{item}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_PrePrimary WHERE StudentNumber='{studentNo}' AND SemesterId='{semester}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentChecker");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = $"DELETE FROM tbl_GeneralReports_Grading_PrePrimary WHERE StudentNumber='{studentNo}' AND SemesterId='{semester}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			AuditTrail.CaptureActions("Dropped Subjects", $"Dropped subjects for {txtName.Text} - {semester}", AuditTrail.Departments.Academics, studentNo, txtClass.Text, 0m, 0m);
			XtraMessageBox.Show("Subject (s) dropped successfully", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		foreach (CheckedListBoxItem item2 in (IEnumerable)chkListSubjects.CheckedItems)
		{
			using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection3.Open();
			trans_s = sqlConnection3.BeginTransaction();
			SqlCommand sqlCommand3 = new SqlCommand();
			sqlCommand3.Connection = sqlConnection3;
			sqlCommand3.Transaction = trans_s;
			sqlCommand3.CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE SubjectId='{item2}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'";
			sqlCommand3.CommandType = CommandType.Text;
			using (SqlCommand sqlCommand4 = sqlCommand3)
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlCommand3 = new SqlCommand();
			sqlCommand3.Connection = sqlConnection3;
			sqlCommand3.Transaction = trans_s;
			sqlCommand3.CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(studentClass)} WHERE SubjectId='{item2}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'";
			sqlCommand3.CommandType = CommandType.Text;
			using (SqlCommand sqlCommand5 = sqlCommand3)
			{
				sqlCommand5.ExecuteNonQuery();
			}
			trans_s.Commit();
			sqlConnection3.Close();
		}
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE StudentNumber='{studentNo}' AND SemesterId='{semester}'", DataConnection.ConnectToDatabase());
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2, "StudentChecker");
		if (dataSet2.Tables[0].Rows.Count == 0)
		{
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand6 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = $"DELETE FROM {SchoolSettings.GeneralReportGradingTableSource(studentClass)} WHERE StudentNumber='{studentNo}' AND SemesterId='{semester}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand6.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
		AuditTrail.CaptureActions("Dropped Subjects", $"Dropped subjects for {txtName.Text} - {semester}", AuditTrail.Departments.Academics, studentNo, txtClass.Text, 0m, 0m);
		XtraMessageBox.Show("Subject (s) dropped successfully", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void DropAllNewCurriculum(string SubjectId, string Term, string ClassId)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trs = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Transaction = trs,
				CommandText = "DELETE FROM tbl_Scores_OL_Report WHERE SubjectId=@SubjectId AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = sqlConnection
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@SubjectId", SubjectId);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", Term);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.AddWithValue("@ClassId", ClassId);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Transaction = trs,
				CommandText = "DELETE FROM OLevelReportNC WHERE SubjectId=@SubjectId AND SemesterId=@SemesterId AND ClassId=@ClassId",
				CommandType = CommandType.Text,
				Connection = sqlConnection
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SubjectId", SubjectId);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@SemesterId", Term);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@ClassId", ClassId);
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trs.Commit();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DropAllOLevel()
	{
		if (classLevel == "Nursery")
		{
			foreach (CheckedListBoxItem item in (IEnumerable)chkListSubjects.CheckedItems)
			{
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"DELETE FROM tbl_Scores_PrePrimary WHERE SemesterId='{semester}' AND SubjectId='{item}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Scores_PrePrimary WHERE SemesterId='{semester}'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentChecker");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = $"DELETE FROM tbl_GeneralReports_Grading_PrePrimary WHERE SemesterId='{semester}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			XtraMessageBox.Show("Subject (s) dropped successfully", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			if (!(classLevel == "Primary") && !(classLevel == "OLevel"))
			{
				return;
			}
			if (studentClass == "S.1" || studentClass == "S.2" || studentClass == "S.3" || studentClass == "S.4")
			{
				foreach (CheckedListBoxItem item2 in (IEnumerable)chkListSubjects.CheckedItems)
				{
					DropAllNewCurriculum(item2.ToString(), semester, studentClass);
				}
			}
			else
			{
				foreach (CheckedListBoxItem item3 in (IEnumerable)chkListSubjects.CheckedItems)
				{
					using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection3.Open();
					trans = sqlConnection3.BeginTransaction();
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE SemesterId='{semester}' AND SubjectId='{item3}'",
						CommandType = CommandType.Text
					})
					{
						sqlCommand3.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(studentClass)} WHERE SemesterId='{semester}' AND SubjectId='{item3}'",
						CommandType = CommandType.Text
					})
					{
						sqlCommand4.ExecuteNonQuery();
					}
					trans.Commit();
					sqlConnection3.Close();
				}
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE SemesterId='{semester}'", DataConnection.ConnectToDatabase());
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "StudentChecker");
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection4.Open();
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Connection = sqlConnection4,
						CommandText = $"DELETE FROM {SchoolSettings.GeneralReportGradingTableSource(studentClass)} WHERE SemesterId='{semester}'",
						CommandType = CommandType.Text
					})
					{
						sqlCommand5.ExecuteNonQuery();
					}
					sqlConnection4.Close();
				}
			}
			XtraMessageBox.Show("Subject (s) dropped successfully", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private string FirstWords(string input)
	{
		try
		{
			string empty = string.Empty;
			empty = ((!input.Contains("/")) ? input.Substring(0, input.Length - 2) : input.Substring(0, input.Length - 6));
			return empty.Trim();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void btnDrop_Click(object sender, EventArgs e)
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to do this? Note that you cannot undo this action\nPlease Re-Process the reports for the selected Study Level, Semester and Class after this action.", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				if (radioGroupDrop.SelectedIndex == 0)
				{
					if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString() || (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
					{
						DropSingleOLevel();
						LoadStudentSubjects();
					}
					else
					{
						if (!(SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString()) || !(classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString()))
						{
							return;
						}
						foreach (CheckedListBoxItem item in (IEnumerable)chkListSubjects.CheckedItems)
						{
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SubjectId  FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE SubjectId='{FirstWords(item.ToString())}' AND SemesterId='{semester}' AND StudentNumber='{studentNo}'", DataConnection.ConnectToDatabase());
							DataSet dataSet = new DataSet();
							sqlDataAdapter.Fill(dataSet, "CountOfPapers");
							string text = FirstWords(item.ToString());
							if (dataSet.Tables[0].Rows.Count == 1)
							{
								using SqlConnection sqlConnection = new SqlConnection(connectionString);
								sqlConnection.Open();
								_trans = sqlConnection.BeginTransaction();
								SqlCommand sqlCommand = new SqlCommand();
								sqlCommand.Connection = sqlConnection;
								sqlCommand.Transaction = _trans;
								sqlCommand.CommandText = $"DELETE FROM {SchoolSettings.GeneralReportGradingTableSource(studentClass)} WHERE  StudentNumber='{studentNo}' AND SemesterId='{semester}' AND SubjectId='{FirstWords(item.ToString())}'";
								sqlCommand.CommandType = CommandType.Text;
								using (SqlCommand sqlCommand2 = sqlCommand)
								{
									sqlCommand2.ExecuteNonQuery();
								}
								sqlCommand = new SqlCommand();
								sqlCommand.Connection = sqlConnection;
								sqlCommand.Transaction = _trans;
								sqlCommand.CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE PaperId='{item}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'";
								sqlCommand.CommandType = CommandType.Text;
								using (SqlCommand sqlCommand3 = sqlCommand)
								{
									sqlCommand3.ExecuteNonQuery();
								}
								sqlCommand = new SqlCommand();
								sqlCommand.Connection = sqlConnection;
								sqlCommand.Transaction = _trans;
								sqlCommand.CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(studentClass)} WHERE PaperId='{item}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'";
								sqlCommand.CommandType = CommandType.Text;
								using (SqlCommand sqlCommand4 = sqlCommand)
								{
									sqlCommand4.ExecuteNonQuery();
								}
								_trans.Commit();
								sqlConnection.Close();
							}
							else
							{
								if (dataSet.Tables[0].Rows.Count <= 1)
								{
									continue;
								}
								using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
								sqlConnection2.Open();
								_trans = sqlConnection2.BeginTransaction();
								SqlCommand sqlCommand = new SqlCommand();
								sqlCommand.Connection = sqlConnection2;
								sqlCommand.Transaction = _trans;
								sqlCommand.CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE PaperId='{item}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'";
								sqlCommand.CommandType = CommandType.Text;
								using (SqlCommand sqlCommand5 = sqlCommand)
								{
									sqlCommand5.ExecuteNonQuery();
								}
								sqlCommand = new SqlCommand();
								sqlCommand.Connection = sqlConnection2;
								sqlCommand.Transaction = _trans;
								sqlCommand.CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(studentClass)} WHERE PaperId='{item}' AND StudentNumber='{studentNo}' AND SemesterId='{semester}'";
								sqlCommand.CommandType = CommandType.Text;
								using (SqlCommand sqlCommand6 = sqlCommand)
								{
									sqlCommand6.ExecuteNonQuery();
								}
								_trans.Commit();
								sqlConnection2.Close();
							}
						}
						AuditTrail.CaptureActions("Dropped Subjects", $"Dropped subjects for {txtName.Text} - {semester}", AuditTrail.Departments.Academics, studentNo, txtClass.Text, 0m, 0m);
						LoadStudentSubjects();
						XtraMessageBox.Show("Subject (s) dropped successfully", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString() || (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
				{
					DropAllOLevel();
					if (studentClass == "S.1" || studentClass == "S.2" || studentClass == "S.3" || studentClass == "S.4")
					{
						LoadAllNewCurriculumSubjects();
					}
					else
					{
						LoadAllSubjectsForClass();
					}
				}
				else
				{
					if (!(SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString()) || !(classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString()))
					{
						return;
					}
					foreach (CheckedListBoxItem item2 in (IEnumerable)chkListSubjects.CheckedItems)
					{
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT SubjectId,PaperId  FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE SubjectId='{FirstWords(item2.ToString())}' AND SemesterId='{semester}' Group By SubjectId,PaperId", DataConnection.ConnectToDatabase());
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2, "CountOfPapers");
						if (dataSet2.Tables[0].Rows.Count == 1)
						{
							using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection3.Open();
							transs = sqlConnection3.BeginTransaction();
							using (SqlCommand sqlCommand7 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = transs,
								CommandText = $"DELETE FROM {SchoolSettings.GeneralReportGradingTableSource(studentClass)} WHERE SemesterId='{semester}' AND SubjectId='{FirstWords(item2.ToString())}'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand7.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand8 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = transs,
								CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE  SemesterId='{semester}' AND PaperId='{item2}'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand8.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand9 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = transs,
								CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(studentClass)} WHERE  SemesterId='{semester}' AND PaperId='{item2}'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand9.ExecuteNonQuery();
							}
							transs.Commit();
							sqlConnection3.Close();
						}
						else
						{
							if (dataSet2.Tables[0].Rows.Count <= 1)
							{
								continue;
							}
							using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection4.Open();
							transs = sqlConnection4.BeginTransaction();
							using (SqlCommand sqlCommand10 = new SqlCommand
							{
								Connection = sqlConnection4,
								Transaction = transs,
								CommandText = $"DELETE FROM {SchoolSettings.GeneralReportTableSource(studentClass)} WHERE  SemesterId='{semester}' AND PaperId='{item2}'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand10.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand11 = new SqlCommand
							{
								Connection = sqlConnection4,
								Transaction = transs,
								CommandText = $"DELETE FROM {SchoolSettings.ScoresTableSource(studentClass)} WHERE  SemesterId='{semester}' AND PaperId='{item2}'",
								CommandType = CommandType.Text
							})
							{
								sqlCommand11.ExecuteNonQuery();
							}
							transs.Commit();
							sqlConnection4.Close();
						}
					}
					if (studentClass == "S.1" || studentClass == "S.2" || studentClass == "S.3" || studentClass == "S.4")
					{
						LoadAllNewCurriculumSubjects();
					}
					else
					{
						LoadAllSubjectsForClass();
					}
					AuditTrail.CaptureActions("Dropped Subjects", $"Dropped subjects for the entire class {studentClass} - {semester}", AuditTrail.Departments.Academics, "", studentClass, 0m, 0m);
					XtraMessageBox.Show("Subject (s) dropped successfully", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
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

	private void dropSubjects_Load(object sender, EventArgs e)
	{
		if (!SubjectDropingMode.MainFormDrop)
		{
			lookUpClasses.Enabled = false;
			LoadStudentSubjects();
		}
		if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString())
		{
			if (ClassGroup == "Nursery")
			{
				Classes.LoadLookUpWithClasses(lookUpClasses, "Nursery");
			}
			else if (ClassGroup == "Primary")
			{
				Classes.LoadLookUpWithClasses(lookUpClasses, "Primary");
			}
			else
			{
				Classes.LoadLookUpWithClasses(lookUpClasses);
			}
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void radioGroupDrop_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!SubjectDropingMode.MainFormDrop)
		{
			return;
		}
		if (radioGroupDrop.SelectedIndex == 0)
		{
			layoutControlGroup3.Visibility = LayoutVisibility.Always;
			if (SubjectDropingMode.MainFormDrop)
			{
				LoadStudentSubjects();
			}
		}
		else if (radioGroupDrop.SelectedIndex == 1)
		{
			layoutControlGroup3.Visibility = LayoutVisibility.Never;
			txtClass.Text = string.Empty;
			txtName.Text = string.Empty;
			txtStream.Text = string.Empty;
			studentNo = string.Empty;
			lookUpClasses.Text = string.Empty;
		}
	}

	private void LoadStudentSubjects()
	{
		try
		{
			if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString() || (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
			{
				if (classLevel == "Nursery")
				{
					using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						string selectCommandText = $"SELECT * FROM tbl_Stud s Right outer join tbl_Scores_PrePrimary o on s.StudentNumber=o.StudentNumber WHERE s.StudentNumber='{studentNo}' AND o.SemesterId='{semester}'";
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet, "students");
						DataTable dataTable = new DataTable();
						dataTable = dataSet.Tables[0];
						chkListSubjects.Items.Clear();
						foreach (DataRow row in dataTable.Rows)
						{
							chkListSubjects.Items.Add(row["SubjectId"]);
						}
						return;
					}
				}
				if (!(classLevel == "Nursery") && !(classLevel == "OLevel"))
				{
					return;
				}
				using SqlConnection selectConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText2 = $"SELECT * FROM tbl_Stud s Right outer join {SchoolSettings.ScoresTableSource(studentClass)} o on s.StudentNumber=o.StudentNumber WHERE s.StudentNumber='{studentNo}' AND o.SemesterId='{semester}'";
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, selectConnection2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "students");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				chkListSubjects.Items.Clear();
				foreach (DataRow row2 in dataTable2.Rows)
				{
					chkListSubjects.Items.Add(row2["SubjectId"]);
				}
				return;
			}
			if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString())
			{
				using (SqlConnection selectConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					string selectCommandText3 = $"SELECT * FROM tbl_Stud s Right outer join {SchoolSettings.ScoresTableSource(studentClass)} a on s.StudentNumber=a.StudentNumber WHERE s.StudentNumber='{studentNo}' AND  a.SemesterId='{semester}'";
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, selectConnection3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "students");
					DataTable dataTable3 = new DataTable();
					dataTable3 = dataSet3.Tables[0];
					chkListSubjects.Items.Clear();
					foreach (DataRow row3 in dataTable3.Rows)
					{
						chkListSubjects.Items.Add(row3["PaperId"]);
					}
					return;
				}
			}
			chkListSubjects.Items.Clear();
			studentNo = string.Empty;
			searchLookUpEdit1.EditValue = null;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadAllNewCurriculumSubjects()
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT  SubjectId FROM  tbl_Scores_OL_Report GROUP BY SubjectId, SemesterId, ClassId HAVING(SemesterId = '{semester}') AND (ClassId = '{studentClass}')";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "students");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			chkListSubjects.Items.Clear();
			foreach (DataRow row in dataTable.Rows)
			{
				chkListSubjects.Items.Add(row["SubjectId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void LoadAllSubjectsForClass()
	{
		try
		{
			if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Primary.ToString() || (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.OLevel.ToString()))
			{
				if (classLevel == "Nursery")
				{
					using (SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
					{
						string selectCommandText = $"SELECT os.SubjectId AS Subject FROM tbl_Scores_PrePrimary s RIGHT OUTER JOIN OLevelSubjects os ON s.SubjectId = os.SubjectId GROUP BY s.SemesterId, os.SubjectId HAVING s.SemesterId = '{semester}'";
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet, "students");
						DataTable dataTable = new DataTable();
						dataTable = dataSet.Tables[0];
						chkListSubjects.Items.Clear();
						foreach (DataRow row in dataTable.Rows)
						{
							chkListSubjects.Items.Add(row["Subject"]);
						}
						return;
					}
				}
				if (!(classLevel == "Primary") && !(classLevel == "OLevel"))
				{
					return;
				}
				using SqlConnection selectConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText2 = $"SELECT os.SubjectId AS Subject FROM {SchoolSettings.ScoresTableSource(studentClass)} s RIGHT OUTER JOIN OLevelSubjects os ON s.SubjectId = os.SubjectId GROUP BY s.SemesterId, os.SubjectId HAVING s.SemesterId = '{semester}'";
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, selectConnection2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "students");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				chkListSubjects.Items.Clear();
				foreach (DataRow row2 in dataTable2.Rows)
				{
					chkListSubjects.Items.Add(row2["Subject"]);
				}
				return;
			}
			if (SchoolSettings.SchoolGeneralCurriculum == SchoolSettings.SchoolType.Secondary.ToString() && classLevel == SchoolSettings.SecondaryClassLevels.ALevel.ToString())
			{
				using (SqlConnection selectConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					string selectCommandText3 = $"SELECT s.PaperId AS Paper, s.SemesterId FROM ALevelSubjects_Categorised sb INNER JOIN  {SchoolSettings.ScoresTableSource(studentClass)} s ON sb.SubjectId = s.SubjectId GROUP BY s.PaperId, s.SemesterId HAVING  s.SemesterId = '{semester}'";
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, selectConnection3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "students");
					DataTable dataTable3 = new DataTable();
					dataTable3 = dataSet3.Tables[0];
					chkListSubjects.Items.Clear();
					foreach (DataRow row3 in dataTable3.Rows)
					{
						chkListSubjects.Items.Add(row3["Paper"]);
					}
					return;
				}
			}
			chkListSubjects.Items.Clear();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void txtStudentNumber_TextChanged(object sender, EventArgs e)
	{
		LoadStudentSubjects();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (chkListSubjects.CheckedItems.Count <= 0)
		{
			btnDrop.Enabled = false;
		}
		else
		{
			btnDrop.Enabled = true;
		}
	}

	private void lookUpClasses_Closed(object sender, ClosedEventArgs e)
	{
		if (lookUpClasses.EditValue == null)
		{
			return;
		}
		studentClass = lookUpClasses.Properties.GetDataSourceValue("ClassId", lookUpClasses.ItemIndex).ToString();
		classLevel = lookUpClasses.Properties.GetDataSourceValue("ClassGroup", lookUpClasses.ItemIndex).ToString();
		levelRanking = lookUpClasses.Properties.GetDataSourceValue("SubGroup", lookUpClasses.ItemIndex).ToString();
		LoadStudentsLookUp(searchLookUpEdit1, studentClass);
		if (radioGroupDrop.SelectedIndex == 1)
		{
			if (studentClass == "S.1" || studentClass == "S.2" || studentClass == "S.3" || studentClass == "S.4")
			{
				LoadAllNewCurriculumSubjects();
			}
			else
			{
				LoadAllSubjectsForClass();
			}
		}
		else if (radioGroupDrop.SelectedIndex == 0 && studentNo != string.Empty)
		{
			LoadStudentSubjects();
		}
	}

	private void searchLookUpEdit1_Closed(object sender, ClosedEventArgs e)
	{
		if (searchLookUpEdit1View.GetFocusedDataSourceRowIndex() > -1)
		{
			txtName.Text = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "Name").ToString();
			txtStream.Text = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "Stream").ToString();
			studentNo = searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "StudentNo").ToString();
			txtClass.Text = studentClass;
			byte[] array = new byte[0];
			array = (byte[])searchLookUpEdit1View.GetRowCellValue(searchLookUpEdit1View.GetFocusedDataSourceRowIndex(), "Picture");
			using (MemoryStream stream = new MemoryStream(array))
			{
				pictureEdit1.Image = Image.FromStream(stream);
			}
			if (studentClass != "N/A")
			{
				LoadStudentSubjects();
			}
		}
	}

	private void lookUpClasses_QueryPopUp(object sender, CancelEventArgs e)
	{
		txtClass.Text = string.Empty;
		txtName.Text = string.Empty;
		txtStream.Text = string.Empty;
		pictureEdit1.Image = null;
		searchLookUpEdit1.EditValue = null;
		studentClass = string.Empty;
		chkListSubjects.Items.Clear();
	}

	private void searchLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
	{
		txtClass.Text = string.Empty;
		txtName.Text = string.Empty;
		txtStream.Text = string.Empty;
		pictureEdit1.Image = null;
		searchLookUpEdit1.EditValue = null;
		chkListSubjects.Items.Clear();
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
		this.chkListSubjects = new DevExpress.XtraEditors.CheckedListBoxControl();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
		this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
		this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.lookUpClasses = new DevExpress.XtraEditors.LookUpEdit();
		this.radioGroupDrop = new DevExpress.XtraEditors.RadioGroup();
		this.txtStream = new DevExpress.XtraEditors.TextEdit();
		this.txtClass = new DevExpress.XtraEditors.TextEdit();
		this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
		this.txtName = new DevExpress.XtraEditors.TextEdit();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.btnClose = new DevExpress.XtraEditors.SimpleButton();
		this.btnDrop = new DevExpress.XtraEditors.SimpleButton();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.lblStudentNumber = new DevExpress.XtraEditors.LabelControl();
		this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
		((System.ComponentModel.ISupportInitialize)this.chkListSubjects).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1View).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroupDrop.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.chkSelectAll.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		base.SuspendLayout();
		this.chkListSubjects.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.chkListSubjects.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkListSubjects.Appearance.Options.UseFont = true;
		this.chkListSubjects.Location = new System.Drawing.Point(4, 31);
		this.chkListSubjects.Name = "chkListSubjects";
		this.chkListSubjects.Size = new System.Drawing.Size(392, 481);
		this.chkListSubjects.SortOrder = System.Windows.Forms.SortOrder.Ascending;
		this.chkListSubjects.StyleController = this.layoutControl1;
		this.chkListSubjects.TabIndex = 1;
		this.layoutControl1.Controls.Add(this.pictureEdit1);
		this.layoutControl1.Controls.Add(this.searchLookUpEdit1);
		this.layoutControl1.Controls.Add(this.lookUpClasses);
		this.layoutControl1.Controls.Add(this.radioGroupDrop);
		this.layoutControl1.Controls.Add(this.txtStream);
		this.layoutControl1.Controls.Add(this.chkListSubjects);
		this.layoutControl1.Controls.Add(this.txtClass);
		this.layoutControl1.Controls.Add(this.chkSelectAll);
		this.layoutControl1.Controls.Add(this.txtName);
		this.layoutControl1.Location = new System.Drawing.Point(1, 1);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(130, 75, 250, 350);
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(608, 516);
		this.layoutControl1.TabIndex = 21;
		this.layoutControl1.Text = "layoutControl1";
		this.pictureEdit1.Location = new System.Drawing.Point(403, 173);
		this.pictureEdit1.Name = "pictureEdit1";
		this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
		this.pictureEdit1.Size = new System.Drawing.Size(198, 183);
		this.pictureEdit1.StyleController = this.layoutControl1;
		this.pictureEdit1.TabIndex = 22;
		this.searchLookUpEdit1.Location = new System.Drawing.Point(403, 145);
		this.searchLookUpEdit1.Name = "searchLookUpEdit1";
		this.searchLookUpEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.searchLookUpEdit1.Properties.Appearance.Options.UseFont = true;
		this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.searchLookUpEdit1.Properties.NullText = "[Search Student]";
		this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
		this.searchLookUpEdit1.Size = new System.Drawing.Size(198, 24);
		this.searchLookUpEdit1.StyleController = this.layoutControl1;
		this.searchLookUpEdit1.TabIndex = 21;
		this.searchLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(searchLookUpEdit1_QueryPopUp);
		this.searchLookUpEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(searchLookUpEdit1_Closed);
		this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
		this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
		this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
		this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
		this.lookUpClasses.Location = new System.Drawing.Point(400, 85);
		this.lookUpClasses.Name = "lookUpClasses";
		this.lookUpClasses.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lookUpClasses.Properties.Appearance.Options.UseFont = true;
		this.lookUpClasses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.lookUpClasses.Properties.NullText = "[Select Class]";
		this.lookUpClasses.Size = new System.Drawing.Size(204, 24);
		this.lookUpClasses.StyleController = this.layoutControl1;
		this.lookUpClasses.TabIndex = 20;
		this.lookUpClasses.QueryPopUp += new System.ComponentModel.CancelEventHandler(lookUpClasses_QueryPopUp);
		this.lookUpClasses.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(lookUpClasses_Closed);
		this.radioGroupDrop.Location = new System.Drawing.Point(403, 26);
		this.radioGroupDrop.Name = "radioGroupDrop";
		this.radioGroupDrop.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
		this.radioGroupDrop.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.radioGroupDrop.Properties.Appearance.Options.UseBackColor = true;
		this.radioGroupDrop.Properties.Appearance.Options.UseFont = true;
		this.radioGroupDrop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
		this.radioGroupDrop.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[2]
		{
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single student"),
			new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Entire class")
		});
		this.radioGroupDrop.Size = new System.Drawing.Size(198, 52);
		this.radioGroupDrop.StyleController = this.layoutControl1;
		this.radioGroupDrop.TabIndex = 0;
		this.radioGroupDrop.SelectedIndexChanged += new System.EventHandler(radioGroupDrop_SelectedIndexChanged);
		this.txtStream.Location = new System.Drawing.Point(403, 483);
		this.txtStream.Name = "txtStream";
		this.txtStream.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStream.Properties.Appearance.Options.UseFont = true;
		this.txtStream.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtStream.Properties.ReadOnly = true;
		this.txtStream.Size = new System.Drawing.Size(198, 26);
		this.txtStream.StyleController = this.layoutControl1;
		this.txtStream.TabIndex = 17;
		this.txtClass.Location = new System.Drawing.Point(403, 432);
		this.txtClass.Name = "txtClass";
		this.txtClass.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtClass.Properties.Appearance.Options.UseFont = true;
		this.txtClass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtClass.Properties.ReadOnly = true;
		this.txtClass.Size = new System.Drawing.Size(198, 26);
		this.txtClass.StyleController = this.layoutControl1;
		this.txtClass.TabIndex = 16;
		this.chkSelectAll.Location = new System.Drawing.Point(4, 4);
		this.chkSelectAll.Name = "chkSelectAll";
		this.chkSelectAll.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkSelectAll.Properties.Appearance.Options.UseFont = true;
		this.chkSelectAll.Properties.Caption = "Check All";
		this.chkSelectAll.Size = new System.Drawing.Size(392, 23);
		this.chkSelectAll.StyleController = this.layoutControl1;
		this.chkSelectAll.TabIndex = 0;
		this.chkSelectAll.CheckedChanged += new System.EventHandler(chkSelectAll_CheckedChanged);
		this.txtName.Location = new System.Drawing.Point(403, 381);
		this.txtName.Name = "txtName";
		this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName.Properties.Appearance.Options.UseFont = true;
		this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtName.Properties.ReadOnly = true;
		this.txtName.Size = new System.Drawing.Size(198, 26);
		this.txtName.StyleController = this.layoutControl1;
		this.txtName.TabIndex = 13;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[6] { this.layoutControlItem1, this.layoutControlItem2, this.layoutControlItem6, this.layoutControlGroup2, this.layoutControlGroup3, this.emptySpaceItem1 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(608, 516);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.chkListSubjects;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 27);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(396, 485);
		this.layoutControlItem1.Text = "layoutControlItem1";
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextToControlDistance = 0;
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem2.Control = this.chkSelectAll;
		this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(396, 27);
		this.layoutControlItem2.Text = "layoutControlItem2";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextToControlDistance = 0;
		this.layoutControlItem2.TextVisible = false;
		this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem6.Control = this.lookUpClasses;
		this.layoutControlItem6.CustomizationFormText = "Class";
		this.layoutControlItem6.Location = new System.Drawing.Point(396, 81);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(208, 28);
		this.layoutControlItem6.Text = "Class";
		this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextToControlDistance = 0;
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlGroup2.CustomizationFormText = "Drop From";
		this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem4 });
		this.layoutControlGroup2.Location = new System.Drawing.Point(396, 0);
		this.layoutControlGroup2.Name = "layoutControlGroup2";
		this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup2.Size = new System.Drawing.Size(208, 81);
		this.layoutControlGroup2.Text = "Drop From";
		this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem4.Control = this.radioGroupDrop;
		this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(202, 56);
		this.layoutControlItem4.Text = "layoutControlItem4";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextToControlDistance = 0;
		this.layoutControlItem4.TextVisible = false;
		this.layoutControlGroup3.CustomizationFormText = "Find Student";
		this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem3, this.layoutControlItem7, this.layoutControlItem8, this.layoutControlItem9, this.layoutControlItem10 });
		this.layoutControlGroup3.Location = new System.Drawing.Point(396, 119);
		this.layoutControlGroup3.Name = "layoutControlGroup3";
		this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup3.Size = new System.Drawing.Size(208, 393);
		this.layoutControlGroup3.Text = "Find Student";
		this.layoutControlItem3.Control = this.searchLookUpEdit1;
		this.layoutControlItem3.CustomizationFormText = "Student";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(202, 28);
		this.layoutControlItem3.Text = "Student";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem7.Control = this.pictureEdit1;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(202, 187);
		this.layoutControlItem7.Text = "layoutControlItem7";
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextToControlDistance = 0;
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.txtName;
		this.layoutControlItem8.CustomizationFormText = "Name";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 215);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(202, 51);
		this.layoutControlItem8.Text = "Name";
		this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(47, 18);
		this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem9.Control = this.txtClass;
		this.layoutControlItem9.CustomizationFormText = "Class";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 266);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(202, 51);
		this.layoutControlItem9.Text = "Class";
		this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem9.TextSize = new System.Drawing.Size(47, 18);
		this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem10.Control = this.txtStream;
		this.layoutControlItem10.CustomizationFormText = "Stream";
		this.layoutControlItem10.Location = new System.Drawing.Point(0, 317);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(202, 51);
		this.layoutControlItem10.Text = "Stream";
		this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem10.TextSize = new System.Drawing.Size(47, 18);
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(396, 109);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(208, 10);
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnClose.Appearance.Options.UseFont = true;
		this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnClose.Location = new System.Drawing.Point(467, 531);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(143, 25);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "Cancel";
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.btnDrop.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnDrop.Appearance.Options.UseFont = true;
		this.btnDrop.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.btnDrop.Location = new System.Drawing.Point(4, 531);
		this.btnDrop.Name = "btnDrop";
		this.btnDrop.Size = new System.Drawing.Size(143, 25);
		this.btnDrop.TabIndex = 2;
		this.btnDrop.Text = "Drop subjects";
		this.btnDrop.Click += new System.EventHandler(btnDrop_Click);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.lblStudentNumber.Location = new System.Drawing.Point(128, 538);
		this.lblStudentNumber.Name = "lblStudentNumber";
		this.lblStudentNumber.Size = new System.Drawing.Size(0, 13);
		this.lblStudentNumber.TabIndex = 18;
		this.lblStudentNumber.Visible = false;
		this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl2.Visible = true;
		this.labelControl2.Location = new System.Drawing.Point(8, 515);
		this.labelControl2.Name = "labelControl2";
		this.labelControl2.Size = new System.Drawing.Size(594, 10);
		this.labelControl2.TabIndex = 19;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(613, 561);
		base.Controls.Add(this.layoutControl1);
		base.Controls.Add(this.labelControl2);
		base.Controls.Add(this.lblStudentNumber);
		base.Controls.Add(this.btnDrop);
		base.Controls.Add(this.btnClose);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "dropSubjects";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Drop subjects";
		base.Load += new System.EventHandler(dropSubjects_Load);
		((System.ComponentModel.ISupportInitialize)this.chkListSubjects).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.searchLookUpEdit1View).EndInit();
		((System.ComponentModel.ISupportInitialize)this.lookUpClasses.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.radioGroupDrop.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStream.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtClass.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.chkSelectAll.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
