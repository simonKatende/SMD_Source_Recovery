using System;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme;

internal class PromoteToNextClass
{
	public static bool ShowOLevelPromotionStatus
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_PromoStatus WHERE ClassLevel='levelo'", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "_PromotionStatus");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			bool result = false;
			if (dataTable.Rows.Count >= 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					result = Convert.ToBoolean(row["outPut"]);
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	public static bool ShowALevelPromotionStatus
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_PromoStatus WHERE ClassLevel='levela'", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "_PromotionStatus");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			bool result = false;
			if (dataTable.Rows.Count >= 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					result = Convert.ToBoolean(row["outPut"]);
				}
			}
			else
			{
				result = false;
			}
			return result;
		}
	}

	public static void SetPromotionStatusVisibility(string classLevel, bool promoStatus)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = $"SELECT * FROM tbl_PromoStatus WHERE ClassLevel='{classLevel}'",
			CommandType = CommandType.Text
		};
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "UPDATE tbl_PromoStatus SET outPut=@outPut WHERE ClassLevel=@ClassLevel",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 10);
				sqlParameter.Value = classLevel;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@outPut", SqlDbType.Bit);
				sqlParameter.Value = promoStatus;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection2.Close();
			return;
		}
		sqlConnection.Close();
		using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection3.Open();
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Connection = sqlConnection3,
			CommandText = "INSERT INTO tbl_PromoStatus (ClassLevel,outPut) VALUES (@ClassLevel,@outPut)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 10);
			sqlParameter2.Value = classLevel;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@outPut", SqlDbType.Bit);
			sqlParameter2.Value = promoStatus;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
		}
		sqlConnection3.Close();
	}

	public static void SetConditionalPromotionRange(string StudentClass, string GroupRange, float From, float To)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = $"SELECT * FROM tbl_PromoCutOff WHERE ClassLevel='{StudentClass}' AND GroupRange='{GroupRange}'",
			CommandType = CommandType.Text
		};
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "UPDATE StudentClass SET From=@From,To=@To WHERE ClassId=@ClassId AND GroupRange=@GroupRange",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@ClassId", SqlDbType.VarChar, 10);
				sqlParameter.Value = StudentClass;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@GroupRange", SqlDbType.Bit);
				sqlParameter.Value = GroupRange;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@From", SqlDbType.Float);
				sqlParameter.Value = From;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@To", SqlDbType.Float);
				sqlParameter.Value = To;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection2.Close();
			return;
		}
		sqlConnection.Close();
		using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection3.Open();
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Connection = sqlConnection3,
			CommandText = "INSERT INTO tbl_PromoStatus (ClassId,GroupRange,From,To) VALUES (@ClassId,@GroupRange,@From,@To)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@ClassId", SqlDbType.VarChar, 10);
			sqlParameter2.Value = StudentClass;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@GroupRange", SqlDbType.Bit);
			sqlParameter2.Value = GroupRange;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@From", SqlDbType.Float);
			sqlParameter2.Value = From;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@To", SqlDbType.Float);
			sqlParameter2.Value = To;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
		}
		sqlConnection3.Close();
	}
}
