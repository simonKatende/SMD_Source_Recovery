using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

[Serializable]
internal class MarkSheet
{
	private static string connectionString = DataConnection.ConnectToDatabase();

	private static string markType { get; set; }

	private static string markSheetView { get; set; }

	private static string gridViewType { get; set; }

	private static int rankType { get; set; }

	private static int rankGroup { get; set; }

	private static string generalViewType { get; set; }

	public static int RankingType
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
			MarkSheet markSheet = new MarkSheet();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			markSheet = (MarkSheet)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return rankType;
		}
	}

	public static int RankingGroup
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
			MarkSheet markSheet = new MarkSheet();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			markSheet = (MarkSheet)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return rankGroup;
		}
	}

	public static void SetRankingTypeAndGroup(int _rankType, int _rankGroup)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet graph = new MarkSheet();
		rankType = _rankType;
		rankGroup = _rankGroup;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetGridViewType(string viewType)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet graph = new MarkSheet();
		gridViewType = viewType;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string GridViewType()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet markSheet = new MarkSheet();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		markSheet = (MarkSheet)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return gridViewType;
	}

	public static void SetMarkSheetType(string markSheet)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet graph = new MarkSheet();
		markType = markSheet;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string MarkSheetType()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet markSheet = new MarkSheet();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		markSheet = (MarkSheet)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return markType;
	}

	public static void SetGeneralView(string _generalView)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet graph = new MarkSheet();
		generalViewType = _generalView;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string GeneralView()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet markSheet = new MarkSheet();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		markSheet = (MarkSheet)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return generalViewType;
	}

	public static void SetMarkSheetViewType(string _markSheetView)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet graph = new MarkSheet();
		markSheetView = _markSheetView;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static string MarkSheetViewType()
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_MarkSheetType.tmp");
		MarkSheet markSheet = new MarkSheet();
		FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		markSheet = (MarkSheet)binaryFormatter.Deserialize(fileStream);
		fileStream.Close();
		return markSheetView;
	}

	public static DataTable GeneralMarkSheetTable(string SemesterId, string classId)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("fullName", typeof(string));
		dataTable.Columns.Add("StudentNumber", typeof(string));
		dataTable.Columns.Add("SemesterId", typeof(string));
		dataTable.Columns.Add("StreamId", typeof(string));
		dataTable.Columns.Add("SubjectId", typeof(string));
		dataTable.Columns.Add("Scores", typeof(string));
		dataTable.Columns.Add("TotalPoints", typeof(float));
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_Stud WHERE ClassId='{classId}'", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentsList");
			foreach (DataRow row in dataSet.Tables["StudentsList"].Rows)
			{
				using SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("SELECT * FROM ALevelSubjects", connectionString);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "StudentsList");
				foreach (DataRow row2 in dataSet2.Tables["StudentsList"].Rows)
				{
					using SqlConnection sqlConnection = new SqlConnection(connectionString);
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand();
					sqlCommand.Connection = sqlConnection;
					sqlCommand.CommandText = string.Format("SELECT * FROM tbl_ALevelReport WHERE StudentNumber='{0}' AND SemesterId='{1}' AND SubjectId='{2}' AND ClassId='{3}'", row["StudentNumber"], SemesterId, row2["SubjectId"], classId);
					sqlCommand.CommandType = CommandType.Text;
					using SqlCommand sqlCommand2 = sqlCommand;
					SqlDataReader sqlDataReader = sqlCommand2.ExecuteReader();
					if (sqlDataReader.HasRows)
					{
						sqlConnection.Close();
						string text = ScoreString(row["StudentNumber"].ToString(), classId, SemesterId, row2["SubjectId"].ToString());
						double num = TotalPoints(row["StudentNumber"].ToString(), classId, SemesterId, row2["SubjectId"].ToString());
						dataTable.Rows.Add(row["fullName"].ToString().ToUpper(), row["StudentNumber"].ToString().ToUpper(), SemesterId, row["StreamId"].ToString(), row2["SubjectId"].ToString().Substring(0, 3), text, num);
					}
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return dataTable;
	}

	private static float TotalPoints(string studNo, string classId, string semId, string subID)
	{
		float result = 0f;
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM tbl_ALevelReport WHERE StudentNumber='{studNo}' AND SemesterId='{semId}' AND SubjectId='{subID}' AND ClassId='{classId}'", connectionString))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelReport");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				result = (float.TryParse(row["TotalPoints"].ToString(), out result) ? result : 0f);
			}
		}
		return result;
	}

	private static string ScoreString(string studNo, string classId, string semId, string subID)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT SubjectId,Paper,ISNULL(CategoryPoints,'-') AS CategoryPoints,Grade FROM tbl_ALevelReport WHERE StudentNumber='{studNo}' AND SemesterId='{semId}' AND SubjectId='{subID}' AND ClassId='{classId}' ORDER BY SubjectId,Paper", connectionString))
		{
			using DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "ALevelReport");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			foreach (DataRow row in dataTable.Rows)
			{
				stringBuilder.Append(row["CategoryPoints"]?.ToString() + ",");
				stringBuilder2.Append(row["Grade"]?.ToString() + ",");
			}
		}
		return $"({stringBuilder.ToString().Remove(stringBuilder.Length - 1)}) {stringBuilder2.ToString().Replace(',', ' ').Trim()}";
	}
}
