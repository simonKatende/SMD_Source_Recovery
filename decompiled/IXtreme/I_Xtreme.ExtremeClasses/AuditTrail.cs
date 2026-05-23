using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

public class AuditTrail
{
	public enum Departments
	{
		[Description("Fees")]
		Fees,
		[Description("Accounts")]
		Accounts,
		[Description("Admission")]
		Admission,
		[Description("Library")]
		Library,
		[Description("Inventory")]
		Inventory,
		[Description("Academics")]
		Academics
	}

	private static string MachineIPAddress
	{
		get
		{
			string hostName = Dns.GetHostName();
			IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
			string result = string.Empty;
			IPAddress[] array = hostAddresses;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					result = iPAddress.ToString();
				}
			}
			return result;
		}
	}

	public static void CaptureActions(string Action, string ActionDetails, Departments departments, string StudentNo, string ClassEn, decimal OldValues, decimal NewValues)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO TrailsAudit (Action,ActionDetails,Date,Time,UserName,Name,SourcePC,SourceIP,UserGroup,Department,StudentNo,ClassEn,OldValues,NewValues) VALUES (@Action,@ActionDetails,@Date,@Time,@UserName,@Name,@SourcePC,@SourceIP,@UserGroup,@Department,@StudentNo,@ClassEn,@OldValues,@NewValues)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("Action", Action);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("ActionDetails", ActionDetails);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("Date", DateTime.Now.ToShortDateString());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("Time", DateTime.Now.ToString("HH:mm:ss"));
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("UserName", CurrentUser.UserName);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("Name", CurrentUser.UserFullName);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("SourcePC", Environment.MachineName);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("SourceIP", MachineIPAddress);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("UserGroup", CurrentUser.UserGroup);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("Department", GetEnumDescription(departments));
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("StudentNo", StudentNo);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("ClassEn", ClassEn);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("OldValues", OldValues);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.AddWithValue("NewValues", NewValues);
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}

	private static string GetEnumDescription(Enum value)
	{
		FieldInfo field = value.GetType().GetField(value.ToString());
		DescriptionAttribute descriptionAttribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
		return (descriptionAttribute == null) ? value.ToString() : descriptionAttribute.Description;
	}
}
