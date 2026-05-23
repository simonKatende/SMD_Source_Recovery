using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using DevExpress.Utils;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public class ReportViewMode
{
	public enum ViewModes
	{
		ArabicOnly,
		ArabicOnlyTranslated,
		ArabicAndThematic
	}

	public enum Languages
	{
		English,
		Arabic
	}

	public struct ReportViewLanguage
	{
		private bool Name;

		private bool Class;

		private bool Stream;

		private bool Sex;

		private bool printReportHeader;

		private bool printSchoolHeader;

		private bool printFeesBalance;

		private bool inputLang;

		private bool displayLang;

		private bool thanawi;

		private bool idaad;

		private bool shuuba;

		private DefaultBoolean rHeader;

		public bool ArNameOn => Name;

		public bool ArClassOn => Class;

		public bool ArStreamOn => Stream;

		public bool ArSexOn => Sex;

		public bool PrintReportHeader => printReportHeader;

		public bool PrintSchoolHeader => printSchoolHeader;

		public bool PrintFeesBalance => printFeesBalance;

		public bool IsShuubaDone => shuuba;

		public bool IsIdaadDone => idaad;

		public bool IsThanawiDone => thanawi;

		public DefaultBoolean IsReportHeaderEnglish => rHeader;

		public string InPutLanguage
		{
			get
			{
				if (inputLang)
				{
					return "Arabic";
				}
				return "English";
			}
		}

		public int InPutLanguageIndex
		{
			get
			{
				if (inputLang)
				{
					return 1;
				}
				return 0;
			}
		}

		public string DisplayLanguage
		{
			get
			{
				if (displayLang)
				{
					return "Arabic";
				}
				return "English";
			}
		}

		public int DisplayLanguageIndex
		{
			get
			{
				if (displayLang)
				{
					return 1;
				}
				return 0;
			}
		}

		public string DisplayLanguageCulture
		{
			get
			{
				if (displayLang)
				{
					return "ar";
				}
				return "en";
			}
		}

		public void InitializeViewLanguage()
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT NameLang,SexLang,ClassLang,StreamLang,sSchoolHeader,sReportHeader,sFeesBalance,rHeaderLang,hShu,hIda,hTha FROM SchoolDetails_TH", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "OutputLanguage");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				Name = false;
				Class = false;
				Stream = false;
				Sex = false;
				printReportHeader = false;
				printSchoolHeader = false;
				printFeesBalance = false;
				thanawi = false;
				idaad = false;
				shuuba = false;
				rHeader = DefaultBoolean.False;
				return;
			}
			IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					Name = bool.TryParse(dataRow["NameLang"].ToString(), out Name) && Name;
					Class = bool.TryParse(dataRow["ClassLang"].ToString(), out Class) && Class;
					Stream = bool.TryParse(dataRow["StreamLang"].ToString(), out Stream) && Stream;
					Sex = bool.TryParse(dataRow["SexLang"].ToString(), out Sex) && Sex;
					printReportHeader = bool.TryParse(dataRow["sReportHeader"].ToString(), out printReportHeader) && printReportHeader;
					printSchoolHeader = bool.TryParse(dataRow["sSchoolHeader"].ToString(), out printSchoolHeader) && printSchoolHeader;
					printFeesBalance = bool.TryParse(dataRow["sFeesBalance"].ToString(), out printFeesBalance) && printFeesBalance;
					thanawi = bool.TryParse(dataRow["hTha"].ToString(), out thanawi) && thanawi;
					idaad = bool.TryParse(dataRow["hIda"].ToString(), out idaad) && idaad;
					shuuba = bool.TryParse(dataRow["hShu"].ToString(), out shuuba) && shuuba;
					rHeader = ((!Enum.TryParse<DefaultBoolean>(dataRow["rHeaderLang"].ToString(), out rHeader)) ? DefaultBoolean.False : rHeader);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void InitializeLanguageParameters()
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT InputLang,DisplayLang FROM tbl_userLogin WHERE userId=" + CurrentUser.UserID, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "LanguageParameters");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				inputLang = false;
				displayLang = false;
				return;
			}
			IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					inputLang = bool.TryParse(dataRow["InputLang"].ToString(), out inputLang) && inputLang;
					displayLang = bool.TryParse(dataRow["DisplayLang"].ToString(), out displayLang) && displayLang;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void SaveViewParameter(string FieldName, object FieldValue)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM SchoolDetails_TH",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE SchoolDetails_TH SET " + FieldName + "=@" + FieldName,
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@" + FieldName, SqlDbType.Bit);
				sqlParameter.Value = Convert.ToBoolean(FieldValue.ToString());
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
			else
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand3 = new SqlCommand();
				sqlCommand3.Connection = sqlConnection;
				sqlCommand3.CommandText = "INSERT INTO SchoolDetails_TH (" + FieldName + ") VALUES (@" + FieldName + ")";
				sqlCommand3.CommandType = CommandType.Text;
				SqlCommand sqlCommand4 = sqlCommand3;
				SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@" + FieldName, SqlDbType.Bit);
				sqlParameter2.Value = Convert.ToBoolean(FieldValue.ToString());
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand4.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}

		public void SaveLanguageParameter(string FieldName, object FieldValue)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand();
			sqlCommand.Connection = sqlConnection;
			sqlCommand.CommandText = "UPDATE tbl_userLogin SET " + FieldName + "=@" + FieldName + " WHERE userId=" + CurrentUser.UserID;
			sqlCommand.CommandType = CommandType.Text;
			SqlCommand sqlCommand2 = sqlCommand;
			SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@" + FieldName, SqlDbType.Bit);
			sqlParameter.Value = Convert.ToBoolean(FieldValue);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
			sqlConnection.Close();
		}
	}

	private static int viewmode;

	public static int ViewMode
	{
		get
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT ReportView FROM SchoolDetails_TH", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ReportView_Mode");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				viewmode = 0;
			}
			else
			{
				{
					IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							DataRow dataRow = (DataRow)enumerator.Current;
							viewmode = Convert.ToInt32(dataRow["ReportView"].ToString());
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			return viewmode;
		}
		set
		{
			viewmode = value;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM SchoolDetails_TH",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "UPDATE SchoolDetails_TH SET ReportView=@ReportView",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@ReportView", SqlDbType.Int);
				sqlParameter.Value = viewmode;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
			else
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO SchoolDetails_TH (ReportView) VALUES (@ReportView)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@ReportView", SqlDbType.Int);
				sqlParameter2.Value = viewmode;
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand3.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
	}
}
