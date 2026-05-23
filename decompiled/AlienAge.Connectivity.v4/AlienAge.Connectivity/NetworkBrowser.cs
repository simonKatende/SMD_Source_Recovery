using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AlienAge.Connectivity;

public sealed class NetworkBrowser
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SERVER_INFO_100
	{
		public int sv100_platform_id;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string sv100_name;
	}

	private const uint SV_TYPE_WORKSTATION = 1u;

	private const uint SV_TYPE_SERVER = 2u;

	[DllImport("Netapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int NetServerEnum(string serverName, int level, ref IntPtr buffer, int prefMaxLen, ref int entriesRead, ref int totalEntries, uint serverType, string domain, IntPtr resumeHandle);

	[DllImport("Netapi32.dll", SetLastError = true)]
	public static extern int NetApiBufferFree(IntPtr buffer);

	public static List<string> GetNetworkComputerNamesUsingPing(string baseIP)
	{
		List<string> computerNames = new List<string>();
		string defaultGateway = GetDefaultGateway();
		List<Task> list = new List<Task>();
		for (int i = 1; i < 255; i++)
		{
			string ip = baseIP + i;
			Ping ping = new Ping();
			Task item = Task.Run(async delegate
			{
				try
				{
					if ((await ping.SendPingAsync(ip, 100)).Status == IPStatus.Success)
					{
						try
						{
							IPHostEntry hostEntry = await Dns.GetHostEntryAsync(ip);
							if (!string.IsNullOrWhiteSpace(hostEntry.HostName) && !hostEntry.HostName.Equals(ip) && !hostEntry.HostName.Equals(defaultGateway))
							{
								string computerName = hostEntry.HostName.Replace(".local", string.Empty);
								lock (computerNames)
								{
									computerNames.Add(computerName);
								}
							}
						}
						catch (SocketException)
						{
						}
					}
				}
				catch (PingException)
				{
				}
			});
			list.Add(item);
		}
		Task.WaitAll(list.ToArray());
		return computerNames.Distinct().ToList();
	}

	private static string GetDefaultGateway()
	{
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			if (networkInterface.OperationalStatus != OperationalStatus.Up)
			{
				continue;
			}
			foreach (GatewayIPAddressInformation gatewayAddress in networkInterface.GetIPProperties().GatewayAddresses)
			{
				if (gatewayAddress.Address.AddressFamily == AddressFamily.InterNetwork)
				{
					return gatewayAddress.Address.ToString();
				}
			}
		}
		return null;
	}

	public static string GetBaseIpAddress()
	{
		string machineName = Environment.MachineName;
		string empty = string.Empty;
		IPHostEntry hostEntry = Dns.GetHostEntry(machineName);
		IEnumerable<IPAddress> source = hostEntry.AddressList.Where((IPAddress ip) => ip.AddressFamily == AddressFamily.InterNetwork);
		if (source.Any())
		{
			empty = source.FirstOrDefault().ToString();
			if (empty == "127.0.0.1")
			{
				return "No IPAddress";
			}
			if (string.IsNullOrWhiteSpace(empty))
			{
				throw new ArgumentException("IP address cannot be null or empty.");
			}
			int num = empty.IndexOf('.');
			int num2 = empty.IndexOf('.', num + 1);
			int num3 = empty.IndexOf('.', num2 + 1);
			if (num3 == -1)
			{
				throw new ArgumentException("Invalid IP address format. Should contain at least three groups.");
			}
			return empty.Substring(0, num3 + 1).Trim();
		}
		return "No IPAddress";
	}

	public static List<string> GetDatabases(string serverName, string loginId, string password)
	{
		string connectionString = "Server=" + serverName + ";User Id=" + loginId + ";Password=" + password + ";";
		List<string> list = new List<string>();
		string cmdText = "SELECT name FROM sys.databases";
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			try
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					list.Add(sqlDataReader["name"].ToString());
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
		return list;
	}
}
