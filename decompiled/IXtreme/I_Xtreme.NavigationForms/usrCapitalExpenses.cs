using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using AlienAge.CustomGrid;
using AlienAge.Semesters;
using DevExpress.Data;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using I_Xtreme.DialogForms;
using I_Xtreme.ExtremeClasses;
using I_Xtreme.PaymentVoucher;

namespace I_Xtreme.NavigationForms;

public class usrCapitalExpenses : XtraUserControl
{
	private SqlTransaction _trans;

	private DataTable dt;

	private DataTable _dt;

	private string _sub_vote = string.Empty;

	private string _vote = string.Empty;

	private string accNo = string.Empty;

	private DataTable _dt_TA;

	private GridHitInfo downHitInfo = null;

	private IContainer components = null;

	private LayoutControl layoutControl1;

	private LayoutControlGroup layoutControlGroup1;

	private SimpleButton simpleButton4;

	private SimpleButton simpleButton3;

	private DateEdit dtVoucherDate;

	private TextEdit txtVoucherNo;

	private SimpleButton simpleButton2;

	private SimpleButton simpleButton1;

	private MyGridControl gridControl1;

	private MyGridView dragOver;

	private LayoutControlItem layoutControlItem1;

	private LayoutControlItem layoutControlItem3;

	private LayoutControlItem layoutControlItem4;

	private LayoutControlItem layoutControlItem6;

	private LayoutControlItem layoutControlItem7;

	private MyGridControl gridControl2;

	private MyGridView gridView2;

	private LayoutControlItem layoutControlItem8;

	private System.Windows.Forms.Timer timer1;

	private TextEdit txtStandingBalance;

	private LayoutControlItem layoutControlItem5;

	private TextEdit txtChequeNo;

	private LayoutControlItem layoutControlItem9;

	private EmptySpaceItem emptySpaceItem2;

	private LayoutControlItem layoutControlItem11;

	private EmptySpaceItem emptySpaceItem1;

	private LayoutControlItem layoutControlItem10;

	private ComboBoxEdit cboCashAccount;

	private LayoutControlItem layoutControlItem2;

	private TextEdit txtAccNo;

	private LayoutControlItem layoutControlItem12;

	private GridColumn gridColumn1;

	private GridColumn gridColumn2;

	private GridColumn gridColumn3;

	private GridColumn gridColumn4;

	private GridColumn gridColumn5;

	private GridColumn gridColumnQTY;

	private GridColumn gridColumnRATE;

	private GridColumn gridColumn8;

	private RepositoryItemTextEdit repositoryItemTextEdit2;

	private RepositoryItemTextEdit repositoryItemTextEdit1;

	private LabelControl labelControl1;

	private LayoutControlItem layoutControlItem13;

	public usrCapitalExpenses()
	{
		InitializeComponent();
	}

	private void InitializeItems()
	{
		LoadExpensesItems();
	}

	private void gridView2_MouseDown(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		downHitInfo = null;
		GridHitInfo gridHitInfo = gridView.CalcHitInfo(new Point(e.X, e.Y));
		if (Control.ModifierKeys == Keys.None && e.Button == MouseButtons.Left && gridHitInfo.RowHandle >= 0)
		{
			downHitInfo = gridHitInfo;
		}
	}

