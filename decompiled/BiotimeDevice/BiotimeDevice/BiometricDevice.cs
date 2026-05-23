using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using zkemkeeper;

namespace BiotimeDevice;

public class BiometricDevice
{
	private static readonly BiometricDevice _deviceManager = new BiometricDevice();

	private static readonly CZKEM _device = (CZKEM)new CZKEMClass();

	public static BiometricDevice DeviceManager => _deviceManager;

	public static CZKEM Device => _device;

	public List<DeviceInformation> DeviceInformationList
	{
		get
		{
			List<DeviceInformation> list = new List<DeviceInformation>();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * FROM BioTimeDevices", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(new DeviceInformation
				{
					Id = Convert.ToInt32(row["Id"]),
					DeviceAssignment = row["DeviceAssignment"].ToString(),
					DeviceNumber = Convert.ToInt32(row["DeviceNumber"].ToString()),
					IpAddress = row["IpAddress"].ToString(),
					IsEnabled = Convert.ToBoolean(row["IsEnabled"]),
					Port = Convert.ToInt32(row["Port"].ToString())
				});
			}
			return list;
		}
	}

	public List<DeviceInformation> DeviceInformationListEnabled
	{
		get
		{
			List<DeviceInformation> list = new List<DeviceInformation>();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * FROM BioTimeDevices WHERE IsEnabled='True'", DataConnection.ConnectToDatabase());
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(new DeviceInformation
				{
					Id = Convert.ToInt32(row["Id"]),
					DeviceAssignment = row["DeviceAssignment"].ToString(),
					DeviceNumber = Convert.ToInt32(row["DeviceNumber"].ToString()),
					IpAddress = row["IpAddress"].ToString(),
					IsEnabled = Convert.ToBoolean(row["IsEnabled"])
				});
			}
			return list;
		}
	}

	private BiometricDevice()
	{
	}

	public bool CreateNewDevice(int DeviceNumber, string IpAddress, string DeviceAssignment, int port)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "SELECT DeviceNumber FROM BioTimeDevices WHERE DeviceNumber=@DeviceNumber",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@DeviceNumber", DeviceNumber);
		sqlParameter.Direction = ParameterDirection.Input;
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			return false;
		}
		sqlDataReader.Close();
		using SqlCommand sqlCommand2 = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO BioTimeDevices (DeviceNumber,IpAddress,DeviceAssignment,IsEnabled,Port) VALUES (@DeviceNumber,@IpAddress,@DeviceAssignment,@IsEnabled,@Port)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@DeviceNumber", DeviceNumber);
		sqlParameter2.Direction = ParameterDirection.Input;
		sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@IpAddress", IpAddress);
		sqlParameter2.Direction = ParameterDirection.Input;
		sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@DeviceAssignment", DeviceAssignment);
		sqlParameter2.Direction = ParameterDirection.Input;
		sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@IsEnabled", true);
		sqlParameter2.Direction = ParameterDirection.Input;
		sqlParameter2 = sqlCommand2.Parameters.AddWithValue("@Port", port);
		sqlParameter2.Direction = ParameterDirection.Input;
		if (sqlCommand2.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
			return true;
		}
		sqlConnection.Close();
		return false;
	}
}
