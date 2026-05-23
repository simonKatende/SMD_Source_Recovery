using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace ExtremeMessenger;

[Serializable]
public class Messenger
{
	public static void SendSms(LabelControl labelControl)
	{
		try
		{
			string requestUriString = "http://www.redsmsuganda.com/api-sub.php";
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "user=" + text3 + "&password=" + text4 + "&reciever=" + text + "&sender=" + text2 + "&message=" + text5;
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = text6.Length;
			StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream(), Encoding.ASCII);
			streamWriter.Write(text6);
			streamWriter.Close();
			StreamReader streamReader = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
			string text7 = streamReader.ReadToEnd();
			labelControl.Text = "REDSMS API Response:" + text7;
			streamReader.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void SaveMessage()
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_5546793873 (timeOut,dateOut,ipAddress,Sender,Student,Receipient,MessageType,MessageBody,Debit,Credit)VALUES(@timeOut,@dateOut,@ipAddress,@Sender,@Student,@Receipient,@MessageType,@MessageBody,@Debit,@Credit)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@timeOut", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@dateOut", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@ipAddress", SqlDbType.VarChar, 50);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Sender", SqlDbType.VarChar, 50);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Student", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Receipient", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@MessageType", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@MessageBody", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Timestamp);
		sqlParameter.Value = "";
		sqlParameter.Direction = ParameterDirection.Input;
	}

	public static string MessengerSender()
	{
		string result = "";
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Sender");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = row["ShortName"].ToString();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}
}