	private void LoadTempCheque()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT id, VoucherNo, Date, Qty, Rate, accNo, item, ChequeNo, narration, ExpenseType, Qty * Rate AS TOTAL  FROM tbl_TempVoucher WHERE VoucherNo='" + txtVoucherNo.Text + "' AND VoucherType='CapitalExpenses'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TempItems");
		_dt = new DataTable();
		_dt = dataSet.Tables[0];
		gridControl1.DataSource = _dt.DefaultView;
	}

	private void TempChequeExists()
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT id, VoucherNo, Date, Qty, Rate, accNo, item, ChequeNo, narration, ExpenseType, Qty * Rate AS TOTAL FROM tbl_TempVoucher WHERE VoucherType='CapitalExpenses'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "TempItems");
		_dt = new DataTable();
		_dt = dataSet.Tables[0];
		if (_dt.Rows.Count <= 0)
		{
			return;
		}
		gridControl1.DataSource = _dt.DefaultView;
		IEnumerator enumerator = _dt.Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				txtVoucherNo.Text = dataRow["VoucherNo"].ToString();
				txtChequeNo.Text = dataRow["ChequeNo"].ToString();
				dtVoucherDate.DateTime = Convert.ToDateTime(dataRow["Date"].ToString());
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
	}

	private void DeleteCheque()
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to cancel voucher (" + txtVoucherNo.Text + ")?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_TempVoucher WHERE VoucherNo=@VoucherNo AND VoucherType='CapitalExpenses'",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 30);
			sqlParameter.Value = txtVoucherNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				gridControl1.DataSource = null;
				txtVoucherNo.Properties.ReadOnly = false;
				txtChequeNo.Properties.ReadOnly = false;
				dtVoucherDate.Properties.ReadOnly = false;
				txtVoucherNo.Text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void DeleteItem(string accNo, string item)
	{
		try
		{
			DialogResult dialogResult = XtraMessageBox.Show("Do you really want to remove " + item + " from the current voucher (" + txtVoucherNo.Text + ")?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "DELETE FROM tbl_TempVoucher WHERE VoucherNo=@VoucherNo AND accNo=@accNo AND VoucherType='CapitalExpenses'",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 30);
			sqlParameter.Value = txtVoucherNo.Text;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = accNo;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() > 0)
			{
				LoadTempCheque();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void gridView2_MouseMove(object sender, MouseEventArgs e)
	{
		GridView gridView = sender as GridView;
		if (e.Button == MouseButtons.Left && downHitInfo != null)
		{
			Size dragSize = SystemInformation.DragSize;
			Rectangle rectangle = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
			if (!rectangle.Contains(new Point(e.X, e.Y)))
			{
				DataRow dataRow = gridView.GetDataRow(downHitInfo.RowHandle);
				gridView.GridControl.DoDragDrop(dataRow, DragDropEffects.Move);
				downHitInfo = null;
				DXMouseEventArgs.GetMouseArgs(e).Handled = true;
			}
		}
	}

	private void gridControl1_DragOver(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(typeof(DataRow)))
		{
			e.Effect = DragDropEffects.Move;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void gridControl1_DragDrop(object sender, DragEventArgs e)
	{
		AdditemToVoucher();
	}

	private void LoadExpensesItems()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo AS AccNo, _ga.accName AS Vote, gas.SubAccoutName AS Item FROM tbl_generalAccounts AS ga INNER JOIN tbl_generalAccounts_Sub AS gas ON ga.accNo = gas.accNo INNER JOIN tbl_generalAccounts AS _ga ON ga.accNo = _ga.accNo WHERE (ga.categoryId = 4000)", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "expenseItems");
			dt = new DataTable();
			dt = dataSet.Tables[0];
			gridControl2.DataSource = dt.DefaultView;
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void usrPettyExpenses_Load(object sender, EventArgs e)
	{
		SplashScreenManager.ShowForm(typeof(WaitForm1));
		SplashScreenManager.Default.SetWaitFormDescription("Compiling expenditure items list...");
		SplashScreenManager.Default.SendCommand(WaitForm1.WaitFormCommand.LoadExpenseItems, 0);
		Thread.Sleep(25);
		InitializeItems();
		dtVoucherDate.DateTime = DateTime.Now;
		txtChequeNo.Focus();
		TempChequeExists();
		LoadTransactingAccount();
		SplashScreenManager.CloseForm(throwExceptionIfAlreadyClosed: false);
	}

	private void LoadTransactingAccount()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT gas.subAccountNo,gas.SubAccoutName,ga.accName FROM tbl_generalAccounts ga RIGHT OUTER JOIN tbl_generalAccounts_Sub gas ON gas.accNo = ga.accNo GROUP BY gas.subAccountNo,gas.SubAccoutName,ga.accName HAVING  (ga.accName = 'Bank Accounts' OR ga.accName = 'Cash' OR ga.accName = 'Mobile Money')", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			_dt_TA = new DataTable();
			_dt_TA = dataSet.Tables[0];
			cboCashAccount.Properties.Items.Clear();
			foreach (DataRow row in _dt_TA.Rows)
			{
				cboCashAccount.Properties.Items.Add(row["SubAccoutName"]);
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void AdditemToVoucher()
	{
		if (txtVoucherNo.Text != string.Empty)
		{
			if (gridView2.GetFocusedDataSourceRowIndex() > -1 && txtChequeNo.Text != null && txtVoucherNo.Text != null)
			{
				_ = dtVoucherDate.DateTime;
				if (true)
				{
					SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand
					{
						CommandText = "SELECT VoucherNo FROM Expenses WHERE VoucherNo=@VoucherNo",
						CommandType = CommandType.Text,
						Connection = sqlConnection
					};
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@VoucherNo", SqlDbType.VarChar, 20);
					sqlParameter.Value = txtVoucherNo.Text;
					sqlParameter.Direction = ParameterDirection.Input;
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						sqlDataReader.Close();
						SqlCommand sqlCommand2 = new SqlCommand
						{
							Connection = sqlConnection,
							CommandText = "SELECT * FROM tbl_TempVoucher WHERE accNo=@accNo AND ExpenseType=@ExpenseType AND VoucherType='CapitalExpenses'",
							CommandType = CommandType.Text
						};
						SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
						sqlParameter2.Value = accNo;
						sqlParameter2.Direction = ParameterDirection.Input;
						sqlParameter2 = sqlCommand2.Parameters.Add("@ExpenseType", SqlDbType.VarChar, 50);
						sqlParameter2.Value = _sub_vote;
						sqlParameter2.Direction = ParameterDirection.Input;
						SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
						if (!sqlDataReader2.HasRows)
						{
							sqlDataReader2.Close();
							sqlConnection.Close();
							QtyAmount qtyAmount = new QtyAmount("CapitalExpenses");
							qtyAmount.sub_vote = _sub_vote;
							qtyAmount.vote = _vote;
							qtyAmount.accountNo = accNo;
							qtyAmount.CheckNo = txtChequeNo.Text;
							qtyAmount.VoucherNo = txtVoucherNo.Text.ToUpper();
							qtyAmount.Date = dtVoucherDate.DateTime;
							if (qtyAmount.ShowDialog() == DialogResult.OK)
							{
								TempChequeExists();
							}
						}
						else
						{
							sqlDataReader2.Close();
							sqlConnection.Close();
							XtraMessageBox.Show($"{_sub_vote} is already added to the voucher {txtVoucherNo.Text}.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					else
					{
						sqlDataReader.Close();
						sqlConnection.Close();
						XtraMessageBox.Show("Voucher No. is already used.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					return;
				}
			}
			XtraMessageBox.Show("No item is selected or the Voucher/Cheque No. is not provided or the Date field is blank.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			XtraMessageBox.Show("Please enter a Voucher No.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtVoucherNo.Focus();
		}
	}

	private void simpleButton1_Click(object sender, EventArgs e)
	{
		AdditemToVoucher();
	}

	private void gridControl2_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Return)
		{
			AdditemToVoucher();
		}
	}

	private void simpleButton2_Click(object sender, EventArgs e)
	{
		if (dragOver.GetFocusedDataSourceRowIndex() > -1)
		{
			DataRow dataRow = _dt.Rows[dragOver.GetFocusedDataSourceRowIndex()];
			DeleteItem(dataRow["accNo"].ToString(), dataRow["ExpenseType"].ToString());
		}
		else
		{
			XtraMessageBox.Show("Please select an item you want to remove from the cheque.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void gridControl1_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			if (dragOver.GetFocusedDataSourceRowIndex() > -1)
			{
				DataRow dataRow = _dt.Rows[dragOver.GetFocusedDataSourceRowIndex()];
				DeleteItem(dataRow["accNo"].ToString(), dataRow["item"].ToString());
			}
			else
			{
				XtraMessageBox.Show("Please select an item you want to remove from the cheque.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		DataRow dataRow = dt.Rows[gridView2.GetFocusedDataSourceRowIndex()];
		_sub_vote = dataRow["Item"].ToString();
		_vote = dataRow["Vote"].ToString();
		accNo = dataRow["AccNo"].ToString();
	}

	private void simpleButton3_Click(object sender, EventArgs e)
	{
		DeleteCheque();
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		if (dragOver.RowCount == 0)
		{
			simpleButton3.Enabled = false;
			simpleButton4.Enabled = false;
		}
		else
		{
			simpleButton3.Enabled = true;
			simpleButton4.Enabled = true;
		}
	}

	private void UpdateTempVoucher()
	{
		try
		{
			int result = ((!int.TryParse(dragOver.GetRowCellValue(dragOver.GetFocusedDataSourceRowIndex(), "Qty").ToString(), out result)) ? 1 : result);
			double result2 = (double.TryParse(dragOver.GetRowCellValue(dragOver.GetFocusedDataSourceRowIndex(), "Rate").ToString(), out result2) ? result2 : 0.0);
			string value = dragOver.GetRowCellValue(dragOver.GetFocusedDataSourceRowIndex(), "narration").ToString();
			string value2 = dragOver.GetRowCellValue(dragOver.GetFocusedDataSourceRowIndex(), "accNo").ToString();
			using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
			sqlConnection.Open();
			using SqlCommand sqlCommand = new SqlCommand
			{
				Connection = sqlConnection,
				CommandText = "UPDATE tbl_TempVoucher SET Qty=@Qty,Rate=@Rate,Narration=@Narration WHERE accNo=@accNo AND VoucherType='CapitalExpenses'",
				CommandType = CommandType.Text
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.Add("@Qty", SqlDbType.Int);
			sqlParameter.Value = result;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Rate", SqlDbType.Float);
			sqlParameter.Value = result2;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
			sqlParameter.Value = value2;
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar, 30);
			sqlParameter.Value = value;
			sqlParameter.Direction = ParameterDirection.Input;
			if (sqlCommand.ExecuteNonQuery() != 0)
			{
				sqlConnection.Close();
				LoadTempCheque();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CloseCheque()
	{
		try
		{
			long voucherTotal = Convert.ToInt64(dragOver.Columns["TOTAL"].SummaryItem.SummaryValue.ToString());
			string empty = string.Empty;
			string empty2 = string.Empty;
			if (string.IsNullOrEmpty(txtChequeNo.Text))
			{
				empty2 = "Cash";
			}
			else
			{
				empty2 = "Cheque";
			}
			ConfirmVoucherClose confirmVoucherClose = new ConfirmVoucherClose();
			DialogResult dialogResult = confirmVoucherClose.ShowDialog();
			if (dialogResult != DialogResult.Yes)
			{
				return;
			}
			CaptureDate captureDate = new CaptureDate();
			string captureDate2 = CaptureDate.GetCaptureDate();
			int num = 0;
			for (int i = 0; i < dragOver.RowCount; i++)
			{
				num++;
				string text = dragOver.GetRowCellValue(i, "ExpenseType").ToString();
				string text2 = dragOver.GetRowCellValue(i, "item").ToString();
				string text3 = dragOver.GetRowCellValue(i, "ChequeNo").ToString();
				empty = (VoucherParameters.VoucherNoSelected = dragOver.GetRowCellValue(i, "VoucherNo").ToString());
				string text5 = dragOver.GetRowCellValue(i, "narration").ToString();
				string value = dragOver.GetRowCellValue(i, "accNo").ToString();
				float num2 = Convert.ToInt64(dragOver.GetRowCellValue(i, "TOTAL").ToString());
				int num3 = Convert.ToInt32(dragOver.GetRowCellValue(i, "QTY"));
				I_Xtreme.ExtremeClasses.PaymentVoucher.SetVoucherInformation(empty, voucherTotal);
				using SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				_trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Transaction = _trans,
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration,@TrRef)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = value;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = text + "-" + text5;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter.Value = WorkingSemesters.GetWorkingSemester();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter.Value = dtVoucherDate.DateTime.ToShortDateString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter.Value = dtVoucherDate.DateTime.ToString("MMMM");
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter.Value = dtVoucherDate.DateTime.Year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter.Value = num2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter.Value = 0;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter.Value = captureDate2;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = text + "-" + text5;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
					sqlParameter.Value = text3 + "-" + empty;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Transaction = _trans,
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration,TrRef) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration,@TrRef)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter2.Value = txtAccNo.Text;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter2.Value = text + "-" + text5;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter2.Value = WorkingSemesters.GetWorkingSemester();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter2.Value = dtVoucherDate.DateTime.ToShortDateString();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter2.Value = dtVoucherDate.DateTime.ToString("MMMM");
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter2.Value = dtVoucherDate.DateTime.Year;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter2.Value = 0;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter2.Value = num2;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter2.Value = captureDate2;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter2.Value = text + "-" + text5;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@TrRef", SqlDbType.VarChar, 30);
					sqlParameter2.Value = text3 + "-" + empty;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = _trans,
					CommandText = "DELETE FROM tbl_TempVoucher WHERE accNo=@accNo AND VoucherType='CapitalExpenses'",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter3 = sqlCommand3.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter3.Value = value;
					sqlParameter3.Direction = ParameterDirection.Input;
					sqlCommand3.ExecuteNonQuery();
				}
				_trans.Commit();
				sqlConnection.Close();
			}
			if (num == dragOver.RowCount)
			{
				LoadTempCheque();
				txtVoucherNo.Properties.ReadOnly = false;
				dtVoucherDate.Properties.ReadOnly = false;
				txtVoucherNo.Text = string.Empty;
				dtVoucherDate.DateTime = DateTime.Now;
				XtraMessageBox.Show("Voucher Closed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				txtStandingBalance.Text = LoadTransactingAccountBalance(txtAccNo.Text).ToString("#,#.0");
				PaymentVoucherRpt report = new PaymentVoucherRpt();
				ReportPrintTool reportPrintTool = new ReportPrintTool(report);
				reportPrintTool.ShowRibbonPreview();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void simpleButton4_Click(object sender, EventArgs e)
	{
		try
		{
			if (cboCashAccount.SelectedIndex != -1)
			{
				if (Convert.ToDouble(dragOver.Columns["TOTAL"].SummaryItem.SummaryValue) <= Convert.ToDouble(txtStandingBalance.Text))
				{
					CloseCheque();
				}
				else
				{
					XtraMessageBox.Show("This transaction is not possible because there is not enough funds on the cash account.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				XtraMessageBox.Show("Please select The Account you wish to spend from.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				cboCashAccount.Focus();
				cboCashAccount.BackColor = Color.Red;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private bool ChequeNoExists(string chequeNo)
	{
		bool result = false;
		using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT ChequeNo FROM tbl_ChequeTransactions WHERE ChequeNo='{chequeNo}'", DataConnection.ConnectToDatabase()))
		{
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "CheckExists");
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				result = false;
			}
			else
			{
				foreach (DataRow row in dataSet.Tables[0].Rows)
				{
					result = !(row["ChequeNo"].ToString() == string.Empty);
				}
			}
		}
		return result;
	}

	private double LoadTransactingAccountBalance(string accNo)
	{
		double result = 0.0;
		try
		{
			string selectCommandText = "SELECT (SUM(ISNULL(Debit,0))-SUM(ISNULL(Credit,0))) AS Total FROM tbl_StatementOfAffairs WHERE _date <= '" + FinalAccounts.BooksClosinggDate.ToString("MM-dd-yyyy") + "' AND accNo='" + accNo + "'";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccountStandingBalance");
			DataTable dataTable = new DataTable();
			dataTable = dataSet.Tables[0];
			IEnumerator enumerator = dataTable.Rows.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					result = (double.TryParse(dataRow["Total"].ToString(), out result) ? result : 0.0);
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
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		return result;
	}

	private void cboCashAccount_Closed(object sender, ClosedEventArgs e)
	{
		if (cboCashAccount.SelectedIndex > -1)
		{
			DataRow dataRow = _dt_TA.Rows[cboCashAccount.SelectedIndex];
			txtAccNo.Text = dataRow["subAccountNo"].ToString();
			txtStandingBalance.Text = LoadTransactingAccountBalance(txtAccNo.Text).ToString("#,#.0");
		}
	}

	private void dragOver_HiddenEditor(object sender, EventArgs e)
	{
		UpdateTempVoucher();
	}

	private void dragOver_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
	{
		if ((dragOver.FocusedColumn == gridColumnQTY || dragOver.FocusedColumn == gridColumnRATE) && (!int.TryParse(e.Value.ToString(), out var result) || result < 0))
		{
			e.Valid = false;
		}
	}

	private void dragOver_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
	{
		e.ExceptionMode = ExceptionMode.DisplayError;
		e.WindowCaption = "Input Error";
		e.ErrorText = "You have to enter digits only.";
		dragOver.HideEditor();
	}

	private void cboCashAccount_QueryPopUp(object sender, CancelEventArgs e)
	{
		cboCashAccount.BackColor = Color.White;
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
		this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
		this.txtAccNo = new DevExpress.XtraEditors.TextEdit();
		this.cboCashAccount = new DevExpress.XtraEditors.ComboBoxEdit();
		this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
		this.txtChequeNo = new DevExpress.XtraEditors.TextEdit();
		this.txtStandingBalance = new DevExpress.XtraEditors.TextEdit();
		this.gridControl2 = new AlienAge.CustomGrid.MyGridControl();
		this.gridView2 = new AlienAge.CustomGrid.MyGridView();
		this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
		this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
		this.dtVoucherDate = new DevExpress.XtraEditors.DateEdit();
		this.txtVoucherNo = new DevExpress.XtraEditors.TextEdit();
		this.gridControl1 = new AlienAge.CustomGrid.MyGridControl();
		this.dragOver = new AlienAge.CustomGrid.MyGridView();
		this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.gridColumnQTY = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.gridColumnRATE = new DevExpress.XtraGrid.Columns.GridColumn();
		this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
		this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
		this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
		this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
		this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
		this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
		this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
		this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).BeginInit();
		this.layoutControl1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.cboCashAccount.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtChequeNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtStandingBalance.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtVoucherDate.Properties.CalendarTimeProperties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dtVoucherDate.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.txtVoucherNo.Properties).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dragOver).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).BeginInit();
		base.SuspendLayout();
		this.layoutControl1.Controls.Add(this.labelControl1);
		this.layoutControl1.Controls.Add(this.txtAccNo);
		this.layoutControl1.Controls.Add(this.cboCashAccount);
		this.layoutControl1.Controls.Add(this.simpleButton2);
		this.layoutControl1.Controls.Add(this.simpleButton1);
		this.layoutControl1.Controls.Add(this.txtChequeNo);
		this.layoutControl1.Controls.Add(this.txtStandingBalance);
		this.layoutControl1.Controls.Add(this.gridControl2);
		this.layoutControl1.Controls.Add(this.simpleButton4);
		this.layoutControl1.Controls.Add(this.simpleButton3);
		this.layoutControl1.Controls.Add(this.dtVoucherDate);
		this.layoutControl1.Controls.Add(this.txtVoucherNo);
		this.layoutControl1.Controls.Add(this.gridControl1);
		this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.layoutControl1.Location = new System.Drawing.Point(0, 0);
		this.layoutControl1.Name = "layoutControl1";
		this.layoutControl1.Root = this.layoutControlGroup1;
		this.layoutControl1.Size = new System.Drawing.Size(870, 488);
		this.layoutControl1.TabIndex = 0;
		this.layoutControl1.Text = "layoutControl1";
		this.txtAccNo.Location = new System.Drawing.Point(4, 122);
		this.txtAccNo.Name = "txtAccNo";
		this.txtAccNo.Properties.ReadOnly = true;
		this.txtAccNo.Size = new System.Drawing.Size(234, 20);
		this.txtAccNo.StyleController = this.layoutControl1;
		this.txtAccNo.TabIndex = 15;
		this.cboCashAccount.Location = new System.Drawing.Point(4, 48);
		this.cboCashAccount.Name = "cboCashAccount";
		this.cboCashAccount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCashAccount.Properties.Appearance.Options.UseFont = true;
		this.cboCashAccount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.cboCashAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.cboCashAccount.Size = new System.Drawing.Size(234, 24);
		this.cboCashAccount.StyleController = this.layoutControl1;
		this.cboCashAccount.TabIndex = 14;
		this.cboCashAccount.QueryPopUp += new System.ComponentModel.CancelEventHandler(cboCashAccount_QueryPopUp);
		this.cboCashAccount.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(cboCashAccount_Closed);
		this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton2.Location = new System.Drawing.Point(242, 280);
		this.simpleButton2.Name = "simpleButton2";
		this.simpleButton2.Size = new System.Drawing.Size(19, 22);
		this.simpleButton2.StyleController = this.layoutControl1;
		this.simpleButton2.TabIndex = 1;
		this.simpleButton2.Text = "<<";
		this.simpleButton2.Click += new System.EventHandler(simpleButton2_Click);
		this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.simpleButton1.Location = new System.Drawing.Point(242, 254);
		this.simpleButton1.Name = "simpleButton1";
		this.simpleButton1.Size = new System.Drawing.Size(19, 22);
		this.simpleButton1.StyleController = this.layoutControl1;
		this.simpleButton1.TabIndex = 0;
		this.simpleButton1.Text = ">>";
		this.simpleButton1.Click += new System.EventHandler(simpleButton1_Click);
		this.txtChequeNo.Location = new System.Drawing.Point(4, 206);
		this.txtChequeNo.Name = "txtChequeNo";
		this.txtChequeNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtChequeNo.Properties.Appearance.Options.UseFont = true;
		this.txtChequeNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtChequeNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtChequeNo.Size = new System.Drawing.Size(234, 24);
		this.txtChequeNo.StyleController = this.layoutControl1;
		this.txtChequeNo.TabIndex = 13;
		this.txtStandingBalance.Location = new System.Drawing.Point(4, 92);
		this.txtStandingBalance.Name = "txtStandingBalance";
		this.txtStandingBalance.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStandingBalance.Properties.Appearance.Options.UseFont = true;
		this.txtStandingBalance.Properties.Appearance.Options.UseTextOptions = true;
		this.txtStandingBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
		this.txtStandingBalance.Properties.ReadOnly = true;
		this.txtStandingBalance.Size = new System.Drawing.Size(234, 26);
		this.txtStandingBalance.StyleController = this.layoutControl1;
		this.txtStandingBalance.TabIndex = 12;
		this.gridControl2.Location = new System.Drawing.Point(4, 300);
		this.gridControl2.MainView = this.gridView2;
		this.gridControl2.Name = "gridControl2";
		this.gridControl2.Size = new System.Drawing.Size(234, 184);
		this.gridControl2.TabIndex = 11;
		this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.gridView2 });
		this.gridControl2.KeyDown += new System.Windows.Forms.KeyEventHandler(gridControl2_KeyDown);
		this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.Empty.Options.UseFont = true;
		this.gridView2.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.FilterPanel.Options.UseFont = true;
		this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
		this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
		this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
		this.gridView2.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.GroupFooter.Options.UseFont = true;
		this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.GroupRow.Options.UseFont = true;
		this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
		this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
		this.gridView2.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.Preview.Options.UseFont = true;
		this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.Row.Options.UseFont = true;
		this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
		this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
		this.gridView2.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 9f);
		this.gridView2.Appearance.TopNewRow.Options.UseFont = true;
		this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.gridView2.FixedLineWidth = 3;
		this.gridView2.GridControl = this.gridControl2;
		this.gridView2.GroupFormat = "{1} {2}";
		this.gridView2.Name = "gridView2";
		this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
		this.gridView2.OptionsBehavior.Editable = false;
		this.gridView2.OptionsCustomization.AllowGroup = false;
		this.gridView2.OptionsFind.AlwaysVisible = true;
		this.gridView2.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.gridView2.OptionsView.ShowGroupPanel = false;
		this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.gridView2.OptionsView.ShowIndicator = false;
		this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView2_FocusedRowChanged);
		this.gridView2.MouseDown += new System.Windows.Forms.MouseEventHandler(gridView2_MouseDown);
		this.gridView2.MouseMove += new System.Windows.Forms.MouseEventHandler(gridView2_MouseMove);
		this.simpleButton4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton4.Appearance.Options.UseFont = true;
		this.simpleButton4.Location = new System.Drawing.Point(265, 461);
		this.simpleButton4.Name = "simpleButton4";
		this.simpleButton4.Size = new System.Drawing.Size(329, 23);
		this.simpleButton4.StyleController = this.layoutControl1;
		this.simpleButton4.TabIndex = 10;
		this.simpleButton4.Text = "Confirm && Close";
		this.simpleButton4.Click += new System.EventHandler(simpleButton4_Click);
		this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.simpleButton3.Appearance.Options.UseFont = true;
		this.simpleButton3.Location = new System.Drawing.Point(598, 461);
		this.simpleButton3.Name = "simpleButton3";
		this.simpleButton3.Size = new System.Drawing.Size(268, 23);
		this.simpleButton3.StyleController = this.layoutControl1;
		this.simpleButton3.TabIndex = 9;
		this.simpleButton3.Text = "Cancel Voucher";
		this.simpleButton3.Click += new System.EventHandler(simpleButton3_Click);
		this.dtVoucherDate.EditValue = null;
		this.dtVoucherDate.Location = new System.Drawing.Point(4, 162);
		this.dtVoucherDate.Name = "dtVoucherDate";
		this.dtVoucherDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtVoucherDate.Properties.Appearance.Options.UseFont = true;
		this.dtVoucherDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.dtVoucherDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtVoucherDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[1]
		{
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
		});
		this.dtVoucherDate.Properties.DisplayFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtVoucherDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtVoucherDate.Properties.EditFormat.FormatString = "{0:dd-MMM-yy}";
		this.dtVoucherDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
		this.dtVoucherDate.Size = new System.Drawing.Size(234, 24);
		this.dtVoucherDate.StyleController = this.layoutControl1;
		this.dtVoucherDate.TabIndex = 7;
		this.txtVoucherNo.Location = new System.Drawing.Point(4, 250);
		this.txtVoucherNo.Name = "txtVoucherNo";
		this.txtVoucherNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtVoucherNo.Properties.Appearance.Options.UseFont = true;
		this.txtVoucherNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
		this.txtVoucherNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtVoucherNo.Size = new System.Drawing.Size(234, 24);
		this.txtVoucherNo.StyleController = this.layoutControl1;
		this.txtVoucherNo.TabIndex = 6;
		this.gridControl1.AllowDrop = true;
		this.gridControl1.Location = new System.Drawing.Point(265, 32);
		this.gridControl1.MainView = this.dragOver;
		this.gridControl1.Name = "gridControl1";
		this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[2] { this.repositoryItemTextEdit1, this.repositoryItemTextEdit2 });
		this.gridControl1.Size = new System.Drawing.Size(601, 425);
		this.gridControl1.TabIndex = 4;
		this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1] { this.dragOver });
		this.gridControl1.DragDrop += new System.Windows.Forms.DragEventHandler(gridControl1_DragDrop);
		this.gridControl1.DragOver += new System.Windows.Forms.DragEventHandler(gridControl1_DragOver);
		this.gridControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(gridControl1_KeyDown);
		this.dragOver.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.FilterPanel.Options.UseFont = true;
		this.dragOver.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.FocusedCell.Options.UseBackColor = true;
		this.dragOver.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.FocusedRow.Options.UseBackColor = true;
		this.dragOver.Appearance.FocusedRow.Options.UseFont = true;
		this.dragOver.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.FooterPanel.Options.UseFont = true;
		this.dragOver.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.GroupFooter.Options.UseFont = true;
		this.dragOver.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.GroupRow.Options.UseFont = true;
		this.dragOver.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.HeaderPanel.Options.UseFont = true;
		this.dragOver.Appearance.HideSelectionRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.HideSelectionRow.Options.UseBackColor = true;
		this.dragOver.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.Preview.Options.UseFont = true;
		this.dragOver.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.Row.Options.UseFont = true;
		this.dragOver.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.Highlight;
		this.dragOver.Appearance.SelectedRow.Options.UseBackColor = true;
		this.dragOver.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 11.25f);
		this.dragOver.Appearance.TopNewRow.Options.UseFont = true;
		this.dragOver.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[8] { this.gridColumn1, this.gridColumn2, this.gridColumn3, this.gridColumn5, this.gridColumn4, this.gridColumnQTY, this.gridColumnRATE, this.gridColumn8 });
		this.dragOver.FixedLineWidth = 3;
		this.dragOver.GridControl = this.gridControl1;
		this.dragOver.GroupFormat = "{1}";
		this.dragOver.Name = "dragOver";
		this.dragOver.OptionsBehavior.AutoExpandAllGroups = true;
		this.dragOver.OptionsCustomization.AllowGroup = false;
		this.dragOver.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
		this.dragOver.OptionsView.ShowFooter = true;
		this.dragOver.OptionsView.ShowGroupPanel = false;
		this.dragOver.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
		this.dragOver.OptionsView.ShowIndicator = false;
		this.dragOver.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
		this.dragOver.HiddenEditor += new System.EventHandler(dragOver_HiddenEditor);
		this.dragOver.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(dragOver_ValidatingEditor);
		this.dragOver.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(dragOver_InvalidValueException);
		this.gridColumn1.Caption = "id";
		this.gridColumn1.FieldName = "id";
		this.gridColumn1.Name = "gridColumn1";
		this.gridColumn2.Caption = "VoucherNo";
		this.gridColumn2.FieldName = "VoucherNo";
		this.gridColumn2.Name = "gridColumn2";
		this.gridColumn3.Caption = "item";
		this.gridColumn3.FieldName = "item";
		this.gridColumn3.Name = "gridColumn3";
		this.gridColumn5.Caption = "Particulars";
		this.gridColumn5.FieldName = "ExpenseType";
		this.gridColumn5.Name = "gridColumn5";
		this.gridColumn5.OptionsColumn.AllowEdit = false;
		this.gridColumn5.OptionsColumn.ReadOnly = true;
		this.gridColumn5.Visible = true;
		this.gridColumn5.VisibleIndex = 0;
		this.gridColumn5.Width = 259;
		this.gridColumn4.Caption = "Narration";
		this.gridColumn4.FieldName = "narration";
		this.gridColumn4.Name = "gridColumn4";
		this.gridColumn4.OptionsColumn.AllowEdit = false;
		this.gridColumn4.OptionsColumn.ReadOnly = true;
		this.gridColumn4.Visible = true;
		this.gridColumn4.VisibleIndex = 1;
		this.gridColumn4.Width = 341;
		this.gridColumnQTY.Caption = "Qty";
		this.gridColumnQTY.ColumnEdit = this.repositoryItemTextEdit2;
		this.gridColumnQTY.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumnQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumnQTY.FieldName = "Qty";
		this.gridColumnQTY.Name = "gridColumnQTY";
		this.gridColumnQTY.Visible = true;
		this.gridColumnQTY.VisibleIndex = 2;
		this.gridColumnQTY.Width = 57;
		this.repositoryItemTextEdit2.AutoHeight = false;
		this.repositoryItemTextEdit2.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.repositoryItemTextEdit2.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
		this.repositoryItemTextEdit2.MaskSettings.Set("mask", "##,###,###,###");
		this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
		this.repositoryItemTextEdit2.UseMaskAsDisplayFormat = true;
		this.gridColumnRATE.Caption = "Rate";
		this.gridColumnRATE.ColumnEdit = this.repositoryItemTextEdit1;
		this.gridColumnRATE.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumnRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumnRATE.FieldName = "Rate";
		this.gridColumnRATE.Name = "gridColumnRATE";
		this.gridColumnRATE.Visible = true;
		this.gridColumnRATE.VisibleIndex = 3;
		this.gridColumnRATE.Width = 210;
		this.repositoryItemTextEdit1.AutoHeight = false;
		this.repositoryItemTextEdit1.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
		this.repositoryItemTextEdit1.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
		this.repositoryItemTextEdit1.MaskSettings.Set("mask", "##,###,###,###");
		this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
		this.repositoryItemTextEdit1.UseMaskAsDisplayFormat = true;
		this.gridColumn8.Caption = "Total";
		this.gridColumn8.DisplayFormat.FormatString = "{0:#,#}";
		this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
		this.gridColumn8.FieldName = "TOTAL";
		this.gridColumn8.Name = "gridColumn8";
		this.gridColumn8.OptionsColumn.AllowEdit = false;
		this.gridColumn8.OptionsColumn.ReadOnly = true;
		this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
		{
			new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", "{0:#,#}")
		});
		this.gridColumn8.Visible = true;
		this.gridColumn8.VisibleIndex = 4;
		this.gridColumn8.Width = 217;
		this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
		this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
		this.layoutControlGroup1.GroupBordersVisible = false;
		this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[15]
		{
			this.layoutControlItem1, this.layoutControlItem4, this.layoutControlItem8, this.layoutControlItem9, this.emptySpaceItem2, this.layoutControlItem11, this.emptySpaceItem1, this.layoutControlItem7, this.layoutControlItem6, this.layoutControlItem10,
			this.layoutControlItem12, this.layoutControlItem2, this.layoutControlItem5, this.layoutControlItem3, this.layoutControlItem13
		});
		this.layoutControlGroup1.Name = "layoutControlGroup1";
		this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
		this.layoutControlGroup1.Size = new System.Drawing.Size(870, 488);
		this.layoutControlGroup1.TextVisible = false;
		this.layoutControlItem1.Control = this.gridControl1;
		this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
		this.layoutControlItem1.Location = new System.Drawing.Point(261, 28);
		this.layoutControlItem1.Name = "layoutControlItem1";
		this.layoutControlItem1.Size = new System.Drawing.Size(605, 429);
		this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem1.TextVisible = false;
		this.layoutControlItem4.Control = this.dtVoucherDate;
		this.layoutControlItem4.CustomizationFormText = "Date:";
		this.layoutControlItem4.Location = new System.Drawing.Point(0, 142);
		this.layoutControlItem4.Name = "layoutControlItem4";
		this.layoutControlItem4.Size = new System.Drawing.Size(238, 44);
		this.layoutControlItem4.Text = "Date:";
		this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem4.TextSize = new System.Drawing.Size(137, 13);
		this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
		this.layoutControlItem8.Control = this.gridControl2;
		this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
		this.layoutControlItem8.Location = new System.Drawing.Point(0, 274);
		this.layoutControlItem8.Name = "layoutControlItem8";
		this.layoutControlItem8.Size = new System.Drawing.Size(238, 210);
		this.layoutControlItem8.Text = "Expense Categories";
		this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem8.TextSize = new System.Drawing.Size(137, 19);
		this.layoutControlItem9.Control = this.txtChequeNo;
		this.layoutControlItem9.CustomizationFormText = "Cheaque No:";
		this.layoutControlItem9.Location = new System.Drawing.Point(0, 186);
		this.layoutControlItem9.Name = "layoutControlItem9";
		this.layoutControlItem9.Size = new System.Drawing.Size(238, 44);
		this.layoutControlItem9.Text = "Cheaque No:";
		this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem9.TextSize = new System.Drawing.Size(137, 13);
		this.emptySpaceItem2.AllowHotTrack = false;
		this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
		this.emptySpaceItem2.Location = new System.Drawing.Point(238, 302);
		this.emptySpaceItem2.Name = "emptySpaceItem2";
		this.emptySpaceItem2.Size = new System.Drawing.Size(23, 182);
		this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.Control = this.simpleButton2;
		this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
		this.layoutControlItem11.Location = new System.Drawing.Point(238, 276);
		this.layoutControlItem11.Name = "layoutControlItem11";
		this.layoutControlItem11.Size = new System.Drawing.Size(23, 26);
		this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem11.TextVisible = false;
		this.emptySpaceItem1.AllowHotTrack = false;
		this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
		this.emptySpaceItem1.Location = new System.Drawing.Point(238, 28);
		this.emptySpaceItem1.Name = "emptySpaceItem1";
		this.emptySpaceItem1.Size = new System.Drawing.Size(23, 222);
		this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.Control = this.simpleButton4;
		this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
		this.layoutControlItem7.Location = new System.Drawing.Point(261, 457);
		this.layoutControlItem7.Name = "layoutControlItem7";
		this.layoutControlItem7.Size = new System.Drawing.Size(333, 27);
		this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem7.TextVisible = false;
		this.layoutControlItem6.Control = this.simpleButton3;
		this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
		this.layoutControlItem6.Location = new System.Drawing.Point(594, 457);
		this.layoutControlItem6.Name = "layoutControlItem6";
		this.layoutControlItem6.Size = new System.Drawing.Size(272, 27);
		this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem6.TextVisible = false;
		this.layoutControlItem10.Control = this.simpleButton1;
		this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
		this.layoutControlItem10.Location = new System.Drawing.Point(238, 250);
		this.layoutControlItem10.Name = "layoutControlItem10";
		this.layoutControlItem10.Size = new System.Drawing.Size(23, 26);
		this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem10.TextVisible = false;
		this.layoutControlItem12.Control = this.txtAccNo;
		this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
		this.layoutControlItem12.Location = new System.Drawing.Point(0, 118);
		this.layoutControlItem12.Name = "layoutControlItem12";
		this.layoutControlItem12.Size = new System.Drawing.Size(238, 24);
		this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem12.TextVisible = false;
		this.layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
		this.layoutControlItem2.Control = this.cboCashAccount;
		this.layoutControlItem2.CustomizationFormText = "Cash Account";
		this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
		this.layoutControlItem2.Name = "layoutControlItem2";
		this.layoutControlItem2.Size = new System.Drawing.Size(238, 44);
		this.layoutControlItem2.Text = "Funding Account";
		this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem2.TextSize = new System.Drawing.Size(137, 13);
		this.layoutControlItem5.Control = this.txtStandingBalance;
		this.layoutControlItem5.CustomizationFormText = "Cash Balance:";
		this.layoutControlItem5.Location = new System.Drawing.Point(0, 72);
		this.layoutControlItem5.Name = "layoutControlItem5";
		this.layoutControlItem5.Size = new System.Drawing.Size(238, 46);
		this.layoutControlItem5.Text = "Account Balance:";
		this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem5.TextSize = new System.Drawing.Size(137, 13);
		this.layoutControlItem3.Control = this.txtVoucherNo;
		this.layoutControlItem3.CustomizationFormText = "Voucher No:";
		this.layoutControlItem3.Location = new System.Drawing.Point(0, 230);
		this.layoutControlItem3.Name = "layoutControlItem3";
		this.layoutControlItem3.Size = new System.Drawing.Size(238, 44);
		this.layoutControlItem3.Text = "Voucher No:";
		this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
		this.layoutControlItem3.TextSize = new System.Drawing.Size(137, 13);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.labelControl1.Appearance.Options.UseFont = true;
		this.labelControl1.Appearance.Options.UseTextOptions = true;
		this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
		this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
		this.labelControl1.Location = new System.Drawing.Point(4, 4);
		this.labelControl1.Name = "labelControl1";
		this.labelControl1.Size = new System.Drawing.Size(862, 24);
		this.labelControl1.StyleController = this.layoutControl1;
		this.labelControl1.TabIndex = 16;
		this.labelControl1.Text = "Capital Expenses";
		this.layoutControlItem13.Control = this.labelControl1;
		this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
		this.layoutControlItem13.Name = "layoutControlItem13";
		this.layoutControlItem13.Size = new System.Drawing.Size(866, 28);
		this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
		this.layoutControlItem13.TextVisible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(this.layoutControl1);
		base.Name = "usrCapitalExpenses";
		base.Size = new System.Drawing.Size(870, 488);
		base.Load += new System.EventHandler(usrPettyExpenses_Load);
		((System.ComponentModel.ISupportInitialize)this.layoutControl1).EndInit();
		this.layoutControl1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.txtAccNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.cboCashAccount.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtChequeNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtStandingBalance.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridView2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtVoucherDate.Properties.CalendarTimeProperties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dtVoucherDate.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.txtVoucherNo.Properties).EndInit();
		((System.ComponentModel.ISupportInitialize)this.gridControl1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dragOver).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.repositoryItemTextEdit1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlGroup1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.emptySpaceItem1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.layoutControlItem13).EndInit();
		base.ResumeLayout(false);
	}
}
