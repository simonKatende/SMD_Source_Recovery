using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace I_Xtreme;

[Serializable]
internal class CurrentControl
{
	public static XtraUserControl UserControl { get; set; }

	public static XtraUserControl PreviousLoadedControl
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_UserControl.tmp");
			CurrentControl currentControl = new CurrentControl();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			currentControl = (CurrentControl)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return UserControl;
		}
	}

	public static void LoadControl(XtraUserControl _UserControl, PanelControl _PanelControl)
	{
		_PanelControl.Controls.Clear();
		_PanelControl.Controls.Add(_UserControl);
		_UserControl.Dock = DockStyle.Fill;
	}

	public static void SaveControl(XtraUserControl userControl)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_UserControl.tmp");
		CurrentControl graph = new CurrentControl();
		UserControl = userControl;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
