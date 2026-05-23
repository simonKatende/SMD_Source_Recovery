using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AlienAge.Connectivity;

namespace AlienAge.Security;

public class LicenceStatus
{
	public enum CurrentStatus
	{
		Expired,
		NotExpired
	}

	private static string TrialLicenceStatus
	{
		get
		{
			string result = "Expired";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT * FROM tbl_StudentIDSNo WHERE _vvvv='{0}'", CryptorEngine.Encrypt("MainKeyValidator")), DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SecurityCheck");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					int length = dataRow["_pppp"].ToString().Length;
					string text = dataRow["_pppp"].ToString().Substring(length - 3, 3);
					int result2 = (int.TryParse(text.ToString(), out result2) ? result2 : 0);
					string value = Convert.ToDateTime(CryptorEngine.Decrypt(dataRow["_pppppppppp"].ToString())).ToString("MM/dd/yyyy");
					string value2 = Convert.ToDateTime(CryptorEngine.Decrypt(dataRow["_pppppppp"].ToString())).ToString("MM/dd/yyyy");
					DateTime dateTime = Convert.ToDateTime(value);
					DateTime dateTime2 = Convert.ToDateTime(value2);
					int num = (int)(DateTime.Now - dateTime2).TotalDays;
					int num2 = (int)DateTime.Now.ToOADate();
					result = (((double)num2 < dateTime.ToOADate()) ? "Expired" : (((double)num2 == dateTime.ToOADate()) ? "NotExpired" : (((double)num2 > dateTime.ToOADate() && num < result2) ? "NotExpired" : ((!((double)num2 > dateTime.ToOADate()) || num <= result2) ? "NotExpired" : "Expired"))));
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
			return result;
		}
	}

	public static bool IsTrialExpired
	{
		get
		{
			bool result = true;
			string text = FingerPrint.GenerateRequestCode(FingerPrint.SchoolName, FingerPrint.ContactNo, FingerPrint.Village, FingerPrint.SchoolType, FingerPrint.Category);
			string arg = CryptorEngine.Encrypt("ClientKeyValidator");
			string arg2 = CryptorEngine.Encrypt("MainKeyValidator");
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_StudentIDSNo WHERE _vvvv = '{arg}' AND _pppp LIKE '{text}%'", DataConnection.ConnectToDatabase()))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "securityCheck");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter($"SELECT * FROM tbl_StudentIDSNo WHERE _vvvv='{arg2}'", DataConnection.ConnectToDatabase());
						DataTable dataTable = new DataTable();
						sqlDataAdapter2.Fill(dataTable);
						if (dataTable.Rows.Count <= 0)
						{
							continue;
						}
						string text2 = dataTable.Rows[0]["_pppp"].ToString();
						string schoolId = dataTable.Rows[0]["_ccccc"].ToString();
						if (text2.Contains('|'))
						{
							int length = text2.Length;
							string text3 = text2.Substring(length - 3, 3);
							string serialNumberiXtremeTrial = SerialNumber.GetSerialNumberiXtremeTrial(text + text3, schoolId);
							string text4 = CryptorEngine.Encrypt(serialNumberiXtremeTrial);
							if (TrialLicenceStatus == CurrentStatus.NotExpired.ToString())
							{
								if (text4 == row["_ssss"].ToString())
								{
									result = false;
									UpdateSuccessfulLogin();
								}
								else
								{
									result = true;
								}
							}
							else if (TrialLicenceStatus == CurrentStatus.Expired.ToString())
							{
								result = true;
							}
						}
						else
						{
							string serialNumberiXtreme = SerialNumber.GetSerialNumberiXtreme(text, schoolId);
							string text5 = CryptorEngine.Encrypt(serialNumberiXtreme);
							if (text5 == row["_ssss"].ToString())
							{
								result = false;
								UpdateSuccessfulLogin();
							}
							else
							{
								result = true;
							}
						}
					}
				}
				else
				{
					result = true;
				}
			}
			return result;
		}
	}

	private static void UpdateSuccessfulLogin()
	{
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.Connection = sqlConnection;
		sqlCommand.CommandText = "UPDATE tbl_StudentIDSNo SET _pppppppppp=@_pppppppppp WHERE _vvvv=@_vvvv";
		sqlCommand.CommandType = CommandType.Text;
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@_pppppppppp", SqlDbType.VarChar, 50);
		sqlParameter.Value = CryptorEngine.Encrypt(DateTime.Now.ToShortDateString());
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@_vvvv", SqlDbType.VarChar, 50);
		sqlParameter.Value = CryptorEngine.Encrypt("MainKeyValidator");
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
		sqlConnection.Close();
	}
}
