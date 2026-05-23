using System;
using System.IO;

namespace EventLogger;

public class FileLogger
{
	private readonly string _logDirectory;

	private readonly string _logFilePath;

	private readonly object _lock = new object();

	public FileLogger()
	{
		_logDirectory = Path.Combine("C:\\Logs", "SyncStudents");
		Directory.CreateDirectory(_logDirectory);
		_logFilePath = Path.Combine(_logDirectory, "service_log.txt");
		LogInformation($"FileLogger initialized at {DateTime.Now}");
	}

	public void LogError(string message)
	{
		WriteToFile($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
	}

	public void LogError(Exception ex, string message)
	{
		WriteToFile($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
		WriteToFile("[EXCEPTION] " + ex.GetType().Name + ": " + ex.Message);
		WriteToFile("[STACKTRACE] " + ex.StackTrace);
	}

	public void LogWarning(string message)
	{
		WriteToFile($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
	}

	public void LogInformation(string message)
	{
		WriteToFile($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
	}

	private void WriteToFile(string message)
	{
		lock (_lock)
		{
			try
			{
				File.AppendAllText(_logFilePath, message + Environment.NewLine);
			}
			catch (Exception ex)
			{
				try
				{
					string path = "C:\\SyncStudents_emergency_log.txt";
					File.AppendAllText(path, $"[LOGGER FAILURE] {DateTime.Now}: {ex.Message}" + Environment.NewLine);
					File.AppendAllText(path, "[ORIGINAL MESSAGE] " + message + Environment.NewLine);
				}
				catch
				{
				}
			}
		}
	}
}
