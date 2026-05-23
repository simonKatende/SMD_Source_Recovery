using System;
using System.Windows.Forms;

namespace AlienAge.TermlySettings.Thematic;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new AssessmentRatioSetup());
	}
}
