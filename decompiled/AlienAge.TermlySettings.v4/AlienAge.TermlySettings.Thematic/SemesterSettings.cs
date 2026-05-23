using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace AlienAge.TermlySettings.Thematic;

public class SemesterSettings
{
	public static void SetClassTermSettings(string classId, string termId, double hop, double bot, double mot, double eot, bool isPercent, DateTime termBegins, DateTime termEnds, string reportHeader, string s_sets, bool as100, string h_hop, string h_bot, string h_mot, string h_eot, bool AEOT)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "INSERT INTO tbl_TermSettings (ClassId,SemesterId,HoP,BOT,MOT,EOT,IsPercentage,TermBeginsOn,TermEndsOn,ReportHeader,Sets,EnterAs100,hHoP,hBOT,hMOT,hEOT,AEOT) VALUES (@ClassId,@SemesterId,@HoP,@BOT,@MOT,@EOT,@IsPercentage,@TermBeginsOn,@TermEndsOn,@ReportHeader,@Sets,@EnterAs100,@hHoP,@hBOT,@hMOT,@hEOT,@AEOT)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 3);
			sqlParameter.Value = classId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter.Value = termId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@HoP", SqlDbType.Float);
			sqlParameter.Value = hop;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BOT", SqlDbType.Float);
			sqlParameter.Value = bot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@MOT", SqlDbType.Float);
			sqlParameter.Value = mot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@EOT", SqlDbType.Float);
			sqlParameter.Value = eot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IsPercentage", SqlDbType.Bit);
			sqlParameter.Value = isPercent;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@TermBeginsOn", SqlDbType.DateTime);
			sqlParameter.Value = termBegins.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@TermEndsOn", SqlDbType.DateTime);
			sqlParameter.Value = termEnds.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ReportHeader", SqlDbType.VarChar, 50);
			sqlParameter.Value = reportHeader;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Sets", SqlDbType.VarChar, 4);
			sqlParameter.Value = s_sets;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@EnterAs100", SqlDbType.Bit);
			sqlParameter.Value = as100;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hHoP", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_hop;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hBOT", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_bot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hMOT", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_mot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hEOT", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_eot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@AEOT", SqlDbType.Bit);
			sqlParameter.Value = AEOT;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void UpdateClassTermSettings(string classId, string termId, double hop, double bot, double mot, double eot, bool isPercent, DateTime termBegins, DateTime termEnds, string reportHeader, string s_sets, bool as100, string h_hop, string h_bot, string h_mot, string h_eot, bool AEOT)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_TermSettings SET HoP=@HoP,BOT=@BOT,MOT=@MOT,EOT=@EOT,IsPercentage=@IsPercentage,TermBeginsOn=@TermBeginsOn,TermEndsOn=@TermEndsOn,ReportHeader=@ReportHeader,Sets=@Sets,EnterAs100=@EnterAs100,hHoP=@hHoP,hBOT=@hBOT,hMOT=@hMOT,hEOT=@hEOT,AEOT=@AEOT WHERE ClassId=@ClassId AND SemesterId=@SemesterId",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 3);
			sqlParameter.Value = classId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter.Value = termId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@HoP", SqlDbType.Float);
			sqlParameter.Value = hop;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BOT", SqlDbType.Float);
			sqlParameter.Value = bot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@MOT", SqlDbType.Float);
			sqlParameter.Value = mot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@EOT", SqlDbType.Float);
			sqlParameter.Value = eot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@IsPercentage", SqlDbType.Bit);
			sqlParameter.Value = isPercent;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@TermBeginsOn", SqlDbType.DateTime);
			sqlParameter.Value = termBegins.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@TermEndsOn", SqlDbType.DateTime);
			sqlParameter.Value = termEnds.ToShortDateString();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ReportHeader", SqlDbType.VarChar, 50);
			sqlParameter.Value = reportHeader;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Sets", SqlDbType.VarChar, 4);
			sqlParameter.Value = s_sets;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@EnterAs100", SqlDbType.Bit);
			sqlParameter.Value = as100;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hHoP", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_hop;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hBOT", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_bot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hMOT", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_mot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@hEOT", SqlDbType.VarChar, 12);
			sqlParameter.Value = h_eot;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@AEOT", SqlDbType.Bit);
			sqlParameter.Value = AEOT;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static bool IsSemesterSet(string _class, string _term)
	{
		bool result = false;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = $"SELECT * FROM tbl_TermSettings WHERE ClassId='{_class}' AND SemesterId='{_term}'",
			CommandType = CommandType.Text
		})
		{
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				result = true;
			}
			sqlDataReader.Close();
			sqlConnection.Close();
		}
		return result;
	}

	public static DateTime NextTermBeginsOn(string semesterId, string classId)
	{
		DateTime result = DateTime.Now;
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_TermSettings WHERE SemesterId='" + semesterId + "' AND ClassId='" + classId + "'", DataConnection.ConnectToDatabase());
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "TermBeginsOn");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (DateTime.TryParse(row["TermBeginsOn"].ToString(), out result) ? result : DateTime.Now);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}
}
