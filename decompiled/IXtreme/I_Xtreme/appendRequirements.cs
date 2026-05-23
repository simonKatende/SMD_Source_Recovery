using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AlienAge.Connectivity;
using DevExpress.XtraEditors;
using I_Xtreme.ExtremeClasses;

namespace I_Xtreme;

public class appendRequirements : XtraForm
{
	private int i;

	private int k;

	private int maximum = 0;

	private bool IsPIK = false;

	private string Item = "";

	private string currentTask = string.Empty;

	private IContainer components = null;

	private BackgroundWorker bgAppendRequirements;

	private System.Windows.Forms.Timer timer1;

	private ProgressBarControl progressBarControl1;

	public appendRequirements(bool IsPIK, string Item)
	{
		InitializeComponent();
		this.IsPIK = IsPIK;
		this.Item = Item;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		k++;
		if (k == 5)
		{
			timer1.Enabled = false;
			bgAppendRequirements.RunWorkerAsync();
		}
	}

	private void bgAppendRequirements_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		Text = "Students billed successfully";
		XtraMessageBox.Show("Students billed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void appendRequirements_Load(object sender, EventArgs e)
	{
		timer1.Enabled = true;
	}

	private void bgAppendRequirements_DoWork(object sender, DoWorkEventArgs e)
	{
		AppendRequirements();
	}

	private void AppendRequirements()
	{
		string commandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,Narration,CaptureDate,IsSent) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@Narration,@CaptureDate,@IsSent)";
		if (IsPIK)
		{
			PayableInKind.AddNewStockItem(Item);
			commandText = "INSERT INTO FeesPayment (StudentNumber,DateOfPayment,SemesterId,accNo,Particulars,Debit,Credit,Balance,ModeOfPayment,BankId,BankSlipNo,Narration,CaptureDate,IsSent,IsPIK,PIKPaid,PIKQty) VALUES (@StudentNumber,@DateOfPayment,@SemesterId,@accNo,@Particulars,@Debit,@Credit,@Balance,@ModeOfPayment,@BankId,@BankSlipNo,@Narration,@CaptureDate,@IsSent,@IsPIK,@PIKPaid,@PIKQty)";
		}
		if (StudentRequirements.CategoryValue == 0)
		{
			currentTask = "Debiting Fees to selected students...";
			int[] selectedRows = StudentRequirements.gridView.GetSelectedRows();
			maximum = selectedRows.Length;
			this.i = 0;
			for (int i = 0; i < selectedRows.Length; i++)
			{
				string text = StudentRequirements.gridView.GetRowCellValue(selectedRows[i], "StudentNumber").ToString().TrimStart()
					.TrimEnd();
				string text2 = StudentRequirements.gridView.GetRowCellValue(selectedRows[i], "Name").ToString().TrimStart()
					.TrimEnd();
				double result = (double.TryParse(StudentRequirements.gridView.GetRowCellValue(selectedRows[i], "cashOnAccount").ToString(), out result) ? result : 0.0);
				double result2 = (double.TryParse(StudentRequirements.gridView.GetRowCellValue(selectedRows[i], "RequiredFees").ToString(), out result2) ? result2 : 0.0);
				double result3 = (double.TryParse(StudentRequirements.gridView.GetRowCellValue(selectedRows[i], "FeesDiscount").ToString(), out result3) ? result3 : 0.0);
				double num = result2 - result3;
				using (SqlConnection sqlConnection = new SqlConnection(DataConnection.ConnectToDatabase()))
				{
					sqlConnection.Open();
					using SqlCommand sqlCommand = new SqlCommand
					{
						Connection = sqlConnection,
						CommandText = $"SELECT StudentNumber FROM FeesPayment WHERE StudentNumber='{text}' AND SemesterId='{StudentRequirements.Semester()}' AND Particulars='Fees'",
						CommandType = CommandType.Text
					};
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					if (!sqlDataReader.HasRows)
					{
						sqlConnection.Close();
						double num2 = result + num;
						using SqlConnection sqlConnection2 = new SqlConnection(DataConnection.ConnectToDatabase());
						sqlConnection2.Open();
						SqlTransaction sqlTransaction = sqlConnection2.BeginTransaction();
						string captureDate = CaptureDate.GetCaptureDate();
						using (SqlCommand sqlCommand2 = new SqlCommand
						{
							Transaction = sqlTransaction,
							Connection = sqlConnection2,
							CommandText = commandText,
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter = sqlCommand2.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter.Value = text;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@DateOfPayment", SqlDbType.DateTime);
							sqlParameter.Value = StudentRequirements.AppendDate.ToShortDateString();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@SemesterId", SqlDbType.VarChar, 18);
							sqlParameter.Value = StudentRequirements.Semester();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
							sqlParameter.Value = StudentRequirements.AccountNumber;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
							sqlParameter.Value = StudentRequirements.RequiredItem();
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@Debit", SqlDbType.Money);
							sqlParameter.Value = num;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@Credit", SqlDbType.Money);
							sqlParameter.Value = 0;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@Balance", SqlDbType.Money);
							sqlParameter.Value = num2;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar, 25);
							sqlParameter.Value = string.Empty;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@BankId", SqlDbType.VarChar, 50);
							sqlParameter.Value = string.Empty;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@BankSlipNo", SqlDbType.VarChar, 50);
							sqlParameter.Value = string.Empty;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
							sqlParameter.Value = string.Empty;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
							sqlParameter.Value = captureDate;
							sqlParameter.Direction = ParameterDirection.Input;
							sqlParameter = sqlCommand2.Parameters.Add("@IsSent", SqlDbType.Bit);
							sqlParameter.Value = 1;
							sqlParameter.Direction = ParameterDirection.Input;
							if (IsPIK)
							{
								sqlParameter = sqlCommand2.Parameters.Add("@IsPIK", SqlDbType.Bit);
								sqlParameter.Value = 1;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@PIKPaid", SqlDbType.Bit);
								sqlParameter.Value = 0;
								sqlParameter.Direction = ParameterDirection.Input;
								sqlParameter = sqlCommand2.Parameters.Add("@PIKQty", SqlDbType.Int);
								sqlParameter.Value = 1;
								sqlParameter.Direction = ParameterDirection.Input;
							}
							sqlCommand2.ExecuteNonQuery();
						}
						using (SqlCommand sqlCommand3 = new SqlCommand
						{
							Transaction = sqlTransaction,
							Connection = sqlConnection2,
							CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
							CommandType = CommandType.Text
						})
						{
							SqlParameter sqlParameter2 = sqlCommand3.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
							sqlParameter2.Value = text;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlParameter2 = sqlCommand3.Parameters.Add("@cashOnAccount", SqlDbType.Money);
							sqlParameter2.Value = num2;
							sqlParameter2.Direction = ParameterDirection.Input;
							sqlCommand3.ExecuteNonQuery();
						}
						sqlTransaction.Commit();
						sqlConnection2.Close();
					}
				}
				this.i++;
				Thread.Sleep(25);
				bgAppendRequirements.ReportProgress(this.i);
			}
			return;
		}
		currentTask = $"Debiting {StudentRequirements.RequiredItem()} to selected students... ";
		int[] selectedRows2 = StudentRequirements.gridView.GetSelectedRows();
		maximum = selectedRows2.Length;
		this.i = 0;
		for (int j = 0; j < selectedRows2.Length; j++)
		{
			string text3 = StudentRequirements.gridView.GetRowCellValue(selectedRows2[j], "StudentNumber").ToString().TrimStart()
				.TrimEnd();
			string text4 = StudentRequirements.gridView.GetRowCellValue(selectedRows2[j], "Name").ToString().TrimStart()
				.TrimEnd();
			double result4 = (double.TryParse(StudentRequirements.gridView.GetRowCellValue(selectedRows2[j], "cashOnAccount").ToString(), out result4) ? result4 : 0.0);
			using (SqlConnection sqlConnection3 = new SqlConnection(DataConnection.ConnectToDatabase()))
			{
				sqlConnection3.Open();
				using SqlCommand sqlCommand4 = new SqlCommand
				{
					Connection = sqlConnection3,
					CommandText = $"SELECT StudentNumber FROM FeesPayment WHERE StudentNumber='{text3}' AND SemesterId='{StudentRequirements.Semester()}' AND Particulars='{StudentRequirements.RequiredItem()}'",
					CommandType = CommandType.Text
				};
				SqlDataReader sqlDataReader2 = sqlCommand4.ExecuteReader();
				if (!sqlDataReader2.HasRows)
				{
					sqlConnection3.Close();
					double num3 = Math.Abs(StudentRequirements.RequiredAmount);
					double num4 = result4 + num3;
					using SqlConnection sqlConnection4 = new SqlConnection(DataConnection.ConnectToDatabase());
					sqlConnection4.Open();
					SqlTransaction sqlTransaction2 = sqlConnection4.BeginTransaction();
					string captureDate2 = CaptureDate.GetCaptureDate();
					using (SqlCommand sqlCommand5 = new SqlCommand
					{
						Transaction = sqlTransaction2,
						Connection = sqlConnection4,
						CommandText = commandText,
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter3 = sqlCommand5.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter3.Value = text3;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@DateOfPayment", SqlDbType.DateTime);
						sqlParameter3.Value = StudentRequirements.AppendDate.ToShortDateString();
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@SemesterId", SqlDbType.VarChar, 18);
						sqlParameter3.Value = StudentRequirements.Semester();
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@accNo", SqlDbType.VarChar, 9);
						sqlParameter3.Value = StudentRequirements.AccountNumber;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@Particulars", SqlDbType.VarChar, 50);
						sqlParameter3.Value = StudentRequirements.RequiredItem();
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@Debit", SqlDbType.Money);
						sqlParameter3.Value = num3;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@Credit", SqlDbType.Money);
						sqlParameter3.Value = 0;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@Balance", SqlDbType.Money);
						sqlParameter3.Value = num4;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@ModeOfPayment", SqlDbType.VarChar, 25);
						sqlParameter3.Value = string.Empty;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@BankId", SqlDbType.VarChar, 50);
						sqlParameter3.Value = string.Empty;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@BankSlipNo", SqlDbType.VarChar, 50);
						sqlParameter3.Value = string.Empty;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@Narration", SqlDbType.VarChar, 50);
						sqlParameter3.Value = string.Empty;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@CaptureDate", SqlDbType.VarChar, 100);
						sqlParameter3.Value = captureDate2;
						sqlParameter3.Direction = ParameterDirection.Input;
						sqlParameter3 = sqlCommand5.Parameters.Add("@IsSent", SqlDbType.Bit);
						sqlParameter3.Value = 1;
						sqlParameter3.Direction = ParameterDirection.Input;
						if (IsPIK)
						{
							sqlParameter3 = sqlCommand5.Parameters.Add("@IsPIK", SqlDbType.Bit);
							sqlParameter3.Value = 1;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@PIKPaid", SqlDbType.Bit);
							sqlParameter3.Value = 0;
							sqlParameter3.Direction = ParameterDirection.Input;
							sqlParameter3 = sqlCommand5.Parameters.Add("@PIKQty", SqlDbType.Int);
							sqlParameter3.Value = 1;
							sqlParameter3.Direction = ParameterDirection.Input;
						}
						sqlCommand5.ExecuteNonQuery();
					}
					using (SqlCommand sqlCommand6 = new SqlCommand
					{
						Transaction = sqlTransaction2,
						Connection = sqlConnection4,
						CommandText = "UPDATE tbl_Stud SET cashOnAccount=@cashOnAccount WHERE StudentNumber=@StudentNumber",
						CommandType = CommandType.Text
					})
					{
						SqlParameter sqlParameter4 = sqlCommand6.Parameters.Add("@StudentNumber", SqlDbType.VarChar, 12);
						sqlParameter4.Value = text3;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlParameter4 = sqlCommand6.Parameters.Add("@cashOnAccount", SqlDbType.Money);
						sqlParameter4.Value = num4;
						sqlParameter4.Direction = ParameterDirection.Input;
						sqlCommand6.ExecuteNonQuery();
					}
					sqlTransaction2.Commit();
					sqlConnection4.Close();
				}
			}
			this.i++;
			Thread.Sleep(25);
			bgAppendRequirements.ReportProgress(this.i);
		}
	}

