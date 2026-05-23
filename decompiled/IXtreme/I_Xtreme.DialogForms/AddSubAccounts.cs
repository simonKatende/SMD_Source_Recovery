using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace I_Xtreme.DialogForms;

public class AddSubAccounts : XtraForm
{
	private DataTable dt;

	private DataTable __dt;

	private DataTable dt_GA;

	public StartOrStopTimer StartTimer;

	private int category = 0;

	private int accNo = 0;

	private string accountLR = string.Empty;

	private SqlTransaction trans;

	private IContainer components = null;

	private LayoutControl layoutControl21;

	private SimpleButton simpleButton22;

	private ComboBoxEdit cboAccountCategories;

	private LayoutControlGroup layoutControlGroup47;

	private LayoutControlItem layoutControlItem66;

	private LayoutControlItem layoutControlAccountName;

	private LayoutControlItem layoutControlItem71;

	private LayoutControlGroup layoutControlGroup1;

	private EmptySpaceItem emptySpaceItem1;

	private ComboBoxEdit txtAccountName;

	private System.Windows.Forms.Timer timer1;

	private ComboBoxEdit cboSubAccounts;

	private LayoutControlItem layoutControlItem1;

	private TextEdit txtOpenningBalance;

	private LayoutControlItem layoutControlItem2;

	private SimpleButton simpleButton1;

	private LayoutControlItem layoutControlItem3;

	public AddSubAccounts()
	{
		InitializeComponent();
		LoadAccounts();
	}

