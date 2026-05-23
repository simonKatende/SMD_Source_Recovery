using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.CommonSettings;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme;

[Serializable]
internal class StudentOptions
{
	private static SqlTransaction trans;

	private static Guid guid;

	private static string activeStudentTable { get; set; }

	private static string activeGuardianTable { get; set; }

	private static string listTypes { get; set; }

	private static string activeStudent { get; set; }

	private static string activeClass { get; set; }

	private static string activeStream { get; set; }

	private static double rowHandle { get; set; }

	private static string loadingMethod { get; set; }

	private static string paymentMode { get; set; }

	private static string activeSemester { get; set; }

	private static string activeYear { get; set; }

	public static string ActiveYear
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
			StudentOptions studentOptions = new StudentOptions();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return activeYear;
		}
	}

	public static Guid ActiveGuid
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
			StudentOptions studentOptions = new StudentOptions();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return guid;
		}
	}

	public static int ActiveRowHandle
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
			if (File.Exists(path))
			{
				StudentOptions studentOptions = new StudentOptions();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return (int)rowHandle;
			}
			return 0;
		}
	}

	public static void DeleteStudentUnConditionally(string studentNumber, Guid _guid, string StudClass, string name)
	{
		DialogResult dialogResult = XtraMessageBox.Show("Do you really want to delete this student?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			trans = sqlConnection.BeginTransaction();
			using (SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_suspendedStudents WHERE StudentNumber=@StudentNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter.Value = studentNumber;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_suspendedGuardians WHERE studentOid=@studentOid",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@studentOid", SqlDbType.UniqueIdentifier);
				sqlParameter2.Value = _guid;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = $"DELETE FROM tbl_LastId WHERE lastId='{studentNumber}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand3.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection,
				Transaction = trans,
				CommandText = $"DELETE FROM FeesPayment WHERE StudentNumber='{studentNumber}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection.Close();
			AuditTrail.CaptureActions("Delete", $"Deleted student {name}", AuditTrail.Departments.Admission, studentNumber, StudClass, 0m, 0m);
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void DeleteStudentConditionally(string studentNumber, Guid _guid, string StudClass)
	{
		try
		{
			string arg = SchoolSettings.ScoresTableSource(StudClass);
			string arg2 = SchoolSettings.GeneralReportTableSource(StudClass);
			string arg3 = SchoolSettings.GeneralReportGradingTableSource(StudClass);
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM FeesPayment WHERE StudentNumber= '{studentNumber}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				XtraMessageBox.Show("Student: " + studentNumber + " cannot be deleted because he/she has Fees Transactions", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			sqlDataReader.Close();
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = $"SELECT * FROM {arg} WHERE StudentNumber=@StudentNumber",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = studentNumber;
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			if (!sqlDataReader2.HasRows)
			{
				return;
			}
			sqlDataReader2.Close();
			sqlConnection2.Close();
			DialogResult dialogResult = XtraMessageBox.Show(studentNumber + " has registered for subjects. Deleting this student will discard all previous academic records.\nDo you really want to do this?", "School Management Dynamics", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection3.Open();
					trans = sqlConnection3.BeginTransaction();
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = "DELETE FROM tbl_Stud WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter2.Value = studentNumber;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = "DELETE FROM tbl_Guardian WHERE studentOid=@studentOid",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter3 = sqlCommand4.Parameters.Add("@studentOid", SqlDbType.UniqueIdentifier);
						sqlParameter3.Value = _guid;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlCommand4.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = $"DELETE FROM {arg} WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter4 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter4.Value = studentNumber;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlCommand5.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand6 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = $"DELETE FROM {arg2} WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter5 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter5.Value = studentNumber;
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlCommand6.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand7 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = $"DELETE FROM {arg3} WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter6 = sqlCommand7.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter6.Value = studentNumber;
						sqlParameter6.Direction = ParameterDirection.Input;
						sqlCommand7.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand8 = new SqlCommand
					{
						Connection = sqlConnection3,
						Transaction = trans,
						CommandText = "DELETE FROM tbl_LastId WHERE lastId=@lastId",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter7 = sqlCommand8.Parameters.Add("@lastId", SqlDbType.VarChar, 12);
						sqlParameter7.Value = studentNumber;
						sqlParameter7.Direction = ParameterDirection.Input;
						sqlCommand8.ExecuteNonQuery();
					}
					trans.Commit();
					sqlConnection3.Close();
					return;
				}
			}
			sqlDataReader2.Close();
			sqlConnection2.Close();
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			trans = sqlConnection4.BeginTransaction();
			using (SqlCommand sqlCommand9 = new SqlCommand
			{
				Connection = sqlConnection4,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_Stud WHERE StudentNumber=@StudentNumber",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter8 = sqlCommand9.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
				sqlParameter8.Value = studentNumber;
				sqlParameter8.Direction = ParameterDirection.Input;
				sqlCommand9.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand10 = new SqlCommand
			{
				Connection = sqlConnection4,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_Guardian WHERE studentOid=@studentOid",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter9 = sqlCommand10.Parameters.Add("@studentOid", SqlDbType.UniqueIdentifier);
				sqlParameter9.Value = _guid;
				sqlParameter9.Direction = ParameterDirection.Input;
				sqlCommand10.ExecuteNonQuery();
			}
			using (SqlCommand sqlCommand11 = new SqlCommand
			{
				Connection = sqlConnection4,
				Transaction = trans,
				CommandText = "DELETE FROM tbl_LastId WHERE lastId=@lastId",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter10 = sqlCommand11.Parameters.Add("@lastId", SqlDbType.VarChar, 12);
				sqlParameter10.Value = studentNumber;
				sqlParameter10.Direction = ParameterDirection.Input;
				sqlCommand11.ExecuteNonQuery();
			}
			trans.Commit();
			sqlConnection4.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void SetActiveYear(string _year)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		activeYear = _year;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetActiveGuid(Guid _guid)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		guid = _guid;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string ActiveStudent()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeStudent;
	}

	public static string ActiveClass()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeClass;
	}

	public static void SetActiveStudent(string _student)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		activeStudent = _student;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetActiveClass(string _class)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		activeClass = _class;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetActiveStream(string _stream)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		activeStream = _stream;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string ActiveStream()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeStream;
	}

	private static string ListType()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return listTypes;
	}

	public static void SetListTYpes(string listType)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		listTypes = listType;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetRowHandle(double row_Handle)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		rowHandle = row_Handle;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void ChangeLoadingMode(string loadMode)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		loadingMethod = loadMode;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string LoadingMode()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return loadingMethod;
	}

	public static void SetPaymentMode(string _paymentMode)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		paymentMode = _paymentMode;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string PaymentMode()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return paymentMode;
	}

	public static string ActiveSemester()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeSemester;
	}

	public static void SetActiveSemester(string _semester)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions graph = new StudentOptions();
		activeSemester = _semester;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetActiveGuardianAndStudent(string _activeStudentTable, string _activeGuardianTable)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StaffOptions.tmp");
		StaffOptions graph = new StaffOptions();
		activeStudentTable = _activeStudentTable;
		activeGuardianTable = _activeGuardianTable;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string ActiveStudentTable()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeStudentTable;
	}

	public static string ActiveGuardianTable()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_StudentOptions.tmp");
		StudentOptions studentOptions = new StudentOptions();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		studentOptions = (StudentOptions)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return activeGuardianTable;
	}

	public static string StudentsInClass(string Class)
	{
		string result = string.Empty;
		string text = Class.Substring(2, 1);
		string arg = "tbl_Stud_" + text;
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT Count(auto) AS ClassCount FROM {arg}", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ClassCount");
			IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = dataRow["ClassCount"].ToString();
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
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}
}
