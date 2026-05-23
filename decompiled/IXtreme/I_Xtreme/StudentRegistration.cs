using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

[Serializable]
internal class StudentRegistration
{
	private static int LevelToRegister { get; set; }

	public static GridView gridView { get; set; }

	private static int AcademicYear { get; set; }

	private static string SelectedClass { get; set; }

	private static string StudentNumber { get; set; }

	private static int RegistrationMode { get; set; }

	public static int CurrentAcademicYear
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

	public static string CurrentClass()
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

	public static string CurrentStudent()
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

	public static void SetRegistrationParameters(GridView gridView1, string studentClass, string studentNumber, int academicYear, int regMode, int levelToRegister)
	{
		StudentRegistration graph = new StudentRegistration();
		AcademicYear = academicYear;
		RegistrationMode = regMode;
		SelectedClass = studentClass;
		StudentNumber = studentNumber;
		LevelToRegister = levelToRegister;
		gridView = gridView1;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_S_Registration.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
