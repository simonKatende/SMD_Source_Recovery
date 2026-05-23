using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace AlienAge.ArabicTheology.TheologyHelperClasses;

public class Subjects
{
	public enum Gender
	{
		ذكر,
		أنثى
	}

	public List<KeyValuePair<string, string>> Grades
	{
		get
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			list.Add(new KeyValuePair<string, string>("First Grade", "ممتاز"));
			list.Add(new KeyValuePair<string, string>("Second Grade", "جيد جدا"));
			list.Add(new KeyValuePair<string, string>("Third Grade", "جيد"));
			list.Add(new KeyValuePair<string, string>("Fourth Grade", "مقبول"));
			list.Add(new KeyValuePair<string, string>("Fail", "راسب"));
			return list;
		}
	}

	public static DataTable GradeISource
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Subject_En", typeof(string));
			dataTable.Columns.Add("Subject_Ar", typeof(string));
			string[] array = new string[4] { "القرآن", "الفقه", "التربية", "اللغة" };
			string[] array2 = new string[4] { "Qur`an", "Fiquh ", "Tarbiya", "Lugha" };
			for (int i = 0; i < array2.Length; i++)
			{
				dataTable.Rows.Add(array2[i], array[i]);
			}
			return dataTable;
		}
	}

	public static DataTable GradeIISource
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Subject_En", typeof(string));
			dataTable.Columns.Add("Subject_Ar", typeof(string));
			string[] array = new string[10] { "الحفظ والتفسير", "التلاوة والتجويد", "الإملاء والخط", "التوحيد", "التاريخ الإسلامي", "فقه العبادات", "الحديث", "النحو والصرف", "الأدب والنصوص", "الإنشاء والمطالعة" };
			string[] array2 = new string[10] { "Hifdhu Wa Tafseer", "Tilawat Wa Tajweed", "Imla`e Wa Khatw", "Tauheed", "Tareekh", "Fiquh", "Hadeeth", "Nahaw Wa Swarf", "Adab", "Insha`e Wa Mutwal`a" };
			for (int i = 0; i < array2.Length; i++)
			{
				dataTable.Rows.Add(array2[i], array[i]);
			}
			return dataTable;
		}
	}

	public static DataTable GradeIIISource
	{
		get
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Subject_En", typeof(string));
			dataTable.Columns.Add("Subject_Ar", typeof(string));
			string[] array = new string[15]
			{
				"التلاوة", "الخفظ و التفسير", "أصول التفسير", "التوحيد", "التاريخ", "الأديان", "الفقه", "أصول الفقه", "فرائض", "الحديث",
				"أصول الحديث", "النحو والصرف", "الأدب", "البلاغة", "الإنشاء و المطالعة"
			};
			string[] array2 = new string[15]
			{
				"Tilaawa", "Hifidhu wa tafsiir", "Usulu tafsiir", "Tauhiid", "Tareekh", "Adiyan", "Fiquh", "Usulu fiquh", "Faraedhu", "Hadeeth",
				"Usulu Hadeeth", "Nahw wa swaruf", "Adab", "Balagha", "Enshaa wal mutwala`a"
			};
			for (int i = 0; i < array2.Length; i++)
			{
				dataTable.Rows.Add(array2[i], array[i]);
			}
			return dataTable;
		}
	}

	public static void InitializeGradeISubjects()
	{
		string[] array = new string[4] { "القرآن", "الفقه", "التربية", "اللغة" };
		string[] array2 = new string[4] { "Qur`an", "Fiquh ", "Tarbiya", "Lugha" };
		for (int i = 0; i < array2.Length; i++)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM OLevelSubjects_TH WHERE SubjectId=@SubjectId AND ClassLevel='GradeI'",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 50);
			sqlParameter.Value = array2[i];
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO OLevelSubjects_TH (SubjectId,SubjectName,ClassLevel) VALUES (@SubjectId,@SubjectName,@ClassLevel)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 50);
				sqlParameter2.Value = array2[i];
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 50);
				sqlParameter2.Value = array[i];
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 10);
				sqlParameter2.Value = "GradeI";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
	}

	public static void InitializeGradeIISubjects()
	{
		string[] array = new string[10] { "الحفظ والتفسير", "التلاوة والتجويد", "الإملاء والخط", "التوحيد", "التاريخ الإسلامي", "فقه العبادات", "الحديث", "النحو والصرف", "الأدب والنصوص", "الإنشاء والمطالعة" };
		string[] array2 = new string[10] { "Hifdhu Wa Tafseer", "Tilawat Wa Tajweed", "Imla`e Wa Khatw", "Tauheed", "Tareekh", "Fiquh", "Hadeeth", "Nahaw Wa Swarf", "Adab", "Insha`e Wa Mutwal`a" };
		for (int i = 0; i < array2.Length; i++)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM OLevelSubjects_TH WHERE SubjectId=@SubjectId AND ClassLevel='GradeII'",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 50);
			sqlParameter.Value = array2[i];
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO OLevelSubjects_TH (SubjectId,SubjectName,ClassLevel) VALUES (@SubjectId,@SubjectName,@ClassLevel)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 50);
				sqlParameter2.Value = array2[i];
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 50);
				sqlParameter2.Value = array[i];
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 10);
				sqlParameter2.Value = "GradeII";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
	}

	public static void InitializeGradeIIISubjects()
	{
		string[] array = new string[15]
		{
			"التلاوة", "الخفظ و التفسير", "أصول التفسير", "التوحيد", "التاريخ", "الأديان", "الفقه", "أصول الفقه", "فرائض", "الحديث",
			"أصول الحديث", "النحو والصرف", "الأدب", "البلاغة", "الإنشاء و المطالعة"
		};
		string[] array2 = new string[15]
		{
			"Tilaawa", "Hifidhu wa tafsiir", "Usulu tafsiir", "Tauhiid", "Tareekh", "Adiyan", "Fiquh", "Usulu fiquh", "Faraedhu", "Hadeeth",
			"Usulu Hadeeth", "Nahw wa swaruf", "Adab", "Balagha", "Enshaa wal mutwala`a"
		};
		for (int i = 0; i < array2.Length; i++)
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM OLevelSubjects_TH WHERE SubjectId=@SubjectId AND ClassLevel='GradeII'",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 50);
			sqlParameter.Value = array2[i];
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (!sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO OLevelSubjects_TH (SubjectId,SubjectName,ClassLevel) VALUES (@SubjectId,@SubjectName,@ClassLevel)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectId", SqlDbType.NVarChar, 50);
				sqlParameter2.Value = array2[i];
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@SubjectName", SqlDbType.NVarChar, 50);
				sqlParameter2.Value = array[i];
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlParameter2 = sqlCommand2.Parameters.Add("@ClassLevel", SqlDbType.VarChar, 10);
				sqlParameter2.Value = "GradeIII";
				sqlParameter2.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
	}

	public static void LoadSubjectsToGridEn(GridControl grid, string ClassLevel)
	{
		DataTable dataTable = new DataTable();
		if (ClassLevel == Classes.ClassLevels.Shuuba.ToString())
		{
			dataTable = GradeISource;
		}
		else if (ClassLevel == Classes.ClassLevels.Idaad.ToString())
		{
			dataTable = GradeIISource;
		}
		else if (ClassLevel == Classes.ClassLevels.Thanawi.ToString())
		{
			dataTable = GradeIIISource;
		}
		grid.DataSource = dataTable.DefaultView;
	}

	public static void LoadSubjectsToComboBoxEn(ComboBoxEdit combo, string ClassLevel)
	{
		DataTable dataTable = new DataTable();
		if (ClassLevel == Classes.ClassLevels.Shuuba.ToString())
		{
			dataTable = GradeISource;
		}
		else if (ClassLevel == Classes.ClassLevels.Idaad.ToString())
		{
			dataTable = GradeIISource;
		}
		else if (ClassLevel == Classes.ClassLevels.Thanawi.ToString())
		{
			dataTable = GradeIIISource;
		}
		combo.Text = string.Empty;
		combo.Properties.Items.Clear();
		foreach (DataRow row in dataTable.Rows)
		{
			combo.Properties.Items.Add(row["Subject_En"].ToString());
		}
	}

	public static void LoadSubjectsToComboBoxAr(ComboBoxEdit combo, string ClassLevel)
	{
		DataTable dataTable = new DataTable();
		switch (ClassLevel)
		{
		case "Primary":
			dataTable = GradeISource;
			break;
		case "OLevel":
			dataTable = GradeIISource;
			break;
		case "ALevel":
			dataTable = GradeIIISource;
			break;
		}
		foreach (DataRow row in dataTable.Rows)
		{
			combo.Properties.Items.Add(row["Subject_Ar"].ToString());
		}
	}

	public static DataTable SubjectSource(string ClassLevel)
	{
		DataTable result = new DataTable();
		if (ClassLevel == Classes.ClassLevels.Shuuba.ToString())
		{
			result = GradeISource;
		}
		else if (ClassLevel == Classes.ClassLevels.Idaad.ToString())
		{
			result = GradeIISource;
		}
		else if (ClassLevel == Classes.ClassLevels.Thanawi.ToString())
		{
			result = GradeIIISource;
		}
		return result;
	}
}
