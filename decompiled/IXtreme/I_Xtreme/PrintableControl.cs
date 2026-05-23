using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.ReportHeaders;
using AlienAge.Security;
using DevExpress.LookAndFeel;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;

namespace I_Xtreme;

[Serializable]
internal class PrintableControl
{
	private static GridControl xtraGrid { get; set; }

	private static GridControl xtraGrid2 { get; set; }

	private static GridView gridView { get; set; }

	private static ChartControl xtraChart { get; set; }

	private static PivotGridControl xtraPivotGrid { get; set; }

	private static PivotGridControl xtraPivotGrid_2 { get; set; }

	public static GridView GridViewControl
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
			string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
			string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
			string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
			string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return xtraGrid;
		}
	}

	public static GridControl PrintableGridControl_2
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
			PrintableControl printableControl = new PrintableControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			printableControl = (PrintableControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return xtraGrid2;
		}
	}

	public static void SavePrintableControl(GridControl Grid1, GridControl Grid2)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraGrid = Grid1;
		xtraGrid2 = Grid2;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SavePrintableControl(GridView _gridView)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
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
		string path = Path.Combine(tempPath, "SMD_PivotGrid.bin");
		PrintableControl graph = new PrintableControl();
		xtraGrid = _gridControl;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void PrintControl(string ReportHeader, string SubHeader, PrintableComponentLink link, bool IsLandScape, GridControl PrintableGrid)
	{
		try
		{
			if (!LicenceStatus.IsTrialExpired)
			{
				link.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs24 {AlienAge.ReportHeaders.ReportHeader.SchoolName}\\par\r\n{AlienAge.ReportHeaders.ReportHeader.SchoolFullAddress}\\par\r\n{string.Empty}\\par\r\n{ReportHeader}\\par\r\n{SubHeader}\\par\r\n}}\r\n";
				link.Component = PrintableGrid;
				link.Landscape = IsLandScape;
				link.PrintingSystem.ClearContent();
				link.PrintDlg();
			}
			else if (LicenceStatus.IsTrialExpired)
			{
				XtraMessageBox.Show("Sorry! You cannot print because your license expired.\nPlease renew your license in order to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void PreviewControl(string ReportHeader, string SubHeader, PrintableComponentLink link, bool IsLandScape, GridControl PrintableGrid)
	{
		try
		{
			if (!LicenceStatus.IsTrialExpired)
			{
				link.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs24 {AlienAge.ReportHeaders.ReportHeader.SchoolName}\\par\r\n{AlienAge.ReportHeaders.ReportHeader.SchoolFullAddress}\\par\r\n{string.Empty}\\par\r\n{ReportHeader}\\par\r\n{SubHeader}\\par\r\n}}\r\n";
				link.Component = PrintableGrid;
				link.Landscape = IsLandScape;
				link.PrintingSystem.ClearContent();
				link.ShowRibbonPreview(UserLookAndFeel.Default.ActiveLookAndFeel);
			}
			else if (LicenceStatus.IsTrialExpired)
			{
				XtraMessageBox.Show("Sorry! You cannot print because your license expired.\nPlease renew your license in order to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void PrintControl(string ReportHeader, string SubHeader, PrintableComponentLink link, bool IsLandScape, PivotGridControl PivotGrid)
	{
		try
		{
			if (!LicenceStatus.IsTrialExpired)
			{
				link.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs24 {AlienAge.ReportHeaders.ReportHeader.SchoolName}\\par\r\n{AlienAge.ReportHeaders.ReportHeader.SchoolFullAddress}\\par\r\n{string.Empty}\\par\r\n{ReportHeader}\\par\r\n{SubHeader}\\par\r\n}}\r\n";
				link.Component = PivotGrid;
				link.Landscape = IsLandScape;
				link.PrintingSystem.ClearContent();
				link.PrintDlg();
			}
			else if (LicenceStatus.IsTrialExpired)
			{
				XtraMessageBox.Show("Sorry! You cannot print because your license expired.\nPlease renew your license in order to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void PreviewControl(string ReportHeader, string SubHeader, PrintableComponentLink link, bool IsLandScape, PivotGridControl PivotGrid)
	{
		try
		{
			if (!LicenceStatus.IsTrialExpired)
			{
				link.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs24 {AlienAge.ReportHeaders.ReportHeader.SchoolName}\\par\r\n{AlienAge.ReportHeaders.ReportHeader.SchoolFullAddress}\\par\r\n{string.Empty}\\par\r\n{ReportHeader}\\par\r\n{SubHeader}\\par\r\n}}\r\n";
				link.Component = PivotGrid;
				link.Landscape = IsLandScape;
				link.PrintingSystem.ClearContent();
				link.ShowRibbonPreview(UserLookAndFeel.Default.ActiveLookAndFeel);
			}
			else if (LicenceStatus.IsTrialExpired)
			{
				XtraMessageBox.Show("Sorry! You cannot print because your license expired.\nPlease renew your license in order to print.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void ExportControl(string ReportHeader, string SubHeader, PrintableComponentLink link, GridControl PrintableGrid)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = "Save to",
			FileName = string.Format("{0}_{1}", ReportHeader.Replace('.', '_'), DateTime.Now.ToString("HHMMss")),
			RestoreDirectory = true,
			Filter = "Excel Workbook (*.Xlsx)|*.Xlsx"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			link.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs24 {AlienAge.ReportHeaders.ReportHeader.SchoolName}\\par\r\n{AlienAge.ReportHeaders.ReportHeader.SchoolFullAddress}\\par\r\n{string.Empty}\\par\r\n{ReportHeader}\\par\r\n{SubHeader}\\par\r\n}}\r\n";
			link.Component = PrintableGrid;
			link.Landscape = false;
			link.PrintingSystem.ClearContent();
			link.ExportToXlsx(saveFileDialog.FileName);
			if (XtraMessageBox.Show("Do you want to open the file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Process.Start(saveFileDialog.FileName);
			}
		}
	}

	public static void ExportControl(string ReportHeader, string SubHeader, PrintableComponentLink link, PivotGridControl PivotGrid)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = "Save to",
			FileName = string.Format("{0}_{1}", ReportHeader.Replace('.', '_'), DateTime.Now.ToString("HHMMss")),
			RestoreDirectory = true,
			Filter = "Excel Workbook (*.Xlsx)|*.Xlsx"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			link.RtfReportHeader = $"{{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{{\\fonttbl{{\\f0\\fnil\\fcharset0 Tahoma;}}}}\r\n\\viewkind4\\uc1\\pard\\qc\\f0\\fs24 {AlienAge.ReportHeaders.ReportHeader.SchoolName}\\par\r\n{AlienAge.ReportHeaders.ReportHeader.SchoolFullAddress}\\par\r\n{string.Empty}\\par\r\n{ReportHeader}\\par\r\n{SubHeader}\\par\r\n}}\r\n";
			link.Component = PivotGrid;
			link.Landscape = false;
			link.PrintingSystem.ClearContent();
			link.ExportToXlsx(saveFileDialog.FileName);
			if (XtraMessageBox.Show("Do you want to open the file?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Process.Start(saveFileDialog.FileName);
			}
		}
	}
}
