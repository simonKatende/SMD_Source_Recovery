using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.DataSync;
using AlienAge.Security;
using AlienAge.Semesters;
using DevExpress.DataAccess.Json;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using I_Xtreme.ExtremeClasses;
using Newtonsoft.Json;

namespace I_Xtreme.DialogForms;

public class SynchPaymentsFromOnline : XtraForm
{
	private int x = 0;

	private bool allDataDownloaded = false;

	private SqlConnection __conn;

	private string term;

	private int pageSize = 50;

	private int k = 0;

	private int pageIndex = 1;

	private string json = string.Empty;

	private int maximum = 0;

	private SqlTransaction __TranS;

	private string schoolcode = string.Empty;

	private readonly string connectionString = DataConnection.ConnectToDatabase();

	private IContainer components = null;

	private SimpleButton simpleButton1;

	private ProgressBarControl progressBarControl1;

	private SimpleButton simpleButton2;

	private BackgroundWorker backgroundWorker1;

	private LayoutControl layoutControl1;

	private LayoutControlGroup Root;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private EmptySpaceItem emptySpaceItem1;

	private GridControl gridControl1;

	private GridView gridView1;

	private LayoutControlItem layoutControlItem2;

	private CheckEdit checkEdit1;

	private LayoutControlItem layoutControlItem5;

	public SynchPaymentsFromOnline()
	{
		InitializeComponent();
		term = WorkingSemesters.GetWorkingSemester();
		schoolcode = SerialNumber.GetSchoolCode(DataConnection.ConnectToDatabase());
		FetchOnlineData();
	}

