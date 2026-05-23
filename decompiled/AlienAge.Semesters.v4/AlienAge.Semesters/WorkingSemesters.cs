using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace AlienAge.Semesters;

[Serializable]
public class WorkingSemesters
{
	public string SemesterList { get; set; }

	public string YearList { get; set; }

	public static void GetSemesters(ComboBoxEdit[] cboSemester)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_PromoStamps WHERE SemesterId LIKE '%Term%' ORDER BY id", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StoredSemesters");
			for (int i = 0; i < cboSemester.Length; i++)
			{
				cboSemester[i].Properties.Items.Clear();
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					cboSemester[i].Properties.Items.Add(row["SemesterId"]);
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	public static void GetSemestersI(ComboBoxEdit[] cboSemester)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_PromoStamps WHERE SemesterId LIKE '%SEM%' ORDER BY id", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StoredSemesters");
			for (int i = 0; i < cboSemester.Length; i++)
			{
				cboSemester[i].Properties.Items.Clear();
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					cboSemester[i].Properties.Items.Add(row["SemesterId"]);
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	public static void GetSemesters(RepositoryItemComboBox cboSemester)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_PromoStamps WHERE SemesterId LIKE '%Term%' ORDER BY id", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StoredSemesters");
			cboSemester.Items.Clear();
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				cboSemester.Items.Add(row["SemesterId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	public static void GetSemestersI(RepositoryItemComboBox cboSemester)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_PromoStamps WHERE SemesterId LIKE '%SEM%' ORDER BY id", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StoredSemesters");
			cboSemester.Items.Clear();
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				cboSemester.Items.Add(row["SemesterId"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	public static void GetYears(RepositoryItemComboBox cboYears)
	{
		try
		{
			WorkingSemesters workingSemesters = new WorkingSemesters();
			using FileStream fileStream = new FileStream("WorkingSemesters.bin", FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			workingSemesters = (WorkingSemesters)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			string[] array = workingSemesters.YearList.Split();
			foreach (string text in array)
			{
				cboYears.Items.AddRange(new object[1] { text });
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	public static void GetYears(ComboBoxEdit cboYears)
	{
		try
		{
			WorkingSemesters workingSemesters = new WorkingSemesters();
			using FileStream fileStream = new FileStream("WorkingSemesters.bin", FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			workingSemesters = (WorkingSemesters)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			cboYears.Properties.Items.Clear();
			string[] array = workingSemesters.YearList.Split();
			foreach (string text in array)
			{
				cboYears.Properties.Items.AddRange(new object[1] { text });
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics");
		}
	}

	public static void SetDefaultTermsToComboBox(ComboBoxEdit[] combo)
	{
		string selectedItem = "";
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_ActiveSemester", DataConnection.ConnectToDatabase());
			try
			{
				DataSet dataSet = new DataSet();
				try
				{
					sqlDataAdapter.Fill(dataSet, "ActiveSemester");
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						foreach (DataRow row in dataSet.Tables[0].Rows)
						{
							selectedItem = row["semester"].ToString();
						}
					}
					else
					{
						selectedItem = "Semester No Set!";
					}
					for (int i = 0; i < combo.Length; i++)
					{
						combo[i].SelectedItem = selectedItem;
					}
				}
				finally
				{
					((IDisposable)dataSet)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)(object)sqlDataAdapter)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static string GetWorkingSemester()
	{
		string result = "";
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_ActiveSemester", DataConnection.ConnectToDatabase());
			try
			{
				DataSet dataSet = new DataSet();
				try
				{
					sqlDataAdapter.Fill(dataSet, "ActiveSemester");
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						foreach (DataRow row in dataSet.Tables[0].Rows)
						{
							result = row["semester"].ToString();
						}
					}
					else
					{
						result = "Semester No Set!";
					}
				}
				finally
				{
					((IDisposable)dataSet)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)(object)sqlDataAdapter)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	public static void SetWorkingSemester(string semester)
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_ActiveSemester",
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
					CommandText = "UPDATE tbl_ActiveSemester SET semester=@semester",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@semester", SqlDbType.VarChar, 12);
				sqlParameter.Value = semester;
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
				CommandText = "INSERT INTO tbl_ActiveSemester (semester) VALUES (@semester)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@semester", SqlDbType.VarChar, 12);
			sqlParameter2.Value = semester;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
			sqlConnection3.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static string PreviousSemester()
	{
		string workingSemester = GetWorkingSemester();
		string text = workingSemester.Substring(0, workingSemester.IndexOf('-'));
		int num = Convert.ToInt32(workingSemester.Substring(workingSemester.IndexOf('-') + 1, 4));
		string result = "";
		if (workingSemester.Length == 10)
		{
			result = "TermIII-" + (num - 1);
		}
		else if (workingSemester.Length == 11)
		{
			result = "TermI-" + num;
		}
		else if (workingSemester.Length == 12)
		{
			result = "TermII-" + num;
		}
		return result;
	}

	public static string PreviousSemesterI()
	{
		string workingSemester = GetWorkingSemester();
		string text = workingSemester.Substring(0, workingSemester.IndexOf('-'));
		int num = Convert.ToInt32(workingSemester.Substring(workingSemester.IndexOf('-') + 1, 4));
		string result = "";
		if (workingSemester.Length == 9)
		{
			result = "SEMII-" + (num - 1);
		}
		else if (workingSemester.Length == 10)
		{
			result = "SEMI-" + num;
		}
		return result;
	}
}
