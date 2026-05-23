using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AlienAge.Connectivity;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

[Serializable]
public class TheologyGradingScale
{
	public static string LandScapeReportFooter_En
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder("Grading Scale: ");
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelGradingScale_TH", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "LandscapeFooterEn");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					for (int i = 0; i < 5; i++)
					{
						stringBuilder.Append(string.Format("{0}({1}-{2})  ", row["Category_En"], row["Debut_En"], row["End_En"]));
					}
				}
			}
			return stringBuilder.ToString();
		}
	}

	public static string LandScapeReportFooter_Ar
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder("مقياس الدرجات: ");
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelGradingScale_TH", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "LandscapeFooterAr");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					for (int i = 0; i < 6; i++)
					{
						stringBuilder.Append(string.Format("{0}({1}-{2})  ", row["Category_Ar"], row["Debut_Ar"], row["End_Ar"]));
					}
				}
			}
			return ReverseString(stringBuilder.ToString());
		}
	}

	private static string ReverseString(string s)
	{
		char[] array = s.ToCharArray();
		Array.Reverse(array);
		return new string(array);
	}

	public static DataTable TheologyGradingScaleSource(string ClassLevel)
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM OLevelGradingScale_TH WHERE ClassLevel='{ClassLevel}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TheologyGradingScale");
		DataTable dataTable = new DataTable();
		return dataSet.Tables[0];
	}

	public static void InitializeTheologySubjectGrades(string ClassLevel)
	{
		try
		{
			if (ClassLevel == "Shuuba")
			{
				List<string> list = new List<string>();
				list.AddRange(new string[9] { "D1", "D2", "C3", "C4", "C5", "C6", "P7", "P8", "F9" });
				List<double> list2 = new List<double>();
				list2.AddRange(new double[9] { 75.0, 70.0, 65.0, 60.0, 55.0, 50.0, 45.0, 40.0, 0.0 });
				List<double> list3 = new List<double>();
				list3.AddRange(new double[9] { 100.0, 74.0, 69.0, 64.0, 59.0, 54.0, 49.0, 44.0, 39.0 });
				List<int> list4 = new List<int>();
				list4.AddRange(new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
				List<string> list5 = new List<string>();
				list5.AddRange(new string[9] { "Very good performance. Keep it up.", "Please don't feel so confortable.", "Aim at excellence next term.", "You need to consult a lot to improve", "Seriously revision is required please.", "Can do better with more effort.", "Below average, concentrate more.", "This is a bad edge to be. Work harder.", "Please! You can do better than this." });
				List<string> list6 = new List<string>();
				list6.AddRange(new string[9] { "Please maintain this performance.", "Make it to the next grade please.", "Aim for distinctions next term.", "Please. Revise seriously.", "Fair results, dont relax.", "Much has to be done.", "More concentration is needed.", "You're one step away from F9!", "More effort is eagerly needed" });
				List<string> list7 = new List<string>();
				list7.AddRange(new string[9] { "Excellent work. Keep it up.", "Promising results. Keep it up.", "Promising results, don't relax", "Don't relax, you can make it", "Aim higher than this.", "Should intensify reading books.", "Just below average", "More effort will raise you.", "Please, revise harder." });
				List<string> list8 = new List<string>();
				list8.AddRange(new string[9] { "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" });
				List<string> list9 = new List<string>();
				list9.AddRange(new string[9] { "٧٥", "٧٠", "٦٥", "٦٠", "٥٥", "٥٠", "٤٥", "٤٠", "٠" });
				List<string> list10 = new List<string>();
				list10.AddRange(new string[9] { "١٠٠", "٧٤", "٦٩", "٦٤", "٥٩", "٥٤", "٤٩", "٤٤", "٣٩" });
				List<string> list11 = new List<string>();
				list11.AddRange(new string[9] { "١", "٢", "٣", "٤", "٥", "٦", "٧", "٨", "٩" });
				List<string> list12 = new List<string>();
				list12.AddRange(new string[9] { "", "", "", "", "", "", "", "", "" });
				List<string> list13 = new List<string>();
				list13.AddRange(new string[9] { "", "", "", "", "", "", "", "", "" });
				List<string> list14 = new List<string>();
				list14.AddRange(new string[9] { "", "", "", "", "", "", "", "", "" });
				for (int i = 0; i < 9; i++)
				{
					using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = $"SELECT * FROM OLevelGradingScale_TH WHERE Category_En='{list[i]}' AND ClassLevel='{ClassLevel}'",
						CommandType = CommandType.Text
					};
					using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						continue;
					}
					sqlConnection.Close();
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO OLevelGradingScale_TH (Category_En,Category_Ar,Debut_En,End_En,Points_En,Debut_Ar,End_Ar,Points_Ar,Com_En,Com2_En,Com3_En,Com_Ar,Com2_Ar,Com3_Ar,ClassLevel) VALUES (@Category_En, @Category_Ar, @Debut_En, @End_En, @Points_En, @Debut_Ar, @End_Ar, @Points_Ar,@Com_En,@Com2_En,@Com3_En,@Com_Ar,@Com2_Ar,@Com3_Ar,@ClassLevel)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@Category_En", SqlDbType.VarChar, 10);
						sqlParameter.Value = list[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Debut_En", SqlDbType.Float);
						sqlParameter.Value = list2[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@End_En", SqlDbType.Float);
						sqlParameter.Value = list3[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Points_En", SqlDbType.Int);
						sqlParameter.Value = list4[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Com_En", SqlDbType.VarChar, 80);
						sqlParameter.Value = list5[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Com2_En", SqlDbType.VarChar, 80);
						sqlParameter.Value = list6[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Com3_En", SqlDbType.VarChar, 80);
						sqlParameter.Value = list7[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Category_Ar", SqlDbType.NVarChar, 10);
						sqlParameter.Value = list8[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Debut_Ar", SqlDbType.NVarChar, 4);
						sqlParameter.Value = list9[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@End_Ar", SqlDbType.NVarChar, 4);
						sqlParameter.Value = list10[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Points_Ar", SqlDbType.NVarChar, 1);
						sqlParameter.Value = list11[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Com_Ar", SqlDbType.NVarChar, 80);
						sqlParameter.Value = list12[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Com2_Ar", SqlDbType.NVarChar, 80);
						sqlParameter.Value = list13[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Com3_Ar", SqlDbType.NVarChar, 80);
						sqlParameter.Value = list14[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 20);
						sqlParameter.Value = ClassLevel;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					sqlConnection2.Close();
				}
				return;
			}
			List<string> list15 = new List<string>();
			list15.AddRange(new string[5] { "A", "B", "C", "D", "E" });
			List<double> list16 = new List<double>();
			list16.AddRange(new double[5] { 80.0, 70.0, 60.0, 50.0, 0.0 });
			List<double> list17 = new List<double>();
			list17.AddRange(new double[5] { 100.0, 79.9, 69.9, 59.9, 49.9 });
			List<int> list18 = new List<int>();
			list18.AddRange(new int[5] { 1, 2, 3, 4, 5 });
			List<string> list19 = new List<string>();
			list19.AddRange(new string[5] { "Excellent work. Keep it up.", "Please don't feel so confortable.", "Aim at excellence next term.", "You need to consult a lot to improve", "Seriously revision is required please." });
			List<string> list20 = new List<string>();
			list20.AddRange(new string[5] { "Please maintain this performance.", "Promising results. Keep it up.", "Promising results, do't relax", "Please. Revise seriously.", "Fair results, dont relax." });
			List<string> list21 = new List<string>();
			list21.AddRange(new string[5] { "Very good performance. Keep it up.", "Thank you, but aim higher", "Encouraging results, keep it up", "Don't relax, you can make it", "Aim higher than this." });
			List<string> list22 = new List<string>();
			list22.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list23 = new List<string>();
			list23.AddRange(new string[5] { "٨٠", "٧٠", "٦٠", "٥٠", "٠" });
			List<string> list24 = new List<string>();
			list24.AddRange(new string[5] { "١٠٠", "٧٩.٩", "٦٩.٩", "٥٩.٩", "٤٩.٩" });
			List<string> list25 = new List<string>();
			list25.AddRange(new string[5] { "١", "٢", "٣", "٤", "٥" });
			List<string> list26 = new List<string>();
			list26.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list27 = new List<string>();
			list27.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list28 = new List<string>();
			list28.AddRange(new string[5] { "", "", "", "", "" });
			for (int j = 0; j < 5; j++)
			{
				using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection3.Open();
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"SELECT * FROM OLevelGradingScale_TH WHERE Category_En='{list15[j]}' AND ClassLevel='{ClassLevel}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
				if (sqlDataReader2.HasRows)
				{
					continue;
				}
				sqlConnection3.Close();
				using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection4.Open();
				using (SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection4,
					CommandText = "INSERT INTO OLevelGradingScale_TH (Category_En,Category_Ar,Debut_En,End_En,Points_En,Debut_Ar,End_Ar,Points_Ar,Com_En,Com2_En,Com3_En,Com_Ar,Com2_Ar,Com3_Ar,ClassLevel) VALUES (@Category_En, @Category_Ar, @Debut_En, @End_En, @Points_En, @Debut_Ar, @End_Ar, @Points_Ar,@Com_En,@Com2_En,@Com3_En,@Com_Ar,@Com2_Ar,@Com3_Ar,@ClassLevel)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@Category_En", SqlDbType.VarChar, 10);
					sqlParameter2.Value = list15[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Debut_En", SqlDbType.Float);
					sqlParameter2.Value = list16[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@End_En", SqlDbType.Float);
					sqlParameter2.Value = list17[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Points_En", SqlDbType.Int);
					sqlParameter2.Value = list18[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Com_En", SqlDbType.VarChar, 80);
					sqlParameter2.Value = list19[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Com2_En", SqlDbType.VarChar, 80);
					sqlParameter2.Value = list20[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Com3_En", SqlDbType.VarChar, 80);
					sqlParameter2.Value = list21[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Category_Ar", SqlDbType.NVarChar, 10);
					sqlParameter2.Value = list22[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Debut_Ar", SqlDbType.NVarChar, 4);
					sqlParameter2.Value = list23[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@End_Ar", SqlDbType.NVarChar, 4);
					sqlParameter2.Value = list24[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Points_Ar", SqlDbType.NVarChar, 1);
					sqlParameter2.Value = list25[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Com_Ar", SqlDbType.NVarChar, 80);
					sqlParameter2.Value = list26[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Com2_Ar", SqlDbType.NVarChar, 80);
					sqlParameter2.Value = list27[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@Com3_Ar", SqlDbType.NVarChar, 80);
					sqlParameter2.Value = list28[j];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 20);
					sqlParameter2.Value = ClassLevel;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand4.ExecuteNonQuery();
				}
				sqlConnection4.Close();
			}
		}
		catch
		{
			throw;
		}
	}

	public static void InitializeTheologyGradingScale(string ClassLevel)
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[5] { "FIRST GRADE", "SECOND GRADE", "THIRD GRADE", "FORTH GRADE", "FAIL" });
			List<double> list2 = new List<double>();
			list2.AddRange(new double[5] { 4.0, 13.0, 25.0, 29.0, 33.0 });
			List<double> list3 = new List<double>();
			list3.AddRange(new double[5] { 12.0, 24.0, 28.0, 32.0, 36.0 });
			List<string> list4 = new List<string>();
			list4.AddRange(new string[5] { "FIRST GRADE", "SECOND GRADE", "THIRD GRADE", "FORTH GRADE", "FAIL" });
			List<double> list5 = new List<double>();
			list5.AddRange(new double[5] { 80.0, 70.0, 60.0, 50.0, 0.0 });
			List<double> list6 = new List<double>();
			list6.AddRange(new double[5] { 100.0, 79.9, 69.9, 59.9, 49.9 });
			List<string> list7 = new List<string>();
			list7.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list8 = new List<string>();
			list8.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list9 = new List<string>();
			list9.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list10 = new List<string>();
			list10.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list11 = new List<string>();
			list11.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list12 = new List<string>();
			list12.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list13 = new List<string>();
			list13.AddRange(new string[5] { "ممتاز", "جيدجدا", "جيد", "مقبول", "راسب" });
			List<string> list14 = new List<string>();
			list14.AddRange(new string[5] { "٤", "١٣", "٢٥", "٢٩", "٣٣" });
			List<string> list15 = new List<string>();
			list15.AddRange(new string[5] { "١٢", "٢٤", "٢٨", "٣٢", "٣٦" });
			List<string> list16 = new List<string>();
			list16.AddRange(new string[5] { "ممتاز", "جيدجدا", "جيد", "مقبول", "راسب" });
			List<string> list17 = new List<string>();
			list17.AddRange(new string[5] { "٨٠", "٧٠", "٦٠", "٥٠", "٠" });
			List<string> list18 = new List<string>();
			list18.AddRange(new string[5] { "١٠٠", "٧٩.٩", "٦٩.٩", "٥٩.٩", "٤٩.٩" });
			List<string> list19 = new List<string>();
			list19.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list20 = new List<string>();
			list20.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list21 = new List<string>();
			list21.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list22 = new List<string>();
			list22.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list23 = new List<string>();
			list23.AddRange(new string[5] { "", "", "", "", "" });
			List<string> list24 = new List<string>();
			list24.AddRange(new string[5] { "", "", "", "", "" });
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				text = ((!(ClassLevel == "Shuuba")) ? $"SELECT * FROM OLevelDivisionScale_TH WHERE Grade_En='{list4[i]}' AND ClassLevel='{ClassLevel}'" : $"SELECT * FROM OLevelDivisionScale_TH WHERE Grade_En='{list[i]}' AND ClassLevel='{ClassLevel}'");
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = text,
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				sqlConnection.Close();
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO dbo.OLevelDivisionScale_TH (Grade_En, Debut_En, End_En, Grade_Ar, Debut_Ar, End_Ar, ClassTeacherComment_En, ClassTeacherComment1_En, ClassTeacherComment2_En, DOSComment_En, DOSComment1_En , DOSComment2_En, ClassTeacherComment_Ar, ClassTeacherComment1_Ar, ClassTeacherComment2_Ar, DOSComment_Ar, DOSComment1_Ar, DOSComment2_Ar, ClassLevel) VALUES (@Grade_En, @Debut_En, @End_En, @Grade_Ar, @Debut_Ar, @End_Ar, @ClassTeacherComment_En, @ClassTeacherComment1_En, @ClassTeacherComment2_En, @DOSComment_En, @DOSComment1_En , @DOSComment2_En, @ClassTeacherComment_Ar, @ClassTeacherComment1_Ar, @ClassTeacherComment2_Ar, @DOSComment_Ar, @DOSComment1_Ar, @DOSComment2_Ar, @ClassLevel)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter;
					if (ClassLevel == "Shuuba")
					{
						sqlParameter = sqlCommand2.Parameters.Add("@Grade_En", SqlDbType.VarChar, 50);
						sqlParameter.Value = list[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Debut_En", SqlDbType.Float);
						sqlParameter.Value = list2[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@End_En", SqlDbType.Float);
						sqlParameter.Value = list3[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Grade_Ar", SqlDbType.NVarChar, 50);
						sqlParameter.Value = list13[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Debut_Ar", SqlDbType.NVarChar, 5);
						sqlParameter.Value = list14[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@End_Ar", SqlDbType.NVarChar, 5);
						sqlParameter.Value = list15[i];
						sqlParameter.Direction = ParameterDirection.Input;
					}
					else
					{
						sqlParameter = sqlCommand2.Parameters.Add("@Grade_En", SqlDbType.VarChar, 50);
						sqlParameter.Value = list4[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Debut_En", SqlDbType.Float);
						sqlParameter.Value = list5[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@End_En", SqlDbType.Float);
						sqlParameter.Value = list6[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Grade_Ar", SqlDbType.NVarChar, 50);
						sqlParameter.Value = list16[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@Debut_Ar", SqlDbType.NVarChar, 5);
						sqlParameter.Value = list17[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@End_Ar", SqlDbType.NVarChar, 5);
						sqlParameter.Value = list18[i];
						sqlParameter.Direction = ParameterDirection.Input;
					}
					sqlParameter = sqlCommand2.Parameters.Add("@ClassTeacherComment_En", SqlDbType.VarChar, 80);
					sqlParameter.Value = list7[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassTeacherComment1_En", SqlDbType.VarChar, 80);
					sqlParameter.Value = list8[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassTeacherComment2_En", SqlDbType.VarChar, 80);
					sqlParameter.Value = list9[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@DOSComment_En", SqlDbType.VarChar, 80);
					sqlParameter.Value = list10[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@DOSComment1_En", SqlDbType.VarChar, 80);
					sqlParameter.Value = list11[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@DOSComment2_En", SqlDbType.VarChar, 80);
					sqlParameter.Value = list12[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassTeacherComment_Ar", SqlDbType.NVarChar, 80);
					sqlParameter.Value = list19[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassTeacherComment1_Ar", SqlDbType.NVarChar, 80);
					sqlParameter.Value = list20[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassTeacherComment2_Ar", SqlDbType.NVarChar, 80);
					sqlParameter.Value = list21[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@DOSComment_Ar", SqlDbType.NVarChar, 80);
					sqlParameter.Value = list22[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@DOSComment1_Ar", SqlDbType.NVarChar, 80);
					sqlParameter.Value = list23[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@DOSComment2_Ar", SqlDbType.NVarChar, 80);
					sqlParameter.Value = list24[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 20);
					sqlParameter.Value = ClassLevel;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch
		{
			throw;
		}
	}
}
