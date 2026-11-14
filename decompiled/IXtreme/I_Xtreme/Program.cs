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

	/// <summary>
	/// Starts the application with no window, sends the day's fee promise reminders if they
	/// are due, and exits. Used by the Windows scheduled task created in Follow-up Settings.
	/// </summary>
	internal const string SendFeeRemindersSwitch = "/send-fee-reminders";

	[STAThread]
	private static int Main(string[] args)
	{
		if (args != null && Array.Exists(args, a => string.Equals(a, SendFeeRemindersSwitch, StringComparison.OrdinalIgnoreCase)))
		{
			// No database connection saved on this PC: nothing can be sent, and no window may be shown.
			if (!DataConnection.DatabaseConnected())
			{
				return 2;
			}
			I_Xtreme.ExtremeClasses.FeesAutoReminders.RunIfDue("(scheduled task)");
			return 0;
		}
		BonusSkins.Register();
		SkinManager.EnableFormSkins();
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.Run(new MyFancyContext());
		return 0;
	}
}
