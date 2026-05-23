using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid.Views.Grid;

namespace I_Xtreme;

[Serializable]
internal class StudentRegistrationAdvanced
{
	private static GridView dataGrid { get; set; }

	private static DataTable dataTable { get; set; }

	public static GridView Grid_View
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_DataGrid.tmp");
			StudentRegistrationAdvanced studentRegistrationAdvanced = new StudentRegistrationAdvanced();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			studentRegistrationAdvanced = (StudentRegistrationAdvanced)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return dataGrid;
		}
	}

	public static void SerializeDataGrid(GridView _gridView)
	{
		StudentRegistrationAdvanced graph = new StudentRegistrationAdvanced();
		dataGrid = _gridView;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_DataGrid.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SaveDataTable(DataTable _dataTable)
	{
		StudentRegistrationAdvanced graph = new StudentRegistrationAdvanced();
		dataTable = _dataTable;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_DataTable.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
