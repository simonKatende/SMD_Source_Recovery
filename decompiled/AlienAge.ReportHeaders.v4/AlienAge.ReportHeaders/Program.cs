using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace AlienAge.ReportHeaders;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		BonusSkins.Register();
		SkinManager.EnableFormSkins();
		UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
		Application.Run(new Form1());
	}
}
