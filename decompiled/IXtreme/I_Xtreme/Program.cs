using System;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace I_Xtreme;

internal static class Program
{
	public class MyFancyContext : ApplicationContext
	{
		private Login logOnForm;

		private MainForm shellForm;

		private readonly ConnectToDatabase connect;

		public MyFancyContext()
		{
			if (DataConnection.DatabaseConnected())
			{
				logOnForm = new Login();
				base.MainForm = logOnForm;
			}
			else
			{
				connect = new ConnectToDatabase();
				base.MainForm = connect;
			}
		}

		public MyFancyContext(Form mainForm)
			: base(mainForm)
		{
		}

		protected override void OnMainFormClosed(object sender, EventArgs e)
		{
			if (base.MainForm == logOnForm && logOnForm.DialogResult == DialogResult.OK)
			{
				shellForm = new MainForm();
				base.MainForm = shellForm;
				base.MainForm.Show();
			}
			else if (base.MainForm == connect && connect.DialogResult == DialogResult.OK)
			{
				logOnForm = new Login();
				base.MainForm = logOnForm;
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
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new MyFancyContext());
	}
}
