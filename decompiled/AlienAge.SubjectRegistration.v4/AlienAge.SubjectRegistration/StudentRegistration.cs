using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AlienAge.SubjectRegistration;

[Serializable]
public class StudentRegistration
{
	private static int k;

	private static SqlTransaction _trans;

	private static SqlTransaction _transaction;

	private static DataSet dataSet;

	private static DataSet dataSet_A;

	private static int LevelToRegister { get; set; }

	private static CheckedListBoxControl chkSubjects { get; set; }

	private static int AcademicYear { get; set; }

	private static string SelectedClass { get; set; }

	private static string StudentNumber { get; set; }

	private static int RegistrationMode { get; set; }

	private static int CurrentAcademicYear
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
			StudentRegistration studentRegistration = new StudentRegistration();
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				studentRegistration = (StudentRegistration)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return AcademicYear;
		}
	}

	public static int LevelForRegistration
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
			StudentRegistration studentRegistration = new StudentRegistration();
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				studentRegistration = (StudentRegistration)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return LevelToRegister;
		}
	}

	public static int ModeOfRegistration
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
			StudentRegistration studentRegistration = new StudentRegistration();
			using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				studentRegistration = (StudentRegistration)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
			}
			return RegistrationMode;
		}
	}

	private static string CurrentClass()
	{
		try
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
			StudentRegistration studentRegistration = new StudentRegistration();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRegistration = (StudentRegistration)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return SelectedClass;
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	private static string CurrentStudent()
	{
		try
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
			StudentRegistration studentRegistration = new StudentRegistration();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRegistration = (StudentRegistration)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return StudentNumber;
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	private static string FirstWords(string input, int numberWords)
	{
		try
		{
			int num = numberWords;
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == ' ')
				{
					num--;
				}
				if (num == 0)
				{
					return input.Substring(0, i);
				}
			}
		}
		catch (Exception ex)
		{
			throw ex;
		}
		return string.Empty;
	}

	private static void RegisterALevel(string scoreProcedure, string reportProcedure, string gradingProcedure, string SubjectTable, string academicYear, string studentDataSource, string gradingTable)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Expected O, but got Unknown
		try
		{
			foreach (CheckedListBoxItem item in (IEnumerable)((BaseCheckedListBoxControl)chkSubjects).CheckedItems)
			{
				CheckedListBoxItem val = item;
				string text = FirstWords(((object)val).ToString(), 1);
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				string selectCommandText = $"SELECT * FROM {studentDataSource}";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
				dataSet_A = new DataSet();
				sqlDataAdapter.Fill(dataSet_A, "students");
				DataTable dataTable = dataSet_A.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					string[] array = "TermI- TermII- TermIII-".Split();
					foreach (string text2 in array)
					{
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						SqlCommand sqlCommand = new SqlCommand();
						sqlCommand.CommandText = $"SELECT * FROM {SubjectTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId ";
						sqlCommand.Connection = sqlConnection2;
						sqlCommand.CommandType = CommandType.Text;
						using SqlCommand sqlCommand2 = sqlCommand;
						sqlCommand2.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
						sqlCommand2.Parameters.AddWithValue("@SemesterId", text2 + academicYear);
						sqlCommand2.Parameters.AddWithValue("@PaperId", ((object)val).ToString());
						SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							sqlConnection2.Close();
							continue;
						}
						sqlConnection2.Close();
						using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection3.Open();
						_trans = sqlConnection3.BeginTransaction();
						SqlCommand sqlCommand3 = new SqlCommand();
						sqlCommand3.Connection = sqlConnection3;
						sqlCommand3.Transaction = _trans;
						sqlCommand3.CommandText = scoreProcedure;
						sqlCommand3.CommandType = CommandType.Text;
						using (SqlCommand sqlCommand4 = sqlCommand3)
						{
							SqlParameter sqlParameter = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
							sqlParameter.Value = row["StudentNumber"].ToString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 10);
							sqlParameter.Value = text2 + academicYear;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
							sqlParameter.Value = ((object)val).ToString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@HoP", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@BOT", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@MOT", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@EOT", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter.Value = text.TrimEnd();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						SqlCommand sqlCommand5 = new SqlCommand();
						sqlCommand5.Connection = sqlConnection3;
						sqlCommand5.Transaction = _trans;
						sqlCommand5.CommandText = reportProcedure;
						sqlCommand5.CommandType = CommandType.Text;
						using (SqlCommand sqlCommand6 = sqlCommand5)
						{
							SqlParameter sqlParameter2 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
							sqlParameter2.Value = row["StudentNumber"].ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@HoP", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@BOT", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@MOT", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@EOT", SqlDbType.VarChar, 4);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@AvMark", SqlDbType.VarChar, 5);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Grade", SqlDbType.VarChar, 1);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Category", SqlDbType.VarChar, 2);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 10);
							sqlParameter2.Value = text2 + academicYear;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Subjectid", SqlDbType.VarChar, 50);
							sqlParameter2.Value = text.TrimEnd();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = ((object)val).ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand6.ExecuteNonQuery();
						}
						_trans.Commit();
						sqlConnection3.Close();
					}
				}
			}
			foreach (CheckedListBoxItem item2 in (IEnumerable)((BaseCheckedListBoxControl)chkSubjects).CheckedItems)
			{
				CheckedListBoxItem val = item2;
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				string selectCommandText = $"SELECT * FROM {studentDataSource}";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
				dataSet_A = new DataSet();
				sqlDataAdapter.Fill(dataSet_A, "students");
				DataTable dataTable = dataSet_A.Tables[0];
				foreach (DataRow row2 in dataTable.Rows)
				{
					string[] array = "TermI- TermII- TermIII-".Split();
					foreach (string text2 in array)
					{
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						SqlCommand sqlCommand7 = new SqlCommand();
						sqlCommand7.CommandText = $"SELECT * FROM {gradingTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId ";
						sqlCommand7.Connection = sqlConnection2;
						sqlCommand7.CommandType = CommandType.Text;
						using SqlCommand sqlCommand2 = sqlCommand7;
						sqlCommand2.Parameters.AddWithValue("@StudentNumber", row2["StudentNumber"].ToString());
						sqlCommand2.Parameters.AddWithValue("@SemesterId", text2 + academicYear);
						sqlCommand2.Parameters.AddWithValue("@SubjectId", FirstWords(((object)val).ToString(), 1));
						SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							sqlConnection2.Close();
							continue;
						}
						sqlConnection2.Close();
						using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection4.Open();
						SqlCommand sqlCommand8 = new SqlCommand();
						sqlCommand8.Connection = sqlConnection4;
						sqlCommand8.CommandText = gradingProcedure;
						sqlCommand8.CommandType = CommandType.Text;
						using SqlCommand sqlCommand6 = sqlCommand8;
						SqlParameter sqlParameter2 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
						sqlParameter2.Value = row2["StudentNumber"].ToString();
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = text2 + academicYear;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Subjectid", SqlDbType.VarChar, 50);
						sqlParameter2.Value = FirstWords(((object)val).ToString(), 1);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Points", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Grade", SqlDbType.VarChar, 2);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@AverageMark", SqlDbType.VarChar, 5);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@hop", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "100";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@bot", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "100";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@mot", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "100";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@eot", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "100";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@TotalPoints", SqlDbType.VarChar, 2);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand6.ExecuteNonQuery();
					}
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void RegisterALevelCustom(string scoreProcedure, string reportProcedure, string gradingProcedure, string SubjectTable, string academicYear, string studentNumber, string gradingTable)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Expected O, but got Unknown
		try
		{
			foreach (CheckedListBoxItem item in (IEnumerable)((BaseCheckedListBoxControl)chkSubjects).CheckedItems)
			{
				CheckedListBoxItem val = item;
				string[] array = "TermI- TermII- TermIII-".Split();
				foreach (string text in array)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand();
					sqlCommand.CommandText = $"SELECT * FROM {SubjectTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND PaperId=@PaperId";
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					using SqlCommand sqlCommand2 = sqlCommand;
					sqlCommand2.Parameters.AddWithValue("@StudentNumber", studentNumber);
					sqlCommand2.Parameters.AddWithValue("@SemesterId", text + academicYear);
					sqlCommand2.Parameters.AddWithValue("@PaperId", ((object)val).ToString());
					SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						sqlConnection.Close();
					}
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					_trans = sqlConnection2.BeginTransaction();
					SqlCommand sqlCommand3 = new SqlCommand();
					sqlCommand3.Connection = sqlConnection2;
					sqlCommand3.Transaction = _trans;
					sqlCommand3.CommandText = scoreProcedure;
					sqlCommand3.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand4 = sqlCommand3)
					{
						SqlParameter sqlParameter = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
						sqlParameter.Value = studentNumber;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 10);
						sqlParameter.Value = text + academicYear;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
						sqlParameter.Value = ((object)val).ToString();
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@HoP", SqlDbType.VarChar, 10);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@BOT", SqlDbType.VarChar, 10);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@MOT", SqlDbType.VarChar, 10);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@EOT", SqlDbType.VarChar, 10);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = FirstWords(((object)val).ToString(), 1);
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand4.ExecuteNonQuery();
					}
					SqlCommand sqlCommand5 = new SqlCommand();
					sqlCommand5.Connection = sqlConnection2;
					sqlCommand5.Transaction = _trans;
					sqlCommand5.CommandText = reportProcedure;
					sqlCommand5.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand6 = sqlCommand5)
					{
						SqlParameter sqlParameter2 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
						sqlParameter2.Value = studentNumber;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@HoP", SqlDbType.VarChar, 4);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@BOT", SqlDbType.VarChar, 4);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@MOT", SqlDbType.VarChar, 4);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@EOT", SqlDbType.VarChar, 4);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@AvMark", SqlDbType.VarChar, 5);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Grade", SqlDbType.VarChar, 1);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Category", SqlDbType.VarChar, 2);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 10);
						sqlParameter2.Value = text + academicYear;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Subjectid", SqlDbType.VarChar, 50);
						sqlParameter2.Value = FirstWords(((object)val).ToString(), 1);
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@PaperId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = ((object)val).ToString();
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand6.ExecuteNonQuery();
					}
					_trans.Commit();
					sqlConnection2.Close();
				}
			}
			foreach (CheckedListBoxItem item2 in (IEnumerable)((BaseCheckedListBoxControl)chkSubjects).CheckedItems)
			{
				CheckedListBoxItem val2 = item2;
				string[] array = "TermI- TermII- TermIII-".Split();
				foreach (string text in array)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					SqlCommand sqlCommand7 = new SqlCommand();
					sqlCommand7.CommandText = $"SELECT * FROM {gradingTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId";
					sqlCommand7.Connection = sqlConnection;
					sqlCommand7.CommandType = CommandType.Text;
					using SqlCommand sqlCommand2 = sqlCommand7;
					sqlCommand2.Parameters.AddWithValue("@StudentNumber", studentNumber);
					sqlCommand2.Parameters.AddWithValue("@SemesterId", text + academicYear);
					sqlCommand2.Parameters.AddWithValue("@SubjectId", FirstWords(((object)val2).ToString(), 1));
					SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						sqlConnection.Close();
						continue;
					}
					sqlConnection.Close();
					using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection3.Open();
					SqlCommand sqlCommand8 = new SqlCommand();
					sqlCommand8.Connection = sqlConnection3;
					sqlCommand8.CommandText = gradingProcedure;
					sqlCommand8.CommandType = CommandType.Text;
					using SqlCommand sqlCommand6 = sqlCommand8;
					SqlParameter sqlParameter2 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
					sqlParameter2.Value = studentNumber;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
					sqlParameter2.Value = text + academicYear;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@Subjectid", SqlDbType.VarChar, 50);
					sqlParameter2.Value = FirstWords(((object)val2).ToString(), 1);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@Points", SqlDbType.VarChar, 3);
					sqlParameter2.Value = "";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@Grade", SqlDbType.VarChar, 2);
					sqlParameter2.Value = "";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
					sqlParameter2.Value = "";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@AverageMark", SqlDbType.VarChar, 5);
					sqlParameter2.Value = "";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@hop", SqlDbType.VarChar, 3);
					sqlParameter2.Value = "100";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@bot", SqlDbType.VarChar, 3);
					sqlParameter2.Value = "100";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@mot", SqlDbType.VarChar, 3);
					sqlParameter2.Value = "100";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@eot", SqlDbType.VarChar, 3);
					sqlParameter2.Value = "100";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand6.Parameters.Add("@TotalPoints", SqlDbType.VarChar, 2);
					sqlParameter2.Value = "";
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand6.ExecuteNonQuery();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void RegisterSingleALevel()
	{
		if (CurrentClass() == "S.5")
		{
			int num = CurrentAcademicYear + 1;
			RegisterALevelCustom("INSERT INTO tbl_Scores_5 (StudentNumber,SemesterId,SubjectId,PaperId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_5 (StudentNumber,SubjectId,PaperId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId) VALUES (@StudentNumber,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId)", "INSERT INTO tbl_GeneralReport_Grading_5  (StudentNumber,SemesterId,SubjectId,Points,Grade,Comment,AverageMark,hop,bot,mot,eot,TotalPoints) VALUES (@StudentNumber,@SemesterId,@SubjectId,@Points,@Grade,@Comment,@AverageMark,@hop,@bot,@mot,@eot,@TotalPoints)", "tbl_Scores_5", CurrentAcademicYear.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_5");
		}
		else if (CurrentClass() == "S.6")
		{
			RegisterALevelCustom("INSERT INTO tbl_Scores_6 (StudentNumber,SemesterId,SubjectId,PaperId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_6 (StudentNumber,SubjectId,PaperId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId) VALUES (@StudentNumber,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId)", "INSERT INTO tbl_GeneralReport_Grading_6  (StudentNumber,SemesterId,SubjectId,Points,Grade,Comment,AverageMark,hop,bot,mot,eot,TotalPoints) VALUES (@StudentNumber,@SemesterId,@SubjectId,@Points,@Grade,@Comment,@AverageMark,@hop,@bot,@mot,@eot,@TotalPoints)", "tbl_Scores_6", CurrentAcademicYear.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_6");
		}
	}

	public static void RegisterAllALevel()
	{
		if (CurrentClass() == "S.5")
		{
			int num = CurrentAcademicYear + 1;
			RegisterALevel("INSERT INTO tbl_Scores_5 (StudentNumber,SemesterId,SubjectId,PaperId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_5 (StudentNumber,SubjectId,PaperId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId) VALUES (@StudentNumber,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId)", "INSERT INTO tbl_GeneralReport_Grading_5  (StudentNumber,SemesterId,SubjectId,Points,Grade,Comment,AverageMark,hop,bot,mot,eot,TotalPoints) VALUES (@StudentNumber,@SemesterId,@SubjectId,@Points,@Grade,@Comment,@AverageMark,@hop,@bot,@mot,@eot,@TotalPoints)", "tbl_Scores_5", CurrentAcademicYear.ToString(), "tbl_Stud_5", "tbl_GeneralReport_Grading_5");
		}
		else if (CurrentClass() == "S.6")
		{
			RegisterALevel("INSERT INTO tbl_Scores_6 (StudentNumber,SemesterId,SubjectId,PaperId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_6 (StudentNumber,SubjectId,PaperId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId) VALUES (@StudentNumber,@SubjectId,@PaperId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId)", "INSERT INTO tbl_GeneralReport_Grading_6  (StudentNumber,SemesterId,SubjectId,Points,Grade,Comment,AverageMark,hop,bot,mot,eot,TotalPoints) VALUES (@StudentNumber,@SemesterId,@SubjectId,@Points,@Grade,@Comment,@AverageMark,@hop,@bot,@mot,@eot,@TotalPoints)", "tbl_Scores_6", CurrentAcademicYear.ToString(), "tbl_Stud_6", "tbl_GeneralReport_Grading_6");
		}
	}

	private static void RegisterOLevel(string scoresProcedure, string sProcGeneralReport, string gradingProcedure, string SubjectTable, string academicYear, string studentDataSource, string gradingTable)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		try
		{
			foreach (CheckedListBoxItem item in (IEnumerable)((BaseCheckedListBoxControl)chkSubjects).CheckedItems)
			{
				CheckedListBoxItem val = item;
				string value = ((object)val).ToString();
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				string selectCommandText = $"SELECT * FROM {studentDataSource}";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
				dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "students");
				DataTable dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					string[] array = "TermI- TermII- TermIII-".Split();
					foreach (string text in array)
					{
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						SqlCommand sqlCommand = new SqlCommand();
						sqlCommand.Connection = sqlConnection2;
						sqlCommand.CommandText = $"SELECT * FROM {SubjectTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId";
						sqlCommand.CommandType = CommandType.Text;
						using SqlCommand sqlCommand2 = sqlCommand;
						sqlCommand2.Parameters.AddWithValue("@StudentNumber", row["StudentNumber"].ToString());
						sqlCommand2.Parameters.AddWithValue("@SemesterId", text + academicYear);
						sqlCommand2.Parameters.AddWithValue("@subjectId", value);
						SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
						if (sqlDataReader.HasRows)
						{
							sqlConnection2.Close();
							continue;
						}
						sqlConnection2.Close();
						DateTime now = DateTime.Now;
						using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection3.Open();
						_transaction = sqlConnection3.BeginTransaction();
						SqlCommand sqlCommand3 = new SqlCommand();
						sqlCommand3.Connection = sqlConnection3;
						sqlCommand3.Transaction = _transaction;
						sqlCommand3.CommandText = scoresProcedure;
						sqlCommand3.CommandType = CommandType.Text;
						using (SqlCommand sqlCommand4 = sqlCommand3)
						{
							SqlParameter sqlParameter = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
							sqlParameter.Value = row["StudentNumber"].ToString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 10);
							sqlParameter.Value = text + academicYear;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter.Value = value;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@HoP", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@BOT", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@MOT", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@EOT", SqlDbType.VarChar, 4);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand4.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
							sqlParameter.Value = "";
							sqlParameter.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						SqlCommand sqlCommand5 = new SqlCommand();
						sqlCommand5.Connection = sqlConnection3;
						sqlCommand5.Transaction = _transaction;
						sqlCommand5.CommandText = sProcGeneralReport;
						sqlCommand5.CommandType = CommandType.Text;
						using (SqlCommand sqlCommand6 = sqlCommand5)
						{
							SqlParameter sqlParameter2 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
							sqlParameter2.Value = row["StudentNumber"].ToString();
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@HoP", SqlDbType.VarChar, 6);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@BOT", SqlDbType.VarChar, 6);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@MOT", SqlDbType.VarChar, 6);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@EOT", SqlDbType.VarChar, 6);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@AvMark", SqlDbType.VarChar, 6);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Category", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Grade", SqlDbType.VarChar, 2);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
							sqlParameter2.Value = "";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = text + academicYear;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand6.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
							sqlParameter2.Value = value;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand6.ExecuteNonQuery();
						}
						_transaction.Commit();
						sqlConnection3.Close();
					}
				}
			}
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			string selectCommandText = $"SELECT * FROM {studentDataSource}";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
			dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "students");
			DataTable dataTable = dataSet.Tables[0];
			foreach (DataRow row2 in dataTable.Rows)
			{
				string[] array = "TermI- TermII- TermIII-".Split();
				foreach (string text in array)
				{
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					SqlCommand sqlCommand7 = new SqlCommand();
					sqlCommand7.Connection = sqlConnection2;
					sqlCommand7.CommandText = $"SELECT * FROM {gradingTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId";
					sqlCommand7.CommandType = CommandType.Text;
					using SqlCommand sqlCommand2 = sqlCommand7;
					sqlCommand2.Parameters.AddWithValue("@StudentNumber", row2["StudentNumber"].ToString());
					sqlCommand2.Parameters.AddWithValue("@SemesterId", text + academicYear);
					SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						sqlConnection2.Close();
						continue;
					}
					sqlConnection2.Close();
					using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection4.Open();
					SqlCommand sqlCommand8 = new SqlCommand();
					sqlCommand8.Connection = sqlConnection4;
					sqlCommand8.CommandText = gradingProcedure;
					sqlCommand8.CommandType = CommandType.Text;
					using SqlCommand sqlCommand9 = sqlCommand8;
					SqlParameter sqlParameter3 = sqlCommand9.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
					sqlParameter3.Value = CurrentStudent();
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@TotalMark", SqlDbType.VarChar, 4);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@Div", SqlDbType.VarChar, 3);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@Agg", SqlDbType.VarChar, 3);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@BestInEight", SqlDbType.VarChar, 2);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@OutOf", SqlDbType.VarChar, 4);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@StudentsInStream", SqlDbType.VarChar, 3);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@PositionInStream", SqlDbType.VarChar, 3);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@Position", SqlDbType.VarChar, 3);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
					sqlParameter3.Value = text + academicYear;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@AvMark", SqlDbType.VarChar, 4);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@HoP", SqlDbType.Float);
					sqlParameter3.Value = 100;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@BOT", SqlDbType.Float);
					sqlParameter3.Value = 100;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@MOT", SqlDbType.Float);
					sqlParameter3.Value = 100;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@EOT", SqlDbType.Float);
					sqlParameter3.Value = 100;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand9.Parameters.Add("@promoStatus", SqlDbType.VarChar, 50);
					sqlParameter3.Value = "";
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlCommand9.ExecuteNonQuery();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Intelligent Records");
		}
	}

	private static void RegisterOLevelCustom(string scoresProcedure, string sProcGeneralReport, string gradingProcedure, string SubjectTable, string academicYear, string studentNumber, string gradingTable)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		try
		{
			string[] array;
			foreach (CheckedListBoxItem item in (IEnumerable)((BaseCheckedListBoxControl)chkSubjects).CheckedItems)
			{
				CheckedListBoxItem val = item;
				string value = ((object)val).ToString();
				array = "TermI- TermII- TermIII-".Split();
				foreach (string text in array)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand();
					sqlCommand.CommandText = $"SELECT * FROM {SubjectTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId AND SubjectId=@SubjectId";
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandType = CommandType.Text;
					using SqlCommand sqlCommand2 = sqlCommand;
					sqlCommand2.Parameters.AddWithValue("@StudentNumber", studentNumber);
					sqlCommand2.Parameters.AddWithValue("@SemesterId", text + academicYear);
					sqlCommand2.Parameters.AddWithValue("@subjectId", value);
					SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						sqlConnection.Close();
						continue;
					}
					string[] array2 = "TermI- TermII- TermIII-".Split();
					int num = 0;
					if (num >= array2.Length)
					{
						continue;
					}
					string text2 = array2[num];
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					_transaction = sqlConnection2.BeginTransaction();
					SqlCommand sqlCommand3 = new SqlCommand();
					sqlCommand3.Connection = sqlConnection2;
					sqlCommand3.Transaction = _transaction;
					sqlCommand3.CommandText = scoresProcedure;
					sqlCommand3.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand4 = sqlCommand3)
					{
						SqlParameter sqlParameter = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
						sqlParameter.Value = studentNumber;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@SemesterId", SqlDbType.VarChar, 10);
						sqlParameter.Value = text + academicYear;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter.Value = value;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@HoP", SqlDbType.VarChar, 4);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@BOT", SqlDbType.VarChar, 4);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@MOT", SqlDbType.VarChar, 4);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@EOT", SqlDbType.VarChar, 4);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand4.Parameters.Add("@Initial", SqlDbType.VarChar, 5);
						sqlParameter.Value = "";
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand4.ExecuteNonQuery();
					}
					SqlCommand sqlCommand5 = new SqlCommand();
					sqlCommand5.Connection = sqlConnection2;
					sqlCommand5.Transaction = _transaction;
					sqlCommand5.CommandText = sProcGeneralReport;
					sqlCommand5.CommandType = CommandType.Text;
					using (SqlCommand sqlCommand6 = sqlCommand5)
					{
						SqlParameter sqlParameter2 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
						sqlParameter2.Value = studentNumber;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@HoP", SqlDbType.VarChar, 6);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@BOT", SqlDbType.VarChar, 6);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@MOT", SqlDbType.VarChar, 6);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@EOT", SqlDbType.VarChar, 6);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@AvMark", SqlDbType.VarChar, 6);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Category", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Grade", SqlDbType.VarChar, 2);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
						sqlParameter2.Value = "";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = text + academicYear;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand6.Parameters.Add("@SubjectId", SqlDbType.VarChar, 50);
						sqlParameter2.Value = value;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand6.ExecuteNonQuery();
					}
					_transaction.Commit();
					sqlConnection2.Close();
				}
			}
			array = "TermI- TermII- TermIII-".Split();
			foreach (string text3 in array)
			{
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				SqlCommand sqlCommand7 = new SqlCommand();
				sqlCommand7.CommandText = $"SELECT * FROM {gradingTable} WHERE StudentNumber=@StudentNumber AND SemesterId=@SemesterId";
				sqlCommand7.Connection = sqlConnection;
				sqlCommand7.CommandType = CommandType.Text;
				using SqlCommand sqlCommand2 = sqlCommand7;
				sqlCommand2.Parameters.AddWithValue("@StudentNumber", studentNumber);
				sqlCommand2.Parameters.AddWithValue("@SemesterId", text3 + academicYear);
				SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					sqlConnection.Close();
					continue;
				}
				sqlConnection.Close();
				using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection3.Open();
				SqlCommand sqlCommand8 = new SqlCommand();
				sqlCommand8.Connection = sqlConnection3;
				sqlCommand8.CommandText = gradingProcedure;
				sqlCommand8.CommandType = CommandType.Text;
				using SqlCommand sqlCommand9 = sqlCommand8;
				SqlParameter sqlParameter3 = sqlCommand9.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 50);
				sqlParameter3.Value = studentNumber;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@TotalMark", SqlDbType.VarChar, 4);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@Div", SqlDbType.VarChar, 3);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@Agg", SqlDbType.VarChar, 3);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@BestInEight", SqlDbType.VarChar, 2);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@OutOf", SqlDbType.VarChar, 4);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@StudentsInStream", SqlDbType.VarChar, 3);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@PositionInStream", SqlDbType.VarChar, 3);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@Position", SqlDbType.VarChar, 3);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
				sqlParameter3.Value = text3 + academicYear;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@AvMark", SqlDbType.VarChar, 4);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@ClassTeacherComment", SqlDbType.VarChar, 80);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@HeadTeacherComment", SqlDbType.VarChar, 80);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@DOSComment", SqlDbType.VarChar, 80);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@HoP", SqlDbType.Float);
				sqlParameter3.Value = 100;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@BOT", SqlDbType.Float);
				sqlParameter3.Value = 100;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@MOT", SqlDbType.Float);
				sqlParameter3.Value = 100;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@EOT", SqlDbType.Float);
				sqlParameter3.Value = 100;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand9.Parameters.Add("@promoStatus", SqlDbType.VarChar, 50);
				sqlParameter3.Value = "";
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlCommand9.ExecuteNonQuery();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Intelligent Records");
		}
	}

	public static void RegisterSingleOLevel()
	{
		if (CurrentClass() == "S.1")
		{
			int num = Convert.ToInt32(CurrentAcademicYear) + 1;
			RegisterOLevelCustom("INSERT INTO tbl_Scores_1 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_1 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_1 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_1", CurrentAcademicYear.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_1");
			RegisterOLevelCustom("INSERT INTO tbl_Scores_2 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_2 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_2 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_2", num.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_2");
		}
		else if (CurrentClass() == "S.2")
		{
			RegisterOLevelCustom("INSERT INTO tbl_Scores_2 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_2 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_2 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_2", CurrentAcademicYear.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_2");
		}
		else if (CurrentClass() == "S.3")
		{
			int num = Convert.ToInt32(CurrentAcademicYear) + 1;
			RegisterOLevelCustom("INSERT INTO tbl_Scores_3 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_3 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_3 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_3", CurrentAcademicYear.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_3");
			RegisterOLevelCustom("INSERT INTO tbl_Scores_4 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_4 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_4 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_4", num.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_4");
		}
		else if (CurrentClass() == "S.4")
		{
			RegisterOLevelCustom("INSERT INTO tbl_Scores_4 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_4 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_4 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_4", CurrentAcademicYear.ToString(), CurrentStudent(), "tbl_GeneralReport_Grading_4");
		}
	}

	public static void RegisterAllOLevel()
	{
		if (CurrentClass() == "S.1")
		{
			int num = CurrentAcademicYear + 1;
			RegisterOLevel("INSERT INTO tbl_Scores_1 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_1 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_1 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_1", CurrentAcademicYear.ToString(), "tbl_Stud_1", "tbl_GeneralReport_Grading_1");
			RegisterOLevel("INSERT INTO tbl_Scores_2 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_2 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_2 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_2", num.ToString(), "tbl_Stud_1", "tbl_GeneralReport_Grading_2");
		}
		else if (CurrentClass() == "S.2")
		{
			RegisterOLevel("INSERT INTO tbl_Scores_2 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_2 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_2 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_2", CurrentAcademicYear.ToString(), "tbl_Stud_2", "tbl_GeneralReport_Grading_2");
		}
		else if (CurrentClass() == "S.3")
		{
			int num = CurrentAcademicYear + 1;
			RegisterOLevel("INSERT INTO tbl_Scores_3 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_3 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_3 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_3", CurrentAcademicYear.ToString(), "tbl_Stud_3", "tbl_GeneralReport_Grading_3");
			RegisterOLevel("INSERT INTO tbl_Scores_4 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_4 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_4 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_4", num.ToString(), "tbl_Stud_3", "tbl_GeneralReport_Grading_4");
		}
		else if (CurrentClass() == "S.4")
		{
			RegisterOLevel("INSERT INTO tbl_Scores_4 (StudentNumber,SemesterId,SubjectId,HoP,BOT,MOT,EOT,Initial) VALUES (@StudentNumber,@SemesterId,@SubjectId,@HoP,@BOT,@MOT,@EOT,@Initial)", "INSERT INTO tbl_GeneralReport_4 (StudentNumber,SubjectId,HoP,BOT,MOT,EOT,AvMark,Grade,Category,Initial,SemesterId,Comment) VALUES (@StudentNumber,@SubjectId,@HoP,@BOT,@MOT,@EOT,@AvMark,@Grade,@Category,@Initial,@SemesterId,@Comment)", "INSERT INTO tbl_GeneralReport_Grading_4 (StudentNumber,SemesterId,Position,OutOf,PositionInStream,StudentsInStream,BestinEight,Agg,Div,ClassTeacherComment,HeadTeacherComment,DOSComment,TotalMark ,AvMark,HoP,BOT,MOT,EOT,promoStatus) VALUES (@StudentNumber,@SemesterId,@Position,@OutOf,@PositionInStream,@StudentsInStream,@BestinEight,@Agg,@Div,@ClassTeacherComment,@HeadTeacherComment,@DOSComment,@TotalMark ,@AvMark,@@HoP,@BOT,@MOT,@EOT,@promoStatus)", "tbl_Scores_4", CurrentAcademicYear.ToString(), "tbl_Stud_4", "tbl_GeneralReport_Grading_4");
		}
	}

	public static void SetRegistrationParameters(CheckedListBoxControl chkAllSubjects, string studentClass, string studentNumber, int academicYear, int regMode, int levelToRegister)
	{
		StudentRegistration graph = new StudentRegistration();
		AcademicYear = academicYear;
		RegistrationMode = regMode;
		SelectedClass = studentClass;
		StudentNumber = studentNumber;
		LevelToRegister = levelToRegister;
		chkSubjects = chkAllSubjects;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
