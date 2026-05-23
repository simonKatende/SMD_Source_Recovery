using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme;

[Serializable]
internal class PreviousSelections
{
	private static ComboBoxEdit cboClass { get; set; }

	private static ComboBoxEdit cboStream { get; set; }

	private static ComboBoxEdit cboYear { get; set; }

	private static CheckedComboBoxEdit cboSelectedSubjects { get; set; }

	private static CheckEdit chkIncludeStream { get; set; }

	private static CheckEdit chkAll { get; set; }

	private static DataGridView dataGridView { get; set; }

	public static ComboBoxEdit cbClass
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return cboClass;
		}
	}

	public static ComboBoxEdit cbStream
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return cboStream;
		}
	}

	public static ComboBoxEdit cbYear
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return cboYear;
		}
	}

	public static CheckedComboBoxEdit cbSubjects
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return cboSelectedSubjects;
		}
	}

	public static CheckEdit chIncludeStream
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return chkIncludeStream;
		}
	}

	public static CheckEdit chAll
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return chkAll;
		}
	}

	public static DataGridView GridViews
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataGridView;
		}
	}

	public static int ItemCount
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
			PreviousSelections previousSelections = new PreviousSelections();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			previousSelections = (PreviousSelections)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return cbClass.Properties.Items.Count;
		}
	}

	public static void SaveControls(ComboBoxEdit cbClass, ComboBoxEdit cboStrm, ComboBoxEdit cboYr, CheckedComboBoxEdit cboSubjects, CheckEdit chkStream, CheckEdit chkAllStudents, DataGridView _dataGridView)
	{
		PreviousSelections graph = new PreviousSelections();
		cboClass = cbClass;
		cboStream = cboStrm;
		cboYear = cboYr;
		cboSelectedSubjects = cboSubjects;
		chkIncludeStream = chkStream;
		chkAll = chkAllStudents;
		dataGridView = _dataGridView;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_PreviousControls.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
