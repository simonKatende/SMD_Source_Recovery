using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme;

internal class StudentPromotion
{
	private static SqlTransaction trans;

	private static SqlTransaction trn;

	private static int k;

	private static void DiscardS6Students()
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		trans = sqlConnection.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "TransferOldStudentsS_6",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "TransferOldGuardiansS_6",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand2.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "DeleteOldGuardiansS_6",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand3.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "DeleteOldStudentsS_6",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand4.ExecuteNonQuery();
		}
		trans.Commit();
		sqlConnection.Close();
	}

	private static void DiscardS6Students(string studentNo)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		trans = sqlConnection.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "TransferOldStudentsS_6Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = studentNo;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "TransferOldGuardiansS_6Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter2.Value = studentNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "DeleteOldGuardiansS_6Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter3.Value = studentNo;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Transaction = trans,
			Connection = sqlConnection,
			CommandText = "DeleteOldStudentsS_6Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter4.Value = studentNo;
			sqlParameter4.Direction = ParameterDirection.Input;
			sqlCommand4.ExecuteNonQuery();
		}
		trans.Commit();
		sqlConnection.Close();
	}

	private static void DiscardS4Students()
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		trn = sqlConnection.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "TransferOldStudentsS_4",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "TransferOldGuardiansS_4",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand2.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "DeleteOldGuardiansS_4",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand3.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "DeleteOldStudentsS_4",
			CommandType = CommandType.StoredProcedure
		})
		{
			sqlCommand4.ExecuteNonQuery();
		}
		trn.Commit();
		sqlConnection.Close();
	}

	private static void DiscardS4Students(string studentNo)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		trn = sqlConnection.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "TransferOldStudentsS_4Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter.Value = studentNo;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlCommand.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "TransferOldGuardiansS_4Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter2.Value = studentNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlCommand2.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "DeleteOldGuardiansS_4Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter3.Value = studentNo;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlCommand3.ExecuteNonQuery();
		}
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Transaction = trn,
			Connection = sqlConnection,
			CommandText = "DeleteOldStudentsS_4Cond",
			CommandType = CommandType.StoredProcedure
		})
		{
			SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter4.Value = studentNo;
			sqlParameter4.Direction = ParameterDirection.Input;
			sqlCommand4.ExecuteNonQuery();
		}
		trn.Commit();
		sqlConnection.Close();
	}

	private static void Promote5To6()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.6'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.5");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.6',RequiredFees='{0}' WHERE ClassId='S.5' AND StudyStatus='B'", row["TuitionResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.6',RequiredFees='{0}' WHERE ClassId='S.5' AND StudyStatus='D'", row["TuitionNonResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = "UPDATE students SET ClassId='S.6',StreamId='-Not Assigned-' WHERE ClassId='S.5' AND StudyStatus='B' AND BursaryStatus<>'None'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = "UPDATE students SET ClassId='S.6',StreamId='-Not Assigned-' WHERE ClassId='S.5' AND StudyStatus='D' AND BursaryStatus<>'None'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote5To6(string studentNo)
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.6'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.5");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.6',RequiredFees='{0}' WHERE ClassId='S.5' AND StudyStatus='B' AND StudentNumber='{1}'", row["TuitionResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.6',RequiredFees='{0}' WHERE ClassId='S.5' AND StudyStatus='D' AND StudentNumber='{1}'", row["TuitionNonResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"UPDATE students SET ClassId='S.6',StreamId='-Not Assigned-' WHERE ClassId='S.5' AND StudyStatus='B' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = $"UPDATE students SET ClassId='S.6',StreamId='-Not Assigned-' WHERE ClassId='S.5' AND StudyStatus='D' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote3To4()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.4'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.4");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.4',RequiredFees='{0}' WHERE ClassId='S.3' AND StudyStatus='B' AND BursaryStatus='None'", row["TuitionResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.4',RequiredFees='{0}' WHERE ClassId='S.3' AND StudyStatus='D' AND BursaryStatus='None'", row["TuitionNonResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = "UPDATE students SET ClassId='S.4',StreamId='-Not Assigned-'WHERE ClassId='S.3' AND StudyStatus='B' AND BursaryStatus<>'None'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = "UPDATE students SET ClassId='S.4',StreamId='-Not Assigned-' WHERE ClassId='S.3' AND StudyStatus='D' AND BursaryStatus<>'None'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote3To4(string studentNo)
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.4'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.4");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.4',RequiredFees='{0}' WHERE ClassId='S.3' AND StudyStatus='B' AND BursaryStatus='None' AND StudentNumber='{1}'", row["TuitionResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.4',RequiredFees='{0}' WHERE ClassId='S.3' AND StudyStatus='D' AND BursaryStatus='None' AND StudentNumber='{1}'", row["TuitionNonResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"UPDATE students SET ClassId='S.4',StreamId='-Not Assigned-'WHERE ClassId='S.3' AND StudyStatus='B' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = $"UPDATE students SET ClassId='S.4',StreamId='-Not Assigned-' WHERE ClassId='S.3' AND StudyStatus='D' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote2To3()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.3'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.3");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.3',RequiredFees='{0}' WHERE ClassId='S.2' AND StudyStatus='B' AND BursaryStatus='None'", row["TuitionResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.3',RequiredFees='{0}' WHERE ClassId='S.2' AND StudyStatus='D' AND BursaryStatus='None'", row["TuitionNonResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = "UPDATE students SET ClassId='S.3',StreamId='-Not Assigned-' WHERE ClassId='S.2' AND StudyStatus='B' AND BursaryStatus<>'None'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = "UPDATE students SET ClassId='S.3',StreamId='-Not Assigned-' WHERE ClassId='S.2' AND StudyStatus='D' AND BursaryStatus<>'None'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote2To3(string studentNo)
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.3'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.3");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.3',RequiredFees='{0}' WHERE ClassId='S.2' AND StudyStatus='B' AND BursaryStatus='None' AND StudentNumber='{1}'", row["TuitionResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.3',RequiredFees='{0}' WHERE ClassId='S.2' AND StudyStatus='D' AND BursaryStatus='None' AND StudentNumber='{1}'", row["TuitionNonResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"UPDATE students SET ClassId='S.3',StreamId='-Not Assigned-' WHERE ClassId='S.2' AND StudyStatus='B' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = $"UPDATE students SET ClassId='S.3',StreamId='-Not Assigned-' WHERE ClassId='S.2' AND StudyStatus='D' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote1To2()
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.2'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.2");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.2',RequiredFees='{0}' WHERE ClassId='S.1' AND StudyStatus='B' AND BursaryStatus='None'", row["TuitionResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.2',RequiredFees='{0}' WHERE ClassId='S.1' AND StudyStatus='D' AND BursaryStatus='None'", row["TuitionNonResidents"]),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = "UPDATE students SET ClassId='S.2' WHERE ClassId='S.1' AND StudyStatus='B' AND BursaryStatus<>'None'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = "UPDATE students SET ClassId='S.2' WHERE ClassId='S.1' AND StudyStatus='D' AND BursaryStatus<>'None'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	private static void Promote1To2(string studentNo)
	{
		using SqlConnection selectConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Classes Where ClassId='S.2'", selectConnection);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "S.2");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		foreach (DataRow row in dataTable.Rows)
		{
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = string.Format("UPDATE students SET ClassId='S.2',RequiredFees='{0}' WHERE ClassId='S.1' AND StudyStatus='B' AND BursaryStatus='None' AND StudentNumber='{1}'", row["TuitionResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand.ExecuteNonQuery();
				}
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = string.Format("UPDATE students SET ClassId='S.2',RequiredFees='{0}' WHERE ClassId='S.1' AND StudyStatus='D' AND BursaryStatus='None' AND StudentNumber='{1}'", row["TuitionNonResidents"], studentNo),
					CommandType = CommandType.Text
				})
				{
					sqlCommand2.ExecuteNonQuery();
				}
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"UPDATE students SET ClassId='S.2' WHERE ClassId='S.1' AND StudyStatus='B' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
					CommandType = CommandType.Text
				})
				{
					sqlCommand3.ExecuteNonQuery();
				}
				sqlConnection3.Close();
			}
			using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection4.Open();
			using (SqlCommand sqlCommand4 = new SqlCommand
			{
				Connection = sqlConnection4,
				CommandText = $"UPDATE students SET ClassId='S.2' WHERE ClassId='S.1' AND StudyStatus='D' AND BursaryStatus<>'None' AND StudentNumber='{studentNo}'",
				CommandType = CommandType.Text
			})
			{
				sqlCommand4.ExecuteNonQuery();
			}
			sqlConnection4.Close();
		}
	}

	public static void PromoteAllStudents(ProgressBarControl progressBar, string _semester)
	{
		if (!SemesterPromoted(_semester))
		{
			try
			{
				Application.DoEvents();
				progressBar.Properties.Maximum = 7;
				Application.DoEvents();
				progressBar.Position = 1;
				DiscardS6Students();
				Application.DoEvents();
				progressBar.Position = 2;
				Promote5To6();
				Application.DoEvents();
				progressBar.Position = 3;
				DiscardS4Students();
				Application.DoEvents();
				progressBar.Position = 4;
				Promote3To4();
				Application.DoEvents();
				progressBar.Position = 5;
				Promote2To3();
				Application.DoEvents();
				progressBar.Position = 6;
				Promote1To2();
				Application.DoEvents();
				progressBar.Position = 7;
				SetPromotedSemester(_semester);
				return;
			}
			catch (Exception ex)
			{
				XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				progressBar.Position = 0;
				return;
			}
		}
		XtraMessageBox.Show("Students are already promoted for this semester.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	private static void PromoteOLevelConditionallyLower(double cutOff, string semester, ProgressBarControl progressBar)
	{
		k = 0;
		progressBar.Position = k;
		string selectCommandText = $"SELECT StudentNumber, ClassId, SemesterId, AVG(_avMark) AS _avMark FROM view_OLevelReport_Final_1 GROUP BY StudentNumber, ClassId, SemesterId HAVING (AVG(_avMark) > {cutOff}) AND SemesterId='{semester}'";
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "olValid");
		DataTable dataTable = dataSet.Tables[0];
		progressBar.Properties.Maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			k++;
			Promote2To3(row["StudentNumber"].ToString());
			Promote1To2(row["StudentNumber"].ToString());
			Application.DoEvents();
			progressBar.Position = k;
		}
	}

	private static void PromoteOLevelConditionallyUpper(double cutOff, string semester, ProgressBarControl progressBar)
	{
		k = 0;
		progressBar.Position = k;
		string empty = string.Empty;
		empty = $"SELECT StudentNumber, ClassId, SemesterId, AVG(_avMark) AS _avMark FROM view_OLevelReport_Final_Upper GROUP BY StudentNumber, ClassId, SemesterId HAVING (AVG(_avMark) > {cutOff}) AND ClassId='S.3' AND SemesterId='{semester}'";
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "olValid");
		DataTable dataTable = dataSet.Tables[0];
		progressBar.Properties.Maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			k++;
			DiscardS4Students(row["StudentNumber"].ToString());
			Promote3To4(row["StudentNumber"].ToString());
			Application.DoEvents();
			progressBar.Position = k;
		}
	}

	private static void PromoteALevelConditionally(double cutOff, string semester, ProgressBarControl progressBar)
	{
		k = 0;
		progressBar.Position = k;
		string empty = string.Empty;
		empty = $"SELECT StudentNumber,ClassId,SemesterId FROM tbl_ALevel_MarkSheet WHERE TotalPoints > {cutOff} AND ClassId='S.5' AND SemesterId='{semester}'";
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(empty, DataConnection.ConnectToDatabase());
		using DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "alValid");
		DataTable dataTable = dataSet.Tables[0];
		progressBar.Properties.Maximum = dataTable.Rows.Count;
		foreach (DataRow row in dataTable.Rows)
		{
			k++;
			DiscardS6Students(row["StudentNumber"].ToString());
			Promote5To6(row["StudentNumber"].ToString());
			Application.DoEvents();
			progressBar.Position = k;
		}
	}

	private static bool SemesterPromoted(string _semester)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = $"SELECT * FROM tbl_PromoStamps WHERE SemesterId='{_semester}'",
			CommandType = CommandType.Text
		};
		using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlConnection.Close();
			return true;
		}
		sqlConnection.Close();
		return false;
	}

	private static void SetPromotedSemester(string _semester)
	{
		using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		using SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "INSERT INTO tbl_PromoStamps (SemesterId) VALUES (@SemesterId)",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 50);
		sqlParameter.Value = _semester;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlCommand.ExecuteNonQuery();
	}

	public static void StudentsPromoteConditionally(string _semester, ProgressBarControl progressBar)
	{
		if (!SemesterPromoted(_semester))
		{
			PromoteALevelConditionally(ALevelAutoCutOff.Repeat, _semester, progressBar);
			PromoteOLevelConditionallyUpper(OLevelAutoCutOff.ProbationDebut, _semester, progressBar);
			PromoteOLevelConditionallyLower(OLevelAutoCutOff.ProbationDebut, _semester, progressBar);
			SetPromotedSemester(_semester);
		}
		else
		{
			XtraMessageBox.Show("Students are already promoted for this semester.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}
