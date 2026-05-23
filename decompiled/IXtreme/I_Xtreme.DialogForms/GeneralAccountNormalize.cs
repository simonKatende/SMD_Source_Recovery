using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;

namespace I_Xtreme.DialogForms;

public class GeneralAccountNormalize : XtraForm
{
	private int i = 0;

	private int k = 0;

	private SqlTransaction trans;

	private IContainer components = null;

	private ProgressBarControl progressBarControl1;

	private Timer timer1;

	public GeneralAccountNormalize()
	{
		InitializeComponent();
	}

	private void DeleteAllDataToNormalize()
	{
		try
		{
			Application.DoEvents();
			Text = "Deleting data..";
			using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection.Open();
				using SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "DELETE FROM FeesPayment WHERE StudentNumber=''",
					CommandType = CommandType.Text
				};
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			using (SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection2.Open();
				using SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection2,
					CommandText = "DELETE FROM FeesPayment WHERE accNo=''",
					CommandType = CommandType.Text
				};
				sqlCommand2.ExecuteNonQuery();
				sqlConnection2.Close();
			}
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using SqlCommand sqlCommand3 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE accNo='5003-0001'",
					CommandType = CommandType.Text
				};
				sqlCommand3.ExecuteNonQuery();
				sqlConnection3.Close();
			}
			using (SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection4.Open();
				using SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection4,
					CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE Narration LIKE '%Fees Payment%' OR particulars LIKE '%Fees Payment%'",
					CommandType = CommandType.Text
				};
				sqlCommand4.ExecuteNonQuery();
				sqlConnection4.Close();
			}
			using (SqlConnection sqlConnection5 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection5.Open();
				using SqlCommand sqlCommand5 = new SqlCommand
				{
					Connection = sqlConnection5,
					CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE accNo='3004-0001'",
					CommandType = CommandType.Text
				};
				sqlCommand5.ExecuteNonQuery();
				sqlConnection5.Close();
			}
			using (SqlConnection sqlConnection6 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection6.Open();
				using SqlCommand sqlCommand6 = new SqlCommand
				{
					Connection = sqlConnection6,
					CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE Credit=0 AND Debit=0",
					CommandType = CommandType.Text
				};
				sqlCommand6.ExecuteNonQuery();
				sqlConnection6.Close();
			}
			using (SqlConnection sqlConnection7 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection7.Open();
				using SqlCommand sqlCommand7 = new SqlCommand
				{
					Connection = sqlConnection7,
					CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE accNo=''",
					CommandType = CommandType.Text
				};
				sqlCommand7.ExecuteNonQuery();
				sqlConnection7.Close();
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_generalAccounts_Sub WHERE accNo='1001'", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "StudentPayables");
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				using SqlConnection sqlConnection8 = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection8.Open();
				using SqlCommand sqlCommand8 = new SqlCommand
				{
					Connection = sqlConnection8,
					CommandText = "DELETE FROM tbl_StatementOfAffairs WHERE accNo=@accNo",
					CommandType = CommandType.Text
				};
				SqlParameter sqlParameter = sqlCommand8.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
				sqlParameter.Value = row["subAccountNo"];
				sqlParameter.Direction = ParameterDirection.Input;
				sqlCommand8.ExecuteNonQuery();
				sqlConnection8.Close();
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private string StudentFullName(string studentNo)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT fullName FROM tbl_Stud WHERE StudentNumber='{studentNo}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "FullName");
		string result = string.Empty;
		IEnumerator enumerator = dataSet.Tables[0].Rows.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				DataRow dataRow = (DataRow)enumerator.Current;
				result = dataRow["fullName"].ToString();
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

	private string AccountNumberInTransit(string AccountName)
	{
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"SELECT subAccountNo FROM tbl_generalAccounts_Sub WHERE SubAccoutName='{AccountName}'", DataConnection.ConnectToDatabase());
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "AccountNumber");
		string result = string.Empty;
		if (dataSet.Tables[0].Rows.Count == 0)
		{
			result = "3002-0001";
		}
		else
		{
			{
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
			}
		}
		return result;
	}

	private void DebitAccountReceivable()
	{
		try
		{
			Application.DoEvents();
			Text = "Normalizing bills...";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM FeesPayment WHERE Credit=0", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AppendedItems");
			progressBarControl1.Properties.Maximum = dataSet.Tables[0].Rows.Count;
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = "3004-0001";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = row["Particulars"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter.Value = row["SemesterId"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).ToString("MMMM");
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).Year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter.Value = Convert.ToDouble(row["Debit"]);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter.Value = 0;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter.Value = row["CaptureDate"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = StudentFullName(row["StudentNumber"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				i++;
				Application.DoEvents();
				progressBarControl1.Position = i;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CreditFeesReceivaleDebotReceivingAccount()
	{
		try
		{
			Application.DoEvents();
			i = 0;
			progressBarControl1.Position = 0;
			Application.DoEvents();
			Text = "Normalizing payments...";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT StudentNumber,DateOfPayment,SemesterId,SUM(Credit) AS Credit,ModeOfPayment,BankId,BankSlipNo,CaptureDate FROM FeesPayment WHERE Debit=0 GROUP BY StudentNumber,DateOfPayment,SemesterId,ModeOfPayment,BankId ,BankSlipNo,CaptureDate", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AppendedItems");
			progressBarControl1.Properties.Maximum = dataSet.Tables[0].Rows.Count;
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = "3004-0001";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = "Fees Payment-" + StudentFullName(row["StudentNumber"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter.Value = row["SemesterId"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).ToString("MMMM");
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).Year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter.Value = 0;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter.Value = Convert.ToDouble(row["Credit"]);
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter.Value = row["CaptureDate"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = "Fees Payment-" + StudentFullName(row["StudentNumber"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				using (SqlCommand sqlCommand2 = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter2 = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter2.Value = row["BankId"].ToString();
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter2.Value = "Fees Payment-" + StudentFullName(row["StudentNumber"].ToString());
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter2.Value = row["SemesterId"];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter2.Value = Convert.ToDateTime(row["DateOfPayment"]);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter2.Value = Convert.ToDateTime(row["DateOfPayment"]).ToString("MMMM");
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter2.Value = Convert.ToDateTime(row["DateOfPayment"]).Year;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter2.Value = Convert.ToDouble(row["Credit"]);
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter2.Value = 0;
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter2.Value = row["CaptureDate"];
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlParameter2 = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter2.Value = "Fees Payment-" + StudentFullName(row["StudentNumber"].ToString());
					sqlParameter2.Direction = ParameterDirection.Input;
					sqlCommand2.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
				i++;
				Application.DoEvents();
				progressBarControl1.Position = i;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void NormalizePrepayments()
	{
		try
		{
			string captureDate = CaptureDate.GetCaptureDate();
			Application.DoEvents();
			i = 0;
			progressBarControl1.Position = 0;
			Application.DoEvents();
			Text = "Normalizing prepayments...";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbl_Stud WHERE cashOnAccount<0", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AppendedItems");
			progressBarControl1.Properties.Maximum = dataSet.Tables[0].Rows.Count;
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				trans = sqlConnection.BeginTransaction();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					Transaction = trans,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Debit,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Debit,@Credit,@captureDate,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = "5003-0001";
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = "Fees Payment-" + StudentFullName(row["StudentNumber"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter.Value = string.Empty;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter.Value = FinalAccounts.BooksBeginningDate;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter.Value = FinalAccounts.BooksBeginningDate.ToString("MMMM");
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter.Value = FinalAccounts.BooksBeginningDate.Year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Debit", SqlDbType.Money);
					sqlParameter.Value = 0;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter.Value = Math.Abs(Convert.ToDouble(row["cashOnAccount"]));
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter.Value = captureDate;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = "Fees Payment-" + StudentFullName(row["StudentNumber"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
				}
				trans.Commit();
				sqlConnection.Close();
				i++;
				Application.DoEvents();
				progressBarControl1.Position = i;
			}
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void CreditIncome()
	{
		try
		{
			Application.DoEvents();
			i = 0;
			progressBarControl1.Position = 0;
			Application.DoEvents();
			Text = "Normalizing revenue...";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM FeesPayment WHERE Debit=0", DataConnection.ConnectToDatabase());
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AppendedItems");
			progressBarControl1.Properties.Maximum = dataSet.Tables[0].Rows.Count;
			foreach (DataRow row in dataSet.Tables[0].Rows)
			{
				SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase());
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand
				{
					Connection = sqlConnection,
					CommandText = "INSERT INTO tbl_StatementOfAffairs (accNo,particulars,SemesterId,_date,month,year,Credit,captureDate,Narration) VALUES (@accNo,@particulars,@SemesterId,@_date,@month,@year,@Credit,@captureDate,@Narration)",
					CommandType = CommandType.Text
				})
				{
					SqlParameter sqlParameter = sqlCommand.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
					sqlParameter.Value = row["accNo"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@particulars", SqlDbType.VarChar, 50);
					sqlParameter.Value = string.Format("{0}-{1}", row["StudentNumber"], StudentFullName(row["StudentNumber"].ToString()));
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@SemesterId", SqlDbType.VarChar, 13);
					sqlParameter.Value = row["SemesterId"];
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@_date", SqlDbType.DateTime);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).ToShortDateString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@month", SqlDbType.VarChar, 9);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).ToString("MMMM");
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@year", SqlDbType.Int);
					sqlParameter.Value = Convert.ToDateTime(row["DateOfPayment"]).Year;
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Credit", SqlDbType.Money);
					sqlParameter.Value = Convert.ToDouble(row["Credit"].ToString());
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@captureDate", SqlDbType.VarChar, 50);
					sqlParameter.Value = row["CaptureDate"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter = sqlCommand.Parameters.Add("@Narration", SqlDbType.VarChar);
					sqlParameter.Value = row["Particulars"].ToString();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				i++;
				Application.DoEvents();
				progressBarControl1.Position = i;
			}
			XtraMessageBox.Show("All processes completed successfully.", "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Close();
		}
		catch (Exception ex)
		{
			XtraMessageBox.Show(ex.Message, "School Management Dynamics", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 3)
		{
			timer1.Enabled = false;
			DeleteAllDataToNormalize();
			DebitAccountReceivable();
			CreditFeesReceivaleDebotReceivingAccount();
			NormalizePrepayments();
			CreditIncome();
		}
	}

	private void GeneralAccountNormalize_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
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
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(337, 31);
		this.progressBarControl1.TabIndex = 0;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(337, 31);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "GeneralAccountNormalize";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Normalizing legders...";
		base.Load += new System.EventHandler(GeneralAccountNormalize_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
