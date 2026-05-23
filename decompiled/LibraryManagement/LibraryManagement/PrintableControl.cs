using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;

namespace LibraryManagement;

[Serializable]
internal class PrintableControl
{
	private static GridControl xtraGrid { get; set; }

	private static GridView gridView { get; set; }

	private static ChartControl xtraChart { get; set; }

	private static PivotGridControl xtraPivotGrid { get; set; }

	private static PivotGridControl xtraPivotGrid_2 { get; set; }

	public static GridView GridViewControl
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return gridView;
		}
	}

	public static ChartControl PrintableChartControl
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return xtraChart;
		}
	}

	public static PivotGridControl PrintablePivotGridControl
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return xtraPivotGrid;
		}
	}

	public static PivotGridControl PrintablePivotGridControl_2
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return xtraPivotGrid_2;
		}
	}

	public static GridControl PrintableGridControl
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return xtraGrid;
		}
	}

	public static void SavePrintableControl(GridView _gridView)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		gridView = _gridView;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(PivotGridControl pivotGrid1, PivotGridControl pivotGrid2, ChartControl chartControl)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraChart = chartControl;
		xtraPivotGrid = pivotGrid1;
		xtraPivotGrid_2 = pivotGrid2;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(PivotGridControl pivotGrid1, GridControl gridControl, ChartControl chartControl)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraChart = chartControl;
		xtraPivotGrid = pivotGrid1;
		xtraGrid = gridControl;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(PivotGridControl pivotGrid1, PivotGridControl pivotGrid2)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraPivotGrid = pivotGrid1;
		xtraPivotGrid_2 = pivotGrid2;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(PivotGridControl pivotGrid1, ChartControl chartControl)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraChart = chartControl;
		xtraPivotGrid = pivotGrid1;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(PivotGridControl _pivotGridControl)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraPivotGrid = _pivotGridControl;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(GridControl _gridControl)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "I_Xtreme_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraGrid = _gridControl;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