	private static bool BankSlipNoExists(string receipNo)
	{
		bool flag = false;
		string selectCommandText = $"SELECT * FROM FeesPayment WHERE BankSlipNo='{receipNo}'";
		using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "FeesPayment");
		DataTable dataTable = new DataTable();
		dataTable = dataSet.Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			return true;
		}
		return false;
	}

	private int AddFeesPayment(double amount, string _receiptNo, string StudentNo, DateTime _dateTime)
	{
		int num = 0;
		string captureDate = CaptureDate.GetCaptureDate();
		string text = "Fees";
		string value = "1001-0001";
		double num2 = AlienAge.DataSync.StudentAccounts.FeesBalance(StudentNo) - amount;
		__conn = new SqlConnection(connectionString);
		__conn.Open();
		__TranS = __conn.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,CaptureDate,IsSent,ReceivedBy,StudentName) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@CaptureDate,@IsSent,@ReceivedBy,@StudentName)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", StudentNo);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@DateOfPayment", _dateTime.ToString("yyyy-MM-dd"));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", term);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@accNo", value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Particulars", text);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Debit", 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Credit", amount);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Balance", 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ModeOfPayment", "Surepay");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@BankId", value);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@BankSlipNo", _receiptNo);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@CaptureDate", captureDate);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@IsSent", 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ReceivedBy", CurrentUser.UserFullName);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentName", StudentNo);
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				num++;
			}
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration,userId,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration,@userId,@TrRef)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter2.Value = value;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
			sqlParameter2.Value = text + "_" + StudentNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter2.Value = term;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
			sqlParameter2.Value = _dateTime.ToString("yyyy-MM-dd");
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
			sqlParameter2.Value = _dateTime.ToString("MMMM");
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter2.Value = _dateTime.Year;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@Credit", SqlDbType.Money);
			sqlParameter2.Value = amount;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
			sqlParameter2.Value = captureDate;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
			sqlParameter2.Value = text;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@userId", SqlDbType.VarChar, 30);
			sqlParameter2.Value = CurrentUser.GetSystemUser();
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
			sqlParameter2.Value = _receiptNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				num++;
			}
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration,userId,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration,@userId,@TrRef)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter3.Value = "3003-0001";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter3.Value = term;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@_date", SqlDbType.DateTime);
			sqlParameter3.Value = _dateTime.ToString("yyyy-MM-dd");
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 9);
			sqlParameter3.Value = _dateTime.ToString("MMMM");
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter3.Value = _dateTime.Year;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Debit", SqlDbType.Money);
			sqlParameter3.Value = amount;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
			sqlParameter3.Value = text + "_" + StudentNo;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar);
			sqlParameter3.Value = text;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
			sqlParameter3.Value = captureDate;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@userId", SqlDbType.VarChar, 30);
			sqlParameter3.Value = CurrentUser.GetSystemUser();
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
			sqlParameter3.Value = _receiptNo;
			sqlParameter3.Direction = ParameterDirection.Input;
			if (sqlCommand3.ExecuteNonQuery() > 0)
			{
				num++;
			}
		}
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter4.Value = StudentNo;
			sqlParameter4.Direction = ParameterDirection.Input;
			sqlParameter4 = sqlCommand4.Parameters.Add("@cashOnAccount", SqlDbType.Float);
			sqlParameter4.Value = num2;
			sqlParameter4.Direction = ParameterDirection.Input;
			sqlCommand4.ExecuteNonQuery();
			num++;
		}
		__TranS.Commit();
		__conn.Close();
		return num;
	}

	private int AddFeesPaymentAndAssign(double amount, string _receiptNo, string StudentNo, DateTime _dateTime, string Particulars, string AccNo)
	{
		int num = 0;
		string captureDate = CaptureDate.GetCaptureDate();
		double num2 = AlienAge.DataSync.StudentAccounts.FeesBalance(StudentNo) - amount;
		__conn = new SqlConnection(connectionString);
		__conn.Open();
		__TranS = __conn.BeginTransaction();
		using (SqlCommand sqlCommand = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,CaptureDate,IsSent,ReceivedBy,StudentName) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@CaptureDate,@IsSent,@ReceivedBy,@StudentName)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentNumber", StudentNo);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@DateOfPayment", _dateTime.ToString("yyyy-MM-dd"));
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@SemesterId", term);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@accNo", AccNo);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Particulars", Particulars);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Debit", 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Credit", amount);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@Balance", 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ModeOfPayment", "Surepay");
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@BankId", AccNo);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@BankSlipNo", _receiptNo);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@CaptureDate", captureDate);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@IsSent", 0);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@ReceivedBy", CurrentUser.UserFullName);
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.AddWithValue("@StudentName", StudentNo);
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				num++;
			}
		}
		using (SqlCommand sqlCommand2 = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration,userId,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration,@userId,@TrRef)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter2.Value = AccNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
			sqlParameter2.Value = Particulars + "_" + StudentNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter2.Value = term;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
			sqlParameter2.Value = _dateTime.ToString("yyyy-MM-dd");
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
			sqlParameter2.Value = _dateTime.ToString("MMMM");
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter2.Value = _dateTime.Year;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@Credit", SqlDbType.Money);
			sqlParameter2.Value = amount;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
			sqlParameter2.Value = captureDate;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
			sqlParameter2.Value = Particulars;
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@userId", SqlDbType.VarChar, 30);
			sqlParameter2.Value = CurrentUser.GetSystemUser();
			sqlParameter2.Direction = ParameterDirection.Input;
			sqlParameter2 = sqlCommand2.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
			sqlParameter2.Value = _receiptNo;
			sqlParameter2.Direction = ParameterDirection.Input;
			if (sqlCommand2.ExecuteNonQuery() > 0)
			{
				num++;
			}
		}
		using (SqlCommand sqlCommand3 = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,captureDate,Narration,userId,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@captureDate,@Narration,@userId,@TrRef)",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter3.Value = "3003-0001";
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
			sqlParameter3.Value = term;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@_date", SqlDbType.DateTime);
			sqlParameter3.Value = _dateTime.ToString("yyyy-MM-dd");
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@month", SqlDbType.VarChar, 9);
			sqlParameter3.Value = _dateTime.ToString("MMMM");
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@year", SqlDbType.Int);
			sqlParameter3.Value = _dateTime.Year;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Debit", SqlDbType.Money);
			sqlParameter3.Value = amount;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
			sqlParameter3.Value = Particulars + "_" + StudentNo;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar);
			sqlParameter3.Value = Particulars;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
			sqlParameter3.Value = captureDate;
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@userId", SqlDbType.VarChar, 30);
			sqlParameter3.Value = CurrentUser.GetSystemUser();
			sqlParameter3.Direction = ParameterDirection.Input;
			sqlParameter3 = sqlCommand3.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
			sqlParameter3.Value = _receiptNo;
			sqlParameter3.Direction = ParameterDirection.Input;
			if (sqlCommand3.ExecuteNonQuery() > 0)
			{
				num++;
			}
		}
		using (SqlCommand sqlCommand4 = new SqlCommand
		{
			Transaction = __TranS,
			Connection = __conn,
			CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
			CommandType = CommandType.Text
		})
		{
			SqlParameter sqlParameter4 = sqlCommand4.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
			sqlParameter4.Value = StudentNo;
			sqlParameter4.Direction = ParameterDirection.Input;
			sqlParameter4 = sqlCommand4.Parameters.Add("@cashOnAccount", SqlDbType.Float);
			sqlParameter4.Value = num2;
			sqlParameter4.Direction = ParameterDirection.Input;
			sqlCommand4.ExecuteNonQuery();
			num++;
		}
		__TranS.Commit();
		__conn.Close();
		return num;
	}

	private async Task FetchOnlineData()
	{
		try
		{
			JsonDataSource jsonDataSource = new JsonDataSource();
			HttpClient httpClient = new HttpClient();
			try
			{
				httpClient.BaseAddress = new Uri("https://sims.surepayltd.com");
				((HttpHeaders)httpClient.DefaultRequestHeaders).Add("Accept", "application/json");
				((HttpHeaders)httpClient.DefaultRequestHeaders).Add("6CD14B34-E080-4AEC-995A-0BC03CCABE6B", "111f942a-0c00-4bb8-ac95-f514e2229066");
				HttpResponseMessage response = await httpClient.GetAsync("/api/feespayment/notsynched/" + schoolcode);
				if (response.IsSuccessStatusCode)
				{
					jsonDataSource.JsonSource = new CustomJsonSource(await response.Content.ReadAsStringAsync());
					jsonDataSource.Fill();
					gridControl1.DataSource = jsonDataSource;
					if (gridView1.RowCount > 0)
					{
						simpleButton2.Enabled = true;
					}
				}
			}
			finally
			{
				((IDisposable)httpClient)?.Dispose();
			}
		}
		finally
		{
			int num = 0;
			if (num >= 0)
			{
			}
		}
	}

	private void DownloadPaymentsAndAssign()
	{
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		try
		{
			double result = 0.0;
			string empty = string.Empty;
			string empty2 = string.Empty;
			long num = 0L;
			DateTime result2 = DateTime.Now;
			StudentItemService studentItemService = new StudentItemService();
			k = 1;
			maximum = gridView1.RowCount;
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				result = (double.TryParse(gridView1.GetRowCellValue(i, "amountPaid").ToString(), out result) ? result : 0.0);
				empty = gridView1.GetRowCellValue(i, "transactionRef").ToString();
				empty2 = gridView1.GetRowCellValue(i, "studentNo").ToString();
				result2 = (DateTime.TryParse(gridView1.GetRowCellValue(i, "trxDate").ToString(), out result2) ? result2 : DateTime.Now);
				num = Convert.ToInt64(gridView1.GetRowCellValue(i, "paymentId").ToString());
				List<StudentItems> studentItems = studentItemService.GetStudentItems(empty2, WorkingSemesters.GetWorkingSemester());
				List<PaymentResult> list = FeeDistributor.DistributeFees(studentItems, (decimal)result, empty2);
				if (!BankSlipNoExists(empty))
				{
					foreach (PaymentResult item in list)
					{
						if (AddFeesPaymentAndAssign((double)item.AmountAllocated, empty, empty2, result2, item.Name, item.AccNo) != 4)
						{
							continue;
						}
						HttpClient val = new HttpClient();
						try
						{
							val.BaseAddress = new Uri(DataSyncHelper.UrlString);
							((HttpHeaders)val.DefaultRequestHeaders).Add("Accept", "application/json");
							((HttpHeaders)val.DefaultRequestHeaders).Add("6CD14B34-E080-4AEC-995A-0BC03CCABE6B", DataSyncHelper.ApiKey);
							StringContent content = new StringContent(JsonConvert.SerializeObject(new
							{
								paymentId = num
							}), Encoding.UTF8, "application/json");
							HttpRequestMessage val2 = new HttpRequestMessage(new HttpMethod("PATCH"), "/api/feespayment/marksynched")
							{
								Content = (HttpContent)(object)content
							};
							HttpResponseMessage result3 = val.SendAsync(val2).Result;
							if (!result3.IsSuccessStatusCode)
							{
							}
						}
						finally
						{
							((IDisposable)val)?.Dispose();
						}
					}
				}
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			k = 1;
			maximum = 0;
		}
	}

	private void DownloadPayments()
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		try
		{
			double result = 0.0;
			string empty = string.Empty;
			string empty2 = string.Empty;
			long num = 0L;
			DateTime result2 = DateTime.Now;
			k = 1;
			maximum = gridView1.RowCount;
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				result = (double.TryParse(gridView1.GetRowCellValue(i, "amountPaid").ToString(), out result) ? result : 0.0);
				empty = gridView1.GetRowCellValue(i, "transactionRef").ToString();
				empty2 = gridView1.GetRowCellValue(i, "studentNo").ToString();
				result2 = (DateTime.TryParse(gridView1.GetRowCellValue(i, "trxDate").ToString(), out result2) ? result2 : DateTime.Now);
				num = Convert.ToInt64(gridView1.GetRowCellValue(i, "paymentId").ToString());
				if (!BankSlipNoExists(empty) && AddFeesPayment(result, empty, empty2, result2) == 4)
				{
					HttpClient val = new HttpClient();
					try
					{
						val.BaseAddress = new Uri(DataSyncHelper.UrlString);
						((HttpHeaders)val.DefaultRequestHeaders).Add("Accept", "application/json");
						((HttpHeaders)val.DefaultRequestHeaders).Add("6CD14B34-E080-4AEC-995A-0BC03CCABE6B", DataSyncHelper.ApiKey);
						StringContent content = new StringContent(JsonConvert.SerializeObject(new
						{
							paymentId = num
						}), Encoding.UTF8, "application/json");
						HttpRequestMessage val2 = new HttpRequestMessage(new HttpMethod("PATCH"), "/api/feespayment/marksynched")
						{
							Content = (HttpContent)(object)content
						};
						HttpResponseMessage result3 = val.SendAsync(val2).Result;
						if (!result3.IsSuccessStatusCode)
						{
						}
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				k++;
				Thread.Sleep(10);
				backgroundWorker1.ReportProgress(k);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			k = 1;
			maximum = 0;
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum + 1;
		progressBarControl1.Position = e.ProgressPercentage;
	}

	private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		k = 0;
		maximum = 0;
		XtraMessageBox.Show("All processes completed successfully.", "Success:" + pageIndex, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		simpleButton1.Enabled = true;
	}

	private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
	{
		if (checkEdit1.Checked)
		{
			DownloadPaymentsAndAssign();
		}
		else
		{
			DownloadPayments();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		if (!backgroundWorker1.IsBusy)
		{
			simpleButton1.Enabled = false;
			simpleButton2.Enabled = false;
			backgroundWorker1.RunWorkerAsync();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.gridControl1 = new DevExpress.XtraGrid.GridControl();
		this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.Root).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		base.SuspendLayout();
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.Location = new System.Drawing.Point(203, 105);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(198, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = "Close";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.layoutControl1.Controls.Add(this.checkEdit1);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.progressBarControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[1] { this.layoutControlItem2 });
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.Root;
		this.layoutControl1.Size = new System.Drawing.Size(403, 129);
		this.layoutControl1.TabIndex = 7;
		this.layoutControl1.Text = "layoutControl1";
		this.gridControl1.Location = new System.Drawing.Point(2, 2);
		this.gridControl1.MainView = this.gridView1;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.Size = new System.Drawing.Size(458, 20);
		this.gridControl1.TabIndex = 5;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView1 });
		this.gridView1.GridControl = this.gridControl1;
		this.gridView1.Name = "gridView1";
		this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.simpleButton2.Appearance.Options.UseFont = true;
		this.simpleButton2.Enabled = false;
		this.simpleButton2.Location = new System.Drawing.Point(2, 105);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(197, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "Sync Data";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.progressBarControl1.Location = new System.Drawing.Point(2, 2);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(399, 52);
		this.progressBarControl1.StyleController = this.layoutControl1;
		this.progressBarControl1.TabIndex = 4;
		this.layoutControlItem2.Control = this.gridControl1;
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(462, 24);
		this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.TextVisible = false;
		this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.Root.GroupBordersVisible = false;
		this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[5] { this.layoutControlItem1, this.layoutControlItem3, this.layoutControlItem4, this.emptySpaceItem1, this.layoutControlItem5 });
		this.Root.Name = "Root";
		this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.Root.Size = new System.Drawing.Size(403, 129);
		this.Root.TextVisible = false;
		this.layoutControlItem1.Control = this.progressBarControl1;
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 56);
		this.layoutControlItem1.MinSize = new System.Drawing.Size(54, 18);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(403, 56);
		this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.Location = new System.Drawing.Point(201, 103);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(202, 26);
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlItem4.Control = this.simpleButton2;
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 103);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(201, 26);
		this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem4.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 56);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(403, 23);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.backgroundWorker1.WorkerReportsProgress = true;
		this.backgroundWorker1.WorkerSupportsCancellation = true;
		this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
		this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
		this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		this.checkEdit1.Location = new System.Drawing.Point(2, 81);
		this.checkEdit1.Name = "checkEdit1";
		this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10f);
		this.checkEdit1.Properties.Appearance.Options.UseFont = true;
		this.checkEdit1.Properties.Caption = "Download payments and auto distribute to student payables";
		this.checkEdit1.Size = new System.Drawing.Size(399, 20);
		this.checkEdit1.StyleController = this.layoutControl1;
		this.checkEdit1.TabIndex = 6;
		this.layoutControlItem5.Control = this.checkEdit1;
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 79);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(403, 24);
		this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem5.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(403, 129);
		base.Controls.Add(this.layoutControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "SynchPaymentsFromOnline";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Download payments";
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.Root).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.checkEdit1.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		base.ResumeLayout(false);
	}
}
