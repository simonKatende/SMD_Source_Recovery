using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

[Serializable]
internal class StudentRequirements
{
	private int appendTo { get; set; }

	private int appendCategory { get; set; }

	private double requiredAMount { get; set; }

	private string _AccountNo { get; set; }

	private string _StudentNumbers { get; set; }

	private string _StudentClasses { get; set; }

	private string _Semesters { get; set; }

	private DateTime _AppendDate { get; set; }

	private string _RequiredItems { get; set; }

	public static GridView gridView { get; set; }

	public static int AppendValue
	{
		get
		{
			StudentRequirements studentRequirements = new StudentRequirements();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return studentRequirements.appendTo;
		}
	}

	public static string AccountNumber
	{
		get
		{
			StudentRequirements studentRequirements = new StudentRequirements();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return studentRequirements._AccountNo;
		}
	}

	public static int CategoryValue
	{
		get
		{
			StudentRequirements studentRequirements = new StudentRequirements();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return studentRequirements.appendCategory;
		}
	}

	public static double RequiredAmount
	{
		get
		{
			StudentRequirements studentRequirements = new StudentRequirements();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return studentRequirements.requiredAMount;
		}
	}

	public static DateTime AppendDate
	{
		get
		{
			StudentRequirements studentRequirements = new StudentRequirements();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return studentRequirements._AppendDate;
		}
	}

	public static string Semester()
	{
		StudentRequirements studentRequirements = new StudentRequirements();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return studentRequirements._Semesters;
	}

	public static string StudentClass()
	{
		StudentRequirements studentRequirements = new StudentRequirements();
		string tempPath = Path.GetTempPath();
		using (FileStream fileStream = new FileStream(Path.Combine(tempPath, "SMD_AppendRequirements.tmp"), FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return studentRequirements._StudentClasses;
	}

	public static string StudentNumber()
	{
		StudentRequirements studentRequirements = new StudentRequirements();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return studentRequirements._StudentNumbers;
	}

	public static string RequiredItem()
	{
		StudentRequirements studentRequirements = new StudentRequirements();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_AppendRequirements.tmp");
		using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRequirements = (StudentRequirements)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
		}
		return studentRequirements._RequiredItems;
	}

	public static void AppendToCustomInit(GridView View, int appedingTo, int appendingCategory, double feesAmount, string itemRequired, string currentSemester, string currentClass, DateTime appendDate, string acc_No)
	{
		StudentRequirements studentRequirements = new StudentRequirements();
		studentRequirements.appendTo = appedingTo;
		studentRequirements.appendCategory = appendingCategory;
		studentRequirements.requiredAMount = feesAmount;
		studentRequirements._RequiredItems = itemRequired;
		studentRequirements._Semesters = currentSemester;
		studentRequirements._StudentClasses = currentClass;
		studentRequirements._AppendDate = appendDate;
		gridView = View;
		studentRequirements._AccountNo = acc_No;
		string tempPath = Path.GetTempPath();
		using FileStream fileStream = new FileStream(Path.Combine(tempPath, "SMD_AppendRequirements.tmp"), FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, studentRequirements);
		fileStream.Close();
	}
}
