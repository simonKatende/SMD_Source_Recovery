using System;
using System.Windows.Forms;
using DevExpress.Skins;

namespace LibraryManagement;

internal static class Program
{
	public class MyFancyContext : ApplicationContext
	{
		private readonly Login logOnForm;

		private LibraryMain shellForm;

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
			if (base.MainForm == logOnForm && logOnForm.DialogResult == DialogResult.OK)
			{
				shellForm = new LibraryMain();
				base.MainForm = shellForm;
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
		SkinManager.EnableFormSkins();
		SkinManager.EnableFormSkinsIfNotVista();
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new MyFancyContext());
	}
}
