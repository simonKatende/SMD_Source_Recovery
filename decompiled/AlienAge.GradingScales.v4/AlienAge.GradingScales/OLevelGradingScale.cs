using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;

namespace AlienAge.GradingScales;

[Serializable]
public sealed class OLevelGradingScale
{
	private static readonly Lazy<OLevelGradingScale> _instance = new Lazy<OLevelGradingScale>(() => new OLevelGradingScale());

	private readonly string connectionString;

	public static OLevelGradingScale Instance => _instance.Value;

	public DataTable SubjectGradingScale
	{
		get
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelGradingScale", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelGradingScale");
			return dataSet.Tables[0];
		}
	}

	public DataTable OLevelAutoCommentsNC
	{
		get
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNC", selectConnection);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelAutoCommentsNC");
			return dataSet.Tables[0];
		}
	}

	public DataTable EndOfYearScale
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelAutoCommentsNC", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "EOYReport");
			return dataSet.Tables[0];
		}
	}

	public DataTable DivisionScale
	{
		get
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelDivisionScale", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OLevelDivisionScale");
			return dataSet.Tables[0];
		}
	}

	public string LandScapeReportFooter
	{
		get
		{
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			StringBuilder stringBuilder = new StringBuilder("Grading Scale: ");
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM OLevelGradingScale", sqlConnection))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "LandscapeFooter");
				DataTable dataTable = dataSet.Tables[0];
				foreach (DataRow row in dataTable.Rows)
				{
					stringBuilder.Append(string.Format("{0}({1}-{2})  ", row["Category"], row["Debut"], row["End"]));
				}
			}
			return stringBuilder.ToString();
		}
	}

	private OLevelGradingScale()
	{
		connectionString = DataConnection.ConnectToDatabase();
	}

	public void InitializeSubjectGradingScale()
	{
		try
		{
			List<string> list = new List<string> { "D1", "D2", "C3", "C4", "C5", "C6", "P7", "P8", "F9" };
			List<float> list2 = new List<float> { 75f, 70f, 65f, 60f, 55f, 50f, 45f, 40f, 0f };
			List<float> list3 = new List<float> { 100f, 74f, 69f, 64f, 59f, 54f, 49f, 44f, 39f };
			List<int> list4 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			List<string> list5 = new List<string> { "Very good performance. Keep it up.", "Please don't feel so confortable.", "Aim at excellence next term.", "You need to consult a lot to improve", "Seriously revision is required please.", "Can do better with more effort.", "Below average, concentrate more.", "This is a bad edge to be. Work harder.", "Please! You can do better than this." };
			List<string> list6 = new List<string> { "Please maintain this performance.", "Make it to the next grade please.", "Aim for distinctions next term.", "Please. Revise seriously.", "Fair results, dont relax.", "Much has to be done.", "More concentration is needed.", "You're one step away from F9!", "More effort is eagerly needed" };
			List<string> list7 = new List<string> { "Excellent work. Keep it up.", "Promising results. Keep it up.", "Promising results, do't relax", "Don't relax, you can make it", "Aim higher than this.", "Should intensify reading books.", "Just below average", "More effort will raise you.", "Please, revise harder." };
			List<string> list8 = new List<string> { "I believe you can do more than  this.", "Thank you, but aim for D1.", "Encouraging results, keep it up", "Very good work", "This is promising. Keep it up.", "Hard work will pay you off.", "settle and read books.", "Please, consider higher grades.", "Invest more time in revision." };
			List<string> list9 = new List<string> { "Thank you, but keep it up.", "Thank you, but aim higher", "A Little more effort is needed.", "Very promising performance", "Good. Promising student.", "You can do better", "Focus more on challenging areas.", "Much more effort is needed.", "Consult the teacher more often." };
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			for (int i = 0; i < 9; i++)
			{
				using SqlCommand sqlCommand = new SqlCommand("SELECT * FROM OLevelGradingScale WHERE Category='" + list[i] + "'", sqlConnection);
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					using SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO OLevelGradingScale (Category,Debut,[End],Points,Comment,Comment2,Comment3,Comment4,Comment5) VALUES (@Category,@Debut,@End,@Points,@Comment,@Comment2,@Comment3,@Comment4,@Comment5)", sqlConnection);
					sqlCommand2.Parameters.AddWithValue("@Category", list[i]);
					sqlCommand2.Parameters.AddWithValue("@Debut", list2[i]);
					sqlCommand2.Parameters.AddWithValue("@End", list3[i]);
					sqlCommand2.Parameters.AddWithValue("@Points", list4[i]);
					sqlCommand2.Parameters.AddWithValue("@Comment", list5[i]);
					sqlCommand2.Parameters.AddWithValue("@Comment2", list6[i]);
					sqlCommand2.Parameters.AddWithValue("@Comment3", list7[i]);
					sqlCommand2.Parameters.AddWithValue("@Comment4", list8[i]);
					sqlCommand2.Parameters.AddWithValue("@Comment5", list9[i]);
					sqlCommand2.ExecuteNonQuery();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public void InitializeNewCurriculumGrades()
	{
		List<string> list = new List<string> { "2.40", "2.10", "1.50", "1.00", "0.00" };
		List<string> list2 = new List<string> { "3.00", "2.39", "2.09", "1.49", "0.99" };
		List<string> list3 = new List<string> { "80", "70", "50", "35", "0" };
		List<string> list4 = new List<string> { "100", "79", "69", "49", "34" };
		List<string> list5 = new List<string> { "A", "B", "C", "D", "E" };
		List<string> list6 = new List<string> { "Exceptional", "Outstanding", "Satisfactory", "Basic", "Elementary" };
		List<string> list7 = new List<string> { "Good Performance, Keep it Up", "Good Performance But Aim Higher than this", "Please Don't Relax, this not so Pleasing", "Put More Efforts and Always Consult your Teachers", "This Results is not very Encouraging. More Efforts Required" };
		List<string> list8 = new List<string> { "Good Performance, Keep it Up", "Good Performance But Aim Higher than this", "Please Don't Relax, this not so Pleasing", "Put More Efforts and Always Consult your Teachers", "This Results is not very Encouraging. More Efforts Required" };
		List<string> list9 = new List<string> { "Good Performance, Keep it Up", "Good Performance But Aim Higher than this", "Please Don't Relax, this not so Pleasing", "Put More Efforts and Always Consult your Teachers", "This Results is not very Encouraging. More Efforts Required" };
		List<string> list10 = new List<string> { "Good Performance, Keep it Up", "Good Performance But Aim Higher than this", "Please Don't Relax, this not so Pleasing", "Put More Efforts and Always Consult your Teachers", "This Results is not very Encouraging. More Efforts Required" };
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using SqlCommand selectCommand = new SqlCommand("SELECT Id FROM OLevelAutoCommentsNC", sqlConnection);
		DataTable dataTable = new DataTable();
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
		{
			sqlDataAdapter.Fill(dataTable);
		}
		if (dataTable.Rows.Count > 5)
		{
			using SqlCommand sqlCommand = new SqlCommand("DELETE FROM OLevelAutoCommentsNC", sqlConnection);
			sqlCommand.ExecuteNonQuery();
		}
		for (int i = 0; i < list.Count; i++)
		{
			using SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM OLevelAutoCommentsNC WHERE D3=@D3 AND E3=@E3 AND D100=@D100 AND E100=@E100", sqlConnection);
			sqlCommand2.Parameters.AddWithValue("@D3", list[i]);
			sqlCommand2.Parameters.AddWithValue("@E3", list2[i]);
			sqlCommand2.Parameters.AddWithValue("@D100", list3[i]);
			sqlCommand2.Parameters.AddWithValue("@E100", list4[i]);
			using SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				using SqlCommand sqlCommand3 = new SqlCommand("INSERT INTO OLevelAutoCommentsNC (D3,E3,D100,E100,Point,Grade,Descriptor,Comment1,Comment2,Comment3,Comment4) VALUES (@D3,@E3,@D100,@E100,@Point,@Grade,@Descriptor,@Comment1,@Comment2,@Comment3,@Comment4)", sqlConnection);
				sqlCommand3.Parameters.AddWithValue("@D3", list[i]);
				sqlCommand3.Parameters.AddWithValue("@E3", list2[i]);
				sqlCommand3.Parameters.AddWithValue("@D100", list3[i]);
				sqlCommand3.Parameters.AddWithValue("@E100", list4[i]);
				sqlCommand3.Parameters.AddWithValue("@Point", i + 1);
				sqlCommand3.Parameters.AddWithValue("@Grade", list5[i]);
				sqlCommand3.Parameters.AddWithValue("@Descriptor", list6[i]);
				sqlCommand3.Parameters.AddWithValue("@Comment1", list7[i]);
				sqlCommand3.Parameters.AddWithValue("@Comment2", list8[i]);
				sqlCommand3.Parameters.AddWithValue("@Comment3", list9[i]);
				sqlCommand3.Parameters.AddWithValue("@Comment4", list10[i]);
				sqlCommand3.ExecuteNonQuery();
			}
		}
	}

	public void InitializeDivisionScale()
	{
		try
		{
			List<string> list = new List<string> { "I", "II", "III", "IV", "IX" };
			List<float> list2 = new List<float> { 8f, 33f, 46f, 59f, 70f };
			List<float> list3 = new List<float> { 32f, 45f, 58f, 69f, 72f };
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM OLevelDivisionScale", sqlConnection))
			{
				sqlCommand.ExecuteNonQuery();
			}
			for (int i = 0; i < 5; i++)
			{
				using SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM OLevelDivisionScale WHERE Grade='" + list[i] + "'", sqlConnection);
				using SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					using SqlCommand sqlCommand3 = new SqlCommand("INSERT INTO OLevelDivisionScale (Grade,Debut,EndMark) VALUES (@Grade,@Debut,@EndMark)", sqlConnection);
					sqlCommand3.Parameters.AddWithValue("@Grade", list[i]);
					sqlCommand3.Parameters.AddWithValue("@Debut", list2[i]);
					sqlCommand3.Parameters.AddWithValue("@EndMark", list3[i]);
					sqlCommand3.ExecuteNonQuery();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public KeyValuePair<string, string> GetGradingScale(double ScoreOutOf3)
	{
		DataTable oLevelAutoCommentsNC = OLevelAutoCommentsNC;
		foreach (DataRow row in oLevelAutoCommentsNC.Rows)
		{
			double result;
			double num = (double.TryParse(row["D3"].ToString(), out result) ? result : 0.0);
			double result2;
			double num2 = (double.TryParse(row["E3"].ToString(), out result2) ? result2 : 0.0);
			if (ScoreOutOf3 >= num && ScoreOutOf3 <= num2)
			{
				return new KeyValuePair<string, string>(row["Grade"].ToString(), row["Descriptor"].ToString());
			}
		}
		return new KeyValuePair<string, string>("", "");
	}

	public string GetAutomaticSubjectComment(float LOA, bool useSmallScale = true)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string text = (useSmallScale ? "D3" : "D100");
		string text2 = (useSmallScale ? "E3" : "E100");
		string selectCommandText = $"SELECT * FROM OLevelAutoCommentsNC WHERE {LOA} >= {text} AND {LOA} <= {text2}";
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection))
		{
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				Random random = new Random();
				string columnName = "Comment" + (double)(int)(random.NextDouble() * 4.0 + 1.0);
				return dataTable.Rows[0][columnName].ToString();
			}
		}
		return "";
	}

	public string[] GetAutomaticFooterComment(float LOA, bool useSmallScale = true)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string[] array = new string[2];
		string text = (useSmallScale ? "D3" : "D100");
		string text2 = (useSmallScale ? "E3" : "E100");
		string selectCommandText = $"SELECT * FROM OLevelAutoCommentsNC WHERE {LOA} >= {text} AND {LOA} <= {text2}";
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection))
		{
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				Random random = new Random();
				double num = (int)(random.NextDouble() * 4.0 + 1.0);
				string columnName = "Headteacher" + num;
				string columnName2 = "Classteacher" + num;
				array[0] = dataTable.Rows[0][columnName].ToString();
				array[1] = dataTable.Rows[0][columnName2].ToString();
			}
		}
		return array;
	}

	public string[] GetFooterComments(string StudentNo, string _Class, string Term)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		string[] array = new string[5];
		string selectCommandText = "SELECT Project,ProjectTitle,ClassteacherRemark,HeadteacherRemark,GenericSkills,StudentNumber FROM tbl_Scores_OL_Report WHERE StudentNumber='" + StudentNo + "' AND ClassId='" + _Class + "' AND SemesterId='" + Term + "' GROUP BY Project,ProjectTitle,ClassteacherRemark,HeadteacherRemark,GenericSkills,StudentNumber";
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection))
		{
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			if (dataTable.Rows.Count > 0)
			{
				array[0] = dataTable.Rows[0]["Project"].ToString();
				array[1] = dataTable.Rows[0]["ProjectTitle"].ToString();
				array[2] = dataTable.Rows[0]["ClassteacherRemark"].ToString();
				array[3] = dataTable.Rows[0]["HeadteacherRemark"].ToString();
				array[4] = dataTable.Rows[0]["GenericSkills"].ToString();
			}
		}
		return array;
	}
}
