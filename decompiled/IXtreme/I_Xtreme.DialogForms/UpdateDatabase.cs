using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class UpdateDatabase : XtraForm
{
	private SqlTransaction trans;

	private int maximum = 0;

	private int k = 1;

	private int w = 0;

	private SqlTransaction _trans;

	private IContainer components = null;

	private BackgroundWorker backgroundWorker1;

	private ProgressBarControl progressBarControl1;

	private System.Windows.Forms.Timer timer1;

	public UpdateDatabase()
	{
		InitializeComponent();
	}

	private void CreateStoredProcedures()
	{
		string connectionString = DataConnection.ConnectToDatabase();
		string path = Path.Combine(Application.StartupPath, "tables", "StoredProcedureUpdate.sql");
		try
		{
			string text = File.ReadAllText(path);
			string[] array = text.Split(new string[1] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (!string.IsNullOrWhiteSpace(text2))
				{
					using SqlCommand sqlCommand = new SqlCommand(text2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message);
		}
	}

	private void CreateMissingTables()
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		try
		{
			StreamReader streamReader = null;
			sqlConnection.Open();
			streamReader = new StreamReader(Application.StartupPath + "\\tables\\TableUpdates.sql", detectEncodingFromByteOrderMarks: true);
			string cmdText = streamReader.ReadToEnd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
		finally
		{
			if (sqlConnection.State == ConnectionState.Open)
			{
				sqlConnection.Close();
			}
		}
	}

	private void UpdateSuspendedStudents()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(12, "StudentID"));
			list.Add(new KeyValuePair<int, string>(100, "Sponsor"));
			list.Add(new KeyValuePair<int, string>(100, "SponsorContact"));
			list.Add(new KeyValuePair<int, string>(100, "mNIN"));
			list.Add(new KeyValuePair<int, string>(100, "fNIN"));
			list.Add(new KeyValuePair<int, string>(100, "sNIN"));
			list.Add(new KeyValuePair<int, string>(11, "PriorityContact"));
			list.Add(new KeyValuePair<int, string>(11, "OtherContact"));
			list.Add(new KeyValuePair<int, string>(100, "GuardianAddress"));
			list.Add(new KeyValuePair<int, string>(100, "Email"));
			list.Add(new KeyValuePair<int, string>(2000, "GamesAndSports"));
			list.Add(new KeyValuePair<int, string>(2000, "Clubs"));
			list.Add(new KeyValuePair<int, string>(50, "StreamEn"));
			list.Add(new KeyValuePair<int, string>(50, "SexAr"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_suspendedStudents')) BEGIN ALTER TABLE [tbl_suspendedStudents] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateScoresPrePrimary()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(100, "Numeracy"));
			list.Add(new KeyValuePair<int, string>(100, "Reading"));
			list.Add(new KeyValuePair<int, string>(100, "Vocabulary"));
			list.Add(new KeyValuePair<int, string>(100, "GeneralKnowledge"));
			list.Add(new KeyValuePair<int, string>(100, "PhysicalEducation"));
			list.Add(new KeyValuePair<int, string>(100, "Swimming"));
			list.Add(new KeyValuePair<int, string>(100, "Writing"));
			list.Add(new KeyValuePair<int, string>(100, "GodsCreation"));
			list.Add(new KeyValuePair<int, string>(100, "LifeSkills"));
			list.Add(new KeyValuePair<int, string>(100, "StoryTelling"));
			list.Add(new KeyValuePair<int, string>(100, "RhymesMusic"));
			list.Add(new KeyValuePair<int, string>(100, "Panctuality"));
			list.Add(new KeyValuePair<int, string>(100, "Smartness"));
			list.Add(new KeyValuePair<int, string>(100, "HeadteacherComment"));
			list.Add(new KeyValuePair<int, string>(100, "ClassteacherComment"));
			list.Add(new KeyValuePair<int, string>(100, "DosComment"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_PrePrimary')) BEGIN ALTER TABLE [tbl_Scores_PrePrimary] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateFeesPayment()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "ClassName"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'FeesPayment')) BEGIN ALTER TABLE [FeesPayment] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateOldStudents()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(12, "StudentID"));
			list.Add(new KeyValuePair<int, string>(100, "Sponsor"));
			list.Add(new KeyValuePair<int, string>(100, "SponsorContact"));
			list.Add(new KeyValuePair<int, string>(100, "mNIN"));
			list.Add(new KeyValuePair<int, string>(100, "fNIN"));
			list.Add(new KeyValuePair<int, string>(100, "sNIN"));
			list.Add(new KeyValuePair<int, string>(11, "PriorityContact"));
			list.Add(new KeyValuePair<int, string>(11, "OtherContact"));
			list.Add(new KeyValuePair<int, string>(100, "GuardianAddress"));
			list.Add(new KeyValuePair<int, string>(100, "GuardianRelation"));
			list.Add(new KeyValuePair<int, string>(100, "Email"));
			list.Add(new KeyValuePair<int, string>(2000, "GamesAndSports"));
			list.Add(new KeyValuePair<int, string>(2000, "Clubs"));
			list.Add(new KeyValuePair<int, string>(50, "StreamEn"));
			list.Add(new KeyValuePair<int, string>(50, "SexAr"));
			list.Add(new KeyValuePair<int, string>(50, "LIN"));
			list.Add(new KeyValuePair<int, string>(50, "fName"));
			list.Add(new KeyValuePair<int, string>(100, "ReportCentre"));
			list.Add(new KeyValuePair<int, string>(100, "HealthStatus"));
			list.Add(new KeyValuePair<int, string>(100, "Cocurricular"));
			list.Add(new KeyValuePair<int, string>(50, "fAddress"));
			list.Add(new KeyValuePair<int, string>(10, "fContact"));
			list.Add(new KeyValuePair<int, string>(50, "fEmail"));
			list.Add(new KeyValuePair<int, string>(50, "mName"));
			list.Add(new KeyValuePair<int, string>(50, "mAddress"));
			list.Add(new KeyValuePair<int, string>(10, "mContact"));
			list.Add(new KeyValuePair<int, string>(50, "mEmail"));
			list.Add(new KeyValuePair<int, string>(10, "DOB"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				string cmdText = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_oldStudents')) BEGIN ALTER TABLE [tbl_oldStudents] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key);
				if (list[i].Value == "DOB")
				{
					cmdText = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_oldStudents')) BEGIN ALTER TABLE [tbl_oldStudents] ADD {0} DATETIME END", list[i].Value);
				}
				using (DbCommand dbCommand = new SqlCommand(cmdText))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateOLevelAutoCommentsNC()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(500, "Headteacher1"));
			list.Add(new KeyValuePair<int, string>(500, "Headteacher2"));
			list.Add(new KeyValuePair<int, string>(500, "Headteacher3"));
			list.Add(new KeyValuePair<int, string>(500, "Headteacher4"));
			list.Add(new KeyValuePair<int, string>(500, "Classteacher1"));
			list.Add(new KeyValuePair<int, string>(500, "Classteacher2"));
			list.Add(new KeyValuePair<int, string>(500, "Classteacher3"));
			list.Add(new KeyValuePair<int, string>(500, "Classteacher4"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'OLevelAutoCommentsNC')) BEGIN ALTER TABLE [OLevelAutoCommentsNC] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateOLevelReportNC()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(100, "Topic"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'OLevelReportNC')) BEGIN ALTER TABLE [OLevelReportNC] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateGuardian()
	{
		k = 1;
		string commandText = "UPDATE tbl_Stud SET Guardian=@Guardian,PriorityContact=@PriorityContact,GuardianAddress=@GuardianAddress,Email=@Email WHERE Oid=@Oid AND (Guardian<>'-----' OR Guardian IS NOT NULL)";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Guardian", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		maximum = dataTable.Rows.Count;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		foreach (DataRow row in dataTable.Rows)
		{
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = commandText,
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = Guid.Parse(row["studentOid"].ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
				sqlParameter.Value = row["GuardianName"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@PriorityContact", SqlDbType.VarChar, 11);
				sqlParameter.Value = row["GuardianContact"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@GuardianAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = row["GuardianAddress"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100);
				sqlParameter.Value = row["Email"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_Guardian WHERE GuardianId=@GuardianId",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@GuardianId", SqlDbType.BigInt);
				sqlParameter2.Value = Convert.ToInt64(row["GuardianId"].ToString());
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			k++;
			Thread.Sleep(10);
			backgroundWorker1.ReportProgress(k);
		}
	}

	private void UpdateSMSLogo()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(500, "UniqueSMS"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_SMSLog')) BEGIN ALTER TABLE [tbl_SMSLog] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateStudentPass1()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "fullNameAr"));
			list.Add(new KeyValuePair<int, string>(20, "ClassIdEn"));
			list.Add(new KeyValuePair<int, string>(20, "ClassIdAr"));
			list.Add(new KeyValuePair<int, string>(8, "StreamAr"));
			list.Add(new KeyValuePair<int, string>(100, "mNIN"));
			list.Add(new KeyValuePair<int, string>(100, "fNIN"));
			list.Add(new KeyValuePair<int, string>(100, "sNIN"));
			list.Add(new KeyValuePair<int, string>(12, "StudentID"));
			list.Add(new KeyValuePair<int, string>(11, "PriorityContact"));
			list.Add(new KeyValuePair<int, string>(11, "OtherContact"));
			list.Add(new KeyValuePair<int, string>(50, "Sponsor"));
			list.Add(new KeyValuePair<int, string>(11, "SponsorContact"));
			list.Add(new KeyValuePair<int, string>(50, "GuardianAddress"));
			list.Add(new KeyValuePair<int, string>(100, "Email"));
			list.Add(new KeyValuePair<int, string>(3000, "GamesAndSports"));
			list.Add(new KeyValuePair<int, string>(3000, "Clubs"));
			list.Add(new KeyValuePair<int, string>(3000, "GenericSkills"));
			list.Add(new KeyValuePair<int, string>(50, "StreamEn"));
			list.Add(new KeyValuePair<int, string>(50, "SexAr"));
			list.Add(new KeyValuePair<int, string>(50, "LIN"));
			list.Add(new KeyValuePair<int, string>(100, "ReportCentre"));
			list.Add(new KeyValuePair<int, string>(100, "Cocurricular"));
			list.Add(new KeyValuePair<int, string>(100, "HealthStatus"));
			list.Add(new KeyValuePair<int, string>(100, "GuardianRelation"));
			list.Add(new KeyValuePair<int, string>(30, "Term"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Stud')) BEGIN ALTER TABLE [tbl_Stud] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSuspendedStudentsPass1()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "fullNameAr"));
			list.Add(new KeyValuePair<int, string>(20, "ClassIdEn"));
			list.Add(new KeyValuePair<int, string>(20, "ClassIdAr"));
			list.Add(new KeyValuePair<int, string>(8, "StreamAr"));
			list.Add(new KeyValuePair<int, string>(100, "mNIN"));
			list.Add(new KeyValuePair<int, string>(100, "fNIN"));
			list.Add(new KeyValuePair<int, string>(100, "sNIN"));
			list.Add(new KeyValuePair<int, string>(12, "StudentID"));
			list.Add(new KeyValuePair<int, string>(11, "PriorityContact"));
			list.Add(new KeyValuePair<int, string>(11, "OtherContact"));
			list.Add(new KeyValuePair<int, string>(50, "Sponsor"));
			list.Add(new KeyValuePair<int, string>(11, "SponsorContact"));
			list.Add(new KeyValuePair<int, string>(50, "GuardianAddress"));
			list.Add(new KeyValuePair<int, string>(100, "Email"));
			list.Add(new KeyValuePair<int, string>(2000, "GamesAndSports"));
			list.Add(new KeyValuePair<int, string>(2000, "Clubs"));
			list.Add(new KeyValuePair<int, string>(50, "StreamEn"));
			list.Add(new KeyValuePair<int, string>(50, "SexAr"));
			list.Add(new KeyValuePair<int, string>(50, "LIN"));
			list.Add(new KeyValuePair<int, string>(100, "ReportCentre"));
			list.Add(new KeyValuePair<int, string>(100, "Cocurricular"));
			list.Add(new KeyValuePair<int, string>(100, "HealthStatus"));
			list.Add(new KeyValuePair<int, string>(100, "GuardianRelation"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_SuspendedStudents')) BEGIN ALTER TABLE [tbl_SuspendedStudents] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateScoresOLReport()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "Identifier100"));
			list.Add(new KeyValuePair<int, string>(80, "Descriptor100"));
			list.Add(new KeyValuePair<int, string>(3, "Score100"));
			list.Add(new KeyValuePair<int, string>(4, "OutOfTen"));
			list.Add(new KeyValuePair<int, string>(4, "PTotal"));
			list.Add(new KeyValuePair<int, string>(4, "PrevOutOfTen"));
			list.Add(new KeyValuePair<int, string>(4, "T1"));
			list.Add(new KeyValuePair<int, string>(4, "T2"));
			list.Add(new KeyValuePair<int, string>(4, "T3"));
			list.Add(new KeyValuePair<int, string>(4, "T4"));
			list.Add(new KeyValuePair<int, string>(4, "T5"));
			list.Add(new KeyValuePair<int, string>(4, "T6"));
			list.Add(new KeyValuePair<int, string>(4, "T7"));
			list.Add(new KeyValuePair<int, string>(4, "T8"));
			list.Add(new KeyValuePair<int, string>(4, "T9"));
			list.Add(new KeyValuePair<int, string>(4, "T10"));
			list.Add(new KeyValuePair<int, string>(4, "P1"));
			list.Add(new KeyValuePair<int, string>(4, "P2"));
			list.Add(new KeyValuePair<int, string>(4, "P3"));
			list.Add(new KeyValuePair<int, string>(4, "P4"));
			list.Add(new KeyValuePair<int, string>(4, "P5"));
			list.Add(new KeyValuePair<int, string>(4, "P6"));
			list.Add(new KeyValuePair<int, string>(4, "P7"));
			list.Add(new KeyValuePair<int, string>(4, "P8"));
			list.Add(new KeyValuePair<int, string>(4, "P9"));
			list.Add(new KeyValuePair<int, string>(4, "P10"));
			list.Add(new KeyValuePair<int, string>(200, "Topic_1"));
			list.Add(new KeyValuePair<int, string>(200, "Topic_2"));
			list.Add(new KeyValuePair<int, string>(200, "Topic_3"));
			list.Add(new KeyValuePair<int, string>(200, "Topic_4"));
			list.Add(new KeyValuePair<int, string>(2000, "Competence_1"));
			list.Add(new KeyValuePair<int, string>(2000, "Competence_2"));
			list.Add(new KeyValuePair<int, string>(2000, "Competence_3"));
			list.Add(new KeyValuePair<int, string>(2000, "Competence_4"));
			list.Add(new KeyValuePair<int, string>(2000, "GenericSkill_1"));
			list.Add(new KeyValuePair<int, string>(2000, "GenericSkill_2"));
			list.Add(new KeyValuePair<int, string>(2000, "GenericSkill_3"));
			list.Add(new KeyValuePair<int, string>(2000, "GenericSkill_4"));
			list.Add(new KeyValuePair<int, string>(80, "Descriptor_1"));
			list.Add(new KeyValuePair<int, string>(80, "Descriptor_2"));
			list.Add(new KeyValuePair<int, string>(80, "Descriptor_3"));
			list.Add(new KeyValuePair<int, string>(80, "Descriptor_4"));
			list.Add(new KeyValuePair<int, string>(200, "TeacherRemarks"));
			list.Add(new KeyValuePair<int, string>(200, "TeacherRemarksDesc"));
			list.Add(new KeyValuePair<int, string>(500, "Project"));
			list.Add(new KeyValuePair<int, string>(100, "ProjectTitle"));
			list.Add(new KeyValuePair<int, string>(200, "ClassteacherRemark"));
			list.Add(new KeyValuePair<int, string>(200, "HeadteacherRemark"));
			list.Add(new KeyValuePair<int, string>(200, "GenericSkills"));
			list.Add(new KeyValuePair<int, string>(200, "WriteComment"));
			list.Add(new KeyValuePair<int, string>(200, "ClassteacherRemarkFA"));
			list.Add(new KeyValuePair<int, string>(200, "HeadteacherRemarkFA"));
			list.Add(new KeyValuePair<int, string>(50, "OverallPerformance"));
			list.Add(new KeyValuePair<int, string>(2000, "OtherRequirements"));
			list.Add(new KeyValuePair<int, string>(200, "ProjAv"));
			list.Add(new KeyValuePair<int, string>(200, "ProjLO"));
			list.Add(new KeyValuePair<int, string>(200, "ProjIdentify"));
			list.Add(new KeyValuePair<int, string>(200, "ProjRemark"));
			list.Add(new KeyValuePair<int, string>(200, "ClassTeacherProject"));
			list.Add(new KeyValuePair<int, string>(200, "HeadTeacherProject"));
			list.Add(new KeyValuePair<int, string>(50, "OverallPerformanceLO"));
			list.Add(new KeyValuePair<int, string>(50, "OverallPerformance100"));
			list.Add(new KeyValuePair<int, string>(200, "TeacherRemarksAIOnly"));
			list.Add(new KeyValuePair<int, string>(3, "CategoryAIOnly"));
			list.Add(new KeyValuePair<int, string>(200, "PICLO"));
			list.Add(new KeyValuePair<int, string>(200, "PISLO"));
			list.Add(new KeyValuePair<int, string>(200, "PICLOEOT"));
			list.Add(new KeyValuePair<int, string>(200, "PISLOEOT"));
			list.Add(new KeyValuePair<int, string>(200, "PICEOT"));
			list.Add(new KeyValuePair<int, string>(200, "PISEOT"));
			list.Add(new KeyValuePair<int, string>(200, "SIC"));
			list.Add(new KeyValuePair<int, string>(50, "SIS"));
			list.Add(new KeyValuePair<int, string>(50, "SubPosLO"));
			list.Add(new KeyValuePair<int, string>(200, "SubPosEOT"));
			list.Add(new KeyValuePair<int, string>(3, "SubPosLOEOT"));
			list.Add(new KeyValuePair<int, string>(3, "GrandAvg"));
			list.Add(new KeyValuePair<int, string>(3, "GrandAvgLO"));
			list.Add(new KeyValuePair<int, string>(3, "GrandAvgEOT"));
			list.Add(new KeyValuePair<int, string>(3, "SubjectRank"));
			list.Add(new KeyValuePair<int, string>(3, "TotalStudents"));
			list.Add(new KeyValuePair<int, string>(3, "Weight"));
			list.Add(new KeyValuePair<int, string>(3, "IsEdited"));
			list.Add(new KeyValuePair<int, string>(3, "UniqueId"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = ((!(list[i].Value == "Score100") && !(list[i].Value == "OutOfTen") && !(list[i].Value == "PrevOutOfTen") && !(list[i].Value == "PTotal")) ? ((list[i].Value == "Identifier100") ? string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} INT END", list[i].Value) : ((list[i].Value == "Weight") ? string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} INT END", list[i].Value) : ((list[i].Value == "ProjAv") ? string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} FLOAT END", list[i].Value) : ((!(list[i].Value == "ProjLO") && !(list[i].Value == "GrandAvg") && !(list[i].Value == "GrandAvgLO") && !(list[i].Value == "GrandAvgEOT")) ? ((!(list[i].Value == "ProjIdentify") && !(list[i].Value == "PICLO") && !(list[i].Value == "PISLO") && !(list[i].Value == "PICLOEOT") && !(list[i].Value == "PISLOEOT") && !(list[i].Value == "PICEOT") && !(list[i].Value == "PISEOT") && !(list[i].Value == "SIC") && !(list[i].Value == "SIS") && !(list[i].Value == "SubPosLO") && !(list[i].Value == "SubPosEOT") && !(list[i].Value == "SubPosLOEOT") && !(list[i].Value == "SubjectRank") && !(list[i].Value == "TotalStudents")) ? ((list[i].Value == "WriteComment" || list[i].Value == "IsEdited") ? string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} BIT END", list[i].Value) : ((!(list[i].Value == "UniqueId")) ? string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key) : "IF NOT EXISTS(SELECT * FROM sys.columns \r\n                            WHERE [name] = N'UniqueId' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report'))\r\n                            BEGIN\r\n                                ALTER TABLE [tbl_Scores_OL_Report] \r\n                                ADD UniqueId UNIQUEIDENTIFIER NOT NULL \r\n                                CONSTRAINT [DF_tbl_Scores_OL_Report_UniqueId] DEFAULT NEWID() \r\n                                ROWGUIDCOL\r\n                            END")) : string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} INT END", list[i].Value)) : string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} FLOAT END", list[i].Value))))) : string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Scores_OL_Report')) BEGIN ALTER TABLE [tbl_Scores_OL_Report] ADD {0} FLOAT END", list[i].Value));
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateStaff()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "ContractExpiryDate"));
			list.Add(new KeyValuePair<int, string>(10, "OtherContact"));
			list.Add(new KeyValuePair<int, string>(50, "MESNo"));
			list.Add(new KeyValuePair<int, string>(50, "NIN"));
			list.Add(new KeyValuePair<int, string>(12, "StaffIdNumber"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = ((!(list[i].Value == "ContractExpiryDate")) ? string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'Staff')) BEGIN ALTER TABLE [Staff] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key) : string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'Staff')) BEGIN ALTER TABLE [Staff] ADD {0} DATETIME END", list[i].Value));
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateTermSettingsNC()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(20, "ProjectAvailable"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_TermSettingsNC')) BEGIN ALTER TABLE [tbl_TermSettingsNC] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateTermSettings()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(20, "AEOT"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_TermSettings')) BEGIN ALTER TABLE [tbl_TermSettings] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateReportSettings()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(20, "ShowRawScores"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_ReportSettings')) BEGIN ALTER TABLE [tbl_ReportSettings] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateUserLogin()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "SendSMS"));
			list.Add(new KeyValuePair<int, string>(20, "UseDashBoard"));
			list.Add(new KeyValuePair<int, string>(20, "EditContact"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_userLogin')) BEGIN ALTER TABLE [tbl_userLogin] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSchoolDetailsPass1()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "SendSMS"));
			list.Add(new KeyValuePair<int, string>(20, "UseDashBoard"));
			list.Add(new KeyValuePair<int, string>(20, "Normalized"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'SchoolDetails')) BEGIN ALTER TABLE [SchoolDetails] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSchoolDetailsPass2()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(100, "SchoolCode"));
			list.Add(new KeyValuePair<int, string>(100, "LicensedBy"));
			list.Add(new KeyValuePair<int, string>(100, "BankName"));
			list.Add(new KeyValuePair<int, string>(100, "AccountNumber"));
			list.Add(new KeyValuePair<int, string>(100, "AccountName"));
			list.Add(new KeyValuePair<int, string>(100, "Country"));
			list.Add(new KeyValuePair<int, string>(100, "Branch"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'SchoolDetails')) BEGIN ALTER TABLE [SchoolDetails] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateStudentIDSNo()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(200, "_ccccc"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_StudentIDSNo')) BEGIN ALTER TABLE [tbl_StudentIDSNo] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateReportCommentsNC()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(500, "GenericSkills"));
			list.Add(new KeyValuePair<int, string>(500, "OtherSkills"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'ReportCommentsNC')) BEGIN ALTER TABLE [ReportCommentsNC] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void TempVoucher()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "VoucherType"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_TempVoucher')) BEGIN ALTER TABLE [tbl_TempVoucher] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateExpenses()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(11, "Contact"));
			list.Add(new KeyValuePair<int, string>(200, "Address"));
			list.Add(new KeyValuePair<int, string>(100, "Payee"));
			list.Add(new KeyValuePair<int, string>(500, "NarrationBig"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'Expenses')) BEGIN ALTER TABLE [Expenses] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateFeesPaymentPass1()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "IsPIK"));
			list.Add(new KeyValuePair<int, string>(50, "PIKPaid"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'FeesPayment')) BEGIN ALTER TABLE [FeesPayment] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateFeesPaymentPass2()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "PIKQty"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'FeesPayment')) BEGIN ALTER TABLE [FeesPayment] ADD {0} INT END", list[i].Value);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void UpdateStudentPass2()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "IsSynched"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Stud')) BEGIN ALTER TABLE [tbl_Stud] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateStudentPass3()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "GuardianPic"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Stud')) BEGIN ALTER TABLE [tbl_Stud] ADD {0} IMAGE  END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSuspendedStudentsPass2()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "IsSynched"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_SuspendedStudents')) BEGIN ALTER TABLE [tbl_SuspendedStudents] ADD {0} BIT default 'FALSE' END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSuspendedStudentsPass3()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "GuardianPic"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_SuspendedStudents')) BEGIN ALTER TABLE [tbl_SuspendedStudents] ADD {0} IMAGE  END", list[i].Value)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void AlterSubjectCombinations()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "combFull"));
			list.Add(new KeyValuePair<int, string>(50, "combShort"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand($"ALTER TABLE tbl_SubjectCombinations ALTER COLUMN {list[i].Value} VARCHAR ({list[i].Key}) NOT NULL"))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void AlterNarrationSizes()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(500, "NarrationBig"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand($"ALTER TABLE Expenses ALTER COLUMN {list[i].Value} VARCHAR ({list[i].Key}) NULL"))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void AlterScoresOLReportSizes()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(100, "P4"));
			list.Add(new KeyValuePair<int, string>(500, "P6"));
			list.Add(new KeyValuePair<int, string>(500, "P8"));
			list.Add(new KeyValuePair<int, string>(2000, "GenericSkills"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand($"ALTER TABLE tbl_Scores_OL_Report ALTER COLUMN {list[i].Value} VARCHAR ({list[i].Key}) NULL"))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void AlterFeesPayment()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "BankSlipNo"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand($"ALTER TABLE FeesPayment ALTER COLUMN {list[i].Value} VARCHAR ({list[i].Key}) NOT NULL"))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSuppliers()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(50, "TIN"));
			list.Add(new KeyValuePair<int, string>(50, "RegNo"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand(string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'tbl_Suppliers')) BEGIN ALTER TABLE [tbl_Suppliers] ADD {0} NVARCHAR({1}) NULL END", list[i].Value, list[i].Key)))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSchoolDetailsPass3()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(500, "SchoolName"));
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				using (DbCommand dbCommand = new SqlCommand($"ALTER TABLE SchoolDetails ALTER COLUMN {list[i].Value} VARCHAR ({list[i].Key}) NOT NULL"))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception)
		{
		}
	}

	private void UpdateSchoolDetailsPass4()
	{
		try
		{
			k = 1;
			List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
			list.Add(new KeyValuePair<int, string>(100, "NumberDisplay"));
			string text = "";
			maximum = list.Count;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			for (int i = 0; i < list.Count; i++)
			{
				sqlConnection.Open();
				text = string.Format("IF NOT EXISTS(SELECT * FROM sys.columns WHERE [name] = N'{0}' AND [object_id] = OBJECT_ID(N'SchoolDetails')) BEGIN ALTER TABLE [SchoolDetails] ADD {0} INT NULL END", list[i].Value, list[i].Key);
				using (DbCommand dbCommand = new SqlCommand(text))
				{
					dbCommand.Connection = sqlConnection;
					dbCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		Subjects.UpdateAllSubjectsRegistered();
		UpdateSchoolDetailsPass1();
		UpdateSchoolDetailsPass2();
		UpdateSchoolDetailsPass3();
		UpdateSchoolDetailsPass4();
		UpdateSuspendedStudents();
		UpdateOldStudents();
		UpdateFeesPaymentPass1();
		UpdateFeesPaymentPass2();
		AlterFeesPayment();
		UpdateFeesPayment();
		UpdateScoresOLReport();
		UpdateSuspendedStudentsPass1();
		UpdateSuspendedStudentsPass2();
		UpdateSuspendedStudentsPass3();
		UpdateStudentPass1();
		UpdateStudentPass2();
		UpdateStudentPass3();
		UpdateGuardian();
		UpdateStaff();
		UpdateExpenses();
		AlterNarrationSizes();
		UpdateUserLogin();
		UpdateStudentIDSNo();
		UpdateReportCommentsNC();
		UpdateTermSettings();
		UpdateOLevelReportNC();
		CreateMissingTables();
		TempVoucher();
		AlterSubjectCombinations();
		UpdateSuppliers();
		UpdateReportSettings();
		UpdateSMSLogo();
		UpdateScoresPrePrimary();
		UpdateTermSettingsNC();
		AlterScoresOLReportSizes();
		UpdateOLevelAutoCommentsNC();
		CreateStoredProcedures();
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		XtraMessageBox.Show("Database updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		Close();
	}

	private void UpdateDatabase_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		w++;
		if (w == 3)
		{
			timer1.Enabled = false;
			w = 0;
			backgroundWorker1.RunWorkerAsync();
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
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(344, 53);
		this.progressBarControl1.TabIndex = 0;
		this.timer1.Interval = 500;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(344, 53);
		base.Controls.Add(this.progressBarControl1);
		this.DoubleBuffered = true;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "UpdateDatabase";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Updating database. Please wait...";
		base.Load += new System.EventHandler(UpdateDatabase_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
