using System;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

public class PayableInKind
{
	public static void AddNewStockItem(string Item)
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_StockItems WHERE AssetName=@AssetName",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
			sqlParameter.Value = Item;
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				return;
			}
			string commandText = "INSERT INTO tbl_StockItems (AssetName,ItemType,Description,Qty,units,IsDepreciable,DepreMethod,DepreRate,InitialCost,lifeSpan,AssetValue,category) VALUES (@AssetName,@ItemType,@Description,@Qty,@units,@IsDepreciable,@DepreMethod,@DepreRate,@InitialCost,@lifeSpan,@AssetValue,@category)";
			using SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = commandText,
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@AssetName", SqlDbType.VarChar, 50);
			sqlParameter2.Value = Item;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@ItemType", SqlDbType.VarChar, 30);
			sqlParameter2.Value = "Stock Item";
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@Description", SqlDbType.VarChar, 150);
			sqlParameter2.Value = "Student Requirement";
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@Qty", SqlDbType.Int);
			sqlParameter2.Value = 0;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@units", SqlDbType.VarChar, 30);
			sqlParameter2.Value = DBNull.Value;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@IsDepreciable", SqlDbType.Bit);
			sqlParameter2.Value = false;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@DepreMethod", SqlDbType.VarChar, 25);
			sqlParameter2.Value = DBNull.Value;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@DepreRate", SqlDbType.Float);
			sqlParameter2.Value = 0;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@InitialCost", SqlDbType.Money);
			sqlParameter2.Value = 0;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@lifeSpan", SqlDbType.Float);
			sqlParameter2.Value = 5;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@AssetValue", SqlDbType.Money);
			sqlParameter2.Value = 0;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@category", SqlDbType.BigInt);
			sqlParameter2.Value = 1;
			sqlParameter2.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}
}
