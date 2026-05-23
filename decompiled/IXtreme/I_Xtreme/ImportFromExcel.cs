using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using I_Xtreme.Properties;

namespace I_Xtreme;

[Serializable]
internal class ImportFromExcel
{
	private static string excelfileName { get; set; }

	private static CheckedListBoxControl checkedListBox { get; set; }

	public static string ExcelFilePath
	{
		get
		{
			return excelfileName;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ExcelSource.bin");
			ImportFromExcel importFromExcel = new ImportFromExcel();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			importFromExcel = (ImportFromExcel)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			excelfileName = ExcelFilePath;
		}
	}

	public static CheckedListBoxControl CheckLBFields
	{
		get
		{
			return checkedListBox;
		}
		set
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_ExcelSource.bin");
			ImportFromExcel importFromExcel = new ImportFromExcel();
			using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			importFromExcel = (ImportFromExcel)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			checkedListBox = CheckLBFields;
		}
	}

	public static void SaveCheckedListBox(CheckedListBoxControl checkLB)
	{
		ImportFromExcel graph = new ImportFromExcel();
		checkedListBox = checkLB;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_ExcelSource.bin");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SaveExcelPath(string excelFilePath)
	{
		ImportFromExcel graph = new ImportFromExcel();
		excelfileName = excelFilePath;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_ExcelSource.bin");
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
		return Convert.ToString('-');
	}

	private static void InsertToSql(Guid uniquGuid, string studentNo, string fname, string lname, string classId, string streamId, string sex, string studyStatus, string houseId, string homeCountry, string religion)
	{
		Image @default = Resources.Default;
		int height = @default.Height;
		int width = @default.Width;
		height = height * 220 / width;
		width = 220;
		if (height > 250)
		{
			width = width * 250 / height;
			height = 250;
		}
		Bitmap bitmap = new Bitmap(@default, width, height);
		MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		memoryStream.Position = 0L;
		byte[] array = new byte[memoryStream.Length + 1];
		memoryStream.Read(array, 0, array.Length);
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO students (fullName,Oid,StudentNumber,FirstName,LastName,ClassId,StreamId,Sex,StudyStatus,HouseId,Religion,Guardian,BursaryStatus,RequiredFees,BursaryProvider,AdmissionDate,Picture,HomeCountry,Status)values(@fullName, @Oid, @StudentNumber, @FirstName, @LastName, @ClassId,@StreamId,@Sex,@StudyStatus,@HouseId,@Religion,@Guardian,@BursaryStatus,@RequiredFees,@BursaryProvider,@AdmissionDate,@Picture,@HomeCountry,@Status)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = studentNo;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@fullName", SqlDbType.VarChar, 100);
			sqlParameter.Value = $"{fname} {lname}";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Oid", SqlDbType.UniqueIdentifier);
			sqlParameter.Value = uniquGuid;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
			sqlParameter.Value = fname;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
			sqlParameter.Value = lname;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@ClassId", SqlDbType.VarChar, 50);
			sqlParameter.Value = classId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@StreamId", SqlDbType.VarChar, 50);
			sqlParameter.Value = streamId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@sex", SqlDbType.VarChar, 1);
			sqlParameter.Value = sex;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@studyStatus", SqlDbType.VarChar, 1);
			sqlParameter.Value = studyStatus;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@HouseId", SqlDbType.VarChar, 50);
			sqlParameter.Value = houseId;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Religion", SqlDbType.VarChar, 15);
			sqlParameter.Value = religion;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Guardian", SqlDbType.VarChar, 50);
			sqlParameter.Value = "-----";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BursaryStatus", SqlDbType.VarChar, 50);
			sqlParameter.Value = "None";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@RequiredFees", SqlDbType.Money);
			sqlParameter.Value = 0;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@BursaryProvider", SqlDbType.VarChar, 50);
			sqlParameter.Value = "-------";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@AdmissionDate", SqlDbType.Int);
			sqlParameter.Value = Convert.ToInt32(DateTime.Now.Year);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Picture", SqlDbType.Image);
			sqlParameter.Value = array;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@HomeCountry", SqlDbType.VarChar, 15);
			sqlParameter.Value = homeCountry;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar, 20);
			sqlParameter.Value = "Active";
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		sqlConnection.Close();
	}

	public static void ImportStudentsFromExcel()
	{
		try
		{
			using OleDbConnection oleDbConnection = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={ExcelFilePath};Extended Properties=Excel 8.0");
			OleDbCommand oleDbCommand = new OleDbCommand("select * from [Sheet1$]", oleDbConnection);
			oleDbConnection.Open();
			OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			string empty6 = string.Empty;
			string empty7 = string.Empty;
			string empty8 = string.Empty;
			string empty9 = string.Empty;
			while (oleDbDataReader.Read())
			{
				empty = valid(oleDbDataReader, 0);
				empty2 = valid(oleDbDataReader, 1);
				empty3 = valid(oleDbDataReader, 2);
				empty4 = valid(oleDbDataReader, 3);
				empty5 = valid(oleDbDataReader, 4);
				empty6 = valid(oleDbDataReader, 5);
				empty7 = valid(oleDbDataReader, 6);
				empty8 = valid(oleDbDataReader, 7);
				empty9 = valid(oleDbDataReader, 8);
				InsertToSql(Guid.NewGuid(), StudentNumber.GetNextStudentNumber()[0], empty, empty2, empty3, empty4, empty5, empty6, empty7, empty8, empty9);
			}
			oleDbConnection.Close();
			oleDbConnection.Dispose();
		}
		catch (DataException ex)
		{
			throw ex;
		}
	}

	public static void TransferGuardians()
	{
		using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
		{
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM Guardians",
				CommandType = CommandType.Text
			};
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Stud WHERE Guardian<>''", selectConnection);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "guard");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			Guid guid = new Guid(row["Oid"].ToString());
			using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection2.Open();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "INSERT INTO Guardians (studentOid,GuardianName,GuardianContact,GuardianAddress)VALUES(@studentOid,@GuardianName,@GuardianContact,@GuardianAddress)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@studentOid", SqlDbType.UniqueIdentifier);
				sqlParameter.Value = guid;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@GuardianName", SqlDbType.VarChar, 50);
				sqlParameter.Value = row["Guardian"].ToString();
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@GuardianContact", SqlDbType.VarChar, 50);
				sqlParameter.Value = string.Empty;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@GuardianAddress", SqlDbType.VarChar, 50);
				sqlParameter.Value = string.Empty;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection2.Close();
			sqlConnection2.Dispose();
		}
	}
}
