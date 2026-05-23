using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AlienAge.CommonSettings.Properties;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace AlienAge.CommonSettings;

public class SchoolSettings
{
	public enum SchoolType
	{
		Secondary,
		Primary
	}

	public enum SecondaryClassLevels
	{
		ALevel,
		OLevel
	}

	private enum OLevelRanking
	{
		OLevelUpper,
		OLevelLower
	}

	public enum PrimaryClassLevels
	{
		PrePrimary,
		LowerPrimary,
		UpperPrimary
	}

	public static string SchoolGeneralCurriculum
	{
		get
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT S_T FROM SchoolDetails", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "SchoolType");
			string result = "";
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				if (row["S_T"].ToString() == "ea/Hl6iT")
				{
					result = "Primary";
				}
				else if (row["S_T"].ToString() == "6ez8aEZy")
				{
					result = "Secondary";
				}
			}
			return result;
		}
	}

	public static bool SchoolCurriculumSet(string ConnectionString)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT S_T FROM SchoolDetails", ConnectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "SchoolType");
		bool result = true;
		if (dataSet.Tables[0].Rows.Count == 0)
		{
			result = false;
		}
		else
		{
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				if (row["S_T"].ToString() != string.Empty)
				{
					if (row["S_T"].ToString().Trim() != "ea/Hl6iT" && row["S_T"].ToString().Trim() != "6ez8aEZy")
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
		}
		return result;
	}

	public static int CurriculumInUse(string ConnectionString)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT S_T FROM SchoolDetails", ConnectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "SchoolType");
		int result = 0;
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			if (row["S_T"].ToString().Trim() == "6ez8aEZy")
			{
				result = 1;
			}
		}
		return result;
	}

	public static void SetSchoolCurriculum(string SchoolType, string ConnectionString)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT S_T FROM SchoolDetails",
				CommandType = CommandType.Text
			};
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			Image defaultNoImage = Resources.DefaultNoImage;
			int height = defaultNoImage.Height;
			int width = defaultNoImage.Width;
			height = height * 409 / width;
			width = 409;
			if (height > 376)
			{
				width = width * 376 / height;
				height = 376;
			}
			Bitmap bitmap = new Bitmap(defaultNoImage, width, height);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			byte[] array = new byte[memoryStream.Length + 1];
			memoryStream.Read(array, 0, array.Length);
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO SchoolDetails (S_T,logo) VALUES (@S_T,@logo)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@S_T", SqlDbType.VarChar, 8);
				sqlParameter.Value = CryptorEngine.Encrypt(SchoolType);
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@logo", SqlDbType.Image);
				sqlParameter.Value = array;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
				return;
			}
			sqlDataReader.Close();
			using SqlCommand sqlCommand3 = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE SchoolDetails SET S_T=@S_T",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@S_T", SqlDbType.VarChar, 8);
			sqlParameter2.Value = CryptorEngine.Encrypt(SchoolType);
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static string ClassLevel(string ClassId)
	{
		string result = "";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes WHERE ClassId='" + ClassId + "'", DataConnection.ConnectToDatabase());
		DataTable dataTable = new DataTable();
		sqlDataAdapter.Fill(dataTable);
		foreach (DataRow row in dataTable.Rows)
		{
			result = row["ClassGroup"].ToString();
		}
		return result;
	}

	public static string OLevelClassRanking(string ClassId)
	{
		string result = "";
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes WHERE ClassId='" + ClassId + "'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "_class_ranking");
		IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				result = dataRow["SubGroup"].ToString();
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

	public static string ScoresTableSource(string StudentClass)
	{
		string result = "";
		if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.OLevel.ToString() && OLevelClassRanking(StudentClass) == OLevelRanking.OLevelUpper.ToString())
		{
			result = "tbl_Scores_OL_Upper";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.OLevel.ToString() && OLevelClassRanking(StudentClass) == OLevelRanking.OLevelLower.ToString())
		{
			result = "tbl_Scores_OL_Lower";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.ALevel.ToString())
		{
			result = "tbl_Scores_AL";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Primary.ToString())
		{
			result = "tbl_Scores_Primary";
		}
		return result;
	}

	public static string GeneralReportTableSource(string StudentClass)
	{
		string result = "";
		if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.OLevel.ToString() && OLevelClassRanking(StudentClass) == OLevelRanking.OLevelUpper.ToString())
		{
			result = "tbl_GeneralReport_OL_Upper";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.OLevel.ToString() && OLevelClassRanking(StudentClass) == OLevelRanking.OLevelLower.ToString())
		{
			result = "tbl_GeneralReport_OL_Lower";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.ALevel.ToString())
		{
			result = "tbl_GeneralReport_AL";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Primary.ToString())
		{
			result = "tbl_GeneralReportCards_Primary";
		}
		return result;
	}

	public static string GeneralReportGradingTableSource(string StudentClass)
	{
		string result = "";
		if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.OLevel.ToString() && OLevelClassRanking(StudentClass) == OLevelRanking.OLevelUpper.ToString())
		{
			result = "tbl_GeneralReport_Grading_OL_Upper";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.OLevel.ToString() && OLevelClassRanking(StudentClass) == OLevelRanking.OLevelLower.ToString())
		{
			result = "tbl_GeneralReport_Grading_OL_Lower";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Secondary.ToString() && ClassLevel(StudentClass) == SecondaryClassLevels.ALevel.ToString())
		{
			result = "tbl_GeneralReport_Grading_AL";
		}
		else if (SchoolGeneralCurriculum == SchoolType.Primary.ToString())
		{
			result = "tbl_GeneralReports_Grading_Primary";
		}
		return result;
	}
}
