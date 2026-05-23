using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace I_Xtreme;

[Serializable]
internal class EmployeeDebts
{
	private static SqlTransaction trans;

	private static SqlTransaction _trans;

	private static SqlTransaction _transaction;

	private static SqlTransaction _transactions;

	private static SqlTransaction tra;

	private static SqlTransaction T;

	private static double appendTo { get; set; }

	private static double appendCategory { get; set; }

	private static double requiredAMount { get; set; }

	public static string EmployeeNumbers { get; set; }

	public static string Months { get; set; }

	public static string Particulars { get; set; }

	public static CheckedListBoxControl chkEmployees { get; set; }

	public static double AppendTo
	{
		get
		{
			EmployeeDebts employeeDebts = new EmployeeDebts();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
			FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			employeeDebts = (EmployeeDebts)binaryFormatter.Deserialize(serializationStream);
			return appendTo;
		}
	}

	public static double AppendItems
	{
		get
		{
			EmployeeDebts employeeDebts = new EmployeeDebts();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
			FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			employeeDebts = (EmployeeDebts)binaryFormatter.Deserialize(serializationStream);
			return appendCategory;
		}
	}

	public static double RequiredAmount
	{
		get
		{
			EmployeeDebts employeeDebts = new EmployeeDebts();
			string tempPath = Path.GetTempPath();
			string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
			FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			employeeDebts = (EmployeeDebts)binaryFormatter.Deserialize(serializationStream);
			return requiredAMount;
		}
	}

