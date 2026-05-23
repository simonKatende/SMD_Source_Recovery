using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AlienAge.Connectivity;

namespace I_Xtreme;

internal class DataModel
{
	private static string connectionString = DataConnection.ConnectToDatabase();

	public static int SaveData(string TargetTable, string[] DataFields, object[] DataValues)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		int num = DataFields.Length - 1;
		for (int i = 0; i < DataValues.Length; i++)
		{
			if (i == num)
			{
				stringBuilder.Append(DataFields[i]);
				if (DataValues[i].GetType() == typeof(string))
				{
					stringBuilder2.Append("'" + DataValues[i]?.ToString() + "'");
				}
				else
				{
					stringBuilder2.Append(DataValues[i]);
				}
			}
			else
			{
				stringBuilder.Append(DataFields[i] + ",");
				if (DataValues[i].GetType() == typeof(string))
				{
					stringBuilder2.Append("'" + DataValues[i]?.ToString() + "',");
				}
				else
				{
					stringBuilder2.Append(DataValues[i]?.ToString() + ",");
				}
			}
		}
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string commandText = $"INSERT INTO {TargetTable} ({stringBuilder}) VALUES ({stringBuilder2})";
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = commandText,
			CommandType = CommandType.Text
		};
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
			return 1;
		}
		sqlConnection.Close();
		return 0;
	}

	public static int DeleteData(string DeleteStatement)
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = DeleteStatement,
			CommandType = CommandType.Text
		};
		if (sqlCommand.ExecuteNonQuery() > 0)
		{
			sqlConnection.Close();
			return 1;
		}
		sqlConnection.Close();
		return 0;
	}

	public static int SaveData(string TargetTable, string[] DataFields, object[] DataValues, string TargetTable2, string[] DataFields2, object[] DataValues2)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		StringBuilder stringBuilder4 = new StringBuilder();
		int num = DataFields.Length - 1;
		for (int i = 0; i < DataValues.Length; i++)
		{
			if (i == num)
			{
				stringBuilder.Append(DataFields[i]);
				if (DataValues[i].GetType() == typeof(string))
				{
					stringBuilder2.Append("'" + DataValues[i]?.ToString() + "'");
				}
				else
				{
					stringBuilder2.Append(DataValues[i]);
				}
			}
			else
			{
				stringBuilder.Append(DataFields[i] + ",");
				if (DataValues[i].GetType() == typeof(string))
				{
					stringBuilder2.Append("'" + DataValues[i]?.ToString() + "',");
				}
				else
				{
					stringBuilder2.Append(DataValues[i]?.ToString() + ",");
				}
			}
		}
		int num2 = DataFields2.Length - 1;
		for (int j = 0; j < DataValues2.Length; j++)
		{
			if (j == num2)
			{
				stringBuilder3.Append(DataFields2[j]);
				if (DataValues2[j].GetType() == typeof(string))
				{
					stringBuilder4.Append("'" + DataValues2[j]?.ToString() + "'");
				}
				else
				{
					stringBuilder4.Append(DataValues2[j]);
				}
			}
			else
			{
				stringBuilder3.Append(DataFields2[j] + ",");
				if (DataValues2[j].GetType() == typeof(string))
				{
					stringBuilder4.Append("'" + DataValues2[j]?.ToString() + "',");
				}
				else
				{
					stringBuilder4.Append(DataValues2[j]?.ToString() + ",");
				}
			}
		}
		int num3 = 0;
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
		string commandText = $"INSERT INTO {TargetTable} ({stringBuilder}) VALUES ({stringBuilder2})";
		string commandText2 = $"INSERT INTO {TargetTable2} ({stringBuilder3}) VALUES ({stringBuilder4})";
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			Transaction = sqlTransaction,
			CommandText = commandText,
			CommandType = CommandType.Text
		})
		{
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				num3++;
			}
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Connection = sqlConnection,
			Transaction = sqlTransaction,
			CommandText = commandText2,
			CommandType = CommandType.Text
		})
		{
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				num3++;
			}
		}
		sqlTransaction.Commit();
		sqlConnection.Close();
		return num3;
	}

	public static DataTable FetchData(string SelectStatement)
	{
		DataTable dataTable = new DataTable();
		if (!SelectStatement.ToUpper().Contains("SELECT"))
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM {SelectStatement}", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SourceTable");
			return dataSet.Tables[0];
		}
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(SelectStatement, connectionString);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2, "SourceTable");
		return dataSet2.Tables[0];
	}

	public static string[] DataCollection(string SelectStatement, string SourceColumn)
	{
		List<string> list = new List<string>();
		if (!SelectStatement.ToUpper().Contains("SELECT"))
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM {SelectStatement}", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SourceTable");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				list.Add(row[SourceColumn].ToString());
			}
		}
		else
		{
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(SelectStatement, connectionString);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "SourceTable");
			foreach (DataRow row2 in dataSet2.Tables[0].Rows)
			{
				list.Add(row2[SourceColumn].ToString());
			}
		}
		return list.ToArray();
	}

	public static DataTable FetchData(string SourceTable, string ConditionalStatement)
	{
		DataTable dataTable = new DataTable();
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM {SourceTable} WHERE {ConditionalStatement} ", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "SourceTable");
		return dataSet.Tables[0];
	}

	public static int GetRecordCount(string GroupedColumn, string TableSource)
	{
		int num = 0;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT COUNT ({0}) AS OutPutName FROM {1} HAVING (COUNT({0}) IS NOT NULL)", GroupedColumn, TableSource), DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		return Convert.ToInt32(dataTable.Rows[0]["OutPutName"].ToString());
	}
}
