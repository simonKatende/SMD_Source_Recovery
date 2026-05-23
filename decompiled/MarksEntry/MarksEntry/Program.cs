using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using MarksEntry.MarksEntryForms;

namespace MarksEntry;

internal static class Program
{
	public class MyFancyContext : ApplicationContext
	{
		private readonly Login logOnForm;

		private MainALevel mainALevel;

		private MainPrimary mainPrimary;

		private MainOLevelNewCur mainOLevelNewCur;

		public MyFancyContext()
		{
			logOnForm = new Login();
			base.MainForm = logOnForm;
		}

		public MyFancyContext(Form mainForm)
			: base(mainForm)
		{
		}

		protected override void OnMainFormClosed(object sender, EventArgs e)
		{
			if (base.MainForm == logOnForm && logOnForm.DialogResult == DialogResult.OK && logOnForm.SelectedClassGroup == "OLevel")
			{
				mainOLevelNewCur = new MainOLevelNewCur(MarksGateway._Class, MarksGateway.Subject, MarksGateway.Term, MarksGateway.TR);
				base.MainForm = mainOLevelNewCur;
				base.MainForm.Show();
			}
			else if (base.MainForm == logOnForm && logOnForm.DialogResult == DialogResult.OK && logOnForm.SelectedClassGroup == "ALevel")
			{
				mainALevel = new MainALevel();
				base.MainForm = mainALevel;
				base.MainForm.Show();
			}
			else if (base.MainForm == logOnForm && logOnForm.DialogResult == DialogResult.OK && logOnForm.SelectedClassGroup == "Primary")
			{
				mainPrimary = new MainPrimary();
				base.MainForm = mainPrimary;
				base.MainForm.Show();
			}
			else
			{
				base.OnMainFormClosed(sender, e);
			}
		}
	}

	[STAThread]
	private static void Main()
	{
		BonusSkins.Register();
		SkinManager.EnableFormSkins();
		SkinManager.EnableFormSkinsIfNotVista();
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new MyFancyContext());
	}
}