	public static string Month()
	{
		EmployeeDebts employeeDebts = new EmployeeDebts();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
		using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			employeeDebts = (EmployeeDebts)binaryFormatter.Deserialize(serializationStream);
		}
		return Months;
	}

	public static string EmployeeNumber()
	{
		EmployeeDebts employeeDebts = new EmployeeDebts();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
		using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			employeeDebts = (EmployeeDebts)binaryFormatter.Deserialize(serializationStream);
		}
		return EmployeeNumbers;
	}

	public static string Particular()
	{
		EmployeeDebts employeeDebts = new EmployeeDebts();
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
		using (FileStream serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			employeeDebts = (EmployeeDebts)binaryFormatter.Deserialize(serializationStream);
		}
		return Particulars;
	}

	public static void AppendToCustomInit(CheckedListBoxControl chkCustomGroup, double appedingTo, double appendingCategory, double DebtAmout, string ItemRequired, string currentMonth)
	{
		EmployeeDebts graph = new EmployeeDebts();
		appendTo = appedingTo;
		appendCategory = appendingCategory;
		requiredAMount = DebtAmout;
		Particulars = ItemRequired;
		Months = currentMonth;
		chkEmployees = new CheckedListBoxControl();
		foreach (CheckedListBoxItem item in (IEnumerable)chkCustomGroup.CheckedItems)
		{
			chkEmployees.Items.Add(item.ToString());
		}
		chkEmployees.CheckAll();
		string tempPath = Path.GetTempPath();
		using FileStream fileStream = new FileStream(Path.Combine(tempPath, "SMD_EmployeeDebts.tmp"), FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void AppendToSingleInit(int appendingTo, int appendingCategory, double DebtAmount, string RequiredItem, string CurrentMonth, string EmployeeNumber)
	{
		EmployeeDebts graph = new EmployeeDebts();
		appendTo = appendingTo;
		appendCategory = appendingCategory;
		requiredAMount = DebtAmount;
		Particulars = RequiredItem;
		Months = CurrentMonth;
		EmployeeNumbers = EmployeeNumber;
		string tempPath = Path.GetTempPath();
		string path = Path.Combine(tempPath, "SMD_EmployeeDebts.tmp");
		using FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		binaryFormatter.Serialize(fileStream, graph);
		fileStream.Close();
	}

	public static void AppendEmployeeDebts()
	{
		string captureDate = CaptureDate.GetCaptureDate();
		if (AppendTo == 0.0)
		{
			try
			{
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = $"SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{EmployeeNumber()}'",
					CommandType = CommandType.Text
				};
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (sqlDataReader.HasRows)
				{
					sqlConnection.Close();
					SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = $"SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{EmployeeNumber()}' AND Particulars='{Particular()}' AND Month='{Month()}'",
						CommandType = CommandType.Text
					};
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					if (sqlDataReader2.HasRows)
					{
						return;
					}
					using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					string selectCommandText = $"SELECT TOP (100) PERCENT Ref, EmployeeNumber, Date, Particulars, Month, Debit, Credit, Balance, capDate FROM tbl_emplDebts AS tbl_emplDebts_1 WHERE (Ref IN (SELECT MAX(Ref) AS Ref FROM tbl_emplDebts AS tbl_emplDebts WHERE (EmployeeNumber = '{EmployeeNumber()}')))";
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, selectConnection);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					DataTable dataTable = new DataTable();
					dataTable = dataSet.Tables[0];
					IEnumerator enumerator = dataTable.Rows.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							DataRow dataRow = (DataRow)enumerator.Current;
							double num = Convert.ToDouble(dataRow["Balance"]);
							double requiredAmount = RequiredAmount;
							double num2 = num + requiredAmount;
							DateTime now = DateTime.Now;
							using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection3.Open();
							trans = sqlConnection3.BeginTransaction();
							using (SqlCommand sqlCommand3 = new SqlCommand
							{
								Connection = sqlConnection3,
								Transaction = trans,
								CommandText = "INSERT INTO tbl_emplDebts (EmployeeNumber,Date,Particulars,Month,Debit,Credit,Balance,capDate) VALUES (@EmployeeNumber,@Date,@Particulars,@Month,@Debit,@Credit,@Balance,@capDate)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter = sqlCommand3.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50);
								sqlParameter.Value = EmployeeNumber();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@Date", SqlDbType.DateTime);
								sqlParameter.Value = now.ToShortDateString();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
								sqlParameter.Value = Particular();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@Month", SqlDbType.VarChar, 15);
								sqlParameter.Value = Month();
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@Debit", SqlDbType.Money);
								sqlParameter.Value = 0;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@Credit", SqlDbType.Money);
								sqlParameter.Value = RequiredAmount;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@Balance", SqlDbType.Money);
								sqlParameter.Value = num2;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand3.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
								sqlParameter.Value = captureDate;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlCommand3.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand4 = new SqlCommand
							{
								Transaction = trans,
								Connection = sqlConnection3,
								CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter2 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.Int);
								sqlParameter2.Value = 5001;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
								sqlParameter2.Value = Particular();
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@_date", SqlDbType.DateTime);
								sqlParameter2.Value = now.ToShortDateString();
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@month", SqlDbType.VarChar, 9);
								sqlParameter2.Value = now.ToString("MMMM");
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@year", SqlDbType.Int);
								sqlParameter2.Value = now.Year;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@debit", SqlDbType.Money);
								sqlParameter2.Value = RequiredAmount;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@credit", SqlDbType.Money);
								sqlParameter2.Value = 0;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlParameter2 = sqlCommand4.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
								sqlParameter2.Value = captureDate;
								sqlParameter2.Direction = ParameterDirection.Input;
								sqlCommand4.ExecuteNonQuery();
							}
							trans.Commit();
							sqlConnection3.Close();
							return;
						}
						return;
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
				sqlConnection.Close();
				using SqlConnection selectConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText2 = $"SELECT * FROM staff WHERE StaffId='{EmployeeNumber()}' AND status='Working'";
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText2, selectConnection2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "employees");
				DataTable dataTable2 = new DataTable();
				dataTable2 = dataSet2.Tables[0];
				DateTime now2 = DateTime.Now;
				IEnumerator enumerator2 = dataTable2.Rows.GetEnumerator();
				try
				{
					if (enumerator2.MoveNext())
					{
						DataRow dataRow2 = (DataRow)enumerator2.Current;
						using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection4.Open();
						_trans = sqlConnection4.BeginTransaction();
						using (SqlCommand sqlCommand5 = new SqlCommand
						{
							Connection = sqlConnection4,
							Transaction = _trans,
							CommandText = "INSERT INTO tbl_emplDebts (EmployeeNumber,Date,Particulars,Month,Debit,Credit,Balance,capDate) VALUES (@EmployeeNumber,@Date,@Particulars,@Month,@Debit,@Credit,@Balance,@capDate)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50);
							sqlParameter3.Value = EmployeeNumber();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@Date", SqlDbType.DateTime);
							sqlParameter3.Value = now2.ToShortDateString();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
							sqlParameter3.Value = Particular();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@Month", SqlDbType.VarChar, 15);
							sqlParameter3.Value = Month();
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@Debit", SqlDbType.VarChar, 50);
							sqlParameter3.Value = 0;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter3.Value = RequiredAmount;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@Balance", SqlDbType.Money);
							sqlParameter3.Value = RequiredAmount;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
							sqlParameter3.Value = captureDate;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand5.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand6 = new SqlCommand
						{
							Transaction = _trans,
							Connection = sqlConnection4,
							CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter4 = sqlCommand6.Parameters.Add("@accNo", SqlDbType.Int);
							sqlParameter4.Value = 5001;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
							sqlParameter4.Value = Particular();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@_date", SqlDbType.DateTime);
							sqlParameter4.Value = now2.ToShortDateString();
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@month", SqlDbType.VarChar, 9);
							sqlParameter4.Value = now2.ToString("MMMM");
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@year", SqlDbType.Int);
							sqlParameter4.Value = now2.Year;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@debit", SqlDbType.Money);
							sqlParameter4.Value = RequiredAmount;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@credit", SqlDbType.Money);
							sqlParameter4.Value = 0;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlParameter4 = sqlCommand6.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
							sqlParameter4.Value = captureDate;
							sqlParameter4.Direction = ParameterDirection.Input;
							sqlCommand6.ExecuteNonQuery();
						}
						_trans.Commit();
						sqlConnection4.Close();
						return;
					}
					return;
				}
				finally
				{
					IDisposable disposable2 = enumerator2 as IDisposable;
					if (disposable2 != null)
					{
						disposable2.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		if (AppendItems == 0.0)
		{
			try
			{
				string empty = string.Empty;
				foreach (CheckedListBoxItem item in (IEnumerable)chkEmployees.CheckedItems)
				{
					char value = '(';
					string text = item.ToString().Substring(0, item.ToString().IndexOf(value));
					empty = text.TrimEnd();
					using SqlConnection selectConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
					string selectCommandText3 = $"SELECT StaffId,NetPay FROM staff WHERE StaffId='{empty}'";
					using SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommandText3, selectConnection3);
					using DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "EmployeeSalary");
					DataTable dataTable3 = new DataTable();
					dataTable3 = dataSet3.Tables[0];
					foreach (DataRow row in dataTable3.Rows)
					{
						using SqlConnection sqlConnection5 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection5.Open();
						using SqlCommand sqlCommand7 = new SqlCommand
						{
							Connection = sqlConnection5,
							CommandText = string.Format("SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{0}'", row["StaffId"]),
							CommandType = CommandType.Text
						};
						SqlDataReader sqlDataReader3 = sqlCommand7.ExecuteReader();
						if (sqlDataReader3.HasRows)
						{
							sqlConnection5.Close();
							SqlConnection sqlConnection6 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection6.Open();
							SqlCommand sqlCommand8 = new SqlCommand
							{
								Connection = sqlConnection6,
								CommandText = string.Format("SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{0}' AND Particulars='{1}' AND Month='{2}'", row["StaffId"], Particular(), Month()),
								CommandType = CommandType.Text
							};
							SqlDataReader sqlDataReader4 = sqlCommand8.ExecuteReader();
							if (sqlDataReader4.HasRows)
							{
								sqlConnection6.Close();
							}
							else
							{
								sqlConnection6.Close();
								using SqlConnection selectConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
								string selectCommandText4 = string.Format("SELECT TOP (100) PERCENT Ref, EmployeeNumber, Date, Particulars, Month, Debit, Credit, Balance, capDate FROM tbl_emplDebts AS tbl_emplDebts_1 WHERE (Ref IN (SELECT MAX(Ref) AS Ref FROM tbl_emplDebts AS tbl_emplDebts WHERE (EmployeeNumber = '{0}')))", row["StaffId"]);
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText4, selectConnection4);
								DataSet dataSet4 = new DataSet();
								sqlDataAdapter4.Fill(dataSet4);
								DataTable dataTable4 = new DataTable();
								dataTable4 = dataSet4.Tables[0];
								DateTime now3 = DateTime.Now;
								IEnumerator enumerator5 = dataTable4.Rows.GetEnumerator();
								try
								{
									if (enumerator5.MoveNext())
									{
										DataRow dataRow4 = (DataRow)enumerator5.Current;
										double num3 = Convert.ToDouble(dataRow4["Balance"]);
										double num4 = Convert.ToDouble(row["NetPay"]);
										double num5 = num3 + num4;
										using SqlConnection sqlConnection7 = new SqlConnection(DataConnection.ConnectToDatabase());
										sqlConnection7.Open();
										_transaction = sqlConnection7.BeginTransaction();
										using (SqlCommand sqlCommand9 = new SqlCommand
										{
											Connection = sqlConnection7,
											Transaction = _transaction,
											CommandText = "INSERT INTO tbl_emplDebts (EmployeeNumber,Date,Particulars,Month,Debit,Credit,Balance,capDate) VALUES (@EmployeeNumber,@Date,@Particulars,@Month,@Debit,@Credit,@Balance,@capDate)",
											CommandType = CommandType.Text
										})
										{
											SqlParameter sqlParameter5 = sqlCommand9.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50);
											sqlParameter5.Value = row["StaffId"];
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@Date", SqlDbType.DateTime);
											sqlParameter5.Value = now3.ToShortDateString();
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
											sqlParameter5.Value = Particular();
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@Month", SqlDbType.VarChar, 15);
											sqlParameter5.Value = Month();
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@Debit", SqlDbType.Money);
											sqlParameter5.Value = 0;
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@Credit", SqlDbType.Money);
											sqlParameter5.Value = Convert.ToDouble(row["NetPay"]);
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@Balance", SqlDbType.Money);
											sqlParameter5.Value = num5;
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlParameter5 = sqlCommand9.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
											sqlParameter5.Value = captureDate;
											sqlParameter5.Direction = ParameterDirection.Input;
											sqlCommand9.ExecuteNonQuery();
										}
										using (SqlCommand sqlCommand10 = new SqlCommand
										{
											Transaction = _transaction,
											Connection = sqlConnection7,
											CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
											CommandType = CommandType.Text
										})
										{
											SqlParameter sqlParameter6 = sqlCommand10.Parameters.Add("@accNo", SqlDbType.Int);
											sqlParameter6.Value = 5001;
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
											sqlParameter6.Value = Particular();
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@_date", SqlDbType.DateTime);
											sqlParameter6.Value = now3.ToShortDateString();
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@month", SqlDbType.VarChar, 9);
											sqlParameter6.Value = now3.ToString("MMMM");
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@year", SqlDbType.Int);
											sqlParameter6.Value = now3.Year;
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@debit", SqlDbType.Money);
											sqlParameter6.Value = RequiredAmount;
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@credit", SqlDbType.Money);
											sqlParameter6.Value = 0;
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlParameter6 = sqlCommand10.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
											sqlParameter6.Value = captureDate;
											sqlParameter6.Direction = ParameterDirection.Input;
											sqlCommand10.ExecuteNonQuery();
										}
										_transaction.Commit();
										sqlConnection7.Close();
									}
								}
								finally
								{
									IDisposable disposable3 = enumerator5 as IDisposable;
									if (disposable3 != null)
									{
										disposable3.Dispose();
									}
								}
							}
						}
						else
						{
							sqlConnection5.Close();
							DateTime now4 = DateTime.Now;
							using SqlConnection sqlConnection8 = new SqlConnection(DataConnection.ConnectToDatabase());
							sqlConnection8.Open();
							_transactions = sqlConnection8.BeginTransaction();
							using (SqlCommand sqlCommand11 = new SqlCommand
							{
								Connection = sqlConnection8,
								Transaction = _transactions,
								CommandText = "INSERT INTO tbl_emplDebts (EmployeeNumber,Date,Particulars,Month,Debit,Credit,Balance,capDate) VALUES (@EmployeeNumber,@Date,@Particulars,@Month,@Debit,@Credit,@Balance,@capDate)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter7 = sqlCommand11.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50);
								sqlParameter7.Value = row["StaffId"];
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@Date", SqlDbType.DateTime);
								sqlParameter7.Value = now4.ToShortDateString();
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
								sqlParameter7.Value = Particular();
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@Month", SqlDbType.VarChar, 15);
								sqlParameter7.Value = Month();
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@Debit", SqlDbType.VarChar, 50);
								sqlParameter7.Value = 0;
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@Credit", SqlDbType.Money);
								sqlParameter7.Value = Convert.ToDouble(row["NetPay"]);
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@Balance", SqlDbType.Money);
								sqlParameter7.Value = Convert.ToDouble(row["NetPay"]);
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlParameter7 = sqlCommand11.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
								sqlParameter7.Value = captureDate;
								sqlParameter7.Direction = ParameterDirection.Input;
								sqlCommand11.ExecuteNonQuery();
							}
							using (SqlCommand sqlCommand12 = new SqlCommand
							{
								Transaction = _transactions,
								Connection = sqlConnection8,
								CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
								CommandType = CommandType.Text
							})
							{
								SqlParameter sqlParameter8 = sqlCommand12.Parameters.Add("@accNo", SqlDbType.Int);
								sqlParameter8.Value = 5001;
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
								sqlParameter8.Value = Particular();
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@_date", SqlDbType.DateTime);
								sqlParameter8.Value = now4.ToShortDateString();
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@month", SqlDbType.VarChar, 9);
								sqlParameter8.Value = now4.ToString("MMMM");
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@year", SqlDbType.Int);
								sqlParameter8.Value = now4.Year;
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@debit", SqlDbType.Money);
								sqlParameter8.Value = RequiredAmount;
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@credit", SqlDbType.Money);
								sqlParameter8.Value = 0;
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlParameter8 = sqlCommand12.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
								sqlParameter8.Value = captureDate;
								sqlParameter8.Direction = ParameterDirection.Input;
								sqlCommand12.ExecuteNonQuery();
							}
							_transactions.Commit();
							sqlConnection8.Close();
						}
					}
				}
				return;
			}
			catch (Exception ex2)
			{
				XtraMessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		try
		{
			string empty2 = string.Empty;
			foreach (CheckedListBoxItem item2 in (IEnumerable)chkEmployees.CheckedItems)
			{
				char value2 = '(';
				string text2 = item2.ToString().Substring(0, item2.ToString().IndexOf(value2));
				empty2 = text2.TrimEnd();
				using SqlConnection selectConnection5 = new SqlConnection(DataConnection.ConnectToDatabase());
				string selectCommandText5 = $"SELECT StaffId,NetPay FROM staff WHERE StaffId='{empty2}'";
				using SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText5, selectConnection5);
				using DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5, "EmployeeSalary");
				DataTable dataTable5 = new DataTable();
				dataTable5 = dataSet5.Tables[0];
				foreach (DataRow row2 in dataTable5.Rows)
				{
					using SqlConnection sqlConnection9 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection9.Open();
					using SqlCommand sqlCommand13 = new SqlCommand
					{
						Connection = sqlConnection9,
						CommandText = string.Format("SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{0}'", row2["StaffId"]),
						CommandType = CommandType.Text
					};
					SqlDataReader sqlDataReader5 = sqlCommand13.ExecuteReader();
					if (sqlDataReader5.HasRows)
					{
						sqlConnection9.Close();
						SqlConnection sqlConnection10 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection10.Open();
						SqlCommand sqlCommand14 = new SqlCommand
						{
							Connection = sqlConnection10,
							CommandText = string.Format("SELECT * FROM tbl_emplDebts WHERE EmployeeNumber='{0}' AND Particulars='{1}' AND Month='{2}'", row2["StaffId"], Particular(), Month()),
							CommandType = CommandType.Text
						};
						SqlDataReader sqlDataReader6 = sqlCommand14.ExecuteReader();
						if (sqlDataReader6.HasRows)
						{
							continue;
						}
						using (SqlConnection selectConnection6 = new SqlConnection(DataConnection.ConnectToDatabase()))
						{
							string selectCommandText6 = string.Format("SELECT TOP (100) PERCENT Ref, EmployeeNumber, Date, Particulars, Month, Debit, Credit, Balance, capDate FROM tbl_emplDebts AS tbl_emplDebts_1 WHERE (Ref IN (SELECT MAX(Ref) AS Ref FROM tbl_emplDebts AS tbl_emplDebts WHERE (EmployeeNumber = '{0}')))", row2["StaffId"]);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText6, selectConnection6);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6);
							DataTable dataTable6 = new DataTable();
							dataTable6 = dataSet6.Tables[0];
							IEnumerator enumerator8 = dataTable6.Rows.GetEnumerator();
							try
							{
								if (!enumerator8.MoveNext())
								{
									continue;
								}
								DataRow dataRow6 = (DataRow)enumerator8.Current;
								double num6 = Convert.ToDouble(dataRow6["Balance"]);
								double requiredAmount2 = RequiredAmount;
								double num7 = num6 + requiredAmount2;
								DateTime now5 = DateTime.Now;
								using SqlConnection sqlConnection11 = new SqlConnection(DataConnection.ConnectToDatabase());
								sqlConnection11.Open();
								tra = sqlConnection11.BeginTransaction();
								using (SqlCommand sqlCommand15 = new SqlCommand
								{
									Connection = sqlConnection11,
									Transaction = tra,
									CommandText = "INSERT INTO tbl_emplDebts (EmployeeNumber,Date,Particulars,Month,Debit,Credit,Balance,capDate) VALUES (@EmployeeNumber,@Date,@Particulars,@Month,@Debit,@Credit,@Balance,@capDate)",
									CommandType = CommandType.Text
								})
								{
									SqlParameter sqlParameter9 = sqlCommand15.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50);
									sqlParameter9.Value = row2["StaffId"];
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@Date", SqlDbType.DateTime);
									sqlParameter9.Value = now5.ToShortDateString();
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
									sqlParameter9.Value = Particular();
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@Month", SqlDbType.VarChar, 15);
									sqlParameter9.Value = Month();
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@Debit", SqlDbType.Money);
									sqlParameter9.Value = 0;
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@Credit", SqlDbType.Money);
									sqlParameter9.Value = Convert.ToDouble(RequiredAmount);
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@Balance", SqlDbType.Money);
									sqlParameter9.Value = num7;
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlParameter9 = sqlCommand15.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
									sqlParameter9.Value = captureDate;
									sqlParameter9.Direction = ParameterDirection.Input;
									sqlCommand15.ExecuteNonQuery();
								}
								using (SqlCommand sqlCommand16 = new SqlCommand
								{
									Transaction = tra,
									Connection = sqlConnection11,
									CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
									CommandType = CommandType.Text
								})
								{
									SqlParameter sqlParameter10 = sqlCommand16.Parameters.Add("@accNo", SqlDbType.Int);
									sqlParameter10.Value = 5001;
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
									sqlParameter10.Value = Particular();
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@_date", SqlDbType.DateTime);
									sqlParameter10.Value = now5.ToShortDateString();
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@month", SqlDbType.VarChar, 9);
									sqlParameter10.Value = now5.ToString("MMMM");
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@year", SqlDbType.Int);
									sqlParameter10.Value = now5.Year;
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@debit", SqlDbType.Money);
									sqlParameter10.Value = RequiredAmount;
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@credit", SqlDbType.Money);
									sqlParameter10.Value = 0;
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlParameter10 = sqlCommand16.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
									sqlParameter10.Value = captureDate;
									sqlParameter10.Direction = ParameterDirection.Input;
									sqlCommand16.ExecuteNonQuery();
								}
								tra.Commit();
								sqlConnection11.Close();
							}
							finally
							{
								IDisposable disposable4 = enumerator8 as IDisposable;
								if (disposable4 != null)
								{
									disposable4.Dispose();
								}
							}
						}
						continue;
					}
					sqlConnection9.Close();
					DateTime now6 = DateTime.Now;
					using SqlConnection sqlConnection12 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection12.Open();
					T = sqlConnection12.BeginTransaction();
					using (SqlCommand sqlCommand17 = new SqlCommand
					{
						Connection = sqlConnection12,
						Transaction = T,
						CommandText = "INSERT INTO tbl_emplDebts (EmployeeNumber,Date,Particulars,Month,Debit,Credit,Balance,capDate) VALUES (@EmployeeNumber,@Date,@Particulars,@Month,@Debit,@Credit,@Balance,@capDate)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter11 = sqlCommand17.Parameters.Add("@EmployeeNumber", SqlDbType.VarChar, 50);
						sqlParameter11.Value = row2["StaffId"];
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@Date", SqlDbType.DateTime);
						sqlParameter11.Value = now6.ToShortDateString();
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@Particulars ", SqlDbType.VarChar, 50);
						sqlParameter11.Value = Particular();
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@Month", SqlDbType.VarChar, 15);
						sqlParameter11.Value = Month();
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@Debit", SqlDbType.VarChar, 50);
						sqlParameter11.Value = 0;
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@Credit", SqlDbType.Money);
						sqlParameter11.Value = Convert.ToDouble(RequiredAmount);
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@Balance", SqlDbType.Money);
						sqlParameter11.Value = Convert.ToDouble(RequiredAmount);
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlParameter11 = sqlCommand17.Parameters.Add("@capDate", SqlDbType.VarChar, 50);
						sqlParameter11.Value = captureDate;
						sqlParameter11.Direction = ParameterDirection.Input;
						sqlCommand17.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand18 = new SqlCommand
					{
						Transaction = T,
						Connection = sqlConnection12,
						CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,debit,credit) VALUES (@accNo,@particulars,@_date,@month,@year,@debit,@credit)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter12 = sqlCommand18.Parameters.Add("@accNo", SqlDbType.Int);
						sqlParameter12.Value = 5001;
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
						sqlParameter12.Value = Particular();
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@_date", SqlDbType.DateTime);
						sqlParameter12.Value = now6.ToShortDateString();
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@month", SqlDbType.VarChar, 9);
						sqlParameter12.Value = now6.ToString("MMMM");
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@year", SqlDbType.Int);
						sqlParameter12.Value = now6.Year;
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@debit", SqlDbType.Money);
						sqlParameter12.Value = RequiredAmount;
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@credit", SqlDbType.Money);
						sqlParameter12.Value = 0;
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlParameter12 = sqlCommand18.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
						sqlParameter12.Value = captureDate;
						sqlParameter12.Direction = ParameterDirection.Input;
						sqlCommand18.ExecuteNonQuery();
					}
					T.Commit();
					sqlConnection12.Close();
				}
			}
		}
		catch (Exception ex3)
		{
			XtraMessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
