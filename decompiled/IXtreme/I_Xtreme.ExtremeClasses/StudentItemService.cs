using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AlienAge.Connectivity;

namespace I_Xtreme.ExtremeClasses;

public class StudentItemService
{
	private readonly string _connectionString = DataConnection.ConnectToDatabase();

	public List<StudentItems> GetStudentItems(string studentNumber, string semesterId)
	{
		List<StudentItems> list = new List<StudentItems>();
		string cmdText = "\r\n;WITH OrderedItems AS\r\n(\r\n    SELECT \r\n        fp.accNo AS AccNo, \r\n        fp.Particulars, \r\n        SUM(fp.Debit) AS Bills, \r\n        SUM(fp.Credit) AS Payment, \r\n        SUM(fp.Debit) - SUM(fp.Credit) AS Balance, \r\n        fp.StudentNumber, \r\n        fp.SemesterId, \r\n        gs.PaymentIndex,\r\n        ROW_NUMBER() OVER (ORDER BY fp.accNo) AS AutoIndex\r\n    FROM dbo.FeesPayment fp\r\n    INNER JOIN dbo.tbl_generalAccounts_Sub gs \r\n        ON fp.accNo = gs.subAccountNo\r\n    WHERE \r\n        fp.StudentNumber = @StudentNumber\r\n        AND fp.SemesterId = @SemesterId\r\n        AND fp.accNo LIKE '1%'\r\n    GROUP BY \r\n        fp.accNo, fp.Particulars, fp.StudentNumber, fp.SemesterId, gs.PaymentIndex\r\n)\r\n\r\nSELECT \r\n    AccNo,\r\n    Particulars,\r\n    Bills,\r\n    Payment,\r\n    Balance,\r\n    StudentNumber,\r\n    SemesterId,\r\n    CASE \r\n        WHEN PaymentIndex IS NOT NULL THEN PaymentIndex\r\n        ELSE AutoIndex + (SELECT ISNULL(MAX(PaymentIndex), 0) FROM OrderedItems) \r\n    END AS FinalPaymentIndex\r\nFROM OrderedItems\r\nORDER BY FinalPaymentIndex;\r\n";
		using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
		{
			using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.Parameters.AddWithValue("@StudentNumber", studentNumber);
			sqlCommand.Parameters.AddWithValue("@SemesterId", semesterId);
			sqlConnection.Open();
			using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				StudentItems item = new StudentItems
				{
					AccNo = sqlDataReader["AccNo"].ToString(),
					Name = sqlDataReader["Particulars"].ToString(),
					RequiredAmount = ((sqlDataReader["Bills"] != DBNull.Value) ? Convert.ToDecimal(sqlDataReader["Bills"]) : 0m),
					PaidAmount = ((sqlDataReader["Payment"] != DBNull.Value) ? Convert.ToDecimal(sqlDataReader["Payment"]) : 0m),
					Balance = ((sqlDataReader["Balance"] != DBNull.Value) ? Convert.ToDecimal(sqlDataReader["Balance"]) : 0m),
					PriorityIndex = ((sqlDataReader["FinalPaymentIndex"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["FinalPaymentIndex"]) : 0)
				};
				list.Add(item);
			}
		}
		return list;
	}
}
