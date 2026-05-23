using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.Connectivity;

namespace MarksEntry;

[Serializable]
internal class ImportScoresFromExcel
{
	private static string excelfileName { get; set; }

	public static string ExcelFilePath
	{
		get
		{
			return excelfileName;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ExcelSourceScores.bin");
			ImportScoresFromExcel importScoresFromExcel = new ImportScoresFromExcel();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			importScoresFromExcel = (ImportScoresFromExcel)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			excelfileName = ExcelFilePath;
		}
	}

	public static void SaveExcelPath(string excelFilePath)
	{
		ImportScoresFromExcel graph = new ImportScoresFromExcel();
		excelfileName = excelFilePath;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_ExcelSourceScores.bin");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	protected static string valid(OleDbDataReader myreader, int stval)
	{
		object obj = myreader[stval];
		if (obj != DBNull.Value)
		{
			return obj.ToString();
		}
		return "-";
	}

	private static void UpdateSql(string studentNo, string classId, string SemesterId, string SubjectId, string hop, string bot, string mot, string eot)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		string commandText = string.Empty;
		switch (classId)
		{
		case "S.1":
			commandText = $"UPDATE tbl_Scores_1 SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,Initial=@Initial WHERE StudentNumber='{studentNo}' AND SemesterId='{SemesterId}' AND SubjectId='{SubjectId}'";
			break;
		case "S.2":
			commandText = $"UPDATE tbl_Scores_2 SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,Initial=@Initial WHERE StudentNumber='{studentNo}' AND SemesterId='{SemesterId}' AND SubjectId='{SubjectId}'";
			break;
		case "S.3":
			commandText = $"UPDATE tbl_Scores_3 SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,Initial=@Initial WHERE StudentNumber='{studentNo}' AND SemesterId='{SemesterId}' AND SubjectId='{SubjectId}'";
			break;
		case "S.4":
			commandText = $"UPDATE tbl_Scores_4 SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,Initial=@Initial WHERE StudentNumber='{studentNo}' AND SemesterId='{SemesterId}' AND SubjectId='{SubjectId}'";
			break;
		case "S.5":
			commandText = $"UPDATE tbl_Scores_5 SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,Initial=@Initial WHERE StudentNumber='{studentNo}' AND SemesterId='{SemesterId}' AND SubjectId='{SubjectId}'";
			break;
		case "S.6":
			commandText = $"UPDATE tbl_Scores_6 SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,Initial=@Initial WHERE StudentNumber='{studentNo}' AND SemesterId='{SemesterId}' AND SubjectId='{SubjectId}'";
			break;
		}
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = commandText,
			CommandType = CommandType.Text
		})
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			double result = (double.TryParse(hop, out result) ? result : (-1.0));
			double result2 = (double.TryParse(bot, out result2) ? result2 : (-1.0));
			double result3 = (double.TryParse(mot, out result3) ? result3 : (-1.0));
			double result4 = (double.TryParse(eot, out result4) ? result4 : (-1.0));
			empty = ((!(hop == "-") && (!(result > 0.0) || !(result < 100.0))) ? "-" : hop);
			empty2 = ((!(bot == "-") && (!(result2 > 0.0) || !(result2 < 100.0))) ? "-" : bot);
			empty3 = ((!(mot == "-") && (!(result3 > 0.0) || !(result3 < 100.0))) ? "-" : mot);
			empty4 = ((!(eot == "-") && (!(result4 > 0.0) || !(result4 < 100.0))) ? "-" : eot);
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@HoP", SqlDbType.VarChar, 5);
			sqlParameter.Value = empty;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BOT", SqlDbType.VarChar, 5);
			sqlParameter.Value = empty2;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@MOT", SqlDbType.VarChar, 5);
			sqlParameter.Value = empty3;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@EOT", SqlDbType.VarChar, 5);
			sqlParameter.Value = empty4;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Initial", SqlDbType.VarChar, 3);
			sqlParameter.Value = TeacherInitials.GetTeacherInitials();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	public static void GetScoresFromExcel(string classId, string semesterId, string subjectId)
	{
		try
		{
			string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={ExcelFilePath};Extended Properties=Excel 8.0";
			using OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
			OleDbCommand oleDbCommand = new OleDbCommand("select * from [ScoreSheet$]", oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			while (oleDbDataReader.Read())
			{
				empty = valid(oleDbDataReader, 0);
				empty2 = valid(oleDbDataReader, 4);
				empty3 = valid(oleDbDataReader, 5);
				empty4 = valid(oleDbDataReader, 6);
				empty5 = valid(oleDbDataReader, 7);
				UpdateSql(empty, classId, semesterId, subjectId, empty2, empty3, empty4, empty5);
			}
			oleDbConnection.Close();
		}
		catch (DataException ex)
		{
			throw ex;
		}
	}
}
