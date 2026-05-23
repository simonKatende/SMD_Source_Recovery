using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public class TermSettings
{
	private static ArabicNumeralHelper conv = new ArabicNumeralHelper();

	public static void SetTermSettingsEn(string classId, string termId, double bot, double mot, double eot, bool isPercent, DateTime termBegins, string reportHeader, string reportHeaderAr, string s_sets)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{classId}' AND SemesterId='{termId}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "UPDATE tbl_TermSettings_TH SET BOTEn=@BOTEn,MOTEn=@MOTEn,EOTEn=@EOTEn,BOTAr=@BOTAr,MOTAr=@MOTAr,EOTAr=@EOTAr,IsPercentage=@IsPercentage,TermBeginsOnEn=@TermBeginsOnEn,TermBeginsOnAr=@TermBeginsOnAr,ReportHeaderEn=@ReportHeaderEn,ReportHeaderAr=@ReportHeaderAr,Sets=@Sets WHERE ClassIdEn=@ClassIdEn AND SemesterId=@SemesterId",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@ClassIdEn", SqlDbType.VarChar, 15);
				sqlParameter.Value = classId;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter.Value = termId;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@BOTEn", SqlDbType.Float);
				sqlParameter.Value = bot;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@MOTEn", SqlDbType.Float);
				sqlParameter.Value = mot;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@EOTEn", SqlDbType.Float);
				sqlParameter.Value = eot;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@BOTAr", SqlDbType.NVarChar, 3);
				sqlParameter.Value = conv.EnglishToArabic(bot.ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@MOTAr", SqlDbType.NVarChar, 3);
				sqlParameter.Value = conv.EnglishToArabic(mot.ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@EOTAr", SqlDbType.NVarChar, 3);
				sqlParameter.Value = conv.EnglishToArabic(eot.ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@IsPercentage", SqlDbType.Bit);
				sqlParameter.Value = isPercent;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@TermBeginsOnEn", SqlDbType.DateTime);
				sqlParameter.Value = termBegins.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@TermBeginsOnAr", SqlDbType.NVarChar, 50);
				sqlParameter.Value = termBegins.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@ReportHeaderEn", SqlDbType.VarChar, 50);
				sqlParameter.Value = reportHeader;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@ReportHeaderAr", SqlDbType.NVarChar, 50);
				sqlParameter.Value = reportHeaderAr;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@Sets", SqlDbType.VarChar, 4);
				sqlParameter.Value = s_sets;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection2.Close();
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection3.Open();
			using SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection3,
				CommandText = "INSERT INTO tbl_TermSettings_TH (ClassIdEn,SemesterId,BOTEn,MOTEn,EOTEn,BOTAr,MOTAr,EOTAr,IsPercentage,TermBeginsOnEn,TermBeginsOnAr,ReportHeaderEn,ReportHeaderAr,Sets) VALUES (@ClassIdEn,@SemesterId,@BOTEn,@MOTEn,@EOTEn,@BOTAr,@MOTAr,@EOTAr,@IsPercentage,@TermBeginsOnEn,@TermBeginsOnAr,@ReportHeaderEn,@ReportHeaderAr,@Sets)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@ClassIdEn", SqlDbType.VarChar, 15);
			sqlParameter2.Value = classId;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter2.Value = termId;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@BOTEn", SqlDbType.Float);
			sqlParameter2.Value = bot;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@MOTEn", SqlDbType.Float);
			sqlParameter2.Value = mot;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@EOTEn", SqlDbType.Float);
			sqlParameter2.Value = eot;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@BOTAr", SqlDbType.NVarChar, 3);
			sqlParameter2.Value = conv.EnglishToArabic(bot.ToString());
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@MOTAr", SqlDbType.NVarChar, 3);
			sqlParameter2.Value = conv.EnglishToArabic(mot.ToString());
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@EOTAr", SqlDbType.NVarChar, 3);
			sqlParameter2.Value = conv.EnglishToArabic(eot.ToString());
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@IsPercentage", SqlDbType.Bit);
			sqlParameter2.Value = isPercent;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@TermBeginsOnEn", SqlDbType.DateTime);
			sqlParameter2.Value = termBegins.ToShortDateString();
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@TermBeginsOnAr", SqlDbType.NVarChar, 50);
			sqlParameter2.Value = termBegins.ToShortDateString();
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@ReportHeaderEn", SqlDbType.VarChar, 50);
			sqlParameter2.Value = reportHeader;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@ReportHeaderAr", SqlDbType.NVarChar, 50);
			sqlParameter2.Value = reportHeaderAr;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@Sets", SqlDbType.VarChar, 4);
			sqlParameter2.Value = s_sets;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
			sqlConnection3.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void SetTermSettingsAr(string classId, string termId, string bot, string mot, string eot, bool isPercent, DateTime termBegins, string reportHeader, string reportHeaderAr, string s_sets, bool outOf100)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{classId}' AND SemesterId='{termId}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection2.Open();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "UPDATE tbl_TermSettings_TH SET BOTEn=@BOTEn,MOTEn=@MOTEn,EOTEn=@EOTEn,BOTAr=@BOTAr,MOTAr=@MOTAr,EOTAr=@EOTAr,IsPercentage=@IsPercentage,TermBeginsOnEn=@TermBeginsOnEn,TermBeginsOnAr=@TermBeginsOnAr,ReportHeaderEn=@ReportHeaderEn,ReportHeaderAr=@ReportHeaderAr,Sets=@Sets,EnterAs100=@EnterAs100 WHERE ClassIdEn=@ClassIdEn AND SemesterId=@SemesterId",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@ClassIdEn", SqlDbType.VarChar, 15);
				sqlParameter.Value = classId;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
				sqlParameter.Value = termId;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@BOTEn", SqlDbType.Float);
				sqlParameter.Value = conv.ArabicToEnglish(bot);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@MOTEn", SqlDbType.Float);
				sqlParameter.Value = conv.ArabicToEnglish(mot);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@EOTEn", SqlDbType.Float);
				sqlParameter.Value = conv.ArabicToEnglish(eot);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@BOTAr", SqlDbType.NVarChar, 3);
				sqlParameter.Value = bot;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@MOTAr", SqlDbType.NVarChar, 3);
				sqlParameter.Value = mot;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@EOTAr", SqlDbType.NVarChar, 3);
				sqlParameter.Value = eot;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@IsPercentage", SqlDbType.Bit);
				sqlParameter.Value = isPercent;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@TermBeginsOnEn", SqlDbType.DateTime);
				sqlParameter.Value = termBegins.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@TermBeginsOnAr", SqlDbType.NVarChar, 10);
				sqlParameter.Value = termBegins.ToShortDateString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@ReportHeader", SqlDbType.VarChar, 50);
				sqlParameter.Value = reportHeader;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@ReportHeaderAr", SqlDbType.NVarChar, 10);
				sqlParameter.Value = reportHeaderAr;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@Sets", SqlDbType.VarChar, 4);
				sqlParameter.Value = s_sets;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@EnterAs100", SqlDbType.Bit);
				sqlParameter.Value = outOf100;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection2.Close();
				return;
			}
			sqlConnection.Close();
			using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection3.Open();
			using SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection3,
				CommandText = "INSERT INTO tbl_TermSettings_TH (ClassIdEn,SemesterId,BOTEn,MOTEn,EOTEn,BOTAr,MOTAr,EOTAr,IsPercentage,TermBeginsOnEn,TermBeginsOnAr,ReportHeaderEn,ReportHeaderAr,Sets) VALUES (@ClassIdEn,@SemesterId,@BOTEn,@MOTEn,@EOTEn,@BOTAr,@MOTAr,@EOTAr,@IsPercentage,@TermBeginsOnEn,@TermBeginsOnAr,@ReportHeaderEn,@ReportHeaderAr,@Sets)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@ClassIdEn", SqlDbType.VarChar, 15);
			sqlParameter2.Value = classId;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter2.Value = termId;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@BOTEn", SqlDbType.Float);
			sqlParameter2.Value = conv.ArabicToEnglish(bot);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@MOTEn", SqlDbType.Float);
			sqlParameter2.Value = conv.ArabicToEnglish(mot);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@EOTEn", SqlDbType.Float);
			sqlParameter2.Value = conv.ArabicToEnglish(eot);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@BOTAr", SqlDbType.NVarChar, 3);
			sqlParameter2.Value = bot;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@MOTAr", SqlDbType.NVarChar, 3);
			sqlParameter2.Value = mot;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@EOTAr", SqlDbType.NVarChar, 3);
			sqlParameter2.Value = eot;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@IsPercentage", SqlDbType.Bit);
			sqlParameter2.Value = isPercent;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@TermBeginsOnEn", SqlDbType.DateTime);
			sqlParameter2.Value = termBegins.ToShortDateString();
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@TermBeginsOnAr", SqlDbType.NVarChar, 10);
			sqlParameter2.Value = termBegins.ToShortDateString();
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@ReportHeader", SqlDbType.VarChar, 50);
			sqlParameter2.Value = reportHeader;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@ReportHeaderAr", SqlDbType.NVarChar, 10);
			sqlParameter2.Value = reportHeaderAr;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand3.Parameters.Add("@Sets", SqlDbType.VarChar, 4);
			sqlParameter2.Value = s_sets;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
			sqlConnection3.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static bool IsSemesterSet(string _class, string _term)
	{
		bool result = false;
		using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_TermSettings_TH WHERE ClassIdEn='{_class}' AND SemesterId='{_term}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlConnection.Close();
				result = true;
			}
			else
			{
				sqlConnection.Close();
				result = false;
			}
		}
		return result;
	}

	public static DateTime NextTermBeginsOn(string semesterId, string classId)
	{
		DateTime result = DateTime.Now;
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE SemesterId='{semesterId}' AND ClassIdEn='{classId}'", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "TermBeginsOn");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (DateTime.TryParse(row["TermBeginsOnEn"].ToString(), out result) ? result : DateTime.Now);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	public static string[] ReportHeaders(string semesterId, string classId)
	{
		string[] array = new string[2] { "", "" };
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_TermSettings_TH WHERE SemesterId='{semesterId}' AND ClassIdEn='{classId}'", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ReportHeaders");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				array[0] = row["ReportHeaderEn"].ToString();
				array[1] = row["ReportHeaderAr"].ToString();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return array;
	}
}
