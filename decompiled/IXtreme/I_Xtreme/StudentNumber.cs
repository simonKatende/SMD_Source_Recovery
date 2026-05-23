using System;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using AlienAge.Security;

namespace I_Xtreme;

internal class StudentNumber
{
	private static string CurrentYear => DateTime.Now.ToString("yy-");

	private static string IDNumberPrefix()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM SchoolDetails", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		return dataSet.Tables[0].Rows[0]["T_T"].ToString();
	}

	public static string[] GetNextStudentNumber()
	{
		string[] array = new string[2] { "", "" };
		string schoolCode = SerialNumber.GetSchoolCode(DataConnection.ConnectToDatabase());
		string empty = string.Empty;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT COUNT(StudentNumber) AS CountOfNumbers FROM tbl_Stud", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		int num = Convert.ToInt32(dataTable.Rows[0]["CountOfNumbers"].ToString());
		int length = num.ToString().Length;
		string text;
		do
		{
			num++;
			empty = length switch
			{
				1 => "0000" + num, 
				2 => "000" + num, 
				3 => "00" + num, 
				4 => "0" + num, 
				5 => num.ToString(), 
				_ => "1000", 
			};
			text = empty.Substring(empty.Length - 5, 5);
		}
		while (StudentNumberExists(schoolCode + text));
		array[0] = schoolCode + text;
		array[1] = IDNumberPrefix() + DateTime.Now.ToString("yy") + "-" + text;
		return array;
	}

	public static bool StudentIDExists(string StudentID)
	{
		bool result = false;
		using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"Select StudentID FROM tbl_Stud WHERE StudentID='{StudentID}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				result = true;
			}
			sqlConnection.Close();
		}
		return result;
	}

	public static bool StudentNumberExists(string StudentNo)
	{
		string connectionString = DataConnection.ConnectToDatabase();
		using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"Select StudentNumber FROM tbl_Stud WHERE StudentNumber='{StudentNo}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				return true;
			}
		}
		using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
		{
			sqlConnection2.Open();
			SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = $"Select StudentNumber FROM tbl_suspendedStudents WHERE StudentNumber='{StudentNo}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
			if (sqlDataReader2.HasRows)
			{
				sqlDataReader2.Close();
				sqlConnection2.Close();
				return true;
			}
		}
		using (SqlConnection sqlConnection3 = new SqlConnection(connectionString))
		{
			sqlConnection3.Open();
			SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection3,
				CommandText = $"Select StudentNumber FROM tbl_oldStudents WHERE StudentNumber='{StudentNo}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
			if (sqlDataReader3.HasRows)
			{
				sqlDataReader3.Close();
				sqlConnection3.Close();
				return true;
			}
		}
		return false;
	}
}
