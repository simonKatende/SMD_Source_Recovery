using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AlienAge.Connectivity;
using DevExpress.XtraBars.Ribbon;

namespace AlienAge.Accounts;

public class Payroll
{
	private static string period = string.Empty;

	private static GalleryItemGroup galleryItemGroup1 = new GalleryItemGroup();

	public bool PayrollNotExists
	{
		get
		{
			bool result = true;
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "SELECT * FROM tbl_EmployeePaySlip WHERE PayrollPeriod=@PayrollPeriod",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@PayrollPeriod", SqlDbType.VarChar, 50);
			sqlParameter.Value = period;
			sqlParameter.Direction = ParameterDirection.Input;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				result = false;
			}
			else
			{
				sqlDataReader.Close();
				sqlConnection.Close();
			}
			return result;
		}
	}

	public Payroll(string PayrollPeriod)
	{
		period = PayrollPeriod;
	}

	public static bool PayrollItemExists(string StaffId, string Item, string _Period)
	{
		bool result = false;
		SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
		sqlConnection.Open();
		SqlCommand sqlCommand = new SqlCommand
		{
			Connection = sqlConnection,
			CommandText = "SELECT * FROM tbl_EmployeePaySlip WHERE PayrollPeriod=@PayrollPeriod AND Particulars=@Particulars AND EmployeeNo=@EmployeeNo",
			CommandType = CommandType.Text
		};
		SqlParameter sqlParameter = sqlCommand.Parameters.Add("@PayrollPeriod", SqlDbType.VarChar, 50);
		sqlParameter.Value = _Period;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
		sqlParameter.Value = Item;
		sqlParameter.Direction = ParameterDirection.Input;
		sqlParameter = sqlCommand.Parameters.Add("@EmployeeNo", SqlDbType.VarChar, 50);
		sqlParameter.Value = StaffId;
		sqlParameter.Direction = ParameterDirection.Input;
		SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
		if (sqlDataReader.HasRows)
		{
			sqlDataReader.Close();
			sqlConnection.Close();
			result = true;
		}
		else
		{
			sqlDataReader.Close();
			sqlConnection.Close();
		}
		return result;
	}

	public static void PopulatePayrollGallery(GalleryDropDown[] galleryDropDown1)
	{
		galleryItemGroup1.Caption = "Payroll";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		string[] array = new string[0];
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT PayrollPeriod FROM tbl_EmployeePaySlip GROUP BY PayrollPeriod", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "Payroll");
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			list.Add(row["PayrollPeriod"].ToString());
		}
		array = list.ToArray();
		galleryItemGroup1.Items.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			GalleryItem galleryItem = new GalleryItem();
			galleryItem.Caption = array[i].ToString();
			galleryItemGroup1.Items.AddRange(new GalleryItem[1] { galleryItem });
		}
		for (int j = 0; j < galleryDropDown1.Length; j++)
		{
			galleryDropDown1[j].Gallery.Groups.AddRange(new GalleryItemGroup[1] { galleryItemGroup1 });
		}
	}
}