	private void bgAppendRequirements_ProgressChanged(object sender, ProgressChangedEventArgs e)
	{
		progressBarControl1.Properties.Maximum = maximum;
		Text = currentTask;
		progressBarControl1.Position = e.ProgressPercentage;
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
		this.bgAppendRequirements = new System.ComponentModel.BackgroundWorker();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).BeginInit();
		base.SuspendLayout();
		this.bgAppendRequirements.WorkerReportsProgress = true;
		this.bgAppendRequirements.WorkerSupportsCancellation = true;
		this.bgAppendRequirements.DoWork += new System.ComponentModel.DoWorkEventHandler(bgAppendRequirements_DoWork);
		this.bgAppendRequirements.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(bgAppendRequirements_ProgressChanged);
		this.bgAppendRequirements.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgAppendRequirements_RunWorkerCompleted);
		this.timer1.Enabled = true;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.progressBarControl1.Location = new System.Drawing.Point(0, 0);
		this.progressBarControl1.Name = "progressBarControl1";
		this.progressBarControl1.Properties.ShowTitle = true;
		this.progressBarControl1.Size = new System.Drawing.Size(319, 43);
		this.progressBarControl1.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(319, 43);
		base.ControlBox = false;
		base.Controls.Add(this.progressBarControl1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		base.MaximizeBox = false;
		base.Name = "appendRequirements";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Appending requirements...";
		base.Load += new System.EventHandler(appendRequirements_Load);
		((System.ComponentModel.ISupportInitialize)this.progressBarControl1.Properties).EndInit();
		base.ResumeLayout(false);
	}
}
