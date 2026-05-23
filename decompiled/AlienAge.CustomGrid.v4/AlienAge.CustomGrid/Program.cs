using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace AlienAge.CustomGrid;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		SkinManager.EnableFormSkins();
		UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
	}
}
