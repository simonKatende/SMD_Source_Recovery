using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace MarksEntry;

[Serializable]
internal class TeacherLogin
{
	private static string CurrentClass { get; set; }

	private static string Subject { get; set; }

	private static string Semester { get; set; }

	private static string Initials { get; set; }

	private static string ID { get; set; }

	private static string _loggingInUser { get; set; }

	public static string CurrentSemester()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		TeacherLogin teacherLogin = new TeacherLogin();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			teacherLogin = (TeacherLogin)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return Semester;
	}

	public static string TeacherID()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		TeacherLogin teacherLogin = new TeacherLogin();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			teacherLogin = (TeacherLogin)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return ID;
	}

	public static string StudentClass()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		TeacherLogin teacherLogin = new TeacherLogin();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			teacherLogin = (TeacherLogin)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return CurrentClass;
	}

	public static string CurrentSubject()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		TeacherLogin teacherLogin = new TeacherLogin();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			teacherLogin = (TeacherLogin)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return Subject;
	}

	public static string TeacherInitials()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		TeacherLogin teacherLogin = new TeacherLogin();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			teacherLogin = (TeacherLogin)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return Initials;
	}

	public static string LogginInUser()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		TeacherLogin teacherLogin = new TeacherLogin();
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			teacherLogin = (TeacherLogin)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return _loggingInUser;
	}

	public static void InitializeLogin(string currentClass, string semester, string subject, string teacherInitials, string teacherID, string loggingUser)
	{
		TeacherLogin graph = new TeacherLogin();
		CurrentClass = currentClass;
		Semester = semester;
		Subject = subject;
		Initials = teacherInitials;
		ID = teacherID;
		_loggingInUser = loggingUser;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_TeacherLogin.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void LoadStreams(string studentClass, RepositoryItemComboBox _cboStream)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * from Streams WHERE ClassId='{studentClass}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Streams");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				_cboStream.Items.Clear();
				_cboStream.Items.Add("-");
				return;
			}
			_cboStream.Items.Clear();
			_cboStream.Items.Add("Entire Class");
			foreach (DataRow row in dataTable.Rows)
			{
				_cboStream.Items.Add(row["StreamId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}

	public static void LoadStreams(string studentClass, ComboBoxEdit _cboStream)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			string selectCommandText = $"SELECT * from Streams WHERE ClassId='{studentClass}'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Streams");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				_cboStream.Properties.Items.Clear();
				ComboBoxItemCollection items = _cboStream.Properties.Items;
				object[] items2 = new string[2] { "Entire Class", "-" };
				items.AddRange(items2);
				return;
			}
			_cboStream.Properties.Items.Clear();
			_cboStream.Properties.Items.Add("Entire Class");
			foreach (DataRow row in dataTable.Rows)
			{
				_cboStream.Properties.Items.Add(row["StreamId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error");
		}
	}
}
