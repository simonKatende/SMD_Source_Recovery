using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AlienAge.Connectivity;

namespace I_Xtreme;

[Serializable]
public class Subjects
{
	private static string[] subjects = new string[38]
	{
		"456-Mathematics", "112-English", "535-Physics", "545-Chemistry", "553-Biology", "208-Literature", "223-CRE", "225-IRE", "301-Latin", "305-Leb Acoli",
		"309-German", "314-French", "315-Leblango", "325-Lugbarati", "335-Luganda", "336-Kiswahili", "337-Arabic", "345-Runyakitara", "355-Lusoga", "365-Ateso",
		"375-Dhopadhola", "385-Runyoro-Rutooro", "395-Lumasaaba", "396-Chinese", "397-Ugandan Sign Langu", "500-General Science", "527-Agriculture", "555-PE", "612-Art & Design", "621-Performing Arts",
		"662-Nutrition & Food Tech.", "745-Technology & Design", "840-ICT", "845-Entrepreneurship", "241-History & Pol. Educ.", "273-Geography", "982-Vegetable Farming", "983-Rabbit Rearing"
	};

	public static DataTable OLevelSubjectsData
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ShortCode", typeof(string));
			dataTable.Columns.Add("Subject", typeof(string));
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "325-Lugbarati", "Lb" },
				{ "355-Lusoga", "Ls" },
				{ "309-Germany", "Gr" },
				{ "662-Nutrition & Food Tech.", "NF" },
				{ "845-Entrepreneurship", "Ep" },
				{ "305-Leb Acoli", "Al" },
				{ "395-Lumasaaba", "Lm" },
				{ "612-Art & Design", "AD" },
				{ "982-Vegetable Farming", "VF" },
				{ "983-Rabbit Rearing", "RR" },
				{ "500-General Science", "GS" },
				{ "555-PE", "PE" }
			};
			string[] array = subjects;
			foreach (string text in array)
			{
				string text2;
				if (dictionary.TryGetValue(text, out var value))
				{
					text2 = value;
				}
				else
				{
					string text3 = text.Substring(text.IndexOf('-') + 1);
					text2 = ((!text3.Contains(" ")) ? ((text3.Length >= 2) ? text3.Substring(0, 2).ToUpper() : text3.ToUpper()) : string.Concat(from word in text3.Split(' ')
						where word.Length > 0
						select char.ToUpper(word[0])));
					text2 = ((text2.Length >= 2) ? text2.Substring(0, 2) : text2.PadRight(2, 'X'));
				}
				dataTable.Rows.Add(text2, text);
			}
			return dataTable;
		}
	}

	public static DataTable ALevelSubjectsData
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Category", typeof(string));
			dataTable.Columns.Add("ShortCode", typeof(string));
			dataTable.Columns.Add("Subject", typeof(string));
			string[] array = new string[30]
			{
				"Mathematics", "Physics", "Chemistry", "Biology", "Fine Art", "Agriculture", "Luganda", "Kiswahili", "French", "Germany",
				"Tech. Drawing", "Foods & Nutrition", "Geography", "History", "Divinity", "Islam", "Economics", "Sub Math", "General Paper", "Arabic",
				"English Lit.", "Entrepreneurship", "ICT", "Clothing & Textile", "Music", "Lusoga", "LEB Lango", "LEB Acoli", "Lumusaaba", "Runyoro"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				if (array[i] == "Clothing & Textile")
				{
					empty = "CT";
					empty2 = "1 Group";
				}
				else if (array[i] == "English Lit.")
				{
					empty = "Li";
					empty2 = "1 Group";
				}
				else if (array[i] == "LEB Lango")
				{
					empty = "LL";
					empty2 = "1 Group";
				}
				else if (array[i] == "LEB Acoli")
				{
					empty = "LA";
					empty2 = "1 Group";
				}
				else if (array[i] == "Foods & Nutrition")
				{
					empty = "FN";
					empty2 = "1 Group";
				}
				else if (array[i] == "General Paper")
				{
					empty = "GP";
					empty2 = "3 Group";
				}
				else if (array[i] == "Germany")
				{
					empty = "Gr";
					empty2 = "1 Group";
				}
				else if (array[i] == "ICT")
				{
					empty = "IT";
					empty2 = "2 Group";
				}
				else if (array[i] == "Lumusaaba")
				{
					empty = "LM";
					empty2 = "2 Group";
				}
				else if (array[i] == "Sub Math")
				{
					empty = "SM";
					empty2 = "2 Group";
				}
				else if (array[i] == "Tech. Drawing")
				{
					empty = "TD";
					empty2 = "1 Group";
				}
				else if (array[i] == "Lusoga")
				{
					empty = "Ls";
					empty2 = "1 Group";
				}
				else
				{
					empty = array[i].Substring(0, 2);
					empty2 = "1 Group";
				}
				dataTable.Rows.Add(empty2, empty, array[i]);
			}
			return dataTable;
		}
	}

	public static DataTable PrimarySubjectsData
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ShortCode", typeof(string));
			dataTable.Columns.Add("Subject", typeof(string));
			string[] array = new string[40]
			{
				"English", "Mathematics", "Science", "Social Studies", "Art", "Agriculture", "Luganda", "Lugbarati", "Lusoga", "Runyankore",
				"Lango", "Acoli", "Kiswahili", "French", "Germany", "Chinese", "Rutooro", "Computer", "Oral English", "Alphabet",
				"Drawing", "Literacy-1", "Literacy-2", "RE", "Music & Dance", "IRE", "CRE", "Reading", "Physical Education", "Life Skills",
				"Social & Emotional Dev.", "Physical Development", "Personal Hygiene", "General World Knowledge", "Numeracy", "Langauge Development I", "Langauge Development II", "Mathematical Concepts", "Health Habits", "Social Development"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string empty = string.Empty;
				empty = ((!(array[i] == "Social Studies")) ? ((!(array[i] == "Oral English")) ? ((!(array[i] == "Literacy-1")) ? ((!(array[i] == "Literacy-2")) ? ((!(array[i] == "Physical Educaction")) ? ((!(array[i] == "Life Skills")) ? ((!(array[i] == "Lugbarati")) ? array[i].Substring(0, 2) : "Lg") : "LS") : "PE") : "L2") : "L1") : "OE") : "SS");
				dataTable.Rows.Add(empty, array[i]);
			}
			return dataTable;
		}
	}

	public static List<string> ALevelPapers(string Subject)
	{
		List<string> list = new List<string>();
		switch (Subject)
		{
		case "Chemistry":
			list.AddRange(new string[4] { "P525/1", "P525/2", "P525/3", "P525/4" });
			break;
		case "Biology":
			list.AddRange(new string[3] { "P530/1", "P530/2", "P530/3" });
			break;
		case "Entrepreneurship":
			list.AddRange(new string[3] { "P230/1", "P230/2", "P230/3" });
			break;
		case "Economics":
			list.AddRange(new string[2] { "P220/1", "P220/2" });
			break;
		case "General Paper":
			list.AddRange(new string[1] { "S101/1" });
			break;
		case "Agriculture":
			list.AddRange(new string[3] { "P515/1", "P515/2", "P515/3" });
			break;
		case "Geography":
			list.AddRange(new string[3] { "P250/1", "P250/2", "P250/3" });
			break;
		case "Physics":
			list.AddRange(new string[3] { "P510/1", "P510/2", "P510/3" });
			break;
		case "Mathematics":
			list.AddRange(new string[3] { "P425/1", "P425/2", "P425/3" });
			break;
		case "Foods & Nutrition":
			list.AddRange(new string[3] { "P640/1", "P640/2", "P640/3" });
			break;
		case "Sub Math":
			list.AddRange(new string[1] { "S475/1" });
			break;
		case "ICT":
			list.AddRange(new string[3] { "S850/1", "S850/2", "S850/3" });
			break;
		case "Fine Art":
			list.AddRange(new string[6] { "P615/1", "P615/2", "P615/3", "P615/4", "P615/5", "P615/6" });
			break;
		case "English Lit.":
			list.AddRange(new string[3] { "P310/1", "P310/2", "P310/3" });
			break;
		case "Kiswahili":
			list.AddRange(new string[4] { "P320/1", "P320/2", "P320/3", "P320/4" });
			break;
		case "History":
			list.AddRange(new string[6] { "P210/1", "P210/2", "P210/3", "P210/4", "P210/5", "P210/6" });
			break;
		case "Divinity":
			list.AddRange(new string[4] { "P245/1", "P245/2", "P245/3", "P245/4" });
			break;
		case "Islam":
			list.AddRange(new string[4] { "P235/1", "P235/2", "P235/3", "P235/4" });
			break;
		case "Luganda":
			list.AddRange(new string[3] { "P360/1", "P360/2", "P360/3" });
			break;
		case "French":
			list.AddRange(new string[4] { "P330/1", "P330/2", "P330/3", "P330/4" });
			break;
		case "Germany":
			list.AddRange(new string[4] { "P1", "P2", "P3", "P4" });
			break;
		case "Arabic":
			list.AddRange(new string[4] { "P1", "P2", "P3", "P4" });
			break;
		case "Tech. Drawing":
			list.AddRange(new string[4] { "P1", "P2", "P3", "P4" });
			break;
		case "Clothing & Textile":
			list.AddRange(new string[3] { "P630/1", "P630/2", "P630/3" });
			break;
		case "Music":
			list.AddRange(new string[3] { "P620/1", "P620/2", "P620/3" });
			break;
		case "Lusoga":
			list.AddRange(new string[3] { "P366/1", "P366/2", "P366/3" });
			break;
		case "LEB Lango":
			list.AddRange(new string[3] { "P362/1", "P362/2", "P362/3" });
			break;
		case "LEB Acoli":
			list.AddRange(new string[3] { "P361/1", "P361/2", "P361/3" });
			break;
		case "Lumusaaba":
			list.AddRange(new string[3] { "P371/1", "P371/2", "P371/3" });
			break;
		case "Runyoro":
			list.AddRange(new string[3] { "P369/1", "P369/2", "P369/3" });
			break;
		}
		return list;
	}

	public static string[] GetSubjectsFromCombinations(string Combination)
	{
		string text = Combination.Replace("/", "");
		return new string[5]
		{
			text.Substring(0, 2),
			text.Substring(2, 2),
			text.Substring(4, 2),
			text.Substring(6, 2),
			text.Substring(8, 2)
		};
	}

	public static void UpdateAllSubjectsRegistered()
	{
		string connectionString = DataConnection.ConnectToDatabase();
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
			try
			{
				string[] array = subjects;
				foreach (string text in array)
				{
					string[] array2 = text.Split(new char[1] { '-' }, 2);
					if (array2.Length == 2)
					{
						string text2 = array2[0];
						string text3 = array2[1];
						string cmdText = "\r\n                                UPDATE tbl_Scores_OL_Report \r\n                                SET SubjectId = @NewSubjectId \r\n                                WHERE SubjectId LIKE @CodePattern";
						using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction);
						sqlCommand.Parameters.AddWithValue("@NewSubjectId", text);
						sqlCommand.Parameters.AddWithValue("@CodePattern", text2 + "%");
						int num = sqlCommand.ExecuteNonQuery();
						Console.WriteLine($"Updated {num} rows for {text}");
					}
				}
				sqlTransaction.Commit();
				Console.WriteLine("All updates completed successfully!");
			}
			catch (Exception ex)
			{
				sqlTransaction.Rollback();
				Console.WriteLine("Error: " + ex.Message);
				Console.WriteLine("All changes were rolled back.");
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine("Database connection error: " + ex2.Message);
		}
	}
}
