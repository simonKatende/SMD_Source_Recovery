using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;

namespace AlienAge.GradingScales;

[Serializable]
public class ALevelGradingScale
{
	public enum GradingSystem
	{
		NewGradingSystem,
		OldGradingSystem
	}

	private static bool _useNewGradingSystem { get; set; }

	public static DataTable SubjectGradingScale
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ALevelGradingScale_2", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelSubjectGradingScale");
			DataTable dataTable = new DataTable();
			return dataSet.Tables[0];
		}
	}

	public static DataTable PaperBalancingScale
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ALevelGradingScale", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelPaperBalancingScale");
			DataTable dataTable = new DataTable();
			return dataSet.Tables[0];
		}
	}

	public static DataTable ALevelComments
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_ALevel_Comments", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevel_Comments");
			DataTable dataTable = new DataTable();
			return dataSet.Tables[0];
		}
	}

	public static string GradingSystemInUse
	{
		get
		{
			string result = "";
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT Points FROM ALevelGradingScale WHERE Category='B' AND Debut=2.6 AND [End]=3.5",
					CommandType = CommandType.Text
				};
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					sqlConnection.Close();
					result = "OldGradingSystem";
				}
				else
				{
					sqlConnection.Close();
					result = "NewGradingSystem";
				}
			}
			return result;
		}
	}

	public static void InitializeSubjectGradingScale(string ConnectionString)
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[9] { "D1", "D2", "C3", "C4", "C5", "C6", "P7", "P8", "F9" });
			List<float> list2 = new List<float>();
			list2.AddRange(new float[9] { 75f, 70f, 65f, 60f, 55f, 50f, 45f, 40f, 0f });
			List<float> list3 = new List<float>();
			list3.AddRange(new float[9] { 100f, 74f, 69f, 64f, 59f, 54f, 49f, 44f, 39f });
			List<int> list4 = new List<int>();
			list4.AddRange(new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			for (int i = 0; i < 9; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM ALevelGradingScale_2 WHERE Category='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(ConnectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO ALevelGradingScale_2 (Category,Debut,[End],Points)VALUES(@Category,@Debut,@End,@Points)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Category", SqlDbType.VarChar, 2);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Debut", SqlDbType.Float);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@End", SqlDbType.Float);
					sqlParameter.Value = list3[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Points", SqlDbType.Int);
					sqlParameter.Value = list4[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void InitializePaperBalacingScale(string ConnectionString)
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[7] { "A", "B", "C", "D", "E", "O", "F" });
			List<double> list2 = new List<double>();
			list2.AddRange(new double[7] { 1.0, 2.6, 3.6, 4.6, 5.6, 6.6, 7.6 });
			List<double> list3 = new List<double>();
			list3.AddRange(new double[7] { 2.5, 3.5, 4.5, 5.5, 6.5, 7.5, 9.0 });
			List<int> list4 = new List<int>();
			list4.AddRange(new int[7] { 6, 5, 4, 3, 2, 1, 0 });
			List<string> list5 = new List<string>();
			list5.AddRange(new string[9] { "Very good performance. Keep it up.", "Please don't feel so confortable.", "Aim at excellence next term.", "You need to consult a lot to improve", "Seriously revision is required please.", "Can do better with more effort.", "Below average, concentrate more.", "This is a bad edge to be. Work harder.", "Please! You can do better than this." });
			List<string> list6 = new List<string>();
			list6.AddRange(new string[9] { "Please maintain this performance.", "Make it to the next grade please.", "Aim for distinctions next term.", "Please. Revise seriously.", "Fair results, dont relax.", "Much has to be done.", "More concentration is needed.", "You're one step away from failing!", "More effort is eagerly needed" });
			List<string> list7 = new List<string>();
			list7.AddRange(new string[9] { "Excellent work. Keep it up.", "Promising results. Keep it up.", "Promising results, do't relax", "Don't relax, you can make it", "Aim at higher than this.", "Should intensify reading books.", "Just below average", "More effort will raise you.", "Please, revise harder." });
			List<string> list8 = new List<string>();
			list8.AddRange(new string[9] { "I believe you can do more than  this.", "Thank you, but aim higher next term.", "Encouraging results, keep it up", "Very good work", "This is promising. Keep it up.", "Hard work will pay you off.", "settle and read books.", "Please, consider higher grades.", "Invest more time in revision." });
			List<string> list9 = new List<string>();
			list9.AddRange(new string[9] { "Thank you, but keep it up.", "Thank you, but aim higher", "A Little more effort is needed.", "Very promising performance", "Good. Promising student.", "You can do better", "Focus more on challenging areas.", "Much more effort is need.", "Consult the teacher more often." });
			for (int i = 0; i < 7; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM ALevelGradingScale WHERE Category='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(ConnectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO ALevelGradingScale (Category,Debut,[End],Points,Comment,Comment2,Comment3,Comment4,Comment5)VALUES(@Category,@Debut,@End,@Points,@Comment,@Comment2,@Comment3,@Comment4,@Comment5)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Category", SqlDbType.VarChar, 2);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Debut", SqlDbType.Float);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@End", SqlDbType.Float);
					sqlParameter.Value = list3[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Points", SqlDbType.Int);
					sqlParameter.Value = list4[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Comment", SqlDbType.VarChar, 50);
					sqlParameter.Value = list5[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Comment2", SqlDbType.VarChar, 50);
					sqlParameter.Value = list6[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Comment3", SqlDbType.VarChar, 50);
					sqlParameter.Value = list7[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Comment4", SqlDbType.VarChar, 50);
					sqlParameter.Value = list8[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Comment5", SqlDbType.VarChar, 50);
					sqlParameter.Value = list9[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void InitializeALevelComments(string ConnectionString)
	{
		try
		{
			List<int> list = new List<int>();
			list.AddRange(new int[5] { 0, 4, 8, 12, 16 });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[5] { 3, 7, 11, 15, 20 });
			for (int i = 0; i < 5; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_ALevel_Comments WHERE Debut={list[i]}",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(ConnectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_ALevel_Comments (Debut,EndMark) VALUES (@Debut,@EndMark)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Debut", SqlDbType.Int);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@EndMark", SqlDbType.Int);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public static string GradeComment(string category)
	{
		string text = "";
		string result = "";
		Random random = new Random();
		int num = (int)(random.NextDouble() * 5.0 + 1.0);
		if (num > 1)
		{
			text = num.ToString();
		}
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT Comment{text.TrimEnd()} FROM ALevelGradingScale WHERE Category='{category.Trim()}'", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Grade_Comment");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = row["Comment" + text.TrimEnd()].ToString();
			}
		}
		return result;
	}
}
