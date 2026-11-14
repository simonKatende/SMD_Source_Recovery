using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using I_Xtreme.Models;

namespace I_Xtreme.ExtremeClasses;

/// <summary>
/// Sends the day's promise reminders without anyone pressing a button. Used two ways:
///   - while the application is open, a timer checks every few minutes (Start);
///   - when it is closed, Windows starts it with the no-window switch (RunIfDue).
/// Either way the service claims the day first, so reminders go out once a day in total.
/// </summary>
internal static class FeesAutoReminders
{
    private static Timer _timer;
    private static bool  _busy;

    private static string LogPath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "School Management Dynamics", "fee-reminders.log");

    // Counts and error text only: never phone numbers, names or message text.
    private static void Log(string line)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogPath));
            File.AppendAllText(LogPath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  {line}{Environment.NewLine}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"FeesAutoReminders: could not write {LogPath}: {ex.Message}");
        }
    }

    /// <summary>
    /// Send today's promise reminders if they are switched on, due, and not yet sent today.
    /// Returns the result, or null when nothing was due. Never throws: failures are logged.
    /// </summary>
    public static SmsReminderResult RunIfDue(string startedBy)
    {
        try
        {
            var service = new FeesFollowUpService();
            if (!service.IsAutomaticRunDue(DateTime.Now)) return null;

            var result = service.RunAutomaticReminders(startedBy);
            if (result.AlreadyRanToday) return null;
            Log($"Automatic promise reminders: {result.TotalSent} sent, {result.Failures.Count} failed (started by {startedBy}).");
            return result;
        }
        catch (Exception ex)
        {
            Log($"Automatic promise reminders failed: {ex.Message}");
            return null;
        }
    }

    /// <summary>Start checking in the background while the application is open.</summary>
    public static void Start(Func<string> currentUser)
    {
        if (_timer != null) return;
        _timer = new Timer { Interval = 60_000 };   // first check a minute after start-up
        _timer.Tick += async (s, e) =>
        {
            _timer.Interval = 5 * 60_000;           // then every five minutes
            if (_busy) return;
            _busy = true;
            try
            {
                string user = currentUser();
                await Task.Run(() => RunIfDue(user));
            }
            catch (Exception ex)
            {
                Log($"Automatic promise reminders: background check failed: {ex.Message}");
            }
            finally
            {
                _busy = false;
            }
        };
        _timer.Start();
    }
}
