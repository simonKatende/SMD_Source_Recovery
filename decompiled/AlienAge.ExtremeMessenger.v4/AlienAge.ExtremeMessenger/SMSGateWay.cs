using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AlienAge.ExtremeMessenger;

public class SMSGateWay
{
	private string connection = string.Empty;

	public static string SMSUserName { get; set; }

	public static string SMSPassword { get; set; }

	public static string SMSURL { get; set; } = "https://www.egosms.co/api/v1/plain/?";


	public static string SMSSender { get; set; }

	public static string SMSProvider { get; set; }

	public SMSGateWay(string ConnectionString)
	{
		connection = ConnectionString;
	}

	public bool TrySendSMSViaPOST(string Recipients, string Message, out string errorMessage)
	{
		if (!InitializeAccount())
		{
			errorMessage = "SMS account is not configured. Set it up under Settings.";
			return false;
		}
		try
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			string requestUriString = $"https://www.egosms.co/api/v1/plain/?number={Uri.EscapeDataString(Recipients)}&message={Uri.EscapeDataString(Message)}&username={Uri.EscapeDataString(SMSUserName)}&password={Uri.EscapeDataString(SMSPassword)}&sender={Uri.EscapeDataString(SMSSender)}";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			string response = streamReader.ReadToEnd();
			streamReader.Close();
			httpWebResponse.Close();
			SaveSMSLog(Recipients, response, Message);
			errorMessage = null;
			return true;
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
			return false;
		}
	}

	public void SendWithUNRAGateway(string Recipients, string Message, string CreatedBy)
	{
		string response = string.Empty;
		string text = string.Empty;
		try
		{
			if (Recipients.Length == 10)
			{
				text = "256" + Recipients.Substring(1, 9);
			}
			else if (Recipients.Length == 11)
			{
				text = "256" + Recipients.Substring(1, 9);
			}
			else if (Recipients.Length == 12)
			{
				text = Recipients;
			}
			else if (Recipients.Length > 12)
			{
				text = Recipients.Substring(1, 9);
				text = "256" + text;
			}
			string address = $"http://192.168.26.83:8080/SMSIntegrator/SmsWS/SMSGateway?Contact={text}&Message={Message}&CreatedBy={CreatedBy}";
			using WebClient webClient = new WebClient();
			string text2 = webClient.DownloadString(address);
			response = "Message Delivered";
		}
		catch (Exception ex)
		{
			response = ex.Message;
		}
		SaveSMSLog(text, response, Message);
	}

	public void SetSMSAccount(string RequestsURL, string UserName, string Password, string Sender, string Provider)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(connection);
			sqlConnection.Open();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_SMSAccount", connection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SMSAccount");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_SMSAccount (url,username,password,provider,sender) VALUES (@url,@username,@password,@provider,@sender)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@url", SqlDbType.VarChar, 200);
					sqlParameter.Value = RequestsURL;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@username", SqlDbType.VarChar, 50);
					sqlParameter.Value = UserName;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@password", SqlDbType.VarChar, 50);
					sqlParameter.Value = Password;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@provider", SqlDbType.VarChar, 50);
					sqlParameter.Value = Provider;
					string empty = string.Empty;
					empty = ((Sender.Length <= 11) ? Sender : Sender.Substring(0, 11));
					sqlParameter = sqlCommand.Parameters.Add("@sender", SqlDbType.VarChar, 11);
					sqlParameter.Value = empty;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					return;
				}
			}
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_SMSAccount SET url=@url,username=@username,password=@password,provider=@provider,sender=@sender",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@url", SqlDbType.VarChar, 200);
			sqlParameter2.Value = RequestsURL;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@username", SqlDbType.VarChar, 50);
			sqlParameter2.Value = UserName;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@password", SqlDbType.VarChar, 50);
			sqlParameter2.Value = Password;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@provider", SqlDbType.VarChar, 50);
			sqlParameter2.Value = Provider;
			string empty2 = string.Empty;
			empty2 = ((Sender.Length <= 11) ? Sender : Sender.Substring(0, 11));
			sqlParameter2 = sqlCommand2.Parameters.Add("@sender", SqlDbType.VarChar, 11);
			sqlParameter2.Value = empty2;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public bool InitializeAccount()
	{
		bool flag = false;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_SMSAccount", connection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "SMSAccount");
		if (dataSet.Tables[0].Rows.Count == 0)
		{
			flag = false;
		}
		else
		{
			flag = true;
			{
				IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						SMSSender = dataRow["sender"].ToString();
						SMSPassword = dataRow["password"].ToString();
						SMSProvider = dataRow["provider"].ToString();
						SMSURL = dataRow["url"].ToString();
						SMSUserName = dataRow["username"].ToString();
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		return flag;
	}

	private void SaveSMSLog(string recipients, string response, string message)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(connection);
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_SMSLog (date, recipients,response,message) VALUES (@date, @recipients,@response,@message)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@date", SqlDbType.DateTime);
			sqlParameter.Value = DateTime.Now;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@recipients", SqlDbType.VarChar, 5000);
			sqlParameter.Value = recipients;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@response", SqlDbType.VarChar, 100);
			sqlParameter.Value = response;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@message", SqlDbType.NVarChar, 500);
			sqlParameter.Value = message;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine($"SaveSMSLog failed: {ex.Message}");
		}
	}
}
