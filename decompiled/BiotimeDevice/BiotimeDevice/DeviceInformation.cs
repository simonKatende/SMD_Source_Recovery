namespace BiotimeDevice;

public class DeviceInformation
{
	public int Id { get; set; }

	public int DeviceNumber { get; set; }

	public int Port { get; set; }

	public string IpAddress { get; set; }

	public string DeviceAssignment { get; set; }

	public bool IsEnabled { get; set; }
}
