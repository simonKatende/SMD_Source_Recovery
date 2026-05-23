using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraEditors;

namespace LibraryManagement;

[Serializable]
public class Semesters
{
	public string SemesterList { get; set; }

	public static void InitializeSemesters()
	{
		Semesters graph = new Semesters
		{
			SemesterList = "Select-Semester TermI-2012 TermII-2012 TermIII-2012 TermI-2013 TermII-2013 TermIII-2013 TermI-2014 TermII-2014 TermIII-2014 TermI-2015 TermII-2015 TermIII-2015 TermI-2016 TermII-2016 TermIII-2016 TermI-2017 TermII-2017 TermIII-2017 TermI-2018 TermII-2018 TermIII-2018 TermI-2019 TermII-2019 TermIII-2019 TermI-2020 TermII-2020 TermIII-2020"
		};
		using FileStream fileStream = new FileStream("bin", FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void GetSemesters(ComboBoxEdit cboSemester)
	{
		try
		{
			Semesters semesters = new Semesters();
			using FileStream fileStream = new FileStream("bin", FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			semesters = (Semesters)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			string[] array = semesters.SemesterList.Split();
			foreach (string text in array)
			{
				cboSemester.Properties.Items.AddRange(new object[1] { text });
			}
			cboSemester.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Intelligent Records");
		}
	}
}