	private void LoadAccounts()
	{
		try
		{
			using SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_account_types", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "_allAccounts");
			__dt = new DataTable();
			__dt = dataSet.Tables[0];
			cboAccountCategories.Properties.Items.Clear();
			foreach (DataRow row in __dt.Rows)
			{
				cboAccountCategories.Properties.Items.Add(row["accountName"]);
			}
			cboAccountCategories.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private string SubAccountNoFromName(string AccountName)
	{
		string result = string.Empty;
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT subAccountNo FROM tbl_generalAccounts_Sub WHERE SubAccoutName='{AccountName}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "SubAccoutNumber");
		IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				result = dataRow["subAccountNo"].ToString();
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	private void AppendAccounts()
	{
		try
		{
			SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			double result = (double.TryParse(txtOpenningBalance.Text, out result) ? result : 0.0);
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = $"SELECT * FROM tbl_generalAccounts_Sub WHERE accNo={accNo} AND SubAccoutName='{Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtAccountName.Text.ToLower())}'",
				CommandType = CommandType.Text
			};
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			if (sqlDataReader.HasRows)
			{
				sqlDataReader.Close();
				sqlConnection.Close();
				if (result > 0.0)
				{
					DialogResult dialogResult = XtraMessageBox.Show("You are about to Add/Change the opening balance for the selected account.\nDo you reaally want to do this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
					if (dialogResult != DialogResult.Yes)
					{
						return;
					}
					using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection2.Open();
					using SqlCommand sqlCommand2 = new SqlCommand
					{
						Connection = sqlConnection2,
						CommandText = "SELECT accNo FROM tbl_StatementOfAffairs WHERE accNo=@accNo AND particulars=@particulars AND Narration=@Narration",
						CommandType = CommandType.Text
					};
					SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = "7001-0001";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = txtAccountName.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = "Opening Balance";
					sqlParameter.Direction = ParameterDirection.Input;
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					if (sqlDataReader2.HasRows)
					{
						sqlDataReader2.Close();
						trans = sqlConnection2.BeginTransaction();
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = trans,
							CommandText = "UPDATE tbl_StatementOfAffairs SET Debit=@Debit,Credit=@Credit WHERE accNo=@accNo AND particulars=@particulars AND Narration=@Narration",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
							sqlParameter2.Value = "7001-0001";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
							sqlParameter2.Value = txtAccountName.Text;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter2.Value = 0;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter2.Value = result;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@Narration", SqlDbType.VarChar);
							sqlParameter2.Value = "Opening Balance";
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand4 = new SqlCommand
						{
							Connection = sqlConnection2,
							Transaction = trans,
							CommandText = "UPDATE tbl_StatementOfAffairs SET Debit=@Debit,Credit=@Credit WHERE accNo=@accNo AND particulars=@particulars AND Narration=@Narration",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter3 = sqlCommand4.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
							sqlParameter3.Value = SubAccountNoFromName(txtAccountName.Text);
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
							sqlParameter3.Value = txtAccountName.Text;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter3.Value = result;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter3.Value = 0;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand4.Parameters.Add("@Narration", SqlDbType.VarChar);
							sqlParameter3.Value = "Opening Balance";
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlCommand4.ExecuteNonQuery();
						}
						trans.Commit();
						sqlConnection2.Close();
						XtraMessageBox.Show("Opening balance changed successfully.", "Micro Fiscal Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						txtOpenningBalance.Text = string.Empty;
						StartTimer(timerStatus: true);
						return;
					}
					sqlDataReader2.Close();
					trans = sqlConnection2.BeginTransaction();
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = trans,
						CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,Debit,Credit,Narration) VALUES (@accNo,@particulars,@_date,@month,@year,@Debit,@Credit,@Narration)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter4 = sqlCommand5.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
						sqlParameter4.Value = "7001-0001";
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
						sqlParameter4.Value = txtAccountName.Text;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@_date", SqlDbType.DateTime);
						sqlParameter4.Value = FinalAccounts.BooksBeginningDate.ToShortDateString();
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@month", SqlDbType.VarChar, 9);
						sqlParameter4.Value = FinalAccounts.BooksBeginningDate.ToString("MMM");
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@year", SqlDbType.Int);
						sqlParameter4.Value = FinalAccounts.BooksBeginningDate.Year;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@Debit", SqlDbType.Money);
						sqlParameter4.Value = 0;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@Credit", SqlDbType.Money);
						sqlParameter4.Value = result;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand5.Parameters.Add("@Narration", SqlDbType.VarChar);
						sqlParameter4.Value = "Opening Balance";
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlCommand5.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand6 = new SqlCommand
					{
						Connection = sqlConnection2,
						Transaction = trans,
						CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,Debit,Credit,Narration) VALUES (@accNo,@particulars,@_date,@month,@year,@Debit,@Credit,@Narration)",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter5 = sqlCommand6.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
						sqlParameter5.Value = SubAccountNoFromName(txtAccountName.Text);
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
						sqlParameter5.Value = txtAccountName.Text;
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@_date", SqlDbType.DateTime);
						sqlParameter5.Value = FinalAccounts.BooksBeginningDate.ToShortDateString();
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@month", SqlDbType.VarChar, 9);
						sqlParameter5.Value = FinalAccounts.BooksBeginningDate.ToString("MMM");
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@year", SqlDbType.Int);
						sqlParameter5.Value = FinalAccounts.BooksBeginningDate.Year;
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@Debit", SqlDbType.Money);
						sqlParameter5.Value = result;
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@Credit", SqlDbType.Money);
						sqlParameter5.Value = 0;
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlParameter5 = sqlCommand6.Parameters.Add("@Narration", SqlDbType.VarChar);
						sqlParameter5.Value = "Opening Balance";
						sqlParameter5.Direction = ParameterDirection.Input;
						sqlCommand6.ExecuteNonQuery();
					}
					trans.Commit();
					sqlConnection2.Close();
					XtraMessageBox.Show("Opening balance added successfully.", "Micro Fiscal Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					txtOpenningBalance.Text = string.Empty;
					StartTimer(timerStatus: true);
					return;
				}
				XtraMessageBox.Show("This account already exists", "Micro Fiscal Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string nextSubAccountNumber = FinalAccounts.GetNextSubAccountNumber(category, accNo);
			sqlDataReader.Close();
			sqlConnection.Close();
			using SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection3.Open();
			using SqlCommand sqlCommand7 = new SqlCommand
			{
				Connection = sqlConnection3,
				CommandText = "INSERT INTO tbl_generalAccounts_Sub (accNo,subAccountNo,SubAccoutName)VALUES(@accNo,@subAccountNo,@SubAccoutName)",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter6 = sqlCommand7.Parameters.Add("@accNo", SqlDbType.Int);
			sqlParameter6.Value = accNo;
			sqlParameter6.Direction = ParameterDirection.Input;
			sqlParameter6 = sqlCommand7.Parameters.Add("@subAccountNo", SqlDbType.VarChar, 9);
			sqlParameter6.Value = nextSubAccountNumber;
			sqlParameter6.Direction = ParameterDirection.Input;
			sqlParameter6 = sqlCommand7.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
			sqlParameter6.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtAccountName.Text.ToLower());
			sqlParameter6.Direction = ParameterDirection.Input;
			if (sqlCommand7.ExecuteNonQuery() <= 0)
			{
				return;
			}
			if (result > 0.0)
			{
				trans = sqlConnection3.BeginTransaction();
				using (SqlCommand sqlCommand8 = new SqlCommand
				{
					Connection = sqlConnection3,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,Debit,Credit,Narration) VALUES (@accNo,@particulars,@_date,@month,@year,@Debit,@Credit,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter7 = sqlCommand8.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter7.Value = nextSubAccountNumber;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter7.Value = txtAccountName.Text;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter7.Value = FinalAccounts.BooksBeginningDate.ToShortDateString();
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter7.Value = FinalAccounts.BooksBeginningDate.ToString("MMM");
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter7.Value = FinalAccounts.BooksBeginningDate.Year;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter7.Value = result;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter7.Value = 0;
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlParameter7 = sqlCommand8.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter7.Value = "Opening Balance";
					sqlParameter7.Direction = ParameterDirection.Input;
					sqlCommand8.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand9 = new SqlCommand
				{
					Connection = sqlConnection3,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,_date,month,year,Debit,Credit,Narration) VALUES (@accNo,@particulars,@_date,@month,@year,@Debit,@Credit,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter8 = sqlCommand9.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter8.Value = "7001-0001";
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter8.Value = txtAccountName.Text;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter8.Value = FinalAccounts.BooksBeginningDate.ToShortDateString();
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter8.Value = FinalAccounts.BooksBeginningDate.ToString("MMM");
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter8.Value = FinalAccounts.BooksBeginningDate.Year;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter8.Value = 0;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter8.Value = result;
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlParameter8 = sqlCommand9.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter8.Value = "Opening Balance";
					sqlParameter8.Direction = ParameterDirection.Input;
					sqlCommand9.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection3.Close();
				StartTimer(timerStatus: true);
				txtAccountName.Text = string.Empty;
				txtAccountName.Focus();
				txtOpenningBalance.Text = string.Empty;
			}
			else
			{
				sqlConnection3.Close();
				StartTimer(timerStatus: true);
				txtAccountName.Text = string.Empty;
				txtAccountName.Focus();
				txtOpenningBalance.Text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Micro Fiscal Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton22_Click(object sender, EventArgs e)
	{
		if (cboAccountCategories.SelectedItem.ToString() == "3.FIXED ASSETS")
		{
			XtraMessageBox.Show("Please use the stock Register to add Fixed Assets\n Goto Accounts->Inventory->Add New", "Micro Fiscal Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			if (cboAccountCategories.SelectedItem.ToString() == "6.CURRENT LIABILITIES")
			{
				if (cboSubAccounts.Text == "Bills Payable" || cboSubAccounts.Text == "Suppliers/Service Providers" || cboSubAccounts.Text == "Short-term Loans" || !(cboSubAccounts.Text == "Employees"))
				{
					return;
				}
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "SELECT FROM tbl_generalAccounts_Sub WHERE SubAccoutName=@SubAccoutName",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand.Parameters.Add("@SubAccoutName", SqlDbType.VarChar, 25);
				sqlParameter.Value = txtAccountName.Text;
				sqlParameter.Direction = ParameterDirection.Input;
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				if (!sqlDataReader.HasRows)
				{
					sqlDataReader.Close();
					sqlConnection.Close();
					AppendAccounts();
					return;
				}
				sqlDataReader.Close();
				sqlConnection.Close();
				EmployeeAdmission employeeAdmission = new EmployeeAdmission("SubAccount", txtAccountName.Text);
				if (employeeAdmission.ShowDialog() != DialogResult.OK)
				{
				}
				return;
			}
			AppendAccounts();
		}
	}

	private void cboAccountCategories_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private int FocusedAccountNo()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT accNo FROM tbl_generalAccounts WHERE accName='" + txtAccountName.Text + "'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "ActiveAccountNo");
		string value = string.Empty;
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			value = row["accNo"].ToString();
		}
		return Convert.ToInt32(value);
	}

	private void GetLoaningAgents()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT Tel AS RefNum,Name FROM tbl_debtors", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "LoaningAgents");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			txtAccountName.Properties.Items.Clear();
			ComboBoxItemCollection items = txtAccountName.Properties.Items;
			object[] items2 = new string[1] { "-Select Debtor-" };
			items.AddRange(items2);
			foreach (DataRow row in dt.Rows)
			{
				txtAccountName.Properties.Items.Add(row["Name"]).ToString();
			}
			txtAccountName.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void GetSuppliers()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT SupplierCode AS RefNum, Company AS Name FROM tbl_Suppliers", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Suppliers");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			txtAccountName.Properties.Items.Clear();
			ComboBoxItemCollection items = txtAccountName.Properties.Items;
			object[] items2 = new string[1] { "-Select Supplier-" };
			items.AddRange(items2);
			foreach (DataRow row in dt.Rows)
			{
				txtAccountName.Properties.Items.Add(row["Name"]).ToString();
			}
			txtAccountName.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void GetEmployees()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT StaffId AS RefNum,StaffName AS Name FROM Staff", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Employees");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			txtAccountName.Properties.Items.Clear();
			ComboBoxItemCollection items = txtAccountName.Properties.Items;
			object[] items2 = new string[1] { "-Select Employee-" };
			items.AddRange(items2);
			foreach (DataRow row in dt.Rows)
			{
				txtAccountName.Properties.Items.Add(row["Name"]);
			}
			txtAccountName.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cboSubAccounts_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void cboSubAccounts_Closed(object sender, ClosedEventArgs e)
	{
		try
		{
			if (cboSubAccounts.SelectedIndex <= -1)
			{
				return;
			}
			DataRow dataRow = dt_GA.Rows[cboSubAccounts.SelectedIndex];
			accNo = Convert.ToInt32(dataRow["accNo"].ToString());
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT subAccountNo,SubAccoutName FROM tbl_generalAccounts_Sub WHERE accNo={accNo}", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "Accounts");
			txtAccountName.Properties.Items.Clear();
			txtAccountName.Text = string.Empty;
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				txtAccountName.Properties.Items.Add(row["SubAccoutName"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "Micro Fiscal Dyanmics", MessageBoxButtons.OK);
		}
	}

	private void cboAccountCategories_Closed(object sender, ClosedEventArgs e)
	{
		if (cboAccountCategories.SelectedIndex > -1)
		{
			cboSubAccounts.Text = string.Empty;
			txtAccountName.Properties.Items.Clear();
			txtAccountName.Text = string.Empty;
			DataRow dataRow = __dt.Rows[cboAccountCategories.SelectedIndex];
			category = Convert.ToInt32(dataRow["categoryId"].ToString());
			accountLR = dataRow["SuperGroup"].ToString();
			if (category > 2000)
			{
				txtOpenningBalance.Properties.ReadOnly = false;
			}
			else
			{
				txtOpenningBalance.Properties.ReadOnly = true;
				txtOpenningBalance.Text = string.Empty;
			}
		}
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT accNo,accName FROM tbl_generalAccounts WHERE categoryId={category}", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "SubAccounts");
		dt_GA = new DataTable();
		dt_GA = dataSet.Tables[0];
		cboSubAccounts.Properties.Items.Clear();
		foreach (DataRow row in dt_GA.Rows)
		{
			cboSubAccounts.Properties.Items.Add(row["accName"]);
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
		this.components = new System.ComponentModel.Container();
		this.layoutControl21 = new DevExpress.XtraLayout.LayoutControl();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtOpenningBalance = new DevExpress.XtraEditors.TextEdit();
		this.cboSubAccounts = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton22 = new DevExpress.XtraEditors.SimpleButton();
		this.cboAccountCategories = new DevExpress.XtraEditors.ComboBoxEdit();
		this.txtAccountName = new DevExpress.XtraEditors.ComboBoxEdit();
		this.layoutControlGroup47 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem66 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem71 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlAccountName = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.layoutControl21).BeginInit();
		this.layoutControl21.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtOpenningBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubAccounts.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboAccountCategories.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccountName.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup47).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem66).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem71).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlAccountName).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		base.SuspendLayout();
		this.layoutControl21.Controls.Add(this.simpleButton1);
		this.layoutControl21.Controls.Add(this.txtOpenningBalance);
		this.layoutControl21.Controls.Add(this.cboSubAccounts);
		this.layoutControl21.Controls.Add(this.simpleButton22);
		this.layoutControl21.Controls.Add(this.cboAccountCategories);
		this.layoutControl21.Controls.Add(this.txtAccountName);
		this.layoutControl21.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl21.Location = new System.Drawing.Point(0, 0);
		this.layoutControl21.Name = "layoutControl21";
		this.layoutControl21.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(564, 77, 465, 514);
		this.layoutControl21.Root = this.layoutControlGroup47;
		this.layoutControl21.Size = new System.Drawing.Size(343, 219);
		this.layoutControl21.TabIndex = 1;
		this.layoutControl21.Text = "layoutControl21";
		this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton1.Appearance.Options.UseFont = true;
		this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.simpleButton1.Location = new System.Drawing.Point(163, 190);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(176, 25);
		this.simpleButton1.StyleController = this.layoutControl21;
		this.simpleButton1.TabIndex = 7;
		this.simpleButton1.Text = "Close";
		this.txtOpenningBalance.Location = new System.Drawing.Point(118, 136);
		this.txtOpenningBalance.Name = "txtOpenningBalance";
		this.txtOpenningBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOpenningBalance.Properties.Appearance.Options.UseFont = true;
		this.txtOpenningBalance.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtOpenningBalance.Properties.Mask.EditMask = "n0";
		this.txtOpenningBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
		this.txtOpenningBalance.Size = new System.Drawing.Size(221, 26);
		this.txtOpenningBalance.StyleController = this.layoutControl21;
		this.txtOpenningBalance.TabIndex = 6;
		this.cboSubAccounts.Location = new System.Drawing.Point(7, 76);
		this.cboSubAccounts.Name = "cboSubAccounts";
		this.cboSubAccounts.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.cboSubAccounts.Properties.Appearance.Options.UseFont = true;
		this.cboSubAccounts.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSubAccounts.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboSubAccounts.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboSubAccounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboSubAccounts.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboSubAccounts.Size = new System.Drawing.Size(332, 26);
		this.cboSubAccounts.StyleController = this.layoutControl21;
		this.cboSubAccounts.TabIndex = 5;
		this.cboSubAccounts.SelectedIndexChanged += new System.EventHandler(cboSubAccounts_SelectedIndexChanged);
		this.cboSubAccounts.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboSubAccounts_Closed);
		this.simpleButton22.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton22.Appearance.Options.UseFont = true;
		this.simpleButton22.Location = new System.Drawing.Point(4, 190);
		this.simpleButton22.Name = "simpleButton22";
		this.simpleButton22.Size = new System.Drawing.Size(155, 25);
		this.simpleButton22.StyleController = this.layoutControl21;
		this.simpleButton22.TabIndex = 4;
		this.simpleButton22.Text = "Add Sub Account";
		this.simpleButton22.Click += new System.EventHandler(simpleButton22_Click);
		this.cboAccountCategories.EnterMoveNextControl = true;
		this.cboAccountCategories.Location = new System.Drawing.Point(7, 25);
		this.cboAccountCategories.Name = "cboAccountCategories";
		this.cboAccountCategories.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboAccountCategories.Properties.Appearance.Options.UseFont = true;
		this.cboAccountCategories.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboAccountCategories.Properties.AppearanceDropDown.Options.UseFont = true;
		this.cboAccountCategories.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboAccountCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboAccountCategories.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
		this.cboAccountCategories.Size = new System.Drawing.Size(332, 26);
		this.cboAccountCategories.StyleController = this.layoutControl21;
		this.cboAccountCategories.TabIndex = 0;
		this.cboAccountCategories.SelectedIndexChanged += new System.EventHandler(cboAccountCategories_SelectedIndexChanged);
		this.cboAccountCategories.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboAccountCategories_Closed);
		this.txtAccountName.Location = new System.Drawing.Point(118, 106);
		this.txtAccountName.Name = "txtAccountName";
		this.txtAccountName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAccountName.Properties.Appearance.Options.UseFont = true;
		this.txtAccountName.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAccountName.Properties.AppearanceDropDown.Options.UseFont = true;
		this.txtAccountName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtAccountName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.txtAccountName.Properties.MaxLength = 35;
		this.txtAccountName.Size = new System.Drawing.Size(221, 26);
		this.txtAccountName.StyleController = this.layoutControl21;
		this.txtAccountName.TabIndex = 2;
		this.layoutControlGroup47.CustomizationFormText = "layoutControlGroup47";
		this.layoutControlGroup47.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup47.GroupBordersVisible = false;
		this.layoutControlGroup47.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem66, this.layoutControlGroup1, this.layoutControlAccountName, this.layoutControlItem1 });
		this.layoutControlGroup47.Location = new System.Drawing.Point(0, 0);
		this.layoutControlGroup47.Name = "layoutControlGroup47";
		this.layoutControlGroup47.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup47.Size = new System.Drawing.Size(343, 219);
		this.layoutControlGroup47.Text = "layoutControlGroup47";
		this.layoutControlGroup47.TextVisible = false;
		this.layoutControlItem66.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem66.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem66.Control = this.cboAccountCategories;
		this.layoutControlItem66.CustomizationFormText = "Category";
		this.layoutControlItem66.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem66.Name = "layoutControlItem66";
		this.layoutControlItem66.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem66.Size = new System.Drawing.Size(339, 51);
		this.layoutControlItem66.Text = "Ledger Account";
		this.layoutControlItem66.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem66.TextSize = new System.Drawing.Size(108, 18);
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[4] { this.layoutControlItem71, this.emptySpaceItem1, this.layoutControlItem2, this.layoutControlItem3 });
		this.layoutControlGroup1.Location = new System.Drawing.Point(0, 132);
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
		this.layoutControlGroup1.Size = new System.Drawing.Size(339, 83);
		this.layoutControlGroup1.Text = "layoutControlGroup1";
		this.layoutControlItem71.Control = this.simpleButton22;
		this.layoutControlItem71.CustomizationFormText = "layoutControlItem71";
		this.layoutControlItem71.Location = new System.Drawing.Point(0, 54);
		this.layoutControlItem71.Name = "layoutControlItem71";
		this.layoutControlItem71.Size = new System.Drawing.Size(159, 29);
		this.layoutControlItem71.Text = "layoutControlItem71";
		this.layoutControlItem71.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem71.TextToControlDistance = 0;
		this.layoutControlItem71.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(0, 30);
		this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(339, 24);
		this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
		this.emptySpaceItem1.Text = "emptySpaceItem1";
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem2.Control = this.txtOpenningBalance;
		this.layoutControlItem2.CustomizationFormText = "Openning Balance";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem2.Size = new System.Drawing.Size(339, 30);
		this.layoutControlItem2.Text = "Opening Balance";
		this.layoutControlItem2.TextSize = new System.Drawing.Size(108, 18);
		this.layoutControlItem3.Control = this.simpleButton1;
		this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
		this.layoutControlItem3.Location = new System.Drawing.Point(159, 54);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(180, 29);
		this.layoutControlItem3.Text = "layoutControlItem3";
		this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem3.TextToControlDistance = 0;
		this.layoutControlItem3.TextVisible = false;
		this.layoutControlAccountName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlAccountName.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlAccountName.Control = this.txtAccountName;
		this.layoutControlAccountName.CustomizationFormText = "Account Name";
		this.layoutControlAccountName.Location = new System.Drawing.Point(0, 102);
		this.layoutControlAccountName.Name = "layoutControlAccountName";
		this.layoutControlAccountName.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlAccountName.Size = new System.Drawing.Size(339, 30);
		this.layoutControlAccountName.Text = "Sub Account";
		this.layoutControlAccountName.TextSize = new System.Drawing.Size(108, 18);
		this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem1.Control = this.cboSubAccounts;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(0, 51);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2);
		this.layoutControlItem1.Size = new System.Drawing.Size(339, 51);
		this.layoutControlItem1.Text = "Major Account";
		this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem1.TextSize = new System.Drawing.Size(108, 18);
		this.timer1.Enabled = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(343, 219);
		base.Controls.Add(this.layoutControl21);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AddSubAccounts";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Sub Accounts";
		((System.ComponentModel.ISupportInitialize)this.layoutControl21).EndInit();
		this.layoutControl21.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtOpenningBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboSubAccounts.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboAccountCategories.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtAccountName.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup47).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem66).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem71).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlAccountName).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		base.ResumeLayout(false);
	}
}
