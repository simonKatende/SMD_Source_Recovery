using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ExtremeMessenger;

public static class MessageProcessor
{
	private static int w;

	private static string ConnectionString()
	{
		StreamReader streamReader = null;
		string result = string.Empty;
		try
		{
			streamReader = new StreamReader("C:\\ConnectionString.txt", detectEncodingFromByteOrderMarks: true);
			result = streamReader.ReadLine();
			streamReader.Close();
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static void StoreMessageToServer(string Recepient, string Subject, string MessageBody, string SentBy)
	{
		using SqlConnection sqlConnection = new SqlConnection(ConnectionString());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_MessageCenter (recepient,subject,body,dateSent,sentBy,processed) VALUES (@recepient,@subject,@body,@dateSent,@sentBy,@processed)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@recepient", SqlDbType.VarChar, 50);
		sqlParameter.Value = Recepient;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@subject", SqlDbType.VarChar, 50);
		sqlParameter.Value = Subject;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@body", SqlDbType.VarChar, 162);
		sqlParameter.Value = MessageBody;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@dateSent", SqlDbType.DateTime);
		sqlParameter.Value = DateTime.Now;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@sentBy", SqlDbType.VarChar, 50);
		sqlParameter.Value = SentBy;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@processed", SqlDbType.Bit);
		sqlParameter.Value = false;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
	}
}
