using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

[Serializable]
internal class FinalAccounts
{
	private static string connectionString = DataConnection.ConnectToDatabase();

	private static SqlTransaction tra;

	private static DataSet ds;

	private static DataTable dt;

	private static double nextInvoiceNumber;

	public static string TotalIncome = "Total Income";

	public static string TotalExpenditure = "Total Expenditure";

	private static string active_debtor { get; set; }

	private static string active_debtorName { get; set; }

	private static string income_expenseType { get; set; }

	private static DateTime startDate { get; set; }

	private static DateTime endDate { get; set; }

	private static string activeBankAccount { get; set; }

	private static bool showDialog { get; set; }

	private static string activeBankName { get; set; }

	private static bool enforceBudget { get; set; }

	private static bool reportAnalysisType { get; set; }

	public static string ActiveBankName
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return activeBankName;
		}
	}

	public static string ActiveDebtor
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return active_debtor;
		}
	}

	public static string ActiveDebtorName
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return active_debtorName;
		}
	}

	public static string ActiveBankAccount
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return activeBankAccount;
		}
	}

	public static bool DetailedAnalysis
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return reportAnalysisType;
		}
	}

	public static DateTime StartDate
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return startDate;
		}
	}

	public static DateTime EndDate
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return endDate;
		}
	}

	public static string ReportType
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			FinalAccounts finalAccounts = new FinalAccounts();
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
			fileStream.Close();
			return income_expenseType;
		}
	}

	public static double NextInvoiceNumber
	{
		get
		{
			using (SqlConnection selectConnection = new SqlConnection(connectionString))
			{
				using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX(InvoiceNo) AS InvoiceNo FROM tbl_InvoiceNumbers", selectConnection);
				using DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "NewInvoice");
				DataTable dataTable = new DataTable();
				dataTable = dataSet.Tables[0];
				double result = 0.0;
				foreach (DataRow row in dataTable.Rows)
				{
					result = (double.TryParse(row["InvoiceNo"].ToString(), out result) ? result : 0.0);
				}
				nextInvoiceNumber = result + 1.0;
			}
			return nextInvoiceNumber;
		}
	}

	public static DateTime BooksBeginningDate
	{
		get
		{
			DateTime result = DateTime.Now;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT BeginningDate FROM tbl_BookingPeriod WHERE Status='Open'", connectionString))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "BooksBeginningDate");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					result = DateTime.Now;
				}
				else
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						result = Convert.ToDateTime(row["BeginningDate"]);
					}
				}
			}
			return result;
		}
	}

	public static int FinancialYear
	{
		get
		{
			int result = 1900;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT BooksPeriod FROM tbl_BookingPeriod WHERE Status='Open'", connectionString))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "BooksPeriodYear");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					result = 1900;
				}
				else
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						result = Convert.ToInt32(row["BooksPeriod"]);
					}
				}
			}
			return result;
		}
	}

	public static DateTime BooksClosinggDate
	{
		get
		{
			DateTime result = DateTime.Now;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT MAX(Id) AS Id,EndingDate FROM tbl_BookingPeriod Group By EndingDate", connectionString))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "BooksBeginningDate");
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					result = DateTime.Now;
				}
				else
				{
					foreach (DataRow row in dataSet.Tables[0].Rows)
					{
						result = Convert.ToDateTime(row["EndingDate"]);
					}
				}
			}
			return result;
		}
	}

	public static bool FinancialYearSet
	{
		get
		{
			bool result = false;
			using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT BooksPeriod FROM tbl_BookingPeriod WHERE Status='Open'", connectionString))
			{
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "BooksPeriodYear");
				result = ((dataSet.Tables[0].Rows.Count != 0) ? true : false);
			}
			return result;
		}
	}

	public static bool EnforceBudget
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			bool result = false;
			if (File.Exists(path))
			{
				FinalAccounts finalAccounts = new FinalAccounts();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				result = enforceBudget;
			}
			return result;
		}
	}

	public static bool CannotShowDialog
	{
		get
		{
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
			if (File.Exists(path))
			{
				FinalAccounts finalAccounts = new FinalAccounts();
				FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				finalAccounts = (FinalAccounts)binaryFormatter.Deserialize(fileStream);
				fileStream.Close();
				return showDialog;
			}
			return true;
		}
	}

	public static void SetActiveBank(string bankName, string bankAcc)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
		FinalAccounts graph = new FinalAccounts();
		activeBankAccount = bankAcc;
		activeBankName = bankName;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetActiveDebtor(string activeDebtor, string activeDebtorName)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
		FinalAccounts graph = new FinalAccounts();
		active_debtor = activeDebtor;
		active_debtorName = activeDebtorName;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetReportType(string reportType, DateTime _startDate, DateTime _endDate)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
		FinalAccounts graph = new FinalAccounts();
		income_expenseType = reportType;
		startDate = _startDate;
		endDate = _endDate;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetReportType(bool analysisType, string reportType, DateTime _startDate, DateTime _endDate)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
		FinalAccounts graph = new FinalAccounts();
		reportAnalysisType = analysisType;
		income_expenseType = reportType;
		startDate = _startDate;
		endDate = _endDate;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static int GetNextAccountNumber(int catId)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = 0;
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT TOP (100) PERCENT autoNo, categoryId, accNo FROM tbl_generalAccounts AS tbl_generalAccounts_1 WHERE (accNo IN (SELECT MAX(accNo) AS accNo FROM tbl_generalAccounts AS tbl_generalAccounts WHERE (categoryId = {catId})))", sqlConnection))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "_accNos");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			if (dataTable.Rows.Count == 0)
			{
				num = catId;
			}
			else
			{
				foreach (DataRow row in dataTable.Rows)
				{
					num = Convert.ToInt32(row["accNo"].ToString());
				}
			}
		}
		sqlConnection.Close();
		return num + 1;
	}

	public static string GetNextSubAccountNumber(int catId, int accNo)
	{
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT MAX(auto) AS id,subAccountNo FROM tbl_generalAccounts_Sub WHERE accNo={accNo} GROUP BY subAccountNo,accNo", connectionString);
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "LastNo");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		string text = "-0000";
		foreach (DataRow row in dataTable.Rows)
		{
			text = row["subAccountNo"].ToString();
		}
		int num = 0;
		int num2 = text.IndexOf('-') + 1;
		string s = text.Substring(num2, text.Length - num2);
		int result = (int.TryParse(s, out result) ? result : 9999);
		string text2 = ((result == 9999) ? 1 : (result + 1)).ToString();
		string text3 = string.Empty;
		if (text2.Length == 1)
		{
			text3 = "000" + text2;
		}
		else if (text2.Length == 2)
		{
			text3 = "00" + text2;
		}
		else if (text2.Length == 3)
		{
			text3 = "0" + text2;
		}
		else if (text2.Length == 4)
		{
			text3 = text2;
		}
		return accNo + "-" + text3;
	}

	public static void LoadAccounts(ComboBoxEdit comboBox)
	{
		try
		{
			using SqlConnection selectConnection = new SqlConnection(connectionString);
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_account_types", selectConnection);
			ds = new DataSet();
			sqlDataAdapter.Fill(ds, "_allAccounts");
			dt = new DataTable();
			dt = ds.Tables[0];
			comboBox.Properties.Items.Clear();
			foreach (DataRow row in dt.Rows)
			{
				comboBox.Properties.Items.Add(row["accountName"]);
			}
			comboBox.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void InitializeInvoice(double invoiceNo, string supplier)
	{
		using SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_InvoiceNumbers (InvoiceNo,supplier)VALUES(@InvoiceNo,@supplier)"
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@InvoiceNo", SqlDbType.Float);
		sqlParameter.Value = invoiceNo;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@supplier", SqlDbType.VarChar, 80);
		sqlParameter.Value = supplier;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
	}

	public static string CategoryNumber(ComboBoxEdit comboBox)
	{
		string empty = string.Empty;
		int selectedIndex = comboBox.SelectedIndex;
		DataRow dataRow = dt.Rows[selectedIndex];
		return dataRow["categoryId"].ToString();
	}

	private static void InitializeStockCategories()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[1] { "PIK Items" });
			for (int i = 0; i < 1; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_StockCategories WHERE category='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_StockCategories (category) VALUES (@category)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@category", SqlDbType.VarChar, 30);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
					sqlConnection2.Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeShareCapital()
	{
		try
		{
			using SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_generalAccounts_Sub WHERE subAccountNo='7001-0001'",
				CommandType = CommandType.Text
			};
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				return;
			}
			using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
			sqlConnection2.Open();
			using (SqlCommand sqlCommand2 = new SqlCommand
			{
				Connection = sqlConnection2,
				CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
				CommandType = CommandType.Text
			})
			{
				SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
				sqlParameter.Value = 7001;
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
				sqlParameter.Value = "7001-0001";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlParameter = sqlCommand2.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 50);
				sqlParameter.Value = "Capital";
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand2.ExecuteNonQuery();
			}
			sqlConnection2.Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeAccountTypes()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[7] { "1.INCOME", "2.EXPENSES", "4.CURRENT ASSETS", "3.FIXED ASSETS", "6.CURRENT LIABILITIES", "7.LONG-TERM LIABILITIES", "5.FINANCED BY" });
			List<string> list2 = new List<string>();
			list2.AddRange(new string[7] { "INCOME & EXPENSES", "INCOME & EXPENSES", "ASSETS", "ASSETS", "LIABILITIES & EQUITY", "LIABILITIES & EQUITY", "LIABILITIES & EQUITY" });
			List<int> list3 = new List<int>();
			list3.AddRange(new int[7] { 1000, 2000, 3000, 4000, 5000, 6000, 7000 });
			List<string> list4 = new List<string>();
			list4.AddRange(new string[7] { "Credit Balances", "Debit Balances", "Debit Balances", "Debit Balances", "Credit Balances", "Credit Balances", "Credit Balances" });
			for (int i = 0; i < 7; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_account_types WHERE categoryId={list3[i]}",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_account_types (categoryId,accountName,Category,SuperGroup)VALUES(@categoryId,@accountName,@Category,@SuperGroup)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter.Value = list3[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accountName", SqlDbType.VarChar, 50);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Category", SqlDbType.VarChar, 20);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@SuperGroup", SqlDbType.VarChar, 20);
					sqlParameter.Value = list4[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeCurrentAssets()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[5] { "Bank Accounts", "Cash", "Mobile Money", "Accounts Receivable", "Others" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[5] { 3001, 3002, 3003, 3004, 3005 });
			for (int i = 0; i < 5; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=3000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				if (list[i] == "Cash")
				{
					sqlConnection2.Open();
					tra = sqlConnection2.BeginTransaction();
					int num = list2[i];
					string nextSubAccountNumber = GetNextSubAccountNumber(3000, num);
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = tra,
						CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
						sqlParameter.Value = 3000;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
						sqlParameter.Value = num;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
						sqlParameter.Value = list[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = tra,
						CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.BigInt);
						sqlParameter2.Value = num;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
						sqlParameter2.Value = nextSubAccountNumber;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
						sqlParameter2.Value = "Cash At Hand";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					tra.Commit();
					sqlConnection2.Close();
				}
				else if (list[i] == "Accounts Receivable")
				{
					sqlConnection2.Open();
					tra = sqlConnection2.BeginTransaction();
					int num2 = list2[i];
					string nextSubAccountNumber2 = GetNextSubAccountNumber(3000, num2);
					using (SqlCommand sqlCommand4 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = tra,
						CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter3 = sqlCommand4.Parameters.Add("@categoryId", SqlDbType.Int);
						sqlParameter3.Value = 3000;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.Int);
						sqlParameter3.Value = num2;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand4.Parameters.Add("@accName", SqlDbType.VarChar, 50);
						sqlParameter3.Value = list[i];
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlCommand4.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = tra,
						CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter4 = sqlCommand5.Parameters.Add("@accNo", SqlDbType.BigInt);
						sqlParameter4.Value = num2;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
						sqlParameter4.Value = nextSubAccountNumber2;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
						sqlParameter4.Value = "Fees Receivable";
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlCommand5.ExecuteNonQuery();
					}
					tra.Commit();
					sqlConnection2.Close();
				}
				else
				{
					sqlConnection2.Open();
					using SqlCommand sqlCommand6 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter5 = sqlCommand6.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter5.Value = 3000;
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand6.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter5.Value = list2[i];
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlParameter5 = sqlCommand6.Parameters.Add("@accName", SqlDbType.VarChar, 50);
					sqlParameter5.Value = list[i];
					sqlParameter5.Direction = ParameterDirection.Input;
					sqlCommand6.ExecuteNonQuery();
					sqlConnection2.Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeRepresentatedBy()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[2] { "Share Capital", "Revenue Reserve" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[2] { 7001, 7002 });
			for (int i = 0; i < 2; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=7000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter.Value = 7000;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeFixedAssets()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[1] { "Furniture" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[1] { 4001 });
			for (int i = 0; i < 1; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=4000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter.Value = 4000;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeCurrentLiabilities()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[5] { "Employees", "Sundry Creditors", "Suppliers/Service Providers", "Bills Payable", "Short-term Loans" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[5] { 5001, 5002, 5003, 5004, 5005 });
			for (int i = 0; i < 5; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=5000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				if (list[i] == "Sundry Creditors")
				{
					sqlConnection2.Open();
					tra = sqlConnection2.BeginTransaction();
					int num = list2[i];
					string nextSubAccountNumber = GetNextSubAccountNumber(5000, num);
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = tra,
						CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
						sqlParameter.Value = 5000;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
						sqlParameter.Value = num;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
						sqlParameter.Value = list[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand3 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = tra,
						CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.BigInt);
						sqlParameter2.Value = num;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
						sqlParameter2.Value = nextSubAccountNumber;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand3.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
						sqlParameter2.Value = "Prepaid Fees";
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlCommand3.ExecuteNonQuery();
					}
					tra.Commit();
					sqlConnection2.Close();
					continue;
				}
				sqlConnection2.Open();
				using SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter3 = sqlCommand4.Parameters.Add("@categoryId", SqlDbType.Int);
				sqlParameter3.Value = 5000;
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.Int);
				sqlParameter3.Value = list2[i];
				sqlParameter3.Direction = ParameterDirection.Input;
				sqlParameter3 = sqlCommand4.Parameters.Add("@accName", SqlDbType.VarChar, 50);
				sqlParameter3.Value = list[i];
				sqlParameter3.Direction = ParameterDirection.Input;
				if (sqlCommand4.ExecuteNonQuery() > 0)
				{
					sqlConnection2.Close();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeLongTermLiabilities()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[2] { "Accummulated Depreciation", "Loans" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[2] { 6001, 6002 });
			for (int i = 0; i < 2; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=6000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using SqlConnection sqlConnection2 = new SqlConnection(connectionString);
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter.Value = 6000;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter.Value = list2[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
					sqlParameter.Value = list[i];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeIncomesAccount()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[2] { "Student Payments", "School Developments" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[2] { 1001, 1002 });
			for (int i = 0; i < 2; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=1000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				if (list[i] == "Student Payments")
				{
					SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
						sqlParameter.Value = 1000;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
						sqlParameter.Value = 1001;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
						sqlParameter.Value = list[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
						sqlConnection2.Close();
					}
					string[] array = new string[3] { "Fees", "Fees Arrears", "B/F" };
					for (int j = 0; j < array.Length; j++)
					{
						int num = list2[i];
						string nextSubAccountNumber = GetNextSubAccountNumber(1000, num);
						using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
						sqlConnection3.Open();
						tra = sqlConnection3.BeginTransaction();
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection3,
							Transaction = tra,
							CommandText = $"DELETE FROM tbl_generalAccounts_Sub WHERE subAccountNo={nextSubAccountNumber} AND SubAccoutName='{list[i]}'",
							CommandType = CommandType.Text
						})
						{
							sqlCommand3.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand4 = new SqlCommand
						{
							Connection = sqlConnection3,
							Transaction = tra,
							CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.BigInt);
							sqlParameter2.Value = num;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
							sqlParameter2.Value = nextSubAccountNumber;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand4.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
							sqlParameter2.Value = array[j];
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						tra.Commit();
						sqlConnection3.Close();
					}
					continue;
				}
				using SqlConnection sqlConnection4 = new SqlConnection(connectionString);
				sqlConnection4.Open();
				using (SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection4,
					CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@categoryId", SqlDbType.Int);
					sqlParameter3.Value = 1000;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand5.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter3.Value = list2[i];
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlParameter3 = sqlCommand5.Parameters.Add("@accName", SqlDbType.VarChar, 50);
					sqlParameter3.Value = list[i];
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlCommand5.ExecuteNonQuery();
				}
				sqlConnection4.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void InitializeExpensesAccount()
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(new string[4] { "Salary and Allowances", "Loan Payment", "Depreciation", "Bursaries/Discounts" });
			List<int> list2 = new List<int>();
			list2.AddRange(new int[4] { 2001, 2002, 2003, 2004 });
			for (int i = 0; i < 4; i++)
			{
				using SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_generalAccounts WHERE categoryId=2000 AND accName='{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					continue;
				}
				using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
				{
					sqlConnection2.Open();
					using (SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "INSERT INTO tbl_generalAccounts (categoryId,accNo,accName)VALUES(@categoryId,@accNo,@accName)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@categoryId", SqlDbType.Int);
						sqlParameter.Value = 2000;
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.Int);
						sqlParameter.Value = list2[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlParameter = sqlCommand2.Parameters.Add("@accName", SqlDbType.VarChar, 50);
						sqlParameter.Value = list[i];
						sqlParameter.Direction = ParameterDirection.Input;
						sqlCommand2.ExecuteNonQuery();
					}
					sqlConnection2.Close();
				}
				if (!(list[i] == "Salary and Allowances"))
				{
					continue;
				}
				using SqlConnection sqlConnection3 = new SqlConnection(connectionString);
				sqlConnection3.Open();
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"SELECT * FROM tbl_SubVote WHERE accNo = '{list2[i]}' AND SubVotename = '{list[i]}'",
					CommandType = CommandType.Text
				};
				using SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
				if (!sqlDataReader2.HasRows)
				{
					SqlConnection sqlConnection4 = new SqlConnection(connectionString);
					sqlConnection4.Open();
					using SqlCommand sqlCommand4 = new SqlCommand
					{
						Connection = sqlConnection4,
						CommandText = "INSERT INTO tbl_SubVote (accNo,SubVotename) VALUES (@accNo,@SubVotename)",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.Int);
					sqlParameter2.Value = list2[i];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand4.Parameters.Add("@SubVotename", SqlDbType.VarChar, 40);
					sqlParameter2.Value = list[i];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand4.ExecuteNonQuery();
				}
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	public static void InitializeChartsOfAccounts()
	{
		InitializeAccountTypes();
		InitializeCurrentAssets();
		InitializeRepresentatedBy();
		InitializeShareCapital();
		InitializeCurrentLiabilities();
		InitializeLongTermLiabilities();
		InitializeFixedAssets();
		InitializeIncomesAccount();
		InitializeExpensesAccount();
		InitializeStockCategories();
	}

	public static double AccountStandingBalance(int AccNo)
	{
		double result = 0.0;
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ClosingBalance FROM tbl_generalAccounts WHERE accNo={AccNo}", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (double.TryParse(row["ClosingBalance"].ToString(), out result) ? result : 0.0);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	public static double CurrentStudentStandingBalance(string StudNo, string studentClass)
	{
		double result = 0.0;
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT cashOnAccount FROM tbl_Stud WHERE StudentNumber='{StudNo}'", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "cashOnAccount");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (double.TryParse(row["cashOnAccount"].ToString(), out result) ? result : 0.0);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	public static double FormerStudentStandingBalance(string StudNo)
	{
		double result = 0.0;
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT cashOnAccount FROM tbl_oldStudents WHERE StudentNumber='{StudNo}'", connectionString);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "cashOnAccount");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				result = (double.TryParse(row["cashOnAccount"].ToString(), out result) ? result : 0.0);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	public static void ExpensesInitialization()
	{
		bool flag = false;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_EnforceBudget", connectionString);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "budgetItems");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		if (dataTable.Rows.Count == 0)
		{
			flag = false;
		}
		else
		{
			foreach (DataRow row in dataTable.Rows)
			{
				flag = Convert.ToBoolean(row["IsForced"]);
			}
		}
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
		FinalAccounts graph = new FinalAccounts();
		enforceBudget = flag;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void SetDialogShowProperty(bool _showDialog)
	{
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_FinalAccounts_Ultimate.tmp");
		FinalAccounts graph = new FinalAccounts();
		showDialog = _showDialog;
		FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}
}
